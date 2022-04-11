using DataAccessLayer;
using DataAccessLayer.Model;
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
    public partial class VEAutoInsertSetting : Form
    {
        public VEAutoInsertSetting()
        {
            InitializeComponent();
        }

        #region Events
        private void frmVEAutoInsertSetting_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                FillCombo();
                ShowManagerSetting();
                ShowTasklistSetting();
                ShowCalendarSetting();
            }
            catch (Exception ex)
            {

            }
        }

        private void ComMPerTrack_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {    
                ComMPerTrackSub.Items.Clear();

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPerTrack.SelectedItem.ToString().Trim() + "'").ToList();
                //    ComMPerTrackSub.Items.Add("");
                //    foreach (var item in data)
                //    {
                //        ComMPerTrackSub.Items.Add(item);
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPerTrack.SelectedItem.ToString().Trim() + "'").ToList();
                        ComMPerTrackSub.Items.Add("");
                        foreach (var item in data)
                        {
                            ComMPerTrackSub.Items.Add(item);
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPerTrack.SelectedItem.ToString().Trim() + "'").ToList();
                        ComMPerTrackSub.Items.Add("");
                        foreach (var item in data)
                        {
                            ComMPerTrackSub.Items.Add(item);
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }
        }

        private void ComMNotesTrack_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                ComMNotesTrackSub.Items.Clear();

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMNotesTrack.SelectedItem.ToString().Trim() + "'");
                //    ComMNotesTrackSub.Items.Add("");
                //    foreach (var item in data)
                //    {
                //        ComMNotesTrackSub.Items.Add(item);
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMNotesTrack.SelectedItem.ToString().Trim() + "'");
                        ComMNotesTrackSub.Items.Add("");
                        foreach (var item in data)
                        {
                            ComMNotesTrackSub.Items.Add(item);
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMNotesTrack.SelectedItem.ToString().Trim() + "'");
                        ComMNotesTrackSub.Items.Add("");
                        foreach (var item in data)
                        {
                            ComMNotesTrackSub.Items.Add(item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void ComCTrack_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                ComCTrackSub.Items.Clear();

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComCTrack.SelectedItem.ToString().Trim() + "'");
                //    ComCTrackSub.Items.Add("");
                //    foreach (var item in data)
                //    {
                //        ComCTrackSub.Items.Add(item);
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComCTrack.SelectedItem.ToString().Trim() + "'");
                        ComCTrackSub.Items.Add("");
                        foreach (var item in data)
                        {
                            ComCTrackSub.Items.Add(item);
                        }
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComCTrack.SelectedItem.ToString().Trim() + "'");
                        ComCTrackSub.Items.Add("");
                        foreach (var item in data)
                        {
                            ComCTrackSub.Items.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void ComMPreTrack_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                ComMPreTrackSub.Items.Clear();

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreTrack.SelectedItem.ToString().Trim() + "'");
                //    ComMPreTrackSub.Items.Add("");
                //    foreach (var item in data)
                //    {
                //        ComMPreTrackSub.Items.Add(item);
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreTrack.SelectedItem.ToString().Trim() + "'");
                        ComMPreTrackSub.Items.Add("");
                        foreach (var item in data)
                        {
                            ComMPreTrackSub.Items.Add(item);
                        }
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreTrack.SelectedItem.ToString().Trim() + "'");
                        ComMPreTrackSub.Items.Add("");
                        foreach (var item in data)
                        {
                            ComMPreTrackSub.Items.Add(item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void BtnMClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ManagerClear();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnTasklistClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                TaskListClear();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnCClear_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                CalendarClear();
            }
            catch (Exception ex)
            {

            }

        }

        private void BtnClearAll_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ManagerClear();
                TaskListClear();
                CalendarClear();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(System.Object sender, System.EventArgs e)
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

                DialogResult dailogResult = MessageBox.Show("Are you sure to save Setting for Auto Insert", "VE Software Setting", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dailogResult.ToString() == "Yes")
                {
                    ManagerAutoInsertSetting();
                    CalendarAutoInsertSetting();
                    TasklistAutoInsertSetting();
                }
                else
                {

                }

            }
            catch (Exception ex)
            {

            }
        }

        private void BtnReloadSetting_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ShowManagerSetting();
                ShowCalendarSetting();
                ShowTasklistSetting();
            }
            catch (Exception ex)
            {}
        }

        #endregion

        #region Methods
        private void FillCombo()
        {
            try
            {

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    string temp="";
                    using (ManagerRepository repo1 = new ManagerRepository(temp))
                    {
                        //dt1 = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        var data = repo1.GetMasterItemTMNew();
                        //for (int I = 0; I < data.Rows.Count; I++)


                        ComMPreTM.Items.Add("");
                        ComMNotesTM.Items.Add("");
                        ComMPermitTM.Items.Add("");
                        ComTaskListTM.Items.Add("");
                        ComCTM.Items.Add("");

                        foreach (var item in data)
                        {
                            ComMNotesTM.Items.Add(item.cTrack);
                            ComMPreTM.Items.Add(item.cTrack);
                            ComMPermitTM.Items.Add(item.cTrack);
                            ComCTM.Items.Add(item.cTrack);
                            ComTaskListTM.Items.Add(item.cTrack);
                        }
                        data = null;

                        //dt1 = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        var data1 = repo1.GetMasterItemPMNew();
                        //for (int I = 0; I < dt1.Rows.Count; I++)


                        ComMJobPM.Items.Add("");
                        ComMPMrv.Items.Add("");
                        ComTaskListPM.Items.Add("");

                        foreach (var item in data1)
                        {
                            ComMJobPM.Items.Add(item.cTrack);
                            ComMPMrv.Items.Add(item.cTrack);
                            ComTaskListPM.Items.Add(item.cTrack);
                        }
                    }


                }
                else
                {
                    using (ManagerRepository repo = new ManagerRepository())
                    {
                        //dt1 = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        var data = repo.GetMasterItemTM();
                        //for (int I = 0; I < data.Rows.Count; I++)


                        ComMPreTM.Items.Add("");
                        ComMNotesTM.Items.Add("");
                        ComMPermitTM.Items.Add("");
                        ComTaskListTM.Items.Add("");
                        ComCTM.Items.Add("");

                        foreach (var item in data)
                        {
                            ComMNotesTM.Items.Add(item.cTrack);
                            ComMPreTM.Items.Add(item.cTrack);
                            ComMPermitTM.Items.Add(item.cTrack);
                            ComCTM.Items.Add(item.cTrack);
                            ComTaskListTM.Items.Add(item.cTrack);
                        }
                        data = null;

                        //dt1 = cmbobj.FillDAtatableCombo("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                        var data1 = repo.GetMasterItemPM();
                        //for (int I = 0; I < dt1.Rows.Count; I++)


                        ComMJobPM.Items.Add("");
                        ComMPMrv.Items.Add("");
                        ComTaskListPM.Items.Add("");

                        foreach (var item in data1)
                        {
                            ComMJobPM.Items.Add(item.cTrack);
                            ComMPMrv.Items.Add(item.cTrack);
                            ComTaskListPM.Items.Add(item.cTrack);
                        }
                    }

                }



                //

                List<string> list = new List<string>();
                //***** fill Pre Required Track Combo Box ****




                //using (EFDbContext db = new EFDbContext())
                //{
                //    list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='PreRequirements'  union select '' as TrackName ORDER BY Trackname ").ToList();
                //    // CmbPreRequireTrack.Items.Add("")

                //    ComMPreTrack.Items.Add("");

                //    foreach (var item in list)
                //    {
                //        ComMPreTrack.Items.Add(item);
                //    }
                //    //list.Clear();

                //    //***** fill Permit Track Combo Box ****
                //    list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='Permits/Required/Inspection'  union select '' as TrackName ORDER BY Trackname ").ToList();
                //    // CmbPreRequireTrack.Items.Add("")

                //    ComMPerTrack.Items.Add("");

                //    foreach (var item in list)
                //    {
                //        ComMPerTrack.Items.Add(item);
                //    }

                //    //***** fill Notes Track Combo Box ****
                //    list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='Notes/Communication'  union select '' as TrackName ORDER BY Trackname ").ToList();
                //    // CmbPreRequireTrack.Items.Add("")


                //    ComMNotesTrack.Items.Add("");
                //    foreach (var item in list)
                //    {
                //        ComMNotesTrack.Items.Add(item);
                //    }

                //    //***** fill Calendar Track Combo Box ****
                //    list = db.Database.SqlQuery<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ").ToList();
                //    // CmbPreRequireTrack.Items.Add("")

                //    ComCTrack.Items.Add("");

                //    foreach (var item in list)
                //    {
                //        ComCTrack.Items.Add(item);
                //    }

                //    //***** fill Calendar Job Number Combo Box ****
                //    var jLIst = db.Database.SqlQuery<JobNumList>("select joblistID,JobNumber from JobList WHERE (IsDelete = 0 OR IsDelete IS NULL)   union select 0 as joblistID, '' as JobNumber ").ToList();
                //    // CmbPreRequireTrack.Items.Add("")

                //    ComCJobNumber.DataSource = jLIst;
                //    ComCJobNumber.DisplayMember = "JobNumber";
                //    ComCJobNumber.ValueMember = "joblistID";
                //}





                if (Properties.Settings.Default.IsTestDatabase == true)
                {


                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='PreRequirements'  union select '' as TrackName ORDER BY Trackname ").ToList();
                        // CmbPreRequireTrack.Items.Add("")

                        ComMPreTrack.Items.Add("");

                        foreach (var item in list)
                        {
                            ComMPreTrack.Items.Add(item);
                        }
                        //list.Clear();

                        //***** fill Permit Track Combo Box ****
                        list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='Permits/Required/Inspection'  union select '' as TrackName ORDER BY Trackname ").ToList();
                        // CmbPreRequireTrack.Items.Add("")

                        ComMPerTrack.Items.Add("");

                        foreach (var item in list)
                        {
                            ComMPerTrack.Items.Add(item);
                        }

                        //***** fill Notes Track Combo Box ****
                        list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='Notes/Communication'  union select '' as TrackName ORDER BY Trackname ").ToList();
                        // CmbPreRequireTrack.Items.Add("")


                        ComMNotesTrack.Items.Add("");
                        foreach (var item in list)
                        {
                            ComMNotesTrack.Items.Add(item);
                        }

                        //***** fill Calendar Track Combo Box ****
                        list = db.Database.SqlQuery<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ").ToList();
                        // CmbPreRequireTrack.Items.Add("")

                        ComCTrack.Items.Add("");

                        foreach (var item in list)
                        {
                            ComCTrack.Items.Add(item);
                        }

                        //***** fill Calendar Job Number Combo Box ****
                        var jLIst = db.Database.SqlQuery<JobNumList>("select joblistID,JobNumber from JobList WHERE (IsDelete = 0 OR IsDelete IS NULL)   union select 0 as joblistID, '' as JobNumber ").ToList();
                        // CmbPreRequireTrack.Items.Add("")

                        ComCJobNumber.DataSource = jLIst;
                        ComCJobNumber.DisplayMember = "JobNumber";
                        ComCJobNumber.ValueMember = "joblistID";
                    }



                }
                else
                {


                    using (EFDbContext db = new EFDbContext())
                    {
                        list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='PreRequirements'  union select '' as TrackName ORDER BY Trackname ").ToList();
                        // CmbPreRequireTrack.Items.Add("")

                        ComMPreTrack.Items.Add("");

                        foreach (var item in list)
                        {
                            ComMPreTrack.Items.Add(item);
                        }
                        //list.Clear();

                        //***** fill Permit Track Combo Box ****
                        list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='Permits/Required/Inspection'  union select '' as TrackName ORDER BY Trackname ").ToList();
                        // CmbPreRequireTrack.Items.Add("")

                        ComMPerTrack.Items.Add("");

                        foreach (var item in list)
                        {
                            ComMPerTrack.Items.Add(item);
                        }

                        //***** fill Notes Track Combo Box ****
                        list = db.Database.SqlQuery<string>("select Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null) and TrackSet='Notes/Communication'  union select '' as TrackName ORDER BY Trackname ").ToList();
                        // CmbPreRequireTrack.Items.Add("")


                        ComMNotesTrack.Items.Add("");
                        foreach (var item in list)
                        {
                            ComMNotesTrack.Items.Add(item);
                        }

                        //***** fill Calendar Track Combo Box ****
                        list = db.Database.SqlQuery<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ").ToList();
                        // CmbPreRequireTrack.Items.Add("")

                        ComCTrack.Items.Add("");

                        foreach (var item in list)
                        {
                            ComCTrack.Items.Add(item);
                        }

                        //***** fill Calendar Job Number Combo Box ****
                        var jLIst = db.Database.SqlQuery<JobNumList>("select joblistID,JobNumber from JobList WHERE (IsDelete = 0 OR IsDelete IS NULL)   union select 0 as joblistID, '' as JobNumber ").ToList();
                        // CmbPreRequireTrack.Items.Add("")

                        ComCJobNumber.DataSource = jLIst;
                        ComCJobNumber.DisplayMember = "JobNumber";
                        ComCJobNumber.ValueMember = "joblistID";
                    }


                }



                list = null;
            }
            catch (Exception ex)
            { }
        }

        private void ShowManagerSetting()
        {
            try
            {

                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText == "Yes")
                {
                    chkManagerApply.Checked = true;
                }
                else
                {
                    chkManagerApply.Checked = false;
                }

                ComMJobPM.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Joblist"]["PM"].InnerText;
                ComMPMrv.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Joblist"]["PMrv"].InnerText;
                ComMPreTM.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["TM"].InnerText;
                ComMPreTrack.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["Track"].InnerText;
                ComMPreTrackSub.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["TrackSub"].InnerText;
                txtMPreComment.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["Comments"].InnerText;

                ComMPermitTM.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["TM"].InnerText;
                ComMPerTrack.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["Track"].InnerText;
                ComMPerTrackSub.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["TrackSub"].InnerText;
                txtMpermitComment.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["Comments"].InnerText;

                ComMNotesTM.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["TM"].InnerText;
                ComMNotesTrack.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["Track"].InnerText;
                ComMNotesTrackSub.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["TrackSub"].InnerText;
                txtMNotesComment.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["Comments"].InnerText;

            }
            catch (Exception ex)
            {

            }
        }

        private void ShowCalendarSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Apply"].InnerText == "Yes")
                {
                    chkCalendarApply.Checked = true;
                }
                else
                {
                    chkCalendarApply.Checked = false;
                }

                ComCJobNumber.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Job"].InnerText;
                ComCTM.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["TM"].InnerText;
                ComCTrack.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Track"].InnerText;
                ComCTrackSub.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["TrackSub"].InnerText;
                txtCComment.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Comments"].InnerText;
            }
            catch (Exception ex)
            {

            }
        }

        private void ShowTasklistSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Apply"].InnerText == "Yes")
                {
                    chkTasklistApply.Checked = true;
                }
                else
                {
                    chkTasklistApply.Checked = false;
                }

                ComTaskListPM.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["PM"].InnerText;
                ComTaskListTM.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["TM"].InnerText;
                txtTaskListDescription.Text = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Description"].InnerText;
            }
            catch (Exception ex)
            {

            }
        }

        private void ManagerAutoInsertSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();
                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (chkManagerApply.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText = "Yes";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Apply"].InnerText = "No";
                }

                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Joblist"]["PM"].InnerText = ComMJobPM.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Joblist"]["PMrv"].InnerText = ComMPMrv.Text.Trim();

                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["TM"].InnerText = ComMPreTM.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["Track"].InnerText = ComMPreTrack.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["TrackSub"].InnerText = ComMPreTrackSub.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Prerequired"]["Comments"].InnerText = txtMPreComment.Text.Trim();

                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["TM"].InnerText = ComMPermitTM.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["Track"].InnerText = ComMPerTrack.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["TrackSub"].InnerText = ComMPerTrackSub.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Permit"]["Comments"].InnerText = txtMpermitComment.Text.Trim();

                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["TM"].InnerText = ComMNotesTM.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["Track"].InnerText = ComMNotesTrack.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["TrackSub"].InnerText = ComMNotesTrackSub.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Manager"]["Notes"]["Comments"].InnerText = txtMNotesComment.Text.Trim();

                myDoc.Save(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");
            }
            catch (Exception ex)
            {

            }


        }

        private void CalendarAutoInsertSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (chkCalendarApply.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Apply"].InnerText = "Yes";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Apply"].InnerText = "No";
                }

                myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Job"].InnerText = ComCJobNumber.Text.Trim();

                if (ComCJobNumber.SelectedIndex != 0)
                {
                    myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["JobId"].InnerText = ComCJobNumber.SelectedValue.ToString();
                }
                else
                {
                    myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["JobId"].InnerText = "0";
                }
                myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["TM"].InnerText = ComCTM.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Track"].InnerText = ComCTrack.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["TrackSub"].InnerText = ComCTrackSub.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Comments"].InnerText = txtCComment.Text.Trim();

                myDoc.Save(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");
            }
            catch (Exception ex)
            {

            }
        }

        private void TasklistAutoInsertSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");


                if (chkTasklistApply.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Apply"].InnerText = "Yes";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Apply"].InnerText = "No";
                }

                myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["PM"].InnerText = ComTaskListPM.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["TM"].InnerText = ComTaskListTM.Text.Trim();
                myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Description"].InnerText = txtTaskListDescription.Text.Trim();

                myDoc.Save(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");
            }
            catch (Exception ex)
            {

            }
        }

        private void ManagerClear()
        {
            try
            {
                chkManagerApply.Checked = false;
                ComMJobPM.Text = "";
                ComMPMrv.Text = "";
                ComMPreTM.Text = "";
                ComMPreTrack.Text = "";
                txtMPreComment.Text = "";

                ComMPermitTM.Text = "";
                ComMPerTrack.Text = "";
                txtMpermitComment.Text = "";

                ComMNotesTM.Text = "";
                ComMNotesTrack.Text = "";
                txtMNotesComment.Text = "";

            }
            catch (Exception ex)
            {

            }

        }

        private void TaskListClear()
        {
            try
            {
                chkTasklistApply.Checked = false;
                ComTaskListPM.Text = "";
                ComTaskListTM.Text = "";
                txtTaskListDescription.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void CalendarClear()
        {
            try
            {
                chkCalendarApply.Checked = false;
                ComCJobNumber.Text = "";
                ComCTM.Text = "";
                ComCTrack.Text = "";
                txtCComment.Text = "";
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}