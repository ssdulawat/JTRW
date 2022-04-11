namespace JTUpdater
{
    partial class frmUpdateJT
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
            this.btnUpdateJT = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdateJT
            // 
            this.btnUpdateJT.Location = new System.Drawing.Point(151, 109);
            this.btnUpdateJT.Name = "btnUpdateJT";
            this.btnUpdateJT.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateJT.TabIndex = 0;
            this.btnUpdateJT.Text = "JT Update";
            this.btnUpdateJT.UseVisualStyleBackColor = true;
            this.btnUpdateJT.Click += new System.EventHandler(this.btnUpdateJT_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(92, 22);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(326, 20);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Do you want to Update the application. ";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(100, 68);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(307, 16);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "(Please press JT Update button for update)";
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(266, 109);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(75, 23);
            this.btncancel.TabIndex = 3;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // frmUpdateJT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(490, 200);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnUpdateJT);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(498, 231);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(498, 231);
            this.Name = "frmUpdateJT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UpdateJT";
            this.Load += new System.EventHandler(this.frmUpdateJT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Button btnUpdateJT;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Button btncancel;


		#endregion
	}
}

