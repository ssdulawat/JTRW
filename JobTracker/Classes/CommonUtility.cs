using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker.Classes
{
    public static class CommonUtility
    {
        public static string Remove_EmptyLine_Space(string StringText)
        {
            string CorrectAddress = StringText;

            try
            {
                if (!string.IsNullOrEmpty(StringText))
                {
                    string[] Seprators = new string[1];
                    Seprators[0] = Environment.NewLine;
                    string[] SplitedData = StringText.Split(Seprators, StringSplitOptions.RemoveEmptyEntries);

                    if (SplitedData.Length > 0)
                    {
                        string[] SplitedDataFinal = SplitedData.Where((w) => !string.IsNullOrEmpty(w.Trim())).ToArray();
                        CorrectAddress = string.Join(Environment.NewLine, SplitedDataFinal);
                    }
                }
            }
            catch (Exception ex)
            {
                CorrectAddress = StringText;
            }            
            return CorrectAddress;
        }

        public static DataTable Remove_EmptyLine_Space(DataTable DataTable, string ColumnName)
        {

            try
            {
                if (DataTable.Rows.Count > 0)
                {
                    for (int i = 0; i < DataTable.Rows.Count; i++)
                    {
                        string Address = DataTable.Rows[i][ColumnName].ToString();
                        DataTable.Rows[i][ColumnName] = Remove_EmptyLine_Space(Address);
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return DataTable;
        }

    }
}
