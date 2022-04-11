using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.JobTrackingForm;
//using JobTracker.Open_Dilaogue_Frm;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using ExpTree_Demo_CS;

namespace JobTracker.InvoiceReport
{
    public partial class FrmAging : Form
    {
        #region Declaration
        //private DataGridViewComboBoxCell cmbContactsName;

        DataTable dttemp = new DataTable();

        private static FrmAging _Instance;
        #endregion
        public FrmAging()
        {
            InitializeComponent();
        }

        #region Events
        private void FrmAging_Load(object sender, EventArgs e)
        {
            try
            {
                FillGrdCompany();
                //AddContactCombo();
                InvoiceFileList.Path = @"N:\transfer\PDF invoice";
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                //MessageBox.Show(ex.Message, "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdCompany_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 & e.ColumnIndex != -1)
            {
                grdAgingeInvoice(e.RowIndex);
                ChangeTraficLight(e.RowIndex);
            }

            try
            {
                ChangeDirJobNumber(e.RowIndex);
            }
            catch (Exception ex)
            {
                //KryptonMessageBox.Show(ex.Message, "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDueInvoice_Click(object sender, EventArgs e)
        {
            Program.CallEmailRemFrm = true;
            var FrmImport = new ImportExcelInvoiceDue();
            FrmImport.Show();
            try
            {
                var ColorDT = new DataTable();
                int aging;
                var dtInvoice = new DataTable();
                
                string JN = Program.GetJobNumber(grdAgingInvoice.Rows[grdAgingInvoice.CurrentRow.Index].Cells["DueInvoiceNo"].Value.ToString());


                //Program.GetJobID = StMethod.GetSingleInt("Select JoblistID From JobList Where JobNumber='" + JN + "'");
                //ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                //// JobAndTrackingMDI.GetJobID = selectedJobListID
                //dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    Program.GetJobID = StMethod.GetSingleIntNew("Select JoblistID From JobList Where JobNumber='" + JN + "'");
                    ColorDT = StMethod.GetListDTNew<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                    dtInvoice = StMethod.GetListDTNew<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");
                }
                else
                {
                    Program.GetJobID = StMethod.GetSingleInt("Select JoblistID From JobList Where JobNumber='" + JN + "'");
                    ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                    dtInvoice = StMethod.GetListDT<DueInvoice>("SELECT Aging, DueInvoiceNo, DueDate, CompanyID,Balance FROM  AgingInvoice WHERE CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() + "  ORDER BY Aging DESC ");

                }


                if (dtInvoice.Rows.Count > 0)
                {
                    if (dtInvoice.Rows[0]["Aging"].ToString() == string.Empty)
                    {
                        if (KryptonMessageBox.Show("Select Job Number not have due invoice! you want to continue.", "Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            // JobAndTrackingMDI.GetJobID = selectedJobListID
                            Program.ofrmMain.CreateFromandtab(new frmTrafficEmail());
                        }
                        else
                        {
                            return;
                        }
                    }

                    aging = Convert.ToInt32(dtInvoice.Columns["Aging"].ToString());
                    Program.DueInvoiceEmailAddress = grdAgingInvoice.Rows[grdAgingInvoice.CurrentRow.Index].Cells["EmailAddress"].Value.ToString();
                    if (aging >= 15)
                    {
                        Program.GetColorID = Convert.ToInt64(ColorDT.Rows[0][Program.GetColumnName(aging)]);
                        ////                        if (aging >= 15 & aging < 30)
                        ////                        {
                        ////Program.GetColorID = ColorDT.Rows[0]["Age15Action"].ToString();
                        ////                        }

                        ////                        if (aging >= 30 & aging < 45)
                        ////                        {
                        ////                            JobAndTrackingMDI.GetColorID = ColorDT.Rows[0]["Age30Action"].ToString();
                        ////                        }

                        ////                        if (aging >= 45 & aging < 60)
                        ////                        {
                        ////                            JobAndTrackingMDI.GetColorID = ColorDT.Rows[0]["Age45Action"].ToString();
                        ////                        }

                        ////                        if (aging >= 60 & aging < 75)
                        ////                        {
                        ////                            JobAndTrackingMDI.GetColorID = ColorDT.Rows[0]["Age60Action"].ToString();
                        ////                        }

                        ////                        if (aging >= 75 & aging < 90)
                        ////                        {
                        ////                            JobAndTrackingMDI.GetColorID = ColorDT.Rows[0]["Age75Action"].ToString();
                        ////                        }

                        ////                        if (aging >= 90 & aging < 105)
                        ////                        {
                        ////                            JobAndTrackingMDI.GetColorID = ColorDT.Rows[0]["Age90Action"].ToString();
                        ////                        }

                        ////                        if (aging >= 105)
                        ////                        {
                        ////                            JobAndTrackingMDI.GetColorID = ColorDT.Rows[0]["Age105Action"].ToString();
                        ////                        }
                        // JobAndTrackingMDI.GetJobID = selectedJobListID
                        Program.ofrmMain.CreateFromandtab(new frmTrafficEmail());
                    }
                    else
                    {
                        Program.GetColorID = 0;
                        if (KryptonMessageBox.Show("Select Job Number not have 15 days old due invoice! you want to continue.", "Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            // JobAndTrackingMDI.GetJobID = selectedJobListID
                            Program.ofrmMain.CreateFromandtab(new frmTrafficEmail());
                        }
                    }
                }

                Program.ofrmMain.CloseActiveForm("");
                ////foreach (Form frm in Application.OpenForms)
                ////{
                ////    if (frm.Text == Program.Text)
                ////    {
                ////        frm.Close();
                ////        Program.Instance.Show();CompanyAging
                ////    }
                ////}
            }
            catch (Exception ex)
            {
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

            var Show2 = new frmThreadCS();
            Show2.GetJobPath = @"N:\transfer\PDF invoice";
            Show2.Show();
            
        }

        private void txtCompanySearch_TextChanged(object sender, EventArgs e)
        {
            FillGrdCompany();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCompanySearch.Clear();
        }

        private void grdCompany_RowHeaderMouseClick(object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                grdAgingeInvoice(e.RowIndex);
                ChangeTraficLight(e.RowIndex);
            }

            try
            {
                ChangeDirJobNumber(e.RowIndex);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Manager", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdCompany_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //long CompanyID = Convert.ToInt64(grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value);
            //if (e.KeyCode == Keys.Up)
            //{
            //    if (grdCompany.CurrentRow.Index != 0)
            //    {
            //        ChangeTraficLight(grdCompany.CurrentRow.Index - 1);
            //        ChangeDirJobNumber(grdCompany.CurrentRow.Index - 1);
            //        grdAgingeInvoice(grdCompany.CurrentRow.Index - 1);
            //    }
            //}

            //if (e.KeyCode == Keys.Down)
            //{
            //    if (grdCompany.CurrentRow.Index != grdCompany.Rows.Count - 1)
            //    {
            //        grdAgingeInvoice(grdCompany.CurrentRow.Index + 1);
            //        ChangeTraficLight(grdCompany.CurrentRow.Index + 1);
            //        ChangeDirJobNumber(grdCompany.CurrentRow.Index + 1);
            //    }
            //}

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

        private void grdAgingInvoice_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                //MessageBox.Show(grdAgingInvoice.Columns[e.ColumnIndex].Name.ToString());

                if (grdAgingInvoice.Columns[e.ColumnIndex].Name == "cmbContactsName" & e.RowIndex != -1)
                //if (grdAgingInvoice.Columns[e.ColumnIndex].Index == 5 & e.RowIndex != -1)
                {
                    DataTable dt = new DataTable();
                    //long ContactID = Convert.ToInt64((System.Windows.Forms.DataGridViewComboBoxCell)grdAgingInvoice.Rows[e.RowIndex].Cells["cmbContactsName"].Value);


                    //Dim ContactID As Int64 = DirectCast(grdAgingInvoice.Rows(e.RowIndex).Cells("cmbContactsName"), System.Windows.Forms.DataGridViewComboBoxCell).Value

                    //string s1;
                    //s1 = grdAgingInvoice.Rows[e.RowIndex].Cells["cmbContactsName"].Value.ToString();

                    //long ContactID = Convert.ToInt64((System.Windows.Forms.DataGridViewComboBoxCell)grdAgingInvoice.Rows[e.RowIndex].Cells["cmbContactsName"].Value);

                    Int64? ContactID=null;
                    string query;

                    if (string.IsNullOrEmpty((grdAgingInvoice.Rows[e.RowIndex].Cells["cmbContactsName"].Value.ToString())))
                    {
                        ContactID = null;
                        query = "SELECT EmailAddress,(FirstName +' '+ LastName) as Contact,ContactsID FROM contacts WHERE ContactsID=null";
                    }
                    else
                    {
                        ContactID = Convert.ToInt64(grdAgingInvoice.Rows[e.RowIndex].Cells["cmbContactsName"].Value.ToString());

                        query = "SELECT EmailAddress,(FirstName +' '+ LastName) as Contact,ContactsID FROM contacts WHERE ContactsID=" + ContactID;
                    }

                    //Int64 ContactID = Convert.ToInt64(grdAgingInvoice.Rows[e.RowIndex].Cells["cmbContactsName"].Value.ToString());

                    //dt = DAL.Filldatatable("SELECT EmailAddress,(FirstName +' '+ LastName) as Contact FROM contacts WHERE ContactsID=" & ContactID)


                    //dt = StMethod.GetListDT<InvContactEmail>("SELECT EmailAddress,(FirstName +' '+ LastName) as Contact,ContactsID FROM contacts WHERE ContactsID=" + ContactID);


                    //dt = StMethod.GetListDT<InvContactEmail>(query);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        dt = StMethod.GetListDTNew<InvContactEmail>(query);

                    }
                    else
                    {
                        dt = StMethod.GetListDT<InvContactEmail>(query);
                    }



                    if (dt.Rows.Count > 0)
                    {

                      
                    
                        //grdAgingInvoice.Rows[e.RowIndex].Cells["EmailAddress"].Value = dt.Rows[0]["EmailAddress"].ToString();



                        //grdAgingInvoice.Rows[e.RowIndex].Cells["ContactsName"].Value = dt.Rows[0][1].ToString();


                        if (grdAgingInvoice.Rows[e.RowIndex].Cells["ContactsName"].Value.ToString() == string.Empty)
                        {
                            
                        }
                        else
                        {
                            //grdAgingInvoice.Rows[e.RowIndex].Cells["ContactsName"].Value = dt.Rows[0]["Contact"].ToString();
                            grdAgingInvoice.Rows[e.RowIndex].Cells["EmailAddress"].Value = dt.Rows[0]["EmailAddress"].ToString();
                        }


                        //grdAgingInvoice.Rows[e.RowIndex].Cells["ContactsName"].Value = dt.Rows[0]["Contact"].ToString();


                    }
                }

                String value2 = grdAgingInvoice.Rows[e.RowIndex].Cells[2].Value.ToString() as string;

                if (e.ColumnIndex == 2)
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
                            grdAgingInvoice.Rows[e.RowIndex].Cells[2].Value = value2;
                            grdAgingInvoice.Rows[e.RowIndex].Cells[2].Tag = inputString;
                        }
                        else
                        {
                            grdAgingInvoice.Rows[e.RowIndex].Cells[2].Tag = inputString;
                        }
                    }
                    else
                    {
                        //e.Value = e.CellStyle.NullValue;
                        //e.FormattingApplied = true;
                    }
                }

           }

            //grdAgingInvoice.Rows(e.RowIndex).Cells("EmailAddress").Value = dt.Rows(0).Item(0).ToString()
            //grdAgingInvoice.Rows(e.RowIndex).Cells("ContactsName").Value = dt.Rows(0).Item(1).ToString()


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
       
        private void grdAgingInvoice_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            try
            {
                //anError.ThrowException = false;

                //MessageBox.Show(anError.Exception.Message.ToString ());

                DataGridView dgv = (DataGridView)sender;
                if (anError.Exception is ArgumentException)
                {

                    //MessageBox.Show(anError.ColumnIndex.ToString());

                    object value = dgv.Rows[anError.RowIndex].Cells[anError.ColumnIndex].Value;
                    if (!((DataGridViewComboBoxColumn)dgv.Columns[anError.ColumnIndex]).Items.Contains(value))
                    {
                        //((DataGridViewComboBoxCell)dgv[anError.ColumnIndex, anError.RowIndex]).Value = DBNull.Value;
                        //((DataGridViewComboBoxCell)dgv[anError.ColumnIndex, anError.RowIndex]).Value = value;
                        //((DataGridViewComboBoxColumn)dgv.Columns[anError.ColumnIndex]).Items.Add(value);

                        // MessageBox.Show("Row index is = " + anError.RowIndex + " and Columns Index is " + anError.ColumnIndex);

                        
                        anError.ThrowException = false;
                    }
                }
                else

                {
                    //core.ShowErrorMessage(e.Exception.Message);
                    anError.Cancel = true;
                }

                //DataGridView dgv = (DataGridView)sender;

                //if (anError.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
                //{
                //    object value = dgv.Rows[anError.RowIndex].Cells[anError.ColumnIndex].Value;
                //    if (!((DataGridViewComboBoxColumn)dgv.Columns[anError.ColumnIndex]).Items.Contains(value))
                //    {
                //        ((DataGridViewComboBoxColumn)dgv.Columns[anError.ColumnIndex]).Items.Add(value);
                //        anError.ThrowException = false;
                //    }
                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
        }
        #endregion

        #region Methods
        public void FillGrdCompany()
        {
            try
            {
                var DTCompany = new DataTable();
                string Query;
                
                Query = "SELECT distinct Company.CompanyID, Company.CompanyName,(Select top 1 WorkPhone from Contacts Where CompanyID=Company.CompanyID and Contacts.Accounting=1) as Phone,(Select top 1 FaxNumber from Contacts Where CompanyID=Company.CompanyID and Contacts.Accounting=1) as Fax , Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode,  Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action,   Company.Age105Action,Company.Aging FROM         Contacts RIGHT OUTER JOIN      Company ON Contacts.CompanyID = Company.CompanyID WHERE     (Company.CompanyID > 0) AND (Company.IsDelete = 0 OR    Company.IsDelete IS NULL)";

                if (CkbPendingInvoice.Checked == true)
                {
                    // Query = Query & " AND  Company.CompanyID  in (SELECT  distinct    JobList.CompanyID FROM         JobList LEFT OUTER JOIN                      JobTracking ON JobList.JobListID = JobTracking.JobListID Where JobTracking.status='Pending' ANd ( JobTracking.IsDelete=0 or JobTracking.IsDelete Is null))"
                    Query = Query + " AND  Company.CompanyID  in (SELECT     CompanyID FROM         AgingInvoice)";
                }

                if (txtCompanySearch.Text.Trim() != string.Empty)
                {
                    Query = Query + " AND Company.CompanyName like '%" + txtCompanySearch.Text.Trim() + "%'";
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
                    withBlock.Columns["Phone"].HeaderText = "Phone";
                    withBlock.Columns["Fax"].HeaderText = "Fax";
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
                    ChangeTraficLight(grdCompany.CurrentRow.Index);
                }
                else
                {
                    grdAgingInvoice.DataSource = null;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void ChangeTraficLight(int RIndex)
        {
            //var DAL = new DataAccessLayer();
            try
            {
                pnlTraficLight.Visible = false;
                int aging;
                var ColorDT = new DataTable();
                
                //ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    ColorDT = StMethod.GetListDTNew<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());


                }
                else
                {
                    ColorDT = StMethod.GetListDT<InvoiceAging>("SELECT Age15Action, Age30Action, Age45Action, Age60Action, Age75Action, Age90Action, Age105Action, Aging FROM  Company WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());

                }

                if (ColorDT.Rows.Count > 0)
                {
                    //aging = ColorDT.Rows[0]["Aging"].ToString();
                    aging = Convert.ToInt32(ColorDT.Rows[0]["Aging"].ToString());
                    if (aging >= 15)
                    {
                        Program.GetColorID = Convert.ToInt64(ColorDT.Rows[0][Program.GetColumnName(aging)]);
                        btnAgingColor.BackColor = Program.ChangeTraficLightColor(Program.GetColorID);
                    }
                    ////    if (aging >= 15 & aging < 30)
                    ////{
                    ////    btnAgingColor.BackColor = Program.ChangeTraficLightColor(ColorDT.Rows[0]["Age15Action"]);
                    ////}

                    ////if (aging >= 30 & aging < 45)
                    ////{
                    ////    btnAgingColor.BackColor = Program.ChangeTraficLightColor(ColorDT.Rows[0]["Age30Action"]);
                    ////}

                    ////if (aging >= 45 & aging < 60)
                    ////{
                    ////    btnAgingColor.BackColor = Program.ChangeTraficLightColor(ColorDT.Rows[0]["Age45Action"]);
                    ////}

                    ////if (aging >= 60 & aging < 75)
                    ////{
                    ////    btnAgingColor.BackColor = Program.ChangeTraficLightColor(ColorDT.Rows[0]["Age60Action"]);
                    ////}

                    ////if (aging >= 75 & aging < 90)
                    ////{
                    ////    btnAgingColor.BackColor = Program.ChangeTraficLightColor(ColorDT.Rows[0]["Age75Action"]);
                    ////}

                    ////if (aging >= 90 & aging < 105)
                    ////{
                    ////    btnAgingColor.BackColor = Program.ChangeTraficLightColor(ColorDT.Rows[0]["Age90Action"]);
                    ////}

                    ////if (aging >= 105)
                    ////{
                    ////    btnAgingColor.BackColor = Program.ChangeTraficLightColor(ColorDT.Rows[0]["Age105Action"]);
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
            DataTable DTCombo = new DataTable();
            //DataGridViewComboBoxColumn cmbContactsName = new DataGridViewComboBoxColumn();

            try
            {
                
                var AgingeInvoice = new DataTable();
                var tEMP = new DataTable();

                string Query;
                grdAgingInvoice.DataSource = null;
                grdAgingInvoice.Columns.Clear();
                Query = "Select Aging, DueInvoiceNo, DueDate,  Balance,CompanyID from AgingInvoice where CompanyID=" + grdCompany.Rows[RowIndex].Cells["CompanyID"].Value.ToString() + " Order by Aging Desc";


                //AgingeInvoice = StMethod.GetListDT<DueInvoice>(Query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    AgingeInvoice = StMethod.GetListDTNew<DueInvoice>(Query);

                }
                else
                {
                    AgingeInvoice = StMethod.GetListDT<DueInvoice>(Query);
                }

                AgingeInvoice.Columns.Add("ContactsName");
                AgingeInvoice.Columns.Add("EmailAddress");
                AgingeInvoice.Columns.Add("Summation");
                AgingeInvoice.Columns.Add("Address");
                AgingeInvoice.Columns.Add("Description");

                AgingeInvoice.Columns.Add("ContactsID");

                var Summation = default(decimal);
                foreach (DataRow dr in AgingeInvoice.Rows)
                {

                    string check = dr["Balance"].ToString();

                    Summation = Summation + Convert.ToDecimal(dr["Balance"]);
                    dr["Summation"] = Summation;

                    //string StrAddress = "SELECT ( Contacts.FirstName+' '+Contacts.LastName) AS Contact, Contacts.EmailAddress,Joblist.Address,JobList.Description FROM         JobList INNER JOIN  Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE  JobList.JobNumber= '" + Program.GetJobNumber(dr["DueInvoiceNo"].ToString()) + "'";

                    string StrAddress = "SELECT ( Contacts.FirstName+' '+Contacts.LastName) AS Contact, Contacts.EmailAddress,Joblist.Address,JobList.Description,Contacts.ContactsID FROM JobList INNER JOIN  Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE  JobList.JobNumber= '" + Program.GetJobNumber(dr["DueInvoiceNo"].ToString()) + "'";



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

                        string s1;

                        s1 = tEMP.Rows[0]["EmailAddress"].ToString();
                        
                        string s2 = StrAddress;


                        dr["ContactsName"] = tEMP.Rows[0]["Contact"].ToString();
                        dr["EmailAddress"] = tEMP.Rows[0]["EmailAddress"].ToString();
                        dr["Address"] = tEMP.Rows[0]["Address"].ToString();
                        dr["Description"] = tEMP.Rows[0]["Description"].ToString();
                        dr["ContactsID"] = tEMP.Rows[0]["ContactsID"].ToString();
                    }
                }


                //for (int k = 0; k < AgingeInvoice.Columns.Count; k++)
                //{
                //    //MessageBox.Show(grdAgingInvoice.Columns[k].HeaderText.ToString());
                //    MessageBox.Show(AgingeInvoice.Columns[k].ColumnName.ToString());

                //}
                

                grdAgingInvoice.DataSource = AgingeInvoice;


                //for (int k = 0; k < grdAgingInvoice.Columns.Count; k++)
                //{

                //    MessageBox.Show(grdAgingInvoice.Columns[k].HeaderText.ToString());
                //}




                string Query2 =string.Empty;
                String query3 = "SELECT (FirstName +' '+ LastName) AS Contact3,";
                Query2 = query3 + "EmailAddress,ContactsID as CID ";
                Query2 = Query2 + "FROM contacts ";
                Query2 = Query2 + "WHERE (IsDelete=0 or IsDelete IS NULL) AND Companyid=";
                Query2 = Query2 + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();


                Query2 = "SELECT (Contacts.FirstName +' '+ Contacts.LastName) as Contact3,Contacts.EmailAddress,Contacts.ContactsID as CID FROM contacts where (Contacts.IsDelete=0 or Contacts.IsDelete IS NULL) AND Contacts.Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();


                //DTCombo = StMethod.GetListDT<InvoiceAddressCheck>(Query2);



                //DTCombo = StMethod.GetListDT<InvoiceAddresTest>(Query2);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    DTCombo = StMethod.GetListDTNew<InvoiceAddresTest>(Query2);
                }
                else
                {
                    DTCombo = StMethod.GetListDT<InvoiceAddresTest>(Query2);
                }


                DataGridViewComboBoxColumn cmbContactsName = new DataGridViewComboBoxColumn();

                cmbContactsName.DisplayMember = DTCombo.Columns["Contact3"].ToString();

        //        cmbContactsName.ValueType = typeof(Int32);
                cmbContactsName.ValueMember = DTCombo.Columns["CID"].ToString();

                cmbContactsName.DisplayIndex = 5;
                cmbContactsName.HeaderText = "Contacts Name";
                //cmbContactsName.DataPropertyName = "ContactsName";
                cmbContactsName.DataPropertyName = "ContactsID";
                cmbContactsName.Name = "cmbContactsName";
                cmbContactsName.DataSource = DTCombo;

                //this.grdAgingInvoice.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e) { };
                //cmbContactsName.DefaultCellStyle.NullValue = 0;


                grdAgingInvoice.Columns.Insert(5, cmbContactsName);
                grdAgingInvoice.Columns["CompanyID"].Visible = false;
                grdAgingInvoice.Columns["DueInvoiceNo"].HeaderText = "Due InvoiceNo";
                grdAgingInvoice.Columns["DueDate"].HeaderText = "Due Date";
                grdAgingInvoice.Columns["EmailAddress"].HeaderText = "Email Address";
                grdAgingInvoice.Columns["Description"].HeaderText = "Job Description";
                grdAgingInvoice.Columns["ContactsName"].Visible = false;
                grdAgingInvoice.Columns["ContactsID"].Visible = false;



                //grdAgingInvoice.Columns.Insert(5, AddContactCombo());
                //{
                //    var withBlock = grdAgingInvoice;
                //    withBlock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //    withBlock.Columns["CompanyID"].Visible = true;
                //    withBlock.Columns["DueInvoiceNo"].HeaderText = "Due InvoiceNo";
                //    withBlock.Columns["DueDate"].HeaderText = "Due Date";

                //    // .Columns["ContactsName"].HeaderText = "Contacts Name"   'Add to new column In grid view
                //    withBlock.Columns["EmailAddress"].HeaderText = "Email Address";   // Add to new column In grid view
                //    withBlock.Columns["Description"].HeaderText = "Job Description";
                //    withBlock.Columns["ContactsName"].Visible = true;                    
                //}


                findAgingFILE();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        

        public DataGridViewComboBoxColumn AddContactCombo()
        {

            DataGridViewComboBoxColumn ComboBoxContactsName = new DataGridViewComboBoxColumn();
            try
            {
                //var dt2 = new DataTable();
                //dt2 = StMethod.GetListDT<InvoiceAddress>("SELECT (FirstName +' '+ LastName) as Contact,EmailAddress ,ContactsID FROM contacts where (IsDelete=0 or IsDelete IS NULL) AND Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());

                DataTable dt2 = new DataTable();
                string Query2;
                String query3 = "SELECT (FirstName +' '+ LastName) AS Contact2,";
                Query2 = query3 + "EmailAddress,ContactsID ";
                Query2 = Query2 + "FROM contacts ";
                Query2 = Query2 + "WHERE (IsDelete=0 or IsDelete IS NULL) AND Companyid=";
                Query2 = Query2 + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString();



                //dt2 = StMethod.GetListDT<InvoiceAddress>(Query2);
                //dt2 = StMethod.GetListDT<InvoiceAddresTest>(Query2);

                //var dt2 = new DataTable();
                //dt2 = StMethod.GetListDT<InvoiceAddress>("SELECT (FirstName +' '+ LastName) as Contact,EmailAddress ,ContactsID FROM contacts where (IsDelete=0 or IsDelete IS NULL) AND Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());
                //cmbContactsName.DataSource = dt2;
                //cmbContactsName.DisplayMember = dt2.Columns["Contact"].ToString();
                //cmbContactsName.ValueMember = dt2.Columns["ContactsID"].ToString();
                //cmbContactsName.DisplayIndex = 5;
                //cmbContactsName.HeaderText = "Contacts Name";
                //cmbContactsName.DataPropertyName = "ContactsName";
                //cmbContactsName.Name = "cmbContactsName";
                //return cmbContactsName;

             

                //string StrAddress = "SELECT ( Contacts.FirstName+' '+Contacts.LastName) AS Contact, Contacts.EmailAddress,Joblist.Address,JobList.Description FROM         JobList INNER JOIN  Contacts ON JobList.ContactsID = Contacts.ContactsID WHERE  JobList.JobNumber= '" + Program.GetJobNumber(dr["DueInvoiceNo"].ToString()) + "'";

                //dt2 = StMethod.GetListDT<InvoiceAddress>("SELECT (FirstName +' '+ LastName) as Contact,EmailAddress,ContactsID FROM contacts where (IsDelete=0 or IsDelete IS NULL) AND Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());

                //string tquery = "SELECT (Contacts.FirstName +' '+ Contacts.LastName) as Contact,Contacts.EmailAddress,ContactsID FROM contacts where (Contacts.IsDelete=0 or Contacts.IsDelete IS NULL) AND Contacts.Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString() ;

                //dt2 = StMethod.GetListDT<InvoiceAddress>(tquery);

                
                
                
                //dt2 = StMethod.GetListDT<InvoiceAddress>("SELECT (Contacts.FirstName +' '+ Contacts.LastName) as Contact,Contacts.EmailAddress,ContactsID FROM contacts where (Contacts.IsDelete=0 or Contacts.IsDelete IS NULL) AND Contacts.Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());



                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt2 = StMethod.GetListDTNew<InvoiceAddress>("SELECT (Contacts.FirstName +' '+ Contacts.LastName) as Contact,Contacts.EmailAddress,ContactsID FROM contacts where (Contacts.IsDelete=0 or Contacts.IsDelete IS NULL) AND Contacts.Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());

                }
                else
                {
                    dt2 = StMethod.GetListDT<InvoiceAddress>("SELECT (Contacts.FirstName +' '+ Contacts.LastName) as Contact,Contacts.EmailAddress,ContactsID FROM contacts where (Contacts.IsDelete=0 or Contacts.IsDelete IS NULL) AND Contacts.Companyid=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString());

                }

                //cmbContactsName.DataSource = dt2.DefaultView;
                //cmbContactsName.DisplayMember = dt2.Columns["Contact"].ToString();
                //cmbContactsName.ValueMember = dt2.Columns["ContactsID"].ToString();

                //cmbContactsName.DisplayIndex = 5;
                //cmbContactsName.HeaderText = "Contacts Name";
                //cmbContactsName.DataPropertyName = "ContactsName";
                //cmbContactsName.Name = "cmbContactsName";
                //cmbContactsName.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;



                //cmbContactsName = new DataGridViewComboBoxColumn() { DataSource = dt2, DisplayMember = "Contact", ValueMember = "ContactsID", DataPropertyName = "ContactsName", Name = "cmbContactsName", HeaderText = "Contacts Name",DisplayIndex=5 };

                //cmbContactsName.DataSource = dt2;

                //cmbContactsName.ValueMember = dt2.Columns["ContactsID"].ToString();
                //cmbContactsName.DisplayMember = dt2.Columns["Contact"].ToString();
                //cmbContactsName.DataPropertyName = grdAgingInvoice.Columns["ContactsName"].Name.ToString (); 

                //cmbContactsName.DisplayIndex = 5;
                //cmbContactsName.HeaderText = "Contacts Name";
                //cmbContactsName.Name = "cmbContactsName";
                //cmbContactsName.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;


                //string s1 = "-load1 UvjkiJyjLlPN1o7FCAwQ0en80t769u5uBKAL1t0u0Cajk86WNmp83F";

                //String filter = s1.ToString();
                //String[] filterRemove = filter.Split(' ');

                //String Value1= filterRemove[1];


                ComboBoxContactsName.DataSource = dt2;
                ComboBoxContactsName.DisplayMember = dt2.Columns["Contact"].ToString();
                ComboBoxContactsName.ValueMember = dt2.Columns["ContactsID"].ToString();

                ComboBoxContactsName.DisplayIndex = 5;
                ComboBoxContactsName.HeaderText = "Contacts Name";
                ComboBoxContactsName.DataPropertyName = "ContactsName";

                //ComboBoxContactsName.DataPropertyName = "ContactsName";
                ComboBoxContactsName.Name = "cmbContactsName";

                //int columnIndex = Your ComboBoxColumn index;
                //(dataGridView1.Columns[columnIndex] as DataGridViewComboBoxColumn).DefaultCellStyle.NullValue = "Nothing selected";

                ComboBoxContactsName.DefaultCellStyle.NullValue = dt2.Columns["Contact"];


                //cmbContactsName.DataSource = dt2;

                //cmbContactsName.ValueMember = dt2.Columns["ContactsID"].ToString();
                //cmbContactsName.DisplayMember = dt2.Columns["Contact"].ToString();
                //cmbContactsName.DataPropertyName = "ContactsName";

                //cmbContactsName.HeaderText = "Contacts Name";
                //cmbContactsName.Name = "cmbContactsName";
                //cmbContactsName.DisplayIndex = 5;
                //cmbContactsName.DefaultCellStyle.NullValue = "ContactsName";



                //cmbContactsName.ValueMember = "ContactsID";
                //cmbContactsName.DisplayMember = "Contact";
                //cmbContactsName.DataPropertyName = "ContactsID";


                //mbColumn.DataSource = this.GetData("SELECT DISTINCT City FROM Customers");
                //cmbColumn.DataPropertyName = "City";
                //cmbColumn.ValueMember = "City";
                //cmbColumn.DisplayMember = "City";
                //cmbColumn.HeaderText = "City";
                //cmbColumn.ValueType = typeof(string);
                //cmbColumn.DefaultCellStyle.NullValue = "";
                //this.dataGridView2.Columns.Insert(2, cmbColumn);


                return ComboBoxContactsName;


            }
            catch (Exception ex)
            {
                return ComboBoxContactsName;
            }
        }

        private void ChangeDirJobNumber(int RIndex)
        {
            try
            {
                string GetDir = @"N:\transfer\PDF invoice";
                bool Find = false;
                InvoiceFileList.Path = GetDir;
                InvoiceFileList.Items.Clear();
                var DirFile = new DirectoryInfo(GetDir);
                var GetFile = DirFile.GetFiles();
                var FileDt = new DataTable();

                //FileDt = StMethod.GetListDT<JobNumList>("Select JobListID,JobNumber from Joblist Where CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    FileDt = StMethod.GetListDTNew<JobNumList>("Select JobListID,JobNumber from Joblist Where CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());

                }
                else
                {
                    FileDt = StMethod.GetListDT<JobNumList>("Select JobListID,JobNumber from Joblist Where CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());

                }

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
                throw ex;
            }
        }

        private void findAgingFILE()
        {
            try
            {
                var DirInfo = new DirectoryInfo(@"N:\transfer\PDF invoice");
                var AgingFile = DirInfo.GetFiles();
                var FileFound = default(bool);
                if (grdAgingInvoice.Rows.Count > 0)
                {
                    string FileNotFound = "";
                    foreach (DataGridViewRow row in grdAgingInvoice.Rows)
                    {
                        foreach (var FA in AgingFile)
                        {
                            // If FA.Name.Contains(Program.GetJobNumber(row.Item("JobNumber"].ToString()())) = True Then
                            // If row.Cells("DueInvoiceNo"].Value.ToString.Contains("11-113-1J") Then
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
            catch (Exception ex)
            {
            }
        }
        #endregion

        private void grdAgingInvoice_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try 
            {

                //if (grdAgingInvoice.CurrentCell.ColumnIndex == 1 && e.Control is ComboBox)
                //{
                //    //ComboBox comboBox = e.Control as ComboBox;
                //    //comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                //    //comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;

                //    ////comboBox.DisplayMember = dttemp.Columns["Contact"].ToString();

                //}

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = ((ComboBox)sender).SelectedIndex;
            MessageBox.Show("Selected Index = " + selectedIndex);
        }


        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {

            try
            {


                //var currentcell = grdAgingInvoice.CurrentCellAddress;
                //var sendingCB = sender as DataGridViewComboBoxEditingControl;
                //DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)grdAgingInvoice.Rows[currentcell.Y].Cells[0];
                //cel.Value = sendingCB.EditingControlFormattedValue.ToString();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void grdAgingInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //MessageBox.Show(grdAgingInvoice.Columns["cmbContactsName"].ToString ());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void grdAgingInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //MessageBox.Show(grdAgingInvoice.Columns["cmbContactsName"].ToString ());

                //MessageBox.Show(grdAgingInvoice.Rows[e.RowIndex].Cells["cmbContactsName"].Value.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }

        private void grdAgingInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //MessageBox.Show("Index => " + e.ColumnIndex + "Value => " + e.Value.ToString());

                if (e.ColumnIndex == 2)
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