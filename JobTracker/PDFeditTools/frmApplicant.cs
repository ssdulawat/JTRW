using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
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

namespace JobTracker.PDFeditTools
{
    public partial class frmApplicant : Form
    {
        #region Global variable
        //private DataAccessLayer DAL;
        private string Applicant_ID;
        private string ApplicantOld_ID;
        private static frmApplicant _Instance;
        #endregion

        #region Constant variable
        private const string ApplicantID = "ApplicantID";
        private const string ApplicantFirstName = "ApplicantFirstName";
        private const string ApplicantLastName = "ApplicantLastName";
        private const string ApplicantMidName = "ApplicantMidName";
        private const string ApplicantBusinessName = "ApplicantBusinessName";
        private const string ApplicantBusinessAddress = "ApplicantBusinessAddress";
        private const string ApplicantBusinessCity = "ApplicantBusinessCity";
        private const string ApplicantBusinessState = "ApplicantBusinessState";
        private const string ApplicantBusinessZip = "ApplicantBusinessZip";
        private const string ApplicantTitle = "ApplicantTitle";
        private const string ApplicantLicense = "ApplicantLicense";
        private const string ApplicantPhone = "ApplicantPhone";
        private const string Applicantfax = "Applicantfax";
        private const string IsChange = "IsChange";
        private const string IsNewRecord = "IsNewRecord";
        private const string IsDelete = "IsDelete";
        private const string ChangeDate = "ChangeDate";
        #endregion

        #region Properties
        public static frmApplicant Instance
        {
            get
            {
                if (_Instance == null || _Instance.IsDisposed)
                {
                    _Instance = new frmApplicant();
                }
                return _Instance;
            }
        }
        public string ApplicantOldID
        {
            get
            {
                return ApplicantOld_ID;
            }
            set
            {
                ApplicantOld_ID = value;
            }
        }
        public string SelectApplicationID
        {
            get
            {
                return Applicant_ID;
            }
            set
            {
                Applicant_ID = value;
            }
        }
        #endregion

        public frmApplicant()
        {
            InitializeComponent();
        }

        #region Events
        private void btnAdd_Click(System.Object sender, System.EventArgs e)
        {
            if (btnAdd.Text == "Insert")
            {
                btnAdd.Text = "Save";
                AddRow();
            }
            else
            {
                InsertNewApplicantInfo();
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            FillGrid();
            btnAdd.Text = "Insert";
        }

        private void grdApplicantInfo_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 0)
            {
                if (btnAdd.Text != "Save")
                {
                    UpdateApplicantInfo();
                }
                else
                {
                    KryptonMessageBox.Show("First Save and then update!");
                }
            }
        }

        private void grdApplicantInfo_RowHeaderMouseDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            SelectApplicationID = grdApplicantInfo.Rows[e.RowIndex].Cells[ApplicantID].Value.ToString();
            this.Hide();
        }

        private void frmApplicant_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = true;
            //SelectApplicationID = ""
            this.Hide();
        }

        private void frmApplicant_Load(System.Object sender, System.EventArgs e)
        {
            FillGrid();
            ApplicantIDFromInfo();
        }

        #endregion

        #region Function
        private void FillGrid()
        {
            try
            {
                string Query = "SELECT ApplicantID, ApplicantFirstName, ApplicantLastName, ApplicantMidName, ApplicantBusinessName, ApplicantBusinessAddress, ApplicantBusinessCity, ApplicantBusinessState, ApplicantBusinessZip, ApplicantTitle, ApplicantLicense, ApplicantPhone, Applicantfax FROM         VBNetApplicantInfo WHERE ApplicantID<>0";

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var list = db.Database.SqlQuery<ApplicantInfo>(Query).ToList();
                //    grdApplicantInfo.DataSource = list;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db.Database.SqlQuery<ApplicantInfo>(Query).ToList();
                        grdApplicantInfo.DataSource = list;
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<ApplicantInfo>(Query).ToList();
                        grdApplicantInfo.DataSource = list;
                    }

                }

                grdApplicantInfo.Columns[ApplicantID].Visible = false;
                grdApplicantInfo.Columns[ApplicantBusinessName].HeaderText = "Business Name";
                grdApplicantInfo.Columns[ApplicantBusinessAddress].HeaderText = "Address";
                grdApplicantInfo.Columns[ApplicantFirstName].HeaderText = "First Name";
                grdApplicantInfo.Columns[ApplicantLastName].HeaderText = "Last Name";
                grdApplicantInfo.Columns[ApplicantMidName].HeaderText = "Middle Name";
                grdApplicantInfo.Columns[ApplicantBusinessCity].HeaderText = "Applicant Business City";
                grdApplicantInfo.Columns[ApplicantBusinessState].HeaderText = "Applicant Business State";
                grdApplicantInfo.Columns[ApplicantBusinessZip].HeaderText = "Applicant Business Zip";
                grdApplicantInfo.Columns[ApplicantTitle].HeaderText = "Title";
                grdApplicantInfo.Columns[ApplicantLicense].HeaderText = "Applicant License";
                grdApplicantInfo.Columns[ApplicantPhone].HeaderText = "Applicant Business Phone";
                grdApplicantInfo.Columns[Applicantfax].HeaderText = "Applicant Business Fax";
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void AddRow()
        {
            try
            {
                DataTable Addrow = new DataTable();
                Addrow = Program.ToDataTable<ApplicantInfo>((List<ApplicantInfo>)grdApplicantInfo.DataSource);
                DataRow NewR = Addrow.NewRow();
                Addrow.Rows.Add(NewR);
                grdApplicantInfo.DataSource = Addrow;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        public void ApplicantIDFromInfo()
        {
            FillGrid();
            foreach (DataGridViewRow grdrow in grdApplicantInfo.Rows)
            {
                if (grdrow.Cells[ApplicantID].Value.ToString().Trim() == ApplicantOldID)
                {
                    grdrow.Selected = true;
                    grdApplicantInfo.CurrentCell = grdrow.Cells[ApplicantFirstName];
                    grdrow.DefaultCellStyle.SelectionBackColor = Color.Tomato;
                    grdrow.DefaultCellStyle.BackColor = Color.Tomato;
                }
            }
        }
        private void InsertNewApplicantInfo()
        {
            try
            {
                string Query = "INSERT INTO VBNetApplicantInfo(ApplicantFirstName, ApplicantLastName, ApplicantMidName, ApplicantBusinessName, ApplicantBusinessAddress, ApplicantBusinessCity, ApplicantBusinessState, ApplicantBusinessZip, ApplicantTitle, ApplicantLicense, ApplicantPhone, Applicantfax ) VALUES (@ApplicantFirstName, @ApplicantLastName, @ApplicantMidName, @ApplicantBusinessName, @ApplicantBusinessAddress, @ApplicantBusinessCity, @ApplicantBusinessState, @ApplicantBusinessZip, @ApplicantTitle, @ApplicantLicense, @ApplicantPhone, @Applicantfax)";
                SqlCommand CMD = new SqlCommand(Query);
                List<SqlParameter> Param = new List<SqlParameter>();
                // Param.Add(new SqlParameter("@ApplicantID", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantID].Value.ToString()))
                Param.Add(new SqlParameter("@ApplicantFirstName", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantFirstName].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantLastName", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantLastName].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantMidName", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantMidName].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessName", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantBusinessName].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessAddress", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantBusinessAddress].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessCity", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantBusinessCity].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessState", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantBusinessState].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessZip", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantBusinessZip].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantTitle", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantTitle].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantLicense", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantLicense].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantPhone", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[ApplicantPhone].Value.ToString()));
                Param.Add(new SqlParameter("@Applicantfax", grdApplicantInfo.Rows[grdApplicantInfo.Rows.Count - 1].Cells[Applicantfax].Value.ToString()));
                
                
                
                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                //    {
                //        KryptonMessageBox.Show("Record Added Successfully");
                //        StMethod.LoginActivityInfo(db, "Insert", this.Text);
                //        btnAdd.Text = "Insert";
                //        FillGrid();
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Added Successfully");
                            StMethod.LoginActivityInfoNew(db, "Insert", this.Text);
                            btnAdd.Text = "Insert";
                            FillGrid();
                        }
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Added Successfully");
                            StMethod.LoginActivityInfo(db, "Insert", this.Text);
                            btnAdd.Text = "Insert";
                            FillGrid();
                        }
                    }

                }


            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void UpdateApplicantInfo()
        {
            try
            {
                string Query = "UPDATE VBNetApplicantInfo SET ApplicantFirstName = @ApplicantFirstName,ApplicantLastName = @ApplicantLastName,ApplicantMidName = @ApplicantMidName,ApplicantBusinessName = @ApplicantBusinessName,ApplicantBusinessAddress = @ApplicantBusinessAddress,ApplicantBusinessCity = @ApplicantBusinessCity,ApplicantBusinessState = @ApplicantBusinessState,ApplicantBusinessZip = @ApplicantBusinessZip,ApplicantTitle = @ApplicantTitle,ApplicantLicense = @ApplicantLicense,ApplicantPhone = @ApplicantPhone,Applicantfax = @Applicantfax WHERE ApplicantID = @ApplicantID";
                SqlCommand CMD = new SqlCommand(Query);
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@ApplicantID", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantID].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantFirstName", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantFirstName].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantLastName", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLastName].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantMidName", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantMidName].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessName", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessName].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessAddress", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessAddress].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessCity", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessCity].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessState", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessState].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantBusinessZip", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantBusinessZip].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantTitle", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantTitle].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantLicense", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantLicense].Value.ToString()));
                Param.Add(new SqlParameter("@ApplicantPhone", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantPhone].Value.ToString()));
                Param.Add(new SqlParameter("@Applicantfax", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[Applicantfax].Value.ToString()));

                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                //    {
                //        KryptonMessageBox.Show("Record Updated Successfully");
                //        StMethod.LoginActivityInfo(db, "Update", this.Text);
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                                        
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Updated Successfully");
                            StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                        }
                    }
                }
                else
                {

                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Updated Successfully");
                            StMethod.LoginActivityInfo(db, "Update", this.Text);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void DeleteApplicantInfo()
        {
            try
            {
                string Query = "DELETE  FROM VBNetApplicantInfo WHERE ApplicantID = @ApplicantID";
                SqlCommand CMD = new SqlCommand(Query);

                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@ApplicantID", grdApplicantInfo.Rows[grdApplicantInfo.CurrentRow.Index].Cells[ApplicantID].Value.ToString()));
                if (KryptonMessageBox.Show("Are you sure to delete these record!", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {
                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                    //    {
                    //        KryptonMessageBox.Show("Record Updated Successfully");
                    //        StMethod.LoginActivityInfo(db, "Delete", this.Text);
                    //    }
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                            {
                                KryptonMessageBox.Show("Record Updated Successfully");
                                StMethod.LoginActivityInfoNew(db, "Delete", this.Text);
                            }
                        }

                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                            {
                                KryptonMessageBox.Show("Record Updated Successfully");
                                StMethod.LoginActivityInfo(db, "Delete", this.Text);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
