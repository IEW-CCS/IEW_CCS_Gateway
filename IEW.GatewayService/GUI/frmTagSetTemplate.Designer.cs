namespace IEW.GatewayService.GUI
{
    partial class frmTagSetTemplate
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
            this.cmbTagSet = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnTempCancel = new System.Windows.Forms.Button();
            this.btnTempLoad = new System.Windows.Forms.Button();
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
            this.cmbTagSet.Location = new System.Drawing.Point(178, 46);
            this.cmbTagSet.Name = "cmbTagSet";
            this.cmbTagSet.Size = new System.Drawing.Size(261, 45);
            this.cmbTagSet.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.Location = new System.Drawing.Point(44, 136);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1200, 517);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnTempCancel
            // 
            this.btnTempCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTempCancel.Location = new System.Drawing.Point(657, 695);
            this.btnTempCancel.Name = "btnTempCancel";
            this.btnTempCancel.Size = new System.Drawing.Size(158, 45);
            this.btnTempCancel.TabIndex = 18;
            this.btnTempCancel.Text = "Cancel";
            this.btnTempCancel.UseVisualStyleBackColor = true;
            // 
            // btnTempLoad
            // 
            this.btnTempLoad.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTempLoad.Location = new System.Drawing.Point(461, 695);
            this.btnTempLoad.Name = "btnTempLoad";
            this.btnTempLoad.Size = new System.Drawing.Size(158, 45);
            this.btnTempLoad.TabIndex = 17;
            this.btnTempLoad.Text = "Load";
            this.btnTempLoad.UseVisualStyleBackColor = true;
            // 
            // frmTagSetTemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 770);
            this.Controls.Add(this.btnTempCancel);
            this.Controls.Add(this.btnTempLoad);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.cmbTagSet);
            this.Controls.Add(this.label1);
            this.Name = "frmTagSetTemplate";
            this.Text = "Load Tag Set Template";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTagSet;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnTempCancel;
        private System.Windows.Forms.Button btnTempLoad;
    }
}