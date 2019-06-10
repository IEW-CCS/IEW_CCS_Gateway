using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEW.ObjectManager;
using System.Collections.Concurrent;

namespace IEW.GatewayService.GUI
{
    public delegate void SetTagListData(ConcurrentDictionary<string, cls_Tag> tag_list);
    public delegate void SetCalcTagListData(ConcurrentDictionary<string, cls_CalcTag> calc_tag_list);


    public partial class frmLoadTagSetTemplate : Form
    {
        public ConcurrentDictionary<string, cls_Tag> template_data = new ConcurrentDictionary<string, cls_Tag>();
        public ConcurrentDictionary<string, cls_CalcTag> template_calc_data = new ConcurrentDictionary<string, cls_CalcTag>();

        public SetTagListData delgSetTagTemplate;
        public SetCalcTagListData delgSetCalcTagTemplate;


        IEW.ObjectManager.ObjectManager objManager = new IEW.ObjectManager.ObjectManager();
        int set_index;
        int calc_set_index;

        public frmLoadTagSetTemplate()
        {
            InitializeComponent();
        }

        public frmLoadTagSetTemplate(SetTagListData set_data, SetCalcTagListData set_calc_data)
        {
            InitializeComponent();
            this.delgSetTagTemplate = set_data;
            this.delgSetCalcTagTemplate = set_calc_data;

            if(LoadTagSetConfig())
            {
                cmbTagSet.Items.Clear();
                foreach (cls_Tag_Set t_set in this.objManager.TagSetManager.tag_set_list)
                {
                    cmbTagSet.Items.Add(t_set.TagSetName);
                }

                lvTagList.Columns.Clear();
                lvTagList.Columns.Add("Tag Name", 80);
                lvTagList.Columns.Add("Data Type", 80);
                lvTagList.Columns.Add("Address", 120);
                lvTagList.Columns.Add("Scale", 80);
                lvTagList.Columns.Add("Offset", 80);
                lvTagList.Columns.Add("Update Time", 180);

                lvCalcTagList.Columns.Clear();
                lvCalcTagList.Columns.Add("Tag Name", 80);
                lvCalcTagList.Columns.Add("A", 60);
                lvCalcTagList.Columns.Add("B", 60);
                lvCalcTagList.Columns.Add("C", 60);
                lvCalcTagList.Columns.Add("D", 60);
                lvCalcTagList.Columns.Add("E", 60);
                lvCalcTagList.Columns.Add("F", 60);
                lvCalcTagList.Columns.Add("G", 60);
                lvCalcTagList.Columns.Add("H", 60);
                lvCalcTagList.Columns.Add("Expression", 180);

            }
            txtDescription.Enabled = false;
        }

        private void btnTempCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTempLoad_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to load the tag template?", "Confirm Message", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }

            if(lvTagList.Items.Count > 0)
            {
                foreach(cls_Tag tag in this.objManager.TagSetManager.tag_set_list[this.set_index].tag_set)
                {
                    template_data.TryAdd(tag.TagName, tag);
                }
                delgSetTagTemplate(template_data);
            }

            if (lvCalcTagList.Items.Count > 0)
            {
                foreach (cls_CalcTag calc_tag in this.objManager.TagSetManager.tag_set_list[this.set_index].calc_tag_set)
                {
                    template_calc_data.TryAdd(calc_tag.TagName, calc_tag);
                }
                delgSetCalcTagTemplate(template_calc_data);
            }

            this.objManager = null;

            this.Close();
        }

        private bool LoadTagSetConfig()
        {
            try
            {
                if (!System.IO.File.Exists("C:\\Gateway\\Config\\Tag_Set_Config.json"))
                {
                    //MessageBox.Show("No tag set config file exists! Please start to create tag set template.", "Information");
                    this.objManager.TagSetManager_Initial();
                    return true;
                }

                StreamReader inputFile = new StreamReader("C:\\Gateway\\Config\\Tag_Set_Config.json");

                string json_string = inputFile.ReadToEnd();

                this.objManager.TagSetManager_Initial(json_string);

                if (this.objManager.TagSetManager.tag_set_list == null)
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

        void DisplayTagTemplate(string set_name)
        {
            lvTagList.Items.Clear();

            int i = 0;
            foreach(cls_Tag_Set ts in this.objManager.TagSetManager.tag_set_list)
            {
                if(ts.TagSetName == set_name)
                {
                    break;
                }
                i++;
            }

            this.set_index = i;
            txtDescription.Text = this.objManager.TagSetManager.tag_set_list[this.set_index].TagSetDescription;

            if (this.objManager.TagSetManager.tag_set_list[this.set_index].tag_set.Count > 0)
            {
                lvTagList.BeginUpdate();
                lvTagList.Items.Clear();
                foreach (cls_Tag tag in this.objManager.TagSetManager.tag_set_list[this.set_index].tag_set)
                {
                    ListViewItem lvItem = new ListViewItem(tag.TagName);
                    lvItem.SubItems.Add(tag.Expression);
                    lvItem.SubItems.Add(tag.UUID_Address);
                    lvItem.SubItems.Add(tag.scale.ToString());
                    lvItem.SubItems.Add(tag.offset.ToString());
                    lvItem.SubItems.Add(tag.LastUpdateTime);
                    lvTagList.Items.Add(lvItem);
                }
                lvTagList.EndUpdate();
            }

            if (this.objManager.TagSetManager.tag_set_list[this.set_index].calc_tag_set.Count > 0)
            {
                lvCalcTagList.BeginUpdate();
                lvCalcTagList.Items.Clear();
                foreach (cls_CalcTag calc_tag in this.objManager.TagSetManager.tag_set_list[this.set_index].calc_tag_set)
                {
                    ListViewItem lvItem = new ListViewItem(calc_tag.TagName);
                    lvItem.SubItems.Add(calc_tag.ParamA);
                    lvItem.SubItems.Add(calc_tag.ParamB);
                    lvItem.SubItems.Add(calc_tag.ParamC);
                    lvItem.SubItems.Add(calc_tag.ParamD);
                    lvItem.SubItems.Add(calc_tag.ParamE);
                    lvItem.SubItems.Add(calc_tag.ParamF);
                    lvItem.SubItems.Add(calc_tag.ParamG);
                    lvItem.SubItems.Add(calc_tag.ParamH);
                    lvItem.SubItems.Add(calc_tag.Expression);
                    lvCalcTagList.Items.Add(lvItem);
                }
                lvCalcTagList.EndUpdate();
            }

        }

        private void cmbTagSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strTagSetName;

            strTagSetName = cmbTagSet.Text.Trim();

            DisplayTagTemplate(strTagSetName);
        }

    }
}
