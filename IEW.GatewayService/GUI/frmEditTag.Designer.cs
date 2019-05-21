namespace IEW.GatewayService.GUI
{
    partial class frmEditTag
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
            this.txtTagName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWordBit = new System.Windows.Forms.ComboBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStartBit = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbLinearScale = new System.Windows.Forms.GroupBox();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTagCancel = new System.Windows.Forms.Button();
            this.btnTagSave = new System.Windows.Forms.Button();
            this.gbLinearScale.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag Name(X):";
            // 
            // txtTagName
            // 
            this.txtTagName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTagName.Location = new System.Drawing.Point(142, 21);
            this.txtTagName.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtTagName.Name = "txtTagName";
            this.txtTagName.Size = new System.Drawing.Size(125, 26);
            this.txtTagName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Word/Bit:";
            // 
            // txtDataType
            // 
            this.txtDataType.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataType.Location = new System.Drawing.Point(142, 90);
            this.txtDataType.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtDataType.Name = "txtDataType";
            this.txtDataType.Size = new System.Drawing.Size(125, 26);
            this.txtDataType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(17, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data Type:";
            // 
            // cmbWordBit
            // 
            this.cmbWordBit.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWordBit.FormattingEnabled = true;
            this.cmbWordBit.Location = new System.Drawing.Point(142, 54);
            this.cmbWordBit.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.cmbWordBit.Name = "cmbWordBit";
            this.cmbWordBit.Size = new System.Drawing.Size(125, 28);
            this.cmbWordBit.TabIndex = 6;
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(142, 126);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(125, 26);
            this.txtAddress.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 126);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Address:";
            // 
            // txtStartBit
            // 
            this.txtStartBit.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartBit.Location = new System.Drawing.Point(142, 161);
            this.txtStartBit.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtStartBit.Name = "txtStartBit";
            this.txtStartBit.Size = new System.Drawing.Size(125, 26);
            this.txtStartBit.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Start Bit:";
            // 
            // txtLength
            // 
            this.txtLength.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLength.Location = new System.Drawing.Point(142, 196);
            this.txtLength.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(125, 26);
            this.txtLength.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 196);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Length:";
            // 
            // gbLinearScale
            // 
            this.gbLinearScale.Controls.Add(this.txtOffset);
            this.gbLinearScale.Controls.Add(this.label9);
            this.gbLinearScale.Controls.Add(this.txtScale);
            this.gbLinearScale.Controls.Add(this.label8);
            this.gbLinearScale.Controls.Add(this.label7);
            this.gbLinearScale.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbLinearScale.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLinearScale.Location = new System.Drawing.Point(15, 233);
            this.gbLinearScale.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.gbLinearScale.Name = "gbLinearScale";
            this.gbLinearScale.Padding = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.gbLinearScale.Size = new System.Drawing.Size(324, 86);
            this.gbLinearScale.TabIndex = 13;
            this.gbLinearScale.TabStop = false;
            this.gbLinearScale.Text = "Linear Scale Setup";
            // 
            // txtOffset
            // 
            this.txtOffset.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOffset.Location = new System.Drawing.Point(225, 54);
            this.txtOffset.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.Size = new System.Drawing.Size(83, 26);
            this.txtOffset.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(164, 54);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Offset(B):";
            // 
            // txtScale
            // 
            this.txtScale.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScale.Location = new System.Drawing.Point(69, 54);
            this.txtScale.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(83, 26);
            this.txtScale.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(7, 54);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "Scale(A):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "Formula: AX + B";
            // 
            // btnTagCancel
            // 
            this.btnTagCancel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagCancel.Location = new System.Drawing.Point(186, 424);
            this.btnTagCancel.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnTagCancel.Name = "btnTagCancel";
            this.btnTagCancel.Size = new System.Drawing.Size(73, 36);
            this.btnTagCancel.TabIndex = 15;
            this.btnTagCancel.Text = "Cancel";
            this.btnTagCancel.UseVisualStyleBackColor = true;
            // 
            // btnTagSave
            // 
            this.btnTagSave.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTagSave.Location = new System.Drawing.Point(95, 424);
            this.btnTagSave.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.btnTagSave.Name = "btnTagSave";
            this.btnTagSave.Size = new System.Drawing.Size(73, 36);
            this.btnTagSave.TabIndex = 14;
            this.btnTagSave.Text = "Save";
            this.btnTagSave.UseVisualStyleBackColor = true;
            this.btnTagSave.Click += new System.EventHandler(this.btnTagSave_Click);
            // 
            // frmEditTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 508);
            this.Controls.Add(this.btnTagCancel);
            this.Controls.Add(this.btnTagSave);
            this.Controls.Add(this.gbLinearScale);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtStartBit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbWordBit);
            this.Controls.Add(this.txtDataType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTagName);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.Name = "frmEditTag";
            this.Text = "Add Tag";
            this.gbLinearScale.ResumeLayout(false);
            this.gbLinearScale.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTagName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbWordBit;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStartBit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbLinearScale;
        private System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnTagCancel;
        private System.Windows.Forms.Button btnTagSave;
    }
}