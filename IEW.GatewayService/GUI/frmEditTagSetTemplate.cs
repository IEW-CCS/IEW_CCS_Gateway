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
    public partial class frmEditTagSetTemplate : Form
    {
        public bool isEdit;
        public cls_Tag_Set tag_set_data;
        public List<cls_Tag> tag_list = new List<cls_Tag>();
        public int tag_set_index;

        public frmEditTagSetTemplate()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        public frmEditTagSetTemplate(cls_Tag_Set tag_set, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            tag_set_data = tag_set;
            tag_list = tag_set.tag_set;
            tag_set_index = index;
        }

        private void frmEditTagSetTemplate_Load(object sender, EventArgs e)
        {
            lvTagList.Columns.Clear();
            lvTagList.Columns.Add("Tag Name", 80);
            lvTagList.Columns.Add("Data Type", 80);
            lvTagList.Columns.Add("Address", 80);
            lvTagList.Columns.Add("Scale", 80);
            lvTagList.Columns.Add("Offset", 80);
            lvTagList.Columns.Add("Update Time", 80);

            if (isEdit)
            {
                txtTagSetName.Enabled = false;
            }
        }

        private void btnTemplateCancel_Click(object sender, EventArgs e)
        {
            Gateway lgateway = (Gateway)this.Owner;
            lgateway.RefreshGatewayConfig();
            this.Close();
        }

        private void btnTemplateSave_Click(object sender, EventArgs e)
        {
            Gateway lgateway = (Gateway)this.Owner;
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
                    if(lgateway.ObjectManager.TagSetManager.tag_set_list.Count > 0)
                    {
                        foreach (cls_Tag_Set tag_set in lgateway.ObjectManager.TagSetManager.tag_set_list)
                        {
                            if (tag_set.TagSetName == txtTagSetName.Text.Trim())
                            {
                                MessageBox.Show("Gateway ID duplicated!", "Error");
                                return;
                            }
                        }
                    }
                }
            }

            tmpTagSet.TagSetName = txtTagSetName.Text.Trim();
            tmpTagSet.TagSetDescription = txtTagSetDescription.Text.Trim();
            tmpTagSet.tag_set = this.tag_list;
            if (!this.isEdit)
            {
                lgateway.ObjectManager.TagSetManager.tag_set_list.Add(tmpTagSet);
            }
            else
            {
                lgateway.ObjectManager.TagSetManager.tag_set_list[this.tag_set_index] = tmpTagSet;
                lgateway.RefreshGatewayConfig();
            }

            tmpTagSet = null;
            lgateway.RefreshGatewayConfig();
            this.Close();
        }

        private void btnTemplateAddTag_Click(object sender, EventArgs e)
        {
            frmEditTag frm = new frmEditTag();
            frm.Owner = this;
            frm.ShowDialog();
            DisplayTagList();
        }

        private void DisplayTagList()
        {
            if(this.tag_list.Count > 0)
            {
                lvTagList.BeginUpdate();
                foreach (cls_Tag tag in tag_list)
                {
                    ListViewItem lvItem = new ListViewItem(tag.TagName);
                    lvItem.SubItems.Add(tag.Expression);
                    lvItem.SubItems.Add(tag.UUID_Address);
                    lvItem.SubItems.Add(tag.scale.ToString());
                    lvItem.SubItems.Add(tag.offset.ToString());
                    lvItem.SubItems.Add(tag.LastUpdateTime);
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

            if (MessageBox.Show("Are you sure to delete the gateway?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
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
    }
}
