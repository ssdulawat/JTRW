using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class dot_permapprenew
    {
        #region Global Variable
        private Hashtable dot_permapprenew_ht = new Hashtable();
        #endregion
        #region Constant
        private const string AID = "Permittee ID";
        private const string PermitName = "Permittee Name";
        private const string A_Address = "Address";
        private const string T1 = "Area Code";
        private const string T2 = "Tel 2";
        private const string T3 = "Tel 3";
        private const string A_Email = "Email";
        private const string MN = "MN";
        private const string BK = "BK";
        private const string QN = "QN";
        private const string BX = "BX";
        private const string SI = "SI";
        private const string O1 = "Engineering Control";
        private const string O2 = "2 Digit year";
        private const string O3 = "File Number";
        private const string Roadway = "Roadway";
        private const string Sidewalk = "Sidewalk";
        private const string DOB = "DOB#";
        private const string House_No = "House No";
        private const string OnStreet = "On Street";
        private const string Street_WorkOn = "Street Work On If Different From Above";
        private const string CrossStreet1 = "Cross Street #1";
        private const string CrossStreet2 = "Cross Street #2";
        private const string PurposeOf = "Purpose";
        private const string C_PermitNo1 = "Permit #1";
        private const string C_PermitType1 = "Permit Type 1";
        private const string NED1 = "End Date 1";
        private const string C_PermitNo2 = "Permit #2";
        private const string C_PermitType2 = "Permit Type 2";
        private const string NED2 = "End Date 2";
        private const string C_PermitNo3 = "Permit #3";
        private const string C_PermitType3 = "Permit Type 3";
        private const string NED3 = "End Date 3";
        private const string C_PermitNo4 = "Permit #4";
        private const string C_PermitType4 = "Permit Type 4";
        private const string NED4 = "End Date 4";
        private const string C_PermitNo5 = "Permit #5";
        private const string C_PermitType5 = "Permit Type 5";
        private const string NED5 = "End Date 5";
        private const string C_PermitNo6 = "Permit #6";
        private const string C_PermitType6 = "Permit Type 6";
        private const string NED6 = "End Date 6";
        private const string C_PermitNo7 = "Permit #7";
        private const string C_PermitType7 = "Permit Type 7";
        private const string NED7 = "End Date 7";
        private const string C_PermitNo8 = "Permit #8";
        private const string C_PermitType8 = "Permit Type 8";
        private const string NED8 = "End Date 8";
        private const string C_PermitNo9 = "Permit #9";
        private const string C_PermitType9 = "Permit Type 9";
        private const string NED9 = "End Date 9";
        private const string C_PErmitNo10 = "Permit #10";
        private const string C_PermitType10 = "Permit Type 10";
        private const string NED10 = "End Date 10";
        private const string C_PermitNo11 = "Permit #11";
        private const string C_PermitType11 = "Permit Type 11";
        private const string NED11 = "End Date 11";
        private const string C_PermitNo12 = "Permit #12";
        private const string C_PermitType12 = "Permit Type 12";
        private const string NED12 = "End Date 12";
        private const string SubmittedBy = "Submitted by";
        private const string T4 = "Area Code 2";
        private const string T5 = "Tel 22";
        private const string T6 = "Tel 32";
        private const string D1 = "Month";
        private const string D2 = "Day";
        private const string D3 = "Year";

        #endregion
        #region Properties
        public string AID_Pro
        {
            get
            {
                return dot_permapprenew_ht[AID].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(AID))
                    dot_permapprenew_ht[AID] = value;
                else
                    dot_permapprenew_ht.Add(AID, value);
            }
        }
        public string PermitName_Pro
        {
            get
            {
                return dot_permapprenew_ht[PermitName].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(PermitName))
                    dot_permapprenew_ht[PermitName] = value;
                else
                    dot_permapprenew_ht.Add(PermitName, value);
            }
        }
        public string A_Address_Pro
        {
            get
            {
                return dot_permapprenew_ht[A_Address].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(A_Address))
                    dot_permapprenew_ht[A_Address] = value;
                else
                    dot_permapprenew_ht.Add(A_Address, value);
            }
        }
        public string T1_Pro
        {
            get
            {
                return dot_permapprenew_ht[T1].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(T1))
                    dot_permapprenew_ht[T1] = value;
                else
                    dot_permapprenew_ht.Add(T1, value);
            }
        }
        public string T2_Pro
        {
            get
            {
                return dot_permapprenew_ht[T2].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(T2))
                    dot_permapprenew_ht[T2] = value;
                else
                    dot_permapprenew_ht.Add(T2, value);
            }
        }
        public string T3_Pro
        {
            get
            {
                return dot_permapprenew_ht[T3].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(T3))
                    dot_permapprenew_ht[T3] = value;
                else
                    dot_permapprenew_ht.Add(T3, value);
            }
        }
        public string A_Email_Pro
        {
            get
            {
                return dot_permapprenew_ht[A_Email].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(A_Email))
                    dot_permapprenew_ht[A_Email] = value;
                else
                    dot_permapprenew_ht.Add(A_Email, value);
            }
        }
        public string MN_Pro
        {
            get
            {
                return dot_permapprenew_ht[MN].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(MN))
                    dot_permapprenew_ht[MN] = value;
                else
                    dot_permapprenew_ht.Add(MN, value);
            }
        }
        public string BK_Pro
        {
            get
            {
                return dot_permapprenew_ht[BK].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(BK))
                    dot_permapprenew_ht[BK] = value;
                else
                    dot_permapprenew_ht.Add(BK, value);
            }
        }
        public string QN_Pro
        {
            get
            {
                return dot_permapprenew_ht[QN].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(QN))
                    dot_permapprenew_ht[QN] = value;
                else
                    dot_permapprenew_ht.Add(QN, value);
            }
        }
        public string BX_Pro
        {
            get
            {
                return dot_permapprenew_ht[BX].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(BX))
                    dot_permapprenew_ht[BX] = value;
                else
                    dot_permapprenew_ht.Add(BX, value);
            }
        }
        public string SI_Pro
        {
            get
            {
                return dot_permapprenew_ht[SI].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(SI))
                    dot_permapprenew_ht[SI] = value;
                else
                    dot_permapprenew_ht.Add(SI, value);
            }
        }
        public string O1_Pro
        {
            get
            {
                return dot_permapprenew_ht[O1].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(O1))
                    dot_permapprenew_ht[O1] = value;
                else
                    dot_permapprenew_ht.Add(O1, value);
            }
        }
        public string O2_Pro
        {
            get
            {
                return dot_permapprenew_ht[O2].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(O2))
                    dot_permapprenew_ht[O2] = value;
                else
                    dot_permapprenew_ht.Add(O2, value);
            }
        }
        public string O3_Pro
        {
            get
            {
                return dot_permapprenew_ht[O3].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(O3))
                    dot_permapprenew_ht[O3] = value;
                else
                    dot_permapprenew_ht.Add(O3, value);
            }
        }
        public string Roadway_Pro
        {
            get
            {
                return dot_permapprenew_ht[Roadway].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(Roadway))
                    dot_permapprenew_ht[Roadway] = value;
                else
                    dot_permapprenew_ht.Add(Roadway, value);
            }
        }
        public string Sidewalk_Pro
        {
            get
            {
                return dot_permapprenew_ht[Sidewalk].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(Sidewalk))
                    dot_permapprenew_ht[Sidewalk] = value;
                else
                    dot_permapprenew_ht.Add(Sidewalk, value);
            }
        }
        public string DOB_Pro
        {
            get
            {
                return dot_permapprenew_ht[DOB].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(DOB))
                    dot_permapprenew_ht[DOB] = value;
                else
                    dot_permapprenew_ht.Add(DOB, value);
            }
        }
        public string House_No_Pro
        {
            get
            {
                return dot_permapprenew_ht[House_No].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(House_No))
                    dot_permapprenew_ht[House_No] = value;
                else
                    dot_permapprenew_ht.Add(House_No, value);
            }
        }
        public string OnStreet_Pro
        {
            get
            {
                return dot_permapprenew_ht[OnStreet].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(OnStreet))
                    dot_permapprenew_ht[OnStreet] = value;
                else
                    dot_permapprenew_ht.Add(OnStreet, value);
            }
        }
        public string Street_WorkOn_Pro
        {
            get
            {
                return dot_permapprenew_ht[Street_WorkOn].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(Street_WorkOn))
                    dot_permapprenew_ht[Street_WorkOn] = value;
                else
                    dot_permapprenew_ht.Add(Street_WorkOn, value);
            }
        }
        public string CrossStreet1_Pro
        {
            get
            {
                return dot_permapprenew_ht[CrossStreet1].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(CrossStreet1))
                    dot_permapprenew_ht[CrossStreet1] = value;
                else
                    dot_permapprenew_ht.Add(CrossStreet1, value);
            }
        }
        public string CrossStreet2_Pro
        {
            get
            {
                return dot_permapprenew_ht[CrossStreet2].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(CrossStreet2))
                    dot_permapprenew_ht[CrossStreet2] = value;
                else
                    dot_permapprenew_ht.Add(CrossStreet2, value);
            }
        }
        public string PurposeOf_Pro
        {
            get
            {
                return dot_permapprenew_ht[PurposeOf].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(PurposeOf))
                    dot_permapprenew_ht[PurposeOf] = value;
                else
                    dot_permapprenew_ht.Add(PurposeOf, value);
            }
        }
        public string C_PermitNo1_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo1].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo1))
                    dot_permapprenew_ht[C_PermitNo1] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo1, value);
            }
        }
        public string C_PermitType1_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType1].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType1))
                    dot_permapprenew_ht[C_PermitType1] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType1, value);
            }
        }
        public string NED1_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED1].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED1))
                    dot_permapprenew_ht[NED1] = value;
                else
                    dot_permapprenew_ht.Add(NED1, value);
            }
        }
        public string C_PermitNo2_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo2].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo2))
                    dot_permapprenew_ht[C_PermitNo2] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo2, value);
            }
        }
        public string C_PermitType2_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType2].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType2))
                    dot_permapprenew_ht[C_PermitType2] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType2, value);
            }
        }
        public string NED2_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED2].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED2))
                    dot_permapprenew_ht[NED2] = value;
                else
                    dot_permapprenew_ht.Add(NED2, value);
            }
        }
        public string C_PermitNo3_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo3].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo3))
                    dot_permapprenew_ht[C_PermitNo3] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo3, value);
            }
        }
        public string C_PermitType3_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType3].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType3))
                    dot_permapprenew_ht[C_PermitType3] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType3, value);
            }
        }
        public string NED3_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED3].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED3))
                    dot_permapprenew_ht[NED3] = value;
                else
                    dot_permapprenew_ht.Add(NED3, value);
            }
        }
        public string C_PermitNo4_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo4].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo4))
                    dot_permapprenew_ht[C_PermitNo4] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo4, value);
            }
        }
        public string C_PermitType4_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType4].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType4))
                    dot_permapprenew_ht[C_PermitType4] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType4, value);
            }
        }
        public string NED4_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED4].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED4))
                    dot_permapprenew_ht[NED4] = value;
                else
                    dot_permapprenew_ht.Add(NED4, value);
            }
        }
        public string C_PermitNo5_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo5].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo5))
                    dot_permapprenew_ht[C_PermitNo5] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo5, value);
            }
        }
        public string C_PermitType5_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType5].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType5))
                    dot_permapprenew_ht[C_PermitType5] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType5, value);
            }
        }
        public string NED5_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED5].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED5))
                    dot_permapprenew_ht[NED5] = value;
                else
                    dot_permapprenew_ht.Add(NED5, value);
            }
        }
        public string C_PermitNo6_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo6].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo6))
                    dot_permapprenew_ht[C_PermitNo6] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo6, value);
            }
        }
        public string C_PermitType6_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType6].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType6))
                    dot_permapprenew_ht[C_PermitType6] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType6, value);
            }
        }
        public string NED6_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED6].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED6))
                    dot_permapprenew_ht[NED6] = value;
                else
                    dot_permapprenew_ht.Add(NED6, value);
            }
        }
        public string C_PermitNo7_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo7].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo7))
                    dot_permapprenew_ht[C_PermitNo7] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo7, value);
            }
        }
        public string C_PermitType7_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType7].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType7))
                    dot_permapprenew_ht[C_PermitType7] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType7, value);
            }
        }
        public string NED7_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED7].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED7))
                    dot_permapprenew_ht[NED7] = value;
                else
                    dot_permapprenew_ht.Add(NED7, value);
            }
        }
        public string C_PermitNo8_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo8].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo8))
                    dot_permapprenew_ht[C_PermitNo8] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo8, value);
            }
        }
        public string C_PermitType8_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType8].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType8))
                    dot_permapprenew_ht[C_PermitType8] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType8, value);
            }
        }
        public string NED8_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED8].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED8))
                    dot_permapprenew_ht[NED8] = value;
                else
                    dot_permapprenew_ht.Add(NED8, value);
            }
        }
        public string C_PermitNo9_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo9].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo9))
                    dot_permapprenew_ht[C_PermitNo9] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo9, value);
            }
        }
        public string C_PermitType9_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType9].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType9))
                    dot_permapprenew_ht[C_PermitType9] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType9, value);
            }
        }
        public string NED9_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED9].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED9))
                    dot_permapprenew_ht[NED9] = value;
                else
                    dot_permapprenew_ht.Add(NED9, value);
            }
        }
        public string C_PErmitNo10_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PErmitNo10].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PErmitNo10))
                    dot_permapprenew_ht[C_PErmitNo10] = value;
                else
                    dot_permapprenew_ht.Add(C_PErmitNo10, value);
            }
        }
        public string C_PermitType10_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType10].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType10))
                    dot_permapprenew_ht[C_PermitType10] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType10, value);
            }
        }
        public string NED10_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED10].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED10))
                    dot_permapprenew_ht[NED10] = value;
                else
                    dot_permapprenew_ht.Add(NED10, value);
            }
        }
        public string C_PermitNo11_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo11].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo11))
                    dot_permapprenew_ht[C_PermitNo11] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo11, value);
            }
        }
        public string C_PermitType11_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType11].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType11))
                    dot_permapprenew_ht[C_PermitType11] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType11, value);
            }
        }
        public string NED11_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED11].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED11))
                    dot_permapprenew_ht[NED11] = value;
                else
                    dot_permapprenew_ht.Add(NED11, value);
            }
        }
        public string C_PermitNo12_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitNo12].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitNo12))
                    dot_permapprenew_ht[C_PermitNo12] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitNo12, value);
            }
        }
        public string C_PermitType12_Pro
        {
            get
            {
                return dot_permapprenew_ht[C_PermitType12].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(C_PermitType12))
                    dot_permapprenew_ht[C_PermitType12] = value;
                else
                    dot_permapprenew_ht.Add(C_PermitType12, value);
            }
        }
        public string NED12_Pro
        {
            get
            {
                return dot_permapprenew_ht[NED12].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(NED12))
                    dot_permapprenew_ht[NED12] = value;
                else
                    dot_permapprenew_ht.Add(NED12, value);
            }
        }
        public string SubmittedBy_Pro
        {
            get
            {
                return dot_permapprenew_ht[SubmittedBy].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(SubmittedBy))
                    dot_permapprenew_ht[SubmittedBy] = value;
                else
                    dot_permapprenew_ht.Add(SubmittedBy, value);
            }
        }
        public string T4_Pro
        {
            get
            {
                return dot_permapprenew_ht[T4].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(T4))
                    dot_permapprenew_ht[T4] = value;
                else
                    dot_permapprenew_ht.Add(T4, value);
            }
        }
        public string T5_Pro
        {
            get
            {
                return dot_permapprenew_ht[T5].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(T5))
                    dot_permapprenew_ht[T5] = value;
                else
                    dot_permapprenew_ht.Add(T5, value);
            }
        }
        public string T6_Pro
        {
            get
            {
                return dot_permapprenew_ht[T6].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(T6))
                    dot_permapprenew_ht[T6] = value;
                else
                    dot_permapprenew_ht.Add(T6, value);
            }
        }
        public string D1_Pro
        {
            get
            {
                return dot_permapprenew_ht[D1].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(D1))
                    dot_permapprenew_ht[D1] = value;
                else
                    dot_permapprenew_ht.Add(D1, value);
            }
        }
        public string D2_Pro
        {
            get
            {
                return dot_permapprenew_ht[D2].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(D2))
                    dot_permapprenew_ht[D2] = value;
                else
                    dot_permapprenew_ht.Add(D2, value);
            }
        }
        public string D3_Pro
        {
            get
            {
                return dot_permapprenew_ht[D3].ToString();
            }
            set
            {
                if (dot_permapprenew_ht.ContainsKey(D3))
                    dot_permapprenew_ht[D3] = value;
                else
                    dot_permapprenew_ht.Add(D3, value);
            }
        }
        #endregion
        public void FillD_PermappRenewpdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_permapprenew_ht)
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
