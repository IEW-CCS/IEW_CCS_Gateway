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
using System.Collections.Concurrent;

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
        int calc_tag_index;
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

        //Counstructor to Edit Tag Set Template
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

        //Counstructor to Add New Tag Set Template
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

        //Delegate function to receive tag set data from frmEditTag form
        void SetCalcTagInformation(cls_CalcTag calc_tag, bool edit)
        {
            if (edit)
            {
                this.calc_tag_list[calc_tag_index] = calc_tag;
                return;
            }
            else
            {
                this.calc_tag_list.Add(calc_tag);
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

            if (isEdit)
            {
                txtTagSetName.Text = this.tag_set_data.TagSetName;
                txtTagSetName.Enabled = false;
                txtTagSetDescription.Text = this.tag_set_data.TagSetDescription;
                DisplayTagList();
                DisplayCalcTagList();
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
            tmpTagSet.calc_tag_set = this.calc_tag_list;

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
                foreach (cls_Tag tag in this.tag_list)
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

        private void DisplayCalcTagList()
        {
            lvCalcTagList.Items.Clear();

            if (this.calc_tag_list.Count > 0)
            {
                lvCalcTagList.BeginUpdate();
                lvCalcTagList.Items.Clear();
                foreach (cls_CalcTag calc_tag in this.calc_tag_list)
                {
                    ListViewItem lvItem = new ListViewItem(calc_tag.TagName);
                    lvItem.SubItems.Add(calc_tag.ParamA);
                    lvItem.SubItems.Add(calc_tag.ParamB);
                    lvItem.SubItems.Add(calc_tag.ParamC);
                    lvItem.SubItems.Add(calc_tag.ParamD);
                    lvItem.SubItems.Add(calc_tag.ParamE);
                    lvItem.SubItems.Add(calc_tag.ParamF);
                    lvItem.SubItems.Add(calc_tag.ParamG);
                    lvItem.SubItems.Add(calc_tag.ParamH);
                    lvItem.SubItems.Add(calc_tag.Expression);
                    lvCalcTagList.Items.Add(lvItem);
                }
                lvCalcTagList.EndUpdate();
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

        private void btnTemplateAddCalcTag_Click(object sender, EventArgs e)
        {
            ConcurrentDictionary<string, cls_Tag> dicTag = new ConcurrentDictionary<string, cls_Tag>();
            foreach(cls_Tag tag in this.tag_list)
            {
                dicTag.TryAdd(tag.TagName, tag);
            }


            frmEditCalcTag frm = new frmEditCalcTag(SetCalcTagInformation, CheckDuplicateTag, dicTag, false);
            frm.Owner = this;
            frm.ShowDialog();
            DisplayCalcTagList();
        }

        private void btnTemplateRemoveCalcTag_Click(object sender, EventArgs e)
        {
            string strCalcTagName;

            if (lvCalcTagList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the calculation tag first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the calculation tag?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvCalcTagList.Focus();
                return;
            }

            strCalcTagName = lvCalcTagList.SelectedItems[0].Text;

            int i = 0;
            foreach (cls_CalcTag calc_tag in this.calc_tag_list)
            {
                if (calc_tag.TagName == strCalcTagName)
                {
                    this.calc_tag_list.RemoveAt(i);
                    break;
                }
                i++;
            }

            DisplayCalcTagList();
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
            foreach (cls_Tag t in tag_list)
            {
                if (t.TagName == strTagName)
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

        private void lvCalcTagList_DoubleClick(object sender, EventArgs e)
        {
            string strCalcTagName;
            ConcurrentDictionary<string, cls_Tag> dictTag = new ConcurrentDictionary<string, cls_Tag>();
            cls_CalcTag calc_tag = new cls_CalcTag();

            if (lvCalcTagList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the calculation tag first!", "Error");
                return;
            }

            foreach (cls_Tag tag in this.tag_list)
            {
                dictTag.TryAdd(tag.TagName, tag);
            }

            strCalcTagName = lvCalcTagList.SelectedItems[0].Text;
            int i = 0;
            foreach (cls_CalcTag t in this.calc_tag_list)
            {
                if (t.TagName == strCalcTagName)
                {
                    calc_tag = t;
                    break;
                }
                i++;
            }
            this.calc_tag_index = i;

            frmEditCalcTag frm = new frmEditCalcTag(SetCalcTagInformation, dictTag, calc_tag);
            frm.Owner = this;
            frm.ShowDialog();
            DisplayCalcTagList();
        }
    }
}
