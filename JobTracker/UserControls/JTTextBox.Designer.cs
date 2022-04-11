namespace JobTracker.UserControls
{
    partial class JTTextBox : System.Windows.Forms.UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtJT = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtJT
            // 
            this.txtJT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtJT.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtJT.Location = new System.Drawing.Point(0, 0);
            this.txtJT.Name = "txtJT";
            this.txtJT.Size = new System.Drawing.Size(153, 23);
            this.txtJT.TabIndex = 0;
            this.txtJT.Click += new System.EventHandler(this.txtJT_Click);
            this.txtJT.TextChanged += new System.EventHandler(this.txtJT_TextChanged);
            // 
            // JTTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtJT);
            this.Name = "JTTextBox";
            this.Size = new System.Drawing.Size(153, 23);
            this.Click += new System.EventHandler(this.JTTextBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.TextBox txtJT;

        #endregion
    }
}
