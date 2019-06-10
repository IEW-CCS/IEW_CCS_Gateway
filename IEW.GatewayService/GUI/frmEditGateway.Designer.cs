﻿namespace IEW.GatewayService.GUI
{
    partial class frmEditGateway
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditGateway));
            this.lblGatewayID = new System.Windows.Forms.Label();
            this.lblGatewayIP = new System.Windows.Forms.Label();
            this.txtGatewayID = new System.Windows.Forms.TextBox();
            this.txtGatewayIP = new System.Windows.Forms.TextBox();
            this.lblDeviceList = new System.Windows.Forms.Label();
            this.lvGWDevice = new System.Windows.Forms.ListView();
            this.btnDeviceRemove = new System.Windows.Forms.Button();
            this.btnDeviceAdd = new System.Windows.Forms.Button();
            this.btnGWSave = new System.Windows.Forms.Button();
            this.btnGWCancel = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblGatewayID
            // 
            this.lblGatewayID.AutoSize = true;
            this.lblGatewayID.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGatewayID.Location = new System.Drawing.Point(47, 40);
            this.lblGatewayID.Name = "lblGatewayID";
            this.lblGatewayID.Size = new System.Drawing.Size(140, 31);
            this.lblGatewayID.TabIndex = 0;
            this.lblGatewayID.Text = "Gateway ID: ";
            // 
            // lblGatewayIP
            // 
            this.lblGatewayIP.AutoSize = true;
            this.lblGatewayIP.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGatewayIP.Location = new System.Drawing.Point(47, 100);
            this.lblGatewayIP.Name = "lblGatewayIP";
            this.lblGatewayIP.Size = new System.Drawing.Size(139, 31);
            this.lblGatewayIP.TabIndex = 1;
            this.lblGatewayIP.Text = "Gateway IP: ";
            // 
            // txtGatewayID
            // 
            this.txtGatewayID.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGatewayID.Location = new System.Drawing.Point(221, 33);
            this.txtGatewayID.Name = "txtGatewayID";
            this.txtGatewayID.Size = new System.Drawing.Size(272, 38);
            this.txtGatewayID.TabIndex = 2;
            // 
            // txtGatewayIP
            // 
            this.txtGatewayIP.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGatewayIP.Location = new System.Drawing.Point(221, 93);
            this.txtGatewayIP.Name = "txtGatewayIP";
            this.txtGatewayIP.Size = new System.Drawing.Size(272, 38);
            this.txtGatewayIP.TabIndex = 3;
            // 
            // lblDeviceList
            // 
            this.lblDeviceList.AutoSize = true;
            this.lblDeviceList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceList.Location = new System.Drawing.Point(47, 162);
            this.lblDeviceList.Name = "lblDeviceList";
            this.lblDeviceList.Size = new System.Drawing.Size(121, 31);
            this.lblDeviceList.TabIndex = 4;
            this.lblDeviceList.Text = "Device List";
            // 
            // lvGWDevice
            // 
            this.lvGWDevice.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGWDevice.FullRowSelect = true;
            this.lvGWDevice.GridLines = true;
            this.lvGWDevice.Location = new System.Drawing.Point(53, 210);
            this.lvGWDevice.Name = "lvGWDevice";
            this.lvGWDevice.Size = new System.Drawing.Size(1233, 521);
            this.lvGWDevice.TabIndex = 5;
            this.lvGWDevice.UseCompatibleStateImageBehavior = false;
            this.lvGWDevice.View = System.Windows.Forms.View.Details;
            this.lvGWDevice.DoubleClick += new System.EventHandler(this.lvGWDevice_DoubleClick);
            // 
            // btnDeviceRemove
            // 
            this.btnDeviceRemove.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnDeviceRemove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeviceRemove.FlatAppearance.BorderSize = 0;
            this.btnDeviceRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeviceRemove.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceRemove.Location = new System.Drawing.Point(1238, 750);
            this.btnDeviceRemove.Name = "btnDeviceRemove";
            this.btnDeviceRemove.Size = new System.Drawing.Size(48, 48);
            this.btnDeviceRemove.TabIndex = 7;
            this.btnDeviceRemove.UseVisualStyleBackColor = true;
            this.btnDeviceRemove.Click += new System.EventHandler(this.btnDeviceRemove_Click);
            // 
            // btnDeviceAdd
            // 
            this.btnDeviceAdd.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnDeviceAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDeviceAdd.FlatAppearance.BorderSize = 0;
            this.btnDeviceAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeviceAdd.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeviceAdd.Location = new System.Drawing.Point(1187, 750);
            this.btnDeviceAdd.Name = "btnDeviceAdd";
            this.btnDeviceAdd.Size = new System.Drawing.Size(48, 48);
            this.btnDeviceAdd.TabIndex = 6;
            this.btnDeviceAdd.UseVisualStyleBackColor = true;
            this.btnDeviceAdd.Click += new System.EventHandler(this.btnDeviceAdd_Click);
            // 
            // btnGWSave
            // 
            this.btnGWSave.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGWSave.Location = new System.Drawing.Point(487, 755);
            this.btnGWSave.Name = "btnGWSave";
            this.btnGWSave.Size = new System.Drawing.Size(158, 69);
            this.btnGWSave.TabIndex = 8;
            this.btnGWSave.Text = "Save";
            this.btnGWSave.UseVisualStyleBackColor = true;
            this.btnGWSave.Click += new System.EventHandler(this.btnGWSave_Click);
            // 
            // btnGWCancel
            // 
            this.btnGWCancel.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGWCancel.Location = new System.Drawing.Point(683, 757);
            this.btnGWCancel.Name = "btnGWCancel";
            this.btnGWCancel.Size = new System.Drawing.Size(158, 69);
            this.btnGWCancel.TabIndex = 9;
            this.btnGWCancel.Text = "Cancel";
            this.btnGWCancel.UseVisualStyleBackColor = true;
            this.btnGWCancel.Click += new System.EventHandler(this.btnGWCancel_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLocation.Location = new System.Drawing.Point(732, 33);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(272, 38);
            this.txtLocation.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(583, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 31);
            this.label1.TabIndex = 10;
            this.label1.Text = "Location: ";
            // 
            // frmEditGateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1328, 854);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGWCancel);
            this.Controls.Add(this.btnGWSave);
            this.Controls.Add(this.btnDeviceRemove);
            this.Controls.Add(this.btnDeviceAdd);
            this.Controls.Add(this.lvGWDevice);
            this.Controls.Add(this.lblDeviceList);
            this.Controls.Add(this.txtGatewayIP);
            this.Controls.Add(this.txtGatewayID);
            this.Controls.Add(this.lblGatewayIP);
            this.Controls.Add(this.lblGatewayID);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditGateway";
            this.Text = "Add Gateway";
            this.Load += new System.EventHandler(this.frmEditGateway_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGatewayID;
        private System.Windows.Forms.Label lblGatewayIP;
        private System.Windows.Forms.TextBox txtGatewayID;
        private System.Windows.Forms.TextBox txtGatewayIP;
        private System.Windows.Forms.Label lblDeviceList;
        private System.Windows.Forms.ListView lvGWDevice;
        private System.Windows.Forms.Button btnDeviceRemove;
        private System.Windows.Forms.Button btnDeviceAdd;
        private System.Windows.Forms.Button btnGWSave;
        private System.Windows.Forms.Button btnGWCancel;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label1;
    }
}