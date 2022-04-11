namespace JobTracker.InvoiceReport
{
    partial class RptInvoiceView
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
            this.saveDioInvoice = new System.Windows.Forms.SaveFileDialog();
            this.prntdialog = new System.Windows.Forms.PrintDialog();
            this.btnPrintReport = new System.Windows.Forms.Button();
            this.btnExportInvoice = new System.Windows.Forms.Button();
            this.btnShowReport = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.CRVAllInreport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblCrvReport = new System.Windows.Forms.Label();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // prntdialog
            // 
            this.prntdialog.UseEXDialog = true;
            // 
            // btnPrintReport
            // 
            this.btnPrintReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(207)))), ((int)(((byte)(254)))));
            this.btnPrintReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnPrintReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.btnPrintReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrintReport.Font = new System.Drawing.Font("Calibri", 8F);
            this.btnPrintReport.Image = global::JobTracker.Properties.Resources.PrintDOC;
            this.btnPrintReport.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPrintReport.Location = new System.Drawing.Point(663, 1);
            this.btnPrintReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrintReport.Name = "btnPrintReport";
            this.btnPrintReport.Size = new System.Drawing.Size(68, 22);
            this.btnPrintReport.TabIndex = 284;
            this.btnPrintReport.Text = "Print";
            this.btnPrintReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrintReport.UseVisualStyleBackColor = false;
            this.btnPrintReport.Click += new System.EventHandler(this.btnPrintReport_Click_1);
            // 
            // btnExportInvoice
            // 
            this.btnExportInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(207)))), ((int)(((byte)(254)))));
            this.btnExportInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnExportInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.btnExportInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportInvoice.Font = new System.Drawing.Font("Calibri", 8F);
            this.btnExportInvoice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportInvoice.Location = new System.Drawing.Point(9, 2);
            this.btnExportInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportInvoice.Name = "btnExportInvoice";
            this.btnExportInvoice.Size = new System.Drawing.Size(129, 22);
            this.btnExportInvoice.TabIndex = 283;
            this.btnExportInvoice.Text = "Export Invoice IFF";
            this.btnExportInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportInvoice.UseVisualStyleBackColor = false;
            this.btnExportInvoice.Click += new System.EventHandler(this.btnExportInvoice_Click_1);
            // 
            // btnShowReport
            // 
            this.btnShowReport.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnShowReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(207)))), ((int)(((byte)(254)))));
            this.btnShowReport.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnShowReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.btnShowReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowReport.Font = new System.Drawing.Font("Calibri", 8F);
            this.btnShowReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowReport.Location = new System.Drawing.Point(490, 0);
            this.btnShowReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowReport.Name = "btnShowReport";
            this.btnShowReport.Size = new System.Drawing.Size(169, 22);
            this.btnShowReport.TabIndex = 285;
            this.btnShowReport.Text = "Show &Report (Alt+R)";
            this.btnShowReport.UseVisualStyleBackColor = false;
            this.btnShowReport.Click += new System.EventHandler(this.btnShowReport_Click_1);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.Controls.Add(this.CRVAllInreport);
            this.Panel1.Location = new System.Drawing.Point(9, 31);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(722, 520);
            this.Panel1.TabIndex = 287;
            // 
            // CRVAllInreport
            // 
            this.CRVAllInreport.ActiveViewIndex = -1;
            this.CRVAllInreport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CRVAllInreport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVAllInreport.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVAllInreport.Location = new System.Drawing.Point(4, 5);
            this.CRVAllInreport.Name = "CRVAllInreport";
            this.CRVAllInreport.Size = new System.Drawing.Size(715, 513);
            this.CRVAllInreport.TabIndex = 1;
            // 
            // lblCrvReport
            // 
            this.lblCrvReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCrvReport.AutoSize = true;
            this.lblCrvReport.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCrvReport.ForeColor = System.Drawing.Color.DarkRed;
            this.lblCrvReport.Location = new System.Drawing.Point(435, 8);
            this.lblCrvReport.Name = "lblCrvReport";
            this.lblCrvReport.Size = new System.Drawing.Size(50, 18);
            this.lblCrvReport.TabIndex = 288;
            this.lblCrvReport.Text = "Report";
            // 
            // RptInvoiceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 561);
            this.Controls.Add(this.lblCrvReport);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.btnShowReport);
            this.Controls.Add(this.btnPrintReport);
            this.Controls.Add(this.btnExportInvoice);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RptInvoiceView";
            this.Text = "ReportInvoiceForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RptInvoiceView_FormClosed_1);
            this.Load += new System.EventHandler(this.RptInvoiceView_Load_1);
            this.Panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.Button btnExportInvoice;
        internal System.Windows.Forms.SaveFileDialog saveDioInvoice;
        internal System.Windows.Forms.Button btnPrintReport;
        internal System.Windows.Forms.PrintDialog prntdialog;
        internal System.Windows.Forms.Button btnShowReport;
        internal System.Windows.Forms.Panel Panel1;
        internal CrystalDecisions.Windows.Forms.CrystalReportViewer CRVAllInreport;
        internal System.Windows.Forms.Label lblCrvReport;


        #endregion
    }
}