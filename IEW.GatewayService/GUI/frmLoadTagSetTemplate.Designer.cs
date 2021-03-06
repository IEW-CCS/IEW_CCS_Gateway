﻿namespace IEW.GatewayService.GUI
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
            this.label3 = new System.Windows.Forms.Label();
            this.lvCalcTagList = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tag Set: ";
            // 
            // cmbTagSet
            // 
            this.cmbTagSet.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTagSet.FormattingEnabled = true;
            this.cmbTagSet.Location = new System.Drawing.Point(96, 23);
            this.cmbTagSet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbTagSet.Name = "cmbTagSet";
            this.cmbTagSet.Size = new System.Drawing.Size(132, 24);
            this.cmbTagSet.TabIndex = 1;
            this.cmbTagSet.SelectedIndexChanged += new System.EventHandler(this.cmbTagSet_SelectedIndexChanged);
            // 
            // lvTagList
            // 
            this.lvTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTagList.FullRowSelect = true;
            this.lvTagList.GridLines = true;
            this.lvTagList.Location = new System.Drawing.Point(22, 122);
            this.lvTagList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvTagList.MultiSelect = false;
            this.lvTagList.Name = "lvTagList";
            this.lvTagList.Size = new System.Drawing.Size(586, 182);
            this.lvTagList.TabIndex = 2;
            this.lvTagList.UseCompatibleStateImageBehavior = false;
            this.lvTagList.View = System.Windows.Forms.View.Details;
            // 
            // btnTempCancel
            // 
            this.btnTempCancel.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTempCancel.Location = new System.Drawing.Point(308, 452);
            this.btnTempCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTempCancel.Name = "btnTempCancel";
            this.btnTempCancel.Size = new System.Drawing.Size(79, 34);
            this.btnTempCancel.TabIndex = 18;
            this.btnTempCancel.Text = "Cancel";
            this.btnTempCancel.UseVisualStyleBackColor = true;
            this.btnTempCancel.Click += new System.EventHandler(this.btnTempCancel_Click);
            // 
            // btnTempLoad
            // 
            this.btnTempLoad.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTempLoad.Location = new System.Drawing.Point(210, 452);
            this.btnTempLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTempLoad.Name = "btnTempLoad";
            this.btnTempLoad.Size = new System.Drawing.Size(79, 34);
            this.btnTempLoad.TabIndex = 17;
            this.btnTempLoad.Text = "Load";
            this.btnTempLoad.UseVisualStyleBackColor = true;
            this.btnTempLoad.Click += new System.EventHandler(this.btnTempLoad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Description: ";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(96, 55);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(512, 45);
            this.txtDescription.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tag List:";
            // 
            // lvCalcTagList
            // 
            this.lvCalcTagList.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCalcTagList.FullRowSelect = true;
            this.lvCalcTagList.GridLines = true;
            this.lvCalcTagList.Location = new System.Drawing.Point(22, 336);
            this.lvCalcTagList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lvCalcTagList.Name = "lvCalcTagList";
            this.lvCalcTagList.Size = new System.Drawing.Size(586, 112);
            this.lvCalcTagList.TabIndex = 26;
            this.lvCalcTagList.UseCompatibleStateImageBehavior = false;
            this.lvCalcTagList.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 314);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "Calculation Tag List:";
            // 
            // frmLoadTagSetTemplate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(627, 491);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lvCalcTagList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTempCancel);
            this.Controls.Add(this.btnTempLoad);
            this.Controls.Add(this.lvTagList);
            this.Controls.Add(this.cmbTagSet);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvCalcTagList;
        private System.Windows.Forms.Label label4;
    }
}