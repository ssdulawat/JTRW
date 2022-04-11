using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Commen2
{
    //class AppConstants
    public static class AppConstants
    {
        public const string AssemblyName = "JobTracker.exe";
        public static string sNetworkDrivePath = "\\\\VE-ADSERVER01\\ve_net_t630\\";
        public static string AppUpdateBasePath = "N:\\VE\\Miscell Programs and components\\VE JobTracker";
        public static string AppUpdateDirectory = Path.Combine(AppUpdateBasePath, "JT Updates");
        public static string QuickBookFileDirectory = "N:\\VE\\QuickBooks\\Invoice transfer folder";
        public static string AppProcessName = "JobTracker";
        public static string AppExeName = "JobTracker.exe";
        public static string JobDiretory = "N:\\VE\\Job2011";
    }
}
