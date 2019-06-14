namespace IEW.GatewayService.GUI
{
    partial class frmListEDCXml
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
            this.lvEDCXmlList = new System.Windows.Forms.ListView();
            this.btnRemoveXml = new System.Windows.Forms.Button();
            this.btnAddXml = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "EDC XML Config List";
            // 
            // lvEDCXmlList
            // 
            this.lvEDCXmlList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvEDCXmlList.FullRowSelect = true;
            this.lvEDCXmlList.GridLines = true;
            this.lvEDCXmlList.Location = new System.Drawing.Point(9, 35);
            this.lvEDCXmlList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvEDCXmlList.MultiSelect = false;
            this.lvEDCXmlList.Name = "lvEDCXmlList";
            this.lvEDCXmlList.Size = new System.Drawing.Size(722, 449);
            this.lvEDCXmlList.TabIndex = 1;
            this.lvEDCXmlList.UseCompatibleStateImageBehavior = false;
            this.lvEDCXmlList.View = System.Windows.Forms.View.Details;
            this.lvEDCXmlList.DoubleClick += new System.EventHandler(this.lvEDCXmlList_DoubleClick);
            // 
            // btnRemoveXml
            // 
            this.btnRemoveXml.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnRemoveXml.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveXml.FlatAppearance.BorderSize = 0;
            this.btnRemoveXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveXml.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveXml.ImageIndex = 6;
            this.btnRemoveXml.Location = new System.Drawing.Point(707, 488);
            this.btnRemoveXml.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRemoveXml.Name = "btnRemoveXml";
            this.btnRemoveXml.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveXml.TabIndex = 13;
            this.btnRemoveXml.UseVisualStyleBackColor = true;
            this.btnRemoveXml.Click += new System.EventHandler(this.btnRemoveXml_Click);
            // 
            // btnAddXml
            // 
            this.btnAddXml.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnAddXml.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddXml.FlatAppearance.BorderSize = 0;
            this.btnAddXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddXml.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddXml.ImageIndex = 5;
            this.btnAddXml.Location = new System.Drawing.Point(679, 488);
            this.btnAddXml.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddXml.Name = "btnAddXml";
            this.btnAddXml.Size = new System.Drawing.Size(24, 24);
            this.btnAddXml.TabIndex = 12;
            this.btnAddXml.UseVisualStyleBackColor = true;
            this.btnAddXml.Click += new System.EventHandler(this.btnAddXml_Click);
            // 
            // frmListEDCXml
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 556);
            this.Controls.Add(this.btnRemoveXml);
            this.Controls.Add(this.btnAddXml);
            this.Controls.Add(this.lvEDCXmlList);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmListEDCXml";
            this.Text = "frmListEDCXml";
            this.Load += new System.EventHandler(this.frmListEDCXml_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvEDCXmlList;
        private System.Windows.Forms.Button btnRemoveXml;
        private System.Windows.Forms.Button btnAddXml;
    }
}