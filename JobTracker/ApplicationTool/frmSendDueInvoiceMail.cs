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
    public partial class frmSendDueInvoiceMail : Form
    {
        #region Declaration
        private Int64 JoblistID;
        //private string SenderEmailAddress;
        //private string SenderEmailPassword;
        private bool ProgreStats;
        #endregion

        public frmSendDueInvoiceMail()
        {
            InitializeComponent();
        }

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
            this.StartPosition = FormStartPosition.CenterParent;
            JoblistID = Program.GetJobID;
            FillCompany();
            // Mailbuilder()
        }
        private void btnSendEmail_Click(System.Object sender, System.EventArgs e)
        {
            picboxEmailProgress.Visible = true;
            btnSendEmail.Visible = false;
            CrateLogfileHeader();
            backworkerEmailSender.RunWorkerAsync();
        }
        private void grdCompanyList_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                if (Program.CheckBoxState(grdCompanyList.Rows[e.RowIndex].Cells["grdChk"].Value))
                {
                    grdCompanyList.Rows[e.RowIndex].Cells["grdChk"].Value = CheckState.Unchecked;
                    
                }
                else
                {
                    grdCompanyList.Rows[e.RowIndex].Cells["grdChk"].Value = CheckState.Checked;
                }
            }
            FillDueInvoice();
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

                //CheckMail.Load(dir4 + "\\CheckFile.xml");
                //string fileName = dir1 + "\\VESoftwareSetting.xml";

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
                foreach (DataGridViewRow Row in grdCompanyList.Rows)
                {
                    grdCompanyList.Rows[Row.Index].Cells["grdChk"].Value = CheckState.Checked;
                }
            }
            else
            {
                foreach (DataGridViewRow Row in grdCompanyList.Rows)
                {
                    grdCompanyList.Rows[Row.Index].Cells["grdChk"].Value = CheckState.Unchecked;
                }
            }
        }
        #endregion

        #region Methods
        public void Mailbuilder()
        {
            EmailUtils.GetSenderEmailaddress();
            for (Int32 i = 0; i < grdCompanyList.Rows.Count; i++)
            {
                if (Program.CheckBoxState(grdCompanyList.Rows[i].Cells["grdChk"].Value))
                {
                    string txtEmailbody = null;
                    string txtEmailSubject = null;
                    string ToEmailAddress = null;
                    string AgingReport = null;
                    try
                    {
                        DataTable DT = new DataTable();
                        //Dim EmailID As Int16
                        DataTable EmailDT = new DataTable();

                        //DT =StMethod.GetListDT<AgingInvoiceData>("SELECT CompanyName, DueInvoiceNo, Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging, OpeningBalance, DueDate, CompanyID FROM    Company WHERE Company.CompanyID=" + grdCompanyList.Rows[i].Cells["CompanyID"].Value.ToString());


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            DT = StMethod.GetListDTNew<AgingInvoiceData>("SELECT CompanyName, DueInvoiceNo, Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging, OpeningBalance, DueDate, CompanyID FROM    Company WHERE Company.CompanyID=" + grdCompanyList.Rows[i].Cells["CompanyID"].Value.ToString());
                        }
                        else
                        {
                            DT = StMethod.GetListDT<AgingInvoiceData>("SELECT CompanyName, DueInvoiceNo, Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging, OpeningBalance, DueDate, CompanyID FROM    Company WHERE Company.CompanyID=" + grdCompanyList.Rows[i].Cells["CompanyID"].Value.ToString());
                        }

                        DataTable InvoiceAgingDT = new DataTable();


                        //InvoiceAgingDT = StMethod.GetListDT<AgingInvoiceData>("Select * from AgingInvoice  Where CompanyID=" + DT.Rows[0]["CompanyID"].ToString() + "order by Aging desc");


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            InvoiceAgingDT = StMethod.GetListDTNew<AgingInvoiceData>("Select * from AgingInvoice  Where CompanyID=" + DT.Rows[0]["CompanyID"].ToString() + "order by Aging desc");

                        }
                        else
                        {
                            InvoiceAgingDT = StMethod.GetListDT<AgingInvoiceData>("Select * from AgingInvoice  Where CompanyID=" + DT.Rows[0]["CompanyID"].ToString() + "order by Aging desc");
                        }

                        if (InvoiceAgingDT.Rows.Count > 0)
                        {
                            if (Convert.ToInt32(DT.Rows[0]["Aging"]) >= 15)
                            {
                                int aging = Convert.ToInt32(DT.Rows[0]["Aging"].ToString());


                                //EmailDT = StMethod.GetListDT<ColorEmailData>("SELECT ColorID, EmailSubject, EmailDescription FROM  ColorEmailDescription WHERE ColorID=" + GetEmailTextID(aging, DT));

                                if (Properties.Settings.Default.IsTestDatabase == true)
                                {

                                    EmailDT = StMethod.GetListDTNew<ColorEmailData>("SELECT ColorID, EmailSubject, EmailDescription FROM  ColorEmailDescription WHERE ColorID=" + GetEmailTextID(aging, DT));
                                }
                                else
                                {
                                    EmailDT = StMethod.GetListDT<ColorEmailData>("SELECT ColorID, EmailSubject, EmailDescription FROM  ColorEmailDescription WHERE ColorID=" + GetEmailTextID(aging, DT));
                                }

                                try
                                {
                                    txtEmailbody = EmailDT.Rows[0]["EmailDescription"].ToString();
                                    txtEmailSubject = DT.Rows[0]["CompanyName"].ToString() + " : " + EmailDT.Rows[0]["EmailSubject"].ToString();

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString());
                                }
                                DataTable DTJobAddress = new DataTable();

                                //AgingReport = "\r\n" + "<TABLE><tr><th>Invoice No </th><th>Invoice Date</th><th>Job Address</th><th>Aging</th><th>Balance</th></tr>";


                                AgingReport = "\r\n" + "<TABLE border='1'><tr><th>Invoice No </th><th>Invoice Date</th><th>Job Address</th><th>Aging</th><th>Balance</th></tr>";

                                DTJobAddress.Rows.Clear();
                                
                                DataTable dtInvoice = new DataTable();
                                
                                //dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + DT.Rows[0]["CompanyID"].ToString() + "  ORDER BY Aging DESC ");

                                if (Properties.Settings.Default.IsTestDatabase == true)
                                {

                                    dtInvoice = StMethod.GetListDTNew<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + DT.Rows[0]["CompanyID"].ToString() + "  ORDER BY Aging DESC ");

                                }
                                else
                                {
                                    dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + DT.Rows[0]["CompanyID"].ToString() + "  ORDER BY Aging DESC ");

                                }


                                String TEMO = DT.Rows[0]["CompanyID"].ToString();

                                for (int j = 0; j < dtInvoice.Rows.Count; j++)
                                {
                                    
                                    //DTJobAddress = StMethod.GetListDT<dtoAddress>("SELECT JobList.Address from JobList WHERE JobNumber='" + GetJobNumber(dtInvoice.Rows[j]["DueInvoiceNo"].ToString()).ToString() + "' ");


                                    if (Properties.Settings.Default.IsTestDatabase == true)
                                    {

                                        DTJobAddress = StMethod.GetListDTNew<dtoAddress>("SELECT JobList.Address from JobList WHERE JobNumber='" + GetJobNumber(dtInvoice.Rows[j]["DueInvoiceNo"].ToString()).ToString() + "' ");
                                    }
                                    else
                                    {
                                        DTJobAddress = StMethod.GetListDT<dtoAddress>("SELECT JobList.Address from JobList WHERE JobNumber='" + GetJobNumber(dtInvoice.Rows[j]["DueInvoiceNo"].ToString()).ToString() + "' ");
                                    }



                                    //AgingReport = AgingReport + "<tr><td>" + dtInvoice.Rows[j]["DueInvoiceNo"].ToString() + " </td><td>" + string.Format ("MM/dd/yyyy",dtInvoice.Rows[j]["DueDate"]) + "</td><td>" + DTJobAddress.Rows[0]["Address"].ToString() + "</td><td>" + dtInvoice.Rows[j]["Aging"].ToString() + "</td><td>" + dtInvoice.Rows[j]["Balance"].ToString() + "</td></tr>";

                                    AgingReport = AgingReport + "<tr><td>" + dtInvoice.Rows[j]["DueInvoiceNo"].ToString() + " </td><td>" + 
                                        dtInvoice.Rows[j]["DueDate"].ToString() + "</td><td>" + DTJobAddress.Rows[0]["Address"].ToString() + 
                                        "</td><td>" + dtInvoice.Rows[j]["Aging"].ToString() + "</td><td>" + 
                                        dtInvoice.Rows[j]["Balance"].ToString() + "</td></tr>";

                                    DTJobAddress.Rows.Clear();
                                }
                                AgingReport = AgingReport + "</TABLE>";
                                DT.Rows.Clear();
                                
                                //DT = StMethod.GetListDT<InvContactEmail>("SELECT EmailAddress FROM  Contacts WHERE Accounting=1 AND CompanyID=" + grdCompanyList.Rows[i].Cells["CompanyID"].Value.ToString());

                                if (Properties.Settings.Default.IsTestDatabase == true)
                                {
                                    DT = StMethod.GetListDTNew<InvContactEmail>("SELECT EmailAddress FROM  Contacts WHERE Accounting=1 AND CompanyID=" + grdCompanyList.Rows[i].Cells["CompanyID"].Value.ToString());

                                }
                                else
                                {
                                    DT = StMethod.GetListDT<InvContactEmail>("SELECT EmailAddress FROM  Contacts WHERE Accounting=1 AND CompanyID=" + grdCompanyList.Rows[i].Cells["CompanyID"].Value.ToString());
                                }


                                try
                                {

                                    if (DT.Rows.Count > 0)
                                    {
                                        Int16 j = 0;
                                        foreach (DataRow row in DT.Rows)
                                        {
                                            if (j == 0)
                                            {
                                                ToEmailAddress = row["EmailAddress"].ToString();
                                                
                                            }
                                            else
                                            {
                                                ToEmailAddress = ToEmailAddress + "," + row["EmailAddress"].ToString();
                                            }
                                            j = (Int16)(j + 1);
                                        }
                                    }
                                CheckAgain:

                                    if (!string.IsNullOrEmpty(ToEmailAddress))
                                    { 
                                        if (ToEmailAddress.Trim()[ToEmailAddress.Trim().Length - 1].ToString() == ",")
                                        {
                                            ToEmailAddress = ToEmailAddress.Trim().Remove(ToEmailAddress.Trim().Length - 1);
                                        }
                                        if (ToEmailAddress.Trim().IndexOf(",") == 0)
                                        {
                                            ToEmailAddress = ToEmailAddress.Trim().Remove(0, 1);
                                        }
                                        //'''''**************
                                        if (ToEmailAddress.Trim()[ToEmailAddress.Trim().Length - 1].ToString() == "," || ToEmailAddress.Trim().IndexOf(",") == 0)
                                        {
                                            goto CheckAgain;
                                        }
                                  }

                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message.ToString());
                                }
                                if (!string.IsNullOrEmpty(ToEmailAddress))
                                {
                                    if (!string.IsNullOrEmpty(txtEmailSubject))
                                    {
                                        if (!string.IsNullOrEmpty(txtEmailbody) && !string.IsNullOrEmpty(AgingReport))
                                        {
                                            if (EmailUtils.MailSender(ToEmailAddress, txtEmailbody + "\r\n" + AgingReport, txtEmailSubject) == false)
                                            {
                                                EmailLogFile(false, "SMTP error or time out error", grdCompanyList.Rows[i].Cells["CompanyName"].Value.ToString());
                                            }
                                            else
                                            {
                                                EmailLogFile(true, "", grdCompanyList.Rows[i].Cells["CompanyName"].Value.ToString());
                                            }
                                        }
                                        else
                                        {
                                            EmailLogFile(false, "Due to email body", grdCompanyList.Rows[i].Cells["CompanyName"].Value.ToString());
                                        }
                                    }
                                    else
                                    {
                                        EmailLogFile(false, "Due to email subject", grdCompanyList.Rows[i].Cells["CompanyName"].Value.ToString());
                                    }
                                }
                                else
                                {
                                    EmailLogFile(false, "Due to recipient address", grdCompanyList.Rows[i].Cells["CompanyName"].Value.ToString());
                                }
                            }
                            else
                            {

                                EmailLogFile(false, "Due invoice not have 15 day old", grdCompanyList.Rows[i].Cells["CompanyName"].Value.ToString());
                            }
                        }
                        else
                        {
                            EmailLogFile(false, "Due invoice not have 15 day old", grdCompanyList.Rows[i].Cells["CompanyName"].Value.ToString());
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    //backworkerEmailSender.ReportProgress((i / grdCompanyList.Rows.Count - 1) * 100)
                }
            }
            ProgreStats = true;
        }
        private Int32 GetEmailTextID(Int32 aging, DataTable ColorDT)
        {
            try
            {
                Int16 emailId = 0;
                if (aging >= 15)
                {
                    if (aging >= 15 && aging < 30)
                    {
                        emailId = Convert.ToInt16(ColorDT.Rows[0]["Age15Action"].ToString());
                    }
                    if (aging >= 30 && aging < 45)
                    {
                        emailId = Convert.ToInt16(ColorDT.Rows[0]["Age30Action"].ToString());
                    }
                    if (aging >= 45 && aging < 60)
                    {
                        emailId = Convert.ToInt16(ColorDT.Rows[0]["Age45Action"].ToString());
                    }
                    if (aging >= 60 && aging < 75)
                    {
                        emailId = Convert.ToInt16(ColorDT.Rows[0]["Age60Action"].ToString());
                    }
                    if (aging >= 75 && aging < 90)
                    {
                        emailId = Convert.ToInt16(ColorDT.Rows[0]["Age75Action"].ToString());
                    }
                    if (aging >= 90 && aging < 105)
                    {
                        emailId = Convert.ToInt16(ColorDT.Rows[0]["Age90Action"].ToString());
                    }
                    if (aging >= 105)
                    {
                        emailId = Convert.ToInt16(ColorDT.Rows[0]["Age105Action"].ToString());
                    }
                }
                return emailId;
            }
            catch (Exception ex)
            {

            }
            return 0;
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


        //private void GetSenderEmailaddress()
        //{
        //    try
        //    {
        //        System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();
        //        CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");
        //        System.Xml.XmlNode reminder = CheckMail.SelectSingleNode("/EmailReminder/Email");
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
        //        MailMessage email = new MailMessage();
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


        private void FillCompany()
        {
            try
            {
                string Query = "SELECT CompanyID,CompanyName FROM Company WHERE CompanyID IN (SELECT CompanyID FROM AgingInvoice) ORDER BY CompanyName";
                DataTable CompanyDt = new DataTable();
                
                
                //CompanyDt = StMethod.GetListDT<CompanyIDs>(Query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    CompanyDt = StMethod.GetListDTNew<CompanyIDs>(Query);
                }
                else
                {
                    CompanyDt = StMethod.GetListDT<CompanyIDs>(Query);
                }


                if (CompanyDt.Rows.Count > 0)
                {
                    grdCompanyList.DataSource = CompanyDt;
                    grdCompanyList.Columns["companyID"].Visible = false;
                    grdCompanyList.Columns["CompanyName"].HeaderText = "Company";
                    grdCompanyList.Columns["CompanyName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grdCompanyList.Rows[grdCompanyList.Rows.Count - 1].Selected = true;
                    grdCompanyList.CurrentCell = grdCompanyList.Rows[grdCompanyList.Rows.Count - 1].Cells["CompanyName"];
                    lblTotalCompany.Text = (grdCompanyList.Rows.Count - 1).ToString();
                }
                FillDueInvoice();
            }
            catch (Exception ex)
            {

            }
        }
        private void FillDueInvoice()
        {
            try
            {
                string Query = "SELECT InvoiceAgingID, DueInvoiceNo, DueDate, Aging FROM AgingInvoice WHERE CompanyID=" + grdCompanyList.Rows[grdCompanyList.CurrentRow.Index].Cells["companyID"].Value.ToString() + "ORDER BY Aging DESC";
                DataTable DueInvoiceDt = new DataTable();


                //DueInvoiceDt = StMethod.GetListDT<DueInvoiceAging>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    DueInvoiceDt = StMethod.GetListDTNew<DueInvoiceAging>(Query);
                }
                else
                {
                    DueInvoiceDt = StMethod.GetListDT<DueInvoiceAging>(Query);
                }


                if (DueInvoiceDt.Rows.Count > 0)
                {
                    grdDueinvoice.DataSource = DueInvoiceDt;
                    grdDueinvoice.Columns["InvoiceAgingID"].Visible = false;
                    grdDueinvoice.Columns["DueInvoiceNo"].HeaderText = "Invoice No";
                    grdDueinvoice.Columns["DueInvoiceNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grdDueinvoice.Columns["DueDate"].HeaderText = "Date";
                    grdDueinvoice.Columns["DueDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grdDueinvoice.Columns["Aging"].HeaderText = "Aging";
                    grdDueinvoice.Columns["Aging"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                    grdDueinvoice.Columns["InvoiceAgingID"].Visible = false;
                    grdDueinvoice.Columns["CompanyID"].Visible = false;
                    grdDueinvoice.Columns["Balance"].Visible = false;
                    grdDueinvoice.Columns["Aging"].DisplayIndex = 3;

                }
            }
            catch (Exception ex)
            {

            }
        }        
        private void EmailLogFile(bool status, string FaildCause, string CompanyName)
        {
            try
            {

                string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir1 = dir1 + "\\JobTracker";

                //CheckMail.Load(dir4 + "\\CheckFile.xml");
                //string fileName = dir1 + "\\VESoftwareSetting.xml";

                //Process.Start(dir1 + "\\EmailLogFile.txt");

                //Process.Start(Application.StartupPath + "\\EmailLogFile.txt");

                string LogFilePath = dir1 + "\\EmailLogFile.txt";
                //string LogFilePath = Application.StartupPath + "\\EmailLogFile.txt";

                FileStream CreateLogFile = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write);
                StreamWriter Writer = new StreamWriter(CreateLogFile);
                Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Writer.WriteLine(" Company Name :-" + CompanyName);
                Writer.WriteLine(" Status       :-" + status);
                Writer.WriteLine(" Failed Case  :-" + FaildCause);
                Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                Writer.Flush();
                Writer.Close();
                CreateLogFile.Close();
            }
            catch (Exception ex)
            {

            }
        }
        private void CrateLogfileHeader()
        {
            try
            {
                string dir1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir1 = dir1 + "\\JobTracker";

                //CheckMail.Load(dir4 + "\\CheckFile.xml");
                //string fileName = dir1 + "\\VESoftwareSetting.xml";

                //Process.Start(dir1 + "\\EmailLogFile.txt");

                //Process.Start(Application.StartupPath + "\\EmailLogFile.txt");

                string LogFilePath = dir1 + "\\EmailLogFile.txt";



                //string LogFilePath = Application.StartupPath + "\\EmailLogFile.txt";

                FileInfo ExitFile = new FileInfo(LogFilePath);
                if (ExitFile.Exists == true)
                {
                    ExitFile.Delete();
                }
                FileStream CreateLogFile = new FileStream(LogFilePath, FileMode.Create, FileAccess.Write);
                StreamWriter Writer = new StreamWriter(CreateLogFile);
                Writer.WriteLine("Job Tracking System (JT Version:-" + cProgramInfo.sApplicationVersion+ ")");
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

            }
        }

        #endregion

        private void grdDueinvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
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
    }
}