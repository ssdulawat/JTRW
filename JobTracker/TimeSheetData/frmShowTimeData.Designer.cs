namespace JobTracker.TimeSheetData
{
    partial class frmShowTimeData
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
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlShowTimeData = new System.Windows.Forms.Panel();
            this.lblRevenue = new System.Windows.Forms.Label();
            this.lblVecost = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();
            this.chkGroupBy = new System.Windows.Forms.CheckBox();
            this.cmbDistinctName = new System.Windows.Forms.ComboBox();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grdShowTimeData = new System.Windows.Forms.DataGridView();
            this.grdUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlShowTimeData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowTimeData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Brown;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(627, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(21, 23);
            this.btnClose.TabIndex = 239;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlShowTimeData
            // 
            this.pnlShowTimeData.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlShowTimeData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShowTimeData.Controls.Add(this.lblRevenue);
            this.pnlShowTimeData.Controls.Add(this.lblVecost);
            this.pnlShowTimeData.Controls.Add(this.lblSearch);
            this.pnlShowTimeData.Controls.Add(this.chkGroupBy);
            this.pnlShowTimeData.Controls.Add(this.cmbDistinctName);
            this.pnlShowTimeData.Controls.Add(this.lblTotalHours);
            this.pnlShowTimeData.Controls.Add(this.btnCancel);
            this.pnlShowTimeData.Controls.Add(this.btnClose);
            this.pnlShowTimeData.Controls.Add(this.grdShowTimeData);
            this.pnlShowTimeData.Controls.Add(this.btnAdd);
            this.pnlShowTimeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShowTimeData.Location = new System.Drawing.Point(0, 0);
            this.pnlShowTimeData.Name = "pnlShowTimeData";
            this.pnlShowTimeData.Size = new System.Drawing.Size(652, 262);
            this.pnlShowTimeData.TabIndex = 0;
            // 
            // lblRevenue
            // 
            this.lblRevenue.AutoSize = true;
            this.lblRevenue.Location = new System.Drawing.Point(499, 7);
            this.lblRevenue.Name = "lblRevenue";
            this.lblRevenue.Size = new System.Drawing.Size(60, 13);
            this.lblRevenue.TabIndex = 248;
            this.lblRevenue.Text = "Revenue :-";
            // 
            // lblVecost
            // 
            this.lblVecost.AutoSize = true;
            this.lblVecost.Location = new System.Drawing.Point(389, 7);
            this.lblVecost.Name = "lblVecost";
            this.lblVecost.Size = new System.Drawing.Size(54, 13);
            this.lblVecost.TabIndex = 247;
            this.lblVecost.Text = "VE Cost :-";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(60, 6);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(44, 13);
            this.lblSearch.TabIndex = 246;
            this.lblSearch.Text = "Search:";
            // 
            // chkGroupBy
            // 
            this.chkGroupBy.AutoSize = true;
            this.chkGroupBy.Checked = true;
            this.chkGroupBy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGroupBy.Location = new System.Drawing.Point(181, 5);
            this.chkGroupBy.Name = "chkGroupBy";
            this.chkGroupBy.Size = new System.Drawing.Size(69, 17);
            this.chkGroupBy.TabIndex = 245;
            this.chkGroupBy.Text = "Group by";
            this.chkGroupBy.UseVisualStyleBackColor = true;
            this.chkGroupBy.CheckedChanged += new System.EventHandler(this.chkGroupBy_CheckedChanged);
            // 
            // cmbDistinctName
            // 
            this.cmbDistinctName.FormattingEnabled = true;
            this.cmbDistinctName.Location = new System.Drawing.Point(106, 3);
            this.cmbDistinctName.Name = "cmbDistinctName";
            this.cmbDistinctName.Size = new System.Drawing.Size(70, 21);
            this.cmbDistinctName.TabIndex = 244;
            this.cmbDistinctName.SelectedIndexChanged += new System.EventHandler(this.cmbDistinctName_SelectedIndexChanged);
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(267, 7);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(57, 13);
            this.lblTotalHours.TabIndex = 243;
            this.lblTotalHours.Text = "Total Time";
            this.lblTotalHours.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(3, 2);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 23);
            this.btnCancel.TabIndex = 241;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grdShowTimeData
            // 
            this.grdShowTimeData.AllowUserToAddRows = false;
            this.grdShowTimeData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdShowTimeData.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdShowTimeData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdShowTimeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShowTimeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdUpdate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdShowTimeData.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdShowTimeData.Location = new System.Drawing.Point(0, 25);
            this.grdShowTimeData.Margin = new System.Windows.Forms.Padding(2);
            this.grdShowTimeData.MultiSelect = false;
            this.grdShowTimeData.Name = "grdShowTimeData";
            this.grdShowTimeData.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdShowTimeData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdShowTimeData.RowTemplate.Height = 24;
            this.grdShowTimeData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.grdShowTimeData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdShowTimeData.Size = new System.Drawing.Size(650, 233);
            this.grdShowTimeData.TabIndex = 197;
            this.grdShowTimeData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdShowTimeData_CellClick);
            // 
            // grdUpdate
            // 
            this.grdUpdate.HeaderText = "^";
            this.grdUpdate.Name = "grdUpdate";
            this.grdUpdate.ReadOnly = true;
            this.grdUpdate.Text = "^";
            this.grdUpdate.UseColumnTextForButtonValue = true;
            this.grdUpdate.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(64, 41);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(41, 23);
            this.btnAdd.TabIndex = 240;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmShowTimeData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(652, 262);
            this.Controls.Add(this.pnlShowTimeData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowTimeData";
            this.Text = "frmShowTimeData";
            this.Load += new System.EventHandler(this.frmShowTimeData_Load);
            this.pnlShowTimeData.ResumeLayout(false);
            this.pnlShowTimeData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowTimeData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlShowTimeData;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Label lblTotalHours;
        internal System.Windows.Forms.CheckBox chkGroupBy;
        internal System.Windows.Forms.ComboBox cmbDistinctName;
        internal System.Windows.Forms.Label lblSearch;
        internal System.Windows.Forms.Label lblVecost;
        internal System.Windows.Forms.Label lblRevenue;
        internal System.Windows.Forms.DataGridView grdShowTimeData;
        internal System.Windows.Forms.DataGridViewButtonColumn grdUpdate;
    }
}