using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IEW.Platform.Kernel.Common;
using IEW.Platform.Kernel.Log;
using System.Windows.Forms;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Collections.Concurrent;
using System.Threading;

//Add
using System.IO;
using System.IO.Ports;

using System.Xml;

namespace IEW.IOTEDCService
{
    public class IOTEDCService : AbstractService
    {

        private string _provider = string.Empty;
        private string _connectstring = string.Empty;
        private string _edcpath = string.Empty;
        private int _reportinterval = 60000;

        internal static ConcurrentDictionary<string, IOT_Device> _IOT_Device = new ConcurrentDictionary<string, IOT_Device>();

        internal static ConcurrentDictionary<string, cls_EDC_Info> _IOT_EDC = new ConcurrentDictionary<string, cls_EDC_Info>();
        internal static ConcurrentDictionary<string, IOT_EDC_GLS_INFO> _IOT_EDC_GlassInfo = new ConcurrentDictionary<string, IOT_EDC_GLS_INFO>();
        internal static ConcurrentQueue<Tuple<string, string>> _Write_EDC_File = new ConcurrentQueue<Tuple<string, string>>();

        internal static ConcurrentDictionary<string, ConcurrentDictionary<string, Tuple<double, double>>> _EDC_Item_Spec = new ConcurrentDictionary<string, ConcurrentDictionary<string, Tuple<double, double>>>();

        internal static string[] item_names = {"RPM","OA","OA_S","Peak","Peak_S","PtoP","PtoP_S","CF","CF_S",
                                               "B01","B01_S","B02","B02_S","B03","B03_S","B04","B04_S","B05","B05_S",
                                               "B06","B06_S","B07","B07_S","B08","B08_S","B09","B09_S","B10","B10_S" };


        private System.Threading.Timer timer_report_edc;
        private bool _run = false;


        #region DI 

        public string provider
        {
            get { return _provider; }
            set { _provider = value; }
        }

        public string connectstring
        {
            get { return _connectstring; }
            set { _connectstring = value; }
        }

        public string edcpath
        {
            get { return _edcpath; }
            set { _edcpath = value; }
        }

        public int reportinterval
        {
            get { return _reportinterval; }
            set { _reportinterval = value; }
        }

        #endregion

        public override bool Init()
        {
            bool ret = false;
            try
            {
                //-------- Load DB Setting --------
                using (IOT_DbContext db = new IOT_DbContext(provider, connectstring))
                {
                    var vIOT_EDC_Gls_Info_Result = db.IOT_EDC_GLS_INFO.AsQueryable().ToList();
                    foreach (IOT_EDC_GLS_INFO _IOT_EDC_Gls_Info_key in vIOT_EDC_Gls_Info_Result)
                    {
                        _IOT_EDC_GlassInfo.AddOrUpdate(_IOT_EDC_Gls_Info_key.sub_eqp_id, _IOT_EDC_Gls_Info_key, (key, oldvalue) => _IOT_EDC_Gls_Info_key);
                    }

                    var vIOT_Device_Result = db.IOT_Device.AsQueryable().ToList();
                    foreach (IOT_Device _IOT_Device_key in vIOT_Device_Result)
                    {
                        _IOT_Device.AddOrUpdate(_IOT_Device_key.device_id, _IOT_Device_key, (key, oldvalue) => _IOT_Device_key);
                    }

                    var vEDC_Label_Result = db.IOT_Device_EDC_LABEL.AsQueryable().ToList();
                    foreach (IOT_Device_EDC_LABEL _EDC_Label_key in vEDC_Label_Result)
                    {
                        ConcurrentDictionary<string, Tuple<double, double>> _Sub_EDC_Spec = _EDC_Item_Spec.GetOrAdd(_EDC_Label_key.device_id, new ConcurrentDictionary<string, Tuple<double, double>>());
                        _Sub_EDC_Spec.AddOrUpdate(_EDC_Label_key.data_name, Tuple.Create(_EDC_Label_key.lspec, _EDC_Label_key.uspec), (key, oldvalue) => Tuple.Create(_EDC_Label_key.lspec, _EDC_Label_key.uspec));
                        _EDC_Item_Spec.AddOrUpdate(_EDC_Label_key.device_id, _Sub_EDC_Spec, (key, oldvalue) => _Sub_EDC_Spec);

                    }


                }

                _run = true;
                Timer_Report_EDC(_reportinterval);

                NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Initial Finished");
               ret = true;
            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
                Destory();
                ret = false;
            }
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "MQTT_Service_Initial Finished");
            return ret;
        }

        public void Destory()
        {
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Begin");
            try
            {
                if (_run)
                {
                    _run = false;
                }
            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
            }
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "End");
        }


        private void Timer_Report_EDC(int interval)
        {
            if (interval == 0)
                interval = 10000;  // 10s

            //使用匿名方法，建立帶有參數的委派
            System.Threading.Thread Thread_Timer_Report_EDC = new System.Threading.Thread
            (
               delegate (object value)
               {
                   int Interval = Convert.ToInt32(value);
                   timer_report_edc = new System.Threading.Timer(new System.Threading.TimerCallback(EDC_TimerTask), null, 1000, Interval);
               }
            );
            Thread_Timer_Report_EDC.Start(interval);
        }

        private void EDC_TimerTask(object timerState)
        {
            try
            {
                Parallel.ForEach(_IOT_EDC, kvp =>
                {
                    if (kvp.Value.RPM.Count() != 0)
                    {
                        string result = string.Empty;
                        string EDC_File_Name = string.Empty;
                        result = kvp.Value.Export(kvp.Key, out EDC_File_Name);

                        if (result != string.Empty && EDC_File_Name != string.Empty)
                        {
                           
                            string FilePath = Path.Combine(_edcpath, EDC_File_Name);
                            _Write_EDC_File.Enqueue(Tuple.Create(FilePath, result));
                        }
                        else
                        {
                            NLogManager.Logger.LogWarn("Service", GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", string.Format("Encode EDC File Faild Device : {0}.", kvp.Key));
                           
                        }

                    }

                });

                ReportEDC();
            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError("Service", GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", string.Format("Encode EDC File Error Exception Msg :{0}.", ex.Message));
            }
        }

        public void Test(xmlMessage InputData)
        {
            string topic = InputData.MQTTTopic;
            string message = InputData.Data;
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", string.Format("Receive_MQTT Message Topic : {0}.", topic));
            Handle_IOT_DEVICE_EDC_ThreadPool(message);
        }

        private void SendMQTTData(xmlMessage msg)
        {
            PutMessage(msg);
        }

        private void Handle_IOT_DEVICE_EDC_ThreadPool(string message)
        {
            try
            {
                cls_EDC_Function Function = new cls_EDC_Function();
                ThreadPool.QueueUserWorkItem(o => Function.ThreadPool_Proc(message));
            }

            catch (Exception ex)
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
            }
        }

        public void ReportEDC()
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



    }
}
