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
    public delegate void SetTagSetManager(TagSetManager ts_manager);

    public partial class frmListTagSet : Form
    {
        public TagSetManager tsm = new TagSetManager();
        public SetTagSetManager delgTSManager;

        public frmListTagSet(SetTagSetManager set_tsm, TagSetManager ts)
        {
            InitializeComponent();
            this.tsm = ts;
            this.delgTSManager = set_tsm;
            this.tsm.eventAddTagSet += new EventHandler(this.btnAddTagSetTemplate_Click);
        }

        private void frmListTagSet_Load(object sender, EventArgs e)
        {
            lvTagSetList.BeginUpdate();

            lvTagSetList.Columns.Clear();
            lvTagSetList.Columns.Add("Tag Set Name", 100);
            lvTagSetList.Columns.Add("Tag Count", 80);
            lvTagSetList.Columns.Add("Calculation Tag Count", 80);
            lvTagSetList.Columns.Add("Tag Set Description", 200);

            lvTagSetList.Items.Clear();

            lvTagSetList.EndUpdate();
            RefreshTagSetList();
        }

        private void RefreshTagSetList()
        {
            //Setup Tag List
            lvTagSetList.BeginUpdate();
            lvTagSetList.Items.Clear();
            if (this.tsm.tag_set_list.Count == 0)
            {
                lvTagSetList.EndUpdate();
                return;
            }
            foreach (cls_Tag_Set ts in tsm.tag_set_list)
            {
                ListViewItem lvItem = new ListViewItem(ts.TagSetName);
                lvItem.SubItems.Add(ts.tag_set.Count().ToString());
                lvItem.SubItems.Add(ts.calc_tag_set.Count().ToString());
                lvItem.SubItems.Add(ts.TagSetDescription);
                lvTagSetList.Items.Add(lvItem);
            }
            lvTagSetList.EndUpdate();
        }

        //Delegate function to setup Tag Set Information
        void SetTagSetInfo(cls_Tag_Set ts_info, bool edit_flag)
        {
            if (edit_flag)
            {
                int i = 0;

                if (tsm.tag_set_list.Count > 0)
                {
                    foreach (cls_Tag_Set ts in tsm.tag_set_list)
                    {
                        if (ts.TagSetName == ts_info.TagSetName)
                        {
                            break;
                        }
                        i++;
                    }

                    tsm.tag_set_list[i] = ts_info;
                }
            }
            else
            {
                tsm.tag_set_list.Add(ts_info);
            }
        }

        //Delegate function to check tag set id is duplicate or not
        bool CheckDuplicateTagSet(string ts_name)
        {
            if (tsm.tag_set_list.Count > 0)
            {
                foreach (cls_Tag_Set ts in tsm.tag_set_list)
                {
                    if (ts.TagSetName == ts_name)
                    {
                        MessageBox.Show("Duplicate tag set id!", "Error");
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnAddTagSetTemplate_Click(object sender, EventArgs e)
        {
            frmEditTagSetTemplate frm = new frmEditTagSetTemplate(SetTagSetInfo, CheckDuplicateTagSet, false);
            frm.Owner = this;
            frm.ShowDialog();

            delgTSManager(tsm);
            RefreshTagSetList();
        }

        private void btnRemoveTagSetTemplate_Click(object sender, EventArgs e)
        {
            string strTagSetID;

            if (lvTagSetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the tag set first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the tag set?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvTagSetList.Focus();
                return;
            }

            strTagSetID = lvTagSetList.SelectedItems[0].Text;

            int i = 0;
            foreach (cls_Tag_Set ts in this.tsm.tag_set_list)
            {
                if (ts.TagSetName == strTagSetID)
                {
                    this.tsm.tag_set_list.RemoveAt(i);
                    break;
                }
                i++;
            }

            delgTSManager(tsm);
            RefreshTagSetList();
        }

        private void lvTagSetList_DoubleClick(object sender, EventArgs e)
        {
            string strTagSetID;
            cls_Tag_Set tsTemp = new cls_Tag_Set();

            if (lvTagSetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the tag set first!", "Error");
                return;
            }

            strTagSetID = lvTagSetList.SelectedItems[0].Text.Trim();

            int i = 0;
            foreach (cls_Tag_Set ts in this.tsm.tag_set_list)
            {
                if (ts.TagSetName == strTagSetID)
                {
                    tsTemp = this.tsm.tag_set_list[i];
                    break;
                }
                i++;
            }

            frmEditTagSetTemplate frm = new frmEditTagSetTemplate(SetTagSetInfo, tsTemp, i);
            frm.Owner = this;
            frm.ShowDialog();

            tsTemp = null;

            RefreshTagSetList();
            lvTagSetList.Focus();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            this.tsm.eventAddTagSet -= new EventHandler(this.btnAddTagSetTemplate_Click);

            base.Dispose(disposing);
        }

    }
}
