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
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnCmdDownload
            // 
            this.btnCmdDownload.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark;
            this.btnCmdDownload.FlatAppearance.BorderSize = 2;
            this.btnCmdDownload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCmdDownload.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCmdDownload.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnCmdDownload.Location = new System.Drawing.Point(1584, 38);
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
            this.btnLoadConfig.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.imageList1.Images.SetKeyName(7, "edc_set.png");
            this.imageList1.Images.SetKeyName(8, "edc_set_list.png");
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveConfig.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveConfig.Location = new System.Drawing.Point(302, 38);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(216, 60);
            this.btnSaveConfig.TabIndex = 7;
            this.btnSaveConfig.Text = "Save Config";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMain.Location = new System.Drawing.Point(436, 126);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1586, 1076);
            this.pnlMain.TabIndex = 8;
            // 
            // Gateway
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2069, 1251);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.tvNodeList);
            this.Controls.Add(this.btnLoadConfig);
            this.Controls.Add(this.btnCmdDownload);
            this.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "Gateway";
            this.Text = "Gateway";
            this.Load += new System.EventHandler(this.Gateway_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCmdDownload;
        private System.Windows.Forms.Button btnLoadConfig;
        private System.Windows.Forms.TreeView tvNodeList;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel pnlMain;
    }
}