namespace JobTracker.Application_Tool
{
    partial class frmSendPMPending
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
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.backworkerEmailSender = new System.ComponentModel.BackgroundWorker();
            this.picboxEmailProgress = new System.Windows.Forms.PictureBox();
            this.grdJobList = new System.Windows.Forms.DataGridView();
            this.grdChk = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlCompany = new System.Windows.Forms.Panel();
            this.cmbPM = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtJobnumber = new System.Windows.Forms.TextBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.lblTotalCompany = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlInvoice = new System.Windows.Forms.Panel();
            this.Label2 = new System.Windows.Forms.Label();
            this.grdPendingTrackSub = new System.Windows.Forms.DataGridView();
            this.lblProcess = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picboxEmailProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobList)).BeginInit();
            this.pnlCompany.SuspendLayout();
            this.pnlInvoice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingTrackSub)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSendEmail.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSendEmail.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSendEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Location = new System.Drawing.Point(320, 548);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(89, 31);
            this.btnSendEmail.TabIndex = 18;
            this.btnSendEmail.Text = "Send";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // backworkerEmailSender
            // 
            this.backworkerEmailSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backworkerEmailSender_DoWork);
            this.backworkerEmailSender.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backworkerEmailSender_ProgressChanged);
            this.backworkerEmailSender.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backworkerEmailSender_RunWorkerCompleted);
            // 
            // picboxEmailProgress
            // 
            this.picboxEmailProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picboxEmailProgress.BackColor = System.Drawing.Color.Transparent;
            this.picboxEmailProgress.Image = global::JobTracker.Properties.Resources.UploadProcess;
            this.picboxEmailProgress.Location = new System.Drawing.Point(262, 547);
            this.picboxEmailProgress.Margin = new System.Windows.Forms.Padding(2);
            this.picboxEmailProgress.Name = "picboxEmailProgress";
            this.picboxEmailProgress.Size = new System.Drawing.Size(201, 33);
            this.picboxEmailProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxEmailProgress.TabIndex = 19;
            this.picboxEmailProgress.TabStop = false;
            this.picboxEmailProgress.Visible = false;
            // 
            // grdJobList
            // 
            this.grdJobList.AllowUserToAddRows = false;
            this.grdJobList.AllowUserToDeleteRows = false;
            this.grdJobList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdJobList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdJobList.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdJobList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdJobList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdJobList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.grdChk});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdJobList.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdJobList.Location = new System.Drawing.Point(1, 34);
            this.grdJobList.Margin = new System.Windows.Forms.Padding(2);
            this.grdJobList.Name = "grdJobList";
            this.grdJobList.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdJobList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdJobList.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.grdJobList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdJobList.RowTemplate.Height = 24;
            this.grdJobList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdJobList.Size = new System.Drawing.Size(689, 209);
            this.grdJobList.TabIndex = 21;
            this.grdJobList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCompanyList_CellClick);
            // 
            // grdChk
            // 
            this.grdChk.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.grdChk.Frozen = true;
            this.grdChk.HeaderText = ": :";
            this.grdChk.Name = "grdChk";
            this.grdChk.ReadOnly = true;
            this.grdChk.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grdChk.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.grdChk.Width = 30;
            // 
            // pnlCompany
            // 
            this.pnlCompany.BackColor = System.Drawing.Color.Transparent;
            this.pnlCompany.Controls.Add(this.cmbPM);
            this.pnlCompany.Controls.Add(this.Label4);
            this.pnlCompany.Controls.Add(this.Label3);
            this.pnlCompany.Controls.Add(this.txtJobnumber);
            this.pnlCompany.Controls.Add(this.chkAll);
            this.pnlCompany.Controls.Add(this.lblTotalCompany);
            this.pnlCompany.Controls.Add(this.Label1);
            this.pnlCompany.Controls.Add(this.grdJobList);
            this.pnlCompany.Location = new System.Drawing.Point(7, 3);
            this.pnlCompany.Name = "pnlCompany";
            this.pnlCompany.Size = new System.Drawing.Size(692, 243);
            this.pnlCompany.TabIndex = 23;
            // 
            // cmbPM
            // 
            this.cmbPM.FormattingEnabled = true;
            this.cmbPM.Location = new System.Drawing.Point(376, 9);
            this.cmbPM.Name = "cmbPM";
            this.cmbPM.Size = new System.Drawing.Size(47, 21);
            this.cmbPM.TabIndex = 32;
            this.cmbPM.SelectedIndexChanged += new System.EventHandler(this.cmbPM_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(347, 12);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(23, 13);
            this.Label4.TabIndex = 31;
            this.Label4.Text = "PM";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(173, 12);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(64, 13);
            this.Label3.TabIndex = 29;
            this.Label3.Text = "Job Number";
            // 
            // txtJobnumber
            // 
            this.txtJobnumber.Location = new System.Drawing.Point(241, 9);
            this.txtJobnumber.Name = "txtJobnumber";
            this.txtJobnumber.Size = new System.Drawing.Size(100, 20);
            this.txtJobnumber.TabIndex = 28;
            this.txtJobnumber.TextChanged += new System.EventHandler(this.txtJobnumber_TextChanged);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAll.Location = new System.Drawing.Point(8, 11);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(72, 18);
            this.chkAll.TabIndex = 27;
            this.chkAll.Text = "Select All";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // lblTotalCompany
            // 
            this.lblTotalCompany.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalCompany.AutoSize = true;
            this.lblTotalCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCompany.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTotalCompany.Location = new System.Drawing.Point(606, 12);
            this.lblTotalCompany.Name = "lblTotalCompany";
            this.lblTotalCompany.Size = new System.Drawing.Size(81, 13);
            this.lblTotalCompany.TabIndex = 26;
            this.lblTotalCompany.Text = "Total Record";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.Label1.Location = new System.Drawing.Point(90, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 17);
            this.Label1.TabIndex = 22;
            this.Label1.Text = "Job List";
            // 
            // pnlInvoice
            // 
            this.pnlInvoice.BackColor = System.Drawing.Color.Transparent;
            this.pnlInvoice.Controls.Add(this.Label2);
            this.pnlInvoice.Controls.Add(this.grdPendingTrackSub);
            this.pnlInvoice.Location = new System.Drawing.Point(5, 254);
            this.pnlInvoice.Name = "pnlInvoice";
            this.pnlInvoice.Size = new System.Drawing.Size(692, 216);
            this.pnlInvoice.TabIndex = 24;
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Bold);
            this.Label2.Location = new System.Drawing.Point(92, 12);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(113, 17);
            this.Label2.TabIndex = 23;
            this.Label2.Text = "Pending TrackSub";
            // 
            // grdPendingTrackSub
            // 
            this.grdPendingTrackSub.AllowUserToAddRows = false;
            this.grdPendingTrackSub.AllowUserToDeleteRows = false;
            this.grdPendingTrackSub.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPendingTrackSub.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPendingTrackSub.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdPendingTrackSub.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdPendingTrackSub.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdPendingTrackSub.Location = new System.Drawing.Point(1, 34);
            this.grdPendingTrackSub.Margin = new System.Windows.Forms.Padding(2);
            this.grdPendingTrackSub.Name = "grdPendingTrackSub";
            this.grdPendingTrackSub.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPendingTrackSub.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            this.grdPendingTrackSub.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.grdPendingTrackSub.RowTemplate.Height = 24;
            this.grdPendingTrackSub.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPendingTrackSub.Size = new System.Drawing.Size(689, 182);
            this.grdPendingTrackSub.TabIndex = 21;
            this.grdPendingTrackSub.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPendingTrackSub_CellClick);
            this.grdPendingTrackSub.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdPendingTrackSub_CellFormatting);
            // 
            // lblProcess
            // 
            this.lblProcess.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblProcess.AutoSize = true;
            this.lblProcess.BackColor = System.Drawing.Color.Transparent;
            this.lblProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblProcess.Location = new System.Drawing.Point(332, 530);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(56, 13);
            this.lblProcess.TabIndex = 25;
            this.lblProcess.Text = "Progress";
            this.lblProcess.Visible = false;
            // 
            // frmSendPMPending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::JobTracker.Properties.Resources.FrmBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(701, 595);
            this.Controls.Add(this.picboxEmailProgress);
            this.Controls.Add(this.lblProcess);
            this.Controls.Add(this.pnlInvoice);
            this.Controls.Add(this.pnlCompany);
            this.Controls.Add(this.btnSendEmail);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmSendPMPending";
            this.Text = "Send PM Pending Email";
            this.Activated += new System.EventHandler(this.frmTrafficEmail_Activated);
            this.Load += new System.EventHandler(this.frmTrafficEmail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picboxEmailProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdJobList)).EndInit();
            this.pnlCompany.ResumeLayout(false);
            this.pnlCompany.PerformLayout();
            this.pnlInvoice.ResumeLayout(false);
            this.pnlInvoice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPendingTrackSub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.Button btnSendEmail;
        internal System.ComponentModel.BackgroundWorker backworkerEmailSender;
        internal System.Windows.Forms.PictureBox picboxEmailProgress;
        internal System.Windows.Forms.DataGridView grdJobList;
        internal System.Windows.Forms.Panel pnlCompany;
        internal System.Windows.Forms.Panel pnlInvoice;
        internal System.Windows.Forms.DataGridView grdPendingTrackSub;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblProcess;
        internal System.Windows.Forms.Label lblTotalCompany;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn grdChk;
        internal System.Windows.Forms.CheckBox chkAll;
        internal System.Windows.Forms.ComboBox cmbPM;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtJobnumber;


        #endregion
    }
}