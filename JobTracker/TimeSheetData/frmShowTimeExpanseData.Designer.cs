namespace JobTracker.TimeSheetData
{
    partial class frmShowTimeExpanseData
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
            this.grdShowTimeData = new System.Windows.Forms.DataGridView();
            this.grdUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlShowTimeData = new System.Windows.Forms.Panel();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowTimeData)).BeginInit();
            this.pnlShowTimeData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdShowTimeData
            // 
            this.grdShowTimeData.AllowUserToAddRows = false;
            this.grdShowTimeData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdShowTimeData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdShowTimeData.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdShowTimeData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdShowTimeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdShowTimeData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdUpdate});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdShowTimeData.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdShowTimeData.Location = new System.Drawing.Point(0, 25);
            this.grdShowTimeData.Margin = new System.Windows.Forms.Padding(2);
            this.grdShowTimeData.MultiSelect = false;
            this.grdShowTimeData.Name = "grdShowTimeData";
            this.grdShowTimeData.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdShowTimeData.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdShowTimeData.RowTemplate.Height = 24;
            this.grdShowTimeData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdShowTimeData.Size = new System.Drawing.Size(445, 235);
            this.grdShowTimeData.TabIndex = 197;
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
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Brown;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.Control;
            this.btnClose.Location = new System.Drawing.Point(422, 2);
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
            this.pnlShowTimeData.Controls.Add(this.lblTotalHours);
            this.pnlShowTimeData.Controls.Add(this.btnCancel);
            this.pnlShowTimeData.Controls.Add(this.btnClose);
            this.pnlShowTimeData.Controls.Add(this.grdShowTimeData);
            this.pnlShowTimeData.Controls.Add(this.btnAdd);
            this.pnlShowTimeData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShowTimeData.Location = new System.Drawing.Point(0, 0);
            this.pnlShowTimeData.Name = "pnlShowTimeData";
            this.pnlShowTimeData.Size = new System.Drawing.Size(447, 262);
            this.pnlShowTimeData.TabIndex = 0;
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.Location = new System.Drawing.Point(286, 7);
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
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 23);
            this.btnCancel.TabIndex = 241;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
            // 
            // frmShowTimeExpanseData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 262);
            this.Controls.Add(this.pnlShowTimeData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowTimeExpanseData";
            this.Text = "frmShowTimeData";
            this.Load += new System.EventHandler(this.frmShowTimeData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdShowTimeData)).EndInit();
            this.pnlShowTimeData.ResumeLayout(false);
            this.pnlShowTimeData.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.DataGridView grdShowTimeData;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Panel pnlShowTimeData;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.Label lblTotalHours;
        internal System.Windows.Forms.DataGridViewButtonColumn grdUpdate;
        #endregion
    }
}