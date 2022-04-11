namespace JobTracker.InvoiceReport
{
    partial class frmShowInvoice
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
            this.pnlSearchReport = new System.Windows.Forms.Panel();
            this.CRVInvoice = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSearchGrid = new System.Windows.Forms.Panel();
            this.grdSearchDetailInvoice = new System.Windows.Forms.DataGridView();
            this.btnGridUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGrdDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlSearchReport.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.pnlSearchGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchDetailInvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlSearchReport
            // 
            this.pnlSearchReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearchReport.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearchReport.Controls.Add(this.CRVInvoice);
            this.pnlSearchReport.Location = new System.Drawing.Point(2, 177);
            this.pnlSearchReport.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearchReport.Name = "pnlSearchReport";
            this.pnlSearchReport.Size = new System.Drawing.Size(1045, 473);
            this.pnlSearchReport.TabIndex = 2;
            // 
            // CRVInvoice
            // 
            this.CRVInvoice.ActiveViewIndex = -1;
            this.CRVInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRVInvoice.Cursor = System.Windows.Forms.Cursors.Default;
            this.CRVInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRVInvoice.Location = new System.Drawing.Point(0, 0);
            this.CRVInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.CRVInvoice.Name = "CRVInvoice";
            this.CRVInvoice.ShowCloseButton = false;
            this.CRVInvoice.ShowGroupTreeButton = false;
            this.CRVInvoice.ShowRefreshButton = false;
            this.CRVInvoice.Size = new System.Drawing.Size(1045, 473);
            this.CRVInvoice.TabIndex = 1;
            this.CRVInvoice.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            this.CRVInvoice.ToolPanelWidth = 150;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.TableLayoutPanel1.Controls.Add(this.pnlSearchGrid, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.pnlSearchReport, 0, 1);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1049, 652);
            this.TableLayoutPanel1.TabIndex = 208;
            // 
            // pnlSearchGrid
            // 
            this.pnlSearchGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearchGrid.Controls.Add(this.grdSearchDetailInvoice);
            this.pnlSearchGrid.Location = new System.Drawing.Point(2, 2);
            this.pnlSearchGrid.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearchGrid.Name = "pnlSearchGrid";
            this.pnlSearchGrid.Size = new System.Drawing.Size(1045, 171);
            this.pnlSearchGrid.TabIndex = 3;
            // 
            // grdSearchDetailInvoice
            // 
            this.grdSearchDetailInvoice.AllowUserToAddRows = false;
            this.grdSearchDetailInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdSearchDetailInvoice.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSearchDetailInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSearchDetailInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearchDetailInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnGridUpdate,
            this.btnGrdDelete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdSearchDetailInvoice.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdSearchDetailInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSearchDetailInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdSearchDetailInvoice.Location = new System.Drawing.Point(0, 0);
            this.grdSearchDetailInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.grdSearchDetailInvoice.MultiSelect = false;
            this.grdSearchDetailInvoice.Name = "grdSearchDetailInvoice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSearchDetailInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdSearchDetailInvoice.RowTemplate.Height = 24;
            this.grdSearchDetailInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSearchDetailInvoice.Size = new System.Drawing.Size(1045, 171);
            this.grdSearchDetailInvoice.TabIndex = 209;
            this.grdSearchDetailInvoice.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdSearchDetailInvoice_CellBeginEdit);
            this.grdSearchDetailInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchDetailInvoice_CellClick);
            this.grdSearchDetailInvoice.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSearchDetailInvoice_CellEndEdit);
            this.grdSearchDetailInvoice.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdSearchDetailInvoice_CellMouseDoubleClick);
            // 
            // btnGridUpdate
            // 
            this.btnGridUpdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnGridUpdate.Frozen = true;
            this.btnGridUpdate.HeaderText = "^";
            this.btnGridUpdate.Name = "btnGridUpdate";
            this.btnGridUpdate.Text = "^";
            this.btnGridUpdate.UseColumnTextForButtonValue = true;
            this.btnGridUpdate.Width = 30;
            // 
            // btnGrdDelete
            // 
            this.btnGrdDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnGrdDelete.Frozen = true;
            this.btnGrdDelete.HeaderText = "X";
            this.btnGrdDelete.Name = "btnGrdDelete";
            this.btnGrdDelete.Text = "X";
            this.btnGrdDelete.UseColumnTextForButtonValue = true;
            this.btnGrdDelete.Width = 30;
            // 
            // frmShowInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JobTracker.Properties.Resources.FormBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1051, 663);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmShowInvoice";
            this.Text = "Show Invoice ";
            this.Load += new System.EventHandler(this.frmSearchInvoice_Load);
            this.pnlSearchReport.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.pnlSearchGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchDetailInvoice)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel pnlSearchReport;
        internal CrystalDecisions.Windows.Forms.CrystalReportViewer CRVInvoice;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Panel pnlSearchGrid;
        internal System.Windows.Forms.DataGridView grdSearchDetailInvoice;
        internal System.Windows.Forms.DataGridViewButtonColumn btnGridUpdate;
        internal System.Windows.Forms.DataGridViewButtonColumn btnGrdDelete;
        #endregion
    }
}