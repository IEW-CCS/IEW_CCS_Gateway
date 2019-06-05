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
using IEW.GatewayService.UI;

namespace IEW.GatewayService.GUI
{
    public delegate void SetTagSetInfo(cls_Tag_Set ts_info, bool edit_flag);
    public delegate bool CheckDuplicateTagSet(string ts_id);

    public partial class frmEditTagSetTemplate : Form
    {
        public bool isEdit;
        public cls_Tag_Set tag_set_data;
        public List<cls_Tag> tag_list = new List<cls_Tag>();
        public List<cls_CalcTag> calc_tag_list = new List<cls_CalcTag>();
        public int tag_set_index;
        int tag_index;
        public SetTagSetInfo delgSetTagSet;
        public CheckDuplicateTagSet delgCheckDuplicate;

        // New Tag Set Constructor
        public frmEditTagSetTemplate()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        //Edit Tag Set Constructor
        public frmEditTagSetTemplate(cls_Tag_Set tag_set, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            this.tag_set_data = tag_set;
            this.tag_list = tag_set.tag_set;
            this.calc_tag_list = tag_set.calc_tag_set;
            this.tag_set_index = index;
        }

        public frmEditTagSetTemplate(SetTagSetInfo set_ts, cls_Tag_Set tag_set, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            this.tag_set_data = tag_set;
            this.tag_list = tag_set.tag_set;
            this.calc_tag_list = tag_set.calc_tag_set;
            this.tag_set_index = index;
            this.delgSetTagSet = set_ts;
        }

        public frmEditTagSetTemplate(SetTagSetInfo set_ts, CheckDuplicateTagSet check, bool edit_flag)
        {
            InitializeComponent();
            this.isEdit = edit_flag;
            this.delgSetTagSet = set_ts;
            this.delgCheckDuplicate = check;
        }

        //Delegate function to receive tag set data from frmEditTag form
        void SetTagInformation(cls_Tag tag, bool edit)
        {
            if(edit)
            {
                tag_list[tag_index] = tag;
                return;
            }
            else
            {
                tag_list.Add(tag);
                return;
            }
        }

        //Delegate function to check duplicated Tag/CalcTag ID from frmEditTag form
        bool CheckDuplicateTag(string tag_name, string type)
        {
            if(type == "TAG")
            {
                if (tag_list.Count > 0)
                {
                    cls_Tag tag = tag_list.Where(p => p.TagName == tag_name).FirstOrDefault();
                    if (tag != null)
                    {
                        MessageBox.Show("Duplicate Tag Name!", "Error");
                        return false;
                    }
                }
            }
            else if(type == "CALC_TAG")
            {
                if (calc_tag_list.Count > 0)
                {
                    cls_CalcTag calc_tag = calc_tag_list.Where(p => p.TagName == tag_name).FirstOrDefault();
                    if (calc_tag != null)
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

        private void frmEditTagSetTemplate_Load(object sender, EventArgs e)
        {
            lvTagList.Columns.Clear();
            lvTagList.Columns.Add("Tag Name", 80);
            lvTagList.Columns.Add("Data Type", 80);
            lvTagList.Columns.Add("Address", 120);
            lvTagList.Columns.Add("Scale", 80);
            lvTagList.Columns.Add("Offset", 80);
            lvTagList.Columns.Add("Update Time", 180);

            if (isEdit)
            {
                txtTagSetName.Text = this.tag_set_data.TagSetName;
                txtTagSetName.Enabled = false;
                txtTagSetDescription.Text = this.tag_set_data.TagSetDescription;
                DisplayTagList();
            }
        }

        private void btnTemplateCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTemplateSave_Click(object sender, EventArgs e)
        {
            cls_Tag_Set tmpTagSet = new cls_Tag_Set();

            if(txtTagSetName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the tag name!", "Error");
                return;
            }
            else
            {
                if(!this.isEdit)
                {
                    if (!this.delgCheckDuplicate(txtTagSetName.Text.Trim()))
                    {
                        return;
                    }
                }
            }

            tmpTagSet.TagSetName = txtTagSetName.Text.Trim();
            tmpTagSet.TagSetDescription = txtTagSetDescription.Text.Trim();
            tmpTagSet.tag_set = this.tag_list;

            delgSetTagSet(tmpTagSet, this.isEdit);
            tmpTagSet = null;

            this.Close();
        }

        private void btnTemplateAddTag_Click(object sender, EventArgs e)
        {
            frmEditTag frm = new frmEditTag(SetTagInformation, CheckDuplicateTag, false);
            frm.Owner = this;
            frm.ShowDialog();
            DisplayTagList();
        }

        private void DisplayTagList()
        {
            lvTagList.Items.Clear();

            if (this.tag_list.Count > 0)
            {
                lvTagList.BeginUpdate();
                lvTagList.Items.Clear();
                foreach (cls_Tag tag in tag_list)
                {
                    ListViewItem lvItem = new ListViewItem(tag.TagName);
                    lvItem.SubItems.Add(tag.Expression);
                    lvItem.SubItems.Add(tag.UUID_Address);
                    lvItem.SubItems.Add(tag.scale.ToString());
                    lvItem.SubItems.Add(tag.offset.ToString());
                    lvItem.SubItems.Add(tag.LastUpdateTime);
                    lvTagList.Items.Add(lvItem);
                }
                lvTagList.EndUpdate();
            }
        }

        private void btnTemplateRemoveTag_Click(object sender, EventArgs e)
        {
            string strTagName;

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

            int i = 0;
            foreach (cls_Tag tag in tag_list)
            {
                if (tag.TagName == strTagName)
                {
                    tag_list.RemoveAt(i);
                    break;
                }
                i++;
            }

            DisplayTagList();
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
            int i = 0;
            foreach(cls_Tag t in tag_list)
            {
                if(t.TagName == strTagName)
                {
                    tag = t;
                    break;
                }
                i++;
            }
            this.tag_index = i;

            frmEditTag frm = new frmEditTag(SetTagInformation, tag);
            frm.Owner = this;
            frm.ShowDialog();
            DisplayTagList();
        }

    }
}
