using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using IEW.Platform.Kernel.Common;
using IEW.Platform.Kernel.Log;
using IEW.ObjectManager;
using BrightIdeasSoftware;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IEW.GatewayService.GUI
{
    public partial class frmOnlineMonitor : Form
    {
        public GateWayManager gateway_mgr;
        public IEW.ObjectManager.ObjectManager object_mgr;

        public frmOnlineMonitor(IEW.ObjectManager.ObjectManager obj_mgr)
        {
            InitializeComponent();
            this.gateway_mgr = obj_mgr.GatewayManager;
            this.object_mgr = obj_mgr;
            this.object_mgr.HeartBeatEventHandler += new EventHandler(this.StatusUpdate);
            this.object_mgr.EDCReportEventHandler += new EventHandler(this.StatusUpdate);
            this.object_mgr.StartAckEventHandler += new EventHandler(this.StatusUpdate);
            this.object_mgr.ConfigAckEventHandler += new EventHandler(this.StatusUpdate);
        }

        private void frmOnlineMonitor_Load(object sender, EventArgs e)
        {
            this.dv_statusColumn.ImageGetter = new BrightIdeasSoftware.ImageGetterDelegate(this.DeviceStatusImageGetter);
            this.iot_statusColumn.ImageGetter = new BrightIdeasSoftware.ImageGetterDelegate(this.IoTStatusImageGetter);

            lvoStatus.SetObjects(this.object_mgr.MonitorManager.device_list);
            //lvoStatus.UncheckSubItem(this.object_mgr.MonitorManager.device_list, dv_idColumn);
            lvoStatus.RefreshObjects(this.object_mgr.MonitorManager.device_list);
        }

        public object DeviceStatusImageGetter(object rawObject)
        {
            cls_Monitor_Device_Info mdi = (cls_Monitor_Device_Info)rawObject;
            switch (mdi.device_status)
            {
                case "Off":
                    return "Off";

                case "Ready":
                    return "Ready";

                case "Run":
                    return "Run";

                case "Down":
                    return "Down";

                case "Idle":
                    return "Idle";

                default:
                    return "Off";
            }
        }

        public object IoTStatusImageGetter(object rawObject)
        {
            cls_Monitor_Device_Info mdi = (cls_Monitor_Device_Info)rawObject;
            switch(mdi.iotclient_status)
            {
                case "Off":
                    return "Off";

                case "Ready":
                    return "Ready";
                /*
                case "Run":
                    return "Run";

                case "Down":
                    return "Down";

                case "Idle":
                    return "Idle";
                */
                default:
                    return "Off";
            }
        }

        private void StatusUpdate(object sender, EventArgs e)
        {
            lvoStatus.RefreshObjects(this.object_mgr.MonitorManager.device_list);
            return;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ArrayList dv_list = new ArrayList();
            
            dv_list = (ArrayList)lvoStatus.CheckedObjects;
            if(dv_list.Count <= 0)
            {
                MessageBox.Show("Please select the device!", "Error");
                return;
            }

            foreach (cls_Monitor_Device_Info dv in dv_list)
            {
                // If device is a virtual device, then directly send the Start/Ack MQTT message to CCS
                if(dv.virtual_flag)
                {
                    IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "SendStartAck", new object[] { dv.gateway_id, dv.device_id });
                    Thread.Sleep(500);
                    continue;
                }

                cls_Collect_start cmd_start = new cls_Collect_start();
                cmd_start.Cmd_Type = "Start";
                cmd_start.Trace_ID = DateTime.Now.ToString("yyyyMMddhhmmss");
                cls_DeviceInfo_start device_info = new cls_DeviceInfo_start();
                device_info.IP_ADDR = dv.plc_ip;
                device_info.PORT_ID = dv.plc_port;
                cmd_start.Device_Info.Add(device_info);
                string tmp_json = JsonConvert.SerializeObject(cmd_start, Newtonsoft.Json.Formatting.Indented);
                IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "GateWay_Collect_Cmd_Start", new object[] { dv.gateway_id, dv.device_id, tmp_json });
                Thread.Sleep(500);
            }
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            ArrayList dv_list = new ArrayList();
            string GateWayID;

            dv_list = (ArrayList)lvoStatus.CheckedObjects;
            if (dv_list.Count <= 0)
            {
                MessageBox.Show("Please select the device!", "Error");
                return;
            }

            if(txtInterval.Text.Trim() == "")
            {
                MessageBox.Show("Please input the data report interval!", "Error");
                return;
            }
            else
            {
                int value;
                if(!int.TryParse(txtInterval.Text.Trim(), out value))
                {
                    MessageBox.Show("Report Interval should be number only!", "Error");
                    return;
                }
            }

            foreach (cls_Monitor_Device_Info dv in dv_list)
            {
                if(dv.device_status == "Off" || dv.device_status == "Down")
                {
                    MessageBox.Show("Device status is wrong, [" + dv.device_id + "] will not send ReadData command", "Warning");
                    continue;
                }

                if (dv.iotclient_status != "Ready")
                {
                    MessageBox.Show("IoTClient status is wrong, [" + dv.device_id + "] will not send ReadData command", "Warning");
                    continue;
                }

                GateWayID = dv.gateway_id;
                string DeviceID = dv.device_id;
                string tmp_json = this.object_mgr.GatewayCommand_Json("Collect", txtInterval.Text.Trim(), DateTime.Now.ToString("yyyyMMddhhmmssfff"), GateWayID, DeviceID);
                IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "GateWay_Collect_Cmd_Download", new object[] { GateWayID, DeviceID, tmp_json });
                Thread.Sleep(500);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                this.object_mgr.HeartBeatEventHandler -= new EventHandler(this.StatusUpdate);
                this.object_mgr.EDCReportEventHandler -= new EventHandler(this.StatusUpdate);
                this.object_mgr.StartAckEventHandler -= new EventHandler(this.StatusUpdate);
                this.object_mgr.ConfigAckEventHandler -= new EventHandler(this.StatusUpdate);
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
