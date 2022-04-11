using ComponentFactory.Krypton.Toolkit;
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

namespace JobTracker.PDFeditTools
{
    public partial class frmCraneUser_subInfo : Form
    {
        #region Globle Variable
        private static frmCraneUser_subInfo _Instance;
        private string CraneUSer_Sub_OldID;
        private string CraneUSer_Sub_SelectID;
        private string CraneUser_Sub_Info;
        private string CraneUSer_Title;
        public static string Query = "SELECT  Contacts.ContactsID, Contacts.FirstName, Contacts.MiddleName, Contacts.LastName, Contacts.ContactTitle, Company.CompanyName, Contacts.MobilePhone, Contacts.EmailAddress,Contacts.Address, Contacts.City, Contacts.State, Contacts.FaxNumber, Contacts.PostalCode FROM         Company INNER JOIN Contacts ON Company.CompanyID = Contacts.CompanyID WHERE (Contacts.IsDelete=0 or Contacts.IsDelete is NULL)";
        #endregion
        #region Constant Crane User Info Declaration
        private const string ContactsID = "ContactsID";
        private const string CompanyID = "CompanyID";
        private const string FirstName = "FirstName";
        private const string MiddleName = "MiddleName";
        private const string LastName = "LastName";
        private const string ContactTitle = "ContactTitle";
        private const string MobilePhone = "MobilePhone";
        private const string EmailAddress = "EmailAddress";
        #endregion
        #region Properties
        public string CraneUser_SubOldID
        {
            get
            {
                return CraneUSer_Sub_OldID;
            }
            set
            {
                CraneUSer_Sub_OldID = value;
            }
        }
        public string SelectCraneUser_SubID
        {
            get
            {
                return CraneUSer_Sub_SelectID;
            }
            set
            {
                CraneUSer_Sub_SelectID = value;
            }
        }
        public string CraneUser_SubInfo
        {
            get
            {
                return CraneUser_Sub_Info;
            }
            set
            {
                CraneUser_Sub_Info = value;
            }
        }
        private const string Notes = "Notes";
        private const string Address = "Address";
        private const string City = "City";
        private const string State = "State";
        private const string PostalCode = "PostalCode";
        private const string Country = "Country";
        private const string Contacts_CompanyName = "CompanyName";
        public string CraneUserTitle
        {
            get
            {
                return CraneUSer_Title;
            }
            set
            {
                CraneUSer_Title = value;
            }
        }
        #endregion

        public frmCraneUser_subInfo()
        {
            InitializeComponent();
        }

        #region EVents
        private void frmCraneUser_subInfo_Load(System.Object sender, System.EventArgs e)
        {
            FillCraneUserInfo();
            Get_craneUser_SubInfoSelectOldID();
        }

        private void frmCraneUser_subInfo_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void grdCraneUser_SubInfo_RowHeaderMouseDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            SelectCraneUser_SubID = grdCraneUser_SubInfo.Rows[grdCraneUser_SubInfo.CurrentRow.Index].Cells[ContactsID].Value.ToString();
            CraneUser_SubInfo = grdCraneUser_SubInfo.Rows[grdCraneUser_SubInfo.CurrentRow.Index].Cells[FirstName].Value.ToString() + " " + grdCraneUser_SubInfo.Rows[grdCraneUser_SubInfo.CurrentRow.Index].Cells[MiddleName].Value.ToString() + " " + grdCraneUser_SubInfo.Rows[grdCraneUser_SubInfo.CurrentRow.Index].Cells[LastName].Value.ToString() + " from " + grdCraneUser_SubInfo.Rows[grdCraneUser_SubInfo.CurrentRow.Index].Cells[Contacts_CompanyName].Value.ToString();
            CraneUserTitle = grdCraneUser_SubInfo.Rows[grdCraneUser_SubInfo.CurrentRow.Index].Cells[ContactTitle].Value.ToString();
            this.Hide();
        }

        private void txtCompanyName_TextChanged(System.Object sender, System.EventArgs e)
        {
            FillCraneUserInfo();
        }
        #endregion

        #region Function
        private void FillCraneUserInfo()
        {
            try
            {
                string lclQuery = Query;
                if (!string.IsNullOrEmpty(txtCompanyName.Text))
                {
                    lclQuery = lclQuery + " AND CompanyName LIKE '%" + txtCompanyName.Text + "%'";
                }
                if (!string.IsNullOrEmpty(txtFirstName.Text))
                {
                    lclQuery = lclQuery + " AND FirstNAme Like '%" + txtFirstName.Text + "%'";
                }
                if (!string.IsNullOrEmpty(txtLastName.Text))
                {
                    lclQuery = lclQuery + " AND LastName Like '%" + txtLastName.Text + "%'";
                }

                //using (EFDbContext db = new EFDbContext())
                //{
                //    grdCraneUser_SubInfo.DataSource = db.Database.SqlQuery<CraneUser>(lclQuery).ToList();
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        grdCraneUser_SubInfo.DataSource = db.Database.SqlQuery<CraneUser>(lclQuery).ToList();
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        grdCraneUser_SubInfo.DataSource = db.Database.SqlQuery<CraneUser>(lclQuery).ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        public void Get_craneUser_SubInfoSelectOldID()
        {
            try
            {
                foreach (DataGridViewRow grdrow in grdCraneUser_SubInfo.Rows)
                {
                    if (grdrow.Cells[ContactsID].Value.ToString().Trim() == CraneUser_SubOldID)
                    {
                        grdrow.Selected = true;
                        grdCraneUser_SubInfo.CurrentCell = grdrow.Cells[FirstName];
                        grdrow.DefaultCellStyle.SelectionBackColor = Color.Tomato;
                        grdrow.DefaultCellStyle.BackColor = Color.Tomato;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
    }
}
