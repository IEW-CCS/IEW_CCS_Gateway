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

namespace IEW.GatewayService.GUI
{
    public partial class frmCalcExpression : Form
    {
        public frmCalcExpression()
        {
            InitializeComponent();
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
    }
}
