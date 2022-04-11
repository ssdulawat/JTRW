namespace JobTracker.PDFeditTools
{
    partial class frmCraneUser_subInfo
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
            this.grdCraneUser_SubInfo = new System.Windows.Forms.DataGridView();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdCraneUser_SubInfo)).BeginInit();
            this.GrpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCraneUser_SubInfo
            // 
            this.grdCraneUser_SubInfo.AllowUserToAddRows = false;
            this.grdCraneUser_SubInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCraneUser_SubInfo.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCraneUser_SubInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCraneUser_SubInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCraneUser_SubInfo.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdCraneUser_SubInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCraneUser_SubInfo.Location = new System.Drawing.Point(1, 62);
            this.grdCraneUser_SubInfo.Margin = new System.Windows.Forms.Padding(2);
            this.grdCraneUser_SubInfo.MultiSelect = false;
            this.grdCraneUser_SubInfo.Name = "grdCraneUser_SubInfo";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCraneUser_SubInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdCraneUser_SubInfo.RowTemplate.Height = 24;
            this.grdCraneUser_SubInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCraneUser_SubInfo.Size = new System.Drawing.Size(768, 409);
            this.grdCraneUser_SubInfo.TabIndex = 215;
            this.grdCraneUser_SubInfo.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCraneUser_SubInfo_RowHeaderMouseDoubleClick);
            // 
            // GrpSearch
            // 
            this.GrpSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GrpSearch.Controls.Add(this.txtLastName);
            this.GrpSearch.Controls.Add(this.Label2);
            this.GrpSearch.Controls.Add(this.txtFirstName);
            this.GrpSearch.Controls.Add(this.Label1);
            this.GrpSearch.Controls.Add(this.txtCompanyName);
            this.GrpSearch.Controls.Add(this.Label9);
            this.GrpSearch.Font = new System.Drawing.Font("Calibri", 9F);
            this.GrpSearch.ForeColor = System.Drawing.Color.Maroon;
            this.GrpSearch.Location = new System.Drawing.Point(1, 12);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(768, 46);
            this.GrpSearch.TabIndex = 216;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "Search";
            // 
            // txtLastName
            // 
            this.txtLastName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtLastName.Location = new System.Drawing.Point(482, 17);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(120, 22);
            this.txtLastName.TabIndex = 5;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(416, 21);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 14);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Last Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.AcceptsReturn = true;
            this.txtFirstName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFirstName.Location = new System.Drawing.Point(301, 17);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(107, 22);
            this.txtFirstName.TabIndex = 3;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(231, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(66, 14);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "First Name";
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCompanyName.Location = new System.Drawing.Point(105, 17);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(120, 22);
            this.txtCompanyName.TabIndex = 1;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label9.Location = new System.Drawing.Point(11, 21);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(91, 14);
            this.Label9.TabIndex = 0;
            this.Label9.Text = "Company Name";
            // 
            // frmCraneUser_subInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(770, 471);
            this.Controls.Add(this.GrpSearch);
            this.Controls.Add(this.grdCraneUser_SubInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmCraneUser_subInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crane User And Sub Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCraneUser_subInfo_FormClosing);
            this.Load += new System.EventHandler(this.frmCraneUser_subInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCraneUser_SubInfo)).EndInit();
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.DataGridView grdCraneUser_SubInfo;
        internal System.Windows.Forms.GroupBox GrpSearch;
        internal System.Windows.Forms.TextBox txtLastName;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtFirstName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtCompanyName;
        internal System.Windows.Forms.Label Label9;
        #endregion
    }
}