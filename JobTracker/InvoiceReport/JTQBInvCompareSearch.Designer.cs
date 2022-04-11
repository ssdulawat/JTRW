using System;

namespace JobTracker.InvoiceReport
{
    partial class JTQBInvCompareSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnInvoiceSearch = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.dtpInvoiceFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpInvoiceTo = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnExport = new System.Windows.Forms.Button();
            this.lblFileName = new System.Windows.Forms.Label();
            this.BtnFileSelect = new System.Windows.Forms.Button();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.grdCompaireInvoiceStatus = new System.Windows.Forms.DataGridView();
            this.InvoiceNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.FolderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Panel1.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompaireInvoiceStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnInvoiceSearch
            // 
            this.BtnInvoiceSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnInvoiceSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnInvoiceSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.BtnInvoiceSearch.Location = new System.Drawing.Point(919, 32);
            this.BtnInvoiceSearch.Name = "BtnInvoiceSearch";
            this.BtnInvoiceSearch.Size = new System.Drawing.Size(160, 35);
            this.BtnInvoiceSearch.TabIndex = 4;
            this.BtnInvoiceSearch.Text = "Search";
            this.BtnInvoiceSearch.UseVisualStyleBackColor = false;
            this.BtnInvoiceSearch.Click += new System.EventHandler(this.BtnInvoiceSearch_Click);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.Controls.Add(this.Label2);
            this.Panel1.Controls.Add(this.dtpInvoiceFrom);
            this.Panel1.Controls.Add(this.dtpInvoiceTo);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Location = new System.Drawing.Point(313, 27);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(572, 55);
            this.Panel1.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(20, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 15);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "From";
            // 
            // dtpInvoiceFrom
            // 
            this.dtpInvoiceFrom.Location = new System.Drawing.Point(78, 13);
            this.dtpInvoiceFrom.Name = "dtpInvoiceFrom";
            this.dtpInvoiceFrom.Size = new System.Drawing.Size(205, 21);
            this.dtpInvoiceFrom.TabIndex = 0;
            this.dtpInvoiceFrom.Value = new System.DateTime(2018, 9, 28, 0, 0, 0, 0);
            // 
            // dtpInvoiceTo
            // 
            this.dtpInvoiceTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtpInvoiceTo.Location = new System.Drawing.Point(351, 13);
            this.dtpInvoiceTo.Name = "dtpInvoiceTo";
            this.dtpInvoiceTo.Size = new System.Drawing.Size(205, 21);
            this.dtpInvoiceTo.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(310, 15);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(23, 15);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "To";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.Controls.Add(this.BtnExport);
            this.GroupBox1.Controls.Add(this.lblFileName);
            this.GroupBox1.Controls.Add(this.BtnFileSelect);
            this.GroupBox1.Controls.Add(this.Panel1);
            this.GroupBox1.Controls.Add(this.BtnInvoiceSearch);
            this.GroupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.GroupBox1.Location = new System.Drawing.Point(12, 28);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(1104, 93);
            this.GroupBox1.TabIndex = 0;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "JT  Invoice  Search";
            // 
            // BtnExport
            // 
            this.BtnExport.Image = global::JobTracker.Properties.Resources.importExcel;
            this.BtnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnExport.Location = new System.Drawing.Point(829, 27);
            this.BtnExport.Name = "BtnExport";
            this.BtnExport.Size = new System.Drawing.Size(163, 40);
            this.BtnExport.TabIndex = 2;
            this.BtnExport.Text = "Export";
            this.BtnExport.UseVisualStyleBackColor = true;
            this.BtnExport.Click += new System.EventHandler(this.BtnExport_Click);
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(44, 70);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(0, 15);
            this.lblFileName.TabIndex = 7;
            // 
            // BtnFileSelect
            // 
            this.BtnFileSelect.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.BtnFileSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.BtnFileSelect.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnFileSelect.Location = new System.Drawing.Point(47, 32);
            this.BtnFileSelect.Name = "BtnFileSelect";
            this.BtnFileSelect.Size = new System.Drawing.Size(165, 35);
            this.BtnFileSelect.TabIndex = 6;
            this.BtnFileSelect.Text = "File Select";
            this.BtnFileSelect.UseVisualStyleBackColor = false;
            this.BtnFileSelect.Click += new System.EventHandler(this.BtnFileSelect_Click);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.Controls.Add(this.grdCompaireInvoiceStatus);
            this.GroupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.Location = new System.Drawing.Point(12, 127);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(1104, 533);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Invoice compare status result";
            // 
            // grdCompaireInvoiceStatus
            // 
            this.grdCompaireInvoiceStatus.AllowUserToAddRows = false;
            this.grdCompaireInvoiceStatus.AllowUserToDeleteRows = false;
            this.grdCompaireInvoiceStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCompaireInvoiceStatus.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCompaireInvoiceStatus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdCompaireInvoiceStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.InvoiceNumber,
            this.InvoiceDate,
            this.InvoiceAmount,
            this.Status});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCompaireInvoiceStatus.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdCompaireInvoiceStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCompaireInvoiceStatus.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCompaireInvoiceStatus.Location = new System.Drawing.Point(3, 20);
            this.grdCompaireInvoiceStatus.Margin = new System.Windows.Forms.Padding(2);
            this.grdCompaireInvoiceStatus.MultiSelect = false;
            this.grdCompaireInvoiceStatus.Name = "grdCompaireInvoiceStatus";
            this.grdCompaireInvoiceStatus.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCompaireInvoiceStatus.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.grdCompaireInvoiceStatus.RowTemplate.Height = 24;
            this.grdCompaireInvoiceStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdCompaireInvoiceStatus.Size = new System.Drawing.Size(1098, 510);
            this.grdCompaireInvoiceStatus.TabIndex = 208;
            // 
            // InvoiceNumber
            // 
            this.InvoiceNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceNumber.DataPropertyName = "InvoiceNumber";
            this.InvoiceNumber.HeaderText = "Invoice Number";
            this.InvoiceNumber.Name = "InvoiceNumber";
            this.InvoiceNumber.ReadOnly = true;
            this.InvoiceNumber.Width = 136;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            dataGridViewCellStyle10.Format = "MM-dd-yyyy";
            dataGridViewCellStyle10.NullValue = null;
            this.InvoiceDate.DefaultCellStyle = dataGridViewCellStyle10;
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 114;
            // 
            // InvoiceAmount
            // 
            this.InvoiceAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceAmount.DataPropertyName = "InvoiceAmount";
            this.InvoiceAmount.HeaderText = "InvoiceAmount";
            this.InvoiceAmount.Name = "InvoiceAmount";
            this.InvoiceAmount.ReadOnly = true;
            this.InvoiceAmount.Width = 130;
            // 
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Status.DataPropertyName = "StatusDescription";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.FileName = "OpenFileDialog1";
            // 
            // JTQBInvCompareSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1128, 672);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Name = "JTQBInvCompareSearch";
            this.Text = "JT QB Inv Compare Search";
            this.Load += new System.EventHandler(this.JTQBInvCompareSearch_Load_1);
            this.Enter += new System.EventHandler(this.JTQBInvCompareSearch_Load);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCompaireInvoiceStatus)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Button BtnInvoiceSearch;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.DateTimePicker dtpInvoiceFrom;
        internal System.Windows.Forms.DateTimePicker dtpInvoiceTo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.FolderBrowserDialog FolderBrowserDialog1;
        internal System.Windows.Forms.Button BtnFileSelect;
        internal System.Windows.Forms.DataGridView grdCompaireInvoiceStatus;
        internal System.Windows.Forms.Label lblFileName;
        #endregion

        private System.Windows.Forms.Button BtnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}