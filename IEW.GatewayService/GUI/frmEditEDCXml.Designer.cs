﻿namespace IEW.GatewayService.GUI
{
    partial class frmEditEDCXml
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbGateway = new System.Windows.Forms.ComboBox();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbInterval = new System.Windows.Forms.GroupBox();
            this.chkMIN = new System.Windows.Forms.CheckBox();
            this.chkMAX = new System.Windows.Forms.CheckBox();
            this.chkAVG = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtReportPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtReportInterval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbEDCHeaderSet = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lvHeaderItemList = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.lvCalcTagList = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelEDCXml = new System.Windows.Forms.Button();
            this.btnSaveEDCXml = new System.Windows.Forms.Button();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.chkTagCheckAll = new System.Windows.Forms.CheckBox();
            this.chkCalcTagCheckAll = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.gbInterval.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial ID";
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(84, 21);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(97, 23);
            this.txtSerial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gateway ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Device ID";
            // 
            // cmbGateway
            // 
            this.cmbGateway.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGateway.FormattingEnabled = true;
            this.cmbGateway.Location = new System.Drawing.Point(84, 48);
            this.cmbGateway.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGateway.Name = "cmbGateway";
            this.cmbGateway.Size = new System.Drawing.Size(97, 24);
            this.cmbGateway.TabIndex = 4;
            this.cmbGateway.SelectedIndexChanged += new System.EventHandler(this.cmbGateway_SelectedIndexChanged);
            // 
            // cmbDevice
            // 
            this.cmbDevice.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(84, 75);
            this.cmbDevice.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(97, 24);
            this.cmbDevice.TabIndex = 5;
            this.cmbDevice.SelectedIndexChanged += new System.EventHandler(this.cmbDevice_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbInterval);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.txtReportPath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtReportInterval);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbReportType);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSerial);
            this.groupBox1.Controls.Add(this.cmbDevice);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbGateway);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(732, 108);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Information";
            // 
            // gbInterval
            // 
            this.gbInterval.Controls.Add(this.chkMIN);
            this.gbInterval.Controls.Add(this.chkMAX);
            this.gbInterval.Controls.Add(this.chkAVG);
            this.gbInterval.Location = new System.Drawing.Point(427, 20);
            this.gbInterval.Name = "gbInterval";
            this.gbInterval.Size = new System.Drawing.Size(257, 49);
            this.gbInterval.TabIndex = 13;
            this.gbInterval.TabStop = false;
            this.gbInterval.Text = "Report Interval Function";
            // 
            // chkMIN
            // 
            this.chkMIN.AutoSize = true;
            this.chkMIN.Location = new System.Drawing.Point(174, 23);
            this.chkMIN.Margin = new System.Windows.Forms.Padding(2);
            this.chkMIN.Name = "chkMIN";
            this.chkMIN.Size = new System.Drawing.Size(49, 21);
            this.chkMIN.TabIndex = 38;
            this.chkMIN.Text = "MIN";
            this.chkMIN.UseVisualStyleBackColor = true;
            // 
            // chkMAX
            // 
            this.chkMAX.AutoSize = true;
            this.chkMAX.Location = new System.Drawing.Point(90, 23);
            this.chkMAX.Margin = new System.Windows.Forms.Padding(2);
            this.chkMAX.Name = "chkMAX";
            this.chkMAX.Size = new System.Drawing.Size(54, 21);
            this.chkMAX.TabIndex = 37;
            this.chkMAX.Text = "MAX";
            this.chkMAX.UseVisualStyleBackColor = true;
            // 
            // chkAVG
            // 
            this.chkAVG.AutoSize = true;
            this.chkAVG.Location = new System.Drawing.Point(5, 23);
            this.chkAVG.Margin = new System.Windows.Forms.Padding(2);
            this.chkAVG.Name = "chkAVG";
            this.chkAVG.Size = new System.Drawing.Size(51, 21);
            this.chkAVG.TabIndex = 36;
            this.chkAVG.Text = "AVG";
            this.chkAVG.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(620, 73);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(64, 24);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtReportPath
            // 
            this.txtReportPath.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportPath.Location = new System.Drawing.Point(298, 76);
            this.txtReportPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtReportPath.Name = "txtReportPath";
            this.txtReportPath.Size = new System.Drawing.Size(308, 23);
            this.txtReportPath.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(206, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Report Path";
            // 
            // txtReportInterval
            // 
            this.txtReportInterval.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportInterval.Location = new System.Drawing.Point(298, 48);
            this.txtReportInterval.Margin = new System.Windows.Forms.Padding(2);
            this.txtReportInterval.Name = "txtReportInterval";
            this.txtReportInterval.Size = new System.Drawing.Size(97, 23);
            this.txtReportInterval.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(206, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Report Interval";
            // 
            // cmbReportType
            // 
            this.cmbReportType.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(298, 20);
            this.cmbReportType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(97, 24);
            this.cmbReportType.TabIndex = 7;
            this.cmbReportType.SelectedIndexChanged += new System.EventHandler(this.cmbReportType_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(206, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Report type";
            // 
            // cmbEDCHeaderSet
            // 
            this.cmbEDCHeaderSet.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEDCHeaderSet.FormattingEnabled = true;
            this.cmbEDCHeaderSet.Location = new System.Drawing.Point(110, 118);
            this.cmbEDCHeaderSet.Margin = new System.Windows.Forms.Padding(2);
            this.cmbEDCHeaderSet.Name = "cmbEDCHeaderSet";
            this.cmbEDCHeaderSet.Size = new System.Drawing.Size(136, 24);
            this.cmbEDCHeaderSet.TabIndex = 6;
            this.cmbEDCHeaderSet.SelectedIndexChanged += new System.EventHandler(this.cmbEDCHeaderSet_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "EDC Header Set";
            // 
            // lvHeaderItemList
            // 
            this.lvHeaderItemList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHeaderItemList.FullRowSelect = true;
            this.lvHeaderItemList.GridLines = true;
            this.lvHeaderItemList.Location = new System.Drawing.Point(18, 146);
            this.lvHeaderItemList.Margin = new System.Windows.Forms.Padding(2);
            this.lvHeaderItemList.Name = "lvHeaderItemList";
            this.lvHeaderItemList.Size = new System.Drawing.Size(228, 173);
            this.lvHeaderItemList.TabIndex = 7;
            this.lvHeaderItemList.UseCompatibleStateImageBehavior = false;
            this.lvHeaderItemList.View = System.Windows.Forms.View.Details;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(247, 121);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "Normal Tag List";
            // 
            // lvTagList
            // 
            this.lvTagList.CheckBoxes = true;
            this.lvTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.GridLines = true;
            this.lvTagList.Location = new System.Drawing.Point(250, 146);
            this.lvTagList.Margin = new System.Windows.Forms.Padding(2);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(488, 173);
            this.lvTagList.TabIndex = 9;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            // 
            // lvCalcTagList
            // 
            this.lvCalcTagList.CheckBoxes = true;
            this.lvCalcTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCalcTagList.FullRowSelect = true;
            this.lvCalcTagList.GridLines = true;
            this.lvCalcTagList.Location = new System.Drawing.Point(18, 348);
            this.lvCalcTagList.Margin = new System.Windows.Forms.Padding(2);
            this.lvCalcTagList.Name = "lvCalcTagList";
            this.lvCalcTagList.Size = new System.Drawing.Size(720, 157);
            this.lvCalcTagList.TabIndex = 11;
            this.lvCalcTagList.UseCompatibleStateImageBehavior = false;
            this.lvCalcTagList.View = System.Windows.Forms.View.Details;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 324);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(101, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Calculation Tag List";
            // 
            // btnCancelEDCXml
            // 
            this.btnCancelEDCXml.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEDCXml.Location = new System.Drawing.Point(390, 509);
            this.btnCancelEDCXml.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnCancelEDCXml.Name = "btnCancelEDCXml";
            this.btnCancelEDCXml.Size = new System.Drawing.Size(79, 36);
            this.btnCancelEDCXml.TabIndex = 34;
            this.btnCancelEDCXml.Text = "Cancel";
            this.btnCancelEDCXml.UseVisualStyleBackColor = true;
            this.btnCancelEDCXml.Click += new System.EventHandler(this.btnCancelEDCXml_Click);
            // 
            // btnSaveEDCXml
            // 
            this.btnSaveEDCXml.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEDCXml.Location = new System.Drawing.Point(291, 509);
            this.btnSaveEDCXml.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnSaveEDCXml.Name = "btnSaveEDCXml";
            this.btnSaveEDCXml.Size = new System.Drawing.Size(79, 36);
            this.btnSaveEDCXml.TabIndex = 33;
            this.btnSaveEDCXml.Text = "Save";
            this.btnSaveEDCXml.UseVisualStyleBackColor = true;
            this.btnSaveEDCXml.Click += new System.EventHandler(this.btnSaveEDCXml_Click);
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkEnable.Location = new System.Drawing.Point(669, 121);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(60, 20);
            this.chkEnable.TabIndex = 35;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // chkTagCheckAll
            // 
            this.chkTagCheckAll.AutoSize = true;
            this.chkTagCheckAll.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTagCheckAll.Location = new System.Drawing.Point(353, 121);
            this.chkTagCheckAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkTagCheckAll.Name = "chkTagCheckAll";
            this.chkTagCheckAll.Size = new System.Drawing.Size(71, 20);
            this.chkTagCheckAll.TabIndex = 36;
            this.chkTagCheckAll.Text = "Check All";
            this.chkTagCheckAll.UseVisualStyleBackColor = true;
            this.chkTagCheckAll.CheckedChanged += new System.EventHandler(this.chkTagCheckAll_CheckedChanged);
            // 
            // chkCalcTagCheckAll
            // 
            this.chkCalcTagCheckAll.AutoSize = true;
            this.chkCalcTagCheckAll.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCalcTagCheckAll.Location = new System.Drawing.Point(125, 324);
            this.chkCalcTagCheckAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkCalcTagCheckAll.Name = "chkCalcTagCheckAll";
            this.chkCalcTagCheckAll.Size = new System.Drawing.Size(71, 20);
            this.chkCalcTagCheckAll.TabIndex = 37;
            this.chkCalcTagCheckAll.Text = "Check All";
            this.chkCalcTagCheckAll.UseVisualStyleBackColor = true;
            this.chkCalcTagCheckAll.CheckedChanged += new System.EventHandler(this.chkCalcTagCheckAll_CheckedChanged);
            // 
            // frmEditEDCXml
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 556);
            this.Controls.Add(this.chkCalcTagCheckAll);
            this.Controls.Add(this.chkTagCheckAll);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.btnCancelEDCXml);
            this.Controls.Add(this.btnSaveEDCXml);
            this.Controls.Add(this.lvCalcTagList);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lvTagList);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lvHeaderItemList);
            this.Controls.Add(this.cmbEDCHeaderSet);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEditEDCXml";
            this.Text = "frmEditEDCXml";
            this.Load += new System.EventHandler(this.frmEditEDCXml_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbInterval.ResumeLayout(false);
            this.gbInterval.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbGateway;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtReportPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtReportInterval;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lvHeaderItemList;
        private System.Windows.Forms.ComboBox cmbEDCHeaderSet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.ListView lvCalcTagList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCancelEDCXml;
        private System.Windows.Forms.Button btnSaveEDCXml;
        private System.Windows.Forms.GroupBox gbInterval;
        private System.Windows.Forms.CheckBox chkMIN;
        private System.Windows.Forms.CheckBox chkMAX;
        private System.Windows.Forms.CheckBox chkAVG;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.CheckBox chkTagCheckAll;
        private System.Windows.Forms.CheckBox chkCalcTagCheckAll;
    }
}