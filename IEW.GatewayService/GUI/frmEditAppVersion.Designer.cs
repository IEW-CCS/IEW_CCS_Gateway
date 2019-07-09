namespace IEW.GatewayService.GUI
{
    partial class frmEditAppVersion
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
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtAppType = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvVersionList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(386, 509);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(79, 36);
            this.btnRemove.TabIndex = 40;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(287, 509);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(79, 36);
            this.btnUpload.TabIndex = 39;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // txtAppType
            // 
            this.txtAppType.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAppType.Location = new System.Drawing.Point(107, 20);
            this.txtAppType.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtAppType.Name = "txtAppType";
            this.txtAppType.Size = new System.Drawing.Size(135, 23);
            this.txtAppType.TabIndex = 42;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Application Type";
            // 
            // lvVersionList
            // 
            this.lvVersionList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvVersionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvVersionList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvVersionList.FullRowSelect = true;
            this.lvVersionList.GridLines = true;
            this.lvVersionList.Location = new System.Drawing.Point(8, 58);
            this.lvVersionList.Margin = new System.Windows.Forms.Padding(2);
            this.lvVersionList.MultiSelect = false;
            this.lvVersionList.Name = "lvVersionList";
            this.lvVersionList.Size = new System.Drawing.Size(724, 434);
            this.lvVersionList.TabIndex = 43;
            this.lvVersionList.UseCompatibleStateImageBehavior = false;
            this.lvVersionList.View = System.Windows.Forms.View.Details;
            // 
            // frmEditAppVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 556);
            this.Controls.Add(this.lvVersionList);
            this.Controls.Add(this.txtAppType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpload);
            this.Name = "frmEditAppVersion";
            this.Text = "frmEditAppVersion";
            this.Load += new System.EventHandler(this.frmEditAppVersion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtAppType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvVersionList;
    }
}