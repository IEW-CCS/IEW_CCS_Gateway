namespace IEW.GatewayService.GUI
{
    partial class frmListGateway
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
            this.lvGatewayList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRemoveGateway = new System.Windows.Forms.Button();
            this.btnAddGateway = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvGatewayList
            // 
            this.lvGatewayList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvGatewayList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvGatewayList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvGatewayList.FullRowSelect = true;
            this.lvGatewayList.GridLines = true;
            this.lvGatewayList.Location = new System.Drawing.Point(12, 36);
            this.lvGatewayList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvGatewayList.Name = "lvGatewayList";
            this.lvGatewayList.Size = new System.Drawing.Size(718, 448);
            this.lvGatewayList.TabIndex = 7;
            this.lvGatewayList.UseCompatibleStateImageBehavior = false;
            this.lvGatewayList.View = System.Windows.Forms.View.Details;
            this.lvGatewayList.DoubleClick += new System.EventHandler(this.lvGatewayList_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Gateway List";
            // 
            // btnRemoveGateway
            // 
            this.btnRemoveGateway.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnRemoveGateway.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveGateway.FlatAppearance.BorderSize = 0;
            this.btnRemoveGateway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveGateway.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveGateway.ImageIndex = 6;
            this.btnRemoveGateway.Location = new System.Drawing.Point(705, 488);
            this.btnRemoveGateway.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveGateway.Name = "btnRemoveGateway";
            this.btnRemoveGateway.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveGateway.TabIndex = 9;
            this.btnRemoveGateway.UseVisualStyleBackColor = true;
            this.btnRemoveGateway.Click += new System.EventHandler(this.btnRemoveGateway_Click);
            // 
            // btnAddGateway
            // 
            this.btnAddGateway.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnAddGateway.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddGateway.FlatAppearance.BorderSize = 0;
            this.btnAddGateway.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGateway.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddGateway.ImageIndex = 5;
            this.btnAddGateway.Location = new System.Drawing.Point(677, 488);
            this.btnAddGateway.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddGateway.Name = "btnAddGateway";
            this.btnAddGateway.Size = new System.Drawing.Size(24, 24);
            this.btnAddGateway.TabIndex = 8;
            this.btnAddGateway.UseVisualStyleBackColor = true;
            this.btnAddGateway.Click += new System.EventHandler(this.btnAddGateway_Click);
            // 
            // frmListGateway
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(733, 556);
            this.Controls.Add(this.lvGatewayList);
            this.Controls.Add(this.btnRemoveGateway);
            this.Controls.Add(this.btnAddGateway);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmListGateway";
            this.Text = "frmListGateway";
            this.Load += new System.EventHandler(this.frmListGateway_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvGatewayList;
        private System.Windows.Forms.Button btnRemoveGateway;
        private System.Windows.Forms.Button btnAddGateway;
        private System.Windows.Forms.Label label1;
    }
}