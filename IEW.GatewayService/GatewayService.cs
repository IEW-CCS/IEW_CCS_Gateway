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
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // IEW/GateWay/Device/ReplyData
            string GateWayID = Topic[1].ToString();
            string DeviceID = Topic[2].ToString() ;

            cls_Gateway_Info Gateway = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
            if (Gateway != null)
            {
                cls_Device_Info Device = Gateway.device_info.Where(p => p.device_name == DeviceID).FirstOrDefault();
                if (Device != null)
                {
                    try
                    {
                        ProcCollectData Function = new ProcCollectData(Device,GateWayID, DeviceID);
                        ThreadPool.QueueUserWorkItem(o => Function.ThreadPool_Proc(InputData.MQTTPayload.ToString()));
                    }
                    catch (Exception ex)
                    {
                        NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
                    }
                }
            }
        }
    }


    public class ProcCollectData
    {
        private string _GatewayID = string.Empty;
        private string _DeviceID = string.Empty;
        private cls_Device_Info _Device = null;
        private const string _LogName = "Service";
        public ProcCollectData(cls_Device_Info Device, string GatewayID, string DeviceID)
        {
            _GatewayID = GatewayID;
            _DeviceID = DeviceID;
            _Device = Device;
                
        }
        public void ThreadPool_Proc(string msg)
        {
            try
            {
                cls_Collect_Reply CollectData = null;
                CollectData = JsonConvert.DeserializeObject<cls_Collect_Reply>(msg.ToString());

                cls_ProcRecv_CollectData ProcRecv_CollectData = new cls_ProcRecv_CollectData();
                ProcRecv_CollectData.GateWayID = _GatewayID;
                ProcRecv_CollectData.Device_ID = _DeviceID;
              
                if (CollectData != null)
                {
                    // 直接平行處理對應所有Tag
                    Parallel.ForEach(CollectData.EDC_Data, p =>
                    {
                        cls_Tag Device_Tag = _Device.tag_info[p.TAG_NAME];
                        string Tag_Value = p.TAG_VALUE;
                        int BitPoints = 0;
                        double tmp_output = 0;
                        string Output = string.Empty;

                        if (Device_Tag.Type == "PLC")
                        {
                            switch (Device_Tag.Expression)
                            {
                                case "Bit":
                                    BitPoints = CalculateBit(Device_Tag.UUID_Address);
                                    if (BitPoints != 0)
                                        Output = HexToBit(0, BitPoints, Tag_Value);
                                    else
                                        Output = string.Empty;

                                    break;
                                case "Int":
                                    BitPoints = CalculateBit(Device_Tag.UUID_Address);
                                    if (BitPoints != 0)
                                    {
                                        tmp_output = HexToInt(BitPoints, Tag_Value);
                                        tmp_output = (Device_Tag.scale * tmp_output) + Device_Tag.offset;
                                        Output = tmp_output.ToString();
                                    }
                                    else
                                    {
                                        Output = string.Empty;
                                    }
                                    break;
                                case "Long":
                                    // 考慮bit offset 寫死固定
                                    BitPoints = CalculateBit(Device_Tag.UUID_Address);
                                    if (BitPoints != 0)
                                    {
                                        tmp_output = HexToLong(BitPoints, Tag_Value);
                                        tmp_output = (Device_Tag.scale * tmp_output) + Device_Tag.offset;
                                        Output = tmp_output.ToString();
                                    }
                                    else
                                    {
                                        Output = string.Empty;
                                    }
                                    break;
                                case "SInt":
                                    BitPoints = CalculateBit(Device_Tag.UUID_Address);
                                    if (BitPoints != 0)
                                    {
                                        tmp_output = HexToSInt(BitPoints, Tag_Value);
                                        tmp_output = (Device_Tag.scale * tmp_output) + Device_Tag.offset;
                                        Output = tmp_output.ToString();
                                    }
                                    else
                                    {
                                        Output = string.Empty;
                                    }
                                    
                                    break;
                                case "SLong":
                                    BitPoints = CalculateBit(Device_Tag.UUID_Address);
                                    if (BitPoints != 0)
                                    {
                                        tmp_output = HexToSLong(BitPoints, Tag_Value);
                                        tmp_output = (Device_Tag.scale * tmp_output) + Device_Tag.offset;
                                        Output = tmp_output.ToString();
                                    }
                                    else
                                    {
                                        Output = string.Empty;
                                    }
                                    break;
                                case "ASC":
                                    Output = HexToASCII(Tag_Value);
                                    break;
                                default:
                                    Output = string.Empty;
                                    break;
                            }
                        }

                        if (Output != string.Empty)
                        {
                            ProcRecv_CollectData.Prod_EDC_Data.Enqueue(Tuple.Create(p.TAG_NAME, Output));
                        }

                    });
                }
                GatewayService._Update_TagValue_Queue.Enqueue(ProcRecv_CollectData);
            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError(_LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
            }
        }

        //decode method

        public byte[] HexToByte(string hexString)
        {
            //運算後的位元組長度:16進位數字字串長/2
            byte[] byteOUT = new byte[hexString.Length / 2];
            for (int i = 0; i < hexString.Length; i = i + 2)
            {
                //每2位16進位數字轉換為一個10進位整數
                byteOUT[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }
            return byteOUT;
        }

        public ushort HexToInt( int itemBPoints, string iodata)
        {
            int itemBOffset = 0;
            ushort result = 0;
            byte[] buffer = new byte[8];  // Max long 4 word
            int bufOffset = 0;
            byte[] ary_bytiodata = HexToByte(iodata);
            int iodataOffset = 0;

            Buffer.BlockCopy(ary_bytiodata, iodataOffset, buffer, bufOffset, ary_bytiodata.Length);

            ulong[] value = new ulong[1];
            Buffer.BlockCopy(buffer, 0, value, 0, 8);
            result = (ushort)(value[0] >> (itemBOffset & 63) & (ulong)(Math.Pow(2, (double)itemBPoints) - 1));
            return result;
        }

        public uint HexToLong( int itemBPoints, string iodata)
        {
            int itemBOffset = 0;
            uint result = 0;
            byte[] buffer = new byte[8];  // Max long 4 word
            int bufOffset = 0;
            byte[] ary_bytiodata = HexToByte(iodata);
            int iodataOffset = 0;

            Buffer.BlockCopy(ary_bytiodata, iodataOffset, buffer, bufOffset, ary_bytiodata.Length);

            ulong[] value = new ulong[1];
            Buffer.BlockCopy(buffer, 0, value, 0, 8);
            result = (uint)(value[0] >> (itemBOffset & 63) & (ulong)(Math.Pow(2, (double)itemBPoints) - 1));
            return result;
        }

        public short HexToSInt( int itemBPoints, string iodata)
        {
            int itemBOffset = 0;
            short result = 0;
            byte[] buffer = new byte[8];  // Max long 4 word
            int bufOffset = 0;
            byte[] ary_bytiodata = HexToByte(iodata);
            int iodataOffset = 0;

            Buffer.BlockCopy(ary_bytiodata, iodataOffset, buffer, bufOffset, ary_bytiodata.Length);

            ulong[] value = new ulong[1];
            Buffer.BlockCopy(buffer, 0, value, 0, 8);
            result = (short)(value[0] >> (itemBOffset & 63) & (ulong)(Math.Pow(2, (double)itemBPoints) - 1));
            return result;
        }

        public int HexToSLong( int itemBPoints, string iodata)
        {
            int itemBOffset = 0;
            int result = 0;
            byte[] buffer = new byte[8];  // Max long 4 word
            int bufOffset = 0;
            byte[] ary_bytiodata = HexToByte(iodata);
            int iodataOffset = 0;

            Buffer.BlockCopy(ary_bytiodata, iodataOffset, buffer, bufOffset, ary_bytiodata.Length);

            ulong[] value = new ulong[1];
            Buffer.BlockCopy(buffer, 0, value, 0, 8);
            result = (int)(value[0] >> (itemBOffset & 63) & (ulong)(Math.Pow(2, (double)itemBPoints) - 1));
            return result;
        }

        public string HexToASCII(string iodata)
        {
            StringBuilder sb = new StringBuilder();
            byte[] ary_bytiodata = HexToByte(iodata);
            int bitoffset = 0;
            for (int i = 0; i < ary_bytiodata.Length; i++)
            {
                sb.Append((char)(ary_bytiodata[i] >> ((bitoffset * 8) & 31) & 255));
            }
            return sb.ToString().Replace('\0', ' ');
        }

        public string HexToBit(int itemBOffset, int itemBPoints, string iodata)
        {
            StringBuilder sb = new StringBuilder();

            byte[] ary_bytiodata = HexToByte(iodata);
            int wstart = (itemBOffset) / 16;
            int bstart = (itemBOffset) % 16;

            for (int p = 0; p < itemBPoints; p++)
            {
                if (bstart > 15)
                {
                    bstart = 0;
                    wstart++;
                }
                int mask = 1 << (bstart & 31);
                sb.Append((iodata[wstart] & mask) / mask);
                bstart++;
            }
            return sb.ToString();
        }

        public int CalculateBit(string UUID_Address)
        {
            //-------運算使用 ------
            char[] delimiterChars = { '.', ':' };
            int first_colon_index = -1;
            int first_dot_index = -1;

            string[] Split_Words = UUID_Address.Split(delimiterChars);
          
            //---- Address 用法  W1000:3000
            //---- W1000.0:a     這種Case固定填一
            first_colon_index = UUID_Address.IndexOf(":");
            first_dot_index = UUID_Address.IndexOf(".");

            if ((first_colon_index > -1) && first_dot_index == -1)   // W1000:3000
            {
                int start = int.Parse(Split_Words[0].Replace("W", "").Replace("w", ""));
                int end = int.Parse(Split_Words[1].Replace("W", "").Replace("w", ""));
                int diff = end - start;
                if (diff < 0) diff = 1;
                return diff * 16;
            }
            else if ((first_colon_index == -1) && first_dot_index == -1)  // W1000
            {
                return 16;
            }

            else if( first_dot_index < first_colon_index)   //W1000.3:5   
            {
                string[] tempSplit_Words = UUID_Address.Substring(first_dot_index).Split(delimiterChars);
                int start = int.Parse(tempSplit_Words[0]);
                int end = int.Parse(tempSplit_Words[1]);
                int diff = end - start;
                return diff ;
            }
            else
            {
                // 表示不合法的表示式 W1000:1001.3:5
                // 組合UUID_Address 的時候需要確認正確的模式進行
                return 0; 
            }


        }

    }

}
