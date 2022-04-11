using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace PDFEditor
{
public class dot_regapp
    {
        #region Global Variable
        private Hashtable dot_regapp_ht = new Hashtable();
        #endregion
        #region Constant
        private const string A_Name = "Name";
        private const string A_AKA = "AKA";
        private const string TIDNo = "Tax ID / Social Security No";
        private const string A_Address = "Address";
        private const string A_CIty = "City";
        private const string A_STate = "State";
        private const string A_Zip = "Zip Code";
        private const string T1 = "Area Code";
        private const string T2 = "Tel 2";
        private const string T3 = "Tel 3";
        private const string Fax1 = "Fax Area Code";
        private const string Fax2 = "Fax 2";
        private const string Fax3 = "Fax 3";
        private const string T4 = "24hr Area Code";
        private const string T5 = "24hr 2";
        private const string T6 = "24hr 3";
        private const string A_Email = "Email";
        private const string B_CunsumerAffairs = "Consumer Affairs License No";
        private const string B_NameOfCompanyLicense1 = "Consumer Affairs Name";
        private const string B_SignHanger = "Sign Hanger License No";
        private const string B_NameOfCompanyLicense2 = "Sign Hanger Name";
        private const string B_MasterRigger = "Master Rigger License No";
        private const string B_NameOfCompanyLicense3 = "Master Rigger Name";
        private const string B_Plumber = "Plumbers License No";
        private const string B_NameOfCompanyLicense4 = "Plumbers Name";
        private const string General_Contractor = "General Contractor";
        private const string Govt_Contractor = "Government Contractor";
        private const string Authority_Contractor = "Authority Contractor";
        private const string Sidewalk_Contractor = "Sidewalk Contractor";
        private const string Crane = "Crane";
        private const string CommercialRefuse = "Commercial Refuse Container";
        private const string C_BICLicense = "BIC License / Registration No";
        private const string Other = "Other";
        private const string C_Identify = "Other Category";
        private const string Manhattan = "Manhattan";
        private const string Brooklyn = "Brooklyn";
        private const string Queens = "Queens";
        private const string Bronx = "Bronx";
        private const string Staten_Island = "Staten Island";
        private const string E_Name1 = "Authorized Rep 1";
        private const string E_Affiliation1 = "Affiliation 1";
        private const string Telephone1 = "Telephone 1";
        private const string E_Name2 = "Authorized Rep 2";
        private const string E_Affiliation2 = "Affiliation 2";
        private const string Telephone2 = "Telephone 2";
        private const string E_Name3 = "Authorized Rep 3";
        private const string E_Affiliation3 = "Affiliation 3";
        private const string Telephone3 = "Telephone 3";
        private const string E_Name4 = "Authorized Rep 4";
        private const string E_Affiliation4 = "Affiliation 4";
        private const string Telephone4 = "Telephone 4";
        private const string E_Name5 = "Authorized Rep 5";
        private const string E_Affiliation5 = "Affiliation 5";
        private const string Telephone5 = "Telephone 5";
        private const string F_Name1 = "Company Officer 1";
        private const string Title1 = "Company Officer 1 Title";
        private const string F_Name2 = "Company Officer 2";
        private const string Title2 = "Company Officer 2 Title";
        private const string F_Name3 = "Company Officer 3";
        private const string Title3 = "Company Officer 3 Title";
        private const string F_Name4 = "Company Officer 4";
        private const string Title4 = "Company Officer 4 Title";
        private const string G_Name1 = "Designated Rep 1";
        private const string G_Name2 = "Designated Rep 2";
        private const string G_Name3 = "Designated Rep 3";
        private const string G_Name4 = "Designated Rep 4";
        private const string H_CompanyOfficial = "Company Official";
        private const string H_Title = "Company Official Title";
        private const string D1 = "Month";
        private const string D2 = "Day";
        private const string D3 = "Year";
        private const string CountyOf = "County of";
        private const string OnThe = "Day 2";
        private const string MonthOf = "Month 2";
        private const string Personally_Came = "Company Official 2";
        private const string Acknowledged = "Company Official 3";
        private const string Authorized_rep6 = "Authorized Rep 6";
        private const string Affiliation6 = "Affiliation 6";
        private const string Telephone6 = "Telephone 6";
        private const string Authorized_rep7 = "Authorized Rep 7";
        private const string Affiliation7 = "Affiliation 7";
        private const string Telephone7 = "Telephone 7";
        private const string Authorized_rep8 = "Authorized Rep 8";
        private const string Affiliation8 = "Affiliation 8";
        private const string Telephone8 = "Telephone 8";
        private const string Authorized_rep9 = "Authorized Rep 9";
        private const string Affiliation9 = "Affiliation 9";
        private const string Telephone9 = "Telephone 9";
        private const string Authorized_rep10 = "Authorized Rep 10";
        private const string Affiliation10 = "Affiliation 10";
        private const string Telephone10 = "Telephone 10";
        private const string Authorized_rep11 = "Authorized Rep 11";
        private const string Affiliation11 = "Affiliation 11";
        private const string Telephone11 = "Telephone 11";
        private const string Authorized_rep12 = "Authorized Rep 12";
        private const string Affiliation12 = "Affiliation 12";
        private const string Telephone12 = "Telephone 12";
        private const string Authorized_rep13 = "Authorized Rep 13";
        private const string Affiliation13 = "Affiliation 13";
        private const string Telephone13 = "Telephone 13";
        private const string Authorized_rep14 = "Authorized Rep 14";
        private const string Affiliation14 = "Affiliation 14";
        private const string Telephone14 = "Telephone 14";
        private const string Authorized_rep15 = "Authorized Rep 15";
        private const string Affiliation15 = "Affiliation 15";
        private const string Telephone15 = "Telephone 15";
        private const string Authorized_rep16 = "Authorized Rep 16";
        private const string Affiliation16 = "Affiliation 16";
        private const string Telephone16 = "Telephone 16";
        private const string Authorized_rep17 = "Authorized Rep 17";
        private const string Affiliation17 = "Affiliation 17";
        private const string Telephone17 = "Telephone 17";
        private const string Authorized_rep18 = "Authorized Rep 18";
        private const string Affiliation18 = "Affiliation 18";
        private const string Telephone18 = "Telephone 18";
        private const string Authorized_rep19 = "Authorized Rep 19";
        private const string Affiliation19 = "Affiliation 19";
        private const string Telephone19 = "Telephone 19";
        private const string Authorized_rep20 = "Authorized Rep 20";
        private const string Affiliation20 = "Affiliation 20";
        private const string Telephone20 = "Telephone 20";
        private const string Authorized_rep21 = "Authorized Rep 21";
        private const string Affiliation21 = "Affiliation 21";
        private const string Telephone21 = "Telephone 21";
        private const string Authorized_rep22 = "Authorized Rep 22";
        private const string Affiliation22 = "Affiliation 22";
        private const string Telephone22 = "Telephone 22";
        private const string Authorizede_rep23 = "Authorized Rep 23";
        private const string Affiliation23 = "Affiliation 23";
        private const string Telephone23 = "Telephone 23";
        private const string Authorized_rep24 = "Authorized Rep 24";
        private const string Affiliation24 = "Affiliation 24";
        private const string Telephone24 = "Telephone 24";
        private const string Authorized_rep25 = "Authorized Rep 25";
        private const string Affiliation25 = "Affiliation 25";
        private const string Telephone25 = "Telephone 25";
        private const string Authorized_rep26 = "Authorized Rep 26";
        private const string Affiliation26 = "Affiliation 26";
        private const string Telephone26 = "Telephone 26";
        private const string Authorized_rep27 = "Authorized Rep 27";
        private const string Affiliation27 = "Affiliation 27";
        private const string Telephone27 = "Telephone 27";
        private const string Authorized_rep28 = "Authorized Rep 28";
        private const string Affiliation28 = "Affiliation 28";
        private const string Telephone28 = "Telephone 28";
        private const string Authorized_rep29 = "Authorized Rep 29";
        private const string Affiliation29 = "Affiliation 29";
        private const string Telephone29 = "Telephone 29";
        private const string Authorized_rep30 = "Authorized Rep 30";
        private const string Affiliation30 = "Affiliation 30";
        private const string Telephone30 = "Telephone 30";
        private const string Auhorized_rep31 = "Authorized Rep 31";
        private const string Affiliation31 = "Affiliation 31";
        private const string Telephone31 = "Telephone 31";
        private const string Authorized_rep32 = "Authorized Rep 32";
        private const string Affiliation32 = "Affiliation 32";
        private const string Telephone32 = "Telephone 32";
        private const string Authorized_rep33 = "Authorized Rep 33";
        private const string Affiliation33 = "Affiliation 33";
        private const string Telephone33 = "Telephone 33";
        private const string Authorized_rep34 = "Authorized Rep 34";
        private const string Affiliation34 = "Affiliation 34";
        private const string Telephone34 = "Telephone 34";
        private const string Authorized_rep35 = "Authorized Rep 35";
        private const string Affiliation35 = "Affiliation 35";
        private const string Telephone35 = "Telephone 35";
        private const string Authorized_rep36 = "Authorized Rep 36";
        private const string Affiliation36 = "Affiliation 36";
        private const string Telephone36 = "Telephone 36";
        private const string Authorized_rep37 = "Authorized Rep 37";
        private const string Affiliation37 = "Affiliation 37";
        private const string Telephone37 = "Telephone 37";
        private const string Authorized_rep38 = "Authorized Rep 38";
        private const string Affiliation38 = "Affiliation 38";
        private const string Telephone38 = "Telephone 38";
        private const string Authorized_rep39 = "Authorized Rep 39";
        private const string Affiliation39 = "Affiliation 39";
        private const string Telephone39 = "Telephone 39";
        private const string Authjorized_rep40 = "Authorized Rep 40";
        private const string Affiliation40 = "Affiliation 40";
        private const string Telephone40 = "Telephone 40";
        private const string Company_Office5 = "Company Officer 5";
        private const string Company_Officer_Title5 = "Company Officer 5 Title";
        private const string Company_Officer6 = "Company Officer 6";
        private const string Company_Officer_Title6 = "Company Officer 6 Title";
        private const string Company_Officer7 = "Company Officer 7";
        private const string Company_Officer_Title7 = "Company Officer 7 Title";
        private const string Company_Officer8 = "Company Officer 8";
        private const string Company_Officer_Title8 = "Company Officer 8 Title";
        private const string Company_officer9 = "Company Officer 9";
        private const string Company_Officer_Title9 = "Company Officer 9 Title";
        private const string Company_Officcer10 = "Company Officer 10";
        private const string Company_Officer_Title10 = "Company Officer 10 Title";
        private const string Company_Officer11 = "Company Officer 11";
        private const string Company_Officer_Title11 = "Company Officer 11 Title";
        private const string Company_Officer12 = "Company Officer 12";
        private const string Company_Oficer_Title12 = "Company Officer 12 Title";
        private const string Company_Officer13 = "Company Officer 13";
        private const string Company_Officer_Title13 = "Company Officer 13 Title";
        private const string Company_Officer14 = "Company Officer 14";
        private const string Company_Officer_Title14 = "Company Officer 14 Title";
        private const string Company_Officer15 = "Company Officer 15";
        private const string Company_Officer_Title15 = "Company Officer 15 Title";
        private const string Company_Officer16 = "Company Officer 16";
        private const string Company_Officer_Title16 = "Company Officer 16 Title";
        #endregion
        #region Properties
        public string A_Name_Pro
        {
            get
            {
                return dot_regapp_ht[A_Name].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(A_Name))
                    dot_regapp_ht[A_Name] = value;
                else
                    dot_regapp_ht.Add(A_Name, value);
            }
        }
        public string A_AKA_Pro
        {
            get
            {
                return dot_regapp_ht[A_AKA].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(A_AKA))
                    dot_regapp_ht[A_AKA] = value;
                else
                    dot_regapp_ht.Add(A_AKA, value);
            }
        }
        public string TIDNo_Pro
        {
            get
            {
                return dot_regapp_ht[TIDNo].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(TIDNo))
                    dot_regapp_ht[TIDNo] = value;
                else
                    dot_regapp_ht.Add(TIDNo, value);
            }
        }
        public string A_Address_Pro
        {
            get
            {
                return dot_regapp_ht[A_Address].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(A_Address))
                    dot_regapp_ht[A_Address] = value;
                else
                    dot_regapp_ht.Add(A_Address, value);
            }
        }
        public string A_CIty_Pro
        {
            get
            {
                return dot_regapp_ht[A_CIty].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(A_CIty))
                    dot_regapp_ht[A_CIty] = value;
                else
                    dot_regapp_ht.Add(A_CIty, value);
            }
        }
        public string A_STate_Pro
        {
            get
            {
                return dot_regapp_ht[A_STate].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(A_STate))
                    dot_regapp_ht[A_STate] = value;
                else
                    dot_regapp_ht.Add(A_STate, value);
            }
        }
        public string A_Zip_Pro
        {
            get
            {
                return dot_regapp_ht[A_Zip].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(A_Zip))
                    dot_regapp_ht[A_Zip] = value;
                else
                    dot_regapp_ht.Add(A_Zip, value);
            }
        }
        public string T1_Pro
        {
            get
            {
                return dot_regapp_ht[T1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(T1))
                    dot_regapp_ht[T1] = value;
                else
                    dot_regapp_ht.Add(T1, value);
            }
        }
        public string T2_Pro
        {
            get
            {
                return dot_regapp_ht[T2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(T2))
                    dot_regapp_ht[T2] = value;
                else
                    dot_regapp_ht.Add(T2, value);
            }
        }
        public string T3_Pro
        {
            get
            {
                return dot_regapp_ht[T3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(T3))
                    dot_regapp_ht[T3] = value;
                else
                    dot_regapp_ht.Add(T3, value);
            }
        }
        public string Fax1_Pro
        {
            get
            {
                return dot_regapp_ht[Fax1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Fax1))
                    dot_regapp_ht[Fax1] = value;
                else
                    dot_regapp_ht.Add(Fax1, value);
            }
        }
        public string Fax2_Pro
        {
            get
            {
                return dot_regapp_ht[Fax2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Fax2))
                    dot_regapp_ht[Fax2] = value;
                else
                    dot_regapp_ht.Add(Fax2, value);
            }
        }
        public string Fax3_Pro
        {
            get
            {
                return dot_regapp_ht[Fax3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Fax3))
                    dot_regapp_ht[Fax3] = value;
                else
                    dot_regapp_ht.Add(Fax3, value);
            }
        }
        public string T4_Pro
        {
            get
            {
                return dot_regapp_ht[T4].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(T4))
                    dot_regapp_ht[T4] = value;
                else
                    dot_regapp_ht.Add(T4, value);
            }
        }
        public string T5_Pro
        {
            get
            {
                return dot_regapp_ht[T5].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(T5))
                    dot_regapp_ht[T5] = value;
                else
                    dot_regapp_ht.Add(T5, value);
            }
        }
        public string T6_Pro
        {
            get
            {
                return dot_regapp_ht[T6].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(T6))
                    dot_regapp_ht[T6] = value;
                else
                    dot_regapp_ht.Add(T6, value);
            }
        }
        public string A_Email_Pro
        {
            get
            {
                return dot_regapp_ht[A_Email].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(A_Email))
                    dot_regapp_ht[A_Email] = value;
                else
                    dot_regapp_ht.Add(A_Email, value);
            }
        }
        public string B_CunsumerAffairs_Pro
        {
            get
            {
                return dot_regapp_ht[B_CunsumerAffairs].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(B_CunsumerAffairs))
                    dot_regapp_ht[B_CunsumerAffairs] = value;
                else
                    dot_regapp_ht.Add(B_CunsumerAffairs, value);
            }
        }
        public string B_NameOfCompanyLicense1_Pro
        {
            get
            {
                return dot_regapp_ht[B_NameOfCompanyLicense1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(B_NameOfCompanyLicense1))
                    dot_regapp_ht[B_NameOfCompanyLicense1] = value;
                else
                    dot_regapp_ht.Add(B_NameOfCompanyLicense1, value);
            }
        }
        public string B_SignHanger_Pro
        {
            get
            {
                return dot_regapp_ht[B_SignHanger].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(B_SignHanger))
                    dot_regapp_ht[B_SignHanger] = value;
                else
                    dot_regapp_ht.Add(B_SignHanger, value);
            }
        }
        public string B_NameOfCompanyLicense2_Pro
        {
            get
            {
                return dot_regapp_ht[B_NameOfCompanyLicense2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(B_NameOfCompanyLicense2))
                    dot_regapp_ht[B_NameOfCompanyLicense2] = value;
                else
                    dot_regapp_ht.Add(B_NameOfCompanyLicense2, value);
            }
        }
        public string B_MasterRigger_Pro
        {
            get
            {
                return dot_regapp_ht[B_MasterRigger].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(B_MasterRigger))
                    dot_regapp_ht[B_MasterRigger] = value;
                else
                    dot_regapp_ht.Add(B_MasterRigger, value);
            }
        }
        public string B_NameOfCompanyLicense3_Pro
        {
            get
            {
                return dot_regapp_ht[B_NameOfCompanyLicense3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(B_NameOfCompanyLicense3))
                    dot_regapp_ht[B_NameOfCompanyLicense3] = value;
                else
                    dot_regapp_ht.Add(B_NameOfCompanyLicense3, value);
            }
        }
        public string B_Plumber_Pro
        {
            get
            {
                return dot_regapp_ht[B_Plumber].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(B_Plumber))
                    dot_regapp_ht[B_Plumber] = value;
                else
                    dot_regapp_ht.Add(B_Plumber, value);
            }
        }
        public string B_NameOfCompanyLicense4_Pro
        {
            get
            {
                return dot_regapp_ht[B_NameOfCompanyLicense4].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(B_NameOfCompanyLicense4))
                    dot_regapp_ht[B_NameOfCompanyLicense4] = value;
                else
                    dot_regapp_ht.Add(B_NameOfCompanyLicense4, value);
            }
        }
        public string General_Contractor_Pro
        {
            get
            {
                return dot_regapp_ht[General_Contractor].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(General_Contractor))
                    dot_regapp_ht[General_Contractor] = value;
                else
                    dot_regapp_ht.Add(General_Contractor, value);
            }
        }
        public string Govt_Contractor_Pro
        {
            get
            {
                return dot_regapp_ht[Govt_Contractor].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Govt_Contractor))
                    dot_regapp_ht[Govt_Contractor] = value;
                else
                    dot_regapp_ht.Add(Govt_Contractor, value);
            }
        }
        public string Authority_Contractor_Pro
        {
            get
            {
                return dot_regapp_ht[Authority_Contractor].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authority_Contractor))
                    dot_regapp_ht[Authority_Contractor] = value;
                else
                    dot_regapp_ht.Add(Authority_Contractor, value);
            }
        }
        public string Sidewalk_Contractor_Pro
        {
            get
            {
                return dot_regapp_ht[Sidewalk_Contractor].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Sidewalk_Contractor))
                    dot_regapp_ht[Sidewalk_Contractor] = value;
                else
                    dot_regapp_ht.Add(Sidewalk_Contractor, value);
            }
        }
        public string Crane_Pro
        {
            get
            {
                return dot_regapp_ht[Crane].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Crane))
                    dot_regapp_ht[Crane] = value;
                else
                    dot_regapp_ht.Add(Crane, value);
            }
        }
        public string CommercialRefuse_Pro
        {
            get
            {
                return dot_regapp_ht[CommercialRefuse].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(CommercialRefuse))
                    dot_regapp_ht[CommercialRefuse] = value;
                else
                    dot_regapp_ht.Add(CommercialRefuse, value);
            }
        }
        public string C_BICLicense_Pro
        {
            get
            {
                return dot_regapp_ht[C_BICLicense].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(C_BICLicense))
                    dot_regapp_ht[C_BICLicense] = value;
                else
                    dot_regapp_ht.Add(C_BICLicense, value);
            }
        }
        public string Other_Pro
        {
            get
            {
                return dot_regapp_ht[Other].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Other))
                    dot_regapp_ht[Other] = value;
                else
                    dot_regapp_ht.Add(Other, value);
            }
        }
        public string C_Identify_Pro
        {
            get
            {
                return dot_regapp_ht[C_Identify].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(C_Identify))
                    dot_regapp_ht[C_Identify] = value;
                else
                    dot_regapp_ht.Add(C_Identify, value);
            }
        }
        public string Manhattan_Pro
        {
            get
            {
                return dot_regapp_ht[Manhattan].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Manhattan))
                    dot_regapp_ht[Manhattan] = value;
                else
                    dot_regapp_ht.Add(Manhattan, value);
            }
        }
        public string Brooklyn_Pro
        {
            get
            {
                return dot_regapp_ht[Brooklyn].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Brooklyn))
                    dot_regapp_ht[Brooklyn] = value;
                else
                    dot_regapp_ht.Add(Brooklyn, value);
            }
        }
        public string Queens_Pro
        {
            get
            {
                return dot_regapp_ht[Queens].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Queens))
                    dot_regapp_ht[Queens] = value;
                else
                    dot_regapp_ht.Add(Queens, value);
            }
        }
        public string Bronx_Pro
        {
            get
            {
                return dot_regapp_ht[Bronx].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Bronx))
                    dot_regapp_ht[Bronx] = value;
                else
                    dot_regapp_ht.Add(Bronx, value);
            }
        }
        public string Staten_Island_Pro
        {
            get
            {
                return dot_regapp_ht[Staten_Island].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Staten_Island))
                    dot_regapp_ht[Staten_Island] = value;
                else
                    dot_regapp_ht.Add(Staten_Island, value);
            }
        }
        public string E_Name1_Pro
        {
            get
            {
                return dot_regapp_ht[E_Name1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Name1))
                    dot_regapp_ht[E_Name1] = value;
                else
                    dot_regapp_ht.Add(E_Name1, value);
            }
        }
        public string E_Affiliation1_Pro
        {
            get
            {
                return dot_regapp_ht[E_Affiliation1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Affiliation1))
                    dot_regapp_ht[E_Affiliation1] = value;
                else
                    dot_regapp_ht.Add(E_Affiliation1, value);
            }
        }
        public string Telephone1_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone1))
                    dot_regapp_ht[Telephone1] = value;
                else
                    dot_regapp_ht.Add(Telephone1, value);
            }
        }
        public string E_Name2_Pro
        {
            get
            {
                return dot_regapp_ht[E_Name2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Name2))
                    dot_regapp_ht[E_Name2] = value;
                else
                    dot_regapp_ht.Add(E_Name2, value);
            }
        }
        public string E_Affiliation2_Pro
        {
            get
            {
                return dot_regapp_ht[E_Affiliation2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Affiliation2))
                    dot_regapp_ht[E_Affiliation2] = value;
                else
                    dot_regapp_ht.Add(E_Affiliation2, value);
            }
        }
        public string Telephone2_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone2))
                    dot_regapp_ht[Telephone2] = value;
                else
                    dot_regapp_ht.Add(Telephone2, value);
            }
        }
        public string E_Name3_Pro
        {
            get
            {
                return dot_regapp_ht[E_Name3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Name3))
                    dot_regapp_ht[E_Name3] = value;
                else
                    dot_regapp_ht.Add(E_Name3, value);
            }
        }
        public string E_Affiliation3_Pro
        {
            get
            {
                return dot_regapp_ht[E_Affiliation3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Affiliation3))
                    dot_regapp_ht[E_Affiliation3] = value;
                else
                    dot_regapp_ht.Add(E_Affiliation3, value);
            }
        }
        public string Telephone3_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone3))
                    dot_regapp_ht[Telephone3] = value;
                else
                    dot_regapp_ht.Add(Telephone3, value);
            }
        }
        public string E_Name4_Pro
        {
            get
            {
                return dot_regapp_ht[E_Name4].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Name4))
                    dot_regapp_ht[E_Name4] = value;
                else
                    dot_regapp_ht.Add(E_Name4, value);
            }
        }
        public string E_Affiliation4_Pro
        {
            get
            {
                return dot_regapp_ht[E_Affiliation4].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Affiliation4))
                    dot_regapp_ht[E_Affiliation4] = value;
                else
                    dot_regapp_ht.Add(E_Affiliation4, value);
            }
        }
        public string Telephone4_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone4].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone4))
                    dot_regapp_ht[Telephone4] = value;
                else
                    dot_regapp_ht.Add(Telephone4, value);
            }
        }
        public string E_Name5_Pro
        {
            get
            {
                return dot_regapp_ht[E_Name5].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Name5))
                    dot_regapp_ht[E_Name5] = value;
                else
                    dot_regapp_ht.Add(E_Name5, value);
            }
        }
        public string E_Affiliation5_Pro
        {
            get
            {
                return dot_regapp_ht[E_Affiliation5].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(E_Affiliation5))
                    dot_regapp_ht[E_Affiliation5] = value;
                else
                    dot_regapp_ht.Add(E_Affiliation5, value);
            }
        }
        public string Telephone5_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone5].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone5))
                    dot_regapp_ht[Telephone5] = value;
                else
                    dot_regapp_ht.Add(Telephone5, value);
            }
        }
        public string F_Name1_Pro
        {
            get
            {
                return dot_regapp_ht[F_Name1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(F_Name1))
                    dot_regapp_ht[F_Name1] = value;
                else
                    dot_regapp_ht.Add(F_Name1, value);
            }
        }
        public string Title1_Pro
        {
            get
            {
                return dot_regapp_ht[Title1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Title1))
                    dot_regapp_ht[Title1] = value;
                else
                    dot_regapp_ht.Add(Title1, value);
            }
        }
        public string F_Name2_Pro
        {
            get
            {
                return dot_regapp_ht[F_Name2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(F_Name2))
                    dot_regapp_ht[F_Name2] = value;
                else
                    dot_regapp_ht.Add(F_Name2, value);
            }
        }
        public string Title2_Pro
        {
            get
            {
                return dot_regapp_ht[Title2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Title2))
                    dot_regapp_ht[Title2] = value;
                else
                    dot_regapp_ht.Add(Title2, value);
            }
        }
        public string F_Name3_Pro
        {
            get
            {
                return dot_regapp_ht[F_Name3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(F_Name3))
                    dot_regapp_ht[F_Name3] = value;
                else
                    dot_regapp_ht.Add(F_Name3, value);
            }
        }
        public string Title3_Pro
        {
            get
            {
                return dot_regapp_ht[Title3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Title3))
                    dot_regapp_ht[Title3] = value;
                else
                    dot_regapp_ht.Add(Title3, value);
            }
        }
        public string F_Name4_Pro
        {
            get
            {
                return dot_regapp_ht[F_Name4].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(F_Name4))
                    dot_regapp_ht[F_Name4] = value;
                else
                    dot_regapp_ht.Add(F_Name4, value);
            }
        }
        public string Title4_Pro
        {
            get
            {
                return dot_regapp_ht[Title4].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Title4))
                    dot_regapp_ht[Title4] = value;
                else
                    dot_regapp_ht.Add(Title4, value);
            }
        }
        public string G_Name1_Pro
        {
            get
            {
                return dot_regapp_ht[G_Name1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(G_Name1))
                    dot_regapp_ht[G_Name1] = value;
                else
                    dot_regapp_ht.Add(G_Name1, value);
            }
        }
        public string G_Name2_Pro
        {
            get
            {
                return dot_regapp_ht[G_Name2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(G_Name2))
                    dot_regapp_ht[G_Name2] = value;
                else
                    dot_regapp_ht.Add(G_Name2, value);
            }
        }
        public string G_Name3_Pro
        {
            get
            {
                return dot_regapp_ht[G_Name3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(G_Name3))
                    dot_regapp_ht[G_Name3] = value;
                else
                    dot_regapp_ht.Add(G_Name3, value);
            }
        }
        public string G_Name4_Pro
        {
            get
            {
                return dot_regapp_ht[G_Name4].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(G_Name4))
                    dot_regapp_ht[G_Name4] = value;
                else
                    dot_regapp_ht.Add(G_Name4, value);
            }
        }
        public string H_CompanyOfficial_Pro
        {
            get
            {
                return dot_regapp_ht[H_CompanyOfficial].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(H_CompanyOfficial))
                    dot_regapp_ht[H_CompanyOfficial] = value;
                else
                    dot_regapp_ht.Add(H_CompanyOfficial, value);
            }
        }
        public string H_Title_Pro
        {
            get
            {
                return dot_regapp_ht[H_Title].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(H_Title))
                    dot_regapp_ht[H_Title] = value;
                else
                    dot_regapp_ht.Add(H_Title, value);
            }
        }
        public string D1_Pro
        {
            get
            {
                return dot_regapp_ht[D1].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(D1))
                    dot_regapp_ht[D1] = value;
                else
                    dot_regapp_ht.Add(D1, value);
            }
        }
        public string D2_Pro
        {
            get
            {
                return dot_regapp_ht[D2].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(D2))
                    dot_regapp_ht[D2] = value;
                else
                    dot_regapp_ht.Add(D2, value);
            }
        }
        public string D3_Pro
        {
            get
            {
                return dot_regapp_ht[D3].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(D3))
                    dot_regapp_ht[D3] = value;
                else
                    dot_regapp_ht.Add(D3, value);
            }
        }
        public string CountyOf_Pro
        {
            get
            {
                return dot_regapp_ht[CountyOf].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(CountyOf))
                    dot_regapp_ht[CountyOf] = value;
                else
                    dot_regapp_ht.Add(CountyOf, value);
            }
        }
        public string OnThe_Pro
        {
            get
            {
                return dot_regapp_ht[OnThe].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(OnThe))
                    dot_regapp_ht[OnThe] = value;
                else
                    dot_regapp_ht.Add(OnThe, value);
            }
        }
        public string MonthOf_Pro
        {
            get
            {
                return dot_regapp_ht[MonthOf].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(MonthOf))
                    dot_regapp_ht[MonthOf] = value;
                else
                    dot_regapp_ht.Add(MonthOf, value);
            }
        }
        public string Personally_Came_Pro
        {
            get
            {
                return dot_regapp_ht[Personally_Came].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Personally_Came))
                    dot_regapp_ht[Personally_Came] = value;
                else
                    dot_regapp_ht.Add(Personally_Came, value);
            }
        }
        public string Acknowledged_Pro
        {
            get
            {
                return dot_regapp_ht[Acknowledged].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Acknowledged))
                    dot_regapp_ht[Acknowledged] = value;
                else
                    dot_regapp_ht.Add(Acknowledged, value);
            }
        }
        public string Authorized_rep6_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep6].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep6))
                    dot_regapp_ht[Authorized_rep6] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep6, value);
            }
        }
        public string Affiliation6_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation6].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation6))
                    dot_regapp_ht[Affiliation6] = value;
                else
                    dot_regapp_ht.Add(Affiliation6, value);
            }
        }
        public string Telephone6_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone6].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone6))
                    dot_regapp_ht[Telephone6] = value;
                else
                    dot_regapp_ht.Add(Telephone6, value);
            }
        }
        public string Authorized_rep7_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep7].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep7))
                    dot_regapp_ht[Authorized_rep7] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep7, value);
            }
        }
        public string Affiliation7_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation7].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation7))
                    dot_regapp_ht[Affiliation7] = value;
                else
                    dot_regapp_ht.Add(Affiliation7, value);
            }
        }
        public string Telephone7_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone7].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone7))
                    dot_regapp_ht[Telephone7] = value;
                else
                    dot_regapp_ht.Add(Telephone7, value);
            }
        }
        public string Authorized_rep8_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep8].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep8))
                    dot_regapp_ht[Authorized_rep8] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep8, value);
            }
        }
        public string Affiliation8_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation8].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation8))
                    dot_regapp_ht[Affiliation8] = value;
                else
                    dot_regapp_ht.Add(Affiliation8, value);
            }
        }
        public string Telephone8_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone8].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone8))
                    dot_regapp_ht[Telephone8] = value;
                else
                    dot_regapp_ht.Add(Telephone8, value);
            }
        }
        public string Authorized_rep9_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep9].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep9))
                    dot_regapp_ht[Authorized_rep9] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep9, value);
            }
        }
        public string Affiliation9_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation9].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation9))
                    dot_regapp_ht[Affiliation9] = value;
                else
                    dot_regapp_ht.Add(Affiliation9, value);
            }
        }
        public string Telephone9_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone9].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone9))
                    dot_regapp_ht[Telephone9] = value;
                else
                    dot_regapp_ht.Add(Telephone9, value);
            }
        }
        public string Authorized_rep10_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep10].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep10))
                    dot_regapp_ht[Authorized_rep10] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep10, value);
            }
        }
        public string Affiliation10_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation10].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation10))
                    dot_regapp_ht[Affiliation10] = value;
                else
                    dot_regapp_ht.Add(Affiliation10, value);
            }
        }
        public string Telephone10_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone10].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone10))
                    dot_regapp_ht[Telephone10] = value;
                else
                    dot_regapp_ht.Add(Telephone10, value);
            }
        }
        public string Authorized_rep11_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep11].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep11))
                    dot_regapp_ht[Authorized_rep11] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep11, value);
            }
        }
        public string Affiliation11_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation11].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation11))
                    dot_regapp_ht[Affiliation11] = value;
                else
                    dot_regapp_ht.Add(Affiliation11, value);
            }
        }
        public string Telephone11_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone11].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone11))
                    dot_regapp_ht[Telephone11] = value;
                else
                    dot_regapp_ht.Add(Telephone11, value);
            }
        }
        public string Authorized_rep12_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep12].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep12))
                    dot_regapp_ht[Authorized_rep12] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep12, value);
            }
        }
        public string Affiliation12_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation12].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation12))
                    dot_regapp_ht[Affiliation12] = value;
                else
                    dot_regapp_ht.Add(Affiliation12, value);
            }
        }
        public string Telephone12_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone12].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone12))
                    dot_regapp_ht[Telephone12] = value;
                else
                    dot_regapp_ht.Add(Telephone12, value);
            }
        }
        public string Authorized_rep13_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep13].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep13))
                    dot_regapp_ht[Authorized_rep13] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep13, value);
            }
        }
        public string Affiliation13_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation13].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation13))
                    dot_regapp_ht[Affiliation13] = value;
                else
                    dot_regapp_ht.Add(Affiliation13, value);
            }
        }
        public string Telephone13_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone13].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone13))
                    dot_regapp_ht[Telephone13] = value;
                else
                    dot_regapp_ht.Add(Telephone13, value);
            }
        }
        public string Authorized_rep14_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep14].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep14))
                    dot_regapp_ht[Authorized_rep14] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep14, value);
            }
        }
        public string Affiliation14_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation14].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation14))
                    dot_regapp_ht[Affiliation14] = value;
                else
                    dot_regapp_ht.Add(Affiliation14, value);
            }
        }
        public string Telephone14_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone14].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone14))
                    dot_regapp_ht[Telephone14] = value;
                else
                    dot_regapp_ht.Add(Telephone14, value);
            }
        }
        public string Authorized_rep15_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep15].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep15))
                    dot_regapp_ht[Authorized_rep15] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep15, value);
            }
        }
        public string Affiliation15_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation15].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation15))
                    dot_regapp_ht[Affiliation15] = value;
                else
                    dot_regapp_ht.Add(Affiliation15, value);
            }
        }
        public string Telephone15_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone15].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone15))
                    dot_regapp_ht[Telephone15] = value;
                else
                    dot_regapp_ht.Add(Telephone15, value);
            }
        }
        public string Authorized_rep16_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep16].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep16))
                    dot_regapp_ht[Authorized_rep16] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep16, value);
            }
        }
        public string Affiliation16_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation16].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation16))
                    dot_regapp_ht[Affiliation16] = value;
                else
                    dot_regapp_ht.Add(Affiliation16, value);
            }
        }
        public string Telephone16_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone16].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone16))
                    dot_regapp_ht[Telephone16] = value;
                else
                    dot_regapp_ht.Add(Telephone16, value);
            }
        }
        public string Authorized_rep17_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep17].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep17))
                    dot_regapp_ht[Authorized_rep17] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep17, value);
            }
        }
        public string Affiliation17_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation17].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation17))
                    dot_regapp_ht[Affiliation17] = value;
                else
                    dot_regapp_ht.Add(Affiliation17, value);
            }
        }
        public string Telephone17_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone17].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone17))
                    dot_regapp_ht[Telephone17] = value;
                else
                    dot_regapp_ht.Add(Telephone17, value);
            }
        }
        public string Authorized_rep18_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep18].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep18))
                    dot_regapp_ht[Authorized_rep18] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep18, value);
            }
        }
        public string Affiliation18_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation18].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation18))
                    dot_regapp_ht[Affiliation18] = value;
                else
                    dot_regapp_ht.Add(Affiliation18, value);
            }
        }
        public string Telephone18_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone18].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone18))
                    dot_regapp_ht[Telephone18] = value;
                else
                    dot_regapp_ht.Add(Telephone18, value);
            }
        }
        public string Authorized_rep19_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep19].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep19))
                    dot_regapp_ht[Authorized_rep19] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep19, value);
            }
        }
        public string Affiliation19_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation19].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation19))
                    dot_regapp_ht[Affiliation19] = value;
                else
                    dot_regapp_ht.Add(Affiliation19, value);
            }
        }
        public string Telephone19_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone19].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone19))
                    dot_regapp_ht[Telephone19] = value;
                else
                    dot_regapp_ht.Add(Telephone19, value);
            }
        }
        public string Authorized_rep20_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep20].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep20))
                    dot_regapp_ht[Authorized_rep20] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep20, value);
            }
        }
        public string Affiliation20_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation20].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation20))
                    dot_regapp_ht[Affiliation20] = value;
                else
                    dot_regapp_ht.Add(Affiliation20, value);
            }
        }
        public string Telephone20_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone20].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone20))
                    dot_regapp_ht[Telephone20] = value;
                else
                    dot_regapp_ht.Add(Telephone20, value);
            }
        }
        public string Authorized_rep21_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep21].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep21))
                    dot_regapp_ht[Authorized_rep21] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep21, value);
            }
        }
        public string Affiliation21_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation21].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation21))
                    dot_regapp_ht[Affiliation21] = value;
                else
                    dot_regapp_ht.Add(Affiliation21, value);
            }
        }
        public string Telephone21_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone21].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone21))
                    dot_regapp_ht[Telephone21] = value;
                else
                    dot_regapp_ht.Add(Telephone21, value);
            }
        }
        public string Authorized_rep22_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep22].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep22))
                    dot_regapp_ht[Authorized_rep22] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep22, value);
            }
        }
        public string Affiliation22_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation22].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation22))
                    dot_regapp_ht[Affiliation22] = value;
                else
                    dot_regapp_ht.Add(Affiliation22, value);
            }
        }
        public string Telephone22_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone22].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone22))
                    dot_regapp_ht[Telephone22] = value;
                else
                    dot_regapp_ht.Add(Telephone22, value);
            }
        }
        public string Authorizede_rep23_Pro
        {
            get
            {
                return dot_regapp_ht[Authorizede_rep23].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorizede_rep23))
                    dot_regapp_ht[Authorizede_rep23] = value;
                else
                    dot_regapp_ht.Add(Authorizede_rep23, value);
            }
        }
        public string Affiliation23_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation23].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation23))
                    dot_regapp_ht[Affiliation23] = value;
                else
                    dot_regapp_ht.Add(Affiliation23, value);
            }
        }
        public string Telephone23_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone23].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone23))
                    dot_regapp_ht[Telephone23] = value;
                else
                    dot_regapp_ht.Add(Telephone23, value);
            }
        }
        public string Authorized_rep24_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep24].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep24))
                    dot_regapp_ht[Authorized_rep24] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep24, value);
            }
        }
        public string Affiliation24_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation24].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation24))
                    dot_regapp_ht[Affiliation24] = value;
                else
                    dot_regapp_ht.Add(Affiliation24, value);
            }
        }
        public string Telephone24_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone24].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone24))
                    dot_regapp_ht[Telephone24] = value;
                else
                    dot_regapp_ht.Add(Telephone24, value);
            }
        }
        public string Authorized_rep25_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep25].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep25))
                    dot_regapp_ht[Authorized_rep25] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep25, value);
            }
        }
        public string Affiliation25_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation25].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation25))
                    dot_regapp_ht[Affiliation25] = value;
                else
                    dot_regapp_ht.Add(Affiliation25, value);
            }
        }
        public string Telephone25_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone25].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone25))
                    dot_regapp_ht[Telephone25] = value;
                else
                    dot_regapp_ht.Add(Telephone25, value);
            }
        }
        public string Authorized_rep26_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep26].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep26))
                    dot_regapp_ht[Authorized_rep26] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep26, value);
            }
        }
        public string Affiliation26_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation26].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation26))
                    dot_regapp_ht[Affiliation26] = value;
                else
                    dot_regapp_ht.Add(Affiliation26, value);
            }
        }
        public string Telephone26_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone26].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone26))
                    dot_regapp_ht[Telephone26] = value;
                else
                    dot_regapp_ht.Add(Telephone26, value);
            }
        }
        public string Authorized_rep27_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep27].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep27))
                    dot_regapp_ht[Authorized_rep27] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep27, value);
            }
        }
        public string Affiliation27_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation27].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation27))
                    dot_regapp_ht[Affiliation27] = value;
                else
                    dot_regapp_ht.Add(Affiliation27, value);
            }
        }
        public string Telephone27_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone27].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone27))
                    dot_regapp_ht[Telephone27] = value;
                else
                    dot_regapp_ht.Add(Telephone27, value);
            }
        }
        public string Authorized_rep28_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep28].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep28))
                    dot_regapp_ht[Authorized_rep28] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep28, value);
            }
        }
        public string Affiliation28_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation28].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation28))
                    dot_regapp_ht[Affiliation28] = value;
                else
                    dot_regapp_ht.Add(Affiliation28, value);
            }
        }
        public string Telephone28_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone28].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone28))
                    dot_regapp_ht[Telephone28] = value;
                else
                    dot_regapp_ht.Add(Telephone28, value);
            }
        }
        public string Authorized_rep29_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep29].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep29))
                    dot_regapp_ht[Authorized_rep29] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep29, value);
            }
        }
        public string Affiliation29_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation29].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation29))
                    dot_regapp_ht[Affiliation29] = value;
                else
                    dot_regapp_ht.Add(Affiliation29, value);
            }
        }
        public string Telephone29_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone29].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone29))
                    dot_regapp_ht[Telephone29] = value;
                else
                    dot_regapp_ht.Add(Telephone29, value);
            }
        }
        public string Authorized_rep30_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep30].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep30))
                    dot_regapp_ht[Authorized_rep30] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep30, value);
            }
        }
        public string Affiliation30_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation30].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation30))
                    dot_regapp_ht[Affiliation30] = value;
                else
                    dot_regapp_ht.Add(Affiliation30, value);
            }
        }
        public string Telephone30_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone30].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone30))
                    dot_regapp_ht[Telephone30] = value;
                else
                    dot_regapp_ht.Add(Telephone30, value);
            }
        }
        public string Auhorized_rep31_Pro
        {
            get
            {
                return dot_regapp_ht[Auhorized_rep31].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Auhorized_rep31))
                    dot_regapp_ht[Auhorized_rep31] = value;
                else
                    dot_regapp_ht.Add(Auhorized_rep31, value);
            }
        }
        public string Affiliation31_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation31].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation31))
                    dot_regapp_ht[Affiliation31] = value;
                else
                    dot_regapp_ht.Add(Affiliation31, value);
            }
        }
        public string Telephone31_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone31].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone31))
                    dot_regapp_ht[Telephone31] = value;
                else
                    dot_regapp_ht.Add(Telephone31, value);
            }
        }
        public string Authorized_rep32_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep32].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep32))
                    dot_regapp_ht[Authorized_rep32] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep32, value);
            }
        }
        public string Affiliation32_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation32].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation32))
                    dot_regapp_ht[Affiliation32] = value;
                else
                    dot_regapp_ht.Add(Affiliation32, value);
            }
        }
        public string Telephone32_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone32].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone32))
                    dot_regapp_ht[Telephone32] = value;
                else
                    dot_regapp_ht.Add(Telephone32, value);
            }
        }
        public string Authorized_rep33_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep33].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep33))
                    dot_regapp_ht[Authorized_rep33] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep33, value);
            }
        }
        public string Affiliation33_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation33].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation33))
                    dot_regapp_ht[Affiliation33] = value;
                else
                    dot_regapp_ht.Add(Affiliation33, value);
            }
        }
        public string Telephone33_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone33].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone33))
                    dot_regapp_ht[Telephone33] = value;
                else
                    dot_regapp_ht.Add(Telephone33, value);
            }
        }
        public string Authorized_rep34_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep34].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep34))
                    dot_regapp_ht[Authorized_rep34] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep34, value);
            }
        }
        public string Affiliation34_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation34].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation34))
                    dot_regapp_ht[Affiliation34] = value;
                else
                    dot_regapp_ht.Add(Affiliation34, value);
            }
        }
        public string Telephone34_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone34].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone34))
                    dot_regapp_ht[Telephone34] = value;
                else
                    dot_regapp_ht.Add(Telephone34, value);
            }
        }
        public string Authorized_rep35_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep35].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep35))
                    dot_regapp_ht[Authorized_rep35] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep35, value);
            }
        }
        public string Affiliation35_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation35].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation35))
                    dot_regapp_ht[Affiliation35] = value;
                else
                    dot_regapp_ht.Add(Affiliation35, value);
            }
        }
        public string Telephone35_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone35].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone35))
                    dot_regapp_ht[Telephone35] = value;
                else
                    dot_regapp_ht.Add(Telephone35, value);
            }
        }
        public string Authorized_rep36_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep36].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep36))
                    dot_regapp_ht[Authorized_rep36] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep36, value);
            }
        }
        public string Affiliation36_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation36].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation36))
                    dot_regapp_ht[Affiliation36] = value;
                else
                    dot_regapp_ht.Add(Affiliation36, value);
            }
        }
        public string Telephone36_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone36].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone36))
                    dot_regapp_ht[Telephone36] = value;
                else
                    dot_regapp_ht.Add(Telephone36, value);
            }
        }
        public string Authorized_rep37_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep37].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep37))
                    dot_regapp_ht[Authorized_rep37] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep37, value);
            }
        }
        public string Affiliation37_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation37].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation37))
                    dot_regapp_ht[Affiliation37] = value;
                else
                    dot_regapp_ht.Add(Affiliation37, value);
            }
        }
        public string Telephone37_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone37].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone37))
                    dot_regapp_ht[Telephone37] = value;
                else
                    dot_regapp_ht.Add(Telephone37, value);
            }
        }
        public string Authorized_rep38_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep38].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep38))
                    dot_regapp_ht[Authorized_rep38] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep38, value);
            }
        }
        public string Affiliation38_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation38].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation38))
                    dot_regapp_ht[Affiliation38] = value;
                else
                    dot_regapp_ht.Add(Affiliation38, value);
            }
        }
        public string Telephone38_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone38].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone38))
                    dot_regapp_ht[Telephone38] = value;
                else
                    dot_regapp_ht.Add(Telephone38, value);
            }
        }
        public string Authorized_rep39_Pro
        {
            get
            {
                return dot_regapp_ht[Authorized_rep39].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authorized_rep39))
                    dot_regapp_ht[Authorized_rep39] = value;
                else
                    dot_regapp_ht.Add(Authorized_rep39, value);
            }
        }
        public string Affiliation39_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation39].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation39))
                    dot_regapp_ht[Affiliation39] = value;
                else
                    dot_regapp_ht.Add(Affiliation39, value);
            }
        }
        public string Telephone39_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone39].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone39))
                    dot_regapp_ht[Telephone39] = value;
                else
                    dot_regapp_ht.Add(Telephone39, value);
            }
        }
        public string Authjorized_rep40_Pro
        {
            get
            {
                return dot_regapp_ht[Authjorized_rep40].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Authjorized_rep40))
                    dot_regapp_ht[Authjorized_rep40] = value;
                else
                    dot_regapp_ht.Add(Authjorized_rep40, value);
            }
        }
        public string Affiliation40_Pro
        {
            get
            {
                return dot_regapp_ht[Affiliation40].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Affiliation40))
                    dot_regapp_ht[Affiliation40] = value;
                else
                    dot_regapp_ht.Add(Affiliation40, value);
            }
        }
        public string Telephone40_Pro
        {
            get
            {
                return dot_regapp_ht[Telephone40].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Telephone40))
                    dot_regapp_ht[Telephone40] = value;
                else
                    dot_regapp_ht.Add(Telephone40, value);
            }
        }
        public string Company_Office5_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Office5].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Office5))
                    dot_regapp_ht[Company_Office5] = value;
                else
                    dot_regapp_ht.Add(Company_Office5, value);
            }
        }
        public string Company_Officer_Title5_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title5].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title5))
                    dot_regapp_ht[Company_Officer_Title5] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title5, value);
            }
        }
        public string Company_Officer6_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer6].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer6))
                    dot_regapp_ht[Company_Officer6] = value;
                else
                    dot_regapp_ht.Add(Company_Officer6, value);
            }
        }
        public string Company_Officer_Title6_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title6].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title6))
                    dot_regapp_ht[Company_Officer_Title6] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title6, value);
            }
        }
        public string Company_Officer7_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer7].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer7))
                    dot_regapp_ht[Company_Officer7] = value;
                else
                    dot_regapp_ht.Add(Company_Officer7, value);
            }
        }
        public string Company_Officer_Title7_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title7].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title7))
                    dot_regapp_ht[Company_Officer_Title7] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title7, value);
            }
        }
        public string Company_Officer8_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer8].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer8))
                    dot_regapp_ht[Company_Officer8] = value;
                else
                    dot_regapp_ht.Add(Company_Officer8, value);
            }
        }
        public string Company_Officer_Title8_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title8].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title8))
                    dot_regapp_ht[Company_Officer_Title8] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title8, value);
            }
        }
        public string Company_officer9_Pro
        {
            get
            {
                return dot_regapp_ht[Company_officer9].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_officer9))
                    dot_regapp_ht[Company_officer9] = value;
                else
                    dot_regapp_ht.Add(Company_officer9, value);
            }
        }
        public string Company_Officer_Title9_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title9].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title9))
                    dot_regapp_ht[Company_Officer_Title9] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title9, value);
            }
        }
        public string Company_Officcer10_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officcer10].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officcer10))
                    dot_regapp_ht[Company_Officcer10] = value;
                else
                    dot_regapp_ht.Add(Company_Officcer10, value);
            }
        }
        public string Company_Officer_Title10_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title10].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title10))
                    dot_regapp_ht[Company_Officer_Title10] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title10, value);
            }
        }
        public string Company_Officer11_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer11].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer11))
                    dot_regapp_ht[Company_Officer11] = value;
                else
                    dot_regapp_ht.Add(Company_Officer11, value);
            }
        }
        public string Company_Officer_Title11_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title11].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title11))
                    dot_regapp_ht[Company_Officer_Title11] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title11, value);
            }
        }
        public string Company_Officer12_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer12].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer12))
                    dot_regapp_ht[Company_Officer12] = value;
                else
                    dot_regapp_ht.Add(Company_Officer12, value);
            }
        }
        public string Company_Oficer_Title12_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Oficer_Title12].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Oficer_Title12))
                    dot_regapp_ht[Company_Oficer_Title12] = value;
                else
                    dot_regapp_ht.Add(Company_Oficer_Title12, value);
            }
        }
        public string Company_Officer13_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer13].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer13))
                    dot_regapp_ht[Company_Officer13] = value;
                else
                    dot_regapp_ht.Add(Company_Officer13, value);
            }
        }
        public string Company_Officer_Title13_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title13].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title13))
                    dot_regapp_ht[Company_Officer_Title13] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title13, value);
            }
        }
        public string Company_Officer14_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer14].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer14))
                    dot_regapp_ht[Company_Officer14] = value;
                else
                    dot_regapp_ht.Add(Company_Officer14, value);
            }
        }
        public string Company_Officer_Title14_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title14].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title14))
                    dot_regapp_ht[Company_Officer_Title14] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title14, value);
            }
        }
        public string Company_Officer15_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer15].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer15))
                    dot_regapp_ht[Company_Officer15] = value;
                else
                    dot_regapp_ht.Add(Company_Officer15, value);
            }
        }
        public string Company_Officer_Title15_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title15].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title15))
                    dot_regapp_ht[Company_Officer_Title15] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title15, value);
            }
        }
        public string Company_Officer16_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer16].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer16))
                    dot_regapp_ht[Company_Officer16] = value;
                else
                    dot_regapp_ht.Add(Company_Officer16, value);
            }
        }
        public string Company_Officer_Title16_Pro
        {
            get
            {
                return dot_regapp_ht[Company_Officer_Title16].ToString();
            }
            set
            {
                if (dot_regapp_ht.ContainsKey(Company_Officer_Title16))
                    dot_regapp_ht[Company_Officer_Title16] = value;
                else
                    dot_regapp_ht.Add(Company_Officer_Title16, value);
            }
        }
        #endregion
        public void FillD_RegapppdfForm(string Path)
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
                    foreach (DictionaryEntry Element in dot_regapp_ht)
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