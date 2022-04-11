namespace JobTracker.JobTrackingForm
{
    partial class frmCraneInfo
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlCraneControl = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.GrpSearch = new System.Windows.Forms.GroupBox();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtOwner = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.txtMake = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtCDNum = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtCapacity = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.grdCDcrane = new System.Windows.Forms.DataGridView();
            this.GrdPreRequireUpdate = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GrdDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tblLaypnlcrane = new System.Windows.Forms.TableLayoutPanel();
            this.pnlCraneControl.SuspendLayout();
            this.GrpSearch.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCDcrane)).BeginInit();
            this.tblLaypnlcrane.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlCraneControl
            // 
            this.pnlCraneControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCraneControl.BackColor = System.Drawing.Color.Transparent;
            this.pnlCraneControl.Controls.Add(this.btnClear);
            this.pnlCraneControl.Controls.Add(this.btnCancel);
            this.pnlCraneControl.Controls.Add(this.btnSave);
            this.pnlCraneControl.Controls.Add(this.GrpSearch);
            this.pnlCraneControl.Location = new System.Drawing.Point(3, 3);
            this.pnlCraneControl.Name = "pnlCraneControl";
            this.pnlCraneControl.Size = new System.Drawing.Size(1836, 93);
            this.pnlCraneControl.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Location = new System.Drawing.Point(725, 55);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(81, 30);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnCancel.Location = new System.Drawing.Point(630, 55);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 30);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.RoyalBlue;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 10F);
            this.btnSave.Location = new System.Drawing.Point(535, 55);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Insert";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // GrpSearch
            // 
            this.GrpSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.GrpSearch.Controls.Add(this.txtSerial);
            this.GrpSearch.Controls.Add(this.Label6);
            this.GrpSearch.Controls.Add(this.txtOwner);
            this.GrpSearch.Controls.Add(this.Label5);
            this.GrpSearch.Controls.Add(this.txtModel);
            this.GrpSearch.Controls.Add(this.Label4);
            this.GrpSearch.Controls.Add(this.txtMake);
            this.GrpSearch.Controls.Add(this.Label3);
            this.GrpSearch.Controls.Add(this.txtCDNum);
            this.GrpSearch.Controls.Add(this.Label2);
            this.GrpSearch.Controls.Add(this.txtCapacity);
            this.GrpSearch.Controls.Add(this.Label1);
            this.GrpSearch.Font = new System.Drawing.Font("Calibri", 9F);
            this.GrpSearch.ForeColor = System.Drawing.Color.Maroon;
            this.GrpSearch.Location = new System.Drawing.Point(534, 4);
            this.GrpSearch.Name = "GrpSearch";
            this.GrpSearch.Size = new System.Drawing.Size(766, 46);
            this.GrpSearch.TabIndex = 0;
            this.GrpSearch.TabStop = false;
            this.GrpSearch.Text = "Search";
            // 
            // txtSerial
            // 
            this.txtSerial.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtSerial.Location = new System.Drawing.Point(705, 15);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(55, 22);
            this.txtSerial.TabIndex = 6;
            this.txtSerial.TextChanged += new System.EventHandler(this.txtCapacity_TextChanged);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label6.Location = new System.Drawing.Point(661, 19);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(39, 14);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "Serial";
            // 
            // txtOwner
            // 
            this.txtOwner.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOwner.Location = new System.Drawing.Point(576, 15);
            this.txtOwner.Name = "txtOwner";
            this.txtOwner.Size = new System.Drawing.Size(79, 22);
            this.txtOwner.TabIndex = 5;
            this.txtOwner.TextChanged += new System.EventHandler(this.txtCapacity_TextChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(530, 19);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(42, 14);
            this.Label5.TabIndex = 8;
            this.Label5.Text = "Owner";
            // 
            // txtModel
            // 
            this.txtModel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtModel.Location = new System.Drawing.Point(447, 15);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(76, 22);
            this.txtModel.TabIndex = 4;
            this.txtModel.TextChanged += new System.EventHandler(this.txtCapacity_TextChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(401, 19);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(42, 14);
            this.Label4.TabIndex = 6;
            this.Label4.Text = "Model";
            // 
            // txtMake
            // 
            this.txtMake.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtMake.Location = new System.Drawing.Point(319, 15);
            this.txtMake.Name = "txtMake";
            this.txtMake.Size = new System.Drawing.Size(76, 22);
            this.txtMake.TabIndex = 3;
            this.txtMake.TextChanged += new System.EventHandler(this.txtCapacity_TextChanged);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(276, 19);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(37, 14);
            this.Label3.TabIndex = 4;
            this.Label3.Text = "Make";
            // 
            // txtCDNum
            // 
            this.txtCDNum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCDNum.Location = new System.Drawing.Point(209, 15);
            this.txtCDNum.Name = "txtCDNum";
            this.txtCDNum.Size = new System.Drawing.Size(61, 22);
            this.txtCDNum.TabIndex = 2;
            this.txtCDNum.TextChanged += new System.EventHandler(this.txtCapacity_TextChanged);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(152, 19);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(52, 14);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "CD_Num";
            // 
            // txtCapacity
            // 
            this.txtCapacity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCapacity.Location = new System.Drawing.Point(62, 15);
            this.txtCapacity.Name = "txtCapacity";
            this.txtCapacity.Size = new System.Drawing.Size(86, 22);
            this.txtCapacity.TabIndex = 1;
            this.txtCapacity.TextChanged += new System.EventHandler(this.txtCapacity_TextChanged);
            this.txtCapacity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCapacity_KeyPress);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(5, 19);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(52, 14);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Capacity";
            // 
            // pnlGrid
            // 
            this.pnlGrid.AutoScroll = true;
            this.pnlGrid.Controls.Add(this.grdCDcrane);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrid.Location = new System.Drawing.Point(3, 102);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Size = new System.Drawing.Size(1836, 833);
            this.pnlGrid.TabIndex = 2;
            // 
            // grdCDcrane
            // 
            this.grdCDcrane.AllowUserToAddRows = false;
            this.grdCDcrane.BackgroundColor = global::JobTracker.Properties.Settings.Default.GridBackColor;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCDcrane.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCDcrane.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCDcrane.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GrdPreRequireUpdate,
            this.GrdDelete});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(207)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCDcrane.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdCDcrane.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.grdCDcrane.Location = new System.Drawing.Point(98, 2);
            this.grdCDcrane.Margin = new System.Windows.Forms.Padding(2);
            this.grdCDcrane.MultiSelect = false;
            this.grdCDcrane.Name = "grdCDcrane";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(243)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCDcrane.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdCDcrane.RowTemplate.Height = 24;
            this.grdCDcrane.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdCDcrane.Size = new System.Drawing.Size(1711, 809);
            this.grdCDcrane.TabIndex = 0;
            this.grdCDcrane.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.grdCDcrane_CellBeginEdit);
            this.grdCDcrane.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCDcrane_CellClick);
            this.grdCDcrane.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCDcrane_CellEndEdit);
            this.grdCDcrane.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdCDcrane_CellFormatting);
            this.grdCDcrane.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdCDcrane_RowHeaderMouseDoubleClick);
            // 
            // GrdPreRequireUpdate
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.GrdPreRequireUpdate.DefaultCellStyle = dataGridViewCellStyle2;
            this.GrdPreRequireUpdate.Frozen = true;
            this.GrdPreRequireUpdate.HeaderText = "^";
            this.GrdPreRequireUpdate.Name = "GrdPreRequireUpdate";
            this.GrdPreRequireUpdate.Text = "^";
            this.GrdPreRequireUpdate.UseColumnTextForButtonValue = true;
            this.GrdPreRequireUpdate.Width = 30;
            // 
            // GrdDelete
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.GrdDelete.DefaultCellStyle = dataGridViewCellStyle3;
            this.GrdDelete.Frozen = true;
            this.GrdDelete.HeaderText = "X";
            this.GrdDelete.Name = "GrdDelete";
            this.GrdDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GrdDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.GrdDelete.Text = "X";
            this.GrdDelete.UseColumnTextForButtonValue = true;
            this.GrdDelete.Width = 30;
            // 
            // tblLaypnlcrane
            // 
            this.tblLaypnlcrane.ColumnCount = 1;
            this.tblLaypnlcrane.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLaypnlcrane.Controls.Add(this.pnlGrid, 0, 1);
            this.tblLaypnlcrane.Controls.Add(this.pnlCraneControl, 0, 0);
            this.tblLaypnlcrane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblLaypnlcrane.Location = new System.Drawing.Point(0, 0);
            this.tblLaypnlcrane.Name = "tblLaypnlcrane";
            this.tblLaypnlcrane.RowCount = 2;
            this.tblLaypnlcrane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 99F));
            this.tblLaypnlcrane.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblLaypnlcrane.Size = new System.Drawing.Size(1842, 938);
            this.tblLaypnlcrane.TabIndex = 3;
            // 
            // frmCraneInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(228)))), ((int)(((byte)(250)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1842, 938);
            this.Controls.Add(this.tblLaypnlcrane);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmCraneInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crane Info";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCraneInfo_FormClosing);
            this.Load += new System.EventHandler(this.frmCraneInfo_Load);
            this.pnlCraneControl.ResumeLayout(false);
            this.GrpSearch.ResumeLayout(false);
            this.GrpSearch.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCDcrane)).EndInit();
            this.tblLaypnlcrane.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        internal System.Windows.Forms.Panel pnlCraneControl;
        internal System.Windows.Forms.GroupBox GrpSearch;
        internal System.Windows.Forms.TextBox txtMake;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtCDNum;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox txtCapacity;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox txtOwner;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox txtModel;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.TextBox txtSerial;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Button btnSave;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Panel pnlGrid;
        internal System.Windows.Forms.DataGridView grdCDcrane;
        internal System.Windows.Forms.TableLayoutPanel tblLaypnlcrane;
        internal System.Windows.Forms.Button btnClear;
        #endregion

        private System.Windows.Forms.DataGridViewButtonColumn GrdPreRequireUpdate;
        private System.Windows.Forms.DataGridViewButtonColumn GrdDelete;
    }
}