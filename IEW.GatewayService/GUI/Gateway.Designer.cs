﻿namespace IEW.GatewayService.UI
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
            this.btnCmdDownload = new System.Windows.Forms.Button();
            this.btnLoadConfig = new System.Windows.Forms.Button();
            this.tvNodeList = new System.Windows.Forms.TreeView();
            this.btnAddGateway = new System.Windows.Forms.Button();
            this.btnRemoveGateway = new System.Windows.Forms.Button();
            this.tcInfo = new System.Windows.Forms.TabControl();
            this.tpGatewayList = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvGatewayList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.tpGatewayInfo = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpDeviceInfo = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tpTagSetList = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tpTagSetInfo = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.tcInfo.SuspendLayout();
            this.tpGatewayList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpGatewayInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tpDeviceInfo.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tpTagSetList.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tpTagSetInfo.SuspendLayout();
            this.panel5.SuspendLayout();
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
            this.tvNodeList.Location = new System.Drawing.Point(42, 126);
            this.tvNodeList.Name = "tvNodeList";
            this.tvNodeList.Size = new System.Drawing.Size(373, 924);
            this.tvNodeList.TabIndex = 3;
            this.tvNodeList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvNodeList_AfterSelect);
            // 
            // btnAddGateway
            // 
            this.btnAddGateway.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddGateway.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddGateway.Location = new System.Drawing.Point(51, 785);
            this.btnAddGateway.Name = "btnAddGateway";
            this.btnAddGateway.Size = new System.Drawing.Size(46, 45);
            this.btnAddGateway.TabIndex = 4;
            this.btnAddGateway.Text = "+";
            this.btnAddGateway.UseVisualStyleBackColor = true;
            this.btnAddGateway.Click += new System.EventHandler(this.btnAddGateway_Click);
            // 
            // btnRemoveGateway
            // 
            this.btnRemoveGateway.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnRemoveGateway.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveGateway.Location = new System.Drawing.Point(110, 785);
            this.btnRemoveGateway.Name = "btnRemoveGateway";
            this.btnRemoveGateway.Size = new System.Drawing.Size(46, 45);
            this.btnRemoveGateway.TabIndex = 5;
            this.btnRemoveGateway.Text = "-";
            this.btnRemoveGateway.UseVisualStyleBackColor = true;
            this.btnRemoveGateway.Click += new System.EventHandler(this.btnRemoveGateway_Click);
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
            this.tcInfo.Size = new System.Drawing.Size(1361, 932);
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
            this.tpGatewayList.Size = new System.Drawing.Size(1345, 885);
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
            this.panel1.Size = new System.Drawing.Size(1333, 867);
            this.panel1.TabIndex = 0;
            // 
            // lvGatewayList
            // 
            this.lvGatewayList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvGatewayList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvGatewayList.FullRowSelect = true;
            this.lvGatewayList.GridLines = true;
            this.lvGatewayList.Location = new System.Drawing.Point(51, 81);
            this.lvGatewayList.Name = "lvGatewayList";
            this.lvGatewayList.Size = new System.Drawing.Size(1229, 673);
            this.lvGatewayList.TabIndex = 1;
            this.lvGatewayList.UseCompatibleStateImageBehavior = false;
            this.lvGatewayList.View = System.Windows.Forms.View.Details;
            this.lvGatewayList.DoubleClick += new System.EventHandler(this.lvGatewayList_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 33);
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
            this.tpGatewayInfo.Size = new System.Drawing.Size(1345, 885);
            this.tpGatewayInfo.TabIndex = 1;
            this.tpGatewayInfo.Tag = "GATEWAY_INFO_TAB";
            this.tpGatewayInfo.Text = "Gateway Information";
            this.tpGatewayInfo.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(7, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1333, 861);
            this.panel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(29, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 37);
            this.label3.TabIndex = 2;
            this.label3.Text = "Gateway IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gateway ID";
            // 
            // tpDeviceInfo
            // 
            this.tpDeviceInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpDeviceInfo.Controls.Add(this.panel3);
            this.tpDeviceInfo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpDeviceInfo.Location = new System.Drawing.Point(8, 39);
            this.tpDeviceInfo.Name = "tpDeviceInfo";
            this.tpDeviceInfo.Size = new System.Drawing.Size(1345, 885);
            this.tpDeviceInfo.TabIndex = 2;
            this.tpDeviceInfo.Tag = "DEVICE_INFO_TAB";
            this.tpDeviceInfo.Text = "Device Information";
            this.tpDeviceInfo.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 9);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1339, 868);
            this.panel3.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(40, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 37);
            this.label5.TabIndex = 1;
            this.label5.Text = "Device Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(40, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 37);
            this.label4.TabIndex = 0;
            this.label4.Text = "Device ID";
            // 
            // tpTagSetList
            // 
            this.tpTagSetList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpTagSetList.Controls.Add(this.panel4);
            this.tpTagSetList.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTagSetList.Location = new System.Drawing.Point(8, 39);
            this.tpTagSetList.Name = "tpTagSetList";
            this.tpTagSetList.Size = new System.Drawing.Size(1345, 885);
            this.tpTagSetList.TabIndex = 3;
            this.tpTagSetList.Text = "TagSet List";
            this.tpTagSetList.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label6);
            this.panel4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1339, 882);
            this.panel4.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(151, 37);
            this.label6.TabIndex = 0;
            this.label6.Text = "TagSet List";
            // 
            // tpTagSetInfo
            // 
            this.tpTagSetInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tpTagSetInfo.Controls.Add(this.panel5);
            this.tpTagSetInfo.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpTagSetInfo.Location = new System.Drawing.Point(8, 39);
            this.tpTagSetInfo.Name = "tpTagSetInfo";
            this.tpTagSetInfo.Size = new System.Drawing.Size(1345, 885);
            this.tpTagSetInfo.TabIndex = 4;
            this.tpTagSetInfo.Text = "TagSet Info";
            this.tpTagSetInfo.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1339, 878);
            this.panel5.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(46, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(243, 37);
            this.label7.TabIndex = 0;
            this.label7.Text = "TagSet Information";
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
            this.ClientSize = new System.Drawing.Size(1849, 1186);
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
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tpDeviceInfo.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.tpTagSetList.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tpTagSetInfo.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tpTagSetList;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tpTagSetInfo;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveConfig;
    }
}