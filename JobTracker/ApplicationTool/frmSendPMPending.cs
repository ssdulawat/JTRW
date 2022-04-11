using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.Application_Tool
{
    public partial class frmSendPMPending : Form
    {
        public frmSendPMPending()
        {
            InitializeComponent();
        }
        #region Declaration
        private Int64 JoblistID;
        private string SenderEmailAddress;
        private string SenderEmailPassword;
        //Dim AgingReport As String
        private static frmSendPMPending _Instance;
        private bool ProgreStats;
        #endregion

        #region Events
        private void frmTrafficEmail_Activated(object sender, System.EventArgs e)
        {
            //GetSenderEmailaddress();
            JoblistID = Program.GetJobID;
            //ailbuilder()

        }
        private void frmTrafficEmail_Load(System.Object sender, System.EventArgs e)
        {
            //GetSenderEmailaddress();
            JoblistID = Program.GetJobID;
            FillJoblist();
            FilPMCombo();
            // Mailbuilder()
        }
        private void btnSendEmail_Click(System.Object sender, System.EventArgs e)
        {
            picboxEmailProgress.Visible = true;
            btnSendEmail.Visible = false;
            CrateLogfileHeader();
            backworkerEmailSender.RunWorkerAsync();
        }
        private void backworkerEmailSender_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Mailbuilder();
        }
        private void backworkerEmailSender_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            lblProcess.Text = e.ProgressPercentage.ToString() + "%";
        }
        private void backworkerEmailSender_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || ProgreStats == true)
            {
                KryptonMessageBox.Show("Please check email sending log file", "Invoice Due Reminder email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                picboxEmailProgress.Visible = false;
                btnSendEmail.Visible = true;



                string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir1 = dir1 + "\\JobTracker";

                Process.Start(dir1 + "\\EmailLogFile.txt");

                //Process.Start(Application.StartupPath + "\\EmailLogFile.txt");



                //Else
                //    KryptonMessageBox.Show("Email sending successfull", "Invoice Due Reminder email", MessageBoxButtons.OK, MessageBoxIcon.Information)
                //    picboxEmailProgress.Visible = False
                //    btnSendEmail.Visible = True
                //    Process.Start(Application.StartupPath & "\EmailLogFile.txt")
            }
        }
        private void chkAll_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                foreach (DataGridViewRow Row in grdJobList.Rows)
                {
                    grdJobList.Rows[Row.Index].Cells["grdChk"].Value = CheckState.Checked;
                }
            }
            else
            {
                foreach (DataGridViewRow Row in grdJobList.Rows)
                {
                    grdJobList.Rows[Row.Index].Cells["grdChk"].Value = CheckState.Unchecked;
                }
            }
        }
        private void txtJobnumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            FillJoblist();
        }
        private void cmbPM_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            FillJoblist();
        }
        private void grdCompanyList_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                if (Program.CheckBoxState( grdJobList.Rows[e.RowIndex].Cells["grdChk"].Value))
                {
                    grdJobList.Rows[e.RowIndex].Cells["grdChk"].Value = CheckState.Unchecked;
                }
                else
                {
                    grdJobList.Rows[e.RowIndex].Cells["grdChk"].Value = CheckState.Checked;
                }
            }
            FillTrackPending();
        }
        #endregion

        #region Methods
        private void FilPMCombo()
        {
            DataTable cmbDt = new DataTable();
            //cmbDt = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");


            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                cmbDt = StMethod.GetListDTNew<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
            }
            else
            {
                cmbDt = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
            }

            for (int I = 0; I < cmbDt.Rows.Count; I++)
            {
                cmbPM.Items.Add(cmbDt.Rows[I]["cTrack"].ToString());
            }



        }
        public void Mailbuilder()
        {
            //EmailUtils.GetSenderEmailaddress();
            EmailUtils.GetSenderEmailaddress2();
            for (Int32 i = 0; i < grdJobList.Rows.Count; i++)
            {
                if (Program.CheckBoxState(grdJobList.Rows[i].Cells["grdChk"].Value))
                {
                    string txtEmailbody = null;
                    string txtEmailSubject = null;
                    string ToEmailAddress = null;

                    try
                    {
                        DataTable DT = new DataTable();
                        //Dim EmailID As Int16
                        DataTable EmailDT = new DataTable();
                        
                        ToEmailAddress = grdJobList.Rows[i].Cells["EmailAddress"].Value.ToString();


                        txtEmailSubject = "Pending PM Track Sub Info";
                        //SELECT     JobTrackingID, JobListID,TaskHandler, TrackName, TrackSubName,Comments,Status,Submitted,  Obtained, Expires,   BillState,   FinalAction, AddDate, TrackSubID FROM         VW_PandingList


                        txtEmailbody = "Job Number :-<b> <mark> " + grdJobList.Rows[i].Cells["JobNumber"].Value.ToString() + "</mark></b>        PM :- <b><mark>" + grdJobList.Rows[i].Cells["Handler"].Value.ToString() + "</mark></b></br> <table border=1><tr><th>TM</th><th>Track</th><th>Track Sub</th><th>Comments</th><th>Status</th><th>Submitted</th><th>Obtained</th><th>Expires</th><th>Bill State</th><th>Final Action</th><th>AddDate</th></tr>";



                        foreach (DataGridViewRow GrdRow in grdPendingTrackSub.Rows)
                        {
                            // txtEmailbody = txtEmailbody + "<tr><td>" + GrdRow.Cells["TaskHandler"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["TrackName"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["TrackSubName"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["Comments"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["Status"].Value.ToString() + "</td>" + "<td>" + string.Format("MM/dd/yyyy", GrdRow.Cells["Submitted"].Value).ToString() + "</td>" + "<td>" +string.Format("MM/dd/yyyy", GrdRow.Cells["Obtained"].Value).ToString() + "</td>" + "<td>" + string.Format("MM/dd/yyyy", GrdRow.Cells["Expires"].Value).ToString() + "</td>" + "<td>" + GrdRow.Cells["BillState"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["FinalAction"].Value.ToString() + "</td>" + "<td>" + string.Format("MM/dd/yyyy", GrdRow.Cells["AddDate"].Value).ToString() + "</td></tr>";

                            txtEmailbody = txtEmailbody + "<tr><td>" + GrdRow.Cells["TaskHandler"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["TrackName"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["TrackSubName"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["Comments"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["Status"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["Submitted"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["Obtained"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["Expires"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["BillState"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["FinalAction"].Value.ToString() + "</td>" + "<td>" + GrdRow.Cells["AddDate"].Value.ToString() + "</td></tr>";

                        }
                        txtEmailbody = txtEmailbody + "</table>";
                        if (!string.IsNullOrEmpty(ToEmailAddress))
                        {
                            if (!string.IsNullOrEmpty(txtEmailSubject))
                            {
                                if (!string.IsNullOrEmpty(txtEmailbody))
                                {
                                    string s1, s2, s3;
                                    s1 = ToEmailAddress;
                                    s2 = txtEmailbody;
                                    s3 = txtEmailSubject;

                                    if (EmailUtils.MailSender(ToEmailAddress, txtEmailbody, txtEmailSubject) == false)
                                    {
                                        EmailLogFile(false, "SMTP error or Connecting time out error", grdJobList.Rows[i].Cells["JobNumber"].Value.ToString());
                                    }
                                    else
                                    {
                                        EmailLogFile(true, "", grdJobList.Rows[i].Cells["JobNumber"].Value.ToString());
                                    }
                                }
                                else
                                {
                                    EmailLogFile(false, "Due to email body", grdJobList.Rows[i].Cells["JobNumber"].Value.ToString());
                                }
                            }
                            else
                            {
                                EmailLogFile(false, "Due to email subject", grdJobList.Rows[i].Cells["JobNumber"].Value.ToString());
                            }
                        }
                        else
                        {
                            EmailLogFile(false, "Due to recipient address", grdJobList.Rows[i].Cells["JobNumber"].Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    //backworkerEmailSender.ReportProgress((i / grdCompanyList.Rows.Count - 1) * 100)
                }
            }
            ProgreStats = true;
        }
        //private void GetSenderEmailaddress()
        //{
        //    try
        //    {
        //        System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();
        //        CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");
        //        System.Xml.XmlNode reminder = CheckMail.SelectSingleNode("/EmailReminder/PNDEmail");
        //        SenderEmailAddress = reminder.ChildNodes.Item(0).InnerText.Trim();
        //        SenderEmailPassword = reminder.ChildNodes.Item(1).InnerText.Trim();
        //        //CheckMail.Save(Application.StartupPath & "\CheckFile.xml")
        //    }
        //    catch (IOException ex1)
        //    {
        //        KryptonMessageBox.Show(ex1.Message + " Please check the access right of it.", "Emila Information");
        //    }
        //    catch (Exception ex2)
        //    {
        //        KryptonMessageBox.Show(ex2.Message + " Please check the access right of it.", "Email Information");
        //    }
        //}
        //public bool MailSender(string EmailTo, string EmailBody, string EmailSubject)
        //{
        //    try
        //    {
        //        System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
        //        SmtpClient GmailSmptp = new SmtpClient();
        //        GmailSmptp.Host = "mail.valjato.com";
        //        //GmailSmptp.Host = "mail.saffron.arvixe.com"
        //        GmailSmptp.EnableSsl = false;
        //        //GmailSmptp.Port = 995
        //        GmailSmptp.Port = 465;
        //        //'GmailSmptp.Port = 993
        //        GmailSmptp.Port = 26;
        //        GmailSmptp.Credentials = new System.Net.NetworkCredential(SenderEmailAddress, SenderEmailPassword);
        //        email.To.Add(EmailTo);
        //        email.From = new System.Net.Mail.MailAddress(SenderEmailAddress);
        //        email.Subject = EmailSubject;
        //        email.Bcc.Add(SenderEmailAddress);
        //        email.IsBodyHtml = true;
        //        email.Body = EmailBody;
        //        GmailSmptp.Send(email);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        KryptonMessageBox.Show("Sending Fail :-" + ex.Message, "Email Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return false;
        //    }
        //}
        private void FillJoblist()
        {
            try
            {
                string Query = "SELECT JobListID, JobNumber, Handler, dbo.fun_PMInfoEmail(Handler) AS EmailAddress FROM  JobList WHERE (IsDelete = 0 OR   IsDelete IS NULL) AND (JobListID IN(SELECT     JobListID   FROM          VW_PandingList))";

                if (!string.IsNullOrEmpty(txtJobnumber.Text.Trim()))
                {
                    Query = Query + " AND JobNumber like '%" + txtJobnumber.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(cmbPM.Text.Trim()))
                {
                    Query = Query + " AND Handler like '" + cmbPM.Text.Trim() + "%'";
                }

                Query = Query + " ORDER BY JobNumber";

                DataTable CompanyDt = new DataTable();
                
                
                //CompanyDt = StMethod.GetListDT<PMJobList>(Query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    CompanyDt = StMethod.GetListDTNew<PMJobList>(Query);
                }
                else
                {
                    CompanyDt = StMethod.GetListDT<PMJobList>(Query);
                }



                // If CompanyDt.Rows.Count > 0 Then
                grdJobList.DataSource = CompanyDt;
                grdJobList.Columns["JobListID"].Visible = false;
                grdJobList.Columns["JobNumber"].HeaderText = "Job#";
                grdJobList.Columns["JobNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdJobList.Columns["Handler"].HeaderText = "PM";

                //grdJobList.Rows[10].Cells["EmailAddress"].Value = "devendra.sarang.8@gmail.com";

                if (CompanyDt.Rows.Count > 0)
                {
                    grdJobList.Rows[grdJobList.Rows.Count - 1].Selected = true;
                    grdJobList.CurrentCell = grdJobList.Rows[grdJobList.Rows.Count - 1].Cells["JobNumber"];
                    lblTotalCompany.Text = (grdJobList.Rows.Count - 1).ToString();


                    // End If
                    FillTrackPending();
                }
                else
                {
                    for (Int32 i = grdPendingTrackSub.Rows.Count - 1; i >= 0; i--)
                    {
                        grdPendingTrackSub.Rows.RemoveAt(i);
                    }
                }

                

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FillTrackPending()
        {
            try
            {
                string Query = "SELECT JobTrackingID, JobListID,TaskHandler, TrackName, TrackSubName,Comments,Status,Submitted,  Obtained, Expires,   BillState,   FinalAction, AddDate, TrackSubID FROM VW_PandingList  WHERE  JobListID=" + grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobListID"].Value.ToString();

                DataTable DueInvoiceDt = new DataTable();

                //DueInvoiceDt = StMethod.GetListDT<JT_JobLIst>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    DueInvoiceDt = StMethod.GetListDTNew<JT_JobLIst>(Query);
                }
                else
                {
                    DueInvoiceDt = StMethod.GetListDT<JT_JobLIst>(Query);
                }

                if (DueInvoiceDt.Rows.Count > 0)
                {
                    grdPendingTrackSub.DataSource = DueInvoiceDt;
                    grdPendingTrackSub.Columns["JobTrackingID"].Visible = false;
                    grdPendingTrackSub.Columns["JobListID"].Visible = false;
                    grdPendingTrackSub.Columns["TrackSubID"].Visible = false;
                    grdPendingTrackSub.Columns["TrackName"].HeaderText = "Track";
                    grdPendingTrackSub.Columns["TrackSubName"].HeaderText = "Track Sub";
                    //.Columns["DueInvoiceNo").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    grdPendingTrackSub.Columns["TaskHandler"].HeaderText = "Task Handler";
                    grdPendingTrackSub.Columns["BillState"].HeaderText = "Bil State";
                    grdPendingTrackSub.Columns["FinalAction"].HeaderText = "Final Action";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void EmailLogFile(bool status, string FaildCause, string JobNumber)
        {
            try
            {


                string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir1 = dir1 + "\\JobTracker";

                
                string LogFilePath = dir1 + "\\EmailLogFile.txt";
                //string LogFilePath = Application.StartupPath + "\\EmailLogFile.txt";
                FileStream CreateLogFile = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write);
                StreamWriter Writer = new StreamWriter(CreateLogFile);
                Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Writer.WriteLine(" Job Number :-" + JobNumber);
                Writer.WriteLine(" Status       :-" + status);
                Writer.WriteLine(" Failed Case  :-" + FaildCause);
                Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Writer.Flush();
                Writer.Close();
                CreateLogFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void CrateLogfileHeader()
        {
            try
            {
                string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir1 = dir1 + "\\JobTracker";



                string LogFilePath = dir1 + "\\EmailLogFile.txt";
                //string LogFilePath = Application.StartupPath + "\\EmailLogFile.txt";

                FileInfo ExitFile = new FileInfo(LogFilePath);
                if (ExitFile.Exists == true)
                {
                    ExitFile.Delete();
                }
                FileStream CreateLogFile = new FileStream(LogFilePath, FileMode.Create, FileAccess.Write);
                StreamWriter Writer = new StreamWriter(CreateLogFile);
                Writer.WriteLine("Job Tracking System (JT Version:-" + cProgramInfo.sApplicationVersion + ")");
                Writer.WriteLine("Email log file create at:-" + DateTime.Now.ToString());
                Writer.WriteLine("The Emaile Log file path :- " + LogFilePath);
                Writer.WriteLine("****************************************************************************************************************");
                //.WriteLine("  Company Name" + vbTab + vbTab + vbTab + vbTab + vbTab + vbTab + vbTab + "Status" + vbTab + vbTab + "FailedCase")
                //.WriteLine("----------------------------------------------------------------------------------------------------------------")
                Writer.WriteLine("");
                Writer.Flush();
                Writer.Close();
                CreateLogFile.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void grdPendingTrackSub_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //MessageBox.Show("Col = " + e.ColumnIndex + " Value is = > " + e.Value.ToString());

                if (e.ColumnIndex == 7)
                {
                    ////e.Value = "MM-dd-yyyy";
                    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //e.FormattingApplied = true;

                    //e.Value = "MM-dd-yyyy";

                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

                    if ((value != null))
                    {
                        e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                        e.FormattingApplied = true;

                    }
                    else
                    {
                        e.Value = e.CellStyle.NullValue;
                        e.FormattingApplied = true;
                    }

                }

                if (e.ColumnIndex == 8)
                {
                    ////e.Value = "MM-dd-yyyy";
                    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //e.FormattingApplied = true;

                    //e.Value = "MM-dd-yyyy";

                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

                    if ((value != null))
                    {
                        e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                        e.FormattingApplied = true;

                    }
                    else
                    {
                        e.Value = e.CellStyle.NullValue;
                        e.FormattingApplied = true;
                    }

                }

                if (e.ColumnIndex == 9)
                {
                    ////e.Value = "MM-dd-yyyy";
                    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //e.FormattingApplied = true;

                    //e.Value = "MM-dd-yyyy";

                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

                    if ((value != null))
                    {
                        e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                        e.FormattingApplied = true;

                    }
                    else
                    {
                        e.Value = e.CellStyle.NullValue;
                        e.FormattingApplied = true;
                    }

                }

                if (e.ColumnIndex == 12)
                {
                    ////e.Value = "MM-dd-yyyy";
                    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //e.FormattingApplied = true;

                    //e.Value = "MM-dd-yyyy";

                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

                    if ((value != null))
                    {
                        e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                        e.FormattingApplied = true;

                    }
                    else
                    {
                        e.Value = e.CellStyle.NullValue;
                        e.FormattingApplied = true;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
    }

        private void grdPendingTrackSub_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Index = " + e.ColumnIndex + "Values ");
                
        }
    }
}
