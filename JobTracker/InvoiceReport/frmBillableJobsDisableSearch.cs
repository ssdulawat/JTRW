using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.Classes;
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
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace JobTracker.InvoiceReport
{
    public partial class frmBillableJobsDisableSearch : Form
    {
        public frmBillableJobsDisableSearch()
        {
            InitializeComponent();
        }

        private void BtnBillJobDisableSearch_Click(System.Object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Fillgrid();
            }
            catch (Exception)
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ExportExcel()
        {

            try
            {
                string titleformname = "Billable Job To Disable Search";

                if (DGVSearchJob.Rows.Count > 0)
                {
                    SaveFileDialog Export = new SaveFileDialog();
                    Export.Filter = "Excel Format|*.xls";
                    //Export.Filter = "Excel Format|*.xlsx";
                    Export.Title = titleformname;


                    if (Directory.Exists("N:"))
                    {
                        Export.InitialDirectory = "N:";
                    }
                    else
                    {
                        Export.InitialDirectory = "C:";
                    }




                    if (Export.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }

                    string FullFilePath = Export.FileName;
                    string filename = Path.GetFileName(Export.FileName);
                    string filePath = Export.FileName;


                    NPOIExcelUtility NPOIUtlity = new NPOIExcelUtility();

                    DataTable ExportDataTable = (DataTable)DGVSearchJob.DataSource;

                    string[] Columnarray = new string[4];
                    Columnarray[0] = "JobNumber";
                    Columnarray[1] = "PM";
                    Columnarray[2] = "LastInvoiceDate";


                    //Dim wBook As New HSSFWorkbook()

                    //Dim wSheet As ISheet = wBook.CreateSheet(filename)

                    HSSFWorkbook wBook = new HSSFWorkbook();
                    ISheet sheet1 = wBook.CreateSheet(filename);
                    IFont myFont2 = (IFont)wBook.CreateFont();
                    myFont2.FontHeightInPoints = 11;
                    myFont2.FontName ="Arial";
                    myFont2.IsBold = true;

                    ICellStyle borderedCellStyle = wBook.CreateCellStyle();
                    Int32 Sheetrowindex = 2;
                    int percent;

                    DataTable ManagerMainGrid;

                    IRow sheetRow = sheet1.CreateRow(0);
                    IRow Sheetrow2 = sheet1.CreateRow(1);
                    
                    for(int i=0;i<=DGVSearchJob.Columns.Count-1;i++)
                    {

                        IFont font = (IFont)wBook.CreateFont();
                        font.IsBold = true;
                        font.FontHeightInPoints = 12;
                        font.FontName = "Arial";
                        font.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index;


                        ICellStyle AllCellStyle = wBook.CreateCellStyle();
                        AllCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

                        AllCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Medium;
                        AllCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Medium;
                        AllCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Medium;
                        AllCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Medium;

                        AllCellStyle.SetFont(font);

                        string columnvalue;                        
                        columnvalue = DGVSearchJob.Columns[i].HeaderText.ToString();

                        ICell Cell = sheetRow.CreateCell(i);
                        Cell.SetCellValue(columnvalue);
                        Cell.CellStyle = AllCellStyle;

                    }

                    //For ManagerRowindex As Integer = 1 To DGVSearchJob.Rows.Count

                    //Dim font As IFont = wBook.CreateFont()
                
                    //font.FontHeightInPoints = 10
                    //font.FontName = "Arial"

                    IFont RowFont = (IFont)wBook.CreateFont();                    
                    RowFont.FontHeightInPoints = 10;
                    RowFont.FontName = "Arial";

                    //Dim AllCellStyle As ICellStyle = wBook.CreateCellStyle()
                    ICellStyle AllRowCellStyle = wBook.CreateCellStyle();

                    AllRowCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;


                    AllRowCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllRowCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllRowCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllRowCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;



                    AllRowCellStyle.SetFont(RowFont);

                    ICreationHelper creationHelper = wBook.GetCreationHelper();
                    IDataFormat DataFormat = wBook.CreateDataFormat();

                    //Dim creationHelper As ICreationHelper = wBook.GetCreationHelper()
                    //Dim DataFormat As IDataFormat = wBook.CreateDataFormat()


                    ICellStyle SecondStyle = wBook.CreateCellStyle();

                    SecondStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;


                    SecondStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    SecondStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    SecondStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    SecondStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                    SecondStyle.SetFont(RowFont);



                    for (int j = 1; j <= DGVSearchJob.Rows.Count; j++)
                    {
                        CreateExportRows(ExportDataTable, borderedCellStyle, (j - 1), ref Sheetrowindex, ref sheet1, AllRowCellStyle, creationHelper);

            //private void CreateExportRows(DataTable dt, HSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle CellStyle, ICreationHelper CreationHelper)

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
                    var fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    wBook.Write(fsd);
                    wBook.Close();
                    fsd.Close();
                    MessageBox.Show("Export Successfully ", Export.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                else
                {
                    MessageBox.Show("No Records found for Export. Please try Again!", titleformname, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
           
        }

        //private void CreateExportRows(dt As DataTable, borderedCellStyle As HSSFCellStyle, rowindex As Int32, ByRef sheetRowIndex As Int64, ByRef sheet As ISheet, CellStyle As ICellStyle, CreationHelper As ICreationHelper)
        //{


        //}

        //private object CreateExport(DataTable dt, HSSFCellStyle borderedCellStyle2, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet)

        private void CreateExportRows(DataTable dt, ICellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle CellStyle, ICreationHelper CreationHelper)
        {
            try
            {
                IRow sheetRow = sheet.CreateRow(sheetRowIndex);
                int ColumnIndex = 0;
                //sheetRow = sheet.CreateRow(sheetRowIndex);

                //For Each header As DataColumn In dt.Columns

                foreach (DataColumn header in dt.Columns)
                {
                    //Dim columnvalue As String
                    //columnvalue = dt.Rows(rowindex).Item(ColumnIndex).ToString()

                    string columnvalue;
                    columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                    if(ColumnIndex == 0) 
                    {
                        ICell cell = sheetRow.CreateCell(ColumnIndex);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(columnvalue);
                        cell.CellStyle = CellStyle;
                    }

                    if (ColumnIndex == 1)
                    {
                        ICell cell = sheetRow.CreateCell(ColumnIndex);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(columnvalue);
                        cell.CellStyle = CellStyle;
                    }

                    if (ColumnIndex == 2)
                    {
                        //string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                        //string columnvalue7 = dt.Rows[rowindex][ColumnIndex].ToString();

                        ICell Cell7 = sheetRow.CreateCell(ColumnIndex);


                        //string filter = columnvalue.ToString();
                        //string[] filterRemove = filter.Split('-');

                        //string Date1 = filterRemove[0];
                        //string Month1 = filterRemove[1];
                        //string TempString = filterRemove[2];

                        //string[] filterRemovePart2 = TempString.Split(' ');

                        //string FindalDate = Date1 + "-" + Month1 + "-" + filterRemovePart2[0];

                        //int value7;
                        //if (int.TryParse(FindalDate.ToString(), out value7))
                        //{

                        //    Cell7.SetCellType(NPOI.SS.UserModel.CellType.Numeric);
                        //    int value8 = int.Parse(FindalDate);
                        //    Cell7.SetCellValue(value8);
                        //}
                        //else
                        //{
                        //    Cell7.SetCellType(NPOI.SS.UserModel.CellType.String);
                        //    Cell7.SetCellValue(Convert.ToString(FindalDate));

                        //}


                        Cell7.SetCellType(NPOI.SS.UserModel.CellType.String);
                        Cell7.SetCellValue(columnvalue);
                        Cell7.CellStyle = CellStyle;
                        



                    }

                    if (ColumnIndex == 3)
                    {
                        ICell cell = sheetRow.CreateCell(ColumnIndex);
                        cell.SetCellType(NPOI.SS.UserModel.CellType.String);
                        cell.SetCellValue(columnvalue);
                        cell.CellStyle = CellStyle;
                    }

                    ColumnIndex = ColumnIndex + 1;
                }
                sheetRowIndex = sheetRowIndex + 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void BtnExport_Click(System.Object sender, System.EventArgs e)
        {
            ExportExcel();


            //string titleformname = "Billable Job To Disable Search";

            //if (DGVSearchJob.Rows.Count > 0)
            //{
            //    SaveFileDialog Export = new SaveFileDialog();
            //    Export.Filter = "Excel Format|*.xls";
            //    //Export.Filter = "Excel Format|*.xlsx";
            //    Export.Title = titleformname;


            //    if (Directory.Exists("N:"))
            //    {
            //        Export.InitialDirectory = "N:";
            //    }
            //    else
            //    {
            //        Export.InitialDirectory = "C:";
            //    }




            //    if (Export.ShowDialog() == DialogResult.Cancel)
            //    {
            //        return;
            //    }

            //    string FullFilePath = Export.FileName;

            //    NPOIExcelUtility NPOIUtlity = new NPOIExcelUtility();
            //    DataTable ExportDataTable = (DataTable)DGVSearchJob.DataSource;
            //    string[] Columnarray = new string[4];
            //    Columnarray[0] = "JobNumber";
            //    Columnarray[1] = "PM";
            //    Columnarray[2] = "LastInvoiceDate";




            //    NPOIReturnObject response = NPOIUtlity.ExportExcelWithNPOI(ExportDataTable, FullFilePath, titleformname, Columnarray);

            //    if (response.IsConfirmed == true)
            //    {
            //        MessageBox.Show(response.ResponseMessage, titleformname, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show(response.ResponseMessage, titleformname, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("No Records found for Export. Please try Again!", titleformname, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private DataTable SearchData()
        {
            try
            {
                DataTable dt = null;
                //List<SqlParameter> Param = new List<SqlParameter>();

                //Param.Add(new SqlParameter("@NOCreditColor", Convert.ToInt16(TxtBoxNoColor.Text)));
                //Param.Add(new SqlParameter("@GreenColor", Convert.ToInt16(TxtBoxGreenColor.Text)));
                //Param.Add(new SqlParameter("@yellowColor", Convert.ToInt16(TxtBoxYellowColor.Text)));
                //Param.Add(new SqlParameter("@OrangeColor", Convert.ToInt16(TxtBoxOrangeColor.Text)));
                //Param.Add(new SqlParameter("@RedColor", Convert.ToInt16(TxtBoxRedColor.Text)));
                //Param.Add(new SqlParameter("@BlackColor", Convert.ToInt16(TxtBoxBlackColor.Text)));
                //Param.Add(new SqlParameter("@DefaultAmount", Convert.ToDecimal(txtBoxamount.Text)));

                //dt = StMethod.GetListDT<JobSearchData_Result>("proc_GetBillableJobDisableSearchData", Param);


                //dt = StMethod.GetBJDSearchData(Convert.ToInt32(TxtBoxNoColor.Text), Convert.ToInt32(TxtBoxGreenColor.Text), Convert.ToInt32(TxtBoxYellowColor.Text), Convert.ToInt32(TxtBoxOrangeColor.Text), Convert.ToInt32(TxtBoxRedColor.Text), Convert.ToInt32(TxtBoxBlackColor.Text), Convert.ToDecimal(txtBoxamount.Text));

                if (Properties.Settings.Default.IsTestDatabase == true)
                {
                    dt = StMethod.GetBJDSearchDataNew(Convert.ToInt32(TxtBoxNoColor.Text), Convert.ToInt32(TxtBoxGreenColor.Text), Convert.ToInt32(TxtBoxYellowColor.Text), Convert.ToInt32(TxtBoxOrangeColor.Text), Convert.ToInt32(TxtBoxRedColor.Text), Convert.ToInt32(TxtBoxBlackColor.Text), Convert.ToDecimal(txtBoxamount.Text));

                }
                else
                {
                    dt = StMethod.GetBJDSearchData(Convert.ToInt32(TxtBoxNoColor.Text), Convert.ToInt32(TxtBoxGreenColor.Text), Convert.ToInt32(TxtBoxYellowColor.Text), Convert.ToInt32(TxtBoxOrangeColor.Text), Convert.ToInt32(TxtBoxRedColor.Text), Convert.ToInt32(TxtBoxBlackColor.Text), Convert.ToDecimal(txtBoxamount.Text));
                }

                lblRecordsCount.Text = "Total Records :- " + dt.Rows.Count.ToString();

                return dt;


            }
            catch (Exception ex)
            {
                MessageBox.Show("The error is occurring while searching for Billable/Job To Disable-Search!", "Billable Job-Search", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new DataTable();
            }

        }

        public void Fillgrid()
        {
            try
            {
                DataTable dt = SearchData();


                //if (Properties.Settings.Default.IsTestDatabase == true)
                //{

                 
                //}
                //else
                //{
                 
                //}

                DGVSearchJob.DataSource = dt;
                DGVSearchJob.AutoGenerateColumns = false;
                DGVSearchJob.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;


                foreach (DataRow dr in dt.Rows)
                {
                    dr["LastInvoiceDate"] = DateTime.Parse((dr["LastInvoiceDate"].ToString())).ToString("MM/dd/yyyy");
                }


                DGVSearchJob.DataSource = dt;

                if(DGVSearchJob.Rows .Count >0 )
                {

                    //Set Column Property
                    DGVSearchJob.Columns["JobNumber"].Visible = true;
                    DGVSearchJob.Columns["JobNumber"].HeaderText = "Job Number";
                    DGVSearchJob.Columns["JobNumber"].Width = 100;

                    DGVSearchJob.Columns["PM"].Visible = true;
                    DGVSearchJob.Columns["PM"].HeaderText = "PM";
                    DGVSearchJob.Columns["PM"].Width = 100;

                    DGVSearchJob.Columns["LastInvoiceDate"].Visible = true;
                    DGVSearchJob.Columns["LastInvoiceDate"].HeaderText = "Last Invoice Date";
                    DGVSearchJob.Columns["LastInvoiceDate"].Width = 200;

                    //dataGridView1.Columns[0].DefaultCellStyle.Format = "dd/MM/yyyy";
                    DGVSearchJob.Columns["LastInvoiceDate"].DefaultCellStyle.Format = "yyyy/dd/mmmm";

                }

                


                //.Columns["JoblistID"].Visible = False
                //.Columns["CompanyID"].Visible = False
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString ());
            }
        }

        private void frmBillableJobDisableSearch_Load(System.Object sender, System.EventArgs e)
        {
            //Fillgrid();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                Fillgrid();
            }
            catch (Exception)
            {
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
