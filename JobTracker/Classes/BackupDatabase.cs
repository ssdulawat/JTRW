using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.Classes
{
    public class BackUpDatabase
    {
        private DataTable DtFolderName;
        public static SqlConnection SqlCon;
        public static SqlCommand sqlCmd;
        
        public static void CreateConection(string ConnectionString)
        {
            SqlCon = new SqlConnection(ConnectionString);
        }

        public static DataTable NameOfSqlServer()
        {
            try
            {
                System.Data.Sql.SqlDataSourceEnumerator SqlEnumerator = System.Data.Sql.SqlDataSourceEnumerator.Instance;
                System.Data.DataTable dTable = SqlEnumerator.GetDataSources();
                return dTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Listing Server name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }
       
        public static object TakeDatabaseBackUp(string BackupPath, string BakupFileName)
        {
            string BackupQuery = "BACKUP DATABASE " + BakupFileName + " TO DISK = '" + BackupPath + "'";
            string BackupInfo = null;
            sqlCmd = new SqlCommand(BackupQuery, SqlCon);
            try
            {
                SqlCon.Close();
                SqlCon.Open();
                sqlCmd.ExecuteScalar();
                SqlCon.Close();
                MessageBox.Show("Database bakup successfully at palce :-" + BackupPath, "Backup Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                SqlCon.Close();
            }
            return null;
        }

        public static object TakeDatabaseBackUpEdited(string BackupPath, string BakupFileName)
        {
            string BackupQuery = "BACKUP DATABASE " + BakupFileName + " TO DISK = '" + BackupPath + "'";
            string BackupInfo = null;
            sqlCmd = new SqlCommand(BackupQuery, SqlCon);
            try
            {
                SqlCon.Close();
                SqlCon.Open();
                sqlCmd.ExecuteScalar();
                SqlCon.Close();
                MessageBox.Show("Database bakup successfully at palce :-" + BackupPath, "Backup Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                SqlCon.Close();
            }
            return null;
        }

        public static object TakeDatabaseBackUpTest(string BackupPath, string BakupFileName)
        {

            string bk = "D:\\1.bak";

            string BackupQuery = "BACKUP DATABASE " + BakupFileName + " TO DISK = '" + bk + "'";

            string BackupInfo = null;


            //BACKUP DATABASE testDB
            //TO DISK = 'D:\backups\testDB.bak';

            sqlCmd = new SqlCommand(BackupQuery, SqlCon);
            try
            {
                SqlCon.Close();
                SqlCon.Open();
                sqlCmd.ExecuteScalar();
                SqlCon.Close();
                MessageBox.Show("Database bakup successfully at palce :-" + BackupPath, "Backup Infomation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                SqlCon.Close();
            }
            return null;
        }


    }
}