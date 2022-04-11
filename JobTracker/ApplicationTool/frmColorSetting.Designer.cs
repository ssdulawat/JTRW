namespace JobTracker.Application_Tool
{
    partial class frmColorSetting
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
            this.gboxBackup = new System.Windows.Forms.GroupBox();
            this.grdColorSetting = new System.Windows.Forms.DataGridView();
            this.GrdUpdateBtn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColorDiosetting = new System.Windows.Forms.ColorDialog();
            this.colorMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.GreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.YellowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueToolScriptMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.grdColoeEmailDes = new System.Windows.Forms.DataGridView();
            this.DataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.gboxBackup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdColorSetting)).BeginInit();
            this.colorMenu.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdColoeEmailDes)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxBackup
            // 
            this.gboxBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBackup.BackColor = System.Drawing.Color.Transparent;
            this.gboxBackup.Controls.Add(this.grdColorSetting);
            this.gboxBackup.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.gboxBackup.Location = new System.Drawing.Point(22, 14);
            this.gboxBackup.Margin = new System.Windows.Forms.Padding(4);
            this.gboxBackup.Name = "gboxBackup";
            this.gboxBackup.Padding = new System.Windows.Forms.Padding(2);
            this.gboxBackup.Size = new System.Drawing.Size(707, 184);
            this.gboxBackup.TabIndex = 2;
            this.gboxBackup.TabStop = false;
            this.gboxBackup.Text = "Color";
            // 
            // grdColorSetting
            // 
            this.grdColorSetting.AllowUserToAddRows = false;
            this.grdColorSetting.AllowUserToDeleteRows = false;
            this.grdColorSetting.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdColorSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdColorSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GrdUpdateBtn});
            this.grdColorSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdColorSetting.Location = new System.Drawing.Point(2, 19);
            this.grdColorSetting.Margin = new System.Windows.Forms.Padding(2);
            this.grdColorSetting.Name = "grdColorSetting";
            this.grdColorSetting.RowTemplate.Height = 24;
            this.grdColorSetting.Size = new System.Drawing.Size(703, 163);
            this.grdColorSetting.TabIndex = 0;
            this.grdColorSetting.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdColorSetting_CellClick);
            this.grdColorSetting.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdColorSetting_CellFormatting);
            this.grdColorSetting.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grdColorSetting_CellMouseClick);
            // 
            // GrdUpdateBtn
            // 
            this.GrdUpdateBtn.Frozen = true;
            this.GrdUpdateBtn.HeaderText = "^";
            this.GrdUpdateBtn.Name = "GrdUpdateBtn";
            this.GrdUpdateBtn.Text = "^";
            this.GrdUpdateBtn.ToolTipText = "Update";
            this.GrdUpdateBtn.UseColumnTextForButtonValue = true;
            this.GrdUpdateBtn.Visible = false;
            this.GrdUpdateBtn.Width = 30;
            // 
            // ColorDiosetting
            // 
            this.ColorDiosetting.SolidColorOnly = true;
            // 
            // colorMenu
            // 
            this.colorMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.colorMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GreenToolStripMenuItem,
            this.YellowToolStripMenuItem,
            this.OrangeToolStripMenuItem,
            this.RedToolStripMenuItem,
            this.BlueToolScriptMenuItem});
            this.colorMenu.Name = "colorMenu";
            this.colorMenu.ShowImageMargin = false;
            this.colorMenu.Size = new System.Drawing.Size(89, 114);
            // 
            // GreenToolStripMenuItem
            // 
            this.GreenToolStripMenuItem.BackColor = System.Drawing.Color.Green;
            this.GreenToolStripMenuItem.Name = "GreenToolStripMenuItem";
            this.GreenToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.GreenToolStripMenuItem.Text = "Green";
            this.GreenToolStripMenuItem.Click += new System.EventHandler(this.GreenToolStripMenuItem_Click);
            // 
            // YellowToolStripMenuItem
            // 
            this.YellowToolStripMenuItem.BackColor = System.Drawing.Color.Yellow;
            this.YellowToolStripMenuItem.Name = "YellowToolStripMenuItem";
            this.YellowToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.YellowToolStripMenuItem.Text = "Yellow";
            this.YellowToolStripMenuItem.Click += new System.EventHandler(this.YellowToolStripMenuItem_Click);
            // 
            // OrangeToolStripMenuItem
            // 
            this.OrangeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.OrangeToolStripMenuItem.Name = "OrangeToolStripMenuItem";
            this.OrangeToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.OrangeToolStripMenuItem.Text = "Orange";
            this.OrangeToolStripMenuItem.Click += new System.EventHandler(this.OrangeToolStripMenuItem_Click);
            // 
            // RedToolStripMenuItem
            // 
            this.RedToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.RedToolStripMenuItem.Name = "RedToolStripMenuItem";
            this.RedToolStripMenuItem.Size = new System.Drawing.Size(88, 22);
            this.RedToolStripMenuItem.Text = "Red";
            this.RedToolStripMenuItem.Click += new System.EventHandler(this.RedToolStripMenuItem_Click);
            // 
            // BlueToolScriptMenuItem
            // 
            this.BlueToolScriptMenuItem.BackColor = System.Drawing.Color.Blue;
            this.BlueToolScriptMenuItem.Name = "BlueToolScriptMenuItem";
            this.BlueToolScriptMenuItem.Size = new System.Drawing.Size(88, 22);
            this.BlueToolScriptMenuItem.Text = "Blue";
            // 
            // GroupBox1
            // 
            this.GroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.grdColoeEmailDes);
            this.GroupBox1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.GroupBox1.Location = new System.Drawing.Point(21, 204);
            this.GroupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.GroupBox1.Size = new System.Drawing.Size(707, 241);
            this.GroupBox1.TabIndex = 3;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Color Email Description Setting";
            // 
            // grdColoeEmailDes
            // 
            this.grdColoeEmailDes.AllowUserToAddRows = false;
            this.grdColoeEmailDes.AllowUserToDeleteRows = false;
            this.grdColoeEmailDes.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdColoeEmailDes.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.grdColoeEmailDes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdColoeEmailDes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DataGridViewButtonColumn1});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdColoeEmailDes.DefaultCellStyle = dataGridViewCellStyle1;
            this.grdColoeEmailDes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdColoeEmailDes.Location = new System.Drawing.Point(2, 19);
            this.grdColoeEmailDes.Margin = new System.Windows.Forms.Padding(2);
            this.grdColoeEmailDes.Name = "grdColoeEmailDes";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdColoeEmailDes.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grdColoeEmailDes.RowTemplate.Height = 24;
            this.grdColoeEmailDes.Size = new System.Drawing.Size(703, 220);
            this.grdColoeEmailDes.TabIndex = 0;
            this.grdColoeEmailDes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdColoeEmailDes_CellClick);
            this.grdColoeEmailDes.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdColoeEmailDes_CellFormatting);
            // 
            // DataGridViewButtonColumn1
            // 
            this.DataGridViewButtonColumn1.Frozen = true;
            this.DataGridViewButtonColumn1.HeaderText = "^";
            this.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1";
            this.DataGridViewButtonColumn1.Text = "^";
            this.DataGridViewButtonColumn1.ToolTipText = "Update";
            this.DataGridViewButtonColumn1.UseColumnTextForButtonValue = true;
            this.DataGridViewButtonColumn1.Width = 30;
            // 
            // frmColorSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JobTracker.Properties.Resources.FormBack;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(742, 457);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.gboxBackup);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmColorSetting";
            this.Text = "Color Setting";
            this.Load += new System.EventHandler(this.frmColorSetting_Load);
            this.gboxBackup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdColorSetting)).EndInit();
            this.colorMenu.ResumeLayout(false);
            this.GroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdColoeEmailDes)).EndInit();
            this.ResumeLayout(false);

        }

        internal System.Windows.Forms.GroupBox gboxBackup;
        internal System.Windows.Forms.ColorDialog ColorDiosetting;
        internal System.Windows.Forms.ContextMenuStrip colorMenu;
        internal System.Windows.Forms.ToolStripMenuItem GreenToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem YellowToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem OrangeToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem RedToolStripMenuItem;
        internal System.Windows.Forms.DataGridView grdColorSetting;
        internal System.Windows.Forms.DataGridViewButtonColumn GrdUpdateBtn;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.DataGridView grdColoeEmailDes;
        internal System.Windows.Forms.DataGridViewButtonColumn DataGridViewButtonColumn1;
        internal System.Windows.Forms.ToolStripMenuItem BlueToolScriptMenuItem;

        #endregion
    }
}