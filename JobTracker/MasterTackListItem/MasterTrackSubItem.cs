using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;


using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

using NPOI.HSSF.UserModel;
using System.Globalization;
using System.Windows;

//UIElement.RemoveHandler(RoutedEvent, Delegate) Method.

namespace JobTracker.MasterTackListItem
{
    public partial class MasterTrackSubItem : Form
    {
        #region Declarations
        //private SqlConnection Con = new SqlConnection();
        //private SqlCommand SqlCmd;
        private DataGridViewComboBoxCell cmbTCTackName;
        private ComboBox cmbCalColor;
        private static MasterTrackSubItem _Instance;
        private bool IsChangeTableVersionInvoice;
        private string ChangeText;
        bool IsSubTrackLoadComplete = false;
        private HSSFWorkbook workBook = new HSSFWorkbook();

        #endregion

        public MasterTrackSubItem()
        {
            InitializeComponent();
        }

        #region Events
        private void MasterTrackSubItem_Load(System.Object sender, System.EventArgs e)
        {
            SetGridTracckColumn();
            FillTrackGrid();
            FillCombo();
            IsSubTrackLoadComplete = false;
            //  FillcmbVersion() ' Fill Version Combo

            cmbSearchTableVersion.SelectedIndexChanged -= this.cmbSearchTableVersion_SelectedIndexChanged;
            fillcmbTableVersionsearch();
            cmbSearchTableVersion.SelectedIndexChanged += cmbSearchTableVersion_SelectedIndexChanged;
        }
        private void grdTrackitem_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    if (Convert.ToInt16(grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString()) == 0)
                    {
                        btnAddTrack_Click();
                        return;
                    }
                    try
                    {
                        if (string.IsNullOrEmpty(grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackSet"].Value.ToString().Trim()))
                        {
                            KryptonMessageBox.Show("Pleasre select Trackset item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        if (string.IsNullOrEmpty(grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackName"].Value.ToString().Trim()))
                        {
                            KryptonMessageBox.Show("Pleasre select Track Name item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    catch (Exception ex)
                    {

                    }
                    string query = "UPDATE MasterTrackSet SET TrackSet=@TrackSet,TrackName=@TrackName,IsChange=@IsChange,ChangeDate=@ChangeDate  WHERE Id=@Id";
                    SqlCommand cmd = new SqlCommand(query);
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@TrackSet", grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackSet"].Value.ToString()));
                    param.Add(new SqlParameter("@TrackName", grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackName"].Value.ToString()));
                    param.Add(new SqlParameter("@Id", grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString()));
                    param.Add(new SqlParameter("@IsChange", 1));
                    param.Add(new SqlParameter("@ChangeDate", DateTime.Now.ToString("MM/dd/yyyy")));

                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    int i = db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());

                    //    if (i == 1)
                    //    {
                    //        KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //        StMethod.LoginActivityInfo(db, "Update", this.Text);
                    //        UpdateInTrackInTrackSubItem();
                    //        grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                    //        grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                    //        //FillTrackGrid()
                    //        //FillTrackSubGrid()
                    //    }
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            int i = db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());

                            if (i == 1)
                            {
                                KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                                UpdateInTrackInTrackSubItem();
                                grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                                grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                //FillTrackGrid()
                                //FillTrackSubGrid()
                            }
                        }

                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            int i = db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());

                            if (i == 1)
                            {
                                KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                StMethod.LoginActivityInfo(db, "Update", this.Text);
                                UpdateInTrackInTrackSubItem();
                                grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                                grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                //FillTrackGrid()
                                //FillTrackSubGrid()
                            }
                        }

                    }







                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                try
                {
                    if (Convert.ToInt32(grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString()) == 0)
                    {
                        KryptonMessageBox.Show("First save and then delete", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    int i = db.Database.ExecuteSqlCommand("Update MasterTrackSet set IsDelete=1 where Id=" + grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString());

                    //    if (i == 1)
                    //    {
                    //        KryptonMessageBox.Show("Delete Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //        StMethod.LoginActivityInfo(db, "Delete", this.Text);
                    //        db.Database.ExecuteSqlCommand("UPDATE MasterTrackSubItem SET IsDelete=1 WHERE TrackId=" + grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString());
                    //        FillTrackGrid();
                    //        FillTrackSubGrid();
                    //    }
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            int i = db.Database.ExecuteSqlCommand("Update MasterTrackSet set IsDelete=1 where Id=" + grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString());

                            if (i == 1)
                            {
                                KryptonMessageBox.Show("Delete Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                StMethod.LoginActivityInfoNew(db, "Delete", this.Text);
                                db.Database.ExecuteSqlCommand("UPDATE MasterTrackSubItem SET IsDelete=1 WHERE TrackId=" + grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString());
                                FillTrackGrid();
                                FillTrackSubGrid();
                            }
                        }

                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            int i = db.Database.ExecuteSqlCommand("Update MasterTrackSet set IsDelete=1 where Id=" + grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString());

                            if (i == 1)
                            {
                                KryptonMessageBox.Show("Delete Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                StMethod.LoginActivityInfo(db, "Delete", this.Text);
                                db.Database.ExecuteSqlCommand("UPDATE MasterTrackSubItem SET IsDelete=1 WHERE TrackId=" + grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString());
                                FillTrackGrid();
                                FillTrackSubGrid();
                            }
                        }
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }
        private void btnAddTrack_Click()
        {
            try
            {
                try
                {
                    if (string.IsNullOrEmpty(grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackSet"].Value.ToString().Trim()))
                    {
                        KryptonMessageBox.Show("Pleasre select Trackset item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackName"].Value.ToString().Trim()))
                    {
                        KryptonMessageBox.Show("Pleasre select Track Name item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message);
                }
                string query = "INSERT INTO MasterTrackSet(TrackSet, TrackName,IsNewRecord) VALUES (@TrackSet,@TrackName,@IsNewRecord)";
                SqlCommand cmd = new SqlCommand(query);
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@TrackSet", grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackSet"].Value.ToString()));
                param.Add(new SqlParameter("@TrackName", grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackName"].Value.ToString()));
                param.Add(new SqlParameter("@IsNewRecord", 1));




                //using (EFDbContext db = new EFDbContext())
                //{
                //    int i = db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());
                //    if (i == 1)
                //    {
                //        MessageBox.Show("Save Sucessfully");

                //        StMethod.LoginActivityInfo(db, "Insert", this.Text);
                //        btnInsertTrack.Text = "Insert";
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        int i = db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());
                        if (i == 1)
                        {
                            MessageBox.Show("Save Sucessfully");

                            StMethod.LoginActivityInfoNew(db, "Insert", this.Text);
                            btnInsertTrack.Text = "Insert";
                        }
                    }

                }
                else
                {

                    using (EFDbContext db = new EFDbContext())
                    {
                        int i = db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());
                        if (i == 1)
                        {
                            MessageBox.Show("Save Sucessfully");

                            StMethod.LoginActivityInfo(db, "Insert", this.Text);
                            btnInsertTrack.Text = "Insert";
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                btnInsertTrack.Text = "Insert";
            }
            SetGridTracckColumn();
            FillTrackGrid();
            FillCombo();
        }

        private void grdTrackSubItem_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (IsChangeTableVersionInvoice == true)
                {
                    if (e.ColumnIndex == 0 && e.RowIndex > -1)
                    {
                        UpdateTableVersionInvoice();
                    }
                    else if (e.ColumnIndex == 1 && e.RowIndex > -1)
                    {
                        if (Convert.ToInt16(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["VersionDescId"].Value.ToString()) == 0)
                        {
                            KryptonMessageBox.Show("First save and then delete!", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        DeleteTableVersionInvoice();
                    }
                    return;
                }
                if ((e.ColumnIndex == 2 || e.ColumnIndex == 3) && e.RowIndex > -1)
                {
                    cmbTCTackName = new DataGridViewComboBoxCell();


                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    var data = db.Database.SqlQuery<dtoMasterTrack>("SELECT Id, TrackName FROM  MasterTrackSet WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackSet='" + grdTrackSubItem.Rows[e.RowIndex].Cells["CmbTrackSet"].Value.ToString().Trim() + "'").ToList();
                    //    cmbTCTackName.DataSource = data;
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            var data = db.Database.SqlQuery<dtoMasterTrack>("SELECT Id, TrackName FROM  MasterTrackSet WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackSet='" + grdTrackSubItem.Rows[e.RowIndex].Cells["CmbTrackSet"].Value.ToString().Trim() + "'").ToList();
                            cmbTCTackName.DataSource = data;
                        }

                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            var data = db.Database.SqlQuery<dtoMasterTrack>("SELECT Id, TrackName FROM  MasterTrackSet WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackSet='" + grdTrackSubItem.Rows[e.RowIndex].Cells["CmbTrackSet"].Value.ToString().Trim() + "'").ToList();
                            cmbTCTackName.DataSource = data;
                        }
                    }


                    cmbTCTackName.DisplayMember = "TrackName";
                    grdTrackSubItem.Rows[e.RowIndex].Cells[3] = cmbTCTackName;
                }
                if (e.ColumnIndex == 0 && e.RowIndex > -1)
                {
                    UpdateTrackSub();
                }
                if (e.ColumnIndex == 1 && e.RowIndex > -1)
                {
                    if (Convert.ToInt32(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["Id"].Value.ToString()) == 0)
                    {
                        KryptonMessageBox.Show("First save and then delete!", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    DeletedJobTrackingTrackSub(e.RowIndex);
                    DeleteTrackSub();

                }
                if (e.ColumnIndex == 8 && e.RowIndex > -1)
                {
                    ColorDialog colorDlg = new ColorDialog();
                    colorDlg.AllowFullOpen = true;
                    colorDlg.AnyColor = true;
                    if (colorDlg.ShowDialog() == DialogResult.OK)
                    {
                        grdTrackSubItem.CurrentRow.Cells["CalColor"].Value = colorDlg.Color.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void btnInsert_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (IsChangeTableVersionInvoice == true)
                {
                    MessageBox.Show("Can't insert row into invoice table, Please clear search criteria.");
                    return;
                }
                if (btnInsert.Text == "Insert Track Sub Item")
                {
                    for (Int32 i = 0; i < grdTrackSubItem.Rows.Count; i++)
                    {
                        if (grdTrackSubItem.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                        {
                            KryptonMessageBox.Show("Can't insert new record, first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    btnInsert.Text = "Save Track Sub Item";



                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    var data = db.Database.SqlQuery<MasterTrackSubData>("SELECT TrackSet,TrackName, TrackSubName,nRate,Description,Account, CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                    //    MasterTrackSubData oNewRow = new MasterTrackSubData() { Id = 0, TrackSet = "", TrackName = "", TrackSubName = "", nRate = 0, Description = "", Account = "", CalColor = "white" };
                    //    data.Add(oNewRow);
                    //    grdTrackSubItem.DataSource = data;
                    //    grdTrackSubItem.CurrentCell = grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["btnUpdateGridTrackSub"];
                    //    grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                    //    grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            var data = db.Database.SqlQuery<MasterTrackSubData>("SELECT TrackSet,TrackName, TrackSubName,nRate,Description,Account, CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                            MasterTrackSubData oNewRow = new MasterTrackSubData() { Id = 0, TrackSet = "", TrackName = "", TrackSubName = "", nRate = 0, Description = "", Account = "", CalColor = "white" };
                            data.Add(oNewRow);
                            grdTrackSubItem.DataSource = data;
                            grdTrackSubItem.CurrentCell = grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["btnUpdateGridTrackSub"];
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                        }



                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            var data = db.Database.SqlQuery<MasterTrackSubData>("SELECT TrackSet,TrackName, TrackSubName,nRate,Description,Account, CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                            MasterTrackSubData oNewRow = new MasterTrackSubData() { Id = 0, TrackSet = "", TrackName = "", TrackSubName = "", nRate = 0, Description = "", Account = "", CalColor = "white" };
                            data.Add(oNewRow);
                            grdTrackSubItem.DataSource = data;
                            grdTrackSubItem.CurrentCell = grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["btnUpdateGridTrackSub"];
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                        }


                    }

                }
                else
                {
                    insertTrackSubItem();
                }
                if (IsChangeTableVersionInvoice == true)
                {
                    MessageBox.Show("Can't insert row into invoice table, Please clear search criteria.");
                    return;
                }
                if (btnInsert.Text == "Insert Track Sub Item")
                {
                    for (Int32 i = 0; i < grdTrackSubItem.Rows.Count; i++)
                    {
                        if (grdTrackSubItem.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                        {
                            KryptonMessageBox.Show("Can't insert new record, first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    btnInsert.Text = "Save Track Sub Item";


                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    var data = db.Database.SqlQuery<MasterTrackSubData>("SELECT TrackSet,TrackName, TrackSubName,nRate,Description,Account, CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                    //    MasterTrackSubData oNewRow = new MasterTrackSubData() { Id = 0, TrackSet = "", TrackName = "", TrackSubName = "", nRate = 0, Description = "", Account = "", CalColor = "white" };
                    //    data.Add(oNewRow);
                    //    grdTrackSubItem.DataSource = data;
                    //    grdTrackSubItem.CurrentCell = grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["btnUpdateGridTrackSub"];
                    //    grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                    //    grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            var data = db.Database.SqlQuery<MasterTrackSubData>("SELECT TrackSet,TrackName, TrackSubName,nRate,Description,Account, CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                            MasterTrackSubData oNewRow = new MasterTrackSubData() { Id = 0, TrackSet = "", TrackName = "", TrackSubName = "", nRate = 0, Description = "", Account = "", CalColor = "white" };
                            data.Add(oNewRow);
                            grdTrackSubItem.DataSource = data;
                            grdTrackSubItem.CurrentCell = grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["btnUpdateGridTrackSub"];
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                        }


                    }
                    else
                    {

                        using (EFDbContext db = new EFDbContext())
                        {
                            var data = db.Database.SqlQuery<MasterTrackSubData>("SELECT TrackSet,TrackName, TrackSubName,nRate,Description,Account, CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                            MasterTrackSubData oNewRow = new MasterTrackSubData() { Id = 0, TrackSet = "", TrackName = "", TrackSubName = "", nRate = 0, Description = "", Account = "", CalColor = "white" };
                            data.Add(oNewRow);
                            grdTrackSubItem.DataSource = data;
                            grdTrackSubItem.CurrentCell = grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["btnUpdateGridTrackSub"];
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                        }

                    }
                }
                else
                {
                    insertTrackSubItem();
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                btnInsert.Text = "Insert Track Sub Item";
                ClearData();
                SetTrackSubGridColumn();
                fillRateVersion();
                //FillTrackSubGrid();


                //btnInsert.Text = "Add New Track Sub Item"
                //ClearData()
                //SetTrackSubGridColumn()
                //fillRateVersion()


                //btnInsert.Text = "Add New Track Sub Item"
                //ClearData()
                //SetTrackSubGridColumn()
                //fillRateVersion()

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void CmbSearchTrack_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (!IsSubTrackLoadComplete) return;
                ClearMasterSubTrack();
                FillTrackGrid();
                FillTrackSubGrid();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void txtSearchTrack_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                ClearMasterSubTrack();
                FillTrackGrid();
                FillTrackSubGrid();
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void txtTrackSub_TextChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                ClearMasterSubTrack();
                if (IsChangeTableVersionInvoice == true)
                {
                    fillRateVersion();
                }
                else
                {
                    FillTrackSubGrid();
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }
        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            cmbSearchTableVersion.SelectedValue = 0;
            IsChangeTableVersionInvoice = false;
            ClearData();
        }
        private void grdTrackSubItem_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 2) && e.RowIndex > -1)
            {
                cmbTCTackName = new DataGridViewComboBoxCell();
                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<dtoMasterTrack>("SELECT Id, TrackName FROM  MasterTrackSet WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackSet='" + grdTrackSubItem.Rows[e.RowIndex].Cells["CmbTrackSet"].Value.ToString().Trim() + "'").ToList();
                //    cmbTCTackName.DataSource = data;
                //    cmbTCTackName.DisplayMember = "TrackName";
                //    grdTrackSubItem.Rows[e.RowIndex].Cells[3] = cmbTCTackName;
                //}



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<dtoMasterTrack>("SELECT Id, TrackName FROM  MasterTrackSet WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackSet='" + grdTrackSubItem.Rows[e.RowIndex].Cells["CmbTrackSet"].Value.ToString().Trim() + "'").ToList();
                        cmbTCTackName.DataSource = data;
                        cmbTCTackName.DisplayMember = "TrackName";
                        grdTrackSubItem.Rows[e.RowIndex].Cells[3] = cmbTCTackName;
                    }


                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<dtoMasterTrack>("SELECT Id, TrackName FROM  MasterTrackSet WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackSet='" + grdTrackSubItem.Rows[e.RowIndex].Cells["CmbTrackSet"].Value.ToString().Trim() + "'").ToList();
                        cmbTCTackName.DataSource = data;
                        cmbTCTackName.DisplayMember = "TrackName";
                        grdTrackSubItem.Rows[e.RowIndex].Cells[3] = cmbTCTackName;
                    }


                }
            }
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (btnInsertTrack.Text.ToUpper() == "SAVE")
                {
                    return;
                }
                string value = (grdTrackSubItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null) ? "" : grdTrackSubItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (value != ChangeText)
                {
                    grdTrackSubItem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    grdTrackSubItem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                    ChangeText = string.Empty;
                }
            }
        }
        private void btnInsertTrack_Click(System.Object sender, System.EventArgs e)
        {
            if (btnInsertTrack.Text == "Insert")
            {
                for (int i = 0; i < grdTrackitem.Rows.Count; i++)
                {
                    if (grdTrackitem.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                    {
                        KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Manager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                btnInsertTrack.Text = "Save";

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<MasterTrackSetData>("SELECT Id, TrackSet, TrackName FROM  MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                //    MasterTrackSetData newRow = new MasterTrackSetData() { Id = 0, TrackSet = "", TrackName = "" };
                //    data.Add(newRow);
                //    grdTrackitem.DataSource = data;
                //    grdTrackitem.CurrentCell = grdTrackitem.Rows[grdTrackitem.Rows.Count - 1].Cells["btnEdit"];
                //    grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                //    grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                //}



                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<MasterTrackSetData>("SELECT Id, TrackSet, TrackName FROM  MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                        MasterTrackSetData newRow = new MasterTrackSetData() { Id = 0, TrackSet = "", TrackName = "" };
                        data.Add(newRow);
                        grdTrackitem.DataSource = data;
                        grdTrackitem.CurrentCell = grdTrackitem.Rows[grdTrackitem.Rows.Count - 1].Cells["btnEdit"];
                        grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                        grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                    }

                }
                else
                {

                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<MasterTrackSetData>("SELECT Id, TrackSet, TrackName FROM  MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                        MasterTrackSetData newRow = new MasterTrackSetData() { Id = 0, TrackSet = "", TrackName = "" };
                        data.Add(newRow);
                        grdTrackitem.DataSource = data;
                        grdTrackitem.CurrentCell = grdTrackitem.Rows[grdTrackitem.Rows.Count - 1].Cells["btnEdit"];
                        grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                        grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                    }

                }
            }
            else
            {
                btnAddTrack_Click();
                //lblDescriptionSize.Visible = False
            }
        }
        private void btnTrackSetCancel_Click(System.Object sender, System.EventArgs e)
        {
            btnInsertTrack.Text = "Insert";
            SetGridTracckColumn();
            FillTrackGrid();
            FillCombo();
        }
        private void grdTrackitem_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                ChangeText = string.Empty;
                if (Convert.ToInt16(grdTrackitem.Rows[grdTrackitem.Rows.Count - 1].Cells["Id"].Value.ToString()) == 0)
                {
                    if (grdTrackitem.CurrentRow.Index == grdTrackitem.Rows.Count - 1)
                    {
                        return;
                    }
                    KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                ChangeText = grdTrackitem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
        private void grdTrackitem_CellEndEdit(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex > -1 && e.RowIndex > -1)
            {
                if (btnInsertTrack.Text.ToUpper() == "SAVE")
                {
                    return;
                }
                if (grdTrackitem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != ChangeText)
                {
                    grdTrackitem.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                    grdTrackitem.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                    ChangeText = string.Empty;
                }
            }
        }
        private void grdTrackSubItem_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            if (IsChangeTableVersionInvoice == false)
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    ChangeText = string.Empty;
                    if (Convert.ToInt32(grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Id"].Value.ToString()) == 0)
                    {
                        if (grdTrackSubItem.CurrentRow.Index == grdTrackSubItem.Rows.Count - 1)
                        {
                            return;
                        }
                        KryptonMessageBox.Show("First Save then select for update", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (grdTrackSubItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                        ChangeText = grdTrackSubItem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
            }
        }
        private void btnRefresh_Click(System.Object sender, System.EventArgs e)
        {
            SetGridTracckColumn();
            FillTrackGrid();
            FillCombo();
            SetTrackSubGridColumn();
            FillTrackSubGrid();
        }
        private void grdTrackSubItem_EditingControlShowing(object sender, System.Windows.Forms.DataGridViewEditingControlShowingEventArgs e)
        {
            if (((DataGridView)sender).CurrentCell.ColumnIndex == 6)
            {
                TextBox DescriptionTextSize = (TextBox)e.Control;
                DescriptionTextSize.KeyPress += DescriptionTextSize_KeyPress;
            }
        }
        private void DescriptionTextSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            //lblDescriptionSize.Visible = True
            //If grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["Description").EditedFormattedValue.ToString.Length - 1 > 250 Then
            //    lblDescriptionSize.Visible = False
            //    If Asc(e.KeyChar) = 8 Then
            //        e.Handled = False
            //        lblDescriptionSize.Visible = False
            //    Else
            //        e.Handled = True
            //    End If
            //Else
            //    lblDescriptionSize.Text = grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["Description").EditedFormattedValue.ToString.Length
            //End If
        }

        private void ExportToExcel()
        {
            try
            {
                frmConfirmation confir = new frmConfirmation(true);
                confir.ShowDialog();
                if (confir.Result == DialogResult.OK)
                {
                    System.Data.DataTable ExportDt = new System.Data.DataTable();
                    string sOrderByField = "";
                    if (confir.Info == "Track Display Set")
                        sOrderByField = "TrackSet";
                    else if (confir.Info == "Track Name")
                        sOrderByField = "TrackName";
                    else
                        sOrderByField = "TrackSubName";

                    string sQuery = string.Format("SELECT TrackSet, TrackName, TrackSubName, Account, nRate as [Rate], Description FROM MasterTrackSubDisplay ORDER BY {0} ASC", sOrderByField);
                    
                    //ExportDt = StMethod.GetListDT<dtoMTSubItem>(sQuery);


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        ExportDt = StMethod.GetListDTNew<dtoMTSubItem>(sQuery);

                    }
                    else
                    {
                        ExportDt = StMethod.GetListDT<dtoMTSubItem>(sQuery);
                    }

                    if (ExportDt.Rows.Count > 0)
                    {

                        string FullFilePath = confir.FileName;
                        string filename = Path.GetFileName(confir.FileName);
                        string filePath = confir.FileName;

                        ISheet sheet1 = workBook.CreateSheet(filename);
                        //ISheet sheet1 = workBook.CreateSheet(confir.FileName);

                        IFont myFont = (IFont)workBook.CreateFont();
                        myFont.FontHeightInPoints = 11;
                        //myFont.FontName = "Tahoma";
                        myFont.FontName = "Arial";



                        ICellStyle borderedCellStyle = (ICellStyle)workBook.CreateCellStyle();

                        borderedCellStyle.SetFont(myFont);

                        //borderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                        //borderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                        //borderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                        //borderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                        borderedCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Left;

                        Int32 Sheetrowindex = 0;
                        int percent = 0;


                        //HSSFFont HeaderFont = (HSSFFont)workBook.CreateFont();
                        IFont HeaderFont = (IFont)workBook.CreateFont();
                        HeaderFont.FontHeightInPoints = 11;
                        //HeaderFont.FontName = "Tahoma";
                        HeaderFont.FontName = "Arial";

                        HeaderFont.IsBold = true;
                        HeaderFont.Color = IndexedColors.RoyalBlue.Index;

                        //XSSFCellStyle HeaderBorderedCellStyle = (XSSFCellStyle)workBook.CreateCellStyle();
                        //HSSFCellStyle HeaderBorderedCellStyle = (HSSFCellStyle)workBook.CreateCellStyle();
                        ICellStyle HeaderBorderedCellStyle = (ICellStyle)workBook.CreateCellStyle();

                        HeaderBorderedCellStyle.SetFont(HeaderFont);

                        HeaderBorderedCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                        HeaderBorderedCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                        HeaderBorderedCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                        HeaderBorderedCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;
                        HeaderBorderedCellStyle.VerticalAlignment = VerticalAlignment.Center;


                        //var sheetRow1 = sheet1.CreateRow(0);
                        //var sheetRow1 = sheet1.CreateRow(0);
                        IRow sheetRow1 = sheet1.CreateRow(0);

                        ICell Cell1 = sheetRow1.CreateCell(0);
                        Cell1.SetCellValue("TrackSet");
                        Cell1.CellStyle = HeaderBorderedCellStyle;

                        ICell Cell2 = sheetRow1.CreateCell(1);
                        Cell2.SetCellValue("TrackName");
                        Cell2.CellStyle = HeaderBorderedCellStyle;

                        ICell Cell3 = sheetRow1.CreateCell(2);
                        Cell3.SetCellValue("TrackSubName");
                        Cell3.CellStyle = HeaderBorderedCellStyle;

                        ICell Cell4 = sheetRow1.CreateCell(3);
                        Cell4.SetCellValue("Account");
                        Cell4.CellStyle = HeaderBorderedCellStyle;

                        ICell Cell5 = sheetRow1.CreateCell(4);
                        Cell5.SetCellValue("Rate");
                        Cell5.CellStyle = HeaderBorderedCellStyle;

                        ICell Cell6 = sheetRow1.CreateCell(5);
                        Cell6.SetCellValue("Description");
                        Cell6.CellStyle = HeaderBorderedCellStyle;

                        Sheetrowindex = 1;
                        ICreationHelper creationHelper = workBook.GetCreationHelper();
                        IDataFormat DataFormat = workBook.CreateDataFormat();


                        //Rate
                        //Description

                        for (int ContactRowindex = 1; ContactRowindex <= ExportDt.Rows.Count; ContactRowindex++)
                        {
                            CreateExport(ExportDt, borderedCellStyle, (ContactRowindex - 1),
                          ref Sheetrowindex, ref sheet1, creationHelper, DataFormat);

                        }


                        int lastColumNum = sheet1.GetRow(0).LastCellNum;
                        for (int i = 0; i <= lastColumNum; i++)
                        {
                            sheet1.AutoSizeColumn(i);
                            GC.Collect();
                        }

                        if (sheet1.PhysicalNumberOfRows > 0)
                        {
                            IRow headerRow = sheet1.GetRow(0);
                            //headerRow.Height =100;
                            for (int i = 0, l = headerRow.LastCellNum; i < l; i++)
                            {
                                sheet1.AutoSizeColumn(i);
                                GC.Collect();
                            }
                        }

                        //export to excel 
                        var fsd = new FileStream(confir.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                        workBook.Write(fsd);
                        workBook.Close();
                        fsd.Close();
                        MessageBox.Show("Export Successfully ", "Master Track Sub", MessageBoxButtons.OK, MessageBoxIcon.Information);




                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }

        }

        private object CreateExport(DataTable dt, ICellStyle borderedCellStyle2, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICreationHelper creationHelper, IDataFormat DataFormat)
        {

            try
            {
                var sheetRow = sheet.CreateRow(sheetRowIndex);
                int ColumnIndex = 0;


                sheetRow = sheet.CreateRow(sheetRowIndex);

                foreach (DataColumn header in dt.Columns)
                {



                    if (ColumnIndex == 0)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        ICell Cell4 = sheetRow.CreateCell(ColumnIndex);
                        Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell4.SetCellValue(Convert.ToString(columnvalue));

                        Cell4.CellStyle = borderedCellStyle2;
                    }

                    if (ColumnIndex == 1)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        ICell Cell4 = sheetRow.CreateCell(ColumnIndex);
                        Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell4.SetCellValue(Convert.ToString(columnvalue));

                        Cell4.CellStyle = borderedCellStyle2;
                    }

                    if (ColumnIndex == 2)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        ICell Cell4 = sheetRow.CreateCell(ColumnIndex);
                        Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell4.SetCellValue(Convert.ToString(columnvalue));

                        Cell4.CellStyle = borderedCellStyle2;
                    }

                    if (ColumnIndex == 3)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        ICell Cell4 = sheetRow.CreateCell(ColumnIndex);
                        Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell4.SetCellValue(Convert.ToString(columnvalue));

                        Cell4.CellStyle = borderedCellStyle2;
                    }


                    if (ColumnIndex == 4)
                    {
                        //string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        //ICell Cell4 = sheetRow.CreateCell(ColumnIndex);
                        //Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //Cell4.SetCellValue(Convert.ToString(columnvalue));

                        //Cell4.CellStyle = borderedCellStyle2;

                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        ICell Cell6 = sheetRow.CreateCell(ColumnIndex);

                        int value8;

                        if (int.TryParse(columnvalue, out value8))
                        {

                            Cell6.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                            int value5 = int.Parse(columnvalue);
                            Cell6.SetCellValue(value5);
                        }
                        else
                        {

                            Cell6.SetCellType(NPOI.SS.UserModel.CellType.String);

                            Cell6.CellStyle.DataFormat = HSSFDataFormat.GetBuiltinFormat("####.####");

                            //Cell6.SetCellValue(Convert.ToDouble(columnvalue));
                            Cell6.SetCellValue(columnvalue);

                            //NumberFormatInfo formatProvider = new NumberFormatInfo();
                            ////formatProvider.NumberDecimalSeparator = ", ";
                            //formatProvider.NumberGroupSeparator = ".";
                            //formatProvider.NumberGroupSizes = new int[] { 2 };
                            //formatProvider.NumberDecimalDigits = 2;


                            //double res = Convert.ToDouble(columnvalue, formatProvider);

                            //double value = Double.Parse(columnvalue,NumberStyles.Float);
                            //Cell6.SetCellValue(res);





                            //String val = "876876, 878";

                            //NumberFormatInfo formatProvider = new NumberFormatInfo();
                            //formatProvider.NumberDecimalSeparator = ", ";
                            //formatProvider.NumberGroupSeparator = ".";
                            //formatProvider.NumberGroupSizes = new int[] { 2 };
                            //double res = Convert.ToDouble(columnvalue, formatProvider);
                            //Cell6.SetCellValue(res);




                        }

                    }


                    if (ColumnIndex == 5)
                    {
                        string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        ICell Cell4 = sheetRow.CreateCell(ColumnIndex);
                        Cell4.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell4.SetCellValue(Convert.ToString(columnvalue));

                        Cell4.CellStyle = borderedCellStyle2;
                    }

                    ColumnIndex = ColumnIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
            return null;
        }

        private void btnExportTOexcel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {

                ExportToExcel();

                //frmConfirmation confir = new frmConfirmation(true);
                //confir.ShowDialog();
                //if (confir.Result == DialogResult.OK)
                //{

                //    Excel.Application excel = new Excel.Application();
                //    Excel.Workbook wBook = null;
                //    Excel.Worksheet wSheet = null;
                //    wBook = excel.Workbooks.Add();
                //    wSheet = (Excel.Worksheet)wBook.Sheets[1]; 
                //    System.Data.DataTable dt = new System.Data.DataTable();

                //    string sOrderByField = "";
                //    if (confir.Info == "Track Display Set")
                //        sOrderByField = "TrackSet";
                //    else if (confir.Info == "Track Name")
                //        sOrderByField = "TrackName";
                //    else
                //        sOrderByField = "TrackSubName";

                //    string sQuery = string.Format("SELECT TrackSet, TrackName, TrackSubName, Account, nRate as [Rate], Description FROM MasterTrackSubDisplay ORDER BY {0} ASC",sOrderByField);
                //    dt = StMethod.GetListDT<dtoMTSubItem>(sQuery);

                //    int colIndex = 0;
                //    int rowIndex = 0;
                //    foreach (System.Data.DataColumn dc in dt.Columns)
                //    {
                //        colIndex = colIndex + 1;
                //        excel.Cells[1, colIndex] = dc.ColumnName;
                //    }
                //    wSheet.Columns.Range["A1:H1"].Font.Bold = true;
                //    wSheet.Columns.Range["A1:H1"].Font.Color = Color.RoyalBlue;
                //    wSheet.Range["F1"].EntireColumn.WrapText = true;
                //    wSheet.Range["A1:F1"].EntireColumn.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Center;
                //    //wSheet.Range["A1:F1").EntireColumn.VerticalAlignment=
                //    wSheet.Range["E1"].EntireColumn.NumberFormat = "0.00";

                //    wSheet.Range["E1"].EntireColumn.HorizontalAlignment = System.Windows.Forms.HorizontalAlignment.Right;
                //    wSheet.Range["A1:F1"].EntireColumn.VerticalAlignment = Excel.XlVAlign.xlVAlignTop;
                //    wSheet.Range["F1"].ColumnWidth = 45;
                //    //wSheet.Range["A1:A1").Select()
                //    //wSheet.Range["A1:F1").Select()
                //    //excel.ActiveWindow.FreezePanes = True
                //    foreach (System.Data.DataRow dr in dt.Rows)
                //    {
                //        rowIndex = rowIndex + 1;
                //        colIndex = 0;
                //        foreach (System.Data.DataColumn dc in dt.Columns)
                //        {
                //            colIndex = colIndex + 1;
                //            excel.Cells[rowIndex + 1, colIndex] = dr[dc.ColumnName];
                //        }
                //    }

                //    wSheet.Columns.AutoFit();
                //    string strFileName = confir.FileName;
                //    bool blnFileOpen = false;
                //    try
                //    {
                //        System.IO.FileStream fileTemp = System.IO.File.OpenWrite(strFileName);
                //        fileTemp.Close();
                //    }
                //    catch (Exception ex)
                //    {
                //        blnFileOpen = false;
                //    }

                //    if (System.IO.File.Exists(strFileName))
                //    {
                //        System.IO.File.Delete(strFileName);
                //    }
                //    bool ROnly = false;
                //    //Dim Password As String = "vedataaccess"
                //    //wSheet.Protect(Password, , , , ROnly)
                //    wBook.SaveAs(strFileName);
                //    excel.Workbooks.Open(strFileName);
                //    excel.Visible = true;



                //}
                //else
                //{
                //    confir.Close();
                //}
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
        }

        private void btnVersionInsert_Click(System.Object sender, System.EventArgs e)
        {
            frmConfirmation confir = new frmConfirmation(false);
            confir.ShowDialog();
            if (confir.Result == DialogResult.OK)
            {
                string tableName = confir.txtInfo.Text;
                if (string.IsNullOrEmpty(confir.txtInfo.Text))
                {
                    MessageBox.Show("Please select enter table name.");
                    return;
                }
                //DataAccessLayer dll = new DataAccessLayer(); //check table name already exists or not
                string querySelectTableName = "Select TableVersionName From VersionTable where TableVersionName='" + tableName + "' ";
                //DataTable dtSelectTableName = new DataTable();

                //var data = StMethod.GetList<string>(querySelectTableName);

                var data = StMethod.GetList<string>(querySelectTableName);
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    data = StMethod.GetListNew<string>(querySelectTableName);

                }
                else
                {
                    data = StMethod.GetList<string>(querySelectTableName);
                }

                if (data.Count > 0)
                {
                    MessageBox.Show("table name already exists");
                }
                else
                {
                    string query = "INSERT INTO VersionTable(TableVersionName) VALUES ('" + confir.txtInfo.Text + "')";
                    ////SqlCommand cmd = new SqlCommand(query, Con); //Insert TableVersionName into data base
                    ////cmd.Parameters.AddWithValue("@TableVersionName", confir.txtInfo.Text);
                    ////Con.Open();


                    //Int32 i = StMethod.UpdateRecord(query);

                    Int32 i;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        i = StMethod.UpdateRecordNew(query);
                    }
                    else
                    {
                        i = StMethod.UpdateRecord(query);
                    }

                    ////Con.Close();
                    if (i == 1)
                    {
                        //MsgBox("Save Sucessfully")
                        //FillcmbVersion()
                        string querySelectTableID = "Select TableVersionId from  VersionTable where TableVersionName='" + confir.txtInfo.Text + "' ";
                        //DataTable dtSelectTableID = new DataTable(); //select TableVersionId into VersionTable


                        //var nTableVersionId = StMethod.GetSingleInt(querySelectTableID);

                        var nTableVersionId = StMethod.GetSingleInt(querySelectTableID);
                        nTableVersionId = 0;

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {

                            nTableVersionId = StMethod.GetSingleIntNew(querySelectTableID);
                        }
                        else
                        {
                            nTableVersionId = StMethod.GetSingleInt(querySelectTableID);
                        }

                        //DataAccessLayer dataHandler = new DataAccessLayer();
                        System.Data.DataTable dt = new System.Data.DataTable(); //select rate into MasterTrackSubDisplay
                        
                        
                        //dt = StMethod.GetListDT<MasterTrackSubData>("SELECT TrackSubName,nRate, Id, TrackSet, TrackName, Description, CalColor, Account FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)");



                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            dt = StMethod.GetListDTNew<MasterTrackSubData>("SELECT TrackSubName,nRate, Id, TrackSet, TrackName, Description, CalColor, Account FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)");




                        }
                        else
                        {
                            dt = StMethod.GetListDT<MasterTrackSubData>("SELECT TrackSubName,nRate, Id, TrackSet, TrackName, Description, CalColor, Account FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)");



                        }

                        if (dt.Rows.Count > 0) //insert into VersionDescription
                        {
                            try
                            {
                                for (int j = 0; j < dt.Rows.Count; j++)
                                {
                                    string query1 = "INSERT INTO VersionDescription(TableVersionId,MasterTrackSubItemId,Rate,Id, TrackSet, TrackName, Description, CalColor, Account,TrackSubName) VALUES (@TableVersionId, @MasterTrackSubItemId, @Rate,@Id, @TrackSet, @TrackName, @Description, @CalColor, @Account,@TrackSubName)";
                                    List<SqlParameter> param = new List<SqlParameter>();
                                    param.Add(new SqlParameter("@TableVersionId", nTableVersionId.ToString()));
                                    param.Add(new SqlParameter("@MasterTrackSubItemId", dt.Rows[j]["Id"]));
                                    param.Add(new SqlParameter("@Rate", dt.Rows[j]["nRate"]));
                                    param.Add(new SqlParameter("@TrackSet", dt.Rows[j]["TrackSet"]));
                                    param.Add(new SqlParameter("@TrackName", dt.Rows[j]["TrackName"]));
                                    param.Add(new SqlParameter("@Description", dt.Rows[j]["Description"]));
                                    param.Add(new SqlParameter("@CalColor", dt.Rows[j]["CalColor"]));
                                    param.Add(new SqlParameter("@Account", dt.Rows[j]["Account"]));
                                    param.Add(new SqlParameter("@Id", dt.Rows[j]["Id"]));
                                    param.Add(new SqlParameter("@TrackSubName", dt.Rows[j]["TrackSubName"]));

                                    //StMethod.UpdateRecord(query1, param);

                                    if (Properties.Settings.Default.IsTestDatabase == true)
                                    {
                                        StMethod.UpdateRecordNew(query1, param);
                                    }
                                    else
                                    {
                                        StMethod.UpdateRecord(query1, param);
                                    }
                                }
                                //'txtVersion.Text = String.Empty
                                // MsgBox("Insert & Copy Rate  Successfully")
                                MessageBox.Show("Insert New Table & Copy Rate  Successfully", "Insert New Rate Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                cmbSearchTableVersion.SelectedIndexChanged -= this.cmbSearchTableVersion_SelectedIndexChanged;
                                fillcmbTableVersionsearch();
                                cmbSearchTableVersion.SelectedIndexChanged += cmbSearchTableVersion_SelectedIndexChanged;
                            }
                            catch (Exception ex)
                            {

                            }
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter Version name first");
                confir.Close();
            }
        }

        private void btnCopyRate_Click(System.Object sender, System.EventArgs e)
        {
            if (cmbTableVersion.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select any version from Table Version");
                return;
            }
            DeleteFromVersionDescription();

            if (Properties.Settings.Default.IsTestDatabase == true)
            {

            
            }
            else
            {
            
            }

           



            /////
            ///
            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<MasterTrackSubData>("SELECT  TrackSubName,nRate, Id, TrackSet, TrackName, Description, CalColor, Account FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)").ToList();

                    if (data.Count > 0)
                    {
                        try
                        {
                            foreach (var item in data)
                            {
                                string query = "INSERT INTO VersionDescription(TableVersionId,MasterTrackSubItemId,Rate,Id, TrackSet, TrackName, Description, CalColor, Account,TrackSubName) VALUES (@TableVersionId, @MasterTrackSubItemId, @Rate,@Id, @TrackSet, @TrackName, @Description, @CalColor, @Account,@TrackSubName)";
                                SqlCommand cmd = new SqlCommand(query);
                                List<SqlParameter> param = new List<SqlParameter>();
                                param.Add(new SqlParameter("@TableVersionId", cmbTableVersion.SelectedValue));
                                param.Add(new SqlParameter("@MasterTrackSubItemId", item.Id));
                                param.Add(new SqlParameter("@Rate", item.nRate));
                                param.Add(new SqlParameter("@TrackSet", item.TrackSet));
                                param.Add(new SqlParameter("@TrackName", item.TrackName));
                                param.Add(new SqlParameter("@Description", item.Description));
                                param.Add(new SqlParameter("@CalColor", item.CalColor));
                                param.Add(new SqlParameter("@Account", item.Account));
                                param.Add(new SqlParameter("@Id", item.Id));
                                param.Add(new SqlParameter("@TrackSubName", item.TrackSubName));
                                db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());
                            }
                            MessageBox.Show("Insert Successfully");
                            cmbSearchTableVersion.SelectedIndexChanged -= this.cmbSearchTableVersion_SelectedIndexChanged;
                            fillcmbTableVersionsearch();
                            cmbSearchTableVersion.SelectedIndexChanged += cmbSearchTableVersion_SelectedIndexChanged;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<MasterTrackSubData>("SELECT  TrackSubName,nRate, Id, TrackSet, TrackName, Description, CalColor, Account FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)").ToList();

                    if (data.Count > 0)
                    {
                        try
                        {
                            foreach (var item in data)
                            {
                                string query = "INSERT INTO VersionDescription(TableVersionId,MasterTrackSubItemId,Rate,Id, TrackSet, TrackName, Description, CalColor, Account,TrackSubName) VALUES (@TableVersionId, @MasterTrackSubItemId, @Rate,@Id, @TrackSet, @TrackName, @Description, @CalColor, @Account,@TrackSubName)";
                                SqlCommand cmd = new SqlCommand(query);
                                List<SqlParameter> param = new List<SqlParameter>();
                                param.Add(new SqlParameter("@TableVersionId", cmbTableVersion.SelectedValue));
                                param.Add(new SqlParameter("@MasterTrackSubItemId", item.Id));
                                param.Add(new SqlParameter("@Rate", item.nRate));
                                param.Add(new SqlParameter("@TrackSet", item.TrackSet));
                                param.Add(new SqlParameter("@TrackName", item.TrackName));
                                param.Add(new SqlParameter("@Description", item.Description));
                                param.Add(new SqlParameter("@CalColor", item.CalColor));
                                param.Add(new SqlParameter("@Account", item.Account));
                                param.Add(new SqlParameter("@Id", item.Id));
                                param.Add(new SqlParameter("@TrackSubName", item.TrackSubName));
                                db.Database.ExecuteSqlCommand(cmd.CommandText, param.ToArray());
                            }
                            MessageBox.Show("Insert Successfully");
                            cmbSearchTableVersion.SelectedIndexChanged -= this.cmbSearchTableVersion_SelectedIndexChanged;
                            fillcmbTableVersionsearch();
                            cmbSearchTableVersion.SelectedIndexChanged += cmbSearchTableVersion_SelectedIndexChanged;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }

        }

        private void cmbSearchTableVersion_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            //cmbSearchTableVersion.SelectedIndexChanged -= this.cmbSearchTableVersion_SelectedIndexChanged;
            //try
            //{
            //    IsChangeTableVersionInvoice = Convert.ToInt32(cmbSearchTableVersion.SelectedValue) != 0;
            //    //if (Convert.ToInt32(cmbSearchTableVersion.SelectedValue) != 0)
            //    //    IsChangeTableVersionInvoice = true;
            //    //else
            //    //    IsChangeTableVersionInvoice = false;
            //    fillRateVersion();
            //}
            //catch (Exception ex)
            //{

            //}
            //cmbSearchTableVersion.SelectedIndexChanged += cmbSearchTableVersion_SelectedIndexChanged;


            //RemoveHandler cmbSearchTableVersion.SelectedIndexChanged, AddressOf Me.cmbSearchTableVersion_SelectedIndexChanged

            //cmbSearchTableVersion.SelectedIndexChanged -= this.cmbSearchTableVersion_SelectedIndexChanged;

            cmbSearchTableVersion.SelectedIndexChanged -= this.cmbSearchTableVersion_SelectedIndexChanged;
            
            try
            {
                if(chkShowAllRate.Checked)
                {
                    KryptonMessageBox.Show("You must have to unchecked the show all option!", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cmbSearchTableVersion.SelectedValue = 0;
                }
                else
                {
                    //If cmbSearchTableVersion.SelectedValue <> 0 Then
                    //' MessageBox.Show("Empty")
                    //IsChangeTableVersionInvoice = True
                    //Else
                    //    ' MessageBox.Show("not Empty")
                    //    IsChangeTableVersionInvoice = False

                    //End If


                    //if (cmbSearchTableVersion.SelectedValue != 0)
                    //{

                    //}
                    //else
                    //{


                    //}


                    IsChangeTableVersionInvoice = Convert.ToInt32(cmbSearchTableVersion.SelectedValue) != 0;
                    if (Convert.ToInt32(cmbSearchTableVersion.SelectedValue) != 0)
                    { 
                        IsChangeTableVersionInvoice = true;
                    }
                    else
                    { 
                        IsChangeTableVersionInvoice = false;
                    }
                    fillRateVersion();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            cmbSearchTableVersion.SelectedIndexChanged += cmbSearchTableVersion_SelectedIndexChanged;
        }




        private void btnDelete_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (cmbSearchTableVersion.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select table to delete.");
                    return;
                }
                if (cmbSearchTableVersion.SelectedIndex == 0)
                {
                    MessageBox.Show("Can't delete Template.");
                    return;
                }
                if (string.IsNullOrEmpty(cmbSearchTableVersion.Text))
                {
                    MessageBox.Show("Please select table to delete.");
                    return;
                }
                if (KryptonMessageBox.Show("Are you sure you want to delete this table? ", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Delete invoice table
                    try
                    {

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            
                            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            {
                                using (var dbTransaction = db.Database.BeginTransaction())
                                {
                                    try
                                    {
                                        db.Database.ExecuteSqlCommand("Delete from VersionDescription where TableVersionId = " + cmbSearchTableVersion.SelectedValue + "");
                                        db.Database.ExecuteSqlCommand("Delete from VersionTable where TableVersionId = " + cmbSearchTableVersion.SelectedValue + "");
                                        db.SaveChanges();
                                        dbTransaction.Commit();
                                    }
                                    catch (Exception ex1)
                                    {
                                        try
                                        {
                                            dbTransaction.Rollback();
                                        }
                                        catch (SqlException ex)
                                        {
                                        }
                                    }
                                }
                            }

                        }
                        else
                        {
                            using (EFDbContext db = new EFDbContext())
                            {
                                using (var dbTransaction = db.Database.BeginTransaction())
                                {
                                    try
                                    {
                                        db.Database.ExecuteSqlCommand("Delete from VersionDescription where TableVersionId = " + cmbSearchTableVersion.SelectedValue + "");
                                        db.Database.ExecuteSqlCommand("Delete from VersionTable where TableVersionId = " + cmbSearchTableVersion.SelectedValue + "");
                                        db.SaveChanges();
                                        dbTransaction.Commit();
                                    }
                                    catch (Exception ex1)
                                    {
                                        try
                                        {
                                            dbTransaction.Rollback();
                                        }
                                        catch (SqlException ex)
                                        {
                                        }
                                    }
                                }
                            }
                        }

                      



///
                    }
                    catch (Exception ex)
                    {
                    }
                    fillcmbTableVersionsearch();
                    IsChangeTableVersionInvoice = Convert.ToInt32(cmbSearchTableVersion.SelectedValue) != 0;
                    fillRateVersion();
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void btnClearSearch1_Click(System.Object sender, System.EventArgs e)
        {
            cmbTrackDispaySet1.SelectedIndex = -1;
            txtTrackName1.Text = string.Empty;
        }
        private void btnClearSearch_Click(System.Object sender, System.EventArgs e)
        {
            IsChangeTableVersionInvoice = false;
            cmbTrackDispaySet.SelectedIndex = -1;
            txtTrackName.Text = string.Empty;
            txtAccount.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtTrackSubName.Text = string.Empty;
        }
        private void cmbTrackDispaySet1_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            SetGridTracckColumn();
        }
        private void txtTrackName1_TextChanged(System.Object sender, System.EventArgs e)
        {
            SetGridTracckColumn();
        }
        private void cmbTrackDispaySet_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            SetTrackSubGridColumn();
        }
        private void txtTrackSubName_TextChanged(System.Object sender, System.EventArgs e)
        {
            SetTrackSubGridColumn();
        }
        private void txtDescription_TextChanged(System.Object sender, System.EventArgs e)
        {
            fillRateVersion();
        }
        private void txtTrackName_TextChanged(System.Object sender, System.EventArgs e)
        {
            SetTrackSubGridColumn();
        }
        private void txtAccount_TextChanged(System.Object sender, System.EventArgs e)
        {
            fillRateVersion();
        }
        private void txtTrackSubName_TextChanged_1(System.Object sender, System.EventArgs e)
        {
            fillRateVersion();
        }
        private void txtTrackName_TextChanged_1(System.Object sender, System.EventArgs e)
        {
            fillRateVersion();
        }
        private void grdTrackitem_CellFormatting(System.Object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            //if ((e.ColumnIndex == 3) && e.RowIndex > -1)
            //{

            //    DataAccessLayer dataHandler = new DataAccessLayer();
            //    Con = dataHandler.sqlcon;
            //    System.Data.DataTable dt2 = new System.Data.DataTable();
            //    // For i As Integer = 0 To grdTrackSubItem.RowCount - 1
            //    cmbTCTackName = new DataGridViewComboBoxCell();
            //    dt2 = dataHandler.Filldatatable("SELECT Id, TrackName FROM  MasterTrackSet WHERE (IsDelete=0 or IsDelete IS NULL) AND TrackSet='" + grdTrackSubItem.Rows["CmbTrackSet", e.RowIndex].Value.ToString().Trim() + "'");
            //    cmbTCTackName.DataSource = dt2;
            //    //cmbTCTackName.ValueMember = dt2.Columns["Id").ToString
            //    cmbTCTackName.DisplayMember = dt2.Columns["TrackName"].ToString();
            //    grdTrackSubItem(3, e.RowIndex) = cmbTCTackName;

            //    // Next
            //}
        }
        private void cmbTrackDispaySet_SelectedIndexChanged_1(System.Object sender, System.EventArgs e)
        {
            //SetTrackSubGridColumn()
            fillRateVersion();
        }
        #endregion

        #region Methods
        private void SetGridTracckColumn()
        {
            grdTrackitem.DataSource = null;
            string query = "SELECT Id, TrackSet, TrackName FROM  MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)";
            if (!string.IsNullOrEmpty(this.cmbTrackDispaySet1.Text))
            {
                query = query + " and TrackSet = '" + cmbTrackDispaySet1.Text + "'";
            }
            if (!string.IsNullOrEmpty(txtTrackName1.Text.Trim()))
            {
                query = query + "and  TrackName like '%" + txtTrackName1.Text + "%' ";
            }


            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<MasterTrackSetData>(query).ToList();
            //    grdTrackitem.DataSource = data;
            //}

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<MasterTrackSetData>(query).ToList();
                    grdTrackitem.DataSource = data;
                }

            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<MasterTrackSetData>(query).ToList();
                    grdTrackitem.DataSource = data;
                }
            }

            DataGridViewComboBoxColumn CmbTrackSet = new DataGridViewComboBoxColumn();
            //.DataSource = dataHandler.Filldatatable("SELECT distinct TrackSet  FROM MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)")
            //.DisplayMember = dt.Columns["TrackSet").ToString
            CmbTrackSet.DisplayIndex = 3;
            CmbTrackSet.DataPropertyName = "TrackSet";
            CmbTrackSet.HeaderText = "Track Display Set";
            CmbTrackSet.Width = 150;
            CmbTrackSet.Name = "CmbTrackSet";
            CmbTrackSet.Width = 220;
            CmbTrackSet.Items.Add("Notes/Communication");
            CmbTrackSet.Items.Add("Permits/Required/Inspection");
            CmbTrackSet.Items.Add("PreRequirements");
            grdTrackitem.Columns.Add(CmbTrackSet);
            grdTrackitem.Columns["Id"].Visible = false;
            grdTrackitem.Columns["TrackSet"].Visible = false;
            grdTrackitem.Columns["TrackName"].HeaderText = "Track Name";
        }
        private void FillTrackGrid()
        {
            string Query = "SELECT Id, TrackSet, TrackName FROM  MasterTrackSet WHERE (IsDelete=0 or IsDelete IS NULL)";
            if (!string.IsNullOrEmpty(CmbSearchTrack.Text))
            {
                Query = Query + " AND TrackSet like '" + CmbSearchTrack.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtSearchTrack.Text))
            {
                Query = Query + " AND TrackName like '" + txtSearchTrack.Text + "%'";
            }
            Query = Query + "GROUP BY Id, TrackSet, TrackName ORDER BY TrackSet";



            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<MasterTrackSetData>(Query).ToList();
            //    grdTrackitem.DataSource = data;
            //}

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<MasterTrackSetData>(Query).ToList();
                    grdTrackitem.DataSource = data;
                }

            }
            else
            {

                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<MasterTrackSetData>(Query).ToList();
                    grdTrackitem.DataSource = data;
                }
            }

            grdTrackitem.Columns["Id"].Visible = false;
            grdTrackitem.Columns["TrackSet"].Visible = false;
            grdTrackitem.Columns["TrackName"].HeaderText = "Track Name";
            grdTrackitem.Columns["TrackName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void UpdateInTrackInTrackSubItem()
        {
            try
            {
                string Query = "UPDATE MasterTrackSubItem SET TrackName=@TrackName WHERE TrackId=@TrackID ";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@TrackId", grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["Id"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@TrackName", grdTrackitem.Rows[grdTrackitem.CurrentRow.Index].Cells["TrackName"].Value.ToString().Trim()));

                //using (EFDbContext db = new EFDbContext())
                //{
                //    db.Database.ExecuteSqlCommand(Query, param.ToArray());
                //    StMethod.LoginActivityInfo(db, "Update", this.Text);
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        db.Database.ExecuteSqlCommand(Query, param.ToArray());
                        StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        db.Database.ExecuteSqlCommand(Query, param.ToArray());
                        StMethod.LoginActivityInfo(db, "Update", this.Text);
                    }
                }

                FillTrackSubGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed In TrackSub Item");
            }
            finally
            {
            }
        }
        private void FillCombo()
        {
            //dt = dataHandler.Filldatatable("SELECT distinct  TrackSet FROM  MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)");

            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<string>("SELECT distinct TrackSet FROM  MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)").ToList();
            //    CmbSearchTrack.DataSource = data;
            //    CmbSearchTrack.DisplayMember = "TrackSet";
            //    CmbSearchTrack.SelectedIndex = -1;
            //}


            
            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<string>("SELECT distinct TrackSet FROM  MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                    CmbSearchTrack.DataSource = data;
                    CmbSearchTrack.DisplayMember = "TrackSet";
                    CmbSearchTrack.SelectedIndex = -1;
                }
            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<string>("SELECT distinct TrackSet FROM  MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)").ToList();
                    CmbSearchTrack.DataSource = data;
                    CmbSearchTrack.DisplayMember = "TrackSet";
                    CmbSearchTrack.SelectedIndex = -1;
                }
            }

        }
        private void ClearData()
        {
            btnInsertTrack.Text = "Insert";
            txtSearchTrack.Text = string.Empty;
            txtTrackSub.Text = string.Empty;
            CmbSearchTrack.SelectedIndex = -1;
            SetGridTracckColumn();
            SetTrackSubGridColumn();
            FillTrackGrid();
            FillTrackSubGrid();
        }
        private void UpdateTableVersionInvoice()
        {
            string query = "UPDATE   VersionDescription SET  Rate =@Rate where VersionDescId=@VersionDescId and TableVersionId=@TableVersionId";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@Rate", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["Rate"].Value.ToString().Trim()));
            param.Add(new SqlParameter("@VersionDescId", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["VersionDescId"].Value.ToString().Trim()));
            param.Add(new SqlParameter("@TableVersionId", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TableVersionId"].Value.ToString().Trim()));
            
            //using (EFDbContext db = new EFDbContext())
            //{
            //    int i = db.Database.ExecuteSqlCommand(query, param.ToArray());
            //    if (i == 1)
            //    {
            //        KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //        StMethod.LoginActivityInfo(db, "Update", this.Text);
            //        grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
            //        grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
            //    }
            //}



            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    int i = db.Database.ExecuteSqlCommand(query, param.ToArray());
                    if (i == 1)
                    {
                        KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                        grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                        grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                    }
                }

            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    int i = db.Database.ExecuteSqlCommand(query, param.ToArray());
                    if (i == 1)
                    {
                        KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        StMethod.LoginActivityInfo(db, "Update", this.Text);
                        grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                        grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                    }
                }
            }
        }
        private void DeleteTableVersionInvoice()
        {
            try
            {
                string query = "DELETE FROM VersionDescription where VersionDescId=" + grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["VersionDescId"].Value.ToString().Trim() + "";


                //using (EFDbContext db = new EFDbContext())
                //{
                //    int i = db.Database.ExecuteSqlCommand(query);
                //    if (i == 1)
                //    {
                //        MessageBox.Show("Deleted Successfully");
                //        StMethod.LoginActivityInfo(db, "Delete", this.Text);
                //    }
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        int i = db.Database.ExecuteSqlCommand(query);
                        if (i == 1)
                        {
                            MessageBox.Show("Deleted Successfully");
                            StMethod.LoginActivityInfoNew(db, "Delete", this.Text);
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        int i = db.Database.ExecuteSqlCommand(query);
                        if (i == 1)
                        {
                            MessageBox.Show("Deleted Successfully");
                            StMethod.LoginActivityInfo(db, "Delete", this.Text);
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Deleted operation failed");
            }
            fillRateVersion();
        }
        private void DeletedJobTrackingTrackSub(int RowIndex)
        {
            string query = "UPDATE JobTracking SET TrackSub=@TrackSub  WHERE TrackSub=@TrackSubName";
            List<SqlParameter> param = new List<SqlParameter>();
            param.Add(new SqlParameter("@TrackSub", ""));
            param.Add(new SqlParameter("@TrackSubName", grdTrackSubItem.Rows[RowIndex].Cells["TrackSubName"].Value.ToString().Trim()));

            try
            {
                //using (EFDbContext db = new EFDbContext())
                //{
                //    db.Database.ExecuteSqlCommand(query, param.ToArray());
                //    StMethod.LoginActivityInfo(db, "Update", this.Text);
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        db.Database.ExecuteSqlCommand(query, param.ToArray());
                        StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        db.Database.ExecuteSqlCommand(query, param.ToArray());
                        StMethod.LoginActivityInfo(db, "Update", this.Text);
                    }
                }

            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
        }
        private void UpdateTrackSub()
        {
            int TrackNameID = 0;
            try
            {
                try
                {
                    if (Convert.ToInt16(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["ID"].Value.ToString()) == 0)
                    {
                        insertTrackSubItem();
                        return;
                    }
                    if (string.IsNullOrEmpty(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackSet"].Value.ToString().Trim()))
                    {
                        KryptonMessageBox.Show("Please select Trackset item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackName"].Value.ToString().Trim()))
                    {
                        KryptonMessageBox.Show("Please select Track Name item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackSubName"].Value.ToString().Trim()))
                    {
                        KryptonMessageBox.Show("Please select Track sub Name item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {

                }
                //Check Data Validation InTrackSub item
                try
                {

                    bool Find = false;
                    foreach (DataGridViewRow DR in grdTrackitem.Rows)
                    {
                        if (grdTrackitem.Rows[DR.Index].Cells["TrackName"].Value.ToString() == grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackName"].Value.ToString().Trim())
                        {
                            Find = true;
                            break;
                        }
                        else
                        {
                            Find = false;
                        }
                    }
                    if (Find == false)
                    {
                        KryptonMessageBox.Show("Enter Track Name is not valid", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {

                }
                string Query = "SELECT Id FROM MasterTrackSet WHERE TrackName='" + grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackName"].Value.ToString() + "'";

                //using (EFDbContext db = new EFDbContext())
                //{
                //    TrackNameID = db.Database.SqlQuery<int>(Query).FirstOrDefault();
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        TrackNameID = db.Database.SqlQuery<int>(Query).FirstOrDefault();
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        TrackNameID = db.Database.SqlQuery<int>(Query).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            //UPDATE mASTER TRACKSUB ITEM
            try
            {
                string query = "UPDATE MasterTrackSubItem SET Trackid=@TrackId,TrackName=@TrackName,TrackSubName=@TrackSubName,IsChange=@IsChange,ChangeDate=@ChangeDate,nRate=@nRate,Description=@Description,Account=@Account, CalColor =@CalColor WHERE id=@Id";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@TrackId", TrackNameID));
                param.Add(new SqlParameter("@TrackName", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackName"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@TrackSubName", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackSubName"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@nRate", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["nRate"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@Description", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["Description"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@IsChange", 1));
                param.Add(new SqlParameter("@ChangeDate", DateTime.Now.ToString("MM/dd/yyyy")));
                param.Add(new SqlParameter("@Id", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["Id"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@Account", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["Account"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@CalColor", grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["CalColor"].Value.ToString().Trim()));

                //using (EFDbContext db = new EFDbContext())
                //{
                //    int i = db.Database.ExecuteSqlCommand(query, param.ToArray());
                //    if (i == 1)
                //    {
                //        KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //        StMethod.LoginActivityInfo(db, "Update", this.Text);
                //        grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                //        grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                //        //lblDescriptionSize.Visible = False
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        int i = db.Database.ExecuteSqlCommand(query, param.ToArray());
                        if (i == 1)
                        {
                            KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            StMethod.LoginActivityInfoNew(db, "Update", this.Text);
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            //lblDescriptionSize.Visible = False
                        }
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        int i = db.Database.ExecuteSqlCommand(query, param.ToArray());
                        if (i == 1)
                        {
                            KryptonMessageBox.Show("Update Successfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            StMethod.LoginActivityInfo(db, "Update", this.Text);
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.BackColor = Color.White;
                            grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                            //lblDescriptionSize.Visible = False
                        }
                    }
                }

                //SetTrackSubGridColumn()
                //FillTrackSubGrid()
            }
            catch (Exception ex)
            {
            }
        }
        public void DeleteTrackSub()
        {
            try
            {
                string query = "UPDATE MasterTrackSubItem SET IsDelete=1 WHERE Id=" + grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["Id"].Value.ToString().Trim() + "";



                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        int i = db.Database.ExecuteSqlCommand(query);
                        if (i == 1)
                        {
                            MessageBox.Show("Deleted Successfully");
                            StMethod.LoginActivityInfoNew(db, "Delete", this.Text);
                            SetTrackSubGridColumn();
                            FillTrackSubGrid();
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        int i = db.Database.ExecuteSqlCommand(query);
                        if (i == 1)
                        {
                            MessageBox.Show("Deleted Successfully");
                            StMethod.LoginActivityInfo(db, "Delete", this.Text);
                            SetTrackSubGridColumn();
                            FillTrackSubGrid();
                        }
                    }
                }

                //using (EFDbContext db = new EFDbContext())
                //{
                //    int i = db.Database.ExecuteSqlCommand(query);
                //    if (i == 1)
                //    {
                //        MessageBox.Show("Deleted Successfully");
                //        StMethod.LoginActivityInfo(db, "Delete", this.Text);
                //        SetTrackSubGridColumn();
                //        FillTrackSubGrid();
                //    }
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Deleted operation failed");
            }
        }
        private void SetTrackSubGridColumn()
        {


          

            string query = "SELECT  TrackSet, TrackName, TrackSubName,nRate,Description,Account,CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)";
            if (!string.IsNullOrEmpty(cmbTrackDispaySet.Text))
            {
                query = query + " AND TrackSet like '%" + cmbTrackDispaySet.Text.ToString() + "%'";
            }
            if (!string.IsNullOrEmpty(txtTrackName.Text))
            {
                query = query + " AND TrackName like '%" + txtTrackName.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtTrackSubName.Text))
            {
                query = query + " AND TrackSubName like '%" + txtTrackSubName.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtDescription.Text))
            {
                query = query + " AND Description like '%" + txtDescription.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtAccount.Text))
            {
                query = query + " AND Account like '%" + txtAccount.Text + "%'";
            }
            grdTrackSubItem.DataSource = null;

            //grdTrackSubItem.DataSource = StMethod.GetListDT<MasterTrackSubData>(query);




            if (Properties.Settings.Default.IsTestDatabase == true)
            {

                grdTrackSubItem.DataSource = StMethod.GetListDTNew<MasterTrackSubData>(query);
            }
            else
            {
              grdTrackSubItem.DataSource = StMethod.GetListDT<MasterTrackSubData>(query);
            }

            DataGridViewComboBoxColumn CmbTCGrdDisplayeSet = new DataGridViewComboBoxColumn();
            {
                var withBlock1 = CmbTCGrdDisplayeSet;
                DataTable dtPM = new DataTable();

                var data = StMethod.GetListNew<M_TrackSetOnly>("SELECT distinct TrackSet FROM MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)");
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    data = StMethod.GetList<M_TrackSetOnly>("SELECT distinct TrackSet FROM MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)");

                }
                else
                {
                    data = StMethod.GetList<M_TrackSetOnly>("SELECT distinct TrackSet FROM MasterTrackSet Where (IsDelete=0 or IsDelete IS NULL)");
                }

                withBlock1.DataSource = data;
                withBlock1.DisplayMember = "TrackSet";
                withBlock1.DisplayIndex = 2;
                withBlock1.HeaderText = "Track Display Set";
                withBlock1.DataPropertyName = "TrackSet";
                withBlock1.Width = 220;
                withBlock1.Name = "CmbTrackSet";
            }
            grdTrackSubItem.Columns.Add(CmbTCGrdDisplayeSet);

            //With cmbCalColorad
            //    Dim colorType As Type = GetType(System.Drawing.Color)
            //    Dim propInfoList As PropertyInfo() = colorType.GetProperties(BindingFlags.[Static] Or BindingFlags.DeclaredOnly Or BindingFlags.[Public])
            //    For Each c As PropertyInfo In propInfoList
            //        Me.cmbCalColor.Items.Add(c.Name)
            //    Next
            //End With
            //DataGridViewComboBoxColumn CmbAccounts = new DataGridViewComboBoxColumn();

            DataGridViewComboBoxColumn CmbAccounts = new DataGridViewComboBoxColumn();
            {
                var withBlock1 = CmbAccounts;
                DataTable dtPM = new DataTable();

                //dtPM = StMethod.GetListDT<string>("SELECT Name as Account FROM TrackSubItemAccount");
                
                var data = StMethod.GetList<M_TrackSubAccountOnly>("SELECT Name as Account FROM TrackSubItemAccount");
                data = null;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    data = StMethod.GetListNew<M_TrackSubAccountOnly>("SELECT Name as Account FROM TrackSubItemAccount");

                }
                else
                {
                    data = StMethod.GetList<M_TrackSubAccountOnly>("SELECT Name as Account FROM TrackSubItemAccount");
                }
                withBlock1.DataSource = data;
                withBlock1.DisplayMember = "Account";
                withBlock1.DisplayIndex = 7;
                withBlock1.HeaderText = "Account";
                withBlock1.DataPropertyName = "Account";
                withBlock1.Width = 180;
                withBlock1.Name = "CmbAccounts";
            }
            grdTrackSubItem.Columns.Add(CmbAccounts);

            //.Columns.Add(CmbTrackName)            
            grdTrackSubItem.Columns["Id"].Visible = false;
            grdTrackSubItem.Columns["TrackSet"].Visible = false;
            grdTrackSubItem.Columns["Account"].Visible = false;
            grdTrackSubItem.Columns["TrackName"].Visible = true;
            grdTrackSubItem.Columns["TrackSubName"].HeaderText = "Track Sub Name";
            grdTrackSubItem.Columns["CalColor"].HeaderText = "Calendar Color";
            // .Columns["CalColor"].DisplayIndex = 7
            grdTrackSubItem.Columns["TrackSubName"].Width = 150;
            //.Columns["Rate"].Width = 90
            grdTrackSubItem.Columns["Description"].Width = 250;
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumne(string ColumnName)
        {
            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            try
            {
                column.DataPropertyName = ColumnName;
                column.HeaderText = ColumnName;
                column.Name = ColumnName;
                column.DropDownWidth = 160;
                column.Width = 90;
                column.MaxDropDownItems = 3;
                column.FlatStyle = FlatStyle.Flat;
            }
            catch (Exception)
            {
                throw;
            }
            return column;
        }
        private void SetComboBoxDataSource<T>(ref DataGridView grid, ref DataGridViewComboBoxColumn comboboxColumn, List<T> source, string ColumnName)
        {
            try
            {
                comboboxColumn.DataSource = new List<T>(source);
                //comboboxColumn.ValueMember = ColumnName;
                comboboxColumn.DisplayMember = ColumnName;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void FillTrackSubGrid()
        {
            string Query = "SELECT  TrackSet, TrackName, TrackSubName,nRate,Description,Account,CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)";
            if (!string.IsNullOrEmpty(CmbSearchTrack.Text))
            {
                Query = Query + " AND TrackSet like '" + CmbSearchTrack.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtSearchTrack.Text))
            {
                Query = Query + " AND TrackName like '" + txtSearchTrack.Text + "%'";
            }
            if (!string.IsNullOrEmpty(txtTrackSub.Text))
            {
                Query = Query + " AND TrackSubName like '" + txtTrackSub.Text + "%'";
            }
            Query = Query + " Group BY TrackSet, TrackName, TrackSubName,nRate,Description,Account,CalColor, Id Order by TrackSet,TrackName,TrackSubName";
            try
            {
                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                //    grdTrackSubItem.DataSource = data;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                        grdTrackSubItem.DataSource = data;
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                        grdTrackSubItem.DataSource = data;
                    }
                }

                grdTrackSubItem.Columns["Id"].Visible = false;
                grdTrackSubItem.Columns["TrackSet"].Visible = false;
                grdTrackSubItem.Columns["Account"].Visible = false;
                grdTrackSubItem.Columns["TrackName"].HeaderText = "Track Name";
                grdTrackSubItem.Columns["TrackSubName"].HeaderText = "Track Sub Name";
                //.Columns["TrackSubName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                grdTrackSubItem.Columns["TrackSubName"].Width = 150;
                grdTrackSubItem.Columns["nRate"].HeaderText = "Rate";
                grdTrackSubItem.Columns["nRate"].Width = 80;
                grdTrackSubItem.Columns["Description"].HeaderText = "Description";
                grdTrackSubItem.Columns["Description"].Width = 250;
                grdTrackSubItem.Columns["CalColor"].HeaderText = "Calendar Color";
                // .Columns["CalColor").DisplayIndex = 7

            }
            catch (Exception ex)
            {

            }
        }
        private void insertTrackSubItem()
        {
            int TrackNameID = 0;
            try
            {
                try
                {
                    if (string.IsNullOrEmpty(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackSet"].Value.ToString().Trim()))
                    {
                        KryptonMessageBox.Show("Please select Trackset item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackName"].Value.ToString().Trim()))
                    {
                        KryptonMessageBox.Show("Please select Track Name item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (string.IsNullOrEmpty(grdTrackSubItem.Rows[grdTrackSubItem.CurrentRow.Index].Cells["TrackSubName"].Value.ToString().Trim()))
                    {
                        KryptonMessageBox.Show("Please select Track sub Name item", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {

                }
                //Check Data Validation InTrackSub item
                try
                {
                    bool Find = false;
                    foreach (DataGridViewRow DR in grdTrackitem.Rows)
                    {
                        if (grdTrackitem.Rows[DR.Index].Cells["TrackName"].Value.ToString() == grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackName"].Value.ToString().Trim())
                        {
                            Find = true;
                            break;
                        }
                        else
                        {
                            Find = false;
                        }
                    }
                    if (Find == false)
                    {
                        KryptonMessageBox.Show("Entered Track Name is not valid", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                catch (Exception ex)
                {

                }
                //''''''''''
                string Query = "SELECT Id FROM MasterTrackSet WHERE TrackNAme='" + grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackName"].Value.ToString().Trim() + "'";


                //using (EFDbContext db = new EFDbContext())
                //{
                //    TrackNameID = db.Database.SqlQuery<int>(Query).FirstOrDefault();
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        TrackNameID = db.Database.SqlQuery<int>(Query).FirstOrDefault();
                    }


                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        TrackNameID = db.Database.SqlQuery<int>(Query).FirstOrDefault();
                    }

                }
            }
            catch (Exception ex)
            {
            }
            if (findDuplicateRecordInTrackSub() == false)
            {
                return;
            }
            //INSERT NEW VALUE IN MASTERTRACKSUBITEM TABLE
            try
            {
                string Query = "INSERT INTO  MasterTrackSubItem(TrackId,TrackName,TrackSubName,nRate,Description,Account, CalColor, IsNewRecord) VALUES(@TrackID,@Trackname,@TrackSubName,@nRate,@Description,@Account, @CalColor, @IsNewRecord) SELECT SCOPE_IDENTITY();";
                List<SqlParameter> param = new List<SqlParameter>();
                param.Add(new SqlParameter("@TrackId", TrackNameID));
                param.Add(new SqlParameter("@TrackName", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackName"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@TrackSubName", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackSubName"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@nRate", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["nRate"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@Description", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Description"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@Account", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Account"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@CalColor", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["CalColor"].Value.ToString().Trim()));
                param.Add(new SqlParameter("@IsNewRecord", 1));

                //using (EFDbContext db = new EFDbContext())
                //{
                //    int i = db.Database.ExecuteSqlCommand(Query, param.ToArray());
                //    if (i > 0)
                //    {
                //        btnInsert.Text = "Insert Track Sub Item";
                //        string querySelectTableID = "Select TableVersionId from VersionTable";
                //        var data = db.Database.SqlQuery<int>(querySelectTableID).ToList();
                //        if (data.Count > 0) //insert into VersionDescription
                //        {
                //            //'''''''''
                //            for (int j = 0; j < data.Count; j++)
                //            {
                //                string query1 = "INSERT INTO VersionDescription(TableVersionId,MasterTrackSubItemId,Rate,Id, TrackSet, TrackName, Description, CalColor, Account,TrackSubName) VALUES (@TableVersionId, @MasterTrackSubItemId, @Rate,@Id, @TrackSet, @TrackName, @Description, @CalColor, @Account,@TrackSubName)";
                //                SqlCommand cmd1 = new SqlCommand(query1);
                //                List<SqlParameter> param1 = new List<SqlParameter>();
                //                param1.Add(new SqlParameter("@TableVersionId", data[j].ToString()));
                //                param1.Add(new SqlParameter("@MasterTrackSubItemId", i));
                //                param1.Add(new SqlParameter("@Rate", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["nRate"].Value.ToString().Trim()));
                //                param1.Add(new SqlParameter("@TrackSet", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackSet"].Value.ToString().Trim()));
                //                param1.Add(new SqlParameter("@TrackName", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackName"].Value.ToString().Trim()));
                //                param1.Add(new SqlParameter("@Description", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Description"].Value.ToString().Trim()));
                //                param1.Add(new SqlParameter("@CalColor", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["CalColor"].Value.ToString().Trim()));
                //                param1.Add(new SqlParameter("@Account", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Account"].Value.ToString().Trim()));
                //                param1.Add(new SqlParameter("@Id", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Id"].Value.ToString().Trim()));
                //                param1.Add(new SqlParameter("@TrackSubName", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackSubName"].Value.ToString().Trim()));
                //                db.Database.ExecuteSqlCommand(cmd1.CommandText, param1.ToArray());
                //            }
                //        }
                //        KryptonMessageBox.Show("Save Sucessfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        StMethod.LoginActivityInfo(db, "Insert", this.Text);
                //        SetTrackSubGridColumn();
                //        FillTrackSubGrid();
                //    }
                //}







                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        int i = db.Database.ExecuteSqlCommand(Query, param.ToArray());
                        if (i > 0)
                        {
                            btnInsert.Text = "Insert Track Sub Item";
                            string querySelectTableID = "Select TableVersionId from VersionTable";
                            var data = db.Database.SqlQuery<int>(querySelectTableID).ToList();
                            if (data.Count > 0) //insert into VersionDescription
                            {
                                //'''''''''
                                for (int j = 0; j < data.Count; j++)
                                {
                                    string query1 = "INSERT INTO VersionDescription(TableVersionId,MasterTrackSubItemId,Rate,Id, TrackSet, TrackName, Description, CalColor, Account,TrackSubName) VALUES (@TableVersionId, @MasterTrackSubItemId, @Rate,@Id, @TrackSet, @TrackName, @Description, @CalColor, @Account,@TrackSubName)";
                                    SqlCommand cmd1 = new SqlCommand(query1);
                                    List<SqlParameter> param1 = new List<SqlParameter>();
                                    param1.Add(new SqlParameter("@TableVersionId", data[j].ToString()));
                                    param1.Add(new SqlParameter("@MasterTrackSubItemId", i));
                                    param1.Add(new SqlParameter("@Rate", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["nRate"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@TrackSet", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackSet"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@TrackName", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackName"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@Description", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Description"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@CalColor", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["CalColor"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@Account", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Account"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@Id", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Id"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@TrackSubName", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackSubName"].Value.ToString().Trim()));
                                    db.Database.ExecuteSqlCommand(cmd1.CommandText, param1.ToArray());
                                }
                            }
                            KryptonMessageBox.Show("Save Sucessfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StMethod.LoginActivityInfoNew(db, "Insert", this.Text);
                            SetTrackSubGridColumn();
                            FillTrackSubGrid();
                        }
                    }





                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        int i = db.Database.ExecuteSqlCommand(Query, param.ToArray());
                        if (i > 0)
                        {
                            btnInsert.Text = "Insert Track Sub Item";
                            string querySelectTableID = "Select TableVersionId from VersionTable";
                            var data = db.Database.SqlQuery<int>(querySelectTableID).ToList();
                            if (data.Count > 0) //insert into VersionDescription
                            {
                                //'''''''''
                                for (int j = 0; j < data.Count; j++)
                                {
                                    string query1 = "INSERT INTO VersionDescription(TableVersionId,MasterTrackSubItemId,Rate,Id, TrackSet, TrackName, Description, CalColor, Account,TrackSubName) VALUES (@TableVersionId, @MasterTrackSubItemId, @Rate,@Id, @TrackSet, @TrackName, @Description, @CalColor, @Account,@TrackSubName)";
                                    SqlCommand cmd1 = new SqlCommand(query1);
                                    List<SqlParameter> param1 = new List<SqlParameter>();
                                    param1.Add(new SqlParameter("@TableVersionId", data[j].ToString()));
                                    param1.Add(new SqlParameter("@MasterTrackSubItemId", i));
                                    param1.Add(new SqlParameter("@Rate", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["nRate"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@TrackSet", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackSet"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@TrackName", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackName"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@Description", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Description"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@CalColor", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["CalColor"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@Account", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Account"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@Id", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["Id"].Value.ToString().Trim()));
                                    param1.Add(new SqlParameter("@TrackSubName", grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells["TrackSubName"].Value.ToString().Trim()));
                                    db.Database.ExecuteSqlCommand(cmd1.CommandText, param1.ToArray());
                                }
                            }
                            KryptonMessageBox.Show("Save Sucessfully", "Master List Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StMethod.LoginActivityInfo(db, "Insert", this.Text);
                            SetTrackSubGridColumn();
                            FillTrackSubGrid();
                        }
                    }



                }

                //
            }
            catch (Exception ex)
            {
            }
        }
        private bool findDuplicateRecordInTrackSub()
        {
            try
            {
                const string Trackset = "cmbTrackSet";
                const string TrackName = "TrackName";
                const string TrackSubName = "TrackSubName";
                foreach (DataGridViewRow grdRow in grdTrackSubItem.Rows)
                {
                    if (grdRow.Index == grdTrackSubItem.Rows.Count - 1)
                    {
                        //Exit For
                        return true;
                    }
                    if (grdRow.Cells[Trackset].Value.ToString().Trim() == grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells[Trackset].Value.ToString().Trim() && grdRow.Cells[TrackName].Value.ToString().Trim() == grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells[TrackName].Value.ToString().Trim() && grdRow.Cells[TrackSubName].Value.ToString().Trim() == grdTrackSubItem.Rows[grdTrackSubItem.Rows.Count - 1].Cells[TrackSubName].Value.ToString().Trim())
                    {
                        if (KryptonMessageBox.Show("It seems you tried to enter duplicate record!. you want continue to save.", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }
        private void FillcmbVersion()
        {
            cmbTableVersion.DataSource = null;

            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<TableVersionData>("SELECT * FROM VersionTable").ToList();
            //    cmbTableVersion.DataSource = data;
            //}

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<TableVersionData>("SELECT * FROM VersionTable").ToList();
                    cmbTableVersion.DataSource = data;
                }

            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<TableVersionData>("SELECT * FROM VersionTable").ToList();
                    cmbTableVersion.DataSource = data;
                }
            }

            cmbTableVersion.DisplayMember = "TableVersionName";
            cmbTableVersion.ValueMember = "TableVersionId";
            // cmbTableVersion.SelectedIndex = -1
        }
        private void fillcmbTableVersionsearch()
        {
            cmbTableVersion.DataSource = null;

            //using (EFDbContext db = new EFDbContext())
            //{
            //    var data = db.Database.SqlQuery<TableVersionData>("select * from VersionTable union SELECT 0 as TableVersionId, 'Template' as TableVersionName order by TableVersionId").ToList();
            //    cmbSearchTableVersion.DataSource = data;
            //}

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    var data = db.Database.SqlQuery<TableVersionData>("select * from VersionTable union SELECT 0 as TableVersionId, 'Template' as TableVersionName order by TableVersionId").ToList();
                    cmbSearchTableVersion.DataSource = data;
                }

            }
            else
            {
                using (EFDbContext db = new EFDbContext())
                {
                    var data = db.Database.SqlQuery<TableVersionData>("select * from VersionTable union SELECT 0 as TableVersionId, 'Template' as TableVersionName order by TableVersionId").ToList();
                    cmbSearchTableVersion.DataSource = data;
                }

            }

            cmbSearchTableVersion.DisplayMember = "TableVersionName";
            cmbSearchTableVersion.ValueMember = "TableVersionId";
        }
        private void DeleteFromVersionDescription()
        {
            try
            {
                //using (EFDbContext db = new EFDbContext())
                //{
                //    db.Database.ExecuteSqlCommand("Delete from VersionDescription where TableVersionId = " + cmbTableVersion.SelectedValue + "");
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        db.Database.ExecuteSqlCommand("Delete from VersionDescription where TableVersionId = " + cmbTableVersion.SelectedValue + "");
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        db.Database.ExecuteSqlCommand("Delete from VersionDescription where TableVersionId = " + cmbTableVersion.SelectedValue + "");
                    }

                }
            }
            catch (Exception ex)
            {
            }
        }
        private void fillRateVersion()
        {
            //Dim dataHandler As New DataAccessLayer
            //Dim dt As New System.Data.DataTable
            //Dim Query As String
            //If cmbSearchTableVersion.SelectedValue = 0 And Not chkShowAllRate.Checked Then

            string Query = null;

            //if (cmbSearchTableVersion.SelectedValue == 0 & !chkShowAllRate.Checked)
            //{
            //}

            //if (cmbSearchTableVersion.SelectedValue == 0 & !chkShowAllRate.Checked)
            //{
            //}

            //if (Convert.ToInt32(cmbSearchTableVersion.SelectedValue) == 0)


            //If cmbSearchTableVersion.SelectedValue = 0 And Not chkShowAllRate.Checked Then

            if (Convert.ToInt32(cmbSearchTableVersion.SelectedValue) == 0 & !chkShowAllRate.Checked)
            {

                //Query = "SELECT  TrackSet, TrackName, TrackSubName,nRate,Description,Account,CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)"
                //If cmbTrackDispaySet.Text<> String.Empty Then
                //    Query = Query & " AND TrackSet like '%" & cmbTrackDispaySet.Text.ToString() & "%'"
                //End If
                //If txtTrackName.Text<> String.Empty Then
                //    Query = Query & " AND TrackName like '%" & txtTrackName.Text & "%'"
                //End If
                //If txtTrackSubName.Text<> String.Empty Then
                //    Query = Query & " AND TrackSubName like '%" & txtTrackSubName.Text & "%'"
                //End If
                //If txtDescription.Text<> String.Empty Then
                //    Query = Query & " AND Description like '%" & txtDescription.Text & "%'"
                //End If
                //If txtAccount.Text<> String.Empty Then
                //    Query = Query & " AND Account like '%" & txtAccount.Text & "%'"
                //End If

                //if (cmbTrackDispaySet.Text != string.Empty)


                //MessageBox.Show("1");

                Query = "SELECT  TrackSet, TrackName, TrackSubName,nRate,Description,Account,CalColor, Id FROM  MasterTrackSubDisplay Where (IsDelete=0 or IsDelete IS NULL)";
                if (!string.IsNullOrEmpty(cmbTrackDispaySet.Text))
                {                    
                    Query = Query + " AND TrackSet like '%" + cmbTrackDispaySet.Text.ToString() + "%'";
                }
                if (!string.IsNullOrEmpty(txtTrackName.Text))
                {
                    
                    Query = Query + " AND TrackName like '%" + txtTrackName.Text + "%'";
                }
                if (!string.IsNullOrEmpty(txtTrackSubName.Text))
                {
                    Query = Query + " AND TrackSubName like '%" + txtTrackSubName.Text + "%'";
                }
                if (!string.IsNullOrEmpty(txtDescription.Text))
                {
                    Query = Query + " AND Description like '%" + txtDescription.Text + "%'";
                }
                if (!string.IsNullOrEmpty(txtAccount.Text))
                {
                    Query = Query + " AND Account like '%" + txtAccount.Text + "%'";
                }

                //Query = Query + " Group BY TrackSet, TrackName, TrackSubName,nRate,Description,Account,CalColor, Id Order by TrackSet,TrackName,TrackSubName" & vbCr & " OPTION(RECOMPILE);"

                Query = Query + " Group BY TrackSet, TrackName, TrackSubName,nRate,Description,Account,CalColor, Id Order by TrackSet,TrackName,TrackSubName";
                try
                {
                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    var data = db.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                    //    grdTrackSubItem.DataSource = data;
                    //}


                    //grdTrackSubItem.DataSource = null;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                        {
                            var data = db2.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                            grdTrackSubItem.DataSource = data;
                        }
                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            var data = db.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                            grdTrackSubItem.DataSource = data;
                        }
                    }

                    // MessageBox.Show("2");
                    grdTrackSubItem.Columns["Id"].Visible = false;
                    grdTrackSubItem.Columns["TrackSet"].Visible = false;
                    grdTrackSubItem.Columns["Account"].Visible = false;
                    grdTrackSubItem.Columns["TrackName"].HeaderText = "Track Name";
                    grdTrackSubItem.Columns["TrackSubName"].HeaderText = "Track Sub Name";
                    //.Columns["TrackSubName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                    grdTrackSubItem.Columns["TrackSubName"].Width = 150;
                    grdTrackSubItem.Columns["nRate"].HeaderText = "Rate";
                    grdTrackSubItem.Columns["nRate"].Width = 80;
                    grdTrackSubItem.Columns["Description"].HeaderText = "Description";
                    grdTrackSubItem.Columns["Description"].Width = 250;
                    grdTrackSubItem.Columns["CalColor"].HeaderText = "Calendar Color";


                    grdTrackSubItem.Columns[0].Visible = true;
                    grdTrackSubItem.Columns["CalColor"].DisplayIndex = grdTrackSubItem.Columns.Count - 1;
                    grdTrackSubItem.Columns["CmbAccounts"].DisplayIndex = grdTrackSubItem.Columns.Count - 2;
                    grdTrackSubItem.Columns["Description"].DisplayIndex = grdTrackSubItem.Columns.Count - 3;

                    //.Columns(0).Visible = True
                    //.Columns("CalColor").DisplayIndex = .Columns.Count - 1
                    //.Columns("CmbAccounts").DisplayIndex = .Columns.Count - 2
                    //.Columns("Description").DisplayIndex = .Columns.Count - 3
                    // .Columns["CalColor").DisplayIndex = 7
                }


                //   dt = dataHandler.Filldatatable(Query)
                //grdTrackSubItem.DataSource = dt
                //With grdTrackSubItem
                //    .Columns("Id").Visible = False
                //    .Columns("TrackSet").Visible = False
                //    .Columns("Account").Visible = False
                //    .Columns("TrackName").HeaderText = "Track Name"
                //    .Columns("TrackSubName").HeaderText = "Track Sub Name"
                //    '.Columns("TrackSubName").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                //    .Columns("TrackSubName").Width = 150
                //    .Columns("nRate").HeaderText = "Rate"
                //    .Columns("nRate").Width = 80
                //    .Columns("nRate").DefaultCellStyle.Format = "c"
                //    .Columns("nRate").DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US")

                //    .Columns("Description").HeaderText = "Description"
                //    .Columns("Description").Width = 250
                //    .Columns("CalColor").HeaderText = "Calendar Color"

                //    .Columns(0).Visible = True
                //    .Columns("CalColor").DisplayIndex = .Columns.Count - 1
                //    .Columns("CmbAccounts").DisplayIndex = .Columns.Count - 2
                //    .Columns("Description").DisplayIndex = .Columns.Count - 3
                //End With

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            //else
            //ElseIf(Not chkShowAllRate.Checked) Then
            else if(!chkShowAllRate.Checked)
            {


                //MessageBox.Show("2");

                //Query = "SELECT  TrackSet, TrackName,TrackSubName, MasterTrackSubItemId,Rate,Description,Account,CalColor, Id,TableVersionId,VersionDescId FROM  VersionDescription  where TableVersionId=" + cmbSearchTableVersion.SelectedValue.ToString() + "";

                //Query = "SELECT  mi.TrackSet, mi.TrackName, mi.TrackSubName,vd.Rate as nRate,mi.Description,mi.Account,mi.CalColor, mi.Id,vd.MasterTrackSubItemId,vd.VersionDescId,vd.TableVersionId FROM  MasterTrackSubDisplay mi LEFT JOIN VersionDescription vd ON mi.Id=vd.MasterTrackSubItemId  Where (mi.IsDelete=0 or mi.IsDelete IS NULL) AND vd.TableVersionId=" + cmbSearchTableVersion.SelectedValue.ToString() + ""


                Query = "SELECT  mi.TrackSet, mi.TrackName, mi.TrackSubName,vd.Rate as nRate,mi.Description,mi.Account,mi.CalColor, mi.Id,vd.MasterTrackSubItemId,vd.VersionDescId,vd.TableVersionId FROM  MasterTrackSubDisplay mi LEFT JOIN VersionDescription vd ON mi.Id=vd.MasterTrackSubItemId  Where (mi.IsDelete=0 or mi.IsDelete IS NULL) AND vd.TableVersionId=" + cmbSearchTableVersion.SelectedValue.ToString() + "";

                //If cmbTrackDispaySet.Text<> String.Empty Then
                //    Query = Query & " AND mi.TrackSet like '%" & cmbTrackDispaySet.Text.ToString() & "%'"
                //End If

                //If txtTrackName.Text<> String.Empty Then
                //    Query = Query & " AND mi.TrackName like '%" & txtTrackName.Text & "%'"
                //End If

                if (!string.IsNullOrEmpty(cmbTrackDispaySet.Text))
                {
                    //Query = Query + " AND TrackSet like '%" + cmbTrackDispaySet.Text.ToString() + "%'";
                    Query = Query + " AND mi.TrackSet like '%" + cmbTrackDispaySet.Text.ToString() + "%'";
                }


                if (!string.IsNullOrEmpty(txtTrackName.Text))
                {
                    //Query = Query + " AND TrackName like '%" + txtTrackName.Text + "%'";
                    Query = Query + " AND mi.TrackName like '%" + txtTrackName.Text + "%'";
                }

                //If txtTrackSubName.Text<> String.Empty Then
                //    Query = Query & " AND mi.TrackSubName like '%" & txtTrackSubName.Text & "%'"
                //End If

                if (!string.IsNullOrEmpty(txtTrackSubName.Text))
                {
                    //Query = Query + " AND TrackSubName like '%" + txtTrackSubName.Text + "%'";
                    Query = Query + " AND mi.TrackSubName like '%" + txtTrackSubName.Text + "%'";
                }

             //   If txtDescription.Text<> String.Empty Then
             //    Query = Query & " AND mi.Description like '%" & txtDescription.Text & "%'"
             //End If

                if (!string.IsNullOrEmpty(txtDescription.Text))
                {
                    //Query = Query + " AND Description like '%" + txtDescription.Text + "%'";
                    Query = Query + " AND mi.Description like '%" + txtDescription.Text + "%'";
                }


                //If txtAccount.Text<> String.Empty Then
                //    Query = Query & " AND mi.Account like '%" & txtAccount.Text & "%'"
                //End If

                if (!string.IsNullOrEmpty(txtAccount.Text))
                {
                    Query = Query + " AND mi.Account like '%" + txtAccount.Text + "%'";
                }


                //Query = Query + " Group BY mi.TrackSet, mi.TrackName,mi.TrackSubName, vd.MasterTrackSubItemId,vd.Rate,mi.Description,mi.Account,mi.CalColor, mi.Id,vd.TableVersionId,vd.VersionDescId Order by mi.TrackSet,mi.TrackName,mi.TrackSubName" & vbCr & " OPTION(RECOMPILE);"

                Query = Query + " Group BY mi.TrackSet, mi.TrackName,mi.TrackSubName, vd.MasterTrackSubItemId,vd.Rate,mi.Description,mi.Account,mi.CalColor, mi.Id,vd.TableVersionId,vd.VersionDescId Order by mi.TrackSet,mi.TrackName,mi.TrackSubName";

                //Query = Query + " Group BY TrackSet, TrackName,TrackSubName, MasterTrackSubItemId,Rate,Description,Account,CalColor, Id,TableVersionId,VersionDescId Order by TrackSet,TrackName,TrackSubName";

                //MessageBox.Show("3");

                try
                {



                   





                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            //var data = db.Database.SqlQuery<VersionDescData>(Query).ToList();
                            var data = db.Database.SqlQuery<VersionDescDataEdit>(Query).ToList();


                            //Clipboard.SetText(Query);

                            //MessageBox.Show("4");

                            if (data.Count > 0)
                            {

                                //MessageBox.Show("5");

                                grdTrackSubItem.DataSource = null;
                                grdTrackSubItem.DataSource = data;
                                grdTrackSubItem.Columns["Id"].Visible = false;
                                grdTrackSubItem.Columns["TrackSet"].Visible = false;
                                grdTrackSubItem.Columns["Account"].Visible = false;
                                grdTrackSubItem.Columns["TrackName"].HeaderText = "Track Name";
                                grdTrackSubItem.Columns["TrackSubName"].HeaderText = "Track Sub Name";
                                grdTrackSubItem.Columns["TrackSubName"].Width = 150;
                                grdTrackSubItem.Columns["Rate"].Width = 90;
                                grdTrackSubItem.Columns["Rate"].HeaderText = cmbSearchTableVersion.Text.ToString();
                                grdTrackSubItem.Columns["Description"].HeaderText = "Description";
                                grdTrackSubItem.Columns["Description"].Width = 250;
                                grdTrackSubItem.Columns["CalColor"].HeaderText = "Calendar Color";
                                grdTrackSubItem.Columns["MasterTrackSubItemId"].Visible = false;
                                grdTrackSubItem.Columns["TableVersionId"].Visible = false;
                                grdTrackSubItem.Columns["VersionDescId"].Visible = false;

                                grdTrackSubItem.Columns[0].Visible = true;
                                grdTrackSubItem.Columns["CalColor"].DisplayIndex = grdTrackSubItem.Columns.Count - 1;
                                grdTrackSubItem.Columns["CmbAccounts"].DisplayIndex = grdTrackSubItem.Columns.Count - 2;
                                grdTrackSubItem.Columns["Description"].DisplayIndex = grdTrackSubItem.Columns.Count - 3;
                            }


                            //    If dt.Rows.Count > 0 Then
                            //    grdTrackSubItem.DataSource = dt
                            //    With grdTrackSubItem
                            //        .Columns("Id").Visible = False
                            //        .Columns("TrackSet").Visible = False
                            //        .Columns("Account").Visible = False
                            //        .Columns("TrackName").HeaderText = "Track Name"
                            //        .Columns("TrackSubName").HeaderText = "Track Sub Name"
                            //        .Columns("TrackSubName").Width = 150
                            //        .Columns("nRate").Width = 90
                            //        .Columns("nRate").HeaderText = cmbSearchTableVersion.Text.ToString()
                            //        .Columns("nRate").DefaultCellStyle.Format = "c"
                            //        .Columns("nRate").DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US")

                            //        .Columns("Description").HeaderText = "Description"
                            //        .Columns("Description").Width = 250
                            //        .Columns("CalColor").HeaderText = "Calendar Color"
                            //        .Columns("MasterTrackSubItemId").Visible = False
                            //        .Columns("TableVersionId").Visible = False
                            //        .Columns("VersionDescId").Visible = False

                            //        .Columns(0).Visible = True
                            //        .Columns("CalColor").DisplayIndex = .Columns.Count - 1
                            //        .Columns("CmbAccounts").DisplayIndex = .Columns.Count - 2
                            //        .Columns("Description").DisplayIndex = .Columns.Count - 3
                            //End With

                            //End If

                        }


                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            //var data = db.Database.SqlQuery<VersionDescData>(Query).ToList();
                            var data = db.Database.SqlQuery<VersionDescDataEdit>(Query).ToList();

                            //MessageBox.Show("4");

                            if (data.Count > 0)
                            {

                                //MessageBox.Show("5");

                                grdTrackSubItem.DataSource = data;
                                grdTrackSubItem.Columns["Id"].Visible = false;
                                grdTrackSubItem.Columns["TrackSet"].Visible = false;
                                grdTrackSubItem.Columns["Account"].Visible = false;
                                grdTrackSubItem.Columns["TrackName"].HeaderText = "Track Name";
                                grdTrackSubItem.Columns["TrackSubName"].HeaderText = "Track Sub Name";
                                grdTrackSubItem.Columns["TrackSubName"].Width = 150;
                                grdTrackSubItem.Columns["Rate"].Width = 90;
                                grdTrackSubItem.Columns["Rate"].HeaderText = cmbSearchTableVersion.Text.ToString();
                                grdTrackSubItem.Columns["Description"].HeaderText = "Description";
                                grdTrackSubItem.Columns["Description"].Width = 250;
                                grdTrackSubItem.Columns["CalColor"].HeaderText = "Calendar Color";
                                grdTrackSubItem.Columns["MasterTrackSubItemId"].Visible = false;
                                grdTrackSubItem.Columns["TableVersionId"].Visible = false;
                                grdTrackSubItem.Columns["VersionDescId"].Visible = false;

                                grdTrackSubItem.Columns[0].Visible = true;
                                grdTrackSubItem.Columns["CalColor"].DisplayIndex = grdTrackSubItem.Columns.Count - 1;
                                grdTrackSubItem.Columns["CmbAccounts"].DisplayIndex = grdTrackSubItem.Columns.Count - 2;
                                grdTrackSubItem.Columns["Description"].DisplayIndex = grdTrackSubItem.Columns.Count - 3;
                            }


                            //    If dt.Rows.Count > 0 Then
                            //    grdTrackSubItem.DataSource = dt
                            //    With grdTrackSubItem
                            //        .Columns("Id").Visible = False
                            //        .Columns("TrackSet").Visible = False
                            //        .Columns("Account").Visible = False
                            //        .Columns("TrackName").HeaderText = "Track Name"
                            //        .Columns("TrackSubName").HeaderText = "Track Sub Name"
                            //        .Columns("TrackSubName").Width = 150
                            //        .Columns("nRate").Width = 90
                            //        .Columns("nRate").HeaderText = cmbSearchTableVersion.Text.ToString()
                            //        .Columns("nRate").DefaultCellStyle.Format = "c"
                            //        .Columns("nRate").DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US")

                            //        .Columns("Description").HeaderText = "Description"
                            //        .Columns("Description").Width = 250
                            //        .Columns("CalColor").HeaderText = "Calendar Color"
                            //        .Columns("MasterTrackSubItemId").Visible = False
                            //        .Columns("TableVersionId").Visible = False
                            //        .Columns("VersionDescId").Visible = False

                            //        .Columns(0).Visible = True
                            //        .Columns("CalColor").DisplayIndex = .Columns.Count - 1
                            //        .Columns("CmbAccounts").DisplayIndex = .Columns.Count - 2
                            //        .Columns("Description").DisplayIndex = .Columns.Count - 3
                            //End With

                            //End If

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

            else
            {
                //MessageBox.Show("3");
                ShowAllRate();
            }
        }


        private void ShowAllRate()
        {
            try
            {
                //Dim dataHandler As New DataAccessLayer
                //Dim dt As New System.Data.DataTable
                //Dim Query As String, colQuery As String = "", whereQuery As String = "", grpQuery As String = ""
                //string Query, colQuery As String = "", whereQuery As String = "", grpQuery As String = "";
                string Query;
                string colQuery = "";
                string whereQuery = "";
                string grpQuery = "";

                DataTable dt;
               

                RateColQuery(colQuery, whereQuery, grpQuery);

                Query = "SELECT  mi.TrackSet, mi.TrackName, mi.TrackSubName," + colQuery + "mi.Description,mi.Account,mi.CalColor, mi.Id FROM  MasterTrackSubDisplay mi " + whereQuery + "   Where (mi.IsDelete=0 or mi.IsDelete IS NULL) ";


                //If cmbTrackDispaySet.Text<> String.Empty Then
                //    Query = Query & " AND mi.TrackSet like '%" & cmbTrackDispaySet.Text.ToString() & "%'"
                //End If
                //If txtTrackName.Text<> String.Empty Then
                //    Query = Query & " AND mi.TrackName like '%" & txtTrackName.Text & "%'"
                //End If
                //If txtTrackSubName.Text<> String.Empty Then
                //    Query = Query & " AND mi.TrackSubName like '%" & txtTrackSubName.Text & "%'"
                //End If
                //If txtDescription.Text<> String.Empty Then
                //    Query = Query & " AND mi.Description like '%" & txtDescription.Text & "%'"
                //End If
                //If txtAccount.Text<> String.Empty Then
                //    Query = Query & " AND mi.Account like '%" & txtAccount.Text & "%'"
                //End If

                if (!string.IsNullOrEmpty(cmbTrackDispaySet.Text))
                {
                    Query = Query + " AND mi.TrackSet like '%" + cmbTrackDispaySet.Text.ToString() + "%'";
                }

                if (!string.IsNullOrEmpty(txtTrackName.Text))
                {
                    Query = Query + " AND mi.TrackName like '%" + txtTrackName.Text + "%'";
                }

                if (!string.IsNullOrEmpty(txtTrackSubName.Text))
                {
                    Query = Query + " AND mi.TrackSubName like '%" + txtTrackSubName.Text + "%'";
                }

                if (!string.IsNullOrEmpty(txtDescription.Text))
                {
                    Query = Query + " AND mi.Description like '%" + txtDescription.Text + "%'";
                }


                if (!string.IsNullOrEmpty(txtAccount.Text))
                {
                    Query = Query + " AND mi.Account like '%" + txtAccount.Text + "%'";
                }

                Query = Query + " Group BY mi.TrackSet, mi.TrackName,mi.TrackSubName," + grpQuery + "mi.Description,mi.Account,mi.CalColor, mi.Id Order by mi.TrackSet,mi.TrackName,mi.TrackSubName";

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                //    grdTrackSubItem.DataSource = data;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                        grdTrackSubItem.DataSource = data;
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<MasterTrackSubData>(Query).ToList();
                        grdTrackSubItem.DataSource = data;
                    }
                }

                grdTrackSubItem.Columns["Id"].Visible = false;
                grdTrackSubItem.Columns["TrackSet"].Visible = false;
                grdTrackSubItem.Columns["Account"].Visible = false;
                grdTrackSubItem.Columns["TrackName"].HeaderText = "Track Name";
                grdTrackSubItem.Columns["TrackSubName"].HeaderText = "Track Sub Name";
                //.Columns["TrackSubName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
                grdTrackSubItem.Columns["TrackSubName"].Width = 150;
                grdTrackSubItem.Columns["nRate"].HeaderText = "Rate";
                grdTrackSubItem.Columns["nRate"].Width = 80;
                grdTrackSubItem.Columns["Description"].HeaderText = "Description";
                grdTrackSubItem.Columns["Description"].Width = 250;
                grdTrackSubItem.Columns["CalColor"].HeaderText = "Calendar Color";


                grdTrackSubItem.Columns[0].Visible = true;
                grdTrackSubItem.Columns["CalColor"].DisplayIndex = grdTrackSubItem.Columns.Count - 1;
                grdTrackSubItem.Columns["CmbAccounts"].DisplayIndex = grdTrackSubItem.Columns.Count - 2;
                grdTrackSubItem.Columns["Description"].DisplayIndex = grdTrackSubItem.Columns.Count - 3;

                //Dim vDT As DataTable = dataHandler.Filldatatable("SELECT  TableVersionName FROM  VersionTable")

                string query2 = "SELECT  TableVersionName FROM  VersionTable";
                //DataTable vDT ;

                //DataTable vDT = StMethod.GetListDT<TableVersionData>(query2);

                DataTable vDT;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    vDT = StMethod.GetListDTNew<TableVersionData>(query2);
                }
                else
                {
                    vDT = StMethod.GetListDT<TableVersionData>(query2);
                }

                foreach (DataRow dr in vDT.Rows)
                {
                    //grdTrackSubItem.Columns(dr("TableVersionName").ToString()).DefaultCellStyle.Format = "c"

                    //grdTrackSubItem.Columns(dr("TableVersionName").ToString()).DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US")
                }

                 //.Columns("Rate").DefaultCellStyle.Format = "c"
                 //.Columns("Rate").DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("en-US")
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        
        
        private void RateColQuery(string colQuery,string whereQuery,string grpQuery)
        {
            try 
            {
                //Dim vDT As DataTable = DAL.Filldatatable("SELECT  TableVersionId ,TableVersionName FROM  VersionTable")

                string Query = "SELECT  TableVersionId ,TableVersionName FROM  VersionTable";

                //string Query = "select TableVersionId from VersionTable where TableVersionName = '" + value.ToString() + "'";

                //DataTable dtTableVersion = StMethod.GetListDT<TableVersionData>(Query);

                DataTable dtTableVersion;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dtTableVersion = StMethod.GetListDTNew<TableVersionData>(Query);
                }
                else
                {
                    dtTableVersion = StMethod.GetListDT<TableVersionData>(Query);
                }

                int count = 1;

                foreach (DataRow dr in dtTableVersion.Rows)
                {
                    colQuery = colQuery + String.Format("{0}.Rate AS [{1}],", "vd" + count, dr["TableVersionName"]);

                    grpQuery = grpQuery + String.Format("{0}.Rate,", "vd" + count);

                    whereQuery = whereQuery + String.Format(" LEFT JOIN VersionDescription {0} ON mi.Id={0}.MasterTrackSubItemId AND {0}.TableVersionId={1} ", "vd" + count, dr["TableVersionId"]);

                    count = count + 1;
                }

                colQuery = "mi.nRate as Rate," + colQuery;
                grpQuery = "mi.nRate," + grpQuery;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }
        }


            private void ClearMasterSubTrack()
        {
            fillcmbTableVersionsearch();
            IsChangeTableVersionInvoice = false;
            cmbSearchTableVersion.SelectedIndex = 0;
            cmbTrackDispaySet.SelectedIndex = -1;
            txtTrackName.Text = string.Empty;
            txtAccount.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtTrackSubName.Text = string.Empty;
            SetGridTracckColumn();
            SetTrackSubGridColumn();
            FillTrackGrid();
            FillTrackSubGrid();
            fillRateVersion();
        }
        #endregion
        private void tbMasterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsSubTrackLoadComplete)
            {
                SetTrackSubGridColumn();
                FillTrackSubGrid();
            }
        }

        private void chkShowAllRate_CheckedChanged(object sender, EventArgs e)
        {
    
            try
            {


                //If(chkShowAllRate.Checked) Then
                //    RemoveHandler cmbSearchTableVersion.SelectedIndexChanged, AddressOf Me.cmbSearchTableVersion_SelectedIndexChanged
                //    cmbSearchTableVersion.SelectedValue = 0
                //    btnCancel_Click(sender, e)
                //    AddHandler cmbSearchTableVersion.SelectedIndexChanged, AddressOf Me.cmbSearchTableVersion_SelectedIndexChanged
                //Else
                //    fillRateVersion()
                //End If
                //btnInsert.Enabled = Not chkShowAllRate.Checked
                //btnVersionInsert.Enabled = Not chkShowAllRate.Checked


                //if (chkShowAllRate.Checked)
                               

                if (chkShowAllRate.Checked)
                {

                    //this.txtSearchTrack.TextChanged -= new System.EventHandler(this.txtSearchTrack_TextChanged);
                    //MyEvent -= eventHandler;

                    //EventHandler C = new EventHandler(cmbSearchTableVersion_SelectedIndexChanged);




                    //cmbSearchTableVersion.SelectedIndexChanged -= new System.EventHandler(this.cmbSearchTableVersion_SelectedIndexChanged);
                    //cmbSearchTableVersion.SelectedValue = 0;
                    //btnCancel_Click(sender, e);
                    //cmbSearchTableVersion.SelectedIndexChanged += new System.EventHandler(this.cmbSearchTableVersion_SelectedIndexChanged);


                    //MessageBox.Show("1");

                    cmbSearchTableVersion.SelectedIndexChanged -= this.cmbSearchTableVersion_SelectedIndexChanged;
                    cmbSearchTableVersion.SelectedValue = 0;
                    btnCancel_Click(sender, e);
                    cmbSearchTableVersion.SelectedIndexChanged += this.cmbSearchTableVersion_SelectedIndexChanged;

                    //RemoveHandler cmbSearchTableVersion.SelectedIndexChanged, AddressOf Me.cmbSearchTableVersion_SelectedIndexChanged
                    //cmbSearchTableVersion.SelectedValue = 0
                    //btnCancel_Click(sender, e)
                    //AddHandler cmbSearchTableVersion.SelectedIndexChanged, AddressOf Me.cmbSearchTableVersion_SelectedIndexChanged


                }
                else
                {
                    //MessageBox.Show("2");
                    fillRateVersion();
                }


                    
                btnInsert.Enabled = !chkShowAllRate.Checked;
                btnVersionInsert.Enabled = !chkShowAllRate.Checked;


                //btnInsert.Enabled = Not chkShowAllRate.Checked
                //btnVersionInsert.Enabled = Not chkShowAllRate.Checked

                //btnInsert.Enabled = !chkShowAllRate.Checked;
                //btnVersionInsert.Enabled = !chkShowAllRate.Checked;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }


        }

        private void grdTrackSubItem_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
             
            catch (Exception ex)
            {

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfirmation confir = new frmConfirmation(false);
                confir.ShowDialog();


                if (confir.Result == DialogResult.OK)
                {

                    //Dim tableName As String = confir.txtInfo.Text
                    //If String.IsNullOrEmpty(confir.txtInfo.Text) Then
                    //    MessageBox.Show("Please select enter Rate version name.")
                    //    Return
                    //End If

                    String tableName = confir.txtInfo.Text;

                    if(string.IsNullOrEmpty(confir.txtInfo.Text))
                    {

                        MessageBox.Show("Please select enter Rate version name.");
                        return;
                    }

                    //Dim dll As New DataAccessLayer 'check table name already exists or not
                    //Dim querySelectTableName As String = "Select TableVersionName From VersionTable where TableVersionName='" + tableName + "' "
                    //Dim dtSelectTableName As New DataTable
                    //dtSelectTableName = dll.Filldatatable(querySelectTableName)


                    String querySelectTableName = "Select TableVersionName From VersionTable where TableVersionName='" + tableName + "' ";
                    DataTable dtSelectTableName = new DataTable();




                }


            }
            catch (Exception ex)
            {

            }
        }
    }
}