Imports ExpTreeLib
Imports ExpTreeLib.CShItem
Imports ExpTreeLib.SystemImageListManager
Imports ExpTreeLib.ShellDll
Imports ExpTreeLib.ShellDll.ShellAPI
Imports ExpTreeLib.ShellDll.ShellHelper
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.IO
Imports System.Text
Imports System.Threading

''' <summary>
''' This Form is a fully working start point for any form which requires an ExplorerTree and
''' ListView with enough room left for application specific controls.
''' </summary>
''' <remarks>
''' <para>This template form illustrates the use of:
''' <list type="bullet">
''' <item><description>Use of the ExpTreeNodeSelected Event Handler.</description></item>
''' <item><description>Use of LVColSorter for column sorting. See MakeLviItem for a custom ListViewItem 
''' builder which is compatible with and useful for LVColSorter. 
''' See Also SortLVItems for how to perform a Refresh of the 
''' ListView in response to a Refresh command from the Context Menu.</description></item>
''' <item><description>Full Context Menus in the ListView.</description></item>
''' <item><description>ListViewItem editing (first SubItem only) if the ListViewItem.Tag is a CShItem.</description></item>
''' <item><description>Handling of dynamic update Events from CShItemUpdate Events.</description></item>
''' <item><description>Proper handling of the Delete Key.</description></item>
''' <item><description>Shows how to handle a DoubleClick on a ListViewItem.</description></item>
''' </list>
''' </para></remarks>
Public Class frmTemplate_TestJumbo
    'avoid Globalization problem-- an empty timevalue
    Dim EmptyTimeValue As New DateTime(1, 1, 1, 0, 0, 0)

    Private LastSelectedCSI As CShItem

    Private DW As CDragWrapper              'wrapper for Drag ops originating in lv1
    Private DropWrap As ClvDropWrapper      'wrapper for Drop ops targeting lv1

    Private m_CreateNew As Boolean = False  'Flag for NewMenu processing of "New" item

    ' InitialLoadLimit is a the number of lv1.Items whose IconIndex will we fetched on initial load
    ' the balance will be fetched AFTER lv1.EndUpdate
    Const InitialLoadLimit As Integer = 32

#Region "   Form Close Methods"
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub frmThread_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing  '7/1/2012
        RemoveHandler CShItemUpdate, AddressOf UpdateInvoke '7/1/2012
    End Sub             '711/2012
#End Region

#Region "   Form Load/VisibleChanged lv1 HandleCreated"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Setup Drag and Drop Wrappers
        DW = New CDragWrapper(lv1)
        DropWrap = New ClvDropWrapper(lv1)
        'Setup Change Notification	7/1/2012
        AddHandler CShItemUpdate, AddressOf UpdateInvoke        '7/1/2012
    End Sub

    Private Sub lv1_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) _
                Handles lv1.HandleCreated
        SystemImageListManager.SetListViewImageList(lv1, False, False)
        SystemImageListManager.SetListViewImageList(lv1, True, False)
    End Sub

    Private Sub Form1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        SystemImageListManager.SetListViewImageList(lv1, False, False)
        SystemImageListManager.SetListViewImageList(lv1, True, False)
    End Sub
#End Region

#Region "   ExplorerTree Event Handling -- AfterNodeSelect"
    Private Sub AfterNodeSelect(ByVal pathName As String, ByVal CSI As CShItem) _
           Handles ExpTree1.ExpTreeNodeSelected

        tsslMiddle.Text = pathName
        Me.Text = pathName
        tsslLeft.Text = "Building Display"
        Dim dirList As New ArrayList()
        Dim fileList As New ArrayList()
        Dim TotalItems As Integer
        Cursor = Cursors.WaitCursor
        If CSI.DisplayName.Equals(CShItem.strMyComputer) Then
            dirList.AddRange(CSI.Directories) 'avoid re-query since only has dirs
        Else
            dirList.AddRange(CSI.Directories)
            fileList.AddRange(CSI.Files)
        End If

        TotalItems = dirList.Count + fileList.Count
        If TotalItems > 0 Then
            Dim item As CShItem
            dirList.Sort()
            fileList.Sort()

            tsslRight.Text = dirList.Count & " Directories " & fileList.Count & " Files"
            Dim combList As New ArrayList(TotalItems)
            combList.AddRange(dirList)
            combList.AddRange(fileList)

            'Build the ListViewItems & add to lv1
            lv1.BeginUpdate()
            lv1.Items.Clear()
            If LastSelectedCSI IsNot Nothing AndAlso LastSelectedCSI IsNot CSI Then
                LastSelectedCSI.ClearItems(True)
            End If
            lv1.Refresh()

            Dim InitialFillLim As Integer = Math.Min(combList.Count, InitialLoadLimit)
            Dim FirstLoad As New List(Of ListViewItem)(combList.Count)
            For Each item In combList
                Dim lvi As ListViewItem = MakeLVItem(item)
                If lv1.Items.Count < InitialFillLim Then
                    lvi.ImageIndex = SystemImageListManager.GetIconIndex(lvi.Tag, False)
                End If
                FirstLoad.Add(lvi)
            Next
            lv1.Items.AddRange(FirstLoad.ToArray)
            lv1.EndUpdate()

            For i As Integer = InitialFillLim - 1 To lv1.Items.Count - 1
                lv1.Items(i).ImageIndex = SystemImageListManager.GetIconIndex(lv1.Items(i).Tag, False)
            Next

        Else
            lv1.Items.Clear()
            If LastSelectedCSI IsNot Nothing AndAlso LastSelectedCSI IsNot CSI Then
                LastSelectedCSI.ClearItems(True)
            End If
            tsslRight.Text = " Has No Items"
        End If
        LastSelectedCSI = CSI
        lv1.Tag = LastSelectedCSI           '7/5/2012   For ClvDropWapper

        'Now that lv.ListViewItems has been set up (and MakeLvItem does attach the appropriate tags
        ' to both the ListViewItem and the appropriate SubItems), set the ListViewItemSorter
        lv1.ListViewItemSorter = New LVColSorter(lv1)
        tsslLeft.Text = "Ready"
        Cursor = Cursors.Default
        'Build Local Image List on first reference - testing jumbo overlaid Icons
        ' Note this only works for first call. First call displays Desktop which is all we are testing
        Debug.WriteLine("Node Selected - " & LastSelectedCSI.ItemPath)
        If FirstNodeSelected Then
            FirstNodeSelected = False
            BuildTestList()
        End If
    End Sub
    Private FirstNodeSelected As Boolean = True
#End Region

#Region "   MakeLVItem"
    Private Function MakeLVItem(ByVal item As CShItem) As ListViewItem
        Dim lvi As New ListViewItem(item.DisplayName)
        With lvi
            .Tag = item
            'Set Length
            If Not item.IsDisk And item.IsFileSystem And Not item.IsFolder Then
                If item.Length > 1024 Then
                    .SubItems.Add(Format(item.Length / 1024, "#,### KB"))
                Else
                    .SubItems.Add(Format(item.Length, "##0 Bytes"))
                End If
                lvi.SubItems(lvi.SubItems.Count - 1).Tag = item.Length
            Else
                .SubItems.Add("")
                lvi.SubItems(lvi.SubItems.Count - 1).Tag = 0L
            End If
            'Set LastWriteTime
            If item.IsDisk OrElse item.LastWriteTime = EmptyTimeValue Then '"#1/1/0001 12:00:00 AM#" is empty
                .SubItems.Add("")
                .SubItems(.SubItems.Count - 1).Tag = EmptyTimeValue
            Else
                .SubItems.Add(item.LastWriteTime.ToString("MM/dd/yyyy HH:mm:ss"))
                .SubItems(.SubItems.Count - 1).Tag = item.LastWriteTime
            End If
            'Set Type
            .SubItems.Add(item.TypeName)
            'Set Attributes
            If Not item.IsDisk And item.IsFileSystem Then
                Dim SB As New StringBuilder()
                Try
                    Dim attr As FileAttributes = item.Attributes
                    If (attr And FileAttributes.System) = FileAttributes.System Then SB.Append("S")
                    If (attr And FileAttributes.Hidden) = FileAttributes.Hidden Then SB.Append("H")
                    If (attr And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then SB.Append("R")
                    If (attr And FileAttributes.Archive) = FileAttributes.Archive Then SB.Append("A")
                Catch
                End Try
                .SubItems.Add(SB.ToString)
            Else : .SubItems.Add("")
            End If
            'Set CreationTime
            If item.IsDisk OrElse item.CreationTime = EmptyTimeValue Then '"#1/1/0001 12:00:00 AM#" is empty
                .SubItems.Add("")
                .SubItems(.SubItems.Count - 1).Tag = EmptyTimeValue
            Else
                .SubItems.Add(item.CreationTime.ToString("MM/dd/yyyy HH:mm:ss"))
                .SubItems(.SubItems.Count - 1).Tag = item.CreationTime
            End If
        End With
        Return lvi
    End Function
#End Region

#Region "   View Menu Event Handling"
    Private Sub mnuViewLargeIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LargeIconsToolStripMenuItem.Click
        lv1.View = View.LargeIcon
    End Sub

    Private Sub mnuViewSmallIcons_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SmallIconsToolStripMenuItem.Click
        lv1.View = View.SmallIcon
    End Sub

    Private Sub mnuViewList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListToolStripMenuItem.Click
        lv1.View = View.List
    End Sub

    Private Sub mnuViewDetails_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailsToolStripMenuItem.Click
        lv1.View = View.Details
    End Sub

    Private Sub mnuViewTile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TileToolStripMenuItem.Click
        lv1.TileSize = New Size(CInt(lv1.ClientSize.Width * 0.333), CInt(lv1.ClientSize.Height / 4))   '05/09/2013 - JDP Make same as frmThread
        lv1.View = View.Tile
    End Sub
#End Region

#Region "   Dynamic Update Handler"
    ''' <summary>
    ''' To receive notification of changes to the FileSystem which may affect the GUI display, declare
    ''' DeskTopItem WithEvents. Changes to CShItem's internal tree which are caused by notification of 
    ''' FileSystem changes or by periodic refresh of the contents of the internal tree raise CShItemUpdate
    ''' events.  Since the periodic refresh runs on a different thread, while Windows Notify messages run on
    ''' the main thread, it is required that we check to see if an Invoke is required or not.
    ''' </summary>
    ''' <remarks></remarks>
    Private Delegate Sub InvokeUpdate(ByVal sender As Object, ByVal e As ShellItemUpdateEventArgs)

    'Private WithEvents DeskTopItem As CShItem = CShItem.GetDeskTop '7/1/2012

    Private m_InvokeUpdate As New InvokeUpdate(AddressOf DoItemUpdate)

    ''' <summary>
    ''' Returns the last CShItem Selected.
    ''' </summary>
    ''' <remarks>Not currently used.</remarks>
    Public ReadOnly Property SelectedItem() As CShItem
        Get
            Return LastSelectedCSI
        End Get
    End Property
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
    ''' Makes changes in lv1 GUI in response to updating events raised by CShItem.
    ''' </summary>
    ''' <param name="sender">The CShItem of the Folder of the changed item.</param>
    ''' <param name="e">Contains information about the type of change and items affected.</param>
    ''' <remarks>Responds to events raised by either WM_Notify messages or FileWatch (FileWatch not
    ''' implemented in this Form).</remarks>
    Private Sub DoItemUpdate(ByVal sender As Object, ByVal e As ShellItemUpdateEventArgs)
        ' Debug.WriteLine("Enter frmDragDrop DoItemUpdate -- " & e.UpdateType.ToString)
        'If e.Item IsNot Nothing Then  'should never be Nothing ... but ...
        Dim Parent As CShItem = DirectCast(sender, CShItem)
        If Parent Is LastSelectedCSI Then ' 6/11/2012 - OrElse (e.Item Is LastSelectedCSI AndAlso e.UpdateType = CShItemUpdateType.Updated) Then   'If not, then of no interest to us
            Try
                lv1.BeginUpdate()
                Select Case e.UpdateType
                    Case CShItem.CShItemUpdateType.Created
                        Dim lvi As ListViewItem = MakeLVItem(e.Item)
                        lvi.ImageIndex = DirectCast(e.Item, CShItem).IconIndexNormal
                        InsertLvi(lvi, lv1)     '6/11/2012
                        If m_CreateNew Then
                            m_CreateNew = False
                            lvi.BeginEdit()
                        End If
                    Case CShItemUpdateType.Deleted
                        Dim lvi As ListViewItem = FindLVItem(e.Item)
                        If lvi IsNot Nothing Then
                            lv1.Items.Remove(lvi)
                        End If
                    Case CShItemUpdateType.Renamed
                        Dim lvi As ListViewItem = FindLVItem(e.Item)
                        If lvi IsNot Nothing Then
                            If e.Item.Parent IsNot LastSelectedCSI Then     'if true = item renamed to different directory
                                lv1.Items.Remove(lvi)
                            Else
                                lvi.Text = e.Item.DisplayName
                                lvi.ImageIndex = DirectCast(e.Item, CShItem).IconIndexNormal
                                lv1.Items.Remove(lvi)   '6/11/2012
                                InsertLvi(lvi, lv1)     '6/11/2012
                            End If
                        End If
                    Case CShItemUpdateType.UpdateDir  'in this case Parent/sender is the item of interest
                        ' CShItemUpdater, etc. will do the appropriate Adds and Removes, generating
                        ' Created/Deleted events that will occur before an UpdateDir event. There is
                        ' no need to do anything here.
                        'lv1.BeginUpdate()
                        'lv1.Sort()
                        'lv1.EndUpdate()

                    Case CShItemUpdateType.Updated
                        Dim lvi As ListViewItem = FindLVItem(e.Item)
                        If lvi IsNot Nothing Then
                            Dim indx As Integer = lv1.Items.IndexOf(lvi)
                            Dim newLVI As ListViewItem = MakeLVItem(e.Item)
                            newLVI.ImageIndex = DirectCast(e.Item, CShItem).IconIndexNormal
                            lv1.Items.RemoveAt(indx)
                            lv1.Items.Insert(indx, newLVI)
                        End If
                    Case CShItemUpdateType.IconChange
                        Dim lvi As ListViewItem = FindLVItem(e.Item)
                        If lvi IsNot Nothing Then
                            lvi.ImageIndex = DirectCast(e.Item, CShItem).IconIndexNormal
                        End If
                    Case CShItemUpdateType.MediaChange
                        Dim lvi As ListViewItem = FindLVItem(e.Item)
                        If lvi IsNot Nothing Then
                            lvi.Text = e.Item.DisplayName
                            lvi.ImageIndex = DirectCast(e.Item, CShItem).IconIndexNormal
                        End If
                End Select
            Catch ex As Exception
                Debug.WriteLine("Error in frmTemplate -- lv1 updater -- " & ex.ToString)
            Finally
                lv1.EndUpdate()
            End Try
        End If      'end of Parent Is LastSelectedCSI test
        'End If          'of e.Item IsNot Nothing test
    End Sub

    Private Function FindLVItem(ByVal item As CShItem) As ListViewItem
        For Each lvi As ListViewItem In lv1.Items
            If lvi.Tag Is item Then
                Return lvi
            End If
        Next
        Return Nothing
    End Function


    ''' <summary>
    ''' Given a ListViewItem with a  CShItem in its' Tag, and a ListView whose Items all have a CShItem in
    ''' their Tags, Insert the ListViewItem in its' proper place in the ListView.
    ''' </summary>
    ''' <param name="lvi">The ListViewItem to be inserted.</param>
    ''' <param name="LV">The ListView into which the ListViewItem is to be inserted.</param>
    ''' <remarks>6/11/2012 - better than a Sort when the list is in order.<br />
    '''          Will honor any prior Column Sorts.</remarks>
    Private Sub InsertLvi(ByVal lvi As ListViewItem, ByVal LV As ListView)
        Dim Item As CShItem = lvi.Tag
        For i As Integer = 0 To LV.Items.Count - 1
            If DirectCast(LV.Items(i).Tag, CShItem).CompareTo(Item) > 0 Then
                LV.Items.Insert(i, lvi)
                lvi.EnsureVisible()
                Exit Sub
            End If
        Next
        LV.Items.Add(lvi)
        lvi.EnsureVisible()
    End Sub
#End Region

#Region "   lv1_DoubleClick"

    Private Sub lv1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv1.DoubleClick
        Dim csi As CShItem = lv1.SelectedItems(0).Tag
        If csi.IsFolder Then
            ExpTree1.ExpandANode(csi)
        Else
            Try
                Process.Start(csi.Path)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error in starting application")
            End Try
        End If
    End Sub
#End Region

#Region "   LabelEdit Handlers (Item Rename) From Calum"
    ''' <summary>
    ''' Handles Before Item Rename for lv1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
    Private Sub lv1_BeforeLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles lv1.BeforeLabelEdit
        Dim item As CShItem = DirectCast(lv1.Items(e.Item).Tag, CShItem)
        If (Not item.IsFileSystem) Or item.IsDisk Or _
            item.Path = CShItem.GetCShItem(CSIDL.MYDOCUMENTS).Path Or _
            Not (item.CanRename) Then
            System.Media.SystemSounds.Beep.Play()
            e.CancelEdit = True
        End If
    End Sub

    ''' <summary>
    ''' Handles After Item Rename for lv1
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
    Private Sub lv1_AfterLabelEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.LabelEditEventArgs) Handles lv1.AfterLabelEdit
        Dim item As CShItem = DirectCast(lv1.Items(e.Item).Tag, CShItem)
        Dim NewName As String
        Dim index As Integer
        Dim path As String
        If e.Label Is Nothing OrElse e.Label = String.Empty Then Exit Sub '6/11/2012
        Try
            NewName = e.Label.Trim

            If NewName.Length < 1 OrElse NewName.IndexOfAny(System.IO.Path.GetInvalidPathChars) <> -1 Then
                e.CancelEdit = True
                System.Media.SystemSounds.Beep.Play()
                Exit Sub
            End If

            path = item.Path

            index = path.LastIndexOf("\"c)
            If index = -1 Then
                e.CancelEdit = True
                System.Media.SystemSounds.Beep.Play()
                Exit Sub
            End If

            Dim newPidl As IntPtr = IntPtr.Zero
            If item.Parent.Folder.SetNameOf(lv1.Handle, CShItem.ILFindLastID(item.PIDL), NewName, SHGDN.NORMAL, newPidl) = S_OK Then
            Else
                System.Media.SystemSounds.Beep.Play()
                e.CancelEdit = True
            End If
        Catch ex As Exception
            e.CancelEdit = True
            System.Media.SystemSounds.Beep.Play()
            Exit Sub
        End Try
    End Sub
#End Region

#Region "   Context Menu Handlers"
    Private m_WindowsContextMenu As WindowsContextMenu = New WindowsContextMenu

    Private Function IsWithin(ByVal Ctl As Control, ByVal e As MouseEventArgs) As Boolean
        IsWithin = False            'default to Not Within
        If e.X < 0 OrElse e.Y < 0 Then Exit Function
        Dim CR As Rectangle = Ctl.ClientRectangle
        If e.X > CR.Width OrElse e.Y > CR.Height Then Exit Function
        IsWithin = True
    End Function
    ''' <summary>
    ''' Sort the ListViewItems based on the CShItems stored in the .Tag of each ListViewItem.
    ''' </summary>
    ''' <remarks>Cannot use LVColSorter for this since we do not know current state
    ''' </remarks>
    Private Sub SortLVItems()
        With lv1
            If .Items.Count < 2 Then Exit Sub 'no point in sorting 0 or 1 items
            .BeginUpdate()
            Dim tmp(.Items.Count - 1) As ListViewItem
            .Items.CopyTo(tmp, 0)
            Array.Sort(tmp, New TagComparer)
            .Items.Clear()
            .Items.AddRange(tmp)
            .EndUpdate()
        End With
    End Sub

    ''' <summary>
    ''' m_OutOfRange is set to True on lv1.MouseLeave (which happens under many circumstances) to prevent
    ''' the non-ListViewItem specific menu from firing. See Remarks
    ''' m_OutOfRange is set to False (allowing ContextMenus in lv1), only on lv1.MouseDown when the Right
    ''' button is pressed. MouseDown only occurs when the Mouse is really over lv1.
    ''' </summary>
    ''' <remarks>
    '''If you hold down the right mouse button, then leave lv1,
    ''' then let go of the mouse button, the MouseUp event is fired upon
    ''' re-entering the lv1 - meaning that the Windows ContextMenu will
    ''' be shown if we don't use this flag (from Calum)
    '''</remarks>
    Private m_OutOfRange As Boolean

    Private Sub lv1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lv1.MouseLeave
        m_OutOfRange = True
    End Sub

    Private Sub lv1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lv1.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            m_OutOfRange = False
        End If
    End Sub

    ''' <summary>
    ''' Handles RightButton Click to display a System Context Menu
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
    Private Sub lv1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lv1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not IsWithin(lv1, e) Then Exit Sub
            If m_OutOfRange Then Exit Sub
            Dim tn As ListViewItem
            Dim pt As New System.Drawing.Point(e.X, e.Y)
            tn = lv1.GetItemAt(e.X, e.Y)
            If Not IsNothing(tn) AndAlso lv1.SelectedItems.Count > 0 Then
                Dim itms(lv1.SelectedItems.Count - 1) As CShItem
                For i As Integer = 0 To lv1.SelectedItems.Count - 1
                    itms(i) = DirectCast(lv1.SelectedItems(i).Tag, CShItem)
                Next
                Dim cmi As CMInvokeCommandInfoEx = Nothing
                Dim allowRename As Boolean = True          'Don't allow rename of more than 1 item
                If lv1.SelectedItems.Count > 1 Then allowRename = False
                If m_WindowsContextMenu.ShowMenu(Me.Handle, itms, MousePosition, allowRename, cmi) Then
                    'Check for rename
                    Dim cmdBytes(256) As Byte
                    m_WindowsContextMenu.winMenu.GetCommandString(cmi.lpVerb.ToInt32, GCS.VERBA, 0, cmdBytes, 256)

                    Dim cmdName As String = szToString(cmdBytes).ToLower
                    If cmdName.Equals("rename") Then
                        lv1.LabelEdit = True
                        tn.BeginEdit()
                    Else
                        m_WindowsContextMenu.InvokeCommand(m_WindowsContextMenu.winMenu, cmi.lpVerb, itms(0).Parent.Path, pt)
                    End If
                    Marshal.ReleaseComObject(m_WindowsContextMenu.winMenu)
                End If
            Else
                GetFolderMenu(MousePosition)
            End If
        End If
    End Sub

#Region "           Folder ContextMenu for a Click on the ListView itself (not on a ListViewItem)"

    Private Sub GetFolderMenu(ByVal pt As Drawing.Point)
        Dim HR As Integer
        Dim min As Integer = 1
        Dim max As Integer = 100000
        Dim cmi As New CMInvokeCommandInfoEx
        Dim comContextMenu As IntPtr = CreatePopupMenu()
        Dim viewSubMenu As IntPtr = CreatePopupMenu()
        ' Dim sortSubMenu As IntPtr = CreatePopupMenu()

        'Check item count - should always be 0 but check just in case
        Dim startIndex As Integer = GetMenuItemCount(comContextMenu.ToInt32)
        'Fill the context menu
        Dim itemInfo As New MENUITEMINFO("View")
        itemInfo.fMask = MIIM.SUBMENU Or MIIM.STRING
        itemInfo.hSubMenu = viewSubMenu
        InsertMenuItem(comContextMenu, 0, True, itemInfo)
        Dim checked As Integer = MFT.BYCOMMAND
        If lv1.View = View.Tile Then checked = MFT.RADIOCHECK Or MFT.CHECKED
        AppendMenu(viewSubMenu, checked, CMD.TILES, "Tiles")
        checked = MFT.BYCOMMAND
        If lv1.View = View.LargeIcon Then checked = MFT.RADIOCHECK Or MFT.CHECKED
        AppendMenu(viewSubMenu, checked, CMD.LARGEICON, "Large Icons")
        checked = MFT.BYCOMMAND
        If lv1.View = View.List Then checked = MFT.RADIOCHECK Or MFT.CHECKED
        AppendMenu(viewSubMenu, checked, CMD.LIST, "List")
        checked = MFT.BYCOMMAND
        If lv1.View = View.Details Then checked = MFT.RADIOCHECK Or MFT.CHECKED
        AppendMenu(viewSubMenu, checked, CMD.DETAILS, "Details")
        checked = MFT.BYCOMMAND

        AppendMenu(comContextMenu, MFT.SEPARATOR, 0, String.Empty)
        AppendMenu(comContextMenu, MFT.BYCOMMAND, CMD.REFRESH, "Refresh")
        AppendMenu(comContextMenu, MFT.SEPARATOR, 0, String.Empty)

        Dim enabled As Integer = MFT.GRAYED
        Dim effects As DragDropEffects
        If LastSelectedCSI Is Nothing Then
            enabled = MFT.BYCOMMAND
        Else
            effects = ShellHelper.CanDropClipboard(LastSelectedCSI)
            If ((effects And DragDropEffects.Copy) = DragDropEffects.Copy) Or _
                    ((effects And DragDropEffects.Move) = DragDropEffects.Move) Then ' Enable paste for stand-alone ExpList
                enabled = MFT.BYCOMMAND
            End If
        End If
        AppendMenu(comContextMenu, enabled, CMD.PASTE, "Paste")

        If LastSelectedCSI IsNot Nothing Then
            enabled = MFT.GRAYED
            If ((effects And DragDropEffects.Link) = DragDropEffects.Link) Then
                enabled = MFT.BYCOMMAND
            End If

            AppendMenu(comContextMenu, enabled, CMD.PASTELINK, _
                    "Paste Link")
            AppendMenu(comContextMenu, MFT.SEPARATOR, 0, String.Empty)

            ' Add the 'New' menu
            If LastSelectedCSI.IsFolder And _
                ((Not LastSelectedCSI.Path.StartsWith("::")) Or (LastSelectedCSI Is CShItem.GetDeskTop)) Then
                Dim xIndex As Integer = GetMenuItemCount(comContextMenu)
                m_WindowsContextMenu.SetUpNewMenu(LastSelectedCSI, comContextMenu, xIndex) ' 6) ' 7)
                AppendMenu(comContextMenu, MFT.SEPARATOR, 0, String.Empty)
            End If
            AppendMenu(comContextMenu, MFT.BYCOMMAND, CMD.PROPERTIES, _
                    "Properties")
        End If

        Dim cmdID As Integer = _
            TrackPopupMenuEx(comContextMenu, TPM.RETURNCMD, _
            pt.X, pt.Y, Me.Handle, IntPtr.Zero)


        If cmdID >= min Then
            cmi = New CMInvokeCommandInfoEx
            cmi.cbSize = Marshal.SizeOf(cmi)
            cmi.nShow = SW.SHOWNORMAL
            cmi.fMask = CMIC.UNICODE Or CMIC.PTINVOKE
            cmi.ptInvoke = New Drawing.Point(pt.X, pt.Y)

            Select Case cmdID
                Case CMD.TILES
                    lv1.View = View.Tile
                    GoTo CLEANUP
                Case CMD.LARGEICON
                    lv1.View = View.LargeIcon
                    GoTo CLEANUP
                Case CMD.LIST
                    lv1.View = View.List
                    GoTo CLEANUP
                Case CMD.DETAILS
                    lv1.View = View.Details
                    GoTo CLEANUP
                    'Case CMD.THUMBNAILS
                    '    lv1.View = View.Thumbnail
                    '    GoTo CLEANUP
                Case CMD.REFRESH
                    If LastSelectedCSI IsNot Nothing Then
                        LastSelectedCSI.UpdateRefresh()
                    End If
                    SortLVItems()
                    GoTo CLEANUP
                Case CMD.PASTE
                    If LastSelectedCSI IsNot Nothing Then
                        cmi.lpVerb = Marshal.StringToHGlobalAnsi("paste")
                        cmi.lpVerbW = Marshal.StringToHGlobalUni("paste")
                    Else
                        GoTo CLEANUP
                    End If
                Case CMD.PASTELINK
                    cmi.lpVerb = Marshal.StringToHGlobalAnsi("pastelink")
                    cmi.lpVerbW = Marshal.StringToHGlobalUni("pastelink")
                Case CMD.PROPERTIES
                    cmi.lpVerb = Marshal.StringToHGlobalAnsi("properties")
                    cmi.lpVerbW = Marshal.StringToHGlobalUni("properties")
                Case Else
                    If CShItem.IsVista Then cmdID -= 1 '12/15/2010 Change
                    cmi.lpVerb = CType(cmdID, IntPtr)
                    cmi.lpVerbW = CType(cmdID, IntPtr)
                    m_CreateNew = True
                    HR = m_WindowsContextMenu.newMenu.InvokeCommand(cmi)
#If DEBUG Then
                    If HR <> S_OK Then
                        Marshal.ThrowExceptionForHR(HR)
                    End If
#End If

                    GoTo CLEANUP
            End Select

            ' Invoke the Paste, Paste Shortcut or Properties command
            If LastSelectedCSI IsNot Nothing Then
                Dim prgf As Integer = 0
                Dim iunk As IntPtr = IntPtr.Zero
                Dim folder As ShellDll.IShellFolder = Nothing
                If LastSelectedCSI Is CShItem.GetDeskTop Then
                    folder = LastSelectedCSI.Folder
                Else
                    folder = LastSelectedCSI.Parent.Folder
                End If

                Dim relPidl As IntPtr = CShItem.ILFindLastID(LastSelectedCSI.PIDL)
                HR = folder.GetUIObjectOf(IntPtr.Zero, 1, New IntPtr() {relPidl}, IID_IContextMenu, prgf, iunk)
#If DEBUG Then
                If Not HR = S_OK Then
                    Marshal.ThrowExceptionForHR(HR)
                End If
#End If

                m_WindowsContextMenu.winMenu = CType(Marshal.GetObjectForIUnknown(iunk), IContextMenu)
                HR = m_WindowsContextMenu.winMenu.InvokeCommand(cmi)
                m_WindowsContextMenu.ReleaseMenu()

#If DEBUG Then
                If Not HR = S_OK Then
                    Marshal.ThrowExceptionForHR(HR)
                End If
#End If
            End If
        End If      '12/15/2010 change
CLEANUP:
        m_WindowsContextMenu.ReleaseNewMenu()

        Marshal.Release(comContextMenu)
        comContextMenu = IntPtr.Zero
        Marshal.Release(viewSubMenu)
        viewSubMenu = IntPtr.Zero

    End Sub

#End Region

    ''' <summary>
    ''' Handles Windows Messages having to do with the display of Cascading menus of the Context Menu.
    ''' </summary>
    ''' <param name="m">The Windows Message</param>
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        'For send to menu in the ListView context menu
        Dim hr As Integer = 0
        If m.Msg = WM.INITMENUPOPUP Or m.Msg = WM.MEASUREITEM Or m.Msg = WM.DRAWITEM Then
            If Not m_WindowsContextMenu.winMenu2 Is Nothing Then
                hr = m_WindowsContextMenu.winMenu2.HandleMenuMsg(m.Msg, m.WParam, m.LParam)
                If hr = 0 Then
                    Return
                End If
            ElseIf (m.Msg = WM.INITMENUPOPUP And m.WParam = m_WindowsContextMenu.newMenuPtr) _
                    Or m.Msg = WM.MEASUREITEM Or m.Msg = WM.DRAWITEM Then
                If Not m_WindowsContextMenu.newMenu2 Is Nothing Then
                    hr = m_WindowsContextMenu.newMenu2.HandleMenuMsg(m.Msg, m.WParam, m.LParam)
                    If hr = 0 Then
                        Return
                    End If
                End If
            End If
        ElseIf m.Msg = WM.MENUCHAR Then
            If Not m_WindowsContextMenu.winMenu3 Is Nothing Then
                hr = m_WindowsContextMenu.winMenu3.HandleMenuMsg2(m.Msg, m.WParam, m.LParam, IntPtr.Zero)
                If hr = 0 Then
                    Return
                End If
            End If
        End If
        MyBase.WndProc(m)
    End Sub
#End Region

#Region "   Keyboard Events "
    ''' <summary>
    ''' Handles Delete Key processing for the ListView
    ''' </summary>
    ''' <param name="sender">object that raised the event</param>
    ''' <param name="e">a KeyEventsArgs</param>
    ''' <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
    Private Sub ExpList_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lv1.KeyUp
        If e.KeyCode = Keys.Delete Then
            If LastSelectedCSI IsNot Nothing AndAlso LastSelectedCSI.IsFolder Then
                Dim HR As Integer
                Dim prgf As Integer = 0
                Dim iunk As IntPtr = IntPtr.Zero
                Dim folder As ShellDll.IShellFolder = LastSelectedCSI.Folder
                Dim pidls(lv1.SelectedItems.Count - 1) As IntPtr
                Dim i As Integer

                For i = 0 To lv1.SelectedItems.Count - 1
                    If Not DirectCast(lv1.SelectedItems(i).Tag, CShItem).CanDelete Then
                        MsgBox("Cannot Delete: " & DirectCast(lv1.SelectedItems(i).Tag, CShItem).DisplayName, MsgBoxStyle.OkOnly, "Cannot Delete")
                        Exit Sub
                    End If
                    'If Not lv1.SelectedItems(i).Tag.CanRename Then AllowRename = False
                    pidls(i) = CShItem.ILFindLastID(lv1.SelectedItems(i).Tag.PIDL)
                Next
                Dim relPidl As IntPtr = CShItem.ILFindLastID(LastSelectedCSI.PIDL)
                HR = folder.GetUIObjectOf(IntPtr.Zero, pidls.Length, pidls, IID_IContextMenu, prgf, iunk)
#If DEBUG Then
                If Not HR = S_OK Then
                    Marshal.ThrowExceptionForHR(HR)
                End If
#End If
                m_WindowsContextMenu.winMenu = CType(Marshal.GetObjectForIUnknown(iunk), IContextMenu)
                Dim cmi As New CMInvokeCommandInfoEx
                cmi.cbSize = Marshal.SizeOf(cmi)
                cmi.nShow = SW.SHOWNORMAL
                cmi.fMask = CMIC.UNICODE Or CMIC.PTINVOKE
                cmi.ptInvoke = New Drawing.Point(0, 0)
                cmi.lpVerb = Marshal.StringToHGlobalAnsi("delete")
                cmi.lpVerbW = Marshal.StringToHGlobalUni("delete")

                HR = m_WindowsContextMenu.winMenu.InvokeCommand(cmi)
                m_WindowsContextMenu.ReleaseMenu()
#If DEBUG Then
                If Not HR = S_OK Then
                    Marshal.ThrowExceptionForHR(HR)
                End If
#End If
                'Else
                '    Dim itm As ListViewItem
                '    For Each itm In lv1.SelectedItems
                '        m_items.Remove(itm)
                '    Next
            End If
        End If
    End Sub

#End Region

#Region "   Test of storing and retrieving Overlaid Jumbo IconImages in Local (rather than System) ImageList"
    Private Sub lv1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lv1.SelectedIndexChanged
        If lv1.SelectedIndices.Count < 1 Then Exit Sub
        Dim Item As CShItem = lv1.Items(lv1.SelectedIndices(0)).Tag
        tsslMiddle.Text = Item.Path
        pbLarge.Image = GetIcon(Item.IconIndexNormal).ToBitmap
        pbXLarge.Image = GetXLIcon(Item.IconIndexNormal).ToBitmap
        Dim BM As Bitmap = GetLocalImage(Item.Path)
        If BM Is Nothing Then
            pbJumbo.Image = GetJumboIcon(Item.IconIndexNormal).ToBitmap
        Else
            pbJumbo.Image = BM
        End If
        pbOrigLarge.Image = GetIcon(GetNonOverlayIndex(Item)).ToBitmap
        pbOrigXL.Image = GetXLIcon(GetNonOverlayIndex(Item)).ToBitmap
        pbOrigJumbo.Image = GetJumboIcon(GetNonOverlayIndex(Item)).ToBitmap
    End Sub

    Dim ImgDict As New Dictionary(Of String, Integer)(64)
    Private Sub BuildTestList()
        For Each lvi As ListViewItem In lv1.Items
            Dim Item As CShItem = lvi.Tag
            If Item.IsLink Then
                Dim hIcon As IntPtr = IntPtr.Zero
                Dim rVal As Integer = GetNonOverlayIndex(Item)

                Dim flags As ShellAPI.ILD = ILD.NORMAL
                If Item.IsLink Then flags = flags Or INDEXTOOVERLAYMASK(ovlLink)
                If Item.IsShared Then flags = flags Or INDEXTOOVERLAYMASK(ovlShare)
                hIcon = ImageList_GetIcon(hJumboImageList, rVal, flags)
                Dim Indx As Integer
                Indx = ImageList_ReplaceIcon(ImageList1.Handle, -1, hIcon)
                ImgDict.Add(Item.Path, Indx)
            End If
        Next
    End Sub
    Private Function GetLocalImage(ByVal Key As String) As Bitmap
        If Not ImgDict.ContainsKey(Key) Then Return Nothing
        Return ImageList1.Images(ImgDict(Key))
    End Function
#End Region

End Class
