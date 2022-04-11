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
    public partial class frmCommunityBoard : Form
    {
        #region Global variable
        private string CommunityBoard_NUM;
        private string OldCommunityBoradNum;
        private static frmCommunityBoard _Instance;
        #endregion

        #region Constant variable
        private const string CommunityBoardID = "CommunityBoardID";
        private const string CommunityBoardNum = "CommunityBoardNum";
        private const string ChairPerson = "ChairPerson";
        private const string Address = "Address";
        private const string City = "City";
        private const string State = "State";
        private const string Zip = "Zip";
        private const string Phone = "Phone";
        private const string Fax = "Fax";
        private const string IsChange = "IsChange";
        private const string IsNewRecord = "IsNewRecord";
        private const string IsDelete = "IsDelete";
        private const string ChangeDate = "ChangeDate";
        #endregion

        #region Properties
        public string CommunityBoardOldNum
        {
            get
            {
                return OldCommunityBoradNum;
            }
            set
            {
                OldCommunityBoradNum = value;
            }
        }
        public string SelectCommunityBoardNum
        {
            get
            {
                return CommunityBoard_NUM;
            }
            set
            {
                CommunityBoard_NUM = value;
            }
        }
        public static frmCommunityBoard Instance
        {
            get
            {
                if (_Instance == null || _Instance.IsDisposed)
                {
                    _Instance = new frmCommunityBoard();
                }
                return _Instance;
            }
        }
        #endregion
        public frmCommunityBoard()
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
                InsertNewCommunityBoardInfo();
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
                    UpdateCommunityBoardInfo();
                }
                else
                {
                    KryptonMessageBox.Show("First Save and then update!");
                }

            }
        }

        private void grdApplicantInfo_RowHeaderMouseDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            SelectCommunityBoardNum = grdCommunityBoard.Rows[e.RowIndex].Cells[CommunityBoardNum].Value.ToString();
            this.Hide();
        }

        private void frmApplicant_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void frmCommunityBoard_Load(System.Object sender, System.EventArgs e)
        {
            FillGrid();
            CommunityBoradNumFromInfo();
        }

        #endregion

        #region Function
        private void FillGrid()
        {
            try
            {
                string Query = "SELECT CommunityBoardID, CommunityBoardNum, ChairPerson, Address, City, State, Zip, Phone, Fax FROM         CommunityBoard";



                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<CommunityData>(Query).ToList();
                //    grdCommunityBoard.DataSource = data;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<CommunityData>(Query).ToList();
                        grdCommunityBoard.DataSource = data;
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<CommunityData>(Query).ToList();
                        grdCommunityBoard.DataSource = data;
                    }
                }

                grdCommunityBoard.Columns[CommunityBoardID].Visible = false;
                grdCommunityBoard.Columns[CommunityBoardNum].HeaderText = "Community Board NO";
                grdCommunityBoard.Columns[ChairPerson].HeaderText = "Chair Person";
                grdCommunityBoard.Columns[Address].HeaderText = "C_B Address";
                grdCommunityBoard.Columns[City].HeaderText = "C_B City";
                grdCommunityBoard.Columns[State].HeaderText = "C_B State";
                grdCommunityBoard.Columns[Zip].HeaderText = "C_B Zip";
                grdCommunityBoard.Columns[Phone].HeaderText = "C_B Phone";
                grdCommunityBoard.Columns[Fax].HeaderText = "C_B Fax";
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
                Addrow = Program.ToDataTable<CommunityData>((List<CommunityData>) grdCommunityBoard.DataSource);
                DataRow NewR = Addrow.NewRow();
                Addrow.Rows.Add(NewR);
                grdCommunityBoard.DataSource = Addrow;
                grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Selected = true;
                grdCommunityBoard.CurrentCell = grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[CommunityBoardNum];
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void InsertNewCommunityBoardInfo()
        {
            try
            {
                string Query = "INSERT INTO CommunityBoard( CommunityBoardNum, ChairPerson, Address, City, State, Zip, Phone, Fax ) VALUES ( @CommunityBoardNum, @ChairPerson, @Address, @City, @State, @Zip, @Phone, @Fax )";

                SqlCommand CMD = new SqlCommand(Query);
                List<SqlParameter> Param = new List<SqlParameter>();
                //Param.Add(new SqlParameter("@CommunityBoardID", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[CommunityBoardID].Value.ToString()))
                Param.Add(new SqlParameter("@CommunityBoardNum", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[CommunityBoardNum].Value.ToString()));
                Param.Add(new SqlParameter("@ChairPerson", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[ChairPerson].Value.ToString()));
                Param.Add(new SqlParameter("@Address", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[Address].Value.ToString()));
                Param.Add(new SqlParameter("@City", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[City].Value.ToString()));
                Param.Add(new SqlParameter("@State", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[State].Value.ToString()));
                Param.Add(new SqlParameter("@Zip", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[Zip].Value.ToString()));
                Param.Add(new SqlParameter("@Phone", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[Phone].Value.ToString()));
                Param.Add(new SqlParameter("@Fax", grdCommunityBoard.Rows[grdCommunityBoard.Rows.Count - 1].Cells[Fax].Value.ToString()));



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
        private void UpdateCommunityBoardInfo()
        {
            try
            {
                string Query = " UPDATE CommunityBoard SET CommunityBoardNum = @CommunityBoardNum,ChairPerson = @ChairPerson,Address = @Address,City = @City,State = @State,Zip = @Zip,Phone = @Phone,Fax = @Fax WHERE CommunityBoardID = @CommunityBoardID";
                SqlCommand CMD = new SqlCommand(Query);
                List<SqlParameter> Param = new List<SqlParameter>();


                //string QueryTemp = "SELECT CommunityBoardID, CommunityBoardNum, ChairPerson, Address, City, State, Zip, Phone, Fax FROM         CommunityBoard";

                string UpdateCommunityBoardID=string.Empty;

                if (string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[CommunityBoardID].Value.ToString()))
                {
                    UpdateCommunityBoardID = "";
                }
                else
                {
                    UpdateCommunityBoardID = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[ChairPerson].Value.ToString();
                }

                //Param.Add(new SqlParameter("@CommunityBoardID", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[CommunityBoardID].Value.ToString()));

                Param.Add(new SqlParameter("@CommunityBoardID", UpdateCommunityBoardID));

                string UpdateCommunityBoardNum = string.Empty;

                if (string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[CommunityBoardNum].Value.ToString()))
                {
                    UpdateCommunityBoardNum = "";
                }
                else
                {
                    UpdateCommunityBoardNum = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[CommunityBoardNum].Value.ToString();
                }


                Param.Add(new SqlParameter("@CommunityBoardNum", UpdateCommunityBoardNum));

                //Param.Add(new SqlParameter("@CommunityBoardNum", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[CommunityBoardNum].Value.ToString()));



                string chairPerson;

                if(string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[ChairPerson].Value.ToString()))
                {
                    chairPerson = "";
                }
                else
                {
                    chairPerson = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[ChairPerson].Value.ToString();
                }


                Param.Add(new SqlParameter("@ChairPerson", chairPerson));


                //Param.Add(new SqlParameter("@ChairPerson", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[ChairPerson].Value.ToString()));




                //MessageBox.Show(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[ChairPerson].Value.ToString());


                string UpdateAddress;

                if (string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Address].Value.ToString()))
                {
                    UpdateAddress = "";
                }
                else
                {
                    UpdateAddress = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Address].Value.ToString();
                }

                Param.Add(new SqlParameter("@Address", UpdateAddress));

                //Param.Add(new SqlParameter("@Address", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Address].Value.ToString()));


                //MessageBox.Show(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Address].Value.ToString()); 

                string UpdateCity;

                if (string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[City].Value.ToString()))
                {
                    UpdateCity = "";
                }
                else
                {
                    UpdateCity = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[City].Value.ToString();
                }

                Param.Add(new SqlParameter("@City", UpdateCity));

                //Param.Add(new SqlParameter("@City", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[City].Value.ToString()));


                //MessageBox.Show(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[State].Value.ToString());


                string UpdateState;

                if (string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[State].Value.ToString()))
                {
                    UpdateState = "";
                }
                else
                {
                    UpdateState = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[State].Value.ToString();
                }

                Param.Add(new SqlParameter("@State", UpdateState));

                //Param.Add(new SqlParameter("@State", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[State].Value.ToString()));


                //MessageBox.Show(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[State].Value.ToString());

                string UpdateZip;

                if (string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Zip].Value.ToString()))
                {
                    UpdateZip = "";
                }
                else
                {
                    UpdateZip = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Zip].Value.ToString();
                }

                Param.Add(new SqlParameter("@Zip", UpdateZip));

                //Param.Add(new SqlParameter("@Zip", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Zip].Value.ToString()));



                //MessageBox.Show(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Zip].Value.ToString());


                string UpdatePhone;

                if (string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Phone].Value.ToString()))
                {
                    UpdatePhone = "";
                }
                else
                {
                    UpdatePhone = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Phone].Value.ToString();
                }

                Param.Add(new SqlParameter("@Phone", UpdatePhone));
                //Param.Add(new SqlParameter("@Phone", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Phone].Value.ToString()));



                //MessageBox.Show(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Phone].Value.ToString());



                string UpdateFax;

                if (string.IsNullOrEmpty(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Fax].Value.ToString()))
                {
                    UpdateFax = "";
                }
                else
                {
                    UpdateFax = grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Fax].Value.ToString();
                }

                Param.Add(new SqlParameter("@Phone", UpdateFax));

                
                //Param.Add(new SqlParameter("@Fax", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Fax].Value.ToString()));



                //MessageBox.Show(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Fax].Value.ToString());

                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                //    {
                //        KryptonMessageBox.Show("Record Updated Successfully");
                //        StMethod.LoginActivityInfo(db, "Update", this.Text);
                //    }
                //}

                //Clipboard.SetText(grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[CommunityBoardID].Value.ToString() + Environment.NewLine + grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[CommunityBoardNum].Value.ToString() + grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[ChairPerson].Value.ToString() + grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Address].Value.ToString() + Environment.NewLine + grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[City].Value.ToString() + Environment.NewLine + grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[State].Value.ToString() + Environment.NewLine + grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Zip].Value.ToString() + Environment.NewLine + grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Phone].Value.ToString() + Environment.NewLine + grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[Fax].Value.ToString());



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                    {
                        if (db2.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                        {
                            KryptonMessageBox.Show("Record Updated Successfully");
                            StMethod.LoginActivityInfoNew(db2, "Update", this.Text);
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
        private void DeleteCommunityInfo()
        {
            try
            {
                string Query = "DELETE  FROM CommunityBoard WHERE CommunityBoardID = @CommunityBoardID";
                SqlCommand CMD = new SqlCommand(Query);
                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@CommunityBoardID", grdCommunityBoard.Rows[grdCommunityBoard.CurrentRow.Index].Cells[CommunityBoardID].Value.ToString()));
                if (KryptonMessageBox.Show("Are you sure to delete these record!", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes)
                {

                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                    //    {
                    //        {
                    //            KryptonMessageBox.Show("Record Updated Successfully");
                    //            StMethod.LoginActivityInfo(db, "Delete", this.Text);
                    //        }
                    //    }
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                            {
                                {
                                    KryptonMessageBox.Show("Record Updated Successfully");
                                    StMethod.LoginActivityInfoNew(db, "Delete", this.Text);
                                }
                            }
                        }
                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                            {
                                {
                                    KryptonMessageBox.Show("Record Updated Successfully");
                                    StMethod.LoginActivityInfo(db, "Delete", this.Text);
                                }
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
        private void CommunityBoradNumFromInfo()
        {
            if (CommunityBoardOldNum != null)
            {
                if (!string.IsNullOrEmpty(CommunityBoardOldNum.Trim()))
                {
                    foreach (DataGridViewRow grdrow in grdCommunityBoard.Rows)
                    {
                        if (grdrow.Cells[CommunityBoardNum].Value.ToString().Trim() == CommunityBoardOldNum)
                        {
                            grdrow.Selected = true;
                            grdCommunityBoard.CurrentCell = grdrow.Cells[CommunityBoardNum];
                            grdrow.DefaultCellStyle.SelectionBackColor = Color.Tomato;
                            grdrow.DefaultCellStyle.BackColor = Color.Tomato;
                        }
                    }
                }
            }
        }
        #endregion
    }
}
