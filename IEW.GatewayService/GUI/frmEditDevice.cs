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
        bool isCopy = false;
        cls_Device_Info device_data;
        cls_Gateway_Info gw_data;
        ConcurrentDictionary<string, cls_Tag> taglist_data = new ConcurrentDictionary<string, cls_Tag>();
        ConcurrentDictionary<string, cls_CalcTag> calc_taglist_data = new ConcurrentDictionary<string, cls_CalcTag>();
        int iDeviceIndex;

        // Constructor called by frmEditGateway after clicked "+" button
        public frmEditDevice()
        {
            InitializeComponent();
            this.isEdit = false;
            this.isEmbedded = false;
        }

        // Constructor called by frmEditGateway after double clicked device list
        public frmEditDevice(cls_Device_Info device, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            this.isEmbedded = false;
            this.device_data = device;
            this.iDeviceIndex = index;
            this.taglist_data = device.tag_info;
            this.calc_taglist_data = device.calc_tag_info;
            if(this.device_data.device_name =="")
            {
                this.isCopy = true;
            }
            else
            {
                this.isCopy = false;
            }
        }

        //Constructor called by Gateway.cs after clicked device node
        public frmEditDevice(cls_Gateway_Info gw, cls_Device_Info device, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            this.isEmbedded = true;
            this.gw_data = gw;
            this.device_data = device;
            this.iDeviceIndex = index;
            this.taglist_data = device.tag_info;
            this.calc_taglist_data = device.calc_tag_info;
            if (this.device_data.device_name == "")
            {
                this.isCopy = true;
            }
            else
            {
                this.isCopy = false;
            }

        }

        private void frmEditDevice_Load(object sender, EventArgs e)
        {
            cmbType.Items.Clear();
            cmbType.Items.Add("PLC");
            cmbType.Items.Add("Temperature");
            cmbType.Items.Add("Vibration");
            //cmbType.Items.Add("BLE");

            lvTagList.Columns.Clear();
           
            lvTagList.Columns.Add("Tag Name", 80);
            lvTagList.Columns.Add("Data Type", 80);
            lvTagList.Columns.Add("Address", 120);
            lvTagList.Columns.Add("Scale", 80);
            lvTagList.Columns.Add("Offset", 80);
            lvTagList.Columns.Add("Update Time", 180);

            lvCalcTagList.Columns.Clear();
            lvCalcTagList.Columns.Add("Tag Name", 80);
            lvCalcTagList.Columns.Add("A", 60);
            lvCalcTagList.Columns.Add("B", 60);
            lvCalcTagList.Columns.Add("C", 60);
            lvCalcTagList.Columns.Add("D", 60);
            lvCalcTagList.Columns.Add("E", 60);
            lvCalcTagList.Columns.Add("F", 60);
            lvCalcTagList.Columns.Add("G", 60);
            lvCalcTagList.Columns.Add("H", 60);
            lvCalcTagList.Columns.Add("Expression", 180);

            if (this.isEdit)
            {
                txtDeviceID.Text = device_data.device_name;
                if(this.isCopy)
                {
                    txtDeviceID.Enabled = true;
                }
                else
                {
                    txtDeviceID.Enabled = false;
                }
                cmbType.Text = device_data.device_type;
                txtPLC_IP.Text = device_data.plc_ip_address;
                txtPLC_Port .Text= device_data.plc_port_id;
                txtBLE_Mac.Text = device_data.ble_mac;
                txtLocation.Text = device_data.device_location;
                //txtBLE_Service_UUID.Text = device_data.ble_service_uuid;
            }
            else
            {
                txtDeviceID.Enabled = true;
            }
            RefreshDeviceTagList();
            RefreshDeviceCalcTagList();
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
            else
            {
                pnlBLE.Enabled = false;
                txtBLE_Mac.Enabled = false;
                txtBLE_Service_UUID.Enabled = false;
                txtBLE_Mac.Text = "";
                txtBLE_Service_UUID.Text = "";
                pnlPLC.Enabled = false;
                txtPLC_IP.Text = "";
                txtPLC_Port.Text = "";
            }
        }

        private void btnDeviceCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeviceSave_Click(object sender, EventArgs e)
        {
            cls_Device_Info diTemp = new cls_Device_Info();
            bool duplicate_flag = false;

            if ( txtDeviceID.Text.Trim() == "" )
            {
                MessageBox.Show("Please enter Device ID!", "Error");
                return;
            }
            
            if(!this.isEdit)
            {
                duplicate_flag = (bool)IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "CheckDuplicateDeviceID", new object[] { txtDeviceID.Text.Trim() });
                if (duplicate_flag)
                {
                    MessageBox.Show("Device ID should be unique!!", "Error");
                    return;
                }
            }

            if(cmbType.Text.Trim() == "")
            {
                MessageBox.Show("Please select the device type!", "Error");
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

            diTemp.device_name = txtDeviceID.Text.Trim();
            diTemp.device_type = cmbType.Text.Trim();
            diTemp.device_location = txtLocation.Text.Trim();
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
          
            diTemp.tag_info = taglist_data;
            diTemp.calc_tag_info = calc_taglist_data;

            this.device_data = diTemp;

            if(!isEmbedded)
            {
                frmEditGateway pgw = (frmEditGateway)this.Owner;

                if (!isEdit)
                {
                    //pgw.device_list.Add(diTemp);
                    pgw.gateway_Info.device_info.Add(diTemp);
                }
                else
                {
                    //pgw.device_list[iDeviceIndex] = diTemp;
                    pgw.gateway_Info.device_info[iDeviceIndex] = diTemp;
                }
            }
            else
            {
                Gateway p = (Gateway)this.Owner;
                p.SetDeviceInfo(gw_data, device_data, iDeviceIndex, this.isCopy);
                p.RefreshGatewayConfig(0);
            }

            this.Close();
        }

        private void btnLoadTag_Click(object sender, EventArgs e)
        {
            var frm = new frmLoadTagSetTemplate(SetTagListFromTamplate, SetCalcTagListFromTamplate);
            frm.ShowDialog();
            RefreshDeviceTagList();
            RefreshDeviceCalcTagList();
        }

        private void RefreshDeviceTagList()
        {
            lvTagList.Items.Clear();

            if (this.taglist_data.Count > 0)
            {
                lvTagList.BeginUpdate();
                lvTagList.Items.Clear();

                foreach (KeyValuePair<string, cls_Tag> kvp in this.taglist_data)
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

        private void RefreshDeviceCalcTagList()
        {
            lvCalcTagList.Items.Clear();

            if (this.calc_taglist_data.Count > 0)
            {
                lvCalcTagList.BeginUpdate();
                lvCalcTagList.Items.Clear();

                foreach (KeyValuePair<string, cls_CalcTag> kvp in this.calc_taglist_data)
                {
                    ListViewItem lvItem = new ListViewItem(kvp.Value.TagName);
                    lvItem.SubItems.Add(kvp.Value.ParamA);
                    lvItem.SubItems.Add(kvp.Value.ParamB);
                    lvItem.SubItems.Add(kvp.Value.ParamC);
                    lvItem.SubItems.Add(kvp.Value.ParamD);
                    lvItem.SubItems.Add(kvp.Value.ParamE);
                    lvItem.SubItems.Add(kvp.Value.ParamF);
                    lvItem.SubItems.Add(kvp.Value.ParamG);
                    lvItem.SubItems.Add(kvp.Value.ParamH);
                    lvItem.SubItems.Add(kvp.Value.Expression);
                    lvCalcTagList.Items.Add(lvItem);
                }
                lvCalcTagList.EndUpdate();
            }
        }

        //Delegate function to recieve tag data from frmEditTag form
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

        //Delegate function to recieve calculation tag data from frmEditCalcTag form
        void SetCalcTagInformation(cls_CalcTag calc_tag, bool edit)
        {
            if (edit)
            {
                cls_CalcTag tmp = new cls_CalcTag();

                if (calc_taglist_data.TryGetValue(calc_tag.TagName, out tmp))
                {
                    if (!calc_taglist_data.TryUpdate(calc_tag.TagName, calc_tag, tmp))
                    {
                        MessageBox.Show("Calculation Tag Update failed!", "Error");
                        return;
                    }
                }
            }
            else
            {
                if (!calc_taglist_data.TryAdd(calc_tag.TagName, calc_tag))
                {
                    MessageBox.Show("Calculation Tag Add failed!", "Error");
                    return;
                }
            }
            //RefreshDeviceCalcTagList();
        }

        //Delegate function to check duplicated Tag ID
        bool CheckDuplicateTag(string tag_name, string type)
        {
            if (type == "TAG")
            {
                if (taglist_data.Count > 0)
                {
                    if (taglist_data.ContainsKey(tag_name))
                    {
                        MessageBox.Show("Duplicate Tag Name!", "Error");
                        return false;
                    }
                }
            }
            else if (type == "CALC_TAG")
            {
                if (calc_taglist_data.Count > 0)
                {
                    if (calc_taglist_data.ContainsKey(tag_name))
                    {
                        MessageBox.Show("Duplicate Calculation Tag Name!", "Error");
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Wrong type string to check duplicated tag name!", "Error");
                return false;
            }

            return true;
        }

        //Delegate function to receive tag data from frmLoadTagSetTemplate form
        void SetTagListFromTamplate(ConcurrentDictionary<string, cls_Tag> tag_list)
        {
            this.taglist_data = tag_list;
        }

        //Delegate function to receive calculation tag data from frmLoadTagSetTemplate form
        void SetCalcTagListFromTamplate(ConcurrentDictionary<string, cls_CalcTag> calc_tag_list)
        {
            this.calc_taglist_data = calc_tag_list;
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

        private void btnCalcTagAdd_Click(object sender, EventArgs e)
        {
            frmEditCalcTag frm = new frmEditCalcTag(SetCalcTagInformation, CheckDuplicateTag, this.taglist_data, false);
            frm.Owner = this;
            frm.ShowDialog();
            RefreshDeviceCalcTagList();
        }

        private void btnCalcTagRemove_Click(object sender, EventArgs e)
        {
            string strCalcTagName;
            cls_CalcTag tmp = new cls_CalcTag();

            if (lvCalcTagList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the calculation tag first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the calculation tag?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvTagList.Focus();
                return;
            }

            strCalcTagName = lvCalcTagList.SelectedItems[0].Text;

            if (!calc_taglist_data.TryRemove(strCalcTagName, out tmp))
            {
                MessageBox.Show("Calculation Tag Remove failed", "Error");
                return;
            }

            RefreshDeviceCalcTagList();
        }

        private void lvCalcTagList_DoubleClick(object sender, EventArgs e)
        {
            string strCalcTagName;
            cls_CalcTag calc_tag = new cls_CalcTag();

            if (lvCalcTagList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the calculation tag first!", "Error");
                return;
            }

            strCalcTagName = lvCalcTagList.SelectedItems[0].Text;
            if (!calc_taglist_data.TryGetValue(strCalcTagName, out calc_tag))
            {
                MessageBox.Show("Get tag[" + strCalcTagName + "] information error", "Error");
                return;
            }

            frmEditCalcTag frm = new frmEditCalcTag(SetCalcTagInformation, this.taglist_data, calc_tag);
            frm.Owner = this;
            frm.ShowDialog();
            RefreshDeviceCalcTagList();
        }

        private void lblDeviceType_Click(object sender, EventArgs e)
        {

        }
    }
}
