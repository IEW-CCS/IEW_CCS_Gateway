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

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using IEW.ObjectManager;
using System.Xml.Linq;

namespace IEW.IOTEDCService
{
    public class IOTEDCService : AbstractService
    {
        private string _SeviceName = "EDCService";
        public string ServiceName
        {
            get
            {
                return this._SeviceName;
            }
        }

        private const string _GatewayID = "GatewayID";
        private const string _DeviceID = "DeviceID";

        public delegate void Put_Write_Event(string Path, string Body);
        public delegate void Handle_Interval_Event(EDCPartaker input);

        private ConcurrentQueue<Tuple<string, string>> _Write_EDC_File = new ConcurrentQueue<Tuple<string, string>>();
        private ConcurrentDictionary<string, EDC_Interval_Partaker> _dic_Interval_EDC = new ConcurrentDictionary<string, EDC_Interval_Partaker>();

        private System.Threading.Timer timer_routine_job;

        private bool _run = false;
        private Thread th_ReportEDC = null;
        private Thread th_Routine_Job = null;

        // -- read config .ini
        private Dictionary<string, string> _dic_Basicsetting = new Dictionary<string, string>();

        public override bool Init()
        {
            try
            {
                _run = true;

                string Config_Path = System.Environment.CurrentDirectory + "/settings/System.xml";
                Load_Xml_Config_To_Dict(Config_Path);

                this.th_ReportEDC = new Thread(new ThreadStart(EDC_Writter));
                this.th_ReportEDC.Start();

                this.th_Routine_Job = new Thread(new ThreadStart(Routine_Job));
                this.th_Routine_Job.Start();

                NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "EDC Service Initial Finished");
            }
            catch (Exception ex)
            { 
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
                Destroy();
                _run = false;
            }
            return _run;

        }

        public void Destroy()
        {
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "EDC Service Destroy Begin");
          
            try
            {
                if (_run)
                {
                    _run = false;
                }

                if (this.th_ReportEDC != null && this.th_ReportEDC.IsAlive)
                {
                    this.th_ReportEDC.Abort();
                    this.th_ReportEDC.Join();
                   
                }

                if (this.th_Routine_Job != null && this.th_Routine_Job.IsAlive)
                {
                    this.th_Routine_Job.Abort();
                    this.th_Routine_Job.Join();

                }

            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
            }
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "EDC Service Destroy End");
        }

        //----- MQTT Receive  -----
        public void ReceiveMQTTData(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string Topic = InputData.MQTTTopic;
            string Payload = InputData.MQTTPayload;

            NLogManager.Logger.LogDebug(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", string.Format("EDC Service Handle ReceiveMQTTData Data: {0}. ", Payload));

            try
            {
                ProcEDCData EDCProc = new ProcEDCData(Payload, EDC_File_Enqueue, Handle_Interval_EDC);
                if (EDCProc != null)
                {
                    ThreadPool.QueueUserWorkItem(o => EDCProc.ThreadPool_Proc());
                }
            }
            catch (Exception ex)
            {
                string ErrorLog = string.Format("EDC Service Handle ReceiveMQTTData Exception Msg : {0}. ", ex.Message);
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ErrorLog);
            }
        }

        public void Handle_Interval_EDC(EDCPartaker input)
        {
            string serial_id = input.serial_id;
            List<cls_EDC_Body_Item> temp_EDC_Body = new List<cls_EDC_Body_Item>(input.edcitem_info.ToArray());
            EDC_Interval_Partaker EDCInterval = _dic_Interval_EDC.GetOrAdd(serial_id, new EDC_Interval_Partaker(input));
            EDCInterval.Add_EDC2Queue(temp_EDC_Body);
            _dic_Interval_EDC.AddOrUpdate(serial_id, EDCInterval, (key, oldvalue) => EDCInterval);
        }

        public void EDC_File_Enqueue(string SavePath, string EDC_string)
        {
            _Write_EDC_File.Enqueue(Tuple.Create(SavePath, EDC_string));
        }

        private void Routine_Job()
        {
            while (_run)
            {
                Check_Interval_Report_EDC();
                Thread.Sleep(1000);
            }
        }

        private void Check_Interval_Report_EDC()
        {
            if (_dic_Interval_EDC.Count == 0)
                return;
            else
            {
                DateTime current_time = DateTime.Now;
                foreach (KeyValuePair<string, EDC_Interval_Partaker> kvp in _dic_Interval_EDC)
                {
                    if (kvp.Value.Checkexpired(current_time) == false)
                    {
                        continue;
                    }
                    else
                    {
                        EDC_Interval_Partaker proc = null;
                        _dic_Interval_EDC.TryRemove(kvp.Key, out proc);

                        string EDC_string = proc.Generate_EDC();

                        if (EDC_string != string.Empty)
                        {
                            string SavePath = proc.GetEDCPath();
                            EDC_File_Enqueue(SavePath, EDC_string);

                        }
                    }
                }
            }
        }

        private void EDC_Writter()
        {
            while (_run)
            {
                if (_Write_EDC_File.Count > 0)
                {
                    Tuple<string, string> _msg = null;
                    while (_Write_EDC_File.TryDequeue(out _msg))
                    {

                        string Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string save_file_path = _msg.Item1.Replace("{datetime}", Timestamp);
                        string EDC_Data = _msg.Item2;

                        try
                        {
                            if (!Directory.Exists(Path.GetDirectoryName(save_file_path)))
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(save_file_path));
                                NLogManager.Logger.LogWarn(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", string.Format("Save EDC Path {0}  Directory Not Exist, Create Directory.", save_file_path));
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
                            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", string.Format("Save EDC File Successful Path: {0}.", save_file_path));

                        }
                        catch (Exception ex)
                        {
                            string ErrorLog = string.Format("Write EDC File Faild Exception Msg : {0}. ", ex.Message);
                            NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ErrorLog);
                        }
                    }
                }

                Thread.Sleep(10);
            }
        }

        private void Load_Xml_Config_To_Dict(string config_path)
        {
            XElement SettingFromFile = XElement.Load(config_path);
            XElement System_Setting = SettingFromFile.Element("system");

            _dic_Basicsetting.Clear();

            if (System_Setting != null)
            {
                foreach (var el in System_Setting.Elements())
                {
                    _dic_Basicsetting.Add(el.Name.LocalName, el.Value);
                }
            }
        }

    }
    public class ProcEDCData
    {
        EDCPartaker objEDC = null;
        public IOTEDCService.Put_Write_Event _Put_Write;
        public IOTEDCService.Handle_Interval_Event _Interval_Event;
        public ProcEDCData(string inputdata, IOTEDCService.Put_Write_Event _delegate_Method, IOTEDCService.Handle_Interval_Event _delegate_Interval_Event)
        {
            try
            {
                this.objEDC = JsonConvert.DeserializeObject<EDCPartaker>(inputdata.ToString());
                _Put_Write = _delegate_Method;
                _Interval_Event = _delegate_Interval_Event;
            }
            catch
            {
                this.objEDC = null;
            }

        }
        public void ThreadPool_Proc()
        {
            try
            {
                switch (objEDC.report_tpye)
                {
                    case "trigger":

                        string EDC_string = string.Empty;
                        EDC_string = objEDC.xml_string();
                        if (EDC_string != string.Empty)
                        {
                            string SavePath = objEDC.ReportEDCPath;
                            _Put_Write(SavePath, EDC_string);
                        }
                        break;

                    case "interval":
                        _Interval_Event(objEDC);
                        break;

                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Handle Process EDC Data Error Message Error [{0}].", ex.Message));
            }
        }
    }
}
