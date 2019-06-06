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
using System.IO;
using Newtonsoft.Json;

namespace IEW.GatewayService.GUI
{
    public delegate void SetEDCXmlInfo(cls_EDC_Info edc_info, bool edit_flag);

    public partial class frmEditEDCXml : Form
    {
        bool isEdit;
        EDCHeaderSet edc_header_list;
        int gateway_index;
        int device_index;
        string gateway_id;
        string device_id;

        public GateWayManager gateway_mgr;
        public cls_EDC_Info edc_data;
        public SetEDCXmlInfo delgSetEDCXmlInfo;


        public frmEditEDCXml()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        //Constructor to Add New EDC Xml Information
        public frmEditEDCXml(SetEDCXmlInfo set_xml, GateWayManager gwm)
        {
            InitializeComponent();
            this.isEdit = false;
            this.gateway_mgr = gwm; ;
            this.delgSetEDCXmlInfo = set_xml;
        }

        //Constructor to Edit EDC Xml Information
        public frmEditEDCXml(SetEDCXmlInfo set_xml, GateWayManager gwm,  cls_EDC_Info edc_info, string gateway, string device)
        {
            InitializeComponent();
            this.isEdit = true;
            this.gateway_mgr = gwm; ;
            this.edc_data = edc_info;
            this.gateway_id = gateway;
            this.device_id = device;
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


            lvTagList.Columns.Clear();
            lvTagList.Columns.Add("Tag Name", 80);
            lvTagList.Columns.Add("Data Type", 60);
            lvTagList.Columns.Add("Address", 80);
            lvTagList.Columns.Add("Scale", 40);
            lvTagList.Columns.Add("Offset", 40);
            lvTagList.Columns.Add("Update Time", 120);

            lvCalcTagList.Columns.Clear();
            lvCalcTagList.Columns.Add("Tag Name", 80);
            lvCalcTagList.Columns.Add("A", 50);
            lvCalcTagList.Columns.Add("B", 50);
            lvCalcTagList.Columns.Add("C", 50);
            lvCalcTagList.Columns.Add("D", 50);
            lvCalcTagList.Columns.Add("E", 50);
            lvCalcTagList.Columns.Add("F", 50);
            lvCalcTagList.Columns.Add("G", 50);
            lvCalcTagList.Columns.Add("H", 50);
            lvCalcTagList.Columns.Add("Expression", 180);

            lvHeaderItemList.Columns.Clear();
            lvHeaderItemList.Columns.Add("Item Name", 60);
            lvHeaderItemList.Columns.Add("Value", 60);
            lvHeaderItemList.Columns.Add("Length", 60);

            cmbEDCHeaderSet.Items.Clear();
            if (LoadHeaderSetConfig())
            {
                if (this.edc_header_list.head_set_list.Count > 0)
                {
                    cmbEDCHeaderSet.Items.Clear();
                    foreach (cls_EDC_Header header in this.edc_header_list.head_set_list)
                    {
                        cmbEDCHeaderSet.Items.Add(header.set_name);
                    }
                }
            }

            cmbReportType.Items.Clear();
            cmbReportType.Items.Add("trigger");
            //cmbReportType.Items.Add("interval");

            if (isEdit)
            {
                txtSerial.Enabled = false;
                cmbGateway.Enabled = false;
                cmbDevice.Enabled = false;

                txtSerial.Text = this.edc_data.serial_id;
                cmbGateway.Text = this.edc_data.gateway_id;
                cmbDevice.Text = this.edc_data.device_id;
                cmbReportType.Text = this.edc_data.report_tpye;
                //txtReportInterval.Text = edc_data.report_interval.ToString();
                txtReportPath.Text = this.edc_data.ReportEDCPath;
                if(this.edc_data.enable)
                {
                    chkEnable.Checked = true;
                }
                else
                {
                    chkEnable.Checked = false;
                }

                cls_Gateway_Info gi = this.gateway_mgr.gateway_list.Where(p => p.gateway_id == this.gateway_id).FirstOrDefault();
                if(gi != null)
                {
                    gateway_index = this.gateway_mgr.gateway_list.FindIndex(c => c.gateway_id == this.gateway_id);
                    cls_Device_Info di = gi.device_info.Where(a => a.device_name == this.device_id).FirstOrDefault();
                    if(di != null)
                    {
                        DisplayTagList(di);
                        DisplayCalcTagList(di);
                        device_index = gi.device_info.FindIndex(b => b.device_name == cmbDevice.Text.Trim());
                    }
                }
                if(edc_data.edchead_info.Count > 0)
                {
                    lvHeaderItemList.BeginUpdate();
                    lvHeaderItemList.Items.Clear();
                    foreach (cls_EDC_Head_Item hi in edc_data.edchead_info)
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
                cmbDevice.Items.Clear();
                foreach (cls_Device_Info di in gi.device_info)
                {
                    cmbDevice.Items.Add(di.device_name);
                }
                gateway_index = this.gateway_mgr.gateway_list.FindIndex(p => p.gateway_id == cmbGateway.Text.Trim());
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
                    device_index = gi.device_info.FindIndex(p => p.device_name == cmbDevice.Text.Trim());
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
            lvTagList.Items.Clear();
            foreach(KeyValuePair<string, cls_Tag> tag in device.tag_info)
            {
                ListViewItem item = new ListViewItem(tag.Value.TagName);
                item.SubItems.Add(tag.Value.Expression);
                item.SubItems.Add(tag.Value.UUID_Address);
                item.SubItems.Add(tag.Value.scale.ToString());
                item.SubItems.Add(tag.Value.offset.ToString());
                item.SubItems.Add(tag.Value.LastUpdateTime);
                if(tag.Value.report_flag == "Y")
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }

                lvTagList.Items.Add(item);
            }
            lvTagList.EndUpdate();
        }

        private void DisplayCalcTagList(cls_Device_Info device)
        {
            lvCalcTagList.BeginUpdate();
            lvCalcTagList.Items.Clear();
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
            lvHeaderItemList.Items.Clear();
            foreach (cls_EDC_Head_Item hi in header.head_set)
            {
                ListViewItem item = new ListViewItem(hi.head_name);
                item.SubItems.Add(hi.value);
                item.SubItems.Add(hi.length.ToString());
                lvHeaderItemList.Items.Add(item);
            }
            lvHeaderItemList.EndUpdate();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Fake Name";
            if(folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtReportPath.Text = Path.GetDirectoryName(folderBrowser.FileName);
            }
        }

        private void btnCancelEDCXml_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveEDCXml_Click(object sender, EventArgs e)
        {
            cls_EDC_Info tmpEDC = new cls_EDC_Info();
            List<Tuple<string, string>> tmp_tag_info = new List<Tuple<string, string>>();
            List<Tuple<string, string>> tmp_calc_tag_info = new List<Tuple<string, string>>();

            if (txtSerial.Text.Trim() == "")
            {
                MessageBox.Show("Please input the serial id!", "Error");
                return;
            }

            if(cmbGateway.Text.Trim() == "")
            {
                MessageBox.Show("Please select the gateway id!", "Error");
                return;
            }

            if(cmbDevice.Text.Trim() == "")
            {
                MessageBox.Show("Please select the device id!", "Error");
                return;
            }

            if(cmbReportType.Text.Trim() == "")
            {
                MessageBox.Show("Please select the report type!", "Error");
                return;
            }

            if(cmbReportType.Text.Trim() == "interval")
            {
                if(txtReportInterval.Text.Trim() == "")
                {
                    MessageBox.Show("Please input the report interval!", "Error");
                    return;
                }
                else
                {
                    int value;
                    if (!int.TryParse(txtReportInterval.Text.Trim(), out value))
                    {
                        MessageBox.Show("Report Interval is number only!", "Error");
                        return;
                    }
                    tmpEDC.report_interval = int.Parse(txtReportInterval.Text.Trim());
                }
            }

            if (txtReportPath.Text.Trim() == "")
            {
                MessageBox.Show("Please input the report path!", "Error");
                return;
            }

            if(!this.isEdit)
            {
                if (cmbEDCHeaderSet.Text.Trim() == "")
                {
                    MessageBox.Show("Please select the EDC Header set first!", "Error");
                    return;
                }
            }

            tmpEDC.serial_id = txtSerial.Text.Trim();
            tmpEDC.gateway_id = cmbGateway.Text.Trim();
            tmpEDC.device_id = cmbDevice.Text.Trim();
            tmpEDC.report_tpye = cmbReportType.Text.Trim();
            tmpEDC.ReportEDCPath = txtReportPath.Text.Trim();

            if(chkEnable.Checked)
            {
                tmpEDC.enable = true;
            }
            else
            {
                tmpEDC.enable = false;
            }

            if(this.isEdit)
            {
                tmpEDC.edchead_info = this.edc_data.edchead_info;
            }
            else
            {
                foreach (cls_EDC_Header h in this.edc_header_list.head_set_list)
                {
                    if (h.set_name == cmbEDCHeaderSet.Text.Trim())
                    {
                        tmpEDC.edchead_info = h.head_set;
                    }
                }
            }

            foreach (ListViewItem item in lvTagList.Items)
            {
                cls_Tag t = this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].tag_info[item.Text.Trim()];
                if(t != null)
                {
                    if(item.Checked)
                    {
                        this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].tag_info[item.Text.Trim()].report_flag = "Y";
                    }
                    else
                    {
                        this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].tag_info[item.Text.Trim()].report_flag = "N";
                    }
                }
            }
            
            foreach(KeyValuePair<string, cls_Tag> tag in this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].tag_info)
            {
                if(tag.Value.report_flag == "Y")
                {
                    tmp_tag_info.Add(Tuple.Create(tag.Key, tag.Key));
                }
            }

            foreach(KeyValuePair<string, cls_CalcTag> calc_tag in this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].calc_tag_info)
            {
                tmp_calc_tag_info.Add(Tuple.Create(calc_tag.Key, calc_tag.Key));
            }

            tmpEDC.tag_info = tmp_tag_info;
            tmpEDC.calc_tag_info = tmp_calc_tag_info;

            delgSetEDCXmlInfo(tmpEDC, this.isEdit);

            this.Close();
        }

        private bool LoadHeaderSetConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\EDC_Header_Set_Config.json"))
                {
                    //MessageBox.Show("No tag set config file exists! Please start to create tag set template.", "Information");
                    //ObjectManager.TagSetManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\EDC_Header_Set_Config.json");

                string json_string = inputFile.ReadToEnd();

                //ObjectManager.TagSetManager_Initial(json_string);
                this.edc_header_list = JsonConvert.DeserializeObject<EDCHeaderSet>(json_string);

                if (this.edc_header_list.head_set_list == null)
                {
                    MessageBox.Show("No EDC header set exists!", "Information");
                    return false;
                }

                inputFile.Close();
            }
            catch
            {
                MessageBox.Show("EDC Header Set config file loading error!", "Error");
                return false;
            }

            return true;
        }
    }
}
