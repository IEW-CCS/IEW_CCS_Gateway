namespace IEW.GatewayService.GUI
{
    partial class frmEditDevice
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditDevice));
            this.txtDeviceID = new System.Windows.Forms.TextBox();
            this.lblDeviceID = new System.Windows.Forms.Label();
            this.lblDeviceType = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtPLC_IP = new System.Windows.Forms.TextBox();
            this.lblPLC_IP = new System.Windows.Forms.Label();
            this.txtPLC_Port = new System.Windows.Forms.TextBox();
            this.lblPLC_Port = new System.Windows.Forms.Label();
            this.txtBLE_Mac = new System.Windows.Forms.TextBox();
            this.lblBLE_Mac = new System.Windows.Forms.Label();
            this.txtBLE_Service_UUID = new System.Windows.Forms.TextBox();
            this.lblBLE_Service_UUID = new System.Windows.Forms.Label();
            this.btnDeviceCancel = new System.Windows.Forms.Button();
            this.btnDeviceSave = new System.Windows.Forms.Button();
            this.pnlBLE = new System.Windows.Forms.Panel();
            this.pnlPLC = new System.Windows.Forms.Panel();
            this.btnTagRemove = new System.Windows.Forms.Button();
            this.btnTagAdd = new System.Windows.Forms.Button();
            this.btnLoadTag = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lvCalcTagList = new System.Windows.Forms.ListView();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.btnCalcTagRemove = new System.Windows.Forms.Button();
            this.btnCalcTagAdd = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlBLE.SuspendLayout();
            this.pnlPLC.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDeviceID
            // 
            this.txtDeviceID.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDeviceID.Location = new System.Drawing.Point(121, 12);
            this.txtDeviceID.Margin = new System.Windows.Forms.Padding(2);
            this.txtDeviceID.Name = "txtDeviceID";
            this.txtDeviceID.Size = new System.Drawing.Size(158, 23);
            this.txtDeviceID.TabIndex = 4;
            // 
            // lblDeviceID
            // 
            this.lblDeviceID.AutoSize = true;
            this.lblDeviceID.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceID.Location = new System.Drawing.Point(20, 12);
            this.lblDeviceID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeviceID.Name = "lblDeviceID";
            this.lblDeviceID.Size = new System.Drawing.Size(62, 17);
            this.lblDeviceID.TabIndex = 3;
            this.lblDeviceID.Text = "Device ID: ";
            // 
            // lblDeviceType
            // 
            this.lblDeviceType.AutoSize = true;
            this.lblDeviceType.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceType.Location = new System.Drawing.Point(20, 40);
            this.lblDeviceType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeviceType.Name = "lblDeviceType";
            this.lblDeviceType.Size = new System.Drawing.Size(76, 17);
            this.lblDeviceType.TabIndex = 5;
            this.lblDeviceType.Text = "Device Type: ";
            this.lblDeviceType.Click += new System.EventHandler(this.lblDeviceType_Click);
            // 
            // cmbType
            // 
            this.cmbType.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(121, 38);
            this.cmbType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(158, 24);
            this.cmbType.TabIndex = 6;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // txtPLC_IP
            // 
            this.txtPLC_IP.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPLC_IP.Location = new System.Drawing.Point(142, 12);
            this.txtPLC_IP.Margin = new System.Windows.Forms.Padding(2);
            this.txtPLC_IP.Name = "txtPLC_IP";
            this.txtPLC_IP.Size = new System.Drawing.Size(158, 23);
            this.txtPLC_IP.TabIndex = 8;
            // 
            // lblPLC_IP
            // 
            this.lblPLC_IP.AutoSize = true;
            this.lblPLC_IP.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLC_IP.Location = new System.Drawing.Point(22, 13);
            this.lblPLC_IP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPLC_IP.Name = "lblPLC_IP";
            this.lblPLC_IP.Size = new System.Drawing.Size(50, 17);
            this.lblPLC_IP.TabIndex = 7;
            this.lblPLC_IP.Text = "PLC IP: ";
            // 
            // txtPLC_Port
            // 
            this.txtPLC_Port.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPLC_Port.Location = new System.Drawing.Point(142, 40);
            this.txtPLC_Port.Margin = new System.Windows.Forms.Padding(2);
            this.txtPLC_Port.Name = "txtPLC_Port";
            this.txtPLC_Port.Size = new System.Drawing.Size(158, 23);
            this.txtPLC_Port.TabIndex = 10;
            // 
            // lblPLC_Port
            // 
            this.lblPLC_Port.AutoSize = true;
            this.lblPLC_Port.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLC_Port.Location = new System.Drawing.Point(22, 42);
            this.lblPLC_Port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPLC_Port.Name = "lblPLC_Port";
            this.lblPLC_Port.Size = new System.Drawing.Size(59, 17);
            this.lblPLC_Port.TabIndex = 9;
            this.lblPLC_Port.Text = "PLC Port: ";
            // 
            // txtBLE_Mac
            // 
            this.txtBLE_Mac.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBLE_Mac.Location = new System.Drawing.Point(158, 12);
            this.txtBLE_Mac.Margin = new System.Windows.Forms.Padding(2);
            this.txtBLE_Mac.Name = "txtBLE_Mac";
            this.txtBLE_Mac.Size = new System.Drawing.Size(158, 23);
            this.txtBLE_Mac.TabIndex = 12;
            // 
            // lblBLE_Mac
            // 
            this.lblBLE_Mac.AutoSize = true;
            this.lblBLE_Mac.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBLE_Mac.Location = new System.Drawing.Point(22, 14);
            this.lblBLE_Mac.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBLE_Mac.Name = "lblBLE_Mac";
            this.lblBLE_Mac.Size = new System.Drawing.Size(66, 17);
            this.lblBLE_Mac.TabIndex = 11;
            this.lblBLE_Mac.Text = "BLE MAC: ";
            // 
            // txtBLE_Service_UUID
            // 
            this.txtBLE_Service_UUID.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBLE_Service_UUID.Location = new System.Drawing.Point(158, 42);
            this.txtBLE_Service_UUID.Margin = new System.Windows.Forms.Padding(2);
            this.txtBLE_Service_UUID.Name = "txtBLE_Service_UUID";
            this.txtBLE_Service_UUID.Size = new System.Drawing.Size(158, 23);
            this.txtBLE_Service_UUID.TabIndex = 14;
            // 
            // lblBLE_Service_UUID
            // 
            this.lblBLE_Service_UUID.AutoSize = true;
            this.lblBLE_Service_UUID.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBLE_Service_UUID.Location = new System.Drawing.Point(22, 43);
            this.lblBLE_Service_UUID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBLE_Service_UUID.Name = "lblBLE_Service_UUID";
            this.lblBLE_Service_UUID.Size = new System.Drawing.Size(107, 17);
            this.lblBLE_Service_UUID.TabIndex = 13;
            this.lblBLE_Service_UUID.Text = "BLE Service UUID: ";
            // 
            // btnDeviceCancel
            // 
            this.btnDeviceCancel.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceCancel.Location = new System.Drawing.Point(335, 511);
            this.btnDeviceCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeviceCancel.Name = "btnDeviceCancel";
            this.btnDeviceCancel.Size = new System.Drawing.Size(79, 34);
            this.btnDeviceCancel.TabIndex = 16;
            this.btnDeviceCancel.Text = "Cancel";
            this.btnDeviceCancel.UseVisualStyleBackColor = true;
            this.btnDeviceCancel.Click += new System.EventHandler(this.btnDeviceCancel_Click);
            // 
            // btnDeviceSave
            // 
            this.btnDeviceSave.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceSave.Location = new System.Drawing.Point(237, 511);
            this.btnDeviceSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeviceSave.Name = "btnDeviceSave";
            this.btnDeviceSave.Size = new System.Drawing.Size(79, 34);
            this.btnDeviceSave.TabIndex = 15;
            this.btnDeviceSave.Text = "OK";
            this.btnDeviceSave.UseVisualStyleBackColor = true;
            this.btnDeviceSave.Click += new System.EventHandler(this.btnDeviceSave_Click);
            // 
            // pnlBLE
            // 
            this.pnlBLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBLE.Controls.Add(this.txtBLE_Mac);
            this.pnlBLE.Controls.Add(this.lblBLE_Mac);
            this.pnlBLE.Controls.Add(this.txtBLE_Service_UUID);
            this.pnlBLE.Controls.Add(this.lblBLE_Service_UUID);
            this.pnlBLE.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlBLE.Location = new System.Drawing.Point(374, 72);
            this.pnlBLE.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBLE.Name = "pnlBLE";
            this.pnlBLE.Size = new System.Drawing.Size(354, 76);
            this.pnlBLE.TabIndex = 17;
            // 
            // pnlPLC
            // 
            this.pnlPLC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPLC.Controls.Add(this.txtPLC_Port);
            this.pnlPLC.Controls.Add(this.lblPLC_IP);
            this.pnlPLC.Controls.Add(this.txtPLC_IP);
            this.pnlPLC.Controls.Add(this.lblPLC_Port);
            this.pnlPLC.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPLC.Location = new System.Drawing.Point(23, 72);
            this.pnlPLC.Margin = new System.Windows.Forms.Padding(2);
            this.pnlPLC.Name = "pnlPLC";
            this.pnlPLC.Size = new System.Drawing.Size(331, 76);
            this.pnlPLC.TabIndex = 18;
            // 
            // btnTagRemove
            // 
            this.btnTagRemove.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnTagRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTagRemove.FlatAppearance.BorderSize = 0;
            this.btnTagRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagRemove.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTagRemove.Location = new System.Drawing.Point(706, 341);
            this.btnTagRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnTagRemove.Name = "btnTagRemove";
            this.btnTagRemove.Size = new System.Drawing.Size(22, 22);
            this.btnTagRemove.TabIndex = 22;
            this.btnTagRemove.UseVisualStyleBackColor = true;
            this.btnTagRemove.Click += new System.EventHandler(this.btnTagRemove_Click);
            // 
            // btnTagAdd
            // 
            this.btnTagAdd.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnTagAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTagAdd.FlatAppearance.BorderSize = 0;
            this.btnTagAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTagAdd.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTagAdd.Location = new System.Drawing.Point(681, 341);
            this.btnTagAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnTagAdd.Name = "btnTagAdd";
            this.btnTagAdd.Size = new System.Drawing.Size(22, 22);
            this.btnTagAdd.TabIndex = 21;
            this.btnTagAdd.UseVisualStyleBackColor = true;
            this.btnTagAdd.Click += new System.EventHandler(this.btnTagAdd_Click);
            // 
            // btnLoadTag
            // 
            this.btnLoadTag.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadTag.Location = new System.Drawing.Point(461, 511);
            this.btnLoadTag.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoadTag.Name = "btnLoadTag";
            this.btnLoadTag.Size = new System.Drawing.Size(110, 34);
            this.btnLoadTag.TabIndex = 23;
            this.btnLoadTag.Text = "Load Tag Template";
            this.btnLoadTag.UseVisualStyleBackColor = true;
            this.btnLoadTag.Click += new System.EventHandler(this.btnLoadTag_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 158);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 27;
            this.label2.Text = "Normal Tag:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 351);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 26;
            this.label1.Text = "Calculation Tag:";
            // 
            // lvCalcTagList
            // 
            this.lvCalcTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCalcTagList.FullRowSelect = true;
            this.lvCalcTagList.GridLines = true;
            this.lvCalcTagList.Location = new System.Drawing.Point(23, 374);
            this.lvCalcTagList.Margin = new System.Windows.Forms.Padding(2);
            this.lvCalcTagList.Name = "lvCalcTagList";
            this.lvCalcTagList.Size = new System.Drawing.Size(705, 122);
            this.lvCalcTagList.TabIndex = 25;
            this.lvCalcTagList.UseCompatibleStateImageBehavior = false;
            this.lvCalcTagList.View = System.Windows.Forms.View.Details;
            this.lvCalcTagList.DoubleClick += new System.EventHandler(this.lvCalcTagList_DoubleClick);
            // 
            // lvTagList
            // 
            this.lvTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.GridLines = true;
            this.lvTagList.Location = new System.Drawing.Point(23, 181);
            this.lvTagList.Margin = new System.Windows.Forms.Padding(2);
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(705, 156);
            this.lvTagList.TabIndex = 24;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            this.lvTagList.DoubleClick += new System.EventHandler(this.lvTagList_DoubleClick);
            // 
            // btnCalcTagRemove
            // 
            this.btnCalcTagRemove.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnCalcTagRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCalcTagRemove.FlatAppearance.BorderSize = 0;
            this.btnCalcTagRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcTagRemove.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCalcTagRemove.Location = new System.Drawing.Point(706, 500);
            this.btnCalcTagRemove.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalcTagRemove.Name = "btnCalcTagRemove";
            this.btnCalcTagRemove.Size = new System.Drawing.Size(22, 22);
            this.btnCalcTagRemove.TabIndex = 29;
            this.btnCalcTagRemove.UseVisualStyleBackColor = true;
            this.btnCalcTagRemove.Click += new System.EventHandler(this.btnCalcTagRemove_Click);
            // 
            // btnCalcTagAdd
            // 
            this.btnCalcTagAdd.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnCalcTagAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCalcTagAdd.FlatAppearance.BorderSize = 0;
            this.btnCalcTagAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcTagAdd.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCalcTagAdd.Location = new System.Drawing.Point(681, 500);
            this.btnCalcTagAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalcTagAdd.Name = "btnCalcTagAdd";
            this.btnCalcTagAdd.Size = new System.Drawing.Size(22, 22);
            this.btnCalcTagAdd.TabIndex = 28;
            this.btnCalcTagAdd.UseVisualStyleBackColor = true;
            this.btnCalcTagAdd.Click += new System.EventHandler(this.btnCalcTagAdd_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(420, 9);
            this.txtLocation.Margin = new System.Windows.Forms.Padding(2);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(138, 23);
            this.txtLocation.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(334, 13);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 30;
            this.label4.Text = "Location: ";
            // 
            // frmEditDevice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(746, 556);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCalcTagRemove);
            this.Controls.Add(this.btnCalcTagAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvCalcTagList);
            this.Controls.Add(this.lvTagList);
            this.Controls.Add(this.btnLoadTag);
            this.Controls.Add(this.btnTagRemove);
            this.Controls.Add(this.btnTagAdd);
            this.Controls.Add(this.pnlPLC);
            this.Controls.Add(this.btnDeviceCancel);
            this.Controls.Add(this.btnDeviceSave);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lblDeviceType);
            this.Controls.Add(this.txtDeviceID);
            this.Controls.Add(this.lblDeviceID);
            this.Controls.Add(this.pnlBLE);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEditDevice";
            this.Text = "Add Device";
            this.Load += new System.EventHandler(this.frmEditDevice_Load);
            this.pnlBLE.ResumeLayout(false);
            this.pnlBLE.PerformLayout();
            this.pnlPLC.ResumeLayout(false);
            this.pnlPLC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDeviceID;
        private System.Windows.Forms.Label lblDeviceID;
        private System.Windows.Forms.Label lblDeviceType;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.TextBox txtPLC_IP;
        private System.Windows.Forms.Label lblPLC_IP;
        private System.Windows.Forms.TextBox txtPLC_Port;
        private System.Windows.Forms.Label lblPLC_Port;
        private System.Windows.Forms.TextBox txtBLE_Mac;
        private System.Windows.Forms.Label lblBLE_Mac;
        private System.Windows.Forms.TextBox txtBLE_Service_UUID;
        private System.Windows.Forms.Label lblBLE_Service_UUID;
        private System.Windows.Forms.Button btnDeviceCancel;
        private System.Windows.Forms.Button btnDeviceSave;
        private System.Windows.Forms.Panel pnlBLE;
        private System.Windows.Forms.Panel pnlPLC;
        private System.Windows.Forms.Button btnTagRemove;
        private System.Windows.Forms.Button btnTagAdd;
        private System.Windows.Forms.Button btnLoadTag;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvCalcTagList;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.Button btnCalcTagRemove;
        private System.Windows.Forms.Button btnCalcTagAdd;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label4;
    }
}