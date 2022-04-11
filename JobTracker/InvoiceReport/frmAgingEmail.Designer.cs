using Microsoft.VisualBasic.CompilerServices;
using System;

namespace JobTracker.InvoiceReport
{
    partial class frmAgingEmail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlJobGrid = new System.Windows.Forms.Panel();
            this.chkActionStatusPending = new System.Windows.Forms.CheckBox();
            this.btnDueInvoiceCompany = new System.Windows.Forms.Button();
            this.CkbPendingInvoice = new System.Windows.Forms.CheckBox();
            this.lbSearch = new System.Windows.Forms.Label();
            this.txtCompanySearch = new System.Windows.Forms.TextBox();
            this.lbClientAging = new System.Windows.Forms.Label();
            this.grdCompany = new System.Windows.Forms.DataGridView();
            this.PnlUpdateAgind = new System.Windows.Forms.Panel();
            this.btnUpdateInvoiceDue = new System.Windows.Forms.Button();
            this.pnlAgindFileBrowser = new System.Windows.Forms.Panel();
            this.tblLayoutActionpnl = new System.Windows.Forms.TableLayoutPanel();
            this.grdInvoiceAction = new System.Windows.Forms.DataGridView();
            this.btnGrdUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGrdDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.cmbGrdAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.txtgrdActionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbGrdStatus = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.pnlFileList = new System.Windows.Forms.Panel();
            this.InvoiceFileList = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnAddInvoiceAction = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.pnlTraficLight = new System.Windows.Forms.Panel();
            this.btnAgingColor = new System.Windows.Forms.Button();
            this.btnInvoicePermitsFileDownload = new System.Windows.Forms.Button();
            this.pnlAgingInvoice = new System.Windows.Forms.Panel();
            this.txtCommLogNotes = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.dtpSearch = new System.Windows.Forms.DateTimePicker();
            this.txtMethodSearch = new System.Windows.Forms.TextBox();
            this.txtInvoiceSearch = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnSendmailAging = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.btnAddCommunication = new System.Windows.Forms.Button();
            this.chkSelect = new System.Windows.Forms.CheckBox();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdCommunicationLog = new System.Windows.Forms.DataGridView();
            this.btnGrdUpdateComm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnGrdDeleteComm = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.grdAging = new System.Windows.Forms.DataGridView();
            this.chkGrdSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lbAginginvoice = new System.Windows.Forms.Label();
            this.parentTableControl = new System.Windows.Forms.TableLayoutPanel();
            this.tablepnlCompany = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMail = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.picboxEmailProgress = new System.Windows.Forms.PictureBox();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.CBEmailBody = new System.Windows.Forms.GroupBox();
            this.btnAgingReport = new System.Windows.Forms.Button();
            this.agingBrowser = new System.Windows.Forms.WebBrowser();
            this.chkAttachAging = new System.Windows.Forms.CheckBox();
            this.txtEmailBody = new System.Windows.Forms.TextBox();
            this.GBemailHeader = new System.Windows.Forms.GroupBox();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.txtEmailTo = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbAdd = new System.Windows.Forms.CheckBox();
            this.grdAttachedfile = new System.Windows.Forms.DataGridView();
            this.backworkerEmailSender = new System.ComponentModel.BackgroundWorker();
            this.pnlJobGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).BeginInit();
            this.PnlUpdateAgind.SuspendLayout();
            this.pnlAgindFileBrowser.SuspendLayout();
            this.tblLayoutActionpnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceAction)).BeginInit();
            this.pnlFileList.SuspendLayout();
            this.pnlTraficLight.SuspendLayout();
            this.pnlAgingInvoice.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCommunicationLog)).BeginInit();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAging)).BeginInit();
            this.parentTableControl.SuspendLayout();
            this.tablepnlCompany.SuspendLayout();
            this.pnlMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEmailProgress)).BeginInit();
            this.CBEmailBody.SuspendLayout();
            this.GBemailHeader.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttachedfile)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlJobGrid
            // 
            this.pnlJobGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlJobGrid.Controls.Add(this.chkActionStatusPending);
            this.pnlJobGrid.Controls.Add(this.btnDueInvoiceCompany);
            this.pnlJobGrid.Controls.Add(this.CkbPendingInvoice);
            this.pnlJobGrid.Controls.Add(this.lbSearch);
            this.pnlJobGrid.Controls.Add(this.txtCompanySearch);
            this.pnlJobGrid.Controls.Add(this.lbClientAging);
            this.pnlJobGrid.Controls.Add(this.grdCompany);
            this.pnlJobGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlJobGrid.Location = new System.Drawing.Point(2, 2);
            this.pnlJobGrid.Margin = new System.Windows.Forms.Padding(2);
            this.pnlJobGrid.Name = "pnlJobGrid";
            this.pnlJobGrid.Size = new System.Drawing.Size(521, 320);
            this.pnlJobGrid.TabIndex = 283;
            // 
            // chkActionStatusPending
            // 
            this.chkActionStatusPending.AutoSize = true;
            this.chkActionStatusPending.Location = new System.Drawing.Point(300, 22);
            this.chkActionStatusPending.Name = "chkActionStatusPending";
            this.chkActionStatusPending.Size = new System.Drawing.Size(87, 17);
            this.chkActionStatusPending.TabIndex = 290;
            this.chkActionStatusPending.Text = "Status Pend,";
            this.chkActionStatusPending.UseVisualStyleBackColor = true;
            this.chkActionStatusPending.CheckedChanged += new System.EventHandler(this.chkActionStatusPending_CheckedChanged);
            // 
            // btnDueInvoiceCompany
            // 
            this.btnDueInvoiceCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDueInvoiceCompany.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnDueInvoiceCompany.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnDueInvoiceCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnDueInvoiceCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDueInvoiceCompany.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDueInvoiceCompany.Location = new System.Drawing.Point(395, 4);
            this.btnDueInvoiceCompany.Margin = new System.Windows.Forms.Padding(2);
            this.btnDueInvoiceCompany.Name = "btnDueInvoiceCompany";
            this.btnDueInvoiceCompany.Size = new System.Drawing.Size(119, 24);
            this.btnDueInvoiceCompany.TabIndex = 283;
            this.btnDueInvoiceCompany.Text = "Email Due Invoice";
            this.btnDueInvoiceCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDueInvoiceCompany.UseVisualStyleBackColor = false;
            this.btnDueInvoiceCompany.Click += new System.EventHandler(this.btnDueInvoice_Click);
            // 
            // CkbPendingInvoice
            // 
            this.CkbPendingInvoice.AutoSize = true;
            this.CkbPendingInvoice.Checked = true;
            this.CkbPendingInvoice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CkbPendingInvoice.Location = new System.Drawing.Point(300, 4);
            this.CkbPendingInvoice.Name = "CkbPendingInvoice";
            this.CkbPendingInvoice.Size = new System.Drawing.Size(92, 17);
            this.CkbPendingInvoice.TabIndex = 289;
            this.CkbPendingInvoice.Text = "Pend. Invoice";
            this.CkbPendingInvoice.UseVisualStyleBackColor = true;
            this.CkbPendingInvoice.CheckedChanged += new System.EventHandler(this.CkbPendingInvoice_CheckedChanged);
            // 
            // lbSearch
            // 
            this.lbSearch.AutoSize = true;
            this.lbSearch.Location = new System.Drawing.Point(84, 7);
            this.lbSearch.Name = "lbSearch";
            this.lbSearch.Size = new System.Drawing.Size(70, 13);
            this.lbSearch.TabIndex = 287;
            this.lbSearch.Text = "Client Search";
            // 
            // txtCompanySearch
            // 
            this.txtCompanySearch.Location = new System.Drawing.Point(157, 4);
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
            this.lbClientAging.Location = new System.Drawing.Point(3, 8);
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
            this.grdCompany.Location = new System.Drawing.Point(0, 40);
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
            this.grdCompany.Size = new System.Drawing.Size(519, 280);
            this.grdCompany.TabIndex = 196;
            this.grdCompany.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompany_CellClick);
            this.grdCompany.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompany_CellContentClick);
            this.grdCompany.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCompany_RowHeaderMouseClick);
            this.grdCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grdCompany_KeyDown);
            // 
            // PnlUpdateAgind
            // 
            this.PnlUpdateAgind.Controls.Add(this.btnUpdateInvoiceDue);
            this.PnlUpdateAgind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlUpdateAgind.Location = new System.Drawing.Point(3, 663);
            this.PnlUpdateAgind.Name = "PnlUpdateAgind";
            this.PnlUpdateAgind.Size = new System.Drawing.Size(1057, 44);
            this.PnlUpdateAgind.TabIndex = 285;
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
            this.btnUpdateInvoiceDue.Location = new System.Drawing.Point(69, 9);
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
            this.pnlAgindFileBrowser.Controls.Add(this.tblLayoutActionpnl);
            this.pnlAgindFileBrowser.Controls.Add(this.btnAddInvoiceAction);
            this.pnlAgindFileBrowser.Controls.Add(this.Label2);
            this.pnlAgindFileBrowser.Controls.Add(this.pnlTraficLight);
            this.pnlAgindFileBrowser.Controls.Add(this.btnInvoicePermitsFileDownload);
            this.pnlAgindFileBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAgindFileBrowser.Location = new System.Drawing.Point(527, 2);
            this.pnlAgindFileBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.pnlAgindFileBrowser.Name = "pnlAgindFileBrowser";
            this.pnlAgindFileBrowser.Size = new System.Drawing.Size(528, 320);
            this.pnlAgindFileBrowser.TabIndex = 286;
            // 
            // tblLayoutActionpnl
            // 
            this.tblLayoutActionpnl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLayoutActionpnl.ColumnCount = 2;
            this.tblLayoutActionpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutActionpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tblLayoutActionpnl.Controls.Add(this.grdInvoiceAction, 0, 0);
            this.tblLayoutActionpnl.Controls.Add(this.pnlFileList, 1, 0);
            this.tblLayoutActionpnl.Location = new System.Drawing.Point(3, 32);
            this.tblLayoutActionpnl.Name = "tblLayoutActionpnl";
            this.tblLayoutActionpnl.RowCount = 1;
            this.tblLayoutActionpnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLayoutActionpnl.Size = new System.Drawing.Size(526, 287);
            this.tblLayoutActionpnl.TabIndex = 291;
            // 
            // grdInvoiceAction
            // 
            this.grdInvoiceAction.AllowUserToAddRows = false;
            this.grdInvoiceAction.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoiceAction.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdInvoiceAction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInvoiceAction.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnGrdUpdate,
            this.btnGrdDelete,
            this.cmbGrdAction,
            this.txtgrdActionDate,
            this.cmbGrdStatus});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoiceAction.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdInvoiceAction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInvoiceAction.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdInvoiceAction.Location = new System.Drawing.Point(2, 2);
            this.grdInvoiceAction.Margin = new System.Windows.Forms.Padding(2);
            this.grdInvoiceAction.MultiSelect = false;
            this.grdInvoiceAction.Name = "grdInvoiceAction";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoiceAction.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdInvoiceAction.RowTemplate.Height = 24;
            this.grdInvoiceAction.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdInvoiceAction.Size = new System.Drawing.Size(418, 283);
            this.grdInvoiceAction.TabIndex = 287;
            this.grdInvoiceAction.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdInvoiceAction_CellBeginEdit);
            this.grdInvoiceAction.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoiceAction_CellClick);
            this.grdInvoiceAction.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoiceAction_CellEndEdit);
            this.grdInvoiceAction.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdInvoiceAction_CellFormatting);
            this.grdInvoiceAction.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoiceAction_CellLeave);
            // 
            // btnGrdUpdate
            // 
            this.btnGrdUpdate.Frozen = true;
            this.btnGrdUpdate.HeaderText = "^";
            this.btnGrdUpdate.Name = "btnGrdUpdate";
            this.btnGrdUpdate.Text = "^";
            this.btnGrdUpdate.UseColumnTextForButtonValue = true;
            this.btnGrdUpdate.Width = 30;
            // 
            // btnGrdDelete
            // 
            this.btnGrdDelete.HeaderText = "X";
            this.btnGrdDelete.Name = "btnGrdDelete";
            this.btnGrdDelete.Text = "X";
            this.btnGrdDelete.UseColumnTextForButtonValue = true;
            this.btnGrdDelete.Width = 30;
            // 
            // cmbGrdAction
            // 
            this.cmbGrdAction.DataPropertyName = "ActionName";
            this.cmbGrdAction.HeaderText = "Action";
            this.cmbGrdAction.Items.AddRange(new object[] {
            "Lien",
            "Sue",
            "Collector",
            "Erase"});
            this.cmbGrdAction.Name = "cmbGrdAction";
            this.cmbGrdAction.Width = 130;
            // 
            // txtgrdActionDate
            // 
            this.txtgrdActionDate.DataPropertyName = "ActionDate";
            this.txtgrdActionDate.HeaderText = "Action Date";
            this.txtgrdActionDate.Name = "txtgrdActionDate";
            this.txtgrdActionDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtgrdActionDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.txtgrdActionDate.Width = 129;
            // 
            // cmbGrdStatus
            // 
            this.cmbGrdStatus.DataPropertyName = "Status";
            this.cmbGrdStatus.HeaderText = "Status";
            this.cmbGrdStatus.Items.AddRange(new object[] {
            "Ignore",
            "Pending",
            "NotPending"});
            this.cmbGrdStatus.Name = "cmbGrdStatus";
            this.cmbGrdStatus.Width = 130;
            // 
            // pnlFileList
            // 
            this.pnlFileList.Controls.Add(this.InvoiceFileList);
            this.pnlFileList.Controls.Add(this.Label1);
            this.pnlFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFileList.Location = new System.Drawing.Point(425, 3);
            this.pnlFileList.Name = "pnlFileList";
            this.pnlFileList.Size = new System.Drawing.Size(98, 281);
            this.pnlFileList.TabIndex = 290;
            // 
            // InvoiceFileList
            // 
            this.InvoiceFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InvoiceFileList.FormattingEnabled = true;
            this.InvoiceFileList.Location = new System.Drawing.Point(2, 25);
            this.InvoiceFileList.Margin = new System.Windows.Forms.Padding(2);
            this.InvoiceFileList.Name = "InvoiceFileList";
            this.InvoiceFileList.Pattern = "*.*";
            this.InvoiceFileList.Size = new System.Drawing.Size(94, 251);
            this.InvoiceFileList.TabIndex = 236;
            this.InvoiceFileList.DoubleClick += new System.EventHandler(this.InvoiceFileList_DoubleClick_1);
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(2, 5);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 15);
            this.Label1.TabIndex = 286;
            this.Label1.Text = "Invoice File List";
            // 
            // btnAddInvoiceAction
            // 
            this.btnAddInvoiceAction.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddInvoiceAction.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddInvoiceAction.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAddInvoiceAction.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAddInvoiceAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddInvoiceAction.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddInvoiceAction.Location = new System.Drawing.Point(118, 4);
            this.btnAddInvoiceAction.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddInvoiceAction.Name = "btnAddInvoiceAction";
            this.btnAddInvoiceAction.Size = new System.Drawing.Size(62, 23);
            this.btnAddInvoiceAction.TabIndex = 289;
            this.btnAddInvoiceAction.Text = "Add";
            this.btnAddInvoiceAction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddInvoiceAction.UseVisualStyleBackColor = false;
            this.btnAddInvoiceAction.Click += new System.EventHandler(this.btnAddInvoiceAction_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(18, 8);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(83, 15);
            this.Label2.TabIndex = 288;
            this.Label2.Text = "Invoice Action";
            // 
            // pnlTraficLight
            // 
            this.pnlTraficLight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTraficLight.Controls.Add(this.btnAgingColor);
            this.pnlTraficLight.Location = new System.Drawing.Point(472, 2);
            this.pnlTraficLight.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTraficLight.Name = "pnlTraficLight";
            this.pnlTraficLight.Size = new System.Drawing.Size(50, 25);
            this.pnlTraficLight.TabIndex = 278;
            this.pnlTraficLight.Visible = false;
            // 
            // btnAgingColor
            // 
            this.btnAgingColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgingColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAgingColor.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAgingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgingColor.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.btnAgingColor.Location = new System.Drawing.Point(0, 0);
            this.btnAgingColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgingColor.Name = "btnAgingColor";
            this.btnAgingColor.Size = new System.Drawing.Size(50, 25);
            this.btnAgingColor.TabIndex = 271;
            this.btnAgingColor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAgingColor.UseVisualStyleBackColor = false;
            // 
            // btnInvoicePermitsFileDownload
            // 
            this.btnInvoicePermitsFileDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoicePermitsFileDownload.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInvoicePermitsFileDownload.Location = new System.Drawing.Point(390, 0);
            this.btnInvoicePermitsFileDownload.Margin = new System.Windows.Forms.Padding(2);
            this.btnInvoicePermitsFileDownload.Name = "btnInvoicePermitsFileDownload";
            this.btnInvoicePermitsFileDownload.Size = new System.Drawing.Size(68, 29);
            this.btnInvoicePermitsFileDownload.TabIndex = 237;
            this.btnInvoicePermitsFileDownload.Text = "Download";
            this.btnInvoicePermitsFileDownload.UseVisualStyleBackColor = true;
            this.btnInvoicePermitsFileDownload.Click += new System.EventHandler(this.btnInvoicePermitsFileDownload_Click);
            // 
            // pnlAgingInvoice
            // 
            this.pnlAgingInvoice.BackColor = System.Drawing.Color.Transparent;
            this.pnlAgingInvoice.Controls.Add(this.txtCommLogNotes);
            this.pnlAgingInvoice.Controls.Add(this.Label9);
            this.pnlAgingInvoice.Controls.Add(this.dtpSearch);
            this.pnlAgingInvoice.Controls.Add(this.txtMethodSearch);
            this.pnlAgingInvoice.Controls.Add(this.txtInvoiceSearch);
            this.pnlAgingInvoice.Controls.Add(this.Label8);
            this.pnlAgingInvoice.Controls.Add(this.Label7);
            this.pnlAgingInvoice.Controls.Add(this.Label6);
            this.pnlAgingInvoice.Controls.Add(this.btnSendmailAging);
            this.pnlAgingInvoice.Controls.Add(this.Label3);
            this.pnlAgingInvoice.Controls.Add(this.btnAddCommunication);
            this.pnlAgingInvoice.Controls.Add(this.chkSelect);
            this.pnlAgingInvoice.Controls.Add(this.TableLayoutPanel1);
            this.pnlAgingInvoice.Controls.Add(this.lbAginginvoice);
            this.pnlAgingInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAgingInvoice.Location = new System.Drawing.Point(3, 333);
            this.pnlAgingInvoice.Name = "pnlAgingInvoice";
            this.pnlAgingInvoice.Size = new System.Drawing.Size(1057, 324);
            this.pnlAgingInvoice.TabIndex = 287;
            // 
            // txtCommLogNotes
            // 
            this.txtCommLogNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCommLogNotes.Location = new System.Drawing.Point(865, 19);
            this.txtCommLogNotes.Name = "txtCommLogNotes";
            this.txtCommLogNotes.Size = new System.Drawing.Size(81, 20);
            this.txtCommLogNotes.TabIndex = 299;
            this.txtCommLogNotes.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCommLogNotes_KeyUp);
            // 
            // Label9
            // 
            this.Label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(887, 6);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(35, 13);
            this.Label9.TabIndex = 298;
            this.Label9.Text = "Notes";
            // 
            // dtpSearch
            // 
            this.dtpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSearch.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSearch.Location = new System.Drawing.Point(952, 19);
            this.dtpSearch.Name = "dtpSearch";
            this.dtpSearch.Size = new System.Drawing.Size(100, 20);
            this.dtpSearch.TabIndex = 297;
            this.dtpSearch.Value = new System.DateTime(2021, 11, 21, 0, 0, 0, 0);
            this.dtpSearch.ValueChanged += new System.EventHandler(this.dtpSearch_ValueChanged);
            // 
            // txtMethodSearch
            // 
            this.txtMethodSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMethodSearch.Location = new System.Drawing.Point(780, 19);
            this.txtMethodSearch.Name = "txtMethodSearch";
            this.txtMethodSearch.Size = new System.Drawing.Size(81, 20);
            this.txtMethodSearch.TabIndex = 296;
            this.txtMethodSearch.TextChanged += new System.EventHandler(this.txtMethodSearch_TextChanged);
            // 
            // txtInvoiceSearch
            // 
            this.txtInvoiceSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceSearch.Location = new System.Drawing.Point(692, 19);
            this.txtInvoiceSearch.Name = "txtInvoiceSearch";
            this.txtInvoiceSearch.Size = new System.Drawing.Size(81, 20);
            this.txtInvoiceSearch.TabIndex = 295;
            this.txtInvoiceSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtInvoiceSearch_KeyUp);
            // 
            // Label8
            // 
            this.Label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(968, 6);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(72, 13);
            this.Label8.TabIndex = 294;
            this.Label8.Text = "CallBackDate";
            // 
            // Label7
            // 
            this.Label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(802, 6);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(43, 13);
            this.Label7.TabIndex = 293;
            this.Label7.Text = "Method";
            // 
            // Label6
            // 
            this.Label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(713, 5);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(42, 13);
            this.Label6.TabIndex = 292;
            this.Label6.Text = "Invoice";
            // 
            // btnSendmailAging
            // 
            this.btnSendmailAging.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSendmailAging.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSendmailAging.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSendmailAging.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSendmailAging.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendmailAging.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendmailAging.Location = new System.Drawing.Point(379, 13);
            this.btnSendmailAging.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendmailAging.Name = "btnSendmailAging";
            this.btnSendmailAging.Size = new System.Drawing.Size(134, 21);
            this.btnSendmailAging.TabIndex = 291;
            this.btnSendmailAging.Text = "Email Due Invoice";
            this.btnSendmailAging.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendmailAging.UseVisualStyleBackColor = false;
            this.btnSendmailAging.Click += new System.EventHandler(this.btnSendmailAging_Click);
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.Label3.Location = new System.Drawing.Point(527, 1);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(115, 15);
            this.Label3.TabIndex = 290;
            this.Label3.Text = "Communication Log";
            // 
            // btnAddCommunication
            // 
            this.btnAddCommunication.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddCommunication.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAddCommunication.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAddCommunication.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAddCommunication.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCommunication.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddCommunication.Location = new System.Drawing.Point(601, 17);
            this.btnAddCommunication.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddCommunication.Name = "btnAddCommunication";
            this.btnAddCommunication.Size = new System.Drawing.Size(59, 23);
            this.btnAddCommunication.TabIndex = 290;
            this.btnAddCommunication.Text = "Add";
            this.btnAddCommunication.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddCommunication.UseVisualStyleBackColor = false;
            this.btnAddCommunication.Click += new System.EventHandler(this.btnAddCommunication_Click);
            // 
            // chkSelect
            // 
            this.chkSelect.AutoSize = true;
            this.chkSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSelect.Location = new System.Drawing.Point(10, 22);
            this.chkSelect.Name = "chkSelect";
            this.chkSelect.Size = new System.Drawing.Size(62, 17);
            this.chkSelect.TabIndex = 209;
            this.chkSelect.Text = "Select";
            this.chkSelect.UseVisualStyleBackColor = true;
            this.chkSelect.CheckedChanged += new System.EventHandler(this.chkSelect_CheckedChanged);
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.ColumnCount = 2;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.grdCommunicationLog, 1, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(3, 42);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 1;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 282F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1051, 282);
            this.TableLayoutPanel1.TabIndex = 208;
            // 
            // grdCommunicationLog
            // 
            this.grdCommunicationLog.AllowUserToAddRows = false;
            this.grdCommunicationLog.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdCommunicationLog.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCommunicationLog.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdCommunicationLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCommunicationLog.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnGrdUpdateComm,
            this.btnGrdDeleteComm});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCommunicationLog.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdCommunicationLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdCommunicationLog.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCommunicationLog.Location = new System.Drawing.Point(527, 2);
            this.grdCommunicationLog.Margin = new System.Windows.Forms.Padding(2);
            this.grdCommunicationLog.MultiSelect = false;
            this.grdCommunicationLog.Name = "grdCommunicationLog";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCommunicationLog.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdCommunicationLog.RowTemplate.Height = 60;
            this.grdCommunicationLog.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCommunicationLog.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCommunicationLog.Size = new System.Drawing.Size(522, 278);
            this.grdCommunicationLog.TabIndex = 207;
            this.grdCommunicationLog.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdCommunicationLog_CellBeginEdit);
            this.grdCommunicationLog.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCommunicationLog_CellClick);
            this.grdCommunicationLog.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCommunicationLog_CellContentClick);
            this.grdCommunicationLog.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCommunicationLog_CellEndEdit);
            this.grdCommunicationLog.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCommunicationLog_CellFormatting);
            this.grdCommunicationLog.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.grdCommunicationLog_DataError);
            // 
            // btnGrdUpdateComm
            // 
            this.btnGrdUpdateComm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnGrdUpdateComm.Frozen = true;
            this.btnGrdUpdateComm.HeaderText = "^";
            this.btnGrdUpdateComm.Name = "btnGrdUpdateComm";
            this.btnGrdUpdateComm.Text = "^";
            this.btnGrdUpdateComm.UseColumnTextForButtonValue = true;
            this.btnGrdUpdateComm.Width = 30;
            // 
            // btnGrdDeleteComm
            // 
            this.btnGrdDeleteComm.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnGrdDeleteComm.Frozen = true;
            this.btnGrdDeleteComm.HeaderText = "X";
            this.btnGrdDeleteComm.Name = "btnGrdDeleteComm";
            this.btnGrdDeleteComm.Text = "X";
            this.btnGrdDeleteComm.UseColumnTextForButtonValue = true;
            this.btnGrdDeleteComm.Width = 30;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.grdAging);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(519, 276);
            this.Panel1.TabIndex = 208;
            // 
            // grdAging
            // 
            this.grdAging.AllowUserToAddRows = false;
            this.grdAging.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdAging.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAging.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdAging.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAging.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkGrdSelect});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAging.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdAging.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAging.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdAging.Location = new System.Drawing.Point(0, 0);
            this.grdAging.Margin = new System.Windows.Forms.Padding(2);
            this.grdAging.MultiSelect = false;
            this.grdAging.Name = "grdAging";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAging.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.grdAging.RowTemplate.Height = 24;
            this.grdAging.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAging.Size = new System.Drawing.Size(519, 276);
            this.grdAging.TabIndex = 206;
            this.grdAging.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAgingInvoice_CellClick);
            this.grdAging.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAging_CellEndEdit);
            this.grdAging.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdAging_CellFormatting);
            // 
            // chkGrdSelect
            // 
            this.chkGrdSelect.Frozen = true;
            this.chkGrdSelect.HeaderText = ": :";
            this.chkGrdSelect.Name = "chkGrdSelect";
            this.chkGrdSelect.Width = 25;
            // 
            // lbAginginvoice
            // 
            this.lbAginginvoice.AutoSize = true;
            this.lbAginginvoice.BackColor = System.Drawing.Color.Transparent;
            this.lbAginginvoice.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.lbAginginvoice.Location = new System.Drawing.Point(5, 4);
            this.lbAginginvoice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAginginvoice.Name = "lbAginginvoice";
            this.lbAginginvoice.Size = new System.Drawing.Size(78, 15);
            this.lbAginginvoice.TabIndex = 207;
            this.lbAginginvoice.Text = "Aging Invoice";
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
            this.parentTableControl.Size = new System.Drawing.Size(1063, 710);
            this.parentTableControl.TabIndex = 288;
            // 
            // tablepnlCompany
            // 
            this.tablepnlCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablepnlCompany.ColumnCount = 2;
            this.tablepnlCompany.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablepnlCompany.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 532F));
            this.tablepnlCompany.Controls.Add(this.pnlJobGrid, 0, 0);
            this.tablepnlCompany.Controls.Add(this.pnlAgindFileBrowser, 1, 0);
            this.tablepnlCompany.Location = new System.Drawing.Point(3, 3);
            this.tablepnlCompany.Name = "tablepnlCompany";
            this.tablepnlCompany.RowCount = 1;
            this.tablepnlCompany.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tablepnlCompany.Size = new System.Drawing.Size(1057, 324);
            this.tablepnlCompany.TabIndex = 0;
            // 
            // pnlMail
            // 
            this.pnlMail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlMail.Controls.Add(this.btnCancel);
            this.pnlMail.Controls.Add(this.picboxEmailProgress);
            this.pnlMail.Controls.Add(this.btnSendEmail);
            this.pnlMail.Controls.Add(this.CBEmailBody);
            this.pnlMail.Controls.Add(this.GBemailHeader);
            this.pnlMail.Controls.Add(this.GroupBox1);
            this.pnlMail.Location = new System.Drawing.Point(120, 37);
            this.pnlMail.Name = "pnlMail";
            this.pnlMail.Size = new System.Drawing.Size(796, 658);
            this.pnlMail.TabIndex = 289;
            this.pnlMail.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(361, 629);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 24);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // picboxEmailProgress
            // 
            this.picboxEmailProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picboxEmailProgress.BackColor = System.Drawing.Color.Transparent;
            this.picboxEmailProgress.Image = global::JobTracker.Properties.Resources.UploadProcess;
            this.picboxEmailProgress.Location = new System.Drawing.Point(314, 594);
            this.picboxEmailProgress.Margin = new System.Windows.Forms.Padding(2);
            this.picboxEmailProgress.Name = "picboxEmailProgress";
            this.picboxEmailProgress.Size = new System.Drawing.Size(201, 31);
            this.picboxEmailProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxEmailProgress.TabIndex = 24;
            this.picboxEmailProgress.TabStop = false;
            this.picboxEmailProgress.Visible = false;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSendEmail.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSendEmail.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSendEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Location = new System.Drawing.Point(361, 594);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(89, 31);
            this.btnSendEmail.TabIndex = 23;
            this.btnSendEmail.Text = "Send";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // CBEmailBody
            // 
            this.CBEmailBody.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBEmailBody.BackColor = System.Drawing.Color.Transparent;
            this.CBEmailBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CBEmailBody.Controls.Add(this.btnAgingReport);
            this.CBEmailBody.Controls.Add(this.agingBrowser);
            this.CBEmailBody.Controls.Add(this.chkAttachAging);
            this.CBEmailBody.Controls.Add(this.txtEmailBody);
            this.CBEmailBody.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBEmailBody.Location = new System.Drawing.Point(54, 151);
            this.CBEmailBody.Margin = new System.Windows.Forms.Padding(2);
            this.CBEmailBody.Name = "CBEmailBody";
            this.CBEmailBody.Padding = new System.Windows.Forms.Padding(2);
            this.CBEmailBody.Size = new System.Drawing.Size(688, 300);
            this.CBEmailBody.TabIndex = 22;
            this.CBEmailBody.TabStop = false;
            this.CBEmailBody.Text = "Email Body";
            // 
            // btnAgingReport
            // 
            this.btnAgingReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgingReport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgingReport.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAgingReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAgingReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgingReport.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgingReport.Location = new System.Drawing.Point(419, 274);
            this.btnAgingReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgingReport.Name = "btnAgingReport";
            this.btnAgingReport.Size = new System.Drawing.Size(102, 24);
            this.btnAgingReport.TabIndex = 21;
            this.btnAgingReport.Text = "Show Aging Report";
            this.btnAgingReport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgingReport.UseVisualStyleBackColor = false;
            this.btnAgingReport.Click += new System.EventHandler(this.btnAgingReport_Click);
            // 
            // agingBrowser
            // 
            this.agingBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.agingBrowser.Location = new System.Drawing.Point(4, 22);
            this.agingBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.agingBrowser.MinimumSize = new System.Drawing.Size(15, 16);
            this.agingBrowser.Name = "agingBrowser";
            this.agingBrowser.Size = new System.Drawing.Size(676, 242);
            this.agingBrowser.TabIndex = 20;
            this.agingBrowser.Visible = false;
            // 
            // chkAttachAging
            // 
            this.chkAttachAging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAttachAging.AutoSize = true;
            this.chkAttachAging.Checked = true;
            this.chkAttachAging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAttachAging.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAttachAging.Location = new System.Drawing.Point(544, 277);
            this.chkAttachAging.Margin = new System.Windows.Forms.Padding(2);
            this.chkAttachAging.Name = "chkAttachAging";
            this.chkAttachAging.Size = new System.Drawing.Size(135, 18);
            this.chkAttachAging.TabIndex = 20;
            this.chkAttachAging.Text = "Attach Current Aging";
            this.chkAttachAging.UseVisualStyleBackColor = true;
            // 
            // txtEmailBody
            // 
            this.txtEmailBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmailBody.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtEmailBody.Location = new System.Drawing.Point(4, 22);
            this.txtEmailBody.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailBody.Multiline = true;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.Size = new System.Drawing.Size(680, 249);
            this.txtEmailBody.TabIndex = 2;
            // 
            // GBemailHeader
            // 
            this.GBemailHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GBemailHeader.BackColor = System.Drawing.Color.Transparent;
            this.GBemailHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GBemailHeader.Controls.Add(this.txtEmailSubject);
            this.GBemailHeader.Controls.Add(this.txtEmailTo);
            this.GBemailHeader.Controls.Add(this.Label4);
            this.GBemailHeader.Controls.Add(this.Label5);
            this.GBemailHeader.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GBemailHeader.Location = new System.Drawing.Point(149, 34);
            this.GBemailHeader.Margin = new System.Windows.Forms.Padding(2);
            this.GBemailHeader.Name = "GBemailHeader";
            this.GBemailHeader.Padding = new System.Windows.Forms.Padding(2);
            this.GBemailHeader.Size = new System.Drawing.Size(502, 107);
            this.GBemailHeader.TabIndex = 20;
            this.GBemailHeader.TabStop = false;
            this.GBemailHeader.Text = "Email Header";
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtEmailSubject.Location = new System.Drawing.Point(67, 64);
            this.txtEmailSubject.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(432, 23);
            this.txtEmailSubject.TabIndex = 3;
            // 
            // txtEmailTo
            // 
            this.txtEmailTo.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtEmailTo.Location = new System.Drawing.Point(67, 28);
            this.txtEmailTo.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailTo.Name = "txtEmailTo";
            this.txtEmailTo.Size = new System.Drawing.Size(432, 23);
            this.txtEmailTo.TabIndex = 2;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.Label4.Location = new System.Drawing.Point(12, 68);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(49, 17);
            this.Label4.TabIndex = 1;
            this.Label4.Text = "Subject";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.Label5.Location = new System.Drawing.Point(12, 28);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(21, 17);
            this.Label5.TabIndex = 0;
            this.Label5.Text = "To";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupBox1.Controls.Add(this.ckbAdd);
            this.GroupBox1.Controls.Add(this.grdAttachedfile);
            this.GroupBox1.Font = new System.Drawing.Font("Calibri", 9F);
            this.GroupBox1.Location = new System.Drawing.Point(102, 450);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox1.Size = new System.Drawing.Size(612, 125);
            this.GroupBox1.TabIndex = 21;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Attachment";
            // 
            // ckbAdd
            // 
            this.ckbAdd.AutoSize = true;
            this.ckbAdd.Location = new System.Drawing.Point(504, 20);
            this.ckbAdd.Name = "ckbAdd";
            this.ckbAdd.Size = new System.Drawing.Size(102, 18);
            this.ckbAdd.TabIndex = 20;
            this.ckbAdd.Text = "Attach Invoice";
            this.ckbAdd.UseVisualStyleBackColor = true;
            this.ckbAdd.CheckedChanged += new System.EventHandler(this.ckbAdd_CheckedChanged);
            // 
            // grdAttachedfile
            // 
            this.grdAttachedfile.AllowUserToAddRows = false;
            this.grdAttachedfile.AllowUserToDeleteRows = false;
            this.grdAttachedfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAttachedfile.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdAttachedfile.Location = new System.Drawing.Point(8, 18);
            this.grdAttachedfile.Margin = new System.Windows.Forms.Padding(2);
            this.grdAttachedfile.Name = "grdAttachedfile";
            this.grdAttachedfile.ReadOnly = true;
            this.grdAttachedfile.RowTemplate.Height = 24;
            this.grdAttachedfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdAttachedfile.Size = new System.Drawing.Size(490, 96);
            this.grdAttachedfile.TabIndex = 5;
            // 
            // backworkerEmailSender
            // 
            this.backworkerEmailSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backworkerEmailSender_DoWork);
            this.backworkerEmailSender.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backworkerEmailSender_RunWorkerCompleted);
            // 
            // frmAgingEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1063, 710);
            this.Controls.Add(this.parentTableControl);
            this.Controls.Add(this.pnlMail);
            this.Name = "frmAgingEmail";
            this.Text = "Aging Email";
            this.Load += new System.EventHandler(this.FrmAging_Load);
            this.pnlJobGrid.ResumeLayout(false);
            this.pnlJobGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompany)).EndInit();
            this.PnlUpdateAgind.ResumeLayout(false);
            this.pnlAgindFileBrowser.ResumeLayout(false);
            this.pnlAgindFileBrowser.PerformLayout();
            this.tblLayoutActionpnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceAction)).EndInit();
            this.pnlFileList.ResumeLayout(false);
            this.pnlFileList.PerformLayout();
            this.pnlTraficLight.ResumeLayout(false);
            this.pnlAgingInvoice.ResumeLayout(false);
            this.pnlAgingInvoice.PerformLayout();
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCommunicationLog)).EndInit();
            this.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAging)).EndInit();
            this.parentTableControl.ResumeLayout(false);
            this.tablepnlCompany.ResumeLayout(false);
            this.pnlMail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picboxEmailProgress)).EndInit();
            this.CBEmailBody.ResumeLayout(false);
            this.CBEmailBody.PerformLayout();
            this.GBemailHeader.ResumeLayout(false);
            this.GBemailHeader.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttachedfile)).EndInit();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.Panel pnlJobGrid;
        internal System.Windows.Forms.DataGridView grdCompany;
        internal System.Windows.Forms.Label lbClientAging;
        internal System.Windows.Forms.Panel PnlUpdateAgind;
        internal System.Windows.Forms.Button btnUpdateInvoiceDue;
        internal System.Windows.Forms.Button btnDueInvoiceCompany;
        internal System.Windows.Forms.Panel pnlAgindFileBrowser;
        internal Microsoft.VisualBasic.Compatibility.VB6.FileListBox InvoiceFileList;
        internal System.Windows.Forms.Button btnInvoicePermitsFileDownload;
        internal System.Windows.Forms.Panel pnlAgingInvoice;
        internal System.Windows.Forms.Panel pnlTraficLight;
        internal System.Windows.Forms.Button btnAgingColor;
        internal System.Windows.Forms.Label lbAginginvoice;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TableLayoutPanel parentTableControl;
        internal System.Windows.Forms.TableLayoutPanel tablepnlCompany;
        internal System.Windows.Forms.TextBox txtCompanySearch;
        internal System.Windows.Forms.Label lbSearch;
        internal System.Windows.Forms.CheckBox CkbPendingInvoice;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.DataGridView grdInvoiceAction;
        internal System.Windows.Forms.DataGridView grdCommunicationLog;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.CheckBox chkSelect;
        internal System.Windows.Forms.Button btnAddInvoiceAction;
        internal System.Windows.Forms.DataGridView grdAging;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn chkGrdSelect;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Button btnAddCommunication;
        internal System.Windows.Forms.Panel pnlMail;
        internal System.Windows.Forms.PictureBox picboxEmailProgress;
        internal System.Windows.Forms.Button btnSendEmail;
        internal System.Windows.Forms.GroupBox CBEmailBody;
        internal System.Windows.Forms.Button btnAgingReport;
        internal System.Windows.Forms.WebBrowser agingBrowser;
        internal System.Windows.Forms.CheckBox chkAttachAging;
        internal System.Windows.Forms.TextBox txtEmailBody;
        internal System.Windows.Forms.GroupBox GBemailHeader;
        internal System.Windows.Forms.TextBox txtEmailSubject;
        internal System.Windows.Forms.TextBox txtEmailTo;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.CheckBox ckbAdd;
        internal System.Windows.Forms.DataGridView grdAttachedfile;
        internal System.ComponentModel.BackgroundWorker backworkerEmailSender;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnSendmailAging;
        internal System.Windows.Forms.DataGridViewButtonColumn btnGrdUpdate;
        internal System.Windows.Forms.DataGridViewButtonColumn btnGrdDelete;
        internal System.Windows.Forms.DataGridViewComboBoxColumn cmbGrdAction;
        internal System.Windows.Forms.DataGridViewTextBoxColumn txtgrdActionDate;
        internal System.Windows.Forms.DataGridViewComboBoxColumn cmbGrdStatus;
        internal System.Windows.Forms.DataGridViewButtonColumn btnGrdUpdateComm;
        internal System.Windows.Forms.DataGridViewButtonColumn btnGrdDeleteComm;
        internal System.Windows.Forms.TextBox txtMethodSearch;
        internal System.Windows.Forms.TextBox txtInvoiceSearch;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.DateTimePicker dtpSearch;
        internal System.Windows.Forms.Panel pnlFileList;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TableLayoutPanel tblLayoutActionpnl;
        internal System.Windows.Forms.CheckBox chkActionStatusPending;
        internal System.Windows.Forms.TextBox txtCommLogNotes;
        internal System.Windows.Forms.Label Label9;

        #endregion
    }
}