namespace JobTracker.MasterTackListItem
{
    partial class frmDocTypicalTxtList
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
            this.btnadd = new System.Windows.Forms.Button();
            this.grdListitem = new System.Windows.Forms.DataGridView();
            this.btnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnremove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tblLytPnlControl = new System.Windows.Forms.TableLayoutPanel();
            this.pnlListItem = new System.Windows.Forms.Panel();
            this.btnInsertDocTypicalText = new System.Windows.Forms.Button();
            this.btnCanceDocTypicalText = new System.Windows.Forms.Button();
            this.pnlCategory = new System.Windows.Forms.Panel();
            this.grdDocTypeCategory = new System.Windows.Forms.DataGridView();
            this.DataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdListitem)).BeginInit();
            this.tblLytPnlControl.SuspendLayout();
            this.pnlListItem.SuspendLayout();
            this.pnlCategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocTypeCategory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnadd
            // 
            this.btnadd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnadd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Location = new System.Drawing.Point(6, 41);
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
            this.grdListitem.Location = new System.Drawing.Point(-1, 76);
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
            this.grdListitem.Size = new System.Drawing.Size(450, 643);
            this.grdListitem.TabIndex = 6;
            this.grdListitem.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdListitem_CellBeginEdit);
            this.grdListitem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdListitem_CellClick);
            this.grdListitem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdListitem_CellContentClick);
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
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(80, 41);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(59, 22);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tblLytPnlControl
            // 
            this.tblLytPnlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblLytPnlControl.ColumnCount = 2;
            this.tblLytPnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLytPnlControl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLytPnlControl.Controls.Add(this.pnlListItem, 1, 0);
            this.tblLytPnlControl.Controls.Add(this.pnlCategory, 0, 0);
            this.tblLytPnlControl.Location = new System.Drawing.Point(2, 0);
            this.tblLytPnlControl.Name = "tblLytPnlControl";
            this.tblLytPnlControl.RowCount = 1;
            this.tblLytPnlControl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblLytPnlControl.Size = new System.Drawing.Size(914, 727);
            this.tblLytPnlControl.TabIndex = 9;
            // 
            // pnlListItem
            // 
            this.pnlListItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlListItem.Controls.Add(this.btnInsertDocTypicalText);
            this.pnlListItem.Controls.Add(this.btnCanceDocTypicalText);
            this.pnlListItem.Controls.Add(this.grdListitem);
            this.pnlListItem.Location = new System.Drawing.Point(460, 3);
            this.pnlListItem.Name = "pnlListItem";
            this.pnlListItem.Size = new System.Drawing.Size(451, 721);
            this.pnlListItem.TabIndex = 1;
            // 
            // btnInsertDocTypicalText
            // 
            this.btnInsertDocTypicalText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnInsertDocTypicalText.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnInsertDocTypicalText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertDocTypicalText.Location = new System.Drawing.Point(10, 41);
            this.btnInsertDocTypicalText.Margin = new System.Windows.Forms.Padding(2);
            this.btnInsertDocTypicalText.Name = "btnInsertDocTypicalText";
            this.btnInsertDocTypicalText.Size = new System.Drawing.Size(59, 22);
            this.btnInsertDocTypicalText.TabIndex = 8;
            this.btnInsertDocTypicalText.Text = "Insert";
            this.btnInsertDocTypicalText.UseVisualStyleBackColor = false;
            this.btnInsertDocTypicalText.Click += new System.EventHandler(this.btnInsertDocTypicalText_Click);
            // 
            // btnCanceDocTypicalText
            // 
            this.btnCanceDocTypicalText.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCanceDocTypicalText.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCanceDocTypicalText.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCanceDocTypicalText.Location = new System.Drawing.Point(84, 41);
            this.btnCanceDocTypicalText.Margin = new System.Windows.Forms.Padding(2);
            this.btnCanceDocTypicalText.Name = "btnCanceDocTypicalText";
            this.btnCanceDocTypicalText.Size = new System.Drawing.Size(59, 22);
            this.btnCanceDocTypicalText.TabIndex = 9;
            this.btnCanceDocTypicalText.Text = "Cancel";
            this.btnCanceDocTypicalText.UseVisualStyleBackColor = false;
            this.btnCanceDocTypicalText.Click += new System.EventHandler(this.btnCanceDocTypicalText_Click);
            // 
            // pnlCategory
            // 
            this.pnlCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCategory.Controls.Add(this.grdDocTypeCategory);
            this.pnlCategory.Controls.Add(this.btnadd);
            this.pnlCategory.Controls.Add(this.btnCancel);
            this.pnlCategory.Location = new System.Drawing.Point(3, 3);
            this.pnlCategory.Name = "pnlCategory";
            this.pnlCategory.Size = new System.Drawing.Size(451, 721);
            this.pnlCategory.TabIndex = 0;
            // 
            // grdDocTypeCategory
            // 
            this.grdDocTypeCategory.AllowUserToAddRows = false;
            this.grdDocTypeCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDocTypeCategory.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDocTypeCategory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdDocTypeCategory.ColumnHeadersHeight = 30;
            this.grdDocTypeCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewButtonColumn1});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdDocTypeCategory.DefaultCellStyle = dataGridViewCellStyle5;
            this.grdDocTypeCategory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdDocTypeCategory.Location = new System.Drawing.Point(0, 76);
            this.grdDocTypeCategory.Margin = new System.Windows.Forms.Padding(2);
            this.grdDocTypeCategory.Name = "grdDocTypeCategory";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdDocTypeCategory.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdDocTypeCategory.RowTemplate.Height = 24;
            this.grdDocTypeCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdDocTypeCategory.Size = new System.Drawing.Size(450, 643);
            this.grdDocTypeCategory.TabIndex = 7;
            this.grdDocTypeCategory.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocTypeCategory_CellClick);
            // 
            // DataGridViewButtonColumn1
            // 
            this.DataGridViewButtonColumn1.Frozen = true;
            this.DataGridViewButtonColumn1.HeaderText = "^";
            this.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1";
            this.DataGridViewButtonColumn1.ReadOnly = true;
            this.DataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataGridViewButtonColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DataGridViewButtonColumn1.Text = "^";
            this.DataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.DataGridViewButtonColumn1.Width = 30;
            // 
            // frmDocTypicalTxtList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(918, 729);
            this.Controls.Add(this.tblLytPnlControl);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimizeBox = false;
            this.Name = "frmDocTypicalTxtList";
            this.Text = "DOC Typical Text";
            this.Load += new System.EventHandler(this.frmDocTypicalTxtList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdListitem)).EndInit();
            this.tblLytPnlControl.ResumeLayout(false);
            this.pnlListItem.ResumeLayout(false);
            this.pnlCategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDocTypeCategory)).EndInit();
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Button btnadd;
        internal System.Windows.Forms.DataGridView grdListitem;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TableLayoutPanel tblLytPnlControl;
        internal System.Windows.Forms.Panel pnlListItem;
        internal System.Windows.Forms.Panel pnlCategory;
        internal System.Windows.Forms.DataGridView grdDocTypeCategory;
        internal System.Windows.Forms.Button btnInsertDocTypicalText;
        internal System.Windows.Forms.Button btnCanceDocTypicalText;
        internal System.Windows.Forms.DataGridViewButtonColumn DataGridViewButtonColumn1;
        internal System.Windows.Forms.DataGridViewButtonColumn btnEdit;
        internal System.Windows.Forms.DataGridViewButtonColumn btnremove;
        #endregion
    }
}