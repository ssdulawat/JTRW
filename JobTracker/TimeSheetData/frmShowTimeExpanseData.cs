using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.TimeSheetData
{
    public partial class frmShowTimeExpanseData : Form
    {
        #region Declaration
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
        private string _UserSearch;
        public string UserSearch
        {
            get
            {
                return _UserSearch;
            }
            set
            {
                _UserSearch = value;
            }
        }
        private string _Status;
        public string Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        private string _AdminStatus;
        public string AdminStatus
        {
            get
            {
                return _AdminStatus;
            }
            set
            {
                _AdminStatus = value;
            }
        }
        private string _BillStatus;
        public string BillStatus
        {
            get
            {
                return _BillStatus;
            }
            set
            {
                _BillStatus = value;
            }
        }
        private bool _ckbTime;
        public bool ckbTime
        {
            get
            {
                return _ckbTime;
            }
            set
            {
                _ckbTime = value;
            }
        }
        private DateTime _dtpDateSearchTo;
        public DateTime dtpDateSearchTo
        {
            get
            {
                return _dtpDateSearchTo;
            }
            set
            {
                _dtpDateSearchTo = value;
            }
        }
        private DateTime _dtpSearchFrom;
        public DateTime dtpSearchFrom
        {
            get
            {
                return _dtpSearchFrom;
            }
            set
            {
                _dtpSearchFrom = value;
            }
        }


        public System.Drawing.Color VeCostColor { get; set; }

        public bool IsVisible { get; set; }

        #endregion
        public frmShowTimeExpanseData()
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

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            btnAdd.Visible = false;
            btnAdd.Text = "Add";
            fillgrdTimeSheetData();
        }

        #endregion

        #region Methods
        public void fillgrdTimeSheetData()
        {
            try
            {
                string queryString = null;
                if (Properties.Settings.Default.timeSheetLoginUserType == "Admin")
                {
                    queryString = "SELECT  Distinct TS_Time.Name, cast(ROUND(sum(TS_Time.Time),2,1)  as decimal(10,2)) as Time FROM TS_Time Where JobListID<>0  ";

                }
                else
                {
                    string LoginUser = Properties.Settings.Default.timeSheetLoginName;
                    queryString = "SELECT Distinct TS_Time.Name, cast(ROUND(sum(TS_Time.Time),2,1)  as decimal(10,2)) as Time FROM TS_Time Where Name='" + LoginUser + "'";
                }
                if (JobNumber != "")
                {
                    queryString = queryString + " and (SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID)  Like'" + JobNumber + "%'";
                }
                if (UserSearch != "")
                {
                    queryString = queryString + " and TS_Time.Name Like'" + UserSearch + "%'";
                }
                if (Status != "")
                {
                    queryString = queryString + " and TS_Time.status Like '%" + Status + "%'";
                }
                if (AdminStatus != "")
                {
                    queryString = queryString + " and TS_Time.AdminStatus Like '%" + AdminStatus + "%'";
                }
                else
                {
                }
                if (BillStatus != "")
                {
                    queryString = queryString + " and TS_Time.BillState Like'" + BillStatus + "'";
                }
                if (ckbTime == true)
                {
                    if (string.CompareOrdinal(dtpDateSearchTo.ToString("yyyy/MM/dd"), dtpSearchFrom.ToString("yyyy/MM/dd")) >= 0)
                    {
                        queryString = queryString + " AND Date BETWEEN '" + dtpSearchFrom.ToString("yyyy/MM/dd") + "' AND '" + dtpDateSearchTo.ToString("yyyy/MM/dd") + "'";
                    }
                    else
                    {
                        //KryptonMessageBox.Show("Added To date must greater then or equal Added From date", "Jobtracking")
                    }
                }
                queryString = queryString + "group by TS_Time.Name";

                //DataTable dtTimeSheet = StMethod.GetListDT<TS_LoginName>(queryString);
                DataTable dtTimeSheet;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dtTimeSheet = StMethod.GetListDTNew<TS_LoginName>(queryString);

                }
                else
                {
                    dtTimeSheet = StMethod.GetListDT<TS_LoginName>(queryString);
                }

                grdShowTimeData.DataSource = dtTimeSheet;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
