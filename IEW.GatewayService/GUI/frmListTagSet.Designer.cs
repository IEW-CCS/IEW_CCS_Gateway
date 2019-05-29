namespace IEW.GatewayService.GUI
{
    partial class frmListTagSet
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
            this.btnRemoveTagSetTemplate = new System.Windows.Forms.Button();
            this.btnAddTagSetTemplate = new System.Windows.Forms.Button();
            this.lvTagSetList = new System.Windows.Forms.ListView();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnRemoveTagSetTemplate
            // 
            this.btnRemoveTagSetTemplate.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnRemoveTagSetTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveTagSetTemplate.FlatAppearance.BorderSize = 0;
            this.btnRemoveTagSetTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveTagSetTemplate.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveTagSetTemplate.ImageIndex = 6;
            this.btnRemoveTagSetTemplate.Location = new System.Drawing.Point(1375, 851);
            this.btnRemoveTagSetTemplate.Name = "btnRemoveTagSetTemplate";
            this.btnRemoveTagSetTemplate.Size = new System.Drawing.Size(48, 48);
            this.btnRemoveTagSetTemplate.TabIndex = 11;
            this.btnRemoveTagSetTemplate.UseVisualStyleBackColor = true;
            this.btnRemoveTagSetTemplate.Click += new System.EventHandler(this.btnRemoveTagSetTemplate_Click);
            // 
            // btnAddTagSetTemplate
            // 
            this.btnAddTagSetTemplate.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnAddTagSetTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddTagSetTemplate.FlatAppearance.BorderSize = 0;
            this.btnAddTagSetTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTagSetTemplate.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddTagSetTemplate.ImageIndex = 5;
            this.btnAddTagSetTemplate.Location = new System.Drawing.Point(1319, 851);
            this.btnAddTagSetTemplate.Name = "btnAddTagSetTemplate";
            this.btnAddTagSetTemplate.Size = new System.Drawing.Size(48, 48);
            this.btnAddTagSetTemplate.TabIndex = 10;
            this.btnAddTagSetTemplate.UseVisualStyleBackColor = true;
            this.btnAddTagSetTemplate.Click += new System.EventHandler(this.btnAddTagSetTemplate_Click);
            // 
            // lvTagSetList
            // 
            this.lvTagSetList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagSetList.FullRowSelect = true;
            this.lvTagSetList.Location = new System.Drawing.Point(30, 85);
            this.lvTagSetList.MultiSelect = false;
            this.lvTagSetList.Name = "lvTagSetList";
            this.lvTagSetList.Size = new System.Drawing.Size(1393, 743);
            this.lvTagSetList.TabIndex = 9;
            this.lvTagSetList.UseCompatibleStateImageBehavior = false;
            this.lvTagSetList.View = System.Windows.Forms.View.Details;
            this.lvTagSetList.DoubleClick += new System.EventHandler(this.lvTagSetList_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(24, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 31);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tag Set Template List";
            // 
            // frmListTagSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1448, 932);
            this.Controls.Add(this.btnRemoveTagSetTemplate);
            this.Controls.Add(this.btnAddTagSetTemplate);
            this.Controls.Add(this.lvTagSetList);
            this.Controls.Add(this.label6);
            this.Name = "frmListTagSet";
            this.Text = "frmListTagSet";
            this.Load += new System.EventHandler(this.frmListTagSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveTagSetTemplate;
        private System.Windows.Forms.Button btnAddTagSetTemplate;
        private System.Windows.Forms.ListView lvTagSetList;
        private System.Windows.Forms.Label label6;
    }
}