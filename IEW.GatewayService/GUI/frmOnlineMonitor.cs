using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private void frmOnlineMonitor_Load(object sender, EventArgs e)
        {
            List<cls_Monitor_Gateway_Info> gw_list = new List<cls_Monitor_Gateway_Info>();

            if(this.gateway_mgr.gateway_list.Count > 0)
            {
                foreach(cls_Gateway_Info gi in this.gateway_mgr.gateway_list)
                {
                    cls_Monitor_Gateway_Info mgi = new cls_Monitor_Gateway_Info();
                    mgi.gateway_id = gi.gateway_id;
                    mgi.gateway_ip = gi.gateway_ip;
                    mgi.gateway_location = gi.location;
                    mgi.gateway_status = "Off";

                    if(gi.device_info.Count > 0)
                    {
                        foreach(cls_Device_Info di in gi.device_info)
                        {
                            cls_Monitor_Device_info mdi = new cls_Monitor_Device_info();
                            mdi.device_id = di.device_name;
                            mdi.device_status = "Off";
                            mdi.plc_ip = di.plc_ip_address;
                            mdi.plc_port = di.plc_port_id;
                            mgi.device_list.Add(mdi);
                        }
                        
                    }
                    gw_list.Add(mgi);
                }
            }

            //Test data
            gw_list[0].gateway_status = "Ready";
            gw_list[1].gateway_status = "Ready";
            gw_list[2].gateway_status = "Run";

            this.gw_statusColumn.ImageGetter = new BrightIdeasSoftware.ImageGetterDelegate(this.GWStatusImageGetter);
            lvoStatus.SetObjects(gw_list);
            lvoStatus.RefreshObjects(gw_list);
        }

        public object GWStatusImageGetter(object rawObject)
        {
            cls_Monitor_Gateway_Info mgi = (cls_Monitor_Gateway_Info)rawObject;
            switch (mgi.gateway_status)
            {
                case "Off":
                    return "Off";

                case "Ready":
                    return "Ready";

                case "Run":
                    return "Run";

                case "Down":
                    return "Down";

                default:
                    return "Off";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ArrayList gw_list = new ArrayList();
            
            gw_list = (ArrayList)lvoStatus.CheckedObjects;
            if(gw_list.Count <= 0)
            {
                MessageBox.Show("Please select the gateway!", "Error");
                return;
            }

            foreach (cls_Monitor_Gateway_Info gw in gw_list)
            {
                cls_Collect_start cmd_start = new cls_Collect_start();
                cmd_start.Cmd_Type = "Start";
                cmd_start.Trace_ID = DateTime.Now.ToString("yyyyMMddhhmmss");
                foreach(cls_Monitor_Device_info dv in gw.device_list)
                {
                    cls_DeviceInfo_start device_info = new cls_DeviceInfo_start();
                    device_info.IP_ADDR = dv.plc_ip;
                    device_info.PORT_ID = dv.plc_port;
                    cmd_start.Device_Info.Add(device_info);
                    string tmp_json = JsonConvert.SerializeObject(cmd_start, Newtonsoft.Json.Formatting.Indented);
                    IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "GateWay_Collect_Cmd_Start", new object[] { gw.gateway_id, dv.device_id, tmp_json });
                }
            }
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            ArrayList gw_list = new ArrayList();
            string GateWayID;

            gw_list = (ArrayList)lvoStatus.CheckedObjects;
            if (gw_list.Count <= 0)
            {
                MessageBox.Show("Please select the gateway!", "Error");
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

            foreach (cls_Monitor_Gateway_Info gw in gw_list)
            {
                if(gw.gateway_status == "Off" || gw.gateway_status == "Down")
                {
                    MessageBox.Show("Gateway status is wrong, [" + gw.gateway_id + "] will not send ReadData command", "Warning");
                    continue;
                }

                GateWayID = gw.gateway_id;
                foreach(cls_Monitor_Device_info dv in gw.device_list)
                {
                    string DeviceID = dv.device_id;
                    string tmp_json = this.object_mgr.GatewayCommand_Json("Collect", txtInterval.Text.Trim(), DateTime.Now.ToString("yyyyMMddhhmmssfff"), GateWayID, DeviceID);
                    IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "GateWay_Collect_Cmd_Download", new object[] { GateWayID, DeviceID, tmp_json });
                }
            }
        }


    }
}
