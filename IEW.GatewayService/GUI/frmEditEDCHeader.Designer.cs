namespace IEW.GatewayService.GUI
{
    partial class frmEditEDCHeader
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtEDCHeaderSetName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.gbAddHeaderItem = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditItem = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnTagCancel = new System.Windows.Forms.Button();
            this.btnTagSave = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.gbAddHeaderItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "EDC Header Group Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "EDC Header Group Descrip.";
            // 
            // txtEDCHeaderSetName
            // 
            this.txtEDCHeaderSetName.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEDCHeaderSetName.Location = new System.Drawing.Point(339, 40);
            this.txtEDCHeaderSetName.Name = "txtEDCHeaderSetName";
            this.txtEDCHeaderSetName.Size = new System.Drawing.Size(310, 38);
            this.txtEDCHeaderSetName.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(339, 91);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(400, 88);
            this.txtDescription.TabIndex = 1;
            // 
            // gbAddHeaderItem
            // 
            this.gbAddHeaderItem.Controls.Add(this.btnEditItem);
            this.gbAddHeaderItem.Controls.Add(this.txtLength);
            this.gbAddHeaderItem.Controls.Add(this.label5);
            this.gbAddHeaderItem.Controls.Add(this.txtValue);
            this.gbAddHeaderItem.Controls.Add(this.txtName);
            this.gbAddHeaderItem.Controls.Add(this.label4);
            this.gbAddHeaderItem.Controls.Add(this.label3);
            this.gbAddHeaderItem.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAddHeaderItem.Location = new System.Drawing.Point(37, 196);
            this.gbAddHeaderItem.Name = "gbAddHeaderItem";
            this.gbAddHeaderItem.Size = new System.Drawing.Size(702, 194);
            this.gbAddHeaderItem.TabIndex = 4;
            this.gbAddHeaderItem.TabStop = false;
            this.gbAddHeaderItem.Text = "Add Header Item";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 31);
            this.label4.TabIndex = 1;
            this.label4.Text = "Value";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(115, 52);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(218, 38);
            this.txtName.TabIndex = 2;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(115, 112);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(218, 38);
            this.txtValue.TabIndex = 3;
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(452, 52);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(218, 38);
            this.txtLength.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Length";
            // 
            // btnEditItem
            // 
            this.btnEditItem.Location = new System.Drawing.Point(523, 112);
            this.btnEditItem.Name = "btnEditItem";
            this.btnEditItem.Size = new System.Drawing.Size(147, 61);
            this.btnEditItem.TabIndex = 5;
            this.btnEditItem.Text = "Edit Item";
            this.btnEditItem.UseVisualStyleBackColor = true;
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.BackgroundImage = global::IEW.GatewayService.Properties.Resources.minus2;
            this.btnRemoveItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRemoveItem.FlatAppearance.BorderSize = 0;
            this.btnRemoveItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveItem.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnRemoveItem.ImageIndex = 6;
            this.btnRemoveItem.Location = new System.Drawing.Point(680, 1092);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(48, 48);
            this.btnRemoveItem.TabIndex = 12;
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(37, 410);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(691, 659);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // btnTagCancel
            // 
            this.btnTagCancel.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagCancel.Location = new System.Drawing.Point(384, 1092);
            this.btnTagCancel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnTagCancel.Name = "btnTagCancel";
            this.btnTagCancel.Size = new System.Drawing.Size(158, 72);
            this.btnTagCancel.TabIndex = 32;
            this.btnTagCancel.Text = "Cancel";
            this.btnTagCancel.UseVisualStyleBackColor = true;
            // 
            // btnTagSave
            // 
            this.btnTagSave.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagSave.Location = new System.Drawing.Point(187, 1092);
            this.btnTagSave.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnTagSave.Name = "btnTagSave";
            this.btnTagSave.Size = new System.Drawing.Size(158, 72);
            this.btnTagSave.TabIndex = 31;
            this.btnTagSave.Text = "Save";
            this.btnTagSave.UseVisualStyleBackColor = true;
            // 
            // btnAddItem
            // 
            this.btnAddItem.BackgroundImage = global::IEW.GatewayService.Properties.Resources.plus;
            this.btnAddItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddItem.FlatAppearance.BorderSize = 0;
            this.btnAddItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddItem.Font = new System.Drawing.Font("新細明體", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnAddItem.Location = new System.Drawing.Point(626, 1092);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(48, 48);
            this.btnAddItem.TabIndex = 33;
            this.btnAddItem.UseVisualStyleBackColor = true;
            // 
            // frmEditEDCHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(760, 1188);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnTagCancel);
            this.Controls.Add(this.btnTagSave);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnRemoveItem);
            this.Controls.Add(this.gbAddHeaderItem);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtEDCHeaderSetName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmEditEDCHeader";
            this.Text = "frmEditEDCHeader";
            this.gbAddHeaderItem.ResumeLayout(false);
            this.gbAddHeaderItem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEDCHeaderSetName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.GroupBox gbAddHeaderItem;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditItem;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button btnTagCancel;
        private System.Windows.Forms.Button btnTagSave;
        private System.Windows.Forms.Button btnAddItem;
    }
}