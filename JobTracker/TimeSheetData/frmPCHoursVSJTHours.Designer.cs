namespace JobTracker.TimeSheetData
{
    partial class frmPCHoursVSJTHours
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlPCvsJT = new System.Windows.Forms.Panel();
            this.btnExportexcelSheet = new System.Windows.Forms.Button();
            this.lbltotalpunchedHrs = new System.Windows.Forms.Label();
            this.gbPCvsJT = new System.Windows.Forms.GroupBox();
            this.cmbUserSearchPCvsJT = new System.Windows.Forms.ComboBox();
            this.gbDateUserSearch = new System.Windows.Forms.GroupBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpDateSearchTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateSearchFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPM = new System.Windows.Forms.Label();
            this.ckbPCvsJT = new System.Windows.Forms.CheckBox();
            this.grdPCvsJT = new System.Windows.Forms.DataGridView();
            this.pnlPCvsJT.SuspendLayout();
            this.gbPCvsJT.SuspendLayout();
            this.gbDateUserSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPCvsJT)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPCvsJT
            // 
            this.pnlPCvsJT.Controls.Add(this.btnExportexcelSheet);
            this.pnlPCvsJT.Controls.Add(this.lbltotalpunchedHrs);
            this.pnlPCvsJT.Controls.Add(this.gbPCvsJT);
            this.pnlPCvsJT.Controls.Add(this.grdPCvsJT);
            this.pnlPCvsJT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPCvsJT.Location = new System.Drawing.Point(0, 0);
            this.pnlPCvsJT.Name = "pnlPCvsJT";
            this.pnlPCvsJT.Size = new System.Drawing.Size(549, 401);
            this.pnlPCvsJT.TabIndex = 0;
            // 
            // btnExportexcelSheet
            // 
            this.btnExportexcelSheet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportexcelSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportexcelSheet.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportexcelSheet.ForeColor = System.Drawing.Color.Maroon;
            this.btnExportexcelSheet.Location = new System.Drawing.Point(10, 6);
            this.btnExportexcelSheet.Name = "btnExportexcelSheet";
            this.btnExportexcelSheet.Size = new System.Drawing.Size(107, 25);
            this.btnExportexcelSheet.TabIndex = 309;
            this.btnExportexcelSheet.Text = " Export Excel";
            this.btnExportexcelSheet.UseVisualStyleBackColor = true;
            this.btnExportexcelSheet.Click += new System.EventHandler(this.btnExportexcelSheet_Click);
            // 
            // lbltotalpunchedHrs
            // 
            this.lbltotalpunchedHrs.AutoSize = true;
            this.lbltotalpunchedHrs.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalpunchedHrs.ForeColor = System.Drawing.Color.DarkRed;
            this.lbltotalpunchedHrs.Location = new System.Drawing.Point(413, 13);
            this.lbltotalpunchedHrs.Name = "lbltotalpunchedHrs";
            this.lbltotalpunchedHrs.Size = new System.Drawing.Size(91, 13);
            this.lbltotalpunchedHrs.TabIndex = 310;
            this.lbltotalpunchedHrs.Text = "Total Punched Hrs";
            // 
            // gbPCvsJT
            // 
            this.gbPCvsJT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPCvsJT.Controls.Add(this.cmbUserSearchPCvsJT);
            this.gbPCvsJT.Controls.Add(this.gbDateUserSearch);
            this.gbPCvsJT.Controls.Add(this.lblPM);
            this.gbPCvsJT.Controls.Add(this.ckbPCvsJT);
            this.gbPCvsJT.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPCvsJT.ForeColor = System.Drawing.Color.Maroon;
            this.gbPCvsJT.Location = new System.Drawing.Point(156, 3);
            this.gbPCvsJT.Name = "gbPCvsJT";
            this.gbPCvsJT.Size = new System.Drawing.Size(208, 21);
            this.gbPCvsJT.TabIndex = 307;
            this.gbPCvsJT.TabStop = false;
            this.gbPCvsJT.Visible = false;
            // 
            // cmbUserSearchPCvsJT
            // 
            this.cmbUserSearchPCvsJT.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cmbUserSearchPCvsJT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUserSearchPCvsJT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbUserSearchPCvsJT.Location = new System.Drawing.Point(156, 18);
            this.cmbUserSearchPCvsJT.Margin = new System.Windows.Forms.Padding(2);
            this.cmbUserSearchPCvsJT.Name = "cmbUserSearchPCvsJT";
            this.cmbUserSearchPCvsJT.Size = new System.Drawing.Size(58, 22);
            this.cmbUserSearchPCvsJT.TabIndex = 307;
            this.cmbUserSearchPCvsJT.Visible = false;
            this.cmbUserSearchPCvsJT.SelectedIndexChanged += new System.EventHandler(this.cmbUserSearchPCvsJT_SelectedIndexChanged);
            // 
            // gbDateUserSearch
            // 
            this.gbDateUserSearch.Controls.Add(this.lblTo);
            this.gbDateUserSearch.Controls.Add(this.lblFrom);
            this.gbDateUserSearch.Controls.Add(this.dtpDateSearchTo);
            this.gbDateUserSearch.Controls.Add(this.dtpDateSearchFrom);
            this.gbDateUserSearch.Location = new System.Drawing.Point(243, 10);
            this.gbDateUserSearch.Name = "gbDateUserSearch";
            this.gbDateUserSearch.Size = new System.Drawing.Size(107, 21);
            this.gbDateUserSearch.TabIndex = 306;
            this.gbDateUserSearch.TabStop = false;
            this.gbDateUserSearch.Visible = false;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.BackColor = System.Drawing.Color.Transparent;
            this.lblTo.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTo.Location = new System.Drawing.Point(128, 18);
            this.lblTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(17, 13);
            this.lblTo.TabIndex = 303;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.BackColor = System.Drawing.Color.Transparent;
            this.lblFrom.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFrom.Location = new System.Drawing.Point(1, 17);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(31, 13);
            this.lblFrom.TabIndex = 291;
            this.lblFrom.Text = "From";
            // 
            // dtpDateSearchTo
            // 
            this.dtpDateSearchTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSearchTo.Location = new System.Drawing.Point(152, 14);
            this.dtpDateSearchTo.Name = "dtpDateSearchTo";
            this.dtpDateSearchTo.Size = new System.Drawing.Size(82, 22);
            this.dtpDateSearchTo.TabIndex = 1;
            // 
            // dtpDateSearchFrom
            // 
            this.dtpDateSearchFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateSearchFrom.Location = new System.Drawing.Point(36, 14);
            this.dtpDateSearchFrom.Name = "dtpDateSearchFrom";
            this.dtpDateSearchFrom.Size = new System.Drawing.Size(87, 22);
            this.dtpDateSearchFrom.TabIndex = 0;
            // 
            // lblPM
            // 
            this.lblPM.AutoSize = true;
            this.lblPM.BackColor = System.Drawing.Color.Transparent;
            this.lblPM.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPM.Location = new System.Drawing.Point(123, 22);
            this.lblPM.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPM.Name = "lblPM";
            this.lblPM.Size = new System.Drawing.Size(32, 14);
            this.lblPM.TabIndex = 304;
            this.lblPM.Text = "User";
            this.lblPM.Visible = false;
            // 
            // ckbPCvsJT
            // 
            this.ckbPCvsJT.AutoSize = true;
            this.ckbPCvsJT.Location = new System.Drawing.Point(224, 17);
            this.ckbPCvsJT.Name = "ckbPCvsJT";
            this.ckbPCvsJT.Size = new System.Drawing.Size(15, 14);
            this.ckbPCvsJT.TabIndex = 305;
            this.ckbPCvsJT.UseVisualStyleBackColor = true;
            this.ckbPCvsJT.Visible = false;
            // 
            // grdPCvsJT
            // 
            this.grdPCvsJT.AllowUserToAddRows = false;
            this.grdPCvsJT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPCvsJT.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPCvsJT.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdPCvsJT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPCvsJT.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdPCvsJT.Location = new System.Drawing.Point(2, 35);
            this.grdPCvsJT.Margin = new System.Windows.Forms.Padding(2);
            this.grdPCvsJT.MultiSelect = false;
            this.grdPCvsJT.Name = "grdPCvsJT";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPCvsJT.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdPCvsJT.RowTemplate.Height = 24;
            this.grdPCvsJT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPCvsJT.Size = new System.Drawing.Size(544, 360);
            this.grdPCvsJT.TabIndex = 198;
            // 
            // frmPCHoursVSJTHours
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 401);
            this.Controls.Add(this.pnlPCvsJT);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPCHoursVSJTHours";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punched Hours";
            this.Load += new System.EventHandler(this.frmPCHoursVSJTHours_Load);
            this.pnlPCvsJT.ResumeLayout(false);
            this.pnlPCvsJT.PerformLayout();
            this.gbPCvsJT.ResumeLayout(false);
            this.gbPCvsJT.PerformLayout();
            this.gbDateUserSearch.ResumeLayout(false);
            this.gbDateUserSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPCvsJT)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel pnlPCvsJT;
        internal System.Windows.Forms.DataGridView grdPCvsJT;
        internal System.Windows.Forms.GroupBox gbPCvsJT;
        internal System.Windows.Forms.ComboBox cmbUserSearchPCvsJT;
        internal System.Windows.Forms.GroupBox gbDateUserSearch;
        internal System.Windows.Forms.Label lblTo;
        internal System.Windows.Forms.Label lblFrom;
        internal System.Windows.Forms.DateTimePicker dtpDateSearchTo;
        internal System.Windows.Forms.DateTimePicker dtpDateSearchFrom;
        internal System.Windows.Forms.Label lblPM;
        internal System.Windows.Forms.CheckBox ckbPCvsJT;
        internal System.Windows.Forms.Button btnExportexcelSheet;
        internal System.Windows.Forms.Label lbltotalpunchedHrs;
        #endregion
    }
}