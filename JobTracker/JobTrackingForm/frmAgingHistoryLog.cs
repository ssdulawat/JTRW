using DataAccessLayer;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.JobTrackingForm
{
    public partial class frmAgingHistoryLog : Form
    {
        ManagerRepository repo = new ManagerRepository();
        public string str1;
        ManagerRepository repo2 = new ManagerRepository("");

        public frmAgingHistoryLog()
        {
            InitializeComponent();
        }

        private int CompanyId;
        private void frmAgingHistoryLog_Load(System.Object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            BindHistoryLog();
            Cursor.Current = Cursors.Default;

        }

        private void BindHistoryLog()
        {
            try
            {
                //var history = repo.db.Database.SqlQuery<AgingHistory>("SELECT C.CompanyID,C.CompanyName,C.Aging,CH.AgingUpdateDate as UDate,CH.Userid, CASE WHEN CH.Userid = 0 THEN 'Admin' ELSE LO.cUserid END AS UserN FROM Company AS C  INNER JOIN ColorHistory AS CH ON C.CompanyID=CH.CompanyID LEFT JOIN Login AS LO ON CH.Userid=LO.nid").ToList();

                //DT.Columns.Add("Color")


                var history = repo.db.Database.SqlQuery<AgingHistory>("SELECT C.CompanyID,C.CompanyName,C.Aging,CH.AgingUpdateDate as UDate,CH.Userid, CASE WHEN CH.Userid = 0 THEN 'Admin' ELSE LO.cUserid END AS UserN FROM Company AS C  INNER JOIN ColorHistory AS CH ON C.CompanyID=CH.CompanyID LEFT JOIN Login AS LO ON CH.Userid=LO.nid").ToList();
                history = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    history = repo2.db2.Database.SqlQuery<AgingHistory>("SELECT C.CompanyID,C.CompanyName,C.Aging,CH.AgingUpdateDate as UDate,CH.Userid, CASE WHEN CH.Userid = 0 THEN 'Admin' ELSE LO.cUserid END AS UserN FROM Company AS C  INNER JOIN ColorHistory AS CH ON C.CompanyID=CH.CompanyID LEFT JOIN Login AS LO ON CH.Userid=LO.nid").ToList();
                }
                else
                {
                    history = repo.db.Database.SqlQuery<AgingHistory>("SELECT C.CompanyID,C.CompanyName,C.Aging,CH.AgingUpdateDate as UDate,CH.Userid, CASE WHEN CH.Userid = 0 THEN 'Admin' ELSE LO.cUserid END AS UserN FROM Company AS C  INNER JOIN ColorHistory AS CH ON C.CompanyID=CH.CompanyID LEFT JOIN Login AS LO ON CH.Userid=LO.nid").ToList();
                }

                grvAgingLogHistory.DataSource = history;


                grvAgingLogHistory.AutoGenerateColumns = false;

                grvAgingLogHistory.Columns["CompanyID"].HeaderText = "Company ID";
                grvAgingLogHistory.Columns["CompanyID"].Visible = false;
                grvAgingLogHistory.Columns["CompanyID"].DisplayIndex = 0;

                grvAgingLogHistory.Columns["CompanyName"].Visible = true;
                grvAgingLogHistory.Columns["CompanyName"].HeaderText = "Company Name";
                grvAgingLogHistory.Columns["CompanyName"].DisplayIndex = 1;
                grvAgingLogHistory.Columns["CompanyName"].Width = 100;

                grvAgingLogHistory.Columns["Aging"].Visible = true;
                grvAgingLogHistory.Columns["Aging"].HeaderText = "Aging";
                grvAgingLogHistory.Columns["Aging"].DisplayIndex = 2;

                grvAgingLogHistory.Columns["UDate"].Visible = true;
                grvAgingLogHistory.Columns["UDate"].HeaderText = "Update Date";
                grvAgingLogHistory.Columns["UDate"].DisplayIndex = 3;
                grvAgingLogHistory.Columns["UDate"].Width = 100;

                grvAgingLogHistory.Columns["UserN"].Visible = true;
                grvAgingLogHistory.Columns["UserN"].HeaderText = "User Name";
                grvAgingLogHistory.Columns["UserN"].DisplayIndex = 4;

                grvAgingLogHistory.Columns["Userid"].Visible = false;
            }
            catch (Exception)
            {
            }
        }        
    }
}
