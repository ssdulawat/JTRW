using DataAccessLayer;
using DataAccessLayer.Model;
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
    public partial class frmDocTypicalTxtList : Form
    {
        #region Declaration
        private DataTable dtmasteritem = new DataTable();
        private string CheckString;
        //    Dim VariousInfo As VariousInfoEntities
        //private DataAccessLayer DAL;
        private static frmDocTypicalTxtList _Instance;

        #endregion
        public frmDocTypicalTxtList()
        {
            InitializeComponent();
        }

        #region Events
        private void frmDocTypicalTxtList_Load(System.Object sender, System.EventArgs e)
        {
            fillDocTypeCategory();
            fillDocListItem();
            fillcolumncombo();
        }

        private void btnadd_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (btnadd.Text == "Insert")
                {
                    btnadd.Text = "Save";
                    DataTable data = Program.ToDataTable<TypeCategoryData>((List<TypeCategoryData>)grdDocTypeCategory.DataSource);
                    DataRow dr = data.NewRow();
                    data.Rows.Add(dr);
                    grdDocTypeCategory.DataSource = data;
                    if (grdDocTypeCategory.Rows.Count > 0)
                    {
                        grdDocTypeCategory.Rows[grdDocTypeCategory.Rows.Count - 1].Selected = true;
                        grdDocTypeCategory.CurrentCell = grdDocTypeCategory.Rows[grdDocTypeCategory.Rows.Count - 1].Cells["CategoryName"];
                    }
                }
                else
                {
                    //Sqlclietn class for interface with database
                    List<SqlParameter> param = new List<SqlParameter>();


                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    param.Add(new SqlParameter("@CategoryName", grdDocTypeCategory.Rows[grdDocTypeCategory.Rows.Count - 1].Cells["CategoryName"].Value.ToString()));
                    //    db.Database.ExecuteSqlCommand("INSERT INTO DocTypicalCategoryList(CategoryName) VALUES(@CategoryName)", param.ToArray());
                    //}


                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            param.Add(new SqlParameter("@CategoryName", grdDocTypeCategory.Rows[grdDocTypeCategory.Rows.Count - 1].Cells["CategoryName"].Value.ToString()));
                            db.Database.ExecuteSqlCommand("INSERT INTO DocTypicalCategoryList(CategoryName) VALUES(@CategoryName)", param.ToArray());
                        }


                    }
                    else
                    {

                        using (EFDbContext db = new EFDbContext())
                        {
                            param.Add(new SqlParameter("@CategoryName", grdDocTypeCategory.Rows[grdDocTypeCategory.Rows.Count - 1].Cells["CategoryName"].Value.ToString()));
                            db.Database.ExecuteSqlCommand("INSERT INTO DocTypicalCategoryList(CategoryName) VALUES(@CategoryName)", param.ToArray());
                        }

                    }

                    //******
                    btnadd.Text = "Insert";
                    //fillcolumncombo()
                    fillDocTypeCategory();
                    MessageBox.Show("New record inserted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (grdDocTypeCategory.Rows.Count > 0)
                    {
                        grdDocTypeCategory.Rows[grdDocTypeCategory.Rows.Count - 1].Selected = true;
                        grdDocTypeCategory.CurrentCell = grdDocTypeCategory.Rows[grdDocTypeCategory.Rows.Count - 1].Cells["CategoryName"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            fillDocTypeCategory();
            btnadd.Text = "Insert";
        }

        private void btnInsertDocTypicalText_Click(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (btnInsertDocTypicalText.Text == "Insert")
                {
                    btnInsertDocTypicalText.Text = "Save";
                    DataTable data = Program.ToDataTable<DocTypeData>((List<DocTypeData>)grdListitem.DataSource);
                    DataRow dr = data.NewRow();
                    data.Rows.Add(dr);
                    grdListitem.DataSource = data;
                    if (grdListitem.Rows.Count > 0)
                    {
                        grdListitem.Rows[grdListitem.Rows.Count - 1].Selected = true;
                        grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["DocTypical_Text"];
                    }
                }
                else
                {
                    try
                    {
                        string str = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["CategoryName"].Value.ToString();
                        //Get id of DocTypical Category


                        //using (EFDbContext db = new EFDbContext())
                        //{
                        //    Int32 queryDocCategoryID = db.Database.SqlQuery<int>("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str+"'").FirstOrDefault();
                        //    //******
                        //    List<SqlParameter> param = new List<SqlParameter>();
                        //    param.Add(new SqlParameter("@DocTypical_Category", queryDocCategoryID));
                        //    param.Add(new SqlParameter("@DocTypical_Text", grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["DocTypical_Text"].Value.ToString()));
                        //    db.Database.ExecuteSqlCommand("INSERT INTO DocTypicalListItem(DocTypical_Category,DocTypical_Text) VALUES(@DocTypical_Category,@DocTypical_Text)", param.ToArray());
                        //}

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            
                            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            {
                                Int32 queryDocCategoryID = db.Database.SqlQuery<int>("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'").FirstOrDefault();
                                //******
                                List<SqlParameter> param = new List<SqlParameter>();
                                param.Add(new SqlParameter("@DocTypical_Category", queryDocCategoryID));
                                param.Add(new SqlParameter("@DocTypical_Text", grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["DocTypical_Text"].Value.ToString()));
                                db.Database.ExecuteSqlCommand("INSERT INTO DocTypicalListItem(DocTypical_Category,DocTypical_Text) VALUES(@DocTypical_Category,@DocTypical_Text)", param.ToArray());
                            }

                        }
                        else
                        {
                            using (EFDbContext db = new EFDbContext())
                            {
                                Int32 queryDocCategoryID = db.Database.SqlQuery<int>("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'").FirstOrDefault();
                                //******
                                List<SqlParameter> param = new List<SqlParameter>();
                                param.Add(new SqlParameter("@DocTypical_Category", queryDocCategoryID));
                                param.Add(new SqlParameter("@DocTypical_Text", grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["DocTypical_Text"].Value.ToString()));
                                db.Database.ExecuteSqlCommand("INSERT INTO DocTypicalListItem(DocTypical_Category,DocTypical_Text) VALUES(@DocTypical_Category,@DocTypical_Text)", param.ToArray());
                            }

                        }

                        btnInsertDocTypicalText.Text = "Insert";
                        fillDocListItem();
                        MessageBox.Show("New record inserted.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (grdListitem.Rows.Count > 0)
                        {
                            grdListitem.Rows[grdListitem.Rows.Count - 1].Selected = true;
                            grdListitem.CurrentCell = grdListitem.Rows[grdListitem.Rows.Count - 1].Cells["DocTypical_Text"];
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCanceDocTypicalText_Click(System.Object sender, System.EventArgs e)
        {
            btnInsertDocTypicalText.Text = "Insert";
            fillDocListItem();
        }

        private void grdDocTypeCategory_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    int ID = Convert.ToInt32(grdDocTypeCategory.Rows[e.RowIndex].Cells["TypeCategoryID"].Value);
                    //VariousInfo = New VariousInfoEntities
                    //Dim QueryUdpate As DocTypicalCategoryList = VariousInfo.DocTypicalCategoryLists.Where(Function(a) a.TypeCategoryID = ID).FirstOrDefault()
                    //QueryUdpate.CategoryName = grdDocTypeCategory.Rows[e.RowIndex].Cells["CategoryName"].Value
                    //VariousInfo.SaveChanges()
                    List<SqlParameter> param = new List<SqlParameter>();

                    string newvalue="";

                    newvalue = grdDocTypeCategory.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();


                    param.Add(new SqlParameter("@CategoryName", newvalue.ToString()));

                    //param.Add(new SqlParameter("@CategoryName", grdDocTypeCategory.Rows[grdDocTypeCategory.Rows.Count - 1].Cells["CategoryName"].Value.ToString()));


                    param.Add(new SqlParameter("@TypeCategoryID", ID));



                    //using (EFDbContext db = new EFDbContext())
                    //{
                    //    db.Database.ExecuteSqlCommand("UPDATE DocTypicalCategoryList SET CategoryName=@CategoryName WHERE TypeCategoryID=@TypeCategoryID", param.ToArray());
                    //}

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        
                        using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                        {
                            db.Database.ExecuteSqlCommand("UPDATE DocTypicalCategoryList SET CategoryName=@CategoryName WHERE TypeCategoryID=@TypeCategoryID", param.ToArray());
                        }
                    }
                    else
                    {
                        using (EFDbContext db = new EFDbContext())
                        {
                            db.Database.ExecuteSqlCommand("UPDATE DocTypicalCategoryList SET CategoryName=@CategoryName WHERE TypeCategoryID=@TypeCategoryID", param.ToArray());
                        }
                    }

                    fillDocTypeCategory();
                    //fillcolumncombo()
                    MessageBox.Show("Record updated", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void grdListitem_CellBeginEdit(System.Object sender, System.Windows.Forms.DataGridViewCellCancelEventArgs e)
        {
            try
            { 
                if (e.ColumnIndex == 2 && e.RowIndex > -1)
                {
                    grdListitem.Rows[e.RowIndex].Cells[2] = fillcolumncombo();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void grdListitem_CellClick(System.Object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex > -1)
            {
                try
                {
                    if (grdListitem.Columns[e.ColumnIndex].Name == "btnEdit")
                    {
                        //int ID = Convert.ToInt32(grdListitem.Rows[e.RowIndex].Cells["DocTypical_ID"].Value);
                        int ID;

                        if (grdListitem.Rows[e.RowIndex].Cells["DocTypical_ID"].Value == DBNull.Value )
                        {

                            ID = 0;
                        }
                        else
                        {
                            ID = Convert.ToInt32(grdListitem.Rows[e.RowIndex].Cells["DocTypical_ID"].Value);
                        }


                        //decimal unitPrice = Convert.ToDecimal(view.GetListSourceRowCellValue(listSourceRowIndex, "Each").Value);





                        //Get id of DocTypical Category
                        string str = grdListitem.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {


                            

                            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            {
                                //int queryDocCategoryID = db.Database.SqlQuery<int>("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'").FirstOrDefault();

                                string query1 = "SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'";

                                //grvPermitsRequiredInspection.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo.db.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvPermitsRequiredInspection.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'").SingleOrDefault();


                                int ID2 = 1;

                                using (TestVariousInfo_WithDataEntities db2 = new TestVariousInfo_WithDataEntities())
                                {
                                    var data = db2.Database.SqlQuery<TypeCategoryData>(query1).ToList();


                                    //var firstMedlem = medlem.Single();

                                    //string nameFromVar = data.FirstOrDefault().ToString ();

                                    //                             public string CategoryName { get; set; }
                                    //    public int DocTypical_ID { get; set; }
                                    //    public string DocTypical_Text { get; set; }
                                    //    public int DocTypical_Category { get; set; }


                                    string s = data[0].CategoryName;
                                    string s2 = data[0].CategoryName;



                                    //ID2 = Convert.ToInt32(data.ToString());
                                }



                                //int s = db.Database.SqlQuery<int>(str);
                                //int queryDocCategoryID = db.Database.SqlQuery<int>(str);

                                string DocTypical_TextStr = grdListitem.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();

                                //******
                                List<SqlParameter> Param = new List<SqlParameter>();

                                //Param.Add(new SqlParameter("@DocTypical_Category", ID2));
                                //Param.Add(new SqlParameter("@DocTypical_Text", grdListitem.Rows[e.RowIndex].Cells["DocTypical_Text"].Value.ToString()));

                                Param.Add(new SqlParameter("@DocTypical_Category", ID2));
                                Param.Add(new SqlParameter("@DocTypical_Text", DocTypical_TextStr));

                                Param.Add(new SqlParameter("@ID", ID));

                                string query = "";
                                query = "insert into DocTypicalListItem (DocTypical_Category,DocTypical_Text) values (@DocTypical_Category,@DocTypical_Text)";


                                db.Database.ExecuteSqlCommand("UPDATE DocTypicalListItem SET DocTypical_Category=@DocTypical_Category,DocTypical_Text=@DocTypical_Text WHERE DocTypical_ID=@ID", Param.ToArray());


                            }


                        }
                        else
                        {

                            using (EFDbContext db = new EFDbContext())
                            {
                                //int queryDocCategoryID = db.Database.SqlQuery<int>("SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'").FirstOrDefault();

                                string query1 = "SELECT TypeCategoryID FROM DocTypicalCategoryList WHERE CategoryName='" + str + "'";

                                //grvPermitsRequiredInspection.Rows[e.RowIndex].Cells["TrackSubID"].Value = repo.db.Database.SqlQuery<int>("SELECT Id FROM  MasterTrackSubItem WHERe TrackSubName='" + grvPermitsRequiredInspection.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + "'").SingleOrDefault();


                                int ID2 = 1;

                                using (EFDbContext db2 = new EFDbContext())
                                {
                                    var data = db2.Database.SqlQuery<TypeCategoryData>(query1).ToList();


                                    //var firstMedlem = medlem.Single();

                                    //string nameFromVar = data.FirstOrDefault().ToString ();

                                    //                             public string CategoryName { get; set; }
                                    //    public int DocTypical_ID { get; set; }
                                    //    public string DocTypical_Text { get; set; }
                                    //    public int DocTypical_Category { get; set; }


                                    string s = data[0].CategoryName;
                                    string s2 = data[0].CategoryName;



                                    //ID2 = Convert.ToInt32(data.ToString());
                                }



                                //int s = db.Database.SqlQuery<int>(str);
                                //int queryDocCategoryID = db.Database.SqlQuery<int>(str);

                                string DocTypical_TextStr = grdListitem.Rows[e.RowIndex].Cells["CategoryName"].Value.ToString();

                                //******
                                List<SqlParameter> Param = new List<SqlParameter>();

                                //Param.Add(new SqlParameter("@DocTypical_Category", ID2));
                                //Param.Add(new SqlParameter("@DocTypical_Text", grdListitem.Rows[e.RowIndex].Cells["DocTypical_Text"].Value.ToString()));

                                Param.Add(new SqlParameter("@DocTypical_Category", ID2));
                                Param.Add(new SqlParameter("@DocTypical_Text", DocTypical_TextStr));

                                Param.Add(new SqlParameter("@ID", ID));

                                string query = "";
                                query = "insert into DocTypicalListItem (DocTypical_Category,DocTypical_Text) values (@DocTypical_Category,@DocTypical_Text)";


                                db.Database.ExecuteSqlCommand("UPDATE DocTypicalListItem SET DocTypical_Category=@DocTypical_Category,DocTypical_Text=@DocTypical_Text WHERE DocTypical_ID=@ID", Param.ToArray());


                            }




                            /////
                        }
                    }


                    
                    fillDocListItem();
                    MessageBox.Show("Record updated.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.ColumnIndex == 1 && e.RowIndex > -1)
            {
                try
                {
                    if (MessageBox.Show("Are sure want to delete it?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int ID = Convert.ToInt32(grdListitem.Rows[e.RowIndex].Cells["DocTypical_ID"].Value);



                        //using (EFDbContext db = new EFDbContext())
                        //{
                        //    db.Database.ExecuteSqlCommand("DELETE FROM DocTypicalListItem WHERE DocTypical_ID=" + ID);
                        //}

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            
                            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                            {
                                db.Database.ExecuteSqlCommand("DELETE FROM DocTypicalListItem WHERE DocTypical_ID=" + ID);
                            }
                        }
                        else
                        {
                            using (EFDbContext db = new EFDbContext())
                            {
                                db.Database.ExecuteSqlCommand("DELETE FROM DocTypicalListItem WHERE DocTypical_ID=" + ID);
                            }
                        }


                        fillDocListItem();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        #endregion

        #region Methods
        private void fillDocListItem()
        {
            try
            {
                //VariousInfo = New VariousInfoEntities()
                string Query = "SELECT DocTypicalCategoryList.CategoryName, DocTypicalListItem.DocTypical_ID, DocTypicalListItem.DocTypical_Text, DocTypicalListItem.DocTypical_Category FROM DocTypicalCategoryList INNER JOIN DocTypicalListItem ON DocTypicalCategoryList.TypeCategoryID = DocTypicalListItem.DocTypical_Category"; //From a In VariousInfo.DocTypicalListItems Select a

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<DocTypeData>(Query).ToList();
                //    grdListitem.DataSource = data;
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<DocTypeData>(Query).ToList();
                        grdListitem.DataSource = data;
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<DocTypeData>(Query).ToList();
                        grdListitem.DataSource = data;
                    }

                }

                grdListitem.Columns["DocTypical_Category"].HeaderText = "Type Category";
                grdListitem.Columns["DocTypical_ID"].Visible = true;
                grdListitem.Columns["DocTypical_Text"].HeaderText = "Typical Text";
                grdListitem.Columns["DocTypical_Category"].Visible = false;
                grdListitem.Columns["DocTypical_Text"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdListitem.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
            }
        }

        public void fillDocTypeCategory()
        {
            try
            {
                //VariousInfo = New VariousInfoEntities()
                var Query = "SELECT * FROM DocTypicalCategoryList"; //From a In VariousInfo.DocTypicalCategoryLists Select a

                //using (EFDbContext db = new EFDbContext())
                //{
                //    grdDocTypeCategory.DataSource = db.Database.SqlQuery<TypeCategoryData>(Query).ToList();
                //}

                if (Properties.Settings.Default.IsTestDatabase == true)
                {                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        grdDocTypeCategory.DataSource = db.Database.SqlQuery<TypeCategoryData>(Query).ToList();
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        grdDocTypeCategory.DataSource = db.Database.SqlQuery<TypeCategoryData>(Query).ToList();
                    }
                }


                grdDocTypeCategory.Columns["TypeCategoryID"].Visible = true ;
                grdDocTypeCategory.Columns["CategoryName"].HeaderText = "Category Name";
                grdDocTypeCategory.Columns["CategoryName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {

            }
        }

        private DataGridViewComboBoxCell fillcolumncombo()
        {
            DataGridViewComboBoxCell columnComboBox = null;
            try
            {
                var query = "SELECT CategoryName FROM DocTypicalCategoryList";

                //using (EFDbContext db = new EFDbContext())
                //{
                //    var data = db.Database.SqlQuery<string>(query).ToList();

                //    columnComboBox = new DataGridViewComboBoxCell();
                //    foreach (var item in data)
                //    {
                //        columnComboBox.Items.Add(item);
                //    }
                //}


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    
                    using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                    {
                        var data = db.Database.SqlQuery<string>(query).ToList();

                        columnComboBox = new DataGridViewComboBoxCell();
                        foreach (var item in data)
                        {
                            columnComboBox.Items.Add(item);
                        }
                    }

                }
                else
                {
                    using (EFDbContext db = new EFDbContext())
                    {
                        var data = db.Database.SqlQuery<string>(query).ToList();

                        columnComboBox = new DataGridViewComboBoxCell();
                        foreach (var item in data)
                        {
                            columnComboBox.Items.Add(item);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return columnComboBox;
        }
        #endregion

        private void grdListitem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}