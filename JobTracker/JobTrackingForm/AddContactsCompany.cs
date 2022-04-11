//using Common;
using Commen2;
using ComponentFactory.Krypton.Toolkit;

//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Application_Tool;
using JobTracker.Classes;
//using Microsoft.Office.Interop.Word;
//using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using DataTable = System.Data.DataTable;
using Exception = System.Exception;
using MessageBoxButtons = System.Windows.Forms.MessageBoxButtons;
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using FontFamily = System.Drawing.FontFamily;
using System.Globalization;
using JobTracker.ApplicationTool;
using NPOI.HSSF.UserModel;





namespace JobTracker.JobTrackingForm
{
    public partial class AddContactsCompany : Form
    {
        #region Declaration
        private static int selectedCompanyID;
        private string CheckString;
        private string CurrentColName;
        private Int32 CurrentRoIndex;
        private Int32 CurrentColIndex;
        private bool CompanyLoad = false;
        private DataGridViewComboBoxColumn cmbVersionTable = new DataGridViewComboBoxColumn();
        private DataGridViewComboBoxColumn cmbTypicalInvoiceType = new DataGridViewComboBoxColumn();
        //private static AddContactsCompany _Instance;
        private List<int> ChangesRows = new List<int>();
        private int defualtTableVersionId;
        
        //private XSSFWorkbook workBook = new XSSFWorkbook();
        private HSSFWorkbook workBook = new HSSFWorkbook();


        DataTable MainDataTable;

        public int CompanyTotalRecord
        {
            set
            {
                lbltotalCompanyRecord.Text = string.Format("Company Total Record : {0}", value);
            }
        }
        #endregion

        public AddContactsCompany()
        {
            InitializeComponent();
        }

        #region Events
        private void AddContactsCompany_Load(System.Object sender, System.EventArgs e)
        {
            ProgressBar1.Visible = false;
            Label9.Visible = false;

            AddgrdColumn();
            PopulateTypicalInvoiceType();
            BindMasterCombo();
            CompanyLoad = true;
            //FillGrdCompany()
            //FillGrdContacts()
            //AddHandler grdCompany.EditingControlShowing, AddressOf grdCompany_EditingControlShowing
            //cmbWordLetter.SelectedIndex = 0 



            //defualtTableVersionId = StMethod.GetDefaultTableVersion();

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                defualtTableVersionId = StMethod.GetDefaultTableVersionNew();
            }
            else
            {
                defualtTableVersionId = StMethod.GetDefaultTableVersion();
            }

        }
        private void btnAddCompany_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (btnAddContacts.Text != "Insert")
                {
                    KryptonMessageBox.Show("First Save contacts infomation", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (btnAddCompany.Text == "Insert")
                {
                    for (Int32 i = 0; i < grdCompany.Rows.Count; i++)
                    {
                        if (grdCompany.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                        {
                            KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    
                    btnAddCompany.Text = "Save";
                    btnDeleteCompany.Enabled = false;
                    DataTable CompanyDt = new DataTable();
                    //CompanyDt = Program.ToDataTable<CompanyColor>((List<CompanyColor>)grdCompany.DataSource);
                    
                    CompanyDt = (DataTable)grdCompany.DataSource;                    
                    DataRow datarow = CompanyDt.NewRow();


                    //int defualtTableVersion = StMethod.GetDefaultTableVersion();

                    int defualtTableVersion2;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        defualtTableVersion2 = StMethod.GetDefaultTableVersionNew();
                    }
                    else
                    {
                        defualtTableVersion2 = StMethod.GetDefaultTableVersion();
                    }

                    datarow["CompanyID"] = 0;
                    datarow["CompanyName"] = "";
                    datarow["Address"] = "";
                    datarow["City"] = "";
                    datarow["State"] = "";
                    datarow["Country"] = "";
                    datarow["PostalCode"] = "";
                    datarow["DotInsuranceExp"] = "";
                    datarow["AirborneExpNUM"] = "";
                    datarow["ServRate"] = 1;
                    datarow["IBMNUM"] = "";
                    datarow["FedExNUM"] = "";
                    datarow["UserName"] = "";
                    datarow["PassWord"] = "";
                    datarow["Age15ActionColor"] = "";
                    datarow["Age30ActionColor"] = "";
                    datarow["Age45ActionColor"] = "";
                    datarow["Age60ActionColor"] = "";
                    datarow["Age75ActionColor"] = "";
                    datarow["Age90ActionColor"] = "";
                    datarow["Age105ActionColor"] = "";
                    datarow["Age15Action"] = 1;
                    datarow["Age30Action"] = 3;
                    datarow["Age45Action"] = 3;
                    datarow["Age60Action"] = 2;
                    datarow["Age75Action"] = 2;
                    datarow["Age90Action"] = 4;
                    datarow["Age105Action"] = 5;


                    //datarow("TableVersionId") = defualtTableVersion
                    //datarow("ServRate") = 1
                    //datarow("TypicalInvoiceType") = "Item"


                    //datarow("IsDisable") = ""
                    //grdCompany.Columns["IsDisable"].Visible = false;
                    //grdCompany.Columns["DBadClient"].Visible = false;

                    //datarow["TableVersionId"] = 0;
                    //datarow["TableVersionId"] = "'--Use Default--";

                    //cmbVersionTable.DefaultCellStyle.NullValue = "--Use Default--";

                    datarow["TypicalInvoiceType"] = "Item";


                    CompanyDt.Rows.Add(datarow);
                    grdCompany.DataSource = CompanyDt;
                    grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyName"];
                    grdCompany.Rows[grdCompany.Rows.Count - 1].Selected = true;
                    grdCompany.Rows[grdCompany.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                    grdCompany.Rows[grdCompany.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;

                    

                    //grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].se

                    //cmbVersionTable.Selected = true;

                    //grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Selected = True                    
                }
                else
                {
                    InsertCompany();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAddContacts_Click(System.Object sender, System.EventArgs e)
        {
            if (btnAddCompany.Text != "Insert")
            {
                KryptonMessageBox.Show("First Save Company infomation", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (btnAddContacts.Text == "Insert")
            {
                for (Int32 i = 0; i < grvContacts.Rows.Count; i++)
                {
                    if (grvContacts.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                    {
                        KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                btnAddContacts.Text = "Save";
                btnDeleteContacts.Enabled = false;
                DataTable ContactDT = new DataTable();

                //ContactDT = Program.ToDataTable<CompanyData>((List<CompanyData>)grvContacts.DataSource);

                ContactDT = Program.ToDataTable<CompanyDataEdit>((List<CompanyDataEdit>)grvContacts.DataSource);

                //ContactDT = (DataTable)grvContacts.DataSource;

                //DataRow datarow = CompanyDt.NewRow();
                //int defualtTableVersion = StMethod.GetDefaultTableVersion();


                DataRow datarow = ContactDT.NewRow();
                datarow["CompanyID"] = 0;
                datarow["ContactsID"] = 0;
                datarow["FirstName"] = "";
                datarow["MiddleName"] = "";
                datarow["LastName"] = "";
                datarow["ContactTitle"] = "";
                datarow["MobilePhone"] = "";
                datarow["EmailAddress"] = "";
                datarow["Notes"] = "";
                datarow["SpecialRiggerNUM"] = "";
                datarow["MasterRiggerNUM"] = "";
                datarow["SpecialSignNUM"] = 0;
                datarow["MasterSignNUM"] = 0;
                datarow["Prefix"] = "";
                datarow["Suffix"] = "";
                datarow["Address"] = "";
                datarow["City"] = "";
                datarow["PostalCode"] = "";
                datarow["State"] = "";
                datarow["Country"] = "";
                datarow["HomePhone"] = "";
                datarow["WorkPhone"] = "";
                datarow["FaxNumber"] = "";
                datarow["AlternativePhone"] = "";
                datarow["FieldPhone"] = "";
                datarow["Pager"] = "";
                
                datarow["Accounting"] = false;


                ContactDT.Rows.Add(datarow);
                grvContacts.DataSource = ContactDT;
                grvContacts.CurrentCell = grvContacts.Rows[grvContacts.Rows.Count - 1].Cells["FirstName"];
                grvContacts.Rows[grvContacts.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                grvContacts.Rows[grvContacts.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
            }
            else
            {
               
                InsertContacts();
            }
        }
        private void btnCancelCompany_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                btnDeleteCompany.Enabled = true;
                btnAddCompany.Text = "Insert";
                FillgrdCompany();
                ChangesRows = new List<int>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
        private void btnDeleteCompany_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                int id = 0;
                if (grdCompany.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow SelectedRow in grdCompany.SelectedRows)
                    {
                        id = Convert.ToInt32(SelectedRow.Cells["CompanyID"].Value.ToString());
                    }
                }
                if (id == 0)
                {
                    KryptonMessageBox.Show("Select a row to delete", "Message");
                    return;
                }
                if (KryptonMessageBox.Show("Are you sure you want to delete this record? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {


                        //using (EFDbContext db = new EFDbContext())
                        //{
                        //    db.Database.ExecuteSqlCommand("UPDATE Contacts SET IsDelete=1 where CompanyID=" + id);
                        //    int num = db.Database.ExecuteSqlCommand("Update Company SET IsDelete=1 where CompanyID=" + id);
                        //    if (num > 0)
                        //    {
                        //        FillgrdCompany();
                        //        KryptonMessageBox.Show("Record Deleted!", "Contacts");
                        //        StMethod.LoginActivityInfo(db, "Delete", this.Name);
                        //    }
                        //}


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            
                            using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                            {
                                db2.Database.ExecuteSqlCommand("UPDATE Contacts SET IsDelete=1 where CompanyID=" + id);
                                int num = db2.Database.ExecuteSqlCommand("Update Company SET IsDelete=1 where CompanyID=" + id);
                                if (num > 0)
                                {
                                    FillgrdCompany();
                                    KryptonMessageBox.Show("Record Deleted!", "Contacts");
                                    //StMethod.LoginActivityInfo(db, "Delete", this.Name);
                                    StMethod.LoginActivityInfoNew(db2, "Delete", this.Name);
                                }
                            }
                        }
                        else
                        {
                            using (EFDbContext db = new EFDbContext())
                            {
                                db.Database.ExecuteSqlCommand("UPDATE Contacts SET IsDelete=1 where CompanyID=" + id);
                                int num = db.Database.ExecuteSqlCommand("Update Company SET IsDelete=1 where CompanyID=" + id);
                                if (num > 0)
                                {
                                    FillgrdCompany();
                                    KryptonMessageBox.Show("Record Deleted!", "Contacts");
                                    StMethod.LoginActivityInfo(db, "Delete", this.Name);
                                }
                            }
                        }



                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Contacts");
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Contacts");
            }
        }

        private void btnDeleteContacts_Click(System.Object sender, System.EventArgs e)
        {
            try
            {


                int id = 0;
                if (grvContacts.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow SelectedRow in grvContacts.SelectedRows)
                    {
                        id = Convert.ToInt32(SelectedRow.Cells["ContactsID"].Value.ToString());

                    }
                }
                if (id == 0)
                {
                    KryptonMessageBox.Show("Select a row to delete", "Message");
                    return;
                }
                if (KryptonMessageBox.Show("Are you sure you want to delete this record? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        //using (EFDbContext db = new EFDbContext())
                        //{
                        //    int num = db.Database.ExecuteSqlCommand("Update Contacts Set IsDelete=1 where ContactsID=" + id);
                        //    if (num > 0)
                        //    {
                        //        FillGrdContacts();
                        //        KryptonMessageBox.Show("Record Deleted!", "Contacts");
                        //        StMethod.LoginActivityInfo(db, "Delete", this.Name);
                        //    }
                        //}

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            
                            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            {
                                int num = db.Database.ExecuteSqlCommand("Update Contacts Set IsDelete=1 where ContactsID=" + id);
                                if (num > 0)
                                {
                                    FillGrdContacts();
                                    KryptonMessageBox.Show("Record Deleted!", "Contacts");
                                    //StMethod.LoginActivityInfo(db, "Delete", this.Name);
                                    StMethod.LoginActivityInfoNew(db, "Delete", this.Name);
                                }
                            }
                        }
                        else
                        {
                            using (EFDbContext db = new EFDbContext())
                            {
                                int num = db.Database.ExecuteSqlCommand("Update Contacts Set IsDelete=1 where ContactsID=" + id);
                                if (num > 0)
                                {
                                    FillGrdContacts();
                                    KryptonMessageBox.Show("Record Deleted!", "Contacts");
                                    StMethod.LoginActivityInfo(db, "Delete", this.Name);
                                }
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        KryptonMessageBox.Show(ex.Message, "Contacts");
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Contacts");
            }
        }
        private void btnCancelContacts_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                btnDeleteContacts.Enabled = true;
                btnAddContacts.Text = "Insert";
                FillGrdContacts();

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Contacts");
            }

        }
        private void txtCompanyName_TextChanged(System.Object sender, System.EventArgs e)
        {
            //if (CompanyLoad)
            FillgrdCompany();
        }
        private void txtFirstName_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (rdbSearchInContact.Checked)
            {
                FillGrdContacts();
            }
            if (rdbSearchInCompany.Checked)
            {
                FillgrdCompany();
            }
        }
        private void grdCompany_RowHeaderMouseClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (grdCompany.Rows.Count > 0)
                {
                    selectedCompanyID = Convert.ToInt32(grdCompany.Rows[e.RowIndex].Cells["CompanyID"].Value);
                    // grdCompany.Rows[0].Selected = True
                }
                else
                {
                    selectedCompanyID = 0;
                }
                FillGrdContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdCompany_KeyDown(System.Object sender, System.Windows.Forms.KeyEventArgs e)
        {
            try
            {
                selectedCompanyID = Convert.ToInt32(grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["CompanyID"].Value);
                if (e.KeyCode == Keys.Up)
                {
                    if (grvContacts.CurrentRow.Index != 0)
                    {
                        selectedCompanyID = Convert.ToInt32(grvContacts.Rows[grvContacts.CurrentRow.Index - 1].Cells["CompanyID"].Value);
                    }
                }
                if (e.KeyCode == Keys.Down)
                {
                    if (grvContacts.CurrentRow.Index != grvContacts.Rows.Count - 1)
                    {
                        selectedCompanyID = Convert.ToInt32(grvContacts.Rows[grvContacts.CurrentRow.Index + 1].Cells["CompanyID"].Value);
                    }
                }
                FillGrdContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdCompany_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (rdbSearchInCompany.Checked == false)
            {
                txtFirstName.Text = string.Empty;
                txtLastName.Text = string.Empty;
            }
            if (e.ColumnIndex == -1 && e.RowIndex == 0)
            {
                return;
            }

            
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    //Attempt to update the datasource.
                    int cnt = e.RowIndex;
                    if (Convert.ToInt32(grdCompany.Rows[cnt].Cells["CompanyID"].Value.ToString()) == 0)
                    {
                        InsertCompany();
                        return;
                    }
                    if (string.IsNullOrEmpty(grdCompany.Rows[e.RowIndex].Cells["CompanyName"].EditedFormattedValue.ToString()))
                    {
                        KryptonMessageBox.Show("Please enter Company Name ", "Contacts");
                        grdCompany.CurrentCell = grdCompany.Rows[e.RowIndex].Cells["CompanyName"];
                        return;
                    }


                    //foreach (DataGridViewRow row in grdCompany.Rows)
                    //{
                    //    for (int i = 0; i < grdCompany.Columns.Count; i++)
                    //    {
                    //        String header = grdCompany.Columns[i].HeaderText;
                    //        MessageBox.Show(header);
                    //    }
                    //}

                    //TableVersionId
                    if (string.IsNullOrEmpty(grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) || grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString() == "0")
                    {
                        KryptonMessageBox.Show("Please enter Item Rate ", "Contacts");
                        //grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["TableVersionId")
                        return;
                    }


                    if (string.IsNullOrEmpty(grdCompany.Rows[e.RowIndex].Cells["ServRate"].EditedFormattedValue.ToString()) || !NumericHelper.IsNumeric(grdCompany.Rows[e.RowIndex].Cells["ServRate"].EditedFormattedValue.ToString()))
                    {
                        KryptonMessageBox.Show("Please enter Service Rate ", "Contacts");
                        grdCompany.CurrentCell = grdCompany.Rows[e.RowIndex].Cells["ServRate"];
                        return;
                    }
                    if (string.IsNullOrEmpty(grdCompany.Rows[e.RowIndex].Cells["TypicalInvoiceType"].EditedFormattedValue.ToString()))
                    {
                        KryptonMessageBox.Show("Please enter Invoice Type", "Contacts");
                        //grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["TypicalInvoiceType")
                        return;
                    }
                    btnAddCompany.Text = "Insert";
                    btnDeleteCompany.Enabled = true;
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update  Company set CompanyName= @CompanyName,Address=@Address,City=@City,State= @State,Country=@Country, PostalCode=@PostalCode,DotInsuranceExp=@DotInsuranceExp , AirborneExpNUM=@AirborneExpNUM,IBMNUM= @IBMNUM,FedExNUM= @FedExNUM, OfficePhone=@OfficePhone, OfficeFax= @OfficeFax, IsChange=@IsChange,ChangeDate=@ChangeDate,UserName=@UserName,PassWord=@PassWord,Age0Action = @A0A, Age15Action=@A15A,Age30Action=@A30A,Age45Action=@A45A,Age60Action=@A60A,Age75Action=@A75A,Age90Action=@A90A,Age105Action=@A105A, DBadClient = @DBadClient, CreditPassDate = @CreditPassDate, IsCreditPass = @IsCreditPass, TableVersionId= @TableVersionId,ServRate=@ServRate,TypicalInvoiceType=@TypicalInvoiceType where   CompanyID=  @CompanyID");
                        List<SqlParameter> Param = new List<SqlParameter>();
                            Param.Add(new SqlParameter("@IsChange", 1));
                            Param.Add(new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")));
                        Param.Add(new SqlParameter("@CompanyID", grdCompany.Rows[cnt].Cells["CompanyID"].Value.ToString()));
                            Param.Add(new SqlParameter("@CompanyName", grdCompany.Rows[cnt].Cells["CompanyName"].Value.ToString()));
                            Param.Add(new SqlParameter("@Address", grdCompany.Rows[cnt].Cells["Address"].Value.ToString()));
                            Param.Add(new SqlParameter("@City", grdCompany.Rows[cnt].Cells["City"].Value.ToString()));
                            Param.Add(new SqlParameter("@State", grdCompany.Rows[cnt].Cells["State"].Value.ToString()));
                            Param.Add(new SqlParameter("@OfficePhone", grdCompany.Rows[cnt].Cells["OfficePhone"].Value.ToString()));
                            Param.Add(new SqlParameter("@OfficeFax", grdCompany.Rows[cnt].Cells["OfficeFax"].Value.ToString()));
                            Param.Add(new SqlParameter("@Country", grdCompany.Rows[cnt].Cells["Country"].Value.ToString()));
                            Param.Add(new SqlParameter("@PostalCode", grdCompany.Rows[cnt].Cells["PostalCode"].Value.ToString()));
                            Param.Add(new SqlParameter("@UserName", grdCompany.Rows[cnt].Cells["UserNaME"].Value.ToString()));
                            Param.Add(new SqlParameter("@PassWord", grdCompany.Rows[cnt].Cells["PassWord"].Value.ToString()));
                            Param.Add(new SqlParameter("@DotInsuranceExp", grdCompany.Rows[cnt].Cells["DotInsuranceExp"].Value.ToString()));
                            Param.Add(new SqlParameter("@AirborneExpNUM", grdCompany.Rows[cnt].Cells["AirborneExpNUM"].Value.ToString()));
                            Param.Add(new SqlParameter("@IBMNUM", grdCompany.Rows[cnt].Cells["IBMNUM"].Value.ToString()));
                            Param.Add(new SqlParameter("@FedExNUM", grdCompany.Rows[cnt].Cells["FedExNUM"].Value.ToString()));

                        //Param.Add(new SqlParameter("@A0A", NullToValue(grdCompany.Rows[cnt].Cells["Age0Action"].Value)));
                        //Param.Add(new SqlParameter("@A15A", NullToValue(grdCompany.Rows[cnt].Cells["Age15Action"].Value)));
                        //Param.Add(new SqlParameter("@A30A", NullToValue(grdCompany.Rows[cnt].Cells["Age30Action"].Value)));
                        //Param.Add(new SqlParameter("@A45A", NullToValue(grdCompany.Rows[cnt].Cells["Age45Action"].Value)));
                        //Param.Add(new SqlParameter("@A60A", NullToValue(grdCompany.Rows[cnt].Cells["Age60Action"].Value)));
                        //Param.Add(new SqlParameter("@A75A", NullToValue(grdCompany.Rows[cnt].Cells["Age75Action"].Value)));
                        //Param.Add(new SqlParameter("@A90A", NullToValue(grdCompany.Rows[cnt].Cells["Age90Action"].Value)));
                        //Param.Add(new SqlParameter("@A105A", NullToValue(grdCompany.Rows[cnt].Cells["Age105Action"].Value)));

                        //,Age0Action = @A0A, Age15Action = @A15A,Age30Action = @A30A,Age45Action = @A45A,Age60Action = @A60A,Age75Action = @A75A,Age90Action = @A90A,Age105Action = @A105A, DBadClient = @DBadClient, CreditPassDate = @CreditPassDate, IsCreditPass = @IsCreditPass, TableVersionId = @TableVersionId,ServRate = @ServRate,TypicalInvoiceType = @TypicalInvoiceType where CompanyID = @CompanyID");

                            Param.Add(new SqlParameter("@A0A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age0Action"].Value)));

                            Param.Add(new SqlParameter("@A15A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age15Action"].Value)));
                            Param.Add(new SqlParameter("@A30A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age30Action"].Value)));
                            Param.Add(new SqlParameter("@A45A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age45Action"].Value)));
                            Param.Add(new SqlParameter("@A60A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age60Action"].Value)));
                            Param.Add(new SqlParameter("@A75A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age75Action"].Value)));
                            Param.Add(new SqlParameter("@A90A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age90Action"].Value)));
                            Param.Add(new SqlParameter("@A105A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age105Action"].Value)));

                        //ColumnDBadClient

                            Param.Add(new SqlParameter("@DBadClient", grdCompany.Rows[cnt].Cells["ColumnDBadClient"].Value));


                        int UpdateTableVersionId=0;

                        if (string.IsNullOrEmpty(grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) || grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString() == "0")
                        {                            
                            return;
                        }
                        else
                        {
                            //UpdateTableVersionId = int.Parse(grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString());

                            string check = grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["cmbVersionTable"].Value.ToString();

                            UpdateTableVersionId = int.Parse(grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["cmbVersionTable"].Value.ToString());

                        }


                        //Param.Add(new SqlParameter("@TableVersionId", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["TableVersionId"].Value));

                        Param.Add(new SqlParameter("@TableVersionId", UpdateTableVersionId));


                        Param.Add(new SqlParameter("@ServRate", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["ServRate"].Value));
                        Param.Add(new SqlParameter("@TypicalInvoiceType", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["TypicalInvoiceType"].Value));
                        //.Rows[cnt].Cells["TableVersionId"].Value))
                        //grdTrackitem.Rows["TrackSet", grdTrackitem.CurrentRow.Index].Value.ToString)

                        //MessageBox.Show(" Start ");

                        if (!Convert.IsDBNull(grdCompany.Rows[cnt].Cells["CreditPassDate"].Value))
                        {

                            if ((Convert.ToDateTime(grdCompany.Rows[cnt].Cells["CreditPassDate"].Value).ToString("M/d/yyyy")) == "1/1/1900")
                            {
                                //Param.Add(new SqlParameter("@IsCreditPass", 0));
                                Param.Add(new SqlParameter("@IsCreditPass", false.ToString()));
                            }
                            else
                            {
                                //Param.Add(new SqlParameter("@IsCreditPass", 1));
                                Param.Add(new SqlParameter("@IsCreditPass", true.ToString()));
                            }
                            Param.Add(new SqlParameter("@CreditPassDate", grdCompany.Rows[cnt].Cells["CreditPassDate"].Value));
                        }
                        else
                        {
                            //Param.Add(new SqlParameter("@IsCreditPass", 0));
                            Param.Add(new SqlParameter("@IsCreditPass", false.ToString()));
                            Param.Add(new SqlParameter("@CreditPassDate", "1/1/1900"));
                        }

                        //if (!Convert.IsDBNull(grdCompany.Rows[cnt].Cells["CreditPassDate"].Value))
                        //{
                        //    if ((grdCompany.Rows[cnt].Cells["CreditPassDate"].Value) == "1/1/1990")
                        //    {
                        //        Param.Add(new SqlParameter("@IsCreditPass", false.ToString()));
                        //        Param.Add(new SqlParameter("@CreditPassDate", "1/1/1900"));
                        //    }
                        //    else
                        //    {
                        //        Param.Add(new SqlParameter("@IsCreditPass", true.ToString()));
                        //        Param.Add(new SqlParameter("@CreditPassDate", grdCompany.Rows[cnt].Cells["CreditPassDate"].Value));
                        //    }
                        //}
                        //else
                        //{
                        //    Param.Add(new SqlParameter("@IsCreditPass", false.ToString()));
                        //    Param.Add(new SqlParameter("@CreditPassDate", "1/1/1900"));
                        //}

                        //MessageBox.Show(" End ");


                        //using (EFDbContext db = new EFDbContext())
                        //{
                        //    if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                        //    {
                        //        KryptonMessageBox.Show("Update Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        StMethod.LoginActivityInfo(db, "Update", this.Text);
                        //        grdCompany.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        //        grdCompany.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                        //        int colScroll = grdCompany.FirstDisplayedScrollingColumnIndex;
                        //        int rowScroll = grdCompany.FirstDisplayedScrollingRowIndex;
                        //        FillgrdCompany();
                        //        grdCompany.FirstDisplayedScrollingColumnIndex = colScroll;
                        //        grdCompany.FirstDisplayedScrollingRowIndex = rowScroll;
                        //    }
                        //}


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            
                            using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                            {
                                if (db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                                {
                                    KryptonMessageBox.Show("Update Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //StMethod.LoginActivityInfo(db2, "Update", this.Text);
                                    
                                    StMethod.LoginActivityInfoNew(db2, "Update", this.Text);

                                    grdCompany.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                    grdCompany.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                    int colScroll = grdCompany.FirstDisplayedScrollingColumnIndex;
                                    int rowScroll = grdCompany.FirstDisplayedScrollingRowIndex;
                                    FillgrdCompany();
                                    grdCompany.FirstDisplayedScrollingColumnIndex = colScroll;
                                    grdCompany.FirstDisplayedScrollingRowIndex = rowScroll;
                                }
                            }
                        }
                        else
                        {
                            using (EFDbContext db = new EFDbContext())
                            {
                                if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                                {
                                    KryptonMessageBox.Show("Update Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    StMethod.LoginActivityInfo(db, "Update", this.Text);
                                    grdCompany.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                    grdCompany.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                    int colScroll = grdCompany.FirstDisplayedScrollingColumnIndex;
                                    int rowScroll = grdCompany.FirstDisplayedScrollingRowIndex;
                                    FillgrdCompany();
                                    grdCompany.FirstDisplayedScrollingColumnIndex = colScroll;
                                    grdCompany.FirstDisplayedScrollingRowIndex = rowScroll;
                                }
                            }
                        }


                    }
                    catch (System.Exception eLoad)
                    {
                        //Add your error handling code here.
                        //Display error message, if any.
                        KryptonMessageBox.Show(eLoad.Message, "Contacts");
                    }
                    grdCompany.CurrentCell = grdCompany.Rows[cnt].Cells["CompanyName"];
                    grdCompany.Rows[cnt].Selected = true;
                }
                catch (System.Exception eUpdate)
                {
                    MessageBox.Show(eUpdate.Message.ToString());
                }
            }
            if (e.ColumnIndex == 30 && e.RowIndex > -1)
            {
                //ColumnDisableForWeb
                //if (Convert.ToBoolean(grdCompany.Rows[e.RowIndex].Cells["IsDisable"].EditedFormattedValue) == false)

                if (Convert.ToBoolean(grdCompany.Rows[e.RowIndex].Cells["ColumnDisableForWeb"].EditedFormattedValue) == false)
                {
                    DisableUser(e.RowIndex);
                }
                else
                {
                    EnableUser(e.RowIndex);
                }
            }
            selectedCompanyID = NullToValue(grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value);
        }
        private int NullToValue(object obj)
        {
            if (obj is null)
                return 0;
            else
                return Convert.ToInt32(obj);
        }

        private int NullToValueSecond(object obj)
        {
           
            if (obj is null || obj is DBNull)
                return 0;
            else
                return Convert.ToInt32(obj);                           
        }


        private void grvContacts_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(e.ColumnIndex.ToString());

            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    //Attempt to update the datasource.
                    int cnt = e.RowIndex;
                    if (Convert.ToInt32(grvContacts.Rows[cnt].Cells["ContactsID"].Value.ToString()) == 0)
                    {
                        InsertContacts();
                        return;
                    }
                    btnAddContacts.Text = "Insert";
                    btnDeleteContacts.Enabled = true;
                    try
                    {
                        SqlCommand cmd = new SqlCommand("update  Contacts set FirstName= @FirstName,MiddleName=@MiddleName,LastName=@LastName,ContactTitle= @ContactTitle,MobilePhone=@MobilePhone, EmailAddress=@EmailAddress,Notes=@Notes,SpecialRiggerNUM=@SpecialRiggerNUM , MasterRiggerNUM=@MasterRiggerNUM,SpecialSignNUM= @SpecialSignNUM,MasterSignNUM=@MasterSignNUM,Prefix=@Prefix,Suffix=@Suffix,Address=@Address,City=@City,PostalCode=@PostalCode,State=@State,Country=@Country,HomePhone=@HomePhone,WorkPhone=@WorkPhone,FaxNumber=@FaxNumber,AlternativePhone=@AlternativePhone,FieldPhone=@FieldPhone,Pager=@Pager,IsChange=@IsChange,ChangeDate=@ChangeDate ,Accounting=@AC where   ContactsID=@ContactsID");
                        List<SqlParameter> Param = new List<SqlParameter>();
                        Param.Add(new SqlParameter("@IsChange", 1));
                        Param.Add(new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")));
                        Param.Add(new SqlParameter("@ContactsID", grvContacts.Rows[cnt].Cells["ContactsID"].Value.ToString()));
                        Param.Add(new SqlParameter("@FirstName", grvContacts.Rows[cnt].Cells["FirstName"].Value.ToString()));
                        Param.Add(new SqlParameter("@MiddleName", grvContacts.Rows[cnt].Cells["MiddleName"].Value.ToString()));
                        Param.Add(new SqlParameter("@LastName", grvContacts.Rows[cnt].Cells["LastName"].Value.ToString()));
                        Param.Add(new SqlParameter("@ContactTitle", grvContacts.Rows[cnt].Cells["ContactTitle"].Value.ToString()));
                        Param.Add(new SqlParameter("@MobilePhone", grvContacts.Rows[cnt].Cells["MobilePhone"].Value.ToString()));
                        Param.Add(new SqlParameter("@EmailAddress", grvContacts.Rows[cnt].Cells["EmailAddress"].Value.ToString()));
                        Param.Add(new SqlParameter("@Notes", grvContacts.Rows[cnt].Cells["Notes"].Value.ToString()));
                        Param.Add(new SqlParameter("@SpecialRiggerNUM", grvContacts.Rows[cnt].Cells["SpecialRiggerNUM"].Value.ToString()));
                        Param.Add(new SqlParameter("@MasterRiggerNUM", grvContacts.Rows[cnt].Cells["MasterRiggerNUM"].Value.ToString()));
                        Param.Add(new SqlParameter("@SpecialSignNUM", grvContacts.Rows[cnt].Cells["SpecialSignNUM"].Value.ToString()));
                        Param.Add(new SqlParameter("@MasterSignNUM", grvContacts.Rows[cnt].Cells["MasterSignNUM"].Value.ToString()));
                        Param.Add(new SqlParameter("@Prefix", grvContacts.Rows[cnt].Cells["Prefix"].Value.ToString()));
                        Param.Add(new SqlParameter("@Suffix", grvContacts.Rows[cnt].Cells["Suffix"].Value.ToString()));
                        Param.Add(new SqlParameter("@Address", grvContacts.Rows[cnt].Cells["Address"].Value.ToString()));
                        Param.Add(new SqlParameter("@City", grvContacts.Rows[cnt].Cells["City"].Value.ToString()));
                        Param.Add(new SqlParameter("@PostalCode", grvContacts.Rows[cnt].Cells["PostalCode"].Value.ToString()));
                        Param.Add(new SqlParameter("@State", grvContacts.Rows[cnt].Cells["State"].Value.ToString()));
                        Param.Add(new SqlParameter("@Country", grvContacts.Rows[cnt].Cells["Country"].Value.ToString()));
                        Param.Add(new SqlParameter("@HomePhone", grvContacts.Rows[cnt].Cells["HomePhone"].Value.ToString()));
                        Param.Add(new SqlParameter("@WorkPhone", grvContacts.Rows[cnt].Cells["WorkPhone"].Value.ToString()));
                        Param.Add(new SqlParameter("@FaxNumber", grvContacts.Rows[cnt].Cells["FaxNumber"].Value.ToString()));
                        Param.Add(new SqlParameter("@AlternativePhone", grvContacts.Rows[cnt].Cells["AlternativePhone"].Value.ToString()));
                        Param.Add(new SqlParameter("@FieldPhone", grvContacts.Rows[cnt].Cells["FieldPhone"].Value.ToString()));
                        Param.Add(new SqlParameter("@Pager", grvContacts.Rows[cnt].Cells["Pager"].Value.ToString()));



                        //if (string.IsNullOrEmpty(grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) || grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString() == "0")
                        //{
                        //    return;
                        //}
                        //else
                        //{
                        //    //UpdateTableVersionId = int.Parse(grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString());

                        //    string check = grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["cmbVersionTable"].Value.ToString();

                        //    UpdateTableVersionId = int.Parse(grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["cmbVersionTable"].Value.ToString());

                        //}


                        //Param.Add(new SqlParameter("@AC", grvContacts.Rows[cnt].Cells["Accounting"].EditedFormattedValue.ToString()));
                        Param.Add(new SqlParameter("@AC", grvContacts.Rows[cnt].Cells["ColumnDAC"].EditedFormattedValue.ToString()));
                        


                        //using (EFDbContext db = new EFDbContext())
                        //{
                        //    if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                        //    {
                        //        KryptonMessageBox.Show("Update Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        grvContacts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        //        grvContacts.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                        //    }
                        //}


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            
                            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            {
                                if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                                {
                                    KryptonMessageBox.Show("Update Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grvContacts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                    grvContacts.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                }
                            }

                        }
                        else
                        {

                            using (EFDbContext db = new EFDbContext())
                            {
                                if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                                {
                                    KryptonMessageBox.Show("Update Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grvContacts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                    grvContacts.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                }
                            }

                        }


                    }
                    catch (System.Exception eLoad)
                    {
                        //Add your error handling code here.
                        //Display error message, if any.
                        KryptonMessageBox.Show(eLoad.Message, "Contacts");
                    }
                    //FillGrdContacts()
                    //If grvContacts.Rows.Count > 0 Then
                    grvContacts.CurrentCell = grvContacts.Rows[cnt].Cells["FirstName"];
                    grvContacts.Rows[cnt].Selected = true;
                    // End If
                    // System.Windows.Forms.MessageBox.Show("Record Updated!", "Message")
                }
                catch (System.Exception eUpdate)
                {
                    //Add your error handling code here.
                    //Display error message, if any.
                    KryptonMessageBox.Show(eUpdate.Message, "Contacts");
                }
            }
        }
        private void grdCompany_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1 && e.ColumnIndex != 30)
            {
                CheckString = string.Empty;
                if (Convert.ToInt16(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyID"].Value.ToString()) == 0)
                {
                    if (grdCompany.CurrentRow.Index == grdCompany.Rows.Count - 1)
                    {
                        return;
                    }
                    KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(grdCompany.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                {
                    CheckString = grdCompany.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
        }
        private void grvContacts_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.RowIndex > -1)
            {
                CheckString = string.Empty;
                if (Convert.ToInt16(grvContacts.Rows[grvContacts.Rows.Count - 1].Cells["ContactsID"].Value.ToString()) == 0)
                {
                    if (grvContacts.CurrentRow.Index == grvContacts.Rows.Count - 1)
                    {
                        return;
                    }
                    KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (!(grvContacts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null))
                {
                    CheckString = grvContacts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                if (grvContacts.Columns[e.ColumnIndex].Name == "EmailAddress")
                {
                    grvContacts.SelectionMode = DataGridViewSelectionMode.CellSelect;
                }
                else
                {
                    grvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }

            }

        }
        private void grdCompany_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyID"].Value.ToString()) == 0)
                    {
                        return;
                    }
                    if (CheckString != grdCompany.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() && e.ColumnIndex != 30)
                    {
                        grdCompany.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grdCompany.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                        ChangesRows.AddCheck(e.RowIndex);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            if (e.ColumnIndex == 30 && e.RowIndex > -1)
            {
                try
                {
                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    bool bvalue = db.Database.SqlQuery<bool>("Select IsDisable FROM Company WHERE IsNewRecord=1 AND CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString()).FirstOrDefault();
                    //    if (bvalue)
                    //    {
                    //        grdCompany.Rows[e.RowIndex].Cells["IsDisable"].Value = CheckState.Unchecked;
                    //    }
                    //}



                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {                        
                        using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                        {
                            //MessageBox.Show("1");
                            bool bvalue = db2.Database.SqlQuery<bool>("Select IsDisable FROM Company WHERE IsNewRecord=1 AND CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString()).FirstOrDefault();
                            if (bvalue)
                            {
                                grdCompany.Rows[e.RowIndex].Cells["IsDisable"].Value = CheckState.Unchecked;
                            }
                        }
                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            //MessageBox.Show("2");

                            bool bvalue = db.Database.SqlQuery<bool>("Select IsDisable FROM Company WHERE IsNewRecord=1 AND CompanyID=" + grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString()).FirstOrDefault();
                            if (bvalue)
                            {
                                grdCompany.Rows[e.RowIndex].Cells["IsDisable"].Value = CheckState.Unchecked;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        private void grvContacts_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                grvContacts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    if (grvContacts.Rows[e.RowIndex].Cells["EmailAddress"].ColumnIndex == e.ColumnIndex)
                    {
                        if (!string.IsNullOrEmpty(grvContacts.Rows[e.RowIndex].Cells["EmailAddress"].Value.ToString()) && !IsValidEmail(grvContacts.Rows[e.RowIndex].Cells["EmailAddress"].Value.ToString()))
                        {
                            grvContacts.CancelEdit();
                            // grvContacts.Rows["EmailAddress", e.RowIndex].Value = String.Empty
                            KryptonMessageBox.Show("Please Enter Valid Email", "Email Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }

                if (Convert.ToInt16(grvContacts.Rows[grvContacts.Rows.Count - 1].Cells["ContactsID"].Value.ToString()) == 0)
                {
                    return;
                }


                if (CheckString != grvContacts.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                {
                    grvContacts.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    grvContacts.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                    CheckString = string.Empty;
                }

                //End If

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdCompany_CellEnter(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdCompany.Rows.Count > 0)
                {
                    selectedCompanyID = Convert.ToInt32(grdCompany.Rows[e.RowIndex].Cells["CompanyID"].Value);
                    // grdCompany.Rows[0].Selected = True
                }
                else
                {
                    selectedCompanyID = 0;
                }
                FillGrdContacts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void txtCompanyName_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (grdCompany.Rows.Count == 0)
                {
                    if ((int)(e.KeyChar) == 13 || (int)(e.KeyChar) == 8)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void txtFirstName_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (grvContacts.Rows.Count == 0)
                {
                    if ((int)(e.KeyChar) == 13 || (int)(e.KeyChar) == 8)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdCompany_CellFormatting(System.Object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (chkboxPassword.Checked == true || chkboxPassword.CheckState == CheckState.Checked)
                {
                    return;
                }
                if (e.ColumnIndex == 13)
                {
                    e.Value = new string('*', e.Value.ToString().Length);
                }
                //If (e.ColumnIndex = 21 Or e.ColumnIndex = 22 Or e.ColumnIndex = 23 Or e.ColumnIndex = 24 Or e.ColumnIndex = 25 Or e.ColumnIndex = 26 Or e.ColumnIndex = 27) And (e.RowIndex > -1) Then
                //    If grdCompany.Rows[e.RowIndex].Cells[e.ColumnIndex - 7].Value = 1 Then
                //        grdCompany.Rows[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Green
                //    End If
                //    If grdCompany.Rows[e.RowIndex].Cells[e.ColumnIndex - 7].Value = 2 Then
                //        grdCompany.Rows[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Orange
                //    End If
                //    If grdCompany.Rows[e.RowIndex].Cells[e.ColumnIndex - 7].Value = 3 Then
                //        grdCompany.Rows[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Yellow
                //    End If
                //    If grdCompany.Rows[e.RowIndex].Cells[e.ColumnIndex - 7].Value = 4 Then
                //        grdCompany.Rows[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red
                //    End If
                //End If

                if (e.ColumnIndex == 33)
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
                }
            catch (Exception ex)
            {
                //throw;
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdCompany_EditingControlShowing(System.Object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
        {
            //If e.Control Is DataGridViewComboBoxEditingControl Then
            //    Return
            //Else
            int i = grdCompany.CurrentCell.ColumnIndex;
            if (i == 32)
            {
                if (chkboxPassword.Checked == true || chkboxPassword.CheckState == CheckState.Checked)
                {
                    return;
                }
                TextBox ContactPassWord = (TextBox)e.Control;
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 13)
                {
                    ContactPassWord.KeyPress += ContactPassWord_KeyPress;
                    ContactPassWord.PasswordChar = '*';
                }
                else
                {
                    ContactPassWord.PasswordChar = char.MinValue;
                }
                TextBox ContctUserName = (TextBox)e.Control;
                if (((DataGridView)sender).CurrentCell.ColumnIndex == 12)
                {
                    ContactPassWord.KeyPress += ContactPassWord_KeyPress;
                }
            }
            //End If
            //If CType(sender, DataGridView).CurrentCell.ColumnIndex = 13 Then
            //    Dim dAL As New DataAccessLayer
            //    If dAL.Filldatatable("Select IsDisable FROM Company WHERE IsNewRecord=1 AND CompanyID=" & grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["CompanyID"].Value.ToString).Rows.Count > 0 Then
            //        grdCompany.Rows["IsDisable", e.RowIndex].Value = CheckState.Unchecked
            //    End If
            //End If
        }
        private void BlackToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            ChangeColourAction(5, Color.Black);
            grdCompany.EndEdit();
        }

        public void ExportPassword()
        {
            try
            {


                SaveFileDialog ExportPassword = new SaveFileDialog();
                //ExportPassword.Filter = "Excel Format|*.xlsx";
                ExportPassword.Filter = "Excel Format|*.xls";
                ExportPassword.Title = "Export Password";
                //ExportPassword.InitialDirectory = "N:";
                ExportPassword.FilterIndex = 2;

                string ExportPath = @"N:\";

                if(Directory.Exists(ExportPath))
                {
                    ExportPassword.InitialDirectory = @"N:\";
                }
                else
                {
                    ExportPassword.InitialDirectory = @"C:\";

                }

                //'Export.InitialDirectory = "N:"
                if (ExportPassword.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }


                string FullFilePath = ExportPassword.FileName;
                string filename = Path.GetFileName(ExportPassword.FileName);
                string filePath = ExportPassword.FileName;

                //Dim workBook As New XSSFWorkbook()
                ISheet sheet1 = workBook.CreateSheet(filename);


                //sheet cell Formatting
                //--------------------------------------------------------
                //XSSFFont myFont = (XSSFFont)workBook.CreateFont();

                HSSFFont myFont = (HSSFFont)workBook.CreateFont();
                myFont.FontHeightInPoints = 11;
                myFont.FontName = "Tahoma";
                myFont.IsBold = true;


                HSSFCellStyle borderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();
                borderedCellStyle.SetFont(myFont);

                borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;


                Int32 Sheetrowindex = 0;
                int percent = 0;


                //DataTable ContactMainGrid = GetContactData();
                //MainDataTable = GetContactData();

                //MessageBox.Show(MainDataTable.Rows.Count.ToString());



                //MainDataTable = StMethod.GetListDT<UserPassowrds>("SELECT CompanyName, UserName,Password FROM Company ORDER BY CompanyName");


                

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    MainDataTable = StMethod.GetListDTNew<UserPassowrdsSecond>("SELECT CompanyName, UserName,Password FROM Company ORDER BY CompanyName");

                }
                else
                {
                    MainDataTable = StMethod.GetListDT<UserPassowrdsSecond>("SELECT CompanyName, UserName,Password FROM Company ORDER BY CompanyName");
                }

                //private void CreateCell(IRow CurrentRow, int CellIndex, string Value, XSSFCellStyle Style)

                //foreach (DataColumn header in MainDataTable.Columns)
                //{
                //    //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                //    CreateCell(SheetR0w3, ColumnIndex3, header.ColumnName, borderedCellStyle);
                //    ColumnIndex3 = ColumnIndex3 + 1;
                //}

                //sheetRow = sheet.CreateRow(sheetRowIndex);
                //ColumnIndex = 0;

                //foreach (DataColumn header in dt.Columns)
                //{
                //    string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();
                //    sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                //    ColumnIndex = ColumnIndex + 1;
                //}



                var sheetRow21 = sheet1.CreateRow(0);

                HSSFFont myFont21 = (HSSFFont)workBook.CreateFont();
                myFont21.FontHeightInPoints = 11;
                myFont21.FontName = "Tahoma";
                myFont21.IsBold = true;
                myFont21.Color = IndexedColors.Blue.Index;


                HSSFCellStyle HeaderBorderedCellStyle21 = (HSSFCellStyle)workBook.CreateCellStyle();
                HeaderBorderedCellStyle21.SetFont(myFont21);

                HeaderBorderedCellStyle21.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                HeaderBorderedCellStyle21.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                HeaderBorderedCellStyle21.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                HeaderBorderedCellStyle21.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                HeaderBorderedCellStyle21.VerticalAlignment = VerticalAlignment.Center;

                ICell Cell1 = sheetRow21.CreateCell(0);
                Cell1.SetCellValue("CompanyName");
                Cell1.CellStyle = HeaderBorderedCellStyle21;

                ICell Cell2 = sheetRow21.CreateCell(1);
                Cell2.SetCellValue("UserID");
                Cell2.CellStyle = HeaderBorderedCellStyle21;

                ICell Cell3 = sheetRow21.CreateCell(2);
                Cell3.SetCellValue("Password");
                Cell3.CellStyle = HeaderBorderedCellStyle21;





                //XSSFFont myFont2 = (XSSFFont)workBook.CreateFont();
                HSSFFont myFont2 = (HSSFFont)workBook.CreateFont();
                myFont2.FontHeightInPoints = 10;
                myFont2.FontName = "Tahoma";

                //XSSFCellStyle HeaderBorderedCellStyle2 = (XSSFCellStyle)workBook.CreateCellStyle();
                HSSFCellStyle HeaderBorderedCellStyle2 = (HSSFCellStyle)workBook.CreateCellStyle();
                HeaderBorderedCellStyle2.SetFont(myFont2);
                HeaderBorderedCellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

                //private object CreateContactPassword(DataTable dt, HSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)


                //XSSFFont myFont2 = (XSSFFont)workBook.CreateFont();
                //myFont2.FontHeightInPoints = 10;
                //myFont2.FontName = "Tahoma";

                //XSSFCellStyle HeaderBorderedCellStyle2 = (XSSFCellStyle)workBook.CreateCellStyle();
                //HeaderBorderedCellStyle2.SetFont(myFont2);
                //HeaderBorderedCellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

                Sheetrowindex = 1;

                for (int ContactRowindex = 1; ContactRowindex <= MainDataTable.Rows.Count; ContactRowindex++)
                {
                    if (ProgressBar1.Value <= MainDataTable.Rows.Count)
                    {
                        CreateContactPassword(MainDataTable, borderedCellStyle, (ContactRowindex - 1),
                            ref Sheetrowindex, ref sheet1, HeaderBorderedCellStyle2);
                    }
                    //percent = (ProgressBar1.Value / ProgressBar1.Maximum) * 100;
                    //Label9.Text = percent + "%" + "Completed";
                    //Label9.Refresh();
                    //ProgressBar1.Value = ProgressBar1.Value + 1;
                    //Sheetrowindex = Sheetrowindex + 1;
                }


                //foreach (System.Data.DataRow dr in dt.Rows)
                //{
                //    rowIndex2 = rowIndex2 + 1;
                //    colIndex2 = 0;
                //    foreach (System.Data.DataColumn dc in dt.Columns)
                //    {
                //        colIndex2 = colIndex2 + 1;
                //        //excel.Cells[rowIndex + 1, colIndex] = dr[dc.ColumnName];
                //        //MessageBox.Show(dr[dc.ColumnName].ToString ());

                //        //        Dim columnvalue As String
                //        //columnvalue = dt.Rows(rowindex).Item(ColumnIndex).ToString()

                //        string columnvalue = dr[dc.ColumnName].ToString();

                //        //Excel.Application excel = new Excel.Application();
                //        //Excel.Workbook wBook = null;
                //        //Excel.Worksheet wSheet = null;

                //        IRow SheetRow11 = Isheet2.CreateRow(rowIndex+1);
                //        ICell Cell11 = SheetRow.CreateCell(colIndex2);

                //        //MessageBox.Show(columnvalue);

                //        //Cell11.SetCellValue(columnvalue);


                //        //IRow SheetRow = Isheet2.CreateRow(1);
                //        //ICell Cell5 = SheetRow.CreateCell(1);
                //        //ICell Cell6 = SheetRow.CreateCell(2);
                //        //ICell Cell7 = SheetRow.CreateCell(3);


                //    }
                //}

                ////FileStream fsd = new FileStream(filePath ,FileMode.OpenOrCreate,FileAccess.ReadWrite);
                //FileStream fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                //workBook2.Write(fsd);
                //workBook2.Close();
                //fsd.Close();

                
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
                MessageBox.Show("Export Successfully ", ExportPassword.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void btnExportPassword_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                ExportPassword();

                //Excel.Application excel = new Excel.Application();
                //Excel.Workbook wBook = null;
                //Excel.Worksheet wSheet = null;
                //wBook = excel.Workbooks.Add();
                //wSheet = (Excel.Worksheet)wBook.Sheets[1];
                //System.Data.DataTable dt = new System.Data.DataTable();

                ////dt = StMethod.GetListDT<UserPassowrds>("SELECT CompanyName AS [Company Name], UserName AS [User ID],Password FROM Company ORDER BY CompanyName");
                //dt = StMethod.GetListDT<UserPassowrds>("SELECT CompanyName, UserName,Password FROM Company ORDER BY CompanyName");
                ////			Dim dc As System.Data.DataColumn
                ////			Dim dr As System.Data.DataRow
                //int colIndex = 0;
                //int rowIndex = 0;
                //foreach (System.Data.DataColumn dc in dt.Columns)
                //{
                //    colIndex = colIndex + 1;
                //    excel.Cells[1, colIndex] = dc.ColumnName;
                //}
                //wSheet.Columns.Range["A1:C1"].Font.Bold = true;
                //wSheet.Columns.Range["A1:C1"].Font.Color = Color.RoyalBlue;
                ////wSheet.Columns.Range["A1:C1").Worksheet.
                ////wSheet.Rows.Range["A1:C1").
                //foreach (System.Data.DataRow dr in dt.Rows)
                //{
                //    rowIndex = rowIndex + 1;
                //    colIndex = 0;
                //    foreach (System.Data.DataColumn dc in dt.Columns)
                //    {
                //        colIndex = colIndex + 1;
                //        excel.Cells[rowIndex + 1, colIndex] = dr[dc.ColumnName];

                //    }
                //}

                //wSheet.Columns.AutoFit();
                //SaveFileDialog Export = new SaveFileDialog();
                //Export.Filter = "Excel Format|*.xls";
                //Export.Title = "Export Password";
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
                //string Password = "vedataaccess";
                //wSheet.Protect(Password,null,null,null, ROnly);
                //wBook.SaveAs(strFileName);
                //excel.Workbooks.Open(strFileName);
                //excel.Visible = true;

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void cmbWordLetter_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            cmbWordLetter.SelectedItem = "select Data";
            if (cmbWordLetter.SelectedItem == "Word Fax")
            {
                wordFAX();
            }
            else if (cmbWordLetter.SelectedItem == "Word Transmittal")
            {
                //WordTranmittal()
                CryWordTrasmittal();
            }
        }
        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            foreach (Control txtbox in pnlCompanyName.Controls)
            {
                if (txtbox is TextBox)
                {
                    txtbox.Text = string.Empty;
                }
                if (txtbox is TextBox)
                {
                    txtbox.Text = string.Empty;
                }
                if (txtbox is CheckBox)
                {
                    CheckBox chk = (CheckBox)txtbox;
                    chk.Checked = false;
                }
            }
        }
        private void btnClear2_Click(System.Object sender, System.EventArgs e)
        {
            foreach (Control txtbox in pnlContacts.Controls)
            {
                if (txtbox is TextBox)
                {
                    txtbox.Text = string.Empty;
                }
                if (txtbox is TextBox)
                {
                    txtbox.Text = string.Empty;
                }
                if (txtbox is CheckBox)
                {
                    CheckBox chk = (CheckBox)txtbox;
                    chk.Checked = false;
                }
                FillgrdCompany();
                FillGrdContacts();
            }
        }
        private void timerLoad_Tick(System.Object sender, System.EventArgs e)
        {
            if (CompanyLoad)
            {
                FillgrdCompany();
                FillGrdContacts();
                ////AddgrdColumn();
                ////PopulateTypicalInvoiceType();
                ////BindMasterCombo();
                //CompanyLoad = true;
                grdCompany.EditingControlShowing += grdCompany_EditingControlShowing;
                cmbWordLetter.SelectedIndex = 0;
            }
            timerLoad.Stop();
            timerLoad.Enabled = false;
            CompanyLoad = false;
        }
        private void rdbSearchInCompany_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            FillgrdCompany();
        }
        private void txtWorkPhoneSearch_TextChanged(System.Object sender, System.EventArgs e)
        {
            FillGrdContacts();
        }
        private void txtFaxSearch_TextChanged(System.Object sender, System.EventArgs e)
        {
            FillGrdContacts();
        }
        private void BlueToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            ChangeColourAction(6, Color.Blue);
            grdCompany.EndEdit();

        }
        private void btnSetRateMaster_Click(System.Object sender, System.EventArgs e)
        {

            try
            { 
            int value = Convert.ToInt32(cmbMasterRateVersionType.SelectedValue);
            ChangesRows = new List<int>();
            for (int index = 0; index < grdCompany.Rows.Count; index++)
            {
                //DataGridViewCell cell = grdCompany.Rows[index].Cells["TableVersionId"];
                DataGridViewCell cell = grdCompany.Rows[index].Cells["cmbVersionTable"];
                
                cell.Value = value;
                grdCompany.UpdateCellValue(cell.ColumnIndex, cell.RowIndex);
                //Changes row
                ChangesRows.AddCheck(index);
            }
            int sel = grdCompany.CurrentRow.Index;
            grdCompany.Rows[sel].Selected = false;
            grdCompany.Rows[sel].Selected = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void btnSetInvoiceType_Click(System.Object sender, System.EventArgs e)
        {
            string value = cmbMasterInvoiceType.Text;
            ChangesRows = new List<int>();
            for (int index = 0; index < grdCompany.Rows.Count; index++)
            {
                DataGridViewCell cell = grdCompany.Rows[index].Cells["TypicalInvoiceType"];
                cell.Value = value;
                grdCompany.UpdateCellValue(cell.ColumnIndex, cell.RowIndex);
                //Changes row
                ChangesRows.AddCheck(index);
            }
            int sel = grdCompany.CurrentRow.Index;
            grdCompany.Rows[sel].Selected = false;
            grdCompany.Rows[sel].Selected = true;
        }
        private void btnMasterUpdate_Click(System.Object sender, System.EventArgs e)
        {
            if (Convert.ToInt32(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyID"].Value.ToString()) == 0)
            {
                MessageBox.Show("Please insert record first then update", "Company", MessageBoxButtons.OK);
                return;
            }

            //'----------------------------------- Show Message if any record not found for update ----------------------------

            if (ChangesRows.Count == 0)
            {
                MessageBox.Show("No changes found", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //----------------------------------- Update record------------------------------------
            if (MessageBox.Show("Sure to update!", "Contacts", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            try
            {

                foreach (int cnt in ChangesRows)
                {

                    SqlCommand cmd = new SqlCommand("update  Company set CompanyName= @CompanyName,Address=@Address,City=@City,State= @State,Country=@Country, PostalCode=@PostalCode,DotInsuranceExp=@DotInsuranceExp , AirborneExpNUM=@AirborneExpNUM,IBMNUM= @IBMNUM,FedExNUM= @FedExNUM, OfficePhone=@OfficePhone, OfficeFax= @OfficeFax, IsChange=@IsChange,ChangeDate=@ChangeDate,UserName=@UserName,PassWord=@PassWord,Age0Action = @A0A, Age15Action=@A15A,Age30Action=@A30A,Age45Action=@A45A,Age60Action=@A60A,Age75Action=@A75A,Age90Action=@A90A,Age105Action=@A105A, DBadClient = @DBadClient, CreditPassDate = @CreditPassDate, IsCreditPass = @IsCreditPass, TableVersionId= @TableVersionId,ServRate= @ServRate,TypicalInvoiceType=@TypicalInvoiceType where   CompanyID=  @CompanyID");
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 1));
                    Param.Add(new SqlParameter("@ChangeDate", Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy")));
                    Param.Add(new SqlParameter("@CompanyID", grdCompany.Rows[cnt].Cells["CompanyID"].Value.ToString()));
                    Param.Add(new SqlParameter("@CompanyName", grdCompany.Rows[cnt].Cells["CompanyName"].Value.ToString()));
                    Param.Add(new SqlParameter("@Address", grdCompany.Rows[cnt].Cells["Address"].Value.ToString()));
                    Param.Add(new SqlParameter("@City", grdCompany.Rows[cnt].Cells["City"].Value.ToString()));
                    Param.Add(new SqlParameter("@State", grdCompany.Rows[cnt].Cells["State"].Value.ToString()));
                    Param.Add(new SqlParameter("@OfficePhone", grdCompany.Rows[cnt].Cells["OfficePhone"].Value.ToString()));
                    Param.Add(new SqlParameter("@OfficeFax", grdCompany.Rows[cnt].Cells["OfficeFax"].Value.ToString()));

                    Param.Add(new SqlParameter("@Country", grdCompany.Rows[cnt].Cells["Country"].Value.ToString()));
                    Param.Add(new SqlParameter("@PostalCode", grdCompany.Rows[cnt].Cells["PostalCode"].Value.ToString()));
                    Param.Add(new SqlParameter("@UserName", grdCompany.Rows[cnt].Cells["UserNaME"].Value.ToString()));
                    Param.Add(new SqlParameter("@PassWord", grdCompany.Rows[cnt].Cells["PassWord"].Value.ToString()));
                    Param.Add(new SqlParameter("@DotInsuranceExp", grdCompany.Rows[cnt].Cells["DotInsuranceExp"].Value.ToString()));
                    Param.Add(new SqlParameter("@AirborneExpNUM", grdCompany.Rows[cnt].Cells["AirborneExpNUM"].Value.ToString()));
                    Param.Add(new SqlParameter("@IBMNUM", grdCompany.Rows[cnt].Cells["IBMNUM"].Value.ToString()));
                    Param.Add(new SqlParameter("@FedExNUM", grdCompany.Rows[cnt].Cells["FedExNUM"].Value.ToString()));



                    //Param.Add(new SqlParameter("@A0A", grdCompany.Rows[cnt].Cells["Age0Action"].Value.ToString()));
                    //Param.Add(new SqlParameter("@A15A", grdCompany.Rows[cnt].Cells["Age15Action"].Value.ToString()));
                    //Param.Add(new SqlParameter("@A30A", grdCompany.Rows[cnt].Cells["Age30Action"].Value.ToString()));
                    //Param.Add(new SqlParameter("@A45A", grdCompany.Rows[cnt].Cells["Age45Action"].Value.ToString()));
                    //Param.Add(new SqlParameter("@A60A", grdCompany.Rows[cnt].Cells["Age60Action"].Value.ToString()));
                    //Param.Add(new SqlParameter("@A75A", grdCompany.Rows[cnt].Cells["Age75Action"].Value.ToString()));
                    //Param.Add(new SqlParameter("@A90A", grdCompany.Rows[cnt].Cells["Age90Action"].Value.ToString()));
                    //Param.Add(new SqlParameter("@A105A", grdCompany.Rows[cnt].Cells["Age105Action"].Value.ToString()));
                    //Param.Add(new SqlParameter("@DBadClient", grdCompany.Rows[cnt].Cells["DBadClient"].Value));




                    Param.Add(new SqlParameter("@A0A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age0Action"].Value)));

                    Param.Add(new SqlParameter("@A15A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age15Action"].Value)));
                    Param.Add(new SqlParameter("@A30A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age30Action"].Value)));
                    Param.Add(new SqlParameter("@A45A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age45Action"].Value)));
                    Param.Add(new SqlParameter("@A60A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age60Action"].Value)));
                    Param.Add(new SqlParameter("@A75A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age75Action"].Value)));
                    Param.Add(new SqlParameter("@A90A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age90Action"].Value)));
                    Param.Add(new SqlParameter("@A105A", NullToValueSecond(grdCompany.Rows[cnt].Cells["Age105Action"].Value)));

                    //ColumnDBadClient

                    Param.Add(new SqlParameter("@DBadClient", grdCompany.Rows[cnt].Cells["ColumnDBadClient"].Value));


                    int MasterInsertTableVersionId=0;

                    if (string.IsNullOrEmpty(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) || grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString() == "0" || (grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) == "--Use Default--")
                    {


                    }
                    else
                    {                       

                        string value = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString();

                        string Query = "select TableVersionId from VersionTable where TableVersionName = '" + value.ToString() + "'";

                        //DataTable dtTableVersion = StMethod.GetListDT<TableVersionData>(Query);

                        DataTable dtTableVersion;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            dtTableVersion = StMethod.GetListDTNew<TableVersionData>(Query);
                        }
                        else
                        {
                            dtTableVersion = StMethod.GetListDT<TableVersionData>(Query);
                        }

                        if (dtTableVersion.Rows.Count > 0)
                        {

                            string check123 = dtTableVersion.Rows[0][0].ToString();
                            MasterInsertTableVersionId = int.Parse(check123);
                        }

                    }

                    Param.Add(new SqlParameter("@TableVersionId", MasterInsertTableVersionId));
                    //Param.Add(new SqlParameter("@TableVersionId", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["TableVersionId"].Value));

                    //Param.Add(new SqlParameter("@TableVersionId", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["TableVersionId"].Value));
                    Param.Add(new SqlParameter("@ServRate", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["ServRate"].Value));
                    Param.Add(new SqlParameter("@TypicalInvoiceType", grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["TypicalInvoiceType"].Value));

                    //.Rows[cnt].Cells["TableVersionId"].Value))
                    //grdTrackitem.Rows["TrackSet", grdTrackitem.CurrentRow.Index].Value.ToString)
                    if (!Convert.IsDBNull(grdCompany.Rows[cnt].Cells["CreditPassDate"].Value))
                    {
                        if ((Convert.ToDateTime(grdCompany.Rows[cnt].Cells["CreditPassDate"].Value).ToString("M/d/yyyy")) == "1/1/1900")
                        {
                            //Param.Add(new SqlParameter("@IsCreditPass", 0));
                            Param.Add(new SqlParameter("@IsCreditPass", false.ToString()));
                        }
                        else
                        {
                            //Param.Add(new SqlParameter("@IsCreditPass", 1));
                            Param.Add(new SqlParameter("@IsCreditPass", true.ToString()));
                        }
                        Param.Add(new SqlParameter("@CreditPassDate", grdCompany.Rows[cnt].Cells["CreditPassDate"].Value));
                    }
                    else
                    {
                        //Param.Add(new SqlParameter("@IsCreditPass", 0));
                        Param.Add(new SqlParameter("@IsCreditPass", false.ToString()));
                        Param.Add(new SqlParameter("@CreditPassDate", "1/1/1900"));
                    }


                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                    //    {
                    //    }
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                        {
                            if (db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                            {
                            }
                        }
                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                            {
                            }
                        }
                    }


                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (ChangesRows.Count != 0)
            {
                //using (EFDbContext db = new EFDbContext())
                //{
                //    StMethod.LoginActivityInfo(db, "Master Update", this.Text);
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    
                    using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                    {
                        StMethod.LoginActivityInfoNew(db2, "Master Update", this.Text);
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        StMethod.LoginActivityInfo(db, "Master Update", this.Text);
                    }

                }

                MessageBox.Show("Update Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillgrdCompany();
            }

        }
        private void btnContactExport_Click(System.Object sender, System.EventArgs e)
        {
            // Get All manager main grid data as a Datatable
            DataTable ContactMainGrid = GetContactData();


            //TimerExport.Enabled = True
            //Export start

            if (ContactMainGrid.Rows.Count > 0)
            {
                ProgressBar1.Minimum = 0;
                ProgressBar1.Maximum = ContactMainGrid.Rows.Count;
                //Show popup for confrim 
                SaveFileDialog Export = new SaveFileDialog();
                //Export.Filter = "Excel Format|*.xlsx";
                Export.Filter = "Excel Format|*.xls";
                Export.Title = "All Contact Data";
                //'Export.InitialDirectory = "N:"

                string ExportPath = @"N:\";

                if (Directory.Exists(ExportPath))
                {
                    Export.InitialDirectory = @"N:\";
                }
                else
                {
                    Export.InitialDirectory = @"C:\";

                }

                if (Export.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                //-----------------------------------------------
                //If user want to contiune then file export with Name 
                string FullFilePath = Export.FileName;
                string filename = Path.GetFileName(Export.FileName);
                string filePath = Export.FileName;

                //Dim workBook As New XSSFWorkbook()
                ISheet sheet1 = workBook.CreateSheet(filename);

                //Progress bar visiible
                ProgressBar1.Visible = true;
                Label9.Visible = true;

                //MessageBox.Show("Progress 1");

                //sheet cell Formatting
                //--------------------------------------------------------

                //XSSFFont myFont = (XSSFFont)workBook.CreateFont();

                HSSFFont myFont = (HSSFFont)workBook.CreateFont();
                 

                myFont.FontHeightInPoints = 11;
                myFont.FontName = "Tahoma";
                myFont.IsBold = true;


                //XSSFCellStyle borderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();
                HSSFCellStyle borderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();

                borderedCellStyle.SetFont(myFont);

                borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;


                Int32 Sheetrowindex = 0;
                int percent = 0;

                for (int ContactRowindex = 1; ContactRowindex <= ContactMainGrid.Rows.Count; ContactRowindex++)
                {
                    if (ProgressBar1.Value <= ContactMainGrid.Rows.Count)
                    {
                        createContactRows(ContactMainGrid, borderedCellStyle, (ContactRowindex - 1), ref Sheetrowindex, ref sheet1);
                    }
                    percent = (ProgressBar1.Value / ProgressBar1.Maximum) * 100;
                    Label9.Text = percent + "%" + "Completed";
                    Label9.Refresh();
                    ProgressBar1.Value = ProgressBar1.Value + 1;
                    Sheetrowindex = Sheetrowindex + 1;
                }

                //MessageBox.Show("Progress 2");

                //Auto sized all the affected columns
                int lastColumNum = sheet1.GetRow(0).LastCellNum;
                for (int i = 0; i <= lastColumNum; i++)
                {
                    sheet1.AutoSizeColumn(i);
                    GC.Collect();
                }

                //MessageBox.Show("Progress 3");

                //export to excel 
                var fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                workBook.Write(fsd);
                workBook.Close();
                fsd.Close();
                MessageBox.Show("Export Successfully ", Export.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = false;
                Label9.Visible = false;

            }
        }
        private void ContactPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Program.ofrmMain.lblLogin.Text == "Admin Login")
            {
                e.Handled = true;
                KryptonMessageBox.Show("Please login as Administrator", "For Change Password and UserName", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                e.Handled = false;
            }
        }
        private void chkboxPassword_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            //JobAndTrackingMDI mdio = this.MdiParent;
            if (Program.ofrmMain.lblLogin.Text == "Admin Login")
            {
                chkboxPassword.Checked = false;
                KryptonMessageBox.Show("Please login as Administrator", "For Showing Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                grdCompany.Refresh();
                FillgrdCompany();
            }
        }
        #endregion

        #region Methods        
        private void PopulateTypicalInvoiceType()
        {
            this.cmbTypicalInvoiceType.Items.Add("Time");
            this.cmbTypicalInvoiceType.Items.Add("Item");
            //Me.cmbTypicalInvoiceType.Items.Add("Expense")
            //.DisplayMember = "TableVersionName"
            //.ValueMember = "TableVersionId"
            //.DisplayIndex = 10
            cmbTypicalInvoiceType.DataPropertyName = "TypicalInvoiceType";
            cmbTypicalInvoiceType.Name = "TypicalInvoiceType";
            cmbTypicalInvoiceType.HeaderText = "Invoice Type";
            cmbTypicalInvoiceType.Width = 100;
            // Me.cmbTypicalInvoiceType.HeaderText = "Typical Invoice Type"       
            this.grdCompany.Columns.Add(cmbTypicalInvoiceType);
        }
        private void AddgrdColumn()
        {
            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<TableVersionData>("Select * from VersionTable  union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId").ToList();
            //    cmbMasterRateVersionType.DataSource = data;
            //}


            //var data = StMethod.GetListDT<TableVersionData>("Select * from VersionTable  union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");
            //cmbMasterRateVersionType.DataSource = data;
            //cmbVersionTable.DisplayMember = "TableVersionName";
            //cmbVersionTable.ValueMember = "TableVersionId";
            ////.DisplayIndex = 10
            //cmbVersionTable.DataPropertyName = "TableVersionId";
            //cmbVersionTable.HeaderText = "Item Rate";
            ////cmbVersionTable.Name = "TableVersionId";
            //cmbVersionTable.Width = 120;
            //cmbVersionTable.Name = "cmbVersionTable";
            //grdCompany.Columns.Add(cmbVersionTable);


            //var data = StMethod.GetListDT<TableVersionData>("Select * from VersionTable union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");


            var data = StMethod.GetListDT<TableVersionData>("Select * from VersionTable union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");
            data = null;
                       

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                data = StMethod.GetListDTNew<TableVersionData>("Select * from VersionTable union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");            
            }
            else
            {
                data = StMethod.GetListDT<TableVersionData>("Select * from VersionTable union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");
            
            }

            //cmbMasterRateVersionType.DataSource = data;

            cmbVersionTable.DataSource = data;
            cmbVersionTable.DisplayMember = "TableVersionName";
            cmbVersionTable.ValueMember = "TableVersionId";

            cmbVersionTable.DataPropertyName = "TableVersionId";
            cmbVersionTable.HeaderText = "Item Rate";
            //cmbVersionTable.Name = "TableVersionId";
            cmbVersionTable.Width = 120;
            cmbVersionTable.Name = "cmbVersionTable";


            //cmbVersionTable.DefaultCellStyle.NullValue = "--Use Default--";

            grdCompany.Columns.Add(cmbVersionTable);


        }

        protected void SetGrvCompany()
        {
            try
            {
                string queryString = "SELECT Company.CompanyID, Company.CompanyName, Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode," +
                                    "Company.DotInsuranceExp,Company.TableVersionId,Company.ServRate,TableVersionIdCompany.AirborneExpNUM,Company.IBMNUM, Company.FedExNUM, Company.UserName, Company.Password," +
                                    "Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action, Company.Age105Action,  ColorSetting_7.ColorCode AS Age0ActionColor," +
                                    "ColorSetting.ColorCode AS Age15ActionColor, ColorSetting_1.ColorCode AS Age30ActionColor,ColorSetting_2.ColorCode AS Age45ActionColor, ColorSetting_3.ColorCode AS Age60ActionColor, ColorSetting_4.ColorCode AS Age75ActionColor," +
                                    "ColorSetting_5.ColorCode AS Age90ActionColor, ColorSetting_6.ColorCode AS Age105ActionColor, Company.OfficeFax, Company.officePhone, Company.TypicalInvoiceType FROM  ColorSetting AS ColorSetting_6 RIGHT OUTER JOIN Company ON " +
                                    "ColorSetting_6.ColorID = Company.Age105Action LEFT OUTER JOIN ColorSetting AS ColorSetting_5 ON Company.Age90Action = ColorSetting_5.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_7 ON Company.Age0Action = ColorSetting_7.ColorID " +
                                    "LEFT OUTER JOIN ColorSetting AS ColorSetting_4 ON Company.Age75Action = ColorSetting_4.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_3 ON Company.Age60Action = ColorSetting_3.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_2 ON Company.Age45Action = ColorSetting_2.ColorID " +
                                    "LEFT OUTER JOIN ColorSetting AS ColorSetting_1 ON Company.Age30Action = ColorSetting_1.ColorID LEFT OUTER JOIN ColorSetting ON Company.Age15Action = ColorSetting.ColorID WHERE Company.Companyid=0  order by Company.CompanyID";
                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<CompanyColor>(queryString).ToList();
                //    grdCompany.DataSource = data;
                //}

                //var data = StMethod.GetListDT<CompanyColor>(queryString);



                //var data = StMethod.GetListDT<CompanyColorNew>(queryString);
                //grdCompany.DataSource = data;

                var data = StMethod.GetListDT<CompanyColorNew>(queryString);
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    data = StMethod.GetListDTNew<CompanyColorNew>(queryString);

                }
                else
                {
                    data = StMethod.GetListDT<CompanyColorNew>(queryString);
                }

                grdCompany.DataSource = data;

                //MainDataTable = StMethod.GetListDT<CompanyColor>(queryString);

                //Set Column Property

                grdCompany.Columns["CompanyID"].Visible = false;
                grdCompany.Columns["CompanyName"].HeaderText = "Company Name";
                grdCompany.Columns["CompanyName"].Width = 300;
                //.Columns["Track"].Visible = False
                grdCompany.Columns["Address"].Width = 90;
                grdCompany.Columns["Address"].HeaderText = "Address";
                //.Columns["Address"].Visible = False
                //.Columns["NeedDate"].Visible = False
                grdCompany.Columns["City"].Width = 90;
                //.Columns["City"].Visible = False
                grdCompany.Columns["State"].Width = 90;
                //.Columns["State"].Visible = False
                //.Columns["Country"].Visible = False
                //.Columns["Status"].Visible = False
                grdCompany.Columns["PostalCode"].HeaderText = "Postal Code";
                grdCompany.Columns["PostalCode"].Width = 90;
                grdCompany.Columns["OfficePhone"].HeaderText = "Office Phone";
                grdCompany.Columns["OfficeFax"].HeaderText = "Office Fax";
                //.Columns["ServRate").DisplayIndex = 11

                //.Columns["PostalCode"].Visible = False
                grdCompany.Columns["DotInsuranceExp"].Width = 150;
                grdCompany.Columns["AirborneExpNUM"].Width = 150;
                grdCompany.Columns["UserName"].HeaderText = "Company User Name";
                grdCompany.Columns["PassWord"].HeaderText = "Password";
                grdCompany.Columns["Age0Action"].Visible = false;
                grdCompany.Columns["Age15Action"].Visible = false;
                grdCompany.Columns["Age30Action"].Visible = false;
                grdCompany.Columns["Age45Action"].Visible = false;
                grdCompany.Columns["Age60Action"].Visible = false;
                grdCompany.Columns["Age75Action"].Visible = false;
                grdCompany.Columns["Age90Action"].Visible = false;
                grdCompany.Columns["Age105Action"].Visible = false;
                grdCompany.Columns["Age0ActionColor"].Width = 50;
                grdCompany.Columns["Age15ActionColor"].Width = 50;
                grdCompany.Columns["Age30ActionColor"].Width = 50;
                grdCompany.Columns["Age45ActionColor"].Width = 50;
                grdCompany.Columns["Age60ActionColor"].Width = 50;
                grdCompany.Columns["Age75ActionColor"].Width = 50;
                grdCompany.Columns["Age90ActionColor"].Width = 50;
                grdCompany.Columns["Age105ActionColor"].Width = 50;
                grdCompany.Columns["Age0ActionColor"].HeaderText = "A0A";
                grdCompany.Columns["Age15ActionColor"].HeaderText = "A15A";
                grdCompany.Columns["Age30ActionColor"].HeaderText = "A30A";
                grdCompany.Columns["Age45ActionColor"].HeaderText = "A45A";
                grdCompany.Columns["Age60ActionColor"].HeaderText = "A60A";
                grdCompany.Columns["Age75ActionColor"].HeaderText = "A75A";
                grdCompany.Columns["Age90ActionColor"].HeaderText = "A90A";
                grdCompany.Columns["Age105ActionColor"].HeaderText = "A105A";

                if (grdCompany.Rows.Count > 0)
                {
                    selectedCompanyID = Convert.ToInt32(grdCompany.Rows[0].Cells["CompanyID"].Value);
                    grdCompany.Rows[0].Selected = true;
                }
                else
                {
                    selectedCompanyID = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void SetGrvContacts()
        {
            try
            {

                string queryString = "SELECT ContactsID, CompanyID, FirstName, MiddleName, LastName, ContactTitle, MobilePhone, EmailAddress, Notes, SpecialRiggerNUM, MasterRiggerNUM,  SpecialSignNUM, MasterSignNUM, Prefix, Suffix, Address, City, PostalCode, State, Country, HomePhone, WorkPhone, FaxNumber, AlternativePhone, FieldPhone,  Pager,Accounting  FROM  Contacts where CompanyID=" + selectedCompanyID + " order by ContactsID";


                //using (EFDbContext db = new EFDbContext())
                //{
                //    var list = db.Database.SqlQuery<CompanyData>(queryString).ToList();
                //    grvContacts.DataSource = list;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db2.Database.SqlQuery<CompanyData>(queryString).ToList();
                        grvContacts.DataSource = list;
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<CompanyData>(queryString).ToList();
                        grvContacts.DataSource = list;
                    }
                }


                //Set Column Property
                grvContacts.Columns["CompanyID"].Visible = false;
                grvContacts.Columns["ContactsID"].Visible = false;
                grvContacts.Columns["PostalCode"].Visible = false;
                //.Columns["CompanyName"].HeaderText = "Client"
                //'.Columns["Track"].Visible = False
                //.Columns["Address"].Width = 90
                //.Columns["Address"].HeaderText = "Address"
                //'.Columns["NeedDate"].Visible = False
                //.Columns["City"].Width = 90
                //.Columns["State"].Width = 90
                //'.Columns["Status"].Visible = False
                //.Columns["PostalCode"].HeaderText = "PostalC ode"
                //.Columns["PostalCode"].Width = 90
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void FillgrdCompany()
        {


            //string queryString = "SELECT Company.CompanyID, Company.CompanyName, Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode,              Company.DotInsuranceExp,Company.AirborneExpNUM,Company.IBMNUM, Company.FedExNUM, Company.UserName, Company.Password,             Company.Age0Action, Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action, Company.Age105Action, ColorSetting_7.ColorCode AS Age0ActionColor, ColorSetting.ColorCode AS Age15ActionColor, ColorSetting_1.ColorCode AS Age30ActionColor,            ColorSetting_2.ColorCode AS Age45ActionColor, ColorSetting_3.ColorCode AS Age60ActionColor, ColorSetting_4.ColorCode AS Age75ActionColor,              ColorSetting_5.ColorCode AS Age90ActionColor, ColorSetting_6.ColorCode AS Age105ActionColor,Company.IsDisable,Company.CompanyNo, Company.DBadClient, Company.CreditPassDate," + "(CASE WHEN Company.TableVersionId=0 OR Company.TableVersionId IS NULL THEN " + defualtTableVersionId + " ELSE Company.TableVersionId END) AS TableVersionId," + "ISNULL(Company.ServRate,1) as ServRate, Company.OfficePhone, Company.OfficeFax," + "(CASE WHEN Company.TypicalInvoiceType='' OR Company.TypicalInvoiceType IS NULL THEN 'Item' ELSE Company.TypicalInvoiceType END) AS TypicalInvoiceType  " + "FROM  ColorSetting AS ColorSetting_6 RIGHT OUTER JOIN Company ON ColorSetting_6.ColorID = Company.Age105Action LEFT OUTER JOIN ColorSetting AS ColorSetting_5 ON Company.Age90Action = ColorSetting_5.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_7 ON Company.Age0Action = ColorSetting_7.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_4 ON Company.Age75Action = ColorSetting_4.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_3 ON Company.Age60Action = ColorSetting_3.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_2 ON Company.Age45Action = ColorSetting_2.ColorID LEFT OUTER JOIN               ColorSetting AS ColorSetting_1 ON Company.Age30Action = ColorSetting_1.ColorID LEFT OUTER JOIN ColorSetting ON Company.Age15Action = ColorSetting.ColorID where Company.CompanyID > 0 and (Company.IsDelete=0 or Company.IsDelete is null)";

            //3 Octoober

            //        string queryString = "SELECT Top 10 Company.CompanyID, Company.CompanyName, Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode,Company.DotInsuranceExp,Company.AirborneExpNUM,Company.IBMNUM, Company.FedExNUM, Company.UserName, Company.Password,Company.Age0Action, Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action, Company.Age105Action, ColorSetting_7.ColorCode AS Age0ActionColor, ColorSetting.ColorCode AS Age15ActionColor, ColorSetting_1.ColorCode AS Age30ActionColor,ColorSetting_2.ColorCode AS Age45ActionColor, ColorSetting_3.ColorCode AS Age60ActionColor, ColorSetting_4.ColorCode AS Age75ActionColor,ColorSetting_5.ColorCode AS Age90ActionColor, ColorSetting_6.ColorCode AS Age105ActionColor,Company.IsDisable,Company.CompanyNo, Company.DBadClient, Company.CreditPassDate, Company.TableVersionId,(CASE WHEN Company.TableVersionId = 0 OR Company.TableVersionId IS NULL THEN 0 ELSE Company.TableVersionId END) AS TableVersionId2, ISNULL(Company.ServRate, 1) as ServRate, Company.OfficePhone, Company.OfficeFax," + "(CASE WHEN Company.TypicalInvoiceType='' OR Company.TypicalInvoiceType IS NULL THEN 'Item' ELSE Company.TypicalInvoiceType END) AS TypicalInvoiceType";

            //string queryString = "SELECT Top 10 Company.CompanyID, Company.CompanyName, Company.Address, Company.City, Company.State,

            string queryString = "SELECT Company.CompanyID, Company.CompanyName, Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode,Company.DotInsuranceExp,Company.AirborneExpNUM,Company.IBMNUM, Company.FedExNUM, Company.UserName, Company.Password,Company.Age0Action, Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action, Company.Age105Action, ColorSetting_7.ColorCode AS Age0ActionColor, ColorSetting.ColorCode AS Age15ActionColor, ColorSetting_1.ColorCode AS Age30ActionColor,ColorSetting_2.ColorCode AS Age45ActionColor, ColorSetting_3.ColorCode AS Age60ActionColor, ColorSetting_4.ColorCode AS Age75ActionColor,ColorSetting_5.ColorCode AS Age90ActionColor, ColorSetting_6.ColorCode AS Age105ActionColor,Company.IsDisable,Company.CompanyNo, Company.DBadClient, Company.CreditPassDate,";

            queryString = queryString + "(CASE WHEN Company.TableVersionId = 0 OR Company.TableVersionId IS NULL THEN 0 ELSE Company.TableVersionId END) AS TableVersionId, ";
                
              queryString = queryString +  "ISNULL(Company.ServRate, 1) as ServRate, Company.OfficePhone, Company.OfficeFax," + "(CASE WHEN Company.TypicalInvoiceType='' OR Company.TypicalInvoiceType IS NULL THEN 'Item' ELSE Company.TypicalInvoiceType END) AS TypicalInvoiceType";




            //Age105ActionColor,Company.IsDisable,Company.CompanyNo, Company.DBadClient, Company.CreditPassDate,(CASE WHEN Company.TableVersionId = 0 OR Company.TableVersionId IS NULL THEN 0 ELSE Company.TableVersionId END) AS TableVersionId2, ISNULL(Company.ServRate, 1) as ServRate, Company.OfficePhone, Company.OfficeFax," +

            //"(CASE WHEN Company.TypicalInvoiceType='' OR Company.TypicalInvoiceType IS NULL THEN 'Item' ELSE Company.TypicalInvoiceType END) AS TypicalInvoiceType";


            string queryString2 = queryString + " FROM  ColorSetting AS ColorSetting_6 RIGHT OUTER JOIN Company ON ColorSetting_6.ColorID = Company.Age105Action LEFT OUTER JOIN ColorSetting AS ColorSetting_5 ON Company.Age90Action = ColorSetting_5.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_7 ON Company.Age0Action = ColorSetting_7.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_4 ON Company.Age75Action = ColorSetting_4.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_3 ON Company.Age60Action = ColorSetting_3.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_2 ON Company.Age45Action = ColorSetting_2.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_1 ON Company.Age30Action = ColorSetting_1.ColorID LEFT OUTER JOIN ColorSetting ON Company.Age15Action = ColorSetting.ColorID ";

            //string queryString2 = queryString + " FROM  ColorSetting AS ColorSetting_6 RIGHT OUTER JOIN Company ON ColorSetting_6.ColorID = Company.Age105Action LEFT OUTER JOIN ColorSetting AS ColorSetting_5 ON Company.Age90Action = ColorSetting_5.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_7 ON Company.Age0Action = ColorSetting_7.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_4 ON Company.Age75Action = ColorSetting_4.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_3 ON Company.Age60Action = ColorSetting_3.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_2 ON Company.Age45Action = ColorSetting_2.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_1 ON Company.Age30Action = ColorSetting_1.ColorID LEFT OUTER JOIN ColorSetting ON Company.Age15Action = ColorSetting.ColorID where Company.CompanyID > 0 and (Company.IsDelete=0 or Company.IsDelete is null) ";


            queryString = "";

            queryString = queryString2 + "where Company.CompanyID > 0 and (Company.IsDelete=0 or Company.IsDelete is null)";


            try
            {

                if (!string.IsNullOrEmpty(this.txtCompanyName.Text))
                {
                    queryString = queryString + " and Company.CompanyName Like'%" + txtCompanyName.Text + "%'";
                }

                if (rdbSearchInCompany.Checked)
                {
                    queryString = queryString + " AND Company.CompanyID in (SELECT CompanyID FROM Contacts WHERE FirstName like '%" + txtFirstName.Text + "%' AND LastName like '%" + txtLastName.Text + "%')";
                }

                queryString = queryString + " order by Company.CompanyID";

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var list = db.Database.SqlQuery<CompanyColor>(queryString).ToList();
                //    grdCompany.DataSource = new List<CompanyColor>(list);
                //}


                //var data = StMethod.GetListDT<CompanyColor>(queryString);

                var data = StMethod.GetListDT<CompanyColor>(queryString);
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    data = StMethod.GetListDTNew<CompanyColor>(queryString);
                }
                else
                {
                    data = StMethod.GetListDT<CompanyColor>(queryString);
                }

                grdCompany.DataSource = data;


                //foreach (DataGridViewRow row in grdCompany.Rows)
                //{
                //    for (int i = 0; i < grdCompany.Columns.Count; i++)
                //    {
                //        String header = grdCompany.Columns[i].HeaderText;
                //        MessageBox.Show(header);
                //    }
                //}

                //MessageBox.Show(grdCompany.Columns[grdCompany.Columns.Count - 5].HeaderText.ToString());


                //Set Column Property

                grdCompany.Columns["ColumnDisableForWeb"].DisplayIndex = 25;
                grdCompany.Columns["ColumnDBadClient"].DisplayIndex = 26;
                grdCompany.Columns["CreditPassDate"].DisplayIndex = 27;

                //grdCompany.Columns["cmbVersionTable"].Visible = false;
                grdCompany.Columns["cmbVersionTable"].DisplayIndex = 28;
                grdCompany.Columns["ServRate"].DisplayIndex = 29;

                grdCompany.Columns["TypicalInvoiceType"].DisplayIndex = 30;
                //grdCompany.Columns["TypicalInvoiceType"].DisplayIndex = grdCompany.Columns.Count -1;

                //grdCompany.Columns["TableVersionId"].DisplayIndex = 31;

                grdCompany.Columns["CompanyID"].Visible = false;

                grdCompany.Columns["CompanyName"].HeaderText = "Company Name";
                grdCompany.Columns["CompanyName"].Frozen = true;



                grdCompany.Columns["Address"].Width = 90;
                grdCompany.Columns["Address"].HeaderText = "Address";
                //.Columns["Address"].Visible = False
                //.Columns["NeedDate"].Visible = False
                grdCompany.Columns["City"].Width = 90;
                //.Columns["City"].Visible = False
                grdCompany.Columns["State"].Width = 90;
                //.Columns["State"].Visible = False
                //.Columns["Country"].Visible = False
                //.Columns["Status"].Visible = False
                grdCompany.Columns["PostalCode"].HeaderText = "Postal Code";
                grdCompany.Columns["PostalCode"].Width = 90;
                grdCompany.Columns["OfficePhone"].HeaderText = "Office Phone";
                grdCompany.Columns["OfficeFax"].HeaderText = "Office Fax";
                //.Columns["ServRate").DisplayIndex = 11 'change below order too

                //grdCompany.Columns["OfficePhone"].DisplayIndex = 11;
                //grdCompany.Columns["OfficeFax"].DisplayIndex = 12;

                grdCompany.Columns["DotInsuranceExp"].Width = 150;
                grdCompany.Columns["AirborneExpNUM"].Width = 150;
                grdCompany.Columns["UserName"].HeaderText = "Company User Name";
                grdCompany.Columns["PassWord"].HeaderText = "Password";
                grdCompany.Columns["PassWord"].DisplayIndex = 14;
                grdCompany.Columns["Age0Action"].Visible = false;
                grdCompany.Columns["Age15Action"].Visible = false;
                grdCompany.Columns["Age30Action"].Visible = false;
                grdCompany.Columns["Age45Action"].Visible = false;
                grdCompany.Columns["Age60Action"].Visible = false;
                grdCompany.Columns["Age75Action"].Visible = false;
                grdCompany.Columns["Age90Action"].Visible = false;
                grdCompany.Columns["Age105Action"].Visible = false;
                grdCompany.Columns["Age0ActionColor"].Width = 50;
                grdCompany.Columns["Age15ActionColor"].Width = 50;
                grdCompany.Columns["Age30ActionColor"].Width = 50;
                grdCompany.Columns["Age45ActionColor"].Width = 50;
                grdCompany.Columns["Age60ActionColor"].Width = 50;
                grdCompany.Columns["Age75ActionColor"].Width = 50;
                grdCompany.Columns["Age90ActionColor"].Width = 50;
                grdCompany.Columns["Age105ActionColor"].Width = 50;
                grdCompany.Columns["Age0ActionColor"].HeaderText = "A0A";
                grdCompany.Columns["Age15ActionColor"].HeaderText = "A15A";
                grdCompany.Columns["Age30ActionColor"].HeaderText = "A30A";
                grdCompany.Columns["Age45ActionColor"].HeaderText = "A45A";
                grdCompany.Columns["Age60ActionColor"].HeaderText = "A60A";
                grdCompany.Columns["Age75ActionColor"].HeaderText = "A75A";
                grdCompany.Columns["Age90ActionColor"].HeaderText = "A90A";
                grdCompany.Columns["Age105ActionColor"].HeaderText = "A105A";
                //grdCompany.Columns["IsDisable"].HeaderText = "Disable For Web";
                grdCompany.Columns["CompanyNo"].HeaderText = "Company No";

                //grdCompany.Columns["CompanyNo"].DisplayIndex = 8;

                //grdCompany.Columns["cmbVersionTable"].Visible = false;

                //grdCompany.Columns["TypicalInvoiceType"].Visible = false ;

                grdCompany.Columns["ServRate"].DisplayIndex = grdCompany.Columns.Count - 2;


                grdCompany.Columns["CompanyName"].DisplayIndex = 1;

                grdCompany.Columns["Address"].DisplayIndex = 3;
                grdCompany.Columns["City"].DisplayIndex = 4;
                grdCompany.Columns["State"].DisplayIndex = 5;
                grdCompany.Columns["Country"].DisplayIndex = 6;
                grdCompany.Columns["PostalCode"].DisplayIndex = 7;
                grdCompany.Columns["CompanyNo"].DisplayIndex = 8;
                grdCompany.Columns["DotInsuranceExp"].DisplayIndex = 9;
                grdCompany.Columns["AirborneExpNUM"].DisplayIndex = 10;
                grdCompany.Columns["OfficePhone"].DisplayIndex = 11;

                grdCompany.Columns["OfficeFax"].DisplayIndex = 12;
                grdCompany.Columns["IBMNUM"].DisplayIndex = 13;
                grdCompany.Columns["PassWord"].DisplayIndex = 14;
                grdCompany.Columns["FedExNum"].DisplayIndex = 15;
                grdCompany.Columns["UserName"].DisplayIndex = 16;

                grdCompany.Columns["Age0ActionColor"].DisplayIndex = 17;
                grdCompany.Columns["Age15ActionColor"].DisplayIndex = 18;
                grdCompany.Columns["Age30ActionColor"].DisplayIndex = 19;
                grdCompany.Columns["Age45ActionColor"].DisplayIndex = 20;
                grdCompany.Columns["Age60ActionColor"].DisplayIndex = 21;
                grdCompany.Columns["Age75ActionColor"].DisplayIndex = 22;
                grdCompany.Columns["Age90ActionColor"].DisplayIndex = 23;
                grdCompany.Columns["Age105ActionColor"].DisplayIndex = 24;

                //CreditPasDate




                //cmbVersionTable.DisplayIndex = 33
                ChangeColorGrd();
                if (grdCompany.Rows.Count > 0)
                {
                    //selectedCompanyID = Convert.ToInt32(grdCompany.Rows["CompanyID", grdCompany.CurrentRow.Index].Value.ToString)
                    selectedCompanyID = Convert.ToInt32(grdCompany.Rows[0].Cells["CompanyID"].Value.ToString());
                    grdCompany.Rows[0].Selected = true;
                    FillGrdContacts();
                    SetBadClient();
                }
                else
                {
                    selectedCompanyID = 0;
                }

                CompanyTotalRecord = grdCompany.Rows.Count;
                ChangesRows = new List<int>();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }


        protected void FillGrdContacts()
        {
            try
            {
                btnAddContacts.Text = "Insert";
                string queryString = "SELECT ContactsID, CompanyID, FirstName, MiddleName, LastName, ContactTitle,Address, City,State, PostalCode,  Country, MobilePhone, EmailAddress, Notes, SpecialRiggerNUM, MasterRiggerNUM,  SpecialSignNUM, MasterSignNUM, Prefix, Suffix,  HomePhone, WorkPhone, FaxNumber, AlternativePhone, FieldPhone,  Pager ,Accounting FROM  Contacts where CompanyID=" + selectedCompanyID + " and (IsDelete=0 or IsDelete is null) ";
                //If txtFirstName.Text <> String.Empty Or txtLastName.Text <> String.Empty Then
                //    queryString = queryString + " OR CompanyId in(SELECT CompanyID FROM Contacts WHERE FirstName like '%" & txtFirstName.Text & "%' AND LastName Like '%" & txtLastName.Text & "%') "
                //End If
                if (rdbSearchInContact.Checked)
                {
                    if (!string.IsNullOrEmpty(this.txtFirstName.Text))
                    {
                        queryString = queryString + " and FirstName Like'%" + txtFirstName.Text + "%'";
                    }
                    if (!string.IsNullOrEmpty(this.txtLastName.Text))
                    {
                        queryString = queryString + " and LastName Like'%" + txtLastName.Text + "%'";
                    }
                    if (!string.IsNullOrEmpty(txtWorkPhoneSearch.Text))
                    {
                        queryString = queryString + " and WorkPhone like '%" + txtWorkPhoneSearch.Text + "%'";
                    }
                    if (!string.IsNullOrEmpty(this.txtFaxSearch.Text))
                    {
                        queryString = queryString + "and FaxNumber like '%" + txtFaxSearch.Text + "%'";
                    }
                }
                queryString = queryString + " order by ContactsID";



                //using (EFDbContext db = new EFDbContext())
                //{
                //    var list = db.Database.SqlQuery<CompanyDataEdit>(queryString).ToList();


                //    grvContacts.DataSource = list;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db.Database.SqlQuery<CompanyDataEdit>(queryString).ToList();
                        grvContacts.DataSource = list;
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<CompanyDataEdit>(queryString).ToList();


                        grvContacts.DataSource = list;
                    }
                }



                //Set Column Property
                grvContacts.Columns["CompanyID"].Visible = false;
                grvContacts.Columns["ContactsID"].Visible = false;
                grvContacts.Columns["Address"].Visible = false;
                grvContacts.Columns["City"].Visible = false;
                grvContacts.Columns["State"].Visible = false;
                grvContacts.Columns["Country"].Visible = false;
                grvContacts.Columns["PostalCode"].HeaderText = "Postal Code";
                grvContacts.Columns["PostalCode"].Visible = false;

                grvContacts.Columns["ContactName"].Visible = false;

              

                //string queryString = "SELECT ContactsID, CompanyID, FirstName, MiddleName, LastName, ContactTitle,Address, City,State, PostalCode,  Country, MobilePhone, EmailAddress, Notes, SpecialRiggerNUM, MasterRiggerNUM,  SpecialSignNUM, MasterSignNUM, Prefix, Suffix,  HomePhone, WorkPhone, FaxNumber, AlternativePhone, FieldPhone,  Pager ,Accounting FROM  Contacts where CompanyID=" + selectedCompanyID + " and (IsDelete=0 or IsDelete is null) ";

                grvContacts.Columns["FirstName"].DisplayIndex = 1;
                grvContacts.Columns["MiddleName"].DisplayIndex = 2;
                grvContacts.Columns["LastName"].DisplayIndex = 3;
                grvContacts.Columns["ContactTitle"].DisplayIndex = 4;
                grvContacts.Columns["MobilePhone"].DisplayIndex = 5;

                grvContacts.Columns["EmailAddress"].DisplayIndex = 6;
                grvContacts.Columns["Notes"].DisplayIndex = 7;
                grvContacts.Columns["SpecialRiggerNUM"].DisplayIndex = 8;
                grvContacts.Columns["MasterRiggerNUM"].DisplayIndex = 9;
                grvContacts.Columns["SpecialSignNUM"].DisplayIndex = 10;

                grvContacts.Columns["MasterSignNUM"].DisplayIndex = 11;
                grvContacts.Columns["Prefix"].DisplayIndex = 12;
                grvContacts.Columns["Suffix"].DisplayIndex = 13;
                grvContacts.Columns["HomePhone"].DisplayIndex = 14;
                grvContacts.Columns["WorkPhone"].DisplayIndex = 15;

                grvContacts.Columns["FaxNumber"].DisplayIndex = 16;
                grvContacts.Columns["AlternativePhone"].DisplayIndex = 17;
                grvContacts.Columns["FieldPhone"].DisplayIndex = 18;
                grvContacts.Columns["Pager"].DisplayIndex = 19;
                grvContacts.Columns["ColumnDAC"].DisplayIndex = 20;


                //.Columns["PostalCode"].Width = 90
                grvContacts.Columns["MobilePhone"].HeaderText = "Mobile Phone";
                grvContacts.Columns["EmailAddress"].HeaderText = "Email Address";
                grvContacts.Columns["SpecialRiggerNUM"].HeaderText = "Special RiggerNUM";
                grvContacts.Columns["MasterRiggerNUM"].HeaderText = "Master RiggerNUM";
                grvContacts.Columns["SpecialSignNUM"].HeaderText = "Special SignNUM";
                grvContacts.Columns["MasterSignNUM"].HeaderText = "Master SignNUM";
                grvContacts.Columns["AlternativePhone"].HeaderText = "Alternative Phone";
                //grvContacts.Columns["Accounting"].Width = 30;
                //grvContacts.Columns["Accounting"].HeaderText = "A/C";




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void BindMasterCombo()
        {
            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<TableVersionData>("Select * from VersionTable  union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId").ToList();
            //    cmbMasterRateVersionType.DataSource = data;
            //}
            
            

            //var data = StMethod.GetListDT<TableVersionData>("Select * from VersionTable  union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");


            var data = StMethod.GetListDTNew<TableVersionData>("Select * from VersionTable  union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");
            data = null;

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                data = StMethod.GetListDT<TableVersionData>("Select * from VersionTable  union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");

            }
            else
            {
                data = StMethod.GetListDT<TableVersionData>("Select * from VersionTable  union SELECT 0 as TableVersionId, '--Use Default--' as TableVersionName order by TableVersionId");
            }

            cmbMasterRateVersionType.DataSource = data;

            cmbMasterRateVersionType.DisplayMember = "TableVersionName";
            cmbMasterRateVersionType.ValueMember = "TableVersionId";
            //cmbTypicalInvoiceType.DataPropertyName = "TableVersionId";
        }
        protected void InsertCompany()
        {
            //grdCompany.Rows[0].Cells["CompanyName"].Selected = True
            //grdCompany.EndEdit()
            try
            {
                //If grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyName").FormattedValue = "" Then
                if (string.IsNullOrEmpty(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyName"].EditedFormattedValue.ToString()))
                {
                    KryptonMessageBox.Show("Please enter Company Name ", "Contacts");
                    grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyName"];
                    return;
                }

                //if (string.IsNullOrEmpty(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) || grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString() == "0")

                    if (string.IsNullOrEmpty(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) || grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString() == "0" || (grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) == "--Use Default--")
                {
                    KryptonMessageBox.Show("Please enter Item Rate ", "Contacts");
                    //grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["TableVersionId")
                    return;
                }




                if (string.IsNullOrEmpty(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["ServRate"].EditedFormattedValue.ToString()) || !NumericHelper.IsNumeric(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["ServRate"].EditedFormattedValue.ToString()))
                {
                    KryptonMessageBox.Show("Please enter Service Rate ", "Contacts");
                    grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["ServRate"];
                    return;
                }
                if (string.IsNullOrEmpty(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["TypicalInvoiceType"].EditedFormattedValue.ToString()))
                {
                    KryptonMessageBox.Show("Please enter Invoice Type", "Contacts");
                    //grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["TypicalInvoiceType")
                    return;
                }
                foreach (DataGridViewRow GridRow in grdCompany.Rows)
                {
                    if (GridRow.Index != grdCompany.Rows.Count - 1)
                    {
                        if (grdCompany.Rows[GridRow.Index].Cells["CompanyName"].EditedFormattedValue.ToString().Trim() == grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyName"].EditedFormattedValue.ToString().Trim())
                        {
                            if (KryptonMessageBox.Show("Enter compnay name exist! " + " You want continue " + "", "Contacts", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                break;
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                //For Each row As DataGridViewRow In grdCompany.Rows
                //    If row.Index <> grdCompany.Rows.Count - 1 Then
                //        If grdCompany.Rows["UserName", row.Index].EditedFormattedValue.ToString.Trim = grdCompany.Rows["UserName", grdCompany.Rows.Count - 1].EditedFormattedValue.ToString.Trim Then
                //            If KryptonMessageBox.Show("Enter User ID is already exist! " & " You want continue " & "", "Contacts", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = System.Windows.Forms.DialogResult.Yes Then
                //                Exit For
                //            Else
                //                Exit Sub
                //            End If
                //        End If
                //    End If
                //Next
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            try
            {
                btnDeleteCompany.Enabled = true;
                int cnt = grdCompany.Rows.Count - 1;
                SqlCommand cmd = new SqlCommand("Insert into Company(CompanyName,Address,City,State,Country, PostalCode, DotInsuranceExp, AirborneExpNUM, IBMNUM, FedExNUM,IsNewRecord,UserName,PassWord,Age15Action,Age30Action,Age45Action,Age60Action,Age75Action,Age90Action,Age105Action,IsDisable, DBadClient,  CreditPassDate, IsCreditPass,TableVersionId,ServRate, OfficePhone, OfficeFax,TypicalInvoiceType) values (@CompanyName,@Address,@City,@State,@Country, @PostalCode, @DotInsuranceExp, @AirborneExpNUM, @IBMNUM, @FedExNUM,@IsNewRecord,@UserName,@PassWord,@A15A,@A30A,@A45A,@A60A,@A75A,@A90A,@A105A,@IsDisable, @DBadClient, @CreditPassDate, @IsCreditPass, @TableVersionId,@ServRate, @OfficePhone, @OfficeFax,@TypicalInvoiceType )");
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@IsNewRecord", 1));
                // Param.Add(new SqlParameter("@JobListID", grdCompany.Rows[cnt].Cells["JobListID"].Value.ToString())
                Param.Add(new SqlParameter("@CompanyName", grdCompany.Rows[cnt].Cells["CompanyName"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@Address", grdCompany.Rows[cnt].Cells["Address"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@City", grdCompany.Rows[cnt].Cells["City"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@State", grdCompany.Rows[cnt].Cells["State"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@Country", grdCompany.Rows[cnt].Cells["Country"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@PostalCode", grdCompany.Rows[cnt].Cells["PostalCode"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@DotInsuranceExp", grdCompany.Rows[cnt].Cells["DotInsuranceExp"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@AirborneExpNUM", grdCompany.Rows[cnt].Cells["AirborneExpNUM"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@IBMNUM", grdCompany.Rows[cnt].Cells["IBMNUM"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@FedExNUM", grdCompany.Rows[cnt].Cells["FedExNUM"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@UserName", grdCompany.Rows[cnt].Cells["UserNaME"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@PassWord", grdCompany.Rows[cnt].Cells["PassWord"].EditedFormattedValue.ToString().Trim()));
                Param.Add(new SqlParameter("@A15A", grdCompany.Rows[cnt].Cells["Age15Action"].Value.ToString()));
                Param.Add(new SqlParameter("@A30A", grdCompany.Rows[cnt].Cells["Age30Action"].Value.ToString()));
                Param.Add(new SqlParameter("@A45A", grdCompany.Rows[cnt].Cells["Age45Action"].Value.ToString()));
                Param.Add(new SqlParameter("@A60A", grdCompany.Rows[cnt].Cells["Age60Action"].Value.ToString()));
                Param.Add(new SqlParameter("@A75A", grdCompany.Rows[cnt].Cells["Age75Action"].Value.ToString()));
                Param.Add(new SqlParameter("@A90A", grdCompany.Rows[cnt].Cells["Age90Action"].Value.ToString()));
                Param.Add(new SqlParameter("@A105A", grdCompany.Rows[cnt].Cells["Age105Action"].Value.ToString()));
                Param.Add(new SqlParameter("@IsDisable", false.ToString()));
                Param.Add(new SqlParameter("@DBadClient", false.ToString()));

                if (!Convert.IsDBNull(grdCompany.Rows[cnt].Cells["CreditPassDate"].Value))
                {
                    if ((grdCompany.Rows[cnt].Cells["CreditPassDate"].Value) == "1/1/1990")
                    {
                        Param.Add(new SqlParameter("@IsCreditPass", false.ToString()));
                        Param.Add(new SqlParameter("@CreditPassDate", "1/1/1900"));
                    }
                    else
                    {
                        Param.Add(new SqlParameter("@IsCreditPass", true.ToString()));
                        Param.Add(new SqlParameter("@CreditPassDate", grdCompany.Rows[cnt].Cells["CreditPassDate"].Value));
                    }
                }
                else
                {
                    Param.Add(new SqlParameter("@IsCreditPass", false.ToString()));
                    Param.Add(new SqlParameter("@CreditPassDate", "1/1/1900"));
                }
                //su
                //Param.Add(new SqlParameter("@TableVersionId", grdCompany.Rows[cnt].Cells["TableVersionId"].Value));


                int InsertTableVersionId = 0;


                //if (string.IsNullOrEmpty(grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) || grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString() == "0")
                //{
                //    return;
                //}
                //else
                //{
                //    //UpdateTableVersionId = int.Parse(grdCompany.Rows[e.RowIndex].Cells["cmbVersionTable"].EditedFormattedValue.ToString());

                //    string check = grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["cmbVersionTable"].Value.ToString();

                //    UpdateTableVersionId = int.Parse(grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["cmbVersionTable"].Value.ToString());

                //}

                string check = grdCompany.Rows[grdCompany.CurrentRow.Index].Cells["cmbVersionTable"].Value.ToString();

                if (string.IsNullOrEmpty(grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) || grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString() == "0" || (grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString()) == "--Use Default--")
                {
                

                }
                else
                {
                    //InsertTableVersionId = int.Parse(grdCompany.Rows[grdCompany.CurrentCell.RowIndex].Cells[grdCompany.Columns["cmbVersionTable"].Index].Value.ToString());

                    //InsertTableVersionId = int.Parse(grdCompany.Rows[grdCompany.CurrentCell.RowIndex].Cells[grdCompany.Columns["cmbVersionTable"].Index].Value.ToString());

                    string value = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].EditedFormattedValue.ToString();

                    string Query = "select TableVersionId from VersionTable where TableVersionName = '" + value.ToString() + "'";

                    //DataTable dtTableVersion = StMethod.GetListDT<TableVersionData>(Query);
                    DataTable dtTableVersion;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        dtTableVersion = StMethod.GetListDTNew<TableVersionData>(Query);
                    }
                    else
                    {
                        dtTableVersion = StMethod.GetListDT<TableVersionData>(Query);
                    }

                    if (dtTableVersion.Rows.Count>0)
                    {

                        string check123 = dtTableVersion.Rows[0][0].ToString();
                        InsertTableVersionId = int.Parse(check123);                        
                    }

                    ////TableVersionId
                    //object z = grdCompany.Rows[cnt].Cells["cmbVersionTable"].Value;
                    
                    //string value6 = ((DataGridView)grdCompany)["cmbVersionTable", grdCompany.Rows.Count - 1].Value.ToString();
                    //string check2 = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].Value.ToString();

                    //string value2 = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].Value.ToString();
                    //string value3 = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"].Value.ToString();
                    //string value4 = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells[grdCompany.Columns["cmbVersionTable"].Index].Value.ToString();

                  
                    //DataGridViewComboBoxCell ComboBoxCell = (DataGridViewComboBoxCell)grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["cmbVersionTable"];

                    //string value12 = ComboBoxCell.EditedFormattedValue.ToString();
                    //string value11 = ComboBoxCell.Value.ToString();

                    //string value14 = ((DataGridView)grdCompany)[ComboBoxCell.ColumnIndex,ComboBoxCell.RowIndex].Value.ToString();

                  
                    //string value13 = grdCompany.Rows[ComboBoxCell.RowIndex].Cells[ComboBoxCell.ColumnIndex].Value.ToString();




                }

              
                //InsertTableVersionId = int.Parse (grdCompany.Rows[grdCompany.CurrentCell.RowIndex].Cells[grdCompany.Columns["cmbVersionTable"].Index].Value.ToString());


                Param.Add(new SqlParameter("@TableVersionId", InsertTableVersionId));

                Param.Add(new SqlParameter("@ServRate", grdCompany.Rows[cnt].Cells["ServRate"].Value));
                Param.Add(new SqlParameter("@TypicalInvoiceType", grdCompany.Rows[cnt].Cells["TypicalInvoiceType"].Value));
                Param.Add(new SqlParameter("@OfficePhone", grdCompany.Rows[cnt].Cells["OfficePhone"].Value.ToString()));
                Param.Add(new SqlParameter("@OfficeFax", grdCompany.Rows[cnt].Cells["OfficeFax"].Value.ToString()));




                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                //    {                        
                //        grdCompany.Columns["ColumnDisableForWeb"].Visible = true;
                //        grdCompany.Columns["ColumnDBadClient"].Visible = true;
                //        FillgrdCompany();
                //        grdCompany.Rows[grdCompany.Rows.Count - 1].Selected = true;
                //        grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyName"];
                //        btnAddCompany.Text = "Insert";
                //        KryptonMessageBox.Show("Save Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        StMethod.LoginActivityInfo(db, "Insert", this.Text);
                //    }
                //}



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    //MessageBox.Show("3");
                    using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                    {
                        if (db2.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                        {
                            grdCompany.Columns["ColumnDisableForWeb"].Visible = true;
                            grdCompany.Columns["ColumnDBadClient"].Visible = true;
                            FillgrdCompany();
                            grdCompany.Rows[grdCompany.Rows.Count - 1].Selected = true;
                            grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyName"];
                            btnAddCompany.Text = "Insert";
                            KryptonMessageBox.Show("Save Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //StMethod.LoginActivityInfo(db2, "Insert", this.Text);
                            StMethod.LoginActivityInfoNew(db2, "Insert", this.Text);
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("4");
                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                        {
                            grdCompany.Columns["ColumnDisableForWeb"].Visible = true;
                            grdCompany.Columns["ColumnDBadClient"].Visible = true;
                            FillgrdCompany();
                            grdCompany.Rows[grdCompany.Rows.Count - 1].Selected = true;
                            grdCompany.CurrentCell = grdCompany.Rows[grdCompany.Rows.Count - 1].Cells["CompanyName"];
                            btnAddCompany.Text = "Insert";
                            KryptonMessageBox.Show("Save Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StMethod.LoginActivityInfo(db, "Insert", this.Text);
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Contacts");
            }
        }
        protected void InsertContacts()
        {
            //grvContacts.Rows[0].Cells["FirstName"].Selected = True
            //grvContacts.EndEdit()
            try
            {
                if (string.IsNullOrEmpty(grvContacts.Rows[grvContacts.Rows.Count - 1].Cells["FirstName"].EditedFormattedValue.ToString().Trim()))
                {
                    KryptonMessageBox.Show("Please enter First Name ", "Contacts");
                    //grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Selected = True
                    grvContacts.CurrentCell = grvContacts.Rows[grvContacts.Rows.Count - 1].Cells["FirstName"];
                    return;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Contacts");
            }


            try
            {
                btnDeleteContacts.Enabled = true;
                int cnt = grvContacts.Rows.Count - 1;
                SqlCommand cmd = new SqlCommand(" Insert into Contacts(CompanyID, FirstName, MiddleName, LastName, ContactTitle, MobilePhone, EmailAddress, Notes, SpecialRiggerNUM, MasterRiggerNUM,  SpecialSignNUM, MasterSignNUM, Prefix, Suffix, Address, City, PostalCode, State, Country, HomePhone, WorkPhone, FaxNumber, AlternativePhone, FieldPhone,  Pager,Accounting,IsNewRecord) values (@CompanyID,@FirstName, @MiddleName, @LastName, @ContactTitle, @MobilePhone, @EmailAddress, @Notes, @SpecialRiggerNUM, @MasterRiggerNUM,  @SpecialSignNUM, @MasterSignNUM, @Prefix, @Suffix, @Address, @City,@PostalCode,@State,@Country,@HomePhone,@WorkPhone,@FaxNumber,@AlternativePhone,@FieldPhone, @Pager,@AC,@IsNewRecord)");
                List<SqlParameter> Param = new List<SqlParameter>();


                //Param.Add(new SqlParameter("@FirstName", grvContacts.Rows[cnt].Cells["FirstName"].Value.ToString()));
                //Param.Add(new SqlParameter("@MiddleName", grvContacts.Rows[cnt].Cells["MiddleName"].Value.ToString()));
                //Param.Add(new SqlParameter("@LastName", grvContacts.Rows[cnt].Cells["LastName"].Value.ToString()));


                //MessageBox.Show(grvContacts.Rows[cnt].Cells[0].EditedFormattedValue.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[1].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[2].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[3].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[4].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[5].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[6].Value.ToString());




                //MessageBox.Show(grvContacts.Rows[cnt].Cells[7].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[8].Value.ToString());


                //MessageBox.Show(grvContacts.Rows[cnt].Cells["FirstName"].EditedFormattedValue.ToString());

              

                //MessageBox.Show(grvContacts.Rows[cnt].Cells["MiddleName"].EditedFormattedValue.ToString());

                //MessageBox.Show(grvContacts.Rows[cnt].Cells["LastName"].EditedFormattedValue.ToString());


                /*
                 
                Firstname = 3
                middlename = 4
                lastname = 5
                ContactTitle = 7
                MobilePhone = 13
                EmailAddress = 14
                 */


                //MessageBox.Show(grvContacts.Rows[cnt].Cells[3].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[4].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[5].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[7].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[cnt].Cells[13].Value.ToString());




                Param.Add(new SqlParameter("@IsNewRecord", 1));
                Param.Add(new SqlParameter("@CompanyID", selectedCompanyID));

             

                //Param.Add(new SqlParameter("@FirstName", grvContacts.Rows[cnt].Cells["FirstName"].EditedFormattedValue.ToString()));
                //Param.Add(new SqlParameter("@MiddleName", grvContacts.Rows[cnt].Cells["MiddleName"].Value.ToString()));
                //Param.Add(new SqlParameter("@LastName", grvContacts.Rows[cnt].Cells["LastName"].Value.ToString()));


                Param.Add(new SqlParameter("@FirstName", grvContacts.Rows[cnt].Cells["FirstName"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@MiddleName", grvContacts.Rows[cnt].Cells["MiddleName"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@LastName", grvContacts.Rows[cnt].Cells["LastName"].EditedFormattedValue.ToString()));


                Param.Add(new SqlParameter("@ContactTitle", grvContacts.Rows[cnt].Cells["ContactTitle"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@MobilePhone", grvContacts.Rows[cnt].Cells["MobilePhone"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@EmailAddress", grvContacts.Rows[cnt].Cells["EmailAddress"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@Notes", grvContacts.Rows[cnt].Cells["Notes"].EditedFormattedValue.ToString()));


                //Param.Add(new SqlParameter("@ContactTitle", grvContacts.Rows[cnt].Cells["ContactTitle"].Value.ToString()));
                //Param.Add(new SqlParameter("@MobilePhone", grvContacts.Rows[cnt].Cells["MobilePhone"].Value.ToString()));
                //Param.Add(new SqlParameter("@EmailAddress", grvContacts.Rows[cnt].Cells["EmailAddress"].Value.ToString()));
                //Param.Add(new SqlParameter("@Notes", grvContacts.Rows[cnt].Cells["Notes"].Value.ToString()));


                //Param.Add(new SqlParameter("@SpecialRiggerNUM", grvContacts.Rows[cnt].Cells["SpecialRiggerNUM"].Value.ToString()));
                //Param.Add(new SqlParameter("@MasterRiggerNUM", grvContacts.Rows[cnt].Cells["MasterRiggerNUM"].Value.ToString()));
                //Param.Add(new SqlParameter("@SpecialSignNUM", grvContacts.Rows[cnt].Cells["SpecialSignNUM"].Value.ToString()));
                //Param.Add(new SqlParameter("@MasterSignNUM", grvContacts.Rows[cnt].Cells["MasterSignNUM"].Value.ToString()));
                //Param.Add(new SqlParameter("@Prefix", grvContacts.Rows[cnt].Cells["Prefix"].Value.ToString()));
                //Param.Add(new SqlParameter("@Suffix", grvContacts.Rows[cnt].Cells["Suffix"].Value.ToString()));
                //Param.Add(new SqlParameter("@Address", grvContacts.Rows[cnt].Cells["Address"].Value.ToString()));


                Param.Add(new SqlParameter("@SpecialRiggerNUM", grvContacts.Rows[cnt].Cells["SpecialRiggerNUM"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@MasterRiggerNUM", grvContacts.Rows[cnt].Cells["MasterRiggerNUM"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@SpecialSignNUM", grvContacts.Rows[cnt].Cells["SpecialSignNUM"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@MasterSignNUM", grvContacts.Rows[cnt].Cells["MasterSignNUM"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@Prefix", grvContacts.Rows[cnt].Cells["Prefix"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@Suffix", grvContacts.Rows[cnt].Cells["Suffix"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@Address", grvContacts.Rows[cnt].Cells["Address"].EditedFormattedValue.ToString()));



                Param.Add(new SqlParameter("@City", grvContacts.Rows[cnt].Cells["City"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@PostalCode", grvContacts.Rows[cnt].Cells["PostalCode"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@State", grvContacts.Rows[cnt].Cells["State"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@Country", grvContacts.Rows[cnt].Cells["Country"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@HomePhone", grvContacts.Rows[cnt].Cells["HomePhone"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@WorkPhone", grvContacts.Rows[cnt].Cells["WorkPhone"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@FaxNumber", grvContacts.Rows[cnt].Cells["FaxNumber"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@AlternativePhone", grvContacts.Rows[cnt].Cells["AlternativePhone"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@FieldPhone", grvContacts.Rows[cnt].Cells["FieldPhone"].EditedFormattedValue.ToString()));
                Param.Add(new SqlParameter("@Pager", grvContacts.Rows[cnt].Cells["Pager"].EditedFormattedValue.ToString()));


                //Param.Add(new SqlParameter("@City", grvContacts.Rows[cnt].Cells["City"].Value.ToString()));
                //Param.Add(new SqlParameter("@PostalCode", grvContacts.Rows[cnt].Cells["PostalCode"].Value.ToString()));
                //Param.Add(new SqlParameter("@State", grvContacts.Rows[cnt].Cells["State"].Value.ToString()));
                //Param.Add(new SqlParameter("@Country", grvContacts.Rows[cnt].Cells["Country"].Value.ToString()));
                //Param.Add(new SqlParameter("@HomePhone", grvContacts.Rows[cnt].Cells["HomePhone"].Value.ToString()));
                //Param.Add(new SqlParameter("@WorkPhone", grvContacts.Rows[cnt].Cells["WorkPhone"].Value.ToString()));
                //Param.Add(new SqlParameter("@FaxNumber", grvContacts.Rows[cnt].Cells["FaxNumber"].Value.ToString()));
                //Param.Add(new SqlParameter("@AlternativePhone", grvContacts.Rows[cnt].Cells["AlternativePhone"].Value.ToString()));
                //Param.Add(new SqlParameter("@FieldPhone", grvContacts.Rows[cnt].Cells["FieldPhone"].Value.ToString()));
                //Param.Add(new SqlParameter("@Pager", grvContacts.Rows[cnt].Cells["Pager"].Value.ToString()));


                //Param.Add(new SqlParameter("@AC", grvContacts.Rows[cnt].Cells["ColumnDAC"].Value.ToString()));

                Param.Add(new SqlParameter("@AC", grvContacts.Rows[cnt].Cells["ColumnDAC"].EditedFormattedValue.ToString()));

                //Param.Add(new SqlParameter("@AC", grvContacts.Rows[cnt].Cells["Accounting"].EditedFormattedValue.ToString()));
                //cmd.Parameters.AddWithValue("@Notes", grvContacts.Rows[cnt].Cells["Notes"].Value.ToString())

                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                //    {
                //        //System.Windows.Forms.MessageBox.Show("Record Saved!", "Message")
                //        FillGrdContacts();
                //        grvContacts.Rows[grvContacts.Rows.Count - 1].Selected = true;
                //        grvContacts.CurrentCell = grvContacts.Rows[grvContacts.Rows.Count - 1].Cells["FirstName"];
                //        btnAddContacts.Text = "Insert";
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                        {
                            //System.Windows.Forms.MessageBox.Show("Record Saved!", "Message")
                            FillGrdContacts();
                            grvContacts.Rows[grvContacts.Rows.Count - 1].Selected = true;
                            grvContacts.CurrentCell = grvContacts.Rows[grvContacts.Rows.Count - 1].Cells["FirstName"];
                            btnAddContacts.Text = "Insert";
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand(cmd.CommandText, Param.ToArray()) > 0)
                        {
                            //System.Windows.Forms.MessageBox.Show("Record Saved!", "Message")
                            FillGrdContacts();
                            grvContacts.Rows[grvContacts.Rows.Count - 1].Selected = true;
                            grvContacts.CurrentCell = grvContacts.Rows[grvContacts.Rows.Count - 1].Cells["FirstName"];
                            btnAddContacts.Text = "Insert";
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Contacts");
            }
        }
        private void DisableUser(Int32 RIndex)
        {
            try
            {
                //Update At Web
                
                //int count = StMethod.UpdateRecord("UPDATE Company SET IsDisable=1 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString(), StMethod.eDatabase.WebDB);

                int count;


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    //MessageBox.Show("5");
                    count = StMethod.UpdateRecordNew("UPDATE Company SET IsDisable=1 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString(), StMethod.eDatabase.WebDB);

                }
                else
                {
                    //MessageBox.Show("6");
                    count = StMethod.UpdateRecord("UPDATE Company SET IsDisable=1 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString(), StMethod.eDatabase.WebDB);

                }

                if (count > 0)
                {

                    //StMethod.UpdateRecord("UPDATE Company SET IsDisable=1 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());



                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        //MessageBox.Show("7");
                        StMethod.UpdateRecordNew("UPDATE Company SET IsDisable=1 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());
                    }
                    else
                    {
                        //MessageBox.Show("8");
                        StMethod.UpdateRecord("UPDATE Company SET IsDisable=1 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());
                    }


                    grdCompany.Rows[RIndex].DefaultCellStyle.BackColor = Color.Gray;
                    grdCompany.Rows[RIndex].DefaultCellStyle.SelectionBackColor = Color.Gray;
                    KryptonMessageBox.Show("Disable Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                else
                {
                    KryptonMessageBox.Show("Record Not Found at WebServer DB! Goto Upload", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("9");
                    grdCompany.Rows[RIndex].Cells["IsDisable"].Value = 0;
                }
                //*******
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message + " Or Please Check internet connection", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EnableUser(Int32 RIndex)
        {
            SqlConnection WebCon = new SqlConnection(global::JobTracker.Properties.Settings.Default.Setting.ToString());

            try
            {
                //Update At Web

                //int count = StMethod.UpdateRecord("UPDATE Company SET IsDisable=0 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString(), StMethod.eDatabase.WebDB);

                int count;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    //MessageBox.Show("10");
                    count = StMethod.UpdateRecordNew("UPDATE Company SET IsDisable=0 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString(), StMethod.eDatabase.WebDB);
                }
                else
                {
                    //MessageBox.Show("11");
                    count = StMethod.UpdateRecord("UPDATE Company SET IsDisable=0 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString(), StMethod.eDatabase.WebDB);
                }

                if (count > 0)
                {
                    
                    //StMethod.UpdateRecord("UPDATE Company SET IsDisable=0 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        //MessageBox.Show("12");
                        StMethod.UpdateRecordNew("UPDATE Company SET IsDisable=0 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());

                    }
                    else
                    {
                        //MessageBox.Show("13");
                        StMethod.UpdateRecord("UPDATE Company SET IsDisable=0 WHERE CompanyID=" + grdCompany.Rows[RIndex].Cells["CompanyID"].Value.ToString());
                    }


                    grdCompany.Rows[RIndex].DefaultCellStyle.BackColor = Color.White;
                    grdCompany.Rows[RIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(159, 207, 255);
                    KryptonMessageBox.Show("Enable Successfully", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
                else
                {
                    KryptonMessageBox.Show("Record Not Found at WebServer DB! Goto Upload", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show("14");
                    grdCompany.Rows[RIndex].Cells["IsDisable"].Value = 1;
                }
                //*******
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message + " Or Please Check internet connection", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                WebCon.Close();
            }
        }
        public bool IsValidEmail(string EmailAddress)
        {
            //Return Regex.IsMatch(EmailAddress, "[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", RegexOptions.IgnoreCase Or RegexOptions.Multiline)
            //^\w+([-+.']\w+)*@\w+([-.](com|net|in|us)+)*$
            return Regex.IsMatch(EmailAddress, "^\\w+([-+.']\\w+)*@\\w+([-.](com|net|in|us)+)*$", RegexOptions.IgnoreCase | RegexOptions.Multiline);

        }

        private void wordFAXUsingNPOI()
        {
            try
            {
                if (grvContacts.Rows.Count == 0)
                {
                    KryptonMessageBox.Show("First Select Contact Name");
                    return;
                }

                //using NPOI.XWPF.UserModel;
                NPOI.XWPF.UserModel.XWPFDocument doc = new NPOI.XWPF.UserModel.XWPFDocument();      //Create a new word document
                                                                                                    //XWPFDocument doc = new XWPFDocument();      //Create a new word document

                //XWPFParagraph p1 = doc.CreateParagraph();   //Add paragraph to new document
                NPOI.XWPF.UserModel.XWPFParagraph p1 = doc.CreateParagraph();   //Add paragraph to new document



                //p1.SetAlignment(ParagraphAlignment.CENTER); //Paragraph alignment is centered
                //p1.SetAlignment(ParagraphAlignment.CENTER); //Paragraph alignment is centered

                NPOI.XWPF.UserModel.XWPFRun r1 = p1.CreateRun();                //Add text to the paragraph
                //XWPFRun r1 = p1.CreateRun();                //Add text to the paragraph
                r1.SetText("Test paragraph one");

                NPOI.XWPF.UserModel.XWPFParagraph p2 = doc.CreateParagraph();
                //XWPFParagraph p2 = doc.CreateParagraph();                
                //p2.SetAlignment(ParagraphAlignment.LEFT);

                //XWPFRun r2 = p2.CreateRun();
                NPOI.XWPF.UserModel.XWPFRun r2 = p2.CreateRun();
                r2.SetText("Test paragraph two");


                //var fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //workBook.Write(fsd);
                //workBook.Close();
                //fsd.Close();
                //MessageBox.Show("Export Successfully ", Export.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);



                //FileStream sw = File.Create("cutput.docx"); //...
                FileStream sw = new FileStream(@"D:\output.docx", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                doc.Write(sw);                              //...
                sw.Close();                                 //Generate files on the server

                //FileInfo file = new FileInfo("cutput.docx");//File save path and name  
                                                            //Note: You need to add the Everyone user to the parent folder where the file is saved and give it full control permissions
                //Response.Clear();
                //Response.ClearHeaders();
                //Response.Buffer = false;
                //Response.ContentType = "application/octet-stream";
                //Response.AppendHeader("Content-Disposition", "attachment;filename="
                //    + HttpUtility.UrlEncode("output.docx", System.Text.Encoding.UTF8));
                //Response.AppendHeader("Content-Length", file.Length.ToString());
                //Response.WriteFile(file.FullName);
                //Response.Flush();                           //Send the generated word file to the user's browser

                //File.Delete("cutput.docx");                 //Clear the word file generated by the server

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message + " Or Please Check internet connection", "Contacts", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void wordFAX()
        {
            try
            {

                //wordFAXUsingNPOI();

                if (grvContacts.Rows.Count == 0)
                {
                    KryptonMessageBox.Show("First Select Contact Name");
                    return;
                }
                Word.Application WordFax = null;
                Word.Document WordDoc = null;
                WordFax = (Word.Application)System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Word.Application"));
                WordDoc = WordFax.Documents.Add();
                WordFax.Visible = true;
                WordFax.Activate();

                //MessageBox.Show("1");

                Word.Range HeaderRang = WordDoc.Paragraphs.Add().Range;
                HeaderRang.InlineShapes.AddPicture(Application.StartupPath + "\\Header.Jpg");
                //WordDoc.SaveAs(Application.StartupPath + "\Word.doc")
                Word.Range FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                FAXtext.Font.Name = "Arial Black";
                FAXtext.Font.Size = float.Parse("54");
                FAXtext.Font.Bold = 1;
                FAXtext.InsertBefore("Fax");
                Word.Table insertTable = WordDoc.Tables.Add(WordDoc.Words.Last, 4, 4);
                insertTable.PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto;

                //MessageBox.Show("1.1");

                insertTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                insertTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                //.PreferredWidth = 91.5
                insertTable.LeftPadding = 18;
                insertTable.AllowAutoFit = true;
                for (int i = 1; i <= 4; i++)
                {
                    insertTable.Cell(i, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                    insertTable.Cell(i, 1).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 1).PreferredWidth = 12;
                    insertTable.Cell(i, 1).Range.Font.Name = "Arial Black";
                    insertTable.Cell(i, 1).Range.Font.Size = float.Parse("10");
                    insertTable.Cell(i, 3).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 3).PreferredWidth = 12;
                    insertTable.Cell(i, 3).Range.Font.Name = "Arial Black";
                    insertTable.Cell(i, 3).Range.Font.Size = float.Parse("10");
                    insertTable.Cell(i, 2).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 2).PreferredWidth = 40;
                    insertTable.Cell(i, 4).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthPercent;
                    insertTable.Cell(i, 4).PreferredWidth = 40;
                }


                //MessageBox.Show("1.3");

                //MessageBox.Show(grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["FirstName"].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["LastName"].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["FaxNumber"].Value.ToString());
                //MessageBox.Show(grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["MobilePhone"].Value.ToString());


                //MessageBox.Show("1.4");

                //myTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

                //insertTable.Cell(1, 1).Range.Borders = Border3DSide;

                insertTable.Cell(1, 1).Range.Text = "To:";
                insertTable.Cell(1, 2).Range.Text = grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["FirstName"].Value.ToString() + " " + grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["LastName"].Value.ToString();


            
                insertTable.Cell(2, 1).Range.Text = "Fax:";
                insertTable.Cell(2, 2).Range.Text = grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["FaxNumber"].Value.ToString();
                insertTable.Cell(3, 1).Range.Text = "Phone:";
                insertTable.Cell(3, 2).Range.Text = grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["MobilePhone"].Value.ToString();
                insertTable.Cell(4, 1).Range.Text = "Re:";
                insertTable.Cell(1, 3).Range.Text = "From:";
                insertTable.Cell(1, 4).Range.Text = "Steve Valjato";
                insertTable.Cell(2, 3).Range.Text = "Pages:";
                insertTable.Cell(2, 4).Range.Text = "1 (including this cover sheet)";
                insertTable.Cell(3, 3).Range.Text = "Date:";
                insertTable.Cell(3, 4).Range.Text = DateTime.Now.ToString("D", CultureInfo.CreateSpecificCulture("en-US"));
                insertTable.Cell(4, 3).Range.Text = "CC:";
                //.Range.Select()
                //.Tables.Rows[1).Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter
                // WordDoc.Tables.Rows[1).Select()
                WordDoc.Tables[1].Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;
                //Dim par As Word.Paragraph = WordDoc.LastParagraph
                Word.FormField WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                WordcheckBox.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore("\r");
                FAXtext.InsertAfter("Urgent");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("For Review");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Please Comment");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("Please Reply");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("For your use");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                WordcheckBox = WordDoc.FormFields.Add(WordDoc.Words.Last, Word.WdFieldType.wdFieldFormCheckBox);
                FAXtext = WordcheckBox.Range;
                FAXtext.InsertBefore(" ");
                FAXtext.InsertAfter("As Requested");
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("9");
                FAXtext.Font.Bold = 1;
                FAXtext = WordDoc.Paragraphs.Add().Range;
                FAXtext.InsertBefore("\r");
                FAXtext.InlineShapes.AddHorizontalLineStandard(WordDoc.Words.Last);
                FAXtext.InsertBefore("\r");
                FAXtext = WordDoc.Paragraphs.Add().Range;
                WordDoc.Paragraphs.Add(FAXtext).Range.ListFormat.ApplyBulletDefault(Word.WdBuiltinStyle.wdStyleListBullet2);
                FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphJustifyMed;
                //.ListFormat.ApplyBulletDefault(Word.WdBuiltinStyle.wdStyleListContinue2)
                FAXtext.Font.Name = "Arial";
                FAXtext.Font.Size = float.Parse("10");
                FAXtext.Font.Bold = 1;
                FAXtext.InsertBefore("Comments:");
                //.Select()
                //Dim SaveExportLocation As New SaveFileDialog
                //SaveExportLocation.Filter = "DOC|*.doc"
                //If SaveExportLocation.ShowDialog = DialogResult.OK Then
                //    WordFax.ChangeFileOpenDirectory(SaveExportLocation.FileName)
                //    WordDoc.Save
                //    WordDoc.Close()
                //    WordDoc = Nothing
                //    WordFax = Nothing
                //    Shell(SaveExportLocation.FileName, AppWinStyle.Hide)
                //End If
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void WordTranmittal()
        {
            Word.Application WordFax = null;
            Word.Document WordDoc = null;
            WordFax = (Word.Application)System.Activator.CreateInstance(System.Type.GetTypeFromProgID("Word.Application"));
            WordDoc = WordFax.Documents.Add();
            WordFax.Visible = true;
            WordFax.Activate();
            Word.Range HeaderRang = WordDoc.Paragraphs.Add().Range;
            HeaderRang.InlineShapes.AddPicture(Application.StartupPath + "\\Header.Jpg");
            //WordDoc.SaveAs(Application.StartupPath + "\Word.doc")
            Word.Range FAXtext = WordDoc.Paragraphs.Add().Range;
            FAXtext.InsertBefore("\r");
            FAXtext.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            FAXtext.InsertBefore("Transmittal");
            FAXtext.set_Style(Word.WdBuiltinStyle.wdStyleHeading2);
            FAXtext.Font.Name = "Arial Black";
            FAXtext.Font.Size = 18;
            FAXtext.Font.Bold = 1;
            FAXtext.Font.Italic = 0;
            FAXtext.InsertAfter("\r");
            FAXtext = WordDoc.Paragraphs.Add().Range;
            FAXtext.InsertBefore("\r" + "\r");
            FAXtext.Font.Name = "Arial";
            FAXtext.Font.Size = 12;
            FAXtext.Font.Bold = 1;
            FAXtext.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
            FAXtext.InsertBefore("ATTENSION:Client Name");

            FAXtext = WordDoc.Range(FAXtext.StartOf() + 10, FAXtext.EndOf() + 11);
            FAXtext.Font.Name = "Arial";
            FAXtext.Font.Size = 12;
            FAXtext.Font.Bold = 1;
            FAXtext.Underline = Word.WdUnderline.wdUnderlineSingle;
            FAXtext.Select();
            //.InsertBefore("Client Name")
            //.InsertBefore(vbTab & vbTab & vbTab & vbTab & vbTab)
            //FAXtext = WordDoc.Paragraphs.Add().Range
            //With FAXtext
            //    .Font.Name = "Arial"
            //    .Font.Size = "12"
            //    .InsertBefore("Client Name")
            //    .InsertAfter(vbTab & vbTab & vbTab & vbTab & vbTab)
            //End With
            //FAXtext = WordDoc.Paragraphs.Add().Range
            //With FAXtext
            //    .InsertBefore(vbCr & vbCr)
            //    .Font.Name = "Arial"
            //    .Font.Size = "12"
            //    .Font.Bold = True
            //    .Font.Underline = True
            //    .InsertBefore("DATE:")
            //End With
            //FAXtext = WordDoc.Paragraphs.Add().Range
            //With FAXtext
            //    .Font.Name = "Arial"
            //    .Font.Size = "12"
            //    .InsertBefore(Format(System.DateTime.Now, "MM/dd/yyyy").ToString)
            //End With
        }
        private void CryWordTrasmittal()
        {
            try
            {
                if (grvContacts.Rows.Count == 0)
                {
                    KryptonMessageBox.Show("First Select Contact Name");
                    return;
                }
                ParameterFields pFields = new ParameterFields();
                ReportDocument printDocument = new ReportDocument();
                printDocument = new rptWordTrasnmittal();

                string SavePath = @"N:\";

                SaveFileDialog SaveExportLocation = new SaveFileDialog();
                
                if(Directory.Exists(SavePath))
                {
                    SaveExportLocation.InitialDirectory = SavePath;

                }
                else
                {
                    SaveExportLocation.InitialDirectory = @"C:\";
                }


                //DataTable dt = StMethod.GetListDT<vWordTran>("SELECT * FROM vWordTrans WHERE ContactsID=" + grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["ContactsID"].Value.ToString());

                DataTable dt;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<vWordTran>("SELECT * FROM vWordTrans WHERE ContactsID=" + grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["ContactsID"].Value.ToString());
                }
                else
                {
                    dt = StMethod.GetListDT<vWordTran>("SELECT * FROM vWordTrans WHERE ContactsID=" + grvContacts.Rows[grvContacts.CurrentRow.Index].Cells["ContactsID"].Value.ToString());
                }


                printDocument.SetDataSource(dt);
                //Export
                //SaveExportLocation.ShowDialog()
                SaveExportLocation.Filter = "DOC|*.Doc";
                if (SaveExportLocation.ShowDialog() == DialogResult.OK)
                {
                    ExportOptions CrExportOptions = null;
                    DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                    PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                    CrDiskFileDestinationOptions.DiskFileName = SaveExportLocation.FileName;
                    ExportOptions ExportOpt = new ExportOptions();
                    ExportOpt.ExportDestinationType = ExportDestinationType.DiskFile;
                    ExportOpt.ExportFormatType = ExportFormatType.WordForWindows;
                    ExportOpt.DestinationOptions = CrDiskFileDestinationOptions;
                    ExportOpt.FormatOptions = CrFormatTypeOptions;
                    printDocument.Export(ExportOpt);
                    //Shell(SaveExportLocation.FileName, AppWinStyle.Hide)
                    Process.Start(SaveExportLocation.FileName);
                    KryptonMessageBox.Show("Please verify document open in MSword or not.");
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void rdbSearchInContact_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            FillGrdContacts();
            if (rdbSearchInContact.Checked == true)
            {
                lblFaxSearch.Visible = true;
                lblWorkPhoneSearch.Visible = true;
                txtWorkPhoneSearch.Visible = true;
                txtFaxSearch.Visible = true;
            }
            else
            {
                lblFaxSearch.Visible = false;
                lblWorkPhoneSearch.Visible = false;
                txtWorkPhoneSearch.Visible = false;
                txtFaxSearch.Visible = false;
            }
        }
        private void SetBadClient()
        {
            try
            {
                foreach (DataGridViewRow grdrow in grdCompany.Rows)
                {
                    //if (Convert.ToBoolean(grdrow.Cells["DBadClient"].Value) == true)
                    //{
                    //    grdrow.DefaultCellStyle.ForeColor = Color.Red;
                    //    Font F = new Font(FontFamily.GenericSansSerif, 8.5f, FontStyle.Strikeout);
                    //    grdrow.DefaultCellStyle.Font = new Font(F, FontStyle.Strikeout);
                    //}



                    if (Convert.ToBoolean(grdrow.Cells["ColumnDBadClient"].Value) == true)
                    {
                        grdrow.DefaultCellStyle.ForeColor = Color.Red;
                        //grdrow.DefaultCellStyle.BackColor = Color.DarkCyan;

                        //grdrow.DefaultCellStyle.BackColor = new SolidBrush((Color)System.Drawing.ColorConverter.ConvertFromString("#1E1E1E"));


                        System.Drawing.Color myColor = System.Drawing.ColorTranslator.FromHtml("#808080");
                        grdrow.DefaultCellStyle.BackColor = myColor;


                        //Control.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E1E1E"));

                        Font F = new Font(FontFamily.GenericSansSerif, 8.5f, FontStyle.Strikeout);
                        grdrow.DefaultCellStyle.Font = new Font(F, FontStyle.Strikeout);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private Int32 ChangeColourAction(Int16 value, Color Actioncolor)
        {

            if (CurrentColName == "Age0ActionColor" && CurrentRoIndex > -1)
            {
                grdCompany.Rows[CurrentRoIndex].Cells["Age0Action"].Value = value;
                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.BackColor = Actioncolor;

                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.SelectionBackColor = Actioncolor;
            }

            if (CurrentColName == "Age15ActionColor" && CurrentRoIndex > -1)
            {
                grdCompany.Rows[CurrentRoIndex].Cells["Age15Action"].Value = value;
                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.BackColor = Actioncolor;

                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.SelectionBackColor = Actioncolor;
            }
            if (CurrentColName == "Age30ActionColor" && CurrentRoIndex > -1)
            {
                grdCompany.Rows[CurrentRoIndex].Cells["Age30Action"].Value = value;
                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.BackColor = Actioncolor;

                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.SelectionBackColor = Actioncolor;
            }
            if (CurrentColName == "Age45ActionColor" && CurrentRoIndex > -1)
            {
                grdCompany.Rows[CurrentRoIndex].Cells["Age45Action"].Value = value;
                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.BackColor = Actioncolor;

                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.SelectionBackColor = Actioncolor;
            }
            if (CurrentColName == "Age60ActionColor" && CurrentRoIndex > -1)
            {
                grdCompany.Rows[CurrentRoIndex].Cells["Age60Action"].Value = value;
                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.BackColor = Actioncolor;

                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.SelectionBackColor = Actioncolor;
            }
            if (CurrentColName == "Age75ActionColor" && CurrentRoIndex > -1)
            {
                grdCompany.Rows[CurrentRoIndex].Cells["Age75Action"].Value = value;
                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.BackColor = Actioncolor;

                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.SelectionBackColor = Actioncolor;
            }
            if (CurrentColName == "Age90ActionColor" && CurrentRoIndex > -1)
            {
                grdCompany.Rows[CurrentRoIndex].Cells["Age90Action"].Value = value;
                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.BackColor = Actioncolor;

                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.SelectionBackColor = Actioncolor;
            }
            if (CurrentColName == "Age105ActionColor" && CurrentRoIndex > -1)
            {
                grdCompany.Rows[CurrentRoIndex].Cells["Age105Action"].Value = value;
                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.BackColor = Actioncolor;

                grdCompany.Rows[CurrentRoIndex].Cells[CurrentColIndex].Style.SelectionBackColor = Actioncolor;
            }
            return 0;
        }

        //private object createContactRows(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)
         
        private object createContactRows(DataTable dt, HSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)
        {

            //add column header
            var sheetRow = sheet.CreateRow(sheetRowIndex);
            int ColumnIndex = 0;

            foreach (DataColumn header in dt.Columns)
            {
                //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)

                //CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                CreateCellNew(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                ColumnIndex = ColumnIndex + 1;                               
            }

           // MessageBox.Show("Progress 1");

            //-----------------------------------------
            //Add column values 
            sheetRowIndex = sheetRowIndex + 1;
            sheetRow = sheet.CreateRow(sheetRowIndex);
            ColumnIndex = 0;

            //MessageBox.Show("Columns ", dt.Columns.ToString());
            //MessageBox.Show("rowindex  ", rowindex.ToString());
            //MessageBox.Show("ColumnIndex  ", ColumnIndex.ToString());

            foreach (DataColumn header in dt.Columns)
            {
                string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                
                //MessageBox.Show("rowindex  ", rowindex.ToString());
                //MessageBox.Show("ColumnIndex  ", ColumnIndex.ToString());
                //MessageBox.Show("columnvalue ", dt.Rows[rowindex][ColumnIndex].ToString());


                if (ColumnIndex == 32)
                {
                    //string filter = columnvalue.ToString();
                    //string[] filterRemove = filter.Split('-');

                    //string Date1 = filterRemove[0];
                    //string Month1 = filterRemove[1];
                    //string TempString = filterRemove[2];

                    //string[] filterRemovePart2 = TempString.Split(' ');

                    //string FindalDate = Month1 + "-" + Date1 + "-" + filterRemovePart2[0];

                    //sheetRow.CreateCell(ColumnIndex).SetCellValue(FindalDate);

                    sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                    ColumnIndex = ColumnIndex + 1;
                }
                else
                {
                    sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                    ColumnIndex = ColumnIndex + 1;
                }
                //ColumnIndex = ColumnIndex + 1;

            }

            //MessageBox.Show("Progress 2");



            //private object SetSheetDatatableNew(DataTable dt, HSSFCellStyle borderedCellStyle, ref Int32 sheetRowIndex, ref ISheet sheet)
            
                sheetRowIndex = sheetRowIndex + 1;
            ////Get CompanyID
            string companyID = dt.Rows[rowindex]["CompanyID"].ToString();

            //set Contact sub grid data 
            //------------------------------------------------------
            DataTable SubDatatable = GetSubContactGridData(companyID);

            //SetSheetDatatable(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);
            SetSheetDatatableNew(ref SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);

            //-------------------------------------------------------
            return null;




        }

        private object SetSheetDatatableNew(ref DataTable SubDatatable, HSSFCellStyle borderedCellStyle, ref Int32 sheetRowIndex, ref ISheet sheet)
        {

            if (SubDatatable.Columns.Count > 0)
            {
                sheetRowIndex = sheetRowIndex + 1;
                int ColumnIndex = 1;
                var sheetRow = sheet.CreateRow(sheetRowIndex);
                foreach (DataColumn header in SubDatatable.Columns)
                {
                    //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                    //sheet.SetDefaultColumnStyle(ColumnIndex, borderedCellStyle)
                    //CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                    //MessageBox.Show("sheetRow = " + sheetRow.ToString());
                    //MessageBox.Show("ColumnIndex = " + ColumnIndex.ToString());
                    //MessageBox.Show("sheetRow = " + header.ColumnName.ToString());

                    CreateCellNew(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                    ColumnIndex = ColumnIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }

            if (SubDatatable.Rows.Count > 0)
            {

                for (int Rowindex = 1; Rowindex <= SubDatatable.Rows.Count; Rowindex++)
                {
                    //add column header
                    var sheetRow = sheet.CreateRow(sheetRowIndex);
                    int ColumnIndex = 1;

                    ColumnIndex = 1;
                    foreach (DataColumn Columns in SubDatatable.Columns)
                    {
                        string columnvalue = SubDatatable.Rows[Rowindex - 1][ColumnIndex - 1].ToString();
                        sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                        //sheet.SetDefaultColumnStyle(ColumnIndex, borderedCellStyle)

                        ColumnIndex = ColumnIndex + 1;
                    }
                    sheetRowIndex = sheetRowIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }
            return null;
        }



        private void CreateCell(IRow CurrentRow, int CellIndex, string Value, XSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
        }

        private void CreateCellNew(IRow CurrentRow, int CellIndex, string Value, HSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;             
        }

        

        private object SetSheetDatatable(DataTable dt, XSSFCellStyle borderedCellStyle, ref Int32 sheetRowIndex, ref ISheet sheet)
        {

            if (dt.Columns.Count > 0)
            {
                sheetRowIndex = sheetRowIndex + 1;
                int ColumnIndex = 1;
                var sheetRow = sheet.CreateRow(sheetRowIndex);
                foreach (DataColumn header in dt.Columns)
                {
                    //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                    //sheet.SetDefaultColumnStyle(ColumnIndex, borderedCellStyle)
                    CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                    ColumnIndex = ColumnIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }

            if (dt.Rows.Count > 0)
            {

                for (int Rowindex = 1; Rowindex <= dt.Rows.Count; Rowindex++)
                {
                    //add column header
                    var sheetRow = sheet.CreateRow(sheetRowIndex);
                    int ColumnIndex = 1;

                    ColumnIndex = 1;
                    foreach (DataColumn Columns in dt.Columns)
                    {
                        string columnvalue = dt.Rows[Rowindex - 1][ColumnIndex - 1].ToString();
                        sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                        //sheet.SetDefaultColumnStyle(ColumnIndex, borderedCellStyle)

                        ColumnIndex = ColumnIndex + 1;
                    }
                    sheetRowIndex = sheetRowIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }
            return null;
        }

        private System.Data.DataTable GetContactData()
        {
            string queryString = "SELECT Company.CompanyID, Company.CompanyName, Company.Address, Company.City, Company.State, Company.Country, Company.PostalCode, Company.DotInsuranceExp,Company.AirborneExpNUM,Company.IBMNUM, Company.FedExNUM, Company.UserName, Company.Password,             Company.Age0Action, Company.Age15Action, Company.Age30Action, Company.Age45Action, Company.Age60Action, Company.Age75Action, Company.Age90Action, Company.Age105Action, ColorSetting_7.ColorCode AS Age0ActionColor, ColorSetting.ColorCode AS Age15ActionColor, ColorSetting_1.ColorCode AS Age30ActionColor,            ColorSetting_2.ColorCode AS Age45ActionColor, ColorSetting_3.ColorCode AS Age60ActionColor, ColorSetting_4.ColorCode AS Age75ActionColor,              ColorSetting_5.ColorCode AS Age90ActionColor, ColorSetting_6.ColorCode AS Age105ActionColor,Company.IsDisable,Company.CompanyNo, Company.DBadClient, Company.CreditPassDate,(CASE WHEN Company.TableVersionId=0 OR Company.TableVersionId IS NULL THEN 0 ELSE Company.TableVersionId END) AS TableVersionId,ISNULL(Company.ServRate,1) as ServRate, Company.OfficePhone, Company.OfficeFax,(CASE WHEN Company.TypicalInvoiceType='' OR Company.TypicalInvoiceType IS NULL THEN 'Item' ELSE Company.TypicalInvoiceType END) AS TypicalInvoiceType  FROM  ColorSetting AS ColorSetting_6 RIGHT OUTER JOIN Company ON ColorSetting_6.ColorID = Company.Age105Action LEFT OUTER JOIN ColorSetting AS ColorSetting_5 ON Company.Age90Action = ColorSetting_5.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_7 ON Company.Age0Action = ColorSetting_7.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_4 ON Company.Age75Action = ColorSetting_4.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_3 ON Company.Age60Action = ColorSetting_3.ColorID LEFT OUTER JOIN ColorSetting AS ColorSetting_2 ON Company.Age45Action = ColorSetting_2.ColorID LEFT OUTER JOIN  ColorSetting AS ColorSetting_1 ON Company.Age30Action = ColorSetting_1.ColorID LEFT OUTER JOIN ColorSetting ON Company.Age15Action = ColorSetting.ColorID where Company.CompanyID > 0 and (Company.IsDelete=0 or Company.IsDelete is null) order by Company.CompanyID";

            System.Data.DataTable dtJL = new System.Data.DataTable();



            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<CompanyColor>(queryString).ToList();
            //    dtJL = Program.ToDataTable<CompanyColor>((List<CompanyColor>)data);
            //}


            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                

                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<CompanyColor>(queryString).ToList();
                    dtJL = Program.ToDataTable<CompanyColor>((List<CompanyColor>)data);
                }

            }
            else
            {

                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<CompanyColor>(queryString).ToList();
                    dtJL = Program.ToDataTable<CompanyColor>((List<CompanyColor>)data);
                }
            }

            return dtJL;
        }

        private System.Data.DataTable GetSubContactGridData(string companyID)
        {
            string queryString = "SELECT FirstName, MiddleName, LastName, ContactTitle,Address, City,State, PostalCode,  Country, MobilePhone, EmailAddress, Notes, SpecialRiggerNUM, MasterRiggerNUM,  SpecialSignNUM, MasterSignNUM, Prefix, Suffix,  HomePhone, WorkPhone, FaxNumber, AlternativePhone, FieldPhone,  Pager ,Accounting FROM  Contacts where CompanyID= " + companyID + " and (IsDelete=0 or IsDelete is null)  order by ContactsID";
            System.Data.DataTable dtJL = new System.Data.DataTable();



            //using (EFDbContext db = new EFDbContext())
            //{
            //    //var data = db.Database.SqlQuery<CompanyColor>(queryString).ToList();
            //    //dtJL = Program.ToDataTable<CompanyColor>((List<CompanyColor>)data);


            //    var data = db.Database.SqlQuery<ContactsData2>(queryString).ToList();
            //    dtJL = Program.ToDataTable<ContactsData2>((List<ContactsData2>)data);
            //    //ContactsData2
            //}

            if (Properties.Settings.Default.IsTestDatabase == true)
            {                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    //var data = db.Database.SqlQuery<CompanyColor>(queryString).ToList();
                    //dtJL = Program.ToDataTable<CompanyColor>((List<CompanyColor>)data);


                    var data = db.Database.SqlQuery<ContactsData2>(queryString).ToList();
                    dtJL = Program.ToDataTable<ContactsData2>((List<ContactsData2>)data);
                    //ContactsData2
                }
            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    //var data = db.Database.SqlQuery<CompanyColor>(queryString).ToList();
                    //dtJL = Program.ToDataTable<CompanyColor>((List<CompanyColor>)data);


                    var data = db.Database.SqlQuery<ContactsData2>(queryString).ToList();
                    dtJL = Program.ToDataTable<ContactsData2>((List<ContactsData2>)data);
                    //ContactsData2
                }
            }

            return dtJL;
        }

        public void ChangeColorGrd()
        {
            //		Dim r As DataGridViewRow
            foreach (DataGridViewRow r in grdCompany.Rows)
            {
                for (Int16 i = 21; i <= 29; i++)
                {
                    try
                    {
                        int colValue = Convert.ToInt32(grdCompany.Rows[r.Index].Cells[i - 8].Value);
                        if (colValue == 6)
                        {
                            //grdCompany.Rows[r.Index].Cells[i].Style.BackColor = Color.Blue
                            grdCompany.Rows[r.Index].Cells[i].Style.BackColor = Color.Blue;
                            grdCompany.Rows[r.Index].Cells[i].Style.SelectionBackColor = Color.Blue;
                            grdCompany.Rows[r.Index].Cells[i].Value = "";
                        }

                        if (colValue == 1)
                        {
                            grdCompany.Rows[r.Index].Cells[i].Style.BackColor = Color.Green;
                            grdCompany.Rows[r.Index].Cells[i].Style.SelectionBackColor = Color.Green;
                            grdCompany.Rows[r.Index].Cells[i].Value = "";
                        }
                        if (colValue == 2)
                        {
                            grdCompany.Rows[r.Index].Cells[i].Style.BackColor = Color.Orange;
                            grdCompany.Rows[r.Index].Cells[i].Style.SelectionBackColor = Color.Orange;
                            grdCompany.Rows[r.Index].Cells[i].Value = "";
                        }
                        if (colValue == 3)
                        {
                            grdCompany.Rows[r.Index].Cells[i].Style.BackColor = Color.Yellow;
                            grdCompany.Rows[r.Index].Cells[i].Style.SelectionBackColor = Color.Yellow;
                            grdCompany.Rows[r.Index].Cells[i].Value = "";
                        }
                        if (colValue == 4)
                        {
                            grdCompany.Rows[r.Index].Cells[i].Style.BackColor = Color.Red;
                            grdCompany.Rows[r.Index].Cells[i].Style.SelectionBackColor = Color.Red;
                            grdCompany.Rows[r.Index].Cells[i].Value = "";
                        }
                        if (colValue == 5)
                        {
                            grdCompany.Rows[r.Index].Cells[i].Style.BackColor = Color.Black;
                            grdCompany.Rows[r.Index].Cells[i].Style.SelectionBackColor = Color.Black;
                            grdCompany.Rows[r.Index].Cells[i].Value = "";
                        }

                        //MessageBox.Show("15");

                        //if (Convert.ToBoolean(grdCompany.Rows[r.Index].Cells["IsDisable"].Value) == true || (CheckState)grdCompany.Rows[r.Index].Cells["IsDisable"].Value == CheckState.Checked)
                        //{
                        //    grdCompany.Rows[r.Index].DefaultCellStyle.BackColor = Color.Gray;
                        //    grdCompany.Rows[r.Index].DefaultCellStyle.SelectionBackColor = Color.Gray;
                        //}

                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message.ToString());
                    }
                }
            }
        }

        //private object CreateContactPassword(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)
        private object CreateContactPassword(DataTable dt, HSSFCellStyle  borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet,HSSFCellStyle HeaderBorderedCellStyle2)
        {

            //add column header
            var sheetRow = sheet.CreateRow(sheetRowIndex);
            int ColumnIndex = 0;

            //foreach (DataColumn header in dt.Columns)
            //{
            //    //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
            //    CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
            //    ColumnIndex = ColumnIndex + 1;
            //}

            //-----------------------------------------
            //Add column values 
            //sheetRowIndex = sheetRowIndex + 1;
            sheetRow = sheet.CreateRow(sheetRowIndex);
            //ColumnIndex = 0;

            //MessageBox.Show(dt.Columns.Count.ToString());

            foreach (DataColumn header in dt.Columns)
            {

                if (sheetRowIndex == 0)
                {

                    //XSSFFont myFont = (XSSFFont)workBook.CreateFont();
                    //myFont.FontHeightInPoints = 11;
                    //myFont.FontName = "Tahoma";
                    //myFont.IsBold = true;
                    //myFont.Color = IndexedColors.Blue.Index;

                    //XSSFCellStyle HeaderBorderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();
                    //HeaderBorderedCellStyle.SetFont(myFont);

                    //HeaderBorderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                    //HeaderBorderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                    //HeaderBorderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                    //HeaderBorderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                    //HeaderBorderedCellStyle.VerticalAlignment = VerticalAlignment.Center;

                    //ICell Cell1 = sheetRow.CreateCell(0);
                    //Cell1.SetCellValue("CompanyName");
                    //Cell1.CellStyle = HeaderBorderedCellStyle;

                    //ICell Cell2 = sheetRow.CreateCell(1);
                    //Cell2.SetCellValue("UserID");
                    //Cell2.CellStyle = HeaderBorderedCellStyle;

                    //ICell Cell3 = sheetRow.CreateCell(2);
                    //Cell3.SetCellValue("Password");
                    //Cell3.CellStyle = HeaderBorderedCellStyle;

                                   
                }

                else
                {
                    //XSSFFont myFont2 = (XSSFFont)workBook.CreateFont();
                    //myFont2.FontHeightInPoints = 10;
                    //myFont2.FontName = "Tahoma";
                
                    //XSSFCellStyle HeaderBorderedCellStyle2 = (XSSFCellStyle)workBook.CreateCellStyle();
                    //HeaderBorderedCellStyle2.SetFont(myFont2);
                    //HeaderBorderedCellStyle2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

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
                        Cell4.CellStyle = HeaderBorderedCellStyle2;
                    }

                    if (ColumnIndex == 1)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell5 = sheetRow.CreateCell(ColumnIndex);
                        //Cell5.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //Cell5.SetCellValue(columnvalue);
                        //Cell5.CellStyle = HeaderBorderedCellStyle2;

                        string columnvalue7 = dt.Rows[rowindex][ColumnIndex].ToString();

                        ICell Cell7 = sheetRow.CreateCell(ColumnIndex);

                        int value7;
                        if (int.TryParse(dt.Rows[rowindex][ColumnIndex].ToString(), out value7))
                        {

                            Cell7.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                            int value8 = int.Parse(columnvalue);
                            Cell7.SetCellValue(value8);
                        }
                        else
                        {
                            Cell7.SetCellType(NPOI.SS.UserModel.CellType.String);
                            Cell7.SetCellValue(Convert.ToString(columnvalue));

                        }
                        Cell7.CellStyle = HeaderBorderedCellStyle2;
                    }


                    if (ColumnIndex == 2)
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
                        Cell6.CellStyle = HeaderBorderedCellStyle2;
                    }
                }

                ColumnIndex = ColumnIndex + 1;

                //string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();
                //sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);

                //ColumnIndex = ColumnIndex + 1;
            }


            sheetRowIndex = sheetRowIndex + 1;



            ////Get CompanyID
            //string companyID = dt.Rows[rowindex]["CompanyID"].ToString();

            ////set Contact sub grid data 
            ////------------------------------------------------------
            //DataTable SubDatatable = GetSubContactGridData(companyID);

            //SetSheetDatatable(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);

            ////-------------------------------------------------------
            return null;
        }

        #endregion

        private void grdCompany_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void grdCompany_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //MessageBox.Show(e.ColumnIndex.ToString());

                if (e.ColumnIndex == 34 && e.RowIndex > -1)
                {
                    //DataGridViewCheckBoxCell checkbox = (DataGridViewCheckBoxCell)grdFormInfo.CurrentCell;
                    //bool isChecked = (bool)checkbox.EditedFormattedValue;

                    DataGridViewComboBoxCell checkbox = (DataGridViewComboBoxCell)grdCompany.CurrentCell;
                    //bool isChecked = (bool)checkbox.EditedFormattedValue;
                    object ischecked = checkbox.EditedFormattedValue;
                    object ischecked2 = checkbox.Value;

                    //MessageBox.Show(ischecked2.ToString());

                    //((DataGridView)sender).CurrentCell.Value

                    //MessageBox.Show(isChecked.ToString());
                }

            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void pnlBtnCompany_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}