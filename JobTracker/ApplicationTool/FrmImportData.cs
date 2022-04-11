using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.Application_Tool
{
    public partial class FrmImportData : Form
    {
        #region Declaration
        #endregion
        public FrmImportData()
        {
            InitializeComponent();
        }

        #region Events
        private void txtInvoiceNo_TextChanged(System.Object sender, System.EventArgs e)
        {
            FillGrid();
        }
        private void FrmImportData_Load(object sender, System.EventArgs e)
        {
            FillGrid();
        }
        private void grdInvoiceDueData_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {



                    // Following is the code which will ask confirmation box before deleting record

                    //if (KryptonMessageBox.Show("Are you sure to want delete", "Task list", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    //{
                    //    string name2 = grdInvoiceDueData.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();
                    //    if (StMethod.UpdateRecord("DELETE FROM AgingInvoice WHERE InvoiceAgingID=" + grdInvoiceDueData.Rows[e.RowIndex].Cells["InvoiceAgingID"].Value.ToString() + "") > 0)
                    //    {
                    //        KryptonMessageBox.Show("Selected Record Deleted", "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        StMethod.LoginActivityInfo("Delete", this.Name);
                    //        FillGrid();
                    //    }

                    //}

                    string name2 = grdInvoiceDueData.Rows[e.RowIndex].Cells["CompanyName"].Value.ToString();



                    //if (StMethod.UpdateRecord("DELETE FROM AgingInvoice WHERE InvoiceAgingID=" + grdInvoiceDueData.Rows[e.RowIndex].Cells["InvoiceAgingID"].Value.ToString() + "") > 0)
                    //{
                    //    KryptonMessageBox.Show("Selected Record Deleted", "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    StMethod.LoginActivityInfo("Delete", this.Name);
                    //    FillGrid();
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.UpdateRecordNew("DELETE FROM AgingInvoice WHERE InvoiceAgingID=" + grdInvoiceDueData.Rows[e.RowIndex].Cells["InvoiceAgingID"].Value.ToString() + "") > 0)
                        {
                            KryptonMessageBox.Show("Selected Record Deleted", "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            StMethod.LoginActivityInfo("Delete", this.Name);
                            FillGrid();
                        }

                    }
                    else
                    {

                        if (StMethod.UpdateRecord("DELETE FROM AgingInvoice WHERE InvoiceAgingID=" + grdInvoiceDueData.Rows[e.RowIndex].Cells["InvoiceAgingID"].Value.ToString() + "") > 0)
                        {
                            KryptonMessageBox.Show("Selected Record Deleted", "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            StMethod.LoginActivityInfo("Delete", this.Name);
                            FillGrid();
                        }
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void btnUpdateAgingColor_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                DataTable CompanyID = new DataTable();
                
                //CompanyID = StMethod.GetListDT<dtoCompanyID>("select distinct CompanyID from JobList Where CompanyID in (Select CompanyID From Company)");


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    CompanyID = StMethod.GetListDTNew<dtoCompanyID>("select distinct CompanyID from JobList Where CompanyID in (Select CompanyID From Company)");

                }
                else
                {
                    CompanyID = StMethod.GetListDT<dtoCompanyID>("select distinct CompanyID from JobList Where CompanyID in (Select CompanyID From Company)");
                }

                DataTable UpdateCompanyAging = new DataTable();
                foreach (DataRow CompanyRow in CompanyID.Rows)
                {
                    
                    
                    //UpdateCompanyAging = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice Where CompanyID=" + CompanyRow["CompanyID"].ToString() + " And Aging=(SELECT MAX(Aging)from AgingInvoice where CompanyID=" + CompanyRow["CompanyID"].ToString() + " ) order by Dueinvoiceno Asc");



                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        UpdateCompanyAging = StMethod.GetListDTNew<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice Where CompanyID=" + CompanyRow["CompanyID"].ToString() + " And Aging=(SELECT MAX(Aging)from AgingInvoice where CompanyID=" + CompanyRow["CompanyID"].ToString() + " ) order by Dueinvoiceno Asc");

                    }
                    else
                    {
                        UpdateCompanyAging = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice Where CompanyID=" + CompanyRow["CompanyID"].ToString() + " And Aging=(SELECT MAX(Aging)from AgingInvoice where CompanyID=" + CompanyRow["CompanyID"].ToString() + " ) order by Dueinvoiceno Asc");

                    }



                    if (UpdateCompanyAging.Rows.Count > 0)
                    {
                        //Aging
                        //string s1 = UpdateCompanyAging.Rows[0]["Aging"].ToString();

                        //OpeningBalance
                        //string s2 = UpdateCompanyAging.Rows[0]["Balance"].ToString();

                        //DueInvoiceNo
                        //string s3 = UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString();

                        //DueDate
                        //string s4 = UpdateCompanyAging.Rows[0]["DueDate"].ToString();

                        //company id
                        //string cid = CompanyRow["CompanyID"].ToString();

                        //StMethod.UpdateRecord("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate='" + UpdateCompanyAging.Rows[0]["DueDate"].ToString() + "' WHERE CompanyID=" + CompanyRow["CompanyID"].ToString());

                        DateTime DueDate = Convert.ToDateTime(UpdateCompanyAging.Rows[0]["DueDate"]);


                        //2019 - 07 - 15 00:00:00.000
                        //string DueDateStr = UpdateCompanyAging.Rows[0]["DueDate"].ToString();
                        
                        string DueDateStr = DueDate.Month + "-" + DueDate.Day + "-" + DueDate.Year + " " + DueDate.ToShortTimeString();


                        //StMethod.UpdateRecord("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate=CAST('" + DueDateStr + "'AS datetime) + '" + "'WHERE CompanyID=" + CompanyRow["CompanyID"].ToString());

                        string CompanyIDTemp = CompanyRow["CompanyID"].ToString();
                        //MessageBox.Show(CompanyIDTemp);

                        string query = "UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate=CAST('" + DueDateStr + "'AS datetime) + '" + "'WHERE CompanyID=" + CompanyRow["CompanyID"].ToString();



                        StMethod.UpdateRecord("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate=CAST('" + DueDateStr + "'AS datetime) + '" + "'WHERE CompanyID=" + CompanyRow["CompanyID"].ToString());



                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            StMethod.UpdateRecordNew("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate=CAST('" + DueDateStr + "'AS datetime) + '" + "'WHERE CompanyID=" + CompanyRow["CompanyID"].ToString());



                        }
                        else
                        {
                            StMethod.UpdateRecord("UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate=CAST('" + DueDateStr + "'AS datetime) + '" + "'WHERE CompanyID=" + CompanyRow["CompanyID"].ToString());


                        }


                        //StMethod.UpdateRecord("declare @vardate varchar(100)='24-10-2018 12:00:00 AM' UPDATE Company SET Aging=" + UpdateCompanyAging.Rows[0]["Aging"].ToString() + ",OpeningBalance=" + UpdateCompanyAging.Rows[0]["Balance"].ToString() + ",DueInvoiceNo='" + UpdateCompanyAging.Rows[0]["DueInvoiceNo"].ToString() + "',DueDate=CAST('" + DueDateStr + "'AS datetime) + '" + "'WHERE CompanyID=" + CompanyRow["CompanyID"].ToString());
                    }
                    UpdateCompanyAging.Rows.Clear();
                }
                KryptonMessageBox.Show("Successfully Updated", "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StMethod.LoginActivityInfo("Update", this.Name);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                KryptonMessageBox.Show("Not Successfully Updated", "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Methods
        public void FillGrid()
        {
            try
            {
                string Query = null;
                //Query = "SELECT Company.CompanyName as [Company Name],AgingInvoice.DueInvoiceNo AS [Invoice No], AgingInvoice.DueDate AS [Due Date], AgingInvoice.Aging, AgingInvoice.Balance AS [Opening Balance],AgingInvoice.InvoiceAgingID,Company.CompanyID FROM  AgingInvoice INNER JOIN     Company ON AgingInvoice.CompanyID = Company.CompanyID WHERE (AgingInvoice.InvoiceAgingID <> 0) ";



                // Selecting Only Date part from datetime 

                Query = "SELECT Company.CompanyName,AgingInvoice.DueInvoiceNo as InvoiceNo, CONVERT(DATE,AgingInvoice.DueDate) as DueDate, AgingInvoice.Aging, AgingInvoice.Balance as OpeningBalance,AgingInvoice.InvoiceAgingID,Company.CompanyID FROM  AgingInvoice INNER JOIN     Company ON AgingInvoice.CompanyID = Company.CompanyID WHERE (AgingInvoice.InvoiceAgingID <> 0) ";

                //Query = "SELECT Company.CompanyName,AgingInvoice.DueInvoiceNo as InvoiceNo, AgingInvoice.DueDate, AgingInvoice.Aging, AgingInvoice.Balance as OpeningBalance,AgingInvoice.InvoiceAgingID,Company.CompanyID FROM  AgingInvoice INNER JOIN     Company ON AgingInvoice.CompanyID = Company.CompanyID WHERE (AgingInvoice.InvoiceAgingID <> 0) ";


                if (!string.IsNullOrEmpty(txtAging.Text.Trim()))
                {
                    Query = Query + " AND AgingInvoice.Aging like '" + txtAging.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtBalance.Text.Trim()))
                {
                    Query = Query + " AND AgingInvoice.Balance like '" + txtBalance.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtInvoiceNo.Text.Trim()))
                {
                    Query = Query + " AND AgingInvoice.DueInvoiceNo like '%" + txtInvoiceNo.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtCompanyName.Text.Trim()))
                {
                    Query = Query + " AND Company.CompanyName like '%" + txtCompanyName.Text.Trim() + "%'";
                }
                Query = Query + " ORDER BY AgingInvoice.DueInvoiceNo";



                //var dt= StMethod.GetListDT<dtoDueInvoices>(Query);
                var dt = StMethod.GetListDT<dtoDueInvoices>(Query);
                dt = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<dtoDueInvoices>(Query);
                }
                else
                {
                    dt = StMethod.GetListDT<dtoDueInvoices>(Query);
                }

                grdInvoiceDueData.DataSource = dt;


                DataGridViewCellStyle DC = new DataGridViewCellStyle();
                DC.Format = "dd/MM";

                grdInvoiceDueData.Columns["DueDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

                //grdInvoiceDueData.Columns["DueDate"].ValueType = typeof(System.DateTime);


                //dataGridViewCellStyle.Format = "dd/MM"; 
                //this.date.DefaultCellStyle = dataGridViewCellStyle;

                //for (int z=0;z == grdInvoiceDueData.Rows.Count;z++)
                //{
                //    grdInvoiceDueData.Rows[z].Cells["DueDate"].Style.Format = "yyyy";

                //}


                //Add Dataformatstring = "dd-MM-yyyy" in bound field column

                //grdInvoiceDueData.Columns[3].DefaultCellStyle = new DataGridViewCellStyle { Format = "dd'/'MM'/'yyyy hh:mm:ss" };



                //dataGridView1.Columns["CurrencyTest"].DefaultCellStyle.Format = "C2";

                //dataGridView1.Columns["DateTest"].DefaultCellStyle.Format = "D";

                //dataGridView1.Columns["CurrencyTest"].ValueType = typeof(System.Double);

                //dataGridView1.Columns["DateTest"].ValueType = typeof(System.DateTime);


                //dataGridViewCellStyle.Format = "dd/MM/yyyy";
                //this.date.DefaultCellStyle = dataGridViewCellStyle;


                //grdInvoiceDueData.Columns[3].DefaultCellStyle.Format = "MM-dd-yyyy";

                //dataGrid.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm:ss";
                //dataGrid.Columns[2].DefaultCellStyle.Format = "MM/dd/yyyy hh:mm:ss tt";

                lblTotalREcord.Text = grdInvoiceDueData.Rows.Count.ToString();
                grdInvoiceDueData.Columns["InvoiceAgingID"].Visible = false;
                grdInvoiceDueData.Columns["CompanyID"].Visible = false;

                //grdInvoiceDueData.ScrollBars = ScrollBars.Both;
                //grdInvoiceDueData.Height = 500;

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        private void grdInvoiceDueData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {                
                if (e.ColumnIndex == 3)
                {

                    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //e.FormattingApplied = true;



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
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
