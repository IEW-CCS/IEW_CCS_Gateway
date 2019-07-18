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
using Newtonsoft.Json;
using Ionic.Zip;
using System.Security.Cryptography;

namespace IEW.GatewayService.GUI
{
    public partial class frmEditAppVersion : Form
    {
        public string application_key;
        public VersionManager ver_mgr;

        public frmEditAppVersion()
        {
            InitializeComponent();
        }

        public frmEditAppVersion(VersionManager ver, string app_key)
        {
            InitializeComponent();
            this.application_key = app_key;
            this.ver_mgr = ver;
        }

        private void frmEditAppVersion_Load(object sender, EventArgs e)
        {
            txtAppType.Enabled = false;
            txtAppType.Text = this.application_key;

            lvVersionList.BeginUpdate();

            lvVersionList.Columns.Clear();
            lvVersionList.Columns.Add("Version", 80);
            lvVersionList.Columns.Add("Path/Name", 160);
            lvVersionList.Columns.Add("Update Time", 140);
            lvVersionList.Columns.Add("Description", 200);

            lvVersionList.Items.Clear();

            lvVersionList.EndUpdate();
            RefreshVersionList();
        }

        private void RefreshVersionList()
        {
            lvVersionList.Items.Clear();

            KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == this.application_key).FirstOrDefault();
            if(kv.Value != null)
            {
                if(kv.Value.Count > 0)
                {
                    lvVersionList.BeginUpdate();
                    foreach(cls_Version_Info ver in kv.Value)
                    {
                        ListViewItem lvItem = new ListViewItem(ver.ap_version);
                        lvItem.SubItems.Add(ver.ap_store_path_name);
                        lvItem.SubItems.Add(ver.update_time.ToString());
                        lvItem.SubItems.Add(ver.ap_description);
                        lvVersionList.Items.Add(lvItem);
                    }
                    lvVersionList.EndUpdate();
                }
            }
        }

        //Delegate function check duplicate version number
        bool CheckDuplicateVersion(string ver_no)
        {
            if(this.ver_mgr.version_list.ContainsKey(this.application_key))
            {
                KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == this.application_key).FirstOrDefault();
                cls_Version_Info ver = kv.Value.Where(o => o.ap_version == ver_no).FirstOrDefault();
                if(ver != null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

        }

        //Delegate function to setup application version information
        void SetVersionInfo(cls_Version_Info ver_info)
        {
            string strPrefix = "C:\\VersionControl";
            string strDestinationDir;
            string strDestinationName;
            string strDestinationMD5;
            string strMD5;

            strDestinationDir = get_destination_dir(ver_info);
            strDestinationName = ver_info.ap_version + ".zip";
            strDestinationMD5 = ver_info.ap_version + ".md5";

            //Compress Image files
            try
            {
                var zip = new ZipFile();
                zip.AddDirectory(ver_info.ap_upload_path_name);
                if(!Directory.Exists(strPrefix + strDestinationDir))
                {
                    Directory.CreateDirectory(strPrefix + strDestinationDir);
                }
                string tmp = strPrefix + strDestinationDir + strDestinationName;
                zip.Save(strPrefix + strDestinationDir + strDestinationName);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Zip file exception -> " + ex.Message, "Error");
                return;
            }

            //Add MD5 checksum file
            try
            {
                strMD5 = GetMD5HashFromFile(strPrefix + strDestinationDir + strDestinationName);
                //StreamWriter output = new StreamWriter(strDestinationDir + strDestinationMD5);
                //output.Write(strMD5);
                //output.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Create MD5 file exception -> " + ex.Message, "Error");
                return;
            }

            ver_info.ap_store_path_name = strDestinationDir + strDestinationName;
            //ver_info.md5_store_path_name = strDestinationDir + strDestinationMD5;
            ver_info.md5_string = strMD5;

            if (this.ver_mgr.version_list.ContainsKey(this.application_key))
            {
                KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == this.application_key).FirstOrDefault();
                kv.Value.Add(ver_info);
            }
            else
            {
                List<cls_Version_Info> tmpVer = new List<cls_Version_Info>();
                tmpVer.Add(ver_info);
                this.ver_mgr.version_list.TryAdd(this.application_key, tmpVer);
            }

            SaveVersionConfig();
        }

        private string get_destination_dir(cls_Version_Info ver)
        {
            string strDest;
            //strDest = "C:\\VersionControl\\" + ver.ap_type + "\\" + ver.ap_version + "\\";
            strDest = "\\" + ver.ap_type + "\\" + ver.ap_version + "\\";

            return strDest;
        }

        private void SaveVersionConfig()
        {
            string json_string;

            json_string = JsonConvert.SerializeObject(this.ver_mgr, Newtonsoft.Json.Formatting.Indented);
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\Version_Config.json");
            output.Write(json_string);
            output.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            frmEditVersionInfo frm = new frmEditVersionInfo(CheckDuplicateVersion, SetVersionInfo, this.application_key);
            frm.Owner = this;
            frm.ShowDialog();

            RefreshVersionList();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string strVersion;
            string strDestinationDir;

            if (lvVersionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the version number first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete this version?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvVersionList.Focus();
                return;
            }

            strVersion = lvVersionList.SelectedItems[0].Text; 

            if (this.ver_mgr.version_list.ContainsKey(this.application_key))
            {
                KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == this.application_key).FirstOrDefault();
                if(kv.Value != null)
                {
                    cls_Version_Info ver = kv.Value.Where(o => o.ap_version == strVersion).FirstOrDefault();
                    if(ver != null)
                    {
                        strDestinationDir = get_destination_dir(ver);
                        if(Directory.Exists(strDestinationDir))
                        {
                            Directory.Delete(strDestinationDir, true);
                        }
                        kv.Value.Remove(ver);
                    }
                    else
                    {
                        MessageBox.Show("Version number not found", "Error");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Version list not found", "Error");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Application not found", "Error");
                return;
            }

            SaveVersionConfig();
            RefreshVersionList();
        }

        public static string GetMD5HashFromFile(string fileName)
        {
            try
            {
                FileStream file = new FileStream(fileName, FileMode.Open);
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] retVal = md5.ComputeHash(file);
                file.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < retVal.Length; i++)
                {
                    sb.Append(retVal[i].ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("GetMD5HashFromFile() fail,error:" + ex.Message);
            }
        }
    }
}
