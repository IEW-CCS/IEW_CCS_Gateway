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
    public delegate void SetHeaderSetInfo(cls_EDC_Header hs_info, bool edit_flag);
    public delegate bool CheckDuplicateHeaderSet(string hs_id);

    public partial class frmEditEDCHeader : Form
    {
        public bool isEdit;
        public cls_EDC_Header header_set_data;
        public List<cls_EDC_Head_Item> item_list = new List<cls_EDC_Head_Item>();
        public int header_set_index;

        public SetHeaderSetInfo delgSetHeaderSet;
        public CheckDuplicateHeaderSet delgCheckDuplicate;

        public frmEditEDCHeader()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        public frmEditEDCHeader(SetHeaderSetInfo set_hs, cls_EDC_Header header_set, int index)
        {
            InitializeComponent();
            this.isEdit = true;
            header_set_data = header_set;
            item_list = header_set.head_set;
            header_set_index = index;
            this.delgSetHeaderSet = set_hs;
        }


        public frmEditEDCHeader(SetHeaderSetInfo set_hs, CheckDuplicateHeaderSet check, bool edit_flag)
        {
            InitializeComponent();
            this.isEdit = edit_flag;
            this.delgSetHeaderSet = set_hs;
            this.delgCheckDuplicate = check;
            this.header_set_data = new cls_EDC_Header();
        }

        private void frmEditEDCHeader_Load(object sender, EventArgs e)
        {
            lvItemList.BeginUpdate();

            lvItemList.Columns.Clear();
            lvItemList.Columns.Add("Item Name", 100);
            lvItemList.Columns.Add("Value", 120);
            lvItemList.Columns.Add("Length", 60);

            if (isEdit)
            {
                txtEDCHeaderSetName.Text = this.header_set_data.set_name;
                txtEDCHeaderSetName.Enabled = false;
                txtDescription.Text = this.header_set_data.set_description;
                DisplayItemList();
            }

            lvItemList.EndUpdate();
        }

        private void DisplayItemList()
        {
            lvItemList.BeginUpdate();

            lvItemList.Items.Clear();

            if (this.header_set_data.head_set.Count > 0)
            {
                lvItemList.Items.Clear();
                foreach (cls_EDC_Head_Item item in this.header_set_data.head_set)
                {
                    ListViewItem lvItem = new ListViewItem(item.head_name);
                    lvItem.SubItems.Add(item.value);
                    lvItem.SubItems.Add(item.length.ToString());
                    lvItemList.Items.Add(lvItem);
                }
            }

            lvItemList.EndUpdate();
        }

        private bool ValidateInputData()
        {
            int iLength;

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the item name!", "Error");
                txtName.Focus();
                return false;
            }

            if (txtValue.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the item value!", "Error");
                txtValue.Focus();
                return false;
            }

            if (txtLength.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the item length!", "Error");
                txtLength.Focus();
                return false;
            }
            else
            {
                if (!int.TryParse(txtLength.Text.Trim(), out iLength))
                {
                    MessageBox.Show("Number only for the item length!", "Error");
                    txtLength.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            cls_EDC_Head_Item tmpItem = new cls_EDC_Head_Item();

            if(ValidateInputData())
            {
                foreach (cls_EDC_Head_Item item in this.item_list)
                {
                    if (txtName.Text.Trim() == item.head_name)
                    {
                        MessageBox.Show("Duplicate item name!", "Error");
                        txtName.Focus();
                        return;
                    }
                }

                tmpItem.head_name = txtName.Text.Trim();
                tmpItem.value = txtValue.Text.Trim();
                tmpItem.length = int.Parse(txtLength.Text.Trim());

                item_list.Add(tmpItem);
                this.header_set_data.head_set = item_list;
            }
            DisplayItemList();
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            string strItemName;

            if (lvItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the item first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the item?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvItemList.Focus();
                return;
            }

            strItemName = lvItemList.SelectedItems[0].Text;

            int i = 0;
            foreach (cls_EDC_Head_Item item in item_list)
            {
                if (item.head_name == strItemName)
                {
                    item_list.RemoveAt(i);
                    this.header_set_data.head_set = item_list;
                    break;
                }
                i++;
            }

            DisplayItemList();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            bool isFound;

            isFound = false;

            if(ValidateInputData())
            {
                int i = 0;
                foreach (cls_EDC_Head_Item item in item_list)
                {
                    if (item.head_name == txtName.Text.Trim())
                    {
                        isFound = true;
                        break;
                    }
                    i++;
                }

                if(isFound)
                {
                    item_list[i].value = txtValue.Text.Trim();
                    item_list[i].length = int.Parse(txtLength.Text.Trim());
                    this.header_set_data.head_set = item_list;
                }
                else
                {
                    MessageBox.Show("None of the item with the same name, please use the Add button!", "Error");
                    return;
                }
            }
            DisplayItemList();
        }

        private void btnTagCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTagSave_Click(object sender, EventArgs e)
        {
            cls_EDC_Header tmpHeaderSet = new cls_EDC_Header();


            if (txtEDCHeaderSetName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the EDC header set name!", "Error");
                return;
            }
            else
            {
                if (!this.isEdit)
                {
                    if (!this.delgCheckDuplicate(txtEDCHeaderSetName.Text.Trim()))
                    {
                        return;
                    }
                }
            }

            tmpHeaderSet.set_name= txtEDCHeaderSetName.Text.Trim();
            tmpHeaderSet.set_description= txtDescription.Text.Trim();
            tmpHeaderSet.head_set = item_list;
            /*
            if(this.header_set_data.head_set.Count > 0)
            {
                tmpHeaderSet.head_set = this.header_set_data.head_set;
            }
            */

            delgSetHeaderSet(tmpHeaderSet, this.isEdit);
            tmpHeaderSet = null;

            this.Close();
        }

        private void lvItemList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            txtName.Text = e.Item.SubItems[0].Text;
            txtValue.Text = e.Item.SubItems[1].Text;
            txtLength.Text = e.Item.SubItems[2].Text;
        }

    }
}
