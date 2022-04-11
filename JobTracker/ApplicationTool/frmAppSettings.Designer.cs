using System;
using System.Drawing;

namespace JobTracker.Application_Tool
{
    partial class frmAppSettings
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
            this.gboxBackup = new System.Windows.Forms.GroupBox();
            this.cmbDatabaseName = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.btnBakDatabase = new System.Windows.Forms.Button();
            this.lblBakAddress = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.lblBakFileName = new System.Windows.Forms.Label();
            this.txtbakFilename = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSSLInvoice = new System.Windows.Forms.CheckBox();
            this.txtMailSeverInvoice = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtEmailpassword = new System.Windows.Forms.TextBox();
            this.btnSaveEmailSetting = new System.Windows.Forms.Button();
            this.txtEmailaddress = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.ChkSSLItem = new System.Windows.Forms.CheckBox();
            this.txtMailServerNameItem = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.txtPasswordItem = new System.Windows.Forms.TextBox();
            this.btnSaveEmailPendingSetting = new System.Windows.Forms.Button();
            this.txtEmailAddressItem = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAgingLogfile = new System.Windows.Forms.Button();
            this.btnUpdateAgingDir = new System.Windows.Forms.Button();
            this.txtAgingPath = new System.Windows.Forms.TextBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.rdbWeekly = new System.Windows.Forms.RadioButton();
            this.rdbDaily = new System.Windows.Forms.RadioButton();
            this.ChkSchedule = new System.Windows.Forms.CheckBox();
            this.btnSaveSchedule = new System.Windows.Forms.Button();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.chkActiveWebUpload = new System.Windows.Forms.CheckBox();
            this.btnActiveDataUpload = new System.Windows.Forms.Button();
            this.grpDatabaseChange = new System.Windows.Forms.GroupBox();
            this.lblLocalConnectionstring = new System.Windows.Forms.Label();
            this.btnSetConnectionString = new System.Windows.Forms.Button();
            this.rdbIsLocalDatabase = new System.Windows.Forms.RadioButton();
            this.rdbIsServerDatabase = new System.Windows.Forms.RadioButton();
            this.btnChangesDataBase = new System.Windows.Forms.Button();
            this.gboxBackup.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.grpDatabaseChange.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxBackup
            // 
            this.gboxBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBackup.BackColor = System.Drawing.Color.Transparent;
            this.gboxBackup.Controls.Add(this.cmbDatabaseName);
            this.gboxBackup.Controls.Add(this.Label4);
            this.gboxBackup.Controls.Add(this.btnBakDatabase);
            this.gboxBackup.Controls.Add(this.lblBakAddress);
            this.gboxBackup.Controls.Add(this.Label2);
            this.gboxBackup.Controls.Add(this.Label3);
            this.gboxBackup.Controls.Add(this.lblBakFileName);
            this.gboxBackup.Controls.Add(this.txtbakFilename);
            this.gboxBackup.Controls.Add(this.Label1);
            this.gboxBackup.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gboxBackup.Location = new System.Drawing.Point(25, 12);
            this.gboxBackup.Margin = new System.Windows.Forms.Padding(4);
            this.gboxBackup.Name = "gboxBackup";
            this.gboxBackup.Padding = new System.Windows.Forms.Padding(2);
            this.gboxBackup.Size = new System.Drawing.Size(697, 122);
            this.gboxBackup.TabIndex = 2;
            this.gboxBackup.TabStop = false;
            this.gboxBackup.Text = "Database Backup Setting";
            // 
            // cmbDatabaseName
            // 
            this.cmbDatabaseName.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.cmbDatabaseName.FormattingEnabled = true;
            this.cmbDatabaseName.Location = new System.Drawing.Point(183, 22);
            this.cmbDatabaseName.Margin = new System.Windows.Forms.Padding(2);
            this.cmbDatabaseName.Name = "cmbDatabaseName";
            this.cmbDatabaseName.Size = new System.Drawing.Size(149, 23);
            this.cmbDatabaseName.TabIndex = 19;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.Label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label4.Location = new System.Drawing.Point(45, 21);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(94, 15);
            this.Label4.TabIndex = 18;
            this.Label4.Text = "Select Database";
            // 
            // btnBakDatabase
            // 
            this.btnBakDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnBakDatabase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnBakDatabase.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnBakDatabase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnBakDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBakDatabase.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnBakDatabase.ForeColor = System.Drawing.Color.Navy;
            this.btnBakDatabase.Location = new System.Drawing.Point(532, 74);
            this.btnBakDatabase.Margin = new System.Windows.Forms.Padding(2);
            this.btnBakDatabase.Name = "btnBakDatabase";
            this.btnBakDatabase.Size = new System.Drawing.Size(148, 26);
            this.btnBakDatabase.TabIndex = 17;
            this.btnBakDatabase.Text = "Backup Database";
            this.btnBakDatabase.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnBakDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBakDatabase.UseVisualStyleBackColor = false;
            this.btnBakDatabase.Click += new System.EventHandler(this.btnBakDatabase_Click);
            // 
            // lblBakAddress
            // 
            this.lblBakAddress.AutoSize = true;
            this.lblBakAddress.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.lblBakAddress.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBakAddress.Location = new System.Drawing.Point(186, 79);
            this.lblBakAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBakAddress.Name = "lblBakAddress";
            this.lblBakAddress.Size = new System.Drawing.Size(80, 15);
            this.lblBakAddress.TabIndex = 16;
            this.lblBakAddress.Text = "Selected Path";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(45, 79);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(75, 15);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Backup Path";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Calibri", 9.5F, System.Drawing.FontStyle.Bold);
            this.Label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label3.Location = new System.Drawing.Point(345, 54);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(13, 15);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "=";
            // 
            // lblBakFileName
            // 
            this.lblBakFileName.AutoSize = true;
            this.lblBakFileName.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.lblBakFileName.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblBakFileName.Location = new System.Drawing.Point(366, 54);
            this.lblBakFileName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBakFileName.Name = "lblBakFileName";
            this.lblBakFileName.Size = new System.Drawing.Size(94, 15);
            this.lblBakFileName.TabIndex = 2;
            this.lblBakFileName.Text = "VariousInfo.bak";
            // 
            // txtbakFilename
            // 
            this.txtbakFilename.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtbakFilename.Location = new System.Drawing.Point(183, 49);
            this.txtbakFilename.Margin = new System.Windows.Forms.Padding(2);
            this.txtbakFilename.Name = "txtbakFilename";
            this.txtbakFilename.Size = new System.Drawing.Size(149, 23);
            this.txtbakFilename.TabIndex = 1;
            this.txtbakFilename.TextChanged += new System.EventHandler(this.txtbakFilename_TextChanged);
            this.txtbakFilename.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbakFilename_KeyPress);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(45, 52);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(90, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Back File Name";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.chkSSLInvoice);
            this.GroupBox1.Controls.Add(this.txtMailSeverInvoice);
            this.GroupBox1.Controls.Add(this.Label7);
            this.GroupBox1.Controls.Add(this.txtEmailpassword);
            this.GroupBox1.Controls.Add(this.btnSaveEmailSetting);
            this.GroupBox1.Controls.Add(this.txtEmailaddress);
            this.GroupBox1.Controls.Add(this.Label9);
            this.GroupBox1.Controls.Add(this.Label8);
            this.GroupBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBox1.Location = new System.Drawing.Point(25, 142);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox1.Size = new System.Drawing.Size(697, 122);
            this.GroupBox1.TabIndex = 20;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Due Invoice Mail Setting";
            // 
            // chkSSLInvoice
            // 
            this.chkSSLInvoice.AutoSize = true;
            this.chkSSLInvoice.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkSSLInvoice.Location = new System.Drawing.Point(353, 76);
            this.chkSSLInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.chkSSLInvoice.Name = "chkSSLInvoice";
            this.chkSSLInvoice.Size = new System.Drawing.Size(47, 21);
            this.chkSSLInvoice.TabIndex = 26;
            this.chkSSLInvoice.Text = "SSL";
            this.chkSSLInvoice.UseVisualStyleBackColor = true;
            // 
            // txtMailSeverInvoice
            // 
            this.txtMailSeverInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailSeverInvoice.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailSeverInvoice.Location = new System.Drawing.Point(460, 37);
            this.txtMailSeverInvoice.Margin = new System.Windows.Forms.Padding(2);
            this.txtMailSeverInvoice.Name = "txtMailSeverInvoice";
            this.txtMailSeverInvoice.Size = new System.Drawing.Size(155, 24);
            this.txtMailSeverInvoice.TabIndex = 24;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label7.Location = new System.Drawing.Point(350, 41);
            this.Label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(91, 14);
            this.Label7.TabIndex = 23;
            this.Label7.Text = "Mail Server Name";
            // 
            // txtEmailpassword
            // 
            this.txtEmailpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailpassword.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailpassword.Location = new System.Drawing.Point(153, 74);
            this.txtEmailpassword.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailpassword.Name = "txtEmailpassword";
            this.txtEmailpassword.PasswordChar = '*';
            this.txtEmailpassword.Size = new System.Drawing.Size(155, 24);
            this.txtEmailpassword.TabIndex = 22;
            this.txtEmailpassword.UseSystemPasswordChar = true;
            // 
            // btnSaveEmailSetting
            // 
            this.btnSaveEmailSetting.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveEmailSetting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveEmailSetting.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveEmailSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSaveEmailSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEmailSetting.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSaveEmailSetting.ForeColor = System.Drawing.Color.Navy;
            this.btnSaveEmailSetting.Image = global::JobTracker.Properties.Resources.SaveHL;
            this.btnSaveEmailSetting.Location = new System.Drawing.Point(532, 74);
            this.btnSaveEmailSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveEmailSetting.Name = "btnSaveEmailSetting";
            this.btnSaveEmailSetting.Size = new System.Drawing.Size(148, 26);
            this.btnSaveEmailSetting.TabIndex = 17;
            this.btnSaveEmailSetting.Text = "Save Email Setting";
            this.btnSaveEmailSetting.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnSaveEmailSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveEmailSetting.UseVisualStyleBackColor = false;
            this.btnSaveEmailSetting.Click += new System.EventHandler(this.btnSaveEmailSetting_Click);
            // 
            // txtEmailaddress
            // 
            this.txtEmailaddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailaddress.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailaddress.Location = new System.Drawing.Point(153, 37);
            this.txtEmailaddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailaddress.Name = "txtEmailaddress";
            this.txtEmailaddress.Size = new System.Drawing.Size(155, 24);
            this.txtEmailaddress.TabIndex = 21;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label9.Location = new System.Drawing.Point(45, 41);
            this.Label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(43, 14);
            this.Label9.TabIndex = 19;
            this.Label9.Text = "Email ID";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label8.Location = new System.Drawing.Point(45, 74);
            this.Label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(57, 14);
            this.Label8.TabIndex = 20;
            this.Label8.Text = "Password";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.ChkSSLItem);
            this.GroupBox2.Controls.Add(this.txtMailServerNameItem);
            this.GroupBox2.Controls.Add(this.Label10);
            this.GroupBox2.Controls.Add(this.txtPasswordItem);
            this.GroupBox2.Controls.Add(this.btnSaveEmailPendingSetting);
            this.GroupBox2.Controls.Add(this.txtEmailAddressItem);
            this.GroupBox2.Controls.Add(this.Label5);
            this.GroupBox2.Controls.Add(this.Label6);
            this.GroupBox2.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBox2.Location = new System.Drawing.Point(25, 291);
            this.GroupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox2.Size = new System.Drawing.Size(697, 122);
            this.GroupBox2.TabIndex = 23;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Pending Item Mail Setting";
            // 
            // ChkSSLItem
            // 
            this.ChkSSLItem.AutoSize = true;
            this.ChkSSLItem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ChkSSLItem.Location = new System.Drawing.Point(353, 70);
            this.ChkSSLItem.Margin = new System.Windows.Forms.Padding(2);
            this.ChkSSLItem.Name = "ChkSSLItem";
            this.ChkSSLItem.Size = new System.Drawing.Size(47, 21);
            this.ChkSSLItem.TabIndex = 29;
            this.ChkSSLItem.Text = "SSL";
            this.ChkSSLItem.UseVisualStyleBackColor = true;
            // 
            // txtMailServerNameItem
            // 
            this.txtMailServerNameItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMailServerNameItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMailServerNameItem.Location = new System.Drawing.Point(460, 32);
            this.txtMailServerNameItem.Margin = new System.Windows.Forms.Padding(2);
            this.txtMailServerNameItem.Name = "txtMailServerNameItem";
            this.txtMailServerNameItem.Size = new System.Drawing.Size(155, 24);
            this.txtMailServerNameItem.TabIndex = 28;
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label10.Location = new System.Drawing.Point(350, 35);
            this.Label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(91, 14);
            this.Label10.TabIndex = 27;
            this.Label10.Text = "Mail Server Name";
            // 
            // txtPasswordItem
            // 
            this.txtPasswordItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordItem.Location = new System.Drawing.Point(153, 74);
            this.txtPasswordItem.Margin = new System.Windows.Forms.Padding(2);
            this.txtPasswordItem.Name = "txtPasswordItem";
            this.txtPasswordItem.PasswordChar = '*';
            this.txtPasswordItem.Size = new System.Drawing.Size(155, 24);
            this.txtPasswordItem.TabIndex = 22;
            this.txtPasswordItem.UseSystemPasswordChar = true;
            // 
            // btnSaveEmailPendingSetting
            // 
            this.btnSaveEmailPendingSetting.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveEmailPendingSetting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveEmailPendingSetting.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveEmailPendingSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSaveEmailPendingSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveEmailPendingSetting.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSaveEmailPendingSetting.ForeColor = System.Drawing.Color.Navy;
            this.btnSaveEmailPendingSetting.Image = global::JobTracker.Properties.Resources.SaveHL;
            this.btnSaveEmailPendingSetting.Location = new System.Drawing.Point(532, 74);
            this.btnSaveEmailPendingSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveEmailPendingSetting.Name = "btnSaveEmailPendingSetting";
            this.btnSaveEmailPendingSetting.Size = new System.Drawing.Size(148, 26);
            this.btnSaveEmailPendingSetting.TabIndex = 17;
            this.btnSaveEmailPendingSetting.Text = "Save Email Setting";
            this.btnSaveEmailPendingSetting.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnSaveEmailPendingSetting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveEmailPendingSetting.UseVisualStyleBackColor = false;
            this.btnSaveEmailPendingSetting.Click += new System.EventHandler(this.btnSaveEmailPendingSetting_Click);
            // 
            // txtEmailAddressItem
            // 
            this.txtEmailAddressItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmailAddressItem.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailAddressItem.Location = new System.Drawing.Point(153, 37);
            this.txtEmailAddressItem.Margin = new System.Windows.Forms.Padding(2);
            this.txtEmailAddressItem.Name = "txtEmailAddressItem";
            this.txtEmailAddressItem.Size = new System.Drawing.Size(155, 24);
            this.txtEmailAddressItem.TabIndex = 21;
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label5.Location = new System.Drawing.Point(45, 41);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(43, 14);
            this.Label5.TabIndex = 19;
            this.Label5.Text = "Email ID";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label6.Location = new System.Drawing.Point(45, 74);
            this.Label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(57, 14);
            this.Label6.TabIndex = 20;
            this.Label6.Text = "Password";
            // 
            // GroupBox3
            // 
            this.GroupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox3.Controls.Add(this.btnAgingLogfile);
            this.GroupBox3.Controls.Add(this.btnUpdateAgingDir);
            this.GroupBox3.Controls.Add(this.txtAgingPath);
            this.GroupBox3.Controls.Add(this.Label12);
            this.GroupBox3.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBox3.Location = new System.Drawing.Point(25, 421);
            this.GroupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox3.Size = new System.Drawing.Size(697, 75);
            this.GroupBox3.TabIndex = 24;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Aging File Directory Setting";
            // 
            // btnAgingLogfile
            // 
            this.btnAgingLogfile.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAgingLogfile.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAgingLogfile.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnAgingLogfile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnAgingLogfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgingLogfile.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnAgingLogfile.ForeColor = System.Drawing.Color.Navy;
            this.btnAgingLogfile.Location = new System.Drawing.Point(271, 45);
            this.btnAgingLogfile.Margin = new System.Windows.Forms.Padding(2);
            this.btnAgingLogfile.Name = "btnAgingLogfile";
            this.btnAgingLogfile.Size = new System.Drawing.Size(148, 26);
            this.btnAgingLogfile.TabIndex = 22;
            this.btnAgingLogfile.Text = "Aging Log File";
            this.btnAgingLogfile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnAgingLogfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgingLogfile.UseVisualStyleBackColor = false;
            this.btnAgingLogfile.Click += new System.EventHandler(this.btnAgingLogfile_Click);
            // 
            // btnUpdateAgingDir
            // 
            this.btnUpdateAgingDir.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdateAgingDir.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnUpdateAgingDir.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnUpdateAgingDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnUpdateAgingDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateAgingDir.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnUpdateAgingDir.ForeColor = System.Drawing.Color.Navy;
            this.btnUpdateAgingDir.Image = global::JobTracker.Properties.Resources.SaveHL;
            this.btnUpdateAgingDir.Location = new System.Drawing.Point(641, 20);
            this.btnUpdateAgingDir.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdateAgingDir.Name = "btnUpdateAgingDir";
            this.btnUpdateAgingDir.Size = new System.Drawing.Size(39, 26);
            this.btnUpdateAgingDir.TabIndex = 17;
            this.btnUpdateAgingDir.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnUpdateAgingDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdateAgingDir.UseVisualStyleBackColor = false;
            this.btnUpdateAgingDir.Click += new System.EventHandler(this.btnUpdateAgingDir_Click);
            // 
            // txtAgingPath
            // 
            this.txtAgingPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAgingPath.Font = new System.Drawing.Font("Calibri", 9F);
            this.txtAgingPath.Location = new System.Drawing.Point(153, 22);
            this.txtAgingPath.Margin = new System.Windows.Forms.Padding(2);
            this.txtAgingPath.Name = "txtAgingPath";
            this.txtAgingPath.Size = new System.Drawing.Size(484, 22);
            this.txtAgingPath.TabIndex = 21;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Arial", 9F);
            this.Label12.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label12.Location = new System.Drawing.Point(45, 26);
            this.Label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(78, 15);
            this.Label12.TabIndex = 19;
            this.Label12.Text = "File Direcotry";
            // 
            // GroupBox4
            // 
            this.GroupBox4.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox4.Controls.Add(this.rdbWeekly);
            this.GroupBox4.Controls.Add(this.rdbDaily);
            this.GroupBox4.Controls.Add(this.ChkSchedule);
            this.GroupBox4.Controls.Add(this.btnSaveSchedule);
            this.GroupBox4.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBox4.Location = new System.Drawing.Point(25, 504);
            this.GroupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox4.Size = new System.Drawing.Size(400, 54);
            this.GroupBox4.TabIndex = 25;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Data Varify Schedule Setting";
            // 
            // rdbWeekly
            // 
            this.rdbWeekly.AutoSize = true;
            this.rdbWeekly.Font = new System.Drawing.Font("Calibri", 9F);
            this.rdbWeekly.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rdbWeekly.Location = new System.Drawing.Point(276, 25);
            this.rdbWeekly.Name = "rdbWeekly";
            this.rdbWeekly.Size = new System.Drawing.Size(65, 18);
            this.rdbWeekly.TabIndex = 23;
            this.rdbWeekly.TabStop = true;
            this.rdbWeekly.Text = "Weekly";
            this.rdbWeekly.UseVisualStyleBackColor = true;
            // 
            // rdbDaily
            // 
            this.rdbDaily.AutoSize = true;
            this.rdbDaily.Font = new System.Drawing.Font("Calibri", 9F);
            this.rdbDaily.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rdbDaily.Location = new System.Drawing.Point(212, 24);
            this.rdbDaily.Name = "rdbDaily";
            this.rdbDaily.Size = new System.Drawing.Size(53, 18);
            this.rdbDaily.TabIndex = 22;
            this.rdbDaily.TabStop = true;
            this.rdbDaily.Text = "Daily";
            this.rdbDaily.UseVisualStyleBackColor = true;
            // 
            // ChkSchedule
            // 
            this.ChkSchedule.AutoSize = true;
            this.ChkSchedule.Font = new System.Drawing.Font("Calibri", 9F);
            this.ChkSchedule.ForeColor = System.Drawing.Color.RoyalBlue;
            this.ChkSchedule.Location = new System.Drawing.Point(45, 25);
            this.ChkSchedule.Name = "ChkSchedule";
            this.ChkSchedule.Size = new System.Drawing.Size(110, 18);
            this.ChkSchedule.TabIndex = 20;
            this.ChkSchedule.Text = "Active Schedule";
            this.ChkSchedule.UseVisualStyleBackColor = true;
            this.ChkSchedule.CheckedChanged += new System.EventHandler(this.ChkSchedule_CheckedChanged);
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveSchedule.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveSchedule.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveSchedule.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSaveSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSchedule.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSaveSchedule.ForeColor = System.Drawing.Color.Navy;
            this.btnSaveSchedule.Image = global::JobTracker.Properties.Resources.SaveHL;
            this.btnSaveSchedule.Location = new System.Drawing.Point(346, 18);
            this.btnSaveSchedule.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(31, 26);
            this.btnSaveSchedule.TabIndex = 17;
            this.btnSaveSchedule.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnSaveSchedule.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveSchedule.UseVisualStyleBackColor = false;
            this.btnSaveSchedule.Click += new System.EventHandler(this.btnSaveSchedule_Click);
            // 
            // GroupBox5
            // 
            this.GroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox5.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox5.Controls.Add(this.chkActiveWebUpload);
            this.GroupBox5.Controls.Add(this.btnActiveDataUpload);
            this.GroupBox5.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBox5.Location = new System.Drawing.Point(433, 504);
            this.GroupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox5.Size = new System.Drawing.Size(289, 54);
            this.GroupBox5.TabIndex = 26;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Active Web Data Upload";
            // 
            // chkActiveWebUpload
            // 
            this.chkActiveWebUpload.AutoSize = true;
            this.chkActiveWebUpload.Font = new System.Drawing.Font("Calibri", 9F);
            this.chkActiveWebUpload.ForeColor = System.Drawing.Color.RoyalBlue;
            this.chkActiveWebUpload.Location = new System.Drawing.Point(42, 26);
            this.chkActiveWebUpload.Name = "chkActiveWebUpload";
            this.chkActiveWebUpload.Size = new System.Drawing.Size(100, 18);
            this.chkActiveWebUpload.TabIndex = 20;
            this.chkActiveWebUpload.Text = "Active Upload";
            this.chkActiveWebUpload.UseVisualStyleBackColor = true;
            // 
            // btnActiveDataUpload
            // 
            this.btnActiveDataUpload.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnActiveDataUpload.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnActiveDataUpload.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnActiveDataUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnActiveDataUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActiveDataUpload.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnActiveDataUpload.ForeColor = System.Drawing.Color.Navy;
            this.btnActiveDataUpload.Image = global::JobTracker.Properties.Resources.SaveHL;
            this.btnActiveDataUpload.Location = new System.Drawing.Point(241, 21);
            this.btnActiveDataUpload.Margin = new System.Windows.Forms.Padding(2);
            this.btnActiveDataUpload.Name = "btnActiveDataUpload";
            this.btnActiveDataUpload.Size = new System.Drawing.Size(31, 26);
            this.btnActiveDataUpload.TabIndex = 17;
            this.btnActiveDataUpload.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnActiveDataUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnActiveDataUpload.UseVisualStyleBackColor = false;
            this.btnActiveDataUpload.Click += new System.EventHandler(this.btnActiveDataUpload_Click);
            // 
            // grpDatabaseChange
            // 
            this.grpDatabaseChange.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDatabaseChange.BackColor = System.Drawing.Color.Transparent;
            this.grpDatabaseChange.Controls.Add(this.lblLocalConnectionstring);
            this.grpDatabaseChange.Controls.Add(this.btnSetConnectionString);
            this.grpDatabaseChange.Controls.Add(this.rdbIsLocalDatabase);
            this.grpDatabaseChange.Controls.Add(this.rdbIsServerDatabase);
            this.grpDatabaseChange.Controls.Add(this.btnChangesDataBase);
            this.grpDatabaseChange.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDatabaseChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.grpDatabaseChange.Location = new System.Drawing.Point(25, 568);
            this.grpDatabaseChange.Margin = new System.Windows.Forms.Padding(4);
            this.grpDatabaseChange.Name = "grpDatabaseChange";
            this.grpDatabaseChange.Padding = new System.Windows.Forms.Padding(2);
            this.grpDatabaseChange.Size = new System.Drawing.Size(704, 97);
            this.grpDatabaseChange.TabIndex = 27;
            this.grpDatabaseChange.TabStop = false;
            this.grpDatabaseChange.Text = "Change Database";
            // 
            // lblLocalConnectionstring
            // 
            this.lblLocalConnectionstring.AutoSize = true;
            this.lblLocalConnectionstring.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalConnectionstring.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblLocalConnectionstring.Location = new System.Drawing.Point(24, 60);
            this.lblLocalConnectionstring.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLocalConnectionstring.Name = "lblLocalConnectionstring";
            this.lblLocalConnectionstring.Size = new System.Drawing.Size(209, 18);
            this.lblLocalConnectionstring.TabIndex = 22;
            this.lblLocalConnectionstring.Text = "Current Local Connection String :";
            this.lblLocalConnectionstring.Visible = false;
            // 
            // btnSetConnectionString
            // 
            this.btnSetConnectionString.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSetConnectionString.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetConnectionString.Font = new System.Drawing.Font("Calibri", 9F);
            this.btnSetConnectionString.ForeColor = System.Drawing.Color.Navy;
            this.btnSetConnectionString.Location = new System.Drawing.Point(414, 23);
            this.btnSetConnectionString.Name = "btnSetConnectionString";
            this.btnSetConnectionString.Size = new System.Drawing.Size(207, 25);
            this.btnSetConnectionString.TabIndex = 20;
            this.btnSetConnectionString.Text = "Setup Local Connection Setting";
            this.btnSetConnectionString.UseVisualStyleBackColor = true;
            this.btnSetConnectionString.Visible = false;
            this.btnSetConnectionString.Click += new System.EventHandler(this.btnSetConnectionString_Click);
            // 
            // rdbIsLocalDatabase
            // 
            this.rdbIsLocalDatabase.AutoSize = true;
            this.rdbIsLocalDatabase.Font = new System.Drawing.Font("Calibri", 9F);
            this.rdbIsLocalDatabase.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rdbIsLocalDatabase.Location = new System.Drawing.Point(262, 25);
            this.rdbIsLocalDatabase.Name = "rdbIsLocalDatabase";
            this.rdbIsLocalDatabase.Size = new System.Drawing.Size(122, 18);
            this.rdbIsLocalDatabase.TabIndex = 19;
            this.rdbIsLocalDatabase.TabStop = true;
            this.rdbIsLocalDatabase.Text = "Is Local Database";
            this.rdbIsLocalDatabase.UseVisualStyleBackColor = true;
            this.rdbIsLocalDatabase.Click += new System.EventHandler(this.rdbIsLocalDatabase_CheckedChanged);
            // 
            // rdbIsServerDatabase
            // 
            this.rdbIsServerDatabase.AutoSize = true;
            this.rdbIsServerDatabase.Font = new System.Drawing.Font("Calibri", 9F);
            this.rdbIsServerDatabase.ForeColor = System.Drawing.Color.RoyalBlue;
            this.rdbIsServerDatabase.Location = new System.Drawing.Point(23, 25);
            this.rdbIsServerDatabase.Name = "rdbIsServerDatabase";
            this.rdbIsServerDatabase.Size = new System.Drawing.Size(127, 18);
            this.rdbIsServerDatabase.TabIndex = 18;
            this.rdbIsServerDatabase.TabStop = true;
            this.rdbIsServerDatabase.Text = "Is Server Database";
            this.rdbIsServerDatabase.UseVisualStyleBackColor = true;
            // 
            // btnChangesDataBase
            // 
            this.btnChangesDataBase.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnChangesDataBase.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnChangesDataBase.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnChangesDataBase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnChangesDataBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangesDataBase.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnChangesDataBase.ForeColor = System.Drawing.Color.Navy;
            this.btnChangesDataBase.Image = global::JobTracker.Properties.Resources.SaveHL;
            this.btnChangesDataBase.Location = new System.Drawing.Point(649, 20);
            this.btnChangesDataBase.Margin = new System.Windows.Forms.Padding(2);
            this.btnChangesDataBase.Name = "btnChangesDataBase";
            this.btnChangesDataBase.Size = new System.Drawing.Size(31, 26);
            this.btnChangesDataBase.TabIndex = 17;
            this.btnChangesDataBase.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnChangesDataBase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChangesDataBase.UseVisualStyleBackColor = false;
            this.btnChangesDataBase.Click += new System.EventHandler(this.btnChangesDataBase_Click);
            // 
            // frmAppSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JobTracker.Properties.Resources.FormBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(742, 667);
            this.Controls.Add(this.grpDatabaseChange);
            this.Controls.Add(this.GroupBox5);
            this.Controls.Add(this.GroupBox4);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.gboxBackup);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmAppSettings";
            this.Text = "Application Setting";
            this.Load += new System.EventHandler(this.frmBackup_Load);
            this.gboxBackup.ResumeLayout(false);
            this.gboxBackup.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.grpDatabaseChange.ResumeLayout(false);
            this.grpDatabaseChange.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.GroupBox gboxBackup;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label lblBakFileName;
        internal System.Windows.Forms.TextBox txtbakFilename;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label lblBakAddress;
        internal System.Windows.Forms.Button btnBakDatabase;
        internal System.Windows.Forms.ComboBox cmbDatabaseName;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.Button btnSaveEmailSetting;
        internal System.Windows.Forms.TextBox txtEmailpassword;
        internal System.Windows.Forms.TextBox txtEmailaddress;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.TextBox txtPasswordItem;
        internal System.Windows.Forms.Button btnSaveEmailPendingSetting;
        internal System.Windows.Forms.TextBox txtEmailAddressItem;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.CheckBox chkSSLInvoice;
        internal System.Windows.Forms.TextBox txtMailSeverInvoice;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.CheckBox ChkSSLItem;
        internal System.Windows.Forms.TextBox txtMailServerNameItem;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Button btnUpdateAgingDir;
        internal System.Windows.Forms.TextBox txtAgingPath;
        internal System.Windows.Forms.Label Label12;
        internal System.Windows.Forms.Button btnAgingLogfile;
        internal System.Windows.Forms.GroupBox GroupBox4;
        internal System.Windows.Forms.Button btnSaveSchedule;
        internal System.Windows.Forms.RadioButton rdbWeekly;
        internal System.Windows.Forms.RadioButton rdbDaily;
        internal System.Windows.Forms.CheckBox ChkSchedule;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.CheckBox chkActiveWebUpload;
        internal System.Windows.Forms.Button btnActiveDataUpload;
        internal System.Windows.Forms.GroupBox grpDatabaseChange;
        internal System.Windows.Forms.RadioButton rdbIsLocalDatabase;
        internal System.Windows.Forms.RadioButton rdbIsServerDatabase;
        internal System.Windows.Forms.Button btnChangesDataBase;
        internal System.Windows.Forms.Button btnSetConnectionString;
        internal System.Windows.Forms.Label lblLocalConnectionstring;

        #endregion
    }
}