namespace JobTracker.JobTrackingForm
{
    partial class frmTrafficEmail
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTrafficEmail));
            this.GBemailHeader = new System.Windows.Forms.GroupBox();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.txtEmailTo = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.CBEmailBody = new System.Windows.Forms.GroupBox();
            this.btnAgingReport = new System.Windows.Forms.Button();
            this.agingBrowser = new System.Windows.Forms.WebBrowser();
            this.chkAttachAging = new System.Windows.Forms.CheckBox();
            this.txtEmailBody = new System.Windows.Forms.TextBox();
            this.grdAttachedfile = new System.Windows.Forms.DataGridView();
            this.CMSGridRowDel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.ckbAdd = new System.Windows.Forms.CheckBox();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.backworkerEmailSender = new System.ComponentModel.BackgroundWorker();
            this.picboxEmailProgress = new System.Windows.Forms.PictureBox();
            this.GBemailHeader.SuspendLayout();
            this.CBEmailBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.grdAttachedfile).BeginInit();
            this.CMSGridRowDel.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.picboxEmailProgress).BeginInit();
            this.SuspendLayout();
            //
            //GBemailHeader
            //
            this.GBemailHeader.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GBemailHeader.BackColor = System.Drawing.Color.Transparent;
            this.GBemailHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GBemailHeader.Controls.Add(this.txtEmailSubject);
            this.GBemailHeader.Controls.Add(this.txtEmailTo);
            this.GBemailHeader.Controls.Add(this.Label2);
            this.GBemailHeader.Controls.Add(this.Label1);
            this.GBemailHeader.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.GBemailHeader.Location = new System.Drawing.Point(98, 28);
            this.GBemailHeader.Margin = new System.Windows.Forms.Padding(2);
            this.GBemailHeader.Name = "GBemailHeader";
            this.GBemailHeader.Padding = new System.Windows.Forms.Padding(2);
            this.GBemailHeader.Size = new System.Drawing.Size(502, 107);
            this.GBemailHeader.TabIndex = 0;
            this.GBemailHeader.TabStop = false;
            this.GBemailHeader.Text = "Email Header";
            //
            //txtEmailSubject
            //
            this.txtEmailSubject.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtEmailSubject.Location = new System.Drawing.Point(67, 64);
            this.txtEmailSubject.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(432, 23);
            this.txtEmailSubject.TabIndex = 3;
            //
            //txtEmailTo
            //
            this.txtEmailTo.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtEmailTo.Location = new System.Drawing.Point(67, 28);
            this.txtEmailTo.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailTo.Name = "txtEmailTo";
            this.txtEmailTo.Size = new System.Drawing.Size(432, 23);
            this.txtEmailTo.TabIndex = 2;
            //
            //Label2
            //
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.Label2.Location = new System.Drawing.Point(12, 68);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(49, 17);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Subject";
            //
            //Label1
            //
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Calibri", 10.2F);
            this.Label1.Location = new System.Drawing.Point(12, 28);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(21, 17);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "To";
            //
            //CBEmailBody
            //
            this.CBEmailBody.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.CBEmailBody.BackColor = System.Drawing.Color.Transparent;
            this.CBEmailBody.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CBEmailBody.Controls.Add(this.btnAgingReport);
            this.CBEmailBody.Controls.Add(this.agingBrowser);
            this.CBEmailBody.Controls.Add(this.chkAttachAging);
            this.CBEmailBody.Controls.Add(this.txtEmailBody);
            this.CBEmailBody.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.CBEmailBody.Location = new System.Drawing.Point(3, 145);
            this.CBEmailBody.Margin = new System.Windows.Forms.Padding(2);
            this.CBEmailBody.Name = "CBEmailBody";
            this.CBEmailBody.Padding = new System.Windows.Forms.Padding(2);
            this.CBEmailBody.Size = new System.Drawing.Size(688, 300);
            this.CBEmailBody.TabIndex = 4;
            this.CBEmailBody.TabStop = false;
            this.CBEmailBody.Text = "Email Body";
            //
            //btnAgingReport
            //
            this.btnAgingReport.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnAgingReport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgingReport.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAgingReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAgingReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgingReport.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.btnAgingReport.Location = new System.Drawing.Point(419, 274);
            this.btnAgingReport.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgingReport.Name = "btnAgingReport";
            this.btnAgingReport.Size = new System.Drawing.Size(102, 24);
            this.btnAgingReport.TabIndex = 21;
            this.btnAgingReport.Text = "Show Aging Report";
            this.btnAgingReport.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAgingReport.UseVisualStyleBackColor = false;
            //
            //agingBrowser
            //
            this.agingBrowser.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
            this.agingBrowser.Location = new System.Drawing.Point(4, 22);
            this.agingBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.agingBrowser.MinimumSize = new System.Drawing.Size(15, 16);
            this.agingBrowser.Name = "agingBrowser";
            this.agingBrowser.Size = new System.Drawing.Size(676, 242);
            this.agingBrowser.TabIndex = 20;
            this.agingBrowser.Visible = false;
            //
            //chkAttachAging
            //
            this.chkAttachAging.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
            this.chkAttachAging.AutoSize = true;
            this.chkAttachAging.Checked = true;
            this.chkAttachAging.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAttachAging.Font = new System.Drawing.Font("Calibri", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (byte)0);
            this.chkAttachAging.Location = new System.Drawing.Point(544, 277);
            this.chkAttachAging.Margin = new System.Windows.Forms.Padding(2);
            this.chkAttachAging.Name = "chkAttachAging";
            this.chkAttachAging.Size = new System.Drawing.Size(135, 18);
            this.chkAttachAging.TabIndex = 20;
            this.chkAttachAging.Text = "Attach Current Aging";
            this.chkAttachAging.UseVisualStyleBackColor = true;
            //
            //txtEmailBody
            //
            this.txtEmailBody.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
            this.txtEmailBody.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtEmailBody.Location = new System.Drawing.Point(4, 22);
            this.txtEmailBody.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailBody.Multiline = true;
            this.txtEmailBody.Name = "txtEmailBody";
            this.txtEmailBody.Size = new System.Drawing.Size(680, 249);
            this.txtEmailBody.TabIndex = 2;
            //
            //grdAttachedfile
            //
            this.grdAttachedfile.AllowUserToAddRows = false;
            this.grdAttachedfile.AllowUserToDeleteRows = false;
            this.grdAttachedfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAttachedfile.ContextMenuStrip = this.CMSGridRowDel;
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
            //CMSGridRowDel
            //
            this.CMSGridRowDel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.DeleteToolStripMenuItem });
            this.CMSGridRowDel.Name = "CMSGridRowDel";
            this.CMSGridRowDel.Size = new System.Drawing.Size(108, 26);
            //
            //DeleteToolStripMenuItem
            //
            //this.DeleteToolStripMenuItem.Image = global::JobTracker.Properties.Resources.CloseBtn;
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.DeleteToolStripMenuItem.Text = "Delete";
            //
            //GroupBox1
            //
            this.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GroupBox1.Controls.Add(this.ckbAdd);
            this.GroupBox1.Controls.Add(this.grdAttachedfile);
            this.GroupBox1.Font = new System.Drawing.Font("Calibri", 9.0F);
            this.GroupBox1.Location = new System.Drawing.Point(51, 444);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox1.Size = new System.Drawing.Size(612, 125);
            this.GroupBox1.TabIndex = 4;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Attachment";
            //
            //ckbAdd
            //
            this.ckbAdd.AutoSize = true;
            this.ckbAdd.Location = new System.Drawing.Point(504, 20);
            this.ckbAdd.Name = "ckbAdd";
            this.ckbAdd.Size = new System.Drawing.Size(102, 18);
            this.ckbAdd.TabIndex = 20;
            this.ckbAdd.Text = "Attach Invoice";
            this.ckbAdd.UseVisualStyleBackColor = true;
            //
            //btnSendEmail
            //
            this.btnSendEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSendEmail.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSendEmail.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSendEmail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            //this.btnSendEmail.Image = global::JobTracker.Properties.Resources.NOTEL;
            this.btnSendEmail.Location = new System.Drawing.Point(310, 588);
            this.btnSendEmail.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(89, 31);
            this.btnSendEmail.TabIndex = 18;
            this.btnSendEmail.Text = "Send";
            this.btnSendEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSendEmail.UseVisualStyleBackColor = false;
            //
            //backworkerEmailSender
            //
            //
            //picboxEmailProgress
            //
            this.picboxEmailProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picboxEmailProgress.BackColor = System.Drawing.Color.Transparent;
            this.picboxEmailProgress.Image = global::JobTracker.Properties.Resources.UploadProcess;
            this.picboxEmailProgress.Location = new System.Drawing.Point(258, 588);
            this.picboxEmailProgress.Margin = new System.Windows.Forms.Padding(2);
            this.picboxEmailProgress.Name = "picboxEmailProgress";
            this.picboxEmailProgress.Size = new System.Drawing.Size(201, 31);
            this.picboxEmailProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picboxEmailProgress.TabIndex = 19;
            this.picboxEmailProgress.TabStop = false;
            this.picboxEmailProgress.Visible = false;
            //
            //frmTrafficEmail
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::JobTracker.Properties.Resources.FrmBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(701, 646);
            this.Controls.Add(this.picboxEmailProgress);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.CBEmailBody);
            this.Controls.Add(this.GBemailHeader);
            this.Controls.Add(this.GroupBox1);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmTrafficEmail";
            this.Text = "Traffic Email Reminder";
            this.GBemailHeader.ResumeLayout(false);
            this.GBemailHeader.PerformLayout();
            this.CBEmailBody.ResumeLayout(false);
            this.CBEmailBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.grdAttachedfile).EndInit();
            this.CMSGridRowDel.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.picboxEmailProgress).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.GroupBox GBemailHeader;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtEmailSubject;
        internal System.Windows.Forms.TextBox txtEmailTo;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.GroupBox CBEmailBody;
        internal System.Windows.Forms.TextBox txtEmailBody;
        internal System.Windows.Forms.DataGridView grdAttachedfile;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnSendEmail;
        internal System.ComponentModel.BackgroundWorker backworkerEmailSender;
        internal System.Windows.Forms.PictureBox picboxEmailProgress;
        internal System.Windows.Forms.CheckBox chkAttachAging;
        internal System.Windows.Forms.WebBrowser agingBrowser;
        internal System.Windows.Forms.Button btnAgingReport;
        internal System.Windows.Forms.ContextMenuStrip CMSGridRowDel;
        internal System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        internal System.Windows.Forms.CheckBox ckbAdd;
        #endregion
    }
}