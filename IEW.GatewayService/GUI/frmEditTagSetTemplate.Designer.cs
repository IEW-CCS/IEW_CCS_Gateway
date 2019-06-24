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
            this.label2 = new System.Windows.Forms.Label();
            this.lvCalcTagList = new System.Windows.Forms.ListView();
            this.btnTemplateRemoveTag = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTemplateAddTag = new System.Windows.Forms.Button();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.txtTagSetDescription = new System.Windows.Forms.TextBox();
            this.txtTagSetName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTemplateCancel = new System.Windows.Forms.Button();
            this.btnTemplateSave = new System.Windows.Forms.Button();
            this.btnTemplateRemoveCalcTag = new System.Windows.Forms.Button();
            this.btnTemplateAddCalcTag = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lvCalcTagList);
            this.groupBox1.Controls.Add(this.btnTemplateRemoveTag);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnTemplateAddTag);
            this.groupBox1.Controls.Add(this.lvTagList);
            this.groupBox1.Controls.Add(this.txtTagSetDescription);
            this.groupBox1.Controls.Add(this.txtTagSetName);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(739, 499);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tag Set Deail Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 303);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Calculation Tag List";
            // 
            // lvCalcTagList
            // 
            this.lvCalcTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCalcTagList.FullRowSelect = true;
            this.lvCalcTagList.GridLines = true;
            this.lvCalcTagList.Location = new System.Drawing.Point(14, 328);
            this.lvCalcTagList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvCalcTagList.MultiSelect = false;
            this.lvCalcTagList.Name = "lvCalcTagList";
            this.lvCalcTagList.Size = new System.Drawing.Size(715, 157);
            this.lvCalcTagList.TabIndex = 8;
            this.lvCalcTagList.UseCompatibleStateImageBehavior = false;
            this.lvCalcTagList.View = System.Windows.Forms.View.Details;
            this.lvCalcTagList.DoubleClick += new System.EventHandler(this.lvCalcTagList_DoubleClick);
            // 
            // btnTemplateRemoveTag
            // 
            this.btnTemplateRemoveTag.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnTemplateRemoveTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTemplateRemoveTag.FlatAppearance.BorderSize = 0;
            this.btnTemplateRemoveTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateRemoveTag.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTemplateRemoveTag.Location = new System.Drawing.Point(705, 296);
            this.btnTemplateRemoveTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTemplateRemoveTag.Name = "btnTemplateRemoveTag";
            this.btnTemplateRemoveTag.Size = new System.Drawing.Size(24, 24);
            this.btnTemplateRemoveTag.TabIndex = 11;
            this.btnTemplateRemoveTag.UseVisualStyleBackColor = true;
            this.btnTemplateRemoveTag.Click += new System.EventHandler(this.btnTemplateRemoveTag_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 109);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Normal Tag List";
            // 
            // btnTemplateAddTag
            // 
            this.btnTemplateAddTag.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnTemplateAddTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTemplateAddTag.FlatAppearance.BorderSize = 0;
            this.btnTemplateAddTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateAddTag.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTemplateAddTag.Location = new System.Drawing.Point(680, 296);
            this.btnTemplateAddTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTemplateAddTag.Name = "btnTemplateAddTag";
            this.btnTemplateAddTag.Size = new System.Drawing.Size(24, 24);
            this.btnTemplateAddTag.TabIndex = 10;
            this.btnTemplateAddTag.UseVisualStyleBackColor = true;
            this.btnTemplateAddTag.Click += new System.EventHandler(this.btnTemplateAddTag_Click);
            // 
            // lvTagList
            // 
            this.lvTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.GridLines = true;
            this.lvTagList.Location = new System.Drawing.Point(14, 134);
            this.lvTagList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvTagList.MultiSelect = false;
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(715, 158);
            this.lvTagList.TabIndex = 6;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            this.lvTagList.DoubleClick += new System.EventHandler(this.lvTagList_DoubleClick);
            // 
            // txtTagSetDescription
            // 
            this.txtTagSetDescription.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagSetDescription.Location = new System.Drawing.Point(140, 62);
            this.txtTagSetDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTagSetDescription.Multiline = true;
            this.txtTagSetDescription.Name = "txtTagSetDescription";
            this.txtTagSetDescription.Size = new System.Drawing.Size(589, 49);
            this.txtTagSetDescription.TabIndex = 5;
            // 
            // txtTagSetName
            // 
            this.txtTagSetName.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagSetName.Location = new System.Drawing.Point(140, 32);
            this.txtTagSetName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTagSetName.Name = "txtTagSetName";
            this.txtTagSetName.Size = new System.Drawing.Size(125, 23);
            this.txtTagSetName.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 64);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tag Set Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 34);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "Tag Set Name: ";
            // 
            // btnTemplateCancel
            // 
            this.btnTemplateCancel.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemplateCancel.Location = new System.Drawing.Point(379, 509);
            this.btnTemplateCancel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnTemplateCancel.Name = "btnTemplateCancel";
            this.btnTemplateCancel.Size = new System.Drawing.Size(79, 36);
            this.btnTemplateCancel.TabIndex = 32;
            this.btnTemplateCancel.Text = "Cancel";
            this.btnTemplateCancel.UseVisualStyleBackColor = true;
            this.btnTemplateCancel.Click += new System.EventHandler(this.btnTemplateCancel_Click);
            // 
            // btnTemplateSave
            // 
            this.btnTemplateSave.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTemplateSave.Location = new System.Drawing.Point(280, 509);
            this.btnTemplateSave.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnTemplateSave.Name = "btnTemplateSave";
            this.btnTemplateSave.Size = new System.Drawing.Size(79, 36);
            this.btnTemplateSave.TabIndex = 31;
            this.btnTemplateSave.Text = "Save";
            this.btnTemplateSave.UseVisualStyleBackColor = true;
            this.btnTemplateSave.Click += new System.EventHandler(this.btnTemplateSave_Click);
            // 
            // btnTemplateRemoveCalcTag
            // 
            this.btnTemplateRemoveCalcTag.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnTemplateRemoveCalcTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTemplateRemoveCalcTag.FlatAppearance.BorderSize = 0;
            this.btnTemplateRemoveCalcTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateRemoveCalcTag.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTemplateRemoveCalcTag.Location = new System.Drawing.Point(711, 509);
            this.btnTemplateRemoveCalcTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTemplateRemoveCalcTag.Name = "btnTemplateRemoveCalcTag";
            this.btnTemplateRemoveCalcTag.Size = new System.Drawing.Size(24, 24);
            this.btnTemplateRemoveCalcTag.TabIndex = 34;
            this.btnTemplateRemoveCalcTag.UseVisualStyleBackColor = true;
            this.btnTemplateRemoveCalcTag.Click += new System.EventHandler(this.btnTemplateRemoveCalcTag_Click);
            // 
            // btnTemplateAddCalcTag
            // 
            this.btnTemplateAddCalcTag.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnTemplateAddCalcTag.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnTemplateAddCalcTag.FlatAppearance.BorderSize = 0;
            this.btnTemplateAddCalcTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTemplateAddCalcTag.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnTemplateAddCalcTag.Location = new System.Drawing.Point(686, 509);
            this.btnTemplateAddCalcTag.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTemplateAddCalcTag.Name = "btnTemplateAddCalcTag";
            this.btnTemplateAddCalcTag.Size = new System.Drawing.Size(24, 24);
            this.btnTemplateAddCalcTag.TabIndex = 33;
            this.btnTemplateAddCalcTag.UseVisualStyleBackColor = true;
            this.btnTemplateAddCalcTag.Click += new System.EventHandler(this.btnTemplateAddCalcTag_Click);
            // 
            // frmEditTagSetTemplate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(746, 556);
            this.Controls.Add(this.btnTemplateRemoveCalcTag);
            this.Controls.Add(this.btnTemplateAddCalcTag);
            this.Controls.Add(this.btnTemplateCancel);
            this.Controls.Add(this.btnTemplateSave);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmEditTagSetTemplate";
            this.Text = "Edit Tag Set Template";
            this.Load += new System.EventHandler(this.frmEditTagSetTemplate_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTemplateRemoveTag;
        private System.Windows.Forms.Button btnTemplateAddTag;
        private System.Windows.Forms.Button btnTemplateCancel;
        private System.Windows.Forms.Button btnTemplateSave;
        private System.Windows.Forms.TextBox txtTagSetDescription;
        private System.Windows.Forms.TextBox txtTagSetName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvCalcTagList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.Button btnTemplateRemoveCalcTag;
        private System.Windows.Forms.Button btnTemplateAddCalcTag;
    }
}