﻿Imports ExpTreeLib
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
''' This Form is an <b>optimized</b> fully working start point for any form which requires an ExplorerTree and
''' ListView. It illustrates the use of a BackgroundWorker to insert slow to gather information into ListViewItems.
''' It leaves enough room for application specific controls. 
''' </summary>
''' <remarks>
''' <para>This Form illustrates the use of:
''' <list type="bullet">
''' <item><description>Use of a BackgroundWorker to improve GUI responsiveness.</description></item>
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
''' </para>
''' </remarks>
Public Class frmThread_TestVersion
    'avoid Globalization problem-- an empty timevalue
    Dim EmptyTimeValue As New DateTime(1, 1, 1, 0, 0, 0)

    Private LastSelectedCSI As CShItem

    Private DW As CDragWrapper              'wrapper for Drag ops originating in lv1
    Private DropWrap As ClvDropWrapper      'wrapper for Drop ops targeting lv1

    Private m_CreateNew As Boolean = False  'Flag for NewMenu processing of "New" item

#Region "   Public Properties"
    ''' <summary>
    ''' InitialLoadLimit is a the number of lv1.Items whose IconIndex will we fetched on initial load
    ''' the balance will be fetched AFTER lv1 shows its initial display
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), Category("Misc"), _
    Description("Maximum # of Items to build in GUI Thread for initial display"), _
    DefaultValue(32)> _
    Public Property InitialLoadLimit() As Integer
        Get
            Return _InitialLoadLimit
        End Get
        Set(ByVal value As Integer)
            _InitialLoadLimit = value
        End Set
    End Property
    Private _InitialLoadLimit As Integer = 32

    ''' <summary>
    ''' WorkUpdateInterval is the Maximum # of Items to build in each 
    ''' BackGroundWorker Progress Interval before reporting them back to the GUI.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>If there are 200 items to show, the first InitialLoadLimit will be built and
    '''          displayed in the GUI thread. The balance will be built in the BackgroundWorker
    '''          thread and reported back to the GUI in chunks of WorkUpdateInterval Items.</remarks>
    <Browsable(True), Category("Misc"), _
    Description("Maximum # of Items in each Background update interval"), _
    DefaultValue(100)> _
    Public Property WorkUpdateInterval() As Integer
        Get
            Return _WorkUpdateInterval
        End Get
        Set(ByVal value As Integer)
            _WorkUpdateInterval = value
        End Set
    End Property
    Private _WorkUpdateInterval As Integer = 100
#End Region

#Region "   Form Close Methods"
    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub frmThread_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing  '7/1/2012
        RemoveHandler CShItemUpdate, AddressOf UpdateInvoke '7/1/2012
        Event2.Close()          '7/8/2012
    End Sub         '7/1/2012

#End Region

#Region "   Form Load/VisibleChanged, lv1 HandleCreated"

    Private Sub frmThread_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub frmThread_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        SystemImageListManager.SetListViewImageList(lv1, False, False)
        SystemImageListManager.SetListViewImageList(lv1, True, False)
    End Sub
#End Region

#Region "   ExplorerTree Event Handling -- AfterNodeSelect"
    Private Sub AfterNodeSelect(ByVal pathName As String, ByVal CSI As CShItem) _
           Handles ExpTree1.ExpTreeNodeSelected

        If LastSelectedCSI IsNot Nothing AndAlso LastSelectedCSI Is CSI Then Exit Sub
        Cursor = Cursors.WaitCursor
        tsslMiddle.Text = pathName
        Me.Text = pathName
        tsslLeft.Text = "Building Display"

        If BGW2 IsNot Nothing Then
            BGW2.CancelAsync()
            Event2.WaitOne()
        End If
        Dim TotalItems As Integer
        Dim StTime As DateTime = Now()
        Dim combList As ArrayList = CSI.GetItems

        TotalItems = combList.Count
        If TotalItems > 0 Then
            'Build the ListViewItems & add to lv1
            lv1.BeginUpdate()
            lv1.Items.Clear()
            If LastSelectedCSI IsNot Nothing AndAlso LastSelectedCSI IsNot CSI Then
                LastSelectedCSI.ClearItems(True)
            End If
            lv1.Refresh()

            Dim InitialFillLim As Integer = Math.Min(combList.Count, InitialLoadLimit)
            Dim FirstLoad As New List(Of ListViewItem)(InitialFillLim)
            For i As Integer = 0 To InitialFillLim - 1
                Dim lvi As ListViewItem = MakeSparceLVItem(combList(i))
                RefreshLvi(lvi)
                lvi.ImageIndex = SystemImageListManager.GetIconIndex(combList(i), False)
                FirstLoad.Add(lvi)
            Next
            lv1.Items.AddRange(FirstLoad.ToArray)

            'Fill the ListView with the remaining items without FileInfo or ICon
            Dim SparseLoad As New List(Of ListViewItem)(combList.Count - InitialFillLim)
            If combList.Count > InitialFillLim Then
                For i As Integer = InitialFillLim To combList.Count - 1
                    Dim lvi As ListViewItem = MakeSparceLVItem(combList(i))
                    RefreshLvi(lvi, True)
                    SparseLoad.Add(lvi)
                Next
                lv1.Items.AddRange(SparseLoad.ToArray)
            End If
            lv1.EndUpdate()

            If combList.Count > InitialLoadLimit Then
                LoadLV1(SparseLoad)
            End If
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
        Debug.WriteLine("Visible " & CSI.Text & " " & Now().Subtract(StTime).TotalMilliseconds.ToString & "ms")
        ShowCounts()
        Cursor = Cursors.Default
    End Sub

    Private Sub ShowCounts()
        If lv1.Items.Count > 0 Then
            Dim Dirs As Integer
            Dim Files As Integer
            For Each lvi As ListViewItem In lv1.Items
                Dim Item As CShItem = lvi.Tag
                If Item.IsFolder Then
                    Dirs += 1
                Else : Files += 1
                End If
            Next
            tsslRight.Text = Dirs & " Directories " & Files & " Files"
        Else
            tsslRight.Text = " Has No Items"
        End If
    End Sub
#End Region

#Region "   Various MakeLV routines"

    ''' <summary>
    ''' Creates a minimal ListViewItem from the input CShItem
    ''' </summary>
    ''' <param name="item">The CShItem that this ListViewItem represents</param>
    ''' <returns>A ListViewItem with .Tag and .Text filled, with empty SubItems for the balance of the SubItems required by the ListView.</returns>
    ''' <remarks>When it is timely to fill the remaining SubItems with data (after BGW2 has completed), call RefreshLvi.</remarks>
    Private Function MakeSparceLVItem(ByVal item As CShItem) As ListViewItem
        Dim lvi As New ListViewItem(item.DisplayName)
        With lvi
            .Tag = item
            For i As Integer = 1 To lv1.Columns.Count - 1
                .SubItems.Add("")
            Next
        End With
        Return lvi
    End Function

    ''' <summary>
    ''' Loads all of a ListViewItem's SubItems with values from the associated CShItem - obtained from the ListViewItem's .Tag.
    ''' Note that the CShItem's time sensitive values will be set by CShItem using a W32_FindData structure if it finds one in the
    ''' CShItem's .Tag - as set in this Form by a BackgroundWorker.
    ''' </summary>
    ''' <param name="lvi">The ListViewItem to be refreshed</param>
    ''' <param name="DeferSet">If True, Defer the filling of Length and Date information until later (in the BackgroundWorker).
    '''                        If False (the default) fill Length and Date information in this call.</param>
    ''' <remarks>For optimization, depends on BGW2 having filled CSI.W32Data with a W32Find_Data structure which CShItem will 
    '''          use for Length, Attributes, and Date information.</remarks>
    Private Sub RefreshLvi(ByVal lvi As ListViewItem, Optional ByVal DeferSet As Boolean = False)
        Dim CSI As CShItem = lvi.Tag
        'Set the Items that must come from a CShItem
        lvi.Text = CSI.Name
        lvi.SubItems(3).Text = CSI.TypeName

        If Not DeferSet Then    'Set the SubItems that may come from an W32Find_Data
            With lvi
                'Set Length
                If CSI.IsDisk OrElse (CSI.IsFileSystem And Not CSI.IsFolder) Then      'Not CSI.IsDisk And
                    If CSI.Length > 1024 Then
                        .SubItems(1).Text = (Format(CSI.Length / 1024, "#,### KB"))
                    Else
                        .SubItems(1).Text = (Format(CSI.Length, "##0 Bytes"))
                    End If
                    .SubItems(1).Tag = CSI.Length
                Else
                    '.SubItems(1) already has been correctly set to blank entry
                    'But, to make LVColSorter work correctly, then we have to Set the .Tag to 0 (really)
                    .SubItems(1).Tag = 0L
                End If
                'Set LastWriteTime
                If CSI.IsDisk OrElse CSI.LastWriteTime = EmptyTimeValue Then '"#1/1/0001 12:00:00 AM#" is empty
                    '.SubItems(2) already has been correctly set to blank entry
                    'But, to make LVColSorter work correctly, then we have to Set the .Tag to EmptyTimeValue
                    ' (Not really in this case, but it is good to do in the general case)
                    .SubItems(2).Tag = EmptyTimeValue
                Else
                    .SubItems(2).Text = CSI.LastWriteTime.ToString("MM/dd/yyyy HH:mm:ss")   '01/01/2014
                    .SubItems(2).Tag = CSI.LastWriteTime
                End If
                'Set Attributes
                If Not CSI.IsDisk And CSI.IsFileSystem Then
                    Dim SB As New StringBuilder()
                    Try
                        Dim attr As FileAttributes = CSI.Attributes
                        If (attr And FileAttributes.System) = FileAttributes.System Then SB.Append("S")
                        If (attr And FileAttributes.Hidden) = FileAttributes.Hidden Then SB.Append("H")
                        If (attr And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then SB.Append("R")
                        If (attr And FileAttributes.Archive) = FileAttributes.Archive Then SB.Append("A")
                    Catch
                    End Try
                    .SubItems(4).Text = SB.ToString
                Else
                    '.SubItems(4) already has been correctly set to blank entry
                    'But, to make LVColSorter work correctly, then we have to Set the .Tag to EmptyTimeValue
                    ' (Not really in this case, but it is good to do in the general case)
                    .SubItems(4).Tag = EmptyTimeValue
                End If
                'Set CreationTime
                If CSI.IsDisk OrElse CSI.CreationTime = EmptyTimeValue Then '"#1/1/0001 12:00:00 AM#" is empty
                    '.SubItems(5) already has been correctly set to blank entry
                    'But, to make LVColSorter work correctly, then we have to Set the .Tag to EmptyTimeValue
                    ' (Not really in this case, but it is good to do in the general case)
                    .SubItems(5).Tag = EmptyTimeValue
                Else
                    .SubItems(5).Text = CSI.CreationTime.ToString("MM/dd/yyyy HH:mm:ss")   '01/01/2014
                    .SubItems(5).Tag = CSI.CreationTime
                End If
            End With
        End If
    End Sub

#End Region

#Region "   The Background worker"
    Private WithEvents BGW2 As BackgroundWorker
    Private Event2 As New ManualResetEvent(True)
    Private InBkground As Integer = 0
    Private ItemInfo As Dictionary(Of String, W32Find_Data)
    Private BkStTime As DateTime

    Private Sub LoadLV1(ByVal ListToDo As List(Of ListViewItem))
        Debug.WriteLine("----LoadLV1 ListToDo.Count = " & ListToDo.Count)
        BkStTime = Now()
        If ListToDo IsNot Nothing AndAlso ListToDo.Count > 0 Then
            Event2.Reset()
            BGW2 = New BackgroundWorker
            tsslLeft.Text = "Loading Info"
            With BGW2
                .WorkerReportsProgress = True
                .WorkerSupportsCancellation = True
                InBkground = 0
                .RunWorkerAsync(ListToDo)
            End With
        End If
    End Sub

    '7/8/2012 - Routine modified to correct a potential deadlock
    Private Sub BGW2_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGW2.DoWork
        Dim ThisWorker As BackgroundWorker = sender
        Dim WorkList As List(Of ListViewItem) = e.Argument
        Dim Results As New List(Of ListViewItem)(WorkUpdateInterval)
        Dim Item As CShItem = DirectCast(WorkList(0).Tag, CShItem).Parent
        If Item.IsFileSystem AndAlso WorkList.Count > 0 Then
            GetItemDatas(Item, WorkList)
        End If
        For i As Integer = 0 To WorkList.Count - 1
            If ThisWorker.CancellationPending Then
                e.Cancel = True : Results = Nothing
                Exit For
            End If
            Item = WorkList(i).Tag
            'Force fetch of IconIndex 
            Dim tmp As Integer = Item.IconIndexNormal
            Results.Add(WorkList(i))
            If Results.Count = WorkUpdateInterval Then
                If ThisWorker.CancellationPending Then
                    e.Cancel = True : Results = Nothing
                    Exit For
                End If
                ThisWorker.ReportProgress(i, Results)
                Results = New List(Of ListViewItem)(WorkUpdateInterval)
            End If
        Next
        Event2.Set()
        e.Result = Results
    End Sub

    Private Sub BGW2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGW2.ProgressChanged
        Dim Items As List(Of ListViewItem) = e.UserState
        For Each Lvi As ListViewItem In Items
            SetLvi(Lvi)
            InBkground += 1
        Next
    End Sub

    Private Sub BGW2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGW2.RunWorkerCompleted
        Debug.WriteLine("----RWCompleted - " & e.ToString)
        If Not e.Cancelled AndAlso e.Error Is Nothing Then
            If e.Result IsNot Nothing Then
                Dim Items As List(Of ListViewItem) = e.Result
                For Each Lvi As ListViewItem In Items
                    SetLvi(Lvi)
                    InBkground += 1
                Next
            End If
        End If
        Debug.WriteLine("Total " & " " & Now().Subtract(BkStTime).TotalMilliseconds.ToString & "ms")
        'Debug.WriteLine(InBkground & " Items set in BGW2")
        Event2.Set()
        BGW2.Dispose()          '7/8/2012
        BGW2 = Nothing
    End Sub

    Private Sub GetItemDatas(ByVal BaseCSI As CShItem, ByVal LVIList As List(Of ListViewItem))
        ItemInfo = New Dictionary(Of String, W32Find_Data)(LVIList.Count)
        Try
            GetInfos(BaseCSI)
        Catch ex As ApplicationException    'only occurs on Invalid Handle - we have nothing to do
            Exit Sub
        End Try
        For Each Lvi As ListViewItem In LVIList
            Dim CSI As CShItem = Lvi.Tag
            Dim csiName As String = IO.Path.GetFileName(CSI.Path)
            If CSI.IsFolder Then
                csiName = csiName & "\"
            End If
            If ItemInfo.ContainsKey(csiName) Then
                CSI.W32Data = ItemInfo(csiName)
            Else
#If DEBUG Then
                Throw New ArgumentException("No ItemData for " & CSI.Path)
#End If
            End If
        Next
    End Sub

    Private Sub GetInfos(ByVal CSI As CShItem)

        Dim DirName As String = CSI.Path
        Dim Data As New W32Find_Data(DirName)

        Dim Handle As SafeFindHandle = Nothing

        Handle = FindFirstFile(DirName & "\*", Data)
        If Handle.IsInvalid Then
            Debug.WriteLine("Invalid Handle for " & CSI.Path)
            Throw New ApplicationException("Invalid FindFileHandle returned for " & DirName)
        End If
        Dim HR As Boolean = True
        While (HR)
            If (Data.dwFileAttributes And FileAttributes.Directory) <> 0 Then
                If Not Data.cFileName.StartsWith(".") Then
                    ItemInfo.Add(Data.Name & "\", Data)
                End If
            Else
                ItemInfo.Add(Data.Name, Data)
            End If
            Data = New W32Find_Data(DirName)
            HR = FindNextFile(Handle, Data)
        End While
        Handle.Close()
    End Sub

    Private Sub SetLvi(ByVal Lvi As ListViewItem)
        Dim CSI As CShItem = Lvi.Tag
        Lvi.ImageIndex = CSI.IconIndexNormal
        RefreshLvi(Lvi)
    End Sub

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
        lv1.TileSize = New Size(CInt(lv1.ClientSize.Width * 0.333), CInt(lv1.ClientSize.Height / 4))
        lv1.View = View.Tile
    End Sub
#End Region

#Region "   Dynamic Update Handler"
    ''' <summary>
    ''' To receive notification of changes to the FileSystem which may affect the GUI display, declare
    ''' DeskTopItem WithEvents. Changes to CShItem's internal tree which are caused by notification of 
    ''' FileSystem changes or by a refresh of the contents of the internal tree raise CShItemUpdate
    ''' events.  For possible future changes, we check to see if an Invoke is required or not.
    ''' </summary>
    ''' <remarks></remarks>
    Private Delegate Sub InvokeUpdate(ByVal sender As Object, ByVal e As ShellItemUpdateEventArgs)

    'Private WithEvents DeskTopItem As CShItem = CShItem.GetDeskTop '7/1/2012

    Private m_InvokeUpdate As New InvokeUpdate(AddressOf DoItemUpdate)

    ''' <summary>
    ''' Returns the last CShItem Selected.
    ''' </summary>
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
    ''' <remarks>Responds to events raised by WM_Notify messages. </remarks>
    Private Sub DoItemUpdate(ByVal sender As Object, ByVal e As ShellItemUpdateEventArgs)
        Debug.WriteLine("Enter frmThread DoItemUpdate -- " & DirectCast(e.Item, CShItem).DisplayName & " - " & e.UpdateType.ToString)
        Dim Parent As CShItem = DirectCast(sender, CShItem)
        If Parent Is LastSelectedCSI Then ' 6/11/2012 - OrElse (e.Item Is LastSelectedCSI AndAlso e.UpdateType = CShItemUpdateType.Updated) Then   'If not, then of no interest to us
            Try
                lv1.BeginUpdate()
                Select Case e.UpdateType
                    Case CShItem.CShItemUpdateType.Created
                        Dim lvi As ListViewItem = MakeSparceLVItem(e.Item)
                        lvi.ImageIndex = e.Item.IconIndexNormal
                        RefreshLvi(lvi)
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
                                RefreshLvi(lvi)
                                e.Item.ResetIconIndex()                       'may have changed
                                lvi.ImageIndex = e.Item.IconIndexNormal
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
                            Dim newLVI As ListViewItem = MakeSparceLVItem(e.Item)
                            RefreshLvi(newLVI)
                            e.Item.ResetIconIndex()                       'may have changed
                            newLVI.ImageIndex = e.Item.IconIndexNormal
                            lv1.Items.RemoveAt(indx)
                            lv1.Items.Insert(indx, newLVI)
                        End If
                    Case CShItemUpdateType.IconChange
                        Dim lvi As ListViewItem = FindLVItem(e.Item)
                        If lvi IsNot Nothing Then
                            e.Item.ResetIconIndex()
                            lvi.ImageIndex = e.Item.IconIndexNormal
                        End If
                    Case CShItemUpdateType.MediaChange
                        Dim lvi As ListViewItem = FindLVItem(e.Item)
                        If lvi IsNot Nothing Then
                            RefreshLvi(lvi)
                            e.Item.ResetIconIndex()
                            lvi.ImageIndex = e.Item.IconIndexNormal
                        End If
                End Select

            Catch ex As Exception
                Debug.WriteLine("Error in frmThread -- lv1 updater -- " & ex.ToString)
            Finally
                lv1.EndUpdate()
            End Try
            ShowCounts()
        End If      'end of Parent Is LastSelectedCSI test
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
        If lv1.ListViewItemSorter IsNot Nothing AndAlso TypeOf lv1.ListViewItemSorter Is LVColSorter Then
            Dim CSorter As LVColSorter = DirectCast(lv1.ListViewItemSorter, LVColSorter)
            For i As Integer = 0 To LV.Items.Count - 1
                If CSorter.Compare(LV.Items(i), lvi) > 0 Then
                    LV.Items.Insert(i, lvi)
                    lvi.EnsureVisible()
                    Exit Sub
                End If
            Next
        Else
            For i As Integer = 0 To LV.Items.Count - 1
                If DirectCast(LV.Items(i).Tag, CShItem).CompareTo(Item) > 0 Then
                    LV.Items.Insert(i, lvi)
                    lvi.EnsureVisible()
                    Exit Sub
                End If
            Next
        End If
        'on fall thru, did not find a spot to insert, so it goes at then end
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
    ''' Handles RightButton Click
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
    Private Sub lv1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lv1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If Not IsWithin(lv1, e) Then Exit Sub
            If m_OutOfRange Then Exit Sub
            Dim lvi As ListViewItem
            Dim pt As New System.Drawing.Point(e.X, e.Y)
            lvi = lv1.GetItemAt(e.X, e.Y)
            If Not IsNothing(lvi) AndAlso lv1.SelectedItems.Count > 0 Then
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
                        lvi.BeginEdit()
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

#Region "           Windows Folder ContextMenu "

    Private Sub GetFolderMenu(ByVal pt As Drawing.Point)
        Dim HR As Integer
        Dim min As Integer = 1
        Dim max As Integer = 100000
        Dim cmi As New CMInvokeCommandInfoEx
        Dim comContextMenu As IntPtr = CreatePopupMenu()
        Dim viewSubMenu As IntPtr = CreatePopupMenu()

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
            End If
        End If
    End Sub

#End Region

#Region "   Test Routines - Only found in this version of this Form"
    'Private Sub TestFindToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestFindToolStripMenuItem.Click
    '    Dim CTest As CShItem = GetCShItem("C:\Testing")
    '    If CTest Is Nothing Then
    '        Debug.WriteLine("C:\Testing Not Got")
    '        Exit Sub
    '    End If
    '    Dim FCT As CShItem = FindCShItem(DeskTopItem, CTest.PIDL)
    '    If FCT Is Nothing Then
    '        Debug.WriteLine("C:\Testing Not Found")
    '        Exit Sub
    '    End If
    '    If CTest Is FCT Then
    '        Debug.WriteLine("Found correctly")
    '    End If
    '    Dim IsAncestor As Boolean = CShItem.IsAncestorOf(CTest.PIDL, FCT.PIDL)
    '    Debug.WriteLine("IsAncestorOf, default fparent returns " & IsAncestor.ToString)
    '    IsAncestor = CShItem.IsAncestorOf(CTest.PIDL, FCT.PIDL, True)
    '    Debug.WriteLine("IsAncestorOf, TRUE fparent returns " & IsAncestor.ToString)

    '    ' Now try for one not in tree
    '    Dim base As IntPtr = CTest.PIDL
    '    Dim Files As ArrayList = CTest.GetContentPtrs(SHCONTF.NONFOLDERS)
    '    If Files Is Nothing OrElse Files.Count < 1 Then Exit Sub
    '    For Each IP As IntPtr In Files
    '        Dim abs As IntPtr = concatPidls(base, IP)
    '        Dim tst As CShItem = FindCShItem(abs)
    '        If tst IsNot Nothing Then
    '            Debug.WriteLine("Found Item: " & tst.DisplayName)
    '        End If
    '        Marshal.FreeCoTaskMem(IP)
    '        Marshal.FreeCoTaskMem(abs)
    '    Next
    '    Dim AAA As CShItem = GetCShItem("C:\testing\AAA.txt")
    '    Dim FAAA As CShItem = FindCShItem(AAA.PIDL)
    'End Sub

    Private Sub TimeTestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimeTestToolStripMenuItem.Click
        If lv1.SelectedItems.Count < 1 Then
            MsgBox("Must Select an Item in the ListView to test with", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "Nothing Selected")
            Exit Sub
        End If
        Dim Result As String
        Dim P1 As IntPtr = DirectCast(lv1.SelectedItems(0).Tag, CShItem).PIDL
        Dim P2 As IntPtr = DirectCast(lv1.SelectedItems(0).Tag, CShItem).PIDL
        Dim StTime As DateTime = Now()
        ' Testing the same PIDL is instantaneous since ILIsEqual first tests the IntPtrs for equality
        'For i As Integer = 1 To 200000
        '    If Not CShItem.IsEqual(P1, P2) Then
        '        MsgBox("Wrong answer", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "IsEqual failed")
        '        Exit Sub
        '    End If
        'Next
        'Result = ("Test1 Elapsed time: " & Now().Subtract(StTime).TotalMilliseconds.ToString & "ms")
        'Debug.WriteLine(Result)
        'MsgBox(Result, MsgBoxStyle.OkOnly, "Result of Test1")

        If lv1.SelectedItems.Count > 1 Then
            P2 = DirectCast(lv1.SelectedItems(1).Tag, CShItem).PIDL
            StTime = Now()
            For i As Integer = 1 To 200000
                If CShItem.IsEqual(P1, P2) Then
                    MsgBox("Wrong answer - Test2", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "IsEqual failed")
                    Exit Sub
                End If
            Next
            Result = "Test2 Elapsed time:  - Using CShItem.IsEqual vs Full PIDL: " & Now().Subtract(StTime).TotalMilliseconds.ToString & "ms"
            Debug.WriteLine(Result)
            MsgBox(Result, MsgBoxStyle.OkOnly, "Result of Test2")

            Dim Rel1 As IntPtr = CShItem.ILFindLastID(DirectCast(lv1.SelectedItems(0).Tag, CShItem).PIDL)
            Dim Rel2 As IntPtr = CShItem.ILFindLastID(DirectCast(lv1.SelectedItems(1).Tag, CShItem).PIDL)
            Dim CSI1 As CShItem = DirectCast(lv1.SelectedItems(0).Tag, CShItem)
            StTime = Now()
            For i As Integer = 1 To 200000
                If CSI1.PidlsEqual(Rel1, Rel2) Then
                    MsgBox("Wrong answer - Test3", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "IsEqual failed")
                    Exit Sub
                End If
            Next
            Result = "Test3 Elapsed time - Same as Test2 with Last Item: " & Now().Subtract(StTime).TotalMilliseconds.ToString & "ms"
            Debug.WriteLine(Result)
            MsgBox(Result, MsgBoxStyle.OkOnly, "Result of Test3")

            Rel1 = DirectCast(lv1.SelectedItems(0).Tag, CShItem).PIDL
            Rel2 = DirectCast(lv1.SelectedItems(1).Tag, CShItem).PIDL
            StTime = Now()
            For i As Integer = 1 To 200000
                If CShItem.GetDeskTop.PidlsEqual(Rel1, Rel2) Then
                    MsgBox("Wrong answer - Test4", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "IsEqual failed")
                    Exit Sub
                End If
            Next
            Result = "Test4 Elapsed time - Same as Test2 vs Full PIDL" & Now().Subtract(StTime).TotalMilliseconds.ToString & "ms"
            Debug.WriteLine(Result)
            MsgBox(Result, MsgBoxStyle.OkOnly, "Result of Test4")
            ' Try the same test with AreBytesEqual
            StTime = Now()
            For i As Integer = 1 To 200000
                If CShItem.AreBytesEqual(Rel1, Rel2) Then
                    MsgBox("Wrong answer - Test5", MsgBoxStyle.Exclamation Or MsgBoxStyle.OkOnly, "IsEqual failed")
                    Exit Sub
                End If
            Next
            Result = "Test5 Elapsed time - Using AreBytesEqual - Full PIDL " & Now().Subtract(StTime).TotalMilliseconds.ToString & "ms"
            Debug.WriteLine(Result)
            MsgBox(Result, MsgBoxStyle.OkOnly, "Result of Test5")
        End If
    End Sub

    Private Sub TestCreDirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestCreDirToolStripMenuItem1.Click

        If LastSelectedCSI IsNot Nothing Then
            ExpTree1.ExpandANode(LastSelectedCSI)
            Dim Base As String = LastSelectedCSI.Path
            Directory.CreateDirectory(Base & "\" & "AAAziz")
            Dim SubDirBase As String = Base & "\" & "AAAziz\Sub"
            'ExpTree1.ExpandANode(Base & "\" & "AAAziz") 'This will fail since MKDIR has not yet been processed (or, perhaps, occurred)
            For i As Integer = 1 To 26
                Directory.CreateDirectory(SubDirBase & i.ToString)
            Next
        End If
    End Sub

    Private Sub TestFilterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestFilterToolStripMenuItem.Click
        If LastSelectedCSI IsNot Nothing Then
            Dim Lst As New List(Of String)
            Dim FLst As New ArrayList()
            FLst.AddRange(LastSelectedCSI.GetFiles("*.txt"))
            If FLst.Count > 0 Then
                For Each CSI As CShItem In FLst
                    Lst.Add(CSI.Name)
                Next
            Else : Lst.Add("No Files matched the Filter")
            End If
            Dim DispForm As New frmDisplay
            With DispForm
                .txtDisplay.Lines = Lst.ToArray
                .Show()
            End With
        End If
    End Sub

    Private Sub SearchBoxToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBoxToolStripMenuItem.Click
        Dim SBForm As New frmSearchBox
        SBForm.ShowDialog()
        SBForm.Dispose()
    End Sub

    Private Sub MultiInstanceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultiInstanceToolStripMenuItem.Click
        Dim MForm As New frmTestMulti
        MForm.Show()
    End Sub
#End Region

End Class