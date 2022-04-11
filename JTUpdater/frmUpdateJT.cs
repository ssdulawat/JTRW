//using Common;
using Commen2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace JTUpdater
{
    public partial class frmUpdateJT : Form
    {
        public frmUpdateJT()
        {
            InitializeComponent();
        }

		private void btnUpdateJT_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				RunningInstance();
				var proc = Process.GetProcessesByName(AppConstants.AppProcessName);
				for (int i = 0; i < proc.Count(); i++)
				{
					proc[i].Kill();
				}

				if (Directory.Exists(AppConstants.AppUpdateDirectory))
				{
					foreach (string fName in Directory.GetFiles(AppConstants.AppUpdateDirectory))
					{
						if (File.Exists(fName))
						{
							string dFile = string.Empty;
							dFile = Path.GetFileName(fName);
							string dFilePath = string.Empty;
							dFilePath = Application.StartupPath + "\\" + dFile;
							File.Copy(fName, dFilePath, true);
						}
					}
					foreach (string fDir in Directory.GetDirectories(AppConstants.AppUpdateDirectory))
					{
						// Dim TargetDir As String = "N:\VE\Miscell Programs and components\VE JobTracker\JT Updates" & "\" & fDir
						DirectoryInfo DirInfo = new DirectoryInfo(fDir);
						if (Directory.Exists(fDir))
						{
							string DestPath = Application.StartupPath;
							//DestPath = "D:\Test Update"
							//Dim ChildFile As FileInfo
							Microsoft.VisualBasic.Devices.Computer CopyFolder = new Microsoft.VisualBasic.Devices.Computer();

							
							//Dim DestDir As DirectoryInfo = New DirectoryInfo(DestPath)
							//Dim SourceDir As DirectoryInfo = New DirectoryInfo(fDir)
							//For Each ChildFile In SourceDir.GetFiles

							//    ChildFile.CopyTo(Path.Combine(DestDir.FullName, ChildFile.Name), True)
							//    If Not File.Exists(Path.Combine(DestDir.FullName, ChildFile.Name)) Then

							//        ChildFile.CopyTo(Path.Combine(DestDir.FullName, ChildFile.Name), False)

							//    End If
							//Next
							if (CopyFolder.FileSystem.DirectoryExists(DestPath + "\\" + DirInfo.Name))
							{

								DestPath = DestPath + "\\" + DirInfo.Name;
								CopyFolder.FileSystem.CopyDirectory(fDir, DestPath, true);
							}
							else
							{
								CopyFolder.FileSystem.CreateDirectory(DestPath + "\\" + DirInfo.Name);
								DestPath = DestPath + "\\" + DirInfo.Name;
								CopyFolder.FileSystem.CopyDirectory(fDir, DestPath);
							}
						}
					}
					//  KryptonMessageBox.Show("Application Update Successfully")
					MessageBox.Show("Application Update Successfully");
				}
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Important:" + Environment.NewLine + "If you have any problem in update Job tracker Application process. Please read these instructions carefully and follow these instructions and then restart your job Tracker Application." + Environment.NewLine + " 1. Close this Application " + Environment.NewLine + " 2. Then Right click on the Job tracker program shortcut, then click on Properties " + Environment.NewLine + " 3. When Properties window is opened, then click on Compatibility tab. " + Environment.NewLine + " 4. Check the Run this program as an administrator box, and click on Apply Button. " + Environment.NewLine + " 5. and click on OK, and Finally Run your Job tracker Application ", "Job Tracker Update");
			}
		}

		protected void RunningInstance()
		{
			//Dim current As Process
			//current = Process.GetCurrentProcess()			
			Process[] processes = System.Diagnostics.Process.GetProcesses();
			foreach (Process process in processes)
			{
				// MessageBox.Show(process.ProcessName)
				if (process.ProcessName == AppConstants.AppProcessName)
				{
					//  KryptonMessageBox.Show("Application is already opened please check system tray")
					MessageBox.Show("Application is already opened please check system tray");
					this.Close();
				}
			}
		}

		private void btncancel_Click(System.Object sender, System.EventArgs e)
		{
			Process.Start(Path.Combine(Application.StartupPath,AppConstants.AppExeName));
			this.Close();
		}

		private void frmUpdateJT_Load(System.Object sender, System.EventArgs e)
		{
		}
	}
}