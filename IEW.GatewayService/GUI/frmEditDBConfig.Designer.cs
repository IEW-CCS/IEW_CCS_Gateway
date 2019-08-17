namespace IEW.GatewayService.GUI
{
    partial class frmEditDBConfig
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
            this.gpbDBInfo = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConnectDB = new System.Windows.Forms.TextBox();
            this.txtPortID = new System.Windows.Forms.TextBox();
            this.txtDataSource = new System.Windows.Forms.TextBox();
            this.cmbDBType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.cmbDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbGateway = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.label10 = new System.Windows.Forms.Label();
            this.btnCancelDBConfig = new System.Windows.Forms.Button();
            this.btnSaveDBConfig = new System.Windows.Forms.Button();
            this.lvCalcTagList = new System.Windows.Forms.ListView();
            this.label11 = new System.Windows.Forms.Label();
            this.chkCalcTagCheckAll = new System.Windows.Forms.CheckBox();
            this.chkTagCheckAll = new System.Windows.Forms.CheckBox();
            this.gpbDBInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbDBInfo
            // 
            this.gpbDBInfo.Controls.Add(this.txtPassword);
            this.gpbDBInfo.Controls.Add(this.label9);
            this.gpbDBInfo.Controls.Add(this.txtUserName);
            this.gpbDBInfo.Controls.Add(this.label8);
            this.gpbDBInfo.Controls.Add(this.txtConnectDB);
            this.gpbDBInfo.Controls.Add(this.txtPortID);
            this.gpbDBInfo.Controls.Add(this.txtDataSource);
            this.gpbDBInfo.Controls.Add(this.cmbDBType);
            this.gpbDBInfo.Controls.Add(this.label7);
            this.gpbDBInfo.Controls.Add(this.label6);
            this.gpbDBInfo.Controls.Add(this.label5);
            this.gpbDBInfo.Controls.Add(this.label4);
            this.gpbDBInfo.Controls.Add(this.txtSerial);
            this.gpbDBInfo.Controls.Add(this.cmbDevice);
            this.gpbDBInfo.Controls.Add(this.label1);
            this.gpbDBInfo.Controls.Add(this.cmbGateway);
            this.gpbDBInfo.Controls.Add(this.label2);
            this.gpbDBInfo.Controls.Add(this.label3);
            this.gpbDBInfo.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbDBInfo.Location = new System.Drawing.Point(-3, 11);
            this.gpbDBInfo.Margin = new System.Windows.Forms.Padding(2);
            this.gpbDBInfo.Name = "gpbDBInfo";
            this.gpbDBInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gpbDBInfo.Size = new System.Drawing.Size(732, 108);
            this.gpbDBInfo.TabIndex = 7;
            this.gpbDBInfo.TabStop = false;
            this.gpbDBInfo.Text = "Database Information";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(559, 68);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(138, 23);
            this.txtPassword.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(475, 70);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Password";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(559, 43);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(138, 23);
            this.txtUserName.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(475, 46);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "User Name";
            // 
            // txtConnectDB
            // 
            this.txtConnectDB.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConnectDB.Location = new System.Drawing.Point(559, 18);
            this.txtConnectDB.Margin = new System.Windows.Forms.Padding(2);
            this.txtConnectDB.Name = "txtConnectDB";
            this.txtConnectDB.Size = new System.Drawing.Size(138, 23);
            this.txtConnectDB.TabIndex = 17;
            // 
            // txtPortID
            // 
            this.txtPortID.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPortID.Location = new System.Drawing.Point(319, 70);
            this.txtPortID.Margin = new System.Windows.Forms.Padding(2);
            this.txtPortID.Name = "txtPortID";
            this.txtPortID.Size = new System.Drawing.Size(138, 23);
            this.txtPortID.TabIndex = 16;
            // 
            // txtDataSource
            // 
            this.txtDataSource.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataSource.Location = new System.Drawing.Point(319, 45);
            this.txtDataSource.Margin = new System.Windows.Forms.Padding(2);
            this.txtDataSource.Name = "txtDataSource";
            this.txtDataSource.Size = new System.Drawing.Size(138, 23);
            this.txtDataSource.TabIndex = 15;
            // 
            // cmbDBType
            // 
            this.cmbDBType.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDBType.FormattingEnabled = true;
            this.cmbDBType.Location = new System.Drawing.Point(319, 18);
            this.cmbDBType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDBType.Name = "cmbDBType";
            this.cmbDBType.Size = new System.Drawing.Size(138, 24);
            this.cmbDBType.TabIndex = 15;
            this.cmbDBType.SelectedIndexChanged += new System.EventHandler(this.cmbDBType_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(233, 24);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "DB Type";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(475, 21);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Connect DB";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(233, 71);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Port ID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(233, 48);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data Source";
            // 
            // txtSerial
            // 
            this.txtSerial.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerial.Location = new System.Drawing.Point(84, 21);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(125, 23);
            this.txtSerial.TabIndex = 1;
            // 
            // cmbDevice
            // 
            this.cmbDevice.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDevice.FormattingEnabled = true;
            this.cmbDevice.Location = new System.Drawing.Point(84, 70);
            this.cmbDevice.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDevice.Name = "cmbDevice";
            this.cmbDevice.Size = new System.Drawing.Size(125, 24);
            this.cmbDevice.TabIndex = 5;
            this.cmbDevice.SelectedIndexChanged += new System.EventHandler(this.cmbDevice_SelectedIndexChanged);
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
            // cmbGateway
            // 
            this.cmbGateway.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbGateway.FormattingEnabled = true;
            this.cmbGateway.Location = new System.Drawing.Point(84, 45);
            this.cmbGateway.Margin = new System.Windows.Forms.Padding(2);
            this.cmbGateway.Name = "cmbGateway";
            this.cmbGateway.Size = new System.Drawing.Size(125, 24);
            this.cmbGateway.TabIndex = 4;
            this.cmbGateway.SelectedIndexChanged += new System.EventHandler(this.cmbGateway_SelectedIndexChanged);
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
            this.label3.Location = new System.Drawing.Point(7, 70);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Device ID";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(671, 124);
            this.chkEnable.Margin = new System.Windows.Forms.Padding(2);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(56, 16);
            this.chkEnable.TabIndex = 14;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // lvTagList
            // 
            this.lvTagList.CheckBoxes = true;
            this.lvTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.GridLines = true;
            this.lvTagList.Location = new System.Drawing.Point(7, 147);
            this.lvTagList.Margin = new System.Windows.Forms.Padding(2);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(720, 173);
            this.lvTagList.TabIndex = 16;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 122);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Normal Tag List";
            // 
            // btnCancelDBConfig
            // 
            this.btnCancelDBConfig.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelDBConfig.Location = new System.Drawing.Point(379, 514);
            this.btnCancelDBConfig.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnCancelDBConfig.Name = "btnCancelDBConfig";
            this.btnCancelDBConfig.Size = new System.Drawing.Size(79, 36);
            this.btnCancelDBConfig.TabIndex = 38;
            this.btnCancelDBConfig.Text = "Cancel";
            this.btnCancelDBConfig.UseVisualStyleBackColor = true;
            this.btnCancelDBConfig.Click += new System.EventHandler(this.btnCancelDBConfig_Click);
            // 
            // btnSaveDBConfig
            // 
            this.btnSaveDBConfig.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDBConfig.Location = new System.Drawing.Point(280, 514);
            this.btnSaveDBConfig.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnSaveDBConfig.Name = "btnSaveDBConfig";
            this.btnSaveDBConfig.Size = new System.Drawing.Size(79, 36);
            this.btnSaveDBConfig.TabIndex = 37;
            this.btnSaveDBConfig.Text = "Save";
            this.btnSaveDBConfig.UseVisualStyleBackColor = true;
            this.btnSaveDBConfig.Click += new System.EventHandler(this.btnSaveDBConfig_Click);
            // 
            // lvCalcTagList
            // 
            this.lvCalcTagList.CheckBoxes = true;
            this.lvCalcTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCalcTagList.FullRowSelect = true;
            this.lvCalcTagList.GridLines = true;
            this.lvCalcTagList.Location = new System.Drawing.Point(7, 345);
            this.lvCalcTagList.Margin = new System.Windows.Forms.Padding(2);
            this.lvCalcTagList.Name = "lvCalcTagList";
            this.lvCalcTagList.Size = new System.Drawing.Size(720, 162);
            this.lvCalcTagList.TabIndex = 36;
            this.lvCalcTagList.UseCompatibleStateImageBehavior = false;
            this.lvCalcTagList.View = System.Windows.Forms.View.Details;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 324);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(101, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "Calculation Tag List";
            // 
            // chkCalcTagCheckAll
            // 
            this.chkCalcTagCheckAll.AutoSize = true;
            this.chkCalcTagCheckAll.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCalcTagCheckAll.Location = new System.Drawing.Point(135, 324);
            this.chkCalcTagCheckAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkCalcTagCheckAll.Name = "chkCalcTagCheckAll";
            this.chkCalcTagCheckAll.Size = new System.Drawing.Size(71, 20);
            this.chkCalcTagCheckAll.TabIndex = 40;
            this.chkCalcTagCheckAll.Text = "Check All";
            this.chkCalcTagCheckAll.UseVisualStyleBackColor = true;
            this.chkCalcTagCheckAll.CheckedChanged += new System.EventHandler(this.chkCalcTagCheckAll_CheckedChanged);
            // 
            // chkTagCheckAll
            // 
            this.chkTagCheckAll.AutoSize = true;
            this.chkTagCheckAll.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTagCheckAll.Location = new System.Drawing.Point(135, 124);
            this.chkTagCheckAll.Margin = new System.Windows.Forms.Padding(2);
            this.chkTagCheckAll.Name = "chkTagCheckAll";
            this.chkTagCheckAll.Size = new System.Drawing.Size(71, 20);
            this.chkTagCheckAll.TabIndex = 39;
            this.chkTagCheckAll.Text = "Check All";
            this.chkTagCheckAll.UseVisualStyleBackColor = true;
            this.chkTagCheckAll.CheckedChanged += new System.EventHandler(this.chkTagCheckAll_CheckedChanged);
            // 
            // frmEditDBConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 556);
            this.Controls.Add(this.chkCalcTagCheckAll);
            this.Controls.Add(this.chkTagCheckAll);
            this.Controls.Add(this.btnCancelDBConfig);
            this.Controls.Add(this.btnSaveDBConfig);
            this.Controls.Add(this.lvCalcTagList);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lvTagList);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.gpbDBInfo);
            this.Name = "frmEditDBConfig";
            this.Text = "frmEditDBConfig";
            this.Load += new System.EventHandler(this.frmEditDBConfig_Load);
            this.gpbDBInfo.ResumeLayout(false);
            this.gpbDBInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbDBInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSerial;
        private System.Windows.Forms.ComboBox cmbDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbGateway;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConnectDB;
        private System.Windows.Forms.TextBox txtPortID;
        private System.Windows.Forms.TextBox txtDataSource;
        private System.Windows.Forms.ComboBox cmbDBType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCancelDBConfig;
        private System.Windows.Forms.Button btnSaveDBConfig;
        private System.Windows.Forms.ListView lvCalcTagList;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkCalcTagCheckAll;
        private System.Windows.Forms.CheckBox chkTagCheckAll;
    }
}