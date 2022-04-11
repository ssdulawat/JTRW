﻿namespace JobTracker.InvoiceReport
{
    partial class frmBillableJobSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DGVSearchJob = new System.Windows.Forms.DataGridView();
            this.LblNoCreditColor = new System.Windows.Forms.Label();
            this.TxtBoxNoColor = new System.Windows.Forms.TextBox();
            this.LblGreenColor = new System.Windows.Forms.Label();
            this.TxtBoxGreenColor = new System.Windows.Forms.TextBox();
            this.LblRedColor = new System.Windows.Forms.Label();
            this.TxtBoxRedColor = new System.Windows.Forms.TextBox();
            this.LblBlackColor = new System.Windows.Forms.Label();
            this.TxtBoxBlackColor = new System.Windows.Forms.TextBox();
            this.txtBoxamount = new System.Windows.Forms.TextBox();
            this.Lblamount = new System.Windows.Forms.Label();
            this.GrpBoxCondition = new System.Windows.Forms.GroupBox();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.BtnBillJobSearch = new System.Windows.Forms.Button();
            this.BtnExport = new System.Windows.Forms.Button();
            this.TxtBoxOrangeColor = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.TxtBoxYellowColor = new System.Windows.Forms.TextBox();
            this.LblYellowColor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchJob)).BeginInit();
            this.GrpBoxCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGVSearchJob
            // 
            this.DGVSearchJob.AllowUserToAddRows = false;
            this.DGVSearchJob.AllowUserToDeleteRows = false;
            this.DGVSearchJob.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVSearchJob.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchJob.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DGVSearchJob.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGVSearchJob.DefaultCellStyle = dataGridViewCellStyle2;
            this.DGVSearchJob.Location = new System.Drawing.Point(35, 258);
            this.DGVSearchJob.MultiSelect = false;
            this.DGVSearchJob.Name = "DGVSearchJob";
            this.DGVSearchJob.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGVSearchJob.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DGVSearchJob.Size = new System.Drawing.Size(1047, 402);
            this.DGVSearchJob.TabIndex = 13;
            // 
            // LblNoCreditColor
            // 
            this.LblNoCreditColor.AutoSize = true;
            this.LblNoCreditColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNoCreditColor.Location = new System.Drawing.Point(73, 29);
            this.LblNoCreditColor.Name = "LblNoCreditColor";
            this.LblNoCreditColor.Size = new System.Drawing.Size(241, 15);
            this.LblNoCreditColor.TabIndex = 17;
            this.LblNoCreditColor.Text = "\"No Invoice Days Max\" for NO Credit color  :";
            // 
            // TxtBoxNoColor
            // 
            this.TxtBoxNoColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxNoColor.Location = new System.Drawing.Point(336, 28);
            this.TxtBoxNoColor.Name = "TxtBoxNoColor";
            this.TxtBoxNoColor.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxNoColor.TabIndex = 18;
            this.TxtBoxNoColor.Text = "28";
            // 
            // LblGreenColor
            // 
            this.LblGreenColor.AutoSize = true;
            this.LblGreenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGreenColor.Location = new System.Drawing.Point(73, 58);
            this.LblGreenColor.Name = "LblGreenColor";
            this.LblGreenColor.Size = new System.Drawing.Size(237, 15);
            this.LblGreenColor.TabIndex = 19;
            this.LblGreenColor.Text = "\"No Invoice Days Max\" for Green  color      :";
            // 
            // TxtBoxGreenColor
            // 
            this.TxtBoxGreenColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxGreenColor.Location = new System.Drawing.Point(336, 57);
            this.TxtBoxGreenColor.Name = "TxtBoxGreenColor";
            this.TxtBoxGreenColor.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxGreenColor.TabIndex = 20;
            this.TxtBoxGreenColor.Text = "28";
            // 
            // LblRedColor
            // 
            this.LblRedColor.AutoSize = true;
            this.LblRedColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRedColor.Location = new System.Drawing.Point(73, 87);
            this.LblRedColor.Name = "LblRedColor";
            this.LblRedColor.Size = new System.Drawing.Size(235, 15);
            this.LblRedColor.TabIndex = 25;
            this.LblRedColor.Text = "\"No Invoice Days Max\" for Red color          :";
            // 
            // TxtBoxRedColor
            // 
            this.TxtBoxRedColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxRedColor.Location = new System.Drawing.Point(336, 86);
            this.TxtBoxRedColor.Name = "TxtBoxRedColor";
            this.TxtBoxRedColor.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxRedColor.TabIndex = 26;
            this.TxtBoxRedColor.Text = "7";
            // 
            // LblBlackColor
            // 
            this.LblBlackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblBlackColor.AutoSize = true;
            this.LblBlackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBlackColor.Location = new System.Drawing.Point(519, 87);
            this.LblBlackColor.Name = "LblBlackColor";
            this.LblBlackColor.Size = new System.Drawing.Size(233, 15);
            this.LblBlackColor.TabIndex = 27;
            this.LblBlackColor.Text = "\"No Invoice Days Max\" for Black color       :";
            // 
            // TxtBoxBlackColor
            // 
            this.TxtBoxBlackColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBoxBlackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxBlackColor.Location = new System.Drawing.Point(777, 86);
            this.TxtBoxBlackColor.Name = "TxtBoxBlackColor";
            this.TxtBoxBlackColor.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxBlackColor.TabIndex = 28;
            this.TxtBoxBlackColor.Text = "4";
            // 
            // txtBoxamount
            // 
            this.txtBoxamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxamount.Location = new System.Drawing.Point(336, 115);
            this.txtBoxamount.Name = "txtBoxamount";
            this.txtBoxamount.Size = new System.Drawing.Size(100, 20);
            this.txtBoxamount.TabIndex = 29;
            this.txtBoxamount.Text = "1200";
            // 
            // Lblamount
            // 
            this.Lblamount.AutoSize = true;
            this.Lblamount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lblamount.Location = new System.Drawing.Point(73, 116);
            this.Lblamount.Name = "Lblamount";
            this.Lblamount.Size = new System.Drawing.Size(237, 15);
            this.Lblamount.TabIndex = 30;
            this.Lblamount.Text = "Invoice amount is greater than                     :";
            // 
            // GrpBoxCondition
            // 
            this.GrpBoxCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpBoxCondition.Controls.Add(this.lblRecordsCount);
            this.GrpBoxCondition.Controls.Add(this.BtnBillJobSearch);
            this.GrpBoxCondition.Controls.Add(this.BtnExport);
            this.GrpBoxCondition.Controls.Add(this.TxtBoxOrangeColor);
            this.GrpBoxCondition.Controls.Add(this.Label3);
            this.GrpBoxCondition.Controls.Add(this.TxtBoxYellowColor);
            this.GrpBoxCondition.Controls.Add(this.LblYellowColor);
            this.GrpBoxCondition.Controls.Add(this.Lblamount);
            this.GrpBoxCondition.Controls.Add(this.txtBoxamount);
            this.GrpBoxCondition.Controls.Add(this.TxtBoxBlackColor);
            this.GrpBoxCondition.Controls.Add(this.LblBlackColor);
            this.GrpBoxCondition.Controls.Add(this.TxtBoxRedColor);
            this.GrpBoxCondition.Controls.Add(this.LblRedColor);
            this.GrpBoxCondition.Controls.Add(this.TxtBoxGreenColor);
            this.GrpBoxCondition.Controls.Add(this.LblGreenColor);
            this.GrpBoxCondition.Controls.Add(this.TxtBoxNoColor);
            this.GrpBoxCondition.Controls.Add(this.LblNoCreditColor);
            this.GrpBoxCondition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GrpBoxCondition.Location = new System.Drawing.Point(36, 28);
            this.GrpBoxCondition.Name = "GrpBoxCondition";
            this.GrpBoxCondition.Size = new System.Drawing.Size(1044, 214);
            this.GrpBoxCondition.TabIndex = 17;
            this.GrpBoxCondition.TabStop = false;
            this.GrpBoxCondition.Text = "Billable Jobs Criteria";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(11, 188);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(121, 15);
            this.lblRecordsCount.TabIndex = 36;
            this.lblRecordsCount.Text = "Total Records :- 0";
            // 
            // BtnBillJobSearch
            // 
            this.BtnBillJobSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnBillJobSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnBillJobSearch.Image = global::JobTracker.Properties.Resources.search_icon;
            this.BtnBillJobSearch.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.BtnBillJobSearch.Location = new System.Drawing.Point(717, 150);
            this.BtnBillJobSearch.Name = "BtnBillJobSearch";
            this.BtnBillJobSearch.Size = new System.Drawing.Size(160, 35);
            this.BtnBillJobSearch.TabIndex = 35;
            this.BtnBillJobSearch.Text = "Scan for billable Jobs";
            this.BtnBillJobSearch.UseVisualStyleBackColor = false;
            this.BtnBillJobSearch.Click += new System.EventHandler(this.BtnBillJobDisableSearch_Click);
            // 
            // BtnExport
            // 
            this.BtnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnExport.Location = new System.Drawing.Point(893, 150);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(135, 35);
            this.BtnExport.TabIndex = 14;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = false;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // TxtBoxOrangeColor
            // 
            this.TxtBoxOrangeColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBoxOrangeColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxOrangeColor.Location = new System.Drawing.Point(777, 57);
            this.TxtBoxOrangeColor.Name = "TxtBoxOrangeColor";
            this.TxtBoxOrangeColor.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxOrangeColor.TabIndex = 34;
            this.TxtBoxOrangeColor.Text = "14";
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(519, 58);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(238, 15);
            this.Label3.TabIndex = 33;
            this.Label3.Text = "\"No Invoice Days Max\" for Orange color     :";
            // 
            // TxtBoxYellowColor
            // 
            this.TxtBoxYellowColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtBoxYellowColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtBoxYellowColor.Location = new System.Drawing.Point(777, 28);
            this.TxtBoxYellowColor.Name = "TxtBoxYellowColor";
            this.TxtBoxYellowColor.Size = new System.Drawing.Size(100, 20);
            this.TxtBoxYellowColor.TabIndex = 32;
            this.TxtBoxYellowColor.Text = "21";
            // 
            // LblYellowColor
            // 
            this.LblYellowColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblYellowColor.AutoSize = true;
            this.LblYellowColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblYellowColor.Location = new System.Drawing.Point(519, 29);
            this.LblYellowColor.Name = "LblYellowColor";
            this.LblYellowColor.Size = new System.Drawing.Size(236, 15);
            this.LblYellowColor.TabIndex = 31;
            this.LblYellowColor.Text = "\"No Invoice Days Max\" for Yellow color      :";
            // 
            // frmBillableJobSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1128, 672);
            this.Controls.Add(this.GrpBoxCondition);
            this.Controls.Add(this.DGVSearchJob);
            this.Name = "frmBillableJobSearch";
            this.Text = "Billable Jobs Search";
            this.Load += new System.EventHandler(this.frmBillableJobSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVSearchJob)).EndInit();
            this.GrpBoxCondition.ResumeLayout(false);
            this.GrpBoxCondition.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.DataGridView DGVSearchJob;
        internal System.Windows.Forms.Button BtnExport;
        internal System.Windows.Forms.Label LblNoCreditColor;
        internal System.Windows.Forms.TextBox TxtBoxNoColor;
        internal System.Windows.Forms.Label LblGreenColor;
        internal System.Windows.Forms.TextBox TxtBoxGreenColor;
        internal System.Windows.Forms.Label LblRedColor;
        internal System.Windows.Forms.TextBox TxtBoxRedColor;
        internal System.Windows.Forms.Label LblBlackColor;
        internal System.Windows.Forms.TextBox TxtBoxBlackColor;
        internal System.Windows.Forms.TextBox txtBoxamount;
        internal System.Windows.Forms.Label Lblamount;
        internal System.Windows.Forms.GroupBox GrpBoxCondition;
        internal System.Windows.Forms.TextBox TxtBoxOrangeColor;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox TxtBoxYellowColor;
        internal System.Windows.Forms.Label LblYellowColor;
        internal System.Windows.Forms.Button BtnBillJobSearch;
        internal System.Windows.Forms.Label lblRecordsCount;
        #endregion
    }
}