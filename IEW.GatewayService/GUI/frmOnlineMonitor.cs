using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEW.ObjectManager;
using BrightIdeasSoftware;

namespace IEW.GatewayService.GUI
{
    public partial class frmOnlineMonitor : Form
    {
        public GateWayManager gateway_mgr;
        public frmOnlineMonitor(GateWayManager gwm)
        {
            InitializeComponent();
            this.gateway_mgr = gwm;
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

                case "Idle":
                    return "Idle";

                case "Down":
                    return "Down";

                default:
                    return "Off";
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReadData_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
