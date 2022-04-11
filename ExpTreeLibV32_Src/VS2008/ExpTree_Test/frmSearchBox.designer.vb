<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSearchBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSearchBox))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.tsbSearch = New System.Windows.Forms.ToolStripButton
        Me.tstbFilter = New System.Windows.Forms.ToolStripTextBox
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LargeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SmallIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsslLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslMiddle = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.ExpTree1 = New ExpTreeLib.ExpTree
        Me.lv1 = New System.Windows.Forms.ListView
        Me.chName = New System.Windows.Forms.ColumnHeader
        Me.chSize = New System.Windows.Forms.ColumnHeader
        Me.chLastModified = New System.Windows.Forms.ColumnHeader
        Me.chTypeStr = New System.Windows.Forms.ColumnHeader
        Me.chAttributes = New System.Windows.Forms.ColumnHeader
        Me.chCreated = New System.Windows.Forms.ColumnHeader
        Me.ToolStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.SystemColors.Window
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSearch, Me.tstbFilter, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(584, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbSearch
        '
        Me.tsbSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tsbSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSearch.Enabled = False
        Me.tsbSearch.Image = CType(resources.GetObject("tsbSearch.Image"), System.Drawing.Image)
        Me.tsbSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSearch.Name = "tsbSearch"
        Me.tsbSearch.Size = New System.Drawing.Size(23, 22)
        Me.tsbSearch.Text = "ToolStripButton1"
        '
        'tstbFilter
        '
        Me.tstbFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.tstbFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tstbFilter.Name = "tstbFilter"
        Me.tstbFilter.Size = New System.Drawing.Size(200, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(116, 22)
        Me.ToolStripLabel1.Text = "Enter Search Pattern:"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 25)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(584, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ViewToolStripMenuItem
        '
        Me.ViewToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DetailsToolStripMenuItem, Me.ListToolStripMenuItem, Me.LargeIconsToolStripMenuItem, Me.SmallIconsToolStripMenuItem, Me.TileToolStripMenuItem})
        Me.ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        Me.ViewToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.ViewToolStripMenuItem.Text = "&View"
        '
        'DetailsToolStripMenuItem
        '
        Me.DetailsToolStripMenuItem.Name = "DetailsToolStripMenuItem"
        Me.DetailsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.DetailsToolStripMenuItem.Text = "&Details"
        '
        'ListToolStripMenuItem
        '
        Me.ListToolStripMenuItem.Name = "ListToolStripMenuItem"
        Me.ListToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.ListToolStripMenuItem.Text = "&List"
        '
        'LargeIconsToolStripMenuItem
        '
        Me.LargeIconsToolStripMenuItem.Name = "LargeIconsToolStripMenuItem"
        Me.LargeIconsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.LargeIconsToolStripMenuItem.Text = "Lar&ge Icons"
        '
        'SmallIconsToolStripMenuItem
        '
        Me.SmallIconsToolStripMenuItem.Name = "SmallIconsToolStripMenuItem"
        Me.SmallIconsToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.SmallIconsToolStripMenuItem.Text = "S&mall Icons"
        '
        'TileToolStripMenuItem
        '
        Me.TileToolStripMenuItem.Name = "TileToolStripMenuItem"
        Me.TileToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.TileToolStripMenuItem.Text = "&Tile"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslLeft, Me.tsslMiddle, Me.tsslRight})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 409)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(584, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslLeft
        '
        Me.tsslLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslLeft.Name = "tsslLeft"
        Me.tsslLeft.Size = New System.Drawing.Size(39, 17)
        Me.tsslLeft.Text = "Ready"
        '
        'tsslMiddle
        '
        Me.tsslMiddle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslMiddle.Name = "tsslMiddle"
        Me.tsslMiddle.Size = New System.Drawing.Size(530, 17)
        Me.tsslMiddle.Spring = True
        '
        'tsslRight
        '
        Me.tsslRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslRight.Name = "tsslRight"
        Me.tsslRight.Size = New System.Drawing.Size(0, 17)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 49)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(584, 360)
        Me.SplitContainer1.SplitterDistance = 279
        Me.SplitContainer1.TabIndex = 6
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ExpTree1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lv1)
        Me.SplitContainer2.Size = New System.Drawing.Size(584, 279)
        Me.SplitContainer2.SplitterDistance = 194
        Me.SplitContainer2.TabIndex = 0
        '
        'ExpTree1
        '
        Me.ExpTree1.AllowDrop = True
        Me.ExpTree1.AllowFolderRename = True
        Me.ExpTree1.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExpTree1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExpTree1.Location = New System.Drawing.Point(0, 0)
        Me.ExpTree1.Name = "ExpTree1"
        Me.ExpTree1.ShowRootLines = False
        Me.ExpTree1.Size = New System.Drawing.Size(194, 279)
        Me.ExpTree1.StartUpDirectory = ExpTreeLib.ExpTree.StartDir.Desktop
        Me.ExpTree1.TabIndex = 1
        '
        'lv1
        '
        Me.lv1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lv1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chSize, Me.chLastModified, Me.chTypeStr, Me.chAttributes, Me.chCreated})
        Me.lv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv1.LabelEdit = True
        Me.lv1.Location = New System.Drawing.Point(0, 0)
        Me.lv1.Name = "lv1"
        Me.lv1.Size = New System.Drawing.Size(386, 279)
        Me.lv1.TabIndex = 2
        Me.lv1.UseCompatibleStateImageBehavior = False
        Me.lv1.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Text = "Name"
        Me.chName.Width = 121
        '
        'chSize
        '
        Me.chSize.Text = "Size"
        Me.chSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chSize.Width = 71
        '
        'chLastModified
        '
        Me.chLastModified.Text = "LastMod Date"
        Me.chLastModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chLastModified.Width = 122
        '
        'chTypeStr
        '
        Me.chTypeStr.Text = "Type"
        Me.chTypeStr.Width = 100
        '
        'chAttributes
        '
        Me.chAttributes.Text = "Attributes"
        Me.chAttributes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.chAttributes.Width = 80
        '
        'chCreated
        '
        Me.chCreated.Text = "Created"
        Me.chCreated.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chCreated.Width = 122
        '
        'frmSearchBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(584, 431)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Name = "frmSearchBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSearchBox"
        Me.TransparencyKey = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMiddle As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ExpTree1 As ExpTreeLib.ExpTree
    Friend WithEvents lv1 As System.Windows.Forms.ListView
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents chLastModified As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTypeStr As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAttributes As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCreated As System.Windows.Forms.ColumnHeader
    Friend WithEvents tsbSearch As System.Windows.Forms.ToolStripButton
    Friend WithEvents tstbFilter As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
End Class
