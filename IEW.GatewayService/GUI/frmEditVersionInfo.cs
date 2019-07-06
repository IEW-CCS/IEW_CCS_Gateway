using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEW.ObjectManager;


namespace IEW.GatewayService.GUI
{
    public delegate void SetVersion(cls_Version_Info ver_info);
    public delegate bool CheckVersion(string ver_no);

    public partial class frmEditVersionInfo : Form
    {
        public string application_key;
        public SetVersion delgSetVersion;
        public CheckVersion delgCheckVersion;

        public frmEditVersionInfo()
        {
            InitializeComponent();
        }

        public frmEditVersionInfo(CheckVersion chk_ver, SetVersion set_ver, string app_key)
        {
            InitializeComponent();
            this.application_key = app_key;
            this.delgCheckVersion = chk_ver;
            this.delgSetVersion = set_ver;
        }

        private void frmEditVersionInfo_Load(object sender, EventArgs e)
        {
            txtAppType.Enabled = false;
            txtAppType.Text = this.application_key;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog folderBrowser = new OpenFileDialog();
            folderBrowser.ValidateNames = false;
            folderBrowser.CheckFileExists = false;
            folderBrowser.CheckPathExists = true;
            folderBrowser.FileName = "Image";
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = Path.GetDirectoryName(folderBrowser.FileName) + "\\";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            cls_Version_Info tmpVer = new cls_Version_Info();

            if(txtVersion.Text.Trim() == "")
            {
                MessageBox.Show("Please input the version number!", "Error");
                return;
            }
            else
            {
                //Check if version number is duplicated or not
                if(!delgCheckVersion(txtVersion.Text.Trim()))
                {
                    MessageBox.Show("Version number is duplicate!", "Error");
                    return;
                }
            }

            if (txtPath.Text.Trim() == "")
            {
                MessageBox.Show("Please input the application image path!", "Error");
                return;
            }

            tmpVer.ap_type = this.application_key;
            tmpVer.ap_version = txtVersion.Text.Trim();
            tmpVer.ap_path_name = txtPath.Text.Trim();
            tmpVer.ap_description = txtDescription.Text.Trim();
            tmpVer.update_time = DateTime.Now;

            delgSetVersion(tmpVer);

            this.Close();
        }
    }
}
