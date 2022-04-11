using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using System.Web;

namespace Common
{
    public static class GenericHelper
    {
        public static string FormateDate(object value)
        {
            if (value is null)
                return "";
            return Convert.ToString(value);
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static DataSet ToDataSet<T>(List<T> items)
        {
            DataSet dataset = new DataSet(typeof(T).Name);
            //DataTable dataTable = new DataTable(typeof(T).Name);
            
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  



                dataset.Tables.Add(new DataTable());
                dataset.Tables[0].Columns.Add(prop.Name);

                //dataTable.Columns.Add(prop.Name);
            }



            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    values[i] = Props[i].GetValue(item, null);
                }
                //dataTable.Rows.Add(values);
                dataset.Tables[0].Rows.Add(values);

            }
            return dataset;
            //return dataTable;
        }

        public static string GetJobNumber(string Jobstr)
        {
            try
            {
                string[] str = Jobstr.Split('-');
                string Newstr = null;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str.Length == 1)
                    {
                        Newstr = str[i];
                    }
                    else
                    {
                        Newstr = str[i] + "-" + str[i + 1];
                    }
                    break;
                }
                return Newstr;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
