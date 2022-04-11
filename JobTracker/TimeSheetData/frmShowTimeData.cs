using DataAccessLayer;
using DataAccessLayer.Model;
using JobTracker.Classes;
using JobTracker.JobTrackingMDIForm;
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

namespace JobTracker.TimeSheetData
{
    public partial class frmShowTimeData : Form
    {
        #region Declaration
        public JobAndTrackingMDI mdio;
        ManagerRepository repo = new ManagerRepository();
        public string str1;
        ManagerRepository repo2 = new ManagerRepository("");


        private string _JobNumber;
        public string JobNumber
        {
            get
            {
                return _JobNumber;
            }
            set
            {
                _JobNumber = value;
            }
        }
        private int _JobListId;
        public int JobListId
        {
            get
            {
                return _JobListId;
            }
            set
            {
                _JobListId = value;
            }
        }
        private string _PM;
        public string PM
        {
            get
            {
                return _PM;
            }
            set
            {
                _PM = value;
            }
        }

        public System.Drawing.Color VeCostColor { get; set; }

        public bool IsVisible { get; set; }
        #endregion

        public frmShowTimeData()
        {
            InitializeComponent();
        }

        #region Events
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void frmShowTimeData_Load(System.Object sender, System.EventArgs e)
        {
            //  fillgrdTimeSheetData()
            btnAdd.Visible = false;
        }
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (btnAdd.Text == "Add")
                {
                    //TimeSheet sheet = new TimeSheet();
                    //List<TimeSheet> SelectTime_data = (List<TimeSheet>)grdShowTimeData.DataSource;
                    DataTable dt = new DataTable();

                    dt = (DataTable)grdShowTimeData.DataSource;
                    DataRow dr = dt.NewRow();
                    dr["JobNumber"] = JobNumber;
                    dr["PM"] = PM;
                    dt.Rows.Add(dr);
                    grdShowTimeData.DataSource = dt;
                    btnAdd.Text = "Save";
                }
                else
                {

                    string query = "INSERT INTO ImportTimeSheetData(JobNumber, PM, Name, Duration)VALUES(@JobNumber,@PM,@Name,@Duration)";
                    List<System.Data.SqlClient.SqlParameter> param = new List<System.Data.SqlClient.SqlParameter>();
                    param.Add(new SqlParameter("@JobNumber", JobNumber));
                    param.Add(new SqlParameter("@PM", PM));
                    param.Add(new SqlParameter("@Name", grdShowTimeData.Rows[grdShowTimeData.Rows.Count - 1].Cells["Name"].Value.ToString()));
                    param.Add(new SqlParameter("@Duration", grdShowTimeData.Rows[grdShowTimeData.Rows.Count - 1].Cells["Duration"].Value.ToString()));

                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    if (db.Database.ExecuteSqlCommand(query, param) > 0)
                    //    {
                    //        // MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    //        btnAdd.Text = "Add";
                    //    }
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            if (db.Database.ExecuteSqlCommand(query, param) > 0)
                            {
                                // MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                btnAdd.Text = "Add";
                            }
                        }
                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            if (db.Database.ExecuteSqlCommand(query, param) > 0)
                            {
                                // MessageBox.Show("Save Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                btnAdd.Text = "Add";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void grdShowTimeData_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            //*** Running Code****************

            //If e.ColumnIndex = 0 Then

            //    If btnAdd.Text = "Save" Then
            //        btnAdd_Click(sender, e)
            //    End If

            //    Dim Query As String = "UPDATE ImportTimeSheetData SET Duration=@Duration,Name=@Name  WHERE JobNumber=@JobNumber and PM=@PM"
            //    Dim param As New List(Of SqlClient.SqlParameter)
            //    With (New DataAccessLayer)
            //        param.Add(.SqlParameter("@Duration", grdShowTimeData.Rows[grdShowTimeData.Rows.Count - 1).Cells("Duration"].Value.ToString()))
            //        param.Add(.SqlParameter("@Name", grdShowTimeData.Rows[grdShowTimeData.Rows.Count - 1).Cells("Name"].Value.ToString()))
            //        param.Add(.SqlParameter("@JobNumber", grdShowTimeData.Rows[grdShowTimeData.Rows.Count - 1).Cells("JobNumber"].Value.ToString()))
            //        param.Add(.SqlParameter("@PM", grdShowTimeData.Rows[grdShowTimeData.Rows.Count - 1).Cells("PM"].Value.ToString()))
            //        If .ParameterSqlExcecuteQuery(New SqlClient.SqlCommand(Query), param) > 0 Then
            //            MessageBox.Show("Update Successfully!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            //        End If
            //    End With
            //End If

        }
        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            btnAdd.Visible = false;
            btnAdd.Text = "Add";
            fillgrdTimeSheetData();
        }
        private void chkGroupBy_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            fillgrdTimeSheetData();
        }
        private void cmbDistinctName_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            fillgrdTimeSheetData();
        }
        #endregion

        #region Methods
        public void FillcmbDistinctName()
        {
            try
            {
                //var ShowDistinctDt = repo.db.Database.SqlQuery<string>("Select distinct Name FROM TS_Time where JobListID=" + JobListId + "").ToList();

                var ShowDistinctDt = repo.db.Database.SqlQuery<string>("Select distinct Name FROM TS_Time where JobListID=" + JobListId + "").ToList();
                ShowDistinctDt = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    ShowDistinctDt = repo2.db2.Database.SqlQuery<string>("Select distinct Name FROM TS_Time where JobListID=" + JobListId + "").ToList();
                }
                else
                {
                    ShowDistinctDt = repo.db.Database.SqlQuery<string>("Select distinct Name FROM TS_Time where JobListID=" + JobListId + "").ToList();

                }
                //if (ShowDistinctDt.Count > 0)
                //{
                //    DataRow newRow = ShowDistinctDt.NewRow();
                //    newRow["Name"] = "";
                //    //ShowDistinctDt.Rows.Add(newRow)
                //    ShowDistinctDt.Rows.InsertAt(newRow, 0);
                //}
                cmbDistinctName.DataSource = ShowDistinctDt;
                cmbDistinctName.DisplayMember = "Name";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fillgrdTimeSheetData()
        {
            try
            {
                //grdShowTimeData
                //.DataSource = (New DataAccessLayer).Filldatatable("SELECT ID,JobNumber,PM,Name,Duration FROM ImportTimeSheetData Where JobNumber='" + JobNumber + "'")  
                //DataTable showTimedataTable = new DataTable();
                //DataTable dtSelectTime = new DataTable();




                //string sQuery = "SELECT  Name, Sum(Time) as Time,'' as TimeSheetID,EmployeeDetailsId, " +
                //    "JobListID,cast(0 as float) As BilableRate,cast(0 as float) as Total," +
                //    "STRING_AGG(CONVERT(NVARCHAR(max), ISNULL(Name,'N/A')), ',') AS csv FROM TS_Time where JobListID=" + JobListId;



                //Orginal code

                //if (!string.IsNullOrEmpty(cmbDistinctName.Text))
                //{
                //    sQuery += " and Name = '" + cmbDistinctName.Text + "'";
                //}
                //if (chkGroupBy.Checked == true)
                //{
                //    sQuery += " Group by name, EmployeeDetailsId, JobListID";
                //}
                
                string sQuery = "";

                //sQuery = "SELECT  Name, Sum(Time) as Time,'' as TimeSheetID,EmployeeDetailsId, JobListID,cast(0 as float) As BilableRate,cast(0 as float) as Total  FROM TS_Time where JobListID=" + JobListId;


                if (chkGroupBy.Checked == true)
                {
                    if (!string.IsNullOrEmpty(cmbDistinctName.Text))
                    {

                        //sQuery = "SELECT  Name, Sum(Time) as Time,'' as TimeSheetID,EmployeeDetailsId, JobListID," +
                        //    "cast(0 as float) As BilableRate, cast(0 as float) as Total" +
                        //    " FROM TS_Time where JobListID=" & JobListId & "and Name = '" & cmbDistinctName.Text +
                        //    "' Group by name, EmployeeDetailsId, JobListID");

                        sQuery = "SELECT  Name, Sum(Time) as Time,'' as TimeSheetID,EmployeeDetailsId, JobListID,cast(0 as float) As BilableRate, cast(0 as float) as Total FROM TS_Time where JobListID=" + JobListId +  "and Name = '" + cmbDistinctName.Text + "' Group by name, EmployeeDetailsId, JobListID";

                    

                    }
                    else
                    {
                        sQuery = "SELECT  Name, Sum(Time) as Time,'' as TimeSheetID,EmployeeDetailsId, JobListID," +
                             "cast(0 as float) As BilableRate, cast(0 as float) as Total " +
                            "FROM TS_Time where JobListID=" + JobListId + " Group by name, EmployeeDetailsId, JobListID";



                    }
                }
                else if (cmbDistinctName.Text != "")
                {
                    //sQuery = "SELECT TimeSheetID, EmployeeDetailsId, JobListID, Name, Time FROM TS_Time where JobListID = " + JobListId + 
                    //    " and Name = '" + cmbDistinctName.Text + "'";


                    //SELECT CAST(TimeSheetID as nvarchar) AS TimeSheetID, EmployeeDetailsId, JobListID, Name, Time FROM TS_Time where JobListID = 5615

                    sQuery = "SELECT CAST(TimeSheetID as nvarchar) AS TimeSheetID,EmployeeDetailsId, JobListID, Name, Time FROM TS_Time where JobListID = " + JobListId +
                        " and Name = '" + cmbDistinctName.Text + "'";

                   

                }
                else
                {
                    sQuery = "SELECT TimeSheetID,EmployeeDetailsId, JobListID, Name, Time FROM TS_Time where JobListID=" + JobListId + "";

                }






                //if (chkGroupBy.Checked == true)
                //{
                //    if (!string.IsNullOrEmpty(cmbDistinctName.Text))
                //    {

                //            sQuery = sQuery + " and Name = '" + cmbDistinctName.Text + "' Group by name, EmployeeDetailsId, JobListID";
                //    }
                //    {
                //        sQuery = sQuery + "Group by name, EmployeeDetailsId, JobListID";

                //    }
                //}




                //List<TimeSheet2> TS_data;
                //List<TimeSheet2> SelectTime_data;
                //using (EFDbContext db = new EFDbContext())
                //{
                //    TS_data = db.Database.SqlQuery<TimeSheet2>(sQuery).ToList();
                //}



                //showTimedataTable.Columns.Add("BilableRate");
                //showTimedataTable.Columns.Add("Total");
                // .DataSource = showTimedataTable
                //dtSelectTime = showTimedataTable;

                //MessageBox.Show("1");


                List<TimeSheet> TS_data;
                List<TimeSheet> SelectTime_data;

                //using (EFDbContext db = new EFDbContext())
                //{
                //    TS_data = db.Database.SqlQuery<TimeSheet>(sQuery).ToList();
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        TS_data = db.Database.SqlQuery<TimeSheet>(sQuery).ToList();
                    }


                }
                else
                {

                    using (EFDbContext db = new EFDbContext())
                    {
                        TS_data = db.Database.SqlQuery<TimeSheet>(sQuery).ToList();
                    }

                }


                //MessageBox.Show("2");


                SelectTime_data = TS_data;

                //MessageBox.Show("3");

                double total = 0;
                //'Update''
                double VECost = 0;
                int count = 0;
                bool flag = false;
                double TotalItem = 0;
                string billableRate ;
                foreach (var item in SelectTime_data)
                {
                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    billableRate = db.Database.SqlQuery<string>("Select Top 1 BillableRate FROM EmployeeDetails Where UserName='" + item.Name + "' AND (IsDelete IS NULL or IsDelete=0) order by billableRate desc").SingleOrDefault();
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            billableRate = db.Database.SqlQuery<string>("Select Top 1 BillableRate FROM EmployeeDetails Where UserName='" + item.Name + "' AND (IsDelete IS NULL or IsDelete=0) order by billableRate desc").SingleOrDefault();
                        }

                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            billableRate = db.Database.SqlQuery<string>("Select Top 1 BillableRate FROM EmployeeDetails Where UserName='" + item.Name + "' AND (IsDelete IS NULL or IsDelete=0) order by billableRate desc").SingleOrDefault();
                        }
                    }

                    if (billableRate != null)
                    {
                        item.BilableRate = Convert.ToDouble( billableRate);
                        item.Total = item.BilableRate * item.Time;
                    }
                    flag = true;
                }

                //MessageBox.Show("4");
                //DataAccessLayer DAL = new DataAccessLayer();
                ////Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker"].ToString()
                //SqlConnection con = new SqlConnection(DAL.ConnectionStringPCTracker);
                //for (int CountRow = 0; CountRow < dtSelectTime.Rows.Count; CountRow++)
                //{

                //    //Dim empID1 As Integer = Convert.ToInt32(dtSelectTime.Rows[CountRow)("EmployeeDetailsId"].ToString())

                //    string empname = (dtSelectTime.Rows[CountRow]["Name"].ToString()); //change Name to user name @g 24 Oct
                //                                                                       //Dim query1 As String = "USE " + con.Database + " select BillableRate FROM EmployeeDetails  where UserName='" & empname & "'"
                //    string query1 = "select top 1 BillableRate FROM EmployeeDetails  where UserName='" + empname + "' AND (IsDelete IS NULL or IsDelete=0) order by billableRate desc";
                //    DataAccessLayer DALL1 = new DataAccessLayer();
                //    DataTable dtBillAbleRate1 = new DataTable();
                //    dtBillAbleRate1 = DALL1.Filldatatable(query1);

                //    if (dtBillAbleRate1.Rows.Count > 0)
                //    {
                //        if (dtBillAbleRate1.Rows[0][0] != null)
                //        {

                //            if (dtBillAbleRate1.Rows.Count > 0)
                //            {

                //                dtSelectTime.Rows[CountRow]["BilableRate"] = Convert.ToDecimal(string.IsNullOrEmpty(dtBillAbleRate1.Rows[0][0].ToString()) ? 0 : dtBillAbleRate1.Rows[0][0]);
                //                dtSelectTime.Rows[CountRow]["Total"] = dtSelectTime.Rows[CountRow]["BilableRate"] * dtSelectTime.Rows[CountRow]["Time"];

                //            }
                //            else
                //            {
                //                dtSelectTime.Rows[CountRow]["BilableRate"] = 0;
                //                dtSelectTime.Rows[CountRow]["Total"] = dtSelectTime.Rows[CountRow]["BilableRate"] * 0;

                //            }

                //        }
                //        else
                //        {

                //        }
                //    }
                //    flag = true;
                //}

                if (flag == true)
                {
                    foreach (var item in SelectTime_data)
                    {
                        if (string.IsNullOrEmpty(item.Time.ToString()))
                        {
                            total = total + 0;
                        }
                        else
                        {
                            total = total + Convert.ToDouble(item.Time.ToString());
                        }

                        //'Update''
                        if (string.IsNullOrEmpty(item.Total.ToString()))
                        {
                            VECost = VECost + 0;

                        }
                        else
                        {
                            VECost = VECost + Convert.ToDouble(item.Total.ToString());
                        }

                    }

                    //for (count = 0; count < dtSelectTime.Rows.Count; count++)
                    //{

                    //    if (string.IsNullOrEmpty(dtSelectTime.Rows[count]["Time"].ToString()))
                    //    {
                    //        total = total + 0;
                    //    }
                    //    else
                    //    {
                    //        total = total + Convert.ToDouble(dtSelectTime.Rows[count]["Time"].ToString());
                    //    }

                    //    //'Update''
                    //    if (string.IsNullOrEmpty(dtSelectTime.Rows[count]["Total"].ToString()))
                    //    {
                    //        VECost = VECost + 0;

                    //    }
                    //    else
                    //    {
                    //        VECost = VECost + Convert.ToDouble(dtSelectTime.Rows[count]["Total"].ToString());
                    //    }

                    //    // mdio = Me.MdiParent
                    //    // mdio.GetTotalVECostAmount = VECost
                    //    // JobAndTrackingMDI.GetTotalVECostAmount = VECost                      

                    //}
                    //DataTable dt = null;
                    List<InvoiceData> InvData = null;
                    if (JobNumber != null)
                    {
                        List<SqlParameter> Param = new List<SqlParameter>();
                        Param.Add(new SqlParameter("@JobNumber", JobNumber));
                        Param.Add(new SqlParameter("@Name", cmbDistinctName.Text));

                        //using (EFDbContext db = new EFDbContext())
                        //{
                        //    InvData = db.Database.SqlQuery<InvoiceData>("SP_GetInvoiceDetailByJobNumber @JobNumber,@Name", Param.ToArray()).ToList();
                        //}

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            
                            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            {
                                InvData = db.Database.SqlQuery<InvoiceData>("SP_GetInvoiceDetailByJobNumber @JobNumber,@Name", Param.ToArray()).ToList();
                            }
                        }
                        else
                        {
                            using (EFDbContext db = new EFDbContext())
                            {
                                InvData = db.Database.SqlQuery<InvoiceData>("SP_GetInvoiceDetailByJobNumber @JobNumber,@Name", Param.ToArray()).ToList();
                            }
                        }

                        foreach (var item in InvData)
                        {
                            double _rate = 0;
                            double _Expenses = 0;
                            double _hrs = 0; //Qty change column name

                            if (Convert.IsDBNull(item.Rate) == true || !double.TryParse(Convert.ToString(item.Rate), out _rate))
                            {
                                _rate = 0;
                            }

                            if (Convert.IsDBNull(item.Hrs) == true || !double.TryParse(Convert.ToString(item.Hrs), out _hrs))
                            {
                                _hrs = 0;
                            }

                            if (Convert.IsDBNull(item.Expenses) == true || !double.TryParse(Convert.ToString(item.Expenses), out _Expenses))
                            {
                                _Expenses = 0;
                            }
                            TotalItem = TotalItem + ((_hrs * _rate) + _Expenses);
                        }
                        //for (var count = 0; count < dt.Rows.Count; count++)
                        //{
                        //    double _rate = 0;
                        //    //Dim _time As Double = 0
                        //    double _Expenses = 0;
                        //    double _hrs = 0; //Qty change column name

                        //    //Dim TotalTime As Double = 0

                        //    if (Convert.IsDBNull(dt.Rows[count]["Rate"]) == true || !double.TryParse(Convert.ToString(dt.Rows[count]["Rate"]), out _rate))
                        //    {
                        //        _rate = 0;
                        //    }

                        //    if (Convert.IsDBNull(dt.Rows[count]["Hrs"]) == true || !double.TryParse(Convert.ToString(dt.Rows[count]["Hrs"]), out _hrs))
                        //    {
                        //        _hrs = 0;
                        //    }

                        //    if (Convert.IsDBNull(dt.Rows[count]["Expenses"]) == true || !double.TryParse(Convert.ToString(dt.Rows[count]["Expenses"]), out _Expenses))
                        //    {
                        //        _Expenses = 0;
                        //    }
                        //    TotalItem = TotalItem + ((_hrs * _rate) + _Expenses);
                        //    //dt.Rows[count)("Expenses") = total.ToString()
                        //}
                    }
                }

                lblRevenue.Text = "Revenue: " + Math.Round(TotalItem, 2);
                lblVecost.Text = "Ve Cost: " + Math.Round(VECost, 2);
                lblTotalHours.Text = "Total Time: " + Math.Round(total, 2);


                this.grdShowTimeData.DataSource = SelectTime_data;
                if (SelectTime_data.Count > 0)
                {
                    CalculateRevenu calcRevenu = new CalculateRevenu();
                    calcRevenu.JobListId = JobListId;
                    calcRevenu.TotalCallBillableRateTime = total;

                    VeCostColor = calcRevenu.setColorTimeData();

                    //Me.grdShowTimeData.Columns["TimeSheetID"].Visible = False
                    // .Columns["TimeSheetID"].Visible = False
                    //''''' .Columns["EmployeeDetailsId"].Visible = False
                    //''''''  Me.grdShowTimeData.Columns["JobListID"].Visible = False
                    //.Columns["BilableRate"].Visible = False
                    //.Columns["Total"].Visible = False
                    //Me.grdShowTimeData.Columns[0).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                    // Me.grdShowTimeData.Columns[0).Width = 30
                }
                else
                {
                    grdShowTimeData.DataSource = null;
                }

                if (grdShowTimeData.RowCount > 0)
                {
                    grdShowTimeData.Columns["TimeSheetID"].Visible = false;
                    grdShowTimeData.Columns["EmployeeDetailsId"].Visible = false;
                    grdShowTimeData.Columns["JobListID"].Visible = false;
                    grdShowTimeData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    grdShowTimeData.Columns[0].Width = 30;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}