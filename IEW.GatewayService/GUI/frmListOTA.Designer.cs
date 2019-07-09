namespace IEW.GatewayService.GUI
{
    partial class frmListOTA
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
            this.gbFTPServer = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServerPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabOTA = new System.Windows.Forms.TabControl();
            this.tabPageIOT = new System.Windows.Forms.TabPage();
            this.lvIOTList = new System.Windows.Forms.ListView();
            this.tabPageWorker = new System.Windows.Forms.TabPage();
            this.lvWorkerList = new System.Windows.Forms.ListView();
            this.tabPageFirmware = new System.Windows.Forms.TabPage();
            this.lvFirmwareList = new System.Windows.Forms.ListView();
            this.btnSetup = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.cmbIOTVersion = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWorkerVersion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbFirmwareVersion = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gbFTPServer.SuspendLayout();
            this.tabOTA.SuspendLayout();
            this.tabPageIOT.SuspendLayout();
            this.tabPageWorker.SuspendLayout();
            this.tabPageFirmware.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFTPServer
            // 
            this.gbFTPServer.Controls.Add(this.txtPassword);
            this.gbFTPServer.Controls.Add(this.label3);
            this.gbFTPServer.Controls.Add(this.txtUserID);
            this.gbFTPServer.Controls.Add(this.label4);
            this.gbFTPServer.Controls.Add(this.txtServerPort);
            this.gbFTPServer.Controls.Add(this.label2);
            this.gbFTPServer.Controls.Add(this.txtServerIP);
            this.gbFTPServer.Controls.Add(this.label1);
            this.gbFTPServer.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFTPServer.Location = new System.Drawing.Point(9, 9);
            this.gbFTPServer.Name = "gbFTPServer";
            this.gbFTPServer.Size = new System.Drawing.Size(723, 72);
            this.gbFTPServer.TabIndex = 1;
            this.gbFTPServer.TabStop = false;
            this.gbFTPServer.Text = "FTP Server Information";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(615, 28);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 22);
            this.txtPassword.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Password";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(427, 28);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(100, 22);
            this.txtUserID.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(367, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "User ID";
            // 
            // txtServerPort
            // 
            this.txtServerPort.Location = new System.Drawing.Point(258, 28);
            this.txtServerPort.Name = "txtServerPort";
            this.txtServerPort.Size = new System.Drawing.Size(100, 22);
            this.txtServerPort.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server Port";
            // 
            // txtServerIP
            // 
            this.txtServerIP.Location = new System.Drawing.Point(70, 28);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(100, 22);
            this.txtServerIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP";
            // 
            // tabOTA
            // 
            this.tabOTA.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabOTA.Controls.Add(this.tabPageIOT);
            this.tabOTA.Controls.Add(this.tabPageWorker);
            this.tabOTA.Controls.Add(this.tabPageFirmware);
            this.tabOTA.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabOTA.Location = new System.Drawing.Point(9, 78);
            this.tabOTA.Name = "tabOTA";
            this.tabOTA.SelectedIndex = 0;
            this.tabOTA.Size = new System.Drawing.Size(723, 428);
            this.tabOTA.TabIndex = 2;
            this.tabOTA.SelectedIndexChanged += new System.EventHandler(this.tabOTA_SelectedIndexChanged);
            // 
            // tabPageIOT
            // 
            this.tabPageIOT.Controls.Add(this.cmbIOTVersion);
            this.tabPageIOT.Controls.Add(this.label5);
            this.tabPageIOT.Controls.Add(this.lvIOTList);
            this.tabPageIOT.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageIOT.Location = new System.Drawing.Point(4, 28);
            this.tabPageIOT.Name = "tabPageIOT";
            this.tabPageIOT.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIOT.Size = new System.Drawing.Size(715, 396);
            this.tabPageIOT.TabIndex = 0;
            this.tabPageIOT.Text = "IoTClient";
            this.tabPageIOT.UseVisualStyleBackColor = true;
            // 
            // lvIOTList
            // 
            this.lvIOTList.CheckBoxes = true;
            this.lvIOTList.Location = new System.Drawing.Point(7, 39);
            this.lvIOTList.Name = "lvIOTList";
            this.lvIOTList.Size = new System.Drawing.Size(702, 354);
            this.lvIOTList.TabIndex = 0;
            this.lvIOTList.UseCompatibleStateImageBehavior = false;
            this.lvIOTList.View = System.Windows.Forms.View.Details;
            // 
            // tabPageWorker
            // 
            this.tabPageWorker.Controls.Add(this.cmbWorkerVersion);
            this.tabPageWorker.Controls.Add(this.label6);
            this.tabPageWorker.Controls.Add(this.lvWorkerList);
            this.tabPageWorker.Location = new System.Drawing.Point(4, 28);
            this.tabPageWorker.Name = "tabPageWorker";
            this.tabPageWorker.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWorker.Size = new System.Drawing.Size(715, 396);
            this.tabPageWorker.TabIndex = 1;
            this.tabPageWorker.Text = "Worker";
            this.tabPageWorker.UseVisualStyleBackColor = true;
            // 
            // lvWorkerList
            // 
            this.lvWorkerList.CheckBoxes = true;
            this.lvWorkerList.Location = new System.Drawing.Point(7, 39);
            this.lvWorkerList.Name = "lvWorkerList";
            this.lvWorkerList.Size = new System.Drawing.Size(702, 354);
            this.lvWorkerList.TabIndex = 1;
            this.lvWorkerList.UseCompatibleStateImageBehavior = false;
            this.lvWorkerList.View = System.Windows.Forms.View.Details;
            // 
            // tabPageFirmware
            // 
            this.tabPageFirmware.Controls.Add(this.cmbFirmwareVersion);
            this.tabPageFirmware.Controls.Add(this.label7);
            this.tabPageFirmware.Controls.Add(this.lvFirmwareList);
            this.tabPageFirmware.Location = new System.Drawing.Point(4, 28);
            this.tabPageFirmware.Name = "tabPageFirmware";
            this.tabPageFirmware.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFirmware.Size = new System.Drawing.Size(715, 396);
            this.tabPageFirmware.TabIndex = 2;
            this.tabPageFirmware.Text = "Firmware";
            this.tabPageFirmware.UseVisualStyleBackColor = true;
            // 
            // lvFirmwareList
            // 
            this.lvFirmwareList.CheckBoxes = true;
            this.lvFirmwareList.Location = new System.Drawing.Point(7, 39);
            this.lvFirmwareList.Name = "lvFirmwareList";
            this.lvFirmwareList.Size = new System.Drawing.Size(702, 354);
            this.lvFirmwareList.TabIndex = 1;
            this.lvFirmwareList.UseCompatibleStateImageBehavior = false;
            this.lvFirmwareList.View = System.Windows.Forms.View.Details;
            // 
            // btnSetup
            // 
            this.btnSetup.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetup.Location = new System.Drawing.Point(13, 511);
            this.btnSetup.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnSetup.Name = "btnSetup";
            this.btnSetup.Size = new System.Drawing.Size(79, 36);
            this.btnSetup.TabIndex = 36;
            this.btnSetup.Text = "Setup";
            this.btnSetup.UseVisualStyleBackColor = true;
            this.btnSetup.Click += new System.EventHandler(this.btnSetup_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(342, 511);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(79, 36);
            this.btnUpdate.TabIndex = 35;
            this.btnUpdate.Text = "OTA Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // cmbIOTVersion
            // 
            this.cmbIOTVersion.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbIOTVersion.FormattingEnabled = true;
            this.cmbIOTVersion.Location = new System.Drawing.Point(108, 9);
            this.cmbIOTVersion.Name = "cmbIOTVersion";
            this.cmbIOTVersion.Size = new System.Drawing.Size(121, 24);
            this.cmbIOTVersion.TabIndex = 61;
            this.cmbIOTVersion.SelectedIndexChanged += new System.EventHandler(this.cmbIOTVersion_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 60;
            this.label5.Text = "New Version List";
            // 
            // cmbWorkerVersion
            // 
            this.cmbWorkerVersion.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWorkerVersion.FormattingEnabled = true;
            this.cmbWorkerVersion.Location = new System.Drawing.Point(108, 9);
            this.cmbWorkerVersion.Name = "cmbWorkerVersion";
            this.cmbWorkerVersion.Size = new System.Drawing.Size(121, 24);
            this.cmbWorkerVersion.TabIndex = 63;
            this.cmbWorkerVersion.SelectedIndexChanged += new System.EventHandler(this.cmbWorkerVersion_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 12);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 62;
            this.label6.Text = "New Version List";
            // 
            // cmbFirmwareVersion
            // 
            this.cmbFirmwareVersion.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFirmwareVersion.FormattingEnabled = true;
            this.cmbFirmwareVersion.Location = new System.Drawing.Point(108, 9);
            this.cmbFirmwareVersion.Name = "cmbFirmwareVersion";
            this.cmbFirmwareVersion.Size = new System.Drawing.Size(121, 24);
            this.cmbFirmwareVersion.TabIndex = 65;
            this.cmbFirmwareVersion.SelectedIndexChanged += new System.EventHandler(this.cmbFirmwareVersion_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 12);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 17);
            this.label7.TabIndex = 64;
            this.label7.Text = "New Version List";
            // 
            // frmListOTA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 556);
            this.Controls.Add(this.btnSetup);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tabOTA);
            this.Controls.Add(this.gbFTPServer);
            this.Name = "frmListOTA";
            this.Text = "frmListOTA";
            this.Load += new System.EventHandler(this.frmListOTA_Load);
            this.gbFTPServer.ResumeLayout(false);
            this.gbFTPServer.PerformLayout();
            this.tabOTA.ResumeLayout(false);
            this.tabPageIOT.ResumeLayout(false);
            this.tabPageIOT.PerformLayout();
            this.tabPageWorker.ResumeLayout(false);
            this.tabPageWorker.PerformLayout();
            this.tabPageFirmware.ResumeLayout(false);
            this.tabPageFirmware.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFTPServer;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtServerPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabOTA;
        private System.Windows.Forms.TabPage tabPageIOT;
        private System.Windows.Forms.TabPage tabPageWorker;
        private System.Windows.Forms.TabPage tabPageFirmware;
        private System.Windows.Forms.Button btnSetup;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListView lvIOTList;
        private System.Windows.Forms.ListView lvWorkerList;
        private System.Windows.Forms.ListView lvFirmwareList;
        private System.Windows.Forms.ComboBox cmbIOTVersion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbWorkerVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbFirmwareVersion;
        private System.Windows.Forms.Label label7;
    }
}