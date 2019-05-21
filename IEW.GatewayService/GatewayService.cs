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
using IEW.ObjectManager;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



using System.Xml;

namespace IEW.GatewayService
{
    public class GatewayService : AbstractService
    {
        //-----  依賴注射直接綁進去 取數值方便 ------
        //-----  如果需要在其他地方取得這個數值 copy 下面兩個function & object factory setting 設定 -----
        private IEW.ObjectManager.ObjectManager _ObjectManager;
        public IEW.ObjectManager.ObjectManager ObjectManager
        {
            get
            {
                return this._ObjectManager;
            }
            set
            {
                this._ObjectManager = value;
            }
        }

        //----暫時存放到Queue中在慢慢Update到ObjectManager去
        internal static ConcurrentQueue<cls_ProcRecv_CollectData> _Update_TagValue_Queue = new ConcurrentQueue<cls_ProcRecv_CollectData>();

        public override bool Init()
        {
            bool ret = false;
            try
            {
               // 以下建構子 讀取 gateway json string from file 
               // ObjectManager.GatewayManager_Initial(InputData.MQTTPayload.ToString());
                NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Gateway_Initial Finished");
                ret = true;
            }
            catch
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Gateway_Initial Failed");
                ret = false;
            }
            return ret;
        }

        public void Destory()
        {
            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Gateway_Destory");
        }

        //-------- send out MQTT Data -------
        private void SendMQTTData(xmlMessage msg)
        {
            PutMessage(msg);
        }


        // From GUI Trigger Msg 
        public void GateWay_Collect_Cmd_Download(string msg)
        {
          //  xmlMessage SendOutMsg = new xmlMessage();
          //  SendOutMsg.LineID = "ABCD";
          //  SendOutMsg.DeviceID = "BLE";
          //  SendOutMsg.MQTTTopic = "Collect_Cmd";
          //  SendOutMsg.MQTTPayload = msg;
          //  SendMQTTData(SendOutMsg);

        }

        // ----- Sample to insert gateway
        public void UpdateGatewayInfo()
        {
           // 直接在裡面純取  ObjectManager 物件
        }


        public void ReceiveMQTTData(xmlMessage InputData)
        {
            MessageBox.Show(InputData.MQTTPayload.ToString());

            //From Topic get device ID   以後再補
            string GateWayID = "1234";
            cls_Gateway_Info Gateway = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
            
            try
            {
                ProcCollectData Function = new ProcCollectData(Gateway);
                ThreadPool.QueueUserWorkItem(o => Function.ThreadPool_Proc(InputData.MQTTPayload.ToString()));
            }

            catch (Exception ex)
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
            }
            
        }

    }


    public class ProcCollectData
    {
        public cls_Gateway_Info _Gateway;
        private const string _LogName = "Service";
        public ProcCollectData(cls_Gateway_Info Gateway)
        {
            _Gateway = Gateway;
        }
        public void ThreadPool_Proc(string msg)
        {
            try
            {
                cls_ProcRecv_CollectData CollectData = null;
                CollectData = JsonConvert.DeserializeObject<cls_ProcRecv_CollectData>(msg.ToString());
                cls_ProcRecv_CollectData ProcRecv_CollectData = new cls_ProcRecv_CollectData();

                //....在裡面補解析的功能部份 .....

                GatewayService._Update_TagValue_Queue.Enqueue(ProcRecv_CollectData);

            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError(_LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
            }
        }
    }

}
