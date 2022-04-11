using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
//using Common;
using Commen2;
using System.Collections.Generic;
using DataAccessLayer.Repositories;
using DataAccessLayer.Model;

namespace JobTracker.JobTrackingForm
{
    public partial class frmInvoice : Form
    {
        #region Declaration
        private string stFileName;
        private string stFilePathAndName;
        private FileInfo MyFile;
        private long JobListID;
        private DataTable FileMultiDT = new DataTable();
        private static frmInvoice _Instance;
        private string CheckString;

        public static frmInvoice Instance
        {
            get
            {
                if (_Instance is null || _Instance.IsDisposed)
                {
                    _Instance = new frmInvoice();
                }

                return _Instance;
            }
        }
        #endregion
        public frmInvoice()
        {
            InitializeComponent();
        }

        #region Events
        private void frmInvoice_Deactivate(object sender, EventArgs e)
        {
            if (Program.CheckActiveWebUploadStatus() == true)
            {
                //frmAdmin.Invoice();
            }
        }
        private void frmInvoice_Disposed(object sender, EventArgs e)
        {
            if (Program.CheckActiveWebUploadStatus() == true)
            {
                //frmAdmin.Invoice();
            }
        }
        private void frmInvoice_Load(object sender, EventArgs e)
        {
            //var SqlCon = new DataAccessLayer();
            //Con = SqlCon.sqlcon;
            SetButtonGrdJoblist();
            FillGrid();
            CreatMultifileDataTable();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            FillGrid();
            CleartextBox();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                try
                {
                    if (txtInvoiceNo.Text.Trim() == string.Empty)
                    {
                        epEmptytext.SetError(txtInvoiceNo, "Please enter Invoice NO");
                        return;
                    }
                    else
                    {
                        epEmptytext.SetError(txtInvoiceNo, "");
                    }

                    bool ISUpload = true;
                    if ((stFilePathAndName ?? "") == (string.Empty ?? ""))
                    {
                        ISUpload = false;
                    }

                    string Query = "INSERT INTO invoice(JobListID,InvoiceDate,InvoiceNumber,InvoiceFileName,Comments,IsNewRecord,UploadFile) Values(@JobListID,@InvoiceDate,@InvoiceNumber,@InvoiceFileName,@Comments,@IsNewRecord,@IsUpload)";
                    List<SqlParameter> Param = new List<SqlParameter>();
                    Param.Add(new SqlParameter("@JobListID", grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobListID"].Value.ToString()));
                    Param.Add(new SqlParameter("@InvoiceDate", Strings.Format(dtpInvoiceDate.Value, "MM/dd/yyyy")));
                    Param.Add(new SqlParameter("@InvoiceNumber", txtInvoiceNo.Text.Trim()));
                    Param.Add(new SqlParameter("@InvoiceFileName", stFileName));
                    Param.Add(new SqlParameter("@Comments", txtComments.Text));
                    Param.Add(new SqlParameter("@IsNewRecord", 1));
                    Param.Add(new SqlParameter("@IsUpload", ISUpload));
                    // Param.Add(new SqlParameter("@IsUpload", ISUpload)


                    //StMethod.LoginActivityInfo("Insert", this.Name);
                    //int Id = StMethod.UpdateRecord(Query, Param);

                    int Id;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.LoginActivityInfoNew("Insert", this.Name);
                        Id = StMethod.UpdateRecordNew(Query, Param);
                    }
                    else
                    {
                        StMethod.LoginActivityInfo("Insert", this.Name);
                        Id = StMethod.UpdateRecord(Query, Param);
                    }

                    //cmd.CommandText = "select ISNULL(max(invoiceID),0) as id from Invoice";
                    //cmd.Connection = Con;
                    //Con.Open();
                    //int Id = Conversions.ToInteger(cmd.ExecuteScalar());
                    //Con.Close();
                    InsertFile(Id);
                    CleartextBox();
                    KryptonMessageBox.Show("Save Successfully", "JT Upload Scan Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SqlException ex)
                {
                }
            }
            else
            {
                // ********Save Multi Selected invoice file*********
                SaveMultiSelectedFile();
                // *****************************
            }

            FillInvocegrid(Convert.ToInt64(grdJobList.Rows[grdJobList.SelectedRows[0].Index].Cells["JobListID"].Value));
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                //change Size of TableLayoutPanl
                grdSelectMultiFileInvoice.Visible = false;
                pnlInvoice.Visible = true;
                TblLayPnlInvoiceUpload.SetRowSpan(pnlJobNo, 1);
                TblLayPnlInvoiceUpload.SetRowSpan(pnlInvoice, 1);
                TblLayPnlInvoiceUpload.SetRowSpan(pnlSaveDataControl, 1);
                TblLayPnlInvoiceUpload.RowStyles[0].SizeType = SizeType.Percent;
                TblLayPnlInvoiceUpload.RowStyles[1].SizeType = SizeType.Percent;
                TblLayPnlInvoiceUpload.RowStyles[2].SizeType = SizeType.Percent;
                btnSave.Text = "Save";
                //********************************
                OpenFileDialog BrowesFile = new OpenFileDialog();
                BrowesFile.Title = "Open Invoice File";
                BrowesFile.Filter = "All Files(*.*)|*.*|(*.pdf)|*.pdf";


                if(Directory.Exists("N:\\transfer\\PDF invoice\\upload temp file"))
                {
                    BrowesFile.InitialDirectory = "N:\\transfer\\PDF invoice\\upload temp file";
                    
                }
                else
                {
                    BrowesFile.InitialDirectory = "C:\\";
                }

                
                if (BrowesFile.ShowDialog() == DialogResult.OK)
                {
                    stFilePathAndName = BrowesFile.FileName;
                    MyFile = new FileInfo(stFilePathAndName);
                    txtJobNumber.Text = Program.GetJobNumber(MyFile.Name.Replace(MyFile.Extension, string.Empty));
                    FillGrid();
                    txtInvoiceNo.Text = MyFile.Name.Replace(MyFile.Extension, string.Empty);
                    txtFileName.Text = MyFile.Name.Replace(MyFile.Extension, string.Empty);
                    txtInvoiceNo.Text = MyFile.Name.Replace(MyFile.Extension, string.Empty);
                    txtFileName.Text = MyFile.Name.Replace(MyFile.Extension, string.Empty);

                    stFileName = txtFileName.Text.Trim();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void txtInvoiceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter | e.KeyCode == Keys.Tab)
            {
                try
                {
                    txtFileName.Text = grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString() + "-" + txtInvoiceNo.Text;
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void grdJobList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FillInvocegrid(Convert.ToInt64(grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobListID"].Value));
            stFilePathAndName = string.Empty;
            stFileName = string.Empty;
        }
        private void txtJobNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (grdJobList.Rows.Count == 0)
            {
                if (Microsoft.VisualBasic.Strings.Asc(e.KeyChar) == 13 || Microsoft.VisualBasic.Strings.Asc(e.KeyChar) == 8)
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
        private void txtTextBox_TextChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void BindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {
            grdJobList.CurrentCell = grdJobList.Rows[0].Cells["JobNumber"];
            grdJobList.Rows[0].Selected = true;
            // grdJobList.Rows[grdJobList.CurrentRow.Index].Selected = False
            FillInvocegrid(Convert.ToInt64(grdJobList.Rows[grdJobList.SelectedRows[0].Index].Cells["JobListID"].Value));
        }
        private void BindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {
            int Pos = Convert.ToInt32(bindNaviTestPos.Text);
            if (Pos >= 0)
            {
                grdJobList.CurrentCell = grdJobList.Rows[Pos - 2].Cells["JobNumber"];
                grdJobList.Rows[Pos - 2].Selected = true;
                FillInvocegrid(Convert.ToInt64(grdJobList.Rows[grdJobList.SelectedRows[0].Index].Cells["JobListID"].Value));
            }
        }
        private void BindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {
            int Pos = Convert.ToInt32(bindNaviTestPos.Text);
            if (Pos <= grdJobList.Rows.Count - 1)
            {
                grdJobList.CurrentCell = grdJobList.Rows[Pos].Cells["JobNumber"];
                grdJobList.Rows[Pos].Selected = true;
                grdJobList.Rows[Pos - 1].Selected = false;
                FillInvocegrid(Convert.ToInt64(grdJobList.Rows[grdJobList.SelectedRows[0].Index].Cells["JobListID"].Value));
            }
        }
        private void BindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {
            int Pos = grdJobList.Rows.Count;
            grdJobList.CurrentCell = grdJobList.Rows[Pos - 1].Cells["JobNumber"];
            grdJobList.Rows[Pos - 1].Selected = true;
            FillInvocegrid(Convert.ToInt64(grdJobList.Rows[grdJobList.SelectedRows[0].Index].Cells["JobListID"].Value));
        }
        private void bindNaviTestPos_KeyPress(object sender, KeyPressEventArgs e)
        {
            int Pos = Convert.ToInt32(bindNaviTestPos.Text);
            if (Microsoft.VisualBasic.Strings.Asc(e.KeyChar) == 13)
            {
                if (Convert.ToInt32(bindNaviTestPos.Text.Trim()) >= 0 & Convert.ToInt32(bindNaviTestPos.Text.Trim()) <= grdJobList.Rows.Count)
                {
                    grdJobList.CurrentCell = grdJobList.Rows[Pos - 1].Cells["JobNumber"];
                    grdJobList.Rows[Pos - 1].Selected = true;
                    FillInvocegrid(Convert.ToInt64(grdJobList.Rows[grdJobList.SelectedRows[0].Index].Cells["JobListID"].Value));
                }
                else
                {
                    bindNaviTestPos.Text = "1";
                }
            }
        }
        private void chkBoxActiveDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxActiveDate.Checked == true)
            {
                pnlDate.Enabled = true;
            }
            else
            {
                pnlDate.Enabled = false;
            }

            FillGrid();
        }
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
        private void grdInvoice_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex > -1 | e.RowIndex > -1)
            {
                CheckString = string.Empty;
                CheckString = grdInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
        private void grdInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(grdInvoice.Columns[e.ColumnIndex].HeaderText.ToString());

            //MessageBox.Show(grdInvoice.Columns[e.ColumnIndex].ToString());

            if (e.ColumnIndex == 0 & e.RowIndex > -1)
            {
                try
                {
                    string Date101, Date102 = null;

                    if (grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Value == null || grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Value == DBNull.Value || String.IsNullOrWhiteSpace(grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Value.ToString()))
                    {
                        // here is your message box...


                    }
                    else
                    {
                        //Date101 = grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString();
                        Date101 = string.Format("{0:dd/MM/yyyy}", grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Value.ToString());
                    }

                    if (grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Tag == null || grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Tag == DBNull.Value || String.IsNullOrWhiteSpace(grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Tag.ToString()))
                    {
                        // here is your message box...

                        //grdTaskList.Rows[e.RowIndex].Cells["Date"].Tag
                        //e.Value = string.Format("{0:MM/dd/yyyy}", dDate);

                        //Date102 = string.Format("{0:MM/dd/yyyy}", grdTimeAndExp.Rows[e.RowIndex].Cells["Date"].Value.ToString());
                        Date102 = string.Format("{0:dd/MM/yyyy}", grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Value.ToString());

                        //Date102 = grdTaskList.Rows[e.RowIndex].Cells["Date"].Value.ToString();

                    }
                    else
                    {
                        Date102 = grdInvoice.Rows[e.RowIndex].Cells["InvoiceDate"].Tag.ToString();
                    }

                    string query = "UPDATE Invoice SET InvoiceDate=@InvoiceDate,InvoiceNumber=@InvoiceNumber,Comments=@Comments,InvoiceFileName=@InvoiceFileName,IsChange=@IsChange,ChangeDate=@ChangeDate WHERE invoiceID=@invoiceID";

                    List<SqlParameter> param = new List<SqlParameter>();



                    //DateTime Dn = Convert.ToDateTime(grdTaskList.Rows[grdTaskList.Rows.Count - 1].Cells["Date"].Value.ToString());
                    //string DNStr = "";
                    //DNStr = Dn.Month + "-" + Dn.Day + "-" + Dn.Year + " " + Dn.ToLongTimeString();
                    //param1.Add(new SqlParameter("@Date", DNStr.ToString()));


                    //DateTime InvoiceDate = Convert.ToDateTime(grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value.ToString());
                    //string InvoiceDateStr = "";
                    //InvoiceDateStr = InvoiceDate.Month + "-" + InvoiceDate.Day + "-" + InvoiceDate.Year + " " + InvoiceDate.ToLongTimeString();

                    //param.Add(new SqlParameter("@InvoiceDate", InvoiceDateStr.ToString ()));

                    param.Add(new SqlParameter("@InvoiceDate", Date102));

                    //param.Add(new SqlParameter("@InvoiceDate", grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceDate"].Value.ToString()));


                    param.Add(new SqlParameter("@InvoiceNumber", grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceNumber"].Value.ToString()));
                    param.Add(new SqlParameter("@InvoiceFileName", grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceFileName"].Value.ToString()));
                    param.Add(new SqlParameter("@Comments", grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["Comments"].Value.ToString()));
                    param.Add(new SqlParameter("@InvoiceID", grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["invoiceID"].Value.ToString()));
                    param.Add(new SqlParameter("@IsChange", 1));
                    param.Add(new SqlParameter("@ChangeDate", Strings.Format(DateTime.Now, "MM/dd/yyyy")));

                    int Update;
                    //Update = StMethod.UpdateRecord(query,param);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        Update = StMethod.UpdateRecordNew(query, param);

                    }
                    else
                    {
                        Update = StMethod.UpdateRecord(query, param);
                    }

                    InsertFile(Convert.ToInt32(grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceID"].Value));
                    if (Update == 1)
                    {
                        grdInvoice.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                        grdInvoice.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                        KryptonMessageBox.Show("Update Successfully", "Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //StMethod.LoginActivityInfo("Update", this.Name);

                        if (Properties.Settings.Default.IsTestDatabase == true)
                        {
                            StMethod.LoginActivityInfoNew("Update", this.Name);

                        }
                        else
                        {
                            StMethod.LoginActivityInfo("Update", this.Name);
                        }

                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }

                grdJobList_CellClick(sender, e);
            }

            if (e.ColumnIndex == 2 & e.RowIndex > -1)
            {
                btnBrowse_Click(sender, e);
                try
                {
                    //grdInvoice.Rows[e.RowIndex].Cells["InvoiceFileName"].Value = grdJobList.Rows[grdJobList.CurrentRow.Index].Cells["JobNumber"].Value.ToString() + "-" + grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceNumber"].Value.ToString();
                    stFileName = grdInvoice.Rows[e.RowIndex].Cells["InvoiceFileName"].Value.ToString();
                }
                catch (Exception ex)
                {
                }
            }

            if (e.RowIndex > -1 & e.ColumnIndex == 1)
            {
                //Int32 i = StMethod.UpdateRecord("UPDATE Invoice SET IsDelete=1 WHERE InvoiceID=" + grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceID"].Value.ToString());

                Int32 i;

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    i = StMethod.UpdateRecordNew("UPDATE Invoice SET IsDelete=1 WHERE InvoiceID=" + grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceID"].Value.ToString());

                }
                else
                {
                    i = StMethod.UpdateRecord("UPDATE Invoice SET IsDelete=1 WHERE InvoiceID=" + grdInvoice.Rows[grdInvoice.CurrentRow.Index].Cells["InvoiceID"].Value.ToString());
                }

                if (i == 1)
                {
                    KryptonMessageBox.Show("Record Deleted", "Job Tracking");
                    //StMethod.LoginActivityInfo("Delete", this.Name);

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {

                        StMethod.LoginActivityInfoNew("Delete", this.Name);
                    }
                    else
                    {
                        StMethod.LoginActivityInfo("Delete", this.Name);
                    }
                }
                FillInvocegrid(Convert.ToInt64(grdJobList.Rows[grdJobList.SelectedRows[0].Index].Cells["JobListID"].Value));
            }
        }
        private void grdInvoice_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                //String value2 = grdInvoice.Rows[e.RowIndex].Cells[7].Value.ToString() as string;

                // If e.ColumnIndex = 6 And e.RowIndex > -1 Then
                // grdInvoice.Rows[e.RowIndex].Cells["InvoiceFileName"].Value = grdJobList.Rows["JobNumber", grdJobList.CurrentRow.Index].Value.ToString & "-" & grdInvoice.Rows["InvoiceNumber", grdInvoice.CurrentRow.Index].Value.ToString
                // stFileName = grdInvoice.Rows[e.RowIndex].Cells["InvoiceFileName"].Value.ToString
                // End If
                if (grdInvoice.Columns[e.ColumnIndex].Name == "InvoiceFileName" & e.RowIndex > -1)
                {
                    stFileName = grdInvoice.Rows[e.RowIndex].Cells["InvoiceFileName"].Value.ToString();
                }

                String value2 = grdInvoice.Rows[e.RowIndex].Cells[5].Value.ToString() as string;

                if (e.ColumnIndex == 5)
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

                            //grdInvoice.Rows[e.RowIndex].Cells[7].Value = value2;
                            grdInvoice.Rows[e.RowIndex].Cells[5].Value = value2;
                            grdInvoice.Rows[e.RowIndex].Cells[5].Tag = inputString;

                        }
                        else
                        {
                            grdInvoice.Rows[e.RowIndex].Cells[5].Tag = inputString;

                        }


                    }
                    else
                    {
                        //e.Value = e.CellStyle.NullValue;
                        //e.FormattingApplied = true;
                    }

                }
                else
                {
                    //e.Value = e.CellStyle.NullValue;
                    //e.FormattingApplied = true;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            try
            {
                if (e.ColumnIndex > -1 | e.RowIndex > -1)
                {
                    if (grdInvoice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != CheckString)
                    {
                        grdInvoice.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Pink;
                        grdInvoice.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Pink;
                        CheckString = string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            // txtFileName.Text = grdJobList.Rows["JobNumber", grdJobList.CurrentRow.Index].Value.ToString & "-" & txtInvoiceNo.Text
            // stFileName = txtFileName.Text.Trim
        }
        private void dtpFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Microsoft.VisualBasic.Strings.Asc(e.KeyChar) == 13)
            {
                FillGrid();
                dtpTo.Focus();
            }
        }
        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            stFileName = txtFileName.Text;
        }
        private void btnBrowseMultiFile_Click(object sender, EventArgs e)
        {
            TblLayPnlInvoiceUpload.SetRowSpan(pnlJobNo, 1);
            grdSelectMultiFileInvoice.Visible = true;
            pnlInvoice.Visible = false;
            TblLayPnlInvoiceUpload.RowStyles[1].SizeType = SizeType.Absolute;
            btnSave.Text = "Save All";
            FetchAllSelectedFile();
        }
        private void grdSelectMultiFileInvoice_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 & e.RowIndex != -1)
            {
                grdSelectMultiFileInvoice.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            grdSelectMultiFileInvoice.Visible = false;
            pnlInvoice.Visible = true;
            TblLayPnlInvoiceUpload.SetRowSpan(pnlJobNo, 1);
            TblLayPnlInvoiceUpload.SetRowSpan(pnlInvoice, 1);
            TblLayPnlInvoiceUpload.SetRowSpan(pnlSaveDataControl, 1);
            TblLayPnlInvoiceUpload.RowStyles[0].SizeType = SizeType.Percent;
            TblLayPnlInvoiceUpload.RowStyles[1].SizeType = SizeType.Percent;
            TblLayPnlInvoiceUpload.RowStyles[2].SizeType = SizeType.Percent;
            btnSave.Text = "Save";
            stFilePathAndName = string.Empty;
            stFileName = string.Empty;
        }
        private void frmInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            // frmAdmin.Invoice
        }
        #endregion

        #region Methods
        private void InsertFile(int GetID)
        {
            if ((stFilePathAndName ?? "") == (string.Empty ?? ""))
            {
                return;
            }

            byte[] data;
            try
            {
                long Filesize = MyFile.Length;
                var fStream = new FileStream(stFilePathAndName, FileMode.Open, FileAccess.Read);
                var Br = new BinaryReader(fStream);
                data = Br.ReadBytes((int)Filesize);
                // Catch ex As Exception

                // End Try
                // Try
                string query = "UPDATE Invoice set InvoiceFile=@InvoiceFile,InvoiceFileName=@InvoiceFileName,InvoiceFileType=@FileType,UploadFile=@IsUpload where invoiceID=@InvoiceID";


                List<SqlParameter> Param = new List<SqlParameter>();
                Param.Add(new SqlParameter("@InvoiceFile", data));
                Param.Add(new SqlParameter("@InvoiceID", GetID));
                Param.Add(new SqlParameter("@IsUpload", 1));
                Param.Add(new SqlParameter("@InvoiceFileName", stFileName));
                Param.Add(new SqlParameter("@FileType", MyFile.Extension.ToString()));
                
                //StMethod.UpdateRecord(query, Param);
                //StMethod.LoginActivityInfo("Update", this.Name);


                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    StMethod.UpdateRecordNew(query, Param);
                    StMethod.LoginActivityInfoNew("Update", this.Name);



                }
                else
                {
                    StMethod.UpdateRecord(query, Param);
                    StMethod.LoginActivityInfo("Update", this.Name);


                }


                stFilePathAndName = string.Empty;
            }
            catch (SqlException ex)
            {
            }
            finally
            {
                stFilePathAndName = string.Empty;
                stFileName = string.Empty;
            }
        }
        private void FillInvocegrid(long JobListID)
        {
            var dt = new DataTable();
            // JobListID = grdJobList.Rows["JobListID", grdJobList.CurrentRow.Index].Value.ToString
            string Query = "SELECT  InvoiceID, JobListID, InvoiceDate, InvoiceNumber, InvoiceFileName, InvoiceFile, Comments,( CASE isnull(UploadFile,0) WHEN 'False' THEN 'Invoice Not Available' WHEN 'True' THEN 'Invoice Availble' WHEN 0  THEN 'Invoice Not Available' END ) as IsUploadInvoice  FROM Invoice   WHERE (IsDelete = 0 Or IsDelete Is null) AND JobListID =" + JobListID + " ORDER BY InvoiceDate";

            //dt = StMethod.GetListDT<InvoiceUpload>(Query);


            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                dt = StMethod.GetListDTNew<InvoiceUpload>(Query);

            }
            else
            {
                dt = StMethod.GetListDT<InvoiceUpload>(Query);
            }

            {
                var withBlock = grdInvoice;
                withBlock.DataSource = dt;
                withBlock.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                withBlock.Columns["InvoiceNumber"].HeaderText = "Invoice Number";
                withBlock.Columns["InvoiceFileName"].HeaderText = "Invoice File";
                withBlock.Columns["InvoiceFile"].Visible = false;
                withBlock.Columns["Comments"].HeaderText = "Comments";
                withBlock.Columns["IsUploadInvoice"].HeaderText = "Invoice File Status";
                withBlock.Columns["JobListID"].Visible = false;
                withBlock.Columns["InvoiceID"].Visible = false;
            }
        }
        private void CleartextBox()
        {
            this.txtInvoiceNo.Text = string.Empty;
            this.txtFileName.Text = string.Empty;
            this.txtComments.Text = string.Empty;
            
            // Me.txtJobNumber.Text = String.Empty
            // Me.txtClientName.Text = String.Empty
            // Me.cmbStatus.SelectedIndex = 0
            stFilePathAndName = string.Empty;
            epEmptytext.SetError(txtInvoiceNo, "");
        }
        private void SetButtonGrdJoblist()
        {
            var dt = new DataTable();
            var BrowseGridBtn = new DataGridViewButtonColumn();
            
            string Query = "SELECT  InvoiceID, JobListID, InvoiceDate, InvoiceNumber, InvoiceFileName, InvoiceFile, Comments, ( case UploadFile when 'False' then 'Invoice Not Available' when 'True' then 'Invoice Availble' end ) as IsUploadInvoice,InvoiceFileType  FROM Invoice   WHERE (IsDelete = 0 Or IsDelete Is null)";


            //dt = StMethod.GetListDT<InvoiceUpload>(Query);

            if (Properties.Settings.Default.IsTestDatabase == true)
            {
                dt = StMethod.GetListDTNew<InvoiceUpload>(Query);

            }
            else
            {
                dt = StMethod.GetListDT<InvoiceUpload>(Query);
            }

            BrowseGridBtn.Name = "BrowseBtn";
            BrowseGridBtn.DisplayIndex = 11;
            BrowseGridBtn.HeaderText = "Browse";
            BrowseGridBtn.DataPropertyName = "grdBrowseBtn";
            BrowseGridBtn.Text = "Browse";
            BrowseGridBtn.UseColumnTextForButtonValue = true;
            grdInvoice.DataSource = dt;
            {
                var withBlock = grdInvoice;
                withBlock.DataSource = dt;
                withBlock.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                withBlock.Columns["InvoiceNumber"].HeaderText = "Invoice Number";
                withBlock.Columns["InvoiceFileName"].HeaderText = "Invoice File";
                withBlock.Columns["InvoiceFile"].Visible = false;
                withBlock.Columns["Comments"].HeaderText = "Comments";
                withBlock.Columns["IsUploadInvoice"].HeaderText = "Invoice File Status";
                withBlock.Columns["JobListID"].Visible = false;
                withBlock.Columns["InvoiceID"].Visible = false;
                withBlock.Columns["InvoiceFileType"].Visible = false;
            }

            grdInvoice.Columns.Add(BrowseGridBtn);
        }
        private void FillGrid()
        {
            string query;
            try
            {
                var dt = new DataTable();
                query = "SELECT JobListID, JobNumber, Address, ContactsName, CompanyID, CompanyName , EmailAddress,DateAdded, Description FROM InvoiceJobList WHERE JobListID<>0";
                if (txtJobNumber.Text != string.Empty)
                {
                    query = query + " AND  JobNumber like '%" + txtJobNumber.Text.Trim() + "%'";
                }

                if (txtClientName.Text != string.Empty)
                {
                    query = query + " AND ContactsName like '%" + txtClientName.Text.Trim() + "%'";
                }

                if (txtCompanyName.Text != string.Empty)
                {
                    query = query + " AND CompanyName like '%" + txtCompanyName.Text.Trim() + "%'";
                }

                if (txtAddress.Text != string.Empty)
                {
                    query = query + " AND Address like '%" + txtAddress.Text.Trim() + "%'";
                }
                
                if (chkBoxActiveDate.CheckState == CheckState.Checked)
                {
                    if (Operators.CompareString(Strings.Format(dtpTo.Value, "yyyy/MM/dd"), Strings.Format(dtpFrom.Value, "yyyy/MM/dd"), false) >= 0)
                    {
                        query = query + " AND DateAdded BETWEEN '" + Strings.Format(dtpFrom.Value, "yyyy/MM/dd") + "' AND '" + Strings.Format(dtpTo.Value, "yyyy/MM/dd") + "'";
                    }
                    else
                    {
                        KryptonMessageBox.Show("Added To date must greater then or equal Added From date", "Jobtracking");
                    }
                }

                query = query + " ORDER BY JobNumber";

                //dt = StMethod.GetListDT<InvJobList>(query);

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    dt = StMethod.GetListDTNew<InvJobList>(query);
                }
                else
                {
                    dt = StMethod.GetListDT<InvJobList>(query);
                }

                var BindSource = new BindingSource();
                grdJobList.DataSource = dt;
                BindSource.DataSource = dt;
                BindNaviGrdJoblist.BindingSource = BindSource;
                if (dt.Rows.Count > 0)
                {
                    grdJobList.DataSource = dt;
                    {
                        var withBlock = grdJobList;
                        withBlock.Columns["JobNumber"].HeaderText = "Job Number";
                        withBlock.Columns["ContactsName"].HeaderText = "Client Name";
                        withBlock.Columns["Address"].HeaderText = " Address";
                        withBlock.Columns["JobListID"].Visible = false;
                        withBlock.Columns["CompanyID"].Visible = false;
                        withBlock.Columns["CompanyName"].HeaderText = "Company Name";
                        withBlock.Columns["EmailAddress"].HeaderText = "Email Address";
                        withBlock.Columns["DateAdded"].HeaderText = "Date Added";
                    }
                    JobListID = Convert.ToInt64(grdJobList.Rows[grdJobList.SelectedRows[0].Index].Cells["JobListID"].Value);
                    FillInvocegrid(JobListID);
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void CreatMultifileDataTable()
        {
            try
            {
                FileMultiDT.Columns.Add("JobListID");
                FileMultiDT.Columns.Add("JobNumber");
                FileMultiDT.Columns.Add("FilePath");
                FileMultiDT.Columns.Add("InvoiceDate");
                FileMultiDT.Columns.Add("InvoiceNumber");
                FileMultiDT.Columns.Add("InvoiceFileName");
                FileMultiDT.Columns.Add("InvoiceFile");
                FileMultiDT.Columns.Add("InvoiceFileType");
                FileMultiDT.Columns.Add("Comments");
                FileMultiDT.Columns.Add("UploadFile");
            }
            catch (Exception ex)
            {
            }
        }
        private void FetchAllSelectedFile()
        {
            FileMultiDT.Rows.Clear();
            var BrowesFile = new OpenFileDialog();
            BrowesFile.Title = "Open Invoice File";
            BrowesFile.Filter = "All Files(*.*)|*.*|(*.pdf)|*.pdf";
            BrowesFile.InitialDirectory = @"N:\transfer\PDF invoice\upload temp file";
            BrowesFile.Multiselect = true;
            if (BrowesFile.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0, loopTo = BrowesFile.FileNames.Length - 1; i <= loopTo; i++)
                {
                    stFilePathAndName = BrowesFile.FileName;
                    MyFile = new FileInfo(BrowesFile.FileNames[i].ToString());
                    DataRow Dr = FileMultiDT.NewRow();
                    Dr["JobListID"] = GetJoblistID(GenericHelper.GetJobNumber(MyFile.Name.Replace(MyFile.Extension, string.Empty)));
                    Dr["InvoiceDate"] = Strings.Format(DateTime.Now, "MM/dd/yyyy");
                    Dr["InvoiceNumber"] = MyFile.Name.Replace(MyFile.Extension, string.Empty);
                    Dr["InvoiceFileName"] = MyFile.Name.Replace(MyFile.Extension, string.Empty);
                    Dr["InvoiceFileType"] = MyFile.Extension;
                    Dr["UploadFile"] = true;
                    Dr["JobNumber"] = GenericHelper.GetJobNumber(MyFile.Name.Replace(MyFile.Extension, string.Empty));
                    Dr["FilePath"] = BrowesFile.FileNames[i].ToString();
                    FileMultiDT.Rows.Add(Dr);
                }

                FillMultiSelectFileGrd();
            }
        }
        public long GetJoblistID(string JobNumber)
        {
            try
            {
                //return StMethod.GetSingleInt("SELECT JobListID FROM JobList WHERE JobNumber='" + JobNumber + "'");

                if (Properties.Settings.Default.IsTestDatabase == true)
                {

                    return StMethod.GetSingleIntNew("SELECT JobListID FROM JobList WHERE JobNumber='" + JobNumber + "'");
                }
                else
                {
                    return StMethod.GetSingleInt("SELECT JobListID FROM JobList WHERE JobNumber='" + JobNumber + "'");
                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Fetching MultiInvoice File Failed due to=" + ex.Message);
            }

            return 0L;
        }
        public string AddJstrInInvoiceNo(string InvoiceNo)
        {
            try
            {
                if (InvoiceNo.Substring(InvoiceNo.Length - 1) == "j")
                {
                    return InvoiceNo;
                }
                else
                {
                    return InvoiceNo + "j";
                }
            }
            catch (Exception ex)
            {
            }

            return default;
        }
        private void FillMultiSelectFileGrd()
        {
            try
            {
                grdSelectMultiFileInvoice.DataSource = FileMultiDT;
                {
                    var withBlock = grdSelectMultiFileInvoice;
                    withBlock.Columns["InvoiceDate"].HeaderText = "Invoice Date";
                    withBlock.Columns["InvoiceNumber"].HeaderText = "Invoice No";
                    withBlock.Columns["InvoiceFileName"].HeaderText = "Invoice File Name";
                    withBlock.Columns["InvoiceFileType"].Visible = false;
                    withBlock.Columns["UploadFile"].HeaderText = "File Uploaded";
                    withBlock.Columns["UploadFile"].ReadOnly = true;
                    withBlock.Columns["JobNumber"].HeaderText = "Job Number";
                    withBlock.Columns["FilePath"].HeaderText = "File Path";
                    withBlock.Columns["JobListID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void SaveMultiSelectedFile()
        {
            try
            {
                foreach (DataGridViewRow Row in grdSelectMultiFileInvoice.Rows)
                {
                    stFilePathAndName = grdSelectMultiFileInvoice.Rows[Row.Index].Cells["FilePath"].Value.ToString();
                    MyFile = new FileInfo(stFilePathAndName);
                    stFileName = grdSelectMultiFileInvoice.Rows[Row.Index].Cells["InvoiceFileName"].Value.ToString();
                    bool ISUpload = true;
                    if ((stFilePathAndName ?? "") == (string.Empty ?? ""))
                    {
                        ISUpload = false;
                    }

                    string Query = "INSERT INTO invoice(JobListID,InvoiceDate,InvoiceNumber,InvoiceFileName,Comments,IsNewRecord,UploadFile) Values(@JobListID,@InvoiceDate,@InvoiceNumber,@InvoiceFileName,@Comments,@IsNewRecord,@IsUpload)";
                    List<SqlParameter> param = new List<SqlParameter>();
                    param.Add(new SqlParameter("@JobListID", grdSelectMultiFileInvoice.Rows[Row.Index].Cells["JobListID"].Value.ToString()));
                    param.Add(new SqlParameter("@InvoiceDate", grdSelectMultiFileInvoice.Rows[Row.Index].Cells["InvoiceDate"].Value.ToString()));
                    param.Add(new SqlParameter("@InvoiceNumber", grdSelectMultiFileInvoice.Rows[Row.Index].Cells["InvoiceNumber"].Value.ToString()));
                    param.Add(new SqlParameter("@InvoiceFileName", grdSelectMultiFileInvoice.Rows[Row.Index].Cells["InvoiceFileName"].Value.ToString()));
                    param.Add(new SqlParameter("@Comments", grdSelectMultiFileInvoice.Rows[Row.Index].Cells["Comments"].Value.ToString()));
                    param.Add(new SqlParameter("@IsNewRecord", 1));
                    param.Add(new SqlParameter("@IsUpload", ISUpload));
                    // param.Add(new SqlParameter("@IsUpload", ISUpload)

                    //StMethod.UpdateRecord(Query, param);
                    //int id= StMethod.GetSingleInt("select ISNULL(max(invoiceID),0) as id from Invoice");

                    int id;

                    if (Properties.Settings.Default.IsTestDatabase == true)
                    {
                        StMethod.UpdateRecordNew(Query, param);
                        id = StMethod.GetSingleIntNew("select ISNULL(max(invoiceID),0) as id from Invoice");

                    }
                    else
                    {
                        StMethod.UpdateRecord(Query, param);
                        id= StMethod.GetSingleInt("select ISNULL(max(invoiceID),0) as id from Invoice");
                    }

                    InsertFile(id);
                    CleartextBox();
                }
                // change Size of TableLayoutPanl
                grdSelectMultiFileInvoice.Visible = false;
                pnlInvoice.Visible = true;
                TblLayPnlInvoiceUpload.SetRowSpan(pnlJobNo, 1);
                TblLayPnlInvoiceUpload.SetRowSpan(pnlInvoice, 1);
                TblLayPnlInvoiceUpload.SetRowSpan(pnlSaveDataControl, 1);
                TblLayPnlInvoiceUpload.RowStyles[0].SizeType = SizeType.Percent;
                TblLayPnlInvoiceUpload.RowStyles[1].SizeType = SizeType.Percent;
                TblLayPnlInvoiceUpload.RowStyles[2].SizeType = SizeType.Percent;
                btnSave.Text = "Save";
                stFilePathAndName = string.Empty;
                stFileName = string.Empty;

                // ********************************
                KryptonMessageBox.Show("Save Successfully", "JT Upload Scan Invoice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("Fetching MultiInvoice File Saved Failed due to=" + ex.Message);
            }
        }
        #endregion

        private void bindNaviTestPos_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try

            {


                //if(char.IsLetter(e.KeyChar) == true )
                //{
                //    e.Handled = false;
                //}

                e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8);


                //if (char.IsDigit(e.KeyChar) == true || e.KeyChar == 8)
                //{
                //    e.Handled = false;
                //}
                //else
                //{
                //    e.Handled = true;
                //}

                //        Dim Pos As Integer = Val(bindNaviTestPos.Text)
                //If Asc(e.KeyChar) = 13 Then
                //    If Val(bindNaviTestPos.Text.Trim) >= 0 And Val(bindNaviTestPos.Text.Trim) <= grdJobList.Rows.Count Then
                //        grdJobList.CurrentCell = grdJobList.Rows(Pos - 1).Cells("JobNumber")
                //        grdJobList.Rows(Pos - 1).Selected = True
                //        FillInvocegrid(grdJobList.Item("JobListID", grdJobList.SelectedRows.Item(0).Index).Value.ToString)
                //    Else
                //        bindNaviTestPos.Text = 1
                //    End If
                //End If

                int pos;
                if (grdJobList.Rows.Count > 0)
                {
                    if (string.IsNullOrEmpty(bindNaviTestPos.Text) == true)
                    {
                        pos = 1;
                        bindNaviTestPos.Text = "1";
                    }
                    else
                    {
                        pos = Convert.ToInt32(bindNaviTestPos.Text);
                    }

                    


                    if (e.KeyChar == 13)
                    {
                        //if (pos >= 0 || pos <= grdJobList.Rows.Count-1)

                            if (pos >= 0 || pos <= grdJobList.Rows.Count - 1)
                            {                            
                            grdJobList.CurrentCell = grdJobList.Rows[pos - 1].Cells["JobNumber"];                            
                            //grdJobList.CurrentRow = grdJobList.Rows[pos - 1];
                            grdJobList.Rows[pos - 1].Selected = true;
                            //FillInvocegrid(Convert.ToInt64(grdJobList.Rows[pos-1].Cells["JobListID"].Value));
                            stFilePathAndName = string.Empty;
                            stFileName = string.Empty;
                        }
                        else
                        {
                            bindNaviTestPos.Text = "1";
                        }
                    }
                }
                

            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("" + ex.Message);
            }
        }

        private void grdInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //string Query = "SELECT  InvoiceID, JobListID, InvoiceDate, InvoiceNumber, InvoiceFileName, InvoiceFile, Comments,( CASE isnull(UploadFile,0) WHEN 'False' THEN 'Invoice Not Available' WHEN 'True' THEN 'Invoice Availble' WHEN 0  THEN 'Invoice Not Available' END ) as IsUploadInvoice  FROM Invoice   WHERE (IsDelete = 0 Or IsDelete Is null) AND JobListID =" + JobListID + " ORDER BY InvoiceDate";

                if (e.ColumnIndex == 5)
                {

                    //String value = e.Value as string;
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


                    String value = e.Value as string;
                    string inputString;
                    DateTime dDate;

                    inputString = e.Value.ToString();

                    if (DateTime.TryParse(inputString, out dDate))
                    {
                        //String.Format("{0:d/MM/yyyy}", dDate);

                        e.Value = string.Format("{0:MM/dd/yyyy}", dDate);
                        e.FormattingApplied = true;


                        //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");

                    }
                    else
                    {
                        
                    }


                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("" + ex.Message);
            }
        }

        private void grdSelectMultiFileInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //MessageBox.Show(e.Value.ToString());

                if (e.ColumnIndex == 5)
                {
                    //e.Value = "MM-dd-yyyy";

                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

                    if ((value != null))
                    {
                        //e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                        e.FormattingApplied = true;

                    }
                    else
                    {
                        e.Value = e.CellStyle.NullValue;
                        e.FormattingApplied = true;
                    }



                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("" + ex.Message);
            }
        }

        private void grdJobList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                //MessageBox.Show( e.ColumnIndex +  "  " + e.Value.ToString());

                if (e.ColumnIndex == 7)
                {
                    //e.Value = "MM-dd-yyyy";

                    String value = e.Value as string;
                    //if ((value != null) && value.Equals(e.CellStyle.DataSourceNullValue))

                    if ((value != null))
                    {
                        e.Value = (DateTime.Parse(e.Value.ToString())).ToString("MM/d/yyyy");
                        e.FormattingApplied = true;

                    }
                    else
                    {
                        e.Value = e.CellStyle.NullValue;
                        e.FormattingApplied = true;
                    }



                }
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show("" + ex.Message);
            }
        }
    }
}