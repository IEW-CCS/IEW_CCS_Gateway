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
            this.taglist_data = device.tag_info;
        }

        public frmEditDevice(cls_Gateway_Info gw, cls_Device_Info device, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            this.isEmbedded = true;
            this.gw_data = gw;
            this.device_data = device;
            this.iDeviceIndex = index;
            this.taglist_data = device.tag_info;
        }

        private void frmEditDevice_Load(object sender, EventArgs e)
        {
            cmbType.Items.Clear();
            cmbType.Items.Add("PLC");
            //cmbType.Items.Add("BLE");

            lvTagList.Columns.Clear();
            lvTagList.Columns.Add("Tag Name", 80);
            lvTagList.Columns.Add("Data Type", 80);
            lvTagList.Columns.Add("Address", 120);
            lvTagList.Columns.Add("Scale", 80);
            lvTagList.Columns.Add("Offset", 80);
            lvTagList.Columns.Add("Update Time", 180);

            if (this.isEdit)
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
            RefreshDeviceTagList();
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
                //foreach(ListViewItem item in lvTagList.Items)
                //{
                  diTemp.tag_info = taglist_data;
                //}
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
            var frm = new frmLoadTagSetTemplate(SetTagListFromTamplate);
            frm.ShowDialog();
            RefreshDeviceTagList();
        }

        private void RefreshDeviceTagList()
        {
            lvTagList.Items.Clear();

            if (this.taglist_data.Count > 0)
            {
                lvTagList.BeginUpdate();
                lvTagList.Items.Clear();

                foreach (KeyValuePair<string, cls_Tag> kvp in taglist_data)
                {
                    ListViewItem lvItem = new ListViewItem(kvp.Value.TagName);
                    lvItem.SubItems.Add(kvp.Value.Expression);
                    lvItem.SubItems.Add(kvp.Value.UUID_Address);
                    lvItem.SubItems.Add(kvp.Value.scale.ToString());
                    lvItem.SubItems.Add(kvp.Value.offset.ToString());
                    lvItem.SubItems.Add(kvp.Value.LastUpdateTime);
                    lvTagList.Items.Add(lvItem);
                }
                lvTagList.EndUpdate();
            }
        }

        void SetTagInformation(cls_Tag tag, bool edit)
        {
            if (edit)
            {
                cls_Tag tmp = new cls_Tag();

                if(taglist_data.TryGetValue(tag.TagName, out tmp))
                {
                    if(!taglist_data.TryUpdate(tag.TagName, tag, tmp))
                    {
                        MessageBox.Show("Tag Update failed!", "Error");
                        return;
                    }
                }
            }
            else
            {
                if(!taglist_data.TryAdd(tag.TagName, tag))
                {
                    MessageBox.Show("Tag Add failed!", "Error");
                    return;
                }
            }
        }

        bool CheckDuplicateTag(string tag_name)
        {
            if (taglist_data.Count > 0)
            {
                if(taglist_data.ContainsKey(tag_name))
                {
                    MessageBox.Show("Duplicate Tag Name!", "Error");
                    return false;
                }
            }

            return true;
        }

        void SetTagListFromTamplate(ConcurrentDictionary<string, cls_Tag> tag_list)
        {
            this.taglist_data = tag_list;
        }

        private void btnTagAdd_Click(object sender, EventArgs e)
        {
            frmEditTag frm = new frmEditTag(SetTagInformation, CheckDuplicateTag, false);
            frm.Owner = this;
            frm.ShowDialog();
            RefreshDeviceTagList();
        }

        private void btnTagRemove_Click(object sender, EventArgs e)
        {
            string strTagName;
            cls_Tag tmp = new cls_Tag();

            if (lvTagList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the tag first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the tag?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvTagList.Focus();
                return;
            }

            strTagName = lvTagList.SelectedItems[0].Text;

            if(!taglist_data.TryRemove(strTagName, out tmp))
            {
                MessageBox.Show("Tag Remove failed", "Error");
                return;
            }

            RefreshDeviceTagList();
        }

        private void lvTagList_DoubleClick(object sender, EventArgs e)
        {
            string strTagName;
            cls_Tag tag = new cls_Tag();

            if (lvTagList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the tag first!", "Error");
                return;
            }

            strTagName = lvTagList.SelectedItems[0].Text;
            if (!taglist_data.TryGetValue(strTagName, out tag))
            {
                MessageBox.Show("Get tag[" + strTagName + "] information error", "Error");
                return;
            }

            frmEditTag frm = new frmEditTag(SetTagInformation, tag);
            frm.Owner = this;
            frm.ShowDialog();
            RefreshDeviceTagList();
        }
    }
}
