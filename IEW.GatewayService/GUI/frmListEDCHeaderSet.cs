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
    public delegate void SetEDCHeaderList(EDCHeaderSet edc_hs);
    public partial class frmListEDCHeaderSet : Form
    {
        public SetEDCHeaderList delgEDCHeaderSetList;
        public EDCHeaderSet hsList = new EDCHeaderSet();

        public frmListEDCHeaderSet(SetEDCHeaderList set_list, EDCHeaderSet hs)
        {
            InitializeComponent();
            this.hsList = hs;
            this.delgEDCHeaderSetList = set_list;
        }

        private void frmListEDCHeaderSet_Load(object sender, EventArgs e)
        {
            lvHeaderSetList.BeginUpdate();

            lvHeaderSetList.Columns.Clear();
            lvHeaderSetList.Columns.Add("Header Set Name", 100);
            lvHeaderSetList.Columns.Add("Item Count", 80);
            lvHeaderSetList.Columns.Add("Header Set Description", 200);

            lvHeaderSetList.Items.Clear();

            lvHeaderSetList.EndUpdate();
            RefreshHeaderSetList();
        }

        private void RefreshHeaderSetList()
        {
            lvHeaderSetList.BeginUpdate();

            lvHeaderSetList.Items.Clear();

            if (this.hsList.head_set_list.Count == 0)
            {
                lvHeaderSetList.EndUpdate();
                return;
            }

            foreach (cls_EDC_Header hs in this.hsList.head_set_list)
            {
                ListViewItem lvItem = new ListViewItem(hs.set_name);
                lvItem.SubItems.Add(hs.head_set.Count().ToString());
                lvItem.SubItems.Add(hs.set_description);
                lvHeaderSetList.Items.Add(lvItem);
            }

            lvHeaderSetList.EndUpdate();
        }

        //Delegate function to setup Header Set Information
        void SetHeaderSetInfo(cls_EDC_Header hs_info, bool edit_flag)
        {
            if (edit_flag)
            {
                int i = 0;

                if (this.hsList.head_set_list.Count > 0)
                {
                    foreach (cls_EDC_Header hs in this.hsList.head_set_list)
                    {
                        if (hs.set_name == hs_info.set_name)
                        {
                            break;
                        }
                        i++;
                    }

                    this.hsList.head_set_list[i] = hs_info;
                }
            }
            else
            {
                this.hsList.head_set_list.Add(hs_info);
            }
        }

        //Delegate function to check tag set id is duplicate or not
        bool CheckDuplicateHeaderSet(string hs_name)
        {
            if (this.hsList.head_set_list.Count > 0)
            {
                foreach (cls_EDC_Header hs in this.hsList.head_set_list)
                {
                    if (hs.set_name == hs_name)
                    {
                        MessageBox.Show("Duplicate header set id!", "Error");
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnAddHeaderSet_Click(object sender, EventArgs e)
        {
            frmEditEDCHeader frm = new frmEditEDCHeader(SetHeaderSetInfo, CheckDuplicateHeaderSet, false);
            frm.Owner = this;
            frm.ShowDialog();

            delgEDCHeaderSetList(this.hsList);
            RefreshHeaderSetList();
        }

        private void btnRemoveHeaderSet_Click(object sender, EventArgs e)
        {
            string strHeaderSetID;

            if (lvHeaderSetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the header set first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the header set?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvHeaderSetList.Focus();
                return;
            }

            strHeaderSetID = lvHeaderSetList.SelectedItems[0].Text;

            int i = 0;
            foreach (cls_EDC_Header hs in this.hsList.head_set_list)
            {
                if (hs.set_name == strHeaderSetID)
                {
                    this.hsList.head_set_list.RemoveAt(i);
                    break;
                }
                i++;
            }

            delgEDCHeaderSetList(this.hsList);
            RefreshHeaderSetList();
        }

        private void lvHeaderSetList_DoubleClick(object sender, EventArgs e)
        {
            string strHeaderSetID;
            cls_EDC_Header hsTemp = new cls_EDC_Header();

            if (lvHeaderSetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the header set first!", "Error");
                return;
            }

            strHeaderSetID = lvHeaderSetList.SelectedItems[0].Text.Trim();

            int i = 0;
            foreach (cls_EDC_Header hs in this.hsList.head_set_list)
            {
                if (hs.set_name== strHeaderSetID)
                {
                    hsTemp = this.hsList.head_set_list[i];
                    break;
                }
                i++;
            }

            frmEditEDCHeader frm = new frmEditEDCHeader(SetHeaderSetInfo, hsTemp, i);
            frm.Owner = this;
            frm.ShowDialog();

            hsTemp = null;

            RefreshHeaderSetList();
            lvHeaderSetList.Focus();
        }

    }
}
