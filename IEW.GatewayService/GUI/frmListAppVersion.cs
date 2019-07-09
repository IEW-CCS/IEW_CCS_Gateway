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
    public partial class frmListAppVersion : Form
    {
        public VersionManager ver_mgr = new VersionManager();

        public frmListAppVersion()
        {
            InitializeComponent();
        }

        public frmListAppVersion(VersionManager vm)
        {
            this.ver_mgr = vm;
            InitializeComponent();
        }

        private void frmListGatewayVersion_Load(object sender, EventArgs e)
        {
            lvVersionList.BeginUpdate();

            lvVersionList.Columns.Clear();
            lvVersionList.Columns.Add("Application", 100);
            lvVersionList.Columns.Add("Newest Version", 80);
            lvVersionList.Columns.Add("Update Time", 140);

            lvVersionList.Items.Clear();

            lvVersionList.EndUpdate();
            RefreshVersionList();
        }

        private void RefreshVersionList()
        {
            lvVersionList.BeginUpdate();
            lvVersionList.Items.Clear();
            if (this.ver_mgr.version_list.Count > 0)
            {
                foreach(KeyValuePair<string, List<cls_Version_Info>> kv in this.ver_mgr.version_list)
                {
                    if(kv.Value.Count > 0)
                    {
                        ListViewItem lvItem = new ListViewItem(kv.Key);
                        //Select the newest update time verson object from list
                        cls_Version_Info ver = kv.Value.OrderByDescending(p => p.update_time).FirstOrDefault();
                        lvItem.SubItems.Add(ver.ap_version);
                        lvItem.SubItems.Add(ver.update_time.ToString());
                        lvVersionList.Items.Add(lvItem);
                    }
                }
            }

            lvVersionList.EndUpdate();
        }
    }
}
