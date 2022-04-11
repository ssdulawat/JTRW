//using Common;
using Commen2;
using ComponentFactory.Krypton.Toolkit;
using DataAccessLayer;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
using JobTracker.JobTrackingMDIForm;
using JobTracker.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker
{
    static class Program
    {
        #region Global variable
        //private static string EmailTable;
        //private static string TableUpdateRecord = "0";
        //private static string TableInsertRecord = "0";
        //private static string TableDeleteRecord = "0";
        //private static string SenderEmailAddress;
        //private static string SenderEmailPassword;
        //private static bool SendEmailSuccessful;
        //private static Form frm = new Form();
        //private static int ScreenWidth;
        //private static int ScreenHeight;
        private static Int64 JobID;
        ////public bool admintools;
        private static char ReportStatus;
        private static long ColorId;
        private static bool CalEmailRem;
        private static string InvoiceEmailAddress;
        private static double TotalVECostAmount;
        ////public delegate void LoginChangeEventHandler(object sender, EventArgs e);
        ////public event LoginChangeEventHandler LoginChange;

        public static JobAndTrackingMDI ofrmMain = null;

        //Calender Constants
        public static string ChBoxSearchString;
        public static string QueryStr;
        #endregion

        #region Mdi Property
        public static Int64 GetJobID
        {
            get
            {
                return JobID;
            }
            set
            {
                JobID = value;
            }
        }

        //public static object LoginformObject { get; set; }

        public static double GetTotalVECostAmount
        {
            get
            {
                return TotalVECostAmount;
            }
            set
            {
                TotalVECostAmount = value;
            }
        }

        public static char getRptStatus
        {
            get
            {
                return ReportStatus;
            }
            set
            {
                ReportStatus = value;
            }
        }
        public static long GetColorID
        {
            get
            {
                return ColorId;
            }
            set
            {
                ColorId = (Int16)value;
            }
        }
        public static bool CallEmailRemFrm
        {
            get
            {
                return CalEmailRem;
            }
            set
            {
                CalEmailRem = value;
            }
        }
        public static string DueInvoiceEmailAddress
        {
            get
            {
                return InvoiceEmailAddress;
            }
            set
            {
                InvoiceEmailAddress = value;
            }
        }

        ////public static bool IsAdmin
        ////{

        ////    set
        ////    {
        ////        foreach (Form frm in this.MdiChildren)
        ////        {
        ////            if (frm.IsMdiContainer != true)
        ////            {
        ////                if (frm.Text == JobStatus.Instance.Text)
        ////                {
        ////                    if (value)
        ////                    {
        ////                        JobStatus.Instance.grvJobList.Columns("IsDisable").Visible = true;
        ////                    }
        ////                    else
        ////                    {
        ////                        JobStatus.Instance.grvJobList.Columns("IsDisable").Visible = false;
        ////                    }
        ////                }
        ////            }
        ////        }
        ////    }
        ////}

        ////public static string LoginButtonText
        ////{
        ////    set
        ////    {
        ////        lblLogin.Text = value;
        ////    }
        ////    get
        ////    {
        ////        return lblLogin.Text;
        ////    }
        ////}

        public static bool InvoiceTime { get; set; }
        public static bool InvoiceExpenses { get; set; }
        public static bool InvoiceItem { get; set; }
        public static bool InvoiceAll { get; set; }
        public static bool InvoiceReportFlag { get; set; }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeValues();
            ofrmMain = new JobAndTrackingMDI();

          Application.Run(new FrmJTLogin());

          

            //LogMeIn();
            //if (cGlobal.bIsAdminLoggedIn)
            //    Application.Run(ofrmMain);
        }

        private static void LogMeIn()
        {
            try
            {
                FrmJTLogin oLogin = new FrmJTLogin();
                //oLogin.CallFromMdi = true;
                oLogin.ShowDialog();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void InitializeValues()
        {
            try
            {
                cErrorLog.LogFilePath = cGlobal.sLogPath;
            }
            catch (Exception ex)
            {
                cErrorLog.WriteLog("Program", "InitializeValues", ex.Message);
            }
        }

        public static void LoadDefaultSettings()
        {
            try
            {
                if (!System.IO.File.Exists(cGlobal.sApplicationPath + @"\VESoftwareSetting.xml"))
                {
                    if (System.IO.File.Exists(cGlobal.sApplicationPath + @"\VESoftwareSetting_Default.xml"))
                    {
                        System.IO.File.Copy(cGlobal.sApplicationPath + @"\VESoftwareSetting_Default.xml", cGlobal.sApplicationPath + @"\VESoftwareSetting.xml");
                        System.IO.File.Delete(cGlobal.sApplicationPath + @"\VESoftwareSetting_Default.xml");
                    }
                    else
                        MessageBox.Show("Unable to load default settings. Please contact support.");
                }

                //if (!System.IO.File.Exists(cGlobal.sApplicationPath + @"VESoftwareSetting.xml"))
                //{
                //    if (System.IO.File.Exists(cGlobal.sApplicationPath + @"VESoftwareSetting_Default.xml"))
                //    {
                //        System.IO.File.Copy(cGlobal.sApplicationPath + @"VESoftwareSetting_Default.xml", cGlobal.sApplicationPath + @"\VESoftwareSetting.xml");
                //        System.IO.File.Delete(cGlobal.sApplicationPath + @"VESoftwareSetting_Default.xml");
                //    }
                //    else
                //        MessageBox.Show("Unable to load default settings. Please contact support.");
                //}


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void Showform()
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.IsMdiContainer == true)
                    frm.Close();
            }
        }

        public static string ZeroIfEmpty(this string s)
        {
            return string.IsNullOrEmpty(s) ? "0" : s;
        }

        public static void closeAll()
        {
            FormCollection fc = Application.OpenForms;
            if (fc.Count > 1)
            {
                for (int i = (fc.Count); i > 1; i--)
                {
                    Form selectedForm = Application.OpenForms[i - 1];
                    selectedForm.Close();
                }
            }
        }

        //var list = db.Database.SqlQuery<IEnumerable<string>>(Query).ToList();
        public static DataTable ToDataTableJobStaus<T>(List<T> items)
        {
            DataTable dataTable = null;
            try
            {
                //if (items is null)
                //    return dataTable;

                dataTable = new DataTable(typeof(T).Name);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }


        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = null;
            try
            {
                //if (items is null)
                //    return dataTable;

                dataTable = new DataTable(typeof(T).Name);
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataTable;
        }

        public static string GetAgingFilePath()
        {
            string path = null;
            try
            {
                using (EFDbContext db = new EFDbContext())
                {
                    path = db.Database.SqlQuery<string>("SELECT FilePath FROM AgingFileInfo").FirstOrDefault();
                }


            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return path;
        }


        public static string GetAgingFilePathNew()
        {
            string path = null;
            try
            {
                
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    path = db.Database.SqlQuery<string>("SELECT FilePath FROM AgingFileInfo").FirstOrDefault();
                }


            }
            catch (SqlException ex)
            {
                KryptonMessageBox.Show(ex.Message, "Update Invoice Due", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return path;
        }


        public static bool CloseExistingForm(string formContent)
        {
            bool bRet = false;
            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Text.Equals(formContent))
                {
                    frm.Close();
                    bRet = true;
                }
            }
            return bRet;
        }

        public static string GenerateCommandText(string storedProcedure, SqlParameter[] parameters)
        {
            string CommandText = "EXEC {0} {1}";
            string[] ParameterNames = new string[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                ParameterNames[i] = parameters[i].ParameterName;
            }

            return string.Format(CommandText, storedProcedure, string.Join(",", ParameterNames));
        }

        //public string ConnectionStringPCTracker
        //{
        //    get
        //    {
        //        if (Properties.Settings.Default.IsTestDatabase)
        //        {
        //            return ConfigurationSettings.AppSettings["PCTracker_Test"].ToString();
        //        }
        //        else
        //        {
        //            return ConfigurationSettings.AppSettings["PCTracker"].ToString();
        //        }
        //    }
        //}
        //public string ConnectionStringVariousInfo
        //{
        //    get
        //    {
        //        if (Properties.Settings.Default.IsTestDatabase)
        //        {
        //            return ConfigurationSettings.AppSettings["JobListAndTracking_Test"].ToString();
        //        }
        //        else
        //        {
        //            return ConfigurationSettings.AppSettings["JobListAndTracking"].ToString();
        //        }
        //    }
        //}        
        public static bool CheckActiveWebUploadStatus()
        {
            bool bRet = false;
            try
            {
                AppSettings settings = new AppSettings();
                using (EFDbContext db = new EFDbContext())
                {
                    settings = StMethod.GetSingle<AppSettings>("SELECT ActiveWebUpload FROM AppSetting ");
                }
                bRet = settings.ActiveWebUpload;
            }
            catch (Exception ex)
            {
            }
            return bRet;
        }

        public static bool CheckActiveWebUploadStatusNew()
        {
            bool bRet = false;
            try
            {
                
                AppSettings settings = new AppSettings();
                using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
                {
                    settings = StMethod.GetSingleNew<AppSettings>("SELECT ActiveWebUpload FROM AppSetting ");
                }
                bRet = settings.ActiveWebUpload;
            }
            catch (Exception ex)
            {
            }
            return bRet;
        }

        public static Color ChangeTraficLightColor(long ColorCode)
        {
            switch (ColorCode)
            {
                case 1:
                    return Color.Green;
                case 2:
                    return Color.Orange;
                case 3:
                    return Color.Yellow;
                case 4:
                    return Color.Red;
                case 5:
                    return Color.Black;
                case 6:
                    return Color.Blue;
            }
            return new Color();
        }

        public static string GetColumnName(int aging)
        {
            string sColumn = string.Empty;

            if ((aging >= 0 && aging < 15))
                sColumn = "Age0Action";
            else if (aging >= 15 && aging < 30)
                sColumn = "Age15Action";
            else if (aging >= 30 && aging < 45)
                sColumn = "Age30Action";
            else if (aging >= 45 && aging < 60)
                sColumn = "Age45Action";
            else if (aging >= 60 && aging < 75)
                sColumn = "Age60Action";
            else if (aging >= 75 && aging < 90)
                sColumn = "Age75Action";
            else if (aging >= 90 && aging < 105)
                sColumn = "Age90Action";
            else if (aging >= 105)
                sColumn = "Age105Action";
            return sColumn;
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
        
        public static bool CheckBoxState(object obj)
        {
            if (obj is null)
                return false;
            if (Convert.ToBoolean(obj) == true)
                return true;
            if (((CheckState)obj) == CheckState.Checked)
                return true;
            else
                return false;
        }
    }
}