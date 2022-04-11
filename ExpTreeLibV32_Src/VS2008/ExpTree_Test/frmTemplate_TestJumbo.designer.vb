<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTemplate_TestJumbo
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
        Me.components = New System.ComponentModel.Container
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
        Me.Label2 = New System.Windows.Forms.Label
        Me.pbOrigXL = New System.Windows.Forms.PictureBox
        Me.pbOrigLarge = New System.Windows.Forms.PictureBox
        Me.pbOrigJumbo = New System.Windows.Forms.PictureBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.pbLarge = New System.Windows.Forms.PictureBox
        Me.pbXLarge = New System.Windows.Forms.PictureBox
        Me.pbJumbo = New System.Windows.Forms.PictureBox
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.pbOrigXL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbOrigLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbOrigJumbo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbXLarge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbJumbo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(943, 24)
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
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 604)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(943, 22)
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
        Me.tsslMiddle.Size = New System.Drawing.Size(889, 17)
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
        Me.ToolStrip1.Size = New System.Drawing.Size(943, 25)
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
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbOrigXL)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbOrigLarge)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbOrigJumbo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbLarge)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbXLarge)
        Me.SplitContainer1.Panel2.Controls.Add(Me.pbJumbo)
        Me.SplitContainer1.Size = New System.Drawing.Size(943, 555)
        Me.SplitContainer1.SplitterDistance = 286
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
        Me.SplitContainer2.Size = New System.Drawing.Size(943, 286)
        Me.SplitContainer2.SplitterDistance = 318
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
        Me.ExpTree1.Size = New System.Drawing.Size(318, 286)
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
        Me.lv1.Size = New System.Drawing.Size(621, 286)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(302, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Icon with NO Overlay"
        '
        'pbOrigXL
        '
        Me.pbOrigXL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbOrigXL.Location = New System.Drawing.Point(296, 100)
        Me.pbOrigXL.Name = "pbOrigXL"
        Me.pbOrigXL.Size = New System.Drawing.Size(64, 64)
        Me.pbOrigXL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbOrigXL.TabIndex = 8
        Me.pbOrigXL.TabStop = False
        '
        'pbOrigLarge
        '
        Me.pbOrigLarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbOrigLarge.Location = New System.Drawing.Point(388, 108)
        Me.pbOrigLarge.Name = "pbOrigLarge"
        Me.pbOrigLarge.Size = New System.Drawing.Size(48, 48)
        Me.pbOrigLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbOrigLarge.TabIndex = 7
        Me.pbOrigLarge.TabStop = False
        '
        'pbOrigJumbo
        '
        Me.pbOrigJumbo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbOrigJumbo.Location = New System.Drawing.Point(12, 4)
        Me.pbOrigJumbo.Name = "pbOrigJumbo"
        Me.pbOrigJumbo.Size = New System.Drawing.Size(256, 256)
        Me.pbOrigJumbo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbOrigJumbo.TabIndex = 6
        Me.pbOrigJumbo.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(503, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Icon with Overlay"
        '
        'pbLarge
        '
        Me.pbLarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbLarge.Location = New System.Drawing.Point(516, 108)
        Me.pbLarge.Name = "pbLarge"
        Me.pbLarge.Size = New System.Drawing.Size(48, 48)
        Me.pbLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbLarge.TabIndex = 4
        Me.pbLarge.TabStop = False
        '
        'pbXLarge
        '
        Me.pbXLarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbXLarge.Location = New System.Drawing.Point(589, 100)
        Me.pbXLarge.Name = "pbXLarge"
        Me.pbXLarge.Size = New System.Drawing.Size(64, 64)
        Me.pbXLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbXLarge.TabIndex = 3
        Me.pbXLarge.TabStop = False
        '
        'pbJumbo
        '
        Me.pbJumbo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbJumbo.Location = New System.Drawing.Point(678, 4)
        Me.pbJumbo.Name = "pbJumbo"
        Me.pbJumbo.Size = New System.Drawing.Size(256, 256)
        Me.pbJumbo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.pbJumbo.TabIndex = 2
        Me.pbJumbo.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(256, 256)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmTemplate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(943, 626)
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
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.pbOrigXL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbOrigLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbOrigJumbo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbXLarge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbJumbo, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents pbJumbo As System.Windows.Forms.PictureBox
    Friend WithEvents pbXLarge As System.Windows.Forms.PictureBox
    Friend WithEvents pbLarge As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbOrigXL As System.Windows.Forms.PictureBox
    Friend WithEvents pbOrigLarge As System.Windows.Forms.PictureBox
    Friend WithEvents pbOrigJumbo As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList

End Class
