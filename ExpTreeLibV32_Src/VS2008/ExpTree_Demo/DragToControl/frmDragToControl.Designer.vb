<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDragToControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDragToControl))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SelectDirectoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsslLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslMiddle = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.laBrowseForSource = New System.Windows.Forms.Label
        Me.txtOutputDir = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.ItemIconDataGridViewImageColumn = New System.Windows.Forms.DataGridViewImageColumn
        Me.DisplayNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LengthDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TypeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LastWriteTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(577, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SelectDirectoryToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'SelectDirectoryToolStripMenuItem
        '
        Me.SelectDirectoryToolStripMenuItem.Name = "SelectDirectoryToolStripMenuItem"
        Me.SelectDirectoryToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.SelectDirectoryToolStripMenuItem.Text = "&Select Directory"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslLeft, Me.tsslMiddle, Me.tsslRight})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 299)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(577, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslLeft
        '
        Me.tsslLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslLeft.Name = "tsslLeft"
        Me.tsslLeft.Size = New System.Drawing.Size(0, 17)
        '
        'tsslMiddle
        '
        Me.tsslMiddle.Name = "tsslMiddle"
        Me.tsslMiddle.Size = New System.Drawing.Size(562, 17)
        Me.tsslMiddle.Spring = True
        '
        'tsslRight
        '
        Me.tsslRight.Name = "tsslRight"
        Me.tsslRight.Size = New System.Drawing.Size(0, 17)
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.laBrowseForSource)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtOutputDir)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(577, 275)
        Me.SplitContainer1.SplitterDistance = 58
        Me.SplitContainer1.TabIndex = 3
        '
        'laBrowseForSource
        '
        Me.laBrowseForSource.AutoSize = True
        Me.laBrowseForSource.Image = CType(resources.GetObject("laBrowseForSource.Image"), System.Drawing.Image)
        Me.laBrowseForSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.laBrowseForSource.Location = New System.Drawing.Point(492, 18)
        Me.laBrowseForSource.Name = "laBrowseForSource"
        Me.laBrowseForSource.Size = New System.Drawing.Size(37, 13)
        Me.laBrowseForSource.TabIndex = 49
        Me.laBrowseForSource.Text = "       ..."
        Me.laBrowseForSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOutputDir
        '
        Me.txtOutputDir.Location = New System.Drawing.Point(111, 14)
        Me.txtOutputDir.Name = "txtOutputDir"
        Me.txtOutputDir.Size = New System.Drawing.Size(375, 20)
        Me.txtOutputDir.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 13)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Output Directory:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemIconDataGridViewImageColumn, Me.DisplayNameDataGridViewTextBoxColumn, Me.LengthDataGridViewTextBoxColumn, Me.TypeNameDataGridViewTextBoxColumn, Me.LastWriteTimeDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(577, 213)
        Me.DataGridView1.TabIndex = 4
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(ExpTree_Demo.CSIDisplay)
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Select the Output Directory for Items Dragged to DataGridView"
        Me.FolderBrowserDialog1.SelectedPath = "C:\Temp\TestDragToControl\Case1"
        '
        'ItemIconDataGridViewImageColumn
        '
        Me.ItemIconDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.ItemIconDataGridViewImageColumn.DataPropertyName = "ItemIcon"
        Me.ItemIconDataGridViewImageColumn.HeaderText = ""
        Me.ItemIconDataGridViewImageColumn.Name = "ItemIconDataGridViewImageColumn"
        Me.ItemIconDataGridViewImageColumn.ReadOnly = True
        Me.ItemIconDataGridViewImageColumn.Width = 5
        '
        'DisplayNameDataGridViewTextBoxColumn
        '
        Me.DisplayNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DisplayNameDataGridViewTextBoxColumn.DataPropertyName = "DisplayName"
        Me.DisplayNameDataGridViewTextBoxColumn.HeaderText = "DisplayName"
        Me.DisplayNameDataGridViewTextBoxColumn.Name = "DisplayNameDataGridViewTextBoxColumn"
        Me.DisplayNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LengthDataGridViewTextBoxColumn
        '
        Me.LengthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LengthDataGridViewTextBoxColumn.DataPropertyName = "Length"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.LengthDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.LengthDataGridViewTextBoxColumn.HeaderText = "Length"
        Me.LengthDataGridViewTextBoxColumn.Name = "LengthDataGridViewTextBoxColumn"
        Me.LengthDataGridViewTextBoxColumn.ReadOnly = True
        Me.LengthDataGridViewTextBoxColumn.Width = 65
        '
        'TypeNameDataGridViewTextBoxColumn
        '
        Me.TypeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName"
        Me.TypeNameDataGridViewTextBoxColumn.HeaderText = "TypeName"
        Me.TypeNameDataGridViewTextBoxColumn.Name = "TypeNameDataGridViewTextBoxColumn"
        Me.TypeNameDataGridViewTextBoxColumn.ReadOnly = True
        '
        'LastWriteTimeDataGridViewTextBoxColumn
        '
        Me.LastWriteTimeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.LastWriteTimeDataGridViewTextBoxColumn.DataPropertyName = "LastWriteTime"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "MM/dd/yyyy HH:mm:ss"
        Me.LastWriteTimeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.LastWriteTimeDataGridViewTextBoxColumn.HeaderText = "LastWriteTime"
        Me.LastWriteTimeDataGridViewTextBoxColumn.Name = "LastWriteTimeDataGridViewTextBoxColumn"
        Me.LastWriteTimeDataGridViewTextBoxColumn.ReadOnly = True
        '
        'frmDragToControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(577, 321)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "frmDragToControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form to Test Dragging to a Control"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMiddle As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents laBrowseForSource As System.Windows.Forms.Label
    Friend WithEvents txtOutputDir As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SelectDirectoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemIconDataGridViewImageColumn As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DisplayNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LengthDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TypeNameDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastWriteTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
