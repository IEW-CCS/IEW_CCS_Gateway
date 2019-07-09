using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEW.ObjectManager;
using Newtonsoft.Json;

namespace IEW.GatewayService.GUI
{
    public delegate void SetOTA(List<cls_Cmd_OTA> ota_list);

    public partial class frmEditOTA : Form
    {
        public string application_type;
        public GateWayManager gw_manager;
        public cls_Version_Info ver_info = new cls_Version_Info();
        public VersionManager ver_mgr;
        public cls_Cmd_OTA cmd_ota;
        public OTAManager ota_manager;
        public SetOTA delgSetOTA;

        public frmEditOTA()
        {
            InitializeComponent();
        }

        public frmEditOTA(SetOTA set_ota, GateWayManager gw_mgr, OTAManager ota_mgr, string ap_type)
        {
            InitializeComponent();
            this.application_type = ap_type;
            this.gw_manager = gw_mgr;
            this.ota_manager = ota_mgr;
            this.cmd_ota = new cls_Cmd_OTA();
            this.delgSetOTA = set_ota;
        }

        private void frmEditOTA_Load(object sender, EventArgs e)
        {
            txtAppType.Text = this.application_type;
            txtAppType.Enabled = false;

            if(this.application_type == "IOT" || this.application_type == "WORKER")
            {
                lvList.BeginUpdate();
                lvList.Columns.Clear();
                lvList.Columns.Add("Gateway ID", 100);
                lvList.Columns.Add("Gateway IP", 80);
                lvList.Columns.Add("Current Version", 80);
                lvList.Columns.Add("Location", 80);
                lvList.Columns.Add("Virtual Flag", 80);
                lvList.Items.Clear();
                lvList.EndUpdate();
            }
            else
            {
                lvList.BeginUpdate();
                lvList.Columns.Clear();
                lvList.Columns.Add("Gateway ID", 100);
                lvList.Columns.Add("Gateway IP", 80);
                lvList.Columns.Add("Current Version", 80);
                lvList.Columns.Add("Virtual Flag", 80);
                lvList.Columns.Add("Device ID", 80);
                lvList.Columns.Add("Device Type", 80);
                lvList.Columns.Add("Location", 140);
                lvList.Items.Clear();
                lvList.EndUpdate();
            }
            
            if(LoadVersionInfo(this.application_type))
            {
                btnOK.Enabled = true;

                cmbVersion.Items.Clear();
                KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == this.application_type).FirstOrDefault();
                foreach (cls_Version_Info ver in kv.Value)
                {
                    cmbVersion.Items.Add(ver.ap_version);
                }

                RefreshList(this.application_type);
            }
            else
            {
                btnOK.Enabled = false;
            }
        }

        private void RefreshList(string ap_type)
        {
            if(ap_type == "IOT" || ap_type == "WORKER")
            {
                if(this.gw_manager.gateway_list.Count > 0)
                {
                    lvList.BeginUpdate();
                    lvList.Items.Clear();
                    foreach (cls_Gateway_Info gw in this.gw_manager.gateway_list)
                    {
                        ListViewItem lvItem = new ListViewItem(gw.gateway_id);
                        lvItem.SubItems.Add(gw.gateway_ip);
                        if(ap_type == "IOT")
                        {
                            if(this.ota_manager.ota_iot_list.Count >0)
                            {
                                cls_OTA_Gateway_Info tmp = this.ota_manager.ota_iot_list.Where(p => p.gateway_id == gw.gateway_id).FirstOrDefault();
                                if(tmp != null)
                                {
                                    if(tmp.ap_version != null)
                                    {
                                        lvItem.SubItems.Add(tmp.ap_version);
                                    }
                                    else
                                    {
                                        lvItem.SubItems.Add("");
                                    }
                                }
                            }
                        }
                        else if(ap_type == "WORKER")
                        {
                            if (this.ota_manager.ota_worker_list.Count > 0)
                            {
                                cls_OTA_Gateway_Info tmp = this.ota_manager.ota_worker_list.Where(p => p.gateway_id == gw.gateway_id).FirstOrDefault();
                                if (tmp != null)
                                {
                                    if (tmp.ap_version != null)
                                    {
                                        lvItem.SubItems.Add(tmp.ap_version);
                                    }
                                    else
                                    {
                                        lvItem.SubItems.Add("");
                                    }
                                }
                            }
                        }

                        lvItem.SubItems.Add(gw.location);
                        if(gw.virtual_flag)
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("N");
                        }
                        lvList.Items.Add(lvItem);
                    }

                    lvList.EndUpdate();
                }
            }
            else
            {
                if (this.gw_manager.gateway_list.Count > 0)
                {
                    lvList.BeginUpdate();
                    lvList.Items.Clear();
                    foreach (cls_Gateway_Info gw in this.gw_manager.gateway_list)
                    {
                        foreach(cls_Device_Info dv in gw.device_info)
                        {
                            ListViewItem lvItem = new ListViewItem(gw.gateway_id);
                            lvItem.SubItems.Add(gw.gateway_ip);
                            if (this.ota_manager.ota_firmware_list.Count > 0)
                            {
                                cls_OTA_Device_Info tmp = this.ota_manager.ota_firmware_list.Where(p => p.gateway_id == gw.gateway_id && p.device_id == dv.device_name).FirstOrDefault();
                                if (tmp != null)
                                {
                                    if (tmp.ap_version != null)
                                    {
                                        lvItem.SubItems.Add(tmp.ap_version);
                                    }
                                    else
                                    {
                                        lvItem.SubItems.Add("");
                                    }
                                }
                            }
                            lvItem.SubItems.Add(gw.location);
                            if (gw.virtual_flag)
                            {
                                lvItem.SubItems.Add("Y");
                            }
                            else
                            {
                                lvItem.SubItems.Add("N");
                            }
                            lvItem.SubItems.Add(dv.device_name);
                            lvItem.SubItems.Add(dv.device_type);
                            lvItem.SubItems.Add(dv.device_location);
                            lvList.Items.Add(lvItem);
                        }
                    }

                    lvList.EndUpdate();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            List<cls_Cmd_OTA> ota_list = new List<cls_Cmd_OTA>();
            string strCurVersion;

            if(cmbVersion.Text.Trim() == "")
            {
                MessageBox.Show("Please select the new version first!", "Error");
                return;
            }

            if(lvList.CheckedItems.Count <=0)
            {
                    MessageBox.Show("Please select the gateways first!", "Error");
                    return;
            }

            foreach(ListViewItem lvItem in lvList.CheckedItems)
            {
                strCurVersion = lvItem.SubItems[2].Text.Trim();
                this.cmd_ota.Current_Version = strCurVersion;
                ota_list.Add(this.cmd_ota);
            }

            delgSetOTA(ota_list);
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll.Checked)
            {
                if(lvList.Items.Count > 0)
                {
                    foreach(ListViewItem lvItem in lvList.Items)
                    {
                        lvItem.Checked = true;
                    }
                }
            }
        }

        private bool LoadVersionInfo(string ap_type)
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\Version_Config.json"))
                {
                    MessageBox.Show("No version information config file exists! \n Please go to Version Management function to create application version information", "Error");
                    return false;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\Version_Config.json");

                string json_string = inputFile.ReadToEnd();

                this.ver_mgr = JsonConvert.DeserializeObject<VersionManager>(json_string);

                if (this.ver_mgr.version_list == null)
                {
                    MessageBox.Show("No Version Configuration exists!", "Information");
                    inputFile.Close();
                    return false;
                }

                KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == ap_type).FirstOrDefault();
                if(kv.Value == null || kv.Value.Count == 0)
                {
                    MessageBox.Show("No " + ap_type + "Version Configuration exists!", "Information");
                    inputFile.Close();
                    return false;
                }

                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Version config file loading error! -> " + ex.Message, "Error");
                return false;
            }

            return true;
        }

        private void cmbVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strVersion;
            strVersion = cmbVersion.Text.Trim();

            KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == this.application_type).FirstOrDefault();
            cls_Version_Info ver = kv.Value.Where(o => o.ap_version == strVersion).FirstOrDefault();
            this.cmd_ota.App_Name = this.application_type;
            this.cmd_ota.Image_Name = ver.ap_store_path_name;
            this.cmd_ota.MD5_String = ver.md5_string;
            this.cmd_ota.New_Version = strVersion;
        }
    }
}
