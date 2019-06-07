namespace IEW.GatewayService.GUI
{
    partial class frmEditCalcTag
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
            this.lvTagList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlCalcExpression = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCalcTagCancel = new System.Windows.Forms.Button();
            this.btnCalcTagSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCalcTagName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvTagList
            // 
            this.lvTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.GridLines = true;
            this.lvTagList.Location = new System.Drawing.Point(39, 74);
            this.lvTagList.MultiSelect = false;
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(423, 813);
            this.lvTagList.TabIndex = 0;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            this.lvTagList.SelectedIndexChanged += new System.EventHandler(this.lvTagList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Normal Tag List";
            // 
            // pnlCalcExpression
            // 
            this.pnlCalcExpression.Location = new System.Drawing.Point(653, 134);
            this.pnlCalcExpression.Name = "pnlCalcExpression";
            this.pnlCalcExpression.Size = new System.Drawing.Size(646, 613);
            this.pnlCalcExpression.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(645, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 31);
            this.label2.TabIndex = 3;
            this.label2.Text = "Calculation Expression";
            // 
            // btnAssign
            // 
            this.btnAssign.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnAssign.BackgroundImage = global::IEW.GatewayService.Properties.Resources.arrow_right;
            this.btnAssign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAssign.FlatAppearance.BorderSize = 0;
            this.btnAssign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAssign.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(521, 338);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 75);
            this.btnAssign.TabIndex = 4;
            this.btnAssign.UseVisualStyleBackColor = false;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(39, 905);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(129, 57);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCalcTagCancel
            // 
            this.btnCalcTagCancel.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcTagCancel.Location = new System.Drawing.Point(671, 955);
            this.btnCalcTagCancel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnCalcTagCancel.Name = "btnCalcTagCancel";
            this.btnCalcTagCancel.Size = new System.Drawing.Size(158, 72);
            this.btnCalcTagCancel.TabIndex = 32;
            this.btnCalcTagCancel.Text = "Cancel";
            this.btnCalcTagCancel.UseVisualStyleBackColor = true;
            this.btnCalcTagCancel.Click += new System.EventHandler(this.btnCalcTagCancel_Click);
            // 
            // btnCalcTagSave
            // 
            this.btnCalcTagSave.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcTagSave.Location = new System.Drawing.Point(474, 955);
            this.btnCalcTagSave.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnCalcTagSave.Name = "btnCalcTagSave";
            this.btnCalcTagSave.Size = new System.Drawing.Size(158, 72);
            this.btnCalcTagSave.TabIndex = 31;
            this.btnCalcTagSave.Text = "Save";
            this.btnCalcTagSave.UseVisualStyleBackColor = true;
            this.btnCalcTagSave.Click += new System.EventHandler(this.btnCalcTagSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(653, 805);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(646, 82);
            this.txtDescription.TabIndex = 35;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(646, 763);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 31);
            this.label10.TabIndex = 34;
            this.label10.Text = "Description:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(645, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 31);
            this.label3.TabIndex = 36;
            this.label3.Text = "Calculation Tag Name:";
            // 
            // txtCalcTagName
            // 
            this.txtCalcTagName.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCalcTagName.Location = new System.Drawing.Point(967, 36);
            this.txtCalcTagName.Name = "txtCalcTagName";
            this.txtCalcTagName.Size = new System.Drawing.Size(332, 38);
            this.txtCalcTagName.TabIndex = 37;
            // 
            // frmEditCalcTag
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(192F, 192F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1342, 1066);
            this.Controls.Add(this.txtCalcTagName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCalcTagCancel);
            this.Controls.Add(this.btnCalcTagSave);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlCalcExpression);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvTagList);
            this.Name = "frmEditCalcTag";
            this.Text = "frmEditCalcTag";
            this.Load += new System.EventHandler(this.frmEditCalcTag_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvTagList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCalcExpression;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCalcTagCancel;
        private System.Windows.Forms.Button btnCalcTagSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCalcTagName;
    }
}