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

namespace IEW.IOTEDCService
{
    public class IOTEDCService : AbstractService
    {
       
        internal static ConcurrentQueue<Tuple<string, string>> _Write_EDC_File = new ConcurrentQueue<Tuple<string, string>>();
        private bool _run = false;

        private Thread th_ReportEDC = null;

        public override bool Init()
        {
            bool ret = false;
            try
            {
                _run = true;
                this.th_ReportEDC = new Thread(new ThreadStart(EDC_Writter));
                this.th_ReportEDC.Start();
                NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Initial Finished");
                ret = true;
            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
                Destroy();
                ret = false;
            }
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "MQTT_Service_Initial Finished");
            return ret;
        }

        public void Destroy()
        {
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Begin");
          
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

            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
            }
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "End");
        }

        private void EDC_Writter()
        {
            while(_run)
            {
                if (_Write_EDC_File.Count > 0)
                {
                    Tuple<string, string> _msg = null;
                    while (_Write_EDC_File.TryDequeue(out _msg))
                    {

                        string Timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                        string save_file_path = _msg.Item1.Replace("{Datetime}", Timestamp);


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
                            NLogManager.Logger.LogInfo("Service", "EDC_Writter", MethodInfo.GetCurrentMethod().Name + "()", string.Format("Save EDC File Successful Path: {0}.", save_file_path));

                        }
                        catch (Exception ex)
                        {
                            NLogManager.Logger.LogError("Service", "EDC_Writter", MethodInfo.GetCurrentMethod().Name + "()", string.Format("Write EDC File Faild Exception Msg : {0}. ", ex.Message));
                        }
                    }
                }

            }
        }

        public void ReceiveMQTTData(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string Topic = InputData.MQTTTopic;
            string Payload = InputData.MQTTPayload;

            ProcEDCData EDCProc = new ProcEDCData(Payload);
            if (EDCProc != null)
            {
                ThreadPool.QueueUserWorkItem(o => EDCProc.ThreadPool_Proc());
            }


        }

    }
    public class ProcEDCData
    {
        EDCPartaker objEDC = null;
        public ProcEDCData(string inputdata)
        {
            try
            {
                this.objEDC =  JsonConvert.DeserializeObject<EDCPartaker>(inputdata.ToString());
            }
            catch(Exception ex)
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
                    // Trigger 代表一來直接寫檔案.
                    case "trigger":

                        string EDC_string = string.Empty;
                        EDC_string = objEDC.xml_string();

                        if (EDC_string != string.Empty)
                        {

                            string SavePath = objEDC.ReportEDCPath;
                            IOTEDCService._Write_EDC_File.Enqueue(Tuple.Create(SavePath, EDC_string));
                        }

                        break;

                    case "interval":

                        // keep interval report 需要討論要上報什麼內容 (MAX, Min, AVG or others...)
                        break;

                    default:
                        break;

                }
            }
            catch (Exception ex)
            {
                    
            }
        }

    }
    }
