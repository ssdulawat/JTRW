using Microsoft.VisualBasic.CompilerServices;
using System;

namespace JobTracker.InvoiceReport
{
    partial class frmInvoiceTool
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grdInvoice = new System.Windows.Forms.DataGridView();
            this.JobNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VeCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Revienu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Difference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.gbAddedDate = new System.Windows.Forms.GroupBox();
            this.chkDateAdd = new System.Windows.Forms.CheckBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpDateSearchFrom = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpDateSearchTo = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnTrackSetCancel = new System.Windows.Forms.Button();
            this.txtPM = new System.Windows.Forms.ComboBox();
            this.lblPm = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.txtInvoiceNO = new System.Windows.Forms.TextBox();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.lblRevienue = new System.Windows.Forms.Label();
            this.lblDifference = new System.Windows.Forms.Label();
            this.lblTotalVeCost = new System.Windows.Forms.Label();
            this.TableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoice)).BeginInit();
            this.Panel1.SuspendLayout();
            this.gbAddedDate.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.grdInvoice, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel1, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.Panel2, 0, 2);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(1182, 368);
            this.TableLayoutPanel1.TabIndex = 0;
            // 
            // grdInvoice
            // 
            this.grdInvoice.AllowUserToAddRows = false;
            this.grdInvoice.AllowUserToDeleteRows = false;
            this.grdInvoice.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoice.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdInvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JobNo,
            this.InvoiceNo,
            this.InvoiceDate,
            this.AddedDate,
            this.PM,
            this.VeCost,
            this.Revienu,
            this.Difference,
            this.Column1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoice.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdInvoice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInvoice.Location = new System.Drawing.Point(3, 63);
            this.grdInvoice.Name = "grdInvoice";
            this.grdInvoice.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoice.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdInvoice.Size = new System.Drawing.Size(1176, 252);
            this.grdInvoice.TabIndex = 0;
            this.grdInvoice.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoice_CellContentClick);
            this.grdInvoice.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdInvoice_CellFormatting);
            // 
            // JobNo
            // 
            this.JobNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.JobNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.JobNo.FillWeight = 157.5354F;
            this.JobNo.Frozen = true;
            this.JobNo.HeaderText = "Job#";
            this.JobNo.MinimumWidth = 125;
            this.JobNo.Name = "JobNo";
            this.JobNo.ReadOnly = true;
            this.JobNo.Width = 125;
            // 
            // InvoiceNo
            // 
            this.InvoiceNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.InvoiceNo.Frozen = true;
            this.InvoiceNo.HeaderText = "Invoice#";
            this.InvoiceNo.MinimumWidth = 125;
            this.InvoiceNo.Name = "InvoiceNo";
            this.InvoiceNo.ReadOnly = true;
            this.InvoiceNo.Width = 125;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.InvoiceDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.InvoiceDate.Frozen = true;
            this.InvoiceDate.HeaderText = "Invoice Date";
            this.InvoiceDate.MinimumWidth = 150;
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 150;
            // 
            // AddedDate
            // 
            this.AddedDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AddedDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.AddedDate.Frozen = true;
            this.AddedDate.HeaderText = "Added Date";
            this.AddedDate.MinimumWidth = 125;
            this.AddedDate.Name = "AddedDate";
            this.AddedDate.ReadOnly = true;
            this.AddedDate.Width = 125;
            // 
            // PM
            // 
            this.PM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PM.FillWeight = 9.452128F;
            this.PM.Frozen = true;
            this.PM.HeaderText = "PM";
            this.PM.MinimumWidth = 100;
            this.PM.Name = "PM";
            this.PM.ReadOnly = true;
            // 
            // VeCost
            // 
            this.VeCost.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VeCost.DefaultCellStyle = dataGridViewCellStyle5;
            this.VeCost.FillWeight = 7.876773F;
            this.VeCost.Frozen = true;
            this.VeCost.HeaderText = "Ve Cost";
            this.VeCost.MinimumWidth = 150;
            this.VeCost.Name = "VeCost";
            this.VeCost.ReadOnly = true;
            this.VeCost.Width = 150;
            // 
            // Revienu
            // 
            this.Revienu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Revienu.DefaultCellStyle = dataGridViewCellStyle6;
            this.Revienu.FillWeight = 7.876773F;
            this.Revienu.Frozen = true;
            this.Revienu.HeaderText = "Revenue";
            this.Revienu.MinimumWidth = 150;
            this.Revienu.Name = "Revienu";
            this.Revienu.ReadOnly = true;
            this.Revienu.Width = 150;
            // 
            // Difference
            // 
            this.Difference.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Difference.DefaultCellStyle = dataGridViewCellStyle7;
            this.Difference.FillWeight = 317.2589F;
            this.Difference.Frozen = true;
            this.Difference.HeaderText = "Difference";
            this.Difference.MinimumWidth = 150;
            this.Difference.Name = "Difference";
            this.Difference.ReadOnly = true;
            this.Difference.Width = 150;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.gbAddedDate);
            this.Panel1.Controls.Add(this.btnSearch);
            this.Panel1.Controls.Add(this.btnRefresh);
            this.Panel1.Controls.Add(this.btnTrackSetCancel);
            this.Panel1.Controls.Add(this.txtPM);
            this.Panel1.Controls.Add(this.lblPm);
            this.Panel1.Controls.Add(this.Label1);
            this.Panel1.Controls.Add(this.lblJobNo);
            this.Panel1.Controls.Add(this.txtInvoiceNO);
            this.Panel1.Controls.Add(this.txtJobNo);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(3, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(1176, 54);
            this.Panel1.TabIndex = 1;
            // 
            // gbAddedDate
            // 
            this.gbAddedDate.Controls.Add(this.chkDateAdd);
            this.gbAddedDate.Controls.Add(this.lblFrom);
            this.gbAddedDate.Controls.Add(this.dtpDateSearchFrom);
            this.gbAddedDate.Controls.Add(this.lblTo);
            this.gbAddedDate.Controls.Add(this.dtpDateSearchTo);
            this.gbAddedDate.Location = new System.Drawing.Point(518, 3);
            this.gbAddedDate.Name = "gbAddedDate";
            this.gbAddedDate.Size = new System.Drawing.Size(353, 45);
            this.gbAddedDate.TabIndex = 308;
            this.gbAddedDate.TabStop = false;
            this.gbAddedDate.Text = "Job Added Date Search";
            // 
            // chkDateAdd
            // 
            this.chkDateAdd.AutoSize = true;
            this.chkDateAdd.Location = new System.Drawing.Point(8, 16);
            this.chkDateAdd.Name = "chkDateAdd";
            this.chkDateAdd.Size = new System.Drawing.Size(83, 17);
            this.chkDateAdd.TabIndex = 309;
            this.chkDateAdd.Text = "Added Date";
            this.chkDateAdd.UseVisualStyleBackColor = true;
            this.chkDateAdd.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFrom.Location = new System.Drawing.Point(94, 18);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 291;
            this.lblFrom.Text = "From";
            // 
            // dtpDateSearchFrom
            // 
            this.dtpDateSearchFrom.Enabled = false;
            this.dtpDateSearchFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSearchFrom.Location = new System.Drawing.Point(130, 16);
            this.dtpDateSearchFrom.Name = "dtpDateSearchFrom";
            this.dtpDateSearchFrom.Size = new System.Drawing.Size(98, 20);
            this.dtpDateSearchFrom.TabIndex = 0;
            this.dtpDateSearchFrom.Value = new System.DateTime(2016, 3, 20, 0, 0, 0, 0);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTo.Location = new System.Drawing.Point(233, 18);
            this.lblTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 303;
            this.lblTo.Text = "To";
            // 
            // dtpDateSearchTo
            // 
            this.dtpDateSearchTo.Enabled = false;
            this.dtpDateSearchTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSearchTo.Location = new System.Drawing.Point(263, 16);
            this.dtpDateSearchTo.Name = "dtpDateSearchTo";
            this.dtpDateSearchTo.Size = new System.Drawing.Size(82, 20);
            this.dtpDateSearchTo.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSearch.Location = new System.Drawing.Point(893, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(81, 32);
            this.btnSearch.TabIndex = 307;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRefresh.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRefresh.Image = global::JobTracker.Properties.Resources.refresh;
            this.btnRefresh.Location = new System.Drawing.Point(1067, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(93, 31);
            this.btnRefresh.TabIndex = 306;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnTrackSetCancel
            // 
            this.btnTrackSetCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTrackSetCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnTrackSetCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnTrackSetCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnTrackSetCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrackSetCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrackSetCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnTrackSetCancel.Location = new System.Drawing.Point(980, 13);
            this.btnTrackSetCancel.Name = "btnTrackSetCancel";
            this.btnTrackSetCancel.Size = new System.Drawing.Size(81, 32);
            this.btnTrackSetCancel.TabIndex = 305;
            this.btnTrackSetCancel.Text = "Clear";
            this.btnTrackSetCancel.UseVisualStyleBackColor = false;
            this.btnTrackSetCancel.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // txtPM
            // 
            this.txtPM.FormattingEnabled = true;
            this.txtPM.Location = new System.Drawing.Point(417, 20);
            this.txtPM.Name = "txtPM";
            this.txtPM.Size = new System.Drawing.Size(76, 21);
            this.txtPM.TabIndex = 243;
            this.txtPM.SelectedIndexChanged += new System.EventHandler(this.txtPM_SelectedIndexChanged);
            // 
            // lblPm
            // 
            this.lblPm.AutoSize = true;
            this.lblPm.Location = new System.Drawing.Point(388, 23);
            this.lblPm.Name = "lblPm";
            this.lblPm.Size = new System.Drawing.Size(23, 13);
            this.lblPm.TabIndex = 1;
            this.lblPm.Text = "PM";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(190, 23);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(49, 13);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Invoice#";
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Location = new System.Drawing.Point(9, 23);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(31, 13);
            this.lblJobNo.TabIndex = 1;
            this.lblJobNo.Text = "Job#";
            // 
            // txtInvoiceNO
            // 
            this.txtInvoiceNO.Location = new System.Drawing.Point(248, 20);
            this.txtInvoiceNO.Name = "txtInvoiceNO";
            this.txtInvoiceNO.Size = new System.Drawing.Size(125, 20);
            this.txtInvoiceNO.TabIndex = 0;
            this.txtInvoiceNO.TextChanged += new System.EventHandler(this.txtJobNo_TextChanged);
            // 
            // txtJobNo
            // 
            this.txtJobNo.Location = new System.Drawing.Point(53, 20);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.Size = new System.Drawing.Size(125, 20);
            this.txtJobNo.TabIndex = 0;
            this.txtJobNo.TextChanged += new System.EventHandler(this.txtJobNo_TextChanged);
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.lblRevienue);
            this.Panel2.Controls.Add(this.lblDifference);
            this.Panel2.Controls.Add(this.lblTotalVeCost);
            this.Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel2.Location = new System.Drawing.Point(3, 321);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(1176, 44);
            this.Panel2.TabIndex = 2;
            // 
            // lblRevienue
            // 
            this.lblRevienue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRevienue.AutoSize = true;
            this.lblRevienue.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRevienue.Location = new System.Drawing.Point(208, 8);
            this.lblRevienue.Name = "lblRevienue";
            this.lblRevienue.Size = new System.Drawing.Size(76, 19);
            this.lblRevienue.TabIndex = 4;
            this.lblRevienue.Text = "Revenue :";
            // 
            // lblDifference
            // 
            this.lblDifference.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDifference.AutoSize = true;
            this.lblDifference.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifference.Location = new System.Drawing.Point(417, 7);
            this.lblDifference.Name = "lblDifference";
            this.lblDifference.Size = new System.Drawing.Size(87, 19);
            this.lblDifference.TabIndex = 3;
            this.lblDifference.Text = "Difference :";
            // 
            // lblTotalVeCost
            // 
            this.lblTotalVeCost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalVeCost.AutoSize = true;
            this.lblTotalVeCost.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalVeCost.Location = new System.Drawing.Point(20, 9);
            this.lblTotalVeCost.Name = "lblTotalVeCost";
            this.lblTotalVeCost.Size = new System.Drawing.Size(62, 19);
            this.lblTotalVeCost.TabIndex = 2;
            this.lblTotalVeCost.Text = "VeCost :";
            // 
            // frmInvoiceTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 368);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmInvoiceTool";
            this.Text = "Revenue Search";
            this.Load += new System.EventHandler(this.frmInvoiceTool_Load);
            this.TableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoice)).EndInit();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.gbAddedDate.ResumeLayout(false);
            this.gbAddedDate.PerformLayout();
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.DataGridView grdInvoice;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TextBox txtJobNo;
        internal System.Windows.Forms.Label lblPm;
        internal System.Windows.Forms.Label lblJobNo;
        internal System.Windows.Forms.Panel Panel2;
        internal System.Windows.Forms.Label lblRevienue;
        internal System.Windows.Forms.Label lblDifference;
        internal System.Windows.Forms.Label lblTotalVeCost;
        internal System.Windows.Forms.ComboBox txtPM;
        internal System.Windows.Forms.Label lblTo;
        internal System.Windows.Forms.Label lblFrom;
        internal System.Windows.Forms.DateTimePicker dtpDateSearchTo;
        internal System.Windows.Forms.DateTimePicker dtpDateSearchFrom;
        internal System.Windows.Forms.Button btnRefresh;
        internal System.Windows.Forms.Button btnTrackSetCancel;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtInvoiceNO;
        internal System.Windows.Forms.Button btnSearch;
        internal System.Windows.Forms.DataGridViewTextBoxColumn JobNo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn InvoiceNo;
        internal System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn AddedDate;
        internal System.Windows.Forms.DataGridViewTextBoxColumn PM;
        internal System.Windows.Forms.DataGridViewTextBoxColumn VeCost;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Revienu;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Difference;
        internal System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        internal System.Windows.Forms.GroupBox gbAddedDate;
        internal System.Windows.Forms.CheckBox chkDateAdd;

        #endregion
    }
}