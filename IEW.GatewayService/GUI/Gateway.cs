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

        //Define TabPages Index
        const int TABPAGE_INDEX_GATEWAY_LIST = 0;
        const int TABPAGE_INDEX_GATEWAY_INFO = 1;
        const int TABPAGE_INDEX_DEVICE_INFO = 2;
        const int TABPAGE_INDEX_TAGSET_LIST = 3;
        const int TABPAGE_INDEX_TAGSET_INFO = 4;

        TreeNode objSelectedNode;
        List<Panel> Panels = new List<Panel>();
        Panel VisiblePanel = null;
        public cls_Gateway_Info gw;
        bool isLoadConfig;

        public Gateway()
        {
            InitializeComponent();
        }

        private void Gateway_Load(object sender, EventArgs e)
        {
            //this.gw_array = null;
            this.objSelectedNode = null;

            tvNodeList.BeginUpdate();
            TreeNode tNode = tvNodeList.Nodes.Add("Gateway List");
            tNode.Tag = TABPAGE_INDEX_GATEWAY_LIST;
            tNode.ImageIndex = 0;

            tNode = tvNodeList.Nodes.Add("Tag Set List");
            tNode.Tag = TABPAGE_INDEX_TAGSET_LIST;
            tNode.ImageIndex = 3;
            tvNodeList.EndUpdate();
            this.isLoadConfig = false;

            tcInfo.Visible = false;

            foreach (TabPage page in tcInfo.TabPages)
            {
                // Add the Panel to the list.
                Panel panel = page.Controls[0] as Panel;
                panel.Height = tvNodeList.Height;
                panel.Width = tcInfo.Width;
                Panels.Add(panel);

                // Reparent and move the Panel.
                panel.Parent = tcInfo.Parent;
                panel.Location = tcInfo.Location;
                panel.Visible = false;
            }
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

            tvNodeList.ExpandAll();
            tvNodeList.EndUpdate();

            DisplayPanel(TABPAGE_INDEX_GATEWAY_LIST);
            DisplayGatewayList();
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

        // Display the appropriate Panel.
        private void DisplayPanel(int index)
        {
            if (Panels.Count < 1)
                return;

            // If this is the same Panel, do nothing.
            if (VisiblePanel == Panels[index])
                return;

            // Hide the previously visible Panel.
            if (VisiblePanel != null) VisiblePanel.Visible = false;

            // Display the appropriate Panel.
            Panels[index].Visible = true;
            VisiblePanel = Panels[index];
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
                     
                default:
                    break;
            }
        }

        private void DisplayGatewayList()
        {
            lvGatewayList.BeginUpdate();

            lvGatewayList.Columns.Clear();
            lvGatewayList.Columns.Add("Gateway ID", 100);
            lvGatewayList.Columns.Add("Gateway IP", 100);
            lvGatewayList.Columns.Add("Device Count", 100);
            
            lvGatewayList.Items.Clear();

            if(ObjectManager.GatewayManager.gateway_list.Count == 0)
            {
                lvGatewayList.EndUpdate();
                return;
            }

            foreach( cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list )
            {
                ListViewItem lvItem = new ListViewItem(gi.gateway_id);
                lvItem.SubItems.Add(gi.gateway_ip);
                lvItem.SubItems.Add(gi.device_info.Count().ToString());
                lvGatewayList.Items.Add(lvItem);
            }

            lvGatewayList.EndUpdate();
        }

        private void DisplayGatewayInfo(int index)
        {
            TreeNode tNode = tvNodeList.SelectedNode;
            //MessageBox.Show(tNode.Text, "Information");

            int i = 0;
            foreach(cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
            {
                if(gi.gateway_id == tNode.Text)
                {
                    break;
                }
                i++;
            }

            frmEditGateway gwForm = new frmEditGateway(ObjectManager.GatewayManager.gateway_list[i], i);
            gwForm.Owner = this;
            gwForm.TopLevel = false;
            gwForm.FormBorderStyle = FormBorderStyle.None;
            this.Panels[index].Controls.Add(gwForm);
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
            this.Panels[index].Controls.Add(deviceForm);
            deviceForm.Show();
        }

        private void DispalyTagSetList(int index)
        {
            lvTagSetList.BeginUpdate();

            lvTagSetList.Columns.Clear();
            lvTagSetList.Columns.Add("Tag Set Name", 100);
            lvTagSetList.Columns.Add("Tag Count", 80);
            lvTagSetList.Columns.Add("Tag Set Description", 200);

            lvTagSetList.Items.Clear();

            if (ObjectManager.TagSetManager.tag_set_list.Count == 0)
            {
                lvTagSetList.EndUpdate();
                return;
            }

            foreach (cls_Tag_Set ts in ObjectManager.TagSetManager.tag_set_list)
            {
                ListViewItem lvItem = new ListViewItem(ts.TagSetName);
                lvItem.SubItems.Add(ts.tag_set.Count().ToString());
                lvItem.SubItems.Add(ts.TagSetDescription);
                lvTagSetList.Items.Add(lvItem);
            }

            lvTagSetList.EndUpdate();
        }

        private void DisplayTagSetInfo(int index)
        {

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

                var json_string = inputFile.ReadToEnd();

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

                var json_string = inputFile.ReadToEnd();

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

        private void SaveGatewayConfig()
        {
            string json_string;

            json_string = ObjectManager.GatewayManager_ToJson_String();
            StreamWriter output = new StreamWriter("C:\\Gateway\\Config\\Gateway_Device_Config.json");
            output.Write(json_string);
            output.Close();
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            SaveGatewayConfig();
        }

        private void lvGatewayList_DoubleClick(object sender, EventArgs e)
        {
            string strGatewayID;
            cls_Gateway_Info gwTemp = new cls_Gateway_Info();

            if (lvGatewayList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the gateway first!", "Error");
                return;
            }

            strGatewayID = lvGatewayList.SelectedItems[0].Text.Trim();

            int i = 0;
            foreach (cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
            {
                if (gi.gateway_id == strGatewayID)
                {
                    gwTemp = ObjectManager.GatewayManager.gateway_list[i];
                    break;
                }
                i++;
            }

            var frm = new frmEditGateway(gwTemp, i);
            frm.Owner = this;
            frm.ShowDialog();

            gwTemp = null;

            RefreshGatewayConfig();
            lvGatewayList.Focus();
        }

        private void btnRemoveGateway_Click(object sender, EventArgs e)
        {
            string strGatewayID;

            if( lvGatewayList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the gateway first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the gateway?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvGatewayList.Focus();
                return;
            }

            strGatewayID = lvGatewayList.SelectedItems[0].Text;

            int i = 0;
            foreach ( cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list)
            {
                if ( gi.gateway_id == strGatewayID )
                {
                    ObjectManager.GatewayManager.gateway_list.RemoveAt(i);
                    break;
                }
                i++;
            }

            RefreshGatewayConfig();
        }

        private void btnAddTagSetTemplate_Click(object sender, EventArgs e)
        {
            frmEditTagSetTemplate frm = new frmEditTagSetTemplate();
            frm.Owner = this;
            frm.ShowDialog();
        }

        private void lvTagSetList_DoubleClick(object sender, EventArgs e)
        {
            string strTagSetName;
            cls_Tag_Set tmpTagSet = new cls_Tag_Set();

            if (lvTagSetList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the tag set first!", "Error");
                return;
            }

            strTagSetName = lvTagSetList.SelectedItems[0].Text.Trim();

            int i = 0;
            foreach (cls_Tag_Set ts in ObjectManager.TagSetManager.tag_set_list)
            {
                if (ts.TagSetName == strTagSetName)
                {
                    tmpTagSet = ObjectManager.TagSetManager.tag_set_list[i];
                    break;
                }
                i++;
            }

            var frm = new frmEditTagSetTemplate(tmpTagSet, i);
            frm.Owner = this;
            frm.ShowDialog();

            tmpTagSet = null;

            RefreshGatewayConfig();
            lvTagSetList.Focus();
        }
    }
}
