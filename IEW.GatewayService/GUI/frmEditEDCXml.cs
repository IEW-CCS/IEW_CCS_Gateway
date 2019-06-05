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
using System.Collections.Concurrent;

namespace IEW.GatewayService.GUI
{
    public delegate void SetEDCXmlInfo(cls_EDC_Info edc_info, bool edit_flag);

    public partial class frmEditEDCXml : Form
    {
        bool isEdit;
        public GateWayManager gateway_mgr;
        EDCHeaderSet edc_header_list;
        public SetEDCXmlInfo delgSetEDCXmlInfo;

        public frmEditEDCXml()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        public frmEditEDCXml(SetEDCXmlInfo set_xml, GateWayManager gwm, EDCHeaderSet header_list)
        {
            InitializeComponent();
            this.isEdit = false;
            this.gateway_mgr = gwm;
            this.edc_header_list = header_list;
            this.delgSetEDCXmlInfo = set_xml;
        }

        private void frmEditEDCXml_Load(object sender, EventArgs e)
        {
            cmbGateway.Items.Clear();
            if(this.gateway_mgr.gateway_list.Count > 0)
            {
                foreach(cls_Gateway_Info gi in this.gateway_mgr.gateway_list)
                {
                    cmbGateway.Items.Add(gi.gateway_id);
                }
            }

            cmbEDCHeaderSet.Items.Clear();
            if(this.edc_header_list.head_set_list.Count > 0)
            {
                foreach(cls_EDC_Header header in this.edc_header_list.head_set_list)
                {
                    cmbEDCHeaderSet.Items.Add(header.set_name);
                }
            }

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

            lvHeaderItemList.Columns.Clear();
            lvHeaderItemList.Columns.Add("Item Name", 80);
            lvHeaderItemList.Columns.Add("Value", 80);
            lvHeaderItemList.Columns.Add("Length", 80);

            if (isEdit)
            {
                txtSerial.Enabled = false;
                cmbGateway.Enabled = false;
                cmbDevice.Enabled = false;
            }
        }

        private void cmbGateway_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbGateway.Text.Trim() == "")
            {
                MessageBox.Show("Please select gateway id", "Error");
                return;
            }

            cls_Gateway_Info gi = this.gateway_mgr.gateway_list.Where(p => p.gateway_id == cmbGateway.Text.Trim()).FirstOrDefault();
            if(gi != null)
            {
                foreach (cls_Device_Info di in gi.device_info)
                {
                    cmbDevice.Items.Add(di.device_name);
                }
            }
            else
            {
                MessageBox.Show("Find gateway failed", "Error");
                return;
            }
        }

        private void cmbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDevice.Text.Trim() == "")
            {
                MessageBox.Show("Please select device id", "Error");
                return;
            }

            cls_Gateway_Info gi = this.gateway_mgr.gateway_list.Where(p => p.gateway_id == cmbGateway.Text.Trim()).FirstOrDefault();
            if (gi != null)
            {
                cls_Device_Info di = gi.device_info.Where(p => p.device_name == cmbDevice.Text.Trim()).FirstOrDefault();
                if(di != null)
                {
                    DisplayTagList(di);
                    DisplayCalcTagList(di);
                }
                else
                {
                    MessageBox.Show("Find device information failed", "Error");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Find gateway information failed", "Error");
                return;
            }
        }

        private void cmbEDCHeaderSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEDCHeaderSet.Text.Trim() == "")
            {
                MessageBox.Show("Please select EDC Header Set", "Error");
                return;
            }

            cls_EDC_Header header = this.edc_header_list.head_set_list.Where(p => p.set_name == cmbEDCHeaderSet.Text.Trim()).FirstOrDefault();
            if(header != null)
            {
                DisplayHeaderSetList(header);
            }
            else
            {
                MessageBox.Show("Find header set information failed", "Error");
                return;
            }

        }

        private void DisplayTagList(cls_Device_Info device)
        {
            lvTagList.BeginUpdate();
            foreach(KeyValuePair<string, cls_Tag> tag in device.tag_info)
            {
                ListViewItem item = new ListViewItem(tag.Value.TagName);
                item.SubItems.Add(tag.Value.Expression);
                item.SubItems.Add(tag.Value.UUID_Address);
                item.SubItems.Add(tag.Value.scale.ToString());
                item.SubItems.Add(tag.Value.offset.ToString());
                item.SubItems.Add(tag.Value.LastUpdateTime);
                lvTagList.Items.Add(item);
            }
            lvTagList.EndUpdate();
        }

        private void DisplayCalcTagList(cls_Device_Info device)
        {
            lvCalcTagList.BeginUpdate();
            foreach (KeyValuePair<string, cls_CalcTag> calc_tag in device.calc_tag_info)
            {
                ListViewItem item = new ListViewItem(calc_tag.Value.TagName);
                item.SubItems.Add(calc_tag.Value.ParamA);
                item.SubItems.Add(calc_tag.Value.ParamB);
                item.SubItems.Add(calc_tag.Value.ParamC);
                item.SubItems.Add(calc_tag.Value.ParamD);
                item.SubItems.Add(calc_tag.Value.ParamE);
                item.SubItems.Add(calc_tag.Value.ParamF);
                item.SubItems.Add(calc_tag.Value.ParamG);
                item.SubItems.Add(calc_tag.Value.ParamH);
                item.SubItems.Add(calc_tag.Value.Expression);
                lvCalcTagList.Items.Add(item);
            }
            lvCalcTagList.EndUpdate();
        }

        private void DisplayHeaderSetList(cls_EDC_Header header)
        {
            lvHeaderItemList.BeginUpdate();
            foreach(cls_EDC_Head_Item hi in header.head_set)
            {
                ListViewItem item = new ListViewItem(hi.head_name);
                item.SubItems.Add(hi.value);
                item.SubItems.Add(hi.length.ToString());
                lvHeaderItemList.Items.Add(item);
            }
            lvHeaderItemList.EndUpdate();
        }
    }
}
