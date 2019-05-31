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

using IEW.ObjectManager;

namespace IEW.IOTEDCService
{
    public class IOTEDCService : AbstractService
    {
        private System.Threading.Timer timer_routine;
        internal static ConcurrentQueue<Tuple<string, string>> _Write_EDC_File = new ConcurrentQueue<Tuple<string, string>>();
        private int routine_interval = 1;
        private bool _run = false;

        public override bool Init()
        {
            bool ret = false;
            try
            {
                _run = true;
                Timer_Routine_Job(routine_interval);
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

        private void Timer_Routine_Job(int interval)
        {
            if (interval == 0)
                interval = 10000;  // 10s

            //使用匿名方法，建立帶有參數的委派
            System.Threading.Thread Thread_Timer_Routine_Job = new System.Threading.Thread
            (
               delegate (object value)
               {
                   int Interval = Convert.ToInt32(value);
                   timer_routine = new System.Threading.Timer(new System.Threading.TimerCallback(EDC_TimerTask), null, 1000, Interval);
               }
            );
            Thread_Timer_Routine_Job.Start(interval);
        }

        private void EDC_TimerTask(object timerState)
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
            //反序列畫 Obj 建構子，建構物件
            // 使用try catch

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
                            IOTEDCService._Write_EDC_File.Enqueue(Tuple.Create(objEDC.ReportEDCPath, EDC_string));
                        }

                        break;

                    case "interval":
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
