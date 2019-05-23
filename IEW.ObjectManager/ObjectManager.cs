using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using IEW.Platform.Kernel.Log;


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
                            tag.Value.Add(_tag.Item2);
                            Device.tag_info.AddOrUpdate(_tag.Item1, tag, (key, oldvalue) => tag);
                        }
                    }
                }
                else
                {
                    NLogManager.Logger.LogError("Service", GetType().Name, MethodInfo.GetCurrentMethod().Name , string.Format("Device {0} Not Exist, So Skip Update Tag Value", _DeviceID));
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
