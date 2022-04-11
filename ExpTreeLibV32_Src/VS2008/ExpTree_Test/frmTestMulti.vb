Imports ExpTree_Demo

''' <summary>
''' Starts an instance of frmThread each time the cmdLaunchfrmThread Button is Clicked.
''' Experiment with adding or removing items via one instance and observing the change
''' showing up in the others.
''' </summary>
''' <remarks></remarks>
Public Class frmTestMulti

    Private Sub cmdLaunchfrmThread_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLaunchfrmThread.Click
        Dim NewForm As New frmThread
        NewForm.Show()
    End Sub
End Class