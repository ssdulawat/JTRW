<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmThread_TestVersion
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
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsslLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslMiddle = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ViewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DetailsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LargeIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SmallIconsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SearchBoxToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MultiInstanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TimeTestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestCreDirToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.TestFilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
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
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(582, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslLeft, Me.tsslMiddle, Me.tsslRight})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 397)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(582, 22)
        Me.StatusStrip1.TabIndex = 4
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
        Me.tsslMiddle.Size = New System.Drawing.Size(528, 17)
        Me.tsslMiddle.Spring = True
        '
        'tsslRight
        '
        Me.tsslRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslRight.Name = "tsslRight"
        Me.tsslRight.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ViewToolStripMenuItem, Me.TestsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(582, 24)
        Me.MenuStrip1.TabIndex = 3
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
        'TestsToolStripMenuItem
        '
        Me.TestsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SearchBoxToolStripMenuItem, Me.MultiInstanceToolStripMenuItem, Me.TimeTestToolStripMenuItem, Me.TestCreDirToolStripMenuItem1, Me.TestFilterToolStripMenuItem})
        Me.TestsToolStripMenuItem.Name = "TestsToolStripMenuItem"
        Me.TestsToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.TestsToolStripMenuItem.Text = "&Tests"
        '
        'SearchBoxToolStripMenuItem
        '
        Me.SearchBoxToolStripMenuItem.Name = "SearchBoxToolStripMenuItem"
        Me.SearchBoxToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SearchBoxToolStripMenuItem.Text = "SearchBox"
        '
        'MultiInstanceToolStripMenuItem
        '
        Me.MultiInstanceToolStripMenuItem.Name = "MultiInstanceToolStripMenuItem"
        Me.MultiInstanceToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.MultiInstanceToolStripMenuItem.Text = "Multi Instance"
        '
        'TimeTestToolStripMenuItem
        '
        Me.TimeTestToolStripMenuItem.Name = "TimeTestToolStripMenuItem"
        Me.TimeTestToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TimeTestToolStripMenuItem.Text = "TimeTest"
        '
        'TestCreDirToolStripMenuItem1
        '
        Me.TestCreDirToolStripMenuItem1.Name = "TestCreDirToolStripMenuItem1"
        Me.TestCreDirToolStripMenuItem1.Size = New System.Drawing.Size(152, 22)
        Me.TestCreDirToolStripMenuItem1.Text = "TestCreDir"
        '
        'TestFilterToolStripMenuItem
        '
        Me.TestFilterToolStripMenuItem.Name = "TestFilterToolStripMenuItem"
        Me.TestFilterToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.TestFilterToolStripMenuItem.Text = "TestFilter"
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
        Me.SplitContainer1.Size = New System.Drawing.Size(582, 348)
        Me.SplitContainer1.SplitterDistance = 268
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
        Me.SplitContainer2.Size = New System.Drawing.Size(582, 268)
        Me.SplitContainer2.SplitterDistance = 197
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
        Me.ExpTree1.Size = New System.Drawing.Size(197, 268)
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
        Me.lv1.Size = New System.Drawing.Size(381, 268)
        Me.lv1.TabIndex = 1
        Me.lv1.UseCompatibleStateImageBehavior = False
        Me.lv1.View = System.Windows.Forms.View.Details
        '
        'chName
        '
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
        Me.Label1.BackColor = System.Drawing.SystemColors.Window
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(582, 76)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Reserved for Application"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmThread_TestVersion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(582, 419)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmThread_TestVersion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form for Testing Multi-Thread Approach - Test and Instrumented Version"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMiddle As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DetailsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargeIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SmallIconsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ExpTree1 As ExpTreeLib.ExpTree
    Friend WithEvents lv1 As System.Windows.Forms.ListView
    Friend WithEvents chName As System.Windows.Forms.ColumnHeader
    Friend WithEvents chSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents chCreated As System.Windows.Forms.ColumnHeader
    Friend WithEvents chTypeStr As System.Windows.Forms.ColumnHeader
    Friend WithEvents chAttributes As System.Windows.Forms.ColumnHeader
    Friend WithEvents chLastModified As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TestsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SearchBoxToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MultiInstanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimeTestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestCreDirToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestFilterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
