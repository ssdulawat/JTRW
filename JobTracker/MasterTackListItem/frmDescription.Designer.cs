namespace JobTracker.MasterTackListItem
{
    partial class frmDescription
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
            this.Label2 = new System.Windows.Forms.Label();
            this.txtTrack = new System.Windows.Forms.TextBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.grdListitem = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnremove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSearchJobDecrp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdListitem)).BeginInit();
            this.SuspendLayout();
            // 
            // Label2
            // 
            this.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(230, 99);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(60, 13);
            this.Label2.TabIndex = 3;
            this.Label2.Text = "Description";
            this.Label2.Visible = false;
            // 
            // txtTrack
            // 
            this.txtTrack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtTrack.Location = new System.Drawing.Point(296, 96);
            this.txtTrack.Margin = new System.Windows.Forms.Padding(2);
            this.txtTrack.Name = "txtTrack";
            this.txtTrack.Size = new System.Drawing.Size(153, 20);
            this.txtTrack.TabIndex = 4;
            this.txtTrack.Visible = false;
            this.txtTrack.TextChanged += new System.EventHandler(this.txtTrack_TextChanged);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Location = new System.Drawing.Point(463, 95);
            this.btnadd.Margin = new System.Windows.Forms.Padding(2);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(59, 22);
            this.btnadd.TabIndex = 5;
            this.btnadd.Text = "Insert";
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // grdListitem
            // 
            this.grdListitem.AllowUserToAddRows = false;
            this.grdListitem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdListitem.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdListitem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdListitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdListitem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnEdit,
            this.btnremove});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdListitem.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdListitem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdListitem.Location = new System.Drawing.Point(9, 124);
            this.grdListitem.Margin = new System.Windows.Forms.Padding(2);
            this.grdListitem.Name = "grdListitem";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdListitem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdListitem.RowTemplate.Height = 24;
            this.grdListitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdListitem.Size = new System.Drawing.Size(580, 468);
            this.grdListitem.TabIndex = 6;
            this.grdListitem.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdListitem_CellBeginEdit);
            this.grdListitem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdListitem_CellClick);
            this.grdListitem.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdListitem_CellEndEdit);
            // 
            // btnEdit
            // 
            this.btnEdit.Frozen = true;
            this.btnEdit.HeaderText = "^";
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.ReadOnly = true;
            this.btnEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.btnEdit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnEdit.Text = "^";
            this.btnEdit.UseColumnTextForButtonValue = true;
            this.btnEdit.Width = 30;
            // 
            // btnremove
            // 
            this.btnremove.Frozen = true;
            this.btnremove.HeaderText = "X";
            this.btnremove.Name = "btnremove";
            this.btnremove.ReadOnly = true;
            this.btnremove.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnremove.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnremove.Text = "X";
            this.btnremove.UseColumnTextForButtonValue = true;
            this.btnremove.Width = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(530, 95);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 22);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.Location = new System.Drawing.Point(11, 98);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(51, 13);
            this.Label3.TabIndex = 8;
            this.Label3.Text = "Search:";
            // 
            // txtSearchJobDecrp
            // 
            this.txtSearchJobDecrp.Location = new System.Drawing.Point(64, 96);
            this.txtSearchJobDecrp.Name = "txtSearchJobDecrp";
            this.txtSearchJobDecrp.Size = new System.Drawing.Size(141, 20);
            this.txtSearchJobDecrp.TabIndex = 9;
            this.txtSearchJobDecrp.TextChanged += new System.EventHandler(this.txtSearchJobDecrp_TextChanged);
            // 
            // frmDescription
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(598, 602);
            this.Controls.Add(this.txtSearchJobDecrp);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grdListitem);
            this.Controls.Add(this.btnadd);
            this.Controls.Add(this.txtTrack);
            this.Controls.Add(this.Label2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "frmDescription";
            this.Text = "Job Description";
            this.Load += new System.EventHandler(this.frmDescription_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListitem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtTrack;
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.DataGridView grdListitem;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        internal System.Windows.Forms.DataGridViewButtonColumn btnremove;
        internal System.Windows.Forms.TextBox txtSearchJobDecrp;
        #endregion
    }
}