//using Common;
using Commen2;
using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Application_Tool;
using JobTracker.Classes;
using JobTracker.InvoiceReport;
using JobTracker.JobTrackingMDIForm;
//using JobTracker.Open_Dilaogue_Frm;
using JobTracker.TimeSheetData;
using JTToaster;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using ExpTree_Demo_CS;
using NPOI.HSSF.UserModel;

namespace JobTracker.JobTrackingForm
{
    public partial class JobStatus : Form
    
    {
        ManagerRepository repo = new ManagerRepository();

        public string str1;
        ManagerRepository repo2 = new ManagerRepository("");


        #region Declaration
        public DataTable dtJL = new DataTable();
        public DataTable dtPreReq = new DataTable();
        public string AutoJB;
        public DataTable dtPermit = new DataTable();
        public JobAndTrackingMDI mdio;
        public DataTable dtNotes = new DataTable();
        public int firstLoad = 0;
        public string cbxJobListDescriptionEvent;
        public string cbxSearchTrackCommentEvent;
        public DataGridViewComboBoxColumn cbxClient = new DataGridViewComboBoxColumn();
        public DataGridViewComboBoxColumn cmbInvoiceClient = new DataGridViewComboBoxColumn();
        public DataGridViewComboBoxColumn cbxContacts = new DataGridViewComboBoxColumn();
        public string ContactsName = string.Empty;
        public int ContactsRowIndex = -1;
        public int selectedJobListID;
        public string CheckString;
        public ComboBox cb = new ComboBox();
        public string GridSymbole;
        public DataGridViewComboBoxCell cmbTCTackName;
        public static JobStatus _Instance;
        public Notification ToasterNoty;
        public string CopyPath;
        public string FolderName;
        public bool isDisable;
        public bool ManagerLoad = true;
        public Int64 JobID;
        public bool selectRecord_Joblist = false;
        public Int32 Colorid;
        public string UserName;
        public string UserType;
        public bool CheckUser;
        public string ColorColumn;
        private const string TIMESERVICEFEE = "TimeServiceFee;";
        public string TestingDate;

        

        #endregion

        #region Properties
        public static JobStatus Instance
        {
            get
            {
                if (_Instance == null || _Instance.IsDisposed)
                {
                    _Instance = new JobStatus();
                }
                return _Instance;
            }
        }

        public string GetCopyFolderName
        {
            get { return CopyPath; }
            set { CopyPath = value; }
        }
        public string GetFolderName
        {
            get
            {
                return FolderName;
            }
            set
            {
                FolderName = value;
            }
        }
        private Color mBodyColor;
        public Color BodyColor
        {
            get
            {
                // Do some work
                return mBodyColor;
            }
            set
            {
                mBodyColor = value;
            }
        }

        public bool isDisabled
        {
            get
            {
                return isDisable;
            }
            set
            {
                isDisable = value;
            }
        }

        private int processcount;

        #endregion

        #region Events

        public JobStatus()
        {
            InitializeComponent();
        }

        private void JobStatus_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                ProgressBar1.Visible = false;
                label11.Visible = false;
                //mdio.MdiParent = MdiParent;
                ManagerLoad = true;
                btnImportTimeSheetData.Visible = false;
                BtnHistoryClick.Visible = true;
                //DefaultValueSetup();



            }
            catch (Exception ex)
            {
                MessageBox.Show("JobStatus_Load");
                cErrorLog.WriteLog("JobStatus", "JobStatus_Load", ex.Message);
            }
        }

        private void TimerLoad_Tick(object sender, EventArgs e)
        {
            try
            {
                if (ManagerLoad)
                {
                    try
                    {
                        selectRecord_Joblist = true;
                        chkPreRequirment.Checked = false;

                        
                        SetColumns();
                                               
                        fillGridJobList();


                        //DriveListBox1.DataSource = "D:";
                        //var MainGrid = new List<ManagerData>();
                        //MainGrid = new GetManagerData();

                        //grvJobList.DataSource = MainGrid;
                        selectRecord_Joblist = false;
                    }
                    catch (Exception ex)
                    {
                        cErrorLog.WriteLog("JobStatus", "TimerLoad_Tick", ex.Message);
                    }
                }
                if (selectRecord_Joblist == false)
                {
                    if (processcount == 1)
                    {
                        //MessageBox.Show("13");



                        SetColumnPreRequirment();
                        FillGridPreRequirment();




                        //var PreRequirement = new List<PreRequirement>();
                        //PreRequirement = new GetPreRequirement();
                        //grvPreRequirments.DataSource = PreRequirement;

                    }
                    if (processcount == 2)
                    {
                        //MessageBox.Show("14");

                        SetColumnPermit();
                        FillGridPermitRequiredInspection();
                        //var PermitRequiredInspection = new List<PermitsRequirement>();
                        //PermitRequiredInspection = new GetPermitsRequirement();
                        //grvPreRequirments.DataSource = PermitRequiredInspection;
                    }
                    if (processcount == 3)
                    {
                        //MessageBox.Show("15");
                        SetColumnNotes();
                        FillGridNotesCommunication();
                        //var NotesCommunication = new List<NotesComunication>();
                        //NotesCommunication = new GetNotesComunication();
                        //grvPreRequirments.DataSource = NotesCommunication;
                    }
                    if (processcount == 4)
                    {
                        //   SetBadClient();
                    }
                    if (processcount == 5)
                    {
                        //MessageBox.Show("16");
                        Fillcombo();
                        ApplyPageLoadSetting();
                        if ((grvJobList.Rows.Count != 0))
                        {
                            ChangeDirJobNumber(grvJobList.Rows.Count - 1);
                            ChangeTraficLight(grvJobList.Rows.Count - 1);
                        }
                        timerLoad.Stop();
                        timerLoad.Enabled = false;
                    }
                    processcount = processcount + 1;
                }

                ManagerLoad = false;
                //MessageBox.Show("17");
            }
            catch (Exception ex)
            {
                MessageBox.Show("TimerLoad_Tick");
                cErrorLog.WriteLog("JobStatus", "TimerLoad_Tick", ex.Message);
            }
        }

        private void grvPermitsRequiredInspection_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvPermitsRequiredInspection.Columns[e.ColumnIndex].Name == "cmbBillState")
                {

                    //if (mdio.lblLogin.Text == "Admin Login")
                    if (!cGlobal.bIsAdminLoggedIn)
                    {
                        grvPermitsRequiredInspection.Columns[e.ColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        grvPermitsRequiredInspection.Columns[e.ColumnIndex].ReadOnly = false;
                    }
                }
            }
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvPermitsRequiredInspection.Columns[e.ColumnIndex].Name == "GrdbtnPrequisition")
                {
                    try
                    {
                        //Attempt to update the datasource.
                        int cnt = e.RowIndex;
                        if (Convert.ToInt32(grvPermitsRequiredInspection.Rows[cnt].Cells["JobTrackingID"].Value.ToString()) == 0)
                        {
                            InsertPermits();
                            return;
                        }
                        btnInsertPermit.Text = "Insert";
                        btnDeletePermit.Enabled = true;
                        if (string.IsNullOrEmpty(grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.CurrentRow.Index].Cells["Track"].Value.ToString()))
                        {
                            KryptonMessageBox.Show("Track field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (string.IsNullOrEmpty(grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.CurrentRow.Index].Cells["TrackSub"].Value.ToString()))
                        {
                            KryptonMessageBox.Show("TrackSub field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            SqlCommand cmd = new SqlCommand("update  Jobtracking set JobListID= @JobListID,TaskHandler=@TaskHandler,Track=@Track,Status= @Status,Submitted=@Submitted, Obtained=@Obtained,Expires=@Expires, FinalAction =@FinalAction, BillState=@BillState , AddDate=@AddDate,NeedDate= @NeedDate,TrackSub=@TrackSub,Comments=@Comments,IsChange=@IsChange,ChangeDate=@ChangeDate,TrackSubID=@TrackSubID,InvOvr=@InvOvr  where   JobTrackingID=    @JobTrackingID");

                            DateTime Submitted = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["Submitted"].Value.ToString());
                            string SubmittedStr = "";
                            SubmittedStr = Submitted.Month + "-" + Submitted.Day + "-" + Submitted.Year + " " + Submitted.ToLongTimeString();

                            DateTime Obtained = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["Obtained"].Value.ToString());
                            string ObtainedStr = "";
                            ObtainedStr = Obtained.Month + "-" + Obtained.Day + "-" + Obtained.Year + " " + Obtained.ToLongTimeString();


                            DateTime Expires = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["Expires"].Value.ToString());
                            string ExpiresStr = "";
                            ExpiresStr = Expires.Month + "-" + Expires.Day + "-" + Expires.Year + " " + Expires.ToLongTimeString();

                            DateTime AddDate = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["AddDate"].Value.ToString());
                            string AddDateStr = "";
                            AddDateStr = AddDate.Month + "-" + AddDate.Day + "-" + AddDate.Year + " " + AddDate.ToLongTimeString();


                            DateTime NeedDate = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["NeedDate"].Value.ToString());
                            string NeedDateStr = "";
                            NeedDateStr = NeedDate.Month + "-" + NeedDate.Day + "-" + NeedDate.Year + " " + NeedDate.ToLongTimeString();


                            List<SqlParameter> Param = new List<SqlParameter>
                            {
                                new SqlParameter("@IsChange", 1),
                                
                                
                                //new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")),

                                
                                //DateTime Submitted = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["Submitted"].Value.ToString());
                                //string SubmittedStr = "";
                                //SubmittedStr = Submitted.Month + "-" + Submitted.Day + "-" + Submitted.Year + " " + Submitted.ToLongTimeString();
                                //Param.Add(new SqlParameter("@Submitted", SubmittedStr.ToString()));

                                new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")),


                            //Param.Add(new SqlParameter("@JobListID", DirectCast(grvPreRequirments.Rows[cnt].Cells[14), System.Windows.Forms.DataGridViewComboBoxCell].Value)
                            new SqlParameter("@JobListID", grvPermitsRequiredInspection.Rows[cnt].Cells["JobListID"].Value.ToString()),
                                new SqlParameter("@TaskHandler", grvPermitsRequiredInspection.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()),
                                new SqlParameter("@Track", grvPermitsRequiredInspection.Rows[cnt].Cells["cmbTrack"].Value.ToString()),
                                
                                //new SqlParameter("@Submitted", grvPermitsRequiredInspection.Rows[cnt].Cells["Submitted"].Value.ToString()),

                                new SqlParameter("@Submitted", SubmittedStr.ToString()),


                            new SqlParameter("@BillState", grvPermitsRequiredInspection.Rows[cnt].Cells["cmbBillState"].Value.ToString()),
                                new SqlParameter("@TrackSub", grvPermitsRequiredInspection.Rows[cnt].Cells["TrackSub"].Value.ToString()),
                                new SqlParameter("@Comments", grvPermitsRequiredInspection.Rows[cnt].Cells["Comments"].Value.ToString()),
                                new SqlParameter("@Status", grvPermitsRequiredInspection.Rows[cnt].Cells["cmbStatus"].Value.ToString()),
                                
                                //new SqlParameter("@Obtained", grvPermitsRequiredInspection.Rows[cnt].Cells["Obtained"].Value.ToString()),
                                new SqlParameter("@Obtained", ObtainedStr.ToString()),


                                //new SqlParameter("@Expires", grvPermitsRequiredInspection.Rows[cnt].Cells["Expires"].Value.ToString()),
                                new SqlParameter("@Expires", ExpiresStr.ToString()),

                                new SqlParameter("@FinalAction", grvPermitsRequiredInspection.Rows[cnt].Cells["FinalAction"].Value.ToString()),
                                
                                //new SqlParameter("@AddDate", grvPermitsRequiredInspection.Rows[cnt].Cells["AddDate"].Value.ToString()),
                                //new SqlParameter("@NeedDate", grvPermitsRequiredInspection.Rows[cnt].Cells["NeedDate"].Value.ToString()),

                                new SqlParameter("@AddDate", AddDateStr.ToString()),
                                new SqlParameter("@NeedDate", NeedDateStr.ToString()),




                                new SqlParameter("@JobTrackingID", grvPermitsRequiredInspection.Rows[cnt].Cells["JobTrackingID"].Value.ToString()),
                                new SqlParameter("@TrackSubID", grvPermitsRequiredInspection.Rows[cnt].Cells["TrackSubID"].Value.ToString()),
                                new SqlParameter("@InvOvr", grvPermitsRequiredInspection.Rows[cnt].Cells["InvOvr"].Value.ToString())
                            };

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                if (repo2.db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                                {

                                    grvPermitsRequiredInspection.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                    grvPermitsRequiredInspection.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                    KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                                {

                                    grvPermitsRequiredInspection.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                    grvPermitsRequiredInspection.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                    KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                            //if (repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                            //{

                            //    grvPermitsRequiredInspection.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            //    grvPermitsRequiredInspection.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            //    KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}
                        }
                        catch (System.Exception eLoad)
                        {
                            //Add your error handling code here.
                            //Display error message, if any.
                            KryptonMessageBox.Show(eLoad.Message, "Manager");
                        }
                        //FillGridPermitRequiredInspection()
                        // If grvPermitsRequiredInspection.Rows.Count > 0 Then
                        grvPermitsRequiredInspection.CurrentCell = grvPermitsRequiredInspection.Rows[cnt].Cells["Comments"];
                        grvPermitsRequiredInspection.Rows[cnt].Selected = true;
                        // End Ifremo
                        // System.Windows.Forms.MessageBox.Show("Record Updated!", "Message")

                    }
                    catch (System.Exception eUpdate)
                    {
                        //Add your error handling code here.
                        //Display error message, if any.
                        KryptonMessageBox.Show(eUpdate.Message, "Manager");
                    }
                }
            }
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvPermitsRequiredInspection.Columns[e.ColumnIndex].Name == "cmbTrack")
                {
                    //FillPermitGridTrackSubCmb(e.ColumnIndex, e.RowIndex)
                }
            }
        }

        private void grvPermitsRequiredInspection_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (grvPreRequirments.Columns[e.ColumnIndex].Name == "cmbTaskHandler")
            {
                if (isDiable(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {                        
                        tempVar.DataSource = repo2.GetMasterItemTMNew();
                        tempVar.DisplayMember = "cTrack";
                    }
                    else
                    {
                        tempVar.DataSource = repo.GetMasterItemTM();
                        tempVar.DisplayMember = "cTrack";
                    }


                    //tempVar.DataSource = repo.GetMasterItemTM();
                    //tempVar.DisplayMember = "cTrack";


                }
                else
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar2 = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];

                    //tempVar2.DataSource = repo.GetMasterItemTM_D();
                    //tempVar2.DisplayMember = "cTrack";

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        tempVar2.DataSource = repo2.GetMasterItemTM_D_New();
                        tempVar2.DisplayMember = "cTrack";
                    }
                    else
                    {
                        tempVar2.DataSource = repo.GetMasterItemTM_D();
                        tempVar2.DisplayMember = "cTrack";
                    }

                }
            }

            FillPermitGridTrackSubCmb(e.RowIndex);
            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    CheckString = string.Empty;
                    if (Convert.ToInt16(grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Cells["JobListID"].Value.ToString()) == 0)
                    {
                        if (grvPermitsRequiredInspection.CurrentRow.Index == grvPermitsRequiredInspection.Rows.Count - 1)
                        {
                            return;
                        }
                        KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                    CheckString = grvPermitsRequiredInspection[e.ColumnIndex, e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void grvPermitsRequiredInspection_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            FillPermitGridTrackSubCmb(e.RowIndex);
            //Comments 1MAy2011
            //If e.ColumnIndex = 4 And e.RowIndex > -1 Then
            //    FillPermitGridTrackSubCmb(e.ColumnIndex, e.RowIndex)
            //End If
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvPermitsRequiredInspection.Columns[e.ColumnIndex].Name == "TrackSub")
                {
                    try
                    {
                        //grvPermitsRequiredInspection.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo.db.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvPermitsRequiredInspection.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'").SingleOrDefault();


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            grvPermitsRequiredInspection.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo2.db2.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvPermitsRequiredInspection.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'").SingleOrDefault();

                        }
                        else
                        {
                            grvPermitsRequiredInspection.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo.db.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvPermitsRequiredInspection.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'").SingleOrDefault();

                        }
                    }
                    catch (Exception ex)
                    { }
                }

                if (grvPermitsRequiredInspection.Columns[e.ColumnIndex].Name == "InvOvr")
                {
                    try
                    {
                        Regex regexint = new Regex("\\d([1-9]|[$]|[\\.\\d+])\\d");
                        Regex regexdec = new Regex("(^(\\$)(0|([1-9][0-9]*))(\\.[0-9]{1,6})?$)|(^(0{0,1}|([1-9][0-9]*))(\\.[0-9]{1,6})?$)");

                        Match mint = regexint.Match(grvPermitsRequiredInspection.Rows[e.RowIndex].Cells["InvOvr"].Value.ToString());
                        Match mDec = regexdec.Match(grvPermitsRequiredInspection.Rows[e.RowIndex].Cells["InvOvr"].Value.ToString());

                        if ((mint.Success & mDec.Success) != false)
                        {

                        }
                        else
                        {
                            grvPermitsRequiredInspection.Rows[e.RowIndex].Cells["InvOvr"].Value = "";
                            MessageBox.Show("Please Enter Number Only");
                        }
                    }
                    catch (Exception ex)
                    {
                        cErrorLog.WriteLog("JobStatus", "grvPermitsRequiredInspection_CellEndEdit", ex.Message);
                    }
                }

            }
            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Cells["JobListID"].Value.ToString()) == 0)
                    {
                        return;
                    }
                    if (grvPermitsRequiredInspection.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grvPermitsRequiredInspection.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grvPermitsRequiredInspection.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "grvPermitsRequiredInspection_CellEndEdit", ex.Message);
            }
        }

        private void grvPermitsRequiredInspection_DataError(System.Object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            if (grvPreRequirments.Columns[e.ColumnIndex].Name == "cmbTaskHandler")
            {
                if (isDiable(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
                    
                    //tempVar.DataSource = repo.GetMasterItemTM();
                    //tempVar.DisplayMember = "cTrack";

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        tempVar.DataSource = repo2.GetMasterItemTMNew();
                        tempVar.DisplayMember = "cTrack";
                    }
                    else
                    {
                        tempVar.DataSource = repo.GetMasterItemTM();
                        tempVar.DisplayMember = "cTrack";
                    }

                }
            }
        }

        private void grvPreRequirments_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int cnt = e.RowIndex;
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvPreRequirments.Columns[e.ColumnIndex].Name == "GrdPreRequireUpdate")
                {
                    if (Convert.ToInt32(grvPreRequirments.Rows[cnt].Cells["JobTrackingID"].Value.ToString()) == 0)
                    {
                        InsertPreReq();
                        return;
                    }
                    btnInsertPreReq.Text = "Insert";
                    btnDeletePreReq.Enabled = true;
                    if (string.IsNullOrEmpty(grvPreRequirments.Rows[grvPreRequirments.CurrentRow.Index].Cells["Track"].Value.ToString()))
                    {
                        KryptonMessageBox.Show("Track field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrEmpty(grvPreRequirments.Rows[grvPreRequirments.CurrentRow.Index].Cells["TrackSub"].Value.ToString()))
                    {
                        KryptonMessageBox.Show("TrackSub field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update  Jobtracking set JobListID= @JobListID,TaskHandler=@TaskHandler,Track=@Track,Status= @Status,Submitted=@Submitted, Obtained=@Obtained,Expires=@Expires,BillState=@BillState , AddDate=@AddDate,NeedDate= @NeedDate,TrackSub=@TrackSub,Comments=@Comments,IsChange=@IsChange,ChangeDate=@ChangeDate,TrackSubID=@TrackSubID, InvOvr=@InvOvr where   JobTrackingID=    @JobTrackingID");


                        String Temp = grvPreRequirments.Rows[cnt].Cells["JobTrackingID"].Value.ToString();

                        DateTime Submitted = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["Submitted"].Value.ToString());
                        string SubmittedStr = "";
                        SubmittedStr = Submitted.Month + "-" + Submitted.Day + "-" + Submitted.Year + " " + Submitted.ToLongTimeString();


                        DateTime Obtained = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["Obtained"].Value.ToString());
                        string ObtainedStr = "";
                        ObtainedStr = Obtained.Month + "-" + Obtained.Day + "-" + Obtained.Year + " " + Obtained.ToLongTimeString();

                        DateTime Expires = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["Expires"].Value.ToString());
                        string ExpiresStr = "";
                        ExpiresStr = Expires.Month + "-" + Expires.Day + "-" + Expires.Year + " " + Expires.ToLongTimeString();


                        DateTime AddDate = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["AddDate"].Value.ToString());
                        string AddDateStr = "";
                        AddDateStr = AddDate.Month + "-" + AddDate.Day + "-" + AddDate.Year + " " + AddDate.ToLongTimeString();

                        DateTime NeedDate = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["NeedDate"].Value.ToString());
                        string NeedDateStr = "";
                        NeedDateStr = NeedDate.Month + "-" + NeedDate.Day + "-" + NeedDate.Year + " " + NeedDate.ToLongTimeString();


                        List<SqlParameter> Param = new List<SqlParameter>
                        {
                            new SqlParameter("@IsChange", 1),
                            new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")),
                            //Param.Add(new SqlParameter("@JobListID", DirectCast(grvPreRequirments.Rows[cnt].Cells[14), System.Windows.Forms.DataGridViewComboBoxCell].Value)
                            new SqlParameter("@JobListID", grvPreRequirments.Rows[cnt].Cells["JobListID"].Value.ToString()),
                            new SqlParameter("@TaskHandler", grvPreRequirments.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()),
                            new SqlParameter("@Track", grvPreRequirments.Rows[cnt].Cells["cmbTrack"].Value.ToString()),


                            new SqlParameter("@Submitted", SubmittedStr.ToString()),
                            //new SqlParameter("@Submitted", grvPreRequirments.Rows[cnt].Cells["Submitted"].Value.ToString()),


                            new SqlParameter("@BillState", grvPreRequirments.Rows[cnt].Cells["BillState"].Value.ToString()),
                            new SqlParameter("@TrackSub", grvPreRequirments.Rows[cnt].Cells["TrackSub"].Value.ToString()),
                            new SqlParameter("@Comments", grvPreRequirments.Rows[cnt].Cells["Comments"].Value.ToString()),
                            new SqlParameter("@Status", grvPreRequirments.Rows[cnt].Cells["cmbStatus"].Value.ToString()),

                            new SqlParameter("@Obtained", ObtainedStr.ToString()),
                            new SqlParameter("@Expires",ExpiresStr.ToString()),

                            //new SqlParameter("@Obtained", grvPreRequirments.Rows[cnt].Cells["Obtained"].Value.ToString()),
                            //new SqlParameter("@Expires", grvPreRequirments.Rows[cnt].Cells["Expires"].Value.ToString()),


                            new SqlParameter("@AddDate", AddDateStr.ToString()),
                            new SqlParameter("@NeedDate", NeedDateStr.ToString()),
                            
                            //new SqlParameter("@AddDate", grvPreRequirments.Rows[cnt].Cells["AddDate"].Value.ToString()),
                            //new SqlParameter("@NeedDate", grvPreRequirments.Rows[cnt].Cells["NeedDate"].Value.ToString()),


                            new SqlParameter("@JobTrackingID", grvPreRequirments.Rows[cnt].Cells["JobTrackingID"].Value.ToString()),
                            new SqlParameter("@TrackSubID", grvPreRequirments.Rows[cnt].Cells["TrackSubID"].Value.ToString()),
                            new SqlParameter("@InvOvr", grvPreRequirments.Rows[cnt].Cells["InvOvr"].Value.ToString())
                        };

                        //if (repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                        //{
                        //    grvPreRequirments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        //    grvPreRequirments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                        //    KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //}

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            if (repo2.db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                            {
                                grvPreRequirments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                grvPreRequirments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            if (repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                            {
                                grvPreRequirments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                grvPreRequirments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    catch (System.Exception eLoad)
                    {
                        //Add your error handling code here.
                        //Display error message, if any.
                        // System.Windows.Forms.MessageBox.Show(eLoad.Message, "Message")
                    }
                    //FillGridPreRequirment()
                    // If grvPreRequirments.Rows.Count > 0 Then
                    grvPreRequirments.Rows[cnt].Selected = true;
                    grvPreRequirments.CurrentCell = grvPreRequirments.Rows[cnt].Cells["Comments"];

                    //End If
                }
            }
            //If e.ColumnIndex = 4 And e.RowIndex > -1 Then
            //    FillPreRequireGridTrackSubCmb(e.ColumnIndex, e.RowIndex)
            //End If
        }

        private void grvPreRequirments_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (grvPreRequirments.Columns[e.ColumnIndex].Name == "cmbTaskHandler")
            {
                if (isDiable(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];

                    //tempVar.DataSource = repo.GetMasterItemPM();
                    //tempVar.DisplayMember = "cTrack";

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        tempVar.DataSource = repo2.GetMasterItemPMNew();
                        tempVar.DisplayMember = "cTrack";


                    }
                    else
                    {
                        tempVar.DataSource = repo.GetMasterItemPM();
                        tempVar.DisplayMember = "cTrack";

                    }

                }
                else
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar2 = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
                    //tempVar2.DataSource = repo.GetMasterItemTM_D();
                    //tempVar2.DisplayMember = "cTrack";

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        tempVar2.DataSource = repo2.GetMasterItemTM_D_New();
                        tempVar2.DisplayMember = "cTrack";

                    }
                    else
                    {
                        tempVar2.DataSource = repo.GetMasterItemTM_D();
                        tempVar2.DisplayMember = "cTrack";
                    }

                }
            }
            if (e.ColumnIndex > -1 || e.RowIndex > -1)
            {
                CheckString = string.Empty;
                if (Convert.ToInt16(grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Cells["JobListID"].Value.ToString()) == 0)
                {
                    if (grvPreRequirments.CurrentRow.Index == grvPreRequirments.Rows.Count - 1)
                    {
                        return;
                    }
                    KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                    return;
                }
                CheckString = grvPreRequirments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            FillPreRequireGridTrackSubCmb(e.RowIndex);
        }

        private void grvPreRequirments_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            FillPreRequireGridTrackSubCmb(e.RowIndex);
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvPreRequirments.Columns[e.ColumnIndex].Name == "TrackSub")
                {
                    try
                    {
                        //grvPreRequirments.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo.db.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvPreRequirments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'").SingleOrDefault();

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            grvPreRequirments.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo2.db2.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvPreRequirments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'").SingleOrDefault();

                        }
                        else
                        {
                            grvPreRequirments.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo.db.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvPreRequirments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'").SingleOrDefault();
                        }

                    }
                    catch (Exception ex)
                    {
                        cErrorLog.WriteLog("JobStatus", "grvPreRequirments_CellEndEdit", ex.Message);
                    }
                }

                if (grvPreRequirments.Columns[e.ColumnIndex].Name == "InvOvr")
                {
                    try
                    {
                        Regex regexint = new Regex("\\d([1-9]|[$]|[\\.\\d+])\\d");
                        Regex regexdec = new Regex("(^(\\$)(0|([1-9][0-9]*))(\\.[0-9]{1,6})?$)|(^(0{0,1}|([1-9][0-9]*))(\\.[0-9]{1,6})?$)");

                        Match mint = regexint.Match(grvPreRequirments.Rows[e.RowIndex].Cells["InvOvr"].Value.ToString());
                        Match mDec = regexdec.Match(grvPreRequirments.Rows[e.RowIndex].Cells["InvOvr"].Value.ToString());

                        if ((mint.Success & mDec.Success) != false)
                        {

                        }
                        else
                        {
                            grvPreRequirments.Rows[e.RowIndex].Cells["InvOvr"].Value = "";
                            MessageBox.Show("Please Enter Number Only");
                        }
                    }
                    catch (Exception ex)
                    {
                        cErrorLog.WriteLog("JobStatus", "grvPreRequirments_CellEndEdit", ex.Message);
                    }
                }
            }
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvPreRequirments.Columns[e.ColumnIndex].Name == "cmbTrack")
                {
                    FillPreRequireGridTrackSubCmb(e.RowIndex);
                }
            }
            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Cells["JobListID"].Value) == 0)
                    {
                        return;
                    }
                    if (grvPreRequirments.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grvPreRequirments.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grvPreRequirments.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "grvPreRequirments_CellEndEdit", ex.Message);
            }
        }

        private void grvJobList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CHANGE THE SUB GIRD OF JOB LIST
            //MessageBox.Show(e.ColumnIndex.ToString());


            try
            {
                selectedJobListID = Convert.ToInt32(grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value);
                isDisabled = Convert.ToBoolean(grvJobList.Rows[e.RowIndex].Cells["IsDisable"].Value);

                if (e.ColumnIndex > -1 & e.RowIndex > -1)
                {
                    if (grvJobList.Columns[e.ColumnIndex].Name == "EmailAddress")
                    {
                    }
                }
                if (e.ColumnIndex > -1 & e.RowIndex > -1)
                {
                    if (grvJobList.Columns[e.ColumnIndex].Name == "Description")
                    {
                    }
                }
                FillGridPreRequirment();
                FillGridPermitRequiredInspection();
                FillGridNotesCommunication();
                //FillGridTimeRevenueData();

                if ((isDisabled))
                    disableJob(true);
                else
                    disableJob(false);
                ChangeDirJobNumber(e.RowIndex);

                // Manage Trafic Light
                //todo
                ChangeTraficLight(e.RowIndex);
                lblCompanyNo.Text = "Client No:- " + grvJobList.Rows[e.RowIndex].Cells["CompanyNo"].Value.ToString();
                //FillTimeSheeData(sender, e);
                FillVECostButtonColor();
                //CalculateRevenu calcRevenu = new CalculateRevenu();
            }

            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "grvJobList_CellClick", ex.Message);
            }

            int cnt = e.RowIndex;
            if (e.ColumnIndex > -1 & e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "GrdJobBtnUpdate")
                {
                    if (Convert.ToInt32(grvJobList.Rows[cnt].Cells["JobListID"].Value.ToString()) == 0)
                    {
                        InsertJobList();
                        return;
                    }
                    btnAdd.Text = "Insert";
                    btnDelete.Enabled = true;
                    try
                    {
                        // Attempt to update the datasource.
                        // validate the required value
                        if ((!ValidateRateServTypeValue(cnt)))
                            return;
                        try
                        {
                            //EFDbContext DAL = new EFDbContext();
                            SqlCommand cmd = new SqlCommand("update  JobList set JobNumber= @JobNumber,CompanyID=@CompanyID,DateAdded=@DateAdded,Description= @Description,Handler=@Handler, Address=@Address,Borough=@Borough ,InvoiceClient=@InvoiceClient ,InvoiceContact=@InvoiceContact, InvoiceEmailAddress=@InvoiceEmailAddress, InvoiceACContacts=@InvoiceACContacts, InvoiceACEmail=@InvoiceACEmail, PMrv=@PMrv, ContactsID=@ContactsID, IsChange=@IsChange , ChangeDate=@ChangeDate,OwnerName=@OwnerName,OwnerAddress=@OwnerAddress,OwnerPhone=@OwnerPhone,OwnerFax=@OwnerFax,ACContacts=@ACContacts,ACEmail=@ACEmail,Clienttext=@Clienttext,ContactsEmails=@ContactsEmails, IsDisable=@IsDisable,IsInvoiceHold=@IsInvoiceHold, RateVersionId=@RateVersionId,ServRate=@ServRate, AdminInvoice=@AdminInvoice, TypicalInvoiceType=@TypicalInvoiceType where   JobListID=@JobListID");
                            List<SqlParameter> Param = new List<SqlParameter>();
                            Param.Add(new SqlParameter("@IsChange", 1));

                            //Param.Add(new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")));




                            //DateTime DateAdded = Convert.ToDateTime(grvJobList.Rows[cnt].Cells["DateAdded"].Value.ToString());

                            //string DateAddedStr = "";

                            //DateAddedStr = DateAdded.Month + "-" + DateAdded.Day + "-" + DateAdded.Year + " " + DateAdded.ToLongTimeString();

                            Param.Add(new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")));





                            Param.Add(new SqlParameter("@JobListID", grvJobList.Rows[cnt].Cells["JobListID"].Value.ToString()));
                            Param.Add(new SqlParameter("@JobNumber", grvJobList.Rows[cnt].Cells["JobNumber"].Value.ToString()));




                            //Param.Add(new SqlParameter("@DateAdded", grvJobList.Rows[cnt].Cells["DateAdded"].Value.ToString()));


                            DateTime DateAdded = Convert.ToDateTime(grvJobList.Rows[cnt].Cells["DateAdded"].Value.ToString());

                            string DateAddedStr = "";

                            DateAddedStr = DateAdded.Month + "-" + DateAdded.Day + "-" + DateAdded.Year + " " + DateAdded.ToLongTimeString();

                            Param.Add(new SqlParameter("@DateAdded", DateAddedStr.ToString()));


                            //param1.Add(new SqlParameter("@Date", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["Date"].Value.ToString()));

                            Param.Add(new SqlParameter("@Description", grvJobList.Rows[cnt].Cells["Description"].Value.ToString()));
                            Param.Add(new SqlParameter("@Address", grvJobList.Rows[cnt].Cells["Address"].Value.ToString()));
                            Param.Add(new SqlParameter("@Handler", grvJobList.Rows[cnt].Cells["cmbHandler"].Value.ToString()));
                            Param.Add(new SqlParameter("@Borough", grvJobList.Rows[cnt].Cells["Borough"].Value.ToString()));
                            Param.Add(new SqlParameter("@PMrv", grvJobList.Rows[cnt].Cells["cmbPMrv"].Value.ToString()));
                            Param.Add(new SqlParameter("@OwnerName", grvJobList.Rows[cnt].Cells["OwnerName"].Value.ToString()));
                            Param.Add(new SqlParameter("@OwnerAddress", grvJobList.Rows[cnt].Cells["OwnerAddress"].Value.ToString()));
                            Param.Add(new SqlParameter("@OwnerPhone", grvJobList.Rows[cnt].Cells["OwnerPhone"].Value.ToString()));
                            Param.Add(new SqlParameter("@OwnerFax", grvJobList.Rows[cnt].Cells["OwnerFax"].Value.ToString()));
                            Param.Add(new SqlParameter("@ACContacts", grvJobList.Rows[cnt].Cells["ACContacts"].Value.ToString()));
                            Param.Add(new SqlParameter("@ACEmail", grvJobList.Rows[cnt].Cells["ACEmail"].Value.ToString()));
                            Param.Add(new SqlParameter("@Clienttext", grvJobList.Rows[cnt].Cells["Clienttext"].Value.ToString()));
                            Param.Add(new SqlParameter("@ContactsEmails", grvJobList.Rows[cnt].Cells["EmailAddress"].Value.ToString()));
                            Param.Add(new SqlParameter("@IsDisable", grvJobList.Rows[cnt].Cells["IsDisable"].Value));
                            Param.Add(new SqlParameter("@IsInvoiceHold", grvJobList.Rows[cnt].Cells["IsInvoiceHold"].Value));
                            Param.Add(new SqlParameter("@InvoiceClient", grvJobList.Rows[cnt].Cells["InvoiceClient"].Value.ToString()));
                            Param.Add(new SqlParameter("@InvoiceContact", grvJobList.Rows[cnt].Cells["InvoiceContact"].Value.ToString()));
                            Param.Add(new SqlParameter("@InvoiceEmailAddress", grvJobList.Rows[cnt].Cells["InvoiceEmailAddress"].Value.ToString()));
                            Param.Add(new SqlParameter("@InvoiceACContacts", grvJobList.Rows[cnt].Cells["InvoiceACContacts"].Value.ToString()));
                            Param.Add(new SqlParameter("@InvoiceACEmail", grvJobList.Rows[cnt].Cells["InvoiceACEmail"].Value.ToString()));
                            Param.Add(new SqlParameter("@RateVersionId", grvJobList.Rows[cnt].Cells["RateVersionId"].Value));
                            Param.Add(new SqlParameter("@ServRate", grvJobList.Rows[cnt].Cells["ServRate"].Value));
                            Param.Add(new SqlParameter("@AdminInvoice", grvJobList.Rows[cnt].Cells["AdminInvoice"].Value));
                            Param.Add(new SqlParameter("@TypicalInvoiceType", grvJobList.Rows[cnt].Cells["cmbTypicalInvoiceType"].Value));

                            if (grvJobList.Rows[cnt].Cells["Client#"].Value.ToString() == "")
                                Param.Add(new SqlParameter("@CompanyID", 0));
                            else
                                Param.Add(new SqlParameter("@CompanyID", grvJobList.Rows[cnt].Cells["Client#"].Value));

                            int ContactsID;


                            //string values = Convert.ToString(grvJobList.Rows[cnt].Cells["ContactsID"].Value);
                            
                            string values = Convert.ToString(grvJobList.Rows[cnt].Cells["ContactsID"].Tag);




                            if (String.IsNullOrEmpty(values))
                            {
                                Param.Add(new SqlParameter("@ContactsID", "0"));
                                ContactsID = 0;
                            }
                            else
                            {
                                ContactsID = Convert.ToInt32(grvJobList.Rows[cnt].Cells["ContactsID"].Tag.ToString());
                                Param.Add(new SqlParameter("@ContactsID", grvJobList.Rows[cnt].Cells["ContactsID"].Tag.ToString()));
                            }

                            //if (repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                            //{
                            //    grvJobList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            //    grvJobList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            //    KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //}


                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {

                                if (repo2.db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                                {
                                    grvJobList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                    grvJobList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                    KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                if (repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                                {
                                    grvJobList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                    grvJobList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                    KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }

                        }

                        catch (Exception eLoad)
                        {
                            KryptonMessageBox.Show(eLoad.Message, "Manager");
                            cErrorLog.WriteLog("JobStatus", "grvJobList_CellClick", eLoad.Message);
                        }
                        grvJobList.CurrentCell = grvJobList.Rows[cnt].Cells["Address"];
                        grvJobList.Rows[cnt].Selected = true;
                    }
                    catch (Exception eUpdate)
                    {
                        KryptonMessageBox.Show(eUpdate.Message, "Manager");
                        cErrorLog.WriteLog("JobStatus", "grvJobList_CellClick", eUpdate.Message);
                    }
                }
            }
            grvJobList_CellEnter(sender, e);
        }

        private void grvJobList_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            try
            {
                //Contact dropdown list
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    if (grvJobList.Columns[e.ColumnIndex].Name == "Contacts")
                    {
                        try
                        {


                            //        Dim Query As String = "SELECT  RTRIM(dbo.ClientName(FirstName,MiddleName,LastName)) +','+ EmailAddress as Contact FROM         Contacts WHERE  CompanyID=" & DirectCast(grvJobList.Rows(grvJobList.CurrentRow.Index).Cells("Client#"), System.Windows.Forms.DataGridViewComboBoxCell).Value & " And (IsDelete Is null Or IsDelete = 0 )"
                            //Dim cmbDT As New DataTable
                            //cmbDT = DAl.Filldatatable(Query)
                            //Dim ContactCmb As New DataGridViewComboBoxCell
                            //ContactCmb.DataSource = cmbDT
                            //ContactCmb.DisplayMember = cmbDT.Columns("Contact").ToString()


                            String CompanyID = "";
                            CompanyID = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["Client#"].Value.ToString();


                            string Query2 = string.Empty;

                            //Query2 = "SELECT  RTRIM(dbo.ClientName(FirstName,MiddleName,LastName)) +','+ EmailAddress as Contact " +
                            //    "FROM  Contacts WHERE  CompanyID=" + CompanyID + " And (IsDelete Is null Or IsDelete = 0 )";


                            //orignal query

                            //string Query = "SELECT  RTRIM(dbo.ClientName(FirstName,MiddleName,LastName)) +','+ EmailAddress as Contact FROM  Contacts WHERE  CompanyID=" + ((System.Windows.Forms.DataGridViewComboBoxCell)grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["Client#"]).Value.ToString() + " And (IsDelete Is null Or IsDelete = 0 )";



                            //DataGridViewComboBoxCell ContactCmb = new DataGridViewComboBoxCell();

                            //using (EFDbContext db = new EFDbContext())
                            //{
                            //    var GetData = db.Database.SqlQuery<string>(Query2);
                            //    ContactCmb.DataSource = GetData;
                            //    ContactCmb.DataSource = GetData.ToList();
                            //}


                            ////ContactCmb.ValueMember = "Contact";
                            ////ContactCmb.DisplayMember = "Contact";

                            //grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = ContactCmb;


                            //Query2 = "Select * FROM  Contacts WHERE  CompanyID=" + CompanyID + " " +
                            //    "And (IsDelete Is null Or IsDelete = 0 )";

                            //Query2 = "select CONCAT(CONCAT(FirstName, ' ', MiddleName, ' ', LastName), ',',   EmailAddress) As Contact123  FROM  Contacts WHERE  CompanyID=" + CompanyID + " " +
                            //   "And (IsDelete Is null Or IsDelete = 0 )";

                            String query3 = "Select CONCAT(CONCAT (FirstName ,' ',MiddleName , ' ' , LastName), ',',EmailAddress ) As Contact,ContactsID ";

                            ////Select FirstName +' ' + MiddleName + '' + LastName + ',' + EmailAddress AS FullName From Contacts;

                            //String query4 = "Select FirstName +' ' + MiddleName + '' + LastName + ',' + EmailAddress AS FullName ";

                            Query2 = query3 + "From Contacts ";
                            Query2 = Query2 + "WHERE  CompanyID=";
                            Query2 = Query2 + CompanyID;
                            Query2 = Query2 + " And (IsDelete Is null Or IsDelete = 0 )";

                            //                            select
                            //CONCAT(CONCAT(FirstName, ' ', MiddleName, ' ', LastName), ',', EmailAddress)
                            //As Contact



                            DataTable ContactDT = new DataTable();
                            //ContactDT = StMethod.GetListDT<ManagerSetColumn>(Query2);

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {

                                ContactDT = StMethod.GetListDTNew<ManagerSetColumn>(Query2);
                            }
                            else
                            {
                                ContactDT = StMethod.GetListDT<ManagerSetColumn>(Query2);
                            }


                            DataGridViewComboBoxCell ContactCheckCmb = new DataGridViewComboBoxCell();



                            DataSet ContactDS = new DataSet();
                            //ContactDS = StMethod.GetListDS<ManagerSetColumn2>(Query2);

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                ContactDS = StMethod.GetListDSNew<ManagerSetColumn2>(Query2);

                            }
                            else
                            {
                                ContactDS = StMethod.GetListDS<ManagerSetColumn2>(Query2);
                            }

                            ContactCheckCmb.DataSource = ContactDS.Tables[0];

                            //ContactCheckCmb.DataSource = ContactDT;

                            //foreach (DataColumn column in ContactDT.Columns)
                            //{
                            //    MessageBox.Show(column.ColumnName);
                            //}

                            //foreach (DataColumn column in ContactDS.Tables[0].Columns)
                            //{
                            //    MessageBox.Show(column.ColumnName);
                            //}


                            //ContactCheckCmb.ValueMember = ContactDS.Tables[0].Columns["Contact123"].ColumnName;
                            //ContactCheckCmb.DisplayMember = ContactDS.Tables[0].Columns["Contact123"].ColumnName;


                            ContactCheckCmb.DisplayMember = "Contact";
                            ContactCheckCmb.ValueMember = "ContactsID";



                            grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = ContactCheckCmb;



                            //foreach (DataColumn column in ContactDT.Columns)
                            //{
                            //    MessageBox.Show(column.ColumnName);
                            //}


                            //foreach (DataColumn column in ContactDT.Columns)
                            //{
                            //    if (column.ColumnName == "Contacts")
                            //    {
                            //        ContactCheckCmb.DisplayMember = column.ColumnName;
                            //        ContactCheckCmb.ValueMember = column.ColumnName;
                            //    }
                            //}



                            //ContactCheckCmb.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;




                            //ContactCheckCmb.DisplayMember = ContactDT.Columns["Contacts"].ToString();
                            //ContactCheckCmb.ValueMember = ContactDT.Columns["Contacts"].ToString();


                            //ContactCheckCmb.ValueMember = ContactDT.Columns["Contact"].ToString();



                            //ContactCmb.DisplayMember = "Contact";
                            //grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = ContactCmb;


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    }
                }
                //'Invoice contact dropdown list
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    if (grvJobList.Columns[e.ColumnIndex].Name == "InvoiceContactT")
                    {
                        try
                        {
                            string Query = "SELECT ContactsID, RTRIM(dbo.ClientName(FirstName,MiddleName,LastName)) +','+ EmailAddress as Contact FROM  Contacts WHERE  CompanyID=" + ((System.Windows.Forms.DataGridViewComboBoxCell)grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["cmbInvoiceClient"]).Value.ToString() + " And (IsDelete Is null Or IsDelete = 0 )";
                            DataGridViewComboBoxCell ContactCmb = new DataGridViewComboBoxCell();

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                                {
                                    var data = db.Database.SqlQuery<InvoiceContacts>(Query);
                                    ContactCmb.DataSource = data;
                                }

                            }
                            else
                            {
                                using (EFDbContext db = new EFDbContext())
                                {
                                    var data = db.Database.SqlQuery<InvoiceContacts>(Query);
                                    ContactCmb.DataSource = data;
                                }

                            }

                            //using (EFDbContext db = new EFDbContext())
                            //{
                            //    var data = db.Database.SqlQuery<InvoiceContacts>(Query);
                            //    ContactCmb.DataSource = data;
                            //}

                            ContactCmb.ValueMember = "ContactsID";
                            ContactCmb.DisplayMember = "Contact";
                            grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = ContactCmb;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }

                //AcContact email address
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    if (grvJobList.Columns[e.ColumnIndex].Name == "ACContacts")
                    {
                        try
                        {
                            string queryEmail = "SELECT  RTRIM(dbo.ClientName(FirstName,MiddleName,LastName)) +','+ EmailAddress as Contact FROM  Contacts WHERE Accounting=1 and CompanyID=" + ((System.Windows.Forms.DataGridViewComboBoxCell)grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["Client#"]).Value.ToString() + " And (IsDelete Is null Or IsDelete = 0 )";
                            DataGridViewComboBoxCell ACContect = new DataGridViewComboBoxCell();

                            //using (EFDbContext db = new EFDbContext())
                            //{
                            //    var data = db.Database.SqlQuery<string>(queryEmail);
                            //    ACContect.DataSource = data;
                            //}

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {

                                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                                {
                                    var data = db.Database.SqlQuery<string>(queryEmail);
                                    ACContect.DataSource = data;
                                }

                            }
                            else
                            {
                                using (EFDbContext db = new EFDbContext())
                                {
                                    var data = db.Database.SqlQuery<string>(queryEmail);
                                    ACContect.DataSource = data;
                                }

                            }


                            ACContect.DisplayMember = "Contact";
                            grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = ACContect;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                //invoiceAcContact email address
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    if (grvJobList.Columns[e.ColumnIndex].Name == "InvoiceACContactsT")
                    {
                        try
                        {
                            string queryEmail = "SELECT ContactsID, RTRIM(dbo.ClientName(FirstName,MiddleName,LastName)) +','+ EmailAddress as Contact FROM         Contacts WHERE Accounting=1 and CompanyID=" + ((System.Windows.Forms.DataGridViewComboBoxCell)grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["cmbInvoiceClient"]).Value.ToString() + " And (IsDelete Is null Or IsDelete = 0 )";
                            DataGridViewComboBoxCell ACContect = new DataGridViewComboBoxCell();

                            //using (EFDbContext db = new EFDbContext())
                            //{
                            //    var data = db.Database.SqlQuery<InvoiceContacts>(queryEmail);
                            //    ACContect.DataSource = data;
                            //}

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                                {
                                    var data = db.Database.SqlQuery<InvoiceContacts>(queryEmail);
                                    ACContect.DataSource = data;
                                }


                            }
                            else
                            {
                                using (EFDbContext db = new EFDbContext())
                                {
                                    var data = db.Database.SqlQuery<InvoiceContacts>(queryEmail);
                                    ACContect.DataSource = data;
                                }

                            }


                            ACContect.DisplayMember = "Contact";
                            ACContect.ValueMember = "ContactsID";
                            grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = ACContect;
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    CheckString = string.Empty;
                    if (Convert.ToInt16(grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobListId"].Value.ToString()) == 0)
                    {
                        if (grvJobList.CurrentRow.Index == grvJobList.Rows.Count - 1)
                        {
                            return;
                        }
                        KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }

                    //CheckString = grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    try
                    {
                        CheckString = grvJobList[e.ColumnIndex, e.RowIndex].Value.ToString();
                    }
                    catch (Exception)
                    { }
                }
                //If e.ColumnIndex = 5 And e.RowIndex > -1 Then
                //    Dim cmbDescription As DataGridViewComboBoxCell = New DataGridViewComboBoxCell
                //    cmbDescription.DataSource = DAl.Filldatatable("SELECT Id, cTrack FROM  MasterItem Whe'Operation is not valid due to the current state of the objectre ID <> 0 and (MasterItem.IsDelete=0 or MasterItem.IsDelete is null ) AND cGroup='Description'")
                //    cmbDescription.DisplayMember = "cTrack"
                //    cmbDescription.DropDownWidth = 200
                //    cmbDescription.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                //    grvJobList.Rows[5, e.RowIndex] = cmbDescription
                //End If
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "grvJobList_CellBeginEdit", ex.Message);
            }
        }

        private void grvJobList_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(DateTime.Now.ToString());

            //String value2 = null;
            string Date102 = null;
            DateTime dateTime16;

            String value2 = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString() as string;


            //if (e.ColumnIndex == 5)
            //{

            //    if ((value2 != null) && (value2 != string.Empty))
            //    {
            //        string inputString = "2000-02-02";

            //        DateTime dDate = DateTime.Now;

            //        inputString = string.Format("{0:MM/d/yyyy}", value2);
            //        inputString = value2.ToString() + " 12:00:00 AM";

            //        inputString = value2.ToString();



            //        if (DateTime.TryParse(inputString, out dDate))
            //        {

            //            value2 = string.Format("{0:MM/dd/yyyy}", dDate);

            //            string temp = string.Format("{0:dd/MM/yyyy}", value2);

            //            //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
            //            grvJobList.Rows[e.RowIndex].Cells[5].Value = value2;
            //            grvJobList.Rows[e.RowIndex].Cells[5].Tag = inputString;
            //        }
            //        else
            //        {
            //            grvJobList.Rows[e.RowIndex].Cells[5].Tag = inputString;
            //        }
            //    }
            //    else
            //    {
            //        //e.Value = e.CellStyle.NullValue;
            //        //e.FormattingApplied = true;
            //    }

            //}

    

            if (grvJobList.Rows[e.RowIndex].Cells[5].Value == null)
            {

            }
            else
            {
                //DateTime dt = new DateTime(2042, 12, 24, 18, 42, 0);

                
                value2 = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString() as string;

                //string CultureDateTimeFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortTimePattern;
                //string DateFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                //string TimeFormat = CultureInfo.CurrentUICulture.DateTimeFormat.LongTimePattern;
                //string DateTimeFormat = "DateFormat TimeFormat";

                //DateTime dt = DateTime.ParseExact(value2, DateTimeFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);



                //$CultureDateTimeFormat = (Get - Culture).DateTimeFormat
                //$DateFormat = $CultureDateTimeFormat.ShortDatePattern
                //$TimeFormat = $CultureDateTimeFormat.LongTimePattern
                //$DateTimeFormat = "$DateFormat $TimeFormat"
                //$DateTime = [DateTime]::ParseExact("06/16/2016 3:14:03 PM",$DateTimeFormat,[System.Globalization.DateTimeFormatInfo]::InvariantInfo,[System.Globalization.DateTimeStyles]::None)



                //string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                //if(sysUIFormat == "MM/d/yyyy")
                //{
                //    string filter = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString().ToString();
                //    string[] filterRemove = filter.Split('-');

                //    string Date1 = filterRemove[0];
                //    string Month1 = filterRemove[1];
                //    string TempString = filterRemove[2];

                //    string[] filterRemovePart2 = TempString.Split(' ');

                //    string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];

                //    value2 = FindalDate;
                //}

                //if (sysUIFormat == "dd/MM/yyyy")
                //{
                //    string filter = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString().ToString();
                //    string[] filterRemove = filter.Split('-');

                //    string Date1 = filterRemove[0];
                //    string Month1 = filterRemove[1];
                //    string TempString = filterRemove[2];

                //    string[] filterRemovePart2 = TempString.Split(' ');

                //    string FindalDate = Month1 + "-" + Date1 + "-" + filterRemovePart2[0];

                //    value2 = FindalDate;
                //}


                //string filter = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString().ToString();
                //string[] filterRemove = filter.Split('-');

                //string Date1 = filterRemove[0];
                //string Month1 = filterRemove[1];
                //string TempString = filterRemove[2];

                //string[] filterRemovePart2 = TempString.Split(' ');

                //string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];

                //value2 = FindalDate;

                //DateTime dt = Convert.ToDateTime(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), CultureInfo.InvariantCulture);
                //value2 = dt.ToString();

                //var date3 = DateTime.Parse(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), new CultureInfo("en-US", true));

                //value2 = date3.Month.ToString() + "-" + date3.Day.ToString() + "-" + date3.Year.ToString() + " " + date3.Hour.ToString() + ":" + date3.Minute.ToString()
                //                 + ":" + date3.Second.ToString() + " " + date3.ToString("tt");





                //string inputString;
                //DateTime dDate;

                //inputString = value2;

                //if (DateTime.TryParse(inputString, out dDate))
                //{


                //    //value2 = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                //    value2 = string.Format("{0:dd/MM/yyyy hh:mm tt}", dDate);

                //}
                //else
                //{

                //}




                //value2 = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString();

                //value2 = string.Format("{0:MM/dd/yyyy HH:mm tt}", grvJobList.Rows[e.RowIndex].Cells[5].Value);


                //DateTime date = DateTime.ParseExact(this.Text, "dd/MM/yyyy", null);

                //DateTime date2 = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), "MM/dd/yyyy", null);

                //value2 = date2.Month.ToString() + "-" + date2.Day.ToString() + "-" + date2.Year;

                //value2 = Convert.ToString(date2);

                //string format= "MM/dd/yyyy h:mm tt";

                //CultureInfo provider = CultureInfo.InvariantCulture;

                //DateTime result = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(),format, provider);



                //DateTime DT = Convert.ToDateTime(value2, System.Globalization.CultureInfo.GetCultureInfo("en-US").DateTimeFormat);

                //var regDate = DateTime.ParseExact(value2, "MM/dd/yyyy HH:mm tt", CultureInfo.InstalledUICulture);

                //value2 = regDate.ToString();

                //var DT = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(),"MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                ////var DT = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), "MM/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);

                //value2 = DT.Month.ToString() + "-" + DT.Day.ToString() + "-" + DT.Year.ToString() + " " + DT.Hour.ToString() + ":" + DT.Minute.ToString()
                //                 + ":" + DT.Second.ToString() + " " + DT.ToString("tt");


                //var myDat2 = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                ////DateTime myDat2;

                //string DateSeperator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;

                //if (DateSeperator == "/")
                //{

                //    myDat2 = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                //}
                //else if (DateSeperator == "-")
                //{

                //    myDat2 = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), "MM-dd-yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                //}


                //DateTime myDate = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), "MM-dd-yyyy hh:mm:ss",
                //                       System.Globalization.CultureInfo.InvariantCulture);

                //string DateSeperator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;

                ////string[] filterRemove = filter.Split('-');
                //string filter = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString();
                //string[] filterRemove=null;

                //if (DateSeperator == "/")
                //{

                //    filterRemove = filter.Split('/');

                //}
                //else if (DateSeperator == "-")
                //{

                //    filterRemove = filter.Split('-');
                //}




                //string Date1 = filterRemove[0];
                //string Month1 = filterRemove[1];
                //string TempString = filterRemove[2];

                //string[] filterRemovePart2 = TempString.Split(' ');

                //string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];

                //value2 = FindalDate;



                //string FinalDateUpdate = string.Empty;

                //FinalDateUpdate = dt2.Month.ToString() + "-" + dt2.Day.ToString() + "-" + dt2.Year.ToString() + " " + dt2.Hour.ToString() + ":" + dt2.Minute.ToString() + ":" + dt2.Second.ToString() + " " + dt2.ToString("tt");

                //CultureInfo provider = CultureInfo.InvariantCulture;

                //dateTime16 = DateTime.ParseExact(value2, new string[] { "MM.dd.yyyy hh:mm tt", "MM-dd-yyyy hh:mm tt", "MM/dd/yyyy hh:mm tt" }, provider, DateTimeStyles.None);

                //value2 = Convert.ToString(dateTime16);

                //inputString = string.Format("{0:MM/dd/yyyy hh:mm tt}", value2);

                //Nullable<DateTime> ActionDateUpdate = DateTime.Now;
                //ActionDateUpdate = DateTime.Parse(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString());

                //ActionDateUpdate = DateTime.ParseExact(grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString(), "MM/dd/yyyy hh:mm tt", CultureInfo.InvariantCulture);


                //string FinalDateUpdate = string.Empty;

                //FinalDateUpdate = ActionDateUpdate.Value.Month.ToString() + "-" + ActionDateUpdate.Value.Day.ToString() + "-" + ActionDateUpdate.Value.Year.ToString() + " " + ActionDateUpdate.Value.Hour.ToString() + ":" + ActionDateUpdate.Value.Minute.ToString()
                //                 + ":" + ActionDateUpdate.Value.Second.ToString() + " " + ActionDateUpdate.Value.ToString("tt");

                //value2 = FinalDateUpdate;
            }

            try
            {
                if (e.ColumnIndex == 5 & e.RowIndex > -1)
                {

                    if ((value2 != null) && (value2 != string.Empty))
                    {
                        string inputString = "2000-02-02";

                        DateTime dDate = DateTime.Now;

                        //inputString = string.Format("{0:MM/d/yyyy}", value2);
                        inputString = string.Format("{0:MM/dd/yyyy hh:mm tt}", value2);
                        
                        //inputString = value2.ToString() + " 12:00:00 AM";

                        //inputString = value2.ToString();



                        if (DateTime.TryParse(inputString, out dDate))
                        {

                            //value2 = string.Format("{0:MM/dd/yyyy}", dDate);

                            //e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);

                            value2 = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);

                            
                            //string temp = string.Format("{0:dd/MM/yyyy}", value2);
                            
                            //MessageBox.Show("value2 " + value2);
                            //MessageBox.Show("inputString " + inputString);

                            //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
                            grvJobList.Rows[e.RowIndex].Cells[5].Value = value2;
                            grvJobList.Rows[e.RowIndex].Cells[5].Tag = inputString;
                        }
                        else
                        {
                            grvJobList.Rows[e.RowIndex].Cells[5].Tag = inputString;


                            
                        }
                    }
                    else
                    {
                        //e.Value = e.CellStyle.NullValue;
                        //e.FormattingApplied = true;
                    }
                }
            }
            catch(Exception ExDateCell)
            {
                MessageBox.Show(ExDateCell.Message.ToString());
            }


            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "Clienttext")
                {
                    try
                    {
                        //Dim Query As String = "SELECT Address FROM Company WHERE CompanyID=" & DirectCast(grvJobList.Rows[e.RowIndex].Cells["Client#"), System.Windows.Forms.DataGridViewComboBoxCell].Value & ""
                        //Dim DA As New DataAccessLayer
                        //grvJobList.Rows[e.RowIndex].Cells["Address"].Value = DA.Filldatatable(Query).Rows[0).Item(0).ToString
                        grvJobList_CellEnter(sender, e);
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "Client#")
                {
                    try
                    {
                        //Select rate version based on what select into contact form corresponding selected comapany name.

                        string query2, query3 = string.Empty;

                        query2 = "SELECT (CASE WHEN DATALENGTH(isnull(TypicalInvoiceType,'')) > 0 then TypicalInvoiceType else 'Item' END ) as TypicalInvoiceType,";

                        query3 = query2 + "TableVersionId,isnull(ServRate,1) as ServRate FROM Company WHERE CompanyID=";

                        query3 = query3 +  ((DataGridViewComboBoxCell)grvJobList.Rows[e.RowIndex].Cells["Client#"]).Value.ToString() + "";


                        //string Query = "SELECT (CASE WHEN DATALENGTH(isnull(TypicalInvoiceType,'')) > 0 then TypicalInvoiceType else 'Item' END ) as TypicalInvoiceType,TableVersionId,isnull(ServRate,1) as ServRate FROM Company WHERE CompanyID=" + ((DataGridViewComboBoxCell)grvJobList.Rows[e.RowIndex].Cells["Client#"]).Value.ToString() + "";

                        if (string.IsNullOrEmpty(grvJobList.Rows[e.RowIndex].Cells["InvoiceClient"].Value.ToString()) || grvJobList.Rows[e.RowIndex].Cells["InvoiceClient"].Value.ToString() == "0")
                        {


                            //using (EFDbContext db = new EFDbContext())
                            //{



                            //    //var list = db.Database.SqlQuery<string>(Query).ToList();
                            //    //DataTable ClientT = Program.ToDataTableJobStaus(list);

                            //    DataSet ClientDS = new DataSet();
                            //    ClientDS = StMethod.GetListDS<ManagerData3>(query3);

                            //    if (btnAdd.Text == "Save")
                            //    {
                            //        RateSerTypeDefaultValueForDataSet(ClientDS,e);
                            //        //RateSerTypeDefaultValue(ClientT, e);
                            //    }
                            //    else
                            //    {
                            //        RateSerTypeDefaultValueForDataSet(ClientDS, e);
                            //        //RateServTypeDefaultValueExisting(ClientT, e);
                            //    }
                            //}



                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                                {



                                    //var list = db.Database.SqlQuery<string>(Query).ToList();
                                    //DataTable ClientT = Program.ToDataTableJobStaus(list);

                                    DataSet ClientDS = new DataSet();
                                    ClientDS = StMethod.GetListDSNew<ManagerData3>(query3);

                                    if (btnAdd.Text == "Save")
                                    {
                                        RateSerTypeDefaultValueForDataSet(ClientDS, e);
                                        //RateSerTypeDefaultValue(ClientT, e);
                                    }
                                    else
                                    {
                                        RateSerTypeDefaultValueForDataSet(ClientDS, e);
                                        //RateServTypeDefaultValueExisting(ClientT, e);
                                    }
                                }

                            }
                            else
                            {
                                using (EFDbContext db = new EFDbContext())
                                {



                                    //var list = db.Database.SqlQuery<string>(Query).ToList();
                                    //DataTable ClientT = Program.ToDataTableJobStaus(list);

                                    DataSet ClientDS = new DataSet();
                                    ClientDS = StMethod.GetListDS<ManagerData3>(query3);

                                    if (btnAdd.Text == "Save")
                                    {
                                        RateSerTypeDefaultValueForDataSet(ClientDS, e);
                                        //RateSerTypeDefaultValue(ClientT, e);
                                    }
                                    else
                                    {
                                        RateSerTypeDefaultValueForDataSet(ClientDS, e);
                                        //RateServTypeDefaultValueExisting(ClientT, e);
                                    }
                                }

                            }

                        }


                        //If (btnAdd.Text = "Save") Then
                        string companyid = ((System.Windows.Forms.DataGridViewComboBoxCell)grvJobList.Rows[e.RowIndex].Cells["Client#"]).Value.ToString();
                        DataRowView dataItem = ((DataGridViewComboBoxCell)grvJobList.Rows[e.RowIndex].Cells["Client#"]).Items.Cast<DataRowView>().Where((s) => s["CompanyID"].ToString() == companyid).FirstOrDefault();
                        //grvJobList.Rows[e.RowIndex].Cells["RateVersionID"].Value = dataItem.Row("TableVersionId")
                        //End If
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
            }

            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "Address")
                {
                    grvJobList_CellEnter(sender, e);
                }
            }
            //Contact dropdown list
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "Contacts")
                {
                    try
                    {
                        //string[] ContactStr = grvJobList.Rows[e.RowIndex].Cells["Contacts"].Value.ToString().Split(','); //Running Code

                        //if (ContactStr.Count() > 0)
                        //{

                        //    DataGridViewTextBoxCell grdtxtcell = new DataGridViewTextBoxCell();
                        //    grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = grdtxtcell;
                        //    grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ContactStr[0].Trim();
                        //    grvJobList.Rows[e.RowIndex].Cells["EmailAddress"].Value = ContactStr[1].ToString();
                        //    grvJobList_CellEnter(sender, e);
                        //}

                        string[] ContactStrNew = ((DataGridView)sender).CurrentCell.EditedFormattedValue.ToString().Split(',');



                        if (ContactStrNew.Count() > 0)
                        {

                            DataGridViewTextBoxCell grdtxtcell = new DataGridViewTextBoxCell();

                            string id1 = ((DataGridView)sender).CurrentCell.Value.ToString();

                            grdtxtcell.Tag = id1;

                            grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = grdtxtcell;
                            grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ContactStrNew[0].Trim();
                            grvJobList.Rows[e.RowIndex].Cells["ContactsID"].Tag = id1;


                            grvJobList.Rows[e.RowIndex].Cells["EmailAddress"].Value = ContactStrNew[1].ToString();
                            grvJobList_CellEnter(sender, e);



                            //Convert.ToString(grvJobList.Rows[cnt].Cells["ContactsID"].Value);


                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            //'Invoice contact dropdown list
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "InvoiceContactT")
                {
                    try
                    {
                        string[] ContactStr = null; //Running Code
                                                    //ContactStr = grvJobList.Rows[e.RowIndex].Cells["InvoiceContact"].Value.ToString.Split(",")
                        if (grvJobList.Rows[e.RowIndex].Cells["InvoiceContactT"] is System.Windows.Forms.DataGridViewComboBoxCell)
                        {
                            System.Windows.Forms.DataGridViewComboBoxCell _cmb = (System.Windows.Forms.DataGridViewComboBoxCell)(grvJobList.Rows[e.RowIndex].Cells["InvoiceContactT"]);
                            var val = _cmb.Value;
                            var rv = _cmb.Items.Cast<DataRowView>().Where((s) => s["ContactsID"] == _cmb.Value).FirstOrDefault();
                            if (rv != null)
                            {
                                ContactStr = rv["Contact"].ToString().Split(',');
                                if (ContactStr.Count() > 0)
                                {
                                    DataGridViewTextBoxCell grdtxtcell = new DataGridViewTextBoxCell();
                                    grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = grdtxtcell;
                                    grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ContactStr[0].Trim();
                                    grvJobList.Rows[e.RowIndex].Cells["InvoiceEmailAddress"].Value = ContactStr[1].ToString();
                                    grvJobList.Rows[e.RowIndex].Cells["InvoiceContact"].Value = val;
                                    grvJobList_CellEnter(sender, e);
                                }
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            //ACContact
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "ACContacts")
                {
                    try
                    {
                        string[] ACContect = grvJobList.Rows[e.RowIndex].Cells["ACContacts"].Value.ToString().Split(','); //Running Code
                        if (ACContect.Count() > 0)
                        {
                            DataGridViewTextBoxCell grdtxtcell = new DataGridViewTextBoxCell();
                            grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = grdtxtcell;
                            grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ACContect[0].Trim();
                            grvJobList.Rows[e.RowIndex].Cells["ACEmail"].Value = ACContect[1].ToString();
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            //Invoice AC Contact
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "InvoiceACContactsT")
                {
                    try
                    {
                        string[] ACContect = null; //Running Code
                                                   //ACContect = grvJobList.Rows[e.RowIndex].Cells["InvoiceACContacts"].Value.ToString.Split(",")
                        if (grvJobList.Rows[e.RowIndex].Cells["InvoiceACContactsT"] is System.Windows.Forms.DataGridViewComboBoxCell)
                        {
                            System.Windows.Forms.DataGridViewComboBoxCell _cmb = (System.Windows.Forms.DataGridViewComboBoxCell)(grvJobList.Rows[e.RowIndex].Cells["InvoiceACContactsT"]);
                            var val = _cmb.Value;
                            var rv = _cmb.Items.Cast<DataRowView>().Where(s => s["ContactsID"] == _cmb.Value).FirstOrDefault();
                            if (rv != null)
                            {
                                ACContect = rv["Contact"].ToString().Split(',');
                                if (ACContect.Count() > 0)
                                {
                                    DataGridViewTextBoxCell grdtxtcell = new DataGridViewTextBoxCell();
                                    grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex] = grdtxtcell;
                                    grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ACContect[0].Trim();
                                    grvJobList.Rows[e.RowIndex].Cells["InvoiceACEmail"].Value = ACContect[1].ToString();
                                    grvJobList.Rows[e.RowIndex].Cells["InvoiceACContacts"].Value = val;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "cmbInvoiceClient")
                {
                    try
                    {
                        int invClient = Convert.ToInt32(((System.Windows.Forms.DataGridViewComboBoxCell)grvJobList.Rows[e.RowIndex].Cells["cmbInvoiceClient"]).Value);
                        if (invClient == -99 || invClient == 0)
                        {
                            grvJobList.Rows[e.RowIndex].Cells["InvoiceContact"].Value = "";
                            grvJobList.Rows[e.RowIndex].Cells["InvoiceContactT"].Value = "";
                            grvJobList.Rows[e.RowIndex].Cells["InvoiceEmailAddress"].Value = "";
                            grvJobList.Rows[e.RowIndex].Cells["InvoiceACContacts"].Value = "";
                            grvJobList.Rows[e.RowIndex].Cells["InvoiceACContactsT"].Value = "";
                            grvJobList.Rows[e.RowIndex].Cells["InvoiceACEmail"].Value = "";
                        }
                        else
                        {
                            DataTable ClientT;
                            //Set default value of item rate, serv rate, invoice type
                            string Query = "SELECT (CASE WHEN DATALENGTH(isnull(TypicalInvoiceType,'')) > 0 then TypicalInvoiceType else 'Item' END ) as TypicalInvoiceType , TableVersionId,isnull(ServRate,1) as ServRate FROM Company WHERE CompanyID=" + invClient;


                            //using (EFDbContext db = new EFDbContext())
                            //{
                            //    var data = db.Database.SqlQuery<RateServType>(Query).ToList();
                            //    ClientT = Program.ToDataTable<RateServType>(data);
                            //}

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                                {
                                    var data = db.Database.SqlQuery<RateServType>(Query).ToList();
                                    ClientT = Program.ToDataTable<RateServType>(data);
                                }


                            }
                            else
                            {
                                using (EFDbContext db = new EFDbContext())
                                {
                                    var data = db.Database.SqlQuery<RateServType>(Query).ToList();
                                    ClientT = Program.ToDataTable<RateServType>(data);
                                }

                            }

                            if (btnAdd.Text == "Save")
                            {
                                RateSerTypeDefaultValue(ClientT, e);
                            }
                            else
                            {
                                RateServTypeDefaultValueExisting(ClientT, e);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        cErrorLog.WriteLog("JobStatus", "grvJobList_CellEnter", ex.Message);
                    }
                }
            }

            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvJobList.Columns[e.ColumnIndex].Name == "DateAdded")
                {
                    DataGridViewTextBoxCell txtCell = new DataGridViewTextBoxCell();
                    grvJobList.Rows[e.RowIndex].Cells["DateAdded"] = txtCell;
                }
            }
            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobListId"].Value.ToString()) == 0)
                    {
                        return;
                    }
                    if (grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grvJobList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grvJobList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void grvJobList_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if ((e.ColumnIndex > -1 & e.RowIndex > -1))
                {
                    //DataGridViewComboBoxCell ContactCmb = new DataGridViewComboBoxCell();
                    //DataTable DataTableContact = new DataTable();
                    if (grvJobList.Columns[e.ColumnIndex].Name == "Clienttext")
                    {
                    }
                    else if ((grvJobList.Columns[e.ColumnIndex].Name == "Contacts"))
                    {
                        //try
                        //{
                        //    int i =repo.GetValueMemberID(Convert.ToInt32(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["Client#"].Value), grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["Contacts"].Value.ToString().Trim());
                        //    if (i == 0)
                        //    {
                        //        grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["ContactsID"].Value = "";
                        //        return;
                        //    }

                        //    grvJobList.Rows[e.RowIndex].Cells["ContactsID"].Value = i;
                        //}
                        //catch (Exception ex)
                        //{

                        //}
                    }
                    // invoice contact and invoiceAcContact email address
                    if ((grvJobList.Columns[e.ColumnIndex].Name == "InvoiceContactT" | grvJobList.Columns[e.ColumnIndex].Name == "InvoiceACContactsT") & e.RowIndex > -1)
                    {
                        try
                        {
                            DataGridView datagridview = (DataGridView)sender;
                            datagridview.BeginEdit(true);
                        }
                        catch (Exception ex)
                        {
                            cErrorLog.WriteLog("JobStatus", "grvJobList_CellEnter", ex.Message);
                        }
                    }

                    if ((grvJobList.Columns[e.ColumnIndex].Name == "DateAdded" & e.RowIndex > -1))
                    {
                        try
                        {
                            //MessageBox.Show(grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                        }
                        catch (Exception ex)
                        {
                            cErrorLog.WriteLog("JobStatus", "grvJobList_CellEnter", ex.Message);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "grvJobList_CellEnter", ex.Message);
            }
        }

        private void grvJobList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                selectedJobListID = Convert.ToInt32(grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value);
                isDisabled = Convert.ToBoolean(grvJobList.Rows[e.RowIndex].Cells["IsDisable"].Value);
                ChangeTraficLight(e.RowIndex);
                FillGridPreRequirment();
                FillGridPermitRequiredInspection();
                FillGridNotesCommunication();
                if ((isDisabled))
                    disableJob(true);
                else
                    disableJob(false);
                lblCompanyNo.Text = "Client No:- " + grvJobList.Rows[e.RowIndex].Cells["CompanyNo"].Value.ToString();
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "grvJobList_RowHeaderMouseClick", ex.Message);
            }
        }


        // checking remain from here

        private void grvJobList_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                selectedJobListID = Convert.ToInt32(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobListID"].Value);
                if (Convert.IsDBNull(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["IsDisable"].Value))
                    isDisabled = Convert.ToBoolean(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["IsDisable"].Value);
                if (e.KeyCode == Keys.Up)
                {
                    if (grvJobList.CurrentRow.Index != 0)
                    {
                        selectedJobListID = Convert.ToInt32(grvJobList.Rows[grvJobList.CurrentRow.Index - 1].Cells["JobListID"].Value);
                        isDisabled = Convert.ToBoolean(grvJobList.Rows[grvJobList.CurrentRow.Index - 1].Cells["IsDisable"].Value);
                        ChangeTraficLight(grvJobList.CurrentRow.Index - 1);
                        ChangeDirJobNumber(grvJobList.CurrentRow.Index - 1);
                        FillGridPreRequirment();
                        FillGridPermitRequiredInspection();
                        FillGridNotesCommunication();
                        if ((isDisabled))
                            disableJob(true);
                        else
                            disableJob(false);
                        lblCompanyNo.Text = "Client No:- " + grvJobList.Rows[grvJobList.CurrentRow.Index - 1].Cells["CompanyNo"].Value.ToString();
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (grvJobList.CurrentRow.Index != grvJobList.Rows.Count - 1)
                    {
                        selectedJobListID = Convert.ToInt32(grvJobList.Rows[grvJobList.CurrentRow.Index + 1].Cells["JobListID"].Value);
                        isDisabled = Convert.ToBoolean(grvJobList.Rows[grvJobList.CurrentRow.Index + 1].Cells["IsDisable"].Value);
                        // Dim JobNo As String = grvJobList.Rows[grvJobList.CurrentRow.Index + 1].Cells["JobNumber"].Value.ToString
                        ChangeTraficLight(grvJobList.CurrentRow.Index + 1);
                        ChangeDirJobNumber(grvJobList.CurrentRow.Index + 1);
                        FillGridPreRequirment();
                        FillGridPermitRequiredInspection();
                        FillGridNotesCommunication();
                        if ((isDisabled))
                            disableJob(true);
                        else
                            disableJob(false);
                        lblCompanyNo.Text = "Client No:- " + grvJobList.Rows[grvJobList.CurrentRow.Index + 1].Cells["CompanyNo"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "grvJobList_KeyDown", ex.Message);
            }
        }

        private void grvNotesCommunication_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(e.ColumnIndex.ToString());

            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvNotesCommunication.Columns[e.ColumnIndex].Name == "cmbBillState")
                {
                    //if (mdio.lblLogin.Text == "Admin Login")
                    if (!cGlobal.bIsAdminLoggedIn)
                    {
                        grvNotesCommunication.Columns[e.ColumnIndex].ReadOnly = true;
                    }
                    else
                    {
                        grvNotesCommunication.Columns[e.ColumnIndex].ReadOnly = false;
                    }
                }
            }
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvNotesCommunication.Columns[e.ColumnIndex].Name == "GrdBtnNotesUpdate")
                {
                    try
                    {
                        //Attempt to update the datasource.
                        int cnt = e.RowIndex;
                        if (Convert.ToInt32(grvNotesCommunication.Rows[cnt].Cells["JobTrackingID"].Value.ToString()) == 0)
                        {
                            InsertNotes();
                            return;
                        }
                        btnInsertNotes.Text = "Insert";
                        btndeleteNotes.Enabled = true;
                        if (string.IsNullOrEmpty(grvNotesCommunication.Rows[grvNotesCommunication.CurrentRow.Index].Cells["Track"].Value.ToString()))
                        {
                            KryptonMessageBox.Show("Track field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (string.IsNullOrEmpty(grvNotesCommunication.Rows[grvNotesCommunication.CurrentRow.Index].Cells["TrackSub"].Value.ToString()))
                        {
                            KryptonMessageBox.Show("TrackSub field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        try
                        {
                            //DataAccessLayer DAL = new DataAccessLayer();
                            SqlCommand cmd = new SqlCommand("update  Jobtracking set JobListID= @JobListID,TaskHandler=@TaskHandler,Track=@Track,Status= @Status,Submitted=@Submitted, Obtained=@Obtained,Expires=@Expires,BillState=@BillState , AddDate=@AddDate,NeedDate= @NeedDate,TrackSub=@TrackSub,Comments=@Comments,IsChange=@IsChange,ChangeDate=@ChangeDate,TrackSubID=@TrackSubID, InvOvr=@InvOvr, DeleteItemTimeService=@DeleteItemTimeService where   JobTrackingID=    @JobTrackingID");

                            String temp = grvNotesCommunication.Rows[cnt].Cells["JobTrackingID"].Value.ToString();

                            List<SqlParameter> Param = new List<SqlParameter>();
                            Param.Add(new SqlParameter("@IsChange", 1));


                            //Param.Add(new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")));


                            DateTime ChangeDate = Convert.ToDateTime(DateTime.Now.ToString());
                            string ChangeDateStr = "";
                            ChangeDateStr = ChangeDate.Month + "-" + ChangeDate.Day + "-" + ChangeDate.Year + " " + ChangeDate.ToLongTimeString();
                            Param.Add(new SqlParameter("@ChangeDate", ChangeDateStr.ToString()));



                            //Param.Add(new SqlParameter("@JobListID", DirectCast(grvPreRequirments.Rows[cnt].Cells[14), System.Windows.Forms.DataGridViewComboBoxCell].Value)


                            Param.Add(new SqlParameter("@JobListID", grvNotesCommunication.Rows[cnt].Cells["JobListID"].Value.ToString()));
                            Param.Add(new SqlParameter("@TaskHandler", grvNotesCommunication.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()));
                            Param.Add(new SqlParameter("@Track", grvNotesCommunication.Rows[cnt].Cells["cmbTrack"].Value.ToString()));


                            //Param.Add(new SqlParameter("@Submitted", grvNotesCommunication.Rows[cnt].Cells["Submitted"].Value.ToString()));

                            DateTime Submitted = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["Submitted"].Value.ToString());
                            string SubmittedStr = "";
                            SubmittedStr = Submitted.Month + "-" + Submitted.Day + "-" + Submitted.Year + " " + Submitted.ToLongTimeString();
                            Param.Add(new SqlParameter("@Submitted", SubmittedStr.ToString()));


                            Param.Add(new SqlParameter("@BillState", grvNotesCommunication.Rows[cnt].Cells["cmbBillState"].Value.ToString()));
                            Param.Add(new SqlParameter("@TrackSub", grvNotesCommunication.Rows[cnt].Cells["TrackSub"].Value.ToString()));
                            Param.Add(new SqlParameter("@Comments", grvNotesCommunication.Rows[cnt].Cells["Comments"].Value.ToString()));
                            Param.Add(new SqlParameter("@Status", grvNotesCommunication.Rows[cnt].Cells["cmbStatus"].Value.ToString()));


                            //Param.Add(new SqlParameter("@Obtained", grvNotesCommunication.Rows[cnt].Cells["Obtained"].Value.ToString()));

                            DateTime Obtained = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["Obtained"].Value.ToString());
                            string ObtainedStr = "";
                            ObtainedStr = Obtained.Month + "-" + Obtained.Day + "-" + Obtained.Year + " " + Obtained.ToLongTimeString();
                            Param.Add(new SqlParameter("@Obtained", ObtainedStr.ToString()));


                            //Param.Add(new SqlParameter("@Expires", grvNotesCommunication.Rows[cnt].Cells["Expires"].Value.ToString()));

                            DateTime Expires = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["Expires"].Value.ToString());
                            string ExpiresStr = "";
                            ExpiresStr = Expires.Month + "-" + Expires.Day + "-" + Expires.Year + " " + Expires.ToLongTimeString();
                            Param.Add(new SqlParameter("@Expires", ExpiresStr.ToString()));



                            //Param.Add(new SqlParameter("@AddDate", grvNotesCommunication.Rows[cnt].Cells["AddDate"].Value.ToString()));

                            DateTime AddDate = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["AddDate"].Value.ToString());
                            string AddDateStr = "";
                            AddDateStr = AddDate.Month + "-" + AddDate.Day + "-" + AddDate.Year + " " + AddDate.ToLongTimeString();
                            Param.Add(new SqlParameter("@AddDate", AddDateStr.ToString()));



                            //Param.Add(new SqlParameter("@NeedDate", grvNotesCommunication.Rows[cnt].Cells["NeedDate"].Value.ToString()));

                            DateTime NeedDate = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["NeedDate"].Value.ToString());
                            string NeedDateStr = "";
                            NeedDateStr = NeedDate.Month + "-" + NeedDate.Day + "-" + NeedDate.Year + " " + NeedDate.ToLongTimeString();
                            Param.Add(new SqlParameter("@NeedDate", NeedDateStr.ToString()));


                            Param.Add(new SqlParameter("@JobTrackingID", grvNotesCommunication.Rows[cnt].Cells["JobTrackingID"].Value.ToString()));
                            Param.Add(new SqlParameter("@TrackSubID", grvNotesCommunication.Rows[cnt].Cells["TrackSubID"].Value.ToString()));
                            Param.Add(new SqlParameter("@InvOvr", grvNotesCommunication.Rows[cnt].Cells["InvOvr"].Value.ToString()));
                            Param.Add(new SqlParameter("@DeleteItemTimeService", grvNotesCommunication.Rows[cnt].Cells["DeleteItemTimeService"].Value.ToString()));


                            //int num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                            int num;

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                num = repo2.db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());

                            }
                            else
                            {
                                num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                            }


                            if (num > 0)
                            {
                                grvNotesCommunication.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                grvNotesCommunication.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                KryptonMessageBox.Show("Update Successfully", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        catch (System.Exception eLoad)
                        {
                            //Add your error handling code here.
                            //Display error message, if any.
                            KryptonMessageBox.Show(eLoad.Message, "Manager");
                        }
                        // FillGridPermitRequiredInspection()
                        //If grvNotesCommunication.Rows.Count > 0 Then
                        grvNotesCommunication.CurrentCell = grvNotesCommunication.Rows[cnt].Cells["Comments"];
                        grvNotesCommunication.Rows[cnt].Selected = true;
                        //End If
                        //  System.Windows.Forms.MessageBox.Show("Record Updated!", "Message")

                    }
                    catch (System.Exception eUpdate)
                    {
                        //Add your error handling code here.
                        //Display error message, if any.
                        KryptonMessageBox.Show(eUpdate.Message, "Manager");
                    }
                }
            }
            //If e.ColumnIndex = 4 And e.RowIndex > -1 Then
            //    FillNotesGridCmb(e.ColumnIndex, e.RowIndex)

            //End If
        }

        private void grvNotesCommunication_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            //if (grvPreRequirments.Columns[e.ColumnIndex].Name == "cmbTaskHandler") //change grid name - resolve exception
            if (grvNotesCommunication.Columns[e.ColumnIndex].Name == "cmbTaskHandler")
            {
                if (isDiable(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        tempVar.DataSource = repo2.GetMasterItemTMNew();
                    }
                    else
                    {
                        tempVar.DataSource = repo.GetMasterItemTM();
                    }

                    //tempVar.DataSource = repo.GetMasterItemTM();

                    //AND (isDisable <> 1 or IsDisable is  null)
                    tempVar.DisplayMember = "cTrack";
                }
                else
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar2 = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
                    //tempVar2.DataSource = repo.GetMasterItemTM_D();

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        tempVar2.DataSource = repo2.GetMasterItemTM_D_New();
                    }
                    else
                    {
                        tempVar2.DataSource = repo.GetMasterItemTM_D();
                    }
                    tempVar2.DisplayMember = "cTrack";
                }
            }
            FillNotesGridCmb(e.ColumnIndex, e.RowIndex);
            try
            {

                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    CheckString = string.Empty;
                    if (Convert.ToInt16(grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Cells["JobListID"].Value.ToString()) == 0)
                    {
                        if (grvNotesCommunication.CurrentRow.Index == grvNotesCommunication.Rows.Count - 1)
                        {
                            return;
                        }
                        KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                    CheckString = grvNotesCommunication[e.ColumnIndex, e.RowIndex].Value.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void grvNotesCommunication_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //String value2 = grvNotesCommunication.Rows[e.RowIndex].Cells[14].Value.ToString() as string;

            String value2 = null;

            if (grvNotesCommunication.Rows[e.RowIndex].Cells[14].Value == null)
            {

            }
            else
            {
                value2 = grvNotesCommunication.Rows[e.RowIndex].Cells[14].Value.ToString() as string;


                //var usCulture = new System.Globalization.CultureInfo("en-US");
                //DateTime userDate = DateTime.Parse(value2, usCulture.DateTimeFormat);
                //value2 = userDate.ToLongDateString();

            }

            if (e.ColumnIndex == 14)
            {

                if ((value2 != null) && (value2 != string.Empty))
                {
                    //string inputString = "2000-02-02";

                    //DateTime dDate = DateTime.Now;

                    ////inputString = string.Format("{0:MM/d/yyyy}", value2);
                    ////inputString = value2.ToString() + " 12:00:00 AM";

                    ////inputString = value2.ToString();
                    //inputString = value2;


                    string inputString = "2000-02-02";

                    DateTime dDate = DateTime.Now;

                    inputString = string.Format("{0:MM/d/yyyy}", value2);
                    inputString = value2.ToString() + " 12:00:00 AM";

                    inputString = value2.ToString();


                    if (DateTime.TryParse(inputString, out dDate))
                    {

                        value2 = string.Format("{0:MM/dd/yyyy}", dDate);

                        string temp = string.Format("{0:dd/MM/yyyy}", value2);

                        //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
                        grvNotesCommunication.Rows[e.RowIndex].Cells[14].Value = value2;
                        grvNotesCommunication.Rows[e.RowIndex].Cells[14].Tag = inputString;
                    }
                    else
                    {
                        grvNotesCommunication.Rows[e.RowIndex].Cells[14].Tag = inputString;


                    }

                    //if (DateTime.TryParse(inputString, out dDate))
                    //{

                    //    //value2 = string.Format("{0:MM/dd/yyyy}", dDate);
                    //    value2 = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                    //    //e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);

                    //    //string temp = string.Format("{0:dd/MM/yyyy}", value2);

                    //    //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;

                    //    grvNotesCommunication.Rows[e.RowIndex].Cells[14].Value = value2;
                    //    grvNotesCommunication.Rows[e.RowIndex].Cells[14].Tag = inputString;
                    //}
                    //else
                    //{
                    //    grvNotesCommunication.Rows[e.RowIndex].Cells[14].Tag = inputString;


                    //}
                }
                else
                {
                    //e.Value = e.CellStyle.NullValue;
                    //e.FormattingApplied = true;
                }

            }



            FillNotesGridCmb(e.ColumnIndex, e.RowIndex);
            //If e.ColumnIndex = 4 And e.RowIndex > -1 Then
            //    FillNotesGridCmb(e.ColumnIndex, e.RowIndex)
            //End If
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (grvNotesCommunication.Columns[e.ColumnIndex].Name == "TrackSub")
                {
                    try
                    {
                        //if (e.ColumnIndex > -1 && e.RowIndex > -1)
                        //    grvNotesCommunication.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo.db.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvNotesCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' AND (IsDelete=0 or IsDelete IS NULL)").FirstOrDefault();


                        if (e.ColumnIndex > -1 && e.RowIndex > -1)
                        {                          
                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                grvNotesCommunication.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo2.db2.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvNotesCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' AND (IsDelete=0 or IsDelete IS NULL)").FirstOrDefault();


                            }
                            else
                            {
                                grvNotesCommunication.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo.db.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvNotesCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "' AND (IsDelete=0 or IsDelete IS NULL)").FirstOrDefault();

                            }

                        }


                    }
                    catch (Exception ex)
                    {

                    }
                    try
                    {
                        //var data = (InvoiceTypeRate)repo.GetInvoiceTypeRate(Convert.ToInt32(grvJobList.CurrentRow.Cells["CompanyID"].Value)).SingleOrDefault();
                        var data = (InvoiceTypeRate)repo.GetInvoiceTypeRate(Convert.ToInt32(grvJobList.CurrentRow.Cells["CompanyID"].Value)).SingleOrDefault();
                        data = null;


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            data = (InvoiceTypeRate)repo2.GetInvoiceTypeRateNew(Convert.ToInt32(grvJobList.CurrentRow.Cells["CompanyID"].Value)).SingleOrDefault();
                        }
                        else
                        {
                            data = (InvoiceTypeRate)repo.GetInvoiceTypeRate(Convert.ToInt32(grvJobList.CurrentRow.Cells["CompanyID"].Value)).SingleOrDefault();
                        }

                        string InvoiceType = string.IsNullOrEmpty(grvJobList.CurrentRow.Cells["TypicalInvoiceType"].Value.ToString()) ? (string.IsNullOrEmpty(data.TypicalInvoiceType) ? "Item" : data.TypicalInvoiceType) : grvJobList.CurrentRow.Cells["TypicalInvoiceType"].Value.ToString();

                        string servRate = string.IsNullOrEmpty(grvJobList.CurrentRow.Cells["ServRate"].Value.ToString()) ? (string.IsNullOrEmpty(data.ServRate) ? "1" : data.ServRate) : grvJobList.CurrentRow.Cells["ServRate"].Value.ToString();

                        if (InvoiceType == "Time" && grvNotesCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == TIMESERVICEFEE)
                        {
                            MessageBox.Show("Invoice Type is Time already", "Manager");
                            grvNotesCommunication.CancelEdit();
                        }
                        else if ((InvoiceType == "Item") && grvNotesCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == TIMESERVICEFEE)
                        {
                            //TODO
                            ////frmPopupInvoiceTime frmpopup = new frmPopupInvoiceTime();
                            ////frmpopup.jobID = grvJobList.CurrentRow.Cells["JobListID"].Value;
                            ////frmpopup.TimeFactorServRate = servRate;
                            ////frmpopup.ShowDialog();
                            ////if (frmpopup.DialogResult == DialogResult.Yes)
                            ////{
                            ////    grvNotesCommunication.Rows[e.RowIndex].Cells["Comments"].Value = frmpopup.InsertString;
                            ////    grvNotesCommunication.Rows[e.RowIndex].Cells["DeleteItemTimeService"].Value = frmpopup.DeleteItems;
                            ////}
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }


                if (grvNotesCommunication.Columns[e.ColumnIndex].Name == "InvOvr")
                {
                    try
                    {
                        Regex regexint = new Regex("\\d([1-9]|[$]|[\\.\\d+])\\d");
                        Regex regexdec = new Regex("(^(\\$)(0|([1-9][0-9]*))(\\.[0-9]{1,6})?$)|(^(0{0,1}|([1-9][0-9]*))(\\.[0-9]{1,6})?$)");

                        Match mint = regexint.Match(grvNotesCommunication.Rows[e.RowIndex].Cells["InvOvr"].Value.ToString());
                        Match mDec = regexdec.Match(grvNotesCommunication.Rows[e.RowIndex].Cells["InvOvr"].Value.ToString());

                        if ((mint.Success & mDec.Success) != false)
                        {

                        }
                        else
                        {
                            grvNotesCommunication.Rows[e.RowIndex].Cells["InvOvr"].Value = "";
                            MessageBox.Show("Please Enter Number Only");
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }

            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Cells["JobListID"].Value.ToString()) == 0)
                    {
                        return;
                    }
                    if (grvNotesCommunication.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grvNotesCommunication.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grvNotesCommunication.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {

            }

           

            

        }

        private void grvNotesCommunication_DataError(object sender, System.Windows.Forms.DataGridViewDataErrorEventArgs e)
        {
            if (grvPreRequirments.Columns[e.ColumnIndex].Name == "cmbTaskHandler")
            {
                if (isDiable(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];
                    
                    //tempVar.DataSource = repo.GetMasterItemTM();


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        tempVar.DataSource = repo2.GetMasterItemTMNew();

                    }
                    else
                    {
                        tempVar.DataSource = repo.GetMasterItemTM();
                    }

                    tempVar.DisplayMember = "cTrack";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Insert")
            {
                for (int i = 0; i < grvJobList.Rows.Count; i++)
                {
                    if (grvJobList.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                    {
                        KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                //AutoJB = repo.AutoJobnumber();

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    AutoJB = repo2.AutoJobnumberNew();
                }
                else
                {
                    AutoJB = repo.AutoJobnumber();
                }


                btnAdd.Text = "Save";
                btnDelete.Enabled = false;
                DataRow datarow = dtJL.NewRow();
                datarow["JobListID"] = 0;
                datarow["JobNumber"] = AutoJB.ToString();


                //**** Auto Insert Setting  *****
                try
                {

                    XmlDocument myDoc = new XmlDocument();

                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                    {

                        datarow["Handler"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Joblist"]["PM"].InnerText;
                        //datarow("PMrv") = myDoc("VESoftwareSetting")("AutoInsert")("Manager")("Joblist")("PMrv").InnerText
                    }
                    else
                    {
                        datarow["Handler"] = "";
                        //datarow("PMrv") = ""
                    }
                }
                catch (Exception ex)
                {
                    datarow["Handler"] = "";
                    //datarow("PMrv") = ""
                }

                // datarow("Client") = ""
                datarow["Description"] = "";
                datarow["Address"] = "";
                datarow["Contacts"] = "";
                datarow["Borough"] = "";
                datarow["DateAdded"] = DateTime.Now;
                datarow["EmailAddress"] = "";
                datarow["OwnerName"] = "";
                datarow["OwnerAddress"] = "";
                datarow["OwnerPhone"] = "";
                datarow["OwnerFax"] = "";
                datarow["ACContacts"] = "";
                datarow["ACEmail"] = "";
                //datarow("PMrv") = ""
                datarow["InvoiceClient"] = 0;
                datarow["InvoiceContact"] = "";
                datarow["InvoiceEmailAddress"] = "";
                datarow["InvoiceACContacts"] = "";
                datarow["InvoiceACEmail"] = "";
                datarow["IsDisable"] = false;
                datarow["IsInvoiceHold"] = false;
                datarow["AdminInvoice"] = false;

                try
                {
                    XmlDocument myDoc = new XmlDocument();

                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");
                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                    {

                        datarow["PMrv"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Joblist"]["PMrv"].InnerText;
                    }
                    else
                    {
                        datarow["PMrv"] = "";
                    }
                }
                catch (Exception ex)
                {
                    datarow["PMrv"] = "";
                }

                dtJL.Rows.Add(datarow);
                grvJobList.DataSource = dtJL;
                grvJobList.CurrentCell = grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobNumber"];
                selectedJobListID = -1;
                // isDisabled = Convert.ToBoolean(grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["IsDisable"].Value)
                grvJobList.Rows[grvJobList.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                grvJobList.Rows[grvJobList.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                FillGridPreRequirment();
                FillGridNotesCommunication();
                FillGridPermitRequiredInspection();

                //If (isDisabled) Then
                //    disableJob(True)
                //Else
                //    disableJob(False)
                //End If
                //grdJobTracking.Rows[grdJobTracking.Rows.Count - 1).Selected = True
            }
            else
            {
                InsertJobList();
            }
        }

        private void DirListBox1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            FileListBox1.Path = DirListBox1.Path;
        }

        private void FileListBox1_DoubleClick(System.Object sender, System.EventArgs e)
        {

            string fExt = string.Empty;
            string filePath = FileListBox1.Path + "\\";
            try
            {
                if ((FileListBox1.FileName.LastIndexOf(".") + 1) != 0)
                {
                    System.Diagnostics.Process.Start(filePath + FileListBox1.FileName);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
        }

        private void btnInsertPreReq_Click(object sender, EventArgs e)
        {
            if (btnInsertPreReq.Text == "Insert")
            {
                for (Int32 i = 0; i < grvPreRequirments.Rows.Count; i++)
                {
                    if (grvPreRequirments.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                    {
                        // KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        return;
                    }
                }
                btnInsertPreReq.Text = "Save";
                btnDeletePreReq.Enabled = false;
                DataRow datarow = dtPreReq.NewRow();
                datarow["JobListID"] = 0;
                datarow["JobNumber"] = "";

                datarow["Track"] = "";

                datarow["Status"] = "Pending";

                try
                {
                    XmlDocument myDoc = new XmlDocument();
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                    {
                        datarow["TaskHandler"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["TM"].InnerText;
                        datarow["Track"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["Track"].InnerText;
                        datarow["TrackSub"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["TrackSub"].InnerText;
                    }
                    else
                    {
                        datarow["TaskHandler"] = "";
                        datarow["Track"] = "";
                        datarow["TrackSub"] = "";
                    }
                }
                catch (Exception ex)
                {
                    datarow["TaskHandler"] = "";
                    datarow["Track"] = "";
                    datarow["TrackSub"] = "";
                }

                //If CheckUser = True Then

                //    If UserType = "User" Then
                //        datarow("TaskHandler") = UserName.ToString()
                //        datarow("Track") = "Client Re;"
                //        datarow("TrackSub") = "Client-> Miscell;"
                //    Else
                //        datarow("TaskHandler") = ""
                //        datarow("Track") = ""
                //        datarow("TrackSub") = ""
                //    End If
                //Else
                //    datarow("TaskHandler") = ""
                //    datarow("Track") = ""
                //    datarow("TrackSub") = ""
                //    MessageBox.Show("Data entered for 'MANAGER.B12'  in settings data sheet does not match any option.  '' is substituted.", "Error handling", MessageBoxButtons.OK, MessageBoxIcon.Information)
                //End If

                datarow["Submitted"] = "1/1/1900";
                datarow["Obtained"] = "1/1/1900";

                //string ExpiresDate = "12/30/9999";
                //string[] ExpiresDateString = ExpiresDate.Split('/');
                //DateTime FinalExpiresDate = Convert.ToDateTime(ExpiresDateString[1] + "/" + ExpiresDateString[0] + "/" + ExpiresDateString[2]);

                //datarow["Expires"] = FinalExpiresDate;

                datarow["Expires"] = "12/30/9999";


                datarow["BillState"] = "";
                datarow["AddDate"] = DateTime.Now;


                //string NeedDate = "12/30/9999";
                //string[] NeedDateString = NeedDate.Split('/');
                //DateTime FinalNeedDate = Convert.ToDateTime(NeedDateString[1] + "/" + NeedDateString[0] + "/" + NeedDateString[2]);

                //datarow["NeedDate"] = FinalNeedDate;

                datarow["NeedDate"] = "12/30/9999";
                datarow["JobTrackingID"] = 0;

                try
                {
                    XmlDocument myDoc = new XmlDocument();
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                    {
                        datarow["Comments"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["Comments"].InnerText;
                    }
                    else
                    {
                        datarow["Comments"] = "";
                    }
                }
                catch (Exception ex)
                {
                    datarow["Comments"] = "";
                }

                if (Convert.ToString(datarow["TrackSub"]) != "")
                {

                    ////////DataTable dt = new DataTable();
                    //////////DataAccessLayer Dl = new DataAccessLayer();
                    ////////dt = new Filldatatable("select * from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) and  TrackSubName = '" + datarow["TrackSub"].ToString() + "' and TrackName = '" + datarow["Track"].ToString() + "'");
                    ////////if (dt.Rows.Count > 0)
                    ////////{
                    ////////    datarow["TrackSubID"] = dt.Rows[0]["id"].ToString();
                    ////////}
                    ///
                    ///
                    datarow["TrackSubID"] = repo.GetTrackSubId(datarow["TrackSub"].ToString(), datarow["Track"].ToString());
                }
                else
                {
                    datarow["TrackSubID"] = 0;
                }
                //datarow("TrackSubID") = 1
                dtPreReq.Rows.Add(datarow);
                grvPreRequirments.DataSource = dtPreReq;
                grvPreRequirments.CurrentCell = grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Cells["comments"];
                grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Selected = true;
                grvPreRequirments.Rows[grvPreRequirments.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                grvPreRequirments.Rows[grvPreRequirments.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                //grdJobTracking.Rows[grdJobTracking.Rows.Count - 1).Selected = True

            }
            else
            {
                if (btnAdd.Text == "Save")
                {
                    // KryptonMessageBox.Show("you can't save first save job list", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    return;
                }
                else
                {
                    InsertPreReq();
                }

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnDelete.Enabled = true;
            btnAdd.Text = "Insert";
            fillGridJobList();
            if (grvJobList.Rows.Count > 0)
            {
                grvJobList.CurrentCell = grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["Address"];
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UserType != "Admin")
            {
                KryptonMessageBox.Show("Only Admin Can Delete Records");
                return;
            }
            else
            {

            }

            int id = 0;
            int rowIndex = 0;
            if (grvJobList.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow SelectedRow in grvJobList.SelectedRows)
                {
                    id = Convert.ToInt32(SelectedRow.Cells["JobListID"].Value.ToString());
                    rowIndex = SelectedRow.Index;
                }
            }
            if (id == 0)
            {
                KryptonMessageBox.Show("Select a row to delete", "Message");
                return;
            }
            if (KryptonMessageBox.Show("Are you sure you want to delete this record? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    //////DataAccessLayer DAL = new DataAccessLayer();
                    //cmd = New SqlCommand("delete from JobList where JobListID=" & id, sqlcon)
                    //int num = new InsertRecord("Update JobList SET IsDelete=1 where JobListID=" + id);


                    //int num = repo.db.Database.ExecuteSqlCommand("Update JobList SET IsDelete=1 where JobListID=" + id);

                    int num;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        num = repo2.db2.Database.ExecuteSqlCommand("Update JobList SET IsDelete=1 where JobListID=" + id);
                    }
                    else
                    {
                        num = repo.db.Database.ExecuteSqlCommand("Update JobList SET IsDelete=1 where JobListID=" + id);
                    }

                    if (num > 0)
                    {
                        fillGridJobList();
                        KryptonMessageBox.Show("Record Deleted!", "Manager");
                        
                        //repo.LoginActivityInfo(repo.db, "Delete", this.Text);

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            repo2.LoginActivityInfoNew(repo2.db2, "Delete", this.Text);
                        }
                        else
                        {
                            repo.LoginActivityInfo(repo.db, "Delete", this.Text);
                        }
                    }

                    if (grvJobList.Rows.Count > 1)
                    {
                        grvJobList.Rows[rowIndex - 1].Selected = true;
                        grvJobList.CurrentCell = grvJobList.Rows[rowIndex - 1].Cells["Description"];
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Manager");
                }
            }

        }

        private void DriveListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DirListBox1.Path = DriveListBox1.Drive;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDeletePreReq_Click(object sender, EventArgs e)
        {
            if (UserType != "Admin")
            {
                KryptonMessageBox.Show("Only Admin Can Delete Records");
                return;
            }

            int id = 0;
            int rowIndex = 0;
            /////TODO
            ////foreach (Form frm in mdio.MdiChildren)
            ////{
            ////    if (frm.Text == RptInvoiceView.Text)
            ////    {
            ////        KryptonMessageBox.Show("First close " + RptInvoiceView.Text + " then delete", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////        return;
            ////    }
            ////    if (frm.Text == frmInvoiceEditRPT.Text)
            ////    {
            ////        KryptonMessageBox.Show("First close " + frmInvoiceEditRPT.Text + " then delete", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////        return;
            ////    }
            ////}
            if (grvPreRequirments.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow SelectedRow in grvPreRequirments.SelectedRows)
                {
                    id = Convert.ToInt32(SelectedRow.Cells["JobTrackingID"].Value.ToString());
                    rowIndex = SelectedRow.Index;
                }
            }
            if (id == 0)
            {
                KryptonMessageBox.Show("Select a row to delete", "Message");
                return;
            }
            if (KryptonMessageBox.Show("Are you sure you want to delete this record? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //DataAccessLayer DAL = new DataAccessLayer();
                    //cmd = New SqlCommand("delete from JobTracking where JobTrackingID=" & id, sqlcon)


                    //int num = repo.db.Database.ExecuteSqlCommand("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id);

                    int num ;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        num = repo2.db2.Database.ExecuteSqlCommand("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id);

                    }
                    else
                    {
                        num = repo.db.Database.ExecuteSqlCommand("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id);
                    }


                    if (num > 0)
                    {
                        FillGridPreRequirment();
                        KryptonMessageBox.Show("Record Deleted!", "Manager");
                        
                        //repo.LoginActivityInfo(repo.db, "Delete", this.Text);


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            repo2.LoginActivityInfoNew(repo2.db2, "Delete", this.Text);
                        }
                        else
                        {
                            repo.LoginActivityInfo(repo.db, "Delete", this.Text);
                        }
                    }
                    if (grvPreRequirments.Rows.Count > 1)
                    {
                        grvPreRequirments.Rows[rowIndex - 1].Selected = true;
                        grvPreRequirments.CurrentCell = grvPreRequirments.Rows[rowIndex - 1].Cells["Obtained"];
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Manager");
                }
            }
        }

        private void btnCancelPreReq_Click(object sender, EventArgs e)
        {
            btnDeletePreReq.Enabled = true;
            btnInsertPreReq.Text = "Insert";
            FillGridPreRequirment();
        }

        private void btnInsertPermit_Click(object sender, EventArgs e)
        {
            if (btnInsertPermit.Text == "Insert")
            {
                for (int i = 0; i < grvPermitsRequiredInspection.Rows.Count; i++)
                {
                    if (grvPermitsRequiredInspection.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                    {
                        // KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        return;
                    }
                }
                btnInsertPermit.Text = "Save";
                btnDeletePermit.Enabled = false;
                DataRow datarow = dtPermit.NewRow();
                datarow["JobListID"] = 0;
                datarow["JobNumber"] = "";

                try
                {
                    XmlDocument myDoc = new XmlDocument();
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                    {
                        datarow["TaskHandler"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["TM"].InnerText;
                        datarow["Track"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["Track"].InnerText;
                        datarow["TrackSub"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["TrackSub"].InnerText;
                    }
                    else
                    {
                        datarow["TaskHandler"] = "";
                        datarow["Track"] = "";
                        datarow["TrackSub"] = "";
                    }
                }
                catch (Exception ex)
                {
                    datarow["TaskHandler"] = "";
                    datarow["Track"] = "";
                    datarow["TrackSub"] = "";
                }

                //if (CheckUser == true)
                //{

                //    if (UserType == "User")
                //    {
                //        datarow("TaskHandler") = UserName.ToString();
                //        datarow("Track") = "VE Requ;";
                //        datarow("TrackSub") = "Miscellaneous->";

                //    }
                //    else
                //    {
                //        datarow("TaskHandler") = "";
                //        datarow("Track") = "";
                //        datarow("TrackSub") = "";

                //    }
                //}
                //else
                //{
                //    datarow("TaskHandler") = "";
                //    datarow("Track") = "";
                //    datarow("TrackSub") = "";
                //    MessageBox.Show("Data entered for 'MANAGER.B12'  in settings data sheet does not match any option.  '' is substituted.", "Error handling", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                datarow["Status"] = "Pending";
                datarow["Submitted"] = "1/1/1900";
                datarow["Obtained"] = "1/1/1900";

                //string ExpiresDate = "12/30/9999";
                //string[] ExpiresDateString = ExpiresDate.Split('/');
                //DateTime FinalExpiresDate = Convert.ToDateTime(ExpiresDateString[1] + "/" + ExpiresDateString[0] + "/" + ExpiresDateString[2]);

                //datarow["Expires"] = FinalExpiresDate;

                datarow["Expires"] = "12/30/9999";

                //datarow["Expires"] = "12/30/9999 11:59:59 PM";

                datarow["FinalAction"] = "No Action";
                datarow["BillState"] = "Not Invoiced";
                datarow["AddDate"] = DateTime.Now;


                //string NeedDate = "12/30/9999";
                //string[] NeedDateString = NeedDate.Split('/');
                //DateTime FinalNeedDate = Convert.ToDateTime(NeedDateString[1] + "/" + NeedDateString[0] + "/" + NeedDateString[2]);

                //datarow["NeedDate"] = FinalNeedDate;

                datarow["NeedDate"] = "12/30/9999";
                datarow["JobTrackingID"] = 0;

                try
                {
                    XmlDocument myDoc = new XmlDocument();
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                    {
                        datarow["Comments"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["Comments"].InnerText;

                    }
                    else
                    {
                        datarow["Comments"] = "";
                    }
                }
                catch (Exception ex)
                {
                    datarow["Comments"] = "";
                }

                if (Convert.ToString(datarow["TrackSub"]) != "")
                {

                    ////DataTable dt = new DataTable();
                    ////DataAccessLayer Dl = new DataAccessLayer();
                    ////dt = Dl.Filldatatable("select * from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) and  TrackSubName = '" + datarow["TrackSub"].ToString() + "' and TrackName = '" + datarow["Track"].ToString() + "'");
                    ////if (dt.Rows.Count > 0)
                    ////{
                    ////    datarow["TrackSubID"] = dt.Rows[0]["id"].ToString();
                    ////}
                    ///
                    datarow["TrackSubID"] = repo.GetTrackSubId(datarow["TrackSub"].ToString(), datarow["Track"].ToString());
                }
                else
                {
                    datarow["TrackSubID"] = 0;
                }
                //datarow("TrackSubID") = 1
                dtPermit.Rows.Add(datarow);
                grvPermitsRequiredInspection.DataSource = dtPermit;
                grvPermitsRequiredInspection.CurrentCell = grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Cells["comments"];
                grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Selected = true;
                grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                //grdJobTracking.Rows[grdJobTracking.Rows.Count - 1).Selected = True
            }
            else
            {
                if (btnAdd.Text == "Save")
                {
                    // KryptonMessageBox.Show("you can't save first save job list", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    return;
                }
                else
                {
                    InsertPermits();
                }
            }

        }

        private void btnDeletePermit_Click(object sender, EventArgs e)
        {
            if (UserType != "Admin")
            {
                KryptonMessageBox.Show("Only Admin Can Delete Records");
                return;
            }

            int id = 0;
            int rowIndex = 0;
            //foreach (Form frm in mdio.MdiChildren)
            //{
            //    ///need to add form - TODO
            //    //////if (frm.Text == RptInvoiceView.Text)
            //    //////{
            //    //////    KryptonMessageBox.Show("First close " + RptInvoiceView.Text + " then delete", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    //////    return;
            //    //////}
            //    //////if (frm.Text == frmInvoiceEditRPT.Text)
            //    //////{
            //    //////    KryptonMessageBox.Show("First close " + frmInvoiceEditRPT.Text + " then delete", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    //////    return;
            //    //////}
            //}
            if (grvPermitsRequiredInspection.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow SelectedRow in grvPermitsRequiredInspection.SelectedRows)
                {
                    id = Convert.ToInt32(SelectedRow.Cells["JobTrackingID"].Value.ToString());
                    rowIndex = SelectedRow.Index;
                }
            }
            if (id == 0)
            {
                KryptonMessageBox.Show("Select a row to delete", "Message");
                return;
            }
            if (KryptonMessageBox.Show("Are you sure you want to delete this record? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                try
                {
                    //DataAccessLayer DAL = new DataAccessLayer();

                    //int num = repo.db.Database.ExecuteSqlCommand("Update JobTracking SET IsDelete=1 where JobTrackingID=" + id);

                    int num;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        num = repo2.db2.Database.ExecuteSqlCommand("Update JobTracking SET IsDelete=1 where JobTrackingID=" + id);
                    }
                    else
                    {
                        num = repo.db.Database.ExecuteSqlCommand("Update JobTracking SET IsDelete=1 where JobTrackingID=" + id);
                    }

                    if (num > 0)
                    {
                        FillGridPermitRequiredInspection();
                        KryptonMessageBox.Show("Record Deleted!", "Manager");
                        
                        //repo.LoginActivityInfo(repo.db, "Delete", this.Text);

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            repo2.LoginActivityInfoNew(repo2.db2, "Delete", this.Text);
                        }
                        else
                        {
                            repo.LoginActivityInfo(repo.db, "Delete", this.Text);
                        }

                    }
                    if (grvPermitsRequiredInspection.Rows.Count > 1)
                    {
                        grvPermitsRequiredInspection.Rows[rowIndex - 1].Selected = true;
                        grvPermitsRequiredInspection.CurrentCell = grvPermitsRequiredInspection.Rows[rowIndex - 1].Cells["Obtained"];
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Manager");

                }
            }
        }

        private void btnCancelPermit_Click(object sender, EventArgs e)
        {
            btnDeletePermit.Enabled = true;
            btnInsertPermit.Text = "Insert";
            FillGridPermitRequiredInspection();
        }

        private void btnInsertNotes_Click(object sender, EventArgs e)
        {
            if (btnInsertNotes.Text == "Insert")
            {
                for (int i = 0; i < grvNotesCommunication.Rows.Count; i++)
                {
                    if (grvNotesCommunication.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                    {
                        // KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        return;
                    }
                }
                btnInsertNotes.Text = "Save";
                btndeleteNotes.Enabled = false;
                DataRow datarow = dtNotes.NewRow();
                datarow["JobListID"] = selectedJobListID;
                datarow["JobNumber"] = "";

                try
                {
                    XmlDocument myDoc = new XmlDocument();
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                    {
                        datarow["TaskHandler"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["TM"].InnerText;
                        datarow["Track"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["Track"].InnerText;
                        datarow["TrackSub"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["TrackSub"].InnerText;
                    }
                    else
                    {
                        datarow["TaskHandler"] = "";
                        datarow["Track"] = "";
                        datarow["TrackSub"] = "";
                    }
                }
                catch (Exception ex)
                {
                    datarow["TaskHandler"] = "";
                    datarow["Track"] = "";
                    datarow["TrackSub"] = "";
                }

                datarow["Status"] = "Pending";
                datarow["Submitted"] = "1/1/1900";
                datarow["Obtained"] = "1/1/1900";

                //string ExpiresDate = "12/30/9999";
                //string[] ExpiresDateString = ExpiresDate.Split('/');
                //DateTime FinalExpiresDate = Convert.ToDateTime(ExpiresDateString[1] + "/" + ExpiresDateString[0] + "/" + ExpiresDateString[2]);
                //datarow["Expires"] = FinalExpiresDate;

                datarow["Expires"] = "12/30/9999";


                datarow["BillState"] = "Not Invoiced";
                datarow["AddDate"] = DateTime.Now;

                //string NeedDate = "12/30/9999";
                //string[] NeedDateString = NeedDate.Split('/');
                //DateTime FinalNeedDate = Convert.ToDateTime(NeedDateString[1] + "/" + NeedDateString[0] + "/" + NeedDateString[2]);
                //datarow["NeedDate"] = FinalNeedDate;

                datarow["NeedDate"] = "12/30/9999";



                datarow["JobTrackingID"] = 0;

                try
                {
                    XmlDocument myDoc = new XmlDocument();
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                    {
                        datarow["Comments"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["Comments"].InnerText;

                    }
                    else
                    {
                        datarow["Comments"] = "";
                    }
                }
                catch (Exception ex)
                {
                    datarow["Comments"] = "";
                }

                if (Convert.ToString(datarow["TrackSub"]) != "")
                {
                    datarow["TrackSubID"] = repo.GetTrackSubId(datarow["TrackSub"].ToString(), datarow["Track"].ToString());
                }
                else
                {
                    datarow["TrackSubID"] = 0;
                }

                //datarow("Comments") = ""
                //datarow("TrackSubID") = 1
                dtNotes.Rows.Add(datarow);
                grvNotesCommunication.DataSource = dtNotes;
                grvNotesCommunication.CurrentCell = grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Cells["comments"];
                grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Selected = true;
                grvNotesCommunication.Rows[grvNotesCommunication.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                grvNotesCommunication.Rows[grvNotesCommunication.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                //grdJobTracking.Rows[grdJobTracking.Rows.Count - 1).Selected = True

            }
            else
            {
                if (btnAdd.Text == "Save")
                {
                    //  KryptonMessageBox.Show("you can't save first save job list", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    return;
                }
                else
                {
                    InsertNotes();
                }
            }
        }

        private void btndeleteNotes_Click(object sender, EventArgs e)
        {
            if (UserType != "Admin")
            {
                KryptonMessageBox.Show("Only Admin Can Delete Records");
                return;
            }

            int id = 0;
            int rowIndex = 0;
            //Need to add form - TODO
            ////foreach (Form frm in mdio.MdiChildren)
            ////{
            ////    if (frm.Text == RptInvoiceView.Text)
            ////    {
            ////        KryptonMessageBox.Show("First close " + RptInvoiceView.Text + " then delete", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////        return;
            ////    }
            ////    if (frm.Text == frmInvoiceEditRPT.Text)
            ////    {
            ////        KryptonMessageBox.Show("First close " + frmInvoiceEditRPT.Text + " then delete", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            ////        return;
            ////    }
            ////}
            if (grvNotesCommunication.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow SelectedRow in grvNotesCommunication.SelectedRows)
                {
                    id = Convert.ToInt32(SelectedRow.Cells["JobTrackingID"].Value.ToString());
                    rowIndex = SelectedRow.Index;
                }
            }
            if (id == 0)
            {
                KryptonMessageBox.Show("Select a row to delete", "Message");
                return;
            }
            if (KryptonMessageBox.Show("Are you sure you want to delete this record? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    //DataAccessLayer DAL = new DataAccessLayer();
                    
                    //int num = repo.db.Database.ExecuteSqlCommand("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id);
                    int num;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        num = repo2.db2.Database.ExecuteSqlCommand("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id);
                    }
                    else
                    {
                        num = repo.db.Database.ExecuteSqlCommand("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id);
                    }


                    if (num > 0)
                    {
                        FillGridNotesCommunication();
                        KryptonMessageBox.Show("Record Deleted!", "Manager");
                        
                        //repo.LoginActivityInfo(repo.db, "Delete", this.Text);

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            repo2.LoginActivityInfoNew(repo2.db2, "Delete", this.Text);
                        }
                        else
                        {
                            repo.LoginActivityInfo(repo.db, "Delete", this.Text);
                        }
                    }
                    if (grvNotesCommunication.Rows.Count > 1)
                    {
                        grvNotesCommunication.Rows[rowIndex - 1].Selected = true;
                        grvNotesCommunication.CurrentCell = grvNotesCommunication.Rows[rowIndex - 1].Cells["AddDate"];
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Manager");
                }
            }
        }

        private void btnCancelNotes_Click(object sender, EventArgs e)
        {
            btndeleteNotes.Enabled = true;
            btnInsertNotes.Text = "Insert";
            FillGridNotesCommunication();
        }

        private void chkPreRequirment_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (chkPreRequirment.Checked == false)
                {
                    pnlButtonVisible(pnlPreRequire, false);
                    tblpnlJobtrackingGrid.RowStyles[0].SizeType = SizeType.Absolute;
                    btnShowTimeData.Visible = true;
                }
                else
                {
                    pnlButtonVisible(pnlPreRequire, true);
                    tblpnlJobtrackingGrid.RowStyles[0].SizeType = SizeType.Percent;
                    btnShowTimeData.Visible = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void chkPermits_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (chkPermits.Checked == false)
                {
                    pnlButtonVisible(pnlPermits, false);
                    tblpnlJobtrackingGrid.RowStyles[1].SizeType = SizeType.Absolute;
                }
                else
                {
                    pnlButtonVisible(pnlPermits, true);
                    tblpnlJobtrackingGrid.RowStyles[1].SizeType = SizeType.Percent;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void chkNotes_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (chkNotes.Checked == false)
                {
                    pnlButtonVisible(pnlNotes, false);
                    tblpnlJobtrackingGrid.RowStyles[2].SizeType = SizeType.Absolute;
                }
                else
                {
                    pnlButtonVisible(pnlNotes, true);
                    tblpnlJobtrackingGrid.RowStyles[2].SizeType = SizeType.Percent;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void btnAgingColor_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (btnAgingColor.Visible != false)
                {

                    if(Colorid != null && Colorid  != 0 )
                    { 
                        
                        //string ColourDes = StMethod.GetSingle<string>("select EmailDescription from ColorEmailDescription where ColorID = " 
                        //+ Colorid).ToString();

                        string ColourDes;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            ColourDes = StMethod.GetSingleNew<string>("select EmailDescription from ColorEmailDescription where ColorID = "
                            + Colorid).ToString();

                        }
                        else
                        {
                            ColourDes = StMethod.GetSingle<string>("select EmailDescription from ColorEmailDescription where ColorID = "
                           + Colorid).ToString();
                        }

                        if (!string.IsNullOrEmpty(ColourDes))
                        MessageBox.Show(" " + ColourDes, "Credit Alert Color Description");

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void BtnHistoryClick_Click(object sender, EventArgs e)
        {
            try
            {
                frmAgingHistoryLog historypopup = new frmAgingHistoryLog();
                DialogResult dialogresult = historypopup.ShowDialog();
                historypopup.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnShowTimeData_Click(object sender, EventArgs e)
        {
            try
            {
                Point newLocationpoint = new System.Drawing.Point()
                {
                    X = tblpnlJobtrackingGrid.Left + btnShowTimeData.Left + 5,
                    Y = tblpnlJobtrackingGrid.Top + btnShowTimeData.Top + 30
                };
                frmShowTimeData frmshowTimeData = new frmShowTimeData();
                ////////frmshowTimeData.mdio.MdiParent = this.MdiParent;
                controlVisibility(true);
                frmshowTimeData.Dock = DockStyle.Fill;
                // frmshowTimeData.JobNumber = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString()
                if (grvJobList.Rows.Count == 0)
                {
                    frmshowTimeData.JobListId = 0;
                    frmshowTimeData.JobNumber = "";
                }
                else
                {
                    frmshowTimeData.JobListId = Convert.ToInt32(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobListId"].Value.ToString());
                    frmshowTimeData.JobNumber = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                }

                // frmshowTimeData.PM = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells[6].Value.ToString()
                frmshowTimeData.TopLevel = false;
                frmshowTimeData.Visible = true;

                pnlShowTimeSheetData.Location = newLocationpoint;
                pnlShowTimeSheetData.BringToFront();
                //pnlShowTimeDataColor.BackColor = mBodyColor

                pnlShowTimeSheetData.Controls.Add(frmshowTimeData);
                frmshowTimeData.fillgrdTimeSheetData();
                frmshowTimeData.FillcmbDistinctName();
                pnlShowTimeDataColor.BackColor = frmshowTimeData.VeCostColor;
                pnlShowTimeSheetData.AutoSize = true;
                pnlShowTimeSheetData.Refresh();
            }
            catch (Exception ex)
            { }
        }

        private void btnPermitsFileDownload_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                frmThreadCS Showdialogue = new frmThreadCS();
                //frmDragDrop Showdialogue = new frmDragDrop();
                bool Find = false;
                //Dim MYDirectoryInfo As New DirectoryInfo("N:\VE\Job2011\" & grvJobList.Item("JobNumber", grvJobList.CurrentRow.Index).Value.ToString)
                foreach (string GetDir in Directory.GetDirectories(AppConstants.JobDiretory))
                {
                    foreach (string SubGetDir in Directory.GetDirectories(GetDir))
                    {
                        if (SubGetDir.Contains(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString()))
                        {
                            //Showdialogue.GetJobPath = GetDir;
                            Find = true;
                            goto BrFor;
                        }
                        else
                        {
                            Find = false;
                        }
                    }

                }
            BrFor:
                if (Find == false)
                {
                    KryptonMessageBox.Show("For Job No:- " + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString() + " Related Folder not Found", "Job Manager", MessageBoxButtons.OK);
                    //Showdialogue.GetJobPath = AppConstants.JobDiretory;
                }
                Showdialogue.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pnlShowTimeSheetData_ControlRemoved(System.Object sender, System.Windows.Forms.ControlEventArgs e)
        {
            controlVisibility(false);
        }

        private void FillTimeSheeData(object sender, EventArgs e)
        {
            try
            {
                bool find = false;
                foreach (Control ctrl in pnlShowTimeSheetData.Controls)
                {
                    if (ctrl.Name == "frmShowTimeData")
                    {
                        frmShowTimeData frm = (frmShowTimeData)ctrl;
                        //frm.JobNumber = grvJobList.Rows[grvJobList.CurrentRow.Index).Cells("JobNumber").Value.ToString()
                        frm.JobListId = Convert.ToInt32(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobListId"].Value);
                        frm.JobNumber = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                        frm.fillgrdTimeSheetData();
                        frm.FillcmbDistinctName();
                        pnlShowTimeDataColor.BackColor = frm.VeCostColor;
                        //Else
                        //    btnShowTimeData_Click(sender, e)
                        find = true;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            //If (Not find) Then
            //    Dim frm As New frmShowTimeData
            //    frm.JobListId = grvJobList.Rows[grvJobList.CurrentRow.Index).Cells("JobListId").Value.ToString()
            //    frm.fillgrdTimeSheetData()
            //    frm.FillcmbDistinctName()
            //    pnlShowTimeDataColor.BackColor = frm.VeCostColor
            //End If
        }

        private void CmbPreRequireTrack_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                cmbTrackSubPreRequire.Items.Clear();

                //var data = StMethod.GetList<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + CmbPreRequireTrack.SelectedItem.ToString().Trim() + "'");

                var data = StMethod.GetList<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + CmbPreRequireTrack.SelectedItem.ToString().Trim() + "'");
                data = null;


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    data = StMethod.GetListNew<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + CmbPreRequireTrack.SelectedItem.ToString().Trim() + "'");
                }
                else
                {
                    data = StMethod.GetList<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + CmbPreRequireTrack.SelectedItem.ToString().Trim() + "'");
                }

                cmbTrackSubPreRequire.Items.Add("");
                foreach (var item in data)
                {
                    cmbTrackSubPreRequire.Items.Add(item);
                }
                //ApplyUserDefinedSetting()
                FillGridNotesCommunication();
                FillGridPermitRequiredInspection();
                FillGridPreRequirment();

                if (isDisabled)
                {
                    disableJob(true);
                }
                else
                {
                    disableJob(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbxSearchTm_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////if (!cmbTMWithPending.Equals(sender))
            ////{
            ////    UserDefindSetting();

            //    fillGridJobList();
            ////}
            //FillGridNotesCommunication();
            //FillGridPermitRequiredInspection();
            //FillGridPreRequirment();
            //ApplyUserDefinedSetting();

            //MessageBox.Show(cbxSearchTm.SelectedIndex.ToString());
            //MessageBox.Show(cbxSearchTm.SelectedText.ToString());
            //MessageBox.Show(cbxSearchTm.SelectedItem.ToString());
            
        }

        private void cbxJobListPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //'UserDefindSetting()
                //ApplyUserDefinedSetting()
                //fillGridJobList()




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbxJobListPMrv_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //'UserDefindSetting()
                //ApplyUserDefinedSetting()
                //fillGridJobList()

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnclear_Click(object sender, System.EventArgs e)
        {
            try
            {
                foreach (Control GP in PanelSearch.Controls)
                {
                    foreach (Control ctrl in GP.Controls)
                    {
                        if (ctrl is System.Windows.Forms.TextBox)
                        {
                            ctrl.Text = string.Empty;
                        }
                        if (ctrl is ComboBox)
                        {
                            ctrl.Text = string.Empty;
                        }
                        if (ctrl is System.Windows.Forms.CheckBox)
                        {
                            System.Windows.Forms.CheckBox chk = (CheckBox)ctrl;
                            chk.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (chkNotInvoiceJob.CheckState == CheckState.Checked)
                {
                    ApplyUserDefinedSetting();
                    fillGridJobList();
                }
                else
                {
                    fillGridJobList();
                    ApplyUserDefinedSetting();
                }

                FillGridNotesCommunication();
                FillGridPermitRequiredInspection();
                FillGridPreRequirment();
                FillTimeSheeData(sender, e);
                //disableJob(True)
                CalculateRevenu calcRevenu = new CalculateRevenu();
                if (grvJobList.Rows.Count > 0)
                {
                    selectedJobListID = Convert.ToInt32(grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobListID"].Value);
                    isDisabled = Convert.ToBoolean(grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["IsDisable"].Value);
                    calcRevenu.JobNumber = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                    // pnlShowTimeDataColor.BackColor = calcRevenu.setColor()
                }
                else
                {
                    selectedJobListID = 0;
                    isDisabled = false;
                    calcRevenu.JobNumber = "";
                }

                if (isDisabled)
                {
                    disableJob(true);
                }
                else
                {
                    disableJob(false);
                }

                ApplyUserDefinedSetting();
            }
            catch (Exception ex)
            {
                string errorstr = ex.Message;
            }
        }

        private void cmbTrackSubPreRequire_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            //fillGridJobList()

            //ApplyUserDefinedSetting()
            FillGridNotesCommunication();
            FillGridPermitRequiredInspection();
            FillGridPreRequirment();
            if (isDisabled)
            {
                disableJob(true);
            }
            else
            {
                disableJob(false);
            }
        }

        private void txtJobListclient_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                //fillGridJobList();
                //selectedJobListID = grvJobList.Item("JobListID", grvJobList.Rows.Count - 1).Value.ToString();
                //FillGridNotesCommunication();
                //FillGridPermitRequiredInspection();
                //FillGridPreRequirment();
                //CalculateRevenu calcRevenu = new CalculateRevenu();
                //calcRevenu.JobNumber = grvJobList.Rows[grvJobList.CurrentRow.Index).Cells("JobNumber").Value.ToString();
                ////' pnlShowTimeDataColor.BackColor = calcRevenu.setColor()
                //ApplyUserDefinedSetting();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkYear_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkYear.Checked == true)
            {
                cmbYear.Enabled = true;
            }
            else
            {
                cmbYear.Enabled = false;
            }
        }

        private void btnTrackSeachRefresh_Click(object sender, EventArgs e)
        {
            //'Reset the track search only section field value
            foreach (Control GP in PanelSearch.Controls)
            {
                foreach (Control txtbox in GrpSrchTrack.Controls)
                {
                    if (txtbox is System.Windows.Forms.TextBox)
                    {
                        txtbox.Text = string.Empty;
                    }
                    if (txtbox is ComboBox)
                    {
                        txtbox.Text = string.Empty;
                    }
                    if (txtbox is System.Windows.Forms.CheckBox)
                    {
                        System.Windows.Forms.CheckBox chk = (CheckBox)txtbox;
                        chk.Checked = false;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Save")
            {
                KryptonMessageBox.Show("First save then refresh or cancel the save operation", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            fillGridJobList();
            FillGridPreRequirment();
            FillGridPermitRequiredInspection();
            FillGridNotesCommunication();
            if (isDisabled)
            {
                disableJob(true);
            }
            else
            {
                disableJob(false);
            }
        }
        private void btnCreateInvoice_Click(object sender, System.EventArgs e)
        {
            bool IsWarning = false;
            string WarningMSG = "";

            if (btnAdd.Text == "Save" || btnInsertNotes.Text == "Save" || btnInsertPermit.Text == "save" || btnInsertPreReq.Text == "Save")
            {
                KryptonMessageBox.Show("First save then proceed", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //foreach (Form RptFrm in Application.OpenForms)
            //{
            //    if (RptFrm.Text == frmInvoiceEditRPT.Text)
            //    {
            //        KryptonMessageBox.Show("Report Edit form already open. First close and then proceed.", "Create invoice report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}

            if (Program.ofrmMain.IsFormAlreadyOpen((new frmInvoiceEditRPT()).Text))
            {
                KryptonMessageBox.Show("Report Edit form already open. First close and then proceed.", "Create invoice report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int SelectedJobListRowIndex = grvJobList.CurrentRow.Index;


            //' *********************************** Check Condition Step 1 *********************************
            bool IsAdminInvoiceCheck = false;
            IsAdminInvoiceCheck = (bool)grvJobList.Rows[SelectedJobListRowIndex].Cells["AdminInvoice"].Value;
            //if (mdio.lblLogin.Text != "Admin LogOut" && IsAdminInvoiceCheck == true)
            if (!cGlobal.bIsAdminLoggedIn && IsAdminInvoiceCheck == true)
            {
                IsWarning = true;
                WarningMSG = "You must be login as Administrator";
                //KryptonMessageBox.Show("First Login as administrator.", "Create invoice report", MessageBoxButtons.OK, MessageBoxIcon.Information)
                //Exit Sub
            }

            //' *********************************** Check Condition Step 2 *********************************
            string NewLineText = string.Empty;
            bool IsClientNull = false;
            bool IsDescriptionNull = false;
            bool IsPMNull = false;
            bool IsAddressNull = false;
            bool IsContactsNull = false;
            bool IsEmailAddressNull = false;

            if (string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["Client#"].Value.ToString()))
            {
                IsClientNull = true;
            }
            if (string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["Description"].Value.ToString()))
            {
                IsDescriptionNull = true;
            }
            if (string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["cmbHandler"].Value.ToString()))
            {
                IsPMNull = true;
            }
            if (string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["Address"].Value.ToString()))
            {
                IsAddressNull = true;
            }
            if (string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["ContactsID"].Value.ToString()))
            {
                IsContactsNull = true;
            }
            if (string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["EmailAddress"].Value.ToString()))
            {
                IsEmailAddressNull = true;
            }

            if (IsClientNull == true || IsDescriptionNull == true || IsPMNull == true || IsAddressNull == true || IsContactsNull == true || IsEmailAddressNull == true)
            {

                if (string.IsNullOrEmpty(WarningMSG) == true)
                {
                    NewLineText = Environment.NewLine;
                }
                IsWarning = true;
                WarningMSG = WarningMSG + NewLineText + "You should be at least defined with those details (Client, Description, PM, Address, Contact, Email).";
            }

            //' *********************************** Check Condition Step 3 *********************************
            bool IsInvoiceTypeNull = false;
            bool IsItemRateNull = false;
            bool IsServRateNull = false;


            if ((string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["RateVersionId"].Value.ToString())) || (grvJobList.Rows[SelectedJobListRowIndex].Cells["RateVersionId"].Value.ToString() == "0"))
            {
                IsItemRateNull = true;
            }

            if (string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["TypicalInvoiceType"].Value.ToString()))
            {
                IsInvoiceTypeNull = true;
            }

            if (string.IsNullOrEmpty(grvJobList.Rows[SelectedJobListRowIndex].Cells["ServRate"].Value.ToString()))
            {
                IsServRateNull = true;
            }

            if (IsItemRateNull == true || IsInvoiceTypeNull == true || IsServRateNull == true)
            {
                if (string.IsNullOrEmpty(WarningMSG) == true)
                {
                    NewLineText = Environment.NewLine;
                }
                IsWarning = true;
                WarningMSG = WarningMSG + NewLineText + "You should be at least defined InvoiceType, ItemRate and ServRate.";
            }

            //' *********************************** Check Condition Step 4 *************************************
            bool IsMathchFourthCase = false;

            if (grvNotesCommunication.Rows.Count > 0)
            {
                string status = null;
                string Billstatus = null;
                foreach (DataGridViewRow row in grvNotesCommunication.Rows)
                {
                    status = row.Cells["cmbStatus"].Value.ToString();
                    Billstatus = row.Cells["cmbBillState"].Value.ToString();

                    if (status == "Ignored" && Billstatus == "Not Invoiced")
                    {
                        IsMathchFourthCase = true;
                        break;
                    }
                }
            }
            if (IsMathchFourthCase != true && grvPermitsRequiredInspection.Rows.Count > 0)
            {
                string status = null;
                string Billstatus = null;
                foreach (DataGridViewRow row in grvPermitsRequiredInspection.Rows)
                {
                    status = row.Cells["cmbStatus"].Value.ToString();
                    Billstatus = row.Cells["cmbBillState"].Value.ToString();

                    if (status == "Ignored" && Billstatus == "Not Invoiced")
                    {
                        IsMathchFourthCase = true;
                        break;
                    }
                }
            }

            if (IsMathchFourthCase == true)
            {
                IsWarning = true;
                WarningMSG = WarningMSG + NewLineText + "Should not be Status = 'Ignored' and Billstatus = 'Not Invoiced'";
            }

            //' *********************************** Show Warning message box based on Checked 4 Condition *********************************
            if (IsWarning == true && !string.IsNullOrEmpty(WarningMSG))
            {
                WarningMSG = WarningMSG + Environment.NewLine + Environment.NewLine + "Press 'OK' to continue or 'CANCEL' to abort stop the process.";
                if (KryptonMessageBox.Show(WarningMSG, "Create invoice report", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                {
                    return;
                }
            }

            Program.GetJobID = selectedJobListID;
            //JobAndTrackingMDI.CreateFromandtab(RptInvoiceView.Instance)
            //Dim Query As String = "SELECT JobTracking.TrackSubID, MasterTrackSubItem.TrackSubName,MasterTrackSubItem.nRate FROM  JobList INNER JOIN  JobTracking ON JobList.JobListID = JobTracking.JobListID LEFT OUTER JOIN MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id Where joblist.JobListID=" + selectedJobListID.ToString + " AND JobTracking.BillState='Not Invoiced' AND JobTracking.Status<>'Pending' AND (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)"
            //Check item has Not Invoice Item,Time and Expenses
            //Dim Query As String = "SELECT DISTINCT JobList.JobListID,JobTracking.JobTrackingId,tt.TimeSheetId,te.TimeSheetExpencesId " & _
            //" FROM  JobList LEFT JOIN JobList j ON JobList.JobListID=j.JobListID " & _
            //" LEFT OUTER JOIN  JobTracking ON j.JobListID = JobTracking.JobListID  AND JobTracking.BillState='Not Invoiced' AND JobTracking.Status<>'Pending' AND (JobTracking.IsDelete=0 or JobTracking.IsDelete is null) " & _
            //" LEFT OUTER JOIN TS_Time tt ON j.JobListID=tt.JobListID AND tt.BillState='Not Invoice' " & _
            //" LEFT OUTER JOIN TS_Expences te ON j.JobListID=te.JobListID AND te.BillState='Not Invoice' " & _
            //" WHERE j.JobListID=" & selectedJobListID & " AND (JobTracking.JobTrackingId IS NOT NULL OR tt.TimeSheetId IS NOT NULL OR te.TimeSheetExpencesId IS NOT NULL)"

            string Query = "SELECT count(*) as Count FROM  JobList LEFT JOIN JobList j ON JobList.JobListID=j.JobListID LEFT OUTER JOIN  JobTracking ON j.JobListID = JobTracking.JobListID  AND JobTracking.BillState='Not Invoiced' AND JobTracking.Status<>'Pending' AND (JobTracking.IsDelete=0 or JobTracking.IsDelete is null) " + " LEFT OUTER JOIN TS_Time tt ON j.JobListID=tt.JobListID AND tt.BillState='Not Invoice' " + " LEFT OUTER JOIN TS_Expences te ON j.JobListID=te.JobListID AND te.BillState='Not Invoice' " + " WHERE j.JobListID=" + selectedJobListID + " AND (JobTracking.JobTrackingId IS NOT NULL OR tt.TimeSheetId IS NOT NULL OR te.TimeSheetExpencesId IS NOT NULL)";
            
            
            int RecordCount = StMethod.GetSingleInt(Query);
            RecordCount = 0;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                RecordCount = StMethod.GetSingleIntNew(Query);
            }
            else
            {
                RecordCount = StMethod.GetSingleInt(Query);
            }



            ////using (EFDbContext db = new EFDbContext())
            ////{
            ////    RecordCount = db.Database.SqlQuery<int>(Query).FirstOrDefault();
            ////}


            //if (DT.Rows.Count > 0)
            //{
            //    RecordCount = (int)Convert.ToInt64(DT.Rows[0]["Count"].ToString());
            //}

            if (RecordCount > 0)
            {
                Program.getRptStatus = 'N';
                Program.getRptStatus = 'N';
                Program.ofrmMain.CreateFromandtab(new frmInvoiceEditRPT());
            }
            else
            {
                KryptonMessageBox.Show("Select job number not have sufficient item to create invoice! Or Please check item should have Not pending or Not invoice.", "Create invoice report", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        ///   checking remain above method
        ///   

        private void btnSendMailPending_Click(object sender, EventArgs e)
        {
            //var count = StMethod.GetSingleInt("SELECT Count(JobTrackingID) as count FROM  JobTracking WHERE Track IN(SELECT TrackName FROM MasterTrackSet WHERE TrackSet='PreRequirements') AND Status='Pending' AND JoblistID=" + selectedJobListID);

            var count = StMethod.GetSingleInt("SELECT Count(JobTrackingID) as count FROM  JobTracking WHERE Track IN(SELECT TrackName FROM MasterTrackSet WHERE TrackSet='PreRequirements') AND Status='Pending' AND JoblistID=" + selectedJobListID);
            count = 0;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                count = StMethod.GetSingleIntNew("SELECT Count(JobTrackingID) as count FROM  JobTracking WHERE Track IN(SELECT TrackName FROM MasterTrackSet WHERE TrackSet='PreRequirements') AND Status='Pending' AND JoblistID=" + selectedJobListID);
            }
            else
            {
                count = StMethod.GetSingleInt("SELECT Count(JobTrackingID) as count FROM  JobTracking WHERE Track IN(SELECT TrackName FROM MasterTrackSet WHERE TrackSet='PreRequirements') AND Status='Pending' AND JoblistID=" + selectedJobListID);
            }

            if (count > 0)
            {
                Program.GetJobID = selectedJobListID;
                Program.ofrmMain.CreateFromandtab(new PendingItemEmail());
            }
            else
            {
                if (KryptonMessageBox.Show("Select Job not have a pending item. You want proceed next.", "Pending Email Reminder", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Program.GetJobID = selectedJobListID;
                    Program.ofrmMain.CreateFromandtab(new PendingItemEmail());
                }
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            Program.CallEmailRemFrm = true;

            //Dim FrmImport As New ImportExcelInvoiceDue
            //FrmImport.Show()
            try
            {
                DataTable ColorDT = new DataTable();
                Int32 aging = 0;
                DataTable dtInvoice = new DataTable();


                //ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString());

                if(string.IsNullOrEmpty(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString()))
                { 

                }
                else
                {
                    //ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString());

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        ColorDT = StMethod.GetListDTNew<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString());

                    }
                    else
                    {
                        ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                    }

                }


                Program.GetJobID = selectedJobListID;
                //dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");

                if (string.IsNullOrEmpty(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString()))
                {

                }
                else
                {
                    //dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        dtInvoice = StMethod.GetListDTNew<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");
                    }
                    else
                    {
                        dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");
                    }
                }


                if (dtInvoice.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(dtInvoice.Rows[0]["Aging"].ToString()))
                    {
                        if (KryptonMessageBox.Show("Select Job Number not have due invoice! you want to continue.", "Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Program.GetJobID = selectedJobListID;
                            Program.ofrmMain.CreateFromandtab(new frmTrafficEmail());
                        }
                        else
                        {
                            return;
                        }
                    }
                    aging = Convert.ToInt32(dtInvoice.Rows[0]["Aging"].ToString());
                    if (aging >= 15)
                    {
                        Program.GetColorID = Convert.ToInt64(ColorDT.Rows[0][GetColumnName(aging)]);
                        ////////if (aging >= 15 && aging < 30)
                        ////////{
                        ////////    Program.GetColorID = ColorDT.Rows[0]["Age15Action"].ToString();
                        ////////}
                        ////////if (aging >= 30 && aging < 45)
                        ////////{
                        ////////    Program.GetColorID = ColorDT.Rows[0]["Age30Action"].ToString();
                        ////////}
                        ////////if (aging >= 45 && aging < 60)
                        ////////{
                        ////////    Program.GetColorID = ColorDT.Rows[0]["Age45Action"].ToString();
                        ////////}
                        ////////if (aging >= 60 && aging < 75)
                        ////////{
                        ////////    Program.GetColorID = ColorDT.Rows[0]["Age60Action"].ToString();
                        ////////}
                        ////////if (aging >= 75 && aging < 90)
                        ////////{
                        ////////    Program.GetColorID = ColorDT.Rows[0]["Age75Action"].ToString();
                        ////////}
                        ////////if (aging >= 90 && aging < 105)
                        ////////{
                        ////////    Program.GetColorID = ColorDT.Rows[0]["Age90Action"].ToString();
                        ////////}
                        ////////if (aging >= 105)
                        ////////{
                        ////////    Program.GetColorID = ColorDT.Rows[0]["Age105Action"].ToString();
                        ////////}

                        Program.GetJobID = selectedJobListID;
                        Program.ofrmMain.CreateFromandtab(new frmTrafficEmail());

                    }
                    else
                    {
                        Program.GetColorID = 0;
                        if (KryptonMessageBox.Show("Select Job Number not have 15 days old due invoice! you want to continue.", "Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            Program.GetJobID = selectedJobListID;
                            Program.ofrmMain.CreateFromandtab(new frmTrafficEmail());
                        }
                    }
                }
                else
                {
                    KryptonMessageBox.Show("No due invoice found", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                ImportExcelInvoiceDue invoiceDue = new ImportExcelInvoiceDue();
                bool bTracker = false;
                foreach (Form frm in Application.OpenForms)
                {
                    if (frm.Text == invoiceDue.Text)
                    {
                        frm.Close();
                        invoiceDue.Show();
                        bTracker = true;
                    }
                }
                if (!bTracker)
                    if (invoiceDue != null)
                    {
                        invoiceDue.Dispose();
                        invoiceDue = null;
                    }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateInvoiceDue_Click(System.Object sender, System.EventArgs e)
        {
            //Dim UpdateAgingFrm As New ImportExcelInvoiceDue
            // UpdateAgingFrm.MdiParent = mdio
            //frm.MdiParent = Me

            //UpdateAgingFrm.ShowDialog()
            Program.ofrmMain.CreateFromandtab(new ImportExcelInvoiceDue());
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // Get All manager main grid data as a Datatable
            DataTable ManagerMainGrid = GetManagerData();
            try
            {

            

            //Export start
            if (ManagerMainGrid.Rows.Count > 0)
            {
                ProgressBar1.Minimum = 0;
                ProgressBar1.Maximum = ManagerMainGrid.Rows.Count;

                //Show popup for confrim 
                SaveFileDialog Export = new SaveFileDialog();
                //Export.Filter = "Excel Format|*.xlsx";
                Export.Filter = "Excel Format|*.xls";
                Export.Title = "Job Status Manager";
                //'Export.InitialDirectory = "N:"
                if (Export.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                //-----------------------------------------------
                //If user want to contiune then file export with Name 
                string FullFilePath = Export.FileName;
                string filename = Path.GetFileName(Export.FileName);
                string filePath = Export.FileName;

                //XSSFWorkbook workBook = new XSSFWorkbook();
                HSSFWorkbook workBook = new HSSFWorkbook();
                
                ISheet sheet1 = workBook.CreateSheet(filename);


                //Progress bar visiible
                ProgressBar1.Visible = true;
                label11.Visible = true;

                //--------------------------------------------------------
                //sheet cell Formatting
                //--------------------------------------------------------

                //XSSFFont myFont = (XSSFFont)workBook.CreateFont();

                HSSFFont myFont = (HSSFFont)workBook.CreateFont();
                myFont.FontHeightInPoints = 11;
                myFont.FontName = "Tahoma";
                myFont.IsBold = true;


                //XSSFCellStyle borderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();
                HSSFCellStyle borderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();

                borderedCellStyle.SetFont(myFont);

                borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;

                Int32 Sheetrowindex = 0;
                int percent = 0;

                for (int ManagerRowindex = 1; ManagerRowindex <= ManagerMainGrid.Rows.Count; ManagerRowindex++)
                {
                    if (ProgressBar1.Value <= ManagerMainGrid.Rows.Count)
                    {
                        createManagerRows(ManagerMainGrid, borderedCellStyle, (ManagerRowindex - 1), ref Sheetrowindex, ref sheet1);
                    }
                    percent = (ProgressBar1.Value / ProgressBar1.Maximum) * 100;
                    label11.Text = percent + "%" + "Completed";
                    label11.Refresh();
                    ProgressBar1.Value = ProgressBar1.Value + 1;
                    Sheetrowindex = Sheetrowindex + 1;
                }

                //Auto sized all the affected columns
                int lastColumNum = sheet1.GetRow(0).LastCellNum;
                for (int i = 0; i <= lastColumNum; i++)
                {
                    sheet1.AutoSizeColumn(i);
                    GC.Collect();
                }

                if (sheet1.PhysicalNumberOfRows > 0)
                {
                    IRow headerRow = sheet1.GetRow(0);
                    //headerRow.Height =100;
                    for (int i = 0, l = headerRow.LastCellNum; i < l; i++)
                    {
                        sheet1.AutoSizeColumn(i);
                        GC.Collect();
                    }
                }


                //export to excel 
                var fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //Dim fs = New FileStream(filename, IO.FileMode.OpenOrCreate, FileAccess.ReadWrite)
                workBook.Write(fsd);
                workBook.Close();
                fsd.Close();
                MessageBox.Show("Export Successfully ", Export.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = false;
                label11.Visible = false;
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion       

        #region Functions & Methods
        private void ApplyUserDefinedSetting()
        {
            try
            {

                XmlDocument myDoc = new XmlDocument();
                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir2 = dir2 + "\\JobTracker";
                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (Properties.Settings.Default.timeSheetLoginName.ToString() == myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText)
                {
                    int selation = 0;
                    int TrueCondtion = 0;
                    string SelectedSetting = "";
                    bool ApplyTrue = false;

                    for (int value = 1; value <= 6; value++)
                    {

                        if (value == 1)
                        {
                            SelectedSetting = "UserSetting1";
                        }
                        else if (value == 2)
                        {
                            SelectedSetting = "UserSetting2";
                        }
                        else if (value == 3)
                        {
                            SelectedSetting = "UserSetting3";
                        }
                        else if (value == 4)
                        {
                            SelectedSetting = "UserSetting4";
                        }
                        else if (value == 5)
                        {
                            SelectedSetting = "UserSetting5";
                        }
                        else if (value == 6)
                        {
                            SelectedSetting = "UserSetting6";
                        }

                        XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" + SelectedSetting.ToString() + "/Selection");
                        if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" + SelectedSetting.ToString() + "/Apply").InnerText == "Yes")
                        {
                            selation = root.ChildNodes.Count;
                            TrueCondtion = 0;
                            foreach (XmlNode childNode in root.ChildNodes)
                            {

                                if (childNode.Name.ToString() == "TM")
                                {
                                    if (childNode.InnerText == cbxSearchTm.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "TMPending")
                                {
                                    if (childNode.InnerText == cmbTMWithPending.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Comments")
                                {
                                    if (childNode.InnerText == txtCommentsPreRequire.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Client")
                                {
                                    if (childNode.InnerText == txtJobListclient.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Job")
                                {
                                    if (childNode.InnerText == txtJobListJobID.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "PM")
                                {
                                    if (childNode.InnerText == cbxJobListPM.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "PMrv")
                                {
                                    if (childNode.InnerText == cbxJobListPMrv.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Pending")
                                {
                                    if ((childNode.InnerText == "True") && (chkShowOnlyPending.Checked == true))
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "NotPending")
                                {
                                    if ((childNode.InnerText == "True") && (chkNotInvoiceJob.Checked == true))
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Address")
                                {
                                    if (childNode.InnerText == txtJobListAddress.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Town")
                                {
                                    if (childNode.InnerText == txtTown.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "ClientText")
                                {
                                    if (childNode.InnerText == txtJoblistClienttext.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Description")
                                {
                                    if (childNode.InnerText == txtJobListSearchDescription.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Track")
                                {
                                    if (childNode.InnerText == CmbPreRequireTrack.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "TrackSub")
                                {
                                    if (childNode.InnerText == cmbTrackSubPreRequire.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "Status")
                                {
                                    if (childNode.InnerText == cmbStatusPreRequire.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                                if (childNode.Name.ToString() == "BillStatus")
                                {
                                    if (childNode.InnerText == cmbBillStatePermit.Text.Trim())
                                    {
                                        TrueCondtion = TrueCondtion + 1;
                                    }
                                }

                            }

                            if ((selation > 0) && (selation == TrueCondtion))
                            {
                                if (ApplyTrue == false)
                                {
                                    ApplyTrue = true;
                                }
                            }


                        }
                        else
                        {
                            //******** User Setting Not Apply  *****
                        }


                    }

                    if (ApplyTrue == true)
                    {

                        if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Prerequired").InnerText == "True")
                        {
                            chkPreRequirment.Checked = true;
                        }
                        else
                        {
                            chkPreRequirment.Checked = false;
                        }

                        if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Permits").InnerText == "True")
                        {
                            chkPermits.Checked = true;
                        }
                        else
                        {
                            chkPermits.Checked = false;
                        }

                        if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Notes").InnerText == "True")
                        {
                            chkNotes.Checked = true;
                        }
                        else
                        {
                            chkNotes.Checked = false;
                        }
                    }
                    else
                    {
                        chkPreRequirment.Checked = false;
                        chkPermits.Checked = true;
                        chkNotes.Checked = true;
                    }
                }
                else
                {
                    //*/****** Invalid User for User Defined Setting  ****
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "FillNotesGridCmb", ex.Message);
            }
        }
        private void FillNotesGridCmb(int colmnIndex, int roIndex)
        {
            cmbTCTackName = new DataGridViewComboBoxCell();
            try
            {
                //var data = repo.GetTrackSubItem(grvNotesCommunication.Rows[roIndex].Cells["cmbTrack"].Value.ToString().Trim());

                var data = repo.GetTrackSubItem(grvNotesCommunication.Rows[roIndex].Cells["cmbTrack"].Value.ToString().Trim());
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    data = repo2.GetTrackSubItemNew(grvNotesCommunication.Rows[roIndex].Cells["cmbTrack"].Value.ToString().Trim());
                }
                else
                {
                    data = repo.GetTrackSubItem(grvNotesCommunication.Rows[roIndex].Cells["cmbTrack"].Value.ToString().Trim());
                }


                cmbTCTackName.DataSource = data;
                cmbTCTackName.DisplayMember = "TrackSubName"; //data.Select(x => x.TrackSubName).FirstOrDefault().ToString();
                grvNotesCommunication[5, roIndex] = cmbTCTackName;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "FillNotesGridCmb", ex.Message);
            }
        }

        private void FillPermitGridTrackSubCmb(int roIndex)
        {
            try
            {
                cmbTCTackName = new DataGridViewComboBoxCell();

                //var data = repo.GetTrackSubItem(grvPermitsRequiredInspection.Rows[roIndex].Cells["cmbTrack"].Value.ToString().Trim());
                var data = repo.GetTrackSubItem(grvPermitsRequiredInspection.Rows[roIndex].Cells["cmbTrack"].Value.ToString().Trim());
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {                    
                    data = repo2.GetTrackSubItemNew(grvPermitsRequiredInspection.Rows[roIndex].Cells["cmbTrack"].Value.ToString().Trim());
                }
                else
                {
                    data = repo.GetTrackSubItem(grvPermitsRequiredInspection.Rows[roIndex].Cells["cmbTrack"].Value.ToString().Trim());
                }

                cmbTCTackName.DataSource = data;
                cmbTCTackName.DisplayMember = "TrackSubName";
                grvPermitsRequiredInspection[5, roIndex] = cmbTCTackName;
            }
            catch (Exception ex)
            {
            }
        }

        private void FillPreRequireGridTrackSubCmb(int roIndex)
        {
            cmbTCTackName = new DataGridViewComboBoxCell();
            try
            {
                var data = repo.GetTrackSubItem(grvPreRequirments.Rows[roIndex].Cells["Track"].Value.ToString().Trim());
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    data = repo2.GetTrackSubItemNew(grvPreRequirments.Rows[roIndex].Cells["Track"].Value.ToString().Trim());
                }
                else
                {
                    data = repo.GetTrackSubItem(grvPreRequirments.Rows[roIndex].Cells["Track"].Value.ToString().Trim());
                }

                cmbTCTackName.DataSource = data;
                cmbTCTackName.DisplayMember = "TrackSubName";// data.Select(x => x.TrackSubName).FirstOrDefault().ToString();
                grvPreRequirments[5, roIndex] = cmbTCTackName;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "FillPreRequireGridTrackSubCmb", ex.Message);
            }
        }

        private void ApplyPageLoadSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();
                try
                {
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                    //MessageBox.Show("VESoftwareSetting.xml file not available in current folder", "Manager PageLoad Setting Error");
                }


                //MessageBox.Show("1");

                //*** Fill TM *****

                if (!string.IsNullOrEmpty(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TM"].InnerText))
                {
                    string query = "Select Count(Id) from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TM"].InnerText + "' and cGroup = 'TM'";
                    
                    
                    //if (StMethod.IsMastersExist(query))
                    //{
                    //    cbxSearchTm.SelectedIndex = cbxSearchTm.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TM"].InnerText.ToString());
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.IsMastersExistNew(query))
                        {
                            cbxSearchTm.SelectedIndex = cbxSearchTm.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TM"].InnerText.ToString());
                        }

                    }
                    else
                    {
                        if (StMethod.IsMastersExist(query))
                        {
                            cbxSearchTm.SelectedIndex = cbxSearchTm.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TM"].InnerText.ToString());
                        }

                    }



                }
                else
                {
                    cbxSearchTm.SelectedIndex = -1;
                }

               
                  
                 

                //MessageBox.Show("2");

                //**** Fill TM Pending ''''

                if (!string.IsNullOrEmpty(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TMPending"].InnerText))
                {

                    //string query = "select * from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TMPending"].InnerText + "' and cGroup = 'TM'";

                    string query = "select Count(Id) from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TMPending"].InnerText + "' and cGroup = 'TM'";


                    //if (StMethod.IsMastersExist(query))
                    //{
                    //    cmbTMWithPending.SelectedIndex = cmbTMWithPending.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TMPending"].InnerText.ToString());
                    //    //cmbTMWithPending.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("TMPending").InnerText
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.IsMastersExistNew(query))
                        {
                            cmbTMWithPending.SelectedIndex = cmbTMWithPending.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TMPending"].InnerText.ToString());
                            //cmbTMWithPending.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("TMPending").InnerText
                        }

                    }
                    else
                    {
                        if (StMethod.IsMastersExist(query))
                        {
                            cmbTMWithPending.SelectedIndex = cmbTMWithPending.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TMPending"].InnerText.ToString());
                            //cmbTMWithPending.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("TMPending").InnerText
                        }

                    }

                }
                else
                {
                    cmbTMWithPending.SelectedIndex = -1;
                }

               
                 
               txtCommentsPreRequire.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Comments"].InnerText;

               txtJobListclient.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Client"].InnerText;
               txtJobListJobID.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Job"].InnerText;


               //MessageBox.Show("3");

               //*** Fill Pm Combo Box *****

               if (!string.IsNullOrEmpty(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PM"].InnerText))
               {
                   //string query = "select * from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PM"].InnerText + "' and cGroup = 'PM'";

                   string query = "select Count(Id)  from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PM"].InnerText + "' and cGroup = 'PM'";

                   //if (StMethod.IsMastersExist(query))
                   //{
                   //    //cbxJobListPM.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("PM").InnerText
                   //    cbxJobListPM.SelectedIndex = cbxJobListPM.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PM"].InnerText.ToString());
                       
                   //    fillGridJobList();
                   //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.IsMastersExistNew(query))
                        {
                            //cbxJobListPM.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("PM").InnerText
                            cbxJobListPM.SelectedIndex = cbxJobListPM.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PM"].InnerText.ToString());

                            fillGridJobList();
                        }
                    }
                    else
                    {
                        if (StMethod.IsMastersExist(query))
                        {
                            //cbxJobListPM.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("PM").InnerText
                            cbxJobListPM.SelectedIndex = cbxJobListPM.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PM"].InnerText.ToString());

                            fillGridJobList();
                        }
                    }

                }
                else
               {

                   cbxJobListPM.SelectedIndex = -1;
               }


               //MessageBox.Show("4");

               //*** fill PMrv Combo Box *****

               if (!string.IsNullOrEmpty(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PMrv"].InnerText))
               {
                   //string query = "select * from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PMrv"].InnerText + "' and cGroup = 'PM'";

                   string query = "select  Count(Id) from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PMrv"].InnerText + "' and cGroup = 'PM'";


                   //if (StMethod.IsMastersExist(query))
                   //{
                   //    //cbxJobListPMrv.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("PMrv").InnerText
                   //    cbxJobListPMrv.SelectedIndex = cbxJobListPMrv.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PMrv"].InnerText.ToString());
                   //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.IsMastersExistNew(query))
                        {
                            //cbxJobListPMrv.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("PMrv").InnerText
                            cbxJobListPMrv.SelectedIndex = cbxJobListPMrv.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PMrv"].InnerText.ToString());
                        }

                    }
                    else
                    {

                        if (StMethod.IsMastersExist(query))
                        {
                            //cbxJobListPMrv.Text = myDoc("VESoftwareSetting")("PageLoad")("ManagerForm")("PMrv").InnerText
                            cbxJobListPMrv.SelectedIndex = cbxJobListPMrv.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PMrv"].InnerText.ToString());
                        }
                    }


                }
               else
               {
                   cbxJobListPMrv.SelectedIndex = -1;
               }


               //MessageBox.Show("5");

               if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Pending"].InnerText == "True")
               {
                   chkShowOnlyPending.Checked = true;
               }
               else
               {

               }

               //MessageBox.Show("6");

               if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["NotPending"].InnerText == "True")
               {
                   chkNotInvoiceJob.Checked = true;
               }
               else
               {

               }

               //MessageBox.Show("7");

               txtJobListAddress.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Address"].InnerText;
               txtTown.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Town"].InnerText;
               txtJoblistClienttext.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["ClientText"].InnerText;
               txtJobListSearchDescription.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Description"].InnerText;

               CmbPreRequireTrack.SelectedIndex = CmbPreRequireTrack.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Track"].InnerText.ToString());
               cmbTrackSubPreRequire.SelectedIndex = cmbTrackSubPreRequire.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TrackSub"].InnerText.ToString());
               cmbStatusPreRequire.SelectedIndex = cmbStatusPreRequire.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Status"].InnerText.ToString());
               cmbBillStatePermit.SelectedIndex = cmbBillStatePermit.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["BillStatus"].InnerText.ToString());


               //MessageBox.Show("8");

               if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PreRequirment"].InnerText == "True")
               {
                   chkPreRequirment.Checked = true;
               }
               else
               {
                   chkPreRequirment.Checked = false;
               }

               if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Permits"].InnerText == "True")
               {
                   chkPermits.Checked = true;
               }
               else
               {
                   chkPermits.Checked = false;
               }

               if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Notes"].InnerText == "True")
               {
                   chkNotes.Checked = true;
               }
               else
               {
                   chkNotes.Checked = false;
               }


                


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());

            }
        }
        private void Fillcombo()
        {
            //dt1 = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");

            //var dtListTm = StMethod.GetMasterItemTM();

            var dtListTm = StMethod.GetMasterItemTM();
            dtListTm = null;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtListTm = StMethod.GetMasterItemTMNew();
            }
            else
            {
                dtListTm = StMethod.GetMasterItemTM();
            }



            cmbTMWithPending.Items.Add("");
            cbxSearchTm.Items.Add("");

            foreach (var item in dtListTm)
            {
                cbxSearchTm.Items.Add(item.cTrack);
                cmbTMWithPending.Items.Add(item.cTrack);
            }
            dtListTm = null;
            //dt1 = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");


            //var dtListPm = StMethod.GetMasterItemPM();

            var dtListPm = StMethod.GetMasterItemPM();
            dtListPm = null;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtListPm = StMethod.GetMasterItemPMNew();
            }
            else
            {
                dtListPm = StMethod.GetMasterItemPM();
            }

            cbxJobListPM.Items.Add("");
            cbxJobListPMrv.Items.Add("");

            foreach (var item in dtListPm)
            {
                cbxJobListPM.Items.Add(item.cTrack);
                cbxJobListPMrv.Items.Add(item.cTrack);
            }
            dtListPm = null;
            //UserSetting()

            //dt1.Clear();
            //dt1 = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
            //for (int I = 0; I < dt1.Rows.Count; I++)
            //{
            //    cbxJobListPMrv.Items.Add(dt1.Rows[I]["cTrack"].ToString()); //Dropdown shifted to above forloop
            //}


            //'PreRequiremen


            //var dtTrack = StMethod.GetList<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ");

            var dtTrack = StMethod.GetList<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ");

            dtTrack = null;


            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtTrack = StMethod.GetListNew<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ");
            }
            else
            {
                dtTrack = StMethod.GetList<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ");
            }


            foreach (var item in dtTrack)
            {
                CmbPreRequireTrack.Items.Add(item);
            }

            //var dtStatus = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Status' ORDER BY cTrack ");

            var dtStatus = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Status' ORDER BY cTrack ");
            dtStatus = null;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                dtStatus = StMethod.GetListNew<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Status' ORDER BY cTrack ");                                
            }
            else
            {
                dtStatus = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Status' ORDER BY cTrack ");                
            }

            cmbStatusPreRequire.Items.Add("");
            foreach (var item in dtStatus)
            {
                cmbStatusPreRequire.Items.Add(item);
            }

            //*********
            //Permits


            //var dtBill = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");

            var dtBill = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
            dtBill = null;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                dtBill = StMethod.GetListNew<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");

            }
            else
            {
                dtBill = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
            }

            cmbBillStatePermit.Items.Add("");
            foreach (var item in dtBill)
            {
                cmbBillStatePermit.Items.Add(item);
                //cmbBillStateNotes.Items.Add(dt1.Rows[i).Item("cTrack").ToString)
            }

            //********
            //Notes

            cmbYear.Items.AddRange(GetYearList());
            cmbYear.SelectedIndex = 1;
        }

        private bool isDiable(string item)
        {
            try
            {
                //int num = repo.db.Database.SqlQuery<int>("select COUNT(*) from masteritem where cGroup='TM' and IsDisable=1 and cTrack='" + item + "'").FirstOrDefault();

                int num;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    num = repo2.db2.Database.SqlQuery<int>("select COUNT(*) from masteritem where cGroup='TM' and IsDisable=1 and cTrack='" + item + "'").FirstOrDefault();

                }
                else
                {
                    num = repo.db.Database.SqlQuery<int>("select COUNT(*) from masteritem where cGroup='TM' and IsDisable=1 and cTrack='" + item + "'").FirstOrDefault();

                }
                return num > 0;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "isDiable", ex.Message);
            }
            return false;
        }

        private object[] GetYearList()
        {
            int length = DateTime.Now.Year + 2 - 2001;
            object[] Years = Enumerable.Range(2001, length).OrderByDescending((e) => e).Select((i) => (object)i).ToArray();
            return Years;
        }

        private void fillGridJobList()
        {
            try
            {
                string queryString = "";


                //If Me.txtJobListJobID.Text <> "" Then queryString = queryString & " and JobList.JobNumber Like'%" & txtJobListJobID.Text & "%'"

                if (this.txtJobListJobID.Text != "")
                {
                    queryString = queryString + " and JobList.JobNumber Like'%" + txtJobListJobID.Text + "%'";
                }

                //If Me.txtJobListclient.Text <> "" Then queryString = queryString & " and CHARINDEX( ISNULL(NULLIF('" & txtJobListclient.Text & "',''),CompanyName),CompanyName)>0 "

                
                if (this.txtJobListclient.Text != "")
                {             
                    queryString = queryString + " and CHARINDEX( ISNULL(NULLIF('" + txtJobListclient.Text + "',''),CompanyName),CompanyName)>0 ";

                }

                
                //If Me.txtJobListAddress.Text <> "" Then queryString = queryString & " and JobList.Address Like'%" & txtJobListAddress.Text & "%'"

                if (this.txtJobListAddress.Text != "")
                {                    
                    queryString = queryString + " and JobList.Address Like'%" + txtJobListAddress.Text + "%'";
                }


                //If txtTown.Text <> "" Then queryString = queryString & " and JobList.Borough like'" & txtTown.Text & "%'"

                if (txtTown.Text != "")
                {                     
                    queryString = queryString + " and JobList.Borough like'" + txtTown.Text + "%'";
                }

                //If txtJoblistClienttext.Text <> "" Then queryString = queryString & " and JobList.Clienttext like'" & txtJoblistClienttext.Text & "%'"



                if (txtJoblistClienttext.Text != "")
                {
                    queryString = queryString + " and JobList.Clienttext like'" + txtJoblistClienttext.Text + "%'";
                }

                //If Me.txtJobListSearchDescription.Text <> "" Then queryString = queryString & " and JobList.Description like'%" & txtJobListSearchDescription.Text & "%'"

                if (this.txtJobListSearchDescription.Text != "")
                {

                    queryString = queryString + " and JobList.Description like'%" + txtJobListSearchDescription.Text + "%'";
                }



                //If Me.cbxJobListPM.SelectedItem <> "" Then queryString = queryString & " and Handler='" & cbxJobListPM.SelectedItem & "'"

                //cbxJobListPM

                //if (this.cbxJobListPM.SelectedIndex != -1)
                //{
                //    queryString = queryString + " and Handler='" + cbxJobListPM.SelectedItem + "'";
                //}


                if (this.cbxJobListPM.SelectedIndex == 0)
                {
                    
                }
                else
                {
                    queryString = queryString + " and Handler='" + cbxJobListPM.SelectedItem + "'";
                }




                //if (cbxJobListPM.SelectedItem.ToString() != "")
                //{
                //    queryString = queryString + " and Handler='" + cbxJobListPM.SelectedItem + "'";

                //}

                //if (this.cbxJobListPM.SelectedItem != "")
                //{
                //}

                //if (this.cbxJobListPM.SelectedItem.ToString() != "")
                //    queryString = queryString + " and Handler='" + cbxJobListPM.SelectedItem + "'";





                //If Me.cbxJobListPMrv.SelectedItem <> "" Then queryString = queryString & " and PMrv='" & cbxJobListPMrv.SelectedItem & "'"

                //if (this.cbxJobListPMrv.SelectedIndex != -1)
                //{
                //    queryString = queryString + " and PMrv='" + cbxJobListPMrv.SelectedItem + "'";                    
                //}


                if (this.cbxJobListPMrv.SelectedIndex == 0)
                {
                    
                }
                else
                {
                    queryString = queryString + " and PMrv='" + cbxJobListPMrv.SelectedItem + "'";
                }





                //if (this.cbxJobListPMrv.SelectedItem.ToString() != "")
                //    queryString = queryString + " and PMrv='" + cbxJobListPMrv.SelectedItem + "'";


                //If Me.cbxSearchTm.SelectedItem <> "" Then queryString = queryString & " and JobTracking.TaskHandler ='" & cbxSearchTm.SelectedItem & "'"

                //if (this.cbxSearchTm.SelectedIndex != -1)
                //{
                //    queryString = queryString + " and JobTracking.TaskHandler ='" + cbxSearchTm.SelectedItem + "'";
                //}


                if (this.cbxSearchTm.SelectedIndex == 0)
                {
                    
                }
                else
                {
                    queryString = queryString + " and JobTracking.TaskHandler ='" + cbxSearchTm.SelectedItem + "'";
                }



                //if (this.cbxSearchTm.SelectedItem.ToString() != "")
                //    queryString = queryString + " and JobTracking.Handler ='" + cbxSearchTm.SelectedItem + "'";

                //If chkShowOnlyPending.Checked = True Then queryString = queryString & "AND JobList.JobListID IN ( SELECT JobListID FROM JobTracking WHERE Status='Pending' AND (IsDelete=0 or IsDelete is null ) )" '(Old Query updated on Date-July 16,2012) and JobTracking.Status='Pending'"


                if (chkShowOnlyPending.Checked == true)
                    queryString = queryString + "AND JobList.JobListID IN ( SELECT JobListID FROM JobTracking WHERE Status='Pending' AND (IsDelete=0 or IsDelete is null ) )";

                /*
                If chkNotInvoiceJob.Checked = True Then

                               queryString = String.Format(queryString, " INNER JOIN JobTracking JT ON JobList.JobListId = JT.JobListId AND  (JT.IsDelete=0 or JT.IsDelete is null )")


                */

                if (chkNotInvoiceJob.Checked == true)
                {

                    //queryString = String.Format(queryString, " INNER JOIN JobTracking JT ON JobList.JobListId = JT.JobListId AND  (JT.IsDelete=0 or JT.IsDelete is null )");


                    //queryString = queryString + " AND ((JT.BillState ='Not Invoiced' AND JT.Status <> 'Pending' AND JobList.TypicalInvoiceType='Item' AND (JobList.IsDisable IS NULL OR JobList.ISDisable=0) AND (JobList.IsInvoiceHold IS NULL OR JobList.IsInvoiceHold=0)) ";


                    //queryString = queryString + " OR ((SELECT COUNT(*) FROM TS_Time WHERE JobListId=JobList.JobListId AND BillState='Not Invoice')> 0 AND JobList.TypicalInvoiceType='Time' AND (JobList.IsDisable IS NULL OR JobList.ISDisable=0) AND (JobList.IsInvoiceHold IS NULL OR JobList.IsInvoiceHold=0))";


                    //queryString = queryString + " OR ((SELECT COUNT(*) FROM TS_Expences WHERE JobListId=JobList.JobListId AND BillState='Not Invoice')> 0 AND (JobList.IsDisable IS NULL OR JobList.ISDisable=0) AND (JobList.IsInvoiceHold IS NULL OR JobList.IsInvoiceHold=0)))";



                    queryString = String.Format(queryString, " INNER JOIN JobTracking JT ON JobList.JobListId = JT.JobListId AND  (JT.IsDelete=0 or JT.IsDelete is null )");


                    queryString = queryString + " AND ((JobTracking.BillState ='Not Invoiced' AND JobTracking.Status <> 'Pending' AND JobList.TypicalInvoiceType='Item' AND (JobList.IsDisable IS NULL OR JobList.ISDisable=0) AND (JobList.IsInvoiceHold IS NULL OR JobList.IsInvoiceHold=0)) ";


                    queryString = queryString + " OR ((SELECT COUNT(*) FROM TS_Time WHERE JobListId=JobList.JobListId AND BillState='Not Invoice')> 0 AND JobList.TypicalInvoiceType='Time' AND (JobList.IsDisable IS NULL OR JobList.ISDisable=0) AND (JobList.IsInvoiceHold IS NULL OR JobList.IsInvoiceHold=0))";


                    queryString = queryString + " OR ((SELECT COUNT(*) FROM TS_Expences WHERE JobListId=JobList.JobListId AND BillState='Not Invoice')> 0 AND (JobList.IsDisable IS NULL OR JobList.ISDisable=0) AND (JobList.IsInvoiceHold IS NULL OR JobList.IsInvoiceHold=0)))";



                }
                else
                {                     
                    queryString = String.Format(queryString, "");
                }


            //    If chkShowDisabled.Checked = False Then
            //queryString = queryString & " AND (JobList.IsDisable = 0  OR JobList.IsDisable IS NULL)"
            //End If

                if (chkShowDisabled.Checked == false)
                { 
                    queryString = queryString + " AND (JobList.IsDisable = 0  OR JobList.IsDisable IS NULL)";
                }


                //    If chkInvoiceHold.Checked = True Then
                //     queryString = queryString & " AND (JobList.IsInvoiceHold = 1 )"
                //Else
                //    queryString = queryString & " AND (JobList.IsInvoiceHold = 0 )"
                //End If

                if (chkInvoiceHold.Checked == true)
                { 
                    queryString = queryString + " AND (JobList.IsInvoiceHold = 1 )";
                }
                else
                {
                    queryString = queryString + " AND (JobList.IsInvoiceHold = 0 )";
                }

            //    If txtCommentsPreRequire.Text.Trim<> String.Empty Then
            //    queryString = queryString & " AND JobList.JobListID IN (SELECT JobListID FROM JobTracking WHERE Comments like '%" & txtCommentsPreRequire.Text.Trim & "%' AND (IsDelete=0 or IsDelete is null ) )"
            //End If

                if (txtCommentsPreRequire.Text.Trim() != string.Empty)
                {                     
                    queryString = queryString + " AND JobList.JobListID IN (SELECT JobListID FROM JobTracking WHERE Comments like '%" + txtCommentsPreRequire.Text.Trim() + "%' AND (IsDelete=0 or IsDelete is null ) )";
                }

                //   If cmbTMWithPending.Text.Trim <> "" Then
                //queryString = queryString & " AND JobList.JobListID IN (SELECT JobListID FROM JobTracking WHERE Status='Pending' AND TaskHandler =  '" & cmbTMWithPending.Text.Trim & "' AND (IsDelete=0 or IsDelete is null ))"
                //   End If

                if (cmbTMWithPending.Text.Trim() != "")
                { 
                    queryString = queryString + " AND JobList.JobListID IN (SELECT JobListID FROM JobTracking WHERE Status='Pending' AND TaskHandler =  '" + cmbTMWithPending.Text.Trim() + "' AND (IsDelete=0 or IsDelete is null ))";
                }


                //   If selectRecord_Joblist = True Then
                //queryString = queryString + "AND JobList.JobListID IN (SELECT TOP 100 JobListID FROM JobList WHERE IsDelete=0 or IsDelete is null order by JobListID DESC )"


              

                if (selectRecord_Joblist == true)
                    queryString = queryString + "AND JobList.JobListID IN (SELECT TOP 100 JobListID FROM JobList WHERE IsDelete=0 or IsDelete is null order by JobListID DESC )";


                //if (selectRecord_Joblist == true)
                //{                     
                //    queryString = queryString + "AND JobList.JobListID IN (SELECT TOP 100 JobListID FROM JobList WHERE IsDelete=0 or IsDelete is null order by JobListID DESC )";
                //}

                string startDate; string endDate; int index = 0;


                //If chkYear.Checked = True Then
                
                //    startDate = (System.DateTime.Now.AddYears(index)).Year.ToString + "-01-01 00:00:00.000"
                //    endDate = (System.DateTime.Now.AddYears(index + 1)).Year.ToString + "-01-01 00:00:00.000"
                    
                //    queryString = queryString & " AND  YEAR(JobList.DateAdded) = " & cmbYear.Text
                //End If




                if (chkYear.Checked == true)
                {

                    startDate = System.DateTime.Now.AddYears(index).Year.ToString() + "-01-01 00:00:00.000";
                    endDate = (System.DateTime.Now.AddYears(index + 1)).Year.ToString() + "-01-01 00:00:00.000";
                    queryString = queryString + " AND  YEAR(JobList.DateAdded) = " + cmbYear.Text;

                    // queryString = queryString & " AND  JobList.DateAdded > '" + startDate + "' AND  JobList.DateAdded < '" + endDate + "' "




                }
                queryString = queryString + "  order by JobList.JobListID  ";

                try
                {
                    // Attempt to load the dataset.
                    //dtJL = new Filldatatable(queryString);


                    //var TempDataAfterFilter = repo.GetManagerDataAfterFilter(queryString);


                    var TempDataAfterFilter = repo.GetManagerDataAfterFilter(queryString);
                    TempDataAfterFilter = null;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        TempDataAfterFilter = repo2.GetManagerDataAfterFilterNew(queryString);
                    }
                    else
                    {
                        TempDataAfterFilter = repo.GetManagerDataAfterFilter(queryString);
                    }


                    //string Sql = "SELECT  DISTINCT JobList.JobListID, JobList.JobNumber,JobList.Clienttext, Company.CompanyID, JobList.DateAdded, JobList.Description, JobList.Handler, JobList.Borough, JobList.Address, Contacts.FirstName + ' ' + Contacts.MiddleName + ' ' + Contacts.LastName AS Contacts, Contacts.EmailAddress, Contacts.ContactsID,Company.CompanyName,JobList.ACContacts,JobList.ACEmail,JobList.OwnerName,JobList.OwnerAddress, JobList.OwnerPhone,JobList.OwnerFax,Company.CompanyNo, JobList.PMrv, IsNull(JobList.IsDisable, 0) as IsDisable, IsNull(JobList.IsInvoiceHold, 0) as IsInvoiceHold," + " jd.InvoiceType AS TypicalInvoiceType, JobList.InvoiceClient, JobList.InvoiceContact,(Select dbo.ClientName(FirstName,MiddleName,LastName) FROM Contacts WHERE ContactsId LIKE jobList.InvoiceContact ) as InvoiceContactT ,JobList.InvoiceEmailAddress, JobList.InvoiceACContacts,(Select dbo.ClientName(FirstName,MiddleName,LastName) FROM Contacts WHERE ContactsId LIKE jobList.InvoiceACContacts ) as InvoiceACContactsT,JobList.InvoiceACEmail," + "CONVERT(INT,jd.TableVersionId) AS RateVersionId," + "jd.ServRate AS ServRate, IsNull(JobList.AdminInvoice, 0) as AdminInvoice FROM  JobList LEFT OUTER JOIN Contacts ON JobList.ContactsID = Contacts.ContactsID LEFT OUTER JOIN Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN JobTracking ON JobList.JobListID = JobTracking.JobListID INNER JOIN vwJobListDefaultValue jd ON JobList.JobListId=jd.JobListID WHERE (JobList.IsDelete=0 or JobList.IsDelete is null) ";

                    //Sql = Sql + queryString;
                    //Clipboard.SetText(Sql.ToString());


                    dtJL = ToDataTable(TempDataAfterFilter);
                    grvJobList.DataSource = dtJL;
                }
                catch (Exception eLoad)
                {
                    // Add your error handling code here.
                    // Display error message, if any.
                    KryptonMessageBox.Show(eLoad.Message, "Manager");
                }


            
                  
                


                // Grid Formatting
                {
                    var withBlock = grvJobList;
                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Width = 80;
                    
                    //withBlock.Columns["DateAdded"].Width = 1;
                    //withBlock.Columns["DateAdded"].HeaderText = "Added";
                    //withBlock.Columns["DateAdded"].Width = 80;

                    withBlock.Columns["Description"].HeaderText = "Description";
                    withBlock.Columns["Clienttext"].HeaderText = "Client Text";
                    withBlock.Columns["Clienttext"].Width = 180;
                    withBlock.Columns["Description"].Width = 200;
                    withBlock.Columns["Handler"].HeaderText = "PM";
                    withBlock.Columns["Handler"].Width = 40;
                    withBlock.Columns["Address"].Width = 150;
                    withBlock.Columns["CompanyID"].Width = 130;
                    withBlock.Columns["Borough"].Width = 90;
                    withBlock.Columns["Borough"].HeaderText = "Town";
                    withBlock.Columns["Contacts"].Width = 130;
                    // .Columns["Contacts").ReadOnly = True
                    withBlock.Columns["EmailAddress"].Width = 250;
                    withBlock.Columns["Handler"].Visible = false;
                    // .Columns["Borough").Visible = False
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["Contacts"].Visible = true;
                    withBlock.Columns["ContactsID"].Visible = false;
                    withBlock.Columns["CompanyName"].Visible = false;
                    withBlock.Columns["OwnerName"].HeaderText = "Owner Name";
                    withBlock.Columns["OwnerAddress"].HeaderText = "Owner Address";
                    withBlock.Columns["OwnerPhone"].HeaderText = "Owner Phone";
                    withBlock.Columns["OwnerFax"].HeaderText = "Owner Fax";
                    withBlock.Columns["ACContacts"].HeaderText = "AC Contacts";
                    withBlock.Columns["ACEmail"].HeaderText = "AC Email";
                    withBlock.Columns["CompanyNo"].Visible = false;
                    withBlock.Columns["PMrv"].HeaderText = "PMrv";
                    withBlock.Columns["PMrv"].Width = 40;
                    withBlock.Columns["PMrv"].Visible = false;

                    withBlock.Columns["IsDisable"].DisplayIndex = grvJobList.Columns.Count - 11;
                    withBlock.Columns["IsDisable"].HeaderText = "Disabled";
                    withBlock.Columns["IsDisable"].Width = 60;

                    withBlock.Columns["IsInvoiceHold"].DisplayIndex = grvJobList.Columns.Count - 10;
                    withBlock.Columns["IsInvoiceHold"].HeaderText = "Invoice Hold";
                    withBlock.Columns["IsInvoiceHold"].Width = 100;


                    withBlock.Columns["cmbInvoiceClient"].HeaderText = "InvoiceClient";
                    withBlock.Columns["cmbInvoiceClient"].DisplayIndex = grvJobList.Columns.Count - 9;
                    withBlock.Columns["InvoiceContact"].Width = 90;

                    withBlock.Columns["InvoiceContact"].Visible = false;
                    withBlock.Columns["InvoiceContactT"].HeaderText = "InvoiceContact";
                    withBlock.Columns["InvoiceContactT"].DisplayIndex = grvJobList.Columns.Count - 8;
                    withBlock.Columns["InvoiceEmailAddress"].Width = 90;
                    withBlock.Columns["InvoiceEmailAddress"].HeaderText = "InvoiceEmailAddress";
                    withBlock.Columns["InvoiceEmailAddress"].DisplayIndex = grvJobList.Columns.Count - 7;

                    withBlock.Columns["InvoiceACContacts"].Visible = false;
                    withBlock.Columns["InvoiceACContactsT"].Width = 90;
                    withBlock.Columns["InvoiceACContactsT"].HeaderText = "InvoiceACContacts";
                    withBlock.Columns["InvoiceACContactsT"].DisplayIndex = grvJobList.Columns.Count - 6;

                    withBlock.Columns["InvoiceACEmail"].Width = 90;
                    withBlock.Columns["InvoiceACEmail"].HeaderText = "InvoiceACEmail";
                    withBlock.Columns["InvoiceACEmail"].DisplayIndex = grvJobList.Columns.Count - 5;

                    withBlock.Columns["cmbTypicalInvoiceType"].DisplayIndex = grvJobList.Columns.Count - 4;
                    withBlock.Columns["TypicalInvoiceType"].HeaderText = "Invoice Type";
                    withBlock.Columns["TypicalInvoiceType"].Width = 100;
                    // Item rate column display index setup code will found it partial calss

                    withBlock.Columns["ServRate"].Width = 90;
                    withBlock.Columns["ServRate"].HeaderText = "Serv Rate";
                    withBlock.Columns["ServRate"].DisplayIndex = grvJobList.Columns.Count - 2;

                    withBlock.Columns["AdminInvoice"].Width = 100;
                    withBlock.Columns["AdminInvoice"].HeaderText = "Admin Inv.";
                    withBlock.Columns["AdminInvoice"].DisplayIndex = grvJobList.Columns.Count - 1;

                    //withBlock.Columns[5].DefaultCellStyle.Format = "d";

                    //dataGrid.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
                    //withBlock.Columns["DateAdded"].Width = 80;
                    //withBlock.Columns[5].DefaultCellStyle.Format = "MM-dd-yyyy hh:mm:ss tt";

                    //withBlock.Columns[5].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
                }


             



                 
            JobListGridRateVersionColumn(ref grvJobList);

            //Need to do after My.Settings will apply Todo
            if (Properties.Settings.Default.PretimeSheetLoginUserType == "Admin" | Properties.Settings.Default.timeSheetLoginUserType == "Admin")
            {
                UserType = "Admin";
                grvJobList.Columns["IsDisable"].Visible = true;
                grvJobList.Columns["IsInvoiceHold"].Visible = true;
            }
            else
            {
                grvJobList.Columns["IsDisable"].Visible = false;
                grvJobList.Columns["IsInvoiceHold"].Visible = false;
            }

            if (grvJobList.Rows.Count > 0)
            {
                grvJobList.CurrentCell = grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["Address"];
                grvJobList.Rows[grvJobList.Rows.Count - 1].Selected = true;

                selectedJobListID = Convert.ToInt32(grvJobList["JobListID", grvJobList.Rows.Count - 1].Value == DBNull.Value ? 0 : grvJobList["JobListID", grvJobList.Rows.Count - 1].Value);
                isDisabled = Convert.ToBoolean(grvJobList["IsDisable", grvJobList.Rows.Count - 1].Value == DBNull.Value ? 0 : grvJobList["IsDisable", grvJobList.Rows.Count - 1].Value);
                lblCompanyNo.Text = "Client No:- " + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyNo"].Value.ToString();
            }
            else
            {
                selectedJobListID = 0;
                isDisabled = false;
            }





           

             if (grvJobList.Rows.Count > 0)
                 grvJobList.CurrentCell = grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["Address"];
             if (grvJobList.Rows.Count > 0)
             {
                 selectedJobListID = Convert.ToInt32(grvJobList["JobListID", grvJobList.Rows.Count - 1].Value == DBNull.Value ? 0 : grvJobList["JobListID", grvJobList.Rows.Count - 1].Value);
                 isDisabled = Convert.ToBoolean(grvJobList["IsDisable", grvJobList.Rows.Count - 1].Value == DBNull.Value ? 0 : grvJobList["IsDisable", grvJobList.Rows.Count - 1].Value);
             }


              
             if (selectRecord_Joblist == false)
             {
                 
                    
                 FillGridPreRequirment();
                 FillGridPermitRequiredInspection();
                 FillGridNotesCommunication();
                 
                    if ((isDisabled))
                        disableJob(true);
                    else
                        disableJob(false);

                    if (grvJobList.Rows.Count > 0)
                    {
                        ChangeDirJobNumber(grvJobList.Rows.Count - 1);
                        ChangeTraficLight(grvJobList.Rows.Count - 1);
                    }                                                              
                }


             selectRecord_Joblist = false;

                

            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "fillGridJobList", ex.Message);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void disableJob(bool flag)
        {
            grvPreRequirments.ReadOnly = flag;
            btnInsertPreReq.Enabled = !flag;
            btnDeletePreReq.Enabled = !flag;
            btnCancelPreReq.Enabled = !flag;

            grvNotesCommunication.ReadOnly = flag;
            btnInsertNotes.Enabled = !flag;
            btndeleteNotes.Enabled = !flag;
            btnCancelNotes.Enabled = !flag;

            grvPermitsRequiredInspection.ReadOnly = flag;
            btnInsertPermit.Enabled = !flag;
            btnDeletePermit.Enabled = !flag;
            btnCancelPermit.Enabled = !flag;
        }

        private void JobListGridRateVersionColumn(ref DataGridView grd)
        {
            try
            {
                var withBlock = grd;
                if ((withBlock.Columns["cmbRateVersion"] == null))
                {
                    //DataAccessLayer DAL = new DataAccessLayer();
                    DataGridViewComboBoxColumn cmbVersionTable = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = cmbVersionTable;
                        // su


                        //var TempTableVersion = repo.GetTableVersion();
                        var TempTableVersion = repo.GetTableVersion();
                        TempTableVersion = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            TempTableVersion = repo.GetTableVersionNew();
                        }
                        else
                        {
                            TempTableVersion = repo.GetTableVersion();
                        }


                        //dt1 = new Filldatatable("select * from VersionTable  union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");
                        DataTable dt1 = ToDataTable(TempTableVersion);
                        withBlock1.DataSource = dt1;
                        withBlock1.DisplayMember = "TableVersionName";
                        withBlock1.ValueMember = "TableVersionId";
                        withBlock1.DataPropertyName = "RateVersionId";
                        withBlock1.HeaderText = "Item Rate";
                        withBlock1.Width = 120;
                        withBlock1.Name = "cmbRateVersion";
                    }
                    withBlock.Columns.Add(cmbVersionTable);
                    withBlock.Columns["cmbRateVersion"].DisplayIndex = grvJobList.Columns.Count - 2;
                }
                else
                    withBlock.Columns["cmbRateVersion"].DisplayIndex = grvJobList.Columns.Count - 2;
                withBlock.Columns["RateVersionId"].Visible = false;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "JobListGridRateVersionColumn", ex.Message);
            }
        }

        private void RateServTypeDefaultValueExistingForDataSet(DataSet ClientT, DataGridViewCellEventArgs e)
        {
            DataTable dt;
            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<RateServType>("SELECT TOP 1 RateVersionId,ServRate,TypicalInvoiceType FROM JOBLIST WHERE JobListID=" + grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value.ToString()).ToList();
            //    dt = Program.ToDataTable<RateServType>(data);
            //}

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<RateServType>("SELECT TOP 1 RateVersionId,ServRate,TypicalInvoiceType FROM JOBLIST WHERE JobListID=" + grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value.ToString()).ToList();
                    dt = Program.ToDataTable<RateServType>(data);
                }
            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<RateServType>("SELECT TOP 1 RateVersionId,ServRate,TypicalInvoiceType FROM JOBLIST WHERE JobListID=" + grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value.ToString()).ToList();
                    dt = Program.ToDataTable<RateServType>(data);
                }
            }

            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (string.IsNullOrEmpty(dr["RateVersionId"].ToString()) || dr["RateVersionId"].ToString() == "0")
                {


                    //grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(
                    //    ClientT.Tables[0].Rows[0]["TableVersionId"].ToString()) || ClientT.Tables[0].Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() :
                    //    ClientT.Tables[0].Rows[0]["TableVersionId"].ToString();

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(
                          ClientT.Tables[0].Rows[0]["TableVersionId"].ToString()) || ClientT.Tables[0].Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersionNew().ToString() :
                          ClientT.Tables[0].Rows[0]["TableVersionId"].ToString();
                    }
                    else
                    {
                        grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(
                          ClientT.Tables[0].Rows[0]["TableVersionId"].ToString()) || ClientT.Tables[0].Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() :
                          ClientT.Tables[0].Rows[0]["TableVersionId"].ToString();
                    }


                }
                if (string.IsNullOrEmpty(dr["TypicalInvoiceType"].ToString()))
                {
                    grvJobList.Rows[e.RowIndex].Cells["cmbTypicalInvoiceType"].Value = string.IsNullOrEmpty
                        (ClientT.Tables[0].Rows[0]["TypicalInvoiceType"].ToString()) ? "Item" :
                        ClientT.Tables[0].Rows[0]["TypicalInvoiceType"].ToString();
                }
                if (string.IsNullOrEmpty(dr["ServRate"].ToString()))
                {
                    grvJobList.Rows[e.RowIndex].Cells["ServRate"].Value = string.IsNullOrEmpty(
                        ClientT.Tables[0].Rows[0]["ServRate"].ToString()) ? "1" : ClientT.Tables[0].Rows[0]["ServRate"].ToString();
                }
                //Else
                //    RateSerTypeDefaultValue(ClientT, e)
            }
        }


        private void RateSerTypeDefaultValueForDataSet(DataSet ClientT, DataGridViewCellEventArgs e)
        {
            //grvJobList.Rows[e.RowIndex].Cells["cmbTypicalInvoiceType"].Value = string.IsNullOrEmpty(ClientT.Rows[0]["TypicalInvoiceType"].ToString()) ? "Item" : ClientT.Rows[0]["TypicalInvoiceType"].ToString();

            grvJobList.Rows[e.RowIndex].Cells["cmbTypicalInvoiceType"].Value = string.IsNullOrEmpty(
                ClientT.Tables[0].Rows[0]["TypicalInvoiceType"].ToString()) ? "Item" :
                ClientT.Tables[0].Rows[0]["TypicalInvoiceType"].ToString();

            string s21 = ClientT.Tables[0].Columns.Count.ToString();

            //grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty
            //    (ClientT.Tables[0].Rows[0]["TableVersionId"].ToString()) || ClientT.Tables[0].Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() : ClientT.Tables[0].Rows[0]["TableVersionId"].ToString();

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty
                  (ClientT.Tables[0].Rows[0]["TableVersionId"].ToString()) || ClientT.Tables[0].Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersionNew().ToString() : ClientT.Tables[0].Rows[0]["TableVersionId"].ToString();

            }
            else
            {
                grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty
                  (ClientT.Tables[0].Rows[0]["TableVersionId"].ToString()) || ClientT.Tables[0].Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() : ClientT.Tables[0].Rows[0]["TableVersionId"].ToString();

            }

            grvJobList.Rows[e.RowIndex].Cells["ServRate"].Value = string.IsNullOrEmpty(ClientT.Tables[0].Rows[0]["ServRate"].ToString()) ? "1" : ClientT.Tables[0].Rows[0]["ServRate"].ToString();

            //grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(ClientT.Rows[0]["TableVersionId"].ToString()) || ClientT.Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() : ClientT.Rows[0]["TableVersionId"].ToString();
            //grvJobList.Rows[e.RowIndex].Cells["ServRate"].Value = string.IsNullOrEmpty(ClientT.Rows[0]["ServRate"].ToString()) ? "1" : ClientT.Rows[0]["ServRate"].ToString();

        }


        //Mostly used when new records were inserted
        private void RateSerTypeDefaultValue(DataTable ClientT, DataGridViewCellEventArgs e)
        {

            
            grvJobList.Rows[e.RowIndex].Cells["cmbTypicalInvoiceType"].Value = string.IsNullOrEmpty(ClientT.Rows[0]["TypicalInvoiceType"].ToString()) ? "Item" : ClientT.Rows[0]["TypicalInvoiceType"].ToString();

            //grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(ClientT.Rows[0]["TableVersionId"].ToString()) || ClientT.Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() : ClientT.Rows[0]["TableVersionId"].ToString();

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(ClientT.Rows[0]["TableVersionId"].ToString()) || ClientT.Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersionNew().ToString() : ClientT.Rows[0]["TableVersionId"].ToString();


            }
            else
            {
                grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(ClientT.Rows[0]["TableVersionId"].ToString()) || ClientT.Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() : ClientT.Rows[0]["TableVersionId"].ToString();

            }

            grvJobList.Rows[e.RowIndex].Cells["ServRate"].Value = string.IsNullOrEmpty(ClientT.Rows[0]["ServRate"].ToString()) ? "1" : ClientT.Rows[0]["ServRate"].ToString();
        }

        //Use that function set default value for exting job list records
        private void RateServTypeDefaultValueExisting(DataTable ClientT, DataGridViewCellEventArgs e)
        {
            DataTable dt;
            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<RateServType>("SELECT TOP 1 RateVersionId,ServRate,TypicalInvoiceType FROM JOBLIST WHERE JobListID=" + grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value.ToString()).ToList();
            //    dt = Program.ToDataTable<RateServType>(data);
            //}

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<RateServType>("SELECT TOP 1 RateVersionId,ServRate,TypicalInvoiceType FROM JOBLIST WHERE JobListID=" + grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value.ToString()).ToList();
                    dt = Program.ToDataTable<RateServType>(data);
                }
            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<RateServType>("SELECT TOP 1 RateVersionId,ServRate,TypicalInvoiceType FROM JOBLIST WHERE JobListID=" + grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value.ToString()).ToList();
                    dt = Program.ToDataTable<RateServType>(data);
                }
            }


            if (dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                if (string.IsNullOrEmpty(dr["RateVersionId"].ToString()) || dr["RateVersionId"].ToString() == "0")
                {
                    /*rvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(ClientT.Rows[0]["TableVersionId"].ToString()) || ClientT.Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() : ClientT.Rows[0]["TableVersionId"].ToString();*/


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(ClientT.Rows[0]["TableVersionId"].ToString()) || ClientT.Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersionNew().ToString() : ClientT.Rows[0]["TableVersionId"].ToString();


                    }
                    else
                    {
                        grvJobList.Rows[e.RowIndex].Cells["cmbRateVersion"].Value = (string.IsNullOrEmpty(ClientT.Rows[0]["TableVersionId"].ToString()) || ClientT.Rows[0]["TableVersionId"].ToString() == "0") ? StMethod.GetDefaultTableVersion().ToString() : ClientT.Rows[0]["TableVersionId"].ToString();


                    }
                }
                if (string.IsNullOrEmpty(dr["TypicalInvoiceType"].ToString()))
                {
                    grvJobList.Rows[e.RowIndex].Cells["cmbTypicalInvoiceType"].Value = string.IsNullOrEmpty(ClientT.Rows[0]["TypicalInvoiceType"].ToString()) ? "Item" : ClientT.Rows[0]["TypicalInvoiceType"].ToString();
                }
                if (string.IsNullOrEmpty(dr["ServRate"].ToString()))
                {
                    grvJobList.Rows[e.RowIndex].Cells["ServRate"].Value = string.IsNullOrEmpty(ClientT.Rows[0]["ServRate"].ToString()) ? "1" : ClientT.Rows[0]["ServRate"].ToString();
                }
                //Else
                //    RateSerTypeDefaultValue(ClientT, e)
            }
        }

        private void FillGridTimeRevenueData()
        {
            try
            {
                Point newLocationpoint = new System.Drawing.Point()
                {
                    X = tblpnlJobtrackingGrid.Left + btnShowTimeData.Left + 5,
                    Y = tblpnlJobtrackingGrid.Top + btnShowTimeData.Top + 30
                };
                frmShowTimeData frmshowTimeData = new frmShowTimeData();
                ////////frmshowTimeData.mdio.MdiParent = this.MdiParent;

                if(frmshowTimeData.Visible == true)
                {

                    controlVisibility(false);
                }

                else
                {

                    //controlVisibility(true);
                }

                //if (frmshowTimeData.Visible = true)
                //{

                //    controlVisibility(true);
                //}

                //else
                //{
                //    controlVisibility(false);
                //}
                
                //controlVisibility(true);
                frmshowTimeData.Dock = DockStyle.Fill;
                // frmshowTimeData.JobNumber = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString()
                if (grvJobList.Rows.Count == 0)
                {
                    frmshowTimeData.JobListId = 0;
                    frmshowTimeData.JobNumber = "";
                }
                else
                {
                    frmshowTimeData.JobListId = Convert.ToInt32(grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobListId"].Value.ToString());
                    frmshowTimeData.JobNumber = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                }

                // frmshowTimeData.PM = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells[6].Value.ToString()
                frmshowTimeData.TopLevel = false;
                frmshowTimeData.Visible = true;

                pnlShowTimeSheetData.Location = newLocationpoint;
                pnlShowTimeSheetData.BringToFront();
                //pnlShowTimeDataColor.BackColor = mBodyColor

                pnlShowTimeSheetData.Controls.Add(frmshowTimeData);



                frmshowTimeData.fillgrdTimeSheetData();
                frmshowTimeData.FillcmbDistinctName();
                pnlShowTimeDataColor.BackColor = frmshowTimeData.VeCostColor;
                pnlShowTimeSheetData.AutoSize = true;
                pnlShowTimeSheetData.Refresh();
            }
            catch (Exception ex)
            { 
            
            }
        }

            private void FillGridNotesCommunication()
        {
            try
            {
                string queryString = " And JobTracking.JobListID=" + selectedJobListID;

                if (cbxSearchTm.Text.Trim() != "")
                    queryString = queryString + " AND JobTracking.TaskHandler= '" + cbxSearchTm.Text.Trim() + "'";

                if (CmbPreRequireTrack.Text.Trim() != "")
                    queryString = queryString + " AND JobTracking.Track= '" + CmbPreRequireTrack.Text.Trim() + "'";
                if (cmbTrackSubPreRequire.Text.Trim() != "")
                    queryString = queryString + " AND JobTracking.TrackSub= '" + cmbTrackSubPreRequire.Text.Trim() + "'";
                if (cmbStatusPreRequire.Text.Trim() != "")
                    queryString = queryString + " AND JobTracking.Status= '" + cmbStatusPreRequire.Text.Trim() + "'";
                if (cmbBillStatePermit.Text.Trim() != "")
                    queryString = queryString + " AND JobTracking.BillState= '" + cmbBillStatePermit.Text.ToString().Trim() + "'";
                if (txtCommentsPreRequire.Text.ToString().Trim() != "")
                    queryString = queryString + " AND JobTracking.Comments like '%" + txtCommentsPreRequire.Text.Trim() + "%'";
                if (cmbTMWithPending.Text.Trim() != "")
                    queryString = queryString + " AND (JobTracking.Status='Pending' AND JobTracking.TaskHandler=  '" + cmbTMWithPending.Text.Trim() + "' )";
                queryString = queryString + " order by JobTrackingID";


                try
                {
                    // Attempt to load the dataset.

                    //var TempNotesComunicationAfterFilter = repo.GetNotesComunicationDataAfterFilter(queryString);

                    var TempNotesComunicationAfterFilter = repo.GetNotesComunicationDataAfterFilter(queryString);
                    TempNotesComunicationAfterFilter = null;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        TempNotesComunicationAfterFilter = repo2.GetNotesComunicationDataAfterFilterNew(queryString);

                    }
                    else
                    {
                        TempNotesComunicationAfterFilter = repo.GetNotesComunicationDataAfterFilter(queryString);
                    }

                    dtNotes = ToDataTable(TempNotesComunicationAfterFilter);
                    grvNotesCommunication.DataSource = dtNotes;
                }

                catch (Exception eLoad)
                {
                    // Add your error handling code here.
                    // Display error message, if any.
                    KryptonMessageBox.Show(eLoad.Message, "Manager");
                }
                // Grid Formatting
                {
                    var withBlock = grvNotesCommunication;

                    // Set Column Property
                    withBlock.Columns["JobListID"].DataPropertyName = "JobListID";
                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Visible = false;
                    withBlock.Columns["Track"].Visible = false;
                    withBlock.Columns["AddDate"].Visible = true;
                    withBlock.Columns["AddDate"].Width = 90;
                    withBlock.Columns["AddDate"].HeaderText = "Added";
                    withBlock.Columns["NeedDate"].Visible = false;
                    withBlock.Columns["Obtained"].Visible = false;
                    withBlock.Columns["Obtained"].Width = 90;
                    withBlock.Columns["Expires"].Visible = false;
                    withBlock.Columns["Expires"].Width = 90;
                    withBlock.Columns["Status"].Visible = false;
                    withBlock.Columns["JobTrackingID"].Visible = false;
                    withBlock.Columns["TaskHandler"].HeaderText = "TM";
                    withBlock.Columns["TaskHandler"].Visible = false;
                    withBlock.Columns["Submitted"].Visible = false;
                    withBlock.Columns["BillState"].Visible = false;
                    withBlock.Columns["Comments"].HeaderText = "Comments";
                    withBlock.Columns["Comments"].Width = 520;
                    withBlock.Columns["InvOvr"].HeaderText = "Inv. Ovr.";
                    withBlock.Columns["InvOvr"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                    // .Columns["TrackSub").Visible = False
                    withBlock.Columns["TrackSub"].Width = 200;
                    withBlock.Columns["TrackSubID"].Visible = false;
                    withBlock.Columns["DeleteItemTimeService"].Visible = false;
                }

                btndeleteNotes.Enabled = true;
                btnInsertNotes.Text = "Insert";
                if (grvNotesCommunication.Rows.Count > 0)
                    grvNotesCommunication.CurrentCell = grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Cells["comments"];

                // Dim rows As IEnumerable(Of DataRow) = dtNotes.AsEnumerable()
                // Dim catchData As List(Of DataRow) = rows.Where(Function(d) d.Item("Status") = "Pending").ToList()
                int countRow = 0;
                foreach (DataRow dr in dtNotes.Rows)
                {
                    if (dr["Status"] == "Pending")
                        countRow = countRow + 1;
                }
                if (countRow > 0)
                    lblNotes.ForeColor = Color.Tomato;
                else
                    lblNotes.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "FillGridNotesCommunication", ex.Message);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillGridPermitRequiredInspection()
        {
            try
            {
                // DataAccessLayer DAL = new DataAccessLayer();

                string queryString = "";

                // If Me.chkShowOnlyPendingTrack.Checked Then queryString = queryString & " and JobTracking.Status ='Pending'"
                if (cbxSearchTm.Text.Trim() != "")
                    queryString = queryString + " AND JobTracking.TaskHandler= '" + cbxSearchTm.Text.Trim() + "'";
                if (CmbPreRequireTrack.Text.ToString() != "")
                    queryString = queryString + " AND JobTracking.Track='" + CmbPreRequireTrack.Text.ToString() + "'";
                if (cmbTrackSubPreRequire.Text.ToString() != "")
                    queryString = queryString + " AND JobTracking.TrackSub='" + cmbTrackSubPreRequire.Text.ToString() + "'";
                if (cmbStatusPreRequire.Text.ToString() != "")
                    queryString = queryString + " AND JobTracking.Status='" + cmbStatusPreRequire.Text.ToString() + "'";
                if (txtCommentsPreRequire.Text.Trim() != "")
                    queryString = queryString + "AND JobTracking.Comments like '%" + txtCommentsPreRequire.Text.Trim() + "%'";
                if (cmbBillStatePermit.Text.ToString() != "")
                    queryString = queryString + " AND JobTracking.BillState='" + cmbBillStatePermit.Text.ToString() + "'";
                if (cmbTMWithPending.Text.Trim() != "")
                    queryString = queryString + " AND (JobTracking.Status='Pending' AND JobTracking.TaskHandler=  '" + cmbTMWithPending.Text.Trim() + "' )";
                queryString = queryString + " order by JobTrackingID";

                try
                {
                    // Attempt to load the dataset.

                    //var TempPermitsRequiredAfterFilter = repo.GetPermitsRequirementDataAfterFilter(queryString, selectedJobListID);
                    var TempPermitsRequiredAfterFilter = repo.GetPermitsRequirementDataAfterFilter(queryString, selectedJobListID);
                    TempPermitsRequiredAfterFilter = null;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        TempPermitsRequiredAfterFilter = repo2.GetPermitsRequirementDataAfterFilterNew(queryString, selectedJobListID);
                    }
                    else
                    {
                        TempPermitsRequiredAfterFilter = repo.GetPermitsRequirementDataAfterFilter(queryString, selectedJobListID);
                    }

                    dtPermit = ToDataTable(TempPermitsRequiredAfterFilter);
                    grvPermitsRequiredInspection.DataSource = dtPermit;
                }
                catch (Exception eLoad)
                {
                    // Add your error handling code here.
                    // Display error message, if any.
                    KryptonMessageBox.Show(eLoad.Message, "Manager");
                }
                // Grid Formatting
                {
                    var withBlock = grvPermitsRequiredInspection;

                    // Set Column Property
                    withBlock.Columns["JobListID"].DataPropertyName = "JobListID";
                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Visible = false;
                    withBlock.Columns["Track"].Visible = false;
                    withBlock.Columns["AddDate"].Visible = true;
                    withBlock.Columns["AddDate"].Width = 90;
                    withBlock.Columns["AddDate"].HeaderText = "Added";
                    withBlock.Columns["NeedDate"].Visible = false;
                    withBlock.Columns["Obtained"].Visible = true;
                    withBlock.Columns["Obtained"].Width = 90;
                    withBlock.Columns["Expires"].Visible = true;
                    withBlock.Columns["Expires"].Width = 90;
                    // .Columns["FinalAction").HeaderText = "Final Action"
                    // .Columns["FinalAction").Visible = True
                    // .Columns["FinalAction").Width = 80
                    withBlock.Columns["Status"].Visible = false;
                    withBlock.Columns["JobTrackingID"].Visible = false;
                    withBlock.Columns["TaskHandler"].HeaderText = "TM";
                    withBlock.Columns["TaskHandler"].Visible = false;
                    withBlock.Columns["Submitted"].Visible = true;

                    withBlock.Columns["BillState"].Visible = false;
                    withBlock.Columns["Comments"].HeaderText = "Comments";
                    withBlock.Columns["Comments"].Width = 330;
                    withBlock.Columns["InvOvr"].HeaderText = "Inv. Ovr.";
                    withBlock.Columns["InvOvr"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                    // .Columns["TrackSub").Visible = False
                    withBlock.Columns["TrackSub"].Width = 200;
                    withBlock.Columns["TrackSubID"].Visible = false;
                }
                btnDeletePermit.Enabled = true;
                btnInsertPermit.Text = "Insert";
                if (grvPermitsRequiredInspection.Rows.Count > 0)
                    grvPermitsRequiredInspection.CurrentCell = grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Cells["comments"];
                // Dim rows As IEnumerable(Of DataRow) = dtPermit.AsEnumerable()
                // Dim catchData As List(Of DataRow) = rows.Where(Function(d) d.Item("Status") = "Pending").ToList()

                int countRow = 0;
                foreach (DataRow dr in dtPermit.Rows)
                {
                    if (dr["Status"] == "Pending")
                        countRow = countRow + 1;
                }
                if (countRow > 0)
                    lblPermit.ForeColor = Color.Tomato;
                else
                    lblPermit.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "FillGridPermitRequiredInspection", ex.Message);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlButtonVisible(Panel pnl, bool pnlreset)
        {
            foreach (Control ctrl in pnl.Controls)
            {
                if (ctrl is Button)
                {
                    if ((ctrl.Name != "btnAgingColor"))
                        ctrl.Visible = pnlreset;
                }
                if (ctrl is DataGridView)
                    ctrl.Visible = pnlreset;
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void SetColumns()
        {
            try
            {
                //var TempColumn = repo.ManagerGridSetColumn();

                var TempColumn = repo.ManagerGridSetColumn();
                TempColumn = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    TempColumn = repo2.ManagerGridSetColumnNewNew();
                    
                }
                else
                {
                    TempColumn = repo.ManagerGridSetColumn();                    
                }

                //string dbname = repo2.GetDatabaseName();
                //MessageBox.Show(dbname.ToString());

                

                

                DataTable dtJL = new DataTable();
                dtJL = ToDataTable(TempColumn);

                grvJobList.DataSource = dtJL;

                cbxClient.Name = "Client#";
                cbxClient.Width = 200;

                grvJobList.Columns.Insert(1, cbxClient);

                DataTable dt = new DataTable();

                //var TempCBlient = repo.GetcbxClient();

                var TempCBlient = repo.GetcbxClient();
                TempCBlient = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    TempCBlient = repo2.GetcbxClientNewNew();
                }
                else
                {
                    TempCBlient = repo.GetcbxClient();
                }


                dt = ToDataTable(TempCBlient);
                DataRow datarow = dt.NewRow();
                datarow["CompanyName"] = "";
                datarow["CompanyID"] = 0;
                dt.Rows.InsertAt(datarow, 0);
                cbxClient.DataSource = dt;
                cbxClient.DisplayMember = "CompanyName";
                cbxClient.ValueMember = "CompanyID";
                cbxClient.DataPropertyName = "CompanyID";
                DataTable _cmbIClientDT = dt.Copy();
                _cmbIClientDT.Rows[0]["CompanyName"] = "--Client--";
                _cmbIClientDT.Rows[0]["CompanyID"] = -99;
                cmbInvoiceClient = new DataGridViewComboBoxColumn() { DataSource = _cmbIClientDT, DisplayMember = "CompanyName", ValueMember = "CompanyID", DataPropertyName = "InvoiceClient", Name = "cmbInvoiceClient", HeaderText = "InvoiceClient" };
                grvJobList.Columns.Insert(grvJobList.Columns.Count - 1, cmbInvoiceClient);
                //EFDbContext cmbobj = new EFDbContext();
                {
                    var withBlock = grvJobList;

                    // Set Column Property
                    // With grvJobList

                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Width = 80;
                    withBlock.Columns["JobNumber"].DisplayIndex = 1;
                    withBlock.Columns["DateAdded"].Width = 80;
                    withBlock.Columns["DateAdded"].HeaderText = "Added";
                    withBlock.Columns["DateAdded"].DisplayIndex = 3;
                    withBlock.Columns["Description"].HeaderText = "Description";
                    withBlock.Columns["Description"].Width = 200;
                    withBlock.Columns["Description"].DisplayIndex = 4;
                    withBlock.Columns["Handler"].HeaderText = "PM";
                    withBlock.Columns["Handler"].Width = 40;
                    withBlock.Columns["Address"].Width = 150;
                    withBlock.Columns["Address"].DisplayIndex = 5;
                    withBlock.Columns["CompanyID"].Width = 130;
                    withBlock.Columns["Borough"].Width = 90;
                    withBlock.Columns["Borough"].HeaderText = "Town";
                    withBlock.Columns["Contacts"].Width = 130;
                    withBlock.Columns["Contacts"].DisplayIndex = 6;
                    withBlock.Columns["EmailAddress"].Width = 250;
                    withBlock.Columns["EmailAddress"].DisplayIndex = 10;
                    withBlock.Columns["Handler"].Visible = false;
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["Contacts"].Visible = true;
                    withBlock.Columns["ContactsID"].Visible = false;
                    withBlock.Columns["CompanyName"].Visible = false;
                    withBlock.Columns["OwnerName"].HeaderText = "Owner Name";
                    withBlock.Columns["OwnerAddress"].HeaderText = "Owner Address";
                    withBlock.Columns["OwnerPhone"].HeaderText = "Owner Phone";
                    withBlock.Columns["OwnerFax"].HeaderText = "Owner Fax";
                    withBlock.Columns["ACContacts"].HeaderText = "AC Contacts";
                    withBlock.Columns["ACEmail"].HeaderText = "AC Email";
                    withBlock.Columns["CompanyNo"].Visible = false;
                    withBlock.Columns["PMrv"].HeaderText = "PMrv";
                    withBlock.Columns["PMrv"].Width = 40;
                    withBlock.Columns["PMrv"].Visible = false;
                    withBlock.Columns["TypicalInvoiceType"].Width = 100;
                    withBlock.Columns["TypicalInvoiceType"].HeaderText = "Invoice Type";
                    withBlock.Columns["TypicalInvoiceType"].Visible = false;
                    withBlock.Columns["IsDisable"].DisplayIndex = grvJobList.Columns.Count - 3;
                    withBlock.Columns["IsDisable"].HeaderText = "Disabled";
                    withBlock.Columns["TypicalInvoiceType"].DisplayIndex = grvJobList.Columns.Count - 1;

                    withBlock.Columns["IsInvoiceHold"].DisplayIndex = grvJobList.Columns.Count - 1;
                    withBlock.Columns["IsInvoiceHold"].HeaderText = "Invoice Hold";
                    withBlock.Columns["InvoiceClient"].Visible = false;

                    DataGridViewComboBoxColumn colPM = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colPM;
                        DataTable dtPM = new DataTable();

                        //var TempColPM = repo.GetMasterItemPM();

                        var TempColPM = repo.GetMasterItemPM();
                        TempColPM = null;


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            TempColPM = repo2.GetMasterItemPMNew();
                        }
                        else
                        {
                            TempColPM = repo.GetMasterItemPM();
                        }


                        dtPM = ToDataTable(TempColPM);

                        withBlock1.DataSource = dtPM;
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 5;
                        withBlock1.HeaderText = "PM";
                        withBlock1.DataPropertyName = "Handler";
                        withBlock1.Width = 58;
                        withBlock1.Name = "cmbHandler";
                    }
                    withBlock.Columns.Add(colPM);


                    DataGridViewComboBoxColumn colPMrv = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colPMrv;
                        //withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        DataTable dtPM = new DataTable();

                        //var TempColPM = repo.GetMasterItemPM();
                        var TempColPM = repo.GetMasterItemPM();
                        TempColPM = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            TempColPM = repo2.GetMasterItemPMNew();
                        }
                        else
                        {
                            TempColPM = repo.GetMasterItemPM();
                        }


                        dtPM = ToDataTable(TempColPM);
                        withBlock1.DataSource = dtPM;
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.HeaderText = "PMrv";
                        withBlock1.DataPropertyName = "PMrv";
                        withBlock1.Width = 58;
                        withBlock1.Name = "cmbPMrv";
                    }
                    withBlock.Columns.Add(colPMrv);

                    DataGridViewComboBoxColumn colTypicalInvoiceType = new DataGridViewComboBoxColumn();
                    colTypicalInvoiceType.Items.Add("Time");
                    colTypicalInvoiceType.Items.Add("Item");
                    {
                        var withBlock1 = colTypicalInvoiceType;
                        withBlock1.DataPropertyName = "TypicalInvoiceType";
                        withBlock1.HeaderText = "Invoice Type";
                        withBlock1.Width = 100;
                        withBlock1.Name = "cmbTypicalInvoiceType";
                    }
                    withBlock.Columns.Add(colTypicalInvoiceType);
                }

                if (grvJobList.Rows.Count > 0)
                {
                    selectedJobListID = Convert.ToInt32(grvJobList.Rows[0].Cells["JobListID"].Value);
                    isDisabled = Convert.ToBoolean(grvJobList.Rows[0].Cells["IsDisable"].Value);
                    grvJobList.Rows[0].Selected = true;
                }
            }

            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "SetColumns", ex.Message);
            }
        }

        private void SetColumnPreRequirment()
        {
            try
            {
                try
                {
                    // Attempt to load the dataset.

                    //var TempPreColumn = repo.PreRequirementSetColumn();

                    var TempPreColumn = repo.PreRequirementSetColumn();
                    TempPreColumn = null;


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        //TempPreColumn = repo.PreRequirementSetColumnNew();
                        TempPreColumn = repo2.PreRequirementSetColumnNew();
                    }
                    else
                    {
                        TempPreColumn = repo.PreRequirementSetColumn();
                    }

                    dtPreReq = ToDataTable(TempPreColumn);
                    grvPreRequirments.DataSource = dtPreReq;
                }
                catch (Exception eLoad)
                {
                    // Add your error handling code here.
                    // Display error message, if any.
                    KryptonMessageBox.Show(eLoad.Message, "Manager");
                }

                {
                    var withBlock = grvPreRequirments;

                    // ComboTM'
                    DataGridViewComboBoxColumn colTM = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colTM;
                        DataTable colTmDT = new DataTable();

                        //var TempPreColTM = repo.GetMasterItemTM_D();
                        var TempPreColTM = repo.GetMasterItemTM_D();
                        TempPreColTM = null;


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            TempPreColTM = repo2.GetMasterItemTM_D_New();

                        }
                        else
                        {
                            TempPreColTM = repo.GetMasterItemTM_D();
                        }

                        colTmDT = ToDataTable(TempPreColTM);

                        //withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) AND (isDisable <> 1 or IsDisable is  null) ORDER BY cTrack ");
                        withBlock1.DataSource = colTmDT;
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 2;
                        withBlock1.HeaderText = "TM";
                        withBlock1.DataPropertyName = "TaskHandler";
                        withBlock1.Width = 65;
                        withBlock1.Name = "cmbTaskHandler";
                    }

                    withBlock.Columns.Add(colTM);


                    DataGridViewComboBoxColumn colTrack = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colTrack;
                        DataTable colTrackDT = new DataTable();

                        //var TempPrecolTrack = repo.GetPreRequirementcolTrack();
                        
                        var TempPrecolTrack = repo.GetPreRequirementcolTrack();


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            TempPrecolTrack = repo2.GetPreRequirementcolTrackNew();
                        }
                        else
                        {
                            TempPrecolTrack = repo.GetPreRequirementcolTrack();
                        }

                        colTrackDT = ToDataTable(TempPrecolTrack);
                        //withBlock1.DataSource = cmbobj.Filldatatable("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='PreRequirements'");
                        withBlock1.DataSource = colTrackDT;
                        withBlock1.DisplayMember = "Trackname";
                        withBlock1.DisplayIndex = 4;
                        withBlock1.HeaderText = "Track";
                        withBlock1.DataPropertyName = "Track";
                        withBlock1.Name = "cmbTrack";
                    }

                    withBlock.Columns.Add(colTrack);

                    DataGridViewComboBoxColumn colStatus = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colStatus;
                        DataTable colStatusDT = new DataTable();

                        //var TempPrecolStatusDT = repo.GetPreRequirementcolStatus();

                        var TempPrecolStatusDT = repo.GetPreRequirementcolStatus();
                        TempPrecolStatusDT = null;


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            TempPrecolStatusDT = repo2.GetPreRequirementcolStatusNew();

                        }
                        else
                        {
                            TempPrecolStatusDT = repo.GetPreRequirementcolStatus();
                        }

                        colStatusDT = ToDataTable(TempPrecolStatusDT);

                        //withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Status' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        withBlock1.DataSource = colStatusDT;
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 9;
                        withBlock1.HeaderText = "Status";
                        withBlock1.DataPropertyName = "Status";
                        withBlock1.Name = "cmbStatus";
                    }
                    withBlock.Columns.Add(colStatus);
                }
                {
                    var withBlock = grvPreRequirments;

                    // Set Column Property
                    withBlock.Columns["JobListID"].DataPropertyName = "JobListID";
                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Visible = false;
                    withBlock.Columns["Track"].Visible = false;
                    withBlock.Columns["AddDate"].Width = 90;
                    withBlock.Columns["AddDate"].HeaderText = "Added";
                    withBlock.Columns["NeedDate"].Visible = false;
                    withBlock.Columns["Obtained"].Visible = true;
                    withBlock.Columns["Obtained"].Width = 90;
                    withBlock.Columns["Expires"].Visible = false;
                    withBlock.Columns["Expires"].Width = 90;
                    withBlock.Columns["Status"].Visible = false;
                    withBlock.Columns["JobTrackingID"].Visible = false;
                    withBlock.Columns["TaskHandler"].HeaderText = "TM";
                    withBlock.Columns["TaskHandler"].Visible = false;
                    withBlock.Columns["Submitted"].Visible = false;
                    withBlock.Columns["BillState"].Visible = false;
                    withBlock.Columns["Comments"].HeaderText = "Comments";
                    withBlock.Columns["Comments"].Width = 550;
                    withBlock.Columns["TrackSubID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "SetColumnPreRequirment", ex.Message);
            }
        }

        private void SetColumnPermit()
        {
            try
            {
                try
                {
                    // Attempt to load the dataset.
                    //var TempColumnPermit = repo.PermitsRequirementSetColumn();

                    var TempColumnPermit = repo.PermitsRequirementSetColumn();
                    TempColumnPermit = null;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        TempColumnPermit = repo2.PermitsRequirementSetColumnNew();
                    }
                    else
                    {
                        TempColumnPermit = repo.PermitsRequirementSetColumn();
                    }

                    dtPermit = ToDataTable(TempColumnPermit);
                    grvPermitsRequiredInspection.DataSource = dtPermit;
                }
                catch (Exception eLoad)
                {
                    KryptonMessageBox.Show(eLoad.Message, "Manager");
                }
                // Grid Formatting
                {
                    var withBlock = grvPermitsRequiredInspection;
                    DataGridViewComboBoxColumn colTM = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colTM;

                        DataTable colTmDT = new DataTable();

                        //var TempPreColTM = repo.GetMasterItemTM_D();
                        var TempPreColTM = repo.GetMasterItemTM_D();
                        TempPreColTM = null;


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            TempPreColTM = repo2.GetMasterItemTM_D_New();
                        }
                        else
                        {
                            TempPreColTM = repo.GetMasterItemTM_D();
                        }

                        colTmDT = ToDataTable(TempPreColTM);

                        // withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) AND (isDisable <> 1 or IsDisable is  null) ORDER BY cTrack ");
                        withBlock1.DataSource = colTmDT;
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 2;
                        withBlock1.HeaderText = "TM";
                        withBlock1.DataPropertyName = "TaskHandler";
                        withBlock1.Width = 58;
                        withBlock1.Name = "cmbTaskHandler";
                    }

                    withBlock.Columns.Add(colTM);



                    DataGridViewComboBoxColumn colTrack = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colTrack;
                        DataTable colTrackDT = new DataTable();

                        //var TempPremitcolTrack = repo.GetPermitsRequirementcolTrack();
                        var TempPremitcolTrack = repo.GetPermitsRequirementcolTrack();
                        TempPremitcolTrack = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            TempPremitcolTrack = repo2.GetPermitsRequirementcolTrackNew();
                        }
                        else
                        {
                            TempPremitcolTrack = repo.GetPermitsRequirementcolTrack();
                        }

                        colTrackDT = ToDataTable(TempPremitcolTrack);


                        // withBlock1.DataSource = cmbobj.Filldatatable("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='Permits/Required/Inspection'");
                        withBlock1.DataSource = colTrackDT;
                        withBlock1.DisplayMember = "Trackname";
                        withBlock1.DisplayIndex = 4;
                        withBlock1.HeaderText = "Track";
                        withBlock1.DataPropertyName = "Track";
                        withBlock1.Name = "cmbTrack";
                    }
                    withBlock.Columns.Add(colTrack);

                    DataGridViewComboBoxColumn colStatus = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colStatus;
                        DataTable colStatusDT = new DataTable();
                        
                        //var TempPremitcolStatusDT = repo.GetPreRequirementcolStatus();
                        var TempPremitcolStatusDT = repo.GetPreRequirementcolStatus();
                        TempPremitcolStatusDT = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            TempPremitcolStatusDT = repo2.GetPreRequirementcolStatusNew();

                        }
                        else
                        {
                            TempPremitcolStatusDT = repo.GetPreRequirementcolStatus();
                        }

                        colStatusDT = ToDataTable(TempPremitcolStatusDT);
                        withBlock1.DataSource = colStatusDT;
                        //withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Status' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 9;
                        withBlock1.HeaderText = "Status";
                        withBlock1.DataPropertyName = "Status";
                        withBlock1.Name = "cmbStatus";
                    }
                    withBlock.Columns.Add(colStatus);


                    DataGridViewComboBoxColumn colFinalAction = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colFinalAction;
                        withBlock1.Items.Add("No Action");
                        withBlock1.Items.Add("Renewed");
                        withBlock1.Items.Add("Not Req'd");
                        withBlock1.HeaderText = "FinalAction";
                        withBlock1.Width = 80;
                        withBlock1.DisplayIndex = 11;
                        withBlock1.DataPropertyName = "FinalAction";
                        withBlock1.Name = "cmbFinalAction";
                    }
                    withBlock.Columns.Add(colFinalAction);


                    DataGridViewComboBoxColumn colBillStatus = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colBillStatus;
                        DataTable colBillStatusDT = new DataTable();

                        //var TempPremitcolBillStatusDT = repo.GetPermitsRequirementcolBillStatus();

                        var TempPremitcolBillStatusDT = repo.GetPermitsRequirementcolBillStatus();
                        TempPremitcolBillStatusDT = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            TempPremitcolBillStatusDT = repo2.GetPermitsRequirementcolBillStatusNew();

                        }
                        else
                        {
                            TempPremitcolBillStatusDT = repo.GetPermitsRequirementcolBillStatus();
                        }

                        colBillStatusDT = ToDataTable(TempPremitcolBillStatusDT);
                        withBlock1.DataSource = colBillStatusDT;
                        //withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 13;
                        withBlock1.HeaderText = "Bill State";
                        withBlock1.DataPropertyName = "BillState";
                        withBlock1.Name = "cmbBillState";
                    }

                    withBlock.Columns.Add(colBillStatus);
                }
                {
                    var withBlock = grvPermitsRequiredInspection;

                    // Set Column Property
                    withBlock.Columns["JobListID"].DataPropertyName = "JobListID";
                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Visible = false;
                    withBlock.Columns["Track"].Visible = false;
                    withBlock.Columns["AddDate"].Visible = true;
                    withBlock.Columns["AddDate"].Width = 90;
                    withBlock.Columns["AddDate"].HeaderText = "Added";
                    withBlock.Columns["NeedDate"].Visible = false;
                    withBlock.Columns["Obtained"].Visible = true;
                    withBlock.Columns["Obtained"].Width = 90;
                    withBlock.Columns["Expires"].Visible = true;
                    withBlock.Columns["Expires"].Width = 90;
                    withBlock.Columns["FinalAction"].Visible = false;
                    withBlock.Columns["FinalAction"].Width = 80;
                    withBlock.Columns["Status"].Visible = false;
                    withBlock.Columns["JobTrackingID"].Visible = false;
                    withBlock.Columns["TaskHandler"].HeaderText = "TM";
                    withBlock.Columns["TaskHandler"].Visible = false;
                    withBlock.Columns["Submitted"].Visible = true;
                    withBlock.Columns["BillState"].Visible = false;
                    withBlock.Columns["Comments"].HeaderText = "Comments";
                    withBlock.Columns["Comments"].Width = 360;
                    withBlock.Columns["TrackSub"].Width = 200;
                    withBlock.Columns["TrackSubID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "SetColumnPermit", ex.Message);
            }
        }

        private void SetColumnNotes()
        {
            //DataAccessLayer cmbobj = new DataAccessLayer();
            try
            {

                try
                {
                    // Attempt to load the dataset.

                    //var TempColumnNotes = repo.NotesSetColumn();
                    var TempColumnNotes = repo.NotesSetColumn();
                    TempColumnNotes = null;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        TempColumnNotes = repo2.NotesSetColumnNew();
                    }
                    else
                    {
                        TempColumnNotes = repo.NotesSetColumn();
                    }

                    dtNotes = ToDataTable(TempColumnNotes);

                    grvNotesCommunication.DataSource = dtNotes;
                }
                catch (Exception eLoad)
                {
                    // Add your error handling code here.0
                    // Display error message, if any.
                    KryptonMessageBox.Show(eLoad.Message, "Manager");
                }
                // Grid Formatting
                {
                    var withBlock = grvNotesCommunication;
                    DataGridViewComboBoxColumn colTM = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colTM;
                        DataTable colTMDT = new DataTable();

                        //var TempNotescolTM = repo.GetMasterItemTM_D();
                        var TempNotescolTM = repo.GetMasterItemTM_D();
                        TempNotescolTM = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            TempNotescolTM = repo2.GetMasterItemTM_D_New();
                        }
                        else
                        {
                            TempNotescolTM = repo.GetMasterItemTM_D();
                        }


                        colTMDT = ToDataTable(TempNotescolTM);
                        withBlock1.DataSource = colTMDT;
                        //withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) AND (isDisable <> 1 or IsDisable is  null) ORDER BY cTrack ");
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 2;
                        withBlock1.HeaderText = "TM";
                        withBlock1.DataPropertyName = "TaskHandler";
                        withBlock1.Width = 58;
                        withBlock1.Name = "cmbTaskHandler";
                    }

                    withBlock.Columns.Add(colTM);

                    DataGridViewComboBoxColumn colTrack = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colTrack;
                        DataTable colTrackDT = new DataTable();

                        //var TempNotescolTrack = repo.GetNotescolTrack();

                        var TempNotescolTrack = repo.GetNotescolTrack();
                        TempNotescolTrack = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            TempNotescolTrack = repo2.GetNotescolTrackNew();

                        }
                        else
                        {
                            TempNotescolTrack = repo.GetNotescolTrack();
                        }


                        colTrackDT = ToDataTable(TempNotescolTrack);
                        withBlock1.DataSource = colTrackDT;
                        //withBlock1.DataSource = cmbobj.Filldatatable("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='Notes/Communication'");
                        withBlock1.DisplayMember = "Trackname";
                        withBlock1.DisplayIndex = 4;
                        withBlock1.HeaderText = "Track";
                        withBlock1.DataPropertyName = "Track";
                        withBlock1.Name = "cmbTrack";
                    }

                    withBlock.Columns.Add(colTrack);

                    DataGridViewComboBoxColumn colStatus = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colStatus;
                        DataTable colStatusDT = new DataTable();

                        //var TempNotescolStatusDT = repo.GetPreRequirementcolStatus();
                        var TempNotescolStatusDT = repo.GetPreRequirementcolStatus();
                        TempNotescolStatusDT = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            TempNotescolStatusDT = repo2.GetPreRequirementcolStatusNew();

                        }
                        else
                        {
                            TempNotescolStatusDT = repo.GetPreRequirementcolStatus();
                        }


                        colStatusDT = ToDataTable(TempNotescolStatusDT);
                        withBlock1.DataSource = colStatusDT;

                        //withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Status' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 9;
                        withBlock1.HeaderText = "Status";
                        withBlock1.DataPropertyName = "Status";
                        withBlock1.Name = "cmbStatus";
                    }
                    withBlock.Columns.Add(colStatus);

                    DataGridViewComboBoxColumn colBillStatus = new DataGridViewComboBoxColumn();
                    {
                        var withBlock1 = colBillStatus;
                        DataTable colBillStatusDT = new DataTable();

                        //var NotescolBillStatusDT = repo.GetPermitsRequirementcolBillStatus();
                        var NotescolBillStatusDT = repo.GetPermitsRequirementcolBillStatus();
                        NotescolBillStatusDT = null;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            NotescolBillStatusDT = repo2.GetPermitsRequirementcolBillStatusNew();

                        }
                        else
                        {
                            NotescolBillStatusDT = repo.GetPermitsRequirementcolBillStatus();
                        }


                        colBillStatusDT = ToDataTable(NotescolBillStatusDT);
                        withBlock1.DataSource = colBillStatusDT;
                        //withBlock1.DataSource = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        withBlock1.DisplayMember = "cTrack";
                        withBlock1.DisplayIndex = 13;
                        withBlock1.HeaderText = "Bill State";
                        withBlock1.DataPropertyName = "BillState";
                        withBlock1.Name = "cmbBillState";
                    }
                    withBlock.Columns.Add(colBillStatus);

                    withBlock.Columns["JobListID"].DataPropertyName = "JobListID";
                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Visible = false;
                    withBlock.Columns["Track"].Visible = false;
                    withBlock.Columns["AddDate"].Visible = true;
                    withBlock.Columns["AddDate"].Width = 90;
                    withBlock.Columns["AddDate"].HeaderText = "Added";
                    withBlock.Columns["NeedDate"].Visible = false;
                    withBlock.Columns["Obtained"].Visible = false;
                    withBlock.Columns["Obtained"].Width = 90;
                    withBlock.Columns["Expires"].Visible = false;
                    withBlock.Columns["Expires"].Width = 90;
                    withBlock.Columns["Status"].Visible = false;
                    withBlock.Columns["JobTrackingID"].Visible = false;
                    withBlock.Columns["TaskHandler"].HeaderText = "TM";
                    withBlock.Columns["TaskHandler"].Visible = false;
                    withBlock.Columns["Submitted"].Visible = false;
                    withBlock.Columns["BillState"].Visible = false;
                    withBlock.Columns["Comments"].HeaderText = "Comments";
                    withBlock.Columns["Comments"].Width = 550;
                    withBlock.Columns["TrackSub"].Width = 200;
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "SetColumnNotes", ex.Message);
            }
        }

        private void FillGridPreRequirment()
        {
            try
            {
                string queryString = "";

                // If Me.chkShowOnlyPendingTrack.Checked Then queryString = queryString & " and JobTracking.Status ='Pending'"
                //TODO
                ////if (cbxSearchTm.Text.Trim() == "")
                ////    queryString = queryString + " AND JobTracking.TaskHandler= '" + cbxSearchTm.Text.Trim() + "'";
                if (CmbPreRequireTrack.Text.ToString() != "")
                    queryString = queryString + " AND JobTracking.Track='" + CmbPreRequireTrack.Text.ToString() + "'";
                if (cmbTrackSubPreRequire.Text.ToString() != "")
                    queryString = queryString + " AND JobTracking.TrackSub='" + cmbTrackSubPreRequire.Text.ToString() + "'";
                if (cmbStatusPreRequire.Text.ToString() != "")
                    queryString = queryString + " AND JobTracking.Status='" + cmbStatusPreRequire.Text.ToString() + "'";
                if (txtCommentsPreRequire.Text.Trim() != "")
                    queryString = queryString + "AND JobTracking.Comments like '%" + txtCommentsPreRequire.Text.Trim() + "%'";
                if (cmbBillStatePermit.Text.Trim() != "")
                    queryString = queryString + " AND JobTracking.BillState= '" + cmbBillStatePermit.Text.Trim() + "'";
                if (cmbTMWithPending.Text.Trim() != "")
                    queryString = queryString + " AND (JobTracking.Status='Pending' AND JobTracking.TaskHandler=  '" + cmbTMWithPending.Text.Trim() + "' )";
                queryString = queryString + " order by JobTrackingID";

                try
                {
                    // Attempt to load the dataset.

                    //var TempPreRequirementDataAfter = repo.GetPreRequirementDataAfterFilter(queryString, selectedJobListID);

                    var TempPreRequirementDataAfter = repo.GetPreRequirementDataAfterFilter(queryString, selectedJobListID);
                    TempPreRequirementDataAfter = null;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        TempPreRequirementDataAfter = repo2.GetPreRequirementDataAfterFilterNew(queryString, selectedJobListID);

                    }
                    else
                    {
                        TempPreRequirementDataAfter = repo.GetPreRequirementDataAfterFilter(queryString, selectedJobListID);
                    }

                    dtPreReq = ToDataTable(TempPreRequirementDataAfter);
                    grvPreRequirments.DataSource = dtPreReq;
                }
                catch (Exception eLoad)
                {
                    // Add your error handling code here.
                    // Display error message, if any.
                    KryptonMessageBox.Show(eLoad.Message, "Manager");
                }

                // Grid Formatting
                {
                    var withBlock = grvPreRequirments;

                    // Set Column Property
                    withBlock.Columns["JobListID"].DataPropertyName = "JobListID";
                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Visible = false;
                    withBlock.Columns["Track"].Visible = false;
                    withBlock.Columns["AddDate"].Width = 90;
                    withBlock.Columns["AddDate"].HeaderText = "Added";
                    withBlock.Columns["NeedDate"].Visible = false;
                    withBlock.Columns["Obtained"].Visible = true;
                    withBlock.Columns["Obtained"].Width = 90;
                    withBlock.Columns["Expires"].Visible = false;
                    withBlock.Columns["Expires"].Width = 90;
                    withBlock.Columns["Status"].Visible = false;
                    withBlock.Columns["JobTrackingID"].Visible = false;
                    withBlock.Columns["TaskHandler"].HeaderText = "TM";
                    withBlock.Columns["TaskHandler"].Visible = false;
                    withBlock.Columns["Submitted"].Visible = false;
                    withBlock.Columns["BillState"].Visible = false;
                    withBlock.Columns["Comments"].HeaderText = "Comments";
                    withBlock.Columns["Comments"].Width = 522;
                    withBlock.Columns["InvOvr"].HeaderText = "Inv. Ovr.";
                    withBlock.Columns["InvOvr"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US");
                    withBlock.Columns["TrackSub"].Width = 200;
                    withBlock.Columns["TrackSubID"].Visible = false;
                }

                btnDeletePreReq.Enabled = true;
                btnInsertPreReq.Text = "Insert";
                if (grvPreRequirments.Rows.Count > 0)
                    grvPreRequirments.CurrentCell = grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Cells["comments"];

                // Dim rows As IEnumerable(Of DataRow) = dtPreReq.AsEnumerable()
                // Dim catchData As List(Of DataRow) = rows.Where(Function(d) d.Item("Status") = "Pending").ToList()
                int countRow = 0;
                foreach (DataRow dr in dtPreReq.Rows)
                {
                    if (dr["Status"] == "Pending")
                        countRow = countRow + 1;
                }
                if (countRow > 0)
                    lblPreRequirment.ForeColor = Color.Tomato;
                else
                    lblPreRequirment.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "FillGridPreRequirment", ex.Message);
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void InsertJobList()
        {
            // grvJobList.Rows[0].Cells["JobNumber").Selected = True 'move this line to below until input validate
            grvJobList.EndEdit();
            //DAL = new EFDbContext();
            try
            {
                if (grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobNumber"].FormattedValue == "")
                {
                    KryptonMessageBox.Show("Please enter Job Number ", "Manager");
                    grvJobList.CurrentCell = grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobNumber"];
                    return;
                }
                else
                    foreach (DataGridViewRow row in grvJobList.Rows)
                    {
                        if (grvJobList.Rows.Count - 1 != row.Index)
                        {
                            if (grvJobList.Rows[row.Index].Cells["JobNumber"].EditedFormattedValue == grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobNumber"].EditedFormattedValue)
                            {
                                if (KryptonMessageBox.Show("Entered Job Number already exist for this Client:-" + grvJobList.Rows[row.Index].Cells["Client#"].EditedFormattedValue.ToString() + " ! you want to continue.", "Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                                {
                                    grvJobList.CurrentCell = grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobNumber"];
                                    return;
                                }
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
            }
            try
            {
                btnDelete.Enabled = true;
                int cnt = grvJobList.Rows.Count - 1;
                // cmd = New SqlCommand(" Insert into JobList(JobNumber,Client,DateAdded,Description,Handler,Address,Borough,Contacts,ContactsEmails) values (@JobNumber,@Client,@DateAdded,@Description,@Handler,@Address,@Borough,@Contacts,@ContactsEmails)", sqlcon)
                if ((!ValidateRateServTypeValue(cnt)))
                    return;
                grvJobList.Rows[0].Cells["JobNumber"].Selected = true;
                SqlCommand cmd = new SqlCommand();
                if ((AutoJB.ToString() != grvJobList.Rows[cnt].Cells["JobNumber"].Value.ToString()))
                    cmd.CommandText = "Insert into JobList (JobNumber, CompanyID, ContactsID, DateAdded, Description, Handler, Address, Borough,InvoiceClient ,InvoiceContact, InvoiceEmailAddress, InvoiceACContacts, InvoiceACEmail,IsNewRecord,OwnerName,OwnerAddress,OwnerPhone,OwnerFax,ACContacts,ACEmail,Clienttext,ContactsEmails, PMrv,RateVersionId,ServRate,AdminInvoice, IsInvoiceHold) values (@JobNumber, @CompanyID, @ContactsID, @DateAdded, @Description, @Handler, @Address, @Borough,@InvoiceClient ,@InvoiceContact,@InvoiceEmailAddress,@InvoiceACContacts, @InvoiceACEmail, @IsNewRecord, @OwnerName, @OwnerAddress,@OwnerPhone,@OwnerFax,@ACContacts,@ACEmail,@Clienttext,@ContactsEmails, @PMrv,@RateVersionId,@ServRate,@AdminInvoice, @IsInvoiceHold)";
                else

                    cmd.CommandText = "Insert into JobList (JobNumber, CompanyID, ContactsID, DateAdded, Description, Handler, Address, Borough,InvoiceClient ,InvoiceContact, InvoiceEmailAddress, InvoiceACContacts, InvoiceACEmail,IsNewRecord,OwnerName,OwnerAddress,OwnerPhone,OwnerFax,ACContacts,ACEmail,Clienttext,ContactsEmails, PMrv, RateVersionId,ServRate,AdminInvoice, IsInvoiceHold) values (@JobNumber,@CompanyID,@ContactsID,@DateAdded,@Description,@Handler,@Address,@Borough,@InvoiceClient ,@InvoiceContact,@InvoiceEmailAddress,@InvoiceACContacts, @InvoiceACEmail,@IsNewRecord,@OwnerName,@OwnerAddress,@OwnerPhone,@OwnerFax,@ACContacts,@ACEmail,@Clienttext,@ContactsEmails, @PMrv, @RateVersionId,@ServRate,@AdminInvoice, @IsInvoiceHold)";


                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@IsNewRecord", 1));
                Param.Add(new SqlParameter("@JobListID", grvJobList.Rows[cnt].Cells["JobListID"].Value.ToString()));

                if ((AutoJB.ToString() != grvJobList.Rows[cnt].Cells["JobNumber"].Value.ToString()))
                    Param.Add(new SqlParameter("@JobNumber", grvJobList.Rows[cnt].Cells["JobNumber"].Value.ToString()));
                else

                    Param.Add(new SqlParameter("@JobNumber", AutoJB.ToString()));
                Param.Add(new SqlParameter("@DateAdded", grvJobList.Rows[cnt].Cells["DateAdded"].Value.ToString()));
                Param.Add(new SqlParameter("@Description", grvJobList.Rows[cnt].Cells["Description"].Value.ToString()));
                Param.Add(new SqlParameter("@Address", grvJobList.Rows[cnt].Cells["Address"].Value.ToString()));
                Param.Add(new SqlParameter("@Handler", grvJobList.Rows[cnt].Cells["cmbHandler"].Value.ToString()));
                Param.Add(new SqlParameter("@Borough", grvJobList.Rows[cnt].Cells["Borough"].Value.ToString()));
                Param.Add(new SqlParameter("@OwnerName", grvJobList.Rows[cnt].Cells["OwnerName"].Value.ToString()));
                Param.Add(new SqlParameter("@OwnerAddress", grvJobList.Rows[cnt].Cells["OwnerAddress"].Value.ToString()));
                Param.Add(new SqlParameter("@OwnerPhone", grvJobList.Rows[cnt].Cells["OwnerPhone"].Value.ToString()));
                Param.Add(new SqlParameter("@OwnerFax", grvJobList.Rows[cnt].Cells["OwnerFax"].Value.ToString()));
                Param.Add(new SqlParameter("@ACContacts", grvJobList.Rows[cnt].Cells["ACContacts"].Value.ToString()));
                Param.Add(new SqlParameter("@ACEmail", grvJobList.Rows[cnt].Cells["ACEmail"].Value.ToString()));
                Param.Add(new SqlParameter("@Clienttext", grvJobList.Rows[cnt].Cells["Clienttext"].Value.ToString()));
                Param.Add(new SqlParameter("@ContactsEmails", grvJobList.Rows[cnt].Cells["EmailAddress"].Value.ToString()));
                Param.Add(new SqlParameter("@PMrv", grvJobList.Rows[cnt].Cells["cmbPMrv"].Value.ToString()));
                Param.Add(new SqlParameter("@IsInvoiceHold", grvJobList.Rows[cnt].Cells["IsInvoiceHold"].Value));
                Param.Add(new SqlParameter("@InvoiceClient", grvJobList.Rows[cnt].Cells["InvoiceClient"].Value.ToString()));
                Param.Add(new SqlParameter("@InvoiceContact", grvJobList.Rows[cnt].Cells["InvoiceContact"].Value.ToString()));
                Param.Add(new SqlParameter("@InvoiceEmailAddress", grvJobList.Rows[cnt].Cells["InvoiceEmailAddress"].Value.ToString()));
                Param.Add(new SqlParameter("@InvoiceACContacts", grvJobList.Rows[cnt].Cells["InvoiceACContacts"].Value.ToString()));
                Param.Add(new SqlParameter("@InvoiceACEmail", grvJobList.Rows[cnt].Cells["InvoiceACEmail"].Value.ToString()));
                Param.Add(new SqlParameter("@RateVersionId", grvJobList.Rows[cnt].Cells["RateVersionId"].Value));
                Param.Add(new SqlParameter("@ServRate", grvJobList.Rows[cnt].Cells["ServRate"].Value));
                Param.Add(new SqlParameter("@AdminInvoice", grvJobList.Rows[cnt].Cells["AdminInvoice"].Value));
                if (grvJobList.Rows[cnt].Cells["Client#"].Value.ToString() == "")
                    Param.Add(new SqlParameter("@CompanyID", 0));
                else
                    Param.Add(new SqlParameter("@CompanyID", grvJobList.Rows[cnt].Cells["Client#"].Value));

                int ContactsID;
                string values = Convert.ToString(grvJobList.Rows[cnt].Cells["ContactsID"].Value);
                if (String.IsNullOrEmpty(values))
                {
                    Param.Add(new SqlParameter("@ContactsID", "0"));
                    ContactsID = 0;
                }
                else
                {
                    ContactsID = Convert.ToInt32(grvJobList.Rows[cnt].Cells["ContactsID"].Value.ToString());
                    Param.Add(new SqlParameter("@ContactsID", grvJobList.Rows[cnt].Cells["ContactsID"].Value.ToString()));
                }
                //(new db.Database.ExecuteSqlCommand(cmd.CommandText, Param) > 0)

                //int num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());

                int num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                num = 0;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    num = repo2.db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());

                }
                else
                {
                    num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                }


                if (num > 0)
                {
                    // System.Windows.Forms.MessageBox.Show("Record Saved!", "Message")
                    fillGridJobList();
                    grvJobList.Rows[grvJobList.Rows.Count - 1].Selected = true;
                    grvJobList.CurrentCell = grvJobList.Rows[grvJobList.Rows.Count - 1].Cells["JobNumber"];
                    btnAdd.Text = "Insert";
                    //new LoginActivityInfo("Insert", this.Text);
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JobStatus", "InsertJobList", ex.Message);
                KryptonMessageBox.Show(ex.Message, "Manager");
            }
        }

        private bool ValidateRateServTypeValue(int rowindex)
        {
            bool conditionValid = true;
            if ((string.IsNullOrEmpty(grvJobList.Rows[rowindex].Cells["RateVersionId"].Value.ToString()) | grvJobList.Rows[rowindex].Cells["RateVersionId"].Value.ToString() == "0"))
            {
                conditionValid = false;
                MessageBox.Show("Please Select Item Rate", "Manager", MessageBoxButtons.OK);
            }
            else if ((string.IsNullOrEmpty(grvJobList.Rows[rowindex].Cells["ServRate"].Value.ToString())))
            {
                conditionValid = false;
                MessageBox.Show("Please Select Service Rate", "Manager", MessageBoxButtons.OK);
            }
            else if ((string.IsNullOrEmpty(grvJobList.Rows[rowindex].Cells["TypicalInvoiceType"].Value.ToString())))
            {
                conditionValid = false;
                MessageBox.Show("Please Select Invoice Type", "Manager", MessageBoxButtons.OK);
            }
            return conditionValid;
        }

        protected void InsertPreReq()
        {
            grvPreRequirments.Rows[0].Cells["comments"].Selected = true;
            grvPreRequirments.EndEdit();
            if (string.IsNullOrEmpty(grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Cells["Track"].Value.ToString()))
            {
                KryptonMessageBox.Show("Track field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Cells["TrackSub"].Value.ToString()))
            {
                KryptonMessageBox.Show("TrackSub field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                btnDeletePreReq.Enabled = true;
                int cnt = grvPreRequirments.Rows.Count - 1;
                //DataAccessLayer DAL = new DataAccessLayer();

                SqlCommand cmd = new SqlCommand("Insert into Jobtracking(JobListID,Track,AddDate,NeedDate,Obtained,Expires,Status,Submitted,BillState,TaskHandler,TrackSub,Comments,IsNewRecord,TrackSubID,InvOvr) values (@JobListID,@Track,@AddDate,@NeedDate,@Obtained,@Expires,@Status,@Submitted,@BillState,@TaskHandler,@TrackSub,@Comments,@IsNewRecord,@TrackSubID,@InvOvr)");
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@IsNewRecord", 1));
                Param.Add(new SqlParameter("@JobListID", selectedJobListID));
                Param.Add(new SqlParameter("@TaskHandler", grvPreRequirments.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()));
                Param.Add(new SqlParameter("@Track", grvPreRequirments.Rows[cnt].Cells["cmbTrack"].Value.ToString()));


                DateTime Submitted = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["Submitted"].Value.ToString());
                string SubmittedStr = "";
                SubmittedStr = Submitted.Month + "-" + Submitted.Day + "-" + Submitted.Year + " " + Submitted.ToLongTimeString();


                Param.Add(new SqlParameter("@Submitted", SubmittedStr.ToString()));
                //Param.Add(new SqlParameter("@Submitted", grvPreRequirments.Rows[cnt].Cells["Submitted"].Value.ToString()));


                Param.Add(new SqlParameter("@BillState", grvPreRequirments.Rows[cnt].Cells["BillState"].Value.ToString()));
                Param.Add(new SqlParameter("@TrackSub", grvPreRequirments.Rows[cnt].Cells["TrackSub"].Value.ToString()));
                Param.Add(new SqlParameter("@Comments", grvPreRequirments.Rows[cnt].Cells["Comments"].Value.ToString()));
                Param.Add(new SqlParameter("@Status", grvPreRequirments.Rows[cnt].Cells["cmbStatus"].Value.ToString()));

                DateTime Obtained = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["Obtained"].Value.ToString());
                string ObtainedStr = "";
                ObtainedStr = Obtained.Month + "-" + Obtained.Day + "-" + Obtained.Year + " " + Obtained.ToLongTimeString();

                Param.Add(new SqlParameter("@Obtained", ObtainedStr.ToString()));

                DateTime Expires = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["Expires"].Value.ToString());
                string ExpiresStr = "";
                ExpiresStr = Expires.Month + "-" + Expires.Day + "-" + Expires.Year + " " + Expires.ToLongTimeString();

                Param.Add(new SqlParameter("@Expires", ExpiresStr.ToString()));


                //Param.Add(new SqlParameter("@Obtained", grvPreRequirments.Rows[cnt].Cells["Obtained"].Value.ToString()));
                //Param.Add(new SqlParameter("@Expires", grvPreRequirments.Rows[cnt].Cells["Expires"].Value.ToString()));

                DateTime AddDate = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["AddDate"].Value.ToString());
                string AddDateStr = "";
                AddDateStr = AddDate.Month + "-" + AddDate.Day + "-" + AddDate.Year + " " + AddDate.ToLongTimeString();

                DateTime NeedDate = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["NeedDate"].Value.ToString());
                string NeedDateStr = "";
                NeedDateStr = NeedDate.Month + "-" + NeedDate.Day + "-" + NeedDate.Year + " " + NeedDate.ToLongTimeString();

                Param.Add(new SqlParameter("@AddDate", AddDateStr.ToString()));
                Param.Add(new SqlParameter("@NeedDate", NeedDateStr.ToString()));

                //Param.Add(new SqlParameter("@AddDate", grvPreRequirments.Rows[cnt].Cells["AddDate"].Value.ToString()));
                //Param.Add(new SqlParameter("@NeedDate", grvPreRequirments.Rows[cnt].Cells["NeedDate"].Value.ToString()));



                Param.Add(new SqlParameter("@TrackSubID", grvPreRequirments.Rows[cnt].Cells["TrackSubID"].Value.ToString()));
                Param.Add(new SqlParameter("@InvOvr", grvPreRequirments.Rows[cnt].Cells["InvOvr"].Value.ToString()));

                //if (new Database.ParameterSqlExcecuteQuery(cmd, Param) > 0)

                repo.Insert();
                repo2.Insert();

                //int num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                int num;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    num = repo2.db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                }
                else
                {
                    num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                }


                
                if (num > 0)
                {
                    //System.Windows.Forms.MessageBox.Show("Record Saved!", "Message")
                    //////new Database.LoginActivityInfo("Insert", this.Text);
                    FillGridPreRequirment();
                    if (grvPreRequirments.Rows.Count > 0)
                    {
                        grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Selected = true;
                        grvPreRequirments.CurrentCell = grvPreRequirments.Rows[grvPreRequirments.Rows.Count - 1].Cells["comments"];
                    }

                    btnInsertPreReq.Text = "Insert";
                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Manager");
            }
        }

        protected void InsertPermits()
        {
            //grvPermitsRequiredInspection.Rows[0].Cells["comments").Selected = True
            grvPermitsRequiredInspection.EndEdit();
            if (string.IsNullOrEmpty(grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Cells["Track"].Value.ToString()))
            {
                KryptonMessageBox.Show("Track field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Cells["TrackSub"].Value.ToString()))
            {
                KryptonMessageBox.Show("TrackSub field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                btnDeletePermit.Enabled = true;
                int cnt = grvPermitsRequiredInspection.Rows.Count - 1;
                //DataAccessLayer DAL = new DataAccessLayer();
                SqlCommand cmd = new SqlCommand("Insert into Jobtracking(JobListID,Track,AddDate,NeedDate,Obtained,Expires,Status,Submitted,BillState,TaskHandler,TrackSub,Comments,IsNewRecord,TrackSubID, FinalAction,InvOvr ) values (@JobListID,@Track,@AddDate,@NeedDate,@Obtained,@Expires,@Status,@Submitted,@BillState,@TaskHandler,@TrackSub,@Comments,@IsNewRecord,@TrackSubID, @FinalAction,@InvOvr)");
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@IsNewRecord", 1));
                Param.Add(new SqlParameter("@JobListID", selectedJobListID));
                Param.Add(new SqlParameter("@TaskHandler", grvPermitsRequiredInspection.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()));
                Param.Add(new SqlParameter("@Track", grvPermitsRequiredInspection.Rows[cnt].Cells["cmbTrack"].Value.ToString()));


                DateTime Submitted = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["Submitted"].Value.ToString());
                string SubmittedStr = "";
                SubmittedStr = Submitted.Month + "-" + Submitted.Day + "-" + Submitted.Year + " " + Submitted.ToLongTimeString();

                Param.Add(new SqlParameter("@Submitted", SubmittedStr.ToString()));

                //Param.Add(new SqlParameter("@Submitted", grvPermitsRequiredInspection.Rows[cnt].Cells["Submitted"].Value.ToString()));

                Param.Add(new SqlParameter("@BillState", grvPermitsRequiredInspection.Rows[cnt].Cells["cmbBillState"].Value.ToString()));
                Param.Add(new SqlParameter("@TrackSub", grvPermitsRequiredInspection.Rows[cnt].Cells["TrackSub"].Value.ToString()));
                Param.Add(new SqlParameter("@Comments", grvPermitsRequiredInspection.Rows[cnt].Cells["Comments"].Value.ToString()));
                Param.Add(new SqlParameter("@Status", grvPermitsRequiredInspection.Rows[cnt].Cells["cmbStatus"].Value.ToString()));

                DateTime Obtained = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["Obtained"].Value.ToString());
                string ObtainedStr = "";
                ObtainedStr = Obtained.Month + "-" + Obtained.Day + "-" + Obtained.Year + " " + Obtained.ToLongTimeString();

                Param.Add(new SqlParameter("@Obtained", ObtainedStr.ToString()));

                DateTime Expires = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["Expires"].Value.ToString());
                string ExpiresStr = "";
                ExpiresStr = Expires.Month + "-" + Expires.Day + "-" + Expires.Year + " " + Expires.ToLongTimeString();

                Param.Add(new SqlParameter("@Expires", ExpiresStr.ToString()));


                //Param.Add(new SqlParameter("@Obtained", grvPermitsRequiredInspection.Rows[cnt].Cells["Obtained"].Value.ToString()));
                //Param.Add(new SqlParameter("@Expires", grvPermitsRequiredInspection.Rows[cnt].Cells["Expires"].Value.ToString()));


                Param.Add(new SqlParameter("@FinalAction", grvPermitsRequiredInspection.Rows[cnt].Cells["FinalAction"].Value.ToString()));




                DateTime AddDate = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["AddDate"].Value.ToString());
                string AddDateStr = "";
                AddDateStr = AddDate.Month + "-" + AddDate.Day + "-" + AddDate.Year + " " + AddDate.ToLongTimeString();

                DateTime NeedDate = Convert.ToDateTime(grvPermitsRequiredInspection.Rows[cnt].Cells["NeedDate"].Value.ToString());
                string NeedDateStr = "";
                NeedDateStr = NeedDate.Month + "-" + NeedDate.Day + "-" + NeedDate.Year + " " + NeedDate.ToLongTimeString();

                Param.Add(new SqlParameter("@AddDate", AddDateStr.ToString()));
                Param.Add(new SqlParameter("@NeedDate", NeedDateStr.ToString()));


                //Param.Add(new SqlParameter("@AddDate", grvPermitsRequiredInspection.Rows[cnt].Cells["AddDate"].Value.ToString()));
                //Param.Add(new SqlParameter("@NeedDate", grvPermitsRequiredInspection.Rows[cnt].Cells["NeedDate"].Value.ToString()));


                Param.Add(new SqlParameter("@InvOvr", grvPermitsRequiredInspection.Rows[cnt].Cells["InvOvr"].Value.ToString()));
                Param.Add(new SqlParameter("@TrackSubID", grvPermitsRequiredInspection.Rows[cnt].Cells["TrackSubID"].Value.ToString()));

                //int num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                //repo.LoginActivityInfo(repo.db, "Insert", this.Text);

                int num;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    num = repo2.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                    repo2.LoginActivityInfoNew(repo2.db2, "Insert", this.Text);                    
                    //repo2.LoginActivityInfo();

                }
                else
                {
                    num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                    repo.LoginActivityInfo(repo.db, "Insert", this.Text);
                }

                //repo.LoginActivityInfo(repo.db, "Insert", this.Text);

                if (num > 0)
                {

                    FillGridPermitRequiredInspection();
                    if (grvPermitsRequiredInspection.Rows.Count > 0)
                    {
                        grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Selected = true;
                        grvPermitsRequiredInspection.CurrentCell = grvPermitsRequiredInspection.Rows[grvPermitsRequiredInspection.Rows.Count - 1].Cells["comments"];
                    }

                    btnInsertPermit.Text = "Insert";
                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Manager");
            }
        }

        protected void InsertNotes()
        {
            grvNotesCommunication.Rows[0].Cells["comments"].Selected = true;
            grvNotesCommunication.EndEdit();
            if (string.IsNullOrEmpty(grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Cells["Track"].Value.ToString()))
            {
                KryptonMessageBox.Show("Track field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Cells["TrackSub"].Value.ToString()))
            {
                KryptonMessageBox.Show("TrackSub field are compulsory", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                btndeleteNotes.Enabled = true;
                int cnt = grvNotesCommunication.Rows.Count - 1;
                //DataAccessLayer DAL = new DataAccessLayer();

                SqlCommand cmd = new SqlCommand("Insert into Jobtracking(JobListID,Track,AddDate,NeedDate,Obtained,Expires, Status, Submitted,BillState,TaskHandler,TrackSub,Comments,IsNewRecord,TrackSubID,InvOvr,DeleteItemTimeService) values (@JobListID,@Track,@AddDate,@NeedDate,@Obtained,@Expires,@Status,@Submitted,@BillState,@TaskHandler,@TrackSub,@Comments,@IsNewRecord,@TrackSubID,@InvOvr,@DeleteItemTimeService)");
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@IsNewRecord", 1));
                Param.Add(new SqlParameter("@JobListID", selectedJobListID));
                Param.Add(new SqlParameter("@TaskHandler", grvNotesCommunication.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()));
                Param.Add(new SqlParameter("@Track", grvNotesCommunication.Rows[cnt].Cells["cmbTrack"].Value.ToString()));

                DateTime Submitted = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["Submitted"].Value.ToString());
                string SubmittedStr = "";
                SubmittedStr = Submitted.Month + "-" + Submitted.Day + "-" + Submitted.Year + " " + Submitted.ToLongTimeString();
                Param.Add(new SqlParameter("@Submitted", SubmittedStr.ToString()));

                //Param.Add(new SqlParameter("@Submitted", grvNotesCommunication.Rows[cnt].Cells["Submitted"].Value.ToString()));


                Param.Add(new SqlParameter("@BillState", grvNotesCommunication.Rows[cnt].Cells["cmbBillState"].Value.ToString()));
                Param.Add(new SqlParameter("@TrackSub", grvNotesCommunication.Rows[cnt].Cells["TrackSub"].Value.ToString()));
                Param.Add(new SqlParameter("@Comments", grvNotesCommunication.Rows[cnt].Cells["Comments"].Value.ToString()));
                Param.Add(new SqlParameter("@Status", grvNotesCommunication.Rows[cnt].Cells["cmbStatus"].Value.ToString()));

                DateTime Obtained = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["Obtained"].Value.ToString());
                string ObtainedStr = "";
                ObtainedStr = Obtained.Month + "-" + Obtained.Day + "-" + Obtained.Year + " " + Obtained.ToLongTimeString();
                Param.Add(new SqlParameter("@Obtained", ObtainedStr.ToString()));

                //Param.Add(new SqlParameter("@Obtained", grvNotesCommunication.Rows[cnt].Cells["Obtained"].Value.ToString()));


                DateTime Expires = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["Expires"].Value.ToString());
                string ExpiresStr = "";
                ExpiresStr = Expires.Month + "-" + Expires.Day + "-" + Expires.Year + " " + Expires.ToLongTimeString();
                Param.Add(new SqlParameter("@Expires", ExpiresStr.ToString()));

                //Param.Add(new SqlParameter("@Expires", grvNotesCommunication.Rows[cnt].Cells["Expires"].Value.ToString()));

                DateTime AddDate = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["AddDate"].Value.ToString());
                string AddDateStr = "";
                AddDateStr = AddDate.Month + "-" + AddDate.Day + "-" + AddDate.Year + " " + AddDate.ToLongTimeString();
                Param.Add(new SqlParameter("@AddDate", AddDateStr.ToString()));

                //Param.Add(new SqlParameter("@AddDate", grvNotesCommunication.Rows[cnt].Cells["AddDate"].Value.ToString()));



                DateTime NeedDate = Convert.ToDateTime(grvNotesCommunication.Rows[cnt].Cells["NeedDate"].Value.ToString());
                string NeedDateStr = "";
                NeedDateStr = NeedDate.Month + "-" + NeedDate.Day + "-" + NeedDate.Year + " " + NeedDate.ToLongTimeString();
                Param.Add(new SqlParameter("@NeedDate", NeedDateStr.ToString()));

                //Param.Add(new SqlParameter("@NeedDate", grvNotesCommunication.Rows[cnt].Cells["NeedDate"].Value.ToString()));



                Param.Add(new SqlParameter("@InvOvr", grvNotesCommunication.Rows[cnt].Cells["InvOvr"].Value.ToString()));
                Param.Add(new SqlParameter("@TrackSubID", grvNotesCommunication.Rows[cnt].Cells["TrackSubID"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@DeleteItemTimeService", grvNotesCommunication.Rows[cnt].Cells["DeleteItemTimeService"].EditedFormattedValue.ToString()));

                //int num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                int num;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    num = repo2.db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                }
                else
                {
                    num = repo.db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray());
                }


                if (num > 0)
                {
                    FillGridNotesCommunication();
                    
                    //repo.LoginActivityInfo(repo.db, "Insert", this.Text);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        repo2.LoginActivityInfoNew(repo2.db2, "Insert", this.Text);
                    }
                    else
                    {
                        repo.LoginActivityInfo(repo.db, "Insert", this.Text);
                    }


                    if (grvNotesCommunication.Rows.Count > 0)
                    {
                        grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Selected = true;
                        grvNotesCommunication.CurrentCell = grvNotesCommunication.Rows[grvNotesCommunication.Rows.Count - 1].Cells["comments"];
                    }

                    btnInsertNotes.Text = "Insert";
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Manager");
            }
        }

        private void SetDirListBox(string jobNumber)
        {
            try
            {

                string code = jobNumber.Substring(0, jobNumber.IndexOf("-"));
                string url = string.Empty;
                try
                {
                    if (code == "EN")
                    {
                        url = "N:\\VE\\JobEN\\" + jobNumber + "\\JobTracker\\";
                        return;
                    }
                    if (code == "VE")
                    {
                        url = "N:\\VE\\JobVE\\" + jobNumber + "\\JobTracker\\";
                        return;
                    }
                    url = "N:\\VE\\Job2010" + code + "\\" + jobNumber + "\\JobTracker\\";
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (string.IsNullOrEmpty(url) || !System.IO.Directory.Exists(url))
                    {
                        DirListBox1.Path = "N:\\";
                        FileListBox1.Path = "N:\\";
                        //FileListBox1.Path = "ffff"
                        OpenFileDialog1.InitialDirectory = "N:\\";
                    }
                    else
                    {
                        DirListBox1.Path = url;
                        FileListBox1.Path = url;
                        OpenFileDialog1.InitialDirectory = url;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void ChangeDirJobNumber(int Rindex)
        {
            try
            {
                string GetDir = null;
                bool Find = false;
                string[] Directries = null;
                try
                {
                    Directries = Directory.GetDirectories(cGlobal.sNetworkDirPath);
                }
                catch (Exception)
                { }
                if (!(Directries is null))
                {
                    foreach (string GetDirWithinLoop in Directries)
                    {
                        GetDir = GetDirWithinLoop;
                        foreach (string SubGetDir in Directory.GetDirectories(GetDirWithinLoop))
                        {
                            if (SubGetDir.Contains(grvJobList.Rows[Rindex].Cells["JobNumber"].Value.ToString()))
                            {
                                DirListBox1.Path = SubGetDir;
                                FileListBox1.Path = SubGetDir;
                                Find = true;
                                break;
                            }
                            else
                            {
                                Find = false;
                            }
                        }
                        if (Find == true)
                        {
                            break;
                        }
                    }
                }
                if (Find == false)
                {
                    DirListBox1.Path = cGlobal.sNetworkDrivePath;
                    FileListBox1.Path = cGlobal.sNetworkDrivePath;
                }
                GetDir = string.Empty;
            }
            catch (Exception ex)
            {
                if (ToasterNoty != null)
                {
                    ToasterNoty.Close();
                }
                ToasterNoty = new Notification(this.Text, ex.Message, -1, FormAnimator.AnimationMethod.Slide, FormAnimator.AnimationDirection.Up);
                ToasterNoty.Show();
            }
        }

        public void ChangeTraficLight(int Rindex)
        {
            try
            {
                string Companyid = Program.ZeroIfEmpty(grvJobList.Rows[Rindex].Cells["CompanyID"].Value.ToString());

                pnlTraficLight.Visible = false;
                lblShowCreditAlert.Visible = false;
                int aging = 0;
                //DataTable ColorDT=null;


                var ColorDT = repo.db.Database.SqlQuery<CompanyAction>("SELECT Age0Action,Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging, DBadClient, IsCreditPass, CreditPassDate,DueInvoiceNo FROM Company WHERE CompanyID= '" + Companyid.ToString() + "'").FirstOrDefault();
                ColorDT = null;


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    ColorDT = repo2.db.Database.SqlQuery<CompanyAction>("SELECT Age0Action,Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging, DBadClient, IsCreditPass, CreditPassDate,DueInvoiceNo FROM Company WHERE CompanyID= '" + Companyid.ToString() + "'").FirstOrDefault();
                }
                else
                {
                    ColorDT = repo.db.Database.SqlQuery<CompanyAction>("SELECT Age0Action,Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging, DBadClient, IsCreditPass, CreditPassDate,DueInvoiceNo FROM Company WHERE CompanyID= '" + Companyid.ToString() + "'").FirstOrDefault();
                }


                if (ColorDT != null)
                {
                    bool Creditpassdetails = creditPassAlertVisible();
                    aging = Convert.ToInt32(ColorDT.Aging.ToString());
                    //'dueinvoiceno = ColorDT.Rows[0).Item("DueInvoiceNo").ToString

                    //If ColorDT.Rows[0).Item("IsCreditPass") = False Then
                    if (!Convert.IsDBNull(ColorDT.CreditPassDate) || Creditpassdetails)
                    {
                        if (Convert.ToDateTime(ColorDT.CreditPassDate.ToString()).ToString("M/d/yyyy") != "1/1/1900" || Creditpassdetails)
                        {
                            DateTime dt = Convert.ToDateTime(ColorDT.CreditPassDate.ToString());
                            if (dt <= DateTime.Today)
                            {
                                //If ColorDT.Rows[0).Item("DBadClient") = True Then
                                //    pnlTraficLight.Visible = True
                                //    'btnAgingColor.Text = "X"
                                //    ' btnAgingColor.BackColor = Color.Gainsboro
                                //End If
                                ColorColumn = GetColumnName(aging);

                                if (Convert.ToBoolean(ColorDT.DBadClient) == true)
                                {
                                    pnlTraficLight.Visible = true;
                                    // btnAgingColor.Text = "X"
                                }
                                lblShowCreditAlert.Visible = false;
                                if (aging >= 0)
                                {
                                    pnlTraficLight.Visible = true;
                                    //pnlTraficLight.Visible = False
                                }
                                else
                                {
                                    pnlTraficLight.Visible = true;
                                }
                            }
                            else
                            {
                                lblShowCreditAlert.Visible = false;
                            }
                        }
                        else
                        {
                            //'creditPassAlertVisible()
                            //If aging < 15 And aging >= 0 Then
                            if (Creditpassdetails == false)
                            {
                                ColorColumn = "Age0Action";
                                pnlTraficLight.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        //If aging < 15 And aging >= 0 Then
                        if (Creditpassdetails == false)
                        {
                            ColorColumn = "Age0Action";
                            pnlTraficLight.Visible = true;
                        }
                    }
                    Colorid = Convert.ToInt32(ColorDT.GetPropValue(ColorDT, ColorColumn));
                    btnAgingColor.BackColor = ChangeTraficLightColor(Colorid);
                }
                else
                {
                    pnlTraficLight.Visible = false;
                    lblShowCreditAlert.Visible = false;
                    btnAgingColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
            catch (Exception ex)
            {
                pnlTraficLight.Visible = false;
                lblShowCreditAlert.Visible = false;
                btnAgingColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            }
        }

        private string GetColumnName(int aging)
        {
            string sColumn = string.Empty;

            if ((aging >= 0 && aging < 15))
                sColumn = "Age0Action";
            else if (aging >= 15 && aging < 30)
                sColumn = "Age15Action";
            else if (aging >= 30 && aging < 45)
                sColumn = "Age30Action";
            else if (aging >= 45 && aging < 60)
                sColumn = "Age45Action";
            else if (aging >= 60 && aging < 75)
                sColumn = "Age60Action";
            else if (aging >= 75 && aging < 90)
                sColumn = "Age75Action";
            else if (aging >= 90 && aging < 105)
                sColumn = "Age90Action";
            else if (aging >= 105)
                sColumn = "Age105Action";
            return sColumn;
        }

        public Color ChangeTraficLightColor(int ColorCode)
        {
            switch (ColorCode)
            {
                case 1:
                    return Color.Green;
                case 2:
                    return Color.Orange;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.Red;
                case 5:
                    return Color.Black;
                case 6:
                    return Color.Blue;
            }
            return new Color();
        }

        private bool creditPassAlertVisible()
        {
            var data = repo.db.Database.SqlQuery<int>("SELECT Count(CompanyID) FROM  AgingInvoice WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString()).FirstOrDefault();

            data = 0;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                data = repo2.db2.Database.SqlQuery<int>("SELECT Count(CompanyID) FROM  AgingInvoice WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString()).FirstOrDefault();
            }
            else
            {
                data = repo.db.Database.SqlQuery<int>("SELECT Count(CompanyID) FROM  AgingInvoice WHERE CompanyID=" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["CompanyID"].Value.ToString()).FirstOrDefault();
            }
            return data == 0;
        }

        private void FillVECostButtonColor()
        {
            try
            {
                DataTable RateDt = new DataTable();
                //DAL = new DataAccessLayer();

                string Query = "SELECT dbo.GetRate(JobList.CompanyID, JobTracking.TrackSubID) as  nRate FROM  JobList INNER JOIN JobTracking ON JobList.JobListID = JobTracking.JobListID LEFT OUTER JOIN  MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id WHERE (JobList.JobListID = " + selectedJobListID.ToString() + ") AND (JobTracking.BillState = 'Not Invoiced') AND (JobTracking.Status <> 'Pending') AND (JobTracking.IsDelete = 0 OR  JobTracking.IsDelete IS NULL)";

                decimal TotalAmount = 0M;
                //var result = repo.db.Database.SqlQuery<Double>(Query).ToList();

                var result = repo.db.Database.SqlQuery<Double>(Query).ToList();
                result = null;


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    result = repo2.db2.Database.SqlQuery<Double>(Query).ToList();
                }
                else
                {
                    result = repo.db.Database.SqlQuery<Double>(Query).ToList();
                }


                if (result.Count > 0)
                {
                    foreach (var rate in result)
                    {
                        TotalAmount = Convert.ToDecimal(TotalAmount + rate.ToString());
                    }

                    //'Update''
                    double Vecost = Program.GetTotalVECostAmount;

                    double VecostPecentage = (Vecost / (double)TotalAmount) * 100;
                    pnlShowTimeDataColor.Visible = true;
                    lblVECostAlert.Visible = true;

                    if (VecostPecentage >= 0 && VecostPecentage < 40)
                    {
                        pnlShowTimeDataColor.Visible = false;
                        lblVECostAlert.Visible = false;
                    }

                    if (VecostPecentage >= 40 && VecostPecentage < 60)
                    {
                        pnlShowTimeDataColor.ForeColor = Color.Green;
                    }

                    if (VecostPecentage >= 60 && VecostPecentage < 75)
                    {
                        pnlShowTimeDataColor.ForeColor = Color.Yellow;
                    }

                    if (VecostPecentage >= 75 && VecostPecentage < 85)
                    {
                        pnlShowTimeDataColor.ForeColor = Color.Orange;
                    }
                    if (VecostPecentage >= 85 && VecostPecentage < 100)
                    {
                        pnlShowTimeDataColor.ForeColor = Color.Red;
                    }
                    if (VecostPecentage == 100)
                    {
                        pnlShowTimeDataColor.ForeColor = Color.Black;
                    }
                }
                else
                {
                    pnlShowTimeDataColor.Visible = false;
                    lblVECostAlert.Visible = false;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void controlVisibility(bool flag)
        {
            pnlShowTimeSheetData.Visible = flag;
            btnShowTimeData.Enabled = !flag;
        }

        private DataTable GetManagerData()
        {
            string queryString = "SELECT  DISTINCT JobList.JobListID, JobList.JobNumber,JobList.Clienttext, Company.CompanyID, JobList.DateAdded AS Added, JobList.Description, JobList.Handler AS PM, JobList.Borough AS Town, JobList.Address, Contacts.FirstName + ' ' + Contacts.MiddleName + ' ' + Contacts.LastName AS Contacts, Contacts.EmailAddress, Contacts.ContactsID,   Company.CompanyName,JobList.ACContacts,JobList.ACEmail,JobList.OwnerName,JobList.OwnerAddress,JobList.OwnerPhone,JobList.OwnerFax,Company.CompanyNo, JobList.PMrv,     IsNull(JobList.IsDisable, 0) as IsDisable, IsNull(JobList.IsInvoiceHold, 0) as IsInvoiceHold, jd.InvoiceType AS TypicalInvoiceType, JobList.InvoiceClient, JobList.InvoiceContact,(Select dbo.ClientName(FirstName,MiddleName,LastName) FROM Contacts WHERE ContactsId LIKE jobList.InvoiceContact ) as InvoiceContactT ,JobList.InvoiceEmailAddress, JobList.InvoiceACContacts,(Select dbo.ClientName(FirstName,MiddleName,LastName) FROM Contacts WHERE ContactsId LIKE jobList.InvoiceACContacts ) as InvoiceACContactsT,JobList.InvoiceACEmail,CONVERT(INT,jd.TableVersionId) AS RateVersionId,jd.ServRate AS ServRate, IsNull(JobList.AdminInvoice, 0) as AdminInvoice FROM  JobList LEFT OUTER JOIN Contacts ON JobList.ContactsID = Contacts.ContactsID LEFT OUTER JOIN  Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN  JobTracking ON JobList.JobListID = JobTracking.JobListID INNER JOIN vwJobListDefaultValue jd ON JobList.JobListId=jd.JobListID     WHERE (JobList.IsDelete=0 or JobList.IsDelete is null)  AND (JobList.IsDisable = 0  OR JobList.IsDisable IS NULL) AND (JobList.IsInvoiceHold = 0 )  order by JobList.JobListID";

            //Dim queryString As String = "SELECT  DISTINCT    JobList.JobListID, JobList.JobNumber,JobList.Clienttext, Company.CompanyID, JobList.DateAdded, JobList.Description, JobList.Handler, JobList.Borough, JobList.Address, Contacts.FirstName + ' ' + Contacts.MiddleName + ' ' + Contacts.LastName AS Contacts, Contacts.EmailAddress, Contacts.ContactsID,   Company.CompanyName,JobList.ACContacts,JobList.ACEmail,JobList.OwnerName,JobList.OwnerAddress,JobList.OwnerPhone,JobList.OwnerFax,Company.CompanyNo, JobList.PMrv,     IsNull(JobList.IsDisable, 0) as IsDisable, IsNull(JobList.IsInvoiceHold, 0) as IsInvoiceHold, jd.InvoiceType AS TypicalInvoiceType, JobList.InvoiceClient, JobList.InvoiceContact,(Select dbo.ClientName(FirstName,MiddleName,LastName) FROM Contacts WHERE ContactsId LIKE jobList.InvoiceContact ) as InvoiceContactT ,JobList.InvoiceEmailAddress, JobList.InvoiceACContacts,(Select dbo.ClientName(FirstName,MiddleName,LastName) FROM Contacts WHERE ContactsId LIKE jobList.InvoiceACContacts ) as InvoiceACContactsT,JobList.InvoiceACEmail,CONVERT(INT,jd.TableVersionId) AS RateVersionId,jd.ServRate AS ServRate, IsNull(JobList.AdminInvoice, 0) as AdminInvoice FROM  JobList LEFT OUTER JOIN            Contacts ON JobList.ContactsID = Contacts.ContactsID LEFT OUTER JOIN      Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN        JobTracking ON JobList.JobListID = JobTracking.JobListID INNER JOIN vwJobListDefaultValue jd ON JobList.JobListId=jd.JobListID     WHERE (JobList.IsDelete=0 or JobList.IsDelete is null)  and Handler='SV' AND (JobList.IsDisable = 0  OR JobList.IsDisable IS NULL) AND (JobList.IsInvoiceHold = 0 )  order by JobList.JobListID  "


            //dtJL = StMethod.GetListDT<DueInvoiceColumns>(queryString);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtJL = StMethod.GetListDTNew<DueInvoiceColumns>(queryString);
            }
            else
            {
                dtJL = StMethod.GetListDT<DueInvoiceColumns>(queryString);
            }

            //'main Manger grid data
            // ManagerMainGrid = dtJL
            //dtJL.Columns["JobListID"].Visible = False
            dtJL.Columns["JobNumber"].ColumnName = "Job#";
            dtJL.Columns["Clienttext"].ColumnName = "Client#";
            dtJL.Columns["ACContacts"].ColumnName = "AC Contacts";
            dtJL.Columns["ACEmail"].ColumnName = "AC Email";
            dtJL.Columns["OwnerName"].ColumnName = "Owner Name";
            dtJL.Columns["OwnerAddress"].ColumnName = "Owner Address";
            dtJL.Columns["OwnerPhone"].ColumnName = "Owner Phone";
            dtJL.Columns["OwnerFax"].ColumnName = "Owner Fax";
            dtJL.Columns["IsDisable"].ColumnName = "Disabled";
            dtJL.Columns["IsInvoiceHold"].ColumnName = "Invoice Hold";

            return (dtJL);
        }

        private object createManagerRows(DataTable dt, HSSFCellStyle  borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)
        {

            try
            {


          
            string jobListid = dt.Rows[rowindex]["JobListID"].ToString();
            //dt.Columns.RemoveAt(ColumnIndex)

            //add column header
            var sheetRow = sheet.CreateRow(sheetRowIndex);
            //sheet.AutoSizeColumn(sheetRowIndex)
            int ColumnIndex = 0;

            foreach (DataColumn header in dt.Columns)
            {
                    //CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                    CreateCellNew(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                     

                    //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                    ColumnIndex = ColumnIndex + 1;
                //sheet.AutoSizeColumn(sheetRowIndex)
            }
            // start end cell
            //Dim startCell As String = "A" = sheetRowIndex
            //Dim EndCell As String = "AI" + sheetRowIndex

            //-----------------------------------------
            //Add column values 
            sheetRowIndex = sheetRowIndex + 1;
            sheetRow = sheet.CreateRow(sheetRowIndex);
            ColumnIndex = 0;
            foreach (DataColumn header in dt.Columns)
            {
                string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();
                sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                ColumnIndex = ColumnIndex + 1;
                //sheet.AutoSizeColumn(sheetRowIndex)
            }

            sheetRowIndex = sheetRowIndex + 1;
            //Get Job id
            //Dim jobListid As String = dt.Rows[rowindex).Item("JobListID").ToString()

            //set Prerequirment data 
            //------------------------------------------------------
            DataTable SubDatatable = GetPreRequirmentData(jobListid);

                //SetSheetDatatable(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);
                SetSheetDatatableNew(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);

                 


                //'-------------------------------------------------------

                //'set PermitRequest data 
                //'-------------------------------------------------------
                DataTable SubPermitRequestTable = GetPermitRequestData(jobListid);


                //SetSheetDatatable(SubPermitRequestTable, borderedCellStyle, ref sheetRowIndex, ref sheet);
                SetSheetDatatableNew(SubPermitRequestTable, borderedCellStyle, ref sheetRowIndex, ref sheet);
                 


                // ''-------------------------------------------------------

                // ''set Notes/coumunication data 
                // ''-------------------------------------------------------
                DataTable SubNotesTable = GeNotesCommisionData(jobListid);
                //SetSheetDatatable(SubNotesTable, borderedCellStyle, ref sheetRowIndex, ref sheet);
                SetSheetDatatableNew(SubNotesTable, borderedCellStyle, ref sheetRowIndex, ref sheet);
                 



                //-------------------------------------------------------
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return null;
        }

        private DataTable GeNotesCommisionData(string jobListID)
        {
            string queryString = "SELECT JobTracking.TaskHandler AS TM,JobTracking.Track,JobTracking.TrackSub, JobTracking.Comments,JobTracking.Status,JobTracking.BillState , JobTracking.AddDate AS Added,JobTracking.InvOvr  FROM  JobTracking INNER JOIN    JobList ON JobTracking.JobListID = JobList.JobListID where JobTracking.Track in (select Trackname from MasterTrackSet where TrackSet='Notes/Communication')  and  JobTracking.JobListID= " + jobListID + " and (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)  order by JobTrackingID";
            
            //dtJL = StMethod.GetListDT<NotesCommisionData>(queryString);


            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtJL = StMethod.GetListDTNew<NotesCommisionData>(queryString);
            }
            else
            {
                dtJL = StMethod.GetListDT<NotesCommisionData>(queryString);
            }

            return dtJL;
        }
        private DataTable GetPreRequirmentData(string jobListID)
        {
            string queryString = "SELECT JobTracking.TaskHandler AS TM,JobTracking.Track,JobTracking.TrackSub, JobTracking.Comments,JobTracking.Status,JobTracking.Obtained,JobTracking.AddDate AS Added,JobTracking.InvOvr  FROM  JobTracking INNER JOIN    JobList ON JobTracking.JobListID = JobList.JobListID where JobTracking.Track in (SELECT Trackname FROM MasterTrackSet WHERE TrackSet='PreRequirements')   and  JobTracking.JobListID= " + jobListID + " and (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)  order by JobTrackingID";

            // Dim queryString As String = "SELECT JobList.JobNumber,JobTracking.TaskHandler AS TM,JobTracking.Track,JobTracking.TrackSub, JobTracking.Comments,JobTracking.Status,JobTracking.Submitted, JobTracking.Obtained,JobTracking.Expires,JobTracking.BillState , JobTracking.AddDate, JobTracking.NeedDate,     JobTracking.JobTrackingID,JobTracking.TrackSubID,JobTracking.InvOvr  FROM  JobTracking INNER JOIN    JobList ON JobTracking.JobListID = JobList.JobListID where JobTracking.Track in (SELECT Trackname FROM MasterTrackSet WHERE TrackSet='PreRequirements')   and  JobTracking.JobListID= " + jobListID + " and (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)  order by JobTrackingID"
            
            //dtJL = StMethod.GetListDT<PreRequirmentData>(queryString);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                dtJL = StMethod.GetListDTNew<PreRequirmentData>(queryString);

            }
            else
            {
                dtJL = StMethod.GetListDT<PreRequirmentData>(queryString);
            }

            return dtJL;
        }

        private DataTable GetPermitRequestData(string jobListID)
        {
            string queryString = "SELECT JobTracking.TaskHandler AS TM, JobTracking.Track, JobTracking.TrackSub, JobTracking.Comments, JobTracking.Status, JobTracking.Submitted, JobTracking.Obtained, JobTracking.Expires, JobTracking.FinalAction, JobTracking.BillState, JobTracking.AddDate AS Added,JobTracking.InvOvr FROM JobTracking INNER JOIN JobList ON JobTracking.JobListID = JobList.JobListID WHERE (JobTracking.Track IN(SELECT TrackName FROM MasterTrackSet WHERE (TrackSet = 'Permits/Required/Inspection'))) AND (JobTracking.JobListID = " + jobListID + " ) AND (JobTracking.IsDelete = 0 OR JobTracking.IsDelete IS NULL) order by JobTrackingID";

            // Dim queryString As String = "SELECT  JobList.JobNumber, JobTracking.TaskHandler AS TM, JobTracking.Track, JobTracking.TrackSub, JobTracking.Comments, JobTracking.Status, JobTracking.Submitted, JobTracking.Obtained, JobTracking.Expires, JobTracking.FinalAction, JobTracking.BillState, JobTracking.AddDate, JobTracking.NeedDate, JobTracking.JobTrackingID, JobTracking.TrackSubID,JobTracking.InvOvr FROM JobTracking INNER JOIN JobList ON JobTracking.JobListID = JobList.JobListID WHERE (JobTracking.Track IN(SELECT TrackName FROM MasterTrackSet WHERE (TrackSet = 'Permits/Required/Inspection'))) AND (JobTracking.JobListID = " + jobListID + " ) AND (JobTracking.IsDelete = 0 OR JobTracking.IsDelete IS NULL) order by JobTrackingID"
            
            //dtJL = StMethod.GetListDT<PermitRequestData>(queryString);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {


                 dtJL = StMethod.GetListDTNew<PermitRequestData>(queryString);
            }
            else
            {
                 dtJL = StMethod.GetListDT<PermitRequestData>(queryString);
            }

            return dtJL;
        }
        private void CreateCell(IRow CurrentRow, int CellIndex, string Value, XSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
        }

        private void CreateCellNew(IRow CurrentRow, int CellIndex, string Value, HSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
        }

        private object SetSheetDatatableNew(DataTable dt, HSSFCellStyle borderedCellStyle, ref Int32 sheetRowIndex, ref ISheet sheet)
        {

            try
            {

                if (dt.Columns.Count > 0)
                {
                    sheetRowIndex = sheetRowIndex + 1;
                    int ColumnIndex = 1;
                    var sheetRow = sheet.CreateRow(sheetRowIndex);
                    foreach (DataColumn header in dt.Columns)
                    {
                        //CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                        CreateCellNew(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                         
                        //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                        ColumnIndex = ColumnIndex + 1;
                    }
                    sheetRowIndex = sheetRowIndex + 1;
                }

                if (dt.Rows.Count > 0)
                {
                    //sheetRowIndex = sheetRowIndex + 1
                    for (int Rowindex = 1; Rowindex <= dt.Rows.Count; Rowindex++)
                    {
                        //add column header
                        var sheetRow = sheet.CreateRow(sheetRowIndex);
                        int ColumnIndex = 1;

                        //If Rowindex = 1 Then
                        //    For Each header As DataColumn In dt.Columns
                        //        sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                        //        ColumnIndex = ColumnIndex + 1
                        //    Next
                        //    sheetRowIndex = sheetRowIndex + 1
                        //End If

                        //-----------------------------------------
                        //Add column values 
                        //sheetRow = sheet.CreateRow(sheetRowIndex)
                        ColumnIndex = 1;
                        foreach (DataColumn Columns in dt.Columns)
                        {
                            string columnvalue = dt.Rows[Rowindex - 1][ColumnIndex - 1].ToString();
                            sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                            ColumnIndex = ColumnIndex + 1;
                        }
                        sheetRowIndex = sheetRowIndex + 1;
                    }
                    sheetRowIndex = sheetRowIndex + 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return null;
        }

        private object SetSheetDatatable(DataTable dt, XSSFCellStyle borderedCellStyle, ref Int32 sheetRowIndex, ref ISheet sheet)
        {

            try 
            { 
           
            if (dt.Columns.Count > 0)
            {
                sheetRowIndex = sheetRowIndex + 1;
                int ColumnIndex = 1;
                var sheetRow = sheet.CreateRow(sheetRowIndex);
                foreach (DataColumn header in dt.Columns)
                {
                    CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                    //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                    ColumnIndex = ColumnIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }

            if (dt.Rows.Count > 0)
            {
                //sheetRowIndex = sheetRowIndex + 1
                for (int Rowindex = 1; Rowindex <= dt.Rows.Count; Rowindex++)
                {
                    //add column header
                    var sheetRow = sheet.CreateRow(sheetRowIndex);
                    int ColumnIndex = 1;

                    //If Rowindex = 1 Then
                    //    For Each header As DataColumn In dt.Columns
                    //        sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                    //        ColumnIndex = ColumnIndex + 1
                    //    Next
                    //    sheetRowIndex = sheetRowIndex + 1
                    //End If

                    //-----------------------------------------
                    //Add column values 
                    //sheetRow = sheet.CreateRow(sheetRowIndex)
                    ColumnIndex = 1;
                    foreach (DataColumn Columns in dt.Columns)
                    {
                        string columnvalue = dt.Rows[Rowindex - 1][ColumnIndex - 1].ToString();
                        sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                        ColumnIndex = ColumnIndex + 1;
                    }
                    sheetRowIndex = sheetRowIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return null;
        }

        #endregion

        private void grvJobList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pnlShowTimeSheetData_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grvJobList_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            try
            {
                //if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                //{



                //}

              // MessageBox.Show("Row => " + anError.RowIndex +  "  Column => " + anError.ColumnIndex + " Error = > " + anError.Exception.Message.ToString());

                //MessageBox.Show(anError.Exception.Message.ToString());



                //if (grvJobList.Columns[anError.ColumnIndex].Name == "DateAdded")


                    
                //if (grvJobList.Columns.inde == 5)
                if (grvJobList.Columns[anError.ColumnIndex].Index == 5)
                {
                    //if (isDiable(((DataGridView)sender).Rows[anError.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)
                    //{
                    //    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    //    DataGridViewComboBoxCell tempVar = (DataGridViewComboBoxCell)((DataGridView)sender)[anError.ColumnIndex, anError.RowIndex];
                    //    tempVar.DataSource = repo.GetMasterItemTM();

                    //    tempVar.DisplayMember = "cTrack";
                    //}

                    //DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    //DataGridViewComboBoxCell tempVar = (DataGridViewComboBoxCell)((DataGridView)sender)[anError.ColumnIndex, anError.RowIndex];

                    //DataGridViewTextBoxCell cmbTMCell = new DataGridViewTextBoxCell();
                    //DataGridViewTextBoxCell tempVar = (DataGridViewTextBoxCell)((DataGridView)sender)[anError.ColumnIndex, anError.RowIndex];
                    //tempVar.Value = TestingDate;

                    //grvJobList.Rows[anError.RowIndex].Cells[anError.ColumnIndex].Value = TestingDate;



                }


                //MessageBox.Show(anError.RowIndex + " " + anError.ColumnIndex);
                //MessageBox.Show("Error happened " + anError.Context.ToString());

                //anError.ThrowException = false;



                //if (anError.Exception.ToString() == "String was not recognized as a valid DateTime")
                //{
                //    //MessageBox.Show("Commit error");

                //}


                //if (anError.Context == DataGridViewDataErrorContexts.Commit)
                //{
                //    MessageBox.Show("Commit error");
                //}
                //if (anError.Context == DataGridViewDataErrorContexts.CurrentCellChange)
                //{
                //    MessageBox.Show("Cell change");
                //}
                //if (anError.Context == DataGridViewDataErrorContexts.Parsing)
                //{
                //    MessageBox.Show("parsing error");
                //}
                //if (anError.Context == DataGridViewDataErrorContexts.LeaveControl)
                //{
                //    MessageBox.Show("leave control error");
                //}


                //if ((anError.Exception) is ConstraintException)
                //{
                //    DataGridView view = (DataGridView)sender;
                //    view.Rows[anError.RowIndex].ErrorText = "an error";
                //    view.Rows[anError.RowIndex].Cells[anError.ColumnIndex].ErrorText = "an error";

                //    anError.ThrowException = false;
                //}

            }
            catch (Exception ex)
            {

            }
        }

        private void grvJobList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                //if (grvJobList.Columns[e.ColumnIndex].Name == "Contacts")

                //if(grvJobList.Columns[grvJobList.CurrentCell.ColumnIndex].Name == "Contacts")
                ////if(grvJobList.CurrentCell.ColumnIndex == 0)
                //{
                //    // Check box column
                //    //ComboBox comboBox = e.Control as ComboBox;
                //    //comboBox.SelectedIndexChanged += new EventHandler(comboBox_SelectedIndexChanged);
                //}            
            }
            catch (Exception ex)
            {

            }
        }

        void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int itesmcount = ((ComboBox)sender).Items.Count;


            //int selectedIndex = ((ComboBox)sender).SelectedIndex;
            //string selectedtesxt = ((ComboBox)sender).SelectedItem.ToString();
            ////MessageBox.Show("Selected Index = " + selectedIndex);
            //MessageBox.Show("Selected itmes = " + selectedtesxt);


            //if (itesmcount > 0)
            //{

            //    int selectedIndex = ((ComboBox)sender).SelectedIndex;
            //    string selectedtesxt = ((ComboBox)sender).SelectedItem.ToString();
            //    //MessageBox.Show("Selected Index = " + selectedIndex);
            //    MessageBox.Show("Selected itmes = " + selectedtesxt);
            //}

            //if (itesmcount != -1)
            //{

            //    int selectedIndex = ((ComboBox)sender).SelectedIndex;

            //    if (string.IsNullOrEmpty(((ComboBox)sender).SelectedItem.ToString()))
            //    { 

            //    }
            //    else
            //    { 
            //    string selectedtesxt = ((ComboBox)sender).SelectedItem.ToString();
            //    //MessageBox.Show("Selected Index = " + selectedIndex);
            //    MessageBox.Show("Selected itmes = " + selectedtesxt);
            //    }
            //}
        }

        private void grvNotesCommunication_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 14)
                {
                    ////MessageBox.Show(e.Value.ToString());
                    //String value = e.Value.ToString();
                    //if ((value != null))
                    //{
                    //    e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    e.FormattingApplied = true;

                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}


                    //String value = e.Value as string;

                    //string inputString;
                    //DateTime dDate;

                    //inputString = e.Value.ToString();
                    //if (DateTime.TryParse(inputString, out dDate))
                    //{
                    //    //String.Format("{0:d/MM/yyyy}", dDate);

                    //    e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                    //    e.FormattingApplied = true;
                    //}
                    //else
                    //{


                    //}




                    //String value = e.Value as string;

                    //string inputString;
                    //DateTime dDate;

                    //inputString = e.Value.ToString();
                    //if (DateTime.TryParse(inputString, out dDate))
                    //{
                    //    String.Format("{0:d/MM/yyyy}", dDate);

                    //    e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                    //    e.FormattingApplied = true;
                    //}
                    //else
                    //{


                    //}

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void grvJobList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {

                    //String value = e.Value as string;

                    //if ((value != null))
                    //{                        
                    //    e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    e.FormattingApplied = true;

                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}


                    String value = e.Value as string;

                    string inputString;
                    DateTime dDate;

                    inputString = e.Value.ToString();
                    if (DateTime.TryParse(inputString, out dDate))
                    {
                        //String.Format("{0:d/MM/yyyy}", dDate);

                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                        e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        //e.Value = string.Format("{0:dd/Mm/yyyy hh:mm tt}", dDate);
                        //e.FormattingApplied = true;

                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Formate " + ex.Message.ToString());
            }
        }



        private void grvNotesCommunication_DataMemberChanged(object sender, EventArgs e)
        {

        }

        private void grvJobList_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {

                    //String value = e.Value as string;

                    //if ((value != null))
                    //{                        
                    //    e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    e.FormattingApplied = true;

                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}


                    //String value = e.Value as string;

                    //string inputString;
                    //DateTime dDate;

                    //inputString = e.Value.ToString();
                    //if (DateTime.TryParse(inputString, out dDate))
                    //{
                    //    //String.Format("{0:d/MM/yyyy}", dDate);

                    //    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                    //    e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                    //    e.ParsingApplied = true;
                    //    //e.FormattingApplied = true;
                    //}
                    //else
                    //{
                    //    e.Value = string.Format("{0:dd/MM/yyyy hh:mm tt}", value);
                    //    e.ParsingApplied = true;

                    //}


                }
            }
            catch (Exception ex)
            {

            }
        }

        private void grvJobList_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 5)
            //    {



            //        //String value = e.ColumnIndex as string;

            //        string inputString;
            //        DateTime dDate;

            //        //inputString = e.Value.ToString();
            //        inputString = e.FormattedValue.ToString();



            //        if (DateTime.TryParse(inputString, out dDate))
            //        {
            //            //String.Format("{0:d/MM/yyyy}", dDate);

            //            //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

            //            e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
            //            //e.FormattingApplied = true;




            //        }
            //        else
            //        {
            //            //string s = "";
            //        }


            //    }


            //}
            //catch (Exception ex)
            //{

            //}

           


        }


        //public DateTime? ToDate(this string dateTimeStr, params string[] dateFmt)
        //{
        //    // example: var dt = "2011-03-21 13:26".ToDate(new string[]{"yyyy-MM-dd HH:mm", 
        //    //                                                  "M/d/yyyy h:mm:ss tt"});
        //    // or simpler: 
        //    // var dt = "2011-03-21 13:26".ToDate("yyyy-MM-dd HH:mm", "M/d/yyyy h:mm:ss tt");
        //    const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
        //    if (dateFmt == null)
        //    {
        //        var dateInfo = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat;
        //        dateFmt = dateInfo.GetAllDateTimePatterns();
        //    }
        //    var result = DateTime.TryParseExact(dateTimeStr, dateFmt, CultureInfo.InvariantCulture,
        //                   style, out var dt) ? dt : null as DateTime?;
        //    return result;
        //}

        private void grvJobList_CellLeave(object sender, DataGridViewCellEventArgs e)
         {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    //MessageBox.Show("hello");

                    //string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;


                    //String value2 = null;

                    //string test = grvJobList.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString();

                    //string inputString = "2000-02-02";
                    //DateTime dDate;

                    //if (DateTime.TryParse(test, out dDate))
                    //{
                    //    String.Format("{0:d/MM/yyyy}", dDate);

                    //    grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:d/MM/yyyy}", test);

                    //}
                    //else
                    //{

                    //    DateTime firstDay = DateTime.ParseExact(test, "MM/dd/yyyy hh:mm tt", CultureInfo.CurrentCulture);


                    //    grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = firstDay;

                    //    //grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = String.Format("{0:MM/d/yyyy hh:mm tt}", test);
                    //    //Console.WriteLine("Invalid"); // <-- Control flow goes here
                    //}






                    String value = grvJobList.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString() as string;

                    string inputString;
                    DateTime dDate=DateTime.Now;

                    inputString = grvJobList.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString();

                    if (DateTime.TryParse(inputString, out dDate))
                    {
                        String.Format("{0:d/MM/yyyy}", dDate);

                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        //e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                        //e.FormattingApplied = true;

                        grvJobList.Rows[e.RowIndex].Cells[5].Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                    }
                    else
                    {
                        string test1 = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                        string test2 = string.Format("{0:MM/dd/yyyy hh:mm tt}", value);


                        //DateTime date2 =  DateTime.ParseExact(test2, "dd/MM/yyyy hh:mm tt",
                        //                        CultureInfo.InvariantCulture);

                        //DateTime date = DateTime.ParseExact(test2, "dd/MM/yyyy hh:mm tt", null);

                        //grvJobList.Rows[e.RowIndex].Cells[5].Value = date;

                        //DateTime d = DateTime.Parse(test2, System.Globalization.DateTimeFormatInfo.InvariantInfo);


                        //grvJobList.Rows[e.RowIndex].Cells[5].Value = d;

                        //grvJobList.Rows[e.RowIndex].Cells[5].Value = firstDay;

                        //grvJobList.Rows[e.RowIndex].Cells[5].Value = test2;

                        //DateTime.Parse

                        //grvJobList.Rows[e.RowIndex].Cells[5].Value = Convert.ToDateTime(test2);
                        //grvJobList.Rows[e.RowIndex].Cells[5].Value = string.Format("{0:DD/mm/yyyy hh:mm tt}", test2);



                        //string CultureDateTimeFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortTimePattern;
                        //string DateFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

                        //string TimeFormat = CultureInfo.CurrentUICulture.DateTimeFormat.LongTimePattern;
                        //string DateTimeFormat = "DateFormat TimeFormat";

                        //DateTime dt = DateTime.ParseExact(inputString, DateTimeFormat, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);

                        //grvJobList.Rows[e.RowIndex].Cells[5].Value = dt;
                    }


                    //string value = e.Value as string;

                    //string inputString;
                    //DateTime dDate;

                    //inputString = e.Value.ToString();
                    //if (DateTime.TryParse(inputString, out dDate))
                    //{
                    //    //String.Format("{0:d/MM/yyyy}", dDate);

                    //    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                    //    e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                    //    e.FormattingApplied = true;
                    //}
                    //else
                    //{


                    //}

                    //if (sysUIFormat == "M/d/yyyy")
                    //{
                    //    string filter = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString().ToString();
                    //    string[] filterRemove = filter.Split('-');

                    //    string Date1 = filterRemove[0];
                    //    string Month1 = filterRemove[1];
                    //    string TempString = filterRemove[2];

                    //    string[] filterRemovePart2 = TempString.Split(' ');

                    //    //string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];
                    //    string FindalDate = Month1 + "-" + Date1 + "-" + filterRemovePart2[0];

                    //    value2 = FindalDate;
                    //}

                    //if (sysUIFormat == "d/M/yyyy")
                    //{
                    //    string filter = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString().ToString();
                    //    string[] filterRemove = filter.Split('-');

                    //    string Date1 = filterRemove[0];
                    //    string Month1 = filterRemove[1];
                    //    string TempString = filterRemove[2];

                    //    string[] filterRemovePart2 = TempString.Split(' ');

                    //    //string FindalDate = Month1 + "-" + Date1 + "-" + filterRemovePart2[0];
                    //    string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];

                    //    value2 = FindalDate;
                    //}

                    //grvJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = value2;

                    //TestingDate = grvJobList.Rows[e.RowIndex].Cells[5].Value.ToString().ToString();
                    TestingDate = grvJobList.Rows[e.RowIndex].Cells[5].EditedFormattedValue.ToString();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grvPermitsRequiredInspection_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void grvPermitsRequiredInspection_DataMemberChanged(object sender, EventArgs e)
        {

        }

        private void grvPreRequirments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void grvPreRequirments_DataMemberChanged(object sender, EventArgs e)
        {

        }

        private void grvPreRequirments_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            if (grvPreRequirments.Columns[e.ColumnIndex].Name == "cmbTaskHandler")
            {
                if (isDiable(((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()) == true)
                {
                    DataGridViewComboBoxCell cmbTMCell = new DataGridViewComboBoxCell();
                    DataGridViewComboBoxCell tempVar = (DataGridViewComboBoxCell)((DataGridView)sender)[e.ColumnIndex, e.RowIndex];

                    //tempVar.DataSource = repo.GetMasterItemTM();

                    //tempVar.DisplayMember = "cTrack";

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        tempVar.DataSource = repo2.GetMasterItemTMNew();

                        tempVar.DisplayMember = "cTrack";

                    }
                    else
                    {
                        tempVar.DataSource = repo.GetMasterItemTM();

                        tempVar.DisplayMember = "cTrack";

                    }

                }
            }
        }
    }
}

//public sealed class ContactName
//{
//    public string Contact { get; set; }
//}