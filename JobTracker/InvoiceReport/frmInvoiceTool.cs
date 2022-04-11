//using Common;
using Commen2;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.InvoiceReport
{
    public partial class frmInvoiceTool : Form
    {
        #region Declaration
        BackgroundWorker bw;
        List<TSTime> rNfo = new List<TSTime>();
        double veCostM = 0;
        double revenueM = 0;
        string username = null;
        //MethodInvoker callBindGrid;//= new MethodInvoker(GetTimeData());
        //public event DoWorkEventHandler DoWork;
        //public event ProgressChangedEventHandler ProgressChanged;
        //private event RunWorkerCompletedEventHandler workComplete;
        #endregion
        public frmInvoiceTool()
        {
            //callBindGrid = new MethodInvoker(GetTimeData());
            // This call is required by the designer.
            InitializeComponent();
            initPM();
        }

        #region Events

        private void frmInvoiceTool_Load(object sender, EventArgs e)
        {
            bw = new BackgroundWorker();
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork += bw_DoWork;
            bw.ProgressChanged += bw_ProgressChanged;
            bw.RunWorkerCompleted += bw_RunWorkerCompleted;
            //GetTimeData();
        }

        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            // Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
            GetTimeData();
            // Me.Invoke(callBindGrid)
        }

        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            { 
            TSTime Data = (TSTime)e.UserState;
            this.grdInvoice.Rows.Add(Data.JobNumber, Data.InvoiceNo, Data.InvoiceDate.ToString("MM/dd/yyyy"), Data.DateAdded.ToString("MM/dd/yyyy"), Data.Handler, Data.VeCost, Data.Revenue, Data.Difference);
                // If Not Data.DateAdded.Date = DateTime.Now.Date Then
                // Me.grdInvoice.Rows(grdInvoice.RowCount - 1).Visible = False
                // End If
            }
            finally
            {

            }

        }

        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.lblDifference.Text = "Difference : " + Math.Round(revenueM - veCostM, 2).ToString("C2");
            this.lblRevienue.Text = "Revenue : " + Math.Round(revenueM, 2).ToString("C2");
            this.lblTotalVeCost.Text = "Ve Cost : " + Math.Round(veCostM, 2).ToString("C2");
            // RemoveHandler dtpDateSearchTo.ValueChanged, AddressOf dtpDateSearchTo_ValueChanged
            dtpDateSearchFrom.ValueChanged -= dtpDateSearchFrom_ValueChanged;
            // Me.dtpDateSearchFrom.Value = DateTime.Now
            // Me.dtpDateSearchTo.Value = DateTime.Now
            // AddHandler dtpDateSearchTo.ValueChanged, AddressOf dtpDateSearchTo_ValueChanged
            dtpDateSearchFrom.ValueChanged += dtpDateSearchFrom_ValueChanged;
            this.Cursor = Cursors.Default;
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            username = this.txtPM.Text.Trim();
            bw.RunWorkerAsync();
        }

        //private static frmInvoiceTool _Instance;

        //public static frmInvoiceTool Instance
        //{
        //    get
        //    {
        //        if (_Instance is null || _Instance.IsDisposed)
        //        {
        //            _Instance = new frmInvoiceTool();
        //        }

        //        return _Instance;
        //    }
        //}

        private void txtPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If Me.grdInvoice.RowCount > 0 Then
            // Me.Filter()
            // End If
        }

        private void txtJobNo_TextChanged(object sender, EventArgs e)
        {
            // If Me.grdInvoice.RowCount > 0 Then
            // Me.Filter()
            // End If
        }

        private void grdInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtpDateSearchFrom_ValueChanged(object sender, EventArgs e)
        {
            // 'Me.dtpDateSearchTo.MinDate = Me.dtpDateSearchFrom.Value
            // 'dtpDateSearchTo.Select()
            // 'SendKeys.Send("%{DOWN}")
            // If Me.grdInvoice.RowCount > 0 Then
            // Me.Filter()
            // End If
        }

        private void dtpDateSearchTo_ValueChanged(object sender, EventArgs e)
        {
            // If Me.grdInvoice.RowCount > 0 Then
            // Me.Filter()
            // End If
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            this.grdInvoice.Rows.Clear();
            this.txtPM.Text = string.Empty;
            this.txtInvoiceNO.Text = string.Empty;
            this.txtPM.SelectedIndex = -1;
            this.txtJobNo.Text = string.Empty;
            this.lblTotalVeCost.Text = "VeCost :";
            this.lblRevienue.Text = "Revenue :";
            this.lblDifference.Text = "Difference :";
            chkDateAdd.CheckState = CheckState.Unchecked;
            this.Cursor = Cursors.WaitCursor;
            username = this.txtPM.Text.Trim();
            bw.CancelAsync();
            bw.RunWorkerAsync();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                this.lblTotalVeCost.Text = "VeCost :";
                this.lblRevienue.Text = "Revenue :";
                this.lblDifference.Text = "Difference :";
                this.grdInvoice.Rows.Clear();

                this.Cursor = Cursors.WaitCursor;
                username = this.txtPM.Text.Trim();
                bw.CancelAsync();
                bw.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool Enable = chkDateAdd.CheckState == CheckState.Checked;
            this.dtpDateSearchFrom.Enabled = Enable;
            this.dtpDateSearchTo.Enabled = Enable;
        }
        #endregion

        #region Methods
        private List<TSTime> GetTimeData()
        {

            
            grdInvoice.Rows.Clear();
            var jobList = new List<TSTime>();
            rNfo.Clear();
            veCostM = 0d;
            revenueM = 0d;
            try
            {
                string where;
                if (string.IsNullOrEmpty(this.txtJobNo.Text.Trim()))
                {
                    where = "";
                }
                else
                {
                    where = "where jl.JobNumber like '%" + this.txtJobNo.Text.Trim() + "%' ";
                }

                DateTime? SearchFrom = null;
                DateTime? SearchTo = null;

                if (chkDateAdd.CheckState == CheckState.Checked)
                {
                    if (!string.IsNullOrEmpty(where))
                    {
                        where = where + " and DateAdded >= '" + dtpDateSearchFrom.Value.Date.ToString("yyyy-MM-dd") + "' and DateAdded <='" + dtpDateSearchTo.Value.Date.ToString("yyyy-MM-dd") + "' ";
                    }
                    else
                    {
                        where = " where DateAdded >= '" + dtpDateSearchFrom.Value.Date.ToString("yyyy-MM-dd") + "' and DateAdded <='" + dtpDateSearchTo.Value.Date.ToString("yyyy-MM-dd") + "' ";
                        SearchTo = dtpDateSearchTo.Value;
                        SearchFrom = dtpDateSearchFrom.Value;
                    }
                }

                if (!string.IsNullOrEmpty(username))
                {
                    if (!string.IsNullOrEmpty(where))
                    {
                        where = where + " and tt.Name like '%" + username + "%' ";
                    }
                    else
                    {
                        where = "where tt.Name like '%" + username + "%' ";
                    }
                }

                string queryString = string.Format("select jl.JobListID,jl.JobNumber,jl.Handler,tt.Name,tt.Time,jl.DateAdded from JobList jl inner join TS_Time tt on jl.JobListID = tt.JobListID {0}", where);
                //var con = new SqlClient.SqlConnection(DAL.ConnectionStringPCTracker);
                var empDetails = new List<EmployeeDetails>();
                var revenueInfo = new List<TSTime>();


                DataTable invoiceDetail = StMethod.GetTimeData(txtJobNo.Text, username, txtInvoiceNO.Text, SearchFrom, SearchTo);
                //DataTable invoiceDetail = StMethod.GetListDT<string>(" EXEC SP_GetInvoiceDetailByJobNumber_All_New", Param,StMethod.eDatabase.PCTracker);
                var invoiceDetails = new List<Invoice_Details>();

                try
                { 

                foreach (DataRow row in invoiceDetail.Rows)
                {
                    Invoice_Details invoice = new Invoice_Details();
                    if (!Convert.IsDBNull(row["Byname"]))
                    {
                        invoice.Byname = row["Byname"].ToString();
                    }

                    if (!Convert.IsDBNull(row["InvoiceDate"]))
                    {


                            //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                            //invoice.InvoiceDate = Convert.ToDateTime(row["InvoiceDate"]);

                            //invoice.InvoiceDate = Convert.ToDateTime((DateTime.Parse(row["InvoiceDate"].ToString())).ToString("MM/d/yyyy"));

                            //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                            //invoice.InvoiceDate = DateTime.Parse((DateTime.Parse(row["InvoiceDate"].ToString())).ToString("DD/MM/yyyy"));


                            //invoice.InvoiceDate = Convert.ToDateTime(row["InvoiceDate"].ToString());
                            //invoice.InvoiceDate = Convert.ToDateTime(row["InvoiceDate"]);
                        }

                    if (!Convert.IsDBNull(row["InvoiceNo"]))
                    {
                        invoice.InvoiceNo = Convert.ToString(row["InvoiceNo"]);
                    }

                    if (!Convert.IsDBNull(row["DueDate"]))
                    {
                            //string formatted = row["DueDate"].ToString("dd-MM-yyyy");

                            //string formatted = date.ToString("dd-MM-yyyy");

                            //invoice.DueDate = DateTime.Parse((DateTime.Parse(row["InvoiceDate"].ToString())).ToString("MM/dd/yyyy"));

                            invoice.DueDate = Convert.ToDateTime(row["DueDate"].ToString());

                            //invoice.DueDate = Convert.ToDateTime(row["DueDate"]);
                        }

                    if (!Convert.IsDBNull(row["Expenses"]) && NumericHelper.IsNumeric(row["Expenses"]))
                    {
                        invoice.Expenses = Convert.ToDouble(row["Expenses"]);
                    }

                    if (!Convert.IsDBNull(row["Hrs"]) && NumericHelper.IsNumeric(row["Hrs"]))
                    {
                        invoice.Hrs = Convert.ToDouble(row["Hrs"]);
                    }
                    if (!Convert.IsDBNull(row["InvoiceNo"]))
                    {
                        invoice.InvoiceNo = row["InvoiceNo"].ToString();
                    }

                    if (!Convert.IsDBNull(row["JobTrackDetailID"]) && NumericHelper.IsNumeric(row["JobTrackDetailID"]))
                    {
                        invoice.JobTrackDetailID = Convert.ToInt64(row["JobTrackDetailID"]);
                    }

                    if (!Convert.IsDBNull(row["PaymentCr"]) && NumericHelper.IsNumeric(row["PaymentCr"]))
                    {
                        invoice.PaymentCr = Convert.ToDouble(row["PaymentCr"]);
                    }

                    if (!Convert.IsDBNull(row["Rate"]) && NumericHelper.IsNumeric(row["Rate"]))
                    {
                        invoice.Rate = Convert.ToDouble(row["Rate"]);
                    }

                    if (!Convert.IsDBNull(row["ReportType"]))
                    {
                        invoice.ReportType = row["ReportType"].ToString();
                    }

                    if (!Convert.IsDBNull(row["JobNumber"]))
                    {
                        invoice.JobNumber = row["JobNumber"].ToString();
                    }
                    invoiceDetails.Add(invoice);
                }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                invoiceDetail.Dispose();
                invoiceDetail = default;
                where = "";
                if (!string.IsNullOrEmpty(username))
                {
                    where = "where username like '%" + username + "%'";
                }

                //DataTable emp_details = DAL.Filldatatable(string.Format("use {0} select UserName,BillableRate FROM EmployeeDetails {1}", con.Database, where));
                DataTable emp_details = StMethod.GetListDT<dtoUserBillRate>(string.Format("Select UserName,BillableRate FROM EmployeeDetails {0}", where));
                foreach (DataRow row in emp_details.Rows)
                {
                    var emp = new EmployeeDetails();
                    if (!Information.IsDBNull(row["UserName"]))
                    {
                        emp.UserName = row["UserName"].ToString();
                    }

                    if (!Information.IsDBNull(row["BillableRate"]) & Information.IsNumeric(row["BillableRate"]))
                    {
                        emp.BillableRate = Convert.ToDouble(row["BillableRate"]);
                    }
                    empDetails.Add(emp);
                }

                emp_details.Dispose();
                emp_details = default;
                DataTable dtJL = StMethod.GetListDT<dtoJobTime>(queryString);
                foreach (DataRow row in dtJL.Rows)
                {
                    // jobList.Add(New TSTime()
                    var rw = new TSTime();
                    if (!Information.IsDBNull(row["DateAdded"]))
                    {
                        rw.DateAdded = Convert.ToDateTime(row["DateAdded"]);
                    }

                    if (!Information.IsDBNull(row["JobNumber"]))
                    {
                        rw.JobNumber = row["JobNumber"].ToString();
                    }

                    if (!Information.IsDBNull(row["JobListID"]) & Information.IsNumeric(row["JobListID"]))
                    {
                        rw.JobListId = Convert.ToInt64(row["JobListID"].ToString());
                    }

                    if (!Information.IsDBNull(row["Name"]))
                    {
                        rw.Name = row["Name"].ToString();
                    }

                    if (!Information.IsDBNull(row["Time"]) & Information.IsNumeric(row["Time"]))
                    {
                        rw.Time = Convert.ToDouble(row["Time"].ToString());
                    }

                    if (!Information.IsDBNull(row["Handler"]))
                    {
                        rw.Handler = row["Handler"].ToString();
                    }

                    double rate = Conversions.ToDouble((from emp in empDetails
                                                        where emp.UserName.Equals(rw.Name)
                                                        select emp.BillableRate).FirstOrDefault());
                    if (rate > 0d)
                    {
                        rw.VeCost = rw.Time * rate;
                        // Dim veCost As Double = (From invoice In invoiceDetails Where rw.JobNumber = invoice.JobNumber And String.IsNullOrWhiteSpace(rw.Time) Select 
                    }
                    // rw.VeCost = rw.Revenue  + rw. 

                    revenueInfo.Add(rw);
                }

                dtJL.Dispose();
                dtJL = default;
                // Dim inv As InvoiceDetail
                if (invoiceDetails.Count > 0)
                {
                    double veCost;
                    double revenue;
                    string handler;
                    Invoice_Details inv;
                    List<string> jobnos = invoiceDetails.Select(a => a.JobNumber).Distinct().ToList();
                    // (From rec In invoiceDetails
                    // Select rec.JobNumber).Distinct().ToList()
                    foreach (string jobno in jobnos)
                    {
                        // invs = invoiceDetails.Where(Function(i) i.JobNumber.Equals(jobno))
                        TSTime ajlst = revenueInfo.FirstOrDefault(d => d.JobNumber.Equals(jobno));
                        // Dim addedDate As DateTime =
                        veCost = revenueInfo.Where((f) => f.JobNumber == jobno).Sum((a) => a.VeCost);
                        revenue = invoiceDetails.Where((f) => f.JobNumber == jobno).Sum((a) => a.Expenses + (a.Hrs * a.Rate));

                        handler = revenueInfo.Where((f) => f.JobNumber == jobno).Select((s) => s.Handler).FirstOrDefault();
                        foreach (string invNo in invoiceDetails.Where(i => i.JobNumber.Equals(jobno)).Select(g => g.InvoiceNo).Distinct())
                        {
                            // Dim add As Boolean
                            var item = new TSTime();
                            if (ajlst is object)
                            {
                                // If Me.CheckBox1.CheckState = CheckState.Checked Then
                                // add = (ajlst.DateAdded >= Me.dtpDateSearchFrom.Value.Date And ajlst.DateAdded <= Me.dtpDateSearchTo.Value.Date)
                                // If Not add Then
                                // Continue For
                                // End If

                                // End If
                                item.DateAdded = ajlst.DateAdded;
                            }

                            // add = (txtJobNo.Text.Trim() = String.Empty Or jobno.Contains(txtJobNo.Text))
                            // If Not add Then
                            // Continue For
                            // End If
                            inv = invoiceDetails.FirstOrDefault(i => i.JobNumber.Equals(jobno) & i.InvoiceNo.Equals(invNo));
                            // add = (txtInvoiceNO.Text.Trim() = String.Empty Or inv.InvoiceNo.Contains(txtInvoiceNO.Text))
                            // If Not add Then
                            // Continue For
                            // End If
                            // veCost = revenueInfo.Where(Function(f) f.JobNumber = jobno And f.InvoiceNo.Equals(invNo)).Sum(Function(a) a.VeCost)
                            // revenue = invoiceDetails.Where(Function(f) f.JobNumber = jobno And f.InvoiceNo.Equals(invNo)).Sum(Function(a) a.Expenses + (a.Hrs * a.Rate))
                            // Dim inv = invoiceDetails.inv     '(Function(i) i.JobNumber.Equals(jobno))
                            // ' Dim jobNo As String = item.JobNumber

                            item.VeCost = veCost;
                            item.Revenue = revenue;
                            item.JobNumber = jobno;
                            item.Handler = handler;
                            item.DueDate = inv.DueDate;
                            item.InvoiceDate = inv.InvoiceDate;
                            item.InvoiceNo = inv.InvoiceNo;
                            rNfo.Add(item);
                            // Me.grdInvoice.Rows.Add(item.JobNumber, item.VeCost, item.Revenue, item.Difference)
                            bw.ReportProgress(1, item);
                        }

                        veCostM += veCost;
                        revenueM += revenue;
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return default;
        }
        private bool initPM()
        {
            try
            {
                DataTable dt1 = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                for (int I = 0, loopTo = dt1.Rows.Count - 1; I <= loopTo; I++)
                    txtPM.Items.Add(dt1.Rows[I]["cTrack"].ToString());
            }
            catch (Exception ex)
            {
            }

            return default;
        }
        private void Filter()
        {
            DateTime invoiceDate;
            revenueM = 0d;
            veCostM = 0d;
            foreach (DataGridViewRow row in this.grdInvoice.Rows)
            {
                row.Visible = true;
                if (this.chkDateAdd.CheckState == CheckState.Checked)
                {
                    if (row.Cells["AddedDate"].Value is null)
                    {
                        row.Visible = false;
                    }
                    else
                    {
                        invoiceDate = Convert.ToDateTime(row.Cells["AddedDate"].Value);
                        row.Visible = row.Visible & invoiceDate >= this.dtpDateSearchFrom.Value.Date & invoiceDate <= this.dtpDateSearchTo.Value.Date;
                    }
                }

                if (row.Cells["JobNo"].Value is null)
                {
                    row.Visible = false;
                }
                else
                {
                    row.Visible = row.Visible & (txtJobNo.Text.Trim() == string.Empty | row.Cells["JobNo"].Value.ToString().Contains(txtJobNo.Text));
                }

                if (row.Cells["InvoiceNo"].Value is null)
                {
                    row.Visible = false;
                }
                else
                {
                    row.Visible = row.Visible & (txtInvoiceNO.Text.Trim() == string.Empty | row.Cells["InvoiceNo"].Value.ToString().Contains(txtInvoiceNO.Text));
                }

                if (row.Cells["PM"].Value is null)
                {
                    row.Visible = false;
                }
                else if (txtPM.SelectedIndex > 0)
                {
                    row.Visible = row.Visible & row.Cells["PM"].Value.ToString() == txtPM.SelectedItem.ToString();
                }

                if (row.Visible)
                {
                    revenueM += Convert.ToDouble(row.Cells["Revienu"].Value);
                    veCostM += Convert.ToDouble(row.Cells["VeCost"].Value);
                }
            }

            this.lblDifference.Text = "Difference : $" + Math.Round(revenueM - veCostM, 2).ToString();
            this.lblRevienue.Text = "Revenue : $" + Math.Round(revenueM, 2).ToString();
            this.lblTotalVeCost.Text = "Ve Cost : $" + Math.Round(veCostM, 2).ToString();
        }
        #endregion

        private void grdInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //MessageBox.Show("Column number is " + e.ColumnIndex + "Value is " + e.Value);

                if (e.ColumnIndex == 2)
                {
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

                if (e.ColumnIndex == 3)
                {
                    //e.Value = "MM-dd-yyyy";

                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

                    if ((value != null))
                    {
                        //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/dd/yyyy");
                        //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("dd/MM/yyyy");
                        e.FormattingApplied = true;

                    }
                    else
                    {
                        e.Value = e.CellStyle.NullValue;
                        e.FormattingApplied = true;
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
