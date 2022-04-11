using Common;
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

namespace JobTracker.JobTrackingForm
{
    public partial class frmTrafficEmail : Form
    {
        #region Declaration
        private DataTable DT = new DataTable();
        //private DataAccessLayer DAL;
        private long JoblistID;
        private string SenderEmailAddress;
        private string SenderEmailPassword;
        private string AgingReport;
        ////private JobAndTrackingMDI mdio; //change by giriraj
        //private static frmTrafficEmail _Instance;
        private bool ProgreStats;
        #endregion
        public frmTrafficEmail()
        {
            InitializeComponent();
        }

        #region Events
        private void btnadd_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                DT.Rows.Clear();
                DirectoryInfo DirInfo = new DirectoryInfo("N:\\transfer\\PDF invoice");
                FileInfo[] AgingFile = DirInfo.GetFiles();

                DataTable FileNameDT = new DataTable();

                var data=StMethod.GetList<string>("select distinct DueInvoiceNo FROM  AgingInvoice WHERE CompanyID in (select CompanyID from joblist WHERE JoblistID=" + JoblistID + ")");
                FileNameDT = Program.ToDataTable(data);
                if (FileNameDT.Rows.Count > 0)
                {
                    string FileNotFound = null;
                    foreach (DataRow row in FileNameDT.Rows)
                    {
                        bool FileFound = false;
                        foreach (FileInfo FA in AgingFile)
                        {
                            //If FA.Name.Contains(ImportExcelInvoiceDue.GetJobNumber(row.Item("JobNumber").ToString())) = True Then
                            if (FA.Name.Contains(row["DueInvoiceNo"].ToString()) == true)
                            {
                                DataRow Dr = DT.NewRow();
                                Dr["FileName"] = FA.FullName;
                                DT.Rows.Add(Dr);
                                FileFound = true;
                                break;
                            }
                            else
                            {
                                FileFound = false;
                            }
                        }
                        if (FileFound == false)
                        {
                            FileNotFound = FileNotFound + "\r\n" + row["DueInvoiceNo"].ToString();
                            KryptonMessageBox.Show("Thise file list are not in directory=" + FileNotFound, "Email Due Invoice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                    FillAttachGrid(DT);
                }
            }
            catch
            {
            }
        }

        private void frmTrafficEmail_Activated(object sender, System.EventArgs e)
        {
            try
            {
                GetSenderEmailaddress();
                JoblistID = Program.GetJobID;
                // JoblistID = JobAndTrackingMDI.GetJobID
                Mailbuilder();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "frmEmailTraffic", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmTrafficEmail_Load(System.Object sender, System.EventArgs e)
        {
            try
            {


                DT.Columns.Add("FileName");
                GetSenderEmailaddress();

                //JoblistID = JobAndTrackingMDI.GetJobID ''change by @g
                JoblistID = Program.GetJobID;
                Mailbuilder();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "frmEmailTraffic", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnSendEmail_Click(System.Object sender, System.EventArgs e)
        {
            picboxEmailProgress.Visible = true;
            btnSendEmail.Visible = false;
            backworkerEmailSender.RunWorkerAsync();
        }
        
        private void btnAgingReport_Click(System.Object sender, System.EventArgs e)
        {
            if (btnAgingReport.Text != "Close Report")
            {
                agingBrowser.Visible = true;
                agingBrowser.DocumentText = AgingReport;
                btnAgingReport.Text = "Close Report";
            }
            else
            {
                btnAgingReport.Text = "Show Aging Report";
                agingBrowser.Visible = false;

            }


        }

        private void DeleteToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            if (grdAttachedfile.SelectedRows.Count > 1)
            {
                foreach (DataGridViewRow Row in grdAttachedfile.SelectedRows)
                {
                    grdAttachedfile.Rows.RemoveAt(Row.Index);
                }
            }
            else if (grdAttachedfile.SelectedRows.Count > 0)
            {
                grdAttachedfile.Rows.RemoveAt(grdAttachedfile.CurrentRow.Index);
            }

        }

        private void ckbAdd_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (ckbAdd.Checked == true)
            {
                //FillAttachGrid(DT)
                btnadd_Click(sender, e);
            }
            else if (ckbAdd.Checked == false)
            {
                DT.Rows.Clear();
            }


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
        #endregion

        #region Methods
        public void FillAttachGrid(DataTable dt)
        {
            grdAttachedfile.DataSource = null;
            grdAttachedfile.DataSource = dt;
            grdAttachedfile.Columns["FileName"].HeaderText = "File Name";
            grdAttachedfile.Columns["FileName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //For Row As Int16 = 0 To grdAttachedfile.Rows.Count - 1
            //    If Row Mod 2 = 0 Then
            //        grdAttachedfile.Rows[Row).DefaultCellStyle.BackColor = Color.
            //    End If
            //Next
        }
        public void Mailbuilder()
        {
            try
            {
                DataTable DT = new DataTable();
                //Dim EmailID As Int16
                DataTable EmailDT = new DataTable();
                DT=StMethod.GetListDT<CompanyEmails> ("SELECT Company.CompanyName,Company.DueInvoiceNo,Joblist.Address,Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action,  Company.Age105Action, Company.Aging,Company.OpeningBalance,Company.DueDate,Company.CompanyID FROM  Company INNER JOIN         JobList ON Company.CompanyID = JobList.CompanyID WHERE JobList.JobListID=" + JoblistID);
                DataTable InvoiceAgingDT = new DataTable();
                InvoiceAgingDT = StMethod.GetListDT<AgingInvoiceData>("Select * from AgingInvoice  Where CompanyID=" + DT.Rows[0]["CompanyID"].ToString());
                //If DT.Rows[0).Item("Aging").ToString <> String.Empty Then
                if (InvoiceAgingDT.Rows.Count > 0)
                {
                    if (Convert.ToInt32(DT.Rows[0]["Aging"]) > 0)
                    {
                        int aging = Convert.ToInt32(DT.Rows[0]["Aging"].ToString());
                        long colId = Program.GetColorID;
                        EmailDT = StMethod.GetListDT <ColorEmailData>("SELECT ColorID, EmailSubject, EmailDescription FROM  ColorEmailDescription WHERE ColorID=" + Program.GetColorID);
                        try
                        {
                            txtEmailBody.Text = EmailDT.Rows[0]["EmailDescription"].ToString();
                            txtEmailSubject.Text = DT.Rows[0]["CompanyName"].ToString() + " : " + EmailDT.Rows[0]["EmailSubject"].ToString(); //+ " = Invoice Automated Notice Letter :"
                        }
                        catch (Exception ex)
                        {

                        }
                        DataTable DTJobAddress = new DataTable();
                        //DTJobAddress = DAL.Filldatatable("SELECT JobList.Address from JobList WHERE JobNumber='" & GetJobNumber(DT.Rows[0).Item("DueInvoiceNo").ToString).ToString & "' ")
                        AgingReport = "\r\n" + "<TABLE><tr><th>Invoice No </th><th>Invoice Date</th><th>Job Address</th><th>Aging</th><th>Balance</th><th>Summation<th></tr>";
                        //<tr><td>" & DT.Rows[0).Item("DueInvoiceNo").ToString & " </td><td>" & Format(DT.Rows[0).Item("DueDate"), "MM/dd/yyyy") & "</td><td>" & DTJobAddress.Rows[0).Item("Address").ToString & "</td><td>" & DT.Rows[0).Item("Aging").ToString & "</td><td>" & DT.Rows[0).Item("OpeningBalance").ToString & "</td></tr>"
                        DTJobAddress.Rows.Clear();
                        DataTable dtInvoice = new DataTable();
                        dtInvoice = StMethod.GetListDT<AgingDueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + DT.Rows[0]["CompanyID"].ToString() + "  ORDER BY Aging DESC ");
                        //AND DueInvoiceNo<>'" & DT.Rows[0).Item("DueInvoiceNo").ToString & "'
                        //If dtInvoice.Rows.Count > 0 Then
                        //    AgingReport = AgingReport + "<tr><th>Other Pending Invoice</th></tr>"
                        //End If
                        decimal SumMation = 0.0M;
                        for (int j = 0; j < dtInvoice.Rows.Count; j++)
                        {
                            DTJobAddress = StMethod.GetListDT<string>("SELECT JobList.Address from JobList WHERE JobNumber='" + GetJobNumber(dtInvoice.Rows[j]["DueInvoiceNo"].ToString()).ToString() + "' ");
                            SumMation = SumMation + Convert.ToDecimal(dtInvoice.Rows[j]["Balance"].ToString());
                            AgingReport = AgingReport + "<tr><td>" + dtInvoice.Rows[j]["DueInvoiceNo"].ToString() + " </td><td>" + GenericHelper.FormateDate((DateTime) dtInvoice.Rows[j]["DueDate"]) + "</td><td>" + DTJobAddress.Rows[0]["Address"].ToString() + "</td><td>" + dtInvoice.Rows[j]["Aging"].ToString() + "</td><td>" + dtInvoice.Rows[j]["Balance"].ToString() + "</td><td>" + SumMation + "</td></tr>";
                        }
                        AgingReport = AgingReport + "</TABLE>";
                        DT.Rows.Clear();
                        DT = StMethod.GetListDT<string>("SELECT Contacts.EmailAddress FROM  JobList INNER JOIN Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE JobList.JobListID=" + JoblistID);
                        txtEmailTo.Text = DT.Rows[0]["EmailAddress"].ToString();
                    }
                    else
                    {
                        DataTable DTJobAddress = new DataTable();
                        DataTable dtInvoice = new DataTable();
                        dtInvoice = StMethod.GetListDT<AgingDueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + DT.Rows[0]["CompanyID"].ToString() + "  ORDER BY Aging DESC ");
                        AgingReport = "\r\n" + "<TABLE><tr><th>Invoice No </th><th>Invoice Date</th><th>Job Address</th><th>Aging</th><th>Balance</th></tr>";
                        for (int j = 0; j < dtInvoice.Rows.Count; j++)
                        {
                            DTJobAddress = StMethod.GetListDT<string>("SELECT JobList.Address from JobList WHERE JobNumber='" + GetJobNumber(dtInvoice.Rows[j]["DueInvoiceNo"].ToString()).ToString() + "' ");
                            AgingReport = AgingReport + "<tr><td>" + dtInvoice.Rows[j]["DueInvoiceNo"].ToString() + " </td><td>" + GenericHelper.FormateDate((DateTime)dtInvoice.Rows[j]["DueDate"]) + "</td><td>" + DTJobAddress.Rows[0]["Address"].ToString() + "</td><td>" + dtInvoice.Rows[j]["Aging"].ToString() + "</td><td>" + dtInvoice.Rows[j]["Balance"].ToString() + "</td></tr>";
                            DTJobAddress.Rows.Clear();
                        }
                        AgingReport = AgingReport + "</TABLE>";
                        DT.Rows.Clear();
                        DT = StMethod.GetListDT<string>("SELECT Contacts.EmailAddress FROM  JobList INNER JOIN Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE JobList.JobListID=" + JoblistID);
                        txtEmailTo.Text = DT.Rows[0]["EmailAddress"].ToString();
                    }
                }
                else
                {
                    DT.Rows.Clear();
                    DT = StMethod.GetListDT<string>("SELECT Contacts.EmailAddress FROM  JobList INNER JOIN Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE JobList.JobListID=" + JoblistID);
                    if (DT.Rows.Count > 0)
                    {
                        txtEmailTo.Text = DT.Rows[0]["EmailAddress"].ToString();
                    }
                }
                if (Program.DueInvoiceEmailAddress != "")
                {
                    txtEmailTo.Text = Program.DueInvoiceEmailAddress;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "frmEmailTraffic & Mailbuilder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private string GetJobNumber(string Jobstr)
        {
            try
            {
                string[] str = Jobstr.Split('-');
                string Newstr = null;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str.Length == 1)
                    {
                        Newstr = str[i];
                    }
                    else
                    {
                        Newstr = str[i] + "-" + str[i + 1];
                    }
                    break;
                }
                return Newstr;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        private void GetSenderEmailaddress()
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();
                CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");
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
        public void MailSender()
        {
            try
            {
                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                SmtpClient GmailSmptp = new SmtpClient();
                GmailSmptp.Host = "mail.valjato.com";
                //GmailSmptp.Host = "mail.saffron.arvixe.com"
                GmailSmptp.EnableSsl = false;
                //GmailSmptp.Port = 995
                GmailSmptp.Port = 465;
                //'GmailSmptp.Port = 993
                GmailSmptp.Port = 26;
                GmailSmptp.Credentials = new System.Net.NetworkCredential(SenderEmailAddress, SenderEmailPassword);
                email.To.Add(txtEmailTo.Text.Trim());
                email.From = new System.Net.Mail.MailAddress(SenderEmailAddress);
                email.Subject = txtEmailSubject.Text.Trim();
                email.Bcc.Add(SenderEmailAddress);
                email.IsBodyHtml = true;
                if (chkAttachAging.Checked == true || chkAttachAging.CheckState == CheckState.Checked)
                {
                    email.Body = txtEmailBody.Text.Trim() + AgingReport;
                }
                else
                {
                    email.Body = txtEmailBody.Text.Trim();
                }
                for (Int16 i = 0; i < grdAttachedfile.Rows.Count; i++)
                {
                    Attachment AttachFile = new Attachment(grdAttachedfile.Rows[i].Cells["FileName"].Value.ToString());
                    email.Attachments.Add(AttachFile);
                }
                GmailSmptp.Send(email);
                ProgreStats = true;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Sending Fail :-" + ex.Message, "Email Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProgreStats = false;
            }
        }
        public void sendSaveMail()
        {
            try
            {
                System.Net.Mail.MailMessage email = new System.Net.Mail.MailMessage();
                SmtpClient GmailSmptp = new SmtpClient();
                GmailSmptp.Host = "mail.valjato.com";
                GmailSmptp.EnableSsl = false;
                GmailSmptp.Port = 25;
                GmailSmptp.Credentials = new System.Net.NetworkCredential(SenderEmailAddress, SenderEmailPassword);
                email.To.Add(txtEmailTo.Text.Trim());
                email.From = new System.Net.Mail.MailAddress(SenderEmailAddress);
                email.Subject = txtEmailSubject.Text.Trim();
                email.IsBodyHtml = true;
                if (chkAttachAging.Checked == true || chkAttachAging.CheckState == CheckState.Checked)
                {
                    email.Body = txtEmailBody.Text.Trim() + AgingReport;
                }
                else
                {
                    email.Body = txtEmailBody.Text.Trim();
                }
                GmailSmptp.Send(email);
                ProgreStats = true;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Sending Fail :-" + ex.Message, "Email Information");
                ProgreStats = false;
            }
        }
        #endregion
    }
}
