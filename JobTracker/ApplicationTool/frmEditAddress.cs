using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JobTracker.Application_Tool
{
    public partial class frmEditAddress : Form
    {
        public frmEditAddress()
        {
            InitializeComponent();
        }

        #region Events
        private void frmEditAddress_Load(object sender, System.EventArgs e)
        {
            XmlDocument myDoc = new XmlDocument();
            try
            {

                string dir4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir4 = dir4 + "\\JobTracker";

                //CheckMail.Load(dir4 + "\\CheckFile.xml");

                myDoc.Load(dir4 + "\\VESoftwareSetting.xml");
                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");


                txtAddress.Text = myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText;
                txtPhoneNo.Text = myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText;
                txtFaxNo.Text = myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void btnSaveAddress_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();


                string dir4 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                dir4 = dir4 + "\\JobTracker";

                //CheckMail.Load(dir4 + "\\CheckFile.xml");

                doc.Load(dir4 + "\\VESoftwareSetting.xml");
                
                //doc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");


                XmlNode node = doc.SelectSingleNode("/VESoftwareSetting/ComapanyAddress");
                node.ChildNodes.Item(0).InnerText = this.txtAddress.Text;
                node.ChildNodes.Item(1).InnerText = this.txtPhoneNo.Text;
                node.ChildNodes.Item(2).InnerText = this.txtFaxNo.Text;


                doc.Save(dir4 + "\\VESoftwareSetting.xml");
                //doc.Save(Application.StartupPath + "\\VESoftwareSetting.xml");
                KryptonMessageBox.Show("Setting save successfully");
            }
            catch (IOException ex1)
            {
                KryptonMessageBox.Show(ex1.Message + " Please check the access right of VESoftwareSetting.xml.");
            }
            catch (Exception ex2)
            {
                KryptonMessageBox.Show(ex2.Message + " Please check the access right of VESoftwareSetting.xml.");
            }
        }
        #endregion
    }
}
