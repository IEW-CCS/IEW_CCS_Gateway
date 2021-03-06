﻿using System;
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
    public delegate void SetTag(cls_Tag tag, bool edit);
    public delegate bool CheckDuplicateTag(string tag_name, string type);

    public partial class frmEditTag : Form
    {
        const int UINT_LENGTH = 1;
        const int SINT_LENGTH = 1;
        const int ULONG_LENGTH = 2;
        const int SLONG_LENGTH = 2;

        bool isEdit;
        cls_Tag tag_data;
        public SetTag delgSetTag;
        public CheckDuplicateTag delgCheckDuplicate;
        string[] ALLOWED_ADDRESS = { "B", "D", "M", "W", "Z" };

        public frmEditTag()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        public frmEditTag(SetTag set_tag, cls_Tag tag)
        {
            InitializeComponent();
            this.isEdit = true;
            this.tag_data = tag;
            this.delgSetTag = set_tag;
            //this.delgCheckDuplicate = check_tag;
        }

        public frmEditTag(SetTag set_tag, CheckDuplicateTag check_tag, bool edit)
        {
            InitializeComponent();
            this.isEdit = edit;
            this.delgSetTag = set_tag;
            this.delgCheckDuplicate = check_tag; 
        }

        private void frmEditTag_Load(object sender, EventArgs e)
        {
            cmbDataType.Items.Clear();
            cmbDataType.Items.Add("PLC");
            cmbDataType.Items.Add("BLE");
            cmbDataType.Items.Add("Virtual");

            cmbWordBit.Items.Clear();

            if (this.isEdit)
            {
                txtTagName.Text = tag_data.TagName;
                txtTagName.Enabled = false;
                cmbDataType.Text = tag_data.Type;
                txtScale.Text = tag_data.scale.ToString();
                txtOffset.Text = tag_data.offset.ToString();
                txtDescription.Text = tag_data.Description;
                if(tag_data.Type == "Virtual")
                {
                    txtStartAddress.Text = "";
                    txtStartAddress.Enabled = false;
                    txtStartBit.Text = "";
                    txtStartBit.Enabled = false;
                    txtEndBit.Text = "";
                    txtEndBit.Enabled = false;
                    txtLength.Text = "";
                    txtLength.Enabled = false;
                    txtScale.Text = "";
                    txtScale.Enabled = false;
                    txtOffset.Text = "";
                    txtOffset.Enabled = false;
                }
                else
                {
                    if (tag_data.UUID_Address.Contains('.'))
                    {
                        cmbWordBit.Text = "BIT";
                        txtLength.Text = "";
                        txtLength.Enabled = false;
                        gbLinearScale.Enabled = false;
                        txtScale.Text = "";
                        txtOffset.Text = "";
                        txtStartBit.Enabled = true;
                        txtEndBit.Enabled = true;

                        string[] strArray = tag_data.UUID_Address.Split(new Char[] { ':', '.' });
                        txtStartAddress.Text = strArray[0];
                        txtStartBit.Text = strArray[1];
                        txtEndBit.Text = strArray[2];
                    }
                    else
                    {
                        cmbWordBit.Text = tag_data.Expression;
                        string[] strArray = tag_data.UUID_Address.Split(new Char[] { ':' });
                        txtStartAddress.Text = strArray[0];
                        txtStartBit.Enabled = false;
                        txtEndBit.Enabled = false;

                        if (cmbWordBit.Text == "ASC")
                        {
                            gbLinearScale.Enabled = false;
                            txtScale.Text = "";
                            txtOffset.Text = "";
                            txtLength.Enabled = true;

                            int start = int.Parse(strArray[0].Substring(1));
                            int end = int.Parse(strArray[1].Substring(1));
                            int length = end - start;
                            txtLength.Text = length.ToString();
                        }
                        else
                        {
                            gbLinearScale.Enabled = true;
                            txtLength.Enabled = false;
                            txtLength.Text = "";
                        }
                    }
                }
            }
            else
            {
                gbLinearScale.Enabled = true;
                txtStartBit.Enabled = true;
                txtEndBit.Enabled = true;
                txtTagName.Enabled = true;
            }
        }

        private void cmbWordBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDataType.Text.Trim() == "Virtual")
            {
                if(cmbWordBit.Text.Trim() == "ASC" || cmbWordBit.Text.Trim() == "DATETIME")
                {
                    txtScale.Text = "";
                    txtScale.Enabled = false;
                    txtOffset.Text = "";
                    txtOffset.Enabled = false;
                }
                else
                {
                    gbLinearScale.Enabled = true;
                    txtScale.Text = "1";
                    txtScale.Enabled = true;
                    txtOffset.Text = "0";
                    txtOffset.Enabled = true;
                }
            }
            else
            {
                if (cmbWordBit.Text.Trim() == "BIT")
                {
                    gbLinearScale.Enabled = false;
                    txtScale.Text = "";
                    txtOffset.Text = "";
                    txtLength.Text = "";
                    txtLength.Enabled = false;
                    txtStartBit.Enabled = true;
                    txtEndBit.Enabled = true;
                }
                else if (cmbWordBit.Text.Trim() == "ASC")
                {
                    gbLinearScale.Enabled = false;
                    txtScale.Text = "";
                    txtOffset.Text = "";
                    txtLength.Enabled = true;
                    txtStartBit.Text = "";
                    txtEndBit.Text = "";
                    txtStartBit.Enabled = false;
                    txtEndBit.Enabled = false;
                }
                else
                {
                    gbLinearScale.Enabled = true;
                    txtLength.Text = "";
                    txtLength.Enabled = false;
                    txtStartBit.Text = "";
                    txtEndBit.Text = "";
                    txtStartBit.Enabled = false;
                    txtEndBit.Enabled = false;
                    txtScale.Text = "1";
                    txtOffset.Text = "0";
                }
            }
        }

        private string get_end_address(string start_address, int offset)
        {
            string end_address;
            int iValue;
            int start_index;
            int iDecimalength;

            if (start_address.Substring(0, 1) == "Z")
            {
                start_index = 2;
                iDecimalength = start_address.Trim().Length - 2;
            }
            else
            {
                start_index = 1;
                iDecimalength = start_address.Trim().Length - 1;
            }

            iValue = int.Parse(start_address.Trim().Substring(start_index)) + offset -1;

            end_address = start_address.Substring(0,start_index) + iValue.ToString("D" + iDecimalength.ToString());

            return end_address;
        }

        private void btnTagSave_Click(object sender, EventArgs e)
        {
            cls_Tag tmpTag = new cls_Tag();
            int iValue;
            string end_address;

            if (txtTagName.Text == "")
            {
                MessageBox.Show("Please enter Tag Name!", "Error");
                return;
            }
            else
            {
                if(!this.isEdit) //Check duplicated id
                {
                    if(!delgCheckDuplicate(txtTagName.Text.Trim(), "TAG"))
                    {
                        return;
                    }
                }
            }
            tmpTag.TagName = txtTagName.Text.Trim();

            if (cmbDataType.Text == "")
            {
                MessageBox.Show("Please select the data type!", "Error");
                return;
            }
            tmpTag.Type = cmbDataType.Text.Trim();

            if (cmbWordBit.Text == "")
            {
                MessageBox.Show("Please select the Word/Bit information!", "Error");
                return;
            }

            if(cmbDataType.Text.Trim() == "Virtual")
            {
                double dScale;
                double dOffset;
                if(cmbWordBit.Text.Trim() == "INT" || cmbWordBit.Text.Trim() == "DOUBLE")
                {
                    if (double.TryParse(txtScale.Text.Trim(), out dScale))
                    {
                        tmpTag.scale = dScale;
                    }
                    else
                    {
                        MessageBox.Show("Scale must be a double value", "Error");
                        return;
                    }

                    if (double.TryParse(txtOffset.Text.Trim(), out dOffset))
                    {
                        tmpTag.offset = dOffset;
                    }
                    else
                    {
                        MessageBox.Show("Offset must be a double value", "Error");
                        return;
                    }
                }
            }
            else
            {
                if (txtStartAddress.Text == "")
                {
                    MessageBox.Show("Please enter start address!", "Error");
                    return;
                }
                else
                {
                    // Check if the first character equals to 'B', 'D', 'M', 'W', "ZR"
                    if(ALLOWED_ADDRESS.Contains(txtStartAddress.Text.Trim().Substring(0, 1)))
                    {
                        if(txtStartAddress.Text.Trim().Substring(0, 1) == "Z")
                        {
                            if(txtStartAddress.Text.Trim().Substring(1, 1) != "R")
                            {
                                MessageBox.Show("The first character of Start Address should be B, D, M, W, ZR", "Error");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("The first character of Start Address should be B, D, M, W, ZR", "Error");
                        return;
                    }

                    int start_index;
                    if(txtStartAddress.Text.Trim().Substring(0, 1) == "Z")
                    {
                        start_index = 2;
                    }
                    else
                    {
                        start_index = 1;
                    }

                    if (!int.TryParse(txtStartAddress.Text.Trim().Substring(start_index), out iValue))
                    {
                        MessageBox.Show("Start Address format is wrong!", "Error");
                        return;
                    }
                }

                if (cmbWordBit.Text == "BIT")
                {
                    if (txtStartBit.Text == "")
                    {
                        MessageBox.Show("Please enter the start bit!", "Error");
                        return;
                    }
                    else
                    {
                        if (int.TryParse(txtStartBit.Text, out iValue))
                        {
                            if (iValue < 0 || iValue > 15)
                            {
                                MessageBox.Show("Please enter the correct start bit!", "Error");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Number only for Start Bit!", "Error");
                            return;
                        }
                    }

                    if (txtEndBit.Text == "")
                    {
                        MessageBox.Show("Please enter the end bit!", "Error");
                        return;
                    }
                    else
                    {
                        if (int.TryParse(txtEndBit.Text, out iValue))
                        {
                            if (iValue < 0 || iValue > 15)
                            {
                                MessageBox.Show("Please enter the correct end bit!", "Error");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Number only for End Bit!", "Error");
                            return;
                        }
                    }
                    tmpTag.UUID_Address = txtStartAddress.Text.Trim() + "." + txtStartBit.Text.Trim() + ":" + txtEndBit.Text.Trim();
                }
                else if (cmbWordBit.Text == "ASC")
                {
                    if (txtLength.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter the length", "Error");
                        return;
                    }

                    if (int.TryParse(txtLength.Text.Trim(), out iValue))
                    {
                        if (iValue <= 0)
                        {
                            MessageBox.Show("Length must > 1", "Error");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Number only for Length!", "Error");
                        return;
                    }
                    end_address = get_end_address(txtStartAddress.Text.Trim(), int.Parse(txtLength.Text.Trim()));
                    tmpTag.UUID_Address = txtStartAddress.Text.Trim() + ":" + end_address;
                }
                else
                {
                    switch (cmbWordBit.Text.Trim())
                    {
                        case "SINT":
                            end_address = get_end_address(txtStartAddress.Text.Trim(), SINT_LENGTH);
                            tmpTag.UUID_Address = txtStartAddress.Text.Trim() + ":" + end_address;
                            break;
                        case "UINT":
                            end_address = get_end_address(txtStartAddress.Text.Trim(), UINT_LENGTH);
                            tmpTag.UUID_Address = txtStartAddress.Text.Trim() + ":" + end_address;
                            break;
                        case "SLONG":
                            end_address = get_end_address(txtStartAddress.Text.Trim(), SLONG_LENGTH);
                            tmpTag.UUID_Address = txtStartAddress.Text.Trim() + ":" + end_address;
                            break;
                        case "ULONG":
                            end_address = get_end_address(txtStartAddress.Text.Trim(), ULONG_LENGTH);
                            tmpTag.UUID_Address = txtStartAddress.Text.Trim() + ":" + end_address;
                            break;

                        default:
                            break;
                    }

                    double dScale;
                    double dOffset;
                    if (double.TryParse(txtScale.Text.Trim(), out dScale))
                    {
                        tmpTag.scale = dScale;
                    }
                    else
                    {
                        MessageBox.Show("Scale must be a double value", "Error");
                        return;
                    }

                    if (double.TryParse(txtOffset.Text.Trim(), out dOffset))
                    {
                        tmpTag.offset = dOffset;
                    }
                    else
                    {
                        MessageBox.Show("Offset must be a double value", "Error");
                        return;
                    }
                }
            }

            tmpTag.Expression = cmbWordBit.Text.Trim();
            tmpTag.Description = txtDescription.Text.Trim();
            tmpTag.LastUpdateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            delgSetTag(tmpTag, this.isEdit);

            this.Close();
        }

        private void btnTagCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbDataType.Text.Trim() == "Virtual")
            {
                cmbWordBit.Items.Clear();
                cmbWordBit.Items.Add("INT");
                cmbWordBit.Items.Add("DOUBLE");
                cmbWordBit.Items.Add("ASC");
                cmbWordBit.Items.Add("DATETIME");

                txtStartAddress.Text = "";
                txtStartAddress.Enabled = false;
                txtStartBit.Text = "";
                txtStartBit.Enabled = false;
                txtEndBit.Text = "";
                txtEndBit.Enabled = false;
                txtLength.Text = "";
                txtLength.Enabled = false;
            }
            else
            {
                cmbWordBit.Items.Clear();
                cmbWordBit.Items.Add("SINT");
                cmbWordBit.Items.Add("UINT");
                cmbWordBit.Items.Add("SLONG");
                cmbWordBit.Items.Add("ULONG");
                cmbWordBit.Items.Add("ASC");
                cmbWordBit.Items.Add("BIT");
            }
        }
    }
}
