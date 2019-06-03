namespace IEW.GatewayService.GUI
{
    partial class frmListEDCHeaderSet
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
            this.btnRemoveHeaderSet = new System.Windows.Forms.Button();
            this.btnAddHeaderSet = new System.Windows.Forms.Button();
            this.lvHeaderSetList = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemoveHeaderSet
            // 
            this.btnRemoveHeaderSet.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnRemoveHeaderSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveHeaderSet.FlatAppearance.BorderSize = 0;
            this.btnRemoveHeaderSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveHeaderSet.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveHeaderSet.ImageIndex = 6;
            this.btnRemoveHeaderSet.Location = new System.Drawing.Point(1325, 732);
            this.btnRemoveHeaderSet.Name = "btnRemoveHeaderSet";
            this.btnRemoveHeaderSet.Size = new System.Drawing.Size(48, 48);
            this.btnRemoveHeaderSet.TabIndex = 15;
            this.btnRemoveHeaderSet.UseVisualStyleBackColor = true;
            this.btnRemoveHeaderSet.Click += new System.EventHandler(this.btnRemoveHeaderSet_Click);
            // 
            // btnAddHeaderSet
            // 
            this.btnAddHeaderSet.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnAddHeaderSet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddHeaderSet.FlatAppearance.BorderSize = 0;
            this.btnAddHeaderSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddHeaderSet.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddHeaderSet.ImageIndex = 5;
            this.btnAddHeaderSet.Location = new System.Drawing.Point(1269, 732);
            this.btnAddHeaderSet.Name = "btnAddHeaderSet";
            this.btnAddHeaderSet.Size = new System.Drawing.Size(48, 48);
            this.btnAddHeaderSet.TabIndex = 14;
            this.btnAddHeaderSet.UseVisualStyleBackColor = true;
            this.btnAddHeaderSet.Click += new System.EventHandler(this.btnAddHeaderSet_Click);
            // 
            // lvHeaderSetList
            // 
            this.lvHeaderSetList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHeaderSetList.FullRowSelect = true;
            this.lvHeaderSetList.GridLines = true;
            this.lvHeaderSetList.Location = new System.Drawing.Point(10, 69);
            this.lvHeaderSetList.MultiSelect = false;
            this.lvHeaderSetList.Name = "lvHeaderSetList";
            this.lvHeaderSetList.Size = new System.Drawing.Size(1363, 647);
            this.lvHeaderSetList.TabIndex = 13;
            this.lvHeaderSetList.UseCompatibleStateImageBehavior = false;
            this.lvHeaderSetList.View = System.Windows.Forms.View.Details;
            this.lvHeaderSetList.DoubleClick += new System.EventHandler(this.lvHeaderSetList_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "EDC Header Set List";
            // 
            // frmListEDCHeaderSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1406, 808);
            this.Controls.Add(this.btnRemoveHeaderSet);
            this.Controls.Add(this.btnAddHeaderSet);
            this.Controls.Add(this.lvHeaderSetList);
            this.Controls.Add(this.label6);
            this.Name = "frmListEDCHeaderSet";
            this.Text = "frmListEDCHeaderSet";
            this.Load += new System.EventHandler(this.frmListEDCHeaderSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveHeaderSet;
        private System.Windows.Forms.Button btnAddHeaderSet;
        private System.Windows.Forms.ListView lvHeaderSetList;
        private System.Windows.Forms.Label label6;
    }
}