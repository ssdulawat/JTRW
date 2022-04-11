using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Classes
{
    public class NPOIExcelUtility
    {
        private NPOIReturnObject MainExportExcelWithNPOI(DataTable dt, string FileNameWithPath, string extension, string SheetName, string[] ColumnsNameinArray = null, List<string> ColumnNameinList = null)
        {
            NPOIReturnObject ReturnResult = new NPOIReturnObject();
            try
            {
                IWorkbook workbook = null;

                if (extension.IndexOf(".") > -1)
                {
                    extension = extension.Replace(".", "");
                }

                if (extension == "xlsx")
                {
                    workbook = new XSSFWorkbook();
                }
                else if (extension == "xls")
                {
                    workbook = new HSSFWorkbook();
                }
                else
                {
                    ReturnResult.IsConfirmed = false;
                    ReturnResult.ResponseMessage = "File format is not supported";
                    return ReturnResult;
                }

                ISheet sheet1 = workbook.CreateSheet(SheetName);
                IRow row1 =(IRow) sheet1.CreateRow(0);

                //'Coulumn Header set in excel
                if (ColumnsNameinArray != null && ColumnsNameinArray.Length > 0)
                {
                    for (int j = 0; j < ColumnsNameinArray.Length; j++)
                    {
                        ICell cell =(ICell) row1.CreateCell(j);
                        string columnName = ColumnsNameinArray[j];
                        cell.SetCellValue(columnName);
                    }
                }
                else if (ColumnNameinList != null && ColumnNameinList.Count > 0)
                {
                    for (int j = 0; j < ColumnNameinList.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        string columnName = ColumnNameinList[j];
                        cell.SetCellValue(columnName);
                    }
                }
                else
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        string columnName = dt.Columns[j].ColumnName;
                        cell.SetCellValue(columnName);
                    }
                }


                //'Set All coumn values
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet1.CreateRow(i + 1);

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string columnName = dt.Columns[j].ColumnName;
                        if (ColumnsNameinArray != null && ColumnsNameinArray.Length > 0)
                        {
                            for (int colarry = 0; colarry < ColumnsNameinArray.Length; colarry++)
                            {
                                if (dt.Columns[j].ColumnName == ColumnsNameinArray[colarry])
                                {
                                    ICell cell = row.CreateCell(colarry);
                                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                                }
                            }
                        }
                        else if (ColumnNameinList != null && ColumnNameinList.Count > 0)
                        {
                            for (int colList = 0; colList < ColumnNameinList.Count; colList++)
                            {
                                if (dt.Columns[j].ColumnName == ColumnNameinList[colList])
                                {
                                    ICell cell = row.CreateCell(colList);
                                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                                }
                            }
                        }
                        else
                        {
                            ICell cell = row.CreateCell(j);
                            cell.SetCellValue(dt.Rows[i][columnName].ToString());
                        }
                    }
                }

                if (File.Exists(FileNameWithPath))
                {
                    File.Delete(FileNameWithPath);
                }
                FileStream xfile = new FileStream(FileNameWithPath, FileMode.CreateNew, System.IO.FileAccess.Write);
                workbook.Write(xfile);
                xfile.Close();
                ReturnResult.IsConfirmed = true;
                ReturnResult.ResponseMessage = "Export Successfully.";

                return ReturnResult;
            }
            catch (Exception ex)
            {
                ReturnResult.IsConfirmed = false;
                ReturnResult.ResponseMessage = ex.Message;
                return ReturnResult;
            }
        }

        private NPOIReturnObject MainExportExcelWithNPOIAutosize(DataTable dt, string FileNameWithPath, string extension, string SheetName, string[] ColumnsNameinArray = null, List<string> ColumnNameinList = null)
        {
            NPOIReturnObject ReturnResult = new NPOIReturnObject();
            try
            {
                IWorkbook workbook = null;

                if (extension.IndexOf(".") > -1)
                {
                    extension = extension.Replace(".", "");
                }

                if (extension == "xlsx")
                {
                    workbook = new XSSFWorkbook();
                }
                else if (extension == "xls")
                {
                    workbook = new HSSFWorkbook();
                }
                else
                {
                    ReturnResult.IsConfirmed = false;
                    ReturnResult.ResponseMessage = "File format is not supported";
                    return ReturnResult;
                }

                ISheet sheet1 = workbook.CreateSheet(SheetName);
                IRow row1 = (IRow)sheet1.CreateRow(0);

                //'Coulumn Header set in excel
                if (ColumnsNameinArray != null && ColumnsNameinArray.Length > 0)
                {
                    for (int j = 0; j < ColumnsNameinArray.Length; j++)
                    {
                        ICell cell = (ICell)row1.CreateCell(j);
                        string columnName = ColumnsNameinArray[j];
                        cell.SetCellValue(columnName);
                    }
                }
                else if (ColumnNameinList != null && ColumnNameinList.Count > 0)
                {
                    for (int j = 0; j < ColumnNameinList.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        string columnName = ColumnNameinList[j];
                        cell.SetCellValue(columnName);
                    }
                }
                else
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row1.CreateCell(j);
                        string columnName = dt.Columns[j].ColumnName;
                        cell.SetCellValue(columnName);
                    }
                }


                //'Set All coumn values
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet1.CreateRow(i + 1);

                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        string columnName = dt.Columns[j].ColumnName;
                        if (ColumnsNameinArray != null && ColumnsNameinArray.Length > 0)
                        {
                            for (int colarry = 0; colarry < ColumnsNameinArray.Length; colarry++)
                            {
                                if (dt.Columns[j].ColumnName == ColumnsNameinArray[colarry])
                                {
                                    ICell cell = row.CreateCell(colarry);
                                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                                }
                            }
                        }
                        else if (ColumnNameinList != null && ColumnNameinList.Count > 0)
                        {
                            for (int colList = 0; colList < ColumnNameinList.Count; colList++)
                            {
                                if (dt.Columns[j].ColumnName == ColumnNameinList[colList])
                                {
                                    ICell cell = row.CreateCell(colList);
                                    cell.SetCellValue(dt.Rows[i][columnName].ToString());
                                }
                            }
                        }
                        else
                        {
                            ICell cell = row.CreateCell(j);
                            cell.SetCellValue(dt.Rows[i][columnName].ToString());
                        }
                    }
                }

            

                if (File.Exists(FileNameWithPath))
                {
                    File.Delete(FileNameWithPath);
                }

                int lastColumNum = sheet1.GetRow(0).LastCellNum;
                for (int z = 0; z <= lastColumNum; z++)
                {
                    sheet1.AutoSizeColumn(z);
                    GC.Collect();
                }

                if (sheet1.PhysicalNumberOfRows > 0)
                {
                    IRow headerRow = sheet1.GetRow(0);
                    //headerRow.Height =100;
                    for (int x = 0, l = headerRow.LastCellNum; x < l; x++)
                    {
                        sheet1.AutoSizeColumn(x);
                        GC.Collect();
                    }
                }



                FileStream xfile = new FileStream(FileNameWithPath, FileMode.CreateNew, System.IO.FileAccess.Write);
                workbook.Write(xfile);
                xfile.Close();
                ReturnResult.IsConfirmed = true;
                ReturnResult.ResponseMessage = "Export Successfully.";

                return ReturnResult;
            }
            catch (Exception ex)
            {
                ReturnResult.IsConfirmed = false;
                ReturnResult.ResponseMessage = ex.Message;
                return ReturnResult;
            }
        }

        private NPOIReturnObject MainExportExcelWithNPOI(DataSet ds, string FileNameWithPath, string extension, string SheetName, string[] ColumnsNameinArray = null, List<string> ColumnNameinList = null)
        {
            NPOIReturnObject ReturnResult = new NPOIReturnObject();
            try
            {

                // Imports all tables from DataSet to new file.
                foreach (DataTable dt in ds.Tables)
                {

                    IWorkbook workbook = null;
                    if (extension.IndexOf(".") > -1)
                    {
                        extension = extension.Replace(".", "");
                    }

                    if (extension == "xlsx")
                    {
                        workbook = new XSSFWorkbook();
                    }
                    else if (extension == "xls")
                    {
                        workbook = new HSSFWorkbook();
                    }
                    else
                    {
                        ReturnResult.IsConfirmed = false;
                        ReturnResult.ResponseMessage = "File format is not supported";
                        return ReturnResult;
                    }

                    ISheet sheet1 = workbook.CreateSheet(SheetName);
                    IRow row1 = sheet1.CreateRow(0);

                    //'Coulumn Header set in excel
                    if (ColumnsNameinArray != null && ColumnsNameinArray.Length > 0)
                    {
                        for (int j = 0; j < ColumnsNameinArray.Length; j++)
                        {
                            ICell cell = row1.CreateCell(j);
                            string columnName = ColumnsNameinArray[j];
                            cell.SetCellValue(columnName);
                        }
                    }
                    else if (ColumnNameinList != null && ColumnNameinList.Count > 0)
                    {
                        for (int j = 0; j < ColumnNameinList.Count; j++)
                        {
                            ICell cell = row1.CreateCell(j);
                            string columnName = ColumnNameinList[j];
                            cell.SetCellValue(columnName);
                        }
                    }
                    else
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            ICell cell = row1.CreateCell(j);
                            string columnName = dt.Columns[j].ColumnName;
                            cell.SetCellValue(columnName);
                        }
                    }


                    //'Set All coumn values
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IRow row = sheet1.CreateRow(i + 1);

                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            string columnName = dt.Columns[j].ColumnName;
                            if (ColumnsNameinArray != null && ColumnsNameinArray.Length > 0)
                            {
                                for (int colarry = 0; colarry < ColumnsNameinArray.Length; colarry++)
                                {
                                    if (dt.Columns[j].ColumnName == ColumnsNameinArray[colarry])
                                    {
                                        ICell cell = row.CreateCell(colarry);
                                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                                    }
                                }
                            }
                            else if (ColumnNameinList != null && ColumnNameinList.Count > 0)
                            {
                                for (int colList = 0; colList < ColumnNameinList.Count; colList++)
                                {
                                    if (dt.Columns[j].ColumnName == ColumnNameinList[colList])
                                    {
                                        ICell cell = row.CreateCell(colList);
                                        cell.SetCellValue(dt.Rows[i][columnName].ToString());
                                    }
                                }
                            }
                            else
                            {
                                ICell cell = row.CreateCell(j);
                                cell.SetCellValue(dt.Rows[i][columnName].ToString());
                            }

                        }
                    }
                    if (File.Exists(FileNameWithPath))
                    {
                        File.Delete(FileNameWithPath);
                    }
                    FileStream xfile = new FileStream(FileNameWithPath, FileMode.CreateNew, System.IO.FileAccess.Write);
                    workbook.Write(xfile);
                    xfile.Close();
                    ReturnResult.IsConfirmed = true;
                    ReturnResult.ResponseMessage = "Export Successfully.";
                }

                return ReturnResult;
            }
            catch (Exception ex)
            {
                ReturnResult.IsConfirmed = false;
                ReturnResult.ResponseMessage = ex.Message;
                return ReturnResult;
            }
        }
        public NPOIReturnObject ExportExcelWithNPOI(DataTable dt, string FileNameWithPath)
        {
            string extension = System.IO.Path.GetExtension(FileNameWithPath);
            return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, "Sheet 1");

        }

        public NPOIReturnObject ExportExcelWithNPOI(string FileNameWithPath, DataTable dt, string extension, string SheetName)
        {
            return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, SheetName);
        }

        public NPOIReturnObject ExportExcelWithNPOI(DataTable dt, string FileNameWithPath, string extension, string SheetName, List<string> ColumnName)
        {
            return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, SheetName, null, ColumnName);
        }

        public NPOIReturnObject ExportExcelWithNPOI(DataTable dt, string FileNameWithPath, string SheetName, string[] ColumnsName)
        {
            string extension = System.IO.Path.GetExtension(FileNameWithPath);
            //return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, SheetName, ColumnsName, null);
            

            return MainExportExcelWithNPOIAutosize(dt, FileNameWithPath, extension, SheetName, ColumnsName, null);

        }

        public NPOIReturnObject ExportExcelWithNPOI(DataTable dt, string FileNameWithPath, string extension, string SheetName, string[] ColumnsName)
        {
            return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, SheetName, ColumnsName, null);
        }

        public NPOIReturnObject ExportExcelWithNPOI(DataTable dt, string FolderPath, string FileNameWithextension)
        {
            string extension = System.IO.Path.GetExtension(FileNameWithextension);
            string FileNameWithPath = System.IO.Path.Combine(FolderPath, FileNameWithextension);
            return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, "Sheet 1");
        }

        public NPOIReturnObject ExportExcelWithNPOI(string FolderPath, string FileNameWithextension, DataTable dt, string SheetName)
        {
            string extension = System.IO.Path.GetExtension(FileNameWithextension);
            string FileNameWithPath = System.IO.Path.Combine(FolderPath, FileNameWithextension);
            return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, SheetName);
        }

        public NPOIReturnObject ExportExcelWithNPOI(string FileNameWithPath, DataTable dt, string SheetName)
        {
            string extension = System.IO.Path.GetExtension(FileNameWithPath);
            return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, SheetName);
        }

        public NPOIReturnObject ExportExcelWithNPOI(DataSet dt, string FileNameWithPath, string SheetName, string[] ColumnsName)
        {
            string extension = System.IO.Path.GetExtension(FileNameWithPath);
            return MainExportExcelWithNPOI(dt, FileNameWithPath, extension, SheetName, ColumnsName, null);
        }
    }

    public class NPOIReturnObject
    {
        public string ResponseMessage { get; set; }
        public bool IsConfirmed { get; set; }
    }

}
