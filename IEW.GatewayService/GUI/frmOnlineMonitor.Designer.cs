﻿namespace IEW.GatewayService.GUI
{
    partial class frmOnlineMonitor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        */

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOnlineMonitor));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvoStatus = new BrightIdeasSoftware.ObjectListView();
            this.gw_idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dv_idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dv_typeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.dv_statusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.iot_statusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hb_statusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hb_timeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.edc_timeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.alarm_codeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.alarm_appColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.alarm_timeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.alarm_msgColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.lvoStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(11, 517);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(76, 28);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadData.Location = new System.Drawing.Point(105, 517);
            this.btnReadData.Margin = new System.Windows.Forms.Padding(2);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(76, 28);
            this.btnReadData.TabIndex = 2;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Online Status Monitor";
            // 
            // lvoStatus
            // 
            this.lvoStatus.AllColumns.Add(this.gw_idColumn);
            this.lvoStatus.AllColumns.Add(this.dv_idColumn);
            this.lvoStatus.AllColumns.Add(this.dv_typeColumn);
            this.lvoStatus.AllColumns.Add(this.dv_statusColumn);
            this.lvoStatus.AllColumns.Add(this.iot_statusColumn);
            this.lvoStatus.AllColumns.Add(this.hb_statusColumn);
            this.lvoStatus.AllColumns.Add(this.hb_timeColumn);
            this.lvoStatus.AllColumns.Add(this.edc_timeColumn);
            this.lvoStatus.AllColumns.Add(this.alarm_codeColumn);
            this.lvoStatus.AllColumns.Add(this.alarm_appColumn);
            this.lvoStatus.AllColumns.Add(this.alarm_msgColumn);
            this.lvoStatus.AllColumns.Add(this.alarm_timeColumn);
            this.lvoStatus.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvoStatus.CheckBoxes = true;
            this.lvoStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gw_idColumn,
            this.dv_idColumn,
            this.dv_typeColumn,
            this.dv_statusColumn,
            this.iot_statusColumn,
            this.hb_statusColumn,
            this.hb_timeColumn,
            this.edc_timeColumn,
            this.alarm_codeColumn,
            this.alarm_appColumn,
            this.alarm_msgColumn,
            this.alarm_timeColumn});
            this.lvoStatus.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvoStatus.FullRowSelect = true;
            this.lvoStatus.GridLines = true;
            this.lvoStatus.HasCollapsibleGroups = false;
            this.lvoStatus.Location = new System.Drawing.Point(12, 38);
            this.lvoStatus.Margin = new System.Windows.Forms.Padding(2);
            this.lvoStatus.MenuLabelColumns = "";
            this.lvoStatus.MenuLabelGroupBy = "";
            this.lvoStatus.MenuLabelLockGroupingOn = "";
            this.lvoStatus.Name = "lvoStatus";
            this.lvoStatus.ShowImagesOnSubItems = true;
            this.lvoStatus.Size = new System.Drawing.Size(723, 466);
            this.lvoStatus.SmallImageList = this.imageList1;
            this.lvoStatus.SortGroupItemsByPrimaryColumn = false;
            this.lvoStatus.TabIndex = 4;
            this.lvoStatus.UseCompatibleStateImageBehavior = false;
            this.lvoStatus.View = System.Windows.Forms.View.Details;
            // 
            // gw_idColumn
            // 
            this.gw_idColumn.AspectName = "gateway_id";
            this.gw_idColumn.CheckBoxes = true;
            this.gw_idColumn.Groupable = false;
            this.gw_idColumn.HeaderCheckBoxUpdatesRowCheckBoxes = false;
            this.gw_idColumn.IsVisible = false;
            this.gw_idColumn.Text = "Gateway ID";
            this.gw_idColumn.Width = 110;
            // 
            // dv_idColumn
            // 
            this.dv_idColumn.AspectName = "device_id";
            this.dv_idColumn.Groupable = false;
            this.dv_idColumn.Text = "Device ID";
            this.dv_idColumn.Width = 90;
            // 
            // dv_typeColumn
            // 
            this.dv_typeColumn.AspectName = "device_type";
            this.dv_typeColumn.Groupable = false;
            this.dv_typeColumn.Text = "Type";
            this.dv_typeColumn.Width = 50;
            // 
            // dv_statusColumn
            // 
            this.dv_statusColumn.AspectName = "device_status";
            this.dv_statusColumn.Groupable = false;
            this.dv_statusColumn.Text = "Status";
            this.dv_statusColumn.Width = 70;
            // 
            // iot_statusColumn
            // 
            this.iot_statusColumn.AspectName = "iotclient_status";
            this.iot_statusColumn.Groupable = false;
            this.iot_statusColumn.Text = "IoTClient Status";
            this.iot_statusColumn.Width = 70;
            // 
            // hb_statusColumn
            // 
            this.hb_statusColumn.AspectName = "hb_status";
            this.hb_statusColumn.Groupable = false;
            this.hb_statusColumn.Text = "HeartBeat";
            this.hb_statusColumn.Width = 70;
            // 
            // hb_timeColumn
            // 
            this.hb_timeColumn.AspectName = "hb_report_time";
            this.hb_timeColumn.Groupable = false;
            this.hb_timeColumn.Text = "HB Time";
            this.hb_timeColumn.Width = 130;
            // 
            // edc_timeColumn
            // 
            this.edc_timeColumn.AspectName = "last_edc_time";
            this.edc_timeColumn.Groupable = false;
            this.edc_timeColumn.Text = "EDC Time";
            this.edc_timeColumn.Width = 130;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Off");
            this.imageList1.Images.SetKeyName(1, "Ready");
            this.imageList1.Images.SetKeyName(2, "Run");
            this.imageList1.Images.SetKeyName(3, "Down");
            this.imageList1.Images.SetKeyName(4, "Idle");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(597, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Report Interval:";
            // 
            // txtInterval
            // 
            this.txtInterval.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInterval.Location = new System.Drawing.Point(681, 8);
            this.txtInterval.Margin = new System.Windows.Forms.Padding(2);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(52, 23);
            this.txtInterval.TabIndex = 6;
            // 
            // alarm_codeColumn
            // 
            this.alarm_codeColumn.AspectName = "last_alarm_code";
            this.alarm_codeColumn.Groupable = false;
            this.alarm_codeColumn.Text = "Alarm Code";
            // 
            // alarm_appColumn
            // 
            this.alarm_appColumn.AspectName = "last_alarm_app";
            this.alarm_appColumn.Groupable = false;
            this.alarm_appColumn.Text = "Alarm App";
            this.alarm_appColumn.Width = 80;
            // 
            // alarm_timeColumn
            // 
            this.alarm_timeColumn.AspectName = "last_alarm_datetime";
            this.alarm_timeColumn.Groupable = false;
            this.alarm_timeColumn.Text = "Alarm Date Time";
            this.alarm_timeColumn.Width = 140;
            // 
            // alarm_msgColumn
            // 
            this.alarm_msgColumn.AspectName = "last_alarm_message";
            this.alarm_msgColumn.Groupable = false;
            this.alarm_msgColumn.Text = "Alarm Message";
            this.alarm_msgColumn.Width = 120;
            // 
            // frmOnlineMonitor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(746, 556);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvoStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmOnlineMonitor";
            this.Text = "frmOnlineMonitor";
            this.Load += new System.EventHandler(this.frmOnlineMonitor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lvoStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReadData;
        private System.Windows.Forms.Label label1;
        private BrightIdeasSoftware.ObjectListView lvoStatus;
        private BrightIdeasSoftware.OLVColumn gw_idColumn;
        private BrightIdeasSoftware.OLVColumn dv_idColumn;
        private BrightIdeasSoftware.OLVColumn dv_typeColumn;
        private BrightIdeasSoftware.OLVColumn dv_statusColumn;
        private BrightIdeasSoftware.OLVColumn iot_statusColumn;
        private BrightIdeasSoftware.OLVColumn hb_statusColumn;
        private System.Windows.Forms.ImageList imageList1;
        private BrightIdeasSoftware.OLVColumn hb_timeColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInterval;
        private BrightIdeasSoftware.OLVColumn edc_timeColumn;
        private BrightIdeasSoftware.OLVColumn alarm_codeColumn;
        private BrightIdeasSoftware.OLVColumn alarm_appColumn;
        private BrightIdeasSoftware.OLVColumn alarm_timeColumn;
        private BrightIdeasSoftware.OLVColumn alarm_msgColumn;
    }
}