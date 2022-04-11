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
using System.Globalization;

namespace JobTracker
{
    public partial class frmTasklist : Form
    {
        #region Declaration
        string CheckCelleditvalue = null;
        string UserType = null;
        string UserName = null;
        bool checkUser = false;
        #endregion

        public frmTasklist()
        {
            InitializeComponent();
        }

        #region Events
        private void frmTasklist_Load(System.Object sender, System.EventArgs e)
        {
            cbxJobListPM.SelectedIndexChanged -= this.cbxJobListPM_SelectedIndexChanged;
            cbxJobListPMrv.SelectedIndexChanged -= this.cbxJobListPMrv_SelectedIndexChanged;
            ComTaskListPMsearch.SelectedIndexChanged -= this.ComTaskListPMsearch_SelectedIndexChanged;
            ComTaskListTMsearch.SelectedIndexChanged -= this.ComTaskListTMsearch_SelectedIndexChanged;
            ComTaskListJobStatusSearch.SelectedIndexChanged -= this.ComTaskListJobStatusSearch_SelectedIndexChanged;
            gbDateUserSearch.Enabled = false; //Date searching

            chkNotInvoiceJob.Visible = false;
            lblCompanyNo.Visible = false;

            checkValiduser();
            AddStatus_grdTadkList();
            AddPM_grdTaskList();
            AddTM_grdTaskList();
            fillgrvJobsearch();
            fillgrdTaskList();
            fillPMSearch();
            fillStatusSearch();
            fillDescriptionSearch();
            ChktaskListDateSearch.Checked = true;

            //checkValiduser();
            //AddStatus_grdTadkList();
            //AddPM_grdTaskList();
            //AddTM_grdTaskList();
            //fillgrvJobsearch();
            //fillgrdTaskList();
            //fillPMSearch();
            //fillStatusSearch();
            //fillDescriptionSearch();
            //ChktaskListDateSearch.Checked = true;

            UserType = Properties.Settings.Default.timeSheetLoginUserType;
            UserName = Properties.Settings.Default.timeSheetLoginName;

            ApplyPageLoadSetting();
            //If checkUser = True And UserType <> "Admin" Then
            //    ComTaskListJobStatusSearch.Text = "Pending"
            //    ComTaskListTMsearch.Text = UserName.ToString()
            //    ComTaskListPMsearch.Text = ""
            //    txtJobNumber.Text = "VE-010"
            //End If

            cbxJobListPM.SelectedIndexChanged += this.cbxJobListPM_SelectedIndexChanged;
            cbxJobListPMrv.SelectedIndexChanged += this.cbxJobListPMrv_SelectedIndexChanged;
            ComTaskListPMsearch.SelectedIndexChanged += this.ComTaskListPMsearch_SelectedIndexChanged;
            ComTaskListTMsearch.SelectedIndexChanged += this.ComTaskListTMsearch_SelectedIndexChanged;
            ComTaskListJobStatusSearch.SelectedIndexChanged += this.ComTaskListJobStatusSearch_SelectedIndexChanged;
        }
        private void txtBox_TextChanged(System.Object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                int TagValue = Convert.ToInt32(((TextBox)sender).Tag);
                if (TagValue == 1)
                    fillgrvJobsearch();
                else if (TagValue == 2)
                {
                    fillgrvJobsearch();
                    fillgrdTaskList();
                }
                else
                    fillgrdTaskList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        //private void cbxJobListDescription_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        //{
        //    fillgrvJobsearch();
        //    fillgrdTaskList();
        //}
        private void cbxJobListPM_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            fillgrvJobsearch();
            fillgrdTaskList();
        }
        private void cmbStatus_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            fillgrvJobsearch();
            fillgrdTaskList();
        }
        private void chkSearchPending_Click(System.Object sender, System.EventArgs e)
        {
            if (chkSearchPending.Checked == true)
            {
                fillgrdTaskList();
            }
            else
            {
                fillgrdTaskList();
            }
        }
        private void btClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                chkTaskListSearch.Checked = false;
                gbDateUserSearch.Enabled = false;

                txtJobNumber.Text = "";
                txtJoblistClienttext.Text = "";
                txtTown.Text = "";
                txtJobListAddress.Text = "";
                cmbStatus.Text = "";
                txtJobListDescription.Text = "";
                //cbxJobListDescription.Text = ""
                txtJobListclient.Text = "";
                chkSearchPending.Checked = false;
                cbxJobListPM.Text = "";
                cbxJobListPMrv.Text = "";
                fillgrvJobsearch();
                fillgrdTaskList();
            }
            catch (Exception ex)
            {

            }
        }
        private void chkTaskListSearch_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (chkTaskListSearch.Checked == true)
                {
                    gbDateUserSearch.Enabled = true;

                }
                else
                {
                    gbDateUserSearch.Enabled = false;
                }
                fillgrdTaskList();
            }
            catch (Exception ex)
            {

            }
        }
        private void dtpDateSearchTo_ValueChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                fillgrdTaskList();
            }
            catch (Exception ex)
            {

            }
        }
        private void btnTaskListSearchClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                txtTaskListJobSearch.Text = string.Empty;
                
                ComTaskListJobStatusSearch.SelectedIndex = 0;

                // comtaskdiscriptionSearch.SelectedIndex = 0
                txtTaskDescription.Text = string.Empty;
                
                ComTaskListPMsearch.SelectedIndex = 0;
                ComTaskListTMsearch.SelectedIndex = 0;

                ChktaskListDateSearch.Checked = false;
                fillgrdTaskList();
            }
            catch (Exception ex)
            {

            }
        }
        //        ComTaskListJobStatusSearch.SelectedIndexChanged
        private void ComTaskListJobStatusSearch_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                fillgrdTaskList();
            }
            catch (Exception ex)
            {
            }
        }
        private void ComTaskListPMsearch_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {

            if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
            {
                grdTaskList.Enabled = true;

                checkUser = true;
                fillgrdTaskList();
            }
            else
            {
                UserPmTmSearch();
            }
        }
        private void ComTaskListTMsearch_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
            {

                checkUser = true;
                grdTaskList.Enabled = true;
                fillgrdTaskList();
            }
            else
            {
                UserPmTmSearch();
            }
        }
        private void ChktaskListDateSearch_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            if (ChktaskListDateSearch.Checked == true)
            {
                gbDateTaskListSearch.Enabled = true;
            }
            else
            {
                gbDateTaskListSearch.Enabled = false;
            }
            fillgrdTaskList();
        }
        //private void comtaskdiscriptionSearch_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        //{
        //    fillgrdTaskList();
        //}
        //private void dtpTaskListDateSearch_ValueChanged(System.Object sender, System.EventArgs e)
        //{
        //    if (ChktaskListDateSearch.Checked == true)
        //    {
        //        fillgrdTaskList();
        //    }
        //}
        private void grvJobList_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            checkValiduser();
            if (checkUser == true)
            {

                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {

                    DataTable dt = new DataTable();

                    //dt = Program.ToDataTable<TaskListData>((List<TaskListData>)grdTaskList.DataSource);
                    dt = (DataTable)grdTaskList.DataSource;
                    Int16 rowindex = (Int16)dt.Rows.Count;

                    DataRow dr = dt.NewRow();
                    // dr("TaskLisiId") = 1 ' 
                    dr["JobNumber"] = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                    dr["Status"] = "Pending"; // CodeAnalysis By shanker(10/8/2013)



                    // Code Added By Devendra Sarang

                    string queryString = "SELECT * FROM TaskList WHERE JobNumber='" + grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString() + "'";

                    DataTable dtTasList = new DataTable();
                    //dtTasList = StMethod.GetListDT<TaskListData>(queryString);


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        dtTasList = StMethod.GetListDTNew<TaskListData>(queryString);
                    }
                    else
                    {
                        dtTasList = StMethod.GetListDT<TaskListData>(queryString);
                    }

                    String TaskListId = "";


                    if (dtTasList.Rows.Count > 0)
                    {
                        //foreach (DataRow row in dtTasList.Rows)
                        //{
                        //    string file = row.Field<string>("TaskLisiId");
                        //}

                        TaskListId = dtTasList.Rows[0].Field<string>(0);

                    }


                    dr["TaskLisiId"] = TaskListId;






                    //grdTaskList.Columns.Add(grdTaskListSTATUS)
                    // dr("PM") = grvJobList.Rows[grvJobList.CurrentRow.Index].Cells["Handler"].Value.ToString()
                    // dr("TM") = ""
                    //  dr("Description") = ""

                    //dr["Date"] = DateTime.Now.ToShortDateString();
                    //dr["CompletedByDate"] = DateTime.Now.ToShortDateString();


                    dr["Date"] = DateTime.Now.ToString ();
                    dr["CompletedByDate"] = DateTime.Now.ToString ();


                    // dr("Status") = ""

                    dt.Rows.Add(dr);
                    if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                    {

                        try
                        {
                            XmlDocument myDoc = new XmlDocument();

                            string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                            dir2 = dir2 + "\\JobTracker";
                            myDoc.Load(dir2 + "\\VESoftwareSetting.xml");


                            //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                            if (myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Apply"].InnerText == "Yes")
                            {
                                dr["PM"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["PM"].InnerText;
                                dr["TM"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["TM"].InnerText;
                                dr["Description"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Description"].InnerText;
                            }
                            else
                            {
                                dr["PM"] = "";
                                dr["TM"] = "";
                                dr["Description"] = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            dr["PM"] = "";
                            dr["TM"] = "";
                            dr["Description"] = "";
                        }

                        grdTaskList.DataSource = dt;
                        grdTaskList.Rows[rowindex].DefaultCellStyle.BackColor = Color.Yellow;
                        grdTaskList.Rows[rowindex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                    }
                    else
                    {

                        try
                        {
                            XmlDocument myDoc = new XmlDocument();

                            string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                            dir2 = dir2 + "\\JobTracker";
                            myDoc.Load(dir2 + "\\VESoftwareSetting.xml");


                            //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");

                            if (UserName.ToString() == myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["PM"].InnerText)
                            {
                                dr["PM"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["PM"].InnerText;
                                dr["TM"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["TM"].InnerText;
                                dr["Description"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Description"].InnerText;
                            }
                            else if (UserName.ToString() == myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["TM"].InnerText)
                            {

                                dr["PM"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["PM"].InnerText;
                                dr["TM"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["TM"].InnerText;
                                dr["Description"] = myDoc["VESoftwareSetting"]["AutoInsert"]["TaskList"]["Description"].InnerText;

                            }
                            else
                            {
                                dr["PM"] = "";
                                dr["TM"] = "";
                                dr["Description"] = "";
                            }
                        }
                        catch (Exception ex)
                        {
                            dr["PM"] = "";
                            dr["TM"] = "";
                            dr["Description"] = "";
                        }
                        //dr("PM") = UserName.ToString()
                        //dr("TM") = UserName.ToString()
                        grdTaskList.DataSource = dt;
                        grdTaskList.Rows[rowindex].DefaultCellStyle.BackColor = Color.Yellow;
                        grdTaskList.Rows[rowindex].DefaultCellStyle.SelectionBackColor = Color.Yellow;
                    }
                }
            }
            else
            {

                //MessageBox.Show(" ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            }

        }
        private void grdTaskList_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    string checkvalue = (grdTaskList.Rows[e.RowIndex].Cells["TaskLisiId"].Value.ToString());
                    string checkDate = grdTaskList.Rows[e.RowIndex].Cells["CompletedByDate"].Value.ToString();
                   

                    //if (String .IsNullOrEmpty (checkDate ))
                    //{

                    //    checkDate = DBNull.Value.ToString ();

                    //}


                    if (string.IsNullOrEmpty(checkvalue))
                    {

                        string query1 = "INSERT INTO TaskList ( JobNumber, PM, TM, Description, Date, CompletedByDate, Status)VALUES(@JobNumber,@PM,@TM,@Description,@Date,@CompletedByDate,@Status)";
                        List<System.Data.SqlClient.SqlParameter> param1 = new List<System.Data.SqlClient.SqlParameter>();
                        param1.Add(new SqlParameter("@JobNumber", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["JobNumber"].Value.ToString()));
                        param1.Add(new SqlParameter("@PM", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["AddPMCmbx"].Value.ToString()));
                        param1.Add(new SqlParameter("@TM", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["AddTMCmbx"].Value.ToString()));
                        param1.Add(new SqlParameter("@Description", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["Description"].Value.ToString()));


                        //DateTime Dn = Convert.ToDateTime(grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["Date"].Value.ToString());

                        //string DNStr = "";

                        //DNStr = Dn.Month + "-" + Dn.Day + "-" + Dn.Year + " " + Dn.ToLongTimeString();


                        string Dn = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                                           

                        param1.Add(new SqlParameter("@Date", Dn));

                        //param1.Add(new SqlParameter("@Date", DNStr.ToString()));
                        //param1.Add(new SqlParameter("@Date", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["Date"].Value.ToString()));

                        if (string.IsNullOrEmpty(checkDate) || checkDate == "1/1/0001 12:00:00 AM")
                        {
                            param1.Add(new SqlParameter("@CompletedByDate", DBNull.Value));

                        }
                        else
                        {
                            //DateTime CBD = Convert.ToDateTime(grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["CompletedByDate"].Value.ToString());

                            //string CBDStr = "";

                            //CBDStr = CBD.Month + "-" + CBD.Day + "-" + CBD.Year + " " + CBD.ToLongTimeString();



                            


                            string CBDStr = grdTaskList.Rows[e.RowIndex].Cells["CompletedByDate"].Value.ToString();

                            param1.Add(new SqlParameter("@CompletedByDate", CBDStr));

                            //param1.Add(new SqlParameter("@CompletedByDate", CBDStr.ToString()));


                            //param1.Add(new SqlParameter("@CompletedByDate", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["CompletedByDate"].Value.ToString()));
                        }


                        param1.Add(new SqlParameter("@Status", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["AddStatusCmbx"].Value.ToString()));
                        //param1.Add(.SqlParameter("@TaskLisiId", grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["TaskLisiId"].Value.ToString()))





                        //if (StMethod.UpdateRecord(query1, param1) > 0)
                        //{
                        //    MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //    // fillgrdTaskList()
                        //    grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        //    grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                        //    //fillgrdTaskList();
                        //}


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            if (StMethod.UpdateRecordNew(query1, param1) > 0)
                            {
                                MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // fillgrdTaskList()
                                grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                //fillgrdTaskList();
                            }
                        }
                        else
                        {
                            if (StMethod.UpdateRecord(query1, param1) > 0)
                            {
                                MessageBox.Show("Save Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // fillgrdTaskList()
                                grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                //fillgrdTaskList();
                            }
                        }

                        return;
                    }

                    //string Date101 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                    //string Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag.ToString();

                    string Date101, Date102=null;

                    //if (grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString()!=null)
                    //{
                    //    Date101 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                    //}

                    //if (grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag.ToString() != null)
                    //{
                    //    Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag.ToString();
                    //}


                    if (grdTaskList.Rows[e.RowIndex].Cells["Date"].Value == null || grdTaskList.Rows[e.RowIndex].Cells["Date"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString()))
                    {
                        // here is your message box...

                        
                    }
                    else
                    {
                        Date101 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                    }


                    if (grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag == null || grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag.ToString()))
                    {
                        // here is your message box...

                        //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        Date102 = string.Format("{0:MM/dd/yyyy}", grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                        //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                    }
                    else
                    {
                        Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag.ToString();
                    }

                    //if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString())
                    //{
                    //    // here is your message box...
                    //}



                    string Query = "UPDATE    TaskList SET JobNumber =@JobNumber, PM =@PM, TM =@TM, Description =@Description, Date =@Date, CompletedByDate =@CompletedByDate, Status =@Status Where TaskLisiId=@TaskLisiId ";

                    string checkDateUpdate = grdTaskList.Rows[e.RowIndex].Cells["CompletedByDate"].Value.ToString();


                    //  string s1, s2, s3, s4, s5;

                    //s1 = grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["JobNumber"].Value.ToString();
                    // s2 = grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["AddPMCmbx"].Value.ToString();
                    // s3 =  grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["AddTMCmbx"].Value.ToString();
                    // s4 =  grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Description"].Value.ToString();
                    // s5 =  grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString();

                    List<System.Data.SqlClient.SqlParameter> param = new List<System.Data.SqlClient.SqlParameter>();
                    param.Add(new SqlParameter("@JobNumber", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["JobNumber"].Value.ToString()));
                    param.Add(new SqlParameter("@PM", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["AddPMCmbx"].Value.ToString()));
                    param.Add(new SqlParameter("@TM", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["AddTMCmbx"].Value.ToString()));
                    param.Add(new SqlParameter("@Description", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Description"].Value.ToString()));




                    //param.Add(new SqlParameter("@Date", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString()));


                    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                    //DateTime DateNew = Convert.ToDateTime(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString()).ToString("MM/d/yyyy");

                    //DateTime DateNew = (DateTime.Parse(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString())).ToString("MM/d/yyyy"); ;



                    //DateTime DateNewStr = (DateTime.Parse(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString()));


                    //String dt = DateTime.Parse(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString()).ToString("MM/d/yyyy");

                    //DateTime dt1 = Convert.ToDateTime(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString());

                    //String dt = DateTime.Parse(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString()).ToString();


                    //String DT11= grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString();
                    ////DateTime dtnew = DateTime.Parse(DT11, "mm/dd/yyyy");

                    //DateTime loadedDate = DateTime.ParseExact(DT11, "dd/MM/yyyy",null);
                    ////insert = DateTime.ParseExact(line[i], "M/d/yyyy hh:mm", CultureInfo.InvariantCulture);


                    //param.Add(new SqlParameter("@Date", loadedDate));

                    //DateTime loadedDate;

                    //String lblMsg = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
                    //String s1,s2;

                    //if (lblMsg == "dd/MM/yyyy")
                    //{
                    //    //txtd.Text = DateTime.Parse(dr["EventDate"].ToString()).ToString("dd/MM/yyyy");
                    //    //s1 = DateTime.Parse(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString()).ToString("dd/MM/yyyy");

                    //    //loadedDate = DateTime.ParseExact(s1, "dd/MM/yyyy", null);

                    //    //usinfo.BDate = DateTime.ParseExact(txtDOB.Text.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    //    loadedDate = DateTime.ParseExact(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    //}
                    //else
                    //{
                    //    //txtd.Text = DateTime.Parse(dr["EventDate"].ToString()).ToString("MM/dd/yyyy");
                    //    //s1 = DateTime.Parse(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString()).ToString("MM/dd/yyyy");
                    //    //loadedDate = DateTime.ParseExact(s1, "MM/dd/yyyy", null);



                    //    loadedDate = DateTime.ParseExact(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString(), "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    //}


                    //DateTime dt1 = Convert.ToDateTime(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString());

                    //string inputString = "2000-02-02";
                    //DateTime dDate;
                    //inputString = e.Value.ToString();
                    //inputString = e.Value.ToString();

                    //if (DateTime.TryParse(inputString, out dDate))
                    //{
                    //    String.Format("{0:d/MM/yyyy}", dDate);

                    //    e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                    //}

                    //string s51 = grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString();

                    //string s52  = (DateTime.Parse(s51.ToString())).ToString("MM/d/yyyy");

                    //DateTime DateNew = Convert.ToDateTime(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString());

                    //DateTime DateNew2 = Convert.ToDateTime(string.Format("{0:MM/dd/yyyy}", DateNew));

                    //string DateNewStr = "";

                    //DateNewStr = DateNew.Month + "-" + DateNew.Day + "-" + DateNew.Year + " " + DateNew.ToLongTimeString();


                    //Param.Add(new SqlParameter("@Expiration", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["Expiration"].Value)));

                    //param.Add(new SqlParameter("@Date", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString()));

                    //param.Add(new SqlParameter("@Date", NullToStrValue(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value)));


                    string Date11= grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString().ToString();

                    //string test = Convert.ToString(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value);

                    //string DateTest = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();


                    //DateTime loadedDate2 = DateTime.ParseExact(Date11, "d", null);

                    //DateTime dtcheck = Convert.ToDateTime(grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString().ToString());
                    //string x = dtcheck.ToString("MM-dd-yyyy");

                    //String dateString = "2013-09-01 16:20";

                    //String lblMsg2 = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;


                    //DateTime loadedDate3;

                    //if (lblMsg2 == "dd/MM/yyyy")
                    //{
                    //    loadedDate3 = DateTime.ParseExact(Date11, "DD-mm-yyyy", null);
                    //}
                    //else
                    //{
                    //    loadedDate3 = DateTime.ParseExact(Date11, "MM-dd-yyyy", null);

                    //}


                    //string version = cProgramInfo.sApplicationVersion;
                    //char[] ch = new char[] { '.' };
                    //string filter1 = version.Remove(Convert.ToInt32(version.LastIndexOfAny(ch).ToString()));
                    //string filter2 = filter1.Remove(Convert.ToInt32(filter1.LastIndexOfAny(ch).ToString()));

                    //string[] filtersplit = Date11.Split('/');
                    //string[] filtersplit=null;




                    //string DateNewStr = "";
                    //ContactStr[0].Trim();

                    //DateNewStr = filtersplit[0].Trim() + "-" + filtersplit[1].Trim() + "-" + filtersplit[2].Trim() ;

                    //DateNewStr = filtersplit[0].Trim() + "-" + filtersplit[1].Trim() + "-" + filtersplit[2].Trim();


                    //CultureInfo cultures = new CultureInfo("en-US");
                    //DateTime val = Convert.ToDateTime(Date11, cultures);


                    //string DateSeperator = CultureInfo.CurrentCulture.DateTimeFormat.DateSeparator;

                    //DateTime loadedDate2 = DateTime.ParseExact(Date11, "MM-dd-yyyy", null);


                    //string DateNewTesting = "";
                    //string DateNewM, DateNewD, DateNewY = "";

                    //DateNewM = loadedDate2.Month.ToString();
                    //DateNewD = loadedDate2.Day.ToString();
                    //DateNewY = loadedDate2.Year.ToString();


                    //if (DateSeperator == "/")
                    //{
                    //    //filtersplit = Date11.Split('/');
                    //    DateNewTesting = DateNewM + "/" + DateNewD + "/" +DateNewY;

                    //}
                    //else if (DateSeperator == "-")
                    //{
                    //    //filtersplit = Date11.Split('-');
                    //    DateNewTesting = DateNewM + "-" + DateNewD + "-" + DateNewY;
                    //}


                    

                    param.Add(new SqlParameter("@Date", Date102));
                    
                    //param.Add(new SqlParameter("@Date", DateNewTesting));
                    //param.Add(new SqlParameter("@Date", val));

                    //param.Add(new SqlParameter("@Date", DateNewStr));





                    //param.Add(new SqlParameter("@Date", (DateTime.Parse(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["Date"].Value.ToString())).ToString("MM/d/yyyy")));

                    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                    //param.Add(new SqlParameter("@Date", DateNewStr));


                    //param.Add(new SqlParameter("@Date", s1));

                    //string DateNewStr = "";

                    //DateNewStr = dt1.Month + "-" + dt1.Day + "-" + dt1.Year + " " + dt1.ToLongTimeString();

                    //string s2 = dt.ToString("MM/dd/yyyy");
                    //DateTime dtnew = DateTime.Parse(s2);
                    //param.Add(new SqlParameter("@Date", dtnew));

                    //string DateNewStr = "";

                    //DateNewStr = dt1.Month + "-" + dt1.Day + "-" + dt1.Year + " " + dt1.ToLongTimeString();

                    //string dt = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();




                    if (string.IsNullOrEmpty(checkDateUpdate) || checkDateUpdate == "1/1/0001 12:00:00 AM")
                    {
                        param.Add(new SqlParameter("@CompletedByDate", DBNull.Value));

                    }
                    else
                    {

                        //DateTime CompletedByDate = Convert.ToDateTime(grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["CompletedByDate"].Value.ToString());

                        //string CompletedByStr = "";

                        //CompletedByStr = CompletedByDate.Month + "-" + CompletedByDate.Day + "-" + CompletedByDate.Year + " " + CompletedByDate.ToLongTimeString();

                   

                        string CompletedByDate = grdTaskList.Rows[e.RowIndex].Cells["CompletedByDate"].Value.ToString();

                        param.Add(new SqlParameter("@CompletedByDate", CompletedByDate));

                        //param.Add(new SqlParameter("@CompletedByDate", "CAST ('" + CompletedByStr + "' AS DATETIME)"));

                        //param.Add(new SqlParameter("@CompletedByDate", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["CompletedByDate"].Value.ToString()));


                    }

                    param.Add(new SqlParameter("@Status", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["AddStatusCmbx"].Value.ToString()));
                    param.Add(new SqlParameter("@TaskLisiId", grdTaskList.Rows[grdTaskList.CurrentRow.Index].Cells["TaskLisiId"].Value.ToString()));

                    //if (StMethod.UpdateRecord(Query, param) > 0)
                    //{
                    //    //grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink

                    //    MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    //    grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);


                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        if (StMethod.UpdateRecordNew(Query, param) > 0)
                        {
                            //grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink

                            MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);


                        }

                    }
                    else
                    {
                        if (StMethod.UpdateRecord(Query, param) > 0)
                        {
                            //grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink

                            MessageBox.Show("Update Successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);


                        }
                    }

                    //fillgrdTaskList();
                }
                if (e.ColumnIndex == 1 && e.RowIndex > -1)
                {

                    if (KryptonMessageBox.Show("Are you sure to want delete", "Task list", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {

                        string testquery = "DELETE FROM TaskList WHERE TaskLisiId=" + grdTaskList.Rows[e.RowIndex].Cells["TaskLisiId"].Value.ToString();

                        string temp_tasklistid = grdTaskList.Rows[e.RowIndex].Cells["TaskLisiId"].Value.ToString();

                        //testquery = string.Concat(testquery, temp_tasklistid);

                        if (string.IsNullOrEmpty(temp_tasklistid))
                        {

                            temp_tasklistid = " ";
                        }
                        else
                        {


                        }

                        string newquery = " ";


                        // newquery=string.Concat(testquery, temp_tasklistid);
                        // newquery = testquery + temp_tasklistid;

                        //if (StMethod.UpdateRecord("DELETE FROM TaskList WHERE TaskLisiId=" + grdTaskList.Rows[e.RowIndex].Cells["TaskLisiId"].Value.ToString()) > 0)

                        newquery = "DELETE FROM TaskList WHERE TaskLisiId= '" + temp_tasklistid + "'";



                        //if (StMethod.UpdateRecord("DELETE FROM TaskList WHERE TaskLisiId= '" + temp_tasklistid + "'") > 0)
                        //{

                        //    KryptonMessageBox.Show("Delete Successfully", "Task List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    grdTaskList.Rows.RemoveAt(e.RowIndex);
                        //    StMethod.LoginActivityInfo("Delete", this.Name);
                        //}


                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            if (StMethod.UpdateRecordNew("DELETE FROM TaskList WHERE TaskLisiId= '" + temp_tasklistid + "'") > 0)
                            {

                                KryptonMessageBox.Show("Delete Successfully", "Task List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdTaskList.Rows.RemoveAt(e.RowIndex);
                                StMethod.LoginActivityInfoNew("Delete", this.Name);
                            }


                        }
                        else
                        {
                            if (StMethod.UpdateRecord("DELETE FROM TaskList WHERE TaskLisiId= '" + temp_tasklistid + "'") > 0)
                            {

                                KryptonMessageBox.Show("Delete Successfully", "Task List", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdTaskList.Rows.RemoveAt(e.RowIndex);
                                StMethod.LoginActivityInfo("Delete", this.Name);
                            }


                        }


                        //If DAL.InsertRecord("DELETE FROM TaskList WHERE TaskLisiId=" & grdTaskList.Rows(e.RowIndex).Cells("TaskLisiId").Value.ToString) > 0 Then
                        //    KryptonMessageBox.Show("Delete Successfully", "Task List", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        //    grdTaskList.Rows.RemoveAt(e.RowIndex)
                        //    DAL.LoginActivityInfo("Delete", Me.Name)
                        //End If


                    }
                    fillgrdTaskList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private string NullToStrValue(object obj)
        {
            if (obj is null)
                return "";
            else
                return Convert.ToString(obj);
        }

        private void grdTaskList_CellLeave(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //If grdTaskList[e.ColumnIndex, e.RowIndex].Value.ToString <> CheckCelleditvalue Then
            //    grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink
            //    grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink
            //    CheckCelleditvalue = String.Empty
            //End If

            //If grdTaskList[e.ColumnIndex, e.RowIndex].Value.ToString <> CheckCelleditvalue Then
            //    If (grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow) And (grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Yellow) Then

            //    Else

            //        grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink
            //        grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink
            //        CheckCelleditvalue = String.Empty
            //    End If

            //End If
        }
        private void grdTaskList_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            try 
            {

                String value2 = grdTaskList.Rows[e.RowIndex].Cells[7].Value.ToString() as string;

            if (grdTaskList[e.ColumnIndex, e.RowIndex].Value.ToString() != CheckCelleditvalue)
            {
                if (grdTaskList.Rows[e.RowIndex].Cells["AddStatusCmbx"].Value.ToString() != "Pending")
                {
                    // grdTaskList.Rows[e.RowIndex].Cells["CompletedByDate"].Value = DateTime.Now.ToShortDateString();
                    grdTaskList.Rows[e.RowIndex].Cells["CompletedByDate"].Value = DateTime.Now;
                }
                else
                {
                    grdTaskList.Rows[e.RowIndex].Cells["CompletedByDate"].Value = string.Empty;
                }

                if ((grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Yellow) && (grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor == Color.Yellow))
                {
                }
                else
                {
                    grdTaskList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    grdTaskList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;

                    CheckCelleditvalue = string.Empty;
                        //CheckCelleditvalue = value2;




                   }
                   //String value = e.Value as string;



                    if (e.ColumnIndex == 7)
                    {

                        if ((value2 != null) && (value2 != string.Empty))
                        {

                            string inputString = "2000-02-02";

                            DateTime dDate = DateTime.Now;

                            //inputString = "02-02-2000";
                            //inputString = value2.ToString();


                            //inputString = string.Format("{0:dd/MM/yyyy}", value2);


                            inputString = string.Format("{0:MM/d/yyyy}", value2);
                            inputString = value2.ToString() + " 12:00:00 AM";

                            inputString = value2.ToString();


                            //value2 = string.Format("{0:MM/dd/yyyy}", dDate);
                            //grdTaskList.Rows[e.RowIndex].Cells[7].Value = value2;


                            if (DateTime.TryParse(inputString, out dDate))
                            {
                                //String.Format("{0:d/MM/yyyy}", dDate);

                                //e.Value = string.Format("{0:d/MM/yyyy}", dDate);



                                value2 = string.Format("{0:MM/dd/yyyy}", dDate);

                                string temp = string.Format("{0:dd/MM/yyyy}", value2);

                                //grdTaskList.Rows[e.RowIndex].Cells[7].Value = grdTaskList.Rows[e.RowIndex].Cells[7].Value;
                                grdTaskList.Rows[e.RowIndex].Cells[7].Value = value2;
                                grdTaskList.Rows[e.RowIndex].Cells[7].Tag = inputString;


                                //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                                //String value = grdTaskList.Rows[e.RowIndex].Cells[7].Value.ToString() as string;

                            }
                            else
                            {
                                //e.Value = e.CellStyle.NullValue;
                                //e.FormattingApplied = true;     

                                //value2 = string.Format("{0:MM/dd/yyyy}", value2);
                                //grdTaskList.Rows[e.RowIndex].Cells[7].Value = value2;

                                //value2 = string.Format("{0:MM/dd/yyyy}", dDate);
                                //grdTaskList.Rows[e.RowIndex].Cells[7].Value = value2;

                                //MessageBox.Show("Edit error");
                                grdTaskList.Rows[e.RowIndex].Cells[7].Tag = inputString;

                                //value2 = string.Format("{0:dd//yyyy}", dDate);
                                //grdTaskList.Rows[e.RowIndex].Cells[7].Value = value2;



                            }


                        }
                        else
                        {
                            //e.Value = e.CellStyle.NullValue;
                            //e.FormattingApplied = true;
                        }


                        }
                    }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }


        private void grdTaskList_CellEnter(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //CheckCelleditvalue = grdTaskList[e.ColumnIndex, e.RowIndex].Value.ToString();

            //if (e.ColumnIndex == 7)
            //{
            //    //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

            //    //CheckCelleditvalue = grdTaskList[e.ColumnIndex, e.RowIndex].Value.ToString();
            //    CheckCelleditvalue = string.Format("{0:MM/dd/yyyy}", grdTaskList[e.ColumnIndex, e.RowIndex].Value.ToString());
            //}
            //else
            //{
            //    CheckCelleditvalue = grdTaskList[e.ColumnIndex, e.RowIndex].Value.ToString();

            //}

            CheckCelleditvalue = grdTaskList[e.ColumnIndex, e.RowIndex].Value.ToString();

        }
        private void grvJobList_CellEnter(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            CheckCelleditvalue = grvJobList[e.ColumnIndex, e.RowIndex].Value.ToString();
        }
        private void grvJobList_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (grvJobList[e.ColumnIndex, e.RowIndex].Value.ToString() != CheckCelleditvalue)
            {
                if ((grvJobList.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Yellow) && (grvJobList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor == Color.Yellow))
                {
                }
                else
                {
                    grvJobList.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    grvJobList.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                    CheckCelleditvalue = string.Empty;
                }
            }
        }
        private void dtpTaskListDateSearchFrom_ValueChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                dtpTaskListDateSearchTo.ValueChanged -= this.dtpTaskListDateSearchTo_ValueChanged;

                dtpTaskListDateSearchTo.Text = dtpTaskListDateSearchFrom.Text;
                fillgrdTaskList();

                dtpTaskListDateSearchTo.ValueChanged += this.dtpTaskListDateSearchTo_ValueChanged;
            }
            catch (Exception ex)
            {
            }
        }
        private void dtpTaskListDateSearchTo_ValueChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (dtpTaskListDateSearchTo.Value < dtpTaskListDateSearchFrom.Value)
                {
                    dtpTaskListDateSearchTo.Text = dtpTaskListDateSearchFrom.Text;
                    fillgrdTaskList();
                }
                else
                {
                    fillgrdTaskList();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void cbxJobListPMrv_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            fillgrvJobsearch();
            fillgrdTaskList();
        }
        private void frmTasklist_Activated(System.Object sender, System.EventArgs e)
        {
            try
            {
                ApplyPageLoadSetting();
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Methods
        private void ApplyPageLoadSetting()
        {
            try
            {
                XmlDocument myDoc = new XmlDocument();
                try
                {
                    string dir2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    dir2 = dir2 + "\\JobTracker";
                    myDoc.Load(dir2 + "\\VESoftwareSetting.xml");


                    //myDoc.Load(Application.StartupPath + "\\VESoftwareSetting.xml");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("VESoftwareSetting.XML File not available in current folder", "Tasklist Pageload Setting Error");
                }

                //If (My.Settings.timeSheetLoginName = myDoc("VESoftwareSetting")("PageLoad")("TaskList")("SearchJob")("PM").InnerText) Then
                //   
                //End If
                txtJobListclient.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Client"].InnerText;
                txtJobNumber.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Job"].InnerText;

                cbxJobListPM.SelectedIndex = cbxJobListPM.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["PM"].InnerText.ToString());
                cbxJobListPMrv.SelectedIndex = cbxJobListPMrv.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["PMrv"].InnerText.ToString());

                txtTown.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Town"].InnerText;
                txtJobListAddress.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Address"].InnerText;
                txtJoblistClienttext.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["ClientText"].InnerText;
                txtJobListDescription.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchJob"]["Description"].InnerText;


                txtTaskListJobSearch.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Job"].InnerText;
                //'ComTaskListJobStatusSearch.SelectedText = cmbStatus.FindStringExact(myDoc("VESoftwareSetting")("PageLoad")("TaskList")("SearchTask")("Status").InnerText)
                ComTaskListJobStatusSearch.Text = (myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Status"].InnerText);

                if (Properties.Settings.Default.timeSheetLoginUserType.ToString() == "Admin")
                {
                    ComTaskListPMsearch.SelectedIndex = ComTaskListPMsearch.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["PM"].InnerText);
                    ComTaskListTMsearch.SelectedIndex = ComTaskListTMsearch.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["TM"].InnerText);


                }
                else
                {
                    if (Properties.Settings.Default.timeSheetLoginName == myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["PM"].InnerText)
                    {
                        ComTaskListPMsearch.SelectedIndex = ComTaskListPMsearch.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["PM"].InnerText);
                    }
                    else
                    {
                        ComTaskListPMsearch.SelectedIndex = -1;
                    }

                    if (Properties.Settings.Default.timeSheetLoginName == myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["TM"].InnerText)
                    {
                        ComTaskListTMsearch.SelectedIndex = ComTaskListTMsearch.FindStringExact(myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["TM"].InnerText);
                    }
                    else
                    {
                        ComTaskListTMsearch.SelectedIndex = -1;
                    }
                }

                txtTaskDescription.Text = myDoc["VESoftwareSetting"]["PageLoad"]["TaskList"]["SearchTask"]["Description"].InnerText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void checkValiduser()
        {
            try
            {
                UserName = Properties.Settings.Default.timeSheetLoginName;
                UserType = Properties.Settings.Default.timeSheetLoginUserType;

                if (UserType == "Admin")
                {
                    checkUser = true;
                }
                else
                {
                    DataTable Dt = null;
                    
                    
                    string query = "select Count(ID) from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + UserName + "' and cGroup = 'PM'";

                    //int count = StMethod.GetSingleInt(query);
                    int count;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        count = StMethod.GetSingleIntNew(query);
                    }
                    else
                    {
                        count = StMethod.GetSingleInt(query);
                    }

                    if (count > 0)
                    {
                        query = "select Count(ID) from MasterItem WHERE (IsDelete=0 or IsDelete is null) and  cTrack= '" + UserName + "' and cGroup = 'TM'";

                        //count = StMethod.GetSingleInt(query);

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            count = StMethod.GetSingleIntNew(query);
                        }
                        else
                        {
                            count = StMethod.GetSingleInt(query);
                        }

                        if (count > 0)
                        {
                            checkUser = true;
                        }
                        else
                        {
                            checkUser = false;
                            MessageBox.Show("You are not valid User for Add & Search any data in Task List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        checkUser = false;
                        MessageBox.Show("You are not valid User for Add & Search any data in Task List", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillgrvJobsearch()
        {
            try
            {
                // Dim queryString As String = " SELECT JobListID, JobNumber, Description, Handler, Address, Borough FROM  JobList WHERE(IsDelete = 0) OR(IsDelete IS NULL)ORDER BY JobListID"
                string queryString = "SELECT JobList.JobListID, JobList.JobNumber, Company.CompanyID, JobList.Description, JobList.Handler, JobList.PMrv, JobList.Clienttext, JobList.Address, JobList.Borough, Company.CompanyName,Company.CompanyNo FROM JobList LEFT OUTER JOIN Company ON JobList.CompanyID = Company.CompanyID WHERE ((JobList.IsDelete = 0) OR  (JobList.IsDelete IS NULL))";
                //ORDER BY JobList.JobListID
                if (!string.IsNullOrEmpty(this.txtJobListclient.Text))
                {
                    queryString = queryString + " and Company.CompanyName Like '%" + txtJobListclient.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.txtJobNumber.Text))
                {
                    queryString = queryString + " and JobList.JobNumber Like '%" + txtJobNumber.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.txtTown.Text))
                {
                    queryString = queryString + " and JobList.Borough Like '%" + txtTown.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.txtJobListAddress.Text))
                {
                    queryString = queryString + " and JobList.Address Like '%" + txtJobListAddress.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.txtJobListDescription.Text))
                {
                    queryString = queryString + " and  JobList.Description Like '%" + txtJobListDescription.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.txtJoblistClienttext.Text))
                {
                    queryString = queryString + " and  JobList.Clienttext Like '%" + txtJoblistClienttext.Text + "%'";
                }

                //If Me.cbxJobListDescription.Text <> "" Then queryString = queryString & " and  JobList.Description Like '%" & cbxJobListDescription.Text & "%'"

                if (!string.IsNullOrEmpty(this.cbxJobListPMrv.Text))
                {
                    queryString = queryString + " and  JobList.PMrv Like '%" + cbxJobListPMrv.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.cbxJobListPM.Text))
                {
                    queryString = queryString + " and  JobList.Handler Like '%" + cbxJobListPM.Text + "%'";
                }


                //DataTable dtJL = StMethod.GetListDT<dtoJobsearch>(queryString + "ORDER BY JobList.JobListID");
                DataTable dtJL;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dtJL = StMethod.GetListDTNew<dtoJobsearch>(queryString + "ORDER BY JobList.JobListID");
                }
                else
                {
                    dtJL = StMethod.GetListDT<dtoJobsearch>(queryString + "ORDER BY JobList.JobListID");
                }

                grvJobList.DataSource = dtJL;


                //    'Set Column Property
                //    ' With grvJobList
                grvJobList.Columns["JobListID"].Visible = false;
                grvJobList.Columns["CompanyID"].Visible = false;
                grvJobList.Columns["CompanyNo"].Visible = false;
                grvJobList.Columns["JobNumber"].HeaderText = "Job#";
                grvJobList.Columns["Borough"].HeaderText = "Town";
                grvJobList.Columns["CompanyName"].HeaderText = "Client#";
                grvJobList.Columns["Handler"].HeaderText = "PM";
                grvJobList.Columns["Clienttext"].HeaderText = "Client text";

                grvJobList.Columns["JobNumber"].DisplayIndex = 1;
                grvJobList.Columns["CompanyName"].DisplayIndex = 2;
                grvJobList.Columns["Address"].DisplayIndex = 3;
                grvJobList.Columns["Borough"].DisplayIndex = 4;
                grvJobList.Columns["Description"].DisplayIndex = 5;

                //.Columns["Status"].DisplayIndex = 8

                grvJobList.Columns["JobNumber"].Width = 60;
                grvJobList.Columns["Description"].Width = 375;
                grvJobList.Columns["CompanyName"].Width = 195;
                grvJobList.Columns["Address"].Width = 150;
                grvJobList.Columns["Handler"].Width = 70;
                grvJobList.Columns["Clienttext"].Width = 120;
                grvJobList.Columns["Address"].Width = 162;

                //If grvJobList.Rows.Count > 0 Then
                //    selectedJobListID = Convert.ToInt32(grvJobList.Rows[0].Cells["JobListID"].Value)
                //    'SetDirListBox(grvJobList.Rows[0].Cells["JobNumber"].Value.ToString())
                //    grvJobList.Rows[0).Selected = True
                //    'FillGridPreRequirment()
                //    'FillGridPermitRequiredInspection()
                //    'FillGridNotesCommunication()
                //End If
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillPMSearch()
        {
            try
            {
                DataTable dt = null;
                string query = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) union SELECT '' as cTrack,0 as ID ORDER BY cTrack ";


                cbxJobListPM.DisplayMember = "cTrack";
                cbxJobListPM.ValueMember = "Id";

                //dt = StMethod.GetListDT<colPMM>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew<colPMM>(query);

                }
                else
                {
                    dt = StMethod.GetListDT<colPMM>(query);
                }

                cbxJobListPM.DataSource = dt;

                DataTable dt3 = null;
                cbxJobListPMrv.DisplayMember = "cTrack";
                cbxJobListPMrv.ValueMember = "id";
                dt3 = StMethod.GetListDT<colPMM>(query);
                cbxJobListPMrv.DataSource = dt3;

                DataTable dt1 = null;
                ComTaskListPMsearch.DisplayMember = "cTrack";
                ComTaskListPMsearch.ValueMember = "Id";
                dt1 = StMethod.GetListDT<colPMM>(query);
                ComTaskListPMsearch.DataSource = dt1;

                DataTable dt2 = null;
                ComTaskListTMsearch.DisplayMember = "cTrack";
                ComTaskListTMsearch.ValueMember = "Id";
                dt2 = StMethod.GetListDT<colPMM>(query);
                ComTaskListTMsearch.DataSource = dt2;

                //For I As Integer = 0 To cmbobj.Filldatatable(query).Rows.Count - 1
                //    cbxJobListPM.Items.Add(cmbobj.Filldatatable(query).Rows[I).Item("cTrack").ToString)

                //    cbxJobListPM.Items.Add(dt.Rows[I).Item("cTrack").ToString)
                //Next
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillStatusSearch()
        {
            try
            {
                DataTable dt = null;
                string query = "SELECT cTrack,id FROM MasterItem WHERE cGroup='Status' union SELECT '' as cTrack,0 as ID ORDER BY id  ";
                cmbStatus.DisplayMember = "cTrack";
                cmbStatus.ValueMember = "cTrack";


                //dt = StMethod.GetListDT<colPMM>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew<colPMM>(query);

                }
                else
                {
                    dt = StMethod.GetListDT<colPMM>(query);
                }


                //For I As Integer = 0 To cmbobj.Filldatatable(query).Rows.Count - 1
                //    cmbStatus.Items.Add(cmbobj.Filldatatable(query).Rows[I).Item("cTrack").ToString)

                //    cmbStatus.Items.Add(dt.Rows[I).Item("cTrack").ToString)
                //Next
                cmbStatus.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillDescriptionSearch()
        {
            // Change By Shanker 10/8/2013 ----start--->
            //Dim cmbobj As New DataAccessLayer
            //Dim dt As DataTable
            //Dim query As String = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='Description' union SELECT '' as cTrack,0 as ID ORDER BY id  "
            //cbxJobListDescription.DisplayMember = "cTrack"
            //cbxJobListDescription.ValueMember = "Id"
            //dt = cmbobj.Filldatatable(query)
            //cbxJobListDescription.DataSource = dt

            //End------------->

            //For I As Integer = 0 To cmbobj.Filldatatable(query).Rows.Count - 1
            //    cbxJobListDescription.Items.Add(cmbobj.Filldatatable(query).Rows[I).Item("cTrack").ToString)

            //    cbxJobListDescription.Items.Add(dt.Rows[I).Item("cTrack").ToString)
            //Next

            //Dim dt1 As DataTable Change By Shanker 10/8/2013

            //comtaskdiscriptionSearch.DisplayMember = "cTrack"
            //comtaskdiscriptionSearch.ValueMember = "Id"
            //dt1 = cmbobj.Filldatatable(query)
            //comtaskdiscriptionSearch.DataSource = dt1
        }

        private void AddStatus_grdTadkList()
        {
            try
            {


                DataTable dt = null;
                string query = "SELECT cTrack FROM MasterItem WHERE cGroup='Status' ORDER BY cTrack ";
                
                //dt = StMethod.GetListDT<dtoTrackOnly>(query);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew<dtoTrackOnly>(query);

                }
                else
                {
                    dt = StMethod.GetListDT<dtoTrackOnly>(query);
                }

                DataGridViewComboBoxColumn grdTaskListSTATUS = new DataGridViewComboBoxColumn();
                grdTaskListSTATUS.Name = "AddStatusCmbx";
                grdTaskListSTATUS.DataPropertyName = "Status";
                grdTaskListSTATUS.DataSource = dt;
                grdTaskListSTATUS.DisplayMember = "cTrack";
                grdTaskListSTATUS.HeaderText = "Status";
                grdTaskListSTATUS.FlatStyle = FlatStyle.Standard;
                grdTaskList.Columns.Add(grdTaskListSTATUS);


                DataTable dt1 = null;
                
                string query1 = "SELECT  Id, cTrack FROM MasterItem WHERE cGroup='Status' union SELECT 0 as Id,'' as cTrack ORDER BY cTrack";

                ComTaskListJobStatusSearch.DisplayMember = "cTrack";
                ComTaskListJobStatusSearch.ValueMember = "Id";
                
                
                //dt1 = StMethod.GetListDT<colPMM>(query1);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt1 = StMethod.GetListDTNew<colPMM>(query1);
                }
                else
                {
                    dt1 = StMethod.GetListDT<colPMM>(query1);
                }

                ComTaskListJobStatusSearch.DataSource = dt1;




            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void AddPM_grdTaskList()
        {
            try
            {
                DataTable dt = null;
                string query = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) union SELECT '' as cTrack,0 as ID ORDER BY cTrack ";
                
                
                //dt = StMethod.GetListDT<colPMM>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew<colPMM>(query);

                }
                else
                {
                    dt = StMethod.GetListDT<colPMM>(query);
                }

                DataGridViewComboBoxColumn grdTaskListPM = new DataGridViewComboBoxColumn();
                grdTaskListPM.Name = "AddPMCmbx";
                grdTaskListPM.DataPropertyName = "PM";
                grdTaskListPM.DataSource = dt;
                grdTaskListPM.DisplayMember = "cTrack";
                grdTaskListPM.HeaderText = "Assigned by";
                grdTaskListPM.DisplayIndex = 4;
                grdTaskListPM.FlatStyle = FlatStyle.Standard;
                grdTaskList.Columns.Add(grdTaskListPM);
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void AddTM_grdTaskList()
        {
            try
            {
                DataTable dt = null;
                string query = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) union SELECT '' as cTrack,0 as ID ORDER BY cTrack ";
                //dt = StMethod.GetListDT<colPMM>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew<colPMM>(query);

                }
                else
                {
                    dt = StMethod.GetListDT<colPMM>(query);
                }

                DataGridViewComboBoxColumn grdTasklistTM = new DataGridViewComboBoxColumn();
                grdTasklistTM.Name = "AddTMCmbx";
                grdTasklistTM.DataPropertyName = "TM";
                grdTasklistTM.DataSource = dt;
                grdTasklistTM.DisplayMember = "cTrack";
                grdTasklistTM.HeaderText = "TM";
                grdTasklistTM.DisplayIndex = 5;
                grdTasklistTM.FlatStyle = FlatStyle.Standard;
                grdTaskList.Columns.Add(grdTasklistTM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void fillgrdTaskList()
        {
            try
            {


                //string queryString = "SELECT TaskLisiId, JobNumber, PM, TM, Description, Date, CompletedByDate, Status FROM TaskList WHERE TaskLisiId<>0";

                //string queryString = "SELECT TaskLisiId, JobNumber, PM, TM, Description, CAST(TaskList.Date as date) as Date," +
                //    "CONVERT(date, TaskList.CompletedByDate) as CompletedByDateNew, Status FROM TaskList WHERE TaskLisiId<>0";



                string queryString = "SELECT tk.TaskLisiId, tk.JobNumber, tk.PM, tk.TM, tk.Description, CONVERT(Date, tk.Date) as Date," +
                    "CONVERT(Date, tk.CompletedByDate) as CompletedByDate, tk.Status FROM TaskList tk WHERE tk.TaskLisiId<>0";

                queryString = "SELECT tk.TaskLisiId, tk.JobNumber, tk.PM, tk.TM, tk.Description, tk.Date as Date," +
                    "tk.CompletedByDate as CompletedByDate, tk.Status FROM TaskList tk WHERE tk.TaskLisiId<>0";


                //"CONVERT(date, tk.CompletedByDate) as CompletedByDateNew, Status FROM TaskList tk WHERE TaskLisiId<>0";


                DataTable dt = null;

                if (!string.IsNullOrEmpty(this.txtTaskListJobSearch.Text))
                {
                    queryString = queryString + " AND JobNumber Like '%" + txtTaskListJobSearch.Text + "%'";
                }

                if (!string.IsNullOrEmpty(this.txtTaskDescription.Text))
                {
                    queryString = queryString + " AND Description Like '%" + txtTaskDescription.Text + "%'";
                }

                //If Me.comtaskdiscriptionSearch.Text <> "" Then queryString = queryString & " AND Description Like '%" & comtaskdiscriptionSearch.Text & "%'"

                if (checkUser == true)
                {

                    if (!string.IsNullOrEmpty(this.ComTaskListPMsearch.Text))
                    {
                        queryString = queryString + " AND PM Like '%" + ComTaskListPMsearch.Text + "%'";
                    }

                    if (!string.IsNullOrEmpty(this.ComTaskListTMsearch.Text))
                    {
                        queryString = queryString + " AND TM Like '%" + ComTaskListTMsearch.Text + "%'";
                    }
                }
                if (!string.IsNullOrEmpty(this.ComTaskListJobStatusSearch.Text))
                {
                    queryString = queryString + " AND Status Like '" + ComTaskListJobStatusSearch.Text + "%'";
                }

                //If Me.ChktaskListDateSearch.Checked = True Then queryString = queryString & " AND CompletedByDate = '" & dtpTaskListDateSearchTo.Value.ToShortDateString() & "'"

                if (this.ChktaskListDateSearch.Checked == true)
                {

                    // commeted 1 following line and edited it by devendra
                    // queryString = queryString + " AND Date between '" + dtpTaskListDateSearchFrom.Value.ToShortDateString() + "' and '" + dtpTaskListDateSearchTo.Value.ToShortDateString() + "'";



                    //string Date1 = dtpTaskListDateSearchFrom.Value.Month + "-" + dtpTaskListDateSearchFrom.Value.Day + "-" + dtpTaskListDateSearchFrom.Value.Year + " " + dtpTaskListDateSearchFrom.Value.ToShortTimeString();
                    //string Date2 = dtpTaskListDateSearchTo.Value.Month + "-" + dtpTaskListDateSearchTo.Value.Day + "-" + dtpTaskListDateSearchTo.Value.Year + " " + dtpTaskListDateSearchTo.Value.ToShortTimeString();

                    string Date1 = dtpTaskListDateSearchFrom.Value.Month + "-" + dtpTaskListDateSearchFrom.Value.Day + "-" + dtpTaskListDateSearchFrom.Value.Year;
                    string Date2 = dtpTaskListDateSearchTo.Value.Month + "-" + dtpTaskListDateSearchTo.Value.Day + "-" + dtpTaskListDateSearchTo.Value.Year;



                    //queryString = queryString + " AND Date between CAST('" + Date1 + "' AS datetime) and CAST('" + Date2 + " AS DATETIME)'";

                   queryString = queryString + " AND Date between CAST('" + Date1 + "' AS date) and CAST('" + Date2 + "' AS date)";


                }

                //If chkTaskListSearch.Checked = True Then
                //    If Format(dtpDateSearchTo.Value, "yyyy/MM/dd") >= Format(dtpDateSearchFrom.Value, "yyyy/MM/dd") Then
                //        queryString = queryString & " AND Date BETWEEN '" & Format(dtpDateSearchFrom.Value, "yyyy/MM/dd") & "' AND '" & Format(dtpDateSearchTo.Value, "yyyy/MM/dd") & "'"
                //    End If
                //End If





                //dt = StMethod.GetListDT<TaskListData>(queryString);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetListDTNew<TaskListData>(queryString);

                }
                else
                {
                    dt = StMethod.GetListDT<TaskListData>(queryString);
                }


                grdTaskList.DataSource = dt;

                //dataGridView1.Columns[2].DefaultCellStyle.Format = "yyyy/MM/dd";


                grdTaskList.Columns["Date"].DefaultCellStyle.Format = "MM-dd-yyyy";


                grdTaskList.Columns["TaskLisiId"].Visible = false;
                grdTaskList.Columns["JobNumber"].HeaderText = "Job#";
                grdTaskList.Columns["Date"].HeaderText = "Entry Date";
                grdTaskList.Columns["Description"].Width = 542;
                grdTaskList.Columns["CompletedByDate"].Width = 110;
                
                grdTaskList.Columns["AddPMCmbx"].Visible = true;
                grdTaskList.Columns["AddTMCmbx"].Visible = true;

                grdTaskList.Columns["JobNumber"].DisplayIndex = 2;

                //grdTaskList.Columns["JobNumber"].DefaultCellStyle.Format=""
                

            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show(ex.Message.ToString());

            }
        }

        //Private Sub AddStatus_grdTadkList()

        //private void AddStatus_grdTadkList()
        //{


        //}


        private void UserPmTmSearch()
        {
            try
            {
                UserName = Properties.Settings.Default.timeSheetLoginName;

                if (ComTaskListPMsearch.Text == UserName && ComTaskListTMsearch.Text == UserName)
                {
                    grdTaskList.Enabled = true;
                    fillgrdTaskList();
                }
                else if (ComTaskListPMsearch.Text == UserName || ComTaskListTMsearch.Text == UserName)
                {
                    grdTaskList.Enabled = true;
                    fillgrdTaskList();
                }
                else
                {
                    if (checkUser == true)
                    {
                        grdTaskList.Enabled = true;
                        ComTaskListPMsearch.Text = UserName.ToString();
                        ComTaskListTMsearch.Text = UserName.ToString();
                        MessageBox.Show("User may only search for task where they are either Assigner or TM", "Error Handling", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        grdTaskList.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        private void grvJobList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtJoblistClienttext_TextAlignChanged(object sender, EventArgs e)
        {

        }

        private void grdTaskList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 7)
                {
                    //e.Value = "MM-dd-yyyy";

                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))


                    
                    //if (DateTime.TryParse(e.Value.ToString(), out dDate2))
                    //{
                    //    //String.Format("{0:d/MM/yyyy}", dDate);

                    //    //e.Value = String.Format("{0:MM/d/yyyy}", e.Value);
                    //    e.Value = String.Format("{MM/d/yyyy}", e.Value);

                    //    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //}
                    //else
                    //{
                    //    //Console.WriteLine("Invalid"); // <-- Control flow goes here
                    //    MessageBox.Show(" ");
                    //}


                    //string inputString = "2000-02-02";
                    string inputString;
                    DateTime dDate;
                    
                    //string x = dDate.ToString("yyyy-MM-dd");

                    inputString = e.Value.ToString();

                    //inputString = string.Format("{0:MM/dd/yyyy}", e.Value);


                    //inputString = string.Format("{0:MM/d/yyyy}", e.Value);
                    //inputString = value2.ToString() + " 12:00:00 AM";

                    //inputString = e.Value.ToString() + " 12:00:00 AM";

                    if (DateTime.TryParse(inputString, out dDate))
                    {
                        //String.Format("{0:d/MM/yyyy}", dDate);

                        e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                        e.FormattingApplied = true;


                        //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                    }
                    else
                    {

                        string s = "";
                        //e.Value = e.CellStyle.NullValue;
                        //e.Value = string.Format("{0:dd/MM/yyyy}", dDate);
                        //e.FormattingApplied = true;

                        //MessageBox.Show("try parse failed");                        
                        //e.Value = e.Value;
                        //e.FormattingApplied = true;


                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                        //e.FormattingApplied = true;
                    }







                    //if (DateTime.TryParseExact(e.Value.ToString(), formats, CultureInfo.InvariantCulture,
                    //                          DateTimeStyles.None, out dt))
                    //{
                    //    // Successfully parse

                    //    e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    //e.Value= String.Format("{MM/d/yyyy}", e.Value);
                    //    e.FormattingApplied = true;

                    //}


                    //if ((value != null))
                    //if ((value != null) && (value != string.Empty))
                    //{


                    //    //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    //e.FormattingApplied = true;

                    //    ////e.Value= String.Format("{MM/d/yyyy}", e.Value);
                    //    //e.FormattingApplied = true;


                    //    //DateTime date = Convert.ToDateTime(e.Value, new CultureInfo("en-US"));
                    //    //e.Value = date.ToString("MM/dd/yyyy");
                    //    //e.FormattingApplied = true;
                    //    //grdTaskList.Rows[e.RowIndex].Cells[7].Value = date.ToString("MM/dd/yyyy");


                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}



                }



                if (e.ColumnIndex == 8)
                {
                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

                    //if ((value != null) && (value!= string.Empty))
                    //{
                    //    e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                    //    e.FormattingApplied = true;

                    //}
                    //else
                    //{
                    //    e.Value = e.CellStyle.NullValue;
                    //    e.FormattingApplied = true;
                    //}
                    
                    string inputString = "2000-02-02";
                    DateTime dDate;
                    inputString = e.Value.ToString();
                    inputString = e.Value.ToString();

                    if (DateTime.TryParse(inputString, out dDate))
                    {
                        String.Format("{0:d/MM/yyyy}", dDate);

                        //e.Value = string.Format("{0:d/MM/yyyy}", dDate);
                        e.Value = string.Format("{0:MM-dd-yyyy}", dDate);
                        //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                    }
                    else
                    {
                        //Console.WriteLine("Invalid"); // <-- Control flow goes here
                        e.Value = e.CellStyle.NullValue;
                        e.FormattingApplied = true;
                    }



                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void grdTaskList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}