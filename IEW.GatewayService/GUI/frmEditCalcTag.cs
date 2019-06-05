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
    public delegate void SetCalcTag(cls_CalcTag tag, bool edit);
    public delegate bool CheckDuplicateCalcTag(string tag_name, string type);

    public partial class frmEditCalcTag : Form
    {
        bool isEdit;
        cls_CalcTag calc_tag_data;
        List<cls_Tag> tag_list_data = new List<cls_Tag>();
        public SetCalcTag delgSetCalcTag;
        public CheckDuplicateCalcTag delgCheckDuplicateCalc;
        public Dictionary<string, int> dicSequence = new Dictionary<string, int> { { "A", 1 }, { "B", 2 }, { "C", 3 }, { "D", 4 }, { "E", 5 }, { "F", 6 }, { "G", 7 }, { "H", 8 } };

        public frmEditCalcTag()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        public frmEditCalcTag(SetCalcTag set_calc_tag, List<cls_Tag> tag_list, cls_CalcTag calc_tag)
        {
            InitializeComponent();
            this.isEdit = true;
            this.calc_tag_data = calc_tag;
            this.delgSetCalcTag = set_calc_tag;
            this.tag_list_data = tag_list;
        }

        public frmEditCalcTag(SetCalcTag set_calc_tag, CheckDuplicateCalcTag check_calc_tag, List<cls_Tag> tag_list, bool edit)
        {

            InitializeComponent();
            this.isEdit = edit;
            this.delgSetCalcTag = set_calc_tag;
            this.delgCheckDuplicateCalc = check_calc_tag;
            this.tag_list_data = tag_list;
        }

        private void frmEditCalcTag_Load(object sender, EventArgs e)
        {
            lvTagList.Columns.Clear();
            lvTagList.Columns.Add("Seq.", 20);
            lvTagList.Columns.Add("Tag Name", 60);
            lvTagList.Columns.Add("Type", 60);

            if(tag_list_data.Count > 0)
            {
                foreach(cls_Tag tag in tag_list_data)
                {
                    if(tag.Expression == "BIT" || tag.Expression == "ASC")
                    {
                        //do not add to tag list
                    }
                    else
                    {
                        ListViewItem lvItem = new ListViewItem("");
                        lvItem.SubItems.Add(tag.TagName);
                        lvItem.SubItems.Add(tag.Expression);
                        lvTagList.Items.Add(lvItem);
                    }
                }
            }
            else
            {
                MessageBox.Show("No tag defined, please add normal tag information and try again!", "Error");
                this.Close();
            }

            if (this.isEdit)
            {
                txtCalcTagName.Text = calc_tag_data.TagName;
                txtCalcTagName.Enabled = false;
                txtDescription.Text = calc_tag_data.Description;

                frmCalcExpression frm = new frmCalcExpression(this.calc_tag_data);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                if (pnlCalcExpression.Controls.Count > 0)
                {
                    pnlCalcExpression.Controls.RemoveAt(0);
                }
                pnlCalcExpression.Controls.Add(frm);

                frm.Show();
            }
            else
            {
                frmCalcExpression frm = new frmCalcExpression();
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                if (pnlCalcExpression.Controls.Count > 0)
                {
                    pnlCalcExpression.Controls.RemoveAt(0);
                }
                pnlCalcExpression.Controls.Add(frm);

                frm.Show();

                txtCalcTagName.Enabled = true;
            }
        }

        private void btnCalcTagCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalcTagSave_Click(object sender, EventArgs e)
        {
            cls_CalcTag tmpCalcTag = new cls_CalcTag();
            frmCalcExpression frmCalc;
            Dictionary<string, string> tag_name_list = new Dictionary<string, string>();

            if (txtCalcTagName.Text == "")
            {
                MessageBox.Show("Please enter Calculation Tag Name!", "Error");
                return;
            }
            else
            {
                if (!this.isEdit) //Check duplicated id
                {
                    if (!delgCheckDuplicateCalc(txtCalcTagName.Text.Trim(), "CALC_TAG"))
                    {
                        return;
                    }
                }
            }

            tmpCalcTag.TagName = txtCalcTagName.Text.Trim();
            tmpCalcTag.Description = txtDescription.Text.Trim();

            if (pnlCalcExpression.Controls.Count > 0)
            {
                frmCalc = (frmCalcExpression)pnlCalcExpression.Controls[0];
                tmpCalcTag.Expression = frmCalc.GetExpression();
                tag_name_list = frmCalc.GetTagNameList();
                if(tag_name_list.Count > 0)
                {
                    foreach(KeyValuePair<string, string> kvp in tag_name_list)
                    {
                        switch(kvp.Key)
                        {
                            case "A":
                                tmpCalcTag.ParamA = kvp.Value;
                                break;

                            case "B":
                                tmpCalcTag.ParamB = kvp.Value;
                                break;

                            case "C":
                                tmpCalcTag.ParamC = kvp.Value;
                                break;

                            case "D":
                                tmpCalcTag.ParamD = kvp.Value;
                                break;

                            case "E":
                                tmpCalcTag.ParamE = kvp.Value;
                                break;

                            case "F":
                                tmpCalcTag.ParamF = kvp.Value;
                                break;

                            case "G":
                                tmpCalcTag.ParamG = kvp.Value;
                                break;

                            case "H":
                                tmpCalcTag.ParamH = kvp.Value;
                                break;

                            default:
                                break;
                        }
                    }
                }
            }

            tmpCalcTag.LastUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            delgSetCalcTag(tmpCalcTag, this.isEdit);

            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if(lvTagList.Items.Count > 0)
            {
                foreach(ListViewItem item in lvTagList.Items)
                {
                    item.Text = "";
                }
            }
        }

        private string GetNextSequence()
        {
            string strSequence;
            int index1, index2, i;

            index1 = 0;
            i = 0;
            foreach(ListViewItem item in lvTagList.Items)
            {
                if(item.Text.Trim() != "")
                {
                    KeyValuePair<string, int> kvp = dicSequence.Where(p => p.Key == item.Text.Trim()).FirstOrDefault();
                    index2 = kvp.Value;
                    if(index2 > index1)
                    {
                        index1 = index2;
                    }
                    i++;
                }
            }

            if(i > 0)
            {
                KeyValuePair<string, int> kvp = dicSequence.Where(p => p.Value == (index1 + 1)).FirstOrDefault();
                strSequence = kvp.Key;
            }
            else
            {
                strSequence = "A";
            }

            
            return strSequence;
        }

        private void lvTagList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(lvTagList.Items.Count > 0)
            {
                int count = 0;
                foreach(ListViewItem item in lvTagList.Items)
                {
                    if(item.Text.Trim() != "")
                    {
                        count++;
                    }
                }

                if(count >= 8)
                {
                    MessageBox.Show("Selected Tags should be less than 8!", "Error");
                    return;
                }
            }

            if(lvTagList.SelectedItems[0].Text.Trim() == "")
            {
                lvTagList.SelectedItems[0].Text = GetNextSequence();
            }

            
        }
    }
}
