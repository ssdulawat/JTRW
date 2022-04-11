namespace JobTracker.InvoiceReport
{
    partial class ImportExcelInvoiceDue
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdInvoiceDueData = new System.Windows.Forms.DataGridView();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnUpdateInvoiceDue = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.OfdFindExcelFile = new System.Windows.Forms.OpenFileDialog();
            this.bgWorkerUpdateAging = new System.ComponentModel.BackgroundWorker();
            this.picBoxProcess = new System.Windows.Forms.PictureBox();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceDueData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProcess)).BeginInit();
            this.SuspendLayout();
            // 
            // grdInvoiceDueData
            // 
            this.grdInvoiceDueData.AllowUserToAddRows = false;
            this.grdInvoiceDueData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdInvoiceDueData.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoiceDueData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdInvoiceDueData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoiceDueData.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdInvoiceDueData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdInvoiceDueData.Location = new System.Drawing.Point(0, 66);
            this.grdInvoiceDueData.Margin = new System.Windows.Forms.Padding(2);
            this.grdInvoiceDueData.MultiSelect = false;
            this.grdInvoiceDueData.Name = "grdInvoiceDueData";
            this.grdInvoiceDueData.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoiceDueData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdInvoiceDueData.RowTemplate.Height = 24;
            this.grdInvoiceDueData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdInvoiceDueData.Size = new System.Drawing.Size(731, 501);
            this.grdInvoiceDueData.TabIndex = 284;
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtFilePath.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(116, 17);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(446, 22);
            this.txtFilePath.TabIndex = 285;
            // 
            // btnUpdateInvoiceDue
            // 
            this.btnUpdateInvoiceDue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdateInvoiceDue.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdateInvoiceDue.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdateInvoiceDue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnUpdateInvoiceDue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateInvoiceDue.Font = new System.Drawing.Font("Calibri", 8.5F);
            this.btnUpdateInvoiceDue.Image = global::JobTracker.Properties.Resources.edit_16;
            this.btnUpdateInvoiceDue.Location = new System.Drawing.Point(574, 12);
            this.btnUpdateInvoiceDue.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateInvoiceDue.Name = "btnUpdateInvoiceDue";
            this.btnUpdateInvoiceDue.Size = new System.Drawing.Size(147, 28);
            this.btnUpdateInvoiceDue.TabIndex = 288;
            this.btnUpdateInvoiceDue.Text = "Update Invoice Due";
            this.btnUpdateInvoiceDue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateInvoiceDue.UseVisualStyleBackColor = false;
            this.btnUpdateInvoiceDue.Click += new System.EventHandler(this.btnUpdateInvoiceDue_Click);
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(31, 21);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(54, 13);
            this.Label1.TabIndex = 289;
            this.Label1.Text = "File Name";
            // 
            // OfdFindExcelFile
            // 
            this.OfdFindExcelFile.FileName = "OpenFileDialog1";
            // 
            // bgWorkerUpdateAging
            // 
            this.bgWorkerUpdateAging.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerUpdateAging_DoWork_1);
            this.bgWorkerUpdateAging.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerUpdateAging_RunWorkerCompleted_1);
            // 
            // picBoxProcess
            // 
            this.picBoxProcess.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picBoxProcess.Image = global::JobTracker.Properties.Resources.UploadProcess;
            this.picBoxProcess.Location = new System.Drawing.Point(171, 257);
            this.picBoxProcess.Margin = new System.Windows.Forms.Padding(2);
            this.picBoxProcess.Name = "picBoxProcess";
            this.picBoxProcess.Size = new System.Drawing.Size(391, 29);
            this.picBoxProcess.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxProcess.TabIndex = 290;
            this.picBoxProcess.TabStop = false;
            this.picBoxProcess.Visible = false;
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalRecord.Location = new System.Drawing.Point(663, 47);
            this.lblTotalRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(64, 13);
            this.lblTotalRecord.TabIndex = 291;
            this.lblTotalRecord.Text = "Total Record";
            // 
            // ImportExcelInvoiceDue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(217)))), ((int)(((byte)(248)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(731, 567);
            this.Controls.Add(this.lblTotalRecord);
            this.Controls.Add(this.picBoxProcess);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnUpdateInvoiceDue);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.grdInvoiceDueData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ImportExcelInvoiceDue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Update Invoice Due";
            this.Load += new System.EventHandler(this.ImportExcelInvoiceDue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceDueData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProcess)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.DataGridView grdInvoiceDueData;
        internal System.Windows.Forms.TextBox txtFilePath;
        internal System.Windows.Forms.Button btnUpdateInvoiceDue;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.OpenFileDialog OfdFindExcelFile;
        internal System.ComponentModel.BackgroundWorker bgWorkerUpdateAging;
        internal System.Windows.Forms.PictureBox picBoxProcess;
        internal System.Windows.Forms.Label lblTotalRecord;


        #endregion
    }
}