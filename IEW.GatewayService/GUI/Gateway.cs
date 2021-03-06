﻿using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEW.Platform.Kernel.Common;
using IEW.Platform.Kernel.Log;
using IEW.ObjectManager;
using IEW.GatewayService.GUI;
using IEW.ObjectManager.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace IEW.GatewayService.UI
{
    public partial class Gateway : Form
    {
        private IEW.ObjectManager.ObjectManager _ObjectManager;
        
        public IEW.ObjectManager.ObjectManager ObjectManager
        {
            get
            {
                return this._ObjectManager;
            }
            set
            {
                this._ObjectManager = value;
            }
        }

        private IOT_DbContext _db;
        public IOT_DbContext db
        {
            get
            {
                return this._db;
            }
            set
            {
                this._db = value;
            }
        }

        static int NODE_INDEX_GATEWAY_LIST = 0;
        static int NODE_INDEX_TAG_SET_LIST = 1;
        static int NODE_INDEX_EDC_HEADER_SET_LIST = 2;
        static int NODE_INDEX_EDC_OUTPUT_LIST = 3;
        static int NODE_INDEX_DB_CONFIG = 4;
        static int NODE_INDEX_ON_LINE_MONITOR = 5;
        static int NODE_INDEX_VERSION = 6;
        static int NODE_INDEX_OTA = 7;

        //Define TabPages Index
        const int TABPAGE_INDEX_GATEWAY_LIST = 0;
        const int TABPAGE_INDEX_GATEWAY_INFO = 1;
        const int TABPAGE_INDEX_DEVICE_INFO = 2;
        const int TABPAGE_INDEX_TAGSET_LIST = 3;
        const int TABPAGE_INDEX_TAGSET_INFO = 4;
        const int TABPAGE_INDEX_EDCHEADERSET_LIST = 5;
        const int TABPAGE_INDEX_EDCHEADERSET_INFO = 6;
        const int TABPAGE_INDEX_EDC_OUTPUT_LIST = 7;
        const int TABPAGE_INDEX_EDC_OUTPUT_INFO = 8;
        const int TABPAGE_INDEX_ON_LINE_MONITOR = 9;
        const int TABPAGE_INDEX_DB_CONFIG_LIST = 10;
        const int TABPAGE_INDEX_DB_CONFIG_INFO = 11;
        const int TABPAGE_INDEX_VERSION_LIST = 12;
        const int TABPAGE_INDEX_IOT_VERSION = 13;
        const int TABPAGE_INDEX_WORKER_VERSION = 14;
        const int TABPAGE_INDEX_FIRMWARE_VERSION = 15;
        const int TABPAGE_INDEX_OTA = 16;

        TreeNode objSelectedNode;
        public cls_GlobalSetting ccs_initial;
        public cls_Gateway_Info gw;
        bool isLoadConfig;
        public EDCHeaderSet header_set = new EDCHeaderSet();

        public Gateway()
        {
            InitializeComponent();
        }

        private void Gateway_Load(object sender, EventArgs e)
        {
            this.objSelectedNode = null;

            tvNodeList.BeginUpdate();

            TreeNode tNode = tvNodeList.Nodes.Add("Gateway List");
            tNode.Tag = TABPAGE_INDEX_GATEWAY_LIST;
            tNode.ImageIndex = 0;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes.Add("Tag Set List");
            tNode.Tag = TABPAGE_INDEX_TAGSET_LIST;
            tNode.ImageIndex = 3;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes.Add("EDC Header Set List");
            tNode.Tag = TABPAGE_INDEX_EDCHEADERSET_LIST;
            tNode.ImageIndex = 8;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes.Add("EDC XML Output Config List");
            tNode.Tag = TABPAGE_INDEX_EDC_OUTPUT_LIST;
            tNode.ImageIndex = 9;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes.Add("Database Config");
            tNode.Tag = TABPAGE_INDEX_DB_CONFIG_LIST;
            tNode.ImageIndex = 12;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes.Add("On-Line Monitor");
            tNode.Tag = TABPAGE_INDEX_ON_LINE_MONITOR;
            tNode.ImageIndex = 11;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes.Add("Version Management");
            tNode.Tag = TABPAGE_INDEX_VERSION_LIST;
            tNode.ImageIndex = 14;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes.Add("OTA Management");
            tNode.Tag = TABPAGE_INDEX_OTA;
            tNode.ImageIndex = 15;
            tNode.SelectedImageIndex = 19;

            tvNodeList.EndUpdate();

            this.isLoadConfig = false;

            pnlMain.Height = tvNodeList.Height;

            //db init
            //LoadDBConfig();
            LoadInitial();

            //if(this.ObjectManager.DBManager.config_db.enable)
            if (this.ccs_initial.db_enabled)
            {
                System.Diagnostics.Debug.Print("DB COnnect Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                //this.db = new IOT_DbContext(this.ObjectManager.DBManager.config_db.provider_name, this.ObjectManager.DBManager.config_db.connection_string);
                this.db = new IOT_DbContext(this.ccs_initial.db_info.provider_name, this.ccs_initial.db_info.connection_string);
                System.Diagnostics.Debug.Print("DB COnnect End & init Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                this.db.Configuration.AutoDetectChangesEnabled = false;
                this.db.Configuration.LazyLoadingEnabled = false;
                this.db.Configuration.ProxyCreationEnabled = false;
                this.db.IOT_GATEWAY.FirstOrDefault();
                System.Diagnostics.Debug.Print("DB COnnect init End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            }
        }

        public void Init()
        {
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            if (LoadGatewayConfig())
            {
                this.isLoadConfig = true;
                LoadMonitorConfig();
            }
            else
            {
                return;
            }

            LoadTagSetConfig();
            LoadHeaderSetConfig();
            LoadEDCXmlConfig();
            LoadDBConfig();
            LoadVersionConfig();
            LoadOTAConfig();

            RefreshGatewayConfig(TABPAGE_INDEX_GATEWAY_LIST);

        }

        public void RefreshGatewayConfig(int display_index)
        {
            foreach (TreeNode node in tvNodeList.Nodes)
            {
                node.Nodes.Clear();
            }

            int j = 0;
            TreeNode tNode;
            tvNodeList.BeginUpdate();
            foreach (cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
            {
                tNode = tvNodeList.Nodes[NODE_INDEX_GATEWAY_LIST].Nodes.Add(gi.gateway_id);
                tNode.Tag = TABPAGE_INDEX_GATEWAY_INFO;
                tNode.ImageIndex = 1;
                tNode.SelectedImageIndex = 19;

                foreach (cls_Device_Info di in gi.device_info)
                {
                    tNode = tvNodeList.Nodes[NODE_INDEX_GATEWAY_LIST].Nodes[j].Nodes.Add(di.device_name);
                    tNode.Tag = TABPAGE_INDEX_DEVICE_INFO;
                    tNode.ImageIndex = 2;
                    tNode.SelectedImageIndex = 19;
                }
                j++;
            }

            foreach(cls_Tag_Set ts in ObjectManager.TagSetManager.tag_set_list)
            {
                tNode = tvNodeList.Nodes[NODE_INDEX_TAG_SET_LIST].Nodes.Add(ts.TagSetName);
                tNode.Tag = TABPAGE_INDEX_TAGSET_INFO;
                tNode.ImageIndex = 4;
                tNode.SelectedImageIndex = 19;
            }
            
            foreach (cls_EDC_Header hs in this.header_set.head_set_list)
            {
                tNode = tvNodeList.Nodes[NODE_INDEX_EDC_HEADER_SET_LIST].Nodes.Add(hs.set_name);
                tNode.Tag = TABPAGE_INDEX_EDCHEADERSET_INFO;
                tNode.ImageIndex = 7;
                tNode.SelectedImageIndex = 19;
            }

            if(ObjectManager.EDCManager.gateway_edc.Count > 0)
            {
                foreach (cls_EDC_Info edc_info in ObjectManager.EDCManager.gateway_edc)
                {
                    tNode = tvNodeList.Nodes[NODE_INDEX_EDC_OUTPUT_LIST].Nodes.Add(edc_info.serial_id + "." + edc_info.gateway_id + "." + edc_info.device_id);
                    tNode.Tag = TABPAGE_INDEX_EDC_OUTPUT_INFO;
                    tNode.ImageIndex = 10;
                    tNode.SelectedImageIndex = 19;
                }
            }

            if (ObjectManager.DBManager.dbconfig_list.Count > 0)
            {
                foreach (cls_DB_Info db_info in ObjectManager.DBManager.dbconfig_list)
                {
                    tNode = tvNodeList.Nodes[NODE_INDEX_DB_CONFIG].Nodes.Add(db_info.serial_id + "." + db_info.gateway_id + "." + db_info.device_id);
                    tNode.Tag = TABPAGE_INDEX_DB_CONFIG_INFO;
                    tNode.ImageIndex = 13;
                    tNode.SelectedImageIndex = 19;
                }
            }

            tNode = tvNodeList.Nodes[NODE_INDEX_VERSION].Nodes.Add("IOT Image");
            tNode.Tag = TABPAGE_INDEX_IOT_VERSION;
            tNode.ImageIndex = 16;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes[NODE_INDEX_VERSION].Nodes.Add("Worker Image");
            tNode.Tag = TABPAGE_INDEX_WORKER_VERSION;
            tNode.ImageIndex = 17;
            tNode.SelectedImageIndex = 19;

            tNode = tvNodeList.Nodes[NODE_INDEX_VERSION].Nodes.Add("Firmware Image");
            tNode.Tag = TABPAGE_INDEX_FIRMWARE_VERSION;
            tNode.ImageIndex = 18;
            tNode.SelectedImageIndex = 19;

            //tvNodeList.ExpandAll();
            tvNodeList.EndUpdate();

            DisplayPanel(display_index);
        }

        private void tvNodeList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(!this.isLoadConfig)
            {
                return;
            }
            
            objSelectedNode = e.Node;

            int index = int.Parse(e.Node.Tag.ToString());
            DisplayPanel(index);
        }

        // Display the appropriate form
        private void DisplayPanel(int index)
        {
            pnlMain.Visible = true;
            SetupPanelData(index);
        }

        private void SetupPanelData(int index)
        {
            switch (index)
            {
                case TABPAGE_INDEX_GATEWAY_LIST:
                    DisplayGatewayList();
                    break;

                case TABPAGE_INDEX_GATEWAY_INFO:
                    DisplayGatewayInfo(false);
                    break;

                case TABPAGE_INDEX_DEVICE_INFO:
                    DisplayDeviceInfo(false);
                    break;

                case TABPAGE_INDEX_TAGSET_LIST:
                    DispalyTagSetList();
                    break;

                case TABPAGE_INDEX_TAGSET_INFO:
                    DisplayTagSetInfo(false);
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_LIST:
                    DisplayEDCHeaderSetList();
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_INFO:
                    DisplayEDCHeaderSetInfo(false);
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_LIST:
                    DisplayEDCXMLList();
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_INFO:
                    DisplayEDCXMLInfo(false);
                    break;
                    
                case TABPAGE_INDEX_DB_CONFIG_LIST:
                    DisplayDBConfigList();
                    break;

                case TABPAGE_INDEX_DB_CONFIG_INFO:
                    DisplayDBConfigInfo(false);
                    break;

                case TABPAGE_INDEX_ON_LINE_MONITOR:
                    DisplayOnlineMonitor();
                    break;

                case TABPAGE_INDEX_VERSION_LIST:
                    DisplayVersionManagement();
                    break;

                case TABPAGE_INDEX_IOT_VERSION:
                    DisplayIOTVersion();
                    break;

                case TABPAGE_INDEX_WORKER_VERSION:
                    DisplayWorkerVersion();
                    break;

                case TABPAGE_INDEX_FIRMWARE_VERSION:
                    DisplayFirmwareVersion();
                    break;

                case TABPAGE_INDEX_OTA:
                    DisplayOTAManagement();
                    break;

                default:
                    break;
            }
        }

        //Delegate function to update GateWayManager information
        void SetGatewayManager(GateWayManager g_manager)
        {
            ObjectManager.GatewayManager.gateway_list = g_manager.gateway_list;
            RefreshGatewayConfig(TABPAGE_INDEX_GATEWAY_LIST);
        }

        //Delegate function to set Gateway Information
        void SetGatewayInfo(cls_Gateway_Info g_info, bool edit_flag)
        {
            if(edit_flag)
            {
                int i = 0;
                foreach(cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
                {
                    if(gi.gateway_id == g_info.gateway_id)
                    {
                        break;
                    }
                    i++;
                }
                ObjectManager.GatewayManager.gateway_list[i] = g_info;
            }
            else
            {
                g_info.function_list.Clear();
                ObjectManager.GatewayManager.gateway_list.Add(g_info);
            }

            RefreshGatewayConfig(TABPAGE_INDEX_GATEWAY_LIST);
        }

        //Delegate function to update TagSetManager information
        void SetTagSetManager(TagSetManager tsManager)
        {
            ObjectManager.TagSetManager.tag_set_list = tsManager.tag_set_list;
            RefreshGatewayConfig(TABPAGE_INDEX_TAGSET_LIST);
        }

        //Delegate function to update Tag Set Information
        void SetTagSetInfo(cls_Tag_Set tag_set, bool edit_flag)
        {
            if (edit_flag)
            {
                int i = 0;
                foreach (cls_Tag_Set ts in ObjectManager.TagSetManager.tag_set_list)
                {
                    if (ts.TagSetName == tag_set.TagSetName)
                    {
                        break;
                    }
                    i++;
                }
                ObjectManager.TagSetManager.tag_set_list[i] = tag_set;
            }
            else
            {
                ObjectManager.TagSetManager.tag_set_list.Add(tag_set);
            }

            RefreshGatewayConfig(TABPAGE_INDEX_TAGSET_LIST);
        }

        //Delegate function to update EDC Header Set List
        void SetEDCHeaderSetList(EDCHeaderSet edc_set_list)
        {
            this.header_set = edc_set_list;
            RefreshGatewayConfig(TABPAGE_INDEX_EDCHEADERSET_LIST);
        }


        //Delegate function to check header set name is duplicate or not
        bool CheckDuplicateHeaderSetName(string hs_name)
        {
            if (this.header_set.head_set_list.Count > 0)
            {
                foreach (cls_EDC_Header hs in this.header_set.head_set_list)
                {
                    if (hs.set_name == hs_name)
                    {
                        MessageBox.Show("Duplicate header set id!", "Error");
                        return false;
                    }
                }
            }

            return true;
        }
        //Delegate function to set EDC Header Set information
        void SetEDCHeaderSetInfo(cls_EDC_Header edc_set, bool edit_flag)
        {
            if(edit_flag)
            {
                int i = 0;
                foreach(cls_EDC_Header hs in this.header_set.head_set_list)
                {
                    if (hs.set_name == edc_set.set_name)
                    {
                        break;
                    }
                    i++;
                }
                this.header_set.head_set_list[i] = edc_set;
            }
            else
            {
                this.header_set.head_set_list.Add(edc_set);
            }

            RefreshGatewayConfig(TABPAGE_INDEX_EDCHEADERSET_LIST);
        }

        //Delegate function to update EDCManager information
        void EDCManager(EDCManager edcMgr)
        {
            ObjectManager.EDCManager.gateway_edc = edcMgr.gateway_edc;
            ObjectManager.EDCManager.serial_id_index = edcMgr.serial_id_index;
            RefreshGatewayConfig(TABPAGE_INDEX_EDC_OUTPUT_LIST);
        }

        //Delegate function to update EDC XML Information
        void SetEDCXmlInfo(cls_EDC_Info edc_info, bool edit_flag)
        {
            if (edit_flag)
            {
                int i = 0;
                foreach (cls_EDC_Info edc in ObjectManager.EDCManager.gateway_edc)
                {
                    if (edc.serial_id == edc_info.serial_id)
                    {
                        break;
                    }
                    i++;
                }
                ObjectManager.EDCManager.gateway_edc[i] = edc_info;
            }
            else
            {
                ObjectManager.EDCManager.gateway_edc.Add(edc_info);
                ObjectManager.EDCManager.serial_id_index = int.Parse(edc_info.serial_id);
            }

            RefreshGatewayConfig(TABPAGE_INDEX_EDC_OUTPUT_LIST);
        }

        //Delegate function to update DBManager information
        void SetDBManager(DBManager dbMgr)
        {
            ObjectManager.DBManager.dbconfig_list = dbMgr.dbconfig_list;
            ObjectManager.DBManager.serial_id_index = dbMgr.serial_id_index;
            RefreshGatewayConfig(TABPAGE_INDEX_DB_CONFIG_LIST);
        }

        //Delegate function to update DB Config Information
        void SetDBConfigInfo(cls_DB_Info db_info, bool edit_flag)
        {
            if (edit_flag)
            {
                int i = 0;
                foreach (cls_DB_Info db in ObjectManager.DBManager.dbconfig_list)
                {
                    if (db.serial_id == db_info.serial_id)
                    {
                        break;
                    }
                    i++;
                }
                ObjectManager.DBManager.dbconfig_list[i] = db_info;
            }
            else
            {
                ObjectManager.DBManager.dbconfig_list.Add(db_info);
                ObjectManager.DBManager.serial_id_index = int.Parse(db_info.serial_id);
            }

            RefreshGatewayConfig(TABPAGE_INDEX_DB_CONFIG_LIST);
        }

        private void DisplayGatewayList()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmListGateway gwList = new frmListGateway(SetGatewayManager, ObjectManager.GatewayManager);
            gwList.Owner = this;
            gwList.TopLevel = false;
            gwList.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(gwList);
            gwList.Show();
        }

        private void DisplayGatewayInfo(bool copy_flag)
        {
            TreeNode tNode = tvNodeList.SelectedNode;

            cls_Gateway_Info gwi = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == tNode.Text.Trim()).FirstOrDefault();
            
            if (gwi == null)
            {
                MessageBox.Show("Cannot find Gateway Object from GatewayManager", "Error");
                return;
            }

            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            if(copy_flag)
            {
                cls_Gateway_Info tmp_gwi = new cls_Gateway_Info();

                string json_string = JsonConvert.SerializeObject(gwi, Newtonsoft.Json.Formatting.Indented);
                tmp_gwi = JsonConvert.DeserializeObject<cls_Gateway_Info>(json_string);
                tmp_gwi.gateway_id = "";

                frmEditGateway gwForm = new frmEditGateway(SetGatewayInfo, tmp_gwi);
                gwForm.Owner = this;
                gwForm.TopLevel = false;
                gwForm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(gwForm);

                gwForm.Show();
            }
            else
            {
                frmEditGateway gwForm = new frmEditGateway(SetGatewayInfo, gwi);
                gwForm.Owner = this;
                gwForm.TopLevel = false;
                gwForm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(gwForm);

                gwForm.Show();
            }

        }

        private void DisplayDeviceInfo(bool copy_flag)
        {
            TreeNode tNode = tvNodeList.SelectedNode;  // Device Node
            TreeNode pNode = tNode.Parent;                    // Gateway Node

            int i = 0;
            int j = 0;

            cls_Gateway_Info gi = ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == pNode.Text.Trim()).FirstOrDefault();
            if(gi == null)
            {
                MessageBox.Show("Cannot find Gateway Object from GatewayManager", "Error");
                return;
            }
            i = ObjectManager.GatewayManager.gateway_list.FindIndex(o => o.gateway_id == gi.gateway_id);

            cls_Device_Info dv = gi.device_info.Where(x => x.device_name == tNode.Text.Trim()).FirstOrDefault();
            if (dv == null)
            {
                MessageBox.Show("Cannot find Device Object from Gateway[" + gi.gateway_id + "]", "Error");
                return;
            }
            j = gi.device_info.FindIndex(y => y.device_name == dv.device_name);

            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            if(copy_flag)
            {
                cls_Device_Info tmpDevice = new cls_Device_Info();

                string json_string = JsonConvert.SerializeObject(dv, Newtonsoft.Json.Formatting.Indented);
                tmpDevice = JsonConvert.DeserializeObject<cls_Device_Info>(json_string);
                tmpDevice.device_name = "";

                frmEditDevice deviceForm = new frmEditDevice(gi, tmpDevice, j);
                deviceForm.Owner = this;
                deviceForm.TopLevel = false;
                deviceForm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(deviceForm);

                deviceForm.Show();
            }
            else
            {
                frmEditDevice deviceForm = new frmEditDevice(gi, dv, j);
                deviceForm.Owner = this;
                deviceForm.TopLevel = false;
                deviceForm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(deviceForm);

                deviceForm.Show();
            }
        }

        private void DispalyTagSetList()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmListTagSet setList = new frmListTagSet(SetTagSetManager, ObjectManager.TagSetManager);
            setList.Owner = this;
            setList.TopLevel = false;
            setList.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(setList);
            setList.Show();
        }

        private void DisplayTagSetInfo(bool copy_flag)
        {
            TreeNode tNode = tvNodeList.SelectedNode;  // Tag Set Node

            int i = 0;
            /*
            foreach(cls_Tag_Set tag_set in ObjectManager.TagSetManager.tag_set_list)
            {
                if(tag_set.TagSetName == tNode.Text)
                {
                    break;
                }
                i++;
            }
            */
            cls_Tag_Set tag_set = ObjectManager.TagSetManager.tag_set_list.Where(p => p.TagSetName == tNode.Text.Trim()).FirstOrDefault();
            if(tag_set == null)
            {
                MessageBox.Show("Cannot find TagSet Object from TagSetManager", "Error");
                return;
            }
            i = ObjectManager.TagSetManager.tag_set_list.FindIndex(o => o.TagSetName == tag_set.TagSetName);

            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            if(copy_flag)
            {
                cls_Tag_Set tmpTagSet = new cls_Tag_Set();
                string json_string = JsonConvert.SerializeObject(tag_set, Newtonsoft.Json.Formatting.Indented);
                tmpTagSet = JsonConvert.DeserializeObject<cls_Tag_Set>(json_string);
                tmpTagSet.TagSetName = "";

                frmEditTagSetTemplate frm = new frmEditTagSetTemplate(SetTagSetInfo, tmpTagSet, i);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(frm);

                frm.Show();
            }
            else
            {

                frmEditTagSetTemplate frm = new frmEditTagSetTemplate(SetTagSetInfo, ObjectManager.TagSetManager.tag_set_list[i], i);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(frm);

                frm.Show();
            }
        }

        private void DisplayEDCHeaderSetList()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmListEDCHeaderSet headerList = new frmListEDCHeaderSet(SetEDCHeaderSetList, this.header_set);
            headerList.Owner = this;
            headerList.TopLevel = false;
            headerList.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(headerList);
            headerList.Show();
        }

        private void DisplayEDCHeaderSetInfo(bool copy_flag)
        {
            TreeNode tNode = tvNodeList.SelectedNode;  // Header Set Info Node

            int i = 0;
            /*
            foreach (cls_EDC_Header hs in this.header_set.head_set_list)
            {
                if (hs.set_name == tNode.Text)
                {
                    break;
                }
                i++;
            }
            */

            cls_EDC_Header hs = this.header_set.head_set_list.Where(p => p.set_name == tNode.Text.Trim()).FirstOrDefault();
            if (hs == null)
            {
                MessageBox.Show("Cannot find Header Set  Object from Header Set List", "Error");
                return;
            }
            i = this.header_set.head_set_list.FindIndex(o => o.set_name == hs.set_name);

            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            if(copy_flag)
            {
                cls_EDC_Header tmpHeaderSet = new cls_EDC_Header();

                string json_string = JsonConvert.SerializeObject(hs, Newtonsoft.Json.Formatting.Indented);
                tmpHeaderSet = JsonConvert.DeserializeObject<cls_EDC_Header>(json_string);
                tmpHeaderSet.set_name = "";

                frmEditEDCHeader frm = new frmEditEDCHeader(SetEDCHeaderSetInfo, CheckDuplicateHeaderSetName, tmpHeaderSet);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(frm);

                frm.Show();
            }
            else
            {
                frmEditEDCHeader frm = new frmEditEDCHeader(SetEDCHeaderSetInfo, CheckDuplicateHeaderSetName, this.header_set.head_set_list[i]);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(frm);

                frm.Show();
            }
        }

        private void DisplayEDCXMLList()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmListEDCXml frm = new frmListEDCXml(EDCManager, ObjectManager.EDCManager, ObjectManager.GatewayManager);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayEDCXMLInfo(bool copy_flag)
        {
            string strSerial;
            string strGatewayID;
            string strDeviceID;
            string[] tmp;
            int i;

            TreeNode tNode = tvNodeList.SelectedNode;  // EDC XML Information Node

            //Get gateway id and device id from tNode.Text
            tmp = tNode.Text.Split('.');
            strSerial = tmp[0];
            strGatewayID = tmp[1];
            strDeviceID = tmp[2];

            i = 0;
            /*
            foreach(cls_EDC_Info edc in ObjectManager.EDCManager.gateway_edc)
            {
                if(edc.serial_id == strSerial)
                {
                    break;
                }
                i++;
            }
            */
            cls_EDC_Info edc = ObjectManager.EDCManager.gateway_edc.Where(p => p.serial_id == strSerial).FirstOrDefault();
            if(edc == null)
            {
                MessageBox.Show("Cannot find EDC Info  Object from EDCManager", "Error");
                return;
            }
            i = ObjectManager.EDCManager.gateway_edc.FindIndex(o => o.serial_id == edc.serial_id);

            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            if(copy_flag)
            {
                cls_EDC_Info tmpEDC = new cls_EDC_Info();

                string json_string = JsonConvert.SerializeObject(edc, Newtonsoft.Json.Formatting.Indented);
                tmpEDC = JsonConvert.DeserializeObject<cls_EDC_Info>(json_string);
                tmpEDC.serial_id = (ObjectManager.EDCManager.get_last_serial_id() + 1).ToString("D8");

                frmEditEDCXml frm = new frmEditEDCXml(SetEDCXmlInfo, ObjectManager.GatewayManager, tmpEDC, strGatewayID, strDeviceID, true);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(frm);

                frm.Show();
            }
            else
            {
                frmEditEDCXml frm = new frmEditEDCXml(SetEDCXmlInfo, ObjectManager.GatewayManager, ObjectManager.EDCManager.gateway_edc[i], strGatewayID, strDeviceID, false);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(frm);

                frm.Show();
            }
        }

        private void DisplayOnlineMonitor()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmOnlineMonitor frm = new frmOnlineMonitor(this.ObjectManager);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayDBConfigList()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmListDBConfig frm = new frmListDBConfig(SetDBManager, ObjectManager.DBManager, ObjectManager.GatewayManager);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayDBConfigInfo(bool copy_flag)
        {
            string strSerial;
            string strGatewayID;
            string strDeviceID;
            string[] tmp;
            int i;

            TreeNode tNode = tvNodeList.SelectedNode;  // EDC XML Information Node

            //Get gateway id and device id from tNode.Text
            tmp = tNode.Text.Split('.');
            strSerial = tmp[0];
            strGatewayID = tmp[1];
            strDeviceID = tmp[2];

            i = 0;
            /*
            foreach (cls_DB_Info db in ObjectManager.DBManager.dbconfig_list)
            {
                if (db.serial_id == strSerial)
                {
                    break;
                }
                i++;
            }
            */
            cls_DB_Info db = ObjectManager.DBManager.dbconfig_list.Where(p => p.serial_id == strSerial).FirstOrDefault();
            if(db == null)
            {
                MessageBox.Show("Cannot find DB Config  Object from DBManager", "Error");
                return;
            }
            i = ObjectManager.DBManager.dbconfig_list.FindIndex(o => o.serial_id == db.serial_id);

            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            if(copy_flag)
            {
                cls_DB_Info tmpDB = new cls_DB_Info();

                string json_string = JsonConvert.SerializeObject(db, Newtonsoft.Json.Formatting.Indented);
                tmpDB = JsonConvert.DeserializeObject<cls_DB_Info>(json_string);
                tmpDB.serial_id = (ObjectManager.DBManager.get_last_serial_id() + 1).ToString("D8");

                frmEditDBConfig frm = new frmEditDBConfig(SetDBConfigInfo, ObjectManager.GatewayManager, tmpDB, strGatewayID, strDeviceID, true);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(frm);

                frm.Show();
            }
            else
            {
                frmEditDBConfig frm = new frmEditDBConfig(SetDBConfigInfo, ObjectManager.GatewayManager, ObjectManager.DBManager.dbconfig_list[i], strGatewayID, strDeviceID, false);
                frm.Owner = this;
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                pnlMain.Controls.Add(frm);

                frm.Show();
            }
        }

        private void DisplayVersionManagement()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmListAppVersion frm = new frmListAppVersion(ObjectManager.VersionManager);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayIOTVersion()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmEditAppVersion frm = new frmEditAppVersion(ObjectManager.VersionManager, "IOT");
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayWorkerVersion()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmEditAppVersion frm = new frmEditAppVersion(ObjectManager.VersionManager, "WORKER");
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayFirmwareVersion()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmEditAppVersion frm = new frmEditAppVersion(ObjectManager.VersionManager, "FIRMWARE");
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayOTAManagement()
        {
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }

            frmListOTA frm = new frmListOTA(this.ObjectManager, ObjectManager.GatewayManager, ObjectManager.OTAManager);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        public void SetDeviceInfo(cls_Gateway_Info gi, cls_Device_Info di, int index, bool copy_flag)
        {
            if(copy_flag)
            {
                gi.device_info.Add(di);
            }
            else
            {
                gi.device_info[index] = di;
            }
        }

        /*
        private void btnAddGateway_Click(object sender, EventArgs e)
        {
            var frm = new frmEditGateway();
            frm.Owner = this;
            frm.ShowDialog();

            gw = null;
            RefreshGatewayConfig(TABPAGE_INDEX_GATEWAY_LIST);
        }
        */

        private bool LoadInitial()
        {
            try
            {
                this.ccs_initial = new cls_GlobalSetting();

                if (!File.Exists("C:\\Gateway\\Config\\Global_Setting.json"))
                {
                    MessageBox.Show("No Global Setting file exists!.", "Error");
                    this.ccs_initial.db_enabled = false;
                    return false;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\Global_Setting.json");

                string json_string = inputFile.ReadToEnd();

                this.ccs_initial = JsonConvert.DeserializeObject<cls_GlobalSetting>(json_string);

                if (this.ccs_initial == null)
                {
                    //Console.WriteLine("No Initial config exists!");
                    MessageBox.Show("No Initial config exists!.", "Error");
                    this.ccs_initial = new cls_GlobalSetting();
                    this.ccs_initial.db_enabled = false;
                    return false;
                }

                inputFile.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Service  Initial file loading error -> " + ex.Message);
                MessageBox.Show("LoadInitial Exception: " + ex.Message, "Error");
                this.ccs_initial.db_enabled = false;
                return false;
            }

            return true;
        }

        private bool LoadGatewayConfig()
        {
            try
            {
                if(!System.IO.File.Exists("C:\\Gateway\\Config\\Gateway_Device_Config.json"))
                {
                    MessageBox.Show("No gateway config file exists! Please start to create new gateway information.", "Information");
                    ObjectManager.GatewayManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\Gateway_Device_Config.json");

                string json_string = inputFile.ReadToEnd();
                //string json_string = EncryptionHelper.Decrypt(inputFile.ReadToEnd());

                ObjectManager.GatewayManager_Initial(json_string);

                if (ObjectManager.GatewayManager.gateway_list == null)
                {
                    MessageBox.Show("No gateway exists!", "Warning");
                    return false;
                }

                inputFile.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Gateway config file loading error -> " + ex.Message, "Error");
                return false;
            }

            return true;
        }

        private bool LoadTagSetConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\Tag_Set_Config.json"))
                {
                    //MessageBox.Show("No tag set config file exists! Please start to create tag set template.", "Information");
                    ObjectManager.TagSetManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\Tag_Set_Config.json");

                string json_string = inputFile.ReadToEnd();

                ObjectManager.TagSetManager_Initial(json_string);

                if (ObjectManager.TagSetManager.tag_set_list == null)
                {
                    MessageBox.Show("No tag set template exists!", "Information");
                    return false;
                }

                inputFile.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Tag Set config file loading error! -> " + ex.Message, "Error");
                return false;
            }

            return true;
        }

        private bool LoadHeaderSetConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\EDC_Header_Set_Config.json"))
                {
                    //MessageBox.Show("No tag set config file exists! Please start to create tag set template.", "Information");
                    //ObjectManager.TagSetManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\EDC_Header_Set_Config.json");

                string json_string = inputFile.ReadToEnd();

                //ObjectManager.TagSetManager_Initial(json_string);
                this.header_set = JsonConvert.DeserializeObject<EDCHeaderSet>(json_string);

                if (this.header_set.head_set_list == null)
                {
                    MessageBox.Show("No EDC header set exists!", "Information");
                    return false;
                }

                inputFile.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("EDC Header Set config file loading error! -> " + ex.Message, "Error");
                return false;
            }

            return true;
        }

        private bool LoadEDCXmlConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\EDC_Xml_Config.json"))
                {
                    //MessageBox.Show("No tag set config file exists! Please start to create tag set template.", "Information");
                    ObjectManager.EDCManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\EDC_Xml_Config.json");

                string json_string = inputFile.ReadToEnd();

                ObjectManager.EDCManager_Initial(json_string);

                if (ObjectManager.EDCManager.gateway_edc == null)
                {
                    MessageBox.Show("No EDC XML config exists!", "Information");
                    return false;
                }

                inputFile.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("EDC XML config file loading error! -> " + ex.Message, "Error");
                return false;
            }

            return true;
        }

        private bool LoadDBConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\Database_Config.json"))
                {
                    //MessageBox.Show("No tag set config file exists! Please start to create tag set template.", "Information");
                    ObjectManager.DBManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\Database_Config.json");

                string json_string = inputFile.ReadToEnd();

                ObjectManager.DBManager_Initial(json_string);

                if (ObjectManager.DBManager.dbconfig_list == null)
                {
                    MessageBox.Show("No DB Configuration exists!", "Information");
                    return false;
                }

                inputFile.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("DB config file loading error! -> " + ex.Message, "Error");
                return false;
            }

            return true;
        }

        private void LoadMonitorConfig()
        {
            if(this.ccs_initial.db_enabled)
            {
                ObjectManager.MonitorManager_Initial();

                BuildMonitorInformationFromDB();
            }
            else
            {
                BuildMonitorInformationFromFile();
            }
        }

        private void BuildMonitorInformationFromDB()
        {
            var tmp = this._db.IOT_STATUS_MONITOR.Where(x => x.id > 0);
            foreach(IOT_STATUS_MONITOR ism in tmp)
            {
                cls_Monitor_Device_Info mdi = new cls_Monitor_Device_Info();
                mdi.gateway_id = ism.gateway_id;
                mdi.device_id = ism.device_id;
                if(ism.virtual_flag == "Y")
                {
                    mdi.virtual_flag = true;
                }
                else
                {
                    mdi.virtual_flag = false;
                }
                mdi.device_type = ism.device_type;
                mdi.device_status = ism.device_status;
                mdi.iotclient_status = ism.iotclient_status;
                mdi.hb_status = ism.hb_status;
                mdi.plc_ip = ism.plc_ip;
                mdi.plc_port = ism.plc_port;
                mdi.device_location = ism.device_location;
                mdi.last_alarm_code = ism.last_alarm_code;
                mdi.last_alarm_app = ism.last_alarm_app;
                mdi.last_edc_time = ism.last_edc_time;
                mdi.hb_report_time = ism.hb_report_time;
                mdi.last_alarm_datetime = ism.last_alarm_datetime;
                mdi.last_alarm_message = ism.last_alarm_message;
                ObjectManager.MonitorManager.device_list.Add(mdi);
            }
        }

        private void BuildMonitorInformationFromFile()
        {
            if(File.Exists("C:\\Gateway\\Information\\Monitor_Status.json"))
            {
                StreamReader inputFile = new StreamReader("C:\\Gateway\\Information\\Monitor_Status.json");
                string json_string = inputFile.ReadToEnd();
                inputFile.Close();

                ObjectManager.MonitorManager_Initial(json_string);
                if (ObjectManager.GatewayManager.gateway_list.Count > 0)
                {
                    foreach (cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
                    {
                        if (gi.device_info.Count > 0)
                        {
                            foreach (cls_Device_Info di in gi.device_info)
                            {
                                cls_Monitor_Device_Info mdi_tmp = ObjectManager.MonitorManager.device_list.Where(p => (p.gateway_id == gi.gateway_id) && (p.device_id == di.device_name)).FirstOrDefault();
                                if(mdi_tmp == null)
                                {
                                    cls_Monitor_Device_Info mdi = new cls_Monitor_Device_Info();
                                    mdi.gateway_id = gi.gateway_id;
                                    mdi.device_id = di.device_name;
                                    mdi.virtual_flag = gi.virtual_flag;
                                    mdi.device_type = di.device_type;
                                    mdi.device_status = "Off";
                                    mdi.iotclient_status = "Off";
                                    mdi.plc_ip = di.plc_ip_address;
                                    mdi.plc_port = di.plc_port_id;
                                    mdi.device_location = di.device_location;
                                    ObjectManager.MonitorManager.device_list.Add(mdi);
                                }
                            }
                        }
                    }
                }
            }
            else  //Monitor_Status.json doesn;t exist, build initial monitor information from gateway/device setting
            {
                ObjectManager.MonitorManager_Initial();
                if (ObjectManager.GatewayManager.gateway_list.Count > 0)
                {
                    foreach (cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
                    {
                        if (gi.device_info.Count > 0)
                        {
                            foreach (cls_Device_Info di in gi.device_info)
                            {
                                cls_Monitor_Device_Info mdi = new cls_Monitor_Device_Info();
                                mdi.gateway_id = gi.gateway_id;
                                mdi.device_id = di.device_name;
                                mdi.virtual_flag = gi.virtual_flag;
                                mdi.device_type = di.device_type;
                                mdi.device_status = "Off";
                                mdi.iotclient_status = "Off";
                                mdi.plc_ip = di.plc_ip_address;
                                mdi.plc_port = di.plc_port_id;
                                mdi.device_location = di.device_location;
                                ObjectManager.MonitorManager.device_list.Add(mdi);
                            }
                        }
                    }
                }
            }
        }

        private bool LoadVersionConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\Version_Config.json"))
                {
                    //MessageBox.Show("No tag set config file exists! Please start to create tag set template.", "Information");
                    ObjectManager.VersionManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\Version_Config.json");

                string json_string = inputFile.ReadToEnd();

                ObjectManager.VersionManager_Initial(json_string);

                if (ObjectManager.VersionManager.version_list == null)
                {
                    MessageBox.Show("No Version Configuration exists!", "Information");
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

        private bool LoadOTAConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\OTA_Config.json"))
                {
                    //MessageBox.Show("No tag set config file exists! Please start to create tag set template.", "Information");
                    ObjectManager.OTAManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\OTA_Config.json");

                string json_string = inputFile.ReadToEnd();

                ObjectManager.OTAManager_Initial(json_string);

                if (ObjectManager.OTAManager.ota_iot_list == null && ObjectManager.OTAManager.ota_worker_list == null && ObjectManager.OTAManager.ota_firmware_list == null )
                {
                    MessageBox.Show("No OTA Configuration exists!", "Information");
                    return false;
                }

                inputFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("OTA config file loading error! -> " + ex.Message, "Error");
                return false;
            }

            return true;
        }

        private void SaveGatewayConfig()
        {
            string json_string;

            json_string = ObjectManager.GatewayManager_ToJson_String();
            //json_string = EncryptionHelper.Encrypt(ObjectManager.GatewayManager_ToJson_String());
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\Gateway_Device_Config.json");
            output.Write(json_string);
            output.Close();
        }

        private void SaveTagSetConfig()
        {
            string json_string;

            json_string = ObjectManager.TagSetManager_ToJson_String();
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\Tag_Set_Config.json");
            output.Write(json_string);
            output.Close();
        }

        private void SaveEDCHeaderSetConfig()
        {
            string json_string;

            json_string = JsonConvert.SerializeObject(this.header_set, Newtonsoft.Json.Formatting.Indented);
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\EDC_Header_Set_Config.json");
            output.Write(json_string);
            output.Close();
        }

        private void SaveEDCXmlConfig()
        {
            string json_string;

            json_string = JsonConvert.SerializeObject(ObjectManager.EDCManager, Newtonsoft.Json.Formatting.Indented);
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\EDC_Xml_Config.json");
            output.Write(json_string);
            output.Close();
        }

        private void SaveDBConfig()
        {
            string json_string;

            json_string = JsonConvert.SerializeObject(ObjectManager.DBManager, Newtonsoft.Json.Formatting.Indented);
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\Database_Config.json");
            output.Write(json_string);
            output.Close();
        }

        /*
        private void SaveVersionConfig()
        {
            string json_string;

            json_string = JsonConvert.SerializeObject(ObjectManager.VersionManager, Newtonsoft.Json.Formatting.Indented);
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\Version_Config.json");
            output.Write(json_string);
            output.Close();
        }
        */

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            Boolean bSaveDB_Result = false;

            System.Diagnostics.Debug.Print("1-"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            SaveGatewayConfig();
            SaveTagSetConfig();
            SaveEDCHeaderSetConfig();
            SaveEDCXmlConfig();
            SaveDBConfig();
            System.Diagnostics.Debug.Print("2-" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            //add for db sync - vic
            if (this.ccs_initial.db_enabled)
            {
                bSaveDB_Result = SyncConfigToDB();
                System.Diagnostics.Debug.Print("3-" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                if (bSaveDB_Result)
                {
                    MessageBox.Show("Save Data To DB Sucessfully!", "Save to DB Result.");
                }
            }
        }

        private Boolean SyncConfigToDB()
        {
            Boolean bResult = true; 
            try
            {
               // System.Diagnostics.Debug.Print("DB COnnect Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                //-------- Load DB Setting --------
                //using (IOT_DbContext db = new IOT_DbContext("MySql.Data.MySqlClient", "server=192.168.8.107;port=3306;database=iotdb;uid=root;password=qQ123456"))
                //{
                   // System.Diagnostics.Debug.Print("DB COnnect End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    System.Diagnostics.Debug.Print("Gateway Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    //gateway sync
                    if (ObjectManager.GatewayManager.gateway_list.Count > 0)
                    {
                        System.Diagnostics.Debug.Print("Gateway Start-1" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        foreach (cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
                        {
                            System.Diagnostics.Debug.Print("Gateway Start-2" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            SaveGatewayToDB(this.db, gi);
                            System.Diagnostics.Debug.Print("Gateway Start-3" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            //device sync
                            System.Diagnostics.Debug.Print("Device Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                            if (gi.device_info.Count > 0)
                            {
                                foreach (cls_Device_Info di in gi.device_info)
                                {
                                    System.Diagnostics.Debug.Print("Device - Save Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                    SaveDeviceToDB(db, di, gi.gateway_id);
                                    System.Diagnostics.Debug.Print("Device - Save End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                    //tag sync
                                    System.Diagnostics.Debug.Print("Device - Tag Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                    if (di.tag_info.Count > 0)
                                    {
                                        foreach (KeyValuePair<string, cls_Tag> kvp in di.tag_info)
                                        {

                                            SaveDeviceTagToDB(this.db, kvp.Value, di.device_name);
                                        }


                                    }
                                    System.Diagnostics.Debug.Print("Device - Tag End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                    System.Diagnostics.Debug.Print("Device - Calc Tag Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                    //calc tag sync
                                    if (di.tag_info.Count > 0)
                                    {
                                        foreach (KeyValuePair<string, cls_CalcTag> kvp in di.calc_tag_info)
                                        {

                                            SaveDeviceCalcTagToDB(this.db, kvp.Value, di.device_name);
                                        }


                                    }
                                    System.Diagnostics.Debug.Print("Device - Calc Tag End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                                }
                            }
                            System.Diagnostics.Debug.Print("Device End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                        }
                    }
                    System.Diagnostics.Debug.Print("Gateway End & Tag Set Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    //tag set sync
                    //SaveTagSetToDB(db);
                    if (ObjectManager.TagSetManager.tag_set_list.Count > 0)
                    {
                        foreach (cls_Tag_Set ts in ObjectManager.TagSetManager.tag_set_list)
                        {
                            SaveTagSetToDB(this.db, ts);

                            //tag  sync
                            if (ts.tag_set.Count > 0)
                            {
                                foreach (cls_Tag tag in ts.tag_set)
                                {
                                    SaveTagToDB(this.db, tag, ts.TagSetName);


                                }

                            }

                            //cal tag  sync
                            if (ts.calc_tag_set.Count > 0)
                            {
                                foreach (cls_CalcTag calc_tag in ts.calc_tag_set)
                                {
                                    SaveCalcTagToDB(this.db, calc_tag, ts.TagSetName);


                                }

                            }

                        }

                    }

                    System.Diagnostics.Debug.Print("Tag Set End & edc header Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    //edc header set sync
                    if (this.header_set.head_set_list.Count > 0)
                    {
                        foreach (cls_EDC_Header eh in this.header_set.head_set_list)
                        {
                            SaveEDC_HeaderSetToDB(this.db , eh);

                            //tag  sync
                            if (eh.head_set.Count > 0)
                            {
                                foreach (cls_EDC_Head_Item ehi in eh.head_set)
                                {
                                    SaveEDC_HeaderToDB(this.db, ehi, eh.set_name);
                                    
                                }

                            }
                            
                        }

                    }

                    /*
                    //edc header set sync
                    if (this.header_set.head_set_list.Count > 0)
                    {
                        foreach (cls_EDC_Header eh in this.header_set.head_set_list)
                        {
                            SaveEDC_HeaderSetToDB(this.db, eh);

                            //tag  sync
                            if (eh.head_set.Count > 0)
                            {
                                foreach (cls_EDC_Head_Item ehi in eh.head_set)
                                {
                                    SaveEDC_HeaderToDB(this.db, ehi, eh.set_name);

                                }

                            }
                        }
                    }
                    */

                    System.Diagnostics.Debug.Print("Edc End & XML Out Start" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    //edc header set sync
                    if (ObjectManager.EDCManager.gateway_edc.Count > 0)
                    {
                        foreach (cls_EDC_Info ei in ObjectManager.EDCManager.gateway_edc)
                        {
                            SaveEDC_XML_ConfigToDB(this.db, ei);
                        }
                    }
                    System.Diagnostics.Debug.Print("XML Out End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message, "SyncConfigToDB");
                bResult =false;
            }
            return bResult;
        }

        private void SaveGatewayToDB(IOT_DbContext _db, cls_Gateway_Info oGatewayInfo)
        {
            Boolean bExisting = false;

            try
            {
                System.Diagnostics.Debug.Print("SaveGatewayToDB -1" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                //var vIotGateways = _db.IOT_GATEWAY.Where(c => c.gateway_id == oGatewayInfo.gateway_id);
                var vIotGateways = _db.IOT_GATEWAY.AsQueryable();
                System.Diagnostics.Debug.Print("SaveGatewayToDB -2" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                /*
                vIotGateways = vIotGateways;
                if (vIotGateways.Count() > 0)
                {
                    bExisting = true;
                }*/
                foreach(IOT_GATEWAY oIotGateway in vIotGateways)
                {
                    if(oIotGateway.gateway_id == oGatewayInfo.gateway_id)
                    {
                        bExisting = true;
                        break;
                    }
                }

                System.Diagnostics.Debug.Print("SaveGatewayToDB -3" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                IOT_GATEWAY oIoT_Gateway = new IOT_GATEWAY();

                if (bExisting)
                {
                    System.Diagnostics.Debug.Print("SaveGatewayToDB -4" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    oIoT_Gateway = vIotGateways.FirstOrDefault();
                    System.Diagnostics.Debug.Print("SaveGatewayToDB -5" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    oIoT_Gateway.gateway_ip = oGatewayInfo.gateway_ip;
                    oIoT_Gateway.location = oGatewayInfo.location;
                    if (oGatewayInfo.virtual_flag)
                    {
                        oIoT_Gateway.virtual_flag = "Y";
                    }
                    else
                    {
                        oIoT_Gateway.virtual_flag = "N";
                    }

                    oIoT_Gateway.virtual_publish_topic = oGatewayInfo.virtual_publish_topic;
                    oIoT_Gateway.clm_date_time = DateTime.Now;
                    oIoT_Gateway.clm_user = "SYSADM";

                    //_db.Update(oIoT_Gateway);
                    System.Diagnostics.Debug.Print("SaveGatewayToDB -6" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    _db.SaveChanges();
                    System.Diagnostics.Debug.Print("SaveGatewayToDB -7" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                }
                else
                {
                    oIoT_Gateway.gateway_id = oGatewayInfo.gateway_id;
                    oIoT_Gateway.gateway_ip = oGatewayInfo.gateway_ip;
                    oIoT_Gateway.location = oGatewayInfo.location;
                    if (oGatewayInfo.virtual_flag)
                    {
                        oIoT_Gateway.virtual_flag = "Y";
                    }
                    else
                    {
                        oIoT_Gateway.virtual_flag = "N";
                    }

                    oIoT_Gateway.virtual_publish_topic = oGatewayInfo.virtual_publish_topic;
                    oIoT_Gateway.clm_date_time = DateTime.Now;
                    oIoT_Gateway.clm_user = "SYSADM";
                    System.Diagnostics.Debug.Print("SaveGatewayToDB -8" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    _db.IOT_GATEWAY.Add(oIoT_Gateway);
                    System.Diagnostics.Debug.Print("SaveGatewayToDB -9" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    _db.SaveChanges();
                    System.Diagnostics.Debug.Print("SaveGatewayToDB -10" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveGatewayToDB");
            }

        }

        private void SaveDeviceToDB(IOT_DbContext _db, cls_Device_Info oDeviceInfo, string gateway_id)
        {
            Boolean bExisting = false;

            try
            {
                System.Diagnostics.Debug.Print("SaveDeviceToDB - Find STart" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                var vIotDevices = _db.IOT_DEVICE.AsQueryable();
                vIotDevices = vIotDevices.Where(c => c.device_id == oDeviceInfo.device_name);
                System.Diagnostics.Debug.Print("SaveDeviceToDB - Find End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                if (vIotDevices.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_DEVICE oIoT_Device = new IOT_DEVICE();

                if (bExisting)
                {
                    oIoT_Device = vIotDevices.FirstOrDefault();
                    oIoT_Device.device_type = oDeviceInfo.device_type;
                    if (oDeviceInfo.device_location == null)
                    {
                        oIoT_Device.location = "";
                    }
                    else
                    {
                        oIoT_Device.location = oDeviceInfo.device_location;
                    }
                    oIoT_Device.gateway_id = gateway_id;
                    oIoT_Device.plc_ip_address = oDeviceInfo.plc_ip_address;
                    oIoT_Device.plc_port_id = oDeviceInfo.plc_port_id;
                    oIoT_Device.ble_mac = oDeviceInfo.ble_mac;
                    //oIoT_Device.ble_service_uuid = oDeviceInfo.ble_service_uuid;
                    //oIoT_Device.plc_ip_address = oDeviceInfo.plc_ip_address;
                    //oIoT_Device.plc_port_id = oDeviceInfo.plc_port_id;
                    //oIoT_Device.ble_mac = oDeviceInfo.ble_mac;
                    //oIoT_Device.ble_service_uuid = oDeviceInfo.ble_service_uuid;
                    oIoT_Device.eqp_id = oDeviceInfo.device_name;
                    oIoT_Device.sub_eqp_id = oDeviceInfo.device_name;

                    oIoT_Device.clm_date_time = DateTime.Now;
                    oIoT_Device.clm_user = "SYSADM";

                    //_db.Update(oIoT_Device);
                    System.Diagnostics.Debug.Print("SaveDeviceToDB - Update STart" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    _db.SaveChanges();
                    System.Diagnostics.Debug.Print("SaveDeviceToDB - Update End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }
                else
                {
                    oIoT_Device.device_id = oDeviceInfo.device_name;
                    oIoT_Device.device_desc= "";
                    oIoT_Device.status = "";
                    oIoT_Device.device_type = oDeviceInfo.device_type;
                    if (oDeviceInfo.device_location == null)
                    {
                        oIoT_Device.location = "";
                    }
                    else
                    {
                        oIoT_Device.location = oDeviceInfo.device_location;
                    }
                    oIoT_Device.ooc_flg = "N";
                    oIoT_Device.oos_flg = "N";
                    oIoT_Device.alarm_flg = "N";
                    oIoT_Device.eqp_id = oDeviceInfo.device_name;
                    oIoT_Device.sub_eqp_id = oDeviceInfo.device_name;
                    oIoT_Device.device_no = oIoT_Device.getNewTableNO(_db);
                    oIoT_Device.gateway_id= gateway_id;
                    oIoT_Device.plc_ip_address = oDeviceInfo.plc_ip_address;
                    oIoT_Device.plc_port_id = oDeviceInfo.plc_port_id;
                    oIoT_Device.ble_mac = oDeviceInfo.ble_mac;
                    //oIoT_Device.ble_service_uuid = oDeviceInfo.ble_service_uuid;
                    //oIoT_Device.plc_ip_address = oDeviceInfo.plc_ip_address;
                    //oIoT_Device.plc_port_id = oDeviceInfo.plc_port_id;
                    //oIoT_Device.ble_mac = oDeviceInfo.ble_mac;
                    //oIoT_Device.ble_service_uuid = oDeviceInfo.ble_service_uuid;

                    oIoT_Device.clm_date_time = DateTime.Now;
                    oIoT_Device.clm_user = "SYSADM";

                    System.Diagnostics.Debug.Print("SaveDeviceToDB - Add STart" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    _db.IOT_DEVICE.Add(oIoT_Device);
                    _db.SaveChanges();
                    System.Diagnostics.Debug.Print("SaveDeviceToDB - Add End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveDeviceToDB");
            }

        }

        private void SaveTagSetToDB(IOT_DbContext _db, cls_Tag_Set oTagSet)
        {
            Boolean bExisting = false;

            try
            {
                System.Diagnostics.Debug.Print("SaveTagSetToDB - Find STart" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                var vIotTagSets = _db.IOT_TAG_SET.AsQueryable();
                vIotTagSets = vIotTagSets.Where(c => c.tag_set_id == oTagSet.TagSetName);
                System.Diagnostics.Debug.Print("SaveTagSetToDB - Find End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                if (vIotTagSets.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_TAG_SET oIoT_TagSet = new IOT_TAG_SET();

                if (bExisting)
                {
                    oIoT_TagSet = vIotTagSets.FirstOrDefault();
                    
                    oIoT_TagSet.tag_set_desc = oTagSet.TagSetDescription;

                    oIoT_TagSet.clm_date_time = DateTime.Now;
                    oIoT_TagSet.clm_user = "SYSADM";

                    //_db.Update(oIoT_TagSet);
                    System.Diagnostics.Debug.Print("SaveTagSetToDB - Update STart" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    _db.SaveChanges();
                    System.Diagnostics.Debug.Print("SaveTagSetToDB - Update End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }
                else
                {
                    oIoT_TagSet.tag_set_id = oTagSet.TagSetName;
                    oIoT_TagSet.tag_set_desc = oTagSet.TagSetDescription;

                    oIoT_TagSet.clm_date_time = DateTime.Now;
                    oIoT_TagSet.clm_user = "SYSADM";

                    System.Diagnostics.Debug.Print("SaveTagSetToDB - Add STart" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                    _db.IOT_TAG_SET.Add(oIoT_TagSet);
                    _db.SaveChanges();
                    System.Diagnostics.Debug.Print("SaveTagSetToDB - Add End" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveTagSetToDB");
            }

        }

        private void SaveDeviceTagToDB(IOT_DbContext _db, cls_Tag oTag, string device_id)
        {
            Boolean bExisting = false;

            try
            {
                var vIotDeviceTags = _db.IOT_DEVICE_TAG.AsQueryable();
                vIotDeviceTags = vIotDeviceTags.Where(c => c.device_id == device_id && c.tag_id == oTag.TagName);
                if (vIotDeviceTags.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_DEVICE_TAG oIoT_DeviceTag = new IOT_DEVICE_TAG();

                if (bExisting)
                {
                    oIoT_DeviceTag = vIotDeviceTags.FirstOrDefault();

                    oIoT_DeviceTag.tag_desc = oTag.Description;
                    oIoT_DeviceTag.data_type = oTag.Expression;
                    oIoT_DeviceTag.data_unit = oTag.Type;
                    oIoT_DeviceTag.uuid_address = oTag.UUID_Address;
                    oIoT_DeviceTag.value = oTag.Value;
                    oIoT_DeviceTag.scale = oTag.scale;
                    oIoT_DeviceTag.offset = oTag.offset;
                    oIoT_DeviceTag.report_flag = oTag.report_flag;
                    oIoT_DeviceTag.db_report_flag = oTag.db_report_flag;
                    oIoT_DeviceTag.clm_date_time = DateTime.Now;
                    oIoT_DeviceTag.clm_user = "SYSADM";

                    //_db.Update(oIoT_TagSet);
                    _db.SaveChanges();
                }
                else
                {

                    oIoT_DeviceTag.device_id = device_id;
                    oIoT_DeviceTag.tag_id = oTag.TagName;
                    oIoT_DeviceTag.tag_desc = oTag.Description;
                    oIoT_DeviceTag.data_type = oTag.Expression;
                    oIoT_DeviceTag.data_unit = oTag.Type;
                    oIoT_DeviceTag.uuid_address = oTag.UUID_Address;
                    oIoT_DeviceTag.value = oTag.Value;
                    oIoT_DeviceTag.scale = oTag.scale;
                    oIoT_DeviceTag.offset = oTag.offset;
                    oIoT_DeviceTag.report_flag = oTag.report_flag;
                    oIoT_DeviceTag.db_report_flag = oTag.db_report_flag;

                    oIoT_DeviceTag.clm_date_time = DateTime.Now;
                    oIoT_DeviceTag.clm_user = "SYSADM";

                    _db.IOT_DEVICE_TAG.Add(oIoT_DeviceTag);
                    _db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveDeviceTagToDB");
            }

        }

        private void SaveDeviceCalcTagToDB(IOT_DbContext _db, cls_CalcTag oCalcTag, string device_id)
        {
            Boolean bExisting = false;

            try
            {
                var vIotDeviceCalcTags = _db.IOT_DEVICE_CALC_TAG.AsQueryable();
                vIotDeviceCalcTags = vIotDeviceCalcTags.Where(c => c.device_id == device_id && c.cal_tag_id == oCalcTag.TagName);
                if (vIotDeviceCalcTags.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_DEVICE_CALC_TAG oIoT_DeviceCalcTag = new IOT_DEVICE_CALC_TAG();

                if (bExisting)
                {
                    oIoT_DeviceCalcTag = vIotDeviceCalcTags.FirstOrDefault();

                    oIoT_DeviceCalcTag.cal_tag_desc = oCalcTag.Description;
                    oIoT_DeviceCalcTag.data_type = oCalcTag.Type;
                    oIoT_DeviceCalcTag.expression = oCalcTag.Expression;

                    oIoT_DeviceCalcTag.value = oCalcTag.Value;
                    oIoT_DeviceCalcTag.param_a = oCalcTag.ParamA;
                    oIoT_DeviceCalcTag.param_b = oCalcTag.ParamB;
                    oIoT_DeviceCalcTag.param_c = oCalcTag.ParamC;
                    oIoT_DeviceCalcTag.param_d = oCalcTag.ParamD;
                    oIoT_DeviceCalcTag.param_e = oCalcTag.ParamE;
                    oIoT_DeviceCalcTag.param_f = oCalcTag.ParamF;
                    oIoT_DeviceCalcTag.param_g = oCalcTag.ParamG;
                    oIoT_DeviceCalcTag.param_h = oCalcTag.ParamH;

                    oIoT_DeviceCalcTag.clm_date_time = DateTime.Now;
                    oIoT_DeviceCalcTag.clm_user = "SYSADM";

                    //_db.Update(oIoT_TagSet);
                    _db.SaveChanges();
                }
                else
                {

                    oIoT_DeviceCalcTag.device_id = device_id;
                    oIoT_DeviceCalcTag.cal_tag_id= oCalcTag.TagName;
                    oIoT_DeviceCalcTag.cal_tag_desc = oCalcTag.Description;
                    oIoT_DeviceCalcTag.data_type = oCalcTag.Type;
                    oIoT_DeviceCalcTag.expression = oCalcTag.Expression;

                    oIoT_DeviceCalcTag.value = oCalcTag.Value;
                    oIoT_DeviceCalcTag.param_a = oCalcTag.ParamA;
                    oIoT_DeviceCalcTag.param_b = oCalcTag.ParamB;
                    oIoT_DeviceCalcTag.param_c = oCalcTag.ParamC;
                    oIoT_DeviceCalcTag.param_d = oCalcTag.ParamD;
                    oIoT_DeviceCalcTag.param_e = oCalcTag.ParamE;
                    oIoT_DeviceCalcTag.param_f = oCalcTag.ParamF;
                    oIoT_DeviceCalcTag.param_g = oCalcTag.ParamG;
                    oIoT_DeviceCalcTag.param_h = oCalcTag.ParamH;

                    oIoT_DeviceCalcTag.clm_date_time = DateTime.Now;
                    oIoT_DeviceCalcTag.clm_user = "SYSADM";

                    _db.IOT_DEVICE_CALC_TAG.Add(oIoT_DeviceCalcTag);
                    _db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveDeviceCalcTagToDB");
            }

        }

        private void SaveTagToDB(IOT_DbContext _db, cls_Tag oTag, string tag_set_id)
        {
            Boolean bExisting = false;

            try
            {
                var vIotTags = _db.IOT_TAG.AsQueryable();
                vIotTags = vIotTags.Where(c => c.tag_set_id == tag_set_id && c.tag_id == oTag.TagName);
                if (vIotTags.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_TAG oIoT_Tag = new IOT_TAG();

                if (bExisting)
                {
                    oIoT_Tag = vIotTags.FirstOrDefault();

                    oIoT_Tag.tag_desc = oTag.Description;
                    oIoT_Tag.data_type = oTag.Expression;
                    oIoT_Tag.data_unit = oTag.Type;
                    oIoT_Tag.uuid_address = oTag.UUID_Address;
                    oIoT_Tag.value = oTag.Value;
                    oIoT_Tag.scale = oTag.scale;
                    oIoT_Tag.offset = oTag.offset;
                    oIoT_Tag.report_flag = oTag.report_flag;
                    oIoT_Tag.db_report_flag = oTag.db_report_flag;
                    oIoT_Tag.clm_date_time = DateTime.Now;
                    oIoT_Tag.clm_user = "SYSADM";

                    //_db.Update(oIoT_TagSet);
                    _db.SaveChanges();
                }
                else
                {

                    oIoT_Tag.tag_set_id = tag_set_id;
                    oIoT_Tag.tag_id = oTag.TagName;
                    oIoT_Tag.tag_desc = oTag.Description;
                    oIoT_Tag.data_type = oTag.Expression;
                    oIoT_Tag.data_unit = oTag.Type;
                    oIoT_Tag.uuid_address = oTag.UUID_Address;
                    oIoT_Tag.value = oTag.Value;
                    oIoT_Tag.scale = oTag.scale;
                    oIoT_Tag.offset = oTag.offset;
                    oIoT_Tag.report_flag = oTag.report_flag;
                    oIoT_Tag.db_report_flag = oTag.db_report_flag;

                    oIoT_Tag.clm_date_time = DateTime.Now;
                    oIoT_Tag.clm_user = "SYSADM";

                    _db.IOT_TAG.Add(oIoT_Tag);
                    _db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveTagToDB");
            }

        }

        private void SaveCalcTagToDB(IOT_DbContext _db, cls_CalcTag oCalcTag, string tag_set_id)
        {
            Boolean bExisting = false;

            try
            {
                var vIotCalcTags = _db.IOT_CALC_TAG.AsQueryable();
                vIotCalcTags = vIotCalcTags.Where(c => c.tag_set_id == tag_set_id && c.cal_tag_id == oCalcTag.TagName);
                if (vIotCalcTags.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_CALC_TAG oIoT_CalcTag = new IOT_CALC_TAG();

                if (bExisting)
                {
                    oIoT_CalcTag = vIotCalcTags.FirstOrDefault();

                    oIoT_CalcTag.cal_tag_desc = oCalcTag.Description;
                    oIoT_CalcTag.data_type = oCalcTag.Type;
                    oIoT_CalcTag.expression = oCalcTag.Expression;

                    oIoT_CalcTag.value = oCalcTag.Value;
                    oIoT_CalcTag.param_a = oCalcTag.ParamA;
                    oIoT_CalcTag.param_b = oCalcTag.ParamB;
                    oIoT_CalcTag.param_c = oCalcTag.ParamC;
                    oIoT_CalcTag.param_d = oCalcTag.ParamD;
                    oIoT_CalcTag.param_e = oCalcTag.ParamE;
                    oIoT_CalcTag.param_f = oCalcTag.ParamF;
                    oIoT_CalcTag.param_g = oCalcTag.ParamG;
                    oIoT_CalcTag.param_h = oCalcTag.ParamH;

                    oIoT_CalcTag.clm_date_time = DateTime.Now;
                    oIoT_CalcTag.clm_user = "SYSADM";

                    //_db.Update(oIoT_TagSet);
                    _db.SaveChanges();
                }
                else
                {

                    oIoT_CalcTag.tag_set_id = tag_set_id;
                    oIoT_CalcTag.cal_tag_id = oCalcTag.TagName;
                    oIoT_CalcTag.cal_tag_desc = oCalcTag.Description;
                    oIoT_CalcTag.data_type = oCalcTag.Type;
                    oIoT_CalcTag.expression = oCalcTag.Expression;

                    oIoT_CalcTag.value = oCalcTag.Value;
                    oIoT_CalcTag.param_a = oCalcTag.ParamA;
                    oIoT_CalcTag.param_b = oCalcTag.ParamB;
                    oIoT_CalcTag.param_c = oCalcTag.ParamC;
                    oIoT_CalcTag.param_d = oCalcTag.ParamD;
                    oIoT_CalcTag.param_e = oCalcTag.ParamE;
                    oIoT_CalcTag.param_f = oCalcTag.ParamF;
                    oIoT_CalcTag.param_g = oCalcTag.ParamG;
                    oIoT_CalcTag.param_h = oCalcTag.ParamH;

                    oIoT_CalcTag.clm_date_time = DateTime.Now;
                    oIoT_CalcTag.clm_user = "SYSADM";

                    _db.IOT_CALC_TAG.Add(oIoT_CalcTag);
                    _db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveCalcTagToDB");
            }

        }

        private void SaveEDC_HeaderSetToDB(IOT_DbContext _db, cls_EDC_Header oEDC_HeaderSet)
        {
            Boolean bExisting = false;

            try
            {
                var vIotEDC_HeaderSets = _db.IOT_EDC_HEADER_SET.AsQueryable();
                vIotEDC_HeaderSets = vIotEDC_HeaderSets.Where(c => c.edc_header_set_id == oEDC_HeaderSet.set_name);
                if (vIotEDC_HeaderSets.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_EDC_HEADER_SET oIoT_EDC_HeaderSet = new IOT_EDC_HEADER_SET();

                if (bExisting)
                {
                    oIoT_EDC_HeaderSet = vIotEDC_HeaderSets.FirstOrDefault();

                    oIoT_EDC_HeaderSet.edc_header_set_desc = oEDC_HeaderSet.set_description;

                    oIoT_EDC_HeaderSet.clm_date_time = DateTime.Now;
                    oIoT_EDC_HeaderSet.clm_user = "SYSADM";

                    //_db.Update(oIoT_TagSet);
                    _db.SaveChanges();
                }
                else
                {
                    oIoT_EDC_HeaderSet.edc_header_set_id = oEDC_HeaderSet.set_name;
                    oIoT_EDC_HeaderSet.edc_header_set_desc = oEDC_HeaderSet.set_description;

                    oIoT_EDC_HeaderSet.clm_date_time = DateTime.Now;
                    oIoT_EDC_HeaderSet.clm_user = "SYSADM";

                    _db.IOT_EDC_HEADER_SET.Add(oIoT_EDC_HeaderSet);
                    _db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveEDC_HeaderSetToDB");
            }

        }

        private void SaveEDC_HeaderToDB(IOT_DbContext _db, cls_EDC_Head_Item oEDC_Header, string edc_header_set_id)
        {
            Boolean bExisting = false;

            try
            {
                var vIotEDC_Headers = _db.IOT_EDC_HEADER.AsQueryable();
                vIotEDC_Headers = vIotEDC_Headers.Where(c => c.edc_header_set_id == edc_header_set_id && c.edc_header_id == oEDC_Header.head_name);
                if (vIotEDC_Headers.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_EDC_HEADER oIoT_EDC_Header = new IOT_EDC_HEADER();

                if (bExisting)
                {
                    oIoT_EDC_Header = vIotEDC_Headers.FirstOrDefault();

                    oIoT_EDC_Header.length = oEDC_Header.length.ToString();
                    oIoT_EDC_Header.value = oEDC_Header.value;
                    oIoT_EDC_Header.clm_date_time = DateTime.Now;
                    oIoT_EDC_Header.clm_user = "SYSADM";

                    //_db.Update(oIoT_TagSet);
                    _db.SaveChanges();
                }
                else
                {

                    oIoT_EDC_Header.edc_header_set_id = edc_header_set_id;
                    oIoT_EDC_Header.edc_header_id = oEDC_Header.head_name;
                    oIoT_EDC_Header.length = oEDC_Header.length.ToString();
                    oIoT_EDC_Header.value = oEDC_Header.value;

                    oIoT_EDC_Header.clm_date_time = DateTime.Now;
                    oIoT_EDC_Header.clm_user = "SYSADM";

                    _db.IOT_EDC_HEADER.Add(oIoT_EDC_Header);
                    _db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveEDC_HeaderToDB");
            }

        }

        private void SaveEDC_XML_ConfigToDB(IOT_DbContext _db, cls_EDC_Info oEDC_Info)
        {
            Boolean bExisting = false;

            try
            {
                var vIotEDC_XML_Configs = _db.IOT_EDC_XML_CONF.AsQueryable();
                vIotEDC_XML_Configs = vIotEDC_XML_Configs.Where(c => c.serial_id == oEDC_Info.serial_id);
                if (vIotEDC_XML_Configs.Count() > 0)
                {
                    bExisting = true;
                }

                IOT_EDC_XML_CONF oIoT_EDC_XML_Config = new IOT_EDC_XML_CONF();

                if (bExisting)
                {
                    oIoT_EDC_XML_Config = vIotEDC_XML_Configs.FirstOrDefault();

                    oIoT_EDC_XML_Config.gateway_id = oEDC_Info.gateway_id;
                    oIoT_EDC_XML_Config.device_id = oEDC_Info.device_id;
                    oIoT_EDC_XML_Config.edc_header_set_id = "EDC_HEADER_SET_ID";
                    oIoT_EDC_XML_Config.report_type = oEDC_Info.report_tpye;
                    oIoT_EDC_XML_Config.report_interval = oEDC_Info.report_interval;
                    oIoT_EDC_XML_Config.report_edc_path = oEDC_Info.ReportEDCPath;
                    oIoT_EDC_XML_Config.avg_flag = "N";
                    oIoT_EDC_XML_Config.max_flag = "N";
                    oIoT_EDC_XML_Config.min_flag = "N";

                    foreach (string s in oEDC_Info.interval_function)
                    {
                        if(s == "AVG")
                        {
                            oIoT_EDC_XML_Config.avg_flag = "Y";
                        }
                        else if(s == "MAX")
                        {
                            oIoT_EDC_XML_Config.max_flag = "Y";
                        }
                        else if(s == "MIN")
                        {
                            oIoT_EDC_XML_Config.min_flag = "Y";
                        }
                    }

                    if (oEDC_Info.enable)
                    {
                        oIoT_EDC_XML_Config.enable = "Y";
                    }
                    else {
                        oIoT_EDC_XML_Config.enable = "N";
                    }
                    

                    oIoT_EDC_XML_Config.clm_date_time = DateTime.Now;
                    oIoT_EDC_XML_Config.clm_user = "SYSADM";

                    //_db.Update(oIoT_TagSet);
                    _db.SaveChanges();
                }
                else
                {

                    oIoT_EDC_XML_Config.serial_id = oEDC_Info.serial_id;
                    oIoT_EDC_XML_Config.gateway_id = oEDC_Info.gateway_id;
                    oIoT_EDC_XML_Config.device_id = oEDC_Info.device_id;
                    oIoT_EDC_XML_Config.edc_header_set_id = "EDC_HEADER_SET_ID";
                    oIoT_EDC_XML_Config.report_type = oEDC_Info.report_tpye;
                    oIoT_EDC_XML_Config.report_interval = oEDC_Info.report_interval;
                    oIoT_EDC_XML_Config.report_edc_path = oEDC_Info.ReportEDCPath;
                    oIoT_EDC_XML_Config.avg_flag = "N";
                    oIoT_EDC_XML_Config.max_flag = "N";
                    oIoT_EDC_XML_Config.min_flag = "N";

                    foreach (string s in oEDC_Info.interval_function)
                    {
                        if (s == "AVG")
                        {
                            oIoT_EDC_XML_Config.avg_flag = "Y";
                        }
                        else if (s == "MAX")
                        {
                            oIoT_EDC_XML_Config.max_flag = "Y";
                        }
                        else if (s == "MIN")
                        {
                            oIoT_EDC_XML_Config.min_flag = "Y";
                        }
                    }


                    if (oEDC_Info.enable)
                    {
                        oIoT_EDC_XML_Config.enable = "Y";
                    }
                    else
                    {
                        oIoT_EDC_XML_Config.enable = "N";
                    }


                    oIoT_EDC_XML_Config.clm_date_time = DateTime.Now;
                    oIoT_EDC_XML_Config.clm_user = "SYSADM";

                    _db.IOT_EDC_XML_CONF.Add(oIoT_EDC_XML_Config);
                    _db.SaveChanges();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message, "SaveEDC_HeaderToDB");
            }

        }

        private void tvNodeList_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Right)
            {
                return;
            }

            TreeNode node_here = tvNodeList.GetNodeAt(e.X, e.Y);
            if(node_here == null)
            {
                return;
            }

            tvNodeList.SelectedNode = node_here;

            switch(tvNodeList.SelectedNode.Tag)
            {
                case TABPAGE_INDEX_GATEWAY_INFO:
                    ctxMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_DEVICE_INFO:
                    ctxMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_TAGSET_INFO:
                    ctxMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_INFO:
                    ctxMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_INFO:
                    ctxMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_DB_CONFIG_INFO:
                    ctxMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_GATEWAY_LIST:
                    ctxAddMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_TAGSET_LIST:
                    ctxAddMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_LIST:
                    ctxAddMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_LIST:
                    ctxAddMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                case TABPAGE_INDEX_DB_CONFIG_LIST:
                    ctxAddMenu.Show(tvNodeList, new Point(e.X, e.Y));
                    break;

                default:
                    return;
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Add Menu Clicked", "Information");
            switch(tvNodeList.SelectedNode.Tag)
            {
                case TABPAGE_INDEX_GATEWAY_LIST:
                    this.ObjectManager.GatewayManager.OnAddGatewayEventCall(e);
                    break;

                case TABPAGE_INDEX_TAGSET_LIST:
                    this.ObjectManager.TagSetManager.OnAddTagSetEventCall(e);
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_LIST:
                    this.header_set.OnAddHeaderSetEventCall(e);
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_LIST:
                    this.ObjectManager.EDCManager.OnAddEDCXmlEventCall(e);
                    break;

                case TABPAGE_INDEX_DB_CONFIG_LIST:
                    this.ObjectManager.DBManager.OnAddDBConfigEventCall(e);
                    break;

                default:
                    return;
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to delete this node?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            switch (tvNodeList.SelectedNode.Tag)
            {
                case TABPAGE_INDEX_GATEWAY_INFO:
                    string gw_id = tvNodeList.SelectedNode.Text.Trim();
                    this.ObjectManager.GatewayManager.gateway_list.Remove(this.ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == gw_id).FirstOrDefault());
                    RefreshGatewayConfig(TABPAGE_INDEX_GATEWAY_LIST);
                    break;

                case TABPAGE_INDEX_DEVICE_INFO:
                    string dv_id = tvNodeList.SelectedNode.Text.Trim();
                    TreeNode pNode = tvNodeList.SelectedNode.Parent;
                    string g_id = pNode.Text.Trim();
                    cls_Gateway_Info gw = this.ObjectManager.GatewayManager.gateway_list.Where(p => p.gateway_id == g_id).FirstOrDefault();
                    if(gw != null)
                    {
                        gw.device_info.Remove(gw.device_info.Where(o => o.device_name == dv_id).FirstOrDefault());
                    }
                    RefreshGatewayConfig(TABPAGE_INDEX_GATEWAY_LIST);
                    break;

                case TABPAGE_INDEX_TAGSET_INFO:
                    string set_id = tvNodeList.SelectedNode.Text.Trim();
                    this.ObjectManager.TagSetManager.tag_set_list.Remove(this.ObjectManager.TagSetManager.tag_set_list.Where(p => p.TagSetName == set_id).FirstOrDefault());
                    RefreshGatewayConfig(TABPAGE_INDEX_TAGSET_LIST);
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_INFO:
                    string header_id = tvNodeList.SelectedNode.Text.Trim();
                    this.header_set.head_set_list.Remove(this.header_set.head_set_list.Where(p => p.set_name == header_id).FirstOrDefault());
                    RefreshGatewayConfig(TABPAGE_INDEX_EDCHEADERSET_LIST);
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_INFO:
                    string[] str_array = tvNodeList.SelectedNode.Text.Split('.');
                    string serial_id = str_array[0];
                    this.ObjectManager.EDCManager.gateway_edc.Remove(this.ObjectManager.EDCManager.gateway_edc.Where(p => p.serial_id == serial_id).FirstOrDefault());
                    RefreshGatewayConfig(TABPAGE_INDEX_EDC_OUTPUT_LIST); 
                    break;

                case TABPAGE_INDEX_DB_CONFIG_INFO:
                    string[] str2_array = tvNodeList.SelectedNode.Text.Split('.');
                    string s_id = str2_array[0];
                    this.ObjectManager.DBManager.dbconfig_list.Remove(this.ObjectManager.DBManager.dbconfig_list.Where(p => p.serial_id == s_id).FirstOrDefault());
                    RefreshGatewayConfig(TABPAGE_INDEX_DB_CONFIG_LIST);
                    break;

                default:
                    return;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (tvNodeList.SelectedNode.Tag)
            {
                case TABPAGE_INDEX_GATEWAY_INFO:
                    DisplayGatewayInfo(true);
                    break;

                case TABPAGE_INDEX_DEVICE_INFO:
                    DisplayDeviceInfo(true);
                    break;

                case TABPAGE_INDEX_TAGSET_INFO:
                    DisplayTagSetInfo(true);
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_INFO:
                    DisplayEDCHeaderSetInfo(true);
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_INFO:
                    DisplayEDCXMLInfo(true);
                    break;

                case TABPAGE_INDEX_DB_CONFIG_INFO:
                    DisplayDBConfigInfo(true);
                    break;

                default:
                    return;
            }
        }

    }
}
