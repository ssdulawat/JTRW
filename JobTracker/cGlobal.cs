using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTracker
{
    public static class cGlobal
    {
        public static string sProgramDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), cProgramInfo.sProductName);
        public static string sLogPath = Path.Combine(sProgramDataPath, "Log");
        public static string sApplicationPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string sSettingFilePath = Path.Combine(sApplicationPath, "ConnectionStringSetting");
        public static bool bIsAdminLoggedIn = false;
        public static string sNetworkDirPath = "N:\\VE\\";
        public static string sNetworkDrivePath = "N:";
        public static string ConnectionStringXml = "ConnectionString.xml";
        public static enmMenu mainmenu;
        public static string AdditionalDB="PCTracker";

        public static string ConnectionStringFilePath
        {
            get { return Path.Combine(sApplicationPath, ConnectionStringXml); }
        }

        public enum enmMenu
        {
            CraneInfo=1, //1
            FormInfo,   //2
            CraneFormFill,  //3
            CraneCDInfo,    //4
            CommunityBoardInfo, //5
            ApplicantInfo,  //6
            AddJobDescription,  //7
            MasterListItem, //8
            PMTMListItem,   //9
            PMInfo, //10
            TypicalTextListItem,    //11
            VETask, //12
            ColorSetting,   //13
            ImportInvoiceData,  //14
            SenddueInvoiceEmail,    //15
            ApplicationSetting, //16
            VerifyWebData,  //17
            Utility,    //18
            SendPMPend, //19
            Task,   //20
            TaskList,   //21
            PageLoadSetting,    //22
            AutoInsertSetting,  //23
            UserDefinedSetting, //24
            EditInvoicveSetting,    //25
            EditAddress,    //26
            InvoicePDFUpload,   //27
            JTInvoiceSearch,    //28
            Aging,  //29
            AgingEmail, //30
            RevenueSearch,  //31
            BillableJobsSearch, //32
            JTQbInvCompareSearch,   //33
            BillableJobsToDisableSearch,    //34
            TextDocumentBuilder,    //35
            ManagerScreen  , //36
            ContactScreen  ,    //37
            Calendar ,   //38
            AddTimeExpanse,   //39
        }

        public static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

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

        public static string SubRemoveEnter(string Str)
        {
            try
            {
                //Dim chr As Char() = New Char() {chr(13)}
                //Dim SpliStr As String()
                //SpliStr = Str.Split(vbCrLf)
                Str = Str.Replace("\r\n", " ");
                //SpliStr = Str.Split(vbCrLf)
                return Str;
            }
            catch (Exception ex)
            {
                return Str;
            }
        }

        public static string Addj(string Str)
        {
            try
            {
                if (Str.Contains("j") == true)
                {
                    if (Str.IndexOf("j") == Str.Length - 1)
                    {
                        return Str;
                    }
                    else
                    {
                        return Str + "j";
                    }

                }
                else
                {
                    return Str + "j";
                }
            }
            catch (Exception ex)
            {
                return Str;
            }
        }

    }
}