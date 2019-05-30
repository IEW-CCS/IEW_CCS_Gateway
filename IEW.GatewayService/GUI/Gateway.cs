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

        //Define TabPages Index
        const int TABPAGE_INDEX_GATEWAY_LIST = 0;
        const int TABPAGE_INDEX_GATEWAY_INFO = 1;
        const int TABPAGE_INDEX_DEVICE_INFO = 2;
        const int TABPAGE_INDEX_TAGSET_LIST = 3;
        const int TABPAGE_INDEX_TAGSET_INFO = 4;
        const int TABPAGE_INDEX_EDCHEADERSET_LIST = 5;
        const int TABPAGE_INDEX_EDCHEADERSET_INFO = 6;

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
            tvNodeList.EndUpdate();

            tNode = tvNodeList.Nodes.Add("EDC Header Set List");
            tNode.Tag = TABPAGE_INDEX_EDCHEADERSET_LIST;
            tNode.ImageIndex = 8;
            tvNodeList.EndUpdate();

            this.isLoadConfig = false;

            pnlMain.Height = tvNodeList.Height;
        }

        private void btnCmdDownload_Click(object sender, EventArgs e)
        {

            //Json.cls_Collect_Json Json = new Json.cls_Collect_Json();
            /*
            Json.Collect_JSON_OBJECT.Cmd_Type = "Collect";
            Json.Collect_JSON_OBJECT.Report_Interval = "10";
            Json.Collect_JSON_OBJECT.Trace_ID = "123456";

            Json.cls_Device_Info Info = new Json.cls_Device_Info();
            Info.MAC = "ABCDE";
            Info.Service_UUID.Add("UUID12345677");
            Info.Service_UUID.Add("UUID12345677");
            Json.Collect_JSON_OBJECT.Device_Info.Add(Info);
        
            //---------------------------------------------------
            Json.cls_Device_Info Info2 = new Json.cls_Device_Info();
            Info2.MAC = "MC2";
            Info2.Service_UUID.Add("UUID55556666");
            Info2.Service_UUID.Add("UUID77778888");
            Json.Collect_JSON_OBJECT.Device_Info.Add(Info2);
            */
            //string tmp_json = Json.To_Json_String();

            // 以下程式碼是反向檢查是否字串塞進物件可以使用
            // Json.cls_Collect_Json JsonOut = new Json.cls_Collect_Json(tmp_json);


            //IEW.Platform.Kernel.Platform.Instance.Invoke("GatewayService", "GateWay_Collect_Cmd_Download", new object[] { tmp_json });
        }

        public void Init()
        {
        }

        private void btnLoadConfig_Click(object sender, EventArgs e)
        {
            if (LoadGatewayConfig())
            {
                this.isLoadConfig = true;
            }
            else
            {
                return;
            }

            LoadTagSetConfig();
            RefreshGatewayConfig();
        }

        public void RefreshGatewayConfig()
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

            tvNodeList.ExpandAll();
            tvNodeList.EndUpdate();

            DisplayPanel(TABPAGE_INDEX_GATEWAY_LIST);
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
                    DisplayGatewayInfo(index);
                    break;

                case TABPAGE_INDEX_DEVICE_INFO:
                    DisplayDeviceInfo(index);
                    break;

                case TABPAGE_INDEX_TAGSET_LIST:
                    DispalyTagSetList(index);
                    break;

                case TABPAGE_INDEX_TAGSET_INFO:
                    DisplayTagSetInfo(index);
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_LIST:
                    DisplayEDCHeaderSetList(index);
                    break;

                case TABPAGE_INDEX_EDCHEADERSET_INFO:
                    DisplayEDCHeaderSetInfo(index);
                    break;

                default:
                    break;
            }
        }

        //Delegate function to update GateWayManager information
        void SetGatewayManager(GateWayManager g_manager)
        {
            ObjectManager.GatewayManager.gateway_list = g_manager.gateway_list;
            RefreshGatewayConfig();
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

            RefreshGatewayConfig();
        }

        //Delegate function to update TagSetManager information
        void SetTagSetManager(TagSetManager tsManager)
        {
            ObjectManager.TagSetManager.tag_set_list = tsManager.tag_set_list;
            RefreshGatewayConfig();
        }

        void SetEDCHeaderSetList(EDCHeaderSet edc_set_list)
        {
            this.header_set = edc_set_list;
            RefreshGatewayConfig();
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

            RefreshGatewayConfig();
        }

        private void DisplayGatewayList()
        {
            frmListGateway gwList = new frmListGateway(SetGatewayManager, ObjectManager.GatewayManager);
            gwList.Owner = this;
            gwList.TopLevel = false;
            gwList.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                pnlMain.Controls.RemoveAt(0);
            }
            pnlMain.Controls.Add(gwList);
            gwList.Show();
        }

        private void DisplayGatewayInfo(int index)
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
                pnlMain.Controls.RemoveAt(0);
            }
            pnlMain.Controls.Add(gwForm);

            gwForm.Show();
        }

        private void DisplayDeviceInfo(int index)
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
                pnlMain.Controls.RemoveAt(0);
            }
            pnlMain.Controls.Add(deviceForm);

            deviceForm.Show();
        }

        private void DispalyTagSetList(int index)
        {
            frmListTagSet setList = new frmListTagSet(SetTagSetManager, ObjectManager.TagSetManager);
            setList.Owner = this;
            setList.TopLevel = false;
            setList.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                pnlMain.Controls.RemoveAt(0);
            }
            pnlMain.Controls.Add(setList);
            setList.Show();

        }

        private void DisplayTagSetInfo(int index)
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

            frmEditTagSetTemplate frm = new frmEditTagSetTemplate(ObjectManager.TagSetManager.tag_set_list[i], i);
            frm.Owner = this;
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                pnlMain.Controls.RemoveAt(0);
            }
            pnlMain.Controls.Add(frm);

            frm.Show();
        }

        private void DisplayEDCHeaderSetList(int index)
        {
            frmListEDCHeaderSet headerList = new frmListEDCHeaderSet(SetEDCHeaderSetList, this.header_set);
            headerList.Owner = this;
            headerList.TopLevel = false;
            headerList.FormBorderStyle = FormBorderStyle.None;
            if (pnlMain.Controls.Count > 0)
            {
                pnlMain.Controls.RemoveAt(0);
            }
            pnlMain.Controls.Add(headerList);
            headerList.Show();
        }

        private void DisplayEDCHeaderSetInfo(int index)
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
                pnlMain.Controls.RemoveAt(0);
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
            RefreshGatewayConfig();
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

                ObjectManager.GatewayManager_Initial(json_string);

                if (ObjectManager.GatewayManager.gateway_list == null)
                {
                    MessageBox.Show("No gateway exists!", "Warning");
                    return false;
                }

                inputFile.Close();
            }
            catch
            {
                MessageBox.Show("Gateway config file loading error!", "Error");
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


        private void SaveGatewayConfig()
        {
            string json_string;

            json_string = ObjectManager.GatewayManager_ToJson_String();
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

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveGatewayConfig();
            SaveTagSetConfig();
            SaveEDCHeaderSetConfig();
        }
        
    }
}
