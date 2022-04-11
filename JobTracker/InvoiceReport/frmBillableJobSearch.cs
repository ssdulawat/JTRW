using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
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
using System.IO;

namespace JobTracker.InvoiceReport
{
    public partial class frmBillableJobSearch : Form
    {
        #region Declartion
        public static frmBillableJobSearch _Instance;
        public static frmBillableJobSearch Instance
        {
            get
            {
                if (_Instance == null || _Instance.IsDisposed)
                {
                    _Instance = new frmBillableJobSearch();
                }
                return _Instance;
            }
        }
        #endregion

        public frmBillableJobSearch()
        {
            InitializeComponent();
        }

        #region Events

        private void BtnBillJobDisableSearch_Click(System.Object sender, System.EventArgs e)
        {
            Fillgrid();
        }

        private void BtnExport_Click(System.Object sender, System.EventArgs e)
        {
            string titleformname = "Billable Job Search";

            if (DGVSearchJob.Rows.Count > 0)
            {
                SaveFileDialog Export = new SaveFileDialog();
                Export.Filter = "Excel Format|*.xls";
                //Export.Filter = "Excel Format|*.xlsx";
                Export.Title = titleformname;
                //Export.InitialDirectory = "N:"
                
                if (Directory.Exists("N:"))
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

                NPOIExcelUtility NPOIUtlity = new NPOIExcelUtility();
                DataTable ExportDataTable = (DataTable)DGVSearchJob.DataSource;
                string[] Columnarray = new string[3];
                Columnarray[0] = "JobNumber";
                Columnarray[1] = "PM";

                NPOIReturnObject response = NPOIUtlity.ExportExcelWithNPOI(ExportDataTable, FullFilePath, titleformname, Columnarray);

                if (response.IsConfirmed == true)
                {
                    MessageBox.Show(response.ResponseMessage, titleformname, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(response.ResponseMessage, titleformname, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No Records found for Export. Please try Again!", titleformname, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmBillableJobSearch_Load(System.Object sender, System.EventArgs e)
        {
            Fillgrid();
        }
        #endregion

        #region Methods
        private DataTable SearchData()
        {
            try
            {
                DataTable dt = null;
                //List<SqlParameter> Param = new List<SqlParameter>();

                //Param.Add(new SqlParameter("@NOCreditColor", Convert.ToInt16(TxtBoxNoColor.Text)));
                //Param.Add(new SqlParameter("@GreenColor", Convert.ToInt16(TxtBoxGreenColor.Text)));
                //Param.Add(new SqlParameter("@yellowColor", Convert.ToInt16(TxtBoxYellowColor.Text)));
                //Param.Add(new SqlParameter("@OrangeColor", Convert.ToInt16(TxtBoxOrangeColor.Text)));
                //Param.Add(new SqlParameter("@RedColor", Convert.ToInt16(TxtBoxRedColor.Text)));
                //Param.Add(new SqlParameter("@BlackColor", Convert.ToInt16(TxtBoxBlackColor.Text)));
                //Param.Add(new SqlParameter("@DefaultAmount", Convert.ToDecimal(txtBoxamount.Text)));

                //dt =StMethod.GetListDT<string>("proc_GetBillableJobSearchData", Param);


                //dt = StMethod.GetBJSearchData(Convert.ToInt32(TxtBoxNoColor.Text), Convert.ToInt32(TxtBoxGreenColor.Text), Convert.ToInt32(TxtBoxYellowColor.Text), Convert.ToInt32(TxtBoxOrangeColor.Text), Convert.ToInt32(TxtBoxRedColor.Text), Convert.ToInt32(TxtBoxBlackColor.Text), Convert.ToDecimal(txtBoxamount.Text));


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetBJSearchData_New(Convert.ToInt32(TxtBoxNoColor.Text), Convert.ToInt32(TxtBoxGreenColor.Text), Convert.ToInt32(TxtBoxYellowColor.Text), Convert.ToInt32(TxtBoxOrangeColor.Text), Convert.ToInt32(TxtBoxRedColor.Text), Convert.ToInt32(TxtBoxBlackColor.Text), Convert.ToDecimal(txtBoxamount.Text));                    
                }
                else
                {
                    dt = StMethod.GetBJSearchData(Convert.ToInt32(TxtBoxNoColor.Text), Convert.ToInt32(TxtBoxGreenColor.Text), Convert.ToInt32(TxtBoxYellowColor.Text), Convert.ToInt32(TxtBoxOrangeColor.Text), Convert.ToInt32(TxtBoxRedColor.Text), Convert.ToInt32(TxtBoxBlackColor.Text), Convert.ToDecimal(txtBoxamount.Text));
                }


                lblRecordsCount.Text = "Total Records :- " + dt.Rows.Count.ToString();

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("The error is occurring while searching for Billable Job-Search!", "Billable Job-Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }
        }
        public void Fillgrid()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                DataTable dt = SearchData();
                DGVSearchJob.DataSource = dt;
                DGVSearchJob.AutoGenerateColumns = false;
                DGVSearchJob.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

                DGVSearchJob.DataSource = dt;
                //DataAccessLayer cmbobj = new DataAccessLayer();
                //Set Column Property
                DGVSearchJob.Columns["JobNumber"].Visible = true;
                DGVSearchJob.Columns["JobNumber"].HeaderText = "Job Number";
                DGVSearchJob.Columns["JobNumber"].Width = 100;

                DGVSearchJob.Columns["PM"].Visible = true;
                DGVSearchJob.Columns["PM"].HeaderText = "PM";
                DGVSearchJob.Columns["PM"].Width = 100;

                //.Columns["JoblistID"].Visible = False
                //.Columns["CompanyID"].Visible = False
            }
            catch(Exception ex)
            {

            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion
    }
}