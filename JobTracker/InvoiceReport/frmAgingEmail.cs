using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
//using JobTracker.Open_Dilaogue_Frm;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpTree_Demo_CS;

namespace JobTracker.InvoiceReport
{
    public partial class frmAgingEmail : Form
    {
        #region Declaration
        private DataGridViewComboBoxCell RegionmbContactsName;
        private string SenderEmailAddress;
        private string SenderEmailPassword;
        private string JobNumberStr;
        private string AgingReport;
        private DataTable DT = new DataTable();
        private bool ProgreStats;
        private string BtnSelect;
        private string InvoiceJobStr = "";

        //public string EmailTo
        //{
        //    get
        //    {
        //        return txtEmailTo.Text;
        //    }
        //}

        //public string EmailSubject
        //{
        //    get
        //    {
        //        return txtEmailSubject.Text;
        //    }
        //}

        //public string EmailBody
        //{
        //    get
        //    {
        //        return txtEmailBody.Text;
        //    }
        //}
        #endregion
        public frmAgingEmail()
        {
            InitializeComponent();
            dtpSearch.Value = DateTime.Now;
        }

        #region Events
        private void FrmAging_Load(object sender, EventArgs e)
        {
            try
            { 
                FillGrdCompany();
                string InvoicePath= @"N:\transfer\PDF invoice";
                
                if (Directory.Exists(InvoicePath))
                {
                    InvoiceFileList.Path = @"N:\transfer\PDF invoice";
                }
                else
                {
                    InvoiceFileList.Path = @"C:\";
                }


                //GetSenderEmailaddress();
                DT.Columns.Add("FileName");
                //dtpSearch.Value = DateTime.Now;

                //myDatePicker.MaxDate = DateTime.Now.AddDays(2);

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
              
        }

        private void grdCompany_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 & e.ColumnIndex != -1)
            {
                grdAgingeInvoice(e.RowIndex);
                invoiceAction(e.RowIndex);
                ChangeTraficLight(e.RowIndex);
                FillCommunicationLog(e.RowIndex);
                btnAddInvoiceAction.Text = "Add";
                btnAddCommunication.Text = "Add";
            }

            try
            {
                ChangeDirJobNumber(e.RowIndex);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDueInvoice_Click(object sender, EventArgs e)
        {
            pnlMail.Visible = true;
            BtnSelect = "C";
            try
            {
                if (grdAging.Rows.Count == 0)
                    return;

                var ColorDT = new DataTable();
                int aging;
                var dtInvoice = new DataTable();
                JobNumberStr = string.Empty;

                foreach (DataGridViewRow grdrow in grdAging.Rows)
                {
                    //if ((CheckState)grdrow.Cells[this.chkGrdSelect.Name].Value == CheckState.Checked | (bool)grdrow.Cells[this.chkGrdSelect.Name].Value == true)


                    bool isSelected = Convert.ToBoolean(grdrow.Cells[this.chkGrdSelect.Name].Value);

                    //CheckState isChecked = (CheckState) grdrow.Cells[this.chkGrdSelect.Name].Value;

                    //if (isSelected == true | isChecked == CheckState.Checked)
                        if (isSelected == true  )                    
                    {
                        JobNumberStr = "JobNumber LIKE '" + Program.GetJobNumber(grdrow.Cells["DueInvoiceNo"].Value.ToString()) + "%' OR " + JobNumberStr;
                    }                    
                }

                

                //    For Each grdrow As DataGridViewRow In grdAging.Rows
                //    If(grdrow.Cells(Me.chkGrdSelect.Name).Value = CheckState.Checked Or grdrow.Cells(Me.chkGrdSelect.Name).Value = True) Then
                //       JobNumberStr = "JobNumber LIKE '" & ImportExcelInvoiceDue.GetJobNumber(grdrow.Cells("DueInvoiceNo").Value.ToString()) & "%' OR " & JobNumberStr
                //    End If
                //Next

                if ((JobNumberStr.Trim() ?? "") != (string.Empty ?? ""))
                {
                    JobNumberStr = JobNumberStr.Remove(JobNumberStr.LastIndexOf("OR"));
                }

                string JN = Program.GetJobNumber(grdAging.Rows[grdAging.CurrentRow.Index].Cells["DueInvoiceNo"].Value.ToString());



                //Program.GetJobID = StMethod.GetSingleInt("Select JoblistID From JobList Where JobNumber='" + JN + "'");

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    Program.GetJobID = StMethod.GetSingleIntNew("Select JoblistID From JobList Where JobNumber='" + JN + "'");
                }
                else
                {
                    Program.GetJobID = StMethod.GetSingleInt("Select JoblistID From JobList Where JobNumber='" + JN + "'");
                }

                //ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    ColorDT = StMethod.GetListDTNew<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());


                }
                else
                {
                    ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());


                }


                // JobAndTrackingMDI.GetJobID = selectedJobListID


                //dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dtInvoice = StMethod.GetListDTNew<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");

                }
                else
                {
                    dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");
                }



                if (dtInvoice.Rows.Count > 0)
                {
                    if (dtInvoice.Rows[0]["Aging"].ToString() == string.Empty)
                    {
                        KryptonMessageBox.Show("Select Job Number not have due invoice!", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //txtEmailTo.Text = StMethod.GetSingle<string>("SELECT dbo.ContactEmailAddres(" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + ") AS EmailAddress");


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    txtEmailTo.Text = StMethod.GetSingleNew<string>("SELECT dbo.ContactEmailAddres(" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + ") AS EmailAddress");

                }
                else
                {
                    txtEmailTo.Text = StMethod.GetSingle<string>("SELECT dbo.ContactEmailAddres(" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + ") AS EmailAddress");
                }

                aging = Convert.ToInt32(dtInvoice.Rows[0]["Aging"].ToString());

                if (aging >= 15)
                {
                    Program.GetColorID = Convert.ToInt64(ColorDT.Rows[0][Program.GetColumnName(aging)]);
                    Mailbuilder();
                    pnlMail.Visible = true;
                    pnlMail.BringToFront();
                }
                else
                {
                    Program.GetColorID = 0;
                    KryptonMessageBox.Show("Select Job Number not have 15 days old due invoice!", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                // KryptonMessageBox.Show(ex.Message, "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
            }
        }

        private void btnUpdateInvoiceDue_Click(object sender, EventArgs e)
        {
            var UpdateAgingFrm = new ImportExcelInvoiceDue();
            UpdateAgingFrm.Show();
        }

        private void InvoiceFileList_DoubleClick(object sender, EventArgs e)
        {
            string fExt = string.Empty;
            string filePath = InvoiceFileList.Path + @"\";
            try
            {
                if (Conversions.ToBoolean(Strings.InStrRev(InvoiceFileList.FileName, ".")))
                {
                    Process.Start(filePath + InvoiceFileList.FileName);
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
        }

        private void btnInvoicePermitsFileDownload_Click(object sender, EventArgs e)
        {
            //var Showdialogue = new frmDragDrop();
            //Showdialogue.GetJobPath = @"N:\transfer\PDF invoice";
            //Showdialogue.Show();

            

            var Showdialogue = new frmThreadCS();
            //Showdialogue.GetJobPath = @"N:\transfer\PDF invoice";
            Showdialogue.Show();

        }

        private void txtCompanySearch_TextChanged(object sender, EventArgs e)
        {
            FillGrdCompany();
        }

        private void grdCompany_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                grdAgingeInvoice(e.RowIndex);
                invoiceAction(e.RowIndex);
                ChangeTraficLight(e.RowIndex);
                FillCommunicationLog(e.RowIndex);
                btnAddInvoiceAction.Text = "Add";
                btnAddCommunication.Text = "Add";
            }

            try
            {
                ChangeDirJobNumber(e.RowIndex);
            }
            catch (Exception ex)
            {
            }
        }

        private void grdCompany_KeyDown(object sender, KeyEventArgs e)
        {
            long CompanyID = Convert.ToInt64(grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value);
            if (e.KeyCode == Keys.Up)
            {
                if (grdCompany.CurrentRow.Index != 0)
                {
                    ChangeTraficLight(grdCompany.CurrentRow.Index - 1);
                    ChangeDirJobNumber(grdCompany.CurrentRow.Index - 1);
                    grdAgingeInvoice(grdCompany.CurrentRow.Index - 1);
                    invoiceAction(grdCompany.CurrentRow.Index - 1);
                    FillCommunicationLog(grdCompany.CurrentRow.Index - 1);
                    btnAddCommunication.Text = "Add";
                    btnAddInvoiceAction.Text = "Add";
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (grdCompany.CurrentRow.Index != grdCompany.Rows.Count - 1)
                {
                    grdAgingeInvoice(grdCompany.CurrentRow.Index + 1);
                    ChangeTraficLight(grdCompany.CurrentRow.Index + 1);
                    ChangeDirJobNumber(grdCompany.CurrentRow.Index + 1);
                    invoiceAction(grdCompany.CurrentRow.Index + 1);
                    FillCommunicationLog(grdCompany.CurrentRow.Index - 1);
                    btnAddInvoiceAction.Text = "Add";
                    btnAddCommunication.Text = "Add";
                }
            }

            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        private void CkbPendingInvoice_CheckedChanged(object sender, EventArgs e)
        {
            FillGrdCompany();
        }
        private void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSelect.Checked == true)
            {
                foreach (DataGridViewRow Row in grdAging.Rows)
                    grdAging.Rows[Row.Index].Cells[this.chkGrdSelect.Name].Value = CheckState.Checked;
            }
            else
            {
                foreach (DataGridViewRow Row in grdAging.Rows)
                    grdAging.Rows[Row.Index].Cells[this.chkGrdSelect.Name].Value = CheckState.Unchecked;
            }
        }

        private void btnAddInvoiceAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddInvoiceAction.Text == "Add")
                {
                    btnAddInvoiceAction.Text = "Save";
                    var dt = new DataTable();
                    //dt = Program.ToDataTable<InvoiceActions>((List<InvoiceActions>)grdInvoiceAction.DataSource);
                    dt = (DataTable)grdInvoiceAction.DataSource;
                    DataRow DR = dt.NewRow();

                    DR["ActionDate"] = DateTime.Now.ToString();

                    //DR["ActionDate"] = (DateTime.Parse(DateTime.Now.ToString())).ToString("MM/d/yyyy"); ;
                    
                    //dtpSearch.Value = DateTime.Now;

                    dt.Rows.Add(DR);
                    grdInvoiceAction.DataSource = dt;
                }
                else
                {
                    btnAddInvoiceAction.Text = "Add";
                    //string InvoiceNo, ActionName, ActionDate, Status, CompanyID;
                    string InvoiceNo, ActionName, Status, CompanyID,Notes;

                    InvoiceNo = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["InvoiceNo"].Value.ToString();
                    ActionName = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.cmbGrdAction.Name].Value.ToString();
                    Status = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.cmbGrdStatus.Name].Value.ToString();

                    Notes = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["Notes"].Value.ToString();


                    Nullable<DateTime> ActionDate = DateTime.Now;
                    //ActionDate = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.txtgrdActionDate.Name].Value.ToString();

                    string FinalDate1= string.Empty;

                    //if (string.IsNullOrEmpty(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.txtgrdActionDate.Name].Value.ToString()))
                    //{


                    //} 
                    //else
                    //{

                    //    ActionDate = DateTime.Parse(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.txtgrdActionDate.Name].Value.ToString());

                    //    int s, s1, s2;

                    //    //11-22-2021 05:34:05 PM

                    //    s = ActionDate.Value.Month;
                    //    s1 = ActionDate.Value.Day;
                    //    s2 = ActionDate.Value.Year;

                    //    FinalDate1 = ActionDate.Value.Month.ToString() + "-" + ActionDate.Value.Day.ToString() + "-" + ActionDate.Value.Year.ToString() + " " + ActionDate.Value.Hour.ToString() +":" + ActionDate.Value.Minute.ToString()
                    //        +":" + ActionDate.Value.Second.ToString() + " " + ActionDate.Value.ToString("tt");





                    //}
                    
                    string Date101 = null;
                    string Date102 = null;


                    //string Date101 = null;
                    //string Date102 = null;

                    Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                    string FinalDateUpdate = string.Empty;

                    if (grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Value == null || grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Value.ToString()))
                    {
                        // here is your message box...


                    }
                    else
                    {
                        //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        //Date101 = string.Format("{0:MM/dd/yyyy}", grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Value.ToString());

                        ActionDate = DateTime.Parse(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.txtgrdActionDate.Name].Value.ToString());

                        int s, s1, s2;

                        //11-22-2021 05:34:05 PM

                        s = ActionDate.Value.Month;
                        s1 = ActionDate.Value.Day;
                        s2 = ActionDate.Value.Year;

                        FinalDate1 = ActionDate.Value.Month.ToString() + "-" + ActionDate.Value.Day.ToString() + "-" + ActionDate.Value.Year.ToString() + " " + ActionDate.Value.Hour.ToString() + ":" + ActionDate.Value.Minute.ToString()
                            + ":" + ActionDate.Value.Second.ToString() + " " + ActionDate.Value.ToString("tt");

                        //ActionDate = FinalDate1;
                        Date101 = FinalDate1;
                    }

                    if (grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Tag == null || grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Tag.ToString()))
                    {
                        // here is your message box...

                        //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                        Date102 = string.Format("{0:dd/MM/yyyy}", grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Value.ToString());

                        //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                        ActionDateUpdate = DateTime.Parse(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Value.ToString());

                        int s, s1, s2;

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
                        Date102 = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["txtgrdActionDate"].Tag.ToString();
                    }



                    //CompanyID = grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();
                    //string Query = "INSERT INTO InvoiceAction( InvoiceNo, ActionName, ActionDate, Status, CompanyID) VALUES('" + InvoiceNo + "','" + ActionName + "','" + FinalDate1 + "','" + Status + "','" + CompanyID + "')";

                    CompanyID = grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();

                    //Notes

                    //string Query = "INSERT INTO InvoiceAction( InvoiceNo, ActionName, ActionDate, Status, CompanyID) VALUES('" + InvoiceNo + "','" + ActionName + "','" + Date102 + "','" + Status + "','" + CompanyID + "')";

                    string Query = "INSERT INTO InvoiceAction( InvoiceNo, ActionName, ActionDate, Status, CompanyID,Notes) " +
                        "VALUES('" + InvoiceNo + "','" + ActionName + "','" + Date102 + "','" + Status + "','" + CompanyID + "','" + Notes  +"')";

                    //StMethod.UpdateRecord(Query);
                    //StMethod.LoginActivityInfo("Insert", this.Name);


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.UpdateRecordNew(Query);
                        StMethod.LoginActivityInfoNew("Insert", this.Name);
                    }
                    else
                    {
                        StMethod.UpdateRecord(Query);
                        StMethod.LoginActivityInfo("Insert", this.Name);
                    }

                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void grdAgingInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 & e.ColumnIndex == 0)
            {
                try
                {
                    if (Program.CheckBoxState(grdAging.Rows[e.RowIndex].Cells[0].Value))
                    {
                        grdAging.Rows[e.RowIndex].Cells[0].Value = CheckState.Unchecked;
                    }
                    else
                    {
                        grdAging.Rows[e.RowIndex].Cells[0].Value = CheckState.Checked;
                        // chkSelect.CheckState = CheckState.Checked
                    }

                    InvoiceJobStr = string.Empty;
                    foreach (DataGridViewRow grdrow in grdAging.Rows)
                    {
                        if (Program.CheckBoxState(grdrow.Cells[this.chkGrdSelect.Name].Value))
                        {
                            InvoiceJobStr = " InvoiceNo LIKE '" + Program.GetJobNumber(grdrow.Cells["DueInvoiceNo"].Value.ToString()) + "%' OR " + InvoiceJobStr;
                        }
                        // If (grdrow.Index = e.RowIndex And (grdrow.Cells[Me.chkGrdSelect.Name].Value = CheckState.Unchecked Or grdrow.Cells[Me.chkGrdSelect.Name].Value = False)) Then
                        // InvoiceJobStr = " InvoiceNo LIKE '" & Program.GetJobNumber(grdrow.Cells["DueInvoiceNo"].Value.ToString()) & "%' OR " & InvoiceJobStr
                        // End If
                    }

                    if ((InvoiceJobStr.Trim() ?? "") != (string.Empty ?? ""))
                    {
                        InvoiceJobStr = InvoiceJobStr.Remove(InvoiceJobStr.LastIndexOf("OR"));
                        invoiceAction(grdCompany.CurrentRow.Index);
                        FillCommunicationLog(grdCompany.CurrentRow.Index);
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void grdInvoiceAction_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 & e.RowIndex > -1)
                {
                    bool chkStatus = false;
                    JobNumberStr = string.Empty;
                    foreach (DataGridViewRow grdrow in grdAging.Rows)
                    {
                        if (Program.CheckBoxState(grdrow.Cells[this.chkGrdSelect.Name].Value))
                        {
                            JobNumberStr = "DueInvoiceNo LIKE '" + Program.GetJobNumber(grdrow.Cells["DueInvoiceNo"].Value.ToString()) + "%' OR " + JobNumberStr;
                        }
                    }

                    if ((JobNumberStr.Trim() ?? "") != (string.Empty ?? ""))
                    {
                        JobNumberStr = JobNumberStr.Remove(JobNumberStr.LastIndexOf("OR"));
                    }

                    foreach (DataGridViewRow grdrow in grdAging.Rows)
                    {
                        if (Program.CheckBoxState(grdrow.Cells[this.chkGrdSelect.Name].Value))
                        {
                            chkStatus = true;
                            break;
                        }
                    }

                    string Query;
                    if (chkStatus == false)
                    {
                        Query = "SELECT     DueInvoiceNo FROM   AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();
                    }
                    else
                    {
                        Query = "SELECT     DueInvoiceNo FROM         AgingInvoice WHERE " + JobNumberStr;
                    }

                    var cmbDT = new DataTable();
                    
                    //cmbDT = StMethod.GetListDT<string>(Query);

                    
                    
                    //cmbDT = StMethod.GetListDT<CommunicationLogCombo>(Query);


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        cmbDT = StMethod.GetListDTNew<CommunicationLogCombo>(Query);
                    }
                    else
                    {
                        cmbDT = StMethod.GetListDT<CommunicationLogCombo>(Query);
                    }

                    var cmbInvocie = new DataGridViewComboBoxCell();
                    cmbInvocie.DataSource = cmbDT;
                    cmbInvocie.DisplayMember = cmbDT.Columns["DueInvoiceNo"].ToString();
                    grdInvoiceAction.Rows[e.RowIndex].Cells[3] = cmbInvocie;
                }
            }
            catch (Exception ex)
            {


            }
        }

        private void grdInvoiceAction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 & e.ColumnIndex == 0)
            {
                try
                {
                    if (btnAddInvoiceAction.Text == "Save")
                    {
                        KryptonMessageBox.Show("First Save then Update!");
                        return;
                    }

                    string InvoiceNo, ActionName, ActionDate, Status;
                    InvoiceNo = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells["InvoiceNo"].Value.ToString();
                    ActionName = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.cmbGrdAction.Name].Value.ToString();
                    Status = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.cmbGrdStatus.Name].Value.ToString();
                    
                    //ActionDate = grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.txtgrdActionDate.Name].Value.ToString();


                    Nullable<DateTime> ActionDateUpdate = DateTime.Now;
                    
                    string FinalDateUpdate = string.Empty;

                    //if (string.IsNullOrEmpty(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.txtgrdActionDate.Name].Value.ToString()))
                    //{


                    //}
                    //else
                    //{

                    //    ActionDateUpdate = DateTime.Parse(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.txtgrdActionDate.Name].Value.ToString());

                    //    int s, s1, s2;

                    //    //11-22-2021 05:34:05 PM

                    //    s = ActionDateUpdate.Value.Month;
                    //    s1 = ActionDateUpdate.Value.Day;
                    //    s2 = ActionDateUpdate.Value.Year;

                    //    FinalDateUpdate = ActionDateUpdate.Value.Month.ToString() + "-" + ActionDateUpdate.Value.Day.ToString() + "-" + ActionDateUpdate.Value.Year.ToString() + " " + ActionDateUpdate.Value.Hour.ToString() + ":" + ActionDateUpdate.Value.Minute.ToString()
                    //        + ":" + ActionDateUpdate.Value.Second.ToString() + " " + ActionDateUpdate.Value.ToString("tt");





                    //}


                    string Date101,  Date102 = null;



                     if (grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value == null || grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString()))
                    {
                        // here is your message box...


                    }
                    else
                    {
                        //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        Date101 = string.Format("{0:dd/MM/yyyy}", grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString());
                    }


                    if (grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Tag == null || grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Tag.ToString()))
                    {
                        // here is your message box...

                        //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        Date102 = string.Format("{0:MM/dd/yyyy}", grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString());


                        //Date102 = string.Format("{0:dd/MM/yyyy}", grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString());

                        //inputString = string.Format("{0:MM/d/yyyy}", value2);

                        //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();


                        

                        //string inputString;
                        //DateTime dDate;

                        //inputString = grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString();

                        //if (DateTime.TryParse(inputString, out dDate))
                        //{
                        //    Date102 = string.Format("{0:MM/dd/yyyy}", grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString());



                        //    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                        //    //e.FormattingApplied = true;
                        //}
                        //else
                        //{


                        //}

                        ActionDateUpdate = DateTime.Parse(grdInvoiceAction.Rows[grdInvoiceAction.Rows.Count - 1].Cells[this.txtgrdActionDate.Name].Value.ToString());

                        int s, s1, s2;

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
                        Date102 = grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Tag.ToString();
                    }





                    //string Query = "Update InvoiceAction SET InvoiceNo ='" + InvoiceNo + "', ActionName='" + ActionName + "', ActionDate='" + FinalDateUpdate + "', Status='" + Status + "'WHERE ActionID=" + grdInvoiceAction.Rows[grdInvoiceAction.CurrentRow.Index].Cells["ActionID"].Value.ToString();


                    string Query = "Update InvoiceAction SET InvoiceNo ='" + InvoiceNo + "', ActionName='" + ActionName + "', ActionDate='" + Date102 + "', Status='" + Status + "'WHERE ActionID=" + grdInvoiceAction.Rows[grdInvoiceAction.CurrentRow.Index].Cells["ActionID"].Value.ToString();



                    //StMethod.UpdateRecord(Query);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.UpdateRecordNew(Query);
                    }
                    else
                    {
                        StMethod.UpdateRecord(Query);
                    }

                    KryptonMessageBox.Show("Record Updated!");
                    
                    //StMethod.LoginActivityInfo("Update", this.Name);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.LoginActivityInfoNew("Update", this.Name);
                    }
                    else
                    {
                        StMethod.LoginActivityInfo("Update", this.Name);
                    }

                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message);
                }
            }

            if (e.RowIndex != -1 & e.ColumnIndex == 1)
            {
                try
                {
                    if (KryptonMessageBox.Show("Are you sure to want delete", "Invoice Action", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {


                        //if (StMethod.UpdateRecord("DELETE FROM InvoiceAction WHERE ActionID=" + grdInvoiceAction.Rows[e.RowIndex].Cells["ActionID"].Value.ToString()) > 0)
                        //{
                        //    KryptonMessageBox.Show("Delete Successfully", "Invoice Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    grdInvoiceAction.Rows.RemoveAt(e.RowIndex);
                        //    StMethod.LoginActivityInfo("Delete", this.Name);
                        //}



                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            if (StMethod.UpdateRecordNew("DELETE FROM InvoiceAction WHERE ActionID=" + grdInvoiceAction.Rows[e.RowIndex].Cells["ActionID"].Value.ToString()) > 0)
                            {
                                KryptonMessageBox.Show("Delete Successfully", "Invoice Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdInvoiceAction.Rows.RemoveAt(e.RowIndex);
                                StMethod.LoginActivityInfoNew("Delete", this.Name);
                            }
                        }
                        else
                        {
                            if (StMethod.UpdateRecord("DELETE FROM InvoiceAction WHERE ActionID=" + grdInvoiceAction.Rows[e.RowIndex].Cells["ActionID"].Value.ToString()) > 0)
                            {
                                KryptonMessageBox.Show("Delete Successfully", "Invoice Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdInvoiceAction.Rows.RemoveAt(e.RowIndex);
                                StMethod.LoginActivityInfo("Delete", this.Name);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Invoice Action", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnAddCommunication_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnAddCommunication.Text == "Add")
                {
                    btnAddCommunication.Text = "Save";
                    var dt = new DataTable();
                    //dt = Program.ToDataTable<CommunicationLogData>((List<CommunicationLogData>)grdCommunicationLog.DataSource);
                    dt = (DataTable)grdCommunicationLog.DataSource;
                    DataRow DR = dt.NewRow();
                    dt.Rows.Add(DR);
                    grdCommunicationLog.DataSource = dt;


                }
                else
                {
                    btnAddCommunication.Text = "Add";
                    string InvoiceNo, Method, Notes, CompanyID;
                    
                    //DateTime CallBackDate;

                    Nullable<DateTime> CallBackDate;
                    
                    InvoiceNo = grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["InvoiceNo"].Value.ToString();
                    Method = grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["Method"].Value.ToString();
                    Notes = grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["Notes"].Value.ToString();
                    CompanyID = grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();


                    //CallBackDate = null;

                    //if (string.IsNullOrEmpty(grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value.ToString()))
                    //{


                    //}
                    //else
                    //{
                    //    CallBackDate = DateTime.Parse(grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value.ToString());

                    //}

                    Nullable<DateTime> ActionDate = DateTime.Now;
                    string FinalDate1 = string.Empty;

                    string Date101 = null;
                    string Date102 = null;

                    if (grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value == null || grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value.ToString()))
                    {
                        // here is your message box...


                    }
                    else
                    {
                        //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        Date101 = string.Format("{0:MM/dd/yyyy}", grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value.ToString());

                        ActionDate = DateTime.Parse(grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value.ToString());

                        int s, s1, s2;

                        //11-22-2021 05:34:05 PM

                        s = ActionDate.Value.Month;
                        s1 = ActionDate.Value.Day;
                        s2 = ActionDate.Value.Year;

                        FinalDate1 = ActionDate.Value.Month.ToString() + "-" + ActionDate.Value.Day.ToString() + "-" + ActionDate.Value.Year.ToString() + " " + ActionDate.Value.Hour.ToString() + ":" + ActionDate.Value.Minute.ToString()
                            + ":" + ActionDate.Value.Second.ToString() + " " + ActionDate.Value.ToString("tt");

                        //ActionDate = FinalDate1;
                        Date101 = FinalDate1;
                    }



                    string Query = "INSERT INTO CommunicationLog( InvoiceNo, Method, Notes, CallBackDate, CompanyID) VALUES('" + InvoiceNo + "','" + Method + "','" + Notes + "','" + FinalDate1 + "','" + CompanyID + "')";


                    //string Query = "INSERT INTO CommunicationLog( InvoiceNo, Method, Notes, CallBackDate, CompanyID) VALUES('" + InvoiceNo + "','" + Method + "','" + Notes + "','" + CallBackDate + "','" + CompanyID + "')";



                    StMethod.UpdateRecord(Query);
                    StMethod.LoginActivityInfo("Insert", this.Name);
                    // SELECT     CommLogID, CompanyID, InvoiceNo, Method, Notes FROM         CommunicationLog
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void grdCommunicationLog_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 4 & e.RowIndex > -1)
                {
                    bool chkStatus = false;
                    JobNumberStr = string.Empty;
                    foreach (DataGridViewRow grdrow in grdAging.Rows)
                    {
                        if (Program.CheckBoxState(grdrow.Cells[this.chkGrdSelect.Name].Value))
                        {
                            JobNumberStr = "DueInvoiceNo LIKE '" + Program.GetJobNumber(grdrow.Cells["DueInvoiceNo"].Value.ToString()) + "%' OR " + JobNumberStr;
                        }
                    }

                    if ((JobNumberStr.Trim() ?? "") != (string.Empty ?? ""))
                    {
                        JobNumberStr = JobNumberStr.Remove(JobNumberStr.LastIndexOf("OR"));
                    }

                    foreach (DataGridViewRow grdrow in grdAging.Rows)
                    {
                        if (Program.CheckBoxState(grdrow.Cells[this.chkGrdSelect.Name].Value))
                        {
                            chkStatus = true;
                            break;
                        }
                    }

                    string Query;
                    if (chkStatus == false)
                    {
                        Query = "SELECT     DueInvoiceNo FROM   AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();
                    }
                    else
                    {
                        Query = "SELECT     DueInvoiceNo FROM         AgingInvoice WHERE " + JobNumberStr;
                    }

                  
                    var cmbDT = new DataTable();

                    //CommunicationLogDataEdit

                    //cmbDT = StMethod.GetListDT<string>(Query);



                    //cmbDT = StMethod.GetListDT<CommunicationLogCombo>(Query);


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        cmbDT = StMethod.GetListDTNew<CommunicationLogCombo>(Query);
                    }
                    else
                    {
                        cmbDT = StMethod.GetListDT<CommunicationLogCombo>(Query);
                    }



                    var cmbInvocie = new DataGridViewComboBoxCell();
                    cmbInvocie.DisplayMember = cmbDT.Columns["DueInvoiceNo"].ToString();
                    cmbInvocie.DataSource = cmbDT;

                    //grdCommunicationLog.Rows[e.RowIndex].Cells[4] = cmbInvocie;
                    grdCommunicationLog.Rows[e.RowIndex].Cells[e.ColumnIndex] = cmbInvocie;





                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            //Dim Query As String = "SELECT Track FROM JobTracking WHERE JobListID IN (SELECT JobListID FROM JobList WHERE JobNumber='" & ImportExcelInvoiceDue.GetJobNumber(grdCommunicationLog.Rows(e.RowIndex).Cells("InvoiceNo").Value.ToString().Trim()) & "') and (IsDelete=0 or IsDelete is Null) AND Track IN (SELECT TrackName  FROM MasterTrackSet WHERE TrackSet='Notes/Communication')"
            //    Dim cmbDT As New DataTable
            //    DAL = New DataAccessLayer
            //    cmbDT = DAL.Filldatatable(Query)
            //    Dim cmbMethod As New DataGridViewComboBoxCell
            //    cmbMethod.DataSource = cmbDT
            //    cmbMethod.DisplayMember = cmbDT.Columns("Track").ToString()
            //    grdCommunicationLog(5, e.RowIndex) = cmbMethod

            try
            {
                if (e.ColumnIndex == 5 & e.RowIndex > -1)
                {
                    string Query = "SELECT Track FROM JobTracking WHERE JobListID IN (SELECT JobListID FROM JobList WHERE JobNumber='" + Program.GetJobNumber(grdCommunicationLog.Rows[e.RowIndex].Cells["InvoiceNo"].Value.ToString().Trim()) + "') and (IsDelete=0 or IsDelete is Null) AND Track IN (SELECT TrackName  FROM MasterTrackSet WHERE TrackSet='Notes/Communication')";
                    var cmbDT = new DataTable();

                    //cmbDT = StMethod.GetListDT<string>(Query);



                    //cmbDT = StMethod.GetListDT<JobTrackListCombo>(Query);


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        cmbDT = StMethod.GetListDTNew<JobTrackListCombo>(Query);
                    }
                    else
                    {
                        cmbDT = StMethod.GetListDT<JobTrackListCombo>(Query);
                    }

                    //JobTrackingData


                    //CellCmb.DisplayMember = "TrackSubDescription";
                    //CellCmb.ValueMember = "JobTrackingID";

                    //CellCmb.DataSource = Dt;

                    //grdTimeAndExp.Rows[e.RowIndex].Cells[e.ColumnIndex] = CellCmb;


                    var cmbMethod = new DataGridViewComboBoxCell();
                    
                    cmbMethod.DisplayMember = cmbDT.Columns["Track"].ToString();
                    cmbMethod.DataSource = cmbDT;

                    //grdCommunicationLog.Rows[e.RowIndex].Cells[5] = cmbMethod;
                    grdCommunicationLog.Rows[e.RowIndex].Cells[e.ColumnIndex] = cmbMethod;

                }
            }
            catch (Exception ex)
            {



            }
        }

        private void btnAgingReport_Click(object sender, EventArgs e)
        {
            if (btnAgingReport.Text != "Close Report")
            {
                agingBrowser.Visible = true;
                agingBrowser.DocumentText = AgingReport;
                btnAgingReport.Text = "Close Report";
            }
            else
            {
                btnAgingReport.Text = "Show Aging Report";
                agingBrowser.Visible = false;
            }
        }

        private void ckbAdd_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbAdd.Checked == true)
            {
                // FillAttachGrid(DT)
                fileAttach();
            }
            else if (ckbAdd.Checked == false)
            {
                DT.Rows.Clear();
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            picboxEmailProgress.Visible = true;
            btnSendEmail.Visible = false;
            backworkerEmailSender.RunWorkerAsync();
            parentTableControl.Enabled = false;
            pnlMail.Visible = true;
            pnlMail.BringToFront();
        }

        private void backworkerEmailSender_DoWork(object sender, DoWorkEventArgs e)
        {
            string EmailBody;
            string EmailTo=txtEmailTo.Text.Trim();
            string EmailSubject=txtEmailSubject.Text.Trim();
            List<string> sAttachments = new List<string>();
            if (chkAttachAging.Checked == true | chkAttachAging.CheckState == CheckState.Checked)
            {
                EmailBody = txtEmailBody.Text.Trim() + AgingReport;
            }
            else
            {
                EmailBody = txtEmailBody.Text.Trim();
            }            
            for (int i = 0, loopTo = grdAttachedfile.Rows.Count - 1; i <= loopTo; i++)
            {
                sAttachments.Add(grdAttachedfile.Rows[i].Cells["FileName"].Value.ToString()); 
            }
            ProgreStats = EmailUtils.MailSender(EmailTo, EmailBody, EmailSubject, sAttachments);
        }

        private void backworkerEmailSender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled | ProgreStats == false)
            {
                KryptonMessageBox.Show("Email sending fail", "Invoice Due Reminder email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                picboxEmailProgress.Visible = false;
                btnSendEmail.Visible = true;
                pnlMail.Visible = false;
                parentTableControl.Enabled = true;
                pnlMail.SendToBack();
            }
            else
            {
                KryptonMessageBox.Show("Email sending successfull", "Invoice Due Reminder email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                picboxEmailProgress.Visible = false;
                btnSendEmail.Visible = true;
                pnlMail.Visible = false;
                parentTableControl.Enabled = true;
                pnlMail.SendToBack();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            parentTableControl.Enabled = true;
            pnlMail.Visible = false;
            pnlMail.SendToBack();
            ckbAdd.Checked = true;
            DT.Rows.Clear();
        }

        private void btnSendmailAging_Click(object sender, EventArgs e)
        {
            BtnSelect = "A";
            pnlMail.Visible = true;
            pnlMail.BringToFront();
            try
            {
                if (grdAging.Rows.Count == 0)
                    return;

                var ColorDT = new DataTable();
                int aging;
                var dtInvoice = new DataTable();
                string EmailAddress = "";
                JobNumberStr = string.Empty;
                foreach (DataGridViewRow grdrow in grdAging.Rows)
                {
                    if (Program.CheckBoxState(grdrow.Cells[this.chkGrdSelect.Name].Value))
                    {
                        JobNumberStr = "JobNumber LIKE '" + Program.GetJobNumber(grdrow.Cells["DueInvoiceNo"].Value.ToString()) + "%' OR " + JobNumberStr;
                        if (grdrow.Cells["EmailAddress"].Value.ToString() != string.Empty)
                        {
                            EmailAddress = grdrow.Cells["EmailAddress"].Value.ToString() + " , " + EmailAddress;
                        }
                    }
                }

                if ((EmailAddress.Trim() ?? "") != (string.Empty ?? ""))
                    EmailAddress = EmailAddress.Remove(EmailAddress.LastIndexOf(","));
                if ((JobNumberStr.Trim() ?? "") != (string.Empty ?? ""))
                {
                    JobNumberStr = JobNumberStr.Remove(JobNumberStr.LastIndexOf("OR"));
                }

                string JN = Program.GetJobNumber(grdAging.Rows[grdAging.CurrentRow.Index].Cells["DueInvoiceNo"].Value.ToString());
                
                
                //Program.GetJobID = StMethod.GetSingleInt("Select JoblistID From JobList Where JobNumber='" + JN + "'");
                //ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                //// JobAndTrackingMDI.GetJobID = selectedJobListID
                //dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");



                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    Program.GetJobID = StMethod.GetSingleIntNew("Select JoblistID From JobList Where JobNumber='" + JN + "'");
                    ColorDT = StMethod.GetListDTNew<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                    // JobAndTrackingMDI.GetJobID = selectedJobListID
                    dtInvoice = StMethod.GetListDTNew<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");
                }
                else
                {
                    Program.GetJobID = StMethod.GetSingleInt("Select JoblistID From JobList Where JobNumber='" + JN + "'");
                    ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                    // JobAndTrackingMDI.GetJobID = selectedJobListID
                    dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");

                }





                if (dtInvoice.Rows.Count > 0)
                {
                    if (dtInvoice.Rows[0]["Aging"].ToString() == string.Empty)
                    {
                        KryptonMessageBox.Show("Select Job Number not have due invoice!", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //aging = dtInvoice.Rows[0]["Aging"].ToString();
                // txtEmailTo.Text = DAL.Filldatatable("SELECT dbo.ContactEmailAddres(" & grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() & ") AS EmailAddress").Rows[0][0).ToString()
                txtEmailTo.Text = EmailAddress;
                aging = Convert.ToInt32(dtInvoice.Rows[0]["Aging"].ToString());
                if (aging >= 15)
                {
                    Program.GetColorID = Convert.ToInt64(ColorDT.Rows[0][Program.GetColumnName(aging)]);
                    Mailbuilder();
                    pnlMail.Visible = true;
                    pnlMail.BringToFront();
                }
                else
                {
                    Program.GetColorID = 0;
                    KryptonMessageBox.Show("Select Job Number not have 15 days old due invoice! you want to continue.", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // KryptonMessageBox.Show(ex.Message, "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information)
            }
        }
        private void grdCommunicationLog_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 & e.ColumnIndex == 0)
            {
                try
                {
                    if (btnAddCommunication.Text == "Save")
                    {
                        KryptonMessageBox.Show("First Save then Update!");
                        return;
                    }

                    string InvoiceNo, Method, Notes;
                    DateTime CallBackDate;
                    InvoiceNo = grdCommunicationLog.CurrentRow.Cells["InvoiceNo"].Value.ToString();
                    Method = grdCommunicationLog.CurrentRow.Cells["Method"].Value.ToString();
                    Notes = grdCommunicationLog.CurrentRow.Cells["Notes"].Value.ToString();



                    Nullable<DateTime> ActionDateUpdate = DateTime.Now;
                    string FinalDateUpdate = string.Empty;

                    string Date101, Date102 = null;



                    if (grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Value == null || grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Value.ToString()))
                    {
                        // here is your message box...


                    }
                    else
                    {
                        //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        Date101 = string.Format("{0:dd/MM/yyyy}", grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Value.ToString());
                    }


                    if (grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Tag == null || grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Tag.ToString()))
                    {
                        // here is your message box...

                        //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        Date102 = string.Format("{0:MM/dd/yyyy}", grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Value.ToString());


                        //Date102 = string.Format("{0:dd/MM/yyyy}", grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString());

                        //inputString = string.Format("{0:MM/d/yyyy}", value2);

                        //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();




                        //string inputString;
                        //DateTime dDate;

                        //inputString = grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString();

                        //if (DateTime.TryParse(inputString, out dDate))
                        //{
                        //    Date102 = string.Format("{0:MM/dd/yyyy}", grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString());



                        //    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                        //    //e.FormattingApplied = true;
                        //}
                        //else
                        //{


                        //}

                        ActionDateUpdate = DateTime.Parse(grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value.ToString());

                        int s, s1, s2;

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
                        Date102 = grdCommunicationLog.Rows[e.RowIndex].Cells["CallBackDate"].Tag.ToString();
                    }





                    //CallBackDate = Convert.ToDateTime(grdCommunicationLog.CurrentRow.Cells["CallBackDate"].Value);
                    //string Query = "UPDATE  CommunicationLog SET InvoiceNo='" + InvoiceNo + "', Method='" + Method + "', Notes='" + Notes + "', CallBackDate= '" + CallBackDate + "' WHERE CommLogID=" + grdCommunicationLog.Rows[grdCommunicationLog.CurrentRow.Index].Cells["CommLogID"].Value.ToString();

                    string Query = "UPDATE  CommunicationLog SET InvoiceNo='" + InvoiceNo + "', Method='" + Method + "', Notes='" + Notes + "', CallBackDate= '" + Date102 + "' WHERE CommLogID=" + grdCommunicationLog.Rows[grdCommunicationLog.CurrentRow.Index].Cells["CommLogID"].Value.ToString();


                    // InvoiceNo = grdCommunicationLog.Rows[grdCommunicationLog.CurrentRow].Cells["InvoiceNo"].Value.ToString()
                    // Method = grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["Method"].Value.ToString()
                    // Notes = grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["Notes"].Value.ToString()
                    // CallBackDate = Convert.ToDateTime(grdCommunicationLog.Rows[grdCommunicationLog.Rows.Count - 1].Cells["CallBackDate"].Value)




                    //StMethod.UpdateRecord(Query);
                    //KryptonMessageBox.Show("Record Updated!");
                    //StMethod.LoginActivityInfo("Update", this.Name);


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {


                        StMethod.UpdateRecordNew(Query);
                        KryptonMessageBox.Show("Record Updated!");
                        StMethod.LoginActivityInfoNew("Update", this.Name);


                    }
                    else
                    {

                        StMethod.UpdateRecord(Query);
                        KryptonMessageBox.Show("Record Updated!");
                        StMethod.LoginActivityInfo("Update", this.Name);


                    }

                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message);
                }
            }

            if (e.RowIndex != -1 & e.ColumnIndex == 1)
            {
                try
                {
                    if (KryptonMessageBox.Show("Are you sure to want delete", "Communication Log", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32( grdCommunicationLog.Rows[e.RowIndex].Cells["CommLogID"].Value);
                        if (id > 0)
                        {
                           
                            
                            //if (StMethod.UpdateRecord("DELETE FROM CommunicationLog WHERE CommLogID=" + id.ToString()) > 0)
                            //{
                            //    KryptonMessageBox.Show("Delete Successfully", "Communication Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    grdCommunicationLog.Rows.RemoveAt(e.RowIndex);
                            //    StMethod.LoginActivityInfo("Delete", this.Name);
                            //}

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {

                                if (StMethod.UpdateRecordNew("DELETE FROM CommunicationLog WHERE CommLogID=" + id.ToString()) > 0)
                                {
                                    KryptonMessageBox.Show("Delete Successfully", "Communication Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdCommunicationLog.Rows.RemoveAt(e.RowIndex);
                                    StMethod.LoginActivityInfoNew("Delete", this.Name);
                                }
                            }
                            else
                            {
                                if (StMethod.UpdateRecord("DELETE FROM CommunicationLog WHERE CommLogID=" + id.ToString()) > 0)
                                {
                                    KryptonMessageBox.Show("Delete Successfully", "Communication Log", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdCommunicationLog.Rows.RemoveAt(e.RowIndex);
                                    StMethod.LoginActivityInfo("Delete", this.Name);
                                }
                            }

                        }
                        else
                        {
                            grdCommunicationLog.Rows.RemoveAt(e.RowIndex);
                        }
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Communication Log", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void txtMethodSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtMethodSearch.Text.Trim() != string.Empty)
            {
                var CommDt = new DataTable();
                string query = "SELECT     CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" + (grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString() + " AND Method like '" + txtMethodSearch.Text.Trim() + "%'");
                
                //CommDt = StMethod.GetListDT<CommunicationLogData>(query);
                
                
                //CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    CommDt = StMethod.GetListDTNew<CommunicationLogDataEdit>(query);
                }
                else
                {
                    CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(query);
                }

                grdCommunicationLog.DataSource = CommDt;
                {
                    var withBlock = grdCommunicationLog;
                    withBlock.Columns["CommLogID"].Visible = false;
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["InvoiceNo"].HeaderText = "Invoice#";
                    withBlock.Columns["InvoiceNo"].Width = 80;
                    withBlock.Columns["Method"].Width = 80;
                    withBlock.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    withBlock.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }
            else
            {
                FillCommunicationLog();
            }
        }

        // Private Sub txtCallBackDateSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        // If (txtCallBackDateSearch.Text.Trim() <> String.Empty) Then
        // DAL = New DataAccessLayer
        // Dim CommDt As New DataTable
        // Dim query As String = "SELECT     CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" & grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString() + " AND CallBackDate = '" + txtCallBackDateSearch.Text.Trim() + "'"

        // CommDt = DAL.Filldatatable(query)
        // grdCommunicationLog.DataSource = CommDt
        // With grdCommunicationLog
        // .Columns["CommLogID"].Visible = False
        // .Columns["CompanyID"].Visible = False
        // .Columns["InvoiceNo"].HeaderText = "Invoice#"
        // .Columns["InvoiceNo"].Width = 80
        // .Columns["Method"].Width = 80
        // .Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        // .Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True
        // End With

        // Else
        // FillCommunicationLog()
        // End If
        // End Sub

        private void txtInvoiceSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtInvoiceSearch.Text.Trim() != string.Empty)
            {
                var CommDt = new DataTable();
                string query = "SELECT CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" + (grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString() + " AND InvoiceNo like '" + txtInvoiceSearch.Text.Trim() + "%'");
                //CommDt = StMethod.GetListDT<CommunicationLogData>(query);
                
                
                //CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    CommDt = StMethod.GetListDTNew<CommunicationLogDataEdit>(query);

                }
                else
                {
                    CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(query);
                }


                grdCommunicationLog.DataSource = CommDt;
                {
                    var withBlock = grdCommunicationLog;
                    withBlock.Columns["CommLogID"].Visible = false;
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["InvoiceNo"].HeaderText = "Invoice#";
                    withBlock.Columns["InvoiceNo"].Width = 80;
                    withBlock.Columns["Method"].Width = 80;
                    withBlock.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    withBlock.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }
            else
            {
                FillCommunicationLog();
            }
        }
        private void dtpSearch_ValueChanged(object sender, EventArgs e)
        {
            // If (dtpSearch.Value <> "9/3/1980") Then

            try
            { 

            if (dtpSearch.Value != DateTime.Today & !(grdCompany.Rows.Count == 0))
            {
                var CommDt = new DataTable();
                //string query = "SELECT CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" + (grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString() + " AND (CallBackDate = '" + dtpSearch.Value + "' OR CallBackDate <'" + dtpSearch.Value + "' )");

                    string query = "SELECT CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" + (grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString() + " AND (CallBackDate = '" + (DateTime.Parse(dtpSearch.Value.ToString())).ToString("MM/d/yyyy") + "' OR CallBackDate <'" +
                      (DateTime.Parse(dtpSearch.Value.ToString())).ToString("MM/d/yyyy") + "' )");

                    //DateTime.Parse(dtpSearch.Value.ToString())).ToString("MM/d/yyyy")
                    //DateTime.Parse(dtpSearch.Value.ToString())).ToString("MM/d/yyyy")

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


                    //CommDt = StMethod.GetListDT<CommunicationLogData>(query);
                    
                    
                    
                    
                    //CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(query);



                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        CommDt = StMethod.GetListDTNew<CommunicationLogDataEdit>(query);
                    }
                    else
                    {
                        CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(query);
                    }

                    grdCommunicationLog.DataSource = CommDt;
                {
                    var withBlock = grdCommunicationLog;
                    withBlock.Columns["CommLogID"].Visible = false;
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["InvoiceNo"].HeaderText = "Invoice#";
                    withBlock.Columns["InvoiceNo"].Width = 80;
                    withBlock.Columns["Method"].Width = 80;
                    withBlock.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    withBlock.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }
            else
            {
                FillCommunicationLog();
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            // End If
        }

        private void txtCommLogNotes_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtCommLogNotes.Text.Trim() != string.Empty)
            {
                var CommDt = new DataTable();
                string query = "SELECT CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" + (grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString() + " AND Notes like '%" + txtCommLogNotes.Text.Trim() + "%'");
                //CommDt = StMethod.GetListDT<CommunicationLogData>(query);


                //CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    CommDt = StMethod.GetListDTNew<CommunicationLogDataEdit>(query);
                }
                else
                {
                    CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(query);
                }

                grdCommunicationLog.DataSource = CommDt;
                {
                    var withBlock = grdCommunicationLog;
                    withBlock.Columns["CommLogID"].Visible = false;
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["InvoiceNo"].HeaderText = "Invoice#";
                    withBlock.Columns["InvoiceNo"].Width = 80;
                    withBlock.Columns["Method"].Width = 80;
                    withBlock.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    withBlock.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
            }
            else
            {
                FillCommunicationLog();
            }
        }
        private void chkActionStatusPending_CheckedChanged(object sender, EventArgs e)
        {
            FillGrdCompany();
        }
        #endregion

        #region Methods        
        public void FillGrdCompany()
        {
            try
            {
                var DTCompany = new DataTable();
                string Query;

                // Query = "SELECT distinct Company.CompanyID, Company.CompanyName,(Select WorkPhone from Contacts Where CompanyID=Company.CompanyID and Contacts.Accounting=1) as Phone,(Select FaxNumber from Contacts Where CompanyID=Company.CompanyID and Contacts.Accounting=1) as Fax , Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode,  Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action,   Company.Age105Action,Company.Aging FROM         Contacts RIGHT OUTER JOIN      Company ON Contacts.CompanyID = Company.CompanyID WHERE     (Company.CompanyID > 0) AND (Company.IsDelete = 0 OR    Company.IsDelete IS NULL)"

                Query = "SELECT distinct Company.CompanyID, Company.CompanyName, Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode,  Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action,   Company.Age105Action,Company.Aging FROM         Contacts RIGHT OUTER JOIN      Company ON Contacts.CompanyID = Company.CompanyID WHERE     (Company.CompanyID > 0) AND (Company.IsDelete = 0 OR    Company.IsDelete IS NULL)";

                if (CkbPendingInvoice.Checked == true)
                {
                    // Query = Query & " AND  Company.CompanyID  in (SELECT  distinct    JobList.CompanyID FROM         JobList LEFT OUTER JOIN                      JobTracking ON JobList.JobListID = JobTracking.JobListID Where JobTracking.status='Pending' ANd ( JobTracking.IsDelete=0 or JobTracking.IsDelete Is null))"
                    Query = Query + " AND  Company.CompanyID  in (SELECT     CompanyID FROM         AgingInvoice)";
                }

                if (txtCompanySearch.Text.Trim() != string.Empty)
                {
                    Query = Query + " AND Company.CompanyName like '%" + txtCompanySearch.Text.Trim() + "%'";
                }

                if (chkActionStatusPending.Checked == true)
                {
                    Query = Query + " AND Company.CompanyID IN(SELECT CompanyID FROM  InvoiceAction WHERE Status='Pending')";
                }

                Query = Query + " ORDER BY Company.Aging DESC";


                //DTCompany = StMethod.GetListDT<CompanyAging>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    DTCompany = StMethod.GetListDTNew<CompanyAging>(Query);
                }
                else
                {
                    DTCompany = StMethod.GetListDT<CompanyAging>(Query);
                }

                grdCompany.DataSource = DTCompany;
                {
                    var withBlock = grdCompany;

                    // .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["CompanyName"].HeaderText = "CompanyName";
                    // .Columns["Phone"].HeaderText = "Phone"
                    // .Columns["Fax"].HeaderText = "Fax"
                    // .Columns["Age").DataPropertyName = "Age"
                    withBlock.Columns["Address"].HeaderText = "Address";
                    withBlock.Columns["City"].HeaderText = "City";
                    withBlock.Columns["State"].HeaderText = "State";
                    // .Columns["Zip").DataPropertyName = "Zip"
                    withBlock.Columns["Age15Action"].Visible = false;
                    withBlock.Columns["Age30Action"].Visible = false;
                    withBlock.Columns["Age45Action"].Visible = false;
                    withBlock.Columns["Age60Action"].Visible = false;
                    withBlock.Columns["Age75Action"].Visible = false;
                    withBlock.Columns["Age90Action"].Visible = false;
                    withBlock.Columns["Age105Action"].Visible = false;
                    withBlock.Columns["Aging"].Visible = false;
                }

                if (grdCompany.Rows.Count > 0)
                {
                    grdCompany.Rows[0].Selected = true;
                    grdCompany.CurrentCell = grdCompany.Rows[0].Cells[1];
                    grdAgingeInvoice(grdCompany.CurrentRow.Index);
                    invoiceAction(grdCompany.CurrentRow.Index);
                    FillCommunicationLog(grdCompany.CurrentRow.Index);
                    ChangeTraficLight(grdCompany.CurrentRow.Index);
                    ChangeDirJobNumber(grdCompany.CurrentRow.Index);
                }
                else
                {
                    grdAging.DataSource = null;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void ChangeTraficLight(int Rindex)
        {
            try
            {
                pnlTraficLight.Visible = false;
                int aging;
                var ColorDT = new DataTable();


                //ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[Rindex].Cells["CompanyID"].Value.ToString());

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    ColorDT = StMethod.GetListDTNew<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[Rindex].Cells["CompanyID"].Value.ToString());
                }
                else
                {
                    ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[Rindex].Cells["CompanyID"].Value.ToString());
                }

                if (ColorDT.Rows.Count > 0)
                {
                    aging = Convert.ToInt32(ColorDT.Rows[0]["Aging"].ToString());
                    if (aging >= 15)
                    {
                        Program.GetColorID = Convert.ToInt64(ColorDT.Rows[0][Program.GetColumnName(aging)]);
                        btnAgingColor.BackColor = Program.ChangeTraficLightColor(Program.GetColorID);
                    }
                    ////aging = ColorDT.Rows[0]["Aging"].ToString();
                    ////if (aging >= 15 & aging < 30)
                    ////{
                    ////    btnAgingColor.BackColor = JobStatus.ChangeTraficLightColor(ColorDT.Rows[0]["Age15Action"]);
                    ////}

                    ////if (aging >= 30 & aging < 45)
                    ////{
                    ////    btnAgingColor.BackColor = JobStatus.ChangeTraficLightColor(ColorDT.Rows[0]["Age30Action"]);
                    ////}

                    ////if (aging >= 45 & aging < 60)
                    ////{
                    ////    btnAgingColor.BackColor = JobStatus.ChangeTraficLightColor(ColorDT.Rows[0]["Age45Action"]);
                    ////}

                    ////if (aging >= 60 & aging < 75)
                    ////{
                    ////    btnAgingColor.BackColor = JobStatus.ChangeTraficLightColor(ColorDT.Rows[0]["Age60Action"]);
                    ////}

                    ////if (aging >= 75 & aging < 90)
                    ////{
                    ////    btnAgingColor.BackColor = JobStatus.ChangeTraficLightColor(ColorDT.Rows[0]["Age75Action"]);
                    ////}

                    ////if (aging >= 90 & aging < 105)
                    ////{
                    ////    btnAgingColor.BackColor = JobStatus.ChangeTraficLightColor(ColorDT.Rows[0]["Age90Action"]);
                    ////}

                    ////if (aging >= 105)
                    ////{
                    ////    btnAgingColor.BackColor = JobStatus.ChangeTraficLightColor(ColorDT.Rows[0]["Age105Action"]);
                    ////}

                    if (aging < 15)
                    {
                        pnlTraficLight.Visible = false;
                    }
                    else
                    {
                        pnlTraficLight.Visible = true;
                    }
                }
                else
                {
                    pnlTraficLight.Visible = false;
                    btnAgingColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
            catch (Exception ex)
            {
                pnlTraficLight.Visible = false;
                btnAgingColor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            }
        }
        public void grdAgingeInvoice(int RowIndex)
        {
            try
            {
                var AgingeInvoice = new DataTable();
                string Query;
                Query = "Select Aging, DueInvoiceNo,Balance, DueDate,  CompanyID, dbo.JobListACEmailAddres(DueInvoiceNo,'E') as EmailAddress from AgingInvoice where CompanyID=" + grdCompany.Rows[RowIndex].Cells["CompanyID"].Value.ToString() + " Order by Aging Desc";


                //AgingeInvoice = StMethod.GetListDT<DueInvoiceEmail>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    AgingeInvoice = StMethod.GetListDTNew<DueInvoiceEmail>(Query);
                }
                else
                {
                    AgingeInvoice = StMethod.GetListDT<DueInvoiceEmail>(Query);
                }


                AgingeInvoice.Columns.Add("Summation");
                AgingeInvoice.Columns.Add("Address");
                AgingeInvoice.Columns.Add("Description");
                var Summation = default(decimal);
                foreach (DataRow dr in AgingeInvoice.Rows)
                {
                    Summation = Summation + Convert.ToDecimal(dr["Balance"]);
                    dr["Summation"] = Summation;
                    
                    
                    string StrAddress = "SELECT Address,Description FROM JobList WHERE  JobNumber= '" + Program.GetJobNumber(dr["DueInvoiceNo"].ToString()) + "'";
                                       
                    var tEMP = new DataTable();

                    //tEMP = StMethod.GetListDT<InvoiceAddress>(StrAddress);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        tEMP = StMethod.GetListDTNew<InvoiceAddress>(StrAddress);
                    }
                    else
                    {
                        tEMP = StMethod.GetListDT<InvoiceAddress>(StrAddress);
                    }

                    if (tEMP.Rows.Count > 0)
                    {
                        dr["Address"] = tEMP.Rows[0]["Address"].ToString();
                        dr["Description"] = tEMP.Rows[0]["Description"].ToString();
                    }
                }

                grdAging.DataSource = AgingeInvoice;
                // grdAgingInvoice.Columns.Insert(5, AddContactCombo)
                {
                    var withBlock = grdAging;
                    // .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["DueInvoiceNo"].HeaderText = "InvoiceNo#";
                    withBlock.Columns["DueInvoiceNo"].Width = 80;
                    withBlock.Columns["DueDate"].HeaderText = "Due Date";
                    withBlock.Columns["DueDate"].Width = 50;
                    withBlock.Columns["DueDate"].DisplayIndex = 9;
                    withBlock.Columns["EmailAddress"].HeaderText = "Email";   // Add to new column In grid view
                    withBlock.Columns["EmailAddress"].DisplayIndex = 7;
                    withBlock.Columns["Description"].HeaderText = "Job Description";
                    withBlock.Columns["Description"].DisplayIndex = 6;
                    withBlock.Columns["Summation"].DisplayIndex = 4;
                    withBlock.Columns["Summation"].HeaderText = "Summ";
                    withBlock.Columns["Address"].DisplayIndex = 8;
                    withBlock.Columns["Aging"].Width = 60;
                }

                findAgingFILE();
            }
            catch (Exception ex)
            {
            }
        }
        public DataGridViewComboBoxColumn AddContactCombo()
        {
            var cmbContactsName = new DataGridViewComboBoxColumn();
            try
            {
                var dt2 = new DataTable();


                //dt2 = StMethod.GetListDT<InvoiceContacts>("SELECT (FirstName +' '+ LastName) as Contact,ContactsID FROM contacts where (IsDelete=0 or IsDelete IS NULL) AND Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());



                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt2 = StMethod.GetListDTNew<InvoiceContacts>("SELECT (FirstName +' '+ LastName) as Contact,ContactsID FROM contacts where (IsDelete=0 or IsDelete IS NULL) AND Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                }
                else
                {
                    dt2 = StMethod.GetListDT<InvoiceContacts>("SELECT (FirstName +' '+ LastName) as Contact,ContactsID FROM contacts where (IsDelete=0 or IsDelete IS NULL) AND Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                }
                cmbContactsName.DataSource = dt2;
                cmbContactsName.DisplayMember = dt2.Columns["Contact"].ToString();
                cmbContactsName.ValueMember = dt2.Columns["ContactsID"].ToString();
                cmbContactsName.DisplayIndex = 5;
                cmbContactsName.HeaderText = "Contacts Name";
                cmbContactsName.DataPropertyName = "ContactsName";
                cmbContactsName.Name = "cmbContactsName";
                return cmbContactsName;
            }
            catch (Exception ex)
            {
                return cmbContactsName;
            }
        }
        private void invoiceAction(int Rowindex)
        {
            try
            {
                var DTAction = new DataTable();
                string Query;
                
                
                Query = "SELECT ActionID, InvoiceNo, ActionName, ActionDate, Status, CompanyID, Notes FROM InvoiceAction where CompanyID=" + grdCompany.Rows[Rowindex].Cells["CompanyID"].Value.ToString() + "";



                if ((InvoiceJobStr.Trim().ToString() ?? "") != (string.Empty ?? ""))
                {
                    Query = Query + " AND " + InvoiceJobStr;
                }
                // If chkActionStatusPending.Checked = True Then
                // Query = Query + " AND Status='Pending'"
                // End If


                //DTAction = StMethod.GetListDT<InvoiceActions>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    DTAction = StMethod.GetListDTNew<InvoiceActions>(Query);
                }
                else
                {
                    DTAction = StMethod.GetListDT<InvoiceActions>(Query);
                }

                grdInvoiceAction.DataSource = DTAction;
                {
                    var withBlock = grdInvoiceAction;
                    // .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["ActionID"].Visible = false;
                    withBlock.Columns["InvoiceNo"].DisplayIndex = 2;
                    withBlock.Columns["InvoiceNo"].HeaderText = "Invoice#";
                    withBlock.Columns["InvoiceNo"].Width = 80;
                    withBlock.Columns[cmbGrdAction.Name].Width = 80;
                    withBlock.Columns[txtgrdActionDate.Name].Width = 80;
                    withBlock.Columns["Notes"].Width = 130;
                    // .Columns["ActionDate"].HeaderText = "Action Date"
                }
            }
            // MessageBox.Show(Me.txtGrdInvoiceNo.Index)
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        //private void GetSenderEmailaddress()
        //{
        //    try
        //    {
        //        var CheckMail = new System.Xml.XmlDocument();
        //        CheckMail.Load(Application.StartupPath + @"\CheckFile.xml");
        //        var reminder = CheckMail.SelectSingleNode("/EmailReminder/Email");
        //        SenderEmailAddress = reminder.ChildNodes.Item(0).InnerText.Trim();
        //        SenderEmailPassword = reminder.ChildNodes.Item(1).InnerText.Trim();
        //    }
        //    // CheckMail.Save(Application.StartupPath & "\CheckFile.xml")
        //    catch (IOException ex1)
        //    {
        //        KryptonMessageBox.Show(ex1.Message + " Please check the access right of it.", "Emila Information");
        //    }
        //    catch (Exception ex2)
        //    {
        //        KryptonMessageBox.Show(ex2.Message + " Please check the access right of it.", "Email Information");
        //    }
        //}        
        private void FillCommunicationLog(int Rowindex)
        {
            try
            {
                var CommDt = new DataTable();
                string Query = "SELECT     CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" + grdCompany.Rows[Rowindex].Cells["CompanyID"].Value.ToString();
                if ((InvoiceJobStr.Trim().ToString() ?? "") != (string.Empty ?? ""))
                {
                    Query = Query + " AND " + InvoiceJobStr;
                }

                //CommDt = StMethod.GetListDT<CommunicationLogData>(Query);

                //CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    CommDt = StMethod.GetListDTNew<CommunicationLogDataEdit>(Query);
                }
                else
                {
                    CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(Query);
                }

                grdCommunicationLog.DataSource = CommDt;
                {
                    var withBlock = grdCommunicationLog;
                    withBlock.Columns["CommLogID"].Visible = false;
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["InvoiceNo"].HeaderText = "Invoice#";
                    withBlock.Columns["InvoiceNo"].Width = 80;
                    withBlock.Columns["Method"].Width = 80;
                    withBlock.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    withBlock.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    withBlock.Columns["Notes"].Width = 150;
                    withBlock.Columns["CallBackDate"].Width = 80;
                }
            }
            catch (Exception ex)
            {
                string ex2 = ex.Message.ToString();

            }
        }
        private void fileAttach()
        {
            try
            {
                DT.Rows.Clear();
                var DirInfo = new DirectoryInfo(@"N:\transfer\PDF invoice");
                var AgingFile = DirInfo.GetFiles();
                var FileNameDT = new DataTable();
                string Query;
                JobNumberStr = string.Empty;
                foreach (DataGridViewRow grdrow in grdAging.Rows)
                {
                    if (Program.CheckBoxState(grdrow.Cells[this.chkGrdSelect.Name].Value))
                    {
                        JobNumberStr = "DueInvoiceNo LIKE '" + Program.GetJobNumber(grdrow.Cells["DueInvoiceNo"].Value.ToString()) + "%' OR " + JobNumberStr;
                    }
                }

                if ((JobNumberStr.Trim() ?? "") != (string.Empty ?? ""))
                {
                    JobNumberStr = JobNumberStr.Remove(JobNumberStr.LastIndexOf("OR"));
                }

                if (BtnSelect == "C")
                {
                    Query = "select distinct DueInvoiceNo FROM  AgingInvoice WHERE CompanyID in (select CompanyID from joblist WHERE JoblistID=" + Program.GetJobID + ")";
                }
                else
                {
                    Query = "select distinct DueInvoiceNo FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + " AND " + JobNumberStr;
                }

                //FileNameDT = StMethod.GetListDT<string>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    FileNameDT = StMethod.GetListDTNew<string>(Query);
                }
                else
                {
                    FileNameDT = StMethod.GetListDT<string>(Query);
                }

                if (FileNameDT.Rows.Count > 0)
                {
                    var FileNotFound = default(string);
                    foreach (DataRow row in FileNameDT.Rows)
                    {
                        var FileFound = default(bool);
                        foreach (var FA in AgingFile)
                        {
                            // If FA.Name.Contains(Program.GetJobNumber(row.Item("JobNumber").ToString())) = True Then
                            if (FA.Name.Contains(row["DueInvoiceNo"].ToString()) == true)
                            {
                                DataRow Dr = DT.NewRow();
                                // Dr = DT.NewRow
                                Dr["FileName"] = FA.FullName;
                                DT.Rows.Add(Dr);
                                FileFound = true;
                                break;
                            }
                            else
                            {
                                FileFound = false;
                            }
                        }

                        if (FileFound == false)
                        {
                            FileNotFound = FileNotFound + Constants.vbCrLf + row["DueInvoiceNo"].ToString();
                            KryptonMessageBox.Show("Thise file list are not in directory=" + FileNotFound, "Email Due Invoice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }

                    FillAttachGrid(DT);
                }
            }
            catch
            {
            }
        }
        public void FillAttachGrid(DataTable dt)
        {
            {
                var withBlock = grdAttachedfile;
                withBlock.DataSource = null;
                withBlock.DataSource = dt;
                withBlock.Columns["FileName"].HeaderText = "File Name";
                withBlock.Columns["FileName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        public void Mailbuilder()
        {
            try
            {
                var DT = new DataTable();
                // Dim EmailID As Int16
                var EmailDT = new DataTable();


                //DT = StMethod.GetListDT<AgingInvoiceData>("SELECT Company.CompanyName,Company.DueInvoiceNo,Joblist.Address,Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action,  Company.Age105Action, Company.Aging,Company.OpeningBalance,Company.DueDate,Company.CompanyID FROM  Company INNER JOIN         JobList ON Company.CompanyID = JobList.CompanyID WHERE JobList.JobListID=" + Program.GetJobID);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    DT = StMethod.GetListDTNew<AgingInvoiceData>("SELECT Company.CompanyName,Company.DueInvoiceNo,Joblist.Address,Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action,  Company.Age105Action, Company.Aging,Company.OpeningBalance,Company.DueDate,Company.CompanyID FROM  Company INNER JOIN         JobList ON Company.CompanyID = JobList.CompanyID WHERE JobList.JobListID=" + Program.GetJobID);

                }
                else
                {
                    DT = StMethod.GetListDT<AgingInvoiceData>("SELECT Company.CompanyName,Company.DueInvoiceNo,Joblist.Address,Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action,  Company.Age105Action, Company.Aging,Company.OpeningBalance,Company.DueDate,Company.CompanyID FROM  Company INNER JOIN         JobList ON Company.CompanyID = JobList.CompanyID WHERE JobList.JobListID=" + Program.GetJobID);

                }


                var InvoiceAgingDT = new DataTable();


                //InvoiceAgingDT = StMethod.GetListDT<AgingInvoiceData>("Select * from AgingInvoice  Where CompanyID=" + DT.Rows[0]["CompanyID"].ToString());




                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    InvoiceAgingDT = StMethod.GetListDTNew<AgingInvoiceData>("Select * from AgingInvoice  Where CompanyID=" + DT.Rows[0]["CompanyID"].ToString());
                }
                else
                {
                    InvoiceAgingDT = StMethod.GetListDT<AgingInvoiceData>("Select * from AgingInvoice  Where CompanyID=" + DT.Rows[0]["CompanyID"].ToString());
                }



                // If DT.Rows[0]["Aging"].ToString ()<> String.Empty Then
                
                if (InvoiceAgingDT.Rows.Count > 0)
                {
                    if (Convert.ToInt32(DT.Rows[0]["Aging"]) > 0)
                    {
                        int aging = Convert.ToInt32(DT.Rows[0]["Aging"].ToString());


                        //EmailDT = StMethod.GetListDT<ColorEmailData>("SELECT ColorID, EmailSubject, EmailDescription FROM  ColorEmailDescription WHERE ColorID=" + Program.GetColorID);

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            EmailDT = StMethod.GetListDTNew<ColorEmailData>("SELECT ColorID, EmailSubject, EmailDescription FROM  ColorEmailDescription WHERE ColorID=" + Program.GetColorID);
                        }
                        else
                        {
                            EmailDT = StMethod.GetListDT<ColorEmailData>("SELECT ColorID, EmailSubject, EmailDescription FROM  ColorEmailDescription WHERE ColorID=" + Program.GetColorID);
                        }


                        try
                        {
                            txtEmailBody.Text = EmailDT.Rows[0]["EmailDescription"].ToString();
                            txtEmailSubject.Text = DT.Rows[0]["CompanyName"].ToString() + " : " + EmailDT.Rows[0]["EmailSubject"].ToString(); // + " = Invoice Automated Notice Letter :"
                        }
                        catch (Exception ex)
                        {

                        }

                        AgingReport = Constants.vbCrLf + "<TABLE><tr><th>Invoice No </th><th>Invoice Date</th><th>Job Address</th><th>Aging</th><th>Balance</th><th>Summation</th></tr>";

                        if (BtnSelect == "C")
                        {
                            foreach (DataGridViewRow grdrow in grdAging.Rows)
                                // SumMation = SumMation + Convert.ToDecimal(dtInvoice.Rows[j]["Balance").ToString())
                                AgingReport = AgingReport + "<tr><td>" + grdrow.Cells["DueInvoiceNo"].Value.ToString() + " </td><td>" + Convert.ToDateTime(grdrow.Cells["DueDate"].Value.ToString()).ToString("MM/dd/yyyy") + "</td><td>" + grdrow.Cells["Address"].Value.ToString() + "</td><td>" + grdrow.Cells["Aging"].Value.ToString() + "</td><td>" + grdrow.Cells["Balance"].Value.ToString() + "</td><td>" + grdrow.Cells["Summation"].Value.ToString() + "</td></tr>";
                        }
                        else
                        {
                            foreach (DataGridViewRow grdrow in grdAging.Rows)
                            {
                                // SumMation = SumMation + Convert.ToDecimal(dtInvoice.Rows[j]["Balance").ToString())
                                if (Program.CheckBoxState(grdrow.Cells[chkGrdSelect.Name].Value))
                                {
                                    AgingReport = AgingReport + "<tr><td>" + grdrow.Cells["DueInvoiceNo"].Value.ToString() + " </td><td>" + Convert.ToDateTime(grdrow.Cells["DueDate"].Value.ToString()).ToString("MM/dd/yyyy") + "</td><td>" + grdrow.Cells["Address"].Value.ToString() + "</td><td>" + grdrow.Cells["Aging"].Value.ToString() + "</td><td>" + grdrow.Cells["Balance"].Value.ToString() + "</td><td>" + grdrow.Cells["Summation"].Value.ToString() + "</td></tr>";
                                }
                            }
                        }

                        AgingReport = AgingReport + "</TABLE>";
                        DT.Rows.Clear();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            // If JobAndTrackingMDI.DueInvoiceEmailAddress <> String.Empty Then
            // txtEmailTo.Text = JobAndTrackingMDI.DueInvoiceEmailAddress
            // End If
        }
        private void ChangeDirJobNumber(int Rindex)
        {
            try
            {
                string GetDir = @"N:\transfer\PDF invoice";
                
                if (Directory.Exists(GetDir))
                {
                    GetDir = @"N:\transfer\PDF invoice";
                }
                else
                {

                    GetDir = @"C:\";
                }

                
                bool Find = false;
                InvoiceFileList.Path = GetDir;
                InvoiceFileList.Items.Clear();
                var DirFile = new DirectoryInfo(GetDir);
                var GetFile = DirFile.GetFiles();
                var FileDt = new DataTable();

                

                //FileDt = StMethod.GetListDT<InvoiceAging>("Select JobNumber from Joblist Where CompanyID=" + grdCompany.Rows[Rindex].Cells["CompanyID"].Value.ToString());


                

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    FileDt = StMethod.GetListDTNew<InvoiceAging>("Select JobNumber from Joblist Where CompanyID=" + grdCompany.Rows[Rindex].Cells["CompanyID"].Value.ToString());
                }
                else
                {
                    FileDt = StMethod.GetListDT<InvoiceAging>("Select JobNumber from Joblist Where CompanyID=" + grdCompany.Rows[Rindex].Cells["CompanyID"].Value.ToString());
                }




                //FileDt = StMethod.GetListDT<string>("Select JobNumber from Joblist Where CompanyID=" + grdCompany.Rows[Rindex].Cells["CompanyID"].Value.ToString());

                foreach (DataRow Dr in FileDt.Rows)
                {
                    foreach (FileInfo FI in GetFile)
                    {
                        if (FI.Name.Contains(Dr["JobNumber"].ToString()))
                        {
                            InvoiceFileList.Items.Add(FI);
                            Find = true;
                        }
                    }
                }

                if (Find == true)
                {
                    InvoiceFileList.Path = GetDir;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void findAgingFILE()
        {
            try
            {
                var DirInfo = new DirectoryInfo(@"N:\transfer\PDF invoice");
                var AgingFile = DirInfo.GetFiles();
                var FileFound = default(bool);
                if (grdAging.Rows.Count > 0)
                {
                    string FileNotFound = "";
                    foreach (DataGridViewRow row in grdAging.Rows)
                    {
                        foreach (var FA in AgingFile)
                        {
                            // If FA.Name.Contains(Program.GetJobNumber(row.Item("JobNumber").ToString())) = True Then
                            // If row.Cells["DueInvoiceNo"].Value.ToString.Contains("11-113-1J") Then
                            // MessageBox.Show("hi")
                            // End If
                            if (FA.Name.ToLower().Contains(row.Cells["DueInvoiceNo"].Value.ToString().ToLower()) == true)
                            {
                                FileFound = true;
                                break;
                            }
                            else
                            {
                                FileFound = false;
                            }
                        }

                        if (FileFound == false)
                        {
                            FileNotFound = FileNotFound + Constants.vbCrLf + row.Cells["DueInvoiceNo"].Value.ToString();
                        }
                    }

                    if ((FileNotFound.Trim() ?? "") != (string.Empty ?? ""))
                    {
                        KryptonMessageBox.Show("Thise file list are not in directory=" + FileNotFound, "Email Due Invoice", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {
            }
        }
        private void FillCommunicationLog()
      {
            try
            {
                var CommDt = new DataTable();

                int CompanyID;



                //if(grdCompany.CurrentRow.Cells.Count > 0)
                //{

                //}
                //else
                //{


                //}

                if(grdCompany.Rows.Count > 0)
                {


              

                //if (grdCompany.CurrentRow.Cells["CompanyID"].Value != null)
                //{
                //    //worksheet.Cells[cellRowIndex, cellColumnIndex] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                //}
                //else
                //{
                //    //worksheet.Cells[cellRowIndex, cellColumnIndex] = String.Empty;
                //}

                //if (string.IsNullOrEmpty(grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString()))
                //{
                //    CompanyID = Convert.ToInt32(grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString());
                //}
                //else
                //{


                //}

                //Dim Query As String = "SELECT     CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" & grdCompany.CurrentRow.Cells("CompanyID").Value.ToString()

                string Query = "SELECT     CommLogID, CompanyID, InvoiceNo, Method, Notes, CallBackDate FROM CommunicationLog WHERE CompanyID=" + grdCompany.CurrentRow.Cells["CompanyID"].Value.ToString();
                if ((InvoiceJobStr.Trim().ToString() ?? "") != (string.Empty ?? ""))
                {
                    Query = Query + " AND " + InvoiceJobStr;
                }

                    //CommDt = StMethod.GetListDT<CommunicationLogData>(Query);


                    //CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(Query);



                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        CommDt = StMethod.GetListDTNew<CommunicationLogDataEdit>(Query);
                    }
                    else
                    {
                        CommDt = StMethod.GetListDT<CommunicationLogDataEdit>(Query);

                    }

                    grdCommunicationLog.DataSource = CommDt;
                {
                    var withBlock = grdCommunicationLog;
                    withBlock.Columns["CommLogID"].Visible = false;
                    withBlock.Columns["CompanyID"].Visible = false;
                    withBlock.Columns["InvoiceNo"].HeaderText = "Invoice#";
                    withBlock.Columns["InvoiceNo"].Width = 80;
                    withBlock.Columns["Method"].Width = 80;
                    withBlock.Columns["Notes"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    withBlock.Columns["Notes"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
               }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        private void grdInvoiceAction_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                //Query = "SELECT ActionID, InvoiceNo, ActionName, ActionDate, Status, CompanyID, Notes FROM InvoiceAction where CompanyID=" + grdCompany.Rows[Rowindex].Cells["CompanyID"].Value.ToString() + "";

                if (e.ColumnIndex == 5)
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
                        //e.Value = string.Format("{0:MM/dd/yyyy hh:mm tt}", dDate);
                        e.FormattingApplied = true;
                    }
                    else
                    {
                        

                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdAging_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                

                if (e.ColumnIndex == 4)
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



                    //if ((value != null))
                    //{
                    //    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    //e.FormattingApplied = true;

                    //    string inputString = "2000-02-02";
                    //    DateTime dDate;

                    //    inputString = e.Value.ToString();

                    //    if (DateTime.TryParse(inputString, out dDate))
                    //    {
                    //        e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                    //        e.FormattingApplied = true;

                    //    }

                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}



                    //String value = e.Value as string;

                    //if ((value != null))
                    //{


                    //    string inputString = "2000-02-02";
                    //    DateTime dDate;

                    //    inputString = e.Value.ToString();

                    //    if (DateTime.TryParse(inputString, out dDate))
                    //    {
                    //        //String.Format("{0:d/MM/yyyy}", dDate);

                    //        //e.Value = string.Format("{0:d/MM/yyyy}", dDate);
                    //        e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                    //        e.FormattingApplied = true;
                    //        //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                    //    }
                    //    else
                    //    {
                    //        //Console.WriteLine("Invalid"); // <-- Control flow goes here
                    //        e.Value = e.CellStyle.NullValue;
                    //        e.FormattingApplied = true;
                    //    }


                    //    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    //e.FormattingApplied = true;

                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdCommunicationLog_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {            
                

                if (e.ColumnIndex == 7)
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

        private void grdCommunicationLog_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //try
            //{

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        private void InvoiceFileList_DoubleClick_1(object sender, EventArgs e)
        {
            //    Dim fExt As String = String.Empty
            //Dim filePath As String = InvoiceFileList.Path & "\"
            //Try
            //    If InStrRev(InvoiceFileList.FileName, ".") Then
            //        System.Diagnostics.Process.Start(filePath & InvoiceFileList.FileName)
            //    End If
            //Catch ex As Exception
            //    KryptonMessageBox.Show(ex.Message, "Message")
            //End Try

            try
            {
                String fExt = string.Empty;
                String filepath = InvoiceFileList.Path + @"\";

                //Microsoft.VisualBasic.Core.dll


                //If InStrRev(InvoiceFileList.FileName, ".") Then

                if (Microsoft.VisualBasic.Strings.InStrRev(InvoiceFileList.FileName, ".") > 0)
                {
                    System.Diagnostics.Process.Start((filepath + InvoiceFileList.FileName));
                }


                //if (Microsoft.VisualBasic.Strings.InStrRev(InvoiceFileList.FileName, ".") == 0)
                //{
                //    System.Diagnostics.Process.Start((filepath + InvoiceFileList.FileName));
                //}

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdCompany_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdAging_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                String value2 = grdAging.Rows[e.RowIndex].Cells[4].Value.ToString() as string;

                if (e.ColumnIndex == 4)
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
                            grdAging.Rows[e.RowIndex].Cells[4].Value = value2;
                            grdAging.Rows[e.RowIndex].Cells[4].Tag = inputString;
                        }
                        else
                        {
                            grdAging.Rows[e.RowIndex].Cells[4].Tag = inputString;


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

        private void grdCommunicationLog_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String value2 = grdCommunicationLog.Rows[e.RowIndex].Cells[7].Value.ToString() as string;

                if (e.ColumnIndex == 7)
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
                            grdCommunicationLog.Rows[e.RowIndex].Cells[7].Value = value2;
                            grdCommunicationLog.Rows[e.RowIndex].Cells[7].Tag = inputString;
                        }
                        else
                        {
                            grdCommunicationLog.Rows[e.RowIndex].Cells[7].Tag = inputString;


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

        private void grdInvoiceAction_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String value2 = grdInvoiceAction.Rows[e.RowIndex].Cells[5].Value.ToString() as string;

                
                if (e.ColumnIndex == 5)
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
                            grdInvoiceAction.Rows[e.RowIndex].Cells[5].Value = value2;
                            grdInvoiceAction.Rows[e.RowIndex].Cells[5].Tag = inputString;
                        }
                        else
                        {
                            grdInvoiceAction.Rows[e.RowIndex].Cells[5].Tag = inputString;
                        }
                    }
                    else
                    {
                        //e.Value = e.CellStyle.NullValue;
                        //e.FormattingApplied = true;
                    }

                }

            }
            catch(Exception ex)
            {

            }
        }

        private void grdInvoiceAction_CellLeave(object sender, DataGridViewCellEventArgs e)
        {


           
                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                //Date101 = string.Format("{0:dd/MM/yyyy}", grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString());

                //String value2 = grdInvoiceAction.Rows[e.RowIndex].Cells[5].Value.ToString() as string;


                //if (e.ColumnIndex == 5)
                //{

                //    if ((value2 != null) && (value2 != string.Empty))
                //    {
                //        string inputString = "2000-02-02";

                //        DateTime dDate = DateTime.Now;

                //        inputString = string.Format("{0:MM/d/yyyy}", value2);
                //        inputString = value2.ToString() + " 12:00:00 AM";

                //        inputString = value2.ToString();



                //        if (DateTime.TryParse(inputString, out dDate))
                //        {

                //            value2 = string.Format("{0:MM/dd/yyyy}", dDate);

                //            string temp = string.Format("{0:dd/MM/yyyy}", value2);

                //            //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
                //            grdInvoiceAction.Rows[e.RowIndex].Cells[5].Value = value2;
                //            grdInvoiceAction.Rows[e.RowIndex].Cells[5].Tag = inputString;
                //        }
                //        else
                //        {
                //            grdInvoiceAction.Rows[e.RowIndex].Cells[5].Tag = inputString;
                //        }
                //    }
                //    else
                //    {
                //        //e.Value = e.CellStyle.NullValue;
                //        //e.FormattingApplied = true;
                //    }

                //}
 


            

        }

        private void grdCommunicationLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
