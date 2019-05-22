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
            if(LoadGatewayConfig())
            {
                RefreshGatewayConfig();
            }
        }

        private void RefreshGatewayConfig()
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

            // Temp data
            tNode = tvNodeList.Nodes[NODE_INDEX_TAG_SET_LIST].Nodes.Add("Tag Set 1");
            tNode.Tag = TABPAGE_INDEX_TAGSET_INFO;
            tNode.ImageIndex = 4;

            tNode = tvNodeList.Nodes[NODE_INDEX_TAG_SET_LIST].Nodes.Add("Tag Set 2");
            tNode.Tag = TABPAGE_INDEX_TAGSET_INFO;
            tNode.ImageIndex = 4;

            tvNodeList.ExpandAll();
            tvNodeList.EndUpdate();

            DisplayPanel(TABPAGE_INDEX_GATEWAY_LIST);
            DisplayGatewayList();
        }

        private void tvNodeList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            objSelectedNode = e.Node;

            //MessageBox.Show(objSelectedNode.Text + ": Tag = " + e.Node.Tag.ToString(), "Information");

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
                    break;

                case TABPAGE_INDEX_DEVICE_INFO:
                    break;

                case TABPAGE_INDEX_TAGSET_LIST:
                    break;

                case TABPAGE_INDEX_TAGSET_INFO:
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
            
            foreach( cls_Gateway_Info gi in ObjectManager.GatewayManager.gateway_list )
            {
                ListViewItem lvItem = new ListViewItem(gi.gateway_id);
                lvItem.SubItems.Add(gi.gateway_ip);
                lvItem.SubItems.Add(gi.device_info.Count().ToString());
                lvGatewayList.Items.Add(lvItem);
            }

            lvGatewayList.EndUpdate();
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
                //ObjectManager.GatewayManager.gateway_list = null;
                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\Gateway_Device_Config.json");

                var json_string = inputFile.ReadToEnd();

                ObjectManager.GatewayManager_Initial(json_string);

                if (ObjectManager.GatewayManager.gateway_list == null)
                {
                    MessageBox.Show("No device exists!", "Information");
                    return false;
                }

                inputFile.Close();
            }
            catch
            {
                MessageBox.Show("Config file loading error!", "Error");
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
    }
}
