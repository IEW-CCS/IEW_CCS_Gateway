using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using IEW.ObjectManager;
using IEW.GatewayService.UI;

namespace IEW.GatewayService.GUI
{
    public delegate void SetGatewayInfo(cls_Gateway_Info g_info, bool edit_flag);
    public delegate bool ChechDuplicateGatewayID(string gw_id);

    public partial class frmEditGateway : Form
    {
        public List<cls_Device_Info> device_list = new List<cls_Device_Info>();
        bool isEdit;
        bool isCopy;
        public cls_Gateway_Info gateway_Info;
        //int iGatewayIndex;
        public SetGatewayInfo delgSetGateway;
        public ChechDuplicateGatewayID delgCheckDuplicate;
        public cls_Gateway_Info old_gw;

        //Constructor currently no use
        public frmEditGateway()
        {
            InitializeComponent();
            this.isEdit = false;
        }
        

        //Constructor currently no use
        public frmEditGateway(cls_Gateway_Info gw)
        {
            InitializeComponent();
            this.isEdit = true;
            this.gateway_Info = gw;
            this.device_list = gw.device_info;
            //iGatewayIndex = index;
        }

        //Constructor called by frmListGateway after double clicked the gateway list
        //Constructor called by Gateway.cs after clicked the gateway node
        public frmEditGateway(SetGatewayInfo set_gw, cls_Gateway_Info gw)
        {
            InitializeComponent();
            this.isEdit = true;
            if(gw.gateway_id == "")
            {
                this.isCopy = true;
            }
            this.gateway_Info = gw;
            this.device_list = gw.device_info;
            //iGatewayIndex = index;
            this.delgSetGateway = set_gw;
        }

        // Constructor called by frmListGateway after clicked "+" button
        public frmEditGateway(SetGatewayInfo set_gw, ChechDuplicateGatewayID check, bool edit_flag)
        {
            InitializeComponent();
            this.isEdit = edit_flag;
            this.gateway_Info = new cls_Gateway_Info();
            this.delgSetGateway = set_gw;
            this.delgCheckDuplicate = check;
        }
        
        private void frmEditGateway_Load(object sender, EventArgs e)
        {
            lvGWDevice.Columns.Clear();
            lvGWDevice.Columns.Add("Device ID", 100);
            lvGWDevice.Columns.Add("Device Type", 100);
            lvGWDevice.Columns.Add("PLC IP", 100);
            lvGWDevice.Columns.Add("PLC Port", 100);
            lvGWDevice.Columns.Add("BLE MAC", 100);
            lvGWDevice.Columns.Add("BLE Service UUID", 100);
            if(this.isEdit)
            {
                txtGatewayID.Text = this.gateway_Info.gateway_id;
                if(this.isCopy)
                {
                    txtGatewayID.Enabled = true;
                }
                else
                {
                    txtGatewayID.Enabled = false;
                }
                txtGatewayIP.Text = this.gateway_Info.gateway_ip;
                txtLocation.Text = this.gateway_Info.location;
                if(this.gateway_Info.virtual_flag)
                {
                    chkVirtual.Checked = true;
                    txtTopic.Text = this.gateway_Info.virtual_publish_topic;
                }
                else
                {
                    chkVirtual.Checked = false;
                    txtTopic.Text = "";
                    txtTopic.Enabled = false;
                }

                DisplayDeviceList();
            }
            else
            {
                txtGatewayID.Enabled = true;
            }
        }

        private void btnGWCancel_Click(object sender, EventArgs e)
        {
            //Gateway lgateway = (Gateway)this.Owner;
            //lgateway.RefreshGatewayConfig();
            this.Close();
        }

        private void btnDeviceAdd_Click(object sender, EventArgs e)
        {
            var frm = new frmEditDevice();
            frm.Owner = this;
            frm.ShowDialog();
            DisplayDeviceList();
        }

        private void DisplayDeviceList()
        {
            if (this.gateway_Info.device_info.Count > 0)
            {
                lvGWDevice.BeginUpdate();
                lvGWDevice.Items.Clear();
                //foreach ( cls_Device_Info di in device_list )
                foreach (cls_Device_Info di in this.gateway_Info.device_info)
                {
                    ListViewItem lvItem = new ListViewItem(di.device_name);
                    lvItem.SubItems.Add(di.device_type);
                    lvItem.SubItems.Add(di.plc_ip_address);
                    lvItem.SubItems.Add(di.plc_port_id);
                    lvItem.SubItems.Add(di.ble_mac);
                    //lvItem.SubItems.Add(di.ble_service_uuid);
                    lvGWDevice.Items.Add(lvItem);
                }
                lvGWDevice.EndUpdate();
            }
        }

        private void btnGWSave_Click(object sender, EventArgs e)
        {
            //Gateway lgateway = (Gateway)this.Owner;
            cls_Gateway_Info giTemp = new cls_Gateway_Info();

            if ( txtGatewayID.Text.Trim() == "" )
            {
                MessageBox.Show("Please enter the gateway id!", "Error");
                return;
            }
            else
            {
                if(!this.isEdit || this.isCopy)
                {
                    /*
                    if(!this.delgCheckDuplicate(txtGatewayID.Text.Trim()))
                    {
                        return;
                    }
                    */
                    bool gw_duplicate_flag = (bool)IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "CheckDuplicateGatewayID", new object[] { txtGatewayID.Text.Trim() });
                    if (gw_duplicate_flag)
                    {
                        MessageBox.Show("Gateway ID [" + txtGatewayID.Text.Trim() + "] is duplicate, it should be unique!!", "Error");
                        return;
                    }
                }
            }

            if(!chkVirtual.Checked)
            {
                if (txtGatewayIP.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the gateway ip!", "Error");
                    return;
                }
                else
                {
                    IPAddress ip;
                    bool validate = IPAddress.TryParse(txtGatewayIP.Text.Trim(), out ip);
                    if (!validate)
                    {
                        MessageBox.Show("Please enter the  valid ip address!", "Error");
                        return;
                    }
                }
            }

            if (lvGWDevice.Items.Count == 0)
            {
                MessageBox.Show("Please add at lease one device", "Error");
                return;
            }

            giTemp.gateway_id = txtGatewayID.Text.Trim();
            giTemp.gateway_ip = txtGatewayIP.Text.Trim();
            giTemp.location = txtLocation.Text.Trim();
            if(chkVirtual.Checked)
            {
                if(txtTopic.Text.Trim() == "")
                {
                    MessageBox.Show("Please input the Publish Topic for virtual gateway", "Error");
                    return;
                }
                giTemp.virtual_flag = true;
            }
            else
            {
                giTemp.virtual_flag = false;
            }

            giTemp.virtual_publish_topic = txtTopic.Text.Trim();
            //giTemp.device_info = this.device_list;
            giTemp.device_info = this.gateway_Info.device_info;

            if (this.isCopy)
            {
                foreach(cls_Device_Info dvi in giTemp.device_info)
                {
                    bool duplicate_flag = (bool)IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "CheckDuplicateDeviceID", new object[] { dvi.device_name });
                    if (duplicate_flag)
                    {
                        MessageBox.Show("Device ID [" + dvi.device_name + "] is duplicate, it should be unique!!", "Error");
                        return;
                    }
                }

                delgSetGateway(giTemp, false);
            }
            else
            {
                delgSetGateway(giTemp, this.isEdit);
            }

            giTemp = null;

            this.Close();
        }

        private void btnDeviceRemove_Click(object sender, EventArgs e)
        {
            string strDeviceID;

            if (lvGWDevice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the device first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the device?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvGWDevice.Focus();
                return;
            }

            strDeviceID = lvGWDevice.SelectedItems[0].Text;

            int i = 0;

            foreach (cls_Device_Info di in device_list)
            {
                if (di.device_name == strDeviceID)
                {
                    device_list.RemoveAt(i);
                    break;
                }
                i++;
            }
            DisplayDeviceList();
        }

        private void lvGWDevice_DoubleClick(object sender, EventArgs e)
        {
            string strDeviceID;

            if (lvGWDevice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the device first!", "Error");
                return;
            }

            strDeviceID = lvGWDevice.SelectedItems[0].Text.Trim();

            int i = 0;

            cls_Device_Info deviceTemp = this.gateway_Info.device_info.Where(o => o.device_name == strDeviceID).FirstOrDefault();
            if(deviceTemp == null)
            {
                return;
            }

            i = this.gateway_Info.device_info.FindIndex(p => p.device_name == deviceTemp.device_name);
            /*
            foreach (cls_Device_Info di in this.gateway_Info.device_info)
            {
                if (di.device_name == strDeviceID)
                {
                    deviceTemp = this.gateway_Info.device_info[i];
                    break;
                }
                i++;
            }
            */

            if(this.isCopy)
            {
                deviceTemp.device_name = "";
            }

            var frm = new frmEditDevice(deviceTemp, i);
            frm.Owner = this;
            frm.ShowDialog();

            DisplayDeviceList();
            lvGWDevice.Focus();
        }

        private void chkVirtual_CheckedChanged(object sender, EventArgs e)
        {
            if(chkVirtual.Checked)
            {
                txtTopic.Enabled = true;
            }
            else
            {
                txtTopic.Enabled = false;
                txtTopic.Text = "";
            }
        }
    }
}
