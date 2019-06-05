using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalc;
using IEW.ObjectManager;

namespace IEW.GatewayService.GUI
{
    public partial class frmCalcExpression : Form
    {
        cls_CalcTag calc_tag_data = new cls_CalcTag();
        bool isEdit;

        public frmCalcExpression()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        public frmCalcExpression(cls_CalcTag calc_tag)
        {
            InitializeComponent();
            this.calc_tag_data = calc_tag;
            this.isEdit = true;
        }

        private void frmCalcExpression_Load(object sender, EventArgs e)
        {
            txtA.Enabled = false;
            txtB.Enabled = false;
            txtC.Enabled = false;
            txtD.Enabled = false;
            txtE.Enabled = false;
            txtF.Enabled = false;
            txtG.Enabled = false;
            txtH.Enabled = false;

            if (isEdit)
            {
                txtA.Text = calc_tag_data.ParamA;
                txtB.Text = calc_tag_data.ParamB;
                txtC.Text = calc_tag_data.ParamC;
                txtD.Text = calc_tag_data.ParamD;
                txtE.Text = calc_tag_data.ParamE;
                txtF.Text = calc_tag_data.ParamF;
                txtG.Text = calc_tag_data.ParamG;
                txtH.Text = calc_tag_data.ParamH;
                txtCalcExpression.Text = calc_tag_data.Expression;
            }
        }

        private void btnEvaluate_Click(object sender, EventArgs e)
        {
     
            //Expression exp = new Expression("Sin(0) + 3 * 5 + Pi");
            Expression exp = new Expression(txtCalcExpression.Text);
            
            //custom functions
            exp.EvaluateFunction += delegate (string name, FunctionArgs args)
            {
                if (name == "avg")
                    args.Result = (int)args.Parameters[0].Evaluate() + (int)args.Parameters[1].Evaluate();
            };

            //custom parameters
            exp.EvaluateParameter += delegate (string name, ParameterArgs args)
            {
                if (name == "Pi")
                    args.Result = 3.14;
                
            };

            try
            {
                txtAnswer.Text = exp.Evaluate().ToString();
            }
            catch(Exception ex) {
                txtAnswer.Text = ex.Message;
            }
            
        }

        private void cboMathmatical_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCalcExpression.Text = cboMathmatical.Text + txtCalcExpression.Text;

        }

        private void cboFunctions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCalcExpression.Text = cboFunctions.Text + txtCalcExpression.Text;
        }

        private void cboTrigonometry_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCalcExpression.Text = cboTrigonometry.Text + txtCalcExpression.Text;
        }

        private void cboAssignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCalcExpression.Text = cboAssignment.Text + txtCalcExpression.Text;
        }

        private void cboConstrant_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCalcExpression.Text = cboConstrant.Text + txtCalcExpression.Text;
        }

        private void cboBooleanLogic_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCalcExpression.Text = cboBooleanLogic.Text + txtCalcExpression.Text;
        }

        public string GetExpression()
        {
            return txtCalcExpression.Text;
        }

        public Dictionary<string, string> GetTagNameList()
        {
            Dictionary<string, string> name_list = new Dictionary<string, string>();
            if(txtA.Text.Trim() != "")
            {
                name_list.Add("A", txtA.Text.Trim());
            }

            if (txtB.Text.Trim() != "")
            {
                name_list.Add("B", txtB.Text.Trim());
            }

            if (txtC.Text.Trim() != "")
            {
                name_list.Add("C", txtC.Text.Trim());
            }

            if (txtD.Text.Trim() != "")
            {
                name_list.Add("D", txtD.Text.Trim());
            }

            if (txtE.Text.Trim() != "")
            {
                name_list.Add("E", txtE.Text.Trim());
            }

            if (txtF.Text.Trim() != "")
            {
                name_list.Add("F", txtF.Text.Trim());
            }

            if (txtG.Text.Trim() != "")
            {
                name_list.Add("G", txtG.Text.Trim());
            }

            if (txtH.Text.Trim() != "")
            {
                name_list.Add("H", txtH.Text.Trim());
            }

            return name_list;
        }

        public void SetNewTag(Dictionary<string, string> new_tag_list)
        {
            txtCalcExpression.Text = "";
            txtA.Text = "";
            txtB.Text = "";
            txtC.Text = "";
            txtD.Text = "";
            txtE.Text = "";
            txtF.Text = "";
            txtG.Text = "";
            txtH.Text = "";

            foreach(KeyValuePair<string, string> kvp in new_tag_list)
            {
                switch(kvp.Key)
                {
                    case "A":
                        txtA.Text = kvp.Value;
                        break;
                    case "B":
                        txtB.Text = kvp.Value;
                        break;

                    case "C":
                        txtC.Text = kvp.Value;
                        break;

                    case "D":
                        txtD.Text = kvp.Value;
                        break;

                    case "E":
                        txtE.Text = kvp.Value;
                        break;

                    case "F":
                        txtF.Text = kvp.Value;
                        break;

                    case "G":
                        txtG.Text = kvp.Value;
                        break;

                    case "H":
                        txtH.Text = kvp.Value;
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
