using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
    public class dot_govt_work_permit_app
    {
        #region Global Variable
        private Hashtable dot_govt_work_permit_app_ht = new Hashtable();
        #endregion
        #region Constant Variable
        private const string AID = "Permittee ID";
        private const string A_Permit_Name = "Permittee Name";
        private const string A_Address = "Address";
        private const string AT1 = "Area Code";
        private const string AT2 = "Tel 2";
        private const string AT3 = "Tel 3";
        private const string A_Email = "Email";
        private const string MN = "MN";
        private const string BK = "BK";
        private const string QN = "QN";
        private const string BX = "BX";
        private const string SI = "SI";
        private const string BO1 = "Engineering Control";
        private const string O2 = "2 Digit Year";
        private const string O3 = "File Number";
        private const string B_ContractName = "Contract Number";
        private const string B_DOB = "DOB#";
        private const string DEP = "DEP";
        private const string DDC = "DDC";
        private const string DOT = "DOT";
        private const string DPR = "DPR";
        private const string EDC = "EDC";
        private const string MTA = "MTA";
        private const string PANY_NJ = "PANY/NJ";
        private const string SCA = "SCA";
        private const string Other = "Other";
        private const string B_Other = "Other Agency";
        private const string B_Proj_Er_Name = "Project Engineer Name";
        private const string PT1 = "Area Code 2";
        private const string PT2 = "Tel 22";
        private const string PT3 = "Tel 23";
        private const string B_Res_Er_Name = "Resident Engineer Name";
        private const string RT1 = "Area Code 3";
        private const string RT2 = "Tel 32";
        private const string RT3 = "Tel 33";
        private const string B_Proj_Description = "Project Description";
        private const string B1 = "Contract Start Month";
        private const string B2 = "Contract Start Day";
        private const string B3 = "Contact Start Year";
        private const string B4 = "Contract End Month";
        private const string B5 = "Contract End Day";
        private const string B6 = "Contact End Year";
        private const string B_Roadway = "Roadway";
        private const string B_Sidewalk = "Sidewalk";
        private const string A0110 = "0110";
        private const string B0111 = "0111";
        private const string C0112 = "0112";
        private const string D0113 = "0113";
        private const string E0114 = "0114";
        private const string F0116 = "0116";
        private const string G0118 = "0118";
        private const string H0119 = "0119";
        private const string I0120 = "0120";
        private const string J0121 = "0121";
        private const string K0126 = "0126";
        private const string L0132 = "0132";
        private const string M0133 = "0133";
        private const string N0135 = "0135";
        private const string O0136 = "0136";
        private const string P0137 = "0137";
        private const string Q0157 = "0157";
        private const string R0158 = "0158";
        private const string S0159 = "0159";
        private const string T0160 = "0160";
        private const string U0161 = "0161";
        private const string V0162 = "0162";
        private const string W0163 = "0163";
        private const string X0164 = "0164";
        private const string OnStreet1 = "On Street 1";
        private const string CrossStreet1 = "From Street 1";
        private const string CossStreet2_1 = "To Street 1";
        private const string LF1 = "Linear Feet 1";
        private const string SD1 = "Start Date 1";
        private const string ED1 = "End Date 1";
        private const string OnStreet2 = "On Street 2";
        private const string CrossStreet2 = "From Street 2";
        private const string CossStreet2_2 = "To Street 2";
        private const string LF2 = "Linear Feet 2";
        private const string SD2 = "Start Date 2";
        private const string ED2 = "End Date 2";
        private const string OnStreet3 = "On Street 3";
        private const string CrossStreet3 = "From Street 3";
        private const string CossStreet2_3 = "To Street 3";
        private const string LF3 = "Linear Feet 3";
        private const string SD3 = "Start Date 3";
        private const string ED3 = "End Date 3";
        private const string OnStreet4 = "On Street 4";
        private const string CrossStreet4 = "From Street 4";
        private const string CossStreet2_4 = "To Street 4";
        private const string LF4 = "Linear Feet 4";
        private const string SD4 = "Start Date 4";
        private const string ED4 = "End Date 4";
        private const string OnStreet5 = "On Street 5";
        private const string CrossStreet5 = "From Street 5";
        private const string CossStreet2_5 = "To Street 5";
        private const string LF5 = "Linear Feet 5";
        private const string SD5 = "Start Date 5";
        private const string ED5 = "End Date 5";
        private const string OnStreet6 = "On Street 6";
        private const string CrossStreet6 = "From Street 6";
        private const string CossStreet2_6 = "To Street 6";
        private const string LF6 = "Linear Feet 6";
        private const string SD6 = "Start Date 6";
        private const string ED6 = "End Date 6";
        private const string OnStreet7 = "On Street 7";
        private const string CrossStreet7 = "From Street 7";
        private const string CossStreet2_7 = "To Street 7";
        private const string LF7 = "Linear Feet 7";
        private const string SD7 = "Start Date 7";
        private const string ED7 = "End Date 7";
        private const string OnStreet8 = "On Street 8";
        private const string CrossStreet8 = "From Street 8";
        private const string CossStreet2_8 = "To Street 8";
        private const string LF8 = "Linear Feet 8";
        private const string SD8 = "Start Date 8";
        private const string ED8 = "End Date 8";
        private const string OnStreet9 = "On Street 9";
        private const string CrossStreet9 = "From Street 9";
        private const string CossStreet2_9 = "To Street 9";
        private const string LF9 = "Linear Feet 9";
        private const string SD9 = "Start Date 9";
        private const string ED9 = "End Date 9";
        private const string OnStreet10 = "On Street 10";
        private const string CrossStreet10 = "From Street 10";
        private const string CossStreet2_10 = "To Street 10";
        private const string LF10 = "Linear Feet 10";
        private const string SD10 = "Start Date 10";
        private const string ED10 = "End Date 10";
        private const string Submitted_By = "Submitted by";
        private const string LT1 = "Area Code 4";
        private const string LT2 = "Tel 42";
        private const string LT3 = "Tel 43";
        private const string D7 = "Month";
        private const string D8 = "Day";
        private const string D9 = "Year";
        private const string Y0201 = "0201";
        private const string Y0202 = "0202";
        private const string Y0203 = "0203";
        private const string Y0204 = "0204";
        private const string Y0205 = "0205";
        private const string Y0208 = "0208";
        private const string Y0211 = "0211";
        private const string Y0214 = "0214";
        private const string Y0215 = "0215";
        private const string Y0221 = "0221";
        private const string G_Onstreet = "On Street 11";
        private const string G_CrossStreet = "From Street 11";
        private const string G_CrossStreet2 = "To Street 11";
        private const string LF = "Linear Feet 11";
        private const string SDate = "Start Date 11";
        private const string EDate = "End Date 11";
        private const string Permit_Type1 = "Permit Type 1";
        private const string Permit_Type2 = "Permit Type 2";
        private const string Permit_Type3 = "Permit Type 3";
        private const string Permit_Type4 = "Permit Type 4";
        private const string Permit_Type5 = "Permit Type 5";
        private const string G1_OnStreet = "On Street 12";
        private const string G1_CrossStreet = "From Street 12";
        private const string G1_CrossStreet2 = "To Street 12";
        private const string G1_LF = "Linear Feet 12";
        private const string G1_SDate = "Start Date 12";
        private const string G1_EDate = "End Date 12";
        private const string Permit_Type6 = "Permit Type 6";
        private const string Permit_Type7 = "Permit Type 7";
        private const string Permit_Type8 = "Permit Type 8";
        private const string Permit_Type9 = "Permit Type 9";
        private const string Permit_Type10 = "Permit Type 10";
        private const string G2_OnStreet = "On Street 13";
        private const string G2_CrossStreet = "From Street 13";
        private const string G2_CrossStreet2 = "To Street 13";
        private const string G2_LF = "Linear Feet 13";
        private const string G2_SDate = "Start Date 13";
        private const string G2_EDate = "End Date 13";
        private const string Permit_Type11 = "Permit Type 11";
        private const string Permit_Type12 = "Permit Type 12";
        private const string Permit_Type13 = "Permit Type 13";
        private const string Permit_Type14 = "Permit Type 14";
        private const string Permit_Type15 = "Permit Type 15";
        private const string G3_OnStreet = "On Street 14";
        private const string G3_CrossStreet = "From Street 14";
        private const string G3_CrossStreet2 = "To Street 14";
        private const string G3_LF = "Linear Feet 14";
        private const string G3_SDate = "Start Date 14";
        private const string G3_EDate = "End Date 14";
        private const string Permit_Type16 = "Permit Type 16";
        private const string Permit_Type17 = "Permit Type 17";
        private const string Permit_Type18 = "Permit Type 18";
        private const string Permit_Type19 = "Permit Type 19";
        private const string Permit_Type20 = "Permit Type 20";
        private const string G4_OnStreet = "On Street 15";
        private const string G4_CrossStreet = "From Street 15";
        private const string G4_CrossStreet2 = "To Street 15";
        private const string G4_LF = "Linear Feet 15";
        private const string G4_SDate = "Start Date 15";
        private const string G4_EDate = "End Date 15";
        private const string Permit_Type21 = "Permit Type 21";
        private const string Permit_Type22 = "Permit Type 22";
        private const string Permit_Type23 = "Permit Type 23";
        private const string Permit_Type24 = "Permit Type 24";
        private const string Permit_Type25 = "Permit Type 25";
        #endregion
        #region Properties
        public string AID_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[AID].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(AID))
                    dot_govt_work_permit_app_ht[AID] = value;
                else
                    dot_govt_work_permit_app_ht.Add(AID, value);
            }
        }
        public string A_Permit_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[A_Permit_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(A_Permit_Name))
                    dot_govt_work_permit_app_ht[A_Permit_Name] = value;
                else
                    dot_govt_work_permit_app_ht.Add(A_Permit_Name, value);
            }
        }
        public string A_Address_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[A_Address].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(A_Address))
                    dot_govt_work_permit_app_ht[A_Address] = value;
                else
                    dot_govt_work_permit_app_ht.Add(A_Address, value);
            }
        }
        public string AT1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[AT1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(AT1))
                    dot_govt_work_permit_app_ht[AT1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(AT1, value);
            }
        }
        public string AT2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[AT2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(AT2))
                    dot_govt_work_permit_app_ht[AT2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(AT2, value);
            }
        }
        public string AT3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[AT3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(AT3))
                    dot_govt_work_permit_app_ht[AT3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(AT3, value);
            }
        }
        public string A_Email_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[A_Email].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(A_Email))
                    dot_govt_work_permit_app_ht[A_Email] = value;
                else
                    dot_govt_work_permit_app_ht.Add(A_Email, value);
            }
        }
        public string MN_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[MN].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(MN))
                    dot_govt_work_permit_app_ht[MN] = value;
                else
                    dot_govt_work_permit_app_ht.Add(MN, value);
            }
        }
        public string BK_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[BK].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(BK))
                    dot_govt_work_permit_app_ht[BK] = value;
                else
                    dot_govt_work_permit_app_ht.Add(BK, value);
            }
        }
        public string QN_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[QN].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(QN))
                    dot_govt_work_permit_app_ht[QN] = value;
                else
                    dot_govt_work_permit_app_ht.Add(QN, value);
            }
        }
        public string BX_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[BX].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(BX))
                    dot_govt_work_permit_app_ht[BX] = value;
                else
                    dot_govt_work_permit_app_ht.Add(BX, value);
            }
        }
        public string SI_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SI].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SI))
                    dot_govt_work_permit_app_ht[SI] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SI, value);
            }
        }
        public string BO1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[BO1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(BO1))
                    dot_govt_work_permit_app_ht[BO1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(BO1, value);
            }
        }
        public string O2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[O2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(O2))
                    dot_govt_work_permit_app_ht[O2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(O2, value);
            }
        }
        public string O3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[O3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(O3))
                    dot_govt_work_permit_app_ht[O3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(O3, value);
            }
        }
        public string B_ContractName_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B_ContractName].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B_ContractName))
                    dot_govt_work_permit_app_ht[B_ContractName] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B_ContractName, value);
            }
        }
        public string B_DOB_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B_DOB].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B_DOB))
                    dot_govt_work_permit_app_ht[B_DOB] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B_DOB, value);
            }
        }
        public string DEP_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[DEP].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(DEP))
                    dot_govt_work_permit_app_ht[DEP] = value;
                else
                    dot_govt_work_permit_app_ht.Add(DEP, value);
            }
        }
        public string DDC_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[DDC].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(DDC))
                    dot_govt_work_permit_app_ht[DDC] = value;
                else
                    dot_govt_work_permit_app_ht.Add(DDC, value);
            }
        }
        public string DOT_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[DOT].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(DOT))
                    dot_govt_work_permit_app_ht[DOT] = value;
                else
                    dot_govt_work_permit_app_ht.Add(DOT, value);
            }
        }
        public string DPR_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[DPR].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(DPR))
                    dot_govt_work_permit_app_ht[DPR] = value;
                else
                    dot_govt_work_permit_app_ht.Add(DPR, value);
            }
        }
        public string EDC_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[EDC].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(EDC))
                    dot_govt_work_permit_app_ht[EDC] = value;
                else
                    dot_govt_work_permit_app_ht.Add(EDC, value);
            }
        }
        public string MTA_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[MTA].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(MTA))
                    dot_govt_work_permit_app_ht[MTA] = value;
                else
                    dot_govt_work_permit_app_ht.Add(MTA, value);
            }
        }
        public string PANY_NJ_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[PANY_NJ].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(PANY_NJ))
                    dot_govt_work_permit_app_ht[PANY_NJ] = value;
                else
                    dot_govt_work_permit_app_ht.Add(PANY_NJ, value);
            }
        }
        public string SCA_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SCA].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SCA))
                    dot_govt_work_permit_app_ht[SCA] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SCA, value);
            }
        }
        public string Other_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Other].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Other))
                    dot_govt_work_permit_app_ht[Other] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Other, value);
            }
        }
        public string B_Other_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B_Other].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B_Other))
                    dot_govt_work_permit_app_ht[B_Other] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B_Other, value);
            }
        }
        public string B_Proj_Er_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B_Proj_Er_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B_Proj_Er_Name))
                    dot_govt_work_permit_app_ht[B_Proj_Er_Name] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B_Proj_Er_Name, value);
            }
        }
        public string PT1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[PT1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(PT1))
                    dot_govt_work_permit_app_ht[PT1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(PT1, value);
            }
        }
        public string PT2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[PT2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(PT2))
                    dot_govt_work_permit_app_ht[PT2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(PT2, value);
            }
        }
        public string PT3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[PT3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(PT3))
                    dot_govt_work_permit_app_ht[PT3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(PT3, value);
            }
        }
        public string B_Res_Er_Name_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B_Res_Er_Name].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B_Res_Er_Name))
                    dot_govt_work_permit_app_ht[B_Res_Er_Name] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B_Res_Er_Name, value);
            }
        }
        public string RT1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[RT1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(RT1))
                    dot_govt_work_permit_app_ht[RT1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(RT1, value);
            }
        }
        public string RT2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[RT2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(RT2))
                    dot_govt_work_permit_app_ht[RT2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(RT2, value);
            }
        }
        public string RT3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[RT3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(RT3))
                    dot_govt_work_permit_app_ht[RT3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(RT3, value);
            }
        }
        public string B_Proj_Description_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B_Proj_Description].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B_Proj_Description))
                    dot_govt_work_permit_app_ht[B_Proj_Description] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B_Proj_Description, value);
            }
        }
        public string B1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B1))
                    dot_govt_work_permit_app_ht[B1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B1, value);
            }
        }
        public string B2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B2))
                    dot_govt_work_permit_app_ht[B2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B2, value);
            }
        }
        public string B3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B3))
                    dot_govt_work_permit_app_ht[B3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B3, value);
            }
        }
        public string B4_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B4))
                    dot_govt_work_permit_app_ht[B4] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B4, value);
            }
        }
        public string B5_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B5))
                    dot_govt_work_permit_app_ht[B5] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B5, value);
            }
        }
        public string B6_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B6))
                    dot_govt_work_permit_app_ht[B6] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B6, value);
            }
        }
        public string B_Roadway_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B_Roadway].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B_Roadway))
                    dot_govt_work_permit_app_ht[B_Roadway] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B_Roadway, value);
            }
        }
        public string B_Sidewalk_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B_Sidewalk].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B_Sidewalk))
                    dot_govt_work_permit_app_ht[B_Sidewalk] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B_Sidewalk, value);
            }
        }
        public string A0110_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[A0110].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(A0110))
                    dot_govt_work_permit_app_ht[A0110] = value;
                else
                    dot_govt_work_permit_app_ht.Add(A0110, value);
            }
        }
        public string B0111_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[B0111].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(B0111))
                    dot_govt_work_permit_app_ht[B0111] = value;
                else
                    dot_govt_work_permit_app_ht.Add(B0111, value);
            }
        }
        public string C0112_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[C0112].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(C0112))
                    dot_govt_work_permit_app_ht[C0112] = value;
                else
                    dot_govt_work_permit_app_ht.Add(C0112, value);
            }
        }
        public string D0113_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[D0113].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(D0113))
                    dot_govt_work_permit_app_ht[D0113] = value;
                else
                    dot_govt_work_permit_app_ht.Add(D0113, value);
            }
        }
        public string E0114_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[E0114].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(E0114))
                    dot_govt_work_permit_app_ht[E0114] = value;
                else
                    dot_govt_work_permit_app_ht.Add(E0114, value);
            }
        }
        public string F0116_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[F0116].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(F0116))
                    dot_govt_work_permit_app_ht[F0116] = value;
                else
                    dot_govt_work_permit_app_ht.Add(F0116, value);
            }
        }
        public string G0118_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G0118].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G0118))
                    dot_govt_work_permit_app_ht[G0118] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G0118, value);
            }
        }
        public string H0119_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[H0119].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(H0119))
                    dot_govt_work_permit_app_ht[H0119] = value;
                else
                    dot_govt_work_permit_app_ht.Add(H0119, value);
            }
        }
        public string I0120_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[I0120].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(I0120))
                    dot_govt_work_permit_app_ht[I0120] = value;
                else
                    dot_govt_work_permit_app_ht.Add(I0120, value);
            }
        }
        public string J0121_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[J0121].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(J0121))
                    dot_govt_work_permit_app_ht[J0121] = value;
                else
                    dot_govt_work_permit_app_ht.Add(J0121, value);
            }
        }
        public string K0126_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[K0126].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(K0126))
                    dot_govt_work_permit_app_ht[K0126] = value;
                else
                    dot_govt_work_permit_app_ht.Add(K0126, value);
            }
        }
        public string L0132_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[L0132].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(L0132))
                    dot_govt_work_permit_app_ht[L0132] = value;
                else
                    dot_govt_work_permit_app_ht.Add(L0132, value);
            }
        }
        public string M0133_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[M0133].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(M0133))
                    dot_govt_work_permit_app_ht[M0133] = value;
                else
                    dot_govt_work_permit_app_ht.Add(M0133, value);
            }
        }
        public string N0135_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[N0135].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(N0135))
                    dot_govt_work_permit_app_ht[N0135] = value;
                else
                    dot_govt_work_permit_app_ht.Add(N0135, value);
            }
        }
        public string O0136_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[O0136].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(O0136))
                    dot_govt_work_permit_app_ht[O0136] = value;
                else
                    dot_govt_work_permit_app_ht.Add(O0136, value);
            }
        }
        public string P0137_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[P0137].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(P0137))
                    dot_govt_work_permit_app_ht[P0137] = value;
                else
                    dot_govt_work_permit_app_ht.Add(P0137, value);
            }
        }
        public string Q0157_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Q0157].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Q0157))
                    dot_govt_work_permit_app_ht[Q0157] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Q0157, value);
            }
        }
        public string R0158_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[R0158].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(R0158))
                    dot_govt_work_permit_app_ht[R0158] = value;
                else
                    dot_govt_work_permit_app_ht.Add(R0158, value);
            }
        }
        public string S0159_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[S0159].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(S0159))
                    dot_govt_work_permit_app_ht[S0159] = value;
                else
                    dot_govt_work_permit_app_ht.Add(S0159, value);
            }
        }
        public string T0160_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[T0160].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(T0160))
                    dot_govt_work_permit_app_ht[T0160] = value;
                else
                    dot_govt_work_permit_app_ht.Add(T0160, value);
            }
        }
        public string U0161_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[U0161].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(U0161))
                    dot_govt_work_permit_app_ht[U0161] = value;
                else
                    dot_govt_work_permit_app_ht.Add(U0161, value);
            }
        }
        public string V0162_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[V0162].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(V0162))
                    dot_govt_work_permit_app_ht[V0162] = value;
                else
                    dot_govt_work_permit_app_ht.Add(V0162, value);
            }
        }
        public string W0163_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[W0163].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(W0163))
                    dot_govt_work_permit_app_ht[W0163] = value;
                else
                    dot_govt_work_permit_app_ht.Add(W0163, value);
            }
        }
        public string X0164_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[X0164].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(X0164))
                    dot_govt_work_permit_app_ht[X0164] = value;
                else
                    dot_govt_work_permit_app_ht.Add(X0164, value);
            }
        }
        public string OnStreet1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet1))
                    dot_govt_work_permit_app_ht[OnStreet1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet1, value);
            }
        }
        public string CrossStreet1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet1))
                    dot_govt_work_permit_app_ht[CrossStreet1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet1, value);
            }
        }
        public string CossStreet2_1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_1))
                    dot_govt_work_permit_app_ht[CossStreet2_1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_1, value);
            }
        }
        public string LF1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF1))
                    dot_govt_work_permit_app_ht[LF1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF1, value);
            }
        }
        public string SD1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD1))
                    dot_govt_work_permit_app_ht[SD1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD1, value);
            }
        }
        public string ED1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED1))
                    dot_govt_work_permit_app_ht[ED1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED1, value);
            }
        }
        public string OnStreet2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet2))
                    dot_govt_work_permit_app_ht[OnStreet2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet2, value);
            }
        }
        public string CrossStreet2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet2))
                    dot_govt_work_permit_app_ht[CrossStreet2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet2, value);
            }
        }
        public string CossStreet2_2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_2))
                    dot_govt_work_permit_app_ht[CossStreet2_2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_2, value);
            }
        }
        public string LF2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF2))
                    dot_govt_work_permit_app_ht[LF2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF2, value);
            }
        }
        public string SD2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD2))
                    dot_govt_work_permit_app_ht[SD2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD2, value);
            }
        }
        public string ED2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED2))
                    dot_govt_work_permit_app_ht[ED2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED2, value);
            }
        }
        public string OnStreet3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet3))
                    dot_govt_work_permit_app_ht[OnStreet3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet3, value);
            }
        }
        public string CrossStreet3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet3))
                    dot_govt_work_permit_app_ht[CrossStreet3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet3, value);
            }
        }
        public string CossStreet2_3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_3))
                    dot_govt_work_permit_app_ht[CossStreet2_3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_3, value);
            }
        }
        public string LF3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF3))
                    dot_govt_work_permit_app_ht[LF3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF3, value);
            }
        }
        public string SD3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD3))
                    dot_govt_work_permit_app_ht[SD3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD3, value);
            }
        }
        public string ED3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED3))
                    dot_govt_work_permit_app_ht[ED3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED3, value);
            }
        }
        public string OnStreet4_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet4))
                    dot_govt_work_permit_app_ht[OnStreet4] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet4, value);
            }
        }
        public string CrossStreet4_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet4))
                    dot_govt_work_permit_app_ht[CrossStreet4] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet4, value);
            }
        }
        public string CossStreet2_4_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_4))
                    dot_govt_work_permit_app_ht[CossStreet2_4] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_4, value);
            }
        }
        public string LF4_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF4))
                    dot_govt_work_permit_app_ht[LF4] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF4, value);
            }
        }
        public string SD4_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD4))
                    dot_govt_work_permit_app_ht[SD4] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD4, value);
            }
        }
        public string ED4_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED4))
                    dot_govt_work_permit_app_ht[ED4] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED4, value);
            }
        }
        public string OnStreet5_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet5))
                    dot_govt_work_permit_app_ht[OnStreet5] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet5, value);
            }
        }
        public string CrossStreet5_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet5))
                    dot_govt_work_permit_app_ht[CrossStreet5] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet5, value);
            }
        }
        public string CossStreet2_5_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_5))
                    dot_govt_work_permit_app_ht[CossStreet2_5] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_5, value);
            }
        }
        public string LF5_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF5))
                    dot_govt_work_permit_app_ht[LF5] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF5, value);
            }
        }
        public string SD5_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD5))
                    dot_govt_work_permit_app_ht[SD5] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD5, value);
            }
        }
        public string ED5_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED5))
                    dot_govt_work_permit_app_ht[ED5] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED5, value);
            }
        }
        public string OnStreet6_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet6))
                    dot_govt_work_permit_app_ht[OnStreet6] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet6, value);
            }
        }
        public string CrossStreet6_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet6))
                    dot_govt_work_permit_app_ht[CrossStreet6] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet6, value);
            }
        }
        public string CossStreet2_6_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_6))
                    dot_govt_work_permit_app_ht[CossStreet2_6] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_6, value);
            }
        }
        public string LF6_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF6))
                    dot_govt_work_permit_app_ht[LF6] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF6, value);
            }
        }
        public string SD6_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD6))
                    dot_govt_work_permit_app_ht[SD6] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD6, value);
            }
        }
        public string ED6_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED6))
                    dot_govt_work_permit_app_ht[ED6] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED6, value);
            }
        }
        public string OnStreet7_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet7))
                    dot_govt_work_permit_app_ht[OnStreet7] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet7, value);
            }
        }
        public string CrossStreet7_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet7))
                    dot_govt_work_permit_app_ht[CrossStreet7] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet7, value);
            }
        }
        public string CossStreet2_7_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_7))
                    dot_govt_work_permit_app_ht[CossStreet2_7] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_7, value);
            }
        }
        public string LF7_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF7))
                    dot_govt_work_permit_app_ht[LF7] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF7, value);
            }
        }
        public string SD7_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD7))
                    dot_govt_work_permit_app_ht[SD7] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD7, value);
            }
        }
        public string ED7_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED7))
                    dot_govt_work_permit_app_ht[ED7] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED7, value);
            }
        }
        public string OnStreet8_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet8))
                    dot_govt_work_permit_app_ht[OnStreet8] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet8, value);
            }
        }
        public string CrossStreet8_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet8))
                    dot_govt_work_permit_app_ht[CrossStreet8] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet8, value);
            }
        }
        public string CossStreet2_8_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_8))
                    dot_govt_work_permit_app_ht[CossStreet2_8] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_8, value);
            }
        }
        public string LF8_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF8))
                    dot_govt_work_permit_app_ht[LF8] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF8, value);
            }
        }
        public string SD8_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD8))
                    dot_govt_work_permit_app_ht[SD8] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD8, value);
            }
        }
        public string ED8_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED8))
                    dot_govt_work_permit_app_ht[ED8] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED8, value);
            }
        }
        public string OnStreet9_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet9))
                    dot_govt_work_permit_app_ht[OnStreet9] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet9, value);
            }
        }
        public string CrossStreet9_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet9))
                    dot_govt_work_permit_app_ht[CrossStreet9] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet9, value);
            }
        }
        public string CossStreet2_9_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_9))
                    dot_govt_work_permit_app_ht[CossStreet2_9] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_9, value);
            }
        }
        public string LF9_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF9))
                    dot_govt_work_permit_app_ht[LF9] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF9, value);
            }
        }
        public string SD9_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD9))
                    dot_govt_work_permit_app_ht[SD9] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD9, value);
            }
        }
        public string ED9_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED9))
                    dot_govt_work_permit_app_ht[ED9] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED9, value);
            }
        }
        public string OnStreet10_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[OnStreet10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(OnStreet10))
                    dot_govt_work_permit_app_ht[OnStreet10] = value;
                else
                    dot_govt_work_permit_app_ht.Add(OnStreet10, value);
            }
        }
        public string CrossStreet10_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CrossStreet10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CrossStreet10))
                    dot_govt_work_permit_app_ht[CrossStreet10] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CrossStreet10, value);
            }
        }
        public string CossStreet2_10_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[CossStreet2_10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(CossStreet2_10))
                    dot_govt_work_permit_app_ht[CossStreet2_10] = value;
                else
                    dot_govt_work_permit_app_ht.Add(CossStreet2_10, value);
            }
        }
        public string LF10_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF10))
                    dot_govt_work_permit_app_ht[LF10] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF10, value);
            }
        }
        public string SD10_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SD10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SD10))
                    dot_govt_work_permit_app_ht[SD10] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SD10, value);
            }
        }
        public string ED10_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[ED10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(ED10))
                    dot_govt_work_permit_app_ht[ED10] = value;
                else
                    dot_govt_work_permit_app_ht.Add(ED10, value);
            }
        }
        public string Submitted_By_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Submitted_By].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Submitted_By))
                    dot_govt_work_permit_app_ht[Submitted_By] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Submitted_By, value);
            }
        }
        public string LT1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LT1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LT1))
                    dot_govt_work_permit_app_ht[LT1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LT1, value);
            }
        }
        public string LT2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LT2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LT2))
                    dot_govt_work_permit_app_ht[LT2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LT2, value);
            }
        }
        public string LT3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LT3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LT3))
                    dot_govt_work_permit_app_ht[LT3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LT3, value);
            }
        }
        public string D7_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[D7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(D7))
                    dot_govt_work_permit_app_ht[D7] = value;
                else
                    dot_govt_work_permit_app_ht.Add(D7, value);
            }
        }
        public string D8_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[D8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(D8))
                    dot_govt_work_permit_app_ht[D8] = value;
                else
                    dot_govt_work_permit_app_ht.Add(D8, value);
            }
        }
        public string D9_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[D9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(D9))
                    dot_govt_work_permit_app_ht[D9] = value;
                else
                    dot_govt_work_permit_app_ht.Add(D9, value);
            }
        }
        public string Y0201_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0201].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0201))
                    dot_govt_work_permit_app_ht[Y0201] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0201, value);
            }
        }
        public string Y0202_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0202].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0202))
                    dot_govt_work_permit_app_ht[Y0202] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0202, value);
            }
        }
        public string Y0203_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0203].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0203))
                    dot_govt_work_permit_app_ht[Y0203] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0203, value);
            }
        }
        public string Y0204_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0204].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0204))
                    dot_govt_work_permit_app_ht[Y0204] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0204, value);
            }
        }
        public string Y0205_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0205].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0205))
                    dot_govt_work_permit_app_ht[Y0205] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0205, value);
            }
        }
        public string Y0208_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0208].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0208))
                    dot_govt_work_permit_app_ht[Y0208] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0208, value);
            }
        }
        public string Y0211_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0211].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0211))
                    dot_govt_work_permit_app_ht[Y0211] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0211, value);
            }
        }
        public string Y0214_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0214].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0214))
                    dot_govt_work_permit_app_ht[Y0214] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0214, value);
            }
        }
        public string Y0215_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0215].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0215))
                    dot_govt_work_permit_app_ht[Y0215] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0215, value);
            }
        }
        public string Y0221_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Y0221].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Y0221))
                    dot_govt_work_permit_app_ht[Y0221] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Y0221, value);
            }
        }
        public string G_Onstreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G_Onstreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G_Onstreet))
                    dot_govt_work_permit_app_ht[G_Onstreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G_Onstreet, value);
            }
        }
        public string G_CrossStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G_CrossStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G_CrossStreet))
                    dot_govt_work_permit_app_ht[G_CrossStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G_CrossStreet, value);
            }
        }
        public string G_CrossStreet2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G_CrossStreet2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G_CrossStreet2))
                    dot_govt_work_permit_app_ht[G_CrossStreet2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G_CrossStreet2, value);
            }
        }
        public string LF_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[LF].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(LF))
                    dot_govt_work_permit_app_ht[LF] = value;
                else
                    dot_govt_work_permit_app_ht.Add(LF, value);
            }
        }
        public string SDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[SDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(SDate))
                    dot_govt_work_permit_app_ht[SDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(SDate, value);
            }
        }
        public string EDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[EDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(EDate))
                    dot_govt_work_permit_app_ht[EDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(EDate, value);
            }
        }
        public string Permit_Type1_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type1].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type1))
                    dot_govt_work_permit_app_ht[Permit_Type1] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type1, value);
            }
        }
        public string Permit_Type2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type2))
                    dot_govt_work_permit_app_ht[Permit_Type2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type2, value);
            }
        }
        public string Permit_Type3_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type3].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type3))
                    dot_govt_work_permit_app_ht[Permit_Type3] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type3, value);
            }
        }
        public string Permit_Type4_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type4].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type4))
                    dot_govt_work_permit_app_ht[Permit_Type4] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type4, value);
            }
        }
        public string Permit_Type5_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type5].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type5))
                    dot_govt_work_permit_app_ht[Permit_Type5] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type5, value);
            }
        }
        public string G1_OnStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G1_OnStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G1_OnStreet))
                    dot_govt_work_permit_app_ht[G1_OnStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G1_OnStreet, value);
            }
        }
        public string G1_CrossStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G1_CrossStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G1_CrossStreet))
                    dot_govt_work_permit_app_ht[G1_CrossStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G1_CrossStreet, value);
            }
        }
        public string G1_CrossStreet2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G1_CrossStreet2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G1_CrossStreet2))
                    dot_govt_work_permit_app_ht[G1_CrossStreet2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G1_CrossStreet2, value);
            }
        }
        public string G1_LF_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G1_LF].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G1_LF))
                    dot_govt_work_permit_app_ht[G1_LF] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G1_LF, value);
            }
        }
        public string G1_SDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G1_SDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G1_SDate))
                    dot_govt_work_permit_app_ht[G1_SDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G1_SDate, value);
            }
        }
        public string G1_EDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G1_EDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G1_EDate))
                    dot_govt_work_permit_app_ht[G1_EDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G1_EDate, value);
            }
        }
        public string Permit_Type6_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type6].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type6))
                    dot_govt_work_permit_app_ht[Permit_Type6] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type6, value);
            }
        }
        public string Permit_Type7_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type7].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type7))
                    dot_govt_work_permit_app_ht[Permit_Type7] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type7, value);
            }
        }
        public string Permit_Type8_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type8].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type8))
                    dot_govt_work_permit_app_ht[Permit_Type8] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type8, value);
            }
        }
        public string Permit_Type9_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type9].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type9))
                    dot_govt_work_permit_app_ht[Permit_Type9] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type9, value);
            }
        }
        public string Permit_Type10_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type10].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type10))
                    dot_govt_work_permit_app_ht[Permit_Type10] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type10, value);
            }
        }
        public string G2_OnStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G2_OnStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G2_OnStreet))
                    dot_govt_work_permit_app_ht[G2_OnStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G2_OnStreet, value);
            }
        }
        public string G2_CrossStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G2_CrossStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G2_CrossStreet))
                    dot_govt_work_permit_app_ht[G2_CrossStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G2_CrossStreet, value);
            }
        }
        public string G2_CrossStreet2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G2_CrossStreet2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G2_CrossStreet2))
                    dot_govt_work_permit_app_ht[G2_CrossStreet2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G2_CrossStreet2, value);
            }
        }
        public string G2_LF_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G2_LF].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G2_LF))
                    dot_govt_work_permit_app_ht[G2_LF] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G2_LF, value);
            }
        }
        public string G2_SDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G2_SDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G2_SDate))
                    dot_govt_work_permit_app_ht[G2_SDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G2_SDate, value);
            }
        }
        public string G2_EDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G2_EDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G2_EDate))
                    dot_govt_work_permit_app_ht[G2_EDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G2_EDate, value);
            }
        }
        public string Permit_Type11_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type11].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type11))
                    dot_govt_work_permit_app_ht[Permit_Type11] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type11, value);
            }
        }
        public string Permit_Type12_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type12].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type12))
                    dot_govt_work_permit_app_ht[Permit_Type12] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type12, value);
            }
        }
        public string Permit_Type13_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type13].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type13))
                    dot_govt_work_permit_app_ht[Permit_Type13] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type13, value);
            }
        }
        public string Permit_Type14_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type14].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type14))
                    dot_govt_work_permit_app_ht[Permit_Type14] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type14, value);
            }
        }
        public string Permit_Type15_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type15].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type15))
                    dot_govt_work_permit_app_ht[Permit_Type15] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type15, value);
            }
        }
        public string G3_OnStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G3_OnStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G3_OnStreet))
                    dot_govt_work_permit_app_ht[G3_OnStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G3_OnStreet, value);
            }
        }
        public string G3_CrossStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G3_CrossStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G3_CrossStreet))
                    dot_govt_work_permit_app_ht[G3_CrossStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G3_CrossStreet, value);
            }
        }
        public string G3_CrossStreet2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G3_CrossStreet2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G3_CrossStreet2))
                    dot_govt_work_permit_app_ht[G3_CrossStreet2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G3_CrossStreet2, value);
            }
        }
        public string G3_LF_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G3_LF].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G3_LF))
                    dot_govt_work_permit_app_ht[G3_LF] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G3_LF, value);
            }
        }
        public string G3_SDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G3_SDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G3_SDate))
                    dot_govt_work_permit_app_ht[G3_SDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G3_SDate, value);
            }
        }
        public string G3_EDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G3_EDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G3_EDate))
                    dot_govt_work_permit_app_ht[G3_EDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G3_EDate, value);
            }
        }
        public string Permit_Type16_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type16].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type16))
                    dot_govt_work_permit_app_ht[Permit_Type16] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type16, value);
            }
        }
        public string Permit_Type17_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type17].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type17))
                    dot_govt_work_permit_app_ht[Permit_Type17] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type17, value);
            }
        }
        public string Permit_Type18_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type18].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type18))
                    dot_govt_work_permit_app_ht[Permit_Type18] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type18, value);
            }
        }
        public string Permit_Type19_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type19].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type19))
                    dot_govt_work_permit_app_ht[Permit_Type19] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type19, value);
            }
        }
        public string Permit_Type20_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type20].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type20))
                    dot_govt_work_permit_app_ht[Permit_Type20] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type20, value);
            }
        }
        public string G4_OnStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G4_OnStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G4_OnStreet))
                    dot_govt_work_permit_app_ht[G4_OnStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G4_OnStreet, value);
            }
        }
        public string G4_CrossStreet_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G4_CrossStreet].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G4_CrossStreet))
                    dot_govt_work_permit_app_ht[G4_CrossStreet] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G4_CrossStreet, value);
            }
        }
        public string G4_CrossStreet2_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G4_CrossStreet2].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G4_CrossStreet2))
                    dot_govt_work_permit_app_ht[G4_CrossStreet2] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G4_CrossStreet2, value);
            }
        }
        public string G4_LF_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G4_LF].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G4_LF))
                    dot_govt_work_permit_app_ht[G4_LF] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G4_LF, value);
            }
        }
        public string G4_SDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G4_SDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G4_SDate))
                    dot_govt_work_permit_app_ht[G4_SDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G4_SDate, value);
            }
        }
        public string G4_EDate_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[G4_EDate].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(G4_EDate))
                    dot_govt_work_permit_app_ht[G4_EDate] = value;
                else
                    dot_govt_work_permit_app_ht.Add(G4_EDate, value);
            }
        }
        public string Permit_Type21_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type21].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type21))
                    dot_govt_work_permit_app_ht[Permit_Type21] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type21, value);
            }
        }
        public string Permit_Type22_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type22].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type22))
                    dot_govt_work_permit_app_ht[Permit_Type22] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type22, value);
            }
        }
        public string Permit_Type23_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type23].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type23))
                    dot_govt_work_permit_app_ht[Permit_Type23] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type23, value);
            }
        }
        public string Permit_Type24_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type24].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type24))
                    dot_govt_work_permit_app_ht[Permit_Type24] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type24, value);
            }
        }
        public string Permit_Type25_Pro
        {
            get
            {
                return dot_govt_work_permit_app_ht[Permit_Type25].ToString();
            }
            set
            {
                if (dot_govt_work_permit_app_ht.ContainsKey(Permit_Type25))
                    dot_govt_work_permit_app_ht[Permit_Type25] = value;
                else
                    dot_govt_work_permit_app_ht.Add(Permit_Type25, value);
            }
        }
        #endregion
        public void Filldot_govt_work_permit_apppdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_govt_work_permit_app_ht)
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