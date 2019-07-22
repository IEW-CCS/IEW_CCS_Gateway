using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using System.Collections.Concurrent;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;
using IEW.Platform.Kernel.Log;


namespace IEW.ObjectManager
{
    public class ObjectManager
    {
        public GateWayManager GatewayManager = null;
        public TagSetManager TagSetManager = null;
        public EDCManager EDCManager = null;
        public MonitorManager MonitorManager = null;
        public DBManager DBManager = null;
        public VersionManager VersionManager = null;
        public OTAManager OTAManager = null;

        public event EventHandler HeartBeatEventHandler;
        public event EventHandler EDCReportEventHandler;
        public event EventHandler StartAckEventHandler;
        public event EventHandler ConfigAckEventHandler;
        public event EventHandler OTAAckEventHandler;

        #region Gateway Constructor
        public void GatewayManager_Initial()
        {
            this.GatewayManager = new GateWayManager();
        }

        public void GatewayManager_Initial(string Json)
        {
            this.GatewayManager = JsonConvert.DeserializeObject<GateWayManager>(Json);
        }
        #endregion

        #region Tagset Constructor
        public void TagSetManager_Initial()
        {
            this.TagSetManager = new TagSetManager();
        }

        public void TagSetManager_Initial(string Json)
        {
            this.TagSetManager = JsonConvert.DeserializeObject<TagSetManager>(Json);
        }
        #endregion

        #region EDCManager Constructor
        public void EDCManager_Initial()
        {
            this.EDCManager = new EDCManager();
        }

        public void EDCManager_Initial(string Json)
        {
            this.EDCManager = JsonConvert.DeserializeObject<EDCManager>(Json);
        }
        #endregion

        #region MonitorManager Constructor
        public void MonitorManager_Initial()
        {
            this.MonitorManager = new MonitorManager();
        }

        public void MonitorManager_Initial(string Json)
        {
            this.MonitorManager = JsonConvert.DeserializeObject<MonitorManager>(Json);
        }
        #endregion

        #region DBManager Constructor
        public void DBManager_Initial()
        {
            this.DBManager = new DBManager();
        }

        public void DBManager_Initial(string Json)
        {
            this.DBManager = JsonConvert.DeserializeObject<DBManager>(Json);
        }
        #endregion

        #region VersionManager Constructor
        public void VersionManager_Initial()
        {
            this.VersionManager = new VersionManager();
        }

        public void VersionManager_Initial(string Json)
        {
            this.VersionManager = JsonConvert.DeserializeObject<VersionManager>(Json);
        }
        #endregion

        #region OTAManager Constructor
        public void OTAManager_Initial()
        {
            this.OTAManager = new OTAManager();
        }

        public void OTAManager_Initial(string Json)
        {
            this.OTAManager = JsonConvert.DeserializeObject<OTAManager>(Json);
        }
        #endregion

        #region Gateway Method
        public void GatewayManager_Set_TagValue(cls_ProcRecv_CollectData ProcRecv_CollectData)
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
                            tag.Value = _tag.Item2;
                            Device.tag_info.AddOrUpdate(_tag.Item1, tag, (key, oldvalue) => tag);
                        }
                    }
                }
                else
                {
                    NLogManager.Logger.LogError("Service", GetType().Name, MethodInfo.GetCurrentMethod().Name, string.Format("Device {0} Not Exist, So Skip Update Tag Value", _DeviceID));
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
                return JsonConvert.SerializeObject(GatewayManager, Newtonsoft.Json.Formatting.Indented);
            }
            catch
            {
                return null;
            }
        }

        public string TagSetManager_ToJson_String()
        {

            try
            {
                return JsonConvert.SerializeObject(TagSetManager, Newtonsoft.Json.Formatting.Indented);
            }
            catch
            {
                return null;
            }
        }

        public string MonitorManager_ToJson_String()
        {
            try
            {
                return JsonConvert.SerializeObject(MonitorManager, Newtonsoft.Json.Formatting.Indented);
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
                if (Device == null)
                {
                    return null;
                }
                else
                {

                    cls_Collect collect_cmd = new cls_Collect(_Cmd_Type, _Report_Interval, _Trace_ID, Device);
                    return JsonConvert.SerializeObject(collect_cmd, Newtonsoft.Json.Formatting.Indented);
                }
            }
        }
        #endregion

        #region Event Handler for Online Monitor
        public void OnHeartBeatEventCall(EventArgs e)
        {
            if(this.HeartBeatEventHandler != null)
            {
                HeartBeatEventHandler(this, e);
            }
        }

        public void OnEDCReportEventCall(EventArgs e)
        {
            if(this.EDCReportEventHandler != null)
            {
                EDCReportEventHandler(this, e);
            }
        }

        public void OnStartAckEventCall(EventArgs e)
        {
            if(this.StartAckEventHandler != null)
            {
                StartAckEventHandler(this, e);
            }
        }

        public void OnConfigAckEventCall(EventArgs e)
        {
            if (this.ConfigAckEventHandler != null)
            {
                ConfigAckEventHandler(this, e);
            }
        }
        #endregion

        #region Event Handler for OTA Update
        public void OnOTAAckEventCall(EventArgs e)
        {
            if(this.OTAAckEventHandler != null)
            {
                OTAAckEventHandler(this, e);
            }
        }
        #endregion
    }
}
