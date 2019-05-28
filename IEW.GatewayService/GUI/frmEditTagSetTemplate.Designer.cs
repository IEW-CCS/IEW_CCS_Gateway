namespace IEW.GatewayService.GUI
{
    partial class frmEditTagSetTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditTagSetTemplate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTagSetDescription = new System.Windows.Forms.TextBox();
            this.txtTagSetName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTemplateRemoveTag = new System.Windows.Forms.Button();
            this.btnTemplateAddTag = new System.Windows.Forms.Button();
            this.btnTemplateCancel = new System.Windows.Forms.Button();
            this.btnTemplateSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTagSetDescription);
            this.groupBox1.Controls.Add(this.txtTagSetName);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1361, 878);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tag Set Deail Information";
            // 
            // txtTagSetDescription
            // 
            this.txtTagSetDescription.Location = new System.Drawing.Point(351, 128);
            this.txtTagSetDescription.Multiline = true;
            this.txtTagSetDescription.Name = "txtTagSetDescription";
            this.txtTagSetDescription.Size = new System.Drawing.Size(986, 94);
            this.txtTagSetDescription.TabIndex = 5;
            // 
            // txtTagSetName
            // 
            this.txtTagSetName.Location = new System.Drawing.Point(351, 68);
            this.txtTagSetName.Name = "txtTagSetName";
            this.txtTagSetName.Size = new System.Drawing.Size(246, 44);
            this.txtTagSetName.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvTagList);
            this.groupBox2.Location = new System.Drawing.Point(0, 232);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1360, 648);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tag List";
            // 
            // lvTagList
            // 
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.Location = new System.Drawing.Point(22, 54);
            this.lvTagList.MultiSelect = false;
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(1315, 578);
            this.lvTagList.TabIndex = 0;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            this.lvTagList.DoubleClick += new System.EventHandler(this.lvTagList_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(28, 128);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(257, 37);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tag Set Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(28, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(202, 37);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tag Set Name: ";
            // 
            // btnTemplateRemoveTag
            // 
            this.btnTemplateRemoveTag.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnTemplateRemoveTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTemplateRemoveTag.FlatAppearance.BorderSize = 0;
            this.btnTemplateRemoveTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateRemoveTag.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTemplateRemoveTag.Location = new System.Drawing.Point(1301, 927);
            this.btnTemplateRemoveTag.Name = "btnTemplateRemoveTag";
            this.btnTemplateRemoveTag.Size = new System.Drawing.Size(48, 48);
            this.btnTemplateRemoveTag.TabIndex = 11;
            this.btnTemplateRemoveTag.UseVisualStyleBackColor = true;
            this.btnTemplateRemoveTag.Click += new System.EventHandler(this.btnTemplateRemoveTag_Click);
            // 
            // btnTemplateAddTag
            // 
            this.btnTemplateAddTag.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnTemplateAddTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTemplateAddTag.FlatAppearance.BorderSize = 0;
            this.btnTemplateAddTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateAddTag.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTemplateAddTag.Location = new System.Drawing.Point(1250, 927);
            this.btnTemplateAddTag.Name = "btnTemplateAddTag";
            this.btnTemplateAddTag.Size = new System.Drawing.Size(48, 48);
            this.btnTemplateAddTag.TabIndex = 10;
            this.btnTemplateAddTag.UseVisualStyleBackColor = true;
            this.btnTemplateAddTag.Click += new System.EventHandler(this.btnTemplateAddTag_Click);
            // 
            // btnTemplateCancel
            // 
            this.btnTemplateCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemplateCancel.Location = new System.Drawing.Point(690, 927);
            this.btnTemplateCancel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnTemplateCancel.Name = "btnTemplateCancel";
            this.btnTemplateCancel.Size = new System.Drawing.Size(158, 72);
            this.btnTemplateCancel.TabIndex = 32;
            this.btnTemplateCancel.Text = "Cancel";
            this.btnTemplateCancel.UseVisualStyleBackColor = true;
            this.btnTemplateCancel.Click += new System.EventHandler(this.btnTemplateCancel_Click);
            // 
            // btnTemplateSave
            // 
            this.btnTemplateSave.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemplateSave.Location = new System.Drawing.Point(493, 927);
            this.btnTemplateSave.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnTemplateSave.Name = "btnTemplateSave";
            this.btnTemplateSave.Size = new System.Drawing.Size(158, 72);
            this.btnTemplateSave.TabIndex = 31;
            this.btnTemplateSave.Text = "Save";
            this.btnTemplateSave.UseVisualStyleBackColor = true;
            this.btnTemplateSave.Click += new System.EventHandler(this.btnTemplateSave_Click);
            // 
            // frmEditTagSetTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1380, 1038);
            this.Controls.Add(this.btnTemplateCancel);
            this.Controls.Add(this.btnTemplateSave);
            this.Controls.Add(this.btnTemplateRemoveTag);
            this.Controls.Add(this.btnTemplateAddTag);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEditTagSetTemplate";
            this.Text = "Edit Tag Set Template";
            this.Load += new System.EventHandler(this.frmEditTagSetTemplate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTemplateRemoveTag;
        private System.Windows.Forms.Button btnTemplateAddTag;
        private System.Windows.Forms.Button btnTemplateCancel;
        private System.Windows.Forms.Button btnTemplateSave;
        private System.Windows.Forms.TextBox txtTagSetDescription;
        private System.Windows.Forms.TextBox txtTagSetName;
    }
}