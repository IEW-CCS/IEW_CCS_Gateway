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
    public delegate void SetDBManager(DBManager db_manager);

    public partial class frmListDBConfig : Form
    {
        public DBManager dbm = new DBManager();
        public GateWayManager gateway_mgr = new GateWayManager();
        public SetDBManager delgDBManager;

        public frmListDBConfig(SetDBManager set_db_mgrr, DBManager db_mgr, GateWayManager gw_mgr)
        {
            InitializeComponent();
            this.dbm = (DBManager)db_mgr.Clone();
            this.gateway_mgr = (GateWayManager)gw_mgr.Clone();
            this.delgDBManager = set_db_mgrr;
        }

        private void frmListDBConfig_Load(object sender, EventArgs e)
        {
            lvDBConfigList.BeginUpdate();

            lvDBConfigList.Columns.Clear();
            lvDBConfigList.Columns.Add("Serial ID", 100);
            lvDBConfigList.Columns.Add("Gateway ID", 80);
            lvDBConfigList.Columns.Add("Device ID", 80);
            lvDBConfigList.Columns.Add("Enable", 60);
            lvDBConfigList.Columns.Add("DB Type", 60);
            lvDBConfigList.Columns.Add("Data Source", 80);
            lvDBConfigList.Columns.Add("Port ID", 80);
            lvDBConfigList.Columns.Add("Connect DB", 60);

            lvDBConfigList.Items.Clear();

            lvDBConfigList.EndUpdate();
            RefreshDBConfigList();
        }

        private void RefreshDBConfigList()
        {
            //Setup Database Config List
            lvDBConfigList.BeginUpdate();
            lvDBConfigList.Items.Clear();

            if (this.dbm.dbconfig_list.Count == 0)
            {
                lvDBConfigList.EndUpdate();
                return;
            }

            foreach (cls_DB_Info db in dbm.dbconfig_list)
            {
                ListViewItem lvItem = new ListViewItem(db.serial_id);
                lvItem.SubItems.Add(db.gateway_id);
                lvItem.SubItems.Add(db.device_id);
                if (db.enable)
                {
                    lvItem.SubItems.Add("Y");
                }
                else
                {
                    lvItem.SubItems.Add("N");
                }
                lvItem.SubItems.Add(db.db_type);
                lvItem.SubItems.Add(db.data_source);
                lvItem.SubItems.Add(db.port_id);
                lvItem.SubItems.Add(db.db_name);
                lvDBConfigList.Items.Add(lvItem);
            }
            lvDBConfigList.EndUpdate();
        }

        //Delegate function check duplicate Gateway ID + Device ID
        bool CheckDuplicateDBConfig(string gateway_id, string device_id)
        {
            if(dbm.dbconfig_list.Count > 0)
            {
                cls_DB_Info db = dbm.dbconfig_list.Where(p => p.gateway_id == gateway_id && p.device_id == device_id).FirstOrDefault();
                if(db != null)
                {
                    //MessageBox.Show("Duplicate Gateway ID + Device ID", "Error");
                    return false;
                }
            }
            
            return true;
        }

        //Delegate function to setup DB Config Information
        void SetDBConfigInfo(cls_DB_Info db_info, bool edit_flag)
        {
            if (edit_flag)
            {
                int i = 0;

                if (dbm.dbconfig_list.Count > 0)
                {
                    foreach (cls_DB_Info db in dbm.dbconfig_list)
                    {
                        if (db.serial_id == db_info.serial_id)
                        {
                            break;
                        }
                        i++;
                    }

                    dbm.dbconfig_list[i] = db_info;
                }
            }
            else
            {
                dbm.dbconfig_list.Add(db_info);
            }
        }

        //Delegate function to setup global serial id index
        void SetupDBSerialIDIndex(int index)
        {
            dbm.serial_id_index = index;
        }

        private void btnAddDBConfig_Click(object sender, EventArgs e)
        {
            frmEditDBConfig frm = new frmEditDBConfig(CheckDuplicateDBConfig, SetDBConfigInfo, SetupDBSerialIDIndex, this.gateway_mgr, this.dbm.serial_id_index);
            frm.Owner = this;
            frm.ShowDialog();

            delgDBManager(dbm);
            RefreshDBConfigList();
        }

        private void btnRemoveDBConfig_Click(object sender, EventArgs e)
        {
            string strSerial;

            if (lvDBConfigList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the DB config first!", "Error");
                return;
            }

            if (MessageBox.Show("Are you sure to delete the DB configuration?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                lvDBConfigList.Focus();
                return;
            }

            strSerial = lvDBConfigList.SelectedItems[0].Text;

            int i = 0;
            foreach (cls_DB_Info db in this.dbm.dbconfig_list)
            {
                if (db.serial_id == strSerial)
                {
                    this.dbm.dbconfig_list.RemoveAt(i);
                    break;
                }
                i++;
            }

            delgDBManager(dbm);
            RefreshDBConfigList();
        }

        private void lvDBConfigList_DoubleClick(object sender, EventArgs e)
        {
            string strSerial;
            string strGatewayID;
            string strDeviceID;
            cls_DB_Info dbTemp = new cls_DB_Info();

            if (lvDBConfigList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select the DB config first!", "Error");
                return;
            }

            strSerial = lvDBConfigList.SelectedItems[0].Text.Trim();
            strGatewayID = lvDBConfigList.SelectedItems[0].SubItems[1].Text.Trim();
            strDeviceID = lvDBConfigList.SelectedItems[0].SubItems[2].Text.Trim();

            int i = 0;
            foreach (cls_DB_Info db in this.dbm.dbconfig_list)
            {
                if (db.serial_id == strSerial)
                {
                    dbTemp = this.dbm.dbconfig_list[i];
                    break;
                }
                i++;
            }

            frmEditDBConfig frm = new frmEditDBConfig(SetDBConfigInfo, this.gateway_mgr, dbTemp, strGatewayID, strDeviceID);
            frm.Owner = this;
            frm.ShowDialog();

            dbTemp = null;

            delgDBManager(dbm);
            RefreshDBConfigList();
            lvDBConfigList.Focus();
        }
    }
}
