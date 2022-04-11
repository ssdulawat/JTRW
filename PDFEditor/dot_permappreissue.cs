using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class dot_permappreissue
    {
        #region Global Variable
        private Hashtable dot_permappreissue_ht = new Hashtable();
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
        private const string Roadway = "Roadway";
        private const string Sidewalk = "Sidewalk";
        private const string DOB = "DOB#";
        private const string House_No = "House No";
        private const string OnStreet = "On Street";
        private const string StreetWorkOn = "Street Work On, If Different from Above";
        private const string CrossStreet1 = "Cross Street #1";
        private const string CrossStreet2 = "Cross Street #2";
        private const string Purpose = "Purpose";
        private const string Permit1 = "Permit #1";
        private const string PermitType1 = "Permit Type 1";
        private const string NSD1 = "New Start Date 1";
        private const string NED1 = "New End Date 1";
        private const string Permit2 = "Permit #2";
        private const string PermitType2 = "Permit Type 2";
        private const string NSD2 = "New Start Date 2";
        private const string NED2 = "New End Date 2";
        private const string Permit3 = "Permit #3";
        private const string PermitType3 = "Permit Type 3";
        private const string NSD3 = "New Start Date 3";
        private const string NED3 = "New End Date 3";
        private const string Permit4 = "Permit #4";
        private const string PermitType4 = "Permit Type 4";
        private const string NSD4 = "New Start Date 4";
        private const string NED4 = "New End Date 4";
        private const string Permit5 = "Permit #5";
        private const string PermitType5 = "Permit Type 5";
        private const string NSD5 = "New Start Date 5";
        private const string NED5 = "New End Date 5";
        private const string Permit6 = "Permit #6";
        private const string PermitType6 = "Permit Type 6";
        private const string NSD6 = "New Start Date 6";
        private const string NED6 = "New End Date 6";
        private const string Permit7 = "Permit #7";
        private const string PermitType7 = "Permit Type 7";
        private const string NSD7 = "New Start Date 7";
        private const string NED7 = "New End Date 7";
        private const string Permit8 = "Permit #8";
        private const string PermitType8 = "Permit Type 8";
        private const string NSD8 = "New Start Date 8";
        private const string NED8 = "New End Date 8";
        private const string Permit9 = "Permit #9";
        private const string PermitType9 = "Permit Type 9";
        private const string NSD9 = "New Start Date 9";
        private const string NED9 = "New End Date 9";
        private const string Permit10 = "Permit #10";
        private const string PermitType10 = "Permit Type 10";
        private const string NSD10 = "New Start Date 10";
        private const string NED10 = "New End Date 10";
        private const string Permit11 = "Permit #11";
        private const string PermitType11 = "Permit Type 11";
        private const string NSD11 = "New Start Date 11";
        private const string NED11 = "New End Date 11";
        private const string Permit12 = "Permit #12";
        private const string PermitType12 = "Permit Type 12";
        private const string NSD12 = "New Start Date 12";
        private const string NED12 = "New End Date 12";
        private const string Submittedby = "Submitted by";
        private const string Area_Code2 = "Area Code 2";
        private const string Tel22 = "Tel 22";
        private const string Tel23 = "Tel 23";
        private const string Month = "Month";
        private const string Day = "Day";
        private const string Year = "Year";

        #endregion
        #region Properties
        public string Permit_ID_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit_ID].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit_ID))
                    dot_permappreissue_ht[Permit_ID] = value;
                else
                    dot_permappreissue_ht.Add(Permit_ID, value);
            }
        }
        public string Permit_Name_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit_Name].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit_Name))
                    dot_permappreissue_ht[Permit_Name] = value;
                else
                    dot_permappreissue_ht.Add(Permit_Name, value);
            }
        }
        public string Address_Pro
        {
            get
            {
                return dot_permappreissue_ht[Address].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Address))
                    dot_permappreissue_ht[Address] = value;
                else
                    dot_permappreissue_ht.Add(Address, value);
            }
        }
        public string Area_Code_Pro
        {
            get
            {
                return dot_permappreissue_ht[Area_Code].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Area_Code))
                    dot_permappreissue_ht[Area_Code] = value;
                else
                    dot_permappreissue_ht.Add(Area_Code, value);
            }
        }
        public string Tel2_Pro
        {
            get
            {
                return dot_permappreissue_ht[Tel2].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Tel2))
                    dot_permappreissue_ht[Tel2] = value;
                else
                    dot_permappreissue_ht.Add(Tel2, value);
            }
        }
        public string Tel3_Pro
        {
            get
            {
                return dot_permappreissue_ht[Tel3].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Tel3))
                    dot_permappreissue_ht[Tel3] = value;
                else
                    dot_permappreissue_ht.Add(Tel3, value);
            }
        }
        public string Email_Pro
        {
            get
            {
                return dot_permappreissue_ht[Email].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Email))
                    dot_permappreissue_ht[Email] = value;
                else
                    dot_permappreissue_ht.Add(Email, value);
            }
        }
        public string MN_Pro
        {
            get
            {
                return dot_permappreissue_ht[MN].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(MN))
                    dot_permappreissue_ht[MN] = value;
                else
                    dot_permappreissue_ht.Add(MN, value);
            }
        }
        public string BK_Pro
        {
            get
            {
                return dot_permappreissue_ht[BK].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(BK))
                    dot_permappreissue_ht[BK] = value;
                else
                    dot_permappreissue_ht.Add(BK, value);
            }
        }
        public string QN_Pro
        {
            get
            {
                return dot_permappreissue_ht[QN].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(QN))
                    dot_permappreissue_ht[QN] = value;
                else
                    dot_permappreissue_ht.Add(QN, value);
            }
        }
        public string BX_Pro
        {
            get
            {
                return dot_permappreissue_ht[BX].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(BX))
                    dot_permappreissue_ht[BX] = value;
                else
                    dot_permappreissue_ht.Add(BX, value);
            }
        }
        public string SI_Pro
        {
            get
            {
                return dot_permappreissue_ht[SI].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(SI))
                    dot_permappreissue_ht[SI] = value;
                else
                    dot_permappreissue_ht.Add(SI, value);
            }
        }
        public string Engineering_Control_Pro
        {
            get
            {
                return dot_permappreissue_ht[Engineering_Control].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Engineering_Control))
                    dot_permappreissue_ht[Engineering_Control] = value;
                else
                    dot_permappreissue_ht.Add(Engineering_Control, value);
            }
        }
        public string Digit_Year_Pro
        {
            get
            {
                return dot_permappreissue_ht[Digit_Year].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Digit_Year))
                    dot_permappreissue_ht[Digit_Year] = value;
                else
                    dot_permappreissue_ht.Add(Digit_Year, value);
            }
        }
        public string File_No_Pro
        {
            get
            {
                return dot_permappreissue_ht[File_No].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(File_No))
                    dot_permappreissue_ht[File_No] = value;
                else
                    dot_permappreissue_ht.Add(File_No, value);
            }
        }
        public string Roadway_Pro
        {
            get
            {
                return dot_permappreissue_ht[Roadway].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Roadway))
                    dot_permappreissue_ht[Roadway] = value;
                else
                    dot_permappreissue_ht.Add(Roadway, value);
            }
        }
        public string Sidewalk_Pro
        {
            get
            {
                return dot_permappreissue_ht[Sidewalk].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Sidewalk))
                    dot_permappreissue_ht[Sidewalk] = value;
                else
                    dot_permappreissue_ht.Add(Sidewalk, value);
            }
        }
        public string DOB_Pro
        {
            get
            {
                return dot_permappreissue_ht[DOB].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(DOB))
                    dot_permappreissue_ht[DOB] = value;
                else
                    dot_permappreissue_ht.Add(DOB, value);
            }
        }
        public string House_No_Pro
        {
            get
            {
                return dot_permappreissue_ht[House_No].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(House_No))
                    dot_permappreissue_ht[House_No] = value;
                else
                    dot_permappreissue_ht.Add(House_No, value);
            }
        }
        public string OnStreet_Pro
        {
            get
            {
                return dot_permappreissue_ht[OnStreet].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(OnStreet))
                    dot_permappreissue_ht[OnStreet] = value;
                else
                    dot_permappreissue_ht.Add(OnStreet, value);
            }
        }
        public string StreetWorkOn_Pro
        {
            get
            {
                return dot_permappreissue_ht[StreetWorkOn].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(StreetWorkOn))
                    dot_permappreissue_ht[StreetWorkOn] = value;
                else
                    dot_permappreissue_ht.Add(StreetWorkOn, value);
            }
        }
        public string CrossStreet1_Pro
        {
            get
            {
                return dot_permappreissue_ht[CrossStreet1].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(CrossStreet1))
                    dot_permappreissue_ht[CrossStreet1] = value;
                else
                    dot_permappreissue_ht.Add(CrossStreet1, value);
            }
        }
        public string CrossStreet2_Pro
        {
            get
            {
                return dot_permappreissue_ht[CrossStreet2].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(CrossStreet2))
                    dot_permappreissue_ht[CrossStreet2] = value;
                else
                    dot_permappreissue_ht.Add(CrossStreet2, value);
            }
        }
        public string Purpose_Pro
        {
            get
            {
                return dot_permappreissue_ht[Purpose].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Purpose))
                    dot_permappreissue_ht[Purpose] = value;
                else
                    dot_permappreissue_ht.Add(Purpose, value);
            }
        }
        public string Permit1_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit1].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit1))
                    dot_permappreissue_ht[Permit1] = value;
                else
                    dot_permappreissue_ht.Add(Permit1, value);
            }
        }
        public string PermitType1_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType1].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType1))
                    dot_permappreissue_ht[PermitType1] = value;
                else
                    dot_permappreissue_ht.Add(PermitType1, value);
            }
        }
        public string NSD1_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD1].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD1))
                    dot_permappreissue_ht[NSD1] = value;
                else
                    dot_permappreissue_ht.Add(NSD1, value);
            }
        }
        public string NED1_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED1].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED1))
                    dot_permappreissue_ht[NED1] = value;
                else
                    dot_permappreissue_ht.Add(NED1, value);
            }
        }
        public string Permit2_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit2].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit2))
                    dot_permappreissue_ht[Permit2] = value;
                else
                    dot_permappreissue_ht.Add(Permit2, value);
            }
        }
        public string PermitType2_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType2].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType2))
                    dot_permappreissue_ht[PermitType2] = value;
                else
                    dot_permappreissue_ht.Add(PermitType2, value);
            }
        }
        public string NSD2_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD2].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD2))
                    dot_permappreissue_ht[NSD2] = value;
                else
                    dot_permappreissue_ht.Add(NSD2, value);
            }
        }
        public string NED2_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED2].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED2))
                    dot_permappreissue_ht[NED2] = value;
                else
                    dot_permappreissue_ht.Add(NED2, value);
            }
        }
        public string Permit3_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit3].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit3))
                    dot_permappreissue_ht[Permit3] = value;
                else
                    dot_permappreissue_ht.Add(Permit3, value);
            }
        }
        public string PermitType3_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType3].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType3))
                    dot_permappreissue_ht[PermitType3] = value;
                else
                    dot_permappreissue_ht.Add(PermitType3, value);
            }
        }
        public string NSD3_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD3].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD3))
                    dot_permappreissue_ht[NSD3] = value;
                else
                    dot_permappreissue_ht.Add(NSD3, value);
            }
        }
        public string NED3_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED3].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED3))
                    dot_permappreissue_ht[NED3] = value;
                else
                    dot_permappreissue_ht.Add(NED3, value);
            }
        }
        public string Permit4_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit4].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit4))
                    dot_permappreissue_ht[Permit4] = value;
                else
                    dot_permappreissue_ht.Add(Permit4, value);
            }
        }
        public string PermitType4_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType4].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType4))
                    dot_permappreissue_ht[PermitType4] = value;
                else
                    dot_permappreissue_ht.Add(PermitType4, value);
            }
        }
        public string NSD4_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD4].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD4))
                    dot_permappreissue_ht[NSD4] = value;
                else
                    dot_permappreissue_ht.Add(NSD4, value);
            }
        }
        public string NED4_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED4].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED4))
                    dot_permappreissue_ht[NED4] = value;
                else
                    dot_permappreissue_ht.Add(NED4, value);
            }
        }
        public string Permit5_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit5].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit5))
                    dot_permappreissue_ht[Permit5] = value;
                else
                    dot_permappreissue_ht.Add(Permit5, value);
            }
        }
        public string PermitType5_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType5].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType5))
                    dot_permappreissue_ht[PermitType5] = value;
                else
                    dot_permappreissue_ht.Add(PermitType5, value);
            }
        }
        public string NSD5_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD5].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD5))
                    dot_permappreissue_ht[NSD5] = value;
                else
                    dot_permappreissue_ht.Add(NSD5, value);
            }
        }
        public string NED5_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED5].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED5))
                    dot_permappreissue_ht[NED5] = value;
                else
                    dot_permappreissue_ht.Add(NED5, value);
            }
        }
        public string Permit6_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit6].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit6))
                    dot_permappreissue_ht[Permit6] = value;
                else
                    dot_permappreissue_ht.Add(Permit6, value);
            }
        }
        public string PermitType6_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType6].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType6))
                    dot_permappreissue_ht[PermitType6] = value;
                else
                    dot_permappreissue_ht.Add(PermitType6, value);
            }
        }
        public string NSD6_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD6].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD6))
                    dot_permappreissue_ht[NSD6] = value;
                else
                    dot_permappreissue_ht.Add(NSD6, value);
            }
        }
        public string NED6_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED6].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED6))
                    dot_permappreissue_ht[NED6] = value;
                else
                    dot_permappreissue_ht.Add(NED6, value);
            }
        }
        public string Permit7_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit7].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit7))
                    dot_permappreissue_ht[Permit7] = value;
                else
                    dot_permappreissue_ht.Add(Permit7, value);
            }
        }
        public string PermitType7_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType7].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType7))
                    dot_permappreissue_ht[PermitType7] = value;
                else
                    dot_permappreissue_ht.Add(PermitType7, value);
            }
        }
        public string NSD7_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD7].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD7))
                    dot_permappreissue_ht[NSD7] = value;
                else
                    dot_permappreissue_ht.Add(NSD7, value);
            }
        }
        public string NED7_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED7].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED7))
                    dot_permappreissue_ht[NED7] = value;
                else
                    dot_permappreissue_ht.Add(NED7, value);
            }
        }
        public string Permit8_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit8].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit8))
                    dot_permappreissue_ht[Permit8] = value;
                else
                    dot_permappreissue_ht.Add(Permit8, value);
            }
        }
        public string PermitType8_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType8].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType8))
                    dot_permappreissue_ht[PermitType8] = value;
                else
                    dot_permappreissue_ht.Add(PermitType8, value);
            }
        }
        public string NSD8_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD8].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD8))
                    dot_permappreissue_ht[NSD8] = value;
                else
                    dot_permappreissue_ht.Add(NSD8, value);
            }
        }
        public string NED8_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED8].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED8))
                    dot_permappreissue_ht[NED8] = value;
                else
                    dot_permappreissue_ht.Add(NED8, value);
            }
        }
        public string Permit9_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit9].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit9))
                    dot_permappreissue_ht[Permit9] = value;
                else
                    dot_permappreissue_ht.Add(Permit9, value);
            }
        }
        public string PermitType9_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType9].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType9))
                    dot_permappreissue_ht[PermitType9] = value;
                else
                    dot_permappreissue_ht.Add(PermitType9, value);
            }
        }
        public string NSD9_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD9].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD9))
                    dot_permappreissue_ht[NSD9] = value;
                else
                    dot_permappreissue_ht.Add(NSD9, value);
            }
        }
        public string NED9_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED9].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED9))
                    dot_permappreissue_ht[NED9] = value;
                else
                    dot_permappreissue_ht.Add(NED9, value);
            }
        }
        public string Permit10_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit10].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit10))
                    dot_permappreissue_ht[Permit10] = value;
                else
                    dot_permappreissue_ht.Add(Permit10, value);
            }
        }
        public string PermitType10_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType10].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType10))
                    dot_permappreissue_ht[PermitType10] = value;
                else
                    dot_permappreissue_ht.Add(PermitType10, value);
            }
        }
        public string NSD10_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD10].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD10))
                    dot_permappreissue_ht[NSD10] = value;
                else
                    dot_permappreissue_ht.Add(NSD10, value);
            }
        }
        public string NED10_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED10].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED10))
                    dot_permappreissue_ht[NED10] = value;
                else
                    dot_permappreissue_ht.Add(NED10, value);
            }
        }
        public string Permit11_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit11].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit11))
                    dot_permappreissue_ht[Permit11] = value;
                else
                    dot_permappreissue_ht.Add(Permit11, value);
            }
        }
        public string PermitType11_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType11].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType11))
                    dot_permappreissue_ht[PermitType11] = value;
                else
                    dot_permappreissue_ht.Add(PermitType11, value);
            }
        }
        public string NSD11_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD11].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD11))
                    dot_permappreissue_ht[NSD11] = value;
                else
                    dot_permappreissue_ht.Add(NSD11, value);
            }
        }
        public string NED11_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED11].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED11))
                    dot_permappreissue_ht[NED11] = value;
                else
                    dot_permappreissue_ht.Add(NED11, value);
            }
        }
        public string Permit12_Pro
        {
            get
            {
                return dot_permappreissue_ht[Permit12].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Permit12))
                    dot_permappreissue_ht[Permit12] = value;
                else
                    dot_permappreissue_ht.Add(Permit12, value);
            }
        }
        public string PermitType12_Pro
        {
            get
            {
                return dot_permappreissue_ht[PermitType12].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(PermitType12))
                    dot_permappreissue_ht[PermitType12] = value;
                else
                    dot_permappreissue_ht.Add(PermitType12, value);
            }
        }
        public string NSD12_Pro
        {
            get
            {
                return dot_permappreissue_ht[NSD12].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NSD12))
                    dot_permappreissue_ht[NSD12] = value;
                else
                    dot_permappreissue_ht.Add(NSD12, value);
            }
        }
        public string NED12_Pro
        {
            get
            {
                return dot_permappreissue_ht[NED12].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(NED12))
                    dot_permappreissue_ht[NED12] = value;
                else
                    dot_permappreissue_ht.Add(NED12, value);
            }
        }
        public string Submittedby_Pro
        {
            get
            {
                return dot_permappreissue_ht[Submittedby].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Submittedby))
                    dot_permappreissue_ht[Submittedby] = value;
                else
                    dot_permappreissue_ht.Add(Submittedby, value);
            }
        }
        public string Area_Code2_Pro
        {
            get
            {
                return dot_permappreissue_ht[Area_Code2].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Area_Code2))
                    dot_permappreissue_ht[Area_Code2] = value;
                else
                    dot_permappreissue_ht.Add(Area_Code2, value);
            }
        }
        public string Tel22_Pro
        {
            get
            {
                return dot_permappreissue_ht[Tel22].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Tel22))
                    dot_permappreissue_ht[Tel22] = value;
                else
                    dot_permappreissue_ht.Add(Tel22, value);
            }
        }
        public string Tel23_Pro
        {
            get
            {
                return dot_permappreissue_ht[Tel23].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Tel23))
                    dot_permappreissue_ht[Tel23] = value;
                else
                    dot_permappreissue_ht.Add(Tel23, value);
            }
        }
        public string Month_Pro
        {
            get
            {
                return dot_permappreissue_ht[Month].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Month))
                    dot_permappreissue_ht[Month] = value;
                else
                    dot_permappreissue_ht.Add(Month, value);
            }
        }
        public string Day_Pro
        {
            get
            {
                return dot_permappreissue_ht[Day].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Day))
                    dot_permappreissue_ht[Day] = value;
                else
                    dot_permappreissue_ht.Add(Day, value);
            }
        }
        public string Year_Pro
        {
            get
            {
                return dot_permappreissue_ht[Year].ToString();
            }
            set
            {
                if (dot_permappreissue_ht.ContainsKey(Year))
                    dot_permappreissue_ht[Year] = value;
                else
                    dot_permappreissue_ht.Add(Year, value);
            }
        }
        #endregion
        public void FillD_PermappIssuepdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_permappreissue_ht)
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