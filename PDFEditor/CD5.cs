using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class CD5
    {
        #region Global Variable
        private Hashtable CD5_ht = new Hashtable();
        #endregion
        #region Constant Variable
        private const string File_Representative_LastName = "Text1";
        private const string LJ_Borough = "Text2";
        private const string LJ_Block = "Text3";
        private const string LJ_Lot = "Text4";
        private const string LJ_HouseNo = "Text5";
        private const string LJ_StreetName = "Text6";
        private const string LJ_Cross_Street = "Text7";
        private const string LJ_No_Of_Stories = "Text8";
        private const string FRI_Last_Name = "Text9";
        private const string FRI_First_Name = "Text10";
        private const string FRI_M_I = "Text11";
        private const string FRI_Registration_No = "Text12";
        private const string FRI_Email_Address = "Text13";
        private const string FRI_Business_Name = "Text14";
        private const string FRI_Business_Telephone = "Text15";
        private const string FRI_Fax = "Text16";
        private const string FRI_Address = "Text17";
        private const string FRI_City = "Text18";
        private const string FRI_State = "Text19";
        private const string FRI_Zip = "Text20";
        private const string SRI_LastName = "Text21";
        private const string SRI_FirstName = "Text22";
        private const string SRI_M_I = "Text23";
        private const string SRI_LicenseNo = "Text24";
        private const string SRI_Email = "Text25";
        private const string SRI_BusinessName = "Text26";
        private const string SRI_BusinessPhone = "Text27";
        private const string SRI_Fax = "Text28";
        private const string SRI_Address = "Text29";
        private const string SRI_City = "Text30";
        private const string SRI_State = "Text31";
        private const string SRI_Zip = "Text32";
        private const string OMAI_LastName = "Text33";
        private const string OMAI_FirstName = "Text34";
        private const string OMAI_M_I = "Text35";
        private const string OMAI_LicenseNo = "Text36";
        private const string OMAI_Email = "Text37";
        private const string OMAI_BusinessName = "Text38";
        private const string OMAI_BusinessPhone = "Text39";
        private const string OMAI_Fax = "Text40";
        private const string OMAI_Address = "Text41";
        private const string OMAI_City = "Text42";
        private const string OMAI_State = "Text43";
        private const string OMAI_Zip = "Text44";
        private const string JI_Description1 = "Text45";
        private const string JI_Description2 = "Text46";
        private const string JI_Description3 = "Text47";
        private const string JI_Description4 = "Text48";
        private const string JI_Description5 = "Text49";
        private const string JI_Description6 = "Text50";
        private const string JI_Description7 = "Text51";
        private const string JI_Expected_Start_Date = "Text52";
        private const string JI_Approximate_Duration_Job = "Text53";
        private const string SS_I_Certify = "Text54";
        private const string SS_Name_Licensed_Regger = "Text55";
        private const string SS_Date = "Text56";

        #endregion
        #region Properties
        public string File_Representative_LastName_Pro
        {
            get
            {
                return CD5_ht[File_Representative_LastName].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(File_Representative_LastName))
                {
                    CD5_ht[File_Representative_LastName] = value;
                }
                else
                {
                    CD5_ht.Add(File_Representative_LastName, value);
                }
            }
        }
        public string LJ_Borough_Pro
        {
            get
            {
                return CD5_ht[LJ_Borough].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(LJ_Borough))
                {
                    CD5_ht[LJ_Borough] = value;
                }
                else
                {
                    CD5_ht.Add(LJ_Borough, value);
                }
            }
        }
        public string LJ_Block_Pro
        {
            get
            {
                return CD5_ht[LJ_Block].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(LJ_Block))
                {
                    CD5_ht[LJ_Block] = value;
                }
                else
                {
                    CD5_ht.Add(LJ_Block, value);
                }
            }
        }
        public string LJ_Lot_Pro
        {
            get
            {
                return CD5_ht[LJ_Lot].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(LJ_Lot))
                {
                    CD5_ht[LJ_Lot] = value;
                }
                else
                {
                    CD5_ht.Add(LJ_Lot, value);
                }
            }
        }
        public string LJ_HouseNo_Pro
        {
            get
            {
                return CD5_ht[LJ_HouseNo].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(LJ_HouseNo))
                {
                    CD5_ht[LJ_HouseNo] = value;
                }
                else
                {
                    CD5_ht.Add(LJ_HouseNo, value);
                }
            }
        }
        public string LJ_StreetName_Pro
        {
            get
            {
                return CD5_ht[LJ_StreetName].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(LJ_StreetName))
                {
                    CD5_ht[LJ_StreetName] = value;
                }
                else
                {
                    CD5_ht.Add(LJ_StreetName, value);
                }
            }
        }
        public string LJ_Cross_Street_Pro
        {
            get
            {
                return CD5_ht[LJ_Cross_Street].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(LJ_Cross_Street))
                {
                    CD5_ht[LJ_Cross_Street] = value;
                }
                else
                {
                    CD5_ht.Add(LJ_Cross_Street, value);
                }
            }
        }
        public string LJ_No_Of_Stories_Pro
        {
            get
            {
                return CD5_ht[LJ_No_Of_Stories].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(LJ_No_Of_Stories))
                {
                    CD5_ht[LJ_No_Of_Stories] = value;
                }
                else
                {
                    CD5_ht.Add(LJ_No_Of_Stories, value);
                }
            }
        }
        public string FRI_Last_Name_Pro
        {
            get
            {
                return CD5_ht[FRI_Last_Name].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_Last_Name))
                {
                    CD5_ht[FRI_Last_Name] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_Last_Name, value);
                }
            }
        }
        public string FRI_First_Name_Pro
        {
            get
            {
                return CD5_ht[FRI_First_Name].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_First_Name))
                {
                    CD5_ht[FRI_First_Name] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_First_Name, value);
                }
            }
        }
        public string FRI_M_I_Pro
        {
            get
            {
                return CD5_ht[FRI_M_I].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_M_I))
                {
                    CD5_ht[FRI_M_I] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_M_I, value);
                }
            }
        }
        public string FRI_Registration_No_Pro
        {
            get
            {
                return CD5_ht[FRI_Registration_No].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_Registration_No))
                {
                    CD5_ht[FRI_Registration_No] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_Registration_No, value);
                }
            }
        }
        public string FRI_Email_Address_Pro
        {
            get
            {
                return CD5_ht[FRI_Email_Address].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_Email_Address))
                {
                    CD5_ht[FRI_Email_Address] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_Email_Address, value);
                }
            }
        }
        public string FRI_Business_Name_Pro
        {
            get
            {
                return CD5_ht[FRI_Business_Name].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_Business_Name))
                {
                    CD5_ht[FRI_Business_Name] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_Business_Name, value);
                }
            }
        }
        public string FRI_Business_Telephone_Pro
        {
            get
            {
                return CD5_ht[FRI_Business_Telephone].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_Business_Telephone))
                {
                    CD5_ht[FRI_Business_Telephone] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_Business_Telephone, value);
                }
            }
        }
        public string FRI_Fax_Pro
        {
            get
            {
                return CD5_ht[FRI_Fax].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_Fax))
                {
                    CD5_ht[FRI_Fax] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_Fax, value);
                }
            }
        }
        public string FRI_Address_Pro
        {
            get
            {
                return CD5_ht[FRI_Address].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_Address))
                {
                    CD5_ht[FRI_Address] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_Address, value);
                }
            }
        }
        public string FRI_City_Pro
        {
            get
            {
                return CD5_ht[FRI_City].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_City))
                {
                    CD5_ht[FRI_City] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_City, value);
                }
            }
        }
        public string FRI_State_Pro
        {
            get
            {
                return CD5_ht[FRI_State].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_State))
                {
                    CD5_ht[FRI_State] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_State, value);
                }
            }
        }
        public string FRI_Zip_Pro
        {
            get
            {
                return CD5_ht[FRI_Zip].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(FRI_Zip))
                {
                    CD5_ht[FRI_Zip] = value;
                }
                else
                {
                    CD5_ht.Add(FRI_Zip, value);
                }
            }
        }
        public string SRI_LastName_Pro
        {
            get
            {
                return CD5_ht[SRI_LastName].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_LastName))
                {
                    CD5_ht[SRI_LastName] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_LastName, value);
                }
            }
        }
        public string SRI_FirstName_Pro
        {
            get
            {
                return CD5_ht[SRI_FirstName].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_FirstName))
                {
                    CD5_ht[SRI_FirstName] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_FirstName, value);
                }
            }
        }
        public string SRI_M_I_Pro
        {
            get
            {
                return CD5_ht[SRI_M_I].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_M_I))
                {
                    CD5_ht[SRI_M_I] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_M_I, value);
                }
            }
        }
        public string SRI_LicenseNo_Pro
        {
            get
            {
                return CD5_ht[SRI_LicenseNo].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_LicenseNo))
                {
                    CD5_ht[SRI_LicenseNo] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_LicenseNo, value);
                }
            }
        }
        public string SRI_Email_Pro
        {
            get
            {
                return CD5_ht[SRI_Email].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_Email))
                {
                    CD5_ht[SRI_Email] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_Email, value);
                }
            }
        }
        public string SRI_BusinessName_Pro
        {
            get
            {
                return CD5_ht[SRI_BusinessName].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_BusinessName))
                {
                    CD5_ht[SRI_BusinessName] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_BusinessName, value);
                }
            }
        }
        public string SRI_BusinessPhone_Pro
        {
            get
            {
                return CD5_ht[SRI_BusinessPhone].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_BusinessPhone))
                {
                    CD5_ht[SRI_BusinessPhone] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_BusinessPhone, value);
                }
            }
        }
        public string SRI_Fax_Pro
        {
            get
            {
                return CD5_ht[SRI_Fax].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_Fax))
                {
                    CD5_ht[SRI_Fax] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_Fax, value);
                }
            }
        }
        public string SRI_Address_Pro
        {
            get
            {
                return CD5_ht[SRI_Address].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_Address))
                {
                    CD5_ht[SRI_Address] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_Address, value);
                }
            }
        }
        public string SRI_City_Pro
        {
            get
            {
                return CD5_ht[SRI_City].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_City))
                {
                    CD5_ht[SRI_City] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_City, value);
                }
            }
        }
        public string SRI_State_Pro
        {
            get
            {
                return CD5_ht[SRI_State].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_State))
                {
                    CD5_ht[SRI_State] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_State, value);
                }
            }
        }
        public string SRI_Zip_Pro
        {
            get
            {
                return CD5_ht[SRI_Zip].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SRI_Zip))
                {
                    CD5_ht[SRI_Zip] = value;
                }
                else
                {
                    CD5_ht.Add(SRI_Zip, value);
                }
            }
        }
        public string OMAI_LastName_Pro
        {
            get
            {
                return CD5_ht[OMAI_LastName].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_LastName))
                {
                    CD5_ht[OMAI_LastName] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_LastName, value);
                }
            }
        }
        public string OMAI_FirstName_Pro
        {
            get
            {
                return CD5_ht[OMAI_FirstName].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_FirstName))
                {
                    CD5_ht[OMAI_FirstName] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_FirstName, value);
                }
            }
        }
        public string OMAI_M_I_Pro
        {
            get
            {
                return CD5_ht[OMAI_M_I].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_M_I))
                {
                    CD5_ht[OMAI_M_I] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_M_I, value);
                }
            }
        }
        public string OMAI_LicenseNo_Pro
        {
            get
            {
                return CD5_ht[OMAI_LicenseNo].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_LicenseNo))
                {
                    CD5_ht[OMAI_LicenseNo] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_LicenseNo, value);
                }
            }
        }
        public string OMAI_Email_Pro
        {
            get
            {
                return CD5_ht[OMAI_Email].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_Email))
                {
                    CD5_ht[OMAI_Email] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_Email, value);
                }
            }
        }
        public string OMAI_BusinessName_Pro
        {
            get
            {
                return CD5_ht[OMAI_BusinessName].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_BusinessName))
                {
                    CD5_ht[OMAI_BusinessName] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_BusinessName, value);
                }
            }
        }
        public string OMAI_BusinessPhone_Pro
        {
            get
            {
                return CD5_ht[OMAI_BusinessPhone].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_BusinessPhone))
                {
                    CD5_ht[OMAI_BusinessPhone] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_BusinessPhone, value);
                }
            }
        }
        public string OMAI_Fax_Pro
        {
            get
            {
                return CD5_ht[OMAI_Fax].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_Fax))
                {
                    CD5_ht[OMAI_Fax] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_Fax, value);
                }
            }
        }
        public string OMAI_Address_Pro
        {
            get
            {
                return CD5_ht[OMAI_Address].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_Address))
                {
                    CD5_ht[OMAI_Address] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_Address, value);
                }
            }
        }
        public string OMAI_City_Pro
        {
            get
            {
                return CD5_ht[OMAI_City].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_City))
                {
                    CD5_ht[OMAI_City] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_City, value);
                }
            }
        }
        public string OMAI_State_Pro
        {
            get
            {
                return CD5_ht[OMAI_State].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_State))
                {
                    CD5_ht[OMAI_State] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_State, value);
                }
            }
        }
        public string OMAI_Zip_Pro
        {
            get
            {
                return CD5_ht[OMAI_Zip].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(OMAI_Zip))
                {
                    CD5_ht[OMAI_Zip] = value;
                }
                else
                {
                    CD5_ht.Add(OMAI_Zip, value);
                }
            }
        }
        public string JI_Description1_Pro
        {
            get
            {
                return CD5_ht[JI_Description1].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Description1))
                {
                    CD5_ht[JI_Description1] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Description1, value);
                }
            }
        }
        public string JI_Description2_Pro
        {
            get
            {
                return CD5_ht[JI_Description2].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Description2))
                {
                    CD5_ht[JI_Description2] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Description2, value);
                }
            }
        }
        public string JI_Description3_Pro
        {
            get
            {
                return CD5_ht[JI_Description3].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Description3))
                {
                    CD5_ht[JI_Description3] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Description3, value);
                }
            }
        }
        public string JI_Description4_Pro
        {
            get
            {
                return CD5_ht[JI_Description4].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Description4))
                {
                    CD5_ht[JI_Description4] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Description4, value);
                }
            }
        }
        public string JI_Description5_Pro
        {
            get
            {
                return CD5_ht[JI_Description5].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Description5))
                {
                    CD5_ht[JI_Description5] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Description5, value);
                }
            }
        }
        public string JI_Description6_Pro
        {
            get
            {
                return CD5_ht[JI_Description6].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Description6))
                {
                    CD5_ht[JI_Description6] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Description6, value);
                }
            }
        }
        public string JI_Description7_Pro
        {
            get
            {
                return CD5_ht[JI_Description7].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Description7))
                {
                    CD5_ht[JI_Description7] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Description7, value);
                }
            }
        }
        public string JI_Expected_Start_Date_Pro
        {
            get
            {
                return CD5_ht[JI_Expected_Start_Date].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Expected_Start_Date))
                {
                    CD5_ht[JI_Expected_Start_Date] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Expected_Start_Date, value);
                }
            }
        }
        public string JI_Approximate_Duration_Job_Pro
        {
            get
            {
                return CD5_ht[JI_Approximate_Duration_Job].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(JI_Approximate_Duration_Job))
                {
                    CD5_ht[JI_Approximate_Duration_Job] = value;
                }
                else
                {
                    CD5_ht.Add(JI_Approximate_Duration_Job, value);
                }
            }
        }
        public string SS_I_Certify_Pro
        {
            get
            {
                return CD5_ht[SS_I_Certify].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SS_I_Certify))
                {
                    CD5_ht[SS_I_Certify] = value;
                }
                else
                {
                    CD5_ht.Add(SS_I_Certify, value);
                }
            }
        }
        public string SS_Name_Licensed_Regger_Pro
        {
            get
            {
                return CD5_ht[SS_Name_Licensed_Regger].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SS_Name_Licensed_Regger))
                {
                    CD5_ht[SS_Name_Licensed_Regger] = value;
                }
                else
                {
                    CD5_ht.Add(SS_Name_Licensed_Regger, value);
                }
            }
        }
        public string SS_Date_Pro
        {
            get
            {
                return CD5_ht[SS_Date].ToString();
            }
            set
            {
                if (CD5_ht.ContainsKey(SS_Date))
                {
                    CD5_ht[SS_Date] = value;
                }
                else
                {
                    CD5_ht.Add(SS_Date, value);
                }
            }
        }

        #endregion
        public void FillAEU2pdfForm(string Path)
        {
            try
            {
                //Source File stream declare here where the pickup the source file to read
                //Application.StartupPath & "\PdfFile\PW5.pdf"
                PdfReader pdfRDR = new PdfReader(Path);
                //Save open file dialouge declare here to save generated pdf to destination derive
                SaveFileDialog pdfSave = new SaveFileDialog();
                pdfSave.Filter = "PDF file|*.pdf";
                //Data Access class object
                if (pdfSave.ShowDialog() == DialogResult.OK)
                {
                    PdfStamper pdfStm = new PdfStamper(pdfRDR, new FileStream(pdfSave.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite), '\0', true);
                    //Declare form field name  from pdf file
                    AcroFields AF = pdfStm.AcroFields;
                    foreach (DictionaryEntry Element in CD5_ht)
                    {
                        AF.SetField(Element.Key.ToString(), Element.Value.ToString());
                    }

                    pdfStm.FormFlattening = false;
                    pdfRDR.Close();

                    pdfStm.Close();

                    Process.Start(pdfSave.FileName);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }
    }
}
