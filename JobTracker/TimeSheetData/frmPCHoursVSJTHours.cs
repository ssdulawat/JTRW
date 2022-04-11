using ComponentFactory.Krypton.Toolkit;
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
using Excel = Microsoft.Office.Interop.Excel;

using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;

namespace JobTracker.TimeSheetData
{
    public partial class frmPCHoursVSJTHours : Form
    {

        
        #region "Declaration"
        private int result = 0;
        private double countPunchHours;
        private DataTable dtCmb = new DataTable();
        private int _EmployeeID;

        double TotalPuchHour;


        public int EmployeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        private DateTime _From;
        public DateTime FromDate
        {
            get
            {
                return _From;
            }
            set
            {
                _From = value;
            }
        }
        private DateTime _To;
        public DateTime ToDATE
        {
            get
            {
                return _To;
            }
            set
            {
                _To = value;
            }
        }
        private string _UserName;
        public string UserName
        {
            get
            {
                return _UserName;
            }
            set
            {
                _UserName = value;
            }
        }
        private bool _ShowDate;
        public bool ShowDate
        {
            get
            {
                return _ShowDate;
            }
            set
            {
                _ShowDate = value;
            }
        }

        #endregion
        public frmPCHoursVSJTHours()
        {
            InitializeComponent();
        }

        #region Events
        private void cmbUserSearchPCvsJT_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            try
            {
                selectWorkingWeek(Convert.ToDateTime(DateTime.Today.ToShortDateString())); //set current week
                selectWorkingWeek(Convert.ToDateTime(dtpDateSearchFrom.Value.AddDays(-4).ToString())); //set priouse week
                                                                                                       // fillgrdPCHoursvsJT()
                ChangePunchHours();
                selectWorkingWeek(Convert.ToDateTime(DateTime.Today.ToShortDateString()));
                selectWorkingWeek(Convert.ToDateTime(dtpDateSearchFrom.Value.AddDays(-4).ToString()));
            }
            catch (Exception ex)
            {

            }
        }

        private void ExportPuchHours()
        {
            try
            {
                SaveFileDialog ExportTimeExpense = new SaveFileDialog();


                //ExportTimeExpense.Filter = "Excel Format|*.xlsx";
                ExportTimeExpense.Filter = "Excel Format|*.xls";
                ExportTimeExpense.Title = "Export Punch Hours";
                ExportTimeExpense.FilterIndex = 2;

                
                if(Directory.Exists ("N:"))
                {
                    ExportTimeExpense.InitialDirectory = "N:";
                }
                else
                {
                    ExportTimeExpense.InitialDirectory = "C:";
                }


                if (ExportTimeExpense.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                //Dim TimeSheetId As Guid = System.Guid.NewGuid()
                string strFileName = ExportTimeExpense.FileName; // "TimeAndExpenses" & TimeSheetId.ToString() '
                bool blnFileOpen = false;

                //    Dim FullFilePath As String = Export.FileName
                //Dim filename As String = Path.GetFileName(Export.FileName)
                //Dim filePath As String = Export.FileName


                String FullFilePath = ExportTimeExpense.FileName;
                String filename = Path.GetFileName(ExportTimeExpense.FileName);
                String filePath = ExportTimeExpense.FileName;

                try
                {
                    System.IO.FileStream fileTemp = System.IO.File.OpenWrite(strFileName);
                    fileTemp.Close();
                }
                catch (Exception ex)
                {
                    blnFileOpen = false;
                }

                if (System.IO.File.Exists(strFileName))
                {
                    System.IO.File.Delete(strFileName);
                }


                //XSSFWorkbook WorkBook = new XSSFWorkbook();
                HSSFWorkbook WorkBook = new HSSFWorkbook();
                ISheet Sheet1 = WorkBook.CreateSheet(filename);

                DataTable dt = new DataTable();
                //Boolean flage = false;
                //DataTable DtHideColumngridView = new DataTable();
                DataTable DtHideColumngridView = new DataTable();
                DtHideColumngridView = (DataTable)grdPCvsJT.DataSource;
                dt = DtHideColumngridView;

                if(dt.Rows.Count > 0)
                {

               

                IRow HeaderRow = Sheet1.CreateRow(1);
                int colIndex = 0;
                    //int rowIndex = 0;


                //IFont myFont11 = (XSSFFont)WorkBook.CreateFont();
                     
                IFont myFont11 = (HSSFFont)WorkBook.CreateFont();

                myFont11.FontHeightInPoints = 11;
                myFont11.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index;
                myFont11.IsBold = true;

                ICellStyle boldtsyle = WorkBook.CreateCellStyle();
                boldtsyle.SetFont(myFont11);

                boldtsyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;

                boldtsyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                boldtsyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin  ;
                boldtsyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                boldtsyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;
                
                IRow row = Sheet1.CreateRow(0);
                ICell Cell = row.CreateCell(0);
                Cell.SetCellValue("Punched Hours VS Job Tracker Hours");

                ICell Cel2 = row.CreateCell(1);
                ICell Cel3 = row.CreateCell(2);
                ICell Cel4 = row.CreateCell(3);
                //ICell Cel5 = row.CreateCell(4);
                //ICell Cel6 = row.CreateCell(5);
                //ICell Cel7 = row.CreateCell(6);
                //ICell Cel8 = row.CreateCell(7);
                ////ICell Cel9 = row.CreateCell(8);
                //ICell Cell0 = row.CreateCell(9);

                Sheet1.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, 0, 3));


                Cell.CellStyle = boldtsyle;
                Cel2.CellStyle = boldtsyle;
                Cel3.CellStyle = boldtsyle;
                Cel4.CellStyle = boldtsyle;
                //Cel5.CellStyle = boldtsyle;
                //Cel6.CellStyle = boldtsyle;
                //Cel7.CellStyle = boldtsyle;
                //Cel8.CellStyle = boldtsyle;
                //Cel9.CellStyle = boldtsyle;
                //Cell0.CellStyle = boldtsyle;

                foreach (DataColumn dc in dt.Columns)
                {

                    IFont font = WorkBook.CreateFont();
                    font.IsBold = true;
                    font.FontHeightInPoints = 11;
                    font.FontName = "Arial";
                    //font.Color = NPOI.HSSF.Util.HSSFColor.RoyalBlue.Index;
                    font.Color = NPOI.HSSF.Util.HSSFColor.Black.Index;


                    ICellStyle AllCellStyle = WorkBook.CreateCellStyle();
                    AllCellStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;


                    AllCellStyle.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                    AllCellStyle.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                    AllCellStyle.SetFont(font);

       
                    ICell Cell22 = HeaderRow.CreateCell(colIndex);
                    Cell22.SetCellValue(dc.ColumnName);
                    Cell22.CellStyle = AllCellStyle;

                    ICellStyle AllCellStyle2 = WorkBook.CreateCellStyle();
                    AllCellStyle2.SetFont(font);

                    colIndex = colIndex + 1;
                }

                //XSSFCellStyle borderedCellStyle = (XSSFCellStyle)WorkBook.CreateCellStyle();

                HSSFCellStyle borderedCellStyle = (HSSFCellStyle)WorkBook.CreateCellStyle();
                 
                Int32 Sheetrowindex = 2;


                IFont font11 = WorkBook.CreateFont();
                font11.FontHeightInPoints = 10;
                font11.FontName = "Arial";

                ICellStyle AllCellStyle11 = WorkBook.CreateCellStyle();

                AllCellStyle11.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                AllCellStyle11.BorderLeft = NPOI.SS.UserModel.BorderStyle.Thin;
                AllCellStyle11.BorderRight = NPOI.SS.UserModel.BorderStyle.Thin;
                AllCellStyle11.BorderTop = NPOI.SS.UserModel.BorderStyle.Thin;
                AllCellStyle11.BorderBottom = NPOI.SS.UserModel.BorderStyle.Thin;

                AllCellStyle11.WrapText = true;

                AllCellStyle11.SetFont(font11);

                ICreationHelper creationHelper11 = WorkBook.GetCreationHelper();

                IDataFormat DataFormat11 = WorkBook.CreateDataFormat();

                ICellStyle SecondStyle11 = WorkBook.CreateCellStyle();
                SecondStyle11.SetFont(font11);

                for (int ManagerRowindex = 1; ManagerRowindex <= grdPCvsJT.Rows.Count; ManagerRowindex++)
                {

                    CreatePuchHoursRows(dt, borderedCellStyle, (ManagerRowindex - 1), ref Sheetrowindex, ref Sheet1, AllCellStyle11, creationHelper11, DataFormat11, SecondStyle11);
                }


                int PunchHorsRowRecord = grdPCvsJT.Rows.Count;

                IRow PunchHorsRow = Sheet1.CreateRow(PunchHorsRowRecord+5);

                ICell CellPunch = PunchHorsRow.CreateCell(3);


                CellPunch.SetCellValue("Punch : " + TotalPuchHour);


                int x, z;

                int lastColumNum = Sheet1.GetRow(1).LastCellNum;

                for (z = 1; z <= lastColumNum; z++)
                {
                    Sheet1.AutoSizeColumn(z);

                    // xlSheet.Range("A1:X1").EntireColumn.AutoFit()
                    GC.Collect();
                }

                if (Sheet1.PhysicalNumberOfRows > 0)
                {

                    IRow Last = Sheet1.GetRow(0);

                    int z2;


                    for (z2 = 0; z2 <= HeaderRow.LastCellNum; z2++)
                    {
                        Sheet1.AutoSizeColumn(z2);
                        // xlSheet.Range("A1:X1").EntireColumn.AutoFit()
                        GC.Collect();
                    }
                }

                FileStream fsd = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

                WorkBook.Write(fsd);
                WorkBook.Close();
                fsd.Close();
                //MessageBox.Show("done");
                MessageBox.Show("Export Successfully ", ExportTimeExpense.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    DialogResult choiceButton = KryptonMessageBox.Show("Record is Null ", "TimeAndExpenses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {

            }
        }

        private object CreatePuchHoursRows(DataTable dt, HSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle AllCellStyle, ICreationHelper ICH, IDataFormat IDF, ICellStyle SecondCS)
            //private object CreatePuchHoursRows(DataTable dt, XSSFCellStyle borderedCellStyle, Int32 rowindex, ref Int32 sheetRowIndex, ref ISheet sheet, ICellStyle AllCellStyle, ICreationHelper ICH, IDataFormat IDF, ICellStyle SecondCS)
        {

            int ColumnIndex = 0;
            IRow row = sheet.CreateRow(sheetRowIndex);

            foreach (DataColumn header in dt.Columns)
            {

                string columnvalue = dt.Rows[rowindex][ColumnIndex].ToString();

                if (ColumnIndex == 0)
                {

                    int value7;
                    if (int.TryParse(columnvalue, out value7))
                    {

                        ICell Cell5 = row.CreateCell(ColumnIndex);
                        Cell5.SetCellType(NPOI.SS.UserModel.CellType.Numeric);

                        //Cell5.SetCellValue(Convert.ToString(dtsearch.Rows.Count));
                        
                        int value11 = int.Parse(columnvalue);
                        Cell5.SetCellValue(value11);
                        TotalPuchHour = TotalPuchHour + Convert.ToDouble(columnvalue);
                        Cell5.CellStyle = AllCellStyle;
                    }
                    else
                    {
                        ICell Cell5 = row.CreateCell(ColumnIndex);
                        Cell5.SetCellType(NPOI.SS.UserModel.CellType.String);

                        //Cell5.SetCellValue(Convert.ToString(dtsearch.Rows.Count));

                        //int value11 = int.Parse(columnvalue);
                        
                        Cell5.SetCellValue(Convert.ToDouble(columnvalue));

                        TotalPuchHour = TotalPuchHour + Convert.ToDouble(columnvalue);
                        Cell5.CellStyle = AllCellStyle;

                    }


                }

                if (ColumnIndex == 1)
                {

                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;


                    // Below is the code to convert date and remove time from it

                    //ICell Cell7 = row.CreateCell(ColumnIndex);
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
                    //Cell7.CellStyle = AllCellStyle;



                }


                if (ColumnIndex == 2)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                if (ColumnIndex == 3)
                {
                    ICell Cell1 = row.CreateCell(ColumnIndex);
                    Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                    Cell1.SetCellValue(columnvalue);
                    Cell1.CellStyle = AllCellStyle;
                }

                //ICell Cell1 = row.CreateCell(ColumnIndex);
                //Cell1.SetCellType(NPOI.SS.UserModel.CellType.String);
                //Cell1.SetCellValue(columnvalue);
                //Cell1.CellStyle = AllCellStyle;

                ColumnIndex = ColumnIndex + 1;
            }

            sheetRowIndex = sheetRowIndex + 1;
            return null;

        }

        

        private void btnExportexcelSheet_Click(System.Object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                ExportPuchHours();


                //Excel.Application excel = new Excel.Application();
                //Excel.Workbook wBook = null;
                //Excel.Worksheet wSheet = null;
                //wBook = excel.Workbooks.Add();
                //wSheet = (Excel.Worksheet)wBook.Sheets[1];
                //// excel sheet landscape
                //wSheet.PageSetup.Orientation = Excel.XlPageOrientation.xlLandscape;
                //wSheet.PageSetup.CenterHorizontally = true;

                ////set margin  page
                //wSheet.PageSetup.LeftMargin = 0.75;
                //wSheet.PageSetup.RightMargin = 0.75;
                //wSheet.PageSetup.TopMargin = 0.75;
                //wSheet.PageSetup.BottomMargin = 0.75;
                //wSheet.PageSetup.HeaderMargin = 0.75;
                //wSheet.PageSetup.FooterMargin = 0.75;

                ////'set page sclliang
                ////wSheet.PageSetup.Zoom = 91
                ////wSheet.PageSetup.FitToPagesTall = 1
                ////wSheet.PageSetup.FitToPagesWide = 1

                //DataTable dt = new DataTable();
                //bool flage = false;
                //DataTable DtHideColumngridView = new DataTable();
                //DtHideColumngridView = (DataTable)grdPCvsJT.DataSource;
                //dt = DtHideColumngridView;

                //if (dt.Rows.Count > 0)
                //{
                //    int colIndex = 0;
                //    int rowIndex = 0;
                //    foreach (DataColumn dc in dt.Columns)
                //    {
                //        colIndex = colIndex + 1;
                //        excel.Cells[2, colIndex] = dc.ColumnName;
                //    }
                //    wSheet.Columns.Range["A2:k2"].Font.Bold = true;
                //    wSheet.Columns.Range["A2:k2"].Font.Size = 11;
                //    wSheet.Columns.Range["A2:k2"].Font.Color = Color.Black;
                //    //  wSheet.Range["D2"].EntireColumn.NumberFormat = "dd/mm/yyyy"

                //    foreach (DataRow dr in dt.Rows)
                //    {
                //        rowIndex = rowIndex + 1;
                //        colIndex = 0;
                //        foreach (DataColumn dc in dt.Columns)
                //        {
                //            colIndex = colIndex + 1;
                //            excel.Cells[rowIndex + 2, colIndex] = dr[dc.ColumnName].ToString();

                //        }
                //    }


                //    int setBorderRowIndex = 0; //Set heare row index
                //    setBorderRowIndex = rowIndex;

                //    wSheet.Columns.AutoFit();


                //    // wSheet.Range["A1:E2").Borders(Global.Excel.XlBordersIndex.xlEdgeTop).Weight = Global.Excel.XlBorderWeight.xlThin 'Fist header
                //    // wSheet.Range["A1:E1").Borders(Global.Excel.XlBordersIndex.xlEdgeLeft).Weight = Global.Excel.XlBorderWeight.xlThin
                //    //wSheet.Range["A1:E1").Borders(Global.Excel.XlBordersIndex.xlEdgeRight).Weight = Global.Excel.XlBorderWeight.xlThin
                //    wSheet.Range["A1:D1"].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;

                //    wSheet.Range["A2:D2"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin; //seccount row
                //    wSheet.Range["A2:D2"].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //    wSheet.Range["A2:D2"].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin;
                //    wSheet.Range["A2:D2"].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;

                //    wSheet.Range["A2:D2"].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlThin;

                //    int CloumnRng = setBorderRowIndex + 2; //set border in excel sheet
                //    string rngA = null;
                //    string rngB = null;
                //    string rngC = null;
                //    string rngD = null;
                //    // Dim rngE As String
                //    //Dim rngF As String
                //    //Dim rngG As String
                //    //Dim rngH As String
                //    //Dim rngI As String
                //    rngA = "A2:A" + CloumnRng;
                //    rngB = "B2:B" + CloumnRng;
                //    rngC = "C2:C" + CloumnRng;
                //    rngD = "D2:D" + CloumnRng;
                //    //  rngE = "E2:E" + CloumnRng
                //    //rngF = "F2:F" + CloumnRng
                //    //rngG = "G2:G" + CloumnRng
                //    //rngH = "H2:H" + CloumnRng
                //    //rngI = "I2:I" + CloumnRng

                //    //Set Left Border
                //    wSheet.Range[rngA].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //    wSheet.Range[rngB].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //    wSheet.Range[rngC].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //    wSheet.Range[rngD].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlThin;
                //    //  wSheet.Range[rngE).Borders(Global.Excel.XlBordersIndex.xlEdgeLeft).Weight = Global.Excel.XlBorderWeight.xlThin
                //    //wSheet.Range[rngF).Borders(Global.Excel.XlBordersIndex.xlEdgeLeft).Weight = Global.Excel.XlBorderWeight.xlThin
                //    //wSheet.Range[rngG).Borders(Global.Excel.XlBordersIndex.xlEdgeLeft).Weight = Global.Excel.XlBorderWeight.xlThin
                //    //wSheet.Range[rngH).Borders(Global.Excel.XlBordersIndex.xlEdgeLeft).Weight = Global.Excel.XlBorderWeight.xlThin
                //    //wSheet.Range[rngI).Borders(Global.Excel.XlBordersIndex.xlEdgeLeft).Weight = Global.Excel.XlBorderWeight.xlThin

                //    //set Bottom Border
                //    int CountColumn = 3;

                //    int tempVar = CloumnRng - 3;
                //    for (int ClmRow = 0; ClmRow <= tempVar; ClmRow++)
                //    {
                //        string strColumnrang = "A" + CountColumn.ToString() + ":D" + CountColumn.ToString();
                //        wSheet.Range[strColumnrang].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlThin;
                //        CountColumn = CountColumn + 1;
                //    }
                //    //Total punched hrs Show
                //    rowIndex = rowIndex + 6;
                //    excel.Cells[rowIndex, 4] = lbltotalpunchedHrs.Text.ToString();

                //    //Set last Right left Both Column
                //    wSheet.Range[rngD].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlThin; //Lef Right Both Last Column
                //                                                                                                       //set column width
                //    wSheet.Columns[1].ColumnWidth = 17;
                //    wSheet.Columns[2].ColumnWidth = 17;
                //    wSheet.Columns[3].ColumnWidth = 17;
                //    wSheet.Columns[4].ColumnWidth = 17;
                //    //  wSheet.Columns[5].ColumnWidth = 21

                //    wSheet.Range["A1:D1"].Merge();
                //    wSheet.Range["A1:D1"].Value = "Punched Hours VS Job Tracker Hours";
                //    wSheet.Columns.Range["A1:D1"].Font.Color = Color.RoyalBlue;
                //    wSheet.Columns.Range["A1:D1"].Font.Bold = true;
                //    wSheet.Columns.Range["A1:D1"].Font.Size = 11;
                //    // set column in center

                //    wSheet.Range["A2"].HorizontalAlignment = Alignment.Center;
                //    wSheet.Range["B2"].HorizontalAlignment = Alignment.Center;
                //    wSheet.Range["C2"].HorizontalAlignment = Alignment.Center;
                //    wSheet.Range["D2"].HorizontalAlignment = Alignment.Center;
                //    //  wSheet.Range["E2"].HorizontalAlignment = Alignment.Center
                //    wSheet.Range["A1"].HorizontalAlignment = Alignment.Center;
                //    //set value in center
                //    wSheet.Columns[1].HorizontalAlignment = Alignment.Center;
                //    wSheet.Columns[2].HorizontalAlignment = Alignment.Center;
                //    wSheet.Columns[3].HorizontalAlignment = Alignment.Center;
                //    wSheet.Columns[4].HorizontalAlignment = Alignment.Center;
                //    //  wSheet.Columns[5].HorizontalAlignment = Alignment.Center


                //    SaveFileDialog Export = new SaveFileDialog();
                //    Export.Filter = "Excel Format|*.xls";
                //    Export.Title = "Export PunchHoursVsJobTrackerHours";
                //    Export.InitialDirectory = "N:";

                //    // If Export.ShowDialog() = DialogResult.Cancel Then
                //    // Exit Sub
                //    //End If
                //    Guid TimeSheetId = System.Guid.NewGuid();
                //    string strFileName = "PunchHoursVsJobTrackerHours" + TimeSheetId.ToString(); //Export.FileName
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
                //    wBook.SaveAs(strFileName);
                //    excel.Workbooks.Open(strFileName);
                //    excel.Visible = true;
                //}
                //else
                //{
                //    //KryptonMessageBox.Show("Record is Null ", "TimeAndExpenses")
                //    DialogResult choiceButton = KryptonMessageBox.Show("Record is Null ", "TimeAndExpenses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //}
            }
            catch (Exception ex)
            {
                KryptonMessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void frmPCHoursVSJTHours_Load(System.Object sender, System.EventArgs e)
        {
            FillPunchHours();
        }
        #endregion

        #region Methods
        private void FillPunchHours()
        {
            try
            {
                //DataAccessLayer DAL = new DataAccessLayer();

                ////Dim pcConnStr As String = ConfigurationSettings.AppSettings("PCTracker").ToString()
                //SqlConnection con = new SqlConnection(DAL.ConnectionStringPCTracker);
                string query = " USE " + cGlobal.AdditionalDB + " SELECT  SingIn, SingOut, Date, HoursWorked FROM Attendance where EmployeeDetailsId=" + EmployeID + "";

                if (ShowDate == true)
                {
                    if (string.CompareOrdinal(_To.ToString("yyyy/MM/dd"), _From.ToString("yyyy/MM/dd")) >= 0)
                    {
                        //query = query + " AND Date BETWEEN '" + _From.ToString("yyyy/MM/dd") + "' AND '" + _To.ToString("yyyy/MM/dd") + "'";
                    }
                }


                DataTable dt = new DataTable();
                dt = StMethod.GetListDT<dtoHoursWorked>(query,StMethod.eDatabase.PCTracker);
                foreach (DataRow changehours in dt.Rows)
                {
                    double _hours = Convert.ToDouble(changehours["HoursWorked"]);
                    string splite = _hours.ToString();
                    string[] filter = splite.Split('.');
                    long i1 = 0;
                    if (filter.Length > 1)
                    {
                        i1 = Convert.ToInt64(filter[1]);
                    }
                    else
                    {
                        i1 = 0;
                    }
                    CountChars(i1.ToString());
                    double filterMint = 0;
                    if (result == 0)
                    {
                        filterMint = i1 / 10.0;
                    }
                    if (result == 1)
                    {
                        filterMint = i1 / 10.0;
                    }
                    if (result == 2)
                    {
                        filterMint = i1 / 100.0;
                    }
                    if (result == 3)
                    {
                        filterMint = i1 / 1000.0;
                    }
                    if (result == 4)
                    {
                        filterMint = i1 / 10000.0;
                    }
                    if (result == 5)
                    {
                        filterMint = i1 / 100000.0;
                    }
                    if (result == 6)
                    {
                        filterMint = i1 / 1000000.0;
                    }
                    if (result == 7)
                    {
                        filterMint = i1 / 10000000.0;
                    }
                    if (result == 8)
                    {
                        filterMint = i1 / 100000000.0;
                    }
                    if (result == 9)
                    {
                        filterMint = i1 / 1000000000.0;
                    }
                    if (result == 10)
                    {
                        filterMint = i1 / 10000000000.0;
                    }
                    if (result == 11)
                    {
                        filterMint = i1 / 100000000000.0;
                    }
                    if (result == 12)
                    {
                        filterMint = i1 / 1000000000000.0;
                    }
                    if (result == 13)
                    {
                        filterMint = i1 / 10000000000000.0;
                    }
                    if (result == 14)
                    {
                        filterMint = i1 / 100000000000000.0;
                    }
                    if (result == 15)
                    {
                        filterMint = i1 / 1000000000000000.0;
                    }
                    if (result == 16)
                    {
                        filterMint = i1 / 10000000000000000.0;
                    }
                    if (result == 17)
                    {
                        filterMint = i1 / 100000000000000000.0;
                    }
                    int Hours = int.Parse(filter[0]);
                    long Minutes = Convert.ToInt64((filterMint * 60));
                    int ConvertMint = (int)(Minutes);
                    changehours["HoursWorked"] = Hours.ToString() + "." + ConvertMint;

                }
                grdPCvsJT.DataSource = dt;
                foreach (DataGridViewColumn grdColumn in grdPCvsJT.Columns)
                {
                    if (grdColumn.Index != 0)
                    {
                        grdPCvsJT.Columns[grdColumn.Index].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    }
                }

                double count = 0;
                foreach (DataRow changehours in dt.Rows)
                {
                    count += Convert.ToDouble(changehours["HoursWorked"]);
                }
                lbltotalpunchedHrs.Text = "Punch :" + count.ToString();
            }
            catch (Exception ex)
            {

            }
        }
        private void fillgrdPunchedHrs()
        {
            try
            {
                double countTotalHrs = 0;

                string query = "use " + cGlobal.AdditionalDB + " SELECT  UserIn, UserOut, Date, PunchedHrs FROM  InOut where EmployeeDetailID=" + EmployeID + " and Date= '" + ToDATE.ToShortDateString() + "'";
                DataTable dt = StMethod.GetListDT<dtoPunchedHrs>(query);
                dt.Columns.Add("Employee");
                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow row in dt.Rows)
                    {
                        row[4] = UserName;
                        countTotalHrs = Convert.ToDouble(countTotalHrs + row[3].ToString());
                    }
                }

                //change column name
                dt.Columns["UserIn"].ColumnName = "Clock In";
                dt.Columns["UserOut"].ColumnName = "Clock Out";
                dt.Columns["PunchedHrs"].ColumnName = "Punched Hours";

                //set display index
                dt.Columns["Employee"].SetOrdinal(0);
                dt.Columns["Clock Out"].SetOrdinal(1);
                dt.Columns["Clock In"].SetOrdinal(2);
                dt.Columns["Date"].SetOrdinal(3);
                dt.Columns["Punched Hours"].SetOrdinal(4);
                lbltotalpunchedHrs.Text = "Total Punched hrs: " + countTotalHrs.ToString();
                grdPCvsJT.DataSource = dt;
            }
            catch (Exception ex)
            {
            }
        }
        private void fillcmbUserSearchTimeAndExp()
        {
            try
            {
                cmbUserSearchPCvsJT.SelectedIndexChanged -= this.cmbUserSearchPCvsJT_SelectedIndexChanged;
                string queryString = null;
                queryString = "use " + cGlobal.AdditionalDB + " SELECT  EmployeeDetailsId, Name FROM  EmployeeDetails where UserType='U' union SELECT 0 as EmployeeDetailsId, '' as Name order by EmployeeDetailsId";
                DataTable dt = StMethod.GetListDT<UserList>(queryString);
                dtCmb = StMethod.GetListDT<UserList>(queryString);
                DataView dtshort = new DataView();
                dtshort = dt.DefaultView;
                dtshort.Sort = "Name";

                cmbUserSearchPCvsJT.DisplayMember = "Name";
                cmbUserSearchPCvsJT.ValueMember = "EmployeeDetailsId";
                cmbUserSearchPCvsJT.DataSource = dtshort; //DAL.Filldatatable(queryString)

                cmbUserSearchPCvsJT.SelectedIndexChanged += cmbUserSearchPCvsJT_SelectedIndexChanged;

            }
            catch (Exception ex)
            {

            }

        }
        private void fillgrdPCHoursvsJT()
        {
            try
            {
                DataTable dtAddColumn = new DataTable();
                DataTable dtPCvsJT = new DataTable();
                // Dim flag As Boolean = True
                // Dim userID As Integer
                // Dim CountAddRow As Integer
                //For cmbRow As Integer = 1 To dtCmb.Rows.Count - 1
                //    userID = dtCmb.Rows(cmbRow)(0).ToString()


                bool flag = true;

                for (int Row = 0; Row <= 1; Row++)
                {

                    string queryString;

                    // Query For use Regulare hours
                    queryString = "SELECT TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as [Job Number],TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID, TS_Time.Time FROM TS_Time Where JobListID<>0";

                    if (!string.IsNullOrEmpty(this.cmbUserSearchPCvsJT.Text))
                    {
                        queryString = queryString + " and TS_Time.Name Like'" + cmbUserSearchPCvsJT.Text + "%'";
                    }

                    //queryString = "SELECT     TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as [Job Number],TS_Time.Date, TS_Time.Name, TS_Time.Time FROM TS_Time Where   JobListID<>0"

                    //If Me.cmbUserSearchPCvsJT.Text <> "" Then queryString = queryString & " and EmployeeDetailsId=  " & userID & " "

                    if (string.CompareOrdinal(dtpDateSearchTo.Value.ToString("yyyy/MM/dd"), dtpDateSearchFrom.Value.ToString("yyyy/MM/dd")) >= 0)
                    {
                        queryString = queryString + " AND Date BETWEEN '" + dtpDateSearchFrom.Value.ToString("yyyy/MM/dd") + "' AND '" + dtpDateSearchTo.Value.ToString("yyyy/MM/dd") + "'";
                    }
                    else
                    {
                    }


                    dtPCvsJT = StMethod.GetListDT<PCHours>(queryString);
                    double Count = 0;

                    foreach (DataRow Column in dtPCvsJT.Rows)
                    {
                        Count = Convert.ToDouble(Count + Column["Time"].ToString());
                    }

                    ChangePunchHours();


                    if (flag == true)
                    {
                        dtAddColumn.Columns.Add("Employee");
                        dtAddColumn.Columns.Add("From");
                        dtAddColumn.Columns.Add("To");
                        dtAddColumn.Columns.Add("Ragular Hours");
                        dtAddColumn.Columns.Add("Punched Hours");
                        flag = false;
                    }
                    if (dtPCvsJT.Rows.Count > 0)
                    {
                    }
                    else
                    {
                        grdPCvsJT.DataSource = dtAddColumn;
                        //selectWorkingWeek(DateTime.Today.ToShortDateString()) 'set current week

                    }
                    DataRow drNew = dtAddColumn.NewRow();

                    drNew["Employee"] = cmbUserSearchPCvsJT.Text.ToString(); //dtPCvsJT.Rows(0)(5).ToString()
                    drNew["From"] = dtpDateSearchFrom.Value.ToShortDateString();
                    drNew["To"] = dtpDateSearchTo.Value.ToShortDateString();
                    drNew["Ragular Hours"] = Count.ToString();
                    drNew["Punched Hours"] = countPunchHours.ToString();
                    dtAddColumn.Rows.Add(drNew);

                    selectWorkingWeek(DateTime.Today); //Back to current Date set
                }

                //'Dim dr As DataRow
                //'dr = dtAddColumn.NewRow()
                //'CountAddRow = CountAddRow + 1
                //'Dim countRagularehours As Double = dtAddColumn.Rows(0)(3)
                //'Dim countPunchedHours As Double = dtAddColumn.Rows(0)(4)
                //'dr("Employee") = dtAddColumn.Rows(0)(0).ToString()
                //'dr("From") = dtAddColumn.Rows(0)(1).ToString()
                //'dr("To") = dtAddColumn.Rows(1)(2).ToString()
                //'dr("Ragular Hours") = countRagularehours + dtAddColumn.Rows(1)(3).ToString()
                //'dr("Punched Hours") = countPunchedHours + dtAddColumn.Rows(1)(4).ToString()
                //'dtAddColumn.Rows.Add(dr)

                //selectWorkingWeek(DateTime.Today.ToShortDateString()) 'set current week
                //selectWorkingWeek(dtpDateSearchFrom.Value.AddDays(-4).ToString()) 'set priouse week
                //Dim dr1 As DataRow
                //dr1 = dtAddColumn.NewRow()
                //dr1("Employee") = ""
                //dr1("From") = ""
                //dr1("To") = ""
                //dr1("Ragular Hours") = ""
                //dr1("Punched Hours") = ""
                //dtAddColumn.Rows.Add(dr1)

                //Next
                for (int Row = 1; Row <= 1; Row++)
                {
                    DataRow dr = dtAddColumn.NewRow();
                    double countRagularehours = Convert.ToDouble(dtAddColumn.Rows[0][3]);
                    double countPunchedHours = Convert.ToDouble(dtAddColumn.Rows[0][4]);
                    dr["Employee"] = dtAddColumn.Rows[0][0].ToString();
                    dr["From"] = dtAddColumn.Rows[0][1].ToString();
                    dr["To"] = dtAddColumn.Rows[1][2].ToString();
                    dr["Ragular Hours"] = countRagularehours + dtAddColumn.Rows[1][3].ToString();
                    dr["Punched Hours"] = countPunchedHours + dtAddColumn.Rows[1][4].ToString();
                    dtAddColumn.Rows.Add(dr);
                }

                grdPCvsJT.DataSource = dtAddColumn;


                grdPCvsJT.Columns["Ragular Hours"].Width = 110;
                grdPCvsJT.Columns["Punched Hours"].Width = 120;

            }
            catch (Exception ex)
            {

            }
        }
        private void ChangePunchHours()
        {
            try
            {
                string query = "use  " + cGlobal.AdditionalDB + " SELECT Date,HoursWorked FROM  Attendance ";

                if (!string.IsNullOrEmpty(this.cmbUserSearchPCvsJT.Text))
                {
                    query = query + " where EmployeeDetailsId=(select EmployeeDetailsId from EmployeeDetails where Name='" + cmbUserSearchPCvsJT.Text + "' order  by Date ASC)";
                }


                //If Format(dtpDateSearchTo.Value, "yyyy/MM/dd") >= Format(dtpDateSearchFrom.Value, "yyyy/MM/dd") Then
                //    query = query & " AND Date BETWEEN '" & Format(dtpDateSearchFrom.Value, "yyyy/MM/dd") & "' AND '" & Format(dtpDateSearchTo.Value, "yyyy/MM/dd") & "'"
                //Else
                //End If
                DataTable dt = new DataTable();
                dt = StMethod.GetListDT<HrsByDate>(query);
                foreach (DataRow changehours in dt.Rows)
                {
                    double _hours = Convert.ToDouble(changehours["HoursWorked"].ToString());
                    string splite = _hours.ToString();
                    string[] filter = splite.Split('.');
                    long i1 = 0;
                    if (filter.Length > 1)
                    {
                        i1 = Convert.ToInt64(filter[1]);
                    }
                    else
                    {
                        i1 = 0;
                    }
                    CountChars(i1.ToString());
                    double filterMint = 0;
                    if (result == 0)
                    {
                        filterMint = i1 / 10.0;
                    }
                    if (result == 1)
                    {
                        filterMint = i1 / 10.0;
                    }
                    if (result == 2)
                    {
                        filterMint = i1 / 100.0;
                    }
                    if (result == 3)
                    {
                        filterMint = i1 / 1000.0;
                    }
                    if (result == 4)
                    {
                        filterMint = i1 / 10000.0;
                    }
                    if (result == 5)
                    {
                        filterMint = i1 / 100000.0;
                    }
                    if (result == 6)
                    {
                        filterMint = i1 / 1000000.0;
                    }
                    if (result == 7)
                    {
                        filterMint = i1 / 10000000.0;
                    }
                    if (result == 8)
                    {
                        filterMint = i1 / 100000000.0;
                    }
                    if (result == 9)
                    {
                        filterMint = i1 / 1000000000.0;
                    }
                    if (result == 10)
                    {
                        filterMint = i1 / 10000000000.0;
                    }
                    if (result == 11)
                    {
                        filterMint = i1 / 100000000000.0;
                    }
                    if (result == 12)
                    {
                        filterMint = i1 / 1000000000000.0;
                    }
                    if (result == 13)
                    {
                        filterMint = i1 / 10000000000000.0;
                    }
                    if (result == 14)
                    {
                        filterMint = i1 / 100000000000000.0;
                    }
                    if (result == 15)
                    {
                        filterMint = i1 / 1000000000000000.0;
                    }
                    if (result == 16)
                    {
                        filterMint = i1 / 10000000000000000.0;
                    }
                    if (result == 17)
                    {
                        filterMint = i1 / 100000000000000000.0;
                    }
                    int Hours = int.Parse(filter[0]);
                    long Minutes = Convert.ToInt64((filterMint * 60));
                    int ConvertMint = (int)(Minutes);
                    changehours["HoursWorked"] = Hours.ToString() + "." + ConvertMint;

                }

                //countPunchHours = 0
                //For Each changehours As DataRow In dt.Rows
                //    countPunchHours = countPunchHours + changehours("HoursWorked").ToString()
                //Next
                DataTable dtRegulareHours = dt;
                grdPCvsJT.DataSource = dt;
            }
            catch (Exception ex)
            {

            }
        }
        public int CountChars(string value)
        {
            result = 0;
            bool lastWasSpace = false;

            foreach (char c in value)
            {
                if (char.IsWhiteSpace(c))
                {
                    // A.
                    // Only count sequential spaces one time.
                    if (lastWasSpace == false)
                    {
                        result += 1;
                    }
                    lastWasSpace = true;
                }
                else
                {
                    // B.
                    // Count other characters every time.
                    result += 1;
                    lastWasSpace = false;
                }
            }
            return result;
        }
        public void selectWorkingWeek(DateTime CurrentDate)
        {
            List<DateTime> WeekDate = new List<DateTime>();
            try
            {
                DateTime SelectedDate = CurrentDate;
                int Positionday = ReturndayPosition(CurrentDate.DayOfWeek.ToString());
                for (int i = Positionday; i >= 1; i--)
                {
                    DateTime DT = new DateTime();
                    DT = SelectedDate;
                    DT = DT.AddDays(-i);
                    WeekDate.Add(DT);
                }

                int tempVar = 4 - Positionday;
                for (int j = 0; j <= tempVar; j++)
                {
                    DateTime DT = new DateTime();
                    DT = SelectedDate;
                    DT = DT.AddDays(j);
                    WeekDate.Add(DT);
                }

                WeekDate.Sort();
                dtpDateSearchFrom.Value = Convert.ToDateTime(WeekDate[0].ToShortDateString());
                dtpDateSearchTo.Value = Convert.ToDateTime(WeekDate[4].ToShortDateString());

            }
            catch
            {
            }
        }
        private int ReturndayPosition(string day)
        {
            int dayPosition = 0;
            switch (day.ToUpper())
            {
                // case "SATURDAY": dayPosition = 0; break;
                // case "SUNDAY": dayPosition = 1; break;
                case "MONDAY":
                    dayPosition = 0;
                    break;
                case "TUESDAY":
                    dayPosition = 1;
                    break;
                case "WEDNESDAY":
                    dayPosition = 2;
                    break;
                case "THURSDAY":
                    dayPosition = 3;
                    break;
                case "FRIDAY":
                    dayPosition = 4;
                    break;

            }
            return dayPosition;
        }
        internal enum Alignment
        {
            Center = 3,
            LeftAlign = 2,
            RighiAlign = 4

        }
        private void fillgrdPunchShotByDate()
        {
            DataTable dtAddColumn = new DataTable();
            DataTable dtPCvsJT = new DataTable();

            bool flag = true;

            string queryString;

            // Query For use Regulare hours
            queryString = "SELECT TS_Time.TimeSheetID,TS_Time.JobListID, TS_Time.EmployeeDetailsId,(SELECT JobNumber FROM Joblist WHERE JobListID=TS_Time.JobListID) as [Job Number],TS_Time.Date, TS_Time.Name,TS_Time.TrackSubID, TS_Time.Time FROM TS_Time Where JobListID<>0";

            if (!string.IsNullOrEmpty(this.cmbUserSearchPCvsJT.Text))
            {
                queryString = queryString + " and TS_Time.Name Like'" + cmbUserSearchPCvsJT.Text + "%'";
            }

            //If Format(dtpDateSearchTo.Value, "yyyy/MM/dd") >= Format(dtpDateSearchFrom.Value, "yyyy/MM/dd") Then
            //    queryString = queryString & " AND Date BETWEEN '" & Format(dtpDateSearchFrom.Value, "yyyy/MM/dd") & "' AND '" & Format(dtpDateSearchTo.Value, "yyyy/MM/dd") & "'"
            //Else
            //End If


            dtPCvsJT = StMethod.GetListDT<PCHours>(queryString);
            double Count = 0;

            foreach (DataRow Column in dtPCvsJT.Rows)
            {
                Count = Convert.ToDouble(Count + Column["Time"].ToString());
            }

            ChangePunchHours();


            if (flag == true)
            {
                dtAddColumn.Columns.Add("Employee");
                dtAddColumn.Columns.Add("From");
                dtAddColumn.Columns.Add("To");
                dtAddColumn.Columns.Add("Ragular Hours");
                dtAddColumn.Columns.Add("Punched Hours");
                flag = false;
            }
            if (dtPCvsJT.Rows.Count > 0)
            {
            }
            else
            {
                grdPCvsJT.DataSource = dtAddColumn;
                //selectWorkingWeek(DateTime.Today.ToShortDateString()) 'set current week

            }

            selectWorkingWeek(DateTime.Today); //Back to current Date set
            grdPCvsJT.DataSource = dtAddColumn;


            grdPCvsJT.Columns["Ragular Hours"].Width = 110;
            grdPCvsJT.Columns["Punched Hours"].Width = 120;

        }
        #endregion
    }
}
