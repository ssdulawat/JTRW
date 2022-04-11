//using Common;
using Commen2;
using ComponentFactory.Krypton.Toolkit;
using CrystalDecisions.CrystalReports.Engine;
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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JobTracker.InvoiceReport
{
    public partial class RptInvoiceView : Form
    {
        #region Declaration
        //private DataAccessLayer PrintReporObj;
        private bool ExportStatus;
        private DataSet dataset = new DataSet();
        private static RptInvoiceView _Instance;
        private Thread rptThred;
        //private JobAndTrackingProgram Program;
        bool _ChkTime = false;

        public bool ChkTime
        {
            get
            {                
                return _ChkTime;
            }
            set
            {
                _ChkTime = value;
            }
        }

        #endregion

        public RptInvoiceView()
        {
            InitializeComponent();
        }

        #region EVents
        private void RptInvoiceView_Load(object sender, System.EventArgs e)
        {

         
        }

        private void btnExportInvoice_Click(System.Object sender, System.EventArgs e)
        {
           
        }

        private void btnPrintReport_Click(System.Object sender, System.EventArgs e)
        {
           

        }
        private void btnShowReport_Click(System.Object sender, System.EventArgs e)
        {
           
        }
        private void tbcInvoiceReport_Click(System.Object sender, System.EventArgs e)
        {
            //Dim strtbname As String = tbcInvoiceReport.SelectedTab.ToString()

            //If ChkTime = True Then

            //    ' tbcInvoiceReport.TabPages(0).Enabled = False

            //    tbcInvoiceReport.SelectedTab = tbItem

            //Else

            //End If
            //tbTime.Enabled = False


        }
        private void RptInvoiceView_FormClosed(System.Object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
           
        }
        #endregion

        #region Methods
        private void FillRptInvoiceView()
        {
            DataTable rptInvoiceDt = new DataTable();
            ReportDocument Rpt = null;

            //var list = StMethod.GetList<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + StMethod.GetSingle<string>("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail ").ToString() + "");

            var list = StMethod.GetList<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + StMethod.GetSingle<string>("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail ").ToString() + "");

            list = null;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                list = StMethod.GetListNew<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + StMethod.GetSingle<string>("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail ").ToString() + "");
            }
            else
            {
                list = StMethod.GetList<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + StMethod.GetSingle<string>("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail ").ToString() + "");
            }

            rptInvoiceDt = Program.ToDataTable(list);

            if (rptInvoiceDt.Rows.Count == 0)
            {
                KryptonMessageBox.Show("Record Not found");
            }
            else
            {

                try
                {
                    rptInvoiceDt.TableName = "InvoicePreview";
                    Rpt = new ReportDocument();
                    CRVAllInreport.RefreshReport();
                    string ReportPath = Application.StartupPath + "\\Reports\\rptInvoice.rpt";
                    Rpt.Load(ReportPath);
                    Rpt.SetDataSource(rptInvoiceDt);
                    if (Rpt.IsLoaded)
                    {
                        XmlDocument myDoc = new XmlDocument();
                        try
                        {
                            string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                            dir2 = dir2 + "\\JobTracker";
                            myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                            //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                            Rpt.SetParameterValue("CompanyAddress", myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText);
                            Rpt.SetParameterValue("CompanyPhoneNo", myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText);
                            Rpt.SetParameterValue("CompanyFax", myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        CRVAllInreport.ReportSource = Rpt;
                        CRVAllInreport.Refresh();

                        myDoc = null;
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Invoice Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void fillRptTimeInvoice()
        {
            DataTable rptInvoiceDt = new DataTable();

            string queryInvoiceTime = "SELECT * FROM rptInvoiceTime";
            
            DataTable invoiceTimedt = new DataTable();


            var list = StMethod.GetList<InvoiceRptTime>(queryInvoiceTime);
            list = null;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                list = StMethod.GetListNew<InvoiceRptTime>(queryInvoiceTime);

            }
            else
            {
                list = StMethod.GetList<InvoiceRptTime>(queryInvoiceTime);
            }

            invoiceTimedt = Program.ToDataTable(list);
            invoiceTimedt.TableName = "rptInvoiceTime";
            try
            {
                ReportDocument Rpt = new ReportDocument();
                string ReportPath = Application.StartupPath + "\\Reports\\rptTimeInvoice.rpt";
                Rpt.Load(ReportPath);
                //'Threading.Thread.Sleep(3000)
                Rpt.SetDataSource(invoiceTimedt);
                XmlDocument myDoc = new XmlDocument();
                try
                {
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    Rpt.SetParameterValue("CompanyAddress", myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText);
                    Rpt.SetParameterValue("CompanyPhoneNo", myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText);
                    Rpt.SetParameterValue("CompanyFax", myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                //'Threading.Thread.Sleep(3000)
                CRVAllInreport.ReportSource = Rpt;
                invoiceTimedt.Dispose();
                myDoc = null;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Time Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillRptExpensesInvoice()
        {
            DataTable rptInvoiceDt = new DataTable();

            string queryInvoiceExpenses = "SELECT * FROM rptInvoiceExpenses";

            DataTable invoiceExpensesdt = new DataTable();

            //using (EFDbContext db = new EFDbContext())
            //{
            //    var list = db.Database.SqlQuery<InvoiceRptExpanse>(queryInvoiceExpenses).ToList();
            //    invoiceExpensesdt = Program.ToDataTable(list);
            //}

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var list = db.Database.SqlQuery<InvoiceRptExpanse>(queryInvoiceExpenses).ToList();
                    invoiceExpensesdt = Program.ToDataTable(list);
                }

            }
            else
            {

                using (EFDbContext db = new EFDbContext())
                {
                    var list = db.Database.SqlQuery<InvoiceRptExpanse>(queryInvoiceExpenses).ToList();
                    invoiceExpensesdt = Program.ToDataTable(list);
                }

            }

            if (invoiceExpensesdt.Rows.Count == 0)
            {
                //  ChkTime = True
            }
            try
            {
                ReportDocument Rpt = new ReportDocument();
                string ReportPath = Application.StartupPath + "\\Reports\\rptTimeExpenses.rpt";
                Rpt.Load(ReportPath);
                System.Threading.Thread.Sleep(3000);
                Rpt.SetDataSource(invoiceExpensesdt);
                XmlDocument myDoc = new XmlDocument();
                try
                {

                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    Rpt.SetParameterValue("CompanyAddress", myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText);
                    Rpt.SetParameterValue("CompanyPhoneNo", myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText);
                    Rpt.SetParameterValue("CompanyFax", myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                System.Threading.Thread.Sleep(3000);
                CRVAllInreport.ReportSource = Rpt;
                invoiceExpensesdt.Dispose();
                myDoc = null;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Expenses Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //  End If
        }

        public string SubRemoveEnter(string Str)
        {
            try
            {
                //Dim chr As Char() = New Char() {chr(13)}
                //Dim SpliStr As String()
                //SpliStr = Str.Split(vbCrLf)
                Str = Str.Replace("\r\n", " ");
                //SpliStr = Str.Split(vbCrLf)
                return Str;
            }
            catch (Exception ex)
            {
                return Str;
            }
        }

        public string Addj(string Str)
        {
            try
            {
                if (Str.Contains("j") == true)
                {
                    if (Str.IndexOf("j") == Str.Length - 1)
                    {
                        return Str;
                    }
                    else
                    {
                        return Str + "j";
                    }

                }
                else
                {
                    return Str + "j";
                }
            }
            catch (Exception ex)
            {
                return Str;
            }
        }

        private void fillRptInvoiceTimeAll() //'For Use All in One
        {

            DataTable rptInvoiceDt = new DataTable();


            //string queryInvoicetime = "with AllReport as (SELECT     InvoiceNo, convert(varchar(12),InvoiceDate,101)as InvoiceDate, Jobdescription, DueDate, " +
            //       "Address, PhoneNo, FaxNo, Email,   Description, JobTrackDetailID, JobNumber, PONo,PaymentCr,   CONVERT(VARCHAR(20), Date, 101) as Date, Convert(nvarchar,Hrs) as Hrs, CONVERT(nvarchar, Rate) as Rate, JobTrackSubName, byname, Convert(nvarchar,Amount) as Amount, '' as Clienttext ,'' as Expenses,'Item' as ReportType FROM         InvoicePreview where JobTrackDetailID = ( SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail) union all SELECT     InvoiceNo, convert(varchar(12),InvoiceDate,101)as InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email,     Description, JobTrackDetailID,  JobNumber, PONo, PaymentCr,CONVERT(VARCHAR(20), Date, 101) as Date   ,  Time as Hrs , Rate,JobTrackSubName, Name as byname ,'' as Amount, Clienttext ,'' as Expenses,'Time' as ReportType FROM         rptInvoiceTime where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)union all SELECT     InvoiceNo, convert(varchar(12),InvoiceDate,101)as InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email, Description, JobTrackDetailID, JobNumber, PONo, PaymentCr,CONVERT(VARCHAR(20), Date, 101) as Date,  '' as Hrs,'' as Rate,'' as JobTrackSubName,  byname,'' as Amount,'' as Clienttext,Expenses,'Expenses' as ReportType  FROM         rptInvoiceExpenses where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)) select * from AllReport order by (case  ReportType when 'Item' then 0 when 'Time' then 1 when 'Expenses' then 2 end)";


            //Dim queryInvoiceTime As String = "SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email,   Description, JobTrackDetailID, JobNumber, PONo,PaymentCr,  Date, Convert(nvarchar,Hrs) as Hrs, '' as Time, CONVERT(nvarchar, Rate) as Rate, JobTrackSubName, byname, Convert(nvarchar,Amount) as Amount, '' as Clienttext ,'' as Expenses FROM         InvoicePreview where JobTrackDetailID = ( SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail) union SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email,     Description, JobTrackDetailID,  JobNumber, PONo, PaymentCr, Date   , '' as Hrs, Time, Rate,'' as JobTrackSubName, '' as byname,'' as Amount, Clienttext ,'' as Expenses FROM         rptInvoiceTime where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)union SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email, Description, JobTrackDetailID, JobNumber, PONo, PaymentCr, Date, Expenses , '' as Hrs,'' as Time,'' as Rate,'' as JobTrackSubName, '' as byname,'' as Amount,'' as Clienttext  FROM         rptInvoiceExpenses where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)"



            string queryInvoicetime = "with AllReport as (SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, " +
                "Address, PhoneNo, FaxNo, Email,   Description, JobTrackDetailID, JobNumber, PONo,PaymentCr,  Date, Convert(nvarchar,Hrs) as Hrs, CONVERT(nvarchar, Rate) as Rate, JobTrackSubName, byname, Convert(nvarchar,Amount) as Amount, '' as Clienttext ,'' as Expenses,'Item' as ReportType FROM         InvoicePreview where JobTrackDetailID = ( SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail) union all SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email,     Description, JobTrackDetailID,  JobNumber, PONo, PaymentCr,Date,  Time as Hrs , Rate,JobTrackSubName, Name as byname ,'' as Amount, Clienttext ,'' as Expenses,'Time' as ReportType FROM         rptInvoiceTime where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)union all SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email, Description, JobTrackDetailID, JobNumber, PONo, PaymentCr,Date,  '' as Hrs,'' as Rate,'' as JobTrackSubName,  byname,'' as Amount,'' as Clienttext,Expenses,'Expenses' as ReportType  FROM         rptInvoiceExpenses where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)) select * from AllReport order by (case  ReportType when 'Item' then 0 when 'Time' then 1 when 'Expenses' then 2 end)";



            DataTable invoiceTimedt = new DataTable();

            //using (EFDbContext db = new EFDbContext())
            //{
            //    //var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoicetime).ToList();
            //    //invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);

            //    var list = db.Database.SqlQuery<InvoiceRptAllNew>(queryInvoicetime).ToList();
            //    invoiceTimedt = Program.ToDataTable<InvoiceRptAllNew>(list);


            //}


            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    //var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoicetime).ToList();
                    //invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);

                    var list = db.Database.SqlQuery<InvoiceRptAllNew>(queryInvoicetime).ToList();
                    invoiceTimedt = Program.ToDataTable<InvoiceRptAllNew>(list);


                }


            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    //var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoicetime).ToList();
                    //invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);

                    var list = db.Database.SqlQuery<InvoiceRptAllNew>(queryInvoicetime).ToList();
                    invoiceTimedt = Program.ToDataTable<InvoiceRptAllNew>(list);


                }


            }



            // invoiceTimedt.TableName = "rptInvoiceTime"
            try
            {
                ReportDocument Rpt = new ReportDocument();
                string ReportPath = Application.StartupPath + "\\Reports\\AllGroupBy.rpt";
                Rpt.Load(ReportPath);
                //Threading.Thread.Sleep(3000)
                Rpt.SetDataSource(invoiceTimedt);
                XmlDocument myDoc = new XmlDocument();
                try
                {

                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    Rpt.SetParameterValue("CompanyAddress", myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText);
                    Rpt.SetParameterValue("CompanyPhoneNo", myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText);
                    Rpt.SetParameterValue("CompanyFax", myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                // Threading.Thread.Sleep(3000)
                CRVAllInreport.ReportSource = Rpt;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Time Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillRptInvoiceItemAndTime()
        {
            DataTable rptInvoiceDt = new DataTable();
            //'Use JobTrackSubName instead default blank value, rptInvoiceTime had added one column with JobTrackSubNum
            string queryInvoiceTime = "with ItemTime as (SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email,   Description, JobTrackDetailID, JobNumber, PONo,PaymentCr, CONVERT(VARCHAR(20), Date, 101) as Date  , Convert(nvarchar,Hrs) as Hrs, CONVERT(nvarchar, Rate) as Rate, JobTrackSubName, byname, Convert(nvarchar,Amount) as Amount, '' as Clienttext ,'' as Expenses,'Item' as ReportType FROM         InvoicePreview where JobTrackDetailID = ( SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail) union all SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email,     Description, JobTrackDetailID,  JobNumber, PONo, PaymentCr, CONVERT(VARCHAR(20), Date, 101) as Date  ,  Time as Hrs , Rate, JobTrackSubName, Name as byname ,'' as Amount, Clienttext ,'' as Expenses,'Time' as ReportType FROM         rptInvoiceTime where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)) select * from ItemTime order by(case ReportType when 'Item' then 0 when 'Time' then 1 end)";
            // Dim queryInvoiceTime As String = "select * From vw_Item_Time_Expense"
            DataTable invoiceTimedt = new DataTable();



            //using (EFDbContext db = new EFDbContext())
            //{
            //    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
            //    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
            //}


            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
                    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
                }
            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
                    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
                }
            }


            // invoiceTimedt.TableName = "rptInvoiceTime"
            try
            {
                ReportDocument Rpt = new ReportDocument();
                string ReportPath = Application.StartupPath + "\\Reports\\AllGroupBy.rpt";
                //Dim ReportPath As String = Application.StartupPath & "\Reports\ItemExpensestime.rpt"
                Rpt.Load(ReportPath);
                System.Threading.Thread.Sleep(3000);
                Rpt.SetDataSource(invoiceTimedt);
                XmlDocument myDoc = new XmlDocument();
                try
                {
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    Rpt.SetParameterValue("CompanyAddress", myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText);
                    Rpt.SetParameterValue("CompanyPhoneNo", myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText);
                    Rpt.SetParameterValue("CompanyFax", myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                System.Threading.Thread.Sleep(3000);
                CRVAllInreport.ReportSource = Rpt;
                //CRVAllreport.RefreshReport()
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Time Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillInvoiceItemAndExpenses()
        {
            DataTable rptInvoiceDt = new DataTable();
            string queryInvoiceTime = "with ItemExpenses  as (SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email,   Description, JobTrackDetailID, JobNumber, PONo,PaymentCr,  CONVERT(VARCHAR(20), Date, 101) as Date, Convert(nvarchar,Hrs) as Hrs,  CONVERT(nvarchar, Rate) as Rate, JobTrackSubName, byname, Convert(nvarchar,Amount) as Amount, '' as Clienttext,'' as  Expenses,'Item' as ReportType FROM         InvoicePreview where JobTrackDetailID = ( SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail) union all SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email, Description, JobTrackDetailID, JobNumber, PONo, PaymentCr, CONVERT(VARCHAR(20), Date, 101) as Date,  '' as Hrs,'' as Rate,'' as JobTrackSubName, byname,'' as Amount,'' as Clienttext,Expenses,'Expenses' as ReportType  FROM         rptInvoiceExpenses where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail))select * from ItemExpenses order by (case  ReportType when 'Item' then 0 when 'Expenses' then 1 end)";
            DataTable invoiceTimedt = new DataTable();

            //using (EFDbContext db = new EFDbContext())
            //{
            //    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
            //    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
            //}


            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
                    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
                }


            }
            else
            {

                using (EFDbContext db = new EFDbContext())
                {
                    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
                    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
                }

            }


            // invoiceTimedt.TableName = "rptInvoiceTime"
            try
            {
                ReportDocument Rpt = new ReportDocument();
                string ReportPath = Application.StartupPath + "\\Reports\\AllGroupBy.rpt";
                Rpt.Load(ReportPath);
                System.Threading.Thread.Sleep(3000);
                Rpt.SetDataSource(invoiceTimedt);
                XmlDocument myDoc = new XmlDocument();
                try
                {
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    Rpt.SetParameterValue("CompanyAddress", myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText);
                    Rpt.SetParameterValue("CompanyPhoneNo", myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText);
                    Rpt.SetParameterValue("CompanyFax", myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                // Threading.Thread.Sleep(3000)
                CRVAllInreport.ReportSource = Rpt;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Time Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillInvoiceTimeAndExpenses()
        {
            DataTable rptInvoiceDt = new DataTable();
            string queryInvoiceTime = "with TimeExpenses as (SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email,     Description, JobTrackDetailID,  JobNumber, PONo, PaymentCr, CONVERT(VARCHAR(20), Date, 101) as Date ,  Time as Hrs, Rate, JobTrackSubName, Name as byname,'' as Amount, Clienttext ,'' as Expenses,'Time' as ReportType FROM         rptInvoiceTime where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)union all SELECT     InvoiceNo, InvoiceDate, Jobdescription, DueDate, Address, PhoneNo, FaxNo, Email, Description, JobTrackDetailID, JobNumber, PONo, PaymentCr, CONVERT(VARCHAR(20), Date, 101) as Date,  '' as Hrs,'' as Rate,'' as JobTrackSubName, byname,'' as Amount,'' as Clienttext,Expenses,'Expenses' as ReportType  FROM         rptInvoiceExpenses where JobTrackDetailID =(SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail)) select * from TimeExpenses order by (case  ReportType when 'Time' then 0 when 'Expenses' then 1 end)";


            DataTable invoiceTimedt = new DataTable();


            //using (EFDbContext db = new EFDbContext())
            //{
            //    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
            //    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
            //}


            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
                    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
                }

            }
            else
            {

                using (EFDbContext db = new EFDbContext())
                {
                    var list = db.Database.SqlQuery<InvoiceRptAll>(queryInvoiceTime).ToList();
                    invoiceTimedt = Program.ToDataTable<InvoiceRptAll>(list);
                }

            }

            // invoiceTimedt.TableName = "rptInvoiceTime"
            try
            {
                ReportDocument Rpt = new ReportDocument();
                string ReportPath = Application.StartupPath + "\\Reports\\AllGroupBy.rpt";
                Rpt.Load(ReportPath);
                System.Threading.Thread.Sleep(3000);
                Rpt.SetDataSource(invoiceTimedt);
                XmlDocument myDoc = new XmlDocument();
                try
                {

                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    Rpt.SetParameterValue("CompanyAddress", myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText);
                    Rpt.SetParameterValue("CompanyPhoneNo", myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText);
                    Rpt.SetParameterValue("CompanyFax", myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
                //Threading.Thread.Sleep(3000)
                CRVAllInreport.ReportSource = Rpt;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Time Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void RptInvoiceView_Load_1(object sender, EventArgs e)
        {
            //If JobAndTrackingProgram.InvoiceAll Then

            //    tbcInvoiceReport.TabPages.Remove(tbItem)
            //    tbcInvoiceReport.TabPages.Remove(tbTime)
            //    tbcInvoiceReport.TabPages.Remove(tbExpenses)
            //    fillRptInvoiceTimeAll()
            //Else
            //    If JobAndTrackingProgram.InvoiceItem Then
            //        FillRptInvoiceView()
            //    Else
            //        tbcInvoiceReport.TabPages.Remove(tbItem)
            //    End If

            //    If JobAndTrackingProgram.InvoiceTime Then
            //        fillRptTimeInvoice()
            //    Else
            //        tbcInvoiceReport.TabPages.Remove(tbTime)
            //    End If

            //    If JobAndTrackingProgram.InvoiceExpenses Then
            //        fillRptExpensesInvoice()
            //    Else
            //        tbcInvoiceReport.TabPages.Remove(tbExpenses)
            //    End If

            //    tbcInvoiceReport.TabPages.Remove(tbAll)
            //End If
            try
            {

                System.Windows.Forms.Cursor.Position = new Point(0, 0); //don't remove this code becouse is system error change the cursor position Solve Ravi sir

                //MessageBox.Show("1");

                if (Program.InvoiceItem == true && Program.InvoiceTime == true && Program.InvoiceExpenses == false)
                {
                   // MessageBox.Show("2");
                    fillRptInvoiceItemAndTime();
                    lblCrvReport.Text = "Item And Time Report";

                }
                if (Program.InvoiceItem == true && Program.InvoiceExpenses == true && Program.InvoiceTime == false)
                {
                    //MessageBox.Show("3");
                    fillInvoiceItemAndExpenses();
                    lblCrvReport.Text = "Item And Expenses Report";
                }
                if (Program.InvoiceTime == true && Program.InvoiceExpenses == true && Program.InvoiceItem == false)
                {
                    //MessageBox.Show("4");
                    fillInvoiceTimeAndExpenses();
                    lblCrvReport.Text = "Time And Expenses Report";
                }
                if (Program.InvoiceTime == true && Program.InvoiceExpenses == true && Program.InvoiceItem == true)
                {
                    //MessageBox.Show("5");
                    fillRptInvoiceTimeAll();
                    lblCrvReport.Text = "All Report";
                }
                if (Program.InvoiceReportFlag == true)
                {
                    if (Program.InvoiceItem)
                    {

                        System.Windows.Forms.Cursor.Position = new Point(0, 0);
                        //rptThred = New Thread(AddressOf FillRptInvoiceView)
                        //rptThred.IsBackground = True
                        //rptThred.Start()
                        //MessageBox.Show("6");
                        FillRptInvoiceView();
                        lblCrvReport.Text = "Item Report";

                    }

                    if (Program.InvoiceTime)
                    {
                        fillRptTimeInvoice();
                        lblCrvReport.Text = "Time Report";
                    }

                    if (Program.InvoiceExpenses)
                    {
                        fillRptExpensesInvoice();
                        lblCrvReport.Text = "Expenses Report";
                    }
                }

                System.Windows.Forms.Cursor.Position = new Point(0, 0);
                btnShowReport.Visible = false;
                btnPrintReport.Visible = false;
                System.Windows.Forms.Cursor.Position = new Point(0, 0);
                // Dim printDia As New PrintDialog
                // printDia.ShowDialog()
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message.ToString());
            }

            System.Windows.Forms.Cursor.Position = new Point(0, 0);
        }

        private void btnShowReport_Click_1(object sender, EventArgs e)
        {
            //    Dim rptInvoiceDt As New DataTable
            //    PrintReporObj = New DataAccessLayer
            //    ' rptInvoiceDt = PrintReporObj.Filldatatable("SELECT * FROM InvoiceReport WHERE JobListID=" & JobAndTrackingProgram.GetJobID & "")
            //    rptInvoiceDt = PrintReporObj.Filldatatable("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" & PrintReporObj.ExceuteScaler("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail ").ToString & "")
            //    If rptInvoiceDt.Rows.Count = 0 Then
            //        KryptonMessageBox.Show("Record Not found")
            //    Else
            //        Try
            //            Dim Rpt As New ReportDocument
            //            Dim ReportPath As String = Application.StartupPath & "\Reports\rptInvoice.rpt"
            //            Rpt.Load(ReportPath)
            //            Threading.Thread.Sleep(3000)
            //            Rpt.SetDataSource(rptInvoiceDt)
            //            Threading.Thread.Sleep(3000)
            //            CRVInvoice.ReportSource = Rpt
            //        Catch ex As Exception
            //            KryptonMessageBox.Show(ex.Message, "Invoice Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            //        End Try
            //    End If
        }

        private void btnExportInvoice_Click_1(object sender, EventArgs e)
        {
            try
            {
                DataTable INDetailDT = new DataTable();
                DataTable RateDT = new DataTable();

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var list = db.Database.SqlQuery<InvoiceExport>("SELECT JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription,           JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address, JobTrackInvoiceDetail.PhoneNo,JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email,            JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue, JobTrackInvoiceDetail.Aging,       JobTrackInvoiceDetail.OpeningBal, JobTrackInvoiceDetail.JobListID, Company.CompanyName,JobList.JobNumber,JobList.Address + JobList.State as JobAddress FROM  JobTrackInvoiceDetail INNER JOIN               JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID INNER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE JobTrackInvoiceDetail.JobTrackDetailID IN(SELECT MAX(JobTrackDetailID)as ID FROM JobTrackInvoiceDetail)").ToList();
                //    INDetailDT = Program.ToDataTable(list);
                //    var list1 = db.Database.SqlQuery<InvoiceJobDtl>("SELECT JobTrackInvoiceRateDetail.InvoiceRptID, JobTrackInvoiceRateDetail.TrackSubID, JobTrackInvoiceRateDetail.JobTrackSubName,  JobTrackInvoiceRateDetail.JobTrackDetailID, JobTrackInvoiceRateDetail.Hrs, JobTrackInvoiceRateDetail.Rate, JobTrackInvoiceRateDetail.Description, MasterTrackSubItem.Account FROM  JobTrackInvoiceRateDetail LEFT OUTER JOIN    MasterTrackSubItem ON JobTrackInvoiceRateDetail.TrackSubID = MasterTrackSubItem.Id  WHERE JobTrackDetailID IN(SELECT MAX(JobTrackDetailID)as ID FROM JobTrackInvoiceDetail)").ToList();
                //    RateDT = Program.ToDataTable(list1);
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db.Database.SqlQuery<InvoiceExport>("SELECT JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription,           JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address, JobTrackInvoiceDetail.PhoneNo,JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email,            JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue, JobTrackInvoiceDetail.Aging,       JobTrackInvoiceDetail.OpeningBal, JobTrackInvoiceDetail.JobListID, Company.CompanyName,JobList.JobNumber,JobList.Address + JobList.State as JobAddress FROM  JobTrackInvoiceDetail INNER JOIN               JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID INNER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE JobTrackInvoiceDetail.JobTrackDetailID IN(SELECT MAX(JobTrackDetailID)as ID FROM JobTrackInvoiceDetail)").ToList();
                        INDetailDT = Program.ToDataTable(list);
                        var list1 = db.Database.SqlQuery<InvoiceJobDtl>("SELECT JobTrackInvoiceRateDetail.InvoiceRptID, JobTrackInvoiceRateDetail.TrackSubID, JobTrackInvoiceRateDetail.JobTrackSubName,  JobTrackInvoiceRateDetail.JobTrackDetailID, JobTrackInvoiceRateDetail.Hrs, JobTrackInvoiceRateDetail.Rate, JobTrackInvoiceRateDetail.Description, MasterTrackSubItem.Account FROM  JobTrackInvoiceRateDetail LEFT OUTER JOIN    MasterTrackSubItem ON JobTrackInvoiceRateDetail.TrackSubID = MasterTrackSubItem.Id  WHERE JobTrackDetailID IN(SELECT MAX(JobTrackDetailID)as ID FROM JobTrackInvoiceDetail)").ToList();
                        RateDT = Program.ToDataTable(list1);
                    }

                }
                else
                {

                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<InvoiceExport>("SELECT JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription,           JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address, JobTrackInvoiceDetail.PhoneNo,JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email,            JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue, JobTrackInvoiceDetail.Aging,       JobTrackInvoiceDetail.OpeningBal, JobTrackInvoiceDetail.JobListID, Company.CompanyName,JobList.JobNumber,JobList.Address + JobList.State as JobAddress FROM  JobTrackInvoiceDetail INNER JOIN               JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID INNER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE JobTrackInvoiceDetail.JobTrackDetailID IN(SELECT MAX(JobTrackDetailID)as ID FROM JobTrackInvoiceDetail)").ToList();
                        INDetailDT = Program.ToDataTable(list);
                        var list1 = db.Database.SqlQuery<InvoiceJobDtl>("SELECT JobTrackInvoiceRateDetail.InvoiceRptID, JobTrackInvoiceRateDetail.TrackSubID, JobTrackInvoiceRateDetail.JobTrackSubName,  JobTrackInvoiceRateDetail.JobTrackDetailID, JobTrackInvoiceRateDetail.Hrs, JobTrackInvoiceRateDetail.Rate, JobTrackInvoiceRateDetail.Description, MasterTrackSubItem.Account FROM  JobTrackInvoiceRateDetail LEFT OUTER JOIN    MasterTrackSubItem ON JobTrackInvoiceRateDetail.TrackSubID = MasterTrackSubItem.Id  WHERE JobTrackDetailID IN(SELECT MAX(JobTrackDetailID)as ID FROM JobTrackInvoiceDetail)").ToList();
                        RateDT = Program.ToDataTable(list1);
                    }

                }

                decimal TotAmountStr = 0M;
                for (int i = 0; i < RateDT.Rows.Count; i++)
                {
                    TotAmountStr = Convert.ToDecimal(TotAmountStr + Convert.ToDecimal(RateDT.Rows[i]["Hrs"]) * Convert.ToDecimal(RateDT.Rows[i]["Rate"]));
                }
                string InvoiceDetail = "!TRNS	TRNSID	TRNSTYPE	DATE	ACCNT	NAME	CLASS	AMOUNT	DOCNUM	MEMO	CLEAR	TOPRINT	ADDR1	ADDR2	ADDR3	ADDR4	ADDR5	DUEDATE	TERMS	FOB	INVTITLE	INVMEMO																			" + "\r\n" + "!SPL	SPLID	TRNSTYPE	DATE	ACCNT	NAME	CLASS	AMOUNT	DOCNUM	MEMO	CLEAR	QNTY	PRICE	INVITEM	PAYMETH	TAXABLE	REIMBEXP	EXTRA																							" + "\r\n" + "!ENDTRNS																																								" + "\r\n" + "TRNS	" + INDetailDT.Rows[0]["JobTrackDetailID"].ToString() + "	INVOICE	" + GenericHelper.FormateDate((DateTime)INDetailDT.Rows[0]["InvoiceDate"]) + "	" + "Accounts Receivable	" + INDetailDT.Rows[0]["CompanyName"].ToString() + "		" + string.Format("{0:n2}", TotAmountStr) + "	" + Addj(INDetailDT.Rows[0]["InvoiceNo"].ToString()) + "		N	N	" + INDetailDT.Rows[0]["CompanyName"].ToString() + " (client)	" + SubRemoveEnter(INDetailDT.Rows[0]["Address"].ToString()) + "		JOB DESCRIPTION:" + INDetailDT.Rows[0]["CompanyName"].ToString() + "	" + INDetailDT.Rows[0]["JobAddress"].ToString() + "	" + GenericHelper.FormateDate((DateTime)INDetailDT.Rows[0]["DueDate"]) + "	Due on receipt			Invoice to continue on following page?																			";
                string RateDetailStr = string.Empty;
                for (int i = 0; i < RateDT.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        RateDetailStr = "SPL	" + RateDT.Rows[i]["InvoiceRptID"].ToString() + "	INVOICE	" + GenericHelper.FormateDate((DateTime)INDetailDT.Rows[0]["InvoiceDate"]) + "	" + RateDT.Rows[i]["Account"].ToString() + "			" + "-" + string.Format("{0:n2}", Convert.ToDecimal((RateDT.Rows[i]["Hrs"])) * Convert.ToDecimal(RateDT.Rows[i]["Rate"])) + "		" + RateDT.Rows[i]["Description"].ToString() + "	N	" + "-" + string.Format("{0:n2}", RateDT.Rows[i]["Hrs"]) + "	" + RateDT.Rows[i]["Rate"].ToString() + "	" + RateDT.Rows[i]["JobTrackSubName"].ToString() + "		N	N	NOTHING																							";
                    }
                    else
                    {
                        RateDetailStr = RateDetailStr + "\r\n" + "SPL	" + RateDT.Rows[i]["InvoiceRptID"].ToString() + "	INVOICE	" + GenericHelper.FormateDate((DateTime)INDetailDT.Rows[0]["InvoiceDate"]) + "	" + RateDT.Rows[i]["Account"].ToString() + "			" + "-" + string.Format("{0:n2}", Convert.ToDecimal((RateDT.Rows[i]["Hrs"])) * Convert.ToDecimal(RateDT.Rows[i]["Rate"])) + "		" + RateDT.Rows[i]["Description"].ToString() + "	N	" + "-" + string.Format("{0:n2}", RateDT.Rows[i]["Hrs"]) + "	" + RateDT.Rows[i]["Rate"].ToString() + "	" + RateDT.Rows[i]["JobTrackSubName"].ToString() + "		N	N	NOTHING																							";
                    }
                }
                RateDetailStr = RateDetailStr + "\r\n" + "ENDTRNS																																								" + "\r\n";

                try
                {
                    string QuickBookFile = Path.Combine(AppConstants.QuickBookFileDirectory, "Inv_Trans_" + DateTime.Now.ToString("yy") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd") + ".IIF");
                    SaveFileDialog saveFileInvoice = new SaveFileDialog();
                    if (File.Exists(QuickBookFile))
                    {
                        if (ExportStatus == true)
                        {
                            btnExportInvoice.BackColor = Color.Tomato;
                            if (KryptonMessageBox.Show("You already export invoice is done! You want to continue.", "Export Quick Book(IFF)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        //saveFileInvoice.Filter = "QuickBookFormat|*.IIF"
                        //saveFileInvoice.Title = "Save an Quick Book(IIF) File"
                        //saveFileInvoice.InitialDirectory = "N:\VE\QuickBooks\Invoice transfer folder"
                        //'saveFileInvoice.FileName = INDetailDT.Rows[0).Item("InvoiceNo").ToString + "j"
                        //saveFileInvoice.FileName = "Inv_Trans_" + Format(Date.Now, "yy") + "_" + Format(Date.Now, "MM") + "_" + Format(Date.Now, "dd")
                        //saveFileInvoice.ShowDialog()
                        FileStream CreateInvoiceFile = new FileStream(QuickBookFile, FileMode.Append, FileAccess.Write);
                        StreamWriter Writer = new StreamWriter(CreateInvoiceFile);
                        Writer.Write(InvoiceDetail + "\r\n" + RateDetailStr);
                        Writer.Flush();
                        Writer.Close();
                        CreateInvoiceFile.Close();
                        ExportStatus = true;
                        //btnExportInvoice.Enabled = False
                    }
                    else
                    {
                        if (ExportStatus == true)
                        {
                            btnExportInvoice.BackColor = Color.Tomato;
                            if (KryptonMessageBox.Show("You already export invoice is done! You want to continue.", "Export Quick Book(IFF)", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                return;
                            }
                        }
                        saveFileInvoice.Filter = "QuickBookFormat|*.IIF";
                        saveFileInvoice.Title = "Save an Quick Book(IIF) File";
                        saveFileInvoice.InitialDirectory = AppConstants.QuickBookFileDirectory;
                        //saveFileInvoice.FileName = INDetailDT.Rows[0).Item("InvoiceNo").ToString + "j"
                        saveFileInvoice.FileName = "Inv_Trans_" + DateTime.Now.ToString("yy") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd");
                        if (saveFileInvoice.ShowDialog() == DialogResult.Cancel)
                        {
                            return;
                        }
                        FileStream CreateInvoiceFile = new FileStream(saveFileInvoice.FileName, FileMode.Create, FileAccess.Write);
                        StreamWriter Writer = new StreamWriter(CreateInvoiceFile);
                        Writer.Write(InvoiceDetail + "\r\n" + RateDetailStr);
                        Writer.Flush();
                        Writer.Close();
                        CreateInvoiceFile.Close();
                        ExportStatus = true;
                        // btnExportInvoice.Enabled = False
                    }
                    KryptonMessageBox.Show("Export Successfully Done.", "Export Quick Book(IFF)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Export Quick Book(IFF)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnPrintReport_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (PrintDialog printDia = new PrintDialog())
                {
                    printDia.ShowDialog();
                    using (ReportDocument printDocument = new ReportDocument())
                    {

                        DataTable rptInvoiceDt = new DataTable();

                        //string detailId = StMethod.GetSingle<string>("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail");
                        //var list = StMethod.GetList<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + detailId + "");

                        string detailId = StMethod.GetSingle<string>("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail");
                        var list = StMethod.GetList<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + detailId + "");
                        list = null;



                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            detailId = StMethod.GetSingleNew<string>("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail");
                            list = StMethod.GetListNew<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + detailId + "");


                        }
                        else
                        {
                            detailId = StMethod.GetSingle<string>("SELECT ISNULL(MAX(JobTrackDetailID),0) AS JobTrackDetailID FROM JobTrackInvoiceDetail");
                            list = StMethod.GetList<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + detailId + "");
                        }

                        rptInvoiceDt = Program.ToDataTable(list);
                        printDocument.SetDataSource(rptInvoiceDt);
                        int ncopy = 0;
                        int frompage = 0;
                        int topage = 0;
                        ncopy = printDia.PrinterSettings.Copies;
                        frompage = printDia.PrinterSettings.FromPage;
                        topage = printDia.PrinterSettings.ToPage;
                        string PrinterName = printDia.PrinterSettings.PrinterName;
                        try
                        {
                            printDocument.PrintOptions.PrinterName = PrinterName;
                            printDocument.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
                            printDocument.PrintToPrinter(ncopy, false, frompage, topage);
                        }
                        catch (Exception ex)
                        {

                        }
                        rptInvoiceDt.Dispose();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void RptInvoiceView_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            try
            { 
            CRVAllInreport.ReportSource = null;
            this.CRVAllInreport.Dispose();
            this.CRVAllInreport = null;
            this.Dispose(false);
            GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }


    }
}