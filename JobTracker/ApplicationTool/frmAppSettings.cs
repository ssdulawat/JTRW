using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
using JobTracker.ConnectionStringSetting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JobTracker.Application_Tool
{
    public partial class frmAppSettings : Form
    {
        #region Global Variable
        #endregion

        public frmAppSettings()
        {
            InitializeComponent();
        }

        #region Events
        private void frmBackup_Load(object sender, System.EventArgs e)
        {
            BackUpDatabase.CreateConection(global::JobTracker.Properties.Settings.Default.MastreTable);
            //Con = new SqlConnection(); //(My.MySettings.Default.Setting)
            //Con = BackUpDatabase.SqlCon;
            FillCmbDatabase();
            lblBakFileName.Text = "VariousInfo" + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MMM") + DateTime.Now.ToString("yyyy");
            //lblBakAddress.Text = "D:\\WORKPLACE\\VE_net\\VE\\JobVe\\" + lblBakFileName.Text;
            lblBakAddress.Text = "D:\\DB_Backup\\" + lblBakFileName.Text;
            GetEmailAddress();
            SetShedule();
            txtAgingPath.Text = Program.GetAgingFilePath();

            //chkActiveWebUpload.Checked = Program.CheckActiveWebUploadStatus();

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                chkActiveWebUpload.Checked = Program.CheckActiveWebUploadStatusNew();
            }
            else
            {
                chkActiveWebUpload.Checked = Program.CheckActiveWebUploadStatus();
            }

            if (ConnectionStringsSetting.IsLocalDatabase)
            {
                rdbIsLocalDatabase.Checked = true;
            }
            else
            {
                rdbIsServerDatabase.Checked = true;
            }
        }

        private void btnSaveSchedule_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                char Schedule = '\0';
                Schedule = (rdbDaily.Checked == Convert.ToBoolean(CheckState.Checked) || rdbDaily.Checked == true) ? 'D' : 'W';

                string query = "UPDATE AppSetting SET CompareSchedule='" + Schedule +
                    "' ,CompareActiveTimer=" + ChkSchedule.CheckState + " " +
                    " Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)";

                int ? CompareActiveTimer=null;

                if (ChkSchedule.Checked == true)
                {
                    CompareActiveTimer = 1;
                }
                else if (ChkSchedule.Checked == false)
                {
                    CompareActiveTimer = 0;
                }

                // CompareActiveTimer = 1 is for true value for bit datatype filed "CompareActiveTimer" of "AppSetting" table


                //if (StMethod.UpdateRecord("UPDATE AppSetting SET CompareSchedule='" + Schedule + "' ,CompareActiveTimer=" + ChkSchedule.CheckState + "  Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)") > 0)

                //if (StMethod.UpdateRecord("UPDATE AppSetting SET CompareSchedule='" + Schedule + "' ,CompareActiveTimer=" + CompareActiveTimer + "  Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)") > 0)
                //{
                //    KryptonMessageBox.Show("Save Successfully", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    if (StMethod.UpdateRecordNew("UPDATE AppSetting SET CompareSchedule='" + Schedule + "' ,CompareActiveTimer=" + CompareActiveTimer + "  Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)") > 0)
                    {
                        KryptonMessageBox.Show("Save Successfully", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {

                    if (StMethod.UpdateRecord("UPDATE AppSetting SET CompareSchedule='" + Schedule + "' ,CompareActiveTimer=" + CompareActiveTimer + "  Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)") > 0)
                    {
                        KryptonMessageBox.Show("Save Successfully", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }



                if (ChkSchedule.Checked == true)
                {
                    Program.ofrmMain.timerGet.Enabled = true;
                    Program.ofrmMain.timerGet.Start();
                }
                else
                {
                    Program.ofrmMain.timerGet.Enabled = true;
                    Program.ofrmMain.timerGet.Start();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnBakDatabase_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                //BackUpDatabase.TakeDatabaseBackUp(lblBakAddress.Text.Trim(), cmbDatabaseName.Text);

                string FinalPath = "";



                //FinalPath = lblBakAddress.Text.Trim() + lblBakFileName.Text.Trim();



                //FinalPath = lblBakAddress.Text.Trim() + "\\" + lblBakFileName.Text.Trim();

                FinalPath = lblBakAddress.Text.Trim() + "-" + lblBakFileName.Text.Trim();


                //MessageBox.Show(lblBakAddress.Text.ToString());
                //MessageBox.Show(lblBakFileName.Text.ToString());

                //MessageBox.Show(FinalPath);

                //MessageBox.Show(cmbDatabaseName.Text.ToString());

              

                //MessageBox.Show("BackupQuery is : " + FinalPath.ToString(),
                //                Application.ProductName,
                //                MessageBoxButtons.OK,
                //                MessageBoxIcon.Information);

                //string BackupQuery = "BACKUP DATABASE " + cmbDatabaseName.Text.ToString().Trim() + " TO DISK = '" + FinalPath + "'";

                //MessageBox.Show(" BackupQuery is " + BackupQuery.ToString());

                string BackupPath = FinalPath;
                string BakupFileName = cmbDatabaseName.Text.ToString().Trim();



                //BackUpDatabase.TakeDatabaseBackUpEdited(BackupPath, cmbDatabaseName.Text.ToString().Trim());

                BackUpDatabase.TakeDatabaseBackUpTest(BackupPath, cmbDatabaseName.Text.ToString().Trim());





                //BACKUP DATABASE TestVariousInfo_WithData
                //TO DISK = 'D:\PCTracker'


                //BackUpDatabase.TakeDatabaseBackUp(lblBakFileName.Text.Trim(), cmbDatabaseName.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           

        }

        private void txtbakFilename_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (((int)e.KeyChar) == 13)
            {
                lblBakFileName.Text = txtbakFilename.Text + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MMM") + DateTime.Now.ToString("yyyy");
            }
        }

        private void txtbakFilename_TextChanged(System.Object sender, System.EventArgs e)
        {
            lblBakFileName.Text = txtbakFilename.Text + DateTime.Now.ToString("dd") + DateTime.Now.ToString("MMM") + DateTime.Now.ToString("yyyy");
        }

        private void btnSaveEmailSetting_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();

                string dir4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir4 = dir4 + "\\JobTracker";

                CheckMail.Load(dir4 + "\\CheckFile.xml");

                //CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");

                XmlNode MailSetting = CheckMail.SelectSingleNode("/EmailReminder/Email");
                MailSetting.ChildNodes.Item(0).InnerText = this.txtEmailaddress.Text.Trim();
                MailSetting.ChildNodes.Item(1).InnerText = this.txtEmailpassword.Text.Trim();
                MailSetting.ChildNodes.Item(2).InnerText = this.txtMailSeverInvoice.Text;
                MailSetting.ChildNodes.Item(3).InnerText = Convert.ToInt32(chkSSLInvoice.CheckState).ToString();


                CheckMail.Save(dir4 + "\\CheckFile.xml");
                //CheckMail.Save(Application.StartupPath + "\\CheckFile.xml");


                KryptonMessageBox.Show("Setting save successfully");
            }
            catch (IOException ex1)
            {
                KryptonMessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                KryptonMessageBox.Show(ex2.Message + " Please check the access right of it.");
            }
        }

        private void btnSaveEmailPendingSetting_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();

                string dir4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir4 = dir4 + "\\JobTracker";

                CheckMail.Load(dir4 + "\\CheckFile.xml");

                //CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");


                XmlNode MailSetting = CheckMail.SelectSingleNode("/EmailReminder/PNDEmail");
                MailSetting.ChildNodes.Item(0).InnerText = this.txtEmailAddressItem.Text.Trim();
                MailSetting.ChildNodes.Item(1).InnerText = this.txtPasswordItem.Text.Trim();
                MailSetting.ChildNodes.Item(2).InnerText = this.txtMailServerNameItem.Text;
                MailSetting.ChildNodes.Item(3).InnerText = Convert.ToInt32(ChkSSLItem.CheckState).ToString();

                CheckMail.Save(dir4 + "\\CheckFile.xml");
                //CheckMail.Save(Application.StartupPath + "\\CheckFile.xml");

                KryptonMessageBox.Show("Setting save successfully");
            }
            catch (IOException ex1)
            {
                KryptonMessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                KryptonMessageBox.Show(ex2.Message + " Please check the access right of it.");
            }
        }

        private void btnUpdateAgingDir_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                SqlCommand CMd = new SqlCommand();
                CMd.CommandText = "UPDATE AgingFileInfo SET FilePath=@path WHERE AgingFileId =(SELECT MAX(AgingFileId) FROM AgingFileInfo)";
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@path", txtAgingPath.Text.Trim()));

                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(CMd.CommandText.ToString(), Param.ToArray()) > 0)
                //    {
                //        KryptonMessageBox.Show("Changes Save", "App Setting");
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        if (db.Database.ExecuteSqlCommand(CMd.CommandText.ToString(), Param.ToArray()) > 0)
                        {
                            KryptonMessageBox.Show("Changes Save", "App Setting");
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand(CMd.CommandText.ToString(), Param.ToArray()) > 0)
                        {
                            KryptonMessageBox.Show("Changes Save", "App Setting");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgingLogfile_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                //FileInfo FileInfo = new FileInfo(Program.GetAgingFilePath() + "/AgingLogFile.txt");
                //if (FileInfo.Exists)
                //{
                //    Process.Start(Program.GetAgingFilePath() + "/AgingLogFile.txt");
                //}
                //else
                //{
                //    KryptonMessageBox.Show("Aging log file not available here at location (" + Program.GetAgingFilePath() + "/AgingLogFile.txt)", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    FileInfo FileInfo = new FileInfo(Program.GetAgingFilePathNew() + "/AgingLogFile.txt");
                    if (FileInfo.Exists)
                    {
                        Process.Start(Program.GetAgingFilePathNew() + "/AgingLogFile.txt");
                    }
                    else
                    {
                        KryptonMessageBox.Show("Aging log file not available here at location (" + Program.GetAgingFilePath() + "/AgingLogFile.txt)", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    FileInfo FileInfo = new FileInfo(Program.GetAgingFilePath() + "/AgingLogFile.txt");
                    if (FileInfo.Exists)
                    {
                        Process.Start(Program.GetAgingFilePath() + "/AgingLogFile.txt");
                    }
                    else
                    {
                        KryptonMessageBox.Show("Aging log file not available here at location (" + Program.GetAgingFilePath() + "/AgingLogFile.txt)", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void btnActiveDataUpload_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                //using (EFDbContext db = new EFDbContext())
                //{

                //    int? ActiveWebUpload = null;

                //    if (chkActiveWebUpload.Checked == true)
                //    {
                //        ActiveWebUpload = 1;
                //    }
                //    else if (chkActiveWebUpload.Checked == false)
                //    {
                //        ActiveWebUpload = 0;
                //    }

                //    if (db.Database.ExecuteSqlCommand("UPDATE AppSetting SET ActiveWebUpload ='" + ActiveWebUpload + "'  Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)") > 0)
                //    {
                //        KryptonMessageBox.Show("Save Successfully", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {                    
                    using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                    {

                        int? ActiveWebUpload = null;

                        if (chkActiveWebUpload.Checked == true)
                        {
                            ActiveWebUpload = 1;
                        }
                        else if (chkActiveWebUpload.Checked == false)
                        {
                            ActiveWebUpload = 0;
                        }

                        if (db2.Database.ExecuteSqlCommand("UPDATE AppSetting SET ActiveWebUpload ='" + ActiveWebUpload + "'  Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)") > 0)
                        {
                            KryptonMessageBox.Show("Save Successfully", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {

                        int? ActiveWebUpload = null;

                        if (chkActiveWebUpload.Checked == true)
                        {
                            ActiveWebUpload = 1;
                        }
                        else if (chkActiveWebUpload.Checked == false)
                        {
                            ActiveWebUpload = 0;
                        }

                        if (db.Database.ExecuteSqlCommand("UPDATE AppSetting SET ActiveWebUpload ='" + ActiveWebUpload + "'  Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)") > 0)
                        {
                            KryptonMessageBox.Show("Save Successfully", "App Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnChangesDataBase_Click(System.Object sender, System.EventArgs e)
        {
            var boolSelectDB = false;
            if (rdbIsLocalDatabase.Checked)
            {
                boolSelectDB = true;
            }
            ConnectionStringsSetting.IsLocalDatabase = boolSelectDB;
            // My.MySettings.Default.Save()
            MessageBox.Show("Please Start your JT application again.", "Application Close", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Application.Exit();
        }

        private void btnSetConnectionString_Click(System.Object sender, System.EventArgs e)
        {
            //FrmChangeDataBase.Show();
        }

        private void rdbIsLocalDatabase_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            btnSetConnectionString.Visible = rdbIsLocalDatabase.Checked;
            //Current Local Connection String :
            if (string.IsNullOrEmpty(ConnectionStringsSetting.LocalConnectionString.Trim()))
            {
                lblLocalConnectionstring.Text = "Current Local Connection String : Currently there is no any connection with local. Please setup your local connection";
            }
            else
            {
                lblLocalConnectionstring.Text = "Current Local Connection String : " + ConnectionStringsSetting.LocalConnectionString;
            }
            lblLocalConnectionstring.Visible = rdbIsLocalDatabase.Checked;
        }
        #endregion

        #region Methods
        private void SetShedule()
        {
            try
            {
                List<AppSettings> settings = new List<AppSettings>();


                //using (EFDbContext db = new EFDbContext())
                //{
                //    settings = db.Database.SqlQuery<AppSettings>("SELECT CompareSchedule,CompareActiveTimer FROM AppSetting Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)").ToList();
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        settings = db.Database.SqlQuery<AppSettings>("SELECT CompareSchedule,CompareActiveTimer FROM AppSetting Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)").ToList();
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        settings = db.Database.SqlQuery<AppSettings>("SELECT CompareSchedule,CompareActiveTimer FROM AppSetting Where Appid=(SELECT  ISNull(MAX(Appid),0) as Appid FROM AppSetting)").ToList();
                    }
                }


                if (settings != null)
                {
                    ChkSchedule.Checked = settings.Select(x => x.CompareActiveTimer).FirstOrDefault();
                    rdbWeekly.Checked = (settings.Select(x => x.CompareSchedule).FirstOrDefault().ToString() == "W");
                }
            }
            catch (Exception ex)
            {

            }
        }

        //public bool CheckActiveWebUploadStatus()
        //{
        //    bool bRet = false;
        //    try
        //    {
        //        AppSettings settings = new AppSettings();
        //        using (EFDbContext db = new EFDbContext())
        //        {
        //            settings = db.Database.SqlQuery<AppSettings>("SELECT ActiveWebUpload FROM AppSetting ").FirstOrDefault();
        //        }
        //        bRet = settings.ActiveWebUpload;
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return bRet;
        //}

        private void GetEmailAddress()
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();

                string dir4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir4 = dir4 + "\\JobTracker";

                CheckMail.Load(dir4 + "\\CheckFile.xml");

                //CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");


                //'*******Change Due invoice Mail setting*****
                XmlNode MailSettingInvoice = CheckMail.SelectSingleNode("/EmailReminder/Email");
                this.txtEmailaddress.Text = MailSettingInvoice.ChildNodes.Item(0).InnerText.Trim();
                this.txtEmailpassword.Text = MailSettingInvoice.ChildNodes.Item(1).InnerText.Trim();
                this.txtMailSeverInvoice.Text = MailSettingInvoice.ChildNodes.Item(2).InnerText.Trim();
                if (Convert.ToBoolean(Convert.ToInt32(MailSettingInvoice.ChildNodes.Item(3).InnerText.Trim())) == true)
                {
                    chkSSLInvoice.CheckState = CheckState.Checked;
                }
                else
                {
                    chkSSLInvoice.CheckState = CheckState.Unchecked;
                }
                //'*******Change Pending Item Mail Setting
                XmlNode MailSettingItem = CheckMail.SelectSingleNode("/EmailReminder/PNDEmail");
                this.txtEmailAddressItem.Text = MailSettingItem.ChildNodes.Item(0).InnerText.Trim();
                this.txtPasswordItem.Text = MailSettingItem.ChildNodes.Item(1).InnerText.Trim();
                this.txtMailServerNameItem.Text = MailSettingItem.ChildNodes.Item(2).InnerText.Trim();
                if (Convert.ToBoolean(Convert.ToInt32(MailSettingInvoice.ChildNodes.Item(3).InnerText.Trim())) == true)
                {
                    ChkSSLItem.CheckState = CheckState.Checked;
                }
                else
                {
                    ChkSSLItem.CheckState = CheckState.Unchecked;
                }
            }
            catch (IOException ex1)
            {
                KryptonMessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                KryptonMessageBox.Show(ex2.Message + " Please check the access right of it.");
            }
        }

        public void FillComboServerName()
        {
            DataTable ServerDt = BackUpDatabase.NameOfSqlServer();
        }

        public void FillCmbDatabase()
        {
            try
            {
                List<string> dbList = new List<string>();
                //using (EFDbContext db = new EFDbContext())
                //{
                //    dbList = db.Database.SqlQuery<string>("SELECT name FROM SYS.databases WHERE name NOT IN ('master','model','msdb','tempdb')").ToList();
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        dbList = db.Database.SqlQuery<string>("SELECT name FROM SYS.databases WHERE name NOT IN ('master','model','msdb','tempdb')").ToList();
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        dbList = db.Database.SqlQuery<string>("SELECT name FROM SYS.databases WHERE name NOT IN ('master','model','msdb','tempdb')").ToList();
                    }

                }

                if (dbList.Count > 0)
                {
                    cmbDatabaseName.DataSource = dbList;
                    cmbDatabaseName.DisplayMember = "name"; //DataBaseDT.Columns[0].ToString();
                }
                else
                {
                    KryptonMessageBox.Show("Database empty", "Backup Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Backup Database", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void ChkSchedule_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}