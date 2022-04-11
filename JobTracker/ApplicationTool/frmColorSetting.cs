using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
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

namespace JobTracker.Application_Tool
{
    public partial class frmColorSetting : Form
    {
        #region GlobalVariable
        //private SqlConnection Con;
        //private SqlCommand Cmd;
        //private DataAccessLayer DAL;
        private string Colorstr;
        
        private static frmColorSetting _Instance;
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
        public static frmColorSetting Instance
        {
            get
            {
                if (_Instance == null || _Instance.IsDisposed)
                {
                    _Instance = new frmColorSetting();
                }
                return _Instance;
            }
        }
        #endregion

        public frmColorSetting()
        {
            InitializeComponent();
        }

        #region Events
        private void frmColorSetting_Load(System.Object sender, System.EventArgs e)
        {
            FillGrdColorSetting();
            fillGrdColorEmailDes();
        }
        private void GreenToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorCode"].Value = "Green";
            //Dim Btn As New DataGridViewButtonCell
            //Btn.Style.BackColor = Color.Green
            //Btn.FlatStyle = FlatStyle.Flat
            grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells[3].Style.BackColor = Color.Green;
        }

        private void YellowToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorCode"].Value = "Yellow";
            grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells[3].Style.BackColor = Color.Yellow;
        }

        private void OrangeToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorCode"].Value = "Orange";
            grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells[3].Style.BackColor = Color.Orange;
        }

        private void RedToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorCode"].Value = "Red";
            grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells[3].Style.BackColor = Color.Red;
        }

        //private void BlueToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        //{
        //    grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorCode").Value = "Blue";
        //    grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells[3].Style.BackColor = Color.Blue;
        //}

        private void grdColorSetting_CellMouseClick(System.Object sender, System.Windows.Forms.DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                if (e.Button == System.Windows.Forms.MouseButtons.Right)
                {
                    //System.Drawing.Point point = new System.Drawing.Point(e.MousePosition);
                    //colorMenu.BringToFront()
                    //colorMenu.Show(point)
                    //colorMenu.AutoClose = True
                }
            }
            else
            {
                colorMenu.Close();
            }
        }

        private void grdColorSetting_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    db.Database.ExecuteSqlCommand("UPDATE ColorSetting SET ColorCode='" + grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorCode"].Value.ToString() + "' WHERE ColorID=" + grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorID"].Value.ToString());
                    //    StMethod.LoginActivityInfo(db, "Update", this.Name);
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            db.Database.ExecuteSqlCommand("UPDATE ColorSetting SET ColorCode='" + grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorCode"].Value.ToString() + "' WHERE ColorID=" + grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorID"].Value.ToString());
                            StMethod.LoginActivityInfoNew(db, "Update", this.Name);
                        }

                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            db.Database.ExecuteSqlCommand("UPDATE ColorSetting SET ColorCode='" + grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorCode"].Value.ToString() + "' WHERE ColorID=" + grdColorSetting.Rows[grdColorSetting.CurrentRow.Index].Cells["ColorID"].Value.ToString());
                            StMethod.LoginActivityInfo(db, "Update", this.Name);
                        }
                    }

                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Color Email Description Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grdColorSetting_CellFormatting(System.Object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            //ChangeColor()
            if (e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                if (grdColorSetting.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Red")
                {
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Red;
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.Red;
                }
                if (grdColorSetting.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Orange")
                {
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Orange;
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.Orange;
                }
                if (grdColorSetting.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Yellow")
                {
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Yellow;
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.Yellow;
                }
                if (grdColorSetting.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Green")
                {
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Green;
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.Green;
                }
                if (grdColorSetting.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Black")
                {
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Black;
                    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.Black;
                }
                //If grdColorSetting.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString = "Blue" Then
                //    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.BackColor = Color.Blue
                //    grdColorSetting.Rows[e.RowIndex].Cells[3].Style.SelectionBackColor = Color.Blue
                //End If
            }
        }

        private void grdColoeEmailDes_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        if (db.Database.ExecuteSqlCommand("UPDATE ColorEmailDescription SET EmailSubject='" + grdColoeEmailDes.Rows[grdColoeEmailDes.CurrentRow.Index].Cells["EmailSubject"].Value.ToString() + "', EmailDescription='" + grdColoeEmailDes.Rows[grdColoeEmailDes.CurrentRow.Index].Cells["EmailDescription"].Value.ToString() + "' WHERE EmaildesID= " + grdColoeEmailDes.Rows[grdColoeEmailDes.CurrentRow.Index].Cells["EmaildesID"].Value.ToString()) > 0)
                        {
                            KryptonMessageBox.Show("Update Successfully", "Color Email Description Setting", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            StMethod.LoginActivityInfo(db, "Update", this.Name);
                        }
                    }
                }
                catch (Exception ex)
                {
                    KryptonMessageBox.Show(ex.Message, "Color Email Description Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grdColoeEmailDes_CellFormatting(object sender, System.Windows.Forms.DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 6 && e.RowIndex > -1)
                {
                    if (grdColoeEmailDes.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Red")
                    {
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.Red;
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.SelectionBackColor = Color.Red;
                    }
                    if (grdColoeEmailDes.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Orange")
                    {
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.Orange;
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.SelectionBackColor = Color.Orange;
                    }
                    if (grdColoeEmailDes.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Yellow")
                    {
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.Yellow;
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.SelectionBackColor = Color.Yellow;
                    }
                    if (grdColoeEmailDes.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Green")
                    {
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.Green;
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.SelectionBackColor = Color.Green;
                    }
                    if (grdColoeEmailDes.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString() == "Black")
                    {
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.Black;
                        grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.SelectionBackColor = Color.Black;
                    }
                    //If grdColoeEmailDes.Rows[e.RowIndex].Cells["ColorCode"].Value.ToString = "Blue" Then
                    //    grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.Blue
                    //    grdColoeEmailDes.Rows[e.RowIndex].Cells[6].Style.SelectionBackColor = Color.Blue
                    //End If
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Color Email Description Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Methods & Functions
        public void fillGrdColorEmailDes()
        {
            try
            {
                List<EmailColor> emails = new List<EmailColor>();


                //using (EFDbContext db = new EFDbContext())
                //{
                //    emails = db.Database.SqlQuery<EmailColor>("SELECT ColorSetting.ColorCode, ColorEmailDescription.EmailDescription, ColorEmailDescription.EmaildesID, ColorEmailDescription.ColorID,ColorEmailDescription.EmailSubject,'' as Color FROM  ColorEmailDescription INNER JOIN ColorSetting ON ColorEmailDescription.ColorID = ColorSetting.ColorID").ToList();
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        emails = db.Database.SqlQuery<EmailColor>("SELECT ColorSetting.ColorCode, ColorEmailDescription.EmailDescription, ColorEmailDescription.EmaildesID, ColorEmailDescription.ColorID,ColorEmailDescription.EmailSubject,'' as Color FROM  ColorEmailDescription INNER JOIN ColorSetting ON ColorEmailDescription.ColorID = ColorSetting.ColorID").ToList();
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        emails = db.Database.SqlQuery<EmailColor>("SELECT ColorSetting.ColorCode, ColorEmailDescription.EmailDescription, ColorEmailDescription.EmaildesID, ColorEmailDescription.ColorID,ColorEmailDescription.EmailSubject,'' as Color FROM  ColorEmailDescription INNER JOIN ColorSetting ON ColorEmailDescription.ColorID = ColorSetting.ColorID").ToList();
                    }
                }

                //DT.Columns.Add("Color");
                if (emails != null)
                {
                    grdColoeEmailDes.DataSource = emails;
                    grdColoeEmailDes.Columns["ColorCode"].HeaderText = "Color";
                    grdColoeEmailDes.Columns["ColorCode"].Visible = false;
                    grdColoeEmailDes.Columns["Color"].DisplayIndex = 1;
                    grdColoeEmailDes.Columns["EmaildesID"].Visible = false;
                    grdColoeEmailDes.Columns["EmailDescription"].HeaderText = "Email Body";
                    grdColoeEmailDes.Columns["ColorID"].Visible = false;
                    grdColoeEmailDes.Columns["EmailSubject"].HeaderText = "Email Subject";
                    grdColoeEmailDes.Columns["EmailSubject"].DisplayIndex = 2;
                    grdColoeEmailDes.Columns["EmailDescription"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    grdColoeEmailDes.Columns["EmailDescription"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                }
                //ChangeColor()
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Color Email Description Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FillGrdColorSetting()
        {
            try
            {
                List<Color_Code> colors = new List<Color_Code>();


                //using (EFDbContext db = new EFDbContext())
                //{
                //    colors = db.Database.SqlQuery<Color_Code>("SELECT ColorCode,ColorID,'' as ColorCodeImage FROM  ColorSetting").ToList();
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        colors = db.Database.SqlQuery<Color_Code>("SELECT ColorCode,ColorID,'' as ColorCodeImage FROM  ColorSetting").ToList();
                    }
                }
                else
                {

                    using (EFDbContext db = new EFDbContext())
                    {
                        colors = db.Database.SqlQuery<Color_Code>("SELECT ColorCode,ColorID,'' as ColorCodeImage FROM  ColorSetting").ToList();
                    }
                }





                if (colors != null)
                {
                    //DT.Columns.Add("ColorCodeImage");
                    grdColorSetting.DataSource = colors;
                    grdColorSetting.Columns["ColorCode"].HeaderText = "Color";
                    grdColorSetting.Columns["ColorCode"].Visible = false;
                    grdColorSetting.Columns["ColorCodeImage"].HeaderText = "ColorCode";
                    grdColorSetting.Columns["ColorCodeImage"].DisplayIndex = 1;
                    //.Columns["ColorCodeImage"].Width = 200
                    //.Columns["EmailDescription"].HeaderText = "Description"
                    grdColorSetting.Columns["ColorID"].Visible = false;
                    grdColorSetting.Columns["ColorCodeImage"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                //ChangeColor()
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message, "Color Email Description Setting", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ChangeColor()
        {
            try
            {
                foreach (DataGridViewRow row in grdColorSetting.Rows)
                {
                    if (grdColorSetting.Rows[row.Index].Cells["ColorCode"].Value.ToString() == "Red")
                    {
                        DataGridViewButtonCell Btn = new DataGridViewButtonCell();
                        Btn.Style.BackColor = Color.Red;
                        Btn.FlatStyle = FlatStyle.Flat;
                        //grdColorSetting(4, row.Index).Style.BackColor = Color.Red;
                        grdColorSetting.Rows[row.Index].Cells[4].Style.BackColor = Color.Red;
                    }
                    if (grdColorSetting.Rows[row.Index].Cells["ColorCode"].Value.ToString() == "Orange")
                    {
                        DataGridViewButtonCell Btn1 = new DataGridViewButtonCell();
                        Btn1.Style.BackColor = Color.Orange;
                        Btn1.FlatStyle = FlatStyle.Flat;
                        grdColorSetting.Rows[row.Index].Cells[4] = Btn1;
                    }
                    if (grdColorSetting.Rows[row.Index].Cells["ColorCode"].Value.ToString() == "Yellow")
                    {
                        DataGridViewButtonCell Btn2 = new DataGridViewButtonCell();
                        Btn2.Style.BackColor = Color.Yellow;
                        Btn2.FlatStyle = FlatStyle.Flat;
                        grdColorSetting.Rows[row.Index].Cells[4] = Btn2;
                    }
                    if (grdColorSetting.Rows[row.Index].Cells["ColorCode"].Value.ToString() == "Green")
                    {
                        DataGridViewButtonCell Btn3 = new DataGridViewButtonCell();
                        Btn3.Style.BackColor = Color.Green;
                        Btn3.FlatStyle = FlatStyle.Flat;
                        grdColorSetting.Rows[row.Index].Cells[4] = Btn3;
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
