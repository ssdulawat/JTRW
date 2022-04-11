Imports ExpTreeLib
Imports ExpTreeLib.CShItem
Imports ExpTreeLib.SystemImageListManager
Imports ExpTreeLib.ShellDll
Imports ExpTreeLib.ShellDll.ShellAPI
Imports ExpTreeLib.ShellDll.ShellHelper
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Text

''' <summary>
''' A Form to demonstrate the use of ExpTreeLib in a Form with no ExpTree and no ListView. It especially demonstrates the use
''' of the ControlDropWrapper to support Drop operations on a Control that is <em>not</em> a ExpTree or ListView.
''' <para>In addition to ControlDropWrapper, it makes use of the CShItem and SystemImageListManager Classes.</para>
''' <para>It also demonstrates the use of CShItem Dynamic updating as may be applied to a DataBound DataGridView</para>
''' </summary>
''' <remarks>SystemImageListManager use is actually demonstrated in the support Class for this Form, CSIDisplay.</remarks>
Public Class frmDragToControl

#Region "   Private Fields/Variables"

    Private CurrentDir As CShItem               'The Directory currently associated with DataGridView1
    Private DropWrap As ControlDropWrapper      'The DropWrapper instance currently monitoring DataGridView1
    Private FileList As BindingList(Of CSIDisplay) 'The list of Files currently displayed in DataGridView1

#End Region

#Region "   Form Exit Methods and Events"
    Private Sub mnuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub frmDragToControl_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing  '7/1/2012
        RemoveHandler CShItemUpdate, AddressOf UpdateInvoke '7/1/2012
    End Sub         '7/1/2012
#End Region

#Region "   Form Load"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Obtain Starting Output Dir from FolderBrowserDialog. If it is NOT Valid or Not Exists then ignore
        With FolderBrowserDialog1
            If .SelectedPath.Trim.Length > 0 AndAlso Directory.Exists(.SelectedPath) Then
                txtOutputDir.Text = .SelectedPath
                Try
                    IO.Path.GetFullPath(txtOutputDir.Text)     'will check for invalid chars, etc.
                    If Not Directory.Exists(txtOutputDir.Text) Then Exit Sub
                Catch ex As Exception
                    Exit Sub
                End Try

                'Setup Change Notification	7/1/2012
                AddHandler CShItemUpdate, AddressOf UpdateInvoke        '7/1/2012

                'Real setup is done in txtOutputDir_Validated
                txtOutputDir.SelectionStart = txtOutputDir.Text.Length + 1
                txtOutputDir.SelectionLength = 0
                txtOutputDir_Validated(sender, e)
            End If
        End With
    End Sub
#End Region

#Region "   Output Directory Change Handlers"
    Private Sub laBrowseForSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
              Handles laBrowseForSource.Click, SelectDirectoryToolStripMenuItem.Click
        With FolderBrowserDialog1
            Dim R As DialogResult = .ShowDialog
            If R <> Windows.Forms.DialogResult.OK Then Exit Sub
            txtOutputDir.Text = .SelectedPath
            txtOutputDir.Focus()    'Force a call to Validating and Validated
            laBrowseForSource.Focus()
        End With
    End Sub

    Private Sub txtOutputDir_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtOutputDir.Validating
        txtOutputDir.Text = txtOutputDir.Text.Trim
        If txtOutputDir.Text.Length = 0 Then Exit Sub ' Just passing thru
        Try
            IO.Path.GetFullPath(txtOutputDir.Text)     'will check for invalid chars, etc.
            If Directory.Exists(txtOutputDir.Text) Then Exit Sub
        Catch ex As Exception
            MsgBox(txtOutputDir.Text & " Is not a Valid or Existing Directory", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Invalid Directory")
            e.Cancel = True
        End Try
    End Sub

    Private Sub txtOutputDir_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOutputDir.Validated
        If txtOutputDir.Text.Length = 0 Then Exit Sub ' Just passing thru
        If CurrentDir IsNot Nothing AndAlso txtOutputDir.Text.Equals(CurrentDir.Path, StringComparison.CurrentCultureIgnoreCase) Then Exit Sub
        'There is a change
        Dim StartPath As String = txtOutputDir.Text
        CurrentDir = GetCShItem(StartPath)
        FileList = New BindingList(Of CSIDisplay)
        'BindingList does not support .AddRange
        For Each CSI As CShItem In CurrentDir.GetItems
            FileList.Add(New CSIDisplay(CSI))
        Next
        BindingSource1.DataSource = FileList
        If DropWrap Is Nothing Then
            DropWrap = New ControlDropWrapper(DataGridView1, StartPath)
        Else
            DropWrap.FullPath = StartPath
        End If

    End Sub

#End Region

#Region "   Dynamic Update Handler"
    ''' <summary>
    ''' To receive notification of changes to the FileSystem which may affect the GUI display, declare
    ''' DeskTopItem WithEvents. Changes to CShItem's internal tree which are caused by notification of 
    ''' FileSystem changes or by periodic refresh of the contents of the internal tree raise CShItemUpdate
    ''' events.
    ''' </summary>
    Private Delegate Sub InvokeUpdate(ByVal sender As Object, ByVal e As ShellItemUpdateEventArgs)

    'Private WithEvents DeskTopItem As CShItem = CShItem.GetDeskTop '7/1/2012

    Private m_InvokeUpdate As New InvokeUpdate(AddressOf DoItemUpdate)

    ''' <summary>
    ''' Determines if DoItemUpdate should be called directly or via Invoke, and then calls it.
    ''' </summary>
    ''' <param name="sender">The CShItem of the Folder of the changed item.</param>
    ''' <param name="e">Contains information about the type of change and items affected.</param>
    ''' <remarks>Responds to events raised by either WM_Notify messages or FileWatch.</remarks>
    Private Sub UpdateInvoke(ByVal sender As Object, ByVal e As ShellItemUpdateEventArgs) '7/1/2012 removed Handles clause
        If Me.InvokeRequired Then
            Invoke(m_InvokeUpdate, sender, e)
        Else
            DoItemUpdate(sender, e)
        End If
    End Sub
    ''' <summary>
    ''' Makes changes in GUI in response to updating events raised by CShItem.
    ''' </summary>
    ''' <param name="sender">The CShItem of the Folder of the changed item.</param>
    ''' <param name="e">Contains information about the type of change and items affected.</param>
    ''' <remarks>Responds to events raised by either WM_Notify messages or FileWatch.</remarks>
    Private Sub DoItemUpdate(ByVal sender As Object, ByVal e As ShellItemUpdateEventArgs)

        'if CurrentDir is not set up, then this notification is of no interest
        If CurrentDir Is Nothing Then Exit Sub

        Dim Parent As CShItem = DirectCast(sender, CShItem)
        If Parent Is CurrentDir Then   'If not, then of no interest to us
            Try
                Select Case e.UpdateType
                    Case CShItem.CShItemUpdateType.Created
                        FileList.Add(New CSIDisplay(e.Item))
                    Case CShItemUpdateType.Deleted
                        FileList.Remove(FindItem(e.Item))
                    Case CShItemUpdateType.Renamed
                        Dim Indx As Integer = FindIndex(e.Item)
                        If Indx > -1 Then
                            If e.Item.Parent IsNot CurrentDir Then          'if true = item renamed to different directory
                                FileList.RemoveAt(Indx)
                            Else
                                FileList(Indx).ResetIcon()   'Extension may have changed
                                FileList.ResetItem(Indx)
                            End If
                        End If
                    Case CShItemUpdateType.UpdateDir  'in this case Parent/sender is the item of interest
                        ' CShItemUpdater, etc. will do the appropriate Adds and Removes, generating
                        ' Created/Deleted events that will occur before an UpdateDir event. There is
                        ' no need to do anything here, except, perhaps, resort the DataGridView - which I do not do

                    Case CShItemUpdateType.Updated 'In this case, something other than Name or Parent has changed - like
                        'attributes. In this case, we don't care since CShItem.Update has done the resets to the Item.
                        'Just in case, reset the item in the BindingList.
                        Dim Indx As Integer = FindIndex(e.Item)
                        If Indx > -1 Then FileList.ResetItem(Indx)
                    Case CShItemUpdateType.IconChange
                        FindItem(e.Item).ResetIcon()
                    Case CShItemUpdateType.MediaChange 'Once again, CShItem.Update has fixed up the CShItem, so just refresh
                        Dim Indx As Integer = FindIndex(e.Item)
                        If Indx > -1 Then
                            FileList(Indx).ResetIcon()
                            FileList.ResetItem(Indx)
                        End If
                End Select
            Catch ex As Exception
                Debug.WriteLine("Error in frmDragToControl updater -- " & ex.ToString)
            End Try
        End If      'end of Parent is CurrentDir Test
    End Sub

    Private Function FindItem(ByVal CSI As CShItem) As CSIDisplay
        For i As Integer = 0 To FileList.Count - 1
            If FileList(i).CSItem Is CSI Then
                Return FileList(i)
            End If
        Next
        Return Nothing
    End Function

    Private Function FindIndex(ByVal CSI As CShItem) As Integer
        For i As Integer = 0 To FileList.Count - 1
            If FileList(i).CSItem Is CSI Then
                Return i
            End If
        Next
        Return -1
    End Function
#End Region

End Class

''' <summary>
''' This Class is used to provide a displayable entry for frmDragToControl which builds a BindingList(Of CSIDisplay)
''' which is then DataBound to that Forms DataGridView.
''' </summary>
''' <remarks>Illustrates the use of SystemImageListManager to get Icons which are then displayed on the DataGridView.
'''          see DoItemUpdate in frmDragToControl to see how to update an instance of this Class in response
'''          to Change Notification Events Raised by CShItem.</remarks>
Public Class CSIDisplay
    Private m_Item As CShItem
    Private m_ItemIcon As Icon

    Sub New(ByVal CSI As CShItem)
        m_Item = CSI
        m_ItemIcon = SystemImageListManager.GetIcon(SystemImageListManager.GetIconIndex(CSI), True)
    End Sub

    ''' <summary>
    ''' Updates the Icon to its' current value.
    ''' </summary>
    ''' <remarks>Used in response to a Windows Message indicating that the Icon has changed.</remarks>
    Public Sub ResetIcon()
        m_ItemIcon = SystemImageListManager.GetIcon(SystemImageListManager.GetIconIndex(m_Item), True)
    End Sub

#Region "   Public RO Properties"
    ''' <summary>
    ''' The underlying CShItem.
    ''' </summary>
    <Browsable(False)> _
    Public ReadOnly Property CSItem() As CShItem
        Get
            Return m_Item
        End Get
    End Property
    ''' <summary>
    ''' The Icon of this CShItem.
    ''' </summary>
    Public ReadOnly Property ItemIcon() As Icon
        Get
            Return m_ItemIcon
        End Get
    End Property
    ''' <summary>
    ''' The DisplayName of this Item.
    ''' </summary>
    Public ReadOnly Property DisplayName() As String
        Get
            Return m_Item.DisplayName
        End Get
    End Property
    ''' <summary>
    ''' The Length of this item in Bytes.
    ''' </summary>
    Public ReadOnly Property Length() As Long
        Get
            Return m_Item.Length
        End Get
    End Property
    ''' <summary>
    ''' The Shell's Typename of this Item.
    ''' </summary>
    Public ReadOnly Property TypeName() As String
        Get
            Return m_Item.TypeName
        End Get
    End Property
    ''' <summary>
    ''' The LastWriteTime of this Item.
    ''' </summary>
    Public ReadOnly Property LastWriteTime() As Date
        Get
            Return m_Item.LastWriteTime
        End Get
    End Property
    ''' <summary>
    ''' The CreationTime of this Item.
    ''' </summary>
    Public ReadOnly Property CreationTime() As Date
        Get
            Return m_Item.CreationTime
        End Get
    End Property
#End Region

End Class