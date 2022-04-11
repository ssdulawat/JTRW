namespace ExpTree_Demo_CS
{
    partial class frmThreadCS : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThreadCS));
            this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslMiddle = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmallIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciontextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
            this.ExpTree1 = new ExpTreeLib.ExpTree();
            this.lv1 = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTypeStr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chAttributes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCreated = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.StatusStrip1.SuspendLayout();
            this.MenuStrip1.SuspendLayout();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SplitContainer2.Panel1.SuspendLayout();
            this.SplitContainer2.Panel2.SuspendLayout();
            this.SplitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusStrip1
            // 
            this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslLeft,
            this.tsslMiddle,
            this.tsslRight});
            this.StatusStrip1.Location = new System.Drawing.Point(0, 511);
            this.StatusStrip1.Name = "StatusStrip1";
            this.StatusStrip1.Size = new System.Drawing.Size(934, 22);
            this.StatusStrip1.TabIndex = 6;
            this.StatusStrip1.Text = "StatusStrip1";
            // 
            // tsslLeft
            // 
            this.tsslLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslLeft.Name = "tsslLeft";
            this.tsslLeft.Size = new System.Drawing.Size(39, 17);
            this.tsslLeft.Text = "Ready";
            // 
            // tsslMiddle
            // 
            this.tsslMiddle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslMiddle.Name = "tsslMiddle";
            this.tsslMiddle.Size = new System.Drawing.Size(880, 17);
            this.tsslMiddle.Spring = true;
            // 
            // tsslRight
            // 
            this.tsslRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsslRight.Name = "tsslRight";
            this.tsslRight.Size = new System.Drawing.Size(0, 17);
            // 
            // MenuStrip1
            // 
            this.MenuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.ViewToolStripMenuItem,
            this.ciontextToolStripMenuItem});
            this.MenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip1.Name = "MenuStrip1";
            this.MenuStrip1.Size = new System.Drawing.Size(934, 24);
            this.MenuStrip1.TabIndex = 5;
            this.MenuStrip1.Text = "MenuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.FileToolStripMenuItem.Text = "&File";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.ExitToolStripMenuItem.Text = "E&xit";
            // 
            // ViewToolStripMenuItem
            // 
            this.ViewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DetailsToolStripMenuItem,
            this.ListToolStripMenuItem,
            this.LargeIconsToolStripMenuItem,
            this.SmallIconsToolStripMenuItem,
            this.TileToolStripMenuItem});
            this.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem";
            this.ViewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ViewToolStripMenuItem.Text = "&View";
            // 
            // DetailsToolStripMenuItem
            // 
            this.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem";
            this.DetailsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.DetailsToolStripMenuItem.Text = "&Details";
            // 
            // ListToolStripMenuItem
            // 
            this.ListToolStripMenuItem.Name = "ListToolStripMenuItem";
            this.ListToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.ListToolStripMenuItem.Text = "&List";
            // 
            // LargeIconsToolStripMenuItem
            // 
            this.LargeIconsToolStripMenuItem.Name = "LargeIconsToolStripMenuItem";
            this.LargeIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.LargeIconsToolStripMenuItem.Text = "Lar&ge Icons";
            this.LargeIconsToolStripMenuItem.Click += new System.EventHandler(this.LargeIconsToolStripMenuItem_Click);
            // 
            // SmallIconsToolStripMenuItem
            // 
            this.SmallIconsToolStripMenuItem.Name = "SmallIconsToolStripMenuItem";
            this.SmallIconsToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.SmallIconsToolStripMenuItem.Text = "S&mall Icons";
            // 
            // TileToolStripMenuItem
            // 
            this.TileToolStripMenuItem.Name = "TileToolStripMenuItem";
            this.TileToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.TileToolStripMenuItem.Text = "&Tile";
            // 
            // ciontextToolStripMenuItem
            // 
            this.ciontextToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.ciontextToolStripMenuItem.Name = "ciontextToolStripMenuItem";
            this.ciontextToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.ciontextToolStripMenuItem.Text = "Ciontext";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer1.Location = new System.Drawing.Point(0, 24);
            this.SplitContainer1.Name = "SplitContainer1";
            this.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.SplitContainer2);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.button3);
            this.SplitContainer1.Panel2.Controls.Add(this.button2);
            this.SplitContainer1.Panel2.Controls.Add(this.button1);
            this.SplitContainer1.Panel2.Controls.Add(this.Label1);
            this.SplitContainer1.Size = new System.Drawing.Size(934, 487);
            this.SplitContainer1.SplitterDistance = 399;
            this.SplitContainer1.TabIndex = 7;
            // 
            // SplitContainer2
            // 
            this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer2.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer2.Name = "SplitContainer2";
            // 
            // SplitContainer2.Panel1
            // 
            this.SplitContainer2.Panel1.Controls.Add(this.ExpTree1);
            // 
            // SplitContainer2.Panel2
            // 
            this.SplitContainer2.Panel2.Controls.Add(this.lv1);
            this.SplitContainer2.Size = new System.Drawing.Size(934, 399);
            this.SplitContainer2.SplitterDistance = 315;
            this.SplitContainer2.TabIndex = 0;
            // 
            // ExpTree1
            // 
            this.ExpTree1.AllowDrop = true;
            this.ExpTree1.AllowFolderRename = true;
            this.ExpTree1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ExpTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExpTree1.Location = new System.Drawing.Point(0, 0);
            this.ExpTree1.Name = "ExpTree1";
            this.ExpTree1.ShowRootLines = false;
            this.ExpTree1.Size = new System.Drawing.Size(315, 399);
            this.ExpTree1.StartUpDirectory = ExpTreeLib.ExpTree.StartDir.Desktop;
            this.ExpTree1.TabIndex = 0;
            // 
            // lv1
            // 
            this.lv1.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lv1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chSize,
            this.chLastModified,
            this.chTypeStr,
            this.chAttributes,
            this.chCreated});
            this.lv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv1.HideSelection = false;
            this.lv1.LabelEdit = true;
            this.lv1.Location = new System.Drawing.Point(0, 0);
            this.lv1.Name = "lv1";
            this.lv1.Size = new System.Drawing.Size(615, 399);
            this.lv1.TabIndex = 1;
            this.lv1.UseCompatibleStateImageBehavior = false;
            this.lv1.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 150;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            this.chSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chSize.Width = 88;
            // 
            // chLastModified
            // 
            this.chLastModified.Text = "LastMod Date";
            this.chLastModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chLastModified.Width = 122;
            // 
            // chTypeStr
            // 
            this.chTypeStr.Text = "Type";
            this.chTypeStr.Width = 100;
            // 
            // chAttributes
            // 
            this.chAttributes.Text = "Attributes";
            this.chAttributes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chAttributes.Width = 80;
            // 
            // chCreated
            // 
            this.chCreated.Text = "Created";
            this.chCreated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.chCreated.Width = 122;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(229, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 43);
            this.button3.TabIndex = 3;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Location = new System.Drawing.Point(143, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 42);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(43, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 43);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Label1
            // 
            this.Label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.Label1.Location = new System.Drawing.Point(0, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(934, 84);
            this.Label1.TabIndex = 0;
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(670, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Back";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // frmThreadCS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 533);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.SplitContainer1);
            this.Controls.Add(this.StatusStrip1);
            this.Controls.Add(this.MenuStrip1);
            this.Name = "frmThreadCS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmThread in C#";
            this.Load += new System.EventHandler(this.frmThreadCS_Load);
            this.StatusStrip1.ResumeLayout(false);
            this.StatusStrip1.PerformLayout();
            this.MenuStrip1.ResumeLayout(false);
            this.MenuStrip1.PerformLayout();
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            this.SplitContainer2.Panel1.ResumeLayout(false);
            this.SplitContainer2.Panel2.ResumeLayout(false);
            this.SplitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.StatusStrip StatusStrip1;
        internal System.Windows.Forms.ToolStripStatusLabel tsslLeft;
        internal System.Windows.Forms.ToolStripStatusLabel tsslMiddle;
        internal System.Windows.Forms.ToolStripStatusLabel tsslRight;
        internal System.Windows.Forms.MenuStrip MenuStrip1;
        internal System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ViewToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem DetailsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem ListToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem LargeIconsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem SmallIconsToolStripMenuItem;
        internal System.Windows.Forms.ToolStripMenuItem TileToolStripMenuItem;
        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.SplitContainer SplitContainer2;
        internal ExpTreeLib.ExpTree ExpTree1;
        internal System.Windows.Forms.ListView lv1;
        internal System.Windows.Forms.ColumnHeader chName;
        internal System.Windows.Forms.ColumnHeader chSize;
        internal System.Windows.Forms.ColumnHeader chLastModified;
        internal System.Windows.Forms.ColumnHeader chTypeStr;
        internal System.Windows.Forms.ColumnHeader chAttributes;
        internal System.Windows.Forms.ColumnHeader chCreated;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem ciontextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    }
}

