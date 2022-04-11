namespace JobTracker.Application_Tool
{
    partial class FrmImportData
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
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.btnUpdateAgingColor = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.lblTotalREcord = new System.Windows.Forms.Label();
            this.txtAging = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtBalance = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdInvoiceDueData = new System.Windows.Forms.DataGridView();
            this.GrdDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSearch.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceDueData)).BeginInit();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearch
            // 
            this.pnlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.Controls.Add(this.btnUpdateAgingColor);
            this.pnlSearch.Controls.Add(this.txtCompanyName);
            this.pnlSearch.Controls.Add(this.Label4);
            this.pnlSearch.Controls.Add(this.lblTotalREcord);
            this.pnlSearch.Controls.Add(this.txtAging);
            this.pnlSearch.Controls.Add(this.Label3);
            this.pnlSearch.Controls.Add(this.txtBalance);
            this.pnlSearch.Controls.Add(this.Label2);
            this.pnlSearch.Controls.Add(this.txtInvoiceNo);
            this.pnlSearch.Controls.Add(this.Label1);
            this.pnlSearch.Location = new System.Drawing.Point(2, 2);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(623, 64);
            this.pnlSearch.TabIndex = 0;
            // 
            // btnUpdateAgingColor
            // 
            this.btnUpdateAgingColor.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdateAgingColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdateAgingColor.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdateAgingColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnUpdateAgingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateAgingColor.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.btnUpdateAgingColor.ForeColor = System.Drawing.Color.Navy;
            this.btnUpdateAgingColor.Location = new System.Drawing.Point(8, 35);
            this.btnUpdateAgingColor.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateAgingColor.Name = "btnUpdateAgingColor";
            this.btnUpdateAgingColor.Size = new System.Drawing.Size(92, 26);
            this.btnUpdateAgingColor.TabIndex = 18;
            this.btnUpdateAgingColor.Text = "Update Aging Color";
            this.btnUpdateAgingColor.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnUpdateAgingColor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateAgingColor.UseVisualStyleBackColor = false;
            this.btnUpdateAgingColor.Click += new System.EventHandler(this.btnUpdateAgingColor_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtCompanyName.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(481, 6);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(2);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(136, 22);
            this.txtCompanyName.TabIndex = 8;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(395, 10);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(91, 14);
            this.Label4.TabIndex = 7;
            this.Label4.Text = "Company Name";
            // 
            // lblTotalREcord
            // 
            this.lblTotalREcord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalREcord.AutoSize = true;
            this.lblTotalREcord.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalREcord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalREcord.Location = new System.Drawing.Point(549, 47);
            this.lblTotalREcord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalREcord.Name = "lblTotalREcord";
            this.lblTotalREcord.Size = new System.Drawing.Size(71, 14);
            this.lblTotalREcord.TabIndex = 6;
            this.lblTotalREcord.Text = "TotalRecord";
            // 
            // txtAging
            // 
            this.txtAging.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtAging.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAging.Location = new System.Drawing.Point(321, 7);
            this.txtAging.Margin = new System.Windows.Forms.Padding(2);
            this.txtAging.Name = "txtAging";
            this.txtAging.Size = new System.Drawing.Size(71, 22);
            this.txtAging.TabIndex = 5;
            this.txtAging.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(280, 9);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(37, 14);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Aging";
            // 
            // txtBalance
            // 
            this.txtBalance.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBalance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBalance.Location = new System.Drawing.Point(191, 8);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(2);
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.Size = new System.Drawing.Size(72, 22);
            this.txtBalance.TabIndex = 3;
            this.txtBalance.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(146, 11);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(51, 14);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Balance";
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtInvoiceNo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceNo.Location = new System.Drawing.Point(70, 8);
            this.txtInvoiceNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(66, 22);
            this.txtInvoiceNo.TabIndex = 1;
            this.txtInvoiceNo.TextChanged += new System.EventHandler(this.txtInvoiceNo_TextChanged);
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(3, 12);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(67, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Invoice No.";
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrid.Controls.Add(this.grdInvoiceDueData);
            this.pnlGrid.Location = new System.Drawing.Point(2, 70);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(2);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(623, 441);
            this.pnlGrid.TabIndex = 1;
            // 
            // grdInvoiceDueData
            // 
            this.grdInvoiceDueData.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdInvoiceDueData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdInvoiceDueData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdInvoiceDueData.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoiceDueData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdInvoiceDueData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInvoiceDueData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GrdDelete});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdInvoiceDueData.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdInvoiceDueData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInvoiceDueData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdInvoiceDueData.Location = new System.Drawing.Point(0, 0);
            this.grdInvoiceDueData.Margin = new System.Windows.Forms.Padding(2);
            this.grdInvoiceDueData.MultiSelect = false;
            this.grdInvoiceDueData.Name = "grdInvoiceDueData";
            this.grdInvoiceDueData.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdInvoiceDueData.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdInvoiceDueData.RowTemplate.Height = 24;
            this.grdInvoiceDueData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.grdInvoiceDueData.Size = new System.Drawing.Size(623, 441);
            this.grdInvoiceDueData.TabIndex = 285;
            this.grdInvoiceDueData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdInvoiceDueData_CellClick);
            this.grdInvoiceDueData.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdInvoiceDueData_CellFormatting);
            // 
            // GrdDelete
            // 
            this.GrdDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.GrdDelete.Frozen = true;
            this.GrdDelete.HeaderText = "X";
            this.GrdDelete.Name = "GrdDelete";
            this.GrdDelete.ReadOnly = true;
            this.GrdDelete.Text = "X";
            this.GrdDelete.ToolTipText = "Delete";
            this.GrdDelete.UseColumnTextForButtonValue = true;
            this.GrdDelete.Width = 30;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Controls.Add(this.pnlSearch, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.pnlGrid, 0, 1);
            this.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.TableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 2;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(627, 513);
            this.TableLayoutPanel1.TabIndex = 2;
            // 
            // FrmImportData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JobTracker.Properties.Resources.FrmBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(627, 513);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmImportData";
            this.Text = "Import Invoice Data";
            this.Load += new System.EventHandler(this.FrmImportData_Load);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInvoiceDueData)).EndInit();
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel pnlSearch;
        internal System.Windows.Forms.Panel pnlGrid;
        internal System.Windows.Forms.DataGridView grdInvoiceDueData;
        internal System.Windows.Forms.TextBox txtBalance;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtInvoiceNo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtAging;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        internal System.Windows.Forms.Label lblTotalREcord;
        internal System.Windows.Forms.TextBox txtCompanyName;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.DataGridViewButtonColumn GrdDelete;
        internal System.Windows.Forms.Button btnUpdateAgingColor;
        #endregion
    }
}