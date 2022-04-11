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

namespace JobTracker.MasterTackListItem
{
    public partial class frmDescription : Form
    {
        //private DataTable dtmasteritem = new DataTable();
        private string CheckString;
        public frmDescription()
        {
            InitializeComponent();
        }

        #region Events
        private void btnadd_Click(System.Object sender, System.EventArgs e)
        {
            if (btnadd.Text == "Insert")
            {
                btnadd.Text = "Save";
                List<colPMM> list = (List<colPMM>)grdListitem.DataSource;
                colPMM datarow = new colPMM() { cTrack = "", Id = 0 };
                list.Add(datarow);
                grdListitem.DataSource = new List<colPMM>( list);
                grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cTrack"];
                grdListitem.Rows[grdListitem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                grdListitem.Rows[grdListitem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
            }
            else
            {
                try
                {
                    string strcTrack = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cTrack"].Value.ToString();
                    string queryMatch = "SELECT COUNT(cTrack) FROM  MasterItem where cTrack='" + strcTrack.ToString() + "'";

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            int count = db.Database.SqlQuery<int>(queryMatch).FirstOrDefault();
                            if (count > 0)
                            {
                                MessageBox.Show("Already exist" + strcTrack.ToString(), "Message");
                                grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cTrack"].Value = "";
                                return;
                            }

                            int cnt = grdListitem.Rows.Count - 1;
                            string query = "Insert into MasterItem(cGroup,cTrack,IsNewRecord) values(@group,@track,@IsNewRecord)";
                            SqlCommand cmd = new SqlCommand(query);
                            List<SqlParameter> list = new List<SqlParameter>();
                            list.Add(new SqlParameter("@IsNewRecord", 1));
                            list.Add(new SqlParameter("@group", "Description"));
                            list.Add(new SqlParameter("@track", grdListitem.Rows[cnt].Cells["cTrack"].Value.ToString()));
                            int i = db.Database.ExecuteSqlCommand(cmd.CommandText, list.ToArray());
                            if (i > 0)
                            {
                                Fillgrid();
                            }

                            if (grdListitem.Rows.Count > 0)
                            {
                                StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                                grdListitem.Rows[grdListitem.Rows.Count - 1].Selected = true;
                                grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cTrack"];
                                btnadd.Text = "Insert";
                            }
                        }


                    }
                    else
                    {

                        using (EFDbContext db = new EFDbContext())
                        {
                            int count = db.Database.SqlQuery<int>(queryMatch).FirstOrDefault();
                            if (count > 0)
                            {
                                MessageBox.Show("Already exist" + strcTrack.ToString(), "Message");
                                grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cTrack"].Value = "";
                                return;
                            }

                            int cnt = grdListitem.Rows.Count - 1;
                            string query = "Insert into MasterItem(cGroup,cTrack,IsNewRecord) values(@group,@track,@IsNewRecord)";
                            SqlCommand cmd = new SqlCommand(query);
                            List<SqlParameter> list = new List<SqlParameter>();
                            list.Add(new SqlParameter("@IsNewRecord", 1));
                            list.Add(new SqlParameter("@group", "Description"));
                            list.Add(new SqlParameter("@track", grdListitem.Rows[cnt].Cells["cTrack"].Value.ToString()));
                            int i = db.Database.ExecuteSqlCommand(cmd.CommandText, list.ToArray());
                            if (i > 0)
                            {
                                Fillgrid();
                            }

                            if (grdListitem.Rows.Count > 0)
                            {
                                StMethod.LoginActivityInfo(db, "Update", this.Text);
                                grdListitem.Rows[grdListitem.Rows.Count - 1].Selected = true;
                                grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["cTrack"];
                                btnadd.Text = "Insert";
                            }
                        }

                    }


                    //
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message");
                }
            }
        }
        private void frmDescription_Load(object sender, System.EventArgs e)
        {
            Fillgrid();
        }
        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                txtSearchJobDecrp.Clear();
                Fillgrid();
                // grdListitem.Columns(0).ReadOnly = False
            }
            catch (Exception ex)
            {
            }
            txtTrack.Clear();
        }
        private void grdListitem_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (btnadd.Text.Trim() == "Save" && e.ColumnIndex == 0)
                {
                    btnadd_Click(sender, e);
                }
                if (Convert.ToInt32(grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["Id"].Value.ToString()) != 0)
                {
                    if (e.ColumnIndex == 0 && e.RowIndex > -1)
                    {
                        //grdListitem.Rows[grdListitem.CurrentRow.Index).ReadOnly = False
                        //grdListitem.Rows[grdListitem.CurrentRow.Index).ReadOnly = False
                        btnadd.Text = "Insert";
                        try
                        {
                            string sql = "update MasterItem set cgroup='Description',cTrack='" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["cTrack"].Value.ToString() + "',IsChange=1,ChangeDate='" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "' where id=" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["Id"].Value.ToString();

                            //using (EFDbContext db = new EFDbContext())
                            //{
                            //    if (db.Database.ExecuteSqlCommand(sql) != 0)
                            //    {
                            //        MessageBox.Show("Update Successfully", "Job Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    }
                            //    StMethod.LoginActivityInfo(db, "Update", this.Text);
                            //    grdListitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                            //}



                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                                {
                                    if (db.Database.ExecuteSqlCommand(sql) != 0)
                                    {
                                        MessageBox.Show("Update Successfully", "Job Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                                    grdListitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                }

                            }
                            else
                            {
                                using (EFDbContext db = new EFDbContext())
                                {
                                    if (db.Database.ExecuteSqlCommand(sql) != 0)
                                    {
                                        MessageBox.Show("Update Successfully", "Job Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    StMethod.LoginActivityInfo(db, "Update", this.Text);
                                    grdListitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                }

                            }
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Message");
                        }
                    }
                    else if (e.ColumnIndex == 1)
                    {
                        try
                        {
                            string sql = "UPDATE masteritem SET IsDelete=1 Where id=" + grdListitem.Rows[grdListitem.CurrentRow.Index].Cells["id"].Value.ToString() + "";

                            //using (EFDbContext db = new EFDbContext())
                            //{
                            //    if (db.Database.ExecuteSqlCommand(sql) != 0)
                            //    {
                            //        MessageBox.Show("Record deleted.", "Job Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //        Fillgrid();
                            //    }
                            //}

                            if (Properties.Settings.Default.IsTestDatabase == true)
                            {
                                
                                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                                {
                                    if (db.Database.ExecuteSqlCommand(sql) != 0)
                                    {
                                        MessageBox.Show("Record deleted.", "Job Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Fillgrid();
                                    }
                                }
                            }
                            else
                            {
                                using (EFDbContext db = new EFDbContext())
                                {
                                    if (db.Database.ExecuteSqlCommand(sql) != 0)
                                    {
                                        MessageBox.Show("Record deleted.", "Job Tracker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        Fillgrid();
                                    }
                                }
                            }

                            grdListitem.Rows.RemoveAt(grdListitem.CurrentRow.Index);
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show(ex.Message, "Message");
                        }
                    }
                    //Else
                    //    MessageBox.Show("Please click save button", "Message")
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void txtTrack_TextChanged(System.Object sender, System.EventArgs e)
        {
            //Fillgrid()
        }
        private void grdListitem_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            CheckString = grdListitem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }
        private void grdListitem_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (CheckString != grdListitem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString())
            {
                grdListitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
            }
        }
        private void txtSearchJobDecrp_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                Fillgrid();
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Methods
        private void Fillgrid()
        {
            try
            {
                string queryString = "SELECT Id, cTrack FROM  MasterItem Where ID <> 0 and (MasterItem.IsDelete=0 or MasterItem.IsDelete is null ) AND cGroup='Description' ORDER BY cTrack ";
                if (!string.IsNullOrEmpty(this.txtSearchJobDecrp.Text))
                {
                    // queryString = queryString & " and cTrack Like'" & txtSearchJobDecrp.Text & "%'"
                    queryString = "SELECT Id, cTrack FROM  MasterItem Where ID <> 0 and (MasterItem.IsDelete=0 or MasterItem.IsDelete is null ) AND cGroup='Description' and cTrack Like'" + txtSearchJobDecrp.Text + "%'";
                }

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var list = db.Database.SqlQuery<colPMM>(queryString).ToList();
                //    grdListitem.DataSource = list;
                //    grdListitem.Columns["cTrack"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                //    grdListitem.Columns["cTrack"].HeaderText = "Job description";
                //    grdListitem.Columns["Id"].Visible = false;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var list = db.Database.SqlQuery<colPMM>(queryString).ToList();
                        grdListitem.DataSource = list;
                        grdListitem.Columns["cTrack"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        grdListitem.Columns["cTrack"].HeaderText = "Job description";
                        grdListitem.Columns["Id"].Visible = false;
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var list = db.Database.SqlQuery<colPMM>(queryString).ToList();
                        grdListitem.DataSource = list;
                        grdListitem.Columns["cTrack"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        grdListitem.Columns["cTrack"].HeaderText = "Job description";
                        grdListitem.Columns["Id"].Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
            }
            btnadd.Text = "Insert";
        }
        #endregion
    }
}