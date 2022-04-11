using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class dot_govt_work_permit_renew_app
    {
        #region Global Variable
        private Hashtable dot_govt_work_permit_renew_app_ht = new Hashtable();
        #endregion
        #region Constant Variable
        private const string Permit_ID = "Permittee ID";
        private const string Permit_Name = "Permittee Name";
        private const string Address = "Address";
        private const string Area_Code = "Area Code";
        private const string Tel2 = "Tel 2";
        private const string Tel3 = "Tel 3";
        private const string Email = "Email";
        private const string MN = "MN";
        private const string BK = "BK";
        private const string QN = "QN";
        private const string BX = "BX";
        private const string SI = "SI";
        private const string Engineering_Control = "Engineering Control";
        private const string Digit_Year = "2 Digit Year";
        private const string File_No = "File Number";
        private const string Contract_No = "Contract Number";
        private const string DOB = "DOB#";
        private const string DEP = "DEP";
        private const string DDC = "DDC";
        private const string DOT = "DOT";
        private const string DPR = "DPR";
        private const string EDC = "EDC";
        private const string MTA = "MTA";
        private const string PANY_NJ = "PANY/NJ";
        private const string SCA = "SCA";
        private const string Other = "Other";
        private const string Other_Agency = "Other Agency";
        private const string Proj_Er_Name = "Project Engineer Name";
        private const string Area_Code2 = "Area Code 2";
        private const string Tel22 = "Tel 22";
        private const string Tel32 = "Tel 32";
        private const string Res_Er_Name = "Resident Engineer Name";
        private const string Area_Code3 = "Area Code 3";
        private const string Tel23 = "Tel 23";
        private const string Tel33 = "Tel 33";
        private const string Proj_Description = "Project Description";
        private const string CSM = "Contract Start Month";
        private const string CSD = "Contract Start Day";
        private const string CSY = "Contract Start Year";
        private const string CEM = "Contract End Month";
        private const string CED = "Contract End Day";
        private const string CEY = "Contact End Year";
        private const string Roadway = "Roadway";
        private const string Sidewalk = "Sidewalk";
        private const string Permit_No1 = "Permit number 1";
        private const string Permit_Type1 = "Permit Type 1";
        private const string NED1 = "New End Date 1";
        private const string Permit_No2 = "Permit number 2";
        private const string Permit_Type2 = "Permit Type 2";
        private const string NED2 = "New End Date 2";
        private const string Permit_No3 = "Permit number 3";
        private const string Permit_Type3 = "Permit Type 3";
        private const string NED3 = "New End Date 3";
        private const string Permit_No4 = "Permit number 4";
        private const string Permit_Type4 = "Permit Type 4";
        private const string NED4 = "New End Date 4";
        private const string Permit_No5 = "Permit number 5";
        private const string Permit_Type5 = "Permit Type 5";
        private const string NED5 = "New End Date 5";
        private const string Permit_No6 = "Permit number 6";
        private const string Permit_Type6 = "Permit Type 6";
        private const string NED6 = "New End Date 6";
        private const string Permit_No7 = "Permit number 7";
        private const string Permit_Type7 = "Permit Type 7";
        private const string NED7 = "New End Date 7";
        private const string Permit_No8 = "Permit number 8";
        private const string Permit_Type8 = "Permit Type 8";
        private const string NED8 = "New End Date 8";
        private const string Permit_No9 = "Permit number 9";
        private const string Permit_Type9 = "Permit Type 9";
        private const string NED9 = "New End Date 9";
        private const string Permit_No10 = "Permit number 10";
        private const string Permit_Type10 = "Permit Type 10";
        private const string NED10 = "New End Date 10";
        private const string Permit_No11 = "Permit number 11";
        private const string Permit_Type11 = "Permit Type 11";
        private const string NED11 = "New End Date 11";
        private const string Permit_No12 = "Permit number 12";
        private const string Permit_Type12 = "Permit Type 12";
        private const string NED12 = "New End Date 12";
        private const string Submitted_by = "Submitted by";
        private const string Are_Code4 = "Area Code 4";
        private const string Tel24 = "Tel 24";
        private const string Tel34 = "Tel 34";
        private const string Month = "Month";
        private const string Day = "Day";
        private const string Year = "Year";
        #endregion
        #region Properties
        public string Permit_ID_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_ID].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_ID))
                    dot_govt_work_permit_renew_app_ht[Permit_ID] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_ID, value);
            }
        }
        public string Permit_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Name))
                    dot_govt_work_permit_renew_app_ht[Permit_Name] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Name, value);
            }
        }
        public string Address_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Address].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Address))
                    dot_govt_work_permit_renew_app_ht[Address] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Address, value);
            }
        }
        public string Area_Code_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Area_Code].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Area_Code))
                    dot_govt_work_permit_renew_app_ht[Area_Code] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Area_Code, value);
            }
        }
        public string Tel2_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Tel2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Tel2))
                    dot_govt_work_permit_renew_app_ht[Tel2] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Tel2, value);
            }
        }
        public string Tel3_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Tel3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Tel3))
                    dot_govt_work_permit_renew_app_ht[Tel3] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Tel3, value);
            }
        }
        public string Email_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Email].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Email))
                    dot_govt_work_permit_renew_app_ht[Email] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Email, value);
            }
        }
        public string MN_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[MN].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(MN))
                    dot_govt_work_permit_renew_app_ht[MN] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(MN, value);
            }
        }
        public string BK_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[BK].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(BK))
                    dot_govt_work_permit_renew_app_ht[BK] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(BK, value);
            }
        }
        public string QN_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[QN].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(QN))
                    dot_govt_work_permit_renew_app_ht[QN] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(QN, value);
            }
        }
        public string BX_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[BX].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(BX))
                    dot_govt_work_permit_renew_app_ht[BX] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(BX, value);
            }
        }
        public string SI_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[SI].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(SI))
                    dot_govt_work_permit_renew_app_ht[SI] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(SI, value);
            }
        }
        public string Engineering_Control_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Engineering_Control].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Engineering_Control))
                    dot_govt_work_permit_renew_app_ht[Engineering_Control] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Engineering_Control, value);
            }
        }
        public string Digit_Year_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Digit_Year].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Digit_Year))
                    dot_govt_work_permit_renew_app_ht[Digit_Year] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Digit_Year, value);
            }
        }
        public string File_No_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[File_No].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(File_No))
                    dot_govt_work_permit_renew_app_ht[File_No] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(File_No, value);
            }
        }
        public string Contract_No_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Contract_No].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Contract_No))
                    dot_govt_work_permit_renew_app_ht[Contract_No] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Contract_No, value);
            }
        }
        public string DOB_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[DOB].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(DOB))
                    dot_govt_work_permit_renew_app_ht[DOB] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(DOB, value);
            }
        }
        public string DEP_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[DEP].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(DEP))
                    dot_govt_work_permit_renew_app_ht[DEP] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(DEP, value);
            }
        }
        public string DDC_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[DDC].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(DDC))
                    dot_govt_work_permit_renew_app_ht[DDC] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(DDC, value);
            }
        }
        public string DOT_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[DOT].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(DOT))
                    dot_govt_work_permit_renew_app_ht[DOT] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(DOT, value);
            }
        }
        public string DPR_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[DPR].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(DPR))
                    dot_govt_work_permit_renew_app_ht[DPR] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(DPR, value);
            }
        }
        public string EDC_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[EDC].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(EDC))
                    dot_govt_work_permit_renew_app_ht[EDC] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(EDC, value);
            }
        }
        public string MTA_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[MTA].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(MTA))
                    dot_govt_work_permit_renew_app_ht[MTA] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(MTA, value);
            }
        }
        public string PANY_NJ_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[PANY_NJ].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(PANY_NJ))
                    dot_govt_work_permit_renew_app_ht[PANY_NJ] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(PANY_NJ, value);
            }
        }
        public string SCA_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[SCA].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(SCA))
                    dot_govt_work_permit_renew_app_ht[SCA] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(SCA, value);
            }
        }
        public string Other_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Other].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Other))
                    dot_govt_work_permit_renew_app_ht[Other] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Other, value);
            }
        }
        public string Other_Agency_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Other_Agency].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Other_Agency))
                    dot_govt_work_permit_renew_app_ht[Other_Agency] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Other_Agency, value);
            }
        }
        public string Proj_Er_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Proj_Er_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Proj_Er_Name))
                    dot_govt_work_permit_renew_app_ht[Proj_Er_Name] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Proj_Er_Name, value);
            }
        }
        public string Area_Code2_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Area_Code2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Area_Code2))
                    dot_govt_work_permit_renew_app_ht[Area_Code2] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Area_Code2, value);
            }
        }
        public string Tel22_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Tel22].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Tel22))
                    dot_govt_work_permit_renew_app_ht[Tel22] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Tel22, value);
            }
        }
        public string Tel32_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Tel32].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Tel32))
                    dot_govt_work_permit_renew_app_ht[Tel32] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Tel32, value);
            }
        }
        public string Res_Er_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Res_Er_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Res_Er_Name))
                    dot_govt_work_permit_renew_app_ht[Res_Er_Name] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Res_Er_Name, value);
            }
        }
        public string Area_Code3_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Area_Code3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Area_Code3))
                    dot_govt_work_permit_renew_app_ht[Area_Code3] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Area_Code3, value);
            }
        }
        public string Tel23_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Tel23].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Tel23))
                    dot_govt_work_permit_renew_app_ht[Tel23] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Tel23, value);
            }
        }
        public string Tel33_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Tel33].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Tel33))
                    dot_govt_work_permit_renew_app_ht[Tel33] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Tel33, value);
            }
        }
        public string Proj_Description_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Proj_Description].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Proj_Description))
                    dot_govt_work_permit_renew_app_ht[Proj_Description] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Proj_Description, value);
            }
        }
        public string CSM_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[CSM].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(CSM))
                    dot_govt_work_permit_renew_app_ht[CSM] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(CSM, value);
            }
        }
        public string CSD_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[CSD].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(CSD))
                    dot_govt_work_permit_renew_app_ht[CSD] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(CSD, value);
            }
        }
        public string CSY_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[CSY].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(CSY))
                    dot_govt_work_permit_renew_app_ht[CSY] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(CSY, value);
            }
        }
        public string CEM_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[CEM].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(CEM))
                    dot_govt_work_permit_renew_app_ht[CEM] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(CEM, value);
            }
        }
        public string CED_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[CED].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(CED))
                    dot_govt_work_permit_renew_app_ht[CED] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(CED, value);
            }
        }
        public string CEY_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[CEY].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(CEY))
                    dot_govt_work_permit_renew_app_ht[CEY] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(CEY, value);
            }
        }
        public string Roadway_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Roadway].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Roadway))
                    dot_govt_work_permit_renew_app_ht[Roadway] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Roadway, value);
            }
        }
        public string Sidewalk_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Sidewalk].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Sidewalk))
                    dot_govt_work_permit_renew_app_ht[Sidewalk] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Sidewalk, value);
            }
        }
        public string Permit_No1_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No1))
                    dot_govt_work_permit_renew_app_ht[Permit_No1] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No1, value);
            }
        }
        public string Permit_Type1_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type1))
                    dot_govt_work_permit_renew_app_ht[Permit_Type1] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type1, value);
            }
        }
        public string NED1_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED1))
                    dot_govt_work_permit_renew_app_ht[NED1] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED1, value);
            }
        }
        public string Permit_No2_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No2))
                    dot_govt_work_permit_renew_app_ht[Permit_No2] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No2, value);
            }
        }
        public string Permit_Type2_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type2))
                    dot_govt_work_permit_renew_app_ht[Permit_Type2] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type2, value);
            }
        }
        public string NED2_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED2))
                    dot_govt_work_permit_renew_app_ht[NED2] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED2, value);
            }
        }
        public string Permit_No3_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No3))
                    dot_govt_work_permit_renew_app_ht[Permit_No3] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No3, value);
            }
        }
        public string Permit_Type3_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type3))
                    dot_govt_work_permit_renew_app_ht[Permit_Type3] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type3, value);
            }
        }
        public string NED3_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED3))
                    dot_govt_work_permit_renew_app_ht[NED3] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED3, value);
            }
        }
        public string Permit_No4_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No4))
                    dot_govt_work_permit_renew_app_ht[Permit_No4] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No4, value);
            }
        }
        public string Permit_Type4_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type4))
                    dot_govt_work_permit_renew_app_ht[Permit_Type4] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type4, value);
            }
        }
        public string NED4_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED4))
                    dot_govt_work_permit_renew_app_ht[NED4] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED4, value);
            }
        }
        public string Permit_No5_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No5))
                    dot_govt_work_permit_renew_app_ht[Permit_No5] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No5, value);
            }
        }
        public string Permit_Type5_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type5))
                    dot_govt_work_permit_renew_app_ht[Permit_Type5] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type5, value);
            }
        }
        public string NED5_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED5))
                    dot_govt_work_permit_renew_app_ht[NED5] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED5, value);
            }
        }
        public string Permit_No6_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No6))
                    dot_govt_work_permit_renew_app_ht[Permit_No6] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No6, value);
            }
        }
        public string Permit_Type6_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type6))
                    dot_govt_work_permit_renew_app_ht[Permit_Type6] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type6, value);
            }
        }
        public string NED6_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED6))
                    dot_govt_work_permit_renew_app_ht[NED6] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED6, value);
            }
        }
        public string Permit_No7_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No7))
                    dot_govt_work_permit_renew_app_ht[Permit_No7] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No7, value);
            }
        }
        public string Permit_Type7_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type7))
                    dot_govt_work_permit_renew_app_ht[Permit_Type7] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type7, value);
            }
        }
        public string NED7_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED7))
                    dot_govt_work_permit_renew_app_ht[NED7] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED7, value);
            }
        }
        public string Permit_No8_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No8))
                    dot_govt_work_permit_renew_app_ht[Permit_No8] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No8, value);
            }
        }
        public string Permit_Type8_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type8))
                    dot_govt_work_permit_renew_app_ht[Permit_Type8] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type8, value);
            }
        }
        public string NED8_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED8))
                    dot_govt_work_permit_renew_app_ht[NED8] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED8, value);
            }
        }
        public string Permit_No9_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No9))
                    dot_govt_work_permit_renew_app_ht[Permit_No9] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No9, value);
            }
        }
        public string Permit_Type9_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type9))
                    dot_govt_work_permit_renew_app_ht[Permit_Type9] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type9, value);
            }
        }
        public string NED9_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED9))
                    dot_govt_work_permit_renew_app_ht[NED9] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED9, value);
            }
        }
        public string Permit_No10_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No10))
                    dot_govt_work_permit_renew_app_ht[Permit_No10] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No10, value);
            }
        }
        public string Permit_Type10_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type10))
                    dot_govt_work_permit_renew_app_ht[Permit_Type10] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type10, value);
            }
        }
        public string NED10_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED10))
                    dot_govt_work_permit_renew_app_ht[NED10] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED10, value);
            }
        }
        public string Permit_No11_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No11].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No11))
                    dot_govt_work_permit_renew_app_ht[Permit_No11] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No11, value);
            }
        }
        public string Permit_Type11_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type11].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type11))
                    dot_govt_work_permit_renew_app_ht[Permit_Type11] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type11, value);
            }
        }
        public string NED11_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED11].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED11))
                    dot_govt_work_permit_renew_app_ht[NED11] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED11, value);
            }
        }
        public string Permit_No12_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_No12].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_No12))
                    dot_govt_work_permit_renew_app_ht[Permit_No12] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_No12, value);
            }
        }
        public string Permit_Type12_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Permit_Type12].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Permit_Type12))
                    dot_govt_work_permit_renew_app_ht[Permit_Type12] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Permit_Type12, value);
            }
        }
        public string NED12_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[NED12].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(NED12))
                    dot_govt_work_permit_renew_app_ht[NED12] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(NED12, value);
            }
        }
        public string Submitted_by_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Submitted_by].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Submitted_by))
                    dot_govt_work_permit_renew_app_ht[Submitted_by] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Submitted_by, value);
            }
        }
        public string Are_Code4_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Are_Code4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Are_Code4))
                    dot_govt_work_permit_renew_app_ht[Are_Code4] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Are_Code4, value);
            }
        }
        public string Tel24_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Tel24].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Tel24))
                    dot_govt_work_permit_renew_app_ht[Tel24] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Tel24, value);
            }
        }
        public string Tel34_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Tel34].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Tel34))
                    dot_govt_work_permit_renew_app_ht[Tel34] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Tel34, value);
            }
        }
        public string Month_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Month].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Month))
                    dot_govt_work_permit_renew_app_ht[Month] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Month, value);
            }
        }
        public string Day_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Day].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Day))
                    dot_govt_work_permit_renew_app_ht[Day] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Day, value);
            }
        }
        public string Year_Pro
        {
            get
            {
                return dot_govt_work_permit_renew_app_ht[Year].ToString();
            }
            set
            {
                if (dot_govt_work_permit_renew_app_ht.ContainsKey(Year))
                    dot_govt_work_permit_renew_app_ht[Year] = value;
                else
                    dot_govt_work_permit_renew_app_ht.Add(Year, value);
            }
        }
        #endregion
        public void FillDGWPRenewApdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_govt_work_permit_renew_app_ht)
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