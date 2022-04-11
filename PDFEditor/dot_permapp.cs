using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class dot_permapp
    {
        #region Global Variable
        private Hashtable dot_permapp_ht = new Hashtable();
        #endregion
        #region Constant Variable
        private const string AID = "Permittee ID";
        private const string A_Pemit_Name = "Permittee Name";
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
        private const string O2 = "2 Digit Year";
        private const string O3 = "File Number";
        private const string B_Roadway = "Roadway";
        private const string B_Sidewalk = "Sidewalk";
        private const string B_DOB = "DOB#";
        private const string B_HouseNo = "House No";
        private const string B_OnStreet = "On Street";
        private const string B_StreetWorkOn = "Street Work On, If Different From Above";
        private const string B_CrossStreet1 = "Cross Street #1";
        private const string B_CrossStreet2 = "Cross Street #2";
        private const string B_Purpose = "Purpose";
        private const string B_NoOfOpening = "Number of Openings";
        private const string B_AreaSize = "Area Size";
        private const string B_FrontageLength = "Frontage Length";
        private const string D1 = "Work Start Month";
        private const string D2 = "Work Start Day";
        private const string D3 = "Work Start Year";
        private const string D4 = "Work End Month";
        private const string D5 = "Work End Day";
        private const string D6 = "Work End Year";
        private const string A0100 = "0100";
        private const string B0111 = "0111";
        private const string C0113 = "0113";
        private const string D0114 = "0114";
        private const string E0115 = "0115";
        private const string F0116 = "0116";
        private const string G0117 = "0117";
        private const string H0118 = "0118";
        private const string I0119 = "0119";
        private const string J0126 = "0126";
        private const string K0127 = "0127";
        private const string L0132 = "0132";
        private const string M0401 = "0401";
        private const string N0402 = "0402";
        private const string O0403 = "0403";
        private const string P0405 = "0405";
        private const string Q0201 = "0201";
        private const string R0202 = "0202";
        private const string S0203 = "0203";
        private const string T0204 = "0204";
        private const string U0205 = "0205";
        private const string V0208 = "0208";
        private const string W0211 = "0211";
        private const string X0214 = "0214";
        private const string Y0215 = "0215";
        private const string Z0221 = "0221";
        private const string AA0701 = "0701";
        private const string BB0702 = "0702";
        private const string CC0703 = "0703";
        private const string DD0704 = "0704";
        private const string EE0705 = "0705";
        private const string Other = "Other";
        private const string Other_Type_Permit = "Other Type permit";
        private const string OS = "OS";
        private const string CS1 = "CS 1";
        private const string CS2 = "CS 2";
        private const string Dim1 = "Dim 1";
        private const string Dim2 = "Dim 2";
        private const string Dim3 = "Dim 3";
        private const string Dim4 = "Dim 4";
        private const string Dim5 = "Dim 5";
        private const string North1 = "North 1";
        private const string North2 = "North 2";
        private const string North3 = "North 3";
        private const string North4 = "North 4";
        private const string SubmittedBy = "Submitted by";
        private const string Area_Code2 = "Area Code 2";
        private const string Tel22 = "Tel 22";
        private const string Tel32 = "Tel 32";
        private const string Month = "Month";
        private const string Day = "Day";
        private const string Year = "Year";
        #endregion
        #region Properties
        public string AID_Pro
        {
            get
            {
                return dot_permapp_ht[AID].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(AID))
                    dot_permapp_ht[AID] = value;
                else
                    dot_permapp_ht.Add(AID, value);
            }
        }
        public string A_Pemit_Name_Pro
        {
            get
            {
                return dot_permapp_ht[A_Pemit_Name].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(A_Pemit_Name))
                    dot_permapp_ht[A_Pemit_Name] = value;
                else
                    dot_permapp_ht.Add(A_Pemit_Name, value);
            }
        }
        public string A_Address_Pro
        {
            get
            {
                return dot_permapp_ht[A_Address].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(A_Address))
                    dot_permapp_ht[A_Address] = value;
                else
                    dot_permapp_ht.Add(A_Address, value);
            }
        }
        public string T1_Pro
        {
            get
            {
                return dot_permapp_ht[T1].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(T1))
                    dot_permapp_ht[T1] = value;
                else
                    dot_permapp_ht.Add(T1, value);
            }
        }
        public string T2_Pro
        {
            get
            {
                return dot_permapp_ht[T2].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(T2))
                    dot_permapp_ht[T2] = value;
                else
                    dot_permapp_ht.Add(T2, value);
            }
        }
        public string T3_Pro
        {
            get
            {
                return dot_permapp_ht[T3].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(T3))
                    dot_permapp_ht[T3] = value;
                else
                    dot_permapp_ht.Add(T3, value);
            }
        }
        public string A_Email_Pro
        {
            get
            {
                return dot_permapp_ht[A_Email].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(A_Email))
                    dot_permapp_ht[A_Email] = value;
                else
                    dot_permapp_ht.Add(A_Email, value);
            }
        }
        public string MN_Pro
        {
            get
            {
                return dot_permapp_ht[MN].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(MN))
                    dot_permapp_ht[MN] = value;
                else
                    dot_permapp_ht.Add(MN, value);
            }
        }
        public string BK_Pro
        {
            get
            {
                return dot_permapp_ht[BK].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(BK))
                    dot_permapp_ht[BK] = value;
                else
                    dot_permapp_ht.Add(BK, value);
            }
        }
        public string QN_Pro
        {
            get
            {
                return dot_permapp_ht[QN].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(QN))
                    dot_permapp_ht[QN] = value;
                else
                    dot_permapp_ht.Add(QN, value);
            }
        }
        public string BX_Pro
        {
            get
            {
                return dot_permapp_ht[BX].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(BX))
                    dot_permapp_ht[BX] = value;
                else
                    dot_permapp_ht.Add(BX, value);
            }
        }
        public string SI_Pro
        {
            get
            {
                return dot_permapp_ht[SI].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(SI))
                    dot_permapp_ht[SI] = value;
                else
                    dot_permapp_ht.Add(SI, value);
            }
        }
        public string O1_Pro
        {
            get
            {
                return dot_permapp_ht[O1].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(O1))
                    dot_permapp_ht[O1] = value;
                else
                    dot_permapp_ht.Add(O1, value);
            }
        }
        public string O2_Pro
        {
            get
            {
                return dot_permapp_ht[O2].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(O2))
                    dot_permapp_ht[O2] = value;
                else
                    dot_permapp_ht.Add(O2, value);
            }
        }
        public string O3_Pro
        {
            get
            {
                return dot_permapp_ht[O3].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(O3))
                    dot_permapp_ht[O3] = value;
                else
                    dot_permapp_ht.Add(O3, value);
            }
        }
        public string B_Roadway_Pro
        {
            get
            {
                return dot_permapp_ht[B_Roadway].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_Roadway))
                    dot_permapp_ht[B_Roadway] = value;
                else
                    dot_permapp_ht.Add(B_Roadway, value);
            }
        }
        public string B_Sidewalk_Pro
        {
            get
            {
                return dot_permapp_ht[B_Sidewalk].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_Sidewalk))
                    dot_permapp_ht[B_Sidewalk] = value;
                else
                    dot_permapp_ht.Add(B_Sidewalk, value);
            }
        }
        public string B_DOB_Pro
        {
            get
            {
                return dot_permapp_ht[B_DOB].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_DOB))
                    dot_permapp_ht[B_DOB] = value;
                else
                    dot_permapp_ht.Add(B_DOB, value);
            }
        }
        public string B_HouseNo_Pro
        {
            get
            {
                return dot_permapp_ht[B_HouseNo].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_HouseNo))
                    dot_permapp_ht[B_HouseNo] = value;
                else
                    dot_permapp_ht.Add(B_HouseNo, value);
            }
        }
        public string B_OnStreet_Pro
        {
            get
            {
                return dot_permapp_ht[B_OnStreet].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_OnStreet))
                    dot_permapp_ht[B_OnStreet] = value;
                else
                    dot_permapp_ht.Add(B_OnStreet, value);
            }
        }
        public string B_StreetWorkOn_Pro
        {
            get
            {
                return dot_permapp_ht[B_StreetWorkOn].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_StreetWorkOn))
                    dot_permapp_ht[B_StreetWorkOn] = value;
                else
                    dot_permapp_ht.Add(B_StreetWorkOn, value);
            }
        }
        public string B_CrossStreet1_Pro
        {
            get
            {
                return dot_permapp_ht[B_CrossStreet1].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_CrossStreet1))
                    dot_permapp_ht[B_CrossStreet1] = value;
                else
                    dot_permapp_ht.Add(B_CrossStreet1, value);
            }
        }
        public string B_CrossStreet2_Pro
        {
            get
            {
                return dot_permapp_ht[B_CrossStreet2].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_CrossStreet2))
                    dot_permapp_ht[B_CrossStreet2] = value;
                else
                    dot_permapp_ht.Add(B_CrossStreet2, value);
            }
        }
        public string B_Purpose_Pro
        {
            get
            {
                return dot_permapp_ht[B_Purpose].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_Purpose))
                    dot_permapp_ht[B_Purpose] = value;
                else
                    dot_permapp_ht.Add(B_Purpose, value);
            }
        }
        public string B_NoOfOpening_Pro
        {
            get
            {
                return dot_permapp_ht[B_NoOfOpening].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_NoOfOpening))
                    dot_permapp_ht[B_NoOfOpening] = value;
                else
                    dot_permapp_ht.Add(B_NoOfOpening, value);
            }
        }
        public string B_AreaSize_Pro
        {
            get
            {
                return dot_permapp_ht[B_AreaSize].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_AreaSize))
                    dot_permapp_ht[B_AreaSize] = value;
                else
                    dot_permapp_ht.Add(B_AreaSize, value);
            }
        }
        public string B_FrontageLength_Pro
        {
            get
            {
                return dot_permapp_ht[B_FrontageLength].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B_FrontageLength))
                    dot_permapp_ht[B_FrontageLength] = value;
                else
                    dot_permapp_ht.Add(B_FrontageLength, value);
            }
        }
        public string D1_Pro
        {
            get
            {
                return dot_permapp_ht[D1].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(D1))
                    dot_permapp_ht[D1] = value;
                else
                    dot_permapp_ht.Add(D1, value);
            }
        }
        public string D2_Pro
        {
            get
            {
                return dot_permapp_ht[D2].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(D2))
                    dot_permapp_ht[D2] = value;
                else
                    dot_permapp_ht.Add(D2, value);
            }
        }
        public string D3_Pro
        {
            get
            {
                return dot_permapp_ht[D3].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(D3))
                    dot_permapp_ht[D3] = value;
                else
                    dot_permapp_ht.Add(D3, value);
            }
        }
        public string D4_Pro
        {
            get
            {
                return dot_permapp_ht[D4].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(D4))
                    dot_permapp_ht[D4] = value;
                else
                    dot_permapp_ht.Add(D4, value);
            }
        }
        public string D5_Pro
        {
            get
            {
                return dot_permapp_ht[D5].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(D5))
                    dot_permapp_ht[D5] = value;
                else
                    dot_permapp_ht.Add(D5, value);
            }
        }
        public string D6_Pro
        {
            get
            {
                return dot_permapp_ht[D6].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(D6))
                    dot_permapp_ht[D6] = value;
                else
                    dot_permapp_ht.Add(D6, value);
            }
        }
        public string A0100_Pro
        {
            get
            {
                return dot_permapp_ht[A0100].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(A0100))
                    dot_permapp_ht[A0100] = value;
                else
                    dot_permapp_ht.Add(A0100, value);
            }
        }
        public string B0111_Pro
        {
            get
            {
                return dot_permapp_ht[B0111].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(B0111))
                    dot_permapp_ht[B0111] = value;
                else
                    dot_permapp_ht.Add(B0111, value);
            }
        }
        public string C0113_Pro
        {
            get
            {
                return dot_permapp_ht[C0113].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(C0113))
                    dot_permapp_ht[C0113] = value;
                else
                    dot_permapp_ht.Add(C0113, value);
            }
        }
        public string D0114_Pro
        {
            get
            {
                return dot_permapp_ht[D0114].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(D0114))
                    dot_permapp_ht[D0114] = value;
                else
                    dot_permapp_ht.Add(D0114, value);
            }
        }
        public string E0115_Pro
        {
            get
            {
                return dot_permapp_ht[E0115].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(E0115))
                    dot_permapp_ht[E0115] = value;
                else
                    dot_permapp_ht.Add(E0115, value);
            }
        }
        public string F0116_Pro
        {
            get
            {
                return dot_permapp_ht[F0116].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(F0116))
                    dot_permapp_ht[F0116] = value;
                else
                    dot_permapp_ht.Add(F0116, value);
            }
        }
        public string G0117_Pro
        {
            get
            {
                return dot_permapp_ht[G0117].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(G0117))
                    dot_permapp_ht[G0117] = value;
                else
                    dot_permapp_ht.Add(G0117, value);
            }
        }
        public string H0118_Pro
        {
            get
            {
                return dot_permapp_ht[H0118].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(H0118))
                    dot_permapp_ht[H0118] = value;
                else
                    dot_permapp_ht.Add(H0118, value);
            }
        }
        public string I0119_Pro
        {
            get
            {
                return dot_permapp_ht[I0119].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(I0119))
                    dot_permapp_ht[I0119] = value;
                else
                    dot_permapp_ht.Add(I0119, value);
            }
        }
        public string J0126_Pro
        {
            get
            {
                return dot_permapp_ht[J0126].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(J0126))
                    dot_permapp_ht[J0126] = value;
                else
                    dot_permapp_ht.Add(J0126, value);
            }
        }
        public string K0127_Pro
        {
            get
            {
                return dot_permapp_ht[K0127].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(K0127))
                    dot_permapp_ht[K0127] = value;
                else
                    dot_permapp_ht.Add(K0127, value);
            }
        }
        public string L0132_Pro
        {
            get
            {
                return dot_permapp_ht[L0132].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(L0132))
                    dot_permapp_ht[L0132] = value;
                else
                    dot_permapp_ht.Add(L0132, value);
            }
        }
        public string M0401_Pro
        {
            get
            {
                return dot_permapp_ht[M0401].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(M0401))
                    dot_permapp_ht[M0401] = value;
                else
                    dot_permapp_ht.Add(M0401, value);
            }
        }
        public string N0402_Pro
        {
            get
            {
                return dot_permapp_ht[N0402].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(N0402))
                    dot_permapp_ht[N0402] = value;
                else
                    dot_permapp_ht.Add(N0402, value);
            }
        }
        public string O0403_Pro
        {
            get
            {
                return dot_permapp_ht[O0403].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(O0403))
                    dot_permapp_ht[O0403] = value;
                else
                    dot_permapp_ht.Add(O0403, value);
            }
        }
        public string P0405_Pro
        {
            get
            {
                return dot_permapp_ht[P0405].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(P0405))
                    dot_permapp_ht[P0405] = value;
                else
                    dot_permapp_ht.Add(P0405, value);
            }
        }
        public string Q0201_Pro
        {
            get
            {
                return dot_permapp_ht[Q0201].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Q0201))
                    dot_permapp_ht[Q0201] = value;
                else
                    dot_permapp_ht.Add(Q0201, value);
            }
        }
        public string R0202_Pro
        {
            get
            {
                return dot_permapp_ht[R0202].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(R0202))
                    dot_permapp_ht[R0202] = value;
                else
                    dot_permapp_ht.Add(R0202, value);
            }
        }
        public string S0203_Pro
        {
            get
            {
                return dot_permapp_ht[S0203].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(S0203))
                    dot_permapp_ht[S0203] = value;
                else
                    dot_permapp_ht.Add(S0203, value);
            }
        }
        public string T0204_Pro
        {
            get
            {
                return dot_permapp_ht[T0204].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(T0204))
                    dot_permapp_ht[T0204] = value;
                else
                    dot_permapp_ht.Add(T0204, value);
            }
        }
        public string U0205_Pro
        {
            get
            {
                return dot_permapp_ht[U0205].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(U0205))
                    dot_permapp_ht[U0205] = value;
                else
                    dot_permapp_ht.Add(U0205, value);
            }
        }
        public string V0208_Pro
        {
            get
            {
                return dot_permapp_ht[V0208].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(V0208))
                    dot_permapp_ht[V0208] = value;
                else
                    dot_permapp_ht.Add(V0208, value);
            }
        }
        public string W0211_Pro
        {
            get
            {
                return dot_permapp_ht[W0211].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(W0211))
                    dot_permapp_ht[W0211] = value;
                else
                    dot_permapp_ht.Add(W0211, value);
            }
        }
        public string X0214_Pro
        {
            get
            {
                return dot_permapp_ht[X0214].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(X0214))
                    dot_permapp_ht[X0214] = value;
                else
                    dot_permapp_ht.Add(X0214, value);
            }
        }
        public string Y0215_Pro
        {
            get
            {
                return dot_permapp_ht[Y0215].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Y0215))
                    dot_permapp_ht[Y0215] = value;
                else
                    dot_permapp_ht.Add(Y0215, value);
            }
        }
        public string Z0221_Pro
        {
            get
            {
                return dot_permapp_ht[Z0221].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Z0221))
                    dot_permapp_ht[Z0221] = value;
                else
                    dot_permapp_ht.Add(Z0221, value);
            }
        }
        public string AA0701_Pro
        {
            get
            {
                return dot_permapp_ht[AA0701].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(AA0701))
                    dot_permapp_ht[AA0701] = value;
                else
                    dot_permapp_ht.Add(AA0701, value);
            }
        }
        public string BB0702_Pro
        {
            get
            {
                return dot_permapp_ht[BB0702].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(BB0702))
                    dot_permapp_ht[BB0702] = value;
                else
                    dot_permapp_ht.Add(BB0702, value);
            }
        }
        public string CC0703_Pro
        {
            get
            {
                return dot_permapp_ht[CC0703].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(CC0703))
                    dot_permapp_ht[CC0703] = value;
                else
                    dot_permapp_ht.Add(CC0703, value);
            }
        }
        public string DD0704_Pro
        {
            get
            {
                return dot_permapp_ht[DD0704].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(DD0704))
                    dot_permapp_ht[DD0704] = value;
                else
                    dot_permapp_ht.Add(DD0704, value);
            }
        }
        public string EE0705_Pro
        {
            get
            {
                return dot_permapp_ht[EE0705].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(EE0705))
                    dot_permapp_ht[EE0705] = value;
                else
                    dot_permapp_ht.Add(EE0705, value);
            }
        }
        public string Other_Pro
        {
            get
            {
                return dot_permapp_ht[Other].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Other))
                    dot_permapp_ht[Other] = value;
                else
                    dot_permapp_ht.Add(Other, value);
            }
        }
        public string Other_Type_Permit_Pro
        {
            get
            {
                return dot_permapp_ht[Other_Type_Permit].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Other_Type_Permit))
                    dot_permapp_ht[Other_Type_Permit] = value;
                else
                    dot_permapp_ht.Add(Other_Type_Permit, value);
            }
        }
        public string OS_Pro
        {
            get
            {
                return dot_permapp_ht[OS].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(OS))
                    dot_permapp_ht[OS] = value;
                else
                    dot_permapp_ht.Add(OS, value);
            }
        }
        public string CS1_Pro
        {
            get
            {
                return dot_permapp_ht[CS1].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(CS1))
                    dot_permapp_ht[CS1] = value;
                else
                    dot_permapp_ht.Add(CS1, value);
            }
        }
        public string CS2_Pro
        {
            get
            {
                return dot_permapp_ht[CS2].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(CS2))
                    dot_permapp_ht[CS2] = value;
                else
                    dot_permapp_ht.Add(CS2, value);
            }
        }
        public string Dim1_Pro
        {
            get
            {
                return dot_permapp_ht[Dim1].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Dim1))
                    dot_permapp_ht[Dim1] = value;
                else
                    dot_permapp_ht.Add(Dim1, value);
            }
        }
        public string Dim2_Pro
        {
            get
            {
                return dot_permapp_ht[Dim2].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Dim2))
                    dot_permapp_ht[Dim2] = value;
                else
                    dot_permapp_ht.Add(Dim2, value);
            }
        }
        public string Dim3_Pro
        {
            get
            {
                return dot_permapp_ht[Dim3].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Dim3))
                    dot_permapp_ht[Dim3] = value;
                else
                    dot_permapp_ht.Add(Dim3, value);
            }
        }
        public string Dim4_Pro
        {
            get
            {
                return dot_permapp_ht[Dim4].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Dim4))
                    dot_permapp_ht[Dim4] = value;
                else
                    dot_permapp_ht.Add(Dim4, value);
            }
        }
        public string Dim5_Pro
        {
            get
            {
                return dot_permapp_ht[Dim5].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Dim5))
                    dot_permapp_ht[Dim5] = value;
                else
                    dot_permapp_ht.Add(Dim5, value);
            }
        }
        public string North1_Pro
        {
            get
            {
                return dot_permapp_ht[North1].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(North1))
                    dot_permapp_ht[North1] = value;
                else
                    dot_permapp_ht.Add(North1, value);
            }
        }
        public string North2_Pro
        {
            get
            {
                return dot_permapp_ht[North2].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(North2))
                    dot_permapp_ht[North2] = value;
                else
                    dot_permapp_ht.Add(North2, value);
            }
        }
        public string North3_Pro
        {
            get
            {
                return dot_permapp_ht[North3].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(North3))
                    dot_permapp_ht[North3] = value;
                else
                    dot_permapp_ht.Add(North3, value);
            }
        }
        public string North4_Pro
        {
            get
            {
                return dot_permapp_ht[North4].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(North4))
                    dot_permapp_ht[North4] = value;
                else
                    dot_permapp_ht.Add(North4, value);
            }
        }
        public string SubmittedBy_Pro
        {
            get
            {
                return dot_permapp_ht[SubmittedBy].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(SubmittedBy))
                    dot_permapp_ht[SubmittedBy] = value;
                else
                    dot_permapp_ht.Add(SubmittedBy, value);
            }
        }
        public string Area_Code2_Pro
        {
            get
            {
                return dot_permapp_ht[Area_Code2].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Area_Code2))
                    dot_permapp_ht[Area_Code2] = value;
                else
                    dot_permapp_ht.Add(Area_Code2, value);
            }
        }
        public string Tel22_Pro
        {
            get
            {
                return dot_permapp_ht[Tel22].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Tel22))
                    dot_permapp_ht[Tel22] = value;
                else
                    dot_permapp_ht.Add(Tel22, value);
            }
        }
        public string Tel32_Pro
        {
            get
            {
                return dot_permapp_ht[Tel32].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Tel32))
                    dot_permapp_ht[Tel32] = value;
                else
                    dot_permapp_ht.Add(Tel32, value);
            }
        }
        public string Month_Pro
        {
            get
            {
                return dot_permapp_ht[Month].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Month))
                    dot_permapp_ht[Month] = value;
                else
                    dot_permapp_ht.Add(Month, value);
            }
        }
        public string Day_Pro
        {
            get
            {
                return dot_permapp_ht[Day].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Day))
                    dot_permapp_ht[Day] = value;
                else
                    dot_permapp_ht.Add(Day, value);
            }
        }
        public string Year_Pro
        {
            get
            {
                return dot_permapp_ht[Year].ToString();
            }
            set
            {
                if (dot_permapp_ht.ContainsKey(Year))
                    dot_permapp_ht[Year] = value;
                else
                    dot_permapp_ht.Add(Year, value);
            }
        }
        #endregion
        public void FillD_PermapppdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_permapp_ht)
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