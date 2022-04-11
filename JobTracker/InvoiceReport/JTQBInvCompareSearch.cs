using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Globalization;
using System.Reflection;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

using NPOI.HSSF.UserModel;
//using NPOI.SS.UserModel;
//using NPOI.XSSF.UserModel;

namespace JobTracker.InvoiceReport
{
    public partial class JTQBInvCompareSearch : Form
    {
        #region Declaration
        private string SelectedFileName;

        DataTable TempDT = new DataTable();
        List<JTQuickbookCompaireList> FinalResponceData = null;
        
        //private XSSFWorkbook workBook = new XSSFWorkbook();


        private HSSFWorkbook workBook = new HSSFWorkbook();
        string path; 

        //if (extension == "xlsx")
        //{
        //    workbook = new XSSFWorkbook();
        //}
        //else if (extension == "xls")
        //{
        //    workbook = new HSSFWorkbook();
        //}



        private void SetSelectedFileName()
        {
            if (!string.IsNullOrEmpty(SelectedFileName))
            {
                lblFileName.Text = System.IO.Path.GetFileName(SelectedFileName);
                lblFileName.ForeColor = Color.Green;
            }
            else
            {
                lblFileName.Text = "File not selected";
                lblFileName.ForeColor = Color.Red;
            }
        }

        #endregion

        public JTQBInvCompareSearch()
        {
            InitializeComponent();
        }

        #region Events
        private void BtnFileSelect_Click(System.Object sender, System.EventArgs e)
        {
            SetSelectedFileName();
            OpenFileDialog OpenExcel = new OpenFileDialog();
           

            DialogResult Result;
            //string[] dirs = System.IO.Directory.GetLogicalDrives;
            string[] dirs = System.IO.Directory.GetLogicalDrives();
            string[] arDrives;
            arDrives = Directory.GetLogicalDrives();

            long j;


            //For j = dirs.GetLowerBound(0) To dirs.GetUpperBound(0)

            for (j = dirs.GetLowerBound(0); (j <= dirs.GetUpperBound(0)); j++)
            {
               
                DriveInfo Drive_Info;
                Drive_Info = new DriveInfo(dirs[j]);
                string DriveType = Drive_Info.DriveType.ToString();

                path = dirs[j] + @"VE\QuickBooks\JT QB Inv Compare";

                OpenExcel.Multiselect = false;
                OpenExcel.Title = "File Search";
                OpenExcel.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                OpenExcel.InitialDirectory = @"C:\";
                OpenExcel.RestoreDirectory = false;

                path = path.Trim();

                if(Directory.Exists(path))
                {
                    OpenExcel.InitialDirectory = path;
                }
                else
                {
                    OpenExcel.InitialDirectory = @"C:\";
                }             
            }





            //OpenFileDialog OpenExcel = new OpenFileDialog();
            //OpenExcel.Multiselect = false;
            //OpenExcel.Title = "File Search";
            //OpenExcel.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";

            Result = OpenExcel.ShowDialog();

            if (Result == DialogResult.OK)
            {
                SelectedFileName = OpenExcel.FileName;

                if (!string.IsNullOrEmpty(SelectedFileName))
                {
                    NPOIUtility.ReadExcelUtility NPOIutiltiyObj = new NPOIUtility.ReadExcelUtility();
                    string StringDateRange = NPOIutiltiyObj.GetExcelSheetCellValue(SelectedFileName, 1, 1, 0);


                    if (!string.IsNullOrEmpty(StringDateRange))
                    {
                        if (!GetDateRange(StringDateRange))
                        {
                            MessageBox.Show("Invoice Date-Range not in valid format. Please select Invoice Date-Range manual.", "JTQuickbookCompaire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Invoice Date-Range not available in the selected file. Please select Invoice Date-Range manual.", "JTQuickbookCompaire", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (true)
                    {

                    }

                    //'Jun 1 - Sep 27, 18
                }
                //txtFilePath.Text = OpenExcel.FileName
            }

            SetSelectedFileName();
        }
        private void BtnInvoiceSearch_Click(System.Object sender, System.EventArgs e)
        {
            DataTable Dt = new DataTable();
            grdCompaireInvoiceStatus.DataSource = Dt;

            if (IsvalidToProcess())
            {
                List<JTQuickbookCompaireList> ExcelData = null;
                List<JTQuickbookCompaireList> DBInvoiceData = null;
                ExcelData = GetExcelData(SelectedFileName);

               

                if (ExcelData.Count > 0)
                {
                    //' Filter Data based on selected date rage

                    //string to = dtpInvoiceTo.Value.ToString();
                    //string From = dtpInvoiceFrom.Value.ToString();

                    ExcelData = ExcelData.Where((w) => w.InvoiceDate <= dtpInvoiceTo.Value && w.InvoiceDate >= dtpInvoiceFrom.Value).ToList();

                    //ExcelData = ExcelData.Where(Function(w) w.InvoiceDate <= dtpInvoiceTo.Value AndAlso w.InvoiceDate >= dtpInvoiceFrom.Value).ToList()

                    //ExcelData = ExcelData.Where(w => w.InvoiceDate <= dtpInvoiceTo.Value && w.InvoiceDate >= dtpInvoiceFrom.Value).ToList();



                    if (ExcelData.Count > 0)
                    {

                        //MessageBox.Show(ExcelData.Count.ToString ());

                        //'''' here we need to get data from DB same as exinting logic for JT invoice Search form

                        
                        
                        DBInvoiceData = GetInvoiceDataByDateRange();
                        
                        
                        
                        //DBInvoiceData = ExcelData;


                        if (DBInvoiceData.Count > 0)
                        {
                            //' Not available in Databasel
                            List<JTQuickbookCompaireList> NotInExcelSheet = DBInvoiceData.Where((p) => !ExcelData.Any((p2) => p2.InvoiceNumber.Trim().ToUpper() == p.InvoiceNumber.Trim().ToUpper())).ToList();

                            //' Not available in Selected Excel File
                            List<JTQuickbookCompaireList> NotInDataBase = ExcelData.Where((p) => !DBInvoiceData.Any((p2) => p2.InvoiceNumber.Trim().ToUpper() == p.InvoiceNumber.Trim().ToUpper())).ToList();

                            //' Available Both side but Amount not match
                            List<JTQuickbookCompaireList> BothButAmountNotMatch = DBInvoiceData.Where((p) => ExcelData.Any((p2) => p2.InvoiceNumber.Trim().ToUpper() == p.InvoiceNumber.Trim().ToUpper() && p2.InvoiceAmount != p.InvoiceAmount)).ToList();

                           
                            NotInDataBase.ForEach((obj) => obj.StatusDescription = "Not In JobList");
                            NotInExcelSheet.ForEach((obj) => obj.StatusDescription = "Not In Selected File");
                            BothButAmountNotMatch.ForEach((obj) => obj.StatusDescription = "Amount does not match");

                            FinalResponceData = NotInDataBase;
                            FinalResponceData.AddRange(NotInExcelSheet);
                            FinalResponceData.AddRange(BothButAmountNotMatch);

                            grdCompaireInvoiceStatus.DataSource = FinalResponceData;

                            TempDT = ToDataTable(FinalResponceData);
                            //TempDT = ConvertToDataTable(FinalResponceData);
                            //TempDT = FinalResponceData;


                            //for (int i = 0; i < grdCompaireInvoiceStatus.Columns.Count; i++)
                            //{
                            //    TempDT.Columns.Add("column" + i.ToString());
                            //}


                            //foreach (DataGridViewRow row in grdCompaireInvoiceStatus.Rows)
                            //{
                            //    DataRow dr = TempDT.NewRow();
                            //    for (int j = 0; j < grdCompaireInvoiceStatus.Columns.Count; j++)
                            //    {
                            //        dr["column" + j.ToString()] = row.Cells[j].Value.ToString();
                            //    }
                            //    TempDT.Rows.Add(dr);
                            //}

                        }
                        else
                        {
                            MessageBox.Show("No records found between a select date range in Database. Please try with another Date range", "JTQuickbookCompaire", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No records found between a select date range. Please try with another data range or File", "JTQuickbookCompaire", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MessageBox.Show("No records found in selected file", "JTQuickbookCompaire", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Please select file for invoice compare", "JTQuickbookCompaire", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            SelectedFileName = string.Empty;
            SetSelectedFileName();

            //TempFill();
        }


        

        private void TempFill()
        {
            try
            {
                DataGridViewColumn IN = new DataGridViewTextBoxColumn();
                DataGridViewColumn ID = new DataGridViewTextBoxColumn();
                DataGridViewColumn IA = new DataGridViewTextBoxColumn();
                DataGridViewColumn SD = new DataGridViewTextBoxColumn();

                grdCompaireInvoiceStatus.DataSource = null;

                //IN.HeaderText = "InvoiceNumber";
                //ID.HeaderText = "InvoiceDate";
                //IA.HeaderText = "InvoiceAmount";
                //SD.HeaderText = "Status Description";

                //grdCompaireInvoiceStatus.Columns.Add(IN);
                //grdCompaireInvoiceStatus.Columns.Add(ID);
                //grdCompaireInvoiceStatus.Columns.Add(IA);
                //grdCompaireInvoiceStatus.Columns.Add(SD);

                grdCompaireInvoiceStatus.Rows.Add("19-434-3", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-4", "04-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-5", "05-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-6", "06-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-7", "07-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-8", "08-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-9", "09-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-10", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-11", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-12", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-13", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-14", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-15", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-16", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-17", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-18", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-19", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-20", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-21", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-22", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-23", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-24", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-25", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-26", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-27", "03-03-2021", "200", "Not In JobList");
                grdCompaireInvoiceStatus.Rows.Add("19-434-28", "03-03-2021", "200", "Not In JobList");

               
                for (int i = 0; i < grdCompaireInvoiceStatus.Columns.Count; i++)
                {
                    TempDT.Columns.Add("column" + i.ToString());
                }
                 

                foreach (DataGridViewRow row in grdCompaireInvoiceStatus.Rows)
                {
                    DataRow dr = TempDT.NewRow();
                    for (int j = 0; j < grdCompaireInvoiceStatus.Columns.Count; j++)
                    {
                        dr["column" + j.ToString()] = row.Cells[j].Value .ToString();
                    }
                    TempDT.Rows.Add(dr);
                }



            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
        }

        private void OpenFileDialog1_FileOk(System.Object sender, System.ComponentModel.CancelEventArgs e)
        {
            string filePath = OpenFileDialog1.InitialDirectory + "\\";
            try
            {
                if ((OpenFileDialog1.FileName.LastIndexOf(".") + 1) != 0)
                {
                    System.Diagnostics.Process.Start(OpenFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
        }
        private void JTQBInvCompareSearch_Load(System.Object sender, System.EventArgs e)
        {
            SelectedFileName = string.Empty;
            SetSelectedFileName();
        }
        #endregion

        #region Methods
        public bool GetDateRange(string DataRangeString)
        {
            bool responce = false;
            string[] parts1 = DataRangeString.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            if (parts1.Length == 2)
            {
                string fromDate = parts1[0];
                //string[] parts2 = parts1[1].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                string[] parts2 = parts1[1].Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);

                //if (parts2.Length == 2)
                if (parts2.Length == 1)
                {

                    try
                    {
                        //fromDate = fromDate.Trim() + " " + (parts2[1]).Trim();
                        string[] parts3 = parts2[0].Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                        fromDate = fromDate.Trim() + " " + (parts3[1]).Trim();
                        
                        
                        string parts4 = parts1[0];
                        string[] parts5 = parts4.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);


                        string Todate = (parts5[0]).Trim() + " " + (parts3[0]).Trim() + " " + (parts3[1]).Trim();
                        //string Todate = (parts5[0]).Trim() + " " + (parts2[0]).Trim() ;

                        //string Todate = (fromDate.Trim() + parts2[0]).Trim();


                        System.Globalization.CultureInfo provider = System.Globalization.CultureInfo.InvariantCulture;

                        DateTime DateTo = DateTime.ParseExact(Todate, "MMM d yy", provider);                        
                        DateTime DateFrom = DateTime.ParseExact(fromDate, "MMM d yy", provider);

                        dtpInvoiceTo.Value = DateTo;
                        dtpInvoiceFrom.Value = DateFrom;
                        responce = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                        return false;
                    }
                }
            }

            return responce;
        }
        private DataTable SearchData()
        {
            try
            {
                string Query = null;
                string innerQuerry = string.Empty;

                Query = "select fi.JobNumber, fi.JobTrackDetailID, fi.InvoiceNo, fi.InvoiceDate, fi.Jobdescription, fi.DueDate, fi.invoiceAddress ,fi.PhoneNo, fi.FaxNo, fi.Email, fi.PONo, fi.PaymentCr,  fi.BalanceDue,case when Reinburs.Reimbursement is null then 0 else Reinburs.Reimbursement end as Reimbursement,case when expn.Expense is null then 0 else expn.Expense end as Expense, case  when rev.Total IS NULL  then 0 else rev.Total end as Total,cast( ROUND(( case  when rev.Total IS NULL  then 0 else rev.Total end  + case when expn.Expense is null then 0 else expn.Expense end),2) AS money) as Revenue,fi.CompanyName from" + "(SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate," + "JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo," + "JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue,Company.CompanyName " + "FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON " + "JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0) {0} )  " + "fi left join  (select jt.JobTrackDetailID,SUM(rate.Amount*rate.Hrs) as Reimbursement   from JobTrackInvoiceDetail jt inner join " + "JobTrackInvoiceRateDetail rate on jt.JobTrackDetailID = rate.JobTrackDetailID " + "inner join MasterTrackSubDisplay mstr on rate.TrackSubID = mstr.Id where  mstr.TrackName ='Reinburs;' " + "group by jt.JobTrackDetailID )  Reinburs on fi.JobTrackDetailID = Reinburs.JobTrackDetailID left join " + "         (select SUM(a.Total) as Total,a.JobTrackDetailID from  ( SELECT  SUM(JobTrackInvoiceRateDetail.Hrs *  JobTrackInvoiceRateDetail.Rate) as Total , JobTrackInvoiceDetail.JobTrackDetailID " + "FROM  dbo.JobTrackInvoiceDetail INNER JOIN dbo.JobTrackInvoiceRateDetail  ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.JobTrackInvoiceRateDetail.JobTrackDetailID GROUP BY JobTrackInvoiceDetail.JobTrackDetailID" + " union SELECT    SUM(Time * Rate) AS Revenue,JobTrackInvoiceDetail.JobTrackDetailID             FROM dbo.JobTrackInvoiceDetail " + " INNER JOIN dbo.CRVTimeInvoice ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.CRVTimeInvoice.JobTrackDetailID INNER JOIN dbo.JobList " + " ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID WHERE (dbo.JobTrackInvoiceDetail.JobTrackDetailID IN  (SELECT ISNULL(JobTrackDetailID,0) " + " AS Expr1 FROM dbo.JobTrackInvoiceDetail AS JobTrackInvoiceDetail_1)) GROUP BY JobTrackInvoiceDetail.JobTrackDetailID) a group by a.JobTrackDetailID) rev on fi.JobTrackDetailID = rev.JobTrackDetailID left join " + " (SELECT   sum(Expenses) as Expense,JobTrackDetailID  from CRVExpensesInvoice group by JobTrackDetailID) expn  on fi.JobTrackDetailID = expn.JobTrackDetailID order by fi.JobNumber";

                //                string QueryTest;
                //                QueryTest = "select fi.JobNumber, fi.JobTrackDetailID, fi.InvoiceNo, fi.InvoiceDate, fi.Jobdescription, fi.DueDate, fi.invoiceAddress ,fi.PhoneNo, fi.FaxNo, fi.Email, fi.PONo, fi.PaymentCr,  fi.BalanceDue,case when Reinburs.Reimbursement is null then 0 else Reinburs.Reimbursement end as Reimbursement,case when expn.Expense is null then 0 else expn.Expense end as Expense, case  when rev.Total IS NULL  then 0 else rev.Total end as Total,cast( ROUND(( case  when rev.Total IS NULL  then 0 else rev.Total end  + case when expn.Expense is null then 0 else expn.Expense end),2) AS money) as Revenue,fi.CompanyName from" +
                //            "(SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate," +
                //            "JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo," +
                //            "JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue,Company.CompanyName " +
                //            "FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON " +
                //            "JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0) {0} )  " +
                //            "fi left join  (select jt.JobTrackDetailID,SUM(rate.Amount*rate.Hrs) as Reimbursement   from JobTrackInvoiceDetail jt inner join " +
                //            "JobTrackInvoiceRateDetail rate on jt.JobTrackDetailID = rate.JobTrackDetailID " +
                //            "inner join MasterTrackSubDisplay mstr on rate.TrackSubID = mstr.Id where  mstr.TrackName ='Reinburs;' " +
                //            "group by jt.JobTrackDetailID )  Reinburs on fi.JobTrackDetailID = Reinburs.JobTrackDetailID left join " +
                //            "         (select SUM(a.Total) as Total,a.JobTrackDetailID from  ( SELECT  SUM(JobTrackInvoiceRateDetail.Hrs *  JobTrackInvoiceRateDetail.Rate) as Total , JobTrackInvoiceDetail.JobTrackDetailID " +
                // "FROM  dbo.JobTrackInvoiceDetail INNER JOIN dbo.JobTrackInvoiceRateDetail  ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.JobTrackInvoiceRateDetail.JobTrackDetailID GROUP BY JobTrackInvoiceDetail.JobTrackDetailID" +
                // " union SELECT    SUM(Time * Rate) AS Revenue,JobTrackInvoiceDetail.JobTrackDetailID             FROM dbo.JobTrackInvoiceDetail " +
                // " INNER JOIN dbo.CRVTimeInvoice ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.CRVTimeInvoice.JobTrackDetailID INNER JOIN dbo.JobList " +
                // " ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID WHERE (dbo.JobTrackInvoiceDetail.JobTrackDetailID IN  (SELECT ISNULL(JobTrackDetailID,0) " +
                //" AS Expr1 FROM dbo.JobTrackInvoiceDetail AS JobTrackInvoiceDetail_1)) GROUP BY JobTrackInvoiceDetail.JobTrackDetailID) a group by a.JobTrackDetailID) rev on fi.JobTrackDetailID = rev.JobTrackDetailID left join " +
                //" (SELECT   sum(Expenses) as Expense,JobTrackDetailID  from CRVExpensesInvoice group by JobTrackDetailID) expn  on fi.JobTrackDetailID = expn.JobTrackDetailID order by fi.JobNumber";



                //innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceDate BETWEEN '" + dtpInvoiceFrom.Value.ToString("MM/dd/yyyy") + "' AND '" + dtpInvoiceTo.Value.ToString("MM/dd/yyyy") + "'";

                //string s = dtpInvoiceFrom.Value.ToString();
                //string s2 = dtpInvoiceFrom.Value.ToString("dd/MM/yyyy");
                //string s3 = string.Format(Query, innerQuerry);

                innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceDate BETWEEN '" + dtpInvoiceFrom.Value.ToString("MM/dd/yyyy") + "' AND '" + dtpInvoiceTo.Value.ToString("MM/dd/yyyy") + "'";

                //innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceDate BETWEEN '" +  "' AND '" + dtpInvoiceTo.Value.ToString("MM/dd/yyyy") + "'";


                DataTable dtQB = new DataTable();

                //dtQB = StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));

                

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dtQB = StMethod.GetListDTNew<QBInvCompare>(string.Format(Query, innerQuerry));
                }
                else
                {
                    dtQB = StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));
                }


                //MessageBox.Show(dtQB.Rows.Count.ToString());

                return dtQB;

                //return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return new DataTable();
        }

        private List<JTQuickbookCompaireList> GetInvoiceDataByDateRange()
        {
            List<JTQuickbookCompaireList> ExcelData = new List<JTQuickbookCompaireList>();
            DataTable Dt = SearchData();

            try
            { 
            if (Dt.Rows.Count > 0)
            {
                    //'Total withOut Round Invoice Amount 


                    //ExcelData = (
                    //    from rw in Dt.AsEnumerable()
                    //    select new JTQuickbookCompaireList
                    //    {
                    //        InvoiceAmount = (string.IsNullOrEmpty(Convert.ToString(rw["Revenue"])) ? 0 : Convert.ToDecimal(rw["Revenue"])),
                    //        InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["InvoiceDate"])) ? default(DateTime?) : DateTime.Parse(Convert.ToString(rw["InvoiceDate"]))),
                    //        InvoiceNumber = Convert.ToString(rw["InvoiceNo"])
                    //    }).ToList();

                    DateTime dt;

                    ExcelData = (
                        from rw in Dt.AsEnumerable()
                        select new JTQuickbookCompaireList
                        {
                            InvoiceAmount = (string.IsNullOrEmpty(Convert.ToString(rw["Revenue"])) ? 0 : Convert.ToDecimal(rw["Revenue"])),
                            InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["InvoiceDate"])) ? default(DateTime?) : DateTime.Parse(Convert.ToString(rw["InvoiceDate"]))),
                            InvoiceNumber = Convert.ToString(rw["InvoiceNo"])
                        }).ToList();

                    //MM / dd / yyyy





                    //InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["InvoiceDate"])) ? default(DateTime?) : 
                    //    DateTime.Parse(Convert.ToString(rw["InvoiceDate"]))),


                    //InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["Date"])) ? default(DateTime?) :
                    //DateTime.ParseExact(rw["Date"].ToString(), "MM-dd-yyyy", CultureInfo.InvariantCulture)),


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return ExcelData;
        }
        private bool IsvalidToProcess()
        {
            bool responce = false;

            if (!string.IsNullOrEmpty(SelectedFileName))
            {
                responce = true;
            }

            return responce;
        }
        private List<JTQuickbookCompaireList> GetExcelData(string ExcelFilePath)
        {
            List<JTQuickbookCompaireList> ExcelData = new List<JTQuickbookCompaireList>();
            NPOIUtility.ReadExcelUtility NPOIutiltiyData = new NPOIUtility.ReadExcelUtility();

            List<string> AllColumns = new List<string>();

            AllColumns.Add("Name");
            AllColumns.Add("Num");
            AllColumns.Add("Date");
            AllColumns.Add("Debit");


            //AllColumns.Add("Amount");
            //AllColumns.Add("Num");
            //AllColumns.Add("Date");

            NPOIUtility.NPOIReadResponseResult Responce = NPOIutiltiyData.ReadExcelFile(ExcelFilePath, AllColumns);

            if (Responce.IsError == true && !string.IsNullOrEmpty(Responce.ResponseMessage))
            {
                MessageBox.Show(Responce.ResponseMessage, "JTQuickbookCompaire", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            //'
            //'.InvoiceDate = (CType(rw["Date"), DateTime?)),

            //            If Responce.IsError = False And Responce.ExcelData.Rows.Count > 0 Then
            //            ExcelData = (From rw In Responce.ExcelData.AsEnumerable() Select New JTQuickbookCompaireList With {
            //                         .InvoiceAmount = If(String.IsNullOrEmpty(Convert.ToString(rw("Debit"))), 0, Convert.ToDecimal(rw("Debit"))),
            //                           .InvoiceDate = If(String.IsNullOrEmpty(Convert.ToString(rw("Date"))), CType(Nothing, DateTime ?), DateTime.Parse(Convert.ToString(rw("Date")))),
            //                         .InvoiceNumber = Convert.ToString(rw("Num"))
            //            }).ToList()
            //End If

            

            if (Responce.IsError == false && Responce.ExcelData.Rows.Count > 0)
            {
                ExcelData = (from rw in Responce.ExcelData.AsEnumerable()
                             select new JTQuickbookCompaireList
                             {

                             }).ToList();
            }

            if (Responce.IsError == false && Responce.ExcelData.Rows.Count > 0)
            {
                ExcelData = (
                    from rw in Responce.ExcelData.AsEnumerable()
                      select new JTQuickbookCompaireList
                    {
                        //InvoiceAmount = (string.IsNullOrEmpty(Convert.ToString(rw["Amount"])) ? 0 : Convert.ToDecimal(rw["Amount"])),
                        //InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["Date"])) ? default(DateTime?) : DateTime.Parse(Convert.ToString(rw["Date"]))),
                        //InvoiceNumber = Convert.ToString(rw["Num"])

                        InvoiceAmount = (string.IsNullOrEmpty(Convert.ToString(rw["Debit"])) ? 0 : 
                        Convert.ToDecimal(rw["Debit"])),


                          //InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["Date"])) ? default(DateTime?) : 
                          //DateTime.Parse(Convert.ToString(rw["Date"]))),


                          //// Commented aftrer creating setup
                          //InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["Date"])) ? default(DateTime?) :
                          //DateTime.ParseExact(rw["Date"].ToString(), "MM-dd-yyyy", CultureInfo.InvariantCulture)),


                         InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["Date"])) ? default(DateTime?) : DateTime.Parse(Convert.ToString(rw["Date"]))),

                          //InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["Date"])) ? default(DateTime?) :
                          //DateTime.ParseExact(rw["Date"].ToString(), "MM-dd-yyyy",null)),


                          //InvoiceDate = (string.IsNullOrEmpty(Convert.ToString(rw["Date"])) ? default(DateTime?) :

                          //DateTime.ParseExact(Convert .ToString (rw ["Date"]), "dd\\/ MM\\/ yyyy hh: mm:ss tt",CultureInfo.InvariantCulture)

                          //DateTime.ParseExact(dRow[4].ToString(), "dd\\/MM\\/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                          InvoiceNumber = Convert.ToString(rw["Num"])

                        

                    }).ToList();
            }

      
            return ExcelData;
        }
        #endregion

        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            DataTable table = new DataTable();

            try
            { 


            FieldInfo[] fields = typeof(T).GetFields();
            foreach (FieldInfo field in fields)
            {
                table.Columns.Add(field.Name, field.FieldType);
            }

            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (FieldInfo field in fields)
                {
                    row[field.Name] = field.GetValue(item);
                }

                table.Rows.Add(row);
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return table;
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                //dt.Columns.Add(property.Name, property.PropertyType);

                dt.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);

            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }
   
        //private object CreateExport(DataTable dt, XSSFCellStyle borderedCellStyle2, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)
        //{
        //ICreationHelper creationHelper = workBook.GetCreationHelper();
        private object CreateExport(DataTable dt, HSSFCellStyle borderedCellStyle2, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICreationHelper creationHelper, IDataFormat DataFormat)
        {
            try
            {
                var sheetRow = sheet.CreateRow(sheetRowIndex);
                int ColumnIndex = 0;


                sheetRow = sheet.CreateRow(sheetRowIndex);

                foreach (DataColumn header in dt.Columns)
                {
                    if (sheetRowIndex == 0)
                    {

                      

                        //XSSFCellStyle HeaderBorderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();

                        //HSSFCellStyle HeaderBorderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();

                        //HeaderBorderedCellStyle.SetFont(myFont);

                        //HeaderBorderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                        //HeaderBorderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                        //HeaderBorderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                        //HeaderBorderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                        //HeaderBorderedCellStyle.VerticalAlignment = VerticalAlignment.Center;

                        //ICell Cell1 = sheetRow.CreateCell(0);
                        //Cell1.SetCellValue("InvoiceNumber");
                        //Cell1.CellStyle = HeaderBorderedCellStyle;

                        //ICell Cell2 = sheetRow.CreateCell(1);
                        //Cell2.SetCellValue("InvoiceDate");
                        //Cell2.CellStyle = HeaderBorderedCellStyle;

                        //ICell Cell3 = sheetRow.CreateCell(2);
                        //Cell3.SetCellValue("InvoiceAmount");
                        //Cell3.CellStyle = HeaderBorderedCellStyle;

                        //ICell Cell4 = sheetRow.CreateCell(3);
                        //Cell4.SetCellValue("Status Description");
                        //Cell4.CellStyle = HeaderBorderedCellStyle;

                        //Columnarray[0] = "InvoiceNumber";
                        //Columnarray[1] = "InvoiceDate";
                        //Columnarray[2] = "InvoiceAmount";
                        //Columnarray[3] = "Status Description";

                        //ICell Cell = CurrentRow.CreateCell(CellIndex);
                        //Cell.SetCellValue(Value);
                        //Cell.CellStyle = Style;

                        //sheetRow.CreateCell(0).SetCellValue("CompanyName");
                        //sheetRow.CreateCell(1).SetCellValue("UserID");
                        //sheetRow.CreateCell(2).SetCellValue("Password");                    
                    }
                    else
                    {
                        //XSSFFont myFont2 = (XSSFFont)workBook.CreateFont();

                        //HSSFFont myFont2 = (HSSFFont)workBook.CreateFont();
                         

                        //myFont2.FontHeightInPoints = 10;
                        //myFont2.FontName = "Tahoma";
                        ////myFont2.IsBold = true ;
                        ////myFont2.Color = IndexedColors.Blue.Index;

                        ////XSSFCellStyle HeaderBorderedCellStyle2 = (XSSFCellStyle)workBook.CreateCellStyle();

                        //HSSFCellStyle HeaderBorderedCellStyle2 = (HSSFCellStyle)workBook.CreateCellStyle();

                        //HeaderBorderedCellStyle2.SetFont(myFont2);
                        //HeaderBorderedCellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

                        //HeaderBorderedCellStyle2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                        //HeaderBorderedCellStyle2.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                        //HeaderBorderedCellStyle2.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                        //HeaderBorderedCellStyle2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                        
                        if (ColumnIndex == 0)
                        {
                            string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                            ICell Cell4 = sheetRow.CreateCell(ColumnIndex);

                            int value;
                            if (int.TryParse(dt.Rows[rowindex][ColumnIndex].ToString(), out value))
                            {

                                Cell4.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                                int value5 = int.Parse(columnvalue);
                                Cell4.SetCellValue(value5);
                            }
                            else
                            {
                                Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                                Cell4.SetCellValue(Convert.ToString(columnvalue));

                            }
                            //Cell4.CellStyle = HeaderBorderedCellStyle2;
                            Cell4.CellStyle = borderedCellStyle2;
                        }


                        if (ColumnIndex == 1)
                        {
                            string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                            //ICell Cell5 = sheetRow.CreateCell(ColumnIndex);
                            //Cell5.SetCellType(NPOI.SS.UserModel.CellType.String);
                            //Cell5.SetCellValue(columnvalue);
                            //Cell5.CellStyle = HeaderBorderedCellStyle2;

                            //string columnvalue7 = dt.Rows[rowindex][ColumnIndex].ToString();

                            ICell Cell7 = sheetRow.CreateCell(ColumnIndex);


                            //string filter = columnvalue.ToString();
                            //string[] filterRemove = filter.Split('-');

                            //string Date1 = filterRemove[0];
                            //string Month1 = filterRemove[1];
                            //string TempString = filterRemove[2];

                            //string[] filterRemovePart2 = TempString.Split(' ');

                            ////string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];
                            //string FindalDate = Month1 + "-" + Date1 + "-" + filterRemovePart2[0];

                            //int value7;
                            //if (int.TryParse(FindalDate.ToString (), out value7))
                            //{

                            //    Cell7.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                            //    int value8 = int.Parse(FindalDate);
                            //    Cell7.SetCellValue(value8);
                            //}
                            //else
                            //{
                            //    Cell7.SetCellType(NPOI.SS.UserModel.CellType.String);
                            //    Cell7.SetCellValue(Convert.ToString(FindalDate));

                            //}

                            Cell7.SetCellType(NPOI.SS.UserModel.CellType.String);
                            Cell7.SetCellValue(Convert.ToString(columnvalue));


                            Cell7.CellStyle = borderedCellStyle2;


                            //int value7;
                            //if (int.TryParse(dt.Rows[rowindex][ColumnIndex].ToString(), out value7))
                            //{

                            //    Cell7.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                            //    int value8 = int.Parse(columnvalue);
                            //    Cell7.SetCellValue(value8);
                            //}
                            //else
                            //{
                            //    Cell7.SetCellType(NPOI.SS.UserModel.CellType.String);
                            //    Cell7.SetCellValue(Convert.ToString(columnvalue));

                            //}


                            //Cell7.CellStyle = HeaderBorderedCellStyle2;

                        }


                        if (ColumnIndex == 2)
                        {
                            string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                            ICell Cell6 = sheetRow.CreateCell(ColumnIndex);

                            int value8;

                            if (int.TryParse(columnvalue, out value8))
                            {

                                Cell6.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                                int value5 = int.Parse(columnvalue);
                                Cell6.SetCellValue(value5);
                            }
                            else
                            {
                                //Cell6.SetCellType(NPOI.SS.UserModel.CellType.String);
                                //Cell6.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("####.####");
                                //Cell6.SetCellValue(columnvalue);



                                string Currency = columnvalue;

                                string filter = Currency.ToString();
                                string[] filterRemove = filter.Split('$');
                                string Sign = "$";
                                string Value = filterRemove[0];

                                Double Value2 = Convert.ToDouble(filterRemove[0]);

                                //borderedCellStyle2.DataFormat = creationHelper.CreateDataFormat().GetFormat("$ ##,##0.00");

                                //borderedCellStyle2.DataFormat = creationHelper.CreateDataFormat().GetFormat("####,##0.0000");
                                borderedCellStyle2.DataFormat = creationHelper.CreateDataFormat().GetFormat("$ ####,##0.0000");

                                string FinalValue = Sign.ToString().Trim() + " " + Value.ToString().Trim();

                                Cell6.SetCellValue(Value2);


                                //XSSFWorkbook xSSFWorkbook = new XSSFWorkbook();
                                //CreationHelper createHelper = xSSFWorkbook.getCreationHelper();
                                //XSSFCellStyle numberStyle = xSSFWorkbook.createCellStyle();
                                //numberStyle.setDataFormat(createHelper.createDataFormat().getFormat("###.00"));
                                //double d = 50.0;
                                //XSSFRow dataRow = sheet.createRow(1);
                                //Cellcel1 = dataRow.createCell(1);
                                //cel1.setCellValue(d);


                                //ICreationHelper creationHelper = workBook.GetCreationHelper();
                                //IDataFormat DataFormat = workBook.CreateDataFormat();






                                //Dim cell As HSSFCell = row.CreateCell(j)
                                //Dim d As Double = Convert.ToDouble(dr(col))
                                //cell.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("0.00")


                                //string s = Math.Round(Convert.ToDouble(columnvalue), 2).ToString("00.0000");

                                //Cell6.SetCellValue(s.ToString());

                                //Cell6.SetCellValue(Math.Round(Convert.ToDouble(columnvalue), 2).ToString("00.0000"));

                                //Cell6.SetCellValue(Convert.ToDouble(columnvalue));
                                //Cell6.SetCellValue(Convert.ToDouble(columnvalue));
                                //Cell6.SetCellType(NPOI.SS.UserModel.CellType.String);
                                //double Convert1 = Convert.ToDouble(columnvalue);
                                //double Convert2 = Convert.ToDouble(Math.Round(Convert1, 2));
                                //Cell6.SetCellValue(Convert2.ToString("#.##"));


                                //creationHelper



                            }

                            Cell6.CellStyle = borderedCellStyle2;



                            //Dim Cell As ICell = sheetRow.CreateCell(ColumnIndex)


                            //Cell.SetCellType(NPOI.SS.UserModel.CellType.String)

                            //Dim Currency As String = FormatCurrency(columnvalue, 2)

                            //Dim filter As String = Currency.ToString()
                            //Dim filterRemove() As String = filter.Split("$")

                            //Dim Sign As String = "$"
                            //Dim Value As String = filterRemove(1)
                            //Dim Value2 As Decimal = filterRemove(1)


                            //CellStyle.DataFormat = CreationHelper.CreateDataFormat.GetFormat("$ ##,##0.0000")

                            //Dim FinalValue As String = Sign.ToString().Trim() + " " + Value.ToString().Trim()

                            //Cell.SetCellValue(Value2)
                            //Cell.CellStyle = CellStyle
                        }

                        if (ColumnIndex == 3)
                        {
                            string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                            ICell Cell6 = sheetRow.CreateCell(ColumnIndex);

                            int value2;
                            if (int.TryParse(dt.Rows[rowindex][ColumnIndex].ToString(), out value2))
                            {

                                Cell6.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                                int value5 = int.Parse(columnvalue);
                                Cell6.SetCellValue(value5);
                            }
                            else
                            {
                                Cell6.SetCellType(NPOI.SS.UserModel.CellType.String);
                                Cell6.SetCellValue(Convert.ToString(columnvalue));

                            }
                            //Cell6.CellStyle = HeaderBorderedCellStyle2;
                            Cell6.CellStyle = borderedCellStyle2;
                        }
                    }

                    ColumnIndex = ColumnIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return null;
        }



            private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string titleformname = "JT QB Inv. Search";

                if (grdCompaireInvoiceStatus.Rows.Count > 0)
                {
                    SaveFileDialog Export = new SaveFileDialog();
                    //Export.Filter = "Excel Format|*.xlsx";
                    Export.Filter = "Excel Format|*.xls";

                    Export.Title = titleformname;
                    Export.RestoreDirectory = false;

                    if (Directory.Exists(@"N:\"))
                    {
                        Export.InitialDirectory = "N:";
                    }
                    else
                    {
                        Export.InitialDirectory = "C:";
                    }



                    if (Export.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }

                    string FullFilePath = Export.FileName;
                    string filename = Path.GetFileName(Export.FileName);
                    string filePath = Export.FileName;

                    NPOIExcelUtility NPOIUtlity = new NPOIExcelUtility();
                    // DataTable ExportDataTable = (DataTable)grdCompaireInvoiceStatus.DataSource;

                    //DataTable ExportDataTable = TempDT;
                    DataTable ExportDataTable = new DataTable();

                    //ExportDataTable = FinalResponceData;

                    //ExportDataTable = ToDataTable(FinalResponceData);
                    //ExportDataTable = ConvertToDataTable(FinalResponceData);
                    

                    //MessageBox.Show(ExportDataTable.Rows.Count.ToString());

                    //string[] Columnarray = new string[4];
                    
                    ////IN.HeaderText = "InvoiceNumber";
                    ////ID.HeaderText = "InvoiceDate";
                    ////IA.HeaderText = "InvoiceAmount";
                    ////SD.HeaderText = "Status Description";

                    //Columnarray[0] = "InvoiceNumber";
                    //Columnarray[1] = "InvoiceDate";
                    //Columnarray[2] = "InvoiceAmount";
                    //Columnarray[3] = "Status Description";

                   


                     //private XSSFWorkbook workBook = new XSSFWorkbook();

                    ISheet sheet1 = workBook.CreateSheet(filename);

                    //sheet cell Formatting
                    //--------------------------------------------------------

                    //XSSFFont myFont = (XSSFFont)workBook.CreateFont();
                    HSSFFont myFont = (HSSFFont)workBook.CreateFont();
                     

                    myFont.FontHeightInPoints = 11;
                    myFont.FontName = "Tahoma";
                    //myFont.IsBold = true;


                    //XSSFCellStyle borderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();

                    HSSFCellStyle borderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();

                    



                    borderedCellStyle.SetFont(myFont);

                    borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                    //borderedCellStyle.VerticalAlignment = VerticalAlignment.Bottom;
                    borderedCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

                    //HeaderBorderedCellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

                    Int32 Sheetrowindex = 0;
                    int percent = 0;


                    //XSSFFont myFont = (XSSFFont)workBook.CreateFont();
                    HSSFFont HeaderFont = (HSSFFont)workBook.CreateFont();


                    HeaderFont.FontHeightInPoints = 11;
                    HeaderFont.FontName = "Tahoma";
                    HeaderFont.IsBold = true;
                    HeaderFont.Color = IndexedColors.Blue.Index;

                    //XSSFCellStyle HeaderBorderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();

                    HSSFCellStyle HeaderBorderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();

                    HeaderBorderedCellStyle.SetFont(HeaderFont);

                    HeaderBorderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                    HeaderBorderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                    HeaderBorderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                    HeaderBorderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                    HeaderBorderedCellStyle.VerticalAlignment = VerticalAlignment.Center;


               
                    var sheetRow1 = sheet1.CreateRow(0);
                     
                    ICell Cell1 = sheetRow1.CreateCell(0);
                    Cell1.SetCellValue("InvoiceNumber");
                    Cell1.CellStyle = HeaderBorderedCellStyle;

                    ICell Cell2 = sheetRow1.CreateCell(1);
                    Cell2.SetCellValue("InvoiceDate");
                    Cell2.CellStyle = HeaderBorderedCellStyle;

                    ICell Cell3 = sheetRow1.CreateCell(2);
                    Cell3.SetCellValue("InvoiceAmount");
                    Cell3.CellStyle = HeaderBorderedCellStyle;

                    ICell Cell4 = sheetRow1.CreateCell(3);
                    Cell4.SetCellValue("Status Description");
                    Cell4.CellStyle = HeaderBorderedCellStyle;

                 
                    //ICell Cell = CurrentRow.CreateCell(CellIndex);
                    //Cell.SetCellValue(Value);
                    //Cell.CellStyle = Style;

                    //sheetRow.CreateCell(0).SetCellValue("CompanyName");
                    //sheetRow.CreateCell(1).SetCellValue("UserID");
                    //sheetRow.CreateCell(2).SetCellValue("Password");

                    Sheetrowindex = 1;
                    ICreationHelper creationHelper = workBook.GetCreationHelper();
                    IDataFormat DataFormat = workBook.CreateDataFormat();
                                       
                    


                    //borderedCellStyle


                    for (int ContactRowindex = 1; ContactRowindex <= TempDT.Rows.Count; ContactRowindex++)
                    {
                        //if (ProgressBar1.Value <= MainDataTable.Rows.Count)
                        //{
                        //    CreateContactPassword(MainDataTable, borderedCellStyle, (ContactRowindex - 1),
                        //        ref Sheetrowindex, ref sheet1);
                        //}

                        CreateExport(TempDT, borderedCellStyle, (ContactRowindex - 1),
                            ref Sheetrowindex, ref sheet1, creationHelper, DataFormat);


                        //percent = (ProgressBar1.Value / ProgressBar1.Maximum) * 100;
                        //Label9.Text = percent + "%" + "Completed";
                        //Label9.Refresh();
                        //ProgressBar1.Value = ProgressBar1.Value + 1;
                        //Sheetrowindex = Sheetrowindex + 1;
                    }

                    int lastColumNum = sheet1.GetRow(0).LastCellNum;
                    for (int i = 0; i <= lastColumNum; i++)
                    {
                        sheet1.AutoSizeColumn(i);
                        GC.Collect();
                    }

                    if (sheet1.PhysicalNumberOfRows > 0)
                    {
                        IRow headerRow = sheet1.GetRow(0);
                        //headerRow.Height =100;
                        for (int i = 0, l = headerRow.LastCellNum; i < l; i++)
                        {
                            sheet1.AutoSizeColumn(i);
                            GC.Collect();
                        }
                    }


                    //                    If String.IsNullOrEmpty(xlWorkBook.Path) Then
                    //    xlWorkBook.SaveAs(FilePath, XlFileFormat.xlExcel8)
                    //Else
                    //    xlWorkBook.Save()
                    //End If


                    //XSSFWorkbookType wk = new XSSFWorkbookType();

                    //workBook.WorkbookType = XSSFWorkbookType.XLSX;

                    //export to excel 
                    var fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);                    
                    workBook.Write(fsd);                    
                    workBook.Close();
                    fsd.Close();
                    MessageBox.Show("Export Successfully ", Export.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //NPOIReturnObject response = NPOIUtlity.ExportExcelWithNPOI(TempDT, FullFilePath, titleformname, Columnarray);

                    //NPOIReturnObject response = NPOIUtlity.ExportExcelWithNPOI(ExportDataTable, FullFilePath, titleformname, Columnarray);

                    //if (response.IsConfirmed == true)
                    //{
                    //    MessageBox.Show(response.ResponseMessage, titleformname, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    //else
                    //{
                    //    MessageBox.Show(response.ResponseMessage, titleformname, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //}
                }
                else
                {
                    MessageBox.Show("No Records found for Export. Please try Again!", titleformname, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void JTQBInvCompareSearch_Load_1(object sender, EventArgs e)
        {
            try
            {
                //int Location1 = Panel1.Location.Y;
                //int Location2 = BtnInvoiceSearch.Location.Y;

                //int Difference = Location1 - Location2;
                //int divide2 = Difference / 2;

                //// Set the location of the button
                //BtnExport.Location = new Point(BtnInvoiceSearch.Location.X, 198);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
