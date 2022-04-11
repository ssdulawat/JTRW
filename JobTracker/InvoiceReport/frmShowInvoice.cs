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
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace JobTracker.InvoiceReport
{
    public partial class frmShowInvoice : Form
    {
        #region Declaration
        //private DataAccessLayer DAL;
        private SqlCommand sqlCmd;
        private SqlConnection sqlCon = new SqlConnection();
        private string CheckString;
        private bool ExportStatus;
        //private DataAccessLayer PrintReporObj;
        public long JobID { get; set; }
        #endregion
        public frmShowInvoice()
        {
            InitializeComponent();
        }

        #region Events
        private void frmSearchInvoice_Load(System.Object sender, System.EventArgs e)
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
            // FillRateInvocieDetail(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString)
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                UpdateInvoiceDetail();

            }
            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {

                //using (EFDbContext db = new EFDbContext())
                //{
                //    int i = db.Database.ExecuteSqlCommand("DELETE FROM JobTrackInvoiceRateDetail WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());

                //    if (i >= 0)
                //    {
                //        i = db.Database.ExecuteSqlCommand("DELETE FROM JobTrackInvoiceDetail WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());
                //        if (i > 0)
                //        {
                //            KryptonMessageBox.Show("Delete Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            FillInvoiceDetail();
                //            StMethod.LoginActivityInfo(db, "Delete", this.Name);
                //        }
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        int i = db.Database.ExecuteSqlCommand("DELETE FROM JobTrackInvoiceRateDetail WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());

                        if (i >= 0)
                        {
                            i = db.Database.ExecuteSqlCommand("DELETE FROM JobTrackInvoiceDetail WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());
                            if (i > 0)
                            {
                                KryptonMessageBox.Show("Delete Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FillInvoiceDetail();
                                StMethod.LoginActivityInfoNew(db, "Delete", this.Name);
                            }
                        }
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        int i = db.Database.ExecuteSqlCommand("DELETE FROM JobTrackInvoiceRateDetail WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());

                        if (i >= 0)
                        {
                            i = db.Database.ExecuteSqlCommand("DELETE FROM JobTrackInvoiceDetail WHERE JobTrackDetailID=" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());
                            if (i > 0)
                            {
                                KryptonMessageBox.Show("Delete Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                FillInvoiceDetail();
                                StMethod.LoginActivityInfo(db, "Delete", this.Name);
                            }
                        }
                    }

                }


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
            }
            catch (Exception ex)
            {

            }
        }

        private void grdSearchDetailInvoice_CellMouseDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            DataTable rptInvoiceDt = new DataTable();
            if (grdSearchDetailInvoice.Rows.Count == 0)
            {
                return;
            }
            // rptInvoiceDt = DAL.Filldatatable("SELECT * FROM InvoiceReport WHERE JobListID=" & JobAndTrackingMDI.GetJobID & "")

            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + "").ToList();
            //    rptInvoiceDt = Program.ToDataTable<InvoiceRptView>(data);
            //}



            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + "").ToList();
                    rptInvoiceDt = Program.ToDataTable<InvoiceRptView>(data);
                }

            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<InvoiceRptView>("SELECT * FROM InvoicePreview WHERE JobTrackDetailID =" + grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString() + "").ToList();
                    rptInvoiceDt = Program.ToDataTable<InvoiceRptView>(data);
                }

            }

            if (rptInvoiceDt.Rows.Count == 0)
            {
                KryptonMessageBox.Show("Record Not found");
            }
            else
            {
                try
                {
                    using (ReportDocument Rpt = new ReportDocument())
                    {
                        //'Dim Rpt As New ReportDocumentl
                        string ReportPath = Application.StartupPath + "\\Reports\\rptInvoice.rpt";
                        Rpt.Load(ReportPath);
                        Rpt.SetDataSource(rptInvoiceDt);
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
                        CRVInvoice.ReportSource = Rpt;
                        rptInvoiceDt.Dispose();
                        myDoc = null;
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Invoice Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Methods
        public void FillInvoiceDetail()
        {
            try
            {
                string Query = null;
                Query = "SELECT JobList.JobNumber, JobTrackInvoiceDetail.JobTrackDetailID, JobTrackInvoiceDetail.InvoiceNo, JobTrackInvoiceDetail.InvoiceDate, JobTrackInvoiceDetail.Jobdescription, JobTrackInvoiceDetail.DueDate, JobTrackInvoiceDetail.Address AS invoiceAddress,JobTrackInvoiceDetail.PhoneNo, JobTrackInvoiceDetail.FaxNo, JobTrackInvoiceDetail.Email, JobTrackInvoiceDetail.PONo, JobTrackInvoiceDetail.PaymentCr, JobTrackInvoiceDetail.BalanceDue FROM  JobTrackInvoiceDetail INNER JOIN JobList ON JobTrackInvoiceDetail.JobListID = JobList.JobListID LEFT OUTER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE (JobTrackInvoiceDetail.JobTrackDetailID <> 0) AND JobTrackInvoiceDetail.JobListID  in(SELECT JobListID FROM JobList WHERE CompanyID in(SELECT CompanyID FROM JobList WHERE JobListID=" + JobID + ")) ";

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var list = db.Database.SqlQuery<InvoiceDetail>(Query);
                //    grdSearchDetailInvoice.DataSource = list;
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db.Database.SqlQuery<InvoiceDetail>(Query);
                        grdSearchDetailInvoice.DataSource = list;
                    }


                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<InvoiceDetail>(Query);
                        grdSearchDetailInvoice.DataSource = list;
                    }

                }

                //.Columns["CompanyName"].HeaderText = "Company Name"
                //.Columns["CompanyName").Visible = False
                grdSearchDetailInvoice.Columns["JobNumber"].HeaderText = "Job Number";
                grdSearchDetailInvoice.Columns["invoiceAddress"].HeaderText = "Customer Address";

                //.Columns["invoiceAddress").DefaultCellStyle.WrapMode = DataGridViewTriState.True

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
                grdSearchDetailInvoice.Columns["JobTrackDetailID"].Visible = false;
                if (grdSearchDetailInvoice.Rows.Count > 0)
                {
                    grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.Rows.Count - 1].Selected = true;
                    grdSearchDetailInvoice.CurrentCell = grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.Rows.Count - 1].Cells["JobNumber"];
                    // FillRateInvocieDetail(grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString)
                }
                else
                {
                    // FillRateInvocieDetail(0)
                }
                grdSearchDetailInvoice.Refresh();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Invoice Preview Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                return Str;
            }
        }
        public void UpdateInvoiceDetail()
        {
            try
            {
                string Query = "UPDATE JobTrackInvoiceDetail SET [InvoiceNo] = @InvoiceNo,[InvoiceDate] = @InvoiceDate, [Jobdescription] = @Jobdescription ,[DueDate] = @DueDate,[Address] = @Address,[PhoneNo] = @PhoneNo,[FaxNo] = @FaxNo, [Email] = @Email,[PONo] = @PONo,[PaymentCr] = @PaymentCr,[BalanceDue] = @BalanceDue WHERE JobTrackDetailID=@JobTrackDetailID";
                sqlCmd = new SqlCommand(Query);
                sqlCmd.Parameters.AddWithValue("@InvoiceNo", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceNo"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@InvoiceDate",GenericHelper.FormateDate((DateTime) grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value));
                sqlCmd.Parameters.AddWithValue("@Jobdescription", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["Jobdescription"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@DueDate", GenericHelper.FormateDate((DateTime)grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["DueDate"].Value));
                sqlCmd.Parameters.AddWithValue("@Address", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["invoiceAddress"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@PhoneNo", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["PhoneNo"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@FaxNo", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["FaxNo"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@PONo", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["PONo"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@PaymentCr", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["PaymentCr"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@BalanceDue", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["BalanceDue"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@Email", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["Email"].Value.ToString());
                sqlCmd.Parameters.AddWithValue("@JobTrackDetailID", grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].Cells["JobTrackDetailID"].Value.ToString());
                int UpID = 0;


                //using (EFDbContext db = new EFDbContext())
                //{
                //    UpID = db.Database.ExecuteSqlCommand(sqlCmd.CommandText, sqlCmd.Parameters);
                //    if (UpID > 0)
                //    {
                //        grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                //        grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                //        KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        StMethod.LoginActivityInfo(db, "Update", this.Name);
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        UpID = db.Database.ExecuteSqlCommand(sqlCmd.CommandText, sqlCmd.Parameters);
                        if (UpID > 0)
                        {
                            grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                            grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StMethod.LoginActivityInfoNew(db, "Update", this.Name);
                        }
                    }


                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        UpID = db.Database.ExecuteSqlCommand(sqlCmd.CommandText, sqlCmd.Parameters);
                        if (UpID > 0)
                        {
                            grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                            grdSearchDetailInvoice.Rows[grdSearchDetailInvoice.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            KryptonMessageBox.Show("Update Successfully", "search Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StMethod.LoginActivityInfo(db, "Update", this.Name);
                        }
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
                sqlCon.Close();
            }
        }        
        #endregion
    }
}
