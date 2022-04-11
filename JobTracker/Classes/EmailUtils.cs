using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

using System.Net.Security;

namespace JobTracker.Classes
{
    public static class EmailUtils
    {
        private static string SenderEmailAddress;
        private static string SenderEmailPassword;

        public static void GetSenderEmailaddress()
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
                KryptonMessageBox.Show(ex1.Message + " Please check the access right of it.", "Email Information");
            }
            catch (Exception ex2)
            {
                KryptonMessageBox.Show(ex2.Message + " Please check the access right of it.", "Email Information");
            }
        }

        public static void GetSenderEmailaddress2()
        {
            try
            {
                System.Xml.XmlDocument CheckMail = new System.Xml.XmlDocument();

                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir2 = dir2 + "\\JobTracker";
                CheckMail.Load(dir2 + "\\VESoftwareSetting.xml");


                //CheckMail.Load(Application.StartupPath + "\\CheckFile.xml");


                System.Xml.XmlNode reminder = CheckMail.SelectSingleNode("/EmailReminder/PNDEmail");
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

        //public static bool MailSender(string EmailTo, string EmailBody, string EmailSubject)
        //{
        //    try
        //    {
        //        GetSenderEmailaddress();

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
        public static bool MailSender(string EmailTo, string EmailBody, string EmailSubject, List<string> attachments = null)
        {
            try
            {
                if (string.IsNullOrEmpty(SenderEmailAddress) || string.IsNullOrEmpty(SenderEmailPassword))
                    GetSenderEmailaddress();

                //MessageBox.Show(SenderEmailAddress.ToString());
                
                var email = new MailMessage();
                var GmailSmptp = new SmtpClient();

                GmailSmptp.Host = "mail.valjato.com";

                //GmailSmptp.Host = "smtp.gmail.com";
                // GmailSmptp.Host = "mail.saffron.arvixe.com"


                GmailSmptp.UseDefaultCredentials = false;

                GmailSmptp.EnableSsl = false  ;

                GmailSmptp.Port = 465;
                GmailSmptp.Port = 26;

                //GmailSmptp.Port = 995;
                //GmailSmptp.Port = 993;

                GmailSmptp.Credentials = new NetworkCredential(SenderEmailAddress,SenderEmailPassword);

                email.To.Add(EmailTo);

                email.From = new MailAddress(SenderEmailAddress);
                email.Subject = EmailSubject;
                email.Bcc.Add(SenderEmailAddress);
                email.IsBodyHtml = true;
                // email.Body = EmailBody                
                

                using (MailMessage email2 = new MailMessage())
                {
                    // specify your email
                    email2.From = new MailAddress(SenderEmailAddress);
                    email2.Subject = EmailSubject;
                    email2.Bcc.Add(SenderEmailAddress);
                    email2.IsBodyHtml = true;
                    email2.Body = EmailBody;

                    email2.To.Add(EmailTo);



                    //string p = @"D:\Development\2020\Khemraj\Time Estimate.pdf";

                    //System.Net.Mail.Attachment att;
                    //att = new System.Net.Mail.Attachment(p);

                    //email2.Attachments.Add(att);


                    if (attachments != null && attachments.Count > 0)
                    {
                        foreach (string item in attachments)
                        {
                            var AttachFile = new Attachment(item);
                            email.Attachments.Add(AttachFile);
                        }
                    }




                    using (SmtpClient smtpClient = new SmtpClient("mail.valjato.com",26))
                    {

                        smtpClient.Host = "mail.valjato.com";
                        smtpClient.Port = 26;
                        smtpClient.EnableSsl = false ;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Timeout = 10000;
                        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network ;

                        smtpClient.Credentials = new NetworkCredential(SenderEmailAddress,SenderEmailPassword );

                        smtpClient.Send(email2);

                    }
                }

                //MailMessage email = new MailMessage();
                //SmtpClient GmailSmptp = new SmtpClient();
                //GmailSmptp.Host = "mail.valjato.com";
                ////GmailSmptp.Host = "mail.saffron.arvixe.com"
                //GmailSmptp.EnableSsl = false;
                ////GmailSmptp.Port = 995
                //GmailSmptp.Port = 465;
                ////'GmailSmptp.Port = 993
                //GmailSmptp.Port = 26;
                //GmailSmptp.Credentials = new System.Net.NetworkCredential(SenderEmailAddress, SenderEmailPassword);
                //email.To.Add(EmailTo);
                //email.From = new System.Net.Mail.MailAddress(SenderEmailAddress);
                //email.Subject = EmailSubject;
                //email.Bcc.Add(SenderEmailAddress);
                //email.IsBodyHtml = true;
                //email.Body = EmailBody;
                //GmailSmptp.Send(email);
                //return true;


                // GmailSmptp.Send(email);

                return true;
            }
            catch (Exception ex)
            {
               KryptonMessageBox.Show("Sending Fail :-" + ex.Message, "Email Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
