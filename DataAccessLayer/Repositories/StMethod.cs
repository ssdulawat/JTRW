using Common;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public static class StMethod
    {
        public enum eDatabase
        {
            VariousInfo=0,
            PCTracker=1,
            WebDB=2,
            TestVariousInfoRW=3
        }

        public static string LoginActivityInfo(EFDbContext db, string MethodName, string frmName)
        {

            DateTime dt = DateTime.Today;
            string Query = "INSERT INTO ActivityInfo  (PCName, MethodName, frmName, ModifyDt) VALUES ( @PCName, @MethodName, @frmName, @dt)";
            SqlCommand CMD = new SqlCommand(Query);
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@PCName", System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString()));
            Param.Add(new SqlParameter("@MethodName", MethodName.ToString()));
            Param.Add(new SqlParameter("@frmName", frmName));
            Param.Add(new SqlParameter("@dt", DateTime.Today));
            if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
            {

            }
            return "";
        }

        public static string LoginActivityInfoNew(TestVariousInfo_WithDataEntities db, string MethodName, string frmName)
        {

            DateTime dt = DateTime.Today;
            string Query = "INSERT INTO ActivityInfo  (PCName, MethodName, frmName, ModifyDt) VALUES ( @PCName, @MethodName, @frmName, @dt)";
            SqlCommand CMD = new SqlCommand(Query);
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@PCName", System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString()));
            Param.Add(new SqlParameter("@MethodName", MethodName.ToString()));
            Param.Add(new SqlParameter("@frmName", frmName));
            Param.Add(new SqlParameter("@dt", DateTime.Today));
            if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
            {

            }
            return "";
        }


        public static string LoginActivityInfo(string MethodName, string frmName)
        {
            DateTime dt = DateTime.Today;
            string Query = "INSERT INTO ActivityInfo  (PCName, MethodName, frmName, ModifyDt) VALUES ( @PCName, @MethodName, @frmName, @dt)";
            SqlCommand CMD = new SqlCommand(Query);
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@PCName", System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString()));
            Param.Add(new SqlParameter("@MethodName", MethodName.ToString()));
            Param.Add(new SqlParameter("@frmName", frmName));
            Param.Add(new SqlParameter("@dt", DateTime.Today));
            using (EFDbContext db = new EFDbContext())
            {
                if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                {
                }
            }
            return "";
        }

        public static string LoginActivityInfoNew(string MethodName, string frmName)
        {
            DateTime dt = DateTime.Today;
            string Query = "INSERT INTO ActivityInfo  (PCName, MethodName, frmName, ModifyDt) VALUES ( @PCName, @MethodName, @frmName, @dt)";
            SqlCommand CMD = new SqlCommand(Query);
            List<SqlParameter> Param = new List<SqlParameter>();
            Param.Add(new SqlParameter("@PCName", System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString()));
            Param.Add(new SqlParameter("@MethodName", MethodName.ToString()));
            Param.Add(new SqlParameter("@frmName", frmName));
            Param.Add(new SqlParameter("@dt", DateTime.Today));
            
            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
            {
                if (db.Database.ExecuteSqlCommand(CMD.CommandText, Param.ToArray()) == 1)
                {
                }
            }
            return "";
        }

        public static int GetDefaultTableVersion()
        {
            int defualtTableVersion = 0;



            using (EFDbContext db = new EFDbContext())
            {
                defualtTableVersion = db.Database.SqlQuery<int>("select TOP 1 TableVersionId from VersionTable order by TableVersionId").FirstOrDefault();
            }
            return defualtTableVersion;
        }

        public static int GetDefaultTableVersionNew()
        {
            int defualtTableVersion = 0;


            
            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
            {
                defualtTableVersion = db.Database.SqlQuery<int>("select TOP 1 TableVersionId from VersionTable order by TableVersionId").FirstOrDefault();
            }
            return defualtTableVersion;
        }


        public static bool IsMastersExist(string query)
        {
            bool bRet = false;
            using (EFDbContext db = new EFDbContext())
            {
                var data = db.Database.SqlQuery<int>(query).FirstOrDefault();
                bRet = (data > 0);
            }
            return bRet;
        }

        public static bool IsMastersExistNew(string query)
        {
            bool bRet = false;            
            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
            {
                var data = db.Database.SqlQuery<int>(query).FirstOrDefault();
                bRet = (data > 0);
            }
            return bRet;
        }

        public static List<colPMM> GetMasterItemPM()
        {
            List<colPMM> result;
            string queryString = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack";
            using (EFDbContext db = new EFDbContext())
            {
                result = db.Database.SqlQuery<colPMM>(queryString).ToList();
            }
            return result;
        }

        public static List<colPMM> GetMasterItemPMNew()
        {
            List<colPMM> result;
            string queryString = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='PM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack";

            using (TestVariousInfo_WithDataEntities db=new TestVariousInfo_WithDataEntities())
            {
                result = db.Database.SqlQuery<colPMM>(queryString).ToList();
            }
            return result;
        }


        public static List<colPreRequirTMM> GetMasterItemTM_D()
        {
            List<colPreRequirTMM> result;
            string queryString = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) AND (isDisable <> 1 or IsDisable is  null) ORDER BY cTrack";
            using (EFDbContext db = new EFDbContext())
            {
                result = db.Database.SqlQuery<colPreRequirTMM>(queryString).ToList();
            }
            return result;
        }

        public static List<colPreRequirTMM> GetMasterItemTM()
        {
            List<colPreRequirTMM> result;
            string queryString = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack";
                       

            using (EFDbContext db = new EFDbContext())
            {
                result = db.Database.SqlQuery<colPreRequirTMM>(queryString).ToList();
            }

            return result;
        }

        public static List<colPreRequirTMM> GetMasterItemTMNew()
        {
            List<colPreRequirTMM> result;
            string queryString = "SELECT cTrack ,Id FROM MasterItem WHERE cGroup='TM' and (IsDelete=0 or IsDelete is null) ORDER BY cTrack";

            using (TestVariousInfo_WithDataEntities db=new TestVariousInfo_WithDataEntities())
            {
                result = db.Database.SqlQuery<colPreRequirTMM>(queryString).ToList();
            }

            return result;
        }



        public static List<T> GetList<T>(string Sql, eDatabase _dbType = eDatabase.VariousInfo) where T : class
        {
            List<T> result;
            using (DbContext db = GetDbConnection(_dbType))
            {
                result = db.Database.SqlQuery<T>(Sql).ToList();
            }
            return result;
        }

        public static List<T> GetListNew<T>(string Sql, eDatabase _dbType = eDatabase.TestVariousInfoRW) where T : class
        {
            List<T> result;
            using (DbContext db = GetDbConnection(_dbType))
            {
                result = db.Database.SqlQuery<T>(Sql).ToList();
            }

            
            return result;
        }



        public static DataTable GetListDT<T>(string Sql, eDatabase _dbType = eDatabase.VariousInfo) where T : class
        {
            List<T> result = null;
            using (DbContext db = GetDbConnection(_dbType))
            {
                result = db.Database.SqlQuery<T>(Sql).ToList();
            }
            return GenericHelper.ToDataTable(result);
        }


        public static DataTable GetListDTNew<T>(string Sql, eDatabase _dbType = eDatabase.TestVariousInfoRW) where T : class
        {
            List<T> result = null;                        
            using (DbContext db = GetDbConnection(_dbType))
            {
                result = db.Database.SqlQuery<T>(Sql).ToList();
            }
            return GenericHelper.ToDataTable(result);
        }


        public static DataSet GetListDS<T>(string Sql, eDatabase _dbType = eDatabase.VariousInfo) where T : class
        {
            List<T> result = null;
            using (DbContext db = GetDbConnection(_dbType))
            {
                result = db.Database.SqlQuery<T>(Sql).ToList();
            }
            return GenericHelper.ToDataSet(result);
            //return GenericHelper.ToDataTable(result);
            
        }

        public static DataSet GetListDSNew<T>(string Sql, eDatabase _dbType = eDatabase.TestVariousInfoRW) where T : class
        {
            List<T> result = null;
            using (DbContext db = GetDbConnection(_dbType))
            {
                result = db.Database.SqlQuery<T>(Sql).ToList();
            }
            return GenericHelper.ToDataSet(result);
            //return GenericHelper.ToDataTable(result);

        }

        public static DataTable GetListDT<T>(string Sql, List<SqlParameter> Param, eDatabase _dbType = eDatabase.VariousInfo) where T : class
        {
            List<T> result;
            try
            {
                
                using (DbContext db = GetDbConnection(_dbType))
                {
                    //result = db.Database.SqlQuery<T>(Sql, Param.ToArray()).ToList();

                    result = db.Database.SqlQuery<T>(Sql, Param.ToArray()).AsQueryable().ToList();

                    //List<columns> data = objectContext.ExecuteStoreQuery<columns>(SQLQuery).AsQueryable().ToList();


                }                
                //List<T> result = null;
                //using (DbContext db = GetDbConnection(_dbType))
                //{
                //    result = db.Database.SqlQuery<T>(Sql).ToList();
                //}
                //return GenericHelper.ToDataTable(result);


            }
            catch (Exception)
            {                
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }


        public static DataTable GetListDTNew3<T>(string Sql, List<SqlParameter> Param, eDatabase _dbType = eDatabase.TestVariousInfoRW) where T : class
        {
            List<T> result;
            try
            {

                using (DbContext db = GetDbConnection(_dbType))
                {
                    //result = db.Database.SqlQuery<T>(Sql, Param.ToArray()).ToList();

                    result = db.Database.SqlQuery<T>(Sql, Param.ToArray()).AsQueryable().ToList();

                    //List<columns> data = objectContext.ExecuteStoreQuery<columns>(SQLQuery).AsQueryable().ToList();


                }
                //List<T> result = null;
                //using (DbContext db = GetDbConnection(_dbType))
                //{
                //    result = db.Database.SqlQuery<T>(Sql).ToList();
                //}
                //return GenericHelper.ToDataTable(result);


            }
            catch (Exception)
            {
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }




        public static DataTable GetListDTChecking<T>(string Sql, List<SqlParameter> Param, eDatabase _dbType = eDatabase.VariousInfo) where T : class
        {
            List<T> result;
            try
            {
                using (DbContext db = GetDbConnection(_dbType))
                {
                    result = db.Database.SqlQuery<T>(Sql, Param.ToArray()).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }


        public static DataTable GetListDT<T>(string Sql, object[] Param, eDatabase _dbType = eDatabase.VariousInfo) where T : class
        {
            List<T> result;
            try
            {
                using (DbContext db = GetDbConnection(_dbType))
                {
                    result = db.Database.SqlQuery<T>(Sql, Param.ToArray()).ToList();                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }

        public static T GetSingle<T>(string Sql) where T : class
        {
            T result;
            using (EFDbContext db = new EFDbContext())
            {
                result = db.Database.SqlQuery<T>(Sql).FirstOrDefault();
            }
            return result;
        }

        public static T GetSingleNew<T>(string Sql) where T : class
        {
            T result;            
            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
            {
                result = db.Database.SqlQuery<T>(Sql).FirstOrDefault();
            }
            return result;
        }



        public static int GetSingleInt(string Sql)
        {
            Int32 nRet = 0;
            using (EFDbContext db = new EFDbContext())
            {
                nRet = db.Database.SqlQuery<int>(Sql).FirstOrDefault();
            }
            return nRet;
        }

        public static int GetSingleIntNew(string Sql)
        {
            Int32 nRet = 0;            
            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
            {
                nRet = db.Database.SqlQuery<int>(Sql).FirstOrDefault();
            }
            return nRet;
        }


        public static Int64 GetSingleInt64(string Sql)
        {
            Int64 nRet = 0;
            using (EFDbContext db = new EFDbContext())
            {
                nRet = db.Database.SqlQuery<Int64>(Sql).FirstOrDefault();
            }
            return nRet;
        }

        public static Int64 GetSingleInt64New(string Sql)
        {
            Int64 nRet = 0;
            using (TestVariousInfo_WithDataEntities db = new TestVariousInfo_WithDataEntities())
            {
                nRet = db.Database.SqlQuery<Int64>(Sql).FirstOrDefault();
            }
            return nRet;
        }



        public static int UpdateRecord(string Sql, List<SqlParameter> Param, eDatabase _dbType = eDatabase.VariousInfo)
        {
            Int32 nRet = 0;
            try
            {
                using (DbContext db = GetDbConnection(_dbType))
                {
                    nRet = db.Database.ExecuteSqlCommand(Sql, Param.ToArray());
                }
            }
            catch (Exception)
            {
                throw;                                
            }
            return nRet;
        }


        public static int UpdateRecordNew(string Sql, List<SqlParameter> Param, eDatabase _dbType = eDatabase.TestVariousInfoRW)
        {
            Int32 nRet = 0;
            try
            {
                using (DbContext db = GetDbConnection(_dbType))
                {
                    nRet = db.Database.ExecuteSqlCommand(Sql, Param.ToArray());
                }
            }
            catch (Exception)
            {
                throw;
            }
            return nRet;
        }

        public static int UpdateRecord(string Sql, eDatabase _dbType = eDatabase.VariousInfo)
        {
            Int32 nRet = 0;
            using (DbContext db =  GetDbConnection(_dbType))
            {
                nRet = db.Database.ExecuteSqlCommand(Sql);
            }
            return nRet;
        }

        public static int UpdateRecordNew(string Sql, eDatabase _dbType = eDatabase.TestVariousInfoRW)
        {
            Int32 nRet = 0;
            using (DbContext db = GetDbConnection(_dbType))
            {
                nRet = db.Database.ExecuteSqlCommand(Sql);
            }
            return nRet;
        }

        #region PcTrackerDB
        public static DbContext GetDbConnection(eDatabase _dbType = eDatabase.VariousInfo)
        {
            DbContext dbCon = null;
            switch (_dbType)
            {               
                case eDatabase.VariousInfo:
                    dbCon = new EFDbContext();
                    break;
                case eDatabase.PCTracker:
                    dbCon = new PCTrackerEntities();
                    break;
                case eDatabase.WebDB:
                    dbCon = new EFDbContext("JobTracker.Properties.Settings.Setting");
                    break;
                case eDatabase.TestVariousInfoRW:
                    dbCon = new TestVariousInfo_WithDataEntities();
                    break;
            }
            return dbCon;
        }
        public static DataTable GetTimeData(string JobNumber, string Name, string InvoiceNo, Nullable<System.DateTime> dateFrom, Nullable<System.DateTime> dateTo)
        {
            List<SP_GetInvoiceDetailByJobNumber_All_New_Result> result;
            try
            {
                using (DbContext db = GetDbConnection(eDatabase.VariousInfo))
                {
                    result=((EFDbContext)db).SP_GetInvoiceDetailByJobNumber_All_New(JobNumber,Name,InvoiceNo,dateFrom,dateTo).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }


        public static DataTable GetBJDSearchData(Nullable<int> nOCreditColor, Nullable<int> greenColor, Nullable<int> yellowColor, Nullable<int> orangeColor, Nullable<int> redColor, Nullable<int> blackColor, Nullable<decimal> defaultAmount)
        {
            List<proc_GetBillableJobDisableSearchData_Result> result;
            try
            {
                using (DbContext db = GetDbConnection(eDatabase.VariousInfo))
                {
                    result = ((EFDbContext)db).proc_GetBillableJobDisableSearchData(nOCreditColor, greenColor, yellowColor, orangeColor, redColor, blackColor, defaultAmount).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }


        public static DataTable GetBJDSearchDataNew(Nullable<int> nOCreditColor, Nullable<int> greenColor, Nullable<int> yellowColor, Nullable<int> orangeColor, Nullable<int> redColor, Nullable<int> blackColor, Nullable<decimal> defaultAmount)
        {
            List<proc_GetBillableJobDisableSearchData_Result> result;
            try
            {                
                using (DbContext db = GetDbConnection(eDatabase.TestVariousInfoRW))
                {
                    result = ((TestVariousInfo_WithDataEntities)db).proc_GetBillableJobDisableSearchData(nOCreditColor, greenColor, yellowColor, orangeColor, redColor, blackColor, defaultAmount).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }




        public static DataTable GetBJSearchData(Nullable<int> nOCreditColor, Nullable<int> greenColor, Nullable<int> yellowColor, Nullable<int> orangeColor, Nullable<int> redColor, Nullable<int> blackColor, Nullable<decimal> defaultAmount)
        {
            List<proc_GetBillableJobSearchData_Result> result;
            try
            {
                using (DbContext db = GetDbConnection(eDatabase.VariousInfo))
                {
                    result = ((EFDbContext)db).proc_GetBillableJobSearchData(nOCreditColor, greenColor, yellowColor, orangeColor, redColor, blackColor, defaultAmount).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }


        public static DataTable GetBJSearchData_New(Nullable<int> nOCreditColor, Nullable<int> greenColor, Nullable<int> yellowColor, Nullable<int> orangeColor, Nullable<int> redColor, Nullable<int> blackColor, Nullable<decimal> defaultAmount)
        {
            List<proc_GetBillableJobSearchData_Result> result;
            try
            {                
                using (DbContext db = GetDbConnection(eDatabase.TestVariousInfoRW))
                {
                    result = ((TestVariousInfo_WithDataEntities)db).proc_GetBillableJobSearchData(nOCreditColor, greenColor, yellowColor, orangeColor, redColor, blackColor, defaultAmount).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return GenericHelper.ToDataTable(result);
        }


        #endregion
    }
}