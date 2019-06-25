using System;
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

        static int NODE_INDEX_GATEWAY_LIST = 0;
        static int NODE_INDEX_TAG_SET_LIST = 1;
        static int NODE_INDEX_EDC_HEADER_SET_LIST = 2;
        static int NODE_INDEX_EDC_OUTPUT_LIST = 3;
        static int NODE_INDEX_DB_CONFIG = 4;
        static int NODE_INDEX_ON_LINE_MONITOR = 5;

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

        TreeNode objSelectedNode;
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

            tNode = tvNodeList.Nodes.Add("Tag Set List");
            tNode.Tag = TABPAGE_INDEX_TAGSET_LIST;
            tNode.ImageIndex = 3;

            tNode = tvNodeList.Nodes.Add("EDC Header Set List");
            tNode.Tag = TABPAGE_INDEX_EDCHEADERSET_LIST;
            tNode.ImageIndex = 8;

            tNode = tvNodeList.Nodes.Add("EDC XML Output Config List");
            tNode.Tag = TABPAGE_INDEX_EDC_OUTPUT_LIST;
            tNode.ImageIndex = 9;

            tNode = tvNodeList.Nodes.Add("Database Config");
            tNode.Tag = TABPAGE_INDEX_DB_CONFIG_LIST;
            tNode.ImageIndex = 12;

            tNode = tvNodeList.Nodes.Add("On-Line Monitor");
            tNode.Tag = TABPAGE_INDEX_ON_LINE_MONITOR;
            tNode.ImageIndex = 11;

            tvNodeList.EndUpdate();

            this.isLoadConfig = false;

            pnlMain.Height = tvNodeList.Height;
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

                foreach (cls_Device_Info di in gi.device_info)
                {
                    tNode = tvNodeList.Nodes[NODE_INDEX_GATEWAY_LIST].Nodes[j].Nodes.Add(di.device_name);
                    tNode.Tag = TABPAGE_INDEX_DEVICE_INFO;
                    tNode.ImageIndex = 2;
                }
                j++;
            }

            foreach(cls_Tag_Set ts in ObjectManager.TagSetManager.tag_set_list)
            {
                tNode = tvNodeList.Nodes[NODE_INDEX_TAG_SET_LIST].Nodes.Add(ts.TagSetName);
                tNode.Tag = TABPAGE_INDEX_TAGSET_INFO;
                tNode.ImageIndex = 4;
            }

            foreach (cls_EDC_Header hs in this.header_set.head_set_list)
            {
                tNode = tvNodeList.Nodes[NODE_INDEX_EDC_HEADER_SET_LIST].Nodes.Add(hs.set_name);
                tNode.Tag = TABPAGE_INDEX_EDCHEADERSET_INFO;
                tNode.ImageIndex = 7;
            }

            if(ObjectManager.EDCManager.gateway_edc.Count > 0)
            {
                foreach (cls_EDC_Info edc_info in ObjectManager.EDCManager.gateway_edc)
                {
                    tNode = tvNodeList.Nodes[NODE_INDEX_EDC_OUTPUT_LIST].Nodes.Add(edc_info.serial_id + "." + edc_info.gateway_id + "." + edc_info.device_id);
                    tNode.Tag = TABPAGE_INDEX_EDC_OUTPUT_INFO;
                    tNode.ImageIndex = 10;
                }
            }

            if (ObjectManager.DBManager.dbconfig_list.Count > 0)
            {
                foreach (cls_DB_Info db_info in ObjectManager.DBManager.dbconfig_list)
                {
                    tNode = tvNodeList.Nodes[NODE_INDEX_DB_CONFIG].Nodes.Add(db_info.serial_id + "." + db_info.gateway_id + "." + db_info.device_id);
                    tNode.Tag = TABPAGE_INDEX_DB_CONFIG_INFO;
                    tNode.ImageIndex = 13;
                }
            }

            tvNodeList.ExpandAll();
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
                    DisplayGatewayInfo();
                    break;

                case TABPAGE_INDEX_DEVICE_INFO:
                    DisplayDeviceInfo();
                    break;

                case TABPAGE_INDEX_TAGSET_LIST:
                    DispalyTagSetList();
                    break;

                case TABPAGE_INDEX_TAGSET_INFO:
                    DisplayTagSetInfo();
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_LIST:
                    DisplayEDCHeaderSetList();
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_INFO:
                    DisplayEDCHeaderSetInfo();
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_LIST:
                    DisplayEDCXMLList();
                    break;

                case TABPAGE_INDEX_EDC_OUTPUT_INFO:
                    DisplayEDCXMLInfo();
                    break;

                case TABPAGE_INDEX_ON_LINE_MONITOR:
                    DisplayOnlineMonitor();
                    break;

                case TABPAGE_INDEX_DB_CONFIG_LIST:
                    DisplayDBConfigList();
                    break;

                case TABPAGE_INDEX_DB_CONFIG_INFO:
                    DisplayDBConfigInfo();
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
            }

            RefreshGatewayConfig(TABPAGE_INDEX_DB_CONFIG_LIST);
        }

        private void DisplayGatewayList()
        {
            frmListGateway gwList = new frmListGateway(SetGatewayManager, ObjectManager.GatewayManager);
            gwList.Owner = this;
            gwList.TopLevel = false;
            gwList.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(gwList);
            gwList.Show();
        }

        private void DisplayGatewayInfo()
        {
            TreeNode tNode = tvNodeList.SelectedNode;

            int i = 0;
            foreach(cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
            {
                if(gi.gateway_id == tNode.Text)
                {
                    break;
                }
                i++;
            }

            frmEditGateway gwForm = new frmEditGateway(SetGatewayInfo, ObjectManager.GatewayManager.gateway_list[i], i);
            gwForm.Owner = this;
            gwForm.TopLevel = false;
            gwForm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(gwForm);

            gwForm.Show();
        }

        private void DisplayDeviceInfo()
        {
            TreeNode tNode = tvNodeList.SelectedNode;  // Device Node
            TreeNode pNode = tNode.Parent;                    // Gateway Node

            int i = 0;
            int j = 0;
            foreach (cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
            {
                if (gi.gateway_id == pNode.Text)
                {
                    foreach (cls_Device_Info dv in ObjectManager.GatewayManager.gateway_list[i].device_info)
                    {
                        if(dv.device_name == tNode.Text)
                        {
                            break;
                        }
                        j++;
                    }
                    break;
                }
                i++;
            }

            frmEditDevice deviceForm = new frmEditDevice(ObjectManager.GatewayManager.gateway_list[i], ObjectManager.GatewayManager.gateway_list[i].device_info[j], j);
            deviceForm.Owner = this;
            deviceForm.TopLevel = false;
            deviceForm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(deviceForm);

            deviceForm.Show();
        }

        private void DispalyTagSetList()
        {
            frmListTagSet setList = new frmListTagSet(SetTagSetManager, ObjectManager.TagSetManager);
            setList.Owner = this;
            setList.TopLevel = false;
            setList.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(setList);
            setList.Show();
        }

        private void DisplayTagSetInfo()
        {
            TreeNode tNode = tvNodeList.SelectedNode;  // Tag Set Node

            int i = 0;
            foreach(cls_Tag_Set tag_set in ObjectManager.TagSetManager.tag_set_list)
            {
                if(tag_set.TagSetName == tNode.Text)
                {
                    break;
                }
                i++;
            }

            frmEditTagSetTemplate frm = new frmEditTagSetTemplate(SetTagSetInfo, ObjectManager.TagSetManager.tag_set_list[i], i);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(frm);

            frm.Show();
        }

        private void DisplayEDCHeaderSetList()
        {
            frmListEDCHeaderSet headerList = new frmListEDCHeaderSet(SetEDCHeaderSetList, this.header_set);
            headerList.Owner = this;
            headerList.TopLevel = false;
            headerList.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(headerList);
            headerList.Show();
        }

        private void DisplayEDCHeaderSetInfo()
        {
            TreeNode tNode = tvNodeList.SelectedNode;  // Header Set Info Node

            int i = 0;
            foreach (cls_EDC_Header hs in this.header_set.head_set_list)
            {
                if (hs.set_name == tNode.Text)
                {
                    break;
                }
                i++;
            }

            frmEditEDCHeader frm = new frmEditEDCHeader(SetEDCHeaderSetInfo, this.header_set.head_set_list[i], i);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(frm);

            frm.Show();
        }

        private void DisplayEDCXMLList()
        {
            frmListEDCXml frm = new frmListEDCXml(EDCManager, ObjectManager.EDCManager, ObjectManager.GatewayManager);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayEDCXMLInfo()
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
            foreach(cls_EDC_Info edc in ObjectManager.EDCManager.gateway_edc)
            {
                if(edc.serial_id == strSerial)
                {
                    break;
                }
                i++;
            }

            frmEditEDCXml frm = new frmEditEDCXml(SetEDCXmlInfo, ObjectManager.GatewayManager, ObjectManager.EDCManager.gateway_edc[i], strGatewayID, strDeviceID);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(frm);

            frm.Show();
        }

        private void DisplayOnlineMonitor()
        {
            frmOnlineMonitor frm = new frmOnlineMonitor(this.ObjectManager);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayDBConfigList()
        {
            frmListDBConfig frm = new frmListDBConfig(SetDBManager, ObjectManager.DBManager, ObjectManager.GatewayManager);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void DisplayDBConfigInfo()
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
            foreach (cls_DB_Info db in ObjectManager.DBManager.dbconfig_list)
            {
                if (db.serial_id == strSerial)
                {
                    break;
                }
                i++;
            }

            frmEditDBConfig frm = new frmEditDBConfig(SetDBConfigInfo, ObjectManager.GatewayManager, ObjectManager.DBManager.dbconfig_list[i], strGatewayID, strDeviceID);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                //pnlMain.Controls.RemoveAt(0);
                pnlMain.Controls[0].Dispose();
            }
            pnlMain.Controls.Add(frm);

            frm.Show();
        }

        public void SetDeviceInfo(cls_Gateway_Info gi, cls_Device_Info di, int index)
        {
            gi.device_info[index] = di;
        }

        private void btnAddGateway_Click(object sender, EventArgs e)
        {
            var frm = new frmEditGateway();
            frm.Owner = this;
            frm.ShowDialog();

            gw = null;
            RefreshGatewayConfig(TABPAGE_INDEX_GATEWAY_LIST);
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
            catch
            {
                MessageBox.Show("Tag Set config file loading error!", "Error");
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
            catch
            {
                MessageBox.Show("EDC Header Set config file loading error!", "Error");
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
            catch
            {
                MessageBox.Show("EDC XML config file loading error!", "Error");
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
            catch
            {
                MessageBox.Show("DB config file loading error!", "Error");
                return false;
            }

            return true;
        }

        private void LoadMonitorConfig()
        {
            ObjectManager.MonitorManager_Initial();

            if (ObjectManager.GatewayManager.gateway_list.Count > 0)
            {
                foreach (cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
                {
                    cls_Monitor_Gateway_Info mgi = new cls_Monitor_Gateway_Info();
                    mgi.gateway_id = gi.gateway_id;
                    mgi.gateway_ip = gi.gateway_ip;
                    mgi.gateway_location = gi.location;
                    mgi.gateway_status = "Off";
                    mgi.iotclient_status = "Off";

                    if (gi.device_info.Count > 0)
                    {
                        foreach (cls_Device_Info di in gi.device_info)
                        {
                            cls_Monitor_Device_info mdi = new cls_Monitor_Device_info();
                            mdi.device_id = di.device_name;
                            mdi.device_status = "Off";
                            mdi.plc_ip = di.plc_ip_address;
                            mdi.plc_port = di.plc_port_id;
                            mgi.device_list.Add(mdi);
                        }

                    }
                    ObjectManager.MonitorManager.monitor_list.Add(mgi);
                }
            }
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

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveGatewayConfig();
            SaveTagSetConfig();
            SaveEDCHeaderSetConfig();
            SaveEDCXmlConfig();
            SaveDBConfig();
        }
    }
}
