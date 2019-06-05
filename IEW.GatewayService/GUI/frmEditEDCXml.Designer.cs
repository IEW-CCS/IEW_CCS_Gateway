namespace IEW.GatewayService.GUI
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
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtReportInterval = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReportPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.cmbEDCHeaderSet = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lvHeaderItemList = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.lvCalcTagList = new System.Windows.Forms.ListView();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCancelEDCXml = new System.Windows.Forms.Button();
            this.btnSaveEDCXml = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial ID";
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(168, 54);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(190, 38);
            this.txtSerial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 31);
            this.label2.TabIndex = 2;
            this.label2.Text = "Gateway ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 31);
            this.label3.TabIndex = 3;
            this.label3.Text = "Device ID";
            // 
            // cmbGateway
            // 
            this.cmbGateway.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGateway.FormattingEnabled = true;
            this.cmbGateway.Location = new System.Drawing.Point(168, 109);
            this.cmbGateway.Name = "cmbGateway";
            this.cmbGateway.Size = new System.Drawing.Size(190, 39);
            this.cmbGateway.TabIndex = 4;
            this.cmbGateway.SelectedIndexChanged += new System.EventHandler(this.cmbGateway_SelectedIndexChanged);
            // 
            // cmbDevice
            // 
            this.cmbDevice.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(168, 165);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(190, 39);
            this.cmbDevice.TabIndex = 5;
            this.cmbDevice.SelectedIndexChanged += new System.EventHandler(this.cmbDevice_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnable);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1322, 226);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Information";
            // 
            // cmbReportType
            // 
            this.cmbReportType.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Location = new System.Drawing.Point(595, 53);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(190, 39);
            this.cmbReportType.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(413, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 31);
            this.label4.TabIndex = 6;
            this.label4.Text = "Report type";
            // 
            // txtReportInterval
            // 
            this.txtReportInterval.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportInterval.Location = new System.Drawing.Point(595, 109);
            this.txtReportInterval.Name = "txtReportInterval";
            this.txtReportInterval.Size = new System.Drawing.Size(190, 38);
            this.txtReportInterval.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(413, 110);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 31);
            this.label5.TabIndex = 8;
            this.label5.Text = "Report Interval";
            // 
            // txtReportPath
            // 
            this.txtReportPath.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReportPath.Location = new System.Drawing.Point(595, 166);
            this.txtReportPath.Name = "txtReportPath";
            this.txtReportPath.Size = new System.Drawing.Size(556, 38);
            this.txtReportPath.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(413, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 31);
            this.label6.TabIndex = 10;
            this.label6.Text = "Report Path";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(1171, 161);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(128, 48);
            this.btnBrowse.TabIndex = 12;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(904, 63);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(114, 35);
            this.chkEnable.TabIndex = 13;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // cmbEDCHeaderSet
            // 
            this.cmbEDCHeaderSet.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEDCHeaderSet.FormattingEnabled = true;
            this.cmbEDCHeaderSet.Location = new System.Drawing.Point(220, 257);
            this.cmbEDCHeaderSet.Name = "cmbEDCHeaderSet";
            this.cmbEDCHeaderSet.Size = new System.Drawing.Size(190, 39);
            this.cmbEDCHeaderSet.TabIndex = 6;
            this.cmbEDCHeaderSet.SelectedIndexChanged += new System.EventHandler(this.cmbEDCHeaderSet_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 31);
            this.label7.TabIndex = 5;
            this.label7.Text = "EDC Header Set";
            // 
            // lvHeaderItemList
            // 
            this.lvHeaderItemList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHeaderItemList.FullRowSelect = true;
            this.lvHeaderItemList.GridLines = true;
            this.lvHeaderItemList.Location = new System.Drawing.Point(37, 323);
            this.lvHeaderItemList.Name = "lvHeaderItemList";
            this.lvHeaderItemList.Size = new System.Drawing.Size(389, 288);
            this.lvHeaderItemList.TabIndex = 7;
            this.lvHeaderItemList.UseCompatibleStateImageBehavior = false;
            this.lvHeaderItemList.View = System.Windows.Forms.View.Details;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(459, 262);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(168, 31);
            this.label8.TabIndex = 8;
            this.label8.Text = "Normal Tag List";
            // 
            // lvTagList
            // 
            this.lvTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.GridLines = true;
            this.lvTagList.Location = new System.Drawing.Point(465, 323);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(870, 288);
            this.lvTagList.TabIndex = 9;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            // 
            // lvCalcTagList
            // 
            this.lvCalcTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCalcTagList.FullRowSelect = true;
            this.lvCalcTagList.GridLines = true;
            this.lvCalcTagList.Location = new System.Drawing.Point(37, 673);
            this.lvCalcTagList.Name = "lvCalcTagList";
            this.lvCalcTagList.Size = new System.Drawing.Size(1298, 288);
            this.lvCalcTagList.TabIndex = 11;
            this.lvCalcTagList.UseCompatibleStateImageBehavior = false;
            this.lvCalcTagList.View = System.Windows.Forms.View.Details;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 630);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(206, 31);
            this.label9.TabIndex = 10;
            this.label9.Text = "Calculation Tag List";
            // 
            // btnCancelEDCXml
            // 
            this.btnCancelEDCXml.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelEDCXml.Location = new System.Drawing.Point(663, 996);
            this.btnCancelEDCXml.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnCancelEDCXml.Name = "btnCancelEDCXml";
            this.btnCancelEDCXml.Size = new System.Drawing.Size(158, 72);
            this.btnCancelEDCXml.TabIndex = 34;
            this.btnCancelEDCXml.Text = "Cancel";
            this.btnCancelEDCXml.UseVisualStyleBackColor = true;
            // 
            // btnSaveEDCXml
            // 
            this.btnSaveEDCXml.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveEDCXml.Location = new System.Drawing.Point(466, 996);
            this.btnSaveEDCXml.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnSaveEDCXml.Name = "btnSaveEDCXml";
            this.btnSaveEDCXml.Size = new System.Drawing.Size(158, 72);
            this.btnSaveEDCXml.TabIndex = 33;
            this.btnSaveEDCXml.Text = "Save";
            this.btnSaveEDCXml.UseVisualStyleBackColor = true;
            // 
            // frmEditEDCXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1364, 1102);
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
            this.Name = "frmEditEDCXml";
            this.Text = "frmEditEDCXml";
            this.Load += new System.EventHandler(this.frmEditEDCXml_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkEnable;
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
    }
}