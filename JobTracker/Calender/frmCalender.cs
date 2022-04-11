using ComponentFactory.Krypton.Toolkit;
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

namespace JobTracker.Calender
{
    public partial class frmCalender : Form
    {
        #region Declaration
        public static int JobTrackingID = 0;
        public static int JobListID = 0;
        public static DateTime currentWeek = DateTime.Now;
        public static string query = string.Empty;
        public static string QueryForIn = string.Empty;
        public static DateTime CurrDate = DateTime.Now;
        private DataTable dtJT = new DataTable();
        public static string ChString = string.Empty;
        private string checkstring;
        private bool CalendarLoad;

        public string ChBoxSearchString
        {
            get
            {
                return ChString;
            }
        }

        public void EnableBtns()
        {
            btnCancel.Enabled = true;
            btnDelete.Enabled = true;
            btnInsert.Enabled = true;
            btnUpdate.Enabled = true;
        }

        public string SetlblJobTrackingID
        {
            set
            {
                // lblJobTrackingID.Text = Value
                JobTrackingID = Convert.ToInt32(value);
            }
        }

        public string SetlblJobListID
        {
            set
            {
                // lblJobTrackingID.Text = Value
                JobListID = Convert.ToInt32(value);
            }
        }

        // Public WriteOnly Property SetCurrentDate() As String

        // Set(ByVal Value As String)
        // CurrDate = Value
        // End Set
        // End Property

        public string SetJobTrackingIDs
        {
            set
            {
                QueryForIn = value;
            }
        }

        public string QueryStr
        {
            get
            {
                return query;
            }
        }

        #endregion

        public frmCalender()
        {
            InitializeComponent();
        }

        ////public SurroundingClass() : base()
        ////{
        ////    this.Disposed += Calendar_Disposed;
        ////    base.Load += Calendar_Load;
        ////    base.KeyDown += Calendar_KeyDown;
        ////    InitializeComponent();
        ////}

        #region Events
        private void Calendar_Load(object sender, EventArgs e)
        {
            cbxClient.SelectedIndexChanged -= cbxClient_SelectedIndexChanged;
            CalendarLoad = true;
            // *** Comment Old Page Load Setting   *****
            // cmbAction.SelectedIndex = 1
            // chkExpired.Checked = True

            // ApplyCalendarPageLoadSetting()

            // FillCombo()
            // 'cmbAction.SelectedIndex = 1
            // FillCombo()
            // FillCalendar(System.DateTime.Now)
            // SetColumnGrdJobTra.Rows[)
            cbxClient.SelectedIndexChanged += cbxClient_SelectedIndexChanged;
        }
        public void MyControl_MyEventName(object sender, EventArgs e)
        {
            try
            {

                //MessageBox.Show("1");

                //this.txtDescription.Text = jobDescription(JobListID);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    this.txtDescription.Text = jobDescriptionNew(JobListID);
                }
                else
                {
                    this.txtDescription.Text = jobDescription(JobListID);
                }

                //MessageBox.Show(this.txtDescription.Text.ToString());



                if (!string.IsNullOrEmpty(QueryForIn))
                {
                    dtJT.Clear();



                    //dtJT = StMethod.GetListDT<JT_JobStatusList>("SELECT JobTracking.JobListID, JobList.JobNumber, JobTracking.TaskHandler, JobTracking.Track, JobTracking.TrackSub, JobTracking.Comments, JobTracking.Status, JobTracking.Submitted, JobTracking.Obtained, JobTracking.Expires, JobTracking.BillState, JobTracking.AddDate, JobTracking.NeedDate, JobTracking.JobTrackingID,JobTracking.FinalAction, MasterTrackSubItem.CalColor,JobTracking.TrackSubID FROM JobTracking INNER JOIN JobList ON JobTracking.JobListID = JobList.JobListID INNER JOIN MasterTrackSubItem ON JobTracking.TrackSub = MasterTrackSubItem.TrackSubName WHERE (JobTracking.IsDelete = 0 OR JobTracking.IsDelete IS NULL) AND (JobTracking.JobTrackingID  in(" + QueryForIn + ") )");
                    //// da.Fill(dtJT)


                    //dtJT = StMethod.GetListDT<JT_JobStatusList>("SELECT JobTracking.JobListID, JobList.JobNumber, JobTracking.TaskHandler, JobTracking.Track, JobTracking.TrackSub, JobTracking.Comments, JobTracking.Status, JobTracking.Submitted, JobTracking.Obtained, JobTracking.Expires, JobTracking.BillState, JobTracking.AddDate, JobTracking.NeedDate, JobTracking.JobTrackingID,JobTracking.FinalAction, MasterTrackSubItem.CalColor,JobTracking.TrackSubID FROM JobTracking INNER JOIN JobList ON JobTracking.JobListID = JobList.JobListID INNER JOIN MasterTrackSubItem ON JobTracking.TrackSub = MasterTrackSubItem.TrackSubName WHERE (JobTracking.IsDelete = 0 OR JobTracking.IsDelete IS NULL) AND (JobTracking.JobTrackingID  in(" + QueryForIn + ") )");

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        //dtJT = StMethod.GetListDTNew<JT_JobStatusList>("SELECT JobTracking.JobListID, JobList.JobNumber, JobTracking.TaskHandler, JobTracking.Track, JobTracking.TrackSub, JobTracking.Comments, JobTracking.Status, JobTracking.Submitted, JobTracking.Obtained, JobTracking.Expires, JobTracking.BillState, JobTracking.AddDate, JobTracking.NeedDate, JobTracking.JobTrackingID,JobTracking.FinalAction, MasterTrackSubItem.CalColor,JobTracking.TrackSubID FROM JobTracking INNER JOIN JobList ON JobTracking.JobListID = JobList.JobListID INNER JOIN MasterTrackSubItem ON JobTracking.TrackSub = MasterTrackSubItem.TrackSubName WHERE (JobTracking.IsDelete = 0 OR JobTracking.IsDelete IS NULL) AND (JobTracking.JobTrackingID  in(" + QueryForIn + ") )");

                        try
                        { 
                        dtJT = StMethod.GetListDTNew<JT_JobStatusList>("SELECT JobTracking.JobListID, JobList.JobNumber, JobTracking.TaskHandler, JobTracking.Track, JobTracking.TrackSub, JobTracking.Comments, JobTracking.Status, JobTracking.Submitted, JobTracking.Obtained, JobTracking.Expires, JobTracking.BillState, JobTracking.AddDate, JobTracking.NeedDate, JobTracking.JobTrackingID,JobTracking.FinalAction, MasterTrackSubItem.CalColor,JobTracking.TrackSubID FROM JobTracking INNER JOIN JobList ON JobTracking.JobListID = JobList.JobListID INNER JOIN MasterTrackSubItem ON JobTracking.TrackSub = MasterTrackSubItem.TrackSubName WHERE (JobTracking.IsDelete = 0 OR JobTracking.IsDelete IS NULL) AND (JobTracking.JobTrackingID  in(" + QueryForIn + ") )");


                        //Clipboard.SetText("SELECT JobTracking.JobListID, JobList.JobNumber, JobTracking.TaskHandler, JobTracking.Track, JobTracking.TrackSub, JobTracking.Comments, JobTracking.Status, JobTracking.Submitted, JobTracking.Obtained, JobTracking.Expires, JobTracking.BillState, JobTracking.AddDate, JobTracking.NeedDate, JobTracking.JobTrackingID,JobTracking.FinalAction, MasterTrackSubItem.CalColor,JobTracking.TrackSubID FROM JobTracking INNER JOIN JobList ON JobTracking.JobListID = JobList.JobListID INNER JOIN MasterTrackSubItem ON JobTracking.TrackSub = MasterTrackSubItem.TrackSubName WHERE (JobTracking.IsDelete = 0 OR JobTracking.IsDelete IS NULL) AND (JobTracking.JobTrackingID  in(" + QueryForIn + ") )");

                        //MessageBox.Show("11");
                        //MessageBox.Show(dtJT.Rows.Count.ToString());
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }

                    }
                    else
                    {
                        dtJT = StMethod.GetListDT<JT_JobStatusList>("SELECT JobTracking.JobListID, JobList.JobNumber, JobTracking.TaskHandler, JobTracking.Track, JobTracking.TrackSub, JobTracking.Comments, JobTracking.Status, JobTracking.Submitted, JobTracking.Obtained, JobTracking.Expires, JobTracking.BillState, JobTracking.AddDate, JobTracking.NeedDate, JobTracking.JobTrackingID,JobTracking.FinalAction, MasterTrackSubItem.CalColor,JobTracking.TrackSubID FROM JobTracking INNER JOIN JobList ON JobTracking.JobListID = JobList.JobListID INNER JOIN MasterTrackSubItem ON JobTracking.TrackSub = MasterTrackSubItem.TrackSubName WHERE (JobTracking.IsDelete = 0 OR JobTracking.IsDelete IS NULL) AND (JobTracking.JobTrackingID  in(" + QueryForIn + ") )");
                        // da.Fill(dtJT)

                        //MessageBox.Show("12");
                        //MessageBox.Show(dtJT.Rows.Count.ToString());
                    }



                    //MessageBox.Show("3");

                    grdJobTracking.DataSource = dtJT;

                    //MessageBox.Show("4");

                    //MessageBox.Show("5 " , dtJT.Rows.Count.ToString());

                    grdJobTracking.Columns["CalColor"].Visible = false;



                    for (int cnt = 0, loopTo = grdJobTracking.Rows.Count - 1; cnt <= loopTo; cnt++)
                    {
                        if (JobTrackingID == Convert.ToInt32(grdJobTracking.Rows[cnt].Cells["JobTrackingID"].Value.ToString()))
                        {
                            grdJobTracking.Rows[cnt].Selected = true;
                            grdJobTracking.CurrentCell = grdJobTracking.Rows[cnt].Cells["Comments"];
                        }

                        string strColor = grdJobTracking.Rows[cnt].Cells["CalColor"].Value.ToString().Trim();
                        if ((strColor ?? "") != (string.Empty ?? ""))
                        {
                            Color Selcolor = System.Drawing.Color.FromName(strColor);
                            grdJobTracking.Rows[cnt].DefaultCellStyle.BackColor = Selcolor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Calendar");
            }
            finally
            {
            }
        }
        private void chkSubmitted_CheckedChanged(object sender, EventArgs e)
        {
            fillGrid();
            PassQueryString();
            FillCalendar(currentWeek);
        }
        private void Calendar_KeyDown(object sender, KeyEventArgs e)
        {
            TimeSpan duration;
            duration = new TimeSpan(7, 0, 0, 0);
            if (e.KeyCode == Keys.Down)
            {
                FillCalendar(DateTime.Now.Add(duration));
            }

            if (e.KeyCode == Keys.Up)
            {
                FillCalendar(DateTime.Now.Subtract(duration));
            }
        }
        private void chkObtained_CheckedChanged(object sender, EventArgs e)
        {
            fillGrid();
            PassQueryString();
            FillCalendar(currentWeek);
        }
        private void chkExpired_CheckedChanged(object sender, EventArgs e)
        {
            fillGrid();
            PassQueryString();
            FillCalendar(currentWeek);
        }
        private void cbxClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            PassQueryString();
            FillCalendar(currentWeek);
        }
        private void cbxJobListPM_SelectedIndexChanged(object sender, EventArgs e)
        {
            PassQueryString();
            FillCalendar(currentWeek);
        }
        private void cbxSearchTm_SelectedIndexChanged(object sender, EventArgs e)
        {
            PassQueryString();
            FillCalendar(currentWeek);
        }
        private void chkShowOnlyPendingTrack_CheckedChanged(object sender, EventArgs e)
        {
            PassQueryString();
            FillCalendar(currentWeek);
        }
        private void btnUp_Click(object sender, EventArgs e)
        {
            TimeSpan duration;
            duration = new TimeSpan(7, 0, 0, 0);
            currentWeek = currentWeek.Add(duration);
            FillCalendar(currentWeek);
            CurrDate = currentWeek;
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            TimeSpan duration;
            duration = new TimeSpan(7, 0, 0, 0);
            currentWeek = currentWeek.Subtract(duration);
            FillCalendar(currentWeek);
            CurrDate = currentWeek;
        }
        private void cbxClient_SelectionChangeCommitted(object sender, EventArgs e)
        {
            PassQueryString();
            FillCalendar(currentWeek);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (grdJobTracking.Rows.Count != 0)
            {
                grdJobTracking.Rows[0].Cells["Comments"].Selected = true;
                grdJobTracking.EndEdit();
                try
                {
                    // Attempt to update the datasource.
                    int cnt;
                    var loopTo = grdJobTracking.Rows.Count - 1;
                    for (cnt = 0; cnt <= loopTo; cnt++)
                    {
                        try
                        {
                            string sql="update  Jobtracking set JobListID= @JobListID,TaskHandler=@TaskHandler,Track=@Track,Status= @Status,Submitted=@Submitted, Obtained=@Obtained,Expires=@Expires,BillState=@BillState , AddDate=@AddDate,NeedDate= @NeedDate,TrackSub=@TrackSub,Comments=@Comments where   JobTrackingID=    @JobTrackingID";
                            var Param = new List<SqlParameter>();
                            Param.Add(new SqlParameter("@JobListID", ((System.Windows.Forms.DataGridViewComboBoxCell)grdJobTracking.Rows[cnt].Cells["cmbJobNumber"]).Value));
                            Param.Add(new SqlParameter("@TaskHandler", grdJobTracking.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()));
                            Param.Add(new SqlParameter("@Track", grdJobTracking.Rows[cnt].Cells["cmbTrack"].Value.ToString()));


                            string Date101 = null;
                            string Date102 = null;

                            Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                            string FinalDateUpdate = string.Empty;


                            if (grdJobTracking.Rows[cnt].Cells["Submitted"].Value == null || grdJobTracking.Rows[cnt].Cells["Submitted"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString()))
                            {
                                // here is your message box...


                            }
                            else
                            {
                                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                                Date101 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                            }


                            if (grdJobTracking.Rows[cnt].Cells["Submitted"].Tag == null || grdJobTracking.Rows[cnt].Cells["Submitted"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Submitted"].Tag.ToString()))
                            {
                                // here is your message box...

                                //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                                //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                                //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                                //Date102 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                                //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                ActionDateUpdate = DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

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
                                Date102 = grdJobTracking.Rows[cnt].Cells["Submitted"].Tag.ToString();
                            }

                            Param.Add(new SqlParameter("@Submitted", Date102));
                            //Param.Add(new SqlParameter("@Submitted", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString()));



                            Param.Add(new SqlParameter("@BillState", grdJobTracking.Rows[cnt].Cells["cmbBillState"].Value.ToString()));
                            Param.Add(new SqlParameter("@TrackSub", grdJobTracking.Rows[cnt].Cells["cmbTrackSub"].Value.ToString()));
                            Param.Add(new SqlParameter("@Comments", grdJobTracking.Rows[cnt].Cells["Comments"].Value.ToString()));
                            Param.Add(new SqlParameter("@Status", grdJobTracking.Rows[cnt].Cells["cmbStatus"].Value.ToString()));


                            string Date103 = null;
                            string Date104 = null;

                            Nullable<DateTime> ActionDateUpdate2 = DateTime.Now;

                            string FinalDateUpdate2 = string.Empty;


                            if (grdJobTracking.Rows[cnt].Cells["Obtained"].Value == null || grdJobTracking.Rows[cnt].Cells["Obtained"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString()))
                            {
                                // here is your message box...


                            }
                            else
                            {
                                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                                Date103 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString());

                            }


                            if (grdJobTracking.Rows[cnt].Cells["Obtained"].Tag == null || grdJobTracking.Rows[cnt].Cells["Obtained"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Obtained"].Tag.ToString()))
                            {
                                // here is your message box...

                                //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                                //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                                //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                                //Date102 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                                //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                ActionDateUpdate2 = DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString());

                                int s, s1, s2;

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
                                Date104 = grdJobTracking.Rows[cnt].Cells["Obtained"].Tag.ToString();
                            }



                            Param.Add(new SqlParameter("@Obtained", Date104));
                            //Param.Add(new SqlParameter("@Obtained", grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString()));



                           
                            string Date105 = null;
                            string Date106 = null;

                            Nullable<DateTime> ActionDateUpdate3 = DateTime.Now;

                            string FinalDateUpdate3 = string.Empty;


                            if (grdJobTracking.Rows[cnt].Cells["Expires"].Value == null || grdJobTracking.Rows[cnt].Cells["Expires"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString()))
                            {
                                // here is your message box...


                            }
                            else
                            {
                                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                                Date105 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString());

                            }


                            if (grdJobTracking.Rows[cnt].Cells["Expires"].Tag == null || grdJobTracking.Rows[cnt].Cells["Expires"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Expires"].Tag.ToString()))
                            {
                                // here is your message box...

                                //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                                //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                                //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                                //Date102 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                                //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                ActionDateUpdate3 = DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString());

                                int s, s1, s2;

                                //11-22-2021 05:34:05 PM

                                s = ActionDateUpdate2.Value.Month;
                                s1 = ActionDateUpdate2.Value.Day;
                                s2 = ActionDateUpdate2.Value.Year;

                                FinalDateUpdate3 = ActionDateUpdate3.Value.Month.ToString() + "-" + ActionDateUpdate3.Value.Day.ToString() + "-" + ActionDateUpdate3.Value.Year.ToString() + " " + ActionDateUpdate3.Value.Hour.ToString() + ":" + ActionDateUpdate3.Value.Minute.ToString()
                                    + ":" + ActionDateUpdate3.Value.Second.ToString() + " " + ActionDateUpdate3.Value.ToString("tt");


                                Date106 = FinalDateUpdate3;

                            }
                            else
                            {
                                Date106 = grdJobTracking.Rows[cnt].Cells["Expires"].Tag.ToString();
                            }


                            Param.Add(new SqlParameter("@Expires", Date106));
                            //Param.Add(new SqlParameter("@Expires", grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString()));


                            string Date107 = null;
                            string Date108 = null;

                            Nullable<DateTime> ActionDateUpdate4 = DateTime.Now;

                            string FinalDateUpdate4 = string.Empty;


                            if (grdJobTracking.Rows[cnt].Cells["AddDate"].Value == null || grdJobTracking.Rows[cnt].Cells["AddDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString()))
                            {
                                // here is your message box...


                            }
                            else
                            {
                                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                                Date107 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString());

                            }


                            if (grdJobTracking.Rows[cnt].Cells["AddDate"].Tag == null || grdJobTracking.Rows[cnt].Cells["AddDate"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["AddDate"].Tag.ToString()))
                            {
                                // here is your message box...

                                //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                                //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                                //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                                //Date102 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                                //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                ActionDateUpdate4 = DateTime.Parse(grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString());

                                int s, s1, s2;

                                //11-22-2021 05:34:05 PM

                                s = ActionDateUpdate4.Value.Month;
                                s1 = ActionDateUpdate4.Value.Day;
                                s2 = ActionDateUpdate4.Value.Year;

                                FinalDateUpdate4 = ActionDateUpdate4.Value.Month.ToString() + "-" + ActionDateUpdate4.Value.Day.ToString() + "-" + ActionDateUpdate4.Value.Year.ToString() + " " + ActionDateUpdate4.Value.Hour.ToString() + ":" + ActionDateUpdate4.Value.Minute.ToString()
                                    + ":" + ActionDateUpdate4.Value.Second.ToString() + " " + ActionDateUpdate4.Value.ToString("tt");


                                Date108 = FinalDateUpdate4;

                            }
                            else
                            {
                                Date108 = grdJobTracking.Rows[cnt].Cells["AddDate"].Tag.ToString();
                            }



                            Param.Add(new SqlParameter("@AddDate", Date108));
                            //Param.Add(new SqlParameter("@AddDate", grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString()));



                            Param.Add(new SqlParameter("@NeedDate", grdJobTracking.Rows[cnt].Cells["NeedDate"].Value.ToString()));
                            Param.Add(new SqlParameter("@JobTrackingID", grdJobTracking.Rows[cnt].Cells["JobTrackingID"].Value.ToString()));




                            //if (StMethod.UpdateRecord(sql, Param) > 0)
                            //{
                            //    KryptonMessageBox.Show("Update Successfully", "Calendar");
                            //}



                           
                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                if (StMethod.UpdateRecordNew(sql, Param) > 0)
                                {
                                    KryptonMessageBox.Show("Update Successfully", "Calendar");
                                }

                            }
                            else
                            {
                                if (StMethod.UpdateRecord(sql, Param) > 0)
                                {
                                    KryptonMessageBox.Show("Update Successfully", "Calendar");
                                }

                            }


                        }
                        // sqlcon.Open()
                        // cmd.ExecuteNonQuery()
                        // sqlcon.Close()

                        // FillCalendar(CurrDate)
                        catch (Exception eLoad)
                        {
                            // Add your error handling code here.
                            // Display error message, if any.
                            KryptonMessageBox.Show(eLoad.Message, "Calendar");
                        }
                    }

                    fillGrid();
                    FillCalendar(CurrDate);
                    if (grdJobTracking.Rows.Count > 0)
                    {
                        grdJobTracking.CurrentCell = grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["Submitted"];
                    }

                    KryptonMessageBox.Show("Record Updated!", "Calendar");
                }
                catch (Exception eUpdate)
                {
                    // Add your error handling code here.
                    // Display error message, if any.
                    KryptonMessageBox.Show(eUpdate.Message, "Calendar");
                }
            }
        }
        private void btnInsert_Click(System.Object sender, System.EventArgs e)
        {
            if (btnInsert.Text == "Insert")
            {
                for (int i = 0; i < grdJobTracking.Rows.Count; i++)
                {
                    if (grdJobTracking.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                    {
                        KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Calendar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                btnInsert.Text = "Save";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                DataRow datarow = dtJT.NewRow();

                //datarow("JobNumber") = ""

                try
                {
                    XmlDocument myDoc = new XmlDocument();


                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

                    dir2 = dir2 + "\\JobTracker";

                    //string fileName = dir2 + "\\VESoftwareSetting.xml";

                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");
                   

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Apply"].InnerText == "Yes")
                    {
                        datarow["JobListID"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["JobId"].InnerText;
                        datarow["JobNumber"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Job"].InnerText;
                        datarow["TaskHandler"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["TM"].InnerText;
                        datarow["Track"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Track"].InnerText;
                        datarow["TrackSub"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["TrackSub"].InnerText;
                    }
                    else
                    {
                        datarow["JobNumber"] = "";
                        datarow["JobListID"] = 0;
                        datarow["TaskHandler"] = "";
                        datarow["Track"] = "";
                        datarow["TrackSub"] = "";
                    }

                }
                catch (Exception ex)
                {
                    datarow["JobNumber"] = "";
                    datarow["JobListID"] = 0;
                    datarow["TaskHandler"] = "";
                    datarow["Track"] = "";
                    datarow["TrackSub"] = "";
                }
                //If Checkvaliduser() = True Then
                //    datarow("TaskHandler") = My.Settings.timeSheetLoginName
                //    datarow("Track") = "Permit;"
                //Else
                //    datarow("TaskHandler") = ""
                //    datarow("Track") = ""
                //End If
                //datarow("TaskHandler") = ""
                //datarow("Track") = ""
                //datarow("TrackSub") = ""
                datarow["Status"] = "";
                datarow["Submitted"] = "1/1/1900";
                datarow["Obtained"] = "1/1/1900";
                
                //datarow["Expires"] = "30/12/9999";
                datarow["Expires"] = "12/30/9999";

                //datarow["Expires"] = "12/30/9999";
                datarow["BillState"] = "";
                datarow["AddDate"] = DateTime.Now;

                datarow["NeedDate"] = "12/30/9999";
                //datarow["NeedDate"] = "30/12/9999";

                try
                {
                    XmlDocument myDoc = new XmlDocument();

                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");

                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                    if (myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Apply"].InnerText == "Yes")
                    {


                        if (!string.IsNullOrEmpty(datarow["JobNumber"].ToString()) && datarow["JobNumber"].ToString() == myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Job"].InnerText)
                        {
                            datarow["JobTrackingID"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["JobId"].InnerText;
                        }
                        else
                        {
                            datarow["JobTrackingID"] = 0;
                            datarow["JobNumber"] = "";

                        }
                        datarow["Comments"] = myDoc["VESoftwareSetting"]["AutoInsert"]["Calendar"]["Comments"].InnerText;
                    }
                    else
                    {
                        datarow["JobTrackingID"] = 0;
                        datarow["Comments"] = "";
                    }
                }
                catch (Exception ex)
                {
                    datarow["JobTrackingID"] = 0;
                    datarow["Comments"] = "";
                }
                //datarow("JobTrackingID") = 0
                //datarow("Comments") = ""
                dtJT.Rows.Add(datarow);
                grdJobTracking.DataSource = dtJT;
                grdJobTracking.CurrentCell = grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["Comments"];
                grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
            }
            else
            {
                InsertJobTracking();
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
            btnInsert.Text = "Insert";
            fillGrid();
            if (grdJobTracking.Rows.Count > 0)
            {
                grdJobTracking.CurrentCell = grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["Submitted"];
            }


        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = default(int);
            var rowIndex = default(int);
            if (grdJobTracking.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow SelectedRow in grdJobTracking.SelectedRows)
                {
                    id = Convert.ToInt32(SelectedRow.Cells["JobTrackingID"].Value.ToString());
                    rowIndex = SelectedRow.Index;
                }
            }

            if (id == 0)
            {
                KryptonMessageBox.Show("Select a row to delete", "Calendar");
                return;
            }

            if (KryptonMessageBox.Show("Are you sure you want to delete this record? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {


                    //if (StMethod.UpdateRecord("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id)>0)
                    //{                        
                    //    StMethod.LoginActivityInfo("Delete", this.Name);                        
                    //    fillGrid();                        
                    //    FillCalendar(CurrDate);                        
                    //    KryptonMessageBox.Show("Record Deleted!", "Calendar");
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        if (StMethod.UpdateRecordNew("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id) > 0)
                        {
                            StMethod.LoginActivityInfoNew("Delete", this.Name);
                            fillGrid();
                            FillCalendar(CurrDate);
                            KryptonMessageBox.Show("Record Deleted!", "Calendar");
                        }
                    }
                    else
                    {
                        if (StMethod.UpdateRecord("UPDATE JobTracking SET IsDelete=1 where JobTrackingID=" + id) > 0)
                        {
                            StMethod.LoginActivityInfo("Delete", this.Name);
                            fillGrid();
                            FillCalendar(CurrDate);
                            KryptonMessageBox.Show("Record Deleted!", "Calendar");
                        }
                    }

                   





                    if (grdJobTracking.Rows.Count > 1)
                    {
                        
                        //grdJobTracking.Rows[rowIndex].Selected = true;
                        
                        grdJobTracking.CurrentCell = grdJobTracking.Rows[rowIndex - 1].Cells["Submitted"];
                        
                    }



                    //btnUpdate.Enabled = true;
                    //btnDelete.Enabled = true;
                    //btnInsert.Text = "Insert";
                    //fillGrid();
                    //if (grdJobTracking.Rows.Count > 0)
                    //{
                    //    grdJobTracking.CurrentCell = grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["Submitted"];
                    //}




                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Calendar");
                }
            }
        }
        private void grdJobTracking_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (grdJobTracking.Rows.Count == 0)
                    return;

                txtDescription.Text = jobDescription(Convert.ToInt32(grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].Cells["JobListID"].Value));
                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    grdJobTracking.Columns["cmbBillState"].ReadOnly = false;
                }
                else
                {
                    grdJobTracking.Columns["cmbBillState"].ReadOnly = true;
                }

                if (e.ColumnIndex == 0 & e.RowIndex > -1)
                {
                    try
                    {
                        // Attempt to update the datasource.
                        int cnt = e.RowIndex;
                        if (Convert.ToInt32(grdJobTracking.Rows[cnt].Cells["JobTrackingID"].Value.ToString()) == 0)
                        {
                            InsertJobTracking();
                            return;
                        }

                        btnInsert.Text = "Insert";
                        btnDelete.Enabled = true;
                        try
                        {
                            string sql = "update  Jobtracking set JobListID= @JobListID,TaskHandler=@TaskHandler,Track=@Track,Status= @Status,Submitted=@Submitted, Obtained=@Obtained,Expires=@Expires,BillState=@BillState , AddDate=@AddDate,NeedDate= @NeedDate,TrackSub=@TrackSub,Comments=@Comments,IsChange=@IsChange,ChangeDate=@ChangeDate,FinalAction=@FinalAction,TrackSubID=@TrackSubID  where   JobTrackingID=    @JobTrackingID";
                            var Param = new List<SqlParameter>();


                            Param.Add(new SqlParameter("@IsChange", 1));

                            //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");


                            //DateTime EditedChnageDate = Convert.ToDateTime((DateTime.Parse(DateTime.Now.ToString())).ToString("MM/d/yyyy"));

                            Nullable<DateTime> EditedChnageDate = DateTime.Parse(DateTime.Now.ToString());
                            string FinalChangeDate = string.Empty;

                            ////int s, s1, s2;

                            //s = EditedChnageDate.Value.Month;
                            //s1 = EditedChnageDate.Value.Day;
                            //s2 = EditedChnageDate.Value.Year;

                            FinalChangeDate = EditedChnageDate.Value.Month.ToString() + "-" + EditedChnageDate.Value.Day.ToString() + "-" + EditedChnageDate.Value.Year.ToString() + " " + EditedChnageDate.Value.Hour.ToString() + ":" + EditedChnageDate.Value.Minute.ToString()
                                + ":" + EditedChnageDate.Value.Second.ToString() + " " + EditedChnageDate.Value.ToString("tt");



                            Param.Add(new SqlParameter("@ChangeDate", FinalChangeDate));


                            //Param.Add(new SqlParameter("@ChangeDate", EditedChnageDate));

                            //Param.Add(new SqlParameter("@ChangeDate", string.Format(DateTime.Now.ToString(), "MM/dd/yyyy")));


                            Param.Add(new SqlParameter("@JobListID", ((System.Windows.Forms.DataGridViewComboBoxCell)grdJobTracking.Rows[cnt].Cells["cmbJobNumber"]).Value));
                            Param.Add(new SqlParameter("@TaskHandler", grdJobTracking.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()));
                            Param.Add(new SqlParameter("@Track", grdJobTracking.Rows[cnt].Cells["cmbTrack"].Value.ToString()));



                            string Date101 = null;
                            string Date102 = null;

                            Nullable<DateTime> ActionDateUpdate = DateTime.Now;

                            string FinalDateUpdate = string.Empty;


                            if (grdJobTracking.Rows[cnt].Cells["Submitted"].Value == null || grdJobTracking.Rows[cnt].Cells["Submitted"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString()))
                            {
                                // here is your message box...


                            }
                            else
                            {
                                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                                Date101 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                            }


                            if (grdJobTracking.Rows[cnt].Cells["Submitted"].Tag == null || grdJobTracking.Rows[cnt].Cells["Submitted"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Submitted"].Tag.ToString()))
                            {
                                // here is your message box...

                                //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                                //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                                //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                                //Date102 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                                //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                ActionDateUpdate = DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

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
                                Date102 = grdJobTracking.Rows[cnt].Cells["Submitted"].Tag.ToString();
                            }


                            Param.Add(new SqlParameter("@Submitted", Date102));

                            //DateTime EditedSubmitted = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString())).ToString("MM/d/yyyy"));

                            //Param.Add(new SqlParameter("@Submitted", EditedSubmitted));




                            //Param.Add(new SqlParameter("@Submitted", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString()));


                            Param.Add(new SqlParameter("@BillState", grdJobTracking.Rows[cnt].Cells["cmbBillState"].Value.ToString()));
                            Param.Add(new SqlParameter("@TrackSub", grdJobTracking.Rows[cnt].Cells["TrackSub"].Value.ToString()));
                            Param.Add(new SqlParameter("@Comments", grdJobTracking.Rows[cnt].Cells["Comments"].Value.ToString()));
                            Param.Add(new SqlParameter("@Status", grdJobTracking.Rows[cnt].Cells["cmbStatus"].Value.ToString()));



                            string Date103 = null;
                            string Date104 = null;

                            Nullable<DateTime> ActionDateUpdate2 = DateTime.Now;
                            

                            string FinalDateUpdate2 = string.Empty;


                            if (grdJobTracking.Rows[cnt].Cells["Obtained"].Value == null || grdJobTracking.Rows[cnt].Cells["Obtained"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString()))
                            {
                                // here is your message box...


                            }
                            else
                            {
                                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                                Date103 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString());

                            }


                            if (grdJobTracking.Rows[cnt].Cells["Obtained"].Tag == null || grdJobTracking.Rows[cnt].Cells["Obtained"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Obtained"].Tag.ToString()))
                            {
                                // here is your message box...

                                //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                                //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                                //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                                //Date102 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                                //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                ActionDateUpdate2 = DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString());

                                int s, s1, s2;

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
                                Date104 = grdJobTracking.Rows[cnt].Cells["Obtained"].Tag.ToString();
                            }

                            Param.Add(new SqlParameter("@Obtained", Date104));

                            //DateTime EditedObtained = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString())).ToString("MM/d/yyyy"));
                            //Param.Add(new SqlParameter("@Obtained", EditedObtained));

                            //Param.Add(new SqlParameter("@Obtained", grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString()));

                            //DateTime EditedExpires = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString())).ToString("MM/d/yyyy"));

                            //DateTime EditedExpires = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString())));

                            //Param.Add(new SqlParameter("@Expires", EditedExpires));

                            //Param.Add(new SqlParameter("@Expires", grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString()));


                            string Date105 = null;
                            string Date106 = null;

                            Nullable<DateTime> ActionDateUpdate3 = DateTime.Now;

                            string FinalDateUpdate3 = string.Empty;


                            if (grdJobTracking.Rows[cnt].Cells["Expires"].Value == null || grdJobTracking.Rows[cnt].Cells["Expires"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString()))
                            {
                                // here is your message box...


                            }
                            else
                            {
                                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                                Date105 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString());

                            }


                            if (grdJobTracking.Rows[cnt].Cells["Expires"].Tag == null || grdJobTracking.Rows[cnt].Cells["Expires"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["Expires"].Tag.ToString()))
                            {
                                // here is your message box...

                                //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                                //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                                //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                                //Date102 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                                //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                ActionDateUpdate3 = DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString());

                                int s, s1, s2;

                                //11-22-2021 05:34:05 PM

                                s = ActionDateUpdate2.Value.Month;
                                s1 = ActionDateUpdate2.Value.Day;
                                s2 = ActionDateUpdate2.Value.Year;

                                FinalDateUpdate3 = ActionDateUpdate3.Value.Month.ToString() + "-" + ActionDateUpdate3.Value.Day.ToString() + "-" + ActionDateUpdate3.Value.Year.ToString() + " " + ActionDateUpdate3.Value.Hour.ToString() + ":" + ActionDateUpdate3.Value.Minute.ToString()
                                    + ":" + ActionDateUpdate3.Value.Second.ToString() + " " + ActionDateUpdate3.Value.ToString("tt");


                                Date106 = FinalDateUpdate3;

                            }
                            else
                            {
                                Date106 = grdJobTracking.Rows[cnt].Cells["Expires"].Tag.ToString();
                            }


                            Param.Add(new SqlParameter("@Expires", Date106));



                            //DateTime EditedAddDate = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString())).ToString("MM/d/yyyy"));


                            

                            //DateTime EditedNeedDate = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["NeedDate"].Value.ToString())).ToString("MM/d/yyyy"));


                           


                            //DateTime EditedAddDate = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString())));
                            //Param.Add(new SqlParameter("@AddDate", EditedAddDate));



                            string Date107 = null;
                            string Date108 = null;

                            Nullable<DateTime> ActionDateUpdate4 = DateTime.Now;

                            string FinalDateUpdate4 = string.Empty;


                            if (grdJobTracking.Rows[cnt].Cells["AddDate"].Value == null || grdJobTracking.Rows[cnt].Cells["AddDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString()))
                            {
                                // here is your message box...


                            }
                            else
                            {
                                //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                                Date107 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString());

                            }


                            if (grdJobTracking.Rows[cnt].Cells["AddDate"].Tag == null || grdJobTracking.Rows[cnt].Cells["AddDate"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdJobTracking.Rows[cnt].Cells["AddDate"].Tag.ToString()))
                            {
                                // here is your message box...

                                //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                                //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                                //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                                //Date102 = string.Format("{0:dd/MM/yyyy}", grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());

                                //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                ActionDateUpdate4 = DateTime.Parse(grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString());

                                int s, s1, s2;

                                //11-22-2021 05:34:05 PM

                                s = ActionDateUpdate4.Value.Month;
                                s1 = ActionDateUpdate4.Value.Day;
                                s2 = ActionDateUpdate4.Value.Year;

                                FinalDateUpdate4 = ActionDateUpdate4.Value.Month.ToString() + "-" + ActionDateUpdate4.Value.Day.ToString() + "-" + ActionDateUpdate4.Value.Year.ToString() + " " + ActionDateUpdate4.Value.Hour.ToString() + ":" + ActionDateUpdate4.Value.Minute.ToString()
                                    + ":" + ActionDateUpdate4.Value.Second.ToString() + " " + ActionDateUpdate4.Value.ToString("tt");


                                Date108 = FinalDateUpdate4;

                            }
                            else
                            {
                                Date108 = grdJobTracking.Rows[cnt].Cells["AddDate"].Tag.ToString();
                            }



                            Param.Add(new SqlParameter("@AddDate", Date108));

                            DateTime EditedNeedDate = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["NeedDate"].Value.ToString())));
                            Param.Add(new SqlParameter("@NeedDate", EditedNeedDate));

                            //Param.Add(new SqlParameter("@AddDate", grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString()));
                            //Param.Add(new SqlParameter("@NeedDate", grdJobTracking.Rows[cnt].Cells["NeedDate"].Value.ToString()));



                            Param.Add(new SqlParameter("@JobTrackingID", grdJobTracking.Rows[cnt].Cells["JobTrackingID"].Value.ToString()));
                            Param.Add(new SqlParameter("@FinalAction", grdJobTracking.Rows[cnt].Cells["FinalAction"].Value.ToString()));
                            Param.Add(new SqlParameter("@TrackSubID", grdJobTracking.Rows[cnt].Cells["TrackSubID"].Value.ToString()));




                            //if (StMethod.UpdateRecord(sql, Param) > 0)
                            //{
                            //    KryptonMessageBox.Show("Update Successfully", "Calendar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                            //    grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            //}


                         

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                if (StMethod.UpdateRecordNew(sql, Param) > 0)
                                {
                                    KryptonMessageBox.Show("Update Successfully", "Calendar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                                    grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                }

                            }
                            else
                            {
                                if (StMethod.UpdateRecord(sql, Param) > 0)
                                {
                                    KryptonMessageBox.Show("Update Successfully", "Calendar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                                    grdJobTracking.Rows[grdJobTracking.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                }
                            }


                            grdJobTracking.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            PassQueryString();
                            FillCalendar(currentWeek);
                        }
                        catch (Exception eLoad)
                        {
                            // Add your error handling code here.
                            // Display error message, if any.
                            KryptonMessageBox.Show(eLoad.Message, "Calendar");
                        }

                        grdJobTracking.CurrentCell = grdJobTracking.Rows[cnt].Cells["Submitted"];
                        grdJobTracking.Rows[cnt].Selected = true;
                    }
                    catch (Exception eUpdate)
                    {
                        // Add your error handling code here.
                        // Display error message, if any.
                        KryptonMessageBox.Show(eUpdate.Message, "Calendar");
                    }
                }

                if (e.ColumnIndex == 4 & e.RowIndex > -1)
                {
                    var dt2 = new DataTable();
                    var cmbTCTackName = new DataGridViewComboBoxCell();
                    cmbTCTackName = new DataGridViewComboBoxCell();

                    //dt2 = StMethod.GetListDT<dtoTSNameOnly>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + grdJobTracking.Rows[e.RowIndex].Cells["cmbTrack"].Value.ToString().Trim() + "'");


                    

                    
                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        dt2 = StMethod.GetListDTNew<dtoTSNameOnly>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + grdJobTracking.Rows[e.RowIndex].Cells["cmbTrack"].Value.ToString().Trim() + "'");


                    }
                    else
                    {
                        dt2 = StMethod.GetListDT<dtoTSNameOnly>("select TrackSubName from MasterTrackSubItem WHERE  (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + grdJobTracking.Rows[e.RowIndex].Cells["cmbTrack"].Value.ToString().Trim() + "'");
                    }

                    cmbTCTackName.DataSource = dt2;
                    cmbTCTackName.DisplayMember = dt2.Columns["TrackSubName"].ToString();
                    // cmbTCTackName.ValueMember = dt2.Columns["Id").ToString
                    grdJobTracking.Rows[e.RowIndex].Cells[5] = cmbTCTackName;
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Calendar");
            }
        }
        private void grdJobTracking_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (e.ColumnIndex >= -1 & e.RowIndex > -1)
            if (e.ColumnIndex != -1 & e.RowIndex >0)
            {
                checkstring = string.Empty;
                if (Convert.ToInt16(grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["JobListID"].Value.ToString()) == 0)
                {
                    if (grdJobTracking.CurrentRow.Index == grdJobTracking.Rows.Count - 1)
                    {
                        return;
                    }

                    KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                checkstring = grdJobTracking.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
        private void grdJobTracking_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 & e.RowIndex > -1)
            {
                try
                {
                    var dt2 = new DataTable();
                    var cmbTCTackName = new DataGridViewComboBoxCell();
                    cmbTCTackName = new DataGridViewComboBoxCell();
                    //dt2 = StMethod.GetListDT<string>("select TrackSubName from MasterTrackSubItem WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + grdJobTracking.Rows[e.RowIndex].Cells["cmbTrack"].Value.ToString().Trim() + "'");


                    

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        dt2 = StMethod.GetListDTNew<string>("select TrackSubName from MasterTrackSubItem WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + grdJobTracking.Rows[e.RowIndex].Cells["cmbTrack"].Value.ToString().Trim() + "'");
                    }
                    else
                    {
                        dt2 = StMethod.GetListDT<string>("select TrackSubName from MasterTrackSubItem WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackName='" + grdJobTracking.Rows[e.RowIndex].Cells["cmbTrack"].Value.ToString().Trim() + "'");
                    }

                    cmbTCTackName.DataSource = dt2;
                    cmbTCTackName.DisplayMember = dt2.Columns["TrackSubName"].ToString();
                    // cmbTCTackName.ValueMember = dt2.Columns["Id"].ToString
                    grdJobTracking.Rows[5].Cells[e.RowIndex] = cmbTCTackName;
                }
                catch (Exception ex)
                {
                }
            }

            if (e.ColumnIndex == 5 & e.RowIndex > -1)
            {
                try
                {
                    //grdJobTracking.Rows[e.RowIndex].Cells["TrackSubID"].Value = StMethod.GetSingleInt("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName=" + grdJobTracking.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        grdJobTracking.Rows[e.RowIndex].Cells["TrackSubID"].Value = StMethod.GetSingleIntNew("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName=" + grdJobTracking.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    else
                    {
                        grdJobTracking.Rows[e.RowIndex].Cells["TrackSubID"].Value = StMethod.GetSingleInt("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName=" + grdJobTracking.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                    

                }
                catch (Exception ex)
                {
                }
            }

            try
            {
                if (e.ColumnIndex > -1 & e.RowIndex > -1)
                {

                    //if (!string.IsNullOrEmpty(grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["JobListID"] && 
                    //    !string.IsNullOrEmpty(grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["JobListID"].Value.ToString())))

                    //if (grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["JobListID"].Value == DBNull.Value )
                    if (grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["JobListID"].Value == null )
                    {
                        
                    }
                    else
                    {

                        if (Convert.ToInt16(grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["JobListID"].Value.ToString()) == 0)
                        {
                            return;
                        }
                    }


                    if(grdJobTracking.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                    {

                    }
                    else
                    {

                        if (checkstring != grdJobTracking.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                        {
                            grdJobTracking.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                            grdJobTracking.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                            checkstring = string.Empty;
                        }
                     }

                    //if (checkstring != grdJobTracking.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
                    //{
                    //    grdJobTracking.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    //    grdJobTracking.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                    //    checkstring = string.Empty;
                    //}

                    //String value2 = grdJobTracking.Rows[e.RowIndex].Cells[8].Value.ToString() as string;

                    String value2=null;

                    if (grdJobTracking.Rows[e.RowIndex].Cells[8].Value == null)
                    {

                    }
                    else
                    {
                        value2 = grdJobTracking.Rows[e.RowIndex].Cells[8].Value.ToString() as string;
                    }



                    if (e.ColumnIndex == 8 & e.RowIndex > -1)
                    {
                        try
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
                                    grdJobTracking.Rows[e.RowIndex].Cells[8].Value = value2;
                                    grdJobTracking.Rows[e.RowIndex].Cells[8].Tag = inputString;
                                }
                                else
                                {
                                    grdJobTracking.Rows[e.RowIndex].Cells[8].Tag = inputString;


                                }
                            }
                            else
                            {
                                //e.Value = e.CellStyle.NullValue;
                                //e.FormattingApplied = true;
                            }
                        }
                        catch (Exception ex)
                        {
                           
                        }
                     
                    }

                    //String value3 = grdJobTracking.Rows[e.RowIndex].Cells[9].Value.ToString() as string;

                    String value3 = null;

                    if (grdJobTracking.Rows[e.RowIndex].Cells[9].Value == null)
                    {

                    }
                    else
                    {
                        value3 = grdJobTracking.Rows[e.RowIndex].Cells[9].Value.ToString() as string;
                    }

                    

                    if (e.ColumnIndex == 9 & e.RowIndex > -1)
                    {
                        try
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
                                    grdJobTracking.Rows[e.RowIndex].Cells[9].Value = value3;
                                    grdJobTracking.Rows[e.RowIndex].Cells[9].Tag = inputString;
                                }
                                else
                                {
                                    grdJobTracking.Rows[e.RowIndex].Cells[9].Tag = inputString;


                                }
                            }
                            else
                            {
                                //e.Value = e.CellStyle.NullValue;
                                //e.FormattingApplied = true;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    //String value4 = grdJobTracking.Rows[e.RowIndex].Cells[10].Value.ToString() as string;
                    String value4 = null;

                    if (grdJobTracking.Rows[e.RowIndex].Cells[10].Value == null)
                    {

                    }
                    else
                    {
                        value4 = grdJobTracking.Rows[e.RowIndex].Cells[10].Value.ToString() as string;
                    }


                    

                    if (e.ColumnIndex == 10 & e.RowIndex > -1)
                    {
                        try
                        {
                            if ((value4 != null) && (value4 != string.Empty))
                            {
                                string inputString = "2000-02-02";

                                DateTime dDate = DateTime.Now;

                                inputString = string.Format("{0:MM/d/yyyy}", value4);
                                inputString = value4.ToString() + " 12:00:00 AM";

                                inputString = value4.ToString();



                                if (DateTime.TryParse(inputString, out dDate))
                                {

                                    value4 = string.Format("{0:MM/dd/yyyy}", dDate);

                                    string temp = string.Format("{0:dd/MM/yyyy}", value4);

                                    //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
                                    grdJobTracking.Rows[e.RowIndex].Cells[10].Value = value4;
                                    grdJobTracking.Rows[e.RowIndex].Cells[10].Tag = inputString;
                                }
                                else
                                {
                                    grdJobTracking.Rows[e.RowIndex].Cells[10].Tag = inputString;


                                }
                            }
                            else
                            {
                                //e.Value = e.CellStyle.NullValue;
                                //e.FormattingApplied = true;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }

                    //String value5 = grdJobTracking.Rows[e.RowIndex].Cells[12].Value.ToString() as string;
                    String value5 = null;

                    if (grdJobTracking.Rows[e.RowIndex].Cells[12].Value == null)
                    {

                    }
                    else
                    {
                        value5 = grdJobTracking.Rows[e.RowIndex].Cells[12].Value.ToString() as string;
                    }



                   

                    if (e.ColumnIndex == 12 & e.RowIndex > -1)
                    {
                        try
                        {
                            if ((value5 != null) && (value5 != string.Empty))
                            {
                                string inputString = "2000-02-02";

                                DateTime dDate = DateTime.Now;

                                inputString = string.Format("{0:MM/d/yyyy}", value5);
                                inputString = value5.ToString() + " 12:00:00 AM";

                                inputString = value5.ToString();



                                if (DateTime.TryParse(inputString, out dDate))
                                {

                                    value5 = string.Format("{0:MM/dd/yyyy}", dDate);

                                    string temp = string.Format("{0:dd/MM/yyyy}", value5);

                                    //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
                                    grdJobTracking.Rows[e.RowIndex].Cells[12].Value = value5;
                                    grdJobTracking.Rows[e.RowIndex].Cells[12].Tag = inputString;
                                }
                                else
                                {
                                    grdJobTracking.Rows[e.RowIndex].Cells[12].Tag = inputString;


                                }
                            }
                            else
                            {
                                //e.Value = e.CellStyle.NullValue;
                                //e.FormattingApplied = true;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }





                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void grdJobTracking_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
        private void timerLoad_Tick(object sender, EventArgs e)
        {
            if (CalendarLoad)
            {
                // cmbAction.SelectedIndex = 1
                FillCombo();
                FillCalendar(DateTime.Now);
                SetColumnGrdJobTracking();
                ApplyCalendarPageLoadSetting();
            }

            CalendarLoad = false;
            timerLoad.Stop();
            timerLoad.Enabled = false;
        }
        private void Calendar_Disposed(object sender, EventArgs e)
        {
        }
        #endregion

        #region Methods

        public string jobDescription(int id)
        {
            string descrption = null;
            try
            {
                //DataTable dt = StMethod.GetListDT<JobDescription>("SELECT Company.CompanyName, JobList.Description, JobList.Address, JobList.Borough, JobList.Handler FROM  JobList INNER JOIN  Company ON JobList.CompanyID = Company.CompanyID WHERE JobListID =" + id);

                DataTable dt;


                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<JobDescription>("SELECT Company.CompanyName, JobList.Description, JobList.Address, JobList.Borough, JobList.Handler FROM  JobList INNER JOIN  Company ON JobList.CompanyID = Company.CompanyID WHERE JobListID =" + id);
                }
                else
                {
                    dt = StMethod.GetListDT<JobDescription>("SELECT Company.CompanyName, JobList.Description, JobList.Address, JobList.Borough, JobList.Handler FROM  JobList INNER JOIN  Company ON JobList.CompanyID = Company.CompanyID WHERE JobListID =" + id);
                }

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    descrption = dr["CompanyName"].ToString() + " @: " + " " + dr["Address"].ToString() + ", " + dr["Borough"].ToString() + "; " + dr["Description"].ToString() + " by " + dr["Handler"].ToString();
                }
                else
                {
                    descrption = "";
                }
            }
            catch (Exception ex)
            {
            }
            return descrption;
        }


        public string jobDescriptionNew(int id)
        {
            string descrption = null;
            try
            {
                DataTable dt = StMethod.GetListDTNew<JobDescription>("SELECT Company.CompanyName, JobList.Description, JobList.Address, JobList.Borough, JobList.Handler FROM  JobList INNER JOIN  Company ON JobList.CompanyID = Company.CompanyID WHERE JobListID =" + id);

                if (dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    descrption = dr["CompanyName"].ToString() + " @: " + " " + dr["Address"].ToString() + ", " + dr["Borough"].ToString() + "; " + dr["Description"].ToString() + " by " + dr["Handler"].ToString();
                }
                else
                {
                    descrption = "";
                }
            }
            catch (Exception ex)
            {
            }
            return descrption;
        }



        private void ApplyCalendarPageLoadSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();
                try
                {
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");


                    //myDoc.Load(Application.StartupPath + @"\VESoftwareSetting.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("VESoftwareSetting.XMl File  not available in current folder", "Calendar page load setting error");
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Submitted"].InnerText == "True")
                {
                    chkSubmitted.Checked = true;
                }
                else
                {
                    chkSubmitted.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Obtained"].InnerText == "True")
                {
                    chkObtained.Checked = true;
                }
                else
                {
                    chkObtained.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Expired"].InnerText == "True")
                {
                    chkExpired.Checked = true;
                }
                else
                {
                    chkExpired.Checked = false;
                }

                if (myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["PendingTraks"].InnerText == "True")
                {
                    chkShowOnlyPendingTrack.Checked = true;
                }
                else
                {
                    chkShowOnlyPendingTrack.Checked = false;
                }

                // cbxClient.Text = myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Client"].InnerText
                cbxClient.SelectedIndex = cbxClient.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Client"].InnerText.ToString());
                cmbAction.SelectedIndex = cmbAction.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Action"].InnerText.ToString());
                // cbxClient.SelectedIndex = cbxClient.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["Client"].InnerText.ToString())
                cbxJobListPM.SelectedIndex = cbxJobListPM.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["PM"].InnerText.ToString());
                cbxSearchTm.SelectedIndex = cbxSearchTm.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["Calendar"]["Show"]["TM"].InnerText.ToString());
            }
            catch (Exception ex)
            {
            }
        }

        protected void FillCombo()
        {
            var dt = new DataTable();
            //dt = StMethod.GetListDT<CompanyIDs>("SELECT  CompanyName,CompanyID  FROM dbo.Company ORDER BY CompanyName");


            

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dt = StMethod.GetListDTNew<CompanyIDs>("SELECT  CompanyName,CompanyID  FROM dbo.Company ORDER BY CompanyName");
            }
            else
            {
                dt = StMethod.GetListDT<CompanyIDs>("SELECT  CompanyName,CompanyID  FROM dbo.Company ORDER BY CompanyName");
            }

            DataRow datarow = dt.NewRow();
            datarow["CompanyID"] = 0;
            datarow["CompanyName"] = "";
            dt.Rows.InsertAt(datarow, 0);
            cbxClient.DataSource = dt;
            cbxClient.DisplayMember = "CompanyName";
            cbxClient.ValueMember = "CompanyID";
            cbxClient.SelectedIndex = -1;
            // cbxUpdateClient.DataSource = dt
            // cbxUpdateClient.DisplayMember = "CompanyName"
            // cbxUpdateClient.ValueMember = "CompanyID"
            
            var dt1 = new DataTable();
            //dt1 = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' ORDER BY cTrack ");



            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dt1 = StMethod.GetListDTNew<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' ORDER BY cTrack ");
            }
            else
            {
                dt1 = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' ORDER BY cTrack ");
            }

            for (int I = 0, loopTo = dt1.Rows.Count - 1; I <= loopTo; I++)
                cbxSearchTm.Items.Add(dt1.Rows[I]["cTrack"].ToString());
            dt1 = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' ORDER BY cTrack ");
            for (int I = 0, loopTo1 = dt1.Rows.Count - 1; I <= loopTo1; I++)
                cbxJobListPM.Items.Add(dt1.Rows[I]["cTrack"].ToString());
        }

        protected void FillCalendar(DateTime CurrentDate)
        {
            // grdJobTracking.DataSource = Nothing
            string currentDay = ((int)CurrentDate.DayOfWeek).ToString();
            // Dim today As System.DateTime
            var duration = default(TimeSpan);
            // Dim answer As System.DateTime
            DateTime firstDayOfCurrentWeek;
            switch (currentDay ?? "")
            {
                case "1":
                    {
                        duration = new TimeSpan(1, 0, 0, 0);
                        break;
                    }

                case "2":
                    {
                        duration = new TimeSpan(2, 0, 0, 0);
                        break;
                    }

                case "3":
                    {
                        duration = new TimeSpan(3, 0, 0, 0);
                        break;
                    }

                case "4":
                    {
                        duration = new TimeSpan(4, 0, 0, 0);
                        break;
                    }

                case "5":
                    {
                        duration = new TimeSpan(5, 0, 0, 0);
                        break;
                    }

                case "6":
                    {
                        duration = new TimeSpan(6, 0, 0, 0);
                        break;
                    }

                case "0":
                    {
                        duration = new TimeSpan(0, 0, 0, 0);
                        break;
                    }
            }
            // fill default date to fill calendar cell
            firstDayOfCurrentWeek = Convert.ToDateTime(CurrentDate.Subtract(duration).ToShortDateString());
            duration = new TimeSpan(14, 0, 0, 0);
            CalenderGridl1.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell11.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(13, 0, 0, 0);
            

            CalenderGridl2.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell12.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(12, 0, 0, 0);
            CalenderGridl3.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell13.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(11, 0, 0, 0);
            CalenderGridl4.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell14.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(10, 0, 0, 0);
            CalenderGridl5.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell15.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(9, 0, 0, 0);
            CalenderGridl6.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell16.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(8, 0, 0, 0);
            CalenderGridl7.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell17.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(7, 0, 0, 0);
            CalenderGridl14.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell21.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(6, 0, 0, 0);
            CalenderGridl13.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell22.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(5, 0, 0, 0);
            CalenderGridl12.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell23.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(4, 0, 0, 0);
            CalenderGridl11.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell24.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(3, 0, 0, 0);
            CalenderGridl10.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell25.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(2, 0, 0, 0);
            CalenderGridl9.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell26.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");
            duration = new TimeSpan(1, 0, 0, 0);
            CalenderGridl8.DefaultDate = firstDayOfCurrentWeek.Subtract(duration).ToString("yyyy-MM-dd");
            cell27.Text = firstDayOfCurrentWeek.Subtract(duration).ToString("MMMM dd");

            // Sunday on center row

            CalenderGridl21.DefaultDate = firstDayOfCurrentWeek.ToString();
            cell31.Text = firstDayOfCurrentWeek.ToString("MMMM dd");
            duration = new TimeSpan(1, 0, 0, 0);
            CalenderGridl20.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell32.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(2, 0, 0, 0);
            CalenderGridl19.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell33.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(3, 0, 0, 0);
            CalenderGridl18.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell34.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(4, 0, 0, 0);
            CalenderGridl17.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell35.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(5, 0, 0, 0);
            CalenderGridl16.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell36.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(6, 0, 0, 0);
            CalenderGridl15.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell37.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(7, 0, 0, 0);
            CalenderGridl28.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell41.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(8, 0, 0, 0);
            CalenderGridl27.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell42.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(9, 0, 0, 0);
            CalenderGridl26.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell43.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(10, 0, 0, 0);
            CalenderGridl25.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell44.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(11, 0, 0, 0);
            CalenderGridl24.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell45.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(12, 0, 0, 0);
            CalenderGridl23.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell46.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(13, 0, 0, 0);
            CalenderGridl22.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell47.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(14, 0, 0, 0);
            CalenderGridl35.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell51.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(15, 0, 0, 0);
            CalenderGridl34.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell52.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(16, 0, 0, 0);
            CalenderGridl33.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell53.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(17, 0, 0, 0);
            CalenderGridl32.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell54.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(18, 0, 0, 0);
            CalenderGridl31.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell55.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(19, 0, 0, 0);
            CalenderGridl30.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell56.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            duration = new TimeSpan(20, 0, 0, 0);
            CalenderGridl29.DefaultDate = firstDayOfCurrentWeek.Add(duration).ToString();
            cell57.Text = firstDayOfCurrentWeek.Add(duration).ToString("MMMM dd");
            SetControls();
        }

        private void SetControls()
        {
            foreach (Control cControl in this.pnlCalendar.Controls)
            {
                if (cControl is Panel)
                {
                    foreach (Control LblCtrl in cControl.Controls)
                    {
                        if (LblCtrl is Label)
                        {
                            if (LblCtrl.Text == DateTime.Now.ToString("MMMM dd"))
                            {
                                LblCtrl.ForeColor = Color.Tomato;
                            }
                            else
                            {
                                LblCtrl.ForeColor = Color.Black;
                            }
                        }
                    }
                }
            }
        }

        protected void PassQueryString()
        {
            try
            {
                Program.ChBoxSearchString= chboxstatus();
                string queryString = string.Empty;
                if (cbxJobListPM.SelectedItem!=null && cbxJobListPM.SelectedItem != "" & this.cbxJobListPM.SelectedIndex != -1)
                    queryString = queryString + " and JobList.Handler='" + cbxJobListPM.SelectedItem + "'";
                if (this.cbxSearchTm.SelectedItem!=null && this.cbxSearchTm.SelectedItem != "" & this.cbxSearchTm.SelectedIndex != -1)
                    queryString = queryString + " and JobTracking.TaskHandler ='" + cbxSearchTm.SelectedItem + "'";
                if (this.cmbAction.SelectedItem!=null && this.cmbAction.SelectedItem != "")
                    queryString = queryString + " AND JobTracking.FinalAction='" + cmbAction.SelectedItem.ToString() + "'";
                queryString = queryString.Replace("Not Req'd", "Not Req''d");
                if (!(this.cbxClient.SelectedIndex < 1))
                {
                    if (this.cbxClient.SelectedValue.ToString() != "")
                    {
                        queryString = queryString + " and Company.CompanyID ='" + cbxClient.SelectedValue + "'";
                    }
                }

                if (chkShowOnlyPendingTrack.Checked == true)
                    queryString = queryString + " and JobTracking.Status='Pending'";
                // If chkSubmitted.Checked = True Then queryString = queryString & " and JobTracking.Submitted<>'1/1/1900'"
                // If chkObtained.Checked = True Then queryString = queryString & " and JobTracking.Obtained<>'1/1/1900'"
                // If chkExpired.Checked = True Then queryString = queryString & " and JobTracking.Expires<>'12/30/9999'"
                query = queryString;
                Program.QueryStr = query;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            // queryString = queryString & " order by JobListID"
        }

        protected void SetColumnGrdJobTracking()
        {
            string queryString = "SELECT JobTracking.JobListID,JobList.JobNumber,JobTracking.TaskHandler,JobTracking.Track,JobTracking.TrackSub, JobTracking.Comments,JobTracking.Status,JobTracking.Submitted, JobTracking.Obtained,JobTracking.Expires,JobTracking.BillState , JobTracking.AddDate, JobTracking.NeedDate,     JobTracking.JobTrackingID,JobTracking.FinalAction,JobTracking.TrackSubID  FROM  JobTracking INNER JOIN    JobList ON JobTracking.JobListID = JobList.JobListID   where JobTracking.JobTrackingID=0";


            //dtJT = StMethod.GetListDT<JT_JobStatusList>(queryString);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dtJT = StMethod.GetListDTNew<JT_JobStatusList>(queryString);
            }
            else
            {
                dtJT = StMethod.GetListDT<JT_JobStatusList>(queryString);
            }


            grdJobTracking.DataSource = dtJT;
            int i = grdJobTracking.Rows.Count;

            //var dt2 = new DataTable();
            //dt2 = StMethod.GetListDT<JobNumList>("Select joblistID,JobNumber from JobList WHERE (IsDelete = 0 OR IsDelete IS NULL)");


            var dt2 = new DataTable();


            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                dt2 = StMethod.GetListDTNew<JobNumList>("Select joblistID,JobNumber from JobList WHERE (IsDelete = 0 OR IsDelete IS NULL)");
            }
            else
            {
                dt2 = StMethod.GetListDT<JobNumList>("Select joblistID,JobNumber from JobList WHERE (IsDelete = 0 OR IsDelete IS NULL)");
            }

            DataRow datarow = dt2.NewRow();
            datarow["joblistID"] = 0;
            datarow["JobNumber"] = "";

            dt2.Rows.Add(datarow);
            {
                var withBlock = grdJobTracking;
                var colJobNumber = new DataGridViewComboBoxColumn();
                colJobNumber.DataSource = dt2;
                colJobNumber.DataPropertyName = "joblistID";
                colJobNumber.HeaderText = "Job#";
                colJobNumber.DisplayMember = dt2.Columns["JobNumber"].ToString();
                colJobNumber.ValueMember = dt2.Columns["joblistID"].ToString();
                colJobNumber.DisplayIndex = 1;
                colJobNumber.Width = 90;
                colJobNumber.Name = "cmbJobNumber";
                withBlock.Columns.Add(colJobNumber);

                //var colTM = new DataGridViewComboBoxColumn();
                //colTM.DataSource = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");


                var colTM = new DataGridViewComboBoxColumn();
                //colTM.DataSource = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    colTM.DataSource = StMethod.GetListDTNew<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");
                }
                else
                {
                    colTM.DataSource = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");
                }

                colTM.DisplayMember = "cTrack";
                colTM.DisplayIndex = 2;
                colTM.HeaderText = "TM";
                colTM.DataPropertyName = "TaskHandler";
                colTM.Width = 58;
                colTM.Name = "cmbTaskHandler";
                // colTM.Items.AddRange(arrTM)
                withBlock.Columns.Add(colTM);


                //var colTrack = new DataGridViewComboBoxColumn();
                //colTrack.DataSource = StMethod.GetListDT<colPreRequircolTrack>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is Null) ");

                var colTrack = new DataGridViewComboBoxColumn();

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    colTrack.DataSource = StMethod.GetListDTNew<colPreRequircolTrack>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is Null) ");
                }
                else
                {
                    colTrack.DataSource = StMethod.GetListDT<colPreRequircolTrack>("select distinct Trackname from MasterTrackSet where (IsDelete=0 or IsDelete is Null) ");
                }

                colTrack.DisplayMember = "Trackname";
                colTrack.DisplayIndex = 4;
                colTrack.HeaderText = "Track";
                colTrack.DataPropertyName = "Track";
                colTrack.Name = "cmbTrack";
                // colTrack.Items.AddRange(arrTrack)
                withBlock.Columns.Add(colTrack);


                //var colStatus = new DataGridViewComboBoxColumn();
                //colStatus.DataSource = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Status' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");


                var colStatus = new DataGridViewComboBoxColumn();

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    colStatus.DataSource = StMethod.GetListDTNew<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Status' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");
                }
                else
                {
                    colStatus.DataSource = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Status' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");
                }

                colStatus.DisplayMember = "cTrack";
                colStatus.DisplayIndex = 9;
                colStatus.HeaderText = "Status";
                colStatus.DataPropertyName = "Status";
                colStatus.Name = "cmbStatus";
                // colStatus.Items.AddRange(arr)
                withBlock.Columns.Add(colStatus);


                //var colBillStatus = new DataGridViewComboBoxColumn();
                //colBillStatus.DataSource = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Bill State' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");

                var colBillStatus = new DataGridViewComboBoxColumn();
                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    colBillStatus.DataSource = StMethod.GetListDTNew<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Bill State' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");
                }
                else
                {
                    colBillStatus.DataSource = StMethod.GetListDT<colPMM>("SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Bill State' AND (IsDelete = 0 OR IsDelete IS NULL) ORDER BY cTrack ");
                }


                colBillStatus.DisplayMember = "cTrack";
                colBillStatus.DisplayIndex = 14;
                colBillStatus.HeaderText = "Bill State";
                colBillStatus.DataPropertyName = "BillState";
                colBillStatus.Name = "cmbBillState";
                // colBillStatus.Items.AddRange(arr)
                withBlock.Columns.Add(colBillStatus);
                // Fincal action combobox
                var colFinalAction = new DataGridViewComboBoxColumn();
                colFinalAction.Items.Add("No Action");
                colFinalAction.Items.Add("Renewed");
                colFinalAction.Items.Add("Not Req'd");
                colFinalAction.HeaderText = "FinalAction";
                colFinalAction.Width = 90;
                colFinalAction.DisplayIndex = 15;
                colFinalAction.DataPropertyName = "FinalAction";
                colFinalAction.Name = "cmbFinalAction";
                withBlock.Columns.Add(colFinalAction);
                // Combo TrackComment


                // Set Column Property
                withBlock.Columns["JobListID"].DataPropertyName = "JobListID";
                withBlock.Columns["JobListID"].Visible = false;
                withBlock.Columns["JobNumber"].HeaderText = "Job#";
                withBlock.Columns["JobNumber"].Visible = false;
                withBlock.Columns["Track"].Visible = false;
                withBlock.Columns["AddDate"].Width = 90;
                withBlock.Columns["AddDate"].HeaderText = "Added";
                withBlock.Columns["NeedDate"].Visible = false;
                withBlock.Columns["Obtained"].Visible = true;
                withBlock.Columns["Obtained"].Width = 90;
                withBlock.Columns["Expires"].Visible = true;
                withBlock.Columns["Expires"].Width = 90;
                withBlock.Columns["Status"].Visible = false;
                withBlock.Columns["JobTrackingID"].Visible = false;
                withBlock.Columns["TaskHandler"].Visible = false;
                withBlock.Columns["Submitted"].Width = 90;
                withBlock.Columns["BillState"].Visible = false;
                withBlock.Columns["Comments"].HeaderText = "Comments";
                withBlock.Columns["Comments"].Width = 250;
                // .Columns["TrackSub"].Visible = False
                withBlock.Columns["TrackSub"].Width = 200;
                withBlock.Columns["FinalAction"].Visible = false;
                withBlock.Columns["TrackSubID"].Visible = false;
            }
        }

        private void fillGrid()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string queryString;
                if (string.IsNullOrEmpty(QueryForIn))
                {
                    queryString = "SELECT JobTracking.JobListID,JobList.JobNumber,JobTracking.TaskHandler,JobTracking.Track,JobTracking.TrackSub, JobTracking.Comments,JobTracking.Status,JobTracking.Submitted, JobTracking.Obtained,JobTracking.Expires,JobTracking.BillState , JobTracking.AddDate, JobTracking.NeedDate,JobTracking.FinalAction,  JobTracking.JobTrackingID,JobTracking.TrackSubID  FROM  JobTracking INNER JOIN    JobList ON JobTracking.JobListID = JobList.JobListID where JobTracking.JobTrackingID =0 and (JobTracking.IsDelete=0 or JobTracking.IsDelete is null)";
                }
                else
                {
                    queryString = "SELECT JobTracking.JobListID,JobList.JobNumber,JobTracking.TaskHandler,JobTracking.Track,JobTracking.TrackSub, JobTracking.Comments,JobTracking.Status,JobTracking.Submitted, JobTracking.Obtained,JobTracking.Expires,JobTracking.BillState , JobTracking.AddDate, JobTracking.NeedDate ,JobTracking.FinalAction , JobTracking.JobTrackingID,JobTracking.TrackSubID  FROM  JobTracking INNER JOIN    JobList ON JobTracking.JobListID = JobList.JobListID where JobTracking.JobTrackingID in(" + QueryForIn + ") and (JobTracking.IsDelete=0 or JobTracking.IsDelete is null) ";
                }

                try
                {
                    // da = New SqlDataAdapter(queryString, sqlcon)
                    dtJT.Clear();
                    grdJobTracking.Refresh();
                    // da.Fill(dtJT)
                    
                    
                    
                    //dtJT = StMethod.GetListDT<JT_JobStatusList>(queryString);
                    //grdJobTracking.DataSource = dtJT;


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        dtJT = StMethod.GetListDTNew<JT_JobStatusList>(queryString);
                    }
                    else
                    {
                        dtJT = StMethod.GetListDT<JT_JobStatusList>(queryString);
                    }



                    grdJobTracking.DataSource = dtJT;

                }
                catch (Exception eLoad)
                {
                    // Add your error handling code here.
                    // Display error message, if any.
                    KryptonMessageBox.Show(eLoad.Message, "Calendar");
                }

                // Grid Formatting
                // Set Column Property
                {
                    var withBlock = grdJobTracking;
                    withBlock.Columns["JobListID"].DataPropertyName = "JobListID";
                    withBlock.Columns["JobListID"].Visible = false;
                    withBlock.Columns["JobNumber"].HeaderText = "Job#";
                    withBlock.Columns["JobNumber"].Visible = false;
                    withBlock.Columns["Track"].Visible = false;
                    withBlock.Columns["AddDate"].Width = 90;
                    withBlock.Columns["AddDate"].HeaderText = "Added";
                    withBlock.Columns["NeedDate"].Visible = false;
                    withBlock.Columns["Obtained"].Visible = true;
                    withBlock.Columns["Obtained"].Width = 90;
                    withBlock.Columns["Expires"].Visible = true;
                    withBlock.Columns["Expires"].Width = 90;
                    withBlock.Columns["Status"].Visible = false;
                    withBlock.Columns["JobTrackingID"].Visible = false;
                    withBlock.Columns["TaskHandler"].Visible = false;
                    withBlock.Columns["Submitted"].Width = 90;
                    withBlock.Columns["BillState"].Visible = false;
                    withBlock.Columns["Comments"].HeaderText = "Comments";
                    withBlock.Columns["Comments"].Width = 250;
                    // .Columns["TrackSub"].Visible = False
                    withBlock.Columns["TrackSub"].Width = 200;
                }

                if (grdJobTracking.Rows.Count > 0)
                {
                    grdJobTracking.CurrentCell = grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["Submitted"];
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private bool Checkvaliduser()
        {
            bool CheckvaliduserRet = default;
            string Username = Properties.Settings.Default.timeSheetLoginName;
            string UserType = Properties.Settings.Default.timeSheetLoginUserType;
            CheckvaliduserRet = false;
            if ((Username ?? "") != (string.Empty ?? ""))
            {
                string query2 = "select * from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + Username + "' and cGroup = 'TM'";


                //if (StMethod.IsMastersExist(query2))
                //{
                //    CheckvaliduserRet = true;
                //}
                //else
                //{
                //    CheckvaliduserRet = false;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    if (StMethod.IsMastersExistNew(query2))
                    {
                        CheckvaliduserRet = true;
                    }
                    else
                    {
                        CheckvaliduserRet = false;
                    }
                }
                else
                {
                    if (StMethod.IsMastersExist(query2))
                    {
                        CheckvaliduserRet = true;
                    }
                    else
                    {
                        CheckvaliduserRet = false;
                    }
                }


            }
            else
            {
            }

            return CheckvaliduserRet;
        }

        protected void InsertJobTracking()
        {
            grdJobTracking.Rows[0].Cells[5].Selected = true;
            grdJobTracking.EndEdit();
            try
            {
                if (grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["cmbJobNumber"].EditedFormattedValue.ToString().Trim() == string.Empty)
                {
                    KryptonMessageBox.Show("Please select Job Number ", "Calendar");
                    return;
                    grdJobTracking.CurrentCell = grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells[14];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            try
            {
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
                int cnt = grdJobTracking.Rows.Count - 1;
                //string sql=" Insert into Jobtra.Rows[JobListID,Track,AddDate,NeedDate,Obtained,Expires,Status,Submitted,BillState,TaskHandler,TrackSub,Comments,FinalAction,IsNewRecord,TrackSubID) values (@JobListID,@Track,@AddDate,@NeedDate,@Obtained,@Expires,@Status,@Submitted,@BillState,@TaskHandler,@TrackSub,@Comments,@FinalAction,@IsNewRecord,@TrackSubID) SELECT @@IDENTITY AS 'currentFileID'";
             
                string sql = " Insert into Jobtracking(JobListID,Track,AddDate,NeedDate,Obtained,Expires,Status,Submitted,BillState,TaskHandler,TrackSub,Comments,FinalAction,IsNewRecord,TrackSubID) values (@JobListID,@Track,@AddDate,@NeedDate,@Obtained,@Expires,@Status,@Submitted,@BillState,@TaskHandler,@TrackSub,@Comments,@FinalAction,@IsNewRecord,@TrackSubID) SELECT @@IDENTITY AS 'currentFileID'";
                var Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@IsNewRecord", 1));
                Param.Add(new SqlParameter("@JobListID", ((System.Windows.Forms.DataGridViewComboBoxCell)grdJobTracking.Rows[cnt].Cells["cmbJobNumber"]).Value));
                Param.Add(new SqlParameter("@TaskHandler", grdJobTracking.Rows[cnt].Cells["cmbTaskHandler"].Value.ToString()));
                Param.Add(new SqlParameter("@Track", grdJobTracking.Rows[cnt].Cells["cmbTrack"].Value.ToString()));


                //DateTime InsertSubmitted = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString())).ToString("MM/d/yyyy"));

                //Param.Add(new SqlParameter("@Submitted", InsertSubmitted));

                //Param.Add(new SqlParameter("@Submitted", DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString())));

                //MessageBox.Show("1");

                DateTime InsertSubmitted = Convert.ToDateTime(grdJobTracking.Rows[cnt].Cells["Submitted"].Value.ToString());
                string SubmittedStr = "";
                SubmittedStr = InsertSubmitted.Month + "-" + InsertSubmitted.Day + "-" + InsertSubmitted.Year + " " + InsertSubmitted.ToLongTimeString();
                Param.Add(new SqlParameter("@Submitted", SubmittedStr.ToString()));

                //MessageBox.Show("2");

                //DateTime Obtained = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["Obtained"].Value.ToString());
                //string ObtainedStr = "";
                //ObtainedStr = Obtained.Month + "-" + Obtained.Day + "-" + Obtained.Year + " " + Obtained.ToLongTimeString();

                //Param.Add(new SqlParameter("@Obtained", ObtainedStr.ToString()));


                Param.Add(new SqlParameter("@BillState", grdJobTracking.Rows[cnt].Cells["cmbBillState"].Value.ToString()));
                Param.Add(new SqlParameter("@TrackSub", grdJobTracking.Rows[cnt].Cells["TrackSub"].Value.ToString()));
                Param.Add(new SqlParameter("@Comments", grdJobTracking.Rows[cnt].Cells["Comments"].Value.ToString()));
                Param.Add(new SqlParameter("@Status", grdJobTracking.Rows[cnt].Cells["cmbStatus"].Value.ToString()));


                //DateTime InsertObtained = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString())).ToString("MM/d/yyyy"));
                //Param.Add(new SqlParameter("@Obtained", InsertObtained));

                //Param.Add(new SqlParameter("@Obtained", grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString()));


                //MessageBox.Show("3");

                DateTime InsertObtained = Convert.ToDateTime(grdJobTracking.Rows[cnt].Cells["Obtained"].Value.ToString());
                string ObtainedStr = "";
                ObtainedStr = InsertObtained.Month + "-" + InsertObtained.Day + "-" + InsertObtained.Year + " " + InsertObtained.ToLongTimeString();
                Param.Add(new SqlParameter("@Obtained", ObtainedStr.ToString()));


                //MessageBox.Show("4");

                //DateTime InsertExpires = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString())));
                //Param.Add(new SqlParameter("@Expires", InsertExpires));

                //Param.Add(new SqlParameter("@Expires", grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString()));


                //MessageBox.Show("5");

                DateTime InsertExpires = Convert.ToDateTime(grdJobTracking.Rows[cnt].Cells["Expires"].Value.ToString());
                string ExpiresStr = "";
                ExpiresStr = InsertExpires.Month + "-" + InsertExpires.Day + "-" + InsertExpires.Year + " " + InsertExpires.ToLongTimeString();
                Param.Add(new SqlParameter("@Expires", ExpiresStr.ToString()));

                //MessageBox.Show("6");

                //DateTime Expires = Convert.ToDateTime(grvPreRequirments.Rows[cnt].Cells["Expires"].Value.ToString());
                //string ExpiresStr = "";
                //ExpiresStr = Expires.Month + "-" + Expires.Day + "-" + Expires.Year + " " + Expires.ToLongTimeString();

                //Param.Add(new SqlParameter("@Expires", ExpiresStr.ToString()));


                //DateTime InsertAddDate = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString())));

                //Param.Add(new SqlParameter("@AddDate", InsertAddDate));

                //Param.Add(new SqlParameter("@AddDate", grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString()));

                //MessageBox.Show("7");

                DateTime InsertAddDate = Convert.ToDateTime(grdJobTracking.Rows[cnt].Cells["AddDate"].Value.ToString());
                string AddDateStr = "";
                AddDateStr = InsertAddDate.Month + "-" + InsertAddDate.Day + "-" + InsertAddDate.Year + " " + InsertAddDate.ToLongTimeString();
                Param.Add(new SqlParameter("@AddDate", AddDateStr.ToString()));

                //MessageBox.Show("8");

                //DateTime InsertNeedDate = Convert.ToDateTime((DateTime.Parse(grdJobTracking.Rows[cnt].Cells["NeedDate"].Value.ToString())));
                //Param.Add(new SqlParameter("@NeedDate", InsertNeedDate));

                //Param.Add(new SqlParameter("@NeedDate", grdJobTracking.Rows[cnt].Cells["NeedDate"].Value.ToString()));

                //MessageBox.Show("9");

                DateTime InsertNeedDate = Convert.ToDateTime(grdJobTracking.Rows[cnt].Cells["NeedDate"].Value.ToString());
                string NeedDateeStr = "";
                NeedDateeStr = InsertNeedDate.Month + "-" + InsertNeedDate.Day + "-" + InsertNeedDate.Year + " " + InsertNeedDate.ToLongTimeString();
                Param.Add(new SqlParameter("@NeedDate", NeedDateeStr.ToString()));

                //MessageBox.Show("10");

                Param.Add(new SqlParameter("@FinalAction", grdJobTracking.Rows[cnt].Cells["FinalAction"].Value.ToString()));
                Param.Add(new SqlParameter("@TrackSubID", grdJobTracking.Rows[cnt].Cells["TrackSubID"].Value.ToString()));


                //int num = StMethod.UpdateRecord(sql, Param);
                //num = StMethod.GetSingleInt("Select Top 1 JobTrackingID From Jobtracking");

                int num;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    num = StMethod.UpdateRecordNew(sql, Param);
                    num = StMethod.GetSingleIntNew("Select Top 1 JobTrackingID From Jobtracking");
                }
                else
                {
                    num = StMethod.UpdateRecord(sql, Param);
                    num = StMethod.GetSingleInt("Select Top 1 JobTrackingID From Jobtracking");
                }

                if (num > 0)
                {
                    // System.Windows.Forms.MessageBox.Show("Record Saved!", "Message")
                    KryptonMessageBox.Show("Save Sucessfully", "Calendar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    QueryForIn = QueryForIn + ",'" + num + "'";
                    if (QueryForIn.IndexOf(",") == 0)
                    {
                        QueryForIn = QueryForIn.Remove(0, 1);
                    }

                    fillGrid();
                    FillCalendar(CurrDate);
                    if (grdJobTracking.Rows.Count > 0)
                    {
                        grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Selected = true;
                        grdJobTracking.CurrentCell = grdJobTracking.Rows[grdJobTracking.Rows.Count - 1].Cells["TrackSub"];
                    }
                    btnInsert.Text = "Insert";
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Calendar");
            }
        }

        private string chboxstatus()
        {
            ChString = "";
            if (chkSubmitted.Checked == true)
            {
                ChString = ChString + "S";
            }

            if (chkExpired.Checked == true)
            {
                ChString = ChString + "E";
            }

            if (chkObtained.Checked == true)
            {
                ChString = ChString + "O";
            }
            return cGlobal.SortString(ChString);
        }
        #endregion

        private void grdJobTracking_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                //MessageBox.Show("Column number is  => " + e.ColumnIndex + "Value is => " + e.Value.ToString());

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


                if (e.ColumnIndex == 9)
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


                if (e.ColumnIndex == 10)
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

                if (e.ColumnIndex == 12)
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

                    //string inputString;
                    //DateTime dDate;

                    //inputString = e.Value.ToString();
                    //if (DateTime.TryParse(inputString, out dDate))
                    //{
                    //    //String.Format("{0:d/MM/yyyy}", dDate);

                    //    e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                    //    e.FormattingApplied = true;
                    //}
                    //else
                    //{


                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}