using JobTracker.JobTrackingMDIForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
//using Common;
using Commen2;

namespace JobTracker.Login
{
    public partial class FrmJTLogin : Form
    {
        #region "Variables & Properties"
        UserLogin dAL = new UserLogin();
        public JobAndTrackingMDI MdiParentCall;
        public bool CallFromMdi;
        #endregion 

        #region "Events"
        public FrmJTLogin()
        {
            InitializeComponent();
            Program.LoadDefaultSettings();
        }

        private void BtnLoginJT_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtJTUserName.Text) || string.IsNullOrEmpty(txtJTPassword.Text))
                {
                    MessageBox.Show("Invalid UserName Or Password!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                //if (!string.IsNullOrEmpty(txtJTUserName.Text) || !string.IsNullOrEmpty(txtJTPassword.Text))
                //{
                string UserName = txtJTUserName.Text.Trim();
                string Password = txtJTPassword.Text.Trim();

                var UserDetail = new List<DataAccessLayer.Model.LoginAuthentication>();
                //UserDetail = dAL.GetUsers(UserName, Password);
                

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    UserDetail = dAL.GetUsers2(UserName, Password);

                }
                else
                {
                    UserDetail = dAL.GetUsers(UserName, Password);
                }



                //var UserDetail = new List<DataAccessLayer.Model.LoginAuthentication>();
                //UserDetail = dAL.GetUsers(UserName, Password);

                if (UserDetail.Count > 0)
                {
                    foreach (var item in UserDetail)
                    {
                        if (item.UserType == "A" && cbIsTestDb.Checked)
                            MessageBox.Show("Must have admin privileges!", "Message");
                        else
                        {

                            //If dt.Rows(0)(0).ToString() = "U" Then
                           
                            Properties.Settings.Default.timeSheetLoginName = item.UserName;

                            //Properties.Settings.Default.timeSheetLoginUserID = item.Id;
                            Properties.Settings.Default.timeSheetLoginUserID = Convert.ToInt32(item.Id);
                            
                            Properties.Settings.Default.timeSheetLoginUserType = "User";
                            Properties.Settings.Default.IsTestDatabase = cbIsTestDb.Checked;
                            Properties.Settings.Default.PretimeSheetLoginName = "Null";
                            Properties.Settings.Default.PretimeSheetLoginUserID = "Null";
                            Properties.Settings.Default.PretimeSheetLoginUserType = "Null";

                            this.ShowInTaskbar = false;
                            this.Hide();

                            txtJTPassword.Text = "";/* TODO ERROR: Skipped SkippedTokensTrivia */
                            txtJTUserName.Text = "";

                        }

                        //////JobAndTrackingMDI mdi = new JobAndTrackingMDI();
                        JobAndTrackingMDI mdi = Program.ofrmMain;
                        // 'Check if the login form open from mdi form
                        if (MdiParentCall != null)
                            mdi = MdiParentCall;
                        if (item.UserType == "A")
                        {
                                                        
                            //Properties.Settings.Default.timeSheetLoginUserID = item.Id;
                            Properties.Settings.Default.timeSheetLoginUserID = Convert.ToInt32(item.Id);

                            Properties.Settings.Default.timeSheetLoginUserType = "Admin";
                            cGlobal.bIsAdminLoggedIn = true;
                            this.ShowInTaskbar = false;
                            this.Hide();

                            mdi.LoginformObject = this;
                            mdi.lblLogin.Text = string.Empty;
                            mdi.lblLogin.Text = "Admin LogOut";


                            //foreach (Form frm in this.MdiChildren)
                            //{
                            //    if (frm.IsMdiContainer != true)
                            //    {
                            //        //If frm.Text = JobStatus.Instance.Text Then
                            //        if (frm is JobTracker.JobTrackingMDIForm)
                            //        {
                            //            if (Properties.Settings.Default.PretimeSheetLoginUserType == "Admin")
                            //            {

                            //                JobStatus.Instance.grvJobList.Columns["IsDisable"].Visible = true;
                            //            }
                            //            else
                            //            {
                            //                JobStatus.Instance.grvJobList.Columns["IsDisable"].Visible = false;
                            //            }
                            //        }
                            //    }
                            //}

                            //BackUpDataabaseToolStripMenuItem.Enabled = True
                            //PMInfoToolStripMenuItem.Enabled = True
                            //PMTMListItemToolStripMenuItem.Enabled = True

                            //mdi.InvoiceToolStripMenuItem.Enabled = true;
                            //mdi.AdminToolStripMenuItem.Enabled = true;
                            //mdi.BackUpDataabaseToolStripMenuItem.Enabled = true;
                            //mdi.PMInfoToolStripMenuItem.Enabled = true;
                            //mdi.PMTMListItemToolStripMenuItem.Enabled = true;
                            mdi.Show();
                            txtJTPassword.Text = "";
                            txtJTUserName.Text = "";
                        }
                        else
                        {
                            mdi.lblLogin.Text = "LogOut";
                            mdi.Show();
                        }
                        // If login form open from mdi 
                        if (CallFromMdi)
                            Close();
                    }
                }
                else
                    MessageBox.Show("Incorrect User name & Password", "Message");
            }

            //}

            catch (Exception ex)
            {
                cErrorLog.WriteLog("JTLogin", "BtnLoginJT_Click", ex.Message);
                MessageBox.Show("Get Compare Schedule Error" + " =>" + ex.Message.ToString());
            }
        }

        private void BtnLoginCancelJT_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JTLogin", "BtnLoginCancelJT_Click", ex.Message);
            }
        }

        private void FrmJTLogin_Load(object sender, EventArgs e)
        {
            try
            {
                //string status = "Null";  
                Process my_proc = Process.GetCurrentProcess();
                string my_name = my_proc.ProcessName;

                if ((Process.GetProcessesByName(my_name).Length > 1))
                {
                    this.Hide();
                    Application.Exit();
                }
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JTLogin", "FrmJTLogin_Load", ex.Message);
            }
        }

        private void cbIsTestDb_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (cbIsTestDb.Checked == true)
                    Properties.Settings.Default.IsTestDatabase = true;
                else
                    Properties.Settings.Default.IsTestDatabase = false;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("JTLogin", "cbIsTestDb_CheckedChanged", ex.Message);
            }
        }
        #endregion

        public double Add2(double num1, double num2)
        {
            return num1 + num2;
        }
    }
}