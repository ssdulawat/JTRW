using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.Reflection;
using System.Data.SqlClient;
using System.IO;

using System.Windows;

namespace JobTracker
{

	[RunInstaller(true)]
	public partial class Installer1 : Installer 
	{
		private string logFilePath = "C:\\setupLog.txt";
		public Installer1()
		{
			InitializeComponent();
		}

	

		private string GetSql(string Name)
		{
			try
			{

				// Gets the current assembly.
				Assembly Asm = Assembly.GetExecutingAssembly();

				// Resources are named using a fully qualified name.
				Stream strm = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name);

				// Reads the contents of the embedded file.
				StreamReader reader = new StreamReader(strm);

				return reader.ReadToEnd();
			}
			catch (Exception ex)
			{
				Log(ex.Message);
				throw ex;
			}
		}

		private void ExecuteSql(string serverName, string dbName, string Sql)
		{
			string connStr = "Data Source=" + serverName + ";Initial Catalog=" +
									dbName + ";Integrated Security=True";
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				try
				{
					Server server = new Server(new ServerConnection(conn));
					server.ConnectionContext.ExecuteNonQuery(Sql);
				}
				catch (Exception ex)
				{
					Log(ex.Message);
				}
			}
		}

		protected void AddDBTable(string serverName)
		{
			try
			{
				// Creates the database and installs the tables.         
				string strScript = GetSql("sql.txt");
				

				ExecuteSql(serverName, "master", strScript);

			}
			catch (Exception ex)
			{
				//Reports any errors and abort.
				Log(ex.Message);
				throw ex;
			}
		}
		public override void Install(System.Collections.IDictionary stateSaver)
		{
			base.Install(stateSaver);
			Log("Setup started");
			AddDBTable(this.Context.Parameters["servername"]);

		}

		public void Log(string str)
		{
			StreamWriter Tex;
			try
			{
				Tex = File.AppendText(this.logFilePath);
				Tex.WriteLine(DateTime.Now.ToString() + " " + str);
				Tex.Close();
			}
			catch
			{

			}

		}
	}
}
