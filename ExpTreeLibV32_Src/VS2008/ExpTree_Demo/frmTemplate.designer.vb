<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTemplate
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(809, 24)
        Me.MenuStrip1.TabIndex = 0
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
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(92, 22)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 408)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(809, 22)
        Me.StatusStrip1.TabIndex = 1
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
        Me.tsslMiddle.Size = New System.Drawing.Size(755, 17)
        Me.tsslMiddle.Spring = True
        '
        'tsslRight
        '
        Me.tsslRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslRight.Name = "tsslRight"
        Me.tsslRight.Size = New System.Drawing.Size(0, 17)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(809, 25)
        Me.ToolStrip1.TabIndex = 2
        Me.ToolStrip1.Text = "ToolStrip1"
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
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Size = New System.Drawing.Size(809, 359)
        Me.SplitContainer1.SplitterDistance = 276
        Me.SplitContainer1.TabIndex = 3
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
        Me.SplitContainer2.Size = New System.Drawing.Size(809, 276)
        Me.SplitContainer2.SplitterDistance = 274
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
        Me.ExpTree1.Size = New System.Drawing.Size(274, 276)
        Me.ExpTree1.StartUpDirectory = ExpTreeLib.ExpTree.StartDir.Desktop
        Me.ExpTree1.TabIndex = 0
        '
        'lv1
        '
        Me.lv1.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lv1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chName, Me.chSize, Me.chLastModified, Me.chTypeStr, Me.chAttributes, Me.chCreated})
        Me.lv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lv1.LabelEdit = True
        Me.lv1.Location = New System.Drawing.Point(0, 0)
        Me.lv1.Name = "lv1"
        Me.lv1.Size = New System.Drawing.Size(531, 276)
        Me.lv1.TabIndex = 1
        Me.lv1.UseCompatibleStateImageBehavior = False
        Me.lv1.View = System.Windows.Forms.View.Details
        '
        'chName
        '
        Me.chName.Tag = "ExpTreeLib.CShItem.DisplayName"
        Me.chName.Text = "Name"
        Me.chName.Width = 150
        '
        'chSize
        '
        Me.chSize.Text = "Size"
        Me.chSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.chSize.Width = 88
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
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(809, 79)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Reserved for Application"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 430)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmTemplate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Starter Template for ExpTree based Apps"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ExpTree1 As ExpTreeLib.ExpTree
    Friend WithEvents lv1 As System.Windows.Forms.ListView
    Friend WithEvents tsslLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMiddle As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAttributes As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTypeStr As System.Windows.Forms.ColumnHeader
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chCreated As System.Windows.Forms.ColumnHeader
    Friend WithEvents chLastModified As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
