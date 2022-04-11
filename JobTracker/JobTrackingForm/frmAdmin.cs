using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace JobTracker.JobTrackingForm
{
    public partial class frmAdmin : Form
    {

        private SqlConnection WebSqlCon;
        private DataSet Dataset = new DataSet();
        private SqlCommand Cmd;
        private DataTable dt;
        private DataSet ds1 = new DataSet();
        private int DeletedRows;
        private int UpdatedRows;
        private int InsertedRows;
        private DataTable dtProgress = new DataTable();
        private int Count = 0;
        private static frmAdmin _Instance;

        public static frmAdmin Instance
        {
            get
            {
                if (_Instance is null || _Instance.IsDisposed)
                {
                    _Instance = new frmAdmin();
                }

                return _Instance;
            }
        }
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void FillLocalListBox()
        {
            chkLbxLocal.Items.Clear();
            string Query = "select name from sys.tables Where name in ('Invoice','JobTracking','JobList','MasterTrackSet','MasterTrackSubItem','Company','Contacts'	)  union select 'All' as name order by name";
            var localDt = new System.Data.DataTable();
            var QueryHandler = new DataAccessLayer();
            localDt = QueryHandler.Filldatatable(Query);
            try
            {
                for (int i = 0, loopTo = localDt.Rows.Count - 1; i <= loopTo; i++)
                    chkLbxLocal.Items.Add(localDt.Rows[i]["name"].ToString());
            }
            catch (Exception ex)
            {
            }
        }

        private void frmAdmin_Disposed(object sender, EventArgs e)
        {
        }

        private void frmAdmin_Load(object sender, EventArgs e)
        {
            FillLocalListBox();
            // 
            WebSqlCon = new SqlConnection(global::JobTracker.Properties.Settings.Default.Setting.ToString());
            // chkReminder.Checked = SetEmailReminder()
            checkStatus();
            if (chkReminder.CheckState == CheckState.Checked | chkReminder.Checked == true)
            {
                pnlEmailREminder.Visible = true;
                PnlSenderEmail.Visible = true;
            }
            else
            {
                pnlEmailREminder.Visible = false;
                PnlSenderEmail.Visible = false;
            }
            GetEmailAddress();
        }

        protected void ApplicationBusy(bool flag)
        {
            if (flag == true)
            {
                Cursor.Current = Cursors.WaitCursor;
                picProgress.Visible = true;
            }
            // btnWait.Visible = True
            // ProgressBar1.Visible = True
            else
            {
                Cursor.Current = Cursors.Default;
                picProgress.Visible = false;
                // btnWait.Visible = False
                // ProgressBar1.Visible = False
            }

            btnUpload.Enabled = !flag;
            chkLbxLocal.Enabled = !flag;
            chkLbxWeb.Enabled = !flag;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            picProgress.Visible = true;
            ApplicationBusy(true);
            DeletedRows = 0;
            InsertedRows = 0;
            UpdatedRows = 0;
            lblDeletedRecord.Text = string.Empty;
            lblInsertedRecord.Text = string.Empty;
            lbUpdatedRecord.Text = string.Empty;
            chkLbxWeb.Items.Clear();
            var DtProgressBar = new DataAccessLayer();
            if (chkLbxLocal.GetItemCheckState(0) == CheckState.Checked)
            {
                for (int i = 1, loopTo = chkLbxLocal.Items.Count - 1; i <= loopTo; i++)
                {
                    string Query = "select * from " + chkLbxLocal.Items[i].ToString() + " where (IsChange=1 or IsNewRecord=1 or IsDelete=1 )";
                    dtProgress = DtProgressBar.Filldatatable(Query);
                    try
                    {
                        if (dtProgress.Rows.Count > 0)
                        {
                            Count = Count + dtProgress.Rows.Count;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            else
            {
                for (int i = 1, loopTo1 = chkLbxLocal.Items.Count - 1; i <= loopTo1; i++)
                {
                    if (chkLbxLocal.GetItemCheckState(i) == CheckState.Checked)
                    {
                        string Query = "select * from " + chkLbxLocal.Items[i].ToString() + " where (IsChange=1 or IsNewRecord=1 or IsDelete=1 )";
                        // Dim DtProgressBar As New DataAccessLayer
                        dtProgress = DtProgressBar.Filldatatable(Query);
                        try
                        {
                            if (dtProgress.Rows.Count > 0)
                            {
                                Count = Count + dtProgress.Rows.Count;
                            }
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
            }

            // Timer1.Enabled = True
            // Timer1.Start()
            // System.Threading.Thread.Sleep(1000)
            BackgroundWorker1.RunWorkerAsync();
            // Threading.Thread.Sleep(1000)
            if (chkLbxLocal.GetItemCheckState(0) == CheckState.Checked)
            {
                for (int i = 1, loopTo2 = chkLbxLocal.Items.Count - 1; i <= loopTo2; i++)
                {
                    SelecttionTable(chkLbxLocal.Items[i].ToString());
                    chkLbxWeb.Items.Add(chkLbxLocal.Items[i].ToString());
                }
            }
            else
            {
                for (int i = 1, loopTo3 = chkLbxLocal.Items.Count - 1; i <= loopTo3; i++)
                {
                    if (chkLbxLocal.GetItemCheckState(i) == CheckState.Checked)
                    {
                        SelecttionTable(chkLbxLocal.Items[i].ToString());
                        chkLbxWeb.Items.Add(chkLbxLocal.Items[i].ToString());
                    }
                }
            }
            // Timer1.Stop()

            lblDeletedRecord.Text = DeletedRows.ToString();
            lblInsertedRecord.Text = InsertedRows.ToString();
            lbUpdatedRecord.Text = UpdatedRows.ToString();
            if (lblDeletedRecord.Text != string.Empty | lblInsertedRecord.Text != string.Empty | lbUpdatedRecord.Text != string.Empty)
            {
                ApplicationBusy(false);
                KryptonMessageBox.Show("Upload SuccessFully", "Upload");
            }
            // ApplicationBusy(False)
        }

        private void chkLbxLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdLocalTableData.DataSource = null;
            try
            {
                var DsHendler = new DataAccessLayer();
                if (chkLbxLocal.GetItemCheckState(0) == CheckState.Checked)
                {
                    for (int i = 1, loopTo = chkLbxLocal.Items.Count - 1; i <= loopTo; i++)
                        chkLbxLocal.SetItemCheckState(i, CheckState.Unchecked);
                }

                if (chkLbxLocal.GetItemCheckState(chkLbxLocal.SelectedIndex) == CheckState.Checked)
                {
                    if (chkLbxLocal.GetItemCheckState(0) == CheckState.Checked)
                    {
                        return;
                    }

                    string Query = "select * from " + chkLbxLocal.Items[chkLbxLocal.SelectedIndex].ToString() + " where (IsChange=1 or IsNewRecord=1 or IsDelete=1 )";
                    // Dim ds As New DataSet
                    dt = new DataTable();
                    dt = DsHendler.Filldatatable(Query);
                    grdLocalTableData.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
            }
            // grdLocalTableData.DataSource = Nothing
        }

        private void CommunityBoard()
        {
            // insert
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            // Cmd = New SqlCommand("", WebSqlCon)
            CbDt = StMethod.GetListDT<CBoardData>("SELECT * FROM CommunityBoard where IsNewRecord=1");
            string query;
            try
            {
                query = "INSERT INTO CommunityBoard (CommunityBoardNum, Address, City, State, Zip) VALUES (@CommunityBoardNum, @Address, @City, @State, @Zip) ";
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@CommunityBoardNum", CbDt.Rows[i]["CommunityBoardNum"].ToString()));
                    Param.Add(new SqlParameter("@Address", CbDt.Rows[i]["Address"].ToString()));
                    Param.Add(new SqlParameter("@City", CbDt.Rows[i]["City"].ToString()));
                    Param.Add(new SqlParameter("@State", CbDt.Rows[i]["State"].ToString()));
                    Param.Add(new SqlParameter("@Zip", CbDt.Rows[i]["Zip"].ToString()));
                    // //wEB TABLE UPDATE
                    InsertedRows = InsertedRows + 1;
                    // ///LOCAL TABALE UPDATE
                    StMethod.UpdateRecord("UPDATE CommunityBoard SET IsNewRecord=0 WHERE CommunityBoardID=" + CbDt.Rows[i]["CommunityBoardID"].ToString() + " ");
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }

            // ***************************Update**********************************
            CbDt = StMethod.GetListDT<CBoardData>("SELECT * FROM CommunityBoard where IsChange=1");
            WebTable = FillWebTable("SELECT * FROM CommunityBoard Where IsChange=1");
            query = "UPDATE CommunityBoard set CommunityBoardNum=@CommunityBoardNum, Address=@Address, City=@City, State=@City, Zip=@Zip,IsChange=@IsChange WHERE CommunityBoardID=@CommunityBoardID";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = WebTable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["CommunityBoardID"].ToString() == WebTable.Rows[j]["CommunityBoardID"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == WebTable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(WebTable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    StMethod.UpdateRecord("UPDATE CommunityBoard SET IsChange=0 WHERE CommunityBoardID=" + CbDt.Rows[i]["CommunityBoardID"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@CommunityBoardNum", CbDt.Rows[i]["CommunityBoardNum"].ToString()));
                    Param.Add(new SqlParameter("@Address", CbDt.Rows[i]["Address"].ToString()));
                    Param.Add(new SqlParameter("@City", CbDt.Rows[i]["City"].ToString()));
                    Param.Add(new SqlParameter("@State", CbDt.Rows[i]["State"].ToString()));
                    Param.Add(new SqlParameter("@Zip", CbDt.Rows[i]["Zip"].ToString()));
                    Param.Add(new SqlParameter("@CommunityBoardID", CbDt.Rows[i]["CommunityBoardID"]));
                    // //wEB TABLE UPDATE
                    StMethod.UpdateRecord(query, Param);
                    UpdatedRows = UpdatedRows + 1;
                    // ///LOCAL TABALE UPDATE
                    StMethod.UpdateRecord("UPDATE CommunityBoard SET IsChange=0 WHERE CommunityBoardID=" + CbDt.Rows[i]["CommunityBoardID"].ToString() + " ");
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            // ***************************Delete**********************************
            CbDt = StMethod.GetListDT<CBoardData>("SELECT * FROM CommunityBoard where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    StMethod.UpdateRecord("delete CommunityBoard where CommunityBoardID=" + CbDt.Rows[i]["CommunityBoardID"].ToString() + "");

                    // //Local Table
                    StMethod.UpdateRecord("delete CommunityBoard where CommunityBoardID=" + CbDt.Rows[i]["CommunityBoardID"].ToString() + " ");
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
        }

        public void Company()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            // Cmd = New SqlCommand("", WebSqlCon)
            CbDt = StMethod.GetListDT<CompanyInfo>("SELECT * FROM Company where IsNewRecord=1");
            string query;
            // *********************'insert******************************
            try
            {
                query = "Insert into Company(CompanyName,Address,City,State,Country, PostalCode, DotInsuranceExp, AirborneExpNUM, IBMNUM, FedExNUM,UserName,Password ) values (@CompanyName,@Address,@City,@State,@Country, @PostalCode, @DotInsuranceExp, @AirborneExpNUM, @IBMNUM, @FedExNUM,@UserName,@Password)";
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@CompanyName", CbDt.Rows[i]["CompanyName"].ToString()));
                    Param.Add(new SqlParameter("@Address", CbDt.Rows[i]["Address"].ToString()));
                    Param.Add(new SqlParameter("@City", CbDt.Rows[i]["City"].ToString()));
                    Param.Add(new SqlParameter("@State", CbDt.Rows[i]["State"].ToString()));
                    Param.Add(new SqlParameter("@Country", CbDt.Rows[i]["Country"].ToString()));
                    Param.Add(new SqlParameter("@PostalCode", CbDt.Rows[i]["PostalCode"].ToString()));
                    Param.Add(new SqlParameter("@DotInsuranceExp", CbDt.Rows[i]["DotInsuranceExp"].ToString()));
                    Param.Add(new SqlParameter("@AirborneExpNUM", CbDt.Rows[i]["AirborneExpNUM"].ToString()));
                    Param.Add(new SqlParameter("@IBMNUM", CbDt.Rows[i]["IBMNUM"].ToString()));
                    Param.Add(new SqlParameter("@FedExNUM", CbDt.Rows[i]["FedExNUM"].ToString()));
                    Param.Add(new SqlParameter("@UserName", CbDt.Rows[i]["UserName"].ToString()));
                    Param.Add(new SqlParameter("@Password", CbDt.Rows[i]["Password"].ToString()));
                    // Insert at web server
                    StMethod.UpdateRecord(query, Param);
                    // Change at local pc
                    StMethod.UpdateRecord("UPDATE Company SET IsNewRecord=0 WHERE CompanyID=" + CbDt.Rows[i]["CompanyID"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }

            // ******************************************Update ***********************************************
            CbDt = StMethod.GetListDT<CompanyInfo>("SELECT * FROM Company where IsChange=1");
            WebTable = FillWebTable("SELECT * FROM Company where IsChange=1");
            query = "update  Company set CompanyName= @CompanyName,Address=@Address,City=@City,State= @State,Country=@Country, PostalCode=@PostalCode,DotInsuranceExp=@DotInsuranceExp , AirborneExpNUM=@AirborneExpNUM,IBMNUM= @IBMNUM,FedExNUM= @FedExNUM,IsChange=@IsChange,UserName=@UserName,Password=@Password where   CompanyID=  @CompanyID";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = WebTable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["CompanyID"].ToString() == WebTable.Rows[j]["CompanyID"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == WebTable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(WebTable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    StMethod.UpdateRecord("UPDATE Company SET IsChange=0 WHERE CompanyID=" + CbDt.Rows[i]["CompanyID"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@CompanyName", CbDt.Rows[i]["CompanyName"].ToString()));
                    Param.Add(new SqlParameter("@Address", CbDt.Rows[i]["Address"].ToString()));
                    Param.Add(new SqlParameter("@City", CbDt.Rows[i]["City"].ToString()));
                    Param.Add(new SqlParameter("@State", CbDt.Rows[i]["State"].ToString()));
                    Param.Add(new SqlParameter("@Country", CbDt.Rows[i]["Country"].ToString()));
                    Param.Add(new SqlParameter("@PostalCode", CbDt.Rows[i]["PostalCode"].ToString()));
                    Param.Add(new SqlParameter("@DotInsuranceExp", CbDt.Rows[i]["DotInsuranceExp"].ToString()));
                    Param.Add(new SqlParameter("@AirborneExpNUM", CbDt.Rows[i]["AirborneExpNUM"].ToString()));
                    Param.Add(new SqlParameter("@IBMNUM", CbDt.Rows[i]["IBMNUM"].ToString()));
                    Param.Add(new SqlParameter("@FedExNUM", CbDt.Rows[i]["FedExNUM"].ToString()));
                    Param.Add(new SqlParameter("@CompanyID", CbDt.Rows[i]["CompanyID"].ToString()));
                    Param.Add(new SqlParameter("@UserName", CbDt.Rows[i]["UserName"].ToString()));
                    Param.Add(new SqlParameter("@Password", CbDt.Rows[i]["Password"].ToString()));
                    // Update at Web server
                    StMethod.UpdateRecord(query, Param);
                    // Update at localsystem
                    StMethod.UpdateRecord("UPDATE Company SET IsChange=0 WHERE CompanyID=" + CbDt.Rows[i]["CompanyID"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }

            // ***************************Delete*******************************
            CbDt = StMethod.GetListDT<CompanyInfo>("SELECT * FROM Company where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    StMethod.UpdateRecord( "delete Company where CompanyID=" + CbDt.Rows[i]["CompanyID"].ToString() + "");
                    // Update Web Server
                    // //Local Table
                    StMethod.UpdateRecord("delete Company WHERE CompanyID=" + CbDt.Rows[i]["CompanyID"].ToString() + " ");
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
        }

        private void Contacts()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            // Cmd = New SqlCommand("", WebSqlCon)
            CbDt = StMethod.GetListDT<ContactsData>("SELECT * FROM Contacts where IsNewRecord=1");
            string query;
            query = " Insert into Contacts(CompanyID, FirstName, MiddleName, LastName, ContactTitle, MobilePhone, EmailAddress, Notes, SpecialRiggerNUM, MasterRiggerNUM,  SpecialSignNUM, MasterSignNUM, Prefix, Suffix, Address, City, PostalCode, State, Country, HomePhone, WorkPhone, FaxNumber, AlternativePhone, FieldPhone,  Pager) values (@CompanyID,@FirstName, @MiddleName, @LastName, @ContactTitle, @MobilePhone, @EmailAddress, @Notes, @SpecialRiggerNUM, @MasterRiggerNUM,  @SpecialSignNUM, @MasterSignNUM, @Prefix, @Suffix, @Address, @City, @PostalCode, @State, @Country, @HomePhone, @WorkPhone, @FaxNumber, @AlternativePhone, @FieldPhone,  @Pager)";
            try
            {
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@CompanyID", CbDt.Rows[i]["CompanyID"].ToString()));
                    Param.Add(new SqlParameter("@FirstName", CbDt.Rows[i]["FirstName"].ToString()));
                    Param.Add(new SqlParameter("@MiddleName", CbDt.Rows[i]["MiddleName"].ToString()));
                    Param.Add(new SqlParameter("@LastName", CbDt.Rows[i]["LastName"].ToString()));
                    Param.Add(new SqlParameter("@ContactTitle", CbDt.Rows[i]["ContactTitle"].ToString()));
                    Param.Add(new SqlParameter("@MobilePhone", CbDt.Rows[i]["MobilePhone"].ToString()));
                    Param.Add(new SqlParameter("@EmailAddress", CbDt.Rows[i]["EmailAddress"].ToString()));
                    Param.Add(new SqlParameter("@Notes", CbDt.Rows[i]["Notes"].ToString()));
                    Param.Add(new SqlParameter("@SpecialRiggerNUM", CbDt.Rows[i]["SpecialRiggerNUM"].ToString()));
                    Param.Add(new SqlParameter("@MasterRiggerNUM", CbDt.Rows[i]["MasterRiggerNUM"].ToString()));
                    Param.Add(new SqlParameter("@SpecialSignNUM", CbDt.Rows[i]["SpecialSignNUM"].ToString()));
                    Param.Add(new SqlParameter("@MasterSignNUM", CbDt.Rows[i]["MasterSignNUM"].ToString()));
                    Param.Add(new SqlParameter("@Prefix", CbDt.Rows[i]["Prefix"].ToString()));
                    Param.Add(new SqlParameter("@Suffix", CbDt.Rows[i]["Suffix"].ToString()));
                    Param.Add(new SqlParameter("@Address", CbDt.Rows[i]["Address"].ToString()));
                    Param.Add(new SqlParameter("@City", CbDt.Rows[i]["City"].ToString()));
                    Param.Add(new SqlParameter("@PostalCode", CbDt.Rows[i]["PostalCode"].ToString()));
                    Param.Add(new SqlParameter("@State", CbDt.Rows[i]["State"].ToString()));
                    Param.Add(new SqlParameter("@Country", CbDt.Rows[i]["Country"].ToString()));
                    Param.Add(new SqlParameter("@HomePhone", CbDt.Rows[i]["HomePhone"].ToString()));
                    Param.Add(new SqlParameter("@WorkPhone", CbDt.Rows[i]["WorkPhone"].ToString()));
                    Param.Add(new SqlParameter("@FaxNumber", CbDt.Rows[i]["FaxNumber"].ToString()));
                    Param.Add(new SqlParameter("@AlternativePhone", CbDt.Rows[i]["AlternativePhone"].ToString()));
                    Param.Add(new SqlParameter("@FieldPhone", CbDt.Rows[i]["FieldPhone"].ToString()));
                    Param.Add(new SqlParameter("@Pager", CbDt.Rows[i]["Pager"].ToString()));
                    // //Update at webserver system
                    StMethod.UpdateRecord(query, Param);
                    // //Local update
                    StMethod.UpdateRecord("UPDATE Contacts SET IsNewRecord=0 WHERE ContactsID=" + CbDt.Rows[i]["ContactsID"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            // ***********************************Update*******************************
            CbDt = StMethod.GetListDT<ContactsData>("SELECT * FROM Contacts where IsChange=1");
            WebTable = StMethod.GetListDT<ContactsData>("SELECT * FROM Contacts where IsChange=1");
            query = "update  Contacts set FirstName= @FirstName,MiddleName=@MiddleName,LastName=@LastName,ContactTitle= @ContactTitle,MobilePhone=@MobilePhone, EmailAddress=@EmailAddress,Notes=@Notes,SpecialRiggerNUM=@SpecialRiggerNUM , MasterRiggerNUM=@MasterRiggerNUM,SpecialSignNUM= @SpecialSignNUM,MasterSignNUM=@MasterSignNUM,Prefix=@Prefix,Suffix=@Suffix,Address=@Address,City=@City,PostalCode=@PostalCode,State=@State,Country=@Country,HomePhone=@HomePhone,WorkPhone=@WorkPhone,FaxNumber=@FaxNumber,AlternativePhone=@AlternativePhone,FieldPhone=@FieldPhone,Pager=@Pager,IsChange=@IsChange where   ContactsID=@ContactsID";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = WebTable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["ContactsID"].ToString() == WebTable.Rows[j]["ContactsID"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == WebTable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(WebTable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    StMethod.UpdateRecord("UPDATE Contacts SET IsChange=0 WHERE ContactsID=" + CbDt.Rows[i]["ContactsID"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@ContactsID", CbDt.Rows[i]["ContactsID"].ToString()));
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@CompanyID", CbDt.Rows[i]["CompanyID"].ToString()));
                    Param.Add(new SqlParameter("@FirstName", CbDt.Rows[i]["FirstName"].ToString()));
                    Param.Add(new SqlParameter("@MiddleName", CbDt.Rows[i]["MiddleName"].ToString()));
                    Param.Add(new SqlParameter("@LastName", CbDt.Rows[i]["LastName"].ToString()));
                    Param.Add(new SqlParameter("@ContactTitle", CbDt.Rows[i]["ContactTitle"].ToString()));
                    Param.Add(new SqlParameter("@MobilePhone", CbDt.Rows[i]["MobilePhone"].ToString()));
                    Param.Add(new SqlParameter("@EmailAddress", CbDt.Rows[i]["EmailAddress"].ToString()));
                    Param.Add(new SqlParameter("@Notes", CbDt.Rows[i]["Notes"].ToString()));
                    Param.Add(new SqlParameter("@SpecialRiggerNUM", CbDt.Rows[i]["SpecialRiggerNUM"].ToString()));
                    Param.Add(new SqlParameter("@MasterRiggerNUM", CbDt.Rows[i]["MasterRiggerNUM"].ToString()));
                    Param.Add(new SqlParameter("@SpecialSignNUM", CbDt.Rows[i]["SpecialSignNUM"].ToString()));
                    Param.Add(new SqlParameter("@MasterSignNUM", CbDt.Rows[i]["MasterSignNUM"].ToString()));
                    Param.Add(new SqlParameter("@Prefix", CbDt.Rows[i]["Prefix"].ToString()));
                    Param.Add(new SqlParameter("@Suffix", CbDt.Rows[i]["Suffix"].ToString()));
                    Param.Add(new SqlParameter("@Address", CbDt.Rows[i]["Address"].ToString()));
                    Param.Add(new SqlParameter("@City", CbDt.Rows[i]["City"].ToString()));
                    Param.Add(new SqlParameter("@PostalCode", CbDt.Rows[i]["PostalCode"].ToString()));
                    Param.Add(new SqlParameter("@State", CbDt.Rows[i]["State"].ToString()));
                    Param.Add(new SqlParameter("@Country", CbDt.Rows[i]["Country"].ToString()));
                    Param.Add(new SqlParameter("@HomePhone", CbDt.Rows[i]["HomePhone"].ToString()));
                    Param.Add(new SqlParameter("@WorkPhone", CbDt.Rows[i]["WorkPhone"].ToString()));
                    Param.Add(new SqlParameter("@FaxNumber", CbDt.Rows[i]["FaxNumber"].ToString()));
                    Param.Add(new SqlParameter("@AlternativePhone", CbDt.Rows[i]["AlternativePhone"].ToString()));
                    Param.Add(new SqlParameter("@FieldPhone", CbDt.Rows[i]["FieldPhone"].ToString()));
                    Param.Add(new SqlParameter("@Pager", CbDt.Rows[i]["Pager"].ToString()));
                    // //Update at webserver system
                    StMethod.UpdateRecord(query, Param);
                    // //Local update
                    StMethod.UpdateRecord("UPDATE Contacts SET IsChange=0 WHERE ContactsID=" + CbDt.Rows[i]["ContactsID"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            // *********************************Delete*************************************
            CbDt = StMethod.GetListDT<ContactsData>("SELECT * FROM Contacts where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    // Update Web Server
                    StMethod.UpdateRecord( "Delete Contacts where ContactsID=" + CbDt.Rows[i]["ContactsID"].ToString() + "");
                    // //Local Table
                    StMethod.UpdateRecord("Delete Contacts WHERE ContactsID=" + CbDt.Rows[i]["ContactsID"].ToString() + " ");
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
        }

        private void DrawingLog()
        {
            // Dim CbDt As New DataTable
            // Cmd = New SqlCommand("", WebSqlCon)
            // Dim DrawingLog As New DataAccessLayer
            // CbDt = DrawingLog.Filldatatable("SELECT * FROM DrawingLog where IsNewRecord=1")
            // Dim query As String

            // Try

            // Cmd.CommandText = query

            // Catch ex As SqlException
            // KryptonMessageBox.Show(ex.Message, "Message")
            // Finally
            // WebSqlCon.Close()
            // End Try
        }

        public void JobList()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            // Cmd = New SqlCommand("", WebSqlCon)
            CbDt = StMethod.GetListDT<JobListFull>("SELECT * FROM JobList where IsNewRecord=1");
            string query;
            query = " Insert into JobList(JobNumber,CompanyID,ContactsID,DateAdded,Description,Handler,Address,Borough) values (@JobNumber,@CompanyID,@ContactsID,@DateAdded,@Description,@Handler,@Address,@Borough)";
            try
            {
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@JobListID", CbDt.Rows[i]["JobListID"].ToString()));
                    Param.Add(new SqlParameter("@JobNumber", CbDt.Rows[i]["JobNumber"].ToString()));
                    Param.Add(new SqlParameter("@DateAdded", CbDt.Rows[i]["DateAdded"].ToString()));
                    Param.Add(new SqlParameter("@Description", CbDt.Rows[i]["Description"].ToString()));
                    Param.Add(new SqlParameter("@Address", CbDt.Rows[i]["Address"].ToString()));
                    Param.Add(new SqlParameter("@Handler", CbDt.Rows[i]["Handler"].ToString()));
                    Param.Add(new SqlParameter("@Borough", CbDt.Rows[i]["Borough"].ToString()));
                    Param.Add(new SqlParameter("@CompanyID", CbDt.Rows[i]["CompanyID"].ToString()));
                    Param.Add(new SqlParameter("@ContactsID", CbDt.Rows[i]["ContactsID"].ToString()));
                    // //Update at webserver system
                    StMethod.UpdateRecord(query, Param);
                    // //Local update
                    StMethod.UpdateRecord("UPDATE JobList SET IsNewRecord=0 WHERE JobListID=" + CbDt.Rows[i]["JobListID"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }

            // **************************************Update*****************************
            CbDt = StMethod.GetListDT<JobListFull>("SELECT * FROM JobList where IsChange=1");
            WebTable = StMethod.GetListDT<JobListFull>("SELECT * FROM JobList where IsChange=1");
            query = "Update JobList set JobNumber= @JobNumber,CompanyID=@CompanyID,DateAdded=@DateAdded,Description= @Description,Handler=@Handler, Address=@Address,Borough=@Borough , ContactsID=@ContactsID ,IsChange=@IsChange where   JobListID=@JobListID";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = WebTable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["JobListID"].ToString() == WebTable.Rows[j]["JobListID"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == WebTable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(WebTable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    StMethod.UpdateRecord("UPDATE JobList SET IsChange=0 WHERE JobListID=" + CbDt.Rows[i]["JobListID"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@JobListID", CbDt.Rows[i]["JobListID"].ToString()));
                    Param.Add(new SqlParameter("@JobNumber", CbDt.Rows[i]["JobNumber"].ToString()));
                    Param.Add(new SqlParameter("@DateAdded", CbDt.Rows[i]["DateAdded"].ToString()));
                    Param.Add(new SqlParameter("@Description", CbDt.Rows[i]["Description"].ToString()));
                    Param.Add(new SqlParameter("@Address", CbDt.Rows[i]["Address"].ToString()));
                    Param.Add(new SqlParameter("@Handler", CbDt.Rows[i]["Handler"].ToString()));
                    Param.Add(new SqlParameter("@Borough", CbDt.Rows[i]["Borough"].ToString()));
                    Param.Add(new SqlParameter("@CompanyID", CbDt.Rows[i]["CompanyID"].ToString()));
                    Param.Add(new SqlParameter("@ContactsID", CbDt.Rows[i]["ContactsID"].ToString()));
                    // //Update at webserver system
                    StMethod.UpdateRecord(query, Param);
                    // //Local update
                    StMethod.UpdateRecord("UPDATE JobList SET IsChange=0 WHERE JobListID=" + CbDt.Rows[i]["JobListID"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            // **************************************Delete*****************************

            CbDt = StMethod.GetListDT<JobListFull>("SELECT * FROM JobList where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    StMethod.UpdateRecord("delete JobList where JobListID=" + CbDt.Rows[i]["JobListID"].ToString() + "");
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    JobList.InsertRecord("delete JobList WHERE JobListID=" + CbDt.Rows[i]["JobListID"].ToString() + " ");
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        public void JobTracking()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            // Cmd = New SqlCommand("", WebSqlCon)
            var JobTracking = new DataAccessLayer();
            CbDt = JobTracking.Filldatatable("SELECT * FROM JobTracking where IsNewRecord=1");
            string query;
            query = "Insert into Jobtracking(JobListID,Track,AddDate,NeedDate,Obtained,Expires,Status,Submitted,BillState,TaskHandler,TrackSub,Comments) values (@JobListID,@Track,@AddDate,@NeedDate,@Obtained,@Expires,@Status,@Submitted,@BillState,@TaskHandler,@TrackSub,@Comments)";
            try
            {
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@JobListID", CbDt.Rows[i]["JobListID"].ToString()));
                    Param.Add(new SqlParameter("@TaskHandler", CbDt.Rows[i]["TaskHandler"].ToString()));
                    Param.Add(new SqlParameter("@Track", CbDt.Rows[i]["Track"].ToString()));
                    Param.Add(new SqlParameter("@Submitted", CbDt.Rows[i]["Submitted"].ToString()));
                    Param.Add(new SqlParameter("@BillState", CbDt.Rows[i]["BillState"].ToString()));
                    Param.Add(new SqlParameter("@TrackSub", CbDt.Rows[i]["TrackSub"].ToString()));
                    Param.Add(new SqlParameter("@Comments", CbDt.Rows[i]["Comments"].ToString()));
                    Param.Add(new SqlParameter("@Status", CbDt.Rows[i]["Status"].ToString()));
                    Param.Add(new SqlParameter("@Obtained", CbDt.Rows[i]["Obtained"].ToString()));
                    Param.Add(new SqlParameter("@Expires", CbDt.Rows[i]["Expires"].ToString()));
                    Param.Add(new SqlParameter("@AddDate", CbDt.Rows[i]["AddDate"].ToString()));
                    Param.Add(new SqlParameter("@NeedDate", CbDt.Rows[i]["NeedDate"].ToString()));
                    WebSqlCon.Open();
                    // //Update at webserver system
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local update
                    JobTracking.InsertRecord("UPDATE Jobtracking SET IsNewRecord=0 WHERE JobtrackingID=" + CbDt.Rows[i]["JobtrackingID"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // **************************************Update*****************************
            CbDt = JobTracking.Filldatatable("SELECT * FROM JobTracking where IsChange=1");
            WebTable = FillWebTable("SELECT * FROM JobTracking where IsChange=1");
            query = "update  Jobtracking set JobListID= @JobListID,TaskHandler=@TaskHandler,Track=@Track,Status= @Status,Submitted=@Submitted, Obtained=@Obtained,Expires=@Expires,BillState=@BillState , AddDate=@AddDate,NeedDate= @NeedDate,TrackSub=@TrackSub,Comments=@Comments,IsChange=@IsChange where   JobTrackingID= @JobTrackingID";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = WebTable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["JobTrackingID"].ToString() == WebTable.Rows[j]["JobTrackingID"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == WebTable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(WebTable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    JobTracking.InsertRecord("UPDATE JobTracking SET IsChange=0 WHERE JobTrackingID=" + CbDt.Rows[i]["JobTrackingID"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@JobListID", CbDt.Rows[i]["JobListID"].ToString()));
                    Param.Add(new SqlParameter("@TaskHandler", CbDt.Rows[i]["TaskHandler"].ToString()));
                    Param.Add(new SqlParameter("@Track", CbDt.Rows[i]["Track"].ToString()));
                    Param.Add(new SqlParameter("@Submitted", CbDt.Rows[i]["Submitted"].ToString()));
                    Param.Add(new SqlParameter("@BillState", CbDt.Rows[i]["BillState"].ToString()));
                    Param.Add(new SqlParameter("@TrackSub", CbDt.Rows[i]["TrackSub"].ToString()));
                    Param.Add(new SqlParameter("@Comments", CbDt.Rows[i]["Comments"].ToString()));
                    Param.Add(new SqlParameter("@Status", CbDt.Rows[i]["Status"].ToString()));
                    Param.Add(new SqlParameter("@Obtained", CbDt.Rows[i]["Obtained"].ToString()));
                    Param.Add(new SqlParameter("@Expires", CbDt.Rows[i]["Expires"].ToString()));
                    Param.Add(new SqlParameter("@AddDate", CbDt.Rows[i]["AddDate"].ToString()));
                    Param.Add(new SqlParameter("@NeedDate", CbDt.Rows[i]["NeedDate"].ToString()));
                    Param.Add(new SqlParameter("@JobTrackingID", CbDt.Rows[i]["JobTrackingID"].ToString()));
                    WebSqlCon.Open();
                    // //Update at webserver system
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local update
                    JobTracking.InsertRecord("UPDATE JobTracking SET IsChange=0 WHERE JobTrackingID=" + CbDt.Rows[i]["JobTrackingID"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
            // **************************************Delete*****************************

            CbDt = JobTracking.Filldatatable("SELECT * FROM JobTracking where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    Cmd = new SqlCommand("", WebSqlCon);
                    Cmd.CommandText = "delete JobTracking where JobTrackingID=" + CbDt.Rows[i]["JobTrackingID"].ToString() + "";
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    JobTracking.InsertRecord("delete JobTracking WHERE JobTrackingID=" + CbDt.Rows[i]["JobTrackingID"].ToString() + " ");
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        private void MasterItem()
        {
            var CbDt = new DataTable();
            var Webtable = new DataTable();
            // Cmd = New SqlCommand("", WebSqlCon)
            var MasterItem = new DataAccessLayer();
            CbDt = MasterItem.Filldatatable("SELECT * FROM MasterItem where IsNewRecord=1");
            string query;
            query = "Insert into MasterItem(cGroup,cTrack) values(@group,@track)";
            try
            {
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@group", CbDt.Rows[i]["cGroup"].ToString()));
                    Param.Add(new SqlParameter("@track", CbDt.Rows[i]["cTrack"].ToString()));
                    WebSqlCon.Open();
                    // //Update at webserver system
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local update
                    MasterItem.InsertRecord("UPDATE MasterItem SET IsNewRecord=0 WHERE Id=" + CbDt.Rows[i]["Id"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // **************************************Update*****************************
            CbDt = MasterItem.Filldatatable("SELECT * FROM MasterItem where IsChange=1");
            Webtable = FillWebTable("SELECT * FROM MasterItem where IsChange=1");
            query = "UPDATE MasterItem SET cGroup=@cGroup,cTrack=@cTrack,IsChange=@IsChange where Id=@Id";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = Webtable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["Id"].ToString() == Webtable.Rows[j]["Id"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == Webtable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(Webtable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    MasterItem.InsertRecord("UPDATE MasterItem SET IsChange=0 WHERE Id=" + CbDt.Rows[i]["Id"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@cGroup", CbDt.Rows[i]["cGroup"].ToString()));
                    Param.Add(new SqlParameter("@cTrack", CbDt.Rows[i]["cTrack"].ToString()));
                    Param.Add(new SqlParameter("@Id", CbDt.Rows[i]["Id"].ToString()));
                    WebSqlCon.Open();
                    // //Update at webserver system
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local update
                    MasterItem.InsertRecord("UPDATE MasterItem SET IsChange=0 WHERE Id=" + CbDt.Rows[i]["Id"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
            // **************************************Delete*****************************

            CbDt = MasterItem.Filldatatable("SELECT * FROM MasterItem where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    Cmd = new SqlCommand("", WebSqlCon);
                    Cmd.CommandText = "delete MasterItem where Id=" + CbDt.Rows[i]["Id"].ToString() + "";
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    MasterItem.InsertRecord("delete MasterItem WHERE Id=" + CbDt.Rows[i]["Id"].ToString() + " ");
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        private void VBCDDatabase()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            // Cmd = New SqlCommand("", WebSqlCon)
            var VBCDDatabase = new DataAccessLayer();
            CbDt = VBCDDatabase.Filldatatable("SELECT * FROM VBCDDatabase where IsNewRecord=1");
            string query;
            query = "INSERT INTO VBCDDatabase (CDNumber,SerialNumber,Make,Model,ModelYear,Capacity,Owner,Expiration,ModelSpaceName,Notes,CraneName,CraneID,OwnerPhone,OwnerFax,TypMast,TypBoom,TypJIB,TypTotal,EquipmentType,ErectionStyle,TravelCTWT,Dunnage,MaxOrLoad) VALUES (@CDNumber, @SerialNumber, @Make, @Model, @ModelYear, @Capacity, @Owner, @Expiration, @ModelSpaceName, @Notes, @CraneName, @CraneID, @OwnerPhone, @OwnerFax, @TypMast, @TypBoom, @TypJIB, @TypTotal, @EquipmentType, @ErectionStyle, @TravelCTWT, @Dunnage, @MaxOrLoad)";
            try
            {
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@CDNumber", CbDt.Rows[i]["CDNumber"].ToString()));
                    Param.Add(new SqlParameter("@SerialNumber", CbDt.Rows[i]["SerialNumber"].ToString()));
                    Param.Add(new SqlParameter("@Make", CbDt.Rows[i]["Make"].ToString()));
                    Param.Add(new SqlParameter("@Model", CbDt.Rows[i]["Model"].ToString()));
                    Param.Add(new SqlParameter("@ModelYear", CbDt.Rows[i]["ModelYear"].ToString()));
                    Param.Add(new SqlParameter("@Capacity", CbDt.Rows[i]["Capacity"].ToString()));
                    Param.Add(new SqlParameter("@Owner", CbDt.Rows[i]["Owner"].ToString()));
                    Param.Add(new SqlParameter("@Expiration", CbDt.Rows[i]["Expiration"].ToString()));
                    Param.Add(new SqlParameter("@ModelSpaceName", CbDt.Rows[i]["ModelSpaceName"].ToString()));
                    Param.Add(new SqlParameter("@Notes", CbDt.Rows[i]["Notes"].ToString()));
                    Param.Add(new SqlParameter("@CraneName", CbDt.Rows[i]["CraneName"].ToString()));
                    Param.Add(new SqlParameter("@CraneID", CbDt.Rows[i]["CraneID"].ToString()));
                    Param.Add(new SqlParameter("@OwnerPhone", CbDt.Rows[i]["OwnerPhone"].ToString()));
                    Param.Add(new SqlParameter("@OwnerFax", CbDt.Rows[i]["OwnerFax"].ToString()));
                    Param.Add(new SqlParameter("@TypMast", CbDt.Rows[i]["TypMast"].ToString()));
                    Param.Add(new SqlParameter("@TypBoom", CbDt.Rows[i]["TypBoom"].ToString()));
                    Param.Add(new SqlParameter("@TypJIB", CbDt.Rows[i]["TypJIB"].ToString()));
                    Param.Add(new SqlParameter("@TypTotal", CbDt.Rows[i]["TypTotal"].ToString()));
                    Param.Add(new SqlParameter("@EquipmentType", CbDt.Rows[i]["EquipmentType"].ToString()));
                    Param.Add(new SqlParameter("@ErectionStyle", CbDt.Rows[i]["ErectionStyle"].ToString()));
                    Param.Add(new SqlParameter("@TravelCTWT", CbDt.Rows[i]["TravelCTWT"].ToString()));
                    Param.Add(new SqlParameter("@Dunnage", CbDt.Rows[i]["Dunnage"].ToString()));
                    Param.Add(new SqlParameter("@MaxOrLoad", CbDt.Rows[i]["MaxOrLoad"].ToString()));
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    VBCDDatabase.InsertRecord("UPDATE VBCDDatabase SET IsNewRecord=0 WHERE Id=" + CbDt.Rows[i]["CDID"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // **************************************Update*****************************
            CbDt = VBCDDatabase.Filldatatable("SELECT * FROM VBCDDatabase where IsChange=1");
            WebTable = FillWebTable("SELECT * FROM VBCDDatabase where IsChange=1");
            query = "Update  VBCDDatabase SET CDNumber = @CDNumber,SerialNumber = @SerialNumber,Make = @Make,Model = @Model,ModelYear = @ModelYear,Capacity = @Capacity,Owner = @Owner,Expiration = @Expiration,ModelSpaceName = @ModelSpaceName,Notes = @Notes,CraneName = @CraneName,CraneID = @CraneID,OwnerPhone = @OwnerPhone,OwnerFax = @OwnerFax,TypMast = @TypMast,TypBoom = @TypBoom,TypJIB = @TypJIB,TypTotal = @TypTotal,EquipmentType = @EquipmentType,ErectionStyle = @ErectionStyle,TravelCTWT = @TravelCTWT,Dunnage = @Dunnage,MaxOrLoad = @MaxOrLoad,IsChange=@IsChange WHERE CDID = @CDID ";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = WebTable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["CDID"].ToString() == WebTable.Rows[j]["CDID"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == WebTable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(WebTable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    VBCDDatabase.InsertRecord("UPDATE VBCDDatabase SET IsChange=0 WHERE CDID=" + CbDt.Rows[i]["CDID"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@CDNumber", CbDt.Rows[i]["CDNumber"].ToString()));
                    Param.Add(new SqlParameter("@SerialNumber", CbDt.Rows[i]["SerialNumber"].ToString()));
                    Param.Add(new SqlParameter("@Make", CbDt.Rows[i]["Make"].ToString()));
                    Param.Add(new SqlParameter("@Model", CbDt.Rows[i]["Model"].ToString()));
                    Param.Add(new SqlParameter("@ModelYear", CbDt.Rows[i]["ModelYear"].ToString()));
                    Param.Add(new SqlParameter("@Capacity", CbDt.Rows[i]["Capacity"].ToString()));
                    Param.Add(new SqlParameter("@Owner", CbDt.Rows[i]["Owner"].ToString()));
                    Param.Add(new SqlParameter("@Expiration", CbDt.Rows[i]["Expiration"].ToString()));
                    Param.Add(new SqlParameter("@ModelSpaceName", CbDt.Rows[i]["ModelSpaceName"].ToString()));
                    Param.Add(new SqlParameter("@Notes", CbDt.Rows[i]["Notes"].ToString()));
                    Param.Add(new SqlParameter("@CraneName", CbDt.Rows[i]["CraneName"].ToString()));
                    Param.Add(new SqlParameter("@CraneID", CbDt.Rows[i]["CraneID"].ToString()));
                    Param.Add(new SqlParameter("@OwnerPhone", CbDt.Rows[i]["OwnerPhone"].ToString()));
                    Param.Add(new SqlParameter("@OwnerFax", CbDt.Rows[i]["OwnerFax"].ToString()));
                    Param.Add(new SqlParameter("@TypMast", CbDt.Rows[i]["TypMast"].ToString()));
                    Param.Add(new SqlParameter("@TypBoom", CbDt.Rows[i]["TypBoom"].ToString()));
                    Param.Add(new SqlParameter("@TypJIB", CbDt.Rows[i]["TypJIB"].ToString()));
                    Param.Add(new SqlParameter("@TypTotal", CbDt.Rows[i]["TypTotal"].ToString()));
                    Param.Add(new SqlParameter("@EquipmentType", CbDt.Rows[i]["EquipmentType"].ToString()));
                    Param.Add(new SqlParameter("@ErectionStyle", CbDt.Rows[i]["ErectionStyle"].ToString()));
                    Param.Add(new SqlParameter("@TravelCTWT", CbDt.Rows[i]["TravelCTWT"].ToString()));
                    Param.Add(new SqlParameter("@Dunnage", CbDt.Rows[i]["Dunnage"].ToString()));
                    Param.Add(new SqlParameter("@MaxOrLoad", CbDt.Rows[i]["MaxOrLoad"].ToString()));
                    Param.Add(new SqlParameter("@CDID", CbDt.Rows[i]["CDID"].ToString()));
                    WebSqlCon.Open();
                    // //Update at webserver system
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local update
                    VBCDDatabase.InsertRecord("UPDATE VBCDDatabase SET IsChange=0 WHERE CDID=" + CbDt.Rows[i]["CDID"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
            // **************************************Delete*****************************

            CbDt = VBCDDatabase.Filldatatable("SELECT * FROM VBCDDatabase where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    Cmd = new SqlCommand("", WebSqlCon);
                    Cmd.CommandText = "delete VBCDDatabase where CDID=" + CbDt.Rows[i]["CDID"].ToString() + "";
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    VBCDDatabase.InsertRecord("delete VBCDDatabase WHERE CDID=" + CbDt.Rows[i]["CDID"].ToString() + " ");
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        private void VBFormInfo()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            Cmd = new SqlCommand("", WebSqlCon);
            var VBFormInfo = new DataAccessLayer();
            CbDt = VBFormInfo.Filldatatable("SELECT * FROM VBFormInfo where IsNewRecord=1");
            string query;
            query = "INSERT INTO VBFormInfo  ( VBFormInfo.JobListID,VBFormInfo.Applicant, VBFormInfo.JobSiteBlock, VBFormInfo.JobSiteLot, VBFormInfo.JobSiteCNNum, VBFormInfo.JobSiteHouseNum, VBFormInfo.JobSiteStreet, VBFormInfo.JobSiteBorough, VBFormInfo.JobSiteState,        VBFormInfo.Crane1CD, VBFormInfo.Crane2CD, VBFormInfo.Crane3CD, VBFormInfo.Crane4CD, VBFormInfo.Crane5CD, VBFormInfo.Crane6CD,  VBFormInfo.CraneUser, VBFormInfo.CraneUserInfo, VBFormInfo.CraneUserTitle, VBFormInfo.WorkPlatformManufacturer, VBFormInfo.WorkPlatformModel,    VBFormInfo.WorkPlatformSuperName, VBFormInfo.WorkPlatformSuperPhone, VBFormInfo.WorkPlatformSuperFax, VBFormInfo.WorkPlatformSuperAddr,        VBFormInfo.WorkPlatformSuperCity, VBFormInfo.WorkPlatformSuperState, VBFormInfo.WorkPlatformSuperZip, VBFormInfo.FirstVariance, VBFormInfo.BIN,    VBFormInfo.CBNum, VBFormInfo.AptorCondoNum, VBFormInfo.SpecialPlaceName, VBFormInfo.SubName, VBFormInfo.SubInfo,     VBFormInfo.ResidenceWithin200ft, VBFormInfo.DatesofVariance, VBFormInfo.DaysofVariance, VBFormInfo.TimeofVarianceFrom, VBFormInfo.TimeofVarianceTo,      VBFormInfo.VarianceWorkDescription, VBFormInfo.ReasonforVariance, VBFormInfo.SiteArchitect, VBFormInfo.CommunityBoardID,        VBFormInfo.SiteNumofStories, VBFormInfo.SiteOccupancy, VBFormInfo.OccupancyType, VBFormInfo.SiteNumofApts, VBFormInfo.SiteNumofAptsCurrent,     VBFormInfo.SiteNumofAptsProposed, VBFormInfo.SiteOwner, VBFormInfo.SiteOwnerAddress, VBFormInfo.SiteOwnerStreet, VBFormInfo.SiteOwnerCity,     VBFormInfo.SiteOwnerState, VBFormInfo.SiteOwnerZip, VBFormInfo.WorkProposed, VBFormInfo.Architect2, VBFormInfo.Architect2fullAddress)                                       VALUES (@JobListID, @Applicant, @JobSiteBlock, @JobSiteLot, @JobSiteCNNum, @JobSiteHouseNum, @JobSiteStreet, @JobSiteBorough, @JobSiteState,        @Crane1CD, @Crane2CD, @Crane3CD, @Crane4CD, @Crane5CD, @Crane6CD,  @CraneUser, @CraneUserInfo, @CraneUserTitle, @WorkPlatformManufacturer, @WorkPlatformModel,    @WorkPlatformSuperName, @WorkPlatformSuperPhone, @WorkPlatformSuperFax, @WorkPlatformSuperAddr,        @WorkPlatformSuperCity,@WorkPlatformSuperState, @WorkPlatformSuperZip, @FirstVariance,@BIN,    @CBNum, @AptorCondoNum, @SpecialPlaceName, @SubName, @SubInfo,     @ResidenceWithin200ft, @DatesofVariance, @DaysofVariance, @TimeofVarianceFrom, @TimeofVarianceTo,     @VarianceWorkDescription, @ReasonforVariance, @SiteArchitect, @CommunityBoardID,   @SiteNumofStories, @SiteOccupancy, @OccupancyType, @SiteNumofApts, @SiteNumofAptsCurrent,     @SiteNumofAptsProposed, @SiteOwner, @SiteOwnerAddress, @SiteOwnerStreet, @SiteOwnerCity,    @SiteOwnerState, @SiteOwnerZip, @WorkProposed, @Architect2, @Architect2fullAddress)";
            try
            {
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@JobListID", CbDt.Rows[i]["JobListID"].ToString()));
                    Param.Add(new SqlParameter("@Applicant", CbDt.Rows[i]["Applicant"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteBlock", CbDt.Rows[i]["JobSiteBlock"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteLot", CbDt.Rows[i]["JobSiteLot"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteCNNum", CbDt.Rows[i]["JobSiteCNNum"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteHouseNum", CbDt.Rows[i]["JobSiteHouseNum"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteStreet", CbDt.Rows[i]["JobSiteStreet"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteBorough", CbDt.Rows[i]["JobSiteBorough"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteState", CbDt.Rows[i]["JobSiteState"].ToString()));
                    Param.Add(new SqlParameter("@Crane1CD", CbDt.Rows[i]["Crane1CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane2CD", CbDt.Rows[i]["Crane2CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane3CD", CbDt.Rows[i]["Crane3CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane4CD", CbDt.Rows[i]["Crane4CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane5CD", CbDt.Rows[i]["Crane5CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane6CD", CbDt.Rows[i]["Crane6CD"].ToString()));
                    Param.Add(new SqlParameter("@CraneUser", CbDt.Rows[i]["CraneUser"].ToString()));
                    Param.Add(new SqlParameter("@CraneUserInfo", CbDt.Rows[i]["CraneUserInfo"].ToString()));
                    Param.Add(new SqlParameter("@CraneUserTitle", CbDt.Rows[i]["CraneUserTitle"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformManufacturer", CbDt.Rows[i]["WorkPlatformManufacturer"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformModel", CbDt.Rows[i]["WorkPlatformModel"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperName", CbDt.Rows[i]["WorkPlatformSuperName"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperPhone", CbDt.Rows[i]["WorkPlatformSuperPhone"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperFax", CbDt.Rows[i]["WorkPlatformSuperFax"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperAddr", CbDt.Rows[i]["WorkPlatformSuperAddr"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperCity", CbDt.Rows[i]["WorkPlatformSuperCity"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperZip", CbDt.Rows[i]["WorkPlatformSuperZip"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperState", CbDt.Rows[i]["WorkPlatformSuperState"].ToString()));
                    Param.Add(new SqlParameter("@FirstVariance", CbDt.Rows[i]["FirstVariance"].ToString()));
                    Param.Add(new SqlParameter("@BIN", CbDt.Rows[i]["BIN"].ToString()));
                    Param.Add(new SqlParameter("@CBNum", CbDt.Rows[i]["CBNum"].ToString()));
                    Param.Add(new SqlParameter("@AptorCondoNum", CbDt.Rows[i]["AptorCondoNum"].ToString()));
                    Param.Add(new SqlParameter("@SpecialPlaceName", CbDt.Rows[i]["SpecialPlaceName"].ToString()));
                    Param.Add(new SqlParameter("@SubName", CbDt.Rows[i]["SubName"].ToString()));
                    Param.Add(new SqlParameter("@SubInfo", CbDt.Rows[i]["SubInfo"].ToString()));
                    Param.Add(new SqlParameter("@ResidenceWithin200ft", CbDt.Rows[i]["ResidenceWithin200ft"].ToString()));
                    Param.Add(new SqlParameter("@DaysofVariance", CbDt.Rows[i]["DaysofVariance"].ToString()));
                    Param.Add(new SqlParameter("@DatesofVariance", CbDt.Rows[i]["DatesofVariance"].ToString()));
                    Param.Add(new SqlParameter("@TimeofVarianceFrom", CbDt.Rows[i]["TimeofVarianceFrom"].ToString()));
                    Param.Add(new SqlParameter("@TimeofVarianceTo", CbDt.Rows[i]["TimeofVarianceTo"].ToString()));
                    Param.Add(new SqlParameter("@VarianceWorkDescription", CbDt.Rows[i]["VarianceWorkDescription"].ToString()));
                    Param.Add(new SqlParameter("@ReasonforVariance", CbDt.Rows[i]["ReasonforVariance"].ToString()));
                    Param.Add(new SqlParameter("@SiteArchitect", CbDt.Rows[i]["SiteArchitect"].ToString()));
                    Param.Add(new SqlParameter("@CommunityBoardID", CbDt.Rows[i]["CommunityBoardID"].ToString()));
                    Param.Add(new SqlParameter("@SiteNumofStories", CbDt.Rows[i]["SiteNumofStories"].ToString()));
                    Param.Add(new SqlParameter("@SiteOccupancy", CbDt.Rows[i]["SiteOccupancy"].ToString()));
                    // Param.Add(new SqlParameter("@SiteOccupancy", CbDt.Rows[i]["SiteOccupancy"].ToString())
                    Param.Add(new SqlParameter("@OccupancyType", CbDt.Rows[i]["OccupancyType"].ToString()));
                    Param.Add(new SqlParameter("@SiteNumofApts", CbDt.Rows[i]["SiteNumofApts"].ToString()));
                    Param.Add(new SqlParameter("@SiteNumofAptsCurrent", CbDt.Rows[i]["SiteNumofAptsCurrent"].ToString()));
                    Param.Add(new SqlParameter("@SiteNumofAptsProposed", CbDt.Rows[i]["SiteNumofAptsProposed"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwner", CbDt.Rows[i]["SiteOwner"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerAddress", CbDt.Rows[i]["SiteOwnerAddress"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerStreet", CbDt.Rows[i]["SiteOwnerStreet"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerCity", CbDt.Rows[i]["SiteOwnerCity"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerState", CbDt.Rows[i]["SiteOwnerState"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerZip", CbDt.Rows[i]["SiteOwnerZip"].ToString()));
                    Param.Add(new SqlParameter("@WorkProposed", CbDt.Rows[i]["WorkProposed"].ToString()));
                    Param.Add(new SqlParameter("@Architect2", CbDt.Rows[i]["Architect2"].ToString()));
                    Param.Add(new SqlParameter("@Architect2fullAddress", CbDt.Rows[i]["Architect2fullAddress"].ToString()));
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    VBFormInfo.InsertRecord("UPDATE VBFormInfo SET IsNewRecord=0 WHERE JobID=" + CbDt.Rows[i]["JobID"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // **************************************Update*****************************
            CbDt = VBFormInfo.Filldatatable("SELECT * FROM VBFormInfo where IsChange=1");
            WebTable = FillWebTable("SELECT * FROM VBFormInfo where IsChange=1");
            query = "Update VBFormInfo  SET VBFormInfo.JobListID=@JobListID,VBFormInfo.Applicant=@Applicant, VBFormInfo.JobSiteBlock=@JobSiteBlock, VBFormInfo.JobSiteLot=@JobSiteLot, VBFormInfo.JobSiteCNNum=@JobSiteCNNum, VBFormInfo.JobSiteHouseNum=@JobSiteHouseNum, VBFormInfo.JobSiteStreet=@JobSiteStreet, VBFormInfo.JobSiteBorough=@JobSiteBorough, VBFormInfo.JobSiteState=@JobSiteState,        VBFormInfo.Crane1CD=@Crane1CD, VBFormInfo.Crane2CD=@Crane2CD, VBFormInfo.Crane3CD=@Crane3CD, VBFormInfo.Crane4CD=@Crane4CD, VBFormInfo.Crane5CD=@Crane5CD, VBFormInfo.Crane6CD=@Crane6CD,  VBFormInfo.CraneUser=@CraneUser, VBFormInfo.CraneUserInfo=@CraneUserInfo, VBFormInfo.CraneUserTitle=@CraneUserTitle, VBFormInfo.WorkPlatformManufacturer=@WorkPlatformManufacturer, VBFormInfo.WorkPlatformModel=@WorkPlatformModel,    VBFormInfo.WorkPlatformSuperName=@WorkPlatformSuperName, VBFormInfo.WorkPlatformSuperPhone=@WorkPlatformSuperPhone, VBFormInfo.WorkPlatformSuperFax=@WorkPlatformSuperFax, VBFormInfo.WorkPlatformSuperAddr=@WorkPlatformSuperAddr,        VBFormInfo.WorkPlatformSuperCity=@WorkPlatformSuperCity, VBFormInfo.WorkPlatformSuperState=@WorkPlatformSuperState, VBFormInfo.WorkPlatformSuperZip=@WorkPlatformSuperZip, VBFormInfo.FirstVariance=@FirstVariance, VBFormInfo.BIN=@BIN,    VBFormInfo.CBNum=@CBNum, VBFormInfo.AptorCondoNum=@AptorCondoNum, VBFormInfo.SpecialPlaceName=@SpecialPlaceName, VBFormInfo.SubName=@SubName, VBFormInfo.SubInfo=@SubInfo,     VBFormInfo.ResidenceWithin200ft=@ResidenceWithin200ft, VBFormInfo.DatesofVariance=@DatesofVariance, VBFormInfo.DaysofVariance=@DaysofVariance, VBFormInfo.TimeofVarianceFrom=@TimeofVarianceFrom, VBFormInfo.TimeofVarianceTo=@TimeofVarianceTo,      VBFormInfo.VarianceWorkDescription=@VarianceWorkDescription, VBFormInfo.ReasonforVariance=@ReasonforVariance, VBFormInfo.SiteArchitect=@SiteArchitect,         VBFormInfo.SiteNumofStories=@SiteNumofStories, VBFormInfo.SiteOccupancy=@SiteOccupancy, VBFormInfo.OccupancyType=@OccupancyType, VBFormInfo.SiteNumofApts=@SiteNumofApts, VBFormInfo.SiteNumofAptsCurrent=@SiteNumofAptsCurrent,     VBFormInfo.SiteNumofAptsProposed=@SiteNumofAptsProposed, VBFormInfo.SiteOwner=@SiteOwner, VBFormInfo.SiteOwnerAddress=@SiteOwnerAddress, VBFormInfo.SiteOwnerStreet=@SiteOwnerStreet, VBFormInfo.SiteOwnerCity=@SiteOwnerCity,     VBFormInfo.SiteOwnerState=@SiteOwnerState, VBFormInfo.SiteOwnerZip=@SiteOwnerZip, VBFormInfo.WorkProposed=@WorkProposed, VBFormInfo.Architect2=@Architect2, VBFormInfo.Architect2fullAddress=@Architect2fullAddress,VBFormInfo.CommunityBoardID=@CommunityBoardID,IsChange=@IsChange  WHERE  JobID =@JobID";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = WebTable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["JobID"].ToString() == WebTable.Rows[j]["JobID"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == WebTable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(WebTable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    VBFormInfo.InsertRecord("UPDATE VBFormInfo SET IsChange=0 WHERE JobID=" + CbDt.Rows[i]["JobID"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@JobID", CbDt.Rows[i]["JobID"].ToString()));
                    Param.Add(new SqlParameter("@JobListID", CbDt.Rows[i]["JobListID"].ToString()));
                    Param.Add(new SqlParameter("@Applicant", CbDt.Rows[i]["Applicant"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteBlock", CbDt.Rows[i]["JobSiteBlock"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteLot", CbDt.Rows[i]["JobSiteLot"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteCNNum", CbDt.Rows[i]["JobSiteCNNum"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteHouseNum", CbDt.Rows[i]["JobSiteHouseNum"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteStreet", CbDt.Rows[i]["JobSiteStreet"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteBorough", CbDt.Rows[i]["JobSiteBorough"].ToString()));
                    Param.Add(new SqlParameter("@JobSiteState", CbDt.Rows[i]["JobSiteState"].ToString()));
                    Param.Add(new SqlParameter("@Crane1CD", CbDt.Rows[i]["Crane1CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane2CD", CbDt.Rows[i]["Crane2CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane3CD", CbDt.Rows[i]["Crane3CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane4CD", CbDt.Rows[i]["Crane4CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane5CD", CbDt.Rows[i]["Crane5CD"].ToString()));
                    Param.Add(new SqlParameter("@Crane6CD", CbDt.Rows[i]["Crane6CD"].ToString()));
                    Param.Add(new SqlParameter("@CraneUser", CbDt.Rows[i]["CraneUser"].ToString()));
                    Param.Add(new SqlParameter("@CraneUserInfo", CbDt.Rows[i]["CraneUserInfo"].ToString()));
                    Param.Add(new SqlParameter("@CraneUserTitle", CbDt.Rows[i]["CraneUserTitle"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformManufacturer", CbDt.Rows[i]["WorkPlatformManufacturer"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformModel", CbDt.Rows[i]["WorkPlatformModel"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperName", CbDt.Rows[i]["WorkPlatformSuperName"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperPhone", CbDt.Rows[i]["WorkPlatformSuperPhone"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperFax", CbDt.Rows[i]["WorkPlatformSuperFax"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperAddr", CbDt.Rows[i]["WorkPlatformSuperAddr"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperCity", CbDt.Rows[i]["WorkPlatformSuperCity"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperZip", CbDt.Rows[i]["WorkPlatformSuperZip"].ToString()));
                    Param.Add(new SqlParameter("@WorkPlatformSuperState", CbDt.Rows[i]["WorkPlatformSuperState"].ToString()));
                    Param.Add(new SqlParameter("@FirstVariance", CbDt.Rows[i]["FirstVariance"].ToString()));
                    Param.Add(new SqlParameter("@BIN", CbDt.Rows[i]["BIN"].ToString()));
                    Param.Add(new SqlParameter("@CBNum", CbDt.Rows[i]["CBNum"].ToString()));
                    Param.Add(new SqlParameter("@AptorCondoNum", CbDt.Rows[i]["AptorCondoNum"].ToString()));
                    Param.Add(new SqlParameter("@SpecialPlaceName", CbDt.Rows[i]["SpecialPlaceName"].ToString()));
                    Param.Add(new SqlParameter("@SubName", CbDt.Rows[i]["SubName"].ToString()));
                    Param.Add(new SqlParameter("@SubInfo", CbDt.Rows[i]["SubInfo"].ToString()));
                    Param.Add(new SqlParameter("@ResidenceWithin200ft", CbDt.Rows[i]["ResidenceWithin200ft"].ToString()));
                    Param.Add(new SqlParameter("@DaysofVariance", CbDt.Rows[i]["DaysofVariance"].ToString()));
                    Param.Add(new SqlParameter("@DatesofVariance", CbDt.Rows[i]["DatesofVariance"].ToString()));
                    Param.Add(new SqlParameter("@TimeofVarianceFrom", CbDt.Rows[i]["TimeofVarianceFrom"].ToString()));
                    Param.Add(new SqlParameter("@TimeofVarianceTo", CbDt.Rows[i]["TimeofVarianceTo"].ToString()));
                    Param.Add(new SqlParameter("@VarianceWorkDescription", CbDt.Rows[i]["VarianceWorkDescription"].ToString()));
                    Param.Add(new SqlParameter("@ReasonforVariance", CbDt.Rows[i]["ReasonforVariance"].ToString()));
                    Param.Add(new SqlParameter("@SiteArchitect", CbDt.Rows[i]["SiteArchitect"].ToString()));
                    Param.Add(new SqlParameter("@CommunityBoardID", CbDt.Rows[i]["CommunityBoardID"].ToString()));
                    Param.Add(new SqlParameter("@SiteNumofStories", CbDt.Rows[i]["SiteNumofStories"].ToString()));
                    Param.Add(new SqlParameter("@SiteOccupancy", CbDt.Rows[i]["SiteOccupancy"].ToString()));
                    // Param.Add(new SqlParameter("@SiteOccupancy", CbDt.Rows[i]["SiteOccupancy"].ToString())
                    Param.Add(new SqlParameter("@OccupancyType", CbDt.Rows[i]["OccupancyType"].ToString()));
                    Param.Add(new SqlParameter("@SiteNumofApts", CbDt.Rows[i]["SiteNumofApts"].ToString()));
                    Param.Add(new SqlParameter("@SiteNumofAptsCurrent", CbDt.Rows[i]["SiteNumofAptsCurrent"].ToString()));
                    Param.Add(new SqlParameter("@SiteNumofAptsProposed", CbDt.Rows[i]["SiteNumofAptsProposed"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwner", CbDt.Rows[i]["SiteOwner"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerAddress", CbDt.Rows[i]["SiteOwnerAddress"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerStreet", CbDt.Rows[i]["SiteOwnerStreet"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerCity", CbDt.Rows[i]["SiteOwnerCity"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerState", CbDt.Rows[i]["SiteOwnerState"].ToString()));
                    Param.Add(new SqlParameter("@SiteOwnerZip", CbDt.Rows[i]["SiteOwnerZip"].ToString()));
                    Param.Add(new SqlParameter("@WorkProposed", CbDt.Rows[i]["WorkProposed"].ToString()));
                    Param.Add(new SqlParameter("@Architect2", CbDt.Rows[i]["Architect2"].ToString()));
                    Param.Add(new SqlParameter("@Architect2fullAddress", CbDt.Rows[i]["Architect2fullAddress"].ToString()));
                    WebSqlCon.Open();
                    // //Update at webserver system
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local update
                    VBFormInfo.InsertRecord("UPDATE VBFormInfo SET IsChange=0 WHERE JobID=" + CbDt.Rows[i]["JobID"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
            // **************************************Delete*****************************

            CbDt = VBFormInfo.Filldatatable("SELECT * FROM VBFormInfo where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    Cmd = new SqlCommand("", WebSqlCon);
                    Cmd.CommandText = "delete VBFormInfo where JobID=" + CbDt.Rows[i]["JobID"].ToString() + "";
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    VBFormInfo.InsertRecord("delete VBFormInfo WHERE JobID=" + CbDt.Rows[i]["JobID"].ToString() + " ");
                    DeletedRows = Conversions.ToInteger(DeletedRows == 1);
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        private void VBNetApplicantInfo()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            // Cmd = New SqlCommand("", WebSqlCon)
            var VBNetApplicantInfo = new DataAccessLayer();
            CbDt = VBNetApplicantInfo.Filldatatable("SELECT * FROM VBNetApplicantInfo where IsNewRecord=1");
            string query;
            query = "INSERT INTO VBNetApplicantInfo (ApplicantFirstName,ApplicantLastName,ApplicantMidName,ApplicantBusinessName,ApplicantBusinessAddress,ApplicantBusinessCity,ApplicantBusinessState,ApplicantBusinessZip,ApplicantTitle,ApplicantLicense,ApplicantPhone,Applicantfax) VALUES (  @ApplicantFirstName, @ApplicantLastName, @ApplicantMidName, @ApplicantBusinessName, @ApplicantBusinessAddress, @ApplicantBusinessCity, @ApplicantBusinessState, @ApplicantBusinessZip, @ApplicantTitle, @ApplicantLicense, @ApplicantPhone, @Applicantfax)";
            try
            {
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@ApplicantFirstName", CbDt.Rows[i]["ApplicantFirstName"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantLastName", CbDt.Rows[i]["ApplicantLastName"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantMidName", CbDt.Rows[i]["ApplicantMidName"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessName", CbDt.Rows[i]["ApplicantBusinessName"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessAddress", CbDt.Rows[i]["ApplicantBusinessAddress"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessCity", CbDt.Rows[i]["ApplicantBusinessCity"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessState", CbDt.Rows[i]["ApplicantBusinessState"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessZip", CbDt.Rows[i]["ApplicantBusinessZip"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantTitle", CbDt.Rows[i]["ApplicantTitle"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantLicense", CbDt.Rows[i]["ApplicantLicense"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantPhone", CbDt.Rows[i]["ApplicantPhone"].ToString()));
                    Param.Add(new SqlParameter("@Applicantfax", CbDt.Rows[i]["Applicantfax"].ToString()));
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    VBNetApplicantInfo.InsertRecord("UPDATE VBNetApplicantInfo SET IsNewRecord=0 WHERE ApplicantID=" + CbDt.Rows[i]["ApplicantID"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // **************************************Update*****************************
            query = string.Empty;
            CbDt = VBNetApplicantInfo.Filldatatable("SELECT * FROM VBNetApplicantInfo where IsChange=1");
            WebTable = FillWebTable("SELECT * FROM VBNetApplicantInfo where IsChange=1");
            query = "Update  VBNetApplicantInfo SET ApplicantFirstName = @ApplicantFirstName,ApplicantLastName = @ApplicantLastName,ApplicantMidName = @ApplicantMidName,ApplicantBusinessName = @ApplicantBusinessName,ApplicantBusinessAddress = @ApplicantBusinessAddress,ApplicantBusinessCity = @ApplicantBusinessCity,ApplicantBusinessState = @ApplicantBusinessState,ApplicantBusinessZip = @ApplicantBusinessZip,ApplicantTitle = @ApplicantTitle,ApplicantLicense = @ApplicantLicense,ApplicantPhone = @ApplicantPhone,Applicantfax = @Applicantfax,IsChange=@IsChange WHERE ApplicantID = @ApplicantID";
            try
            {
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    for (int j = 0, loopTo2 = WebTable.Rows.Count - 1; j <= loopTo2; j++)
                    {
                        if (CbDt.Rows[i]["ApplicantID"].ToString() == WebTable.Rows[j]["ApplicantID"].ToString())
                        {
                            if (CbDt.Rows[i]["IsChange"].ToString() == WebTable.Rows[j]["IsChange"].ToString())
                            {
                                if (Operators.CompareString(Strings.Format(Conversions.ToDate(CbDt.Rows[i]["ChangeDate"].ToString()), "MM/dd/yyyy"), Strings.Format(Conversions.ToDate(WebTable.Rows[j]["ChangeDate"].ToString()), "MM/dd/yyyy"), false) < 0)
                                {
                                    VBNetApplicantInfo.InsertRecord("UPDATE Contacts SET IsChange=0 WHERE ContactsID=" + CbDt.Rows[i]["ContactsID"].ToString() + " ");
                                    VBNetApplicantInfo.InsertRecord("UPDATE Contacts SET IsChange=0 WHERE ContactsID=" + CbDt.Rows[i]["ContactsID"].ToString() + " ");
                                    CbDt.Rows.RemoveAt(i);
                                }
                            }
                        }
                    }
                }

                for (int i = 0, loopTo3 = CbDt.Rows.Count - 1; i <= loopTo3; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@IsChange", 0));
                    Param.Add(new SqlParameter("@ApplicantID", CbDt.Rows[i]["ApplicantID"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantFirstName", CbDt.Rows[i]["ApplicantFirstName"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantLastName", CbDt.Rows[i]["ApplicantLastName"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantMidName", CbDt.Rows[i]["ApplicantMidName"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessName", CbDt.Rows[i]["ApplicantBusinessName"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessAddress", CbDt.Rows[i]["ApplicantBusinessAddress"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessCity", CbDt.Rows[i]["ApplicantBusinessCity"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessState", CbDt.Rows[i]["ApplicantBusinessState"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantBusinessZip", CbDt.Rows[i]["ApplicantBusinessZip"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantTitle", CbDt.Rows[i]["ApplicantTitle"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantLicense", CbDt.Rows[i]["ApplicantLicense"].ToString()));
                    Param.Add(new SqlParameter("@ApplicantPhone", CbDt.Rows[i]["ApplicantPhone"].ToString()));
                    Param.Add(new SqlParameter("@Applicantfax", CbDt.Rows[i]["Applicantfax"].ToString()));
                    WebSqlCon.Open();
                    // //Update at webserver system
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local update
                    VBNetApplicantInfo.InsertRecord("UPDATE VBNetApplicantInfo SET IsChange=0 WHERE ApplicantID=" + CbDt.Rows[i]["ApplicantID"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
            // **************************************Delete*****************************

            CbDt = VBNetApplicantInfo.Filldatatable("SELECT * FROM VBNetApplicantInfo where IsDelete=1");
            try
            {
                for (int i = 0, loopTo4 = CbDt.Rows.Count - 1; i <= loopTo4; i++)
                {
                    Cmd = new SqlCommand("", WebSqlCon);
                    Cmd.CommandText = "delete VBNetApplicantInfo where ApplicantID=" + CbDt.Rows[i]["ApplicantID"].ToString() + "";
                    WebSqlCon.Open();
                    // Update Web Server
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    // //Local Table
                    VBNetApplicantInfo.InsertRecord("Delete VBNetApplicantInfo where WHERE ApplicantID=" + CbDt.Rows[i]["ApplicantID"].ToString() + " ");
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        public void Invoice()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            string query;
            // Cmd = New SqlCommand("", WebSqlCon)
            var Invoice = new DataAccessLayer();
            try
            {
                CbDt = Invoice.Filldatatable("SELECT * FROM Invoice where IsNewRecord=1");
                query = "INSERT INTO invoice(JobListID,InvoiceDate,InvoiceNumber,InvoiceFileName,Comments,InvoiceFileType,UploadFile) Values(@JobListID,@InvoiceDate,@InvoiceNumber,@InvoiceFileName,@Comments,@InvoiceFileType,@UploadFile)";
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Cmd.Connection = WebSqlCon;
                    Param.Add(new SqlParameter("@JobListID", CbDt.Rows[i]["JobListID"].ToString()));
                    Param.Add(new SqlParameter("@InvoiceDate", Strings.Format(CbDt.Rows[i]["InvoiceDate"], "MM/dd/yyyy")));
                    Param.Add(new SqlParameter("@InvoiceNumber", CbDt.Rows[i]["InvoiceNumber"].ToString()));
                    Param.Add(new SqlParameter("@InvoiceFileName", CbDt.Rows[i]["InvoiceFileName"].ToString()));
                    Param.Add(new SqlParameter("@Comments", CbDt.Rows[i]["Comments"].ToString()));
                    Param.Add(new SqlParameter("@InvoiceFileType", CbDt.Rows[i]["InvoiceFileType"].ToString()));
                    Param.Add(new SqlParameter("@UploadFile", CbDt.Rows[i]["UploadFile"].ToString()));
                    WebSqlCon.Open();
                    // Update WebSErver
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    Cmd = new SqlCommand("SELECT ISNULL(max(invoiceID),0) as id FROM Invoice", WebSqlCon);
                    long InvoiceID;
                    WebSqlCon.Open();
                    InvoiceID = Conversions.ToLong(Cmd.ExecuteScalar());
                    WebSqlCon.Close();
                    // InsertUpdateInvoiceFileWeb(CbDt.Rows[i]["InvoiceID"].ToString())
                    InsertUpdateInvoiceFileWeb(InvoiceID.ToString());
                    // Update Local Server
                    Invoice.InsertRecord("UPDATE invoice SET IsNewRecord=0 WHERE InvoiceID=" + CbDt.Rows[i]["InvoiceID"].ToString() + " ");
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Invoice Table Excetption Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Invoice Table Excetption Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
            // '''''''Update Web Server
            try
            {
                CbDt = Invoice.Filldatatable("SELECT * FROM invoice where IsChange=1");
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    Cmd = new SqlCommand();
                    Cmd.CommandText = "UPDATE Invoice SET JobListID=@JobListID,InvoiceDate=@InvoiceDate,InvoiceNumber=@InvoiceNumber,InvoiceFileName=@InvoiceFileName,Comments=@Comments,InvoiceFileType=@InvoiceFileType,UploadFile=@UploadFile WHERE invoiceID=@invoiceID";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@JobListID", CbDt.Rows[i]["JobListID"].ToString()));
                    Param.Add(new SqlParameter("@InvoiceDate", CbDt.Rows[i]["InvoiceDate"].ToString()));
                    Param.Add(new SqlParameter("@InvoiceNumber", CbDt.Rows[i]["InvoiceNumber"].ToString()));
                    Param.Add(new SqlParameter("@InvoiceFileName", CbDt.Rows[i]["InvoiceFileName"].ToString()));
                    Param.Add(new SqlParameter("@Comments", CbDt.Rows[i]["Comments"].ToString()));
                    Param.Add(new SqlParameter("@invoiceID", CbDt.Rows[i]["InvoiceID"].ToString()));
                    Param.Add(new SqlParameter("@InvoiceFileType", CbDt.Rows[i]["InvoiceFileType"].ToString()));
                    Param.Add(new SqlParameter("@UploadFile", CbDt.Rows[i]["UploadFile"].ToString()));
                    WebSqlCon.Open();
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    InsertUpdateInvoiceFileWeb(CbDt.Rows[i]["InvoiceID"].ToString());
                    Invoice.InsertRecord("UPDATE invoice SET IsChange=0 WHERE InvoiceID=" + CbDt.Rows[i]["InvoiceID"].ToString() + " ");
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Invoice Table Excetption Message");
            }
            catch (Exception ex1)
            {
                KryptonMessageBox.Show(ex1.Message, "Invoice Table Excetption Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
            // 'Deletd Web Invoice Record
            try
            {
                CbDt = Invoice.Filldatatable("SELECT InvoiceID FROM invoice where IsDelete=1");
                for (int i = 0, loopTo2 = CbDt.Rows.Count - 1; i <= loopTo2; i++)
                {
                    Cmd = new SqlCommand();
                    Cmd.CommandText = "DELETE FROM Invoice WHERE InvoiceId=" + CbDt.Rows[i]["InvoiceID"].ToString() + "";
                    Cmd.Connection = WebSqlCon;
                    WebSqlCon.Open();
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    Invoice.InsertRecord("DELETE FROM Invoice WHERE InvoiceId=" + CbDt.Rows[i]["InvoiceID"].ToString());
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Invoice Table Excetption Message");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        public void InsertUpdateInvoiceFileWeb(string InvoiceId)
        {
            var dt = new DataTable();
            var Filldt = new DataAccessLayer();
            dt = Filldt.Filldatatable("Select InvoiceFile from  Invoice where InvoiceID=" + InvoiceId + "");
            try
            {
                byte[] Filbyte;
                Filbyte = dt.Rows(0).Item("InvoiceFile");
                long k;
                k = Information.UBound(Filbyte);
                if (k > 0L)
                {
                    try
                    {
                        int GetId;
                        // Cmd = New SqlCommand
                        // Cmd.CommandText = "select ISNULL(max(invoiceID),0) as id from Invoice"
                        // Cmd.Connection = WebSqlCon
                        // WebSqlCon.Open()
                        // GetId = Cmd.ExecuteScalar()
                        // WebSqlCon.Close()
                        Cmd = new SqlCommand();
                        Cmd.CommandText = "UPDATE Invoice set InvoiceFile=@InvoiceFile where invoiceID=" + InvoiceId + " ";
                        List<SqlParameter> Param = new List<SqlParameter>();
                        Param.Add(new SqlParameter("@InvoiceFile", Filbyte));
                        WebSqlCon.Open();
                        Cmd.ExecuteNonQuery();
                        WebSqlCon.Close();
                    }
                    catch (SqlException ex)
                    {
                        InsertUpdateInvoiceFileWeb(InvoiceId);
                    }
                    finally
                    {
                        WebSqlCon.Close();
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        public void MasterTrackSub()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            string query;
            // Cmd = New SqlCommand("", WebSqlCon)
            var MasterTrackSet = new DataAccessLayer();
            try
            {
                CbDt = MasterTrackSet.Filldatatable("SELECT * FROM MasterTrackSet WHERE IsNewRecord=1");
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    Cmd = new SqlCommand();
                    Cmd.Connection = WebSqlCon;
                    Cmd.CommandText = "INSERT INTO MasterTrackSet(TrackSet, TrackName) VALUES (@TrackSet,@TrackName)";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@TrackSet", CbDt.Rows[i]["TrackSet"].ToString()));
                    Param.Add(new SqlParameter("@TrackName", CbDt.Rows[i]["TrackName"].ToString()));
                    WebSqlCon.Open();
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    MasterTrackSet.InsertRecord("UPDATE MasterTrackSet SET IsNewRecord=0 WHERE Id=" + CbDt.Rows[i]["Id"].ToString());
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "MasterTrackSet Table Updation Error");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // UPDATE RECORD

            try
            {
                CbDt = MasterTrackSet.Filldatatable("SELECT * FROM MasterTrackSet WHERE IsChange=1");
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    Cmd = new SqlCommand();
                    Cmd.Connection = WebSqlCon;
                    Cmd.CommandText = "UPDATE MasterTrackSet SET TrackSet=@TrackSet, TrackName=@TrackName WHERE Id=@Id ";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@TrackSet", CbDt.Rows[i]["TrackSet"].ToString()));
                    Param.Add(new SqlParameter("@TrackName", CbDt.Rows[i]["TrackName"].ToString()));
                    Param.Add(new SqlParameter("@Id", CbDt.Rows[i]["Id"].ToString()));
                    WebSqlCon.Open();
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    MasterTrackSet.InsertRecord("UPDATE MasterTrackSet SET IsChange=0 WHERE Id=" + CbDt.Rows[i]["Id"].ToString());
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "MasterTrackSet Table Updation Error");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // 'DELTE RECORD
            try
            {
                CbDt = MasterTrackSet.Filldatatable("SELECT * FROM MasterTrackSet WHERE IsDelete=1");
                for (int i = 0, loopTo2 = CbDt.Rows.Count - 1; i <= loopTo2; i++)
                {
                    Cmd = new SqlCommand();
                    Cmd.Connection = WebSqlCon;
                    Cmd.CommandText = "DELETE FROM MasterTrackSet WHERE Id=@Id) ";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@Id", CbDt.Rows[i]["Id"].ToString()));
                    WebSqlCon.Open();
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    MasterTrackSet.InsertRecord("DELETE FROM MasterTrackSet WHERE Id=" + CbDt.Rows[i]["Id"].ToString());
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "MasterTrackSet Table Updation Error");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        public void MasterTrackSubItem()
        {
            var CbDt = new DataTable();
            var WebTable = new DataTable();
            string query;
            // Cmd = New SqlCommand("", WebSqlCon)
            var MasterTrackSet = new DataAccessLayer();
            try
            {
                CbDt = MasterTrackSet.Filldatatable("SELECT * FROM MasterTrackSubItem WHERE IsNewRecord=1");
                for (int i = 0, loopTo = CbDt.Rows.Count - 1; i <= loopTo; i++)
                {
                    Cmd = new SqlCommand();
                    Cmd.Connection = WebSqlCon;
                    Cmd.CommandText = "INSERT INTO MasterTrackSubItem(TrackId,TrackName,TrackSubName) VALUES (@TrackId,@TrackName,@TrackSubName)";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@TrackSubName", CbDt.Rows[i]["TrackSubName"].ToString()));
                    Param.Add(new SqlParameter("@TrackName", CbDt.Rows[i]["TrackName"].ToString()));
                    Param.Add(new SqlParameter("@TrackId", CbDt.Rows[i]["TrackId"].ToString()));
                    WebSqlCon.Open();
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    MasterTrackSet.InsertRecord("UPDATE MasterTrackSubItem SET IsNewRecord=0 WHERE Id=" + CbDt.Rows[i]["Id"].ToString());
                    InsertedRows = InsertedRows + 1;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "MasterTrackSubItem Table Updation Error");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // UPDATE RECORD

            try
            {
                CbDt = MasterTrackSet.Filldatatable("SELECT * FROM MasterTrackSubItem WHERE IsChange=1");
                for (int i = 0, loopTo1 = CbDt.Rows.Count - 1; i <= loopTo1; i++)
                {
                    Cmd = new SqlCommand();
                    Cmd.Connection = WebSqlCon;
                    Cmd.CommandText = "UPDATE MasterTrackSubItem SET TrackSubName=@TrackSubName,TrackName=@TrackName,TrackId=@TrackId WHERE Id=@Id ";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@TrackSubName", CbDt.Rows[i]["TrackSubName"].ToString()));
                    Param.Add(new SqlParameter("@TrackName", CbDt.Rows[i]["TrackName"].ToString()));
                    Param.Add(new SqlParameter("@TrackId", CbDt.Rows[i]["TrackId"].ToString()));
                    Param.Add(new SqlParameter("@Id", CbDt.Rows[i]["Id"].ToString()));
                    WebSqlCon.Open();
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    MasterTrackSet.InsertRecord("UPDATE MasterTrackSubItem SET IsChange=0 WHERE Id=" + CbDt.Rows[i]["Id"].ToString());
                    UpdatedRows = UpdatedRows + 1;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "MasterTrackSubItem Table Updation Error");
            }
            finally
            {
                WebSqlCon.Close();
            }

            // 'DELTE RECORD
            try
            {
                CbDt = MasterTrackSet.Filldatatable("SELECT * FROM MasterTrackSubItem WHERE IsDelete=1");
                for (int i = 0, loopTo2 = CbDt.Rows.Count - 1; i <= loopTo2; i++)
                {
                    Cmd = new SqlCommand();
                    Cmd.Connection = WebSqlCon;
                    Cmd.CommandText = "DELETE FROM MasterTrackSubItem WHERE Id=@Id ";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@Id", CbDt.Rows[i]["Id"].ToString()));
                    WebSqlCon.Open();
                    Cmd.ExecuteNonQuery();
                    WebSqlCon.Close();
                    MasterTrackSet.InsertRecord("DELETE FROM MasterTrackSubItem WHERE Id=" + CbDt.Rows[i]["Id"].ToString());
                    DeletedRows = DeletedRows + 1;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "MasterTrackSubItem Table Updation Error");
            }
            finally
            {
                WebSqlCon.Close();
            }
        }

        private void SelecttionTable(string SelStr)
        {
            switch (SelStr ?? "")
            {
                case "CommunityBoard":
                    {
                        CommunityBoard();
                        break;
                    }

                case "Company":
                    {
                        Company();
                        break;
                    }

                case "Contacts":
                    {
                        Contacts();
                        break;
                    }

                case "JobList":
                    {
                        JobList();
                        break;
                    }

                case "JobTracking":
                    {
                        JobTracking();
                        break;
                    }

                case "MasterItem":
                    {
                        MasterItem();
                        break;
                    }

                case "VBCDDatabase":
                    {
                        VBCDDatabase();
                        break;
                    }

                case "VBFormInfo":
                    {
                        VBFormInfo();
                        break;
                    }

                case "VBNetApplicantInfo":
                    {
                        VBNetApplicantInfo();
                        break;
                    }

                case "Invoice":
                    {
                        Invoice();
                        break;
                    }

                case "MasterTrackSubItem":
                    {
                        MasterTrackSubItem();
                        break;
                    }

                case "MasterTrackSet":
                    {
                        MasterTrackSub();
                        break;
                    }
            }
        }

        private DataTable FillWebTable(string Query)
        {
            try
            {
                var adp = new SqlDataAdapter(Query, WebSqlCon);
                var dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count >= 0)
                {
                    return dt;
                }
                else
                {
                    return default;
                }
            }
            catch (Exception ex)
            {
            }

            return default;
        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            double per = 100d / Count;
            BackgroundWorker worker = (BackgroundWorker)sender;
            double i;
            var loopTo = (double)Count;
            for (i = 1d; i <= loopTo; i++)
            {
                worker.ReportProgress(Convert.ToInt32( i * per));
                // ProgressBar1.Value = i
                System.Threading.Thread.Sleep(50);
            }

            // ProgressBar1.Visible = False
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 100)
            {
                ApplicationBusy(false);
            }
        }

        private void chkReminder_CheckedChanged(object sender, EventArgs e)
        {
            // If chkReminder.Checked = True Then
            // UpdateAppSettings_("True")
            // Else
            // UpdateAppSettings_("False")
            // End If
            GetEmailAddress();
            try
            {
                var CheckMail = new XmlDocument();
                CheckMail.Load(Application.StartupPath + @"\CheckFile.xml");
                var reminder = CheckMail.SelectSingleNode("/EmailReminder/CheckBox");
                if (chkReminder.Checked == true)
                {
                    pnlEmailREminder.Visible = true;
                    // PnlSenderEmail.Visible = True
                    reminder.ChildNodes[0].InnerText = Conversions.ToString(true);
                }
                else
                {
                    // PnlSenderEmail.Visible = False
                    pnlEmailREminder.Visible = false;
                    reminder.ChildNodes[0].InnerText = Conversions.ToString(false);
                }

                CheckMail.Save(Application.StartupPath + @"\CheckFile.xml");
            }
            catch (IOException ex1)
            {
                MessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message + " Please check the access right of it.");
            }

            Program.ofrmMain.timerGet.Enabled = Convert.ToBoolean( chkReminder.CheckState);
            checkStatus();
        }

        public static void UpdateAppSettings_(string state)
        {
            // AppDomain.CurrentDomain.SetupInformation.ConfigurationFile 
            // This will get the app.config file path from Current application Domain
            var XmlDoc = new XmlDocument();
            // Load XML Document
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            // XmlDoc.Load()
            // Navigate Each XML Element of app.Config file
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "appSettings")
                {
                    foreach (XmlNode xNode in xElement.ChildNodes)
                    {
                        if (xNode.Attributes[0].Value == "EmailReminder")
                        {
                            xNode.Attributes[1].Value = state;
                            break;
                        }
                    }
                }
            }
            // Save app.config file
            XmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
        }

        protected bool SetEmailReminder()
        {
            bool state;
            var XmlDoc = new XmlDocument();
            // Load XML Document
            XmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            // Navigate Each XML Element of app.Config file
            foreach (XmlElement xElement in XmlDoc.DocumentElement)
            {
                if (xElement.Name == "appSettings")
                {
                    // Loop each node of appSettings Element 
                    // xNode.Attributes(0).Value , Mean First Attributes of Node , 
                    // KeyName Portion
                    // xNode.Attributes(1).Value , Mean Second Attributes of Node,
                    // KeyValue Portion
                    foreach (XmlNode xNode in xElement.ChildNodes)
                    {
                        if (xNode.Attributes[0].Value == "EmailReminder")
                        {
                            state = Conversions.ToBoolean(xNode.Attributes[1].Value);
                            return state;
                        }
                    }
                }
            }

            return default;
        }

        public void checkStatus()
        {
            var CheckMail = new XmlDocument();
            CheckMail.Load(Application.StartupPath + @"\CheckFile.xml");
            var reminder = CheckMail.SelectSingleNode("/EmailReminder/CheckBox");
            if (Conversions.ToBoolean(reminder.ChildNodes.Item(0).InnerText.Trim()) == true)
            {
                chkReminder.Checked = true;
            }
            else
            {
                chkReminder.Checked = false;
            }

            if (Conversions.ToBoolean(reminder.ChildNodes.Item(1).InnerText.Trim()) == true)
            {
                rdbDaily.Checked = true;
            }
            else
            {
                rdbDaily.Checked = false;
            }

            if (Conversions.ToBoolean(reminder.ChildNodes.Item(2).InnerText.Trim()) == true)
            {
                rdbDaily.Checked = true;
            }
            else
            {
                rdbDaily.Checked = false;
            }

            if (Conversions.ToBoolean(reminder.ChildNodes.Item(3).InnerText.Trim()) == true)
            {
                rdbWeekly.Checked = true;
            }
            else
            {
                rdbWeekly.Checked = false;
            }
        }

        private void rdbHourly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var CheckMail = new XmlDocument();
                CheckMail.Load(Application.StartupPath + @"\CheckFile.xml");
                var reminder = CheckMail.SelectSingleNode("/EmailReminder/CheckBox");
                if (rdbHourly.Checked == true)
                {
                    reminder.ChildNodes[1].InnerText = Conversions.ToString(true);
                }
                else
                {
                    reminder.ChildNodes[1].InnerText = Conversions.ToString(false);
                }

                CheckMail.Save(Application.StartupPath + @"\CheckFile.xml");
            }
            catch (IOException ex1)
            {
                MessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message + " Please check the access right of it.");
            }

            Program.ofrmMain.timerGet.Interval = 3600000;
        }

        private void rdbDaily_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var CheckMail = new XmlDocument();
                CheckMail.Load(Application.StartupPath + @"\CheckFile.xml");
                var reminder = CheckMail.SelectSingleNode("/EmailReminder/CheckBox");
                if (rdbDaily.Checked == true)
                {
                    reminder.ChildNodes[2].InnerText = Conversions.ToString(true);
                }
                else
                {
                    reminder.ChildNodes[2].InnerText = Conversions.ToString(false);
                }

                CheckMail.Save(Application.StartupPath + @"\CheckFile.xml");
            }
            catch (IOException ex1)
            {
                MessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message + " Please check the access right of it.");
            }
        }

        private void rdbWeekly_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var CheckMail = new XmlDocument();
                CheckMail.Load(Application.StartupPath + @"\CheckFile.xml");
                var reminder = CheckMail.SelectSingleNode("/EmailReminder/CheckBox");
                if (rdbWeekly.Checked == true)
                {
                    reminder.ChildNodes[3].InnerText = Conversions.ToString(true);
                }
                else
                {
                    reminder.ChildNodes[3].InnerText = Conversions.ToString(false);
                }

                CheckMail.Save(Application.StartupPath + @"\CheckFile.xml");
            }
            catch (IOException ex1)
            {
                MessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message + " Please check the access right of it.");
            }
        }

        private void GetEmailAddress()
        {
            try
            {
                var CheckMail = new XmlDocument();
                CheckMail.Load(Application.StartupPath + @"\CheckFile.xml");
                var reminder = CheckMail.SelectSingleNode("/EmailReminder/Email");
                this.txtEmailaddress.Text = reminder.ChildNodes.Item(0).InnerText.Trim();
                this.txtEmailpassword.Text = reminder.ChildNodes.Item(1).InnerText.Trim();
            }
            // CheckMail.Save(Application.StartupPath & "\CheckFile.xml")
            catch (IOException ex1)
            {
                MessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message + " Please check the access right of it.");
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                var CheckMail = new XmlDocument();
                CheckMail.Load(Application.StartupPath + @"\CheckFile.xml");
                var reminder = CheckMail.SelectSingleNode("/EmailReminder/Email");
                reminder.ChildNodes.Item(0).InnerText = this.txtEmailaddress.Text.Trim();
                reminder.ChildNodes.Item(1).InnerText = this.txtEmailpassword.Text.Trim();
                CheckMail.Save(Application.StartupPath + @"\CheckFile.xml");
            }
            catch (IOException ex1)
            {
                MessageBox.Show(ex1.Message + " Please check the access right of it.");
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message + " Please check the access right of it.");
            }
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Convert.ToBoolean( e.Result) == true | e.Cancelled == true)
            {
                ApplicationBusy(false);
            }
        }
    }
}