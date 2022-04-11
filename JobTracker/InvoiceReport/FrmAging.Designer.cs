using Microsoft.VisualBasic.CompilerServices;

namespace JobTracker.InvoiceReport
{
    partial class FrmAging
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlJobGrid = new System.Windows.Forms.Panel();
            this.CkbPendingInvoice = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtCompanySearch = new System.Windows.Forms.TextBox();
            this.lbClientAging = new System.Windows.Forms.Label();
            this.grdCompany = new System.Windows.Forms.DataGridView();
            this.PnlUpdateAgind = new System.Windows.Forms.Panel();
            this.btnDueInvoice = new System.Windows.Forms.Button();
            this.btnUpdateInvoiceDue = new System.Windows.Forms.Button();
            this.pnlAgindFileBrowser = new System.Windows.Forms.Panel();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlTraficLight = new System.Windows.Forms.Panel();
            this.btnAgingColor = new System.Windows.Forms.Button();
            this.InvoiceFileList = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.btnInvoicePermitsFileDownload = new System.Windows.Forms.Button();
            this.pnlAgingInvoice = new System.Windows.Forms.Panel();
            this.lbAginginvoice = new System.Windows.Forms.Label();
            this.grdAgingInvoice = new System.Windows.Forms.DataGridView();
            this.parentTableControl = new System.Windows.Forms.TableLayoutPanel();
            this.tablepnlCompany = new System.Windows.Forms.TableLayoutPanel();
            this.pnlJobGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).BeginInit();
            this.PnlUpdateAgind.SuspendLayout();
            this.pnlAgindFileBrowser.SuspendLayout();
            this.pnlTraficLight.SuspendLayout();
            this.pnlAgingInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgingInvoice)).BeginInit();
            this.parentTableControl.SuspendLayout();
            this.tablepnlCompany.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlJobGrid
            // 
            this.pnlJobGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlJobGrid.Controls.Add(this.CkbPendingInvoice);
            this.pnlJobGrid.Controls.Add(this.btnClear);
            this.pnlJobGrid.Controls.Add(this.lbSearch);
            this.pnlJobGrid.Controls.Add(this.txtCompanySearch);
            this.pnlJobGrid.Controls.Add(this.lbClientAging);
            this.pnlJobGrid.Controls.Add(this.grdCompany);
            this.pnlJobGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJobGrid.Location = new System.Drawing.Point(2, 2);
            this.pnlJobGrid.Margin = new System.Windows.Forms.Padding(2);
            this.pnlJobGrid.Name = "pnlJobGrid";
            this.pnlJobGrid.Size = new System.Drawing.Size(635, 291);
            this.pnlJobGrid.TabIndex = 283;
            // 
            // CkbPendingInvoice
            // 
            this.CkbPendingInvoice.AutoSize = true;
            this.CkbPendingInvoice.Checked = true;
            this.CkbPendingInvoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkbPendingInvoice.Location = new System.Drawing.Point(354, 6);
            this.CkbPendingInvoice.Name = "CkbPendingInvoice";
            this.CkbPendingInvoice.Size = new System.Drawing.Size(103, 17);
            this.CkbPendingInvoice.TabIndex = 289;
            this.CkbPendingInvoice.Text = "Pending Invoice";
            this.CkbPendingInvoice.UseVisualStyleBackColor = true;
            this.CkbPendingInvoice.CheckedChanged += new System.EventHandler(this.CkbPendingInvoice_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(559, 1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 288;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(88, 7);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(70, 13);
            this.lbSearch.TabIndex = 287;
            this.lbSearch.Text = "Client Search";
            // 
            // txtCompanySearch
            // 
            this.txtCompanySearch.Location = new System.Drawing.Point(164, 4);
            this.txtCompanySearch.Name = "txtCompanySearch";
            this.txtCompanySearch.Size = new System.Drawing.Size(139, 20);
            this.txtCompanySearch.TabIndex = 286;
            this.txtCompanySearch.TextChanged += new System.EventHandler(this.txtCompanySearch_TextChanged);
            // 
            // lbClientAging
            // 
            this.lbClientAging.AutoSize = true;
            this.lbClientAging.BackColor = System.Drawing.Color.Transparent;
            this.lbClientAging.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbClientAging.Location = new System.Drawing.Point(3, 3);
            this.lbClientAging.Name = "lbClientAging";
            this.lbClientAging.Size = new System.Drawing.Size(75, 15);
            this.lbClientAging.TabIndex = 285;
            this.lbClientAging.Text = "Client Aging ";
            // 
            // grdCompany
            // 
            this.grdCompany.AllowUserToAddRows = false;
            this.grdCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCompany.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCompany.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCompany.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCompany.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCompany.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdCompany.Location = new System.Drawing.Point(0, 28);
            this.grdCompany.Margin = new System.Windows.Forms.Padding(2);
            this.grdCompany.MultiSelect = false;
            this.grdCompany.Name = "grdCompany";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCompany.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCompany.RowTemplate.Height = 24;
            this.grdCompany.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCompany.Size = new System.Drawing.Size(633, 263);
            this.grdCompany.TabIndex = 196;
            this.grdCompany.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompany_CellClick);
            this.grdCompany.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCompany_RowHeaderMouseClick);
            this.grdCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCompany_KeyDown);
            // 
            // PnlUpdateAgind
            // 
            this.PnlUpdateAgind.Controls.Add(this.btnDueInvoice);
            this.PnlUpdateAgind.Controls.Add(this.btnUpdateInvoiceDue);
            this.PnlUpdateAgind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlUpdateAgind.Location = new System.Drawing.Point(3, 605);
            this.PnlUpdateAgind.Name = "PnlUpdateAgind";
            this.PnlUpdateAgind.Size = new System.Drawing.Size(944, 43);
            this.PnlUpdateAgind.TabIndex = 285;
            // 
            // btnDueInvoice
            // 
            this.btnDueInvoice.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDueInvoice.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDueInvoice.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDueInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnDueInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDueInvoice.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDueInvoice.Location = new System.Drawing.Point(175, 10);
            this.btnDueInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.btnDueInvoice.Name = "btnDueInvoice";
            this.btnDueInvoice.Size = new System.Drawing.Size(134, 25);
            this.btnDueInvoice.TabIndex = 283;
            this.btnDueInvoice.Text = "Email Due Invoice";
            this.btnDueInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDueInvoice.UseVisualStyleBackColor = false;
            this.btnDueInvoice.Click += new System.EventHandler(this.btnDueInvoice_Click);
            // 
            // btnUpdateInvoiceDue
            // 
            this.btnUpdateInvoiceDue.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdateInvoiceDue.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUpdateInvoiceDue.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(182)))), ((int)(((byte)(255)))));
            this.btnUpdateInvoiceDue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateInvoiceDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F);
            this.btnUpdateInvoiceDue.Image = global::JobTracker.Properties.Resources.edit_16;
            this.btnUpdateInvoiceDue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUpdateInvoiceDue.Location = new System.Drawing.Point(13, 9);
            this.btnUpdateInvoiceDue.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateInvoiceDue.Name = "btnUpdateInvoiceDue";
            this.btnUpdateInvoiceDue.Size = new System.Drawing.Size(119, 26);
            this.btnUpdateInvoiceDue.TabIndex = 282;
            this.btnUpdateInvoiceDue.Text = "Update Aging >>";
            this.btnUpdateInvoiceDue.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateInvoiceDue.UseVisualStyleBackColor = true;
            this.btnUpdateInvoiceDue.Click += new System.EventHandler(this.btnUpdateInvoiceDue_Click);
            // 
            // pnlAgindFileBrowser
            // 
            this.pnlAgindFileBrowser.BackColor = System.Drawing.Color.Transparent;
            this.pnlAgindFileBrowser.Controls.Add(this.Label1);
            this.pnlAgindFileBrowser.Controls.Add(this.pnlTraficLight);
            this.pnlAgindFileBrowser.Controls.Add(this.InvoiceFileList);
            this.pnlAgindFileBrowser.Controls.Add(this.btnInvoicePermitsFileDownload);
            this.pnlAgindFileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAgindFileBrowser.Location = new System.Drawing.Point(641, 2);
            this.pnlAgindFileBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAgindFileBrowser.Name = "pnlAgindFileBrowser";
            this.pnlAgindFileBrowser.Size = new System.Drawing.Size(301, 291);
            this.pnlAgindFileBrowser.TabIndex = 286;
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(108, 4);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 15);
            this.Label1.TabIndex = 286;
            this.Label1.Text = "Invoice File List";
            // 
            // pnlTraficLight
            // 
            this.pnlTraficLight.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlTraficLight.Controls.Add(this.btnAgingColor);
            this.pnlTraficLight.Location = new System.Drawing.Point(6, 52);
            this.pnlTraficLight.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTraficLight.Name = "pnlTraficLight";
            this.pnlTraficLight.Size = new System.Drawing.Size(96, 62);
            this.pnlTraficLight.TabIndex = 278;
            this.pnlTraficLight.Visible = false;
            // 
            // btnAgingColor
            // 
            this.btnAgingColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAgingColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgingColor.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAgingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgingColor.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.btnAgingColor.Location = new System.Drawing.Point(0, 0);
            this.btnAgingColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgingColor.Name = "btnAgingColor";
            this.btnAgingColor.Size = new System.Drawing.Size(96, 62);
            this.btnAgingColor.TabIndex = 271;
            this.btnAgingColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgingColor.UseVisualStyleBackColor = false;
            // 
            // InvoiceFileList
            // 
            this.InvoiceFileList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InvoiceFileList.FormattingEnabled = true;
            this.InvoiceFileList.Location = new System.Drawing.Point(109, 24);
            this.InvoiceFileList.Margin = new System.Windows.Forms.Padding(2);
            this.InvoiceFileList.Name = "InvoiceFileList";
            this.InvoiceFileList.Pattern = "*.*";
            this.InvoiceFileList.Size = new System.Drawing.Size(188, 238);
            this.InvoiceFileList.TabIndex = 236;
            this.InvoiceFileList.DoubleClick += new System.EventHandler(this.InvoiceFileList_DoubleClick);
            // 
            // btnInvoicePermitsFileDownload
            // 
            this.btnInvoicePermitsFileDownload.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnInvoicePermitsFileDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoicePermitsFileDownload.Location = new System.Drawing.Point(6, 129);
            this.btnInvoicePermitsFileDownload.Margin = new System.Windows.Forms.Padding(2);
            this.btnInvoicePermitsFileDownload.Name = "btnInvoicePermitsFileDownload";
            this.btnInvoicePermitsFileDownload.Size = new System.Drawing.Size(98, 69);
            this.btnInvoicePermitsFileDownload.TabIndex = 237;
            this.btnInvoicePermitsFileDownload.Text = "Permits/File Download";
            this.btnInvoicePermitsFileDownload.UseVisualStyleBackColor = true;
            this.btnInvoicePermitsFileDownload.Click += new System.EventHandler(this.btnInvoicePermitsFileDownload_Click);
            // 
            // pnlAgingInvoice
            // 
            this.pnlAgingInvoice.BackColor = System.Drawing.Color.Transparent;
            this.pnlAgingInvoice.Controls.Add(this.lbAginginvoice);
            this.pnlAgingInvoice.Controls.Add(this.grdAgingInvoice);
            this.pnlAgingInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAgingInvoice.Location = new System.Drawing.Point(3, 304);
            this.pnlAgingInvoice.Name = "pnlAgingInvoice";
            this.pnlAgingInvoice.Size = new System.Drawing.Size(944, 295);
            this.pnlAgingInvoice.TabIndex = 287;
            // 
            // lbAginginvoice
            // 
            this.lbAginginvoice.AutoSize = true;
            this.lbAginginvoice.BackColor = System.Drawing.Color.Transparent;
            this.lbAginginvoice.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbAginginvoice.Location = new System.Drawing.Point(10, 9);
            this.lbAginginvoice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAginginvoice.Name = "lbAginginvoice";
            this.lbAginginvoice.Size = new System.Drawing.Size(78, 15);
            this.lbAginginvoice.TabIndex = 207;
            this.lbAginginvoice.Text = "Aging Invoice";
            // 
            // grdAgingInvoice
            // 
            this.grdAgingInvoice.AllowUserToAddRows = false;
            this.grdAgingInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAgingInvoice.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdAgingInvoice.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAgingInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdAgingInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAgingInvoice.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdAgingInvoice.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdAgingInvoice.Location = new System.Drawing.Point(3, 37);
            this.grdAgingInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.grdAgingInvoice.MultiSelect = false;
            this.grdAgingInvoice.Name = "grdAgingInvoice";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAgingInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdAgingInvoice.RowTemplate.Height = 24;
            this.grdAgingInvoice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAgingInvoice.Size = new System.Drawing.Size(939, 252);
            this.grdAgingInvoice.TabIndex = 206;
            this.grdAgingInvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAgingInvoice_CellClick);
            this.grdAgingInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAgingInvoice_CellContentClick);
            this.grdAgingInvoice.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAgingInvoice_CellEndEdit);
            this.grdAgingInvoice.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdAgingInvoice_CellFormatting);
            this.grdAgingInvoice.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdAgingInvoice_DataError);
            this.grdAgingInvoice.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.grdAgingInvoice_EditingControlShowing);
            // 
            // parentTableControl
            // 
            this.parentTableControl.ColumnCount = 1;
            this.parentTableControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.parentTableControl.Controls.Add(this.tablepnlCompany, 0, 0);
            this.parentTableControl.Controls.Add(this.PnlUpdateAgind, 0, 2);
            this.parentTableControl.Controls.Add(this.pnlAgingInvoice, 0, 1);
            this.parentTableControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parentTableControl.Location = new System.Drawing.Point(0, 0);
            this.parentTableControl.Name = "parentTableControl";
            this.parentTableControl.RowCount = 3;
            this.parentTableControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.parentTableControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.parentTableControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.parentTableControl.Size = new System.Drawing.Size(950, 651);
            this.parentTableControl.TabIndex = 288;
            // 
            // tablepnlCompany
            // 
            this.tablepnlCompany.ColumnCount = 2;
            this.tablepnlCompany.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablepnlCompany.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 305F));
            this.tablepnlCompany.Controls.Add(this.pnlJobGrid, 0, 0);
            this.tablepnlCompany.Controls.Add(this.pnlAgindFileBrowser, 1, 0);
            this.tablepnlCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablepnlCompany.Location = new System.Drawing.Point(3, 3);
            this.tablepnlCompany.Name = "tablepnlCompany";
            this.tablepnlCompany.RowCount = 1;
            this.tablepnlCompany.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablepnlCompany.Size = new System.Drawing.Size(944, 295);
            this.tablepnlCompany.TabIndex = 0;
            // 
            // FrmAging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(950, 651);
            this.Controls.Add(this.parentTableControl);
            this.Name = "FrmAging";
            this.Text = "Aging";
            this.Load += new System.EventHandler(this.FrmAging_Load);
            this.pnlJobGrid.ResumeLayout(false);
            this.pnlJobGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).EndInit();
            this.PnlUpdateAgind.ResumeLayout(false);
            this.pnlAgindFileBrowser.ResumeLayout(false);
            this.pnlAgindFileBrowser.PerformLayout();
            this.pnlTraficLight.ResumeLayout(false);
            this.pnlAgingInvoice.ResumeLayout(false);
            this.pnlAgingInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAgingInvoice)).EndInit();
            this.parentTableControl.ResumeLayout(false);
            this.tablepnlCompany.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.Panel pnlJobGrid;
        internal System.Windows.Forms.DataGridView grdCompany;
        internal System.Windows.Forms.Label lbClientAging;
        internal System.Windows.Forms.Panel PnlUpdateAgind;
        internal System.Windows.Forms.Button btnUpdateInvoiceDue;
        internal System.Windows.Forms.Button btnDueInvoice;
        internal System.Windows.Forms.Panel pnlAgindFileBrowser;
        internal Microsoft.VisualBasic.Compatibility.VB6.FileListBox InvoiceFileList;
        internal System.Windows.Forms.Button btnInvoicePermitsFileDownload;
        internal System.Windows.Forms.Panel pnlAgingInvoice;
        internal System.Windows.Forms.Panel pnlTraficLight;
        internal System.Windows.Forms.Button btnAgingColor;
        internal System.Windows.Forms.Label lbAginginvoice;
        internal System.Windows.Forms.DataGridView grdAgingInvoice;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TableLayoutPanel parentTableControl;
        internal System.Windows.Forms.TableLayoutPanel tablepnlCompany;
        internal System.Windows.Forms.TextBox txtCompanySearch;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Label lbSearch;
        internal System.Windows.Forms.CheckBox CkbPendingInvoice;
        #endregion
    }
}