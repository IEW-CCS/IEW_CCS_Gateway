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
    public partial class frmEditTag : Form
    {
        bool isEdit;
        cls_Tag tag_data;


        public frmEditTag()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        public frmEditTag(cls_Tag tag)
        {
            InitializeComponent();
            this.isEdit = true;
            this.tag_data = tag;
        }

        private void frmEditTag_Load(object sender, EventArgs e)
        {
            cmbDataType.Items.Clear();
            cmbDataType.Items.Add("PLC");
            cmbDataType.Items.Add("BLE");

            cmbWordBit.Items.Clear();
            cmbWordBit.Items.Add("SINT");
            cmbWordBit.Items.Add("UINT");
            cmbWordBit.Items.Add("SLONG");
            cmbWordBit.Items.Add("ULONG");
            cmbWordBit.Items.Add("ASC");
            cmbWordBit.Items.Add("BIT");


            if (this.isEdit)
            {
                txtTagName.Enabled = false;
                txtTagName.Text = tag_data.TagName;
                cmbDataType.Text = tag_data.Type;
                txtScale.Text = tag_data.scale.ToString();
                txtOffset.Text = tag_data.offset.ToString();
                txtDescription.Text = tag_data.Description;

                if(tag_data.UUID_Address.Contains('.'))
                {
                    cmbWordBit.Text = "BIT";
                    txtLength.Text = "";
                    txtLength.Enabled = false;
                    string[] strArray = tag_data.Expression.Split(new Char[] { ':', '.'});
                    txtStartAddress.Text = strArray[0];
                    txtStartBit.Text = strArray[1];
                    txtEndBit.Text = strArray[2];
                }
                else
                {
                    cmbWordBit.Text = tag_data.Expression ;
                    string[] strArray = tag_data.Expression.Split(new Char[] { ':' });


                    if (cmbWordBit.Text == "ASC")
                    {
                        txtLength.Enabled = true;
                    }
                    else
                    {
                        txtLength.Enabled = false;
                    }


                }


            }
            else
            {
                txtTagName.Enabled = true;
            }
        }

        private void btnTagSave_Click(object sender, EventArgs e)
        {
            // this ccr testing hello
            //test by james
            // this is vic test
            // test again
        }

    }
}
