//using Common;
using Commen2;
using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using DevComponents.DotNetBar;
using JobTracker.Application_Tool;
using JobTracker.Calender;
using JobTracker.Classes;
using JobTracker.Document_Generator;
using JobTracker.InvoiceReport;
using JobTracker.JobTrackingForm;
using JobTracker.Login;
using JobTracker.MasterTackListItem;
using JobTracker.PDFeditTools;
using JobTracker.TimeSheetData;
using JobTracker.VEUserSettingInvoiceEdit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static JobTracker.cGlobal;

namespace JobTracker.JobTrackingMDIForm
{
    public partial class JobAndTrackingMDI : Form
    {
        #region "Global variable"
        public string EmailTable;
        public string TableUpdateRecord = "0";
        public string TableInsertRecord = "0";
        public string TableDeleteRecord = "0";
        public string SenderEmailAddress;
        public string SenderEmailPassword;
        public bool SendEmailSuccessful;
        public Form frm = new Form();
        public int ScreenWidth;
        public int ScreenHeight;
        public Int64 JobID;
        public bool admintools;
        public char ReportStatus;
        public Int16 ColorId;
        public bool CalEmailRem;
        public string InvoiceEmailAddress;
        public double TotalVECostAmount;
        public event LoginChangeEventHandler LoginChange;

        public delegate void LoginChangeEventHandler(object sender, EventArgs e);
        #endregion
        
        public JobAndTrackingMDI()
        {
            InitializeComponent();
        }

        #region Events
        private void Manager_Click(System.Object sender, System.EventArgs e)
        {
            CreateFromandtab(JobStatus.Instance);
        }
        private void JobAndTrackingMDI_Load(object sender, EventArgs e)
        {
            //string checktext = lblLogin.Text.ToString();

            ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            ScreenHeight = Screen.PrimaryScreen.Bounds.Height;

            GetSenderEmailaddress();

            if (DataVarifReminderShedule() == "H")
            {
                timerGet.Interval = 3600000;
            }
            lblVersion.Text = "Version:-" + cProgramInfo.sApplicationVersion;
            this.Text = "Job Tracker (" + lblVersion.Text + ")";
            NtyicnJT.Text = "Job Traking (JT " + lblVersion.Text.Trim() + ")";
            NtyicnJT.BalloonTipText = "JT Activated";
            NtyicnJT.ShowBalloonTip(3000);
            EnableTimer();
            //backWorkerLoadForm.RunWorkerAsync()
            
            Manager_Click(sender, e);


            //Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Fixed3D
            //Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            UpdateCheckNewVersion();
            if (ConnectionStringSetting.ConnectionStringsSetting.IsLocalDatabase == true)
            {
                MessageBox.Show("This Time you connected Local data base", "DataBase Connection ");
            }
            //MessageBox.Show(lblLogin.Text.ToString ());

        }
        public object LoginformObject { get; set; }
        private void JobAndTrackingMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            Application.Exit(e);
            // CType(LoginformObject, frmJTLogin).Show()
            if (LoginformObject != null)
            {
                //(FrmJTLogin)LoginformObject.ShowInTaskbar = true;
                //(FrmJTLogin)LoginformObject.Close();
            }
            e.Cancel = false;
            //NtyicnJT.Visible = false;
        }
        private void NtyicnJT_MouseClick(object sender, MouseEventArgs e)
        {
            //if (e.Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    Drawing.Point point = new Drawing.Point(Control.MousePosition);
            //    CMSNotify.Show(point);
            //}
            //else if (e.Button == MouseButtons.Left)
            //{
            //    this.ShowInTaskbar = true;
            //    this.WindowState = FormWindowState.Maximized;


            //    if (!ActiveMdiChild == null)
            //        this.ActiveMdiChild.WindowState = FormWindowState.Maximized;
            //}
        }
        private void TimerDateTime_Tick(object sender, EventArgs e)
        {
            try
            {
                lblDate.Text = "DATE:-" + string.Format(DateTime.Now.ToString("MM-dd-yyyy"));
                lblTime.Text = "TIME:-" + string.Format(DateTime.Now.ToString("hh:mm:ss tt"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void timerGet_Tick(System.Object sender, System.EventArgs e)
        {
            switch (DataVarifReminderShedule())
            {
                case "H":
                    {
                        //If BackWorkerEmail.IsBusy = False Then
                        //CrateLogfileHeader()
                        //BackWorkerEmail.RunWorkerAsync()
                        //End If

                        //Dim Frmvarif As New FrmVarifyWebdata 'open form agen and agen when click the email due invoice in manage form (Change by @g)
                        //Frmvarif.Show()
                        break;
                    }
                case "D":
                    {
                        //********Daily******************************
                        DateTime dateTime = Convert.ToDateTime("5:00:00 PM");
                        DateTime TodayTime = Convert.ToDateTime((System.DateTime.Now).ToLongTimeString());
                        // getUpdateTableName()
                        if (TodayTime == dateTime || TodayTime > dateTime)
                        {


                            //if (StMethod.GetSingleInt("SELECT Count(*) as count FROM Appsetting WHERE Comparedate in ('" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')") == 0)
                            //{
                            //    //If BackWorkerEmail.IsBusy = False Then
                            //    //CrateLogfileHeader()
                            //    //BackWorkerEmail.RunWorkerAsync()
                            //    //'End If
                            //    //If BackWorkerEmail.IsBusy = False Then
                            //    //    ChkDateMail.InsertRecord("INSERT INTO EmailRecord(UploadDate) Values('" & Format(System.DateTime.Now, "MM/dd/yyyy") & "')")
                            //    //End If

                            //    //Dim Frmvarif As New FrmVarifyWebdata 'this chenage by@G
                            //    //Frmvarif.Show()
                            //}
                            //else
                            //{
                            //    timerGet.Enabled = false;
                            //    timerGet.Stop();
                            //}



                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                if (StMethod.GetSingleIntNew("SELECT Count(*) as count FROM Appsetting WHERE Comparedate in ('" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')") == 0)
                                {
                                    //If BackWorkerEmail.IsBusy = False Then
                                    //CrateLogfileHeader()
                                    //BackWorkerEmail.RunWorkerAsync()
                                    //'End If
                                    //If BackWorkerEmail.IsBusy = False Then
                                    //    ChkDateMail.InsertRecord("INSERT INTO EmailRecord(UploadDate) Values('" & Format(System.DateTime.Now, "MM/dd/yyyy") & "')")
                                    //End If

                                    //Dim Frmvarif As New FrmVarifyWebdata 'this chenage by@G
                                    //Frmvarif.Show()
                                }
                                else
                                {
                                    timerGet.Enabled = false;
                                    timerGet.Stop();
                                }

                            }
                            else
                            {
                                if (StMethod.GetSingleInt("SELECT Count(*) as count FROM Appsetting WHERE Comparedate in ('" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')") == 0)
                                {
                                    //If BackWorkerEmail.IsBusy = False Then
                                    //CrateLogfileHeader()
                                    //BackWorkerEmail.RunWorkerAsync()
                                    //'End If
                                    //If BackWorkerEmail.IsBusy = False Then
                                    //    ChkDateMail.InsertRecord("INSERT INTO EmailRecord(UploadDate) Values('" & Format(System.DateTime.Now, "MM/dd/yyyy") & "')")
                                    //End If

                                    //Dim Frmvarif As New FrmVarifyWebdata 'this chenage by@G
                                    //Frmvarif.Show()
                                }
                                else
                                {
                                    timerGet.Enabled = false;
                                    timerGet.Stop();
                                }
                            }

                        

                        }
                        else
                        {
                            timerGet.Enabled = false;
                            timerGet.Stop();
                        }
                        //***********************************************************
                        break;
                    }
                case "W":
                    {
                        //'**********************************wEEKLY*************
                        // Dim LastEmailDate As Date
                        //LastEmailDate = Format(ChkDateMail.Filldatatable("SELECT * FROM EmailRecord Where id=(SELEC  ISNull(MAX(id),0) as id FROM EmailRecord)").Rows[0).Item("UploadDate").ToString(), "MM/dd/yyyy")
                        System.DateTime TodayDate = Convert.ToDateTime(System.DateTime.Now.ToString("MM/dd/yyyy"));
                        int CurrentWeek = Microsoft.VisualBasic.DateAndTime.DatePart("ww", System.DateTime.Now.ToString());
                        DateTime dateTime = Convert.ToDateTime("05:00:00 AM");
                        DateTime TodayTime = Convert.ToDateTime((System.DateTime.Now).ToLongTimeString());


                        //int oldWeek = Microsoft.VisualBasic.DateAndTime.DatePart("ww", StMethod.GetListDT<dtoCompareDate>("SELECT Comparedate FROM Appsetting Where Appid=(SELECT ISNull(MAX(Appid),0) as Appid FROM AppSetting)").Rows[0]["Comparedate"].ToString());


                        //int oldWeek = Microsoft.VisualBasic.DateAndTime.DatePart("ww", StMethod.GetListDT<dtoCompareDate>("SELECT Comparedate FROM Appsetting Where Appid=(SELECT ISNull(MAX(Appid),0) as Appid FROM AppSetting)").Rows[0]["Comparedate"].ToString());

                        int oldWeek;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            oldWeek = Microsoft.VisualBasic.DateAndTime.DatePart("ww", StMethod.GetListDTNew<dtoCompareDate>("SELECT Comparedate FROM Appsetting Where Appid=(SELECT ISNull(MAX(Appid),0) as Appid FROM AppSetting)").Rows[0]["Comparedate"].ToString());
                        }
                        else
                        {
                            oldWeek = Microsoft.VisualBasic.DateAndTime.DatePart("ww", StMethod.GetListDT<dtoCompareDate>("SELECT Comparedate FROM Appsetting Where Appid=(SELECT ISNull(MAX(Appid),0) as Appid FROM AppSetting)").Rows[0]["Comparedate"].ToString());
                        }

                        if ((TodayDate.DayOfWeek == (System.DayOfWeek)1 || System.DateTime.Today.DayOfWeek > (System.DayOfWeek)1) && CurrentWeek > oldWeek)
                        {


                            if (TodayTime == dateTime || TodayTime > dateTime)
                            {


                                //if (StMethod.GetSingleInt("SELECT Count(*) as count FROM Appsetting WHERE Comparedate in ('" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')") == 0)
                                //{
                                //    //If BackWorkerEmail.IsBusy = False Then
                                //    //CrateLogfileHeader()
                                //    //BackWorkerEmail.RunWorkerAsync()
                                //    //If

                                //    //Dim Frmvarif As New FrmVarifyWebdata this comment by @G
                                //    //Frmvarif.Show()
                                //}
                                //else
                                //{
                                //    timerGet.Enabled = false;
                                //    timerGet.Stop();
                                //}



                                if (Properties.Settings.Default.IsTestDatabase == true)
                                {

                                    if (StMethod.GetSingleIntNew("SELECT Count(*) as count FROM Appsetting WHERE Comparedate in ('" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')") == 0)
                                    {
                                        //If BackWorkerEmail.IsBusy = False Then
                                        //CrateLogfileHeader()
                                        //BackWorkerEmail.RunWorkerAsync()
                                        //If

                                        //Dim Frmvarif As New FrmVarifyWebdata this comment by @G
                                        //Frmvarif.Show()
                                    }
                                    else
                                    {
                                        timerGet.Enabled = false;
                                        timerGet.Stop();
                                    }
                                }
                                else
                                {
                                    if (StMethod.GetSingleInt("SELECT Count(*) as count FROM Appsetting WHERE Comparedate in ('" + System.DateTime.Now.ToString("MM/dd/yyyy") + "')") == 0)
                                    {
                                        //If BackWorkerEmail.IsBusy = False Then
                                        //CrateLogfileHeader()
                                        //BackWorkerEmail.RunWorkerAsync()
                                        //If

                                        //Dim Frmvarif As New FrmVarifyWebdata this comment by @G
                                        //Frmvarif.Show()
                                    }
                                    else
                                    {
                                        timerGet.Enabled = false;
                                        timerGet.Stop();
                                    }
                                }


                            }
                            else
                            {
                                timerGet.Enabled = false;
                                timerGet.Stop();
                            }
                        }
                        //*******************************************************
                        break;
                    }
            }
        }
        private void BackWorkerEmail_DoWork(object sender, DoWorkEventArgs e)
        {
            EmailJobpendingList();
        }
        private void TabctrlFrm_SelectedTabChanged(object sender, DevComponents.DotNetBar.TabStripTabChangedEventArgs e)
        {
            try
            {
                if (tabctrlFrm.SelectedTab is null)
                    return;

                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.IsMdiContainer != true)
                    {
                        if (tabctrlFrm.SelectedTab.Text == frm.Text)
                        {
                            frm.BringToFront();
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void TabctrlFrm_TabItemClose(object sender, DevComponents.DotNetBar.TabStripActionEventArgs e)
        {
            CloseActiveForm(tabctrlFrm.SelectedTab.Text);
            //foreach (Form frm in this.MdiChildren)
            //{
            //    if (frm.IsMdiContainer != true)
            //    {
            //        if (tabctrlFrm.SelectedTab.Text == frm.Text)
            //        {
            //            tabctrlFrm.Tabs.RemoveAt(tabctrlFrm.Tabs.IndexOf(tabctrlFrm.Tabs[frm.Text]));
            //            frm.Close();
            //            break;
            //        }
            //    }
            //}
        }
        private void lbkApprovedVersion_Click(System.Object sender, System.EventArgs e)
        {
            lbkApprovedVersion.Visible = false;
            try
            {
                string version = cProgramInfo.sApplicationVersion;
                char[] ch = new char[] { '.' };
                string filter1 = version.Remove(Convert.ToInt32(version.LastIndexOfAny(ch).ToString()));
                string filter2 = filter1.Remove(Convert.ToInt32(filter1.LastIndexOfAny(ch).ToString()));
                string[] filtersplit = filter2.Split('.');

                if (filtersplit.Length > 0)
                {
                    string query = "UPDATE    AppSetting SET  NewVersion ='" + filtersplit[1] + "', ApprovedVersion ='True'";

                    //StMethod.UpdateRecord(query);


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        StMethod.UpdateRecordNew(query);
                    }
                    else
                    {
                        StMethod.UpdateRecord(query);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnLogin_Click(System.Object sender, System.EventArgs e)
        {

            try
            { 

            if (lblLogin.Text == "Admin Login")
            {
                //If MdiChildren.Length = 0 Then
                
                
                //UnselectMenu();


                //frmLogin frm as New frmLogin()
                FrmJTLogin loginfrm = new FrmJTLogin();
                loginfrm.CallFromMdi = true;
                loginfrm.MdiParentCall = this;
                //loginfrm.Activemdi = Me
                //frm.MdiParent = Me
                loginfrm.Show();

                BackUpDataabaseToolStripMenuItem.Enabled = true;
                PMInfoToolStripMenuItem.Enabled = true;
                PMTMListItemToolStripMenuItem.Enabled = true;
                InvoiceToolStripMenuItem.Enabled = true;


                //AdminToolStripMenuItem.BackColor = Color.LightBlue
                //Else
                // KryptonMessageBox.Show("First close all open forms." & vbCrLf & "For admin login", "Login Information")
                //End If
            }
            else
            {
                if ((Properties.Settings.Default.PretimeSheetLoginName.ToString() != "Null") && (!string.IsNullOrEmpty(Properties.Settings.Default.PretimeSheetLoginName.ToString())))
                {
                    Properties.Settings.Default.timeSheetLoginName = Properties.Settings.Default.PretimeSheetLoginName;
                    Properties.Settings.Default.timeSheetLoginUserID = Convert.ToInt32( Properties.Settings.Default.PretimeSheetLoginUserID);
                    Properties.Settings.Default.timeSheetLoginUserType = Properties.Settings.Default.PretimeSheetLoginUserType;

                    Properties.Settings.Default.PretimeSheetLoginName = "Null";
                    Properties.Settings.Default.PretimeSheetLoginUserID = "Null";
                    Properties.Settings.Default.PretimeSheetLoginUserType = "Null";
                    Properties.Settings.Default.timeSheetLoginUserType = "";

                }
                Properties.Settings.Default.timeSheetLoginUserType = "";
                AdminToolStripMenuItem.Enabled = false;
                InvoiceToolStripMenuItem.Enabled = false;
                BackUpDataabaseToolStripMenuItem.Enabled = false;
                PMInfoToolStripMenuItem.Enabled = false;
                PMTMListItemToolStripMenuItem.Enabled = false;
                lblLogin.Text = "Admin Login";

                //JobStatus.btnCreateInvoice.Enabled = False
                btnCloasAll_Click(sender, e);
            }

            foreach (Form frm in this.MdiChildren)
            {
                if (frm.IsMdiContainer != true)
                {
                    //If frm.Text = JobStatus.Instance.Text Then
                    if (frm is JobStatus)
                    {
                        if (Properties.Settings.Default.PretimeSheetLoginUserType == "Admin")
                        {
                            JobStatus.Instance.grvJobList.Columns["IsDisable"].Visible = true;
                        }
                        else
                        {
                            JobStatus.Instance.grvJobList.Columns["IsDisable"].Visible = false;
                        }
                    }
                }
            }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }


        #endregion

        #region Methods
        public void CreateFromandtab(Form Newfrm)
        {
            TabItem newtab = new TabItem();
            newtab.Name = Newfrm.Text;
            newtab.Text = Newfrm.Text;
            if (!IsFormAlreadyOpen(Newfrm.Text))
            {
                tabctrlFrm.Tabs.Add(newtab);
                tabctrlFrm.Visible = true;
                Newfrm.MdiParent = this;
                Newfrm.WindowState = FormWindowState.Maximized;
                Newfrm.Show();
            }
            tabctrlFrm.SelectedTab = newtab;
            Newfrm.BringToFront();
        }
        public bool IsFormAlreadyOpen(string formText)
        {
            //foreach (Form frm in this.MdiChildren)
            foreach (TabItem item in tabctrlFrm.Tabs)
            {
                //if (frm.IsMdiContainer != true)
                if (item.Text.ToLower().Equals(formText.ToLower()))
                    return true;
            }
            return false;
        }
        public void CloseActiveForm(string formText)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.IsMdiContainer != true)
                {
                    if (formText == frm.Text)
                    {
                        try
                        {
                            tabctrlFrm.Tabs.RemoveAt(tabctrlFrm.Tabs.IndexOf(tabctrlFrm.Tabs[frm.Text]));
                        }
                        catch (Exception)
                        { }
                        frm.Close();
                        break;
                    }
                }
            }
        }
        public void LoadTaskList()
        {
            try
            {
                if (Properties.Settings.Default.timeSheetLoginUserType == "User")
                {

                    string query = "select Count(*) As count from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + Properties.Settings.Default.timeSheetLoginName + "' and cGroup = 'PM'";

                    //int count = StMethod.GetSingleInt(query);

                    int count;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        count = StMethod.GetSingleIntNew(query);
                    }
                    else
                    {
                        count = StMethod.GetSingleInt(query);
                    }

                    if (count > 0)
                    {
                        query = "select Count(*) As count from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + Properties.Settings.Default.timeSheetLoginName + "' and cGroup = 'TM'";

                        //count = StMethod.GetSingleInt(query);

                        //if (count > 0)
                        //{
                        //    CreateFromandtab(new frmTasklist());
                        //}
                        //else
                        //{
                        //    MessageBox.Show("You are not valid User for Add & Search any data in Task List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //}


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            count = StMethod.GetSingleIntNew(query);

                            if (count > 0)
                            {
                                CreateFromandtab(new frmTasklist());
                            }
                            else
                            {
                                MessageBox.Show("You are not valid User for Add & Search any data in Task List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            count = StMethod.GetSingleInt(query);

                            if (count > 0)
                            {
                                CreateFromandtab(new frmTasklist());
                            }
                            else
                            {
                                MessageBox.Show("You are not valid User for Add & Search any data in Task List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("You are not valid User for Add & Search any data in Task List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                    {
                        CreateFromandtab(new frmTasklist());
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btnCloasAll_Click(System.Object sender, System.EventArgs e)
        {
            //Program.closeAll();
            foreach (Form frm in this.MdiChildren)
            {
                CloseActiveForm(frm.Text);
            }
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int indx = Convert.ToInt32(((ToolStripMenuItem)sender).Tag);

            switch ((enmMenu)indx)
            {
                case enmMenu.CraneInfo:
                    CreateFromandtab(new frmCraneInfo());
                    break;
                case enmMenu.FormInfo:
                    //CreateFromandtab(new frmfo());
                    break;
                case enmMenu.CraneFormFill:
                    CreateFromandtab(new frmCraneInfoFill());
                    break;
                case enmMenu.CraneCDInfo:
                    //CreateFromandtab(new frmCraneInfo());
                    break;
                case enmMenu.CommunityBoardInfo:
                    CreateFromandtab(new frmCommunityBoard());
                    break;
                case enmMenu.ApplicantInfo:
                    CreateFromandtab(new frmApplicant());
                    break;
                case enmMenu.TextDocumentBuilder:
                    CreateFromandtab(new frmTxtDocBuilder());
                    break;
                case enmMenu.AddJobDescription:
                    CreateFromandtab(new frmDescription());
                    break;
                case enmMenu.MasterListItem:
                    CreateFromandtab(new MasterTrackSubItem());
                    break;
                case enmMenu.PMTMListItem:
                    CreateFromandtab(new frmTMPMEmpList());
                    break;
                case enmMenu.PMInfo:
                    break;
                case enmMenu.TypicalTextListItem:
                    CreateFromandtab(new frmDocTypicalTxtList());
                    break;
                case enmMenu.VETask:
                    break;
                case enmMenu.ColorSetting:
                    CreateFromandtab(new frmColorSetting());
                    break;
                case enmMenu.ImportInvoiceData:
                    CreateFromandtab(new FrmImportData());
                    break;
                case enmMenu.SenddueInvoiceEmail:
                    CreateFromandtab(new frmSendDueInvoiceMail());
                    break;
                case enmMenu.ApplicationSetting:
                    CreateFromandtab(new frmAppSettings());
                    break;
                case enmMenu.VerifyWebData:
                    break;
                case enmMenu.Utility:                                        
                    break;
                case enmMenu.SendPMPend:
                    CreateFromandtab(new frmSendPMPending());
                    break;
                case enmMenu.Task:
                    break;
                case enmMenu.TaskList:
                    LoadTaskList();
                    break;
                case enmMenu.PageLoadSetting:
                    CreateFromandtab(new FrmPageLoadSetting());
                    break;
                case enmMenu.AutoInsertSetting:
                    CreateFromandtab(new VEAutoInsertSetting());
                    break;
                case enmMenu.UserDefinedSetting:
                    CreateFromandtab(new FrmUserDefinedSetting());
                    break;
                case enmMenu.EditInvoicveSetting:
                    CreateFromandtab(new EditInvoiceSetting());
                    break;
                case enmMenu.EditAddress:
                    CreateFromandtab(new frmEditAddress());
                    break;
                case enmMenu.InvoicePDFUpload:
                    CreateFromandtab(new frmInvoice());
                    break;
                case enmMenu.JTInvoiceSearch:
                    CreateFromandtab(new frmSearchInvoice());
                    break;
                case enmMenu.Aging:
                    CreateFromandtab(new FrmAging());
                    break;
                case enmMenu.AgingEmail:
                    CreateFromandtab(new frmAgingEmail());
                    break;
                case enmMenu.RevenueSearch:
                    //CreateFromandtab(new frmInvoiceTool());
                    break;
                case enmMenu.BillableJobsSearch:
                    CreateFromandtab(new frmBillableJobSearch());
                    break;
                case enmMenu.JTQbInvCompareSearch:
                    CreateFromandtab(new JTQBInvCompareSearch());
                    break;
                case enmMenu.BillableJobsToDisableSearch:
                    CreateFromandtab(new frmBillableJobsDisableSearch());
                    break;
                case enmMenu.ManagerScreen:
                    CreateFromandtab(new JobStatus());
                    break;
                case enmMenu.ContactScreen: //37
                    CreateFromandtab(new AddContactsCompany());
                    break;
                case enmMenu.Calendar: //38
                    CreateFromandtab(new frmCalender());
                    break;
                case enmMenu.AddTimeExpanse: //39
                    CreateFromandtab(new AddtimeANDExpense());
                    break;
                default:
                    break;
            }
        }
        private void GetSenderEmailaddress()
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir2 = dir2 + "\\JobTracker";
                CheckMail.Load(dir2 + "\\CheckFile.xml");

                //CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");
                System.Xml.XmlNode reminder = CheckMail.SelectSingleNode("/EmailReminder/Email");
                SenderEmailAddress = reminder.ChildNodes.Item(0).InnerText.Trim();
                SenderEmailPassword = reminder.ChildNodes.Item(1).InnerText.Trim();
                //CheckMail.Save(Application.StartupPath & "\CheckFile.xml")
            }
            catch (IOException ex1)
            {
                KryptonMessageBox.Show(ex1.Message + " Please check the access right of it.", "Emila Information");
            }
            catch (Exception ex2)
            {
                KryptonMessageBox.Show(ex2.Message + " Please check the access right of it.", "Email Information");
            }
        }
        protected void UnselectMenu()
        {
            Manager.BackColor = Color.Silver;
            JobTracking.BackColor = Color.Silver;
            JobList.BackColor = Color.Silver;
            CalendarMenuStrip.BackColor = Color.Silver;
            AddContactsCompanyToolStripMenuItem.BackColor = Color.Silver;
            JTInformationToolStripMenuItem.BackColor = Color.Silver;
            JTListItemToolStripMenuItem.BackColor = Color.Silver;
            AdminToolStripMenuItem.BackColor = Color.Silver;

        }
        private void UpdateCheckNewVersion()
        {
            try
            {
                string query = "SELECT  NewVersion,ApprovedVersion FROM AppSetting";

                //DataTable dt = new DataTable();
                //dt = StMethod.GetListDT<dtoVersions>(query);

                DataTable dt = new DataTable();

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew<dtoVersions>(query);

                }
                else
                {
                    dt = StMethod.GetListDT<dtoVersions>(query);
                }



                if (dt is null && dt.Rows.Count == 0)
                    return;

                string version = cProgramInfo.sApplicationVersion;
                char[] ch = new char[] { '.' };
                string filter1 = version.Remove(Convert.ToInt32(version.LastIndexOfAny(ch)));
                string filter2 = filter1.Remove(Convert.ToInt32(filter1.LastIndexOfAny(ch)));
                string[] filtersplit = filter2.Split('.');

                ShowApprovedVersion(Convert.ToInt32(dt.Rows[0][0]), Convert.ToInt32(filtersplit[1]), dt.Rows[0][1].ToString());
                if (filtersplit.Length > 0)
                {

                    if (string.CompareOrdinal(filtersplit[1], dt.Rows[0][0].ToString()) < 0)
                    {

                        if (Properties.Settings.Default.timeSheetLoginUserType.ToString() == "Admin")
                        {
                            lnlLblNewVersion.Visible = true;
                            KryptonMessageBox.Show("Please check new version is available", "Update Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            lnlLblNewVersion.LinkColor = Color.Red;

                        }
                        else if (Properties.Settings.Default.timeSheetLoginUserType.ToString() == "User")
                        {
                            if (dt.Rows[0][1].ToString() == "True")
                            {
                                lnlLblNewVersion.Visible = true;
                                KryptonMessageBox.Show("Please check new version is available", "Update Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                lnlLblNewVersion.LinkColor = Color.Red;
                            }
                            else
                            {
                                lnlLblNewVersion.Visible = false;
                            }
                        }
                    }
                    else
                    {
                        lnlLblNewVersion.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ShowApprovedVersion(int databaseversion, int applicationversion, string approved)
        {
            try
            {
                if (Properties.Settings.Default.timeSheetLoginUserType == "User")
                {
                    lbkApprovedVersion.Visible = false;
                }
                else if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    if (databaseversion > applicationversion)
                    {
                        string query = "Update AppSetting  Set  ApprovedVersion = 'False' ";
                        //StMethod.UpdateRecord(query);


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            StMethod.UpdateRecordNew(query);

                        }
                        else
                        {
                            StMethod.UpdateRecord(query);
                        }


                        lbkApprovedVersion.Visible = true;



                    }
                    else if (databaseversion == applicationversion)
                    {
                        if (approved == "True")
                        {
                            lbkApprovedVersion.Visible = false;
                        }
                        else
                        {
                            lbkApprovedVersion.Visible = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lbkApprovedVersion.Visible = false;
            }
        }
        private string DataVarifReminderShedule()
        {
            try
            {
                //return StMethod.GetSingle<string>("SELECT CompareSchedule FROM AppSetting");

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    StMethod.GetSingleNew<string>("SELECT CompareSchedule FROM AppSetting");
                }
                else
                {
                    StMethod.GetSingle<string>("SELECT CompareSchedule FROM AppSetting");
                }

            }
            catch (Exception ex)
            {
                //KryptonMessageBox.Show("Get Compare Schedule Error");
                KryptonMessageBox.Show("Get Compare Schedule Error" + " =>" + ex.Message.ToString());
            }
            return null;
        }
        private void EnableTimer()
        {
            try
            {
                //if (Convert.ToBoolean(StMethod.GetListDT<AppSettings>("SELECT CompareActiveTimer FROM AppSetting").Rows[0]["CompareActiveTimer"]) == true)
                //{
                //    timerGet.Enabled = true;
                //    timerGet.Start();
                //}
                //else
                //{
                //    timerGet.Enabled = false;
                //    timerGet.Stop();
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    if (Convert.ToBoolean(StMethod.GetListDTNew<AppSettings>("SELECT CompareActiveTimer FROM AppSetting").Rows[0]["CompareActiveTimer"]) == true)
                    {
                        timerGet.Enabled = true;
                        timerGet.Start();
                    }
                    else
                    {
                        timerGet.Enabled = false;
                        timerGet.Stop();
                    }
                }
                else
                {
                    if (Convert.ToBoolean(StMethod.GetListDT<AppSettings>("SELECT CompareActiveTimer FROM AppSetting").Rows[0]["CompareActiveTimer"]) == true)
                    {
                        timerGet.Enabled = true;
                        timerGet.Start();
                    }
                    else
                    {
                        timerGet.Enabled = false;
                        timerGet.Stop();
                    }
                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        public void EmailJobpendingList()
        {
            DataTable dtJobListID = new DataTable();
            DataTable dtEmailjoblistpending = new DataTable();
            //DataAccessLayer GetTable = new DataAccessLayer();
            string ToEmail = null;
            string jobAddress = null;
            string EmailBody = "";
            int SendEmailCount = 0;
            bool CompleteSendEmail = false;
            bool EmailStatus = false;
            string FailedCause = null;
            string JobNumber = null;

            //dtJobListID = StMethod.GetListDT<JobNumList>("SELECT JobListID,JobNumber from Joblist");
            

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                dtJobListID = StMethod.GetListDTNew<JobNumList>("SELECT JobListID,JobNumber from Joblist");

            }
            else
            {
                dtJobListID = StMethod.GetListDT<JobNumList>("SELECT JobListID,JobNumber from Joblist");
            }

            try
            {
                for (int i = 0; i < dtJobListID.Rows.Count; i++)
                {
                    CompleteSendEmail = false;
                    if (i == dtJobListID.Rows.Count - 1)
                    {
                        CompleteSendEmail = true;
                    }



                    //if (StMethod.GetSingleInt("SELECT Count(*) as count FROM SendEmailRecord WHERE SendEmailJoblistId=" + dtJobListID.Rows[i]["JobListID"].ToString()) > 0)
                    //{
                    //    cErrorLog.EmailLogFile(true, "Already Emailed", dtJobListID.Rows[i]["JobNumber"].ToString());
                    //    goto TrowHerer;
                    //}



                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        if (StMethod.GetSingleIntNew("SELECT Count(*) as count FROM SendEmailRecord WHERE SendEmailJoblistId=" + dtJobListID.Rows[i]["JobListID"].ToString()) > 0)
                        {
                            cErrorLog.EmailLogFile(true, "Already Emailed", dtJobListID.Rows[i]["JobNumber"].ToString());
                            goto TrowHerer;
                        }
                    }
                    else
                    {
                        if (StMethod.GetSingleInt("SELECT Count(*) as count FROM SendEmailRecord WHERE SendEmailJoblistId=" + dtJobListID.Rows[i]["JobListID"].ToString()) > 0)
                        {
                            cErrorLog.EmailLogFile(true, "Already Emailed", dtJobListID.Rows[i]["JobNumber"].ToString());
                            goto TrowHerer;
                        }
                    }


                    //dtEmailjoblistpending = StMethod.GetListDT<dtoEmailaddress>("Select EmailAddress,Address from EmailJobPendingList where joblistid in (" + dtJobListID.Rows[i]["JobListID"].ToString() + ")");


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        dtEmailjoblistpending = StMethod.GetListDTNew<dtoEmailaddress>("Select EmailAddress,Address from EmailJobPendingList where joblistid in (" + dtJobListID.Rows[i]["JobListID"].ToString() + ")");
                    }
                    else
                    {
                        dtEmailjoblistpending = StMethod.GetListDT<dtoEmailaddress>("Select EmailAddress,Address from EmailJobPendingList where joblistid in (" + dtJobListID.Rows[i]["JobListID"].ToString() + ")");
                    }

                    try
                    {
                        ToEmail = dtEmailjoblistpending.Rows[i]["EmailAddress"].ToString();
                        jobAddress = dtEmailjoblistpending.Rows[i]["Address"].ToString();
                        EmailBody = string.Empty;
                        EmailStatus = true;
                    }
                    catch (Exception ex)
                    {
                        EmailStatus = false;
                        FailedCause = "Email Address and Jobaddress Not available. ";
                    }
                    finally
                    {
                        EmailBody = string.Empty;
                    }
                    if (dtEmailjoblistpending.Rows.Count > 0)
                    {
                        EmailStatus = true;
                        for (int j = 0; j < dtEmailjoblistpending.Rows.Count; j++)
                        {
                            try
                            {
                                EmailBody = EmailBody + "<tr> <td width='10%'> Track:-" + dtEmailjoblistpending.Rows[j]["Track"].ToString() + "</td> <td width='10%'> TrackSub :-" + dtEmailjoblistpending.Rows[j]["TrackSub"].ToString() + "</td> <td width='10%'> Notes:-" + dtEmailjoblistpending.Rows[j]["Comments"].ToString() + "</td></tr>";
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message.ToString());
                            }
                        }
                    }
                    else
                    {
                        EmailStatus = false;
                        FailedCause = FailedCause + "Track and Track Sub Information not available.";
                    }
                    if (dtEmailjoblistpending.Rows.Count > 0)
                    {
                        EmailBody = "<table> <tr><td width='10%' Colspan=3>Please be advised that the following outstanding matters are still pending</td><tr><td width='10%' colspan=3> Job Address :-" + jobAddress + "</td></tr>" + EmailBody + "</table>";
                        //If ToEmail <> String.Empty Then
                        SendUploadmail(EmailBody, "Test@dutechnosys.com", jobAddress);
                        EmailStatus = true;


                        //StMethod.UpdateRecord("INSERT INTO SendEmailRecord(SendEmailJoblistId,IsSend) VALUES('" + dtJobListID.Rows[i]["JobListID"].ToString() + "','" + SendEmailSuccessful + "')");
                                               


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            StMethod.UpdateRecordNew("INSERT INTO SendEmailRecord(SendEmailJoblistId,IsSend) VALUES('" + dtJobListID.Rows[i]["JobListID"].ToString() + "','" + SendEmailSuccessful + "')");
                        }
                        else
                        {
                            StMethod.UpdateRecord("INSERT INTO SendEmailRecord(SendEmailJoblistId,IsSend) VALUES('" + dtJobListID.Rows[i]["JobListID"].ToString() + "','" + SendEmailSuccessful + "')");
                        }


                        SendEmailCount = (int)(SendEmailCount + 1);
                        if (SendEmailCount == 20)
                        {
                            System.Threading.Thread.Sleep(120000);
                        }
                    }
                    else
                    {
                        EmailStatus = false;
                        cErrorLog.EmailLogFile(EmailStatus, FailedCause, dtJobListID.Rows[i]["JobNumber"].ToString());
                        goto TrowHerer;
                        //FailedCause = FailedCause & "Track and Track Sub Information not available."
                        //End If
                    }
                    if (SendEmailSuccessful == true)
                    {
                        cErrorLog.EmailLogFile(EmailStatus, FailedCause, dtJobListID.Rows[i]["JobNumber"].ToString());
                    }
                    else
                    {
                        cErrorLog.EmailLogFile(false, "Due internet Connection error or due SMTP serverError.", dtJobListID.Rows[i]["JobNumber"].ToString());
                    }
                TrowHerer:
                    EmailBody = string.Empty;
                    jobAddress = string.Empty;
                    ToEmail = string.Empty;
                    if (i == dtJobListID.Rows.Count - 1)
                    {
                        CompleteSendEmail = true;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Email Information");
            }
            if (CompleteSendEmail == true)
            {
                //DataTable dt = StMethod.GetListDT<EmailRecord>("SELECT UploadDate FROM EmailRecord Where id=(SELECT  ISNull(MAX(id),0) as id FROM EmailRecord)");


                DataTable dt;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<EmailRecord>("SELECT UploadDate FROM EmailRecord Where id=(SELECT  ISNull(MAX(id),0) as id FROM EmailRecord)");
                }
                else
                {
                    dt = StMethod.GetListDT<EmailRecord>("SELECT UploadDate FROM EmailRecord Where id=(SELECT  ISNull(MAX(id),0) as id FROM EmailRecord)");
                }

                if (dt != null && (string.Format("MM/dd/yyyy", dt.Rows[0]["UploadDate"]) != DateTime.Now.ToString("MM/dd/yyyy")))
                {



                    //StMethod.UpdateRecord("INSERT INTO EmailRecord(UploadDate) Values('" + DateTime.Now.ToString("MM/dd/yyyy") + "')");
                    //StMethod.UpdateRecord("DELETE FROM SendEmailRecord");


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        StMethod.UpdateRecordNew("INSERT INTO EmailRecord(UploadDate) Values('" + DateTime.Now.ToString("MM/dd/yyyy") + "')");
                        StMethod.UpdateRecordNew("DELETE FROM SendEmailRecord");
                    }
                    else
                    {
                        StMethod.UpdateRecord("INSERT INTO EmailRecord(UploadDate) Values('" + DateTime.Now.ToString("MM/dd/yyyy") + "')");
                        StMethod.UpdateRecord("DELETE FROM SendEmailRecord");
                    }

                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    
                    Process.Start(dir2 + "\\EmailLogFile.txt");

                    //Process.Start(Application.StartupPath + "\\EmailLogFile.txt");
                }
            }
        }
        private void SendUploadmail(string sb, string ToSendEmail, string JobAddress)
        {
            try
            {
                string JobAddresSub = "Pending Matters @" + JobAddress;
                SendEmailSuccessful = EmailUtils.MailSender(ToSendEmail, sb.ToString(), JobAddresSub);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Sending Fail :-" + ex.Message, "Email Information");
                SendEmailSuccessful = false;
            }
        }
        #endregion
    }
}