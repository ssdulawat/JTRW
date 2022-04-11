Public Class frmDisplay

#Region "   Hide/Close/Clear Handlers"
    Private Sub cmdHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHide.Click
        HideToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub HideToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HideToolStripMenuItem.Click
        Me.Hide()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        ExitToolStripMenuItem_Click(sender, e)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        Me.txtDisplay.Clear()
    End Sub

    Private Sub cmdClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClear.Click
        ClearToolStripMenuItem_Click(sender, e)
    End Sub
#End Region
End Class