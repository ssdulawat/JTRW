using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class BaseRepository
    {
        //public EFDbContext db { get; set; }

        public BaseRepository()
        {            
        }

        protected EFDbContext GetDbContext()
        {
            EFDbContext context = new EFDbContext();
            return context;
        }

        protected TestVariousInfo_WithDataEntities GetDbContextNew()
        {

            TestVariousInfo_WithDataEntities context = new TestVariousInfo_WithDataEntities();
            return context;
        }

        public string DatabaseNameNew(TestVariousInfo_WithDataEntities db2)
        {           
            return db2.Database.Connection.ConnectionString.ToString(); ;
        }

        public string LoginActivityInfo(EFDbContext db,string MethodName, string frmName)
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

        public string LoginActivityInfoNew(TestVariousInfo_WithDataEntities db, string MethodName, string frmName)
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
    }
}
