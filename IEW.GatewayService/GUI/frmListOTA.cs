using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEW.Platform.Kernel.Common;
using IEW.Platform.Kernel.Log;
using IEW.ObjectManager;
using Newtonsoft.Json;

namespace IEW.GatewayService.GUI
{
    public partial class frmListOTA : Form
    {
        static string[] AP_TYPE = { "IOT", "WORKER", "FIRMWARE" };
        const int PAGE_INDEX_IOT = 0;
        const int PAGE_INDEX_WORKER = 1;
        const int PAGE_INDEX_FIRMWARE = 2;

        public IEW.ObjectManager.ObjectManager obj_manager;
        public OTAManager ota_manager;
        public GateWayManager gw_manager;
        public VersionManager ver_mgr;
        public cls_Version_Info ver_info;

        public frmListOTA()
        {
            InitializeComponent();
        }

        public frmListOTA(IEW.ObjectManager.ObjectManager obj_mgr, GateWayManager gw_mgr, OTAManager ota_mgr)
        {
            InitializeComponent();
            this.obj_manager = obj_mgr;
            this.gw_manager = gw_mgr;
            this.ota_manager = ota_mgr;
            this.obj_manager.OTAAckEventHandler += new EventHandler(this.RefreshOTAAck);
        }

        private void frmListOTA_Load(object sender, EventArgs e)
        {
            if(LoadFTPConfig())
            {
                txtServerIP.Text = this.ota_manager.ftp_info.server_ip;
                txtServerPort.Text = this.ota_manager.ftp_info.server_port;
                txtUserID.Text = this.ota_manager.ftp_info.user_id;
                txtPassword.Text = this.ota_manager.ftp_info.password;
            }

            lvIOTList.BeginUpdate();
            lvIOTList.Columns.Clear();
            lvIOTList.Columns.Add("Gateway ID", 100);
            lvIOTList.Columns.Add("Location", 80);
            lvIOTList.Columns.Add("Current Version", 80);
            lvIOTList.Columns.Add("Virtual Flag", 60);
            lvIOTList.Columns.Add("Update Status", 80);
            lvIOTList.Columns.Add("Update Time", 140);
            lvIOTList.Columns.Add("Return Message", 140);
            lvIOTList.Items.Clear();
            lvIOTList.EndUpdate();

            lvWorkerList.BeginUpdate();
            lvWorkerList.Columns.Clear();
            lvWorkerList.Columns.Add("Gateway ID", 100);
            lvWorkerList.Columns.Add("Location", 80);
            lvWorkerList.Columns.Add("Current Version", 80);
            lvWorkerList.Columns.Add("Virtual Flag", 60);
            lvWorkerList.Columns.Add("Update Status", 80);
            lvWorkerList.Columns.Add("Update Time", 140);
            lvWorkerList.Columns.Add("Return Message", 140);
            lvWorkerList.Items.Clear();
            lvWorkerList.EndUpdate();

            lvFirmwareList.BeginUpdate();
            lvFirmwareList.Columns.Clear();
            lvFirmwareList.Columns.Add("Gateway ID", 100);
            lvFirmwareList.Columns.Add("Device ID", 100);
            lvFirmwareList.Columns.Add("Location", 80);
            lvFirmwareList.Columns.Add("Current Version", 80);
            lvFirmwareList.Columns.Add("Virtual Flag", 60);
            lvFirmwareList.Columns.Add("Update Status", 80);
            lvFirmwareList.Columns.Add("Update Time", 140);
            lvFirmwareList.Columns.Add("Return Message", 140);
            lvFirmwareList.Items.Clear();
            lvFirmwareList.EndUpdate();

            CheckForIllegalCrossThreadCalls = false;
            RefreshOTAList(PAGE_INDEX_IOT);
        }

        private void RefreshOTAAck(object sender, EventArgs e)
        {
            //MessageBox.Show("Receive OTA Ack Event!", "Information");
            SaveOTAConfig();
            RefreshOTAList(this.tabOTA.SelectedIndex);
        }

        private bool LoadFTPConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\FTP_Config.json"))
                {
                    this.ota_manager.ftp_info = new cls_FTP_Server();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\FTP_Config.json");

                string json_string = inputFile.ReadToEnd();

                this.ota_manager.ftp_info = JsonConvert.DeserializeObject<cls_FTP_Server>(json_string);

                if (this.ota_manager.ftp_info == null)
                {
                    MessageBox.Show("No FTP Configuration exists!", "Information");
                    return false;
                }

                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("FTP config file loading error! -> " + ex.Message, "Error");
                return false;
            }

            return true;
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
                if (kv.Value == null || kv.Value.Count == 0)
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

        private void SaveOTAConfig()
        {
            string json_string;

            json_string = JsonConvert.SerializeObject(this.ota_manager, Newtonsoft.Json.Formatting.Indented);
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\OTA_Config.json");
            output.Write(json_string);
            output.Close();
        }

        private void SaveFTPConfig()
        {
            string json_string;

            json_string = JsonConvert.SerializeObject(this.ota_manager.ftp_info, Newtonsoft.Json.Formatting.Indented);
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\FTP_Config.json");
            output.Write(json_string);
            output.Close();
        }

        private void RefreshOTAList(int page_index)
        {
            //MessageBox.Show("Refresh index: " + page_index.ToString(), "Information");
            switch(page_index)
            {
                case PAGE_INDEX_IOT:
                    DisplayIOTList();
                    break;

                case PAGE_INDEX_WORKER:
                    DisplayWorkerList();
                    break;

                case PAGE_INDEX_FIRMWARE:
                    DisplayFirmwareList();
                    break;

                default:
                    DisplayIOTList();
                    break;
            }
        }

        private void DisplayIOTList()
        {
            cmbIOTVersion.Items.Clear();
            if (LoadVersionInfo("IOT"))
            {
                KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == "IOT").FirstOrDefault();
                foreach (cls_Version_Info ver in kv.Value)
                {
                    cmbIOTVersion.Items.Add(ver.ap_version);
                }
            }

            if(this.gw_manager.gateway_list.Count > 0)
            {
                lvIOTList.BeginUpdate();
                lvIOTList.Items.Clear();
                List<cls_OTA_Gateway_Info> tmp_list = new List<cls_OTA_Gateway_Info>();

                foreach (cls_Gateway_Info gw in this.gw_manager.gateway_list)
                {
                    cls_OTA_Gateway_Info ota_gw = this.ota_manager.ota_iot_list.Where(p => p.gateway_id == gw.gateway_id).FirstOrDefault();
                    if(ota_gw == null)
                    {
                        ListViewItem lvItem = new ListViewItem(gw.gateway_id);
                        lvItem.SubItems.Add(gw.location);
                        lvItem.SubItems.Add(""); //Version
                        if (gw.virtual_flag)
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("N");
                        }
                        lvItem.SubItems.Add(""); //Status
                        lvItem.SubItems.Add(""); //Update Time
                        lvItem.SubItems.Add(""); //Return Message
                        lvIOTList.Items.Add(lvItem);

                        cls_OTA_Gateway_Info tmp = new cls_OTA_Gateway_Info();
                        tmp.gateway_id = gw.gateway_id;
                        tmp.ap_type = "IOT";
                        tmp_list.Add(tmp);
                    }
                    else
                    {
                        ListViewItem lvItem = new ListViewItem(gw.gateway_id);
                        lvItem.SubItems.Add(gw.location);
                        lvItem.SubItems.Add(ota_gw.ap_version); //Version
                        if (gw.virtual_flag)
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("N");
                        }
                        lvItem.SubItems.Add(ota_gw.update_status);
                        lvItem.SubItems.Add(ota_gw.last_update_time.ToString());
                        lvItem.SubItems.Add(ota_gw.status_message); //Return Message
                        lvIOTList.Items.Add(lvItem);
                    }
                }

                lvIOTList.EndUpdate();

                if(tmp_list.Count > 0)
                {
                    foreach(cls_OTA_Gateway_Info ogi in tmp_list)
                    {
                        this.ota_manager.ota_iot_list.Add(ogi);
                    }
                }
            }

            SaveOTAConfig();
        }

        private void DisplayWorkerList()
        {
            cmbWorkerVersion.Items.Clear();
            if (LoadVersionInfo("WORKER"))
            {
                KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == "WORKER").FirstOrDefault();
                foreach (cls_Version_Info ver in kv.Value)
                {
                    cmbWorkerVersion.Items.Add(ver.ap_version);
                }
            }

            if (this.gw_manager.gateway_list.Count > 0)
            {
                lvWorkerList.BeginUpdate();
                lvWorkerList.Items.Clear();
                List<cls_OTA_Gateway_Info> tmp_list = new List<cls_OTA_Gateway_Info>();

                foreach (cls_Gateway_Info gw in this.gw_manager.gateway_list)
                {
                    cls_OTA_Gateway_Info ota_gw = this.ota_manager.ota_worker_list.Where(p => p.gateway_id == gw.gateway_id).FirstOrDefault();
                    if (ota_gw == null)
                    {
                        ListViewItem lvItem = new ListViewItem(gw.gateway_id);
                        lvItem.SubItems.Add(gw.location);
                        lvItem.SubItems.Add(""); //Version
                        if (gw.virtual_flag)
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("N");
                        }

                        lvItem.SubItems.Add(""); //Status
                        lvItem.SubItems.Add(""); //Update Time
                        lvItem.SubItems.Add(""); //Return Message
                        lvWorkerList.Items.Add(lvItem);

                        cls_OTA_Gateway_Info tmp = new cls_OTA_Gateway_Info();
                        tmp.gateway_id = gw.gateway_id;
                        tmp.ap_type = "WORKER";
                        tmp_list.Add(tmp);
                    }
                    else
                    {
                        ListViewItem lvItem = new ListViewItem(gw.gateway_id);
                        lvItem.SubItems.Add(gw.location);
                        lvItem.SubItems.Add(ota_gw.ap_version); //Version
                        if (gw.virtual_flag)
                        {
                            lvItem.SubItems.Add("Y");
                        }
                        else
                        {
                            lvItem.SubItems.Add("N");
                        }
                        lvItem.SubItems.Add(ota_gw.update_status);
                        lvItem.SubItems.Add(ota_gw.last_update_time.ToString());
                        lvItem.SubItems.Add(ota_gw.status_message); //Return Message
                        lvWorkerList.Items.Add(lvItem);
                    }
                }

                lvWorkerList.EndUpdate();
                if (tmp_list.Count > 0)
                {
                    foreach (cls_OTA_Gateway_Info ogi in tmp_list)
                    {
                        this.ota_manager.ota_worker_list.Add(ogi);
                    }
                }
            }
        }

        private void DisplayFirmwareList()
        {
            cmbFirmwareVersion.Items.Clear();
            if (LoadVersionInfo("FIRMWARE"))
            {
                KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == "FIRMWARE").FirstOrDefault();
                foreach (cls_Version_Info ver in kv.Value)
                {
                    cmbFirmwareVersion.Items.Add(ver.ap_version);
                }
            }

            if (this.gw_manager.gateway_list.Count > 0)
            {
                lvFirmwareList.BeginUpdate();
                lvFirmwareList.Items.Clear();
                List<cls_OTA_Device_Info> tmp_list = new List<cls_OTA_Device_Info>();

                foreach (cls_Gateway_Info gw in this.gw_manager.gateway_list)
                {
                    foreach(cls_Device_Info dv in gw.device_info)
                    {
                        cls_OTA_Device_Info ota_dv = this.ota_manager.ota_firmware_list.Where(p => (p.gateway_id == gw.gateway_id) && (p.device_id == dv.device_name)).FirstOrDefault();
                        if (ota_dv == null)
                        {
                            ListViewItem lvItem = new ListViewItem(gw.gateway_id);
                            lvItem.SubItems.Add(dv.device_name);
                            lvItem.SubItems.Add(dv.device_location);
                            lvItem.SubItems.Add(""); //Version
                            if (gw.virtual_flag)
                            {
                                lvItem.SubItems.Add("Y");
                            }
                            else
                            {
                                lvItem.SubItems.Add("N");
                            }

                            lvItem.SubItems.Add(""); //Status
                            lvItem.SubItems.Add(""); //Update Time
                            lvItem.SubItems.Add(""); //Return Message
                            lvFirmwareList.Items.Add(lvItem);

                            cls_OTA_Device_Info tmp = new cls_OTA_Device_Info();
                            tmp.gateway_id = gw.gateway_id;
                            tmp.device_id = dv.device_name;
                            tmp.ap_type = "FIRMWARE";
                            tmp_list.Add(tmp);
                        }
                        else
                        {
                            ListViewItem lvItem = new ListViewItem(gw.gateway_id);
                            lvItem.SubItems.Add(dv.device_name);
                            lvItem.SubItems.Add(dv.device_location);
                            lvItem.SubItems.Add(ota_dv.ap_version); //Version
                            if (gw.virtual_flag)
                            {
                                lvItem.SubItems.Add("Y");
                            }
                            else
                            {
                                lvItem.SubItems.Add("N");
                            }
                            lvItem.SubItems.Add(ota_dv.update_status);
                            lvItem.SubItems.Add(ota_dv.last_update_time.ToString());
                            lvItem.SubItems.Add(ota_dv.status_message); //Return Message
                            lvFirmwareList.Items.Add(lvItem);
                        }
                    }
                }
                lvFirmwareList.EndUpdate();
                if (tmp_list.Count > 0)
                {
                    foreach (cls_OTA_Device_Info odi in tmp_list)
                    {
                        this.ota_manager.ota_firmware_list.Add(odi);
                    }
                }
            }
        }

        private bool VerifyFTPData()
        {
            int iValue;

            if (txtServerIP.Text.Trim() == "")
            {
                MessageBox.Show("Please input the FTP Server IP!", "Error");
                return false;
            }
            else
            {
                IPAddress ip;
                bool validate = IPAddress.TryParse(txtServerIP.Text.Trim(), out ip);
                if (!validate)
                {
                    MessageBox.Show("Please enter the  valid ip address!", "Error");
                    return false;
                }
            }

            if (txtServerPort.Text == "")
            {
                MessageBox.Show("Please enter the Port number!", "Error");
                return false;
            }
            else
            {
                if (!int.TryParse(txtServerPort.Text, out iValue))
                {
                    MessageBox.Show("Number only for Port number!", "Error");
                    return false;
                }
            }

            if (txtUserID.Text == "")
            {
                MessageBox.Show("Please enter the User ID!", "Error");
                return false;
            }

            if (txtPassword.Text == "")
            {
                MessageBox.Show("Please enter the Password!", "Error");
                return false;
            }

            return true;
        }

        private bool VerifyInputData(string ap_type)
        {
            if(ap_type == "IOT")
            {
                if (cmbIOTVersion.Text.Trim() == "")
                {
                    MessageBox.Show("Please select the new version first", "Error");
                    return false;
                }

                if(lvIOTList.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select the gateway first", "Error");
                    return false;
                }
            }
            else if(ap_type == "WORKER")
            {
                if (cmbWorkerVersion.Text.Trim() == "")
                {
                    MessageBox.Show("Please select the new version first", "Error");
                    return false;
                }

                if (lvWorkerList.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select the gateway first", "Error");
                    return false;
                }
            }
            else if(ap_type == "FIRMWARE")
            {
                if (cmbFirmwareVersion.Text.Trim() == "")
                {
                    MessageBox.Show("Please select the new version first", "Error");
                    return false;
                }

                if (lvFirmwareList.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select the device first", "Error");
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private void tabOTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshOTAList(tabOTA.SelectedIndex);
        }

        private void cmbIOTVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strVersion;
            strVersion = cmbIOTVersion.Text.Trim();

            KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == "IOT").FirstOrDefault();
            cls_Version_Info ver = kv.Value.Where(o => o.ap_version == strVersion).FirstOrDefault();
            this.ver_info = ver;
        }

        private void cmbWorkerVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strVersion;
            strVersion = cmbWorkerVersion.Text.Trim();

            KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == "WORKER").FirstOrDefault();
            cls_Version_Info ver = kv.Value.Where(o => o.ap_version == strVersion).FirstOrDefault();
            this.ver_info = ver;
        }

        private void cmbFirmwareVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strVersion;
            strVersion = cmbFirmwareVersion.Text.Trim();

            KeyValuePair<string, List<cls_Version_Info>> kv = this.ver_mgr.version_list.Where(p => p.Key == "FIRMWARE").FirstOrDefault();
            cls_Version_Info ver = kv.Value.Where(o => o.ap_version == strVersion).FirstOrDefault();
            this.ver_info = ver;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            cls_Cmd_OTA cmd_ota = new cls_Cmd_OTA();
            int ver_index;
            ListView lvList = null;
            string gw_id;
            string dv_id;

            if (VerifyFTPData())
            {
                this.ota_manager.ftp_info.server_ip = txtServerIP.Text.Trim();
                this.ota_manager.ftp_info.server_port = txtServerPort.Text.Trim();
                this.ota_manager.ftp_info.user_id = txtUserID.Text.Trim();
                this.ota_manager.ftp_info.password = txtPassword.Text.Trim();

                SaveFTPConfig();
            }
            else
            {
                return;
            }
            
            if(VerifyInputData(AP_TYPE[tabOTA.SelectedIndex]))
            {
                SaveOTAConfig();
            }
            else
            {
                return;
            }

            ver_index = 0;
            if (tabOTA.SelectedIndex == 0) //IOT Tab Page
            {
                lvList = lvIOTList;
                ver_index = 2;
            }
            else if(tabOTA.SelectedIndex == 1) //Worker Tab Page
            {
                lvList = lvWorkerList;
                ver_index = 2;
            }
            else if(tabOTA.SelectedIndex == 2) //Firmware Tab Page
            {
                lvList = lvFirmwareList;
                ver_index = 3;
            }

            if(lvList != null)
            {
                foreach (ListViewItem lvItem in lvList.CheckedItems)
                {
                    //MessageBox.Show(lvItem.SubItems[2].Text, "Information");
                    cmd_ota.Trace_ID = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    cmd_ota.FTP_Server = txtServerIP.Text.Trim();
                    cmd_ota.FTP_Port = txtServerPort.Text.Trim();
                    cmd_ota.User_name = txtUserID.Text.Trim();
                    cmd_ota.Password = txtPassword.Text.Trim();
                    cmd_ota.App_Name = AP_TYPE[tabOTA.SelectedIndex];
                    cmd_ota.Current_Version = lvItem.SubItems[ver_index].Text;
                    cmd_ota.New_Version = this.ver_info.ap_version;
                    //cmd_ota.Process_ID = 
                    cmd_ota.Image_Name = this.ver_info.ap_store_path_name;
                    cmd_ota.MD5_String = this.ver_info.md5_string;

                    string json_string = JsonConvert.SerializeObject(cmd_ota, Newtonsoft.Json.Formatting.Indented);
                    gw_id = lvItem.Text.Trim();
                    if(tabOTA.SelectedIndex == 0 || tabOTA.SelectedIndex == 1)
                    {
                        cls_Gateway_Info gw = this.gw_manager.gateway_list.Where(p => p.gateway_id == gw_id).FirstOrDefault();
                        dv_id = gw.device_info[0].device_name;

                        cls_OTA_Gateway_Info ogi = null;
                        if (tabOTA.SelectedIndex == 0)
                        {
                            ogi = this.ota_manager.ota_iot_list.Where(o => o.gateway_id == gw_id).FirstOrDefault();
                        }
                        else
                        {
                            ogi = this.ota_manager.ota_worker_list.Where(o => o.gateway_id == gw_id).FirstOrDefault();
                        }

                        if(ogi != null)
                        {
                            ogi.ap_new_version = this.ver_info.ap_version;
                            ogi.ap_new_store_path_name = this.ver_info.ap_store_path_name;
                            ogi.md5_new_string = this.ver_info.md5_string;
                            ogi.ap_description = this.ver_info.ap_description;
                        }
                    }
                    else
                    {
                        dv_id = lvItem.SubItems[1].Text.Trim();
                        cls_OTA_Device_Info odi = this.ota_manager.ota_firmware_list.Where(o => (o.gateway_id == gw_id) && (o.device_id == dv_id)).FirstOrDefault();
                        if(odi != null)
                        {
                            odi.ap_new_version = this.ver_info.ap_version;
                            odi.ap_new_store_path_name = this.ver_info.ap_store_path_name;
                            odi.md5_new_string = this.ver_info.md5_string;
                            odi.ap_description = this.ver_info.ap_description;
                        }
                    }

                    SaveOTAConfig();
                    IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "SendOTA", new object[] { gw_id, dv_id, json_string });
                    Thread.Sleep(500);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                this.obj_manager.OTAAckEventHandler -= new EventHandler(this.RefreshOTAAck);
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
