namespace IEW.GatewayService.GUI
{
    partial class frmListDBConfig
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
            this.btnRemoveDBConfig = new System.Windows.Forms.Button();
            this.btnAddDBConfig = new System.Windows.Forms.Button();
            this.lvDBConfigList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemoveDBConfig
            // 
            this.btnRemoveDBConfig.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnRemoveDBConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveDBConfig.FlatAppearance.BorderSize = 0;
            this.btnRemoveDBConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveDBConfig.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveDBConfig.ImageIndex = 6;
            this.btnRemoveDBConfig.Location = new System.Drawing.Point(709, 493);
            this.btnRemoveDBConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveDBConfig.Name = "btnRemoveDBConfig";
            this.btnRemoveDBConfig.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveDBConfig.TabIndex = 17;
            this.btnRemoveDBConfig.UseVisualStyleBackColor = true;
            this.btnRemoveDBConfig.Click += new System.EventHandler(this.btnRemoveDBConfig_Click);
            // 
            // btnAddDBConfig
            // 
            this.btnAddDBConfig.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnAddDBConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddDBConfig.FlatAppearance.BorderSize = 0;
            this.btnAddDBConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDBConfig.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddDBConfig.ImageIndex = 5;
            this.btnAddDBConfig.Location = new System.Drawing.Point(681, 493);
            this.btnAddDBConfig.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddDBConfig.Name = "btnAddDBConfig";
            this.btnAddDBConfig.Size = new System.Drawing.Size(24, 24);
            this.btnAddDBConfig.TabIndex = 16;
            this.btnAddDBConfig.UseVisualStyleBackColor = true;
            this.btnAddDBConfig.Click += new System.EventHandler(this.btnAddDBConfig_Click);
            // 
            // lvDBConfigList
            // 
            this.lvDBConfigList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvDBConfigList.FullRowSelect = true;
            this.lvDBConfigList.GridLines = true;
            this.lvDBConfigList.Location = new System.Drawing.Point(11, 40);
            this.lvDBConfigList.Margin = new System.Windows.Forms.Padding(2);
            this.lvDBConfigList.MultiSelect = false;
            this.lvDBConfigList.Name = "lvDBConfigList";
            this.lvDBConfigList.Size = new System.Drawing.Size(722, 449);
            this.lvDBConfigList.TabIndex = 15;
            this.lvDBConfigList.UseCompatibleStateImageBehavior = false;
            this.lvDBConfigList.View = System.Windows.Forms.View.Details;
            this.lvDBConfigList.DoubleClick += new System.EventHandler(this.lvDBConfigList_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Database Config List";
            // 
            // frmListDBConfig
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 556);
            this.Controls.Add(this.btnRemoveDBConfig);
            this.Controls.Add(this.btnAddDBConfig);
            this.Controls.Add(this.lvDBConfigList);
            this.Controls.Add(this.label1);
            this.Name = "frmListDBConfig";
            this.Text = "frmListDBConfig";
            this.Load += new System.EventHandler(this.frmListDBConfig_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveDBConfig;
        private System.Windows.Forms.Button btnAddDBConfig;
        private System.Windows.Forms.ListView lvDBConfigList;
        private System.Windows.Forms.Label label1;
    }
}