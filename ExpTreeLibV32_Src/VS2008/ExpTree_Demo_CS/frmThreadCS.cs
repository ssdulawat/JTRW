using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using ExpTreeLib;
//using ExpTreeLib.ShellDll;
using ExpTreeLib;
using ExpTreeLib.ShellDll;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ExpTree_Demo_CS
{
	/// <summary>
	/// This Form is an <b>optimized</b> fully working start point for any form which requires an ExplorerTree and
	/// ListView. It illustrates the use of a BackgroundWorker to insert slow to gather information into ListViewItems.
	/// It leaves enough room for application specific controls. 
	/// </summary>
	/// <remarks>
	/// <para>This Form illustrates the use of:
	/// <list type="bullet">
	/// <item><description>Use of a BackgroundWorker to improve GUI responsiveness.</description></item>
	/// <item><description>Use of the ExpTreeNodeSelected Event Handler.</description></item>
	/// <item><description>Use of LVColSorter for column sorting. See MakeLviItem for a custom ListViewItem 
	/// builder which is compatible with and useful for LVColSorter. 
	/// See Also SortLVItems for how to perform a Refresh of the 
	/// ListView in response to a Refresh command from the Context Menu.</description></item>
	/// <item><description>Full Context Menus in the ListView.</description></item>
	/// <item><description>ListViewItem editing (first SubItem only) if the ListViewItem.Tag is a CShItem.</description></item>
	/// <item><description>Handling of dynamic update Events from CShItemUpdate Events.</description></item>
	/// <item><description>Proper handling of the Delete Key.</description></item>
	/// <item><description>Shows how to handle a DoubleClick on a ListViewItem.</description></item>
	/// </list>
	/// </para>
	/// </remarks>
	/// 



	public partial class frmThreadCS : Form
    {
        /// <summary>
        /// Creates an instance of frmThreadCS
        /// </summary>
        public frmThreadCS()
        {
            InitializeComponent();

            // Set up Handlers - I love C#
            base.VisibleChanged += frmThread_VisibleChanged;
		    base.Load += frmThread_Load;
            ExpTree1.ExpTreeNodeSelected += AfterNodeSelect;
            lv1.HandleCreated += lv1_HandleCreated;
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            LargeIconsToolStripMenuItem.Click += LargeIconsToolStripMenuItem_Click;
            SmallIconsToolStripMenuItem.Click += SmallIconsToolStripMenuItem_Click;
            ListToolStripMenuItem.Click += ListToolStripMenuItem_Click;
            DetailsToolStripMenuItem.Click += DetailsToolStripMenuItem_Click;
            TileToolStripMenuItem.Click += TileToolStripMenuItem_Click;
            lv1.DoubleClick += lv1_DoubleClick;
            lv1.BeforeLabelEdit += lv1_BeforeLabelEdit;
            lv1.AfterLabelEdit += lv1_AfterLabelEdit;
            lv1.MouseLeave += lv1_MouseLeave;
            lv1.MouseDown += lv1_MouseDown;
            lv1.MouseUp += lv1_MouseUp;
            lv1.KeyUp += lv1_KeyUp;

        }
		//avoid Globalization problem-- an empty timevalue
	public string GetJobPath;
	ArrayList BackItemStack = new ArrayList();
	int ItemCount;
	//CShItem LastSelectedCSI;
	//Private LastSelectedCSI As CShItem
	//Dim BackItemStack As New ArrayList

		DateTime EmptyTimeValue = new DateTime(1, 1, 1, 0, 0, 0);

	private CShItem LastSelectedCSI;

    private CDragWrapper DW;    //wrapper for Drag ops originating in lv1

    private ClvDropWrapper DropWrap;    //wrapper for Drop ops targeting lv1

    private bool m_CreateNew = false;   //Flag for NewMenu processing of "New" item

    private CShItem DeskTopItem = CShItem.GetDeskTop();   // Not used in C# version, but ensures CShItem is initialized

    /// <summary>
    /// To receive notification of changes to the FileSystem which may affect the GUI display,
    /// assign a Handler as is done in frmThread_Load.
    /// Changes to CShItem's internal tree which are caused by notification of 
    /// FileSystem changes or by a refresh of the contents of the internal tree raise CShItemUpdate
    /// events.  For possible future changes, we check to see if an Invoke is required or not.
    /// </summary>
    /// <remarks></remarks>
    private delegate void InvokeUpdate(object sender, ShellItemUpdateEventArgs e);

    private InvokeUpdate m_InvokeUpdate;

	#region "   Public Properties"
    private int _InitialLoadLimit = 32;
	/// <summary>
	/// InitialLoadLimit is a the number of lv1.Items whose IconIndex will we fetched on initial load
	/// the balance will be fetched AFTER lv1 shows its initial display
	/// </summary>
	/// <value></value>
	/// <returns></returns>
	/// <remarks></remarks>
	[Browsable(true), Category("Misc"), Description("Maximum # of Items to build in GUI Thread for initial display"), DefaultValue(32)]
	public int InitialLoadLimit {
		get { return _InitialLoadLimit; }
		set { _InitialLoadLimit = value; }
	}

    private int _WorkUpdateInterval = 100;
	/// <summary>
	/// WorkUpdateInterval is the Maximum # of Items to build in each 
	/// BackGroundWorker Progress Interval before reporting them back to the GUI.
	/// </summary>
	/// <value></value>
	/// <returns></returns>
	/// <remarks>If there are 200 items to show, the first InitialLoadLimit will be built and
	///          displayed in the GUI thread. The balance will be built in the BackgroundWorker
	///          thread and reported back to the GUI in chunks of WorkUpdateInterval Items.</remarks>
	[Browsable(true), Category("Misc"), Description("Maximum # of Items in each Background update interval"), DefaultValue(100)]
	public int WorkUpdateInterval {
		get { return _WorkUpdateInterval; }
		set { _WorkUpdateInterval = value; }
	}
	#endregion

	#region "   Form Close Methods"
	private void ExitToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
	{
		this.Close();
	}
    private void frmThreadCS_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e) //7/1/2012
    {
        CShItem.CShItemUpdate -= UpdateInvoke; //7/1/2012
    } //7/1/2012
	#endregion

	#region "   Form Load/VisibleChanged lv1 HandleCreated"

	private void frmThread_Load(System.Object sender, System.EventArgs e)
	{
		//Setup Drag and Drop Wrappers
		DW = new CDragWrapper(lv1);
		DropWrap = new ClvDropWrapper(lv1);

        //Wire up Notification Change Event Handler and Form Closing to remove it when done
        m_InvokeUpdate = new InvokeUpdate(this.DoItemUpdate);
        CShItem.CShItemUpdate += UpdateInvoke;
        this.FormClosing += frmThreadCS_FormClosing;        //7/1/2012

			if(GetJobPath!="")
            {
				if (GetJobPath == "N:\\transfer\\PDF invoice")
				{
					//CShItem chitem = new CShItem(GetJobPath);

					if(Directory.Exists(GetJobPath))
					{ 
						CShItem chitem;
						//chitem = new CShItem(GetJobPath);
						ExpTree1.RootItem = CShItem.GetCShItem("N:\\transfer\\");						
							//AfterNodeSelect("N:\\transfer\\", chitem);
							//sbr1.Text = GetJobPath;
					}
					else
                    {
						ExpTree1.RootItem = CShItem.GetCShItem(ShellAPI.CSIDL.DESKTOP);
						//button4.Enabled = false;

					}
				}
				else
				{
					//CShItem chitem = new CShItem(GetJobPath);

					//ExpTree1.RootItem = CShItem.GetCShItem(AppConstants.JobDiretory);
					ExpTree1.RootItem = CShItem.GetCShItem(ShellAPI.CSIDL.DESKTOP);
					//AfterNodeSelect(AppConstants.JobDiretory, chitem);
					//sbr1.Text = GetJobPath;
				}


			}
			MenuStrip1.Visible = false;			


    }

	private void lv1_HandleCreated(object sender, System.EventArgs e)
	{
		SystemImageListManager.SetListViewImageList(lv1, false, false);
		SystemImageListManager.SetListViewImageList(lv1, true, false);
	}

	private void frmThread_VisibleChanged(object sender, System.EventArgs e)
	{
		SystemImageListManager.SetListViewImageList(lv1, false, false);
		SystemImageListManager.SetListViewImageList(lv1, true, false);
	}
	#endregion

	#region "   ExplorerTree Event Handling -- AfterNodeSelect"

	private void AfterNodeSelect(string pathName, CShItem CSI)
	{

			try
			{ 
            if (LastSelectedCSI != null && object.ReferenceEquals(LastSelectedCSI, CSI))
                return;
            Cursor = Cursors.WaitCursor;
		tsslMiddle.Text = pathName;
		this.Text = pathName;
		tsslLeft.Text = "Building Display";

		if (BGW2 != null) {
			BGW2.CancelAsync();
			Event2.WaitOne();
		}
		int TotalItems = 0;

			//ArrayList combList = CSI.GetItems();
			ArrayList combList = new ArrayList();
			combList = CSI.GetItems();

			TotalItems = combList.Count;
		if (TotalItems > 0) {
			//Build the ListViewItems & add to lv1
			lv1.BeginUpdate();
			lv1.Items.Clear();
			if (LastSelectedCSI != null && !object.ReferenceEquals(LastSelectedCSI, CSI)) {
				LastSelectedCSI.ClearItems(true,false);
			}
			lv1.Refresh();

			int InitialFillLim = Math.Min(combList.Count, InitialLoadLimit);
			List<ListViewItem> FirstLoad = new List<ListViewItem>(InitialFillLim);
			for (int i = 0; i <= InitialFillLim - 1; i++) {
				ListViewItem lvi = MakeLVItem((CShItem)combList[i]);
				RefreshLvi(lvi);
				lvi.ImageIndex = SystemImageListManager.GetIconIndex((CShItem)combList[i], false, false);
				FirstLoad.Add(lvi);
			}
			lv1.Items.AddRange(FirstLoad.ToArray());

			//Fill the ListView with the remaining items without FileInfo or ICon
			List<ListViewItem> SparseLoad = new List<ListViewItem>(combList.Count - InitialFillLim);
			if (combList.Count > InitialFillLim) {
				for (int i = InitialFillLim; i <= combList.Count - 1; i++) {
                    ListViewItem lvi = MakeLVItem((CShItem)combList[i]);
					RefreshLvi(lvi, true);
					SparseLoad.Add(lvi);
				}
				lv1.Items.AddRange(SparseLoad.ToArray());
			}
			lv1.EndUpdate();

			if (combList.Count > InitialLoadLimit) {
				LoadLV1(SparseLoad);
			}
		} else {
			lv1.Items.Clear();
			if (LastSelectedCSI != null && !object.ReferenceEquals(LastSelectedCSI, CSI)) {
				LastSelectedCSI.ClearItems(true,false);
			}
			tsslRight.Text = " Has No Items";
		}
		LastSelectedCSI = CSI;
			
		lv1.Tag = LastSelectedCSI;          //7/5/2012   For ClvDropWapper
//Now that lv.ListViewItems has been set up (and MakeLvItem does attach the appropriate tags
		// to both the ListViewItem and the appropriate SubItems), set the ListViewItemSorter
		lv1.ListViewItemSorter = new LVColSorter(lv1);
        
		tsslLeft.Text = "Ready";
        ShowCounts();
		Cursor = Cursors.Default;

		BackItemStack.Add(LastSelectedCSI);
		ItemCount = BackItemStack.Count;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message.ToString());
			}

		}

	private void ShowCounts()
	{
		if (lv1.Items.Count > 0)
		{
			int Dirs = 0;
			int Files = 0;
			foreach (ListViewItem lvi in lv1.Items)
			{
				CShItem Item = (CShItem)(lvi.Tag);
				if (Item.IsFolder)
				{
					Dirs += 1;
				}
				else
				{
					 Files += 1;
				}
			}
			tsslRight.Text = Dirs + " Directories " + Files + " Files";
		}
		else
		{
			tsslRight.Text = " Has No Items";
		}
	}	
    #endregion

	#region "       Various MakeLV routines"

	/// <summary>
	/// Creates a minimal ListViewItem from the input CShItem
	/// </summary>
	/// <param name="item">The CShItem that this ListViewItem represents</param>
	/// <returns>A ListViewItem with .Tag and .Text filled, with empty SubItems for the balance of the View.</returns>
	/// <remarks>When it is timely to fill the remaining SubItems with data, call RefreshLvi.</remarks>
	private ListViewItem MakeLVItem(CShItem item)
	{
		ListViewItem lvi = new ListViewItem(item.DisplayName);
		lvi.Tag = item;
		for (int i = 1; i <= lv1.Columns.Count - 1; i++) {
			lvi.SubItems.Add("");
		}
		return lvi;
	}
    /// <summary>
    /// Alternate signature of RefreshLvi. Calls the main RefreshLVI with the parameter DeferSet set to False.
    /// </summary>
    /// <param name="lvi">The ListViewItem to be refreshed</param>
    private void RefreshLvi(ListViewItem lvi)
    {
        RefreshLvi(lvi, false);
    }
    /// <summary>
    /// Loads all of a ListViewItem's SubItems with values from either the associated CShItem. or - obtained from the ListViewItem's .Tag.
    /// Note that the CShItem's time sensitive values will be set by CShItem using a W32_FindData structure if it finds one in the
    /// CShItem's .W32Data - as set in this Form by a BackgroundWorker.
    /// </summary>
    /// <param name="lvi">The ListViewItem to be refreshed</param>
    /// <param name="DeferSet">If True, Defer the filling of Length and Date information until later (in the BackgroundWorker).
    ///                        If False (the default) fill Length and Date information in this call.</param>
    /// <remarks></remarks>
    /// 
    private void RefreshLvi(ListViewItem lvi, bool DeferSet)
	{
		CShItem CSI = (CShItem)lvi.Tag;
		//Set the Items that must come from a CShItem
		lvi.Text = CSI.Name;
		lvi.SubItems[3].Text = CSI.TypeName;
        //Set the Items that take some time to obtain
        if (!DeferSet) {   
			//Set Length
            if (!CSI.IsDisk & CSI.IsFileSystem & !CSI.IsFolder)
            {   //Set the SubItems that may come from an W32Find_Data
				if (CSI.Length > 1024) {
					lvi.SubItems[1].Text = (Strings.Format(CSI.Length / 1024, "#,### KB"));
				} else {
					lvi.SubItems[1].Text = (Strings.Format(CSI.Length, "##0 Bytes"));
				}
				lvi.SubItems[1].Tag = CSI.Length;
			} else {
				//.SubItems(1) already has been correctly set to blank entry
                // But the .Tag must be set to 0 to make LVColSorter work correctly
                lvi.SubItems[1].Tag = 0L;
			}
			//Set LastWriteTime
			//"#1/1/0001 12:00:00 AM#" is empty
			if (CSI.IsDisk || CSI.LastWriteTime == EmptyTimeValue) {
			//.SubItems(2) already has been correctly set to blank entry
			} else {
				lvi.SubItems[2].Text = CSI.LastWriteTime.ToString("MM/dd/yyyy HH:mm:ss");
				lvi.SubItems[2].Tag = CSI.LastWriteTime;
			}
			//Set Attributes
			if (!CSI.IsDisk & CSI.IsFileSystem) {
				StringBuilder SB = new StringBuilder();
				try {
					FileAttributes attr = CSI.Attributes;
					if ((attr & FileAttributes.System) == FileAttributes.System)
						SB.Append("S");
					if ((attr & FileAttributes.Hidden) == FileAttributes.Hidden)
						SB.Append("H");
					if ((attr & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
						SB.Append("R");
					if ((attr & FileAttributes.Archive) == FileAttributes.Archive)
						SB.Append("A");
				} catch {
				}
				lvi.SubItems[4].Text = SB.ToString();
			} else {
				//.SubItems(4) already has been correctly set to blank entry
			}
			//Set CreationTime
			//"#1/1/0001 12:00:00 AM#" is empty
			if (CSI.IsDisk || CSI.CreationTime == EmptyTimeValue) {
			//.SubItems(5) already has been correctly set to blank entry
			} else {
				lvi.SubItems[5].Text = CSI.CreationTime.ToString("MM/dd/yyyy HH:mm:ss");
				lvi.SubItems[5].Tag = CSI.CreationTime;
			}
		}
	}

	#endregion

	#region "   Background worker"
	private BackgroundWorker withEventsField_BGW2;
	private BackgroundWorker BGW2 {
		get { return withEventsField_BGW2; }
		set {
			if (withEventsField_BGW2 != null) {
				withEventsField_BGW2.DoWork -= BGW2_DoWork;
				withEventsField_BGW2.ProgressChanged -= BGW2_ProgressChanged;
				withEventsField_BGW2.RunWorkerCompleted -= BGW2_RunWorkerCompleted;
			}
			withEventsField_BGW2 = value;
			if (withEventsField_BGW2 != null) {
				withEventsField_BGW2.DoWork += BGW2_DoWork;
				withEventsField_BGW2.ProgressChanged += BGW2_ProgressChanged;
				withEventsField_BGW2.RunWorkerCompleted += BGW2_RunWorkerCompleted;
			}
		}
	}
	private ManualResetEvent Event2 = new ManualResetEvent(true);
	private int InBkground = 0;

    private Dictionary<string, ExpTreeLib.ShellDll.ShellAPI.W32Find_Data> ItemInfo;
	private void LoadLV1(List<ListViewItem> ListToDo)
	{
		BGW2 = new BackgroundWorker();
		Event2.Reset();
		tsslLeft.Text = "Loading Info";
        BGW2.WorkerReportsProgress = true;
        BGW2.WorkerSupportsCancellation = true;
		InBkground = 0;
        BGW2.RunWorkerAsync(ListToDo);
	}

	//7/8/2012 - Routine modified to correct a potential deadlock
	private void BGW2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
	{
		BackgroundWorker ThisWorker = (BackgroundWorker)sender;
        List<ListViewItem> WorkList = (List<ListViewItem>)e.Argument;
		List<ListViewItem> Results = new List<ListViewItem>(WorkUpdateInterval);
		CShItem Item = ((CShItem)(WorkList[0].Tag)).Parent;
		if (Item.IsFileSystem && WorkList.Count > 0)
		{
			GetItemDatas(Item, WorkList);
		}
		for (int i = 0; i < WorkList.Count; i++)
		{
			if (ThisWorker.CancellationPending)
			{
				e.Cancel = true;
				Results = null;
				break;
			}
			Item = (CShItem)WorkList[i].Tag;
			//Force fetch of IconIndex 
			int tmp = Item.IconIndexNormal;
			Results.Add(WorkList[i]);
			if (Results.Count == WorkUpdateInterval)
			{
				if (ThisWorker.CancellationPending)
				{
					e.Cancel = true;
					Results = null;
					break;
				}
				ThisWorker.ReportProgress(i, Results);
				Results = new List<ListViewItem>(WorkUpdateInterval);
			}
		}
		Event2.Set();
		e.Result = Results;
	}
	private void BGW2_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
	{
		List<ListViewItem> Items = (List<ListViewItem>)e.UserState;
		foreach (ListViewItem Lvi in Items) {
			SetLvi(Lvi);
			InBkground += 1;
		}
	}

	private void BGW2_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
	{
		if (!e.Cancelled && e.Error == null) {
			if (e.Result != null) {
                List<ListViewItem> Items = (List<ListViewItem>)e.Result;
				foreach (ListViewItem Lvi in Items) {
					SetLvi(Lvi);
					InBkground += 1;
				}
			}
		}
		Debug.WriteLine(InBkground + " Items set in BGW2");
		Event2.Set();
		BGW2 = null;
	}

	private void GetItemDatas(CShItem BaseCSI, List<ListViewItem> LVIList)
	{
		ItemInfo = new Dictionary<string, ExpTreeLib.ShellDll.ShellAPI.W32Find_Data>(LVIList.Count);
		GetInfos(BaseCSI);
		foreach (ListViewItem Lvi in LVIList) {
			CShItem CSI = (CShItem)Lvi.Tag;
			string csiName = System.IO.Path.GetFileName(CSI.Path);
			if (CSI.IsFolder) {
				csiName = csiName + "\\";
			}
			if (ItemInfo.ContainsKey(csiName)) {
				CSI.W32Data = ItemInfo[csiName];
			#if DEBUG
			} else {
				throw new ArgumentException("No ItemData for " + CSI.Path);
			#endif
			}
		}
	}


	private void GetInfos(CShItem CSI)
	{
		string DirName = CSI.Path;
		ExpTreeLib.ShellDll.ShellAPI.W32Find_Data Data = new ShellAPI.W32Find_Data(DirName);

		ShellAPI.SafeFindHandle Handle = null;

		Handle = ShellAPI.FindFirstFile(DirName + "\\*", Data);
		if (Handle.IsInvalid) {
			throw new ApplicationException("Invalid FindFileHandle returned for " + DirName);
		}
		bool HR = true;
		while ((HR)) {
			if (((FileAttributes)Data.dwFileAttributes & FileAttributes.Directory) != 0) {
				if (!Data.cFileName.StartsWith(".")) {
					ItemInfo.Add(Data.Name + "\\", Data);
				}
			} else {
				ItemInfo.Add(Data.Name, Data);
			}
			Data = new ShellAPI.W32Find_Data(DirName);
            HR = ShellAPI.FindNextFile(Handle, Data);
		}
		Handle.Close();
	}

	private void SetLvi(ListViewItem Lvi)
	{
		CShItem CSI = (CShItem)Lvi.Tag;
		Lvi.ImageIndex = CSI.IconIndexNormal;
		RefreshLvi(Lvi);
	}

	#endregion

	#region "   View Menu Event Handling"
    private void LargeIconsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
	{
		lv1.View = View.LargeIcon;
	}

    private void SmallIconsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
	{
		lv1.View = View.SmallIcon;
	}

    private void ListToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
	{
		lv1.View = View.List;
	}

    private void DetailsToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
	{
		lv1.View = View.Details;
	}

    private void TileToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
	{
		lv1.TileSize = new  System.Drawing.Size(Convert.ToInt32(lv1.ClientSize.Width * 0.333), Convert.ToInt32(lv1.ClientSize.Height / 4));
		lv1.View = View.Tile;
	}
	#endregion

	#region "      Dynamic Update Handler"

	/// <summary>
	/// Returns the last CShItem Selected.
    /// Not currently used within ExpTreeLib or Exp_Demo
	/// </summary>
	public CShItem SelectedItem {
		get { return LastSelectedCSI; }
	}
	/// <summary>
	/// Determines if DoItemUpdate should be called directly or via Invoke, and then calls it.
	/// </summary>
	/// <param name="sender">The CShItem of the Folder of the changed item.</param>
	/// <param name="e">Contains information about the type of change and items affected.</param>
	/// <remarks>Responds to events raised by either WM_Notify messages or FileWatch.</remarks>
	private void UpdateInvoke(object sender, ShellItemUpdateEventArgs e)
	{
		if (this.InvokeRequired) {
			Invoke(m_InvokeUpdate, sender, e);
		} else {
			DoItemUpdate(sender, e);
		}
	}
	/// <summary>
	/// Makes changes in lv1 GUI in response to updating events raised by CShItem.
	/// </summary>
	/// <param name="sender">The CShItem of the Folder of the changed item.</param>
	/// <param name="e">Contains information about the type of change and items affected.</param>
	/// <remarks>Responds to events raised by WM_Notify messages. </remarks>
	private void DoItemUpdate(object sender, ShellItemUpdateEventArgs e)
	{
        //Debug.WriteLine("Enter frmThread DoItemUpdate -- " + ((CShItem)e.Item).DisplayName + " - " + e.UpdateType.ToString());
        CShItem Parent = (CShItem)sender;
        if (Parent == LastSelectedCSI) //6/11/2012 If not, then of no interest to us
        {
            try
            {
                lv1.BeginUpdate();
                if (e.UpdateType == CShItem.CShItemUpdateType.Created)
                {
                    ListViewItem lvi = MakeLVItem(e.Item);
                    lvi.ImageIndex = e.Item.IconIndexNormal;
                    RefreshLvi(lvi);
                    InsertLvi(lvi, lv1);        //6/11/2012
                    if (m_CreateNew)
                    {
                        m_CreateNew = false;
                        lvi.BeginEdit();
                    }
                }
                else if (e.UpdateType == CShItem.CShItemUpdateType.Deleted)
                {
                    ListViewItem lvi = FindLVItem(e.Item);
                    if (lvi != null)
                    {
                        lv1.Items.Remove(lvi);
                    }
                }
                else if (e.UpdateType == CShItem.CShItemUpdateType.Renamed)
                {
                    ListViewItem lvi = FindLVItem(e.Item);
                    if (lvi != null)
                    {
                        if (e.Item.Parent != LastSelectedCSI) //if true = item renamed to different directory
                        {
                            lv1.Items.Remove(lvi);
                        }
                        else
                        {
                            RefreshLvi(lvi);
                            e.Item.ResetIconIndex(); //may have changed
                            lvi.ImageIndex = e.Item.IconIndexNormal;
                            lv1.Items.Remove(lvi);
                            InsertLvi(lvi, lv1);        //6/11/2012
                        }
                    }
                }
                else if (e.UpdateType == CShItem.CShItemUpdateType.UpdateDir) //in this case Parent/sender is the item of interest
                {
                    // CShItemUpdater, etc. will do the appropriate Adds and Removes, generating
                    // Created/Deleted events that will occur before an UpdateDir event. There is
                    // no need to do anything here.
                }
                else if (e.UpdateType == CShItem.CShItemUpdateType.Updated)
                {
                        ListViewItem lvi = FindLVItem(e.Item);
                        if (lvi != null)
                        {
                            int indx = lv1.Items.IndexOf(lvi);
                            ListViewItem newLVI = MakeLVItem(e.Item);
                            RefreshLvi(newLVI);
                            e.Item.ResetIconIndex(); //may have changed
                            newLVI.ImageIndex = e.Item.IconIndexNormal;
                            lv1.Items.RemoveAt(indx);
                            lv1.Items.Insert(indx, newLVI);
                        }
                }
                else if (e.UpdateType == CShItem.CShItemUpdateType.IconChange)
                {
                    ListViewItem lvi = FindLVItem(e.Item);
                    if (lvi != null)
                    {
                        e.Item.ResetIconIndex();
                        lvi.ImageIndex = e.Item.IconIndexNormal;
                    }
                }
                else if (e.UpdateType == CShItem.CShItemUpdateType.MediaChange)
                {
                    ListViewItem lvi = FindLVItem(e.Item);
                    if (lvi != null)
                    {
                        RefreshLvi(lvi);
                        e.Item.ResetIconIndex();
                        lvi.ImageIndex = e.Item.IconIndexNormal;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error in frmThread -- lv1 updater -- " + ex.ToString());
            }
            finally
            {
                lv1.EndUpdate();
            }
            ShowCounts();
        } //end of Parent Is LastSelectedCSI test
	}

	private ListViewItem FindLVItem(CShItem item)
	{
		foreach (ListViewItem lvi in lv1.Items) {
			if (object.ReferenceEquals(lvi.Tag, item)) {
				return lvi;
			}
		}
		return null;
	}

    /// <summary>
    /// Given a ListViewItem with a  CShItem in its' Tag, and a ListView whose Items all have a CShItem in
    /// their Tags, Insert the ListViewItem in its' proper place in the ListView.
    /// </summary>
    /// <param name="lvi">The ListViewItem to be inserted.</param>
    /// <param name="LV">The ListView into which the ListViewItem is to be inserted.</param>
    /// <remarks>6/11/2012 - better than a Sort when the list is in order.<br />
    ///          Will not honor any prior Column Sorts.</remarks>
    private void InsertLvi(ListViewItem lvi, ListView LV)
    {
        CShItem Item = (CShItem)lvi.Tag;
        for (int i = 0; i < LV.Items.Count; i++)
        {
            if (((CShItem)(LV.Items[i].Tag)).CompareTo(Item) > 0)
            {
                LV.Items.Insert(i, lvi);
                lvi.EnsureVisible();
                return;
            }
        }
        LV.Items.Add(lvi);
        lvi.EnsureVisible();
    }
	#endregion

	#region "       lv1_DoubleClick"

	private void lv1_DoubleClick(object sender, System.EventArgs e)
	{
		CShItem csi = (CShItem)lv1.SelectedItems[0].Tag;
		if (csi.IsFolder) {
			ExpTree1.ExpandANode(csi,true);   //7/13/2012
				
				BackItemStack.Add(csi.Path);
				ItemCount = BackItemStack.Count;
				button4.Enabled = true;

		} else {
			try {
				Process.Start(csi.Path);
			} catch (Exception ex) {
				Interaction.MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Error in starting application");
			}
		}
	}
	#endregion

	#region "       LabelEdit Handlers (Item Rename) From Calum"
	/// <summary>
	/// Handles Before Item Rename for lv1
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	/// <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
	private void lv1_BeforeLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
	{
		CShItem item = (CShItem)lv1.Items[e.Item].Tag;
		if ((!item.IsFileSystem) | item.IsDisk | item.Path == CShItem.GetCShItem(ShellAPI.CSIDL.MYDOCUMENTS).Path | !(item.CanRename)) {
			System.Media.SystemSounds.Beep.Play();
			e.CancelEdit = true;
		}
	}

	/// <summary>
	/// Handles After Item Rename for lv1
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	/// <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
	private void lv1_AfterLabelEdit(object sender, System.Windows.Forms.LabelEditEventArgs e)
	{
		CShItem item = (CShItem)lv1.Items[e.Item].Tag;
		string NewName = null;
		int index = 0;
		string path = null;
        if (e.Label == null || e.Label == string.Empty) //6/11/2012
        {
            return;
        }
		try {
			NewName = e.Label.Trim();

			if (NewName.Length < 1 || NewName.IndexOfAny(System.IO.Path.GetInvalidPathChars()) != -1) {
				e.CancelEdit = true;
				System.Media.SystemSounds.Beep.Play();
				return;
			}

			path = item.Path;

			index = path.LastIndexOf('\\');
			if (index == -1) {
				e.CancelEdit = true;
				System.Media.SystemSounds.Beep.Play();
				return;
			}

			IntPtr newPidl = IntPtr.Zero;
			if (item.Parent.Folder.SetNameOf((int)lv1.Handle, CShItem.ILFindLastID(item.PIDL), NewName, ShellAPI.SHGDN.NORMAL, ref newPidl) == ShellAPI.S_OK) {
			} else {
				System.Media.SystemSounds.Beep.Play();
				e.CancelEdit = true;
			}
		} catch  {
			e.CancelEdit = true;
			System.Media.SystemSounds.Beep.Play();
			return;
		}
	}
	#endregion

	#region "       Context Menu Handlers"

	private WindowsContextMenu m_WindowsContextMenu = new WindowsContextMenu();
	private bool IsWithin(Control Ctl, MouseEventArgs e)
	{
		bool functionReturnValue = false;
		functionReturnValue = false;
		//default to Not Within
		if (e.X < 0 || e.Y < 0)
			return functionReturnValue;
		System.Drawing.Rectangle CR = Ctl.ClientRectangle;
		if (e.X > CR.Width || e.Y > CR.Height)
			return functionReturnValue;
		functionReturnValue = true;
		return functionReturnValue;
	}
	/// <summary>
	/// Sort the ListViewItems based on the CShItems stored in the .Tag of each ListViewItem.
	/// </summary>
    /// <remarks>Cannot use LVColSorter for this since we do not know its' current state.
	/// </remarks>
    private void SortLVItems()
    {
        if (lv1.Items.Count < 2) //no point in sorting 0 or 1 items
        {
            return;
        }
        lv1.BeginUpdate();
        ListViewItem[] tmp = new ListViewItem[lv1.Items.Count];
        lv1.Items.CopyTo(tmp, 0);
        Array.Sort(tmp, new CShItem.TagComparer());
        lv1.Items.Clear();
        lv1.Items.AddRange(tmp);
        lv1.EndUpdate();
    }
	/// <summary>
	/// m_OutOfRange is set to True on lv1.MouseLeave (which happens under many circumstances) to prevent
	/// the non-ListViewItem specific menu from firing. See Remarks
	/// m_OutOfRange is set to False (allowing ContextMenus in lv1), only on lv1.MouseDown when the Right
	/// button is pressed. MouseDown only occurs when the Mouse is really over lv1.
	/// </summary>
	/// <remarks>
	///If you hold down the right mouse button, then leave lv1,
	/// then let go of the mouse button, the MouseUp event is fired upon
	/// re-entering the lv1 - meaning that the Windows ContextMenu will
	/// be shown if we don't use this flag (from Calum)
	///</remarks>

	private bool m_OutOfRange;
	private void lv1_MouseLeave(object sender, System.EventArgs e)
	{
		m_OutOfRange = true;
	}

	private void lv1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		if (e.Button == System.Windows.Forms.MouseButtons.Right) {
			m_OutOfRange = false;
		}
	}

	/// <summary>
	/// Handles RightButton Click
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	/// <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
	private void lv1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
	{
		if (e.Button == System.Windows.Forms.MouseButtons.Right) {
			if (!IsWithin(lv1, e))
				return;
			if (m_OutOfRange)
				return;
			ListViewItem lvi = default(ListViewItem);
			System.Drawing.Point pt = new System.Drawing.Point(e.X, e.Y);
			lvi = lv1.GetItemAt(e.X, e.Y);
			if ((lvi != null) && lv1.SelectedItems.Count > 0) {
				CShItem[] itms = new CShItem[lv1.SelectedItems.Count];
				for (int i = 0; i <= lv1.SelectedItems.Count - 1; i++) {
					itms[i] = (CShItem)lv1.SelectedItems[i].Tag;
				}
				ShellAPI.CMInvokeCommandInfoEx cmi;
				bool allowRename = true;
				//Don't allow rename of more than 1 item
				if (lv1.SelectedItems.Count > 1)
					allowRename = false;
				if (m_WindowsContextMenu.ShowMenu(this.Handle, itms, MousePosition, allowRename, out cmi)) {
					//Check for rename
					byte[] cmdBytes = new byte[257];
                    m_WindowsContextMenu.winMenu.GetCommandString(cmi.lpVerb.ToInt32(), (int)ShellAPI.GCS.VERBA, 0, cmdBytes, 256);

                    string cmdName = ShellHelper.szToString(cmdBytes,0,cmdBytes.Length).ToLower();
					if (cmdName.Equals("rename")) {
						lv1.LabelEdit = true;
						lvi.BeginEdit();
					} else {
						m_WindowsContextMenu.InvokeCommand(m_WindowsContextMenu.winMenu, (uint)cmi.lpVerb.ToInt32(), itms[0].Parent.Path, pt);
					}
					Marshal.ReleaseComObject(m_WindowsContextMenu.winMenu);
				}
			} else {
				GetFolderMenu(MousePosition);
			}
		}
	}

	#region "           Windows Folder ContextMenu "

	private void GetFolderMenu(System.Drawing.Point pt)
	{
		int HR = 0;
		int min = 1;
		//int max = 100000;
		ShellAPI.CMInvokeCommandInfoEx cmi = new ShellAPI.CMInvokeCommandInfoEx();
        IntPtr comContextMenu = ShellAPI.CreatePopupMenu();
        IntPtr viewSubMenu = ShellAPI.CreatePopupMenu();
		// Dim sortSubMenu As IntPtr = CreatePopupMenu()

		//Check item count - should always be 0 but check just in case
        int startIndex = ShellAPI.GetMenuItemCount(comContextMenu.ToInt32());
		//Fill the context menu
        ShellAPI.MENUITEMINFO itemInfo = new ShellAPI.MENUITEMINFO("View");
        itemInfo.fMask = (int)(ShellAPI.MIIM.SUBMENU | ShellAPI.MIIM.STRING);
		itemInfo.hSubMenu = viewSubMenu;
        ShellAPI.InsertMenuItem(comContextMenu, 0, true, ref itemInfo);
        int @checked = (int)ShellAPI.MFT.BYCOMMAND;
		if (lv1.View == View.Tile)
			@checked = (int)(ShellAPI.MFT.RADIOCHECK | ShellAPI.MFT.CHECKED);
        ShellAPI.AppendMenu(viewSubMenu, @checked, (int)ShellAPI.CMD.TILES, "Tiles");
		@checked = (int)ShellAPI.MFT.BYCOMMAND;
		if (lv1.View == View.LargeIcon)
			@checked = (int)(ShellAPI.MFT.RADIOCHECK | ShellAPI.MFT.CHECKED);
		ShellAPI.AppendMenu(viewSubMenu, @checked, (int)ShellAPI.CMD.LARGEICON, "Large Icons");
		@checked = (int)ShellAPI.MFT.BYCOMMAND;
		if (lv1.View == View.List)
			@checked = (int)(ShellAPI.MFT.RADIOCHECK | ShellAPI.MFT.CHECKED);
		ShellAPI.AppendMenu(viewSubMenu, @checked, (int)ShellAPI.CMD.LIST, "List");
		@checked = (int)ShellAPI.MFT.BYCOMMAND;
		if (lv1.View == View.Details)
			@checked = (int)(ShellAPI.MFT.RADIOCHECK | ShellAPI.MFT.CHECKED);
		ShellAPI.AppendMenu(viewSubMenu, @checked, (int)ShellAPI.CMD.DETAILS, "Details");
		@checked = (int)ShellAPI.MFT.BYCOMMAND;

		ShellAPI.AppendMenu(comContextMenu, (int)ShellAPI.MFT.SEPARATOR, 0, string.Empty);
        ShellAPI.AppendMenu(comContextMenu, (int)ShellAPI.MFT.BYCOMMAND, (int)ShellAPI.CMD.REFRESH, "Refresh");
        ShellAPI.AppendMenu(comContextMenu, (int)ShellAPI.MFT.SEPARATOR, 0, string.Empty);

        int enabled = (int)ShellAPI.MFT.GRAYED;
		DragDropEffects effects = default(DragDropEffects);
		if (LastSelectedCSI == null) {
            enabled = (int)ShellAPI.MFT.BYCOMMAND;
		} else {
			effects = ShellHelper.CanDropClipboard(LastSelectedCSI);
			// Enable paste for stand-alone ExpList
			if (((effects & DragDropEffects.Copy) == DragDropEffects.Copy) | ((effects & DragDropEffects.Move) == DragDropEffects.Move)) {
                enabled = (int)ShellAPI.MFT.BYCOMMAND;
			}
		}
		ShellAPI.AppendMenu(comContextMenu, enabled, (int)ShellAPI.CMD.PASTE, "Paste");

		if (LastSelectedCSI != null) {
			enabled = (int)ShellAPI.MFT.GRAYED;
			if (((effects & DragDropEffects.Link) == DragDropEffects.Link)) {
                enabled = (int)ShellAPI.MFT.BYCOMMAND;
			}

            ShellAPI.AppendMenu(comContextMenu, enabled, (int)ShellAPI.CMD.PASTELINK, "Pas		te Link");
            ShellAPI.AppendMenu(comContextMenu, (int)ShellAPI.MFT.SEPARATOR, 0, string.Empty);

			// Add the 'New' menu
			//If LastSelectedCSI.IsFolder And m_allowNewItems And _
			if (LastSelectedCSI.IsFolder & ((!LastSelectedCSI.Path.StartsWith("::")) | (object.ReferenceEquals(LastSelectedCSI, CShItem.GetDeskTop())))) {
				int xIndex = ShellAPI.GetMenuItemCount((int)comContextMenu);

				m_WindowsContextMenu.SetUpNewMenu(LastSelectedCSI, comContextMenu, xIndex);
					// 6) ' 7)
				ShellAPI.AppendMenu(comContextMenu, (int)ShellAPI.MFT.SEPARATOR, 0, string.Empty);					
				}
			ShellAPI.AppendMenu(comContextMenu, (int)ShellAPI.MFT.BYCOMMAND, (int)ShellAPI.CMD.PROPERTIES, "Properties");
		}

        int cmdID = ShellAPI.TrackPopupMenuEx(comContextMenu, (int)ShellAPI.TPM.RETURNCMD, pt.X, pt.Y, this.Handle, IntPtr.Zero);


		if (cmdID >= min) {
            cmi = new ShellAPI.CMInvokeCommandInfoEx();
			cmi.cbSize = Marshal.SizeOf(cmi);
            cmi.nShow = (int)ShellAPI.SW.SHOWNORMAL;
            cmi.fMask = (int)(ShellAPI.CMIC.UNICODE | ShellAPI.CMIC.PTINVOKE);
			cmi.ptInvoke = new System.Drawing.Point(pt.X, pt.Y);

			switch (cmdID) {
                case (int)ShellAPI.CMD.TILES:
					lv1.View = View.Tile;
					goto CLEANUP;
                case (int)ShellAPI.CMD.LARGEICON:
					lv1.View = View.LargeIcon;
					goto CLEANUP;
                case (int)ShellAPI.CMD.LIST:
					lv1.View = View.List;
					goto CLEANUP;
                case (int)ShellAPI.CMD.DETAILS:
					lv1.View = View.Details;
					goto CLEANUP;
                case (int)ShellAPI.CMD.REFRESH:
					SortLVItems();
					goto CLEANUP;
                case (int)ShellAPI.CMD.PASTE:
					if (LastSelectedCSI != null) {
						cmi.lpVerb = Marshal.StringToHGlobalAnsi("paste");
						cmi.lpVerbW = Marshal.StringToHGlobalUni("paste");
					} else {
						goto CLEANUP;
					}
					break;
                case (int)ShellAPI.CMD.PASTELINK:
					cmi.lpVerb = Marshal.StringToHGlobalAnsi("pastelink");
					cmi.lpVerbW = Marshal.StringToHGlobalUni("pastelink");
					break;
                case (int)ShellAPI.CMD.PROPERTIES:
					cmi.lpVerb = Marshal.StringToHGlobalAnsi("properties");
					cmi.lpVerbW = Marshal.StringToHGlobalUni("properties");
					break;
				default:
					if (CShItem.IsVista)
						cmdID -= 1;
					//12/15/2010 Change
					cmi.lpVerb = (IntPtr)cmdID;
					cmi.lpVerbW = (IntPtr)cmdID;
					m_CreateNew = true;
					HR = m_WindowsContextMenu.newMenu.InvokeCommand(ref cmi);

					goto CLEANUP;
			}

			// Invoke the Paste, Paste Shortcut or Properties command
			if (LastSelectedCSI != null) {
				int prgf = 0;
				IntPtr iunk = IntPtr.Zero;
				IShellFolder folder = null;
				if (object.ReferenceEquals(LastSelectedCSI, CShItem.GetDeskTop())) {
					folder = LastSelectedCSI.Folder;
				} else {
					folder = LastSelectedCSI.Parent.Folder;
				}

				IntPtr relPidl = CShItem.ILFindLastID(LastSelectedCSI.PIDL);
                Guid ICMenu = ShellAPI.IID_IContextMenu;
				HR = folder.GetUIObjectOf(IntPtr.Zero, 1, new IntPtr[] { relPidl }, ref ICMenu, ref prgf, ref iunk);
				#if DEBUG
				if (!(HR == ShellAPI.S_OK)) {
					Marshal.ThrowExceptionForHR(HR);
				}
				#endif

				m_WindowsContextMenu.winMenu = (IContextMenu)Marshal.GetObjectForIUnknown(iunk);
				HR = m_WindowsContextMenu.winMenu.InvokeCommand(ref cmi);
				m_WindowsContextMenu.ReleaseMenu();

				#if DEBUG
				if (!(HR == ShellAPI.S_OK)) {
					Marshal.ThrowExceptionForHR(HR);
				}
				#endif
			}
		}
		CLEANUP:
		//12/15/2010 change
		m_WindowsContextMenu.ReleaseNewMenu();

		Marshal.Release(comContextMenu);
		comContextMenu = IntPtr.Zero;
		Marshal.Release(viewSubMenu);
		viewSubMenu = IntPtr.Zero;
	}

	#endregion

	/// <summary>
	/// Handles Windows Messages having to do with the display of Cascading menus of the Context Menu.
	/// </summary>
	/// <param name="m">The Windows Message</param>
    protected override void WndProc(ref System.Windows.Forms.Message m)
	{
		//For send to menu in the ListView context menu
		int hr = 0;
        if (m.Msg == (int)ShellAPI.WM.INITMENUPOPUP | m.Msg == (int)ShellAPI.WM.MEASUREITEM | m.Msg == (int)ShellAPI.WM.DRAWITEM)
        {
			if ((m_WindowsContextMenu.winMenu2 != null)) {
				hr = m_WindowsContextMenu.winMenu2.HandleMenuMsg(m.Msg, m.WParam, m.LParam);
				if (hr == 0) {
					return;
				}
			} else if ((m.Msg == (int)ShellAPI.WM.INITMENUPOPUP & m.WParam == m_WindowsContextMenu.newMenuPtr) | m.Msg == (int)ShellAPI.WM.MEASUREITEM | m.Msg == (int)ShellAPI.WM.DRAWITEM) {
				if ((m_WindowsContextMenu.newMenu2 != null)) {
					hr = m_WindowsContextMenu.newMenu2.HandleMenuMsg(m.Msg, m.WParam, m.LParam);
					if (hr == 0) {
						return;
					}
				}
			}
		} else if (m.Msg == (int)ShellAPI.WM.MENUCHAR) {
			if ((m_WindowsContextMenu.winMenu3 != null)) {
				hr = m_WindowsContextMenu.winMenu3.HandleMenuMsg2(m.Msg, m.WParam, m.LParam, IntPtr.Zero);
				if (hr == 0) {
					return;
				}
			}
		}
		base.WndProc(ref m);
	}
	#endregion

	#region "       Keyboard Events "
	/// <summary>
	/// Handles Delete Key processing for the ListView
	/// </summary>
	/// <param name="sender">object that raised the event</param>
	/// <param name="e">a KeyEventsArgs</param>
	/// <remarks>Modified version of Calum McLellan's code from ExpList.</remarks>
    private void lv1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete) {
			if (LastSelectedCSI != null && LastSelectedCSI.IsFolder) {
				int HR = 0;
				int prgf = 0;
				IntPtr iunk = IntPtr.Zero;
				IShellFolder folder = LastSelectedCSI.Folder;
				IntPtr[] pidls = new IntPtr[lv1.SelectedItems.Count];
				int i = 0;

				for (i = 0; i <= lv1.SelectedItems.Count - 1; i++) {
					if (!((CShItem)lv1.SelectedItems[i].Tag).CanDelete) {
						Interaction.MsgBox("Cannot Delete: " + ((CShItem)lv1.SelectedItems[i].Tag).DisplayName, MsgBoxStyle.OkOnly, "Cannot Delete");
						return;
					}
					//If Not lv1.SelectedItems(i).Tag.CanRename Then AllowRename = False
                    CShItem TheItem = (CShItem)lv1.SelectedItems[i].Tag;
					pidls[i] = CShItem.ILFindLastID(TheItem.PIDL);
				}
				IntPtr relPidl = CShItem.ILFindLastID(LastSelectedCSI.PIDL);
                Guid CMenu = ShellAPI.IID_IContextMenu;
				HR = folder.GetUIObjectOf(IntPtr.Zero, pidls.Length, pidls, ref CMenu, ref prgf, ref iunk);
				#if DEBUG
                if (!(HR == ShellAPI.S_OK))
                {
					Marshal.ThrowExceptionForHR(HR);
				}
				#endif

                    
				m_WindowsContextMenu.winMenu = (IContextMenu)Marshal.GetObjectForIUnknown(iunk);
                ShellAPI.CMInvokeCommandInfoEx cmi = new ShellAPI.CMInvokeCommandInfoEx();
				cmi.cbSize = Marshal.SizeOf(cmi);
                cmi.nShow = (int)ShellAPI.SW.SHOWNORMAL;
                cmi.fMask = (int)(ShellAPI.CMIC.UNICODE | ShellAPI.CMIC.PTINVOKE);
				cmi.ptInvoke = new System.Drawing.Point(0, 0);
				cmi.lpVerb = Marshal.StringToHGlobalAnsi("delete");
				cmi.lpVerbW = Marshal.StringToHGlobalUni("delete");

				HR = m_WindowsContextMenu.winMenu.InvokeCommand(ref cmi);
				m_WindowsContextMenu.ReleaseMenu();
                //#if DEBUG
                //if (!(HR == ShellAPI.S_OK))
                //{
                //    Marshal.ThrowExceptionForHR(HR);
                //}
                //#endif
			}
		}
	}

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //ExpTree1.RootItem = CShItem.GetCShItem(ShellDll.CSIDL.DESKTOP);

            ExpTree1.RootItem = CShItem.GetCShItem(ExpTreeLib.ShellDll.ShellAPI.CSIDL.DESKTOP);


			
			BackItemStack.Add(ExpTreeLib.ShellDll.ShellAPI.CSIDL.DESKTOP);
			ItemCount = BackItemStack.Count;
			button4.Enabled = true;
					

			//BackItemStack.Add(CreateObject("WScript.Shell").SpecialFolders("Desktop"))
			//ItemCount = BackItemStack.Count
			//btnBack.Enabled = True

			//BackItemStack.Add(CreateObject("WScript.Shell").SpecialFolders("Desktop"))

			//ExpTree1.RootItem = CShItem.GetCShItem(CShItem.GetDeskTop);
			//BackItemStack.Add(Environment.SpecialFolder.Desktop);

			//ItemCount = BackItemStack.Count;
			//btnBack.Enabled = true;

		}

        private void button2_Click(object sender, EventArgs e)
        {
            ExpTree1.RootItem = CShItem.GetCShItem(ExpTreeLib.ShellDll.ShellAPI.CSIDL.DRIVES);
			
			BackItemStack.Add(ExpTreeLib.ShellDll.ShellAPI.CSIDL.DRIVES);
			ItemCount = BackItemStack.Count;
			button4.Enabled = true;


			//BackItemStack.Add("::{20D04FE0-3AEA-1069-A2D8-08002B30309D}")
			//ItemCount = BackItemStack.Count
			//btnBack.Enabled = True
		}

      

        private void button3_Click(object sender, EventArgs e)
        {
			this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try 
			{ 
			

			//			If ItemCount = 0 Then
			//	btnBack.Enabled = False
			//	Exit Sub
			//Else
			//	btnBack.Enabled = True
			//End If

			//Dim chitem As New CShItem(BackItemStack.Item(ItemCount - 1).ToString)
			//AfterNodeSelect(BackItemStack.Item(ItemCount - 1).ToString, chitem)
			//ItemCount = ItemCount - 1

			//CShItem chitem = new CShItem(LastSelectedCSI,BackItemStackp[ItemCount - 1]);

			if (ItemCount <= 1)
            {
				//button4.Enabled = false;
            }
			else
            {
				//button4.Enabled = true;

					if (BackItemStack.Count > 0)
					{

						//CShItem ChiItemBack = new CShItem(LastSelectedCSI, BackItemStack[ItemCount - 1].ToString ());

						CShItem ChiItemBack = CShItem.GetCShItem(BackItemStack[ItemCount - 1].ToString());

						AfterNodeSelect(BackItemStack[ItemCount - 1].ToString(), ChiItemBack);

						ExpTree1.ExpandANode(BackItemStack[ItemCount - 1].ToString(), true);

						ItemCount = ItemCount - 1;


						//ExpTree1.RootItem = CShItem.GetCShItem(BackItemStack[ItemCount - 1].ToString());

						//ExpTree1.ExpTreeNodeSelected += CShItem.GetCShItem(BackItemStack[ItemCount - 1].ToString());



						//AfterNodeSelect(BackItemStack[ItemCount - 1].ToString(), chicheck);				


						//ExpTree1.RootItem = CShItem.GetCShItem("N:\\transfer\\");
						//ExpTree1.ExpTreeNodeSelected(CShItem.GetCShItem(BackItemStack[ItemCount - 1].ToString());


					}
				}

			//CShItem chicheck = CShItem.GetCShItem(BackItemStack[ItemCount - 1].ToString());

			

				//ItemCount = ItemCount - 1;

			}
			catch(Exception ex)
            {
				MessageBox.Show(ex.Message.ToString());

            }

		}

        private void frmThreadCS_Load(object sender, EventArgs e)
        {

        }
    }
}
