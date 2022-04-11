using Common;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public static class StMethod
    {
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

        public static int GetDefaultTableVersion()
        {
            int defualtTableVersion = 0;
            using (EFDbContext db = new EFDbContext())
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

        public static List<T> GetList<T>(string Sql) where T : class
        {
            List<T> result;
            using (EFDbContext db = new EFDbContext())
            {
                result = db.Database.SqlQuery<T>(Sql).ToList();
            }
            return result;
        }

        public static DataTable GetListDT<T>(string Sql) where T : class
        {
            List<T> result;
            using (EFDbContext db = new EFDbContext())
            {
                result = db.Database.SqlQuery<T>(Sql).ToList();
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

        public static int GetSingleInt(string Sql)
        {
            Int32 nRet = 0;
            using (EFDbContext db = new EFDbContext())
            {
                nRet = db.Database.SqlQuery<int>(Sql).FirstOrDefault();
            }
            return nRet;
        }

        public static int UpdateRecord(string Sql, List<SqlParameter> Param)
        {
            Int32 nRet = 0;
            using (EFDbContext db = new EFDbContext())
            {
                nRet = db.Database.ExecuteSqlCommand(Sql, Param.ToArray());
            }
            return nRet;
        }

        public static int UpdateRecord(string Sql)
        {
            Int32 nRet = 0;
            using (EFDbContext db = new EFDbContext())
            {
                nRet = db.Database.ExecuteSqlCommand(Sql);
            }
            return nRet;
        }
    }
}