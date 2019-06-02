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
    public delegate void SetGatewayManager(GateWayManager gw_manager);

    public partial class frmListGateway : Form
    {
        public GateWayManager gm = new GateWayManager();
        public SetGatewayManager delgGWManager;

        public frmListGateway(SetGatewayManager set_gm, GateWayManager gw)
        {
            InitializeComponent();
            this.gm = gw;
            this.delgGWManager = set_gm;
        }

        private void frmListGateway_Load(object sender, EventArgs e)
        {
            lvGatewayList.BeginUpdate();

            lvGatewayList.Columns.Clear();
            lvGatewayList.Columns.Add("Gateway ID", 100);
            lvGatewayList.Columns.Add("Gateway IP", 100);
            lvGatewayList.Columns.Add("Device Count", 100);
            lvGatewayList.EndUpdate();
            RefreshGatewayList();
        }

        private void RefreshGatewayList()
        {
            lvGatewayList.BeginUpdate();

            lvGatewayList.Items.Clear();
            if (gm.gateway_list.Count == 0)
            {
                lvGatewayList.EndUpdate();
                return;
            }

            foreach (cls_Gateway_Info gi in gm.gateway_list)
            {
                ListViewItem lvItem = new ListViewItem(gi.gateway_id);
                lvItem.SubItems.Add(gi.gateway_ip);
                lvItem.SubItems.Add(gi.device_info.Count().ToString());
                lvGatewayList.Items.Add(lvItem);
            }
            lvGatewayList.EndUpdate();
        }

        //Delegate function to add Gateway Information
        void SetGatewayInfo(cls_Gateway_Info g_info, bool edit_flag)
        {
            if(edit_flag)
            {
                int i = 0;

                if (gm.gateway_list.Count > 0)
                {
                    foreach (cls_Gateway_Info gi in gm.gateway_list)
                    {
                        if (gi.gateway_id == g_info.gateway_id)
                        {
                            break;
                        }
                        i++;
                    }

                    gm.gateway_list[i] = g_info;
                }
            }
            else
            {
                gm.gateway_list.Add(g_info);
            }
        }

        //Delegate function to check gateway id is duplicate or not
        bool CheckDuplicateGateway(string gw_name)
        {
            if (gm.gateway_list.Count > 0)
            {
                foreach(cls_Gateway_Info gi in gm.gateway_list)
                {
                    if(gi.gateway_id == gw_name)
                    {
                        MessageBox.Show("Duplicate gateway id!", "Error");
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnAddGateway_Click(object sender, EventArgs e)
        {
            //var frm = new frmEditGateway();
            var frm = new frmEditGateway(SetGatewayInfo, CheckDuplicateGateway, false);
            frm.Owner = this;
            frm.ShowDialog();

            delgGWManager(gm);
            RefreshGatewayList();
        }

        private void btnRemoveGateway_Click(object sender, EventArgs e)
        {
            string strGatewayID;

            if (lvGatewayList.SelectedItems.Count == 0)
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
            foreach (cls_Gateway_Info gi in this.gm.gateway_list)
            {
                if (gi.gateway_id == strGatewayID)
                {
                    this.gm.gateway_list.RemoveAt(i);
                    break;
                }
                i++;
            }

            delgGWManager(gm);
            RefreshGatewayList();
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
            foreach (cls_Gateway_Info gi in this.gm.gateway_list)
            {
                if (gi.gateway_id == strGatewayID)
                {
                    gwTemp = this.gm.gateway_list[i];
                    break;
                }
                i++;
            }

            var frm = new frmEditGateway(SetGatewayInfo, gwTemp, i);
            frm.Owner = this;
            frm.ShowDialog();

            gwTemp = null;

            RefreshGatewayList();
            lvGatewayList.Focus();
        }

    }
}
