﻿using System;
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
using System.Globalization;

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


        private Thread th_Proc_Flow = null;
        private bool _run = false;

        //----暫時存放到Queue中在慢慢Update到ObjectManager去
        internal static ConcurrentQueue<cls_ProcRecv_CollectData> _Update_TagValue_Queue = new ConcurrentQueue<cls_ProcRecv_CollectData>();

        public override bool Init()
        {
            bool ret = false;
            try
            {
                // 以下建構子 讀取 gateway json string from file 
                // ObjectManager.GatewayManager_Initial(InputData.MQTTPayload.ToString());

                _run = true;
                this.th_Proc_Flow = new Thread(new ThreadStart(Proc_Flow));
                this.th_Proc_Flow.Start();

                // Timer_Routine_Job(routine_interval);

                NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Gateway_Initial Finished");
                ret = true;
            }
            catch
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Gateway_Initial Failed");
                Destroy();
                ret = false;
            }
            return ret;
        }

        public void Destroy()
        {
            try
            {
                if (_run)
                {
                    _run = false;
                }

                if (this.th_Proc_Flow != null && this.th_Proc_Flow.IsAlive)
                {
                    this.th_Proc_Flow.Abort();
                    this.th_Proc_Flow.Join();

                }

            }
            catch (Exception ex)
            {
                NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
            }

            NLogManager.Logger.LogInfo(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", "Gateway_Destory");
        }

        public bool CheckDuplicateDeviceID(string device_id)
        {
            //MessageBox.Show("GatewayService receive invoke", "Information");
            foreach(cls_Gateway_Info gw_info in ObjectManager.GatewayManager.gateway_list)
            {
                foreach(cls_Device_Info dv_info in gw_info.device_info)
                {
                    if(dv_info.device_name == device_id)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        //-------- send out MQTT Data -------
        private void SendMQTTData(xmlMessage msg)
        {
            PutMessage(msg);
        }

        // From GUI Trigger Msg 
        public void GateWay_Collect_Cmd_Download(string gatewayid, string deviceid, string msg)
        {
            xmlMessage SendOutMsg = new xmlMessage();
            SendOutMsg.LineID = gatewayid;
            SendOutMsg.DeviceID = deviceid;
            SendOutMsg.MQTTTopic = "Collect_Cmd";
            SendOutMsg.MQTTPayload = msg;
            SendMQTTData(SendOutMsg);

        }

        // From GUI Trigger Msg 
        public void GateWay_Collect_Cmd_Start(string gatewayid, string deviceid, string msg)
        {
            xmlMessage SendOutMsg = new xmlMessage();
            SendOutMsg.LineID = gatewayid;
            SendOutMsg.DeviceID = deviceid;
            SendOutMsg.MQTTTopic = "Collect_Start";
            SendOutMsg.MQTTPayload = msg;
            SendMQTTData(SendOutMsg);

        }

        private void TimerTask(object timerState)
        {
            if (_Update_TagValue_Queue.Count > 0)
            {
                cls_ProcRecv_CollectData _msg = null;
                while (_Update_TagValue_Queue.TryDequeue(out _msg))
                {
                    string Gateway_ID = _msg.GateWayID;
                    string Device_ID = _msg.Device_ID;
                    // Update Normal Tag
                    UpdateGatewayTagInfo(_msg);

                    // Update Calculate Tag
                    ProcCalcTag(Gateway_ID, Device_ID);

                    // 結合EDC and other Information 送MQTT
                    Organize_EDCPartaker(Gateway_ID, Device_ID);
                }
            }
        }
        public void Proc_Flow()
        {
            while (_run)
            {
                if (_Update_TagValue_Queue.Count > 0)
                {
                    cls_ProcRecv_CollectData _msg = null;
                    while (_Update_TagValue_Queue.TryDequeue(out _msg))
                    {
                        string Gateway_ID = _msg.GateWayID;
                        string Device_ID = _msg.Device_ID;
                        // Update Normal Tag
                        UpdateGatewayTagInfo(_msg);

                        // Update Calculate Tag
                        ProcCalcTag(Gateway_ID, Device_ID);

                        // 結合EDC and other Information 送MQTT
                        Organize_EDCPartaker(Gateway_ID, Device_ID);
                    }
                }
                Thread.Sleep(10);
            }
        }

        public void UpdateGatewayTagInfo(cls_ProcRecv_CollectData ProcData)
        {
            ObjectManager.GatewayManager_Set_TagValue(ProcData);
        }

        public void ProcCalcTag(string GateWayID, string Device_ID)
        {
            cls_Gateway_Info gateway = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
            if (gateway != null)
            {
                cls_Device_Info device = gateway.device_info.Where(p => p.device_name == Device_ID).FirstOrDefault();
                if (device != null)
                {
                    foreach (KeyValuePair<string, cls_CalcTag> kvp in device.calc_tag_info)
                    {
                        cls_Tag tagA = null;
                        cls_Tag tagB = null;
                        cls_Tag tagC = null;
                        cls_Tag tagD = null;
                        cls_Tag tagE = null;
                        cls_Tag tagF = null;
                        cls_Tag tagG = null;
                        cls_Tag tagH = null;

                        Double douA = -1;
                        Double douB = -1;
                        Double douC = -1;
                        Double douD = -1;
                        Double douE = -1;
                        Double douF = -1;
                        Double douG = -1;
                        Double douH = -1;
                        Double douResult = -999999.999;

                        if (kvp.Value.ParamA.Trim() != "")
                        {
                            // for vic verify dictionary key exist or not.
                            if (device.tag_info.ContainsKey(kvp.Value.ParamA))
                                tagA = device.tag_info[kvp.Value.ParamA];
                        }

                        if (kvp.Value.ParamB.Trim() != "")
                        {
                            tagB = device.tag_info[kvp.Value.ParamB];
                        }

                        if (kvp.Value.ParamC.Trim() != "")
                        {
                            tagC = device.tag_info[kvp.Value.ParamC];
                        }

                        if (kvp.Value.ParamD.Trim() != "")
                        {
                            tagD = device.tag_info[kvp.Value.ParamD];
                        }

                        if (kvp.Value.ParamE.Trim() != "")
                        {
                            tagE = device.tag_info[kvp.Value.ParamE];
                        }

                        if (kvp.Value.ParamF.Trim() != "")
                        {
                            tagF = device.tag_info[kvp.Value.ParamF];
                        }

                        if (kvp.Value.ParamG.Trim() != "")
                        {
                            tagG = device.tag_info[kvp.Value.ParamG];
                        }

                        if (kvp.Value.ParamH.Trim() != "")
                        {
                            tagH = device.tag_info[kvp.Value.ParamH];
                        }

                        try
                        {
                            douA = Convert.ToDouble(tagA.Value);
                            douB = Convert.ToDouble(tagB.Value);
                            douC = Convert.ToDouble(tagC.Value);
                            douD = Convert.ToDouble(tagD.Value);
                            douE = Convert.ToDouble(tagE.Value);
                            douF = Convert.ToDouble(tagF.Value);
                            douG = Convert.ToDouble(tagG.Value);
                            douH = Convert.ToDouble(tagH.Value);

                            ExpressionCalculator exp_calc = new ExpressionCalculator(kvp.Value.Expression, douA, douB, douC, douD, douE, douF, douG, douH);
                            douResult = exp_calc.Evaluate();
                            kvp.Value.Value = douResult.ToString();

                        }
                        catch (Exception ex)
                        {
                            douResult = -999999.999;
                        }
                    }
                }
            }
        }

        public void Organize_EDCPartaker(string GateWayID, string Device_ID)
        {
            //--- 等待EDC List information 
            List<cls_EDC_Info> lst_EDCInfo = ObjectManager.EDCManager.gateway_edc.Where(p => p.gateway_id == GateWayID && p.device_id == Device_ID && p.enable == true).ToList();

            foreach (cls_EDC_Info _EDC in lst_EDCInfo)
            {
                EDCPartaker EDCReporter = new EDCPartaker(_EDC);
                EDCReporter.timestapm = DateTime.Now;


                cls_Gateway_Info gateway = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                if (gateway != null)
                {
                    cls_Device_Info device = gateway.device_info.Where(p => p.device_name == Device_ID).FirstOrDefault();
                    if (device != null)
                    {
                        // Assembly Normal Tag info
                        foreach (Tuple<string, string> _Items in _EDC.tag_info)
                        {
                            cls_EDC_Body_Item edctiem = new cls_EDC_Body_Item();
                            edctiem.item_name = _Items.Item1;
                            edctiem.item_type = "X";
                            if (device.tag_info.ContainsKey(_Items.Item2))
                                edctiem.item_value = device.tag_info[_Items.Item2].Value;
                            else
                                edctiem.item_value = string.Empty;

                            EDCReporter.edcitem_info.Add(edctiem);
                        }

                        // Assembly Calc Tag info
                        foreach (Tuple<string, string> _Items in _EDC.calc_tag_info)
                        {
                            cls_EDC_Body_Item edctiem = new cls_EDC_Body_Item();
                            edctiem.item_name = _Items.Item1;
                            edctiem.item_type = "X";

                            if (device.calc_tag_info.ContainsKey(_Items.Item2))
                                edctiem.item_value = device.calc_tag_info[_Items.Item2].Value;
                            else
                                edctiem.item_value = string.Empty;

                            EDCReporter.edcitem_info.Add(edctiem);
                        }
                    }
                }

                //----- Send MQTT-----
                xmlMessage SendOutMsg = new xmlMessage();
                SendOutMsg.LineID = GateWayID;     // GateID
                SendOutMsg.DeviceID = Device_ID;   // DeviceID
                SendOutMsg.MQTTTopic = "EDCService";
                SendOutMsg.MQTTPayload = JsonConvert.SerializeObject(EDCReporter, Newtonsoft.Json.Formatting.Indented);
                SendMQTTData(SendOutMsg);
            }
        }

        public void ReceiveHeartBeat(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/Status/HeartBeat
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString();

            cls_HeartBeat hb = new cls_HeartBeat();
            hb = JsonConvert.DeserializeObject<cls_HeartBeat>(InputData.MQTTPayload.ToString());

            if (ObjectManager.MonitorManager != null)
            {
                cls_Monitor_Gateway_Info gw = ObjectManager.MonitorManager.monitor_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                if (gw != null)
                {
                    cls_Monitor_Device_Info dv = gw.device_list.Where(p => p.device_id == DeviceID).FirstOrDefault();
                    if (dv != null)
                    {
                        gw.gateway_status = hb.Status;
                        gw.hb_report_time = DateTime.ParseExact(hb.HBDatetime, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                        gw.hb_status = hb.Status;

                        dv.device_status = hb.Status;
                        dv.hb_status = hb.Status;
                        dv.hb_report_time = DateTime.ParseExact(hb.HBDatetime, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                    }

                    cls_Monitor_Device_Info mdv = ObjectManager.MonitorManager.device_list.Where(o => o.gateway_id == GateWayID && o.device_id == DeviceID).FirstOrDefault();
                    if(mdv != null)
                    {
                        mdv.device_status = hb.Status;
                        mdv.hb_status = hb.Status;
                        mdv.hb_report_time = DateTime.ParseExact(hb.HBDatetime, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                    }

                    this.ObjectManager.OnHeartBeatEventCall(null);
                }
            }
        }

        public void StartAck(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/Cmd/Start/Ack
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString();

            cls_StartAck sc = new cls_StartAck();
            sc = JsonConvert.DeserializeObject<cls_StartAck>(InputData.MQTTPayload.ToString());

            if (ObjectManager.MonitorManager != null)
            {
                cls_Monitor_Gateway_Info gw = ObjectManager.MonitorManager.monitor_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                if (gw != null)
                {
                    cls_Monitor_Device_Info dv = gw.device_list.Where(p => p.device_id == DeviceID).FirstOrDefault();
                    if (dv != null)
                    {
                        if(sc.Cmd_Result == "OK")
                        {
                            gw.gateway_status = "Ready";
                            gw.hb_status = "Ready";
                            gw.hb_report_time = DateTime.ParseExact(sc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                            dv.device_status = "Ready";
                            dv.hb_status = "Ready";
                            dv.hb_report_time = DateTime.ParseExact(sc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

                            //Send message to notify IoTClient for receiving Gateway/Device configuration data
                            //SendCmdConfig(GateWayID, DeviceID);
                        }
                        else
                        {
                            gw.gateway_status = "Down";
                            gw.hb_status = "Down";
                            gw.hb_report_time = DateTime.ParseExact(sc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                            dv.device_status = "Down";
                            dv.hb_status = "Down";
                            dv.hb_report_time = DateTime.ParseExact(sc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                        }
                    }

                    cls_Monitor_Device_Info mdv = ObjectManager.MonitorManager.device_list.Where(o => o.gateway_id == GateWayID && o.device_id == DeviceID).FirstOrDefault();
                    if (mdv != null)
                    {
                        if (sc.Cmd_Result == "OK")
                        {
                            mdv.device_status = "Ready";
                            mdv.hb_status = "Ready";
                            mdv.hb_report_time = DateTime.ParseExact(sc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

                            //Send message to notify IoTClient for receiving Gateway/Device configuration data
                            SendCmdConfig(GateWayID, DeviceID);
                        }
                        else
                        {
                            mdv.device_status = "Down";
                            mdv.hb_status = "Down";
                            mdv.hb_report_time = DateTime.ParseExact(sc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                        }
                    }

                    //Raise event to notify Online Monitor form to refresh status
                    this.ObjectManager.OnStartAckEventCall(null);
                }
            }
        }

        public void SendStartAck(string GateWayID, string DeviceID)
        {
            cls_StartAck sc = new cls_StartAck();
            sc.Cmd_Result = "OK";
            sc.Trace_ID = DateTime.Now.ToString("yyyyMMddHHmmssfff");

            string json_msg = JsonConvert.SerializeObject(sc, Newtonsoft.Json.Formatting.Indented);
            xmlMessage SendOutMsg = new xmlMessage();
            SendOutMsg.LineID = GateWayID;
            SendOutMsg.DeviceID = DeviceID;
            SendOutMsg.MQTTTopic = "Collect_Start_Ack";
            SendOutMsg.MQTTPayload = json_msg;
            SendMQTTData(SendOutMsg);
        }

        public void SendCmdConfig(string GateWayID, string DeviceID)
        {
            cls_Gateway_Info tmp_gw_info = new cls_Gateway_Info();
            cls_Gateway_Info gw_info = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
            if(gw_info == null)
            {
                MessageBox.Show("Can't find [" + GateWayID + "][" + DeviceID + "] Config to send to IoTClient", "Error");
                return;
            }

            tmp_gw_info.gateway_id = gw_info.gateway_id;
            tmp_gw_info.gateway_ip = gw_info.gateway_ip;
            tmp_gw_info.location = gw_info.location;
            tmp_gw_info.virtual_flag = gw_info.virtual_flag;
            tmp_gw_info.virtual_publish_topic = gw_info.virtual_publish_topic;
            tmp_gw_info.function_list = gw_info.function_list;
            cls_Device_Info dv_info = gw_info.device_info.Where(o => o.device_name == DeviceID).FirstOrDefault();
            tmp_gw_info.device_info.Add(dv_info);

            string json_msg = JsonConvert.SerializeObject(tmp_gw_info, Newtonsoft.Json.Formatting.Indented);

            xmlMessage SendOutMsg = new xmlMessage();
            SendOutMsg.LineID = GateWayID;
            SendOutMsg.DeviceID = DeviceID;
            SendOutMsg.MQTTTopic = "Cmd_Config";
            SendOutMsg.MQTTPayload = json_msg;
            SendMQTTData(SendOutMsg);
        }

        public void ConfigEDC(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/Cmd/Config/EDC
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString();

            SendConfigEDCReply(GateWayID, DeviceID);
        }

        public void SendConfigEDCReply(string GateWayID, string DeviceID)
        {
            List<cls_EDC_Info> edc_list = ObjectManager.EDCManager.gateway_edc.Where(p => p.gateway_id == GateWayID && p.device_id == DeviceID).ToList();

            if (edc_list == null)
            {
                MessageBox.Show("Can't find [" + GateWayID + "][" + DeviceID + "] EDC XML Config to send to IoTClient", "Error");
                return;
            }

            string json_msg = JsonConvert.SerializeObject(edc_list, Newtonsoft.Json.Formatting.Indented);
            xmlMessage SendOutMsg = new xmlMessage();
            SendOutMsg.LineID = GateWayID;
            SendOutMsg.DeviceID = DeviceID;
            SendOutMsg.MQTTTopic = "Cmd_Config_EDC";
            SendOutMsg.MQTTPayload = json_msg;
            SendMQTTData(SendOutMsg);
        }

        public void ConfigDB(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/Cmd/Config/DB
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString();

            SendConfigDBReply(GateWayID, DeviceID);
        }

        public void SendConfigDBReply(string GateWayID, string DeviceID)
        {
            cls_DB_Info db_info = ObjectManager.DBManager.dbconfig_list.Where(p => p.gateway_id == GateWayID && p.device_id == DeviceID).FirstOrDefault();
            if (db_info == null)
            {
                MessageBox.Show("Can't find [" + GateWayID + "][" + DeviceID + "] DB Config to send to IoTClient", "Error");
                return;
            }

            string json_msg = JsonConvert.SerializeObject(db_info, Newtonsoft.Json.Formatting.Indented);
            xmlMessage SendOutMsg = new xmlMessage();
            SendOutMsg.LineID = GateWayID;
            SendOutMsg.DeviceID = DeviceID;
            SendOutMsg.MQTTTopic = "Cmd_Config_DB";
            SendOutMsg.MQTTPayload = json_msg;
            SendMQTTData(SendOutMsg);
        }

        public void ConfigAck(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/Cmd/Config/Ack
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString();

            cls_ConfigAck ca = new cls_ConfigAck();
            ca = JsonConvert.DeserializeObject<cls_ConfigAck>(InputData.MQTTPayload.ToString());

            //Update IoTClient status in Online Monitor
            if (ObjectManager.MonitorManager != null)
            {
                cls_Monitor_Gateway_Info gw = ObjectManager.MonitorManager.monitor_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                if (gw != null)
                {
                    cls_Monitor_Device_Info dv = gw.device_list.Where(p => p.device_id == DeviceID).FirstOrDefault();
                    if (dv != null)
                    {

                        if(ca.Cmd_Result == "OK")
                        {
                            gw.iotclient_status =  "Ready";
                            dv.iotclient_status = "Ready";
                        }
                        else
                        {
                            gw.iotclient_status = "Off";
                            dv.iotclient_status = "Off";
                        }
                    }

                    cls_Monitor_Device_Info mdv = ObjectManager.MonitorManager.device_list.Where(o => o.gateway_id == GateWayID && o.device_id == DeviceID).FirstOrDefault();
                    if (mdv != null)
                    {

                        if (ca.Cmd_Result == "OK")
                        {
                            mdv.iotclient_status = "Ready";
                        }
                        else
                        {
                            mdv.iotclient_status = "Off";
                        }
                    }

                    this.ObjectManager.OnConfigAckEventCall(null);
                }
            }
        }

        public void SendOTA(string GateWayID, string DeviceID, string msg)
        {
            //string json_msg = JsonConvert.SerializeObject(ota, Newtonsoft.Json.Formatting.Indented);
            xmlMessage SendOutMsg = new xmlMessage();
            SendOutMsg.LineID = GateWayID;
            SendOutMsg.DeviceID = DeviceID;
            SendOutMsg.MQTTTopic = "Cmd_OTA";
            SendOutMsg.MQTTPayload = msg;
            SendMQTTData(SendOutMsg);
        }

        public void OTAAck(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/Cmd/OTA/Ack
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString();

            cls_Cmd_OTA_Ack ota_ack = new cls_Cmd_OTA_Ack();
            ota_ack = JsonConvert.DeserializeObject<cls_Cmd_OTA_Ack>(InputData.MQTTPayload.ToString());
            if(ota_ack.Cmd_Result == "OK")
            {
                if (ota_ack.App_Name == "IOT")
                {
                    cls_OTA_Gateway_Info ogi = ObjectManager.OTAManager.ota_iot_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                    if (ogi != null)
                    {
                        if (ota_ack.New_Version == ogi.ap_new_version)
                        {
                            ogi.ap_version = ogi.ap_new_version;
                            ogi.ap_last_store_path_name = ogi.ap_new_store_path_name;
                            ogi.md5_last_string = ogi.md5_new_string;
                            ogi.ap_new_version = "";
                            ogi.ap_new_store_path_name = "";
                            ogi.md5_new_string = "";
                            ogi.update_status = "OK";
                            ogi.last_update_time = DateTime.Now;
                            ogi.status_message = ota_ack.Return_Message;
                        }
                    }
                }
                else if (ota_ack.App_Name == "WORKER")
                {
                    cls_OTA_Gateway_Info ogi = ObjectManager.OTAManager.ota_worker_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                    if (ogi != null)
                    {
                        if (ota_ack.New_Version == ogi.ap_new_version)
                        {
                            ogi.ap_version = ogi.ap_new_version;
                            ogi.ap_last_store_path_name = ogi.ap_new_store_path_name;
                            ogi.md5_last_string = ogi.md5_new_string;
                            ogi.ap_new_version = "";
                            ogi.ap_new_store_path_name = "";
                            ogi.md5_new_string = "";
                            ogi.update_status = "OK";
                            ogi.last_update_time = DateTime.Now;
                            ogi.status_message = ota_ack.Return_Message;
                        }
                    }
                }
                else if (ota_ack.App_Name == "FIRMWARE")
                {
                    cls_OTA_Device_Info odi = ObjectManager.OTAManager.ota_firmware_list.Where(p => (p.gateway_id == GateWayID) && (p.device_id == DeviceID)).FirstOrDefault();
                    if (odi != null)
                    {
                        if (ota_ack.New_Version == odi.ap_new_version)
                        {
                            odi.ap_version = odi.ap_new_version;
                            odi.ap_last_store_path_name = odi.ap_new_store_path_name;
                            odi.md5_last_string = odi.md5_new_string;
                            odi.ap_new_version = "";
                            odi.ap_new_store_path_name = "";
                            odi.md5_new_string = "";
                            odi.update_status = "OK";
                            odi.last_update_time = DateTime.Now;
                            odi.status_message = ota_ack.Return_Message;
                        }
                    }
                }
            }
            else //OTA Result is NG
            {
                if (ota_ack.App_Name == "IOT")
                {
                    cls_OTA_Gateway_Info ogi = ObjectManager.OTAManager.ota_iot_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                    if (ogi != null)
                    {
                        ogi.update_status = ota_ack.Cmd_Result;
                        ogi.status_message = ota_ack.Return_Message;
                        ogi.last_update_time = DateTime.Now;
                    }
                }
                else if (ota_ack.App_Name == "WORKER")
                {
                    cls_OTA_Gateway_Info ogi = ObjectManager.OTAManager.ota_worker_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                    if (ogi != null)
                    {
                        ogi.update_status = ota_ack.Cmd_Result;
                        ogi.status_message = ota_ack.Return_Message;
                        ogi.last_update_time = DateTime.Now;
                    }
                }
                else if (ota_ack.App_Name == "FIRMWARE")
                {
                    cls_OTA_Device_Info odi = ObjectManager.OTAManager.ota_firmware_list.Where(p => (p.gateway_id == GateWayID) && (p.device_id == DeviceID)).FirstOrDefault();
                    if (odi != null)
                    {
                        odi.update_status = ota_ack.Cmd_Result;
                        odi.status_message = ota_ack.Return_Message;
                        odi.last_update_time = DateTime.Now;
                    }
                }
            }

            //Update new version information for gateway/device
            this.ObjectManager.OnOTAAckEventCall(null);
        }

        public void ReadDataAck(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/Cmd/ReadData/Ack
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString();

            if (ObjectManager.MonitorManager != null)
            {
                cls_Monitor_Gateway_Info gw = ObjectManager.MonitorManager.monitor_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                if (gw != null)
                {
                    cls_Monitor_Device_Info dv = gw.device_list.Where(p => p.device_id == DeviceID).FirstOrDefault();
                    if (dv != null)
                    {
                        cls_ReadDataAck rc = new cls_ReadDataAck();

                        rc = JsonConvert.DeserializeObject<cls_ReadDataAck>(InputData.MQTTPayload.ToString());
                        if (rc.Cmd_Result == "OK")
                        {
                            gw.gateway_status = "Idle";
                            gw.hb_status = "Idle";
                            gw.hb_report_time = DateTime.ParseExact(rc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                            dv.device_status = "Idle";
                            dv.hb_status = "Idle";
                            dv.hb_report_time = DateTime.ParseExact(rc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            gw.gateway_status = "Down";
                            gw.hb_status = "Down";
                            gw.hb_report_time = DateTime.ParseExact(rc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                            dv.device_status = "Down";
                            dv.hb_status = "Down";
                            dv.hb_report_time = DateTime.ParseExact(rc.Trace_ID, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                        }
                    }

                    //Raise event to notify Online Monitor form to refresh status
                    this.ObjectManager.OnHeartBeatEventCall(null);
                }
            }
        }

        public void SetOnlineMonitorEDCReportStatus(string gw_id, string dv_id, string payload)
        {
            if (ObjectManager.MonitorManager != null)
            {
                cls_Monitor_Gateway_Info gw = ObjectManager.MonitorManager.monitor_list.Where(p => p.gateway_id == gw_id).FirstOrDefault();
                if (gw != null)
                {
                    cls_Monitor_Device_Info dv = gw.device_list.Where(p => p.device_id == dv_id).FirstOrDefault();
                    if (dv != null)
                    {
                        cls_HeartBeat hb = new cls_HeartBeat();

                        cls_read_data_reply CollectData = null;
                        CollectData = JsonConvert.DeserializeObject<cls_read_data_reply>(payload);
                        gw.last_edc_time = DateTime.ParseExact(CollectData.Time_Stamp, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

                        dv.last_edc_time = DateTime.ParseExact(CollectData.Time_Stamp, "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);
                    }
                }
            }
        }

        public void ReceiveReplyData(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/ReplyData
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString();

            if (ObjectManager.GatewayManager != null)
            {
                cls_Gateway_Info Gateway = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                if (Gateway != null)
                {
                    cls_Device_Info Device = Gateway.device_info.Where(p => p.device_name == DeviceID).FirstOrDefault();
                    if (Device != null)
                    {
                        try
                        {
                            SetOnlineMonitorEDCReportStatus(GateWayID, DeviceID, InputData.MQTTPayload.ToString());

                            //Raise event to notify Online Monitor form to refresh status
                            this.ObjectManager.OnEDCReportEventCall(null);
                        }
                        catch (Exception ex)
                        {
                            NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
                        }
                    }
                }
            }
        }

        public void ReceiveMQTTData(xmlMessage InputData)
        {
            // Parse Mqtt Topic
            string[] Topic = InputData.MQTTTopic.Split('/');    // /IEW/GateWay/Device/ReplyData
            string GateWayID = Topic[2].ToString();
            string DeviceID = Topic[3].ToString() ;

            if (ObjectManager.GatewayManager != null)
            {
                cls_Gateway_Info Gateway = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == GateWayID).FirstOrDefault();
                if (Gateway != null)
                {
                    cls_Device_Info Device = Gateway.device_info.Where(p => p.device_name == DeviceID).FirstOrDefault();
                    if (Device != null)
                    {
                        try
                        {
                            ProcCollectData Function = new ProcCollectData(Device, GateWayID, DeviceID);
                            ThreadPool.QueueUserWorkItem(o => Function.ThreadPool_Proc(InputData.MQTTPayload.ToString()));

                            SetOnlineMonitorEDCReportStatus(GateWayID, DeviceID, InputData.MQTTPayload.ToString());
                            //Raise event to notify Online Monitor form to refresh status
                            this.ObjectManager.OnEDCReportEventCall(null);
                        }
                        catch (Exception ex)
                        {
                            NLogManager.Logger.LogError(LogName, GetType().Name, MethodInfo.GetCurrentMethod().Name + "()", ex);
                        }
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

        private string[] CheckWordType = { "W", "D", "ZR" };

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
                cls_read_data_reply CollectData = null;
                CollectData = JsonConvert.DeserializeObject<cls_read_data_reply>(msg.ToString());
    
                cls_ProcRecv_CollectData ProcRecv_CollectData = new cls_ProcRecv_CollectData();
                ProcRecv_CollectData.GateWayID = _GatewayID;
                ProcRecv_CollectData.Device_ID = _DeviceID;
              
                if (CollectData != null)
                {
                    // 直接平行處理對應所有Tag
                    Parallel.ForEach(CollectData.EDC_Data, p =>
                    {
                        cls_Tag Device_Tag = _Device.tag_info[p.DATA_NAME];
                        string Tag_Value = p.DATA_VALUE;
                        int BitPoints = 0;
                        double tmp_output = 0;
                        string Output = string.Empty;

                        if (Device_Tag.Type == "PLC")
                        {
                            if (CheckWordType.Any(x => Device_Tag.UUID_Address.Contains(x)))
                            {
                                if (Tag_Value.Length % 4 != 0)
                                    return;
                                switch (Device_Tag.Expression)
                                {
                                    case "BIT":
                                        BitPoints = CalcBitPoints(Device_Tag.UUID_Address);
                                        if (BitPoints != 0)
                                            Output = HexToBit(0, BitPoints, Tag_Value);
                                        else
                                            Output = string.Empty;
                                        break;

                                    case "UINT":
                                        BitPoints = 16;   // Int固定16 bit ;
                                        tmp_output = HexToInt(BitPoints, Tag_Value);
                                        tmp_output = (Device_Tag.scale * tmp_output) + Device_Tag.offset;
                                        Output = tmp_output.ToString();
                                        break;

                                    case "ULONG":
                                        BitPoints = 32;
                                        tmp_output = HexToLong(BitPoints, Tag_Value);
                                        tmp_output = (Device_Tag.scale * tmp_output) + Device_Tag.offset;
                                        Output = tmp_output.ToString();
                                        break;
                                    case "SINT":
                                        BitPoints = 16;
                                        tmp_output = HexToSInt(BitPoints, Tag_Value);
                                        tmp_output = (Device_Tag.scale * tmp_output) + Device_Tag.offset;
                                        Output = tmp_output.ToString();
                                        break;
                                    case "SLONG":
                                        BitPoints = 32;
                                        tmp_output = HexToSLong(BitPoints, Tag_Value);
                                        tmp_output = (Device_Tag.scale * tmp_output) + Device_Tag.offset;
                                        Output = tmp_output.ToString();
                                        break;

                                    case "ASC":
                                        Output = HexToASCII(Tag_Value);  //  目前Decode 全部都解析解析完再考慮長度
                                        break;
                                    default:
                                        Output = string.Empty;
                                        break;
                                }
                            }
                        }

                        if (Output != string.Empty)
                        {
                            ProcRecv_CollectData.Prod_EDC_Data.Enqueue(Tuple.Create(p.DATA_NAME, Output));
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

        // -----  decode method  -----

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

        public int CalcBitPoints( string UUID_Address)
        {
            char[] delimiterChars = { '.', ':' };
            int first_colon_index = -1;
            int first_dot_index = -1;

            string[] Split_Words = UUID_Address.Split(delimiterChars);
          
            first_colon_index = UUID_Address.IndexOf(":");
            first_dot_index = UUID_Address.IndexOf(".");

            //----- 討論不合法表示是是否該回傳整個word or o
            if ((first_colon_index == -1) && first_dot_index == -1)  // W1000  沒有寫 dot or :
            {
                //return 0;
                return 16;
            }
            else if (first_colon_index == -1)                       // 忘記標誌 : 則代表全部
            {
                //return 0;
                return 16;
            }
            else if( first_dot_index < first_colon_index)          //W1000.3:5   
            {
                string[] tempSplit_Words = UUID_Address.Substring(first_dot_index).Split(delimiterChars);
                int start = int.Parse(tempSplit_Words[1]);
                int end = int.Parse(tempSplit_Words[2]);
                int diff = (end - start) + 1;
                return diff ;
            }
            else   // 表示不合法的表示式for bit return 0 
            {
                return 0; 
            }
        }

        public int CalcWordPoints(string UUID_Address)
        {
            char[] delimiterChars = { '.', ':' };
            int first_colon_index = -1;
            int first_dot_index = -1;

            string[] Split_Words = UUID_Address.Split(delimiterChars);

            //---- Address 用法  W1000:3000
            first_colon_index = UUID_Address.IndexOf(":");
            first_dot_index =UUID_Address.IndexOf(".");

            if ((first_colon_index > -1) && first_dot_index == -1)   // W1000:3000
            {
                int start = int.Parse(Split_Words[0].Replace("W", "").Replace("w", ""));
                int end = int.Parse(Split_Words[1].Replace("W", "").Replace("w", ""));
                int diff = (end - start) + 1;
                return diff;
               
            }
            else
            {
                return 1;
            }
        }

    }

}
