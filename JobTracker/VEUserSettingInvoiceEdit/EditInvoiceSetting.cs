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

namespace JobTracker.VEUserSettingInvoiceEdit
{
    public partial class EditInvoiceSetting : Form
    {
        public EditInvoiceSetting()
        {
            InitializeComponent();
        }

        #region Events
        private void btnSaveSetting_Click(System.Object sender, System.EventArgs e)
        {
            try
            {


                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir2 = dir2 + "\\JobTracker";
                //myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                string fileName = dir2 + "\\VESoftwareSetting.xml";

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

            try
            {
                XmlDocument myDoc = new XmlDocument();

                try
                {
                    string dir3 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir3 = dir3 + "\\JobTracker";
                    myDoc.Load(dir3 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("VESoftwareSetting.xml File not available in current folder", "EditInvoiceSetting : Error");
                }



                if (chkManagerApply.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["EditReportSetting"]["Apply"].InnerText = "Yes";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["EditReportSetting"]["Apply"].InnerText = "No";
                }

                if (chkConvertTimeSheet.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["EditReportSetting"]["ckbConvertAssocitedTime"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["EditReportSetting"]["ckbConvertAssocitedTime"].InnerText = "False";
                }


                myDoc["VESoftwareSetting"]["EditReportSetting"]["Combovalue"].InnerText = cmbConvertTimeSheet.SelectedItem.ToString();


                if (chkItem.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["EditReportSetting"]["ItemCheck"].InnerText = "True";
                }
                else
                {
                    myDoc["VESoftwareSetting"]["EditReportSetting"]["ItemCheck"].InnerText = "False";
                }


                if (chkExpenses.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["EditReportSetting"]["ExpensesCheck"].InnerText = "True";
                }
                else
                {

                    myDoc["VESoftwareSetting"]["EditReportSetting"]["ExpensesCheck"].InnerText = "False";
                }

                if (chkTime.Checked == true)
                {
                    myDoc["VESoftwareSetting"]["EditReportSetting"]["TimeCheck"].InnerText = "True";
                }
                else
                {

                    myDoc["VESoftwareSetting"]["EditReportSetting"]["TimeCheck"].InnerText = "False";
                }



                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir2 = dir2 + "\\JobTracker";
                
                myDoc.Save(dir2 + "\\VESoftwareSetting.xml");

                //myDoc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");

                MessageBox.Show("Successful change setting ", "Edit Invoice User Defined Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

            }


            // MessageBox.Show("Please! apply setting checked true and then you  save the  setting", "Edit Invoice User Defined Setting", MessageBoxButtons.OK, MessageBoxIcon.Information)


        }

        private void EditInvoiceSetting_Load(System.Object sender, System.EventArgs e)
        {
            ShowSetting();
        }

        #endregion

        #region Methods
        private void ShowSetting()
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
                    MessageBox.Show("VESoftwarSetting.xml File Not Available in Current Folder ", "EditInvoiceSetting");
                }

                if (myDoc["VESoftwareSetting"]["EditReportSetting"]["Apply"].InnerText == "Yes")
                {
                    chkManagerApply.Checked = true;
                }
                else
                {
                    chkManagerApply.Checked = false;
                }
                if (myDoc["VESoftwareSetting"]["EditReportSetting"]["ckbConvertAssocitedTime"].InnerText == "True")
                {
                    chkConvertTimeSheet.Checked = true;
                }
                else
                {
                    chkConvertTimeSheet.Checked = false;
                }
                if (myDoc["VESoftwareSetting"]["EditReportSetting"]["ItemCheck"].InnerText == "True")
                {
                    chkItem.Checked = true;
                }
                else
                {
                    chkItem.Checked = false;
                }
                if (myDoc["VESoftwareSetting"]["EditReportSetting"]["ExpensesCheck"].InnerText == "True")
                {
                    chkExpenses.Checked = true;
                }
                else
                {
                    chkExpenses.Checked = false;
                }
                if (myDoc["VESoftwareSetting"]["EditReportSetting"]["TimeCheck"].InnerText == "True")
                {
                    chkTime.Checked = true;
                }
                else
                {
                    chkTime.Checked = false;
                }

                cmbConvertTimeSheet.Text = (myDoc["VESoftwareSetting"]["EditReportSetting"]["Combovalue"].InnerText);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
