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

namespace JobTracker.JobTrackingForm
{
    public partial class frmCraneInfo : Form
    {
        #region GlobalVariable
        private string CheckString;
        private string CraneID;
        private string OldCraneID;
        string Colorstr = null;

        #endregion

        #region Properties
        public string ColoChange
        {
            get
            {
                return Colorstr;
            }
            set
            {
                Colorstr = value;
            }
        }

        public string CraneOldID
        {
            get
            {
                return OldCraneID;
            }
            set
            {
                OldCraneID = value;
            }
        }

        public string SelectCDID
        {
            get
            {
                return CraneID;
            }
            set
            {
                CraneID = value;
            }
        }
        #endregion

        #region Events
        public frmCraneInfo()
        {
            InitializeComponent();
        }

        private void frmCraneInfo_Load(System.Object sender, System.EventArgs e)
        {
          

            FillCraneGrid();
            CommunityBoardFromInfo();

            

        }

        private void txtCapacity_TextChanged(System.Object sender, System.EventArgs e)
        {
            FillCraneGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSave.Text == "Insert")
                {
                    for (Int32 i = 0; i < grdCDcrane.Rows.Count; i++)
                    {
                        if (grdCDcrane.Rows[i].DefaultCellStyle.BackColor == Color.Pink)
                        {
                            KryptonMessageBox.Show("you can't insert new record first Update and then insert", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    btnSave.Text = "Save";

                    //DataTable CraneDT = Program.ToDataTable<CDInfoContact>((List<CDInfoContact>)grdCDcrane.DataSource);

                    DataTable CraneDT = Program.ToDataTable<CDInfoContactNew>((List<CDInfoContactNew>)grdCDcrane.DataSource);


                    DataRow datarow = CraneDT.NewRow();


                    //grdCDcrane.Columns["CDNumber"].HeaderText = "CD Number";
                    //grdCDcrane.Columns["CraneID"].HeaderText = "Crane ID";
                    //grdCDcrane.Columns["CraneName"].HeaderText = "Crane Name";
                    //grdCDcrane.Columns["EquipmentType"].HeaderText = "Equipment Type";
                    //grdCDcrane.Columns["ModelYear"].HeaderText = "Model Year";
                    //grdCDcrane.Columns["ModelSpaceName"].HeaderText = "ModelSpace Name";
                    //grdCDcrane.Columns["OwnerFax"].HeaderText = "Owner Fax";
                    //grdCDcrane.Columns["OwnerPhone"].HeaderText = "Owner Phone";
                    //grdCDcrane.Columns["SerialNumber"].HeaderText = "Serial No";
                    //grdCDcrane.Columns["TypBoom"].HeaderText = "Type Boom";
                    //grdCDcrane.Columns["TypJIB"].HeaderText = "Type JIB";
                    //grdCDcrane.Columns["TypMast"].HeaderText = "Type Mast";
                    //grdCDcrane.Columns["TypTotal"].HeaderText = "Type Total";
                    //grdCDcrane.Columns["ApprovedChartType"].HeaderText = "Approved Chart Type";
                    //grdCDcrane.Columns["Dunnage1"].HeaderText = "Dunnage1";
                    //grdCDcrane.Columns["Dunnage2"].HeaderText = "Dunnage2";
                    //grdCDcrane.Columns["TravelCtwt"].HeaderText = "TravelCtwt";


                    datarow["CDID"] = 0;
                    datarow["Capacity"] = "";
                    datarow["CDNumber"] = "";
                    datarow["CraneID"] = "";
                    datarow["CraneName"] = "";
                    datarow["EquipmentType"] = "";
                    datarow["Expiration"] = "";
                    datarow["Make"] = "";
                    datarow["Model"] = "";
                    datarow["ModelYear"] = DateTime.Now.ToString("yyyy").ToString();
                    datarow["ModelSpaceName"] = "";
                    datarow["Notes"] = "";
                    datarow["Owner"] = "";
                    datarow["OwnerFax"] = "";
                    datarow["OwnerPhone"] = "";

                    //datarow["SerialNo"] = "";
                    datarow["SerialNumber"] = "";

                    //datarow["TypeBoom"] = "";
                    //datarow["TypeJIB"] = "";
                    //datarow["TypeMast"] = "";
                    //datarow["TypeTotal"] = "";

                    datarow["TypBoom"] = "";
                    datarow["TypJIB"] = "";
                    datarow["TypMast"] = "";
                    datarow["TypTotal"] = "";


                    datarow["ApprovedChartType"] = "";
                    datarow["Dunnage1"] = "";
                    datarow["Dunnage2"] = "";
                    datarow["TravelCtwt"] = "";
                    CraneDT.Rows.Add(datarow);
                    grdCDcrane.DataSource = CraneDT;
                    grdCDcrane.CurrentCell = grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Capacity"];
                    grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Selected = true;
                    grdCDcrane.Rows[grdCDcrane.CurrentRow.Index].DefaultCellStyle.SelectionBackColor = Color.Gold;
                    grdCDcrane.Rows[grdCDcrane.CurrentRow.Index].DefaultCellStyle.BackColor = Color.Gold;
                }
                else
                {
                    InsertDataCranInfo();
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                FillCraneGrid();
                btnSave.Text = "Insert";
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnClear_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                foreach (Control ctrl in GrpSearch.Controls)
                {
                    if (ctrl is TextBox)
                    {
                        ctrl.Text = string.Empty;
                    }

                    else if (ctrl is CheckBox)
                    {
                        //CheckBox chk = ctrl;
                        ((CheckBox)ctrl).Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtCapacity_KeyPress(System.Object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            try
            {
                if (grdCDcrane.Rows.Count == 0)
                {
                    if (((int)e.KeyChar) == 13 || ((int)e.KeyChar) == 8)
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = false;
                }
            }
            catch (Exception ex)
            { }
        }

        private void frmCraneInfo_FormClosing(System.Object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void grdCDcrane_RowHeaderMouseDoubleClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            SelectCDID = grdCDcrane.Rows[e.RowIndex].Cells["CDID"].Value.ToString();
            this.Hide();
        }

        private void grdCDcrane_CellEndEdit(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    if (Convert.ToInt16(grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["CDID"].Value.ToString()) == 0)
                    {
                        return;
                    }

                    //if (CheckString != grdCDcrane.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() && e.ColumnIndex != 28)

                    //if (CheckString != grdCDcrane.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() && e.ColumnIndex != 28 )

                    //if (grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value == null || grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdInvoiceAction.Rows[e.RowIndex].Cells["txtgrdActionDate"].Value.ToString()))

                    if (grdCDcrane.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null || grdCDcrane.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdCDcrane.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()))
                    { 

                    }
                    else
                    {

                        if (CheckString != grdCDcrane.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() && e.ColumnIndex != 28)
                        {
                            grdCDcrane.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                            grdCDcrane.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                            CheckString = string.Empty;

                        }

                    }
                    //txtCode.Text = dgvIncome.SelectedRows[0].Cells[1].Value?.ToString();

                    String value2 = grdCDcrane.Rows[e.RowIndex].Cells[8].Value?.ToString() as string;

                    //String value2 = grdCDcrane.Rows[e.RowIndex].Cells[8].Value.ToString() as string;

                    if (e.ColumnIndex == 8)
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
                                grdCDcrane.Rows[e.RowIndex].Cells[8].Value = value2;
                                grdCDcrane.Rows[e.RowIndex].Cells[8].Tag = inputString;
                            }
                            else
                            {
                                grdCDcrane.Rows[e.RowIndex].Cells[8].Tag = inputString;
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
            catch (ArgumentNullException ex2)
            {
                MessageBox.Show(ex2.Message.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
        }

        private void grdCDcrane_CellBeginEdit(object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1 && e.ColumnIndex != 28)
                {
                    CheckString = string.Empty;
                    if (Convert.ToInt16(grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["CDID"].Value.ToString()) == 0)
                    {
                        if (grdCDcrane.CurrentRow.Index == grdCDcrane.Rows.Count - 1)
                        {
                            return;
                        }
                        KryptonMessageBox.Show("First Save then select for update", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //CheckString = grdCDcrane.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    CheckString = NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                 

                }
            }
            catch (Exception ex)
            {
            }
        }

        private void grdCDcrane_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {

            //MessageBox.Show(e.ColumnIndex.ToString());

            if (e.RowIndex != -1 && e.ColumnIndex == 0)
            {
                try
                {
                    SqlCommand Cmd = new SqlCommand();
                    List<SqlParameter> Param = new List<SqlParameter>();

                    Cmd.CommandText = "UPDATE VBCDDatabase SET CDNumber=@CDNUM,SerialNumber=@SerialNumber,Make=@Make,Model=@Model,ModelYear=@ModelYear,Capacity=@Capacity,Owner=@Owner,Expiration=@Expiration,ModelSpaceName=@ModelSpaceName,Notes=@Notes,CraneName=@CraneName,CraneID=@CraneID,OwnerPhone=@OwnerPhone,OwnerFax=@OwnerFax,TypMast=@TypMast,TypBoom=@TypBoom,TypJIB=@TypJIB,TypTotal=@TypTotal,ISChange=@ISChange,ChangeDate=@ChangeDate,EquipmentType=@EquipmentType,ApprovedChartType=@ApprovedChartType,Dunnage1=@Dunnage1,Dunnage2=@Dunnage2,TravelCtwt=@TravelCtwt WHERE CDID=@CDID";

                    //Param.Add(new SqlParameter("@CDNUM", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["CDNumber"].Value));



                    //grdCDcrane.Columns["CDNumber"].HeaderText = "CD Number";
                    //grdCDcrane.Columns["CraneID"].HeaderText = "Crane ID";
                    //grdCDcrane.Columns["CraneName"].HeaderText = "Crane Name";
                    //grdCDcrane.Columns["EquipmentType"].HeaderText = "Equipment Type";
                    //grdCDcrane.Columns["ModelYear"].HeaderText = "Model Year";
                    //grdCDcrane.Columns["ModelSpaceName"].HeaderText = "ModelSpace Name";
                    //grdCDcrane.Columns["OwnerFax"].HeaderText = "Owner Fax";
                    //grdCDcrane.Columns["OwnerPhone"].HeaderText = "Owner Phone";
                    //grdCDcrane.Columns["SerialNumber"].HeaderText = "Serial No";
                    //grdCDcrane.Columns["TypBoom"].HeaderText = "Type Boom";
                    //grdCDcrane.Columns["TypJIB"].HeaderText = "Type JIB";
                    //grdCDcrane.Columns["TypMast"].HeaderText = "Type Mast";
                    //grdCDcrane.Columns["TypTotal"].HeaderText = "Type Total";
                    //grdCDcrane.Columns["ApprovedChartType"].HeaderText = "Approved Chart Type";
                    //grdCDcrane.Columns["Dunnage1"].HeaderText = "Dunnage1";
                    //grdCDcrane.Columns["Dunnage2"].HeaderText = "Dunnage2";
                    //grdCDcrane.Columns["TravelCtwt"].HeaderText = "TravelCtwt";



                    Param.Add(new SqlParameter("@CDNUM", grdCDcrane.Rows[e.RowIndex].Cells["CDNumber"].Value));
                    //Param.Add(new SqlParameter("@SerialNumber", NullToIntValue(grdCDcrane.Rows[e.RowIndex].Cells["SerialNo"].Value)));
                    
                    Param.Add(new SqlParameter("@SerialNumber", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["SerialNumber"].Value)));


                    Param.Add(new SqlParameter("@Make", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["Make"].Value)));
                    Param.Add(new SqlParameter("@Model", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["Model"].Value)));
                    Param.Add(new SqlParameter("@ModelYear", NullToIntValue(grdCDcrane.Rows[e.RowIndex].Cells["ModelYear"].Value)));
                    Param.Add(new SqlParameter("@Capacity", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["Capacity"].Value)));
                    Param.Add(new SqlParameter("@Owner", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["Owner"].Value)));
                    Param.Add(new SqlParameter("@Expiration", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["Expiration"].Value)));
                    Param.Add(new SqlParameter("@ModelSpaceName", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["ModelSpaceName"].Value)));
                    Param.Add(new SqlParameter("@Notes", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["Notes"].Value)));
                    Param.Add(new SqlParameter("@CraneName", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["CraneName"].Value)));
                    Param.Add(new SqlParameter("@CraneID", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["CraneID"].Value)));
                    Param.Add(new SqlParameter("@OwnerPhone", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["OwnerPhone"].Value)));
                    Param.Add(new SqlParameter("@OwnerFax", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["OwnerFax"].Value)));

                    //Param.Add(new SqlParameter("@TypMast", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["TypeMast"].Value)));
                    //Param.Add(new SqlParameter("@TypBoom", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["TypeBoom"].Value)));
                    //Param.Add(new SqlParameter("@TypJIB", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["TypeJIB"].Value)));
                    //Param.Add(new SqlParameter("@TypTotal", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["TypeTotal"].Value)));


                    Param.Add(new SqlParameter("@TypMast", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["TypMast"].Value)));
                    Param.Add(new SqlParameter("@TypBoom", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["TypBoom"].Value)));
                    Param.Add(new SqlParameter("@TypJIB", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["TypJIB"].Value)));
                    Param.Add(new SqlParameter("@TypTotal", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["TypTotal"].Value)));


                    Param.Add(new SqlParameter("@CDID", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["CDID"].Value)));
                    Param.Add(new SqlParameter("@EquipmentType", NullToStrValue(grdCDcrane.Rows[e.RowIndex].Cells["EquipmentType"].Value)));
                    Param.Add(new SqlParameter("@ApprovedChartType", NullToStrValue(grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["ApprovedChartType"].Value)));
                    Param.Add(new SqlParameter("@Dunnage1", NullToStrValue(grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Dunnage1"].Value)));
                    Param.Add(new SqlParameter("@Dunnage2", NullToStrValue(grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Dunnage2"].Value)));
                    Param.Add(new SqlParameter("@TravelCtwt", NullToStrValue(grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TravelCtwt"].Value)));
                    Param.Add(new SqlParameter("@ISChange", 1));
                    Param.Add(new SqlParameter("@ChangeDate", DateTime.Now.ToString("MM/dd/yyyy")));


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        

                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            if (db.Database.ExecuteSqlCommand(Cmd.CommandText.ToString(), Param.ToArray()) > 0)
                            {
                                KryptonMessageBox.Show("Update Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdCDcrane.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                grdCDcrane.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                FillCraneGrid();
                            }
                        }
                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            if (db.Database.ExecuteSqlCommand(Cmd.CommandText.ToString(), Param.ToArray()) > 0)
                            {
                                KryptonMessageBox.Show("Update Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                grdCDcrane.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                                grdCDcrane.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                                FillCraneGrid();
                            }
                        }
                    }

                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    if (db.Database.ExecuteSqlCommand(Cmd.CommandText.ToString(), Param.ToArray()) > 0)
                    //    {
                    //        KryptonMessageBox.Show("Update Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        grdCDcrane.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    //        grdCDcrane.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(159, 207, 255);
                    //        FillCraneGrid();
                    //    }
                    //}
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (e.RowIndex != -1 && e.ColumnIndex == 1)
            {
                try
                {
                    if (KryptonMessageBox.Show("Are you sure to want delete", "Crane Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {


                        //using (EFDbContext db = new EFDbContext())
                        //{
                        //    if (db.Database.ExecuteSqlCommand("DELETE FROM VBCDDatabase WHERE CDID=" + grdCDcrane.Rows[e.RowIndex].Cells["CDID"].Value) > 0)
                        //    {
                        //        KryptonMessageBox.Show("Delete Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        //grdCDcrane.Rows.RemoveAt(e.RowIndex);
                        //        FillCraneGrid();
                        //        StMethod.LoginActivityInfo(db, "Delete", this.Name);
                        //    }
                        //}

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            
                            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            {
                                if (db.Database.ExecuteSqlCommand("DELETE FROM VBCDDatabase WHERE CDID=" + grdCDcrane.Rows[e.RowIndex].Cells["CDID"].Value) > 0)
                                {
                                    KryptonMessageBox.Show("Delete Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //grdCDcrane.Rows.RemoveAt(e.RowIndex);
                                    FillCraneGrid();
                                    StMethod.LoginActivityInfoNew(db, "Delete", this.Name);
                                }
                            }


                        }
                        else
                        {
                            using (EFDbContext db = new EFDbContext())
                            {
                                if (db.Database.ExecuteSqlCommand("DELETE FROM VBCDDatabase WHERE CDID=" + grdCDcrane.Rows[e.RowIndex].Cells["CDID"].Value) > 0)
                                {
                                    KryptonMessageBox.Show("Delete Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //grdCDcrane.Rows.RemoveAt(e.RowIndex);
                                    FillCraneGrid();
                                    StMethod.LoginActivityInfo(db, "Delete", this.Name);
                                }
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Methods & Functions

        private int NullToIntValue(object obj)
        {
            if (obj is null)
                return 0;
            else
                return Convert.ToInt32(obj);
        }

        private string NullToStrValue(object obj)
        {
            if (obj is null)
                return "";
            else
                return Convert.ToString(obj);
        }

        private void InsertDataCranInfo()
        {
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "INSERT INTO VBCDDatabase([CDNumber],[SerialNumber],[Make],[Model],[ModelYear],[Capacity],[Owner],[Expiration]," +
                    "[ModelSpaceName],[Notes],[CraneName],[CraneID],[OwnerPhone],[OwnerFax],[TypMast],[TypBoom],[TypJIB],[TypTotal],[IsNewRecord]," +
                    "[EquipmentType],[ApprovedChartType],[Dunnage1],[Dunnage2],[TravelCtwt])VALUES (@CDNUM,@SerialNumber,@Make,@Model,@ModelYear,@Capacity," +
                    "@Owner,@Expiration,@ModelSpaceName,@Notes,@CraneName,@CraneID,@OwnerPhone,@OwnerFax,@TypMast,@TypBoom,@TypJIB,@TypTotal,@IsNewRecord," +
                    "@EquipmentType,@ApprovedChartType,@Dunnage1,@Dunnage2,@TravelCtwt)";

                List<SqlParameter> Param = new List<SqlParameter>
                {

                    
                    //grdCDcrane.Columns["CDNumber"].HeaderText = "CD Number";
                    //grdCDcrane.Columns["CraneID"].HeaderText = "Crane ID";
                    //grdCDcrane.Columns["CraneName"].HeaderText = "Crane Name";
                    //grdCDcrane.Columns["EquipmentType"].HeaderText = "Equipment Type";
                    //grdCDcrane.Columns["ModelYear"].HeaderText = "Model Year";
                    //grdCDcrane.Columns["ModelSpaceName"].HeaderText = "ModelSpace Name";
                    //grdCDcrane.Columns["OwnerFax"].HeaderText = "Owner Fax";
                    //grdCDcrane.Columns["OwnerPhone"].HeaderText = "Owner Phone";
                    //grdCDcrane.Columns["SerialNumber"].HeaderText = "Serial No";
                    //grdCDcrane.Columns["TypBoom"].HeaderText = "Type Boom";
                    //grdCDcrane.Columns["TypJIB"].HeaderText = "Type JIB";
                    //grdCDcrane.Columns["TypMast"].HeaderText = "Type Mast";
                    //grdCDcrane.Columns["TypTotal"].HeaderText = "Type Total";
                    //grdCDcrane.Columns["ApprovedChartType"].HeaderText = "Approved Chart Type";
                    //grdCDcrane.Columns["Dunnage1"].HeaderText = "Dunnage1";
                    //grdCDcrane.Columns["Dunnage2"].HeaderText = "Dunnage2";
                    //grdCDcrane.Columns["TravelCtwt"].HeaderText = "TravelCtwt";


                    new SqlParameter("@CDNUM", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["CDNumber"].Value.ToString()),
                    //new SqlParameter("@SerialNumber", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["SerialNo"].Value.ToString()),

                    new SqlParameter("@SerialNumber", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["SerialNumber"].Value.ToString()),

                    new SqlParameter("@Make", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Make"].Value.ToString()),
                    new SqlParameter("@Model", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Model"].Value.ToString()),
                    new SqlParameter("@ModelYear", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["ModelYear"].Value.ToString()),
                    new SqlParameter("@Capacity", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Capacity"].Value.ToString()),
                    new SqlParameter("@Owner", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Owner"].Value.ToString()),
                    new SqlParameter("@Expiration", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Expiration"].Value.ToString()),
                    new SqlParameter("@ModelSpaceName", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["ModelSpaceName"].Value.ToString()),
                    new SqlParameter("@Notes", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Notes"].Value.ToString()),
                    new SqlParameter("@CraneName", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["CraneName"].Value.ToString()),
                    new SqlParameter("@CraneID", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["CraneID"].Value.ToString()),
                    new SqlParameter("@OwnerPhone", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["OwnerPhone"].Value.ToString()),
                    new SqlParameter("@OwnerFax", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["OwnerFax"].Value.ToString()),
                    
                    //new SqlParameter("@TypMast", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TypeMast"].Value.ToString()),
                    //new SqlParameter("@TypBoom", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TypeBoom"].Value.ToString()),
                    //new SqlParameter("@TypJIB", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TypeJIB"].Value.ToString()),
                    //new SqlParameter("@TypTotal", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TypeTotal"].Value.ToString()),

                    new SqlParameter("@TypMast", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TypMast"].Value.ToString()),
                    new SqlParameter("@TypBoom", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TypBoom"].Value.ToString()),
                    new SqlParameter("@TypJIB", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TypJIB"].Value.ToString()),
                    new SqlParameter("@TypTotal", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TypTotal"].Value.ToString()),


                    new SqlParameter("@EquipmentType", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["EquipmentType"].Value.ToString()),
                    new SqlParameter("@ApprovedChartType", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["ApprovedChartType"].Value.ToString()),
                    new SqlParameter("@Dunnage1", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Dunnage1"].Value.ToString()),
                    new SqlParameter("@Dunnage2", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["Dunnage2"].Value.ToString()),
                    new SqlParameter("@TravelCtwt", grdCDcrane.Rows[grdCDcrane.Rows.Count - 1].Cells["TravelCtwt"].Value.ToString()),
                    new SqlParameter("@IsNewRecord", 1)
                };
                //Con.Open();


                //using (EFDbContext db = new EFDbContext())
                //{
                //    if (db.Database.ExecuteSqlCommand(Cmd.CommandText.ToString(), Param.ToArray()) > 0)
                //    {
                //        KryptonMessageBox.Show("Save Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        btnSave.Text = "Insert";
                //        FillCraneGrid();
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        if (db.Database.ExecuteSqlCommand(Cmd.CommandText.ToString(), Param.ToArray()) > 0)
                        {
                            KryptonMessageBox.Show("Save Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSave.Text = "Insert";
                            FillCraneGrid();
                        }
                    }
                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand(Cmd.CommandText.ToString(), Param.ToArray()) > 0)
                        {
                            KryptonMessageBox.Show("Save Successfully", "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSave.Text = "Insert";
                            FillCraneGrid();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Crane Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillCraneGrid()
        {
            try
            {
                //string Query = "SELECT CDID, Capacity, CDNumber as [CD Number], CraneID as [Crane ID], CraneName as [Crane Name], EquipmentType as [Equipment Type], Expiration, Make, Model, ModelYear as [Model Year], ModelSpaceName as [ModelSpace Name], Notes, Owner, OwnerFax as [Owner Fax], OwnerPhone as [Owner Phone], SerialNumber as [Serial No], TypBoom as [Type Boom], TypJIB as [Type JIB], TypMast as [Type Mast], TypTotal as [Type Total],ApprovedChartType as [Approved Chart Type],Dunnage1 as [Dunnage1],Dunnage2 as [Dunnage2],TravelCtwt as [TravelCtwt]  FROM VBCDDatabase WHERE CDID<>0 ";

                string Query = "SELECT CDID, Capacity, CDNumber, CraneID, CraneName, EquipmentType, Expiration, Make, Model, ModelYear, ModelSpaceName, Notes, Owner, OwnerFax, OwnerPhone, SerialNumber, TypBoom, TypJIB, TypMast, TypTotal,ApprovedChartType,Dunnage1,Dunnage2,TravelCtwt FROM VBCDDatabase WHERE CDID<>0 ";


                if (!string.IsNullOrEmpty(txtCapacity.Text.Trim()))
                {
                    Query = Query + "AND Capacity LIKE '%" + txtCapacity.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtCDNum.Text.Trim()))
                {
                    Query = Query + "AND CDNumber LIKE '%" + txtCDNum.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtMake.Text.Trim()))
                {
                    Query = Query + "AND Make LIKE '%" + txtMake.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtModel.Text.Trim()))
                {
                    Query = Query + "AND Model LIKE '%" + txtModel.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtOwner.Text.Trim()))
                {
                    Query = Query + "AND Owner LIKE '%" + txtOwner.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtSerial.Text.Trim()))
                {
                    Query = Query + "AND SerialNumber LIKE '%" + txtSerial.Text.Trim() + "%'";
                }

                //using (EFDbContext db = new EFDbContext())
                //{
                //    //var list = db.Database.SqlQuery<CDInfoContact>(Query).ToList();
                    
                //    var list = db.Database.SqlQuery<CDInfoContactNew>(Query).ToList();

                //    grdCDcrane.DataSource = list;
                //}



                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        //var list = db.Database.SqlQuery<CDInfoContact>(Query).ToList();

                        var list = db.Database.SqlQuery<CDInfoContactNew>(Query).ToList();

                        grdCDcrane.DataSource = list;
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        //var list = db.Database.SqlQuery<CDInfoContact>(Query).ToList();

                        var list = db.Database.SqlQuery<CDInfoContactNew>(Query).ToList();

                        grdCDcrane.DataSource = list;
                    }

                }



                //grdCDcrane.Columns[0].Frozen = false;


                grdCDcrane.Columns["CDID"].Visible = false;
                
                grdCDcrane.Columns["CDNumber"].HeaderText  = "CD Number";
                grdCDcrane.Columns["CraneID"].HeaderText = "Crane ID";
                grdCDcrane.Columns["CraneName"].HeaderText = "Crane Name";
                grdCDcrane.Columns["EquipmentType"].HeaderText = "Equipment Type";
                grdCDcrane.Columns["ModelYear"].HeaderText = "Model Year";
                grdCDcrane.Columns["ModelSpaceName"].HeaderText = "ModelSpace Name";
                grdCDcrane.Columns["OwnerFax"].HeaderText = "Owner Fax";
                grdCDcrane.Columns["OwnerPhone"].HeaderText = "Owner Phone";
                grdCDcrane.Columns["SerialNumber"].HeaderText = "Serial No";
                grdCDcrane.Columns["TypBoom"].HeaderText = "Type Boom";
                grdCDcrane.Columns["TypJIB"].HeaderText = "Type JIB";
                grdCDcrane.Columns["TypMast"].HeaderText = "Type Mast";


                grdCDcrane.Columns["TypTotal"].HeaderText = "Type Total";
                grdCDcrane.Columns["ApprovedChartType"].HeaderText = "Approved Chart Type";

                grdCDcrane.Columns["Dunnage1"].HeaderText = "Dunnage1";
                grdCDcrane.Columns["Dunnage2"].HeaderText = "Dunnage2";
                grdCDcrane.Columns["TravelCtwt"].HeaderText = "TravelCtwt";


                //grdCDcrane.AutoSize = false;

                //grdCDcrane.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;                
                //grdCDcrane.ScrollBars = ScrollBars.Both;

                //AutoSizeColumnsMode = Fill
                //AutoSizeRowsMode = Displayedcells
                //RightToLeft = Yes

                //grdCDcrane.Height = pnlGrid.Height - 10;



                //this.Size = Screen.PrimaryScreen.WorkingArea.Size;


                //grdCDcrane.Height = pnlGrid.Height - 10;
                //grdCDcrane.Width = pnlGrid.Width - 10;


                //grdCDcrane.Columns["CraneID"].Visible = false;



                //((Form)this.MdiParent).Controls["kryptonPanel1"].Enabled = true;


                //grdCDcrane.Location.X = ((Form)this.MdiParent).Controls["kryptonPanel1"].Location.X;

                //grdCDcrane.Location =  new Point(((Form)this.MdiParent).Controls["kryptonPanel1"].Location.X-10, ((Form)this.MdiParent).Controls["kryptonPanel1"].Location.Y-10);

                //grdCDcrane.Location = new Point(15, ((Form)this.MdiParent).Controls["kryptonPanel1"].Location.Y - 30);

                //btnShowCausali.Location = new Point(20, 20);
                //grdCDcrane.Location.X = JobTrackingMDIForm.JobAndTrackingMDI.ControlAccessibleObject
                //grdCDcrane.ScrollBars = ScrollBars.Horizontal;


                //this.ApplicationObjectRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; 
                //it is for avoid unused column space not row space.

                //grdCDcrane.Height = pnlGrid.Height - 1;


                //for (int i = 0; i < grdCDcrane.Columns.Count; i++)
                //{

                //    grdCDcrane.Columns[i].Frozen = false;
                //}

                //grdCDcrane.Height = grdCDcrane.Height + 260;
                //grdCDcrane.Width = grdCDcrane.Width + 450;


                //pnlGrid.Height = this.Height - 10;

                //pnlGrid.Dock = DockStyle.Fill;
                ////pnlGrid.Height = 1250;

                //pnlGrid.Width = 800;

               // pnlGrid.Anchor = AnchorStyles.Top;

                grdCDcrane.ScrollBars = ScrollBars.Both;
                grdCDcrane.BringToFront();
                grdCDcrane.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                //grdCDcrane.Height = 100;

                //grdCDcrane.Height = pnlGrid.Height - 100;

               // grdCDcrane.Height = Screen.PrimaryScreen.WorkingArea.Height - 20;
                

                //Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                //int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
                //int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;

                //this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
                //this.Size = new Size(w, h);

                //Screen.PrimaryScreen.WorkingArea.Size;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        public void CommunityBoardFromInfo()
        {
            foreach (DataGridViewRow grdrow in grdCDcrane.Rows)
            {
                if (grdrow.Cells["CDID"].Value.ToString().Trim() == CraneOldID)
                {
                    grdrow.Selected = true;
                    grdCDcrane.CurrentCell = grdrow.Cells["CDNumber"];
                    grdrow.DefaultCellStyle.SelectionBackColor = Color.Tomato;
                    grdrow.DefaultCellStyle.BackColor = Color.Tomato;
                }
            }
        }

        #endregion

        private void grdCDcrane_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {

                if (e.ColumnIndex == 8)
                {
                    String value = e.Value as string;

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



                    //if ((value != null))
                    //{ 
                    //    //String value = e.Value as string;

                    //    string inputString;
                    //    DateTime dDate;

                    //    inputString = e.Value.ToString();
                    //    if (DateTime.TryParse(inputString, out dDate))
                    //    {
                    //        //String.Format("{0:d/MM/yyyy}", dDate);

                    //        e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                    //        e.FormattingApplied = true;
                    //    }
                    //    else
                    //    {


                    //    }
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