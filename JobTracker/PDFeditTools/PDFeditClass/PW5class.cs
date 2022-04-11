using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JobTracker.PDFeditTools.PDFeditClass
{
    class PW5class
    {
        #region PW5 pdf Constant Variable
        private const string WorkPermitNo = "topmostSubform[0].Page1[0].Work_Permit_No[0]";
        private const string LI_HouseNo = "topmostSubform[0].Page1[0].TextField1[0]";
        private const string LI_StreetName = "topmostSubform[0].Page1[0].TextField1[1]";
        private const string LI_Borough = "topmostSubform[0].Page1[0].TextField1[2]";
        private const string LI_Block = "topmostSubform[0].Page1[0].TextField1[3]";
        private const string LI_Lot = "topmostSubform[0].Page1[0].TextField1[4]";
        private const string LI_Bin = "topmostSubform[0].Page1[0].TextField1[5]";
        private const string LI_CBNo = "topmostSubform[0].Page1[0].TextField1[6]";
        private const string LI_WorkOnFloor = "topmostSubform[0].Page1[0].TextField1[7]";
        private const string LI_Apt_CondoNo = "topmostSubform[0].Page1[0].TextField1[8]";
        private const string Con_LastName = "topmostSubform[0].Page1[0].TextField1[9]";
        private const string Con_FirstName = "topmostSubform[0].Page1[0].TextField1[10]";
        private const string Con_MiddelName = "topmostSubform[0].Page1[0].TextField1[11]";
        private const string Con_BusinessName = "topmostSubform[0].Page1[0].TextField1[12]";
        private const string Con_BusinessTelephoneNP = "topmostSubform[0].Page1[0].TextField1[13]";
        private const string Con_BusinessAddress = "topmostSubform[0].Page1[0].TextField1[14]";
        private const string Con_BusinessFax = "topmostSubform[0].Page1[0].TextField1[15]";
        private const string Con_City = "topmostSubform[0].Page1[0].TextField1[16]";
        private const string Con_State = "topmostSubform[0].Page1[0].TextField1[17]";
        private const string Con_Zip = "topmostSubform[0].Page1[0].TextField1[18]";
        private const string Con_MoNo = "topmostSubform[0].Page1[0].TextField1[19]";
        private const string Con_LicenseNo = "topmostSubform[0].Page1[0].TextField1[32]";
        private const string SubCon_LastName = "topmostSubform[0].Page1[0].TextField1[20]";
        private const string SubCon_FirstName = "topmostSubform[0].Page1[0].TextField1[21]";
        private const string SubCon_MiddelName = "topmostSubform[0].Page1[0].TextField1[22]";
        private const string SubCon_BusinessName = "topmostSubform[0].Page1[0].TextField1[23]";
        private const string SubCon_BusinessTelephoneNP = "topmostSubform[0].Page1[0].TextField1[24]";
        private const string SubCon_BusinessAddress = "topmostSubform[0].Page1[0].TextField1[25]";
        private const string SubCon_BusinessFax = "topmostSubform[0].Page1[0].TextField1[26]";
        private const string SubCon_City = "topmostSubform[0].Page1[0].TextField1[27]";
        private const string SubCon_State = "topmostSubform[0].Page1[0].TextField1[28]";
        private const string SubCon_Zip = "topmostSubform[0].Page1[0].TextField1[29]";
        private const string SubCon_MoNo = "topmostSubform[0].Page1[0].TextField1[30]";
        private const string Variane_Info_Description = "topmostSubform[0].Page1[0].TextField1[49]";
        private const string ReasonForVariance = "topmostSubform[0].Page1[0].Explanation[0]";
        #endregion
        #region Global Variable
        private static string GV_LI_HouseNo;
        private static string GV_LI_StreetName;
        private static string GV_LI_Borough;
        private static string GV_LI_Block;
        private static string GV_LI_Lot;
        private static string GV_LI_Bin;
        private static string GV_LI_CBNo;
        private static string GV_LI_WorkOnFloor;
        private static string GV_LI_Apt_CondoNo;
        private static string GV_Con_LastName;
        private static string GV_Con_FirstName;
        private static string GV_Con_MiddelName;
        private static string GV_Con_BusinessName;
        private static string GV_Con_BusinessTelephoneNP;
        private static string GV_Con_BusinessAddress;
        private static string GV_Con_BusinessFax;
        private static string GV_Con_City;
        private static string GV_Con_State;
        private static string GV_Con_Zip;
        private static string GV_Con_MoNo;
        private static string GV_Con_LIcenseNo;
        private static string Sub_Con_LastName;
        private static string Sub_Con_MiddleName;
        private static string Sub_Con_FirstName;
        private static string Sub_Con_BusinessName;
        private static string Sub_Con_BusinessTelephone;
        private static string Sub_Con_BusinessAddress;
        private static string Sub_Con_BusinessFax;
        private static string Sub_Con_City;
        private static string Sub_Con__state;
        private static string Sub_Con_Zip;
        private static string Sub_Con_MobileNo;
        private static string FSI_WorkPermitNo;
        private static string VI_Reasonofvariance;
        private static string VI_Description;
        #endregion
        #region Properties
        public static string LocationInfo_HouseNo
        {
            get
            {
                return GV_LI_HouseNo;
            }
            set
            {
                GV_LI_HouseNo = value;
            }
        }
        public static string LocationInfo_StreetName
        {
            get
            {
                return GV_LI_StreetName;
            }
            set
            {
                GV_LI_StreetName = value;
            }
        }
        public static string LocationInfo_Borough
        {
            get
            {
                return GV_LI_Borough;
            }
            set
            {
                GV_LI_Borough = value;
            }
        }
        public static string LocationInfo_Block
        {
            get
            {
                return GV_LI_Block;
            }
            set
            {
                GV_LI_Block = value;
            }
        }
        public static string LocationInfo_Lot
        {
            get
            {
                return GV_LI_Lot;
            }
            set
            {
                GV_LI_Lot = value;
            }
        }
        public static string LocationInfo_Bin
        {
            get
            {
                return GV_LI_Bin;
            }
            set
            {
                GV_LI_Bin = value;
            }
        }
        public static string LocationInfo_CBNO
        {
            get
            {
                return GV_LI_CBNo;
            }
            set
            {
                GV_LI_CBNo = value;
            }
        }
        public static string LocationInfo_WorkOnFloor
        {
            get
            {
                return GV_LI_WorkOnFloor;
            }
            set
            {
                GV_LI_WorkOnFloor = value;
            }
        }
        public static string LocationInfo_Apt_Condono
        {
            get
            {
                return GV_LI_Apt_CondoNo;
            }
            set
            {
                GV_LI_Apt_CondoNo = value;
            }
        }
        public static string Contractor_LastName
        {
            get
            {
                return GV_Con_LastName;
            }
            set
            {
                GV_Con_LastName = value;
            }
        }
        public static string Contractor_FirstName
        {
            get
            {
                return GV_Con_FirstName;
            }
            set
            {
                GV_Con_FirstName = value;
            }
        }
        public static string Contractor_MiddelName
        {
            get
            {
                return GV_Con_MiddelName;
            }
            set
            {
                GV_Con_MiddelName = value;
            }
        }
        public static string Contractor_BusinessName
        {
            get
            {
                return GV_Con_BusinessName;
            }
            set
            {
                GV_Con_BusinessName = value;
            }
        }
        public static string Contractor_BusinessTelephone
        {
            get
            {
                return GV_Con_BusinessTelephoneNP;
            }
            set
            {
                GV_Con_BusinessTelephoneNP = value;
            }
        }
        public static string Contractor_BusinessAddress
        {
            get
            {
                return GV_Con_BusinessAddress;
            }
            set
            {
                GV_Con_BusinessAddress = value;
            }
        }
        public static string Contractor_BusinessFax
        {
            get
            {
                return GV_Con_BusinessFax;
            }
            set
            {
                GV_Con_BusinessFax = value;
            }
        }
        public static string Contractor_City
        {
            get
            {

                return null;
            }
            set
            {

            }
        }
        public static string Contractor_State
        {
            get
            {
                return GV_Con_City;
            }
            set
            {
                GV_Con_City = value;
            }
        }
        public string Contractor_Zip
        {
            get
            {
                return GV_Con_Zip;
            }
            set
            {
                GV_Con_Zip = value;
            }
        }
        public static string Contractor_MobileNo
        {
            get
            {
                return GV_Con_MoNo;
            }
            set
            {
                GV_Con_MoNo = value;
            }
        }
        public static string Contractor_LicenseNo
        {
            get
            {
                return GV_Con_LIcenseNo;
            }
            set
            {
                GV_Con_LIcenseNo = value;
            }
        }
        public static string SubContrator_LastName
        {
            get
            {
                return Sub_Con_LastName;
            }
            set
            {
                Sub_Con_LastName = value;
            }
        }
        public static string SubContrator_MiddleName
        {
            get
            {
                return Sub_Con_MiddleName;
            }
            set
            {
                Sub_Con_MiddleName = value;
            }
        }
        public static string SubContrator_FirstName
        {
            get
            {
                return Sub_Con_FirstName;
            }
            set
            {
                Sub_Con_FirstName = value;
            }
        }
        public static string SubContrator_BusinessName
        {
            get
            {
                return Sub_Con_BusinessName;
            }
            set
            {
                Sub_Con_BusinessName = value;
            }
        }
        public static string SubContrator_BusinessTelePhone
        {
            get
            {
                return Sub_Con_BusinessTelephone;
            }
            set
            {
                Sub_Con_BusinessTelephone = value;
            }
        }
        public static string SubContrator_BusinessAddress
        {
            get
            {
                return Sub_Con_BusinessAddress;
            }
            set
            {
                Sub_Con_BusinessAddress = value;
            }
        }
        public static string SubContrator_BusinessFAx_Email
        {
            get
            {
                return Sub_Con_BusinessFax;
            }
            set
            {
                Sub_Con_BusinessFax = value;
            }
        }
        public static string SubContrator_BusinessCity
        {
            get
            {
                return Sub_Con_City;
            }
            set
            {
                Sub_Con_City = value;
            }
        }
        public static string SubContrator_State
        {
            get
            {
                return Sub_Con__state;
            }
            set
            {
                Sub_Con__state = value;
            }
        }
        public static string SubContrator_Zip
        {
            get
            {
                return Sub_Con_Zip;
            }
            set
            {
                Sub_Con_Zip = value;
            }
        }
        public static string SubContrator_MobileNo
        {
            get
            {
                return Sub_Con_MobileNo;
            }
            set
            {
                Sub_Con_MobileNo = value;
            }
        }
        public static string Filling_Status_Info_WorkPermitNumber
        {
            get
            {
                return FSI_WorkPermitNo;
            }
            set
            {
                FSI_WorkPermitNo = value;
            }
        }
        public static string VarianceInformaton_Reason
        {
            get
            {
                return VI_Reasonofvariance;
            }
            set
            {
                VI_Reasonofvariance = value;
            }
        }
        public static string VarianceInformaton_Description
        {
            get
            {
                return VI_Description;
            }
            set
            {
                VI_Description = value;
            }
        }
        #endregion
        public static void FillPWD5pdfForm(string Path)
        {
            try
            {
                //Source File stream declare here where the pickup the source file to read
                //Application.StartupPath & "\PdfFile\PW5.pdf"
                PdfReader pdfRDR = new PdfReader(Path);
                //Save open file dialouge declare here to save generated pdf to destination derive
                SaveFileDialog pdfSave = new SaveFileDialog();
                pdfSave.Filter = "PDF file|*.pdf";

                if (Directory.Exists("N:"))
                {
                    pdfSave.InitialDirectory = "N:";
                }
                else
                {
                    pdfSave.InitialDirectory = "C:";
                }



                //Data Access class object
                if (pdfSave.ShowDialog() == DialogResult.OK)
                {
                    PdfStamper pdfStm = new PdfStamper(pdfRDR, new FileStream(pdfSave.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite), '\0', true);
                    //Declare form field nmae colletion from pdf file
                    AcroFields AF = pdfStm.AcroFields;
                    //Location information
                    AF.SetField(LI_StreetName, LocationInfo_StreetName);
                    AF.SetField(LI_Block, LocationInfo_Block);
                    AF.SetField(LI_Borough, LocationInfo_Borough);
                    AF.SetField(LI_Lot, LocationInfo_Lot);
                    AF.SetField(LI_HouseNo, LocationInfo_HouseNo);

                    //Contrector Information
                    AF.SetField(Con_LastName, Contractor_LastName);
                    AF.SetField(Con_MiddelName, Contractor_MiddelName);
                    AF.SetField(Con_FirstName, Contractor_FirstName);
                    AF.SetField(Con_BusinessName, Contractor_BusinessName);
                    AF.SetField(Con_BusinessAddress, Contractor_BusinessAddress);
                    AF.SetField(Con_BusinessFax, Contractor_BusinessFax);
                    AF.SetField(Con_City, Contractor_City);
                    AF.SetField(Con_State, Contractor_State);
                    AF.SetField(Con_BusinessTelephoneNP, Contractor_BusinessTelephone);
                    AF.SetField(Con_LicenseNo, Contractor_LicenseNo);

                    //Subcontrector Information
                    AF.SetField(SubCon_LastName, SubContrator_LastName);
                    AF.SetField(SubCon_MiddelName, SubContrator_MiddleName);
                    AF.SetField(SubCon_FirstName, SubContrator_FirstName);
                    AF.SetField(SubCon_BusinessName, SubContrator_BusinessName);
                    AF.SetField(SubCon_BusinessTelephoneNP, SubContrator_BusinessTelePhone);
                    AF.SetField(SubCon_BusinessAddress, SubContrator_BusinessAddress);
                    AF.SetField(SubCon_BusinessFax, SubContrator_BusinessFAx_Email);
                    AF.SetField(SubCon_City, SubContrator_BusinessCity);
                    AF.SetField(SubCon_State, SubContrator_State);
                    AF.SetField(SubCon_Zip, SubContrator_Zip);
                    AF.SetField(SubCon_MoNo, SubContrator_MobileNo);
                    AF.SetField(WorkPermitNo, Filling_Status_Info_WorkPermitNumber);
                    AF.SetField(Variane_Info_Description, VarianceInformaton_Description);
                    AF.SetField(ReasonForVariance, VarianceInformaton_Reason);

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