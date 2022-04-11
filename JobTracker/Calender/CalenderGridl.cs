using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;

namespace JobTracker.Calender
{
    public partial class CalenderGridl : UserControl
    {
        #region gloable Variable
        private string setDate;
        private int setSelectedValue = 0;
        private bool SubmittedStatus;
        private bool ExpiresStatus;
        private bool ObtainedStatus;
        private string Query;
        private string chString;
        public event EventHandler MyEventName;
        #endregion
        #region Properties
        public string DefaultDate
        {
            set
            {
                setDate = value;
                fillgrid(setDate);
            }
        }
        public int SelectedValue
        {
            get
            {
                if (setSelectedValue > 0)
                {
                    return setSelectedValue;
                }
                else
                {
                    return 0;
                }
            }

        }
        public bool Submitted
        {
            set
            {
                SubmittedStatus = value;
            }
        }
        public bool Obtained
        {
            set
            {
                ObtainedStatus = value;
            }
        }
        public bool Expires
        {
            set
            {
                ExpiresStatus = value;
            }
        }
        public string QueryStr
        {
            set
            {
                Query = string.Empty;
                Query = value;
            }
        }
        #endregion
        public CalenderGridl()
        {
            InitializeComponent();
        }
        protected void fillgrid(string controlDate)
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                string str = string.Empty;
                chString = Program.ChBoxSearchString;
                Query = Program.QueryStr;
                if (!string.IsNullOrEmpty(chString))
                {
                    if (chString == "S")
                    {
                        str = str + " and  (JobTracking.Submitted='" + controlDate + "' and JobTracking.Submitted<>'1/1/1900')";
                    }
                    if (chString == "O")
                    {
                        str = str + " and  (JobTracking.Obtained='" + controlDate + "' and JobTracking.Obtained<>'1/1/1900')";
                    }
                    if (chString == "E")
                    {
                        str = str + " and  (JobTracking.Expires='" + controlDate + "' and JobTracking.Expires<>'12/30/9999')";
                    }
                    if (chString == "ES")
                    {
                        str = str + " and  (JobTracking.Submitted='" + controlDate + "' and jobTracking.Submitted<>'1/1/1900') or (JobTracking.Expires='" + controlDate + "' and JobTracking.Expires<>'12/30/9999')";
                    }
                    if (chString == "EO")
                    {
                        str = str + " and  (JobTracking.Expires='" + controlDate + "' and JobTracking.Expires<>'12/30/9999') or (JobTracking.Obtained='" + controlDate + "' and JobTracking.Obtained<>'1/1/1900')";
                    }
                    if (chString == "OS")
                    {
                        str = str + " and  (JobTracking.Submitted='" + controlDate + "' and JobTracking.Submitted<>'1/1/1900') or (JobTracking.Obtained='" + controlDate + "' and JobTracking.Obtained<>'1/1/1900')";
                    }
                    if (chString == "EOS")
                    {
                        str = str + " and  (JobTracking.Submitted='" + controlDate + "' and jobTracking.Submitted<>'1/1/1900') or (JobTracking.Obtained='" + controlDate + "' and JobTracking.Obtained<>'1/1/1900') or (JobTracking.Expires='" + controlDate + "' and JobTracking.Expires<>'12/30/9999')";
                    }
                    Query = str + Query;
                }
                else
                {
                    //COMMENTED DUE TO IT'S LOGICAL ERROR
                    Query = Query + " and JobTracking.JobTrackingID=0";
                }
                // Query = Query & " and ( JobTracking.Submitted='" & controlDate & "' or JobTracking.Obtained='" & controlDate & "' or JobTracking.Expires='" & controlDate & "')"

                string queryString = "SELECT JobTracking.JobTrackingID, JobTracking.JobListID, JobList.JobNumber, JobTracking.Track FROM  JobList left outer JOIN    Company ON JobList.CompanyID = Company.CompanyID inner JOIN                JobTracking ON JobList.JobListID = JobTracking.JobListID where (JobTracking.IsDelete=0 or JobTracking.IsDelete is null) and JobList.JobNumber <> '' " + Query + " Order by JobTracking.JobListID";
                
                
                //grvJobList.DataSource = StMethod.GetListDT<JobTrackList>(queryString);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    grvJobList.DataSource = StMethod.GetListDTNew<JobTrackList>(queryString);
                }
                else
                {
                    grvJobList.DataSource = StMethod.GetListDT<JobTrackList>(queryString);
                }

                grvJobList.Columns["JobListID"].Visible = false;
                grvJobList.Columns["JobTrackingID"].Visible = false;
                grvJobList.Columns["JobNumber"].HeaderText = "Job#";
                grvJobList.Columns["JobNumber"].Width = 60;
                grvJobList.Columns["Track"].HeaderText = "Track";
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        #region Events
        private void grvJobList_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                setSelectedValue = Convert.ToInt32(grvJobList.Rows[e.RowIndex].Cells["JobTrackingID"].Value);
                frmCalender frm = new frmCalender();
                frm.SetlblJobTrackingID = grvJobList.Rows[e.RowIndex].Cells["JobTrackingID"].Value.ToString();
                frm.SetlblJobListID = grvJobList.Rows[e.RowIndex].Cells["JobListID"].Value.ToString();
                //RaiseEvent MyEventName(sender, e)
            }
            catch (Exception ex)
            {

            }
        }

        private void grvJobList_MouseClick(System.Object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                frmCalender frm = new frmCalender();
                string QueryForIn = string.Empty;
                int cnt = 0;
                if (grvJobList.Rows.Count > 0)
                {
                    for (cnt = 0; cnt < grvJobList.Rows.Count; cnt++)
                    {
                        if (cnt == 0)
                        {
                            QueryForIn = "'" + grvJobList.Rows[cnt].Cells["JobTrackingID"].Value.ToString() + "'";
                        }
                        else
                        {
                            QueryForIn = QueryForIn + ",'" + grvJobList.Rows[cnt].Cells["JobTrackingID"].Value.ToString() + "'";
                        }
                    }
                }
                frm.SetJobTrackingIDs = QueryForIn;
                frm.EnableBtns();
                if (MyEventName != null)
                    MyEventName(sender, e);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion
    }
}
