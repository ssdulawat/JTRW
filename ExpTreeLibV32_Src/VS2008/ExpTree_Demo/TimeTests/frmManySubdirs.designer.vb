<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManySubdirs
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsslLeft = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslMiddle = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslRight = New System.Windows.Forms.ToolStripStatusLabel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.txtDisplay = New System.Windows.Forms.TextBox
        Me.prgBar = New System.Windows.Forms.ProgressBar
        Me.cmdRunTest = New System.Windows.Forms.Button
        Me.cmdPopulateDir = New System.Windows.Forms.Button
        Me.cmdShowLog = New System.Windows.Forms.Button
        Me.cmdDone = New System.Windows.Forms.Button
        Me.StatusStrip1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslLeft, Me.tsslMiddle, Me.tsslRight})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 435)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(430, 22)
        Me.StatusStrip1.TabIndex = 2
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
        Me.tsslMiddle.Size = New System.Drawing.Size(376, 17)
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
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtDisplay)
        Me.SplitContainer1.Panel1.Controls.Add(Me.prgBar)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdRunTest)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdPopulateDir)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdShowLog)
        Me.SplitContainer1.Panel2.Controls.Add(Me.cmdDone)
        Me.SplitContainer1.Size = New System.Drawing.Size(430, 435)
        Me.SplitContainer1.SplitterDistance = 299
        Me.SplitContainer1.TabIndex = 3
        '
        'txtDisplay
        '
        Me.txtDisplay.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtDisplay.Location = New System.Drawing.Point(0, 0)
        Me.txtDisplay.Multiline = True
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtDisplay.Size = New System.Drawing.Size(299, 394)
        Me.txtDisplay.TabIndex = 1
        '
        'prgBar
        '
        Me.prgBar.ForeColor = System.Drawing.Color.Red
        Me.prgBar.Location = New System.Drawing.Point(12, 400)
        Me.prgBar.Name = "prgBar"
        Me.prgBar.Size = New System.Drawing.Size(267, 23)
        Me.prgBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgBar.TabIndex = 0
        '
        'cmdRunTest
        '
        Me.cmdRunTest.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdRunTest.Location = New System.Drawing.Point(26, 202)
        Me.cmdRunTest.Name = "cmdRunTest"
        Me.cmdRunTest.Size = New System.Drawing.Size(74, 30)
        Me.cmdRunTest.TabIndex = 3
        Me.cmdRunTest.Text = "Run Test"
        Me.cmdRunTest.UseVisualStyleBackColor = True
        '
        'cmdPopulateDir
        '
        Me.cmdPopulateDir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdPopulateDir.Location = New System.Drawing.Point(26, 260)
        Me.cmdPopulateDir.Name = "cmdPopulateDir"
        Me.cmdPopulateDir.Size = New System.Drawing.Size(74, 30)
        Me.cmdPopulateDir.TabIndex = 2
        Me.cmdPopulateDir.Text = "Populate Dir"
        Me.cmdPopulateDir.UseVisualStyleBackColor = True
        '
        'cmdShowLog
        '
        Me.cmdShowLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdShowLog.Location = New System.Drawing.Point(26, 315)
        Me.cmdShowLog.Name = "cmdShowLog"
        Me.cmdShowLog.Size = New System.Drawing.Size(74, 30)
        Me.cmdShowLog.TabIndex = 1
        Me.cmdShowLog.Text = "Show Log"
        Me.cmdShowLog.UseVisualStyleBackColor = True
        '
        'cmdDone
        '
        Me.cmdDone.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdDone.Location = New System.Drawing.Point(26, 373)
        Me.cmdDone.Name = "cmdDone"
        Me.cmdDone.Size = New System.Drawing.Size(74, 30)
        Me.cmdDone.TabIndex = 0
        Me.cmdDone.Text = "Done"
        Me.cmdDone.UseVisualStyleBackColor = True
        '
        'frmManySubdirs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(430, 457)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmManySubdirs"
        Me.Text = "Create and/or Test Remote Dir with Many SubDirs"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslLeft As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslMiddle As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslRight As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents cmdShowLog As System.Windows.Forms.Button
    Friend WithEvents cmdDone As System.Windows.Forms.Button
    Friend WithEvents prgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents txtDisplay As System.Windows.Forms.TextBox
    Friend WithEvents cmdPopulateDir As System.Windows.Forms.Button
    Friend WithEvents cmdRunTest As System.Windows.Forms.Button
End Class
