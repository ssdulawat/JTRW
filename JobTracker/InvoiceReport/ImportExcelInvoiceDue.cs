using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Application_Tool;
using JobTracker.JobTrackingForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.InvoiceReport
{
    public partial class ImportExcelInvoiceDue : Form
    {
        #region Global Variable
        private bool ProgressStatus;
        private DataTable FileDT = new DataTable();
        private string GetDirectory;
        private string ErrorText;
        bool bFormLoadComplete = false;
        #endregion

        public ImportExcelInvoiceDue()
        {
            InitializeComponent();
        }

        #region Events
        private void ImportExcelInvoiceDue_Load(System.Object sender, System.EventArgs e)
        {
            FileDT.Columns.Add("FileName");
            FileDT.Columns.Add("FileDate");
            FileDT.Columns.Add("DirName");

            GetDirectory = GetAgingFilePath();

            //GetDirectory = @"D:\Aging Testing";

            //N:\VE\QuickBooks\Current Aging


            GetAgingLatestFile();
            bFormLoadComplete = true;
        }
        private void btnImportData_Click()
        {
            try
            {
                if (string.IsNullOrEmpty(txtFilePath.Text.Trim()))
                {
                    return;
                }

                //OleDbConnection ImportCon = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data source='" + txtFilePath.Text.Trim() + "';Extended Properties=Excel 8.0");
                ////Dim ImportCon As New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data source='" & txtFilePath.Text.Trim & "';Extended Properties=Excel 8.0")
                ////Dim ImportCon As New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data source='" & txtFilePath.Text.Trim & "';Jet OLEDB:Database Password=theagereport;Extended Properties='Excel 5.0;HDR=Yes;IMEX=1'")

                //OleDbCommand ImportCmd = new OleDbCommand("select * from [sheet1$]", ImportCon);
                //OleDbDataAdapter ImportAdp = new OleDbDataAdapter(ImportCmd);
                //ImportAdp.TableMappings.Add("Table", "InvoiceDue");
                //DataSet ImportDS = new DataSet();
                //ImportAdp.Fill(ImportDS);
                //grdInvoiceDueData.DataSource = ImportDS.Tables[0];
                //Int64 i = 0;
                //foreach (DataGridViewRow row in grdInvoiceDueData.Rows)
                //{
                //    if (!string.IsNullOrEmpty(grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString()))
                //    {
                //        i = i + 1;
                //    }
                //}
                //lblTotalRecord.Text = i.ToString();



                OleDbConnection ImportCon = new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data source='" + txtFilePath.Text.Trim() + "';Extended Properties=Excel 8.0");

                //OleDbConnection ImportCon = new OleDbConnection("provider=Microsoft.ACE.OLEDB.4.0;Data source='" + txtFilePath.Text.Trim() + "';Extended Properties=Excel 8.0");


                //Dim ImportCon As New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data source='" & txtFilePath.Text.Trim & "';Extended Properties=Excel 8.0")
                //Dim ImportCon As New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data source='" & txtFilePath.Text.Trim & "';Jet OLEDB:Database Password=theagereport;Extended Properties='Excel 5.0;HDR=Yes;IMEX=1'")

                //    If(ImportCon.State = ConnectionState.Closed) Then
                //    ImportCon.Open()
                //End If

                if (ImportCon.State == ConnectionState.Closed)
                {
                    ImportCon.Open();
                }


                //    Dim dtXlsSchema As DataTable
                //dtXlsSchema = ImportCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, _
                //       New Object() { Nothing, Nothing, Nothing, "TABLE"})


                DataTable dtXlsSchema;
                

                dtXlsSchema = ImportCon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] {null,null,null,"TABLE"});


                DataTable dtXlsSchema2;
                dtXlsSchema2 = ImportCon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, null);

                //string Str = Convert.ToString(dtXlsSchema.Rows[0].Item["Table_Name"]).Trim();

                string Str = Convert.ToString(dtXlsSchema.Rows[0]["Table_Name"]).Trim();

                //Dim Str As String = Convert.ToString(dtXlsSchema.Rows(0).Item("Table_Name")).Trim()

                //string Sheet1 = dtXlsSchema.Rows[0].Item["TABLE_NAME"].ToString().Trim();
                string Sheet1 = dtXlsSchema.Rows[0]["TABLE_NAME"].ToString().Trim();

                //Dim SelectQuery As String            
                //SelectQuery = String.Concat("select * from [", Sheet1.ToString.Trim())
                //SelectQuery = String.Concat(SelectQuery, "]")

                string SelectQuery;
                SelectQuery = string.Concat("select * from [", Sheet1.ToString().Trim());
                SelectQuery = string.Concat(SelectQuery , "]");


                //Dim dtXlsSchema2 As DataTable
                //dtXlsSchema2 = ImportCon.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Columns, Nothing)

                OleDbCommand ImportCmd = new OleDbCommand(SelectQuery , ImportCon);
                //OleDbCommand ImportCmd = new OleDbCommand("select * from [sheet1$]", ImportCon);
                OleDbDataAdapter ImportAdp = new OleDbDataAdapter(ImportCmd);
                ImportAdp.TableMappings.Add("Table", "InvoiceDue");
                DataSet ImportDS = new DataSet();
                ImportAdp.Fill(ImportDS);
                grdInvoiceDueData.DataSource = ImportDS.Tables[0];
                Int64 i = 0;

                foreach (DataGridViewRow row in grdInvoiceDueData.Rows)
                {
                    if (!string.IsNullOrEmpty(grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString()))
                    {
                        i = i + 1;
                    }

                    //dr["LastInvoiceDate"] = DateTime.Parse((dr["LastInvoiceDate"].ToString())).ToString("MM/dd/yyyy");

                    //if (!string.IsNullOrEmpty(grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString()))
                    //{
                        
                    //}
                    
                    //dataGrid.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
                }

                //grdInvoiceDueData.Columns["Due Date"].DefaultCellStyle.Format  = "MM/dd/yyyy HH:mm:ss";
                grdInvoiceDueData.Columns["Due Date"].DefaultCellStyle.Format = "MM/dd/yyyy";

                lblTotalRecord.Text = i.ToString();



            }
            catch (System.Data.OleDb.OleDbException oleex)
            {
                DbException _ex = (DbException)oleex;
                if (_ex.ErrorCode == -2147467259)
                {
                    MessageBox.Show("File is already open please close file first then try.", "Excel error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.BeginInvoke(new MethodInvoker(ClosethisForm));
                }
                else
                {
                    KryptonMessageBox.Show("Import Error:-" + _ex.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //'-2147467259

                //'The Microsoft Access database engine cannot open or write to the file
            }
        }

        //Private Sub Browse_Click()
        //    Dim OpenExcel As New OpenFileDialog
        //    OpenExcel.Title = "Invoice Due Aging Excel File"
        //    OpenExcel.Filter = "All Files(*.*)|*.*|(Excel Aging File)|*.xls"
        //    If OpenExcel.ShowDialog() = DialogResult.OK Then
        //        txtFilePath.Text = OpenExcel.FileName
        //    End If
        //End Sub
        private void btnUpdateInvoiceDue_Click(System.Object sender, System.EventArgs e)
        {
            DisAbleControl();
            bgWorkerUpdateAging.RunWorkerAsync();


        }
        private void bgWorkerUpdateAging_DoWork(System.Object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                UpdateAging();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            
        }
        private void bgWorkerUpdateAging_RunWorkerCompleted(System.Object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled || ProgressStatus == false)
            {
                KryptonMessageBox.Show("Update Aging fail", "Update Aging", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableControl();
            }
            else
            {
                KryptonMessageBox.Show("Update Aging successfull", "Update Aging", MessageBoxButtons.OK, MessageBoxIcon.Information);
                EnableControl();
            }
        }
        #endregion

        #region Methods
        public void UpdateAging()
        {
            try
            {
                //Transaction Start Here

                
              


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        using (var dbTransaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                //Update Company aging
                                db.Database.ExecuteSqlCommand("UPDATE Company SET Aging=0,OpeningBalance=0,DueInvoiceNo=0");
                                db.Database.ExecuteSqlCommand("DELETE FROM AgingInvoice");
                                //Dim JobID As Int32 = JobAndTrackingMDI.GetJobID
                                //CompanyID = DAL.ExceuteScaler("SELECT CompanyID FROM Joblist WHERE JoblistID=" & JobID)

                                var CompanyIDs = db.Database.SqlQuery<int>("Select Distinct CompanyID from JobList Where CompanyID in (Select CompanyID From Company)").ToList();
                                foreach (Int32 id in CompanyIDs)
                                {
                                    DataTable AgingOfJobnumber = new DataTable();
                                    var JobNolist = db.Database.SqlQuery<string>("select jobnumber from JobList Where (IsDelete is null or  IsDelete = 0) and  CompanyID=" + id.ToString()).ToList();
                                    DataTable CompanyAgingDT = new DataTable();
                                    CompanyAgingDT.Columns.Add("CompAging");
                                    CompanyAgingDT.Columns.Add("OpenBal");
                                    CompanyAgingDT.Columns.Add("InvoiceNo");
                                    CompanyAgingDT.Columns.Add("DueDate");
                                    //Dim CompanyDatarow As DataRow


                                    foreach (var jobno in JobNolist)
                                    {
                                        DataTable JobMaxAging = new DataTable();
                                        JobMaxAging.Columns.Add("Aging");
                                        JobMaxAging.Columns.Add("Bal");
                                        JobMaxAging.Columns.Add("InvoiceNo");
                                        JobMaxAging.Columns.Add("DueDate");
                                        DataRow TableRow = null;
                                        foreach (DataGridViewRow row in grdInvoiceDueData.Rows)
                                        {

                                            try
                                            {



                                                if (GetJobNumber(grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString()).ToString().Trim() == jobno.Trim())
                                                {
                                                    TableRow = JobMaxAging.NewRow();
                                                    TableRow["Aging"] = grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString();
                                                    TableRow["Bal"] = grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString();
                                                    TableRow["InvoiceNo"] = grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString();
                                                    TableRow["DueDate"] = grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString();
                                                    JobMaxAging.Rows.Add(TableRow);


                                                    string DueDate = string.Empty;
                                                    DueDate = grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString();

                                                    DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));

                                                    //String dy = datevalue.Day.ToString();
                                                    //String mn = datevalue.Month.ToString();
                                                    //String yy = datevalue.Year.ToString();

                                                    //string hh = datevalue.Hour.ToString();
                                                    //string mm = datevalue.Minute.ToString();
                                                    //string ss = datevalue.Second.ToString();



                                                    //string FinalDate = mn + "-" + dy +  "-" + yy;

                                                    //Dim d1 As String = DateTime.Parse(lbltime.Text).ToString("dd/MM/yyyy hh:mm:ss tt")
                                                    string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");


                                                    //grdInvoiceDueData.Columns["Due Date"].DefaultCellStyle.Format = "MM/dd/yyyy";


                                                    string Updatequery = "if (Select COUNT(invoiceagingID) from AgingInvoice Where DueInvoiceNo='" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString().Trim() + "')=0     begin INSERT INTO AgingInvoice(CompanyID,DueInvoiceNo,DueDate,Aging,Balance) VALUES(" + id.ToString() + ",'" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString() + "','" + s1.ToString() + "'," + ReturnAging(grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString()).ToString() + "," + grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString() + ") End    Else    begin UPDATE AgingInvoice SET Aging=" + ReturnAging(grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString()).ToString() + ",DueDate='" + s1.ToString() + "',Balance=" + grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString() + ",CompanyID=" + id.ToString() + " Where DueInvoiceNo='" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString() + "' end";

                                                    //string Updatequery = "if (Select COUNT(invoiceagingID) from AgingInvoice Where DueInvoiceNo='" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString().Trim() + "')=0     begin INSERT INTO AgingInvoice(CompanyID,DueInvoiceNo,DueDate,Aging,Balance) VALUES(" + id.ToString() + ",'" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString() + "','" + grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString() + "'," + ReturnAging(grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString()).ToString() + "," + grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString() + ") End    Else    begin UPDATE AgingInvoice SET Aging=" + ReturnAging(grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString()).ToString() + ",DueDate='" + grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString() + "',Balance=" + grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString() + ",CompanyID=" + id.ToString() + " Where DueInvoiceNo='" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString() + "' end";

                                                    db.Database.ExecuteSqlCommand(Updatequery);
                                                    //DAL.InsertRecord("DELETE FROM AgingInvoice WHERE Aging=0")
                                                    grdInvoiceDueData.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                                                    grdInvoiceDueData.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                                                    // grdInvoiceDueData.Rows.RemoveAt(row.Index)color
                                                }

                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message.ToString());

                                            }
                                        }

                                    }

                                }
                                DataTable UpdateCompanyAging = new DataTable();
                                foreach (Int32 id in CompanyIDs)
                                {
                                    //If CompanyRow.Item("CompanyID").ToString = 4015 Then
                                    //    Dim str As String = CompanyRow.Item("CompanyID").ToString
                                    //End If
                                    var list = db.Database.SqlQuery<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM AgingInvoice Where CompanyID=" + id.ToString() + " And Aging=(SELECT MAX(Aging)from AgingInvoice where CompanyID=" + id.ToString() + " ) order by Dueinvoiceno Asc").ToList();
                                    UpdateCompanyAging = Program.ToDataTable<DueInvoice>(list);
                                    if (UpdateCompanyAging.Rows.Count > 0)
                                    {


                                        string DueDate = string.Empty;
                                        DueDate = UpdateCompanyAging.Rows[0]["DueDate"].ToString();

                                        DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));

                                        string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                                        db.Database.ExecuteSqlCommand("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate='" + s1.ToString() + "' WHERE CompanyID=" + id.ToString());


                                        //db.Database.ExecuteSqlCommand("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate='" + UpdateCompanyAging.Rows[0]["DueDate"].ToString() + "' WHERE CompanyID=" + id.ToString());



                                        LogCompanyAginghistory(id, Convert.ToInt32(UpdateCompanyAging.Rows[0]["Aging"].ToString()));
                                    }
                                    UpdateCompanyAging.Rows.Clear();
                                }
                                //KryptonMessageBox.Show("Update Aging Successfully", "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                ProgressStatus = true;
                                MakeLogfileUpdateAging(txtFilePath.Text);

                                db.SaveChanges();
                                //Transection Commit
                                dbTransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    dbTransaction.Rollback();
                                }
                                catch (SqlException ex1)
                                {
                                    KryptonMessageBox.Show(ex1.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message.ToString());
                                }
                                KryptonMessageBox.Show(ex.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ProgressStatus = false;
                                ErrorText = ex.Message;
                                MakeLogfileUpdateAging(txtFilePath.Text);
                            }
                        }
                    }



                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        using (var dbTransaction = db.Database.BeginTransaction())
                        {
                            try
                            {
                                //Update Company aging
                                db.Database.ExecuteSqlCommand("UPDATE Company SET Aging=0,OpeningBalance=0,DueInvoiceNo=0");
                                db.Database.ExecuteSqlCommand("DELETE FROM AgingInvoice");
                                //Dim JobID As Int32 = JobAndTrackingMDI.GetJobID
                                //CompanyID = DAL.ExceuteScaler("SELECT CompanyID FROM Joblist WHERE JoblistID=" & JobID)

                                var CompanyIDs = db.Database.SqlQuery<int>("Select Distinct CompanyID from JobList Where CompanyID in (Select CompanyID From Company)").ToList();
                                foreach (Int32 id in CompanyIDs)
                                {
                                    DataTable AgingOfJobnumber = new DataTable();
                                    var JobNolist = db.Database.SqlQuery<string>("select jobnumber from JobList Where (IsDelete is null or  IsDelete = 0) and  CompanyID=" + id.ToString()).ToList();
                                    DataTable CompanyAgingDT = new DataTable();
                                    CompanyAgingDT.Columns.Add("CompAging");
                                    CompanyAgingDT.Columns.Add("OpenBal");
                                    CompanyAgingDT.Columns.Add("InvoiceNo");
                                    CompanyAgingDT.Columns.Add("DueDate");
                                    //Dim CompanyDatarow As DataRow


                                    foreach (var jobno in JobNolist)
                                    {
                                        DataTable JobMaxAging = new DataTable();
                                        JobMaxAging.Columns.Add("Aging");
                                        JobMaxAging.Columns.Add("Bal");
                                        JobMaxAging.Columns.Add("InvoiceNo");
                                        JobMaxAging.Columns.Add("DueDate");
                                        DataRow TableRow = null;
                                        foreach (DataGridViewRow row in grdInvoiceDueData.Rows)
                                        {

                                            try
                                            {



                                                if (GetJobNumber(grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString()).ToString().Trim() == jobno.Trim())
                                                {
                                                    TableRow = JobMaxAging.NewRow();
                                                    TableRow["Aging"] = grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString();
                                                    TableRow["Bal"] = grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString();
                                                    TableRow["InvoiceNo"] = grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString();
                                                    TableRow["DueDate"] = grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString();
                                                    JobMaxAging.Rows.Add(TableRow);


                                                    string DueDate = string.Empty;
                                                    DueDate = grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString();

                                                    DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));

                                                    //String dy = datevalue.Day.ToString();
                                                    //String mn = datevalue.Month.ToString();
                                                    //String yy = datevalue.Year.ToString();

                                                    //string hh = datevalue.Hour.ToString();
                                                    //string mm = datevalue.Minute.ToString();
                                                    //string ss = datevalue.Second.ToString();



                                                    //string FinalDate = mn + "-" + dy +  "-" + yy;

                                                    //Dim d1 As String = DateTime.Parse(lbltime.Text).ToString("dd/MM/yyyy hh:mm:ss tt")
                                                    string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");


                                                    //grdInvoiceDueData.Columns["Due Date"].DefaultCellStyle.Format = "MM/dd/yyyy";


                                                    string Updatequery = "if (Select COUNT(invoiceagingID) from AgingInvoice Where DueInvoiceNo='" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString().Trim() + "')=0     begin INSERT INTO AgingInvoice(CompanyID,DueInvoiceNo,DueDate,Aging,Balance) VALUES(" + id.ToString() + ",'" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString() + "','" + s1.ToString() + "'," + ReturnAging(grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString()).ToString() + "," + grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString() + ") End    Else    begin UPDATE AgingInvoice SET Aging=" + ReturnAging(grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString()).ToString() + ",DueDate='" + s1.ToString() + "',Balance=" + grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString() + ",CompanyID=" + id.ToString() + " Where DueInvoiceNo='" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString() + "' end";

                                                    //string Updatequery = "if (Select COUNT(invoiceagingID) from AgingInvoice Where DueInvoiceNo='" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString().Trim() + "')=0     begin INSERT INTO AgingInvoice(CompanyID,DueInvoiceNo,DueDate,Aging,Balance) VALUES(" + id.ToString() + ",'" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString() + "','" + grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString() + "'," + ReturnAging(grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString()).ToString() + "," + grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString() + ") End    Else    begin UPDATE AgingInvoice SET Aging=" + ReturnAging(grdInvoiceDueData.Rows[row.Index].Cells["Aging"].Value.ToString()).ToString() + ",DueDate='" + grdInvoiceDueData.Rows[row.Index].Cells["Due Date"].Value.ToString() + "',Balance=" + grdInvoiceDueData.Rows[row.Index].Cells["Open Balance"].Value.ToString() + ",CompanyID=" + id.ToString() + " Where DueInvoiceNo='" + grdInvoiceDueData.Rows[row.Index].Cells["NUM"].Value.ToString() + "' end";

                                                    db.Database.ExecuteSqlCommand(Updatequery);
                                                    //DAL.InsertRecord("DELETE FROM AgingInvoice WHERE Aging=0")
                                                    grdInvoiceDueData.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                                                    grdInvoiceDueData.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                                                    // grdInvoiceDueData.Rows.RemoveAt(row.Index)color
                                                }

                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show(ex.Message.ToString());

                                            }
                                        }

                                    }

                                }
                                DataTable UpdateCompanyAging = new DataTable();
                                foreach (Int32 id in CompanyIDs)
                                {
                                    //If CompanyRow.Item("CompanyID").ToString = 4015 Then
                                    //    Dim str As String = CompanyRow.Item("CompanyID").ToString
                                    //End If
                                    var list = db.Database.SqlQuery<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM AgingInvoice Where CompanyID=" + id.ToString() + " And Aging=(SELECT MAX(Aging)from AgingInvoice where CompanyID=" + id.ToString() + " ) order by Dueinvoiceno Asc").ToList();
                                    UpdateCompanyAging = Program.ToDataTable<DueInvoice>(list);
                                    if (UpdateCompanyAging.Rows.Count > 0)
                                    {


                                        string DueDate = string.Empty;
                                        DueDate = UpdateCompanyAging.Rows[0]["DueDate"].ToString();

                                        DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));

                                        string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                                        db.Database.ExecuteSqlCommand("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate='" + s1.ToString() + "' WHERE CompanyID=" + id.ToString());


                                        //db.Database.ExecuteSqlCommand("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate='" + UpdateCompanyAging.Rows[0]["DueDate"].ToString() + "' WHERE CompanyID=" + id.ToString());



                                        LogCompanyAginghistory(id, Convert.ToInt32(UpdateCompanyAging.Rows[0]["Aging"].ToString()));
                                    }
                                    UpdateCompanyAging.Rows.Clear();
                                }
                                //KryptonMessageBox.Show("Update Aging Successfully", "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Information)

                                ProgressStatus = true;
                                MakeLogfileUpdateAging(txtFilePath.Text);

                                db.SaveChanges();
                                //Transection Commit
                                dbTransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                try
                                {
                                    dbTransaction.Rollback();
                                }
                                catch (SqlException ex1)
                                {
                                    KryptonMessageBox.Show(ex1.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    MessageBox.Show(ex.Message.ToString());
                                }
                                KryptonMessageBox.Show(ex.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ProgressStatus = false;
                                ErrorText = ex.Message;
                                MakeLogfileUpdateAging(txtFilePath.Text);
                            }
                        }
                    }


                }


                /////// test
                ///
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public int LogCompanyAginghistory(int CompanyID, int Aging)
        {
            try
            {
                //using (EFDbContext db = new EFDbContext())
                //{
                //    string query = "INSERT INTO ColorHistory(CompanyID,Aging,AgingUpdateDate,Userid) VALUES (" + CompanyID + "," + Aging + ", getdate()," + Properties.Settings.Default.timeSheetLoginUserID + ")";
                //    return db.Database.ExecuteSqlCommand(query);
                //}



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        string query = "INSERT INTO ColorHistory(CompanyID,Aging,AgingUpdateDate,Userid) VALUES (" + CompanyID + "," + Aging + ", getdate()," + Properties.Settings.Default.timeSheetLoginUserID + ")";
                        return db.Database.ExecuteSqlCommand(query);
                    }
                    
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        string query = "INSERT INTO ColorHistory(CompanyID,Aging,AgingUpdateDate,Userid) VALUES (" + CompanyID + "," + Aging + ", getdate()," + Properties.Settings.Default.timeSheetLoginUserID + ")";
                        return db.Database.ExecuteSqlCommand(query);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        public string GetJobNumber(string Jobstr)
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
                MessageBox.Show(ex.Message);
            }
            return null;
        }
        private int ReturnAging(string Aging)
        {
            try
            {
                int AgingValue = 0;
                if (string.IsNullOrEmpty(Aging) || string.IsNullOrEmpty(Aging))
                {
                    AgingValue = 0;
                }
                else
                {
                    AgingValue = Convert.ToInt32(Aging);
                }
                return AgingValue;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return 0;
        }
        private void DisAbleControl()
        {
            txtFilePath.Enabled = false;
            //btnBrowse.Enabled = False
            //btnImportData.Enabled = False
            btnUpdateInvoiceDue.Enabled = false;
            grdInvoiceDueData.Enabled = false;
            picBoxProcess.BringToFront();
            picBoxProcess.Visible = true;
            this.WindowState = FormWindowState.Minimized;
        }
        private void EnableControl()
        {
            txtFilePath.Enabled = true;
            //btnBrowse.Enabled = True
            //btnImportData.Enabled = True
            btnUpdateInvoiceDue.Enabled = true;
            grdInvoiceDueData.Enabled = true;
            picBoxProcess.Visible = false;
            picBoxProcess.SendToBack();


            if (Program.CallEmailRemFrm == true)
            {
                Program.ofrmMain.CreateFromandtab(new frmTrafficEmail());
            }

            //If JobAndTrackingMDI.CallEmailRemFrm = True Then
            //    JobAndTrackingMDI.CreateFromandtab(frmTrafficEmail.Instance)
            //End If
            this.WindowState = FormWindowState.Maximized;
            //Me.Close()
        }
        public string GetAgingFilePath()
        {
            try
            {


                //txtFilePath.Text = Dt.Rows[0).Item("FilePath").ToString + "/" + Dt.Rows[0).Item("FileName"].ToString

                //string sRet = StMethod.GetSingle<string>("SELECT FilePath FROM AgingFileInfo");

                string sRet;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    sRet = StMethod.GetSingleNew<string>("SELECT FilePath FROM AgingFileInfo");
                }
                else
                {
                    sRet = StMethod.GetSingle<string>("SELECT FilePath FROM AgingFileInfo");
                }

                return sRet;
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
        private void ClosethisForm()
        {
            Program.ofrmMain.CloseActiveForm(this.Text);
        }
        public void GetAgingLatestFile()
        {
            try
            {
                DirectoryInfo DirInfo = new DirectoryInfo(GetDirectory);
                FileInfo[] AgingFile = DirInfo.GetFiles();

                foreach (FileInfo FA in AgingFile)
                {
                    if (FA.Extension == ".xls")
                    {
                        DataRow dr = FileDT.NewRow();
                        dr["FileName"] = FA.Name;
                        dr["FileDate"] = FA.CreationTimeUtc.ToString("MM/dd/yyyy hh:mm:ss tt");
                        dr["DirName"] = FA.DirectoryName;
                        FileDT.Rows.Add(dr);
                    }
                }
                DataView AgingFileView = FileDT.DefaultView;
                AgingFileView.Sort = "FileDate DESC";
                //FileDT.Clear()
                FileDT = AgingFileView.ToTable();
                AgingFileView.Dispose();
                DataTable DBDt = new DataTable();

                //var data = StMethod.GetList<A_FileInfo>("SELECT FileName,FileDateTime FROM AgingFileInfo");

                var data = StMethod.GetList<A_FileInfo>("SELECT FileName,FileDateTime FROM AgingFileInfo");
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    data = StMethod.GetListNew<A_FileInfo>("SELECT FileName,FileDateTime FROM AgingFileInfo");

                }
                else
                {
                    data = StMethod.GetList<A_FileInfo>("SELECT FileName,FileDateTime FROM AgingFileInfo");
                }

                DBDt = Program.ToDataTable<A_FileInfo>(data);
                
                
                if (string.IsNullOrEmpty(DBDt.Rows[0]["FileName"].ToString()))
                {
                    txtFilePath.Text = FileDT.Rows[0]["DirName"].ToString() + "\\" + FileDT.Rows[0]["FileName"].ToString();
                }
                else if (string.IsNullOrEmpty(DBDt.Rows[0]["FileDateTime"].ToString()))
                {
                    txtFilePath.Text = FileDT.Rows[0]["DirName"].ToString() + "\\" + FileDT.Rows[0]["FileName"].ToString();
                }
                else
                {

                    if (DBDt.Rows[0]["FileName"].ToString().Equals(FileDT.Rows[0]["FileName"].ToString()))
                    {
                        if (Convert.ToDateTime(DBDt.Rows[0]["FileDateTime"].ToString()).Equals(Convert.ToDateTime(FileDT.Rows[0]["FileDate"].ToString())))
                        {
                            if (KryptonMessageBox.Show("New Aging File not available at Location (" + FileDT.Rows[0]["DirName"].ToString() + ")." + "\r\n" + " You want to select a aging file from another location! ", "Update Aging", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                OpenFileDialog OpenExcel = new OpenFileDialog();
                                OpenExcel.Title = "Invoice Due Aging Excel File";
                                OpenExcel.Filter = "All Files(*.*)|*.*|(Excel Aging File)|*.xls";
                                if (OpenExcel.ShowDialog() == DialogResult.OK)
                                {
                                    txtFilePath.Text = OpenExcel.FileName;
                                }
                                else
                                {
                                    //Me.Close()
                                    this.BeginInvoke(new MethodInvoker(ClosethisForm));
                                }
                            }
                            else
                            {
                                //Me.Close()
                                this.BeginInvoke(new MethodInvoker(ClosethisForm));
                            }
                            //Me.Close()
                            this.BeginInvoke(new MethodInvoker(ClosethisForm));
                            return;

                            //' txtFilePath.Text = FileDT.Rows[0]["DirName"].ToString + "\" + FileDT.Rows[0]["FileName"].ToString
                        }
                        else
                        {
                            txtFilePath.Text = FileDT.Rows[0]["DirName"].ToString() + "\\" + FileDT.Rows[0]["FileName"].ToString();
                        }
                    }
                    else
                    {
                        txtFilePath.Text = FileDT.Rows[0]["DirName"].ToString() + "\\" + FileDT.Rows[0]["FileName"].ToString();
                    }

                }
                btnImportData_Click();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                if (!bFormLoadComplete)
                    this.BeginInvoke(new MethodInvoker(ClosethisForm));
            }
        }
        private void MakeLogfileUpdateAging(string Filepath)
        {
            try
            {
                FileInfo AgingFileinfo = new FileInfo(txtFilePath.Text.Trim());


                //using (EFDbContext db = new EFDbContext())
                //{
                //    db.Database.ExecuteSqlCommand("UPDATE AgingFileInfo SET FileName='" + AgingFileinfo.Name + "',FileDateTime='" + AgingFileinfo.CreationTimeUtc + "' WHERE AgingFileId=(SELECT max(AgingFileId) FROM AgingFileInfo) ");
                //    StMethod.LoginActivityInfo(db, "Update", this.Name);
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        db.Database.ExecuteSqlCommand("UPDATE AgingFileInfo SET FileName='" + AgingFileinfo.Name + "',FileDateTime='" + AgingFileinfo.CreationTimeUtc + "' WHERE AgingFileId=(SELECT max(AgingFileId) FROM AgingFileInfo) ");
                        //StMethod.LoginActivityInfo(db, "Update", this.Name);
                        StMethod.LoginActivityInfoNew(db, "Update", this.Name);
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        db.Database.ExecuteSqlCommand("UPDATE AgingFileInfo SET FileName='" + AgingFileinfo.Name + "',FileDateTime='" + AgingFileinfo.CreationTimeUtc + "' WHERE AgingFileId=(SELECT max(AgingFileId) FROM AgingFileInfo) ");
                        StMethod.LoginActivityInfo(db, "Update", this.Name);
                    }
                }

                string LogFilePath = GetDirectory + "\\AgingLogFile.txt";
                FileInfo LogStatus = new FileInfo(LogFilePath);
                if (LogStatus.Exists)
                {
                    FileStream CreateLogFile = new FileStream(LogFilePath, FileMode.Append, FileAccess.Write, FileShare.Read);
                    StreamWriter Writer = new StreamWriter(CreateLogFile);
                    Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    Writer.WriteLine(" Updating Date        :-" + DateTime.Now);
                    Writer.WriteLine(" Aging File Name      :-" + AgingFileinfo.Name);
                    Writer.WriteLine(" Aging File Directory :-" + AgingFileinfo.DirectoryName);
                    Writer.WriteLine(" Machine Name         :-" + Environment.MachineName);
                    Writer.WriteLine(" Error During Update  :-" + ErrorText);
                    Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    Writer.Flush();
                    Writer.Close();
                    CreateLogFile.Close();

                }
                else
                {
                    FileStream CreateLogFile = new FileStream(LogFilePath, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
                    StreamWriter Writer = new StreamWriter(CreateLogFile);
                    Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    Writer.WriteLine("*****************************************Aging Update Log File**************************************************");
                    Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    Writer.WriteLine(" Updating Date        :- " + DateTime.Now);
                    Writer.WriteLine(" Aging File Name      :- " + AgingFileinfo.Name);
                    Writer.WriteLine(" Aging File Directory :- " + AgingFileinfo.DirectoryName);
                    Writer.WriteLine(" Machine Name         :- " + Environment.MachineName);
                    Writer.WriteLine(" Error During Update  :-" + ErrorText);
                    Writer.WriteLine("----------------------------------------------------------------------------------------------------------------");
                    Writer.Flush();
                    Writer.Close();
                    CreateLogFile.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void bgWorkerUpdateAging_DoWork_1(object sender, DoWorkEventArgs e)
        {
            try
            {
                UpdateAging();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void bgWorkerUpdateAging_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Cancelled || ProgressStatus == false)
                {
                    KryptonMessageBox.Show("Update Aging fail", "Update Aging", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EnableControl();
                }
                else
                {
                    KryptonMessageBox.Show("Update Aging successfull", "Update Aging", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EnableControl();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


    }
}