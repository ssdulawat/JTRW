namespace JobTracker.PDFeditTools
{
    partial class frmApplicant
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grdApplicantInfo = new System.Windows.Forms.DataGridView();
            this.UpdategrdBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.DeletegrdBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdApplicantInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(70, 27);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 24);
            this.btnCancel.TabIndex = 212;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAdd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAdd.Location = new System.Drawing.Point(11, 27);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(55, 24);
            this.btnAdd.TabIndex = 211;
            this.btnAdd.Text = "Insert";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdApplicantInfo
            // 
            this.grdApplicantInfo.AllowUserToAddRows = false;
            this.grdApplicantInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdApplicantInfo.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdApplicantInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdApplicantInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdApplicantInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UpdategrdBtn,
            this.DeletegrdBtn});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdApplicantInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdApplicantInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdApplicantInfo.Location = new System.Drawing.Point(2, 55);
            this.grdApplicantInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grdApplicantInfo.MultiSelect = false;
            this.grdApplicantInfo.Name = "grdApplicantInfo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdApplicantInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdApplicantInfo.RowTemplate.Height = 24;
            this.grdApplicantInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdApplicantInfo.Size = new System.Drawing.Size(768, 409);
            this.grdApplicantInfo.TabIndex = 214;
            this.grdApplicantInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdApplicantInfo_CellClick);
            this.grdApplicantInfo.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdApplicantInfo_RowHeaderMouseDoubleClick);
            // 
            // UpdategrdBtn
            // 
            this.UpdategrdBtn.Frozen = true;
            this.UpdategrdBtn.HeaderText = "^";
            this.UpdategrdBtn.Name = "UpdategrdBtn";
            this.UpdategrdBtn.Text = "^";
            this.UpdategrdBtn.UseColumnTextForButtonValue = true;
            this.UpdategrdBtn.Width = 30;
            // 
            // DeletegrdBtn
            // 
            this.DeletegrdBtn.Frozen = true;
            this.DeletegrdBtn.HeaderText = "X";
            this.DeletegrdBtn.Name = "DeletegrdBtn";
            this.DeletegrdBtn.Text = "X";
            this.DeletegrdBtn.UseColumnTextForButtonValue = true;
            this.DeletegrdBtn.Width = 30;
            // 
            // frmApplicant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(770, 475);
            this.Controls.Add(this.grdApplicantInfo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmApplicant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Applicant Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmApplicant_FormClosing);
            this.Load += new System.EventHandler(this.frmApplicant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdApplicantInfo)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Button btnAdd;
        internal System.Windows.Forms.DataGridView grdApplicantInfo;
        internal System.Windows.Forms.DataGridViewButtonColumn UpdategrdBtn;
        internal System.Windows.Forms.DataGridViewButtonColumn DeletegrdBtn;
        #endregion
    }
}