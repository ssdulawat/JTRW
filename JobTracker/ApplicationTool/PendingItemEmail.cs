using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JobTracker.Application_Tool
{
    public partial class PendingItemEmail : Form
    {
        #region Declaration
        private DataTable DT = new DataTable();
        //private DataAccessLayer DAL;
        private long JoblistID;
        private string SenderEmailAddress;
        private string SenderEmailPassword;
        private bool SSl;
        private string DomainServer;
        private string EmailBody;
        private static PendingItemEmail _Instance;
        //private JobAndTrackingMDI Program;
        private bool ProgreStats;
        #endregion
        
        public PendingItemEmail()
        {
            InitializeComponent();
        }

        #region Events
        private void frmTrafficEmail_Activated(object sender, System.EventArgs e)
        {
            //JoblistID = JobAndTrackingMDI.GetJobID
            JoblistID = Program.GetJobID;
            EmailJobpendingList();
        }

        private void frmTrafficEmail_Load(System.Object sender, System.EventArgs e)
        {
            DT.Columns.Add("FileName");
            // JoblistID = JobAndTrackingMDI.GetJobID
            JoblistID = Program.GetJobID;
            radiobtnname();
            EmailJobpendingList();
        }

        private void btnSendEmail_Click(System.Object sender, System.EventArgs e)
        {
            picboxEmailProgress.Visible = true;
            btnSendEmail.Visible = false;
            backworkerEmailSender.RunWorkerAsync();
        }        

        private void backworkerEmailSender_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            MailSender();
        }

        private void backworkerEmailSender_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || ProgreStats == false)
            {
                KryptonMessageBox.Show("Email sending fail", "Invoice Due Reminder email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                picboxEmailProgress.Visible = false;
                btnSendEmail.Visible = true;
            }
            else
            {
                KryptonMessageBox.Show("Email sending successfull", "Invoice Due Reminder email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                picboxEmailProgress.Visible = false;
                btnSendEmail.Visible = true;
            }
        }

        private void btnAgingReport_Click(System.Object sender, System.EventArgs e)
        {
            if (btnAgingReport.Text != "Close Report")
            {
                agingBrowser.Visible = true;
                agingBrowser.DocumentText = EmailBody;
                btnAgingReport.Text = "Close Report";
            }
            else
            {
                btnAgingReport.Text = "Show Pending Item";
                agingBrowser.Visible = false;
            }


        }

        private void rdbbtnMail1_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                CheckMail.Load(dir2 + "\\CheckFile.xml");

                //CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");


                //'*******Change Due invoice Mail setting*****
                XmlNode MailSettingInvoice = CheckMail.SelectSingleNode("/EmailReminder/Email");
                SenderEmailAddress = MailSettingInvoice.ChildNodes.Item(0).InnerText.Trim();
                SenderEmailPassword = MailSettingInvoice.ChildNodes.Item(1).InnerText.Trim();
                DomainServer = MailSettingInvoice.ChildNodes.Item(2).InnerText.Trim();
                if (bool.TryParse(MailSettingInvoice.ChildNodes.Item(3).InnerText.Trim(), out bool result) == true)
                {
                    SSl = true;
                }
                else
                {
                    SSl = false;
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
        private void rdbbtnMail2_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                CheckMail.Load(dir2 + "\\CheckFile.xml");

                //CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");


                //'*******Change pending Mail setting*****
                XmlNode MailSettingInvoice = CheckMail.SelectSingleNode("/EmailReminder/PNDEmail");
                SenderEmailAddress = MailSettingInvoice.ChildNodes.Item(0).InnerText.Trim();
                SenderEmailPassword = MailSettingInvoice.ChildNodes.Item(1).InnerText.Trim();
                DomainServer = MailSettingInvoice.ChildNodes.Item(2).InnerText.Trim();
                if (bool.TryParse(MailSettingInvoice.ChildNodes.Item(3).InnerText.Trim(), out bool result) == true)
                {
                    SSl = true;
                }
                else
                {
                    SSl = false;
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
        #endregion

        #region Methods
        private void radiobtnname()
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir2 = dir2 + "\\JobTracker";

                //string fileName = dir2 + "\\VESoftwareSetting.xml";

                CheckMail.Load(dir2 + "\\CheckFile.xml");

                //CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");

                XmlNode MailSettingInvoice = CheckMail.SelectSingleNode("/EmailReminder/Email");
                rdbbtnMail1.Text = MailSettingInvoice.ChildNodes.Item(0).InnerText.Trim();
                XmlNode MailSettingitem = CheckMail.SelectSingleNode("/EmailReminder/PNDEmail");
                rdbbtnMail2.Text = MailSettingitem.ChildNodes.Item(0).InnerText.Trim();
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
        public void EmailJobpendingList()
        {
            try
            {
                DataTable GetCompany = new DataTable();

                //GetCompany = StMethod.GetListDT<CompanyEmails> ("SELECT Company.CompanyName, JobList.Address, JobList.JobNumber, Contacts.EmailAddress FROM  JobList INNER JOIN Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN          Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE JobList.JobListID=" + JoblistID);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    GetCompany = StMethod.GetListDTNew<CompanyEmails>("SELECT Company.CompanyName, JobList.Address, JobList.JobNumber, Contacts.EmailAddress FROM  JobList INNER JOIN Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN          Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE JobList.JobListID=" + JoblistID);
                }
                else
                {
                    GetCompany = StMethod.GetListDT<CompanyEmails>("SELECT Company.CompanyName, JobList.Address, JobList.JobNumber, Contacts.EmailAddress FROM  JobList INNER JOIN Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN          Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE JobList.JobListID=" + JoblistID);
                }

                txtEmailTo.Text = GetCompany.Rows[0]["EmailAddress"].ToString();
                txtEmailSubject.Text = GetCompany.Rows[0]["CompanyName"].ToString() + ", " + GetCompany.Rows[0]["JobNumber"].ToString() + " : " + GetCompany.Rows[0]["Address"].ToString() + " : Automated Notice Letter :";
                txtEmailBody.Text = "Please be advised that the following outstanding matters are still pending.";
                EmailBody = "<br><table border=\"1\"></tr> <th>Track</th> <th>TrackSub</th> <th>Notes</th></tr>";
                
                
                DataTable PendingItem = new DataTable();

                //PendingItem = StMethod.GetListDT<JobComments>("SELECT Track, TrackSub, Comments FROM  JobTracking WHERE Track IN(SELECT TrackName FROM MasterTrackSet WHERE TrackSet='PreRequirements') AND Status='Pending' AND JoblistID=" + JoblistID);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    PendingItem = StMethod.GetListDTNew<JobComments>("SELECT Track, TrackSub, Comments FROM  JobTracking WHERE Track IN(SELECT TrackName FROM MasterTrackSet WHERE TrackSet='PreRequirements') AND Status='Pending' AND JoblistID=" + JoblistID);

                }
                else
                {
                    PendingItem = StMethod.GetListDT<JobComments>("SELECT Track, TrackSub, Comments FROM  JobTracking WHERE Track IN(SELECT TrackName FROM MasterTrackSet WHERE TrackSet='PreRequirements') AND Status='Pending' AND JoblistID=" + JoblistID);
                }

                foreach (DataRow r in PendingItem.Rows)
                {
                    EmailBody = EmailBody + "<tr> <td> " + r["Track"].ToString() + "</td> <td>" + r["TrackSub"].ToString() + "</td> <td> " + r["Comments"].ToString() + "</td></tr>";
                }
                EmailBody = EmailBody + "</table>";

            }
            catch (Exception ex)
            {

            }

        }
        public string FindBRstr(string str)
        {
            try
            {
                char Chr = "\r\n"[0];
                str = str.Replace("\r\n", "<br>");
                //Return str = "<p>" + str + "<p>"
                return str;
            }
            catch (Exception ex)
            {
                return txtEmailBody.Text;
            }
        }
        public void MailSender()
        {
            try
            {
                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                SmtpClient MailSmptp = new SmtpClient();
                MailSmptp.Host = DomainServer;
                MailSmptp.EnableSsl = SSl;
                MailSmptp.Port = 465;
                //'GmailSmptp.Port = 993
                MailSmptp.Port = 26;
                MailSmptp.UseDefaultCredentials = false;
                MailSmptp.Credentials = new System.Net.NetworkCredential(SenderEmailAddress, SenderEmailPassword);
                email.To.Add(txtEmailTo.Text.Trim());
                email.From = new System.Net.Mail.MailAddress(SenderEmailAddress);
                email.Subject = txtEmailSubject.Text.Trim();
                email.Bcc.Add(SenderEmailAddress);
                email.IsBodyHtml = true;
                //If chkAttachAging.Checked = True Or chkAttachAging.CheckState = CheckState.Checked Then
                email.Body = FindBRstr(txtEmailBody.Text.Trim()).ToString() + EmailBody;
                //Else
                //email.Body = txtEmailBody.Text.Trim
                //End If
                MailSmptp.Send(email);
                ProgreStats = true;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Sending Fail :-" + ex.Message, "Email Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgreStats = false;
            }
        }
        #endregion
    }
}