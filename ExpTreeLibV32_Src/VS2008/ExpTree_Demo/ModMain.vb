Imports ExpTreeLib
Imports ExpTreeLib.ShellDll.ShellAPI

''' <summary>
''' modMain contains the entry point for the Demo application. 
''' </summary>
Module ModMain
    ''' <summary>
    ''' The entry point for the Demo application.
    ''' Change, using the code editor, the Form that is to be the main Form of a particular demonstration.
    ''' </summary>
    ''' <remarks>Will catch any unhandled exceptions and report them before exiting.''' </remarks>
    <STAThread()> _
    Sub main()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Dim D As CShItem = CShItem.GetDeskTop   'initialize for non-ExpTree uses
        Try
            'Application.Run(New frmTemplate)
            Application.Run(New frmThread)
            'Application.Run(New frmDragToControl)
        Catch ex As Exception
            MsgBox("App terminated abnormally -- " & vbCrLf & ex.GetType.Name & vbCrLf & ex.Message, _
                    MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Abnormal Termination")
            Debug.WriteLine("App terminated abnormally -- " & vbCrLf & ex.GetType.Name & vbCrLf & ex.ToString)
        End Try
    End Sub
End Module
