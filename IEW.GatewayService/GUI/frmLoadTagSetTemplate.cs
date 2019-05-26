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
    public partial class frmLoadTagSetTemplate : Form
    {
        public frmLoadTagSetTemplate()
        {
            InitializeComponent();
        }

        private void btnTempCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
