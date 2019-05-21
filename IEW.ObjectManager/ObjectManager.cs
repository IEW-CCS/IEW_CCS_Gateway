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

        public void GatewayManager_Initial()
        {
            this.GatewayManager = new GateWayManager();
        }

        public void GatewayManager_Initial(string Json)
        {
            this.GatewayManager = JsonConvert.DeserializeObject<GateWayManager>(Json);
        }

        public void Insert_Update_TagValue (cls_ProcRecv_CollectData ProcRecv_CollectData)
        {
            string _GateWayID = ProcRecv_CollectData.GateWayID;

            if (ProcRecv_CollectData.Decode_Result == true)
            {
                cls_Gateway_Info Gateway = GatewayManager.gateway_list.Where(p => p.gateway_id == _GateWayID).FirstOrDefault();
                if (Gateway != null)
                {
                    foreach (cls_Collect_Reply_Tag p in ProcRecv_CollectData.Prod_EDC_Data)
                    {
                        /*
                        if (Gateway.tag_info.ContainsKey(p.TAG_NAME))
                        {
                            cls_Tag tag = Gateway.tag_info[p.TAG_NAME];
                            tag.Value.Add( p.TAG_VALUE);
                            Gateway.tag_info.AddOrUpdate(p.TAG_NAME, tag, (key, oldvalue) => tag);
                        }
                        */
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

        public string GatewayCommand_Json(string _Cmd_Type, string _Report_Interval, string _Trace_ID, string _GateWayID)
        {
            cls_Gateway_Info Gateway = GatewayManager.gateway_list.Where(p => p.gateway_id == _GateWayID).FirstOrDefault();
            if (Gateway == null)
                return null;

            cls_Collect collect_cmd = new cls_Collect(_Cmd_Type, _Report_Interval, _Trace_ID, Gateway);
            return JsonConvert.SerializeObject(collect_cmd, Formatting.Indented);
          
        }
    }
}
