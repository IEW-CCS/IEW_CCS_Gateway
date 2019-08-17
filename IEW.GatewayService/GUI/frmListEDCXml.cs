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

namespace IEW.GatewayService.GUI
{
    public delegate void SetEDCManager(EDCManager edc_manager);

    public partial class frmListEDCXml : Form
    {
        public EDCManager edcm = new EDCManager();
        public GateWayManager gateway_mgr = new GateWayManager();
        public SetEDCManager delgEDCManager;

        public frmListEDCXml(SetEDCManager set_edc_mgrr, EDCManager edc_mgr, GateWayManager gwm)
        {
            InitializeComponent();
            this.delgEDCManager = set_edc_mgrr;
            //this.edcm = (EDCManager)edc_mgr.Clone();
            this.edcm = edc_mgr;
            this.gateway_mgr = (GateWayManager)gwm.Clone();
            this.edcm.eventAddEDCXml += new EventHandler(this.btnAddXml_Click);
        }

        private void frmListEDCXml_Load(object sender, EventArgs e)
        {
            lvEDCXmlList.BeginUpdate();

            lvEDCXmlList.Columns.Clear();
            lvEDCXmlList.Columns.Add("Serial ID", 100);
            lvEDCXmlList.Columns.Add("Gateway ID", 80);
            lvEDCXmlList.Columns.Add("Device ID", 80);
            lvEDCXmlList.Columns.Add("Report Type", 80);
            lvEDCXmlList.Columns.Add("Report Interval", 80);
            lvEDCXmlList.Columns.Add("Enabled", 60);
            lvEDCXmlList.Columns.Add("Tag Count", 80);
            lvEDCXmlList.Columns.Add("Calc.Tag Count", 80);
            lvEDCXmlList.Columns.Add("Report Path", 80);

            lvEDCXmlList.Items.Clear();

            lvEDCXmlList.EndUpdate();
            RefreshEDCXmlList();
        }

        private void RefreshEDCXmlList()
        {
            //Setup EDC XML List
            lvEDCXmlList.BeginUpdate();
            lvEDCXmlList.Items.Clear();
            if (this.edcm.gateway_edc.Count == 0)
            {
                lvEDCXmlList.EndUpdate();
                return;
            }

            foreach (cls_EDC_Info edc in edcm.gateway_edc)
            {
                ListViewItem lvItem = new ListViewItem(edc.serial_id);
                lvItem.SubItems.Add(edc.gateway_id);
                lvItem.SubItems.Add(edc.device_id);
                lvItem.SubItems.Add(edc.report_tpye);
                lvItem.SubItems.Add(edc.report_interval.ToString());
                if(edc.enable)
                {
                    lvItem.SubItems.Add("Y");
                }
                else
                {
                    lvItem.SubItems.Add("N");
                }
                lvItem.SubItems.Add(edc.tag_info.Count.ToString());
                lvItem.SubItems.Add(edc.calc_tag_info.Count.ToString());
                lvItem.SubItems.Add(edc.ReportEDCPath);

                lvEDCXmlList.Items.Add(lvItem);
            }
            lvEDCXmlList.EndUpdate();
        }

        //Delegate function to setup EDC XML Information
        void SetEDCXmlInfo(cls_EDC_Info edc_info, bool edit_flag)
        {
            if (edit_flag)
            {
                int i = 0;

                if (edcm.gateway_edc.Count > 0)
                {
                    foreach (cls_EDC_Info edc in edcm.gateway_edc)
                    {
                        if (edc.serial_id == edc_info.serial_id)
                        {
                            break;
                        }
                        i++;
                    }

                    edcm.gateway_edc[i] = edc_info;
                }
            }
            else
            {
                edcm.gateway_edc.Add(edc_info);
            }
        }

        //Delegate function to setup global serial id index
        void SetupSerialIDIndex(int index)
        {
            edcm.serial_id_index = index;
        }

        private void btnAddXml_Click(object sender, EventArgs e)
        {
            frmEditEDCXml frm = new frmEditEDCXml(SetEDCXmlInfo, SetupSerialIDIndex, this.gateway_mgr, this.edcm.serial_id_index);
            frm.Owner = this;
            frm.ShowDialog();

            delgEDCManager(edcm);
            RefreshEDCXmlList();
        }

        private void btnRemoveXml_Click(object sender, EventArgs e)
        {
            string strSerial;

            if (lvEDCXmlList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the EDC XML config first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the tag set?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvEDCXmlList.Focus();
                return;
            }

            strSerial = lvEDCXmlList.SelectedItems[0].Text;

            int i = 0;
            foreach (cls_EDC_Info edc in this.edcm.gateway_edc)
            {
                if (edc.serial_id == strSerial)
                {
                    this.edcm.gateway_edc.RemoveAt(i);
                    break;
                }
                i++;
            }

            delgEDCManager(edcm);
            RefreshEDCXmlList();
        }

        private void lvEDCXmlList_DoubleClick(object sender, EventArgs e)
        {
            string strSerial;
            string strGatewayID;
            string strDeviceID;
            cls_EDC_Info edcTemp = new cls_EDC_Info();

            if (lvEDCXmlList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the EDC XML config first!", "Error");
                return;
            }

            strSerial = lvEDCXmlList.SelectedItems[0].Text.Trim();
            strGatewayID = lvEDCXmlList.SelectedItems[0].SubItems[1].Text.Trim();
            strDeviceID = lvEDCXmlList.SelectedItems[0].SubItems[2].Text.Trim();

            int i = 0;
            foreach (cls_EDC_Info edc in this.edcm.gateway_edc)
            {
                if (edc.serial_id == strSerial)
                {
                    edcTemp = this.edcm.gateway_edc[i];
                    break;
                }
                i++;
            }

            frmEditEDCXml frm = new frmEditEDCXml(SetEDCXmlInfo, this.gateway_mgr, edcTemp, strGatewayID, strDeviceID, false);
            frm.Owner = this;
            frm.ShowDialog();

            edcTemp = null;

            delgEDCManager(edcm);
            RefreshEDCXmlList();
            lvEDCXmlList.Focus();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            this.edcm.eventAddEDCXml -= new EventHandler(this.btnAddXml_Click);

            base.Dispose(disposing);
        }

    }
}
