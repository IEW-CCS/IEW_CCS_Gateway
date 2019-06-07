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
    public delegate void SetCalcTag(cls_CalcTag tag, bool edit);
    public delegate bool CheckDuplicateCalcTag(string tag_name, string type);

    public partial class frmEditCalcTag : Form
    {
        bool isEdit;
        cls_CalcTag calc_tag_data;
        ConcurrentDictionary<string, cls_Tag> tag_list_data = new ConcurrentDictionary<string, cls_Tag>();
        public SetCalcTag delgSetCalcTag;
        public CheckDuplicateCalcTag delgCheckDuplicateCalc;
        public Dictionary<string, int> dicSequence = new Dictionary<string, int> { { "A", 1 }, { "B", 2 }, { "C", 3 }, { "D", 4 }, { "E", 5 }, { "F", 6 }, { "G", 7 }, { "H", 8 } };

        public frmEditCalcTag()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        //Constructor to Edit Calculation Tag
        public frmEditCalcTag(SetCalcTag set_calc_tag, ConcurrentDictionary<string, cls_Tag> tag_list, cls_CalcTag calc_tag)
        {
            InitializeComponent();
            this.isEdit = true;
            this.calc_tag_data = calc_tag;
            this.delgSetCalcTag = set_calc_tag;
            this.tag_list_data = tag_list;
        }

        //Constructor to Add New Calculation Tag
        public frmEditCalcTag(SetCalcTag set_calc_tag, CheckDuplicateCalcTag check_calc_tag, ConcurrentDictionary<string, cls_Tag> tag_list, bool edit)
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
            lvTagList.Columns.Add("Seq.", 50);
            lvTagList.Columns.Add("Tag Name", 80);
            lvTagList.Columns.Add("Type", 60);

            if(tag_list_data.Count > 0)
            {
                foreach(KeyValuePair<string, cls_Tag> tag in tag_list_data)
                {
                    if(tag.Value.Expression == "BIT" || tag.Value.Expression == "ASC")
                    {
                        //do not add to tag list
                    }
                    else
                    {
                        ListViewItem lvItem = new ListViewItem("");
                        lvItem.SubItems.Add(tag.Value.TagName);
                        lvItem.SubItems.Add(tag.Value.Expression);
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
                if(frmCalc.GetExpression() == "")
                {
                    MessageBox.Show("Calculation Expressiom must not be empty!", "Error");
                    return;
                }

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

        private void RefreshSequence(string sequence)
        {
            int index;
            KeyValuePair<string, int> kvp = dicSequence.Where(p => p.Key == sequence).FirstOrDefault();
            index = kvp.Value;

            lvTagList.BeginUpdate();

            foreach(ListViewItem item in lvTagList.Items)
            {
                if(item.Text.Trim() == "")
                {
                    continue;
                }

                if(item.Text == sequence)
                {
                    item.Text = "";
                    continue;
                }
                else
                {
                    KeyValuePair<string, int> tmp = dicSequence.Where(p => p.Key == item.Text.Trim()).FirstOrDefault();
                    if(tmp.Value > index)
                    {
                        KeyValuePair<string, int> pair = dicSequence.ElementAt(tmp.Value - 2);
                        item.Text = pair.Key;
                    }
                    continue;
                }
            }

            lvTagList.EndUpdate();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            frmCalcExpression frmCalc;
            Dictionary<string, string> dicTagList = new Dictionary<string, string>();
            foreach(ListViewItem item in lvTagList.Items)
            {
                if(item.Text.Trim() != "")
                {
                    dicTagList.Add(item.Text.Trim(), item.SubItems[1].Text.Trim());
                }
            }

            if(dicTagList.Count == 0)
            {
                MessageBox.Show("No tag seleced, please select again!", "Information");
                return;
            }

            if (pnlCalcExpression.Controls.Count > 0)
            {
                frmCalc = (frmCalcExpression)pnlCalcExpression.Controls[0];
                frmCalc.SetNewTag(dicTagList);
            }
        }

        private void lvTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = 0;
            if (lvTagList.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in lvTagList.Items)
                {
                    if (item.Text.Trim() != "")
                    {
                        count++;
                    }
                }

                if (lvTagList.SelectedItems[0].Text.Trim() == "" && count >= 8)
                {
                    MessageBox.Show("Selected Tags should be less than 8!", "Error");
                    return;
                }

                if (lvTagList.SelectedItems[0].Text.Trim() == "")
                {
                    lvTagList.SelectedItems[0].Text = GetNextSequence();
                }
                else
                {
                    RefreshSequence(lvTagList.SelectedItems[0].Text.Trim());
                }
            }
        }
    }
}
