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

using System.Security.Principal;
using System.Diagnostics;

namespace JobTracker.Application_Tool
{
    public partial class FrmPageLoadSetting : Form
    {
        public FrmPageLoadSetting()
        {
            InitializeComponent();
        }

        #region Events
        private void FrmPageLoadSetting_Load(System.Object sender, System.EventArgs e)
        {
            try
            {

                ////ProcessStartInfo proc = new ProcessStartInfo();
                ////proc.UseShellExecute = true;

                ////proc.WorkingDirectory = Environment.CurrentDirectory;

                ////proc.FileName = Application.ExecutablePath;

                ////proc.Verb = "runas";

                ////try
                ////{

                ////    Process.Start(proc);
                ////}
                ////catch
                ////{

                ////    // The user refused the elevation.
                ////    // Do nothing and return directly ...
                ////    return;

                ////}

                ////Application.Exit();  // Quit itself

                ////Application.EnableVisualStyles();
                ////Application.SetCompatibleTextRenderingDefault(false);

                ////WindowsIdentity identity = WindowsIdentity.GetCurrent();
                ////WindowsPrincipal principal = new WindowsPrincipal(identity);


                ////if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                ////{
                ////    MessageBox.Show("You must run this application as administrator. Terminating.");
                ////    Application.Exit();
                ////}

                //////Application.Run(new FormMain());

                ////Application.Run(new FrmPageLoadSetting());



                //WindowsIdentity identity = WindowsIdentity.GetCurrent();
                //WindowsPrincipal principal = new WindowsPrincipal(identity);

                //if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                //{

                //    //MessageBox.Show(" 0 ");

                //    fillCombo();
                //    fillManagerPageLodSetting();
                //    FillTimeSheetPageLoadSetting();
                //    FillTaskListPageLoadSetting();
                //    FillCalendarPageLoadSetting();

                //}
                //else
                //{

                //    //MessageBox.Show("You must run this application as administrator. Terminating.");
                //    //Application.Exit();

                //    // MessageBox.Show("You must run this application as administrator. Terminating.");


                //    //Application.Exit();
                //    //string AppName = String.Concat(Application.StartupPath + "\\JobTracker.exe");
                //    //System.Diagnostics.Process proc = new System.Diagnostics.Process();
                //    ////proc.StartInfo.FileName = "C:\\Windows\\system32\\notepad.exe";
                //    //proc.StartInfo.FileName = AppName;
                //    //proc.StartInfo.Verb = "runas"; // Elevate the application
                //    //proc.StartInfo.UseShellExecute = true;
                //    //proc.Start();

                //    //Application.Exit();

                //    MessageBox.Show(" 1 ");

                //    this.Hide();
                //    //FrmPageLoadSetting.ActiveForm.Hide();


                //    //var exeName = Process.GetCurrentProcess().MainModule.FileName;
                //    //ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                //    //startInfo.Verb = "runas";
                //    //startInfo.Arguments = "restart";
                //    //Process.Start(startInfo);
                //    //this.BeginInvoke(new MethodInvoker(Close));

                //    MessageBox.Show(" 2 ");

                //    var exeName = Process.GetCurrentProcess().MainModule.FileName;

                //    MessageBox.Show(" 3 " , exeName.ToString());

                //    ProcessStartInfo startInfo = new ProcessStartInfo(exeName);
                //    //ProcessStartInfo startInfo = new ProcessStartInfo(AppName);

                //    MessageBox.Show(" 4 ");

                //    startInfo.Verb = "runas";

                //    MessageBox.Show(" 5 ");

                //    startInfo.Arguments = "restart";

                //    MessageBox.Show(" 6 ");

                //    Process.Start(startInfo);

                //    MessageBox.Show(" 7 ");

                //    this.BeginInvoke(new MethodInvoker(Close));

                //    MessageBox.Show(" 8 ");

                //    //MessageBox.Show(" 2 ");
                //    //MessageBox.Show(exeName.ToString());
                //    //MessageBox.Show(startInfo.ToString());

                //    //this.Close();

                //    //this.BeginInvoke(new MethodInvoker(Application.Exit));

                //    //FrmPageLoadSetting.ActiveForm.Close();



                //    //if (!Valid())
                //    //    this.Close;

                //    //if (!Valid())
                //    //    this.BeginInvoke(new MethodInvoker(Close));

                //    //MessageBox.Show(" 3 ");

                //    //this.BeginInvoke(new MethodInvoker(Close));


                //    //if (!Valid())
                //    //    this.BeginInvoke(new MethodInvoker(Close));

                //    //this.Hide();
                //    //Form1 f1 = new Form1();
                //    //f1.ShowDialog();
                //    //this.Close();



                //}

                fillCombo();
                fillManagerPageLodSetting();
                FillTimeSheetPageLoadSetting();
                FillTaskListPageLoadSetting();
                FillCalendarPageLoadSetting();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnMSetting_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                try
                {


                    //string fileName = Application.StartupPath + "\\VESoftwareSetting.xml";


                    string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    dir1 = dir1 + "\\JobTracker";

                    //CheckMail.Load(dir4 + "\\CheckFile.xml");


                    string fileName = dir1 + "\\VESoftwareSetting.xml";

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

                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //CheckMail.Load(dir4 + "\\CheckFile.xml");

//                string fileName = dir4 + "\\VESoftwareSetting.xml";
                
                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TM"].InnerText = comManagerTM.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TMPending"].InnerText = ComMTMWithPending.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Comments"].InnerText = txtMCommentsPreRequire.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Client"].InnerText = txtMClient.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Job"].InnerText = txtMJobListJobID.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PM"].InnerText = ComMJoblistPM.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PMrv"].InnerText = ComJobListPMrv.Text.Trim();
                if (chkMShowOnlyPending.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Pending"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Pending"].InnerText = "False";
                }

                if (chkMNotInvoiceJob.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["NotPending"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["NotPending"].InnerText = "False";
                }

                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Address"].InnerText = txtMJobListAddress.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Town"].InnerText = txtMTown.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["ClientText"].InnerText = txtMJoblistClienttext.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Description"].InnerText = txtMJobListSearchDescription.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Track"].InnerText = ComMPreRequireTrack.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TrackSub"].InnerText = ComMTrackSubPreRequire.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Status"].InnerText = ComMStatusPreRequire.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["BillStatus"].InnerText = ComMBillStatePermit.Text.Trim();


                if (chkMPreRequirment.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PreRequirment"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PreRequirment"].InnerText = "False";
                }
                if (chkMPermits.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Permits"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Permits"].InnerText = "False";
                }

                if (chkMNotes.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Notes"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Notes"].InnerText = "False";
                }


                string dir3 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir3 = dir3 + "\\JobTracker";

                //string fileName = dir5 + "\\VESoftwareSetting.xml";
                
                //string fileName2 = dir5 + "\\VESoftwareSetting.xml";

                myDoc.Save(dir3 + "\\VESoftwareSetting.xml");
                
                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");

                MessageBox.Show("Save Page Load Setting Successfully", "VE Software Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnTSSave_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
               

                //WindowsIdentity identity = WindowsIdentity.GetCurrent();
                //WindowsPrincipal principal = new WindowsPrincipal(identity);

                //if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                //{
                //    //MessageBox.Show("You must run this application as administrator. Terminating.");
                //    //Application.Exit();
                                        
                //    string AppName = String.Concat(Application.StartupPath + "\\JobTracker.exe");

                //    //MessageBox.Show(AppName);

                //    System.Diagnostics.Process proc = new System.Diagnostics.Process();

                //    //proc.StartInfo.FileName = "C:\\Windows\\system32\\notepad.exe";
                //    proc.StartInfo.FileName = AppName;

                //    proc.StartInfo.Verb = "runas"; // Elevate the application
                //    proc.StartInfo.UseShellExecute = true;
                //    proc.Start();
                    
                   
                //}
                //else
                //{ 

                try
                {

                    string dir4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir4 = dir4 + "\\JobTracker";

                    //CheckMail.Load(dir4 + "\\CheckFile.xml");

                    string fileName1 = dir4 + "\\VESoftwareSetting.xml";

                    //string fileName = Application.StartupPath + "\\VESoftwareSetting.xml";


                    FileSecurity fSecurity = File.GetAccessControl(fileName1);
                    FileInfo fSecurity1 = new FileInfo(fileName1);
                    fSecurity1.IsReadOnly = false;
                    string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    fSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
                    File.SetAccessControl(fileName1, fSecurity);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


                XmlDocument myDoc = new XmlDocument();

                string dir5 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir5 = dir5 + "\\JobTracker";

                //CheckMail.Load(dir4 + "\\CheckFile.xml");


                string fileName = dir5 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir5 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Job"].InnerText = txtTSJobListJob.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Client"].InnerText = txtTSJobClient.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Description"].InnerText = txtTSDescriptionSearchJob.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["PM"].InnerText = ComTSPM.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Town"].InnerText = txtTSTown.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Address"].InnerText = txtTSAddress.Text.Trim();


                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["Job"].InnerText = txtTSUserJobNumber.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["User"].InnerText = ComTSUserSearch.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["Status"].InnerText = ComTSStatus.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["BillStatus"].InnerText = ComTSBillStatus.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["AdminStatus"].InnerText = ComTSAdminStatus.Text.Trim();


                string dir7 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir7 = dir7 + "\\JobTracker";

                //CheckMail.Load(dir4 + "\\CheckFile.xml");


                string fileName7 = dir7 + "\\VESoftwareSetting.xml";

                //myDoc.Load(dir7 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");


                myDoc.Save(dir7 + "\\VESoftwareSetting.xml");

                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");
                MessageBox.Show("Save Page Load Setting Successfully", "VE Software Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}



            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message.ToString());
            }





        }

        private void btnTaskListSave_Click(System.Object sender, System.EventArgs e)
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

                XmlDocument myDoc = new XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir1 + "\\VESoftwareSetting.xml";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Client"].InnerText = txtTaskListJobClient.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Job"].InnerText = txtTaskListJobNumber.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["PM"].InnerText = ComTaskListJobPM.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["PMrv"].InnerText = ComTaskListJobPMrv.Text.Trim();
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Town"].InnerText = txtTaskListJobTown.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Address"].InnerText = txtTaskListJobAddress.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["ClientText"].InnerText = txtTasklistJobClientText.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Description"].InnerText = txtTaskListJobDescription.Text;

                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Job"].InnerText = txtTaskListJobSearch.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Status"].InnerText = ComTaskListJobStatusSearch.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["PM"].InnerText = ComTaskListPMsearch.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["TM"].InnerText = ComTaskListTMsearch.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Description"].InnerText = txtTaskListDescriptionSearch.Text;

                myDoc.Save(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");

                MessageBox.Show("Save Page Load Setting Successfully", "VE Software Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCSave_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                try
                {
                    string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    dir1 = dir1 + "\\JobTracker";

                    //CheckMail.Load(dir4 + "\\CheckFile.xml");


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

                XmlDocument myDoc = new XmlDocument();


                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (chkCSubmitted.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Submitted"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Submitted"].InnerText = "False";
                }

                if (chkcObtained.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Obtained"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Obtained"].InnerText = "False";
                }

                if (chkcExpired.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Expired"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Expired"].InnerText = "False";
                }

                if (chkCShowOnlyPendingTrack.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["PendingTraks"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["PendingTraks"].InnerText = "False";
                }

                myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Client"].InnerText = ComCClient.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Action"].InnerText = ComCAction.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["PM"].InnerText = ComCPM.Text;
                myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["TM"].InnerText = ComCTM.Text;


                myDoc.Save(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");

                MessageBox.Show("Save Page Load Setting Successfully", "VE Software Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }

        }
        
        private void ComMPreRequireTrack_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                ComMTrackSubPreRequire.Items.Clear();


                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreRequireTrack.SelectedItem.ToString().Trim() + "'").ToList();
                //    ComMTrackSubPreRequire.Items.Add("");
                //    foreach (var item in data)
                //    {
                //        ComMTrackSubPreRequire.Items.Add(item);
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreRequireTrack.SelectedItem.ToString().Trim() + "'").ToList();
                        ComMTrackSubPreRequire.Items.Add("");
                        foreach (var item in data)
                        {
                            ComMTrackSubPreRequire.Items.Add(item);
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<string>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + ComMPreRequireTrack.SelectedItem.ToString().Trim() + "'").ToList();
                        ComMTrackSubPreRequire.Items.Add("");
                        foreach (var item in data)
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

        private void btnMClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                comManagerTM.Text = "";
                txtMCommentsPreRequire.Text = "";
                ComMTMWithPending.Text = "";

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

                chkMPreRequirment.Checked = false;
                chkMPermits.Checked = false;
                chkMNotes.Checked = false;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnTSClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                txtTSJobListJob.Text = "";
                txtTSJobClient.Text = "";
                txtTSDescriptionSearchJob.Text = "";
                ComTSPM.Text = "";
                txtTSTown.Text = "";
                txtTSAddress.Text = "";

                txtTSUserJobNumber.Text = "";
                ComTSUserSearch.Text = "";
                ComTSStatus.Text = "";
                ComTSBillStatus.Text = "";
                ComTSAdminStatus.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void btnTasklistClear_Click(System.Object sender, System.EventArgs e)
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

        private void btnCalendarClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                chkCSubmitted.Checked = false;

                chkcObtained.Checked = false;

                chkcExpired.Checked = false;

                chkCShowOnlyPendingTrack.Checked = false;


                ComCClient.Text = "";
                ComCAction.Text = "";
                ComCPM.Text = "";
                ComCTM.Text = "";
            }
            catch (Exception ex)
            {

            }
        }

        private void TabControl1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                fillManagerPageLodSetting();
                FillTimeSheetPageLoadSetting();
                FillTaskListPageLoadSetting();
                FillCalendarPageLoadSetting();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Functions
        private void fillCombo()
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
                ComTSPM.Items.Add("");

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
                    ComTSPM.Items.Add(item);
                    ComTaskListPMsearch.Items.Add(item);
                    ComTaskListJobPM.Items.Add(item);
                    ComTaskListJobPMrv.Items.Add(item);
                    ComCPM.Items.Add(item);
                }
                //***** fill Manager Track Combo Box ****                

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db.Database.SqlQuery<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ").ToList();
                        // CmbPreRequireTrack.Items.Add("")


                        ComMPreRequireTrack.Items.Add("");

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

                        //****** Fill TaskList State Combo Box **********
                        //Dim query1 As String = "SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack"
                        //ComTaskListJobStatusSearch.DisplayMember = "cTrack"
                        //ComTaskListJobStatusSearch.ValueMember = "Id"
                        //dt1 = cmbobj.Filldatatable(query1)
                        //ComTaskListJobStatusSearch.DataSource = dt1

                        ComTaskListJobStatusSearch.DisplayMember = "cTrack";
                        ComTaskListJobStatusSearch.ValueMember = "Id";

                        var data2 = db.Database.SqlQuery<colPMM>("SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack").ToList();
                        ComTaskListJobStatusSearch.DataSource = data2;


                        ComMBillStatePermit.Items.Add("");

                        //***** Fill Bill Status ComBox *****                    
                        list = db.Database.SqlQuery<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) union select '' as cTrack ORDER BY cTrack").ToList();
                        ComMBillStatePermit.DataSource = list;
                        ComMBillStatePermit.DisplayMember = "cTrack";
                        ComMBillStatePermit.SelectedIndex = -1;

                        //****** Fill Time Sheet Bill Status CobboBox *********
                        var masteritem = db.Database.SqlQuery<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='BILL STATE' union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId ").ToList();

                        ComTSBillStatus.DisplayMember = "Value";
                        ComTSBillStatus.ValueMember = "TS_MasterItemId";
                        ComTSBillStatus.DataSource = masteritem;
                        ComTSBillStatus.SelectedIndex = 0;

                        //******* Fill Time Sheet Status Combo Box ********

                        //var dtTSStatus = StMethod.GetListDT<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='STATUS' AND UserType='U'  union SELECT 0 as TS_MasterItemId,'' as value order by Value ");


                        var dtTSStatus = StMethod.GetListDTNew<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='STATUS' AND UserType='U'  union SELECT 0 as TS_MasterItemId,'' as value order by Value ");



                        ComTSStatus.DataSource = dtTSStatus;
                        ComTSStatus.DisplayMember = "Value";
                        ComTSStatus.ValueMember = "TS_MasterItemId";

                        //////////***** Fill Time Sheet User Combo Box ********
                        ////////DataTable dtTSUser = null;
                        //////////Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()
                        ////////SqlConnection con = new SqlConnection(Dal.ConnectionStringPCTracker);
                        ////////dtTSUser = Dal.Filldatatable("use " + con.Database + " SELECT  EmployeeDetailsId, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");
                        ////////ComTSUserSearch.DisplayMember = "UserName";
                        ////////ComTSUserSearch.ValueMember = "EmployeeDetailsId";
                        ////////ComTSUserSearch.DataSource = dtTSUser;



                        //var dtusers = StMethod.GetListDT<dtoUsers>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");


                        //var dtusers = StMethod.GetListDT<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");

                        var dtusers = StMethod.GetListDTNew<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");

                        ComTSUserSearch.DisplayMember = "UserName";
                        ComTSUserSearch.ValueMember = "Id";
                        ComTSUserSearch.DataSource = dtusers;

                        //****** Fill Time Sheet Admin Status ComBo box ******
                        masteritem = db.Database.SqlQuery<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'  union SELECT 0 as TS_MasterItemId,'' union SELECT 1 as TS_MasterItemId,'None' as value order by Value").ToList();
                        ComTSAdminStatus.DisplayMember = "Value";
                        ComTSAdminStatus.ValueMember = "TS_MasterItemId";
                        ComTSAdminStatus.DataSource = masteritem;

                        //******* fill Calendar Client Combobox *****
                        var companydata = db.Database.SqlQuery<CompanyIDs>("SELECT CompanyName,CompanyID  FROM dbo.Company Union Select '' as CompanyName,0 as CompanyID ORDER BY CompanyName").ToList();
                        //companydata.Add(new CompanyIDs() { CompanyID = 0, CompanyName = "" });
                        //ComCClient.DataSource = companydata.OrderBy(r => r.CompanyID);
                        ComCClient.DataSource = companydata;
                        ComCClient.DisplayMember = "CompanyName";
                        ComCClient.ValueMember = "CompanyID";
                        //ComCClient.SelectedIndex = 0;
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<string>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is null)   union select '' as TrackName ").ToList();
                        // CmbPreRequireTrack.Items.Add("")


                        ComMPreRequireTrack.Items.Add("");

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

                        //****** Fill TaskList State Combo Box **********
                        //Dim query1 As String = "SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack"
                        //ComTaskListJobStatusSearch.DisplayMember = "cTrack"
                        //ComTaskListJobStatusSearch.ValueMember = "Id"
                        //dt1 = cmbobj.Filldatatable(query1)
                        //ComTaskListJobStatusSearch.DataSource = dt1

                        ComTaskListJobStatusSearch.DisplayMember = "cTrack";
                        ComTaskListJobStatusSearch.ValueMember = "Id";
                        var data2 = db.Database.SqlQuery<colPMM>("SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack").ToList();
                        ComTaskListJobStatusSearch.DataSource = data2;


                        ComMBillStatePermit.Items.Add("");

                        //***** Fill Bill Status ComBox *****                    
                        list = db.Database.SqlQuery<string>("SELECT cTrack FROM MasterItem WHERE cGroup='Bill State' and (IsDelete=0 or IsDelete is null) union select '' as cTrack ORDER BY cTrack").ToList();
                        ComMBillStatePermit.DataSource = list;
                        ComMBillStatePermit.DisplayMember = "cTrack";
                        ComMBillStatePermit.SelectedIndex = -1;

                        //****** Fill Time Sheet Bill Status CobboBox *********
                        var masteritem = db.Database.SqlQuery<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='BILL STATE' union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId ").ToList();

                        ComTSBillStatus.DisplayMember = "Value";
                        ComTSBillStatus.ValueMember = "TS_MasterItemId";
                        ComTSBillStatus.DataSource = masteritem;
                        ComTSBillStatus.SelectedIndex = 0;

                        //******* Fill Time Sheet Status Combo Box ********
                        var dtTSStatus = StMethod.GetListDT<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='STATUS' AND UserType='U'  union SELECT 0 as TS_MasterItemId,'' as value order by Value ");
                        ComTSStatus.DataSource = dtTSStatus;
                        ComTSStatus.DisplayMember = "Value";
                        ComTSStatus.ValueMember = "TS_MasterItemId";

                        //////////***** Fill Time Sheet User Combo Box ********
                        ////////DataTable dtTSUser = null;
                        //////////Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()
                        ////////SqlConnection con = new SqlConnection(Dal.ConnectionStringPCTracker);
                        ////////dtTSUser = Dal.Filldatatable("use " + con.Database + " SELECT  EmployeeDetailsId, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");
                        ////////ComTSUserSearch.DisplayMember = "UserName";
                        ////////ComTSUserSearch.ValueMember = "EmployeeDetailsId";
                        ////////ComTSUserSearch.DataSource = dtTSUser;



                        //var dtusers = StMethod.GetListDT<dtoUsers>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");


                        var dtusers = StMethod.GetListDT<dtoUsersNew>("SELECT Id, UserName FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by UserName");


                        ComTSUserSearch.DisplayMember = "UserName";
                        ComTSUserSearch.ValueMember = "Id";
                        ComTSUserSearch.DataSource = dtusers;

                        //****** Fill Time Sheet Admin Status ComBo box ******
                        masteritem = db.Database.SqlQuery<MasterData>("SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'  union SELECT 0 as TS_MasterItemId,'' union SELECT 1 as TS_MasterItemId,'None' as value order by Value").ToList();
                        ComTSAdminStatus.DisplayMember = "Value";
                        ComTSAdminStatus.ValueMember = "TS_MasterItemId";
                        ComTSAdminStatus.DataSource = masteritem;

                        //******* fill Calendar Client Combobox *****
                        var companydata = db.Database.SqlQuery<CompanyIDs>("SELECT CompanyName,CompanyID  FROM dbo.Company Union Select '' as CompanyName,0 as CompanyID ORDER BY CompanyName").ToList();
                        //companydata.Add(new CompanyIDs() { CompanyID = 0, CompanyName = "" });
                        //ComCClient.DataSource = companydata.OrderBy(r => r.CompanyID);
                        ComCClient.DataSource = companydata;
                        ComCClient.DisplayMember = "CompanyName";
                        ComCClient.ValueMember = "CompanyID";
                        //ComCClient.SelectedIndex = 0;
                    }

                }





                ////////////////
            }
            catch (Exception ex)
            {

            }
        }

        private void fillManagerPageLodSetting()
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
                }


                comManagerTM.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TM"].InnerText;
                ComMTMWithPending.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TMPending"].InnerText;
                txtMCommentsPreRequire.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Comments"].InnerText;
                txtMClient.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Client"].InnerText;
                txtMJobListJobID.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Job"].InnerText;
                ComMJoblistPM.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PM"].InnerText;
                ComJobListPMrv.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PMrv"].InnerText;

                if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Pending"].InnerText == "True")
                {
                    chkMShowOnlyPending.Checked = true;
                }
                else
                {
                    chkMShowOnlyPending.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["NotPending"].InnerText == "True")
                {
                    chkMNotInvoiceJob.Checked = true;
                }
                else
                {
                    chkMNotInvoiceJob.Checked = false;
                }

                txtMJobListAddress.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Address"].InnerText;
                txtMTown.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Town"].InnerText;
                txtMJoblistClienttext.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["ClientText"].InnerText;
                txtMJobListSearchDescription.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Description"].InnerText;
                ComMPreRequireTrack.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Track"].InnerText;
                ComMTrackSubPreRequire.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["TrackSub"].InnerText;
                ComMStatusPreRequire.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Status"].InnerText;
                ComMBillStatePermit.Text = myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["BillStatus"].InnerText;

                if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["PreRequirment"].InnerText == "True")
                {
                    chkMPreRequirment.Checked = true;
                }
                else
                {
                    chkMPreRequirment.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Permits"].InnerText == "True")
                {
                    chkMPermits.Checked = true;
                }
                else
                {
                    chkMPermits.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["ManagerForm"]["Notes"].InnerText == "True")
                {
                    chkMNotes.Checked = true;
                }
                else
                {
                    chkMNotes.Checked = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void FillTimeSheetPageLoadSetting()
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
                }

                txtTSJobListJob.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Job"].InnerText;
                txtTSJobClient.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Client"].InnerText;
                txtTSDescriptionSearchJob.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Description"].InnerText;
                ComTSPM.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["PM"].InnerText;
                txtTSTown.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Town"].InnerText;
                txtTSAddress.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Address"].InnerText;

                txtTSUserJobNumber.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["Job"].InnerText;
                ComTSUserSearch.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["User"].InnerText;
                ComTSStatus.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["Status"].InnerText;
                ComTSBillStatus.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["BillStatus"].InnerText;
                ComTSAdminStatus.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["AdminStatus"].InnerText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void FillTaskListPageLoadSetting()
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
            }

            try
            {
                txtTaskListJobClient.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Client"].InnerText;
                txtTaskListJobNumber.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Job"].InnerText;
                ComTaskListJobPM.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["PM"].InnerText;
                ComTaskListJobPMrv.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["PMrv"].InnerText;
                txtTaskListJobTown.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Town"].InnerText;
                txtTaskListJobAddress.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Address"].InnerText;
                txtTasklistJobClientText.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["ClientText"].InnerText;
                txtTaskListJobDescription.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Description"].InnerText;


                txtTaskListJobSearch.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Job"].InnerText;
                ComTaskListJobStatusSearch.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Status"].InnerText;
                ComTaskListPMsearch.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["PM"].InnerText;
                ComTaskListTMsearch.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["TM"].InnerText;
                txtTaskListDescriptionSearch.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Description"].InnerText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }



        }

        private void FillCalendarPageLoadSetting()
        {

            try
            {
                XmlDocument myDoc = new XmlDocument();


                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                if (myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Submitted"].InnerText == "True")
                {
                    chkCSubmitted.Checked = true;
                }
                else
                {
                    chkCSubmitted.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Obtained"].InnerText == "True")
                {
                    chkcObtained.Checked = true;
                }
                else
                {
                    chkcObtained.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Expired"].InnerText == "True")
                {
                    chkcExpired.Checked = true;
                }
                else
                {
                    chkcExpired.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["PendingTraks"].InnerText == "True")
                {
                    chkCShowOnlyPendingTrack.Checked = true;
                }
                else
                {
                    chkCShowOnlyPendingTrack.Checked = false;
                }

                ComCClient.Text = myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Client"].InnerText;
                ComCAction.Text = myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Action"].InnerText;
                ComCPM.Text = myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["PM"].InnerText;
                ComCTM.Text = myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["TM"].InnerText;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        #endregion
    }
}