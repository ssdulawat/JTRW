using Microsoft.VisualBasic.CompilerServices;

namespace JobTracker.JobTrackingForm
{
    partial class frmAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.chkLbxLocal = new System.Windows.Forms.CheckedListBox();
            this.chkLbxWeb = new System.Windows.Forms.CheckedListBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtUpdatedRecords = new System.Windows.Forms.Label();
            this.txtInsertedRecord = new System.Windows.Forms.Label();
            this.txtDeletedRecords = new System.Windows.Forms.Label();
            this.lbUpdatedRecord = new System.Windows.Forms.Label();
            this.lblInsertedRecord = new System.Windows.Forms.Label();
            this.lblDeletedRecord = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.Timer(this.components);
            this.BackgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.chkReminder = new System.Windows.Forms.CheckBox();
            this.pnlEmailREminder = new System.Windows.Forms.Panel();
            this.rdbWeekly = new System.Windows.Forms.RadioButton();
            this.rdbDaily = new System.Windows.Forms.RadioButton();
            this.rdbHourly = new System.Windows.Forms.RadioButton();
            this.PnlSenderEmail = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtEmailpassword = new System.Windows.Forms.TextBox();
            this.txtEmailaddress = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.grdLocalTableData = new System.Windows.Forms.DataGridView();
            this.picProgress = new System.Windows.Forms.PictureBox();
            this.pnlLocal = new System.Windows.Forms.Panel();
            this.pnlWeb = new System.Windows.Forms.Panel();
            this.pnlUpdateLabal = new System.Windows.Forms.Panel();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.pnlReminder = new System.Windows.Forms.Panel();
            this.tbpnlUpload = new System.Windows.Forms.TableLayoutPanel();
            this.TableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlEmailREminder.SuspendLayout();
            this.PnlSenderEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocalTableData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).BeginInit();
            this.pnlLocal.SuspendLayout();
            this.pnlWeb.SuspendLayout();
            this.pnlUpdateLabal.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            this.Panel1.SuspendLayout();
            this.pnlReminder.SuspendLayout();
            this.tbpnlUpload.SuspendLayout();
            this.TableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(47, 3);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(76, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Local Server";
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Transparent;
            this.Label2.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(50, 4);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(71, 14);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Web Server";
            // 
            // chkLbxLocal
            // 
            this.chkLbxLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLbxLocal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chkLbxLocal.CheckOnClick = true;
            this.chkLbxLocal.FormattingEnabled = true;
            this.chkLbxLocal.Location = new System.Drawing.Point(0, 29);
            this.chkLbxLocal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkLbxLocal.Name = "chkLbxLocal";
            this.chkLbxLocal.Size = new System.Drawing.Size(167, 169);
            this.chkLbxLocal.TabIndex = 4;
            // 
            // chkLbxWeb
            // 
            this.chkLbxWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLbxWeb.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.chkLbxWeb.FormattingEnabled = true;
            this.chkLbxWeb.Location = new System.Drawing.Point(0, 26);
            this.chkLbxWeb.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkLbxWeb.Name = "chkLbxWeb";
            this.chkLbxWeb.Size = new System.Drawing.Size(167, 169);
            this.chkLbxWeb.TabIndex = 5;
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpload.Location = new System.Drawing.Point(55, 102);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(49, 43);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.UseVisualStyleBackColor = true;
            // 
            // txtUpdatedRecords
            // 
            this.txtUpdatedRecords.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtUpdatedRecords.AutoSize = true;
            this.txtUpdatedRecords.BackColor = System.Drawing.Color.Transparent;
            this.txtUpdatedRecords.Location = new System.Drawing.Point(282, 8);
            this.txtUpdatedRecords.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtUpdatedRecords.Name = "txtUpdatedRecords";
            this.txtUpdatedRecords.Size = new System.Drawing.Size(114, 13);
            this.txtUpdatedRecords.TabIndex = 8;
            this.txtUpdatedRecords.Text = "No. of record updated:";
            // 
            // txtInsertedRecord
            // 
            this.txtInsertedRecord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtInsertedRecord.AutoSize = true;
            this.txtInsertedRecord.BackColor = System.Drawing.Color.Transparent;
            this.txtInsertedRecord.Location = new System.Drawing.Point(66, 8);
            this.txtInsertedRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtInsertedRecord.Name = "txtInsertedRecord";
            this.txtInsertedRecord.Size = new System.Drawing.Size(105, 13);
            this.txtInsertedRecord.TabIndex = 9;
            this.txtInsertedRecord.Text = "No. of record added:";
            // 
            // txtDeletedRecords
            // 
            this.txtDeletedRecords.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtDeletedRecords.AutoSize = true;
            this.txtDeletedRecords.BackColor = System.Drawing.Color.Transparent;
            this.txtDeletedRecords.Location = new System.Drawing.Point(507, 7);
            this.txtDeletedRecords.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txtDeletedRecords.Name = "txtDeletedRecords";
            this.txtDeletedRecords.Size = new System.Drawing.Size(110, 13);
            this.txtDeletedRecords.TabIndex = 10;
            this.txtDeletedRecords.Text = "No. of record deleted:";
            // 
            // lbUpdatedRecord
            // 
            this.lbUpdatedRecord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lbUpdatedRecord.AutoSize = true;
            this.lbUpdatedRecord.BackColor = System.Drawing.Color.Transparent;
            this.lbUpdatedRecord.Location = new System.Drawing.Point(396, 8);
            this.lbUpdatedRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUpdatedRecord.Name = "lbUpdatedRecord";
            this.lbUpdatedRecord.Size = new System.Drawing.Size(15, 13);
            this.lbUpdatedRecord.TabIndex = 11;
            this.lbUpdatedRecord.Text = "U";
            // 
            // lblInsertedRecord
            // 
            this.lblInsertedRecord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblInsertedRecord.AutoSize = true;
            this.lblInsertedRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblInsertedRecord.Location = new System.Drawing.Point(173, 9);
            this.lblInsertedRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInsertedRecord.Name = "lblInsertedRecord";
            this.lblInsertedRecord.Size = new System.Drawing.Size(10, 13);
            this.lblInsertedRecord.TabIndex = 12;
            this.lblInsertedRecord.Text = "I";
            // 
            // lblDeletedRecord
            // 
            this.lblDeletedRecord.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDeletedRecord.AutoSize = true;
            this.lblDeletedRecord.BackColor = System.Drawing.Color.Transparent;
            this.lblDeletedRecord.Location = new System.Drawing.Point(618, 7);
            this.lblDeletedRecord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeletedRecord.Name = "lblDeletedRecord";
            this.lblDeletedRecord.Size = new System.Drawing.Size(15, 13);
            this.lblDeletedRecord.TabIndex = 13;
            this.lblDeletedRecord.Text = "D";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Interval = 1000;
            // 
            // BackgroundWorker1
            // 
            this.BackgroundWorker1.WorkerReportsProgress = true;
            // 
            // chkReminder
            // 
            this.chkReminder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.chkReminder.AutoSize = true;
            this.chkReminder.BackColor = System.Drawing.Color.Transparent;
            this.chkReminder.Location = new System.Drawing.Point(28, 4);
            this.chkReminder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkReminder.Name = "chkReminder";
            this.chkReminder.Size = new System.Drawing.Size(99, 17);
            this.chkReminder.TabIndex = 16;
            this.chkReminder.Text = "Email Reminder";
            this.chkReminder.UseVisualStyleBackColor = false;
            // 
            // pnlEmailREminder
            // 
            this.pnlEmailREminder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pnlEmailREminder.BackColor = System.Drawing.Color.Transparent;
            this.pnlEmailREminder.Controls.Add(this.rdbWeekly);
            this.pnlEmailREminder.Controls.Add(this.rdbDaily);
            this.pnlEmailREminder.Controls.Add(this.rdbHourly);
            this.pnlEmailREminder.Location = new System.Drawing.Point(28, 25);
            this.pnlEmailREminder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlEmailREminder.Name = "pnlEmailREminder";
            this.pnlEmailREminder.Size = new System.Drawing.Size(97, 81);
            this.pnlEmailREminder.TabIndex = 17;
            // 
            // rdbWeekly
            // 
            this.rdbWeekly.AutoSize = true;
            this.rdbWeekly.Location = new System.Drawing.Point(6, 54);
            this.rdbWeekly.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbWeekly.Name = "rdbWeekly";
            this.rdbWeekly.Size = new System.Drawing.Size(61, 17);
            this.rdbWeekly.TabIndex = 2;
            this.rdbWeekly.TabStop = true;
            this.rdbWeekly.Text = "Weekly";
            this.rdbWeekly.UseVisualStyleBackColor = true;
            // 
            // rdbDaily
            // 
            this.rdbDaily.AutoSize = true;
            this.rdbDaily.Location = new System.Drawing.Point(5, 32);
            this.rdbDaily.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbDaily.Name = "rdbDaily";
            this.rdbDaily.Size = new System.Drawing.Size(48, 17);
            this.rdbDaily.TabIndex = 1;
            this.rdbDaily.TabStop = true;
            this.rdbDaily.Text = "Daily";
            this.rdbDaily.UseVisualStyleBackColor = true;
            // 
            // rdbHourly
            // 
            this.rdbHourly.AutoSize = true;
            this.rdbHourly.Location = new System.Drawing.Point(5, 11);
            this.rdbHourly.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdbHourly.Name = "rdbHourly";
            this.rdbHourly.Size = new System.Drawing.Size(55, 17);
            this.rdbHourly.TabIndex = 0;
            this.rdbHourly.TabStop = true;
            this.rdbHourly.Text = "Hourly";
            this.rdbHourly.UseVisualStyleBackColor = true;
            // 
            // PnlSenderEmail
            // 
            this.PnlSenderEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PnlSenderEmail.BackColor = System.Drawing.Color.Transparent;
            this.PnlSenderEmail.Controls.Add(this.btnOK);
            this.PnlSenderEmail.Controls.Add(this.txtEmailpassword);
            this.PnlSenderEmail.Controls.Add(this.txtEmailaddress);
            this.PnlSenderEmail.Controls.Add(this.Label5);
            this.PnlSenderEmail.Controls.Add(this.Label4);
            this.PnlSenderEmail.Controls.Add(this.Label3);
            this.PnlSenderEmail.Location = new System.Drawing.Point(1, 111);
            this.PnlSenderEmail.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PnlSenderEmail.Name = "PnlSenderEmail";
            this.PnlSenderEmail.Size = new System.Drawing.Size(170, 118);
            this.PnlSenderEmail.TabIndex = 18;
            this.PnlSenderEmail.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(55, 98);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 19);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // txtEmailpassword
            // 
            this.txtEmailpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailpassword.Location = new System.Drawing.Point(7, 76);
            this.txtEmailpassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmailpassword.Name = "txtEmailpassword";
            this.txtEmailpassword.PasswordChar = '*';
            this.txtEmailpassword.Size = new System.Drawing.Size(155, 21);
            this.txtEmailpassword.TabIndex = 22;
            this.txtEmailpassword.UseSystemPasswordChar = true;
            // 
            // txtEmailaddress
            // 
            this.txtEmailaddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailaddress.Location = new System.Drawing.Point(6, 38);
            this.txtEmailaddress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtEmailaddress.Name = "txtEmailaddress";
            this.txtEmailaddress.Size = new System.Drawing.Size(155, 20);
            this.txtEmailaddress.TabIndex = 21;
            // 
            // Label5
            // 
            this.Label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.Location = new System.Drawing.Point(12, 7);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(151, 14);
            this.Label5.TabIndex = 19;
            this.Label5.Text = "Set Sender Email Address";
            // 
            // Label4
            // 
            this.Label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(4, 59);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(81, 14);
            this.Label4.TabIndex = 20;
            this.Label4.Text = "EmailPassword";
            // 
            // Label3
            // 
            this.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(4, 23);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(73, 14);
            this.Label3.TabIndex = 19;
            this.Label3.Text = "EmailAddress";
            // 
            // grdLocalTableData
            // 
            this.grdLocalTableData.AllowUserToAddRows = false;
            this.grdLocalTableData.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLocalTableData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdLocalTableData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLocalTableData.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdLocalTableData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdLocalTableData.Location = new System.Drawing.Point(0, 0);
            this.grdLocalTableData.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.grdLocalTableData.MultiSelect = false;
            this.grdLocalTableData.Name = "grdLocalTableData";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLocalTableData.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdLocalTableData.RowTemplate.Height = 24;
            this.grdLocalTableData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdLocalTableData.Size = new System.Drawing.Size(695, 248);
            this.grdLocalTableData.TabIndex = 197;
            // 
            // picProgress
            // 
            this.picProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picProgress.BackColor = System.Drawing.Color.Transparent;
            this.picProgress.Image = global::JobTracker.Properties.Resources.UploadProcess;
            this.picProgress.Location = new System.Drawing.Point(21, 195);
            this.picProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picProgress.Name = "picProgress";
            this.picProgress.Size = new System.Drawing.Size(123, 33);
            this.picProgress.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProgress.TabIndex = 198;
            this.picProgress.TabStop = false;
            this.picProgress.Visible = false;
            // 
            // pnlLocal
            // 
            this.pnlLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLocal.BackColor = System.Drawing.Color.Transparent;
            this.pnlLocal.Controls.Add(this.chkLbxLocal);
            this.pnlLocal.Controls.Add(this.Label1);
            this.pnlLocal.Location = new System.Drawing.Point(3, 3);
            this.pnlLocal.Name = "pnlLocal";
            this.pnlLocal.Size = new System.Drawing.Size(167, 241);
            this.pnlLocal.TabIndex = 199;
            // 
            // pnlWeb
            // 
            this.pnlWeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWeb.BackColor = System.Drawing.Color.Transparent;
            this.pnlWeb.Controls.Add(this.chkLbxWeb);
            this.pnlWeb.Controls.Add(this.Label2);
            this.pnlWeb.Location = new System.Drawing.Point(349, 3);
            this.pnlWeb.Name = "pnlWeb";
            this.pnlWeb.Size = new System.Drawing.Size(167, 241);
            this.pnlWeb.TabIndex = 200;
            // 
            // pnlUpdateLabal
            // 
            this.pnlUpdateLabal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUpdateLabal.BackColor = System.Drawing.Color.Transparent;
            this.pnlUpdateLabal.Controls.Add(this.txtDeletedRecords);
            this.pnlUpdateLabal.Controls.Add(this.txtUpdatedRecords);
            this.pnlUpdateLabal.Controls.Add(this.txtInsertedRecord);
            this.pnlUpdateLabal.Controls.Add(this.lbUpdatedRecord);
            this.pnlUpdateLabal.Controls.Add(this.lblInsertedRecord);
            this.pnlUpdateLabal.Controls.Add(this.lblDeletedRecord);
            this.pnlUpdateLabal.Location = new System.Drawing.Point(3, 256);
            this.pnlUpdateLabal.Name = "pnlUpdateLabal";
            this.pnlUpdateLabal.Size = new System.Drawing.Size(695, 28);
            this.pnlUpdateLabal.TabIndex = 201;
            // 
            // pnlGrid
            // 
            this.pnlGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGrid.BackColor = System.Drawing.Color.Transparent;
            this.pnlGrid.Controls.Add(this.grdLocalTableData);
            this.pnlGrid.Location = new System.Drawing.Point(3, 290);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(695, 248);
            this.pnlGrid.TabIndex = 202;
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.Color.Transparent;
            this.Panel1.Controls.Add(this.picProgress);
            this.Panel1.Controls.Add(this.btnUpload);
            this.Panel1.Location = new System.Drawing.Point(176, 3);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(167, 241);
            this.Panel1.TabIndex = 203;
            // 
            // pnlReminder
            // 
            this.pnlReminder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlReminder.BackColor = System.Drawing.Color.Transparent;
            this.pnlReminder.Controls.Add(this.PnlSenderEmail);
            this.pnlReminder.Controls.Add(this.pnlEmailREminder);
            this.pnlReminder.Controls.Add(this.chkReminder);
            this.pnlReminder.Location = new System.Drawing.Point(522, 3);
            this.pnlReminder.Name = "pnlReminder";
            this.pnlReminder.Size = new System.Drawing.Size(170, 241);
            this.pnlReminder.TabIndex = 204;
            // 
            // tbpnlUpload
            // 
            this.tbpnlUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbpnlUpload.BackColor = System.Drawing.Color.Transparent;
            this.tbpnlUpload.ColumnCount = 4;
            this.tbpnlUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpnlUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpnlUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpnlUpload.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tbpnlUpload.Controls.Add(this.pnlLocal, 0, 0);
            this.tbpnlUpload.Controls.Add(this.pnlWeb, 2, 0);
            this.tbpnlUpload.Controls.Add(this.Panel1, 1, 0);
            this.tbpnlUpload.Controls.Add(this.pnlReminder, 3, 0);
            this.tbpnlUpload.Location = new System.Drawing.Point(3, 3);
            this.tbpnlUpload.Name = "tbpnlUpload";
            this.tbpnlUpload.RowCount = 1;
            this.tbpnlUpload.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbpnlUpload.Size = new System.Drawing.Size(695, 247);
            this.tbpnlUpload.TabIndex = 205;
            // 
            // TableLayoutPanel1
            // 
            this.TableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.TableLayoutPanel1.ColumnCount = 1;
            this.TableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TableLayoutPanel1.Controls.Add(this.tbpnlUpload, 0, 0);
            this.TableLayoutPanel1.Controls.Add(this.pnlGrid, 0, 2);
            this.TableLayoutPanel1.Controls.Add(this.pnlUpdateLabal, 0, 1);
            this.TableLayoutPanel1.Location = new System.Drawing.Point(2, 4);
            this.TableLayoutPanel1.Name = "TableLayoutPanel1";
            this.TableLayoutPanel1.RowCount = 3;
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.TableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.TableLayoutPanel1.Size = new System.Drawing.Size(701, 541);
            this.TableLayoutPanel1.TabIndex = 206;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(708, 548);
            this.Controls.Add(this.TableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmAdmin";
            this.Text = "Upload";
            this.pnlEmailREminder.ResumeLayout(false);
            this.pnlEmailREminder.PerformLayout();
            this.PnlSenderEmail.ResumeLayout(false);
            this.PnlSenderEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLocalTableData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProgress)).EndInit();
            this.pnlLocal.ResumeLayout(false);
            this.pnlLocal.PerformLayout();
            this.pnlWeb.ResumeLayout(false);
            this.pnlWeb.PerformLayout();
            this.pnlUpdateLabal.ResumeLayout(false);
            this.pnlUpdateLabal.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            this.Panel1.ResumeLayout(false);
            this.pnlReminder.ResumeLayout(false);
            this.pnlReminder.PerformLayout();
            this.tbpnlUpload.ResumeLayout(false);
            this.TableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.CheckedListBox chkLbxLocal;
        internal System.Windows.Forms.CheckedListBox chkLbxWeb;
        internal System.Windows.Forms.Label txtUpdatedRecords;
        internal System.Windows.Forms.Label txtInsertedRecord;
        internal System.Windows.Forms.Label txtDeletedRecords;
        internal System.Windows.Forms.Label lbUpdatedRecord;
        internal System.Windows.Forms.Label lblInsertedRecord;
        internal System.Windows.Forms.Label lblDeletedRecord;
        internal System.Windows.Forms.Timer ProgressBar;
        internal System.ComponentModel.BackgroundWorker BackgroundWorker1;
        public System.Windows.Forms.Button btnUpload;
        internal System.Windows.Forms.CheckBox chkReminder;
        internal System.Windows.Forms.Panel pnlEmailREminder;
        internal System.Windows.Forms.RadioButton rdbWeekly;
        internal System.Windows.Forms.RadioButton rdbDaily;
        internal System.Windows.Forms.RadioButton rdbHourly;
        internal System.Windows.Forms.Panel PnlSenderEmail;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtEmailpassword;
        internal System.Windows.Forms.TextBox txtEmailaddress;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.DataGridView grdLocalTableData;
        internal System.Windows.Forms.PictureBox picProgress;
        internal System.Windows.Forms.Panel pnlLocal;
        internal System.Windows.Forms.Panel pnlWeb;
        internal System.Windows.Forms.Panel pnlUpdateLabal;
        internal System.Windows.Forms.Panel pnlGrid;
        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.Panel pnlReminder;
        internal System.Windows.Forms.TableLayoutPanel tbpnlUpload;
        internal System.Windows.Forms.TableLayoutPanel TableLayoutPanel1;
        #endregion
    }
}