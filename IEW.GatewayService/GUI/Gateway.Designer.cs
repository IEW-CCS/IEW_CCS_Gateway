namespace IEW.GatewayService.UI
{
    partial class Gateway
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gateway));
            this.btnCmdDownload = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.tvNodeList = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tcInfo = new System.Windows.Forms.TabControl();
            this.tpGatewayList = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvGatewayList = new System.Windows.Forms.ListView();
            this.btnRemoveGateway = new System.Windows.Forms.Button();
            this.btnAddGateway = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tpGatewayInfo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tpDeviceInfo = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tpTagSetList = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnRemoveTagSetTemplate = new System.Windows.Forms.Button();
            this.btnAddTagSetTemplate = new System.Windows.Forms.Button();
            this.lvTagSetList = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.tpTagSetInfo = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.tcInfo.SuspendLayout();
            this.tpGatewayList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpGatewayInfo.SuspendLayout();
            this.tpDeviceInfo.SuspendLayout();
            this.tpTagSetList.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tpTagSetInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCmdDownload
            // 
            this.btnCmdDownload.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCmdDownload.FlatAppearance.BorderSize = 2;
            this.btnCmdDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCmdDownload.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCmdDownload.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnCmdDownload.Location = new System.Drawing.Point(1566, 48);
            this.btnCmdDownload.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.btnCmdDownload.Name = "btnCmdDownload";
            this.btnCmdDownload.Size = new System.Drawing.Size(233, 60);
            this.btnCmdDownload.TabIndex = 0;
            this.btnCmdDownload.Text = "CMD_Download";
            this.btnCmdDownload.UseVisualStyleBackColor = true;
            this.btnCmdDownload.Click += new System.EventHandler(this.btnCmdDownload_Click);
            // 
            // btnLoadConfig
            // 
            this.btnLoadConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoadConfig.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadConfig.Location = new System.Drawing.Point(42, 38);
            this.btnLoadConfig.Name = "btnLoadConfig";
            this.btnLoadConfig.Size = new System.Drawing.Size(216, 60);
            this.btnLoadConfig.TabIndex = 1;
            this.btnLoadConfig.Text = "Load Config";
            this.btnLoadConfig.UseVisualStyleBackColor = true;
            this.btnLoadConfig.Click += new System.EventHandler(this.btnLoadConfig_Click);
            // 
            // tvNodeList
            // 
            this.tvNodeList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvNodeList.ImageIndex = 0;
            this.tvNodeList.ImageList = this.imageList1;
            this.tvNodeList.Location = new System.Drawing.Point(42, 126);
            this.tvNodeList.Name = "tvNodeList";
            this.tvNodeList.SelectedImageIndex = 0;
            this.tvNodeList.Size = new System.Drawing.Size(373, 1076);
            this.tvNodeList.TabIndex = 3;
            this.tvNodeList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNodeList_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "gateway_list.png");
            this.imageList1.Images.SetKeyName(1, "gateway.png");
            this.imageList1.Images.SetKeyName(2, "device.png");
            this.imageList1.Images.SetKeyName(3, "tag_list.png");
            this.imageList1.Images.SetKeyName(4, "tag.png");
            this.imageList1.Images.SetKeyName(5, "plus.png");
            this.imageList1.Images.SetKeyName(6, "minus2.png");
            // 
            // tcInfo
            // 
            this.tcInfo.Controls.Add(this.tpGatewayList);
            this.tcInfo.Controls.Add(this.tpGatewayInfo);
            this.tcInfo.Controls.Add(this.tpDeviceInfo);
            this.tcInfo.Controls.Add(this.tpTagSetList);
            this.tcInfo.Controls.Add(this.tpTagSetInfo);
            this.tcInfo.Location = new System.Drawing.Point(446, 126);
            this.tcInfo.Name = "tcInfo";
            this.tcInfo.SelectedIndex = 0;
            this.tcInfo.Size = new System.Drawing.Size(1585, 1076);
            this.tcInfo.TabIndex = 6;
            // 
            // tpGatewayList
            // 
            this.tpGatewayList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpGatewayList.Controls.Add(this.panel1);
            this.tpGatewayList.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpGatewayList.Location = new System.Drawing.Point(8, 39);
            this.tpGatewayList.Name = "tpGatewayList";
            this.tpGatewayList.Padding = new System.Windows.Forms.Padding(3);
            this.tpGatewayList.Size = new System.Drawing.Size(1569, 1029);
            this.tpGatewayList.TabIndex = 0;
            this.tpGatewayList.Tag = "GATEWAY_LIST_TAB";
            this.tpGatewayList.Text = "Gateway List";
            this.tpGatewayList.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lvGatewayList);
            this.panel1.Controls.Add(this.btnRemoveGateway);
            this.panel1.Controls.Add(this.btnAddGateway);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(7, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1554, 1015);
            this.panel1.TabIndex = 0;
            // 
            // lvGatewayList
            // 
            this.lvGatewayList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvGatewayList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvGatewayList.FullRowSelect = true;
            this.lvGatewayList.GridLines = true;
            this.lvGatewayList.Location = new System.Drawing.Point(20, 81);
            this.lvGatewayList.Name = "lvGatewayList";
            this.lvGatewayList.Size = new System.Drawing.Size(1508, 846);
            this.lvGatewayList.TabIndex = 1;
            this.lvGatewayList.UseCompatibleStateImageBehavior = false;
            this.lvGatewayList.View = System.Windows.Forms.View.Details;
            this.lvGatewayList.DoubleClick += new System.EventHandler(this.lvGatewayList_DoubleClick);
            // 
            // btnRemoveGateway
            // 
            this.btnRemoveGateway.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnRemoveGateway.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveGateway.FlatAppearance.BorderSize = 0;
            this.btnRemoveGateway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveGateway.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveGateway.ImageIndex = 6;
            this.btnRemoveGateway.Location = new System.Drawing.Point(93, 933);
            this.btnRemoveGateway.Name = "btnRemoveGateway";
            this.btnRemoveGateway.Size = new System.Drawing.Size(48, 48);
            this.btnRemoveGateway.TabIndex = 5;
            this.btnRemoveGateway.UseVisualStyleBackColor = true;
            this.btnRemoveGateway.Click += new System.EventHandler(this.btnRemoveGateway_Click);
            // 
            // btnAddGateway
            // 
            this.btnAddGateway.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnAddGateway.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddGateway.FlatAppearance.BorderSize = 0;
            this.btnAddGateway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGateway.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddGateway.ImageIndex = 5;
            this.btnAddGateway.Location = new System.Drawing.Point(37, 933);
            this.btnAddGateway.Name = "btnAddGateway";
            this.btnAddGateway.Size = new System.Drawing.Size(48, 48);
            this.btnAddGateway.TabIndex = 4;
            this.btnAddGateway.UseVisualStyleBackColor = true;
            this.btnAddGateway.Click += new System.EventHandler(this.btnAddGateway_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gateway List";
            // 
            // tpGatewayInfo
            // 
            this.tpGatewayInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpGatewayInfo.Controls.Add(this.panel2);
            this.tpGatewayInfo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpGatewayInfo.Location = new System.Drawing.Point(8, 39);
            this.tpGatewayInfo.Name = "tpGatewayInfo";
            this.tpGatewayInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpGatewayInfo.Size = new System.Drawing.Size(1569, 1029);
            this.tpGatewayInfo.TabIndex = 1;
            this.tpGatewayInfo.Tag = "GATEWAY_INFO_TAB";
            this.tpGatewayInfo.Text = "Gateway Information";
            this.tpGatewayInfo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1554, 1015);
            this.panel2.TabIndex = 0;
            // 
            // tpDeviceInfo
            // 
            this.tpDeviceInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpDeviceInfo.Controls.Add(this.panel3);
            this.tpDeviceInfo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDeviceInfo.Location = new System.Drawing.Point(8, 39);
            this.tpDeviceInfo.Name = "tpDeviceInfo";
            this.tpDeviceInfo.Size = new System.Drawing.Size(1569, 1029);
            this.tpDeviceInfo.TabIndex = 2;
            this.tpDeviceInfo.Tag = "DEVICE_INFO_TAB";
            this.tpDeviceInfo.Text = "Device Information";
            this.tpDeviceInfo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1561, 1006);
            this.panel3.TabIndex = 0;
            // 
            // tpTagSetList
            // 
            this.tpTagSetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpTagSetList.Controls.Add(this.panel4);
            this.tpTagSetList.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTagSetList.Location = new System.Drawing.Point(8, 39);
            this.tpTagSetList.Name = "tpTagSetList";
            this.tpTagSetList.Size = new System.Drawing.Size(1569, 1029);
            this.tpTagSetList.TabIndex = 3;
            this.tpTagSetList.Text = "TagSet List";
            this.tpTagSetList.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnRemoveTagSetTemplate);
            this.panel4.Controls.Add(this.btnAddTagSetTemplate);
            this.panel4.Controls.Add(this.lvTagSetList);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1549, 1021);
            this.panel4.TabIndex = 0;
            // 
            // btnRemoveTagSetTemplate
            // 
            this.btnRemoveTagSetTemplate.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnRemoveTagSetTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveTagSetTemplate.FlatAppearance.BorderSize = 0;
            this.btnRemoveTagSetTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTagSetTemplate.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveTagSetTemplate.ImageIndex = 6;
            this.btnRemoveTagSetTemplate.Location = new System.Drawing.Point(97, 932);
            this.btnRemoveTagSetTemplate.Name = "btnRemoveTagSetTemplate";
            this.btnRemoveTagSetTemplate.Size = new System.Drawing.Size(48, 48);
            this.btnRemoveTagSetTemplate.TabIndex = 7;
            this.btnRemoveTagSetTemplate.UseVisualStyleBackColor = true;
            // 
            // btnAddTagSetTemplate
            // 
            this.btnAddTagSetTemplate.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnAddTagSetTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTagSetTemplate.FlatAppearance.BorderSize = 0;
            this.btnAddTagSetTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTagSetTemplate.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddTagSetTemplate.ImageIndex = 5;
            this.btnAddTagSetTemplate.Location = new System.Drawing.Point(41, 932);
            this.btnAddTagSetTemplate.Name = "btnAddTagSetTemplate";
            this.btnAddTagSetTemplate.Size = new System.Drawing.Size(48, 48);
            this.btnAddTagSetTemplate.TabIndex = 6;
            this.btnAddTagSetTemplate.UseVisualStyleBackColor = true;
            this.btnAddTagSetTemplate.Click += new System.EventHandler(this.btnAddTagSetTemplate_Click);
            // 
            // lvTagSetList
            // 
            this.lvTagSetList.FullRowSelect = true;
            this.lvTagSetList.Location = new System.Drawing.Point(47, 100);
            this.lvTagSetList.MultiSelect = false;
            this.lvTagSetList.Name = "lvTagSetList";
            this.lvTagSetList.Size = new System.Drawing.Size(1461, 809);
            this.lvTagSetList.TabIndex = 1;
            this.lvTagSetList.UseCompatibleStateImageBehavior = false;
            this.lvTagSetList.View = System.Windows.Forms.View.Details;
            this.lvTagSetList.DoubleClick += new System.EventHandler(this.lvTagSetList_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(276, 37);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tag Set Template List";
            // 
            // tpTagSetInfo
            // 
            this.tpTagSetInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpTagSetInfo.Controls.Add(this.panel5);
            this.tpTagSetInfo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTagSetInfo.Location = new System.Drawing.Point(8, 39);
            this.tpTagSetInfo.Name = "tpTagSetInfo";
            this.tpTagSetInfo.Size = new System.Drawing.Size(1569, 1029);
            this.tpTagSetInfo.TabIndex = 4;
            this.tpTagSetInfo.Text = "TagSet Info";
            this.tpTagSetInfo.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1561, 1021);
            this.panel5.TabIndex = 0;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveConfig.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveConfig.Location = new System.Drawing.Point(302, 38);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(216, 60);
            this.btnSaveConfig.TabIndex = 7;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // Gateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2063, 1283);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.tcInfo);
            this.Controls.Add(this.tvNodeList);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.btnCmdDownload);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Gateway";
            this.Text = "Gateway";
            this.Load += new System.EventHandler(this.Gateway_Load);
            this.tcInfo.ResumeLayout(false);
            this.tpGatewayList.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tpGatewayInfo.ResumeLayout(false);
            this.tpDeviceInfo.ResumeLayout(false);
            this.tpTagSetList.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tpTagSetInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCmdDownload;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.TreeView tvNodeList;
        private System.Windows.Forms.Button btnAddGateway;
        private System.Windows.Forms.Button btnRemoveGateway;
        private System.Windows.Forms.TabControl tcInfo;
        private System.Windows.Forms.TabPage tpGatewayList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tpGatewayInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tpDeviceInfo;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListView lvGatewayList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tpTagSetList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tpTagSetInfo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView lvTagSetList;
        private System.Windows.Forms.Button btnRemoveTagSetTemplate;
        private System.Windows.Forms.Button btnAddTagSetTemplate;
    }
}