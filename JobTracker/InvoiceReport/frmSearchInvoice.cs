//using Common;
//using Commen2;
using Commen2;
using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
//using Excel = Microsoft.Office.Interop.Excel;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
//using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports.Engine;

namespace JobTracker.InvoiceReport
{
    public partial class frmSearchInvoice : Form
    {
        #region Declaration
        string CheckString = null;
        bool ExportStatus = false;
        //XSSFWorkbook workBook = new XSSFWorkbook();
        HSSFWorkbook workBook = new HSSFWorkbook();


        int GrandToal = 0;
        int FinalTotal = 0;

        #endregion
        public frmSearchInvoice()
        {
           InitializeComponent();
        }

        #region Events
        private void btnSearch_Click(System.Object sender, System.EventArgs e)
        {
            FillInvoiceDetail();
        }
        private void chkBoxActiveDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (chkBoxActiveDate.Checked == true)
            {
                pnlDate.Enabled = true;
            }
            else
            {
                pnlDate.Enabled = false;
            }
        }
        private void frmSearchInvoice_Load(System.Object sender, System.EventArgs e)
        {
            pnlDate.Enabled = false;
            //DAL = new DataAccessLayer();
            //sqlCon = DAL.sqlcon;
        }
        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            foreach (Control textBox in pnlSearchItem.Controls)
            {
                if (textBox is TextBox)
                {
                    textBox.Text = string.Empty;
                }
                chkBoxActiveDate.Checked = false;
            }
        }

        private void btnPreview_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

            DataTable rptInvoiceDt = new DataTable();
            ReportDocument Rpt = null;
            //ReportDocument Rpt;

            if (btnPreview.Text == "Show Report")
            {
                Rpt = new ReportDocument();
                btnPrintReport.Enabled = true;
                pnlgrdRateDetail.Visible = false;
                btnPreview.Text = "Close Report";

                if (grdSearchDetailInvoice.Rows.Count == 0)
                {
                    return;
                }
                //rptInvoiceDt = GetAllReport(Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value), grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());

                rptInvoiceDt = GetAllReport(Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value), grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());


                if (rptInvoiceDt.Rows.Count == 0)
                {
                    KryptonMessageBox.Show("Record Not found");
                }
                else
                {
                    try
                    {
                        string ReportPath = Application.StartupPath + "\\Reports\\JTSearchAllGroupBy.rpt";
                        //string ReportPath = Application.StartupPath + "\\InvoiceReport\\JTSearchAllGroupBy.rpt";
                        Rpt.Load(ReportPath);
                        Rpt.SetDataSource(rptInvoiceDt);
                        XmlDocument myDoc = new XmlDocument();
                        try
                        {
                            myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                            Rpt.SetParameterValue("CompanyAddress", myDoc["VESoftwareSetting"]["ComapanyAddress"]["Address"].InnerText);
                            Rpt.SetParameterValue("CompanyPhoneNo", myDoc["VESoftwareSetting"]["ComapanyAddress"]["PhoneNo"].InnerText);
                            Rpt.SetParameterValue("CompanyFax", myDoc["VESoftwareSetting"]["ComapanyAddress"]["FaxNo"].InnerText);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                        CRVInvoice.ReportSource = Rpt;
                        myDoc = null;

                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Invoice Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                btnPreview.Text = "Show Report";
                btnPrintReport.Enabled = false;
                pnlgrdRateDetail.BringToFront();
                pnlgrdRateDetail.Visible = true;
                Rpt = null;
                rptInvoiceDt.Dispose();
                //GC.Collect()
            }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void txtJobNumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            FillInvoiceDetail();
        }
        private void grdSearchDetailInvoice_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > -1 || e.RowIndex > -1)
            {
                CheckString = string.Empty;
                CheckString = grdSearchDetailInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            }
            grdSearchDetailInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.WrapMode = DataGridViewTriState.True;
            grdSearchDetailInvoice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void grdSearchDetailInvoice_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {

               //MessageBox.Show(grdSearchDetailInvoice.Columns[e.ColumnIndex].HeaderText.ToString());

               //MessageBox.Show(grdSearchDetailInvoice.Columns[e.ColumnIndex].ToString());


                int JobTrakDtlID = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);
                FillRateInvocieDetail(JobTrakDtlID);
                FillTimeRateInvoiveDetail(JobTrakDtlID, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                FillExpecesRateInvoiceDetail(JobTrakDtlID, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());

                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    UpdateInvoiceDetail();

                    // Commented above line and copy code of that sub below







                }
                if (e.ColumnIndex == 1 && e.RowIndex > -1)
                {
                    UndoAndDelete(Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value), false);
                    KryptonMessageBox.Show("Delete Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillInvoiceDetail();

                    //StMethod.LoginActivityInfo("Delete", this.Name);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.LoginActivityInfoNew("Delete", this.Name);
                    }
                    else
                    {
                        StMethod.LoginActivityInfo("Delete", this.Name);
                    }
                }

                if (e.ColumnIndex == 2 && e.RowIndex > -1)
                {
                    UndoAndDelete(Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value), true);
                    KryptonMessageBox.Show("Undo Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FillInvoiceDetail();

                    //StMethod.LoginActivityInfo("Undo", this.Name);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.LoginActivityInfoNew("Undo", this.Name);
                    }
                    else
                    {
                        StMethod.LoginActivityInfo("Undo", this.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdSearchDetailInvoice_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.Rows.Count - 1].Cells["JobTrackDetailID"].Value.ToString()) == 0)
                    {
                        return;
                    }
                    if (grdSearchDetailInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grdSearchDetailInvoice.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grdSearchDetailInvoice.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
                grdSearchDetailInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.WrapMode = DataGridViewTriState.False;
                grdSearchDetailInvoice.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                grdSearchDetailInvoice.Rows[e.RowIndex].DefaultCellStyle.WrapMode = DataGridViewTriState.False;

                String value2 = grdSearchDetailInvoice.Rows[e.RowIndex].Cells[6].Value.ToString() as string;

                if (e.ColumnIndex == 6)
                {

                    if ((value2 != null) && (value2 != string.Empty))
                    {
                        string inputString = "2000-02-02";

                        DateTime dDate = DateTime.Now;

                        inputString = string.Format("{0:MM/d/yyyy}", value2);
                        inputString = value2.ToString() + " 12:00:00 AM";

                        inputString = value2.ToString();



                        if (DateTime.TryParse(inputString, out dDate))
                        {

                            value2 = string.Format("{0:MM/dd/yyyy}", dDate);

                            string temp = string.Format("{0:dd/MM/yyyy}", value2);

                            //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
                            grdSearchDetailInvoice.Rows[e.RowIndex].Cells[6].Value = value2;
                            grdSearchDetailInvoice.Rows[e.RowIndex].Cells[6].Tag = inputString;
                        }
                        else
                        {
                            grdSearchDetailInvoice.Rows[e.RowIndex].Cells[6].Tag = inputString;


                        }
                    }
                    else
                    {
                        //e.Value = e.CellStyle.NullValue;
                        //e.FormattingApplied = true;
                    }

                }


                String value3 = grdSearchDetailInvoice.Rows[e.RowIndex].Cells[8].Value.ToString() as string;

                if (e.ColumnIndex == 8)
                {

                    if ((value3 != null) && (value3 != string.Empty))
                    {
                        string inputString = "2000-02-02";

                        DateTime dDate = DateTime.Now;

                        inputString = string.Format("{0:MM/d/yyyy}", value3);
                        inputString = value3.ToString() + " 12:00:00 AM";

                        inputString = value3.ToString();



                        if (DateTime.TryParse(inputString, out dDate))
                        {

                            value3 = string.Format("{0:MM/dd/yyyy}", dDate);

                            string temp = string.Format("{0:dd/MM/yyyy}", value3);

                            //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
                            grdSearchDetailInvoice.Rows[e.RowIndex].Cells[8].Value = value3;
                            grdSearchDetailInvoice.Rows[e.RowIndex].Cells[8].Tag = inputString;
                        }
                        else
                        {
                            grdSearchDetailInvoice.Rows[e.RowIndex].Cells[8].Tag = inputString;


                        }
                    }
                    else
                    {
                        //e.Value = e.CellStyle.NullValue;
                        //e.FormattingApplied = true;
                    }

                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdSearchRateInvoice_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grdSearchRateInvoice.Rows[grdSearchRateInvoice.Rows.Count - 1].Cells["InvoiceRptID"].Value.ToString()) == 0)
                    {
                        return;
                    }
                    if (grdSearchRateInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grdSearchRateInvoice.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grdSearchRateInvoice.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdSearchRateInvoice_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > -1 || e.RowIndex > -1)
            {
                CheckString = string.Empty;
                CheckString = grdSearchRateInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
        private void grdSearchRateInvoice_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                UpdateRateDetail();
            }
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                //int i = StMethod.UpdateRecord("DELETE FROM JobTrackInvoiceRateDetail WHERE InvoiceRptID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["InvoiceRptID"].Value.ToString());

                int i;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    i = StMethod.UpdateRecordNew("DELETE FROM JobTrackInvoiceRateDetail WHERE InvoiceRptID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["InvoiceRptID"].Value.ToString());
                }
                else
                {
                    i = StMethod.UpdateRecord("DELETE FROM JobTrackInvoiceRateDetail WHERE InvoiceRptID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["InvoiceRptID"].Value.ToString());

                }

                //StMethod.UpdateRecord("if (SELECT COUNT(JobTrackDetailID) FROM JobTrackInvoiceRateDetail WHERE JobTrackDetailID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + ")=0      BEGIN DELETE FROM JobTrackInvoiceDetail wHERE JobTrackDetailID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + " END");



                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    StMethod.UpdateRecordNew("if (SELECT COUNT(JobTrackDetailID) FROM JobTrackInvoiceRateDetail WHERE JobTrackDetailID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + ")=0      BEGIN DELETE FROM JobTrackInvoiceDetail wHERE JobTrackDetailID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + " END");


                }
                else
                {
                    StMethod.UpdateRecord("if (SELECT COUNT(JobTrackDetailID) FROM JobTrackInvoiceRateDetail WHERE JobTrackDetailID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + ")=0      BEGIN DELETE FROM JobTrackInvoiceDetail wHERE JobTrackDetailID=" + grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + " END");

                }

                if (i > 0)
                {
                    KryptonMessageBox.Show("Delete Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //StMethod.LoginActivityInfo("Delete", this.Name);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.LoginActivityInfoNew("Delete", this.Name);
                    }
                    else
                    {
                        StMethod.LoginActivityInfo("Delete", this.Name);
                    }

                    int JobTrackDtlID = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);
                    FillRateInvocieDetail(JobTrackDtlID);
                    FillTimeRateInvoiveDetail(JobTrackDtlID, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                    FillExpecesRateInvoiceDetail(JobTrackDtlID, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                    FillInvoiceDetail();
                }
            }
        }
        private void btnPrintReport_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                PrintDialog printDia = new PrintDialog();
                printDia.ShowDialog();
                ReportDocument printDocument = new ReportDocument();
                printDocument = new rptInvoice();
                DataTable rptInvoiceDt = new DataTable();

                //rptInvoiceDt = StMethod.GetListDT<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + "");

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    rptInvoiceDt = StMethod.GetListDTNew<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + "");
                }
                else
                {
                    rptInvoiceDt = StMethod.GetListDT<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + "");
                }

                printDocument.SetDataSource(rptInvoiceDt);
                Int32 ncopy = 0;
                Int32 frompage = 0;
                Int32 topage = 0;
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
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }
        private void btnExportInvoice_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                btnExportInvoice.BackColor = Color.FromArgb(156, 207, 254);
                
                
                DataTable INDetailDT = new DataTable();

                //INDetailDT = StMethod.GetListDT<InvoiceExport>("SELECT JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription,           JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address, JobTrackInvoiceDetail.PhoneNo,JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email,  JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue, JobTrackInvoiceDetail.Aging,       JobTrackInvoiceDetail.OpeningBal, JobTrackInvoiceDetail.JobListID, Company.CompanyName,JobList.JobNumber,JobList.Address + JobList.State as JobAddress FROM  JobTrackInvoiceDetail INNER JOIN               JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID INNER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE JobTrackInvoiceDetail.JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    INDetailDT = StMethod.GetListDTNew<InvoiceExport>("SELECT JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription,           JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address, JobTrackInvoiceDetail.PhoneNo,JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email,  JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue, JobTrackInvoiceDetail.Aging,       JobTrackInvoiceDetail.OpeningBal, JobTrackInvoiceDetail.JobListID, Company.CompanyName,JobList.JobNumber,JobList.Address + JobList.State as JobAddress FROM  JobTrackInvoiceDetail INNER JOIN               JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID INNER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE JobTrackInvoiceDetail.JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());

                }
                else
                {
                    INDetailDT = StMethod.GetListDT<InvoiceExport>("SELECT JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription,           JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address, JobTrackInvoiceDetail.PhoneNo,JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email,  JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue, JobTrackInvoiceDetail.Aging,       JobTrackInvoiceDetail.OpeningBal, JobTrackInvoiceDetail.JobListID, Company.CompanyName,JobList.JobNumber,JobList.Address + JobList.State as JobAddress FROM  JobTrackInvoiceDetail INNER JOIN               JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID INNER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE JobTrackInvoiceDetail.JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());

                }

                DataTable RateDT = new DataTable();
                
                //RateDT = StMethod.GetListDT<InvoiceJobDtl>("SELECT JobTrackInvoiceRateDetail.InvoiceRptID, JobTrackInvoiceRateDetail.TrackSubID, JobTrackInvoiceRateDetail.JobTrackSubName,  JobTrackInvoiceRateDetail.JobTrackDetailID, JobTrackInvoiceRateDetail.Hrs, JobTrackInvoiceRateDetail.Rate, JobTrackInvoiceRateDetail.Description, MasterTrackSubItem.Account FROM  JobTrackInvoiceRateDetail LEFT OUTER JOIN    MasterTrackSubItem ON JobTrackInvoiceRateDetail.TrackSubID = MasterTrackSubItem.Id  WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    RateDT = StMethod.GetListDTNew<InvoiceJobDtl>("SELECT JobTrackInvoiceRateDetail.InvoiceRptID, JobTrackInvoiceRateDetail.TrackSubID, JobTrackInvoiceRateDetail.JobTrackSubName,  JobTrackInvoiceRateDetail.JobTrackDetailID, JobTrackInvoiceRateDetail.Hrs, JobTrackInvoiceRateDetail.Rate, JobTrackInvoiceRateDetail.Description, MasterTrackSubItem.Account FROM  JobTrackInvoiceRateDetail LEFT OUTER JOIN    MasterTrackSubItem ON JobTrackInvoiceRateDetail.TrackSubID = MasterTrackSubItem.Id  WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());

                }
                else
                {
                    RateDT = StMethod.GetListDT<InvoiceJobDtl>("SELECT JobTrackInvoiceRateDetail.InvoiceRptID, JobTrackInvoiceRateDetail.TrackSubID, JobTrackInvoiceRateDetail.JobTrackSubName,  JobTrackInvoiceRateDetail.JobTrackDetailID, JobTrackInvoiceRateDetail.Hrs, JobTrackInvoiceRateDetail.Rate, JobTrackInvoiceRateDetail.Description, MasterTrackSubItem.Account FROM  JobTrackInvoiceRateDetail LEFT OUTER JOIN    MasterTrackSubItem ON JobTrackInvoiceRateDetail.TrackSubID = MasterTrackSubItem.Id  WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());

                }

                decimal TotAmountStr = 0M;


                for (int i = 0; i < RateDT.Rows.Count; i++)
                {
                    TotAmountStr = TotAmountStr + Convert.ToDecimal(RateDT.Rows[i]["Hrs"]) * Convert.ToDecimal(RateDT.Rows[i]["Rate"]);
                }

                string InvoiceDetail = "!TRNS	TRNSID	TRNSTYPE	DATE	ACCNT	NAME	CLASS	AMOUNT	DOCNUM	MEMO	CLEAR	TOPRINT	ADDR1	ADDR2	ADDR3	ADDR4	ADDR5	DUEDATE	TERMS	FOB	INVTITLE	INVMEMO																			" + "\r\n" + "!SPL	SPLID	TRNSTYPE	DATE	ACCNT	NAME	CLASS	AMOUNT	DOCNUM	MEMO	CLEAR	QNTY	PRICE	INVITEM	PAYMETH	TAXABLE	REIMBEXP	EXTRA																							" + "\r\n" + "!ENDTRNS																																								" + "\r\n" + "TRNS	" + INDetailDT.Rows[0]["JobTrackDetailID"].ToString() + "	INVOICE	" + string.Format("MM/dd/yyyy", Convert.ToDateTime(INDetailDT.Rows[0]["InvoiceDate"])) + "	" + "Accounts Receivable	" + INDetailDT.Rows[0]["CompanyName"].ToString() + "		" + string.Format("{0:n2}", TotAmountStr) + "	" + cGlobal.Addj(INDetailDT.Rows[0]["InvoiceNo"].ToString()) + "		N	N	" + INDetailDT.Rows[0]["CompanyName"].ToString() + " (client)	" + SubRemoveEnter(INDetailDT.Rows[0]["Address"].ToString()) + "		JOB DESCRIPTION:" + INDetailDT.Rows[0]["CompanyName"].ToString() + "	" + INDetailDT.Rows[0]["JobAddress"].ToString() + "	" + string.Format("MM/dd/yyyy", INDetailDT.Rows[0]["DueDate"]) + "	Due on receipt			Invoice to continue on following page?																			";
                string RateDetailStr = string.Empty;
                for (int i = 0; i < RateDT.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        RateDetailStr = "SPL	" + RateDT.Rows[i]["InvoiceRptID"].ToString() + "	INVOICE	" + string.Format("MM/dd/yyyy", INDetailDT.Rows[0]["InvoiceDate"]) + "	" + RateDT.Rows[i]["Account"].ToString() + "			" + "-" + string.Format("{0:n2}", Convert.ToSingle((RateDT.Rows[i]["Hrs"])) * Convert.ToSingle(RateDT.Rows[i]["Rate"])) + "		" + RateDT.Rows[i]["Description"].ToString() + "	N	" + "-" + string.Format("{0:n2}", RateDT.Rows[i]["Hrs"]) + "	" + RateDT.Rows[i]["Rate"].ToString() + "	" + RateDT.Rows[i]["JobTrackSubName"].ToString() + "		N	N	NOTHING																							";
                    }
                    else
                    {
                        RateDetailStr = RateDetailStr + "\r\n" + "SPL	" + RateDT.Rows[i]["InvoiceRptID"].ToString() + "	INVOICE	" + string.Format("MM/dd/yyyy", INDetailDT.Rows[0]["InvoiceDate"]) + "	" + RateDT.Rows[i]["Account"].ToString() + "			" + "-" + string.Format("{0:n2}", Convert.ToSingle(RateDT.Rows[i]["Hrs"]) * Convert.ToSingle(RateDT.Rows[i]["Rate"])) + "		" + RateDT.Rows[i]["Description"].ToString() + "	N	" + "-" + string.Format("{0:n2}", RateDT.Rows[i]["Hrs"]) + "	" + RateDT.Rows[i]["Rate"].ToString() + "	" + RateDT.Rows[i]["JobTrackSubName"].ToString() + "		N	N	NOTHING																							";
                    }
                }
                RateDetailStr = RateDetailStr + "\r\n" + "ENDTRNS																																								" + "\r\n";

                try
                {
                    SaveFileDialog saveFileInvoice = new SaveFileDialog();


                    //N:\VE\QuickBooks\Invoice transfer folder

                    string QuickBookFile = Path.Combine(AppConstants.QuickBookFileDirectory, "Inv_Trans_" + DateTime.Now.ToString("yy") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd") + ".IIF");
                    if (File.Exists(QuickBookFile))
                    {
                        if (ExportStatus == true && grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor == Color.Green)
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
                        //'saveFileInvoice.FileName = INDetailDT.Rows[0).Rows["InvoiceNo").ToString + "j"
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
                        if (ExportStatus == true && grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor == Color.Green)
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
                        //saveFileInvoice.FileName = INDetailDT.Rows[0).Rows["InvoiceNo").ToString + "j"
                        saveFileInvoice.FileName = "Inv_Trans_" + DateTime.Now.ToString("yy") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd");

                        //N:\VE\QuickBooks\Invoice transfer folder
                        string FilterPath = @"N:\VE\QuickBooks\Invoice transfer folder";

                        if (Directory.Exists(FilterPath))
                        {
                            saveFileInvoice.InitialDirectory = FilterPath;
                        }
                        else
                        {
                            saveFileInvoice.InitialDirectory = @"C:\";
                        }

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
                    grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Green;
                    grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Green;
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
        private void grdTimeSearchRateInvoice_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int JobTrackDtlId = 0;
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                UpdateTimeDetail();
                JobTrackDtlId = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);
                FillRateInvocieDetail(JobTrackDtlId);
                FillTimeRateInvoiveDetail(JobTrackDtlId, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                FillExpecesRateInvoiceDetail(JobTrackDtlId, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                FillInvoiceDetail();
            }
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                JobTrackDtlId = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);


                //int i = StMethod.UpdateRecord("DELETE FROM CRVTimeInvoice WHERE CRVTimeInvoiceID=" + grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].Cells["CRVTimeInvoiceID"].Value.ToString());

                int i;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    i = StMethod.UpdateRecordNew("DELETE FROM CRVTimeInvoice WHERE CRVTimeInvoiceID=" + grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].Cells["CRVTimeInvoiceID"].Value.ToString());

                }
                else
                {
                    i = StMethod.UpdateRecord("DELETE FROM CRVTimeInvoice WHERE CRVTimeInvoiceID=" + grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].Cells["CRVTimeInvoiceID"].Value.ToString());
                }

                if (i > 0)
                {
                    KryptonMessageBox.Show("Delete Successfully", "Search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //'DAL.LoginActivityInfo("Delete", Me.Name)
                    FillRateInvocieDetail(JobTrackDtlId);
                    FillTimeRateInvoiveDetail(JobTrackDtlId, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                    FillExpecesRateInvoiceDetail(JobTrackDtlId, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                    FillInvoiceDetail();
                }
            }
        }
        private void grdTimeSearchRateInvoice_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > -1 || e.RowIndex > -1)
            {
                CheckString = string.Empty;
                CheckString = grdTimeSearchRateInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
        private void grdTimeSearchRateInvoice_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.Rows.Count - 1].Cells["CRVTimeInvoiceID"].Value.ToString()) == 0)
                    {
                        return;
                    }
                    if (grdTimeSearchRateInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grdTimeSearchRateInvoice.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grdTimeSearchRateInvoice.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdExpensesSearchRateInvoice_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 || e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.Rows.Count - 1].Cells["CRVTimeInvoiceID"].Value.ToString()) == 0)
                    {
                        return;
                    }
                    if (grdExpensesSearchRateInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grdExpensesSearchRateInvoice.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grdExpensesSearchRateInvoice.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdExpensesSearchRateInvoice_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > -1 || e.RowIndex > -1)
            {
                CheckString = string.Empty;
                CheckString = grdExpensesSearchRateInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
        private void grdExpensesSearchRateInvoice_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            int JobTrackDtlId = 0;
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                UpdateExpensesDetail();
                JobTrackDtlId = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);
                FillRateInvocieDetail(JobTrackDtlId);
                FillTimeRateInvoiveDetail(JobTrackDtlId, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                FillExpecesRateInvoiceDetail(JobTrackDtlId, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                FillInvoiceDetail();
            }
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                JobTrackDtlId = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);


                //int i = StMethod.UpdateRecord("DELETE FROM CRVExpensesInvoice WHERE CRVExpensesInvoiceID=" + grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].Cells["CRVExpensesInvoiceID"].Value.ToString());

                int i;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    i = StMethod.UpdateRecordNew("DELETE FROM CRVExpensesInvoice WHERE CRVExpensesInvoiceID=" + grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].Cells["CRVExpensesInvoiceID"].Value.ToString());

                }
                else
                {
                    i = StMethod.UpdateRecord("DELETE FROM CRVExpensesInvoice WHERE CRVExpensesInvoiceID=" + grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].Cells["CRVExpensesInvoiceID"].Value.ToString());
                }

                if (i > 0)
                {
                    KryptonMessageBox.Show("Delete Successfully", "Search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //'DAL.LoginActivityInfo("Delete", Me.Name)
                    FillRateInvocieDetail(JobTrackDtlId);
                    FillTimeRateInvoiveDetail(JobTrackDtlId, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                    FillExpecesRateInvoiceDetail(JobTrackDtlId, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                    FillInvoiceDetail();
                }
            }
        }

        public void ExportReport()
        {
            try
            {


                SaveFileDialog ExportReport = new SaveFileDialog();
                //ExportReport.Filter = "Excel Format|*.xlsx";
                ExportReport.Filter = "Excel Format|*.xls";
                ExportReport.Title = "Export Invoice";
                //ExportReport.InitialDirectory = "N:";
                ExportReport.FilterIndex = 2;

                string ExportPath = "N:\\";

                

                if (Directory.Exists(ExportPath))
                {
                    ExportReport.InitialDirectory = "N:\\";
                }
                else
                {
                    ExportReport.InitialDirectory = "C:\\";
                }


                if (ExportReport.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                string FullFilePath = ExportReport.FileName;
                string filename = Path.GetFileName(ExportReport.FileName);
                string filePath = ExportReport.FileName;

                //Dim workBook As New XSSFWorkbook()
               
                ISheet sheet1 = workBook.CreateSheet(filename);

                //Workbook wb = WorkbookFactory.create(new FileInputStream(filePath));

                //XSSFFont myFont = (XSSFFont)workBook.CreateFont();
                HSSFFont myFont = (HSSFFont)workBook.CreateFont();

                myFont.FontHeightInPoints = 11;
                myFont.FontName = "Tahoma";
                myFont.IsBold = false;


                //XSSFCellStyle borderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();
                HSSFCellStyle borderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();

                 
                borderedCellStyle.SetFont(myFont);

                borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin ;
                borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;

                borderedCellStyle.WrapText = true;

                //var cellType = CellType.String;
                //var colStyle = sheet1.GetColumnStyle(6);



                //colStyle.WrapText = true;

                //sheet1.SetDefaultColumnStyle(6, colStyle);

                DataTable dtsearch = SearchData3();

                string s = dtsearch.Rows.Count.ToString();

                Int32 Sheetrowindex = 0;
                int percent = 0;

                int GTotal = 0;


                //XSSFFont BottomFont = (XSSFFont)workBook.CreateFont();
                HSSFFont BottomFont = (HSSFFont)workBook.CreateFont();
                 
                BottomFont.FontHeightInPoints = 14;
                BottomFont.Color = IndexedColors.RoyalBlue.Index;

                BottomFont.IsBold = true;


                //XSSFCellStyle BottomBorderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();
                HSSFCellStyle BottomBorderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();

                BottomBorderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                BottomBorderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                BottomBorderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                BottomBorderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                BottomBorderedCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Right;
                BottomBorderedCellStyle.SetFont(BottomFont);


                for (int ContactRowindex = 0; ContactRowindex <= dtsearch.Rows.Count; ContactRowindex++)
                //for (int ContactRowindex = 0; ContactRowindex <= dtsearch.Rows.Count-1; ContactRowindex++)
                {
                    //if (ProgressBar1.Value <= MainDataTable.Rows.Count)
                    //{
                    //    CreateContactPassword(MainDataTable, borderedCellStyle, (ContactRowindex - 1),
                    //        ref Sheetrowindex, ref sheet1);
                    //}

                    CreateSearchInvoice(dtsearch, borderedCellStyle, (ContactRowindex - 1),
                            ref Sheetrowindex, ref sheet1);

                    if(ContactRowindex== dtsearch.Rows.Count)
                    {

                        var sheetRow2 = sheet1.CreateRow(dtsearch.Rows.Count+1);
                        //var sheetRow2 = sheet1.CreateRow(dtsearch.Rows.Count+5);
                        //int ColumnIndex = 0;
                        //int ColumnIndex2 = 0;

                        ICell Cell4 = sheetRow2.CreateCell(0);
                        Cell4.SetCellValue(Convert.ToString("Total Invoice"));
                        Cell4.CellStyle = BottomBorderedCellStyle;

                        int value7;
                        if (int.TryParse(dtsearch.Rows.Count.ToString (), out value7))
                        {

                            ICell Cell5 = sheetRow2.CreateCell(1);
                            Cell5.SetCellType(NPOI.SS.UserModel.CellType.Numeric);

                            //Cell5.SetCellValue(Convert.ToString(dtsearch.Rows.Count));
                                                        
                            int value11 = int.Parse(dtsearch.Rows.Count.ToString());
                            Cell5.SetCellValue(value11);
                            Cell5.CellStyle = BottomBorderedCellStyle;                            
                        }

                        ICell Cell11 = sheetRow2.CreateCell(2);
                        ICell Cell12 = sheetRow2.CreateCell(3);
                        Cell11.CellStyle = BottomBorderedCellStyle;
                        Cell12.CellStyle = BottomBorderedCellStyle;

                        //ICell Cell5 = sheetRow2.CreateCell(1);
                        //Cell5.SetCellValue(Convert.ToString(dtsearch.Rows.Count));
                        //Cell5.CellStyle = BottomBorderedCellStyle;

                        ICell Cell6 = sheetRow2.CreateCell(4);
                        Cell6.SetCellValue(Convert.ToString("Grand Total"));
                        Cell6.CellStyle = BottomBorderedCellStyle;



                        int value8;
                        if (int.TryParse(GrandToal.ToString(), out value8))
                        {

                            ICell Cell15 = sheetRow2.CreateCell(5);
                            Cell15.SetCellType(NPOI.SS.UserModel.CellType.Numeric);

                            //Cell5.SetCellValue(Convert.ToString(dtsearch.Rows.Count));

                            //MessageBox.Show(GrandToal.ToString());

                            int value15 = int.Parse(GrandToal.ToString());
                            Cell15.SetCellValue(value15);
                            Cell15.CellStyle = BottomBorderedCellStyle;
                        }

                        //ICell Cell7 = sheetRow2.CreateCell(5);
                        //Cell7.SetCellValue(Convert.ToString(GrandToal));
                        //Cell7.CellStyle = BottomBorderedCellStyle;


                    }


                }



                //Auto sized all the affected columns
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



                //export to excel 

                var fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workBook.Write(fsd);                
                workBook.Close();
                fsd.Close();
                MessageBox.Show("Export Successfully ", ExportReport.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        //private object CreateSearchInvoice(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)

        private object CreateSearchInvoice(DataTable dt, HSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)
        {

            //add column header
            
            var sheetRow = sheet.CreateRow(sheetRowIndex);
            
            int ColumnIndex = 0;
            
            //int ColumnIndex2 = 0;
                  
            foreach (DataColumn header in dt.Columns)
            {

                if (sheetRowIndex == 0)
                {

                    //XSSFFont myFont = (XSSFFont)workBook.CreateFont();
                    HSSFFont myFont = (HSSFFont)workBook.CreateFont();
                     

                    myFont.FontHeightInPoints = 16;
                    //myFont.FontName = "Tahoma";
                    myFont.IsBold = true;
                    myFont.Color = IndexedColors.RoyalBlue.Index;

                    //XSSFCellStyle HeaderBorderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();

                    HSSFCellStyle HeaderBorderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();
                     

                    HeaderBorderedCellStyle.SetFont(myFont);

                    HeaderBorderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                    HeaderBorderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                    HeaderBorderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                    HeaderBorderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                    HeaderBorderedCellStyle.VerticalAlignment = VerticalAlignment.Center;
                    
                    ICell Cell1 = sheetRow.CreateCell(0);
                    Cell1.SetCellValue("Job Number");
                    Cell1.CellStyle = HeaderBorderedCellStyle;

                    ICell Cell2 = sheetRow.CreateCell(1);
                    Cell2.SetCellValue("Company Name");
                    Cell2.CellStyle = HeaderBorderedCellStyle;

                    ICell Cell3 = sheetRow.CreateCell(2);
                    Cell3.SetCellValue("invoice Number");
                    Cell3.CellStyle = HeaderBorderedCellStyle;


                    ICell Cell4 = sheetRow.CreateCell(3);
                    Cell4.SetCellValue("invoice Address");
                    Cell4.CellStyle = HeaderBorderedCellStyle;

                    ICell Cell5 = sheetRow.CreateCell(4);
                    Cell5.SetCellValue("invoice Date");
                    Cell5.CellStyle = HeaderBorderedCellStyle;

                    ICell Cell6 = sheetRow.CreateCell(5);
                    Cell6.SetCellValue("Invoice Total");
                    Cell6.CellStyle = HeaderBorderedCellStyle;                               
                }
                else
                {
                    //XSSFFont myFont2 = (XSSFFont)workBook.CreateFont();
                    //myFont2.FontHeightInPoints = 10;
                    //myFont2.FontName = "Tahoma";
                    //myFont2.IsBold = true ;
                    //myFont2.Color = IndexedColors.Blue.Index;

                    //XSSFCellStyle HeaderBorderedCellStyle2 = (XSSFCellStyle)workBook.CreateCellStyle();
                    //HeaderBorderedCellStyle2.SetFont(myFont2);
                    
                    //HeaderBorderedCellStyle2.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    //HeaderBorderedCellStyle2.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    //HeaderBorderedCellStyle2.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    //HeaderBorderedCellStyle2.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                    //HeaderBorderedCellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

                    if (ColumnIndex == 0)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();
                        
                        ICell Cell4 = sheetRow.CreateCell(ColumnIndex);
                        
                        //int value;
                        //if (int.TryParse(dt.Rows[rowindex][ColumnIndex].ToString(), out value))
                        //{

                        //    Cell4.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        //    int value5 = int.Parse(columnvalue);
                        //    Cell4.SetCellValue(value5);
                        //}
                        //else
                        //{
                        //    Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //    Cell4.SetCellValue(Convert.ToString(columnvalue));

                        //}
                        
                        Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell4.SetCellValue(Convert.ToString(columnvalue));

                        Cell4.CellStyle = borderedCellStyle;
                    }

                    if (ColumnIndex == 17)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell5 = sheetRow.CreateCell(ColumnIndex);
                        //Cell5.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //Cell5.SetCellValue(columnvalue);
                        //Cell5.CellStyle = HeaderBorderedCellStyle2;

                        //string columnvalue7 = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell7 = sheetRow.CreateCell(ColumnIndex);
                        ICell Cell7 = sheetRow.CreateCell(1);

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

                        Cell7.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell7.SetCellValue(Convert.ToString(columnvalue));
                        Cell7.CellStyle = borderedCellStyle;
                    }

                    if (ColumnIndex == 2)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell5 = sheetRow.CreateCell(ColumnIndex);
                        //Cell5.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //Cell5.SetCellValue(columnvalue);
                        //Cell5.CellStyle = HeaderBorderedCellStyle2;

                        //string columnvalue7 = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell7 = sheetRow.CreateCell(ColumnIndex);
                        ICell Cell8 = sheetRow.CreateCell(2);

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

                        Cell8.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell8.SetCellValue(Convert.ToString(columnvalue));
                        Cell8.CellStyle = borderedCellStyle;
                    }

                    if (ColumnIndex == 6)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell5 = sheetRow.CreateCell(ColumnIndex);
                        //Cell5.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //Cell5.SetCellValue(columnvalue);
                        //Cell5.CellStyle = HeaderBorderedCellStyle2;

                        //string columnvalue11 = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell7 = sheetRow.CreateCell(ColumnIndex);
                        ICell Cell11 = sheetRow.CreateCell(3);

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

                        Cell11.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell11.SetCellValue(Convert.ToString(columnvalue));
                        Cell11.CellStyle = borderedCellStyle;
                        
                    }

                    if (ColumnIndex == 3)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell5 = sheetRow.CreateCell(ColumnIndex);
                        //Cell5.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //Cell5.SetCellValue(columnvalue);
                        //Cell5.CellStyle = HeaderBorderedCellStyle2;

                        //string columnvalue11 = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell7 = sheetRow.CreateCell(ColumnIndex);
                        ICell Cell11 = sheetRow.CreateCell(4);

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

                        Cell11.SetCellType(NPOI.SS.UserModel.CellType.String);

                        //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                        Cell11.SetCellValue((DateTime.Parse(columnvalue.ToString())).ToString("MM/d/yyyy"));

                        
                        //Cell11.SetCellValue(Convert.ToString(columnvalue));
                        Cell11.CellStyle = borderedCellStyle;
                    }

                    if (ColumnIndex == 15)
                    {                       
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();
                        ICell Cell7 = sheetRow.CreateCell(5);

                        int value7;
                        if (int.TryParse(dt.Rows[rowindex][ColumnIndex].ToString(), out value7))
                        {

                            Cell7.SetCellType(NPOI.SS.UserModel.CellType.Numeric);                            
                            int value8 = int.Parse(columnvalue);
                            GrandToal = GrandToal+ value8;

                            //MessageBox.Show("Cell Value = " + columnvalue + "Total = " +                              GrandToal.ToString());

                            //FinalTotal = GrandToal;

                            Cell7.SetCellValue(value8);
                            Cell7.CellStyle = borderedCellStyle;

                            
                            
                        }
                        else
                        {
                            Cell7.SetCellType(NPOI.SS.UserModel.CellType.String);
                            Cell7.SetCellValue(Convert.ToString(columnvalue));
                            Cell7.CellStyle = borderedCellStyle;
                        }

                        //Cell11.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //Cell11.SetCellValue(Convert.ToString(columnvalue11));
                        //Cell11.CellStyle = HeaderBorderedCellStyle2;
                    }


                }

                //ColumnIndex = ColumnIndex + 1;

                //string columnvalue2 = dt.Rows[rowindex][ColumnIndex].ToString();
                //MessageBox.Show(columnvalue2.ToString());

                //sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);

                ColumnIndex = ColumnIndex + 1;

            }

            sheetRowIndex = sheetRowIndex + 1;

            return null;
        }

        private void btnExportReport_Click(System.Object sender, System.EventArgs e)
        {
            //Export all invoice in excel
            try
            {
                GrandToal = 0;
                ExportReport();

                //FillInvoiceDetail();

                //DataTable dtsearch = SearchData();


                //if (dtsearch.Rows.Count > 0)
                //{



                //Excel.Application excelobj = new Excel.Application();
                //Excel.Workbook wBook = null;
                //Excel.Worksheet wSheet = null;
                //wBook = excelobj.Workbooks.Add();
                //wSheet = (Excel.Worksheet)wBook.Sheets[1];

                //int colIndex = 0;
                //int rowIndex = 1;

                //excelobj.Cells[1, 1] = "Job Number";
                //excelobj.Cells[1, 2] = "Company Name";
                //excelobj.Cells[1, 3] = "Invoice Number";
                //excelobj.Cells[1, 4] = "invoice Address";
                //excelobj.Cells[1, 5] = "invoice Date";
                //excelobj.Cells[1, 6] = "invoice Total";

                //wSheet.Columns.Range["A1:F1"].Font.Bold = true;
                //wSheet.Columns.Range["A1:F1"].Font.Color = Color.RoyalBlue;
                //wSheet.Columns.Range["A1:F1"].Font.Size = 16;

                ////' Dim query As IEnumerable(Of String) = From dt In dtsearch.AsEnumerable() Select dt.Field(Of String)("CompanyName")

                //foreach (System.Data.DataRow dr in dtsearch.Rows)
                //{
                //    rowIndex = rowIndex + 1;

                //    excelobj.Cells[rowIndex, 1] = dr["JobNumber"];
                //    excelobj.Cells[rowIndex, 2] = dr["CompanyName"];
                //    excelobj.Cells[rowIndex, 3] = dr["InvoiceNo"];
                //    excelobj.Cells[rowIndex, 4] = dr["invoiceAddress"];
                //    excelobj.Cells[rowIndex, 5] = dr["InvoiceDate"];
                //    excelobj.Cells[rowIndex, 6] = dr["Total"];
                //}


                //if (dtsearch.Rows.Count > 0)
                //{
                //    rowIndex = rowIndex + 1;
                //    int TotalInvoice = dtsearch.Rows.Count;
                //    //decimal total = Convert.ToDecimal(dtsearch.Compute("Sum(Convert(Total, 'System.Int32')", "Total IS NOT NULL"));
                //    var total = dtsearch.AsEnumerable().Sum(x => Convert.ToDecimal(x["Total"]));
                //    excelobj.Cells[rowIndex, 1] = "Total Invoice";
                //    excelobj.Cells[rowIndex, 1].Font.Size = 14;
                //    excelobj.Cells[rowIndex, 1].Font.Color = Color.RoyalBlue;

                //    excelobj.Cells[rowIndex, 5] = "Grand Total";
                //    excelobj.Cells[rowIndex, 5].Font.Size = 14;
                //    excelobj.Cells[rowIndex, 5].Font.Color = Color.RoyalBlue;

                //    excelobj.Cells[rowIndex, 2] = TotalInvoice;
                //    excelobj.Cells[rowIndex, 2].Font.Size = 14;
                //    excelobj.Cells[rowIndex, 2].Font.Color = Color.RoyalBlue;

                //    excelobj.Cells[rowIndex, 6] = total;
                //    excelobj.Cells[rowIndex, 6].Font.Size = 14;
                //    excelobj.Cells[rowIndex, 6].Font.Color = Color.RoyalBlue;
                //}

                //wSheet.Columns.Range["A1:F" + rowIndex.ToString()].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                //wSheet.Columns.Range["A1:F" + rowIndex.ToString()].Borders.Weight = 2.0;

                //wSheet.Columns.AutoFit();
                //SaveFileDialog Export = new SaveFileDialog();
                //Export.Filter = "Excel Format|*.xls";
                //Export.Title = "Export Invoice";
                //Export.InitialDirectory = "N:";
                ////saveFileInvoice.FileName = INDetailDT.Rows[0).Rows["InvoiceNo").ToString + "j"
                //if (Export.ShowDialog() == DialogResult.Cancel)
                //{
                //    return;
                //}
                //string strFileName = Export.FileName;
                //bool blnFileOpen = false;
                //try
                //{
                //    System.IO.FileStream fileTemp = System.IO.File.OpenWrite(strFileName);
                //    fileTemp.Close();
                //}
                //catch (Exception ex)
                //{
                //    blnFileOpen = false;
                //}

                //if (System.IO.File.Exists(strFileName))
                //{
                //    System.IO.File.Delete(strFileName);
                //}
                //bool ROnly = false;

                //wBook.SaveAs(strFileName);
                //excelobj.Workbooks.Open(strFileName);
                //excelobj.Visible = true;
                //}
                //else
                //{
                //    ///Show alert mesg here when no records found
                //    KryptonMessageBox.Show("NO Record Found");
                //}
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void btnReduction_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                int jobDetailId = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);
                string invoiceNo = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString();
                FillRateInvocieDetail(jobDetailId, true);
                FillTimeRateInvoiveDetail(jobDetailId, invoiceNo, true);
                FillExpecesRateInvoiceDetail(jobDetailId, invoiceNo, true);
                CaclulateReductionInvoiceDetail();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Methods
        private DataTable SearchData()
        {
            try
            {
                string Query = null;
                string innerQuerry = string.Empty;

                Query = "select Top 150 fi.JobNumber, fi.JobTrackDetailID, fi.InvoiceNo, fi.InvoiceDate, fi.Jobdescription, fi.DueDate, fi.invoiceAddress ,fi.PhoneNo, fi.FaxNo, fi.Email, fi.PONo, fi.PaymentCr,  fi.BalanceDue,case when Reinburs.Reimbursement is null then 0 else Reinburs.Reimbursement end as Reimbursement,case when expn.Expense is null then 0 else expn.Expense end as Expense, case  when rev.Total IS NULL  then 0 else rev.Total end as Total,cast( ROUND(( case  when rev.Total IS NULL  then 0 else rev.Total end  + case when expn.Expense is null then 0 else expn.Expense end),2) AS money) as Revenue,fi.CompanyName from" +
                    " (SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate," + "JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo," + "JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue,Company.CompanyName " +
                    " FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON " + "JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0) {0} )  " + "fi left join  (select jt.JobTrackDetailID,SUM(rate.Amount*rate.Hrs) as Reimbursement   from JobTrackInvoiceDetail jt inner join " +
                    " JobTrackInvoiceRateDetail rate on jt.JobTrackDetailID = rate.JobTrackDetailID " +
                    " inner join MasterTrackSubDisplay mstr on rate.TrackSubID = mstr.Id where  mstr.TrackName ='Reinburs;' " +
                    " group by jt.JobTrackDetailID )  Reinburs on fi.JobTrackDetailID = Reinburs.JobTrackDetailID left join " +
                    " (select SUM(a.Total) as Total,a.JobTrackDetailID from  ( SELECT  SUM(JobTrackInvoiceRateDetail.Hrs *  JobTrackInvoiceRateDetail.Rate) as Total , JobTrackInvoiceDetail.JobTrackDetailID "
                    + " FROM  dbo.JobTrackInvoiceDetail INNER JOIN dbo.JobTrackInvoiceRateDetail  ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.JobTrackInvoiceRateDetail.JobTrackDetailID GROUP BY JobTrackInvoiceDetail.JobTrackDetailID union SELECT SUM(Time * Rate) AS Revenue,JobTrackInvoiceDetail.JobTrackDetailID FROM dbo.JobTrackInvoiceDetail " +
                    " INNER JOIN dbo.CRVTimeInvoice ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.CRVTimeInvoice.JobTrackDetailID INNER JOIN dbo.JobList " +
                    " ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID WHERE (dbo.JobTrackInvoiceDetail.JobTrackDetailID IN  (SELECT ISNULL(JobTrackDetailID,0) " +
                    " AS Expr1 FROM dbo.JobTrackInvoiceDetail AS JobTrackInvoiceDetail_1)) GROUP BY JobTrackInvoiceDetail.JobTrackDetailID) a group by a.JobTrackDetailID) rev on fi.JobTrackDetailID = rev.JobTrackDetailID left join " +
                    " (SELECT   sum(Expenses) as Expense,JobTrackDetailID  from CRVExpensesInvoice group by JobTrackDetailID) expn  on fi.JobTrackDetailID = expn.JobTrackDetailID order by fi.JobNumber";
                //& SELECT  c.CompanyName FROM Company c INNER JOIN JobList JL ON JL.CompanyID = c.CompanyID INNER JOIN JobTrackInvoiceDetail JT ON JT.JobListID=JL.JobListID

                //Query = "SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo, JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0)"
                if (!string.IsNullOrEmpty(txtCompanyName.Text))
                {
                    innerQuerry = innerQuerry + " AND Company.CompanyName LIKE '% " + txtCompanyName.Text.Trim() + " %'";
                }
                if (!string.IsNullOrEmpty(txtJobNumber.Text))
                {
                    innerQuerry = innerQuerry + " AND JobList.JobNumber LIKE '%" + txtJobNumber.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtAddress.Text))
                {
                    innerQuerry = innerQuerry + " AND Company.Address LIKE '%" + txtAddress.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
                {
                    innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceNo LIKE '%" + txtInvoiceNo.Text.Trim() + "%'";
                }
                if (chkBoxActiveDate.Checked == true)
                {
                    innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceDate BETWEEN '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' AND '" + dtpTo.Value.ToString("MM/dd/yyyy") + "'";
                }


                //return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    return StMethod.GetListDTNew<QBInvCompare>(string.Format(Query, innerQuerry));
                }
                else
                {
                    return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));
                }
                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //throw ex;
            }
            return new DataTable();
        }

        private DataTable SearchData2()
        {
            try
            {
                string Query = null;
                string innerQuerry = string.Empty;

                Query = "select Top 150 fi.JobNumber, fi.JobTrackDetailID, fi.InvoiceNo, fi.InvoiceDate, fi.Jobdescription, fi.DueDate, fi.invoiceAddress ,fi.PhoneNo, fi.FaxNo, fi.Email, fi.PONo, fi.PaymentCr,  fi.BalanceDue,case when Reinburs.Reimbursement is null then 0 else Reinburs.Reimbursement end as Reimbursement,case when expn.Expense is null then 0 else expn.Expense end as Expense, case  when rev.Total IS NULL  then 0 else rev.Total end as Total,cast( ROUND(( case  when rev.Total IS NULL  then 0 else rev.Total end  + case when expn.Expense is null then 0 else expn.Expense end),2) AS money) as Revenue,fi.CompanyName from" +
                    " (SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate," + "JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo," + "JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue,Company.CompanyName " +
                    " FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON " + "JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0) {0} )  " + "fi left join  (select jt.JobTrackDetailID,SUM(rate.Amount*rate.Hrs) as Reimbursement   from JobTrackInvoiceDetail jt inner join " +
                    " JobTrackInvoiceRateDetail rate on jt.JobTrackDetailID = rate.JobTrackDetailID " +
                    " inner join MasterTrackSubDisplay mstr on rate.TrackSubID = mstr.Id where  mstr.TrackName ='Reinburs;' " +
                    " group by jt.JobTrackDetailID )  Reinburs on fi.JobTrackDetailID = Reinburs.JobTrackDetailID left join " +
                    " (select SUM(a.Total) as Total,a.JobTrackDetailID from  ( SELECT  SUM(JobTrackInvoiceRateDetail.Hrs *  JobTrackInvoiceRateDetail.Rate) as Total , JobTrackInvoiceDetail.JobTrackDetailID "
                    + " FROM  dbo.JobTrackInvoiceDetail INNER JOIN dbo.JobTrackInvoiceRateDetail  ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.JobTrackInvoiceRateDetail.JobTrackDetailID GROUP BY JobTrackInvoiceDetail.JobTrackDetailID union SELECT SUM(Time * Rate) AS Revenue,JobTrackInvoiceDetail.JobTrackDetailID FROM dbo.JobTrackInvoiceDetail " +
                    " INNER JOIN dbo.CRVTimeInvoice ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.CRVTimeInvoice.JobTrackDetailID INNER JOIN dbo.JobList " +
                    " ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID WHERE (dbo.JobTrackInvoiceDetail.JobTrackDetailID IN  (SELECT ISNULL(JobTrackDetailID,0) " +
                    " AS Expr1 FROM dbo.JobTrackInvoiceDetail AS JobTrackInvoiceDetail_1)) GROUP BY JobTrackInvoiceDetail.JobTrackDetailID) a group by a.JobTrackDetailID) rev on fi.JobTrackDetailID = rev.JobTrackDetailID left join " +
                    " (SELECT   sum(Expenses) as Expense,JobTrackDetailID  from CRVExpensesInvoice group by JobTrackDetailID) expn  on fi.JobTrackDetailID = expn.JobTrackDetailID order by fi.JobNumber";
                //& SELECT  c.CompanyName FROM Company c INNER JOIN JobList JL ON JL.CompanyID = c.CompanyID INNER JOIN JobTrackInvoiceDetail JT ON JT.JobListID=JL.JobListID

                //Query = "SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo, JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0)"
                if (!string.IsNullOrEmpty(txtCompanyName.Text))
                {
                    innerQuerry = innerQuerry + " AND Company.CompanyName LIKE '% " + txtCompanyName.Text.Trim() + " %'";
                }
                if (!string.IsNullOrEmpty(txtJobNumber.Text))
                {
                    innerQuerry = innerQuerry + " AND JobList.JobNumber LIKE '%" + txtJobNumber.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtAddress.Text))
                {
                    innerQuerry = innerQuerry + " AND Company.Address LIKE '%" + txtAddress.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
                {
                    innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceNo LIKE '%" + txtInvoiceNo.Text.Trim() + "%'";
                }
                if (chkBoxActiveDate.Checked == true)
                {
                    innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceDate BETWEEN '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' AND '" + dtpTo.Value.ToString("MM/dd/yyyy") + "'";
                }


                //return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    return StMethod.GetListDTNew<QBInvCompare>(string.Format(Query, innerQuerry));
                }
                else
                {
                    return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));
                }

            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message.ToString());
            }
            return new DataTable();
        }


        private DataTable SearchData3()
        {
            try
            {
                string Query = null;
                string innerQuerry = string.Empty;

                Query = "select Top 150 fi.JobNumber, fi.JobTrackDetailID, fi.InvoiceNo, fi.InvoiceDate, fi.Jobdescription, fi.DueDate, fi.invoiceAddress ,fi.PhoneNo, fi.FaxNo, fi.Email, fi.PONo, fi.PaymentCr,  fi.BalanceDue,case when Reinburs.Reimbursement is null then 0 else Reinburs.Reimbursement end as Reimbursement,case when expn.Expense is null then 0 else expn.Expense end as Expense, case  when rev.Total IS NULL  then 0 else rev.Total end as Total,cast( ROUND(( case  when rev.Total IS NULL  then 0 else rev.Total end  + case when expn.Expense is null then 0 else expn.Expense end),2) AS money) as Revenue,fi.CompanyName from" +
                    " (SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate," + "JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo," + "JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue,Company.CompanyName " +
                    " FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON " + "JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0) {0} )  " + "fi left join  (select jt.JobTrackDetailID,SUM(rate.Amount*rate.Hrs) as Reimbursement   from JobTrackInvoiceDetail jt inner join " +
                    " JobTrackInvoiceRateDetail rate on jt.JobTrackDetailID = rate.JobTrackDetailID " +
                    " inner join MasterTrackSubDisplay mstr on rate.TrackSubID = mstr.Id where  mstr.TrackName ='Reinburs;' " +
                    " group by jt.JobTrackDetailID )  Reinburs on fi.JobTrackDetailID = Reinburs.JobTrackDetailID left join " +
                    " (select SUM(a.Total) as Total,a.JobTrackDetailID from  ( SELECT  SUM(JobTrackInvoiceRateDetail.Hrs *  JobTrackInvoiceRateDetail.Rate) as Total , JobTrackInvoiceDetail.JobTrackDetailID "
                    + " FROM  dbo.JobTrackInvoiceDetail INNER JOIN dbo.JobTrackInvoiceRateDetail  ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.JobTrackInvoiceRateDetail.JobTrackDetailID GROUP BY JobTrackInvoiceDetail.JobTrackDetailID union SELECT SUM(Time * Rate) AS Revenue,JobTrackInvoiceDetail.JobTrackDetailID FROM dbo.JobTrackInvoiceDetail " +
                    " INNER JOIN dbo.CRVTimeInvoice ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.CRVTimeInvoice.JobTrackDetailID INNER JOIN dbo.JobList " +
                    " ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID WHERE (dbo.JobTrackInvoiceDetail.JobTrackDetailID IN  (SELECT ISNULL(JobTrackDetailID,0) " +
                    " AS Expr1 FROM dbo.JobTrackInvoiceDetail AS JobTrackInvoiceDetail_1)) GROUP BY JobTrackInvoiceDetail.JobTrackDetailID) a group by a.JobTrackDetailID) rev on fi.JobTrackDetailID = rev.JobTrackDetailID left join " +
                    " (SELECT   sum(Expenses) as Expense,JobTrackDetailID  from CRVExpensesInvoice group by JobTrackDetailID) expn  on fi.JobTrackDetailID = expn.JobTrackDetailID order by fi.JobNumber";
                //& SELECT  c.CompanyName FROM Company c INNER JOIN JobList JL ON JL.CompanyID = c.CompanyID INNER JOIN JobTrackInvoiceDetail JT ON JT.JobListID=JL.JobListID

                //Query = "SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo, JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0)"
                if (!string.IsNullOrEmpty(txtCompanyName.Text))
                {
                    innerQuerry = innerQuerry + " AND Company.CompanyName LIKE '% " + txtCompanyName.Text.Trim() + " %'";
                }
                if (!string.IsNullOrEmpty(txtJobNumber.Text))
                {
                    innerQuerry = innerQuerry + " AND JobList.JobNumber LIKE '%" + txtJobNumber.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtAddress.Text))
                {
                    innerQuerry = innerQuerry + " AND Company.Address LIKE '%" + txtAddress.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
                {
                    innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceNo LIKE '%" + txtInvoiceNo.Text.Trim() + "%'";
                }
                if (chkBoxActiveDate.Checked == true)
                {
                    innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceDate BETWEEN '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' AND '" + dtpTo.Value.ToString("MM/dd/yyyy") + "'";
                }

                //return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    return StMethod.GetListDTNew<QBInvCompare>(string.Format(Query, innerQuerry));
                }
                else
                {
                    return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message.ToString());
            }
            return new DataTable();
        }

        private DataTable SearchData4()
        {
            try
            {
                string Query = null;
                string innerQuerry = string.Empty;

                Query = "select Top 150 fi.JobNumber, fi.JobTrackDetailID, fi.InvoiceNo, fi.InvoiceDate, fi.Jobdescription, fi.DueDate, fi.invoiceAddress ,fi.PhoneNo, fi.FaxNo, fi.Email, fi.PONo, fi.PaymentCr,  fi.BalanceDue,case when Reinburs.Reimbursement is null then 0 else Reinburs.Reimbursement end as Reimbursement,case when expn.Expense is null then 0 else expn.Expense end as Expense, case  when rev.Total IS NULL  then 0 else rev.Total end as Total,cast( ROUND(( case  when rev.Total IS NULL  then 0 else rev.Total end  + case when expn.Expense is null then 0 else expn.Expense end),2) AS money) as Revenue,fi.CompanyName from" +
                    " (SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate," + "JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo," + "JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue,Company.CompanyName " +
                    " FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON " + "JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0) {0} )  " + "fi left join  (select jt.JobTrackDetailID,SUM(rate.Amount*rate.Hrs) as Reimbursement   from JobTrackInvoiceDetail jt inner join " +
                    " JobTrackInvoiceRateDetail rate on jt.JobTrackDetailID = rate.JobTrackDetailID " +
                    " inner join MasterTrackSubDisplay mstr on rate.TrackSubID = mstr.Id where  mstr.TrackName ='Reinburs;' " +
                    " group by jt.JobTrackDetailID )  Reinburs on fi.JobTrackDetailID = Reinburs.JobTrackDetailID left join " +
                    " (select SUM(a.Total) as Total,a.JobTrackDetailID from  ( SELECT  SUM(JobTrackInvoiceRateDetail.Hrs *  JobTrackInvoiceRateDetail.Rate) as Total , JobTrackInvoiceDetail.JobTrackDetailID "
                    + " FROM  dbo.JobTrackInvoiceDetail INNER JOIN dbo.JobTrackInvoiceRateDetail  ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.JobTrackInvoiceRateDetail.JobTrackDetailID GROUP BY JobTrackInvoiceDetail.JobTrackDetailID union SELECT SUM(Time * Rate) AS Revenue,JobTrackInvoiceDetail.JobTrackDetailID FROM dbo.JobTrackInvoiceDetail " +
                    " INNER JOIN dbo.CRVTimeInvoice ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.CRVTimeInvoice.JobTrackDetailID INNER JOIN dbo.JobList " +
                    " ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID WHERE (dbo.JobTrackInvoiceDetail.JobTrackDetailID IN  (SELECT ISNULL(JobTrackDetailID,0) " +
                    " AS Expr1 FROM dbo.JobTrackInvoiceDetail AS JobTrackInvoiceDetail_1)) GROUP BY JobTrackInvoiceDetail.JobTrackDetailID) a group by a.JobTrackDetailID) rev on fi.JobTrackDetailID = rev.JobTrackDetailID left join " +
                    " (SELECT   sum(Expenses) as Expense,JobTrackDetailID  from CRVExpensesInvoice group by JobTrackDetailID) expn  on fi.JobTrackDetailID = expn.JobTrackDetailID order by fi.JobNumber";
                //& SELECT  c.CompanyName FROM Company c INNER JOIN JobList JL ON JL.CompanyID = c.CompanyID INNER JOIN JobTrackInvoiceDetail JT ON JT.JobListID=JL.JobListID

                //Query = "SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo, JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0)"
                if (!string.IsNullOrEmpty(txtCompanyName.Text))
                {
                    innerQuerry = innerQuerry + " AND Company.CompanyName LIKE '% " + txtCompanyName.Text.Trim() + " %'";
                }
                if (!string.IsNullOrEmpty(txtJobNumber.Text))
                {
                    innerQuerry = innerQuerry + " AND JobList.JobNumber LIKE '%" + txtJobNumber.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtAddress.Text))
                {
                    innerQuerry = innerQuerry + " AND Company.Address LIKE '%" + txtAddress.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
                {
                    innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceNo LIKE '%" + txtInvoiceNo.Text.Trim() + "%'";
                }
                if (chkBoxActiveDate.Checked == true)
                {
                    innerQuerry = innerQuerry + " AND JobTrackInvoiceDetail.InvoiceDate BETWEEN '" + dtpFrom.Value.ToString("MM/dd/yyyy") + "' AND '" + dtpTo.Value.ToString("MM/dd/yyyy") + "'";
                }
                //return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    return StMethod.GetListDTNew<QBInvCompare>(string.Format(Query, innerQuerry));
                }
                else
                {
                    return StMethod.GetListDT<QBInvCompare>(string.Format(Query, innerQuerry));
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message.ToString());
            }
            return new DataTable();
        }
        public void FillInvoiceDetail()
        {
            try
            {
                DataTable dt = SearchData();

                grdSearchDetailInvoice.DataSource = dt;
                //.Columns["CompanyName"].HeaderText = "Company Name"
                //.Columns["CompanyName"].Visible = False
                grdSearchDetailInvoice.Columns["JobNumber"].HeaderText = "Job Number";
                grdSearchDetailInvoice.Columns["invoiceAddress"].HeaderText = "Customer Address";

                //.Columns["invoiceAddress"].DefaultCellStyle.WrapMode = DataGridViewTriState.True
                grdSearchDetailInvoice.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                grdSearchDetailInvoice.Columns["InvoiceNo"].HeaderText = "Invoice No";
                grdSearchDetailInvoice.Columns["DueDate"].HeaderText = "Due Date";
                grdSearchDetailInvoice.Columns["Jobdescription"].HeaderText = "Job Description";
                grdSearchDetailInvoice.Columns["PhoneNo"].HeaderText = "Phone No";
                grdSearchDetailInvoice.Columns["FaxNo"].HeaderText = "Fax No";
                grdSearchDetailInvoice.Columns["Email"].HeaderText = "Email Address";
                grdSearchDetailInvoice.Columns["PONo"].HeaderText = "P.O. Number";
                grdSearchDetailInvoice.Columns["PaymentCr"].HeaderText = "Payments/Credit";
                grdSearchDetailInvoice.Columns["BalanceDue"].HeaderText = "Balance Due";
                grdSearchDetailInvoice.Columns["Reimbursement"].HeaderText = "Reimbursement";
                grdSearchDetailInvoice.Columns["Reimbursement"].DefaultCellStyle.Format = "N2";
                grdSearchDetailInvoice.Columns["Revenue"].HeaderText = "Revenue";
                grdSearchDetailInvoice.Columns["Revenue"].DefaultCellStyle.Format = "N2";
                grdSearchDetailInvoice.Columns["Expense"].HeaderText = "Expense";
                grdSearchDetailInvoice.Columns["Expense"].DefaultCellStyle.Format = "N2";
                grdSearchDetailInvoice.Columns["Total"].HeaderText = "Total";
                grdSearchDetailInvoice.Columns["Total"].DefaultCellStyle.Format = "N2";
                grdSearchDetailInvoice.Columns["JobTrackDetailID"].Visible = false;

                if (grdSearchDetailInvoice.Rows.Count > 0)
                {
                    grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.Rows.Count - 1].Selected = true;
                    grdSearchDetailInvoice.CurrentCell = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.Rows.Count - 1].Cells["JobNumber"];
                    int JobTrackDtlID = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);


                    FillRateInvocieDetail(JobTrackDtlID);

                    FillTimeRateInvoiveDetail(JobTrackDtlID, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                    FillExpecesRateInvoiceDetail(JobTrackDtlID, grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                }
                else
                {
                    FillRateInvocieDetail(0);
                    FillTimeRateInvoiveDetail(0, "");
                    FillExpecesRateInvoiceDetail(0, "");
                }
                grdSearchDetailInvoice.Refresh();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Invoice Preview Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetAllReport(int JobtrackInvoiceId, string InvoiceNo)
        {
            DataTable DT = null;

            string Q1 = null;
            string Q2 = null;
            string Q3 = null;

            Q1 = "with AllReport as (SELECT dbo.JobTrackInvoiceDetail.InvoiceNo,convert(varchar(12),JobTrackInvoiceDetail.InvoiceDate,101)as InvoiceDate,dbo.JobTrackInvoiceDetail.Jobdescription, dbo.JobTrackInvoiceDetail.DueDate,dbo.JobTrackInvoiceDetail.Address,dbo.JobTrackInvoiceDetail.PhoneNo, dbo.JobTrackInvoiceDetail.FaxNo, dbo.JobTrackInvoiceDetail.Email,dbo.JobTrackInvoiceRateDetail.Description, dbo.JobTrackInvoiceDetail.JobTrackDetailID,dbo.JobList.JobNumber,dbo.JobTrackInvoiceDetail.PONo,dbo.JobTrackInvoiceDetail.PaymentCr,CONVERT(VARCHAR(20), JobTrackInvoiceRateDetail.Date, 101) as Date, Convert(nvarchar,JobTrackInvoiceRateDetail.Hrs) as Hrs,CONVERT(nvarchar, JobTrackInvoiceRateDetail.Rate) as Rate,dbo.JobTrackInvoiceRateDetail.JobTrackSubName,dbo.JobTrackInvoiceRateDetail.byname,Convert(nvarchar,JobTrackInvoiceRateDetail.Amount) as Amount,   '' as Clienttext, '' as Expenses, 'Item' as ReportType FROM  dbo.JobTrackInvoiceDetail INNER JOIN dbo.JobTrackInvoiceRateDetail ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.JobTrackInvoiceRateDetail.JobTrackDetailID INNER JOIN dbo.JobList ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID LEFT OUTER JOIN dbo.MasterTrackSubItem ON dbo.JobTrackInvoiceRateDetail.TrackSubID = dbo.MasterTrackSubItem.Id where JobTrackInvoiceDetail.JobTrackDetailID = '" + JobtrackInvoiceId + "' and JobTrackInvoiceDetail.InvoiceNo = '" + InvoiceNo + "' ";

            Q2 = "union all SELECT   dbo.JobTrackInvoiceDetail.InvoiceNo,convert(varchar(12),JobTrackInvoiceDetail.InvoiceDate,101)as InvoiceDate,dbo.JobTrackInvoiceDetail.Jobdescription, dbo.JobTrackInvoiceDetail.DueDate,dbo.JobTrackInvoiceDetail.Address, dbo.JobTrackInvoiceDetail.PhoneNo, dbo.JobTrackInvoiceDetail.FaxNo, dbo.JobTrackInvoiceDetail.Email,dbo.CRVTimeInvoice.Description, dbo.JobTrackInvoiceDetail.JobTrackDetailID,  dbo.JobList.JobNumber,  dbo.JobTrackInvoiceDetail.PONo, dbo.JobTrackInvoiceDetail.PaymentCr,CONVERT(VARCHAR(20), CRVTimeInvoice.Date, 101) as Date,Time as Hrs , Rate,JobTrackSubName, Name as byname ,'' as Amount, Clienttext ,'' as Expenses,'Time' as ReportType FROM dbo.JobTrackInvoiceDetail INNER JOIN dbo.CRVTimeInvoice ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.CRVTimeInvoice.JobTrackDetailID INNER JOIN dbo.JobList ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID WHERE (dbo.JobTrackInvoiceDetail.JobTrackDetailID IN (SELECT ISNULL(JobTrackDetailID,0) AS Expr1 FROM dbo.JobTrackInvoiceDetail AS JobTrackInvoiceDetail_1 where JobTrackInvoiceDetail.JobTrackDetailID = '" + JobtrackInvoiceId + "' and JobTrackInvoiceDetail.InvoiceNo = '" + InvoiceNo + "'))";

            Q3 = "union all SELECT dbo.JobTrackInvoiceDetail.InvoiceNo,  convert(varchar(12),JobTrackInvoiceDetail.InvoiceDate,101)as InvoiceDate, dbo.JobTrackInvoiceDetail.Jobdescription, dbo.JobTrackInvoiceDetail.DueDate, dbo.JobTrackInvoiceDetail.Address, dbo.JobTrackInvoiceDetail.PhoneNo, dbo.JobTrackInvoiceDetail.FaxNo, dbo.JobTrackInvoiceDetail.Email, dbo.CRVExpensesInvoice.Description, dbo.JobTrackInvoiceDetail.JobTrackDetailID, dbo.JobList.JobNumber,dbo.JobTrackInvoiceDetail.PONo, dbo.JobTrackInvoiceDetail.PaymentCr, CONVERT(VARCHAR(20), CRVExpensesInvoice.Date, 101) as Date,  '' as Hrs,'' as Rate,'' as JobTrackSubName,  byname,'' as Amount,'' as Clienttext,Expenses,'Expenses' as ReportType FROM dbo.JobTrackInvoiceDetail INNER JOIN dbo.CRVExpensesInvoice ON dbo.JobTrackInvoiceDetail.JobTrackDetailID = dbo.CRVExpensesInvoice.JobTrackDetailID INNER JOIN dbo.JobList ON dbo.JobTrackInvoiceDetail.JobListID = dbo.JobList.JobListID WHERE(dbo.JobTrackInvoiceDetail.JobTrackDetailID IN (SELECT ISNULL(JobTrackDetailID, 0) AS Expr1 FROM dbo.JobTrackInvoiceDetail AS JobTrackInvoiceDetail_1 where JobTrackInvoiceDetail.JobTrackDetailID = '" + JobtrackInvoiceId + "' and JobTrackInvoiceDetail.InvoiceNo = '" + InvoiceNo + "')) ) select * from AllReport order by (case  ReportType when 'Item' then 0 when 'Time' then 1 when 'Expenses' then 2 end)";

            if (!chkEnableReduction.Checked)
            {
                string query = Q1 + Q2 + Q3;

                //DT = StMethod.GetListDT<InvoiceData>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    DT = StMethod.GetListDTNew<InvoiceData>(query);

                }
                else
                {
                    DT = StMethod.GetListDT<InvoiceData>(query);
                }

            }
            else
            {

                //rptInvoiceDt = GetAllReport(grdSearchDetailInvoice.Rows(grdSearchDetailInvoice.CurrentRow.Index).Cells("JobTrackDetailID").Value.ToString, grdSearchDetailInvoice.Rows(grdSearchDetailInvoice.CurrentRow.Index).Cells("InvoiceNo").Value.ToString)

                //SqlCommand cmd = new SqlCommand("sp_InvoiceReportItems", new SqlConnection(DAL.ConnectionStringVariousInfo));
                //TODO-RUNTIME
                //int temp = 0;

                //SqlParameter SP1 = new SqlParameter();
                //SP1.ParameterName = "@JobTrackDetailId";
                //SP1.SqlDbType = SqlDbType.BigInt;
                //SP1.Value = JobtrackInvoiceId;

                //double s1 = 1.0;

                Int64 int123 = 1;

                List<SqlParameter> Param = new List<SqlParameter>();
                
                Param.Add(new SqlParameter("@JobTrackDetailId", SqlDbType.BigInt, 100,ParameterDirection.Input,false,0,0, "JobTrackDetailId",DataRowVersion.Current, int123));


                //Param.Add(new SqlParameter("@InvoiceNo", InvoiceNo));
                //Param.Add(new SqlParameter("@Reduction", txtReduction.Value));
                //Param.Add(new SqlParameter("@ItemReduc", Convert.ToInt32(chkItemReduc.CheckState)));
                //Param.Add(new SqlParameter("@TimeReduc", Convert.ToInt32(chkTimeReduc.CheckState)));
                //Param.Add(new SqlParameter("@ExpReduc", Convert.ToInt32(chkExpReduc.CheckState)));


                //new SqlParameter("@JobTrackDetailId", SqlDbType.BigInt, 100, ParameterDirection.Input, true, 0, 0, "JobTrackDetailId", DataRowVersion.Current, JobtrackInvoiceId),

                //DT = StMethod.GetListDT<string>("sp_InvoiceReportItemsTesting", Param);


                try
                {

                    //SqlParameter parameter = new SqlParameter("@Description",SqlDbType.VarChar, 11, ParameterDirection.Input,
                    //            true, 0, 0, "Description", DataRowVersion.Current,"garden hose");

                    // MessageBox.Show(JobtrackInvoiceId.ToString());


                    //DT = StMethod.GetListDT<string>("sp_InvoiceReportItems", new List<SqlParameter>(new[]

                    //DT = StMethod.GetListDT<string>("sp_InvoiceReportItemsTesting @JobTrackDetailId,@InvoiceNo,@Reduction,@ItemReduc,@TimeReduc,@ExpReduc");


                    //DT = StMethod.GetListDT<InvoiceData>(query);




                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {


                        DT = StMethod.GetListDTNew3<InvoiceData>("sp_InvoiceReportItems", new List<SqlParameter>(new[]

                        //DT = StMethod.GetListDT<string>("exec sp_InvoiceReportItems @JobTrackDetailId,@InvoiceNo, @Reduction,@ItemReduc,@TimeReduc,@ExpReduc", new List<SqlParameter>(new[]
                        {
                            //new SqlParameter("@InvoiceNo", InvoiceNo),

                            new SqlParameter("@JobTrackDetailId",SqlDbType.BigInt,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId),
                            new SqlParameter("@InvoiceNo",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"InvoiceNo",DataRowVersion.Current,InvoiceNo),
                            new SqlParameter("@Reduction", txtReduction.Value),
                            new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                            new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                            new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))
                            //new SqlParameter ("@JobTrackDetailId",SqlDbType.BigInt,1000,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId)

                            	//@JobTrackDetailId BIGINT,
                             //   @InvoiceNo NVARCHAR(MAX),
                             //   @Reduction DECIMAL(10,2)=0.0,
                             //   @ItemReduc BIT=0,
                             //   @TimeReduc BIT=0

                        }

                                       )); ;





                    }
                    else
                    {
                        DT = StMethod.GetListDT<InvoiceData>("sp_InvoiceReportItems", new List<SqlParameter>(new[]

                        //DT = StMethod.GetListDT<string>("exec sp_InvoiceReportItems @JobTrackDetailId,@InvoiceNo, @Reduction,@ItemReduc,@TimeReduc,@ExpReduc", new List<SqlParameter>(new[]
                        {
                            //new SqlParameter("@InvoiceNo", InvoiceNo),

                            new SqlParameter("@JobTrackDetailId",SqlDbType.BigInt,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId),
                            new SqlParameter("@InvoiceNo",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"InvoiceNo",DataRowVersion.Current,InvoiceNo),
                            new SqlParameter("@Reduction", txtReduction.Value),
                            new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                            new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                            new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))
                            //new SqlParameter ("@JobTrackDetailId",SqlDbType.BigInt,1000,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId)

                            	//@JobTrackDetailId BIGINT,
                             //   @InvoiceNo NVARCHAR(MAX),
                             //   @Reduction DECIMAL(10,2)=0.0,
                             //   @ItemReduc BIT=0,
                             //   @TimeReduc BIT=0

                        }

                    )); ;





                    }

                    //    DT = StMethod.GetListDT<InvoiceData>("sp_InvoiceReportItems", new List<SqlParameter>(new[]

                    //    //DT = StMethod.GetListDT<string>("exec sp_InvoiceReportItems @JobTrackDetailId,@InvoiceNo, @Reduction,@ItemReduc,@TimeReduc,@ExpReduc", new List<SqlParameter>(new[]
                    //    {
                    //    //new SqlParameter("@InvoiceNo", InvoiceNo),

                    //    new SqlParameter("@JobTrackDetailId",SqlDbType.BigInt,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId),
                    //    new SqlParameter("@InvoiceNo",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"InvoiceNo",DataRowVersion.Current,InvoiceNo),
                    //    new SqlParameter("@Reduction", txtReduction.Value),
                    //    new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                    //    new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                    //    new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))
                    //    //new SqlParameter ("@JobTrackDetailId",SqlDbType.BigInt,1000,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId)

                    //    	//@JobTrackDetailId BIGINT,
                    //     //   @InvoiceNo NVARCHAR(MAX),
                    //     //   @Reduction DECIMAL(10,2)=0.0,
                    //     //   @ItemReduc BIT=0,
                    //     //   @TimeReduc BIT=0

                    //}

                    //));;







                    //new SqlParameter("@InvoiceNo", InvoiceNo),
                    //new SqlParameter("@Reduction", txtReduction.Value),
                    //new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                    //new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                    //new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))

                    //new SqlParameter("@JobTrackDetailId",SqlDbType.BigInt, JobtrackInvoiceId),
                    //new SqlParameter("@InvoiceNo",SqlDbType.NVarChar, 1),
                    //new SqlParameter("@Reduction",SqlDbType.Decimal,1),
                    //new SqlParameter("@ItemReduc",SqlDbType.Bit,Convert.ToInt32(chkItemReduc.CheckState)),
                    //new SqlParameter("@TimeReduc",SqlDbType.Bit,Convert.ToInt32(chkTimeReduc.CheckState)),
                    //new SqlParameter("@ExpReduc",SqlDbType.Bit,Convert.ToInt32(chkExpReduc.CheckState)),

                    //@JobTrackDetailId BIGINT,
                    //@InvoiceNo NVARCHAR(MAX),
                    //@Reduction DECIMAL(10,2)=0.0,
                    //@ItemReduc BIT=0,
                    //@TimeReduc BIT=0,
                    //@ExpReduc BIT=0

                    //cmd.Parameters.Add("@units", SqlDbType.Int).Value = units ?? (object)DBNull.Value;

                    //new SqlParameter("@ItemReduc", Convert.ToInt32(chkItemReduc.CheckState)),
                    //new SqlParameter("@TimeReduc", Convert.ToInt32(chkTimeReduc.CheckState)),
                    //new SqlParameter("@ExpReduc", Convert.ToInt32(chkExpReduc.CheckState))


                }
                catch (Exception ex)
            {
                    MessageBox.Show(ex.Message.ToString());
            }
            
                }
            DT = Remove_EmptyLine_Space(DT, "Address");
            return DT;
        }

        public DataTable Remove_EmptyLine_Space(DataTable DataTable, string ColumnName)
        {

            try
            {
                if (DataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < DataTable.Rows.Count; i++)
                    {
                        string Address = DataTable.Rows[i][ColumnName].ToString();
                        DataTable.Rows[i][ColumnName] = Remove_EmptyLine_Space(Address);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return DataTable;
        }

        public string Remove_EmptyLine_Space(string StringText)
        {
            string CorrectAddress = StringText;
            try
            {
                if (!string.IsNullOrEmpty(StringText))
                {
                    string[] Seprators = new string[1];
                    Seprators[0] = Environment.NewLine;
                    string[] SplitedData = StringText.Split(Seprators, StringSplitOptions.RemoveEmptyEntries);

                    if (SplitedData.Length > 0)
                    {
                        string[] SplitedDataFinal = SplitedData.Where((w) => !string.IsNullOrEmpty(w.Trim())).ToArray();
                        CorrectAddress = string.Join(Environment.NewLine, SplitedDataFinal);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                CorrectAddress = StringText;
            }


            return CorrectAddress;
        }

        public void UpdateInvoiceDetail()
        {
            try
            {

                string Date101, Date102 = null;
                
                string Date103, Date104 = null;

                Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                string FinalDateUpdate = string.Empty;


                Nullable<DateTime> ActionDateUpdate2 = DateTime.Now;

                string FinalDateUpdate2 = string.Empty;

                if (grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value == null || grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value.ToString()))
                {
                    // here is your message box...


                }
                else
                {
                    //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                    Date101 = string.Format("{0:dd/MM/yyyy}", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value.ToString());
                }

                if (grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Tag == null || grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Tag.ToString()))
                {
                    // here is your message box...

                    //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                    //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                    Date102 = string.Format("{0:dd/MM/yyyy}", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value.ToString());

                    ActionDateUpdate = DateTime.Parse(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.Rows.Count-1].Cells["InvoiceDate"].Value.ToString());

                    int s, s1, s2;

                    //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                    //int s, s1, s2;

                    //11-22-2021 05:34:05 PM

                    s = ActionDateUpdate.Value.Month;
                    s1 = ActionDateUpdate.Value.Day;
                    s2 = ActionDateUpdate.Value.Year;

                    FinalDateUpdate = ActionDateUpdate.Value.Month.ToString() + "-" + ActionDateUpdate.Value.Day.ToString() + "-" + ActionDateUpdate.Value.Year.ToString() + " " + ActionDateUpdate.Value.Hour.ToString() + ":" + ActionDateUpdate.Value.Minute.ToString()
                        + ":" + ActionDateUpdate.Value.Second.ToString() + " " + ActionDateUpdate.Value.ToString("tt");


                    Date102 = FinalDateUpdate;

                }
                else
                {
                    Date102 = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Tag.ToString();
                }










                if (grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value == null || grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value.ToString()))
                {
                    // here is your message box...


                }
                else
                {
                    //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                    Date103 = string.Format("{0:dd/MM/yyyy}", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value.ToString());
                }



                if (grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Tag == null || grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Tag.ToString()))
                {
                    // here is your message box...

                    //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                    //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                    Date104 = string.Format("{0:dd/MM/yyyy}", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value.ToString());

                    //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                    ActionDateUpdate2 = DateTime.Parse(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.Rows.Count - 1].Cells["DueDate"].Value.ToString());

                    int s, s1, s2;

                    //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                    //int s, s1, s2;

                    //11-22-2021 05:34:05 PM

                    s = ActionDateUpdate2.Value.Month;
                    s1 = ActionDateUpdate2.Value.Day;
                    s2 = ActionDateUpdate2.Value.Year;

                    FinalDateUpdate2 = ActionDateUpdate2.Value.Month.ToString() + "-" + ActionDateUpdate2.Value.Day.ToString() + "-" + ActionDateUpdate2.Value.Year.ToString() + " " + ActionDateUpdate2.Value.Hour.ToString() + ":" + ActionDateUpdate2.Value.Minute.ToString()
                        + ":" + ActionDateUpdate2.Value.Second.ToString() + " " + ActionDateUpdate2.Value.ToString("tt");


                    Date104 = FinalDateUpdate2;

                }
                else
                {
                    Date104 = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Tag.ToString();
                }










                string Query = "UPDATE JobTrackInvoiceDetail SET [InvoiceNo] = @InvoiceNo,[InvoiceDate] = @InvoiceDate, [Jobdescription] = @Jobdescription ,[DueDate] = @DueDate,[Address] = @Address,[PhoneNo] = @PhoneNo,[FaxNo] = @FaxNo, [Email] = @Email,[PONo] = @PONo,[PaymentCr] = @PaymentCr,[BalanceDue] = @BalanceDue WHERE JobTrackDetailID=@JobTrackDetailID";
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@InvoiceNo", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString()));

                //String EditedInvoiceDate;
                //EditedInvoiceDate = string.Format("MM/dd/yyyy", 
                //    grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value.ToString());

                //EditedInvoiceDate = (DateTime.Parse(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value.ToString())).ToString("MM/d/yyyy");


                //Param.Add(new SqlParameter("@InvoiceDate", (DateTime.Parse(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value.ToString())).ToString("MM/d/yyyy")));

                 Param.Add(new SqlParameter("@InvoiceDate", Date102));

                //Param.Add(new SqlParameter("@InvoiceDate", string.Format("MM/dd/yyyy", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value)));

                //Param.Add(new SqlParameter("@InvoiceDate", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value));

                Param.Add(new SqlParameter("@Jobdescription", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["Jobdescription"].Value.ToString()));

                Param.Add(new SqlParameter("@DueDate", Date104));

                //Param.Add(new SqlParameter("@DueDate", (DateTime.Parse(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value.ToString())).ToString("MM/d/yyyy")));



                //Param.Add(new SqlParameter("@DueDate", string.Format("MM/dd/yyyy", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value)));


                //Param.Add(new SqlParameter("@DueDate", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value));


                Param.Add(new SqlParameter("@Address", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["invoiceAddress"].Value.ToString()));
                Param.Add(new SqlParameter("@PhoneNo", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["PhoneNo"].Value.ToString()));
                Param.Add(new SqlParameter("@FaxNo", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["FaxNo"].Value.ToString()));
                Param.Add(new SqlParameter("@PONo", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["PONo"].Value.ToString()));
                Param.Add(new SqlParameter("@PaymentCr", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["PaymentCr"].Value.ToString()));
                Param.Add(new SqlParameter("@BalanceDue", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["BalanceDue"].Value.ToString()));
                Param.Add(new SqlParameter("@Email", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["Email"].Value.ToString()));
                Param.Add(new SqlParameter("@JobTrackDetailID", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString()));

                //int UpID = StMethod.UpdateRecord(Query, Param);
                //if (UpID > 0)
                //{
                //    grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                //    grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                //    KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    StMethod.LoginActivityInfo("Update", this.Name);
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    int UpID2 = StMethod.UpdateRecordNew(Query, Param);
                    if (UpID2 > 0)
                    {
                        grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                        grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                        KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StMethod.LoginActivityInfoNew("Update", this.Name);
                    }
                }
                else
                {
                    int UpID = StMethod.UpdateRecord(Query, Param);
                    if (UpID > 0)
                    {
                        grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                        grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                        KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        StMethod.LoginActivityInfo("Update", this.Name);
                    }
                }

            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex1)
            {
                KryptonMessageBox.Show(Ex1.Message, "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //sqlCon.Close();
            }
        }

        public void FillRateInvocieDetail(int InvoiceDetailID, bool ApplyReduction = false)
        {
            string Query = null;
            string reductionStr = ApplyReduction ? string.Format("dbo.fn_Reduction(Rate,{0},{1}) AS Rate", txtReduction.Value, Convert.ToInt32(chkItemReduc.CheckState)) : "Rate";
            Query = "SELECT JobTrackSubName, Description, Hrs," + reductionStr + ",InvoiceRptID,JobTrackDetailID, JobTrackingID FROM  JobTrackInvoiceRateDetail WhERE JobTrackDetailID=" + InvoiceDetailID;
            try
            {
                //if (ApplyReduction)
                //    grdSearchRateInvoice.DataSource = StMethod.GetListDT<RateInvoiceDtl>(Query);
                //else
                //    grdSearchRateInvoice.DataSource = StMethod.GetListDT<dtoRateInvoiceDtl>(Query);



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    if (ApplyReduction)
                        grdSearchRateInvoice.DataSource = StMethod.GetListDTNew<RateInvoiceDtl>(Query);
                    else
                        grdSearchRateInvoice.DataSource = StMethod.GetListDTNew<dtoRateInvoiceDtl>(Query);
                }
                else
                {
                    if (ApplyReduction)
                        grdSearchRateInvoice.DataSource = StMethod.GetListDT<RateInvoiceDtl>(Query);
                    else
                        grdSearchRateInvoice.DataSource = StMethod.GetListDT<dtoRateInvoiceDtl>(Query);


                }

                grdSearchRateInvoice.Columns["JobTrackSubName"].HeaderText = "Item";
                grdSearchRateInvoice.Columns["JobTrackSubName"].Width = 200;
                grdSearchRateInvoice.Columns["Description"].HeaderText = "Description";
                grdSearchRateInvoice.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
                grdSearchRateInvoice.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdSearchRateInvoice.Columns["Hrs"].HeaderText = "Hrs";
                grdSearchRateInvoice.Columns["Hrs"].Width = 80;
                grdSearchRateInvoice.Columns["Rate"].HeaderText = "Rate";
                grdSearchRateInvoice.Columns["Rate"].Width = 80;
                grdSearchRateInvoice.Columns["InvoiceRptID"].Visible = false;
                grdSearchRateInvoice.Columns["JobTrackDetailID"].Visible = false;
                grdSearchRateInvoice.Columns["JobTrackingID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public void FillTimeRateInvoiveDetail(int TimeInvoiceDetailID, string InvoiceNumber, bool ApplyReduction = false)
        {
            string Query = null;
            string reductionStr = ApplyReduction ? string.Format("dbo.fn_Reduction(Rate,{0},{1})", txtReduction.Value, Convert.ToInt32(chkTimeReduc.CheckState)) : "Rate";

            Query = "select CRVTimeInvoiceId,  CRVTimeInvoice.JobTrackDetailID, Name as 'By',JobTrackSubName as Item,Description,Time as Hrs," + reductionStr + " AS Rate,(CAST(" + reductionStr + " AS DECIMAL)*Time) as Amount,TimeSheetID from CRVTimeInvoice  left join JobTrackInvoiceDetail as JTD on jtd.JobTrackDetailID = CRVTimeInvoice.JobTrackDetailID where  jtd.JobTrackDetailID = " + TimeInvoiceDetailID + " and jtd.InvoiceNo = '" + InvoiceNumber + "' ";

            try
            {
                //grdTimeSearchRateInvoice.DataSource = StMethod.GetListDT<InvTimeRate>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    grdTimeSearchRateInvoice.DataSource = StMethod.GetListDTNew<InvTimeRate>(Query);

                }
                else
                {
                    grdTimeSearchRateInvoice.DataSource = StMethod.GetListDT<InvTimeRate>(Query);
                }

                grdTimeSearchRateInvoice.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
                grdTimeSearchRateInvoice.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                grdTimeSearchRateInvoice.Columns["Item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grdTimeSearchRateInvoice.Columns["Item"].Width = 60;

                //grdTimeSearchRateInvoice.Columns[5].Width = 60;

                //grdTimeSearchRateInvoice.Columns["Hrs"].Width = 50;

                grdTimeSearchRateInvoice.Columns["By"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grdTimeSearchRateInvoice.Columns["Rate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                grdTimeSearchRateInvoice.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                grdTimeSearchRateInvoice.Columns["By"].Width = 50;
                grdTimeSearchRateInvoice.Columns["Rate"].Width = 60;
                grdTimeSearchRateInvoice.Columns["Amount"].Width = 60;

                grdTimeSearchRateInvoice.Columns["CRVTimeInvoiceId"].Visible = false;
                grdTimeSearchRateInvoice.Columns["JobTrackDetailID"].Visible = false;
                grdTimeSearchRateInvoice.Columns["TimeSheetID"].Visible = false;
                grdTimeSearchRateInvoice.Columns["Item"].ReadOnly = true;
                grdTimeSearchRateInvoice.Columns["Amount"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void FillExpecesRateInvoiceDetail(int ExpInvoiceDetailID, string invoiceNumber, bool ApplyReduction = false)
        {
            string Query = null;
            string reductionStr = ApplyReduction ? string.Format("dbo.fn_Reduction(Expenses,{0},{1})", txtReduction.Value, Convert.ToInt32(chkExpReduc.CheckState)) : "Expenses";

            Query = "SELECT CRVExpensesInvoiceID,CRVExpensesInvoice.JobTrackDetailID,byname as 'By', '' as Item ,Description,'' as Hrs ,0.00 as Rate, " + reductionStr + " as Amount, TimeSheetExpencesID from CRVExpensesInvoice  left join JobTrackInvoiceDetail as JTD on jtd.JobTrackDetailID = CRVExpensesInvoice.JobTrackDetailID  where  jtd.JobTrackDetailID = " + ExpInvoiceDetailID + " and  jtd.InvoiceNo = '" + invoiceNumber + "'";

            try
            {
                DataTable dt;


                //if (ApplyReduction)
                //    dt = StMethod.GetListDT<dtoInvExpRate>(Query);
                //else
                //    dt = StMethod.GetListDT<InvExpRate>(Query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    if (ApplyReduction)
                        dt = StMethod.GetListDTNew<dtoInvExpRate>(Query);
                    else
                        dt = StMethod.GetListDTNew<InvExpRate>(Query);
                }
                else
                {
                    if (ApplyReduction)
                        dt = StMethod.GetListDT<dtoInvExpRate>(Query);
                    else
                        dt = StMethod.GetListDT<InvExpRate>(Query);
                }



                if (dt.Rows.Count > 0)
                {
                    grdExpensesSearchRateInvoice.DataSource = dt;


                    grdExpensesSearchRateInvoice.Columns["Hrs"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    grdExpensesSearchRateInvoice.Columns["By"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    grdExpensesSearchRateInvoice.Columns["Item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    grdExpensesSearchRateInvoice.Columns["Rate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    grdExpensesSearchRateInvoice.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                    grdExpensesSearchRateInvoice.Columns["Hrs"].Width = 50;
                    grdExpensesSearchRateInvoice.Columns["By"].Width = 50;
                    grdExpensesSearchRateInvoice.Columns["Item"].Width = 60;
                    grdExpensesSearchRateInvoice.Columns["Rate"].Width = 60;
                    grdExpensesSearchRateInvoice.Columns["Amount"].Width = 60;
                    grdExpensesSearchRateInvoice.Columns["CRVExpensesInvoiceID"].Visible = false;
                    grdExpensesSearchRateInvoice.Columns["JobTrackDetailID"].Visible = false;
                    grdExpensesSearchRateInvoice.Columns["Description"].DefaultCellStyle.WrapMode = DataGridViewTriState.NotSet;
                    grdExpensesSearchRateInvoice.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grdExpensesSearchRateInvoice.Columns["TimeSheetExpencesID"].Visible = false;

                    grdExpensesSearchRateInvoice.Columns["Hrs"].ReadOnly = true;
                    grdExpensesSearchRateInvoice.Columns["Rate"].ReadOnly = true;
                    grdExpensesSearchRateInvoice.Columns["Item"].ReadOnly = true;
                }

                else
                {
                    grdExpensesSearchRateInvoice.DataSource = null;

                }


            }
            catch (Exception ex)
            {
                //MessageBox.Show( ex.Message);
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void UpdateRateDetail()
        {
            string Query = null;
            try
            {
                Query = "UPDATE JobTrackInvoiceRateDetail  SET [JobTrackSubName] = @Item ,[Hrs] = @Hrs,[Rate] = @Rate ,[Description] = @Description WHERE InvoiceRptID=@InvoiceRptID";

                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@Item", grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["JobTrackSubName"].Value.ToString()));
                Param.Add(new SqlParameter("@Hrs", grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["Hrs"].Value.ToString()));
                Param.Add(new SqlParameter("@Rate", grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["Rate"].Value.ToString()));
                Param.Add(new SqlParameter("@Description", grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["Description"].Value.ToString()));
                Param.Add(new SqlParameter("@InvoiceRptID", grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].Cells["InvoiceRptID"].Value.ToString()));

                //int UpID = StMethod.UpdateRecord(Query, Param);

                int UpID;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    UpID = StMethod.UpdateRecordNew(Query, Param);

                }
                else
                {
                    UpID = StMethod.UpdateRecord(Query, Param);
                }

                if (UpID > 0)
                {
                    grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                    grdSearchRateInvoice.Rows[grdSearchRateInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                    KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex1)
            {
                KryptonMessageBox.Show(Ex1.Message, "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateTimeDetail()
        {
            string Query = null;
            try
            {
                Query = "UPDATE CRVTimeInvoice  SET [Name] = @Name ,[Time] = @Time,[Rate] = @Rate ,[Description] = @Description WHERE CRVTimeInvoiceId=@CRVTimeInvoiceId";

                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@Name", grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].Cells["By"].Value.ToString()));
                Param.Add(new SqlParameter("@Time", grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].Cells["Hrs"].Value.ToString()));
                Param.Add(new SqlParameter("@Rate", grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].Cells["Rate"].Value.ToString()));
                Param.Add(new SqlParameter("@Description", grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].Cells["Description"].Value.ToString()));
                Param.Add(new SqlParameter("@CRVTimeInvoiceId", grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].Cells["CRVTimeInvoiceId"].Value.ToString()));

                //int UpID = StMethod.UpdateRecord(Query, Param);

                int UpID;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    UpID = StMethod.UpdateRecordNew(Query, Param);
                }
                else
                {
                    UpID = StMethod.UpdateRecord(Query, Param);
                }

                if (UpID > 0)
                {
                    grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                    grdTimeSearchRateInvoice.Rows[grdTimeSearchRateInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                    KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex1)
            {
                KryptonMessageBox.Show(Ex1.Message, "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //sqlCon.Close();
            }
        }

        public void UpdateExpensesDetail()
        {
            string Query = null;
            try
            {
                Query = "UPDATE CRVExpensesInvoice  SET [byname] = @byname ,[Expenses] = @Expenses,[Description] = @Description WHERE CRVExpensesInvoiceID=@CRVExpensesInvoiceID";

                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@byname", grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].Cells["By"].Value.ToString()));
                Param.Add(new SqlParameter("@Expenses", grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].Cells["Amount"].Value.ToString()));
                Param.Add(new SqlParameter("@Description", grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].Cells["Description"].Value.ToString()));
                Param.Add(new SqlParameter("@CRVExpensesInvoiceID", grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].Cells["CRVExpensesInvoiceID"].Value.ToString()));

                //int UpID = StMethod.UpdateRecord(Query, Param);

                int UpID;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    UpID = StMethod.UpdateRecordNew(Query, Param);
                }
                else
                {
                    UpID = StMethod.UpdateRecord(Query, Param);
                }


                if (UpID > 0)
                {
                    grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                    grdExpensesSearchRateInvoice.Rows[grdExpensesSearchRateInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                    KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception Ex1)
            {
                KryptonMessageBox.Show(Ex1.Message, "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //sqlCon.Close();
            }
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
                MessageBox.Show(ex.Message.ToString());
                return Str;
            }
        }
        private bool UndoAndDelete(int JobTrackDetailId, bool isUndo)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();
            if (isUndo)
            {
                string msgStr = "";
                if (grdSearchRateInvoice.Rows.Cast<DataGridViewRow>().Any((r) => Convert.IsDBNull(r.Cells["JobTrackingID"].Value) | string.IsNullOrEmpty(r.Cells["JobTrackingID"].Value.ToString())))
                {
                    msgStr = msgStr + "Unable to perform undo with some of Item Invoices, due to refer id not available." + "\r\n";
                }
                if (grdTimeSearchRateInvoice.Rows.Cast<DataGridViewRow>().Any((r) => Convert.IsDBNull(r.Cells["TimeSheetID"].Value) | string.IsNullOrEmpty(r.Cells["TimeSheetID"].Value.ToString())))
                {
                    msgStr = msgStr + "Unable to perform undo with some of Time Invoices, due to refer id not available." + "\r\n";
                }
                if (grdExpensesSearchRateInvoice.Rows.Cast<DataGridViewRow>().Any((r) => Convert.IsDBNull(r.Cells["TimeSheetExpencesID"].Value) | string.IsNullOrEmpty(r.Cells["TimeSheetExpencesID"].Value.ToString())))
                {
                    msgStr = msgStr + "Unable to perform undo with some of Expense Invoice due to refer id not available." + "\r\n";
                }
                if (!string.IsNullOrEmpty(msgStr))
                {
                    msgStr = "Selected invoice created in older version, so system would not able to perform undo due to below reason" + "\r\n" + msgStr;
                    MessageBox.Show(msgStr, "Search Invoice", MessageBoxButtons.OK);
                    if (MessageBox.Show("Still want to perform Undo operation, that may cause lose your data and Invoice status will not be update", "Search Invoice", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        return false;
                    }
                }
            }

            sqlParam.Add(new SqlParameter("@JobTrackDetailId", JobTrackDetailId));
            sqlParam.Add(new SqlParameter("@isUndo", isUndo));
            
            
            //StMethod.UpdateRecord("spUndoInvoiceDetails", sqlParam);



            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                StMethod.UpdateRecordNew("spUndoInvoiceDetails", sqlParam);
            }
            else
            {
                StMethod.UpdateRecord("spUndoInvoiceDetails", sqlParam);
            }


            //StMethod.UpdateRecord("spUndoInvoiceDetailsTetsing", sqlParam);
            return true;
        }
        private void CaclulateReductionInvoiceDetail()
        {

            try
            { 
            DataGridViewCell CellReinburs = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["Reimbursement"];
            DataGridViewCell CellExpense = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["Expense"];
            DataGridViewCell CellRevenue = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["Revenue"];
            DataGridViewCell CellTotal = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["Total"];
            object jtdId = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value;
            DataTable dt = new DataTable();

                //   dt = StMethod.GetListDT<InvReduction>("sp_InvoiceDetailReductioTesting", new List<SqlParameter>(new[]
                //  {
                //    //new SqlParameter("@JobTrackDetailId", jtdId),
                //     new SqlParameter("@JobTrackDetailId",SqlDbType.Int,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,jtdId),
                //    new SqlParameter("@Reduction", txtReduction.Value),
                //    new SqlParameter("@ItemReduc", Convert.ToInt32(chkItemReduc.CheckState)),
                //    new SqlParameter("@TimeReduc", Convert.ToInt32(chkTimeReduc.CheckState)),
                //    new SqlParameter("@ExpenseReduc", Convert.ToInt32(chkExpReduc.CheckState))
                //}));

                //object Red = Convert.ToDecimal(txtReduction.Value);
                
                object Red = txtReduction.Value;                
                decimal dece3 = Convert.ToDecimal(txtReduction.Value);
                
                int InvoiceNo = Convert.ToInt32(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value);


                //SqlDbType.Decimal s1;

                bool chkItemRed;

                if (chkItemReduc.Checked)
                {
                    chkItemRed = true;                
                }
                else
                {
                    chkItemRed = false;

                }

                bool chkItemRe;

                if (chkItemReduc.Checked)
                {
                    chkItemRe = true;
                }
                else
                {
                    chkItemRe = false;

                }

                //Param.Add(new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)));
                //Param.Add(new SqlParameter("@TimeReduc", Convert.ToBoolean(chkItemReduc.CheckState)));


                //ALTER PROCEDURE[dbo].[sp_InvoiceDetailReductioTesting]
                //@JobTrackDetailId as BIGINT = null,
                //@Reduction as DECIMAL(10, 2) = 1.0,
                //@ItemReduc as BIT = 0,
                //@TimeReduc as BIT = 0,
                //@ExpenseReduc as BIT = 0


                //new SqlParameter("@JobTrackDetailId", SqlDbType.BigInt, 100, ParameterDirection.Input, true, 0, 0, "JobTrackDetailId", DataRowVersion.Current, JobtrackInvoiceId),
                //    new SqlParameter("@InvoiceNo", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "InvoiceNo", DataRowVersion.Current, InvoiceNo),
                //    new SqlParameter("@Reduction", txtReduction.Value),
                //    new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                //    new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                //    new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))


                List <SqlParameter> Param = new List<SqlParameter>();

                Param.Add(new SqlParameter("@JobTrackDetailId", SqlDbType.BigInt, 100, ParameterDirection.Input, false, 0, 0, "JobTrackDetailId", DataRowVersion.Current, jtdId));

                Param.Add(new SqlParameter("@InvoiceNo", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, "InvoiceNo", DataRowVersion.Current, InvoiceNo));

                Param.Add(new SqlParameter("@Reduction", SqlDbType.Decimal, 100, ParameterDirection.Input, false, 0, 0, "Reduction", DataRowVersion.Current, dece3));

                Param.Add(new SqlParameter("@ItemReduc", chkItemRed));
                Param.Add(new SqlParameter("@TimeReduc", chkItemRe));
                //Param.Add(new SqlParameter("@ExpReduc", Convert.ToBoolean(chkItemReduc.CheckState)));


                //new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                //new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                //new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))

                //dt = StMethod.GetListDT<InvReductionEdit>("sp_InvoiceDetailReductioTesting", Param);

                //InvoiceData
                //InvReductionEdit










               // dt = StMethod.GetListDT<InvReductionEditNew>("sp_InvoiceDetailReduction", new List<SqlParameter>(new[]



               ////DT = StMethod.GetListDT<string>("exec sp_InvoiceReportItems @JobTrackDetailId,@InvoiceNo, @Reduction,@ItemReduc,@TimeReduc,@ExpReduc", new List<SqlParameter>(new[]
               //{
               //     //new SqlParameter("@InvoiceNo", InvoiceNo),

               //     new SqlParameter("@JobTrackDetailId",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,jtdId),
               //     new SqlParameter("@InvoiceNo",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"InvoiceNo",DataRowVersion.Current,InvoiceNo),
               //     new SqlParameter("@Reduction", txtReduction.Value),
               //     new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
               //     new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
               //     new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))
               //     //new SqlParameter ("@JobTrackDetailId",SqlDbType.BigInt,1000,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId)
                    
               //     	//@JobTrackDetailId BIGINT,
               //      //   @InvoiceNo NVARCHAR(MAX),
               //      //   @Reduction DECIMAL(10,2)=0.0,
               //      //   @ItemReduc BIT=0,
               //      //   @TimeReduc BIT=0

               // }

               //)); ;






                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew3<InvReductionEditNew>("sp_InvoiceDetailReduction", new List<SqlParameter>(new[]



                   //DT = StMethod.GetListDT<string>("exec sp_InvoiceReportItems @JobTrackDetailId,@InvoiceNo, @Reduction,@ItemReduc,@TimeReduc,@ExpReduc", new List<SqlParameter>(new[]
                   {
                         //new SqlParameter("@InvoiceNo", InvoiceNo),

                         new SqlParameter("@JobTrackDetailId",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,jtdId),
                         new SqlParameter("@InvoiceNo",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"InvoiceNo",DataRowVersion.Current,InvoiceNo),
                         new SqlParameter("@Reduction", txtReduction.Value),
                         new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                         new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                         new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))
                         //new SqlParameter ("@JobTrackDetailId",SqlDbType.BigInt,1000,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId)

                         	//@JobTrackDetailId BIGINT,
                          //   @InvoiceNo NVARCHAR(MAX),
                          //   @Reduction DECIMAL(10,2)=0.0,
                          //   @ItemReduc BIT=0,
                          //   @TimeReduc BIT=0

                     }

                   )); ;

                }
                else
                {
                    dt = StMethod.GetListDT<InvReductionEditNew>("sp_InvoiceDetailReduction", new List<SqlParameter>(new[]



                    //DT = StMethod.GetListDT<string>("exec sp_InvoiceReportItems @JobTrackDetailId,@InvoiceNo, @Reduction,@ItemReduc,@TimeReduc,@ExpReduc", new List<SqlParameter>(new[]
                    {
                        //new SqlParameter("@InvoiceNo", InvoiceNo),

                        new SqlParameter("@JobTrackDetailId",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,jtdId),
                        new SqlParameter("@InvoiceNo",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"InvoiceNo",DataRowVersion.Current,InvoiceNo),
                        new SqlParameter("@Reduction", txtReduction.Value),
                        new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                        new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                        new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))
                        //new SqlParameter ("@JobTrackDetailId",SqlDbType.BigInt,1000,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId)
                    
                    	    //@JobTrackDetailId BIGINT,
                         //   @InvoiceNo NVARCHAR(MAX),
                         //   @Reduction DECIMAL(10,2)=0.0,
                         //   @ItemReduc BIT=0,
                         //   @TimeReduc BIT=0

                    }

                    )); ;
                }












                //  dt = StMethod.GetListDT<InvReductionEdit>("sp_InvoiceDetailReductioTesting", new List<SqlParameter>(new[]
                //{
                //         new SqlParameter("@JobTrackDetailId",SqlDbType.BigInt,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,jtdId),
                //           //new SqlParameter("@Reduction", txtReduction.Value),
                //        //new SqlParameter("@ItemReduc", Convert.ToInt32(chkItemReduc.CheckState)),
                //        //new SqlParameter("@TimeReduc", Convert.ToInt32(chkTimeReduc.CheckState)),
                //        //new SqlParameter("@ExpenseReduc", Convert.ToInt32(chkExpReduc.CheckState))


                //         new SqlParameter("@Reduction",SqlDbType.NVarChar,100,ParameterDirection.Input,false,0,0,"@Reduction",DataRowVersion.Current,txtReduction.Value.ToString()),

                //        //new SqlParameter("@Reduction",SqlDbType.Decimal,100,ParameterDirection.Input,false,0,0,"Reduction",DataRowVersion.Current,Convert.ToDecimal(txtReduction.Value.ToString())),

                //        //new SqlParameter("@Reduction",SqlDbType.Decimal,100,ParameterDirection.Input,true,1,1,"Reduction",DataRowVersion.Current,Convert.ToDecimal(dece2)),
                //        //new SqlParameter("@InvoiceNo",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"InvoiceNo",DataRowVersion.Current,InvoiceNo),

                //        new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                //        new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                //        new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))

                //    }));


                //ALTER PROCEDURE[dbo].[sp_InvoiceDetailReductioTesting]
                //@JobTrackDetailId as BIGINT = null,
                //@Reduction as DECIMAL(10, 2) = 0.0,
                //@ItemReduc as BIT = 0,
                //@TimeReduc as BIT = 0,
                //@ExpenseReduc as BIT = 0

                // public class InvReductionEdit
                //{
                //    public int JobTrackDetailId { get; set; }
                //    public decimal Reimbursement { get; set; }
                //    public decimal Expense { get; set; }
                //    public decimal Revenue { get; set; }
                //    public decimal Total { get; set; }
                //}


                //DT = StMethod.GetListDT<InvoiceData>("sp_InvoiceReportItemsTesting", new List<SqlParameter>(new[]

                //DT = StMethod.GetListDT<string>("exec sp_InvoiceReportItems @JobTrackDetailId,@InvoiceNo, @Reduction,@ItemReduc,@TimeReduc,@ExpReduc", new List<SqlParameter>(new[]
                //   {
                //    //new SqlParameter("@InvoiceNo", InvoiceNo),

                //    new SqlParameter("@JobTrackDetailId",SqlDbType.BigInt,100,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId),
                //    new SqlParameter("@InvoiceNo",SqlDbType.VarChar,100,ParameterDirection.Input,true,0,0,"InvoiceNo",DataRowVersion.Current,InvoiceNo),
                //    new SqlParameter("@Reduction", txtReduction.Value),
                //    new SqlParameter("@ItemReduc", Convert.ToBoolean(chkItemReduc.CheckState)),
                //    new SqlParameter("@TimeReduc", Convert.ToBoolean(chkTimeReduc.CheckState)),
                //    new SqlParameter("@ExpReduc", Convert.ToBoolean(chkExpReduc.CheckState))
                //    //new SqlParameter ("@JobTrackDetailId",SqlDbType.BigInt,1000,ParameterDirection.Input,true,0,0,"JobTrackDetailId",DataRowVersion.Current,JobtrackInvoiceId)

                //    	//@JobTrackDetailId BIGINT,
                //     //   @InvoiceNo NVARCHAR(MAX),
                //     //   @Reduction DECIMAL(10,2)=0.0,
                //     //   @ItemReduc BIT=0,
                //     //   @TimeReduc BIT=0

                //}

                //   )); ;






                if (dt.Rows.Count > 0)
            {
                //CellReinburs.Value = dt.Rows[0]["Reimbursement"];
                //CellExpense.Value = dt.Rows[0]["Expense"];
                //CellRevenue.Value = dt.Rows[0]["Revenue"];
                //CellTotal.Value = dt.Rows[0]["Total"];

                    CellReinburs.Value = dt.Rows[0]["Reimbursement"];
                    CellExpense.Value = dt.Rows[0]["Expense"];
                    CellRevenue.Value = dt.Rows[0]["Revenue"];
                    CellTotal.Value = dt.Rows[0]["Total"];


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        private void chkEnableReduction_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grdSearchDetailInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //MessageBox.Show("Index => " + e.ColumnIndex + "Value => " + e.Value.ToString());

                if (e.ColumnIndex == 6)
                {
                    //String value = e.Value as string;

                    //if ((value != null))
                    //{
                    //    e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    e.FormattingApplied = true;

                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}

                    String value = e.Value as string;

                    string inputString;
                    DateTime dDate;

                    inputString = e.Value.ToString();
                    if (DateTime.TryParse(inputString, out dDate))
                    {
                        //String.Format("{0:d/MM/yyyy}", dDate);

                        e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                        e.FormattingApplied = true;
                    }
                    else
                    {


                    }

                }

                if (e.ColumnIndex == 8)
                {
                    //String value = e.Value as string;

                    //if ((value != null))
                    //{
                    //    e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    e.FormattingApplied = true;

                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}

                    String value = e.Value as string;

                    string inputString;
                    DateTime dDate;

                    inputString = e.Value.ToString();
                    if (DateTime.TryParse(inputString, out dDate))
                    {
                        //String.Format("{0:d/MM/yyyy}", dDate);

                        e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                        e.FormattingApplied = true;
                    }
                    else
                    {


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
