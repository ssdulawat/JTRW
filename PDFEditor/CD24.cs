using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class CD24
    {
        #region Global Variable
        private Hashtable CD24_ht = new Hashtable();
        #endregion
        #region Constant Variable
        private const string LI_HouseNo = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[0]";
        private const string AI_LastName = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[0]";
        private const string PI_Boom_Phase1 = "topmostSubform[0].Page1[0].Phase_I__Row_1[0]";
        private const string PI_Boom_Phase2 = "topmostSubform[0].Page1[0].Phase_II__Row_1[0]";
        private const string PI_Boom_Phase3 = "topmostSubform[0].Page1[0].Phase_III__Row_1[0]";
        private const string PI_Boom_Phase4 = "topmostSubform[0].Page1[0].Phase_IV__Row_1[0]";
        private const string PI_Jib_Phase1 = "topmostSubform[0].Page1[0].Phase_I__Row_2[0]";
        private const string PI_Jib_Phase2 = "topmostSubform[0].Page1[0].Phase_II__Row_2[0]";
        private const string PI_Jib_Phase3 = "topmostSubform[0].Page1[0].Phase_III__Row_2[0]";
        private const string PI_Jib_Phase4 = "topmostSubform[0].Page1[0].Phase_IV__Row_2[0]";
        private const string PI_Mast_Phase1 = "topmostSubform[0].Page1[0].Phase_I__Row_3[0]";
        private const string PI_Mast_Phase2 = "topmostSubform[0].Page1[0].Phase_II__Row_3[0]";
        private const string PI_Mast_Phase3 = "topmostSubform[0].Page1[0].Phase_III__Row_3[0]";
        private const string PI_Mast_Phase4 = "topmostSubform[0].Page1[0].Phase_IV__Row_3[0]";
        private const string PI_Total_Phase1 = "topmostSubform[0].Page1[0].Phase_I__Row_4[0]";
        private const string PI_Total_Phase2 = "topmostSubform[0].Page1[0].Phase_II__Row_4[0]";
        private const string PI_Total_Phase3 = "topmostSubform[0].Page1[0].Phase_III__Row_4[0]";
        private const string PI_Total_Phase4 = "topmostSubform[0].Page1[0].Phase_IV__Row_4[0]";
        private const string SP_Approval = "topmostSubform[0].Page1[0].is_contingent_upon_its_satisfactorily_passing_an_assembled_inspection__for[0]";
        private const string LI_StreetName = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[1]";
        private const string LI_Date = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[2]";
        private const string LI_Borough = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[3]";
        private const string LI_Block = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[4]";
        private const string LI_Lot = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[5]";
        private const string LI_CN = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[6]";
        private const string LI_DeviceType1 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[7]";
        private const string LI_SerialNo1 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[8]";
        private const string LI_CD1 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[9]";
        private const string LI_DeviceType2 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[10]";
        private const string LI_SerialNo2 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[11]";
        private const string LI_CD2 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[12]";
        private const string LI_CD3 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[13]";
        private const string LI_CD4 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[14]";
        private const string LI_SerialNo3 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[15]";
        private const string LI_SerialNo4 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[16]";
        private const string LI_DeviceType3 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[17]";
        private const string LI_DeviceType4 = "topmostSubform[0].Page1[0].Location_Information_Required_for_all_applications[18]";
        private const string AI_FirstName = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[1]";
        private const string AI_MiddleName = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[2]";
        private const string AI_BusinessName = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[3]";
        private const string AI_BusinessAddress = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[4]";
        private const string AI_Email = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[5]";
        private const string AI_City = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[6]";
        private const string AI_State = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[7]";
        private const string AI_Zip = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[8]";
        private const string AI_BusinessPhone = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[9]";
        private const string AI_BusinessFax = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[10]";
        private const string AI_MobileNo = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[11]";
        private const string AI_LicenseNo = "topmostSubform[0].Page1[0].Applicant_Information__Required_for_all_applications[12]";

        #endregion

        #region Properties
        public string LI_HouseNo_Pro
        {
            get
            {
                return CD24_ht[LI_HouseNo].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_HouseNo))
                {
                    CD24_ht[LI_HouseNo] = value;
                }
                else
                {
                    CD24_ht.Add(LI_HouseNo, value);
                }
            }
        }
        public string AI_LastName_Pro
        {
            get
            {
                return CD24_ht[AI_LastName].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_LastName))
                {
                    CD24_ht[AI_LastName] = value;
                }
                else
                {
                    CD24_ht.Add(AI_LastName, value);
                }
            }
        }
        public string PI_Boom_Phase1_Pro
        {
            get
            {
                return CD24_ht[PI_Boom_Phase1].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Boom_Phase1))
                {
                    CD24_ht[PI_Boom_Phase1] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Boom_Phase1, value);
                }
            }
        }
        public string PI_Boom_Phase2_Pro
        {
            get
            {
                return CD24_ht[PI_Boom_Phase2].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Boom_Phase2))
                {
                    CD24_ht[PI_Boom_Phase2] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Boom_Phase2, value);
                }
            }
        }
        public string PI_Boom_Phase3_Pro
        {
            get
            {
                return CD24_ht[PI_Boom_Phase3].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Boom_Phase3))
                {
                    CD24_ht[PI_Boom_Phase3] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Boom_Phase3, value);
                }
            }
        }
        public string PI_Boom_Phase4_Pro
        {
            get
            {
                return CD24_ht[PI_Boom_Phase4].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Boom_Phase4))
                {
                    CD24_ht[PI_Boom_Phase4] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Boom_Phase4, value);
                }
            }
        }
        public string PI_Jib_Phase1_Pro
        {
            get
            {
                return CD24_ht[PI_Jib_Phase1].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Jib_Phase1))
                {
                    CD24_ht[PI_Jib_Phase1] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Jib_Phase1, value);
                }
            }
        }
        public string PI_Jib_Phase2_Pro
        {
            get
            {
                return CD24_ht[PI_Jib_Phase2].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Jib_Phase2))
                {
                    CD24_ht[PI_Jib_Phase2] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Jib_Phase2, value);
                }
            }
        }
        public string PI_Jib_Phase3_Pro
        {
            get
            {
                return CD24_ht[PI_Jib_Phase3].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Jib_Phase3))
                {
                    CD24_ht[PI_Jib_Phase3] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Jib_Phase3, value);
                }
            }
        }
        public string PI_Jib_Phase4_Pro
        {
            get
            {
                return CD24_ht[PI_Jib_Phase4].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Jib_Phase4))
                {
                    CD24_ht[PI_Jib_Phase4] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Jib_Phase4, value);
                }
            }
        }
        public string PI_Mast_Phase1_Pro
        {
            get
            {
                return CD24_ht[PI_Mast_Phase1].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Mast_Phase1))
                {
                    CD24_ht[PI_Mast_Phase1] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Mast_Phase1, value);
                }
            }
        }
        public string PI_Mast_Phase2_Pro
        {
            get
            {
                return CD24_ht[PI_Mast_Phase2].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Mast_Phase2))
                {
                    CD24_ht[PI_Mast_Phase2] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Mast_Phase2, value);
                }
            }
        }
        public string PI_Mast_Phase3_Pro
        {
            get
            {
                return CD24_ht[PI_Mast_Phase3].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Mast_Phase3))
                {
                    CD24_ht[PI_Mast_Phase3] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Mast_Phase3, value);
                }
            }
        }
        public string PI_Mast_Phase4_Pro
        {
            get
            {
                return CD24_ht[PI_Mast_Phase4].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Mast_Phase4))
                {
                    CD24_ht[PI_Mast_Phase4] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Mast_Phase4, value);
                }
            }
        }
        public string PI_Total_Phase1_Pro
        {
            get
            {
                return CD24_ht[PI_Total_Phase1].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Total_Phase1))
                {
                    CD24_ht[PI_Total_Phase1] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Total_Phase1, value);
                }
            }
        }
        public string PI_Total_Phase2_Pro
        {
            get
            {
                return CD24_ht[PI_Total_Phase2].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Total_Phase2))
                {
                    CD24_ht[PI_Total_Phase2] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Total_Phase2, value);
                }
            }
        }
        public string PI_Total_Phase3_Pro
        {
            get
            {
                return CD24_ht[PI_Total_Phase3].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Total_Phase3))
                {
                    CD24_ht[PI_Total_Phase3] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Total_Phase3, value);
                }
            }
        }
        public string PI_Total_Phase4_Pro
        {
            get
            {
                return CD24_ht[PI_Total_Phase4].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(PI_Total_Phase4))
                {
                    CD24_ht[PI_Total_Phase4] = value;
                }
                else
                {
                    CD24_ht.Add(PI_Total_Phase4, value);
                }
            }
        }
        public string SP_Approval_Pro
        {
            get
            {
                return CD24_ht[SP_Approval].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(SP_Approval))
                {
                    CD24_ht[SP_Approval] = value;
                }
                else
                {
                    CD24_ht.Add(SP_Approval, value);
                }
            }
        }
        public string LI_StreetName_Pro
        {
            get
            {
                return CD24_ht[LI_StreetName].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_StreetName))
                {
                    CD24_ht[LI_StreetName] = value;
                }
                else
                {
                    CD24_ht.Add(LI_StreetName, value);
                }
            }
        }
        public string LI_Date_Pro
        {
            get
            {
                return CD24_ht[LI_Date].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_Date))
                {
                    CD24_ht[LI_Date] = value;
                }
                else
                {
                    CD24_ht.Add(LI_Date, value);
                }
            }
        }
        public string LI_Borough_Pro
        {
            get
            {
                return CD24_ht[LI_Borough].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_Borough))
                {
                    CD24_ht[LI_Borough] = value;
                }
                else
                {
                    CD24_ht.Add(LI_Borough, value);
                }
            }
        }
        public string LI_Block_Pro
        {
            get
            {
                return CD24_ht[LI_Block].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_Block))
                {
                    CD24_ht[LI_Block] = value;
                }
                else
                {
                    CD24_ht.Add(LI_Block, value);
                }
            }
        }
        public string LI_Lot_Pro
        {
            get
            {
                return CD24_ht[LI_Lot].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_Lot))
                {
                    CD24_ht[LI_Lot] = value;
                }
                else
                {
                    CD24_ht.Add(LI_Lot, value);
                }
            }
        }
        public string LI_CN_Pro
        {
            get
            {
                return CD24_ht[LI_CN].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_CN))
                {
                    CD24_ht[LI_CN] = value;
                }
                else
                {
                    CD24_ht.Add(LI_CN, value);
                }
            }
        }
        public string LI_DeviceType1_Pro
        {
            get
            {
                return CD24_ht[LI_DeviceType1].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_DeviceType1))
                {
                    CD24_ht[LI_DeviceType1] = value;
                }
                else
                {
                    CD24_ht.Add(LI_DeviceType1, value);
                }
            }
        }
        public string LI_SerialNo1_Pro
        {
            get
            {
                return CD24_ht[LI_SerialNo1].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_SerialNo1))
                {
                    CD24_ht[LI_SerialNo1] = value;
                }
                else
                {
                    CD24_ht.Add(LI_SerialNo1, value);
                }
            }
        }
        public string LI_CD1_Pro
        {
            get
            {
                return CD24_ht[LI_CD1].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_CD1))
                {
                    CD24_ht[LI_CD1] = value;
                }
                else
                {
                    CD24_ht.Add(LI_CD1, value);
                }
            }
        }
        public string LI_DeviceType2_Pro
        {
            get
            {
                return CD24_ht[LI_DeviceType2].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_DeviceType2))
                {
                    CD24_ht[LI_DeviceType2] = value;
                }
                else
                {
                    CD24_ht.Add(LI_DeviceType2, value);
                }
            }
        }
        public string LI_SerialNo2_Pro
        {
            get
            {
                return CD24_ht[LI_SerialNo2].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_SerialNo2))
                {
                    CD24_ht[LI_SerialNo2] = value;
                }
                else
                {
                    CD24_ht.Add(LI_SerialNo2, value);
                }
            }
        }
        public string LI_CD2_Pro
        {
            get
            {
                return CD24_ht[LI_CD2].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_CD2))
                {
                    CD24_ht[LI_CD2] = value;
                }
                else
                {
                    CD24_ht.Add(LI_CD2, value);
                }
            }
        }
        public string LI_CD3_Pro
        {
            get
            {
                return CD24_ht[LI_CD3].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_CD3))
                {
                    CD24_ht[LI_CD3] = value;
                }
                else
                {
                    CD24_ht.Add(LI_CD3, value);
                }
            }
        }
        public string LI_CD4_Pro
        {
            get
            {
                return CD24_ht[LI_CD4].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_CD4))
                {
                    CD24_ht[LI_CD4] = value;
                }
                else
                {
                    CD24_ht.Add(LI_CD4, value);
                }
            }
        }
        public string LI_SerialNo3_Pro
        {
            get
            {
                return CD24_ht[LI_SerialNo3].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_SerialNo3))
                {
                    CD24_ht[LI_SerialNo3] = value;
                }
                else
                {
                    CD24_ht.Add(LI_SerialNo3, value);
                }
            }
        }
        public string LI_SerialNo4_Pro
        {
            get
            {
                return CD24_ht[LI_SerialNo4].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_SerialNo4))
                {
                    CD24_ht[LI_SerialNo4] = value;
                }
                else
                {
                    CD24_ht.Add(LI_SerialNo4, value);
                }
            }
        }
        public string LI_DeviceType3_Pro
        {
            get
            {
                return CD24_ht[LI_DeviceType3].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_DeviceType3))
                {
                    CD24_ht[LI_DeviceType3] = value;
                }
                else
                {
                    CD24_ht.Add(LI_DeviceType3, value);
                }
            }
        }
        public string LI_DeviceType4_Pro
        {
            get
            {
                return CD24_ht[LI_DeviceType4].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(LI_DeviceType4))
                {
                    CD24_ht[LI_DeviceType4] = value;
                }
                else
                {
                    CD24_ht.Add(LI_DeviceType4, value);
                }
            }
        }
        public string AI_FirstName_Pro
        {
            get
            {
                return CD24_ht[AI_FirstName].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_FirstName))
                {
                    CD24_ht[AI_FirstName] = value;
                }
                else
                {
                    CD24_ht.Add(AI_FirstName, value);
                }
            }
        }
        public string AI_MiddleName_Pro
        {
            get
            {
                return CD24_ht[AI_MiddleName].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_MiddleName))
                {
                    CD24_ht[AI_MiddleName] = value;
                }
                else
                {
                    CD24_ht.Add(AI_MiddleName, value);
                }
            }
        }
        public string AI_BusinessName_Pro
        {
            get
            {
                return CD24_ht[AI_BusinessName].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_BusinessName))
                {
                    CD24_ht[AI_BusinessName] = value;
                }
                else
                {
                    CD24_ht.Add(AI_BusinessName, value);
                }
            }
        }
        public string AI_BusinessAddress_Pro
        {
            get
            {
                return CD24_ht[AI_BusinessAddress].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_BusinessAddress))
                {
                    CD24_ht[AI_BusinessAddress] = value;
                }
                else
                {
                    CD24_ht.Add(AI_BusinessAddress, value);
                }
            }
        }
        public string AI_Email_Pro
        {
            get
            {
                return CD24_ht[AI_Email].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_Email))
                {
                    CD24_ht[AI_Email] = value;
                }
                else
                {
                    CD24_ht.Add(AI_Email, value);
                }
            }
        }
        public string AI_City_Pro
        {
            get
            {
                return CD24_ht[AI_City].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_City))
                {
                    CD24_ht[AI_City] = value;
                }
                else
                {
                    CD24_ht.Add(AI_City, value);
                }
            }
        }
        public string AI_State_Pro
        {
            get
            {
                return CD24_ht[AI_State].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_State))
                {
                    CD24_ht[AI_State] = value;
                }
                else
                {
                    CD24_ht.Add(AI_State, value);
                }
            }
        }
        public string AI_Zip_Pro
        {
            get
            {
                return CD24_ht[AI_Zip].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_Zip))
                {
                    CD24_ht[AI_Zip] = value;
                }
                else
                {
                    CD24_ht.Add(AI_Zip, value);
                }
            }
        }
        public string AI_BusinessPhone_Pro
        {
            get
            {
                return CD24_ht[AI_BusinessPhone].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_BusinessPhone))
                {
                    CD24_ht[AI_BusinessPhone] = value;
                }
                else
                {
                    CD24_ht.Add(AI_BusinessPhone, value);
                }
            }
        }
        public string AI_BusinessFax_Pro
        {
            get
            {
                return CD24_ht[AI_BusinessFax].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_BusinessFax))
                {
                    CD24_ht[AI_BusinessFax] = value;
                }
                else
                {
                    CD24_ht.Add(AI_BusinessFax, value);
                }
            }
        }
        public string AI_MobileNo_Pro
        {
            get
            {
                return CD24_ht[AI_MobileNo].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_MobileNo))
                {
                    CD24_ht[AI_MobileNo] = value;
                }
                else
                {
                    CD24_ht.Add(AI_MobileNo, value);
                }
            }
        }
        public string AI_LicenseNo_Pro
        {
            get
            {
                return CD24_ht[AI_LicenseNo].ToString();
            }
            set
            {
                if (CD24_ht.ContainsKey(AI_LicenseNo))
                {
                    CD24_ht[AI_LicenseNo] = value;
                }
                else
                {
                    CD24_ht.Add(AI_LicenseNo, value);
                }
            }
        }

        #endregion
        public void FillCD24pdfForm(string Path)
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
                    foreach (DictionaryEntry Element in CD24_ht)
                    {
                        AF.SetField(Element.Key.ToString().ToString(), Element.Value.ToString());
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
