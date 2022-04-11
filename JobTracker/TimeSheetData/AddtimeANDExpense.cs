using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer.Model;
using DataAccessLayer;
using DataAccessLayer.Repositories;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Excel = Microsoft.Office.Interop.Excel;

using NPOI.HSSF.UserModel;
using System.Data.SqlClient;
using System.Threading;

namespace JobTracker.TimeSheetData
{
    public partial class AddtimeANDExpense : Form
    {
        #region Declaration
        private int result = 0;
        private int SelectJobListID;
        private int selectempID;
        // Dim selectUserID As Integer
        private string CheckString1;
        private string CheckString;
        private int selectUserJoblistID;
        private string userID;

        bool IsInvoiceClick = false;

        private DataTable dtTimeExportExcelSheet = new DataTable();
        private DataTable dtExpensesExportExcelSheet = new DataTable();
        //public JobAndTrackingMDI MdiInstance;
        //private static AddtimeANDExpense _Instance;
        private Button BillStateChangeButton = new Button();
        private Button ExpBillStateButton = new Button();
        #endregion

        string InvoiceClick = string.Empty;
        string NonInvoiceClick = string.Empty;

        public AddtimeANDExpense()
        {
            InitializeComponent();
        }

        #region Events
        private void AddtimeANDExpense_Load(System.Object sender, System.EventArgs e)
        {
            try
            {
                init();

                userID =  Properties.Settings.Default.timeSheetLoginUserID.ToString();
                
                Program.ofrmMain.LoginChange += OnLoginChangeEvent;
                ProgressBar1.Visible = false;
                Label2.Visible = false;
                fillcmbItemSTATUS_grdTimeAndExp();
                fillcmbItemBILLSTATE_grdTimeAndExp();
                fillcmbAdminStatus_grdTimeAndExp();
                fillcmbUserTimeAndExp();
                btnSave.Visible = true;

                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    // pnlUSerLoginCombo.Visible = True
                    btnSave.Visible = true;
                    lblPM.Enabled = true;
                    cmbUserSearch.Enabled = true;
                }
                else
                {
                    cmbAdminMass.Visible = false;
                    lbMassAdminStatusChange.Visible = false;
                    lblMassStatuesChange.Visible = false;
                    cmbMassStatusChange.Visible = false;
                    btnChangeMASS.Visible = false;
                }
                FillcmbUser();
                fillcmbUserSearchTimeAndExp();
                cmbBillStatus.Text = "Submit";
                //  cmbAdminStatus.Text = "All"
                if (ckbTime.Checked == true)
                {
                    gbDateUserSearch.Enabled = true;
                }

                Fillcombo();
                fillGridJobList();

                fillTimeSheet();
                fillExpences();

                //fillcmbItemSTATUS_grdTimeAndExp()
                // fillcmbItemBILLSTATE_grdTimeAndExp()
                if (!pnlUSerLoginCombo.Visible)
                {
                    //selectempID = Properties.Settings.Default.timeSheetLoginUserID;

                    selectempID = Convert.ToInt32(Properties.Settings.Default.timeSheetLoginUserID);


                    //Properties.Settings.Default.timeSheetLoginUserID
                }

                ApplyTimeSheetPageLoadSetting();
                if (ckbTime.Checked == true)
                {
                    btnPunchHousvsJT.Enabled = true;
                }
                OnLoginChangeEvent(new object(), new EventArgs());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtJobListJobID_TextChanged(System.Object sender, System.EventArgs e)
        {
            fillGridJobList();
        }

        public static DataTable ToDataTableAddTime<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();
            for (int i = 0; i < properties.Count; i++)
            {
                PropertyDescriptor property = properties[i];
                //dt.Columns.Add(property.Name, property.PropertyType);

                dt.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);

            }
            object[] values = new object[properties.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = properties[i].GetValue(item);
                }
                dt.Rows.Add(values);
            }
            return dt;
        }


        private void grdJobList_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    //  btnSave.Visible = False
                }
                else
                {
                    // btnSave.Visible = True
                }
                if (!Convert.IsDBNull(grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["IsDisable"].Value))
                {
                    if (Convert.ToBoolean(grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["IsDisable"].Value))
                    {
                        MessageBox.Show("Selected job seems disabled. You cannot add time and expenses detail.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                SelectJobListID = Convert.ToInt32(grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobListID"].Value);
                if (e.ColumnIndex == 0)
                {
                    CheckString1 = "";
                }
                else
                {
                    CheckString1 = grdJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                }

                //fillTimeSheet()
                //fillExpences()

                DataTable dt = new DataTable();
                if (tbTimeAndExp.SelectedTab.Text == "Time")
                {
                    //if (grdTimeAndExp.Rows.Count > 0)
                    if (grdTimeAndExp.Rows.Count >= 0)
                    {

                        //dGridResults.ItemsSource = ds.Tables(0).DefaultView

                        //dt = ToDataTable<TS_TimeData>((List<TS_TimeData>)grdTimeAndExp.DataSource);

                        //dt = ToDataTable((List<TS_TimeData>)grdTimeAndExp.DataSource);

                        List<TS_TimeData> FinalResponceData = null;

                        dt = (DataTable)grdTimeAndExp.DataSource;


                        //for(int k=0;k<=dt.Columns.Count;k++)
                        //{

                        //    MessageBox.Show(dt.Columns[k].ColumnName.ToString());
                        //}

                        //List<TS_TimeData>grdTimeAndExp.DataSource

                        //FinalResponceData = (List<TS_TimeData>)grdTimeAndExp.DataSource;

                        //dt = ToDataTableAddTime<TS_TimeData>((List<TS_TimeData>)grdTimeAndExp.DataSource);

                        //dt = Program.ToDataTable<TS_TimeData>((List<TS_TimeData>)grdTimeAndExp.DataSource);

                        //dt = Program.ToDataTable<TS_TimeData>((List<TS_TimeData>)grdTimeAndExp.DataSource);

                        //dt = (DataTable)grdTimeAndExp.DataSource;

                        //FinalResponceData = ((List<TS_TimeData>)grdTimeAndExp.DataSource).ToList();

                        //dt = ToDataTable((List<TS_TimeData>)grdTimeAndExp.DataSource);

                        ////TempDT = ToDataTable(FinalResponceData);





                        DataRow dr = dt.NewRow();
                        dr["JobListID"] = SelectJobListID;
                        dr["TimeSheetID"] = 0;
                        dr["EmployeeDetailsId"] = selectempID;
                        dr["Time"] = 0;
                        if (string.IsNullOrEmpty(cmbUserSearch.Text))
                        {
                            dr["Name"] = Properties.Settings.Default.timeSheetLoginName;
                        }
                        else
                        {
                            dr["Name"] = cmbUserSearch.Text.ToString();
                        }

                        //grdJobList.Columns["JobNumber"].HeaderText = "Job#";
                        //grdJobList.Columns["JobNumber"].Width = 80;

                        //dr["Job Number"] = grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                        dr["Job_Number"] = grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();

                        dr["Date"] = DateTime.Now.ToShortDateString();
                        dr["BillState"] = "Not Invoice";
                        dr["Status"] = "Submit";
                        // dr("MassStatusChangeBox") = "Hold"
                        dr["AdminStatus"] = "None";
                        dt.Rows.Add(dr);
                        grdTimeAndExp.DataSource = dt;

                        if (dt.Rows.Count > 1)
                        {
                            grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
                            grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                        }
                        else
                        {
                            grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Yellow;
                            grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                        }
                    }
                }
                else
                {
                    if (grdTimeAndExp.Rows.Count >= 0)
                    {
                        //dt = Program.ToDataTable<TS_TimeData>((List<TS_TimeData>)grdExpenses.DataSource);
                        dt = (DataTable)grdExpenses.DataSource;


                        DataRow dr = dt.NewRow();
                        dr["JobListID"] = SelectJobListID;
                        dr["TimeSheetExpencesID"] = 0;
                        dr["EmployeeDetailsId"] = selectempID;
                        if (string.IsNullOrEmpty(cmbUserSearch.Text))
                        {
                            dr["Name"] = Properties.Settings.Default.timeSheetLoginName;
                        }
                        else
                        {
                            dr["Name"] = cmbUserSearch.Text.ToString();
                        }

                        //dr["Job Number"] = grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                        dr["Job_Number"] = grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                        
                        dr["Date"] = DateTime.Now.ToShortDateString();
                        dr["BillState"] = "Not Invoice";
                        dr["Status"] = "Submit";
                        dr["AdminStatus"] = "None";
                        // dr("MassStatusChangeBox") = "Hold"
                        dt.Rows.Add(dr);
                        grdExpenses.DataSource = dt;
                        grdExpenses.Rows[grdExpenses.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Yellow;
                        grdExpenses.Rows[grdExpenses.Rows.Count - 1].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                   }
                }
            }
        }
        private void tbTimeAndExp_Click(System.Object sender, System.EventArgs e)
        {
            if (tbTimeAndExp.SelectedTab.Text == "Time")
            {
                lblTotalHours.Visible = true;
                lblTotalAmount.Visible = false;
                TotalHolidayHours.Visible = true;
                lblHoliday.Visible = true;
                btnPunchHousvsJT.Enabled = true;

                lblVacationTime.Visible = true;
                lblSickTime.Visible = true;
                lblPunch.Visible = true;
            }
            else
            {
                lblTotalHours.Visible = false;
                lblTotalAmount.Visible = true;
                TotalHolidayHours.Visible = false;
                lblHoliday.Visible = false;

                lblVacationTime.Visible = false;
                lblSickTime.Visible = false;
                lblPunch.Visible = false;
                btnPunchHousvsJT.Enabled = false;
            }
        }
        private void grdTimeAndExp_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            // If e.ColumnIndex = 0 And e.RowIndex > -1 Then

            //If DataGridView1.Columns(e.ColumnIndex).HeaderText = "MinEquation" Then

            //MessageBox.Show(grdTimeAndExp.Columns[e.ColumnIndex].HeaderText.ToString());
            
            //MessageBox.Show(grdTimeAndExp.Columns[e.ColumnIndex].ToString());

            if (e.RowIndex > -1)
            {

                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    //grdTimeAndExp.Rows[e.RowIndex].Cells["AdminStatus"].ReadOnly = False
                }
                else
                {
                    grdTimeAndExp.Rows[e.RowIndex].Cells["TimeItemNameBILLSTATE"].ReadOnly = true;
                    //grdTimeAndExp.Rows[e.RowIndex].Cells["AdminStatus"].ReadOnly = True
                    grdTimeAndExp.Rows[e.RowIndex].Cells["TimeSheetUser"].ReadOnly = true;

                    for (int Row = 0; Row < grdTimeAndExp.Rows.Count; Row++)
                    {
                        string strvalue = (grdTimeAndExp.Rows[Row].Cells["AdminStatus"].Value.ToString());

                        if (strvalue == "Approved")
                        {
                            grdTimeAndExp.Rows[Row].ReadOnly = true;
                        }
                    }

                }

                //  End If
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {

                    string checkvalue = (grdTimeAndExp.Rows[e.RowIndex].Cells["TimeSheetID"].Value.ToString());
                    double lessthenHours = Convert.ToDouble(grdTimeAndExp.Rows[e.RowIndex].Cells["Time"].Value.ToString());

                    if (checkvalue == "0")
                    {
                        btnSave_Click(sender, e);
                        //KryptonMessageBox.Show("please save fist then update", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        return;
                    }

                    if (lessthenHours > 24)
                    {
                        // KryptonMessageBox.Show("Less then 24 hours", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)

                        fillTimeSheet();
                        return;
                    }
                    //  For Each dr As DataGridViewRow In grdTimeAndExp.Rows
                    //If dr.Cells["TimeSheetID"].Value = "0" Then

                    // Else

                    string Date101 = null;
                    string Date102 = null;

                    Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                    string FinalDateUpdate = string.Empty;


                    if (grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value == null || grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString()))
                    {
                        // here is your message box...


                    }
                    else
                    {
                        //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        Date101 = string.Format("{0:dd/MM/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());

                    }


                    if (grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Tag == null || grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Tag.ToString()))
                    {
                        // here is your message box...

                        //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                        Date102 = string.Format("{0:dd/MM/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());

                        //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                        ActionDateUpdate = DateTime.Parse(grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());

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
                        Date102 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Tag.ToString();
                    }


                    

                    string Query = "UPDATE TS_Time SET JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@Empid, TrackSubid =@TrackSubid, Time =@Time, Description =@Description, status =@status, BillState =@BillState,Date=@Date,Comment=@Comment,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName, JobTrackingId=@JobTrackingId where TimeSheetID=@TimeSheetID";
                    List<SqlParameter> param = new List<SqlParameter>();

                    //MessageBox.Show("Query " + Query);

                    //DataAccessLayer DAL = new DataAccessLayer();
                    //Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()
                    ////SqlConnection con = new SqlConnection(DAL.ConnectionStringPCTracker);
                    //Dim queryString1 As String = "use " + con.Database + " SELECT  EmployeeDetailsId FROM  EmployeeDetails where UserName = '" & grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeSheetUser"].Value.ToString() & "' "
                    string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeSheetUser"].Value.ToString() + "' ";
                    ////DataTable dt1 = DAL.Filldatatable(queryString1);

                    //Int32 UpdateEmpId = StMethod.GetSingleInt(queryString1);

                    //MessageBox.Show("queryString1 " + queryString1);

                    //Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);

                    Int64 FetchEmpId;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        FetchEmpId = StMethod.GetSingleInt64New(queryString1);
                    }
                    else
                    {
                        FetchEmpId = StMethod.GetSingleInt64(queryString1);
                    }

                    //MessageBox.Show("FetchEmpId " + FetchEmpId);

                    Int64 UpdateEmpId = Convert.ToInt64(FetchEmpId);

                    //MessageBox.Show("UpdateEmpId " + UpdateEmpId);

                    //Int64 UpdateEmpId = Convert.ToInt64(StMethod.GetSingleInt(queryString1));

                    Int64 UpdateJobListId = Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobListID"].Value.ToString());

                    //MessageBox.Show("UpdateJobListId " + UpdateJobListId);

                    //Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);

                    //Int64 InsertEmpId = Convert.ToInt64(FetchEmpId);



                    param.Add(new SqlParameter("@JobListID", UpdateJobListId));

                   // MessageBox.Show("UpdateJobListId " + UpdateJobListId);

                    //param.Add(new SqlParameter("@JobListID", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobListID"].Value.ToString()));

                    param.Add(new SqlParameter("@Name", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeSheetUser"].Value.ToString()));


                    //MessageBox.Show("Name " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeSheetUser"].Value.ToString());

                    param.Add(new SqlParameter("@Empid", UpdateEmpId));

                    //MessageBox.Show("Empid " + UpdateEmpId);


                    param.Add(new SqlParameter("@TrackSubid", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TrackSubid"].Value.ToString()));

                    //MessageBox.Show("TrackSubid " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TrackSubid"].Value.ToString());



                    param.Add(new SqlParameter("@TrackSubName", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TrackSubName"].Value.ToString()));

                    //MessageBox.Show("TrackSubName " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TrackSubName"].Value.ToString());

                    param.Add(new SqlParameter("@Time", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["Time"].Value.ToString()));

                    //MessageBox.Show("Time " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["Time"].Value.ToString());


                    param.Add(new SqlParameter("@Description", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["Description"].Value.ToString()));


                    //MessageBox.Show("Description " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["Description"].Value.ToString());

                    param.Add(new SqlParameter("@status", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeItemNameSTATUS"].Value.ToString()));

                    //MessageBox.Show("status " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeItemNameSTATUS"].Value.ToString());

                    param.Add(new SqlParameter("@BillState", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeItemNameBILLSTATE"].Value.ToString()));

                    //MessageBox.Show("BillState " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeItemNameBILLSTATE"].Value.ToString());


                    //string Date1 = string.Empty;
                    //Date1 = grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["Date"].Value.ToString();

                    //DateTime datevalue = (Convert.ToDateTime(Date1.ToString()));
                    //string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");


                    //param.Add(new SqlParameter("@Date",s1.ToString()));


                    param.Add(new SqlParameter("@Date", Date102));

                    //MessageBox.Show("Date " + Date102);

                    //param.Add(new SqlParameter("@Date", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["Date"].Value.ToString()));


                    param.Add(new SqlParameter("@Comment", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["Comment"].Value.ToString()));

                    //MessageBox.Show("Comment " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["Comment"].Value.ToString());



                    //MessageBox.Show("JobTrackingId  1" + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobTrackingId"].Value.ToString());

                    //MessageBox.Show("JobTrackingId  2" + Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobTrackingId"].Value.ToString()));

                    //queryString = "SELECT TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as [Job_Number],TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID,TS_Time.status, TS_Time.Time, TS_Time.BillState,TS_Time.TrackSubName,TS_Time.Description,TS_Time.Comment, TS_Time.AdminStatus,JobTrackingId FROM TS_Time Where JobListID<>0 ";


                    param.Add(new SqlParameter("@JobTrackingId", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobTrackingId"].Value.ToString()));

                    //MessageBox.Show("JobTrackingId " + Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobTrackingId"].Value.ToString()));

                    //param.Add(new SqlParameter("@JobTrackingId", Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobTrackingId"].Value.ToString())));

                    //MessageBox.Show("JobTrackingId " + grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobTrackingId"].Value.ToString());

                    //param.Add(new SqlParameter("@JobTrackingId", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["JobTrackingId"].Value.ToString()));



                    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                    {
                        param.Add(new SqlParameter("@AdminStatus", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["AdminStatus"].Value.ToString()));

                      

                    }
                    else
                    {

                        param.Add(new SqlParameter("@AdminStatus", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["AdminStatus"].Value.ToString()));



                    }

                    param.Add(new SqlParameter("@TimeSheetID", grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeSheetID"].Value.ToString()));

                    //MessageBox.Show("TimeSheetID 1 " + Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.CurrentRow.Index].Cells["TimeSheetID"].Value.ToString()));


                    //if (StMethod.UpdateRecord(Query, param) > 0)
                    //{
                    //    grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                    //    MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    //Dim choiceButton As DialogResult = MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                    //    grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        if (StMethod.UpdateRecordNew(Query, param) > 0)
                        {
                            grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Dim choiceButton As DialogResult = MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        }


                    }
                    else
                    {
                        if (StMethod.UpdateRecord(Query, param) > 0)
                        {
                            grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Dim choiceButton As DialogResult = MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                            grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        }

                    }

                    if (grdTimeAndExp.RowCount > 2)
                    {
                        grdTimeAndExp.Rows[e.RowIndex].Selected = true;
                    }
                    //fillTimeSheet()
                    //fillExpences()
                    //  End If
                    //  Next
                    // MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    //fillTimeSheet()
                    //fillExpences()
                }
                if (e.ColumnIndex == 1 && e.RowIndex > -1)
                {
                    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                    {

                        //DataAccessLayer DAL = new DataAccessLayer();
                        if (KryptonMessageBox.Show("Are you sure to want delete", "Time", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //if (StMethod.UpdateRecord("DELETE FROM TS_Time WHERE TimeSheetID=" + grdTimeAndExp.Rows[e.RowIndex].Cells["TimeSheetID"].Value.ToString()) > 0)
                            //{
                            //    //KryptonMessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            //    DialogResult choiceButton = MessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    grdTimeAndExp.Rows.RemoveAt(e.RowIndex);
                            //    StMethod.LoginActivityInfo("Delete", this.Name);
                            //}


                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                if (StMethod.UpdateRecordNew("DELETE FROM TS_Time WHERE TimeSheetID=" + grdTimeAndExp.Rows[e.RowIndex].Cells["TimeSheetID"].Value.ToString()) > 0)
                                {
                                    //KryptonMessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    DialogResult choiceButton = MessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdTimeAndExp.Rows.RemoveAt(e.RowIndex);
                                    StMethod.LoginActivityInfoNew("Delete", this.Name);
                                }

                            }
                            else
                            {
                                if (StMethod.UpdateRecord("DELETE FROM TS_Time WHERE TimeSheetID=" + grdTimeAndExp.Rows[e.RowIndex].Cells["TimeSheetID"].Value.ToString()) > 0)
                                {
                                    //KryptonMessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                    DialogResult choiceButton = MessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdTimeAndExp.Rows.RemoveAt(e.RowIndex);
                                    StMethod.LoginActivityInfo("Delete", this.Name);
                                }
                            }

                        }
                        fillTimeSheet();
                        fillExpences();
                    }
                    else
                    {

                        string strvalue = grdTimeAndExp.Rows[e.RowIndex].Cells["AdminStatus"].Value.ToString();

                        if (strvalue == "Approved")
                        {
                            // grdTimeAndExp.Rows[Row].ReadOnly = True
                        }
                        else
                        {
                            
                            if (KryptonMessageBox.Show("Are you sure to want delete", "Time", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {


                                //if (StMethod.UpdateRecord("DELETE FROM TS_Time WHERE TimeSheetID=" + grdTimeAndExp.Rows[e.RowIndex].Cells["TimeSheetID"].Value.ToString()) > 0)
                                //{
                                //    // KryptonMessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                //    DialogResult choiceButton = MessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    grdTimeAndExp.Rows.RemoveAt(e.RowIndex);
                                //    StMethod.LoginActivityInfo("Delete", this.Name);
                                //}


                                if (Properties.Settings.Default.IsTestDatabase == true)
                                {
                                    if (StMethod.UpdateRecordNew("DELETE FROM TS_Time WHERE TimeSheetID=" + grdTimeAndExp.Rows[e.RowIndex].Cells["TimeSheetID"].Value.ToString()) > 0)
                                    {
                                        // KryptonMessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        DialogResult choiceButton = MessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        grdTimeAndExp.Rows.RemoveAt(e.RowIndex);
                                        StMethod.LoginActivityInfoNew("Delete", this.Name);
                                    }

                                }
                                else
                                {
                                    if (StMethod.UpdateRecord("DELETE FROM TS_Time WHERE TimeSheetID=" + grdTimeAndExp.Rows[e.RowIndex].Cells["TimeSheetID"].Value.ToString()) > 0)
                                    {
                                        // KryptonMessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        DialogResult choiceButton = MessageBox.Show("Delete Successfully", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        grdTimeAndExp.Rows.RemoveAt(e.RowIndex);
                                        StMethod.LoginActivityInfo("Delete", this.Name);
                                    }
                                }

                            }
                            fillTimeSheet();
                            fillExpences();
                        }
                    }
                }
            }
        }
        private void grdExpenses_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {


                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {

                    // grdExpenses.Rows[e.RowIndex].Cells["AdminStatus"].ReadOnly = False
                }
                else
                {
                    grdExpenses.Rows[e.RowIndex].Cells["ExpenseSheetItemNameBILLSTATE"].ReadOnly = true;
                    //grdExpenses.Rows[e.RowIndex].Cells["AdminStatus"].ReadOnly = True
                    grdExpenses.Rows[e.RowIndex].Cells["ExpenseSheetUser"].ReadOnly = true;

                    for (int Row = 0; Row < grdExpenses.Rows.Count; Row++)
                    {
                        string strvalue = (grdExpenses.Rows[Row].Cells["AdminStatus"].Value.ToString());

                        if (strvalue == "Approved")
                        {
                            grdExpenses.Rows[Row].ReadOnly = true;
                        }
                    }
                }


                //   End If
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    string checkvalue = (grdExpenses.Rows[e.RowIndex].Cells["TimeSheetExpencesID"].Value.ToString());


                    if (checkvalue == "0")
                    {
                        btnSave_Click(sender, e);
                        // KryptonMessageBox.Show("please save fist then update", "Time", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        return;
                    }
                    //  For Each dr As DataGridViewRow In grdExpenses.Rows
                    //If dr.Cells["TimeSheetExpencesID"].Value = "0" Then

                    // Else

                    string Date101 = null;
                    string Date102 = null;

                    Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                    string FinalDateUpdate = string.Empty;


                    if (grdExpenses.Rows[e.RowIndex].Cells["Date"].Value == null || grdExpenses.Rows[e.RowIndex].Cells["Date"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdExpenses.Rows[e.RowIndex].Cells["Date"].Value.ToString()))
                    {
                        // here is your message box...


                    }
                    else
                    {
                        //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        Date101 = string.Format("{0:dd/MM/yyyy}", grdExpenses.Rows[e.RowIndex].Cells["Date"].Value.ToString());

                    }


                    if (grdExpenses.Rows[e.RowIndex].Cells["Date"].Tag == null || grdExpenses.Rows[e.RowIndex].Cells["Date"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdExpenses.Rows[e.RowIndex].Cells["Date"].Tag.ToString()))
                    {
                        // here is your message box...

                        //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                        //Date102 = string.Format("{0:dd/MM/yyyy}", grdExpenses.Rows[e.RowIndex].Cells["Date"].Value.ToString());

                        //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                        ActionDateUpdate = DateTime.Parse(grdExpenses.Rows[e.RowIndex].Cells["Date"].Value.ToString());

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
                        Date102 = grdExpenses.Rows[e.RowIndex].Cells["Date"].Tag.ToString();
                    }


                    //string Query = "UPDATE    TS_Expences SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId= @EmployeeDetailId, TrackSubid =@TrackSubid, Expences =@Expences, Description =@Description, status =@status, BillState =@BillState,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetExpencesID=@TimeSheetExpencesID";

                    string Query = "UPDATE    TS_Expences SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId= @EmployeeDetailId, TrackSubid =@TrackSubid, Expences =@Expences, Description =@Description, status =@status, BillState =@BillState,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName,Date=@Date where TimeSheetExpencesID=@TimeSheetExpencesID";
                    
                    //MessageBox.Show("775");

                   // MessageBox.Show("Query" + Query);

                    List <SqlParameter> param = new List<SqlParameter>();
                    //Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()
                    ////DataAccessLayer DAL = new DataAccessLayer();
                    ////SqlConnection con = new SqlConnection(DAL.ConnectionStringPCTracker);
                    ////DataAccessLayer tempVar = new DataAccessLayer();


                    //Dim queryString1 As String = "use " + con.Database + " SELECT  EmployeeDetailsId FROM  EmployeeDetails where UserName = '" & grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["ExpenseSheetUser"].Value.ToString() & "' "
                    string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["ExpenseSheetUser"].Value.ToString() + "' ";
                    //DataTable dt1 = DAL.Filldatatable(queryString1);


                    //MessageBox.Show("queryString1" + queryString1);

                    //long UpdateEmpId = Convert.ToInt64(StMethod.GetSingleInt(queryString1));

                    //Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);
                    Int64 FetchEmpId;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        FetchEmpId = StMethod.GetSingleInt64New(queryString1);

                    }
                    else
                    {
                        FetchEmpId = StMethod.GetSingleInt64(queryString1);
                    }


                    //MessageBox.Show("FetchEmpId" + FetchEmpId);

                    Int64 UpdateEmpId = Convert.ToInt64(FetchEmpId);

                    //MessageBox.Show("UpdateEmpId" + UpdateEmpId);

                    Int64 UpdateJobListId = Convert.ToInt64(grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["JobListID"].Value.ToString());
                    
                   // MessageBox.Show("UpdateJobListId" + UpdateJobListId);


                    param.Add(new SqlParameter("@JobListID", UpdateJobListId));
                                        


                    ////////if (dt1.Rows.Count == 1)
                    ////////{
                    ////////    UpdateEmpId = (Int16)Convert.ToInt32(dt1.Rows[0][0].ToString());
                    ////////}


                    param.Add(new SqlParameter("@Name", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["ExpenseSheetUser"].Value.ToString()));
                    param.Add(new SqlParameter("@EmployeeDetailId", UpdateEmpId));



                    //MessageBox.Show("TrackSubid ",grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["TrackSubid"].Value.ToString());
                    //MessageBox.Show("TrackSubName ", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["TrackSubName"].Value.ToString());
                    //MessageBox.Show("ExpenseSheetUser ", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["ExpenseSheetUser"].Value.ToString());
                    //MessageBox.Show("Expences ", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["Expences"].Value.ToString());
                    //MessageBox.Show("Description ", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["Description"].Value.ToString());


                    //param.Add(new SqlParameter("@Expences", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["Expences"].Value.ToString()));
                    //param.Add(new SqlParameter("@Description", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["Description"].Value.ToString()));



                    param.Add(new SqlParameter("@TrackSubid", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["TrackSubid"].Value.ToString()));
                    param.Add(new SqlParameter("@TrackSubName", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["TrackSubName"].Value.ToString()));




                    param.Add(new SqlParameter("@Expences", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["Expences"].Value.ToString()));
                    param.Add(new SqlParameter("@Description", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["Description"].Value.ToString()));
                    param.Add(new SqlParameter("@status", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["ExpenseSheetItemNameSTATUS"].Value.ToString()));
                    param.Add(new SqlParameter("@BillState", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["ExpenseSheetItemNameBILLSTATE"].Value.ToString()));

                    param.Add(new SqlParameter("@Date", Date102));

                    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                    {
                        param.Add(new SqlParameter("@AdminStatus", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["AdminStatus"].Value.ToString()));
                    }
                    else
                    {

                        param.Add(new SqlParameter("@AdminStatus", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["AdminStatus"].Value.ToString()));
                    }

                    param.Add(new SqlParameter("@TimeSheetExpencesID", grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["TimeSheetExpencesID"].Value.ToString()));

                    //if (StMethod.UpdateRecord(Query, param) > 0)
                    //{
                    //    MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //    if (grdExpenses.RowCount > 1)
                    //    {
                    //        grdExpenses.Rows[e.RowIndex].Selected = true;
                    //    }
                    //    //  fillTimeSheet()
                    //    //  fillExpences()


                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.UpdateRecordNew(Query, param) > 0)
                        {
                            MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (grdExpenses.RowCount > 1)
                            {
                                grdExpenses.Rows[e.RowIndex].Selected = true;
                            }
                            //  fillTimeSheet()
                            //  fillExpences()


                        }
                    }
                    else
                    {
                        if (StMethod.UpdateRecord(Query, param) > 0)
                        {
                            MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (grdExpenses.RowCount > 1)
                            {
                                grdExpenses.Rows[e.RowIndex].Selected = true;
                            }
                            //  fillTimeSheet()
                            //  fillExpences()


                        }
                    }


                    //    End If
                    //  Next

                    //MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    //fillTimeSheet()
                    //fillExpences()
                }
                if (e.ColumnIndex == 1 && e.RowIndex > -1)
                {
                    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                    {

                        if (KryptonMessageBox.Show("Are you sure to want delete", "Expenses", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        {
                            //if (StMethod.UpdateRecord("DELETE FROM TS_Expences WHERE TimeSheetExpencesID=" + grdExpenses.Rows[e.RowIndex].Cells["TimeSheetExpencesID"].Value.ToString()) > 0)
                            //{
                            //    KryptonMessageBox.Show("Delete Successfully", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    grdExpenses.Rows.RemoveAt(e.RowIndex);
                            //    // DAL.LoginActivityInfo("Delete", Me.Name)
                            //}


                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                if (StMethod.UpdateRecordNew("DELETE FROM TS_Expences WHERE TimeSheetExpencesID=" + grdExpenses.Rows[e.RowIndex].Cells["TimeSheetExpencesID"].Value.ToString()) > 0)
                                {
                                    KryptonMessageBox.Show("Delete Successfully", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdExpenses.Rows.RemoveAt(e.RowIndex);
                                    // DAL.LoginActivityInfo("Delete", Me.Name)
                                }

                            }
                            else
                            {
                                if (StMethod.UpdateRecord("DELETE FROM TS_Expences WHERE TimeSheetExpencesID=" + grdExpenses.Rows[e.RowIndex].Cells["TimeSheetExpencesID"].Value.ToString()) > 0)
                                {
                                    KryptonMessageBox.Show("Delete Successfully", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdExpenses.Rows.RemoveAt(e.RowIndex);
                                    // DAL.LoginActivityInfo("Delete", Me.Name)
                                }
                            }


                        }
                        fillTimeSheet();
                        fillExpences();
                    }
                    else
                    {
                        string strvalue = grdExpenses.Rows[e.RowIndex].Cells["AdminStatus"].Value.ToString();

                        if (strvalue == "Approved")
                        {
                            // grdExpenses.Rows[Row].ReadOnly = True
                        }
                        else
                        {                            
                            if (KryptonMessageBox.Show("Are you sure to want delete", "Expenses", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                //if (StMethod.UpdateRecord("DELETE FROM TS_Expences WHERE TimeSheetExpencesID=" + grdExpenses.Rows[e.RowIndex].Cells["TimeSheetExpencesID"].Value.ToString()) > 0)
                                //{
                                //    KryptonMessageBox.Show("Delete Successfully", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //    grdExpenses.Rows.RemoveAt(e.RowIndex);
                                //    // DAL.LoginActivityInfo("Delete", Me.Name)
                                //}

                                if (Properties.Settings.Default.IsTestDatabase == true)
                                {
                                    if (StMethod.UpdateRecordNew("DELETE FROM TS_Expences WHERE TimeSheetExpencesID=" + grdExpenses.Rows[e.RowIndex].Cells["TimeSheetExpencesID"].Value.ToString()) > 0)
                                    {
                                        KryptonMessageBox.Show("Delete Successfully", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        grdExpenses.Rows.RemoveAt(e.RowIndex);
                                        // DAL.LoginActivityInfo("Delete", Me.Name)
                                    }

                                }
                                else
                                {
                                    if (StMethod.UpdateRecord("DELETE FROM TS_Expences WHERE TimeSheetExpencesID=" + grdExpenses.Rows[e.RowIndex].Cells["TimeSheetExpencesID"].Value.ToString()) > 0)
                                    {
                                        KryptonMessageBox.Show("Delete Successfully", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        grdExpenses.Rows.RemoveAt(e.RowIndex);
                                        // DAL.LoginActivityInfo("Delete", Me.Name)
                                    }
                                }

                            }
                            fillTimeSheet();
                            fillExpences();
                        }

                    }
                }
            }

            //string checkTrackSubName = grdExpenses.Rows[e.RowIndex].Cells["TrackSubName"].Value.ToString();
            //MessageBox.Show("TrackSubName on cell click", checkTrackSubName);


        }
        private void btnLogOut_Click(System.Object sender, System.EventArgs e)
        {
            Properties.Settings.Default.timeSheetLoginUserType = "";
            Program.ofrmMain.CloseActiveForm(this.Text);
            this.Close();
        }
        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            fillTimeSheet();
            fillExpences();
        }
        private void cbxJobListPM_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            fillGridJobList();
        }
        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            txtJobListAddress.Text = "";
            txtJobListclient.Text = "";
            txtJobListJobID.Text = "";
            // cbxJobListDescription.Text = ""
            txtDescriptionSearchJob.Text = "";
            cbxJobListPM.Text = "";
            txtTown.Text = "";
            fillGridJobList();
        }
        private void btnChangeMASS_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                // If KryptonMessageBox.Show("Are you sure to want Change Status", "Mass Status", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then

                //End If
                if (string.IsNullOrEmpty(cmbMassStatusChange.Text) && string.IsNullOrEmpty(cmbAdminMass.Text))
                {

                    DialogResult choiceButton = MessageBox.Show("Select  Status is Null", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {

                    if (tbTimeAndExp.SelectedTab.Text == "Time")
                    {

                        for (int Row = 0; Row < grdTimeAndExp.Rows.Count; Row++)
                        {
                            int TimeSheetid =Convert.ToInt32( grdTimeAndExp.Rows[Row].Cells["TimeSheetID"].Value);
                            // Dim Query As String = "UPDATE TS_Time SET status =@status,AdminStatus =@AdminStatus where TimeSheetID=@TimeSheetID "
                            string Query = "UPDATE TS_Time SET ";
                            if (!string.IsNullOrEmpty(cmbMassStatusChange.Text.Trim()))
                            {
                                Query = Query + " status =@status,";
                            }
                            if (!string.IsNullOrEmpty(cmbAdminMass.Text.Trim()))
                            {
                                Query = Query + " AdminStatus =@AdminStatus";
                            }

                            if (Query.LastIndexOf(",") == Query.Length - 1)
                            {
                                Query = Query.Remove(Query.LastIndexOf(","));
                            }
                            Query = Query + " where TimeSheetID=@TimeSheetID ";
                            List<SqlParameter> param = new List<SqlParameter>();
                            
                            if (cmbMassStatusChange.Text == "Empty")
                            {
                                param.Add(new SqlParameter("@status", ""));
                            }
                            else
                            {
                                param.Add(new SqlParameter("@status", cmbMassStatusChange.Text.ToString()));
                            }
                            //If cmbAdminMass.Text = "Empty" Then
                            //    param.Add(.SqlParameter("@AdminStatus", ""))
                            //Else
                            //    param.Add(.SqlParameter("@AdminStatus", cmbAdminMass.Text.ToString()))
                            //End If

                            param.Add(new SqlParameter("@AdminStatus", cmbAdminMass.Text.ToString()));
                            param.Add(new SqlParameter("@TimeSheetID", TimeSheetid));

                            //if (StMethod.UpdateRecord(Query, param) > 0)
                            //{
                            //    // MessageBox.Show("Change Status Time Sheet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            //}

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {

                                if (StMethod.UpdateRecordNew(Query, param) > 0)
                                {
                                    // MessageBox.Show("Change Status Time Sheet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                }
                            }
                            else
                            {
                                if (StMethod.UpdateRecord(Query, param) > 0)
                                {
                                    // MessageBox.Show("Change Status Time Sheet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                }
                            }


                        }
                        DialogResult choiceButton = MessageBox.Show("Change Status Time Sheet Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillTimeSheet();
                        cmbAdminMass.Text = "";
                        cmbMassStatusChange.Text = "";
                    }
                    else
                    {
                        for (int Row = 0; Row < grdExpenses.Rows.Count; Row++)
                        {
                            int TimeSheetid = Convert.ToInt32( grdExpenses.Rows[Row].Cells["TimeSheetExpencesID"].Value);

                            //MessageBox.Show("1005");

                            string Query = "UPDATE TS_Expences  SET ";
                            if (!string.IsNullOrEmpty(cmbMassStatusChange.Text.Trim()))
                            {
                                Query = Query + " status =@status,";
                            }
                            if (!string.IsNullOrEmpty(cmbAdminMass.Text.Trim()))
                            {
                                Query = Query + " AdminStatus =@AdminStatus";
                            }
                            if (Query.LastIndexOf(",") == Query.Length - 1)
                            {
                                Query = Query.Remove(Query.LastIndexOf(","));
                            }
                            Query = Query + " where TimeSheetExpencesID=@TimeSheetExpencesID ";
                            List<SqlParameter> param = new List<SqlParameter>();
                            //param.Add(.SqlParameter("@status", cmbMassStatusChange.Text.ToString()))
                            //param.Add(.SqlParameter("@AdminStatus", cmbAdminMass.Text.ToString()))
                            if (cmbMassStatusChange.Text == "Empty")
                            {
                                param.Add(new SqlParameter("@status", ""));
                            }
                            else
                            {
                                param.Add(new SqlParameter("@status", cmbMassStatusChange.Text.ToString()));
                            }

                            param.Add(new SqlParameter("@AdminStatus", cmbAdminMass.Text.ToString()));
                            param.Add(new SqlParameter("@TimeSheetExpencesID", TimeSheetid));

                            //if (StMethod.UpdateRecord(Query, param) > 0)
                            //{
                                //  MessageBox.Show("Change Status Expenses Seet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            //}

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {

                                if (StMethod.UpdateRecordNew(Query, param) > 0)
                                {
                                    //  MessageBox.Show("Change Status Expenses Seet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                }
                            }
                            else
                            {
                                if (StMethod.UpdateRecord(Query, param) > 0)
                                {
                                    //  MessageBox.Show("Change Status Expenses Seet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                }
                            }


                        }
                        // MessageBox.Show("Change Status Expenses Sheet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        DialogResult choiceButton = MessageBox.Show("Change Status Expenses Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillExpences();
                        cmbAdminMass.Text = "";
                        cmbMassStatusChange.Text = "";
                    }
                    //  End If
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void txtJobNumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            fillTimeSheet();

            fillExpences();
        }
        private void txtTrackSubComment_TextChanged(System.Object sender, System.EventArgs e)
        {
            fillTimeSheet();
            fillExpences();
        }
        private void btnSearchUserClear_Click(System.Object sender, System.EventArgs e)
        {
            cmbStatus.SelectedIndexChanged -= this.cmbStatus_SelectedIndexChanged;

            txtJobNumber.Text = "";
            cmbUserSearch.Text = "";
            cmbStatus.Text = "";
            cmbBillStatus.Text = "";
            cmbAdminStatus.Text = "";
            //txtTrackSubComment.Text = ""
            ckbTime.Checked = false;
            gbDateUserSearch.Enabled = false;
            fillTimeSheet();
            fillExpences();
            cmbStatus.SelectedIndexChanged += this.cmbStatus_SelectedIndexChanged;

        }
        private void grdTimeAndExp_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex != 0 && e.ColumnIndex != 1)
            {
               // CheckString = grdTimeAndExp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            if (e.ColumnIndex == 12 && e.RowIndex > -1)
            {

                try
                { 
                
                int joblistID =Convert.ToInt32( grdTimeAndExp.Rows[e.RowIndex].Cells["JobListID"].Value);

                string query = "Select JobTrackingID, ISNULL(TrackSubId,0) as TrackSubId,(Select TracksubName from MasterTrackSubItem where Id = TrackSubId)+ ' ' + ISNULL(Comments,'') as TrackSubDescription from JobTracking where (IsDelete=0 Or IsDelete Is null) and JobListID=" + joblistID + " UNION SELECT 0 AS JobTrackingID, 0 as TrackSubId, '' as TrackSubDescription order by TrackSubId";


                    //string query = "Select JobTrackingID, TrackSubId,(Select TracksubName from MasterTrackSubItem where Id = TrackSubId)+ ' ' + ISNULL(Comments,'') as TrackSubDescription from JobTracking where (IsDelete=0 Or IsDelete Is null) and JobListID=" + joblistID + " UNION SELECT 0 AS JobTrackingID, 0 as TrackSubId, '' as TrackSubDescription order by TrackSubId";


                    DataTable Dt = new DataTable();

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        Dt = StMethod.GetListDTNew<JobTrackingData>(query); ;
                    }
                    else
                    {
                        Dt = StMethod.GetListDT<JobTrackingData>(query);
                    }
                  

                string count = Dt.Rows.Count.ToString ();

                DataGridViewComboBoxCell CellCmb = new DataGridViewComboBoxCell();

                //CellCmb.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;
                //CellCmb.FlatStyle = FlatStyle.Standard;

                //CellCmb.DisplayMember = "TrackSubDescription";
                //CellCmb.ValueMember = "JobTrackingID";

                CellCmb.DisplayMember = "TrackSubDescription";
                CellCmb.ValueMember = "JobTrackingID";
                
                CellCmb.DataSource = Dt;

                //grdTimeAndExp.Rows[12].Cells[e.RowIndex] = CellCmb;
                grdTimeAndExp.Rows[e.RowIndex].Cells[e.ColumnIndex] = CellCmb;


                    //DataGridViewComboBoxColumn CellCmb2 = new DataGridViewComboBoxColumn();
                    //CellCmb2.DisplayMember = "TrackSubDescription";
                    //CellCmb2.ValueMember = "JobTrackingID";
                    //CellCmb2.DataSource = Dt;
                    //CellCmb2.HeaderText = "blalalalalal";
                    //CellCmb2.Visible = false;

                    //grdTimeAndExp.Columns.Insert(5, CellCmb2);
                    //grdExpenses.Columns[5].DisplayIndex = 6;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
            if (e.ColumnIndex == 15 && e.RowIndex > -1)
            {
                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    try
                    {
                        string query = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'   union SELECT 1 as TS_MasterItemId,'None' as value order by TS_MasterItemId";
                        //Dim query As String = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'   union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId"                        
                        DataTable Dt = new DataTable();


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            Dt = StMethod.GetListDTNew<MasterData>(query);
                        }
                        else
                        {
                            Dt = StMethod.GetListDT<MasterData>(query);
                        }
                        
                        //Dt = StMethod.GetListDT<MasterData>(query);

                        DataGridViewComboBoxCell celAdmin = new DataGridViewComboBoxCell();
                        celAdmin.DataSource = Dt;
                        celAdmin.DisplayMember = "Value";
                        grdTimeAndExp.Rows[15].Cells[e.RowIndex] = celAdmin;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }


        private void grdTimeAndExp_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            try
            {

            


                if (grdTimeAndExp.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                {
                    if (grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Yellow)
                    {
                    }
                    else
                    {
                        grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                    }
                    // grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink
                    //grdTimeAndExp.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink
                    CheckString = string.Empty;
                }


                String value2 = grdTimeAndExp.Rows[e.RowIndex].Cells[6].Value.ToString() as string;

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
                            grdTimeAndExp.Rows[e.RowIndex].Cells[6].Value = value2;
                            grdTimeAndExp.Rows[e.RowIndex].Cells[6].Tag = inputString;
                        }
                        else
                        {
                            grdTimeAndExp.Rows[e.RowIndex].Cells[6].Tag = inputString;


                        }
                    }
                    else
                    {
                        //e.Value = e.CellStyle.NullValue;
                        //e.FormattingApplied = true;
                    }

                }

                    // If e.ColumnIndex = 12 And e.RowIndex > -1 Then
                    //Dim joblistID As Integer = grdTimeAndExp.Rows(e.RowIndex).Cells("JobListID").Value
                    // ''Get TracKSub Id and JobTrackingId
                    // Dim cmbCell As DataGridViewComboBoxCell = CType(grdTimeAndExp.Rows(e.RowIndex).Cells("TrackSubName"), DataGridViewCell)
                    // For Each dr As DataRowView In cmbCell.Items
                    //     If(dr("JobTrackingID").ToString() = cmbCell.Value.ToString()) Then
                    //         grdTimeAndExp.Rows(e.RowIndex).Cells("JobTrackingId").Value = cmbCell.Value
                    //         grdTimeAndExp.Rows(e.RowIndex).Cells("TrackSubName").Value = dr("TrackSubDescription")
                    //         grdTimeAndExp.Rows(e.RowIndex).Cells("TrackSubID").Value = dr("TrackSubId")
                    //         Exit For
                    //     End If
                    // Next

                    if (e.ColumnIndex == 12 && e.RowIndex > -1)
                    {
                    int joblistID =Convert.ToInt32(grdTimeAndExp.Rows[e.RowIndex].Cells["JobListID"].Value);
                    //'Get TracKSub Id and JobTrackingId
                    DataGridViewComboBoxCell cmbCell = (DataGridViewComboBoxCell)(grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubName"]);
                    foreach (DataRowView dr in cmbCell.Items)
                    {
                        //if (dr["JobTrackingID"].ToString() == cmbCell.Value.ToString())
                        //{
                        //    grdTimeAndExp.Rows[e.RowIndex].Cells["JobTrackingId"].Value = cmbCell.Value;
                        //    grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubName"].Value = dr["TrackSubDescription"];
                        //    grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubID"].Value = dr["TrackSubId"];
                        //    break;
                        //}

                        if (dr["JobTrackingID"].ToString() == cmbCell.Value.ToString())
                        {

                            //DataGridViewComboBoxCell CellCmb = new DataGridViewComboBoxCell();
                            //CellCmb.DisplayMember = "TrackSubDescription";
                            //CellCmb.ValueMember = "JobTrackingID";
                            //CellCmb.DataSource = Dt;
                            //grdTimeAndExp.Rows[e.RowIndex].Cells[e.ColumnIndex] = CellCmb;

                            DataGridViewTextBoxCell TrackSubName = new DataGridViewTextBoxCell();
                            grdTimeAndExp.Rows[e.RowIndex].Cells[e.ColumnIndex] = TrackSubName;
                            
                            grdTimeAndExp.Rows[e.RowIndex].Cells["JobTrackingId"].Value = cmbCell.Value;
                            grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubName"].Value = dr["TrackSubDescription"];
                            grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubID"].Value = dr["TrackSubId"];
                            break;
                        }

                    }
                    //'Comment on 1 June, 2016
                    //'Below comment code no longer needed, as I updated above code perform this operation
                    //Dim query As String = "select TrackSubId,(Select TracksubName from MasterTrackSubItem where Id = TrackSubId)+ ' ' + ISNULL(Comments,'') as TrackSubDescription from JobTracking where (IsDelete=0 Or IsDelete Is null) and JobListID=" & joblistID & " AND (Select TracksubName from MasterTrackSubItem where Id = JobTracking.TrackSubId)+ ' ' + ISNULL(JobTracking.Comments,'') like '%" & grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubName"].Value.ToString() & "'  "
                    //Dim DALCellEnding As New DataAccessLayer
                    //grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubID"].Value = DALCellEnding.ExceuteScaler(query)
                    //'End code comment.


                    DateTime selectDateFrom = Convert.ToDateTime( grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value);
                    DateTime selectDateTo = selectDateFrom.AddDays(-3);
                    int TrackSubID = Convert.ToInt32( grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubID"].Value);
                    
                    string querySelectJobTrack = "select count(InvoiceRptID) from JobTrackInvoiceRateDetail where  jobtrackdetailid  in (select JobTrackDetailID from JobTrackInvoiceDetail where JobListID=" + joblistID + " and InvoiceDate between '" + selectDateTo + "' and '" + selectDateFrom + "') and  TrackSubId= " + TrackSubID + "";

                    //int DtSelectJobTrack = StMethod.GetSingleInt(querySelectJobTrack);
                    int DtSelectJobTrack;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        DtSelectJobTrack = StMethod.GetSingleIntNew(querySelectJobTrack);
                    }
                    else
                    {
                        DtSelectJobTrack = StMethod.GetSingleInt(querySelectJobTrack);
                    }

                    if (DtSelectJobTrack > 0)
                    {
                        // MessageBox.Show(" Sub Track Comment invalid It it's invoiced more than three days ago.", "Time")
                        DialogResult choiceButton = KryptonMessageBox.Show("Sub Track Comment invalid. It invoiced more than three days ago.", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        grdTimeAndExp.Rows[e.RowIndex].Cells["TracksubName"].Value = "";
                        grdTimeAndExp.Rows[e.RowIndex].Cells["JobTrackingId"].Value = "";
                    }



                }



            }
            catch (Exception ex)
            {

            }
        }
        private void grdExpenses_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
         

            if (e.ColumnIndex == 11 && e.RowIndex > -1)
            {              
                
                try
                { 
                int joblistID =Convert.ToInt32( grdExpenses.Rows[e.RowIndex].Cells["JobListID"].Value);
                string query = "Select JobTrackingID,TrackSubId,(Select TracksubName from MasterTrackSubItem where Id = TrackSubId)+ ' ' + ISNULL(Comments,'') as TrackSubDescription from JobTracking where (IsDelete=0 Or IsDelete Is null) and JobListID=" + joblistID + " UNION SELECT 0 as TrackSubId,  0 as TrackSubId,'' as TrackSubDescription order by TrackSubId";

                    //string query = "Select TrackSubId,(Select TracksubName from MasterTrackSubItem where Id = TrackSubId)+ ' ' + ISNULL(Comments,'') as TrackSubDescription from JobTracking where (IsDelete=0 Or IsDelete Is null) and JobListID=" + joblistID + " UNION SELECT 0 as TrackSubId, '' as TrackSubDescription order by TrackSubId";

                    //select JobTrackingID, TrackSubId,(Select TracksubName from MasterTrackSubItem where Id = TrackSubId)+' ' + ISNULL(Comments, '') as TrackSubDescription from JobTracking where (IsDelete = 0 Or IsDelete Is null) and JobListID = " & joblistID & " UNION SELECT 0 AS JobTrackingID, 0 as TrackSubId, '' as TrackSubDescription order by TrackSubId"


                DataTable Dt = new DataTable();

                    //Dt = StMethod.GetListDT<JT_Desc>(query);



                    //Dt = StMethod.GetListDT<JobTrackingData>(query);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        Dt = StMethod.GetListDTNew<JobTrackingData>(query);

                    }
                    else
                    {
                        Dt = StMethod.GetListDT<JobTrackingData>(query);
                    }


                    DataGridViewComboBoxCell CellCmb = new DataGridViewComboBoxCell();
                   
                    CellCmb.DisplayMember = "TrackSubDescription";
                    CellCmb.ValueMember = "JobTrackingID";
                    CellCmb.DataSource = Dt;

                    grdExpenses.Rows[e.RowIndex].Cells[e.ColumnIndex] = CellCmb;






                    //DataTable Dt = new DataTable();
                    //Dt = StMethod.GetListDT<JobTrackingData>(query);
                    

                    //DataGridViewComboBoxCell CellCmb = new DataGridViewComboBoxCell();

                    //CellCmb.DisplayMember = "TrackSubDescription";
                    //CellCmb.ValueMember = "JobTrackingID";

                    //CellCmb.DataSource = Dt;

                    ////grdTimeAndExp.Rows[12].Cells[e.RowIndex] = CellCmb;
                    //grdTimeAndExp.Rows[e.RowIndex].Cells[e.ColumnIndex] = CellCmb;




                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
            if (e.ColumnIndex == 15 && e.RowIndex > -1)
            {
                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {

                    try
                    {
                        //Dim query As String = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'   union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId"
                        string query = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'   union SELECT 1 as TS_MasterItemId,'None' as value order by TS_MasterItemId";

                        DataTable Dt = new DataTable();
                        
                        //Dt = StMethod.GetListDT<MasterData>(query);


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            Dt = StMethod.GetListDTNew<MasterData>(query);
                        }
                        else
                        {
                            Dt = StMethod.GetListDT<MasterData>(query);
                        }


                        DataGridViewComboBoxCell celAdmin = new DataGridViewComboBoxCell();
                        celAdmin.DataSource = Dt;
                        celAdmin.DisplayMember = "Value";
                        grdExpenses.Rows[15].Cells[e.RowIndex] = celAdmin;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }
        private void grdExpenses_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {





            string CheckString = "check";
            if (grdExpenses.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
            {
                if (grdExpenses.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Yellow)
                {

                }
                else
                {
                    grdExpenses.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    grdExpenses.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                }
                CheckString = string.Empty;
            }





            String value2 = grdExpenses.Rows[e.RowIndex].Cells[6].Value.ToString() as string;

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
                        grdExpenses.Rows[e.RowIndex].Cells[6].Value = value2;
                        grdExpenses.Rows[e.RowIndex].Cells[6].Tag = inputString;
                    }
                    else
                    {
                        grdExpenses.Rows[e.RowIndex].Cells[6].Tag = inputString;


                    }
                }
                else
                {
                    //e.Value = e.CellStyle.NullValue;
                    //e.FormattingApplied = true;
                }

            }







            if (e.ColumnIndex == 11 && e.RowIndex > -1)
            {
                
                int joblistID = Convert.ToInt32(grdExpenses.Rows[e.RowIndex].Cells["JobListID"].Value);


                //Dim queryCellEndEdit As String = "SELECT  id FROM MasterTrackSubItem WHERE (IsDelete=0 Or IsDelete Is null) AND id in(select TrackSubID FROM JobTracking WHERE JoblistID=" & joblistIDCellEndEdit & ") AND TrackSubName='" & grdExpenses.Rows[e.RowIndex].Cells["TrackSubName"].Value & "'"
                //Dim DALCellEndEdit As New DataAccessLayer
                //grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value = DALCellEndEdit.ExceuteScaler(queryCellEndEdit)

                //string query = "select TrackSubId,(Select TracksubName from MasterTrackSubItem where Id = TrackSubId)+ ' ' + ISNULL(Comments,'') as TrackSubDescription from JobTracking where (IsDelete=0 Or IsDelete Is null) and JobListID=" + joblistID + " AND (Select TracksubName from MasterTrackSubItem where Id = JobTracking.TrackSubId)+ ' ' + ISNULL(JobTracking.Comments,'') like '%" + grdExpenses.Rows[e.RowIndex].Cells["TrackSubName"].Value.ToString() + "'  ";
                //grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value = DALCellEnding.ExceuteScaler(query);

                //MessageBox.Show("enter");




                //foreach (DataRowView dr in cmbCell.Items)
                //{

                //    if (dr["JobTrackingID"].ToString() == cmbCell.Value.ToString())
                //    {

                //        DataGridViewTextBoxCell TrackSubName = new DataGridViewTextBoxCell();

                //        grdTimeAndExp.Rows[e.RowIndex].Cells[11] = TrackSubName;
                //           grdTimeAndExp.Rows[e.RowIndex].Cells["JobTrackingId"].Value = cmbCell.Value;
                //        //grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubName"].Value = dr["TrackSubDescription"];
                //        grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubID"].Value = dr["TrackSubId"];
                //        break;
                //    }
                //}

                DataGridViewComboBoxCell cmbCell = (DataGridViewComboBoxCell)(grdExpenses.Rows[e.RowIndex].Cells["TrackSubName"]);

                foreach (DataRowView dr in cmbCell.Items)
                {

                        if (dr["JobTrackingID"].ToString() == cmbCell.Value.ToString())
                        {
                            DataGridViewTextBoxCell TrackSubName = new DataGridViewTextBoxCell();
                            grdExpenses.Rows[e.RowIndex].Cells[e.ColumnIndex] = TrackSubName;


                        //e.ColumnIndex
                        //e.RowIndex

                        //MessageBox.Show(" Columnd Index is ", grdTimeAndExp.Rows[e.RowIndex].Cells[e.ColumnIndex].ToString());

                        // blank
                        //MessageBox.Show(grdTimeAndExp.Rows[e.RowIndex].Cells["JobTrackingId"].Value.ToString());

                        // 81424 integer
                        //MessageBox.Show(cmbCell.Value.ToString());

                        // old tracksubname value   
                        //MessageBox.Show(grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubName"].Value.ToString());

                        // new tracksunmae value
                        //MessageBox.Show(dr["TrackSubDescription"].ToString());

                        // 37 old id
                        //MessageBox.Show(grdTimeAndExp.Rows[e.RowIndex].Cells["TrackSubID"].Value.ToString());

                        // 55 new id
                        //MessageBox.Show(dr["TrackSubId"].ToString());


                        //grdExpenses.Rows[e.RowIndex].Cells["JobTrackingId"].Value = cmbCell.Value;
                        grdExpenses.Rows[e.RowIndex].Cells["TrackSubName"].Value = dr["TrackSubDescription"];
                        grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value = dr["TrackSubId"];


                            break;
                        }
                    }


                //MessageBox.Show("Middle");



                //MessageBox.Show("TrackSubID fetch " + grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value.ToString());

                string query = "select TrackSubId from JobTracking where (IsDelete=0 Or IsDelete Is null) and JobListID=" + joblistID + " AND (Select TracksubName from MasterTrackSubItem where Id = JobTracking.TrackSubId)+ ' ' + ISNULL(JobTracking.Comments,'') like '%" + grdExpenses.Rows[e.RowIndex].Cells["TrackSubName"].Value.ToString() + "'  ";

                
                
                //grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value = StMethod.GetSingleInt(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value = StMethod.GetSingleIntNew(query);
                }
                else
                {
                    grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value = StMethod.GetSingleInt(query);
                }


                //MessageBox.Show("Query is =>" + query.ToString());

                //MessageBox.Show("TrackSubID fetch " + grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value.ToString());
                //MessageBox.Show("TracksubName field " + grdExpenses.Rows[e.RowIndex].Cells["TracksubName"].Value.ToString());

                //MessageBox.Show("TracksubName columnd " + grdExpenses.Rows[e.RowIndex].Cells[11].Value.ToString());


                //MessageBox.Show("end");

                //MessageBox.Show("9 Column " + grdExpenses.Rows[e.RowIndex].Cells[9].Value.ToString());
                //MessageBox.Show("10 Column " + grdExpenses.Rows[e.RowIndex].Cells[10].Value.ToString());
                //MessageBox.Show("11 Column " + grdExpenses.Rows[e.RowIndex].Cells[11].Value.ToString());




                DateTime selectDateFrom = Convert.ToDateTime(grdExpenses.Rows[e.RowIndex].Cells["Date"].Value);
                DateTime selectDateTo = selectDateFrom.AddDays(-3);
                int TrackSubID = Convert.ToInt32(grdExpenses.Rows[e.RowIndex].Cells["TrackSubID"].Value);


              

                string FindalSelectDateFrom = string.Empty;
                FindalSelectDateFrom = selectDateFrom.ToString();

                DateTime datevalue = (Convert.ToDateTime(FindalSelectDateFrom.ToString()));
                string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                string FindalSelectDateTo = string.Empty;
                FindalSelectDateTo = selectDateTo.ToString();

                DateTime datevalue2 = (Convert.ToDateTime(FindalSelectDateTo.ToString()));
                string s2 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");



                //string querySelectJobTrack = "select count(InvoiceRptID) from JobTrackInvoiceRateDetail where  jobtrackdetailid  in (select JobTrackDetailID from JobTrackInvoiceDetail where JobListID=" + joblistID + " and InvoiceDate between '" + selectDateTo + "' and '" + selectDateFrom + "') and  TrackSubId= " + TrackSubID + "";

                string querySelectJobTrack = "select count(InvoiceRptID) from JobTrackInvoiceRateDetail where  jobtrackdetailid  in (select JobTrackDetailID from JobTrackInvoiceDetail where JobListID=" + joblistID + " and InvoiceDate between '" + s1 + "' and '" + s2 + "') and  TrackSubId= " + TrackSubID + "";


                //int DtSelectJobTrack = StMethod.GetSingleInt(querySelectJobTrack);
                int DtSelectJobTrack;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    DtSelectJobTrack = StMethod.GetSingleIntNew(querySelectJobTrack);
                }
                else
                {
                    DtSelectJobTrack = StMethod.GetSingleInt(querySelectJobTrack);
                }

                if (DtSelectJobTrack > 0)
                {
                    // MessageBox.Show(" Sub Track Comment invalid It it's invoiced more than three days ago.", "Expenses")
                    DialogResult choiceButton = KryptonMessageBox.Show(" Sub Track Comment invalid It it's invoiced more than three days ago.", "Expenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    grdExpenses.Rows[e.RowIndex].Cells["TracksubName"].Value = "";
                }




                //MessageBox.Show(grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["TrackSubid"].Value.ToString());
                //MessageBox.Show(grdExpenses.Rows[grdExpenses.CurrentRow.Index].Cells["TrackSubName"].Value.ToString());

            }


        }
        private void ckbTime_Click(System.Object sender, System.EventArgs e)
        {

            if (ckbTime.Checked == true)
            {
                // btnPunchHousvsJT.Enabled = True
                gbDateUserSearch.Enabled = true;
                fillExpences();
                fillTimeSheet();
            }
            else
            {
                // btnPunchHousvsJT.Enabled = False
                gbDateUserSearch.Enabled = false;
                fillTimeSheet();
                fillExpences();

            }

        }
        private void dtpDateSearchTo_ValueChanged(System.Object sender, System.EventArgs e)
        {

            //  RemoveHandler dtpDateSearchFrom.ValueChanged, AddressOf Me.dtpDateSearchFrom_ValueChanged
            try
            {
                //If dtpDateSearchTo.Text < dtpDateSearchFrom.Text Then
                //    RemoveHandler dtpDateSearchTo.ValueChanged, AddressOf Me.dtpDateSearchTo_ValueChanged
                //    MessageBox.Show("To Date Must be greater and equal to from date", "Date Time ", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                //    '  AddHandler dtpDateSearchTo.ValueChanged, AddressOf Me.dtpDateSearchTo_ValueChanged
                //    ' dtpDateSearchTo.Text = dtpDateSearchFrom.Value.AddDays(-1)
                //    dtpDateSearchTo.Text = DateTime.Now.Date.ToShortDateString()

                //Else
                //    'dtpDateSearchTo.Text = dtpDateSearchFrom.Text.ToString()

                //    fillTimeSheet()
                //    fillExpences()

                //End If
                fillTimeSheet();
                fillExpences();

            }
            catch (Exception ex)
            {

            }
            //   AddHandler dtpDateSearchFrom.ValueChanged, AddressOf Me.dtpDateSearchFrom_ValueChanged
        }
        private void cmbStatus_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {

                string selectStatus = cmbStatus.SelectedValue.ToString();
                // If Not selectStatus Is Nothing And selectStatus <> 0 Then
                //fillTimeSheet()
                //  fillExpences()
                //Else
                fillTimeSheet();
                fillExpences();
                // End If

            }
            catch (Exception ex)
            {

            }
        }
        private void cmbAdminStatus_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {

                string selectStatus = cmbAdminStatus.SelectedValue.ToString();
                // If Not selectStatus Is Nothing And selectStatus <> 0 Then
                fillTimeSheet();
                fillExpences();
                // Else
                // fillTimeSheet()
                // fillExpences()
                //  End If

            }
            catch (Exception ex)
            {

            }
        }
        private void cmbSelectUser_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            // Dim str As String = My.Settings.timeSheetLoginUserType

            // If str = "Admin" Then
            userID = cmbSelectUser.SelectedValue.ToString();
            selectempID =Convert.ToInt32( cmbSelectUser.SelectedValue);
            fillGridJobList();
            fillTimeSheet();
            fillExpences();

            //Else
            //userID = cmbSelectUser.SelectedValue
            //fillGridJobList()
            //fillTimeSheet()
            //fillExpences()
            //selectempID = cmbSelectUser.SelectedValue
            //End If
        }
        private void cmbBillStatus_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {

                string selectBillStatus = cmbBillStatus.SelectedValue.ToString();
                //If Not selectBillStatus Is Nothing And selectBillStatus <> 0 Then
                //    fillTimeSheet()
                //    fillExpences()
                //Else
                fillTimeSheet();
                fillExpences();
                //End If

            }
            catch (Exception ex)
            {

            }
        }
        private void cmbUserSearch_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            try 
            {
                fillTimeSheet();
                fillExpences();
            }
            catch (Exception ex)
            {

            }
           
        }
        private void btnSave_Click(System.Object sender, System.EventArgs e)
        {

            if (tbTimeAndExp.SelectedTab.Text == "Time")
            {


               

                try
                {



                        foreach (DataGridViewRow dr in grdTimeAndExp.Rows) //DirectCast(grdTimeAndExp.Rows[cnt].Cells["Client#"), System.Windows.Forms.DataGridViewComboBoxCell].Value))
                         {
                        // Dim str1 As String = grdTimeAndExp.Columns["TimeSheetID"].Value.ToString()


                        if (dr.Cells["TimeSheetID"].Value.ToString() == "0")
                        {

                            if (!backgroundWorker2.IsBusy)
                            {
                                backgroundWorker2.RunWorkerAsync(2000);
                                //backgroundWorker1.RunWorkerAsync();
                            }
                            else
                            {

                            }


                            ////If str1 = "0" Then
                            //string username = grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"].Value.ToString();
                            ////Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()



                            ////Dim queryString1 As String = "use " + con.Database + " SELECT  EmployeeDetailsId FROM  EmployeeDetails where UserName = '" & grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"].Value.ToString() & "' "

                            //string queryString1 = "SELECT  Id FROM  EmployeeDetails where UserName = '" + grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"].Value.ToString() + "' ";


                            ////int EmpId = StMethod.GetSingleInt(queryString1);

                            ////long EmpId = Convert.ToInt64(StMethod.GetSingleInt(queryString1));
                            ////Int64 EmpId = Convert.ToInt64(StMethod.GetSingleInt(queryString1));


                            ////Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);
                            //Int64 FetchEmpId;

                            //if (Properties.Settings.Default.IsTestDatabase == true)
                            //{
                            //    FetchEmpId = StMethod.GetSingleInt64New(queryString1);

                            //}
                            //else
                            //{
                            //    FetchEmpId = StMethod.GetSingleInt64(queryString1);
                            //}


                            ////Int64 EmpId = Convert.ToInt64(FetchEmpId);

                            ////Int64 EmpId;
                            //Nullable<Int64> EmpId = null;


                            ////DataSet ds1 = new DataSet();
                            ////ds1 = StMethod.GetListDS<EmployeeData>(queryString1);

                            //DataTable dt = new DataTable();
                            ////dt=StMethod.GetListDT<EmployeeData>(queryString1);

                            //if (Properties.Settings.Default.IsTestDatabase == true)
                            //{
                            //    dt = StMethod.GetListDTNew<EmployeeData>(queryString1);

                            //}
                            //else
                            //{
                            //    dt = StMethod.GetListDT<EmployeeData>(queryString1);
                            //}


                            ////if (ds1.Tables[0].Rows.Count == 1)
                            ////{
                            ////    EmpId= Convert.ToInt64(ds1.Tables[0].Rows[0],);

                            ////}

                            //if (dt.Rows.Count == 1)
                            //{
                            //    EmpId= Convert.ToInt64(dt.Rows[0][0].ToString());
                            //}



                            ////If(dt1.Rows.Count = 1) Then

                            ////   EmpId = Convert.ToInt32(dt1.Rows(0)(0).ToString())

                            ////End If




                            ////long vOut = Convert.ToInt64(vIn);

                            ////username = DirectCast(grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"),System.windows.foem.dat


                            //string Date101 = null;
                            //string Date102 = null;

                            //Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                            //string FinalDateUpdate = string.Empty;


                            //if (grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count-1].Cells["Date"].Value == null || grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString()))
                            //{
                            //    // here is your message box...


                            //}
                            //else
                            //{
                            //    //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                            //    Date101 = string.Format("{0:dd/MM/yyyy}", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString());

                            //}

                            //if (grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count-1].Cells["Date"].Tag == null || grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Tag.ToString()))
                            //{
                            //    // here is your message box...

                            //    //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                            //    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                            //    //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                            //    Date102 = string.Format("{0:dd/MM/yyyy}", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString());

                            //    //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                            //    ActionDateUpdate = DateTime.Parse(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString());

                            //    int s, s1, s2;

                            //    //11-22-2021 05:34:05 PM

                            //    s = ActionDateUpdate.Value.Month;
                            //    s1 = ActionDateUpdate.Value.Day;
                            //    s2 = ActionDateUpdate.Value.Year;

                            //    FinalDateUpdate = ActionDateUpdate.Value.Month.ToString() + "-" + ActionDateUpdate.Value.Day.ToString() + "-" + ActionDateUpdate.Value.Year.ToString() + " " + ActionDateUpdate.Value.Hour.ToString() + ":" + ActionDateUpdate.Value.Minute.ToString()
                            //        + ":" + ActionDateUpdate.Value.Second.ToString() + " " + ActionDateUpdate.Value.ToString("tt");


                            //    Date102 = FinalDateUpdate;

                            //}
                            //else
                            //{
                            //    Date102 = grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Tag.ToString();
                            //}


                            //string query = "INSERT INTO TS_Time(JobListID, EmployeeDetailsId,  Name, TrackSubid,TrackSubName, Time, Description, status, BillState,Date,Comment,AdminStatus,JobTrackingId)VALUES(@JobListID, @EmployeeDetailsId,  @Name, @TrackSubid,@TrackSubName, @Time, @Description, @status, @BillState,@Date,@Comment,@AdminStatus,@JobTrackingId)";
                            //List<SqlParameter> param = new List<SqlParameter>();

                            ////param.Add(new SqlParameter("@JobListID", SelectJobListID));

                            //param.Add(new SqlParameter("@JobListID", Convert.ToInt64(SelectJobListID)));

                            //param.Add(new SqlParameter("@Name", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"].Value.ToString()));




                            //param.Add(new SqlParameter("@EmployeeDetailsId", EmpId));


                            //param.Add(new SqlParameter("@TrackSubid", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TrackSubid"].Value.ToString()));
                            //param.Add(new SqlParameter("@TrackSubName", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TrackSubName"].Value.ToString()));
                            //param.Add(new SqlParameter("@Time", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Time"].Value.ToString()));
                            //param.Add(new SqlParameter("@Description", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Description"].Value.ToString()));
                            //param.Add(new SqlParameter("@status", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeItemNameSTATUS"].Value.ToString()));

                            //string DueDate = string.Empty;
                            ////DueDate = grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString();

                            ////DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));
                            ////string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                            ////param.Add(new SqlParameter("@Date", s1.ToString()));

                            //param.Add(new SqlParameter("@Date", Date102));

                            ////param.Add(new SqlParameter("@Date", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString()));


                            //param.Add(new SqlParameter("@Comment", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Comment"].Value.ToString()));
                            //param.Add(new SqlParameter("@BillState", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeItemNameBILLSTATE"].Value.ToString()));
                            //param.Add(new SqlParameter("@AdminStatus", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["AdminStatus"].Value.ToString()));

                            ////param.Add(new SqlParameter("@JobTrackingId", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString()));

                            ////MessageBox.Show("Without " + grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString());

                            ////Int64 checkvalue = Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString());



                            ////MessageBox.Show("With " + checkvalue);

                            //param.Add(new SqlParameter("@JobTrackingId", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString()));

                            ////Int64 checkvalue = Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString());

                            ////param.Add(new SqlParameter("@JobTrackingId", checkvalue ));


                            ////if (StMethod.UpdateRecord(query, param) > 0)
                            ////{
                            ////    //MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            ////    DialogResult choiceButton = KryptonMessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            ////    //fillTimeSheet()
                            ////}

                            //if (Properties.Settings.Default.IsTestDatabase == true)
                            //{


                            //    if (StMethod.UpdateRecordNew(query, param) > 0)
                            //    {
                            //        //MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            //        DialogResult choiceButton = KryptonMessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //        //fillTimeSheet()
                            //    }
                            //}
                            //else
                            //{

                            //    if (StMethod.UpdateRecord(query, param) > 0)
                            //    {
                            //        //MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            //        DialogResult choiceButton = KryptonMessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //        //fillTimeSheet()
                            //    }
                            //}





                        }

                        // else

                        else // ******************************************** Update Record all in Time Sheet **************
                        {


                            //backgroundWorker1.RunWorkerAsync(2000);


                            if(!backgroundWorker1.IsBusy)
                            {
                                backgroundWorker1.RunWorkerAsync(2000);
                                //backgroundWorker1.RunWorkerAsync();
                            }
                            else
                            {                               
                                //backgroundWorker1.CancelAsync();
                            }

                            

                            //if (!worker.IsBusy)
                            //    worker.RunWorkerAsync();
                            //else
                            //    MessageBox.Show("Can't run the worker twice!");

                            // else update start of time



                            //  StringBuilder updateQuery = new StringBuilder("");



                            //  DataTable dtUpdate = new DataTable();
                            //  dtUpdate.Columns.AddRange(new DataColumn[12]
                            //  {
                            //  new DataColumn("JobListID", typeof(Int64)),
                            //  new DataColumn("Name", typeof(string)),
                            //  new DataColumn("EmployeeDetailsId", typeof(Int64)),
                            //  new DataColumn("TrackSubid", typeof(int)),
                            //  new DataColumn("Time", typeof(double)),
                            //  new DataColumn("Description", typeof(string)),
                            //  new DataColumn("status", typeof(string)),
                            //  new DataColumn("BillState", typeof(string)),
                            //  new DataColumn("Date", typeof(DateTime)),
                            //  new DataColumn("Comment", typeof(string)),
                            //  new DataColumn("AdminStatus", typeof(string)),
                            //  new DataColumn("TrackSubName", typeof(string))
                            //  //new DataColumn("TimeSheetID", typeof(Int64))
                            //  });


                            //  DataTable dtUpdate2 = new DataTable();
                            //  dtUpdate2.Columns.AddRange(new DataColumn[1]
                            //{                            
                            //  new DataColumn("TimeSheetID", typeof(Int64))
                            //});


                            //foreach (DataGridViewRow drupdateTimeSheet in grdTimeAndExp.Rows)
                            //{

                            //    try
                            //    {



                            //        string Query = "UPDATE TS_Time SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@Empid,  TrackSubid =@TrackSubid, Time =@Time, Description =@Description, status =@status, BillState =@BillState,Date=@Date,Comment=@Comment,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetID=@TimeSheetID";

                            //        List<SqlParameter> param = new List<SqlParameter>();

                            //        //Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()

                            //        //Dim queryString1 As String = "use " + con.Database + " SELECT  EmployeeDetailsId FROM  EmployeeDetails where UserName = '" & drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString() & "' "

                            //        string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString() + "' ";





                            //        //int UpdateEmpId = StMethod.GetSingleInt(queryString1);

                            //        //Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);
                            //        Int64 FetchEmpId;


                            //        if (Properties.Settings.Default.IsTestDatabase == true)
                            //        {

                            //            FetchEmpId = StMethod.GetSingleInt64New(queryString1);
                            //        }
                            //        else
                            //        {
                            //            FetchEmpId = StMethod.GetSingleInt64(queryString1);
                            //        }

                            //        Int64 UpdateEmpId = Convert.ToInt64(FetchEmpId);

                            //        //Dim queryString1 As String = " SELECT  Id FROM  EmployeeDetails where UserName = '" & drupdateTimeSheet.Cells("TimeSheetUser").Value.ToString() & "' "



                            //        //param.Add(new SqlParameter("@JobListID", drupdateTimeSheet.Cells["JobListID"].Value.ToString()));                                
                            //        param.Add(new SqlParameter("@JobListID", Convert.ToInt64(drupdateTimeSheet.Cells["JobListID"].Value.ToString())));

                            //        param.Add(new SqlParameter("@Name", drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString()));
                            //    param.Add(new SqlParameter("@EmpId", UpdateEmpId));
                            //    param.Add(new SqlParameter("@TrackSubid", drupdateTimeSheet.Cells["TrackSubid"].Value.ToString()));
                            //    param.Add(new SqlParameter("@TrackSubName", drupdateTimeSheet.Cells["TrackSubName"].Value.ToString()));
                            //    param.Add(new SqlParameter("@Time", drupdateTimeSheet.Cells["Time"].Value.ToString()));
                            //    param.Add(new SqlParameter("@Description", drupdateTimeSheet.Cells["Description"].Value.ToString()));
                            //    param.Add(new SqlParameter("@status", drupdateTimeSheet.Cells["TimeItemNameSTATUS"].Value.ToString()));
                            //    param.Add(new SqlParameter("@BillState", drupdateTimeSheet.Cells["TimeItemNameBILLSTATE"].Value.ToString()));




                            //        string DueDate = string.Empty;
                            //    DueDate = drupdateTimeSheet.Cells["Date"].Value.ToString();

                            //    DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));
                            //    string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                            //    param.Add(new SqlParameter("@Date", s1.ToString()));

                            //    //param.Add(new SqlParameter("@Date", drupdateTimeSheet.Cells["Date"].Value.ToString()));

                            //    param.Add(new SqlParameter("@Comment", drupdateTimeSheet.Cells["Comment"].Value.ToString()));

                            //    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                            //    {
                            //        param.Add(new SqlParameter("@AdminStatus", drupdateTimeSheet.Cells["AdminStatus"].Value.ToString()));
                            //    }
                            //    else
                            //    {

                            //        param.Add(new SqlParameter("@AdminStatus", drupdateTimeSheet.Cells["AdminStatus"].Value.ToString()));
                            //    }


                            //        //string Query = "UPDATE TS_Time SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@Empid,  TrackSubid =@TrackSubid, Time =@Time, Description =@Description, status =@status, BillState =@BillState,Date=@Date,Comment=@Comment,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetID=@TimeSheetID";




                            //        param.Add(new SqlParameter("@TimeSheetID", drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString()));

                            //    //updateQuery.Append("UPDATE [" + harltabcol[i, 1] + "] SET [" + harltabcol[i, 0] + "] =N'" + temp1 + "' WHERE " + harltabcol[i, 0] + "='" + temp + "';");

                            //    //updateQuery.Append(Query + ";");

                            //        //updateQuery.Append(Query); 

                            //        //if (StMethod.UpdateRecord(Query, param) > 0)
                            //        //{
                            //        //    //MessageBox.Show("updated");
                            //        //}


                            //        //dtUpdate.Rows.Add(Convert.ToInt64(drupdateTimeSheet.Cells["JobListID"].Value.ToString()), drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString(), UpdateEmpId, drupdateTimeSheet.Cells["TrackSubid"].Value.ToString(), drupdateTimeSheet.Cells["Time"].Value.ToString(), drupdateTimeSheet.Cells["Description"].Value.ToString(), drupdateTimeSheet.Cells["TimeItemNameSTATUS"].Value.ToString(), drupdateTimeSheet.Cells["TimeItemNameBILLSTATE"].Value.ToString(), s1.ToString(), drupdateTimeSheet.Cells["Comment"].Value.ToString(), drupdateTimeSheet.Cells["AdminStatus"].Value.ToString(), drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString(), drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString());


                            //        //dtUpdate.Rows.Add(Convert.ToInt64(drupdateTimeSheet.Cells["JobListID"].Value.ToString()), drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString(), UpdateEmpId, drupdateTimeSheet.Cells["TrackSubid"].Value.ToString(), drupdateTimeSheet.Cells["Time"].Value.ToString(), drupdateTimeSheet.Cells["Description"].Value.ToString(), drupdateTimeSheet.Cells["TimeItemNameSTATUS"].Value.ToString(), drupdateTimeSheet.Cells["TimeItemNameBILLSTATE"].Value.ToString(), s1.ToString(), drupdateTimeSheet.Cells["Comment"].Value.ToString(), drupdateTimeSheet.Cells["AdminStatus"].Value.ToString(), drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString());

                            //        //dtUpdate2.Rows.Add(drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString());


                            //        //if (Properties.Settings.Default.IsTestDatabase == true)
                            //        //{

                            //        //    if (StMethod.UpdateRecordNew(Query, param) > 0)
                            //        //    {
                            //        //        //MessageBox.Show("updated");
                            //        //    }
                            //        //}
                            //        //else
                            //        //{
                            //        //    if (StMethod.UpdateRecord(Query, param) > 0)
                            //        //    {
                            //        //        //MessageBox.Show("updated");
                            //        //    }
                            //        //}






                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        MessageBox.Show(ex.Message.ToString());

                            //    }

                            //}




                            // for each end






                            //if (dtUpdate.Rows.Count > 0)
                            //{
                            //    //InsertInvoiceItemsNew("JobTrackInvoiceRateDetail", dt, sqlTran);
                            //    //UpdateTimeNew("TS_Time", dtUpdate,);
                            //    if (Properties.Settings.Default.IsTestDatabase == true)
                            //    {
                            //        //string Query = "UPDATE TS_Time SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@Empid,  TrackSubid =@TrackSubid, Time =@Time, Description =@Description, status =@status, BillState =@BillState,Date=@Date,Comment=@Comment,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetID=@TimeSheetID";

                            //        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            //        {
                            //            UpdateTimeNew("TS_Time", dtUpdate, db,dtUpdate2);
                            //        }

                            //    }
                            //    else
                            //    {
                            //        //using (EFDbContext db = new EFDbContext())
                            //        //{
                            //        //    UpdateTime("TS_Time", dtUpdate, db);
                            //        //}
                            //    }

                            //}
                            ///



                        }
                    }


                    ////////// else finish

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }


            }
            else
            {

                //try
                //{
                
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message.ToString());
                //}

              


                foreach (DataGridViewRow dr in grdExpenses.Rows)
                {
                    // Dim str As String = grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TimeSheetExpencesID"].Value.ToString()
                    if (dr.Cells["TimeSheetExpencesID"].Value.ToString() == "0")
                    {
                        //If str = "0" Then

                        if (!backgroundWorker3.IsBusy)
                        {
                            backgroundWorker3.RunWorkerAsync(2000);
                            //backgroundWorker1.RunWorkerAsync();
                        }
                        else
                        {
                            //backgroundWorker1.CancelAsync();
                        }


                        //string Date101 = null;
                        //string Date102 = null;

                        //Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                        //string FinalDateUpdate = string.Empty;


                        //if (grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value == null || grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString()))
                        //{
                        //    // here is your message box...


                        //}
                        //else
                        //{
                        //    //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        //    Date101 = string.Format("{0:dd/MM/yyyy}", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString());

                        //}

                        //if (grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Tag == null || grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Tag.ToString()))
                        //{
                        //    // here is your message box...

                        //    //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                        //    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        //    //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                        //    //Date102 = string.Format("{0:dd/MM/yyyy}", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString());

                        //    //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                            
                        //    ActionDateUpdate = DateTime.Parse(grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString());

                        //    int s, s1, s2;

                        //    //11-22-2021 05:34:05 PM

                        //    s = ActionDateUpdate.Value.Month;
                        //    s1 = ActionDateUpdate.Value.Day;
                        //    s2 = ActionDateUpdate.Value.Year;

                        //    FinalDateUpdate = ActionDateUpdate.Value.Month.ToString() + "-" + ActionDateUpdate.Value.Day.ToString() + "-" + ActionDateUpdate.Value.Year.ToString() + " " + ActionDateUpdate.Value.Hour.ToString() + ":" + ActionDateUpdate.Value.Minute.ToString()
                        //        + ":" + ActionDateUpdate.Value.Second.ToString() + " " + ActionDateUpdate.Value.ToString("tt");


                        //    Date102 = FinalDateUpdate;

                        //}
                        //else
                        //{
                        //    Date102 = grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Tag.ToString();
                        //}


                        //string query = "INSERT INTO TS_Expences(JobListID, EmployeeDetailsId,Name,TrackSubid,TrackSubName,  Expences,  Description, status, BillState,Date,Comment,AdminStatus)VALUES(@JobListID, @EmployeeDetailsId,  @Name, @TrackSubid,@TrackSubName, @Expences, @Description, @status, @BillState,@Date,@Comment,@AdminStatus)";

                        ////MessageBox.Show("query => " + query);

                        ////string query = "INSERT INTO TS_Expences(JobListID, EmployeeDetailsId,Name,TrackSubid,TrackSubName,  Expences,  Description, status, BillState,Date,Comment,AdminStatus )VALUES(@JobListID, @EmployeeDetailsId,  @Name, @TrackSubid,@TrackSubName, @Expences, @Description, @status, @BillState,@Date,@Comment,@AdminStatus)";


                        //List<SqlParameter> param = new List<SqlParameter>();

                        //string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetUser"].Value.ToString() + "' ";

                        ////MessageBox.Show("queryString1 => " + queryString1);

                        ////int InsertEmpId = StMethod.GetSingleInt(queryString1);

                        ////int FetchEmpId = StMethod.GetSingleInt(queryString1);

                        ////Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);

                        //Int64 FetchEmpId;

                        //if (Properties.Settings.Default.IsTestDatabase == true)
                        //{
                        //    FetchEmpId = StMethod.GetSingleInt64New(queryString1);

                        //}
                        //else
                        //{
                        //    FetchEmpId = StMethod.GetSingleInt64(queryString1);
                        //}


                        //Int64 InsertEmpId = Convert.ToInt64(FetchEmpId);

                        ////MessageBox.Show("FetchEmpId => " + FetchEmpId);
                        ////MessageBox.Show("InsertEmpId => " + InsertEmpId);

                        //param.Add(new SqlParameter("@JobListID", Convert.ToInt64(SelectJobListID)));

                        ////param.Add(new SqlParameter("@JobListID", SelectJobListID));

                        ////MessageBox.Show("JobListID => " + Convert.ToInt64(SelectJobListID));


                        //param.Add(new SqlParameter("@Name", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetUser"].Value.ToString()));
                        //param.Add(new SqlParameter("@EmployeeDetailsId", InsertEmpId));



                        ////MessageBox.Show("Name => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetUser"].Value.ToString());
                        ////MessageBox.Show("EmployeeDetailsId => " + InsertEmpId);

                        //param.Add(new SqlParameter("@TrackSubid", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TrackSubid"].Value.ToString()));

                        ////MessageBox.Show("TrackSubid => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TrackSubid"].Value.ToString());

                        //param.Add(new SqlParameter("@TrackSubName", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TrackSubName"].Value.ToString()));
                        //param.Add(new SqlParameter("@Expences", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Expences"].Value.ToString()));


                        ////MessageBox.Show("TrackSubName => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TrackSubName"].Value.ToString());
                        ////MessageBox.Show("Expences => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Expences"].Value.ToString());

                        //param.Add(new SqlParameter("@Description", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Description"].Value.ToString()));
                        //param.Add(new SqlParameter("@status", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetItemNameSTATUS"].Value.ToString()));
                        //param.Add(new SqlParameter("@BillState", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetItemNameBILLSTATE"].Value.ToString()));


                        ////MessageBox.Show("Description => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Description"].Value.ToString());
                        ////MessageBox.Show("status => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetItemNameSTATUS"].Value.ToString());
                        ////MessageBox.Show("BillState => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetItemNameBILLSTATE"].Value.ToString());
                        


                        ////string DueDate = string.Empty;
                        ////DueDate = grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString();

                        ////DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));
                        ////string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                        //param.Add(new SqlParameter("@Date", Date102));


                        ////MessageBox.Show("Date => " + Date102);
                        
                        ////param.Add(new SqlParameter("@Date", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString()));

                        //param.Add(new SqlParameter("@Comment", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Comment"].Value.ToString()));

                        ////MessageBox.Show("Comment => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Comment"].Value.ToString());


                        //param.Add(new SqlParameter("@AdminStatus", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["AdminStatus"].Value.ToString()));

                        ////MessageBox.Show("AdminStatus => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["AdminStatus"].Value.ToString());

                        //if (StMethod.UpdateRecord(query, param) > 0)
                        //{
                        //    MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //    //fillExpences()
                        //}



                        //if (Properties.Settings.Default.IsTestDatabase == true)
                        //{

                        //    if (StMethod.UpdateRecordNew(query, param) > 0)
                        //    {
                        //        MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //        //fillExpences()
                        //    }


                        //}
                        //else
                        //{
                        //    if (StMethod.UpdateRecord(query, param) > 0)
                        //    {
                        //        MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //        //fillExpences()
                        //    }


                        //}


                    }


                    // end of if


                    else //***********************Update the record all *********************************
                    {

                        if (!backgroundWorker4.IsBusy)
                        {
                            backgroundWorker4.RunWorkerAsync(2000);
                            //backgroundWorker1.RunWorkerAsync();
                        }
                        else
                        {
                            //backgroundWorker1.CancelAsync();
                        }


                        //foreach (DataGridViewRow drUpdate in grdExpenses.Rows)
                        //{

                        //    //MessageBox.Show("2047");

                        //    string Query = "UPDATE TS_Expences SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@EmployeeDetailsId,  TrackSubid =@TrackSubid, Expences =@Expences, Description =@Description, status =@status, BillState =@BillState,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetExpencesID=@TimeSheetExpencesID";
                        //    List<SqlParameter> param = new List<SqlParameter>();

                        //    //MessageBox.Show("Query => " + Query);


                        //    //string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + drUpdate.Cells["ExpenseSheetUser"].Value.ToString() + "' ";

                        //    string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + drUpdate.Cells["ExpenseSheetUser"].Value.ToString() + "' ";

                        //    //int UpdateEmpId = StMethod.GetSingleInt(queryString1);

                        //    //MessageBox.Show("queryString1 => " + queryString1);

                        //    //int FetchEmpId2 = StMethod.GetSingleInt(queryString1);
                        //    //Int64 UpdateEmpId = Convert.ToInt64(FetchEmpId2);

                        //    //Int64 FetchEmpId2 = StMethod.GetSingleInt64(queryString1);
                        //    Int64 FetchEmpId2;

                        //    if (Properties.Settings.Default.IsTestDatabase == true)
                        //    {
                        //        FetchEmpId2 = StMethod.GetSingleInt64New(queryString1);


                        //    }
                        //    else
                        //    {
                        //        FetchEmpId2 = StMethod.GetSingleInt64(queryString1);

                        //    }


                        //    //MessageBox.Show("FetchEmpId2 => " + FetchEmpId2);

                        //    Int64 UpdateEmpId = Convert.ToInt64(FetchEmpId2);

                        //    //MessageBox.Show("UpdateEmpId => " + UpdateEmpId);

                        //    param.Add(new SqlParameter("@JobListID", Convert.ToInt64(drUpdate.Cells["JobListID"].Value.ToString())));

                        //    //param.Add(new SqlParameter("@JobListID", drUpdate.Cells["JobListID"].Value.ToString()));


                        //    //MessageBox.Show("JobListID => " + Convert.ToInt64(drUpdate.Cells["JobListID"].Value.ToString()));

                        //    param.Add(new SqlParameter("@Name", drUpdate.Cells["ExpenseSheetUser"].Value.ToString()));
                        //    param.Add(new SqlParameter("@EmployeeDetailsId", UpdateEmpId));
                        //    param.Add(new SqlParameter("@TrackSubid", drUpdate.Cells["TrackSubid"].Value.ToString()));
                        //    param.Add(new SqlParameter("@TrackSubName", drUpdate.Cells["TrackSubName"].Value.ToString()));
                        //    param.Add(new SqlParameter("@Expences", drUpdate.Cells["Expences"].Value.ToString()));
                        //    param.Add(new SqlParameter("@Description", drUpdate.Cells["Description"].Value.ToString()));
                        //    param.Add(new SqlParameter("@status", drUpdate.Cells["ExpenseSheetItemNameSTATUS"].Value.ToString()));
                        //    param.Add(new SqlParameter("@BillState", drUpdate.Cells["ExpenseSheetItemNameBILLSTATE"].Value.ToString()));

                        //    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                        //    {
                        //        param.Add(new SqlParameter("@AdminStatus", drUpdate.Cells["AdminStatus"].Value.ToString()));
                        //    }
                        //    else
                        //    {
                        //        param.Add(new SqlParameter("@AdminStatus", drUpdate.Cells["AdminStatus"].Value.ToString()));
                        //    }

                        //    param.Add(new SqlParameter("@TimeSheetExpencesID", drUpdate.Cells["TimeSheetExpencesID"].Value.ToString()));

                        //    //if (StMethod.UpdateRecord(Query, param) > 0)
                        //    //{
                        //    //    //MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        //    //    //MessageBox.Show("Update Successfully!");
                        //    //}

                        //    if (Properties.Settings.Default.IsTestDatabase == true)
                        //    {

                        //        if (StMethod.UpdateRecordNew(Query, param) > 0)
                        //        {
                        //            //MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        //            //MessageBox.Show("Update Successfully!");
                        //        }
                        //    }
                        //    else
                        //    {
                        //        if (StMethod.UpdateRecord(Query, param) > 0)
                        //        {
                        //            //MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        //            //MessageBox.Show("Update Successfully!");
                        //        }
                        //    }

                        //}


                    }


                    // else end above line
                }
            }

            //fillTimeSheet();
            //fillExpences();
        }
        private void txtDescriptionSearchJob_TextChanged(System.Object sender, System.EventArgs e)
        {
            fillGridJobList();
        }
        private void dtpDateSearchFrom_ValueChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                dtpDateSearchTo.ValueChanged -= this.dtpDateSearchTo_ValueChanged;
                dtpDateSearchTo.Text = dtpDateSearchFrom.Text;
                fillTimeSheet();
                fillExpences();

                dtpDateSearchTo.ValueChanged += this.dtpDateSearchTo_ValueChanged;
            }
            catch (Exception ex)
            {
            }
        }
        private void txtSearchUser_TextChanged(System.Object sender, System.EventArgs e)
        {
            fillTimeSheet();
            fillExpences();
        }

        //private object CreateExpenseRow(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle AllCellStyle, ICreationHelper ICH, IDataFormat IDF, ICellStyle SecondCS)

        private object CreateExpenseRow(DataTable dt, HSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle AllCellStyle, ICreationHelper ICH, IDataFormat IDF, ICellStyle SecondCS)
        {

        //    Dim ColumnIndex As Integer = 0
        //    Dim sheetRow = sheet.CreateRow(sheetRowIndex)
        //    sheetRow = sheet.CreateRow(sheetRowIndex)
        //        ColumnIndex = 0

            //Dim row As IRow = sheet.CreateRow(sheetRowIndex)

            int ColumnIndex = 0;
            IRow row = sheet.CreateRow(sheetRowIndex);
            row = sheet.CreateRow(sheetRowIndex);


            ColumnIndex = 0;
            //Dim row As IRow = sheet.CreateRow(sheetRowIndex)

            row = sheet.CreateRow(sheetRowIndex);

           
            foreach (DataColumn header in dt.Columns)
            {
                string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                if (ColumnIndex == 0)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                if (ColumnIndex == 1)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);


                    //string filter = columnvalue.ToString();
                    //string[] filterRemove = filter.Split('-');

                    //string Date1 = filterRemove[0];
                    //string Month1 = filterRemove[1];
                    //string TempString = filterRemove[2];

                    //string[] filterRemovePart2 = TempString.Split(' ');

                    //string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];

                    //Cell1.SetCellValue(FindalDate);
                    //Cell1.CellStyle = AllCellStyle;


                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;


                }

                if (ColumnIndex == 2)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                if (ColumnIndex == 3)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                if (ColumnIndex == 4)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                if (ColumnIndex == 5)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                if (ColumnIndex == 6)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    //Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    //Cell1.SetCellValue(columnvalue);
                    //Cell1.CellStyle = AllCellStyle;

                    //Dim Currency As String = FormatCurrency(columnvalue, 2)

                    //Dim filter As String = Currency.ToString()
                    //Dim filterRemove() As String = filter.Split("$")

                    //Dim Sign As String = "$"
                    //Dim Value As String = filterRemove(1)
                    //Dim Value2 As Decimal = filterRemove(1)

                    //String Currency = Microsoft.VisualBasic.Strings.FormatCurrency(columnvalue,2);

                    //String filter = Currency.ToString();
                    //String[] filterRemove = filter.Split('$');
                    //String Sign = "$";

                    //String Value1;
                    //Value1 = filterRemove[1];
                    //Decimal Value2 = Convert.ToDecimal (filterRemove[1]);

                    //AllCellStyle.DataFormat = ICH.CreateDataFormat().GetFormat("$ ##,##0.00");

                    //String FinalValue = Sign.ToString().Trim() + " " + Value1.ToString().Trim();


                    //Cell1.SetCellValue(Convert.ToDouble(Value2));
                    //Cell1.CellStyle = AllCellStyle;

                    if (String.IsNullOrEmpty(columnvalue))
                    {
                        Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell1.SetCellValue(String.Empty);
                    }
                    else
                    {



                        //Cell1.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        //Double FinalValue = Convert.ToDouble(columnvalue);
                        //Cell1.SetCellValue("$ " + FinalValue.ToString("0.00"));



                        //Cell1.SetCellValue(columnvalue);

                        //CellStyle.DataFormat = CreationHelper.CreateDataFormat.GetFormat("$ ##,##0.00")
                        //Dim FinalValue As String = Sign.ToString().Trim() + " " + Value.ToString().Trim()
                        //Cell.SetCellValue(Value2)

                        //String.Format("{0:00.0}", 123.4567);      // "123.5"

                        //Math.Round(inputValue, 2, MidpointRounding.AwayFromZero)
                        //decimalVar.ToString("0.00");
                        //Cell1.SetCellValue("$" + String.Format("{0:00.0}", columnvalue));





                        //Cell1.SetCellValue("$" + Math.Round(Convert.ToDouble(columnvalue),2,MidpointRounding.AwayFromZero));

                        //Cell1.SetCellValue("$" + Convert.ToDouble(columnvalue));

                        //Cell1.SetCellValue(Convert.ToDouble(columnvalue));



                        //string filter = columnvalue;
                        //string Sign = "$";


                        //string Currency = FormatCurrency(columnvalue, 2);


                        Cell1.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        


                        string Currency = columnvalue;

                        string filter = Currency.ToString();
                        string[] filterRemove = filter.Split('$');
                        string Sign = "$";
                        string Value = filterRemove[0];

                        Double Value2 = Convert.ToDouble(filterRemove[0]);

                        //ICH.CreateDataFormat.

                        AllCellStyle.DataFormat= ICH.CreateDataFormat().GetFormat("$ ##,##0.00");

                        //Double FinalValue = Convert.ToDouble(columnvalue);
                        string FinalValue = Sign.ToString().Trim() + " " + Value.ToString().Trim();
                        
                        Cell1.SetCellValue(Value2);


                        //Dim Currency As String = FormatCurrency(columnvalue, 2)
                        //Dim filter As String = Currency.ToString()
                        //Dim filterRemove() As String = filter.Split("$")


                        //Dim Sign As String = "$"
                        //Dim Value As String = filterRemove(1)
                        //Dim Value2 As Decimal = filterRemove(1)
                        //CellStyle.DataFormat = CreationHelper.CreateDataFormat.GetFormat("$ ##,##0.00")

                        //Dim FinalValue As String = Sign.ToString().Trim() + " " + Value.ToString().Trim()

                        //Cell.SetCellValue(Value2)

                    }
                    Cell1.CellStyle = AllCellStyle;


                    //        '    If (String.IsNullOrEmpty(columnvalue)) Then
                    //'        Cell.SetCellType(NPOI.SS.UserModel.CellType.String)
                    //'        Cell.SetCellValue(String.Empty)
                    //'    Else
                    //'        Cell.SetCellType(NPOI.SS.UserModel.CellType.Numeric)
                    //'        Cell = row.CreateCell(ColumnIndex)
                    //'        Cell.SetCellValue(Convert.ToDecimal(columnvalue))
                    //'    End If

                }

                if (ColumnIndex == 7)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                if (ColumnIndex == 8)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                if (ColumnIndex == 9)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }
                ColumnIndex = ColumnIndex + 1;
            }
            sheetRowIndex = sheetRowIndex + 1;

             return null;
        }

        //private object CreateTimeExpesneRowForSeconDExport(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle AllCellStyle, ICreationHelper ICH, IDataFormat IDF, ICellStyle SecondCS)
        //{
            private object CreateTimeExpesneRowForSeconDExport(DataTable dt, HSSFCellStyle  borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle AllCellStyle, ICreationHelper ICH,IDataFormat IDF,ICellStyle SecondCS)
        {

            //add column header
            
            int ColumnIndex = 0;
            //var sheetRow = sheet.CreateRow(sheetRowIndex);


            //Dim row As IRow = sheet.CreateRow(sheetRowIndex)

            IRow row = sheet.CreateRow(sheetRowIndex);
            
            //foreach (DataColumn header in dt.Columns)
            //{
            //    //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
            //    CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
            //    ColumnIndex = ColumnIndex + 1;
            //}

            ////-----------------------------------------
            ////Add column values 
            //sheetRowIndex = sheetRowIndex + 1;
            //sheetRow = sheet.CreateRow(sheetRowIndex);
            //ColumnIndex = 0;
            foreach (DataColumn header in dt.Columns)
            {
                
                
                string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();
                //MessageBox.Show(columnvalue);
                //sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);



                //ICell Cell1 = sheetRow.CreateCell(ColumnIndex);
                //Cell1.SetCellValue(columnvalue);
                //Cell1.CellStyle = AllCellStyle;

                //ColumnIndex = ColumnIndex + 1;

               

                if (ColumnIndex == 0)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);                    
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                }

                if (ColumnIndex == 1)
                {

                //    Dim Cell As ICell = row.CreateCell(ColumnIndex)
                //Cell.SetCellType(NPOI.SS.UserModel.CellType.String)

                //CellStyle.DataFormat = Nothing
                //SecondCellStyle.DataFormat = Nothing


                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);




                    //AllCellStyle = null;

                    //Dim DateFormat2 As String = FormatDateTime(columnvalue)

                    //Dim filter As String = DateFormat2.ToString()
                    //Dim filterRemove() As String = filter.Split("/")

                    //Dim Month1 As String = filterRemove(0)
                    //Dim Date1 As String = filterRemove(1)
                    //Dim Year1 As String = filterRemove(2)


                    //Dim testDate As DateTime = #3/12/1999#

                    //String DateFormat2 = DateTime.FromOADate 


                    //string DateFormat2 = FormatDateTime(columnvalue);




                    //string Month1 = filterRemove[0];
                    //string Date1 = filterRemove[1];
                    //string Year1 = filterRemove[2];

                    //string Remain = filterRemove[3];

                    //String FindalDate = Date1 + "-" + Month1 + "-" + Year1;



                    //13-10-2016 12:00:00 AM



                    //string filter = columnvalue.ToString();
                    //string[] filterRemove = filter.Split('-');

                    //string Date1 = filterRemove[0];
                    //string Month1 = filterRemove[1];
                    //string TempString = filterRemove[2];

                    //string[] filterRemovePart2 = TempString.Split(' ');

                    //string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];
                    //Cell1.SetCellValue(FindalDate);

                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                    

                }

                if (ColumnIndex == 2)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                }

                if (ColumnIndex == 3)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                }

                if (ColumnIndex == 4)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                    Cell1.SetCellValue(Convert.ToDouble(columnvalue.ToString()));
                    Cell1.CellStyle = AllCellStyle;


                }

                if (ColumnIndex == 5)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                }

                if (ColumnIndex == 6)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                }

                if (ColumnIndex == 7)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                }

                if (ColumnIndex == 8)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                }

                if (ColumnIndex == 9)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;

                }

                if (ColumnIndex == 10)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);

                    //Cell1.SetCellValue(columnvalue);
                    //Cell1.CellStyle = SecondCS;

                    //SecondCellStyle.DataFormat = Nothing

                    if (string.IsNullOrEmpty(columnvalue))
                    {
                        Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell1.SetCellValue(String.Empty);
                    }
                    else
                    {
                        //Cell1.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        Cell1 = row.CreateCell(ColumnIndex);
                        Cell1.SetCellValue(Convert.ToDouble(columnvalue));
                    }
                    Cell1.CellStyle = SecondCS;

                }

                //if (ColumnIndex == 11)
                //{
                //    ICell Cell1 = sheetRow.CreateCell(ColumnIndex);
                //    Cell1.SetCellValue("testing without border");
                //    Cell1.CellStyle = SecondCS;
                //}



                ColumnIndex = ColumnIndex + 1;



            }

            sheetRowIndex = sheetRowIndex + 1;


            ////Get jobListID
            //string jobListID = dt.Rows[rowindex]["JobListID"].ToString();

            ////set Time sub grid data 
            ////------------------------------------------------------
            //DataTable SubDatatable = GetSubTimeGridData(jobListID);

            //SetSheetDatatable(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);

            ////'-------------------------------------------------------

            ////'set Expense sub grid data 
            ////'------------------------------------------------------
            //SubDatatable = GeExpensesData(jobListID);
            //SetSheetDatatable(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);

            ////'-------------------------------------------------------

            return null;
        }


        private void ExportTimeExpensesToExcel()
        {
            try
            {
                //    Dim Export As New SaveFileDialog
                //Export.Filter = "Excel Format|*.xls"
                //Export.Title = "Export TimeSheetAndExpenses"
                //Export.InitialDirectory = "N:"


                SaveFileDialog ExportTimeExpense = new SaveFileDialog();


                //ExportTimeExpense.Filter = "Excel Format|*.xlsx";
                ExportTimeExpense.Filter = "Excel Format|*.xls";
                ExportTimeExpense.Title = "Export TimeSheetAndExpenses";
                ExportTimeExpense.InitialDirectory = "N:";

                if (ExportTimeExpense.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                //Dim TimeSheetId As Guid = System.Guid.NewGuid()
                string strFileName = ExportTimeExpense.FileName; // "TimeAndExpenses" & TimeSheetId.ToString() '
                bool blnFileOpen = false;

                //    Dim FullFilePath As String = Export.FileName
                //Dim filename As String = Path.GetFileName(Export.FileName)
                //Dim filePath As String = Export.FileName


                String FullFilePath = ExportTimeExpense.FileName;
                String filename = Path.GetFileName(ExportTimeExpense.FileName);
                String filePath = ExportTimeExpense.FileName;

                try
                {
                    System.IO.FileStream fileTemp = System.IO.File.OpenWrite(strFileName);
                    fileTemp.Close();
                }
                catch (Exception ex)
                {
                    blnFileOpen = false;
                }

                if (System.IO.File.Exists(strFileName))
                {
                    System.IO.File.Delete(strFileName);
                }


                //XSSFWorkbook WorkBook = new XSSFWorkbook();
                HSSFWorkbook WorkBook = new HSSFWorkbook();
                
                ISheet Sheet1 = WorkBook.CreateSheet(filename);

                DataTable dt = new DataTable();
                Boolean flage = false;
                DataTable DtHideColumngridView = new DataTable();

                //If tbTimeAndExp.SelectedTab.Text = "Time" Then

                if (tbTimeAndExp.SelectedTab.Text == "Time")
                {

                    //DtHideColumngridView = dtTimeExportExcelSheet;
                    //DtHideColumngridView.Columns.Add("Punch Hrs");

                    DtHideColumngridView = dtTimeExportExcelSheet;
                    DtHideColumngridView.Columns.Add("Punch Hrs");

                    //change header name

                    DtHideColumngridView.Columns.Remove("TimeSheetID");
                    DtHideColumngridView.Columns["status"].ColumnName = "Status";
                    DtHideColumngridView.Columns["Job_Number"].ColumnName = "Job#";
                    DtHideColumngridView.Columns["TrackSubName"].ColumnName = "TrackSub Comment";
                    DtHideColumngridView.Columns["BillState"].ColumnName = "Bill State";
                    DtHideColumngridView.Columns["AdminStatus"].ColumnName = "Admin Status";
                    DtHideColumngridView.Columns["Name"].ColumnName = "PM";

                    //DtHideColumngridView.Columns.Remove("TimeSheetID")

                    //DtHideColumngridView.Columns("status").ColumnName = "Status"
                    //DtHideColumngridView.Columns("Job Number").ColumnName = "Job#"
                    //DtHideColumngridView.Columns("TrackSubName").ColumnName = "TrackSub Comment"
                    //DtHideColumngridView.Columns("BillState").ColumnName = "Bill State"
                    //DtHideColumngridView.Columns("AdminStatus").ColumnName = "Admin Status"
                    //DtHideColumngridView.Columns("Name").ColumnName = "PM"


                    //' Add new Column
                    DtHideColumngridView.Columns["Time"].ColumnName = "Submit Hrs";
                    //DtHideColumngridView.Columns("Time").ColumnName = "Submit Hrs"


                    //'set display index

                    DtHideColumngridView.Columns["Job#"].SetOrdinal(1);
                    DtHideColumngridView.Columns["Date"].SetOrdinal(2);
                    DtHideColumngridView.Columns["PM"].SetOrdinal(3);
                    DtHideColumngridView.Columns["Status"].SetOrdinal(4);
                    DtHideColumngridView.Columns["Submit Hrs"].SetOrdinal(5);

                    DtHideColumngridView.Columns["Punch Hrs"].SetOrdinal(6);
                    DtHideColumngridView.Columns["Bill State"].SetOrdinal(7);
                    DtHideColumngridView.Columns["TrackSub Comment"].SetOrdinal(8);
                    DtHideColumngridView.Columns["Description"].SetOrdinal(9);
                    DtHideColumngridView.Columns["Admin Status"].SetOrdinal(10);
                    //DtHideColumngridView.Columns["TimeSheetID"].SetOrdinal(11);


                    //DtHideColumngridView.Columns("Job#").SetOrdinal(1)
                    //DtHideColumngridView.Columns("Date").SetOrdinal(2)
                    //DtHideColumngridView.Columns("PM").SetOrdinal(3)
                    //DtHideColumngridView.Columns("Status").SetOrdinal(4)
                    //DtHideColumngridView.Columns("Submit Hrs").SetOrdinal(5)
                    //DtHideColumngridView.Columns("Punch Hrs").SetOrdinal(6)
                    //DtHideColumngridView.Columns("Bill State").SetOrdinal(7)
                    //DtHideColumngridView.Columns("TrackSub Comment").SetOrdinal(8)
                    //DtHideColumngridView.Columns("Description").SetOrdinal(9)
                    //DtHideColumngridView.Columns("Admin Status").SetOrdinal(10)
                    //'DtHideColumngridView.Columns("TimeSheetID").SetOrdinal(11)
                }
                else
                {
                    //DtHideColumngridView = dtExpensesExportExcelSheet

                    //DtHideColumngridView.Columns.Remove("TimeSheetExpencesID")
                    //DtHideColumngridView.Columns("status").ColumnName = "Status"
                    //DtHideColumngridView.Columns("Job Number").ColumnName = "Job#"
                    //DtHideColumngridView.Columns("Name").ColumnName = "PM"
                    //DtHideColumngridView.Columns("Expences").ColumnName = "Amount "
                    //DtHideColumngridView.Columns("TrackSubName").ColumnName = "TrackSub Comment"
                    //DtHideColumngridView.Columns("BillState").ColumnName = "Bill State"
                    //DtHideColumngridView.Columns("AdminStatus").ColumnName = "Admin Status"
                    //flage = True

                    DtHideColumngridView = dtExpensesExportExcelSheet;

                    DtHideColumngridView.Columns.Remove("TimeSheetExpencesID");

                    DtHideColumngridView.Columns["status"].ColumnName = "Status";
                    DtHideColumngridView.Columns["Job_Number"].ColumnName = "Job#";
                    DtHideColumngridView.Columns["Name"].ColumnName = "PM";
                    DtHideColumngridView.Columns["Expences"].ColumnName = "Amount";
                    DtHideColumngridView.Columns["TrackSubName"].ColumnName = "TrackSub Comment";
                    DtHideColumngridView.Columns["BillState"].ColumnName = "Bill State";
                    DtHideColumngridView.Columns["AdminStatus"].ColumnName = "Admin Status";
                    flage = true;
                }

                //DtHideColumngridView.Columns.Remove("JobListID")
                //DtHideColumngridView.Columns.Remove("EmployeeDetailsId")
                //DtHideColumngridView.Columns.Remove("Comment")
                //DtHideColumngridView.Columns.Remove("TrackSubID")

                //dt = DtHideColumngridView

                DtHideColumngridView.Columns.Remove("JobListID");
                DtHideColumngridView.Columns.Remove("EmployeeDetailsId");
                DtHideColumngridView.Columns.Remove("Comment");
                DtHideColumngridView.Columns.Remove("TrackSubID");
                dt = DtHideColumngridView;


                //If dt.Rows.Count > 0 Then

                //    Dim dc As System.Data.DataColumn
                //    Dim dr As System.Data.DataRow
                //    Dim colIndex As Integer = 0
                //    Dim rowIndex As Integer = 0

                //    Dim sheetRow = sheet1.CreateRow(1)

                //    Dim HeaderRow As IRow = sheet1.CreateRow(1)

                if (dt.Rows.Count > 0)
                {

                    //DataColumn dc = new DataColumn();
                    DataRow dr;
                    int colIndex = 0;
                    int rowIndex = 0;


                    //IRow sheetrow = Sheet1.CreateRow(1);
                    IRow HeaderRow = Sheet1.CreateRow(1);

                    //For Each dc In dt.Columns

                    //If tbTimeAndExp.SelectedTab.Text = "Time" Then

                    if(tbTimeAndExp .SelectedTab.Text == "Time") 
                    {
                        foreach (DataColumn dc in dt.Columns)
                        {

                            if (dc.ColumnName == "JobTrackingId")
                            {


                                IFont font2 = WorkBook.CreateFont();
                                font2.IsBold = true;
                                font2.FontHeightInPoints = 10;
                                font2.FontName = "Arial";
                                font2.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index;

                                ICellStyle AllCellStyle3 = WorkBook.CreateCellStyle();
                                AllCellStyle3.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

                                AllCellStyle3.BorderLeft = NPOI.SS.UserModel.BorderStyle.None;
                                AllCellStyle3.BorderRight = NPOI.SS.UserModel.BorderStyle.None;
                                AllCellStyle3.BorderTop = NPOI.SS.UserModel.BorderStyle.None;
                                AllCellStyle3.BorderBottom = NPOI.SS.UserModel.BorderStyle.None;
                                AllCellStyle3.SetFont(font2);
                                ICell Cell5 = HeaderRow.CreateCell(colIndex);
                                Cell5.SetCellValue(dc.ColumnName);
                                Cell5.CellStyle = AllCellStyle3;

                                break;

                            }

                            //Dim font As IFont = workBook.CreateFont()
                            //font.IsBold = True
                            //font.FontHeightInPoints = 10
                            //font.FontName = "Arial"
                            //font.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index

                            //    Dim AllCellStyle As ICellStyle = workBook.CreateCellStyle()
                            //AllCellStyle.Alignment = HorizontalAlignment.Center

                            //AllCellStyle.BorderLeft = BorderStyle.Thin
                            //AllCellStyle.BorderRight = BorderStyle.Thin
                            //AllCellStyle.BorderTop = BorderStyle.Thin
                            //AllCellStyle.BorderBottom = BorderStyle.Thin

                            //AllCellStyle.SetFont(font)

                            IFont font = WorkBook.CreateFont();
                            font.IsBold = true;
                            font.FontHeightInPoints = 10;
                            font.FontName = "Arial";
                            font.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index;


                            ICellStyle AllCellStyle = WorkBook.CreateCellStyle();
                            AllCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;


                            AllCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                            AllCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                            AllCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                            AllCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                            AllCellStyle.SetFont(font);

                            //Dim Cell As ICell = HeaderRow.CreateCell(colIndex)
                            //Cell.SetCellValue(dc.ColumnName)
                            //Cell.CellStyle = AllCellStyle

                            //  Dim AllCellStyle2 As ICellStyle = workBook.CreateCellStyle()
                            //  AllCellStyle2.SetFont(font)

                            //    colIndex = colIndex + 1

                            ICell Cell = HeaderRow.CreateCell(colIndex);
                            Cell.SetCellValue(dc.ColumnName);
                            Cell.CellStyle = AllCellStyle;

                            ICellStyle AllCellStyle2 = WorkBook.CreateCellStyle();
                            AllCellStyle2.SetFont(font);

                            colIndex = colIndex + 1;


                            

                           

                        }

                    }
                    else
                    {
                        colIndex = 0;
                        rowIndex = 0;


                        foreach (DataColumn dc in dt.Columns)
                        //foreach (dc in dt.Columns)
                        {

                            IFont font = WorkBook.CreateFont();
                            font.IsBold = true;
                            font.FontHeightInPoints = 10;
                            font.FontName = "Arial";
                            font.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index;
                            ICellStyle AllCellStyle = WorkBook.CreateCellStyle();
                            AllCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                            AllCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                            AllCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                            AllCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                            AllCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                            AllCellStyle.SetFont(font);
                            ICell Cell = HeaderRow.CreateCell(colIndex);
                            Cell.SetCellValue(dc.ColumnName);
                            Cell.CellStyle = AllCellStyle;

                            colIndex = colIndex + 1;

                            //ICellStyle AllCellStyle2 = WorkBook.CreateCellStyle();
                            //AllCellStyle2.SetFont(font);
                        }


                        //colIndex = colIndex + 1;

                    }






                    //    Dim borderedCellStyle As XSSFCellStyle = CType(workBook.CreateCellStyle(), XSSFCellStyle)
                    //Dim Sheetrowindex As Int64 = 2


                    //XSSFCellStyle borderedCellStyle = (XSSFCellStyle)WorkBook.CreateCellStyle();
                    
                    HSSFCellStyle borderedCellStyle = (HSSFCellStyle)WorkBook.CreateCellStyle();

                    Int32 Sheetrowindex = 2;


                    IFont font31 = WorkBook.CreateFont();
                    font31.FontHeightInPoints = 10;
                    font31.FontName = "Arial";

                    ICellStyle AllCellStyle31 = WorkBook.CreateCellStyle();

                    AllCellStyle31.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    AllCellStyle31.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle31.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle31.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle31.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                    AllCellStyle31.WrapText = true;

                    AllCellStyle31.SetFont(font31);

                    ICreationHelper creationHelper31 = WorkBook.GetCreationHelper();

                    IDataFormat DataFormat31 = WorkBook.CreateDataFormat();

                    ICellStyle SecondStyle31 = WorkBook.CreateCellStyle();

                    SecondStyle31.SetFont(font31);



                    IFont font32 = WorkBook.CreateFont();
                    font32.FontHeightInPoints = 10;
                    font32.FontName = "Arial";

                    ICellStyle AllCellStyle32 = WorkBook.CreateCellStyle();

                    AllCellStyle32.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    AllCellStyle32.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle32.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle32.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle32.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                    AllCellStyle32.WrapText = true;

                    AllCellStyle32.SetFont(font32);

                    ICreationHelper creationHelper32 = WorkBook.GetCreationHelper();

                    IDataFormat DataFormat32 = WorkBook.CreateDataFormat();

                    ICellStyle SecondStyle32 = WorkBook.CreateCellStyle();

                    SecondStyle32.SetFont(font32);

                  

                    if (tbTimeAndExp.SelectedTab.Text == "Time")
                    {
                        //For ManagerRowindex As Integer = 1 To grdTimeAndExp.Rows.Count

                        for (int ManagerRowindex = 1; ManagerRowindex <= grdTimeAndExp.Rows.Count; ManagerRowindex++)
                        {


                            //createManagerRows(dt, borderedCellStyle, (ManagerRowindex - 1), Sheetrowindex, sheet1, AllCellStyle, creationHelper, DataFormat, SecondStyle)


                            //private object CreateTimeExpesneRowForSeconDExport(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)

                            //private object CreateTimeExpesneRowForSeconDExport(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, XSSFCellStyle AllCellStyle, ICreationHelper ICH, IDataFormat IDF, ICellStyle SecondCS)

                            CreateTimeExpesneRowForSeconDExport(dt, borderedCellStyle, (ManagerRowindex - 1), ref Sheetrowindex, ref Sheet1, AllCellStyle31, creationHelper31, DataFormat31, SecondStyle31);

                            //ManagerRowindex = ManagerRowindex + 1;

                        }
                    }
                    else
                    {
                        //For ManagerRowindex As Integer = 1 To dt.Rows.Count

                        for (int ManagerRowindex = 1; ManagerRowindex <= dt.Rows.Count; ManagerRowindex++)
                        {

                          

                            //private object CreateExpenseRow(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle AllCellStyle, ICreationHelper ICH, IDataFormat IDF, ICellStyle SecondCS)


                            //CreateExpenseRow(dt, borderedCellStyle, (ManagerRowindex - 1), ref Sheetrowindex, ref Sheet1, AllCellStyle, creationHelper, DataFormat, SecondStyle);

                            CreateExpenseRow(dt, borderedCellStyle, (ManagerRowindex - 1), ref Sheetrowindex, ref Sheet1, AllCellStyle32, creationHelper32, DataFormat32, SecondStyle32);

                        }
                    }
                    //    Dim fsd = New FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)


                    //workBook.Write(fsd)
                    //workBook.Close()
                    //fsd.Close()
                    //MessageBox.Show("Export Successfully ", Export.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)


                    //If tbTimeAndExp.SelectedTab.Text = "Time" Then

                    if (tbTimeAndExp.SelectedTab.Text == "Time")
                    {

                        //Dim filter As String = lblTotalHours.Text.ToString()
                        //Dim filterRemove() As String = filter.Split(":")
                        //Dim totalhours As Double = filterRemove(1)


                        string Filter = lblTotalHours.Text.ToString();
                        //string[] filterRemove = Filter.Split(":");


                        string[] filterRemove = Filter.Split(':');

                        //string authors = "Mahesh Chand, Henry He, Chris Love, Raj Beniwal, Praveen Kumar";
                        //// Split authors separated by a comma followed by space  
                        //string[] authorsList = authors.Split(", ");

                        double totalhours = Convert.ToDouble(filterRemove[1]);                        

                        rowIndex = rowIndex + 4;

                        IFont Allfont = WorkBook.CreateFont();
                        Allfont.FontHeightInPoints = 10;
                        Allfont.FontName = "Arial";

                        ICellStyle AllCellStyle = WorkBook.CreateCellStyle();
                        AllCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        AllCellStyle.SetFont(Allfont);
                        

                        int Rindex = dt.Rows.Count + 3;
                        IRow LastRow = Sheet1.CreateRow(Rindex);
                        ICell Cell5 = LastRow.CreateCell(4);
                        Cell5.SetCellValue(TotalHolidayHours.Text.ToString());

                        ICell Cell6 = LastRow.CreateCell(5);
                        Cell6.SetCellValue(lblHoliday.Text.ToString());

                        ICell Cell7 = LastRow.CreateCell(6);
                        Cell7.SetCellValue(lblSickTime.Text.ToString());

                        ICell Cell8 = LastRow.CreateCell(7);
                        Cell8.SetCellValue(lblVacationTime.Text.ToString());

                        ICell Cell9 = LastRow.CreateCell(8);
                        Cell9.SetCellValue("Total Hours:  " + totalhours.ToString("F2"));


                        //Dim Cell6 As ICell = LastRow.CreateCell(5)
                        //Cell6.SetCellValue(lblHoliday.Text.ToString())

                        //Dim Cell7 As ICell = LastRow.CreateCell(6)
                        //Cell7.SetCellValue(lblSickTime.Text.ToString())

                        //Dim Cell8 As ICell = LastRow.CreateCell(7)
                        //Cell8.SetCellValue(lblVacationTime.Text.ToString())

                        //Dim Cell9 As ICell = LastRow.CreateCell(8)
                        //Cell9.SetCellValue("Total Hours:  " + totalhours.ToString("F2"))


                    }

                    else 
                    {
                        //int Rindex = dt.Rows.Count + 3;
                        //IRow LastRow = Sheet1.CreateRow(Rindex);
                        //ICell Cell5 = LastRow.CreateCell(4);
                        //Cell5.SetCellValue(TotalHolidayHours.Text.ToString());


                        String Filter = lblTotalAmount.Text.ToString();
                        String[] FilterRemove = Filter.Split('$');
                        Double TotalTime = Convert.ToDouble(FilterRemove[1]);
                        
                        rowIndex = rowIndex + 4;
                        int Rindex = dt.Rows.Count + 3;
                        IRow LastRow = Sheet1.CreateRow(Rindex);
                        ICell Cell5 = LastRow.CreateCell(5);
                        Cell5.SetCellValue("Total Amount $ " + TotalTime.ToString());

                        //    Dim filter As String = lblTotalAmount.Text.ToString()
                        //Dim filterRemove() As String = filter.Split("$")
                        //Dim TotalTime As Double = filterRemove(1)
                        //rowIndex = rowIndex + 4
                        //Dim Rindex As Integer = dt.Rows.Count + 3

                        //Dim LastRow As IRow = sheet1.CreateRow(Rindex)

                        //Dim Cell5 As ICell = LastRow.CreateCell(5)
                        //Cell5.SetCellValue("Total Amount $ " + TotalTime.ToString())
                    }





                    if (flage == true)
                    {

                        // Set row number
                        int startRow = 0;
                        int endRow = 0;

                        // Set column number
                        int startColumn = 0;
                        int endColumn = 9;

                        IFont font = WorkBook.CreateFont();
                        font.IsBold = true;
                        font.FontHeightInPoints = 10;
                        font.FontName = "Arial";
                        font.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index;

                        ICellStyle AllCellStyle = WorkBook.CreateCellStyle();
                        AllCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                        AllCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                        AllCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                        AllCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                        AllCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                        AllCellStyle.SetFont(font);
                        //ICell Cell = HeaderRow.CreateCell(colIndex);
                        
                        //ICellStyle AllCellStyle2 = WorkBook.CreateCellStyle();
                        //AllCellStyle2.SetFont(font);



                        

                        string Value = cmbUserSearch.Text.ToString() + " " + "Expenses";


                        var sheetRow5 = Sheet1.CreateRow(0);

                        ICell IC = sheetRow5.CreateCell (startColumn);
                        IC.SetCellValue(Value);
                        IC.CellStyle = AllCellStyle;



                        ICell Cel2 = sheetRow5.CreateCell(1);
                        ICell Cel3 = sheetRow5.CreateCell(2);
                        ICell Cel4 = sheetRow5.CreateCell(3);
                        ICell Cel5 = sheetRow5.CreateCell(4);
                        ICell Cel6 = sheetRow5.CreateCell(5);
                        ICell Cel7 = sheetRow5.CreateCell(6);
                        ICell Cel8 = sheetRow5.CreateCell(7);
                        ICell Cel9 = sheetRow5.CreateCell(8);
                        //ICell Cell0 = sheetRow5.CreateCell(9);

                        Sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(startRow, endRow, startColumn, endColumn));

                        IC.CellStyle = AllCellStyle;

                        Cel2.CellStyle = AllCellStyle;
                        Cel3.CellStyle = AllCellStyle;
                        Cel4.CellStyle = AllCellStyle;
                        Cel5.CellStyle = AllCellStyle;
                        Cel6.CellStyle = AllCellStyle;
                        Cel7.CellStyle = AllCellStyle;
                        Cel8.CellStyle = AllCellStyle;
                        Cel9.CellStyle = AllCellStyle;
                        //Cell0.CellStyle = AllCellStyle;


                        //sheetRow5.CreateCell(startColumn).SetCellValue(Value);

                        //Cell.SetCellValue(dc.ColumnName);
                        //Cell.CellStyle = AllCellStyle;


                    }
                    else
                    {

                        int startRow2 = 0;
                        int endRow2 = 0;

                        // Set column number
                        int startColumn2 = 0;
                        int endColumn2 = 9;

                        
                        string Value = cmbUserSearch.Text.ToString() + " " + "Time";

                        //XSSFFont myFont2 = (XSSFFont)WorkBook.CreateFont();

                        HSSFFont myFont2 = (HSSFFont)WorkBook.CreateFont();
                         

                        myFont2.FontHeightInPoints = 11;
                        myFont2.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index;
                        myFont2.IsBold = true;
                                               

                        IFont font = WorkBook.CreateFont();
                        font.IsBold = true;
                        font.FontHeightInPoints = 12;
                        font.FontName = "Arial";
                        
                        ICellStyle boldtsyle = WorkBook.CreateCellStyle();
                        boldtsyle.SetFont(font);
                        
                        boldtsyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

                        boldtsyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                        boldtsyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                        boldtsyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                        boldtsyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;


                        IRow row = Sheet1.CreateRow(0);
                        ICell Cell = row.CreateCell(0);
                        Cell.SetCellValue(Value);

                        ICell Cel2 = row.CreateCell(1);
                        ICell Cel3 = row.CreateCell(2);
                        ICell Cel4 = row.CreateCell(3);
                        ICell Cel5 = row.CreateCell(4);
                        ICell Cel6 = row.CreateCell(5);
                        ICell Cel7 = row.CreateCell(6);
                        ICell Cel8 = row.CreateCell(7);
                        ICell Cel9 = row.CreateCell(8);
                        ICell Cell0 = row.CreateCell(9);

                        Sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(startRow2, endRow2, startColumn2, endColumn2));

                        Cell.CellStyle = boldtsyle;

                        Cel2.CellStyle = boldtsyle;
                        Cel3.CellStyle = boldtsyle;
                        Cel4.CellStyle = boldtsyle;
                        Cel5.CellStyle = boldtsyle;
                        Cel6.CellStyle = boldtsyle;
                        Cel7.CellStyle = boldtsyle;
                        Cel8.CellStyle = boldtsyle;
                        Cel9.CellStyle = boldtsyle;
                        Cell0.CellStyle = boldtsyle;



                        //ICellStyle Bs = WorkBook.CreateCellStyle();

                        //Bs.BorderLeft = NPOI.SS.UserModel.BorderStyle.Double;
                        //Bs.BorderRight = NPOI.SS.UserModel.BorderStyle.Double;
                        //Bs.BorderTop = NPOI.SS.UserModel.BorderStyle.Double;
                        //Bs.BorderBottom = NPOI.SS.UserModel.BorderStyle.Double;


                        //IRow row = Sheet1.CreateRow(0);
                        ////ICell Cell = row.CreateCell(0);
                        ////Cell.SetCellValue(Value);

                        //for (int i = 1; i <= 5; ++i)
                        //{

                        //    ICell C1 = row.CreateCell(i);
                        //    C1.CellStyle = Bs;
                        //    //Cell cell = row.createCell(i);
                        //    //cell.setCellStyle(borderStyle);
                        //    if (i == 1)
                        //    {
                        //        //cell.setCellValue("Centred Text");
                        //        C1.SetCellValue(Value);
                        //    }
                        //}

                        //Sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(startRow2, endRow2, startColumn2, 15));



                    }
                    int x, z;

                    int lastColumNum = Sheet1.GetRow(1).LastCellNum;

                    //int lastColumNum = Sheet1.GetRow(0).LastCellNum;

                    for (z = 1; z <= lastColumNum; z++)
                    {
                        Sheet1.AutoSizeColumn(z);

                        // xlSheet.Range("A1:X1").EntireColumn.AutoFit()
                        GC.Collect();
                    }

                    if (Sheet1.PhysicalNumberOfRows > 0)
                    {

                        IRow Last = Sheet1.GetRow(0);

                        int z2;


                        for (z2 = 0; z2 <= HeaderRow.LastCellNum; z2++)
                        {
                            Sheet1.AutoSizeColumn(z2);
                            // xlSheet.Range("A1:X1").EntireColumn.AutoFit()
                            GC.Collect();
                        }
                    }

                    FileStream fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    WorkBook.Write(fsd);
                    WorkBook.Close();
                    fsd.Close();
                    //MessageBox.Show("done");
                    MessageBox.Show("Export Successfully ", ExportTimeExpense.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);



                }
                else
                {
                    //Dim choiceButton As DialogResult = KryptonMessageBox.Show("Record is Null ", "TimeAndExpenses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    DialogResult ChoiceButton = MessageBox.Show("Record is Null ", "TimeAndExpenses", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

          private void btnExportexcelSheet_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                ExportTimeExpensesToExcel();
                
                //Excel.Application excel = new Excel.Application();
                //Excel.Workbook wBook = null;
                //Excel.Worksheet wSheet = null;
                //wBook = excel.Workbooks.Add();
                //wSheet = (Excel.Worksheet)wBook.Sheets[1];

                //// excel sheet landscape
                //wSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                ////set margin  page
                //wSheet.PageSetup.LeftMargin = 0.75;
                //wSheet.PageSetup.RightMargin = 0.75;
                //wSheet.PageSetup.TopMargin = 0.75;
                //wSheet.PageSetup.BottomMargin = 0.75;
                //wSheet.PageSetup.HeaderMargin = 0.75;
                //wSheet.PageSetup.FooterMargin = 0.75;

                ////set page sclliang
                //wSheet.PageSetup.Zoom = 80;
                //wSheet.PageSetup.FitToPagesTall = 1;
                //wSheet.PageSetup.FitToPagesWide = 1;

                //System.Data.DataTable dt = new System.Data.DataTable();
                //bool flage = false;
                //DataTable DtHideColumngridView = new DataTable();
                //if (tbTimeAndExp.SelectedTab.Text == "Time")
                //{
                //    DtHideColumngridView = dtTimeExportExcelSheet;
                //    DtHideColumngridView.Columns.Add("Punch Hrs");
                //    //change header name
                //    DtHideColumngridView.Columns.Remove("TimeSheetID");
                //    DtHideColumngridView.Columns["status"].ColumnName = "Status";
                //    DtHideColumngridView.Columns["Job_Number"].ColumnName = "Job#";
                //    DtHideColumngridView.Columns["TrackSubName"].ColumnName = "TrackSub Comment";
                //    DtHideColumngridView.Columns["BillState"].ColumnName = "Bill State";
                //    DtHideColumngridView.Columns["AdminStatus"].ColumnName = "Admin Status";
                //    DtHideColumngridView.Columns["Name"].ColumnName = "PM";
                //    // Add new Column
                //    DtHideColumngridView.Columns["Time"].ColumnName = "Submit Hrs";
                //    //set display index
                //    DtHideColumngridView.Columns["Job#"].SetOrdinal(1);
                //    DtHideColumngridView.Columns["Date"].SetOrdinal(2);
                //    DtHideColumngridView.Columns["PM"].SetOrdinal(3);
                //    DtHideColumngridView.Columns["Status"].SetOrdinal(4);
                //    DtHideColumngridView.Columns["Submit Hrs"].SetOrdinal(5);
                //    DtHideColumngridView.Columns["Punch Hrs"].SetOrdinal(6);
                //    DtHideColumngridView.Columns["Bill State"].SetOrdinal(7);
                //    DtHideColumngridView.Columns["TrackSub Comment"].SetOrdinal(8);
                //    DtHideColumngridView.Columns["Description"].SetOrdinal(9);
                //    DtHideColumngridView.Columns["Admin Status"].SetOrdinal(10);
                //}
                //else
                //{
                //    DtHideColumngridView = dtExpensesExportExcelSheet;

                //    DtHideColumngridView.Columns.Remove("TimeSheetExpencesID");
                //    DtHideColumngridView.Columns["status"].ColumnName = "Status";
                //    DtHideColumngridView.Columns["Job Number"].ColumnName = "Job#";
                //    DtHideColumngridView.Columns["Name"].ColumnName = "PM";
                //    DtHideColumngridView.Columns["Expences"].ColumnName = "Amount ";
                //    DtHideColumngridView.Columns["TrackSubName"].ColumnName = "TrackSub Comment";
                //    DtHideColumngridView.Columns["BillState"].ColumnName = "Bill State";
                //    DtHideColumngridView.Columns["AdminStatus"].ColumnName = "Admin Status";
                //    flage = true;
                //}

                //DtHideColumngridView.Columns.Remove("JobListID");
                //DtHideColumngridView.Columns.Remove("EmployeeDetailsId");
                //DtHideColumngridView.Columns.Remove("Comment");
                //DtHideColumngridView.Columns.Remove("TrackSubID");

                //dt = DtHideColumngridView;

                //if (dt.Rows.Count > 0)
                //{

                //    int colIndex = 0;
                //    int rowIndex = 0;
                //    foreach (System.Data.DataColumn dc in dt.Columns)
                //    {
                //        colIndex = colIndex + 1;
                //        excel.Cells[2, colIndex] = dc.ColumnName;
                //    }
                //    wSheet.Columns.Range["A2:k2"].Font.Bold = true;


                //    wSheet.Columns.Range["A2:k2"].Font.Color = Color.RoyalBlue;
                //    foreach (System.Data.DataRow dr in dt.Rows)
                //    {
                //        rowIndex = rowIndex + 1;
                //        colIndex = 0;
                //        foreach (System.Data.DataColumn dc in dt.Columns)
                //        {
                //            colIndex = colIndex + 1;
                //            excel.Cells[rowIndex + 2, colIndex] = dr[dc.ColumnName];

                //        }
                //    }

                //    int setBorderRowIndex = 0; //Set heare row index
                //    setBorderRowIndex = rowIndex;

                //    if (tbTimeAndExp.SelectedTab.Text == "Time")
                //    {
                //        string filter = lblTotalHours.Text.ToString();
                //        string[] filterRemove = filter.Split(':');
                //        double totalhours = Convert.ToDouble(filterRemove[1]);

                //        rowIndex = rowIndex + 4;

                //        excel.Cells[rowIndex, 5] = TotalHolidayHours.Text.ToString(); //Ragular Hours
                //        excel.Cells[rowIndex, 6] = lblHoliday.Text.ToString(); //"Holiday "
                //        excel.Cells[rowIndex, 7] = lblSickTime.Text.ToString(); //"Sick Time" +
                //        excel.Cells[rowIndex, 8] = lblVacationTime.Text.ToString(); //Vacation Time " +
                //        excel.Cells[rowIndex, 9] = "Total Hours:  " + totalhours.ToString("F2");
                //    }
                //    else
                //    {
                //        string filter = lblTotalAmount.Text.ToString();
                //        string[] filterRemove = filter.Split('$');
                //        double TotalTime = Convert.ToDouble(filterRemove[1]);

                //        rowIndex = rowIndex + 4;
                //        excel.Cells[rowIndex, 6] = "Total Amount $ " + TotalTime.ToString("F2");
                //    }

                //    wSheet.Columns.AutoFit();

                //    if (tbTimeAndExp.SelectedTab.Text == "Time")
                //    {
                //        // ("A1:J2")
                //        wSheet.Range["A1:J2"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin; //Fist header
                //        wSheet.Range["A1:J1"].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A1:J1"].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A1:J1"].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;

                //        wSheet.Range["A2:J2"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin; //seccount row
                //        wSheet.Range["A2:J2"].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A2:J2"].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A2:J2"].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A2:J2"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;
                //        int CloumnRng = setBorderRowIndex + 2; //set border in excel sheet
                //        string rngA = null;
                //        string rngB = null;
                //        string rngC = null;
                //        string rngD = null;
                //        string rngE = null;
                //        string rngF = null;
                //        string rngG = null;
                //        string rngH = null;
                //        string rngI = null;
                //        string rngJ = null;
                //        rngA = "A2:A" + CloumnRng;
                //        rngB = "B2:B" + CloumnRng;
                //        rngC = "C2:C" + CloumnRng;
                //        rngD = "D2:D" + CloumnRng;
                //        rngE = "E2:E" + CloumnRng;
                //        rngF = "F2:F" + CloumnRng;
                //        rngG = "G2:G" + CloumnRng;
                //        rngH = "H2:H" + CloumnRng;
                //        rngI = "I2:I" + CloumnRng;
                //        rngJ = "J2:J" + CloumnRng;

                //        //Set Left Border
                //        wSheet.Range[rngA].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngB].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngC].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngD].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngE].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngF].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngG].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngH].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngI].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngJ].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;

                //        //set Bottom Border
                //        int CountColumn = 3;

                //        int tempVar = CloumnRng - 3;
                //        for (int ClmRow = 0; ClmRow <= tempVar; ClmRow++)
                //        {
                //            string strColumnrang = "A" + CountColumn.ToString() + ":J" + CountColumn.ToString();
                //            wSheet.Range[strColumnrang].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
                //            CountColumn = CountColumn + 1;
                //        }

                //        //Set last Right left Both Column
                //        wSheet.Range[rngJ].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin; //Lef Right Both Last Column

                //    }
                //    else
                //    {
                //        // ("A1:I2") Range
                //        wSheet.Range["A1:I2"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin; //Fist header
                //        wSheet.Range["A1:I1"].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A1:I1"].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A1:I1"].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;

                //        wSheet.Range["A2:I2"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin; //seccount row
                //        wSheet.Range["A2:I2"].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A2:I2"].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A2:I2"].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range["A2:I2"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;
                //        int CloumnRng = setBorderRowIndex + 2; //set border in excel sheet
                //        string rngA = null;
                //        string rngB = null;
                //        string rngC = null;
                //        string rngD = null;
                //        string rngE = null;
                //        string rngF = null;
                //        string rngG = null;
                //        string rngH = null;
                //        string rngI = null;


                //        rngA = "A2:A" + CloumnRng;
                //        rngB = "B2:B" + CloumnRng;
                //        rngC = "C2:C" + CloumnRng;
                //        rngD = "D2:D" + CloumnRng;
                //        rngE = "E2:E" + CloumnRng;
                //        rngF = "F2:F" + CloumnRng;
                //        rngG = "G2:G" + CloumnRng;
                //        rngH = "H2:H" + CloumnRng;
                //        rngI = "I2:I" + CloumnRng;

                //        //Set Left Border
                //        wSheet.Range[rngA].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngB].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngC].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngD].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngE].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngF].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngG].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngH].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //        wSheet.Range[rngI].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;

                //        //set Bottom Border
                //        int CountColumnExpenses = 3;

                //        int tempVar = CloumnRng - 3;
                //        for (int ClmRow = 0; ClmRow <= tempVar; ClmRow++)
                //        {
                //            string strColumnrang = "A" + CountColumnExpenses.ToString() + ":I" + CountColumnExpenses.ToString();
                //            wSheet.Range[strColumnrang].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
                //            CountColumnExpenses = CountColumnExpenses + 1;
                //        }

                //        //Set last Right left Both Column
                //        wSheet.Range[rngI].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin; //Lef Right Both Last Column

                //    }


                //    if (flage == true) //for expenses header marge()
                //    {
                //        wSheet.Range["A1:I1"].Merge();
                //        wSheet.Range["A1:I1"].Value = cmbUserSearch.Text.ToString() + " " + "Expenses";
                //    }
                //    else
                //    {
                //        wSheet.Range["A1:J1"].Merge();
                //        wSheet.Range["A1:J1"].Value = cmbUserSearch.Text.ToString() + " " + "Time";
                //    }

                //    wSheet.Range["A1:J1"].Font.Size = 12;
                //    wSheet.Range["A1:J1"].Font.Bold = true;
                //    wSheet.Range["A1:J1"].HorizontalAlignment = Alignment.Center;

                //    wSheet.Columns[1].ColumnWidth = 11;
                //    wSheet.Columns[2].ColumnWidth = 11;
                //    wSheet.Columns[3].ColumnWidth = 3;
                //    wSheet.Columns[4].ColumnWidth = 11;
                //    wSheet.Columns[5].ColumnWidth = 11;
                //    wSheet.Columns[7].ColumnWidth = 11;

                //    if (flage == true) //For Expenses
                //    {
                //        wSheet.Columns[9].ColumnWidth = 12;
                //        wSheet.Columns[6].ColumnWidth = 40;
                //        wSheet.Columns[8].ColumnWidth = 40;
                //        wSheet.Range["H2"].EntireColumn.WrapText = true;
                //        wSheet.Range["F2"].EntireColumn.WrapText = true;

                //        wSheet.Range["G2"].EntireColumn.NumberFormat = "$ #,##0.00"; // For Amount
                //        wSheet.Range["F2"].HorizontalAlignment = Alignment.Center; //FOR tRACKER SUB 16
                //        wSheet.Range["H2"].HorizontalAlignment = Alignment.Center; //FOR DECRIPTION 12
                //        wSheet.Range["I2"].HorizontalAlignment = Alignment.Center; //FOR ADDMIN STATUS
                //        wSheet.Range["B2"].HorizontalAlignment = Alignment.Center; //FOR DATE
                //        wSheet.Range["C2"].HorizontalAlignment = Alignment.Center; //FOR PM
                //        wSheet.Range["E2"].HorizontalAlignment = Alignment.Center; //FOR Bill State
                //        wSheet.Range["G2"].HorizontalAlignment = Alignment.Center; //FOR Amount

                //        //For Column Value in Center
                //        wSheet.Columns[3].HorizontalAlignment = Alignment.Center; //PM
                //        wSheet.Columns[7].HorizontalAlignment = Alignment.Center; //Amount
                //        wSheet.Columns[1].HorizontalAlignment = Alignment.Center; //Job#
                //        wSheet.Columns[9].HorizontalAlignment = Alignment.Center; //Admin St
                //        wSheet.Columns[4].HorizontalAlignment = Alignment.Center; //Status
                //        wSheet.Columns[2].HorizontalAlignment = Alignment.Center; //Date


                //    }
                //    else //For Time 7
                //    {
                //        wSheet.Columns[6].ColumnWidth = 11;
                //        wSheet.Columns[10].ColumnWidth = 12;
                //        wSheet.Columns[9].ColumnWidth = 40;
                //        wSheet.Columns[8].ColumnWidth = 40;
                //        wSheet.Range["H2"].EntireColumn.WrapText = true;
                //        wSheet.Range["I2"].EntireColumn.WrapText = true;

                //        wSheet.Range["G2"].HorizontalAlignment = Alignment.Center; //FOR tRACKER SUB
                //        wSheet.Range["H2"].HorizontalAlignment = Alignment.Center; //FOR DECRIPTION
                //        wSheet.Range["I2"].HorizontalAlignment = Alignment.Center; //FOR ADMIN STATUS
                //        wSheet.Range["B2"].HorizontalAlignment = Alignment.Center; //FOR DATE
                //        wSheet.Range["C2"].HorizontalAlignment = Alignment.Center; //FOR PM
                //        wSheet.Range["E2"].HorizontalAlignment = Alignment.Center; //FOR Time
                //        wSheet.Range["F2"].HorizontalAlignment = Alignment.Center; //FOR Bill Status

                //        //For Column Value in Center
                //        wSheet.Columns[5].HorizontalAlignment = Alignment.Center; //Time
                //        wSheet.Columns[3].HorizontalAlignment = Alignment.Center; //PM
                //        wSheet.Columns[1].HorizontalAlignment = Alignment.Center; //Job#
                //        wSheet.Columns[10].HorizontalAlignment = Alignment.Center; //Admin St
                //        wSheet.Columns[4].HorizontalAlignment = Alignment.Center; //Status
                //        wSheet.Columns[2].HorizontalAlignment = Alignment.Center; //Date
                //    }

                //    SaveFileDialog Export = new SaveFileDialog();
                //    Export.Filter = "Excel Format|*.xls";
                //    Export.Title = "Export TimeSheetAndExpenses";

                //    Export.InitialDirectory = "N:";

                //    if (Export.ShowDialog() == DialogResult.Cancel)
                //    {
                //        return;
                //    }
                //    //Dim TimeSheetId As Guid = System.Guid.NewGuid()
                //    string strFileName = Export.FileName; // "TimeAndExpenses" & TimeSheetId.ToString() '
                //    bool blnFileOpen = false;
                //    try
                //    {
                //        System.IO.FileStream fileTemp = System.IO.File.OpenWrite(strFileName);
                //        fileTemp.Close();
                //    }
                //    catch (Exception ex)
                //    {
                //        blnFileOpen = false;
                //    }

                //    if (System.IO.File.Exists(strFileName))
                //    {
                //        System.IO.File.Delete(strFileName);
                //    }
                //    wBook.SaveAs(strFileName);
                //    excel.Workbooks.Open(strFileName);
                //    excel.Visible = true;
                //}
                //else
                //{
                //    //KryptonMessageBox.Show("Record is Null ", "TimeAndExpenses")
                //    DialogResult choiceButton = KryptonMessageBox.Show("Record is Null ", "TimeAndExpenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
            fillTimeSheet();
            fillExpences();
        }
        internal enum Alignment
        {
            Center = 3,
            LeftAlign = 2,
            RighiAlign = 4

        }
        private void btnPunchHousvsJT_Click(System.Object sender, System.EventArgs e)
        {
            //try
            //{

            //    string UserName = cmbUserSearch.Text;
            //    if (string.IsNullOrEmpty(UserName))
            //    {
            //        KryptonMessageBox.Show("Select User", "User Name");
            //    }
            //    else
            //    {
            //        frmPCHoursVSJTHours frmPCVsJT = new frmPCHoursVSJTHours();
            //        int userID = Convert.ToInt32( cmbUserSearch.SelectedValue);
            //        if (ckbTime.Checked == true)
            //        {
            //            frmPCVsJT.ShowDate = true;
            //        }
            //        else
            //        {
            //            frmPCVsJT.ShowDate = false;
            //        }
            //        frmPCVsJT.EmployeID = userID;
            //        frmPCVsJT.FromDate = dtpDateSearchFrom.Value;
            //        frmPCVsJT.ToDATE = dtpDateSearchTo.Value;
            //        frmPCVsJT.UserName = UserName;
            //        frmPCVsJT.Show();
            //    }

            //}
            //catch (Exception ex)
            //{

            //}


        }
        private void btnTotal_Click(System.Object sender, System.EventArgs e)
        {
            frmShowTimeExpanseData frmshowTimeExpance = new frmShowTimeExpanseData();
            frmshowTimeExpance.Dock = DockStyle.Fill;
            frmshowTimeExpance.TopLevel = false;
            frmshowTimeExpance.Visible = true;
            pnlShowTotalData.Visible = true;
            pnlShowTotalData.BringToFront();
            pnlShowTotalData.Controls.Add(frmshowTimeExpance);
            frmshowTimeExpance.JobNumber = this.txtJobNumber.Text;
            frmshowTimeExpance.UserSearch = this.cmbUserSearch.Text;
            frmshowTimeExpance.Status = this.cmbStatus.Text;
            frmshowTimeExpance.AdminStatus = this.cmbAdminStatus.Text;
            frmshowTimeExpance.BillStatus = this.cmbBillStatus.Text;
            frmshowTimeExpance.ckbTime = ckbTime.Checked;
            frmshowTimeExpance.dtpDateSearchTo = dtpDateSearchTo.Value;
            frmshowTimeExpance.dtpSearchFrom = dtpDateSearchFrom.Value;
            frmshowTimeExpance.fillgrdTimeSheetData();
            frmshowTimeExpance.BringToFront();
        }
        private void pnlShowTotalData_ControlRemoved(System.Object sender, System.Windows.Forms.ControlEventArgs e)
        {
            controlVisibility(false);
        }
        private void controlVisibility(bool flag)
        {
            pnlShowTotalData.Visible = flag;
            btnTotal.Enabled = !flag;
        }
        private void grdJobList_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (grdJobList.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString1)
            {
                if (grdJobList.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Yellow)
                {

                }
                else
                {
                    grdJobList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    grdJobList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                }

                CheckString1 = string.Empty;
            }

        }
        private void grdTimeAndExp_RowsAdded(System.Object sender, DataGridViewColumnEventArgs e)
        {
            //'Add button
            if ((grdTimeAndExp.Columns["TimeItemNameBILLSTATE"] == null))
            {
                return;
            }
            Rectangle columnLocation = grdTimeAndExp.GetColumnDisplayRectangle(grdTimeAndExp.Columns["TimeItemNameBILLSTATE"].Index, true);
            Button button =(Button) grdTimeAndExp.Controls.Find("btnBillStatusChange", true).ToArray()[0];
            if (e is DataGridViewRowsAddedEventArgs || grdTimeAndExp.Rows.Count > 0)
            {
                button.Visible = true;
            }
            button.Location = new Point(columnLocation.Location.X + columnLocation.Width - 17, columnLocation.Location.Y + 7);
        }
        private void tbTimeAndExp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //'Add button
            if ((grdTimeAndExp.Columns["TimeItemNameBILLSTATE"] == null))
            {
                return;
            }
            Rectangle columnLocation = grdTimeAndExp.GetColumnDisplayRectangle(grdTimeAndExp.Columns["TimeItemNameBILLSTATE"].Index, true);
            Button button = (Button)grdTimeAndExp.Controls.Find("btnBillStatusChange", true).ToArray()[0];
            if (e is DataGridViewRowsAddedEventArgs || grdTimeAndExp.Rows.Count > 0)
            {
                button.Visible = true;
            }
            button.Location = new Point(columnLocation.Location.X + columnLocation.Width - 17, columnLocation.Location.Y + 7);
        }
        private void grdExpenses_RowsAdded(System.Object sender, DataGridViewRowsAddedEventArgs e)
        {
            //'Add button
            if ((grdExpenses.Columns["ExpenseSheetItemNameBILLSTATE"] == null))
            {
                return;
            }
            Rectangle columnLocation = grdExpenses.GetColumnDisplayRectangle(grdExpenses.Columns["ExpenseSheetItemNameBILLSTATE"].Index, true);
            Button button =(Button) grdExpenses.Controls.Find("btnExpBillStatusChange", true).ToArray()[0];
            if (e is DataGridViewRowsAddedEventArgs || grdExpenses.Rows.Count > 0)
            {
                button.Visible = true;
            }
            button.Location = new Point(columnLocation.Location.X + columnLocation.Width - 17, columnLocation.Location.Y + 7);
        }
        private void billStatusButtonClick(System.Object sender, EventArgs e)
        {
            contextMenuBillState.Show((Control)sender, ((Button)sender).Location);
        }
        private void ShowTooTipOnColumnsButton(System.Object sender, EventArgs e)
        {
            tooltipTimeExp.Show("Mass Bill State Change Option.", (Control)sender);
        }
        //Login change event call
        private void OnLoginChangeEvent(object sender, EventArgs e)
        {
            Application.DoEvents();
            string strUserAndAdminType = Properties.Settings.Default.timeSheetLoginUserType;
            if (grdTimeAndExp.Columns != null)
            {
                grdTimeAndExp.Columns["AdminStatus"].ReadOnly = (strUserAndAdminType == "Admin") ? false : true;
                grdTimeAndExp.Refresh();
            }
            if (grdExpenses.Columns != null)
            {
                grdExpenses.Columns["AdminStatus"].ReadOnly = (strUserAndAdminType == "Admin") ? false : true;
                grdExpenses.Refresh();
            }

            if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
            {
                // pnlUSerLoginCombo.Visible = True
                btnSave.Visible = true;
                lblPM.Enabled = true;
                cmbUserSearch.Enabled = true;
            }
            else
            {
                cmbAdminMass.Visible = false;
                lbMassAdminStatusChange.Visible = false;
                lblMassStatuesChange.Visible = false;
                cmbMassStatusChange.Visible = false;
                btnChangeMASS.Visible = false;
            }
            Application.DoEvents();
        }
        private void contextMenuBillState_ItemClicked(System.Object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            DialogResult choice = MessageBox.Show("Sure about to change all records Bill State?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (DialogResult.No == choice)
            {
                return;
            }
            bool IsInvoiceClick = false;
            if (e.ClickedItem.Text == "Invoice")
            {
                IsInvoiceClick = true;
            }
            if (tbTimeAndExp.SelectedTab.Text == "Time")
            {
                ArrayList timesheetId = new ArrayList();
                for (int Row = 0; Row < grdTimeAndExp.Rows.Count; Row++)
                {
                    timesheetId.Add(grdTimeAndExp.Rows[Row].Cells["TimeSheetID"].Value);
                }
                string Query = string.Format("UPDATE TS_Time SET BillState=@BillState WHERE TimeSheetId IN ({0})", string.Join(",", timesheetId.ToArray()));
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@BillState", (IsInvoiceClick ? "Invoice" : "Not Invoice")));


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    if (StMethod.UpdateRecordNew(Query, param) > 0)
                    {
                        // MessageBox.Show("Change Status Time Sheet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    }

                }
                else
                {
                    if (StMethod.UpdateRecord(Query, param) > 0)
                    {
                        // MessageBox.Show("Change Status Time Sheet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    }

                }

                //if (StMethod.UpdateRecord(Query, param) > 0)
                //{
                //    MessageBox.Show("Change Status Time Sheet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}

                MessageBox.Show("Bill State change Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillTimeSheet();
            }
            else
            {
                ArrayList expSheetId = new ArrayList();
                for (int Row = 0; Row < grdExpenses.Rows.Count; Row++)
                {
                    expSheetId.Add(grdExpenses.Rows[Row].Cells["TimeSheetExpencesID"].Value);
                }
                //MessageBox.Show("4014");

                string Query = string.Format("UPDATE TS_Expences SET BillState=@BillState WHERE TimeSheetExpencesID IN ({0})", string.Join(",", expSheetId.ToArray()));
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@BillState", (IsInvoiceClick ? "Invoice" : "Not Invoice")));

                //if (StMethod.UpdateRecord(Query, param) > 0)
                //{
                //    //  MessageBox.Show("Change Status Expenses Seet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    if (StMethod.UpdateRecordNew(Query, param) > 0)
                    {
                        //  MessageBox.Show("Change Status Expenses Seet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    }


                }
                else
                {
                    if (StMethod.UpdateRecord(Query, param) > 0)
                    {
                        //  MessageBox.Show("Change Status Expenses Seet Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    }


                }


                MessageBox.Show("Bill State change Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillExpences();
            }
        }
        private void AddtimeANDExpense_FormClosed(System.Object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            Program.ofrmMain.LoginChange -= OnLoginChangeEvent;
        }
        private void DisbaledRowByAdmin(DataGridView grd)
        {
            if (Properties.Settings.Default.timeSheetLoginUserType != "Admin")
            {
                string[] _adminStatus = { "Approved", "Paid", "Rejected" };
                for (int index = 0; index < grd.Rows.Count; index++)
                {
                    string _status = grd.Rows[index].Cells["AdminStatus"].Value.ToString().Trim();
                    if (_adminStatus.Any((s) => s == _status))
                    {
                        grd.Rows[index].ReadOnly = true;
                    }
                }
            }
        }
        private void BtnExport_Click(System.Object sender, System.EventArgs e)
        {
            // Get All Time and expense main grid data as a Datatable
            DataTable TimeExpenseMainGrid = GetTimeAndExpenseData();

            //Export start

            if (TimeExpenseMainGrid.Rows.Count > 0)
            {
                ProgressBar1.Minimum = 0;
                ProgressBar1.Maximum = TimeExpenseMainGrid.Rows.Count;


                // MessageBox.Show("Progress 1");
                //Show popup for confrim 
                SaveFileDialog Export = new SaveFileDialog();

                if (TimeExpenseMainGrid.Rows.Count >= 65535)
                {
                    Export.Filter = "Excel Format|*.xlsx";
                }
                else
                {
                    Export.Filter = "Excel Format|*.xlsx";
                    //Export.Filter = "Excel Format|*.xls";
                }

                //Export.Filter = "Excel Format|*.xlsx";

                //MessageBox.Show("Progress 2");

                Export.Title = "Time/Expense Data";

                string SavePath = @"N:\";
              

                if (Directory.Exists(SavePath))
                {
                    Export.InitialDirectory = SavePath;

                }
                else
                {
                    Export.InitialDirectory = @"C:\";
                }


                //MessageBox.Show("Progress 3");

                //'Export.InitialDirectory = "N:"
                if (Export.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                //-----------------------------------------------
                //If user want to contiune then file export with Name 
                //string FullFilePath = Export.FileName;
                string filename = Path.GetFileName(Export.FileName);
                string filePath = Export.FileName;

                XSSFWorkbook workBook = new XSSFWorkbook();
                //HSSFWorkbook workBook = new HSSFWorkbook();
                ISheet sheet1 = workBook.CreateSheet(filename);

                //Progress bar visiible
                ProgressBar1.Visible = true;
                Label2.Visible = true;

                //--------------------------------------------------------

                //sheet cell Formatting
                //--------------------------------------------------------
                XSSFFont myFont = (XSSFFont)workBook.CreateFont();
                //HSSFFont myFont = (HSSFFont)workBook.CreateFont();
                myFont.FontHeightInPoints = 11;
                myFont.FontName = "Tahoma";
                myFont.IsBold = true;

                

                XSSFCellStyle borderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();
                //HSSFCellStyle borderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();

                borderedCellStyle.SetFont(myFont);

                borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                borderedCellStyle.VerticalAlignment = VerticalAlignment.Center;


               // MessageBox.Show("Progress 4");

                int Sheetrowindex = 0;
                int percent = 0;
                for (int TimeExpenseRowindex = 1; TimeExpenseRowindex <= TimeExpenseMainGrid.Rows.Count; TimeExpenseRowindex++)
                {
                    if (ProgressBar1.Value <= TimeExpenseMainGrid.Rows.Count)
                    {
                        createTimeExpenseRows(TimeExpenseMainGrid, borderedCellStyle, (TimeExpenseRowindex - 1),ref Sheetrowindex,ref sheet1);
                    }
                    percent = (ProgressBar1.Value / ProgressBar1.Maximum) * 100;
                    Label2.Text = percent + "%" + "Completed";
                    Label2.Refresh();
                    ProgressBar1.Value = ProgressBar1.Value + 1;
                    Sheetrowindex = Sheetrowindex + 1;
                }

                //MessageBox.Show("Progress 5");

                //Auto sized all the affected columns
                int lastColumNum = sheet1.GetRow(0).LastCellNum;
                for (int i = 0; i <= lastColumNum; i++)
                {
                    sheet1.AutoSizeColumn(i);
                    GC.Collect();
                }

                //MessageBox.Show("1");
                //MessageBox.Show(sheet1.LastRowNum.ToString());

                //if (sheet1.LastRowNum >= 65535)
                //{
                //    Export.Filter = "Excel Format|*.xlsx";
                //}
                //else
                //{
                //    Export.Filter = "Excel Format|*.xls";
                //}

                ////if (sheet1.PhysicalNumberOfRows >= 65535)
                ////{
                ////    Export.Filter = "Excel Format|*.xlsx";
                ////}
                ////else
                ////{
                ////    Export.Filter = "Excel Format|*.xls";
                ////}

                //if (Export.ShowDialog() == DialogResult.Cancel)
                //{
                //    return;
                //}

                //export to excel 
                var fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                //Dim fs = New FileStream(filename, IO.FileMode.OpenOrCreate, FileAccess.ReadWrite)
                workBook.Write(fsd);
                workBook.Close();
                fsd.Close();
                MessageBox.Show("Export Successfully ", Export.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProgressBar1.Value = 0;
                ProgressBar1.Visible = false;
                Label2.Visible = false;
            }
        }
        #endregion

        #region Methods
        private void init()
        {
            //'Time grid
            BillStateChangeButton.Name = "btnBillStatusChange";
            BillStateChangeButton.FlatStyle = FlatStyle.Flat;
            BillStateChangeButton.Text = "▼";
            grdTimeAndExp.Controls.Add(BillStateChangeButton);
            BillStateChangeButton.Visible = false;
            BillStateChangeButton.Width = 15;
            BillStateChangeButton.Height = 15;
            BillStateChangeButton.ContextMenuStrip = contextMenuBillState;
            BillStateChangeButton.Font = new Font("Calibri", 8);
            BillStateChangeButton.Click += billStatusButtonClick;
            BillStateChangeButton.MouseHover += ShowTooTipOnColumnsButton;
            //'Expense grid
            ExpBillStateButton.Name = "btnExpBillStatusChange";
            ExpBillStateButton.FlatStyle = FlatStyle.Flat;
            ExpBillStateButton.Text = "▼";
            grdExpenses.Controls.Add(ExpBillStateButton);
            ExpBillStateButton.Visible = false;
            ExpBillStateButton.Width = 15;
            ExpBillStateButton.Height = 15;
            ExpBillStateButton.ContextMenuStrip = contextMenuBillState;
            ExpBillStateButton.Font = new Font("Calibri", 8);
            ExpBillStateButton.Click += billStatusButtonClick;
            ExpBillStateButton.MouseHover += ShowTooTipOnColumnsButton;
        }
        private void ApplyTimeSheetPageLoadSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();
                string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                dir2 = dir2 + "\\JobTracker";
                myDoc.Load(dir2 + "\\VESoftwareSetting.xml");


                //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");


                txtJobListJobID.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Job"].InnerText;
                txtJobListclient.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Client"].InnerText;
                txtDescriptionSearchJob.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Description"].InnerText;
                cbxJobListPM.SelectedIndex = cbxJobListPM.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["PM"].InnerText.ToString());
                txtTown.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Town"].InnerText;
                txtJobListAddress.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchJob"]["Address"].InnerText;

                int value = 0;
                value = cmbUserSearch.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["User"].InnerText.ToString());
                if (Properties.Settings.Default.timeSheetLoginUserType.ToString() == "Admin")
                {                    
                    cmbUserSearch.SelectedIndex = value;
                }
                else
                {
                    if (Properties.Settings.Default.timeSheetLoginName == myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["User"].InnerText)
                    {
                        //cmbUserSearch.SelectedIndex = cmbUserSearch.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["User"].InnerText.ToString());
                        cmbUserSearch.SelectedIndex = value;
                    }
                    else
                    {
                        cmbUserSearch.SelectedIndex = -1;
                    }
                }


                txtJobNumber.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["Job"].InnerText;
                cmbStatus.SelectedIndex = cmbStatus.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["Status"].InnerText.ToString());
                cmbBillStatus.SelectedIndex = cmbBillStatus.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["BillStatus"].InnerText.ToString().ToString());
                cmbAdminStatus.SelectedIndex = cmbAdminStatus.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TimeSheet"]["SearchUser"]["AdminStatus"].InnerText.ToString());
            }
            catch (Exception ex)
            {

            }

        }
        private void Fillcombo()
        {
            DataTable dt= null;
            try
            {
                dt = new DataTable();
                //dt = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                }
                else
                {
                    dt = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack ");
                }


                for (int I = 0; I < dt.Rows.Count; I++)
                {
                    cbxJobListPM.Items.Add(dt.Rows[I]["cTrack"].ToString());
                }
            }
            catch (Exception ex)
            {

                //MessageBox.Show("Fille Combobo Error " + ex.Message.ToString());
                MessageBox.Show("Fillcombo" + ex.Message.ToString());
                throw;
                
            }
            finally
            {
                 dt = null;
            }
        }
        private void fillGridJobList()
        {
            try
            {
                string queryString = "SELECT  DISTINCT JobList.JobListID, JobList.JobNumber,   Company.CompanyName, Company.CompanyID, JobList.DateAdded, JobList.Description, JobList.Handler, JobList.Borough, JobList.Address,Contacts.FirstName + ' ' + Contacts.MiddleName + ' ' + Contacts.LastName AS Contacts, Contacts.EmailAddress, Contacts.ContactsID,JobList.ACContacts,JobList.ACEmail,JobList.OwnerName,JobList.OwnerAddress,JobList.OwnerPhone,JobList.OwnerFax,Company.CompanyNo, JobList.IsDisable FROM  JobList LEFT OUTER JOIN            Contacts ON JobList.ContactsID = Contacts.ContactsID LEFT OUTER JOIN      Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN        JobTracking ON JobList.JobListID = JobTracking.JobListID     WHERE (JobList.IsDelete=0 or JobList.IsDelete is null) ";

                if (!string.IsNullOrEmpty(this.txtJobListJobID.Text))
                {
                    queryString = queryString + " and JobList.JobNumber Like'%" + txtJobListJobID.Text + "%'";
                }
                if (!string.IsNullOrEmpty(this.txtJobListclient.Text))
                {
                    queryString = queryString + " and CompanyName Like'%" + txtJobListclient.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.txtJobListAddress.Text))
                {
                    queryString = queryString + " and JobList.Address Like'%" + txtJobListAddress.Text + "%'";
                }

                if (!string.IsNullOrEmpty(txtTown.Text))
                {
                    queryString = queryString + " and JobList.Borough like'" + txtTown.Text + "%'";
                }


                if (!string.IsNullOrEmpty(this.txtDescriptionSearchJob.Text))
                {
                    queryString = queryString + " and JobList.Description like'%" + txtDescriptionSearchJob.Text + "%'";
                }

                if (this.cbxJobListPM.SelectedItem != "")
                {
                    queryString = queryString + " and Handler='" + cbxJobListPM.SelectedItem + "'";
                }

                if (pnlUSerLoginCombo.Visible)
                {
                    if (userID == "0")
                    {
                        queryString = queryString + " AND Joblist.JobListID in (select joblistid from TS_Expences union select joblistid from TS_Time)";
                    }
                    else
                    {
                        queryString = queryString + " AND Joblist.JobListID in (select joblistid from TS_Expences where EmployeeDetailsId=" + userID + " union select joblistid from TS_Time where EmployeeDetailsId=" + userID + ")";
                    }
                }

                //DataTable dtJL = StMethod.GetListDT<JobsList>(queryString);

                DataTable dtJL;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dtJL = StMethod.GetListDTNew<JobsList>(queryString);
                }
                else
                {
                    dtJL = StMethod.GetListDT<JobsList>(queryString);
                }

                grdJobList.DataSource = dtJL;
                // End If

                //Grid Formatting
                grdJobList.Columns["JobListID"].Visible = false;
                grdJobList.Columns["JobNumber"].HeaderText = "Job#";
                grdJobList.Columns["JobNumber"].Width = 80;
                grdJobList.Columns["DateAdded"].Width = 1;
                grdJobList.Columns["DateAdded"].HeaderText = "Added";
                grdJobList.Columns["DateAdded"].Width = 80;
                grdJobList.Columns["CompanyName"].HeaderText = "client#";
                grdJobList.Columns["Handler"].HeaderText = "PM";
                grdJobList.Columns["Description"].HeaderText = "Description";
                grdJobList.Columns["Description"].Width = 200;
                grdJobList.Columns["Handler"].Width = 40;
                grdJobList.Columns["Address"].Width = 150;
                grdJobList.Columns["CompanyID"].Width = 130;
                grdJobList.Columns["Borough"].Width = 200;
                grdJobList.Columns["Borough"].HeaderText = "Town";
                grdJobList.Columns["Contacts"].Width = 130;
                //.Columns["Contacts"].ReadOnly = True
                grdJobList.Columns["EmailAddress"].Width = 250;
                grdJobList.Columns["Handler"].Visible = true;
                //.Columns["Borough"].Visible = False
                grdJobList.Columns["CompanyID"].Visible = false;
                grdJobList.Columns["Contacts"].Visible = false;
                grdJobList.Columns["ContactsID"].Visible = false;
                grdJobList.Columns["CompanyName"].Visible = true;
                grdJobList.Columns["OwnerName"].Visible = false;
                grdJobList.Columns["OwnerAddress"].Visible = false;
                grdJobList.Columns["OwnerPhone"].Visible = false;
                grdJobList.Columns["OwnerFax"].Visible = false;
                grdJobList.Columns["ACContacts"].Visible = false;
                grdJobList.Columns["ACEmail"].Visible = false;
                grdJobList.Columns["CompanyNo"].Visible = false;
                grdJobList.Columns["DateAdded"].Visible = false;
                grdJobList.Columns["EmailAddress"].Visible = false;
                grdJobList.Columns["IsDisable"].Visible = false;
                grdJobList.Columns["IsDisable"].HeaderText = "Disabled";
                foreach (DataGridViewColumn grdColumn in grdJobList.Columns)
                {
                    if (grdColumn.Index != 0)
                    {
                        grdJobList.Columns[grdColumn.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }
                if (grdJobList.Rows.Count > 0)
                {
                    SelectJobListID = Convert.ToInt32( grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobListID"].Value);
                }
                else
                {
                    SelectJobListID = 0;
                }

                //Dim t As Threading.Tasks.Task = New Threading.Tasks.Task(AddressOf SetGridColor)
                //t.Start()
                SetGridColor();

                // fillTimeSheet()
                // fillExpences()
            }
            catch (Exception ex)
            {
                MessageBox.Show("fillGridJobList" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetGridColor()
        {
            for (int rowIndex = 0; rowIndex < grdJobList.Rows.Count; rowIndex++)
            {
                if (grdJobList.Rows.Count == 0)
                {
                    break;
                }
                DataGridViewRow currentRow = grdJobList.Rows[rowIndex];
                if (Convert.IsDBNull(currentRow.Cells["IsDisable"].Value))
                {
                    continue;
                }
                if (Convert.ToBoolean( currentRow.Cells["IsDisable"].Value))
                {
                    currentRow.DefaultCellStyle.BackColor = Color.LightGray;
                    currentRow.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                }
            }
        }
        private void FillcmbUser()
        {

            try
            { 

            cmbSelectUser.SelectedIndexChanged -= this.cmbSelectUser_SelectedIndexChanged;
            string queryString = null;

            //Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()

            if (Properties.Settings.Default.timeSheetLoginUserType == "user")
            {
                int EmpID = Properties.Settings.Default.timeSheetLoginUserID;
                //queryString = "use " + con.Database + " SELECT  EmployeeDetailsId, Name FROM  EmployeeDetails where UserType='U' and EmployeeDetailsId='" & EmpID & "' "
                queryString = "SELECT Id, UserName FROM  EmployeeDetails where UserType='U' and Id='" + EmpID + "' ";
            }
            else
            {
                queryString = "SELECT Id, UserName FROM EmployeeDetails where UserType='U' union SELECT 0 as Id, '' as UserName order by Id";
            }
                //DataTable dtJL = StMethod.GetListDT<dtoUsers>(queryString);

                //DataTable dtJL = StMethod.GetListDT<dtoUsersTest>(queryString);

                DataTable dtJL;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dtJL = StMethod.GetListDTNew<dtoUsersTest>(queryString);
                }
                else
                {
                    dtJL = StMethod.GetListDT<dtoUsersTest>(queryString);
                }


                cmbSelectUser.DisplayMember = "UserName";
            cmbSelectUser.ValueMember = "Id";
            cmbSelectUser.DataSource = dtJL;
            userID = cmbSelectUser.SelectedValue.ToString();
            cmbSelectUser.SelectedIndexChanged += cmbSelectUser_SelectedIndexChanged;
            }

            catch(Exception ex)
            {
                MessageBox.Show("FillcmbUser" + ex.Message.ToString());
            }

        }
        private void fillcmbUserSearchTimeAndExp()
        {
            try
            {
                cmbUserSearch.SelectedIndexChanged -= this.cmbUserSearch_SelectedIndexChanged;
                string queryString = null;

                queryString = "SELECT  Id, UserName FROM  EmployeeDetails where UserType='U' AND UserName<>'' union SELECT 0 as Id, '' as UserName order by UserName";

                //DataTable dt = StMethod.GetListDT<dtoUsers>(queryString);
                //DataTable dt = StMethod.GetListDT<dtoUsersTest>(queryString);

                DataTable dt;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<dtoUsersTest>(queryString);
                }
                else
                {
                    dt = StMethod.GetListDT<dtoUsersTest>(queryString);
                }


                DataView dtshort = new DataView();
                dtshort = dt.DefaultView;
                dtshort.Sort = "UserName";
                //dtshort.Sort = "Name"
                cmbUserSearch.DisplayMember = "UserName";
                cmbUserSearch.ValueMember = "Id";
                cmbUserSearch.DataSource = dtshort; //DAL.Filldatatable(queryString)
                cmbUserSearch.SelectedIndexChanged += cmbUserSearch_SelectedIndexChanged;

            }
            catch (Exception ex)
            {
                MessageBox.Show("fillcmbUserSearchTimeAndExp" + ex.Message.ToString());
            }

        }
        private void fillcmbAdminStatus_grdTimeAndExp()
        {
            try
            {
                DataTable Dt = new DataTable();

                cmbAdminStatus.SelectedIndexChanged -= this.cmbAdminStatus_SelectedIndexChanged;

                //Dim query As String = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='STATUS' AND UserType='A'  union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId"
                string query = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'  union SELECT 0 as TS_MasterItemId,'' union SELECT 1 as TS_MasterItemId,'None' as value order by TS_MasterItemId";
                //Dim query As String = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='AdminStatus'  union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId"

                //Dt = StMethod.GetListDT<MasterData>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    Dt = StMethod.GetListDTNew<MasterData>(query);
                }
                else
                {
                    Dt = StMethod.GetListDT<MasterData>(query);
                }

                cmbAdminStatus.DisplayMember = "Value";
                cmbAdminStatus.ValueMember = "TS_MasterItemId";
                
                //cmbAdminStatus.DataSource = StMethod.GetListDT<MasterData>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    cmbAdminStatus.DataSource = StMethod.GetListDTNew<MasterData>(query);
                }
                else
                {
                    cmbAdminStatus.DataSource = StMethod.GetListDT<MasterData>(query);
                }

                cmbAdminStatus.SelectedIndexChanged += this.cmbAdminStatus_SelectedIndexChanged;

            }
            catch (Exception ex)
            {
                MessageBox.Show("fillcmbAdminStatus_grdTimeAndExp" + ex.Message.ToString());
            }
        }
        private void fillcmbItemSTATUS_grdTimeAndExp()
        {
            try
            {
                DataTable Dt = new DataTable();
                cmbStatus.SelectedIndexChanged -= this.cmbStatus_SelectedIndexChanged;

                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    string query = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='STATUS' AND UserType='U'  union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId ";

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        Dt = StMethod.GetListDTNew<MasterData>(query);

                    }
                    else
                    {
                        Dt = StMethod.GetListDT<MasterData>(query);
                    }

                    //Dt = StMethod.GetListDT<MasterData>(query);

                    cmbStatus.DisplayMember = "Value";
                    cmbStatus.ValueMember = "TS_MasterItemId";
                    
                    
                    //cmbStatus.DataSource = StMethod.GetListDT<MasterData>(query);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        cmbStatus.DataSource = StMethod.GetListDTNew<MasterData>(query);

                    }
                    else
                    {
                        cmbStatus.DataSource = StMethod.GetListDT<MasterData>(query);
                    }


                    cmbStatus.Text = "Submit";

                    


                }
                else
                {
                    string query = "SELECT TS_MasterItemId, Value FROM TS_MasterItem where ItemName='STATUS' AND UserType='U'  union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId";

                    //Dt = StMethod.GetListDT<MasterData>(query);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        Dt = StMethod.GetListDTNew<MasterData>(query);

                    }
                    else
                    {
                        Dt = StMethod.GetListDT<MasterData>(query);
                    }


                    cmbStatus.DisplayMember = "Value";
                    cmbStatus.ValueMember = "TS_MasterItemId";
                    
                    //cmbStatus.DataSource = StMethod.GetListDT<MasterData>(query);



                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        cmbStatus.DataSource = StMethod.GetListDTNew<MasterData>(query);

                    }
                    else
                    {
                        cmbStatus.DataSource = StMethod.GetListDT<MasterData>(query);
                    }

                    cmbStatus.Text = "Submit";

                }
                cmbStatus.SelectedIndexChanged += this.cmbStatus_SelectedIndexChanged;

                DataGridViewComboBoxColumn grdExpeItemNameSTATUS = new DataGridViewComboBoxColumn();
                grdExpeItemNameSTATUS.Name = "ExpenseSheetItemNameSTATUS";
                grdExpeItemNameSTATUS.DataPropertyName = "status";
                grdExpeItemNameSTATUS.DataSource = Dt;
                grdExpeItemNameSTATUS.DisplayMember = "Value";
                grdExpeItemNameSTATUS.HeaderText = "Status";
                grdExpeItemNameSTATUS.FlatStyle = FlatStyle.Standard;
                DataGridViewComboBoxColumn grdTimeItemNameSTATUS = new DataGridViewComboBoxColumn();
                grdTimeItemNameSTATUS.Name = "TimeItemNameSTATUS";
                grdTimeItemNameSTATUS.DataPropertyName = "status";

                grdTimeItemNameSTATUS.DataSource = Dt;
                grdTimeItemNameSTATUS.DisplayMember = "Value";
                grdTimeItemNameSTATUS.HeaderText = "Status";
                grdTimeItemNameSTATUS.FlatStyle = FlatStyle.Standard;
                grdExpenses.Columns.Add(grdExpeItemNameSTATUS);
                grdTimeAndExp.Columns.Add(grdTimeItemNameSTATUS);

            }
            catch (Exception ex)
            {
                MessageBox.Show("fillcmbItemSTATUS_grdTimeAndExp" + ex.Message.ToString());
            }
        }
        private void fillcmbItemBILLSTATE_grdTimeAndExp()
        {
            try
            {
                DataTable Dt = new DataTable();
                cmbBillStatus.SelectedIndexChanged -= this.cmbBillStatus_SelectedIndexChanged;
                string query = "SELECT TS_MasterItemId, Value FROM  TS_MasterItem where ItemName='BILL STATE' union SELECT 0 as TS_MasterItemId,'' as value order by TS_MasterItemId ";


                //Dt = StMethod.GetListDT<MasterData>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    Dt = StMethod.GetListDTNew<MasterData>(query);
                }
                else
                {
                    Dt = StMethod.GetListDT<MasterData>(query);
                }



                cmbBillStatus.DisplayMember = "Value";
                cmbBillStatus.ValueMember = "TS_MasterItemId";

                //cmbBillStatus.DataSource = StMethod.GetListDT<MasterData>(query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    cmbBillStatus.DataSource = StMethod.GetListDTNew<MasterData>(query);
                }
                else
                {
                    cmbBillStatus.DataSource = StMethod.GetListDT<MasterData>(query);
                }

                cmbBillStatus.SelectedIndexChanged += this.cmbBillStatus_SelectedIndexChanged;
                DataGridViewComboBoxColumn grdExpeItemNameBILLSTATE = new DataGridViewComboBoxColumn();
                grdExpeItemNameBILLSTATE.Name = "ExpenseSheetItemNameBILLSTATE";
                grdExpeItemNameBILLSTATE.DataPropertyName = "BillState";
                grdExpeItemNameBILLSTATE.DataSource = Dt;
                grdExpeItemNameBILLSTATE.DisplayMember = "Value";
                grdExpeItemNameBILLSTATE.HeaderText = "Bill State";
                grdExpeItemNameBILLSTATE.FlatStyle = FlatStyle.Standard;

                DataGridViewComboBoxColumn grdTimeItemNameBILLSTATE = new DataGridViewComboBoxColumn();
                grdTimeItemNameBILLSTATE.Name = "TimeItemNameBILLSTATE";
                grdTimeItemNameBILLSTATE.DataPropertyName = "BillState";
                grdTimeItemNameBILLSTATE.DataSource = Dt;
                grdTimeItemNameBILLSTATE.DisplayMember = "Value";
                grdTimeItemNameBILLSTATE.HeaderText = "Bill State";
                grdTimeItemNameBILLSTATE.FlatStyle = FlatStyle.Standard;
                grdExpenses.Columns.Add(grdExpeItemNameBILLSTATE);
                grdTimeAndExp.Columns.Add(grdTimeItemNameBILLSTATE);

            }
            catch (Exception ex)
            {
                MessageBox.Show("fillcmbItemBILLSTATE_grdTimeAndExp" + ex.Message.ToString());
            }
        }
        private void fillgrdTrackSubGrid()
        {
            try
            {
                string query = "SELECT  id, TrackSubName FROM MasterTrackSubItem WHERE (IsDelete=0 Or IsDelete Is null) UNION SELECT 0 as id, '' as TrackSubName order by id";
                DataTable Dt = new DataTable();

                //Dt = StMethod.GetListDT<colTrackSubItem>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    Dt = StMethod.GetListDTNew<colTrackSubItem>(query);
                }
                else
                {
                    Dt = StMethod.GetListDT<colTrackSubItem>(query);
                }


                DataGridViewComboBoxColumn grdExpenseTrackSubID = new DataGridViewComboBoxColumn();
                grdExpenseTrackSubID.Name = "ExpenseSheetTrackSubName";
                grdExpenseTrackSubID.DataPropertyName = "TrackSubID";
                grdExpenseTrackSubID.DataSource = Dt;
                grdExpenseTrackSubID.DisplayMember = "TrackSubName";
                grdExpenseTrackSubID.ValueMember = "id";
                grdExpenseTrackSubID.HeaderText = "Track Sub Name";
                grdExpenseTrackSubID.FlatStyle = FlatStyle.Standard;
                //.DisplayIndex = 7
                DataGridViewComboBoxColumn grdTimeTrackSubID = new DataGridViewComboBoxColumn();
                grdTimeTrackSubID.Name = "TimeSheetTrackSubName";
                grdTimeTrackSubID.DataPropertyName = "TrackSubID";
                grdTimeTrackSubID.DataSource = Dt;
                grdTimeTrackSubID.DisplayMember = "TrackSubName";
                grdTimeTrackSubID.ValueMember = "id";
                grdTimeTrackSubID.HeaderText = "Track Sub Name";
                grdTimeTrackSubID.FlatStyle = FlatStyle.Flat;
                //.DisplayIndex = 7
                grdExpenses.Columns.Add(grdExpenseTrackSubID);
                grdTimeAndExp.Columns.Add(grdTimeTrackSubID);
                //With grdExpenseTrackSubID
                //    .DataSource = Dt
                //    .DisplayMember = "TrackSubName"
                //    .ValueMember = "id"
                //End With
                //With grdTimeTrackSubID
                //    .DataSource = Dt
                //    .DisplayMember = "TrackSubName"
                //    .ValueMember = "id"
                //End With
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void fillcmbItemMASS_grdTimeAndExp()
        {
            try
            {
                DataTable Dt = new DataTable();
                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    string query = "SELECT ItemName, Value FROM TS_MasterItem where ItemName='MASS'";
                    //Dt = StMethod.GetListDT<TS_ItemMASS>(query);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        Dt = StMethod.GetListDTNew<TS_ItemMASS>(query);
                    }
                    else
                    {
                        Dt = StMethod.GetListDT<TS_ItemMASS>(query);
                    }

                }
                else
                {
                    string query = "SELECT ItemName, Value FROM TS_MasterItem where ItemName='MASS' AND UserType='U'";
                    //Dt = StMethod.GetListDT<TS_ItemMASS>(query);
                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        Dt = StMethod.GetListDTNew<TS_ItemMASS>(query);

                    }
                    else
                    {
                        Dt = StMethod.GetListDT<TS_ItemMASS>(query);
                    }
                }

                DataGridViewComboBoxColumn grdExpeItemNameMASS = new DataGridViewComboBoxColumn();
                grdExpeItemNameMASS.Name = "ExpenseSheetItemNameMASS";
                grdExpeItemNameMASS.DataPropertyName = "MassStatusChangeBox";
                grdExpeItemNameMASS.DataSource = Dt;
                grdExpeItemNameMASS.DisplayMember = "Value";

                grdExpeItemNameMASS.HeaderText = "MassStatusChangeBox";
                grdExpeItemNameMASS.FlatStyle = FlatStyle.Standard;
                DataGridViewComboBoxColumn grdTimeItemNameMASS = new DataGridViewComboBoxColumn();
                grdTimeItemNameMASS.Name = "TimeItemNameMASS";
                grdTimeItemNameMASS.DataPropertyName = "MassStatusChangeBox";
                grdTimeItemNameMASS.DataSource = Dt;
                grdTimeItemNameMASS.DisplayMember = "Value";
                grdTimeItemNameMASS.HeaderText = "MassStatusChangeBox";
                grdTimeItemNameMASS.FlatStyle = FlatStyle.Standard;
                grdExpenses.Columns.Add(grdExpeItemNameMASS);
                grdTimeAndExp.Columns.Add(grdTimeItemNameMASS);

            }
            catch (Exception ex)
            {
            }
        }
        private void fillcmbUserTimeAndExp()
        {
            try
            {
                string queryString = "SELECT  Id, UserName FROM  EmployeeDetails where UserType='U' AND UserName<>'' union SELECT 0 as Id, '' as UserName order by UserName";

                //********Change code by giriraj 2O Oct 2013 ****
                //Dim queryString As String = "use TestPCTracker SELECT  EmployeeDetailsId, Name FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as UserName order by EmployeeDetailsId"

                //DataTable dt = StMethod.GetListDT<dtoUsers>(queryString);


                //DataTable dt = StMethod.GetListDT<dtoUsersTest>(queryString);

                DataTable dt;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew<dtoUsersTest>(queryString);

                }
                else
                {
                    dt = StMethod.GetListDT<dtoUsersTest>(queryString);

                }


                DataGridViewComboBoxColumn grdcmbUserExpenses = new DataGridViewComboBoxColumn();
                grdcmbUserExpenses.Name = "ExpenseSheetUser";
                grdcmbUserExpenses.DataPropertyName = "Name";
                // .ValueMember = "EmployeeDetailsId"


                grdcmbUserExpenses.DataSource = dt;
                grdcmbUserExpenses.DisplayMember = "UserName";
                grdcmbUserExpenses.HeaderText = "User";
                grdcmbUserExpenses.FlatStyle = FlatStyle.Standard;
                DataGridViewComboBoxColumn grdcmbUserTime = new DataGridViewComboBoxColumn();
                grdcmbUserTime.DataSource = dt;
                grdcmbUserTime.Name = "TimeSheetUser";
                grdcmbUserTime.DataPropertyName = "Name";
                //.ValueMember = "EmployeeDetailsId"

                grdcmbUserTime.DisplayMember = "UserName";
                grdcmbUserTime.HeaderText = "User";
                grdcmbUserTime.FlatStyle = FlatStyle.Standard;

                grdExpenses.Columns.Add(grdcmbUserExpenses);
                grdTimeAndExp.Columns.Add(grdcmbUserTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show("fillcmbUserTimeAndExp" + ex.Message.ToString());
            }
        }
        private void fillTimeSheet()
        {
            try
            {
                frmShowTimeExpanseData frmshowTotals = GetPnlFormObject();
                frmshowTotals.JobNumber = this.txtJobNumber.Text;
                frmshowTotals.UserSearch = this.cmbUserSearch.Text;
                frmshowTotals.Status = this.cmbStatus.Text;
                frmshowTotals.AdminStatus = this.cmbAdminStatus.Text;
                frmshowTotals.BillStatus = this.cmbBillStatus.Text;
                frmshowTotals.ckbTime = ckbTime.Checked;
                frmshowTotals.dtpDateSearchTo = dtpDateSearchTo.Value;
                frmshowTotals.dtpSearchFrom = dtpDateSearchFrom.Value;
                frmshowTotals.fillgrdTimeSheetData();
                string queryString = null;

                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    queryString = "SELECT TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as [Job_Number],TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID,TS_Time.status, TS_Time.Time, TS_Time.BillState,TS_Time.TrackSubName,TS_Time.Description,TS_Time.Comment, TS_Time.AdminStatus,JobTrackingId FROM TS_Time Where JobListID<>0 ";

                    //queryString = "SELECT TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as \"Job Number\",TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID,TS_Time.status, TS_Time.Time, TS_Time.BillState,TS_Time.TrackSubName,TS_Time.Description,TS_Time.Comment, TS_Time.AdminStatus,JobTrackingId FROM TS_Time Where JobListID<>0 ";



                    //                    queryString = "SELECT TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,";


                    ////                    queryString = queryString + "(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as \"Job Number2\",";

                    //                    queryString = queryString + "(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as Job_Number,";

                    //                    queryString = queryString + "TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID,TS_Time.status, TS_Time.Time, TS_Time.BillState,TS_Time.TrackSubName,TS_Time.Description,TS_Time.Comment, TS_Time.AdminStatus,JobTrackingId FROM TS_Time Where JobListID<>0 ";




                }
                else
                {
                    string LoginUser = Properties.Settings.Default.timeSheetLoginName;

                    //queryString = "SELECT TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as [Job Number],TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID,TS_Time.status, TS_Time.Time, TS_Time.BillState,TS_Time.TrackSubName,TS_Time.Description,TS_Time.Comment, TS_Time.AdminStatus,JobTrackingId FROM TS_Time Where Name='" + LoginUser + "'";

                    queryString = "SELECT TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as [Job_Number],TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID,TS_Time.status, TS_Time.Time, TS_Time.BillState,TS_Time.TrackSubName,TS_Time.Description,TS_Time.Comment, TS_Time.AdminStatus,JobTrackingId FROM TS_Time Where Name='" + LoginUser + "'";

                    //queryString = "SELECT     TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as [Job Number],TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID,TS_Time.status, TS_Time.Time, TS_Time.TrackSubName,TS_Time.Description,TS_Time.Comment,TS_Time.BillState, TS_Time.AdminStatus FROM TS_Time Where Name='" & LoginUser & "'"

                }

                if (!string.IsNullOrEmpty(this.txtJobNumber.Text))
                {
                    queryString = queryString + " and (SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID)  Like'" + txtJobNumber.Text + "%'";
                }
                //frmshowTimeExpance.JobNumber = Me.txtJobNumber.Text
                // If Me.txtPM.Text <> "" Then queryString = queryString & " and TS_Time.Name Like'%" & txtPM.Text & "%'"
                if (!string.IsNullOrEmpty(this.cmbUserSearch.Text))
                {
                    queryString = queryString + " and TS_Time.EmployeeDetailsId = '" + cmbUserSearch.SelectedValue + "'";
                }
                //frmshowTimeExpance.UserSearch = Me.cmbUserSearch.Text

                if (!string.IsNullOrEmpty(this.cmbStatus.Text))
                {
                    queryString = queryString + " and TS_Time.status Like '%" + cmbStatus.Text + "%'";
                }
                //frmshowTimeExpance.Status = Me.cmbStatus.Text
                //  If Me.cmbAdminStatus.Text = "All" Then

                //  Else
                if (!string.IsNullOrEmpty(this.cmbAdminStatus.Text))
                {

                    queryString = queryString + " and TS_Time.AdminStatus Like '%" + cmbAdminStatus.Text + "%'";
                    //   frmshowTimeExpance.AdminStatus = Me.cmbAdminStatus.Text
                }
                else
                {
                    // queryString = queryString & " and TS_Time.AdminStatus Like '" & cmbAdminStatus.Text & "'"
                }
                //   End If
                if (!string.IsNullOrEmpty(this.txtTrackSubComment.Text.Trim()))
                {
                    queryString = queryString + "and  TS_Time.TrackSubName like '%" + txtTrackSubComment.Text.Trim() + "%' ";
                }

                if (!string.IsNullOrEmpty(this.cmbBillStatus.Text))
                {
                    queryString = queryString + " and TS_Time.BillState Like'" + cmbBillStatus.Text + "'";
                }
                //frmshowTimeExpance.BillStatus = Me.cmbBillStatus.Text
                if (ckbTime.Checked == true)
                {
                    //   frmshowTimeExpance.ckbTime = ckbTime.Checked
                    if (string.CompareOrdinal(dtpDateSearchTo.Value.ToString("yyyy/MM/dd"), dtpDateSearchFrom.Value.ToString("yyyy/MM/dd")) >= 0)
                    {
                        queryString = queryString + " AND Date BETWEEN '" + dtpDateSearchFrom.Value.ToString("yyyy/MM/dd") + "' AND '" + dtpDateSearchTo.Value.ToString("yyyy/MM/dd") + "'";
                        //      frmshowTimeExpance.dtpDateSearchTo = dtpDateSearchTo.Value
                        //     frmshowTimeExpance.dtpSearchFrom = dtpDateSearchFrom.Value
                    }
                    else
                    {
                        //KryptonMessageBox.Show("Added To date must greater then or equal Added From date", "Jobtracking")
                    }

                    // If Me.dtpDateSearchFrom.Text <> "" Then queryString = queryString & " and TS_Time.Date ='" & dtpDateSearchFrom.Value.ToShortDateString() & "'"
                }

                DataTable dtTimeSheet = null;
                
                //dtTimeSheet = StMethod.GetListDT<TS_TimeData>(queryString);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dtTimeSheet = StMethod.GetListDTNew<TS_TimeData>(queryString);
                }
                else
                {
                    dtTimeSheet = StMethod.GetListDT<TS_TimeData>(queryString);
                }

                // set Fill record Excel sheet Export                
                //dtTimeExportExcelSheet = StMethod.GetListDT<TS_TimeData>(queryString + " order by TS_Time.Date ASC ");

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dtTimeExportExcelSheet = StMethod.GetListDTNew<TS_TimeData>(queryString + " order by TS_Time.Date ASC ");
                }
                else
                {
                    dtTimeExportExcelSheet = StMethod.GetListDT<TS_TimeData>(queryString + " order by TS_Time.Date ASC ");
                }

                grdTimeAndExp.DataSource = dtTimeSheet;


                //'Update''
                DataTable distinctTable = dtTimeSheet.DefaultView.ToTable(true, "Date");

                Int16 DateCount = (Int16)distinctTable.Rows.Count;
                lbltotaldays.Text = "Total Days:- " + DateCount;

                //int z;
                //for (z=0;z<grdTimeAndExp .Columns.Count-1;z++)
                //{

                //    MessageBox.Show(grdTimeAndExp.Columns[z].HeaderText.ToString());
                //}



                //grdTimeAndExp.Columns["Time"].DefaultCellStyle.Format = "00.00"
                grdTimeAndExp.Columns["TimeSheetID"].Visible = false;
                grdTimeAndExp.Columns["JobListID"].Visible = false;
                grdTimeAndExp.Columns["EmployeeDetailsId"].Visible = false;
                grdTimeAndExp.Columns["TrackSubID"].Visible = false;


                // grdTimeAndExp.Columns["TimeSheetUser"].HeaderText = "User"
                grdTimeAndExp.Columns["Comment"].Visible = false;

                grdTimeAndExp.Columns["Job_Number"].HeaderText = "Job No.";

                grdTimeAndExp.Columns["TrackSubName"].HeaderText = "TrackSub Comment";

                grdTimeAndExp.Columns["AdminStatus"].HeaderText = "Admin Status";

                grdTimeAndExp.Columns["Job_Number"].Width = 50;
                grdTimeAndExp.Columns["Date"].Width = 72;
                grdTimeAndExp.Columns["TimeSheetUser"].Width = 60;
                grdTimeAndExp.Columns["Time"].Width = 45;
                grdTimeAndExp.Columns["TrackSubName"].Width = 420;
                grdTimeAndExp.Columns["Description"].Width = 195;
                grdTimeAndExp.Columns["JobTrackingId"].Visible = false;

                grdTimeAndExp.Columns["TrackSubId"].Visible = false;
                // .Columns["TimeSheetUser"].DisplayIndex = 6
                grdTimeAndExp.Columns["TimeItemNameSTATUS"].DisplayIndex = 13;
                grdTimeAndExp.Columns["TimeItemNameBILLSTATE"].DisplayIndex = 15;
                frmshowTotals.fillgrdTimeSheetData();

                //For Each dRow As DataRow In duplicateList
                //    dTable.Rows.Remove(dRow)
                //Next

                ChangePunchHours();
                //Dim countMint As Integer
                //Dim countHours As Integer
                //Dim fltMint As Integer
                //Dim fltHours As Integer
                double count = 0;
                for (int Row = 0; Row < grdTimeAndExp.Rows.Count; Row++)
                {
                    //For Each grdRowTime As DataGridViewRow In grdTimeAndExp.Rows  'Running Code
                    count = count + Convert.ToDouble(grdTimeAndExp.Rows[Row].Cells["Time"].Value);
                    //    Dim Time As Double = Convert.ToDouble(grdRowTime.Cells["Time"].Value)

                    //    Dim splitTime As String = Time.ToString()
                    //    Dim splitFilter() As String = splitTime.Split(".")

                    //    If splitFilter.Length > 1 Then
                    //        fltMint = Convert.ToInt32(splitFilter(1))
                    //        fltHours = Convert.ToInt32(splitFilter(0))
                    //    Else
                    //        fltMint = 0
                    //        fltHours = Convert.ToInt32(splitFilter(0))
                    //    End If
                    //    countMint = countMint + fltMint
                    //    countHours = countHours + fltHours
                    //    If countMint > 60 Then
                    //        countHours = countHours + 1
                    //        countMint = countMint - 60

                    //    End If

                    //Next
                }
                lblTotalHours.Text = "Total Hours:" + count.ToString();

                //For Each grdColumn As DataGridViewColumn In grdTimeAndExp.Columns
                //    If grdColumn.Index <> 0 And grdColumn.Index <> 1 Then
                //        grdTimeAndExp.Columns[grdColumn.Index].AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill
                //    End If
                //Next
                double Holiday = 0;
                double SickHoliday = 0;
                double VacationHoliday = 0;
                //  Dim Regular As Integer
                bool cnd = false;
                // Dim CheckRegulare As Boolean = True

                foreach (DataGridViewRow grdROW in grdTimeAndExp.Rows)
                {

                    string checkvalue = grdROW.Cells["TrackSubName"].Value.ToString();

                    if (checkvalue.Contains("HOLIDAY"))
                    {
                        Holiday = Holiday + Convert.ToDouble(grdROW.Cells["Time"].Value.ToString());
                        // CheckRegulare = False
                    }

                    if (checkvalue.Contains("SICK TIME"))
                    {
                        SickHoliday = SickHoliday + Convert.ToDouble(grdROW.Cells["Time"].Value.ToString());
                        //CheckRegulare = False
                    }

                    if (checkvalue.Contains("VACATION TIME"))
                    {
                        VacationHoliday = VacationHoliday + Convert.ToDouble(grdROW.Cells["Time"].Value.ToString());
                        //CheckRegulare = False
                    }

                    //If CheckRegulare = True Then
                    //    Regular = Regular + 1
                    //    CheckRegulare = True
                    //End If
                    lblHoliday.Text = "Holiday :" + Holiday;
                    lblSickTime.Text = "Sick Time :" + SickHoliday;
                    lblVacationTime.Text = "Vacation Time :" + VacationHoliday;
                    // lblRegular.Text = "Regular:" & Regular
                    cnd = true;
                }

                if (cnd == true)
                {
                    double TotalHoliday = Holiday + SickHoliday + VacationHoliday;

                    // lblTotalHoliday.Text = "Total Holiday :" & TotalHoliday
                    //Dim total As Double = Convert.ToDouble(TotalHoliday + count.ToString())
                    double LessLoggedHours = Convert.ToDouble(count - TotalHoliday);
                    TotalHolidayHours.Text = "Regular:" + LessLoggedHours.ToString();
                }
                else
                {
                    lblHoliday.Text = "Holiday :" + 0.ToString();
                    lblSickTime.Text = "Sick Time :" + 0.ToString();
                    lblVacationTime.Text = "Vacation Time :" + 0.ToString();
                    TotalHolidayHours.Text = "Regular:" + 0.ToString();
                    //lblPunch.Text = "Punch : " & 0.0
                }

                DisbaledRowByAdmin(grdTimeAndExp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("fillTimeSheet" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ChangePunchHours()
        {
            try
            {
                int userID = Convert.ToInt32(cmbUserSearch.SelectedValue);
                string query = " USe " + cGlobal.AdditionalDB + " SELECT  SingIn, SingOut, Date, HoursWorked FROM Attendance where EmployeeDetailsId=" + userID + "";

                if (ckbTime.Checked == true)
                {
                    if (string.CompareOrdinal(dtpDateSearchTo.Value.ToString("yyyy/MM/dd"), dtpDateSearchFrom.Value.ToString("yyyy/MM/dd")) >= 0)
                    {
                        query = query + " AND Date BETWEEN '" + dtpDateSearchFrom.Value.ToString("yyyy/MM/dd") + "' AND '" + dtpDateSearchTo.Value.ToString("yyyy/MM/dd") + "'";
                    }

                }
                DataTable dt = new DataTable();
                //dt = StMethod.GetListDT<InOutData>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<InOutData>(query);
                }
                else
                {
                    dt = StMethod.GetListDT<InOutData>(query);
                }

                foreach (DataRow changehours in dt.Rows)
                {
                    double _hours = Convert.ToDouble(changehours["HoursWorked"].ToString());
                    string splite = _hours.ToString();
                    string[] filter = splite.Split('.');
                    long i1 = 0;
                    if (filter.Length > 1)
                    {

                        i1 = Convert.ToInt64(filter[1]);
                    }
                    else
                    {
                        i1 = 0;
                    }
                    CountChars(i1.ToString());
                    double filterMint = 0;
                    if (result == 0)
                    {
                        filterMint = i1 / 10.0;
                    }
                    if (result == 1)
                    {
                        filterMint = i1 / 10.0;
                    }
                    if (result == 2)
                    {
                        filterMint = i1 / 100.0;
                    }
                    if (result == 3)
                    {
                        filterMint = i1 / 1000.0;
                    }
                    if (result == 4)
                    {
                        filterMint = i1 / 10000.0;
                    }
                    if (result == 5)
                    {
                        filterMint = i1 / 100000.0;
                    }
                    if (result == 6)
                    {
                        filterMint = i1 / 1000000.0;
                    }
                    if (result == 7)
                    {
                        filterMint = i1 / 10000000.0;
                    }
                    if (result == 8)
                    {
                        filterMint = i1 / 100000000.0;
                    }
                    if (result == 9)
                    {
                        filterMint = i1 / 1000000000.0;
                    }
                    if (result == 10)
                    {
                        filterMint = i1 / 10000000000.0;
                    }
                    if (result == 11)
                    {
                        filterMint = i1 / 100000000000.0;
                    }
                    if (result == 12)
                    {
                        filterMint = i1 / 1000000000000.0;
                    }
                    if (result == 13)
                    {
                        filterMint = i1 / 10000000000000.0;
                    }
                    if (result == 14)
                    {
                        filterMint = i1 / 100000000000000.0;
                    }
                    if (result == 15)
                    {
                        filterMint = i1 / 1000000000000000.0;
                    }
                    if (result == 16)
                    {
                        filterMint = i1 / 10000000000000000.0;
                    }
                    if (result == 17)
                    {
                        filterMint = i1 / 100000000000000000.0;
                    }
                    int Hours = int.Parse(filter[0]);
                    long Minutes = Convert.ToInt64((filterMint * 60));
                    int ConvertMint = (int)(Minutes);
                    changehours["HoursWorked"] = Hours.ToString() + "." + ConvertMint;

                }
                double count = 0;
                foreach (DataRow changehours in dt.Rows)
                {
                    count = Convert.ToDouble(count + changehours["HoursWorked"].ToString());
                }
                lblPunch.Text = "Punch :" + count.ToString();
            }
            catch (Exception ex)
            {

            }
        }
        public int CountChars(string value)
        {
            result = 0;
            bool lastWasSpace = false;

            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    // A.
                    // Only count sequential spaces one time.
                    if (lastWasSpace == false)
                    {
                        result += 1;
                    }
                    lastWasSpace = true;
                }
                else
                {
                    // B.
                    // Count other characters every time.
                    result += 1;
                    lastWasSpace = false;
                }
            }
            return result;
        }
        private void fillExpences()
        {
            try
            {
                string queryString = null;
                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    //queryString = "SELECT  TS_Expences.TimeSheetExpencesID, TS_Expences.JobListID, TS_Expences.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Expences.JobListID) as [Job Number],TS_Expences.Date, TS_Expences.Name,TS_Expences.TrackSubID, TS_Expences.status, TS_Expences.BillState,TS_Expences.TrackSubName,TS_Expences.Expences, TS_Expences.Description,TS_Expences.Comment,TS_Expences.AdminStatus FROM TS_Expences where JobListID<>0 ";

                    queryString = "SELECT  TS_Expences.TimeSheetExpencesID, TS_Expences.JobListID, TS_Expences.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Expences.JobListID) as [Job_Number],TS_Expences.Date, TS_Expences.Name,TS_Expences.TrackSubID, TS_Expences.status, TS_Expences.BillState,TS_Expences.TrackSubName,TS_Expences.Expences, TS_Expences.Description,TS_Expences.Comment,TS_Expences.AdminStatus FROM TS_Expences where JobListID<>0 ";

                }
                else
                {
                    //string LoginUser = Properties.Settings.Default.timeSheetLoginName;
                    //queryString = "SELECT  TS_Expences.TimeSheetExpencesID, TS_Expences.JobListID, TS_Expences.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Expences.JobListID) as [Job Number],TS_Expences.Date, TS_Expences.Name,TS_Expences.TrackSubID, TS_Expences.status, TS_Expences.BillState,TS_Expences.TrackSubName,TS_Expences.Expences, TS_Expences.Description,TS_Expences.Comment,TS_Expences.AdminStatus   FROM TS_Expences where Name='" + LoginUser + "'";

                    string LoginUser = Properties.Settings.Default.timeSheetLoginName;
                    queryString = "SELECT  TS_Expences.TimeSheetExpencesID, TS_Expences.JobListID, TS_Expences.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Expences.JobListID) as [Job_Number],TS_Expences.Date, TS_Expences.Name,TS_Expences.TrackSubID, TS_Expences.status, TS_Expences.BillState,TS_Expences.TrackSubName,TS_Expences.Expences, TS_Expences.Description,TS_Expences.Comment,TS_Expences.AdminStatus   FROM TS_Expences where Name='" + LoginUser + "'";
                }

                if (!string.IsNullOrEmpty(this.txtJobNumber.Text))
                {
                    queryString = queryString + " and (SELECT JobNumber FROM Joblist WHERE JobListID=TS_Expences.JobListID) Like'" + txtJobNumber.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.cmbUserSearch.Text))
                {
                    queryString = queryString + " and TS_Expences.EmployeeDetailsId = '" + cmbUserSearch.SelectedValue + "'";
                }

                if (!string.IsNullOrEmpty(this.cmbStatus.Text))
                {
                    queryString = queryString + " and TS_Expences.status Like'" + cmbStatus.Text + "'";
                }

                if (!string.IsNullOrEmpty(this.cmbBillStatus.Text))
                {
                    queryString = queryString + " and TS_Expences.BillState Like'" + cmbBillStatus.Text + "'";
                }
                //If Me.cmbAdminStatus.Text = "All" Then

                //Else
                if (!string.IsNullOrEmpty(this.cmbAdminStatus.Text))
                {
                    queryString = queryString + " and TS_Expences.AdminStatus Like  '%" + cmbAdminStatus.Text + "%'";
                }
                else
                {
                    //queryString = queryString & " and TS_Expences.AdminStatus Like '" & cmbAdminStatus.Text & "'"
                }

                // End If
                if (!string.IsNullOrEmpty(this.txtTrackSubComment.Text.Trim()))
                {
                    queryString = queryString + "and  TS_Expences.TrackSubName like '%" + txtTrackSubComment.Text.Trim() + "%' ";
                }

                if (ckbTime.Checked == true)
                {
                    if (string.CompareOrdinal(dtpDateSearchTo.Value.ToString("yyyy/MM/dd"), dtpDateSearchFrom.Value.ToString("yyyy/MM/dd")) >= 0)
                    {
                        queryString = queryString + " AND TS_Expences.Date BETWEEN '" + dtpDateSearchFrom.Value.ToString("yyyy/MM/dd") + "' AND '" + dtpDateSearchTo.Value.ToString("yyyy/MM/dd") + "'";
                    }
                    else
                    {

                    }
                }

                DataTable dtExpenseSheet;

                //DataTable dtExpenseSheet = StMethod.GetListDT<TS_ExpencesData>(queryString);
                //// set fill Export Excel sheet
                //dtExpensesExportExcelSheet = StMethod.GetListDT<TS_ExpencesData>(queryString + " order by TS_Expences.Date ASC ");


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dtExpenseSheet = StMethod.GetListDTNew<TS_ExpencesData>(queryString);
                    dtExpensesExportExcelSheet = StMethod.GetListDTNew<TS_ExpencesData>(queryString + " order by TS_Expences.Date ASC ");

                }
                else
                {
                    dtExpenseSheet = StMethod.GetListDT<TS_ExpencesData>(queryString);
                    dtExpensesExportExcelSheet = StMethod.GetListDT<TS_ExpencesData>(queryString + " order by TS_Expences.Date ASC ");
                }

                grdExpenses.DataSource = dtExpenseSheet;

                grdExpenses.Columns["TimeSheetExpencesID"].Visible = false;
                grdExpenses.Columns["JobListID"].Visible = false;
                grdExpenses.Columns["EmployeeDetailsId"].Visible = false;
                //grdExpenses.Columns["Expences"].Visible = True
                // grdExpenses.Columns["ExpenseSheetTrackSubName"].DisplayIndex = 2
                // grdExpenses.Columns["Expences"].DisplayIndex = 3
                // grdExpenses.Columns["Description"].DisplayIndex = 4
                grdExpenses.Columns["ExpenseSheetUser"].HeaderText = "User";
                grdExpenses.Columns["Expences"].HeaderText = "Amount $";
                //grdExpenses.Columns["ExpenseSheetItemNameSTATUS"].DisplayIndex = 5
                grdExpenses.Columns["TrackSubID"].Visible = false;
                grdExpenses.Columns["Job_Number"].HeaderText = "Job No.";
                grdExpenses.Columns["TrackSubName"].HeaderText = "TrackSub Comment";
                grdExpenses.Columns["AdminStatus"].HeaderText = "Admin Status";

                grdExpenses.Columns["Comment"].Visible = false;

                grdExpenses.Columns["Date"].Width = 72;
                grdExpenses.Columns["ExpenseSheetUser"].Width = 55;
                grdExpenses.Columns["Expences"].Width = 60;
                grdExpenses.Columns["Description"].Width = 195;
                grdExpenses.Columns["TrackSubName"].Width = 410;

                grdExpenses.Columns["Job_Number"].Width = 50;
                grdExpenses.Columns["ExpenseSheetItemNameSTATUS"].DisplayIndex = 13;
                grdExpenses.Columns["ExpenseSheetItemNameBILLSTATE"].DisplayIndex = 15;

                double count = 0;
                foreach (DataGridViewRow grdRowTime in grdExpenses.Rows)
                {
                    count = count + Convert.ToDouble(grdRowTime.Cells["Expences"].Value); //Calculate the Time

                    double setvalue = Convert.ToDouble(grdRowTime.Cells["Expences"].Value); //Round of Expenses value
                    double values = Math.Round(setvalue, 2);
                    grdRowTime.Cells["Expences"].Value = values.ToString();

                }

                //Dim count As Double
                //For Row As Integer = 0 To grdExpenses.Rows.Count - 1
                //    count = count + Convert.ToDouble(grdExpenses.Rows[Row].Cells["Expences"].Value)

                //Next
                lblTotalAmount.Text = "Total Amount $ " + count.ToString();
                //For Each grdColumn As DataGridViewColumn In grdExpenses.Columns
                //    If grdColumn.Index <> 0 And grdColumn.Index <> 1 Then
                //        grdExpenses.Columns[grdColumn.Index].AutoSizeMode = DataGridViewAutoSizeColumnsMode.Fill
                //    End If
                //Next
                DisbaledRowByAdmin(grdExpenses);

            }
            catch (Exception ex)
            {
                MessageBox.Show("fillExpences" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private frmShowTimeExpanseData GetPnlFormObject()
        {
            foreach (Control item in pnlShowTotalData.Controls)
            {
                if (item.Name.Equals("frmShowTimeExpanseData"))
                {
                    return (frmShowTimeExpanseData)item;
                }
            }
            return new frmShowTimeExpanseData();
        }

        private void CreateCellNew(IRow CurrentRow, int CellIndex, string Value, HSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
        }

        private void CreateCellNew2(IRow CurrentRow, int CellIndex, string Value, XSSFCellStyle Style)
        {
            
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
        }

        private void CreateCell(IRow CurrentRow, int CellIndex, string Value, XSSFCellStyle Style)
        {
            ICell Cell = CurrentRow.CreateCell(CellIndex);
            Cell.SetCellValue(Value);
            Cell.CellStyle = Style;
        }
        //private object createTimeExpenseRows(DataTable dt, HSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)
        private object createTimeExpenseRows(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)
        {

            
            //add column header
            var sheetRow = sheet.CreateRow(sheetRowIndex);
            int ColumnIndex = 0;

            foreach (DataColumn header in dt.Columns)
            {
                //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)

                //CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                //CreateCellNew(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                CreateCellNew2(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                ColumnIndex = ColumnIndex + 1;
            }

            //-----------------------------------------
            //Add column values 
            sheetRowIndex = sheetRowIndex + 1;
            sheetRow = sheet.CreateRow(sheetRowIndex);
            ColumnIndex = 0;
            foreach (DataColumn header in dt.Columns)
            {

                string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();
                sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                ColumnIndex = ColumnIndex + 1;

               
                
                
               
            }

            sheetRowIndex = sheetRowIndex + 1;
            //Get jobListID
            string jobListID = dt.Rows[rowindex]["JobListID"].ToString();

            //set Time sub grid data 
            //------------------------------------------------------
            DataTable SubDatatable = GetSubTimeGridData(jobListID);

            //SetSheetDatatable(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);
            SetSheetDatatableNew(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);

            //'-------------------------------------------------------

            //'set Expense sub grid data 
            //'------------------------------------------------------
            SubDatatable = GeExpensesData(jobListID);

            //SetSheetDatatable(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);
            SetSheetDatatableNew(SubDatatable, borderedCellStyle, ref sheetRowIndex, ref sheet);
             

            //'-------------------------------------------------------

            return null;
        }

        //private object SetSheetDatatableNew(DataTable dt, HSSFCellStyle borderedCellStyle, ref Int32 sheetRowIndex, ref ISheet sheet)
        private object SetSheetDatatableNew(DataTable dt, XSSFCellStyle borderedCellStyle, ref Int32 sheetRowIndex, ref ISheet sheet)
        {
            

            if (dt.Columns.Count > 0)
            {
                sheetRowIndex = sheetRowIndex + 1;
                int ColumnIndex = 1;
                var sheetRow = sheet.CreateRow(sheetRowIndex);
                foreach (DataColumn header in dt.Columns)
                {
                    //sheetRow.CreateCell(ColumnIndex).SetCellValue(header.ColumnName)
                    //CreateCell(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);


                    //CreateCellNew(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);
                    CreateCellNew2(sheetRow, ColumnIndex, header.ColumnName, borderedCellStyle);

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

                        if (ColumnIndex-1 == 2)
                        {
                            string editedValue ="";
                            editedValue = (DateTime.Parse(columnvalue.ToString())).ToString("dd/MM/yyyy");

                            sheetRow.CreateCell(ColumnIndex).SetCellValue(editedValue);
                        }
                        else
                        {
                            sheetRow.CreateCell(ColumnIndex).SetCellValue(columnvalue);
                        }

                        
                        
                        ColumnIndex = ColumnIndex + 1;



                    }
                    sheetRowIndex = sheetRowIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }
            return null;
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
                        ColumnIndex = ColumnIndex + 1;

                    }
                    sheetRowIndex = sheetRowIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }
            return null;
        }


        private DataTable GetTimeAndExpenseData()
        {
            string queryString = "SELECT  DISTINCT    JobList.JobListID, JobList.JobNumber As Job_Number,Company.CompanyName AS Client,JobList.Description, JobList.Handler AS PM, JobList.Borough AS Town, JobList.Address FROM  JobList LEFT OUTER JOIN Contacts ON JobList.ContactsID = Contacts.ContactsID LEFT OUTER JOIN      Company ON JobList.CompanyID = Company.CompanyID LEFT OUTER JOIN        JobTracking ON JobList.JobListID = JobTracking.JobListID     WHERE (JobList.IsDelete=0 or JobList.IsDelete is null)";

            DataTable dtJL = new DataTable();
            //dtJL = StMethod.GetListDT<TS_Clients>(queryString);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtJL = StMethod.GetListDTNew<TS_Clients>(queryString);
            }
            else
            {
                dtJL = StMethod.GetListDT<TS_Clients>(queryString);
            }


            return dtJL;
        }
        private DataTable GetSubTimeGridData(string jobListID)
        {
            string queryString = " SELECT TS_Time.Name AS Tuser, (SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as Job_Number,TS_Time.Date, TS_Time.Time,TS_Time.TrackSubName AS TrackSubComment,TS_Time.Description,TS_Time.status, TS_Time.AdminStatus, TS_Time.BillState FROM TS_Time Where JobListID = " + jobListID + "  and TS_Time.status Like '%Submit%'  order by TS_Time.Date ASC";
            DataTable dtJL = new DataTable();
            
            //dtJL = StMethod.GetListDT<TS_TimeStatus>(queryString);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtJL = StMethod.GetListDTNew<TS_TimeStatus>(queryString);
            }
            else
            {
                dtJL = StMethod.GetListDT<TS_TimeStatus>(queryString);
            }


            return dtJL;
        }
        private DataTable GeExpensesData(string jobListID)
        {
            string queryString = "SELECT TS_Expences.Name AS EUser, (SELECT JobNumber FROM Joblist WHERE JobListID=TS_Expences.JobListID) as [Job Number],TS_Expences.Date,TS_Expences.TrackSubName AS TrackSubComment,TS_Expences.Expences AS Amount, TS_Expences.Description, TS_Expences.status,TS_Expences.AdminStatus, TS_Expences.BillState  FROM TS_Expences where JobListID = " + jobListID + "  and TS_Expences.status Like'Submit' order by TS_Expences.Date ASC ";
            DataTable dtJL = new DataTable();

            //dtJL = StMethod.GetListDT<TS_Exp_Status>(queryString);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtJL = StMethod.GetListDTNew<TS_Exp_Status>(queryString);
            }
            else
            {
                dtJL = StMethod.GetListDT<TS_Exp_Status>(queryString);
            }

            return dtJL;
        }
        #endregion

        private void grdTimeAndExp_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                string errorMeg = e.Exception.ToString();
                //MessageBox.Show(e.Exception.ToString());
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdExpenses_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                string errorMeg = e.Exception.ToString();
                //MessageBox.Show(e.Exception.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdTimeAndExp_CellLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdTimeAndExp_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                //MessageBox.Show("Column number is " + e.ColumnIndex + "Value is " + e.Value.ToString());

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




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdExpenses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                //MessageBox.Show("Column number is  => " + e.ColumnIndex + "Value is => " + e.Value.ToString());

                if (e.ColumnIndex == 6)
                {
                    //e.Value = "MM-dd-yyyy";

                    //String value = e.Value as string;
                    ////if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

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

        private void txtTrackSubComment_TextChanged_1(object sender, EventArgs e)
        {
            try
            {

                fillTimeSheet();
                fillExpences();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdTimeAndExp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void contextMenuBillState_Click(object sender, EventArgs e)
        {
            //try
            //{

      
            //    //Dim choice As DialogResult = MessageBox.Show("Sure about to change all records Bill State?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            //  //  If(DialogResult.No = choice) Then
            //  //Return
            //  //      End If

            //    DialogResult choice;
            //    choice = MessageBox.Show("Sure about to change all records Bill State ? ",this.Text,MessageBoxButtons.YesNo,MessageBoxIcon.Warning);

            //    //MessageBox.Show(" 1 ");

            //    if(DialogResult.No == choice)
            //    {
            //        return;
            //    }



            //    //MessageBox.Show(" 2 ");

            //    //Dim IsInvoiceClick As Boolean = False
            //    //If(e.ClickedItem.Text = "Invoice") Then
            //    // IsInvoiceClick = True
            //    //End If

            //    //MenuItem clickedMenuItem = sender as MenuItem;
            //    //var menuText = clickedMenuItem.Text;

            //    Boolean IsInvoiceClick = false;

                


            //    //Dim IsInvoiceClick As Boolean = False
            //    //If(e.ClickedItem.Text = "Invoice") Then
            //    //   IsInvoiceClick = True
            //    //End If

            //    //contextMenuBillState
            //    ContextMenuStrip clickedMenuItem = sender as ContextMenuStrip;

            //    string menuText = clickedMenuItem.Text;

            //    MessageBox.Show("menuText =>" , menuText);




            //    //var clickedMenuItem2 = sender as MenuItem;
                
            //    //var menuText2 = clickedMenuItem.Text;

            //    //switch (menuText)
            //    //{
            //    //    case "Tiger":
            //    //        break;

            //    //    case "Lion":
            //    //        break;
            //    //}


            //    //object clickedMenuItem2 = sender as MenuItem;


            //    //MenuItem mi = sender as MenuItem;







            //    //KryptonContextMenu clickedMenuItem2 = sender as KryptonContextMenu;
            //    //   string title2 = clickedMenuItem2.ToString();
            //    //   MessageBox.Show(title2);

            //    //   MessageBox.Show(" 4 ");

            //    //   string title = mi.Text.ToString();
            //    //   MessageBox.Show(title);
            //    //   //string title = mi.Header.ToString();

            //    //   MessageBox.Show(" 5 ");



            //    //string title = contextMenuBillState.Text;

            //    //MessageBox.Show(title);
            //    //MessageBox.Show(contextMenuBillState.Text);

            //    //MessageBox.Show(" 0 ");

            //    //0 Not Invoice
            //    // 1 Invoice
            //    //contextMenuBillState.Items[0].Selected = true;

            //    //MessageBox.Show((contextMenuBillState.Items[0].ToString()));
            //    //MessageBox.Show((contextMenuBillState.Items[0].Text));

            //    //MessageBox.Show(" 1 ");

            //    //MessageBox.Show((contextMenuBillState.Items[1].ToString()));
            //    //MessageBox.Show((contextMenuBillState.Items[1].Text));

            //    //MessageBox.Show(" 2 ");



            //    //MessageBox.Show((contextMenuBillState.Items[0].Selected.ToString()));
            //    //MessageBox.Show((contextMenuBillState.Items[1].Selected.ToString()));



            //    //if (contextMenuBillState.Items[1].Selected == true)
            //    //{
            //    //    IsInvoiceClick = true;
            //    //    MessageBox.Show(" 4 ");
            //    //}
            //    //else
            //    //{

            //    //}


            //    //if (contextMenuBillState.Text == "Invoice")
            //    //{
            //    //    IsInvoiceClick = true;
            //    //    MessageBox.Show(" 4 ");
            //    //}

            //    //System.Windows.Forms.MenuItem Clicked_Item =  new System.Windows.Forms.MenuItem();


            //    //                System.Console.WriteLine(Clicked_Item.Text);
            //    //MessageBox.Show(Clicked_Item.Text);

            //    //MessageBox.Show(" 5 ");

            //    //System.Windows.Forms.MenuItem Clicked_Item2 = sender as System.Windows.Forms.MenuItem;

            //    //MessageBox.Show(" 6 ");

            //    //MessageBox.Show(Clicked_Item2.Text);
            //    ////System.Console.WriteLine(Clicked_Item2.Text);

            //    //MessageBox.Show(" 7 ");

            //    ////System.Windows.Forms.MenuItem Clicked_Item = sender as System.Windows.Forms.MenuItem;
            //    ////System.Console.WriteLine(Clicked_Item.Text);

            //    ////If(e.ClickedItem.Text = "Invoice") Then
            //    //// IsInvoiceClick = True
            //    ////End If

            //    //MessageBox.Show(" 5 ");

            //    //if (menuText == "Invoice")
            //    //{
            //    //    IsInvoiceClick = true;
            //    //}







            //    //MessageBox.Show(" 4 ");

            //    if (tbTimeAndExp.SelectedTab.Text == "Time")
            //    {
                                        
            //        var timesheetId = new ArrayList();

            //        //MessageBox.Show(" 5 ");

            //        for (int Row = 0, loopTo = grdTimeAndExp.Rows.Count - 1; Row <= loopTo; Row++)
            //        { 
            //            timesheetId.Add(grdTimeAndExp.Rows[Row].Cells["TimeSheetID"].Value);
            //        }

            //        //MessageBox.Show(" 6 ");

            //        string Query = String.Format("UPDATE TS_Time SET BillState=@BillState WHERE TimeSheetId IN ({0})", String.Join(",", timesheetId.ToArray()));

            //        //MessageBox.Show(Query);

            //        //Dim Query As String = String.Format("UPDATE TS_Time SET BillState=@BillState WHERE TimeSheetId IN ({0})", String.Join(",", timesheetId.ToArray()))

            //        //MessageBox.Show(Microsoft.VisualBasic.Interaction.IIf(IsInvoiceClick, "Invoice", "Not Invoice").ToString());

            //        string billState=string.Empty;

            //        //if (IsInvoiceClick == true)
            //        //{
            //        //    billState = "Invoice";
            //        //    //billState = "Not Invoice";
            //        //}
            //        //else if (IsInvoiceClick == false)
            //        //{
            //        //    //billState = "Invoice";
            //        //    billState = "Not Invoice";
            //        //}

            //        //MessageBox.Show("Time InvoiceClick = ", InvoiceClick);
            //        //MessageBox.Show("Time NonInvoiceClick = ", NonInvoiceClick);
                    

            //        if (InvoiceClick == "Invoice" && NonInvoiceClick == string.Empty)
            //        {
            //            billState = "Invoice";
            //        }
            //        else if (NonInvoiceClick == "Not Invoice" && InvoiceClick == string.Empty)
            //        {
            //            billState = "Not Invoice";
            //        }
            //        else
            //        {

            //        }


            //        List<SqlParameter> param = new List<SqlParameter>();
            //        param.Add(new SqlParameter("@BillState", billState));

            //        //param.Add(new SqlParameter("@BillState", Microsoft.VisualBasic.Interaction.IIf(IsInvoiceClick, "Invoice", "Not Invoice")));



            //        //MessageBox.Show(" 7 ");

            //        if (StMethod.UpdateRecord(Query, param) > 0)
            //        {
            //            //MessageBox.Show(" 8 ");
            //        }

            //        //MessageBox.Show(" 9 ");
            //        MessageBox.Show("Bill State change Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        fillTimeSheet();
            //        //MessageBox.Show(" 10 ");

            //    }
            //    else
            //    {
            //        var expSheetId = new ArrayList();

            //        for (int Row = 0, loopTo = grdExpenses.Rows.Count - 1; Row <= loopTo; Row++)
            //            expSheetId.Add(grdExpenses.Rows[Row].Cells["TimeSheetExpencesID"].Value);

            //        string Query = string.Format("UPDATE TS_Expences SET BillState=@BillState WHERE TimeSheetExpencesID IN ({0})", string.Join(",", expSheetId.ToArray()));

            //        string billState2=string.Empty;

            //        //if (IsInvoiceClick == true)
            //        //{
            //        //    billState2 = "Invoice";
            //        //    //billState2 = "Not Invoice";
            //        //}
            //        //else if (IsInvoiceClick == false)
            //        //{
            //        //    //billState2 = "Invoice";
            //        //    billState2 = "Not Invoice";
            //        //}

            //        //if(InvoiceClick!= string.Empty)
            //        //{
            //        //    billState2 = "Invoice";
            //        //}


            //        //if (NonInvoiceClick != string.Empty)
            //        //{
            //        //    billState2 = "Not Invoice";
            //        //}

            //        //MessageBox.Show("Expences InvoiceClick = ", InvoiceClick);
            //        //MessageBox.Show("Expences NonInvoiceClick = ", NonInvoiceClick);



            //        if (InvoiceClick == "Invoice" && NonInvoiceClick == string.Empty)
            //        {
            //            billState2 = "Invoice";
            //        }
            //        else if (NonInvoiceClick == "Not Invoice" && InvoiceClick == string.Empty)
            //        {
            //            billState2 = "Not Invoice";
            //        }
            //        else
            //        {
                            
            //        }


            //        //var param = new List<SqlClient.SqlParameter>();
            //        List<SqlParameter> param = new List<SqlParameter>();

            //        //param.Add(.SqlParameter("@BillState", IIf(IsInvoiceClick, "Invoice", "Not Invoice")))

            //        //param.Add(new SqlParameter("@BillState", Microsoft.VisualBasic.Interaction.IIf(IsInvoiceClick, "Invoice", "Not Invoice")));

            //        param.Add(new SqlParameter("@BillState", billState2));


            //        if (StMethod.UpdateRecord(Query, param) > 0)
            //        {
                     
            //        }
            //        MessageBox.Show("Bill State change Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        fillExpences();

            //    }





            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }

        private void toolstripMenuNotInvoice_Click(object sender, EventArgs e)
        {
            //IsInvoiceClick = false;

            //InvoiceClick = string.Empty;
            //NonInvoiceClick = string.Empty;

            //InvoiceClick = string.Empty;
            //NonInvoiceClick = "Not Invoice";

            //MessageBox.Show(" Inside NonInvoiceClick = InvoiceClick = ", InvoiceClick);
            //MessageBox.Show(" Inside NonInvoiceClick = NonInvoiceClick = ", NonInvoiceClick);

            
            //MessageBox.Show(" Inside NonInvoiceClick = NonInvoiceClick = ", NonInvoiceClick);

            //switch (menuText)
            //{
            //    case "Tiger":
            //        break;

            //    case "Lion":
            //        break;

            //}



        }

        private void toolStripMenuInvoice_Click(object sender, EventArgs e)
        {
            //IsInvoiceClick = true;

            //InvoiceClick = string.Empty;
            //NonInvoiceClick = string.Empty;

            //InvoiceClick = "Invoice";
            //NonInvoiceClick = string.Empty;

            //MessageBox.Show(" Inside InvoiceClick = InvoiceClick = ", InvoiceClick);
            //MessageBox.Show(" Inside InvoiceClick = NonInvoiceClick = ", NonInvoiceClick);

           
        }


        private void UpdateTime(string tableName, DataTable dt, EFDbContext sqltran)
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

        private void UpdateTimeNew(string tableName, DataTable dt, TestVariousInfo_WithDataEntities sqltran,DataTable dt2)
        {
            string[] columnNames = dt.Columns.Cast<DataColumn>().Select((s) => s.ColumnName).ToArray();
            string[] paramVar = columnNames.Select((s) => string.Format("@{0}", s)).ToArray();


            
            string[] tempVar = dt2.Columns.Cast<DataColumn>().Select((s) => s.ColumnName).ToArray();

            string[] whereVar = tempVar.Select((s) => string.Format("@{0}", s)).ToArray();

            //string query = string.Format("INSERT INTO {0} ({1}) VALUES({2})", tableName, string.Join(",", columnNames), string.Join(",", paramVar));

            string query = string.Format("UPDATE {0} SET ({1}) VALUES({2})", tableName, string.Join(",", columnNames), string.Join(",", paramVar));



            //query = query + " where TimeSheetID=@" + whereVar;


            //UPDATE TS_Time SET
            //(JobListID, Name, EmployeeDetailsId, TrackSubid, Time, Description, status, BillState, Date,
            //Comment, AdminStatus, TrackSubName)
            //VALUES(@JobListID, @Name, @EmployeeDetailsId, @TrackSubid, @Time,
            //@Description, @status, @BillState, @Date, @Comment, @AdminStatus, @TrackSubName)

            
            string query2 = string.Format("UPDATE {0} SET"+columnNames[0]+"=@",paramVar[0]+ ","+ columnNames[1]+"=@", paramVar[1]);


            //UPDATE TS_Time SET JobListID =@@JobListID,Name =@@Name

            query2 = string.Format("UPDATE " + tableName +" SET " + columnNames[0] + "=" + paramVar[0] + "," + columnNames[1] + "="+ paramVar[1]+ "," + columnNames[2] + "=" + paramVar[2] +"," + columnNames[3] + "=" + paramVar[3] + "," + columnNames[4] + "=" + paramVar[4] + "," + columnNames[5] + "=" + paramVar[5] + "," + columnNames[6] + "=" + paramVar[6]+ "," + columnNames[7] + "=" + paramVar[7]+"," + columnNames[8] + "=" + paramVar[8] +"," + columnNames[9] + "=" + paramVar[9] +"," + columnNames[10] + "=" + paramVar[10] +"," + columnNames[11] + "=" + paramVar[11]);


            //UPDATE TS_Time SET JobListID = @JobListID, Name = @Name,EmployeeDetailsId = @EmployeeDetailsId, TrackSubid = @TrackSubid, Time = @Time, Description = @Description, status = @status, BillState = @BillState, Date = @Date, Comment = @Comment, AdminStatus = @AdminStatus, TrackSubName = @TrackSubName

            //query2 = string.Format("UPDATE " + tableName + " SET " + columnNames[0] + "=" + paramVar[0] + "," + columnNames[1] + "=" + paramVar[1] + columnNames[2] + "=" + paramVar[2] + "," + columnNames[3] + "=" + paramVar[3] + "," + columnNames[4] + "=" + paramVar[4] + "," + columnNames[5] + "=" + paramVar[5] + "," + columnNames[6] + "=" + paramVar[6] + "," + columnNames[7] + "=" + paramVar[7] + "," + columnNames[8] + "=" + paramVar[8] + "," + columnNames[9] + "=" + paramVar[9] + "," + columnNames[10] + "=" + paramVar[10] + "," + columnNames[11] + "=" + paramVar[11] + "," + columnNames[12] + "=" + paramVar[12]);

            /*
             0      JobListID
             1      Name

             * */


            //string Query = "UPDATE TS_Time SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@Empid,  TrackSubid =@TrackSubid, Time =@Time, Description =@Description, status =@status, BillState =@BillState,Date=@Date,Comment=@Comment,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetID=@TimeSheetID";

            //10 comments

            //string query3 = " where TimeSheetID="+ whereVar[0];

            //Clipboard.SetText(query2 + Environment.NewLine + query3);

            query2 = query2 + " where TimeSheetID=" + whereVar[0];

            //Clipboard.SetText(" query2 is " + query2);

            //query2 is UPDATE TS_Time SET JobListID = @JobListID, Name = @Name, EmployeeDetailsId = @EmployeeDetailsId, TrackSubid = @TrackSubid, Time = @Time, Description = @Description, status = @status, BillState = @BillState, Date = @Date, Comment = @Comment, AdminStatus = @AdminStatus, TrackSubName = @TrackSubName

            //Clipboard.SetText("eee" + Environment.NewLine + "xxxx");

            foreach (DataRow dr in dt.Rows)
            {
                SqlCommand _cmd = new SqlCommand(query);
                //_cmd.Transaction = sqltran;
                List<SqlParameter> param = new List<SqlParameter>();
                foreach (string col in columnNames)
                {
                    //_cmd.Parameters.Add(new SqlParameter("@" + col, dr[col]));

                    param.Add(new SqlParameter("@" + col, dr[col]));

                    //foreach(string col2 in whereVar)
                    //{
                    //    param.Add(new SqlParameter("@" + col2, dr[col2])); 
                    //}

                }
                //_cmd.ExecuteNonQuery();
                //sqltran.Database.ExecuteSqlCommand(_cmd.CommandText, _cmd.Parameters);

                Clipboard.SetText(" query2 is " + query2);

                Clipboard.SetText("param" + Environment.NewLine + param.ToArray());

                //sqltran.Database.ExecuteSqlCommand(query, param.ToArray());


            }
        }


        private void contextMenuBillState_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                DialogResult choice;
                choice = MessageBox.Show("Sure about to change all records Bill State ? ", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (DialogResult.No == choice)
                {
                    return;
                }

                Boolean IsInvoiceClick = false;

                if(e.ClickedItem.Text == "Invoice")
                {
                    IsInvoiceClick = true;
                }


                if (tbTimeAndExp.SelectedTab.Text == "Time")
                {

                    var timesheetId = new ArrayList();                                   

                    for (int Row = 0, loopTo = grdTimeAndExp.Rows.Count - 1; Row <= loopTo; Row++)
                    {
                        timesheetId.Add(grdTimeAndExp.Rows[Row].Cells["TimeSheetID"].Value);
                    }

                    string Query = String.Format("UPDATE TS_Time SET BillState=@BillState WHERE TimeSheetId IN ({0})", String.Join(",", timesheetId.ToArray()));

                    //Dim Query As String = String.Format("UPDATE TS_Time SET BillState=@BillState WHERE TimeSheetId IN ({0})", String.Join(",", timesheetId.ToArray()))

                    //MessageBox.Show(Microsoft.VisualBasic.Interaction.IIf(IsInvoiceClick, "Invoice", "Not Invoice").ToString());
                                                 


                  


                    List<SqlParameter> param = new List<SqlParameter>();
                    
                    //param.Add(new SqlParameter("@BillState", billState));

                    param.Add(new SqlParameter("@BillState", Microsoft.VisualBasic.Interaction.IIf(IsInvoiceClick, "Invoice", "Not Invoice")));



                    //MessageBox.Show(" 7 ");

                    //if (StMethod.UpdateRecord(Query, param) > 0)
                    //{
                    //    //MessageBox.Show(" 8 ");
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.UpdateRecordNew(Query, param) > 0)
                        {
                            //MessageBox.Show(" 8 ");
                        }
                    }
                    else
                    {
                        if (StMethod.UpdateRecord(Query, param) > 0)
                        {
                            //MessageBox.Show(" 8 ");
                        }
                    }

                    MessageBox.Show("Bill State change Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTimeSheet();
                }
                else
                {
                    var expSheetId = new ArrayList();

                    for (int Row = 0, loopTo = grdExpenses.Rows.Count - 1; Row <= loopTo; Row++)
                        expSheetId.Add(grdExpenses.Rows[Row].Cells["TimeSheetExpencesID"].Value);

                    string Query = string.Format("UPDATE TS_Expences SET BillState=@BillState WHERE TimeSheetExpencesID IN ({0})", string.Join(",", expSheetId.ToArray()));

                    string billState2 = string.Empty;

                  


                    //var param = new List<SqlClient.SqlParameter>();
                    List<SqlParameter> param = new List<SqlParameter>();

                    //param.Add(.SqlParameter("@BillState", IIf(IsInvoiceClick, "Invoice", "Not Invoice")))

                    param.Add(new SqlParameter("@BillState", Microsoft.VisualBasic.Interaction.IIf(IsInvoiceClick, "Invoice", "Not Invoice")));

                    //param.Add(new SqlParameter("@BillState", billState2));


                    //if (StMethod.UpdateRecord(Query, param) > 0)
                    //{

                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.UpdateRecordNew(Query, param) > 0)
                        {

                        }
                    }
                    else
                    {
                        if (StMethod.UpdateRecord(Query, param) > 0)
                        {

                        }
                    }

                    MessageBox.Show("Bill State change Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillExpences();

                }



            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private int BackgroundProcessLogicMethodForUpdateTime(BackgroundWorker bw, int a)
        {
            int result = 0;
            

            try
            {
                //Thread.Sleep(20000);
                Thread.Sleep(5000);
                //MessageBox.Show("I was doing some update work in the background. please wait");

                //MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("System is doing some update work in the background. Please wait for some time. We will inform you once update is completed", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);


                foreach (DataGridViewRow drupdateTimeSheet in grdTimeAndExp.Rows)
                {

                    try
                    {
                        string Query = "UPDATE TS_Time SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@Empid,  TrackSubid =@TrackSubid, Time =@Time, Description =@Description, status =@status, BillState =@BillState,Date=@Date,Comment=@Comment,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetID=@TimeSheetID";

                        List<SqlParameter> param = new List<SqlParameter>();

                        //Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()

                        //Dim queryString1 As String = "use " + con.Database + " SELECT  EmployeeDetailsId FROM  EmployeeDetails where UserName = '" & drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString() & "' "

                        string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString() + "' ";





                        //int UpdateEmpId = StMethod.GetSingleInt(queryString1);

                        //Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);
                        Int64 FetchEmpId;


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            FetchEmpId = StMethod.GetSingleInt64New(queryString1);
                        }
                        else
                        {
                            FetchEmpId = StMethod.GetSingleInt64(queryString1);
                        }

                        Int64 UpdateEmpId = Convert.ToInt64(FetchEmpId);

                        //Dim queryString1 As String = " SELECT  Id FROM  EmployeeDetails where UserName = '" & drupdateTimeSheet.Cells("TimeSheetUser").Value.ToString() & "' "



                        //param.Add(new SqlParameter("@JobListID", drupdateTimeSheet.Cells["JobListID"].Value.ToString()));                                
                        param.Add(new SqlParameter("@JobListID", Convert.ToInt64(drupdateTimeSheet.Cells["JobListID"].Value.ToString())));

                        param.Add(new SqlParameter("@Name", drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString()));
                        param.Add(new SqlParameter("@EmpId", UpdateEmpId));
                        param.Add(new SqlParameter("@TrackSubid", drupdateTimeSheet.Cells["TrackSubid"].Value.ToString()));
                        param.Add(new SqlParameter("@TrackSubName", drupdateTimeSheet.Cells["TrackSubName"].Value.ToString()));
                        param.Add(new SqlParameter("@Time", drupdateTimeSheet.Cells["Time"].Value.ToString()));
                        param.Add(new SqlParameter("@Description", drupdateTimeSheet.Cells["Description"].Value.ToString()));
                        param.Add(new SqlParameter("@status", drupdateTimeSheet.Cells["TimeItemNameSTATUS"].Value.ToString()));
                        param.Add(new SqlParameter("@BillState", drupdateTimeSheet.Cells["TimeItemNameBILLSTATE"].Value.ToString()));




                        string DueDate = string.Empty;
                        DueDate = drupdateTimeSheet.Cells["Date"].Value.ToString();

                        DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));
                        string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                        param.Add(new SqlParameter("@Date", s1.ToString()));

                        //param.Add(new SqlParameter("@Date", drupdateTimeSheet.Cells["Date"].Value.ToString()));

                        param.Add(new SqlParameter("@Comment", drupdateTimeSheet.Cells["Comment"].Value.ToString()));

                        if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                        {
                            param.Add(new SqlParameter("@AdminStatus", drupdateTimeSheet.Cells["AdminStatus"].Value.ToString()));
                        }
                        else
                        {

                            param.Add(new SqlParameter("@AdminStatus", drupdateTimeSheet.Cells["AdminStatus"].Value.ToString()));
                        }


                        //string Query = "UPDATE TS_Time SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@Empid,  TrackSubid =@TrackSubid, Time =@Time, Description =@Description, status =@status, BillState =@BillState,Date=@Date,Comment=@Comment,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetID=@TimeSheetID";




                        param.Add(new SqlParameter("@TimeSheetID", drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString()));

                        //updateQuery.Append("UPDATE [" + harltabcol[i, 1] + "] SET [" + harltabcol[i, 0] + "] =N'" + temp1 + "' WHERE " + harltabcol[i, 0] + "='" + temp + "';");

                        //updateQuery.Append(Query + ";");

                        //updateQuery.Append(Query); 

                        //if (StMethod.UpdateRecord(Query, param) > 0)
                        //{
                        //    //MessageBox.Show("updated");
                        //}


                        //dtUpdate.Rows.Add(Convert.ToInt64(drupdateTimeSheet.Cells["JobListID"].Value.ToString()), drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString(), UpdateEmpId, drupdateTimeSheet.Cells["TrackSubid"].Value.ToString(), drupdateTimeSheet.Cells["Time"].Value.ToString(), drupdateTimeSheet.Cells["Description"].Value.ToString(), drupdateTimeSheet.Cells["TimeItemNameSTATUS"].Value.ToString(), drupdateTimeSheet.Cells["TimeItemNameBILLSTATE"].Value.ToString(), s1.ToString(), drupdateTimeSheet.Cells["Comment"].Value.ToString(), drupdateTimeSheet.Cells["AdminStatus"].Value.ToString(), drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString(), drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString());


                        //dtUpdate.Rows.Add(Convert.ToInt64(drupdateTimeSheet.Cells["JobListID"].Value.ToString()), drupdateTimeSheet.Cells["TimeSheetUser"].Value.ToString(), UpdateEmpId, drupdateTimeSheet.Cells["TrackSubid"].Value.ToString(), drupdateTimeSheet.Cells["Time"].Value.ToString(), drupdateTimeSheet.Cells["Description"].Value.ToString(), drupdateTimeSheet.Cells["TimeItemNameSTATUS"].Value.ToString(), drupdateTimeSheet.Cells["TimeItemNameBILLSTATE"].Value.ToString(), s1.ToString(), drupdateTimeSheet.Cells["Comment"].Value.ToString(), drupdateTimeSheet.Cells["AdminStatus"].Value.ToString(), drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString());

                        //dtUpdate2.Rows.Add(drupdateTimeSheet.Cells["TimeSheetID"].Value.ToString());


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            if (StMethod.UpdateRecordNew(Query, param) > 0)
                            {
                                //MessageBox.Show("updated");
                            }
                        }
                        else
                        {
                            if (StMethod.UpdateRecord(Query, param) > 0)
                            {
                                //MessageBox.Show("updated");
                            }
                        }






                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());

                    }

                }
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            try 
            {

                BackgroundWorker helperBW = sender as BackgroundWorker;
                int arg = (int)e.Argument;
                e.Result = BackgroundProcessLogicMethodForUpdateTime(helperBW, arg);
                if (helperBW.CancellationPending)
                {
                    e.Cancel = true;
                }





            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else if (e.Cancelled)
                {
                    // Next, handle the case where the user canceled 
                    // the operation.
                    // Note that due to a race condition in 
                    // the DoWork event handler, the Cancelled
                    // flag may not have been set, even though
                    // CancelAsync was called.
                    //resultLabel.Text = "Canceled";

                }
                else
                {
                    // Finally, handle the case where the operation 
                    // succeeded.
                    //resultLabel.Text = e.Result.ToString();

                    MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTimeSheet();
                    fillExpences();
                    backgroundWorker1.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                try
                {

                    BackgroundWorker helperBW = sender as BackgroundWorker;
                    int arg = (int)e.Argument;
                    e.Result = BackgroundProcessLogicMethodForInsertTime(helperBW, arg);
                    if (helperBW.CancellationPending)
                    {
                        e.Cancel = true;
                    }
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

        private int BackgroundProcessLogicMethodForInsertTime(BackgroundWorker bw, int a)
        {
            int result = 0;

            try
            {

                Thread.Sleep(5000);
                //MessageBox.Show("I was doing some update work in the background. please wait");

                //MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("System is doing some insert work in the background. Please wait for some time.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);



                foreach (DataGridViewRow dr in grdTimeAndExp.Rows) //DirectCast(grdTimeAndExp.Rows[cnt].Cells["Client#"), System.Windows.Forms.DataGridViewComboBoxCell].Value))
                {

                    if (dr.Cells["TimeSheetID"].Value.ToString() == "0")
                    {
                        //If str1 = "0" Then
                        
                        //string username = grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"].Value.ToString();


                        //Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()



                        //Dim queryString1 As String = "use " + con.Database + " SELECT  EmployeeDetailsId FROM  EmployeeDetails where UserName = '" & grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"].Value.ToString() & "' "

                        string queryString1 = "SELECT  Id FROM  EmployeeDetails where UserName = '" + grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"].Value.ToString() + "' ";



                        //int EmpId = StMethod.GetSingleInt(queryString1);

                        //long EmpId = Convert.ToInt64(StMethod.GetSingleInt(queryString1));
                        //Int64 EmpId = Convert.ToInt64(StMethod.GetSingleInt(queryString1));


                        //Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);
                        Int64 FetchEmpId;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            FetchEmpId = StMethod.GetSingleInt64New(queryString1);

                        }
                        else
                        {
                            FetchEmpId = StMethod.GetSingleInt64(queryString1);

                        }


                        //Int64 EmpId = Convert.ToInt64(FetchEmpId);

                        //Int64 EmpId;
                        Nullable<Int64> EmpId = null;
                        EmpId = Convert.ToInt64(FetchEmpId);

                        //DataSet ds1 = new DataSet();
                        //ds1 = StMethod.GetListDS<EmployeeData>(queryString1);


                        /*

                        DataTable dt = new DataTable();
                        //dt=StMethod.GetListDT<EmployeeData>(queryString1);

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            dt = StMethod.GetListDTNew<EmployeeData>(queryString1);

                        }
                        else
                        {
                            dt = StMethod.GetListDT<EmployeeData>(queryString1);
                        }

                        if (dt.Rows.Count == 1)
                        {
                            EmpId = Convert.ToInt64(dt.Rows[0][0].ToString());
                        }


                        */

                        //if (ds1.Tables[0].Rows.Count == 1)
                        //{
                        //    EmpId= Convert.ToInt64(ds1.Tables[0].Rows[0],);

                        //}




                        //If(dt1.Rows.Count = 1) Then

                        //   EmpId = Convert.ToInt32(dt1.Rows(0)(0).ToString())

                        //End If




                        //long vOut = Convert.ToInt64(vIn);

                        //username = DirectCast(grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"),System.windows.foem.dat


                        string Date101 = null;
                        string Date102 = null;

                        Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                        string FinalDateUpdate = string.Empty;


                        if (grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value == null || grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString()))
                        {
                            // here is your message box...


                        }
                        else
                        {
                            //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                            Date101 = string.Format("{0:dd/MM/yyyy}", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString());

                        }

                        if (grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Tag == null || grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Tag.ToString()))
                        {
                            // here is your message box...

                            //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                            //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                            //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                            Date102 = string.Format("{0:dd/MM/yyyy}", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString());

                            //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                            ActionDateUpdate = DateTime.Parse(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString());

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
                            Date102 = grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Tag.ToString();
                        }




                        string query = "INSERT INTO TS_Time(JobListID, EmployeeDetailsId,  Name, TrackSubid,TrackSubName, Time, Description, status, BillState,Date,Comment,AdminStatus,JobTrackingId)VALUES(@JobListID, @EmployeeDetailsId,  @Name, @TrackSubid,@TrackSubName, @Time, @Description, @status, @BillState,@Date,@Comment,@AdminStatus,@JobTrackingId)";
                        List<SqlParameter> param = new List<SqlParameter>();



                        //param.Add(new SqlParameter("@JobListID", SelectJobListID));

                        param.Add(new SqlParameter("@JobListID", Convert.ToInt64(SelectJobListID)));

                        param.Add(new SqlParameter("@Name", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeSheetUser"].Value.ToString()));




                        param.Add(new SqlParameter("@EmployeeDetailsId", EmpId));


                        param.Add(new SqlParameter("@TrackSubid", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TrackSubid"].Value.ToString()));


                        param.Add(new SqlParameter("@TrackSubName", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TrackSubName"].Value.ToString()));
                        param.Add(new SqlParameter("@Time", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Time"].Value.ToString()));
                        param.Add(new SqlParameter("@Description", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Description"].Value.ToString()));
                        param.Add(new SqlParameter("@status", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeItemNameSTATUS"].Value.ToString()));

                        string DueDate = string.Empty;
                        //DueDate = grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString();

                        //DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));
                        //string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                        //param.Add(new SqlParameter("@Date", s1.ToString()));

                        param.Add(new SqlParameter("@Date", Date102));

                        //param.Add(new SqlParameter("@Date", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString()));


                        param.Add(new SqlParameter("@Comment", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Comment"].Value.ToString()));
                        param.Add(new SqlParameter("@BillState", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["TimeItemNameBILLSTATE"].Value.ToString()));
                        param.Add(new SqlParameter("@AdminStatus", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["AdminStatus"].Value.ToString()));

                        //param.Add(new SqlParameter("@JobTrackingId", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString()));

                        //MessageBox.Show("Without " + grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString());

                        //Int64 checkvalue = Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString());



                        //MessageBox.Show("With " + checkvalue);

                        param.Add(new SqlParameter("@JobTrackingId", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString()));

                        //Int64 checkvalue = Convert.ToInt64(grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["JobTrackingId"].Value.ToString());

                        //param.Add(new SqlParameter("@JobTrackingId", checkvalue ));


                        //if (StMethod.UpdateRecord(query, param) > 0)
                        //{
                        //    //MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        //    DialogResult choiceButton = KryptonMessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //    //fillTimeSheet()
                        //}

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {


                            if (StMethod.UpdateRecordNew(query, param) > 0)
                            {
                                //MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                //DialogResult choiceButton = KryptonMessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //fillTimeSheet()
                            }
                        }
                        else
                        {

                            if (StMethod.UpdateRecord(query, param) > 0)
                            {
                                //MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                //DialogResult choiceButton = KryptonMessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //fillTimeSheet()
                            }
                        }





                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return result;
        }

         private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else if (e.Cancelled)
                {
                    // Next, handle the case where the user canceled 
                    // the operation.
                    // Note that due to a race condition in 
                    // the DoWork event handler, the Cancelled
                    // flag may not have been set, even though
                    // CancelAsync was called.
                    //resultLabel.Text = "Canceled";

                }
                else
                {
                    // Finally, handle the case where the operation 
                    // succeeded.
                    //resultLabel.Text = e.Result.ToString();
                    MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTimeSheet();
                    fillExpences();
                    backgroundWorker2.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                BackgroundWorker helperBW = sender as BackgroundWorker;
                int arg = (int)e.Argument;
                e.Result = BackgroundProcessLogicMethodForUpdateExpense(helperBW, arg);
                if (helperBW.CancellationPending)
                {
                    e.Cancel = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void backgroundWorker4_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else if (e.Cancelled)
                {
                    // Next, handle the case where the user canceled 
                    // the operation.
                    // Note that due to a race condition in 
                    // the DoWork event handler, the Cancelled
                    // flag may not have been set, even though
                    // CancelAsync was called.
                    //resultLabel.Text = "Canceled";

                }
                else
                {
                    // Finally, handle the case where the operation 
                    // succeeded.
                    //resultLabel.Text = e.Result.ToString();

                    MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTimeSheet();
                    fillExpences();
                    backgroundWorker4.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }





        //



        private int BackgroundProcessLogicMethodForUpdateExpense(BackgroundWorker bw, int a)
        {
            int result = 0;


            try
            {
                //Thread.Sleep(20000);
                Thread.Sleep(5000);
                //MessageBox.Show("I was doing some update work in the background. please wait");

                //MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show("System is doing some update work in the background. Please wait for some time.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);



                foreach (DataGridViewRow drUpdate in grdExpenses.Rows)
                {

                    //MessageBox.Show("2047");

                    string Query = "UPDATE TS_Expences SET  JobListID =@JobListID,  Name =@Name, EmployeeDetailsId=@EmployeeDetailsId,  TrackSubid =@TrackSubid, Expences =@Expences, Description =@Description, status =@status, BillState =@BillState,AdminStatus=@AdminStatus,TrackSubName=@TrackSubName where TimeSheetExpencesID=@TimeSheetExpencesID";
                    List<SqlParameter> param = new List<SqlParameter>();

                    //MessageBox.Show("Query => " + Query);


                    //string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + drUpdate.Cells["ExpenseSheetUser"].Value.ToString() + "' ";

                    string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + drUpdate.Cells["ExpenseSheetUser"].Value.ToString() + "' ";

                    //int UpdateEmpId = StMethod.GetSingleInt(queryString1);

                    //MessageBox.Show("queryString1 => " + queryString1);

                    //int FetchEmpId2 = StMethod.GetSingleInt(queryString1);
                    //Int64 UpdateEmpId = Convert.ToInt64(FetchEmpId2);

                    //Int64 FetchEmpId2 = StMethod.GetSingleInt64(queryString1);
                    Int64 FetchEmpId2;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        FetchEmpId2 = StMethod.GetSingleInt64New(queryString1);


                    }
                    else
                    {
                        FetchEmpId2 = StMethod.GetSingleInt64(queryString1);

                    }


                    //MessageBox.Show("FetchEmpId2 => " + FetchEmpId2);

                    Int64 UpdateEmpId = Convert.ToInt64(FetchEmpId2);

                    //MessageBox.Show("UpdateEmpId => " + UpdateEmpId);

                    param.Add(new SqlParameter("@JobListID", Convert.ToInt64(drUpdate.Cells["JobListID"].Value.ToString())));

                    //param.Add(new SqlParameter("@JobListID", drUpdate.Cells["JobListID"].Value.ToString()));


                    //MessageBox.Show("JobListID => " + Convert.ToInt64(drUpdate.Cells["JobListID"].Value.ToString()));

                    param.Add(new SqlParameter("@Name", drUpdate.Cells["ExpenseSheetUser"].Value.ToString()));
                    param.Add(new SqlParameter("@EmployeeDetailsId", UpdateEmpId));
                    param.Add(new SqlParameter("@TrackSubid", drUpdate.Cells["TrackSubid"].Value.ToString()));
                    param.Add(new SqlParameter("@TrackSubName", drUpdate.Cells["TrackSubName"].Value.ToString()));
                    param.Add(new SqlParameter("@Expences", drUpdate.Cells["Expences"].Value.ToString()));
                    param.Add(new SqlParameter("@Description", drUpdate.Cells["Description"].Value.ToString()));
                    param.Add(new SqlParameter("@status", drUpdate.Cells["ExpenseSheetItemNameSTATUS"].Value.ToString()));
                    param.Add(new SqlParameter("@BillState", drUpdate.Cells["ExpenseSheetItemNameBILLSTATE"].Value.ToString()));

                    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                    {
                        param.Add(new SqlParameter("@AdminStatus", drUpdate.Cells["AdminStatus"].Value.ToString()));
                    }
                    else
                    {
                        param.Add(new SqlParameter("@AdminStatus", drUpdate.Cells["AdminStatus"].Value.ToString()));
                    }

                    param.Add(new SqlParameter("@TimeSheetExpencesID", drUpdate.Cells["TimeSheetExpencesID"].Value.ToString()));

                    //if (StMethod.UpdateRecord(Query, param) > 0)
                    //{
                    //    //MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    //    //MessageBox.Show("Update Successfully!");
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.UpdateRecordNew(Query, param) > 0)
                        {
                            //MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            //MessageBox.Show("Update Successfully!");
                        }
                    }
                    else
                    {
                        if (StMethod.UpdateRecord(Query, param) > 0)
                        {
                            //MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                            //MessageBox.Show("Update Successfully!");
                        }
                    }

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return result;
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {

            try
            {
                BackgroundWorker helperBW = sender as BackgroundWorker;
                int arg = (int)e.Argument;
                e.Result = BackgroundProcessLogicMethodForInsertExpense(helperBW, arg);
                if (helperBW.CancellationPending)
                {
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }


        private int BackgroundProcessLogicMethodForInsertExpense(BackgroundWorker bw, int a)
        {

            try
            {

                foreach (DataGridViewRow dr in grdExpenses.Rows)
                {

                    if (dr.Cells["TimeSheetExpencesID"].Value.ToString() == "0")
                    {
                        //If str = "0" Then

                        if (!backgroundWorker3.IsBusy)
                        {
                            backgroundWorker3.RunWorkerAsync(2000);
                            //backgroundWorker1.RunWorkerAsync();
                        }
                        else
                        {
                            //backgroundWorker1.CancelAsync();
                        }


                        string Date101 = null;
                        string Date102 = null;

                        Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                        string FinalDateUpdate = string.Empty;


                        if (grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value == null || grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString()))
                        {
                            // here is your message box...


                        }
                        else
                        {
                            //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                            Date101 = string.Format("{0:dd/MM/yyyy}", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString());

                        }

                        if (grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Tag == null || grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Tag.ToString()))
                        {
                            // here is your message box...

                            //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                            //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                            //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                            //Date102 = string.Format("{0:dd/MM/yyyy}", grdTimeAndExp.Rows[grdTimeAndExp.Rows.Count - 1].Cells["Date"].Value.ToString());

                            //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                            ActionDateUpdate = DateTime.Parse(grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString());

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
                            Date102 = grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Tag.ToString();
                        }


                        string query = "INSERT INTO TS_Expences(JobListID, EmployeeDetailsId,Name,TrackSubid,TrackSubName,  Expences,  Description, status, BillState,Date,Comment,AdminStatus)VALUES(@JobListID, @EmployeeDetailsId,  @Name, @TrackSubid,@TrackSubName, @Expences, @Description, @status, @BillState,@Date,@Comment,@AdminStatus)";

                        //MessageBox.Show("query => " + query);

                        //string query = "INSERT INTO TS_Expences(JobListID, EmployeeDetailsId,Name,TrackSubid,TrackSubName,  Expences,  Description, status, BillState,Date,Comment,AdminStatus )VALUES(@JobListID, @EmployeeDetailsId,  @Name, @TrackSubid,@TrackSubName, @Expences, @Description, @status, @BillState,@Date,@Comment,@AdminStatus)";


                        List<SqlParameter> param = new List<SqlParameter>();

                        string queryString1 = " SELECT  Id FROM  EmployeeDetails where UserName = '" + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetUser"].Value.ToString() + "' ";

                        //MessageBox.Show("queryString1 => " + queryString1);

                        //int InsertEmpId = StMethod.GetSingleInt(queryString1);

                        //int FetchEmpId = StMethod.GetSingleInt(queryString1);

                        //Int64 FetchEmpId = StMethod.GetSingleInt64(queryString1);

                        Int64 FetchEmpId;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            FetchEmpId = StMethod.GetSingleInt64New(queryString1);

                        }
                        else
                        {
                            FetchEmpId = StMethod.GetSingleInt64(queryString1);
                        }


                        Int64 InsertEmpId = Convert.ToInt64(FetchEmpId);

                        //MessageBox.Show("FetchEmpId => " + FetchEmpId);
                        //MessageBox.Show("InsertEmpId => " + InsertEmpId);

                        param.Add(new SqlParameter("@JobListID", Convert.ToInt64(SelectJobListID)));

                        //param.Add(new SqlParameter("@JobListID", SelectJobListID));

                        //MessageBox.Show("JobListID => " + Convert.ToInt64(SelectJobListID));


                        param.Add(new SqlParameter("@Name", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetUser"].Value.ToString()));
                        param.Add(new SqlParameter("@EmployeeDetailsId", InsertEmpId));



                        //MessageBox.Show("Name => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetUser"].Value.ToString());
                        //MessageBox.Show("EmployeeDetailsId => " + InsertEmpId);

                        param.Add(new SqlParameter("@TrackSubid", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TrackSubid"].Value.ToString()));

                        //MessageBox.Show("TrackSubid => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TrackSubid"].Value.ToString());

                        param.Add(new SqlParameter("@TrackSubName", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TrackSubName"].Value.ToString()));
                        param.Add(new SqlParameter("@Expences", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Expences"].Value.ToString()));


                        //MessageBox.Show("TrackSubName => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["TrackSubName"].Value.ToString());
                        //MessageBox.Show("Expences => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Expences"].Value.ToString());

                        param.Add(new SqlParameter("@Description", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Description"].Value.ToString()));
                        param.Add(new SqlParameter("@status", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetItemNameSTATUS"].Value.ToString()));
                        param.Add(new SqlParameter("@BillState", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetItemNameBILLSTATE"].Value.ToString()));


                        //MessageBox.Show("Description => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Description"].Value.ToString());
                        //MessageBox.Show("status => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetItemNameSTATUS"].Value.ToString());
                        //MessageBox.Show("BillState => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["ExpenseSheetItemNameBILLSTATE"].Value.ToString());



                        //string DueDate = string.Empty;
                        //DueDate = grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString();

                        //DateTime datevalue = (Convert.ToDateTime(DueDate.ToString()));
                        //string s1 = DateTime.Parse(datevalue.ToString()).ToString("MM/dd/yyyy hh:mm:ss tt");

                        param.Add(new SqlParameter("@Date", Date102));


                        //MessageBox.Show("Date => " + Date102);

                        //param.Add(new SqlParameter("@Date", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Date"].Value.ToString()));

                        param.Add(new SqlParameter("@Comment", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Comment"].Value.ToString()));

                        //MessageBox.Show("Comment => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["Comment"].Value.ToString());


                        param.Add(new SqlParameter("@AdminStatus", grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["AdminStatus"].Value.ToString()));

                        //MessageBox.Show("AdminStatus => " + grdExpenses.Rows[grdExpenses.Rows.Count - 1].Cells["AdminStatus"].Value.ToString());

                        //if (StMethod.UpdateRecord(query, param) > 0)
                        //{
                        //    //MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //    //fillExpences()
                        //}



                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            if (StMethod.UpdateRecordNew(query, param) > 0)
                            {
                                //MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //fillExpences()
                            }


                        }
                        else
                        {
                            if (StMethod.UpdateRecord(query, param) > 0)
                            {
                                //MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                //fillExpences()
                            }


                        }


                    }


                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            return result;
        }

            private void backgroundWorker3_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message);
                }
                else if (e.Cancelled)
                {
                    // Next, handle the case where the user canceled 
                    // the operation.
                    // Note that due to a race condition in 
                    // the DoWork event handler, the Cancelled
                    // flag may not have been set, even though
                    // CancelAsync was called.
                    //resultLabel.Text = "Canceled";

                }
                else
                {
                    // Finally, handle the case where the operation 
                    // succeeded.
                    //resultLabel.Text = e.Result.ToString();

                    MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillTimeSheet();
                    fillExpences();
                    backgroundWorker3.Dispose();
                }
            }            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        ///

    }
}