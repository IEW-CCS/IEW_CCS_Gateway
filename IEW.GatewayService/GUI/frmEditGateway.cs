﻿using System;
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
    public partial class frmEditGateway : Form
    {
        public List<cls_Device_Info> device_list = new List<cls_Device_Info>();
        bool isEdit;
        cls_Gateway_Info gateway_Info;
        int iGatewayIndex;

        public frmEditGateway()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        public frmEditGateway(cls_Gateway_Info gw, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            this.gateway_Info = gw;
            this.device_list = gw.device_info;
            iGatewayIndex = index;
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
                txtGatewayID.Enabled = false;
                txtGatewayIP.Text = this.gateway_Info.gateway_ip;
                DisplayDeviceList();
            }
            else
            {
                txtGatewayID.Enabled = true;
            }
        }

        private void btnGWCancel_Click(object sender, EventArgs e)
        {
            Gateway lgateway = (Gateway)this.Owner;
            lgateway.RefreshGatewayConfig();
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
            if (device_list.Count > 0)
            {
                lvGWDevice.BeginUpdate();
                lvGWDevice.Items.Clear();
                foreach ( cls_Device_Info di in device_list )
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
            Gateway lgateway = (Gateway)this.Owner;
            cls_Gateway_Info giTemp = new cls_Gateway_Info();

            if ( txtGatewayID.Text.Trim() == "" )
                MessageBox.Show("Please enter the gateway id!", "Error");
            else
            {
                if(!this.isEdit)
                {
                    foreach (cls_Gateway_Info gi in lgateway.ObjectManager.GatewayManager.gateway_list)
                    {
                        if (gi.gateway_id.Trim() == txtGatewayID.Text.Trim())
                        {
                            MessageBox.Show("Gateway ID duplicated!", "Error");
                            return;
                        }
                    }
                }
            }

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

            if (lvGWDevice.Items.Count == 0)
            {
                MessageBox.Show("Please add at lease one device", "Error");
                return;
            }

            giTemp.gateway_id = txtGatewayID.Text.Trim();
            giTemp.gateway_ip = txtGatewayIP.Text.Trim();
            giTemp.device_info = this.device_list;
            if(!this.isEdit)
            {
                lgateway.ObjectManager.GatewayManager.gateway_list.Add(giTemp);
            }
            else
            {
                lgateway.ObjectManager.GatewayManager.gateway_list[iGatewayIndex] = giTemp;
                lgateway.RefreshGatewayConfig();
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

            if (MessageBox.Show("Are you sure to delete the gateway?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
            cls_Device_Info deviceTemp = new cls_Device_Info();

            if (lvGWDevice.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the device first!", "Error");
                return;
            }

            strDeviceID = lvGWDevice.SelectedItems[0].Text.Trim();

            int i = 0;
            foreach (cls_Device_Info di in this.gateway_Info.device_info)
            {
                if (di.device_name == strDeviceID)
                {
                    deviceTemp = this.gateway_Info.device_info[i];
                    break;
                }
                i++;
            }

            var frm = new frmEditDevice(deviceTemp, i);
            frm.Owner = this;
            frm.ShowDialog();

            deviceTemp = null;

            DisplayDeviceList();
            lvGWDevice.Focus();
        }
    }
}
