using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class dot_govt_work_permit_reissue_app
    {
        #region Global Variable
        private Hashtable dot_govt_work_permit_reissue_app_ht = new Hashtable();
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
        private const string Pany_NJ = "PANY/NJ";
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
        private const string Project_Description = "Project Description";
        private const string Contract_Start_Month = "Contract Start Month";
        private const string Contract_Start_Day = "Contract Start Day";
        private const string Contract_Start_Year = "Contract Start Year";
        private const string Contract_End_Month = "Contract End Month";
        private const string Contract_End_Day = "Contract End Day";
        private const string Contract_End_Year = "Contact End Year";
        private const string Roadway = "Roadway";
        private const string Sidewalk = "Sidewalk";
        private const string Permit1 = "Permit #1";
        private const string PermitType1 = "Permit Type 1";
        private const string New_Start_Date1 = "New Start Date 1";
        private const string New_End_Date1 = "New End Date 1";
        private const string Permit2 = "Permit #2";
        private const string PermitType2 = "Permit Type 2";
        private const string New_Start_Date2 = "New Start Date 2";
        private const string New_End_Date2 = "New End Date 2";
        private const string Permit3 = "Permit #3";
        private const string PermitType3 = "Permit Type 3";
        private const string New_Start_Date3 = "New Start Date 3";
        private const string New_End_Date3 = "New End Date 3";
        private const string Permit4 = "Permit #4";
        private const string PermitType4 = "Permit Type 4";
        private const string New_Start_Date4 = "New Start Date 4";
        private const string New_End_Date4 = "New End Date 4";
        private const string Permit5 = "Permit #5";
        private const string PermitType5 = "Permit Type 5";
        private const string New_Start_date5 = "New Start Date 5";
        private const string New_End_Date5 = "New End Date 5";
        private const string Permit6 = "Permit #6";
        private const string PermitType6 = "Permit Type 6";
        private const string New_Start_Date6 = "New Start Date 6";
        private const string New_End_Date6 = "New End Date 6";
        private const string Permit7 = "Permit #7";
        private const string PermitType7 = "Permit Type 7";
        private const string New_Start_Date7 = "New Start Date 7";
        private const string New_End_Date7 = "New End Date 7";
        private const string Permit8 = "Permit #8";
        private const string PermitType8 = "Permit Type 8";
        private const string New_Start_Date8 = "New Start Date 8";
        private const string New_End_Date8 = "New End Date 8";
        private const string Permit9 = "Permit #9";
        private const string PermitType9 = "Permit Type 9";
        private const string New_Start_Date9 = "New Start Date 9";
        private const string New_End_Date9 = "New End Date 9";
        private const string Permit10 = "Permit #10";
        private const string PermitType10 = "Permit Type 10";
        private const string New_Start_Date10 = "New Start Date 10";
        private const string New_End_Date10 = "New End Date 10";
        private const string Permit11 = "Permit #11";
        private const string PermitType11 = "Permit Type 11";
        private const string New_Start_Date11 = "New Start Date 11";
        private const string New_End_Date11 = "New End Date 11";
        private const string Permit12 = "Permit #12";
        private const string PermitType12 = "Permit Type 12";
        private const string New_Start_Date12 = "New Start Date 12";
        private const string New_End_Date12 = "New End Date 12";
        private const string Submitted_By = "Submitted by";
        private const string Area_Code4 = "Area Code 4";
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
                return dot_govt_work_permit_reissue_app_ht[Permit_ID].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit_ID))
                    dot_govt_work_permit_reissue_app_ht[Permit_ID] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit_ID, value);
            }
        }
        public string Permit_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit_Name))
                    dot_govt_work_permit_reissue_app_ht[Permit_Name] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit_Name, value);
            }
        }
        public string Address_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Address].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Address))
                    dot_govt_work_permit_reissue_app_ht[Address] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Address, value);
            }
        }
        public string Area_Code_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Area_Code].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Area_Code))
                    dot_govt_work_permit_reissue_app_ht[Area_Code] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Area_Code, value);
            }
        }
        public string Tel2_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Tel2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Tel2))
                    dot_govt_work_permit_reissue_app_ht[Tel2] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Tel2, value);
            }
        }
        public string Tel3_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Tel3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Tel3))
                    dot_govt_work_permit_reissue_app_ht[Tel3] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Tel3, value);
            }
        }
        public string Email_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Email].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Email))
                    dot_govt_work_permit_reissue_app_ht[Email] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Email, value);
            }
        }
        public string MN_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[MN].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(MN))
                    dot_govt_work_permit_reissue_app_ht[MN] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(MN, value);
            }
        }
        public string BK_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[BK].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(BK))
                    dot_govt_work_permit_reissue_app_ht[BK] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(BK, value);
            }
        }
        public string QN_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[QN].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(QN))
                    dot_govt_work_permit_reissue_app_ht[QN] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(QN, value);
            }
        }
        public string BX_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[BX].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(BX))
                    dot_govt_work_permit_reissue_app_ht[BX] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(BX, value);
            }
        }
        public string SI_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[SI].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(SI))
                    dot_govt_work_permit_reissue_app_ht[SI] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(SI, value);
            }
        }
        public string Engineering_Control_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Engineering_Control].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Engineering_Control))
                    dot_govt_work_permit_reissue_app_ht[Engineering_Control] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Engineering_Control, value);
            }
        }
        public string Digit_Year_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Digit_Year].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Digit_Year))
                    dot_govt_work_permit_reissue_app_ht[Digit_Year] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Digit_Year, value);
            }
        }
        public string File_No_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[File_No].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(File_No))
                    dot_govt_work_permit_reissue_app_ht[File_No] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(File_No, value);
            }
        }
        public string Contract_No_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Contract_No].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Contract_No))
                    dot_govt_work_permit_reissue_app_ht[Contract_No] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Contract_No, value);
            }
        }
        public string DOB_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[DOB].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(DOB))
                    dot_govt_work_permit_reissue_app_ht[DOB] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(DOB, value);
            }
        }
        public string DEP_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[DEP].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(DEP))
                    dot_govt_work_permit_reissue_app_ht[DEP] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(DEP, value);
            }
        }
        public string DDC_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[DDC].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(DDC))
                    dot_govt_work_permit_reissue_app_ht[DDC] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(DDC, value);
            }
        }
        public string DOT_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[DOT].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(DOT))
                    dot_govt_work_permit_reissue_app_ht[DOT] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(DOT, value);
            }
        }
        public string DPR_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[DPR].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(DPR))
                    dot_govt_work_permit_reissue_app_ht[DPR] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(DPR, value);
            }
        }
        public string EDC_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[EDC].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(EDC))
                    dot_govt_work_permit_reissue_app_ht[EDC] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(EDC, value);
            }
        }
        public string MTA_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[MTA].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(MTA))
                    dot_govt_work_permit_reissue_app_ht[MTA] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(MTA, value);
            }
        }
        public string Pany_NJ_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Pany_NJ].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Pany_NJ))
                    dot_govt_work_permit_reissue_app_ht[Pany_NJ] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Pany_NJ, value);
            }
        }
        public string SCA_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[SCA].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(SCA))
                    dot_govt_work_permit_reissue_app_ht[SCA] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(SCA, value);
            }
        }
        public string Other_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Other].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Other))
                    dot_govt_work_permit_reissue_app_ht[Other] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Other, value);
            }
        }
        public string Other_Agency_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Other_Agency].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Other_Agency))
                    dot_govt_work_permit_reissue_app_ht[Other_Agency] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Other_Agency, value);
            }
        }
        public string Proj_Er_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Proj_Er_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Proj_Er_Name))
                    dot_govt_work_permit_reissue_app_ht[Proj_Er_Name] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Proj_Er_Name, value);
            }
        }
        public string Area_Code2_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Area_Code2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Area_Code2))
                    dot_govt_work_permit_reissue_app_ht[Area_Code2] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Area_Code2, value);
            }
        }
        public string Tel22_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Tel22].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Tel22))
                    dot_govt_work_permit_reissue_app_ht[Tel22] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Tel22, value);
            }
        }
        public string Tel32_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Tel32].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Tel32))
                    dot_govt_work_permit_reissue_app_ht[Tel32] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Tel32, value);
            }
        }
        public string Res_Er_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Res_Er_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Res_Er_Name))
                    dot_govt_work_permit_reissue_app_ht[Res_Er_Name] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Res_Er_Name, value);
            }
        }
        public string Area_Code3_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Area_Code3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Area_Code3))
                    dot_govt_work_permit_reissue_app_ht[Area_Code3] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Area_Code3, value);
            }
        }
        public string Tel23_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Tel23].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Tel23))
                    dot_govt_work_permit_reissue_app_ht[Tel23] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Tel23, value);
            }
        }
        public string Tel33_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Tel33].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Tel33))
                    dot_govt_work_permit_reissue_app_ht[Tel33] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Tel33, value);
            }
        }
        public string Project_Description_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Project_Description].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Project_Description))
                    dot_govt_work_permit_reissue_app_ht[Project_Description] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Project_Description, value);
            }
        }
        public string Contract_Start_Month_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Contract_Start_Month].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Contract_Start_Month))
                    dot_govt_work_permit_reissue_app_ht[Contract_Start_Month] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Contract_Start_Month, value);
            }
        }
        public string Contract_Start_Day_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Contract_Start_Day].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Contract_Start_Day))
                    dot_govt_work_permit_reissue_app_ht[Contract_Start_Day] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Contract_Start_Day, value);
            }
        }
        public string Contract_Start_Year_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Contract_Start_Year].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Contract_Start_Year))
                    dot_govt_work_permit_reissue_app_ht[Contract_Start_Year] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Contract_Start_Year, value);
            }
        }
        public string Contract_End_Month_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Contract_End_Month].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Contract_End_Month))
                    dot_govt_work_permit_reissue_app_ht[Contract_End_Month] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Contract_End_Month, value);
            }
        }
        public string Contract_End_Day_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Contract_End_Day].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Contract_End_Day))
                    dot_govt_work_permit_reissue_app_ht[Contract_End_Day] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Contract_End_Day, value);
            }
        }
        public string Contract_End_Year_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Contract_End_Year].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Contract_End_Year))
                    dot_govt_work_permit_reissue_app_ht[Contract_End_Year] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Contract_End_Year, value);
            }
        }
        public string Roadway_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Roadway].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Roadway))
                    dot_govt_work_permit_reissue_app_ht[Roadway] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Roadway, value);
            }
        }
        public string Sidewalk_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Sidewalk].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Sidewalk))
                    dot_govt_work_permit_reissue_app_ht[Sidewalk] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Sidewalk, value);
            }
        }
        public string Permit1_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit1))
                    dot_govt_work_permit_reissue_app_ht[Permit1] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit1, value);
            }
        }
        public string PermitType1_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType1))
                    dot_govt_work_permit_reissue_app_ht[PermitType1] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType1, value);
            }
        }
        public string New_Start_Date1_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date1))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date1] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date1, value);
            }
        }
        public string New_End_Date1_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date1))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date1] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date1, value);
            }
        }
        public string Permit2_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit2))
                    dot_govt_work_permit_reissue_app_ht[Permit2] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit2, value);
            }
        }
        public string PermitType2_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType2))
                    dot_govt_work_permit_reissue_app_ht[PermitType2] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType2, value);
            }
        }
        public string New_Start_Date2_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date2))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date2] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date2, value);
            }
        }
        public string New_End_Date2_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date2))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date2] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date2, value);
            }
        }
        public string Permit3_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit3))
                    dot_govt_work_permit_reissue_app_ht[Permit3] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit3, value);
            }
        }
        public string PermitType3_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType3))
                    dot_govt_work_permit_reissue_app_ht[PermitType3] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType3, value);
            }
        }
        public string New_Start_Date3_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date3))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date3] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date3, value);
            }
        }
        public string New_End_Date3_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date3))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date3] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date3, value);
            }
        }
        public string Permit4_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit4))
                    dot_govt_work_permit_reissue_app_ht[Permit4] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit4, value);
            }
        }
        public string PermitType4_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType4))
                    dot_govt_work_permit_reissue_app_ht[PermitType4] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType4, value);
            }
        }
        public string New_Start_Date4_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date4))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date4] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date4, value);
            }
        }
        public string New_End_Date4_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date4))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date4] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date4, value);
            }
        }
        public string Permit5_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit5))
                    dot_govt_work_permit_reissue_app_ht[Permit5] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit5, value);
            }
        }
        public string PermitType5_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType5))
                    dot_govt_work_permit_reissue_app_ht[PermitType5] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType5, value);
            }
        }
        public string New_Start_date5_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_date5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_date5))
                    dot_govt_work_permit_reissue_app_ht[New_Start_date5] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_date5, value);
            }
        }
        public string New_End_Date5_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date5))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date5] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date5, value);
            }
        }
        public string Permit6_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit6))
                    dot_govt_work_permit_reissue_app_ht[Permit6] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit6, value);
            }
        }
        public string PermitType6_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType6))
                    dot_govt_work_permit_reissue_app_ht[PermitType6] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType6, value);
            }
        }
        public string New_Start_Date6_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date6))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date6] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date6, value);
            }
        }
        public string New_End_Date6_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date6))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date6] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date6, value);
            }
        }
        public string Permit7_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit7))
                    dot_govt_work_permit_reissue_app_ht[Permit7] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit7, value);
            }
        }
        public string PermitType7_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType7))
                    dot_govt_work_permit_reissue_app_ht[PermitType7] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType7, value);
            }
        }
        public string New_Start_Date7_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date7))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date7] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date7, value);
            }
        }
        public string New_End_Date7_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date7))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date7] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date7, value);
            }
        }
        public string Permit8_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit8))
                    dot_govt_work_permit_reissue_app_ht[Permit8] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit8, value);
            }
        }
        public string PermitType8_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType8))
                    dot_govt_work_permit_reissue_app_ht[PermitType8] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType8, value);
            }
        }
        public string New_Start_Date8_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date8))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date8] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date8, value);
            }
        }
        public string New_End_Date8_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date8))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date8] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date8, value);
            }
        }
        public string Permit9_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit9))
                    dot_govt_work_permit_reissue_app_ht[Permit9] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit9, value);
            }
        }
        public string PermitType9_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType9))
                    dot_govt_work_permit_reissue_app_ht[PermitType9] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType9, value);
            }
        }
        public string New_Start_Date9_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date9))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date9] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date9, value);
            }
        }
        public string New_End_Date9_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date9))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date9] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date9, value);
            }
        }
        public string Permit10_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit10))
                    dot_govt_work_permit_reissue_app_ht[Permit10] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit10, value);
            }
        }
        public string PermitType10_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType10))
                    dot_govt_work_permit_reissue_app_ht[PermitType10] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType10, value);
            }
        }
        public string New_Start_Date10_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date10))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date10] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date10, value);
            }
        }
        public string New_End_Date10_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date10))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date10] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date10, value);
            }
        }
        public string Permit11_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit11].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit11))
                    dot_govt_work_permit_reissue_app_ht[Permit11] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit11, value);
            }
        }
        public string PermitType11_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType11].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType11))
                    dot_govt_work_permit_reissue_app_ht[PermitType11] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType11, value);
            }
        }
        public string New_Start_Date11_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date11].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date11))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date11] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date11, value);
            }
        }
        public string New_End_Date11_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date11].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date11))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date11] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date11, value);
            }
        }
        public string Permit12_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Permit12].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Permit12))
                    dot_govt_work_permit_reissue_app_ht[Permit12] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Permit12, value);
            }
        }
        public string PermitType12_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[PermitType12].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(PermitType12))
                    dot_govt_work_permit_reissue_app_ht[PermitType12] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(PermitType12, value);
            }
        }
        public string New_Start_Date12_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_Start_Date12].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_Start_Date12))
                    dot_govt_work_permit_reissue_app_ht[New_Start_Date12] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_Start_Date12, value);
            }
        }
        public string New_End_Date12_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[New_End_Date12].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(New_End_Date12))
                    dot_govt_work_permit_reissue_app_ht[New_End_Date12] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(New_End_Date12, value);
            }
        }
        public string Submitted_By_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Submitted_By].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Submitted_By))
                    dot_govt_work_permit_reissue_app_ht[Submitted_By] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Submitted_By, value);
            }
        }
        public string Area_Code4_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Area_Code4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Area_Code4))
                    dot_govt_work_permit_reissue_app_ht[Area_Code4] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Area_Code4, value);
            }
        }
        public string Tel24_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Tel24].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Tel24))
                    dot_govt_work_permit_reissue_app_ht[Tel24] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Tel24, value);
            }
        }
        public string Tel34_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Tel34].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Tel34))
                    dot_govt_work_permit_reissue_app_ht[Tel34] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Tel34, value);
            }
        }
        public string Month_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Month].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Month))
                    dot_govt_work_permit_reissue_app_ht[Month] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Month, value);
            }
        }
        public string Day_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Day].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Day))
                    dot_govt_work_permit_reissue_app_ht[Day] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Day, value);
            }
        }
        public string Year_Pro
        {
            get
            {
                return dot_govt_work_permit_reissue_app_ht[Year].ToString();
            }
            set
            {
                if (dot_govt_work_permit_reissue_app_ht.ContainsKey(Year))
                    dot_govt_work_permit_reissue_app_ht[Year] = value;
                else
                    dot_govt_work_permit_reissue_app_ht.Add(Year, value);
            }
        }
        #endregion

        public void FillDGWPRApdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_govt_work_permit_reissue_app_ht)
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