namespace IEW.GatewayService.GUI
{
    partial class frmLoadTagSetTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadTagSetTemplate));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTagSet = new System.Windows.Forms.ComboBox();
            this.lvTagList = new System.Windows.Forms.ListView();
            this.btnTempCancel = new System.Windows.Forms.Button();
            this.btnTempLoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag Set: ";
            // 
            // cmbTagSet
            // 
            this.cmbTagSet.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagSet.FormattingEnabled = true;
            this.cmbTagSet.Location = new System.Drawing.Point(212, 46);
            this.cmbTagSet.Name = "cmbTagSet";
            this.cmbTagSet.Size = new System.Drawing.Size(261, 45);
            this.cmbTagSet.TabIndex = 1;
            this.cmbTagSet.SelectedIndexChanged += new System.EventHandler(this.cmbTagSet_SelectedIndexChanged);
            // 
            // lvTagList
            // 
            this.lvTagList.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.Location = new System.Drawing.Point(44, 268);
            this.lvTagList.MultiSelect = false;
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(1200, 469);
            this.lvTagList.TabIndex = 2;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            // 
            // btnTempCancel
            // 
            this.btnTempCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTempCancel.Location = new System.Drawing.Point(657, 779);
            this.btnTempCancel.Name = "btnTempCancel";
            this.btnTempCancel.Size = new System.Drawing.Size(158, 67);
            this.btnTempCancel.TabIndex = 18;
            this.btnTempCancel.Text = "Cancel";
            this.btnTempCancel.UseVisualStyleBackColor = true;
            this.btnTempCancel.Click += new System.EventHandler(this.btnTempCancel_Click);
            // 
            // btnTempLoad
            // 
            this.btnTempLoad.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTempLoad.Location = new System.Drawing.Point(461, 779);
            this.btnTempLoad.Name = "btnTempLoad";
            this.btnTempLoad.Size = new System.Drawing.Size(158, 67);
            this.btnTempLoad.TabIndex = 17;
            this.btnTempLoad.Text = "Load";
            this.btnTempLoad.UseVisualStyleBackColor = true;
            this.btnTempLoad.Click += new System.EventHandler(this.btnTempLoad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(37, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 37);
            this.label2.TabIndex = 19;
            this.label2.Text = "Description: ";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(212, 110);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(1021, 86);
            this.txtDescription.TabIndex = 20;
            // 
            // frmLoadTagSetTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1288, 886);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTempCancel);
            this.Controls.Add(this.btnTempLoad);
            this.Controls.Add(this.lvTagList);
            this.Controls.Add(this.cmbTagSet);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLoadTagSetTemplate";
            this.Text = "Load Tag Set Template";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTagSet;
        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.Button btnTempCancel;
        private System.Windows.Forms.Button btnTempLoad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
    }
}