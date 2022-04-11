//using Common;
using Commen2;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.Classes
{
    internal static class JobtrackModule
    {

        //Public sNetworkDrivePath As String = "\\VE-ADSERVER01\ve_net_t630\"
        static string sNetworkDrivePath = @"\\VE-ADSERVER01\ve_net_t630\";

        public static string SortingString(string Str)
        {
            try
            {

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                if (string.IsNullOrEmpty(Str) || string.IsNullOrEmpty(Str))
                {
                    return "";
                }
                sb.Capacity = Str.Length;
                char c = '\0';
                char prev = string.Empty[0];
                int prevCount = 0;
                char[] ArryStr = new char[3];
                for (int i = 0; i < Str.Length; i++)
                {
                    ArryStr[i] = Str[i];
                }
                for (int i = 0; i < Str.Length; i++)
                {
                    for (int j = i; j < Str.Length; j++)
                    {
                        if (ArryStr[i] > ArryStr[j])
                        {
                            char temp = ArryStr[i];
                            ArryStr[i] = ArryStr[j];
                            ArryStr[j] = temp;
                        }
                    }
                }
                for (int i = 0; i < Str.Length; i++)
                {
                    sb.Append(ArryStr[i]);
                }
                return sb.ToString();

            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public static DirectoryInfo UpdatedVersion()
        {
            try
            {
                DirectoryInfo DirInfo = new DirectoryInfo(AppConstants.AppUpdateBasePath);
                DirectoryInfo[] UpdateSetup = DirInfo.GetDirectories();
                List<string> DirList = new List<string>();
                foreach (DirectoryInfo DI in UpdateSetup)
                {
                    if (DI.Name.Contains("JT Version"))
                    {
                        DirList.Add(DI.Name);
                    }
                }
                if (DirList.Count > 0)
                {

                    DirList.Sort();
                    string NEwVersionName = DirList[DirList.Count - 1].ToString().Replace("JT Version", "").Trim();
                    if (NEwVersionName !=  cProgramInfo.sApplicationVersion)
                    {
                        foreach (DirectoryInfo DI in UpdateSetup)
                        {
                            if (DI.Name.Contains(NEwVersionName))
                            {
                                return DI;
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public static void RunUpdatetion()
        {
            DirectoryInfo dirinfo = UpdatedVersion();
            try
            {

                if (!(dirinfo == null))
                {
                    if (MessageBox.Show("New Updated Available! You want to update.", "JT Updates  Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //If Shell("C:\WINDOWS\system32\MsiExec.exe /x{61661A37-68B9-4A97-A40E-4F44C10734CF}", AppWinStyle.Hide) > 0 Then
                        if (Microsoft.VisualBasic.Interaction.Shell("C:\\WINDOWS\\system32\\MsiExec.exe /x{61661A37-68B9-4A97-A40E-4F44C10734CF}") > 0)
                        {

                            Process.Start(dirinfo.FullName + "\\Setup.exe");
                        }

                        //msiexec.exe /i "C:\Example.msi"
                        //Shell("msiexec.exe /i """ & dirinfo.FullName + "\Setup.exe"" /qn")
                        //End If

                    }
                }
                else
                {
                    MessageBox.Show("No new updates!", "JT Updates  Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Process.Start(dirinfo.FullName + "\\Setup.exe");
            }
        }
        public static void AddCheck(this List<int> ListArray, int value)
        {
            if (ListArray.IndexOf(value) == -1)
            {
                ListArray.Add(value);
            }
        }
    }
}
