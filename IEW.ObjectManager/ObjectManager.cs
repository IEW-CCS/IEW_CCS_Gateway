using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace IEW.ObjectManager
{
    public class ObjectManager
    {
        public GateWayManager GatewayManager = null;
        public TagSetManager TagSetManager = null;

        public void GatewayManager_Initial()
        {
            this.GatewayManager = new GateWayManager();
        }

        public void GatewayManager_Initial(string Json)
        {
            this.GatewayManager = JsonConvert.DeserializeObject<GateWayManager>(Json);
        }

        public void TagSetManager_Initial()
        {
            this.TagSetManager = new TagSetManager();
        }

        public void TagSetManager_Initial(string Json)
        {
            this.TagSetManager = JsonConvert.DeserializeObject<TagSetManager>(Json);
        }

        public void Insert_Update_TagValue (cls_ProcRecv_CollectData ProcRecv_CollectData)
        {
            string _GateWayID = ProcRecv_CollectData.GateWayID;
            string _DeviceID = ProcRecv_CollectData.Device_ID;

            if (ProcRecv_CollectData.Decode_Result == true)
            {
                cls_Gateway_Info Gateway = GatewayManager.gateway_list.Where(p => p.gateway_id == _GateWayID).FirstOrDefault();
                if (Gateway != null)
                {
                    cls_Device_Info Device = Gateway.device_info.Where(p => p.device_name == _DeviceID).FirstOrDefault();
                    if (Device != null)
                    {
                        foreach (cls_Collect_Reply_Tag p in ProcRecv_CollectData.Prod_EDC_Data)
                        {
                            if (Device.tag_info.ContainsKey(p.TAG_NAME))
                            {
                                cls_Tag tag = Device.tag_info[p.TAG_NAME];
                                tag.Value.Add( p.TAG_VALUE);
                                Device.tag_info.AddOrUpdate(p.TAG_NAME, tag, (key, oldvalue) => tag);
                            }
                        }
                    }
                }
            }

        }

        public string GatewayManager_ToJson_String()
        {
 
            try
            {
                return JsonConvert.SerializeObject(GatewayManager, Formatting.Indented);
            }
            catch
            {
                return null;
            }
        }

        public string GatewayCommand_Json(string _Cmd_Type, string _Report_Interval, string _Trace_ID, string _GateWayID, string _DeviceID)
        {
            cls_Gateway_Info Gateway = GatewayManager.gateway_list.Where(p => p.gateway_id == _GateWayID).FirstOrDefault();
            if (Gateway == null)
            {
                return null;
            }
            else
            {
                cls_Device_Info Device = Gateway.device_info.Where(p => p.device_name == _DeviceID).FirstOrDefault();
                if( Device == null)
                {
                    return null;
                }
                else
                {
                    
                    cls_Collect collect_cmd = new cls_Collect(_Cmd_Type, _Report_Interval, _Trace_ID, Device);
                    return JsonConvert.SerializeObject(collect_cmd, Formatting.Indented);
                }
            }
        }
    }
}
