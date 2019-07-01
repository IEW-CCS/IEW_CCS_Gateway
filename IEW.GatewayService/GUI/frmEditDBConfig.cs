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
using System.IO;
using Newtonsoft.Json;


namespace IEW.GatewayService.GUI
{
    public delegate void SetDBInfo(cls_DB_Info db_info, bool edit_flag);
    public delegate void SetDBSerial(int index);
    public delegate bool CheckDuplicate(string gateway_id, string device_id);

    public partial class frmEditDBConfig : Form
    {
        bool isEdit;
        int gateway_index;
        int device_index;
        int serial_index;
        string gateway_id;
        string device_id;
        string password;

        public GateWayManager gateway_mgr;
        public cls_DB_Info db_data;
        public CheckDuplicate delgCheckDuplicate;
        public SetDBInfo delgSetDBInfo;
        public SetDBSerial delgSetDBSerial;

        public frmEditDBConfig()
        {
            InitializeComponent();
            this.isEdit = false;
        }

        //Constructor to Add New DB Config Information
        public frmEditDBConfig(CheckDuplicate check, SetDBInfo set_db_info, SetDBSerial set_serial, GateWayManager gwm, int index)
        {
            InitializeComponent();
            this.isEdit = false;
            this.gateway_mgr = gwm; ;
            this.serial_index = index;
            this.delgCheckDuplicate = check;
            this.delgSetDBInfo = set_db_info;
            this.delgSetDBSerial = set_serial;
        }

        //Constructor to Edit DB Config Information
        public frmEditDBConfig(SetDBInfo set_db_info, GateWayManager gwm, cls_DB_Info db_info, string gateway, string device)
        {
            InitializeComponent();
            this.isEdit = true;
            this.gateway_mgr = gwm; ;
            this.db_data = db_info;
            this.gateway_id = gateway;
            this.device_id = device;
            this.delgSetDBInfo = set_db_info;
        }

        private void frmEditDBConfig_Load(object sender, EventArgs e)
        {
            cmbGateway.Items.Clear();
            if (this.gateway_mgr.gateway_list.Count > 0)
            {
                foreach (cls_Gateway_Info gi in this.gateway_mgr.gateway_list)
                {
                    cmbGateway.Items.Add(gi.gateway_id);
                }
            }

            lvTagList.Columns.Clear();
            lvTagList.Columns.Add("Tag Name", 100);
            lvTagList.Columns.Add("Data Type", 80);
            lvTagList.Columns.Add("Address", 100);
            lvTagList.Columns.Add("Scale", 60);
            lvTagList.Columns.Add("Offset", 60);
            lvTagList.Columns.Add("Update Time", 140);

            lvCalcTagList.Columns.Clear();
            lvCalcTagList.Columns.Add("Tag Name", 80);
            lvCalcTagList.Columns.Add("A", 50);
            lvCalcTagList.Columns.Add("B", 50);
            lvCalcTagList.Columns.Add("C", 50);
            lvCalcTagList.Columns.Add("D", 50);
            lvCalcTagList.Columns.Add("E", 50);
            lvCalcTagList.Columns.Add("F", 50);
            lvCalcTagList.Columns.Add("G", 50);
            lvCalcTagList.Columns.Add("H", 50);
            lvCalcTagList.Columns.Add("Expression", 180);

            cmbDBType.Items.Clear();
            cmbDBType.Items.Add("My SQL");
            cmbDBType.Items.Add("MS SQL");

            txtSerial.Enabled = false;
            this.serial_index = this.serial_index + 1;
            txtSerial.Text = this.serial_index.ToString("D8");

            if (isEdit)
            {
                cmbGateway.Enabled = false;
                cmbDevice.Enabled = false;
                cmbDBType.Enabled = false;
                txtDataSource.Enabled = false;
                txtPortID.Enabled = false;
                txtConnectDB.Enabled = false;
                txtUserName.Enabled = false;
                txtPassword.Enabled = false;

                txtSerial.Text = this.db_data.serial_id;
                cmbGateway.Text = this.db_data.gateway_id;
                cmbDevice.Text = this.db_data.device_id;
                cmbDBType.Text = this.db_data.db_type;
                txtDataSource.Text = this.db_data.data_source;
                txtPortID.Text = this.db_data.port_id;
                txtConnectDB.Text = this.db_data.db_name;
                txtUserName.Text = this.db_data.user_name;
                txtPassword.Text = EncryptionHelper.Decrypt(this.db_data.password);
                if (this.db_data.enable)
                {
                    chkEnable.Checked = true;
                }
                else
                {
                    chkEnable.Checked = false;
                }

                cls_Gateway_Info gi = this.gateway_mgr.gateway_list.Where(p => p.gateway_id == this.gateway_id).FirstOrDefault();
                if (gi != null)
                {
                    gateway_index = this.gateway_mgr.gateway_list.FindIndex(c => c.gateway_id == this.gateway_id);
                    cls_Device_Info di = gi.device_info.Where(a => a.device_name == this.device_id).FirstOrDefault();
                    if (di != null)
                    {
                        DisplayTagList(di);
                        DisplayCalcTagList(di);
                        device_index = gi.device_info.FindIndex(b => b.device_name == cmbDevice.Text.Trim());
                    }
                }
            }
        }

        private void DisplayTagList(cls_Device_Info device)
        {
            lvTagList.BeginUpdate();
            lvTagList.Items.Clear();
            foreach (KeyValuePair<string, cls_Tag> tag in device.tag_info)
            {
                ListViewItem item = new ListViewItem(tag.Value.TagName);
                item.SubItems.Add(tag.Value.Expression);
                item.SubItems.Add(tag.Value.UUID_Address);
                item.SubItems.Add(tag.Value.scale.ToString());
                item.SubItems.Add(tag.Value.offset.ToString());
                item.SubItems.Add(tag.Value.LastUpdateTime);
                if (tag.Value.db_report_flag == "Y")
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }

                lvTagList.Items.Add(item);
            }
            lvTagList.EndUpdate();
        }

        private void DisplayCalcTagList(cls_Device_Info device)
        {
            lvCalcTagList.BeginUpdate();
            lvCalcTagList.Items.Clear();
            foreach (KeyValuePair<string, cls_CalcTag> calc_tag in device.calc_tag_info)
            {
                ListViewItem item = new ListViewItem(calc_tag.Value.TagName);
                item.SubItems.Add(calc_tag.Value.ParamA);
                item.SubItems.Add(calc_tag.Value.ParamB);
                item.SubItems.Add(calc_tag.Value.ParamC);
                item.SubItems.Add(calc_tag.Value.ParamD);
                item.SubItems.Add(calc_tag.Value.ParamE);
                item.SubItems.Add(calc_tag.Value.ParamF);
                item.SubItems.Add(calc_tag.Value.ParamG);
                item.SubItems.Add(calc_tag.Value.ParamH);
                item.SubItems.Add(calc_tag.Value.Expression);
                lvCalcTagList.Items.Add(item);
            }
            lvCalcTagList.EndUpdate();
        }

        private void cmbGateway_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbGateway.Text.Trim() == "")
            {
                MessageBox.Show("Please select gateway id", "Error");
                return;
            }

            cls_Gateway_Info gi = this.gateway_mgr.gateway_list.Where(p => p.gateway_id == cmbGateway.Text.Trim()).FirstOrDefault();
            if (gi != null)
            {
                cmbDevice.Items.Clear();
                foreach (cls_Device_Info di in gi.device_info)
                {
                    cmbDevice.Items.Add(di.device_name);
                }
                gateway_index = this.gateway_mgr.gateway_list.FindIndex(p => p.gateway_id == cmbGateway.Text.Trim());
            }
            else
            {
                MessageBox.Show("Find gateway failed", "Error");
                return;
            }
        }

        private string generate_connection_string(string db_type)
        {
            string strConnectionString;
            switch(db_type)
            {
                case "My SQL":
                    strConnectionString = "";
                    strConnectionString = "data source=" + txtDataSource.Text.Trim() + "," + txtPortID.Text.Trim() + "; initial catalog=" + txtConnectDB.Text.Trim();
                    //strConnectionString = strConnectionString + "; user id=" + txtUserName.Text.Trim() + "; password=" + EncryptionHelper.Encrypt(txtPassword.Text.Trim());
                    strConnectionString = strConnectionString + "; user id=" + txtUserName.Text.Trim() + "; password=" + txtPassword.Text.Trim();
                    strConnectionString = strConnectionString + "; MultipleActiveResultSets=True; App=EntityFramework; persist security info=True";
                    break;

                case "MS SQL":
                    strConnectionString = "";
                    strConnectionString = "server=" + txtDataSource.Text.Trim() + "; port=" + txtPortID.Text.Trim() + "; database=" + txtConnectDB.Text.Trim();
                   // strConnectionString = strConnectionString + "; uid=" + txtUserName.Text.Trim() + "; password=" + EncryptionHelper.Encrypt(txtPassword.Text.Trim());
                    strConnectionString = strConnectionString + "; uid=" + txtUserName.Text.Trim() + "; password=" + txtPassword.Text.Trim();
                    break;

                default:
                    strConnectionString = null;
                    break;
            }

            return strConnectionString;
        }

        private string get_provider_name(string db_type)
        {
            string strProviderName;
            switch(db_type)
            {
                case "My SQL":
                    strProviderName = "MySql.Data.MySqlClient";
                    break;

                case "MS SQL":
                    strProviderName = "System.Data.SqlClient";
                    break;

                default:
                    strProviderName = null;
                    break;
            }

            return strProviderName;
        }

        private void cmbDevice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDevice.Text.Trim() == "")
            {
                MessageBox.Show("Please select device id", "Error");
                return;
            }

            cls_Gateway_Info gi = this.gateway_mgr.gateway_list.Where(p => p.gateway_id == cmbGateway.Text.Trim()).FirstOrDefault();
            if (gi != null)
            {
                cls_Device_Info di = gi.device_info.Where(p => p.device_name == cmbDevice.Text.Trim()).FirstOrDefault();
                if (di != null)
                {
                    DisplayTagList(di);
                    DisplayCalcTagList(di);
                    device_index = gi.device_info.FindIndex(p => p.device_name == cmbDevice.Text.Trim());
                }
                else
                {
                    MessageBox.Show("Find device information failed", "Error");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Find gateway information failed", "Error");
                return;
            }
        }

        private void btnCancelDBConfig_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveDBConfig_Click(object sender, EventArgs e)
        {
            cls_DB_Info tmpDB = new cls_DB_Info();
            List<Tuple<string, string>> tmp_tag_info = new List<Tuple<string, string>>();
            List<Tuple<string, string>> tmp_calc_tag_info = new List<Tuple<string, string>>();

            if (cmbGateway.Text.Trim() == "")
            {
                MessageBox.Show("Please select the gateway id!", "Error");
                return;
            }

            if (cmbDevice.Text.Trim() == "")
            {
                MessageBox.Show("Please select the device id!", "Error");
                return;
            }

            if(!this.isEdit)
            {
                if (!delgCheckDuplicate(cmbGateway.Text.Trim(), cmbDevice.Text.Trim()))
                {
                    MessageBox.Show("Gateway ID + Device ID should be an unique key!", "Error");
                    return;
                }
            }

            if (cmbDBType.Text.Trim() == "")
            {
                MessageBox.Show("Please select the DB type!", "Error");
                return;
            }

            if(txtDataSource.Text.Trim() == "")
            {
                MessageBox.Show("Please input the data source!", "Error");
                return;
            }

            if (txtPortID.Text.Trim() == "")
            {
                MessageBox.Show("Please input the port id!", "Error");
                return;
            }

            if (txtConnectDB.Text.Trim() == "")
            {
                MessageBox.Show("Please input the database name!", "Error");
                return;
            }

            if (txtDataSource.Text.Trim() == "")
            {
                MessageBox.Show("Please input the data source!", "Error");
                return;
            }

            if (txtUserName.Text.Trim() == "")
            {
                MessageBox.Show("Please input the user name!", "Error");
                return;
            }

            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please input the password!", "Error");
                return;
            }

            tmpDB.serial_id = txtSerial.Text.Trim();
            tmpDB.gateway_id = cmbGateway.Text.Trim();
            tmpDB.device_id = cmbDevice.Text.Trim();
            tmpDB.db_type = cmbDBType.Text.Trim();
            tmpDB.data_source = txtDataSource.Text.Trim();
            tmpDB.port_id = txtPortID.Text.Trim();
            tmpDB.db_name = txtConnectDB.Text.Trim();
            tmpDB.user_name = txtUserName.Text.Trim();
            //tmpDB.password = EncryptionHelper.Encrypt(txtPassword.Text.Trim());
            tmpDB.password = txtPassword.Text.Trim();


            if (generate_connection_string(cmbDBType.Text.Trim()) == null)
            {
                MessageBox.Show("DB type not supported yet", "Error");
                return;
            }
            else
            {
                tmpDB.connection_string = generate_connection_string(cmbDBType.Text.Trim());
            }

            if (get_provider_name(cmbDBType.Text.Trim()) == null)
            {
                MessageBox.Show("DB type not supported yet", "Error");
                return;
            }
            else
            {
                tmpDB.provider_name = get_provider_name(cmbDBType.Text.Trim());
            }

            if (chkEnable.Checked)
            {
                tmpDB.enable = true;
            }
            else
            {
                tmpDB.enable = false;
            }

            foreach (ListViewItem item in lvTagList.Items)
            {
                cls_Tag t = this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].tag_info[item.Text.Trim()];
                if (t != null)
                {
                    if (item.Checked)
                    {
                        this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].tag_info[item.Text.Trim()].db_report_flag = "Y";
                    }
                    else
                    {
                        this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].tag_info[item.Text.Trim()].db_report_flag = "N";
                    }
                }
            }

            foreach (KeyValuePair<string, cls_Tag> tag in this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].tag_info)
            {
                if (tag.Value.db_report_flag == "Y")
                {
                    tmp_tag_info.Add(Tuple.Create(tag.Key, tag.Key));
                }
            }

            foreach (KeyValuePair<string, cls_CalcTag> calc_tag in this.gateway_mgr.gateway_list[gateway_index].device_info[device_index].calc_tag_info)
            {
                tmp_calc_tag_info.Add(Tuple.Create(calc_tag.Key, calc_tag.Key));
            }

            tmpDB.tag_info = tmp_tag_info;
            tmpDB.calc_tag_info = tmp_calc_tag_info;

            if (!this.isEdit)
            {
                delgSetDBSerial(this.serial_index);
            }
            delgSetDBInfo(tmpDB, this.isEdit);

            if (!this.gateway_mgr.gateway_list[this.gateway_index].function_list.Contains("DB"))
            {
                this.gateway_mgr.gateway_list[this.gateway_index].function_list.Add("DB");
            }

            this.Close();
        }

        private void cmbDBType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(cmbDBType.Text.Trim())
            {
                case "My SQL":
                    txtPortID.Text = "3306";
                    break;

                case "MS SQL":
                    txtPortID.Text = "1433";
                    break;

                default:
                    break;
            }
        }
    }
}
