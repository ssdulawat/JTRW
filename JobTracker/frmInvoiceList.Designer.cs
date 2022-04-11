namespace JobTracker
{
    partial class frmInvoiceList
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
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.InvoiceFileList = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.lblInvoice = new System.Windows.Forms.Label();
            this.pbLoadInvoiceList = new System.Windows.Forms.ProgressBar();
            this.bg = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.TableLayoutPanel1.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.InvoiceFileList, 0, 1);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.pbLoadInvoiceList, 0, 2);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.598726F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.40128F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(306, 335);
            this.TableLayoutPanel1.TabIndex = 2;
            // 
            // InvoiceFileList
            // 
            this.InvoiceFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InvoiceFileList.FormattingEnabled = true;
            this.InvoiceFileList.Location = new System.Drawing.Point(2, 28);
            this.InvoiceFileList.Margin = new System.Windows.Forms.Padding(2);
            this.InvoiceFileList.Name = "InvoiceFileList";
            this.InvoiceFileList.Pattern = "*.*";
            this.InvoiceFileList.Size = new System.Drawing.Size(302, 277);
            this.InvoiceFileList.TabIndex = 240;
            this.InvoiceFileList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.InvoiceFileList_MouseDoubleClick_1);
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.lblInvoice);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(300, 20);
            this.Panel1.TabIndex = 241;
            // 
            // lblInvoice
            // 
            this.lblInvoice.AutoSize = true;
            this.lblInvoice.BackColor = System.Drawing.Color.Transparent;
            this.lblInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoice.Location = new System.Drawing.Point(4, 3);
            this.lblInvoice.Name = "lblInvoice";
            this.lblInvoice.Size = new System.Drawing.Size(103, 15);
            this.lblInvoice.TabIndex = 2;
            this.lblInvoice.Text = "Invoice File list";
            // 
            // pbLoadInvoiceList
            // 
            this.pbLoadInvoiceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLoadInvoiceList.Location = new System.Drawing.Point(3, 310);
            this.pbLoadInvoiceList.Name = "pbLoadInvoiceList";
            this.pbLoadInvoiceList.Size = new System.Drawing.Size(300, 22);
            this.pbLoadInvoiceList.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbLoadInvoiceList.TabIndex = 242;
            // 
            // bg
            // 
            this.bg.WorkerReportsProgress = true;
            this.bg.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bg_DoWork_1);
            this.bg.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bg_ProgressChanged_1);
            this.bg.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bg_RunWorkerCompleted_1);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frmInvoiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JobTracker.Properties.Resources.FrmBkLight;
            this.ClientSize = new System.Drawing.Size(306, 335);
            this.Controls.Add(this.TableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmInvoiceList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice List";
            this.Load += new System.EventHandler(this.frmInvoiceList_Load_1);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal Microsoft.VisualBasic.Compatibility.VB6.FileListBox InvoiceFileList;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Label lblInvoice;
        internal System.Windows.Forms.ProgressBar pbLoadInvoiceList;
        internal System.ComponentModel.BackgroundWorker bg;


        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}