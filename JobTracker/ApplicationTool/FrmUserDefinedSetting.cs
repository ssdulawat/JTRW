using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JobTracker.Application_Tool
{
    public partial class FrmUserDefinedSetting : Form
    {
        string SelectedSetting = "";
        public FrmUserDefinedSetting()
        {
            InitializeComponent();
        }

        #region Events
        private void FrmUserDefinedSetting_Load(System.Object sender, System.EventArgs e)
        {
            //SaveManagerSetting()
            FillCombo();
            ComMUserSetting.SelectedIndex = 0;
        }

        private void ComMPreRequireTrack_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                ComMTrackSubPreRequire.Items.Clear();


                //using (EFDbContext db = new EFDbContext())
                //{
                //    var list = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreRequireTrack.SelectedItem.ToString().Trim() + "'").ToList();
                //    ComMTrackSubPreRequire.Items.Add("");
                //    foreach (var item in list)
                //    {
                //        ComMTrackSubPreRequire.Items.Add(item);
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreRequireTrack.SelectedItem.ToString().Trim() + "'").ToList();
                        ComMTrackSubPreRequire.Items.Add("");
                        foreach (var item in list)
                        {
                            ComMTrackSubPreRequire.Items.Add(item);
                        }
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreRequireTrack.SelectedItem.ToString().Trim() + "'").ToList();
                        ComMTrackSubPreRequire.Items.Add("");
                        foreach (var item in list)
                        {
                            ComMTrackSubPreRequire.Items.Add(item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void btnMSetting_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                try
                {
                    string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    dir1 = dir1 + "\\JobTracker";

                    string fileName = dir1 + "\\VESoftwareSetting.xml";
                    //string fileName = Application.StartupPath + "\\VESoftwareSetting.xml";


                    FileSecurity fSecurity = File.GetAccessControl(fileName);
                    FileInfo fSecurity1 = new FileInfo(fileName);
                    fSecurity1.IsReadOnly = false;
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    fSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                    File.SetAccessControl(fileName, fSecurity);
                }
                catch (Exception ex)
                {

                }

                SelectUserDefinedSetting();
                SaveSetting();
            }
            catch (Exception ex)
            {

            }
        }

        private void ComMUserSetting_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {

                RefreshandLoadSetting();

            }
            catch (Exception ex)
            {

            }
        }

        private void TCUserSetting_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            RefreshandLoadSetting();
        }

        private void btnMClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ClearManagerTools();
            }
            catch (Exception ex)
            {

            }

        }

        private void btnTSClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ClearTimeSheetTools();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnTasklistClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ClearTiskListTools();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCalendarClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ClearCalendarTools();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnTSSave_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                SelectUserDefinedSetting();
                SaveSetting();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnTaskListSave_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                SelectUserDefinedSetting();
                SaveSetting();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCSave_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                SelectUserDefinedSetting();
                SaveSetting();
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region Methods
        private void SelectUserDefinedSetting()
        {
            try
            {
                if (ComMUserSetting.Text == "-Select -")
                {
                    MessageBox.Show("First Select User Defined Setting", "VE UserDefined Setting", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ComMUserSetting.Text == "User Defined #1")
                {
                    SelectedSetting = "UserSetting1";
                }
                else if (ComMUserSetting.Text == "User Defined #2")
                {
                    SelectedSetting = "UserSetting2";
                }
                else if (ComMUserSetting.Text == "User Defined #3")
                {
                    SelectedSetting = "UserSetting3";
                }
                else if (ComMUserSetting.Text == "User Defined #4")
                {
                    SelectedSetting = "UserSetting4";
                }
                else if (ComMUserSetting.Text == "User Defined #5")
                {
                    SelectedSetting = "UserSetting5";
                }
                else if (ComMUserSetting.Text == "User Defined #6")
                {
                    SelectedSetting = "UserSetting6";
                }
                else
                {
                    SelectedSetting = "";
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void SaveSetting()
        {
            try
            {
                if (TCUserSetting.SelectedTab.Text == TPManager.Text && !string.IsNullOrEmpty(SelectedSetting.ToString()))
                {
                    if (ComInitaialsUser.SelectedIndex != 0)
                    {
                        SaveManagerSetting();
                    }
                    else
                    {
                        MessageBox.Show("Select Initaials User for Setting", "VE User Defined Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (TCUserSetting.SelectedTab.Text == TPTasklistForm.Text && !string.IsNullOrEmpty(SelectedSetting.ToString()))
                {
                    if (ComInitaialsUser.SelectedIndex != 0)
                    {
                        SaveTasklistSetting();
                    }
                    else
                    {
                        MessageBox.Show("Select Initaials User for Setting", "VE User Defined Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (TCUserSetting.SelectedTab.Text == TPTimeSheet.Text && !string.IsNullOrEmpty(SelectedSetting.ToString()))
                {
                    if (ComInitaialsUser.SelectedIndex != 0)
                    {
                        SaveTimeSheetSetting();
                    }
                    else
                    {
                        MessageBox.Show("Select Initaials User for Setting", "VE User Defined Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (TCUserSetting.SelectedTab.Text == TPCalendarForm.Text)
                {
                    if (ComInitaialsUser.SelectedIndex != 0)
                    {
                        SaveCalendarSetting();
                    }
                    else
                    {
                        MessageBox.Show("Select Initaials User for Setting", "VE User Defined Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void FillCombo()
        {
            try
            {
                //var data = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack");

                var data = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack");
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    data = StMethod.GetListNew<string>("SELECT cTrack FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack");

                }
                else
                {
                    data = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack");
                }

                comManagerTM.Items.Add("");
                ComMTMWithPending.Items.Add("");
                ComTaskListTMsearch.Items.Add("");
                ComCTM.Items.Add("");

                foreach (var item in data)
                {
                    comManagerTM.Items.Add(item);
                    // cmbTMWithPending.Items.Add("")
                    ComMTMWithPending.Items.Add(item);
                    ComTaskListTMsearch.Items.Add(item);
                    ComCTM.Items.Add(item);
                }


                ComMJoblistPM.Items.Add("");
                ComJobListPMrv.Items.Add("");
                ComTSJobPM.Items.Add("");

                ComTaskListJobPM.Items.Add("");
                ComTaskListJobPMrv.Items.Add("");
                ComTaskListPMsearch.Items.Add("");
                ComCPM.Items.Add("");

                //var data1 = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack");

                var data1 = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack");
                data1 = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    data1 = StMethod.GetListNew<string>("SELECT cTrack FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack");
                }
                else
                {
                    data1 = StMethod.GetList<string>("SELECT cTrack FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack");
                }

                foreach (var item in data1)
                {
                    ComMJoblistPM.Items.Add(item);
                    ComJobListPMrv.Items.Add(item);
                    ComTSJobPM.Items.Add(item);
                    ComTaskListPMsearch.Items.Add(item);
                    ComTaskListJobPM.Items.Add(item);
                    ComTaskListJobPMrv.Items.Add(item);
                    ComCPM.Items.Add(item);
                }

                ComMPreRequireTrack.Items.Add("");

                //***** fill Manager Track Combo Box ****

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db.Database.SqlQuery<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ").ToList();
                        // CmbPreRequireTrack.Items.Add("")
                        foreach (var item in list)
                        {
                            ComMPreRequireTrack.Items.Add(item);
                        }

                        ComMStatusPreRequire.Items.Add("");

                        //**** fill Manager StatusCombo Box *****
                        list = db.Database.SqlQuery<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Status' union select '' as cTrack ORDER BY cTrack ").ToList();
                        ComMStatusPreRequire.DataSource = list;
                        ComMStatusPreRequire.DisplayMember = "cTrack";
                        ComMStatusPreRequire.SelectedIndex = -1;


                        ComTaskListJobStatusSearch.Items.Add("");

                        //****** Fill TaskList State Combo Box **********
                        ComTaskListJobStatusSearch.DisplayMember = "cTrack";
                        ComTaskListJobStatusSearch.ValueMember = "Id";
                        var ComTaskList = db.Database.SqlQuery<colPMM>("SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack").ToList();
                        ComTaskListJobStatusSearch.DataSource = ComTaskList;


                        ComMBillStatePermit.Items.Add("");

                        //***** Fill Bill Status ComBox *****
                        list = db.Database.SqlQuery<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) union select '' as cTrack ORDER BY cTrack").ToList();
                        ComMBillStatePermit.DataSource = list;
                        ComMBillStatePermit.DisplayMember = "cTrack";
                        ComMBillStatePermit.SelectedIndex = -1;

                        //****** Fill Time Sheet Bill Status CobboBox *********
                        //ComTaskListJobStatusSearch.DisplayMember = "cTrack"
                        //ComTaskListJobStatusSearch.ValueMember = "Id"
                        //dtTaskListStatus = cmbobj.Filldatatable("SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack")
                        //ComTaskListJobStatusSearch.DataSource = dtTaskListStatus


                        ComTSBillStatusUserSearch.Items.Add("");

                        list = db.Database.SqlQuery<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) union select '' as cTrack ORDER BY cTrack").ToList();
                        ComTSBillStatusUserSearch.DataSource = list;
                        ComTSBillStatusUserSearch.DisplayMember = "cTrack";
                        ComTSBillStatusUserSearch.SelectedIndex = 0;

                        ComTSStatusUserSearch.Items.Add("");

                        //******* Fill Time Sheet Status Combo Box ********                    
                        var masteritem = db.Database.SqlQuery<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='STATUS' AND UserType='U'  union SELECT 0 as TS_MasterItemId,'' as value order by Value ").ToList();
                        ComTSStatusUserSearch.DataSource = masteritem;
                        ComTSStatusUserSearch.DisplayMember = "Value";
                        ComTSStatusUserSearch.ValueMember = "TS_MasterItemId";

                        //***** Fill Time Sheet User Combo Box ******** TODO
                        //////DataTable dtTSUser = null;
                        ////////Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()
                        //////SqlConnection con = new SqlConnection(Dal.ConnectionStringPCTracker);
                        //////dtTSUser = Dal.Filldatatable("use " + con.Database + " SELECT  EmployeeDetailsId, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");
                        //////ComTSUserSearch.DisplayMember = "UserName";
                        //////ComTSUserSearch.ValueMember = "EmployeeDetailsId";
                        //////ComTSUserSearch.DataSource = dtTSUser;


                        //var dtusers = StMethod.GetListDT<dtoUsers>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");

                        //var dtusers = StMethod.GetListDT<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");

                        var dtusers = StMethod.GetListDTNew<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");

                        ComTSUserSearch.DisplayMember = "UserName";
                        ComTSUserSearch.ValueMember = "Id";
                        ComTSUserSearch.DataSource = dtusers;


                        ComTSAdminStatusUserSearch.Items.Add("");

                        //****** Fill Time Sheet Admin Status ComBo box ******                    
                        masteritem = db.Database.SqlQuery<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'  union SELECT 0 as TS_MasterItemId,'' union SELECT 1 as TS_MasterItemId,'None' as value order by Value").ToList();
                        ComTSAdminStatusUserSearch.DisplayMember = "Value";
                        ComTSAdminStatusUserSearch.ValueMember = "TS_MasterItemId";
                        ComTSAdminStatusUserSearch.DataSource = masteritem;

                        //****** Fill Instil User ComboBox  *****
                        //////DataTable dtInstailUser = null;
                        ////////pcConnStr = ConfigurationSettings.AppSettings("PCTracker").ToString()
                        //////con = new SqlConnection(Dal.ConnectionStringPCTracker);
                        //////dtInstailUser = Dal.Filldatatable("use " + con.Database + " SELECT  EmployeeDetailsId, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");
                        //////ComInitaialsUser.DisplayMember = "UserName";
                        //////ComInitaialsUser.ValueMember = "EmployeeDetailsId";
                        //////ComInitaialsUser.DataSource = dtInstailUser;
                        ///



                        //var dtInstailUser = StMethod.GetListDT<dtoUsers>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");

                        //var dtInstailUser = StMethod.GetListDT<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");

                        var dtInstailUser = StMethod.GetListDTNew<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");

                        ComInitaialsUser.DisplayMember = "UserName";
                        ComInitaialsUser.ValueMember = "Id";
                        ComInitaialsUser.DataSource = dtInstailUser;


                        ComCClient.Items.Add("");

                        //******* fill Calendar Client Combobox *****
                        var companydata = db.Database.SqlQuery<CompanyIDs>("SELECT CompanyName,CompanyID  FROM dbo.Company Union Select '' as CompanyName,0 as CompanyID ORDER BY CompanyName").ToList();
                        //companydata.Add(new CompanyIDs() { CompanyID = 0, CompanyName = "" });
                        //ComCClient.DataSource = companydata.OrderBy(r => r.CompanyID);
                        ComCClient.DataSource = companydata;
                        ComCClient.DisplayMember = "CompanyName";
                        ComCClient.ValueMember = "CompanyID";
                        //ComCClient.SelectedIndex = -1;
                    }



                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ").ToList();
                        // CmbPreRequireTrack.Items.Add("")
                        foreach (var item in list)
                        {
                            ComMPreRequireTrack.Items.Add(item);
                        }

                        ComMStatusPreRequire.Items.Add("");

                        //**** fill Manager StatusCombo Box *****
                        list = db.Database.SqlQuery<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Status' union select '' as cTrack ORDER BY cTrack ").ToList();
                        ComMStatusPreRequire.DataSource = list;
                        ComMStatusPreRequire.DisplayMember = "cTrack";
                        ComMStatusPreRequire.SelectedIndex = -1;


                        ComTaskListJobStatusSearch.Items.Add("");

                        //****** Fill TaskList State Combo Box **********
                        ComTaskListJobStatusSearch.DisplayMember = "cTrack";
                        ComTaskListJobStatusSearch.ValueMember = "Id";
                        var ComTaskList = db.Database.SqlQuery<colPMM>("SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack").ToList();
                        ComTaskListJobStatusSearch.DataSource = ComTaskList;


                        ComMBillStatePermit.Items.Add("");

                        //***** Fill Bill Status ComBox *****
                        list = db.Database.SqlQuery<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) union select '' as cTrack ORDER BY cTrack").ToList();
                        ComMBillStatePermit.DataSource = list;
                        ComMBillStatePermit.DisplayMember = "cTrack";
                        ComMBillStatePermit.SelectedIndex = -1;

                        //****** Fill Time Sheet Bill Status CobboBox *********
                        //ComTaskListJobStatusSearch.DisplayMember = "cTrack"
                        //ComTaskListJobStatusSearch.ValueMember = "Id"
                        //dtTaskListStatus = cmbobj.Filldatatable("SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack")
                        //ComTaskListJobStatusSearch.DataSource = dtTaskListStatus


                        ComTSBillStatusUserSearch.Items.Add("");

                        list = db.Database.SqlQuery<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) union select '' as cTrack ORDER BY cTrack").ToList();
                        ComTSBillStatusUserSearch.DataSource = list;
                        ComTSBillStatusUserSearch.DisplayMember = "cTrack";
                        ComTSBillStatusUserSearch.SelectedIndex = 0;

                        ComTSStatusUserSearch.Items.Add("");

                        //******* Fill Time Sheet Status Combo Box ********                    
                        var masteritem = db.Database.SqlQuery<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='STATUS' AND UserType='U'  union SELECT 0 as TS_MasterItemId,'' as value order by Value ").ToList();
                        ComTSStatusUserSearch.DataSource = masteritem;
                        ComTSStatusUserSearch.DisplayMember = "Value";
                        ComTSStatusUserSearch.ValueMember = "TS_MasterItemId";

                        //***** Fill Time Sheet User Combo Box ******** TODO
                        //////DataTable dtTSUser = null;
                        ////////Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()
                        //////SqlConnection con = new SqlConnection(Dal.ConnectionStringPCTracker);
                        //////dtTSUser = Dal.Filldatatable("use " + con.Database + " SELECT  EmployeeDetailsId, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");
                        //////ComTSUserSearch.DisplayMember = "UserName";
                        //////ComTSUserSearch.ValueMember = "EmployeeDetailsId";
                        //////ComTSUserSearch.DataSource = dtTSUser;


                        //var dtusers = StMethod.GetListDT<dtoUsers>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");

                        var dtusers = StMethod.GetListDT<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");



                        ComTSUserSearch.DisplayMember = "UserName";
                        ComTSUserSearch.ValueMember = "Id";
                        ComTSUserSearch.DataSource = dtusers;


                        ComTSAdminStatusUserSearch.Items.Add("");

                        //****** Fill Time Sheet Admin Status ComBo box ******                    
                        masteritem = db.Database.SqlQuery<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'  union SELECT 0 as TS_MasterItemId,'' union SELECT 1 as TS_MasterItemId,'None' as value order by Value").ToList();
                        ComTSAdminStatusUserSearch.DisplayMember = "Value";
                        ComTSAdminStatusUserSearch.ValueMember = "TS_MasterItemId";
                        ComTSAdminStatusUserSearch.DataSource = masteritem;

                        //****** Fill Instil User ComboBox  *****
                        //////DataTable dtInstailUser = null;
                        ////////pcConnStr = ConfigurationSettings.AppSettings("PCTracker").ToString()
                        //////con = new SqlConnection(Dal.ConnectionStringPCTracker);
                        //////dtInstailUser = Dal.Filldatatable("use " + con.Database + " SELECT  EmployeeDetailsId, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");
                        //////ComInitaialsUser.DisplayMember = "UserName";
                        //////ComInitaialsUser.ValueMember = "EmployeeDetailsId";
                        //////ComInitaialsUser.DataSource = dtInstailUser;
                        ///



                        //var dtInstailUser = StMethod.GetListDT<dtoUsers>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");

                        var dtInstailUser = StMethod.GetListDT<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by UserName");


                        ComInitaialsUser.DisplayMember = "UserName";
                        ComInitaialsUser.ValueMember = "Id";
                        ComInitaialsUser.DataSource = dtInstailUser;


                        ComCClient.Items.Add("");

                        //******* fill Calendar Client Combobox *****
                        var companydata = db.Database.SqlQuery<CompanyIDs>("SELECT CompanyName,CompanyID  FROM dbo.Company Union Select '' as CompanyName,0 as CompanyID ORDER BY CompanyName").ToList();
                        //companydata.Add(new CompanyIDs() { CompanyID = 0, CompanyName = "" });
                        //ComCClient.DataSource = companydata.OrderBy(r => r.CompanyID);
                        ComCClient.DataSource = companydata;
                        ComCClient.DisplayMember = "CompanyName";
                        ComCClient.ValueMember = "CompanyID";
                        //ComCClient.SelectedIndex = -1;
                    }


                }






                //
            }
            catch (Exception ex)
            {
            }
        }

        private void ClearManagerTools()
        {
            try
            {
                comManagerTM.Text = "";
                ComMTMWithPending.Text = "";
                txtMCommentsPreRequire.Text = "";
                txtMClient.Text = "";
                txtMJobListJobID.Text = "";
                ComMJoblistPM.Text = "";
                ComJobListPMrv.Text = "";
                chkMShowOnlyPending.Checked = false;
                chkMNotInvoiceJob.Checked = false;
                txtMJobListAddress.Text = "";
                txtMTown.Text = "";
                txtMJoblistClienttext.Text = "";
                txtMJobListSearchDescription.Text = "";

                ComMPreRequireTrack.Text = "";
                ComMTrackSubPreRequire.Text = "";
                ComMStatusPreRequire.Text = "";
                ComMBillStatePermit.Text = "";

            }
            catch (Exception ex)
            {

            }
        }

        private void ClearTimeSheetTools()
        {
            try
            {
                txtTSJobListJob.Text = "";
                txtTSJobClient.Text = "";
                txtTSDescriptionSearchJob.Text = "";
                ComTSJobPM.Text = "";
                txtTSJobTown.Text = "";
                txtTSJobAddress.Text = "";

                txtTSUserJobNumber.Text = "";
                ComTSUserSearch.Text = "";
                ComTSStatusUserSearch.Text = "";
                ComTSBillStatusUserSearch.Text = "";
                ComTSAdminStatusUserSearch.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void ClearTiskListTools()
        {
            try
            {
                txtTaskListJobClient.Text = "";
                txtTaskListJobNumber.Text = "";
                ComTaskListJobPM.Text = "";
                ComTaskListJobPMrv.Text = "";
                txtTaskListJobTown.Text = "";
                txtTaskListJobAddress.Text = "";
                txtTasklistJobClientText.Text = "";
                txtTaskListJobDescription.Text = "";


                txtTaskListJobSearch.Text = "";
                ComTaskListJobStatusSearch.Text = "";
                ComTaskListPMsearch.Text = "";
                ComTaskListTMsearch.Text = "";
                txtTaskListDescriptionSearch.Text = "";

            }
            catch (Exception ex)
            {

            }
        }

        private void ClearCalendarTools()
        {
            try
            {
                ComCAction.Text = "";
                ComCClient.Text = "";
                ComCPM.Text = "";
                ComCTM.Text = "";

                chkcExpired.Checked = false;
                chkcObtained.Checked = false;
                chkCShowOnlyPendingTrack.Checked = false;
                chkCSubmitted.Checked = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void SaveManagerSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");



                myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText = ComInitaialsUser.Text.Trim();
                if (chkApplySetting.Checked == true)
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" + SelectedSetting.ToString() + "/Apply").InnerText = "Yes";
                }
                else
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" + SelectedSetting.ToString() + "/Apply").InnerText = "No";
                }
                if (chkMPreRequirment.Checked == true)
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Prerequired").InnerText = "True";
                }
                else
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerFor/ShowGrid/Prerequired").InnerText = "False";
                }
                if (chkMPermits.Checked == true)
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Permits").InnerText = "True";
                }
                else
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerFor/ShowGrid/permits").InnerText = "False";
                }
                if (chkMNotes.Checked == true)
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Notes").InnerText = "True";
                }
                else
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerFor/ShowGrid/Notes").InnerText = "False";
                }
                XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" + SelectedSetting.ToString() + "/Selection");
                root.RemoveAll();

                myDoc.Save(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");


                if (!string.IsNullOrEmpty(comManagerTM.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("TM");
                    Element.InnerText = comManagerTM.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(ComMTMWithPending.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("TMPending");
                    Element.InnerText = ComMTMWithPending.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(txtMCommentsPreRequire.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Comments");
                    Element.InnerText = txtMCommentsPreRequire.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(txtMClient.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Client");
                    Element.InnerText = txtMClient.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(txtMJobListJobID.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Job");
                    Element.InnerText = txtMJobListJobID.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(ComMJoblistPM.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("PM");
                    Element.InnerText = ComMJoblistPM.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(ComJobListPMrv.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("PMrv");
                    Element.InnerText = ComJobListPMrv.Text.Trim();
                    root.AppendChild(Element);
                }
                if (chkMShowOnlyPending.Checked == true)
                {
                    XmlElement Element = myDoc.CreateElement("Pending");
                    Element.InnerText = "True";
                    root.AppendChild(Element);
                }
                if (chkMNotInvoiceJob.Checked == true)
                {
                    XmlElement Element = myDoc.CreateElement("NotPending");
                    Element.InnerText = "True";
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(txtMJobListAddress.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Address");
                    Element.InnerText = txtMJobListAddress.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(txtMTown.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Town");
                    Element.InnerText = txtMTown.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(txtMJoblistClienttext.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("ClientText");
                    Element.InnerText = txtMJoblistClienttext.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(txtMJobListSearchDescription.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Description");
                    Element.InnerText = txtMJobListSearchDescription.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(ComMPreRequireTrack.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Track");
                    Element.InnerText = ComMPreRequireTrack.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(ComMTrackSubPreRequire.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("TrackSub");
                    Element.InnerText = ComMTrackSubPreRequire.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(ComMStatusPreRequire.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Status");
                    Element.InnerText = ComMStatusPreRequire.Text.Trim();
                    root.AppendChild(Element);
                }
                if (!string.IsNullOrEmpty(ComMBillStatePermit.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("BillStatus");
                    Element.InnerText = ComMBillStatePermit.Text.Trim();
                    root.AppendChild(Element);
                }

                myDoc.Save(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");


                MessageBox.Show("Save VE User Defined Setting Successfully", "VE Software Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
        }

        private void SaveTimeSheetSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();

                string dir3 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir3 = dir3 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir3 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText = ComInitaialsUser.Text.Trim();

                if (chkApplySetting.Checked == true)
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TimeSheet/" + SelectedSetting.ToString() + "/Apply").InnerText = "Yes";
                }
                else
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TimeSheet/" + SelectedSetting.ToString() + "/Apply").InnerText = "No";
                }

                XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TimeSheet/" + SelectedSetting.ToString() + "/Selection");

                root.RemoveAll();

                myDoc.Save(dir3 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");


                if (!string.IsNullOrEmpty(txtTSJobListJob.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("JobsearchJob");
                    Element.InnerText = txtTSJobListJob.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTSJobClient.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("JobSearchClient");
                    Element.InnerText = txtTSJobClient.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTSDescriptionSearchJob.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("JobsearchDescription");
                    Element.InnerText = txtTSDescriptionSearchJob.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(ComTSJobPM.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("JobsearchPM");
                    Element.InnerText = ComTSJobPM.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTSJobTown.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("JobSearchTown");
                    Element.InnerText = txtTSJobTown.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTSJobAddress.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("JobSearchAddress");
                    Element.InnerText = txtTSJobAddress.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTSUserJobNumber.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("UserJob");
                    Element.InnerText = txtTSUserJobNumber.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(ComTSUserSearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("UserSearch");
                    Element.InnerText = ComTSUserSearch.Text.Trim();
                    root.AppendChild(Element);
                }

                if (!string.IsNullOrEmpty(ComTSStatusUserSearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("UserStatus");
                    Element.InnerText = ComTSStatusUserSearch.Text.Trim();
                    root.AppendChild(Element);
                }

                if (!string.IsNullOrEmpty(ComTSBillStatusUserSearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("UserBillStatus");
                    Element.InnerText = ComTSBillStatusUserSearch.Text.Trim();
                    root.AppendChild(Element);
                }

                if (!string.IsNullOrEmpty(ComTSAdminStatusUserSearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("UserAdminStatus");
                    Element.InnerText = ComTSAdminStatusUserSearch.Text.Trim();
                    root.AppendChild(Element);
                }

                myDoc.Save(dir3 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");

                MessageBox.Show("Save VE User Defined Setting Successfully", "VE Software Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
            }
        }

        private void SaveTasklistSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();


                string dir3 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir3 = dir3 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir3 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText = ComInitaialsUser.Text.Trim();

                if (chkApplySetting.Checked == true)
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TaskList/" + SelectedSetting.ToString() + "/Apply").InnerText = "Yes";
                }
                else
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TaskList/" + SelectedSetting.ToString() + "/Apply").InnerText = "No";
                }



                XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TaskList/" + SelectedSetting.ToString() + "/Selection");

                root.RemoveAll();

                myDoc.Save(dir3 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");


                if (!string.IsNullOrEmpty(txtTaskListJobClient.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("JobClient");
                    Element.InnerText = txtTaskListJobClient.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTaskListJobNumber.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("JoblistJob");
                    Element.InnerText = txtTaskListJobNumber.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(ComTaskListJobPM.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("JobPM");
                    Element.InnerText = ComTaskListJobPM.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(ComTaskListJobPMrv.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("JobPMrv");
                    Element.InnerText = ComTaskListJobPMrv.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTaskListJobTown.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("JobTown");
                    Element.InnerText = txtTaskListJobTown.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTaskListJobAddress.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("JobAddress");
                    Element.InnerText = txtTaskListJobAddress.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTasklistJobClientText.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("JobClientText");
                    Element.InnerText = txtTasklistJobClientText.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTaskListJobDescription.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("JobDescription");
                    Element.InnerText = txtTaskListJobDescription.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(txtTaskListJobSearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("TaskJob");
                    Element.InnerText = txtTaskListJobSearch.Text.Trim();
                    root.AppendChild(Element);
                }

                if (!string.IsNullOrEmpty(ComTaskListJobStatusSearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("TaskStatus");
                    Element.InnerText = ComTaskListJobStatusSearch.Text.Trim();
                    root.AppendChild(Element);
                }

                if (!string.IsNullOrEmpty(ComTaskListPMsearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("TaskPM");
                    Element.InnerText = ComTaskListPMsearch.Text.Trim();
                    root.AppendChild(Element);
                }

                if (!string.IsNullOrEmpty(ComTaskListTMsearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("TaskTM");
                    Element.InnerText = ComTaskListTMsearch.Text.Trim();
                    root.AppendChild(Element);
                }

                if (!string.IsNullOrEmpty(txtTaskListDescriptionSearch.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("TaskDescription");
                    Element.InnerText = txtTaskListDescriptionSearch.Text.Trim();
                    root.AppendChild(Element);
                }

                myDoc.Save(dir3 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");

                MessageBox.Show("Save VE User Defined Setting Successfully", "VE Software Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

            }
        }

        private void SaveCalendarSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();


                string dir4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir4 = dir4 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir4 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText = ComInitaialsUser.Text.Trim();

                if (chkApplySetting.Checked == true)
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/Calendar/" + SelectedSetting.ToString() + "/Apply").InnerText = "Yes";
                }
                else
                {
                    myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/Calendar/" + SelectedSetting.ToString() + "/Apply").InnerText = "No";
                }



                XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/Calendar/" + SelectedSetting.ToString() + "/Selection");

                root.RemoveAll();

                myDoc.Save(dir4 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");


                if (!string.IsNullOrEmpty(ComCAction.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Action");
                    Element.InnerText = ComCAction.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(ComCClient.Text.Trim()))
                {
                    XmlElement Element = myDoc.CreateElement("Client");
                    Element.InnerText = ComCClient.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(ComCPM.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("PM");
                    Element.InnerText = ComCPM.Text.Trim();
                    root.AppendChild(Element);
                }


                if (!string.IsNullOrEmpty(ComCTM.Text.Trim()))
                {

                    XmlElement Element = myDoc.CreateElement("TM");
                    Element.InnerText = ComCTM.Text.Trim();
                    root.AppendChild(Element);
                }


                if (chkcExpired.Checked == true)
                {
                    XmlElement Element = myDoc.CreateElement("Expired");
                    Element.InnerText = "True";
                    root.AppendChild(Element);
                }

                if (chkcObtained.Checked == true)
                {
                    XmlElement Element = myDoc.CreateElement("Obtained");
                    Element.InnerText = "True";
                    root.AppendChild(Element);
                }

                if (chkCShowOnlyPendingTrack.Checked == true)
                {
                    XmlElement Element = myDoc.CreateElement("OnlyPending");
                    Element.InnerText = "True";
                    root.AppendChild(Element);
                }

                if (chkCSubmitted.Checked == true)
                {
                    XmlElement Element = myDoc.CreateElement("Submitted");
                    Element.InnerText = "True";
                    root.AppendChild(Element);
                }

                myDoc.Save(dir4 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");

                MessageBox.Show("Save VE User Defined Setting Successfully", "VE Software Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

            }
        }

        private void ShowManagerUserDefinedSetting()
        {
            try
            {
                ClearManagerTools();
                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");


                if (!string.IsNullOrEmpty(myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText))
                {
                    ComInitaialsUser.Text = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText;
                }
                else
                {
                    ComInitaialsUser.SelectedIndex = 0;
                }
                if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Prerequired").InnerText == "True")
                {
                    chkMPreRequirment.Checked = true;
                }
                else
                {
                    chkMPreRequirment.Checked = false;
                }
                if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Permits").InnerText == "True")
                {
                    chkMPermits.Checked = true;
                }
                else
                {
                    chkMPermits.Checked = false;
                }
                if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/ShowGrid/Notes").InnerText == "True")
                {
                    chkMNotes.Checked = true;
                }
                else
                {
                    chkMNotes.Checked = false;
                }
                if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" + SelectedSetting.ToString() + "/Apply").InnerText == "Yes")
                {
                    chkApplySetting.Checked = true;
                }
                else
                {
                    chkApplySetting.Checked = false;
                }
                //Dim root As XmlNodeList = myDoc.SelectNodes("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" & SelectedSetting.ToString() & "/Selection")
                XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" + SelectedSetting.ToString() + "/Selection");
                foreach (XmlNode childNode in root.ChildNodes)
                {
                    if (childNode.Name.ToString() == "TM")
                    {
                        comManagerTM.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "TMPending")
                    {
                        ComMTMWithPending.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Comments")
                    {
                        txtMCommentsPreRequire.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Client")
                    {
                        txtMClient.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Job")
                    {
                        txtMJobListJobID.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "PM")
                    {
                        ComMJoblistPM.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "PMrv")
                    {
                        ComJobListPMrv.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Pending")
                    {
                        if (Convert.ToBoolean(childNode.InnerText) == true)
                        {
                            chkMShowOnlyPending.Checked = true;
                        }
                    }
                    if (childNode.Name.ToString() == "NotPending")
                    {
                        if (Convert.ToBoolean(childNode.InnerText) == true)
                        {
                            chkMNotInvoiceJob.Checked = true;
                        }
                    }
                    if (childNode.Name.ToString() == "Address")
                    {
                        txtMJobListAddress.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Town")
                    {
                        txtMTown.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "ClientText")
                    {
                        txtMJoblistClienttext.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Description")
                    {
                        txtMJobListSearchDescription.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Track")
                    {
                        ComMPreRequireTrack.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "TrackSub")
                    {
                        ComMTrackSubPreRequire.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Status")
                    {
                        ComMStatusPreRequire.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "BillStatus")
                    {
                        ComMBillStatePermit.Text = childNode.InnerText;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void ShowTimeSheetUserDefinedSetting()
        {
            try
            {
                ClearTimeSheetTools();
                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (!string.IsNullOrEmpty(myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText))
                {

                    ComInitaialsUser.Text = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText;
                }
                else
                {
                    ComInitaialsUser.SelectedIndex = 0;
                }


                if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TimeSheet/" + SelectedSetting.ToString() + "/Apply").InnerText == "Yes")
                {
                    chkApplySetting.Checked = true;
                }
                else
                {
                    chkApplySetting.Checked = false;
                }

                //Dim root As XmlNodeList = myDoc.SelectNodes("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" & SelectedSetting.ToString() & "/Selection")

                XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TimeSheet/" + SelectedSetting.ToString() + "/Selection");

                foreach (XmlNode childNode in root.ChildNodes)
                {

                    if (childNode.Name.ToString() == "JobsearchJob")
                    {
                        txtTSJobListJob.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "JobSearchClient")
                    {
                        txtTSJobClient.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "JobsearchDescription")
                    {
                        txtTSDescriptionSearchJob.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "JobsearchPM")
                    {
                        ComTSJobPM.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "JobSearchTown")
                    {
                        txtTSJobTown.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "JobSearchAddress")
                    {
                        txtTSJobAddress.Text = childNode.InnerText;
                    }


                    if (childNode.Name.ToString() == "UserJob")
                    {
                        txtTSUserJobNumber.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "UserSearch")
                    {
                        ComTSUserSearch.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "UserStatus")
                    {
                        ComTSStatusUserSearch.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "UserBillStatus")
                    {
                        ComTSBillStatusUserSearch.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "UserAdminStatus")
                    {
                        ComTSAdminStatusUserSearch.Text = childNode.InnerText;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowTasklistUserDefinedSetting()
        {

            try
            {
                ClearTiskListTools();
                XmlDocument myDoc = new XmlDocument();


                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");


                if (!string.IsNullOrEmpty(myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText))
                {

                    ComInitaialsUser.Text = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText;
                }
                else
                {
                    ComInitaialsUser.SelectedIndex = 0;
                }


                if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TaskList/" + SelectedSetting.ToString() + "/Apply").InnerText == "Yes")
                {
                    chkApplySetting.Checked = true;
                }
                else
                {
                    chkApplySetting.Checked = false;
                }

                //Dim root As XmlNodeList = myDoc.SelectNodes("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" & SelectedSetting.ToString() & "/Selection")

                XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/TaskList/" + SelectedSetting.ToString() + "/Selection");

                foreach (XmlNode childNode in root.ChildNodes)
                {
                    if (childNode.Name.ToString() == "JobClient")
                    {
                        txtTaskListJobClient.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "JoblistJob")
                    {
                        txtTaskListJobNumber.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "JobPM")
                    {
                        ComTaskListJobPM.Text = childNode.InnerText;
                    }



                    if (childNode.Name.ToString() == "JobPMrv")
                    {
                        ComTaskListJobPMrv.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "JobTown")
                    {
                        txtTaskListJobTown.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "JobAddress")
                    {
                        txtTaskListJobAddress.Text = childNode.InnerText;
                    }


                    if (childNode.Name.ToString() == "JobClientText")
                    {
                        txtTasklistJobClientText.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "JobDescription")
                    {
                        txtTaskListJobDescription.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "TaskJob")
                    {
                        txtTaskListJobSearch.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "TaskStatus")
                    {
                        ComTaskListJobStatusSearch.Text = childNode.InnerText;
                    }

                    if (childNode.Name.ToString() == "TaskPM")
                    {
                        ComTaskListPMsearch.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "TaskTM")
                    {
                        ComTaskListTMsearch.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "TaskDescription")
                    {
                        txtTaskListDescriptionSearch.Text = childNode.InnerText;
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void ShowCalendarUserDefinedSetting()
        {
            try
            {
                ClearCalendarTools();
                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (!string.IsNullOrEmpty(myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText))
                {
                    ComInitaialsUser.Text = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/ApplyUser").InnerText;
                }
                else
                {
                    ComInitaialsUser.SelectedIndex = 0;
                }
                if (myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/Calendar/" + SelectedSetting.ToString() + "/Apply").InnerText == "Yes")
                {
                    chkApplySetting.Checked = true;
                }
                else
                {
                    chkApplySetting.Checked = false;
                }
                //Dim root As XmlNodeList = myDoc.SelectNodes("/VESoftwareSetting/UserDefinedSetting/ManagerForm/" & SelectedSetting.ToString() & "/Selection")
                XmlNode root = myDoc.SelectSingleNode("/VESoftwareSetting/UserDefinedSetting/Calendar/" + SelectedSetting.ToString() + "/Selection");
                foreach (XmlNode childNode in root.ChildNodes)
                {
                    if (childNode.Name.ToString() == "Action")
                    {
                        ComCAction.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Client")
                    {
                        ComCClient.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "PM")
                    {
                        ComCPM.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "TM")
                    {
                        ComCTM.Text = childNode.InnerText;
                    }
                    if (childNode.Name.ToString() == "Expired")
                    {
                        if (childNode.InnerText == "True")
                        {
                            chkcExpired.Checked = true;
                        }
                        else
                        {
                            chkcExpired.Checked = false;
                        }
                    }
                    if (childNode.Name.ToString() == "Obtained")
                    {
                        if (childNode.InnerText == "True")
                        {
                            chkcObtained.Checked = true;
                        }
                        else
                        {
                            chkcObtained.Checked = false;
                        }
                    }
                    if (childNode.Name.ToString() == "OnlyPending")
                    {
                        if (childNode.InnerText == "True")
                        {
                            chkCShowOnlyPendingTrack.Checked = true;
                        }
                        else
                        {
                            chkCShowOnlyPendingTrack.Checked = false;
                        }
                    }
                    if (childNode.Name.ToString() == "Submitted")
                    {
                        if (childNode.InnerText == "True")
                        {
                            chkCSubmitted.Checked = true;
                        }
                        else
                        {
                            chkCSubmitted.Checked = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void RefreshandLoadSetting()
        {

            if (TCUserSetting.SelectedTab.Text.ToString() == TPManager.Text.ToString())
            {
                if (ComMUserSetting.SelectedIndex != 0)
                {
                    SelectUserDefinedSetting();
                    ShowManagerUserDefinedSetting();
                }
                else
                {
                    ClearManagerTools();
                }

            }
            else if (TCUserSetting.SelectedTab.Text.ToString() == TPCalendarForm.Text.ToString())
            {
                if (ComMUserSetting.SelectedIndex != 0)
                {
                    SelectUserDefinedSetting();
                    ShowCalendarUserDefinedSetting();
                }
                else
                {
                    ClearCalendarTools();
                }

            }
            else if (TCUserSetting.SelectedTab.Text.ToString() == TPTasklistForm.Text.ToString())
            {
                if (ComMUserSetting.SelectedIndex != 0)
                {
                    SelectUserDefinedSetting();
                    ShowTasklistUserDefinedSetting();
                }
                else
                {
                    ClearTiskListTools();
                }

            }
            else if (TCUserSetting.SelectedTab.Text.ToString() == TPTimeSheet.Text.ToString())
            {
                if (ComMUserSetting.SelectedIndex != 0)
                {
                    SelectUserDefinedSetting();
                    ShowTimeSheetUserDefinedSetting();
                }
                else
                {
                    ClearTimeSheetTools();
                }

            }
            else
            {

            }
        }

        #endregion
    }
}