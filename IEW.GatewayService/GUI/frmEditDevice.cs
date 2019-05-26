using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEW.ObjectManager;
using IEW.GatewayService.UI;
using System.Net;
using System.Collections.Concurrent;

namespace IEW.GatewayService.GUI
{
    public partial class frmEditDevice : Form
    {
        bool isEdit;
        bool isEmbedded;
        cls_Device_Info device_data;
        cls_Gateway_Info gw_data;
        ConcurrentDictionary<string, cls_Tag> taglist_data = new ConcurrentDictionary<string, cls_Tag>();
        int iDeviceIndex;

        public frmEditDevice()
        {
            InitializeComponent();
            this.isEdit = false;
            this.isEmbedded = false;
        }

        public frmEditDevice(cls_Device_Info device, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            this.isEmbedded = false;
            this.device_data = device;
            this.iDeviceIndex = index;
        }

        public frmEditDevice(cls_Gateway_Info gw, cls_Device_Info device, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            this.isEmbedded = true;
            this.gw_data = gw;
            this.device_data = device;
            this.iDeviceIndex = index;
        }

        private void frmEditDevice_Load(object sender, EventArgs e)
        {
            cmbType.Items.Clear();
            cmbType.Items.Add("PLC");
            cmbType.Items.Add("BLE");
            if(this.isEdit)
            {
                txtDeviceID.Text = device_data.device_name;
                txtDeviceID.Enabled = false;
                cmbType.Text = device_data.device_type;
                txtPLC_IP.Text = device_data.plc_ip_address;
                txtPLC_Port .Text= device_data.plc_port_id;
                txtBLE_Mac.Text = device_data.ble_mac;
                //txtBLE_Service_UUID.Text = device_data.ble_service_uuid;
            }
            else
            {
                txtDeviceID.Enabled = true;
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ( cmbType.Text == "PLC")
            {
                pnlBLE.Enabled = false;
                txtBLE_Mac.Text = "";
                txtBLE_Service_UUID.Text = "";
                pnlPLC.Enabled = true;
                txtPLC_IP.Enabled = true;
                txtPLC_Port.Enabled = true;
            }
            else if (cmbType.Text == "BLE")
            {
                pnlBLE.Enabled = true;
                txtBLE_Mac.Enabled = true;
                txtBLE_Service_UUID.Enabled = true;
                pnlPLC.Enabled = false;
                txtPLC_IP.Text = "";
                txtPLC_Port.Text = "";
            }
        }

        private void btnDeviceCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public cls_Device_Info GetDeviceInfo()
        {
            return device_data;
        }

        private void btnDeviceSave_Click(object sender, EventArgs e)
        {
            cls_Device_Info diTemp = new cls_Device_Info();

            if ( txtDeviceID.Text.Trim() == "" )
            {
                MessageBox.Show("Please enter Device ID!", "Error");
                return;
            }

            if (cmbType.Text == "PLC")
            {
                if (txtPLC_IP.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the PLC ip!", "Error");
                    return;
                }
                else
                {
                    IPAddress ip;
                    bool validate = IPAddress.TryParse(txtPLC_IP.Text.Trim(), out ip);
                    if (!validate)
                    {
                        MessageBox.Show("Please enter the  valid ip address!", "Error");
                        return;
                    }
                }

                if (txtPLC_Port.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the port id!", "Error");
                    return;
                }
            }
            else if ( cmbType.Text == "BLE" )
            {
                if (txtBLE_Mac.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the MAC address!", "Error");
                    return;
                }
                else
                {
                    Regex r = new Regex("^([0-9a-fA-F]{2}(?:(?:-[0-9a-fA-F]{2}){5}|(?::[0-9a-fA-F]{2}){5}|[0-9a-fA-F]{10}))$");
                    if( !r.IsMatch(txtBLE_Mac.Text.Trim()) )
                    {
                        MessageBox.Show("Invalid MAC address!", "Error");
                        return;
                    }
                }

                if (txtBLE_Service_UUID.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter the BLE Service UUID!", "Error");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select the device type!", "Error");
                return;
            }

            diTemp.device_name = txtDeviceID.Text.Trim();
            diTemp.device_type = cmbType.Text.Trim();
            diTemp.plc_ip_address = txtPLC_IP.Text.Trim();
            diTemp.plc_port_id = txtPLC_Port.Text.Trim();
            diTemp.ble_mac = txtBLE_Mac.Text.Trim();
            if (txtBLE_Service_UUID.Text.Trim() == "")
            {
                diTemp.ble_service_uuid = null;
            }
            else
            {
                diTemp.ble_service_uuid.Add(txtBLE_Service_UUID.Text.Trim());
            }
          
            if (lvTagList.Items.Count > 0)
            {

            }

            this.device_data = diTemp;

            if(!isEmbedded)
            {
                frmEditGateway pgw = (frmEditGateway)this.Owner;

                if (!isEdit)
                {
                    pgw.device_list.Add(diTemp);
                }
                else
                {
                    pgw.device_list[iDeviceIndex] = diTemp;
                }
            }
            else
            {
                Gateway p = (Gateway)this.Owner;
                p.SetDeviceInfo(gw_data, device_data, iDeviceIndex);
                p.RefreshGatewayConfig();
            }

            diTemp = null;

            this.Close();
        }

        private void btnLoadTag_Click(object sender, EventArgs e)
        {
            var frm = new frmLoadTagSetTemplate();
            frm.ShowDialog();

        }

        private void RefreshDeviceTagList()
        {

        }
    }
}
