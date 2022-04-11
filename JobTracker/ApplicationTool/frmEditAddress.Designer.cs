namespace JobTracker.Application_Tool
{
    partial class frmEditAddress
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.btnSaveAddress = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.gboxBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxBackup
            // 
            this.gboxBackup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBackup.BackColor = System.Drawing.Color.Transparent;
            this.gboxBackup.Controls.Add(this.txtAddress);
            this.gboxBackup.Controls.Add(this.Label3);
            this.gboxBackup.Controls.Add(this.txtFaxNo);
            this.gboxBackup.Controls.Add(this.btnSaveAddress);
            this.gboxBackup.Controls.Add(this.Label2);
            this.gboxBackup.Controls.Add(this.txtPhoneNo);
            this.gboxBackup.Controls.Add(this.Label1);
            this.gboxBackup.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gboxBackup.Location = new System.Drawing.Point(25, 12);
            this.gboxBackup.Margin = new System.Windows.Forms.Padding(4);
            this.gboxBackup.Name = "gboxBackup";
            this.gboxBackup.Padding = new System.Windows.Forms.Padding(2);
            this.gboxBackup.Size = new System.Drawing.Size(697, 202);
            this.gboxBackup.TabIndex = 2;
            this.gboxBackup.TabStop = false;
            this.gboxBackup.Text = "Edit Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtAddress.Location = new System.Drawing.Point(118, 22);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(2);
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(180, 104);
            this.txtAddress.TabIndex = 23;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.Label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label3.Location = new System.Drawing.Point(45, 22);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(51, 15);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Address";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtFaxNo.Location = new System.Drawing.Point(429, 49);
            this.txtFaxNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(149, 23);
            this.txtFaxNo.TabIndex = 21;
            // 
            // btnSaveAddress
            // 
            this.btnSaveAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveAddress.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveAddress.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSaveAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveAddress.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSaveAddress.ForeColor = System.Drawing.Color.Navy;
            this.btnSaveAddress.Image = global::JobTracker.Properties.Resources.SaveHL;
            this.btnSaveAddress.Location = new System.Drawing.Point(430, 117);
            this.btnSaveAddress.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveAddress.Name = "btnSaveAddress";
            this.btnSaveAddress.Size = new System.Drawing.Size(148, 26);
            this.btnSaveAddress.TabIndex = 20;
            this.btnSaveAddress.Text = "Save Address";
            this.btnSaveAddress.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnSaveAddress.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSaveAddress.UseVisualStyleBackColor = false;
            this.btnSaveAddress.Click += new System.EventHandler(this.btnSaveAddress_Click);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.Label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label2.Location = new System.Drawing.Point(342, 49);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(47, 15);
            this.Label2.TabIndex = 4;
            this.Label2.Text = "Fax No.";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.txtPhoneNo.Location = new System.Drawing.Point(429, 19);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(2);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(149, 23);
            this.txtPhoneNo.TabIndex = 1;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.Label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.Label1.Location = new System.Drawing.Point(342, 22);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(62, 15);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Phone No.";
            // 
            // frmEditAddress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JobTracker.Properties.Resources.FormBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(742, 227);
            this.Controls.Add(this.gboxBackup);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmEditAddress";
            this.Text = "Address Setting";
            this.Load += new System.EventHandler(this.frmEditAddress_Load);
            this.gboxBackup.ResumeLayout(false);
            this.gboxBackup.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.GroupBox gboxBackup;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtFaxNo;
        internal System.Windows.Forms.Button btnSaveAddress;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label Label3;
        #endregion
    }
}