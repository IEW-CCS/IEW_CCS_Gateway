using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Collections.Concurrent;

using System.Threading;

using System.Xml.Serialization;
using System.Xml;


using IEW.Platform.Kernel.Log;


namespace IEW.ObjectManager
{
    public class ObjectManager
    {
        public GateWayManager GatewayManager = null;
        public TagSetManager TagSetManager = null;
        public EDCManager EDCManager = null;

        private System.Threading.Thread Thread_Timer_Check_EDC = null;
        private System.Threading.Timer Timer_Check_EDC = null;
        private ConcurrentQueue<Tuple<string, string>> _Write_EDC_File = new ConcurrentQueue<Tuple<string, string>>();

        #region Gateway Constructor
        public void GatewayManager_Initial()
        {
            this.GatewayManager = new GateWayManager();
        }
        public void GatewayManager_Initial(string Json)
        {
            this.GatewayManager = JsonConvert.DeserializeObject<GateWayManager>(Json);
        }
        #endregion

        #region Gateway Method
        public void GatewayManager_Set_TagValue(cls_ProcRecv_CollectData ProcRecv_CollectData)
        {
            string _GateWayID = ProcRecv_CollectData.GateWayID;
            string _DeviceID = ProcRecv_CollectData.Device_ID;

            cls_Gateway_Info Gateway = GatewayManager.gateway_list.Where(p => p.gateway_id == _GateWayID).FirstOrDefault();
            if (Gateway != null)
            {
                cls_Device_Info Device = Gateway.device_info.Where(p => p.device_name == _DeviceID).FirstOrDefault();
                if (Device != null)
                {
                    Tuple<string, string> _tag = null;
                    while (ProcRecv_CollectData.Prod_EDC_Data.TryDequeue(out _tag))
                    {
                        if (Device.tag_info.ContainsKey(_tag.Item1))
                        {
                            cls_Tag tag = Device.tag_info[_tag.Item1];
                            tag.Value = _tag.Item2;
                            Device.tag_info.AddOrUpdate(_tag.Item1, tag, (key, oldvalue) => tag);
                        }
                    }
                }
                else
                {
                    NLogManager.Logger.LogError("Service", GetType().Name, MethodInfo.GetCurrentMethod().Name, string.Format("Device {0} Not Exist, So Skip Update Tag Value", _DeviceID));
                }
            }
            else
            {
                NLogManager.Logger.LogError("Service", GetType().Name, MethodInfo.GetCurrentMethod().Name, string.Format("Gateway {0} Not Exist, So Skip Update Tag Value", _GateWayID));

            }


        }
        public string GatewayManager_ToJson_String()
        {

            try
            {
                return JsonConvert.SerializeObject(GatewayManager, Newtonsoft.Json.Formatting.Indented);
            }
            catch
            {
                return null;
            }
        }
        public string GatewayCommand_ToJson_String(string _Cmd_Type, string _Report_Interval, string _Trace_ID, string _GateWayID, string _DeviceID)
        {
            cls_Gateway_Info Gateway = GatewayManager.gateway_list.Where(p => p.gateway_id == _GateWayID).FirstOrDefault();
            if (Gateway == null)
            {
                return null;
            }
            else
            {
                cls_Device_Info Device = Gateway.device_info.Where(p => p.device_name == _DeviceID).FirstOrDefault();
                if (Device == null)
                {
                    return null;
                }
                else
                {

                    cls_Collect collect_cmd = new cls_Collect(_Cmd_Type, _Report_Interval, _Trace_ID, Device);
                    return JsonConvert.SerializeObject(collect_cmd, Newtonsoft.Json.Formatting.Indented);
                }
            }
        }
        #endregion

        #region Tagset Constructor
        public void TagSetManager_Initial()
        {
            this.TagSetManager = new TagSetManager();
        }
        public void TagSetManager_Initial(string Json)
        {
            this.TagSetManager = JsonConvert.DeserializeObject<TagSetManager>(Json);
        }
        #endregion




        #region EDCManager Method
        public T EDC_Deserialize<T>(string s)
        {
            XmlDocument xdoc = new XmlDocument();
            try
            {
                xdoc.LoadXml(s);
                XmlNodeReader reader = new XmlNodeReader(xdoc.DocumentElement);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                object obj = ser.Deserialize(reader);
                return (T)obj;
            }
            catch
            {
                return default(T);
            }
        }
        private void EDCManager_Stop()
        {
            this.Thread_Timer_Check_EDC.Abort();
        }
        private void EDCManager_Start(int interval)
        {
            if (interval == 0)
                interval = 1000;  // Default 1s scan 一次

            //使用匿名方法，建立帶有參數的委派
            this.Thread_Timer_Check_EDC = new System.Threading.Thread
            (
               delegate (object value)
               {
                   int Interval = Convert.ToInt32(value);
                   Timer_Check_EDC = new System.Threading.Timer(new System.Threading.TimerCallback(EDCManager_TimerTask), null, 1000, Interval);
               }
            );
            this.Thread_Timer_Check_EDC.Start(interval);
        }
        private void EDCManager_TimerTask(object timerState)
        {
            // 在Timer task中一直檢查是否符合EDC上報條件。
            DateTime CurrentTime = DateTime.Now;
            Parallel.ForEach(EDCManager.gateway_edc, e =>
            {
                string EDC_string = string.Empty;
                bool condition = false;
                switch (e.report_tpye)
                {
                    case "trigger":
                        if (e.triggered == true)
                            condition = true;
                        break;
                    case "interval":
                        TimeSpan ts = e.LastReportDatetime - CurrentTime;
                        double diff = ts.TotalSeconds;
                        if (diff > e.report_interval)
                        {
                            condition = true;
                            e.LastReportDatetime = CurrentTime;
                        }
                        break;

                    default:
                        condition = false;
                        break;
                }

                if (condition)
                {
                    cls_Gateway_Info Gateway = GatewayManager.gateway_list.Where(p => p.gateway_id == e.gateway_id).FirstOrDefault();
                    if (Gateway != null)
                    {
                        cls_Device_Info Device = Gateway.device_info.Where(p => p.device_name == e.device_id).FirstOrDefault();
                        if (Device != null)
                        {
                            //  EDC_Report tempEDC = new EDC_Report();  // 考慮直接使用反序列畫
                            // 直接在local 存放一個 base 的 EDC 檔案，直接返序列畫成物件進行對應
                            var sr = new StreamReader(e.baseEDCPath);
                            EDC_Report tempEDC  = EDC_Deserialize<EDC_Report>(sr.ReadToEnd());



                            foreach (Tuple<string, string> edctag in e.tag_info)
                            {
                                EDC_Report.IARYClass _data_count = tempEDC.CreateIARYClass();
                                _data_count.ITEM_NAME = edctag.Item1;
                                _data_count.ITEM_TYPE = "X";
                                _data_count.ITEM_VALUE = Device.tag_info[edctag.Item2].Value;
                            }
                            e.LastReportDatetime = CurrentTime;
                            e.triggered = false;
                            EDC_string = tempEDC.EDC_String_Serialize();
                        }
                    }
                }



                if (EDC_string != string.Empty)
                {
                    _Write_EDC_File.Enqueue(Tuple.Create(e.ReportEDCPath, EDC_string));
                }
            });

            EDCManager_ReportFile();
        }
        public void EDCManager_ReportFile()
        {
            if (_Write_EDC_File.Count > 0)
            {
                Tuple<string, string> _msg = null;
                while (_Write_EDC_File.TryDequeue(out _msg))
                {
                    string save_file_path = _msg.Item1;
                    string EDC_Data = _msg.Item2;

                    try
                    {
                        if (!Directory.Exists(Path.GetDirectoryName(save_file_path)))
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(save_file_path));
                        }
                        string temp_name = save_file_path + ".tmp";
                        using (FileStream fs = System.IO.File.Open(temp_name, FileMode.Create))
                        {
                            using (StreamWriter EDCWriter = new StreamWriter(fs, Encoding.UTF8))
                            {
                                EDCWriter.Write(EDC_Data);
                                EDCWriter.Flush();
                                fs.Flush();
                            }
                        }

                        if (System.IO.File.Exists(save_file_path))
                            System.IO.File.Delete(save_file_path);
                        while (System.IO.File.Exists(save_file_path))
                            Thread.Sleep(1);
                        System.IO.File.Move(temp_name, save_file_path);
                        NLogManager.Logger.LogInfo("Service", GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", string.Format("Save EDC File Successful Path: {0}.", save_file_path));

                    }
                    catch (Exception ex)
                    {
                        NLogManager.Logger.LogError("Service", GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", string.Format("Write EDC File Faild Exception Msg : {0}. ", ex.Message));
                    }
                }
            }




        }
        #endregion
    }
}
