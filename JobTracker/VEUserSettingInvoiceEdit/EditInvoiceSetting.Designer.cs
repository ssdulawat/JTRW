namespace JobTracker.VEUserSettingInvoiceEdit
{
    partial class EditInvoiceSetting
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
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.chkManagerApply = new System.Windows.Forms.CheckBox();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.chkItem = new System.Windows.Forms.CheckBox();
            this.chkExpenses = new System.Windows.Forms.CheckBox();
            this.chkTime = new System.Windows.Forms.CheckBox();
            this.chkConvertTimeSheet = new System.Windows.Forms.CheckBox();
            this.cmbConvertTimeSheet = new System.Windows.Forms.ComboBox();
            this.GroupBox2.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox2
            // 
            this.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GroupBox2.Controls.Add(this.chkManagerApply);
            this.GroupBox2.Controls.Add(this.btnSaveSetting);
            this.GroupBox2.Controls.Add(this.GroupBox7);
            this.GroupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GroupBox2.Location = new System.Drawing.Point(14, 12);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(747, 300);
            this.GroupBox2.TabIndex = 1;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Edit Invoice";
            // 
            // chkManagerApply
            // 
            this.chkManagerApply.AutoSize = true;
            this.chkManagerApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkManagerApply.Location = new System.Drawing.Point(21, 24);
            this.chkManagerApply.Name = "chkManagerApply";
            this.chkManagerApply.Size = new System.Drawing.Size(105, 17);
            this.chkManagerApply.TabIndex = 321;
            this.chkManagerApply.Text = "Apply Setting ";
            this.chkManagerApply.UseVisualStyleBackColor = true;
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSaveSetting.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveSetting.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSaveSetting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSaveSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveSetting.Font = new System.Drawing.Font("Calibri", 9.5F);
            this.btnSaveSetting.Location = new System.Drawing.Point(266, 250);
            this.btnSaveSetting.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(243, 45);
            this.btnSaveSetting.TabIndex = 320;
            this.btnSaveSetting.Text = "Click to Apply and   Save Setting";
            this.btnSaveSetting.UseVisualStyleBackColor = false;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnSaveSetting_Click);
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.chkItem);
            this.GroupBox7.Controls.Add(this.chkExpenses);
            this.GroupBox7.Controls.Add(this.chkTime);
            this.GroupBox7.Controls.Add(this.chkConvertTimeSheet);
            this.GroupBox7.Controls.Add(this.cmbConvertTimeSheet);
            this.GroupBox7.Location = new System.Drawing.Point(162, 59);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(493, 186);
            this.GroupBox7.TabIndex = 2;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "Change Convert Associted Time ";
            // 
            // chkItem
            // 
            this.chkItem.AutoSize = true;
            this.chkItem.Location = new System.Drawing.Point(159, 59);
            this.chkItem.Name = "chkItem";
            this.chkItem.Size = new System.Drawing.Size(46, 17);
            this.chkItem.TabIndex = 288;
            this.chkItem.Text = "Item";
            this.chkItem.UseVisualStyleBackColor = true;
            // 
            // chkExpenses
            // 
            this.chkExpenses.AutoSize = true;
            this.chkExpenses.Location = new System.Drawing.Point(159, 116);
            this.chkExpenses.Name = "chkExpenses";
            this.chkExpenses.Size = new System.Drawing.Size(72, 17);
            this.chkExpenses.TabIndex = 287;
            this.chkExpenses.Text = "Expenses";
            this.chkExpenses.UseVisualStyleBackColor = true;
            // 
            // chkTime
            // 
            this.chkTime.AutoSize = true;
            this.chkTime.Location = new System.Drawing.Point(159, 88);
            this.chkTime.Name = "chkTime";
            this.chkTime.Size = new System.Drawing.Size(52, 17);
            this.chkTime.TabIndex = 286;
            this.chkTime.Text = "Time ";
            this.chkTime.UseVisualStyleBackColor = true;
            // 
            // chkConvertTimeSheet
            // 
            this.chkConvertTimeSheet.AutoSize = true;
            this.chkConvertTimeSheet.Location = new System.Drawing.Point(159, 31);
            this.chkConvertTimeSheet.Name = "chkConvertTimeSheet";
            this.chkConvertTimeSheet.Size = new System.Drawing.Size(172, 17);
            this.chkConvertTimeSheet.TabIndex = 285;
            this.chkConvertTimeSheet.Text = "Convert Associted Time Sheet ";
            this.chkConvertTimeSheet.UseVisualStyleBackColor = true;
            // 
            // cmbConvertTimeSheet
            // 
            this.cmbConvertTimeSheet.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.cmbConvertTimeSheet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbConvertTimeSheet.Items.AddRange(new object[] {
            "Invoice",
            "Not Invoice",
            "Ignore"});
            this.cmbConvertTimeSheet.Location = new System.Drawing.Point(161, 145);
            this.cmbConvertTimeSheet.Margin = new System.Windows.Forms.Padding(2);
            this.cmbConvertTimeSheet.Name = "cmbConvertTimeSheet";
            this.cmbConvertTimeSheet.Size = new System.Drawing.Size(116, 21);
            this.cmbConvertTimeSheet.TabIndex = 281;
            // 
            // EditInvoiceSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(779, 343);
            this.Controls.Add(this.GroupBox2);
            this.Name = "EditInvoiceSetting";
            this.Text = "EditInvoiceSetting";
            this.Load += new System.EventHandler(this.EditInvoiceSetting_Load);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox7.PerformLayout();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.GroupBox GroupBox2;
        internal System.Windows.Forms.CheckBox chkManagerApply;
        internal System.Windows.Forms.Button btnSaveSetting;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.ComboBox cmbConvertTimeSheet;
        internal System.Windows.Forms.CheckBox chkExpenses;
        internal System.Windows.Forms.CheckBox chkTime;
        internal System.Windows.Forms.CheckBox chkConvertTimeSheet;
        internal System.Windows.Forms.CheckBox chkItem;


        #endregion
    }
}