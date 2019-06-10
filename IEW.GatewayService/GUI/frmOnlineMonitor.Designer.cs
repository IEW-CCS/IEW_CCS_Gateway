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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOnlineMonitor));
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReadData = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvoStatus = new BrightIdeasSoftware.ObjectListView();
            this.gw_idColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gw_ipColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.gw_statusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.edc_timeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hb_statusColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.hb_timeColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gw_locationColumn = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            ((System.ComponentModel.ISupportInitialize)(this.lvoStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(969, 950);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(151, 55);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReadData
            // 
            this.btnReadData.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadData.Location = new System.Drawing.Point(1155, 950);
            this.btnReadData.Name = "btnReadData";
            this.btnReadData.Size = new System.Drawing.Size(151, 55);
            this.btnReadData.TabIndex = 2;
            this.btnReadData.Text = "Read Data";
            this.btnReadData.UseVisualStyleBackColor = true;
            this.btnReadData.Click += new System.EventHandler(this.btnReadData_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Online Status Monitor";
            // 
            // lvoStatus
            // 
            this.lvoStatus.AllColumns.Add(this.gw_idColumn);
            this.lvoStatus.AllColumns.Add(this.gw_ipColumn);
            this.lvoStatus.AllColumns.Add(this.gw_statusColumn);
            this.lvoStatus.AllColumns.Add(this.edc_timeColumn);
            this.lvoStatus.AllColumns.Add(this.hb_statusColumn);
            this.lvoStatus.AllColumns.Add(this.hb_timeColumn);
            this.lvoStatus.AllColumns.Add(this.gw_locationColumn);
            this.lvoStatus.AlternateRowBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lvoStatus.CheckBoxes = true;
            this.lvoStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.gw_idColumn,
            this.gw_ipColumn,
            this.gw_statusColumn,
            this.edc_timeColumn,
            this.hb_statusColumn,
            this.hb_timeColumn,
            this.gw_locationColumn});
            this.lvoStatus.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvoStatus.FullRowSelect = true;
            this.lvoStatus.GridLines = true;
            this.lvoStatus.HasCollapsibleGroups = false;
            this.lvoStatus.Location = new System.Drawing.Point(23, 76);
            this.lvoStatus.MenuLabelColumns = "";
            this.lvoStatus.MenuLabelGroupBy = "";
            this.lvoStatus.MenuLabelLockGroupingOn = "";
            this.lvoStatus.Name = "lvoStatus";
            this.lvoStatus.ShowImagesOnSubItems = true;
            this.lvoStatus.Size = new System.Drawing.Size(1367, 850);
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
            this.gw_idColumn.Text = "Gateway ID";
            this.gw_idColumn.Width = 110;
            // 
            // gw_ipColumn
            // 
            this.gw_ipColumn.AspectName = "gateway_ip";
            this.gw_ipColumn.Text = "Gatewya IP";
            this.gw_ipColumn.Width = 90;
            // 
            // gw_statusColumn
            // 
            this.gw_statusColumn.AspectName = "gateway_status";
            this.gw_statusColumn.Text = "Status";
            this.gw_statusColumn.Width = 80;
            // 
            // edc_timeColumn
            // 
            this.edc_timeColumn.AspectName = "last_edc_time";
            this.edc_timeColumn.Text = "Last EDC Time";
            this.edc_timeColumn.Width = 140;
            // 
            // hb_statusColumn
            // 
            this.hb_statusColumn.AspectName = "hb_status";
            this.hb_statusColumn.Text = "H/B Status";
            this.hb_statusColumn.Width = 80;
            // 
            // hb_timeColumn
            // 
            this.hb_timeColumn.AspectName = "hb_report_time";
            this.hb_timeColumn.Text = "H/B Time";
            this.hb_timeColumn.Width = 140;
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
            // gw_locationColumn
            // 
            this.gw_locationColumn.AspectName = "gateway_location";
            this.gw_locationColumn.Text = "Location";
            // 
            // frmOnlineMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1419, 1038);
            this.Controls.Add(this.lvoStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReadData);
            this.Controls.Add(this.btnStart);
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
        private BrightIdeasSoftware.OLVColumn gw_ipColumn;
        private BrightIdeasSoftware.OLVColumn gw_statusColumn;
        private BrightIdeasSoftware.OLVColumn edc_timeColumn;
        private BrightIdeasSoftware.OLVColumn hb_statusColumn;
        private BrightIdeasSoftware.OLVColumn hb_timeColumn;
        private System.Windows.Forms.ImageList imageList1;
        private BrightIdeasSoftware.OLVColumn gw_locationColumn;
    }
}