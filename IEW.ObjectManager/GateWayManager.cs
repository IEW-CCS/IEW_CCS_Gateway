using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Concurrent;

namespace IEW.ObjectManager
{
    #region Gateway Class Define

    public class cls_Device_Info
    {
        public string device_name { get; set; }
        public string device_type { get; set; }
        public string plc_ip_address { get; set; }
        public string plc_port_id { get; set; }
        public string ble_mac { get; set; }
        public List<string> ble_service_uuid = new List<string>();
        public ConcurrentDictionary<string, cls_Tag> tag_info = new ConcurrentDictionary<string, cls_Tag>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class cls_Gateway_Info
    {
        public string gateway_id { get; set; }
        public string gateway_ip { get; set; }
        public List<cls_Device_Info> device_info = new List<cls_Device_Info>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public class GateWayManager
    {
        public List<cls_Gateway_Info> gateway_list = new List<cls_Gateway_Info>();

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    #endregion

    #region Tag Class Define

    public class cls_Tag
    {
        public string TagName { get; set; }
        public string Type { get; set; }
        public string UUID_Address { get; set; }  // For PLC type Using W1000:W1003  or W1000.1:a   16 bit 代表 0 1 2 3 4 5 6 7 8 9 a b c d e 
        public string Expression { get; set; }
        public List<string> Value = new List<string>();
        public double scale { get; set; }
        public double offset { get; set; }
        public string LastUpdateTime { get; set; }
        public string Description { get; set; }
    }

    #endregion

    #region Collect Cmd Json
    public class cls_Collect_Tag
    {
        public string DATA_NAME { get; set; }
        public string DATA_ADDR { get; set; }
        public string DATA_TYPE { get; set; }
        public string DATA_LENGTH { get; set; }
    }

    public class cls_Collect
    {
        public string Cmd_Type { get; set; }
        public string Report_Interval { get; set; }
        public string Trace_ID { get; set; }
        public List<cls_Collect_Tag> Address_Info = new List<cls_Collect_Tag>();

        public cls_Collect()
        {

        }

        public cls_Collect (string _Cmd_Type, string _Report_Interval, string _Trace_ID, cls_Device_Info _DeviceInfo)
        {
            Cmd_Type = _Cmd_Type;
            Report_Interval = _Report_Interval;
            Trace_ID = _Trace_ID;

            //-------運算使用 ------
            char[] delimiterChars = {'.', ':'};
            int first_colon_index = -1;
            int first_dot_index = -1;

            foreach (KeyValuePair<string, cls_Tag> kvp in _DeviceInfo.tag_info)
            {
                cls_Collect_Tag temp = new cls_Collect_Tag();
                temp.DATA_NAME = kvp.Value.TagName;
                temp.DATA_TYPE = kvp.Value.Expression;
                string[] Split_Words = kvp.Value.UUID_Address.Split(delimiterChars);
                temp.DATA_ADDR = Split_Words[0]; // 這裡填入需要拆碼後的資料 W1000: 1003   只填入W1000 進去

                //---- Address 用法  W1000:3000
                //---- W1000.0:a     這種Case固定填一
                first_colon_index = kvp.Value.UUID_Address.IndexOf(":");
                first_dot_index = kvp.Value.UUID_Address.IndexOf(".");

                if ((first_colon_index > -1) && first_dot_index == -1)   // W1000:3000
                {
                    int start = int.Parse(Split_Words[0].Replace("W", "").Replace("w", ""));
                    int end = int.Parse(Split_Words[1].Replace("W", "").Replace("w", ""));
                    int diff = end - start;

                    if (diff > 0)
                        temp.DATA_LENGTH = diff.ToString();
                    else
                        temp.DATA_LENGTH = "1";
                }
                else
                {
                    temp.DATA_LENGTH = "1";
                }

                Address_Info.Add(temp);
            }

        }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    #endregion

    #region Collect Reply  Json
    public class cls_Collect_Reply_Tag
    {
        public string TAG_NAME { get; set; }
        public string TAG_VALUE { get; set; }
    }

    public class cls_Collect_Reply
    {
        public string Device_ID { get; set; }
        public string IP_Address { get; set; }
        public string Time_Stamp { get; set; }
        public List<cls_Collect_Reply_Tag> EDC_Data = new List<cls_Collect_Reply_Tag>();
    }

    public class cls_ProcRecv_CollectData
    {
        public string GateWayID { get; set; }
        public string Device_ID { get; set; }
        public ConcurrentQueue<Tuple<string, string>> Prod_EDC_Data = new ConcurrentQueue<Tuple<string, string>>();
    }

    #endregion


}