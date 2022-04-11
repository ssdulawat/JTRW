//using Common;
using Commen2;
using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JobTracker.InvoiceReport
{
    public partial class frmInvoiceEditRPT : Form
    {
        #region Declaration
        //private DataAccessLayer DAL;
        private static frmInvoiceEditRPT _Instance;
        //private SqlCommand SqlCmd;
        private long jobID;
        private int compnyId;
        private string typicalInvoiceType;
        //private JobAndTrackingMDI mdio;
        //private SqlConnection Sqlcon = new SqlConnection();
        private BackgroundWorker worker;
        #endregion
        public frmInvoiceEditRPT()
        {
            InitializeComponent();

            worker = new BackgroundWorker();
            worker.DoWork += bw_DoWork;

            // Add any initialization after the InitializeComponent() call.
            fillcmbUserSearch();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        #region Events
        public void CJobTrackRateDetailEdit(Int64 JobListID, string FactorText = "0.00", short Factor = 0)
        {
            DataTable RateDt = new DataTable();
            //Dim Query As String = "SELECT JobTracking.TrackSubID, MasterTrackSubItem.TrackSubName,(case when JobTracking.Comments IS null  then '' else  JobTracking.Comments +',' end)+(case when MasterTrackSubItem.Description IS null  then '' else MasterTrackSubItem.Description  end)+(case when submitted='1/1/1900'or Submitted='12/30/9999'  then '' else ',Submitted='+ CONVERT(varchar(10),submitted,101)end)+(Case when Obtained='1/1/1900' or Obtained='12/30/9999'  then '' else ',Obtained='+ CONVERT(varchar(10),Obtained,101)end)+(case When Expires='12/30/9999' or Expires='1/1/1900' then '' else ',Expires='+ CONVERT(varchar(10),Expires,101)end) as Description, MasterTrackSubItem.nRate,JobTracking.JobTrackingID FROM  JobList INNER JOIN  JobTracking ON JobList.JobListID = JobTracking.JobListID LEFT OUTER JOIN MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id Where joblist.JobListID=" + JobListID.ToString + " AND JobTracking.BillState='Not Invoiced' AND JobTracking.Status<>'Pending' AND (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)"
            // Change on 25-04-2013
            string Query = "SELECT JobTracking.TrackSubID, MasterTrackSubItem.TrackSubName,(CASE WHEN JobTracking.Comments IS NULL THEN '' ELSE JobTracking.Comments + ',' END) + (CASE WHEN MasterTrackSubItem.Description IS NULL THEN '' ELSE MasterTrackSubItem.Description END) + (CASE WHEN submitted = '1/1/1900' OR Submitted = '12/30/9999' THEN '' ELSE ',Submitted=' + CONVERT(varchar(10), submitted, 101) END) + (CASE WHEN Obtained = '1/1/1900' OR         Obtained = '12/30/9999' THEN '' ELSE ',Obtained=' + CONVERT(varchar(10), Obtained, 101) END) + (CASE WHEN Expires = '12/30/9999' OR Expires = '1/1/1900' THEN '' ELSE ',Expires=' + CONVERT(varchar(10), Expires, 101) END) AS Description, dbo.fn_Factor(dbo.GetItemRateJobCompany(JobList.JobListID, JobTracking.TrackSubID,JobTracking.JobTrackingId )," + FactorText + "," + Factor + ") as  nRate, JobTracking.JobTrackingID, JobTracking.TaskHandler, JobTracking.AddDate, JobList.CompanyID, JobTracking.DeleteItemTimeService  FROM  JobList INNER JOIN JobTracking ON JobList.JobListID = JobTracking.JobListID LEFT OUTER JOIN  MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id WHERE (JobList.JobListID = " + JobListID.ToString() + ") AND (JobTracking.BillState = 'Not Invoiced') AND (JobTracking.Status <> 'Pending') AND (JobTracking.IsDelete = 0 OR  JobTracking.IsDelete IS NULL)";
            //JobTracking.InvOvr
            //Chnage on 25-04-2013   MasterTrackSubItem.nRate,
            //Dim Query As String = "SELECT  JobTracking.TrackSubID, MasterTrackSubItem.TrackSubName, (CASE WHEN JobTracking.Comments IS NULL THEN '' ELSE JobTracking.Comments + ',' END) + (CASE WHEN MasterTrackSubItem.Description IS NULL THEN '' ELSE MasterTrackSubItem.Description END) + (CASE WHEN submitted = '1/1/1900' OR Submitted = '12/30/9999' THEN '' ELSE ',Submitted=' + CONVERT(varchar(10), submitted, 101) END) + (CASE WHEN Obtained = '1/1/1900' OR         Obtained = '12/30/9999' THEN '' ELSE ',Obtained=' + CONVERT(varchar(10), Obtained, 101) END) + (CASE WHEN Expires = '12/30/9999' OR Expires = '1/1/1900' THEN '' ELSE ',Expires=' + CONVERT(varchar(10), Expires, 101) END) AS Description, MasterTrackSubItem.nRate,dbo.GetRate(JobList.CompanyID, JobTracking.TrackSubID) as  Rate, JobTracking.JobTrackingID, JobTracking.TaskHandler, JobTracking.AddDate, JobList.CompanyID FROM  JobList INNER JOIN JobTracking ON JobList.JobListID = JobTracking.JobListID LEFT OUTER JOIN  MasterTrackSubItem ON JobTracking.TrackSubID = MasterTrackSubItem.Id WHERE (JobList.JobListID = 2758) AND (JobTracking.BillState = 'Not Invoiced') AND (JobTracking.Status <> 'Pending') AND (JobTracking.IsDelete = 0 OR  JobTracking.IsDelete IS NULL)"

            try
            {
                //RateDt = StMethod.GetListDT<TrackRateDetail>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    RateDt = StMethod.GetListDTNew<TrackRateDetail>(Query);
                }
                else
                {
                    RateDt = StMethod.GetListDT<TrackRateDetail>(Query);
                }

                DataColumn HrsCol = new DataColumn(); //Manulay added 4 column
                DataColumn DateCol = new DataColumn();
                //  Dim QtyCol As New DataColumn
                DataColumn AmountCol = new DataColumn();
                DataColumn ByCol = new DataColumn();
                HrsCol.ColumnName = "Hrs";
                // DateCol.ColumnName = "Date"
                // QtyCol.ColumnName = "Qty"
                //  ByCol.ColumnName = "By"
                AmountCol.ColumnName = "Amount";

                RateDt.Columns.Add(HrsCol);
                // RateDt.Columns.Add(DateCol)
                //  RateDt.Columns.Add(QtyCol)
                RateDt.Columns.Add(AmountCol);
                //  RateDt.Columns.Add(ByCol)

                for (Int32 i = 0; i < RateDt.Rows.Count; i++)
                {
                    // RateDt.Rows[i).Item("nRate") = "1.00"
                    RateDt.Rows[i]["Hrs"] = "1.00";
                }

                grdRateDetail.DataSource = RateDt;
                grdRateDetail.AllowUserToResizeRows = true;
                grdRateDetail.Columns["TrackSubName"].HeaderText = "Item";
                grdRateDetail.Columns["TrackSubName"].Width = 200;
                grdRateDetail.Columns["TrackSubName"].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
                grdRateDetail.Columns["Description"].HeaderText = "Description";
                grdRateDetail.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
                grdRateDetail.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdRateDetail.Columns["nRate"].HeaderText = "Rate";

                grdRateDetail.Columns["TaskHandler"].DisplayIndex = 1;
                grdRateDetail.Columns["AddDate"].DisplayIndex = 2;
                grdRateDetail.Columns["TrackSubName"].DisplayIndex = 3;
                grdRateDetail.Columns["Description"].DisplayIndex = 4;
                grdRateDetail.Columns["nRate"].DisplayIndex = 6;
                grdRateDetail.Columns["Hrs"].DisplayIndex = 7;

                grdRateDetail.Columns["Amount"].DisplayIndex = 8;
                grdRateDetail.Columns["TaskHandler"].HeaderText = "By";
                grdRateDetail.Columns["AddDate"].HeaderText = "Date";
                grdRateDetail.Columns["Hrs"].Width = 80;
                grdRateDetail.Columns["Hrs"].HeaderText = "Qty";
                // 
                grdRateDetail.Columns["nRate"].Width = 80;
                grdRateDetail.Columns["TrackSubID"].Visible = false;
                grdRateDetail.Columns["JobTrackingID"].Visible = false;
                grdRateDetail.Columns["CompanyID"].Visible = false;
                grdRateDetail.Columns["DeleteItemTimeService"].Visible = false;
                string StrNew = null;
                for (int i = 0; i < grdRateDetail.Rows.Count; i++)
                {
                    string Str = grdRateDetail.Rows[i].Cells["Description"].Value.ToString();
                    if (Str[Str.Length - 1].ToString() == ",")
                    {
                        Str = Str.Remove(Str.Length - 1, 1);
                    }
                    if (Str.IndexOf(",") == 0 || Str.IndexOf(",") == 1)
                    {
                        Str = Str.Remove(Str.IndexOf(","), 1);
                    }
                    grdRateDetail.Rows[i].Cells["Description"].Value = Str;
                    StrNew = string.Empty;
                }
                //GetAmountFromDescription(Factor)

                //For i As Integer = 0 To grdRateDetail.Rows.Count - 1
                //    TotalAmount = TotalAmount + (Val(grdRateDetail.Rows[i].Cells["nRate"].Value.ToString) * Val(grdRateDetail.Rows[i].Cells["Hrs"].Value.ToString))
                //Next

                for (int i = 0; i < grdRateDetail.Rows.Count; i++)
                {
                    if (grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString() == "")
                    {
                        grdRateDetail.Rows[i].Cells["nRate"].Value = "1.00";
                    }
                    double rate = Convert.ToDouble( grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue);
                    double Qty = Convert.ToDouble(grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue);
                    grdRateDetail.Rows[i].Cells["Amount"].Value = Convert.ToDouble(grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue) * Convert.ToDouble(grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue);
                    grdRateDetail.Rows[i].Cells["Hrs"].Value = Qty.ToString();
                    grdRateDetail.Rows[i].Cells["nRate"].Value = Convert.ToDecimal(rate.ToString());
                }
                CountTotalAmount();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Job DesCri4ption Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmInvoiceEditRPT_Load(System.Object sender, System.EventArgs e)
        {
            if (Program.getRptStatus == 'N')
            {
                CJobTrackDetailEdit(Program.GetJobID);
                CJobTrackRateDetailEdit(Program.GetJobID);
            }
            // fillLisiVewItem()
            UserSettingEditInvoice();
            fillgrvExpenses();
            fillgrvTime();
            lblTotalExpenses.Visible = false;
            lblTotalTime.Visible = false;
            LoadCheckBox();
            CheckApplyWhenTimeServiceFeeThere();
        }
        private void btnCreateVriFyInvoice_Click(System.Object sender, System.EventArgs e)
        {


            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                

                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    using (var dbTransaction = db.Database.BeginTransaction())
                    {
                        try
                        {
                            //MessageBox.Show("1");

                            if (Program.ofrmMain.IsFormAlreadyOpen("ReportInvoiceForm"))
                            {
                                KryptonMessageBox.Show("Report Viewer form already open. First close and then proceed.", "Create invoice report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (Program.getRptStatus == 'N') //'Change JobAndTrackingMDI as Mdio on 17/10/2013
                            {
                                if (KryptonMessageBox.Show("You sure want to proceed Next!", "Create Invoice Report", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    //SaveNewRptInvoiceDetail(db);
                                    SaveNewRptInvoiceDetailNew(db);

                                    //MessageBox.Show("2");

                                    bool flag = true;
                                    if (ckbItem.Checked == true && ckbTime.Checked == true && ckbExpenses.Checked == false)
                                    {
                                        //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                        //    UpdateConvertInvoiceItem()  'change by convert time sheet
                                        //    UpdateConvertInvoiceTime()
                                        //Else
                                        //    UpdateInvoiceItem()
                                        //    UpdateInvoiceTime()
                                        //End If

                                        //MessageBox.Show("3");

                                        UpdateInvoiceItemNew(db);

                                        //MessageBox.Show("4");

                                        UpdateInvoiceTimeNew(db);

                                        //MessageBox.Show("5");

                                        SaveNewRptInvoiceRatedetailNew(db);

                                        //MessageBox.Show("6");

                                        SaveNewTimeReportNew(db);
                                        flag = false;

                                        //MessageBox.Show("7");

                                    }

                                    if (ckbItem.Checked == true && ckbExpenses.Checked == true && ckbTime.Checked == false)
                                    {
                                        //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                        //    UpdateConvertInvoiceItem()  'change by convert time sheet
                                        //    UpdateConvertInvoiceExpenses()
                                        //Else
                                        //    UpdateInvoiceItem()
                                        //    UpdateInvoiceExpenses()
                                        //End If
                                        UpdateInvoiceItemNew(db);
                                        
                                        UpdateInvoiceExpensesNew(db);
                                        SaveNewRptInvoiceRatedetailNew(db);
                                        SaveNewExpensesReportNew(db);
                                        flag = false;
                                    }
                                    if (ckbTime.Checked == true && ckbExpenses.Checked == true && ckbItem.Checked == false)
                                    {
                                        //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                        //    UpdateConvertInvoiceTime()  'change by convert time sheet
                                        //    UpdateConvertInvoiceExpenses()
                                        //Else
                                        //    UpdateInvoiceTime()
                                        //    UpdateInvoiceExpenses()
                                        //End If
                                        UpdateInvoiceTimeNew(db);
                                        UpdateInvoiceExpensesNew(db);
                                        SaveNewTimeReportNew(db);
                                        SaveNewExpensesReportNew(db);
                                        flag = false;
                                    }
                                    if (ckbTime.Checked == true && ckbExpenses.Checked == true && ckbItem.Checked == true)
                                    {
                                        SaveNewRptInvoiceRatedetailNew(db);
                                        SaveNewTimeReportNew(db);
                                        SaveNewExpensesReportNew(db);
                                        //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                        //    UpdateConvertInvoiceTime()  'change by convert time sheet
                                        //    UpdateConvertInvoiceExpenses()
                                        //    UpdateConvertInvoiceItem()
                                        //Else
                                        //    UpdateInvoiceTime()
                                        //    UpdateInvoiceExpenses()
                                        //    UpdateInvoiceItem()
                                        //End If
                                        UpdateInvoiceTimeNew(db);
                                        UpdateInvoiceExpensesNew(db);
                                        UpdateInvoiceItemNew(db);
                                        flag = false;
                                    }
                                    if (chkAll.Checked == true)
                                    {
                                        //SaveNewRptInvoiceRatedetail()
                                        //SaveNewTimeReport()
                                        //SaveNewExpensesReport()

                                    }
                                    else
                                    {
                                        if (flag == true)
                                        {


                                            if (ckbItem.Checked)
                                            {
                                                //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                                //    UpdateConvertInvoiceItem()  'change by convert time sheet
                                                //Else
                                                //    UpdateInvoiceItem()
                                                //End If
                                                UpdateInvoiceItemNew(db);
                                                SaveNewRptInvoiceRatedetailNew(db);

                                            }
                                            if (ckbTime.Checked)
                                            {
                                                //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                                //    UpdateConvertInvoiceTime()  'change by convert time sheet
                                                //Else
                                                //    UpdateInvoiceTime()
                                                //End If
                                                UpdateInvoiceTimeNew(db);
                                                SaveNewTimeReportNew(db);
                                            }

                                            if (ckbExpenses.Checked)
                                            {
                                                //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                                //    UpdateConvertInvoiceExpenses()  'change by convert time sheet
                                                //Else
                                                //    UpdateInvoiceExpenses()
                                                //End If
                                                UpdateInvoiceExpensesNew(db);
                                                SaveNewExpensesReportNew(db);
                                            }
                                        }
                                    }


                                    dbTransaction.Commit();
                                    Program.InvoiceItem = ckbItem.Checked; //Change by 11/10/2013
                                    Program.InvoiceTime = ckbTime.Checked;
                                    Program.InvoiceExpenses = ckbExpenses.Checked;
                                    Program.InvoiceAll = chkAll.Checked;
                                    Program.InvoiceReportFlag = flag;

                                    //Try



                                    //'If chkAll.Checked = True Then
                                    //'    SaveNewRptInvoiceRatedetail()
                                    //'    SaveNewTimeReport()
                                    //'    SaveNewExpensesReport()
                                    //'Else
                                    //'    If ckbItem.Checked Then
                                    //'        SaveNewRptInvoiceRatedetail()
                                    //'    End If
                                    //'    If ckbTime.Checked Then
                                    //'        SaveNewTimeReport()
                                    //'    End If

                                    //'    If ckbExpenses.Checked Then
                                    //'        SaveNewExpensesReport()
                                    //'    End If
                                    //'End If

                                    //'JobAndTrackingMDI.InvoiceItem = ckbItem.Checked
                                    //'JobAndTrackingMDI.InvoiceTime = ckbTime.Checked
                                    //'JobAndTrackingMDI.InvoiceExpenses = ckbExpenses.Checked
                                    //'JobAndTrackingMDI.InvoiceAll = chkAll.Checked
                                    //'Try
                                    //'    For Each row As DataGridViewRow In grdRateDetail.Rows
                                    //'        Dim Query As String = "UPDATE JobTracking Set BillState='Invoiced',IsChange=1 WHERE JobListID=" & JobAndTrackingMDI.GetJobID & " AND BillState='Not Invoiced' AND JobTrackingID=" & grdRateDetail.Rows[row.Index].Cells["JobTrackingID"].Value.ToString
                                    //'        DAL = New DataAccessLayer
                                    //'        DAL.InsertRecord(Query)
                                    //'        DAL.LoginActivityInfo("Update", Me.Name)
                                    //'    Next
                                    //'Catch ex As Exception
                                    //'End Try
                                    //'Try
                                    //'    For TimeRow As Integer = 0 To grvTime.Rows.Count - 1
                                    //'        Dim queryTime As String = "UPDATE    TS_Time SET  BillState ='Invoice' where TimeSheetID= " & grvTime.Rows[TimeRow].Cells["TimeSheetID"].Value.ToString & ""
                                    //'        DAL = New DataAccessLayer
                                    //'        DAL.InsertRecord(queryTime)
                                    //'    Next

                                    //'    For ExpRow As Integer = 0 To grvExpenses.Rows.Count - 1
                                    //'        Dim queryExp As String = "UPDATE    TS_Expences SET  BillState ='Invoice' where  TimeSheetExpencesID= " & grvExpenses.Rows[ExpRow].Cells["TimeSheetExpencesID"].Value.ToString & ""
                                    //'        DAL = New DataAccessLayer
                                    //'        DAL.InsertRecord(queryExp)
                                    //'    Next

                                    //'Catch ex As Exception

                                    //'End Try

                                    btnCreateVriFyInvoice.Enabled = false;

                                    //RptInvoiceView rptInvoiceView = new RptInvoiceView();
                                    //rptInvoiceView.ChkTime = true;

                                    //Dim mdio As JobAndTrackingMDI
                                    //mdio = Me.MdiParent


                                    Program.ofrmMain.CreateFromandtab(new RptInvoiceView());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //dbTransaction.Rollback();

                            MessageBox.Show(ex.Message.ToString());
                            KryptonMessageBox.Show("Something went wrong, please try to create invoice again.", "Invoice");
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
                            //MessageBox.Show("1");

                            if (Program.ofrmMain.IsFormAlreadyOpen("ReportInvoiceForm"))
                            {
                                KryptonMessageBox.Show("Report Viewer form already open. First close and then proceed.", "Create invoice report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            if (Program.getRptStatus == 'N') //'Change JobAndTrackingMDI as Mdio on 17/10/2013
                            {
                                if (KryptonMessageBox.Show("You sure want to proceed Next!", "Create Invoice Report", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                                {
                                    SaveNewRptInvoiceDetail(db);


                                    //MessageBox.Show("2");

                                    bool flag = true;
                                    if (ckbItem.Checked == true && ckbTime.Checked == true && ckbExpenses.Checked == false)
                                    {
                                        //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                        //    UpdateConvertInvoiceItem()  'change by convert time sheet
                                        //    UpdateConvertInvoiceTime()
                                        //Else
                                        //    UpdateInvoiceItem()
                                        //    UpdateInvoiceTime()
                                        //End If

                                        //MessageBox.Show("3");

                                        UpdateInvoiceItem(db);

                                        //MessageBox.Show("4");

                                        UpdateInvoiceTime(db);

                                        //MessageBox.Show("5");

                                        SaveNewRptInvoiceRatedetail(db);

                                        //MessageBox.Show("6");

                                        SaveNewTimeReport(db);
                                        flag = false;

                                        //MessageBox.Show("7");

                                    }

                                    if (ckbItem.Checked == true && ckbExpenses.Checked == true && ckbTime.Checked == false)
                                    {
                                        //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                        //    UpdateConvertInvoiceItem()  'change by convert time sheet
                                        //    UpdateConvertInvoiceExpenses()
                                        //Else
                                        //    UpdateInvoiceItem()
                                        //    UpdateInvoiceExpenses()
                                        //End If
                                        UpdateInvoiceItem(db);
                                        UpdateInvoiceExpenses(db);
                                        SaveNewRptInvoiceRatedetail(db);
                                        SaveNewExpensesReport(db);
                                        flag = false;
                                    }
                                    if (ckbTime.Checked == true && ckbExpenses.Checked == true && ckbItem.Checked == false)
                                    {
                                        //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                        //    UpdateConvertInvoiceTime()  'change by convert time sheet
                                        //    UpdateConvertInvoiceExpenses()
                                        //Else
                                        //    UpdateInvoiceTime()
                                        //    UpdateInvoiceExpenses()
                                        //End If
                                        UpdateInvoiceTime(db);
                                        UpdateInvoiceExpenses(db);
                                        SaveNewTimeReport(db);
                                        SaveNewExpensesReport(db);
                                        flag = false;
                                    }
                                    if (ckbTime.Checked == true && ckbExpenses.Checked == true && ckbItem.Checked == true)
                                    {
                                        SaveNewRptInvoiceRatedetail(db);
                                        SaveNewTimeReport(db);
                                        SaveNewExpensesReport(db);
                                        //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                        //    UpdateConvertInvoiceTime()  'change by convert time sheet
                                        //    UpdateConvertInvoiceExpenses()
                                        //    UpdateConvertInvoiceItem()
                                        //Else
                                        //    UpdateInvoiceTime()
                                        //    UpdateInvoiceExpenses()
                                        //    UpdateInvoiceItem()
                                        //End If
                                        UpdateInvoiceTime(db);
                                        UpdateInvoiceExpenses(db);
                                        UpdateInvoiceItem(db);
                                        flag = false;
                                    }
                                    if (chkAll.Checked == true)
                                    {
                                        //SaveNewRptInvoiceRatedetail()
                                        //SaveNewTimeReport()
                                        //SaveNewExpensesReport()

                                    }
                                    else
                                    {
                                        if (flag == true)
                                        {


                                            if (ckbItem.Checked)
                                            {
                                                //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                                //    UpdateConvertInvoiceItem()  'change by convert time sheet
                                                //Else
                                                //    UpdateInvoiceItem()
                                                //End If
                                                UpdateInvoiceItem(db);
                                                SaveNewRptInvoiceRatedetail(db);

                                            }
                                            if (ckbTime.Checked)
                                            {
                                                //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                                //    UpdateConvertInvoiceTime()  'change by convert time sheet
                                                //Else
                                                //    UpdateInvoiceTime()
                                                //End If
                                                UpdateInvoiceTime(db);
                                                SaveNewTimeReport(db);
                                            }

                                            if (ckbExpenses.Checked)
                                            {
                                                //If (chkConvertTimeSheet.CheckState = CheckState.Checked And cmbConvertTimeSheet.Text.Trim() <> String.Empty) Then
                                                //    UpdateConvertInvoiceExpenses()  'change by convert time sheet
                                                //Else
                                                //    UpdateInvoiceExpenses()
                                                //End If
                                                UpdateInvoiceExpenses(db);
                                                SaveNewExpensesReport(db);
                                            }
                                        }
                                    }


                                    dbTransaction.Commit();
                                    Program.InvoiceItem = ckbItem.Checked; //Change by 11/10/2013
                                    Program.InvoiceTime = ckbTime.Checked;
                                    Program.InvoiceExpenses = ckbExpenses.Checked;
                                    Program.InvoiceAll = chkAll.Checked;
                                    Program.InvoiceReportFlag = flag;

                                    //Try



                                    //'If chkAll.Checked = True Then
                                    //'    SaveNewRptInvoiceRatedetail()
                                    //'    SaveNewTimeReport()
                                    //'    SaveNewExpensesReport()
                                    //'Else
                                    //'    If ckbItem.Checked Then
                                    //'        SaveNewRptInvoiceRatedetail()
                                    //'    End If
                                    //'    If ckbTime.Checked Then
                                    //'        SaveNewTimeReport()
                                    //'    End If

                                    //'    If ckbExpenses.Checked Then
                                    //'        SaveNewExpensesReport()
                                    //'    End If
                                    //'End If

                                    //'JobAndTrackingMDI.InvoiceItem = ckbItem.Checked
                                    //'JobAndTrackingMDI.InvoiceTime = ckbTime.Checked
                                    //'JobAndTrackingMDI.InvoiceExpenses = ckbExpenses.Checked
                                    //'JobAndTrackingMDI.InvoiceAll = chkAll.Checked
                                    //'Try
                                    //'    For Each row As DataGridViewRow In grdRateDetail.Rows
                                    //'        Dim Query As String = "UPDATE JobTracking Set BillState='Invoiced',IsChange=1 WHERE JobListID=" & JobAndTrackingMDI.GetJobID & " AND BillState='Not Invoiced' AND JobTrackingID=" & grdRateDetail.Rows[row.Index].Cells["JobTrackingID"].Value.ToString
                                    //'        DAL = New DataAccessLayer
                                    //'        DAL.InsertRecord(Query)
                                    //'        DAL.LoginActivityInfo("Update", Me.Name)
                                    //'    Next
                                    //'Catch ex As Exception
                                    //'End Try
                                    //'Try
                                    //'    For TimeRow As Integer = 0 To grvTime.Rows.Count - 1
                                    //'        Dim queryTime As String = "UPDATE    TS_Time SET  BillState ='Invoice' where TimeSheetID= " & grvTime.Rows[TimeRow].Cells["TimeSheetID"].Value.ToString & ""
                                    //'        DAL = New DataAccessLayer
                                    //'        DAL.InsertRecord(queryTime)
                                    //'    Next

                                    //'    For ExpRow As Integer = 0 To grvExpenses.Rows.Count - 1
                                    //'        Dim queryExp As String = "UPDATE    TS_Expences SET  BillState ='Invoice' where  TimeSheetExpencesID= " & grvExpenses.Rows[ExpRow].Cells["TimeSheetExpencesID"].Value.ToString & ""
                                    //'        DAL = New DataAccessLayer
                                    //'        DAL.InsertRecord(queryExp)
                                    //'    Next

                                    //'Catch ex As Exception

                                    //'End Try

                                    btnCreateVriFyInvoice.Enabled = false;

                                    //RptInvoiceView rptInvoiceView = new RptInvoiceView();
                                    //rptInvoiceView.ChkTime = true;

                                    //Dim mdio As JobAndTrackingMDI
                                    //mdio = Me.MdiParent


                                    Program.ofrmMain.CreateFromandtab(new RptInvoiceView());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //dbTransaction.Rollback();

                            MessageBox.Show(ex.Message.ToString());
                            KryptonMessageBox.Show("Something went wrong, please try to create invoice again.", "Invoice");
                        }
                    }
                }

            }
        }


        //
        private void btnInvoicePreview_Click(System.Object sender, System.EventArgs e)
        {
            //For Each RptFrm As Form In Application.OpenForms
            //    If RptFrm.Text = RptInvoiceView.Text Then
            //        KryptonMessageBox.Show("Report Viewer form already open. First close and then procceed.", "Create invoice report", MessageBoxButtons.OK, MessageBoxIcon.Information)
            //        Exit Sub
            //    End If
            //Next
            //JobAndTrackingMDI.CreateFromandtab(RptInvoiceView.Instance)

        }

        private void grdRateDetail_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {

                //Dim TotalAmount As Decimal
                //For i As Integer = 0 To grdRateDetail.Rows.Count - 1
                //    TotalAmount = TotalAmount + (Val(grdRateDetail.Rows[i].Cells["nRate"].Value.ToString) * Val(grdRateDetail.Rows[i].Cells["Hrs"].Value.ToString))
                //Next

                //lblTotalAmount.Text = "Total Amount:- $" + Convert.ToString(TotalAmount)

            }
            catch (Exception ex)
            {

            }
        }

        private void grdRateDetail_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    grdRateDetail.Rows.RemoveAt(e.RowIndex);

                    //Dim TotalAmount As Decimal
                    //'For i As Integer = 0 To grdRateDetail.Rows.Count - 1
                    //'    TotalAmount = TotalAmount + (Val(grdRateDetail.Rows[i].Cells["nRate"].Value.ToString) * Val(grdRateDetail.Rows[i].Cells["Hrs"].Value.ToString))
                    //'Next

                    //lblTotalAmount.Text = "Total Amount:- $" + Convert.ToString(TotalAmount)
                }
                catch (Exception ex)
                {

                }
            }
            try
            {
                if (e.ColumnIndex == 4 || e.ColumnIndex == 9 && e.RowIndex > -1)
                {

                    double rate =(double) grdRateDetail.Rows[e.RowIndex].Cells["nRate"].EditedFormattedValue;
                    double Qty = (double)grdRateDetail.Rows[e.RowIndex].Cells["Hrs"].EditedFormattedValue;
                    grdRateDetail.Rows[e.RowIndex].Cells["Amount"].Value =(double) grdRateDetail.Rows[e.RowIndex].Cells["nRate"].EditedFormattedValue * Convert.ToDouble(grdRateDetail.Rows[e.RowIndex].Cells["Hrs"].EditedFormattedValue);
                    grdRateDetail.Rows[e.RowIndex].Cells["Hrs"].Value = Qty.ToString();
                    grdRateDetail.Rows[e.RowIndex].Cells["nRate"].Value = Convert.ToDecimal(rate.ToString());
                    decimal TotalAmount = 0M;
                    for (int i = 0; i < grdRateDetail.Rows.Count; i++)
                    {
                        TotalAmount = Convert.ToDecimal((double)TotalAmount + (NumericHelper.Val(grdRateDetail.Rows[i].Cells["nRate"].Value.ToString()) * NumericHelper.Val(grdRateDetail.Rows[i].Cells["Hrs"].Value.ToString())));
                    }

                    lblTotalAmount.Text = "Total Amount:- $" + Convert.ToString(Math.Round(TotalAmount));
                }
            }
            catch (Exception ex)
            {

            }

        }

        private void grdRateDetail_EditingControlShowing(System.Object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == 2)
            {
                grdRateDetail.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                grdRateDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
        }

        private void btnShowInvoice_Click(System.Object sender, System.EventArgs e)
        {
            frmShowInvoice frmInvoice = new frmShowInvoice();
            frmInvoice.JobID = Program.GetJobID;
            frmInvoice.Show();
        }

        private void btnInvoicelist_Click(System.Object sender, System.EventArgs e)
        {
            //With ProgressBar1
            //    .Style = ProgressBarStyle.Marquee
            //    .Step = 1
            //    .Minimum = 0
            //    .Maximum = 100
            //    .Value = 20
            //    .Visible = True
            //End With
            try
            {
                frmInvoiceList frmlist = new frmInvoiceList();
                frmlist.CompnyID = compnyId;
                //ProgressBar1.Value = 50
                frmlist.Show();
                //ProgressBar1.Value = 80

            }
            catch (Exception ex)
            {

                //Finally
                //    ProgressBar1.Value = 100
                //    ProgressBar1.Visible = False
            }


        }
        private void tbcEditReportItem_Click(System.Object sender, System.EventArgs e)
        {
            if (tbcEditReportItem.SelectedTab.Text == "Item")
            {
                lblTotalExpenses.Visible = false;
                lblTotalTime.Visible = false;

            }
            if (tbcEditReportItem.SelectedTab.Text == "Time")
            {
                lblTotalExpenses.Visible = false;
                lblTotalTime.Visible = true;

            }
            if (tbcEditReportItem.SelectedTab.Text == "Expenses")
            {
                lblTotalTime.Visible = false;
                lblTotalExpenses.Visible = true;

            }
        }

        private void grvTime_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    grvTime.Rows.RemoveAt(e.RowIndex);
                    double totalTime = 0;
                    for (int i = 0; i < grvTime.Rows.Count; i++)
                    {
                        totalTime = totalTime + Convert.ToDouble(grvTime.Rows[i].Cells["Amount"].Value.ToString());
                    }
                    lblTotalTime.Text = "Total Time :" + Math.Round(totalTime);
                }
                catch (Exception ex)
                {

                }
            }
            if (e.ColumnIndex == 8 || e.ColumnIndex == 9 && e.RowIndex > -1)
            {
                try
                {
                    double rate =(double) grvTime.Rows[e.RowIndex].Cells["Rate"].EditedFormattedValue;
                    double Qty =(double) grvTime.Rows[e.RowIndex].Cells["Qty"].EditedFormattedValue;
                    grvTime.Rows[e.RowIndex].Cells["Amount"].Value = Convert.ToDouble(grvTime.Rows[e.RowIndex].Cells["Rate"].EditedFormattedValue )* Convert.ToDouble(grvTime.Rows[e.RowIndex].Cells["Qty"].EditedFormattedValue);

                    double totalTime = 0;
                    for (int i = 0; i < grvTime.Rows.Count; i++)
                    {
                        totalTime = totalTime + Convert.ToDouble(grvTime.Rows[i].Cells["Amount"].Value.ToString());
                    }
                    lblTotalTime.Text = "Total Time :" + Math.Round(totalTime);
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void grvExpenses_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //Try
            //    If e.ColumnIndex = 8 Or e.ColumnIndex = 9 And e.RowIndex > -1 Then

            //        Dim rate As Double = grvExpenses.Rows[e.RowIndex].Cells["Rate"].EditedFormattedValue
            //        Dim Qty As Double = grvExpenses.Rows[e.RowIndex].Cells["Qty"].EditedFormattedValue
            //        grvExpenses.Rows[e.RowIndex].Cells["Amount"].Value = grvExpenses.Rows[e.RowIndex].Cells["Rate"].EditedFormattedValue * Convert.ToDouble(grvExpenses.Rows[e.RowIndex].Cells["Qty"].EditedFormattedValue)
            //        grvExpenses.Rows[e.RowIndex].Cells["Qty"].Value = Qty.ToString()
            //        grvExpenses.Rows[e.RowIndex].Cells["Rate"].Value = Convert.ToDecimal(rate.ToString())
            //        Dim totalExpenses As Double
            //        For i As Integer = 0 To grvExpenses.Rows.Count - 1
            //            totalExpenses = totalExpenses + Convert.ToDouble(grvExpenses.Rows[i].Cells["Amount"].EditedFormattedValue)
            //        Next
            //        lblTotalExpenses.Text = "Total Amount $:" & totalExpenses
            //    End If
            //Catch ex As Exception

            //End Try

            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    grvExpenses.Rows.RemoveAt(e.RowIndex);
                    double totalExpenses = 0;
                    for (int i = 0; i < grvExpenses.Rows.Count; i++)
                    {
                        totalExpenses = totalExpenses + Convert.ToDouble(grvExpenses.Rows[i].Cells["Amount"].Value.ToString());
                    }
                    lblTotalExpenses.Text = "Total Amount $:" + Math.Round(totalExpenses);
                }
                catch (Exception ex)
                {

                    throw ex;

                }
            }
        }

        private void grdRateDetail_CellLeave(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4 || e.ColumnIndex == 9 && e.RowIndex > -1)
                {

                    double rate =(double) grdRateDetail.Rows[e.RowIndex].Cells["nRate"].EditedFormattedValue;
                    double Qty =(double) grdRateDetail.Rows[e.RowIndex].Cells["Hrs"].EditedFormattedValue;
                    grdRateDetail.Rows[e.RowIndex].Cells["Amount"].Value = Convert.ToDouble(grdRateDetail.Rows[e.RowIndex].Cells["nRate"].EditedFormattedValue) * Convert.ToDouble(grdRateDetail.Rows[e.RowIndex].Cells["Hrs"].EditedFormattedValue);
                    grdRateDetail.Rows[e.RowIndex].Cells["Hrs"].Value = Qty.ToString();
                    grdRateDetail.Rows[e.RowIndex].Cells["nRate"].Value = Convert.ToDecimal(rate.ToString());
                    decimal TotalAmount = 0M;
                    for (int i = 0; i < grdRateDetail.Rows.Count; i++)
                    {
                        TotalAmount = Convert.ToDecimal((double)TotalAmount + (NumericHelper.Val(grdRateDetail.Rows[i].Cells["nRate"].Value.ToString()) * NumericHelper.Val(grdRateDetail.Rows[i].Cells["Hrs"].Value.ToString())));
                    }

                    lblTotalAmount.Text = "Total Amount:- $" + Convert.ToString(Math.Round(TotalAmount));
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void chkAll_Click(System.Object sender, System.EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                ckbExpenses.Checked = false;
                ckbItem.Checked = false;
                ckbTime.Checked = false;

            }
            else
            {
                ckbExpenses.Checked = false;
                ckbItem.Checked = true;
                ckbTime.Checked = false;
            }

        }

        private void grvTime_CellLeave(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 || e.ColumnIndex == 9 && e.RowIndex > -1)
            {
                try
                {
                    double rate =(double) grvTime.Rows[e.RowIndex].Cells["Rate"].EditedFormattedValue;
                    double Qty =(double) grvTime.Rows[e.RowIndex].Cells["Qty"].EditedFormattedValue;
                    grvTime.Rows[e.RowIndex].Cells["Amount"].Value = Convert.ToDouble(grvTime.Rows[e.RowIndex].Cells["Rate"].EditedFormattedValue )* Convert.ToDouble(grvTime.Rows[e.RowIndex].Cells["Qty"].EditedFormattedValue);

                    double totalTime = 0;
                    for (int i = 0; i < grvTime.Rows.Count; i++)
                    {
                        totalTime = totalTime + Convert.ToDouble(grvTime.Rows[i].Cells["Amount"].Value.ToString());
                    }
                    lblTotalTime.Text = "Total Time :" + Math.Round(totalTime);
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void tbcEditReportItem_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (tbcEditReportItem.SelectedTab.Text == tbTime.Text)
                {

                    GbSearchTrackSub.Visible = true;
                }
                else
                {
                    GbSearchTrackSub.Visible = false;
                    txtSearchTrackSubComment.Text = "";
                }
                CheckApplyWhenTimeServiceFeeThere();
            }
            catch (Exception ex)
            {

            }
        }

        private void txtSearchTrackSubComment_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                fillgrvTime();
            }
            catch (Exception ex)
            {

            }
        }

        //Private Sub chkConvertTimeSheet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConvertTimeSheet.CheckedChanged

        //    Try
        //        If chkConvertTimeSheet.Checked = True Then

        //            cmbConvertTimeSheet.Enabled = True
        //        Else
        //            cmbConvertTimeSheet.Enabled = False

        //        End If
        //    Catch ex As Exception

        //    End Try

        //End Sub

        private void frmInvoiceEditRPT_FormClosed(System.Object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.Dispose(false);
        }
        private void ckbSearchTime_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (ckbSearchTime.Checked == true)
                {
                    gbDateUserSearch.Enabled = true;
                }
                else
                {
                    gbDateUserSearch.Enabled = false;

                }
                fillgrvTime();
            }
            catch (Exception ex)
            {

            }
        }
        private void txtDescriptionSearchJob_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                fillgrvTime();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSearchUserClear_Click(System.Object sender, System.EventArgs e)
        {

            try
            {
                txtSearchTrackSubComment.Text = "";
                txtDescription.Text = "";
                cmbUserSearch.Text = "";
                ckbSearchTime.Checked = false;
                gbDateUserSearch.Enabled = false;
                fillgrvTime();
            }
            catch (Exception ex)
            {

            }
        }

        private void cmbUserSearch_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                fillgrvTime();
            }
            catch (Exception ex)
            {

            }
        }

        private void dtpDateSearchFrom_ValueChanged(System.Object sender, System.EventArgs e)
        {
            dtpDateSearchTo.ValueChanged -= this.dtpDateSearchTo_ValueChanged;
            try
            {
                dtpDateSearchTo.Text = dtpDateSearchFrom.Text;
                fillgrvTime();
                dtpDateSearchTo.ValueChanged += this.dtpDateSearchTo_ValueChanged;
            }
            catch (Exception ex)
            {

            }
        }

        private void dtpDateSearchTo_ValueChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                fillgrvTime();
            }
            catch (Exception ex)
            {

            }
        }

        private void btnReduction_Click(System.Object sender, System.EventArgs e)
        {
            // Dim mdio = Me.MdiParent
            //CJobTrackRateDetailEdit(mdio.GetJobID, txtReduction.Value, CInt(ckbItem.CheckState Or chkAll.CheckState))
            fillgrvExpenses(1);

        }
        private void btnTimeReduction_Click(System.Object sender, System.EventArgs e)
        {
            //Dim mdio = Me.MdiParent
            //'CJobTrackRateDetailEdit(mdio.GetJobID, txtTimeReduction.Value, CInt(ckbItem.CheckState Or chkAll.CheckState))
            fillgrvTime(1);
        }

        private void btnItemReduction_Click(System.Object sender, System.EventArgs e)
        {
            CJobTrackRateDetailEdit(Program.GetJobID, txtItemFactor.Value.ToString(), 1);
        }

        private void CheckApplyWhenTimeServiceFeeThere()
        {
            //TrackSubName
            if ((grdRateDetail.Rows.OfType<DataGridViewRow>().Any((f) => f.Cells["TrackSubName"].Value.ToString().Contains("TimeServiceFee"))) && (typicalInvoiceType == "Item" | string.IsNullOrEmpty(typicalInvoiceType)))
            {
                ckbItem.Checked = true;
                ckbTime.Checked = true;
                ckbExpenses.Checked = true;
                GbSearchTrackSub.Enabled = false;
                btnTimeReduction.Enabled = false;
                txtTimeFactor.Enabled = false;
            }
            else if (typicalInvoiceType == "Item" | string.IsNullOrEmpty(typicalInvoiceType))
            {
                ckbItem.Checked = true;
                ckbTime.Checked = false;
                ckbExpenses.Checked = true;
            }
            else if (typicalInvoiceType == "Time")
            {
                ckbItem.Checked = true;
                ckbTime.Checked = true;
                ckbExpenses.Checked = true;
            }
            else
            {
                GbSearchTrackSub.Enabled = true;
            }
        }
        #endregion

        #region Methods
        public void CJobTrackDetailEdit(long JobListId)
        {
            try
            {

                string Query;
                //Query = "SELECT JobList.JobNumber, JobList.Description,JobList.Clienttext, JobList.Address AS JobAddress, JobList.Borough, JobList.Handler,JobList.CompanyID, Company.CompanyName, Company.Address AS CompanyAddress, Contacts.WorkPhone, Contacts.FaxNumber, Contacts.EmailAddress,Company.City, Company.State, Company.PostalCode, Company.Country, Company.TypicalInvoiceType FROM  JobList INNER JOIN Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN         Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE  JobListID =" & JobListId

                //"(CASE WHEN JobList.InvoiceACContacts IS NOT NULL ANd JobList.InvoiceACContacts<>'' THEN dbo.fn_GetContactDetailsByContactIDNew(JobList.InvoiceACContacts,'ContactName') WHEN JobList.InvoiceContact IS NOT NULL And JobList.InvoiceContact<>'' THEN  dbo.fn_GetContactDetailsByContactIDNew(JobList.InvoiceContact,'ContactName') WHEN JobList.ACContacts IS NOT NULL AND JobList.ACContacts<>'' THEN JobList.ACContacts WHEN JobList.ContactsID IS NOT NULL And JobList.ContactsID<>'' THEN  dbo.fn_GetContactDetailsByContactIDNew(JobList.ContactsID,'ContactName') ELSE '' END )ContactsName," & _

                //"(CASE WHEN JobList.InvoiceACContacts IS NOT NULL ANd JobList.InvoiceACContacts<>'' THEN dbo.fn_GetContactDetailsByContactIDNew(JobList.InvoiceACContacts,'Address') WHEN JobList.InvoiceContact IS NOT NULL And JobList.InvoiceContact<>'' THEN  dbo.fn_GetContactDetailsByContactIDNew(JobList.InvoiceContact,'Address') WHEN JobList.ACContacts IS NOT NULL AND JobList.ACContacts<>'' THEN  dbo.fn_GetContactDetailsByContactIDNew((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'Address') WHEN JobList.ContactsID IS NOT NULL And JobList.ContactsID<>'' THEN  dbo.fn_GetContactDetailsByContactIDNew(JobList.ContactsID,'Address') ELSE '' END )ContactsAddress," & _

                //            Query = "SELECT JobList.JobNumber, JobList.Description,JobList.Clienttext, JobList.Address AS JobAddress, JobList.Borough, JobList.Handler,JobList.CompanyID," & _
                //                "(CASE WHEN Isnull(JobList.InvoiceACContacts,'') <>'' and (select dbo.fn_IsEmptyContactsAddress(JobList.InvoiceACContacts))>0  THEN dbo.fn_GetContactDetailsByJobListContactID(JobList.InvoiceACContacts,'Address' ,JobList.CompanyID) WHEN ISNULL(JobList.InvoiceContact,'')<>'' and (select dbo.fn_IsEmptyContactsAddress(JobList.InvoiceContact))>0 THEN  dbo.fn_GetContactDetailsByJobListContactID(JobList.InvoiceContact,'Address' ,JobList.CompanyID) WHEN  ISNULL(JobList.ACContacts,'') <>'' and (select dbo.fn_IsEmptyContactsAddress((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID)))>0 THEN  dbo.fn_GetContactDetailsByJobListContactID((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'Address' ,JobList.CompanyID) WHEN ISNUll(JobList.ContactsID,0) <> 0 and (select dbo.fn_IsEmptyContactsAddress(JobList.ContactsID))>0 THEN  dbo.fn_GetContactDetailsByJobListContactID(JobList.ContactsID,'Address' ,JobList.CompanyID) ELSE '' END )ContactsAddress," & _
                //                  "(CASE WHEN Isnull(JobList.InvoiceACContacts,'') <>'' THEN dbo.fn_GetContactDetailsByJobListContactID(JobList.InvoiceACContacts,'FaxNumber', default) WHEN ISNULL(JobList.InvoiceContact,'')<>'' THEN  dbo.fn_GetContactDetailsByJobListContactID(JobList.InvoiceContact,'FaxNumber', default) WHEN ISNULL(JobList.ACContacts,'') <>'' THEN  dbo.fn_GetContactDetailsByJobListContactID((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'FaxNumber', default) WHEN ISNUll(JobList.ContactsID,0) <>0 THEN  dbo.fn_GetContactDetailsByJobListContactID(JobList.ContactsID,'FaxNumber', default) ELSE '' END )ContactsFaxNumber," & _
                //                   "(CASE WHEN Isnull(JobList.InvoiceACContacts,'') <>'' THEN dbo.fn_GetContactDetailsByJobListContactID(JobList.InvoiceACContacts,'WorkPhone', default) WHEN ISNULL(JobList.InvoiceContact,'')<>'' THEN  dbo.fn_GetContactDetailsByJobListContactID(JobList.InvoiceContact,'WorkPhone', default) WHEN ISNULL(JobList.ACContacts,'') <>'' THEN  dbo.fn_GetContactDetailsByJobListContactID((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'WorkPhone', default) WHEN ISNUll(JobList.ContactsID,0) <>0 THEN  dbo.fn_GetContactDetailsByJobListContactID(JobList.ContactsID,'WorkPhone', default) ELSE '' END )ContactsWorkPhone," & _
                //                    "(coalesce(dbo.fn_GetContactDetailsByJobListContactID(JobList.InvoiceACContacts,'ContactEmail', default), ', ') + ',' + coalesce(dbo.fn_GetContactDetailsByJobListContactID(JobList.InvoiceContact,'ContactEmail', default), ', ') +  ',' +  coalesce( dbo.fn_GetContactDetailsByJobListContactID((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'ContactEmail', default),'') +  ',' +  coalesce(dbo.fn_GetContactDetailsByJobListContactID(JobList.ContactsID,'ContactEmail', default), ', ') )As AllContactsEmail," & _
                //"(CASE WHEN c.CompanyName<>''AND c.CompanyName IS NOT NULL THEN c.CompanyName ELSE Company.CompanyName END)CompanyName," & _
                // "Company.Address AS CompanyAddress, (CASE WHEN JobList.InvoiceContact IS NOT NULL AND JobList.InvoiceContact<>'' THEN (SELECT top 1 WorkPhone FROM Contacts WHERE ContactsID LIKE JobList.InvoiceContact) ELSE Contacts.WorkPhone END) AS WorkPhone, Contacts.FaxNumber, (CASE WHEN JobList.InvoiceEmailAddress<>''AND JobList.InvoiceEmailAddress IS NOT NULL THEN JobList.InvoiceEmailAddress ELSE  Contacts.EmailAddress END)EmailAddress,Company.City, Company.State, Company.PostalCode, Company.Country, (CASE WHEN JobList.TypicalInvoiceType IS NULL OR JobList.TypicalInvoiceType='' THEN  Company.TypicalInvoiceType ELSE JobList.TypicalInvoiceType END) AS TypicalInvoiceType   FROM  JobList INNER JOIN Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN   Contacts ON JobList.ContactsID = Contacts.ContactsID  LEFT JOIN Company c on JobList.InvoiceClient=c.CompanyId WHERE  JobListID=" & JobListId

                Query = "SELECT JobList.JobNumber, JobList.Description,JobList.Clienttext, JobList.Address AS JobAddress, JobList.Borough, JobList.Handler,JobList.CompanyID," + "(CASE WHEN Isnull(JobList.InvoiceACContacts,'') <>'' THEN dbo.fn_GetContactDetailsByJobContactID(JobList.InvoiceACContacts,'Address' ,JobList.CompanyID) WHEN ISNULL(JobList.InvoiceContact,'')<>''  THEN  dbo.fn_GetContactDetailsByJobContactID(JobList.InvoiceContact,'Address' ,JobList.CompanyID) WHEN  ISNULL(JobList.ACContacts,'') <>'' THEN  dbo.fn_GetContactDetailsByJobContactID((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'Address' ,JobList.CompanyID) WHEN ISNUll(JobList.ContactsID,0) <> 0 THEN  dbo.fn_GetContactDetailsByJobContactID(JobList.ContactsID,'Address' ,JobList.CompanyID) ELSE '' END )ContactsAddress," + "(CASE WHEN Isnull(JobList.InvoiceACContacts,'') <>'' THEN dbo.fn_GetContactDetailsByJobContactID(JobList.InvoiceACContacts,'FaxNumber', default) WHEN ISNULL(JobList.InvoiceContact,'')<>'' THEN  dbo.fn_GetContactDetailsByJobContactID(JobList.InvoiceContact,'FaxNumber', default) WHEN ISNULL(JobList.ACContacts,'') <>'' THEN  dbo.fn_GetContactDetailsByJobContactID((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'FaxNumber', default) WHEN ISNUll(JobList.ContactsID,0) <>0 THEN  dbo.fn_GetContactDetailsByJobContactID(JobList.ContactsID,'FaxNumber', default) ELSE '' END )ContactsFaxNumber," + "(CASE WHEN Isnull(JobList.InvoiceACContacts,'') <>'' THEN dbo.fn_GetContactDetailsByJobContactID(JobList.InvoiceACContacts,'WorkPhone', default) WHEN ISNULL(JobList.InvoiceContact,'')<>'' THEN  dbo.fn_GetContactDetailsByJobContactID(JobList.InvoiceContact,'WorkPhone', default) WHEN ISNULL(JobList.ACContacts,'') <>'' THEN  dbo.fn_GetContactDetailsByJobContactID((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'WorkPhone', default) WHEN ISNUll(JobList.ContactsID,0) <>0 THEN  dbo.fn_GetContactDetailsByJobContactID(JobList.ContactsID,'WorkPhone', default) ELSE '' END )ContactsWorkPhone," + "(coalesce(dbo.fn_GetContactDetailsByJobContactID(JobList.InvoiceACContacts,'ContactEmail', default), ', ') + ',' + coalesce(dbo.fn_GetContactDetailsByJobContactID(JobList.InvoiceContact,'ContactEmail', default), ', ') +  ',' +  coalesce( dbo.fn_GetContactDetailsByJobContactID((select top 1 isnull(ContactsID,0)  from contacts where (JobList.ACContacts like '%' + rtrim(ltrim(contacts.FirstName)) + '%' and JobList.ACContacts like '%' + rtrim(ltrim(contacts.MiddleName))  + '%' and  JobList.ACContacts like '%' + rtrim(ltrim(contacts.LastName))  + '%') and CompanyID = JobList.CompanyID),'ContactEmail', default),'') +  ',' +  coalesce(dbo.fn_GetContactDetailsByJobContactID(JobList.ContactsID,'ContactEmail', default), ', ') )As AllContactsEmail," + "(CASE WHEN c.CompanyName<>''AND c.CompanyName IS NOT NULL THEN c.CompanyName ELSE Company.CompanyName END)CompanyName," + "Company.Address AS CompanyAddress, (CASE WHEN JobList.InvoiceContact IS NOT NULL AND JobList.InvoiceContact<>'' THEN (SELECT top 1 WorkPhone FROM Contacts WHERE ContactsID LIKE JobList.InvoiceContact) ELSE Contacts.WorkPhone END) AS WorkPhone, Contacts.FaxNumber, (CASE WHEN JobList.InvoiceEmailAddress<>''AND JobList.InvoiceEmailAddress IS NOT NULL THEN JobList.InvoiceEmailAddress ELSE  Contacts.EmailAddress END)EmailAddress,Company.City, Company.State, Company.PostalCode, Company.Country, (CASE WHEN JobList.TypicalInvoiceType IS NULL OR JobList.TypicalInvoiceType='' THEN  Company.TypicalInvoiceType ELSE JobList.TypicalInvoiceType END) AS TypicalInvoiceType   FROM  JobList INNER JOIN Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN   Contacts ON JobList.ContactsID = Contacts.ContactsID  LEFT JOIN Company c on JobList.InvoiceClient=c.CompanyId WHERE  JobListID=" + JobListId;

                jobID = JobListId;
                string Jobdescrption = null;
                
                
                DataTable Dt = new DataTable();
                
                //Dt = StMethod.GetListDT<JobClients>(Query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    Dt = StMethod.GetListDTNew<JobClients>(Query);
                }
                else
                {
                    Dt = StMethod.GetListDT<JobClients>(Query);
                }

                if (Dt.Rows.Count > 0)
                {
                    //If Dt.Rows[0).Item("CompanyName").ToString = String.Empty Then
                    //    descrption = String.Empty
                    //Else
                    //    descrption = Dt.Rows[0).Item("").ToString & ","
                    //End If
                    if (string.IsNullOrEmpty(Dt.Rows[0]["JobAddress"].ToString()))
                    {
                        Jobdescrption = string.Empty;
                    }
                    else
                    {
                        Jobdescrption = Dt.Rows[0]["JobAddress"].ToString() + ",";
                    }
                    if (string.IsNullOrEmpty(Dt.Rows[0]["Borough"].ToString()))
                    {
                        Jobdescrption = Jobdescrption + string.Empty;
                    }
                    else
                    {
                        Jobdescrption = Jobdescrption + " " + Dt.Rows[0]["Borough"].ToString() + ";";
                    }
                    if (string.IsNullOrEmpty(Dt.Rows[0]["Description"].ToString()))
                    {
                        Jobdescrption = Jobdescrption + string.Empty;
                    }
                    else
                    {
                        Jobdescrption = Jobdescrption + " " + Dt.Rows[0]["Description"].ToString() + " by";
                    }
                    if (string.IsNullOrEmpty(Dt.Rows[0]["Handler"].ToString()))
                    {
                        Jobdescrption = Jobdescrption + string.Empty;
                    }
                    else
                    {
                        Jobdescrption = Jobdescrption + " " + Dt.Rows[0]["Handler"].ToString();
                    }
                }
                else
                {
                    Jobdescrption = "";
                }
                compnyId =Convert.ToInt32( Dt.Rows[0]["CompanyID"]);
                txtInvoiceNo.Text = Dt.Rows[0]["JobNumber"].ToString();
                txtJobDescription.Text = Jobdescrption;
                txtJobNumber.Text = Dt.Rows[0]["JobNumber"].ToString();


                if (string.IsNullOrEmpty(Dt.Rows[0]["ContactsAddress"].ToString()))
                {
                    //txtAddress.Text = Dt.Rows[0).Item("CompanyName").ToString & vbCrLf & Dt.Rows[0).Item("CompanyAddress").ToString & vbCrLf & Dt.Rows[0).Item("City").ToString + ", " + Dt.Rows[0).Item("State").ToString + " " + Dt.Rows[0).Item("PostalCode").ToString & vbCrLf & Dt.Rows[0).Item("Country").ToString
                    txtAddress.Text = Dt.Rows[0]["CompanyName"].ToString() + GetNewLine(Dt.Rows[0]["CompanyName"].ToString(), string.Empty) + Dt.Rows[0]["CompanyAddress"].ToString() + GetNewLine(Dt.Rows[0]["CompanyAddress"].ToString(), string.Empty) + Dt.Rows[0]["City"].ToString() + GetNewLine(Dt.Rows[0]["City"].ToString(), ", ") + Dt.Rows[0]["State"].ToString() + GetNewLine(Dt.Rows[0]["State"].ToString(), " ") + Dt.Rows[0]["PostalCode"].ToString() + GetNewLine(Dt.Rows[0]["PostalCode"].ToString(), " ") + Dt.Rows[0]["Country"].ToString();
                }
                else
                {
                    //txtAddress.Text = Dt.Rows[0).Item("ContactsAddress").ToString.Replace("NEWLINETEXT", Environment.NewLine)
                    txtAddress.Text = Dt.Rows[0]["ContactsAddress"].ToString().Replace("NEWLINETEXT", Environment.NewLine) + GetNewLine(Dt.Rows[0]["ContactsAddress"].ToString().Replace("NEWLINETEXT", Environment.NewLine), string.Empty) + Dt.Rows[0]["CompanyAddress"].ToString() + GetNewLine(Dt.Rows[0]["CompanyAddress"].ToString(), string.Empty) + Dt.Rows[0]["City"].ToString() + GetNewLine(Dt.Rows[0]["City"].ToString(), ", ") + Dt.Rows[0]["State"].ToString() + GetNewLine(Dt.Rows[0]["State"].ToString(), " ") + Dt.Rows[0]["PostalCode"].ToString() + GetNewLine(Dt.Rows[0]["PostalCode"].ToString(), " ") + Dt.Rows[0]["Country"].ToString();
                }
                //txtEmailAddress.Text = Dt.Rows[0).Item("EmailAddress").ToString
                txtEmailAddress.Text = RemoveEmptyStr(Dt.Rows[0]["AllContactsEmail"].ToString());
                txtFaxNo.Text = Dt.Rows[0]["ContactsFaxNumber"].ToString();
                txtphoneNo.Text = Dt.Rows[0]["ContactsWorkPhone"].ToString();
                txtInvoiceEditeClientText.Text = Dt.Rows[0]["Clienttext"].ToString();
                typicalInvoiceType = Dt.Rows[0]["TypicalInvoiceType"].ToString();
                Dt = null;
                
                
                var count=StMethod.GetSingleInt("SELECT COUNT(InvoiceNo)+1 AS InvoiceNo From JobTrackInvoiceDetail Where Joblistid=" + JobListId);
                count = 0;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    count = StMethod.GetSingleIntNew("SELECT COUNT(InvoiceNo)+1 AS InvoiceNo From JobTrackInvoiceDetail Where Joblistid=" + JobListId);

                }
                else
                {
                    count = StMethod.GetSingleInt("SELECT COUNT(InvoiceNo)+1 AS InvoiceNo From JobTrackInvoiceDetail Where Joblistid=" + JobListId);
                }

                //Dt = Program.ToDataTable(list);
                txtInvoiceNo.Text = txtInvoiceNo.Text + "-" + count.ToString();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Job Description Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {

            }
        }
        private void fillLisiVewItem()
        {
            try
            {
                //Dim DAL As DataAccessLayer
                //Dim FileDt As New DataTable
                //DAL = New DataAccessLayer
                //FileDt = DAL.Filldatatable("Select JobNumber from Joblist Where CompanyID=" & jobID)
                //lstInvoiceList.DataSource = FileDt
                //lstInvoiceList.DisplayMember = "JobNumber"
            }
            catch (Exception ex)
            {
            }
        }
        public string GetNewLine(string previosValue, string defaultReturnValue)
        {
            string NewLineStr = string.Empty;

            if (!string.IsNullOrEmpty(previosValue))
            {

                if (!string.IsNullOrEmpty(previosValue.Trim()))
                {

                    if (!string.IsNullOrEmpty(defaultReturnValue))
                    {
                        NewLineStr = defaultReturnValue;
                    }
                    else
                    {
                        NewLineStr = Environment.NewLine;
                    }
                }
            }

            return NewLineStr;
        }
        private string RemoveEmptyStr(string str)
        {
            string mystr = "";
            if (str.Split(',').Length > 0)
            {
                foreach (string s in str.Split(','))
                {
                    if (!string.IsNullOrEmpty(s))
                    {
                        mystr = mystr + s + ",";
                    }
                }
                return mystr.Remove(mystr.Length - 1);
            }
            return str;
        }
        private void CountTotalAmount()
        {
            double TotalAmount = 0;
            for (int i = 0; i < grdRateDetail.Rows.Count; i++)
            {
                TotalAmount = TotalAmount + (NumericHelper.Val(grdRateDetail.Rows[i].Cells["nRate"].Value.ToString()) * NumericHelper.Val(grdRateDetail.Rows[i].Cells["Hrs"].Value.ToString()));
            }
            lblTotalAmount.Text = "Total Amount:- $" + (Math.Round(TotalAmount).ToString());
        }
        //Private Sub GetAmountFromDescription(Optional ByVal enableReduction As Short = 0)
        //    'InvOvr
        //    Try
        //        'For Each DGrdRow As DataGridViewRow In grdRateDetail.Rows
        //        '    Dim GetNumber() As String = DGrdRow.Cells("Description"].Value.ToString.Split(";")
        //        '    If (GetNumber(0).ToString.Contains("$") = True) Then
        //        '        If (enableReduction > 0) Then
        //        '            DGrdRow.Cells("nRate"].Value = Format(CalculateReduction(Convert.ToDecimal(GetNumber(0).ToString.Replace("$", ""))), "0.00")
        //        '        Else
        //        '            DGrdRow.Cells("nRate"].Value = Format(Convert.ToDecimal(GetNumber(0).ToString.Replace("$", "")), "0.00")
        //        '        End If

        //        '    End If
        //        'Next
        //        For Each DGrdRow As DataGridViewRow In grdRateDetail.Rows
        //            Dim GetNumber As String = DGrdRow.Cells("InvOvr"].Value.ToString
        //            If (Not String.IsNullOrEmpty(GetNumber)) Then
        //                If (enableReduction > 0) Then
        //                    DGrdRow.Cells("nRate"].Value = Format(CalculateFactor(Convert.ToDecimal(GetNumber)), "0.00")
        //                Else
        //                    DGrdRow.Cells("nRate"].Value = Format(Convert.ToDecimal(GetNumber), "0.00")
        //                End If

        //            End If
        //        Next
        //    Catch ex As Exception
        //        KryptonMessageBox.Show(ex.Message, "Edit Invoice Report", MessageBoxButtons.OK, MessageBoxIcon.Error)
        //    End Try
        //End Sub
        public void SaveNewRptInvoiceDetail(EFDbContext sqlTran)
        {
            try
            {
                string Query = "INSERT INTO JobTrackInvoiceDetail(JobListID,InvoiceNo,InvoiceDate,JobDescription,DueDate,Address,PhoneNo,FaxNo,Email,PONo,PaymentCr,BalanceDue) VALUES(@jobListID,@InvoiceNo,@InvoiceDate,@JobDescription,@DueDate,@Address,@PhoneNo,@FaxNo,@Email,@PONo,@PaymentCr,@BalanceDue)";
                //SqlCommand SqlCmd = new SqlCommand(Query);
                List<SqlParameter> Param= new List<SqlParameter>();
                Param.Add(new SqlParameter("@JobListID", Program.GetJobID.ToString()));
                Param.Add(new SqlParameter("@InvoiceNo", txtInvoiceNo.Text.Trim()));
                Param.Add(new SqlParameter("@InvoiceDate", dtpInvoiceDate.Value.ToString("MM/dd/yyyy")));
                Param.Add(new SqlParameter("@JobDescription", txtJobDescription.Text.Trim().Trim()));
                Param.Add(new SqlParameter("@DueDate", dtpDueDate.Value.ToString("MM/dd/yyyy")));
                Param.Add(new SqlParameter("@Address", CommonUtility.Remove_EmptyLine_Space(txtAddress.Text)));
                Param.Add(new SqlParameter("@PhoneNo", txtphoneNo.Text.Trim()));
                Param.Add(new SqlParameter("@FaxNo", txtFaxNo.Text.Trim()));
                Param.Add(new SqlParameter("@Email", txtEmailAddress.Text.Trim()));
                Param.Add(new SqlParameter("@PONo", txtPONo.Text.Trim()));
                Param.Add(new SqlParameter("@PaymentCr", Convert.ToDecimal( txtPaymentCr.Text.Trim())));
                Param.Add(new SqlParameter("@BalanceDue", Convert.ToDecimal(txtBalanceDue.Text.Trim())));
                //SqlCmd.ExecuteNonQuery();

                sqlTran.Database.ExecuteSqlCommand(Query, Param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveNewRptInvoiceDetailNew(TestVariousInfo_WithDataEntities sqlTran)
        {
            try
            {
                string Query = "INSERT INTO JobTrackInvoiceDetail(JobListID,InvoiceNo,InvoiceDate,JobDescription,DueDate,Address,PhoneNo,FaxNo,Email,PONo,PaymentCr,BalanceDue) VALUES(@jobListID,@InvoiceNo,@InvoiceDate,@JobDescription,@DueDate,@Address,@PhoneNo,@FaxNo,@Email,@PONo,@PaymentCr,@BalanceDue)";
                //SqlCommand SqlCmd = new SqlCommand(Query);
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@JobListID", Program.GetJobID.ToString()));
                Param.Add(new SqlParameter("@InvoiceNo", txtInvoiceNo.Text.Trim()));
                Param.Add(new SqlParameter("@InvoiceDate", dtpInvoiceDate.Value.ToString("MM/dd/yyyy")));
                Param.Add(new SqlParameter("@JobDescription", txtJobDescription.Text.Trim().Trim()));
                Param.Add(new SqlParameter("@DueDate", dtpDueDate.Value.ToString("MM/dd/yyyy")));
                Param.Add(new SqlParameter("@Address", CommonUtility.Remove_EmptyLine_Space(txtAddress.Text)));
                Param.Add(new SqlParameter("@PhoneNo", txtphoneNo.Text.Trim()));
                Param.Add(new SqlParameter("@FaxNo", txtFaxNo.Text.Trim()));
                Param.Add(new SqlParameter("@Email", txtEmailAddress.Text.Trim()));
                Param.Add(new SqlParameter("@PONo", txtPONo.Text.Trim()));
                Param.Add(new SqlParameter("@PaymentCr", Convert.ToDecimal(txtPaymentCr.Text.Trim())));
                Param.Add(new SqlParameter("@BalanceDue", Convert.ToDecimal(txtBalanceDue.Text.Trim())));
                //SqlCmd.ExecuteNonQuery();

                sqlTran.Database.ExecuteSqlCommand(Query, Param.ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveNewRptInvoiceRatedetail(EFDbContext sqlTran)
        {
            //Get JobTrackInvoiceDetail ID
            decimal JobTrackDetailID;
            //JobTrackDetailID = DAL.ExceuteScaler("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail")
            JobTrackDetailID = GetLatestInvoiceDetailId(sqlTran);
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[11]
                {
                new DataColumn("TrackSubID", typeof(int)),
                new DataColumn("JobTrackSubName", typeof(string)),
                new DataColumn("JobTrackDetailID", typeof(decimal)),
                new DataColumn("Hrs", typeof(decimal)),
                new DataColumn("Rate", typeof(decimal)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("Date", typeof(DateTime)),
                new DataColumn("byname", typeof(string)),
                new DataColumn("Amount", typeof(decimal)),
                new DataColumn("Clienttext", typeof(string)),
                new DataColumn("JobTrackingID", typeof(int))
                });
                for (int i = 0; i < grdRateDetail.Rows.Count; i++)
                {
                    long TrackSubID = Convert.ToInt64(grdRateDetail.Rows[i].Cells["TrackSubID"].EditedFormattedValue.ToString());
                    string JobTrackSubName = grdRateDetail.Rows[i].Cells["TrackSubName"].EditedFormattedValue.ToString();
                    decimal ID = JobTrackDetailID;
                    string Hrs = string.IsNullOrEmpty(grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue.ToString()) ? "0.1" : grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue.ToString();
                    string Rate = string.IsNullOrEmpty(grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString()) ? "0.0" : grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString();
                    string Description = grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString();
                    if (grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString().Split("];"[0]).Length > 0)
                    {
                        //'Dim desc As String = grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString().Split("];")(0).ToString()
                        //' Description = desc.Replace("[", "")

                        //'********** Updated in the code on 7-Jan-2019 for error ("when creating invoices.  the item "Miscellaneous Reinburcement" does not transfer the full description to the invoice.")
                        Description = string.Empty;
                        string[] descWords = grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString().Split("];"[0]);
                        foreach (string desc in descWords)
                        {
                            Description += desc.Replace("[", "");
                        }
                    }

                    string Date1 = grdRateDetail.Rows[i].Cells["AddDate"].EditedFormattedValue.ToString();
                    string byname = grdRateDetail.Rows[i].Cells["TaskHandler"].EditedFormattedValue.ToString();
                    string Amount = string.IsNullOrEmpty(grdRateDetail.Rows[i].Cells["Amount"].EditedFormattedValue.ToString()) ? "0.0" : grdRateDetail.Rows[i].Cells["Amount"].EditedFormattedValue.ToString();
                    int jobTrackingId = Convert.ToInt32(grdRateDetail.Rows[i].Cells["JobTrackingID"].Value.ToString());
                    string Clienttext = txtInvoiceEditeClientText.Text.ToString();

                    //Dim Result As String = Cells("Description"].Value.ToString().Split(";"c, ","c)

                    dt.Rows.Add(TrackSubID, JobTrackSubName, ID, Hrs, Rate, Description, Date1, byname, Amount, Clienttext, jobTrackingId);

                }

                if (dt.Rows.Count > 0)
                {
                    //Dim consString As String = Sqlcon.ConnectionString  ;
                    //Using con As New SqlConnection(Sqlcon.ConnectionString)
                    InsertInvoiceItems("JobTrackInvoiceRateDetail", dt, sqlTran);
                    //Using con As SqlConnection = sqlTran.Connection

                    //Dim sqlBulkCopy As New SqlBulkCopy(con)
                    //If (sqlTran IsNot Nothing) Then
                    //    sqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTran)
                    //End If
                    //Using sqlBulkCopy
                    //    'Set the database table name
                    //    sqlBulkCopy.DestinationTableName = "dbo.JobTrackInvoiceRateDetail"
                    //    sqlBulkCopy.BatchSize = 500
                    //    '[OPTIONAL]: Map the DataTable columns with that of the database table
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackDetailID", "JobTrackDetailID")
                    //    sqlBulkCopy.ColumnMappings.Add("Date", "Date")
                    //    sqlBulkCopy.ColumnMappings.Add("TrackSubID", "TrackSubID")
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackSubName", "JobTrackSubName")
                    //    sqlBulkCopy.ColumnMappings.Add("Rate", "Rate")
                    //    sqlBulkCopy.ColumnMappings.Add("Hrs", "Hrs")
                    //    sqlBulkCopy.ColumnMappings.Add("Description", "Description")
                    //    sqlBulkCopy.ColumnMappings.Add("byname", "byname")
                    //    sqlBulkCopy.ColumnMappings.Add("Amount", "Amount")
                    //    sqlBulkCopy.ColumnMappings.Add("Clienttext", "Clienttext")
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackingID", "JobTrackingID")
                    //    'con.Open()
                    //    sqlBulkCopy.WriteToServer(dt)
                    //    'con.Close()
                    //End Using
                    //End Using
                }
                //Dim Query As String = "INSERT INTO JobTrackInvoiceRateDetail(JobTrackSubName,JobTrackDetailID,Hrs,Rate,Description,TrackSubID,Date,byname,Amount,Clienttext) VALUES (@JobTrackSubName,@JobTrackDetailID,@Hrs,@Rate,@Description,@TrackSubID,@Date,@byname,@Amount,@Clienttext)"
                //SqlCmd = New SqlCommand(Query, Sqlcon)
                //SqlCmd.Parameters.AddWithValue("@JobTrackDetailID", JobTrackDetailID)

                //If grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString() = "" Then
                //    SqlCmd.Parameters.AddWithValue("@Rate", 0.0)
                //Else
                //    SqlCmd.Parameters.AddWithValue("@Rate", grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString)
                //End If
                //If grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue.ToString() = "" Then
                //    SqlCmd.Parameters.AddWithValue("@Hrs", 1.0)
                //Else
                //    SqlCmd.Parameters.AddWithValue("@Hrs", grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue.ToString)
                //End If
                //If grdRateDetail.Rows[i].Cells["Amount"].EditedFormattedValue.ToString() = "" Then
                //    SqlCmd.Parameters.AddWithValue("@Amount", 0.0)
                //Else
                //    SqlCmd.Parameters.AddWithValue("@Amount", grdRateDetail.Rows[i].Cells["Amount"].EditedFormattedValue.ToString)
                //End If
                //SqlCmd.Parameters.AddWithValue("@Description", grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString)
                //SqlCmd.Parameters.AddWithValue("@JobTrackSubName", grdRateDetail.Rows[i].Cells["TrackSubName"].EditedFormattedValue.ToString)
                //SqlCmd.Parameters.AddWithValue("@Date", grdRateDetail.Rows[i].Cells["AddDate"].EditedFormattedValue.ToString)
                //SqlCmd.Parameters.AddWithValue("@byname", grdRateDetail.Rows[i].Cells["TaskHandler"].EditedFormattedValue.ToString)

                //SqlCmd.Parameters.AddWithValue("@TrackSubID", grdRateDetail.Rows[i].Cells["TrackSubID"].EditedFormattedValue.ToString)
                //SqlCmd.Parameters.AddWithValue("@Clienttext", txtInvoiceEditeClientText.Text.ToString())
                //Sqlcon.Open()
                //SqlCmd.ExecuteNonQuery()
                //Sqlcon.Close()
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Sqlcon.Close()
            }

        }

        public void SaveNewRptInvoiceRatedetailNew(TestVariousInfo_WithDataEntities sqlTran)
        {
            //Get JobTrackInvoiceDetail ID
            decimal JobTrackDetailID;
            //JobTrackDetailID = DAL.ExceuteScaler("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail")

            //JobTrackDetailID = GetLatestInvoiceDetailId(sqlTran);
            JobTrackDetailID = GetLatestInvoiceDetailIdNew(sqlTran);

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[11]
                {
                new DataColumn("TrackSubID", typeof(int)),
                new DataColumn("JobTrackSubName", typeof(string)),
                new DataColumn("JobTrackDetailID", typeof(decimal)),
                new DataColumn("Hrs", typeof(decimal)),
                new DataColumn("Rate", typeof(decimal)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("Date", typeof(DateTime)),
                new DataColumn("byname", typeof(string)),
                new DataColumn("Amount", typeof(decimal)),
                new DataColumn("Clienttext", typeof(string)),
                new DataColumn("JobTrackingID", typeof(int))
                });
                for (int i = 0; i < grdRateDetail.Rows.Count; i++)
                {
                    long TrackSubID = Convert.ToInt64(grdRateDetail.Rows[i].Cells["TrackSubID"].EditedFormattedValue.ToString());
                    string JobTrackSubName = grdRateDetail.Rows[i].Cells["TrackSubName"].EditedFormattedValue.ToString();
                    decimal ID = JobTrackDetailID;
                    string Hrs = string.IsNullOrEmpty(grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue.ToString()) ? "0.1" : grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue.ToString();
                    string Rate = string.IsNullOrEmpty(grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString()) ? "0.0" : grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString();
                    string Description = grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString();
                    if (grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString().Split("];"[0]).Length > 0)
                    {
                        //'Dim desc As String = grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString().Split("];")(0).ToString()
                        //' Description = desc.Replace("[", "")

                        //'********** Updated in the code on 7-Jan-2019 for error ("when creating invoices.  the item "Miscellaneous Reinburcement" does not transfer the full description to the invoice.")
                        Description = string.Empty;
                        string[] descWords = grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString().Split("];"[0]);
                        foreach (string desc in descWords)
                        {
                            Description += desc.Replace("[", "");
                        }
                    }

                    string Date1 = grdRateDetail.Rows[i].Cells["AddDate"].EditedFormattedValue.ToString();
                    string byname = grdRateDetail.Rows[i].Cells["TaskHandler"].EditedFormattedValue.ToString();
                    string Amount = string.IsNullOrEmpty(grdRateDetail.Rows[i].Cells["Amount"].EditedFormattedValue.ToString()) ? "0.0" : grdRateDetail.Rows[i].Cells["Amount"].EditedFormattedValue.ToString();
                    int jobTrackingId = Convert.ToInt32(grdRateDetail.Rows[i].Cells["JobTrackingID"].Value.ToString());
                    string Clienttext = txtInvoiceEditeClientText.Text.ToString();

                    //Dim Result As String = Cells("Description"].Value.ToString().Split(";"c, ","c)

                    dt.Rows.Add(TrackSubID, JobTrackSubName, ID, Hrs, Rate, Description, Date1, byname, Amount, Clienttext, jobTrackingId);

                }

                if (dt.Rows.Count > 0)
                {
                    //Dim consString As String = Sqlcon.ConnectionString  ;
                    //Using con As New SqlConnection(Sqlcon.ConnectionString)


                    //InsertInvoiceItems("JobTrackInvoiceRateDetail", dt, sqlTran);
                    InsertInvoiceItemsNew("JobTrackInvoiceRateDetail", dt, sqlTran);


                    //Using con As SqlConnection = sqlTran.Connection

                    //Dim sqlBulkCopy As New SqlBulkCopy(con)
                    //If (sqlTran IsNot Nothing) Then
                    //    sqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTran)
                    //End If
                    //Using sqlBulkCopy
                    //    'Set the database table name
                    //    sqlBulkCopy.DestinationTableName = "dbo.JobTrackInvoiceRateDetail"
                    //    sqlBulkCopy.BatchSize = 500
                    //    '[OPTIONAL]: Map the DataTable columns with that of the database table
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackDetailID", "JobTrackDetailID")
                    //    sqlBulkCopy.ColumnMappings.Add("Date", "Date")
                    //    sqlBulkCopy.ColumnMappings.Add("TrackSubID", "TrackSubID")
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackSubName", "JobTrackSubName")
                    //    sqlBulkCopy.ColumnMappings.Add("Rate", "Rate")
                    //    sqlBulkCopy.ColumnMappings.Add("Hrs", "Hrs")
                    //    sqlBulkCopy.ColumnMappings.Add("Description", "Description")
                    //    sqlBulkCopy.ColumnMappings.Add("byname", "byname")
                    //    sqlBulkCopy.ColumnMappings.Add("Amount", "Amount")
                    //    sqlBulkCopy.ColumnMappings.Add("Clienttext", "Clienttext")
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackingID", "JobTrackingID")
                    //    'con.Open()
                    //    sqlBulkCopy.WriteToServer(dt)
                    //    'con.Close()
                    //End Using
                    //End Using
                }
                //Dim Query As String = "INSERT INTO JobTrackInvoiceRateDetail(JobTrackSubName,JobTrackDetailID,Hrs,Rate,Description,TrackSubID,Date,byname,Amount,Clienttext) VALUES (@JobTrackSubName,@JobTrackDetailID,@Hrs,@Rate,@Description,@TrackSubID,@Date,@byname,@Amount,@Clienttext)"
                //SqlCmd = New SqlCommand(Query, Sqlcon)
                //SqlCmd.Parameters.AddWithValue("@JobTrackDetailID", JobTrackDetailID)

                //If grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString() = "" Then
                //    SqlCmd.Parameters.AddWithValue("@Rate", 0.0)
                //Else
                //    SqlCmd.Parameters.AddWithValue("@Rate", grdRateDetail.Rows[i].Cells["nRate"].EditedFormattedValue.ToString)
                //End If
                //If grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue.ToString() = "" Then
                //    SqlCmd.Parameters.AddWithValue("@Hrs", 1.0)
                //Else
                //    SqlCmd.Parameters.AddWithValue("@Hrs", grdRateDetail.Rows[i].Cells["Hrs"].EditedFormattedValue.ToString)
                //End If
                //If grdRateDetail.Rows[i].Cells["Amount"].EditedFormattedValue.ToString() = "" Then
                //    SqlCmd.Parameters.AddWithValue("@Amount", 0.0)
                //Else
                //    SqlCmd.Parameters.AddWithValue("@Amount", grdRateDetail.Rows[i].Cells["Amount"].EditedFormattedValue.ToString)
                //End If
                //SqlCmd.Parameters.AddWithValue("@Description", grdRateDetail.Rows[i].Cells["Description"].EditedFormattedValue.ToString)
                //SqlCmd.Parameters.AddWithValue("@JobTrackSubName", grdRateDetail.Rows[i].Cells["TrackSubName"].EditedFormattedValue.ToString)
                //SqlCmd.Parameters.AddWithValue("@Date", grdRateDetail.Rows[i].Cells["AddDate"].EditedFormattedValue.ToString)
                //SqlCmd.Parameters.AddWithValue("@byname", grdRateDetail.Rows[i].Cells["TaskHandler"].EditedFormattedValue.ToString)

                //SqlCmd.Parameters.AddWithValue("@TrackSubID", grdRateDetail.Rows[i].Cells["TrackSubID"].EditedFormattedValue.ToString)
                //SqlCmd.Parameters.AddWithValue("@Clienttext", txtInvoiceEditeClientText.Text.ToString())
                //Sqlcon.Open()
                //SqlCmd.ExecuteNonQuery()
                //Sqlcon.Close()
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Sqlcon.Close()
            }

        }

        private void SaveNewTimeReport(EFDbContext sqlTran)
        {
            try
            {
                decimal jobTrackDetailID;
                //jobTrackDetailID = DAL.ExceuteScaler("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail")
                jobTrackDetailID = GetLatestInvoiceDetailId(sqlTran);

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[8]
                {
                new DataColumn("JobTrackDetailID", typeof(long)),
                new DataColumn("Date", typeof(string)),
                new DataColumn("Time", typeof(string)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("Rate", typeof(string)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("JobTrackSubName", typeof(string)),
                new DataColumn("TimeSheetID", typeof(int))
                });
                for (int row = 0; row < grvTime.Rows.Count; row++)
                {

                    decimal ID = jobTrackDetailID;
                    string Date1 = grvTime.Rows[row].Cells["Date"].Value.ToString();
                    string Time = grvTime.Rows[row].Cells["Qty"].Value.ToString();
                    List<string> desList = new List<string>(new[] { grvTime.Rows[row].Cells["TrackSubName"].Value.ToString(), grvTime.Rows[row].Cells["Description"].Value.ToString() });

                    //'TrackSubName consider as item in time invoice so we comment below code
                    //Dim Description As String = grvTime.Rows[row].Cells["TrackSubName"].Value.ToString() & ", " & grvTime.Rows[row].Cells["Description"].Value.ToString()
                    //'= String.Join(",", desList.Remove(st))
                    //If (Description.Length > 0) Then
                    //    If (Description(0) = ",") Then Description = Description.Remove(0, 1)
                    //    If (Description(Description.Length - 1) = ",") Then Description = Description.Remove(Description.Length - 1)
                    //End If
                    string Item = grvTime.Rows[row].Cells["TrackSubName"].Value.ToString();

                    string Description = grvTime.Rows[row].Cells["Description"].Value.ToString();
                    string Rate = grvTime.Rows[row].Cells["Rate"].Value.ToString();
                    string Name = grvTime.Rows[row].Cells["By"].Value.ToString();
                    int timeSheetId = Convert.ToInt32(grvTime.Rows[row].Cells["TimeSheetID"].Value);
                    dt.Rows.Add(ID, Date1, Time, Description, Rate, Name, Item, timeSheetId);
                }
                if (dt.Rows.Count > 0)
                {
                    //Dim consString As String = Sqlcon.ConnectionString  ;
                    InsertInvoiceItems("dbo.CRVTimeInvoice", dt, sqlTran);
                    //Using con As SqlConnection = sqlTran.Connection

                    //Dim sqlBulkCopy As New SqlBulkCopy(con)
                    //If (sqlTran IsNot Nothing) Then
                    //    sqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.UseInternalTransaction, sqlTran)
                    //End If
                    //Using sqlBulkCopy
                    //    'Set the database table name
                    //    sqlBulkCopy.DestinationTableName = "dbo.CRVTimeInvoice"
                    //    sqlBulkCopy.BatchSize = 500
                    //    '[OPTIONAL]: Map the DataTable columns with that of the database table
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackDetailID", "JobTrackDetailID")
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackSubName", "JobTrackSubName")
                    //    sqlBulkCopy.ColumnMappings.Add("Date", "Date")
                    //    sqlBulkCopy.ColumnMappings.Add("Time", "Time")
                    //    sqlBulkCopy.ColumnMappings.Add("Description", "Description")
                    //    sqlBulkCopy.ColumnMappings.Add("Rate", "Rate")
                    //    sqlBulkCopy.ColumnMappings.Add("Name", "Name")
                    //    sqlBulkCopy.ColumnMappings.Add("TimeSheetID", "TimeSheetID")
                    //    'con.Open()
                    //    sqlBulkCopy.WriteToServer(dt)
                    //    'con.Close()
                    //End Using
                    //End Using
                }

                //Dim JobTrackDetailID As Int64
                //JobTrackDetailID = DAL.ExceuteScaler("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail")

                //'Dim Query As String = "INSERT INTO CRVTimeInvoice(JobTrackDetailID, Date, Time, Description,Rate,Name)VALUES(@JobTrackDetailID,@Date,@Time,@Description,@Rate, @Name)"
                //'For i As Integer = 0 To grvTime.Rows.Count - 1
                //'    SqlCmd = New SqlCommand(Query, Sqlcon)
                //'    SqlCmd.Parameters.AddWithValue("@JobTrackDetailID", JobTrackDetailID)
                //'    SqlCmd.Parameters.AddWithValue("@Date", grvTime.Rows[i].Cells["Date"].Value.ToString())
                //'    SqlCmd.Parameters.AddWithValue("@Time", grvTime.Rows[i].Cells["Qty"].Value.ToString())
                //'    SqlCmd.Parameters.AddWithValue("@Description", grvTime.Rows[i].Cells["Description"].Value.ToString())
                //'    SqlCmd.Parameters.AddWithValue("@Rate", grvTime.Rows[i].Cells["Rate"].Value.ToString())
                //'    SqlCmd.Parameters.AddWithValue("@Name", grvTime.Rows[i].Cells["By"].Value.ToString())

                //'    Sqlcon.Open()
                //'    SqlCmd.ExecuteNonQuery()
                //'    Sqlcon.Close()
                //Dim xmlString As New StringBuilder("")
                //'xmlString.Append("<Data>")
                //For TimeRow As Integer = 0 To grvTime.Rows.Count - 1
                //    xmlString.Append("<Row>")
                //    xmlString.Append("<JobTrackDetailID>" + JobTrackDetailID.ToString() + "</JobTrackDetailID>")
                //    xmlString.Append("<Date>" + grvTime.Rows[TimeRow].Cells["Date"].Value.ToString() + "</Date>")
                //    xmlString.Append("<Time>" + grvTime.Rows[TimeRow].Cells["Qty"].Value.ToString() + "</Time>")
                //    xmlString.Append("<Description>" + grvTime.Rows[TimeRow].Cells["Description"].Value.ToString() + "</Description>")
                //    xmlString.Append("<Rate>" + grvTime.Rows[TimeRow].Cells["Rate"].Value.ToString() + "</Rate>")
                //    xmlString.Append("<Name>" + grvTime.Rows[TimeRow].Cells["By"].Value.ToString() + "</Name>")
                //    xmlString.Append("</Row>")
                //    If TimeRow Mod 100 = 0 And TimeRow <> 0 Then
                //        Dim xml As String = "<Data>" + xmlString.ToString() + "</Data>)"
                //        Dim Param As New List(Of SqlParameter)
                //        Param.Add(DAL.SqlParameter("@xmlString", xml.Replace("&", "&amp;")))
                //        DAL.InsertRecord(New SqlCommand("SP_CRVTimeInvoice_INSERT"), Param)
                //        xmlString.Clear()
                //    End If
                //Next

                //If Not String.IsNullOrEmpty(xmlString.ToString()) Then
                //    Dim xml As String = "<Data>" + xmlString.ToString() + "</Data>)"
                //    Dim Param As New List(Of SqlParameter)
                //    Param.Add(DAL.SqlParameter("@xmlString", xml.Replace("&", "&amp;")))
                //    DAL.InsertRecord(New SqlCommand("SP_CRVTimeInvoice_INSERT"), Param)
                //End If
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveNewTimeReportNew(TestVariousInfo_WithDataEntities sqlTran)
        {
            try
            {
                decimal jobTrackDetailID;
                //jobTrackDetailID = DAL.ExceuteScaler("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail")

                //jobTrackDetailID = GetLatestInvoiceDetailId(sqlTran);
                jobTrackDetailID = GetLatestInvoiceDetailIdNew(sqlTran);


                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[8]
                {
                new DataColumn("JobTrackDetailID", typeof(long)),
                new DataColumn("Date", typeof(string)),
                new DataColumn("Time", typeof(string)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("Rate", typeof(string)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("JobTrackSubName", typeof(string)),
                new DataColumn("TimeSheetID", typeof(int))
                });
                for (int row = 0; row < grvTime.Rows.Count; row++)
                {

                    decimal ID = jobTrackDetailID;
                    string Date1 = grvTime.Rows[row].Cells["Date"].Value.ToString();
                    string Time = grvTime.Rows[row].Cells["Qty"].Value.ToString();
                    List<string> desList = new List<string>(new[] { grvTime.Rows[row].Cells["TrackSubName"].Value.ToString(), grvTime.Rows[row].Cells["Description"].Value.ToString() });

                    //'TrackSubName consider as item in time invoice so we comment below code
                    //Dim Description As String = grvTime.Rows[row].Cells["TrackSubName"].Value.ToString() & ", " & grvTime.Rows[row].Cells["Description"].Value.ToString()
                    //'= String.Join(",", desList.Remove(st))
                    //If (Description.Length > 0) Then
                    //    If (Description(0) = ",") Then Description = Description.Remove(0, 1)
                    //    If (Description(Description.Length - 1) = ",") Then Description = Description.Remove(Description.Length - 1)
                    //End If
                    string Item = grvTime.Rows[row].Cells["TrackSubName"].Value.ToString();

                    string Description = grvTime.Rows[row].Cells["Description"].Value.ToString();
                    string Rate = grvTime.Rows[row].Cells["Rate"].Value.ToString();
                    string Name = grvTime.Rows[row].Cells["By"].Value.ToString();
                    int timeSheetId = Convert.ToInt32(grvTime.Rows[row].Cells["TimeSheetID"].Value);
                    dt.Rows.Add(ID, Date1, Time, Description, Rate, Name, Item, timeSheetId);
                }
                if (dt.Rows.Count > 0)
                {
                    //Dim consString As String = Sqlcon.ConnectionString  ;


                    //InsertInvoiceItems("dbo.CRVTimeInvoice", dt, sqlTran);
                    InsertInvoiceItemsNew("dbo.CRVTimeInvoice", dt, sqlTran);


                    //Using con As SqlConnection = sqlTran.Connection

                    //Dim sqlBulkCopy As New SqlBulkCopy(con)
                    //If (sqlTran IsNot Nothing) Then
                    //    sqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.UseInternalTransaction, sqlTran)
                    //End If
                    //Using sqlBulkCopy
                    //    'Set the database table name
                    //    sqlBulkCopy.DestinationTableName = "dbo.CRVTimeInvoice"
                    //    sqlBulkCopy.BatchSize = 500
                    //    '[OPTIONAL]: Map the DataTable columns with that of the database table
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackDetailID", "JobTrackDetailID")
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackSubName", "JobTrackSubName")
                    //    sqlBulkCopy.ColumnMappings.Add("Date", "Date")
                    //    sqlBulkCopy.ColumnMappings.Add("Time", "Time")
                    //    sqlBulkCopy.ColumnMappings.Add("Description", "Description")
                    //    sqlBulkCopy.ColumnMappings.Add("Rate", "Rate")
                    //    sqlBulkCopy.ColumnMappings.Add("Name", "Name")
                    //    sqlBulkCopy.ColumnMappings.Add("TimeSheetID", "TimeSheetID")
                    //    'con.Open()
                    //    sqlBulkCopy.WriteToServer(dt)
                    //    'con.Close()
                    //End Using
                    //End Using
                }

                //Dim JobTrackDetailID As Int64
                //JobTrackDetailID = DAL.ExceuteScaler("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail")

                //'Dim Query As String = "INSERT INTO CRVTimeInvoice(JobTrackDetailID, Date, Time, Description,Rate,Name)VALUES(@JobTrackDetailID,@Date,@Time,@Description,@Rate, @Name)"
                //'For i As Integer = 0 To grvTime.Rows.Count - 1
                //'    SqlCmd = New SqlCommand(Query, Sqlcon)
                //'    SqlCmd.Parameters.AddWithValue("@JobTrackDetailID", JobTrackDetailID)
                //'    SqlCmd.Parameters.AddWithValue("@Date", grvTime.Rows[i].Cells["Date"].Value.ToString())
                //'    SqlCmd.Parameters.AddWithValue("@Time", grvTime.Rows[i].Cells["Qty"].Value.ToString())
                //'    SqlCmd.Parameters.AddWithValue("@Description", grvTime.Rows[i].Cells["Description"].Value.ToString())
                //'    SqlCmd.Parameters.AddWithValue("@Rate", grvTime.Rows[i].Cells["Rate"].Value.ToString())
                //'    SqlCmd.Parameters.AddWithValue("@Name", grvTime.Rows[i].Cells["By"].Value.ToString())

                //'    Sqlcon.Open()
                //'    SqlCmd.ExecuteNonQuery()
                //'    Sqlcon.Close()
                //Dim xmlString As New StringBuilder("")
                //'xmlString.Append("<Data>")
                //For TimeRow As Integer = 0 To grvTime.Rows.Count - 1
                //    xmlString.Append("<Row>")
                //    xmlString.Append("<JobTrackDetailID>" + JobTrackDetailID.ToString() + "</JobTrackDetailID>")
                //    xmlString.Append("<Date>" + grvTime.Rows[TimeRow].Cells["Date"].Value.ToString() + "</Date>")
                //    xmlString.Append("<Time>" + grvTime.Rows[TimeRow].Cells["Qty"].Value.ToString() + "</Time>")
                //    xmlString.Append("<Description>" + grvTime.Rows[TimeRow].Cells["Description"].Value.ToString() + "</Description>")
                //    xmlString.Append("<Rate>" + grvTime.Rows[TimeRow].Cells["Rate"].Value.ToString() + "</Rate>")
                //    xmlString.Append("<Name>" + grvTime.Rows[TimeRow].Cells["By"].Value.ToString() + "</Name>")
                //    xmlString.Append("</Row>")
                //    If TimeRow Mod 100 = 0 And TimeRow <> 0 Then
                //        Dim xml As String = "<Data>" + xmlString.ToString() + "</Data>)"
                //        Dim Param As New List(Of SqlParameter)
                //        Param.Add(DAL.SqlParameter("@xmlString", xml.Replace("&", "&amp;")))
                //        DAL.InsertRecord(New SqlCommand("SP_CRVTimeInvoice_INSERT"), Param)
                //        xmlString.Clear()
                //    End If
                //Next

                //If Not String.IsNullOrEmpty(xmlString.ToString()) Then
                //    Dim xml As String = "<Data>" + xmlString.ToString() + "</Data>)"
                //    Dim Param As New List(Of SqlParameter)
                //    Param.Add(DAL.SqlParameter("@xmlString", xml.Replace("&", "&amp;")))
                //    DAL.InsertRecord(New SqlCommand("SP_CRVTimeInvoice_INSERT"), Param)
                //End If
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void SaveNewExpensesReport(EFDbContext sqlTran)
        {
            try
            {
                decimal JobTrackDetailID;
                //JobTrackDetailID = DAL.ExceuteScaler("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail")
                
                JobTrackDetailID = GetLatestInvoiceDetailId(sqlTran);

                //if (Properties.Settings.Default.IsTestDatabase == true)
                //{
                //    JobTrackDetailID = GetLatestInvoiceDetailIdNew(sqlTran);

                //}
                //else
                //{
                //    JobTrackDetailID = GetLatestInvoiceDetailId(sqlTran);
                //}


                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6]
                {
                new DataColumn("JobTrackDetailID", typeof(long)),
                new DataColumn("Date", typeof(string)),
                new DataColumn("Expenses", typeof(string)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("byname", typeof(string)),
                new DataColumn("TimeSheetExpencesID", typeof(int))
                });
                for (int i = 0; i < grvExpenses.Rows.Count; i++)
                {

                    decimal ID = JobTrackDetailID;
                    string Date1 = grvExpenses.Rows[i].Cells["Date"].Value.ToString();
                    string Expenses = grvExpenses.Rows[i].Cells["Amount"].Value.ToString();
                    string Description = grvExpenses.Rows[i].Cells["Description"].Value.ToString();
                    string byname = grvExpenses.Rows[i].Cells["Bye"].Value.ToString();
                    int timeSheetExpencesID = Convert.ToInt32( grvExpenses.Rows[i].Cells["TimeSheetExpencesID"].Value);
                    dt.Rows.Add(ID, Date1, Expenses, Description, byname, timeSheetExpencesID);

                }
                if (dt.Rows.Count > 0)
                {
                    //Dim consString As String = Sqlcon.ConnectionString  ;
                    InsertInvoiceItems("dbo.CRVExpensesInvoice", dt, sqlTran);
                    //Using con As SqlConnection = sqlTran.Connection

                    //Dim sqlBulkCopy As New SqlBulkCopy(con)
                    //If (sqlTran IsNot Nothing) Then
                    //    sqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTran)
                    //End If
                    //Using sqlBulkCopy
                    //    'Set the database table name
                    //    sqlBulkCopy.DestinationTableName = "dbo.CRVExpensesInvoice"
                    //    sqlBulkCopy.BatchSize = 500
                    //    '[OPTIONAL]: Map the DataTable columns with that of the database table
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackDetailID", "JobTrackDetailID")
                    //    sqlBulkCopy.ColumnMappings.Add("Date", "Date")
                    //    sqlBulkCopy.ColumnMappings.Add("Description", "Description")
                    //    sqlBulkCopy.ColumnMappings.Add("Expenses", "Expenses")
                    //    sqlBulkCopy.ColumnMappings.Add("byname", "byname")
                    //    sqlBulkCopy.ColumnMappings.Add("TimeSheetExpencesID", "TimeSheetExpencesID")
                    //    'con.Open()
                    //    sqlBulkCopy.WriteToServer(dt)
                    //    'con.Close()
                    //End Using
                    //End Using
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveNewExpensesReportNew(TestVariousInfo_WithDataEntities sqlTran)
        {
            try
            {
                decimal JobTrackDetailID;
                //JobTrackDetailID = DAL.ExceuteScaler("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail")

                //JobTrackDetailID = GetLatestInvoiceDetailId(sqlTran);

                JobTrackDetailID = GetLatestInvoiceDetailIdNew(sqlTran);

                //if (Properties.Settings.Default.IsTestDatabase == true)
                //{
                //    JobTrackDetailID = GetLatestInvoiceDetailIdNew(sqlTran);

                //}
                //else
                //{
                //    JobTrackDetailID = GetLatestInvoiceDetailId(sqlTran);
                //}



                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[6]
                {
                new DataColumn("JobTrackDetailID", typeof(long)),
                new DataColumn("Date", typeof(string)),
                new DataColumn("Expenses", typeof(string)),
                new DataColumn("Description", typeof(string)),
                new DataColumn("byname", typeof(string)),
                new DataColumn("TimeSheetExpencesID", typeof(int))
                });
                for (int i = 0; i < grvExpenses.Rows.Count; i++)
                {

                    decimal ID = JobTrackDetailID;
                    string Date1 = grvExpenses.Rows[i].Cells["Date"].Value.ToString();
                    string Expenses = grvExpenses.Rows[i].Cells["Amount"].Value.ToString();
                    string Description = grvExpenses.Rows[i].Cells["Description"].Value.ToString();
                    string byname = grvExpenses.Rows[i].Cells["Bye"].Value.ToString();
                    int timeSheetExpencesID = Convert.ToInt32(grvExpenses.Rows[i].Cells["TimeSheetExpencesID"].Value);
                    dt.Rows.Add(ID, Date1, Expenses, Description, byname, timeSheetExpencesID);

                }
                if (dt.Rows.Count > 0)
                {
                    //Dim consString As String = Sqlcon.ConnectionString  ;

                    //InsertInvoiceItems("dbo.CRVExpensesInvoice", dt, sqlTran);

                    InsertInvoiceItemsNew("dbo.CRVExpensesInvoice", dt, sqlTran);

                    //Using con As SqlConnection = sqlTran.Connection

                    //Dim sqlBulkCopy As New SqlBulkCopy(con)
                    //If (sqlTran IsNot Nothing) Then
                    //    sqlBulkCopy = New SqlBulkCopy(con, SqlBulkCopyOptions.Default, sqlTran)
                    //End If
                    //Using sqlBulkCopy
                    //    'Set the database table name
                    //    sqlBulkCopy.DestinationTableName = "dbo.CRVExpensesInvoice"
                    //    sqlBulkCopy.BatchSize = 500
                    //    '[OPTIONAL]: Map the DataTable columns with that of the database table
                    //    sqlBulkCopy.ColumnMappings.Add("JobTrackDetailID", "JobTrackDetailID")
                    //    sqlBulkCopy.ColumnMappings.Add("Date", "Date")
                    //    sqlBulkCopy.ColumnMappings.Add("Description", "Description")
                    //    sqlBulkCopy.ColumnMappings.Add("Expenses", "Expenses")
                    //    sqlBulkCopy.ColumnMappings.Add("byname", "byname")
                    //    sqlBulkCopy.ColumnMappings.Add("TimeSheetExpencesID", "TimeSheetExpencesID")
                    //    'con.Open()
                    //    sqlBulkCopy.WriteToServer(dt)
                    //    'con.Close()
                    //End Using
                    //End Using
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void LoadCheckBox()
        {
            //var list= StMethod.GetList<string>("SELECT top 1 TypicalInvoiceType FROM JobList WHERE JobListId=" + Program.GetColorID);

            var list = StMethod.GetList<string>("SELECT top 1 TypicalInvoiceType FROM JobList WHERE JobListId=" + Program.GetColorID);
            list = null;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                list = StMethod.GetListNew<string>("SELECT top 1 TypicalInvoiceType FROM JobList WHERE JobListId=" + Program.GetColorID);
            }
            else
            {
                list = StMethod.GetList<string>("SELECT top 1 TypicalInvoiceType FROM JobList WHERE JobListId=" + Program.GetColorID);
            }

            DataTable jobList = Program.ToDataTable(list);


            if (jobList.Rows.Count > 0)
            {
                DataRow r = jobList.Rows[0];
                if (Convert.ToString(r["TypicalInvoiceType"]) == "Item")
                {
                    ckbItem.Checked = true;
                    ckbTime.Checked = false;
                    ckbExpenses.Checked = true;
                }
                else if (Convert.ToString(r["TypicalInvoiceType"]) == "Time")
                {
                    ckbItem.Checked = ckbTime.Checked == ckbExpenses.Checked == true;
                }

            }
        }
        private void UserSettingEditInvoice()
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
                    MessageBox.Show("VESoftwareSetting.xml file not available in current folder", "InvoiceEditRpt Page Load Setting Error");
                }


                //If (myDoc("VESoftwareSetting")("EditReportSetting")("ckbConvertAssocitedTime").InnerText = "True") Then
                //    ''chkConvertTimeSheet.Checked = True
                //Else
                //    ''chkConvertTimeSheet.Checked = False
                //    cmbConvertTimeSheet.Enabled = False
                //End If
                //'Comment user settings 22 Feb, 2017
                //If (myDoc("VESoftwareSetting")("EditReportSetting")("ExpensesCheck").InnerText = "True") Then
                //    ckbExpenses.Checked = True
                //Else
                //    ckbExpenses.Checked = False
                //End If
                //If (myDoc("VESoftwareSetting")("EditReportSetting")("TimeCheck").InnerText = "True") Then
                //    ckbTime.Checked = True
                //Else
                //    ckbTime.Checked = False
                //End If
                //If (myDoc("VESoftwareSetting")("EditReportSetting")("ItemCheck").InnerText = "True") Then
                //    ckbItem.Checked = True
                //Else
                //    ckbItem.Checked = False
                //End If

                if (typicalInvoiceType == "Item")
                {
                    ckbItem.Checked = true;
                    ckbExpenses.Checked = true;
                    ckbTime.Checked = false;
                }
                else if (typicalInvoiceType == "Time")
                {
                    ckbTime.Checked = true;
                    ckbExpenses.Checked = true;
                    ckbItem.Checked = false;
                }

                //cmbConvertTimeSheet.SelectedIndex = cmbConvertTimeSheet.FindStringExact(myDoc("VESoftwareSetting")("EditReportSetting")("Combovalue").InnerText.ToString())
            }
            catch (Exception ex)
            {

            }
        }
        private void SaveJobListReport(EFDbContext sqlTran = null)
        {
            try
            {
                string Query = "INSERT INTO CRVItemExpensesTime(Jobnumber, InvoiceNo, InvoiceDate, Address, JobDecription, PONO, DueDate, Clienttext) VALUES(@Jobnumber, @InvoiceNo, @InvoiceDate, @Address, @JobDecription, @PONO, @DueDate, @Clienttext)";
                SqlCommand SqlCmd = new SqlCommand(Query);

                SqlCmd.Parameters.AddWithValue("@Jobnumber", Program.GetJobID.ToString());
                SqlCmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text.Trim());
                SqlCmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                SqlCmd.Parameters.AddWithValue("@JobDecription", txtJobDescription.Text.Trim().Trim());
                SqlCmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value.ToString("MM/dd/yyyy"));
                SqlCmd.Parameters.AddWithValue("@Address", CommonUtility.Remove_EmptyLine_Space(txtAddress.Text));
                SqlCmd.Parameters.AddWithValue("@Clienttext", txtphoneNo.Text.Trim());
                //  SqlCmd.Parameters.AddWithValue("@FaxNo", txtFaxNo.Text.Trim)
                //  SqlCmd.Parameters.AddWithValue("@Email", txtEmailAddress.Text.Trim)
                SqlCmd.Parameters.AddWithValue("@PONO", txtPONo.Text.Trim());
                // SqlCmd.Parameters.AddWithValue("@PaymentCr", txtPaymentCr.Text.Trim)
                // SqlCmd.Parameters.AddWithValue("@BalanceDue", txtBalanceDue.Text.Trim)
                sqlTran.Database.ExecuteSqlCommand(SqlCmd.CommandText, SqlCmd.Parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveJobListReportNew(TestVariousInfo_WithDataEntities sqlTran = null)
        {
            try
            {
                string Query = "INSERT INTO CRVItemExpensesTime(Jobnumber, InvoiceNo, InvoiceDate, Address, JobDecription, PONO, DueDate, Clienttext) VALUES(@Jobnumber, @InvoiceNo, @InvoiceDate, @Address, @JobDecription, @PONO, @DueDate, @Clienttext)";
                SqlCommand SqlCmd = new SqlCommand(Query);

                SqlCmd.Parameters.AddWithValue("@Jobnumber", Program.GetJobID.ToString());
                SqlCmd.Parameters.AddWithValue("@InvoiceNo", txtInvoiceNo.Text.Trim());
                SqlCmd.Parameters.AddWithValue("@InvoiceDate", dtpInvoiceDate.Value.ToString("MM/dd/yyyy"));
                SqlCmd.Parameters.AddWithValue("@JobDecription", txtJobDescription.Text.Trim().Trim());
                SqlCmd.Parameters.AddWithValue("@DueDate", dtpDueDate.Value.ToString("MM/dd/yyyy"));
                SqlCmd.Parameters.AddWithValue("@Address", CommonUtility.Remove_EmptyLine_Space(txtAddress.Text));
                SqlCmd.Parameters.AddWithValue("@Clienttext", txtphoneNo.Text.Trim());
                //  SqlCmd.Parameters.AddWithValue("@FaxNo", txtFaxNo.Text.Trim)
                //  SqlCmd.Parameters.AddWithValue("@Email", txtEmailAddress.Text.Trim)
                SqlCmd.Parameters.AddWithValue("@PONO", txtPONo.Text.Trim());
                // SqlCmd.Parameters.AddWithValue("@PaymentCr", txtPaymentCr.Text.Trim)
                // SqlCmd.Parameters.AddWithValue("@BalanceDue", txtBalanceDue.Text.Trim)
                sqlTran.Database.ExecuteSqlCommand(SqlCmd.CommandText, SqlCmd.Parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UpdateInvoiceItem(EFDbContext sqlTran)
        {
            try
            {
                //For Each row As DataGridViewRow In grdRateDetail.Rows
                //    Dim Query As String = "UPDATE JobTracking Set BillState='Invoiced',IsChange=1 WHERE JobListID=" & mdio.GetJobID & " AND BillState='Not Invoiced' AND JobTrackingID=" & grdRateDetail.Rows[row.Index].Cells["JobTrackingID"].Value.ToString
                //    DAL = New DataAccessLayer
                //    DAL.InsertRecord(Query)
                //    DAL.LoginActivityInfo("Update", Me.Name)
                //Next

                StringBuilder xmlString = new StringBuilder("");
                xmlString.Append("<Data>");
                foreach (DataGridViewRow row in grdRateDetail.Rows)
                {
                    xmlString.Append("<Row><JobTrackingID>" + grdRateDetail.Rows[row.Index].Cells["JobTrackingID"].Value.ToString() + "</JobTrackingID></Row>");
                }
                xmlString.Append("</Data>");
                SqlCommand _sqlcmd = new SqlCommand("SP_UpdateConvertInvoiceItem");
                List<SqlParameter> Param = new List<SqlParameter>();

                //Dim Param As New List(Of SqlParameter)
                //Param.Add(DAL.SqlParameter("@xmlString", xmlString.ToString()))
                //Param.Add(DAL.SqlParameter("@billState", "Invoiced"))
                //Param.Add(DAL.SqlParameter("@jobListID", mdio.GetJobID))
                Param.Add(new SqlParameter("@xmlString", xmlString.ToString()));
                Param.Add(new SqlParameter("@billState", "Invoiced"));
                Param.Add(new SqlParameter("@jobListID", Program.GetJobID));

                ////if (sqlTran != null)
                ////{
                ////    _sqlcmd.Transaction = sqlTran;
                ////}
                //////DAL.InsertRecord(_sqlcmd, Param)
                //_sqlcmd.CommandType = CommandType.StoredProcedure;
                //_sqlcmd.ExecuteNonQuery();
                var result = Program.GenerateCommandText("SP_UpdateConvertInvoiceItem", Param.ToArray());
                sqlTran.Database.ExecuteSqlCommand(result, Param.ToArray());
                StMethod.LoginActivityInfo(sqlTran, "Update", this.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void UpdateInvoiceItemNew(TestVariousInfo_WithDataEntities sqlTran)
        {
            try
            {
                //For Each row As DataGridViewRow In grdRateDetail.Rows
                //    Dim Query As String = "UPDATE JobTracking Set BillState='Invoiced',IsChange=1 WHERE JobListID=" & mdio.GetJobID & " AND BillState='Not Invoiced' AND JobTrackingID=" & grdRateDetail.Rows[row.Index].Cells["JobTrackingID"].Value.ToString
                //    DAL = New DataAccessLayer
                //    DAL.InsertRecord(Query)
                //    DAL.LoginActivityInfo("Update", Me.Name)
                //Next

                StringBuilder xmlString = new StringBuilder("");
                xmlString.Append("<Data>");
                foreach (DataGridViewRow row in grdRateDetail.Rows)
                {
                    xmlString.Append("<Row><JobTrackingID>" + grdRateDetail.Rows[row.Index].Cells["JobTrackingID"].Value.ToString() + "</JobTrackingID></Row>");
                }
                xmlString.Append("</Data>");
                SqlCommand _sqlcmd = new SqlCommand("SP_UpdateConvertInvoiceItem");
                List<SqlParameter> Param = new List<SqlParameter>();

                //Dim Param As New List(Of SqlParameter)
                //Param.Add(DAL.SqlParameter("@xmlString", xmlString.ToString()))
                //Param.Add(DAL.SqlParameter("@billState", "Invoiced"))
                //Param.Add(DAL.SqlParameter("@jobListID", mdio.GetJobID))
                Param.Add(new SqlParameter("@xmlString", xmlString.ToString()));
                Param.Add(new SqlParameter("@billState", "Invoiced"));
                Param.Add(new SqlParameter("@jobListID", Program.GetJobID));

                ////if (sqlTran != null)
                ////{
                ////    _sqlcmd.Transaction = sqlTran;
                ////}
                //////DAL.InsertRecord(_sqlcmd, Param)
                //_sqlcmd.CommandType = CommandType.StoredProcedure;
                //_sqlcmd.ExecuteNonQuery();
                var result = Program.GenerateCommandText("SP_UpdateConvertInvoiceItem", Param.ToArray());
                sqlTran.Database.ExecuteSqlCommand(result, Param.ToArray());
                StMethod.LoginActivityInfoNew(sqlTran, "Update", this.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Private Sub UpdateConvertInvoiceItem()
        //    Try
        //        If (cmbConvertTimeSheet.SelectedItem.ToString() <> String.Empty) Then
        //            Dim billst As String = cmbConvertTimeSheet.SelectedItem.ToString()

        //            If (billst.ToString() = "Invoice") Then
        //                billst = "Invoiced"
        //            ElseIf (billst.ToString() = "Ignore") Then
        //                billst = "Ignored"
        //            ElseIf (billst.ToString() = "Not Invoice") Then
        //                billst = "Not Invoiced"
        //            End If

        //            'For Each row As DataGridViewRow In grdRateDetail.Rows
        //            '    Dim Query As String = "UPDATE JobTracking Set BillState ='" & billst.ToString() & "',IsChange=1 WHERE JobListID=" & mdio.GetJobID & " AND BillState='Not Invoiced' AND JobTrackingID=" & grdRateDetail.Rows[row.Index].Cells["JobTrackingID"].Value.ToString
        //            '    DAL = New DataAccessLayer
        //            '    DAL.InsertRecord(Query)
        //            '    DAL.LoginActivityInfo("Update", Me.Name)
        //            'Next

        //            Dim xmlString As New StringBuilder("")
        //            xmlString.Append("<Data>")
        //            For Each row As DataGridViewRow In grdRateDetail.Rows
        //                xmlString.Append("<Row><JobTrackingID>" + grdRateDetail.Rows[row.Index].Cells["JobTrackingID"].Value.ToString() + "</JobTrackingID></Row>")
        //            Next
        //            xmlString.Append("</Data>")

        //            Dim Param As New List(Of SqlParameter)
        //            Param.Add(DAL.SqlParameter("@xmlString", xmlString.ToString()))
        //            Param.Add(DAL.SqlParameter("@billState", billst.ToString()))
        //            Param.Add(DAL.SqlParameter("@jobListID", mdio.GetJobID))
        //            DAL.InsertRecord(New SqlCommand("SP_UpdateConvertInvoiceItem"), Param)
        //            DAL.LoginActivityInfo("Update", Me.Name)
        //        End If
        //    Catch ex As Exception
        //    End Try
        //End Sub

        
        private void UpdateInvoiceTime(EFDbContext sqlTran)
        {
            try
            {
                //For TimeRow As Integer = 0 To grvTime.Rows.Count - 1
                //    Dim queryTime As String = "UPDATE    TS_Time SET  BillState ='Invoice' where TimeSheetID= " & grvTime.Rows[TimeRow].Cells["TimeSheetID"].Value.ToString & ""
                //    DAL = New DataAccessLayer
                //    DAL.InsertRecord(queryTime)
                //Next

                StringBuilder xmlString = new StringBuilder("");
                xmlString.Append("<Data>");
                for (int TimeRow = 0; TimeRow < grvTime.Rows.Count; TimeRow++)
                {
                    xmlString.Append("<Row><TimeSheetID>" + grvTime.Rows[TimeRow].Cells["TimeSheetID"].Value.ToString() + "</TimeSheetID></Row>");

                }
                xmlString.Append("</Data>");
                //Dim Param As New List(Of SqlParameter)
                //Param.Add(DAL.SqlParameter("@xmlString", xmlString.ToString()))
                //Param.Add(DAL.SqlParameter("@billState", "Invoice"))
                //SqlCommand _sqlcmd = new SqlCommand("SP_UpdateConvertInvoiceTime");
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@xmlString", xmlString.ToString()));
                Param.Add(new SqlParameter("@billState", "Invoice"));

                //DAL.InsertRecord(_sqlcmd, Param)
                //_sqlcmd.CommandType = CommandType.StoredProcedure;
                var result = Program.GenerateCommandText("SP_UpdateConvertInvoiceTime", Param.ToArray());
                sqlTran.Database.ExecuteSqlCommand(result, Param.ToArray());
                StMethod.LoginActivityInfo(sqlTran,"Update", this.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void UpdateInvoiceTimeNew(TestVariousInfo_WithDataEntities sqlTran)
        {
            try
            {
                //For TimeRow As Integer = 0 To grvTime.Rows.Count - 1
                //    Dim queryTime As String = "UPDATE    TS_Time SET  BillState ='Invoice' where TimeSheetID= " & grvTime.Rows[TimeRow].Cells["TimeSheetID"].Value.ToString & ""
                //    DAL = New DataAccessLayer
                //    DAL.InsertRecord(queryTime)
                //Next

                StringBuilder xmlString = new StringBuilder("");
                xmlString.Append("<Data>");
                for (int TimeRow = 0; TimeRow < grvTime.Rows.Count; TimeRow++)
                {
                    xmlString.Append("<Row><TimeSheetID>" + grvTime.Rows[TimeRow].Cells["TimeSheetID"].Value.ToString() + "</TimeSheetID></Row>");

                }
                xmlString.Append("</Data>");
                //Dim Param As New List(Of SqlParameter)
                //Param.Add(DAL.SqlParameter("@xmlString", xmlString.ToString()))
                //Param.Add(DAL.SqlParameter("@billState", "Invoice"))
                //SqlCommand _sqlcmd = new SqlCommand("SP_UpdateConvertInvoiceTime");
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@xmlString", xmlString.ToString()));
                Param.Add(new SqlParameter("@billState", "Invoice"));

                //DAL.InsertRecord(_sqlcmd, Param)
                //_sqlcmd.CommandType = CommandType.StoredProcedure;
                var result = Program.GenerateCommandText("SP_UpdateConvertInvoiceTime", Param.ToArray());
                sqlTran.Database.ExecuteSqlCommand(result, Param.ToArray());
                StMethod.LoginActivityInfoNew(sqlTran, "Update", this.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Private Sub UpdateConvertInvoiceTime()
        //    Try
        //        Dim xmlString As New StringBuilder("")
        //        xmlString.Append("<Data>")
        //        For TimeRow As Integer = 0 To grvTime.Rows.Count - 1
        //            xmlString.Append("<Row><TimeSheetID>" + grvTime.Rows[TimeRow].Cells["TimeSheetID"].Value.ToString() + "</TimeSheetID></Row>")

        //            'Dim queryTime As String = "UPDATE    TS_Time SET  BillState ='" & cmbConvertTimeSheet.SelectedItem & "' where TimeSheetID= " & grvTime.Rows[TimeRow].Cells["TimeSheetID"].Value.ToString() & ""
        //            'DAL = New DataAccessLayer
        //            'DAL.InsertRecord(queryTime)

        //        Next
        //        xmlString.Append("</Data>")
        //        Dim Param As New List(Of SqlParameter)
        //        Param.Add(DAL.SqlParameter("@xmlString", xmlString.ToString()))
        //        Param.Add(DAL.SqlParameter("@billState", cmbConvertTimeSheet.SelectedItem.ToString()))
        //        DAL.InsertRecord(New SqlCommand("SP_UpdateConvertInvoiceTime"), Param)
        //    Catch ex As Exception

        //    End Try
        //End Sub
        private void UpdateInvoiceExpenses(EFDbContext sqlTran)
        {
            try
            {
                if (grvExpenses.Rows.Count == 0)
                    return;
                //For ExpRow As Integer = 0 To grvExpenses.Rows.Count - 1
                //    Dim queryExp As String = "UPDATE    TS_Expences SET  BillState ='Invoice' where  TimeSheetExpencesID= " & grvExpenses.Rows[ExpRow].Cells["TimeSheetExpencesID"].Value.ToString() & ""
                //    DAL = New DataAccessLayer
                //    DAL.InsertRecord(queryExp)
                //Next

                StringBuilder xmlString = new StringBuilder("");
                xmlString.Append("<Data>");
                foreach (DataGridViewRow row in grvExpenses.Rows)
                {
                    xmlString.Append("<Row><TimeSheetExpencesID>" + grvExpenses.Rows[row.Index].Cells["TimeSheetExpencesID"].Value.ToString() + "</TimeSheetExpencesID></Row>");
                }
                xmlString.Append("</Data>");

                //Dim Param As New List(Of SqlParameter)
                //Param.Add(DAL.SqlParameter("@xmlString", xmlString.ToString()))
                //Param.Add(DAL.SqlParameter("@billState", "Invoice"))
                //SqlCommand _sqlcmd = new SqlCommand("SP_UpdateConvertInvoiceExpenses");
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@xmlString", xmlString.ToString()));
                Param.Add(new SqlParameter("@billState", "Invoice"));
                var pxmlString = new SqlParameter("xmlString", SqlDbType.Text);
                pxmlString.Value = xmlString.ToString();
                var pbillState = new SqlParameter("billState", SqlDbType.Text);
                pbillState.Value = "Invoice";
                //_sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlTran.Database.ExecuteSqlCommand("exec SP_UpdateConvertInvoiceExpenses @xmlString, @billState", pxmlString,pbillState);
                StMethod.LoginActivityInfo(sqlTran,"Update", this.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void UpdateInvoiceExpensesNew(TestVariousInfo_WithDataEntities sqlTran)
        {
            try
            {
                if (grvExpenses.Rows.Count == 0)
                    return;
                //For ExpRow As Integer = 0 To grvExpenses.Rows.Count - 1
                //    Dim queryExp As String = "UPDATE    TS_Expences SET  BillState ='Invoice' where  TimeSheetExpencesID= " & grvExpenses.Rows[ExpRow].Cells["TimeSheetExpencesID"].Value.ToString() & ""
                //    DAL = New DataAccessLayer
                //    DAL.InsertRecord(queryExp)
                //Next

                StringBuilder xmlString = new StringBuilder("");
                xmlString.Append("<Data>");
                foreach (DataGridViewRow row in grvExpenses.Rows)
                {
                    xmlString.Append("<Row><TimeSheetExpencesID>" + grvExpenses.Rows[row.Index].Cells["TimeSheetExpencesID"].Value.ToString() + "</TimeSheetExpencesID></Row>");
                }
                xmlString.Append("</Data>");

                //Dim Param As New List(Of SqlParameter)
                //Param.Add(DAL.SqlParameter("@xmlString", xmlString.ToString()))
                //Param.Add(DAL.SqlParameter("@billState", "Invoice"))
                //SqlCommand _sqlcmd = new SqlCommand("SP_UpdateConvertInvoiceExpenses");
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@xmlString", xmlString.ToString()));
                Param.Add(new SqlParameter("@billState", "Invoice"));
                var pxmlString = new SqlParameter("xmlString", SqlDbType.Text);
                pxmlString.Value = xmlString.ToString();
                var pbillState = new SqlParameter("billState", SqlDbType.Text);
                pbillState.Value = "Invoice";
                //_sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlTran.Database.ExecuteSqlCommand("exec SP_UpdateConvertInvoiceExpenses @xmlString, @billState", pxmlString, pbillState);
                StMethod.LoginActivityInfoNew(sqlTran, "Update", this.Name);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void fillgrvTime(short Factor = 0)
        {
            try
            {
                string Query = null;
                ////SqlConnection conPCTracker = new SqlConnection(DAL.ConnectionStringPCTracker);
                ////SqlConnection conVariousInfo = new SqlConnection(DAL.ConnectionStringVariousInfo);

                //Query = "SELECT '' as Bye, TimeSheetID, JobListID, EmployeeDetailsId,Date,'' as Item, Description , '' as Qty, Time, '' As Amount  FROM  TS_Time where JobListID=" & jobID & " and BillState='Not Invoice'"

                //Query = "SELECT a.TimeSheetID, '' as bye, a.JobListID, a.EmployeeDetailsId, a.Date,'' as Item, a.Description , '' as Qty, a.Time, b.BillableRate as Rate, (a.Time *  b.BillableRate) as Amount FROM VariousInfo.dbo.Ts_Time a INNER JOIN PCTracker.dbo.EmployeeDetails b ON a.EmployeeDetailsId = b.EmployeeDetailsId   where a.JobListID=" & jobID & " and a.BillState='Not Invoice'"
                //Update 2 June, 2016
                //Removing TrackSubNam column instead I use this function dbo.fn_GetTimeItemDescription().
                //This column give me earlier comment with Track sub name even I update those comment in job track item.

                Query = "SELECT a.TimeSheetID, a.Name as [By], a.JobListID, a.EmployeeDetailsId, a.Date,'' as Item, dbo.fn_GetTimeItemDescription(a.TimeSheetID) as                             TrackSubName , a.Description ,dbo.fn_Factor(b.BillableRate," + txtTimeFactor.Value + "," + Factor + ") as Rate, a.Time as Qty," + "(a.Time *  dbo.fn_Factor(b.BillableRate," + txtTimeFactor.Value + "," + Factor + ")) as Amount" + " FROM  Ts_Time a INNER JOIN EmployeeDetails b ON a.EmployeeDetailsId = b.id AND (b.IsDelete IS NULL OR b.IsDelete=0)  where a.JobListID=" + jobID + " and a.BillState='Not Invoice'";
                //" FROM  " + conVariousInfo.Database + ".dbo.Ts_Time a INNER JOIN " + conPCTracker.Database + ".dbo.EmployeeDetails b ON a.EmployeeDetailsId = b.EmployeeDetailsId  where a.JobListID=" & jobID & " and a.BillState='Not Invoice'"


                if (GbSearchTrackSub.Visible == true)
                {
                    if (!string.IsNullOrEmpty(txtSearchTrackSubComment.Text.Trim()))
                    {
                        Query = Query + "and  a.TrackSubName like '%" + txtSearchTrackSubComment.Text + "%' ";
                    }

                    if (!string.IsNullOrEmpty(txtDescription.Text.Trim()))
                    {
                        Query = Query + "and  a.Description like '%" + txtDescription.Text + "%' ";
                    }


                    if (!string.IsNullOrEmpty(this.cmbUserSearch.Text))
                    {
                        Query = Query + " and a.Name = '" + cmbUserSearch.Text + "'";
                    }

                    if (ckbSearchTime.Checked == true)
                    {

                        if (string.CompareOrdinal(dtpDateSearchTo.Value.ToString("yyyy/MM/dd"), dtpDateSearchFrom.Value.ToString("yyyy/MM/dd")) >= 0)
                        {
                            Query = Query + " AND a.Date BETWEEN '" + dtpDateSearchFrom.Value.ToString("yyyy/MM/dd") + "' AND '" + dtpDateSearchTo.Value.ToString("yyyy/MM/dd") + "'";

                        }
                    }
                }

                DataTable Dt = new DataTable();
                bool find = false;
                Dt = SearchResultInTime(ref find);
                if (!find)
                {
                    
                    //Dt = StMethod.GetListDT<TimeSheetInfo>(Query);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        Dt = StMethod.GetListDTNew<TimeSheetInfo>(Query);
                    }
                    else
                    {
                        Dt = StMethod.GetListDT<TimeSheetInfo>(Query);
                    }

                }

                //Dt.Columns.Add("Rate")

                grvTime.DataSource = Dt;
                //For i As Int32 = 0 To Dt.Rows.Count - 1

                //    Dt.Rows[i).Item("Rate") = "1.00"
                //Next
                bool flag = false;
                if (Dt.Rows.Count > 0)
                {
                    flag = true;
                }

                grvTime.Columns["TimeSheetID"].Visible = false;
                grvTime.Columns["Item"].Visible = false;
                grvTime.Columns["JobListID"].Visible = false;
                grvTime.Columns["EmployeeDetailsId"].Visible = false;
                // grvTime.Columns["Bye"].HeaderText = "By"
                grvTime.Columns["TrackSubName"].Width = 200;
                grvTime.Columns["TrackSubName"].HeaderText = "TrackSub Comments";
                grvTime.Columns["By"].Width = 80;
                grvTime.Columns["Date"].Width = 80;
                grvTime.Columns["Description"].Width = 590;
                grvTime.Columns["Rate"].Width = 80;
                grvTime.Columns["Qty"].Width = 80;
                grvTime.Columns["Amount"].Width = 78;
                //grvTime.Columns["Qty"].Width = 78

                int count = 0;
                double total = 0;
                if (flag == true)
                {
                    for (count = 0; count < grvTime.Rows.Count; count++)
                    {

                        total = total + Convert.ToDouble(Dt.Rows[count]["Amount"].ToString());
                    }
                }
                lblTotalTime.Text = "Total Time:" + Math.Round(total);

            }
            catch (Exception ex)
            {

            }
        }
        private void fillgrvExpenses(short Factor = 0)
        {
            try
            {
                string Query = "SELECT TimeSheetExpencesID, JobListID, EmployeeDetailsId, Name as Bye, Date, '' as Item,  Description, '' as Rate, '' as Qty, dbo.fn_Factor(Expences," + txtFactor.Value + "," + Factor + ") as Amount FROM  TS_Expences where JobListID=" + jobID + " and BillState='Not Invoice'";
                //Query = "SELECT a.TimeSheetExpencesID, a.JobListID, a.EmployeeDetailsId,'' as Bye, a.Date, '' as Item, a.Expences, a.Description, b.BillableRate as Rate, '' as Qty, '' as Amount FROM  TestVariousInfo.dbo.TS_Expences a INNER JOIN PCTracker.dbo.EmployeeDetails b ON a.EmployeeDetailsId = b.EmployeeDetailsId where a.JobListID=" & jobID & " and a.BillState='Not Invoice' "
                DataTable Dt = new DataTable();
                
                //Dt = StMethod.GetListDT<ExpenseData>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    Dt = StMethod.GetListDTNew<ExpenseData>(Query);
                }
                else
                {
                    Dt = StMethod.GetListDT<ExpenseData>(Query);
                }


                grvExpenses.DataSource = Dt;
                bool flag = false;
                if (Dt.Rows.Count > 0)
                {
                    flag = true;
                }

                grvExpenses.Columns["TimeSheetExpencesID"].Visible = false;
                grvExpenses.Columns["JobListID"].Visible = false;
                grvExpenses.Columns["EmployeeDetailsId"].Visible = false;
                grvExpenses.Columns["Date"].Width = 110;
                grvExpenses.Columns["Description"].Width = 980;
                // grvExpenses.Columns["Expences"].HeaderText = "Expenses"
                grvExpenses.Columns["Bye"].HeaderText = "By";
                grvExpenses.Columns["Bye"].Width = 80;
                grvExpenses.Columns["Date"].Width = 80;
                grvExpenses.Columns["Description"].Width = 690;
                grvExpenses.Columns["Rate"].Width = 80;
                // grvExpenses.Columns["Time"].Width = 80
                grvExpenses.Columns["Amount"].Width = 75;
                grvExpenses.Columns["Qty"].Width = 75;

                int count = 0;
                double total = 0;
                if (flag == true)
                {
                    for (count = 0; count < grvExpenses.Rows.Count; count++)
                    {

                        total = total + Convert.ToDouble(Dt.Rows[count]["Amount"].ToString());
                    }
                }
                lblTotalExpenses.Text = " Total Amount:" + Math.Round(total);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private decimal CalculateReduction(decimal rate)
        {
            return Math.Round(rate - (rate * txtItemFactor.Value), 2, System.MidpointRounding.AwayFromZero);
        }
        private decimal CalculateFactor(decimal rate)
        {
            return Math.Round((rate * txtItemFactor.Value), 2, System.MidpointRounding.AwayFromZero);
        }

        private void fillcmbUserSearch()
        {
            try
            {
                DataTable dt = new DataTable();
                //"SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack "

                var data= StMethod.GetMasterItemPM();
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    data = StMethod.GetMasterItemPMNew();

                }
                else
                {
                    data = StMethod.GetMasterItemPM();
                }


                foreach (var item in data)
                {
                    cmbUserSearch.Items.Add(item.cTrack);
                }
            }
            catch (Exception ex)
            {}
        }
        private DataTable SearchResultInTime(ref bool findTimeServiceFee)
        {
            string BulkQuery = "";
            DataTable dt = new DataTable();
            //SqlConnection conPCTracker = new SqlConnection(DAL.ConnectionStringPCTracker);
            //SqlConnection conVariousInfo = new SqlConnection(DAL.ConnectionStringVariousInfo);
            if (grdRateDetail.Rows.OfType<DataGridViewRow>().Any(f => f.Cells["TrackSubName"].Value.ToString().Contains("TimeServiceFee")) && (typicalInvoiceType == "Item" | string.IsNullOrEmpty(typicalInvoiceType)))
            {
                List<DataGridViewRow> rows = grdRateDetail.Rows.OfType<DataGridViewRow>().Where((f) => f.Cells["TrackSubName"].Value.ToString().Contains("TimeServiceFee")).ToList();
                findTimeServiceFee = true;
                int count = 0;
                foreach (DataGridViewRow r in rows)
                {
                    string Query = "";
                    decimal Factor = 1M;
                    string[] comments = r.Cells["Description"].Value.ToString().Split(';', ',');
                    var reduce = comments.Where((f) => f.Contains("Reduce:")).FirstOrDefault().Replace("Reduce:", "").Trim();
                    string deleteTimeItem = r.Cells["DeleteItemTimeService"].Value.ToString();
                    if (Convert.ToDouble(reduce) == 0)
                    {
                        Factor = 0M;
                    }
                    Query = " SELECT a.TimeSheetID, a.Name as [By], a.JobListID, a.EmployeeDetailsId, a.Date,'' as Item, dbo.fn_GetTimeItemDescription(a.TimeSheetID) as                             TrackSubName , a.Description ,dbo.fn_Factor(b.BillableRate," + reduce + "," + Factor + ") as Rate, a.Time as Qty," + "(a.Time *  dbo.fn_Factor(b.BillableRate," + reduce + "," + Factor + ")) as Amount" + " FROM  Ts_Time a INNER JOIN EmployeeDetails b ON a.EmployeeDetailsId = b.id AND ISNULL( b.IsDelete,0)=0 where a.JobListID=" + jobID + " and a.BillState='Not Invoice'";
                    //" FROM  " + conVariousInfo.Database + ".dbo.Ts_Time a INNER JOIN " + conPCTracker.Database + ".dbo.EmployeeDetails b ON a.EmployeeDetailsId =                               b.EmployeeDetailsId  where a.JobListID=" & jobID & " and a.BillState='Not Invoice'"

                    string TrackSubcommentSerchtext = comments.Where((f) => f.Contains("Comment:")).FirstOrDefault().Replace("Comment:", "").Trim();
                    //'txtSearchTrackSubComment.Text = TrackSubcommentSerchtext

                    string txtDescriptionSearchText = comments.Where((f) => f.Contains("Descr:")).FirstOrDefault().Replace("Descr:", "").Trim();
                    //'txtDescription.Text = txtDescriptionSearchText

                    Query = Query + "and  a.TrackSubName like '%" + TrackSubcommentSerchtext + "%' ";

                    Query = Query + "and  a.Description like '%" + txtDescriptionSearchText + "%' ";
                    if (!string.IsNullOrEmpty(deleteTimeItem))
                    {
                        Query = Query + "and  a.TimeSheetID NOT IN (" + deleteTimeItem + ")";
                    }
                    string name = comments.Where((f) => f.Contains("By:")).FirstOrDefault().Replace("By:", "").Trim();
                    string dateFrom = comments.Where((f) => f.Contains("From:")).FirstOrDefault().Replace("From:", "").Trim();
                    string dateTo = comments.Where((f) => f.Contains("To:")).FirstOrDefault().Replace("To:", "").Trim();

                    if (!string.IsNullOrEmpty(name))
                    {
                        Query = Query + " and a.Name = '" + name + "'";
                    }
                    if (!string.IsNullOrEmpty(dateFrom) || !string.IsNullOrEmpty(dateTo))
                    {
                        Query = Query + " AND a.Date BETWEEN '" + dateFrom + "' AND '" + dateTo + "' ";
                    }
                    if (count == 0)
                    {
                        BulkQuery = Query;
                    }
                    else
                    {
                        BulkQuery = BulkQuery + "\r\n" + " UNION " + "\r\n" + Query;
                    }

                    count = count + 1;
                }

                //dt = StMethod.GetListDT<string>(BulkQuery);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<string>(BulkQuery);
                }
                else
                {
                    dt = StMethod.GetListDT<string>(BulkQuery);
                }


                return dt;
            }
            return dt;
        }

        private decimal GetLatestInvoiceDetailId(EFDbContext sqltran)
        {
            return sqltran.Database.SqlQuery<decimal> ("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail").FirstOrDefault();
        }

        private decimal GetLatestInvoiceDetailIdNew(TestVariousInfo_WithDataEntities sqltran)
        {
            return sqltran.Database.SqlQuery<decimal>("SELECT MAX(JobTrackDetailID) FROM JobTrackInvoiceDetail").FirstOrDefault();
        }

        //Bulk function replacing with this, for enable transaction on item inserting of invoice.
        private void InsertInvoiceItems(string tableName, DataTable dt, EFDbContext sqltran)
        {
            string[] columnNames = dt.Columns.Cast<DataColumn>().Select((s) => s.ColumnName).ToArray();
            string[] paramVar = columnNames.Select((s) => string.Format("@{0}", s)).ToArray();
            
            string query = string.Format("INSERT INTO {0} ({1}) VALUES({2})", tableName, string.Join(",", columnNames), string.Join(",", paramVar));
            foreach (DataRow dr in dt.Rows)
            {
                SqlCommand _cmd = new SqlCommand(query);
                //_cmd.Transaction = sqltran;
                List<SqlParameter> param = new List<SqlParameter>();
                foreach (string col in columnNames)
                {
                    //_cmd.Parameters.Add(new SqlParameter("@" + col, dr[col]));
                    
                    param.Add(new SqlParameter("@" + col, dr[col]));
                }
                //_cmd.ExecuteNonQuery();
                //sqltran.Database.ExecuteSqlCommand(_cmd.CommandText, _cmd.Parameters);
                sqltran.Database.ExecuteSqlCommand(query, param.ToArray());
            }
        }

        private void InsertInvoiceItemsNew(string tableName, DataTable dt, TestVariousInfo_WithDataEntities sqltran)
        {
            string[] columnNames = dt.Columns.Cast<DataColumn>().Select((s) => s.ColumnName).ToArray();
            string[] paramVar = columnNames.Select((s) => string.Format("@{0}", s)).ToArray();

            string query = string.Format("INSERT INTO {0} ({1}) VALUES({2})", tableName, string.Join(",", columnNames), string.Join(",", paramVar));
            foreach (DataRow dr in dt.Rows)
            {
                SqlCommand _cmd = new SqlCommand(query);
                //_cmd.Transaction = sqltran;
                List<SqlParameter> param = new List<SqlParameter>();
                foreach (string col in columnNames)
                {
                    //_cmd.Parameters.Add(new SqlParameter("@" + col, dr[col]));

                    param.Add(new SqlParameter("@" + col, dr[col]));
                }
                //_cmd.ExecuteNonQuery();
                //sqltran.Database.ExecuteSqlCommand(_cmd.CommandText, _cmd.Parameters);
                sqltran.Database.ExecuteSqlCommand(query, param.ToArray());
            }
        }

        #endregion
    }
}