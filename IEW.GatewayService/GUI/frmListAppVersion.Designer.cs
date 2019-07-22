namespace IEW.GatewayService.GUI
{
    partial class frmListAppVersion
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
            this.lvVersionList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvVersionList
            // 
            this.lvVersionList.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvVersionList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvVersionList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvVersionList.FullRowSelect = true;
            this.lvVersionList.GridLines = true;
            this.lvVersionList.Location = new System.Drawing.Point(8, 39);
            this.lvVersionList.Margin = new System.Windows.Forms.Padding(2);
            this.lvVersionList.Name = "lvVersionList";
            this.lvVersionList.Size = new System.Drawing.Size(724, 506);
            this.lvVersionList.TabIndex = 10;
            this.lvVersionList.UseCompatibleStateImageBehavior = false;
            this.lvVersionList.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Application Version Management";
            // 
            // frmListAppVersion
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(740, 556);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvVersionList);
            this.Name = "frmListAppVersion";
            this.Text = "frmListAppVersion";
            this.Load += new System.EventHandler(this.frmListGatewayVersion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvVersionList;
        private System.Windows.Forms.Label label1;
    }
}